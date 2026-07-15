using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;

namespace BOI.OIFrx
{
    public class BIGC : CMNC
    {
        public const string SL_MODULE_SOL = "SOL";          //신성솔라 Customized Module      

        #region GCM_TABLE

        public const string MP_GCM_MATERIAL_TYPE = "MATERIAL_TYPE";
        public const string B_GCM_B_DAIRY_FARM = "B_DAIRY_FARM";
        public const string B_GCM_B_INV_RSN_DETAIL = "B_INV_RSN_DETAIL";
        public const string B_GCM_B_INV_LOSS_CODE = "B_INV_LOSS_CODE";
        public const string B_GCM_B_MILKCAR_TANK = "B_MILKCAR_TANK";
        public const string B_GCM_B_INV_ACC_DETAIL = "B_INV_ACC_DETAIL";
        public const string B_GCM_B_RMK_MAT_TYPE = "B_@RMK_MAT_TYPE";
        public const string B_GCM_B_DEPT_TEAM = "B_DEPT_TEAM";
        public const string B_GCM_B_VENDOR = "B_VENDOR";
        public const string B_GCM_B_FACTORY_LIST = "B_@FACTORY_LIST";
        public const string B_GCM_AREA = "AREA";
        public const string B_GCM_SUB_AREA = "SUB_AREA";
        public const string B_GCM_B_DAIRY_DIRECTION = "B_DAIRY_DIRECTION";
        public const string B_GCM_B_DAIRY_COMMITTEE = "B_DAIRY_COMMITTEE";
        public const string B_GCM_B_LINE_GROUP = "B_LINE_GROUP";
        public const string B_GCM_B_DAIRY_MILK_STATION = "B_DAIRY_MILK_STATION";
        public const string COM_PORT_TYPE = "COM_PORT_TYPE";
        public const string B_GCM_B_DAIRY_INPUT_RES = "B_DAIRY_INPUT_RES";
        public const string B_GCM_LOSS_CODE = "LOSS_CODE";
        public const string B_GCM_B_H101_TUNER_ENV = "B_H101_TUNER_ENV";
        public const string B_GCM_B_INV_REQ_TYPE = "B_INV_REQ_TYPE";
        public const string B_GCM_B_INV_DLV_TYPE = "B_INV_DLV_TYPE";
        public const string B_GCM_B_DEPT_PART = "B_DEPT_PART";
        public const string B_GCM_B_MHR_WRK_TIME = "B_MHR_WRK_TIME";
        public const string B_GCM_B_MAT_TYPE_GRP = "B_MAT_TYPE_GRP";
        
        #endregion

        #region RES_GROUP

        public const string MP_RES_GROUP_RAWMILKTANK = "RawmilkTank";

        #endregion

        #region FUNC_NAME

        /*CINV*/
             


        /*ORMK*/
        public const string MP_FUNC_NAME_ORMK2001 = "ORMK2001";
        public const string MP_FUNC_NAME_ORMK2002 = "ORMK2002";
        public const string MP_FUNC_NAME_ORMK2003 = "ORMK2003";
        public const string MP_FUNC_NAME_ORMK2006 = "ORMK2006";
        
        /*OINV*/
        public const string MP_FUNC_NAME_OINV1008 = "OINV1008";
        public const string MP_FUNC_NAME_OINV2210 = "OINV2210";
        public const string MP_FUNC_NAME_OINV2212 = "OINV2212";
        public const string MP_FUNC_NAME_OINV2215 = "OINV2215";
        public const string MP_FUNC_NAME_OINV2217 = "OINV2217";


        /*CWIP*/
        public const string MP_FUNC_NAME_CWIP8140 = "CWIP8140";
        public const string MP_FUNC_NAME_CWIP8020 = "CWIP8020";
        public const string MP_FUNC_NAME_CWIP8040 = "CWIP8040";
        public const string MP_FUNC_NAME_CWIP8050 = "CWIP8050";
        public const string MP_FUNC_NAME_CWIP8060 = "CWIP8060";        
        public const string MP_FUNC_NAME_CWIP8070 = "CWIP8070";
        

        public const string MP_FUNC_NAME_CWIP3001 = "CWIP3001";


        public const string MP_FUNC_NAME_CWIP2301 = "CWIP2301";
        public const string MP_FUNC_NAME_CWIP2302 = "CWIP2302";


        public const string MP_FUNC_NAME_CWIP2401 = "CWIP2401";
        public const string MP_FUNC_NAME_CWIP2403 = "CWIP2403";
        public const string MP_FUNC_NAME_CWIP2405 = "CWIP2405";
        public const string MP_FUNC_NAME_CWIP2406 = "CWIP2406";


