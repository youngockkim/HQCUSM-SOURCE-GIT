
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranScribeLotExt.vb
//   Description : Scribe Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Operation() : View Operation Information
//       - Scribe_Lot() : Scribe Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-11 : Created by CM Koo
//       - 2008-01-21 : Added by W.Y Choi
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
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPTranScribeLotExt : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranScribeLotExt()
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.GroupBox grpScribe;
        private System.Windows.Forms.Panel pnlUnitTop;
        private System.Windows.Forms.GroupBox grpQty;
        private System.Windows.Forms.TextBox txtOutQty2;
        private System.Windows.Forms.TextBox txtOutQty1;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblOutQty2;
        private System.Windows.Forms.Label lblOutQty1;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Panel pnlUnitMid;
        private System.Windows.Forms.GroupBox grpUnit1;
        private FarPoint.Win.Spread.FpSpread spdSublotScribe;
        private FarPoint.Win.Spread.SheetView spdSublotScribe_Sheet1;
        private System.Windows.Forms.TabPage tbpInfo;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvScribeCode;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvGrade;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private Splitter splUnit;
        private System.Windows.Forms.Label lblCrrID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer6 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer6 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.grpScribe = new System.Windows.Forms.GroupBox();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.pnlUnitMid = new System.Windows.Forms.Panel();
            this.grpUnit1 = new System.Windows.Forms.GroupBox();
            this.spdSublotScribe = new FarPoint.Win.Spread.FpSpread();
            this.spdSublotScribe_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splUnit = new System.Windows.Forms.Splitter();
            this.pnlUnitTop = new System.Windows.Forms.Panel();
            this.grpQty = new System.Windows.Forms.GroupBox();
            this.txtOutQty2 = new System.Windows.Forms.TextBox();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty2 = new System.Windows.Forms.Label();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvScribeCode = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvGrade = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
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
            this.grpScribe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.tbpInfo.SuspendLayout();
            this.pnlUnitMid.SuspendLayout();
            this.grpUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotScribe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotScribe_Sheet1)).BeginInit();
            this.pnlUnitTop.SuspendLayout();
            this.grpQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvScribeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpScribe);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 236);
            this.pnlTranInfo.TabIndex = 1;
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
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 377);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 380);
            this.pnlComment.Size = new System.Drawing.Size(722, 42);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // grpComment
            // 
            this.grpComment.Size = new System.Drawing.Size(722, 42);
            // 
            // txtComment
            // 
            this.txtComment.Size = new System.Drawing.Size(596, 20);
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
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpInfo);
            this.tabTran.Controls.SetChildIndex(this.tbpInfo, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
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
            this.lblFormTitle.Text = "Scribe Lot";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            columnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer6.Name = "columnHeaderRenderer6";
            columnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer6.TextRotationAngle = 0D;
            rowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer6.Name = "rowHeaderRenderer6";
            rowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer6.TextRotationAngle = 0D;
            // 
            // grpScribe
            // 
            this.grpScribe.Controls.Add(this.cdvCrrID);
            this.grpScribe.Controls.Add(this.lblCrrID);
            this.grpScribe.Controls.Add(this.cdvResID);
            this.grpScribe.Controls.Add(this.lblResID);
            this.grpScribe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScribe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpScribe.Location = new System.Drawing.Point(0, 0);
            this.grpScribe.Name = "grpScribe";
            this.grpScribe.Size = new System.Drawing.Size(722, 236);
            this.grpScribe.TabIndex = 0;
            this.grpScribe.TabStop = false;
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
            this.cdvCrrID.Enabled = false;
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(118, 42);
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
            this.cdvCrrID.TabIndex = 16;
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
            this.lblCrrID.Location = new System.Drawing.Point(12, 42);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 15;
            this.lblCrrID.Text = "Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCrrID.Visible = false;
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
            this.cdvResID.Enabled = false;
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
            // tbpInfo
            // 
            this.tbpInfo.Controls.Add(this.pnlUnitMid);
            this.tbpInfo.Controls.Add(this.pnlUnitTop);
            this.tbpInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Size = new System.Drawing.Size(728, 422);
            this.tbpInfo.TabIndex = 2;
            this.tbpInfo.Text = "Scribe Information";
            // 
            // pnlUnitMid
            // 
            this.pnlUnitMid.Controls.Add(this.grpUnit1);
            this.pnlUnitMid.Controls.Add(this.splUnit);
            this.pnlUnitMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitMid.Location = new System.Drawing.Point(0, 71);
            this.pnlUnitMid.Name = "pnlUnitMid";
            this.pnlUnitMid.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlUnitMid.Size = new System.Drawing.Size(728, 351);
            this.pnlUnitMid.TabIndex = 2;
            // 
            // grpUnit1
            // 
            this.grpUnit1.Controls.Add(this.spdSublotScribe);
            this.grpUnit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit1.Location = new System.Drawing.Point(3, 5);
            this.grpUnit1.Name = "grpUnit1";
            this.grpUnit1.Size = new System.Drawing.Size(717, 343);
            this.grpUnit1.TabIndex = 0;
            this.grpUnit1.TabStop = false;
            this.grpUnit1.Text = "Unit1";
            // 
            // spdSublotScribe
            // 
            this.spdSublotScribe.AccessibleDescription = "spdSublotScribe, Sheet1, Row 0, Column 0, ";
            this.spdSublotScribe.AllowEditOverflow = true;
            this.spdSublotScribe.BackColor = System.Drawing.SystemColors.Control;
            this.spdSublotScribe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSublotScribe.EditModeReplace = true;
            this.spdSublotScribe.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSublotScribe.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSublotScribe.HorizontalScrollBar.Name = "";
            this.spdSublotScribe.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdSublotScribe.HorizontalScrollBar.TabIndex = 18;
            this.spdSublotScribe.Location = new System.Drawing.Point(3, 16);
            this.spdSublotScribe.Name = "spdSublotScribe";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer6;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer6;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdSublotScribe.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdSublotScribe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdSublotScribe.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSublotScribe.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSublotScribe.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSublotScribe_Sheet1});
            this.spdSublotScribe.Size = new System.Drawing.Size(711, 324);
            this.spdSublotScribe.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSublotScribe.TabIndex = 0;
            this.spdSublotScribe.TabStop = false;
            this.spdSublotScribe.TextTipDelay = 200;
            this.spdSublotScribe.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSublotScribe.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSublotScribe.VerticalScrollBar.Name = "";
            this.spdSublotScribe.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdSublotScribe.VerticalScrollBar.TabIndex = 19;
            // 
            // spdSublotScribe_Sheet1
            // 
            this.spdSublotScribe_Sheet1.Reset();
            spdSublotScribe_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSublotScribe_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSublotScribe_Sheet1.ColumnCount = 8;
            spdSublotScribe_Sheet1.RowCount = 3;
            spdSublotScribe_Sheet1.RowHeader.ColumnCount = 0;
            this.spdSublotScribe_Sheet1.ColumnFooter.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotScribe_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotScribe_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSublotScribe_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotScribe_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Slot";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Lot ID";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Scribe Count";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Grade";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Loss Code";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Cell Grade";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Qty2";
            this.spdSublotScribe_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Cell Judge";
            this.spdSublotScribe_Sheet1.ColumnHeader.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotScribe_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotScribe_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSublotScribe_Sheet1.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotScribe_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(0).Label = "Slot";
            this.spdSublotScribe_Sheet1.Columns.Get(0).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(0).Width = 40F;
            this.spdSublotScribe_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(1).Label = "Sub Lot ID";
            this.spdSublotScribe_Sheet1.Columns.Get(1).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(1).Width = 120F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdSublotScribe_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.spdSublotScribe_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(2).Label = "Scribe Count";
            this.spdSublotScribe_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(2).Width = 87F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textCellType1.MaxLength = 1;
            this.spdSublotScribe_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdSublotScribe_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(3).Label = "Grade";
            this.spdSublotScribe_Sheet1.Columns.Get(3).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(3).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(3).Width = 67F;
            this.spdSublotScribe_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(4).Label = "Loss Code";
            this.spdSublotScribe_Sheet1.Columns.Get(4).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(4).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(4).Width = 67F;
            this.spdSublotScribe_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("DotumChe", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdSublotScribe_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(5).Label = "Cell Grade";
            this.spdSublotScribe_Sheet1.Columns.Get(5).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(5).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(5).Width = 115F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 9999999D;
            numberCellType2.MinimumValue = 0D;
            this.spdSublotScribe_Sheet1.Columns.Get(6).CellType = numberCellType2;
            this.spdSublotScribe_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(6).Label = "Qty2";
            this.spdSublotScribe_Sheet1.Columns.Get(6).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(6).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(6).Width = 50F;
            this.spdSublotScribe_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("DotumChe", 9F);
            this.spdSublotScribe_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotScribe_Sheet1.Columns.Get(7).Label = "Cell Judge";
            this.spdSublotScribe_Sheet1.Columns.Get(7).Locked = true;
            this.spdSublotScribe_Sheet1.Columns.Get(7).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotScribe_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotScribe_Sheet1.Columns.Get(7).Width = 122F;
            this.spdSublotScribe_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSublotScribe_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSublotScribe_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotScribe_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSublotScribe_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotScribe_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSublotScribe_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.spdSublotScribe_Sheet1_CellChanged);
            this.spdSublotScribe_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splUnit
            // 
            this.splUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.splUnit.Location = new System.Drawing.Point(720, 5);
            this.splUnit.Name = "splUnit";
            this.splUnit.Size = new System.Drawing.Size(5, 343);
            this.splUnit.TabIndex = 4;
            this.splUnit.TabStop = false;
            // 
            // pnlUnitTop
            // 
            this.pnlUnitTop.Controls.Add(this.grpQty);
            this.pnlUnitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUnitTop.Location = new System.Drawing.Point(0, 0);
            this.pnlUnitTop.Name = "pnlUnitTop";
            this.pnlUnitTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlUnitTop.Size = new System.Drawing.Size(728, 71);
            this.pnlUnitTop.TabIndex = 1;
            // 
            // grpQty
            // 
            this.grpQty.Controls.Add(this.txtOutQty2);
            this.grpQty.Controls.Add(this.txtOutQty1);
            this.grpQty.Controls.Add(this.txtQty2);
            this.grpQty.Controls.Add(this.txtQty1);
            this.grpQty.Controls.Add(this.lblOutQty2);
            this.grpQty.Controls.Add(this.lblOutQty1);
            this.grpQty.Controls.Add(this.lblQty2);
            this.grpQty.Controls.Add(this.lblQty1);
            this.grpQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQty.Location = new System.Drawing.Point(3, 3);
            this.grpQty.Name = "grpQty";
            this.grpQty.Size = new System.Drawing.Size(722, 68);
            this.grpQty.TabIndex = 0;
            this.grpQty.TabStop = false;
            // 
            // txtOutQty2
            // 
            this.txtOutQty2.Location = new System.Drawing.Point(330, 40);
            this.txtOutQty2.MaxLength = 11;
            this.txtOutQty2.Name = "txtOutQty2";
            this.txtOutQty2.ReadOnly = true;
            this.txtOutQty2.Size = new System.Drawing.Size(115, 20);
            this.txtOutQty2.TabIndex = 9;
            this.txtOutQty2.TabStop = false;
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(330, 16);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(115, 20);
            this.txtOutQty1.TabIndex = 7;
            this.txtOutQty1.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(100, 40);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(115, 20);
            this.txtQty2.TabIndex = 3;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 16);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(115, 20);
            this.txtQty1.TabIndex = 1;
            this.txtQty1.TabStop = false;
            // 
            // lblOutQty2
            // 
            this.lblOutQty2.AutoSize = true;
            this.lblOutQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty2.Location = new System.Drawing.Point(266, 43);
            this.lblOutQty2.Name = "lblOutQty2";
            this.lblOutQty2.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty2.TabIndex = 8;
            this.lblOutQty2.Text = "Out Qty 2";
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.AutoSize = true;
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Location = new System.Drawing.Point(266, 19);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty1.TabIndex = 6;
            this.lblOutQty1.Text = "Out Qty 1";
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Location = new System.Drawing.Point(37, 43);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(32, 13);
            this.lblQty2.TabIndex = 2;
            this.lblQty2.Text = "Qty 2";
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Location = new System.Drawing.Point(37, 19);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(32, 13);
            this.lblQty1.TabIndex = 0;
            this.lblQty1.Text = "Qty 1";
            // 
            // cdvScribeCode
            // 
            this.cdvScribeCode.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvScribeCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvScribeCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvScribeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvScribeCode.Location = new System.Drawing.Point(190, 17);
            this.cdvScribeCode.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvScribeCode.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvScribeCode.Name = "MCSSCodeView";
            this.cdvScribeCode.Size = new System.Drawing.Size(20, 20);
            this.cdvScribeCode.SmallImageList = null;
            this.cdvScribeCode.TabIndex = 0;
            this.cdvScribeCode.TabStop = false;
            this.cdvScribeCode.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvScribeCode.Visible = false;
            this.cdvScribeCode.VisibleColumnHeader = false;
            // 
            // cdvGrade
            // 
            this.cdvGrade.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvGrade.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvGrade.Location = new System.Drawing.Point(312, 17);
            this.cdvGrade.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.Name = "cdvGrade";
            this.cdvGrade.Size = new System.Drawing.Size(20, 20);
            this.cdvGrade.SmallImageList = null;
            this.cdvGrade.TabIndex = 0;
            this.cdvGrade.TabStop = false;
            this.cdvGrade.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvGrade.Visible = false;
            this.cdvGrade.VisibleColumnHeader = false;
            // 
            // frmWIPTranScribeLotExt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranScribeLotExt";
            this.Text = "Scribe Extension";
            this.Activated += new System.EventHandler(this.frmWIPTranScribeLot_Activated);
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
            this.grpScribe.ResumeLayout(false);
            this.grpScribe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.tbpInfo.ResumeLayout(false);
            this.pnlUnitMid.ResumeLayout(false);
            this.grpUnit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotScribe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotScribe_Sheet1)).EndInit();
            this.pnlUnitTop.ResumeLayout(false);
            this.grpQty.ResumeLayout(false);
            this.grpQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvScribeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_load_sublot_list_flag;


        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {

            MPCF.FieldClear(this, txtLotID);

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");


#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false) return false;
#endif

            if (cdvCrrID.Items.Count < 1)
            {
                if (SetSublotList() == false) return false;
            }
            else if (cdvCrrID.Items.Count == 1)
            {
                cdvCrrID.Text = cdvCrrID.Items[0].Text;
                cdvCrrID_SelectedItemChanged(null, null);
            }
            else
            {
                MPCF.ClearList(spdSublotScribe, true);
            }


            cdvResID.Text = LOT.GetString("START_RES_ID");
            
            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            
            txtOutQty1.Text = txtQty1.Text;
            txtOutQty2.Text = txtQty2.Text;
            
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
                        
                        ClearLotSpread();
                        MPCF.ClearList(spdSublotScribe, true);
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
            
            int i = 0;
            
            switch (MPCF.Trim(FuncName))
            {
                case "Scribe_Lot":
                    
                    
                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                    //    txtLotID.Focus();
                    //    return false;
                    //}
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    
                    #if _CRR
                    if (cdvCrrID.Items.Count > 0)
                    {
                        if (cdvCrrID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpGeneral;
                            cdvCrrID.Focus();
                            return false;
                        }
                    }
                    #endif
                    
                    
                    
                    for (i = 0; i < spdSublotScribe.ActiveSheet.RowCount; i++)
                    {
                        
                        if (MPCF.Trim(spdSublotScribe.ActiveSheet.Cells[i,1].Value) != "" )
                        {
                            
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
        // SetSublotList()
        //       -  Set Sublot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetSublotList()
        {
            int i;
            int i_row;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");


            MPCF.ClearList(spdSublotScribe, true);
            
            b_load_sublot_list_flag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            i_row = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdSublotScribe.ActiveSheet.RowCount += out_node.GetList(0).Count;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    spdSublotScribe.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    spdSublotScribe.ActiveSheet.Cells[i_row, 2].Value = (int)0;

                    spdSublotScribe.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList(0)[i].GetChar("GRADE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 5].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 6].Value = out_node.GetList(0)[i].GetDouble("QTY_2");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");

                    if (out_node.GetList(0)[i].GetString("CELL_GRADE") != "")
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_grade_count;
                        string s_mask;

                        i_cell_grade_count = out_node.GetList(0)[i].GetString("CELL_GRADE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_grade_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_grade_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotScribe.ActiveSheet.Cells[i_row, 5].CellType = MaskCellType;

                    }

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    if (out_node.GetList(0)[i].GetString("CELL_JUDGE") != "")
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_judge_count;
                        string s_mask;

                        i_cell_judge_count = out_node.GetList(0)[i].GetString("CELL_JUDGE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_judge_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_judge_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotScribe.ActiveSheet.Cells[i_row, 7].CellType = MaskCellType;
                    }

                    i_row++;
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            b_load_sublot_list_flag = true;

            return true;
        }

#if _CRR

        //
        // SetCarrierSublotList()
        //       -  Set Sublot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetCarrierSublotList(string sCrrID)
        {
            int i;
            int i_row;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.ClearList(spdSublotScribe, true);

            b_load_sublot_list_flag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("CRR_ID", MPCF.Trim(sCrrID));

            i_row = 0;
            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdSublotScribe.ActiveSheet.RowCount += out_node.GetList(0).Count;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    spdSublotScribe.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    spdSublotScribe.ActiveSheet.Cells[i_row, 2].Value = (int)0;

                    spdSublotScribe.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList(0)[i].GetChar("GRADE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 5].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 6].Value = out_node.GetList(0)[i].GetDouble("QTY_2");
                    spdSublotScribe.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");


                    if (out_node.GetList(0)[i].GetString("CELL_GRADE") != "")
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_grade_count;
                        string s_mask;

                        i_cell_grade_count = out_node.GetList(0)[i].GetString("CELL_GRADE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_grade_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_grade_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotScribe.ActiveSheet.Cells[i_row, 5].CellType = MaskCellType;
                    }

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    if (out_node.GetList(0)[i].GetString("CELL_JUDGE") != "")
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_judge_count;
                        string s_mask;

                        i_cell_judge_count = out_node.GetList(0)[i].GetString("CELL_JUDGE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_judge_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_judge_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotScribe.ActiveSheet.Cells[i_row, 7].CellType = MaskCellType;
                    }

                    i_row++;

                }

                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));

            } while (in_node.GetInt("NEXT_SLOT_NO") > 0);

            b_load_sublot_list_flag = true;

            return true;
        }

        
        #endif

        
        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                MPCF.FieldVisible(grpUnit1, true);
            }
            else
            {
                MPCF.FieldVisible(grpUnit1, false);
                txtOutQty1.Text = "0";

            }
            if (out_node.GetString("UNIT_2") != "")
            {
                MPCF.FieldVisible(grpUnit1, true);
            }
            else
            {
                txtOutQty2.Text = "0";
            }

            return true;

        }

        //
        // Scribe_Lot()
        //       - Scribe Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Scribe_Lot()
        {

            int i = 0;
            string s_sublot_id;

            TRSNode in_node = new TRSNode("Scribe_Lot_EXT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));

                if (MPCF.CheckNumeric(txtOutQty1.Text) == true)
                {
                    in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(txtOutQty1.Text));
                }
                else
                {
                    in_node.AddDouble("OUT_QTY_1", 0);
                }
                if (MPCF.CheckNumeric(txtOutQty2.Text) == true)
                {
                    in_node.AddDouble("OUT_QTY_2", MPCF.ToDbl(txtOutQty2.Text));
                }
                else
                {
                    in_node.AddDouble("OUT_QTY_2", 0);
                }
                in_node.AddDouble("OUT_QTY_3", LOT.GetDouble("QTY_3"));



                for (i = 0; i < spdSublotScribe.ActiveSheet.RowCount; i++)
                {
                    s_sublot_id = MPCF.Trim(spdSublotScribe.ActiveSheet.Cells[i, 1].Value);
                    if (s_sublot_id != "")
                    {
                        if (MPCF.ToInt(spdSublotScribe.ActiveSheet.Cells[i, 2].Value) != 0)
                        {
                            list_item = in_node.AddNode("SUBLOT");

                            list_item.AddInt("SLOT_NO", MPCF.ToInt(spdSublotScribe.ActiveSheet.Cells[i, 0].Value));
                            list_item.AddString("SUBLOT_ID", MPCF.Trim(spdSublotScribe.ActiveSheet.Cells[i, 1].Value));
                            list_item.AddInt("SCRIBE_COUNT", MPCF.ToInt(spdSublotScribe.ActiveSheet.Cells[i, 2].Value));

                        }
                    }
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

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Scribe_Lot_Ext", in_node, ref out_node) == false)
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

        private void frmWIPTranScribeLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

                    b_load_sublot_list_flag = false;

                    #if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
                    #endif
                    
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_SCRIBE);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }        
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (MPCF.Trim(LOT.GetString("OPER")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                    return;
                }
                
                cdvResID.Init();
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
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Scribe_Lot") == false) return;
                if (Scribe_Lot() == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        
        private void spdSublotScribe_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {

            string s_cell_grade = string.Empty;
            if (b_load_sublot_list_flag == false)
            {
                return;
            }
            
            switch (e.Column)
            {
                case 2: //count
                    
                    int i;
                    int i_scribe_count;

                    i_scribe_count = 0;
                    for (i = 0; i < spdSublotScribe.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdSublotScribe.ActiveSheet.Cells[i, 1].Value) != "")
                        {
                            if (MPCF.ToInt(spdSublotScribe.ActiveSheet.Cells[i, 2].Value) == 0)
                            {
                                i_scribe_count = i_scribe_count + 1;
                            }
                            else
                            {
                                i_scribe_count = i_scribe_count + MPCF.ToInt(spdSublotScribe.ActiveSheet.Cells[i, 2].Value);
                            }
                        }
                        txtOutQty1.Text = i_scribe_count.ToString();
                    }
                        
                    break;                    
            }
            
        }
        
        
        
        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text != "")
            {
                SetCarrierSublotList(cdvCrrID.Text);
            }
#endif
        }
        
        private void cdvCrrID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text == "")
            {
                MPCF.ClearList(spdSublotScribe, true);
            }
#endif
        }

    }
    
}
