using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.TRSCore;
using SOI.OIFrx.SOIPopup;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOICodeViewDescription : UserControl
    {
        #region Property

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

        private bool _useConvertLanguageCode = false; // Convert가 필요한 경우 사용.
        public bool _UseConvertLanguageCode
        {
            get
            {
                return _useConvertLanguageCode;
            }
            set
            {
                _useConvertLanguageCode = value;
            }
        }

        private bool _useConvertLanguageDesc = false; // Convert가 필요한 경우 사용.
        public bool _UseConvertLanguageDesc
        {
            get
            {
                return _useConvertLanguageDesc;
            }
            set
            {
                _useConvertLanguageDesc = value;
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

        private bool _descriptionVisible = true;
        public new bool DescriptionVisible
        {
            get
            {
                return _descriptionVisible;
            }
            set
            {
                _descriptionVisible = value;
                SetOITheme();
            }
        }

        public new string Text
        {
            get
            {
                return this.cdvCode.Text;
            }
            set
            {
                this.cdvCode.Text = value;
            }
        }

        public string Code
        {
            get
            {
                return this.cdvCode.Text;
            }
            set
            {
                this.cdvCode.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return this.txtDesc.Text;
            }
            set
            {
                this.txtDesc.Text = value;
            }
        }

        private int codeWidth;
        public int CodeWidth
        {
            get
            {
                return codeWidth;
            }
            set
            {
                codeWidth = value;
                this.pnlCode.Width = codeWidth;
            }
        }

        public event EventHandler CodeViewButtonClick;
        private void OnCodeViewButtonClick(object sender, EventArgs e)
        {
            if (CodeViewButtonClick != null)
            {
                CodeViewButtonClick(this, e);
            }
        }

        public event EventHandler ValueChanged;
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        public DialogResult drResult;

        public List<string> returnDatas;

        #endregion

        #region Constructor

        public SOICodeViewDescription()
        {
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

        private void cdvDesc_CodeViewButtonClick(object sender, EventArgs e)
        {
            CodeViewButtonClick(this, e);
        }

        private void cdvCode_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(this, e);
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            // Description Visible 처리
            pnlDesc.Visible = _descriptionVisible;
            pnlMargin.Visible = _descriptionVisible;

            if (_UseOITheme == true)
            {
                // 정의 속성
                this.pnlCode.Width = codeWidth;

                

                //// 공통 속성
                //this.lblOnText.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.lblOnText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                //this.btnOff.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.btnOff.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                //this.btnOn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                //this.btnOn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                //this.lblOnText.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                //this.lblOffText.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                //// 공통 색상
                //this.pnlOutBorder.BackColor = MPGV.gTheme.CheckBoxOnOffBorder;
                //this.lblOnText.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffOnBackground;
                //this.lblOnText.Appearance.ForeColor = MPGV.gTheme.CheckBoxOnOffOnForeground;
                //this.lblOffText.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffOffBackground;
                //this.lblOffText.Appearance.ForeColor = MPGV.gTheme.CheckBoxOnOffOffForeground;
                //this.btnOff.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffButtonBackground;
                //this.btnOff.Appearance.BorderColor = MPGV.gTheme.CheckBoxOnOffButtonBorder;
                //this.btnOn.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffButtonBackground;
                //this.btnOn.Appearance.BorderColor = MPGV.gTheme.CheckBoxOnOffButtonBorder;

                //// Enable 상태가 아닌 경우
                //if (base.Enabled == false)
                //{
                //    this.lblOnText.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                //    this.lblOnText.Appearance.ForeColor = MPGV.gTheme.ControlCommonDisabledForeground;
                //    this.lblOffText.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                //    this.lblOffText.Appearance.ForeColor = MPGV.gTheme.ControlCommonDisabledForeground;
                //    this.btnOff.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                //    this.btnOn.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                //}
            }
        }

        /// <summary>
        /// Validation을 합니다.
        /// </summary>
        public void SetValidation()
        {
            this.cdvCode.SetValidation();
        }

        /// <summary>
        /// CodeView Popup 창을 엽니다.
        /// 
        /// --Default--
        /// visibleFalse : null
        /// pageSize : -1
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
        public string Show(SOICodeViewDescription control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn)
        {
            return Show(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, null, selectedColumn, -1);
        }

        /// <summary>
        /// CodeView Popup 창을 엽니다.
        /// 
        /// --Default--
        /// pageSize : -1
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
        public string Show(SOICodeViewDescription control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string[] visibleFalse, string selectedColumn)
        {
            return Show(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, visibleFalse, selectedColumn, -1);
        }

        /// <summary>
        /// CodeView Popup 창을 엽니다.
        /// 
        /// --Default--
        /// visibleFalse : null
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
        public string Show(SOICodeViewDescription control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            return Show(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, null, selectedColumn, pageSize);
        }

        /// <summary>
        /// Open CodeViewPopup
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
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string Show(SOICodeViewDescription control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string[] visibleFalse, string selectedColumn, int pageSize)
        {
            string sReturn = string.Empty;

            try
            {
                // Code Return
                sReturn = this.cdvCode.Show(cdvCode, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, visibleFalse, selectedColumn, pageSize);

                this.drResult = this.cdvCode.drResult;

                if (this.drResult != DialogResult.Cancel)
                {
                    if (cdvCode.returnDatas != null && cdvCode.returnDatas.Count > 1)
                    {
                        this.Description = cdvCode.returnDatas[1];
                    }
                    else
                    {
                        this.Description = string.Empty;
                    }

                    this.returnDatas = cdvCode.returnDatas;
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
                return control.Code;
            }
        }

        #endregion
    }
}
