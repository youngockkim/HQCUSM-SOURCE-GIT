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
using System.IO;

namespace SOI.Solar
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranChangeOrder : SOIBaseForm03
    {
        #region " Constant Definition "

        public enum SOURCE_LIST
        {
            ORDER_ID = 0,
            ORDER_DESC,
            MAT_ID
        }

        public enum TARGET_LIST
        {
            ORDER_ID = 0,
            ORDER_DESC,
            MAT_ID,
            MAT_VER,
            LINE_ID,
            SHIFT,
            OPER,
            WORK_CENTER,
            ORD_QTY,
            FINAL_ORDER_ID,
            FINAL_MAT_ID,
            FINAL_MAT_VER,
            PBA_ORDER_ID,
            PBA_MAT_ID,
            PBA_MAT_VER,
            MAT_MODEL,
            CUST_MAT_ID,
            WORK_DATE,
            PLAN_START_TIME,
            PLAN_END_TIME,
            ORDER_TYPE,
            LOT_TYPE,
            OWNER_CODE,
            CREATE_CODE,
            LOT_PRIORITY,
            ORG_DUE_TIME,
            ORD_STATUS_FLAG,
            START_QTY,
            PROC_QTY,
            SCRAP_QTY,
            REPAIR_REQ_QTY,
            REPAIR_SCRAP_QTY,
            NO_REPAIR_QTY,
            REPAIR_QTY,
            PRINT_QTY,
            INF_QTY,
            BOX_PRINT_QTY,
            ORD_CMF_1,
            ORD_CMF_2,
            ORD_CMF_3,
            ORD_CMF_4,
            ORD_CMF_5,
            ORD_CMF_6,
            ORD_CMF_7,
            ORD_CMF_8,
            ORD_CMF_9,
            ORD_CMF_10,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        public enum LOT_LIST
        {
            CHK_FLAG = 0,
            LOT_ID,
            LOT_DESC,
            MAT_ID,
            MAT_VER,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            QTY_1,
            QTY_2,
            QTY_3,
            LOT_TYPE,
            OWNER_CODE,
            CREATE_CODE,
            LOT_PRIORITY,
            LOT_STATUS,
            ORG_DUE_TIME,
            RES_ID,
            ORDER_ID,
            LOT_CMF_3,
            LOT_CREATE_FLAG,
            LOT_CREATE_TIME,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COLS_SCREEN_LIST
        {
            SCREEN_ID = 0,
            SCREEN_DESCRIPTION
        }

        #endregion

        #region Constructor

        public frmCUSTranChangeOrder()
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
                //ViewScreenList(string.Empty);
                ViewSourceOrderList();
                ViewTargetOrderList();

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindScreenID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if (ViewScreenList(txtFindScreenID.Text) == false)
                    //{
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewScreenList(txtFindScreenID.Text) == false)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewScreenList(string.Empty) == false)
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
        /// Print Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Label Print 합니다.
                //MPCF.PrintFlexibleScreen(this, base.printOption, udcScreen, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            string sOrderID;

            try
            {
                if (CheckCondition("WIP_Adapt_Lot") == true)
                {

                    if (AdaptOrderLot() == false)
                    {
                        return;
                    }

                    // Set List
                    sOrderID = MPCF.Trim(cdvSourceOrderID.Text);
                    if (sOrderID == "") return;

                    if (ViewLotList(sOrderID) == false) return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Screen List
        /// </summary>
        /// <param name="screenId"></param>
        /// <returns></returns>
        private bool ViewScreenList(string screenId)
        {
            TRSNode in_node = new TRSNode("VIEW_SCREEN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SCREEN_LIST_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(this);
                //udcScreen.InitFlexibleScreen();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY_OPTION", MPGV.gsFactory);
                if (string.IsNullOrEmpty(screenId) == false)
                {
                    in_node.AddString("SCREEN_ID", screenId);
                }
                if (MPCF.CallService("BAS", "BAS_View_Screen_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                if (out_node.GetList(0) != null)
                {
                    // Clear
                    spdSourceOrderList.Sheets[0].ClearSelection();

                    int iRow = 0;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdSourceOrderList.Sheets[0].Rows.Count;
                        spdSourceOrderList.Sheets[0].RowCount++;

                        spdSourceOrderList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.SCREEN_ID].Value = out_node.GetList(0)[i].GetString("SCREEN_ID");
                        spdSourceOrderList.Sheets[0].Cells[iRow, (int)COLS_SCREEN_LIST.SCREEN_DESCRIPTION].Value = out_node.GetList(0)[i].GetString("SCREEN_DESC");                            
                    }

                    // Selection
                    spdSourceOrderList.ActiveSheet.ActiveRowIndex = 0;
                    spdSourceOrderList.Sheets[0].AddSelection(0, 0, 1, spdSourceOrderList.Sheets[0].Columns.Count);
                }
                
                // Fit
                MPCF.FitColumnHeader(spdSourceOrderList);

                // Re-bind
                if (string.IsNullOrEmpty(screenId) == false)
                {
                    //txtFindScreenID.Text = screenId;
                    //txtFindScreenID.SelectAll();
                    //txtFindScreenID.Focus();
                }

                // View
                if (spdSourceOrderList.Sheets[0].Rows.Count > 0)
                {
                    if (ViewScreenInfo(spdSourceOrderList.Sheets[0].Cells[spdSourceOrderList.Sheets[0].GetSelection(0).Row, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString()) == false)
                    {
                        return false;
                    }

                    if (ViewScreen(spdSourceOrderList.Sheets[0].GetSelection(0).Row) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Screen 
        /// </summary>
        /// <param name="sScreenID"></param>
        /// <returns></returns>
        private bool ViewScreenInfo(string sScreenID)
        {
            TRSNode in_node = new TRSNode("View_Screen_Info_IN");
            TRSNode out_node = new TRSNode("View_Screen_Info_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(grpLotList);
                MPCF.FieldClear(grpTargetOrderList);

                // Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", sScreenID);
                if (MPCF.CallService("BAS", "BAS_View_Screen_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                //txtScreenId.Text = out_node.GetString("SCREEN_ID");
                //txtScreenDesc.Text = out_node.GetString("SCREEN_DESC");
                //txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                //txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                //txtUpdateUser.Text =  out_node.GetString("UPDATE_USER_ID");
                //txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Screen 조회
        /// Local 파일에 있고 변경되지 않은 경우 Local 파일로 조회
        /// Local 파일에 없거나 변경된 경우 서비스 조회
        /// </summary>
        /// <returns></returns>
        private bool ViewScreen(int selectedRowIndex)
        {
            string sPathZip;
            string sPathXML;
            string sCreateTime;

            long iFileSize;
            DateTime create_time;
            TRSNode in_node = new TRSNode("View_Screen_IN");
            TRSNode out_node = new TRSNode("View_Screen_OUT");

            try
            {
                // Field Clear
                MPCF.FieldClear(grpTargetOrderList);

                // 1. Screen 정보가 없는 경우 종료
                if (spdSourceOrderList.Sheets[0].Rows.Count < 1)
                {
                    return false;
                }

                // 2. 선택된 Screen이 없는 경우 종료
                if (selectedRowIndex < 0)
                {
                    return false;
                }

                // 3. 선택된 Screen ID로 파일 경로 설정
                sPathZip = MPGV.gsFlexibleScreenLocalPath + spdSourceOrderList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".gzip";

                // 4. 파일이 없는 경우 생성
                if (Directory.Exists(MPGV.gsFlexibleScreenLocalPath) == false)
                {
                    Directory.CreateDirectory(MPGV.gsFlexibleScreenLocalPath);
                }

                // 5. File 정보 가져오기
                FileInfo fi = new FileInfo(sPathZip);

                // 6. Server File 정보와 비교
                // 파일이 없던 경우 초기값으로 비교하여 강제 업데이트
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SCREEN_ID", spdSourceOrderList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString());
                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19001231000000");
                    in_node.AddInt("FILE_SIZE", 0);
                }
                else
                {
                    create_time = fi.CreationTime;
                    sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    iFileSize = fi.Length;
                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                }
                if (MPCF.CallService("BAS", "BAS_Check_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    // File Update
                    UpdateScreenXML(spdSourceOrderList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString(), out_node);
                }

                // 7. XML 파일 경로 설정
                sPathXML = MPGV.gsFlexibleScreenLocalPath + spdSourceOrderList.Sheets[0].Cells[selectedRowIndex, (int)COLS_SCREEN_LIST.SCREEN_ID].Value.ToString() + ".xml";

                // 8. Init
                //udcScreen.InitFlexibleScreen();

                // 9. Open
                //spdSpread.Open(sPathXML);
                //udcScreen.ScreenSpread.Open(sPathXML);

                // 10. Set Theme
                //udcScreen.SetOITheme();

                // 11. Lock
                //udcScreen.ScreenLock = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        /// <summary>
        /// 다운로드한 파일을 Local에 저장
        /// </summary>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool UpdateScreenXML(string screenID, TRSNode out_node)
        {
            try
            {
                // 1. File Path 설정
                string sPath = MPGV.gsFlexibleScreenLocalPath + screenID;

                // 2. gzip 파일 생성.
                FileStream fs = File.Open(sPath + ".gzip", FileMode.Create);

                // 3. 다운로드한 파일 저장
                BinaryWriter bw = new BinaryWriter(fs);
                fs.Flush();
                byte[] buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2);
                bw.Write(buffer);
                bw.Close();
                fs.Close();

                // 4. 생성 날짜 수정.
                DateTime dt_create_time = MPCF.ToDate(out_node.GetString("CREATION_TIME"));
                File.SetCreationTime(sPath + ".gzip", dt_create_time);

                // 5. XML 파일 생성
                MPCF.ZipDecompress(sPath);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(cdvSourceOrderID);
                    MPCF.FieldClear(cdvTargetOrderID);
                    MPCF.ClearList(spdSourceOrderList);
                    MPCF.ClearList(spdTargetOrderList);
                    MPCF.ClearList(spdLotList);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private bool ViewSourceOrderList()
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_LIST_OUT");
            List<TRSNode> order_list;

            int i = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvSourceOrderID.Text));
                if (MPCF.CallService("CUS", "CUS_View_Order_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                order_list = out_node.GetList("ORDER_LIST");

                for (i = 0; i < order_list.Count; i++)
                {
                    spdSourceOrderList.ActiveSheet.RowCount++;
                    spdSourceOrderList.ActiveSheet.Cells[i, (int)SOURCE_LIST.ORDER_ID].Value = order_list[i].GetString("ORDER_ID");
                    spdSourceOrderList.ActiveSheet.Cells[i, (int)SOURCE_LIST.ORDER_DESC].Tag = order_list[i].GetString("ORDER_DESC");
                    //spdSourceOrderList.ActiveSheet.Cells[i, (int)SOURCE_LIST.MAT_ID].Text = order_list[i].GetString("MAT_ID");
                }

                MPCF.FitColumnHeader(spdSourceOrderList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewTargetOrderList()
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_LIST_OUT");
            List<TRSNode> order_list;

            int i = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvTargetOrderID.Text));
                if (MPCF.CallService("CUS", "CUS_View_Order_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                order_list = out_node.GetList("ORDER_LIST");

                for (i = 0; i < order_list.Count; i++)
                {
                    spdTargetOrderList.ActiveSheet.RowCount++;
                    spdTargetOrderList.ActiveSheet.Cells[i, (int)TARGET_LIST.ORDER_ID].Value = order_list[i].GetString("ORDER_ID");
                    spdTargetOrderList.ActiveSheet.Cells[i, (int)TARGET_LIST.ORDER_DESC].Tag = order_list[i].GetString("ORDER_DESC");
                    spdTargetOrderList.ActiveSheet.Cells[i, (int)TARGET_LIST.MAT_ID].Text = order_list[i].GetString("MAT_ID");
                    spdTargetOrderList.ActiveSheet.Cells[i, (int)TARGET_LIST.MAT_VER].Text = order_list[i].GetInt("MAT_VER").ToString();
                }

                MPCF.FitColumnHeader(spdTargetOrderList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewLotList(string sOrderID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            List<TRSNode> lot_list;
            int i;

            MPCF.ClearList(spdLotList);

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LOT_CMF_3", sOrderID);        //in_node.AddString("ORDER_ID", sOrderID);


                if (MPCF.CallService("CUS", "CUS_View_Lot_List_By_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                lot_list = out_node.GetList("LOT_LIST");

                for (i = 0; i < lot_list.Count; i++)
                {
                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_ID].Value = lot_list[i].GetString("LOT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_DESC].Tag = lot_list[i].GetString("LOT_DESC");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_ID].Text = lot_list[i].GetString("MAT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_CMF_3].Text = lot_list[i].GetString("LOT_CMF_3");
                }

                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "WIP_Adapt_Lot":

                    // comment text 가 empty인지 확인
                    if (txtComment.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtComment.Focus();
                        return false;
                    }

                    break;
            }

            return true;

        }

        private bool AdaptOrderLot()
        {
            int i = 0;
            string sLotID;

            TRSNode in_node = new TRSNode("ADAPT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            // Adapt Lot
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", string.Empty);
            in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvTargetOrderID.Text));
            in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

            try
            {

                for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    if (spdLotList.ActiveSheet.GetValue(i, 0) != null)
                    {
                        if (Convert.ToBoolean(spdLotList.ActiveSheet.GetValue(i, 0)) == true)
                        {
                            sLotID = MPCF.Trim(spdLotList.ActiveSheet.GetValue(i, 1));

                            // Adapt Lot
                            in_node.SetString("LOT_ID", sLotID);

                            if (MPCF.CallService("WIP", "WIP_Adapt_Lot", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        #endregion

        private void cdvSourceOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                //if (MPCF.CheckValue(cdvWorkLine, false) == false)
                //{
                //    return;
                //}

                // In Node Setup
                TRSNode in_node = new TRSNode("CUS_View_Order_List_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", "20010101010101");
                in_node.AddString("TO_DATE", "99910101010101");
                //in_node.AddString("WORK_LINE", cdvWorkLine.Text);
                //in_node.AddChar("ACTIVE_ORD_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", "");
                in_node.AddString("MAT_TYPE", "");
                in_node.AddString("MAT_GRP", "");

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvSourceOrderID.Text = cdvSourceOrderID.Show(cdvSourceOrderID, "View Work Order", "CUS", "CUS_View_Order_List", in_node, "ORDER_LIST", display, header, "Order ID");

                if (ViewSourceOrderList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvTargetOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                //if (MPCF.CheckValue(cdvWorkLine, false) == false)
                //{
                //    return;
                //}

                // In Node Setup
                TRSNode in_node = new TRSNode("CUS_View_Order_List_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", "20010101010101");
                in_node.AddString("TO_DATE", "99910101010101");
                //in_node.AddString("WORK_LINE", cdvWorkLine.Text);
                //in_node.AddChar("ACTIVE_ORD_FLAG", 'Y');
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", "");
                in_node.AddString("MAT_TYPE", "");
                in_node.AddString("MAT_GRP", "");

                // Display and Header Text Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };
                string[] header = new string[] { "Order ID", "Order Desc" };

                // Show CodeView and Get Return
                cdvTargetOrderID.Text = cdvTargetOrderID.Show(cdvTargetOrderID, "View Work Order", "CUS", "CUS_View_Order_List", in_node, "ORDER_LIST", display, header, "Order ID");

                if (ViewTargetOrderList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdSourceOrderList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                string sOrderID;
                int iRow = spdSourceOrderList.ActiveSheet.ActiveRowIndex;
                if (iRow < 0) return;

                sOrderID = MPCF.Trim(spdSourceOrderList.ActiveSheet.Cells[iRow, 0].Value);
                if (sOrderID == "") return;

                if (ViewLotList(sOrderID) == false) return;

                cdvSourceOrderID.Text = sOrderID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdTargetOrderList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                string sOrderID;
                int iRow = spdTargetOrderList.ActiveSheet.ActiveRowIndex;
                if (iRow < 0) return;

                sOrderID = MPCF.Trim(spdTargetOrderList.ActiveSheet.Cells[iRow, 0].Value);
                if (sOrderID == "") return;

                cdvTargetOrderID.Text = sOrderID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
