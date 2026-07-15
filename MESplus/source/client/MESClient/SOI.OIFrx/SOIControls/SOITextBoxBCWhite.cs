using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIThemes;
using System.Drawing;
using SOI.OIFrx.SOIControls;
using Infragistics.Win.UltraWinToolbars;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOITextBoxBCWhite : UltraTextEditor
    {
        #region Property

        private SOIContextMenu textBoxContextMenu;

        private bool bFocused = false;
        private bool bMouseOver = false;
        private bool bValidation = false;

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

        public new bool ReadOnly
        {
            get 
            { 
                return base.ReadOnly; 
            }
            set 
            {
                base.ReadOnly = value;
                SetOITheme();
            }
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                SetOITheme();
            }
        }

        private bool useSOIContextMenu = true;
        public bool UseSOIContextMenu
        {
            get
            {
                return useSOIContextMenu;
            }
            set
            {
                useSOIContextMenu = value;
                SetContextMenu(useSOIContextMenu);
            }
        }

        #endregion

        #region Constructor

        public SOITextBoxBCWhite()
        {
            InitializeComponent();
        }

        public SOITextBoxBCWhite(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        private void SOITextBox_Enter(object sender, EventArgs e)
        {
            bFocused = true;
            SetOITheme();
            SetTouchKeyboard(true);
        }

        private void SOITextBox_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
            SetTouchKeyboard(false);
        }

        private void SOITextBox_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOITextBox_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void SOITextBox_TextChanged(object sender, EventArgs e)
        {
            if (bValidation == true)
            {
                bValidation = false;
                MPOF.ShowMessage("", MSSAG_LEVEL.NONE, false);
                SetOITheme();
            }
        }

        private void textBoxContextMenu_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
            if (this.SelectionLength < 1)
            {
                textBoxContextMenu.Tools["cut"].SharedProps.Enabled = false;
            }
            else
            {
                textBoxContextMenu.Tools["cut"].SharedProps.Enabled = true;
            }

            if (string.IsNullOrEmpty(Clipboard.GetText()) == true)
            {
                textBoxContextMenu.Tools["paste"].SharedProps.Enabled = false;
            }
            else
            {
                textBoxContextMenu.Tools["paste"].SharedProps.Enabled = true;
            }
        }

        private void textBoxContextMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            if (e.Tool.Key == "cut")
            {
                this.Cut();
            }
            else if (e.Tool.Key == "copy")
            {
                this.Copy();
            }
            else if (e.Tool.Key == "paste")
            {
                this.Paste();
            }
            else if (e.Tool.Key == "selectAll")
            {
                this.SelectAll();
            }
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
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;                
                
                // Enable 상태가 아닌 경우
                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MOGV.gTheme.ControlCommonDisabledBorder;
                }
                // 읽기 전용인 경우
                else if (base.ReadOnly == true)
                {
                    this.Appearance.BackColor = MOGV.gTheme.TextBoxReadOnlyBackground;
                    this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                    this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                }
                else
                {
                    // Focus 상태인 경우
                    if (bFocused == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxFocusedBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxFocusedForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                        }
                    }
                    // Mouse Over 상태인 경우
                    else if (bMouseOver == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.TextBoxMouseOverBorder;
                        }
                    }
                    // 일반상태인 경우
                    else
                    {
                        this.Appearance.BackColor = Color.White;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Validation을 설정합니다.
        /// </summary>
        public void SetValidation()
        {
            bValidation = true;
            this.Appearance.BorderColor = MOGV.gTheme.TextBoxValidationBorder;
        }

        /// <summary>
        /// Context Menu를 설정합니다.
        /// </summary>
        /// <param name="enable"></param>
        public void SetContextMenu(bool bUse)
        {
            // 사용하는 경우
            if (bUse == true)
            {
                // Context Menu 초기화
                if (textBoxContextMenu == null)
                {
                    textBoxContextMenu = new SOIContextMenu();

                    // Tool Button 할당
                    textBoxContextMenu.SetTools(this);

                    // Context Meu 할당
                    textBoxContextMenu.SetContextMenuUltra(this, MOGC.CONTROL_CONTEXT_MENU_KEY);

                    // Event Handler 등록
                    textBoxContextMenu.BeforeToolDropdown += new BeforeToolDropdownEventHandler(textBoxContextMenu_BeforeToolDropdown);
                    textBoxContextMenu.ToolClick += new ToolClickEventHandler(textBoxContextMenu_ToolClick);
                }
            }
            // 사용하지 않는 경우
            else
            {
                textBoxContextMenu.Dispose();
            }
        }

        /// <summary>
        /// Touch Keyboard를 보이거나 감춥니다.
        /// </summary>
        /// <param name="use"></param>
        public void SetTouchKeyboard(bool use)
        {
            // 읽기 전용인 경우 제외
            if (this.ReadOnly == true)
            {
                return;
            }

            // Touch Keyboard Use
            MPOF.ShowTouchKeyboard(use);
        }

        #endregion
    }
}
