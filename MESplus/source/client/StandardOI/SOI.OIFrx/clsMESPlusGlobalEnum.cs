using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOI.OIFrx
{
    // ********************************************************************
    // 하단의 enum 명칭은 Framework에서 사용 중 이므로 사용할 수 없습니다.
    // SMALLICON_INDEX
   // TOOLICON_INDEX
   // LANG_FORMAT
   // DATE_TIME_FORMAT
   // RTD_RULE_LOT
   // RTD_RULE_RES
   // eGraphType
   // HISTORY_COLUMN
   // DISPLAY_DIRECTION
   // CAPTION_TYPE
   // MSGBOX_ICON_TYPE
   // MSG_LEVEL
    // ********************************************************************

    #region SOI Control 

    public enum SOIButtonStyle
    {
        DefaultStyle = 0,
        CancelStyle
    }

    public enum SOIButtonImageStyle
    {
        DefaultStyle = 0,
        TransparentStyle,
        CloseButtonStyle
        //,ProcessButtonStyle        
    }

    public enum SOILabelStyle
    {
        DefaultStyle = 0,
        KeyStyle,
        ValueStyle
    }

    public enum SOIPictureBoxStyle
    {
        None = 0,
        Start,
        Hold,
        Rework,
        Repair,
        Inventory,
        Transit
    }

    public enum SOIGroupBoxStyle
    {
        DefaultStyle = 0,
        NumberStyle
    }

    public enum SOICheckBoxOnOffState
    {
        OnState = 0,
        OffState
    }

    public enum SOIDateTimeFormat
    {
        DATE_SHORT = 0,
        DATE_LONG,
        TIME_SHORT,
        TIME_LONG,
        TIME_HH_MM,
        TIME_HH_MM_SS,
        DATE_SHORT_TT_HH_MM_SS,
        DATE_SHORT_HH_MM_SS,
        DATE_SHORT_HH_MM,
        DATE_SHORT_HH
    }

    public enum SOIDateTimeComboBoxFormat
    {
        YYYY =0 ,
        YYYY_MM,
        YYYY_MM_DD,
        YYYY_MM_DD_HH_MM_SS,
        HH_MM,
        HH_MM_SS
    }

    public enum SOIListBoxStyle
    {
        DefaultStyle = 0,
        MenuStyle
    }

    public enum SOIPanelStyle
    {
        TransparentStyle = 0,
        TabControlBorderStyle
    }

    public enum SOIButtonImageViewerStyle
    {
        DefaultStyle = 0,
        TransparentStyle
    }

    public enum SOIButtonPDFViewStyle
    {
        DefaultStyle = 0,
        TransparentStyle
    }

    public enum SOIButtonImportExcelStyle
    {
        DefaultStyle = 0,
        TransparentStyle
    }

    public enum SOIButtonExportExcelStyle
    {
        DefaultStyle = 0,
        TransparentStyle
    }

    public enum SOIButtonPrintOptionStyle
    {
        DefaultStyle = 0,
        TransparentStyle
    }

    public enum SOIChartType
    {
        BarChart = 0,
        PieChart
    }

    public enum SOIChartBarValueType
    {
        Percentage = 0,
        Quantity
    }

    public enum SOITabControlStyle
    {
        DefaultStyle = 0,
        MenuStyle
    }

    public enum SOIBaseFormStyle
    {
        Undefined = 0,
        OI_Style,
        UI_Style
    }

    public enum SOIPopupShowStyle
    {
        Normal = 0,
        Maximized,
        PopupAsFunc
    }

    #endregion

    public enum SAVE_FILE_TYPE
    {
        xlsx = 0
    }

    public enum BARCODE_FONT_TYPE
    {
        CODE39 = 0
    }
}
