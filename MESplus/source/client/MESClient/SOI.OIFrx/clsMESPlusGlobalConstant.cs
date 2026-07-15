using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;
using System.Drawing;

namespace SOI.OIFrx
{
    public class MOGC : CMNC
    {
        #region PLM Viewer

        public const string PLM_VIEWER_URL = "";
        //public const string PLM_VIEWER_URL = "http://demo.stage.sdsplm.com/public/viewer/init.html";

        #endregion

        #region Theme

        public const string THEME_NAME_LIGHT = "Light";
        public const string THEME_NAME_DARK = "Dark";

        #endregion

        #region Control

        public const int SM_TABLETPC = 86;

        public const string CONTROL_CONTEXT_MENU_KEY = "SOIContextMenuPopup";

        #endregion

        #region BAS

        public const string MP_GCM_BAS_SCREEN_REL = "SCREEN_REL";
        public static string gsQueryStatementLong = string.Empty;

        #endregion

        #region Color

        public static Color DefaultBackColor = Color.Black;
        public static Color DefaultForeColor = Color.Yellow;
        public static Color ErrorBackColor = Color.Black;
        public static Color ErrorForeColor = Color.Yellow;
        public static Color SuccessBackColor = Color.Blue;
        public static Color SuccessForeColor = Color.White;

        #endregion
    }
}
