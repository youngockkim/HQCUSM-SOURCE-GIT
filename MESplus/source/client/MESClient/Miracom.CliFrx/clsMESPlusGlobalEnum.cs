using System.Data;
using System.Collections;
using System.Diagnostics;
using System;

namespace Miracom.CliFrx
{
    public enum SMALLICON_INDEX
    {
        IDX_FACTORY = 0,
        IDX_SHIP_FACTORY = 2,
        IDX_TRANSACTION = 10,
        IDX_SETUP = 11,
        IDX_EVENT = 12,
        IDX_CODE_TABLE = 13,
        IDX_CODE_DATA = 14,
        IDX_MATERIAL = 15,
        IDX_FLOW = 16,
        IDX_REWORK_FLOW = 17,
        IDX_OPER = 18,
        IDX_MFO = 19,
        IDX_SEC_GROUP = 20,
        IDX_USER = 21,
        IDX_RESOURCE = 22,
        IDX_RESOURCE_PROC = 23,
        IDX_RESOURCE_DOWN = 24,
        IDX_RESOURCE_GROUP = 25,
        IDX_SUB_EQUIP = 26,
        IDX_STATUS = 27,
        IDX_CHARACTER = 28,
        IDX_COL_SET = 29,
        IDX_COL_SET_DELETE = 30,
        IDX_COL_SET_AUTO = 31,
        IDX_CARRIER = 32,
        IDX_CARRIER_EMPTY = 33,
        IDX_CARRIER_FULL = 34,
        IDX_LOT = 35,
        IDX_LOT_CHECK = 36,
        IDX_LOT_HOLD = 37,
        IDX_LOT_HOLD_CHECK = 38,
        IDX_LOT_RELEASE = 39,
        IDX_LOT_REWORK = 40,
        IDX_LOT_REWORK_CHECK = 41,
        IDX_LOT_ALTER = 42,
        IDX_LOT_ALTER_CHECK = 43,
        IDX_LOT_START = 44,
        IDX_LOT_START_CHECK = 45,
        IDX_CHART = 46,
        IDX_CHART_LINE = 47,
        IDX_LOG_SHEET = 48,
        IDX_AREA = 49,
        IDX_SUB_AREA = 50,
        IDX_FUNCTION_GROUP = 51,
        IDX_FUNCTION = 52,
        IDX_MESSAGE_GROUP = 53,
        IDX_MESSAGE = 54,
        IDX_PRIORITY = 55,
        IDX_BOM = 56,
        IDX_PORT = 57,
        IDX_ORDER = 58,
        IDX_ORDER_DELETE = 59,
        IDX_PART = 60,
        IDX_INQUIRY = 61,
        IDX_SUB_LOT = 62,
        IDX_HISTORY = 63,
        IDX_HISTORY_DELETE = 64,
        IDX_ALARM = 65,
        IDX_DEPARTMENT = 66,
        IDX_CALENDAR = 67,
        IDX_KEY = 68,
        IDX_CUSTOMER = 69,
        IDX_CATEGORY = 70,
        IDX_YEAR = 71,
        IDX_MONTH = 72,
        IDX_PM = 73,
        IDX_POLICY = 74,
        IDX_OPTION = 75,
        IDX_SLOT_EMPTY = 76,
        IDX_SLOT_FULL = 77,
        IDX_SLOT_FULL_NEW = 78,
        IDX_SLOT_COMBINE = 79,
        IDX_RECIPE = 80,
        IDX_STOCKER = 81,
        IDX_LABEL = 84,
        IDX_ALARM_ERROR = 88,
        IDX_ALARM_WARN = 89,
        IDX_ALARM_INFO = 90,
        IDX_REPAIR_LOT = 92,
        IDX_DISPATCHER = 93,
        //현재 아이콘이 없어서 다른 아이콘을 대신 사용하므로 나중에 수정되어야 함
        IDX_COL_SET_VERSION = 29,
        IDX_PRIVILEGE = 82,
        IDX_PRIVILEGE_GROUP = 83,
        IDX_PRIVILEGE_SERVICE = 105,
        IDX_TOOL = 85,
        IDX_TOOL_EVENT = 86,
        IDX_TOOL_TYPE = 87,
        IDX_TOOL_SCRAP = 91,
        IDX_TOOL_RETURN = 94,
        IDX_EQ_TYPE = 95,
        IDX_RCP_MGR_DIR = 96,
        IDX_MODULE_DIR = 97,
        IDX_MODULE = 98,
        IDX_RCP_HOLD = 99,
        IDX_VERSION = 100,
        IDX_VERSION_REQUEST = 101,
        IDX_VERSION_APPROVAL = 102,
        IDX_VERSION_ACTIVATE = 103,
        IDX_WHITE_IMAGE = 104,
        IDX_SUB_RES_DOWN = 106,
        IDX_PORT_DOWN = 107
        //앞으로 추가되어야 함
        
    }
    
