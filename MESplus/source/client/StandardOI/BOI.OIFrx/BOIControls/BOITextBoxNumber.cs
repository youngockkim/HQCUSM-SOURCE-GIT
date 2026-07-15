using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using BOI.OIFrx.BOIPopup;
using System.Drawing;
using System.Windows.Forms;
using SOI.OIFrx;
using CliFrx = SOI.CliFrx;
using SOI.OIFrx.SOIControls;

namespace BOI.OIFrx.BOIControls
{
    public partial class BOITextBoxNumber : SOITextBoxNumber
    {
        #region Property

        public bool bFocused = false;
        public bool bMouseOver = false;
        private bool bValidation = false;
        private bool bKeyDown = false;

        private frmLargeKeyPad keyPad;

        #endregion

        #region Contructor

        public BOITextBoxNumber()
        {
            base.Events.Dispose();
            InitializeComponent();            
        }

        public BOITextBoxNumber(IContainer container) : base (container)
        {
            base.Events.Dispose();
            container.Add(this);            
            InitializeComponent();            
        }

        #endregion

        [DefaultValue(false)]
        public bool isKeyDown
        {
            get
            {
                return bKeyDown;
            }
            set
            {
                bKeyDown = value;
            }
        }
        
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

        private void BOITextBoxNumber_Enter(object sender, EventArgs e)
        {            
            bFocused = true;
            SetOITheme();
            ShowKeyPad();
        }        

        private void BOITextBoxNumber_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {            
            ShowKeyPad();
        }

        private void BOITextBoxNumber_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
        }

        private void BOITextBoxNumber_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void BOITextBoxNumber_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void BOITextBoxNumber_ValueChanged(object sender, EventArgs e)
        {
            if (bValidation == true)
            {
                bValidation = false;
                MPCF.ShowMessage("", CliFrx.MSG_LEVEL.NONE, false);
                SetOITheme();
            }

            if (this.Value == null
                || string.IsNullOrEmpty(this.Value.ToString()) == true)
            {
                if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                {
                    this.Value = this.DefaultIntegerValue;
                }
                else if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                {
                    this.Value = this.DefaultDoubleValue;
                }
            }
        }

        #endregion

        #region Function   
  

        private void ShowKeyPad()
        {
            try
            {
                if (this.ShowKeyPadControl == true)
                {
                    if (keyPad == null
                        || keyPad.IsDisposed == true)
                    {
                        keyPad = new frmLargeKeyPad();
                        keyPad.Owner = MPGV.gfrmMDI;

                        Point controlLocation = this.PointToScreen(new Point(0, 0));

                        keyPad.Left = controlLocation.X + this.Width - keyPad.Width;
                        keyPad.Top = controlLocation.Y + this.Height + 3;

                        // Mouse 클릭 위치를 확인
                        Rectangle rect = Screen.GetWorkingArea(Control.MousePosition);

                        // 우측 하단에 표시되는 경우 컨트롤 상단에 표시.
                        // 우측화면 넘어 컨트롤 자체가 보이지 않는 경우는 없다고 가정.
                        if (controlLocation.Y + keyPad.Height > rect.Top + rect.Height)
                        {
                            keyPad.Left = controlLocation.X + this.Width - keyPad.Width;
                            keyPad.Top = controlLocation.Y - keyPad.Height - 3;
                        }

                        keyPad.Tag = this;
                        if (keyPad.ShowDialog() == DialogResult.OK)
                        {
                            if (bKeyDown)
                            {
                                BICF.SendMessage(this.Handle, BIGC.WM_KEYDOWN, new IntPtr(BIGC.VK_RETURN), new IntPtr(0));
                            }
                        }

                        this.Update();
                    }
                }
            }
            finally
            {
                if (keyPad != null)
                {
                    keyPad.Dispose();
                }
            }
        }

        public new void AddValue(object oValue)
        {
            // 현재 Value가 null인 경우
            if (this.Value == null)
            {
                this.Value = oValue;
            }
            else
            {
                // 0으로 시작하는 경우 0 제거
                if (this.Value.ToString().StartsWith("0") == true && this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                {
                    this.Value = (this.Value.ToString().Remove(0) + oValue.ToString());
                }
                // 0으로 시작하지 않는 경우 추가
                else
                {
                    try
                    {
                        this.Value = (this.Value.ToString() + oValue.ToString());
                    }
                    catch (OverflowException)
                    {
                        return;
                    }
                }
            }
        }

        #endregion
    }
}
