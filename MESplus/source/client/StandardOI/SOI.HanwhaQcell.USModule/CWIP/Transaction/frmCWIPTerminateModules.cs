using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPTerminateModules : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPTerminateModules()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            LOT_ID = 0,
            ORDER_ID,
            MAT_ID,
            MAT_VER,
            LINE_ID,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            QTY_1,
            CREATE_TIME,
            LAST_TRAN_TIME,
            FQC_FLAG,
            INS_TIME,
            LIMIT_DATE,
            TODATE,
            SAME_FLAG
        }

        public enum TERMINATED_LIST
        {
            LOT_ID = 0,
            ORDER_ID,
            MAT_ID,
            MAT_VER,
            LINE_ID,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
			SHIFT,
            CELL_LOSS,          //IS-21-09-068 [MES OI Update Request] Cell Loss 필드 추가 요청
            NUM_OF_STRINGS,     //[2024-01-17] 필드 추가
            TERMINATE_PROCESS,  //IS-21-04-017 Terminate Module
            TERMINATE_EQ,       //IS-21-04-017 Terminate Module
            QTY_1,
            LAST_ACTIVE_HIST_SEQ,
            CREATE_TIME,
            ACTUAL_TERMINATION_DATE,
            LOT_DEL_TIME,
            LOT_DEL_CODE,
            LOT_DEL_DESC,
            LOT_DEL_CAUSE,
            COMMENT,
            FQC_FLAG,
            INS_TIME,
            LIMIT_DATE,
            TODATE,
            SAME_FLAG,
            TERMINATE_TIME
        }

        #endregion

        #region [Variable Definition]

        private string gSelectedLotID = string.Empty;
        private string gSelectedMatID = string.Empty;
        private string gSelectedFlow = string.Empty;
        private string gSelectedOper = string.Empty;
        private DateTime gSelectedLastTranTime;
        private int gSelectedMatVer = 1;
        private int gSelectedFlowSeqNum = 1;
        private string gSelectedFqcFlag = string.Empty;
        private string gSelectedInsTime = string.Empty;
        private string gSelectedLimitDate = string.Empty;
        private string gSelectedTodate = string.Empty;
        private string gSelectedSameFlag = string.Empty;

        private string gTerminatedLotID = string.Empty;
        private string gTerminatedMatID = string.Empty;
        private string gTerminatedFlow = string.Empty;
        private string gTerminatedOper = string.Empty;
        private int gTerminatedMatVer = 1;
        private int gTerminatedFlowSeqNum = 1;
        private int gTerminatedLastActiveHisSeq = 0;
        private string gTerminatedFqcFlag = string.Empty;
        private string gTerminatedInsTime = string.Empty;
        private string gTerminatedLimitDate = string.Empty;
        private string gTerminatedTodate = string.Empty;
        private string gTerminatedSameFlag = string.Empty;
        private string gTerminatedTime = string.Empty;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPTerminateModules_Load(object sender, EventArgs e)
        {
            // Init
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today;
            dtpActualTerminationDate.Value = DateTime.Today;
            //dtpFrom.Value = DateTime.Today.AddDays(-7);

            MPCF.ConvertCaption(this);

            // IS-21-04-017 Terminate Module
			// TERMINATE_PROCESS / TERMINATE_EQ
			MPCF.ClearList(spdModule);
			MPCF.ClearList(spdTerminated);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCWIPTerminateModules_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpFrom);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
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

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
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

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", MPCF.Trim(HQGC.MATERIAL_TYPE_P)); // Production

                string[] header = new string[] { "Product", "Description" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "MAT_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvMaterial.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvTerminateCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_TERMINATE_CODE));
                in_node.AddString("USE_YN", "Y");

                string[] header = new string[] { "Terminattion Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvTerminateCode.Text = cdvTerminateCode.Show(cdvTerminateCode, "Terminate Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvTerminateCode.Text) != "")
                {
                    if (cdvTerminateCode.returnDatas.Count > 0)
                    {
                        cdvTerminateCode.Tag = cdvTerminateCode.returnDatas[1];
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }          
        }
        //IS-21-04-017 Terminate Module
        private void cdvTerminateProcess_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");
                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", "TERMINATE_PROCESS");
                in_node.AddString("USE_YN", "Y");

                string[] header = new string[] { "Termination Process", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvProcess.Text = cdvProcess.Show(cdvProcess, "Terminate Process", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");
                if (MPCF.Trim(cdvProcess.Text) != "")
                {
                    if (cdvProcess.returnDatas.Count > 0)
                    {
                        cdvProcess.Tag = cdvProcess.returnDatas[1];
						cdvEquipment.Text = "";
						cdvEquipment.Description = "";
                    }

                    this.setTerminateProcessData();

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCause_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_TERMINATE_CAUSE));
                in_node.AddString("USE_YN", "Y");

                string[] header = new string[] { "Cause Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvCause.Text = cdvCause.Show(cdvCause, "Cause Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvCause.Text) != "")
                {
                    if (cdvCause.returnDatas.Count > 0)
                    {
                        cdvCause.Tag = cdvCause.returnDatas[1];
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }          

        }
        //IS-21-04-017 Terminate Module
        private void cdvTerminateEquipment_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (cdvProcess.Text != "")
                {
                    TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                    TRSNode out_node = new TRSNode("VIEW_CODE_OUT");
                    // In Node Setup
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '7';
					in_node.AddString("TABLE_NAME", "TERMINATE_EQ");
                    in_node.AddString("KEY_2", cdvProcess.Text);
                    in_node.AddString("USE_YN", "Y");

                    string[] header = new string[] { "Terminattion Equipment", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_1" };
                    cdvEquipment.Text = cdvEquipment.Show(cdvEquipment, "Terminate Equipment", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                    if (MPCF.Trim(cdvEquipment.Text) != "")
                    {
                        if (cdvEquipment.returnDatas.Count > 0)
                        {
                            cdvEquipment.Tag = cdvEquipment.returnDatas[1];
                        }
                    }
                }
                else
                {
                    MPCF.ShowMessage("Process is not selected", MSG_LEVEL.ERROR, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewLotStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(gSelectedLotID))
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(gSelectedLotID);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnViewLotHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(gSelectedLotID))
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(gSelectedLotID);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewLotStatus1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(gTerminatedLotID))
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotStatusPopup f = new frmWIPViewLotStatusPopup(gTerminatedLotID);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnViewLotHistory1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(gTerminatedLotID))
                {
                    return;
                }

                // Show Popup
                frmWIPViewLotHistoryPopup f = new frmWIPViewLotHistoryPopup(gTerminatedLotID);
                f.Owner = MPGV.gfrmMDI;
                f.ShowDialog();
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
                // Validation

                if (txtLotID.Text.ToString() == "")
                {
                    if (MPCF.CheckValue(cdvLineID, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cdvMaterial, false) == false)
                    {
                        return;
                    }
                }
                

                // Initialize Spread
                //MPCF.ClearList(spdModule);
                MPCF.ClearList(spdTerminated);

                // View Lot List
                if (ViewLotList() == false)
                {
                    cdvLineID.Select();
                    MPCF.SetFocus(cdvLineID);
                    return;
                }

                // View Terminated Lot List
                if (ViewTermainetedLotList() == false)
                {
                    cdvLineID.Select();
                    MPCF.SetFocus(cdvLineID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvTerminateCode, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvCause, false) == false)
                {
                    return;
                }

                //IS-21-04-017 Terminate Module
                // cdvProcess
                if (MPCF.CheckValue(cdvProcess, false) == false)
                {
                    return;
                }

                // cdvEquipment
                if (MPCF.CheckValue(cdvEquipment, false) == false)
                {
                    return;
                }
                
                // soiShiftCode
                if (MPCF.CheckValue(soiShiftCode, false) == false)
                {
                    return;
                }

                if (string.IsNullOrEmpty(gSelectedLotID))
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(548), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (!ValidateTerminateLot())
                {
                    return;
                }

                if (!TerminateLot())
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                /*
                if (MPCF.CheckValue(cdvTerminateCode, false) == false)
                {
                    return;
                }
                */

                if (string.IsNullOrEmpty(gTerminatedLotID))
                {
                    return;
                }

                if (gTerminatedLastActiveHisSeq == 0)
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(549), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (!DeleteLotHistory())
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = Application.StartupPath;
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpModuleList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdModule.Sheets[0].Protect = false;
                    spdModule.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdModule.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcelTerminated_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = Application.StartupPath;
                pop.InitialDirectory = "c:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpTerminated.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdTerminated.Sheets[0].Protect = false;
                    spdTerminated.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdTerminated.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdModule_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            gSelectedLotID = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.LOT_ID].Text;
            txtLotID.Text = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.LOT_ID].Text;
            gSelectedMatID = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.MAT_ID].Text;
            gSelectedMatVer = MPCF.ToInt(spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.MAT_VER].Text);
            gSelectedFlow = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.FLOW].Text;
            gSelectedFlowSeqNum = MPCF.ToInt(spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.FLOW_SEQ_NUM].Text);
            gSelectedOper = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.OPER].Text;
            gSelectedLastTranTime = DateTime.Parse(spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.LAST_TRAN_TIME].Text);
           // gSelectedLastTranTime = DateTime.ParseExact(spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.LAST_TRAN_TIME].Text, "yyyyMMddHHmmss", null);
            gSelectedFqcFlag = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.FQC_FLAG].Text;
            gSelectedInsTime = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.INS_TIME].Text;
            gSelectedLimitDate = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.LIMIT_DATE].Text;
            gSelectedTodate = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.TODATE].Text;
            gSelectedSameFlag = spdModule.Sheets[0].Cells[e.Row, (int)LOT_LIST.SAME_FLAG].Text;

            setTerminateProcessData();
        }

        private void spdTerminated_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            gTerminatedLotID = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LOT_ID].Text;
            txtLotID.Text = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LOT_ID].Text;
            gTerminatedMatID = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.MAT_ID].Text;
            gTerminatedMatVer = MPCF.ToInt(spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.MAT_VER].Text);
            gTerminatedFlow = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.FLOW].Text;
            gTerminatedFlowSeqNum = MPCF.ToInt(spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.FLOW_SEQ_NUM].Text);
            gTerminatedOper = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.OPER].Text;
            gTerminatedLastActiveHisSeq = MPCF.ToInt(spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LAST_ACTIVE_HIST_SEQ].Text);
            gTerminatedFqcFlag = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.FQC_FLAG].Text;
            gTerminatedInsTime = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.INS_TIME].Text;
            gTerminatedLimitDate = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.LIMIT_DATE].Text;
            gTerminatedTodate = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TODATE].Text;
            gTerminatedSameFlag = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.SAME_FLAG].Text;
            gTerminatedTime = spdTerminated.Sheets[0].Cells[e.Row, (int)TERMINATED_LIST.TERMINATE_TIME].Text;
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


        #region Function

        private bool ViewLotList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdModule);

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
                TRSNode lot_list;

                MPCF.SetInMsg(in_node);
                if (string.IsNullOrEmpty(MPCF.Trim(txtLotID.Text)))
                {
                    in_node.ProcStep = '1'; // by View Conditions
                }
                else
                {
                    /* - [GERP PROJECT] [ERP 23.05.24] 시작***********************************************/
                    // SELECT Ooper > M4000  -> Ooper > <> M4000
                    //in_node.ProcStep = '2'; // by Lot ID
                    in_node.ProcStep = '5'; // by Lot ID
                    /* - [GERP PROJECT] 끝*****************************************************************/
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_TIME", dtpFromDateTimeOut.ToString("yyyyMMdd") + "000000");
                    }
                }

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpToDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_TIME", dtpToDateTimeOut.ToString("yyyyMMdd") + "235959");
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdModule.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lot_list = out_node.GetList(0)[i];

                    spdModule.ActiveSheet.RowCount++;

                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_ID].Value = lot_list.GetString("LOT_ID");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.ORDER_ID].Value = lot_list.GetString("ORDER_ID");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_ID].Value = lot_list.GetString("MAT_ID");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_VER].Value = lot_list.GetInt("MAT_VER");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.LINE_ID].Value = lot_list.GetString("LOT_CMF_1");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.FLOW].Value = lot_list.GetString("FLOW");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.FLOW_SEQ_NUM].Value = lot_list.GetInt("FLOW_SEQ_NUM");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.OPER].Value = lot_list.GetString("OPER");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.QTY_1].Value = lot_list.GetDouble("QTY_1");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.LAST_TRAN_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("LAST_TRAN_TIME"));
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.FQC_FLAG].Value = lot_list.GetString("FQC_FLAG");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.INS_TIME].Value = lot_list.GetString("INS_TIME");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.LIMIT_DATE].Value = lot_list.GetString("LIMIT_DATE");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.TODATE].Value = lot_list.GetString("TODATE");
                    spdModule.ActiveSheet.Cells[i, (int)LOT_LIST.SAME_FLAG].Value = lot_list.GetString("SAME_FLAG");
                }

                //MPCF.FitColumnHeader(spdModule);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private void setTerminateProcessData()
        {
            int oper = 0;
            if (gSelectedOper.Length <= 0)
            {
                gSelectedOper = "0";
            }

            int.TryParse(gSelectedOper.Substring(1), out oper);
            if (oper >= 3110)
            {
                chkMachineErrorYn.Checked = true;
                chkMachineErrorYn.Enabled = false;
                if (MPCF.Trim(cdvProcess.Text) == "P0001")
                {
                    txtNumOfStrings.Enabled = true;
                }
                else
                {
                    txtNumOfStrings.Text = "";
                    txtNumOfStrings.Enabled = false;
                }
            }
            else
            {
                if (MPCF.Trim(cdvProcess.Text) == "P0001")
                {
                    chkMachineErrorYn.Checked = true;
                    chkMachineErrorYn.Enabled = false;
                    txtNumOfStrings.Enabled = true;
                }
                else
                {
                    txtNumOfStrings.Text = "";
                    txtNumOfStrings.Enabled = false;
                    chkMachineErrorYn.Checked = false;
                    chkMachineErrorYn.Enabled = true;
                }
            }
        }

        private bool ViewTermainetedLotList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdTerminated);

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
                TRSNode terminated_lot_list;

                MPCF.SetInMsg(in_node);
                if (string.IsNullOrEmpty(MPCF.Trim(txtLotID.Text)))
                {
                    in_node.ProcStep = '3'; // by View Conditions
                }
                else
                {
                    /* - [GERP PROJECT] [ERP 23.05.24] 시작***********************************************/
                    // SELECT Ooper > M4000  -> Ooper > <> M4000
                    //in_node.ProcStep = '4'; // by Lot ID
                    in_node.ProcStep = '6';
                    /* - [GERP PROJECT] 끝*****************************************************************/
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_TIME", dtpFromDateTimeOut.ToString("yyyyMMdd") + "000000");
                    }
                }

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpToDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_TIME", dtpToDateTimeOut.ToString("yyyyMMdd") + "235959");
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdTerminated.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    terminated_lot_list = out_node.GetList(0)[i];

                    spdTerminated.ActiveSheet.RowCount++;

                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LOT_ID].Value = terminated_lot_list.GetString("LOT_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.ORDER_ID].Value = terminated_lot_list.GetString("ORDER_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MAT_ID].Value = terminated_lot_list.GetString("MAT_ID");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.MAT_VER].Value = terminated_lot_list.GetInt("MAT_VER");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LINE_ID].Value = terminated_lot_list.GetString("LOT_CMF_1");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.FLOW].Value = terminated_lot_list.GetString("FLOW");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.FLOW_SEQ_NUM].Value = terminated_lot_list.GetInt("FLOW_SEQ_NUM");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.OPER].Value = terminated_lot_list.GetString("OPER");

					// 20210517 SHIFT
					spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.SHIFT].Value = terminated_lot_list.GetString("TERMINATE_SHIFT");
					
                    //IS-21-04-017 Terminate Module
					// TERMINATE_PROCESS / TERMINATE_EQ
					spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATE_PROCESS].Value = terminated_lot_list.GetString("TERMINATE_PROCESS");
					spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATE_PROCESS].Tag = terminated_lot_list.GetString("TERMINATE_PROCESS_CODE");
					spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATE_EQ].Value = terminated_lot_list.GetString("TERMINATE_EQ");
					spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATE_EQ].Tag = terminated_lot_list.GetString("TERMINATE_EQ_CODE");

                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.QTY_1].Value = terminated_lot_list.GetDouble("QTY_1");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LAST_ACTIVE_HIST_SEQ].Value = terminated_lot_list.GetInt("LAST_ACTIVE_HIST_SEQ");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(terminated_lot_list.GetString("CREATE_TIME"));
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.ACTUAL_TERMINATION_DATE].Value = MPCF.MakeDateFormat(terminated_lot_list.GetString("TRAN_CMF_20"), DATE_TIME_FORMAT.DATE);
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LOT_DEL_TIME].Value = MPCF.MakeDateFormat(terminated_lot_list.GetString("LOT_DEL_TIME"));
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LOT_DEL_CODE].Value = terminated_lot_list.GetString("LOT_DEL_CODE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LOT_DEL_DESC].Value = terminated_lot_list.GetString("LOT_DEL_DESC");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LOT_DEL_CAUSE].Value = terminated_lot_list.GetString("LOT_DEL_CAUSE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.COMMENT].Value = terminated_lot_list.GetString("LAST_COMMENT");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.FQC_FLAG].Value = terminated_lot_list.GetString("FQC_FLAG");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.INS_TIME].Value = terminated_lot_list.GetString("INS_TIME");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.LIMIT_DATE].Value = terminated_lot_list.GetString("LIMIT_DATE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TODATE].Value = terminated_lot_list.GetString("TODATE");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.SAME_FLAG].Value = terminated_lot_list.GetString("SAME_FLAG");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.TERMINATE_TIME].Value = terminated_lot_list.GetString("TERMINATE_TIME");
                    spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.NUM_OF_STRINGS].Value = terminated_lot_list.GetString("LOT_CMF_17");

                    //20210927  //IS-21-04-017 Terminate Module
                    if (terminated_lot_list.GetString("TRAN_CMF_16") == "N")
                    {
                        //spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CELL_LOSS].Value = terminated_lot_list.GetString("TRAN_CMF_16");
                        spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CELL_LOSS].Value = "Y";

                    }
                    else
                    {
                        spdTerminated.ActiveSheet.Cells[i, (int)TERMINATED_LIST.CELL_LOSS].Value = "N";
                    }

                 }

                //MPCF.FitColumnHeader(spdTerminated);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ValidateTerminateLot()
        {
            TRSNode in_node = new TRSNode("VALIDATE_LOT_IN");
            TRSNode out_node = new TRSNode("VALIDATE_LOT_OUT");
            //TRSNode terminate_item;
            
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LOT_ID", gSelectedLotID);

                if (MPCF.CallService("CWIP", "CWIP_Validate_Terminate_Lot", in_node, ref out_node) == false)
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

        private bool TerminateLot()
        {
            TRSNode in_node = new TRSNode("TERMINATE_LOT_IN");
            TRSNode out_node = new TRSNode("TERMINATE_LOT_OUT");
            //TRSNode terminate_item;
            DateTime dtpActualTerminationDateTimeOut = new DateTime();

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", gSelectedLotID);
                in_node.AddString("MAT_ID", gSelectedMatID);
                in_node.AddInt("MAT_VER", gSelectedMatVer);
                in_node.AddString("FLOW", gSelectedFlow);
                in_node.AddInt("FLOW_SEQ_NUM", gSelectedFlowSeqNum);
                in_node.AddString("OPER", gSelectedOper);
                in_node.AddString("DEL_CODE", MPCF.Trim(cdvTerminateCode.Text));
                in_node.AddString("NUM_OF_STRINGS", MPCF.Trim(this.txtNumOfStrings.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                //in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');
                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCause.Text));

                if (dtpActualTerminationDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpActualTerminationDate.Value.ToString(), out dtpActualTerminationDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        /*
                            1. TER_DATE+060000 > SYS_DATE
                               TER_DATE+000000  

                            2. TER_DATE+060000 < LAST_DATE 
                               (일자는 동일한데 시간만 다를경우)
                               TER_DATE = LAST_DATE + 1초   
    
                            3. LAST_DATE의 일자가 더 크므로 걍 넵둠 (오류발생)
                        */
                        DateTime terDate;
                        DateTime sysDate;
                        DateTime lastDate;

                        terDate = DateTime.ParseExact(dtpActualTerminationDateTimeOut.ToString("yyyyMMdd") + "060000", "yyyyMMddHHmmss", null);
                        sysDate = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", null);
                        lastDate = DateTime.ParseExact(gSelectedLastTranTime.ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", null);

                        if (DateTime.Compare(terDate, sysDate) > 0)
                        {
                            terDate = DateTime.ParseExact(dtpActualTerminationDateTimeOut.ToString("yyyyMMdd") + "000000", "yyyyMMddHHmmss", null);
                        }

                        DateTime terYmd = DateTime.ParseExact(terDate.ToString("yyyyMMdd"), "yyyyMMdd", null);
                        DateTime lastYmd = DateTime.ParseExact(lastDate.ToString("yyyyMMdd"), "yyyyMMdd", null);
                        if (DateTime.Compare(terYmd, lastYmd) == 0 && DateTime.Compare(terDate, lastDate) <= 0)
                        {
                            terDate = lastDate.AddSeconds(1);
                        }

                        in_node.AddString("BACK_TIME", terDate.ToString("yyyyMMddHHmmss"));
                        in_node.AddString("TRAN_CMF_20", terDate.ToString("yyyyMMdd"));

                        /* FQC 통과 되지 않은 모듈 폐기시, ParseExact 예외 방지를 위해 조건 추가 */
                        // ERP고도화 프로젝트시 룰이 변경됨( 기존 FQC 확인에서 PACKING 확인으로 바뀜 )
                        // 변경된 룰( packing이전(한번도 패킹한적 없는 경우), packing이후( unpack( rework order 있는 경우)  ) => 폐기가능
                        //if (false == string.IsNullOrEmpty(gSelectedLimitDate))
                        //{
                        //    if (DateTime.Compare(terDate, DateTime.ParseExact(gSelectedLimitDate, "yyyyMMddHHmmss", null)) > 0)
                        //    {
                        //        MPCF.ShowMsgBox("The module cannot be terminated in MES since closing date has passed. Please terminate the module in SAP.");
                        //        return false;
                        //    }
                        //}

                        //else
                        // {
                        //    MPCF.ShowMessage("test Success", MSG_LEVEL.ERROR, false);
                        //    return false;
                        //}

                    }
                }               
                  
                /*IS-21-01-049  include check function (Machine Error) */
                if (chkMachineErrorYn.Checked == true)
                {
                    in_node.AddString("TRAN_CMF_16", "Y");
                }
                else
                {
                    in_node.AddString("TRAN_CMF_16", "N");
                }  

				/*
                // cdvProcess / cdvEquipment
                //IS-21-04-017 Terminate Module
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvProcess.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvEquipment.Text));
				*/

				// IS-21-05-028 Terminate Module Shift 추가건 개발
				in_node.AddString("TERMINATE_SHIFT", MPCF.Trim(soiShiftCode.Text));
				in_node.AddString("TERMINATE_PROCESS_CODE", MPCF.Trim(cdvProcess.Text));
				in_node.AddString("TERMINATE_EQ_CODE", MPCF.Trim(cdvEquipment.Text));
				
                if (MPCF.CallService("WIP", "WIP_Terminate_Lot", in_node, ref out_node) == false)
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

        private bool DeleteLotHistory()
        {
            TRSNode in_node = new TRSNode("DELETE_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            //TRSNode terminate_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", gTerminatedLotID);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", gTerminatedLastActiveHisSeq);

                //gTerminatedTime = DateTime.ParseExact(gTerminatedTime, "yyyyMMddHHmmss", null).AddMonths(1).ToString("yyyyMM") + "01055959";

                //[2023.10.16]폐기취소시 한 달이내 검증로직 제외
                /* FQC 통과 되지 않은 모듈 폐기시, ParseExact 예외 방지를 위해 조건 추가 */
                /*
                if (false == string.IsNullOrEmpty(gTerminatedTodate))
                {
                    if (DateTime.Compare(DateTime.ParseExact(gTerminatedTodate, "yyyyMMddHHmmss", null), DateTime.ParseExact(gTerminatedTime, "yyyyMMddHHmmss", null)) > 0)
                    {
                        MPCF.ShowMsgBox("The module cannot be un-terminated in MES since closing date has passed. Please un-terminate the module in SAP.");
                        return false;

                    }
                }
                else
                {
                    if (MPCF.ShowMsgBox("After canceling module termination, please check if GR has been successfully completed in SAP.", MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return false;
                    }
                    else
                    {

                    }
                }
                */
                            

                if (MPCF.CallService("WIP", "WIP_Delete_Lot_History", in_node, ref out_node) == false)
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

		private void soiShiftCode_CodeViewButtonClick(object sender, EventArgs e)
		{
			try
			{

				TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
				MPCF.SetInMsg(in_node);
				in_node.ProcStep = '1';
				in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

				string[] header = new string[] { "Shift Code", "Description" };
				string[] display = new string[] { "KEY_1", "DATA_1" };

				soiShiftCode.Text = soiShiftCode.Show(soiShiftCode, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

				// Validation
				if (string.IsNullOrEmpty(soiShiftCode.Text) == true)
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

        private void txtNumOfStrings_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링             
	        if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {          
    	        e.Handled = true;             
            }    
        }
    }
}
