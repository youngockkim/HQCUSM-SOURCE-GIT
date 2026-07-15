using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.UI;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.MESCore.Controls
{
    public partial class udcFlexibleConditionForLot : UserControl
    {
        public udcFlexibleConditionForLot()
        {
            InitializeComponent();

            cboLogical.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
        }

        #region " Constant Definition "

        private const string LOT_ID = "LOT_ID";
        private const string LOT_DESC = "LOT_DESC";
        private const string FACTORY = "FACTORY";
        private const string MAT_ID = "MAT_ID";
        private const string MAT_VER = "MAT_VER";
        private const string FLOW = "FLOW";
        private const string FLOW_SEQ_NUM = "FLOW_SEQ_NUM";
        private const string OPER = "OPER";
        private const string QTY_1 = "QTY_1";
        private const string QTY_2 = "QTY_2";
        private const string QTY_3 = "QTY_3";
        private const string CRR_ID = "CRR_ID";
        private const string LOT_TYPE = "LOT_TYPE";
        private const string OWNER_CODE = "OWNER_CODE";
        private const string CREATE_CODE = "CREATE_CODE";
        private const string LOT_PRIORITY = "LOT_PRIORITY";
        private const string LOT_STATUS = "LOT_STATUS";
        private const string HOLD_FLAG = "HOLD_FLAG";
        private const string HOLD_CODE = "HOLD_CODE";
        private const string HOLD_PASSWORD = "HOLD_PASSWORD";
        private const string HOLD_PRV_GRP_ID = "HOLD_PRV_GRP_ID";
        private const string OPER_IN_QTY_1 = "OPER_IN_QTY_1";
        private const string OPER_IN_QTY_2 = "OPER_IN_QTY_2";
        private const string OPER_IN_QTY_3 = "OPER_IN_QTY_3";
        private const string CREATE_QTY_1 = "CREATE_QTY_1";
        private const string CREATE_QTY_2 = "CREATE_QTY_2";
        private const string CREATE_QTY_3 = "CREATE_QTY_3";
        private const string START_QTY_1 = "START_QTY_1";
        private const string START_QTY_2 = "START_QTY_2";
        private const string START_QTY_3 = "START_QTY_3";
        private const string INV_FLAG = "INV_FLAG";
        private const string TRANSIT_FLAG = "TRANSIT_FLAG";
        private const string UNIT_EXIST_FLAG = "UNIT_EXIST_FLAG";
        private const string INV_UNIT = "INV_UNIT";
        private const string RWK_FLAG = "RWK_FLAG";
        private const string RWK_CODE = "RWK_CODE";
        private const string RWK_COUNT = "RWK_COUNT";
        private const string RWK_RET_FLOW = "RWK_RET_FLOW";
        private const string RWK_RET_FLOW_SEQ_NUM = "RWK_RET_FLOW_SEQ_NUM";
        private const string RWK_RET_OPER = "RWK_RET_OPER";
        private const string RWK_END_FLOW = "RWK_END_FLOW";
        private const string RWK_END_FLOW_SEQ_NUM = "RWK_END_FLOW_SEQ_NUM";
        private const string RWK_END_OPER = "RWK_END_OPER";
        private const string RWK_RET_CLEAR_FLAG = "RWK_RET_CLEAR_FLAG";
        private const string RWK_TIME = "RWK_TIME";
        private const string NSTD_FLAG = "NSTD_FLAG";
        private const string NSTD_RET_FLOW = "NSTD_RET_FLOW";
        private const string NSTD_RET_FLOW_SEQ_NUM = "NSTD_RET_FLOW_SEQ_NUM";
        private const string NSTD_RET_OPER = "NSTD_RET_OPER";
        private const string NSTD_TIME = "NSTD_TIME";
        private const string REP_FLAG = "REP_FLAG";
        private const string REP_RET_OPER = "REP_RET_OPER";
        private const string START_FLAG = "START_FLAG";
        private const string START_TIME = "START_TIME";
        private const string START_RES_ID = "START_RES_ID";
        private const string END_FLAG = "END_FLAG";
        private const string END_TIME = "END_TIME";
        private const string END_RES_ID = "END_RES_ID";
        private const string SAMPLE_FLAG = "SAMPLE_FLAG";
        private const string SAMPLE_WAIT_FLAG = "SAMPLE_WAIT_FLAG";
        private const string SAMPLE_RESULT = "SAMPLE_RESULT";
        private const string FROM_TO_FLAG = "FROM_TO_FLAG";
        private const string FROM_TO_LOT_ID = "FROM_TO_LOT_ID";
        private const string SHIP_CODE = "SHIP_CODE";
        private const string SHIP_TIME = "SHIP_TIME";
        private const string ORG_DUE_TIME = "ORG_DUE_TIME";
        private const string SCH_DUE_TIME = "SCH_DUE_TIME";
        private const string CREATE_TIME = "CREATE_TIME";
        private const string FAC_IN_TIME = "FAC_IN_TIME";
        private const string FLOW_IN_TIME = "FLOW_IN_TIME";
        private const string OPER_IN_TIME = "OPER_IN_TIME";
        private const string RESERVE_RES_ID = "RESERVE_RES_ID";
        private const string BATCH_ID = "BATCH_ID";
        private const string BATCH_SEQ = "BATCH_SEQ";
        private const string ORDER_ID = "ORDER_ID";
        private const string ADD_ORDER_ID_1 = "ADD_ORDER_ID_1";
        private const string ADD_ORDER_ID_2 = "ADD_ORDER_ID_2";
        private const string ADD_ORDER_ID_3 = "ADD_ORDER_ID_3";
        private const string LOT_LOCATION = "LOT_LOCATION";
        private const string LOT_CMF_1 = "LOT_CMF_1";
        private const string LOT_CMF_2 = "LOT_CMF_2";
        private const string LOT_CMF_3 = "LOT_CMF_3";
        private const string LOT_CMF_4 = "LOT_CMF_4";
        private const string LOT_CMF_5 = "LOT_CMF_5";
        private const string LOT_CMF_6 = "LOT_CMF_6";
        private const string LOT_CMF_7 = "LOT_CMF_7";
        private const string LOT_CMF_8 = "LOT_CMF_8";
        private const string LOT_CMF_9 = "LOT_CMF_9";
        private const string LOT_CMF_10 = "LOT_CMF_10";
        private const string LOT_CMF_11 = "LOT_CMF_11";
        private const string LOT_CMF_12 = "LOT_CMF_12";
        private const string LOT_CMF_13 = "LOT_CMF_13";
        private const string LOT_CMF_14 = "LOT_CMF_14";
        private const string LOT_CMF_15 = "LOT_CMF_15";
        private const string LOT_CMF_16 = "LOT_CMF_16";
        private const string LOT_CMF_17 = "LOT_CMF_17";
        private const string LOT_CMF_18 = "LOT_CMF_18";
        private const string LOT_CMF_19 = "LOT_CMF_19";
        private const string LOT_CMF_20 = "LOT_CMF_20";
        private const string LOT_DEL_FLAG = "LOT_DEL_FLAG";
        private const string LOT_DEL_CODE = "LOT_DEL_CODE";
        private const string LOT_DEL_TIME = "LOT_DEL_TIME";
        private const string BOM_SET_ID = "BOM_SET_ID";
        private const string BOM_SET_VERSION = "BOM_SET_VERSION";
        private const string BOM_ACTIVE_HIST_SEQ = "BOM_ACTIVE_HIST_SEQ";
        private const string BOM_HIST_SEQ = "BOM_HIST_SEQ";
        private const string LAST_TRAN_CODE = "LAST_TRAN_CODE";
        private const string LAST_TRAN_TIME = "LAST_TRAN_TIME";
        private const string LAST_COMMENT = "LAST_COMMENT";
        private const string LAST_ACTIVE_HIST_SEQ = "LAST_ACTIVE_HIST_SEQ";
        private const string LAST_HIST_SEQ = "LAST_HIST_SEQ";
        private const string CRITICAL_RES_ID = "CRITICAL_RES_ID";
        private const string CRITICAL_RES_GROUP_ID = "CRITICAL_RES_GROUP_ID";
        private const string SAVE_RES_ID_1 = "SAVE_RES_ID_1";
        private const string SAVE_RES_ID_2 = "SAVE_RES_ID_2";
        private const string SUBRES_ID = "SUBRES_ID";
        private const string LOT_GROUP_ID_1 = "LOT_GROUP_ID_1";
        private const string LOT_GROUP_ID_2 = "LOT_GROUP_ID_2";
        private const string LOT_GROUP_ID_3 = "LOT_GROUP_ID_3";
        private const string RESV_FIELD_1 = "RESV_FIELD_1";
        private const string RESV_FIELD_2 = "RESV_FIELD_2";
        private const string RESV_FIELD_3 = "RESV_FIELD_3";
        private const string RESV_FIELD_4 = "RESV_FIELD_4";
        private const string RESV_FIELD_5 = "RESV_FIELD_5";
        private const string RESV_FLAG_1 = "RESV_FLAG_1";
        private const string RESV_FLAG_2 = "RESV_FLAG_2";
        private const string RESV_FLAG_3 = "RESV_FLAG_3";
        private const string RESV_FLAG_4 = "RESV_FLAG_4";
        private const string RESV_FLAG_5 = "RESV_FLAG_5";

        #endregion

        #region "Properties"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string QueryText
        {
            get
            {
                return txtQuery.Text;
            }
            set
            {
                txtQuery.Text = value;
            }
        }

        #endregion

        public bool GetConditionControl(string strColumn)
        {
            switch (MPCF.Trim(strColumn))
            {
                case "LOT_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "LOT_DESC":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 50;
                    break;
                case "FACTORY": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "MAT_ID": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "MAT_VER": 
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "FLOW": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "FLOW_SEQ_NUM":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "OPER":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "QTY_1":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "QTY_2": 
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "QTY_3": 
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "CRR_ID": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "LOT_TYPE": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 1;
                    break;
                case "OWNER_CODE": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 10;
                    break;
                case "CREATE_CODE": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 10;
                    break;
                case "LOT_PRIORITY":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "LOT_STATUS":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "HOLD_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "HOLD_CODE":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 10;
                    break;
                case "HOLD_PASSWORD":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "HOLD_PRV_GRP_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "OPER_IN_QTY_1":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "OPER_IN_QTY_2":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "OPER_IN_QTY_3":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "CREATE_QTY_1":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "CREATE_QTY_2":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "CREATE_QTY_3":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "START_QTY_1":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "START_QTY_2":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "START_QTY_3":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "INV_FLAG": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "TRANSIT_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "UNIT_EXIST_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "INV_UNIT":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "RWK_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RWK_CODE":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 10;
                    break;
                case "RWK_COUNT":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "RWK_RET_FLOW":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "RWK_RET_FLOW_SEQ_NUM":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "RWK_RET_OPER":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "RWK_END_FLOW":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "RWK_END_FLOW_SEQ_NUM":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "RWK_END_OPER":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "RWK_RET_CLEAR_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RWK_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "NSTD_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "NSTD_RET_FLOW":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "NSTD_RET_FLOW_SEQ_NUM":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 6;
                    break;
                case "NSTD_RET_OPER":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "NSTD_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "REP_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "REP_RET_OPER":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "START_FLAG": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "START_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "START_RES_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "END_FLAG": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "END_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "END_RES_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "SAMPLE_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "SAMPLE_WAIT_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "SAMPLE_RESULT":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "FROM_TO_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "FROM_TO_LOT_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "SHIP_CODE":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = true;
                    cdvValue.MaxLength = 10;
                    break;
                case "SHIP_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "ORG_DUE_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "SCH_DUE_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "CREATE_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "FAC_IN_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "FLOW_IN_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "OPER_IN_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "RESERVE_RES_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "BATCH_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "BATCH_SEQ":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 3;
                    break;
                case "ORDER_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 15;
                    break;
                case "ADD_ORDER_ID_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 15;
                    break;
                case "ADD_ORDER_ID_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 15;
                    break;
                case "ADD_ORDER_ID_3":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 15;
                    break;
                case "LOT_LOCATION":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "LOT_CMF_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_3":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_4":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_5":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_6":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_7":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_8":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_9":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_10":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_11":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_12":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_13":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_14":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_15":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_16":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_17":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_18":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_19":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_CMF_20":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "LOT_DEL_FLAG":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "LOT_DEL_CODE":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "LOT_DEL_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "BOM_SET_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "BOM_SET_VERSION":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 3;
                    break;
                case "BOM_ACTIVE_HIST_SEQ":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "BOM_HIST_SEQ":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "LAST_TRAN_CODE":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 12;
                    break;
                case "LAST_TRAN_TIME":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 14;
                    break;
                case "LAST_COMMENT":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 400;
                    break;
                case "LAST_ACTIVE_HIST_SEQ":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "LAST_HIST_SEQ":
                    cdvValue.Tag = "NUMBER";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 10;
                    break;
                case "CRITICAL_RES_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "CRITICAL_RES_GROUP_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "SAVE_RES_ID_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "SAVE_RES_ID_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "SUBRES_ID":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 20;
                    break;
                case "LOT_GROUP_ID_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "LOT_GROUP_ID_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "LOT_GROUP_ID_3":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 25;
                    break;
                case "RESV_FIELD_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "RESV_FIELD_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "RESV_FIELD_3":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "RESV_FIELD_4":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "RESV_FIELD_5":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 30;
                    break;
                case "RESV_FLAG_1":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RESV_FLAG_2":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RESV_FLAG_3":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RESV_FLAG_4": 
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;
                case "RESV_FLAG_5":
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1;
                    break;

                default :
                    cdvValue.Tag = "STRING";
                    cdvValue.VisibleButton = false;
                    cdvValue.MaxLength = 1000;
                    break;
            }

            return true;
        }

        // ViewLotConidtionList()
        //       - View Lot Condition list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - 
        public bool ViewLotConidtionList(ListView lisListView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(lisListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = 'MWIPLOTSTS' " +
                                     "       ORDER BY COLUMN_NAME");

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(lisListView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool GetCondtionList()
        {
            BASLIST.ViewGCMDataList(cdvCondition.GetListView, '1', "LOT_CONDITION");

            return true;
        }

        private void cdvCondition_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cboOperator.SelectedIndex = 0;
            cdvValue.Text = "";

            if (string.IsNullOrEmpty(e.Text) == true) return;
            GetConditionControl(e.Text);
        }

        private void cdvValue_ButtonPress(object sender, EventArgs e)
        {
            string strTableName = "";

            if (string.IsNullOrEmpty(MPCF.Trim(cdvCondition.Text)) == false)
            {
                switch (MPCF.Trim(cdvCondition.Text))
                {
                    case "LOT_TYPE":
                        strTableName = "LOT_TYPE";
                        break;
                    case "OWNER_CODE":
                        strTableName = "OWNER_CODE";
                        break;
                    case "CREATE_CODE":
                        strTableName = "CREATE_CODE";
                        break;
                    case "HOLD_CODE":
                        strTableName = "HOLD_CODE";
                        break;
                    case "RWK_CODE":
                        strTableName = "REWORK_CODE";
                        break;
                    case "SHIP_CODE":
                        strTableName = "SHIP_CODE";
                        break;
                }

                BASLIST.ViewGCMDataList(cdvValue.GetListView, '1', strTableName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strValue = "";

            if (cdvValue.Text != "")
            {
                if (cdvValue.Tag != null)
                {
                    if (cdvValue.Tag.ToString() == "STRING")
                    {
                        strValue = " '" + cdvValue.Text + "'";
                        
                    }
                    else if (cdvValue.Tag.ToString() == "NUMBER")
                    {
                        strValue = " " + cdvValue.Text;
                    }

                    if (MPCF.Trim(txtQuery.Text) == "")
                    {
                        txtQuery.Text = " WHERE " + cdvCondition.Text + " " + MPCF.SubtractString(cboOperator.Text, " ", false, false) + strValue;
                    }
                    else
                    {
                        txtQuery.Text = txtQuery.Text + " " + cboLogical.Text + " " + cdvCondition.Text + " " + MPCF.SubtractString(cboOperator.Text, " ", false, false) + strValue;
                    }
                }
            }
        }

        private void udcFlexibleConditionForLot_Load(object sender, EventArgs e)
        {
            cdvCondition.Init();
            MPCF.InitListView(cdvCondition.GetListView);
            cdvCondition.Columns.Add("Condition", 150, HorizontalAlignment.Left);
            //cdvCondition.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCondition.SelectedSubItemIndex = 0;
            cdvCondition.DisplaySubItemIndex = 0;
            cdvCondition.GetDisplayTextBox.ReadOnly = true;

            cdvValue.Init();
            MPCF.InitListView(cdvValue.GetListView);
            cdvValue.Columns.Add("Value", 150, HorizontalAlignment.Left);
            cdvValue.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvValue.SelectedSubItemIndex = 0;
            cdvValue.DisplaySubItemIndex = 0;

            cboLogical.SelectedIndex = 0;
            cboOperator.SelectedIndex = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuery.Text = "";
        }

        private void cdvValue_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (cdvValue.Tag != null)
            {
                if (cdvValue.Tag.ToString() == "STRING")
                {
                }
                else if (cdvValue.Tag.ToString() == "NUMBER")
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
                        {
                            if (cdvTemp.Text.IndexOf((char)46) > -1)
                            {
                                e.Handled = true;
                            }

                            if (!(e.KeyChar == (char)46))
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar == (char)43 || e.KeyChar == (char)45)
                            {
                                if (MPCF.Trim(cdvTemp.Text) != "")
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cdvCondition_ButtonPress(object sender, EventArgs e)
        {
            if (cdvCondition.Items.Count > 0) return;

            cdvCondition.Init();
            cdvCondition.Columns.Add("Column Name", 50, HorizontalAlignment.Left);
            ViewLotConidtionList(cdvCondition.GetListView);
            cdvCondition.SelectedSubItemIndex = 0;
        }
    }
}
