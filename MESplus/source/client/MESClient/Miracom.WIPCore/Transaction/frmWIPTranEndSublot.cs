
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranEndSublot.vb
//   Description : End Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetToFlowList() : Get Flow List
//       - GetToOperationList() : Get Operation List
//       - GetRetFlowList() : Get Flow List
//       - GetRetOperationList() : Get Operation List
//       - GetResourceIDList() :Get ResourceID List
//       - End_Sublot() : End Sublot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by WKIM
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
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPTranEndSublot : Miracom.MESCore.TranForm10
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranEndSublot()
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
        



        private System.Windows.Forms.GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRetOperation;
        private System.Windows.Forms.Label lblRetOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOperation;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.Panel pnlResInfo;
        private System.Windows.Forms.GroupBox grpResInfo;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResID;
        private System.Windows.Forms.Label lblSubResource;
        private Miracom.UI.Controls.MCListView.MCListView lisProcOperList;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRetFlow;
        private System.Windows.Forms.ColumnHeader colOper;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder7 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder8 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder4 = new FarPoint.Win.CompoundBorder(bevelBorder7, bevelBorder8);
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.cdvRetFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lisProcOperList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvSubResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResource = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvRetOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRetOper = new System.Windows.Forms.Label();
            this.cdvToOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToOper = new System.Windows.Forms.Label();
            this.pnlResInfo = new System.Windows.Forms.Panel();
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
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
            this.grpComment.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRetOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).BeginInit();
            this.pnlResInfo.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSublotID
            // 
            this.lblSublotID.AutoSize = true;
            this.lblSublotID.Size = new System.Drawing.Size(68, 13);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(-11, 2);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // txtSlotNo
            // 
            this.txtSlotNo.MaxLength = 6;
            // 
            // lblSlotNo
            // 
            this.lblSlotNo.AutoSize = true;
            this.lblSlotNo.Location = new System.Drawing.Point(432, 40);
            this.lblSlotNo.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
            this.pnlTranInfo.Controls.Add(this.pnlResInfo);
            // 
            // pnlComment
            // 
            this.pnlComment.TabIndex = 2;
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
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
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
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm06";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTranInfo.Controls.Add(this.cdvRetFlow);
            this.grpTranInfo.Controls.Add(this.cdvToFlow);
            this.grpTranInfo.Controls.Add(this.lisProcOperList);
            this.grpTranInfo.Controls.Add(this.cdvSubResID);
            this.grpTranInfo.Controls.Add(this.lblSubResource);
            this.grpTranInfo.Controls.Add(this.cdvResID);
            this.grpTranInfo.Controls.Add(this.lblResID);
            this.grpTranInfo.Controls.Add(this.cdvRetOperation);
            this.grpTranInfo.Controls.Add(this.lblRetOper);
            this.grpTranInfo.Controls.Add(this.cdvToOperation);
            this.grpTranInfo.Controls.Add(this.lblToOper);
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(3, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 96);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // cdvRetFlow
            // 
            this.cdvRetFlow.AddEmptyRowToLast = false;
            this.cdvRetFlow.AddEmptyRowToTop = false;
            this.cdvRetFlow.DisplaySubItemIndex = 0;
            this.cdvRetFlow.FlowReadOnly = false;
            this.cdvRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetFlow.LabelText = "Return Flow";
            this.cdvRetFlow.LabelWidth = 106;
            this.cdvRetFlow.ListCond_ExtFactory = "";
            this.cdvRetFlow.ListCond_Step = '1';
            this.cdvRetFlow.Location = new System.Drawing.Point(352, 17);
            this.cdvRetFlow.Name = "cdvRetFlow";
            this.cdvRetFlow.SearchSubItemIndex = 0;
            this.cdvRetFlow.SelectedDescIndex = -1;
            this.cdvRetFlow.SelectedSubItemIndex = 0;
            this.cdvRetFlow.SequenceReadOnly = false;
            this.cdvRetFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvRetFlow.TabIndex = 5;
            this.cdvRetFlow.VisibleColumnHeader = false;
            this.cdvRetFlow.VisibleDescription = false;
            this.cdvRetFlow.VisibleFlowButton = true;
            this.cdvRetFlow.VisibleSequenceButton = true;
            this.cdvRetFlow.WidthButton = 20;
            this.cdvRetFlow.WidthFlowAndSequence = 200;
            this.cdvRetFlow.WidthSequence = 50;
            this.cdvRetFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRetFlow_SelectedItemChanged);
            this.cdvRetFlow.FlowButtonPress += new System.EventHandler(this.cdvRetFlow_ButtonPress);
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.FlowReadOnly = false;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 106;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '1';
            this.cdvToFlow.Location = new System.Drawing.Point(12, 17);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvToFlow.TabIndex = 0;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 200;
            this.cdvToFlow.WidthSequence = 50;
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_FlowButtonPress);
            // 
            // lisProcOperList
            // 
            this.lisProcOperList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lisProcOperList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOper});
            this.lisProcOperList.EnableSort = true;
            this.lisProcOperList.EnableSortIcon = true;
            this.lisProcOperList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisProcOperList.FullRowSelect = true;
            this.lisProcOperList.Location = new System.Drawing.Point(596, 7);
            this.lisProcOperList.Name = "lisProcOperList";
            this.lisProcOperList.Size = new System.Drawing.Size(118, 87);
            this.lisProcOperList.TabIndex = 10;
            this.lisProcOperList.TabStop = false;
            this.lisProcOperList.UseCompatibleStateImageBehavior = false;
            this.lisProcOperList.View = System.Windows.Forms.View.Details;
            this.lisProcOperList.Visible = false;
            // 
            // colOper
            // 
            this.colOper.Text = "Processed Operation";
            this.colOper.Width = 100;
            // 
            // cdvSubResID
            // 
            this.cdvSubResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResID.BtnToolTipText = "";
            this.cdvSubResID.DescText = "";
            this.cdvSubResID.DisplaySubItemIndex = -1;
            this.cdvSubResID.DisplayText = "";
            this.cdvSubResID.Focusing = null;
            this.cdvSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResID.Index = 0;
            this.cdvSubResID.IsViewBtnImage = false;
            this.cdvSubResID.Location = new System.Drawing.Point(458, 66);
            this.cdvSubResID.MaxLength = 20;
            this.cdvSubResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.Name = "cdvSubResID";
            this.cdvSubResID.ReadOnly = false;
            this.cdvSubResID.SearchSubItemIndex = 0;
            this.cdvSubResID.SelectedDescIndex = -1;
            this.cdvSubResID.SelectedSubItemIndex = -1;
            this.cdvSubResID.SelectionStart = 0;
            this.cdvSubResID.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResID.SmallImageList = null;
            this.cdvSubResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResID.TabIndex = 9;
            this.cdvSubResID.TextBoxToolTipText = "";
            this.cdvSubResID.TextBoxWidth = 200;
            this.cdvSubResID.VisibleButton = true;
            this.cdvSubResID.VisibleColumnHeader = false;
            this.cdvSubResID.VisibleDescription = false;
            this.cdvSubResID.ButtonPress += new System.EventHandler(this.cdvSubResID_ButtonPress);
            // 
            // lblSubResource
            // 
            this.lblSubResource.AutoSize = true;
            this.lblSubResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResource.Location = new System.Drawing.Point(352, 68);
            this.lblSubResource.Name = "lblSubResource";
            this.lblSubResource.Size = new System.Drawing.Size(89, 13);
            this.lblSubResource.TabIndex = 8;
            this.lblSubResource.Text = "Sub Resource ID";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(118, 66);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 4;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 70);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 3;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvRetOperation
            // 
            this.cdvRetOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRetOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRetOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRetOperation.BtnToolTipText = "";
            this.cdvRetOperation.DescText = "";
            this.cdvRetOperation.DisplaySubItemIndex = -1;
            this.cdvRetOperation.DisplayText = "";
            this.cdvRetOperation.Focusing = null;
            this.cdvRetOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOperation.Index = 0;
            this.cdvRetOperation.IsViewBtnImage = false;
            this.cdvRetOperation.Location = new System.Drawing.Point(458, 42);
            this.cdvRetOperation.MaxLength = 10;
            this.cdvRetOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRetOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRetOperation.Name = "cdvRetOperation";
            this.cdvRetOperation.ReadOnly = false;
            this.cdvRetOperation.SearchSubItemIndex = 0;
            this.cdvRetOperation.SelectedDescIndex = -1;
            this.cdvRetOperation.SelectedSubItemIndex = -1;
            this.cdvRetOperation.SelectionStart = 0;
            this.cdvRetOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvRetOperation.SmallImageList = null;
            this.cdvRetOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRetOperation.TabIndex = 7;
            this.cdvRetOperation.TextBoxToolTipText = "";
            this.cdvRetOperation.TextBoxWidth = 200;
            this.cdvRetOperation.VisibleButton = true;
            this.cdvRetOperation.VisibleColumnHeader = false;
            this.cdvRetOperation.VisibleDescription = false;
            this.cdvRetOperation.ButtonPress += new System.EventHandler(this.cdvRetOperation_ButtonPress);
            // 
            // lblRetOper
            // 
            this.lblRetOper.AutoSize = true;
            this.lblRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetOper.Location = new System.Drawing.Point(352, 46);
            this.lblRetOper.Name = "lblRetOper";
            this.lblRetOper.Size = new System.Drawing.Size(88, 13);
            this.lblRetOper.TabIndex = 6;
            this.lblRetOper.Text = "Return Operation";
            this.lblRetOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvToOperation
            // 
            this.cdvToOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToOperation.BtnToolTipText = "";
            this.cdvToOperation.DescText = "";
            this.cdvToOperation.DisplaySubItemIndex = -1;
            this.cdvToOperation.DisplayText = "";
            this.cdvToOperation.Focusing = null;
            this.cdvToOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOperation.Index = 0;
            this.cdvToOperation.IsViewBtnImage = false;
            this.cdvToOperation.Location = new System.Drawing.Point(118, 42);
            this.cdvToOperation.MaxLength = 10;
            this.cdvToOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.Name = "cdvToOperation";
            this.cdvToOperation.ReadOnly = false;
            this.cdvToOperation.SearchSubItemIndex = 0;
            this.cdvToOperation.SelectedDescIndex = -1;
            this.cdvToOperation.SelectedSubItemIndex = -1;
            this.cdvToOperation.SelectionStart = 0;
            this.cdvToOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvToOperation.SmallImageList = null;
            this.cdvToOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToOperation.TabIndex = 2;
            this.cdvToOperation.TextBoxToolTipText = "";
            this.cdvToOperation.TextBoxWidth = 200;
            this.cdvToOperation.VisibleButton = true;
            this.cdvToOperation.VisibleColumnHeader = false;
            this.cdvToOperation.VisibleDescription = false;
            this.cdvToOperation.ButtonPress += new System.EventHandler(this.cdvToOperation_ButtonPress);
            // 
            // lblToOper
            // 
            this.lblToOper.AutoSize = true;
            this.lblToOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToOper.Location = new System.Drawing.Point(12, 46);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(69, 13);
            this.lblToOper.TabIndex = 1;
            this.lblToOper.Text = "To Operation";
            this.lblToOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlResInfo
            // 
            this.pnlResInfo.Controls.Add(this.grpResInfo);
            this.pnlResInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResInfo.Location = new System.Drawing.Point(0, 101);
            this.pnlResInfo.Name = "pnlResInfo";
            this.pnlResInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlResInfo.Size = new System.Drawing.Size(728, 130);
            this.pnlResInfo.TabIndex = 1;
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.spdResInfo);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(0, 3);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(728, 127);
            this.grpResInfo.TabIndex = 0;
            this.grpResInfo.TabStop = false;
            this.grpResInfo.Text = "Resource Information";
            // 
            // spdResInfo
            // 
            this.spdResInfo.AccessibleDescription = "";
            this.spdResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResInfo.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdResInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.HorizontalScrollBar.Name = "";
            this.spdResInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdResInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdResInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdResInfo.Location = new System.Drawing.Point(3, 16);
            this.spdResInfo.MoveActiveOnFocus = false;
            this.spdResInfo.Name = "spdResInfo";
            this.spdResInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdResInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdResInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResInfo_LotInfo});
            this.spdResInfo.Size = new System.Drawing.Size(722, 108);
            this.spdResInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResInfo.TabIndex = 0;
            this.spdResInfo.TabStop = false;
            this.spdResInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdResInfo.TextTipDelay = 200;
            this.spdResInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.VerticalScrollBar.Name = "";
            this.spdResInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdResInfo.VerticalScrollBar.TabIndex = 3;
            this.spdResInfo.Resize += new System.EventHandler(this.spdResInfo_Resize);
            // 
            // spdResInfo_LotInfo
            // 
            this.spdResInfo_LotInfo.Reset();
            spdResInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResInfo_LotInfo.ColumnCount = 4;
            spdResInfo_LotInfo.RowCount = 6;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 0).Value = "Up/Down Flag";
            this.spdResInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 2).Value = "Primary Status";
            this.spdResInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdResInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(0).Border = compoundBorder3;
            this.spdResInfo_LotInfo.Columns.Get(0).CellType = textCellType5;
            this.spdResInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Width = 148F;
            this.spdResInfo_LotInfo.Columns.Get(1).CellType = textCellType6;
            this.spdResInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(1).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(1).Width = 199F;
            this.spdResInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(2).Border = compoundBorder4;
            this.spdResInfo_LotInfo.Columns.Get(2).CellType = textCellType7;
            this.spdResInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Width = 148F;
            this.spdResInfo_LotInfo.Columns.Get(3).CellType = textCellType8;
            this.spdResInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(3).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(3).Width = 199F;
            this.spdResInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResInfo_LotInfo.RowHeader.Visible = false;
            this.spdResInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(3).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(4).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdResInfo_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPTranEndSublot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranEndSublot";
            this.Text = "End Sublot";
            this.Activated += new System.EventHandler(this.frmWIPTranEndSublot_Activated);
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
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
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRetOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).EndInit();
            this.pnlResInfo.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "

        // ViewSubLotInfo()
        //       -   View SubLot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewSubLotInfo(string s_sublot_id)
        {
            MPCF.FieldClear(this, txtSublotID);
            if (base.ViewSubLotInfo(s_sublot_id) == false)
            {
                txtSublotID.Focus();
                return false;
            }
            txtLotID.Text = SUBLOT.GetString("LOT_ID");
            txtSlotNo.Text = SUBLOT.GetInt("SLOT_NO").ToString();

            ViewProcOperList();
            GetResourceIDList();

            cdvResID.Text = SUBLOT.GetString("START_RES_ID");
            if (cdvResID.Text != "")
            {
                if (View_Resource() == false)
                {
                    txtSublotID.Focus();
                    return false;
                }
            }
            
            return true;
        }
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                switch (ProcStep)
                {
                    case "1":
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        ClearSubLotSpread();
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
                case "END_SUBLOT":

                    if (MPCF.CheckValue(txtSublotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(SUBLOT.GetString("MAT_ID")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtSublotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(SUBLOT.GetString("FLOW")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                        txtSublotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(SUBLOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtSublotID.Focus();
                        return false;
                    }
                    if (cdvToFlow.Text == "" && cdvToOperation.Text != "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvToFlow.Focus();
                        return false;
                    }
                    //If Trim(cdvToFlow.Text) <> "" And Trim(cdvToOperation.Text) = "" Then
                    //    ShowMsgBox(GetMessage(108))
                    //    tabTran.SelectedTab = tbpgeneral
                    //    cdvToOperation.Focus()
                    //    Return False
                    //End If
                    if (cdvRetFlow.Text == "" && cdvRetOperation.Text != "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRetFlow.Focus();
                        return false;
                    }
                    if (cdvRetFlow.Text != "" && cdvRetOperation.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRetOperation.Focus();
                        return false;
                    }
                    if (cdvRetFlow.Text != "" && cdvRetOperation.Text != "")
                    {
                        if (cdvToFlow.Text == "" || cdvToOperation.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpGeneral;
                            if (cdvToFlow.Text == "")
                            {
                                cdvToFlow.Focus();
                                return false;
                            }
                            if (cdvToOperation.Text == "")
                            {
                                cdvToOperation.Focus();
                                return false;
                            }
                        }
                    }
                    if (cdvResID.Items.Count > 0)
                    {
                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            cdvResID.Focus();
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
        
        // GetToOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetToOperationList(string sFlow)
        {
            
            try
            {
                cdvToOperation.Init();
                MPCF.InitListView(cdvToOperation.GetListView);
                cdvToOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvToOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvToOperation.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvToOperation.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        //
        // GetRetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetRetOperationList(string sFlow)
        {
            
            try
            {
                cdvRetOperation.Init();
                MPCF.InitListView(cdvRetOperation.GetListView);
                cdvRetOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvRetOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRetOperation.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvRetOperation.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        
        //
        // GetResourceIDList()
        //       - Get ResourceID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {
            
            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                #if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, SUBLOT.GetString("MAT_ID"), SUBLOT.GetInt("MAT_VER"), SUBLOT.GetString("FLOW"), SUBLOT.GetString("OPER"), false) == false)
                {
                    return false;
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        private void InitResInfo()
        {
            
            //Initilize spdResInfo
            spdResInfo.Sheets[0].Cells[0, 1].Text = "";
            spdResInfo.Sheets[0].Cells[0, 3].Text = "";
            spdResInfo.Sheets[0].Cells[1, 0].Text = "";
            spdResInfo.Sheets[0].Cells[1, 1].Text = "";
            spdResInfo.Sheets[0].Cells[1, 2].Text = "";
            spdResInfo.Sheets[0].Cells[1, 3].Text = "";
            spdResInfo.Sheets[0].Cells[2, 0].Text = "";
            spdResInfo.Sheets[0].Cells[2, 1].Text = "";
            spdResInfo.Sheets[0].Cells[2, 2].Text = "";
            spdResInfo.Sheets[0].Cells[2, 3].Text = "";
            spdResInfo.Sheets[0].Cells[3, 0].Text = "";
            spdResInfo.Sheets[0].Cells[3, 1].Text = "";
            spdResInfo.Sheets[0].Cells[3, 2].Text = "";
            spdResInfo.Sheets[0].Cells[3, 3].Text = "";
            spdResInfo.Sheets[0].Cells[4, 0].Text = "";
            spdResInfo.Sheets[0].Cells[4, 1].Text = "";
            spdResInfo.Sheets[0].Cells[4, 2].Text = "";
            spdResInfo.Sheets[0].Cells[4, 3].Text = "";
            spdResInfo.Sheets[0].Cells[5, 0].Text = "";
            spdResInfo.Sheets[0].Cells[5, 1].Text = "";
            spdResInfo.Sheets[0].Cells[5, 2].Text = "";
            spdResInfo.Sheets[0].Cells[5, 3].Text = "";
            
        }
        
        private void ViewProcOperList()
        {
            
            WIPLIST.ViewProcessedOperationList(lisProcOperList, '2', txtSublotID.Text, null);
            if (lisProcOperList.Items.Count > 0)
            {
                
                cdvToFlow.Size = new Size(279, 20);
                cdvToOperation.Size = new Size(172, 20);
                cdvResID.Size = new Size(172, 20);
                
                //lblRetFlow.Location = new Point(308, 22);
                lblRetOper.Location = new Point(308, 46);
                lblSubResource.Location = new Point(308, 68);

                cdvRetFlow.Location = new Point(306, 18);
                cdvRetOperation.Location = new Point(414, 42);
                cdvSubResID.Location = new Point(414, 66);
                
                cdvRetFlow.Size = new Size(281, 20);
                cdvRetOperation.Size = new Size(172, 20);
                cdvSubResID.Size = new Size(172, 20);
                
                lisProcOperList.Visible = true;
                
            }
            else
            {
                
                cdvToFlow.Size = new Size(307, 20);
                cdvToOperation.Size = new Size(200, 20);
                cdvResID.Size = new Size(200, 20);
                
                //lblRetFlow.Location = new Point(352, 22);
                lblRetOper.Location = new Point(352, 46);
                lblSubResource.Location = new Point(352, 68);
                
                cdvRetFlow.Location = new Point(349, 18);
                cdvRetOperation.Location = new Point(458, 42);
                cdvSubResID.Location = new Point(458, 66);
                
                cdvRetFlow.Size = new Size(309, 20);
                cdvRetOperation.Size = new Size(200, 20);
                cdvSubResID.Size = new Size(200, 20);
                
                lisProcOperList.Visible = false;
                
            }
            
        }
        
        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Resource()
        {
#if _RAS
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                InitResInfo();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";
                }
                spdResInfo.Sheets[0].Cells[0, 3].Text = out_node.GetString("RES_PRI_STS");

                spdResInfo.Sheets[0].Cells[1, 1].Text = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 3].Text = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 1].Text = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 3].Text = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 1].Text = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 3].Text = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 1].Text = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 3].Text = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 1].Text = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 3].Text = out_node.GetString("RES_STS_10");

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    View_Factory_ResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = out_node.GetString("RES_STS_PRT_1");
                    spdResInfo.Sheets[0].Cells[1, 2].Text = out_node.GetString("RES_STS_PRT_2");
                    spdResInfo.Sheets[0].Cells[2, 0].Text = out_node.GetString("RES_STS_PRT_3");
                    spdResInfo.Sheets[0].Cells[2, 2].Text = out_node.GetString("RES_STS_PRT_4");
                    spdResInfo.Sheets[0].Cells[3, 0].Text = out_node.GetString("RES_STS_PRT_5");
                    spdResInfo.Sheets[0].Cells[3, 2].Text = out_node.GetString("RES_STS_PRT_6");
                    spdResInfo.Sheets[0].Cells[4, 0].Text = out_node.GetString("RES_STS_PRT_7");
                    spdResInfo.Sheets[0].Cells[4, 2].Text = out_node.GetString("RES_STS_PRT_8");
                    spdResInfo.Sheets[0].Cells[5, 0].Text = out_node.GetString("RES_STS_PRT_9");
                    spdResInfo.Sheets[0].Cells[5, 2].Text = out_node.GetString("RES_STS_PRT_10");
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
            return true;

        }

        //
        // View_Factory_ResStatus()
        //       - Get Resource Status Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Factory_ResStatus()
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdResInfo.Sheets[0].Cells[1, 0].Text = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 2].Text = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 0].Text = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 2].Text = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 0].Text = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 2].Text = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 0].Text = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 2].Text = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 0].Text = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 2].Text = out_node.GetString("RES_STS_10");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // End_Sublot()
        //       - End Sublot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool End_Sublot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("END_SUBLOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", SUBLOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
                in_node.AddString("MAT_ID", SUBLOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", SUBLOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", SUBLOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", SUBLOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", SUBLOT.GetString("OPER"));
                in_node.AddDouble("QTY_2", SUBLOT.GetDouble("QTY_2"));
                in_node.AddDouble("QTY_3", SUBLOT.GetDouble("QTY_3"));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOperation.Text));
                in_node.AddString("RET_FLOW", MPCF.Trim(cdvRetFlow.Text));
                in_node.AddString("RET_OPER", MPCF.Trim(cdvRetOperation.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("SUBRES_ID", MPCF.Trim(cdvSubResID.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

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
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("WIP", "WIP_End_Sublot", in_node, ref out_node) == false)
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
        
        private void frmWIPTranEndSublot_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_END);
                    if (txtSublotID.Text != "")
                    {
                        ViewSubLotInfo(txtSublotID.Text);
                    }
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvToFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvToFlow.ListCond_Step = '1';
            cdvToFlow.ListCond_MatID = "";
            cdvToFlow.ListCond_MatVersion = 0;
        }
        
        private void cdvToFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvToOperation.Text = "";
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = SUBLOT.GetString("MAT_ID");
                cdvToFlow.ListCond_MatVersion = SUBLOT.GetInt("MAT_VER");
            }
            
        }

        private void cdvRetFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvRetFlow.ListCond_Step = '1';
            cdvRetFlow.ListCond_MatID = "";
            cdvRetFlow.ListCond_MatVersion = 0;
        }
        
        private void cdvRetFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRetOperation.Text = "";
            if (MPCF.Trim(cdvRetFlow.Text) != "")
            {
                cdvRetFlow.ListCond_Step = '2';
                cdvRetFlow.ListCond_MatID = SUBLOT.GetString("MAT_ID");
                cdvRetFlow.ListCond_MatVersion = SUBLOT.GetInt("MAT_VER");
            }
        }
        
        private void cdvToOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvToFlow.Text.Trim() == "" && SUBLOT.GetString("FLOW").Trim() == "")
            {
                cdvToOperation.Init();
                cdvToOperation.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvToFlow.Focus();
                return;
            }

            if (cdvToFlow.Text.Trim() == "")
            {
                if (GetToOperationList(SUBLOT.GetString("FLOW")) == false)
                {
                    return;
                }
            }
            else
            {
                if (GetToOperationList(cdvToFlow.Text) == false)
                {
                    return;
                }
            }
        }
        
        private void cdvRetOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (cdvRetFlow.CheckValue() == false) return;
            
            if (GetRetOperationList(cdvRetFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("END_SUBLOT") == false) return;
                if (End_Sublot('1') == false) return;

                ViewSubLotInfo(txtSublotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (MPCF.Trim(SUBLOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                txtSublotID.Focus();
                return;
            }
            
        }
        
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvResID.Text != "")
            {
                if (View_Resource() == false)
                {
                    return;
                }
            }
            
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvResID.Text != "")
                {
                    if (View_Resource() == false)
                    {
                        return;
                    }
                }
            }
        }
        
        private void cdvResID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            
            if (cdvResID.Text == "")
            {
                InitResInfo();
            }
            
        }
        
        private void spdResInfo_Resize(System.Object sender, System.EventArgs e)
        {
            
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdResInfo.Width - 716) / 2;
                if (iDiffSize >= 0)
                {
                    spdResInfo.Sheets[0].Columns[1].Width = 199 + iDiffSize;
                    spdResInfo.Sheets[0].Columns[3].Width = 199 + iDiffSize;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvSubResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvSubResID.Init();
            MPCF.InitListView(cdvSubResID.GetListView);
            cdvSubResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvSubResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResID.SelectedSubItemIndex = 0;
            #if _RAS
            RASLIST.ViewSubResourceList(cdvSubResID.GetListView, '5', cdvResID.Text);
            #endif
        }        
        
    }
    
}