        public const string MP_FUNC_NAME_CWIP8530 = "CWIP8530";
        public const string MP_FUNC_NAME_CWIP8591 = "CWIP8591";
        public const string MP_FUNC_NAME_CWIP8593 = "CWIP8593";
        public const string MP_FUNC_NAME_CWIP8510 = "CWIP8510";
        
        #endregion

        #region REQUEST_STATUS

        public const char B_REQ_STATUS_REQUEST = 'R';
        public const char B_REQ_STATUS_CONFIRM = 'C';
        public const char B_REQ_STATUS_END = 'E';

        public const string B_REQ_STATUS_REQUEST_DESC = "요청";
        public const string B_REQ_STATUS_CONFIRM_DESC = "확정";        
        public const string B_REQ_STATUS_END_DESC = "마감";
        


        #endregion

        #region REQUEST_TYPE

        public const string B_REQ_TYPE_BASIC = "INV_BAS";
        public const string B_REQ_TYPE_RAWMILK = "INV_RMK";
        public const string B_REQ_TYPE_SHIP = "INV_MOV";
        public const string B_REQ_TYPE_DISPENSE = "INV_DIS";
        public const string B_REQ_TYPE_RETURN = "INV_RTN";

        #endregion

        #region IO_FLAG

        public const char B_IO_FLAG_IN = 'I';
        public const char B_IO_FLAG_OUT = 'O';

        public const string B_IO_FLAG_IN_DESC = "입고";
        public const string B_IO_FLAG_OUT_DESC = "출고";

        #endregion

        #region YES_NO

        public const char B_YES = 'Y';
        public const char B_NO = 'N';

        public const string B_YES_DESC = "Yes";
        public const string B_NO_DESC = "No";

        #endregion

        #region ACCOUNT_DETAIL
        public const string B_INV_ACC_DETAIL_ALL = "ALL"; // 전체

        public const string B_INV_ACC_DETAIL_BUY = "R21"; //구매(매입)입고
        public const string B_INV_ACC_DETAIL_DAIRY_FARM = "R22"; //낙농가입고
        public const string B_INV_ACC_DETAIL_DAIRY_COMMITTEE = "R23"; //낙진회입고
        public const string B_INV_ACC_DETAIL_OTHER_FACTORY = "R41"; //이송(타공장)입고
        public const string B_INV_ACC_DETAIL_TEAM = "R42"; //팀간입고
        public const string B_INV_ACC_DETAIL_RECV_ETC = "R51"; //기타입고

        public const string B_INV_ACC_DETAIL_MOVE_OUT = "M11"; //불출
        public const string B_INV_ACC_DETAIL_MOVE_RETURN = "M12"; //반납
        public const string B_INV_ACC_DETAIL_MOVE_INPUT = "M13"; //투입
        public const string B_INV_ACC_DETAIL_MOVE_CANCEL_INPUT = "M14"; //투입해제
        public const string B_INV_ACC_DETAIL_MOVE_STORE = "M15"; //창고이동
        


        public const string B_INV_ACC_DETAIL_ISS_TEAM = "I27"; //팀간출고
        public const string B_INV_ACC_DETAIL_ISS_FACTORY = "I33"; //이송(타공장)출고
        public const string B_INV_ACC_DETAIL_ISS_SELL = "I37"; //매각출고
                

        #endregion

        #region ACCOUNT_GRP

        public const string B_INV_ACC_GRP_RECV_ETC = "RG5"; //기타입고

        public const string B_INV_ACC_GRP_MOVE_INSIDE = "MG1"; //사내이동

        public const string B_INV_ACC_GRP_ISS_SALES = "IG3"; //매출출고

        public const string B_INV_ACC_GRP_RECV_BUY = "RG2"; //구매입고

        public const string B_INV_ACC_GRP_FACTORY_BUY = "RG4"; //이송입고

        #endregion

        #region OPER_GROUP

        public const string OPER_GRP_1_M = "M"; //M창고
        public const string OPER_GRP_1_O = "O"; //공정
        public const string OPER_GRP_1_P = "P"; //P창고
        public const string OPER_GRP_1_W = "W"; //P창고

        #endregion

        #region OPER

        public const string B_OPER_W100 = "W100"; //대기창고
        public const string B_OPER_W300 = "W300"; //외주창고

        #endregion

        #region MAT_TYPE_GRP

        public const string B_MAT_TYPE_GRP_M = "M"; //자재
        public const string B_MAT_TYPE_GRP_P = "P"; //(반)제품

        #endregion

        #region MAT_TYPE

        public const string B_MAT_TYPE_DUMMY = "DM"; //반제품 원자재
        public const string B_MAT_TYPE_FG = "FG";    //완제품
        public const string B_MAT_TYPE_HG = "HG";    //재공품

        #endregion
        #region INV_RSN_DETAIL

