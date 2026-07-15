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
    public partial class SOITextBox : UltraTextEditor
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

        private int _decimalCount = 3;
        public int _DecimalCount
        {
            get
            {
                return _decimalCount;
            }
            set
            {
                _decimalCount = value;
            }
        }

        private bool _useOnlyNumeric = false;
        public bool _UseOnlyNumeric
        {
            get
            {
                return _useOnlyNumeric;
            }
            set
            {
                _useOnlyNumeric = value;
                SetOnlyNumeric();
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

        public SOITextBox()
        {
            InitializeComponent();
        }

        public SOITextBox(IContainer container)
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
            SetNumericPattern();
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
                MPCF.ShowMessage("", CliFrx.MSG_LEVEL.NONE, false);
                SetOITheme();
            }
        }

        private void SOITextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_useOnlyNumeric == true)
            {
                // 8 : Backsapce
                // 45 : Minus
                // 46 : 소수점
                // 기타 문자는 제외
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 46)
                {
                    e.Handled = true;
                }

                if (e.KeyChar == 46 && this.Text.Contains('.') == true)
                {
                    e.Handled = true;
                }

                if (e.KeyChar == 46 && _DecimalCount <= 0)
                {
                    e.Handled = true;
                }

                if (e.KeyChar != 8 && this.Text.Contains('.') == true && _DecimalCount > 0)
                {
                    if ((this.Text.IndexOf('.') + _DecimalCount) < this.Text.Length)
                    {
                        e.Handled = true;
                    }
                }
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
                this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;                
                
                // Enable 상태가 아닌 경우
                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                }
                // 읽기 전용인 경우
                else if (base.ReadOnly == true)
                {
                    this.Appearance.BackColor = MPGV.gTheme.TextBoxReadOnlyBackground;
                    this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                    this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
                }
                else
                {
                    // Focus 상태인 경우
                    if (bFocused == true)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxFocusedBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxFocusedForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
                        }
                    }
                    // Mouse Over 상태인 경우
                    else if (bMouseOver == true)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxMouseOverBorder;
                        }
                    }
                    // 일반상태인 경우
                    else
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 숫자만 입력가능한 형태로 변경합니다.
        /// </summary>
        public void SetOnlyNumeric()
        {
            this.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
        }

        /// <summary>
        /// 패턴을 점검합니다.
        /// </summary>
        public void SetNumericPattern()
        {
            if (_useOnlyNumeric == true)
            {
                //if (this.Text.Contains('.') == true)
                //{
                //    if (this.Text.Count(f => f == '.') > 1)
                //    {
                //        char[] numbers = this.Text.ToCharArray();
                //        int iNumLength = numbers.Length;
                //        bool bFirstFound = false;
                //        for (int i = iNumLength - 1; i >= 0; i--)
                //        {
                //            if (numbers[i] == '.')
                //            {
                //                if (bFirstFound == false)
                //                {
                //                    bFirstFound = true;
                //                    continue;
                //                }
                //                else
                //                {
                //                    this.Text = this.Text.Remove(i, 1);
                //                }
                //            }
                //        }
                //    }
                //}                
            }
        }

        /// <summary>
        /// Validation을 설정합니다.
        /// </summary>
        public void SetValidation()
        {
            bValidation = true;
            this.Appearance.BorderColor = MPGV.gTheme.TextBoxValidationBorder;
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
                    textBoxContextMenu.SetContextMenuUltra(this, MPGC.CONTROL_CONTEXT_MENU_KEY);

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
            MPCF.ShowTouchKeyboard(use);
        }

        #endregion
    }

    public class NoFocusRect : Infragistics.Win.IUIElementDrawFilter
    {
        #region Implementation of IUIElementDrawFilter
        public bool DrawElement(Infragistics.Win.DrawPhase drawPhase, ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return true;
        }
        public Infragistics.Win.DrawPhase GetPhasesToFilter(ref Infragistics.Win.UIElementDrawParams drawParams)
        {
            return Infragistics.Win.DrawPhase.BeforeDrawFocus;
        }
        #endregion
    }
}