    public enum TOOLICON_INDEX
    {
        ICON_INDEX_FACTORY_SETUP = 0

        //앞으로 추가되어야 함
        
    }
    
    public enum LANG_FORMAT
    {
        STANDARD = 0,
        SYSTEM
    }
    
    public enum DATE_TIME_FORMAT
    {
        DATETIME = 0,
        DATE,
        TIME,
        NONE
        
        //STANDARD
        //YYYY/MM/DD HH:MM:SS
        //YYYY/MM/DD
        //HH:MM:SS
    }
    
    public enum RTD_RULE_LOT
    {
        PRIORITY_LEVEL = 0,
        REWORK_CODE_MATCH = 1,
        OWNER_CODE_MATCH = 2,
        CREATE_CODE_MATCH = 3,
        LOT_STATUS_MATCH = 4,
        MOST_LOT_QUANTITY1 = 5,
        MOST_LOT_QUANTITY2 = 6,
        MOST_LOT_QUANTITY3 = 7,
        NSTD_LOT = 8,
        STARTED_LOT = 9,
        LONGEST_WAIT_TIME = 10,
        SHORTEST_DUE_TIME = 11,
        EARLIEST_START_TIME = 12,
        SMALL_NEXT_OPER_WIP = 13,
        NEXT_RESOURCE_UP = 14,
        MATERIAL_MATCH = 15,
        #if _RCP
        RECIPE_MATCH = 16,
        #endif
        #if _TOOL
        TOOL_MATCH = 17,
        #endif
        #if _ORD
        ORDER_MATCH = 18,
        #endif
        LOT_INFO_MATCH = 19,
        SCH_START_TIME = 20,
        MIN_CRITICAL_RATIO = 21,
        LAST_MATERIAL_MATCH = 22,
        LESS_WIP_FOLLOW_OPER = 23,
        LAST_RECIPE_MATCH = 24
    }
    
    #if _RAS
    public enum RTD_RULE_RES
    {
        UP_DOWN_STATUS = 0,
        PRIMARY_STATUS = 1,
        RESOURCE_TYPE_MATCH = 2,
        LAST_EVENT_MATCH = 3,
        RES_INFO_MATCH = 4
    }
    #endif

    public enum RTD_RULE_PORT
    {
        PORT_TYPE_MATCH = 0,
        PORT_INFO_MATCH = 1,
        PORT_SEQ = 2,
        PORT_LAST_HIST_SEQ = 3,
        PORT_LOT_MATCH = 4,
        PORT_RES_MATCH = 5
    }
    
    public enum eGraphType
    {
        NULL = - 1,
        XBARR = 0,
        XBARS = 1,
        XRS = 2,
        P = 3,
        PN = 4,
        C = 5,
        U = 6,
        ZBARS = 7,
        DELTAS = 8
    }

