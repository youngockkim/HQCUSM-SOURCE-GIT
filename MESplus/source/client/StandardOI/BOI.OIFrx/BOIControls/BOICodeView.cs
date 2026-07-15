using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using System.Windows.Forms;
using Miracom.TRSCore;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx;
using SOI.OIFrx.SOIControls;
using CliFrx = SOI.CliFrx;
using BOI.OIFrx.BOIPopup;
using SOI.DNM;

namespace BOI.OIFrx.BOIControls
{
    public partial class BOICodeView : SOICodeView
    {
        #region Property

        public bool bFocused = false;
        public bool bMouseOver = false;
        public bool bValidation = false;

        private new DialogResult drResult;

        public new List<string> returnDatas;

        public List<List<string>> ReturnList;

        private BOI.OIFrx.BOIPopup.frmCodeViewPopup cvp;

        private frmCodeViewMultiSelPopup cvmsp;

        public new event EventHandler CodeViewButtonClick;
        private void OnCodeViewButtonClick(object sender, EventArgs e)
        {
            if (CodeViewButtonClick != null)
            {
                CodeViewButtonClick(this, e);

            }
        }

        private bool bSaveRegistry = true;
        [Browsable(true)]
        public bool SaveRegistry
        {
            get
            {
                return bSaveRegistry;
            }
            set
            {
                bSaveRegistry = value;
            }
        }

        #endregion

        #region Constructor

        public BOICodeView()
        {
            base.Events.Dispose();
            InitializeComponent();            
        }

        public BOICodeView(IContainer container)
        {
            base.Events.Dispose();
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
            btnCodeView.Appearance.BackColor = MPGV.gTheme.CodeViewButtonBackground;
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
        

        private void BOICodeView_Enter(object sender, EventArgs e)
        {
            bFocused = true;
            SetOITheme();
        }

        private void BOICodeView_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
        }

        private void BOICodeView_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void BOICodeView_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void BOICodeView_TextChanged(object sender, EventArgs e)
        {
            if (DesignMode == true)
            {
                return;
            }

            SetValidationOff();
        }

        private void BOICodeView_Click(object sender, EventArgs e)
        {
            OnCodeViewButtonClick(this, e);
        }

        #endregion

        #region Function

     


        /// <summary>
        /// Validation을 해제합니다.
        /// </summary>
        private void SetValidationOff()
        {
            bValidation = false;
            MPCF.ShowMessage("", CliFrx.MSG_LEVEL.NONE, false);
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
        public string Show(BOICodeView control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
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
        public string Show(BOICodeView control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            string sReturn = string.Empty;

            try
            {
                // 리턴값 초기화
                sReturn = control.Text;

                // 신규 팝업 생성             
                cvp = new BOI.OIFrx.BOIPopup.frmCodeViewPopup();

                // 초기화
                if (cvp.InitCodeViewPopup(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, selectedColumn, pageSize) == false)
                {
                    return sReturn;
                }

                // Show Dialog
                cvp.Owner = MPGV.gfrmMDI;
                drResult = cvp.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnDatas = cvp.ReturnDatas;                    
                    //SetValidationOff();
                }
                // Field Reset한 경우
                else if (drResult == DialogResult.No)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnDatas = cvp.ReturnDatas;
                }
                // 취소한 경우
                else
                {
                    // 아무것도 하지 않음
                }

                if (cvp.Owner != null)
                {
                    cvp.Owner.Activate();
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("CodeView Show() \n" + ex.Message);
                return control.Text;
            }
        }

        public string Show(BOICodeView control, string popupTitle, string sViewID, TPDR.DirectViewCond[] dvcArgu,
            string selectedColumn, int pageSize)
        {
            return Show(control, popupTitle, sViewID, dvcArgu, null, null, selectedColumn, pageSize, false);
        }

        public string Show(BOICodeView control, string popupTitle, string sViewID, TPDR.DirectViewCond[] dvcArgu,
            string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            return Show(control, popupTitle, sViewID, dvcArgu, displayColumn, header, selectedColumn, pageSize, false);
        }

        public string Show(BOICodeView control, string popupTitle, string sViewID, TPDR.DirectViewCond[] cvcArgu,
            string[] displayColumn, string[] header, string selectedColumn, int pageSize, bool isDirectView)
        {
            string sReturn = string.Empty;

            try
            {
                // 리턴값 초기화
                sReturn = control.Text;

                // 신규 팝업 생성             
                cvp = new BOI.OIFrx.BOIPopup.frmCodeViewPopup();

                // 초기화
                if (cvp.InitCodeViewPopup(control, popupTitle, sViewID, cvcArgu, displayColumn, header, selectedColumn, pageSize, isDirectView) == false)
                {
                    return sReturn;
                }

                // Show Dialog
                cvp.Owner = MPGV.gfrmMDI;
                drResult = cvp.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnDatas = cvp.ReturnDatas;
                    //SetValidationOff();
                }
                // Field Reset한 경우
                else if (drResult == DialogResult.No)
                {
                    sReturn = cvp.ReturnValue;
                    this.returnDatas = cvp.ReturnDatas;
                }
                // 취소한 경우
                else
                {
                    // 아무것도 하지 않음
                }

                if (cvp.Owner != null)
                {
                    cvp.Owner.Activate();
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("CodeView Show() \n" + ex.Message);
                return control.Text;
            }
        }

        public string ShowMultiSelect(BOICodeView control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn)
        {
            return ShowMultiSelect(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, selectedColumn, -1);
        }

        public string ShowMultiSelect(BOICodeView control, string popupTitle, string moduleName, string serviceName, TRSNode inNode,
            string listName, string[] displayColumn, string[] header, string selectedColumn, int pageSize)
        {
            string sReturn = string.Empty;

            try
            {
                // 리턴값 초기화
                sReturn = control.Text;

                // 신규 팝업 생성
                
                cvmsp = new frmCodeViewMultiSelPopup();
                
                // 초기화
                if (cvmsp.InitCodeViewPopup(control, popupTitle, moduleName, serviceName, inNode, listName, displayColumn, header, selectedColumn, pageSize) == false)
                {
                    return sReturn;
                }

                // Show Dialog
                cvmsp.Owner = MPGV.gfrmMDI;
                drResult = cvmsp.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    sReturn = cvmsp.ReturnValue;
                    this.returnDatas = cvmsp.ReturnDatas;
                    this.ReturnList = cvmsp.ReturnList;
                    //SetValidationOff();
                }
                // Field Reset한 경우
                else if (drResult == DialogResult.No)
                {
                    sReturn = cvmsp.ReturnValue;
                    this.returnDatas = cvmsp.ReturnDatas;
                    this.ReturnList = cvmsp.ReturnList;
                }
                // 취소한 경우
                else
                {
                    // 아무것도 하지 않음
                }

                if (cvmsp.Owner != null)
                {
                    cvmsp.Owner.Activate();
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("CodeView Show() \n" + ex.Message);
                return control.Text;
            }
        }

        #endregion
    }
}
