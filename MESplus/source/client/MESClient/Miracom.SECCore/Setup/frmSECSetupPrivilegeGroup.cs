
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
//   File Name   : frmSECSetupPrivilegeGroup.vb
//   Description : Privilege Group Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Privilege_Group() : View Privilege Group definition
//       - View_Privilege_Group_List() : View all table list which is included in one factory
//       - Update_Privilege_Group() : Create/Update/Delete Privilege Group definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-04-21 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.SECCore
{
    public class frmSECSetupPrivilegeGroup : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmSECSetupPrivilegeGroup()
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
        private Miracom.UI.Controls.MCListView.MCListView lisPrvGrp;
        private System.Windows.Forms.Label lblPrvGrp;
        private System.Windows.Forms.TextBox txtPrvGrp;
        private System.Windows.Forms.TabControl tabPrvGrp;
        private System.Windows.Forms.GroupBox grpPrvGrp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.GroupBox grpCopyPrvGrp;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToPrvGrp;
        private System.Windows.Forms.TextBox txtToPrvGrp;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisPrvGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtPrvGrp = new System.Windows.Forms.TextBox();
            this.lblPrvGrp = new System.Windows.Forms.Label();
            this.grpPrvGrp = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.plnRightBottom = new System.Windows.Forms.Panel();
            this.tabPrvGrp = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopyPrvGrp = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToPrvGrp = new System.Windows.Forms.Label();
            this.txtToPrvGrp = new System.Windows.Forms.TextBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpPrvGrp.SuspendLayout();
            this.plnRightBottom.SuspendLayout();
            this.tabPrvGrp.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopyPrvGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.plnRightBottom);
            this.pnlRight.Controls.Add(this.grpPrvGrp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisPrvGrp);
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
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Privilege Group Setup";
            // 
            // lisPrvGrp
            // 
            this.lisPrvGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPrvGrp.EnableSort = true;
            this.lisPrvGrp.EnableSortIcon = true;
            this.lisPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPrvGrp.FullRowSelect = true;
            this.lisPrvGrp.HideSelection = false;
            this.lisPrvGrp.Location = new System.Drawing.Point(3, 3);
            this.lisPrvGrp.MultiSelect = false;
            this.lisPrvGrp.Name = "lisPrvGrp";
            this.lisPrvGrp.Size = new System.Drawing.Size(229, 500);
            this.lisPrvGrp.TabIndex = 0;
            this.lisPrvGrp.UseCompatibleStateImageBehavior = false;
            this.lisPrvGrp.View = System.Windows.Forms.View.Details;
            this.lisPrvGrp.SelectedIndexChanged += new System.EventHandler(this.lisPrvGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Privilege Group";
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
            this.txtDesc.Size = new System.Drawing.Size(356, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtPrvGrp
            // 
            this.txtPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrvGrp.Location = new System.Drawing.Point(132, 16);
            this.txtPrvGrp.MaxLength = 20;
            this.txtPrvGrp.Name = "txtPrvGrp";
            this.txtPrvGrp.Size = new System.Drawing.Size(200, 20);
            this.txtPrvGrp.TabIndex = 1;
            this.txtPrvGrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrvGrp_KeyPress);
            // 
            // lblPrvGrp
            // 
            this.lblPrvGrp.AutoSize = true;
            this.lblPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrvGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPrvGrp.Location = new System.Drawing.Point(15, 19);
            this.lblPrvGrp.Name = "lblPrvGrp";
            this.lblPrvGrp.Size = new System.Drawing.Size(94, 13);
            this.lblPrvGrp.TabIndex = 0;
            this.lblPrvGrp.Text = "Privilege Group";
            this.lblPrvGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpPrvGrp
            // 
            this.grpPrvGrp.Controls.Add(this.lblDesc);
            this.grpPrvGrp.Controls.Add(this.txtDesc);
            this.grpPrvGrp.Controls.Add(this.txtPrvGrp);
            this.grpPrvGrp.Controls.Add(this.lblPrvGrp);
            this.grpPrvGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPrvGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpPrvGrp.Location = new System.Drawing.Point(3, 0);
            this.grpPrvGrp.Name = "grpPrvGrp";
            this.grpPrvGrp.Size = new System.Drawing.Size(500, 70);
            this.grpPrvGrp.TabIndex = 0;
            this.grpPrvGrp.TabStop = false;
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
            // plnRightBottom
            // 
            this.plnRightBottom.Controls.Add(this.tabPrvGrp);
            this.plnRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnRightBottom.Location = new System.Drawing.Point(3, 70);
            this.plnRightBottom.Name = "plnRightBottom";
            this.plnRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.plnRightBottom.Size = new System.Drawing.Size(500, 433);
            this.plnRightBottom.TabIndex = 1;
            // 
            // tabPrvGrp
            // 
            this.tabPrvGrp.Controls.Add(this.tbpGeneral);
            this.tabPrvGrp.Controls.Add(this.tbpCopy);
            this.tabPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrvGrp.ItemSize = new System.Drawing.Size(60, 18);
            this.tabPrvGrp.Location = new System.Drawing.Point(0, 5);
            this.tabPrvGrp.Name = "tabPrvGrp";
            this.tabPrvGrp.SelectedIndex = 0;
            this.tabPrvGrp.Size = new System.Drawing.Size(500, 428);
            this.tabPrvGrp.TabIndex = 0;
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
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(305, 16);
            this.txtCreateTime.MaxLength = 30;
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
            this.tbpCopy.Controls.Add(this.grpCopyPrvGrp);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopy.Size = new System.Drawing.Size(492, 402);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Privilege Group";
            this.tbpCopy.Visible = false;
            // 
            // grpCopyPrvGrp
            // 
            this.grpCopyPrvGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCopyPrvGrp.Controls.Add(this.btnCopy);
            this.grpCopyPrvGrp.Controls.Add(this.lblToPrvGrp);
            this.grpCopyPrvGrp.Controls.Add(this.txtToPrvGrp);
            this.grpCopyPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyPrvGrp.Location = new System.Drawing.Point(3, 0);
            this.grpCopyPrvGrp.Name = "grpCopyPrvGrp";
            this.grpCopyPrvGrp.Size = new System.Drawing.Size(486, 47);
            this.grpCopyPrvGrp.TabIndex = 0;
            this.grpCopyPrvGrp.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(330, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToPrvGrp
            // 
            this.lblToPrvGrp.AutoSize = true;
            this.lblToPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToPrvGrp.Location = new System.Drawing.Point(15, 19);
            this.lblToPrvGrp.Name = "lblToPrvGrp";
            this.lblToPrvGrp.Size = new System.Drawing.Size(95, 13);
            this.lblToPrvGrp.TabIndex = 0;
            this.lblToPrvGrp.Text = "To Privilege Group";
            this.lblToPrvGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToPrvGrp
            // 
            this.txtToPrvGrp.Location = new System.Drawing.Point(120, 16);
            this.txtToPrvGrp.MaxLength = 20;
            this.txtToPrvGrp.Name = "txtToPrvGrp";
            this.txtToPrvGrp.Size = new System.Drawing.Size(200, 20);
            this.txtToPrvGrp.TabIndex = 1;
            // 
            // frmSECSetupPrivilegeGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSECSetupPrivilegeGroup";
            this.Text = "Privilege Group Setup";
            this.Activated += new System.EventHandler(this.frmSECSteupPrivilegeGroup_Activated);
            this.Load += new System.EventHandler(this.frmSECSetupPrivilegeGroup_Load);
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
            this.grpPrvGrp.ResumeLayout(false);
            this.grpPrvGrp.PerformLayout();
            this.plnRightBottom.ResumeLayout(false);
            this.tabPrvGrp.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyPrvGrp.ResumeLayout(false);
            this.grpCopyPrvGrp.PerformLayout();
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
                case "Update_Privilege_Group":

                    if (MPCF.CheckValue(txtPrvGrp, 1) == false)
                    {
                        return false;
                    }
                    break;
                    
                case "Copy_Privilege_Group":
                    
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        if (MPCF.CheckValue(txtPrvGrp, 1) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtToPrvGrp, 1) == false)
                        {
                            tabPrvGrp.SelectedIndex = 1;
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
        // View_Privilege_Group()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Privilege_Group()
        {
            TRSNode in_node = new TRSNode("VIEW_PRIVILEGE_GROUP_IN");
            TRSNode out_node = new TRSNode("VIEW_PRIVILEGE_GROUP_OUT");
            
            try
            {
                MPCF.FieldClear(this, txtFind, null, null, null, null, false);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PRV_GRP_ID", lisPrvGrp.SelectedItems[0].Text);

                if (MPCR.CallService("SEC", "SEC_View_Privilege_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtPrvGrp.Text = MPCF.Trim(out_node.GetString("PRV_GRP_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("PRV_GRP_DESC"));

                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_Privilege_Group()
        //       - Create/Update/Delete Privilege Group Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Privilege_Group(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_PRIVILEGE_GROUP_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("PRV_GRP_ID", txtPrvGrp.Text);
                in_node.AddString("PRV_GRP_DESC", MPCF.Trim(txtDesc.Text));

                if (MPCR.CallService("SEC", "SEC_Update_Privilege_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisPrvGrp.Items.Add(MPCF.Trim(txtPrvGrp.Text), (int)SMALLICON_INDEX.IDX_SEC_GROUP);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisPrvGrp.Sorting = SortOrder.Ascending;
                        lisPrvGrp.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisPrvGrp, MPCF.Trim(txtPrvGrp.Text), false) == true)
                        {
                            lisPrvGrp.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisPrvGrp, MPCF.Trim(txtPrvGrp.Text), false);
                        if (idx != - 1)
                        {
                            lisPrvGrp.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisPrvGrp.Items.Count.ToString();
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
        // Copy_Privilege_Group()
        //       - Copy Privilege Group Definition & Group Functions
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("C" - Copy)
        //
        private bool Copy_Privilege_Group(char ProcStep)
        {
            TRSNode in_node = new TRSNode("COPY_PRIVILEGE_GROUP_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            ListViewItem itm = new ListViewItem();
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FROM_PRV_GRP_ID", txtPrvGrp.Text);
                in_node.AddString("PRV_GRP_ID", txtToPrvGrp.Text);

                if (MPCR.CallService("SEC", "SEC_Copy_Privilege_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    itm = lisPrvGrp.Items.Add(MPCF.Trim(txtToPrvGrp.Text), (int)SMALLICON_INDEX.IDX_SEC_GROUP);
                    itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                    itm.Selected = true;
                    itm.EnsureVisible();
                    lblDataCount.Text = lisPrvGrp.Items.Count.ToString();
                }
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
                return this.lisPrvGrp;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmSECSteupPrivilegeGroup_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (SECLIST.ViewPrvGroupList(lisPrvGrp, '1', null, "") == true)
                    {
                        lblDataCount.Text = lisPrvGrp.Items.Count.ToString();
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
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
        
        private void frmSECSetupPrivilegeGroup_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisPrvGrp);
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
                if (CheckCondition("Update_Privilege_Group", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Privilege_Group(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("Update_Privilege_Group", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Privilege_Group(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("Update_Privilege_Group", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Privilege_Group(MPGC.MP_STEP_DELETE) == false)
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
        
        private void lisPrvGrp_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisPrvGrp.SelectedIndices.Count > 0)
                {
                    View_Privilege_Group();
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
                if (SECLIST.ViewPrvGroupList(lisPrvGrp, '1', null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisPrvGrp.Items.Count.ToString();
                if (lisPrvGrp.Items.Count > 0)
                {
                    MPCF.FindListItem(lisPrvGrp, txtPrvGrp.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtPrvGrp_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
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

            MPCF.ExportToExcel(lisPrvGrp, this.Text, "");
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Copy_Privilege_Group", MPGC.MP_STEP_COPY) == true)
            {
                if (Copy_Privilege_Group(MPGC.MP_STEP_COPY) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (SECLIST.ViewPrvGroupList(lisPrvGrp, '1', null, "") == false)
                    {
                        return;
                    }
                    lblDataCount.Text = lisPrvGrp.Items.Count.ToString();
                    if (lisPrvGrp.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisPrvGrp, txtToPrvGrp.Text, false);
                    }
                }
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisPrvGrp, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisPrvGrp, txtFind.Text, 0, true, false);
            
        }
        
    }
    
}
