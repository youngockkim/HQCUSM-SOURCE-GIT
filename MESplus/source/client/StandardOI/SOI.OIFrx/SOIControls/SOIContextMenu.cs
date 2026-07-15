using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using System.Drawing;
using System.Windows.Forms;
using SOI.OIFrx.SOIControls;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIContextMenu : UltraToolbarsManager
    {
        #region Property

        private PopupMenuTool menuTool = new PopupMenuTool(MPGC.CONTROL_CONTEXT_MENU_KEY);
        private ButtonTool btnToolCut = new ButtonTool("cut");
        private ButtonTool btnToolCopy = new ButtonTool("copy");
        private ButtonTool btnToolPaste = new ButtonTool("paste");
        private ButtonTool btnToolSelectAll = new ButtonTool("selectAll");
        private ButtonTool btnToolCopyCell = new ButtonTool("copyCell");
        private ButtonTool btnToolCopyRow = new ButtonTool("copyRow");
        private ButtonTool btnToolPrint = new ButtonTool("print");

        private Control parentControl;

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        #endregion

        #region Constructor

        public SOIContextMenu()
        {
            InitializeComponent();
        }

        public SOIContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 공통 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.FontData.SizeInPoints = 11;
                this.MenuSettings.PopupStyle = PopupStyle.Menu;
                this.MenuSettings.ToolDisplayStyle = ToolDisplayStyle.TextOnlyAlways;                
                this.ImageSizeLarge = new Size(0, 0);
                this.ImageSizeSmall = new Size(0, 0);

                // 공통 색상
                this.Appearance.BackColor = MPGV.gTheme.ContextMenuBackground;
                this.Appearance.BorderColor = MPGV.gTheme.ContextMenuBorder;
                this.Appearance.ForeColor = MPGV.gTheme.ContextMenuForeground;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.MenuSettings.IconAreaAppearance.BackColor = MPGV.gTheme.ContextMenuBackground;
            }
        }

        /// <summary>
        /// Parent Control에 따라 다른 Tool을 Add 합니다.
        /// </summary>
        /// <param name="parentControl"></param>
        public void SetTools(Control ctrl)
        {
            // 테마 설정
            SetOITheme();

            // Parent Control 할당
            this.parentControl = ctrl;

            if (ctrl is SOITextBox)
            {
                // Button 속성 설정
                btnToolCut.SharedProps.Caption = MPCF.FindLanguage("Cut");                
                btnToolCopy.SharedProps.Caption = MPCF.FindLanguage("Copy");
                btnToolPaste.SharedProps.Caption = MPCF.FindLanguage("Paste");
                btnToolSelectAll.SharedProps.Caption = MPCF.FindLanguage("Select All");
                btnToolSelectAll.InstanceProps.IsFirstInGroup = true;

                menuTool.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
                    btnToolCut,
                    btnToolCopy,
                    btnToolPaste,
                    btnToolSelectAll
                });

                this.Tools.Add(menuTool);
            }
            else if (ctrl is SOIGrid)
            {
                // Button 속성 설정
                btnToolCopyCell.SharedProps.Caption = MPCF.FindLanguage("Copy Cell");
                btnToolCopyRow.SharedProps.Caption = MPCF.FindLanguage("Copy Row");
                //btnToolPrint.SharedProps.Caption = MPCF.FindLanguage("Print");
                //btnToolPrint.InstanceProps.IsFirstInGroup = true;

                menuTool.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
                    btnToolCopyCell,
                    btnToolCopyRow
                });

                //menuTool.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
                //    btnToolCopyCell,
                //    btnToolCopyRow,
                //    btnToolPrint
                //});

                this.Tools.Add(menuTool);
            }
            else if (ctrl is SOISpread)
            {
                // Button 속성 설정
                btnToolCopyCell.SharedProps.Caption = MPCF.FindLanguage("Copy Cell");
                btnToolCopyRow.SharedProps.Caption = MPCF.FindLanguage("Copy Row");
                
                menuTool.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
                    btnToolCopyCell,
                    btnToolCopyRow
                });

                this.Tools.Add(menuTool);
            }
        }

        #endregion
    }
}
