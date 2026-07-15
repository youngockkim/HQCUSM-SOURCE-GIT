using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOI.Solar
{
    public sealed class CSGC
    {
        public const string MP_TIV_INV_OPR = "W110";
        public const string MP_TIV_INV_WIPOPR = "W210";

        public const string SOL_OPER_JIG      = "1230";
        public const string SOL_OPER_TABBING  = "1310";
        public const string SOL_OPER_EPE_FILM = "1530";
        public const string SOL_OPER_EL       = "2610";

        public const string MP_MAT_TYPE_FG = "FG";
        public const string MP_MAT_TYPE_HALF = "HALF";
        public const string MP_MAT_TYPE_RAW = "RAW";

        public const string MP_CRR_GRP_JB = "JB";
        public const string MP_CRR_GRP_JG = "JG";
        public const string MP_CRR_GRP_MZ = "MZ";
        public const string MP_CRR_GRP_TR = "TR";

        #region 필요없는 부분 추후 확인


        #region " Attribute "

        public const string ATTR_NAME_TERMINAL_IPADDR = "IP_ADDRESS";
        public const string ATTR_NAME_TERMINAL_OPER = "OPER";
        public const string ATTR_NAME_TERMINAL_RES_LIST = "RES_LIST";
        public const string ATTR_NAME_TERMINAL_WORK_CENTER_LIST = "WORK_CENTER_LIST";

        #endregion

        #region "GROUP / CMF Item"


        #endregion

        #region "GCM Table Name"

        public const int MP_DEFAULT_COUNT_FOR_SLEEP = 5;
        public const int MP_DEFAULT_SLEEP_TIME = 500;

        public const int SPREAD_RAW_HEIGHT_OI = 52;
        // DTR 
        public const string MP_GCM_FTP_INFO = "C@FTP_INFO";
        public const string MP_GCM_JUDGE_IQC = "C@JUDGE_IQC";
        public const string MP_IQC_BASE_LOT_ID = "IQCBASELOT01";
        public const string MP_GCM_DLV_TYPE = "C@DLV_TYPE";
        public const string MP_GCM_OPER_GRP_USER_LIST = "C@OPER_GRP_USER_LIST";
        public const string MP_GCM_SAVE_FLAG = "C@SAVE_FLAG";

        public const string MP_GCM_OPER_WIP = "C@OPER_WIP";
        public const string MP_GCM_OPER_LIST_R = "C@OPER_LIST_R";

        public const string MP_GCM_VIEW_STOCK_INVG = "C@VIEW_STOCK_INVG";

        public const string MP_GCM_OPER_GROUP_USER = "C@OPER_GROUP_USER";
        public const string MP_GCM_STK_INVG_LOC = "C@STK_INVG_LOC";
        public const string MP_GCM_STOCK_INVG_MST = "C@STOCK_INVG_MST";

        public const string MP_GCM_SHIFT = "C@SHIFT";
        public const string MP_GCM_TBL_INV_OPER = "C@INV_OPER";
        //public const string MP_GCM_TBL_INV_OPER_FROM = "C@INV_OPER_FROM";
        //public const string MP_GCM_TBL_INV_OPER_FROM_ONLY = "C@INV_OPER_FROM_ONLY";
        public const string MP_GCM_TBL_INV_OPER_FROM_TO = "C@INV_OPER_FROM_TO";
        //public const string MP_GCM_TBL_INV_OPER_TO = "C@INV_OPER_TO";
        //public const string MP_GCM_TBL_INV_OPER_TO_ONLY = "C@INV_OPER_TO_ONLY";
        public const string MP_GCM_TBL_OPER_RES_LIST = "C@OPER_RES_LIST";
        //public const string MP_GCM_TBL_INV_OPER_FROM_STK = "C@INV_OPER_FROM_STK";
        public const string MP_GCM_TBL_SHIFT = "C@SHIFT";
        public const string MP_GCM_TBL_TERMINAL_INFO = "C@TERMINAL_INFO";
        public const string MP_GCM_PLAN_OPER = "C@PLAN_OPER";
        public const string MP_GCM_IQC_USER_LIST = "C@IQC_USER_LIST";
        public const string MP_GCM_TBL_PRIORITY_LEVEL = "C@PRIORITY_LEVEL";
        public const string MP_GCM_TBL_ORDER_TYPE = "C@ORDER_TYPE";
        public const string MP_GCM_TBL_OPER_GROUP_SHIFT = "C@OPER_GROUP_SHIFT";
        public const string MP_GCM_TBL_WORKING_TYPE = "C@WORKING_TYPE";

        public const string MP_GCM_RES_LIST_BY_WC = "C@RES_LIST_BY_WC";
        public const string MP_GCM_RES_LIST_BY_WC_MAT = "C@RES_LIST_BY_WC_MAT";
        public const string MP_GCM_RES_LIST_PROC = "@RES_LIST_PROC";

        public const string MP_GCM_LOSS_CODE_REQ = "C@LOSS_CODE_REQ";

        public const string MP_GCM_MAT_PALLET_TYPE = "C@MAT_PALLET_TYPE";
        public const string MP_GCM_MAT_FLOW_OPER = "C@MAT_FLOW_OPER";

        public const string MP_GCM_FACTORY_LIST = "C@FACTORY_LIST";
        public const string MP_GCM_RES_POSITION_LIST = "C@RES_POSITION";
        public const string MP_GCM_RES_SETID_TAB_LIST = "C@RES_SETID_TAB";
        public const string MP_GCM_RES_SETID_FRM_LIST = "C@RES_SETID_FRM";


        public const string MP_GCM_MOLD_GROUP = "C@MOLD_GROUP";
        public const string MP_GCM_WORK_CENTER = "C@WORK_CENTER";
        public const string MP_GCM_RES_LIST_FOR_PLAN = "C@RES_LIST_FOR_PLAN";
        public const string MP_GCM_VIEW_LOSS_CODE = "C@VIEW_LOSS_CODE";
        public const string MP_GCM_VIEW_LOSS_CODE_JDG = "C@VIEW_LOSS_CODE_JDG";
        public const string MP_GCM_VIEW_LOSS_CODE_TBL = "C@VIEW_LOSS_CODE_TBL";

        public const string MP_GCM_VIEW_BOM_MAT = "C@VIEW_BOM_MAT";

        public const string MP_TRAN_TYPE_MAT_CHG = "MAT_CHG";

        public const string MP_GCM_VIEW_OPER_QC_TYPE = "C@VIEW_OPER_QC_TYPE";
        public const string MP_GCM_OPER_LIST = "@OPER_LIST";
        public const string MP_GCM_OPER_LIST_SHORT = "@OPER_LIST_SHORT";
        public const string MP_GCM_REQ_LOSS_OPER_LIST = "C@REQ_LOSS_OPER_LIST";
        public const string MP_GCM_LOSS_TYPE = "C@LOSS_TYPE";
        public const string MP_GCM_ROUTE_CONTROL = "C@ROUTE_CONTROL";
        public const string MP_GCM_RES_LIST_BY_MAT = "C@RES_LIST_BY_MAT";

        public const string MP_GCM_LABEL_PRINTER = "C@LABEL_PRINTER";

        public const string MP_GCM_ETC_TRAN_TYPE = "C@ETC_TRAN_TYPE";
        public const string MP_GCM_CREATE_CODE_PROD = "PROD";
        public const string MP_GCM_CREATE_CODE_ETC = "ETC";
        public const string MP_GCM_CREATE_CODE_TLBL = "TLBL";
        public const string MP_GCM_OWNER_CODE_PROD = "PROD";
        public const string MP_GCM_OWNER_CODE_ETC = "ETC";
        public const string MP_GCM_OWNER_CODE_TLBL = "TLBL";
        public const string MP_GCM_TRAN_TYPE_TLBL = "TLBL";


        public const string MP_GCM_QC_FLOW_OPER = "C@QC_FLOW_OPER";
        public const string MP_GCM_PERIOD = "C@PERIOD";
        public const string MP_GCM_DEFAULT_LABEL = "C@DEFAULT_LABEL";

        public const string MP_GCM_LOSS_CODE_OP_DEFAULT = "L99";

        public const string MP_LABEL_LBL_RAW_001 = "LBL_RAW_001";
        public const string MP_LABEL_LBL_PROD_001 = "LBL_PROD_001";

        public const string MP_GCM_PLAN_MAT_LIST = "C@PLAN_MAT_LIST";

        public const string MP_GCM_REPAIR_GROUP = "C@REP_CODE_GRP";
        public const string MP_GCM_REPAIR_CODE = "REPAIR_CODE";

        public const string MP_GCM_REP_RST_GROUP = "C@REP_CODE_GRP";
        public const string MP_GCM_REP_RST_CODE = "C@REP_CODE";
        public const string MP_GCM_REP_RSN_GROUP = "C@REP_CODE_GRP";

        public const string MP_GCM_REP_RSN_CODE = "C@REP_CODE";
        public const string MP_GCM_VIEW_REP_RST_CODE = "C@VIEW_REP_RST_CODE";
        public const string MP_GCM_VIEW_REP_RSN_CODE = "C@VIEW_REP_RSN_CODE";

        public const string MP_GCM_VIEW_LOSS_GROUP = "C@VIEW_LOSS_GROUP";

        public const string MP_HOLD_CODE_REPAIR = "REPAIR";
        public const string MP_REL_CODE_REPAIR_END = "REPAIR_END";

        public const string MP_OPER_PRODUCT_STOCK = "4900";
        public const string MP_GCM_TBL_REPAIR_OPER = "C@REPAIR_OPER";

        public const string MP_GCM_TBL_CUR_WORK_ORDER = "C@WORK_ORDER";

        public const string MP_GCM_START_SCR_TYPE = "C@START_SCR_TYPE";
        public const string MP_GCM_START_SCR_TYPE_CREATION = "CREATION";
        public const string MP_GCM_START_SCR_TYPE_LAYUP = "LAYUP";
        public const string MP_GCM_START_SCR_TYPE_NONE = "NONE";
        public const string MP_GCM_START_SCR_TYPE_RAWBATCH = "RAWBATCH";
        public const string MP_GCM_START_SCR_TYPE_RESRAW = "RESRAW";
        public const string MP_GCM_START_SCR_TYPE_STRING = "STRING";

        public const string MP_TRAN_TYPE_START = "START";
        public const string MP_TRAN_TYPE_END = "END";
        public const string MP_TRAN_TYPE_MOVE = "MOVE";



        #endregion

        #region " ETC "

        public const string MP_SEC_GRP_IQC_GRUOP = "IQC_GROUP";
        public const string MP_SEC_GRP_OPERATOR_GROUP = "OPERATOR_GROUP";

        public const string MP_TOOL_TYPE_MOLD_TYPE_01 = "MOLD_TYPE_01";

        public const char MP_ORDER_CRITERIA_RESOURCE = 'R';
        public const char MP_ORDER_CRITERIA_GROUP = 'G';
        public const char MP_ORDER_CRITERIA_WORK_CENTER = 'W';

        public const char MP_ORDER_STATUS_OPEN = '0';
        public const char MP_ORDER_STATUS_PROC = 'P';
        public const char MP_ORDER_STATUS_WAIT = 'W';
        public const char MP_ORDER_STATUS_CLOSED = 'C';
        public const char MP_ORDER_STATUS_DELETED = 'D';

        public const string MP_VL_BOM_LOT_LIST = "VL_BOM_LOT_LIST";
        public const string MP_VL_BOM_LOT_SUM = "VL_BOM_LOT_SUM";
        public const string MP_VL_BOM_LOT_INFO = "VL_BOM_LOT_INFO";
        public const string MP_VL_INV_TRACE_DOWN = "VL_INV_TRACE_DOWN";
        public const string MP_VL_INV_TRACE_UP = "VL_INV_TRACE_UP";
        public const string MP_VL_MAT_LIST_EXT_001 = "VL_MAT_LIST_EXT_001";


        public const string MP_GCM_CV_CODE_PROC_ADJUST = "PROC_ADJ";

        public const string MP_DTR_WIP_LOT_CREATE_CODE_PROD = "PROD";
        public const string MP_DTR_WIP_LOT_CREATE_CODE_LOSS = "LOSS";
        public const string MP_DTR_WIP_LOT_CREATE_CODE_QC = "QC";

        public const string MP_DTR_LOSS_TYPE_LOSS_OPER_HALF = "LT01";
        public const string MP_DTR_LOSS_TYPE_LOSS_OPER_RAW = "LT02";
        //public const string MP_DTR_LOSS_TYPE_LOSS_OPER_SELECT = "LT03";

        public const string MP_BOM_INPUT_TYPE_SCAN = "S";
        public const string MP_BOM_INPUT_TYPE_AUTO = "A";
        public const string MP_BOM_INPUT_TYPE_OPTIONAL = "O";

        public const string CUS_OPER_FORM = "S01";      //성형공정코드

        public const string CUS_REL_LEVEL_RES = "R";
        public const string CUS_REL_LEVEL_RESG = "G";
        public const string CUS_REL_LEVEL_WC = "W";

        public const string CUS_MAT_TYPE_FG = "20";     //Final Goods(제품)
        public const string CUS_MAT_TYPE_SFG = "40";    //Semi-final Goods(반제품)

        public const string CUS_SHIFT_1 = "D1";    //주간 Shift
        public const string CUS_SHIFT_2 = "N1";    //야간 Shift

        public const string MP_ROUTE_YIELD_TYPE_ALL = "A";
        public const string MP_ROUTE_YIELD_TYPE_LOSS = "L";

        public const string MP_MAT_GRP_2_RUB_TYPE = "R1030";
        public const string MP_MAT_GRP_2_STL_TYPE = "R2010";

        public const string MP_GCM_WIP_RES_OPER = "C@WIP_RES_OPER";

        public const string MP_GCM_ERP_MVT_CODE = "C@ERP_MVT_CODE";

        public const string MP_VL_LOSS_HISTROY_01 = "VL_LOSS_HISTROY_01";
        public const string MP_VL_RES_STATUS_BY_OPER = "VL_RES_STATUS_BY_OPER";
        public const string MP_VL_RES_STATUS_BY_OPER_V2 = "VL_RES_STATUS_BY_OPER_V2";

        public const string MP_VL_RES_STATUS_BY_OPER_S00 = "VL_RES_STATUS_BY_OPER_S00";
        public const string MP_VL_RES_STATUS_BY_OPER_DEFAULT = "VL_RES_STATUS_BY_OPER_DEFAULT";



        public const string MP_VL_RES_STATUS_SUM_1 = "VL_RES_STATUS_SUM_1";
        public const string MP_VL_RES_STATUS_SUM_2 = "VL_RES_STATUS_SUM_2";
        public const string MP_VL_MAT_STATUS_BY_OPER = "VL_MAT_STATUS_BY_OPER";
        public const string MP_VL_MAT_STATUS_BY_OPER_2 = "VL_MAT_STATUS_BY_OPER_2";
        public const string MP_VL_MAT_STATUS_SUM = "VL_MAT_STATUS_SUM";
        public const string MP_VL_MAT_STATUS_SUM_2 = "VL_MAT_STATUS_SUM_2";
        public const string MP_VL_REWORK_HISTORY_01 = "VL_REWORK_HISTORY_01";
        public const string MP_VL_RW_GD_HISTORY_01 = "VL_RW_GD_HISTORY_01";
        public const string MP_VL_RW_GD_HISTORY_02 = "VL_RW_GD_HISTORY_02";


        public const string MP_VL_PROD_RESULT_MAT_RES = "VL_PROD_RESULT_MAT_RES";
        public const string MP_VL_PROD_RESULT_MAT_WC = "VL_PROD_RESULT_MAT_WC";
        public const string MP_VL_PROD_RESULT_LOT = "VL_PROD_RESULT_LOT";
        //public const string MP_VL_PROD_RESULT_TERMINAL = "VL_PROD_RESULT_TERMINAL";
        //public const string MP_VL_PROD_RESULT_TERMINAL_2 = "VL_PROD_RESULT_TERMINAL_2";

        public const string MP_VL_RES_AUTO_PROD_HIS = "VL_RES_AUTO_PROD_HIS";


        public const string MP_VL_INV_MAT_MOVE = "VL_INV_MAT_MOVE";
        public const string MP_VL_INV_MAT_MOVE_DETAIL = "VL_INV_MAT_MOVE_DETAIL";
        public const string MP_VL_INV_MAT_MOVE_RPT = "VL_INV_MAT_MOVE_RPT";

        public const string MP_VL_INV_LOT_MOVE_SUM = "VL_INV_LOT_MOVE_SUM";
        public const string MP_VL_INV_LOT_MOVE_DETAIL = "VL_INV_LOT_MOVE_DETAIL";

        public const string MP_VL_STK_INVG_MAG_GRP = "VL_STK_INVG_MAG_GRP";
        public const string MP_VL_STK_INVG_MAT_LIST = "VL_STK_INVG_MAT_LIST";
        public const string MP_VL_STK_INVG_LOT_LIST = "VL_STK_INVG_LOT_LIST";
        public const string MP_VL_STK_INVG_SCAN_LIST = "VL_STK_INVG_SCAN_LIST";
        public const string MP_VL_STK_INVG_LOT_LIST_ADJ = "VL_STK_INVG_LOT_LIST_ADJ";
        public const string MP_VL_STK_INVG_LOT_LIST_NO_SCAN = "VL_STK_INVG_LOT_LIST_NO_SCAN";
        public const string MP_VL_STK_MES_LOT_LIST = "VL_STK_MES_LOT_LIST";
        public const string MP_VL_WK_SHIP_PROC_LIST = "VL_WK_SHIP_PROC_LIST";
        public const string MP_VL_WK_SHIP_PROC_CUST_LIST = "VL_WK_SHIP_PROC_CUST_LIST";

        public const string MP_GCM_INSP_TYPE = "C@INSP_TYPE";
        public const string MP_GCM_RAS_DOWN_CODE_L = "C$RAS_DOWN_CODE_L";

        public const string MP_ERP_MVP_551 = "551";
        public const string MP_ERP_MVP_552 = "552";
        public const string MP_ERP_MVP_601 = "601";
        public const string MP_LOSS_CODE_PRDLOSS = "PRDLOSS";


        public const string MP_ORDER_TYPE_PROD = "PROD";
        public const string MP_ORDER_TYPE_REWORK = "RWRK";
        public const string MP_ORDER_TYPE_EMERGENCY = "EMGC";

        public const string MP_INF_ID_SHIP_NOTE = "INF009";
        public const string MP_INF_ID_DELIVERY_NOTE = "INF010";
        public const string MP_INF_ID_PLANT_PO = "INF011";

        public const string MP_MAT_GRP_2_CHEMICALS = "R1050";

        public const string MP_INV_LOSS_CODE_LS551 = "LS551";
        public const string MP_INV_CV_CODE_CV552 = "CV552";
        public const string MP_INV_GCM_TBL_INV_VENDOR = "C@VENDOR_CODE_LAG";

        public const string MP_INV_LOSS_CODE_LSNA = "LSNA";
        public const string MP_INV_CV_CODE_CVNA = "CVNA";

        public const string MP_VL_REQ_LOSS_LT2_HIS = "VL_REQ_LOSS_LT2_HIS";

        public const string MP_GCM_PROC_OPER_SETUP = "C@PROC_OPER_SETUP";
        public const string MP_GCM_PROC_OPER_MOLD = "MOLD";

        public const string MP_VWSP_1PLAN = "1PLAN";
        public const string MP_VWSP_2NOTE = "2NOTE";
        public const string MP_VWSP_3SHIP = "3SHIP";
        public const string MP_VWSP_4DIFF1 = "4DIFF1";
        public const string MP_VWSP_5DIFF2 = "5DIFF2";

        public const string MP_VWSP_SUM_1PLAN = "SUM_1PLAN";    // 출하계획 합계
        public const string MP_VWSP_SUM_2NOTE = "SUM_2NOTE";    // 출하지시 합계
        public const string MP_VWSP_SUM_3SHIP = "SUM_3SHIP";    // 출하실적 합계
        public const string MP_VWSP_PLAN_ACVRATE = "PLAN_ACVRATE";  // 출하계획 대비 달성율      
        public const string MP_VWSP_ORD_ACVRATE = "ORD_ACVRATE";  // 출하지시 대비

        public const string MP_CHECK_VIEW = "VIEW";
        public const string MP_CHECK_CREATE = "CREATE";
        public const string MP_CHECK_UPDATE = "UPDATE";
        public const string MP_CHECK_DELETE = "DELETE";
        public const string MP_CHECK_CANCEL = "CANCEL";

        #endregion

        #region " ENUM "

        public enum ORD_LIST : int
        {
            CHECK = 0,
            ORDER_ID,
            MAT_ID,
            MAT_SHORT_DESC,
            MAT_DESC,
            RES_SHORT_DESC,
            RES_DESC,
            WORK_CENTER,
            ORD_QTY,
            ORD_STSD,
            MOLD_GROUP_ID,
            ORDER_TYPE,
            WORK_DATE,
            SHIFT,
            RES_ID,
            MAT_VER,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            OPER_DESC,
            MOLD_ID,
            CUR_MOLD_GRP,
            RES_STS,
            ORDER_DESC,
            LOT_TYPE,
            OWNER_CODE,
            CREATE_CODE,
            ORD_PRIORITY,
            ORG_DUE_TIME,
            ORD_STS,
            PLAN_START_TIME,
            PLAN_END_TIME,
            PROC_QTY,
            GOOD_QTY,
            LOSS_QTY,
            QC_QTY_1,
            QC_QTY_2,
            QC_QTY_3,
            SCRAP_QTY,
            NO_LOSS_QTY,
            REWORK_QTY,
            SUSP_LOT_ID,
            SUSP_QTY,
            SUSP_MAT_ID,
            SUSP_MAT_VER,
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
            CAVITY,
            WORK_DATE_RAW
        }

        public enum ORD_USR_LIST : int
        {
            CHECK = 0,
            USER_REMOVE_BTN,
            USER_DESC,
            SHIFT,
            MAT_ID,
            MAT_SHORT_DESC,
            RES_ID,
            RES_SHORT_DESC,
            RES_DESC,
            WORK_CENTER,
            ORD_QTY,
            WORK_DATE,
            ORDER_ID,
            ORDER_TYPE,
            MAT_VER,
            MAT_DESC,
            PROC_QTY,
            GOOD_QTY,
            LOSS_QTY,
            QC_QTY_1,
            MOLD_ID,
            USER_ID,
            USER_LIST,
            START_TIME,
            END_TIME,
            QC_QTY_2,
            QC_QTY_3,
            CLOSE_FLAG,
            RES_OR_WC_FLAG,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            OPER_DESC,
            SEQ_NUM,
            MAIN_FLAG,
            MOLD_GROUP_ID,
            CUR_MOLD_GRP,
            RES_STS,
            CAVITY,
            LOT_TYPE,
            OWNER_CODE,
            CREATE_CODE,
            ORD_PRIORITY,
            ORG_DUE_TIME,
            ORD_STS,
            PLAN_START_TIME,
            PLAN_END_TIME,
            SCRAP_QTY,
            NO_LOSS_QTY,
            REWORK_QTY,
            SUSP_LOT_ID,
            SUSP_QTY,
            SUSP_MAT_ID,
            SUSP_MAT_VER,
            PALLET_ID,
            CUST_SNP,
            CUST_MAT_ID,
            CUST_ID,
            PALLET_DESC,
            ORD_CMF_3,
            ORD_CMF_4,
            ORD_CMF_5,
            ORD_CMF_6,
            ORD_CMF_7,
            ORD_CMF_8,
            ORD_CMF_9,
            ORD_CMF_10,
            ODU_CMF_1,
            ODU_CMF_2,
            ODU_CMF_3,
            ODU_CMF_4,
            ODU_CMF_5,
            ODU_CMF_6,
            ODU_CMF_7,
            ODU_CMF_8,
            ODU_CMF_9,
            ODU_CMF_10,
            START_TIME_RAW,
            USER_ID_LIST,
            USER_COUNT,
            USE_FACTORY_DESC,
            PRINT_QTY,
            MAT_GRP_2,
            WORK_DATE_RAW
        }

        public enum TOOL_STS : int
        {
            STATUS_1 = 0,
            STATUS_2,
            STATUS_3,
            STATUS_4,
            STATUS_5,
            STATUS_6,
            STATUS_7,
            STATUS_8,
            STATUS_9,
            STATUS_10,
            STATUS_11,
            STATUS_12,
            STATUS_13,
            STATUS_14,
            STATUS_15,
            STATUS_16,
            STATUS_17,
            STATUS_18,
            STATUS_19,
            STATUS_20,
            STATUS_21,
            STATUS_22,
            STATUS_23,
            STATUS_24,
            STATUS_25,
            STATUS_26,
            STATUS_27,
            STATUS_28,
            STATUS_29,
            STATUS_30
        }

        public enum BOM_INFO : int
        {
            OPER = 0,
            MAT_ID,
            MAT_SHORT_DESC,
            MAT_DESC,
            QTY,
            UNIT,
            INV_OPER,
            INPUT_TYPE_CODE,
            INPUT_TYPE,
            LOT_COUNT,
            TOT_QTY,
            LOT_UNIT,
            LOT_ID,
            LOTQTY,
            INPUT_TIME,
            PURE_IN_QTY,
            P_BASE_QTY,
            P_BASE_UNIT,
            SCRAP_QTY,
            SEQ_NUM,
            BOM_SET_ID,
            SCALE_FACTOR,
            OPER_SEQ_NUM,
            USER_LOSS_QTY,
            MAT_GRP_2,
            LOT_CREATE_TIME,
            REQ_FLAG,
            REQ_TIME
        }

        #endregion

        public const string MP_USER_ADMIN_GROUP = "ADMIN_GROUP";

        public const int SOL_BOX_MAX_COUNT = 35;
        #endregion

    }
}
