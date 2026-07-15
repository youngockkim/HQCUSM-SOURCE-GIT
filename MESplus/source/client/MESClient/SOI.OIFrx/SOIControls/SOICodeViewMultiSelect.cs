using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using System.Windows.Forms;
using SOI.OIFrx.SOIPopup;
using Miracom.TRSCore;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOICodeViewMultiSelect : UltraTextEditor
    {
        #region Properties

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

        public DialogResult drResult;

        public List<string> returnValues;
        public TRSNode returnData;

        private frmCodeViewMultiSelectPopup cvp;

        public event EventHandler CodeViewButtonClick;
        private void OnCodeViewButtonClick(object sender, EventArgs e)
        {
            if (CodeViewButtonClick != null)
            {
                CodeViewButtonClick(this, e);
            }
        }

        #endregion

        #region Constructor

        public SOICodeViewMultiSelect()
        {
            InitializeComponent();
        }

        public SOICodeViewMultiSelect(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.ButtonsRight.Exists("CodeViewButton"))
            {
                return;
            }

            EditorButton btnCodeView = new EditorButton();
            btnCodeView.Key = "CodeViewButton";
            btnCodeView.Width = 30;
            btnCodeView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            btnCodeView.Appearance.BackColor = MOGV.gTheme.CodeViewButtonBackground;
            btnCodeView.Appearance.Image = Properties.Resources.CodeViewButtonImage;
            this.ButtonsRight.Add(btnCodeView);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        private void SOICodeViewMultiSelect_Enter(object sender, EventArgs e)
        {
            bFocused = true;
            SetOITheme();
        }

        private void SOICodeViewMultiSelect_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
        }

        private void SOICodeViewMultiSelect_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOICodeViewMultiSelect_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void SOICodeViewMultiSelect_TextChanged(object sender, EventArgs e)
        {
            if (DesignMode == true)
            {
                return;
            }

            SetValidationOff();
        }

        private void SOICodeViewMultiSelect_Click(object sender, EventArgs e)
        {
            OnCodeViewButtonClick(this, e);
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
                // 공통속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

                // 공통색상
                this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
                if (ButtonsRight.Count > 0)
                {
                    this.ButtonsRight[0].Appearance.BackColor = MOGV.gTheme.CodeViewButtonBackground;
                }

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MOGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    // 색상                
                    if (bFocused == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxFocusedBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxFocusedForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                        }
                    }
                    else if (bMouseOver == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.TextBoxMouseOverBorder;
                        }
                    }
                    else
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxBackground;
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
        /// Validation을 합니다.
        /// </summary>
        public void SetValidation()
        {
            bValidation = true;
            this.Appearance.BorderColor = MOGV.gTheme.TextBoxValidationBorder;
        }

        /// <summary>
        /// Validation을 해제합니다.
        /// </summary>
        private void SetValidationOff()
        {
            bValidation = false;
            MPOF.ShowMessage("", MSSAG_LEVEL.NONE, false);
            SetOITheme();
        }

        /// <summary>
        /// CodeView Popup 창을 엽니다.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="popupTitle"></param>
        /// <param name="moduleName"></param>
        /// <param name="serviceName"></param>
        /// <param name="inNode"></param>
        /// <param name="listName"></param>
        /// <param name="displayColumn"></param>
        /// <param name="header"></param>
        /// <param name="selectedColumn"></param>
        /// <returns></returns>
        public string Show(SOICodeViewMultiSelect control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn)
        {
            return Show(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, selectedColumn, -1);
        }

        /// <summary>
        /// CodeView Popup 창을 엽니다.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="popupTitle"></param>
        /// <param name="moduleName"></param>
        /// <param name="serviceName"></param>
        /// <param name="inNode"></param>
        /// <param name="listName"></param>
        /// <param name="displayColumn"></param>
        /// <param name="header"></param>
        /// <param name="selectedColumn"></param>
        /// <returns></returns>
        public string Show(SOICodeViewMultiSelect control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            string sReturn = string.Empty;
            List<string> returnValues;
            TRSNode returnData;

            try
            {
                // 리턴값 초기화
                sReturn = control.Text;
                returnValues = control.returnValues;
                returnData = control.returnData;

                // 신규 팝업 생성
                cvp = new frmCodeViewMultiSelectPopup();

                // 초기화
                if (cvp.InitCodeViewPopup(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, selectedColumn, pageSize, returnValues, returnData) == false)
                {
                    return sReturn;
                }

                // Show Dialog
                cvp.Owner = MOGV.gfrmMDI;
                drResult = cvp.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnValues = cvp.ReturnValues;
                    this.returnData = cvp.ReturnData;
                    //SetValidationOff();
                }
                // Field Reset한 경우
                else if (drResult == DialogResult.No)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnValues = cvp.ReturnValues;
                    this.returnData = cvp.ReturnData;
                }
                // 취소한 경우
                else
                {
                    this.returnValues = returnValues;
                    this.returnData = returnData;
                }

                if (cvp.Owner != null)
                {
                    cvp.Owner.Activate();
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MPOF.ShowErrorMessage("CodeView Show() \n" + ex.Message);
                return control.Text;
            }
        }

        #endregion
    }
}
