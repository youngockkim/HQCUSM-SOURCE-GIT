
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;
//#If _RTD = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRTDSetupDispatcher.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-19 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.RTDCore
{
    public class frmRTDSetupRule : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRTDSetupRule()
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
        



        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblRuleID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtRuleID;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabPage tbpGeneral;
        private Miracom.UI.Controls.MCListView.MCListView lisRule;
        private System.Windows.Forms.ColumnHeader colRuleID;
        private System.Windows.Forms.ColumnHeader colDspDesc;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabControl tabRule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRuleType;
        private Label lblRuleType;
        private ColumnHeader colRuleType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblRuleID = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtRuleID = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabRule = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvRuleType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRuleType = new System.Windows.Forms.Label();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lisRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.colRuleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuleType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpDsp.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabRule.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRuleType)).BeginInit();
            this.grpCreateInfo.SuspendLayout();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpDsp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisRule);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Rule Setup";
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblRuleID);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Controls.Add(this.txtRuleID);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(3, 0);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(500, 70);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 42);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblRuleID
            // 
            this.lblRuleID.AutoSize = true;
            this.lblRuleID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRuleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleID.Location = new System.Drawing.Point(15, 19);
            this.lblRuleID.Name = "lblRuleID";
            this.lblRuleID.Size = new System.Drawing.Size(50, 13);
            this.lblRuleID.TabIndex = 0;
            this.lblRuleID.Text = "Rule ID";
            this.lblRuleID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtRuleID
            // 
            this.txtRuleID.Location = new System.Drawing.Point(120, 16);
            this.txtRuleID.MaxLength = 20;
            this.txtRuleID.Name = "txtRuleID";
            this.txtRuleID.Size = new System.Drawing.Size(200, 20);
            this.txtRuleID.TabIndex = 1;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabRule);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 70);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 443);
            this.pnlTab.TabIndex = 1;
            // 
            // tabRule
            // 
            this.tabRule.Controls.Add(this.tbpGeneral);
            this.tabRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRule.ItemSize = new System.Drawing.Size(60, 18);
            this.tabRule.Location = new System.Drawing.Point(0, 5);
            this.tabRule.Name = "tabRule";
            this.tabRule.SelectedIndex = 0;
            this.tabRule.Size = new System.Drawing.Size(500, 438);
            this.tabRule.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Controls.Add(this.grpCreateInfo);
            this.tbpGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(5);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 412);
            this.tbpGeneral.TabIndex = 2;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.Visible = false;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvRuleType);
            this.grpGeneral.Controls.Add(this.lblRuleType);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(5, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(482, 332);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // cdvRuleType
            // 
            this.cdvRuleType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRuleType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRuleType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRuleType.BtnToolTipText = "";
            this.cdvRuleType.DescText = "";
            this.cdvRuleType.DisplaySubItemIndex = -1;
            this.cdvRuleType.DisplayText = "";
            this.cdvRuleType.Focusing = null;
            this.cdvRuleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRuleType.Index = 0;
            this.cdvRuleType.IsViewBtnImage = false;
            this.cdvRuleType.Location = new System.Drawing.Point(120, 19);
            this.cdvRuleType.MaxLength = 20;
            this.cdvRuleType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRuleType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRuleType.Name = "cdvRuleType";
            this.cdvRuleType.ReadOnly = true;
            this.cdvRuleType.SearchSubItemIndex = 0;
            this.cdvRuleType.SelectedDescIndex = -1;
            this.cdvRuleType.SelectedSubItemIndex = -1;
            this.cdvRuleType.SelectionStart = 0;
            this.cdvRuleType.Size = new System.Drawing.Size(177, 20);
            this.cdvRuleType.SmallImageList = null;
            this.cdvRuleType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRuleType.TabIndex = 1;
            this.cdvRuleType.TextBoxToolTipText = "";
            this.cdvRuleType.TextBoxWidth = 177;
            this.cdvRuleType.VisibleButton = true;
            this.cdvRuleType.VisibleColumnHeader = false;
            this.cdvRuleType.VisibleDescription = false;
            this.cdvRuleType.ButtonPress += new System.EventHandler(this.cdvRuleType_ButtonPress);
            // 
            // lblRuleType
            // 
            this.lblRuleType.AutoSize = true;
            this.lblRuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRuleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleType.Location = new System.Drawing.Point(10, 22);
            this.lblRuleType.Name = "lblRuleType";
            this.lblRuleType.Size = new System.Drawing.Size(65, 13);
            this.lblRuleType.TabIndex = 0;
            this.lblRuleType.Text = "Rule Type";
            // 
            // grpCreateInfo
            // 
            this.grpCreateInfo.Controls.Add(this.txtUpdateTime);
            this.grpCreateInfo.Controls.Add(this.txtCreateTime);
            this.grpCreateInfo.Controls.Add(this.txtUpdateUser);
            this.grpCreateInfo.Controls.Add(this.lblUpdate);
            this.grpCreateInfo.Controls.Add(this.txtCreateUser);
            this.grpCreateInfo.Controls.Add(this.lblCreate);
            this.grpCreateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCreateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateInfo.Location = new System.Drawing.Point(5, 337);
            this.grpCreateInfo.Name = "grpCreateInfo";
            this.grpCreateInfo.Size = new System.Drawing.Size(482, 70);
            this.grpCreateInfo.TabIndex = 1;
            this.grpCreateInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(300, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(300, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
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
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
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
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisRule
            // 
            this.lisRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRuleID,
            this.colRuleType,
            this.colDspDesc});
            this.lisRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRule.EnableSort = true;
            this.lisRule.EnableSortIcon = true;
            this.lisRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRule.FullRowSelect = true;
            this.lisRule.HideSelection = false;
            this.lisRule.Location = new System.Drawing.Point(3, 3);
            this.lisRule.MultiSelect = false;
            this.lisRule.Name = "lisRule";
            this.lisRule.Size = new System.Drawing.Size(229, 508);
            this.lisRule.TabIndex = 0;
            this.lisRule.UseCompatibleStateImageBehavior = false;
            this.lisRule.View = System.Windows.Forms.View.Details;
            this.lisRule.SelectedIndexChanged += new System.EventHandler(this.lisRule_SelectedIndexChanged);
            // 
            // colRuleID
            // 
            this.colRuleID.Text = "Rule ID";
            this.colRuleID.Width = 100;
            // 
            // colRuleType
            // 
            this.colRuleType.Text = "Rule Type";
            this.colRuleType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colRuleType.Width = 65;
            // 
            // colDspDesc
            // 
            this.colDspDesc.Text = "Description";
            this.colDspDesc.Width = 300;
            // 
            // frmRTDSetupRule
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDSetupRule";
            this.Text = "Dispatcher Rule Setup";
            this.Activated += new System.EventHandler(this.frmRTDSetupRule_Activated);
            this.Load += new System.EventHandler(this.frmRTDSetupRule_Load);
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
            this.grpDsp.ResumeLayout(false);
            this.grpDsp.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.tabRule.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRuleType)).EndInit();
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Variable Definition"
        bool b_load_flag = false;
        #endregion
        
        #region "Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            
            try
            {
                if (MPCF.CheckValue(txtRuleID, 1) == false)
                {
                    return false;
                }
                
                switch (c_step)
                {
                    case MPGC.MP_STEP_CREATE:                        
                     
                        break;
                    case MPGC.MP_STEP_UPDATE:

                        break;
                    case MPGC.MP_STEP_DELETE:                        
                   
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
        // Update_Rule()
        //       - Create/Update/Delete Rule Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Rule(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_RULE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RULE_ID", MPCF.Trim(txtRuleID.Text));
                in_node.AddString("RULE_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddChar("RULE_TYPE", Convert.ToChar(MPCF.Trim(cdvRuleType.Text)));

                if (MPCR.CallService("RTD", "RTD_Update_Rule", in_node, ref out_node) == false)
                {
                    return false;
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
        // View_Rule()
        //       - View Rule Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Rule(string s_rule_id)
        {
            TRSNode in_node = new TRSNode("VIEW_RULE_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("RULE_ID", MPCF.Trim(s_rule_id));

                if (MPCR.CallService("RTD", "RTD_View_Rule", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtRuleID.Text = MPCF.Trim(out_node.GetString("RULE_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));
                cdvRuleType.Text = MPCF.Trim(out_node.GetChar("RULE_TYPE"));
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
        
        private bool ExistListItem(ListView MyListView, string Item, char c_step)
        {
            int index;
            
            if (Item == "")
            {
                return false;
            }
            if (c_step == '1')
            {
                for (index = 0; index <= MyListView.Items.Count - 1; index++)
                {
                    if (MyListView.Items[index].Text == Item)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (index = 0; index <= MyListView.Items.Count - 1; index++)
                {
                    if (MyListView.Items[index].Text == Item)
                    {
                        if (MyListView.SelectedItems[0].Index != index)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisRule;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        #endregion
        
        private void frmRTDSetupRule_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    lblDataCount.Text = "";
                    if (RTDLIST.ViewRuleList(lisRule, '1', null, "", ' ') == true)
                    {
                        lblDataCount.Text = lisRule.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisRule.Items.Count > 0)
                    {
                        lisRule.Items[0].Selected = true;
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRTDSetupRule_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisRule);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ExportToExcel(lisRule, this.Text, "");
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
                if (RTDLIST.ViewRuleList(lisRule, '1', null, "", ' ') == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisRule.Items.Count);
                }
                if (lisRule.Items.Count > 0)
                {
                    MPCF.FindListItem(lisRule, txtRuleID.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisRule, txtFind.Text, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisRule, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisRule_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                
                if (lisRule.SelectedItems.Count > 0)
                {
                    if (View_Rule(lisRule.SelectedItems[0].Text) == false)
                    {
                        return;
                    }
                }
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
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (Update_Rule(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                btnRefresh.PerformClick();
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
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (Update_Rule(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                MPCF.FieldClear(this.pnlRight);

                btnRefresh.PerformClick();
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
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (Update_Rule(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                btnRefresh.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvRuleType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvRuleType.Init();
                MPCF.InitListView(cdvRuleType.GetListView);
                cdvRuleType.Columns.Add("Rule Type", 50, HorizontalAlignment.Left);
                cdvRuleType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRuleType.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvRuleType.GetListView, '1', "RTD_RULE_TYPE");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }    
                
    }
//#End If
}
