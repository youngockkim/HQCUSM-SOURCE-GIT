//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupResourceGroup.vb
//   Description : Resource Group Setup
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_SecGrp() : View Security Group definition
//       - View_Resource_Group_List() : View all table list which is included in one factory
//       - Update_SecGrp() : Create/Update/Delete Security Group definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-08-28 : Created by Aiden
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public class frmRASSetupResourceGroup : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupResourceGroup()
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
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tbpCopyGroup;
        private System.Windows.Forms.GroupBox grpCopyResGrp;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TabControl tabResGrp;
        private Miracom.UI.Controls.MCListView.MCListView lisResGrp;
        private System.Windows.Forms.Label lblResGrp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtResGrp;
        private System.Windows.Forms.GroupBox grpResGrp;
        private System.Windows.Forms.Label lblToResGrp;
        private System.Windows.Forms.TextBox txtToResGrp;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisResGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtResGrp = new System.Windows.Forms.TextBox();
            this.lblResGrp = new System.Windows.Forms.Label();
            this.grpResGrp = new System.Windows.Forms.GroupBox();
            this.plnRightBottom = new System.Windows.Forms.Panel();
            this.tabResGrp = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpCopyGroup = new System.Windows.Forms.TabPage();
            this.grpCopyResGrp = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToResGrp = new System.Windows.Forms.Label();
            this.txtToResGrp = new System.Windows.Forms.TextBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpResGrp.SuspendLayout();
            this.plnRightBottom.SuspendLayout();
            this.tabResGrp.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.tbpCopyGroup.SuspendLayout();
            this.grpCopyResGrp.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.grpResGrp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisResGrp);
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
            // lisResGrp
            // 
            this.lisResGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisResGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResGrp.EnableSort = true;
            this.lisResGrp.EnableSortIcon = true;
            this.lisResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResGrp.FullRowSelect = true;
            this.lisResGrp.HideSelection = false;
            this.lisResGrp.Location = new System.Drawing.Point(3, 3);
            this.lisResGrp.MultiSelect = false;
            this.lisResGrp.Name = "lisResGrp";
            this.lisResGrp.Size = new System.Drawing.Size(229, 500);
            this.lisResGrp.TabIndex = 0;
            this.lisResGrp.UseCompatibleStateImageBehavior = false;
            this.lisResGrp.View = System.Windows.Forms.View.Details;
            this.lisResGrp.SelectedIndexChanged += new System.EventHandler(this.lisResGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Resource Group";
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
            // txtResGrp
            // 
            this.txtResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResGrp.Location = new System.Drawing.Point(132, 16);
            this.txtResGrp.MaxLength = 20;
            this.txtResGrp.Name = "txtResGrp";
            this.txtResGrp.Size = new System.Drawing.Size(177, 20);
            this.txtResGrp.TabIndex = 1;
            // 
            // lblResGrp
            // 
            this.lblResGrp.AutoSize = true;
            this.lblResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblResGrp.Location = new System.Drawing.Point(15, 19);
            this.lblResGrp.Name = "lblResGrp";
            this.lblResGrp.Size = new System.Drawing.Size(99, 13);
            this.lblResGrp.TabIndex = 0;
            this.lblResGrp.Text = "Resource Group";
            this.lblResGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpResGrp
            // 
            this.grpResGrp.Controls.Add(this.txtDesc);
            this.grpResGrp.Controls.Add(this.lblDesc);
            this.grpResGrp.Controls.Add(this.txtResGrp);
            this.grpResGrp.Controls.Add(this.lblResGrp);
            this.grpResGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpResGrp.Location = new System.Drawing.Point(3, 0);
            this.grpResGrp.Name = "grpResGrp";
            this.grpResGrp.Size = new System.Drawing.Size(500, 70);
            this.grpResGrp.TabIndex = 0;
            this.grpResGrp.TabStop = false;
            // 
            // plnRightBottom
            // 
            this.plnRightBottom.Controls.Add(this.tabResGrp);
            this.plnRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnRightBottom.Location = new System.Drawing.Point(3, 70);
            this.plnRightBottom.Name = "plnRightBottom";
            this.plnRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.plnRightBottom.Size = new System.Drawing.Size(500, 433);
            this.plnRightBottom.TabIndex = 1;
            // 
            // tabResGrp
            // 
            this.tabResGrp.Controls.Add(this.tbpGeneral);
            this.tabResGrp.Controls.Add(this.tbpCopyGroup);
            this.tabResGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResGrp.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResGrp.Location = new System.Drawing.Point(0, 5);
            this.tabResGrp.Name = "tabResGrp";
            this.tabResGrp.SelectedIndex = 0;
            this.tabResGrp.Size = new System.Drawing.Size(500, 428);
            this.tabResGrp.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpTime);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 402);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.txtUpdateTime);
            this.grpTime.Controls.Add(this.txtCreateTime);
            this.grpTime.Controls.Add(this.txtUpdateUser);
            this.grpTime.Controls.Add(this.lblUpdate);
            this.grpTime.Controls.Add(this.txtCreateUser);
            this.grpTime.Controls.Add(this.lblCreate);
            this.grpTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTime.Location = new System.Drawing.Point(3, 0);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(486, 71);
            this.grpTime.TabIndex = 0;
            this.grpTime.TabStop = false;
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
            // tbpCopyGroup
            // 
            this.tbpCopyGroup.Controls.Add(this.grpCopyResGrp);
            this.tbpCopyGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyGroup.Name = "tbpCopyGroup";
            this.tbpCopyGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopyGroup.Size = new System.Drawing.Size(492, 402);
            this.tbpCopyGroup.TabIndex = 1;
            this.tbpCopyGroup.Text = "Copy Resource Group";
            this.tbpCopyGroup.Visible = false;
            // 
            // grpCopyResGrp
            // 
            this.grpCopyResGrp.Controls.Add(this.btnCopy);
            this.grpCopyResGrp.Controls.Add(this.lblToResGrp);
            this.grpCopyResGrp.Controls.Add(this.txtToResGrp);
            this.grpCopyResGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyResGrp.Location = new System.Drawing.Point(3, 0);
            this.grpCopyResGrp.Name = "grpCopyResGrp";
            this.grpCopyResGrp.Size = new System.Drawing.Size(486, 47);
            this.grpCopyResGrp.TabIndex = 0;
            this.grpCopyResGrp.TabStop = false;
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
            // lblToResGrp
            // 
            this.lblToResGrp.AutoSize = true;
            this.lblToResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToResGrp.Location = new System.Drawing.Point(13, 19);
            this.lblToResGrp.Name = "lblToResGrp";
            this.lblToResGrp.Size = new System.Drawing.Size(101, 13);
            this.lblToResGrp.TabIndex = 0;
            this.lblToResGrp.Text = "To Resource Group";
            this.lblToResGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToResGrp
            // 
            this.txtToResGrp.Location = new System.Drawing.Point(125, 16);
            this.txtToResGrp.MaxLength = 20;
            this.txtToResGrp.Name = "txtToResGrp";
            this.txtToResGrp.Size = new System.Drawing.Size(177, 20);
            this.txtToResGrp.TabIndex = 1;
            // 
            // frmRASSetupResourceGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupResourceGroup";
            this.Text = "Resource Group Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupResourceGroup_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupResourceGroup_Load);
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
            this.grpResGrp.ResumeLayout(false);
            this.grpResGrp.PerformLayout();
            this.plnRightBottom.ResumeLayout(false);
            this.tabResGrp.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.tbpCopyGroup.ResumeLayout(false);
            this.grpCopyResGrp.ResumeLayout(false);
            this.grpCopyResGrp.PerformLayout();
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
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "UpdateResourceGroup":

                    if (MPCF.CheckValue(txtResGrp, 1) == false)
                    {
                        return false;
                    }
                    break;

                case "CopyResourceGroup":
                    
                    if (MPCF.CheckValue(txtResGrp, 1) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtToResGrp, 1) == false)
                    {
                        tabResGrp.SelectedIndex = 1;
                        return false;
                    }
                    break;
                    
            }
            return true;
        }
        
        //
        // ViewResourceGroup()
        //       - View resource group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewResourceGroup()
        {
            TRSNode in_node = new TRSNode("View_Resource_Group_In");
            TRSNode out_node = new TRSNode("View_Resource_Group_Out");
            
            try
            {
                MPCF.FieldClear(this, txtFind);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RESG_ID", lisResGrp.SelectedItems[0].Text);

                if (MPCR.CallService("RAS", "RAS_View_Resource_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtResGrp.Text = out_node.GetString("RESG_ID");
                txtDesc.Text = out_node.GetString("RESG_DESC");

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
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
        // UpdateResourceGroup()
        //       - Create/Update/Delete Resource Group Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool UpdateResourceGroup(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("Update_Resource_Group_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
               
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("RESG_ID", txtResGrp.Text);
                in_node.AddString("RESG_DESC", MPCF.Trim(txtDesc.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Resource_Group", in_node, ref out_node) == false)
                {
                    return false;
                }            
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisResGrp.Items.Add(MPCF.Trim(txtResGrp.Text), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisResGrp.Sorting = SortOrder.Ascending;
                        lisResGrp.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisResGrp, MPCF.Trim(txtResGrp.Text), false) == true)
                        {
                            lisResGrp.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisResGrp, MPCF.Trim(txtResGrp.Text), false);
                        if (idx != - 1)
                        {
                            lisResGrp.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisResGrp.Items.Count.ToString();
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
        // CopyResourceGroup()
        //       - Copy Resource Group Definition & Relate group resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool CopyResourceGroup()
        {
            TRSNode in_node = new TRSNode("Copy_Resource_Group_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            ListViewItem itm = new ListViewItem();
            
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_COPY;
                in_node.AddString("RESG_ID", txtResGrp.Text);
                in_node.AddString("TO_RESG_ID", txtToResGrp.Text);


                if (MPCR.CallService("RAS", "RAS_Copy_Resource_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    itm = lisResGrp.Items.Add(MPCF.Trim(txtToResGrp.Text), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                    itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                    itm.Selected = true;
                    itm.EnsureVisible();
                    lblDataCount.Text = lisResGrp.Items.Count.ToString();
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
                return this.lisResGrp;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion

        private void frmRASSetupResourceGroup_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (RASLIST.ViewResourceGroupList(lisResGrp, '1') == true)
                    {
                        lblDataCount.Text = lisResGrp.Items.Count.ToString();
                        if (lisResGrp.Items.Count > 0)
                        {
                            lisResGrp.Items[0].Selected = true;
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

        private void frmRASSetupResourceGroup_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisResGrp);
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
                if (CheckCondition("UpdateResourceGroup") == true)
                {
                    if (UpdateResourceGroup(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("UpdateResourceGroup") == true)
                {
                    if (UpdateResourceGroup(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("UpdateResourceGroup") == true)
                {
                    if (UpdateResourceGroup(MPGC.MP_STEP_DELETE) == false)
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
        
        private void lisResGrp_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisResGrp.SelectedItems.Count > 0)
                {
                    ViewResourceGroup();
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
                if (RASLIST.ViewResourceGroupList(lisResGrp, '1') == false) return;
                lblDataCount.Text = lisResGrp.Items.Count.ToString();
                if (lisResGrp.Items.Count > 0)
                {
                    MPCF.FindListItem(lisResGrp, txtResGrp.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisResGrp, this.Text, "");
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CopyResourceGroup") == true)
            {
                if (CopyResourceGroup() == false) return;
                if (RASLIST.ViewResourceGroupList(lisResGrp, '1') == false) return;
                lblDataCount.Text = lisResGrp.Items.Count.ToString();
                if (lisResGrp.Items.Count > 0)
                {
                    MPCF.FindListItem(lisResGrp, txtToResGrp.Text, false);
                }
            }
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisResGrp, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisResGrp, txtFind.Text, 0, true, false);
        }
        
    }
    
}