        public const string B_INV_RSN_DTL_RA1 = "RA1"; // 생산계획변경
        public const string B_INV_RSN_DTL_RA2 = "RA2"; // 불량
        public const string B_INV_RSN_DTL_RB1 = "RB1"; // 구매입고
        public const string B_INV_RSN_DTL_RC1 = "RC1"; // 타공장이송

        public const string B_INV_RSN_DTL_R32 = "R32"; // 외주창고입고(자공장)
        public const string B_INV_RSN_DTL_RC2 = "RC2"; // 타공장이송(외주)

        #endregion
        #region INV_RSN_GRP

        public const string B_INV_RSN_GRP_RG1 = "RG1"; //자재 사유그룹 (LOT 생성 사유)
        public const string B_INV_RSN_GRP_RG2 = "RG2"; //자재 사유그룹 (LOSS 사유)
        public const string B_INV_RSN_GRP_RG3 = "RG3"; //자재 사유그룹 (자재 이동 사유)
        public const string B_INV_RSN_GRP_RG4 = "RG4"; //자재 사유그룹 (수량 변경(-) 사유)
        public const string B_INV_RSN_GRP_RG5 = "RG5"; //자재 사유그룹 (생산출고)
        public const string B_INV_RSN_GRP_RG9 = "RG9"; //자재 사유그룹 (수량 변경(+) 사유)
        public const string B_INV_RSN_GRP_RGA = "RGA"; //자재 사유그룹 (반납)
        public const string B_INV_RSN_GRP_RGB = "RGB"; //자재 사유그룹 (입고)
        public const string B_INV_RSN_GRP_RGC = "RGC"; //자재 사유그룹 (타공장이송)

        #endregion

        #region DELIVERY_STATUS

        public const char B_DLV_STATUS_RUNNING = 'R';
        public const char B_DLV_STATUS_CLOSE = 'C';

        #endregion

        #region ACCOUNT_TYPE

        public const string B_INV_ACC_TYPE_ISSUE = "ISS"; //기타입고
        public const string B_INV_ACC_TYPE_MOVE = "MOVE"; //기타입고
        public const string B_INV_ACC_TYPE_RECEIVE = "RECV"; //기타입고

        #endregion

        #region MATERIAL_VERSION

        public const int B_MATERIAL_DEFAULT_VERSION = 1;
        #endregion

        #region LOSS_TYPE

        public const char B_LOSS_TYPE_L = 'L'; //자재 창고 불량
        public const char B_LOSS_CODE_I = 'I'; //자재 LOSS CODE
        public const char B_LOSS_CODE_P = 'P'; //공정 LOSS CODE

        #endregion

        #region LOT_TYPE

        public const char B_LOT_TYPE_D = 'D'; //Dummy
        public const char B_LOT_TYPE_E = 'E'; //Engineer
        public const char B_LOT_TYPE_M = 'M'; //Monitoring
        public const char B_LOT_TYPE_P = 'P'; //Production
        public const char B_LOT_TYPE_T = 'T'; //Test
        public const char B_LOT_TYPE_I = 'I'; //Inventory

        #endregion

        #region OWNER_CODE

        public const string B_OWNER_CODE_DEVE = "DEVE"; //Develop
        public const string B_OWNER_CODE_PROD = "PROD"; //Production   

        #endregion

        #region CREATE_CODE

        public const string B_CREATE_CODE_ENG = "ENG"; //Engineer Lot
        public const string B_CREATE_CODE_PROD = "PROD"; //Product Lot  
        public const string B_CREATE_CODE_TEST = "TEST"; //Test Lot

        #endregion

        #region FLOW

        public const string B_FLOW_FF100 = "FF100"; //INV Flow

        #endregion

        #region ORDER_STATUS

        public const string B_ORD_STATUS_NOT_WORKING = "O"; //NOT WORKING
        public const string B_ORD_STATUS_RESERVED = "R"; //RESERVED
        public const string B_ORD_STATUS_PROCESS = "P"; //PROCESS
        public const string B_ORD_STATUS_COMPLETED = "C"; //COMPLETED

        #endregion

        #region "API 관련"
        public const uint WM_KEYDOWN = 0x0100;
        public const long VK_RETURN = 0x0D;
        #endregion

        #region H101
        public const string B_CLIENT_TUNE_MODULE = "EISCL";

        public static readonly string B_MEMBER_CAST_FLAG = "_CAST_FLAG";

        #endregion

