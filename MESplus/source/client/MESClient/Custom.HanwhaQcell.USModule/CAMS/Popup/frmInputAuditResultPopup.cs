//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmInputAuditResultPopup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCAMS() : View CAMS definition
//       - UpdateCAMS() : Create/Update/Delete CAMS
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-05-25 14:47:59 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmInputAuditResultPopup : TranForm01
    {
        public frmInputAuditResultPopup()
        {
            InitializeComponent();

            btnProcess.Location = new Point(640, 7);
            btnClose.Location = new Point(731, 7);

            spdItemList.ActiveSheet.RowCount = 0;

            GetSpreadComboboxList();
        }


        #region " Constant Definition "

        private enum LIST
        {
            CHECK,
            DIV_NAME,
            DIV_BTN,
            DIV_CODE,
            ITEM,
            DETAIL,
            RESULT,
            FILE_NAME,
            FILE_BTN,
            USER_NAME,
            USER_BTN,
            USER_ID,
            LIMIT_DATE
        }

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string m_audit_id;
        private bool m_new_flag;

        public string AUDIT_ID
        {
            get
            {
                if (m_audit_id == null)
                {
                    m_audit_id = "";
                }
                return m_audit_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_audit_id = "";
                }
                m_audit_id = value;
            }
        }

        public bool NEW_FLAG
        {
            get 
            {
                return m_new_flag;
            }
            set 
            {
                m_new_flag = value;
            }
        }

        #endregion

        #region " Function Definition "

        //
        // SetSpreadComboboxList()
        //       - Set Spread Combobox List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetSpreadComboboxList()
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;

                ArrayList alResultCode = new ArrayList();
                ArrayList alResultName = new ArrayList();
                alResultCode.Add("");
                alResultName.Add("");
                alResultCode.Add("C");
                alResultName.Add("Critical");
                alResultCode.Add("M");
                alResultName.Add("Major");
                alResultCode.Add("N");
                alResultName.Add("Minor");

                FarPoint.Win.Spread.CellType.ComboBoxCellType cb1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();//CellType 정의
                cb1.ItemData = (string[])alResultCode.ToArray(typeof(string));//ItemData 값 지정.
                cb1.Items = (string[])alResultName.ToArray(typeof(string)); //Items 값 지정..
                cb1.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData; //이 부분이 빠지면 안됨..
                with_1.Columns[MPCF.ToInt(LIST.RESULT)].CellType = cb1; //CellType 지정. .

                FarPoint.Win.Spread.CellType.DateTimeCellType _cell_type = (FarPoint.Win.Spread.CellType.DateTimeCellType)with_1.Columns[MPCF.ToInt(LIST.LIMIT_DATE)].CellType;
                _cell_type.DateDefault = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                with_1.Columns[MPCF.ToInt(LIST.LIMIT_DATE)].CellType = _cell_type;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.txtAuditID;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ('1', '2')
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    MPCF.FieldClear(this);

                    // TODO
                }
                else if (c_case == '2')
                {
                    // TODO
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string FuncName : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            //if (MPCF.CheckValue(txtKeyField, 1) == false)
            //{
            //    return false;
            //}

            switch (FuncName)
            {
                case "CREATE":
                    // TODO
                    break;
                case "UPDATE":
                case "DELETE":
                    if (MPCF.CheckValue(txtAuditID, 1) == false)
                    {
                        return false;
                    }
                    // TODO
                    break;
            }

            return true;            
        }


        //
        // ViewAuditPlan()
        //       - View Audit_Plan
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAuditPlan()
        {
            TRSNode in_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_IN");
            TRSNode out_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_OUT");
            byte[] bt_buffer;

            char c_status = '1';
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("AUDIT_ID", txtAuditID.Text);

                if (MPCR.CallService("CAMS", "CAMS_View_Audit_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("STATUS") != '0')
                {
                    btnProcess.Enabled = false;
                }

                txtAuditDesc.Text = out_node.GetString("AUDIT_DESC");
                txtPlanDate.Text = MPCF.DateToString(MPCF.ToDate(out_node.GetString("PLAN_DATE")));

                cdvCustomer.Text = out_node.GetString("CUSTOMER_CODE");
                cdvCustomer.DescText = out_node.GetString("CUSTOMER_NAME");

                txtAuditor.Text = out_node.GetString("AUDITOR");

                cdvManager.Text = out_node.GetString("MANAGER_ID");
                cdvManager.DescText = out_node.GetString("MANAGER_NAME");
                txtAgenda.Text = out_node.GetString("AGENDA");

                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;
                int i = 0;

                i = 0;
                List<TRSNode> audit_item_list = out_node.GetList("AUDIT_ITEM_LIST");
                foreach (TRSNode node in audit_item_list)
                {
                    with_1.RowCount = i + 1;
                    with_1.SetValue(i, MPCF.ToInt(LIST.CHECK), false);
                    with_1.SetValue(i, MPCF.ToInt(LIST.DIV_NAME), node.GetString("ITEM_DIV_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.DIV_CODE), node.GetString("ITEM_DIVISION"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.ITEM), node.GetString("ITEM_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.DETAIL), node.GetString("CHECK_DETAIL"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.RESULT), node.GetChar("CHECK_RESULT"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.FILE_NAME), node.GetString("FILE_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.USER_NAME), node.GetString("ACTION_MGR_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.USER_ID), node.GetString("ACTION_MGR_ID"));
                    if (MPCF.Trim(node.GetString("ACTION_LIMIT_DATE")) == "")
                    {
                        with_1.SetValue(i, MPCF.ToInt(LIST.LIMIT_DATE), "");
                    }
                    else
                    {
                        with_1.SetValue(i, MPCF.ToInt(LIST.LIMIT_DATE), MPCF.ToDate(node.GetString("ACTION_LIMIT_DATE")));
                    }                        

                    if ((bt_buffer = out_node.GetBlob(node.GetString("FILE_NAME"))) != null)
                    {
                        MemoryStream ms_buffer;
                        try
                        {
                            ms_buffer = new MemoryStream();
                            ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                            ms_buffer.Position = 0;
                            with_1.SetTag(i, MPCF.ToInt(LIST.FILE_NAME), bt_buffer);
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                    } 

                    i++;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateAuditResult()
        //       - Update Audit_Result
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateAuditResult()
        {
            TRSNode in_node = new TRSNode("CAMS_UPDATE_AUDIT_RESULT_IN");
            TRSNode out_node = new TRSNode("CAMS_UPDATE_AUDIT_RESULT_OUT");
            TRSNode list_item;
            byte[] file_buffer;

            char c_result;
            char c_status;

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("AUDIT_ID", txtAuditID.Text);        
                in_node.AddString("AUDIT_DATE", dtpAuditDate.Value.ToString("yyyyMMdd"));
                //in_node.AddChar("STATUS",'1');

                //Audit Item 목록 저장
                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;

                if (with_1.RowCount == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    return false;
                }

                c_result = 'O'; //2023.0.28 주석 처리 Open으로 변경 
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (MPCF.Trim(with_1.GetValue(i, (int)LIST.DIV_CODE)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107)); 
                        with_1.SetActiveCell(i, (int)LIST.DIV_NAME);
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetValue(i, (int)LIST.ITEM)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107)); 
                        with_1.SetActiveCell(i, (int)LIST.ITEM);
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetValue(i, (int)LIST.DETAIL)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107)); 
                        with_1.SetActiveCell(i, (int)LIST.DETAIL);
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetValue(i, (int)LIST.RESULT)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107)); 
                        with_1.SetActiveCell(i, (int)LIST.RESULT);
                        return false;
                    }
                    
                    if (MPCF.Trim(with_1.GetValue(i, (int)LIST.RESULT)) != "P")
                    {
                        if (MPCF.Trim(with_1.GetValue(i, (int)LIST.USER_ID)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            with_1.SetActiveCell(i, (int)LIST.USER_NAME);
                            return false;
                        }

                        if (MPCF.Trim(with_1.GetValue(i, (int)LIST.LIMIT_DATE)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            with_1.SetActiveCell(i, (int)LIST.LIMIT_DATE);
                            return false;
                        }
                    }

                    list_item = in_node.AddNode("AUDIT_RESULT_ITEM");
                    list_item.AddInt("SORT_ORDER", (i + 1));
                    list_item.AddString("ITEM_DIVISION", MPCF.Trim(with_1.GetValue(i, (int)LIST.DIV_CODE)));
                    list_item.AddString("ITEM_NAME", MPCF.Trim(with_1.GetValue(i, (int)LIST.ITEM)));
                    list_item.AddString("CHECK_DETAIL", MPCF.Trim(with_1.GetValue(i, (int)LIST.DETAIL)));
                    list_item.AddChar("CHECK_RESULT", MPCF.Trim(with_1.GetValue(i, (int)LIST.RESULT)));
                    list_item.AddString("FILE_NAME", MPCF.Trim(with_1.GetValue(i, (int)LIST.FILE_NAME)));
                    list_item.AddString("ACTION_MGR_ID", MPCF.Trim(with_1.GetValue(i, (int)LIST.USER_ID)));
                    if (MPCF.Trim(with_1.Cells[i, (int)LIST.LIMIT_DATE].Value) != "")
                    {
                        DateTime _date = Convert.ToDateTime(with_1.Cells[i, (int)LIST.LIMIT_DATE].Value);
                        list_item.AddString("ACTION_LIMIT_DATE", _date.ToString("yyyyMMdd"));
                    }

                    // Audit Item에 한건이라도 F이면 RESULT는 F로 //2023.0.28 주석 처리
                   // if (MPCF.Trim(with_1.GetValue(i, (int)LIST.RESULT)) == "F") c_result = 'F';

                    if (with_1.Cells[i, (int)LIST.FILE_NAME].Tag != null)
                    {
                        file_buffer = null;
                        file_buffer = (byte[])with_1.Cells[i, (int)LIST.FILE_NAME].Tag;
                        list_item.SetBlob(MPCF.Trim(with_1.GetValue(i, (int)LIST.FILE_NAME)), file_buffer);
                    }
                }

                in_node.AddChar("RESULT", c_result);

                //if (c_result == 'P') //Audit Close 처리 //2023.0.28 -- Result:Pass/Fail --> Finding:Critical/Major/Minor 형식으로 변경 된에 따라 STATUS는 무조거 '1' 변경
                //    in_node.AddChar("STATUS", '3');
                //else
                    in_node.AddChar("STATUS", '1');

                if (MPCR.CallService("CAMS", "CAMS_Update_Audit_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (in_node.ProcStep == MPGC.MP_STEP_CREATE)
                    txtAuditID.Text = MPCF.Trim(out_node.GetString("AUDIT_ID"));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmInputAuditResultPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');


                txtAuditID.Text = AUDIT_ID;
                ViewAuditPlan();

                // TODO
                b_load_flag = true;
            }
        }

        private void cdvCustomer_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCustomer.Init();
                MPCF.InitListView(cdvCustomer.GetListView);
                cdvCustomer.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCustomer.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCustomer.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvCustomer.GetListView, '1', MPGC.MP_GCM_AMS_CUSTOMER) == true)
                {
                    cdvCustomer.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvManager_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvManager.Init();
                MPCF.InitListView(cdvManager.GetListView);
                cdvManager.Columns.Add("ID", 150, HorizontalAlignment.Left);
                cdvManager.Columns.Add("Name", 200, HorizontalAlignment.Left);
                cdvManager.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvManager.GetListView, '1', MPGC.MP_GCM_AMS_MANAGER) == true)
                {
                    cdvManager.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            UpdateAuditResult();
        }

        private void spdItemList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)LIST.DIV_BTN:
                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Code", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (BASLIST.ViewGCMDataList(cdvDataList.GetListView, '1', MPGC.MP_GCM_AMS_ITEM_DIV) == true)
                        {
                            cdvDataList.InsertEmptyRow(0, 1);
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case (int)LIST.USER_BTN:
                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("ID", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Name", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        BASLIST.ViewGCMDataList(cdvDataList.GetListView, '1', MPGC.MP_GCM_AMS_USER);
                        //SECLIST.ViewSECUserList(cdvDataList.GetListView);

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case (int)LIST.FILE_BTN:
                        //Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                        System.IO.FileInfo finfo;
                        System.Windows.Forms.OpenFileDialog ofdFile;
                        System.IO.BinaryReader br;
                        byte[] file_buffer;

                        try
                        {
                            ofdFile = new OpenFileDialog();
                            ofdFile.Filter = "All File(*.*)|*.*";
                            ofdFile.FileName = "";

                            if (ofdFile.ShowDialog() == DialogResult.OK)
                            {
                                finfo = new System.IO.FileInfo(ofdFile.FileName);
                                if (finfo.Exists == true)
                                {
                                    br = new System.IO.BinaryReader(finfo.OpenRead());
                                    file_buffer = br.ReadBytes((int)finfo.Length);
                                    spdItemList.ActiveSheet.SetTag(e.Row, (int)LIST.FILE_NAME, file_buffer);
                                    br.Close();

                                    spdItemList.ActiveSheet.SetValue(e.Row, (int)LIST.FILE_NAME, finfo.Name);
                                    spdItemList.ActiveSheet.SetTag(e.Row, (int)LIST.FILE_BTN, "U");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdItemList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)LIST.FILE_NAME:
                        if (spdItemList.ActiveSheet.GetTag(e.Row, (int)LIST.FILE_NAME) != null)
                        {
                            byte[] bt_buffer = (byte[])spdItemList.ActiveSheet.GetTag(e.Row, (int)LIST.FILE_NAME);
                            string s_file_name = spdItemList.ActiveSheet.GetValue(e.Row, (int)LIST.FILE_NAME).ToString();
                            s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_file_name;
                            try
                            {
                                System.IO.FileStream fs = System.IO.File.Open(s_file_name, System.IO.FileMode.Create);
                                System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fs);
                                writer.Write(bt_buffer, 0, bt_buffer.Length);
                                writer.Close();
                            }
                            catch (Exception ex)
                            {
                                MPCF.ShowMsgBox(ex.Message);
                                return;
                            }

                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = s_file_name;
                            proc.Start();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                switch (e.Col)
                {
                    case (int)LIST.DIV_NAME:
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[1].Text);
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[0].Text);
                        break;

                    case (int)LIST.USER_NAME:
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[1].Text);
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[0].Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                int i = spdItemList.ActiveSheet.RowCount;
                spdItemList.ActiveSheet.RowCount++;
                spdItemList.ActiveSheet.SetValue(i, (int)LIST.CHECK, true);
                spdItemList.ActiveSheet.SetTag(i, (int)LIST.CHECK, "I");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdItemList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdItemList.ActiveSheet.GetValue(i, (int)LIST.CHECK)) == true)
                    {
                        spdItemList.ActiveSheet.Rows[i].Remove();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
