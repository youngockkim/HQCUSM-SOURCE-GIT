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
    public partial class frmCWIPTerminateModulesMulti : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPTerminateModulesMulti()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        String TERMINATE_CODE_DEFAULT = "T024";
        String TERMINATE_CODE_TEXT_DEFAULT = "Recycling";
        String TERMINATE_CAUSE_DEFAULT = "C012";
        String TERMINATE_CAUSE_TEXT_DEFAULT = "Method";
        String TERMINATE_PROCESS_DEFAULT = "P0028";
        String TERMINATE_EQ_DEFAULT = "E0058";
        String TERMINATE_COMMENT = "Recycling";
        String EASTERNZONEID = "Eastern Standard Time";
  
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
            REMARK,
            SHIFT,
            LAST_TRAN_TIME_ORG
            //LIMIT_DATE
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
            TERMINATE_PROCESS, //IS-21-04-017 Terminate Module
            TERMINATE_EQ, //IS-21-04-017 Terminate Module
            QTY_1,
            LAST_ACTIVE_HIST_SEQ,
            CREATE_TIME,
            ACTUAL_TERMINATION_DATE,
            SYS_TRAN_TIME,
            LOT_DEL_CODE,
            LOT_DEL_DESC,
            LOT_DEL_CAUSE,
            COMMENT
        }

        #endregion

        #region [Variable Definition]

        private string gSelectedLotID = string.Empty;
        private string gSelectedMatID = string.Empty;
        private string gSelectedFlow = string.Empty;
        private string gSelectedOper = string.Empty;

        private string gTerminatedLotID = string.Empty;
        private string gTerminatedMatID = string.Empty;
        private string gTerminatedFlow = string.Empty;
        private string gTerminatedOper = string.Empty;
        private int gTerminatedLastActiveHisSeq = 0;

        private TRSNode gUserInputLotList;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPTerminateModulesMulti_Load(object sender, EventArgs e)
        {
            dtpActualTerminationDate.Value = DateTime.Today;
            MPCF.ConvertCaption(this);

            // IS-21-04-017 Terminate Module
			// TERMINATE_PROCESS / TERMINATE_EQ
			MPCF.ClearList(spdModule);
			MPCF.ClearList(spdTerminated);

            gUserInputLotList = new TRSNode("VIEW_LOT_LIST_OUT");

            cdvCause.Text = TERMINATE_CAUSE_DEFAULT;
            cdvCause.Description = TERMINATE_CAUSE_TEXT_DEFAULT;

            cdvTerminateCode.Text = TERMINATE_CODE_DEFAULT;
            cdvTerminateCode.Description = TERMINATE_CODE_TEXT_DEFAULT;
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCWIPTerminateModulesMulti_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
//                MPCF.SetFocus(dtpFrom);

                bIsShown = true;
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int row, inx =0, rowCount = 0, curCount = 0, processedCnt = 0;
            String msg = "";

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

                rowCount = spdModule.ActiveSheet.RowCount;
                msg = String.Format( "Do you want to terminate these {0} modules?", rowCount);
                if (MPCF.ShowMsgBox(msg, MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                
                for (row = 0, inx=0; row < rowCount; row++)
                {
                    MPCF.ShowMessage("Terminating Modules...", MSG_LEVEL.INFO, false);

                    curCount = spdModule.ActiveSheet.RowCount;
                    inx = row - (rowCount - curCount);
                    if (spdModule.ActiveSheet.Cells[inx, (int)LOT_LIST.REMARK].Value.ToString().Length > 0) 
                        continue;

                    spdModule.ActiveSheet.AddSelection(inx, 0, 1, 1);

                    if (TerminateLot(inx))
                    {
                        processedCnt++;
                    }
                }
                MPCF.ShowMessage("Total : " + row + "    [ Terminated : " + processedCnt + ", Remained : " + (row - processedCnt) + " ]" ,   MSG_LEVEL.ERROR, false);
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
                //btnView.PerformClick();

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

        #endregion


        #region Function

        private void ValidateLimitDate()
        {
            int i;
            TRSNode lot_list;

            DateTime terDate = DateTime.UtcNow;

            TimeZoneInfo est;
            try
            {
                est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                Console.Write("Unable to retrieve the Eastern Standard time zone.");
                return;
            }
            catch (InvalidTimeZoneException)
            {
                Console.Write("Unable to retrieve the Eastern Standard time zone.");
                return;
            }
            DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(terDate.AddSeconds(-5), est);

            for (i = 0; i < gUserInputLotList.GetList(0).Count; i++)
            {
                lot_list = gUserInputLotList.GetList(0)[i];

                String limitDate = lot_list.GetString("LIMIT_DATE");

                if (string.IsNullOrEmpty(limitDate) == true)
                {
                    continue;
                }

                /* FQC 통과 되지 않은 모듈 폐기시, ParseExact 예외 방지를 위해 조건 추가 */
                // ERP고도화 프로젝트시 룰이 변경됨( 기존 FQC 확인에서 PACKING 확인으로 바뀜 )
                // 변경된 룰( packing이전(한번도 패킹한적 없는 경우), packing이후( unpack( rework order )  )
                //if (DateTime.Compare(terDate, DateTime.ParseExact(limitDate, "yyyyMMddHHmmss", null)) > 0)
                //{
                //    String limitMsg = "The module cannot be terminated in MES since closing date has passed. Please terminate the module in SAP.";
                //    lot_list.SetString("REMARK", String.Format("{0}\r\n{1}", limitMsg, lot_list.GetString("REMARK")));
                //}

            }
        }
        
        private bool ViewLotList()
        {
            try
            {
                int i,row = 0;

                MPCF.ClearList(spdModule);

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
                //TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
                TRSNode lot_list, lot_id_list;

                List<String> list = txtLotID.Text.Replace("\r", "").Trim().Split('\n').Distinct().ToList();
                list.ForEach(item => {
                    lot_id_list = in_node.AddNode("LOT_ID_LIST");
                    lot_id_list.AddString("LOT_ID", item );
                    lot_id_list.AddString("FACTORY", "USGAM1");
                });

                MPCF.SetInMsg(in_node);
                if (MPCF.CallService("CWIP", "CWIP_View_Multi_Lot_List", in_node, ref gUserInputLotList) == false)
                {
                    return false;
                }

                ValidateLimitDate();

                spdModule.ActiveSheet.RowCount = 0;

                for (i = 0; i < gUserInputLotList.GetList(0).Count; i++)
                {
                    lot_list = gUserInputLotList.GetList(0)[i];

                    if (lot_list.GetChar("LOT_DEL_FLAG") == 'Y')
                    {
                        this.AddTerminatedLotList(lot_list);
                        continue;
                    }

                    if ( lot_list.GetString("REMARK").Length > 0 )
                    {
                        row = spdModule.ActiveSheet.RowCount++;

                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].Value = lot_list.GetString("LOT_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.ORDER_ID].Value = lot_list.GetString("ORDER_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_ID].Value = lot_list.GetString("MAT_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_VER].Value = lot_list.GetInt("MAT_VER");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LINE_ID].Value = lot_list.GetString("LOT_CMF_1");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW].Value = lot_list.GetString("FLOW");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW_SEQ_NUM].Value = lot_list.GetInt("FLOW_SEQ_NUM");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.OPER].Value = lot_list.GetString("OPER");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.QTY_1].Value = lot_list.GetDouble("QTY_1");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LAST_TRAN_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("LAST_TRAN_TIME"));
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].Value = lot_list.GetString("REMARK");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.SHIFT].Value = lot_list.GetChar("TERMINATE_SHIFT");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LAST_TRAN_TIME_ORG].Value = lot_list.GetString("LAST_TRAN_TIME");
                        //spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LIMIT_DATE].Value = MPCF.MakeDateFormat(lot_list.GetString("LIMIT_DATE"));

                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].ForeColor = Color.Orange;
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].ForeColor = Color.Orange;
                    }
                }

                for (i = 0; i < gUserInputLotList.GetList(0).Count; i++)
                {
                    lot_list = gUserInputLotList.GetList(0)[i];

                    if (lot_list.GetChar("LOT_DEL_FLAG") != 'Y' && lot_list.GetString("REMARK").Length <= 0)
                    {
                        row = spdModule.ActiveSheet.RowCount++;

                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].Value = lot_list.GetString("LOT_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.ORDER_ID].Value = lot_list.GetString("ORDER_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_ID].Value = lot_list.GetString("MAT_ID");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_VER].Value = lot_list.GetInt("MAT_VER");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LINE_ID].Value = lot_list.GetString("LOT_CMF_1");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW].Value = lot_list.GetString("FLOW");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW_SEQ_NUM].Value = lot_list.GetInt("FLOW_SEQ_NUM");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.OPER].Value = lot_list.GetString("OPER");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.QTY_1].Value = lot_list.GetDouble("QTY_1");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("CREATE_TIME"));
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LAST_TRAN_TIME].Value = MPCF.MakeDateFormat(lot_list.GetString("LAST_TRAN_TIME"));
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].Value = lot_list.GetString("REMARK");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.SHIFT].Value = lot_list.GetChar("TERMINATE_SHIFT");
                        spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LAST_TRAN_TIME_ORG].Value = lot_list.GetString("LAST_TRAN_TIME");
                        //spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LIMIT_DATE].Value = MPCF.MakeDateFormat(lot_list.GetString("LIMIT_DATE"));
                    }
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

        private bool AddTerminatedLotList(TRSNode out_node)
        {
            int row = spdTerminated.ActiveSheet.RowCount++;

            try
            {
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LOT_ID].Value = out_node.GetString("LOT_ID");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.ORDER_ID].Value = out_node.GetString("ORDER_ID");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.MAT_ID].Value = out_node.GetString("MAT_ID");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.MAT_VER].Value = out_node.GetInt("MAT_VER");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LINE_ID].Value = out_node.GetString("LOT_CMF_1");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.FLOW].Value = out_node.GetString("FLOW");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.FLOW_SEQ_NUM].Value = out_node.GetInt("FLOW_SEQ_NUM");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.OPER].Value = out_node.GetString("OPER");

                // 20210517 SHIFT
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.SHIFT].Value = out_node.GetString("TERMINATE_SHIFT");

                //IS-21-04-017 Terminate Module
                // TERMINATE_PROCESS / TERMINATE_EQ
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.TERMINATE_PROCESS].Value = out_node.GetString("TERMINATE_PROCESS");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.TERMINATE_PROCESS].Tag = out_node.GetString("TERMINATE_PROCESS_CODE");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.TERMINATE_EQ].Value = out_node.GetString("TERMINATE_EQ");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.TERMINATE_EQ].Tag = out_node.GetString("TERMINATE_EQ_CODE");

                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.QTY_1].Value = out_node.GetDouble("QTY_1");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LAST_ACTIVE_HIST_SEQ].Value = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.ACTUAL_TERMINATION_DATE].Value = MPCF.MakeDateFormat(out_node.GetString("TRAN_CMF_20"), DATE_TIME_FORMAT.DATE);
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.SYS_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetString("SYS_TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LOT_DEL_CODE].Value = out_node.GetString("LOT_DEL_CODE");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LOT_DEL_DESC].Value = out_node.GetString("LOT_DEL_DESC");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.LOT_DEL_CAUSE].Value = out_node.GetString("LOT_DEL_CAUSE");
                spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.COMMENT].Value = out_node.GetString("LAST_COMMENT");

                //20210927  //IS-21-04-017 Terminate Module
                if (out_node.GetString("TRAN_CMF_16") == "N")
                {
                    spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.CELL_LOSS].Value = "Y";

                }
                else
                {
                    spdTerminated.ActiveSheet.Cells[row, (int)TERMINATED_LIST.CELL_LOSS].Value = "N";
                }
 
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }
 

        private bool ValidateTerminateLot(String LotID, int row)
        {
            TRSNode in_node = new TRSNode("VALIDATE_LOT_IN");
            TRSNode out_node = new TRSNode("VALIDATE_LOT_OUT");
            //TRSNode terminate_item;
            
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LOT_ID", LotID);

                if (MPCF.CallService("CWIP", "CWIP_Validate_Terminate_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;

            }
            catch (Exception ex)
            {
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LINE_ID].ForeColor = Color.Red;
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LINE_ID].Value = LotID + " was already terminated.";
                return false;
            }
        }

        private bool TerminateLot(int row)
        {
            String LotID = spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].Value.ToString();
            if (!ValidateTerminateLot(LotID, row))
            {
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].ForeColor = Color.Red;
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].ForeColor = Color.Red;
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].Value = LotID + " was already terminated.";
                return false;
            }

            TRSNode in_node = new TRSNode("TERMINATE_LOT_IN");
            TRSNode out_node = new TRSNode("TERMINATE_LOT_OUT");
            DateTime dtpActualTerminationDateTimeOut = new DateTime();

            //TRSNode terminate_item;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", LotID);
                in_node.AddString("LINE_ID", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LINE_ID].Value.ToString());
                in_node.AddString("MAT_ID", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_ID].Value.ToString());
                in_node.AddInt("MAT_VER", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.MAT_VER].Value.ToString());
                in_node.AddString("FLOW", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW].Value.ToString());
                in_node.AddInt("FLOW_SEQ_NUM", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.FLOW_SEQ_NUM].Value.ToString());
                in_node.AddString("OPER", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.OPER].Value.ToString());
                in_node.AddString("DEL_CODE", MPCF.Trim(cdvTerminateCode.Text));
                in_node.AddString("COMMENT", TERMINATE_COMMENT);
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
                        lastDate = DateTime.ParseExact(DateTime.Now.AddDays(-1).ToString("yyyyMMddHHmmss"), "yyyyMMddHHmmss", null);

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
                in_node.AddString("TERMINATE_SHIFT", spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.SHIFT].Value.ToString());
                in_node.AddString("TERMINATE_PROCESS_CODE", TERMINATE_PROCESS_DEFAULT);
                in_node.AddString("TERMINATE_EQ_CODE", TERMINATE_EQ_DEFAULT);
				
                if (MPCF.CallService("WIP", "WIP_Terminate_Lot", in_node, ref out_node) == false)
                {
                    spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].ForeColor = Color.Red;
                    spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].ForeColor = Color.Red;
                    spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].Value = out_node.Msg; 
                    return false;
                }

                TRSNode lot_id_list;
                TRSNode result_node = new TRSNode("TERMINATE_RESULT");
                lot_id_list = in_node.AddNode("LOT_ID_LIST");
                lot_id_list.AddString("LOT_ID", LotID);
                lot_id_list.AddString("FACTORY", "USGAM1");

                MPCF.SetInMsg(in_node);
                if (MPCF.CallService("CWIP", "CWIP_View_Multi_Lot_List", in_node, ref result_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdModule.ActiveSheet.RemoveRows(row, 1);
                if (result_node.GetList(0) != null && result_node.GetList(0)[0] != null)
                {
                    AddTerminatedLotList(result_node.GetList(0)[0]);
                }

                return true;

            }
            catch (Exception ex)
            {
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.LOT_ID].ForeColor = Color.Red;
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].ForeColor = Color.Red;
                spdModule.ActiveSheet.Cells[row, (int)LOT_LIST.REMARK].Value = ex.Message; 
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation

                // Initialize Spread
                //MPCF.ClearList(spdModule);
                MPCF.ClearList(spdTerminated);

                // View Lot List
                if (ViewLotList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCause_CodeViewButtonClick(object sender, EventArgs e)
        {
            MPCF.ShowMessage("Cause option (C-code) cannot be changed on this MES OI Terminate Modules (MULTI) page.", MSG_LEVEL.INFO, false);

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

                cdvCause.returnDatas[0] = "C012";
                cdvCause.returnDatas[1] = "Module";

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

    }
}
