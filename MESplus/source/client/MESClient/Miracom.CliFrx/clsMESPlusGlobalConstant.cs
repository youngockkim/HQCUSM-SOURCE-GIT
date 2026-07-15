using System.Data;
using System.Collections;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace Miracom.CliFrx
{
    public sealed class MPGC
    {
        
        #region "H101 Function Result"
        
        public const char MP_SUCCESS_STATUS = '0';
        public const char MP_FAIL_STATUS = '1';
        public const char MP_WARN_STATUS = '2';
        public const char MP_TRBL_STATUS = '3';

        public const char MP_MSG_CATE_SUCCESS = 'S';
        public const char MP_MSG_CATE_WARN    = 'W';
        public const char MP_MSG_CATE_ERROR   = 'E';
        
        #endregion
        
        #region "Transaction Code"
        
        public const string MP_TRAN_CODE_CREATE = "CREATE";
        public const string MP_TRAN_CODE_START = "START";
        public const string MP_TRAN_CODE_END = "END";
        public const string MP_TRAN_CODE_MOVE = "MOVE";
        public const string MP_TRAN_CODE_SKIP = "SKIP";
        public const string MP_TRAN_CODE_REWORK = "REWORK";
        public const string MP_TRAN_CODE_REPAIR = "REPAIR";
        public const string MP_TRAN_CODE_REPAIR_END = "REPAIR_END";
        public const string MP_TRAN_CODE_LOCAL_REPAIR = "LOCAL_REPAIR";
        public const string MP_TRAN_CODE_LOSS = "LOSS";
        public const string MP_TRAN_CODE_BONUS = "BONUS";
        public const string MP_TRAN_CODE_SPLIT = "SPLIT";
        public const string MP_TRAN_CODE_MERGE = "MERGE";
        public const string MP_TRAN_CODE_COMBINE = "COMBINE";
        public const string MP_TRAN_CODE_HOLD = "HOLD";
        public const string MP_TRAN_CODE_RELEASE = "RELEASE";
        public const string MP_TRAN_CODE_SHIP = "SHIP";
        public const string MP_TRAN_CODE_RECEIVE = "RECEIVE";
        public const string MP_TRAN_CODE_ADAPT = "ADAPT";
        public const string MP_TRAN_CODE_ATTRIBUTE = "ATTRIBUTE";
        public const string MP_TRAN_CODE_LOTEDC = "LOTEDC";
        public const string MP_TRAN_CODE_RESEDC = "RESEDC";
        public const string MP_TRAN_CODE_SORT = "SORT";
        public const string MP_TRAN_CODE_STORE = "STORE";
        public const string MP_TRAN_CODE_UNSTORE = "UNSTORE";
        public const string MP_TRAN_CODE_REGENERATE = "REGENERATE";
        public const string MP_TRAN_CODE_RESERVE = "RESERVE";
        
        public const string MP_TRAN_CODE_IN_INV = "IN INV";
        public const string MP_TRAN_CODE_OUT_INV = "OUT INV";
        public const string MP_TRAN_CODE_TRANSFER_INV = "TRANS INV";
        public const string MP_TRAN_CODE_CONV_TO_LOT = "CONV TO LOT";
        public const string MP_TRAN_CODE_CONV_TO_INV = "CONV TO INV";
        public const string MP_TRAN_CODE_CONSUME = "CONSUME";
        public const string MP_TRAN_CODE_SCRAP = "SCRAP";
        public const string MP_TRAN_CODE_REVERSE = "REVERSE";
        public const string MP_TRAN_CODE_SCRIBE = "SCRIBE";
        
        public const string MP_TRAN_CODE_TERMINATE = "TERMINATE";
        public const string MP_TRAN_CODE_RECREATE = "RECREATE";
        public const string MP_TRAN_CODE_CLEAN = "CLEAN";
        public const string MP_TRAN_CODE_ABORT_START = "ABORT_START";
        
        #endregion
        
        #region "Process Step"

        public const char MP_STEP_CREATE = 'I';
        public const char MP_STEP_UPDATE = 'U';
        public const char MP_STEP_DELETE = 'D';
        public const char MP_STEP_CONFIRM = 'F';
        public const char MP_STEP_DELETE_FORCE = 'X';
        public const char MP_STEP_COPY = 'C';
        public const char MP_STEP_UNDELETE = 'R';
        public const char MP_STEP_APPROVAL = 'A';
        public const char MP_STEP_RELEASE = 'E';
        public const char MP_STEP_CANCEL_APPROVAL = 'P';
        public const char MP_STEP_SCRAP = 'S';
        public const char MP_STEP_RETURN = 'N';
        public const char MP_STEP_REGENERATE = 'G';
        public const char MP_STEP_VERSION_UP = 'V';
        public const char MP_STEP_TERMINATE = 'M';

        public const char MP_STEP_TRAN = 'T';
        
        #endregion
        
        #region "CMF Item"
        
        //CMF
        public const string MP_CMF_MATERIAL = "CMF_MATERIAL";
        public const string MP_CMF_FORMAT = "CMF_FORMAT";
        public const string MP_CMF_TEMPLATE = "CMF_TEMPLATE";
        public const string MP_CMF_FLOW = "CMF_FLOW";
        public const string MP_CMF_OPERATION = "CMF_OPER";
        public const string MP_CMF_STEP = "CMF_STEP";
        public const string MP_CMF_RESOURCE = "CMF_RESOURCE";
        public const string MP_CMF_PORT = "CMF_PORT";

        public const string MP_CMF_CARRIER = "CMF_CARRIER";
        public const string MP_CMF_SUBRESOURCE = "CMF_SUBRESOURCE";
        public const string MP_CMF_USER = "CMF_USER";
        public const string MP_CMF_CHARACTER = "CMF_CHARACTER";
        public const string MP_CMF_COL_SET = "CMF_COL_SET";
        public const string MP_CMF_ORDER = "CMF_ORDER";
        public const string MP_CMF_BOM_SET = "CMF_BOM_SET";
        public const string MP_CMF_RECIPE = "CMF_RECIPE";
        public const string MP_CMF_PART = "CMF_PART";
        public const string MP_CMF_LABEL = "CMF_LABEL";

        public const string MP_CMF_QUEUETIME = "CMF_QUEUETIME";
        public const string MP_CMF_SERVICE = "CMF_SERVICE";

        public const string MP_CMF_INPUT_OPER_VALUE = "CMF_INPUT_OPER_VALUE";

        /* Add by DM KIM 2012.04.18 */
        public const string MP_CMF_TEST_PGM = "CMF_TEST_PGM";

        /* Add by YG SON 2012.11.20 */
        public const string MP_CMF_CHKLIST = "CMF_CHKLIST";

        //QCM CMF
        public const string MP_CMF_SMP_PROC = "CMF_SMP_PROC";
        public const string MP_CMF_INSP_ITEM = "CMF_INSP_ITEM";
        public const string MP_CMF_INSP_SET = "CMF_INSP_SET";
        
        public const string MP_CMF_LOT = "CMF_LOT";
        public const string MP_CMF_SUBLOT = "CMF_SUBLOT";
        
        public const string MP_CMF_TRN_ADAPT = "CMF_TRN_ADAPT";
        public const string MP_CMF_TRN_BONUS = "CMF_TRN_BONUS";
        public const string MP_CMF_TRN_LOSS = "CMF_TRN_LOSS";
        public const string MP_CMF_TRN_CREATE = "CMF_TRN_CREATE";
        public const string MP_CMF_TRN_START = "CMF_TRN_START";
        public const string MP_CMF_TRN_END = "CMF_TRN_END";
        public const string MP_CMF_TRN_MOVE = "CMF_TRN_MOVE";
        public const string MP_CMF_TRN_SKIP = "CMF_TRN_SKIP";
        public const string MP_CMF_TRN_REWORK = "CMF_TRN_REWORK";
        public const string MP_CMF_TRN_REPAIR = "CMF_TRN_REPAIR";
        public const string MP_CMF_TRN_REPAIR_END = "CMF_TRN_REPAIR_END";
        public const string MP_CMF_TRN_LOCAL_REPAIR = "CMF_TRN_LOCAL_REPAIR";
        public const string MP_CMF_TRN_SPLIT = "CMF_TRN_SPLIT";
        public const string MP_CMF_TRN_COMBINE = "CMF_TRN_COMBINE";
        public const string MP_CMF_TRN_MERGE = "CMF_TRN_MERGE";
        public const string MP_CMF_TRN_HOLD = "CMF_TRN_HOLD";
        public const string MP_CMF_TRN_RELEASE = "CMF_TRN_RELEASE";
        public const string MP_CMF_TRN_SHIP = "CMF_TRN_SHIP";
        public const string MP_CMF_TRN_RECEIVE = "CMF_TRN_RECEIVE";
        public const string MP_CMF_TRN_ASSEMBLY = "CMF_TRN_ASSEMBLY";
        public const string MP_CMF_TRN_DISASSEMBLE = "CMF_TRN_DISASSEMBLE";
        public const string MP_CMF_TRN_REPLACE = "CMF_TRN_REPLACE";
        public const string MP_CMF_TRN_LOTEDC = "CMF_TRN_LOTEDC";
        public const string MP_CMF_TRN_EVENT = "CMF_TRN_EVENT";
        public const string MP_CMF_TRN_TROUBLE = "CMF_TRN_TROUBLE";
        public const string MP_CMF_TRN_RMA_OPEN = "CMF_TRN_RMA_OPEN";
        public const string MP_CMF_TRN_RMA_CLOSE = "CMF_TRN_RMA_CLOSE";
        public const string MP_CMF_TRN_SORT = "CMF_TRN_SORT";
        public const string MP_CMF_TRN_STORE = "CMF_TRN_STORE";
        public const string MP_CMF_TRN_UNSTORE = "CMF_TRN_UNSTORE";
        public const string MP_CMF_TRN_TERMINATE = "CMF_TRN_TERMINATE";
        public const string MP_CMF_TRN_CHANGE_CMF = "CMF_TRN_CHANGE_CMF";
        public const string MP_CMF_TRN_RESERVE = "CMF_TRN_RESERVE";
        public const string MP_CMF_TRN_UNRESERVE = "CMF_TRN_UNRESERVE";
        public const string MP_CMF_TRN_SCRIBE = "CMF_TRN_SCRIBE";
        public const string MP_CMF_TRN_CV = "CMF_TRN_CV";
        public const string MP_CMF_TRN_REGENERATE = "CMF_TRN_REGENERATE";
        public const string MP_CMF_TRN_START_STEP = "CMF_TRN_START_STEP";
        public const string MP_CMF_TRN_END_STEP = "CMF_TRN_END_STEP";
        public const string MP_CMF_TRN_BIN_COL = "CMF_TRN_BIN_COL";
        public const string MP_CMF_TRN_ABORT_START = "CMF_TRN_ABORT_START";


        //change port status
        public const string MP_CMF_TRN_CHANGE_PORT = "CMF_TRN_CHANGE_PORT";
        public const string MP_CMF_TRN_COLLECT_LOT_DEFECT = "CMF_TRN_COLLECT_DFT";
        public const string MP_CMF_TRN_CLEAN_LOT_DEFECT = "CMF_TRN_CLEAN_DFT";
        
        //Inventory CMF
        public const string MP_GRP_INV_MATERIAL = "GRP_INV_MATERIAL";
        public const string MP_GRP_INV_OPERATION = "GRP_INV_OPER";
        public const string MP_CMF_INV_MATERIAL = "CMF_INV_MATERIAL";
        public const string MP_CMF_INV_OPERATION = "CMF_INV_OPER";
        public const string MP_CMF_TRN_IN_INV = "CMF_TRN_IN_INV";
        public const string MP_CMF_TRN_OUT_INV = "CMF_TRN_OUT_INV";
        public const string MP_CMF_TRN_TRANS_INV = "CMF_TRN_TRANS_INV";
        public const string MP_CMF_TRN_CONV_TO_LOT = "CMF_TRN_CONV_TO_LOT";
        public const string MP_CMF_TRN_CONV_TO_INV = "CMF_TRN_CONV_TO_INV";
        public const string MP_CMF_TRN_CONSUME = "CMF_TRN_CONSUME";
        public const string MP_CMF_TRN_SCRAP = "CMF_TRN_SCRAP";
        
        public const string MP_CMF_TRN_QCM_BATCH = "CMF_TRN_QCM_BATCH";
        public const string MP_CMF_TRN_QCM_RESULT = "CMF_TRN_QCM_RESULT";
        public const string MP_CMF_TRN_QCM_FINAL = "CMF_TRN_QCM_FINAL";
        public const string MP_CMF_TRN_QCM_MERGE = "CMF_TRN_QCM_MERGE";
        public const string MP_CMF_TRN_QCM_SPLIT = "CMF_TRN_QCM_SPLIT";
        public const string MP_CMF_CHART_SET = "CMF_CHART_SET";
        public const string MP_CMF_CHART = "CMF_CHART";

        public const string MP_CMF_RULE_RELATION = "CMF_RULE_RELATION";
        public const string MP_CMF_RULE_SEQ_KEY = "CMF_RULE_SEQ_KEY";
        public const string MP_CMF_CALENDAR = "CMF_CALENDAR";
        public const string MP_CMF_ALARM = "CMF_ALARM";
    
        //BIN
        public const string MP_CMF_BIN_DEF = "CMF_BIN_DEF";
        public const string MP_CMF_BIN_UNIT = "CMF_BIN_UNIT";
        public const string MP_CMF_BIN_GRADE = "CMF_BIN_GRADE";

        //MMS
        public const string MP_CMF_MMS_CALI_INST = "CMF_MMS_CALI_INST";
        public const string MP_CMF_MMS_EQUIPMENT = "CMF_MMS_EQUIPMENT";
    
        //Group
        public const string MP_GRP_FLOW = "GRP_FLOW";
        public const string MP_GRP_MATERIAL = "GRP_MATERIAL";
        public const string MP_GRP_OPERATION = "GRP_OPER";
        public const string MP_GRP_STEP = "GRP_STEP";        
        public const string MP_GRP_CHARACTER = "GRP_CHARACTER";
        public const string MP_GRP_RESOURCE = "GRP_RESOURCE";
        public const string MP_GRP_COL_SET = "GRP_COL_SET";
        public const string MP_GRP_USER = "GRP_USER";
        public const string MP_GRP_EVENT = "GRP_EVENT";
        public const string MP_GRP_BOM_SET = "GRP_BOM_SET";
        public const string MP_GRP_RECIPE = "GRP_RECIPE";
        public const string MP_GRP_INSP_SET = "GRP_INSP_SET";
        public const string MP_GRP_CHART = "GRP_CHART";
        public const string MP_GRP_CHART_SET = "GRP_CHART_SET";
        public const string MP_GRP_FORMAT = "GRP_FORMAT";
        public const string MP_GRP_TEMPLATE = "GRP_TEMPLATE";
        public const string MP_GRP_CHKLIST = "GRP_CHKLIST";
        public const string MP_GRP_BIN_DEF = "GRP_BIN_DEF";
        public const string MP_GRP_CALENDAR = "GRP_CALENDAR";
        public const string MP_GRP_ALARM = "GRP_ALARM";
        
        //FOR BACKEND
        //COMBINE_REL_CMF
        public const string MP_CMF_COMBINE_REL = "CMF_COMBINE_REL";
        public const string MP_CMF_MAT_CHG = "CMF_MAT_CHG";
        #endregion
        
        #region "GCM Table Name"
        
        //System GCM Table
        public const string MP_GCM_MSGGRP_TBL = "MESSAGE_GROUP";
        
        //Collection Set Group Table 1~10
        public const string MP_GCM_COL_GRP_1 = "COL_GRP_1";
        public const string MP_GCM_COL_GRP_2 = "COL_GRP_2";
        public const string MP_GCM_COL_GRP_3 = "COL_GRP_3";
        public const string MP_GCM_COL_GRP_4 = "COL_GRP_4";
        public const string MP_GCM_COL_GRP_5 = "COL_GRP_5";
        public const string MP_GCM_COL_GRP_6 = "COL_GRP_6";
        public const string MP_GCM_COL_GRP_7 = "COL_GRP_7";
        public const string MP_GCM_COL_GRP_8 = "COL_GRP_8";
        public const string MP_GCM_COL_GRP_9 = "COL_GRP_9";
        public const string MP_GCM_COL_GRP_10 = "COL_GRP_10";
        
        //Character Group Table 1~10
        public const string MP_GCM_CHAR_GRP_1 = "CHAR_GRP_1";
        public const string MP_GCM_CHAR_GRP_2 = "CHAR_GRP_2";
        public const string MP_GCM_CHAR_GRP_3 = "CHAR_GRP_3";
        public const string MP_GCM_CHAR_GRP_4 = "CHAR_GRP_4";
        public const string MP_GCM_CHAR_GRP_5 = "CHAR_GRP_5";
        public const string MP_GCM_CHAR_GRP_6 = "CHAR_GRP_6";
        public const string MP_GCM_CHAR_GRP_7 = "CHAR_GRP_7";
        public const string MP_GCM_CHAR_GRP_8 = "CHAR_GRP_8";
        public const string MP_GCM_CHAR_GRP_9 = "CHAR_GRP_9";
        public const string MP_GCM_CHAR_GRP_10 = "CHAR_GRP_10";
        
        //Resource Group Table 1~10
        public const string MP_GCM_RES_GRP_1 = "RES_GRP_1";
        public const string MP_GCM_RES_GRP_2 = "RES_GRP_2";
        public const string MP_GCM_RES_GRP_3 = "RES_GRP_3";
        public const string MP_GCM_RES_GRP_4 = "RES_GRP_4";
        public const string MP_GCM_RES_GRP_5 = "RES_GRP_5";
        public const string MP_GCM_RES_GRP_6 = "RES_GRP_6";
        public const string MP_GCM_RES_GRP_7 = "RES_GRP_7";
        public const string MP_GCM_RES_GRP_8 = "RES_GRP_8";
        public const string MP_GCM_RES_GRP_9 = "RES_GRP_9";
        public const string MP_GCM_RES_GRP_10 = "RES_GRP_10";
        
        //Event Group Table 1~10
        public const string MP_GCM_EVN_GRP_1 = "EVN_GRP_1";
        public const string MP_GCM_EVN_GRP_2 = "EVN_GRP_2";
        public const string MP_GCM_EVN_GRP_3 = "EVN_GRP_3";
        public const string MP_GCM_EVN_GRP_4 = "EVN_GRP_4";
        public const string MP_GCM_EVN_GRP_5 = "EVN_GRP_5";
        public const string MP_GCM_EVN_GRP_6 = "EVN_GRP_6";
        public const string MP_GCM_EVN_GRP_7 = "EVN_GRP_7";
        public const string MP_GCM_EVN_GRP_8 = "EVN_GRP_8";
        public const string MP_GCM_EVN_GRP_9 = "EVN_GRP_9";
        public const string MP_GCM_EVN_GRP_10 = "EVN_GRP_10";
        
        //Material Group Table 1~10
        public const string MP_GCM_MATERIAL_GRP_1 = "MATERIAL_GRP_1";
        public const string MP_GCM_MATERIAL_GRP_2 = "MATERIAL_GRP_2";
        public const string MP_GCM_MATERIAL_GRP_3 = "MATERIAL_GRP_3";
        public const string MP_GCM_MATERIAL_GRP_4 = "MATERIAL_GRP_4";
        public const string MP_GCM_MATERIAL_GRP_5 = "MATERIAL_GRP_5";
        public const string MP_GCM_MATERIAL_GRP_6 = "MATERIAL_GRP_6";
        public const string MP_GCM_MATERIAL_GRP_7 = "MATERIAL_GRP_7";
        public const string MP_GCM_MATERIAL_GRP_8 = "MATERIAL_GRP_8";
        public const string MP_GCM_MATERIAL_GRP_9 = "MATERIAL_GRP_9";
        public const string MP_GCM_MATERIAL_GRP_10 = "MATERIAL_GRP_10";
        
        //Inventory Material Group Table 1~10
        public const string MP_GCM_INV_MATERIAL_GRP_1 = "INV_MATERIAL_GRP_1";
        public const string MP_GCM_INV_MATERIAL_GRP_2 = "INV_MATERIAL_GRP_2";
        public const string MP_GCM_INV_MATERIAL_GRP_3 = "INV_MATERIAL_GRP_3";
        public const string MP_GCM_INV_MATERIAL_GRP_4 = "INV_MATERIAL_GRP_4";
        public const string MP_GCM_INV_MATERIAL_GRP_5 = "INV_MATERIAL_GRP_5";
        public const string MP_GCM_INV_MATERIAL_GRP_6 = "INV_MATERIAL_GRP_6";
        public const string MP_GCM_INV_MATERIAL_GRP_7 = "INV_MATERIAL_GRP_7";
        public const string MP_GCM_INV_MATERIAL_GRP_8 = "INV_MATERIAL_GRP_8";
        public const string MP_GCM_INV_MATERIAL_GRP_9 = "INV_MATERIAL_GRP_9";
        public const string MP_GCM_INV_MATERIAL_GRP_10 = "INV_MATERIAL_GRP_10";

        //Flow Group Table 1~10
        public const string MP_GCM_FLOW_GRP_1 = "FLOW_GRP_1";
        public const string MP_GCM_FLOW_GRP_2 = "FLOW_GRP_2";
        public const string MP_GCM_FLOW_GRP_3 = "FLOW_GRP_3";
        public const string MP_GCM_FLOW_GRP_4 = "FLOW_GRP_4";
        public const string MP_GCM_FLOW_GRP_5 = "FLOW_GRP_5";
        public const string MP_GCM_FLOW_GRP_6 = "FLOW_GRP_6";
        public const string MP_GCM_FLOW_GRP_7 = "FLOW_GRP_7";
        public const string MP_GCM_FLOW_GRP_8 = "FLOW_GRP_8";
        public const string MP_GCM_FLOW_GRP_9 = "FLOW_GRP_9";
        public const string MP_GCM_FLOW_GRP_10 = "FLOW_GRP_10";
        
        //Operation Group Table 1~10
        public const string MP_GCM_OPER_GRP_1 = "OPER_GRP_1";
        public const string MP_GCM_OPER_GRP_2 = "OPER_GRP_2";
        public const string MP_GCM_OPER_GRP_3 = "OPER_GRP_3";
        public const string MP_GCM_OPER_GRP_4 = "OPER_GRP_4";
        public const string MP_GCM_OPER_GRP_5 = "OPER_GRP_5";
        public const string MP_GCM_OPER_GRP_6 = "OPER_GRP_6";
        public const string MP_GCM_OPER_GRP_7 = "OPER_GRP_7";
        public const string MP_GCM_OPER_GRP_8 = "OPER_GRP_8";
        public const string MP_GCM_OPER_GRP_9 = "OPER_GRP_9";
        public const string MP_GCM_OPER_GRP_10 = "OPER_GRP_10";

        //Step Group Table 1~10
        public const string MP_GCM_STEP_GRP_1 = "STEP_GRP_1";
        public const string MP_GCM_STEP_GRP_2 = "STEP_GRP_2";
        public const string MP_GCM_STEP_GRP_3 = "STEP_GRP_3";
        public const string MP_GCM_STEP_GRP_4 = "STEP_GRP_4";
        public const string MP_GCM_STEP_GRP_5 = "STEP_GRP_5";
        public const string MP_GCM_STEP_GRP_6 = "STEP_GRP_6";
        public const string MP_GCM_STEP_GRP_7 = "STEP_GRP_7";
        public const string MP_GCM_STEP_GRP_8 = "STEP_GRP_8";
        public const string MP_GCM_STEP_GRP_9 = "STEP_GRP_9";
        public const string MP_GCM_STEP_GRP_10 = "STEP_GRP_10";

        //User Group Table 1~10
        public const string MP_GCM_USER_GRP_1 = "USER_GRP_1";
        public const string MP_GCM_USER_GRP_2 = "USER_GRP_2";
        public const string MP_GCM_USER_GRP_3 = "USER_GRP_3";
        public const string MP_GCM_USER_GRP_4 = "USER_GRP_4";
        public const string MP_GCM_USER_GRP_5 = "USER_GRP_5";
        public const string MP_GCM_USER_GRP_6 = "USER_GRP_6";
        public const string MP_GCM_USER_GRP_7 = "USER_GRP_7";
        public const string MP_GCM_USER_GRP_8 = "USER_GRP_8";
        public const string MP_GCM_USER_GRP_9 = "USER_GRP_9";
        public const string MP_GCM_USER_GRP_10 = "USER_GRP_10";

        //CheckList Group Table 1~10
        //Yeonggon Son 2012.11.20
        public const string MP_GCM_CHKLIST_GRP_1 = "CHKLIST_GRP_1";
        public const string MP_GCM_CHKLIST_GRP_2 = "CHKLIST_GRP_2";
        public const string MP_GCM_CHKLIST_GRP_3 = "CHKLIST_GRP_3";
        public const string MP_GCM_CHKLIST_GRP_4 = "CHKLIST_GRP_4";
        public const string MP_GCM_CHKLIST_GRP_5 = "CHKLIST_GRP_5";
        public const string MP_GCM_CHKLIST_GRP_6 = "CHKLIST_GRP_6";
        public const string MP_GCM_CHKLIST_GRP_7 = "CHKLIST_GRP_7";
        public const string MP_GCM_CHKLIST_GRP_8 = "CHKLIST_GRP_8";
        public const string MP_GCM_CHKLIST_GRP_9 = "CHKLIST_GRP_9";
        public const string MP_GCM_CHKLIST_GRP_10 = "CHKLIST_GRP_10";

        //File Attach
        public const string MP_GCM_ATTACH_TYPE = "FILE_ATTACH_TYPE";         // File Attach Type
        public const string MP_GCM_ATTACH_PATH = "FILE_ATTACH_PATH";         // File Attach Path
        
        //BOM Set Group Table 1~10
        public const string MP_GCM_BOM_GRP_1 = "BOM_GRP_1";
        public const string MP_GCM_BOM_GRP_2 = "BOM_GRP_2";
        public const string MP_GCM_BOM_GRP_3 = "BOM_GRP_3";
        public const string MP_GCM_BOM_GRP_4 = "BOM_GRP_4";
        public const string MP_GCM_BOM_GRP_5 = "BOM_GRP_5";
        public const string MP_GCM_BOM_GRP_6 = "BOM_GRP_6";
        public const string MP_GCM_BOM_GRP_7 = "BOM_GRP_7";
        public const string MP_GCM_BOM_GRP_8 = "BOM_GRP_8";
        public const string MP_GCM_BOM_GRP_9 = "BOM_GRP_9";
        public const string MP_GCM_BOM_GRP_10 = "BOM_GRP_10";
        
        //Recipe Group Table 1~10
        public const string MP_GCM_RECIPE_GRP_1 = "RECIPE_GRP_1";
        public const string MP_GCM_RECIPE_GRP_2 = "RECIPE_GRP_2";
        public const string MP_GCM_RECIPE_GRP_3 = "RECIPE_GRP_3";
        public const string MP_GCM_RECIPE_GRP_4 = "RECIPE_GRP_4";
        public const string MP_GCM_RECIPE_GRP_5 = "RECIPE_GRP_5";
        public const string MP_GCM_RECIPE_GRP_6 = "RECIPE_GRP_6";
        public const string MP_GCM_RECIPE_GRP_7 = "RECIPE_GRP_7";
        public const string MP_GCM_RECIPE_GRP_8 = "RECIPE_GRP_8";
        public const string MP_GCM_RECIPE_GRP_9 = "RECIPE_GRP_9";
        public const string MP_GCM_RECIPE_GRP_10 = "RECIPE_GRP_10";
        
        //Inspection Set Group Table 1~10
        public const string MP_GCM_INSP_SET_GRP_1 = "INSP_SET_GRP_1";
        public const string MP_GCM_INSP_SET_GRP_2 = "INSP_SET_GRP_2";
        public const string MP_GCM_INSP_SET_GRP_3 = "INSP_SET_GRP_3";
        public const string MP_GCM_INSP_SET_GRP_4 = "INSP_SET_GRP_4";
        public const string MP_GCM_INSP_SET_GRP_5 = "INSP_SET_GRP_5";
        public const string MP_GCM_INSP_SET_GRP_6 = "INSP_SET_GRP_6";
        public const string MP_GCM_INSP_SET_GRP_7 = "INSP_SET_GRP_7";
        public const string MP_GCM_INSP_SET_GRP_8 = "INSP_SET_GRP_8";
        public const string MP_GCM_INSP_SET_GRP_9 = "INSP_SET_GRP_9";
        public const string MP_GCM_INSP_SET_GRP_10 = "INSP_SET_GRP_10";
        
        //SPC Chart Group Table 1~10
        public const string MP_GCM_CHT_GRP_1 = "CHT_GRP_1";
        public const string MP_GCM_CHT_GRP_2 = "CHT_GRP_2";
        public const string MP_GCM_CHT_GRP_3 = "CHT_GRP_3";
        public const string MP_GCM_CHT_GRP_4 = "CHT_GRP_4";
        public const string MP_GCM_CHT_GRP_5 = "CHT_GRP_5";
        public const string MP_GCM_CHT_GRP_6 = "CHT_GRP_6";
        public const string MP_GCM_CHT_GRP_7 = "CHT_GRP_7";
        public const string MP_GCM_CHT_GRP_8 = "CHT_GRP_8";
        public const string MP_GCM_CHT_GRP_9 = "CHT_GRP_9";
        public const string MP_GCM_CHT_GRP_10 = "CHT_GRP_10";
        
        //SPC Chart Group Table 1~10
        public const string MP_GCM_CHTSET_GRP_1 = "CHTSET_GRP_1";
        public const string MP_GCM_CHTSET_GRP_2 = "CHTSET_GRP_2";
        public const string MP_GCM_CHTSET_GRP_3 = "CHTSET_GRP_3";
        public const string MP_GCM_CHTSET_GRP_4 = "CHTSET_GRP_4";
        public const string MP_GCM_CHTSET_GRP_5 = "CHTSET_GRP_5";
        public const string MP_GCM_CHTSET_GRP_6 = "CHTSET_GRP_6";
        public const string MP_GCM_CHTSET_GRP_7 = "CHTSET_GRP_7";
        public const string MP_GCM_CHTSET_GRP_8 = "CHTSET_GRP_8";
        public const string MP_GCM_CHTSET_GRP_9 = "CHTSET_GRP_9";
        public const string MP_GCM_CHTSET_GRP_10 = "CHTSET_GRP_10";

        public const string MP_GCM_CALENDAR_GRP_1 = "CALENDAR_GRP_1";
        public const string MP_GCM_CALENDAR_GRP_2 = "CALENDAR_GRP_2";
        public const string MP_GCM_CALENDAR_GRP_3 = "CALENDAR_GRP_3";
        public const string MP_GCM_CALENDAR_GRP_4 = "CALENDAR_GRP_4";
        public const string MP_GCM_CALENDAR_GRP_5 = "CALENDAR_GRP_5";
        public const string MP_GCM_CALENDAR_GRP_6 = "CALENDAR_GRP_6";
        public const string MP_GCM_CALENDAR_GRP_7 = "CALENDAR_GRP_7";
        public const string MP_GCM_CALENDAR_GRP_8 = "CALENDAR_GRP_8";
        public const string MP_GCM_CALENDAR_GRP_9 = "CALENDAR_GRP_9";
        public const string MP_GCM_CALENDAR_GRP_10 = "CALENDAR_GRP_10";

        public const string MP_GCM_ALARM_GRP_1 = "ALARM_GRP_1";
        public const string MP_GCM_ALARM_GRP_2 = "ALARM_GRP_2";
        public const string MP_GCM_ALARM_GRP_3 = "ALARM_GRP_3";
        public const string MP_GCM_ALARM_GRP_4 = "ALARM_GRP_4";
        public const string MP_GCM_ALARM_GRP_5 = "ALARM_GRP_5";
        public const string MP_GCM_ALARM_GRP_6 = "ALARM_GRP_6";
        public const string MP_GCM_ALARM_GRP_7 = "ALARM_GRP_7";
        public const string MP_GCM_ALARM_GRP_8 = "ALARM_GRP_8";
        public const string MP_GCM_ALARM_GRP_9 = "ALARM_GRP_9";
        public const string MP_GCM_ALARM_GRP_10 = "ALARM_GRP_10";

        public const string MP_GCM_MMS_CALI_INST_GRP_1 = "CALI_INST_GRP_1";
        public const string MP_GCM_MMS_CALI_INST_GRP_2 = "CALI_INST_GRP_2";
        public const string MP_GCM_MMS_CALI_INST_GRP_3 = "CALI_INST_GRP_3";
        public const string MP_GCM_MMS_CALI_INST_GRP_4 = "CALI_INST_GRP_4";
        public const string MP_GCM_MMS_CALI_INST_GRP_5 = "CALI_INST_GRP_5";
        public const string MP_GCM_MMS_CALI_INST_GRP_6 = "CALI_INST_GRP_6";
        public const string MP_GCM_MMS_CALI_INST_GRP_7 = "CALI_INST_GRP_7";
        public const string MP_GCM_MMS_CALI_INST_GRP_8 = "CALI_INST_GRP_8";
        public const string MP_GCM_MMS_CALI_INST_GRP_9 = "CALI_INST_GRP_9";
        public const string MP_GCM_MMS_CALI_INST_GRP_10 = "CALI_INST_GRP_10";

        public const string MP_GCM_MMS_EQUIP_GRP_1 = "MMS_EQUIP_GRP_1";
        public const string MP_GCM_MMS_EQUIP_GRP_2 = "MMS_EQUIP_GRP_2";
        public const string MP_GCM_MMS_EQUIP_GRP_3 = "MMS_EQUIP_GRP_3";
        public const string MP_GCM_MMS_EQUIP_GRP_4 = "MMS_EQUIP_GRP_4";
        public const string MP_GCM_MMS_EQUIP_GRP_5 = "MMS_EQUIP_GRP_5";
        public const string MP_GCM_MMS_EQUIP_GRP_6 = "MMS_EQUIP_GRP_6";
        public const string MP_GCM_MMS_EQUIP_GRP_7 = "MMS_EQUIP_GRP_7";
        public const string MP_GCM_MMS_EQUIP_GRP_8 = "MMS_EQUIP_GRP_8";
        public const string MP_GCM_MMS_EQUIP_GRP_9 = "MMS_EQUIP_GRP_9";
        public const string MP_GCM_MMS_EQUIP_GRP_10 = "MMS_EQUIP_GRP_10";

        public const string MP_WIP_CREATE_CODE = "CREATE_CODE";
        public const string MP_WIP_OWNER_CODE = "OWNER_CODE";
        public const string MP_WIP_LOT_TYPE = "LOT_TYPE";
        public const string MP_WIP_SUBLOT_TYPE = "SUBLOT_TYPE";
        public const string MP_WIP_MATERIAL_TYPE = "MATERIAL_TYPE";
        public const string MP_WIP_MATERIAL_PACKTYPE = "MATERIAL_PACK_TYPE";
        public const string MP_WIP_OPTIONAL_FLOW_GROUP = "OPTIONAL_FLOW_GROUP";
        public const string MP_WIP_OPTIONAL_OPER_GROUP = "OPTIONAL_OPER_GROUP";
        
        public const string MP_WIP_UNIT_TABLE = "UNIT";
        public const string MP_WIP_SHIP_CODE = "SHIP_CODE";
        public const string MP_WIP_HOLD_CODE = "HOLD_CODE";
        public const string MP_WIP_REPAIR_CODE = "REPAIR_CODE";
        public const string MP_WIP_RESULT_CODE = "RESULT_CODE";
        public const string MP_WIP_ACTION_CODE = "ACTION_CODE";
        public const string MP_WIP_RELEASE_CODE = "RELEASE_CODE";
        public const string MP_WIP_ORDER_STATUS = "ORDER_STATUS";
        public const string MP_WIP_TERMINATE_CODE = "TERMINATE_CODE";
        public const string MP_WIP_CV_CODE = "CV_CODE";
        public const string MP_WIP_LOT_DEFECT_CODE = "LOT_DEFECT_CODE";
        public const string MP_WIP_SUBLOT_GRADE = "SUBLOT_GRADE";
        public const string MP_WIP_BIN_RELEASE_CODE = "BIN_RELEASE_OPT";
        public const string MP_WIP_QUEUE_TIME_RELEASE_CODE = "QTM_RELEASE_OPT";
        
        public const string MP_RAS_RES_TYPE = "RES_TYPE";
        public const string MP_RAS_SUBRES_TYPE = "SUBRES_TYPE";
        public const string MP_RAS_AREA_CODE = "AREA";
        public const string MP_RAS_SUBAREA_CODE = "SUB_AREA";
        public const string MP_RAS_WORK_POSITION = "WORK_POSITION";
        public const string MP_RAS_CHAMBER_GROUP = "CHAMBER_GROUP";
        public const string MP_RAS_PM_PERIOD = "PM_PERIOD";
        public const string MP_RAS_PM_EVENT = "PM_EVENT";
        
        //Add by Kelly Jung 20121224 Merry Christmas~~~!!!!!
        //for PM Schedule. select group1~10
        public const string MP_RAS_RES_GROUP_TYPE = "RES_GROUP_TYPE";
        
        public const string MP_RAS_CRR_TYPE1 = "CRR_TYPE1";
        public const string MP_RAS_CRR_TYPE2 = "CRR_TYPE2";
        public const string MP_RAS_CRR_TYPE3 = "CRR_TYPE3";
        
        public const string MP_ATTR_TYPE_TABLE = "ATTRIBUTE_TYPE";
        
        
        public const string MP_RMA_CREATE_CODE = "RMA_CREATE_CODE";
        public const string MP_RMA_RESULT_CODE = "RMA_RESULT_CODE";
        public const string MP_ARCHIVE_MODULE = "ARCHIVE_MODULE";
        
        //POP
        public const string MP_POP_PRINTER_TYPE = "PRINTER_TYPE";
        public const string MP_POP_RESOLUTION = "RESOLUTION";
        public const string MP_POP_TEXT_FONT = "TEXT_FONT";
        public const string MP_POP_BARCODE_FONT = "BARCODE_FONT";
        public const string MP_POP_PRINT_VARIABLE = "PRINT_VARIABLE";
        public const string MP_POP_ROTATE = "ROTATE";
        public const string MP_GCM_CUSTOMER = "CUSTOMER";
        
        //TOOL
        public const string MP_RAS_TOOL_STATUS = "TOOL_STATUS";
        public const string MP_RAS_TOOL_GRP = "TOOL_GRP";
        public const string MP_RAS_TOOL_GRADE = "TOOL_GRADE";
        public const string MP_RAS_TOOL_DEFECT = "TOOL_DEFECT";
        
        //PORT
        public const string MP_RAS_PORT_STATE = "PORT_STATE";
        public const string MP_RAS_PORT_TYPE = "PORT_TYPE";
        
        //QCM
        public const string MP_QCM_SMP_PROC_TYPE = "SMP_PROC_TYPE";
        public const string MP_QCM_INSP_METHOD = "QCM_INSP_METHOD";
        public const string MP_QCM_DEFECT_GRP = "QCM_DEFECT_GRP";
        public const string MP_QCM_INSP_TYPE = "QCM_INSP_TYPE";
        public const string MP_QCM_VENDOR = "QCM_VENDOR";
        public const string MP_QCM_CUSTOMER = "QCM_CUSTOMER";

        //WFM
        public const string MP_WFM_NODE_TYPE = "WFM_NODE_TYPE";

        public const string MP_GCM_TABLE_GROUP = "GCM_TABLE_GROUP";
        public const string MP_SEC_FUNCTION_GROUP = "FUNCTION_GROUP";
        public const string MP_SEC_PROGRAM_LIST = "PROGRAM_LIST";

        //EDC
        public const string MP_EDC_UNIT_TABLE = "EDC_UNIT"; // Character Unit Table

        //SHEET
        public const string MP_SHEET_EVENT = "SHEET_EVENT";

        public const string MP_SHEET_QUERY_TYPE = "SHEET_QUERY_TYPE";
        public const string MP_SHEET_SHEET_TYPE = "SHEET_SHEET_TYPE";
        public const string MP_SHEET_DATA_TYPE = "SHEET_DATA_TYPE";

        public const string MP_SHEET_TYPE_DEFINE = "SHEET_TYPE_DEFINE";
        public const string MP_SHEET_TRAN_DEFINE = "SHEET_TRAN_DEFINE";

        public const string MP_SHEET_GRP_CAPTION = "GROUP_CAPTION";
        public const string MP_SHEET_GRP_TABLE = "GROUP_TABLE";

        public const string MP_SHEET_TRN_CAPTION = "TRAN_CAPTION";
        public const string MP_SHEET_TRN_TABLE = "TRAN_TABLE";
        //ID
        public const string MP_ID_GEN_TYPE = "ID_GEN_TYPE";
        public const string MP_ID_GEN_TRAN_CODE = "ID_GEN_TRAN_CODE";

        //Batch
        public const string MP_BATCH_TYPE = "BATCH_TYPE";

        public const string MP_FUNC_KEY_TYPE = "FUNC_KEY_TYPE";

        //Future Action
        public const string MP_FAC_OA_SERVICES = "FAC_OA_SERVICES";

        public const string MP_BIN_DATA_1 = "__BIN_DATA_1";
        public const string MP_BIN_DATA_2 = "__BIN_DATA_2";
        public const string MP_BIN_DATA_3 = "__BIN_DATA_3";
        public const string MP_BIN_DATA_4 = "__BIN_DATA_4";
        public const string MP_BIN_DATA_5 = "__BIN_DATA_5";
        public const string MP_BIN_DATA_6 = "__BIN_DATA_6";
        public const string MP_BIN_DATA_7 = "__BIN_DATA_7";
        public const string MP_BIN_DATA_8 = "__BIN_DATA_8";
        public const string MP_BIN_DATA_9 = "__BIN_DATA_9";
        public const string MP_BIN_DATA_10 = "__BIN_DATA_10";

        //Flexible Group
        public const string MP_SCREEN_GRP = "SCREEN_GROUP";

        //Sheet Setup
        public const string MP_DOC_TYPE = "DOC_TYPE";
        public const string MP_PAPER_TYPE = "PAPER_TYPE";        

        //FMB
        public const string MP_FMB_HOST_INFO = "FMB_HOST_INFO";

        //Master Code
        public const string MP_MASTER_CODE = "MASTER_CODE";

        //BIN
        public const string MP_WIP_BIN_TRANS_CODE = "BIN_TRAN_CODE";
        public const string MP_WIP_BIN_CALC_TYPE = "BIN_CALC_TYPE";
        public const string MP_WIP_BIN_YIELD_BASE = "BIN_YIELD_BASE";
        public const string MP_WIP_BIN_SEQ = "BIN_SEQ";
        public const string MP_WIP_BIN_PROMPT = "BIN_PROMPT";
        public const string MP_WIP_BIN_TYPE = "BIN_TYPE";
        public const string MP_WIP_BIN_YESNO = "BIN_GCM_YESNO";
        public const string MP_WIP_BIN_OPERATOR = "BIN_OPERATOR";

        //FORMAT        
        public const string MP_GCM_FORMAT_GRP_1 = "FORMAT_GRP_1";
        public const string MP_GCM_FORMAT_GRP_2 = "FORMAT_GRP_2";
        public const string MP_GCM_FORMAT_GRP_3 = "FORMAT_GRP_3";
        public const string MP_GCM_FORMAT_GRP_4 = "FORMAT_GRP_4";
        public const string MP_GCM_FORMAT_GRP_5 = "FORMAT_GRP_5";
        public const string MP_GCM_FORMAT_GRP_6 = "FORMAT_GRP_6";
        public const string MP_GCM_FORMAT_GRP_7 = "FORMAT_GRP_7";
        public const string MP_GCM_FORMAT_GRP_8 = "FORMAT_GRP_8";
        public const string MP_GCM_FORMAT_GRP_9 = "FORMAT_GRP_9";
        public const string MP_GCM_FORMAT_GRP_10 = "FORMAT_GRP_10";

        //TEMPLATE        
        public const string MP_GCM_TEMPLATE_GRP_1 = "TEMPLATE_GRP_1";
        public const string MP_GCM_TEMPLATE_GRP_2 = "TEMPLATE_GRP_2";
        public const string MP_GCM_TEMPLATE_GRP_3 = "TEMPLATE_GRP_3";
        public const string MP_GCM_TEMPLATE_GRP_4 = "TEMPLATE_GRP_4";
        public const string MP_GCM_TEMPLATE_GRP_5 = "TEMPLATE_GRP_5";
        public const string MP_GCM_TEMPLATE_GRP_6 = "TEMPLATE_GRP_6";
        public const string MP_GCM_TEMPLATE_GRP_7 = "TEMPLATE_GRP_7";
        public const string MP_GCM_TEMPLATE_GRP_8 = "TEMPLATE_GRP_8";
        public const string MP_GCM_TEMPLATE_GRP_9 = "TEMPLATE_GRP_9";
        public const string MP_GCM_TEMPLATE_GRP_10 = "TEMPLATE_GRP_10";

        public const string MP_GCM_MENU_GROUP = "MENU_GROUP";
        public const string MP_GCM_TRAN_CODE = "TRAN_CODE";

        //Inventory
        public const string MP_GCM_OPER_TYPE = "OPER_TYPE";
        public const string MP_GCM_INV_MAT_TYPE = "INV_MAT_TYPE";
        public const string MP_GCM_INV_IN_TYPE = "INV_IN_TYPE";
        public const string MP_GCM_INV_IN_REASON = "INV_IN_RSN";
        public const string MP_GCM_INV_TRAN_TYPE = "INV_TRAN_TYPE";
        public const string MP_GCM_INV_OUT_TYPE = "INV_OUT_TYPE";
        public const string MP_GCM_INV_ERP_IN_TYPE = "INV_ERP_IN";
        public const string MP_GCM_INV_ERP_VENDOR = "INV_ERP_VENDOR";
        public const string MP_GCM_INV_ETC_IN_TYPE = "INV_ETC_IN_TYPE";
        public const string MP_GCM_INV_ETC_IN_REASON = "INV_ETC_IN_RSN";
        public const string MP_GCM_INV_ETC_OUT_TYPE = "INV_ETC_OUT_TYPE";
        public const string MP_GCM_INV_ETC_OUT_REASON = "INV_ETC_OUT_RSN";
        public const string MP_GCM_INV_LOCATION = "LOCATION";
        public const string MP_GCM_INV_BARCODE_RESOLUTION = "INV_BCODE_RESOLUTION";
        public const string MP_GCM_INV_INS_REQUESTER = "INV_INS_REQUESTER";
        public const string MP_GCM_INV_INS_PRIORITY = "INV_INS_PRIORITY";
        public const string MP_GCM_INV_REQ_PRIORITY = "INV_REQ_PRIORITY";
        public const string MP_GCM_INV_TRS_PRIORITY = "INV_TRS_PRIORITY";
        public const string MP_GCM_INV_PASS_FLAG = "INV_PASS_FLAG";
        public const string MP_GCM_INV_LOSS_TYPE = "INV_LOSS_TYPE";
        public const string MP_GCM_INV_LOSS_CODE = "INV_LOSS_CODE";
        public const string MP_GCM_INV_SPARE_TYPE = "MNT_SPARE_TYPE";
        public const string MP_GCM_INV_SPARE_MODEL = "MNT_MODEL";
        public const string MP_GCM_INV_MATERIAL_TYPE = "INV_MATERIAL_TYPE";
        public const string MP_GCM_INV_UNIT_TABLE = "INV_UNIT";
        //BIN Definition Group Table 1~10
        public const string MP_GCM_BIN_DEF_GRP_1 = "BIN_DEF_GRP_1";
        public const string MP_GCM_BIN_DEF_GRP_2 = "BIN_DEF_GRP_2";
        public const string MP_GCM_BIN_DEF_GRP_3 = "BIN_DEF_GRP_3";
        public const string MP_GCM_BIN_DEF_GRP_4 = "BIN_DEF_GRP_4";
        public const string MP_GCM_BIN_DEF_GRP_5 = "BIN_DEF_GRP_5";
        public const string MP_GCM_BIN_DEF_GRP_6 = "BIN_DEF_GRP_6";
        public const string MP_GCM_BIN_DEF_GRP_7 = "BIN_DEF_GRP_7";
        public const string MP_GCM_BIN_DEF_GRP_8 = "BIN_DEF_GRP_8";
        public const string MP_GCM_BIN_DEF_GRP_9 = "BIN_DEF_GRP_9";
        public const string MP_GCM_BIN_DEF_GRP_10 = "BIN_DEF_GRP_10";
        //Add by JJ OH 2013-01-15
        //For Lot Definition (GCM Table)
        public const string MP_GCM_INV_LOT_TYPE = "INV_LOT_TYPE";

        //Add by Kelly Jung 20121225
        //for Lot Extension Definition (GCM Table)
        public const string MP_GCM_LOT_EXTENSION = "LOT_EXTENSION";
        public const string MP_GCM_YESNO = "YESNO";

        //Add by yk.Yoo 2023.03.09 
        //MMS Definition
        public const string MP_GCM_MMS_ITEM_GROUP = "MMS_ITEM_GROUP";
        public const string MP_GCM_MMS_SAMPLE_GROUP = "MMS_SAMPLE_GROUP";
        //public const string MP_GCM_MMS_USE_GROUP = "MMS_USE_GROUP";
        //public const string MP_GCM_MMS_MGR_GROUP = "MMS_MGR_GROUP";
        //public const string MP_GCM_MMS_CALI_INSTITUTE = "MMS_CALI_INSTITUTE";
        //public const string MP_GCM_MMS_CALI_DIV = "MMS_CALI_DIV";
        //public const string MP_GCM_MMS_TOOL = "MMS_TOOL";
        public const string MP_GCM_MMS_UNIT = "MMS_UNIT";
        public const string MP_GCM_MMS_DEPT_CODE = "MMS_DEPT_CODE";
        public const string MP_GCM_MMS_USE_DIV = "MMS_USE_DIV";
        public const string MP_GCM_MMS_PLACE_CODE = "MMS_PLACE_CODE";
        public const string MP_GCM_MMS_ALARM_CODE = "MMS_ALARM_CODE";
        public const string MP_GCM_MMS_ANA_METHOD = "MMS_ANALYSIS_METHOD"; //2023.04.10 ∫–ºÆ πÊπ˝ √ﬂ∞°
        //public const string MP_GCM_MMS_ANA_STATUS = "MMS_ANALYSIS_STATUS"; //2023.04.10 ªÛ≈¬ √ﬂ∞°
        public const string MP_GCM_MMS_RESULT_TYPE = "MMS_RESULT_TYPE"; //2023.05.04 √ﬂ∞° 
        public const string MP_GCM_MMS_EQUIP_TYPE = "MMS_EQUIP_TYPE"; //2023.05.08 √ﬂ∞° 


        //Add by yk.Yoo 2023.05.26
        //AUDIT GCM Table Definition
        public const string MP_GCM_AMS_CUSTOMER = "AMS_CUSTOMER";
        public const string MP_GCM_AMS_AUDIT_STATUS = "AMS_AUDIT_STATUS";
        public const string MP_GCM_AMS_ITEM_DIV = "AMS_ITEM_DIV";
        public const string MP_GCM_AMS_MANAGER = "AMS_MANAGER";
        public const string MP_GCM_AMS_USER = "AMS_USER";

        #endregion
        
        #region "Resource Status"
        
        //Status
        public const string MP_RESOURCE_STATUS_WAIT = "WAIT";
        public const string MP_RESOURCE_STATUS_PROC = "PROC";
        public const string MP_DEFAULT_RESOURCE_STATUS = "WAIT";
        
        #endregion
        
        #region "Resource Up/Down status"
        
        public const char MP_RES_UP_FLAG = 'U';
        public const char MP_RES_DOWN_FLAG = 'D';
        public const char MP_DEFAULT_RES_UP_DOWN_FLAG = 'U';
        
        #endregion
        
        #region "Lot Status"
        
        public const string MP_LOT_STATUS_WAIT = "WAIT";
        public const string MP_LOT_STATUS_PROC = "PROC";
        public const string MP_LOT_STATUS_RESV = "RESV";
        
        #endregion
        
        #region "Attach Character to Version, Unit MAX and Value MAX "
        
        public const int MP_UNIT_COUNT_MAX = 500;
        public const int MP_VALUE_COUNT_MAX = 1000;
        
        #endregion
        
        #region "Caption & Error Message XML File"
        public const string MP_CAPTION_FILE = "MESCaption.xml";
        public const string MP_MESSAGE_FILE = "MESMessage.xml";
        
        #endregion
        
        #region "ToolBar and Image Index"
        
        public const int MESSAGE_INDEX = 34;                // <<Check>> ªÁøÎ«œ¥¬∞˜¿Ã æ¯¿Ω
        public const int MESSAGE_OPEN_ICON_INDEX = 51;      // <<Check>> ªÁøÎ«œ¥¬∞˜¿Ã æ¯¿Ω 
        public const int MESSAGE_CLOSE_ICON_INDEX = 52;     // <<Check>> ªÁøÎ«œ¥¬∞˜¿Ã æ¯¿Ω
        
        #endregion
        
        #region "Privilege Type"
        public const string MP_PRV_TYPE_RES = "RESOURCE";
        public const string MP_PRV_TYPE_OPER = "OPERATION";
        public const string MP_PRV_TYPE_GCMTBL = "GCMTABLE";
        public const string MP_PRV_TYPE_SERVICE = "SERVICE";
        public const string MP_PRV_TYPE_ATTR = "ATTRIBUTE";
        #endregion
        
        #region "Print Font"
        //Type
        public const string POP_TYPE_TEXT = "T";
        public const string POP_TYPE_BARCODE = "B";
        public const string POP_TYPE_IMAGE = "I";
        public const string POP_TYPE_GRAPHIC = "G";
        public const string POP_TYPE_COMMAND = "C";
        
        //Rotate
        public const string POP_ROTATE_NORMAL = "N";
        public const string POP_ROTATE_ROTATED = "R";
        public const string POP_ROTATE_INVERTED = "I";
        public const string POP_ROTATE_BOTTOMUP = "B";
        
        //Barcode Font

        public const string POP_BAR_FONT_93 = "A";
        public const string POP_BAR_FONT_128 = "C";
        public const string POP_BAR_FONT_3OF9 = "3";
        public const string POP_BAR_FONT_PDF417 = "7";
        public const string POP_BAR_FONT_EAN_8 = "8";
        public const string POP_BAR_FONT_UPC_E = "9";
        public const string POP_BAR_FONT_EAN_13 = "E";
        public const string POP_BAR_FONT_UPC_A = "U";
        public const string POP_BAR_FONT_2D_BARCODE = "X";
        public const string POP_BAR_FONT_2DM_BARCODE = "M";        
        
        //Print Port
        public const string POP_PRINT_PORT_LPT = "LPT";
        public const string POP_PRINT_PORT_COM = "COM";
        public const string POP_PRINT_PORT_USB = "USB";
        public const string POP_PRINT_PORT_TCP = "TCP";
        
        // Communication Value.
        public const int STX = 0x2; // Start of Text
        public const int ETX = 0x3; // End of Text
        public const int CR = 0xD; // Carriage Return
        public const int LF = 0xA; // Line Feed
        public const int HT = 0x9; // Horizontal Tab
        
        
        // Print Status Í¥Ä??Î≥Ä??
        public static string s_PrtStatus; // ?ÑÎ¶∞???ÅÌÉúÍ∞?Check.
        public static List<byte> bl_PrtStatus;
        public static bool b_InputSTX; // STX Í∞Ä?§Ïñ¥?îÎäîÏßÄ ?†Î¨¥.
        public const int i_BufFull = 50; // Receive Buffer Full Check Count.
        public const string s_TimeOut = "05"; // Print Status Check-Out Timeout
        
        public const double PRINT_200_DPM = 8; //Dots per Milimeter(200DPI)
        public const double PRINT_300_DPM = 12; //Dots per Milimeter(300DPI)
        
        #endregion
                
        #region "Prompt"
        public const char PROMPT_ASCII = 'A';
        public const char PROMPT_NUMBER = 'N';
        public const char PROMPT_FLOAT = 'F';
        #endregion

        #region "Alarm"
        
        //Alarm Type
        public const char MP_ALM_NORMAL = 'N';
        public const char MP_ALM_RESOURCE = 'R';
        public const char MP_ALM_AUTO_GATHER = 'A';
        
        //Alarm Level
        public const char MP_ALM_LEVEL_INFO = 'I';
        public const char MP_ALM_LEVEL_WARN = 'W';
        public const char MP_ALM_LEVEL_ERROR = 'E';

        //Alarm Transaction Point
        public const char MP_ALM_TRAN_START = 'S';
        public const char MP_ALM_TRAN_SPLIT = 'P';
        public const char MP_ALM_TRAN_END = 'E';
        public const char MP_ALM_TRAN_REWORK = 'R';
        public const char MP_ALM_TRAN_START_AFTER = '1';
        public const char MP_ALM_TRAN_SPLIT_AFTER = '2';
        public const char MP_ALM_TRAN_END_AFTER = '3';
        public const char MP_ALM_TRAN_REWORK_AFTER = '4';
        

        #endregion
        
        #region "QCM"
        
        //Sampling type
        public const string MP_QCM_SMP_TYPE_MANUAL = "MN";
        public const string MP_QCM_SMP_TYPE_TOTAL_INSPECTION = "TI";
        public const string MP_QCM_SMP_TYPE_FIXED_SAMPLE = "FS";
        public const string MP_QCM_SMP_TYPE_USED_PERCENTAGE = "UP";
        public const string MP_QCM_SMP_TYPE_USED_SCHEME = "US";
        
        //Inspection type
        public const string MP_QCM_INSP_TYPE_IQC = "IQC";
        public const string MP_QCM_INSP_TYPE_PQC = "PQC";
        public const string MP_QCM_INSP_TYPE_OQC = "OQC";
        public const string MP_QCM_INSP_TYPE_RMA = "RMA";
        
        //Inspection type
        public const string MP_QCM_INSP_METHOD_I = "INDIVIDUAL";
        public const string MP_QCM_INSP_METHOD_Q = "QUANTITY";
        
        //Final Decision
        public const string MP_QCM_DECISION_REJECT = "REJECT";
        public const string MP_QCM_DECISION_ACCEPT = "ACCEPT";
        
        #endregion
        
        #region "SUBLOT"
        public const string MP_SUBLOT_GOOD_GRADE = "G";
        public const string MP_SUBLOT_SCRAP_GRADE = "S";
        #endregion

        #region "MFO OPTION"
        public const string MP_MFO_EXT_LOSS_TBL_DEF = "EXT_LOSS_TBL_DEF";
        public const string MP_MFO_EXT_BONUS_TBL_DEF = "EXT_BONUS_TBL_DEF";
        public const string MP_MFO_EXT_LOT_DEFECT_TBL = "EXT_LOT_DEFECT_TBL";
        public const string MP_MFO_MENU_RELATION = "MENU_RELATION";
        //////public const string MP_MFO_EXT_REWORK_TBL_DEF = "EXT_REWORK_TBL_DEF";
        //////public const string MP_MFO_EXT_HOLD_TBL_DEF = "EXT_HOLD_TBL_DEF";
        //////public const string MP_MFO_EXT_RELEASE_TBL_DEF = "EXT_RELEASE_TBL_DEF";
        //////public const string MP_MFO_EXT_TERM_TBL_DEF = "EXT_TERM_TBL_DEF";
        #endregion      
        
        #region "WIN API"
        
        public const int LVM_FIRST = 0x1000;
        public const int LVM_SETCOLUMN = (LVM_FIRST + 26);
        public const int LVM_GETHEADER = (LVM_FIRST + 31);
        
        public const int HDI_FORMAT = 0x1;
        public const int HDI_IMAGE = 0x10;
        
        public const int HDF_LEFT = 0x0;
        public const int HDF_RIGHT = 0x1;
        public const int HDF_CENTER = 0x2;
        public const int HDF_JUSTIFYMASK = 0x3;
        public const int HDF_RTLREADING = 0x4;
        public const int HDF_SORTDOWN = 0x200;
        public const int HDF_SORTUP = 0x400;
        public const int HDF_IMAGE = 0x800;
        public const int HDF_BITMAP_ON_RIGHT = 0x1000;
        public const int HDF_BITMAP = 0x2000;
        public const int HDF_STRING = 0x4000;
        public const int HDF_OWNERDRAW = 0x8000;
        
        public const int HDM_FIRST = 0x1200;
        public const int HDM_SETITEM = (HDM_FIRST + 4);
        public const int HDM_SETIMAGELIST = (HDM_FIRST + 8);
        
        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]public struct LVCOLUMN
        {
            public int mask;
            public int fmt;
            public int cx;
            public IntPtr pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }
        
        [DllImport("User32.dll")]public static  extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        [DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref LVCOLUMN lParam);
        
        [DllImport("User32.dll", CharSet = CharSet.Auto)]public static  extern int ShowWindow(IntPtr hWnd, short cmdShow);
        
        #endregion

        #region "Archive ∞¸∑√"

        //'Archive º“Ω∫ ¿⁄∑· ªË¡¶ ø©∫Œ
        public const string ARC_SOURCE_DELETE = "D";
        public const string ARC_SOURCE_UNDELETE = "U";

        //'Rollback segment ªÁøÎ ø©∫Œ
        public const string ARC_ROLLBACK_USE = "R";
        public const string ARC_ROLLBACK_NOTUSE = "N";

        //'Running archive value
        public const string ARC_RUNNING = "Y";

        //'Archive Backup Type
        public const string ARC_BACKUP_FILE = "F";
        public const string ARC_BACKUP_DB = "D";
        public const string ARC_BACKUP_FILE_DB = "B";

        #endregion

        #region "Admin ∞¸∑√"

        public const int MP_AUTO_REFRESH_TIME = 30;  //Auto Refresh Time (Sec)

        //'º≠πˆ ∏¥œ≈Õ∏µΩ√ º≠πˆ∑Œ∫Œ≈Õ ¿¿¥‰ªÛ≈¬∏¶ ≥™≈∏≥ø
        public const int ADM_IDLE_STATUS = 0;    //IDLE ªÛ≈¬
        public const int ADM_REQUEST_STATUS = 1;    //º≠πˆø° ø‰√ª¿ª «—ªÛ≈¬
        public const int ADM_REPLY_STATUS = 2;   //º≠πˆ∑Œ∫Œ≈Õ ¿¿¥‰¿ª πﬁ¿Ω

        //'√÷¥Î Request ∞πºˆ
        public const int ADM_MAX_REQUEST_CNT = 1000;

        //'GCM Table List
        public const string MP_GCM_SERVER_LIST = "SERVER_LIST";

        public const string MP_LOCAL_HOST = "LOCALHOST";
        public const string MP_DEFAULT_IP = "DEFAULT";
        #endregion

        #region "Attribute Type"
        public const string MP_ATTR_TYPE_LOT = "LOT";
        public const string MP_ATTR_TYPE_RESOURCE = "RESOURCE";
        public const string MP_ATTR_TYPE_SUBLOT = "SUBLOT";
        public const string MP_ATTR_TYPE_BOM = "BOM";
        public const string MP_ATTR_TYPE_MATERIAL = "MATERIAL";
        public const string MP_ATTR_TYPE_FLOW = "FLOW";
        public const string MP_ATTR_TYPE_OPER = "OPER";
        public const string MP_ATTR_TYPE_FACTORY = "FACTORY";
        public const string MP_ATTR_TYPE_CARRIER = "CARRIER";
        /*** #989 SPM Development (2012.04.25 by JYPARK) ***/
        public const string MP_ATTR_TYPE_SPEC = "SPEC";
        /*** End of Add (2012.04.25) ***/

        public const string MP_SYS_ATTR_BIN_HOLD_CODE = "MP_BIN_HOLD_CODE";
        public const string MP_SYS_ATTR_QUEUE_TIME_HOLD_CODE = "MP_QUEUE_TIME_HOLD_CODE";

        #endregion

        #region "CONVERT TYPE"

        public const string MP_CONVERT_DATE_FORMAT = "DATE";            // "yyyyMMdd" Format
        public const string MP_CONVERT_HYPHENDATE_FORMAT = "HYPHENDATE";// "yyyy-MM-dd" Format
        public const string MP_CONVERT_SLASHDATE_FORMAT = "SLASHDATE";  // "yyyy/MM/dd" Format
        public const string MP_CONVERT_NODAYDATE_FORMAT = "NODAYDATE";  // "yyyyMM Format for monthly report
        public const string MP_CONVERT_TIME_FORMAT = "TIME";            // "HHmmss" Format
        public const string MP_CONVERT_DATETIME_FORMAT = "DATETIME";    // "yyyyMMddHHmmss" Format
        public const string MP_CONVERT_YEAR_FORMAT = "YEAR";            // "yyyy" Format
        public const string MP_CONVERT_MONTH_FORMAT = "MONTH";          // "MM" Format
        #endregion

        #region "ETC Constant"

        public const int EXCEL_MAX_COL = 255; //(EXCel?êÏÑú ?àÏö©?òÎäî ÏµúÎ? Column??-1)
        public const int MP_MAX_SLOT_CNT = 1000; //ÏµúÎ? Slot Í∞?àò
        public const int MP_MAX_BATCH_CNT = 12; //Batch???¨Ìï®?†Ïàò ?àÎäî Lot??ÏµúÎ? Í∞úÏàò

        public const string MP_SYS_DOCK_MENU = "SYS_MENU_MENU";
        public const string MP_SYS_DOCK_FAVORITES = "SYS_MENU_FAVORITES";
        public const string MP_SYS_DOCK_OPERATION = "SYS_MENU_OPERATION";
        public const string MP_SYS_DOCK_RESOURCE = "SYS_MENU_RESOURCE";
        public const string MP_SYS_DOCK_DISPATCHER = "SYS_MENU_DISPATCHER";
        public const string MP_SYS_DOCK_BBS = "SYS_MENU_BBS";

        //Public Const FONT_NAME As String = "Íµ¥Î¶º"
        //Public Const FONT_SIZE As Single = 9.0

        public const int SP_MAX_COLUMN_WIDTH = 500;
        public const int SP_MIN_COLUMN_WIDTH = 20;

        public const int LV_MAX_COLUMN_WIDTH = 500;
        public const int LV_MIN_COLUMN_WIDTH = 50;
        public const int LV_MAX_LIST_COUNT = 20;
        public const int LV_BONUS_LISTVIEW_HEIGHT = 2;
        public const int LV_BONUS_COLUMN_WIDTH = 4;
        public const int LV_BONUS_COLUMN_WIDTH_WITH_IMAGE = 2;

        public const int MP_MDI_CHILD_HEIGHT = 580; //MDI Child Form???íÏù¥
        public const int MP_MDI_CHILD_WIDTH = 750; //MDI Child Form????

        public const double MP_MAX_QTY = 9999999.999; //Max Qty
        public const double MP_MIN_QTY = -9999999.999; //Min Qty

        public const string MP_DONT_CHECK_PASSWORD = "DO_NOT_CHECK_PASSWORD";

        public const int MP_MAX_GDI_COUNT = 8000;

        public const string MP_PAPER_TYPE_CUSTOM = "CUSTOM_TYPE";

        #endregion

        #region "QA∞¸∑√"

        public const string ACTION_RULE = "ACT_RULE";
        public const string SAMPLE_RULE = "SMP_RULE";

        public const string TAP_QA_RULE_TYPE = "QA_RULE_TYPE";
        public const string TAP_QA_SMP_TYPE = "QA_SMP_TYPE";
        public const string TAP_QA_SMP_QTY_TYPE = "QA_SMP_QTY_TYPE";
        public const string TAP_QA_SMP_SEL_TYPE = "QA_SMP_SEL_TYPE";

        public const string TAP_ACTION_RULE = "ACT_RULE";
        public const string TAP_SAMPLE_RULE = "SMP_RULE";
        public const string TAP_QA_RESULT = "QA_RESULT";
        public const string TAP_QA_PROTECT = "QA_PROTECT";
        public const string TAP_CMF_QA_ACTION_RULE = "CMF_QA_ACT_RULE";
        public const string TAP_CMF_QA_SAMPLE_RULE = "CMF_QA_SMP_RULE";
        public const string TAP_CMF_TRN_QA_GATE = "CMF_TRN_QA_GATE";
        public const string TAP_TEST_TYPE = "TEST_TYPE";

        public const string TAP_QA_SMP_SIZE_TYPE_U = "UNIT";
        public const string TAP_QA_SMP_SIZE_TYPE_U_1 = "UNIT1";
        public const string TAP_QA_SMP_SIZE_TYPE_U_2 = "UNIT2";
        public const string TAP_QA_SMP_SIZE_TYPE_U_12 = "UNIT1/2";
        public const string TAP_QA_SMP_SIZE_TYPE_SLOT = "SUBLOT";

        public const string TAP_QA_SMP_QTY_TYPE_A = "ALL";
        public const string TAP_QA_SMP_QTY_TYPE_AQL = "AQL";
        public const string TAP_QA_SMP_QTY_TYPE_M = "MANUAL";
        public const string TAP_QA_SMP_QTY_TYPE_S = "STATIC";
        public const string TAP_QA_SMP_QTY_TYPE_R = "RANDOM";
        public const string TAP_QA_SMP_QTY_TYPE_QTY = "By Qty";
        public const string TAP_QA_SMP_QTY_TYPE_PC = "By %";

        public const string TAP_QA_SMP_SEL_TYPE_M = "MANUAL";
        public const string TAP_QA_SMP_SEL_TYPE_R = "RANDOM";
        public const string TAP_QA_SMP_SEL_TYPE_S = "STATIC";

        public const string TAP_QA_LOC_CELL = "QA_LOC_CELL";

        public const string TAP_YESORNO = "YESNO";

        public const string s_loss_table = "LOSS_CODE";
        public const string ACT_RULE_SKIP = "SKIP";
        public const string PASS_FLAG_DESC = "Pass Count For Skip";
        public const string ACT_RULE_FAIL = "FAIL";

        public const int MP_SAMPLE_RULE_COUNT_25 = 25;
        public const int MP_SAMPLE_RULE_COUNT_50 = 50;
        public const int MP_SAMPLE_RULE_COUNT_75 = 75;
        public const int MP_SAMPLE_RULE_MAX_COUNT = 100;

        # endregion

        #region "Low_Yield∞¸∑√"

        public const string MP_PRIORITY_TYPE_TBL_DEF = "PRIORITY_TYPE";
        public const string MP_LYD_BASE_TBL_DEF = "LYD_BASE_TYPE";
        public const string MP_LYD_TYPE_TBL_DEF = "LYD_TYPE";
        public const string MP_LYD_UNIT_TBL_DEF = "LYD_UNIT";
        public const string MP_LYD_UNIT_TYPE_TBL_DEF = "LYD_UNIT_TYPE";
        public const string MP_LYD_CHECK_TRANS_TBL_DEF = "LYD_CHECK_TRANS";
        public const string MP_LYD_AQL_TYPE_TBL_DEF = "LYD_AQL_TYPE";
        public const string MP_LYD_AQL_TBL_TBL_DEF = "LYD_AQL_TBL";

        public const string MP_CMF_LOW_YIELD = "CMF_LOW_YIELD";
        public const string MP_LYD_BASE_OPER_IN = "OPER_IN";
        public const string MP_LYD_BASE_OPER_START = "OPER_START";
        public const string MP_LYD_BASE_OPER_OUT = "OPER_OUT";
        public const string MP_LYD_BASE_LOT_EXT = "LOT_EXT";
        public const string MP_LYD_BASE_LOT_STS = "LOT_STS";

        public const string MP_LYD_UNIT_TYPE_AQL = "AQL";

        public const string MP_LYD_TYPE_BC = "BC";
        public const string MP_LYD_TYPE_LC = "LC";
        public const string MP_LYD_TYPE_BL = "BL";
        public const string MP_LYD_TYPE_OL = "OL";
        public const string MP_LYD_TYPE_OC = "OC";
        public const string MP_LYD_TYPE_OB = "OB";
        public const string MP_LYD_TYPE_ALL = "ALL";

        # endregion

        #region "Message BBS"

        public const string MP_BBS_MSG_TYPE_ERROR = "ERROR";
        public const string MP_BBS_MSG_TYPE_INFO = "INFO";
        public const string MP_BBS_MSG_TYPE_WARN = "WARN";

        #endregion

        #region Inventory∞¸∑√

        public const string MP_CMF_INV_LOT = "CMF_INV_LOT";

        public const string MP_INV_SCRAP_CODE = "SCRAP_CODE";
        public const string MP_INV_CV_CODE = "INV_CV_CODE";

        //Inspection Flag
        public const string MP_INV_INS_REQUEST = "R";
        public const string MP_INV_INS_ACCEPT = "A";
        public const string MP_INV_INS_FINISH = "I";

        //Inspection Result Flag
        public const string MP_INV_INS_PASS = "P";
        public const string MP_INV_INS_FAIL = "F";
        public const string MP_INV_INS_SPECIAL = "S";

        //Status
        public const string MP_INV_REQUEST_OPEN = "O";
        public const string MP_INV_REQUEST_REVOKE = "R";
        public const string MP_INV_REQUEST_COMPLETE = "C";

        public const char MP_INV_DOC_TYPE_TRANSFER = 'T';
        public const char MP_INV_DOC_TYPE_DELIVER = 'R';

        //Inventory Transaction Code
        public const string MP_INV_TRAN_CODE_IN = "IN";
        public const string MP_INV_TRAN_CODE_TRANSFER = "TRANSFER";
        public const string MP_INV_TRAN_CODE_RELEASE = "RELEASE";
        public const string MP_INV_TRAN_CODE_ADAPT = "ADAPT";
        public const string MP_INV_TRAN_CODE_LOSS = "LOSS";
        public const string MP_INV_TRAN_CODE_IQC = "IQC";
        public const string MP_INV_TRAN_CODE_HOLD = "HOLD";
        public const string MP_INV_TRAN_CODE_CV = "CV";
        public const string MP_INV_TRAN_CODE_DEFECT = "DEFECT";

        #endregion

        #region " Resource ∞¸∑√ "

        public const string MP_RAS_PROC_MODE_FULLAUTO = "FULL AUTO";
        public const string MP_RAS_PROC_MODE_MANUAL = "MANUAL";
        public const string MP_RAS_PROC_MODE_SEMIAUTO = "SEMI AUTO";

        public const string MP_RAS_CTRL_MODE_ONLINELOCAL = "ONLINE LOCAL";
        public const string MP_RAS_CTRL_MODE_ONLINEREMOTE = "ONLINE REMOTE";
        public const string MP_RAS_CTRL_MODE_OFFLINE = "OFFLINE";

        public const string MP_RAS_CTRL_MODE_S_ONLINELOCAL = "OL";
        public const string MP_RAS_CTRL_MODE_S_ONLINEREMOTE = "OR";
        public const string MP_RAS_CTRL_MODE_S_OFFLINE = "OF";

        public const string MP_RAS_PROC_RULE_NORMAL = "NORMAL";
        public const string MP_RAS_PROC_RULE_SERIAL = "SERIAL";
        public const string MP_RAS_PROC_RULE_BATCH = "BATCH";

        public const char MP_RAS_PROC_RULE_C_NORMAL = ' ';
        public const char MP_RAS_PROC_RULE_C_SERIAL = 'S';
        public const char MP_RAS_PROC_RULE_C_BATCH = 'B';

        #endregion
    }
}