        #region "BOI Order Info"
        public enum ORDER
        {
            FACTORY,
            ORDER_ID,
            ORDER_DESC,
            ORDER_TYPE,
            LOT_ID,
            FLOW,
            FLOW_SEQ_NUM,
            OPER,
            RES_ID,
            MAT_ID,
            MAT_VER,
            MAT_BOM_TYPE,
            ORD_QTY,
            PROD_QTY,
            REMAIN_QTY,
            LOSS_QTY,
            UNIT_1,
            SHOP_CODE,
            LINE_ID,
            LOT_TYPE,
            ORD_DATE,
            PLAN_DATE,
            PLAN_PRIORITY,
            ORD_REG_DATE,
            ORG_PLAN_DATE,
            ORG_ORD_QTY,
            PLAN_START_TIME,
            PLAN_END_TIME,
            ORD_START_TIME,
            ORD_END_TIME,
            CLOSE_TIME,
            LABEL_CODE,
            PACK_QTY,
            CUST_ID,
            ERP_SO_NO,
            ERP_SO_SEQ,
            ORDER_STATUS,
            COMMENT_1,
            COMMENT_2,
            COMMENT_3,
            ORD_QTY_1,
            ORD_QTY_2,
            ORD_QTY_3,
            ORD_QTY_4,
            ORD_QTY_5,
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
        #endregion

        #region "BOI Lot Info"
        public enum LOT
        {
            FACTORY,
            ORDER_ID,
            ORDER_QTY,
            LOT_ID,
            LOT_QTY,
            MAT_ID,
            LINE_ID,
            FLOW,
            OPER,
            RES_ID,
            INSPECTION_FLAG,
            MAT_BOM_TYPE
        }
        #endregion

        #region Collection Group

        public const string B_COL_GRP_1_MB = "MB"; //자재-불량
        public const string B_COL_GRP_1_ML = "ML"; //자재-LOSS
        public const string B_COL_GRP_1_MQ = "MQ"; //자재-검사
        public const string B_COL_GRP_1_PB = "PB"; //공정-불량
        public const string B_COL_GRP_1_PQ = "PQ"; //공정-검사

        #endregion

        #region LOSS CODE TYPE

        public const string B_LOSS_CODE_TYPE_I = "I"; //자재
        public const string B_LOSS_CODE_TYPE_P = "P"; //제품

        #endregion

        #region LOT STATUS

        public const string B_LOT_STATUS_PROC = "PROC"; //진행중
        public const string B_LOT_STATUS_WAIT = "WAIT"; //대기중
        #endregion

        #region LOT GEN RULE

        public const string B_LOT_GEN_RULE_L = "L"; //LOT
        public const string B_LOT_GEN_RULE_C = "C"; //CHILD LOT

        #endregion


        #region CARRIER_LOT_PREFIX
        public const string B_CARRIER_LOT_PREFIX = "CRR";
        #endregion

        #region Material Assy Lot Type

        public const string B_ASSY_LOT_RM_TYPE = "RAW_MATERIAL"; //원자재
        public const string B_ASSY_LOT_SP_TYPE = "SEMI_PRODUCT"; //반제품
        public const string B_ASSY_LOT_RR_TYPE = "RERUN"; //RERUN
        public const string B_ASSY_LOT_SL_TYPE = "STERILIZE"; //재살균
        #endregion

        #region Work Atd Type

        public const string B_WRK_ATD_PUN_01 = "PUN_01"; //결근
        public const string B_WRK_ATD_PUN_02 = "PUN_02"; //교육
        public const string B_WRK_ATD_PUN_03 = "PUN_03"; //출장
        public const string B_WRK_ATD_PUN_04 = "PUN_04"; //휴무
        public const string B_WRK_ATD_PUN_05 = "PUN_05"; //공가
        public const string B_WRK_ATD_PUN_06 = "PUN_06"; //출근
        public const string B_WRK_ATD_PUN_07 = "PUN_07"; //퇴근
        public const string B_WRK_ATD_PUN_08 = "PUN_08"; //조퇴
        #endregion

        #region Work Manual

        public const string B_WRK_MANUAL_W_01 = "W_01"; //반장
        public const string B_WRK_MANUAL_W_02 = "W_02"; //청소
        public const string B_WRK_MANUAL_W_03 = "W_03"; //품질관리
        public const string B_WRK_MANUAL_W_04 = "W_04"; //현장지원
        #endregion

        #region UNIT

        public const string B_DATABASE_DEFAULT_UNIT = "KG"; //Production
            
        #endregion

        #region Port Type

        public const string B_PORT_SPOOL = "SPOOL"; //스풀

        #endregion

        #region Label ID

        public const string B_LABEL_LB001 = "LB001"; //포장 팔레트
        public const string B_LABEL_LB002 = "LB002"; //성형공병/외주출고
        public const string B_LABEL_LB003 = "LB003"; //향료실
        public const string B_LABEL_LB004 = "LB004"; //콘과자
        public const string B_LABEL_LB005 = "LB005"; //자재

        #endregion


        #region Character ID

        //설비DATA
        public static readonly string CHR_CRDR001 = "CRDR001"; //설비중량

        #endregion
    }
}
