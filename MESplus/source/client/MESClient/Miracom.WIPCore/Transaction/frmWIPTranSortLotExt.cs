
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranSortLotExt.vb
//   Description : Sort Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Lot Information
//       - Sort_Lot() : Sort Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-11 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

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

namespace Miracom.WIPCore
{
    public class frmWIPTranSortLotExt : Miracom.MESCore.TranForm05
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranSortLotExt()
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
        



        private System.Windows.Forms.Panel pnlTranInfoRight;
        private System.Windows.Forms.Panel pnlTranInfoMid;
        private Miracom.UI.Controls.MCListView.MCListView lisSublotList;
        private System.Windows.Forms.Panel pnlTranInfoMidRight;
        private System.Windows.Forms.Panel pnlTranInfoMidMid;
        private System.Windows.Forms.GroupBox grpSortButton;
        private System.Windows.Forms.GroupBox grpLotInfo;
        private System.Windows.Forms.ColumnHeader colSlotNo;
        private System.Windows.Forms.ColumnHeader colSublotID;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtOperDesc;
        private System.Windows.Forms.Label lblOperDesc;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtFlowDesc;
        private System.Windows.Forms.Label lblFlowDesc;
        private System.Windows.Forms.TextBox txtMatDesc;
        private System.Windows.Forms.Label lblMatDesc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private System.Windows.Forms.Label lblCrrID;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.ColumnHeader colCrrID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlTranInfoRight = new System.Windows.Forms.Panel();
            this.lisSublotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlotNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSublotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCrrID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTranInfoMid = new System.Windows.Forms.Panel();
            this.pnlTranInfoMidMid = new System.Windows.Forms.Panel();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtOperDesc = new System.Windows.Forms.TextBox();
            this.lblOperDesc = new System.Windows.Forms.Label();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtFlowDesc = new System.Windows.Forms.TextBox();
            this.lblFlowDesc = new System.Windows.Forms.Label();
            this.txtMatDesc = new System.Windows.Forms.TextBox();
            this.lblMatDesc = new System.Windows.Forms.Label();
            this.pnlTranInfoMidRight = new System.Windows.Forms.Panel();
            this.grpSortButton = new System.Windows.Forms.GroupBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTranInfoRight.SuspendLayout();
            this.pnlTranInfoMid.SuspendLayout();
            this.pnlTranInfoMidMid.SuspendLayout();
            this.grpLotInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.pnlTranInfoMidRight.SuspendLayout();
            this.grpSortButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTran
            // 
            this.pnlTran.Controls.Add(this.pnlTranInfoMid);
            this.pnlTran.Controls.Add(this.pnlTranInfoRight);
            // 
            // grpComment
            // 
            this.grpComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
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
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotID
            // 
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Sort Extension";
            // 
            // pnlTranInfoRight
            // 
            this.pnlTranInfoRight.Controls.Add(this.lisSublotList);
            this.pnlTranInfoRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTranInfoRight.Location = new System.Drawing.Point(430, 0);
            this.pnlTranInfoRight.Name = "pnlTranInfoRight";
            this.pnlTranInfoRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTranInfoRight.Size = new System.Drawing.Size(292, 376);
            this.pnlTranInfoRight.TabIndex = 0;
            // 
            // lisSublotList
            // 
            this.lisSublotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlotNo,
            this.colSublotID,
            this.colCrrID});
            this.lisSublotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSublotList.EnableSort = true;
            this.lisSublotList.EnableSortIcon = true;
            this.lisSublotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSublotList.FullRowSelect = true;
            this.lisSublotList.Location = new System.Drawing.Point(3, 3);
            this.lisSublotList.Name = "lisSublotList";
            this.lisSublotList.Size = new System.Drawing.Size(286, 370);
            this.lisSublotList.TabIndex = 0;
            this.lisSublotList.UseCompatibleStateImageBehavior = false;
            this.lisSublotList.View = System.Windows.Forms.View.Details;
            // 
            // colSlotNo
            // 
            this.colSlotNo.Text = "Slot No";
            this.colSlotNo.Width = 50;
            // 
            // colSublotID
            // 
            this.colSublotID.Text = "Sub Lot ID";
            this.colSublotID.Width = 120;
            // 
            // colCrrID
            // 
            this.colCrrID.Text = "Carrier ID";
            this.colCrrID.Width = 100;
            // 
            // pnlTranInfoMid
            // 
            this.pnlTranInfoMid.Controls.Add(this.pnlTranInfoMidMid);
            this.pnlTranInfoMid.Controls.Add(this.pnlTranInfoMidRight);
            this.pnlTranInfoMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfoMid.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfoMid.Name = "pnlTranInfoMid";
            this.pnlTranInfoMid.Size = new System.Drawing.Size(430, 376);
            this.pnlTranInfoMid.TabIndex = 0;
            // 
            // pnlTranInfoMidMid
            // 
            this.pnlTranInfoMidMid.Controls.Add(this.grpLotInfo);
            this.pnlTranInfoMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfoMidMid.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfoMidMid.Name = "pnlTranInfoMidMid";
            this.pnlTranInfoMidMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTranInfoMidMid.Size = new System.Drawing.Size(342, 376);
            this.pnlTranInfoMidMid.TabIndex = 0;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.cdvFlow);
            this.grpLotInfo.Controls.Add(this.cdvMaterial);
            this.grpLotInfo.Controls.Add(this.cdvCrrID);
            this.grpLotInfo.Controls.Add(this.lblCrrID);
            this.grpLotInfo.Controls.Add(this.txtQty3);
            this.grpLotInfo.Controls.Add(this.txtQty2);
            this.grpLotInfo.Controls.Add(this.txtQty1);
            this.grpLotInfo.Controls.Add(this.lblQty);
            this.grpLotInfo.Controls.Add(this.txtOperDesc);
            this.grpLotInfo.Controls.Add(this.lblOperDesc);
            this.grpLotInfo.Controls.Add(this.txtOper);
            this.grpLotInfo.Controls.Add(this.lblOper);
            this.grpLotInfo.Controls.Add(this.txtFlowDesc);
            this.grpLotInfo.Controls.Add(this.lblFlowDesc);
            this.grpLotInfo.Controls.Add(this.txtMatDesc);
            this.grpLotInfo.Controls.Add(this.lblMatDesc);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotInfo.Location = new System.Drawing.Point(3, 3);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(336, 370);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
            this.grpLotInfo.Text = "Lot Information";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = true;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 95;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(15, 65);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = true;
            this.cdvFlow.Size = new System.Drawing.Size(295, 20);
            this.cdvFlow.TabIndex = 3;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = false;
            this.cdvFlow.VisibleSequenceButton = false;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(15, 17);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(295, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 95;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(110, 186);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 15;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 200;
            this.cdvCrrID.Visible = false;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvCrrID_TextBoxTextChanged);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.Location = new System.Drawing.Point(15, 190);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 14;
            this.lblCrrID.Text = "Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCrrID.Visible = false;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(244, 162);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(66, 20);
            this.txtQty3.TabIndex = 13;
            this.txtQty3.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(177, 162);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(66, 20);
            this.txtQty2.TabIndex = 12;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(110, 162);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(66, 20);
            this.txtQty1.TabIndex = 11;
            this.txtQty1.TabStop = false;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Location = new System.Drawing.Point(15, 166);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(66, 13);
            this.lblQty.TabIndex = 10;
            this.lblQty.Text = "Qty 1 / 2 / 3";
            // 
            // txtOperDesc
            // 
            this.txtOperDesc.Location = new System.Drawing.Point(110, 138);
            this.txtOperDesc.MaxLength = 200;
            this.txtOperDesc.Name = "txtOperDesc";
            this.txtOperDesc.ReadOnly = true;
            this.txtOperDesc.Size = new System.Drawing.Size(200, 20);
            this.txtOperDesc.TabIndex = 9;
            this.txtOperDesc.TabStop = false;
            // 
            // lblOperDesc
            // 
            this.lblOperDesc.AutoSize = true;
            this.lblOperDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperDesc.Location = new System.Drawing.Point(15, 142);
            this.lblOperDesc.Name = "lblOperDesc";
            this.lblOperDesc.Size = new System.Drawing.Size(58, 13);
            this.lblOperDesc.TabIndex = 8;
            this.lblOperDesc.Text = "Oper Desc";
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(110, 114);
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(200, 20);
            this.txtOper.TabIndex = 7;
            this.txtOper.TabStop = false;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 118);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(30, 13);
            this.lblOper.TabIndex = 6;
            this.lblOper.Text = "Oper";
            // 
            // txtFlowDesc
            // 
            this.txtFlowDesc.Location = new System.Drawing.Point(110, 90);
            this.txtFlowDesc.MaxLength = 200;
            this.txtFlowDesc.Name = "txtFlowDesc";
            this.txtFlowDesc.ReadOnly = true;
            this.txtFlowDesc.Size = new System.Drawing.Size(200, 20);
            this.txtFlowDesc.TabIndex = 5;
            this.txtFlowDesc.TabStop = false;
            // 
            // lblFlowDesc
            // 
            this.lblFlowDesc.AutoSize = true;
            this.lblFlowDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlowDesc.Location = new System.Drawing.Point(15, 94);
            this.lblFlowDesc.Name = "lblFlowDesc";
            this.lblFlowDesc.Size = new System.Drawing.Size(57, 13);
            this.lblFlowDesc.TabIndex = 4;
            this.lblFlowDesc.Text = "Flow Desc";
            // 
            // txtMatDesc
            // 
            this.txtMatDesc.Location = new System.Drawing.Point(110, 42);
            this.txtMatDesc.MaxLength = 200;
            this.txtMatDesc.Name = "txtMatDesc";
            this.txtMatDesc.ReadOnly = true;
            this.txtMatDesc.Size = new System.Drawing.Size(200, 20);
            this.txtMatDesc.TabIndex = 2;
            this.txtMatDesc.TabStop = false;
            // 
            // lblMatDesc
            // 
            this.lblMatDesc.AutoSize = true;
            this.lblMatDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatDesc.Location = new System.Drawing.Point(15, 45);
            this.lblMatDesc.Name = "lblMatDesc";
            this.lblMatDesc.Size = new System.Drawing.Size(72, 13);
            this.lblMatDesc.TabIndex = 1;
            this.lblMatDesc.Text = "Material Desc";
            // 
            // pnlTranInfoMidRight
            // 
            this.pnlTranInfoMidRight.Controls.Add(this.grpSortButton);
            this.pnlTranInfoMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTranInfoMidRight.Location = new System.Drawing.Point(342, 0);
            this.pnlTranInfoMidRight.Name = "pnlTranInfoMidRight";
            this.pnlTranInfoMidRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTranInfoMidRight.Size = new System.Drawing.Size(88, 376);
            this.pnlTranInfoMidRight.TabIndex = 1;
            // 
            // grpSortButton
            // 
            this.grpSortButton.Controls.Add(this.btnReverse);
            this.grpSortButton.Controls.Add(this.btnDown);
            this.grpSortButton.Controls.Add(this.btnUp);
            this.grpSortButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSortButton.Location = new System.Drawing.Point(3, 3);
            this.grpSortButton.Name = "grpSortButton";
            this.grpSortButton.Size = new System.Drawing.Size(82, 370);
            this.grpSortButton.TabIndex = 1;
            this.grpSortButton.TabStop = false;
            this.grpSortButton.Text = "Sort Method";
            // 
            // btnReverse
            // 
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReverse.Location = new System.Drawing.Point(7, 84);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(70, 26);
            this.btnReverse.TabIndex = 2;
            this.btnReverse.Text = "REVERSE";
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDown.Location = new System.Drawing.Point(7, 54);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(70, 26);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "DOWN";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUp.Location = new System.Drawing.Point(7, 24);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(70, 26);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "UP";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmWIPTranSortLotExt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranSortLotExt";
            this.Text = "Sort Extension";
            this.Activated += new System.EventHandler(this.frmWIPTranSortLotExt_Activated);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
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
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTranInfoRight.ResumeLayout(false);
            this.pnlTranInfoMid.ResumeLayout(false);
            this.pnlTranInfoMidMid.ResumeLayout(false);
            this.grpLotInfo.ResumeLayout(false);
            this.grpLotInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.pnlTranInfoMidRight.ResumeLayout(false);
            this.grpSortButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        public struct stSublotInfo
        {
            public string sublot_id;
            public int slot_no;
            public string crr_id;
        }
        
        private bool b_load_flag;
        private int iHistSeq;

        public stSublotInfo[] aSubLotList;
        
        #endregion
        
        #region " Function Definition "
        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {
            iHistSeq = 0;
            aSubLotList = new stSublotInfo[1];
            
            switch (iStep)
            {
                case 0:

                    MPCF.FieldClear(this);
                    break;
                case 1:

                    MPCF.FieldClear(this, txtLotID);
                    
                    #if _CRR
                    cdvCrrID.Init();
                    cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
                    cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                    cdvCrrID.SelectedSubItemIndex = 0;
                    if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false)
                    {
                        return;
                    }
                    #endif
                    if (View_Lot_Info() == false)
                    {
                        txtLotID.Focus();
                        return;
                    }
                    break;
            }
        }
        
        // View_Lot_Info()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        private bool View_Lot_Info()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
            cdvMaterial.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            txtMatDesc.Text = MPCF.Trim(out_node.GetString("MAT_DESC"));
            cdvFlow.Text = MPCF.Trim(out_node.GetString("FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            txtFlowDesc.Text = MPCF.Trim(out_node.GetString("FLOW_DESC"));
            txtOper.Text = MPCF.Trim(out_node.GetString("OPER"));
            txtOperDesc.Text = MPCF.Trim(out_node.GetString("OPER_DESC"));

            txtQty1.Text = out_node.GetDouble("QTY_1").ToString();
            txtQty2.Text = out_node.GetDouble("QTY_2").ToString();
            txtQty3.Text = out_node.GetDouble("QTY_3").ToString();

            iHistSeq = out_node.GetInt("LAST_HIST_SEQ");

#if _CRR
            if (cdvCrrID.GetListView.Items.Count < 1)
            {
                if (ViewSublotList(txtLotID.Text) == false)
                {
                    return false;
                }
            }
            else
            {
                if (cdvCrrID.Text == "")
                {
                    if (ViewSublotList(txtLotID.Text) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    colCrrID.Text = "Lot ID";
                    if (RASLIST.ViewCarrierSublotList(lisSublotList, '1', cdvCrrID.Text) == false)
                    {
                        return false;
                    }
                }
            }
#else
            if (ViewSublotList(txtLotID.Text) == false)
            {
                return false;
            }
#endif

            int i;
            aSubLotList = new stSublotInfo[lisSublotList.Items.Count + 1];
            for (i = 0; i <= lisSublotList.Items.Count - 1; i++)
            {
                aSubLotList[i].slot_no = MPCF.ToInt(lisSublotList.Items[i].Text);
                aSubLotList[i].sublot_id = lisSublotList.Items[i].SubItems[1].Text;
                aSubLotList[i].crr_id = lisSublotList.Items[i].SubItems[2].Text;
            }

            return true;

        }

        private bool ViewSublotList(string sLotId)
        {

            int i;
            ListViewItem itm;
            int iCurMaxSlot;
            int iEmpty;
            int i_max_slot_count;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.InitListView(lisSublotList);
            colCrrID.Text = "Carrier ID";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

            iCurMaxSlot = 0;

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if ((out_node.GetList(0)[i].GetInt("SLOT_NO") - iCurMaxSlot) > 1)
                    {
                        for (iEmpty = iCurMaxSlot + 1; iEmpty < out_node.GetList(0)[i].GetInt("SLOT_NO"); iEmpty++)
                        {
                            itm = new ListViewItem(iEmpty.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                            itm.SubItems.Add("");
                            itm.SubItems.Add("");

                            lisSublotList.Items.Add(itm);
                        }
                    }

                    itm = new ListViewItem(out_node.GetList(0)[i].GetInt("SLOT_NO").ToString(), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                    itm.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SUBLOT_ID")));
                    itm.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                    lisSublotList.Items.Add(itm);

                    iCurMaxSlot = out_node.GetList(0)[i].GetInt("SLOT_NO");
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            i_max_slot_count = MPGO.MaxSubLotSlotCount();
            for (i = iCurMaxSlot + 1; i <= i_max_slot_count; i++)
            {
                itm = new ListViewItem(i.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                itm.SubItems.Add("");
                itm.SubItems.Add("");

                lisSublotList.Items.Add(itm);
            }

            return true;

        }

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            return true;
        }

        // Sort_Lot()
        //       -   Sort Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Sort_Lot()
        {
            TRSNode in_node = new TRSNode("SORT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", iHistSeq);
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(txtOper.Text));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("LOT_TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("LOT_TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("LOT_TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("LOT_TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("LOT_TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("LOT_TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("LOT_TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("LOT_TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("LOT_TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("LOT_TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                CompareSortedSlot(ref in_node);
                // 2006.01.09. CM Koo.
                // ë³¢æê²½ëœ?¬ë¡¯???†ìœ¼ë©?Transaction ë°œìƒ?œí‚¤ì§¢æ ?ŠëŠ”??
                if (in_node.GetList(0).Count < 1)
                {
                    return false;
                }

                if (MPCR.CallService("WIP", "WIP_Sort_Lot_Ext", in_node, ref out_node) == false)
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

        
        private void CompareSortedSlot(ref TRSNode sp_in)
        {
            int i;
            int iTo;
            TRSNode sublot_item;
            
            for (i = 0; i <= (aSubLotList.Length - 1) - 1; i++)
            {
                if (MPCF.Trim(aSubLotList[i].sublot_id) != "")
                {
                    iTo = MPCF.FindListItemIndex(lisSublotList, aSubLotList[i].sublot_id, 1, false);
                    if (aSubLotList[i].slot_no != MPCF.ToInt(lisSublotList.Items[iTo].Text))
                    {
                        sublot_item = sp_in.AddNode("SUBLOT");

                        sublot_item.AddInt("SLOT_NO", aSubLotList[i].slot_no);
                        sublot_item.AddInt("TO_SLOT_NO", MPCF.ToInt(lisSublotList.Items[iTo].Text));
                        sublot_item.AddString("SUBLOT_ID", aSubLotList[i].sublot_id);
                    }
                }
            }
        }
        
        #endregion
        
        private void frmWIPTranSortLotExt_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                cdvMaterial.BackColor = SystemColors.Control;
                cdvFlow.BackColor = SystemColors.Control;
                
                #if _CRR
                lblCrrID.Visible = true;
                cdvCrrID.Visible = true;
                #endif
                
                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_SORT);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ClearData(1);
                }
                
                b_load_flag = true;
            }
            
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ClearData(1);
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData(0);
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;
            if (Sort_Lot() == false) return;

            ClearData(1);
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            ClearData(1);
            
        }
        
        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                
                if (lisSublotList.SelectedItems.Count < 1)
                {
                    return;
                }
                
                int i;
                int iNext;
                int iListIndex;
                int iImageIndex;
                string sSublotID;
                string sCrrID;
                
                iNext = 0;
                for (i = 0; i <= lisSublotList.Items.Count - 1; i++)
                {
                    if (lisSublotList.Items[i].Selected == true && lisSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        iListIndex = lisSublotList.Items[i].Index;
                        if (iListIndex > iNext)
                        {
                            sSublotID = lisSublotList.Items[iListIndex].SubItems[1].Text;
                            lisSublotList.Items[iListIndex].SubItems[1].Text = lisSublotList.Items[iListIndex - 1].SubItems[1].Text;
                            lisSublotList.Items[iListIndex - 1].SubItems[1].Text = sSublotID;
                            
                            sCrrID = lisSublotList.Items[iListIndex].SubItems[2].Text;
                            lisSublotList.Items[iListIndex].SubItems[2].Text = lisSublotList.Items[iListIndex - 1].SubItems[2].Text;
                            lisSublotList.Items[iListIndex - 1].SubItems[2].Text = sCrrID;
                            
                            iImageIndex = lisSublotList.Items[iListIndex].ImageIndex;
                            lisSublotList.Items[iListIndex].ImageIndex = lisSublotList.Items[iListIndex - 1].ImageIndex;
                            lisSublotList.Items[iListIndex - 1].ImageIndex = iImageIndex;
                            
                            lisSublotList.Items[iListIndex].Selected = false;
                            lisSublotList.Items[iListIndex - 1].Selected = true;
                        }
                        
                        if (iListIndex == iNext)
                        {
                            iNext++;
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                
                if (lisSublotList.SelectedItems.Count < 1)
                {
                    return;
                }
                
                int i;
                int iNext;
                int iListIndex;
                int iImageIndex;
                string sSublotID;
                string sCrrID;
                
                iNext = lisSublotList.Items.Count - 1;
                for (i = lisSublotList.Items.Count - 1; i >= 0; i--)
                {
                    if (lisSublotList.Items[i].Selected == true && lisSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        iListIndex = lisSublotList.Items[i].Index;
                        if (iListIndex < iNext)
                        {
                            sSublotID = lisSublotList.Items[iListIndex].SubItems[1].Text;
                            lisSublotList.Items[iListIndex].SubItems[1].Text = lisSublotList.Items[iListIndex + 1].SubItems[1].Text;
                            lisSublotList.Items[iListIndex + 1].SubItems[1].Text = sSublotID;
                            
                            sCrrID = lisSublotList.Items[iListIndex].SubItems[2].Text;
                            lisSublotList.Items[iListIndex].SubItems[2].Text = lisSublotList.Items[iListIndex + 1].SubItems[2].Text;
                            lisSublotList.Items[iListIndex + 1].SubItems[2].Text = sCrrID;
                            
                            iImageIndex = lisSublotList.Items[iListIndex].ImageIndex;
                            lisSublotList.Items[iListIndex].ImageIndex = lisSublotList.Items[iListIndex + 1].ImageIndex;
                            lisSublotList.Items[iListIndex + 1].ImageIndex = iImageIndex;
                            
                            lisSublotList.Items[iListIndex].Selected = false;
                            lisSublotList.Items[iListIndex + 1].Selected = true;
                        }
                        
                        if (iListIndex == iNext)
                        {
                            iNext--;
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnReverse_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                
                if (lisSublotList.Items.Count < 1)
                {
                    return;
                }
                
                int i;
                int iLast;
                int iImageIndex;
                string sSublotID;
                string sCrrID;
                
                iLast = lisSublotList.Items.Count - 1;
                for (i = 0; i <= MPCF.ToInt(iLast / 2); i++)
                {
                    sSublotID = lisSublotList.Items[i].SubItems[1].Text;
                    lisSublotList.Items[i].SubItems[1].Text = lisSublotList.Items[iLast - i].SubItems[1].Text;
                    lisSublotList.Items[iLast - i].SubItems[1].Text = sSublotID;
                    
                    sCrrID = lisSublotList.Items[i].SubItems[2].Text;
                    lisSublotList.Items[i].SubItems[2].Text = lisSublotList.Items[iLast - i].SubItems[2].Text;
                    lisSublotList.Items[iLast - i].SubItems[2].Text = sCrrID;
                    
                    iImageIndex = lisSublotList.Items[i].ImageIndex;
                    lisSublotList.Items[i].ImageIndex = lisSublotList.Items[iLast - i].ImageIndex;
                    lisSublotList.Items[iLast - i].ImageIndex = iImageIndex;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }        
            
        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text != "")
            {
                colCrrID.Text = "Lot ID";
                RASLIST.ViewCarrierSublotList(lisSublotList, '1', cdvCrrID.Text);
                
                int i;
                aSubLotList = new stSublotInfo[lisSublotList.Items.Count + 1];
                for (i = 0; i <= lisSublotList.Items.Count - 1; i++)
                {
                    aSubLotList[i].slot_no = MPCF.ToInt(lisSublotList.Items[i].Text);
                    aSubLotList[i].sublot_id = lisSublotList.Items[i].SubItems[1].Text;
                    aSubLotList[i].crr_id = lisSublotList.Items[i].SubItems[2].Text;
                }
            }
#endif //_CRR
        }
        
        private void cdvCrrID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text == "")
            {
                if (ViewSublotList(txtLotID.Text) == false)
                {
                    return;
                }
                
                int i;
                aSubLotList = new stSublotInfo[lisSublotList.Items.Count + 1];
                for (i = 0; i <= lisSublotList.Items.Count - 1; i++)
                {
                    aSubLotList[i].slot_no = MPCF.ToInt(lisSublotList.Items[i].Text);
                    aSubLotList[i].sublot_id = lisSublotList.Items[i].SubItems[1].Text;
                    aSubLotList[i].crr_id = lisSublotList.Items[i].SubItems[2].Text;
                }
            }    
#endif //_CRR        
        }
    }    
}
