
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmINVTranInInventory.vb
//   Description : Inventory In Inventory Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - In_Store() : Inventory In Store transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-12 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _INV = True Then

namespace Miracom.INVCore
{
    public class frmINVTranInInventory : Miracom.MESCore.TranForm09
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVTranInInventory()
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
        



        private System.Windows.Forms.GroupBox grpTransInfo;
        protected System.Windows.Forms.TextBox txtSetAllocQty;
        protected System.Windows.Forms.Label lblSetAllocQty;
        protected System.Windows.Forms.TextBox txtInQty1;
        protected System.Windows.Forms.Label lblInQty1;
        protected System.Windows.Forms.Label lblInUnit1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpTransInfo = new System.Windows.Forms.GroupBox();
            this.lblInUnit1 = new System.Windows.Forms.Label();
            this.txtSetAllocQty = new System.Windows.Forms.TextBox();
            this.lblSetAllocQty = new System.Windows.Forms.Label();
            this.txtInQty1 = new System.Windows.Forms.TextBox();
            this.lblInQty1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInventoryInfo.SuspendLayout();
            this.grpInventoryInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).BeginInit();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTransInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInvOper_SelectedItemChanged);
            this.cdvInvOper.ButtonPress += new System.EventHandler(this.cdvInvOper_ButtonPress);
            // 
            // cdvMatID
            // 
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.ButtonPress += new System.EventHandler(this.cdvMatID_ButtonPress);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // lblInvOper
            // 
            this.lblInvOper.AutoSize = true;
            this.lblInvOper.Size = new System.Drawing.Size(91, 13);
            // 
            // lblMatID
            // 
            this.lblMatID.AutoSize = true;
            this.lblMatID.Size = new System.Drawing.Size(52, 13);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTransInfo);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlInventoryInfo, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.grpTransInfo, 0);
            // 
            // grpInventoryInfo
            // 
            this.grpInventoryInfo.AutoSize = true;
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.MaxLength = 30;
            // 
            // lblLastTranTime
            // 
            this.lblLastTranTime.AutoSize = true;
            this.lblLastTranTime.Size = new System.Drawing.Size(78, 13);
            // 
            // lblLastTranCode
            // 
            this.lblLastTranCode.AutoSize = true;
            this.lblLastTranCode.Size = new System.Drawing.Size(80, 13);
            // 
            // lblAllocQty
            // 
            this.lblAllocQty.AutoSize = true;
            this.lblAllocQty.Size = new System.Drawing.Size(49, 13);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.Size = new System.Drawing.Size(23, 13);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvMatVersion
            // 
            this.cdvMatVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.ButtonPress += new System.EventHandler(this.cdvMatVersion_ButtonPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpTranTop
            // 
            this.grpTranTop.AutoSize = true;
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "In Inventory";
            // 
            // grpTransInfo
            // 
            this.grpTransInfo.Controls.Add(this.lblInUnit1);
            this.grpTransInfo.Controls.Add(this.txtSetAllocQty);
            this.grpTransInfo.Controls.Add(this.lblSetAllocQty);
            this.grpTransInfo.Controls.Add(this.txtInQty1);
            this.grpTransInfo.Controls.Add(this.lblInQty1);
            this.grpTransInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTransInfo.Location = new System.Drawing.Point(3, 96);
            this.grpTransInfo.Name = "grpTransInfo";
            this.grpTransInfo.Size = new System.Drawing.Size(722, 279);
            this.grpTransInfo.TabIndex = 1;
            this.grpTransInfo.TabStop = false;
            // 
            // lblInUnit1
            // 
            this.lblInUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInUnit1.Location = new System.Drawing.Point(226, 19);
            this.lblInUnit1.Name = "lblInUnit1";
            this.lblInUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblInUnit1.TabIndex = 2;
            this.lblInUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSetAllocQty
            // 
            this.txtSetAllocQty.Location = new System.Drawing.Point(120, 40);
            this.txtSetAllocQty.MaxLength = 11;
            this.txtSetAllocQty.Name = "txtSetAllocQty";
            this.txtSetAllocQty.ReadOnly = true;
            this.txtSetAllocQty.Size = new System.Drawing.Size(100, 20);
            this.txtSetAllocQty.TabIndex = 4;
            this.txtSetAllocQty.TabStop = false;
            this.txtSetAllocQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSetAllocQty
            // 
            this.lblSetAllocQty.AutoSize = true;
            this.lblSetAllocQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSetAllocQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetAllocQty.Location = new System.Drawing.Point(16, 43);
            this.lblSetAllocQty.Name = "lblSetAllocQty";
            this.lblSetAllocQty.Size = new System.Drawing.Size(49, 13);
            this.lblSetAllocQty.TabIndex = 3;
            this.lblSetAllocQty.Text = "Alloc Qty";
            this.lblSetAllocQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInQty1
            // 
            this.txtInQty1.Location = new System.Drawing.Point(120, 16);
            this.txtInQty1.MaxLength = 11;
            this.txtInQty1.Name = "txtInQty1";
            this.txtInQty1.ReadOnly = true;
            this.txtInQty1.Size = new System.Drawing.Size(100, 20);
            this.txtInQty1.TabIndex = 1;
            this.txtInQty1.TabStop = false;
            this.txtInQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInQty1
            // 
            this.lblInQty1.AutoSize = true;
            this.lblInQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInQty1.Location = new System.Drawing.Point(15, 19);
            this.lblInQty1.Name = "lblInQty1";
            this.lblInQty1.Size = new System.Drawing.Size(41, 13);
            this.lblInQty1.TabIndex = 0;
            this.lblInQty1.Text = "In Qty";
            this.lblInQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmINVTranInInventory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmINVTranInInventory";
            this.Text = "Tran In Store";
            this.Activated += new System.EventHandler(this.frmINVTranInInventory_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlInventoryInfo.ResumeLayout(false);
            this.pnlInventoryInfo.PerformLayout();
            this.grpInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).EndInit();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranTop.PerformLayout();
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTransInfo.ResumeLayout(false);
            this.grpTransInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, cdvMatID, cdvInvOper, cdvMatVersion, null, null, false);
                        if (View_Inventory_Info('1', cdvMatID.Text,MPCF.ToInt(cdvMatVersion.Text), cdvInvOper.Text) == false)
                        {
                            if (cdvMatID.Text == "")
                            {
                                cdvMatID.Focus();
                            }
                            else if (cdvInvOper.Text == "")
                            {
                                cdvInvOper.Focus();
                            }
                            
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
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
                case "IN_Inventory":

                    if (MPCF.CheckValue(cdvMatID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInvOper, 1) == false)
                    {
                        return false;
                    }
                    if (txtInQty1.ReadOnly == false)
                    {
                        if (txtInQty1.Text == "" || txtInQty1.Text == "0")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtInQty1.Focus();
                            return false;
                        }
                    }
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        //
        // View_Inventory_Info()
        //       - Get Inventory Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inventory_Info(char sStep, string sMatID, int iMatVer, string sOper)
        {
            TRSNode in_node = new TRSNode("View_Inventory_Info_In");
            TRSNode out_node = new TRSNode("View_Inventory_Info_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = sStep;
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("OPER", sOper);

                if (MPCR.CallService("INV", "INV_View_Inventory_Info", in_node, ref out_node, true) == false)
                {
                    // INV-0002인 경우는 표시하지 않는다.
                    if (out_node.MsgCode == "INV-0002")
                    {
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                txtQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                txtAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                txtLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                txtLastTranTime.Text =  MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                txtLastHistSeq.Text =  MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        //
        // View_Material_Info()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Material_Info(string sMatID, int iMatVer)
        {
            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT1") != "")
            {
                txtInQty1.ReadOnly = false;
                lblUnit1.Text = out_node.GetString("UNIT1");
                lblInUnit1.Text = out_node.GetString("UNIT1");
            }
            else
            {
                txtInQty1.ReadOnly = true;
                lblUnit1.Text = "";
                lblInUnit1.Text = "";
            }
            
            //'If Trim(View_Material_Out.unit2) <> "" Then
            //'    txtInQty2.ReadOnly = False
            //'    lblUnit2.Text = RTrim(View_Material_Out.unit2)
            //'    lblInUnit2.Text = RTrim(View_Material_Out.unit2)
            //'Else
            //'    txtInQty2.ReadOnly = True
            //'    lblUnit2.Text = ""
            //'    lblInUnit2.Text = ""
            //'End If
            //'If Trim(View_Material_Out.unit3) <> "" Then
            //'    txtInQty3.ReadOnly = False
            //'    lblUnit3.Text = RTrim(View_Material_Out.unit3)
            //'    lblInUnit3.Text = RTrim(View_Material_Out.unit3)
            //'Else
            //'    txtInQty3.ReadOnly = True
            //'    lblUnit3.Text = ""
            //'    lblInUnit3.Text = ""
            //'End If
            
            return true;
            
        }
        
        //
        // In_Inventory()
        //       - Inventory In Inventory
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool In_Inventory(char ProcStep)
        {
            TRSNode in_node = new TRSNode("In_Inventory_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(txtLastHistSeq.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatVersion.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvInvOper.Text));
                in_node.AddDouble("IN_QTY_1", MPCF.ToDbl(txtInQty1.Text));
                in_node.AddDouble("ALLOC_QTY", MPCF.ToDbl(txtSetAllocQty.Text));

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("INV", "INV_In_Inventory", in_node, ref out_node) == false)
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
        
        private void frmINVTranInInventory_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    SetCMFItem(MPGC.MP_CMF_TRN_IN_INV);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvMatVersion.Text = e.SelectedItem.SubItems[1].Text;
            cdvInvOper.Text = "";
            if (MPCF.Trim(cdvMatID.Text) != "")
            {
                View_Material_Info(cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text));
            }

        }
        
        private void cdvInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvInvOper.Text == "")
            {
                return;
            }
            if (cdvMatID.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("IN_Inventory") == false) return;
                if (In_Inventory('1') == false) return;

                ClearData('2');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            ClearData('2');
            
        }
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMatID.Init();
            MPCF.InitListView(cdvMatID.GetListView);
            cdvMatID.Columns.Add("Material", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Version", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvMatID.SelectedSubItemIndex = 0;

            WIPLIST.ViewMaterialList(cdvMatID.GetListView, '1', "", ' ', ' ', "", true, null, "");

        }
        
        private void cdvInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInvOper.Init();
            MPCF.InitListView(cdvInvOper.GetListView);
            cdvInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInvOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvInvOper.GetListView, '6', "", 0, "", "", null, "");            
        }

        private void cdvMatVersion_ButtonPress(object sender, EventArgs e)
        {
            cdvMatVersion.Init();
            MPCF.InitListView(cdvMatVersion.GetListView);
            cdvMatVersion.Columns.Add("Version", 100, HorizontalAlignment.Left);
            cdvMatVersion.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvMatVersion.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialVersionList(cdvMatVersion.GetListView, '1', cdvMatID.Text, "", ' ', ' ', null, "");
        }

    }
    //#End If
}
