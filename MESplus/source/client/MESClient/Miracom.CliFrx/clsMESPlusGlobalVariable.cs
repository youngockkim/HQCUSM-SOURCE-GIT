using System.Data;
using System.Collections;
using System.Diagnostics;
using System;
using System.Net;

namespace Miracom.CliFrx
{
    public sealed class MPGV
    {
        
        #region "Global Variables"
        
        public static string gsClientVersion; //Server Program Version
        public static string gsServerVersion; //Client Program Version
        public static string gsUpgradeFile; //Upgrade Program Name
        public static string gsDownloadFileList;
        public static string gsHelpURL;
        public static string gsDefaultHelpURL;
        
        public static int giTimeOut;
        public static int giLogOutTime;
        public static int giVersionCheckTime; // Version Check Time Added by ICBAE
        public static int giIdleTime; //(if giIdleTime=giLogoutTime => Logout)
        public static string gsDateDelimiter = "/"; //DateTime Foramt ("/", "-" , "." )
        public static string gsServerName = "MESServer"; //"MESServer"
        public static string gsSiteID; //Server Site ID ("MPD1", "MPP1", ...)
        public static string gsSiteNickName; //Server Site Nickname ("MPD1", "MPP1", ...), In case of TibRv, Site id is subject, so this field store short nickname for connection
        public static bool gbAutoRefresh = false;
        public static int giAutoRefreshTime = 300;
        public static bool gbListAutoRefresh = true;
        public static string gsRemoteAddress; //Remote Addres
        public static string gsRvService; //TibRV Service Name
        public static string gsRvNetwork; //TibRv Network Name
        public static string gsStationMode; //H101 Station Mode
        public static string gsTimePattern = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern;

        public static bool gbExitFlag;
        public static string gsComputerName;
        public static string gsFactory;
        public static string gsUserID;
        public static string gsPassword;
        public static string gsPassport;

        //Added by hans(2018-04-20) Login시 User의 Plnat, Shop, Line정보 조회하기 위한 변수 선언
        public static string gsPlantID;
        public static string gsPlantDesc;
        public static string gsShop;
        public static string gsShopDesc;
        public static string gsLineID;
        public static string gsLineDesc;
        public static string gsMatType;
        public static string gsMatTypeDesc;
        public static char gcAdminGrpFlag = 'N';

        public static bool gbShowMsgFlag = true;
        /*2013.01.09 LogInBox 에서 사용할 변수*/
        public static string gsUserID2;
        public static string gsPassword2;
        /*-----------------------------------*/
        public static string gsReturnLotID; //Return Lot ID
        public static string gsWorkDate; //Return Lot Work Date
        
        public static string gsCentralFactory = "SYSTEM"; //Central Factory
        
        public static bool gbGridFlag = true;
        public static bool gbLoginFlag = false;
        public static bool gbLogoutFlag = false;
        
        public static char gcLanguage = '1';

        public static char gcAutoUpgrade = '1';
        public static bool gbUseSmallLetter = true;
        
        public static bool gbShowMessagePanel;
        public static string gsMessage;
        public static string gsUserGroup;
        public static string gsDepartment;
        public static string gsUserAreaID;
        public static string gsUserSubAreaID;
        public static string gsProgramID;
        
        public static DATE_TIME_FORMAT geDateTimeFormat = DATE_TIME_FORMAT.DATETIME;
        public static LANG_FORMAT geLanguageFormat = LANG_FORMAT.SYSTEM;
        
        public static System.Windows.Forms.Form gfrmMDI;
        
        //Language Function
        public static string[,] gsMessageData;
        public static int giMaxMessageData = 1000;
        
        public static bool gbProcessCaster = false; //Caster Processing
        public static int giMessageSize = 8; //Caster Processing
        
        public static char gcChangePassword = ' ';
        
        public static int giRequestReplyWaitTime = 10;
        
        public static ArrayList gaMenuLanguage = new ArrayList();
        public static ArrayList gaButtonLanguage = new ArrayList();
        public static ArrayList gaTextLanguage = new ArrayList();
        
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
        public static string gsMCPulblishChannel;

        public static FactoryShiftInfoTag gShiftInfor;
        
        public static AlarmListTag[] gtAlarmList = new AlarmListTag[101];
        public static int giAlarmCnt;


        public static SPCAlarmListTag[] gtSPCAlarmList = new SPCAlarmListTag[100];
        public static int giSPCAlarmCnt;
        
        public static string gsAlarmType = "ALM";


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

        //Add by IC.Bae 2012.03.08
        public static CookieContainer gCookieContainer = null;

        public static int giSpanRow = 0;
        public static int giSpanCol = 0;

        //Add by DM KIM 2012.05.08
        public static System.Windows.Forms.Form gfrmPopupInformNote;
        public static BBSMessageTag[] gtBBSMessageList = new BBSMessageTag[101];
        public static int giBBSMessageCnt;

        //Add by IC.Bae 2012.06.08
        public static System.Drawing.Color gTitleColor;

        //Add by IC.Bae 2012.06.29 for MESplusV6 Push Service
        public static string gsMessagingLocation;
        public static ArrayList gaALMChannel = new ArrayList();
        public static ArrayList gaUTLChannel = new ArrayList();
        public static string gsChannelPrefix;

        public static gtBinLotInfoTag gtBinLot;


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

        #region "Interface"

        public static intMdiFormFunction gIMdiForm;
        public static intFormEventFunction gIBaseFormEvent;

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
        public static string gsQueryStatementLOG = "";
        public static int gsQueryStatementLOGCount = 0;

        public static string gsTableName;

        #endregion
    }
}
