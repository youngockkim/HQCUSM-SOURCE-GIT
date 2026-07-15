//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSCalibrationResultPopup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//       - TranMms() : Process Mms for transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-04-03 13:07:57 : XXXX Created by generator in DEV Tools
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
    public partial class frmMMSCalibrationResultPopup : TranForm02
    {
        public frmMMSCalibrationResultPopup()
        {
            InitializeComponent();

        }

        #region " Constant Definition "
        private enum EQUIP_LIST : int
        {
            CHECK = 0,
            EQUIP_ID,
            BUTTON,
            EQUIP_NAME
        }

        private enum FILE_LIST : int
        {
            CHECK = 0,
            FILE_NAME,
            FILE_PATH,
            FILE_ORDER
        }

        private string m_cali_id;    
        private string m_equip_id;                               
        private string m_equip_name;                               
        private string m_equip_no;                              
        private string m_plan_date;
        private int m_cali_cycle;

        public string CALI_ID
        {
            get
            {
                if (m_cali_id == null)
                {
                    m_cali_id = "";
                }
                return m_cali_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_cali_id = "";
                }
                m_cali_id = value;
            }
        }

        public string EQUIP_ID
        {
            get
            {
                if (m_equip_id == null)
                {
                    m_equip_id = "";
                }
                return m_equip_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_equip_id = "";
                }
                m_equip_id = value;
            }
        }

        public string EQUIP_NAME
        {
            get
            {
                if (m_equip_name == null)
                {
                    m_equip_name = "";
                }
                return m_equip_name;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_equip_name = "";
                }
                m_equip_name = value;
            }
        }


        public string EQUIP_NO
        {
            get
            {
                if (m_equip_no == null)
                {
                    m_equip_no = "";
                }
                return m_equip_no;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_equip_no = "";
                }
                m_equip_no = value;
            }
        }


        public string PLAN_DATE
        {
            get
            {
                if (m_plan_date == null)
                {
                    m_plan_date = "";
                }
                return m_plan_date;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_plan_date = "";
                }
                m_plan_date = value;
            }
        }

        public int CALI_CYCLE
        {
            get
            {
                return m_cali_cycle;
            }
            set
            {
                m_cali_cycle = value;
            }
        }

        #endregion


        #region " Variable Definition "



        private bool b_load_flag;

        #endregion

        #region " Function Definition "

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
            return this.txtCalibrationEquipCode;
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
                    spdCaliFileList.ActiveSheet.RowCount = 0;
                    spdStandardEquipList.ActiveSheet.RowCount = 0;

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
            if (MPCF.CheckValue(txtCalibrationEquipCode, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "TRAN1":
                    if (dtpCaliDate.Value > DateTime.Now)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(635));
                        return false;
                    }

                    // TODO
                    break;
                case "TRAN2":
                    // TODO
                    break;
            }

            return true;            
        }

        private bool UpdateCalibrationResultRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_OUT");
            TRSNode list_item;
            byte[] file_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                if (MPCF.Trim(CALI_ID) == "")
                {
                    in_node.ProcStep = MPGC.MP_STEP_CREATE;
                    CALI_ID = MPCF.Trim(txtCalibrationEquipCode.Text) + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
                else
                {
                    in_node.ProcStep = MPGC.MP_STEP_UPDATE; 
                }
                in_node.AddChar("TRAN_STEP", '2');
                in_node.AddString("CALI_ID", CALI_ID);
                in_node.AddString("EQUIP_ID", MPCF.Trim(txtCalibrationEquipCode.Text));
                in_node.AddString("CALI_DATE", dtpCaliDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("CALI_INSTITUTE", MPCF.Trim(cdvCaliInstitute.Text));
                in_node.AddString("CALI_USER_ID", MPCF.Trim(cdvCaliUser.Text));
                in_node.AddDouble("CALI_COST", nudCaliAmount.Value);
                in_node.AddString("CALI_METHOD", MPCF.Trim(txtCaliMethod.Text));
                in_node.AddString("CALI_DESC", MPCF.Trim(txtCaliRemarks.Text));
                in_node.AddString("PLAN_DATE", Convert.ToDateTime(txtPlanDate.Text).ToString("yyyyMMdd"));
                in_node.AddString("NEXT_PLAN_DATE", dtpCaliDate.Value.AddMonths(CALI_CYCLE).ToString("yyyyMMdd"));

                if (MPCF.Trim(cboCaliResult.Text) != "")
                {
                    in_node.AddChar("CALI_RESULT", MPCF.ToUpper(MPCF.Trim(cboCaliResult.Text).Substring(0,1)));
                }
                in_node.AddString("FILE_NAME", MPCF.Trim(cdvCaliDocument.Text));

                if (cdvCaliDocument.Tag != null && cdvCaliDocument.GetTextBox.Tag != null)
                {
                    file_buffer = (byte[])cdvCaliDocument.Tag;
                    in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                }

                //기준 측정기 목록 저장
                FarPoint.Win.Spread.SheetView with_1 = spdStandardEquipList.ActiveSheet;
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)EQUIP_LIST.CHECK].Value) == true)
                    {
                        if (MPCF.Trim(with_1.GetValue(i, (int)EQUIP_LIST.EQUIP_ID)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            with_1.SetActiveCell(i, (int)EQUIP_LIST.EQUIP_ID);
                            return false;
                        }

                        list_item = in_node.AddNode("CALIBRATION_EQUIP_LIST");
                        list_item.AddString("STANDARD_EQUIP_ID", MPCF.Trim(with_1.GetValue(i, (int)EQUIP_LIST.EQUIP_ID)));
                        list_item.AddChar("IUD_FLAG", MPCF.Trim(with_1.GetTag(i, (int)EQUIP_LIST.CHECK)));
                    }
                }

                //교정 결과서 파일 저장 처리 
                FarPoint.Win.Spread.SheetView with_2 = spdCaliFileList.ActiveSheet;
                for (int i = 0; i < with_2.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_2.Cells[i, (int)FILE_LIST.CHECK].Value) == true)
                    {
                        if (MPCF.Trim(with_2.GetValue(i, (int)FILE_LIST.FILE_NAME)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            with_1.SetActiveCell(i, (int)FILE_LIST.FILE_NAME);
                            return false;
                        }

                        list_item = in_node.AddNode("CALIBRATION_FILE_LIST");
                        list_item.AddString("FILE_NAME", MPCF.Trim(with_2.GetValue(i, (int)FILE_LIST.FILE_NAME)));
                        list_item.AddChar("IUD_FLAG", MPCF.Trim(with_2.GetTag(i, (int)FILE_LIST.CHECK)));
                        if (MPCF.Trim(with_2.GetValue(i, (int)FILE_LIST.FILE_ORDER)) != "")
                        {
                            list_item.AddInt("FILE_ORDER", MPCF.ToInt(with_2.GetValue(i, (int)FILE_LIST.FILE_ORDER)));
                        }

                        if (with_2.Cells[i, (int)FILE_LIST.FILE_NAME].Tag != null && with_2.Cells[i, (int)FILE_LIST.FILE_PATH].Tag != null)
                        {
                            file_buffer = null;
                            file_buffer = (byte[])with_2.Cells[i, (int)FILE_LIST.FILE_NAME].Tag;
                            //list_item.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer); //Server에서 받지 못함. in_node에 넣어야 Server에서 받음.                            
                            in_node.AddBlob(MPCF.Trim(with_2.GetValue(i, (int)FILE_LIST.FILE_NAME)), file_buffer);
                        }
                    }
                }


                if (MPCR.CallService("CMMS", "CMMS_Update_Calibration_Result_Registration", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCR.ShowSuccessMsg(out_node);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        //
        // ViewCalibrationData()
        //       - View Calibration Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationData()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_DATA_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            byte[] bt_buffer;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("CALI_ID", CALI_ID);

                TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_DATA_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Result_Registration", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvCaliInstitute.Text = MPCF.Trim(out_node.GetString("CALI_INSTITUTE"));
                cdvCaliInstitute.DescText = MPCF.Trim(out_node.GetString("CALI_INSTITUTE_NAME"));
                cdvCaliUser.Text = MPCF.Trim(out_node.GetString("CALI_USER_ID"));
                cdvCaliUser.DescText = MPCF.Trim(out_node.GetString("CALI_USER_NAME"));
                nudCaliAmount.Value =  MPCF.ToDecimal(out_node.GetDouble("CALI_COST"));
                txtCaliMethod.Text = MPCF.Trim(out_node.GetString("CALI_METHOD"));
                txtCaliRemarks.Text = MPCF.Trim(out_node.GetString("CALI_DESC"));
                dtpCaliDate.Value = MPCF.ToDate(out_node.GetString("CALI_DATE"));
                cboCaliResult.Text = out_node.GetChar("CALI_RESULT").ToString();
                cdvCaliDocument.Text = MPCF.Trim(out_node.GetString("FILE_NAME"));

                //교정 결과가 등록 되어 있으면 저장 불가.
                if (out_node.GetChar("CALI_RESULT").ToString() != "")
                { 
                    btnProcess.Enabled = false;
                }

                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                     MemoryStream ms_buffer;

                    try
                    {
                        ms_buffer = new MemoryStream();
                        ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                        ms_buffer.Position = 0;
                        cdvCaliDocument.Tag = bt_buffer;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                } 


                //out_list.Add(out_node);
                FarPoint.Win.Spread.SheetView with_1 = spdStandardEquipList.ActiveSheet;
                FarPoint.Win.Spread.SheetView with_2 = spdCaliFileList.ActiveSheet;
                int i = 0;

                i = 0;
                List<TRSNode> calibration_equip_list = out_node.GetList("CALIBRATION_EQUIP_LIST");
                foreach (TRSNode node in calibration_equip_list)
                {
                    with_1.RowCount = i + 1;
                    with_1.SetValue(i, MPCF.ToInt(EQUIP_LIST.CHECK), false);
                    with_1.SetValue(i, MPCF.ToInt(EQUIP_LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                    with_1.SetValue(i, MPCF.ToInt(EQUIP_LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));
                    i++;
                }

                i = 0;
                List<TRSNode> calibration_file_list = out_node.GetList("CALIBRATION_FILE_LIST");
                foreach (TRSNode node in calibration_file_list)
                {
                    with_2.RowCount = i + 1;
                    with_2.SetValue(i, MPCF.ToInt(FILE_LIST.CHECK), false);
                    with_2.SetValue(i, MPCF.ToInt(FILE_LIST.FILE_NAME), node.GetString("FILE_NAME"));
                    with_2.SetValue(i, MPCF.ToInt(FILE_LIST.FILE_PATH), node.GetString("FILE_PATH"));
                    with_2.SetValue(i, MPCF.ToInt(FILE_LIST.FILE_ORDER), node.GetInt("FILE_ORDER").ToString());

                    if ((bt_buffer = out_node.GetBlob(node.GetString("FILE_NAME"))) != null)
                    {
                        MemoryStream ms_buffer;
                        try
                        {
                            ms_buffer = new MemoryStream();
                            ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                            ms_buffer.Position = 0;
                            with_2.SetTag(i, MPCF.ToInt(FILE_LIST.FILE_NAME), bt_buffer);

                            //cdvCaliDocument.Tag = bt_buffer;
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                    } 

                    i++;
                }

                //foreach (TRSNode eqp_node in out_list)
                //{   
                    
                //}

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewCalibrationHistory()
        //       - View Calibration_Result_Registration List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationHistory(string sEquipCode)
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
              //  MPCF.ClearList(spcMain);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';

                in_node.AddString("EQUIP_ID", sEquipCode);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Result_Registration_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                //FarPoint.Win.Spread.SheetView with_1 = spdCalibrationHistory.ActiveSheet;
                //int i = 0;

                //foreach (TRSNode out_node in out_list)
                //{
                //    List<TRSNode> calibration_result = out_node.GetList("ITEM_LIST");
                //    foreach (TRSNode node in calibration_result)
                //    {
                //        with_1.RowCount = i + 1;
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE")));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_DATE), MPCF.MakeDateFormat(node.GetString("CALI_DATE")));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_INSTI), node.GetString("CALI_INSTI"));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_USER), node.GetString("CALI_USER"));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_METHOD), node.GetString("CALI_METHOD"));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_RESULT), node.GetString("CALI_RESULT"));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_COST), node.GetInt("CALI_COST"));
                //        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_DESC), node.GetString("CALI_DESC"));
                //        i++;
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmMMSCalibrationResultPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                txtCalibrationEquipCode.Text = EQUIP_ID;
                txtCalibrationEquipName.Text = EQUIP_NAME;
                txtEquioNo.Text = EQUIP_NO;
                txtPlanDate.Text = PLAN_DATE;

                if (CALI_ID != "")
                    ViewCalibrationData();

                b_load_flag = true;
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                // TODO
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("TRAN1") == false) return;

                if (UpdateCalibrationResultRegistration() == false) return;

                if (cboCaliResult.Text != "")
                {
                    btnProcess.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

   
        private void cdvCaliInstitute_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCaliInstitute.Init();
                MPCF.InitListView(cdvCaliInstitute.GetListView);
                cdvCaliInstitute.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCaliInstitute.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCaliInstitute.SelectedSubItemIndex = 0;
                if (HQCF.ViewCalibrationInstituteList(cdvCaliInstitute.GetListView, '3', ' ', 'Y') == true)
                {
                    cdvCaliInstitute.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCaliUser_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCaliUser.Init();
                MPCF.InitListView(cdvCaliUser.GetListView);
                cdvCaliUser.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCaliUser.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCaliUser.SelectedSubItemIndex = 0;
                if (HQCF.ViewCalibrationUserList(cdvCaliUser.GetListView, '3', 'Y') == true)
                {
                    cdvCaliUser.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkStandardEquipAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdStandardEquipList.ActiveSheet.RowCount; i++)
                {
                    spdStandardEquipList.ActiveSheet.SetValue(i, (int)EQUIP_LIST.CHECK, chkStandardEquipAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkCaliFileAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdCaliFileList.ActiveSheet.RowCount; i++)
                {
                    spdCaliFileList.ActiveSheet.SetValue(i, (int)FILE_LIST.CHECK, chkCaliFileAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnStandardEquipDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdStandardEquipList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdStandardEquipList.ActiveSheet.GetValue(i, (int)EQUIP_LIST.CHECK)) == true)
                    {
                        if (spdStandardEquipList.ActiveSheet.GetTag(i, (int)FILE_LIST.CHECK).ToString() == "I")
                        {
                            spdStandardEquipList.ActiveSheet.Rows[i].Remove();
                        }
                        else
                        {
                            spdStandardEquipList.ActiveSheet.SetValue(i, (int)FILE_LIST.CHECK, chkCaliFileAll.Checked);
                            spdStandardEquipList.ActiveSheet.SetTag(i, (int)FILE_LIST.CHECK, "D");
                            spdStandardEquipList.ActiveSheet.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCaliFileDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdCaliFileList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdCaliFileList.ActiveSheet.GetValue(i, (int)FILE_LIST.CHECK)) == true)
                    {
                        if (spdCaliFileList.ActiveSheet.GetTag(i, (int)FILE_LIST.CHECK).ToString() == "I")
                        {
                            spdCaliFileList.ActiveSheet.Rows[i].Remove();
                        }
                        else
                        {
                            spdCaliFileList.ActiveSheet.SetValue(i, (int)FILE_LIST.CHECK, chkCaliFileAll.Checked);
                            spdCaliFileList.ActiveSheet.SetTag(i, (int)FILE_LIST.CHECK, "D");
                            spdCaliFileList.ActiveSheet.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCaliNewFile_Click(object sender, EventArgs e)
        {
            //Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            System.IO.FileInfo finfo;
            System.IO.BinaryReader br;
            System.Windows.Forms.OpenFileDialog ofdFile;
            int iRow;
            byte[] file_buffer;

            try
            {

                if (spdCaliFileList.ActiveSheet.RowCount > 9)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(620)); //You can register up to 10 files.
                }

                ofdFile = new OpenFileDialog();
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new System.IO.FileInfo(ofdFile.FileName);

                    //System.Text.RegularExpressions.Regex objAlphaPattern = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_.-]*$");
                    //if (objAlphaPattern.IsMatch(finfo.Name) == false)
                    //{
                    //    MPCF.ShowMsgBox("Check File Name!");
                    //    return;
                    //}

                    if (finfo.Exists == true)
                    {
                        for (int i = 0; i < spdCaliFileList.ActiveSheet.RowCount; i++)
                        {
                            if (spdCaliFileList.ActiveSheet.GetValue(i, (int)FILE_LIST.FILE_NAME).Equals(finfo.Name))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(301));
                                spdCaliFileList.ActiveSheet.SetActiveCell(i, (int)FILE_LIST.FILE_NAME);
                                return;
                            }
                        }

                        iRow = spdCaliFileList.ActiveSheet.RowCount;
                        spdCaliFileList.ActiveSheet.RowCount = iRow + 1;

                        br = new System.IO.BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        spdCaliFileList.ActiveSheet.SetTag(iRow, (int)FILE_LIST.FILE_NAME, file_buffer);
                        br.Close();

                        spdCaliFileList.ActiveSheet.SetValue(iRow, (int)FILE_LIST.CHECK, true);
                        spdCaliFileList.ActiveSheet.SetValue(iRow, (int)FILE_LIST.FILE_NAME, finfo.Name);
                        spdCaliFileList.ActiveSheet.SetTag(iRow, (int)FILE_LIST.FILE_PATH, "U");
                        spdCaliFileList.ActiveSheet.SetTag(iRow, (int)FILE_LIST.CHECK, "I");
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCaliPlanDoc_ButtonPress(object sender, EventArgs e)
        {
            //Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            System.IO.FileInfo finfo;
            System.IO.BinaryReader br;
            System.Windows.Forms.OpenFileDialog ofdFile;

            byte[] file_buffer;

            try
            {
                ofdFile = new OpenFileDialog();
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new System.IO.FileInfo(ofdFile.FileName);

                    //System.Text.RegularExpressions.Regex objAlphaPattern = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_.-]*$");
                    //if (objAlphaPattern.IsMatch(finfo.Name) == false)
                    //{
                    //    MPCF.ShowMsgBox("Check File Name!");
                    //    return;
                    //}

                    if (MPCF.ByteLen(finfo.Name) > cdvCaliDocument.MaxLength)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(621)); //File name is too long.
                    }

                    if (finfo.Exists == true)
                    {

                        br = new System.IO.BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        cdvCaliDocument.Tag = file_buffer;
                        br.Close();

                        cdvCaliDocument.GetTextBox.Tag = "U";
                        cdvCaliDocument.Text = finfo.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnStandardEquipAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i = spdStandardEquipList.ActiveSheet.RowCount;
                spdStandardEquipList.ActiveSheet.RowCount++;
                spdStandardEquipList.ActiveSheet.SetValue(i, (int)EQUIP_LIST.CHECK, true);
                spdStandardEquipList.ActiveSheet.SetTag(i, (int)EQUIP_LIST.CHECK, "I");
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void spdStandardEquipList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)EQUIP_LIST.BUTTON:
                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Equip Code", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (HQCF.ViewStandardEquipmentList(cdvDataList.GetListView, '4', 'Y', "") == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
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
            switch (e.Col)
            {
                case (int)EQUIP_LIST.EQUIP_ID:
                    for (int i = 0; i < spdStandardEquipList.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdStandardEquipList.ActiveSheet.GetValue(i, e.Col)).Equals(e.SelectedItem.SubItems[0].Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(622)); //The same base measuring instrument exists.
                            return;
                        }
                    }
                    spdStandardEquipList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[0].Text);
                    spdStandardEquipList.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[1].Text);
                    break;
            }
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            HQCF.OpenAttachedFile(cdvCaliDocument);
        }

        private void spdCaliFileList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            byte[] bt_buffer;
            try
            {
                switch (e.Column)
                {
                    case (int)FILE_LIST.FILE_NAME:

                        if (spdCaliFileList.ActiveSheet.Cells[e.Row, e.Column].Tag == null)
                        {
                            return;
                        }

                        bt_buffer = (byte[])spdCaliFileList.ActiveSheet.Cells[e.Row, e.Column].Tag;

                        string s_file_name = spdCaliFileList.ActiveSheet.GetValue(e.Row, e.Column).ToString();
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
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}
