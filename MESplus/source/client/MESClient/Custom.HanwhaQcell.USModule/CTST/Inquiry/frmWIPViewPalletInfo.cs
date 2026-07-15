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
using Infragistics.Win.UltraWinGrid;
using Miracom.CliFrx;
using Miracom.MESCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmWIPViewPalletInfo : SOIBaseForm10
    {

        delegate void SetMessageDelegate(TRSNode node);
        private SetMessageDelegate _SetMessageDelegate;

        #region "Event Definition"
#if _ZPL
        //------------------------------------------
        private Rs232 m_CommPort = new Rs232();
        //------------------------------------------
#endif
        #endregion

        #region Property

        #endregion

        #region " Constant Definition "

        /// <summary>
        /// spdBoxList
        /// </summary>
        private const int SEQ_P_PALLET_ID = 0;
        private const int SEQ_P_LABEL_TYPE = 1;
        private const int SEQ_P_LABEL_TYPE_DESC = 2;
        private const int SEQ_P_LABEL_GRP = 3;
        private const int SEQ_P_LABEL_GRP_DESC = 4;
        private const int SEQ_P_LABEL_CODE = 5;
        private const int SEQ_P_LABEL_CODE_DESC = 6;
        private const int SEQ_P_LABEL_FORM = 7;
        private const int SEQ_P_LABEL_FORM_DESC = 8;
        private const int SEQ_P_LABEL_ORDER_ID = 9;
        private const int SEQ_P_LABEL_PACK_QTY = 10;
        private const int SEQ_P_LABEL_PACKED_QTY = 11;
        private const int SEQ_P_LABEL_STATUS = 12;
        private const int SEQ_P_USER_ID = 13;
        private const int SEQ_P_USER_ID_DESC = 14;
        private const int SEQ_P_CREATE_TIME = 15;
        private const int SEQ_P_UPDATE_USER_ID = 16;
        private const int SEQ_P_UPDATE_USER_ID_DESC = 17;
        private const int SEQ_P_UPDATE_TIME = 18;


        /// <summary>
        /// spdLotList
        /// </summary>
        private const int SEQ_LOT1_SEL = 0;
        private const int SEQ_LOT1_MOLDING_LOT_ID = 1;
        private const int SEQ_LOT1_MIXER_LOT_ID = 2;
        private const int SEQ_LOT1_OPER = 3;
        private const int SEQ_LOT1_OPER_DESC = 4;
        private const int SEQ_LOT1_PROD_QTY = 5;
        private const int SEQ_LOT1_MAT_ID = 6;
        private const int SEQ_LOT1_MAT_DESC = 7;
        private const int SEQ_LOT1_WEIGHT = 8;
        private const int SEQ_LOT1_STATUS = 9;
        private const int SEQ_LOT1_HOLD_FLAG = 10;
        private const int SEQ_LOT1_SHIFT = 11;
        private const int SEQ_LOT1_SHIFT_DESC = 12;
        private const int SEQ_LOT1_WORK_DATE = 13;
        private const int SEQ_LOT1_LBL_FORM = 14;
        private const int SEQ_LOT1_ORDER_ID = 15;

        #endregion

        #region " Variable Definition "

        #endregion

        #region " H101 Delegate Function"

        // SetMessageEvent()
        //       - Set Message Event
        // Return Value
        //       - 
        // Arguments
        //        -  ByVal in_node As TRSNode : in node
        //
        public void SetMessageEvent(TRSNode in_node)
        {
            try
            {
                IAsyncResult r = BeginInvoke(_SetMessageDelegate, new object[] { in_node });
                EndInvoke(r);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        // SetMessage()
        //       - Set Message
        // Return Value
        //       - 
        // Arguments
        //        -  ByVal in_node As TRSNode : node
        //
        private void SetMessage(TRSNode node)
        {
            try
            {

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }
        #endregion

        #region Constructor

        public frmWIPViewPalletInfo()
        {
            InitializeComponent();
            _SetMessageDelegate = new SetMessageDelegate(SetMessage);
        }

        #endregion

        #region Function

        // Load 초기화
        private void InitLoad()
        {

            try
            {
                string sWorkDate = HQCF.GetWorkDate();
                //new System.DateTime(MPCF.ToInt(sTmp.Substring(0, 4)), MPCF.ToInt(sTmp.Substring(4, 2)), MPCF.ToInt(sTmp.Substring(6, 2)), 0, 0, 0, 0);
                dtpFrom.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);
                dtpTo.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);
                /// Control 초기화
                cdvlblCode.CodeHeight = label3.Height;
                cdvlblGrp.CodeHeight = label3.Height;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }


        //BOX List Spread 데이터 조회 후, 각 셀의 타입을 변경. 
        private void SetBoxCellType()
        {
            try
            {
                HQCF.SetCellType(spdPalletList, SEQ_P_PALLET_ID, HQCF.SpreadCellType.TextCellType, 150, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_TYPE, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_TYPE_DESC, HQCF.SpreadCellType.TextCellType, 100, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_GRP, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_GRP_DESC, HQCF.SpreadCellType.TextCellType, 100, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_CODE, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_CODE_DESC, HQCF.SpreadCellType.TextCellType, 100, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_FORM, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_FORM_DESC, HQCF.SpreadCellType.TextCellType, 100, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_ORDER_ID, HQCF.SpreadCellType.TextCellType, 100, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_PACK_QTY, HQCF.SpreadCellType.TextCellType, 70, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_PACKED_QTY, HQCF.SpreadCellType.TextCellType, 70, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                HQCF.SetCellType(spdPalletList, SEQ_P_LABEL_STATUS, HQCF.SpreadCellType.TextCellType, 50, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdPalletList, SEQ_P_USER_ID, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_USER_ID_DESC, HQCF.SpreadCellType.TextCellType, 80, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdPalletList, SEQ_P_CREATE_TIME, HQCF.SpreadCellType.TextCellType, 120, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdPalletList, SEQ_P_UPDATE_USER_ID, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdPalletList, SEQ_P_UPDATE_USER_ID_DESC, HQCF.SpreadCellType.TextCellType, 80, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdPalletList, SEQ_P_UPDATE_TIME, HQCF.SpreadCellType.TextCellType, 120, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        //BOX List Spread 데이터 조회 후, 각 셀의 타입을 변경. 
        private void SetLotCellType()
        {
            try
            {
                HQCF.SetCellType(spdLotList, SEQ_LOT1_SEL, HQCF.SpreadCellType.CheckBoxCellType, 50, false, false, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_MOLDING_LOT_ID, HQCF.SpreadCellType.TextCellType, 150, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_MIXER_LOT_ID, HQCF.SpreadCellType.TextCellType, 150, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_OPER, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_OPER_DESC, HQCF.SpreadCellType.TextCellType, 55, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_PROD_QTY, HQCF.SpreadCellType.TextCellType, 55, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Right);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_MAT_ID, HQCF.SpreadCellType.TextCellType, 50, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_MAT_DESC, HQCF.SpreadCellType.TextCellType, 0, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_WEIGHT, HQCF.SpreadCellType.TextCellType, 100, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_STATUS, HQCF.SpreadCellType.TextCellType, 100, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_HOLD_FLAG, HQCF.SpreadCellType.TextCellType, 100, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_SHIFT, HQCF.SpreadCellType.TextCellType, 60, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_SHIFT_DESC, HQCF.SpreadCellType.TextCellType, 80, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_WORK_DATE, HQCF.SpreadCellType.TextCellType, 120, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Center);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_LBL_FORM, HQCF.SpreadCellType.TextCellType, 0, false, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);
                HQCF.SetCellType(spdLotList, SEQ_LOT1_ORDER_ID, HQCF.SpreadCellType.TextCellType, 150, true, true, FarPoint.Win.Spread.CellHorizontalAlignment.Left);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }


        // <summary>
        /// CheckCondition
        /// </summary>
        /// <param name="FuncName"></param>
        /// <returns></returns>
        private bool CheckCondition(string FuncName)
        {

            try
            {

                switch (MPCF.Trim(FuncName))
                {

                    case "CREATE":


                        break;

                    case "UPDATE":


                        break;


                    case "DELETE":


                        break;


                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }

            return true;
        }


        //ViewPalletInfoList
        // ViewPalletInfoList()
        //       PALLET View
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private bool ViewPalletInfoList()
        {
            MPCF.ClearList(spdPalletList);

            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] Condition = new TPDR.DirectViewCond[5];

            try
            {
                DisplayMessage("", MSSAG_LEVEL.INFO);
                FarPoint.Win.Spread.SheetView with_1 = spdPalletList.ActiveSheet;
                int irow = with_1.ActiveRowIndex;

                Condition[0].sCondtion_ID = "FACTORY";
                Condition[0].sCondition_Value = MPGV.gsFactory;
                Condition[1].sCondtion_ID = "FROM_DATE";
                Condition[1].sCondition_Value = dtpFrom.GetValueAsString(8);
                Condition[2].sCondtion_ID = "TO_DATE";
                Condition[2].sCondition_Value = dtpTo.GetValueAsString(8);
                Condition[3].sCondtion_ID = "LABEL_GRP";
                Condition[3].sCondition_Value = MPCF.Trim(cdvlblGrp.Text);
                Condition[4].sCondtion_ID = "LABEL_CODE";
                Condition[4].sCondition_Value = MPCF.Trim(cdvlblCode.Text);

                if (TPDR.DirectViewOne(null, "WIP7004-01", ref dt, false, false, Condition, false, false) == false)
                {
                    if (dt != null) { dt.Dispose(); }

                    if (dt.Rows.Count == 0)
                    {
                        dt.Dispose();
                        //DisplayMessage(MPCF.GetMessage(244), MSSAG_LEVEL.ERROR);
                    }
                    return false;
                }

                if (dt == null || dt.Rows.Count < 1) return false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LastRow;

                    LastRow = with_1.RowCount;
                    with_1.RowCount++;

                    with_1.SetValue(LastRow, SEQ_P_PALLET_ID, MPCF.Trim(dt.Rows[i]["LABEL_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_TYPE, MPCF.Trim(dt.Rows[i]["LABEL_TYPE"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_TYPE_DESC, MPCF.Trim(dt.Rows[i]["TYPE_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_GRP, MPCF.Trim(dt.Rows[i]["LABEL_GRP"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_GRP_DESC, MPCF.Trim(dt.Rows[i]["GRP_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_CODE, MPCF.Trim(dt.Rows[i]["LABEL_CODE"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_CODE_DESC, MPCF.Trim(dt.Rows[i]["CODE_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_FORM, MPCF.Trim(dt.Rows[i]["LABEL_FORM"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_FORM_DESC, MPCF.Trim(dt.Rows[i]["FORM_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_ORDER_ID, MPCF.Trim(dt.Rows[i]["ORDER_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_PACK_QTY, MPCF.Trim(dt.Rows[i]["PACK_QTY"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_LABEL_PACKED_QTY, MPCF.Trim(dt.Rows[i]["QTY"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_USER_ID, MPCF.Trim(dt.Rows[i]["CREATE_USER_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_USER_ID_DESC, MPCF.Trim(dt.Rows[i]["USER_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_CREATE_TIME, MPCF.Trim(dt.Rows[i]["CREATE_TIME"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_UPDATE_USER_ID, MPCF.Trim(dt.Rows[i]["UPDATE_USER_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_UPDATE_USER_ID_DESC, MPCF.Trim(dt.Rows[i]["UPDATE_USER_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_P_UPDATE_TIME, MPCF.Trim(dt.Rows[i]["UPDATE_TIME"].ToString()));

                    if (MPCF.Trim(dt.Rows[i]["LABEL_STATUS"].ToString()) == "P")
                    {
                        with_1.SetValue(LastRow, SEQ_P_LABEL_STATUS, "사용중");
                        //with_1.Rows[LastRow].BackColor = Color.LightGreen;
                    }
                    else if (MPCF.Trim(dt.Rows[i]["LABEL_STATUS"].ToString()) == "A")
                    {
                        with_1.SetValue(LastRow, SEQ_P_LABEL_STATUS, "사용가능");
                        //with_1.Rows[LastRow].BackColor = Color.LightSkyBlue;
                    }
                    else if (MPCF.Trim(dt.Rows[i]["LABEL_STATUS"].ToString()) == "C")
                    {
                        with_1.SetValue(LastRow, SEQ_P_LABEL_STATUS, "사용불가");
                        //with_1.Rows[LastRow].BackColor = Color.OrangeRed;
                    }
                }

                MPCF.FitColumnHeader(spdPalletList);

                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        //ViewLotListInfo
        // ViewLotListInfo()
        //       LOT View
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private bool ViewLotListInfo(string sPalletId)
        {
            MPCF.ClearList(spdLotList);

            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] Condition = new TPDR.DirectViewCond[2];

            try
            {
                DisplayMessage("", MSSAG_LEVEL.INFO);
                FarPoint.Win.Spread.SheetView with_1 = spdLotList.ActiveSheet;
                int irow = with_1.ActiveRowIndex;

                Condition[0].sCondtion_ID = "FACTORY";
                Condition[0].sCondition_Value = MPGV.gsFactory;

                Condition[1].sCondtion_ID = "PALLET_ID";
                Condition[1].sCondition_Value = MPCF.Trim(sPalletId);


                if (TPDR.DirectViewOne(null, "WIP7004-02", ref dt, false, false, Condition, false, false) == false)
                {
                    if (dt != null) { dt.Dispose(); }

                    if (dt.Rows.Count == 0)
                    {
                        dt.Dispose();
                        //DisplayMessage(MPCF.GetMessage(244), MSSAG_LEVEL.ERROR);
                    }
                    return false;
                }

                if (dt == null || dt.Rows.Count < 1) return false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LastRow;

                    LastRow = with_1.RowCount;
                    with_1.RowCount++;

                    with_1.SetValue(LastRow, SEQ_LOT1_SEL, "False");
                    with_1.SetValue(LastRow, SEQ_LOT1_MOLDING_LOT_ID, MPCF.Trim(dt.Rows[i]["LOT_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_MIXER_LOT_ID, MPCF.Trim(dt.Rows[i]["MIX_LOT_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_OPER, MPCF.Trim(dt.Rows[i]["OPER"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_OPER_DESC, MPCF.Trim(dt.Rows[i]["OPER_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_MAT_ID, MPCF.Trim(dt.Rows[i]["MAT_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_MAT_DESC, MPCF.Trim(dt.Rows[i]["MAT_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_PROD_QTY, MPCF.Trim(dt.Rows[i]["QTY_1"].ToString() + " " + dt.Rows[i]["UNIT_1"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_MAT_ID, MPCF.Trim(dt.Rows[i]["MAT_ID"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_MAT_DESC, MPCF.Trim(dt.Rows[i]["MAT_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_WORK_DATE, MPCF.Trim(dt.Rows[i]["WORK_DATE"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_SHIFT, MPCF.Trim(dt.Rows[i]["SHIFT"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_SHIFT_DESC, MPCF.Trim(dt.Rows[i]["SHIFT_DESC"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_STATUS, MPCF.Trim(dt.Rows[i]["STATUS"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_HOLD_FLAG, MPCF.Trim(dt.Rows[i]["HOLD_FLAG"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_LBL_FORM, MPCF.Trim(dt.Rows[i]["LBL_FORM"].ToString()));
                    with_1.SetValue(LastRow, SEQ_LOT1_ORDER_ID, MPCF.Trim(dt.Rows[i]["ORDER_ID"].ToString()));

                    if (MPCF.Trim(dt.Rows[i]["STATUS"].ToString()) == "W")
                    {
                        with_1.SetValue(LastRow, SEQ_LOT1_STATUS, "대기");
                        with_1.Rows[LastRow].BackColor = Color.Transparent;
                    }
                    else
                    {
                        with_1.SetValue(LastRow, SEQ_LOT1_STATUS, "작업중");
                        with_1.Rows[LastRow].BackColor = Color.LightSkyBlue;
                    }
                }

                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        #endregion

        #region Event Handler


        private void frmWIPViewPalletInfo_Load(object sender, EventArgs e)
        {
            MPOF.ConvertCaption(this);
            MPOF.FieldClear(this);
            MPCF.ClearList(spdPalletList);
            MPCF.ClearList(spdLotList);
            //InitLoad();
            //SetBoxCellType();
            //SetLotCellType();
            /*
            string sWorkDate = HQCF.GetWorkDate();
            dtpFrom.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);
            dtpTo.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);

            DisplayMessage("", MSSAG_LEVEL.INFO);

            // 제품군 DESC
            txtMatType.Text = MPCF.Trim(MOGV.gsMatType);
            */
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewPalletInfoList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }

        private void cdvlblGrp_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "KEY_1", "DATA_1" };

                //Show CodeView and Get Return
                cdvlblGrp.Text = cdvlblGrp.Show(cdvlblGrp, "KEY_1", "CMN_View_GCM_Data_11", new string[] { "CINV_LBL_GRP", "PACK" }, display, header, "KEY_1");

                cdvlblCode.Text = "";
                cdvlblCode.Description = "";
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void cdvlblCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "KEY_1", "DATA_1" };

                //Show CodeView and Get Return
                cdvlblCode.Text = cdvlblCode.Show(cdvlblCode, "USER ID", "CMN_View_GCM_Data_11", new string[] { "CINV_LBL_CODE", MPCF.Trim(cdvlblGrp.Text) }, display, header, "USER_ID");
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void spdPalletList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdPalletList.ActiveSheet;
                for (int i = 0; i < spdPalletList.ActiveSheet.RowCount; i++)
                {
                    spdPalletList.ActiveSheet.Rows[i].BackColor = Color.Transparent;
                }

                spdPalletList.ActiveSheet.Rows[e.Row].BackColor = Color.LightSkyBlue;

                ViewLotListInfo(MPCF.Trim(with_1.Cells[e.Row, SEQ_P_PALLET_ID].Text));

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }
        }

        #endregion
    }
}