    public enum HISTORY_COLUMN
    {
        HIST_SEQ = 0,
        TRAN_CODE = 1,
        TRAN_TIME = 2,
        FACTORY = 3,
        MAT_ID = 4,
        MAT_VER = 5,
        FLOW = 6,
        FLOW_SEQ_NUM = 7,
        OPER = 8,
        QTY_1 = 9,
        QTY_2 = 10,
        QTY_3 = 11,
        CARRIER = 12,
        LOT_TYPE = 13,
        OWNER_CODE = 14,
        CREATE_CODE = 15,
        CREATE_TIME = 16,
        LOT_PRIORITY = 17,
        LOT_STATUS = 18,
        LOT_DEL_TIME = 19,
        HOLD_FLAG = 20,
        HOLD_CODE = 21,
        HOLD_PRV_GRPI_ID = 22,
        OPER_IN_QTY_1 = 23,
        OPER_IN_QTY_2 = 24,
        OPER_IN_QTY_3 = 25,
        CREATE_QTY_1 = 26,
        CREATE_QTY_2 = 27,
        CREATE_QTY_3 = 28,
        START_QTY_1 = 29,
        START_QTY_2 = 30,
        START_QTY_3 = 31,
        INV_FLAG = 32,
        TRANSIT_FLAG = 33,
        UNIT_EXIT_FLAG = 34,
        INV_UNIT = 35,
        RWK_FLAG = 36,
        RWK_CODE = 37,
        RWK_COUNT = 38,
        RWK_RET_FLOW = 39,
        RWK_RET_FLOW_SEQ = 40,
        RWK_RET_OPER = 41,
        RWK_END_FLOW = 42,
        RWK_END_FLOW_SEQ = 43,
        RWK_END_OPER = 44,
        RWK_RET_CLEAR_FLAG = 45,
        RWK_TIME = 46,
        NSTD_FLAG = 47,
        NSTD_RET_FLOW = 48,
        NSTD_RET_FLOW_SEQ = 49,
        NSTD_RET_OPER = 50,
        NSTD_TIME = 51,
        REPAIR_FLAG = 52,
        REPAIR_RET_OPER = 53,
        START_FLAG = 54,
        START_TIME = 55,
        START_RESOURCE = 56,
        END_FLAG = 57,
        END_TIME = 58,
        END_RESOURCE = 59,
        SAMPLE_FLAG = 60,
        SAMPLE_WAIT_FLAG = 61,
        SAMPLE_RESULT = 62,
        FROM_TO_FLAG = 63,
        FROM_TO_LOT_ID = 64,
        FROM_TO_MAT_ID = 65,
        FROM_TO_MAT_VER = 66,
        FROM_TO_FLOW = 67,
        FROM_TO_FLOW_SEQ = 68,
        FROM_TO_OPER = 69,
        FROM_TO_QTY_1 = 70,
        FROM_TO_QTY_2 = 71,
        FROM_TO_QTY_3 = 72,
        FROM_TO_HIST_SEQ = 73,
        SHIP_CODE = 74,
        SHIP_TIME = 75,
        ORG_DUE_TIME = 76,
        SCH_DUE_TIME = 77,
        FAC_IN_TIME = 78,
        FLOW_IN_TIME = 79,
        OPER_IN_TIME = 80,
        RESERVER_RESOURCE = 81,
        BATCH_ID = 82,
        BATCH_SEQ = 83,
        ORDER_ID = 84,
        ADD_ORDER_ID_1 = 85,
        ADD_ORDER_ID_2 = 86,
        ADD_ORDER_ID_3 = 87,
        LOT_LOCATION = 88,
        LOT_CMF_1 = 89,
        LOT_CMF_2 = 90,
        LOT_CMF_3 = 91,
        LOT_CMF_4 = 92,
        LOT_CMF_5 = 93,
        LOT_CMF_6 = 94,
        LOT_CMF_7 = 95,
        LOT_CMF_8 = 96,
        LOT_CMF_9 = 97,
        LOT_CMF_10 = 98,
        LOT_CMF_11 = 99,
        LOT_CMF_12 = 100,
        LOT_CMF_13 = 101,
        LOT_CMF_14 = 102,
        LOT_CMF_15 = 103,
        LOT_CMF_16 = 104,
        LOT_CMF_17 = 105,
        LOT_CMF_18 = 106,
        LOT_CMF_19 = 107,
        LOT_CMF_20 = 108,
        LOT_DEL_FLAG = 109,
        LOT_DEL_CODE = 110,
        BOM_SET_ID = 111,
        BOM_SET_VER = 112,
        BOM_ACTIVE_HIST_SEQ = 113,
        BOM_HIST_SEQ = 114,
        CRITICAL_RESOURCE = 115,
        CRITICAL_RESOURCE_GROUP = 116,
        SAVE_RESOURCE_1 = 117,
        SAVE_RESOURCE_2 = 118,
        SUB_RESOURCE = 119,
        LOT_GROUP_ID_1 = 120,
        LOT_GROUP_ID_2 = 121,
        LOT_GROUP_ID_3 = 122,
        RESV_FIELD_1 = 123,
        RESV_FIELD_2 = 124,
        RESV_FIELD_3 = 125,
        RESV_FIELD_4 = 126,
        RESV_FIELD_5 = 127,
        RESV_FLAG_1 = 128,
        RESV_FLAG_2 = 129,
        RESV_FLAG_3 = 130,
        RESV_FLAG_4 = 131,
        RESV_FLAG_5 = 132,
        OLD_FACTORY = 133,
        OLD_MAT_ID = 134,
        OLD_MAT_VER = 135,
        OLD_FLOW = 136,
        OLD_FLOW_SEQ = 137,
        OLD_OPER = 138,
        OLD_QTY_1 = 139,
        OLD_QTY_2 = 140,
        OLD_QTY_3 = 141,
        OLD_HIST_SEQ = 142,
        OLD_LOT_TYPE = 143,
        OLD_OWNER_CODE = 144,
        OLD_CREATE_CODE = 145,
        OLD_FACTORY_IN_TIME = 146,
        OLD_FLOW_IN_TIME = 147,
        OLD_OPER_IN_TIME = 148,
        TRAN_CMF_1 = 149,
        TRAN_CMF_2 = 150,
        TRAN_CMF_3 = 151,
        TRAN_CMF_4 = 152,
        TRAN_CMF_5 = 153,
        TRAN_CMF_6 = 154,
        TRAN_CMF_7 = 155,
        TRAN_CMF_8 = 156,
        TRAN_CMF_9 = 157,
        TRAN_CMF_10 = 158,
        TRAN_CMF_11 = 159,
        TRAN_CMF_12 = 160,
        TRAN_CMF_13 = 161,
        TRAN_CMF_14 = 162,
        TRAN_CMF_15 = 163,
        TRAN_CMF_16 = 164,
        TRAN_CMF_17 = 165,
        TRAN_CMF_18 = 166,
        TRAN_CMF_19 = 167,
        TRAN_CMF_20 = 168,
        TRAN_USER_ID = 169,
        TRAN_COMMENT = 170,
        PREV_ACTIVE_HIST_SEQ = 171,
        MULTI_TR_KEY = 172,
        HIST_START_SEQ = 173,
        HIST_DEL_FLAG = 174,
        HIST_DEL_TIME = 175,
        HIST_DEL_USER_ID = 176,
        HIST_DELETE_COMMENT = 177,
        LAST_ACTIVE_HIST_SEQ = 178,
        LAST_HIST_SEQ = 179,
        LAST_TRAN_CODE = 180,
        LAST_TRAN_TIME = 181,
        LAST_COMMENT = 182,
        LAST_SYS_TRAN_TIME = 183
    }

    public enum DISPLAY_DIRECTION 
    {
        DISPLAY_LANDSCAPE = 0,
        DISPLAY_PORTRAIT
    }

    public enum CAPTION_TYPE
    {
        LABEL = 0,
        BUTTON,
        MENU
    }

    public enum MSGBOX_ICON_TYPE
    {
        NONE = 0,
        WARNING,
        ERROR
    }

    public enum VAR_TYPE
    {
        Ascii = 'A',
        Number = 'N',
        Float = 'F',
        Table = 'T'
    }

    public enum GCM_TABLE_TYPE
    {
        General = ' ',
        Extend = 'E',
        Large = 'L'
    }
}
