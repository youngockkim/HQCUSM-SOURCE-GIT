
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupPMSchedule.vb
//   Description : PM Schedule Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - Update_PM_Schedule() : Update PM Schedule
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-02 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASSetupPMComment : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupPMComment()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        public frmRASSetupPMComment(string ResID, string PMPlanDate, string PMPeriod, string PMComment)
        {
            
            
            InitializeComponent();
            
            
            txtResID.Text = MPCF.Trim(ResID);
            txtPMPlanDate.Text = MPCF.Trim(PMPlanDate);
            txtPMPeriod.Text = MPCF.Trim(PMPeriod);
            txtPMComment.Text = MPCF.Trim(PMComment);
            
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
        



        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBotton;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.TextBox txtPMPlanDate;
        private System.Windows.Forms.Label lblPMPlanDate;
        private System.Windows.Forms.TextBox txtPMPeriod;
        private System.Windows.Forms.Label lblPMPeriod;
        internal System.Windows.Forms.TextBox txtPMComment;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtPMPeriod = new System.Windows.Forms.TextBox();
            this.lblPMPeriod = new System.Windows.Forms.Label();
            this.txtPMPlanDate = new System.Windows.Forms.TextBox();
            this.lblPMPlanDate = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlBotton = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.txtPMComment = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.pnlBotton.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpGeneral);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.pnlTop.Size = new System.Drawing.Size(352, 108);
            this.pnlTop.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtPMPeriod);
            this.grpGeneral.Controls.Add(this.lblPMPeriod);
            this.grpGeneral.Controls.Add(this.txtPMPlanDate);
            this.grpGeneral.Controls.Add(this.lblPMPlanDate);
            this.grpGeneral.Controls.Add(this.txtResID);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.Location = new System.Drawing.Point(5, 1);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(342, 102);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // txtPMPeriod
            // 
            this.txtPMPeriod.Location = new System.Drawing.Point(120, 69);
            this.txtPMPeriod.MaxLength = 6;
            this.txtPMPeriod.Name = "txtPMPeriod";
            this.txtPMPeriod.ReadOnly = true;
            this.txtPMPeriod.Size = new System.Drawing.Size(200, 20);
            this.txtPMPeriod.TabIndex = 5;
            // 
            // lblPMPeriod
            // 
            this.lblPMPeriod.AutoSize = true;
            this.lblPMPeriod.Location = new System.Drawing.Point(15, 72);
            this.lblPMPeriod.Name = "lblPMPeriod";
            this.lblPMPeriod.Size = new System.Drawing.Size(56, 13);
            this.lblPMPeriod.TabIndex = 4;
            this.lblPMPeriod.Text = "PM Period";
            this.lblPMPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMPlanDate
            // 
            this.txtPMPlanDate.Location = new System.Drawing.Point(120, 43);
            this.txtPMPlanDate.MaxLength = 30;
            this.txtPMPlanDate.Name = "txtPMPlanDate";
            this.txtPMPlanDate.ReadOnly = true;
            this.txtPMPlanDate.Size = new System.Drawing.Size(200, 20);
            this.txtPMPlanDate.TabIndex = 3;
            // 
            // lblPMPlanDate
            // 
            this.lblPMPlanDate.AutoSize = true;
            this.lblPMPlanDate.Location = new System.Drawing.Point(15, 46);
            this.lblPMPlanDate.Name = "lblPMPlanDate";
            this.lblPMPlanDate.Size = new System.Drawing.Size(73, 13);
            this.lblPMPlanDate.TabIndex = 2;
            this.lblPMPlanDate.Text = "PM Plan Date";
            this.lblPMPlanDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(120, 16);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(200, 20);
            this.txtResID.TabIndex = 1;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnOk);
            this.pnlBotton.Controls.Add(this.btnClose);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 313);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(352, 40);
            this.pnlBotton.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(164, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(256, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cancle";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.txtPMComment);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 108);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMiddle.Size = new System.Drawing.Size(352, 205);
            this.pnlMiddle.TabIndex = 1;
            // 
            // txtPMComment
            // 
            this.txtPMComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPMComment.Location = new System.Drawing.Point(5, 5);
            this.txtPMComment.MaxLength = 400;
            this.txtPMComment.Multiline = true;
            this.txtPMComment.Name = "txtPMComment";
            this.txtPMComment.Size = new System.Drawing.Size(342, 195);
            this.txtPMComment.TabIndex = 0;
            // 
            // frmRASSetupPMComment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(352, 353);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRASSetupPMComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PM Comment Setup";
            this.Closed += new System.EventHandler(this.frmRASSetupPMComment_Closed);
            this.Load += new System.EventHandler(this.frmRASSetupPMComment_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRASSetupPMComment_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRASSetupPMComment_KeyUp);
            this.pnlTop.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlBotton.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        #endregion
        
        #region " Function Definition "
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            bool returnValue;
            
            try
            {
                returnValue = false;

                switch (MPCF.Trim(FuncName))
                {
                    
                case "Update_PM_Schedule":
                    
                    
                    if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.CheckValue(txtResID, 1) == false)
                        {
                            return returnValue;
                        }
                        
                        if (MPCF.CheckValue(txtPMPlanDate, 1) == false)
                        {
                            return returnValue;
                        }
                        
                        if (MPCF.CheckValue(txtPMPeriod, 1) == false)
                        {
                            return returnValue;
                        }
                    }
                    break;
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
    }
    
    //
    // Update_PM_Schedule()
    //       - Update PM Schedule
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByVal ProcStep As String : Process Step
    //       - RowIndex As Integer = -1 : Row Index of Resource
    //
    private bool Update_PM_Schedule(char ProcStep, int RowIndex)
    {
        TRSNode in_node = new TRSNode("Update_PM_Schedule_In");
        TRSNode out_node = new TRSNode("Cmn_Out");
        
        try
        {
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            
            if (ProcStep == MPGC.MP_STEP_UPDATE)
            {
                in_node.AddString("RES_ID", MPCF.Trim(txtResID.Text));
                in_node.AddString("PM_PLAN_DATE", MPCF.DestroyDateFormat(MPCF.Trim(txtPMPlanDate.Text), DATE_TIME_FORMAT.DATE));
                in_node.AddString("PM_PERIOD", MPCF.Trim(txtPMPeriod.Text));
                in_node.AddString("PM_COMMENT", MPCF.Trim(txtPMComment.Text));

            }

            if (MPCR.CallService("RAS", "RAS_Update_PM_Schedule", in_node, ref out_node) == false)
            {
                return false;
            }
            MPCR.ShowSuccessMsg(out_node);
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
        
    }
    
    #endregion
    
    #region " Form Control Event Routine "
    
    private void frmRASSetupPMComment_Closed(object sender, System.EventArgs e)
    {
        //        Me.Dispose()
    }
    
    private void frmRASSetupPMComment_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (!(this.ActiveControl == null))
        {
            if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
            {
                if (e.KeyValue != 13 && e.KeyValue != 8)
                {
                    if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
    
    private void frmRASSetupPMComment_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (!(this.ActiveControl == null))
        {
            if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
            {
                if (e.KeyChar == (char)58)
                {
                    e.Handled = true;
                }
            }
        }
    }
    
    private void btnOk_Click(System.Object sender, System.EventArgs e)
    {
        
        if (CheckCondition("Update_PM_Schedule", MPGC.MP_STEP_UPDATE) == false)
        {
            return;
        }
        if (Update_PM_Schedule(MPGC.MP_STEP_UPDATE, - 1) == false)
        {
            return;
        }
        
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
        
    }
    
    private void btnClose_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }
    
    private void frmRASSetupPMComment_Load(object sender, System.EventArgs e)
    {
        
        MPGV.gIBaseFormEvent.Form_Load(this, e);
        
    }
    #endregion
    
}

}
