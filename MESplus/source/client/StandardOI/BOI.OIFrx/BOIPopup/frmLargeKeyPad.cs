using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOIControls = SOI.OIFrx.SOIControls;
using SOI.OIFrx;
using SOI.OIFrx.SOIControls;
using CliFrx = SOI.CliFrx;
using BOI.OIFrx.BOIControls;

namespace BOI.OIFrx.BOIPopup
{
    public partial class frmLargeKeyPad : Form
    {
        #region Property

        private bool bInitValue = false;
        private object oInitValue;
        private bool bFirstInput = false;

        /// <summary>
        /// 테마 사용 여부를 설정합니다.
        /// </summary>
        private bool _useOITheme = true;
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                if (_useOITheme == true)
                {
                    // Use OI Theme 변경 시 테마 적용
                    SetOITheme();
                }
            }
        }

        #endregion

        #region Constructor

        public frmLargeKeyPad()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Paint 이벤트 발생 시 디자인 타임에서만 적용합니다.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                // 테마를 사용하는 경우에만 적용
                if (_UseOITheme == true)
                {
                    SetOITheme();
                }
            }

            base.OnPaint(pe);
        }

        private void frmLargeKeyPad_Load(object sender, EventArgs e)
        {
            //SetOITheme();
            MPCF.LoadControlTheme(this);

            // Get Init Value
            GetInitValue();
        }

        

        private void btnNumZero_Click(object sender, EventArgs e)
        {
            SetNumber('0');
            btnEnter.Focus();
        }

        private void btnNumOne_Click(object sender, EventArgs e)
        {
            SetNumber('1');
            btnEnter.Focus();
        }

        private void btnNumTwo_Click(object sender, EventArgs e)
        {
            SetNumber('2');
            btnEnter.Focus();
        }

        private void btnNumThree_Click(object sender, EventArgs e)
        {
            SetNumber('3');
            btnEnter.Focus();
        }

        private void btnNumFour_Click(object sender, EventArgs e)
        {
            SetNumber('4');
            btnEnter.Focus();
        }

        private void btnNumFive_Click(object sender, EventArgs e)
        {
            SetNumber('5');
            btnEnter.Focus();
        }

        private void btnNumSix_Click(object sender, EventArgs e)
        {
            SetNumber('6');
            btnEnter.Focus();
        }

        private void btnNumSeven_Click(object sender, EventArgs e)
        {
            SetNumber('7');
            btnEnter.Focus();
        }

        private void btnNumEight_Click(object sender, EventArgs e)
        {
            SetNumber('8');
            btnEnter.Focus();
        }

        private void btnNumNine_Click(object sender, EventArgs e)
        {
            SetNumber('9');
            btnEnter.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetNumber('C');
            DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            SetNumber('B');
            btnEnter.Focus();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            SetNumber('.');
            btnEnter.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void frmLargeKeyPad_KeyDown(object sender, KeyEventArgs e)
        {
            // 실행되지 않음
            if (e.KeyCode == Keys.Enter
                || e.KeyCode == Keys.Tab)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (bInitValue == true)
                {
                    SetNumber('I');
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.C)
            {
                SetNumber('C');
                this.Close();
            }
            else if (e.KeyCode == Keys.Back)
            {
                SetNumber('B');
            }
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                SetNumber('0');
            }
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                SetNumber('1');
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                SetNumber('2');
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                SetNumber('3');
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                SetNumber('4');
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                SetNumber('5');
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                SetNumber('6');
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                SetNumber('7');
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                SetNumber('8');
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                SetNumber('9');
            }
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                SetNumber('.');
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
                this.BackColor = MPGV.gTheme.PopupKeyPadBorder;
                this.pnlOut.BackColor = MPGV.gTheme.PopupKeyPadBackground;

                //this.btnNumZero.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumZero.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumOne.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumOne.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumTwo.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumTwo.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumThree.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumThree.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumFour.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumFour.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumFive.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumFive.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumSix.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumSix.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumSeven.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumSeven.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumEight.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumEight.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumNine.Appearance.BackColor = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnNumNine.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadNumberBackground;
                //this.btnClear.Appearance.BackColor = MPGV.gTheme.PopupKeyPadControlButtonBackground;
                //this.btnClear.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadControlButtonBackground;
                //this.btnBackspace.Appearance.BackColor = MPGV.gTheme.PopupKeyPadControlButtonBackground;
                //this.btnBackspace.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadControlButtonBackground;
                //this.btnEnter.Appearance.BackColor = MPGV.gTheme.PopupKeyPadControlButtonBackground;
                //this.btnEnter.Appearance.BackColor2 = MPGV.gTheme.PopupKeyPadControlButtonBackground;
            }
        }

        /// <summary>
        /// 초기값을 저장합니다.
        /// </summary>
        private void GetInitValue()
        {
            if(this.Tag != null && this.Tag is SOITextBoxNumber)
            {
                oInitValue = ((SOITextBoxNumber)this.Tag).Value;
                bInitValue = true;
            }
        }

        /// <summary>
        /// 입력한 값을 TextBox로 전달합니다.
        /// </summary>
        /// <param name="value"></param>
        private void SetNumber(char btnChar)
        {
            try
            {
                BOITextBoxNumber parentControl;
                BOISpread parentSpread;

                if (this.Tag != null && this.Tag is BOITextBoxNumber)
                {
                    parentControl = ((BOITextBoxNumber)this.Tag);

                    if (bFirstInput == false)
                    {
                        parentControl.Value = 0;
                        bFirstInput = true;
                    }

                    if (btnChar == 'I')
                    {
                        parentControl.Value = oInitValue;
                    }
                    else if (btnChar == 'C')
                    {
                        if (parentControl.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                        {
                            parentControl.Value = parentControl.DefaultIntegerValue;
                        }
                        else if (parentControl.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                        {
                            parentControl.Value = parentControl.DefaultDoubleValue;
                        }
                    }
                    else if (btnChar == 'B')
                    {
                        parentControl.RemoveLastValue();
                    }
                    else if (btnChar == '0')
                    {
                        parentControl.AddValue(0);
                    }
                    else if (btnChar == '1')
                    {
                        parentControl.AddValue(1);
                    }
                    else if (btnChar == '2')
                    {
                        parentControl.AddValue(2);
                    }
                    else if (btnChar == '3')
                    {
                        parentControl.AddValue(3);
                    }
                    else if (btnChar == '4')
                    {
                        parentControl.AddValue(4);
                    }
                    else if (btnChar == '5')
                    {
                        parentControl.AddValue(5);
                    }
                    else if (btnChar == '6')
                    {
                        parentControl.AddValue(6);
                    }
                    else if (btnChar == '7')
                    {
                        parentControl.AddValue(7);
                    }
                    else if (btnChar == '8')
                    {
                        parentControl.AddValue(8);
                    }
                    else if (btnChar == '9')
                    {
                        parentControl.AddValue(9);
                    }
                    else if (btnChar == '.')
                    {
                        parentControl.AddValue('.');
                    }
                }
                else if (this.Tag != null && this.Tag is BOISpread)
                {
                    FarPoint.Win.Spread.Cell cell;
                    parentSpread = ((BOISpread)this.Tag);

                    cell = parentSpread.ActiveSheet.ActiveCell;                    

                    if (bFirstInput == false)
                    {
                        cell.Value = 0;
                        bFirstInput = true;
                    }

                    if (btnChar == 'I')
                    {
                        cell.Value = oInitValue;
                    }
                    else if (btnChar == 'C')
                    {
                        if (cell.Column.CellType is FarPoint.Win.Spread.CellType.NumberCellType)
                        {
                            if (((FarPoint.Win.Spread.CellType.NumberCellType)cell.Column.CellType).DecimalPlaces > 0)
                            {
                                cell.Value = 0.0d;
                            }
                            else
                            {
                                cell.Value = 0;
                            }
                        }
                        
                    }
                    else if (btnChar == 'B')
                    {
                        parentSpread.RemoveLastValue();
                    }
                    else if (btnChar == '0')
                    {
                        parentSpread.AddValue(0);
                    }
                    else if (btnChar == '1')
                    {
                        parentSpread.AddValue(1);
                    }
                    else if (btnChar == '2')
                    {
                        parentSpread.AddValue(2);
                    }
                    else if (btnChar == '3')
                    {
                        parentSpread.AddValue(3);
                    }
                    else if (btnChar == '4')
                    {
                        parentSpread.AddValue(4);
                    }
                    else if (btnChar == '5')
                    {
                        parentSpread.AddValue(5);
                    }
                    else if (btnChar == '6')
                    {
                        parentSpread.AddValue(6);
                    }
                    else if (btnChar == '7')
                    {
                        parentSpread.AddValue(7);
                    }
                    else if (btnChar == '8')
                    {
                        parentSpread.AddValue(8);
                    }
                    else if (btnChar == '9')
                    {
                        parentSpread.AddValue(9);
                    }
                    else if (btnChar == '.')
                    {
                        parentSpread.AddValue('.');
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("Key Pad SetNumber()" + ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
            }
        }



        #endregion

        private void frmLargeKeyPad_Deactivate(object sender, EventArgs e)
        {
            try
            {
                if (this == null
                    || this.IsDisposed == true)
                {
                    //this.Close();                    
                }
            }
            finally
            {
                if (this != null)
                {
                    //this.Dispose();
                }
            }
        }

        

       

 

        

        
    }
}
