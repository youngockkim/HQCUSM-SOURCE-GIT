using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Data;
//using Miracom.MESCore;
//using Miracom.CliFrx;
using FarPoint.Win.Spread;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.CliFrx;

namespace SOI.Solar
{
    public partial class frmNumericKeyPad : Form
    {
        public enum NUM_TYPE
        {
            U_INTEGER = 0,
            U_DOUBLE,
            INTEGER,
            DOUBLE,
            STRING
        }

        private NUM_TYPE _Number_Type = NUM_TYPE.U_INTEGER;

        public NUM_TYPE Number_Type
        {
            get
            {
                return _Number_Type;
            }
            set
            {
                _Number_Type = value;                
            }
        }

        private int MAX_NUMBER_SIZE = 10;

        //private int i_mode
        private double d_number_in;

        public double NUMBER_IN
        {
            get
            {
                return d_number_in;
            }
            set
            {
                d_number_in = value;
            }
        }

        private string s_string_in;

        public string STRING_IN
        {
            get
            {
                return s_string_in;
            }
            set
            {
                s_string_in = value;
            }
        }

        public frmNumericKeyPad()
        {
            InitializeComponent();
        }

        private void SetNumber(string sAdded)
        {
            string sCurNumber = string.Empty;
            double dNumber;

            try
            {
                sCurNumber = lblNumberIn.Text;

                if (sCurNumber.Length >= MAX_NUMBER_SIZE)
                    return;

                if (sAdded.Equals(".") == true)
                {
                    if (sCurNumber.IndexOf(".") >= 0)
                        return;
                }
               
                sCurNumber = sCurNumber + sAdded;

                dNumber = MPCF.ToDbl(sCurNumber);
                d_number_in = dNumber;

                if (sCurNumber.IndexOf(".") >= 0)
                {
                    lblNumberIn.Text = sCurNumber;
                }
                else
                {
                    lblNumberIn.Text = dNumber.ToString();
                }
              
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void SetString(string sAdded)
        {
            string sCurNumber = string.Empty;
             
            try
            {
                sCurNumber = lblNumberIn.Text;

                if (sCurNumber.Length >= MAX_NUMBER_SIZE)
                    return;
 
                sCurNumber = sCurNumber + sAdded;

                s_string_in = sCurNumber;

                lblNumberIn.Text = sCurNumber;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void DelNumber()
        {
            string sCurNumber = string.Empty;
            double dNumber;

            try
            {
                sCurNumber = lblNumberIn.Text;

                if (sCurNumber.Length > 1)
                {
                    sCurNumber = sCurNumber.Substring(0, sCurNumber.Length - 1);
                }
                else
                {
                    sCurNumber = "0";
                }

                dNumber = MPCF.ToDbl(sCurNumber);
                d_number_in = dNumber;

                if (sCurNumber.IndexOf(".") >= 0)
                {
                    lblNumberIn.Text = sCurNumber;
                }
                else
                {
                    lblNumberIn.Text = dNumber.ToString();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void ClearNumber()
        {
            string sCurNumber = string.Empty;
            double dNumber;

            try
            {
                sCurNumber = lblNumberIn.Text;

                //sCurNumber = "0";

                //dNumber = MPCF.ToDbl(sCurNumber);

                //lblNumberIn.Text = dNumber.ToString();
                //d_number_in = dNumber;

                sCurNumber = "0";

                dNumber = MPCF.ToDbl(sCurNumber);

                lblNumberIn.Text = "";
                d_number_in = dNumber;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
         
        private void ubtn0_Click(object sender, EventArgs e)
        {
        //    string sAdded;

        //    try
        //    {
        //        sAdded = MPCF.Trim(((Infragistics.Win.Misc.UltraButton)sender).Text);

        //        SetNumber(sAdded);
        //    }
        //    catch
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //    }
            
        }

        private void ubtn0_MouseUp(object sender, MouseEventArgs e)
        {
            string sAdded;

            try
            {
                sAdded = MPCF.Trim(((Infragistics.Win.Misc.UltraButton)sender).Text);

                if (_Number_Type == NUM_TYPE.STRING)
                {
                    SetString(sAdded);
                }
                else
                {
                    SetNumber(sAdded);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void ubtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ubtnDel_MouseUp(object sender, MouseEventArgs e)
        {
            DelNumber();
        }

        private void ubtnClear_MouseUp(object sender, MouseEventArgs e)
        {
            ClearNumber();
        }

        private void ubtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmNumericKeyPad_Load(object sender, EventArgs e)
        {
            if (_Number_Type == NUM_TYPE.U_DOUBLE || _Number_Type == NUM_TYPE.DOUBLE)
                ubtnDP.Visible = true;
            else
                ubtnDP.Visible = false;

            if (_Number_Type == NUM_TYPE.STRING)
            {
                ubtnHP.Visible = true;
                lblNumberIn.Text = "";
            }
            else
            {
                ubtnHP.Visible = false;
                lblNumberIn.Text = d_number_in.ToString();
            }
        }

        private void ubtnHP_MouseUp(object sender, MouseEventArgs e)
        {
            string sAdded;

            try
            {
                sAdded = MPCF.Trim(((Infragistics.Win.Misc.UltraButton)sender).Text);

                SetString(sAdded);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
