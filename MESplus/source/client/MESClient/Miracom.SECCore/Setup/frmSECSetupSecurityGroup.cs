
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
//   File Name   : frmSECSetupSecurityGroup.vb
//   Description : Security Group Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_SecGrp() : View Security Group definition
//       - View_SecGrp_List() : View all table list which is included in one factory
//       - Update_SecGrp() : Create/Update/Delete Security Group definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.SECCore
{
    public class frmSECSetupSecurityGroup : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmSECSetupSecurityGroup()
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
        



        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel plnRightBottom;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tbpCopy;
        private System.Windows.Forms.GroupBox grpCopyTable;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TabControl tabSecGrp;
        private Miracom.UI.Controls.MCListView.MCListView lisSecGrp;
        private System.Windows.Forms.Label lblSecGrp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtSecGrp;
        private System.Windows.Forms.GroupBox grpSecGrp;
        private System.Windows.Forms.Label lblToSecGrp;
        private TabPage tbpAttribute;
        private BASCore.udcAttributeStatus udcAttribute;
        private System.Windows.Forms.TextBox txtToSecGrp;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisSecGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtSecGrp = new System.Windows.Forms.TextBox();
            this.lblSecGrp = new System.Windows.Forms.Label();
            this.grpSecGrp = new System.Windows.Forms.GroupBox();
            this.plnRightBottom = new System.Windows.Forms.Panel();
            this.tabSecGrp = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopyTable = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToSecGrp = new System.Windows.Forms.Label();
            this.txtToSecGrp = new System.Windows.Forms.TextBox();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttribute = new Miracom.BASCore.udcAttributeStatus();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpSecGrp.SuspendLayout();
            this.plnRightBottom.SuspendLayout();
            this.tabSecGrp.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.plnRightBottom);
            this.pnlRight.Controls.Add(this.grpSecGrp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisSecGrp);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Security Group Setup";
            // 
            // lisSecGrp
            // 
            this.lisSecGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisSecGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSecGrp.EnableSort = true;
            this.lisSecGrp.EnableSortIcon = true;
            this.lisSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSecGrp.FullRowSelect = true;
            this.lisSecGrp.HideSelection = false;
            this.lisSecGrp.Location = new System.Drawing.Point(3, 3);
            this.lisSecGrp.MultiSelect = false;
            this.lisSecGrp.Name = "lisSecGrp";
            this.lisSecGrp.Size = new System.Drawing.Size(229, 500);
            this.lisSecGrp.TabIndex = 0;
            this.lisSecGrp.UseCompatibleStateImageBehavior = false;
            this.lisSecGrp.View = System.Windows.Forms.View.Details;
            this.lisSecGrp.SelectedIndexChanged += new System.EventHandler(this.lisSecGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Security Group";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 200;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(132, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(357, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSecGrp
            // 
            this.txtSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecGrp.Location = new System.Drawing.Point(132, 17);
            this.txtSecGrp.MaxLength = 20;
            this.txtSecGrp.Name = "txtSecGrp";
            this.txtSecGrp.Size = new System.Drawing.Size(200, 20);
            this.txtSecGrp.TabIndex = 1;
            this.txtSecGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecGrp_KeyPress);
            // 
            // lblSecGrp
            // 
            this.lblSecGrp.AutoSize = true;
            this.lblSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSecGrp.Location = new System.Drawing.Point(15, 19);
            this.lblSecGrp.Name = "lblSecGrp";
            this.lblSecGrp.Size = new System.Drawing.Size(91, 13);
            this.lblSecGrp.TabIndex = 0;
            this.lblSecGrp.Text = "Security Group";
            this.lblSecGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpSecGrp
            // 
            this.grpSecGrp.Controls.Add(this.txtDesc);
            this.grpSecGrp.Controls.Add(this.lblDesc);
            this.grpSecGrp.Controls.Add(this.txtSecGrp);
            this.grpSecGrp.Controls.Add(this.lblSecGrp);
            this.grpSecGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSecGrp.Location = new System.Drawing.Point(3, 0);
            this.grpSecGrp.Name = "grpSecGrp";
            this.grpSecGrp.Size = new System.Drawing.Size(500, 70);
            this.grpSecGrp.TabIndex = 0;
            this.grpSecGrp.TabStop = false;
            // 
            // plnRightBottom
            // 
            this.plnRightBottom.Controls.Add(this.tabSecGrp);
            this.plnRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnRightBottom.Location = new System.Drawing.Point(3, 70);
            this.plnRightBottom.Name = "plnRightBottom";
            this.plnRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.plnRightBottom.Size = new System.Drawing.Size(500, 433);
            this.plnRightBottom.TabIndex = 1;
            // 
            // tabSecGrp
            // 
            this.tabSecGrp.Controls.Add(this.tbpGeneral);
            this.tabSecGrp.Controls.Add(this.tbpCopy);
            this.tabSecGrp.Controls.Add(this.tbpAttribute);
            this.tabSecGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSecGrp.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSecGrp.Location = new System.Drawing.Point(0, 5);
            this.tabSecGrp.Name = "tabSecGrp";
            this.tabSecGrp.SelectedIndex = 0;
            this.tabSecGrp.Size = new System.Drawing.Size(500, 428);
            this.tabSecGrp.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 402);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(486, 71);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(305, 40);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(305, 16);
            this.txtCreateTime.MaxLength = 20;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(125, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(13, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(125, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(13, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopyTable);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopy.Size = new System.Drawing.Size(492, 402);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Security Group";
            this.tbpCopy.Visible = false;
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.btnCopy);
            this.grpCopyTable.Controls.Add(this.lblToSecGrp);
            this.grpCopyTable.Controls.Add(this.txtToSecGrp);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 0);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(486, 47);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(330, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToSecGrp
            // 
            this.lblToSecGrp.AutoSize = true;
            this.lblToSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToSecGrp.Location = new System.Drawing.Point(15, 19);
            this.lblToSecGrp.Name = "lblToSecGrp";
            this.lblToSecGrp.Size = new System.Drawing.Size(93, 13);
            this.lblToSecGrp.TabIndex = 0;
            this.lblToSecGrp.Text = "To Security Group";
            this.lblToSecGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToSecGrp
            // 
            this.txtToSecGrp.Location = new System.Drawing.Point(120, 16);
            this.txtToSecGrp.MaxLength = 20;
            this.txtToSecGrp.Name = "txtToSecGrp";
            this.txtToSecGrp.Size = new System.Drawing.Size(200, 20);
            this.txtToSecGrp.TabIndex = 0;
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttribute);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Size = new System.Drawing.Size(492, 402);
            this.tbpAttribute.TabIndex = 2;
            this.tbpAttribute.Text = "Attribute";
            this.tbpAttribute.UseVisualStyleBackColor = false;
            // 
            // udcAttribute
            // 
            this.udcAttribute.AttributeFactory = "";
            this.udcAttribute.AttributeKey = "";
            this.udcAttribute.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttribute.AttributeName = "";
            this.udcAttribute.AttributeType = "SECGROUP";
            this.udcAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttribute.FromSequence = 0;
            this.udcAttribute.Location = new System.Drawing.Point(0, 0);
            this.udcAttribute.Name = "udcAttribute";
            this.udcAttribute.Size = new System.Drawing.Size(492, 402);
            this.udcAttribute.TabIndex = 0;
            this.udcAttribute.ToSequence = 2147483647;
            // 
            // frmSECSetupSecurityGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSECSetupSecurityGroup";
            this.Text = "Security Group Setup";
            this.Activated += new System.EventHandler(this.frmSECTBLDEF00_Activated);
            this.Load += new System.EventHandler(this.frmSECTBLDEF00_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpSecGrp.ResumeLayout(false);
            this.grpSecGrp.PerformLayout();
            this.plnRightBottom.ResumeLayout(false);
            this.tabSecGrp.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.tbpAttribute.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        bool b_load_flag;
        
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

            switch (MPCF.Trim(FuncName))
            {
                case "Update_SecGrp":

                    if (MPCF.CheckValue(txtSecGrp, 1) == false)
                    {
                        return false;
                    }
                    break;
                    
                case "Copy_SecGrp":
                    
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        if (MPCF.CheckValue(txtSecGrp, 1) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtToSecGrp, 1) == false)
                        {
                            tabSecGrp.SelectedIndex = 1;
                            return false;
                        }
                    }
                    else
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(129));
                        return false;
                    }
                    break;
                    
            }
            return true;
        }
        
        //
        // View_SecGrp()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_SecGrp()
        {
            TRSNode in_node = new TRSNode("VIEW_SECGRP_IN");
            TRSNode out_node = new TRSNode("VIEW_SECGRP_OUT");
            
            try
            {
                MPCF.FieldClear(this, txtFind, null, null, null, null, false);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SEC_GRP_ID", lisSecGrp.SelectedItems[0].Text);

                if (MPCR.CallService("SEC", "SEC_View_SecGrp", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSecGrp.Text = MPCF.Trim(out_node.GetString("SEC_GRP_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("SEC_GRP_DESC"));

                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                udcAttribute.AttributeKey = MPCF.Trim(out_node.GetString("SEC_GRP_ID"));
                udcAttribute.View();

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_SecGrp()
        //       - Create/Update/Delete Security Group Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_SecGrp(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_SECGRP_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("SEC_GRP_ID", txtSecGrp.Text);
                in_node.AddString("SEC_GRP_DESC", MPCF.Trim(txtDesc.Text));

                if (MPCR.CallService("SEC", "SEC_Update_SecGrp", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisSecGrp.Items.Add(MPCF.Trim(txtSecGrp.Text), (int)SMALLICON_INDEX.IDX_SEC_GROUP);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisSecGrp.Sorting = SortOrder.Ascending;
                        lisSecGrp.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisSecGrp, MPCF.Trim(txtSecGrp.Text), false) == true)
                        {
                            lisSecGrp.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisSecGrp, MPCF.Trim(txtSecGrp.Text), false);
                        if (idx != - 1)
                        {
                            lisSecGrp.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisSecGrp.Items.Count.ToString();
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
        
        
        //
        // Copy_SecGrp()
        //       - Copy Security Group Definition & Group Functions
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("C" - Copy)
        //
        private bool Copy_SecGrp(char ProcStep)
        {
            TRSNode in_node = new TRSNode("COPY_SECGRP_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            ListViewItem itm = new ListViewItem();
            
            try
            {
                MPCR.SetInMsg(in_node);                
                in_node.ProcStep = ProcStep;
                in_node.AddString("FROM_SEC_GRP_ID", txtSecGrp.Text);
                in_node.AddString("SEC_GRP_ID", txtToSecGrp.Text);

                if (MPCR.CallService("SEC", "SEC_Copy_SecGrp", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    itm = lisSecGrp.Items.Add(MPCF.Trim(txtToSecGrp.Text), (int)SMALLICON_INDEX.IDX_SEC_GROUP);
                    itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                    itm.Selected = true;
                    itm.EnsureVisible();
                    lblDataCount.Text = lisSecGrp.Items.Count.ToString();
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisSecGrp;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmSECTBLDEF00_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (SECLIST.ViewSecGroupList(lisSecGrp, '1', null, "") == true)
                    {
                        lblDataCount.Text = lisSecGrp.Items.Count.ToString();
                        if (lisSecGrp.Items.Count > 0)
                        {
                            lisSecGrp.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmSECTBLDEF00_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisSecGrp);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_SecGrp", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_SecGrp(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_SecGrp", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_SecGrp(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_SecGrp", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_SecGrp(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisSecGrp_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisSecGrp.SelectedIndices.Count > 0)
                {
                    View_SecGrp();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (SECLIST.ViewSecGroupList(lisSecGrp, '1', null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisSecGrp.Items.Count.ToString();
                if (lisSecGrp.Items.Count > 0)
                {
                    MPCF.FindListItem(lisSecGrp, txtSecGrp.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtSecGrp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisSecGrp, this.Text, "");
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Copy_SecGrp", MPGC.MP_STEP_COPY) == true)
            {
                if (Copy_SecGrp(MPGC.MP_STEP_COPY) == false)
                {
                    return;
                }
                if (SECLIST.ViewSecGroupList(lisSecGrp, '1', null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisSecGrp.Items.Count.ToString();
                if (lisSecGrp.Items.Count > 0)
                {
                    MPCF.FindListItem(lisSecGrp, txtToSecGrp.Text, false);
                }
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisSecGrp, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisSecGrp, txtFind.Text, 0, true, false);
            
        }
        
    }
    
}
