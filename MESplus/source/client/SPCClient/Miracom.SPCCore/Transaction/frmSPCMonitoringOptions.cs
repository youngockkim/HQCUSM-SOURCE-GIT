
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Infragistics.Win.UltraWinEditors;

//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCMonitoringOptions.vb
//   Description : Setting Monitoring Options
//
//   SPC Version : 1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - 2005-04-26 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class frmSPCMonitoringOptions : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCMonitoringOptions()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Panel pnlMain;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRuleCheck;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRChart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpecLimit;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewDate;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewLotID;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtMaxLotCount;
        internal System.Windows.Forms.Label lblMaxLotCount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewCZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewBZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewAZone;
        internal System.Windows.Forms.Button btnExit;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkViewRuleCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewSpecLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewLotID = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtMaxLotCount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblMaxLotCount = new System.Windows.Forms.Label();
            this.chkViewCZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewBZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewAZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExit);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 106);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(368, 36);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Location = new System.Drawing.Point(289, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(207, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkViewRuleCheck);
            this.pnlMain.Controls.Add(this.chkViewRChart);
            this.pnlMain.Controls.Add(this.chkViewSpecLimit);
            this.pnlMain.Controls.Add(this.chkViewDate);
            this.pnlMain.Controls.Add(this.chkViewLotID);
            this.pnlMain.Controls.Add(this.txtMaxLotCount);
            this.pnlMain.Controls.Add(this.lblMaxLotCount);
            this.pnlMain.Controls.Add(this.chkViewCZone);
            this.pnlMain.Controls.Add(this.chkViewBZone);
            this.pnlMain.Controls.Add(this.chkViewAZone);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(368, 106);
            this.pnlMain.TabIndex = 0;
            // 
            // chkViewRuleCheck
            // 
            this.chkViewRuleCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRuleCheck.Location = new System.Drawing.Point(216, 12);
            this.chkViewRuleCheck.Name = "chkViewRuleCheck";
            this.chkViewRuleCheck.Size = new System.Drawing.Size(122, 14);
            this.chkViewRuleCheck.TabIndex = 6;
            this.chkViewRuleCheck.Text = "View Rule Check";
            this.chkViewRuleCheck.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewRChart
            // 
            this.chkViewRChart.Checked = true;
            this.chkViewRChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRChart.Location = new System.Drawing.Point(216, 32);
            this.chkViewRChart.Name = "chkViewRChart";
            this.chkViewRChart.Size = new System.Drawing.Size(112, 14);
            this.chkViewRChart.TabIndex = 7;
            this.chkViewRChart.Text = "View R-Chart";
            this.chkViewRChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewSpecLimit
            // 
            this.chkViewSpecLimit.Checked = true;
            this.chkViewSpecLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpecLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpecLimit.Location = new System.Drawing.Point(92, 52);
            this.chkViewSpecLimit.Name = "chkViewSpecLimit";
            this.chkViewSpecLimit.Size = new System.Drawing.Size(118, 14);
            this.chkViewSpecLimit.TabIndex = 5;
            this.chkViewSpecLimit.Text = "View Spec Limit";
            this.chkViewSpecLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewDate
            // 
            this.chkViewDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewDate.Location = new System.Drawing.Point(92, 32);
            this.chkViewDate.Name = "chkViewDate";
            this.chkViewDate.Size = new System.Drawing.Size(112, 14);
            this.chkViewDate.TabIndex = 4;
            this.chkViewDate.Text = "View Date";
            this.chkViewDate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewLotID
            // 
            this.chkViewLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewLotID.Location = new System.Drawing.Point(92, 12);
            this.chkViewLotID.Name = "chkViewLotID";
            this.chkViewLotID.Size = new System.Drawing.Size(122, 14);
            this.chkViewLotID.TabIndex = 3;
            this.chkViewLotID.Text = "View XAxis Label";
            this.chkViewLotID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtMaxLotCount
            // 
            this.txtMaxLotCount.Location = new System.Drawing.Point(302, 48);
            this.txtMaxLotCount.MaxLength = 2;
            this.txtMaxLotCount.Name = "txtMaxLotCount";
            this.txtMaxLotCount.Size = new System.Drawing.Size(54, 20);
            this.txtMaxLotCount.TabIndex = 9;
            this.txtMaxLotCount.Text = "30";
            this.txtMaxLotCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxLotCount_KeyPress);
            // 
            // lblMaxLotCount
            // 
            this.lblMaxLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLotCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxLotCount.Location = new System.Drawing.Point(216, 52);
            this.lblMaxLotCount.Name = "lblMaxLotCount";
            this.lblMaxLotCount.Size = new System.Drawing.Size(112, 14);
            this.lblMaxLotCount.TabIndex = 8;
            this.lblMaxLotCount.Text = "Max Point Count :";
            // 
            // chkViewCZone
            // 
            this.chkViewCZone.Checked = true;
            this.chkViewCZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewCZone.Location = new System.Drawing.Point(14, 52);
            this.chkViewCZone.Name = "chkViewCZone";
            this.chkViewCZone.Size = new System.Drawing.Size(112, 14);
            this.chkViewCZone.TabIndex = 2;
            this.chkViewCZone.Text = "C Zone";
            this.chkViewCZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewBZone
            // 
            this.chkViewBZone.Checked = true;
            this.chkViewBZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewBZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewBZone.Location = new System.Drawing.Point(14, 32);
            this.chkViewBZone.Name = "chkViewBZone";
            this.chkViewBZone.Size = new System.Drawing.Size(112, 14);
            this.chkViewBZone.TabIndex = 1;
            this.chkViewBZone.Text = "B Zone";
            this.chkViewBZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewAZone
            // 
            this.chkViewAZone.Checked = true;
            this.chkViewAZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewAZone.Location = new System.Drawing.Point(14, 12);
            this.chkViewAZone.Name = "chkViewAZone";
            this.chkViewAZone.Size = new System.Drawing.Size(112, 14);
            this.chkViewAZone.TabIndex = 0;
            this.chkViewAZone.Text = "A Zone";
            this.chkViewAZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // frmSPCMonitoringOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(368, 142);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(376, 150);
            this.Name = "frmSPCMonitoringOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitoring Options";
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Properties Implementation"
        
        public bool IsViewRuleCheck
        {
            get
            {
                return chkViewRuleCheck.Checked;
            }
            set
            {
                if (chkViewRuleCheck.Checked != value)
                {
                    chkViewRuleCheck.Checked = value;
                }
            }
        }
        
        public bool IsViewRChart
        {
            get
            {
                return chkViewRChart.Checked;
            }
            set
            {
                if (chkViewRChart.Checked != value)
                {
                    chkViewRChart.Checked = value;
                }
            }
        }
        
        public bool IsViewSpecLimit
        {
            get
            {
                return chkViewSpecLimit.Checked;
            }
            set
            {
                if (chkViewSpecLimit.Checked != value)
                {
                    chkViewSpecLimit.Checked = value;
                }
            }
        }
        
        public bool IsViewDate
        {
            get
            {
                return chkViewDate.Checked;
            }
            set
            {
                if (chkViewDate.Checked != value)
                {
                    chkViewDate.Checked = value;
                }
            }
        }
        
        public bool IsViewLotID
        {
            get
            {
                return chkViewLotID.Checked;
            }
            set
            {
                if (chkViewLotID.Checked != value)
                {
                    chkViewLotID.Checked = value;
                }
            }
        }
        
        public bool IsViewAZone
        {
            get
            {
                return chkViewAZone.Checked;
            }
            set
            {
                if (chkViewAZone.Checked != value)
                {
                    chkViewAZone.Checked = value;
                }
            }
        }
        
        public bool IsViewBZone
        {
            get
            {
                return chkViewBZone.Checked;
            }
            set
            {
                if (chkViewBZone.Checked != value)
                {
                    chkViewBZone.Checked = value;
                }
            }
        }
        
        public bool IsViewCZone
        {
            get
            {
                return chkViewCZone.Checked;
            }
            set
            {
                if (chkViewCZone.Checked != value)
                {
                    chkViewCZone.Checked = value;
                }
            }
        }
        
        public int MaxLotCount
        {
            get
            {
                return MPCF.ToInt(txtMaxLotCount.Text);
            }
            set
            {
                if (txtMaxLotCount.Text != value.ToString())
                {
                    txtMaxLotCount.Text = value.ToString();
                }
            }
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void btnExit_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCMonitoringOptions.btnExit_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //MaxLotCount Validation
                //if (MPCF.CheckNumeric(MaxLotCount) == false)
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                //    this.DialogResult = System.Windows.Forms.DialogResult.None;
                //    return;
                //}
                //else
                //{
                    if (MPCF.ToInt(MaxLotCount) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                    if (MPCF.ToInt(MaxLotCount) > 100)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(236, "\'100\' ") + MPCF.GetMessage(236));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(236) + " \'100\'");
                        }
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                //}
                
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCMonitoringOptions.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtMaxLotCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            if (((UltraTextEditor)sender).Text == "" || ((UltraTextEditor)sender).Text.Contains(".") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCMonitoringOptions.txtMaxLotCount_KeyPress()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
