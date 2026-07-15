using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SOI.CliFrx;

namespace SOI.OIFrx.SOIThemes
{
    public class clsDarkColors : clsThemeColors
    {
        public clsDarkColors()
        {
            // Solution Color
            this.Foreground = Color.FromArgb(255, 255, 255);

            // Main Form
            this.MainFormBackground = Color.FromArgb(56,64,75);
            this.MainFormTitleBackground = Color.FromArgb(0,0,0);
            this.MainFormTitleControlBoxBackground = Color.FromArgb(1,116,207);
            this.MainFormTitleUnderline = this.MainFormTitleControlBoxBackground;
            this.MainFormBottomBackground = this.MainFormTitleBackground;
            this.MainFormOpenMenuBackground = Color.FromArgb(17, 20, 27);
            this.MainFormMessageDefaultForeground = Color.White;
            this.MainFormMessageInfoForeground = Color.White;
            this.MainFormMessageWarnForeground = Color.Yellow;
            this.MainFormMessageErrorForeground = Color.Red;

            // Login Form
            this.LoginFormBorder = Color.FromArgb(255, 255, 255);
            this.LoginFormBackground = Color.FromArgb(33, 38, 40);
            this.LoginFormForeground = Color.FromArgb(255, 255, 255);
            this.LoginFormLoginButtonBackground = Color.FromArgb(246, 187, 67);

            // MainMenu Form
            this.MainMenuFormBorder = Color.FromArgb(1,76,135);
            this.MainMenuFormBackground = Color.FromArgb(33, 38, 40);

            // Opened Menu Form
            this.OpenedMenuFormBacgkround = Color.FromArgb(33, 38, 40);

            // AlarmMessage Form
            this.AlarmMessageFormBackgroundInfo = Color.FromArgb(0, 166, 81);
            this.AlarmMessageFormBackgroundWarn = Color.FromArgb(252,182,0);
            this.AlarmMessageFormBackgroundError = Color.FromArgb(254,52,0);

            // Child Form
            this.FormTopBackground = Color.FromArgb(40,48,61);
            this.FormMiddleBackground = Color.FromArgb(62,68,79);
            this.FormBottomBackground = Color.FromArgb(62,68,79);
            this.FormTitleForeground = Color.FromArgb(255, 255, 255);

            // Popup Form
            this.PopupTopBackground = Color.FromArgb(181,180,181);
            this.PopupTopForeground = Color.FromArgb(51,51,51);
            this.PopupTopUnderline = this.MainFormTitleUnderline;
            this.PopupMiddleBackground = Color.FromArgb(56,64,75);
            this.PopupBottomBackground = Color.FromArgb(56,64,75);

            // Popup KeyPad Form
            this.PopupKeyPadBackground = this.PopupMiddleBackground;
            this.PopupKeyPadBorder = Color.FromArgb(61, 69, 80);
            this.PopupKeyPadNumberBackground = Color.FromArgb(13, 121, 159);
            this.PopupKeyPadControlButtonBackground = Color.FromArgb(79, 107, 129);

            // Controls Common Color
            this.ControlCommonDisabledBackground = Color.FromArgb(44,49,55);
            this.ControlCommonDisabledBorder = Color.FromArgb(44,49,55);
            this.ControlCommonDisabledForeground = Color.FromArgb(170,170,170);
            this.ControlCommonScrollBarBackground = Color.FromArgb(61, 69, 80);
            this.ControlCommonScrollBarArrowColor = Color.FromArgb(0, 0, 0);
            this.ControlCommonScrollBarForeground = Color.FromArgb(151, 151, 151);
            this.ControlCommonScrollBarSelectedColor = Color.FromArgb(141, 141, 141);

            // SOILabel
            this.LabelForeground = Color.FromArgb(255, 255, 255);
            this.LabelBackground = Color.Transparent;
            this.LabelKeyForeground = Color.FromArgb(211, 212, 213);
            this.LabelValueForeground = Color.FromArgb(255, 255, 255);

            // SOITextBox                                    
            this.TextBoxBackground = Color.FromArgb(61,69,80);
            this.TextBoxBorder = Color.FromArgb(61,69,80);
            this.TextBoxForeground = Color.FromArgb(255,255,255);
            //this.TextBoxFocusedBackground = Color.FromArgb(0,164,238);            
            this.TextBoxFocusedBackground = Color.FromArgb(240, 249, 104);
            this.TextBoxFocusedForeground = Color.FromArgb(0, 0, 0);
            this.TextBoxMouseOverBorder = Color.FromArgb(43, 42, 48);
            this.TextBoxReadOnlyBackground = Color.FromArgb(151, 151, 151);
            this.TextBoxValidationBorder = Color.Red;

            // SOITextBoxValue
            this.TextBoxValueForeground = Color.FromArgb(255,255,255);

            // SOIComboBox
            this.ComboBoxForeground = this.TextBoxForeground;
            this.ComboBoxBackground = this.TextBoxBackground;
            this.ComboBoxBorder = this.TextBoxBorder;
            this.ComboBoxArrow = this.PopupTopBackground;
            this.ComboBoxMouseOverBorder = this.TextBoxMouseOverBorder;

            // SOIButton
            this.ButtonDefaultBackground = Color.FromArgb(13,121,159);
            this.ButtonDefaultHoverBackground = Color.FromArgb(3, 111, 149);
            this.ButtonDefaultPressBackground = this.ButtonDefaultBackground;
            this.ButtonCancelBackground = Color.FromArgb(112,112,112);
            this.ButtonCancelHoverBackground = Color.FromArgb(127,127,127);
            this.ButtonCancelPressBackground = this.ButtonCancelBackground;

            // SOIButtonImage            
            this.ButtonImageDefaultBackground = Color.FromArgb(13, 121, 159);
            this.ButtonImageDefaultHoverBackground = Color.FromArgb(3, 111, 149);
            this.ButtonImageDefaultPressBackground = this.ButtonImageDefaultBackground;
            this.ButtonImageTransparentBackground = Color.Transparent;
            this.ButtonImageTransparentHoverForeground = Color.FromArgb(228, 228, 228);
            this.ButtonImageProcessBackground = Color.FromArgb(19, 96, 125);
            this.ButtonImageProcessHoverBackground = Color.FromArgb(9, 86, 115);
            this.ButtonImageProcessPressBackground = this.ButtonImageProcessBackground;
            this.ButtonImageCloseBackground = Color.FromArgb(112, 112, 112);
            this.ButtonImageCloseHoverBackground = Color.FromArgb(127, 127, 127);
            this.ButtonImageClosePressBackground = this.ButtonImageCloseBackground;

            // SOICodeView
            this.CodeViewButtonBackground = this.ButtonDefaultBackground;

            // SOICheckBox
            this.CheckBoxForeground = this.TextBoxForeground;
            this.CheckBoxBackground = Color.Transparent;

            // SOICheckBoxOnOff
            this.CheckBoxOnOffBorder = Color.FromArgb(61, 69, 80);
            this.CheckBoxOnOffOnBackground = Color.FromArgb(13, 121, 159);
            this.CheckBoxOnOffOnForeground = Color.FromArgb(255, 255, 255);
            this.CheckBoxOnOffOffBackground = Color.FromArgb(61, 69, 80);
            this.CheckBoxOnOffOffForeground = Color.FromArgb(211, 212, 213);
            this.CheckBoxOnOffButtonBackground = Color.FromArgb(17, 20, 27);
            this.CheckBoxOnOffButtonBorder = Color.FromArgb(17, 20, 27);

            // SOIRadioButton
            this.RadioButtonBackground = Color.Transparent;
            this.RadioButtonForeground = this.LabelForeground;

            // SOIUnderline
            this.UnderlineBackground = Color.FromArgb(87, 91, 100);

            // SOIDateTime
            this.DateTimeForeground = this.TextBoxForeground;
            this.DateTimeBackground = this.TextBoxBackground;
            this.DateTimeBorder = this.TextBoxBorder;
            this.DateTimeButtonBackground = Color.FromArgb(40, 48, 61);
            this.DateTimeMouseOverBorder = this.TextBoxMouseOverBorder;
            this.DateTimeCalendarHeaderBackground = Color.FromArgb(40, 48, 61);
            this.DateTimeCalendarHeaderForeground = Color.FromArgb(255, 255, 255);
            this.DateTimeCalendarDayForeground = Color.FromArgb(255,255,255);
            this.DateTimeCalendarTrailDayForeground = Color.FromArgb(90, 90, 90);
            this.DateTimeCalendarActivaDayBackground = Color.FromArgb(43, 42, 48);

            // SOIListBox
            this.ListBoxBackground = Color.FromArgb(28, 52, 78);
            this.ListBoxBorder = Color.FromArgb(59,59,69);
            this.ListBoxBorderForMenu = Color.FromArgb(28, 52, 78);
            this.ListBoxRowBackground = Color.FromArgb(28, 52, 78);
            this.ListBoxRowForeground = Color.FromArgb(255, 255, 255);
            this.ListBoxRowMouseOverBackground = Color.FromArgb(20, 73, 119);
            this.ListBoxRowSelectedBackground = Color.FromArgb(68,102,130);
            this.ListBoxScrollThumbBackground = this.ControlCommonScrollBarForeground;

            // SOITabControl
            //this.TabControlBackground = this.MainMenuFormBackground;
            this.TabControlBackground = Color.FromArgb(28, 52, 78);
            this.TabControlForeground = this.Foreground;
            this.TabControlBorder = Color.FromArgb(34, 39, 45);            
            //this.TabControlActiveTabBackground = Color.FromArgb(28, 52, 78);
            this.TabControlActiveTabBackground = Color.FromArgb(34, 39, 45);
            this.TabControlActiveTabForeground = Color.FromArgb(59, 217, 229);
            this.TabControlMenuBackground = this.MainMenuFormBackground;
            this.TabControlMenuForeground = this.Foreground;
            this.TabControlMenuBorder = Color.FromArgb(59, 59, 69);
            this.TabControlMenuActiveTabBackground = Color.FromArgb(28, 52, 78);
            this.TabControlMenuActiveTabForeground = Color.FromArgb(59, 217, 229);

            // SOIGroupBox
            this.GroupBoxBackground = Color.FromArgb(34,39,45);
            this.GroupBoxBorder = Color.FromArgb(34, 39, 45);
            this.GroupBoxHeaderForeground = Color.FromArgb(59,217,229);
            this.GroupBoxHeaderBackground = Color.FromArgb(17, 20, 27);
            this.GroupBoxNumberStyleBackground = Color.FromArgb(58, 65, 73);
            this.GroupBoxNumberStyleHeaderBackground = Color.FromArgb(79, 107, 129);
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
            this.ListViewColumnHeaderBackground = Color.FromArgb(0,120,215);

            // SOITreeView
            this.TreeViewBackground = Color.FromArgb(28,52,78);
            this.TreeViewForeground = Color.FromArgb(255,255,255);
            this.TreeViewLineForeground = Color.FromArgb(138, 193, 237);
            this.TreeViewScrollThumbBackground = this.ListBoxScrollThumbBackground;

            // SOIGrid
            this.GridBackground = this.TextBoxBackground;
            this.GridBorder = Color.FromArgb(34,39,45);
            this.GridColumnHeaderForeground = this.Foreground;
            this.GridColumnHeaderBackground = Color.FromArgb(79,107,129);
            this.GridCellBorder = this.GridBorder;
            this.GridCellForeground = this.TextBoxForeground;            
            this.GridRowSelectedBackground = Color.FromArgb(43,42,48);

            // SOIChart
            this.ChartBackground = Color.FromArgb(61,69,80);
            this.ChartForeground = Color.FromArgb(255, 255, 255);
            this.ChartBorder = this.GridBorder;
            this.ChartBarYLineBorder = Color.FromArgb(255, 255, 255);
            this.ChartBarDefaultBarColor = Color.FromArgb(49, 187, 197);
            //this.ChartBarDefaultBarColor = Color.FromArgb(1,116,207);

            // SOISpread
            this.SpreadBackground = this.GridBackground;
            this.SpreadBorder = this.GridBorder;
            this.SpreadColumnHeaderForeground = this.GridColumnHeaderForeground;
            this.SpreadColumnHeaderBackground = this.GridColumnHeaderBackground;
            this.SpreadCellBorder = this.GridCellBorder;
            this.SpreadCellForeground = this.GridCellForeground;
            this.SpreadRowSelectedBackground = Color.FromArgb(0, 164, 238);
            this.SpreadCellEditableBackColor = Color.FromArgb(61, 69, 80);
            this.SpreadCellReadOnlyBackColor = Color.FromArgb(151, 151, 151);

            // SOIFlexibleScreen
            this.FlexibleScreenBackground = Color.FromArgb(255, 255, 255);
            this.FlexibleScreenCellForeground = Color.FromArgb(0, 0, 0);
        }
    }
}
