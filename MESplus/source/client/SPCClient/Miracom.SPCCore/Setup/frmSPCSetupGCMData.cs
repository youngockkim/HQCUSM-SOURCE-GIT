
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
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCSetupGCMData.vb
//   Description :
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - View_Data() : View Data Information
//       - Update_Data() : Create/Update/Delete Data
//       - RefreshDataList() : Refresh Data List
//
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-12-12 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCSetupGCMData : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCSetupGCMData()
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
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnCreate;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.GroupBox grpOption;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.RadioButton rbnTrouble;
        internal System.Windows.Forms.RadioButton rbnAction;
        internal Miracom.UI.Controls.MCListView.MCListView lisData;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblCode;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCode;
        internal System.Windows.Forms.Splitter splData;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.rbnAction = new System.Windows.Forms.RadioButton();
            this.rbnTrouble = new System.Windows.Forms.RadioButton();
            this.splData = new System.Windows.Forms.Splitter();
            this.lisData = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            this.grpOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnCreate);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 314);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(456, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(374, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(294, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Location = new System.Drawing.Point(214, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.Location = new System.Drawing.Point(134, 9);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(74, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpData);
            this.pnlCenter.Controls.Add(this.grpOption);
            this.pnlCenter.Controls.Add(this.splData);
            this.pnlCenter.Controls.Add(this.lisData);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(456, 314);
            this.pnlCenter.TabIndex = 0;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lblDesc);
            this.grpData.Controls.Add(this.lblCode);
            this.grpData.Controls.Add(this.txtDesc);
            this.grpData.Controls.Add(this.txtCode);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpData.Location = new System.Drawing.Point(3, 240);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(450, 74);
            this.grpData.TabIndex = 3;
            this.grpData.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(8, 46);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(8, 22);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(36, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(112, 43);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(332, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(112, 19);
            this.txtCode.MaxLength = 30;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 20);
            this.txtCode.TabIndex = 1;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.rbnAction);
            this.grpOption.Controls.Add(this.rbnTrouble);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 191);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(450, 49);
            this.grpOption.TabIndex = 2;
            this.grpOption.TabStop = false;
            // 
            // rbnAction
            // 
            this.rbnAction.AutoSize = true;
            this.rbnAction.Location = new System.Drawing.Point(263, 19);
            this.rbnAction.Name = "rbnAction";
            this.rbnAction.Size = new System.Drawing.Size(83, 17);
            this.rbnAction.TabIndex = 1;
            this.rbnAction.Text = "Action Code";
            this.rbnAction.CheckedChanged += new System.EventHandler(this.rbnAction_CheckedChanged);
            // 
            // rbnTrouble
            // 
            this.rbnTrouble.AutoSize = true;
            this.rbnTrouble.Location = new System.Drawing.Point(59, 19);
            this.rbnTrouble.Name = "rbnTrouble";
            this.rbnTrouble.Size = new System.Drawing.Size(89, 17);
            this.rbnTrouble.TabIndex = 0;
            this.rbnTrouble.Text = "Trouble Code";
            // 
            // splData
            // 
            this.splData.Dock = System.Windows.Forms.DockStyle.Top;
            this.splData.Location = new System.Drawing.Point(3, 188);
            this.splData.Name = "splData";
            this.splData.Size = new System.Drawing.Size(450, 3);
            this.splData.TabIndex = 1;
            this.splData.TabStop = false;
            // 
            // lisData
            // 
            this.lisData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisData.EnableSort = true;
            this.lisData.EnableSortIcon = true;
            this.lisData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisData.FullRowSelect = true;
            this.lisData.Location = new System.Drawing.Point(3, 3);
            this.lisData.MultiSelect = false;
            this.lisData.Name = "lisData";
            this.lisData.Size = new System.Drawing.Size(450, 185);
            this.lisData.TabIndex = 0;
            this.lisData.TabStop = false;
            this.lisData.UseCompatibleStateImageBehavior = false;
            this.lisData.View = System.Windows.Forms.View.Details;
            this.lisData.SelectedIndexChanged += new System.EventHandler(this.lisData_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Code";
            this.ColumnHeader1.Width = 150;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 270;
            // 
            // frmSPCSetupGCMData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(456, 354);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSPCSetupGCMData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trouble / Action Code Setup";
            this.Load += new System.EventHandler(this.frmSPCSetupGCMData_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (rbnAction.Checked == false && rbnTrouble.Checked == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    rbnAction.Focus();
                    return false;
                }
                
                if (txtCode.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtCode.Focus();
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Data()
        //       - View GCM Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Data()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Data_In");
                TRSNode out_node = new TRSNode("View_Data_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("TABLE_NAME", (rbnAction.Checked == true ? modSPCConstants.MP_SPC_ACTION_CODE : modSPCConstants.MP_SPC_TROUBLE_CODE));
                in_node.AddString("KEY_1", MPCF.Trim(lisData.SelectedItems[0].Text));

                if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCode.Text = MPCF.Trim(lisData.SelectedItems[0].Text);
                txtDesc.Text = out_node.GetString("DATA_1");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.View_Data()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Update_Data()
        //       - View GCM Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Update_Data(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Update_Data_In");
                TRSNode out_node = new TRSNode("Cmn_Out");


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;             
                in_node.AddString("TABLE_NAME", (rbnAction.Checked == true ? modSPCConstants.MP_SPC_ACTION_CODE : modSPCConstants.MP_SPC_TROUBLE_CODE));
                in_node.AddString("KEY_1", MPCF.Trim(txtCode.Text));
                in_node.AddString("DATA_1", MPCF.Trim(txtDesc.Text));

                if (MPCR.CallService("SPC", "SPC_Update_Data", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.Update_Data()\n" + ex.Message);
                return false;
            }
            
        }
        
        // RefreshDataList()
        //       - Refresh Data List
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void RefreshDataList()
        {
            
            try
            {
                if (rbnTrouble.Checked == true)
                {
                    BASLIST.ViewGCMDataList(lisData, '1', modSPCConstants.MP_SPC_TROUBLE_CODE);
                }
                else
                {
                    BASLIST.ViewGCMDataList(lisData, '1', modSPCConstants.MP_SPC_ACTION_CODE);
                }
                if (lisData.Items.Count > 0)
                {
                    MPCF.FindListItem(lisData, txtCode.Text, false);
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.RefreshDataList()\n" + ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisData;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implementations"
        
        private void frmSPCSetupGCMData_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                rbnTrouble.Checked = true;
                BASLIST.ViewGCMDataList(lisData, '1', modSPCConstants.MP_SPC_TROUBLE_CODE);
                if (lisData.Items.Count > 0)
                {
                    lisData.Items[0].Selected = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.frmSPCSetupGCMData_Load()\n" + ex.Message);
            }
            
        }
        
        private void rbnAction_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (rbnTrouble.Checked == true)
                {
                    BASLIST.ViewGCMDataList(lisData, '1', modSPCConstants.MP_SPC_TROUBLE_CODE);
                }
                else
                {
                    BASLIST.ViewGCMDataList(lisData, '1', modSPCConstants.MP_SPC_ACTION_CODE);
                }
                if (lisData.Items.Count > 0)
                {
                    lisData.Items[0].Selected = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.rbnAction_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void lisData_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.grpData);
                if (lisData.SelectedItems.Count > 0)
                {
                    View_Data();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.lisData_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (Update_Data(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                RefreshDataList();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.btnCreate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (Update_Data(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                RefreshDataList();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.btnUpdate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (Update_Data(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                MPCF.FieldClear(this.grpData);
                RefreshDataList();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.btnDelete_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupGCMData.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
