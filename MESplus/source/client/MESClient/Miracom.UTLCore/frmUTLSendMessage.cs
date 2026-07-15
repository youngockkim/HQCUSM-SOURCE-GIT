
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;



//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmUTLSendMessage.vb
//   Description : MES Cient Form Send Message Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - ClearData() : Initalize form fields
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-10 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _UTL = True Then

namespace Miracom.UTLCore
{
    public class frmUTLSendMessage : Miracom.MESCore.TranForm11
    {
        
        #region " Windows Form auto generated code "
        
        public frmUTLSendMessage()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserGroup;
        private System.Windows.Forms.Label lblFactory;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserGroup;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvFactory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUserGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserGroup = new System.Windows.Forms.Label();
            this.lblFactory = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Location = new System.Drawing.Point(2, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(738, 92);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.txtMessage);
            this.pnlTranCenter.Location = new System.Drawing.Point(2, 92);
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(738, 414);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvUserID);
            this.grpOption.Controls.Add(this.cdvUserGroup);
            this.grpOption.Controls.Add(this.cdvFactory);
            this.grpOption.Controls.Add(this.lblUser);
            this.grpOption.Controls.Add(this.lblUserGroup);
            this.grpOption.Controls.Add(this.lblFactory);
            this.grpOption.Size = new System.Drawing.Size(732, 92);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(8, 6);
            this.btnExcel.Size = new System.Drawing.Size(20, 22);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(589, 7);
            this.btnProcess.Size = new System.Drawing.Size(73, 25);
            this.btnProcess.Text = "Send";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(666, 7);
            this.btnClose.Size = new System.Drawing.Size(73, 25);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pnlCenter
            // 
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Send Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(738, 412);
            this.txtMessage.TabIndex = 0;
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(118, 63);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(200, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 5;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 200;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // cdvUserGroup
            // 
            this.cdvUserGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserGroup.BtnToolTipText = "";
            this.cdvUserGroup.DescText = "";
            this.cdvUserGroup.DisplaySubItemIndex = -1;
            this.cdvUserGroup.DisplayText = "";
            this.cdvUserGroup.Focusing = null;
            this.cdvUserGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserGroup.Index = 0;
            this.cdvUserGroup.IsViewBtnImage = false;
            this.cdvUserGroup.Location = new System.Drawing.Point(118, 39);
            this.cdvUserGroup.MaxLength = 20;
            this.cdvUserGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserGroup.Name = "cdvUserGroup";
            this.cdvUserGroup.ReadOnly = false;
            this.cdvUserGroup.SearchSubItemIndex = 0;
            this.cdvUserGroup.SelectedDescIndex = -1;
            this.cdvUserGroup.SelectedSubItemIndex = -1;
            this.cdvUserGroup.SelectionStart = 0;
            this.cdvUserGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvUserGroup.SmallImageList = null;
            this.cdvUserGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserGroup.TabIndex = 3;
            this.cdvUserGroup.TextBoxToolTipText = "";
            this.cdvUserGroup.TextBoxWidth = 200;
            this.cdvUserGroup.VisibleButton = true;
            this.cdvUserGroup.VisibleColumnHeader = false;
            this.cdvUserGroup.VisibleDescription = false;
            this.cdvUserGroup.ButtonPress += new System.EventHandler(this.cdvUserGroup_ButtonPress);
            this.cdvUserGroup.TextBoxTextChanged += new System.EventHandler(this.cdvUserGroup_TextBoxTextChanged);
            // 
            // cdvFactory
            // 
            this.cdvFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFactory.BtnToolTipText = "";
            this.cdvFactory.DescText = "";
            this.cdvFactory.DisplaySubItemIndex = -1;
            this.cdvFactory.DisplayText = "";
            this.cdvFactory.Focusing = null;
            this.cdvFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFactory.Index = 0;
            this.cdvFactory.IsViewBtnImage = false;
            this.cdvFactory.Location = new System.Drawing.Point(118, 15);
            this.cdvFactory.MaxLength = 10;
            this.cdvFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.Name = "cdvFactory";
            this.cdvFactory.ReadOnly = false;
            this.cdvFactory.SearchSubItemIndex = 0;
            this.cdvFactory.SelectedDescIndex = -1;
            this.cdvFactory.SelectedSubItemIndex = -1;
            this.cdvFactory.SelectionStart = 0;
            this.cdvFactory.Size = new System.Drawing.Size(200, 20);
            this.cdvFactory.SmallImageList = null;
            this.cdvFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFactory.TabIndex = 1;
            this.cdvFactory.TextBoxToolTipText = "";
            this.cdvFactory.TextBoxWidth = 200;
            this.cdvFactory.VisibleButton = true;
            this.cdvFactory.VisibleColumnHeader = false;
            this.cdvFactory.VisibleDescription = false;
            this.cdvFactory.TextBoxTextChanged += new System.EventHandler(this.cdvFactory_TextBoxTextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(12, 67);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User ID";
            // 
            // lblUserGroup
            // 
            this.lblUserGroup.AutoSize = true;
            this.lblUserGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserGroup.Location = new System.Drawing.Point(12, 42);
            this.lblUserGroup.Name = "lblUserGroup";
            this.lblUserGroup.Size = new System.Drawing.Size(61, 13);
            this.lblUserGroup.TabIndex = 2;
            this.lblUserGroup.Text = "User Group";
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactory.Location = new System.Drawing.Point(12, 19);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 0;
            this.lblFactory.Text = "Factory";
            // 
            // frmUTLSendMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "frmUTLSendMessage";
            this.Text = "Send Message";
            this.Activated += new System.EventHandler(this.frmUTLSendMessage_Activated);
            this.Load += new System.EventHandler(this.frmUTLSendMessage_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUTLSendMessage_KeyPress);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.pnlTranCenter.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName)
        {
            
            //            int i = 0;
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Send_Message":
                        
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        
        private void ClearData(string ProcStep)
        {
            
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void InitCodeView()
        {
            
            cdvFactory.Init();
            MPCF.InitListView(cdvFactory.GetListView);
            cdvFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvFactory.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFactory.SelectedSubItemIndex = 0;
            
        }
        
        private bool SendMessage()
        {
            TRSNode node = new TRSNode("Publish_Message_In");
            string sPublishChannel;
            
            try
            {
                MPCR.SetInMsg(node);
                node.ProcStep = '1';
                node.AddString("SEND_COMPUTER_ID", MPGV.gsComputerName);
                node.AddString("SEND_USER_ID", MPGV.gsUserID, true);
                node.AddString("SEND_USER_GROUP", MPGV.gsUserGroup);

                node.AddString("TO_FACTORY", MPCF.Trim(cdvFactory.Text));
                node.AddString("TO_USER_GROUP", MPCF.Trim(cdvUserGroup.Text));
                node.AddString("TO_USER_ID", MPCF.Trim(cdvUserID.Text), true);
                node.AddString("MESSAGE", MPCF.Trim(txtMessage.Text));

                sPublishChannel = "/" + MPGV.gsSiteID;
                sPublishChannel += "/UTL";

#if _HTTP
                if (MPCF.Trim(cdvFactory.Text) != "")
                {
                    sPublishChannel += "/" + MPCF.Trim(cdvFactory.Text);
                    if (MPCF.Trim(cdvUserGroup.Text) != "")
                    {
                        sPublishChannel += "/" + MPCF.Trim(cdvUserGroup.Text);
                        if (MPCF.Trim(cdvUserID.Text) != "")
                        {
                            sPublishChannel += "/" + MPCF.Trim(cdvUserID.Text);
                        }
                    }
                }
                
#else
                if (MPCF.Trim(cdvFactory.Text) != "")
                {
                    sPublishChannel += "/" + MPCF.Trim(cdvFactory.Text);
                }
                else
                {
                    sPublishChannel += "/*";
                }
                if (MPCF.Trim(cdvUserGroup.Text) != "")
                {
                    sPublishChannel += "/" + MPCF.Trim(cdvUserGroup.Text);
                }
                else
                {
                    sPublishChannel += "/*";
                }
                if (MPCF.Trim(cdvUserID.Text) != "")
                {
                    sPublishChannel += "/" + MPCF.Trim(cdvUserID.Text);
                }
                else
                {
                    sPublishChannel += "/*";
                }
#endif
                if (MPCR.CallService("UTL", "UTL_Publish_Message", node, sPublishChannel) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvFactory;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region "Form Control Event Routine"
        
        private void frmUTLSendMessage_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                this.MinimumSize = new System.Drawing.Size(0, 0);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmUTLSendMessage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (!(this.ActiveControl == null))
                {
                    if (this.ActiveControl is TextBox)
                    {
                        //if (e.KeyChar == (char)58)
                        if (e.KeyChar == (char)58)
                        {
                            e.Handled = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmUTLSendMessage_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    InitCodeView();
                    WIPLIST.ViewFactoryList(cdvFactory.GetListView, '1', null);
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Send_Message") == false)
                {
                    return;
                }
                if (SendMessage() == false)
                {
                    return;
                }
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvUserGroup_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            if (cdvFactory.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvFactory.Focus();
                return;
            }
            
            cdvUserGroup.Init();
            MPCF.InitListView(cdvUserGroup.GetListView);
            cdvUserGroup.Columns.Add("UserGroup", 100, HorizontalAlignment.Left);
            cdvUserGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUserGroup.SelectedSubItemIndex = 0;
            
            SECLIST.ViewSecGroupList(cdvUserGroup.GetListView, '1', null, cdvFactory.Text);
            
        }
        
        private void cdvFactory_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            
            cdvUserGroup.ListClear();
            cdvUserGroup.Text = "";
            cdvUserID.ListClear();
            cdvUserID.Text = "";
            
        }
        
        private void cdvUserGroup_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            
            cdvUserID.ListClear();
            cdvUserID.Text = "";
            
        }
        
        private void cdvUserID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            if (cdvFactory.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvFactory.Focus();
                return;
            }
            
            if (cdvUserGroup.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvUserGroup.Focus();
                return;
            }
            
            cdvUserID.Init();
            MPCF.InitListView(cdvUserID.GetListView);
            cdvUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUserID.SelectedSubItemIndex = 0;
            
            SECLIST.ViewSECUserList(cdvUserID.GetListView, '2', - 1, null, cdvFactory.Text, cdvUserGroup.Text);
            
        }
        
        protected override void OnDeactivate(System.EventArgs e)
        {
            
            if (btnProcess.Focused == true)
            {
                txtMessage.Focus();
                txtMessage.SelectionStart = txtMessage.TextLength;
            }
            
            base.OnDeactivate(e);
            
        }
        
        #endregion
        
    }
    //#End If
}
