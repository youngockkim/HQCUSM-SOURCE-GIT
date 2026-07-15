using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Miracom.UI;
//using Miracom.CliFrx;
//using Miracom.TRSCore;
//using Miracom.MESCore;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.Solar.Controls
{
    [DefaultEvent("SelectedItemChanged")]
    public partial class udcUser : UserControl
    {

        private char m_cond_c_step;
        private string m_cond_s_user_id;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;

        private bool b_login_success = false;
        private bool b_init_login_user = false;
        private bool b_refuse_event_exec = false;
        private bool b_force_user_info = false;
        
        public udcUser()
        {
            InitializeComponent();

            Init();
        }
        

        #region "Control Events"
                    
        private System.EventHandler TextBoxLostFocusEvent;
        public event System.EventHandler TextBoxLostFocus
        {
            add
            {
                TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxLostFocusEvent, value);
            }
            remove
            {
                TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxLostFocusEvent, value);
            }
        }

        private System.EventHandler TextBoxGotFocusEvent;
        public event System.EventHandler TextBoxGotFocus
        {
            add
            {
                TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxGotFocusEvent, value);
            }
            remove
            {
                TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxGotFocusEvent, value);
            }
        }

        private void txtUserID_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void txtUserID_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private System.Windows.Forms.KeyPressEventHandler IDTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler IDTextKeyPress
        {
            add
            {
                IDTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(IDTextKeyPressEvent, value);
            }
            remove
            {
                IDTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(IDTextKeyPressEvent, value);
            }
        }
         

        private System.EventHandler IDTextChangedEvent;
        public event System.EventHandler IDTextChanged
        {
            add
            {
                IDTextChangedEvent = (System.EventHandler)System.Delegate.Combine(IDTextChangedEvent, value);
            }
            remove
            {
                IDTextChangedEvent = (System.EventHandler)System.Delegate.Remove(IDTextChangedEvent, value);
            }
        }

        private System.EventHandler IDTextClickEvent;
        public event System.EventHandler IDTextClick
        {
            add
            {
                IDTextClickEvent = (System.EventHandler)System.Delegate.Combine(IDTextClickEvent, value);
            }
            remove
            {
                IDTextClickEvent = (System.EventHandler)System.Delegate.Remove(IDTextClickEvent, value);
            }
        }

        #endregion

        #region "Properties"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RefuseEventExec
        {
            get
            {
                return b_refuse_event_exec;
            }
            set
            {
                b_refuse_event_exec = value;
            }
        }

        public bool InitLoginUser
        {
            get
            {
                return b_init_login_user;
            }
            set
            {
                b_init_login_user = value;
            }
        }

        public bool ForceUserInfo
        {
            get
            {
                return b_force_user_info;
            }
            set
            {
                b_force_user_info = value;
            }
        }

        public bool LoginSuccess
        {
            get
            {
                return b_login_success;
            }
            set
            {
                b_login_success = value;
            }
        }
 
        //[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IDText
        {
            get
            {
                return txtUserID.Text;
            }
            set
            {
                txtUserID.Text = value;
            }
        }

        public string DescText
        {
            get
            {
                return txtUserDesc.Text;
            }
            set
            {
                txtUserDesc.Text = value;
            }
        }

        public Color LabelBackColor
        {
            get
            {
                return lblUser.BackColor;
            }
            set
            {
                lblUser.BackColor = value;
            }
        }

        public Color LabelForeColor
        {
            get
            {
                return lblUser.ForeColor;
            }
            set
            {
                lblUser.ForeColor = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblUser.Width;
            }
            set
            {
                //lblUser.Width = value;
                pnlLeft.Width = value;
            }
        }

        public Color UserIDBackColor
        {
            get
            {
                return txtUserID.BackColor;
            }
            set
            {
                txtUserID.BackColor = value;
            }
        }

        public Color UserIDForeColor
        {
            get
            {
                return txtUserID.ForeColor;
            }
            set
            {
                txtUserID.ForeColor = value;
            }
        }

        public int UserIDWidth
        {
            get
            {
                return pnlUserID.Width;
            }
            set
            {
                pnlUserID.Width = value;
            }
        }


        public Color UserDescBackColor
        {
            get
            {
                return txtUserDesc.BackColor;
            }
            set
            {
                txtUserDesc.BackColor = value;
            }
        }

        public Color UserDescForeColor
        {
            get
            {
                return txtUserDesc.ForeColor;
            }
            set
            {
                txtUserDesc.ForeColor = value;
            }
        }

        public int UserDescWidth
        {
            get
            {
                return pnlUserDesc.Width;
            }
            set
            {
                pnlUserDesc.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return txtUserID.MaxLength;
            }
        }

        public string LabelText
        {
            get
            {
                return lblUser.Text;
            }
            set
            {
                lblUser.Text = value;
            }
        }

        public TextBox GetTextBox
        {
            get
            {
                return txtUserID;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font LabelFont
        {
            get
            {
                return lblUser.Font;
            }
            set
            {
                lblUser.Font = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font UserIDFont
        {
            get
            {
                return txtUserID.Font;
            }
            set
            {
                txtUserID.Font = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font UserDescFont
        {
            get
            {
                return txtUserDesc.Font;
            }
            set
            {
                txtUserDesc.Font = value;
            }
        }

#endregion

        //
        // View_User()
        //       - View User Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool View_User()
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                b_login_success = false;

                CSGV.gsProcUserID = "";
                CSGV.gsProcUserDesc = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PRC_USER", MPCF.Trim(txtUserID.Text), true);

                if (MPCF.CallService("CUS", "CUS_View_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtUserDesc.Text = MPCF.Trim(out_node.GetString("USER_DESC"));
                
                CSGV.gsProcUserID = MPCF.Trim(txtUserID.Text);
                CSGV.gsProcUserDesc = MPCF.Trim(txtUserDesc.Text);

                b_login_success = true;
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private void udcUser_FontChanged(object sender, EventArgs e)
        {
            txtUserID.Font = this.Font;
            txtUserDesc.Font = this.Font;
        }
        
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_user_id = "";
            m_cond_s_filter = "";

            if (b_init_login_user == true)
            {
                txtUserID.Text = MPGV.gsUserID;

                if (View_User() == false)
                    return;
            }
            
        }
        
        public bool CheckValue()
        {
            return MPCF.CheckValue(this.txtUserID, 1);
        }

        public void ClearField()
        {
            if (b_force_user_info == false)
            {
                txtUserID.Text = "";
                txtUserDesc.Text = "";
            }
        }

        public void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (MPCF.Trim(txtUserID.Text) == "")
                        return;

                    if (View_User() == false)
                        return;

                }

                if (IDTextKeyPressEvent != null)
                    IDTextKeyPressEvent(this, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (b_force_user_info == false)
            {
                txtUserDesc.Text = "";
                CSGV.gsProcUserID = "";
                CSGV.gsProcUserDesc = "";

                b_login_success = false;

            }
           
            if (IDTextChangedEvent != null)
                IDTextChangedEvent(this, e);
        }

        private void txtUserID_Click(object sender, EventArgs e)
        {
            Form frm;

            try
            {
                //if (udcProcUser.ReadOnly == true)
                //    return;

                frm = new frmNumericKeyPad();

                frm.Top = this.Top + (this.Height - frm.Height);
                frm.Left = this.Left + (this.Width - frm.Width);

                ((frmNumericKeyPad)frm).STRING_IN = txtUserID.Text;
                ((frmNumericKeyPad)frm).Number_Type = frmNumericKeyPad.NUM_TYPE.STRING;

                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                txtUserID.Text = ((frmNumericKeyPad)frm).STRING_IN;

                frm.Dispose();

                if (MPCF.Trim(txtUserID.Text) != "")
                    View_User();

                if (IDTextClickEvent != null)
                    IDTextClickEvent(this, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void udcUser_Load(object sender, EventArgs e)
        {
            //if (MPCF.Trim(CSGV.gsProcUserID) != "")
            //{
            //    b_force_user_info = true;
            //    txtUserID.Text = CSGV.gsProcUserID;
            //    txtUserDesc.Text = CSGV.gsProcUserDesc;

            //    this.LoginSuccess = true;                
            //}
        }

    }
}
