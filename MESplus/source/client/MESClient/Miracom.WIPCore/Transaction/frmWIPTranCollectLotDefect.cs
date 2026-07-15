
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCollectLotDefect.vb
//   Description : Collect Lot Defect
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

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
    public class frmWIPTranCollectLotDefect : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranCollectLotDefect()
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
        



        private System.Windows.Forms.TabPage tbpDefect;
        private System.Windows.Forms.GroupBox grpLoss;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private System.Windows.Forms.Label lblCauseRes;
        private System.Windows.Forms.Label lblCauseOper;
        private System.Windows.Forms.Label lblCauseFlow;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblUser2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblAttachFile1;
        private System.Windows.Forms.TextBox txtAttachFile1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtAttachFile5;
        private System.Windows.Forms.TextBox txtAttachFile4;
        private System.Windows.Forms.TextBox txtAttachFile3;
        private System.Windows.Forms.TextBox txtAttachFile2;
        protected FarPoint.Win.Spread.FpSpread spdDefectData;
        protected FarPoint.Win.Spread.SheetView spdDefectData_LotInfo;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDefect;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvSublotID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.tbpDefect = new System.Windows.Forms.TabPage();
            this.spdDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdDefectData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpLoss = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtAttachFile5 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtAttachFile4 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtAttachFile3 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtAttachFile2 = new System.Windows.Forms.TextBox();
            this.lblAttachFile1 = new System.Windows.Forms.Label();
            this.txtAttachFile1 = new System.Windows.Forms.TextBox();
            this.cdvCauseRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.txtChkUser2 = new System.Windows.Forms.TextBox();
            this.txtChkUser1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvDefect = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvSublotID = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
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
            this.tbpDefect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).BeginInit();
            this.grpLoss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSublotID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpLoss);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 415);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 376);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 379);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // txtComment
            // 
            this.txtComment.TabIndex = 11;
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
            // txtTranDateTime
            // 
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 2);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpDefect);
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpDefect, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
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
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Collect Lot Defect";
            // 
            // tbpDefect
            // 
            this.tbpDefect.Controls.Add(this.spdDefectData);
            this.tbpDefect.Location = new System.Drawing.Point(4, 22);
            this.tbpDefect.Name = "tbpDefect";
            this.tbpDefect.Size = new System.Drawing.Size(728, 422);
            this.tbpDefect.TabIndex = 2;
            this.tbpDefect.Text = "Defect";
            // 
            // spdDefectData
            // 
            this.spdDefectData.AccessibleDescription = "";
            this.spdDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefectData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDefectData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.HorizontalScrollBar.Name = "";
            this.spdDefectData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdDefectData.HorizontalScrollBar.TabIndex = 2;
            this.spdDefectData.Location = new System.Drawing.Point(0, 0);
            this.spdDefectData.MoveActiveOnFocus = false;
            this.spdDefectData.Name = "spdDefectData";
            this.spdDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefectData_LotInfo});
            this.spdDefectData.Size = new System.Drawing.Size(728, 422);
            this.spdDefectData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDefectData.TabIndex = 1;
            this.spdDefectData.TabStop = false;
            this.spdDefectData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdDefectData.TextTipDelay = 200;
            this.spdDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefectData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.VerticalScrollBar.Name = "";
            this.spdDefectData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdDefectData.VerticalScrollBar.TabIndex = 3;
            this.spdDefectData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDefectData_ButtonClicked);
            // 
            // spdDefectData_LotInfo
            // 
            this.spdDefectData_LotInfo.Reset();
            spdDefectData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefectData_LotInfo.ColumnCount = 11;
            spdDefectData_LotInfo.RowCount = 1000;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).Value = "Defect Code";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "...";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Sub Lot ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 4).Value = "Count";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Loc X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Loc Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Loc Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 8).Value = "Cell X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 9).Value = "Cell Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 10).Value = "Cell Z";
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.Columns.Get(0).BackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(0).Label = "Defect Code";
            this.spdDefectData_LotInfo.Columns.Get(0).Locked = false;
            this.spdDefectData_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(0).Width = 114F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdDefectData_LotInfo.Columns.Get(1).CellType = buttonCellType1;
            this.spdDefectData_LotInfo.Columns.Get(1).Label = "...";
            this.spdDefectData_LotInfo.Columns.Get(1).Locked = false;
            this.spdDefectData_LotInfo.Columns.Get(1).Resizable = false;
            this.spdDefectData_LotInfo.Columns.Get(1).Width = 25F;
            this.spdDefectData_LotInfo.Columns.Get(2).Label = "Sub Lot ID";
            this.spdDefectData_LotInfo.Columns.Get(2).Width = 156F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdDefectData_LotInfo.Columns.Get(3).CellType = buttonCellType2;
            this.spdDefectData_LotInfo.Columns.Get(3).Width = 28F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(4).CellType = numberCellType1;
            this.spdDefectData_LotInfo.Columns.Get(4).Label = "Count";
            this.spdDefectData_LotInfo.Columns.Get(4).Width = 52F;
            this.spdDefectData_LotInfo.Columns.Get(5).CellType = numberCellType2;
            this.spdDefectData_LotInfo.Columns.Get(5).Label = "Loc X";
            this.spdDefectData_LotInfo.Columns.Get(5).Width = 54F;
            this.spdDefectData_LotInfo.Columns.Get(6).CellType = numberCellType3;
            this.spdDefectData_LotInfo.Columns.Get(6).Label = "Loc Y";
            this.spdDefectData_LotInfo.Columns.Get(6).Width = 53F;
            this.spdDefectData_LotInfo.Columns.Get(7).CellType = numberCellType4;
            this.spdDefectData_LotInfo.Columns.Get(7).Label = "Loc Z";
            this.spdDefectData_LotInfo.Columns.Get(7).Width = 52F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 9999999D;
            numberCellType5.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(8).CellType = numberCellType5;
            this.spdDefectData_LotInfo.Columns.Get(8).Label = "Cell X";
            this.spdDefectData_LotInfo.Columns.Get(8).Width = 56F;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 9999999D;
            numberCellType6.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(9).CellType = numberCellType6;
            this.spdDefectData_LotInfo.Columns.Get(9).Label = "Cell Y";
            this.spdDefectData_LotInfo.Columns.Get(9).Width = 55F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999999D;
            numberCellType7.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(10).CellType = numberCellType7;
            this.spdDefectData_LotInfo.Columns.Get(10).Label = "Cell Z";
            this.spdDefectData_LotInfo.Columns.Get(10).Width = 52F;
            this.spdDefectData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.RowHeader.Columns.Default.Resizable = true;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDefectData_LotInfo.RowHeader.Visible = false;
            this.spdDefectData_LotInfo.Rows.Default.Height = 17F;
            this.spdDefectData_LotInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefectData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpLoss
            // 
            this.grpLoss.Controls.Add(this.Label4);
            this.grpLoss.Controls.Add(this.txtAttachFile5);
            this.grpLoss.Controls.Add(this.Label3);
            this.grpLoss.Controls.Add(this.txtAttachFile4);
            this.grpLoss.Controls.Add(this.Label2);
            this.grpLoss.Controls.Add(this.txtAttachFile3);
            this.grpLoss.Controls.Add(this.Label1);
            this.grpLoss.Controls.Add(this.txtAttachFile2);
            this.grpLoss.Controls.Add(this.lblAttachFile1);
            this.grpLoss.Controls.Add(this.txtAttachFile1);
            this.grpLoss.Controls.Add(this.cdvCauseRes);
            this.grpLoss.Controls.Add(this.cdvCauseOper);
            this.grpLoss.Controls.Add(this.cdvCauseFlow);
            this.grpLoss.Controls.Add(this.lblCauseRes);
            this.grpLoss.Controls.Add(this.lblCauseOper);
            this.grpLoss.Controls.Add(this.lblCauseFlow);
            this.grpLoss.Controls.Add(this.txtChkUser2);
            this.grpLoss.Controls.Add(this.txtChkUser1);
            this.grpLoss.Controls.Add(this.lblUser1);
            this.grpLoss.Controls.Add(this.lblUser2);
            this.grpLoss.Controls.Add(this.cdvResID);
            this.grpLoss.Controls.Add(this.lblResID);
            this.grpLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLoss.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLoss.Location = new System.Drawing.Point(0, 0);
            this.grpLoss.Name = "grpLoss";
            this.grpLoss.Size = new System.Drawing.Size(722, 235);
            this.grpLoss.TabIndex = 1;
            this.grpLoss.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(14, 204);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(97, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Attach File Name 5";
            // 
            // txtAttachFile5
            // 
            this.txtAttachFile5.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile5.Location = new System.Drawing.Point(116, 202);
            this.txtAttachFile5.MaxLength = 100;
            this.txtAttachFile5.Name = "txtAttachFile5";
            this.txtAttachFile5.Size = new System.Drawing.Size(204, 20);
            this.txtAttachFile5.TabIndex = 21;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(354, 178);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(97, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Attach File Name 4";
            // 
            // txtAttachFile4
            // 
            this.txtAttachFile4.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile4.Location = new System.Drawing.Point(460, 174);
            this.txtAttachFile4.MaxLength = 100;
            this.txtAttachFile4.Name = "txtAttachFile4";
            this.txtAttachFile4.Size = new System.Drawing.Size(204, 20);
            this.txtAttachFile4.TabIndex = 19;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(14, 178);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(97, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Attach File Name 3";
            // 
            // txtAttachFile3
            // 
            this.txtAttachFile3.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile3.Location = new System.Drawing.Point(116, 176);
            this.txtAttachFile3.MaxLength = 100;
            this.txtAttachFile3.Name = "txtAttachFile3";
            this.txtAttachFile3.Size = new System.Drawing.Size(204, 20);
            this.txtAttachFile3.TabIndex = 17;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(354, 152);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Attach File Name 2";
            // 
            // txtAttachFile2
            // 
            this.txtAttachFile2.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile2.Location = new System.Drawing.Point(460, 150);
            this.txtAttachFile2.MaxLength = 100;
            this.txtAttachFile2.Name = "txtAttachFile2";
            this.txtAttachFile2.Size = new System.Drawing.Size(204, 20);
            this.txtAttachFile2.TabIndex = 15;
            // 
            // lblAttachFile1
            // 
            this.lblAttachFile1.AutoSize = true;
            this.lblAttachFile1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachFile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachFile1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttachFile1.Location = new System.Drawing.Point(14, 154);
            this.lblAttachFile1.Name = "lblAttachFile1";
            this.lblAttachFile1.Size = new System.Drawing.Size(97, 13);
            this.lblAttachFile1.TabIndex = 12;
            this.lblAttachFile1.Text = "Attach File Name 1";
            // 
            // txtAttachFile1
            // 
            this.txtAttachFile1.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile1.Location = new System.Drawing.Point(116, 152);
            this.txtAttachFile1.MaxLength = 100;
            this.txtAttachFile1.Name = "txtAttachFile1";
            this.txtAttachFile1.Size = new System.Drawing.Size(204, 20);
            this.txtAttachFile1.TabIndex = 13;
            // 
            // cdvCauseRes
            // 
            this.cdvCauseRes.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseRes.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseRes.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseRes.BtnToolTipText = "";
            this.cdvCauseRes.DescText = "";
            this.cdvCauseRes.DisplaySubItemIndex = -1;
            this.cdvCauseRes.DisplayText = "";
            this.cdvCauseRes.Focusing = null;
            this.cdvCauseRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseRes.Index = 0;
            this.cdvCauseRes.IsViewBtnImage = false;
            this.cdvCauseRes.Location = new System.Drawing.Point(458, 64);
            this.cdvCauseRes.MaxLength = 20;
            this.cdvCauseRes.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.Name = "cdvCauseRes";
            this.cdvCauseRes.ReadOnly = false;
            this.cdvCauseRes.SearchSubItemIndex = 0;
            this.cdvCauseRes.SelectedDescIndex = -1;
            this.cdvCauseRes.SelectedSubItemIndex = -1;
            this.cdvCauseRes.SelectionStart = 0;
            this.cdvCauseRes.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseRes.SmallImageList = null;
            this.cdvCauseRes.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseRes.TabIndex = 11;
            this.cdvCauseRes.TextBoxToolTipText = "";
            this.cdvCauseRes.TextBoxWidth = 200;
            this.cdvCauseRes.VisibleButton = true;
            this.cdvCauseRes.VisibleColumnHeader = false;
            this.cdvCauseRes.VisibleDescription = false;
            this.cdvCauseRes.ButtonPress += new System.EventHandler(this.cdvCauseRes_ButtonPress);
            // 
            // cdvCauseOper
            // 
            this.cdvCauseOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseOper.BtnToolTipText = "";
            this.cdvCauseOper.DescText = "";
            this.cdvCauseOper.DisplaySubItemIndex = -1;
            this.cdvCauseOper.DisplayText = "";
            this.cdvCauseOper.Focusing = null;
            this.cdvCauseOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseOper.Index = 0;
            this.cdvCauseOper.IsViewBtnImage = false;
            this.cdvCauseOper.Location = new System.Drawing.Point(458, 40);
            this.cdvCauseOper.MaxLength = 10;
            this.cdvCauseOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.Name = "cdvCauseOper";
            this.cdvCauseOper.ReadOnly = false;
            this.cdvCauseOper.SearchSubItemIndex = 0;
            this.cdvCauseOper.SelectedDescIndex = -1;
            this.cdvCauseOper.SelectedSubItemIndex = -1;
            this.cdvCauseOper.SelectionStart = 0;
            this.cdvCauseOper.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseOper.SmallImageList = null;
            this.cdvCauseOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseOper.TabIndex = 9;
            this.cdvCauseOper.TextBoxToolTipText = "";
            this.cdvCauseOper.TextBoxWidth = 200;
            this.cdvCauseOper.VisibleButton = true;
            this.cdvCauseOper.VisibleColumnHeader = false;
            this.cdvCauseOper.VisibleDescription = false;
            this.cdvCauseOper.ButtonPress += new System.EventHandler(this.cdvCauseOper_ButtonPress);
            // 
            // cdvCauseFlow
            // 
            this.cdvCauseFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseFlow.BtnToolTipText = "";
            this.cdvCauseFlow.DescText = "";
            this.cdvCauseFlow.DisplaySubItemIndex = -1;
            this.cdvCauseFlow.DisplayText = "";
            this.cdvCauseFlow.Focusing = null;
            this.cdvCauseFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseFlow.Index = 0;
            this.cdvCauseFlow.IsViewBtnImage = false;
            this.cdvCauseFlow.Location = new System.Drawing.Point(458, 16);
            this.cdvCauseFlow.MaxLength = 20;
            this.cdvCauseFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.Name = "cdvCauseFlow";
            this.cdvCauseFlow.ReadOnly = false;
            this.cdvCauseFlow.SearchSubItemIndex = 0;
            this.cdvCauseFlow.SelectedDescIndex = -1;
            this.cdvCauseFlow.SelectedSubItemIndex = -1;
            this.cdvCauseFlow.SelectionStart = 0;
            this.cdvCauseFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseFlow.SmallImageList = null;
            this.cdvCauseFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseFlow.TabIndex = 7;
            this.cdvCauseFlow.TextBoxToolTipText = "";
            this.cdvCauseFlow.TextBoxWidth = 200;
            this.cdvCauseFlow.VisibleButton = true;
            this.cdvCauseFlow.VisibleColumnHeader = false;
            this.cdvCauseFlow.VisibleDescription = false;
            this.cdvCauseFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCauseFlow_SelectedItemChanged);
            this.cdvCauseFlow.ButtonPress += new System.EventHandler(this.cdvCauseFlow_ButtonPress);
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.AutoSize = true;
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Location = new System.Drawing.Point(352, 67);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(86, 13);
            this.lblCauseRes.TabIndex = 10;
            this.lblCauseRes.Text = "Cause Resource";
            this.lblCauseRes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseOper
            // 
            this.lblCauseOper.AutoSize = true;
            this.lblCauseOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseOper.Location = new System.Drawing.Point(352, 43);
            this.lblCauseOper.Name = "lblCauseOper";
            this.lblCauseOper.Size = new System.Drawing.Size(86, 13);
            this.lblCauseOper.TabIndex = 8;
            this.lblCauseOper.Text = "Cause Operation";
            this.lblCauseOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.AutoSize = true;
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Location = new System.Drawing.Point(352, 19);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(62, 13);
            this.lblCauseFlow.TabIndex = 6;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtChkUser2
            // 
            this.txtChkUser2.Location = new System.Drawing.Point(118, 64);
            this.txtChkUser2.MaxLength = 20;
            this.txtChkUser2.Name = "txtChkUser2";
            this.txtChkUser2.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser2.TabIndex = 5;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(118, 40);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser1.TabIndex = 3;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser1.Location = new System.Drawing.Point(12, 42);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(86, 13);
            this.lblUser1.TabIndex = 2;
            this.lblUser1.Text = "Check User ID 1";
            this.lblUser1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser2.Location = new System.Drawing.Point(12, 66);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(86, 13);
            this.lblUser2.TabIndex = 4;
            this.lblUser2.Text = "Check User ID 2";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 16);
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
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(12, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvDefect
            // 
            this.cdvDefect.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDefect.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvDefect.Location = new System.Drawing.Point(194, 17);
            this.cdvDefect.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Name = "cdvDefect";
            this.cdvDefect.Size = new System.Drawing.Size(20, 20);
            this.cdvDefect.SmallImageList = null;
            this.cdvDefect.TabIndex = 0;
            this.cdvDefect.TabStop = false;
            this.cdvDefect.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDefect.Visible = false;
            this.cdvDefect.VisibleColumnHeader = false;
            this.cdvDefect.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDefect_SelectedItemChanged);
            // 
            // cdvSublotID
            // 
            this.cdvSublotID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvSublotID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSublotID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSublotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvSublotID.Location = new System.Drawing.Point(299, 17);
            this.cdvSublotID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSublotID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSublotID.Name = "cdvSublotID";
            this.cdvSublotID.Size = new System.Drawing.Size(20, 20);
            this.cdvSublotID.SmallImageList = null;
            this.cdvSublotID.TabIndex = 0;
            this.cdvSublotID.TabStop = false;
            this.cdvSublotID.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvSublotID.Visible = false;
            this.cdvSublotID.VisibleColumnHeader = false;
            this.cdvSublotID.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvSublotID_SelectedItemChanged);
            // 
            // frmWIPTranCollectLotDefect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranCollectLotDefect";
            this.Text = "Collect Lot Defect";
            this.Activated += new System.EventHandler(this.frmWIPTranCollectLotDefect_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
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
            this.tbpDefect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).EndInit();
            this.grpLoss.ResumeLayout(false);
            this.grpLoss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSublotID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdDefectData);

                    spdDefectData.SuspendLayout();
                    spdDefectData.Sheets[0].RowCount = 1000;
                    spdDefectData.ResumeLayout();

                    MPCF.FieldClear(this);
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
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string ProcStep)
        {
            int i;

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            for (i = 0; i < spdDefectData.Sheets[0].RowCount; i++)
            {
                if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 0)) == "" && MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 2)) != "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    tabTran.SelectedTab = tbpDefect;
                    spdDefectData.Sheets[0].SetActiveCell(i, 0);
                    spdDefectData.Focus();
                    return false;
                }
            }

            
            return true;
            
        }

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
            spdDefectData.Sheets[0].RowCount = 0;
            spdDefectData.Sheets[0].RowCount = 1000;

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            return true;
        }


        private bool ViewSublotList(ListView control, string sLotId)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("View_Sublot_List_In");
            TRSNode out_node = new TRSNode("View_Sublot_List_Out");

            MPCF.InitListView(control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SUBLOT_ID"), (int)SMALLICON_INDEX.IDX_SLOT_FULL);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("SLOT_NO").ToString());
                    control.Items.Add(itmX);

                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            return true;

        }

        
        //
        // GetFlowList()
        //       - Get Flow List by Material
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal cdvList As MCCodeView.MCCodeView : Flow List
        //
        private bool GetFlowList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewFlowList(cdvList.GetListView, '1', "",0, "", null, "") == false)
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
        // GetOperationList()
        //       - Get Operation List by Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow
        //
        private bool GetOperationList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList, string sFlow)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvList.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        // Collect_Lot_Defect()
        //       - Collect Defect Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Collect_Lot_Defect(char ProcStep)
        {

            int i = 0;

            TRSNode in_node = new TRSNode("Collect_Lot_Defect_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("DEFECT_COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("CHK_USER_ID_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHK_USER_ID_2", MPCF.Trim(txtChkUser2.Text), true);
                in_node.AddString("ATTACH_FILE_1", MPCF.Trim(txtAttachFile1.Text));
                in_node.AddString("ATTACH_FILE_2", MPCF.Trim(txtAttachFile2.Text));
                in_node.AddString("ATTACH_FILE_3", MPCF.Trim(txtAttachFile3.Text));
                in_node.AddString("ATTACH_FILE_4", MPCF.Trim(txtAttachFile4.Text));
                in_node.AddString("ATTACH_FILE_5", MPCF.Trim(txtAttachFile5.Text));

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

                for (i = 0; i <= spdDefectData.Sheets[0].RowCount - 1; i++)
                {
                    if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 0)) != "")
                    {
                        list_item = in_node.AddNode("DATA_LIST");

                        list_item.AddString("DEFECT_CODE", MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 0)));
                        list_item.AddString("SUBLOT_ID", MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 2)));

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 4)) == "")
                        {
                            list_item.AddDouble("DEFECT_QTY", 1);
                        }
                        else
                        {
                            list_item.AddDouble("DEFECT_QTY", MPCF.ToDbl(spdDefectData.Sheets[0].GetValue(i, 4)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 5)) == "")
                        {
                            list_item.AddDouble("LOC_X", 0);
                        }
                        else
                        {
                            list_item.AddDouble("LOC_X", MPCF.ToDbl(spdDefectData.Sheets[0].GetValue(i, 5)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 6)) == "")
                        {
                            list_item.AddDouble("LOC_Y", 0);
                        }
                        else
                        {
                            list_item.AddDouble("LOC_Y", MPCF.ToDbl(spdDefectData.Sheets[0].GetValue(i, 6)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 7)) == "")
                        {
                            list_item.AddDouble("LOC_Z", 0);
                        }
                        else
                        {
                            list_item.AddDouble("LOC_Z", MPCF.ToDbl(spdDefectData.Sheets[0].GetValue(i, 7)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 8)) == "")
                        {
                            list_item.AddInt("CELL_X", 0);
                        }
                        else
                        {
                            list_item.AddInt("CELL_X", MPCF.ToInt(spdDefectData.Sheets[0].GetValue(i, 8)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 9)) == "")
                        {
                            list_item.AddInt("CELL_Y", 0);
                        }
                        else
                        {
                            list_item.AddInt("CELL_Y", MPCF.ToInt(spdDefectData.Sheets[0].GetValue(i, 9)));
                        }

                        if (MPCF.Trim(spdDefectData.Sheets[0].GetValue(i, 10)) == "")
                        {
                            list_item.AddInt("CELL_Z", 0);
                        }
                        else
                        {
                            list_item.AddInt("CELL_Z", MPCF.ToInt(spdDefectData.Sheets[0].GetValue(i, 10)));
                        }
                    }

                }

                if (MPCR.CallService("WIP", "WIP_Collect_Lot_Defect", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        
        
        #endregion
        
        private void frmWIPTranCollectLotDefect_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_COLLECT_LOT_DEFECT);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdDefectData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_lot_defect_table;

            try
            {
                if (txtLotID.Text == "")
                {
                    return;
                }
                
                if (e.Column == 1)
                {
                    cdvDefect.Init();
                    cdvDefect.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDefect.GetListView);
                    cdvDefect.Columns.Add("Defect", 50, HorizontalAlignment.Left);
                    cdvDefect.Columns.Add("Desc", 200, HorizontalAlignment.Left);

                    s_lot_defect_table = "";
                    s_lot_defect_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOT_DEFECT_TBL);
                    if (s_lot_defect_table == "")
                    {
                        s_lot_defect_table = MPGC.MP_WIP_LOT_DEFECT_CODE;
                    }

                    if (BASLIST.ViewGCMDataList(cdvDefect.GetListView, '1', s_lot_defect_table) == false)
                    {
                        return;
                    }
                    
                    if (cdvDefect.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == 3)
                {
                    cdvSublotID.Init();
                    cdvSublotID.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvSublotID.GetListView);
                    cdvSublotID.Columns.Add("Sub Lot ID", 50, HorizontalAlignment.Left);
                    cdvSublotID.Columns.Add("Slot No", 200, HorizontalAlignment.Left);
                    if (ViewSublotList(cdvSublotID.GetListView, txtLotID.Text) == false)
                    {
                        return;
                    }
                    
                    if (cdvSublotID.ShowPopupList(e.Row, e.Column) == false)
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
        
        
        private void cdvDefect_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "")
                {
                    return;
                }
                
                spdDefectData.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvSublotID_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "")
                {
                    return;
                }
                
                spdDefectData.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        

        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData("1");
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("1") == false) return;
            if (Collect_Lot_Defect('1') == false) return;

            ViewLotInfo(txtLotID.Text);            
        }
        
        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                return;
            }
            
            if (GetFlowList(cdvCauseFlow) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvCauseOper.Text = "";
            
        }
        
        private void cdvCauseOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                return;
            }
            if (cdvCauseFlow.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvCauseFlow.Focus();
                return;
            }
            
            if (GetOperationList(cdvCauseOper, cdvCauseFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (cdvCauseOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvCauseOper.Focus();
                return;
            }

            cdvCauseRes.Init();
            MPCF.InitListView(cdvCauseRes.GetListView);
            cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCauseRes.SelectedSubItemIndex = 0;
#if _RAS
            if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
            {
                return;
            }
#endif
            
        }
        
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }

            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
#if _RAS
            if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
            {
                return;
            }
#endif
            
        }
    }
    
}
