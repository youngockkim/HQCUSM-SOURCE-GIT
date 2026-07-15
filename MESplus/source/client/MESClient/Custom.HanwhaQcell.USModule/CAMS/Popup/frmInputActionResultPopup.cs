//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmInputActionResultPopup.cs
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
    public partial class frmInputActionResultPopup : TranForm01
    {
        public frmInputActionResultPopup()
        {
            InitializeComponent();

            btnUpdate.Visible = false;
            btnProcess.Location = new Point(640, 7);
            btnClose.Location = new Point(731, 7);

            spdItemList.ActiveSheet.RowCount = 0;

            GetSpreadComboboxList();
        }


        #region " Constant Definition "

        private enum LIST
        {
            CHECK,
            SORT_ORDER,
            DIV_NAME,
            DIV_CODE,
            ITEM,
            DETAIL,
            RESULT,
            FILE_NAME,
            LIMIT_DATE,
            ACTION_DATE,
            ACTION_IMAGE,
            ACTION_IMAGE_BTN,
            ACTION_USER_NAME,
            ACTION_USER_BTN,
            ACTION_USER_ID,
            ACTION_RESULT
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
                alResultCode.Add("O");
                alResultName.Add("Open");
                alResultCode.Add("C");
                alResultName.Add("Close");

                FarPoint.Win.Spread.CellType.ComboBoxCellType cb1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();//CellType 정의
                cb1.ItemData = (string[])alResultCode.ToArray(typeof(string));//ItemData 값 지정.
                cb1.Items = (string[])alResultName.ToArray(typeof(string)); //Items 값 지정..
                cb1.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData; //이 부분이 빠지면 안됨..
                with_1.Columns[MPCF.ToInt(LIST.ACTION_RESULT)].CellType = cb1; //CellType 지정. .

                FarPoint.Win.Spread.CellType.DateTimeCellType _cell_type = (FarPoint.Win.Spread.CellType.DateTimeCellType)with_1.Columns[MPCF.ToInt(LIST.ACTION_DATE)].CellType;
                _cell_type.DateDefault = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                with_1.Columns[MPCF.ToInt(LIST.ACTION_DATE)].CellType = _cell_type;

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
        private bool ViewAuditResult()
        {
            TRSNode in_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_IN");
            TRSNode out_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("AUDIT_ID", txtAuditID.Text);

                if (MPCR.CallService("CAMS", "CAMS_View_Audit_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("STATUS") == '3') //조치 완료 시
                {

                    btnProcess.Enabled = false;
                    btnUpdate.Visible = true;
                    dtpActionDate.Enabled = false;
                }

                txtAuditDesc.Text = out_node.GetString("AUDIT_DESC");
                txtPlanDate.Text = MPCF.DateToString(MPCF.ToDate(out_node.GetString("PLAN_DATE")));

                cdvCustomer.Text = out_node.GetString("CUSTOMER_CODE");
                cdvCustomer.DescText = out_node.GetString("CUSTOMER_NAME");

                txtAuditor.Text = out_node.GetString("AUDITOR");

                cdvManager.Text = out_node.GetString("MANAGER_ID");
                cdvManager.DescText = out_node.GetString("MANAGER_NAME");
                txtAgenda.Text = out_node.GetString("AGENDA");

                txtAuditDate.Text = MPCF.MakeDateFormat(out_node.GetString("AUDIT_DATE"), DATE_TIME_FORMAT.DATE);

                dtpActionDate.Value = MPCF.ToDate(out_node.GetString("ACTION_DATE"));
                txtActionRemark.Text = out_node.GetString("ACTION_REMARK");

                cdvFileName.Text = out_node.GetString("CMF_1");

                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    HQCF.SetAttachedFile(cdvFileName, bt_buffer, "");
                }
                else
                {
                    cdvFileName.GetTextBox.Tag = "";
                }

                FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;
                int i = 0;

                i = 0;
                List<TRSNode> audit_item_list = out_node.GetList("AUDIT_ITEM_LIST");
                foreach (TRSNode node in audit_item_list)
                {
                    string s_checkresult = "";
                    if(node.GetChar("CHECK_RESULT") == 'C')
                        s_checkresult = "Critical";
                    else if(node.GetChar("CHECK_RESULT") == 'M')
                        s_checkresult = "Major";
                    else if (node.GetChar("CHECK_RESULT") == 'N')
                        s_checkresult = "Minor";

                    with_1.RowCount = i + 1;
                    with_1.SetValue(i, MPCF.ToInt(LIST.CHECK), false);
                    with_1.SetValue(i, MPCF.ToInt(LIST.SORT_ORDER), node.GetInt("SORT_ORDER"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.DIV_NAME), node.GetString("ITEM_DIV_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.DIV_CODE), node.GetString("ITEM_DIVISION"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.ITEM), node.GetString("ITEM_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.DETAIL), node.GetString("CHECK_DETAIL"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.RESULT), s_checkresult);
                    with_1.SetValue(i, MPCF.ToInt(LIST.FILE_NAME), node.GetString("FILE_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_USER_ID), node.GetString("ACTION_USER_ID"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_USER_NAME), node.GetString("ACTION_USER_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_USER_ID), node.GetString("ACTION_USER_ID"));
                    if (MPCF.Trim(node.GetString("ACTION_LIMIT_DATE")) != "")
                        with_1.SetValue(i, MPCF.ToInt(LIST.LIMIT_DATE), MPCF.MakeDateFormat(node.GetString("ACTION_LIMIT_DATE"), DATE_TIME_FORMAT.DATE));
                  
                    with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_IMAGE), node.GetString("ACTION_FILE_NAME"));

                    if (MPCF.Trim(node.GetString("ACTION_DATE")) != "")
                        with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_DATE), MPCF.MakeDateFormat(node.GetString("ACTION_DATE"), DATE_TIME_FORMAT.DATE));

                    with_1.SetValue(i, MPCF.ToInt(LIST.ACTION_RESULT), node.GetChar("ACTION_RESULT"));


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

                    if ((bt_buffer = out_node.GetBlob(node.GetString("ACTION_FILE_NAME"))) != null)
                    {
                        MemoryStream ms_buffer;
                        try
                        {
                            ms_buffer = new MemoryStream();
                            ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                            ms_buffer.Position = 0;
                            with_1.SetTag(i, MPCF.ToInt(LIST.ACTION_IMAGE), bt_buffer);
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
        private bool UpdateActionResult(char c_step_flag)
        {
            TRSNode in_node = new TRSNode("CAMS_UPDATE_AUDIT_RESULT_IN");
            TRSNode out_node = new TRSNode("CAMS_UPDATE_AUDIT_RESULT_OUT");
            TRSNode list_item;
            byte[] file_buffer;
            
            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddChar("STEP_FLAG", c_step_flag); //'3');
                in_node.AddString("AUDIT_ID", txtAuditID.Text);        
                in_node.AddString("ACTION_DATE", dtpActionDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("ACTION_REMARK",MPCF.Trim(txtActionRemark.Text));
                in_node.AddChar("STATUS",'2');
                in_node.AddString("CMF_1", cdvFileName.Text);
                if (MPCF.Trim(cdvFileName.GetTextBox.Tag).Equals("U"))
                {
                    if (cdvFileName.Tag != null)
                    {
                        file_buffer = (byte[])cdvFileName.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                    }
                }

                if (c_step_flag == '3')
                {
                    //Audit Item 목록 저장
                    FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;

                    if (with_1.RowCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        return false;
                    }


                    for (int i = 0; i < with_1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(with_1.GetValue(i, (int)LIST.CHECK)) == true)
                        {
                            if (MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_DATE)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                with_1.SetActiveCell(i, (int)LIST.ACTION_DATE);
                                return false;
                            }
                            if (MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_RESULT)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                with_1.SetActiveCell(i, (int)LIST.ACTION_RESULT);
                                return false;
                            }
                            if (MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_USER_ID)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                with_1.SetActiveCell(i, (int)LIST.ACTION_USER_ID);
                                return false;
                            }

                            list_item = in_node.AddNode("ACTION_RESULT_ITEM");
                            list_item.AddInt("SORT_ORDER", with_1.GetValue(i, (int)LIST.SORT_ORDER));
                            list_item.AddString("ACTION_USER_ID", MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_USER_ID)));
                            list_item.AddString("ACTION_FILE_NAME", MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_IMAGE)));
                            list_item.AddChar("ACTION_RESULT", with_1.GetValue(i, (int)LIST.ACTION_RESULT));
                            DateTime _date = Convert.ToDateTime(with_1.Cells[i, (int)LIST.ACTION_DATE].Value);
                            list_item.AddString("ACTION_DATE", _date.ToString("yyyyMMdd"));

                            if (with_1.Cells[i, (int)LIST.ACTION_IMAGE].Tag != null)
                            {
                                file_buffer = null;
                                file_buffer = (byte[])with_1.Cells[i, (int)LIST.ACTION_IMAGE].Tag;
                                list_item.SetBlob(MPCF.Trim(with_1.GetValue(i, (int)LIST.ACTION_IMAGE)), file_buffer);
                            }
                        }
                    }
                }

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

        private void frmInputActionResultPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');


                txtAuditID.Text = AUDIT_ID;
                ViewAuditResult();

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
                cdvManager.Columns.Add("User ID", 150, HorizontalAlignment.Left);
                cdvManager.Columns.Add("User Name", 200, HorizontalAlignment.Left);
                cdvManager.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvManager.GetListView, '1', MPGC.MP_GCM_AMS_MANAGER) == true)
                {
                    cdvManager.InsertEmptyRow(0, 1);
                }

                //cdvManager.Init();
                //MPCF.InitListView(cdvManager.GetListView);
                //cdvManager.Columns.Add("ID", 150, HorizontalAlignment.Left);
                //cdvManager.Columns.Add("Name", 200, HorizontalAlignment.Left);
                //cdvManager.SelectedSubItemIndex = 0;
                //if (SECLIST.ViewSECUserList(cdvManager.GetListView) == false)
                //{
                //    cdvManager.InsertEmptyRow(0, 1);
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            UpdateActionResult('3');
        }

        private void spdItemList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)LIST.ACTION_USER_BTN:

                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("ID", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Name", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        BASLIST.ViewGCMDataList(cdvDataList.GetListView, '1', MPGC.MP_GCM_AMS_USER);

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case (int)LIST.ACTION_IMAGE_BTN:
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
                                    spdItemList.ActiveSheet.SetTag(e.Row, (int)LIST.ACTION_IMAGE, file_buffer);
                                    br.Close();

                                    spdItemList.ActiveSheet.SetValue(e.Row, (int)LIST.ACTION_IMAGE, finfo.Name);
                                    spdItemList.ActiveSheet.SetTag(e.Row, (int)LIST.ACTION_IMAGE_BTN, "U");
                                }

                                spdItemList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(LIST.CHECK), true);
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
                    case (int)LIST.ACTION_IMAGE:
                        if (spdItemList.ActiveSheet.GetTag(e.Row, (int)LIST.ACTION_IMAGE) != null)
                        {
                            byte[] bt_buffer = (byte[])spdItemList.ActiveSheet.GetTag(e.Row, (int)LIST.ACTION_IMAGE);
                            string s_file_name = spdItemList.ActiveSheet.GetValue(e.Row, (int)LIST.ACTION_IMAGE).ToString();
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

                    case (int)LIST.ACTION_USER_NAME:
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[1].Text);
                        spdItemList.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[0].Text);
                        spdItemList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(LIST.CHECK), true);
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

        private void spdItemList_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdItemList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(LIST.CHECK), true);
        }

        private void cdvFileName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            HQCF.OpenAttachedFile(cdvFileName);
        }

        private void cdvFileName_ButtonPress(object sender, EventArgs e)
        {
            System.IO.FileInfo finfo;
            System.Windows.Forms.OpenFileDialog ofdFile;

            try
            {
                ofdFile = new OpenFileDialog();
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new System.IO.FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                        HQCF.SetAttachedFile(cdvFileName, finfo, "U");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateActionResult('4');
        }
    }
}
