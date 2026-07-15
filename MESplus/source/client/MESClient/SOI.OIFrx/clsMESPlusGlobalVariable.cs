using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;
using SOI.OIFrx.SOIModel;
using Miracom.TRSCore;
using System.Collections;
using SOI.OIFrx.SOIThemes;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIBaseForm;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public class MOGV : CMNV
    {
        #region Theme

        // 최초 실행 시 (저장된 테마값이 없는 경우) 적용. 
        public static intHmMdiFormFunction gIHmMdiForm;
        public static string gsDefaultThemeName = MOGC.THEME_NAME_LIGHT;

        // Design Mode에서 적용.
        public static clsThemeColors gTheme = new clsLightColors();

        public static List<string> glThemeSet;

        #endregion

        #region Login

        public static bool gbReloginFlag = false; // 재시작여부

        #endregion

        #region "Global Variables"

        public static bool gbPlaySoundFlag = false;         // Play Sound Signal : Sound를 Play 할 것 인지 여부

        public static string gsClientVersion; // Client Version
        public static string gsServerVersion; // Server Version
        public static string gsUpgradeFile; // Upgrade Program File Name
        public static string gsDownloadFileList;
        public static string gsHelpURL;
        public static string gsDefaultHelpURL;

        public static string gsDateDelimiter = "/"; //DateTime Foramt ("/", "-" , "." )
        public static string gsSiteNickName; //Server Site Nickname ("MPD1", "MPP1", ...), In case of TibRv, Site id is subject, so this field store short nickname for connection

        public static bool gbExitFlag;
        /*2013.01.09 LogInBox 에서 사용할 변수*/
        public static string gsUserID2;
        public static string gsPassword2;
        /*-----------------------------------*/
        public static string gsReturnLotID; //Return Lot ID
        public static string gsWorkDate; //Return Lot Work Date

        public static string gsCentralFactory = "SYSTEM"; //Central Factory

        public static bool gbLoginFlag = false;
        public static bool gbLogoutFlag = false;
        public static bool gbReLoadLanguageFlag = false;

        public static bool gbShowMessagePanel;
        public static string gsUserGroup;
        public static string gsDepartment;
        public static string gsUserAreaID;
        public static string gsUserSubAreaID;

        public static Hashtable ghtMessageData;
        public static Hashtable ghtCaptionData;

        public static DATE_TIME_FORMAT geDateTimeFormat = DATE_TIME_FORMAT.DATETIME;
        public static LANG_FORMAT geLanguageFormat = LANG_FORMAT.SYSTEM;

        public static int giMessageSize = 8; //Caster Processing

        public static char gcChangePassword = ' ';

        public static int giRequestReplyWaitTime = 10;

        // MES Client Caption File Name
        public const string gsCaptionFileName = "MESClientCaption.txt";
        public static System.Windows.Forms.ListView goCaptionList = new System.Windows.Forms.ListView();

        public static System.Drawing.Color gcolorReadOnlyBackColor = System.Drawing.SystemColors.Control;

        public static string gsCurrentLot_ID;
        public static int giCurrentHistSeq;
        public static string gsCurrentRes_ID;
        public static ArrayList gaSelectLot_ID = new ArrayList();
        public static ArrayList gaSelectRes_ID = new ArrayList();

        public static bool gbBOMPartList;
        public static bool gbCharList;
        public static bool gbCharSetList;
        public static bool gbMaterialList;
        public static bool gbResourceList;
        public static bool gbFlowList;
        public static bool gbOperList;
        public static bool gbUserList;

        public static FactoryShiftInfoTag gShiftInfor;

        //public static AlarmListTag[] gtAlarmList = new AlarmListTag[101];
        public static int giAlarmCnt;

        public static SPCAlarmListTag[] gtSPCAlarmList = new SPCAlarmListTag[100];
        public static int giSPCAlarmCnt;

        // Carrier Status -> Carrier History
        public static string gsCurrentCrrID;

        // Tool -> Tool History
        public static string gsCurrentToolID;
        public static string gsCurrentToolType;

        public static ArrayList gaWarningMsg = new ArrayList();

        //Add by J.S. 2009.02.13
        //favorites수정시 LotListMain, ResourceListMain시 submenu를 refresh하기위한 변수 
        public static bool gbFavoriteChangeForLotListMain;
        public static bool gbFavoriteChangeForResourceListMain;

        public static int giSpanRow = 0;
        public static int giSpanCol = 0;

        /*Module*/
        public const string CRC_MODUEL_WIP = "CRC";
        public const string CRC_MODUEL_WORK_GUIDE = "WORKGUIDE";


        public static string gsFlexibleScreenLocalPath = Application.StartupPath + "\\Screen\\";

        //Add by DM KIM 2012.05.08
        public static System.Windows.Forms.Form gfrmPopupInformNote;

        //Add by IC.Bae 2012.06.08
        public static System.Drawing.Color gTitleColor;

        public static gtBinLotInfoTag gtBinLot;

        public static SOIDefaultBackgroundForm gfrmDefaultBackForm = new SOIDefaultBackgroundForm();

        public static iFormEventFunction gIBaseFormEvent;

        #endregion

        #region "SPC Client"

        public static string gsStyleName = "3D"; //3D Type or Flat Type
        public static string gsChartID;

#if _SPCTYPE1
        public const string gsSPCType = "1";
#elif _SPCTYPE2
        public const string gsSPCType = "2";
#elif _SPCTYPE3
        public const string gsSPCType = "3";
#else
        public const string gsSPCType = "1";
#endif

        #endregion

        #region "SQL Syntax"

        public static string[] SqlSyntax = new string[] {
            "SELECT",
            "*",
            "FROM",
            "WHERE",
            "ORDER",
            "AND",
            "OR",
            "IN",
            "GROUP",
            "BY",
            "NOT",
            "AS",
            "DISTINCT",
            "=",
            "<>",
            "LIKE"
           
        };
        #endregion

        #region "Field Constant"

        public static string[] FieldConstant = new string[] {
            "MAT_ID",
            "MAT_VER",
            "FLOW",
            "OPER",
            "RES_TYPE",
            "RESG_ID",
            "RES_ID",
            /* 2013.06.12. Aiden. ID Generator 의 Constant Rule 에서 사용할 수 있는 Field 를 추가 */
            "LOT_ID",
            "SUBLOT_ID",
            "SEQ_KEY_1",
            "SEQ_KEY_2",
            "SEQ_KEY_3",
            "SEQ_KEY_4",
            "SEQ_KEY_5",
            "SEQ_KEY_6",
            "SEQ_KEY_7",
            "SEQ_KEY_8",
            "SEQ_KEY_9",
            "SEQ_KEY_10",
            "ARGUMENT_1",
            "ARGUMENT_2",
            "ARGUMENT_3",
            "ARGUMENT_4",
            "ARGUMENT_5",
            "ARGUMENT_6",
            "ARGUMENT_7",
            "ARGUMENT_8",
            "ARGUMENT_9",
            "ARGUMENT_10"
        };
        #endregion

        #region "Admin 관련"

        public static int giRequestCnt;
        public static int giRequestSeq;

        public static gtProcessInfoTag[] gtProcessinfoList;
        public static gtServerInfoTag[] gtServerInfoList;

        public static string gsTableName;

        #endregion

        #region Function

        public static ArrayList galAllFunctionList = new ArrayList(); // 전체 화면 목록
        public static ArrayList galFavFunctionList = new ArrayList(); // 즐겨찾기 화면 목록

        #endregion

        #region Error Message

        public static List<ErrorModel> glErrorMessageList = new List<ErrorModel>(); // Error Message 목록

        #endregion

        #region Base Form Font

        public static string gbffFormFontType = "Malgun Gothic"; // Form Font Type
        public static System.Single gbffFormFontOISize = 12F; // Form Font Size
        public static System.Single gbffFormFontUISize = 9F; // Form Font Size
        public static System.Single gbffGroupBoxFontOISize = 14F; // Form Font Size
        public static System.Single gbffGroupBoxFontUISize = 11F; // Form Font Size        

        #endregion

        #region " Constant Definition "
        /*라인 구분(AREA_ID)*/
        public const string KY_AREA_AR = "AR";     //권선(Winding)
        public const string KY_AREA_FG = "FG";     //조립(Assembly)

        /*Module*/
        public const string KY_MODUEL_KEY = "KEY";

        /*CMF*/
        public const string KY_CMF_IMAGE = "CMF_IMAGE";
        public const string KY_CMF_DOC = "CMF_DOC";
        public const string MP_GCM_CMAT_CATE_TYPE = "CMAT_CATE_TYPE";
        public const string MP_GCM_CMAT_CATE_CODE = "CMAT_CATE_CODE";
        public const string MP_GCM_SUB_AREA = "SUB_AREA";

        #endregion

        #region " Variable Definition  "


        public static string gsTuneChannel = "";            // Client Tune Channel (2012/08/12 lakekim)
        public static string gsLine = "";                   // Option Line 
        public static string gsLineDesc = "";               // Option LineDesc
        public static string gsResId = "";                  // Option Resource
        public static string gsResource = "";                  // Option Resource
        public static string gsArea = "";                   // Option Area  -- shop
        public static string gsMatType = "";                // Option 제품군 
        public static string gsMatTypeDesc = "";                // Option 제품군  설명
        public static string gsAreaDesc = "";                   // Option Area  -- shopDesc
        public static string gsPlant = "";                  // Option Plant
        public static string gsOper = "";                   // Option Operation
        public static string gsOperDesc = "";                   // Option Operation
        public static string gsTuneId = "";                 // Operation별 Tune Id(2012/08/22 lakekim)
        public static bool gbTunePublish = false;           // MES서버에서의 공정 진행 정보를 Tune할지 여부(2012/08/22 lakekim)
        public static string gsPrintPortID = "SPOOL";         // Label Print Port
        public static bool gbDefaultPrint = true;           // Default Print 사용 여부
        public static bool gbTuneWorkGuide = false;           // MES서버에서의 작업 표준서 정보를 Tune할
        public static string gsQueryStatementLong = string.Empty; // 다중 쿼리사용시 Statement
        public static GroupBox grpCond;
        public static Hashtable htSelected;
        public static string gs_image_id = string.Empty;
        public static string sClipboardText = string.Empty;     // directview spread 사용, 셀 클릭 시 셀의 텍스트 내용을 복사하기 위한 변수
        #endregion

        public struct BOM_TAG_INFO
        {
            public string s_mat_id;
            public string s_mother_mat_id;
        }
    }
}
