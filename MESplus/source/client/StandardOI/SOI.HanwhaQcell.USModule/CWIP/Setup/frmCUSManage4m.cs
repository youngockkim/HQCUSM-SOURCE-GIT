using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSManage4m : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private static string FM_TYPE = "DF";

        public enum FM_LIST
        {
            APPLY_DATE,
            WORK_LINE,
            FM_KIND,
            OPER,
            RESOURCE,
            BEFORE,
            AFTER,
            DEPARTMENT,
            CHARGE_USER,
            UNUSUAL_DESC,
            CREATE_USER,
            CREATE_TIME,
            UPDATE_USER,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmCUSManage4m()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Init
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            dtpApplyTime.Value = DateTime.Now;
            cdvUserID.Text = MPGV.gsUserID;

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        /// <summary>
        /// Oper CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOperation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                //cdvOperation.Text = cdvOperation.Show(cdvOperation, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                // Show CodeView and Get Return
                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdE10TroubleList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }
                
                if (ViewE10TroubleList() == false)
                {
                    return;
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                if (ViewE10TroubleList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewE10TroubleList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                
                if (dtpFrom.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                
                if (dtpTo.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (cdvWorkLine != null && cdvWorkLine.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }
                

                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdE10TroubleList);
                
                // Bind
                spdE10TroubleList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {

                    //APPLY_DATE,
                    //WORK_LINE,
                    //FM_KIND,
                    //OPER,
                    //RESOURCE,
                    //BEFORE,
                    //AFTER,
                    //DEPARTMENT,
                    //CHARGE_USER,
                    //UNUSUAL_DESC,
                    //CREATE_USER,
                    //CREATE_TIME,
                    //UPDATE_USER,
                    //UPDATE_TIME
                    spdE10TroubleList.ActiveSheet.RowHeader.Cells[i, 0].Tag = out_node.GetList(0)[i].GetInt("SEQ_NUM");
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_DATE")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_DATE].Tag = out_node.GetList(0)[i].GetString("WORK_DATE");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_DATE].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("WORK_DATE"));
                    }
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetString("LINE_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.FM_KIND].Value = out_node.GetList(0)[i].GetString("KIND_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.FM_KIND].Tag = out_node.GetList(0)[i].GetString("KIND");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPER].Tag = out_node.GetList(0)[i].GetString("OPER");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.RESOURCE].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.RESOURCE].Tag = out_node.GetList(0)[i].GetString("RES_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.BEFORE].Value = out_node.GetList(0)[i].GetString("BEFORE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.AFTER].Value = out_node.GetList(0)[i].GetString("AFTER");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.DEPARTMENT].Value = out_node.GetList(0)[i].GetString("DEPARTMENT");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CHARGE_USER].Value = out_node.GetList(0)[i].GetString("CHARGE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CHARGE_USER].Tag = out_node.GetList(0)[i].GetString("CHARGE_USER_ID");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UNUSUAL_DESC].Value = out_node.GetList(0)[i].GetString("UNUSUAL_DESC");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Value = out_node.GetList(0)[i].GetString("CREATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Tag = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Tag = out_node.GetList(0)[i].GetString("CREATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                    }

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Tag = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Tag = out_node.GetList(0)[i].GetString("UPDATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                    }
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10TroubleList);

                lblSumQty_W.Text = spdE10TroubleList.ActiveSheet.RowCount.ToString();



                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool View4mData(int row)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                
                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.APPLY_DATE].Tag != null || MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.APPLY_DATE].Tag.ToString()) == "")
                {
                    in_node.AddString("WORK_DATE", spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.APPLY_DATE].Tag.ToString());
                }


                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag != null && MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()) != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()));
                }
                else
                {
                    return false;
                }

                if (spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag != null)
                {
                    in_node.AddInt("SEQ_NUM", spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag);
                }
                else
                {
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSeq.Text = out_node.GetInt("SEQ_NUM").ToString();
                if (MPCF.Trim(out_node.GetString("APPLY_TIME")) == "")
                {
                }
                else
                {
                    dtpApplyTime.Value = MPCF.ToDate(out_node.GetString("APPLY_TIME"));
                }
                cdvWorkLineI.Text = out_node.GetString("LINE_ID");
                cdvKind.Text = out_node.GetString("KIND");
                cdvOper.Text = out_node.GetString("OPER");
                cdvResID.Text = out_node.GetString("RES_ID");
                txtBefore.Text = out_node.GetString("BEFORE");
                txtAfter.Text = out_node.GetString("AFTER");
                txtDepartment.Text = out_node.GetString("DEPARTMENT");

                cdvUserID.Text = out_node.GetString("CHARGE_USER_ID");

                txtUnusualDesc.Text = out_node.GetString("UNUSUAL_DESC");

                    


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        public string ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return "";
                }


                return out_node.GetString("USER_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return "";
            }
        }

        private bool Update_Daily_Work_List(char cProcStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);

                DateTime dtpDateTimeOut = new DateTime();

                if (cProcStep == MPGC.MP_STEP_CREATE)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    }
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineI.Text));
                    in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                    in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                    in_node.AddString("KIND", MPCF.Trim(cdvKind.Text));
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("DEPARTMENT", MPCF.Trim(txtDepartment.Text));
                    in_node.AddString("CHARGE_USER_ID", MPCF.Trim(cdvUserID.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                }
                else if ((cProcStep == MPGC.MP_STEP_UPDATE) || (cProcStep == MPGC.MP_STEP_DELETE))
                {
                    bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    }
                    in_node.AddInt("SEQ_NUM", MPCF.ToInt(MPCF.Trim(txtSeq.Text)));
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineI.Text));
                    in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                    in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                    in_node.AddString("KIND", MPCF.Trim(cdvKind.Text));
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("DEPARTMENT", MPCF.Trim(txtDepartment.Text));
                    in_node.AddString("CHARGE_USER_ID", MPCF.Trim(cdvUserID.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                }

                

                if (MPCF.CallService("CWIP", "CWIP_Update_4m", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        private void cdvWorkLineE_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(txtSeq, false) == false)
                {
                    return;
                }


                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdE10TroubleList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvWorkLineI_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLineI.Text = cdvWorkLineI.Show(cdvWorkLineI, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineI.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvKind_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_KIND));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvKind.Text = cdvKind.Show(cdvKind, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvKind.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineI.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOper.Text == null || cdvOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResID_CodeViewButtonClick_1(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvWorkLineI.Text);
                in_node.AddString("OPER", cdvOper.Text);

                // Display and Header Text Setup
                string[] header = new string[] { "Equip ID", "Equip Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show CodeView and Get Return
                cdvResID.Text = cdvResID.Show(cdvResID, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    MPCF.SetFocus(cdvResID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvUserID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_USER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Display and Header Text Setup
                string[] header = new string[] { "User ID", "User Desc" };
                string[] display = new string[] { "USER_ID", "USER_DESC" };

                // Show CodeView and Get Return
                cdvUserID.Text = cdvUserID.Show(cdvUserID, "View User List", "SEC", "SEC_View_User_List", in_node, "LIST", display, header, "USER_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvUserID.Text) == true)
                {
                    MPCF.SetFocus(cdvUserID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdE10TroubleList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0 || e.ColumnHeader == true)
            {
                return;
            }

            if (View4mData(e.Row) == false)
            {
                return;
            }
        }

        private void cdvWorkLineI_ValueChanged(object sender, EventArgs e)
        {
            cdvOper.Text = "";
            cdvResID.Text = "";
        }

        private void cdvOper_ValueChanged(object sender, EventArgs e)
        {
            cdvResID.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(txtSeq, false) == false)
                {
                    return;
                }


                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                    txtSeq.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        
    }
}
