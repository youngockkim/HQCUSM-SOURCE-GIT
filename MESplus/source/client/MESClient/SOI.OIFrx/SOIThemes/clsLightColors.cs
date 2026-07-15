using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SOI.CliFrx;

namespace SOI.OIFrx.SOIThemes
{
    public class clsLightColors : clsThemeColors
    {
        public clsLightColors()
        {
            // Solution Color
            this.Foreground = Color.FromArgb(255, 255, 255);

            // Main Form
            this.MainFormBackground = Color.FromArgb(233, 234, 238);
            this.MainFormTitleBackground = Color.FromArgb(33, 38, 40);
            this.MainFormTitleControlBoxBackground = Color.FromArgb(0, 72, 129);
            this.MainFormTitleUnderline = this.MainFormTitleControlBoxBackground;
            this.MainFormBottomBackground = this.MainFormTitleBackground;
            this.MainFormOpenMenuBackground = Color.FromArgb(114, 114, 114);
            this.MainFormMessageDefaultForeground = Color.White;
            this.MainFormMessageInfoForeground = Color.White;
            this.MainFormMessageWarnForeground = Color.Yellow;
            this.MainFormMessageErrorForeground = Color.Red;

            // Login Form
            this.LoginFormBorder = Color.FromArgb(255, 255, 255);
            this.LoginFormBackground = Color.FromArgb(0, 120, 215);
            this.LoginFormForeground = Color.FromArgb(255, 255, 255);
            this.LoginFormLoginButtonBackground = Color.FromArgb(246, 187, 67);

            // MainMenu Form
            this.MainMenuFormBorder = Color.FromArgb(255, 255, 255);
            this.MainMenuFormBackground = Color.FromArgb(0, 120, 215);

            // Opened Menu Form
            this.OpenedMenuFormBacgkround = Color.FromArgb(0, 120, 215);

            // Child Form            
            this.FormTopBackground = Color.FromArgb(181, 180, 181);      
            this.FormMiddleBackground = Color.FromArgb(233,234,238);
            this.FormBottomBackground = Color.FromArgb(233,234,238);
            this.FormTitleForeground = Color.FromArgb(52, 52, 52);

            // Popup Form
            this.PopupTopBackground = Color.FromArgb(0, 120, 215);
            this.PopupTopForeground = Color.FromArgb(255, 255, 255);
            this.PopupTopUnderline = this.MainFormTitleUnderline;
            this.PopupMiddleBackground = Color.FromArgb(242, 242, 242);
            this.PopupBottomBackground = Color.FromArgb(242, 242, 242);

            // Popup KeyPad Form
            this.PopupKeyPadBackground = Color.FromArgb(242, 242, 242);
            this.PopupKeyPadBorder = Color.FromArgb(152, 152, 152);
            this.PopupKeyPadNumberBackground = Color.FromArgb(43, 127, 189);
            this.PopupKeyPadControlButtonBackground = Color.FromArgb(114, 114, 114);
            
            // Controls Common Color
            this.ControlCommonDisabledBackground = Color.FromArgb(240,240,240);
            this.ControlCommonDisabledBorder = Color.FromArgb(211,211,211);
            this.ControlCommonDisabledForeground = Color.FromArgb(160,160,160);
            this.ControlCommonScrollBarArrowColor = Color.FromArgb(0, 0, 0);
            this.ControlCommonScrollBarBackground = Color.FromArgb(227,227,227);
            this.ControlCommonScrollBarForeground = Color.FromArgb(151,151,151);
            this.ControlCommonScrollBarSelectedColor = Color.FromArgb(141,141,141);

            // SOILabel
            this.LabelForeground = Color.FromArgb(85, 85, 85);
            this.LabelBackground = Color.Transparent;
            this.LabelKeyForeground = Color.FromArgb(51, 51, 51);
            this.LabelValueForeground = Color.FromArgb(0, 0, 0);

            // SOITextBox
            this.TextBoxBackground = Color.FromArgb(242,242,242);
            this.TextBoxBorder = Color.FromArgb(152,152,152);
            this.TextBoxForeground = Color.FromArgb(0,0,0);
            this.TextBoxFocusedBackground = Color.FromArgb(240,249,104);
            this.TextBoxFocusedForeground = this.TextBoxForeground;
            this.TextBoxMouseOverBorder = Color.FromArgb(43, 42, 48);
            this.TextBoxReadOnlyBackground = Color.FromArgb(220, 220, 220);
            this.TextBoxValidationBorder = Color.Red;

            // SOITextBoxValue
            this.TextBoxValueForeground = Color.FromArgb(0, 0, 0);

            // SOIComboBox
            this.ComboBoxForeground = this.TextBoxForeground;
            this.ComboBoxBackground = Color.FromArgb(242, 242, 242);
            this.ComboBoxBorder = this.TextBoxBorder;
            this.ComboBoxArrow = this.PopupTopBackground;
            this.ComboBoxMouseOverBorder = this.TextBoxMouseOverBorder;

            // SOIButton
            this.ButtonDefaultBackground = Color.FromArgb(43,127,189);
            this.ButtonDefaultHoverBackground = Color.FromArgb(33,117,179);
            this.ButtonDefaultPressBackground = this.ButtonDefaultBackground;
            this.ButtonCancelBackground = Color.FromArgb(51,73,94);
            this.ButtonCancelHoverBackground = Color.FromArgb(41,63,84);
            this.ButtonCancelPressBackground = this.ButtonCancelBackground;

            // SOIButtonImage
            this.ButtonImageDefaultBackground = Color.FromArgb(43, 127, 189);
            this.ButtonImageDefaultHoverBackground = Color.FromArgb(33, 117, 179);
            this.ButtonImageDefaultPressBackground = this.ButtonImageDefaultBackground;
            this.ButtonImageTransparentBackground = Color.Transparent;
            this.ButtonImageTransparentHoverForeground = Color.FromArgb(240,240,240);
            this.ButtonImageProcessBackground = Color.FromArgb(59,174,218);
            this.ButtonImageProcessHoverBackground = Color.FromArgb(49,164,208);
            this.ButtonImageProcessPressBackground = this.ButtonImageProcessBackground;
            this.ButtonImageCloseBackground = Color.FromArgb(51,73,94);
            this.ButtonImageCloseHoverBackground = Color.FromArgb(41, 63, 84);
            this.ButtonImageClosePressBackground = this.ButtonImageCloseBackground;

            // SOICodeView
            this.CodeViewButtonBackground = this.ButtonDefaultBackground;

            // SOICheckBox
            this.CheckBoxForeground = this.TextBoxForeground;
            this.CheckBoxBackground = Color.Transparent;

            // SOICheckBoxOnOff
            this.CheckBoxOnOffBorder = Color.FromArgb(152, 152, 152);
            this.CheckBoxOnOffOnBackground = Color.FromArgb(43, 127, 189);
            this.CheckBoxOnOffOnForeground = Color.FromArgb(255,255,255);
            this.CheckBoxOnOffOffBackground = Color.FromArgb(242, 242, 242);
            this.CheckBoxOnOffOffForeground = Color.FromArgb(51, 51, 51);
            this.CheckBoxOnOffButtonBackground = Color.FromArgb(200, 200, 200);
            this.CheckBoxOnOffButtonBorder = Color.FromArgb(114, 114, 114);            

            // SOIRadioButton 
            this.RadioButtonBackground = Color.Transparent;
            this.RadioButtonForeground = this.LabelForeground;

            // SOIUnderline
            this.UnderlineBackground = Color.FromArgb(87, 91, 100);

            // SOIDateTime
            this.DateTimeForeground = this.TextBoxForeground;
            this.DateTimeBackground = Color.FromArgb(242, 242, 242);
            this.DateTimeBorder = this.TextBoxBorder;
            this.DateTimeButtonBackground = Color.FromArgb(200, 200, 200);
            this.DateTimeMouseOverBorder = this.TextBoxMouseOverBorder;
            this.DateTimeCalendarHeaderBackground = Color.FromArgb(200, 200, 200);
            this.DateTimeCalendarHeaderForeground = Color.FromArgb(45, 45, 45);
            this.DateTimeCalendarDayForeground = Color.FromArgb(0, 0, 0);
            this.DateTimeCalendarTrailDayForeground = Color.FromArgb(160, 160, 160);
            this.DateTimeCalendarActivaDayBackground = Color.FromArgb(207, 217, 231);

            // SOIListBox
            this.ListBoxBackground = Color.FromArgb(236, 239, 239);
            this.ListBoxBorder = Color.FromArgb(152, 152, 152);
            this.ListBoxBorderForMenu = Color.FromArgb(255, 255, 255);
            this.ListBoxRowBackground = Color.FromArgb(255, 255, 255);
            this.ListBoxRowForeground = Color.FromArgb(1, 73, 129);
            this.ListBoxRowMouseOverBackground = Color.FromArgb(178, 214, 243);
            this.ListBoxRowSelectedBackground = Color.FromArgb(213, 234, 251);
            this.ListBoxScrollThumbBackground = this.ControlCommonScrollBarForeground;

            // SOITabControl
            this.TabControlBackground = this.MainMenuFormBackground;
            this.TabControlForeground = this.Foreground;
            this.TabControlBorder = Color.FromArgb(152, 152, 152);
            this.TabControlActiveTabBackground = Color.FromArgb(255, 255, 255);
            this.TabControlActiveTabForeground = Color.FromArgb(8, 115, 214);
            this.TabControlMenuBackground = this.MainMenuFormBackground;
            this.TabControlMenuForeground = this.Foreground;
            this.TabControlMenuBorder = Color.FromArgb(152, 152, 152);
            this.TabControlMenuActiveTabBackground = Color.FromArgb(255, 255, 255);
            this.TabControlMenuActiveTabForeground = Color.FromArgb(8, 115, 214);

            // SOIGroupBox
            this.GroupBoxBackground = Color.FromArgb(255,255,255);
            this.GroupBoxBorder = Color.FromArgb(223, 224, 228);
            this.GroupBoxHeaderForeground = Color.FromArgb(45,45,45);
            this.GroupBoxHeaderBackground = Color.FromArgb(200,200,200);
            this.GroupBoxNumberStyleBackground = Color.FromArgb(242, 242, 242);
            this.GroupBoxNumberStyleHeaderBackground = Color.FromArgb(114,114,114);
            this.GroupBoxNumberStyleHeaderForeground = Color.FromArgb(255, 255, 255);

            // SOIContextMenu
            this.ContextMenuBackground = Color.FromArgb(229, 229, 229);
            this.ContextMenuBorder = Color.FromArgb(202, 202, 202);
            this.ContextMenuForeground = Color.FromArgb(0, 0, 0);

            // SOIPanel
            this.PanelBackground = Color.Transparent;

            // SOISplitContainer
            this.SplitContainerBackground = Color.Transparent;

            // SOIListView
            this.ListViewBackground = this.GroupBoxBackground;
            this.ListViewBorder = this.TextBoxBorder;
            this.ListViewColumnHeaderBackground = Color.FromArgb(22, 76, 199);

            // SOITreeView
            this.TreeViewBackground = Color.FromArgb(255,255,255);
            this.TreeViewForeground = Color.FromArgb(0, 67, 126);
            this.TreeViewLineForeground = Color.FromArgb(138, 193, 237);
            this.TreeViewScrollThumbBackground = this.ListBoxScrollThumbBackground;

            // SOIGrid
            this.GridBackground = Color.FromArgb(242, 242, 242);
            this.GridBorder = Color.FromArgb(152, 152, 152);
            this.GridColumnHeaderForeground = Color.FromArgb(255,255,255);
            this.GridColumnHeaderBackground = Color.FromArgb(114, 114, 114);
            this.GridCellBorder = Color.FromArgb(152, 152, 152);
            this.GridCellForeground = this.TextBoxForeground;
            this.GridRowSelectedBackground = Color.FromArgb(207, 217, 231);

            // SOIChart
            this.ChartBackground = Color.FromArgb(242, 242, 242);
            this.ChartForeground = Color.FromArgb(85, 85, 85);
            this.ChartBorder = Color.FromArgb(152, 152, 152);
            this.ChartBarYLineBorder = Color.FromArgb(85, 85, 85);
            this.ChartBarDefaultBarColor = Color.FromArgb(0, 120, 215);

            // SOISpread
            this.SpreadBackground = Color.FromArgb(242, 242, 242);
            this.SpreadBorder = Color.FromArgb(152, 152, 152);
            this.SpreadColumnHeaderForeground = Color.FromArgb(255, 255, 255);
            this.SpreadColumnHeaderBackground = Color.FromArgb(114, 114, 114);
            this.SpreadCellBorder = Color.FromArgb(152, 152, 152);
            this.SpreadCellForeground = Color.FromArgb(0, 0, 0);
            this.SpreadRowSelectedBackground = Color.FromArgb(0, 164, 238);
            this.SpreadCellEditableBackColor = Color.FromArgb(242, 242, 242);
            this.SpreadCellReadOnlyBackColor = Color.FromArgb(220, 220, 220);

            // SOIFlexibleScreen
            this.FlexibleScreenBackground = Color.FromArgb(255,255,255);
            this.FlexibleScreenCellForeground = Color.FromArgb(0,0,0);
        }
    }
}
