
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
//   File Name   : frmSVMViewServiceError.vb
//   Description : MES Cient Form View Service Errlog
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2011-10-26 : Created by J.S
//
//
//
//   Copyright(C) 1998-2011 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.SVMCore
{
    public class frmSVMViewServiceError : Miracom.MESCore.ViewForm01
    {
#region " Windows Form auto generated code "
        
        public frmSVMViewServiceError()
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
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private Panel pnlErrList;
        private Panel pnlDetail;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private TextBox txtServerName;
        private Label lblServerName;
        private UI.Controls.MCCodeView.MCCodeView cdvService;
        private Label lblService;
        private UI.Controls.MCCodeView.MCCodeView cdvResID;
        private Label lblResID;
        private TextBox txtMsgId;
        private Label lblMsgId;
        private TextBox txtErrorMsgDetail;
        private Label lblErrDetail;
        private TextBox txtInMsg;
        private Label lblInMsg;
        private ComboBox cboStatusValue;
        private Label lblStatusValue;
        private TextBox txtDBErrMsg;
        private Label lblDBError;
        private TextBox txtLotID;
        private Label lblLotID;
        private SaveFileDialog sfdExcel;
        private Splitter splCondition;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer7 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer7 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.splCondition = new System.Windows.Forms.Splitter();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.txtErrorMsgDetail = new System.Windows.Forms.TextBox();
            this.lblErrDetail = new System.Windows.Forms.Label();
            this.txtInMsg = new System.Windows.Forms.TextBox();
            this.lblInMsg = new System.Windows.Forms.Label();
            this.pnlErrList = new System.Windows.Forms.Panel();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.cdvService = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblService = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtMsgId = new System.Windows.Forms.TextBox();
            this.lblMsgId = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtDBErrMsg = new System.Windows.Forms.TextBox();
            this.lblDBError = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.cboStatusValue = new System.Windows.Forms.ComboBox();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlErrList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(549, 7);
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(734, 92);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboStatusValue);
            this.grpOption.Controls.Add(this.lblStatusValue);
            this.grpOption.Controls.Add(this.txtDBErrMsg);
            this.grpOption.Controls.Add(this.lblDBError);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.txtMsgId);
            this.grpOption.Controls.Add(this.lblMsgId);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Controls.Add(this.cdvService);
            this.grpOption.Controls.Add(this.lblService);
            this.grpOption.Controls.Add(this.txtServerName);
            this.grpOption.Controls.Add(this.lblServerName);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(734, 92);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.pnlErrList);
            this.pnlViewMid.Controls.Add(this.pnlDetail);
            this.pnlViewMid.Controls.Add(this.splCondition);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 92);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(734, 421);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 7);
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Size = new System.Drawing.Size(734, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(734, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Data";
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
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            columnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer7.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer7.Name = "columnHeaderRenderer7";
            columnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer7.TextRotationAngle = 0D;
            rowHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer7.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer7.Name = "rowHeaderRenderer7";
            rowHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer7.TextRotationAngle = 0D;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(522, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(206, 45);
            this.pnlPeriod.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(55, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(150, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(50, 14);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(55, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(150, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(37, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // splCondition
            // 
            this.splCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.splCondition.Location = new System.Drawing.Point(0, 3);
            this.splCondition.Name = "splCondition";
            this.splCondition.Size = new System.Drawing.Size(734, 3);
            this.splCondition.TabIndex = 2;
            this.splCondition.TabStop = false;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.txtErrorMsgDetail);
            this.pnlDetail.Controls.Add(this.lblErrDetail);
            this.pnlDetail.Controls.Add(this.txtInMsg);
            this.pnlDetail.Controls.Add(this.lblInMsg);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 246);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(734, 175);
            this.pnlDetail.TabIndex = 1;
            // 
            // txtErrorMsgDetail
            // 
            this.txtErrorMsgDetail.Location = new System.Drawing.Point(435, 6);
            this.txtErrorMsgDetail.Multiline = true;
            this.txtErrorMsgDetail.Name = "txtErrorMsgDetail";
            this.txtErrorMsgDetail.ReadOnly = true;
            this.txtErrorMsgDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorMsgDetail.Size = new System.Drawing.Size(293, 163);
            this.txtErrorMsgDetail.TabIndex = 3;
            // 
            // lblErrDetail
            // 
            this.lblErrDetail.AutoSize = true;
            this.lblErrDetail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblErrDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrDetail.Location = new System.Drawing.Point(360, 16);
            this.lblErrDetail.Name = "lblErrDetail";
            this.lblErrDetail.Size = new System.Drawing.Size(59, 13);
            this.lblErrDetail.TabIndex = 2;
            this.lblErrDetail.Text = "Error Detail";
            // 
            // txtInMsg
            // 
            this.txtInMsg.Location = new System.Drawing.Point(77, 6);
            this.txtInMsg.Multiline = true;
            this.txtInMsg.Name = "txtInMsg";
            this.txtInMsg.ReadOnly = true;
            this.txtInMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInMsg.Size = new System.Drawing.Size(272, 163);
            this.txtInMsg.TabIndex = 1;
            // 
            // lblInMsg
            // 
            this.lblInMsg.AutoSize = true;
            this.lblInMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInMsg.Location = new System.Drawing.Point(10, 16);
            this.lblInMsg.Name = "lblInMsg";
            this.lblInMsg.Size = new System.Drawing.Size(62, 13);
            this.lblInMsg.TabIndex = 0;
            this.lblInMsg.Text = "In Message";
            // 
            // pnlErrList
            // 
            this.pnlErrList.Controls.Add(this.spdList);
            this.pnlErrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlErrList.Location = new System.Drawing.Point(0, 6);
            this.pnlErrList.Name = "pnlErrList";
            this.pnlErrList.Size = new System.Drawing.Size(734, 240);
            this.pnlErrList.TabIndex = 1;
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 32;
            this.spdList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.Location = new System.Drawing.Point(0, 0);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
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
            this.spdList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(734, 240);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 33;
            this.spdList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdList_SelectionChanged);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 14;
            spdList_Sheet1.RowCount = 50;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sequence";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "System Node";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Server Name";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "SUB NO";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Service Name";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Message ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Error Message";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "DB Error Message";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Consume Time(sec)";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "User ID";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdList_Sheet1.Columns.Get(0).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(0).Label = "Sequence";
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 90F;
            this.spdList_Sheet1.Columns.Get(1).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 120F;
            this.spdList_Sheet1.Columns.Get(2).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(2).Label = "System Node";
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 84F;
            this.spdList_Sheet1.Columns.Get(3).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(3).Label = "Server Name";
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 79F;
            this.spdList_Sheet1.Columns.Get(4).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(4).Label = "SUB NO";
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 71F;
            this.spdList_Sheet1.Columns.Get(5).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(5).Label = "Service Name";
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 151F;
            this.spdList_Sheet1.Columns.Get(6).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(6).Label = "Resource ID";
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 104F;
            this.spdList_Sheet1.Columns.Get(7).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(7).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 77F;
            this.spdList_Sheet1.Columns.Get(8).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(8).Label = "Message ID";
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 101F;
            this.spdList_Sheet1.Columns.Get(9).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(9).Label = "Status";
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 69F;
            this.spdList_Sheet1.Columns.Get(10).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(10).Label = "Error Message";
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 116F;
            this.spdList_Sheet1.Columns.Get(11).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(11).Label = "DB Error Message";
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 132F;
            this.spdList_Sheet1.Columns.Get(12).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(12).AllowAutoSort = true;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.MaximumValue = 10000000D;
            numberCellType1.MinimumValue = -10000000D;
            this.spdList_Sheet1.Columns.Get(12).CellType = numberCellType1;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(12).Label = "Consume Time(sec)";
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 117F;
            this.spdList_Sheet1.Columns.Get(13).AllowAutoFilter = true;
            this.spdList_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(13).Label = "User ID";
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 115F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtServerName
            // 
            this.txtServerName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtServerName.Location = new System.Drawing.Point(326, 40);
            this.txtServerName.MaxLength = 100;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(120, 20);
            this.txtServerName.TabIndex = 8;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(240, 44);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(69, 13);
            this.lblServerName.TabIndex = 7;
            this.lblServerName.Text = "Server Name";
            // 
            // cdvService
            // 
            this.cdvService.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvService.BorderHotColor = System.Drawing.Color.Black;
            this.cdvService.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvService.BtnToolTipText = "";
            this.cdvService.DescText = "";
            this.cdvService.DisplaySubItemIndex = -1;
            this.cdvService.DisplayText = "";
            this.cdvService.Focusing = null;
            this.cdvService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvService.Index = 0;
            this.cdvService.IsViewBtnImage = false;
            this.cdvService.Location = new System.Drawing.Point(542, 64);
            this.cdvService.MaxLength = 100;
            this.cdvService.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvService.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvService.Name = "cdvService";
            this.cdvService.ReadOnly = false;
            this.cdvService.SearchSubItemIndex = 0;
            this.cdvService.SelectedDescIndex = -1;
            this.cdvService.SelectedSubItemIndex = -1;
            this.cdvService.SelectionStart = 0;
            this.cdvService.Size = new System.Drawing.Size(185, 20);
            this.cdvService.SmallImageList = null;
            this.cdvService.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvService.TabIndex = 10;
            this.cdvService.TextBoxToolTipText = "";
            this.cdvService.TextBoxWidth = 185;
            this.cdvService.VisibleButton = true;
            this.cdvService.VisibleColumnHeader = false;
            this.cdvService.VisibleDescription = false;
            this.cdvService.ButtonPress += new System.EventHandler(this.cdvService_ButtonPress);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(462, 67);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(74, 13);
            this.lblService.TabIndex = 9;
            this.lblService.Text = "Service Name";
            this.lblService.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(97, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(120, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 120;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(10, 18);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            // 
            // txtMsgId
            // 
            this.txtMsgId.Location = new System.Drawing.Point(97, 40);
            this.txtMsgId.MaxLength = 10;
            this.txtMsgId.Name = "txtMsgId";
            this.txtMsgId.Size = new System.Drawing.Size(120, 20);
            this.txtMsgId.TabIndex = 6;
            // 
            // lblMsgId
            // 
            this.lblMsgId.AutoSize = true;
            this.lblMsgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgId.Location = new System.Drawing.Point(10, 44);
            this.lblMsgId.Name = "lblMsgId";
            this.lblMsgId.Size = new System.Drawing.Size(64, 13);
            this.lblMsgId.TabIndex = 5;
            this.lblMsgId.Text = "Message ID";
            this.lblMsgId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(326, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(120, 20);
            this.txtLotID.TabIndex = 3;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(240, 20);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 2;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDBErrMsg
            // 
            this.txtDBErrMsg.Location = new System.Drawing.Point(97, 64);
            this.txtDBErrMsg.MaxLength = 200;
            this.txtDBErrMsg.Name = "txtDBErrMsg";
            this.txtDBErrMsg.Size = new System.Drawing.Size(120, 20);
            this.txtDBErrMsg.TabIndex = 12;
            // 
            // lblDBError
            // 
            this.lblDBError.AutoSize = true;
            this.lblDBError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBError.Location = new System.Drawing.Point(10, 68);
            this.lblDBError.Name = "lblDBError";
            this.lblDBError.Size = new System.Drawing.Size(74, 13);
            this.lblDBError.TabIndex = 11;
            this.lblDBError.Text = "DB Error MSG";
            this.lblDBError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusValue.Location = new System.Drawing.Point(240, 68);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(67, 13);
            this.lblStatusValue.TabIndex = 13;
            this.lblStatusValue.Text = "Status Value";
            // 
            // cboStatusValue
            // 
            this.cboStatusValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusValue.FormattingEnabled = true;
            this.cboStatusValue.Items.AddRange(new object[] {
            "",
            "0 : Success",
            "1 : Fail",
            "2 : Warning",
            "3 : Trouble"});
            this.cboStatusValue.Location = new System.Drawing.Point(326, 64);
            this.cboStatusValue.Name = "cboStatusValue";
            this.cboStatusValue.Size = new System.Drawing.Size(120, 21);
            this.cboStatusValue.TabIndex = 14;
            // 
            // sfdExcel
            // 
            this.sfdExcel.DefaultExt = "xls";
            this.sfdExcel.Filter = "Excel files|*.xls";
            // 
            // frmSVMViewServiceError
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(734, 553);
            this.Name = "frmSVMViewServiceError";
            this.Text = "View Service Error";
            this.Activated += new System.EventHandler(this.frmSVMViewServiceError_Activated);
            this.Load += new System.EventHandler(this.frmSVMViewServiceError_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlErrList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "

        private const int COL_COL_SET_ID = 4;
        private const int COL_CHAR_DESC = 15;
        private const int COL_VALUE_COUNT = 21;
        private const int COL_SPEC_OUT_MASK = 47;
        private const int COL_UPDATE_TIME = 49;
                
        private const int HIST_SEQ_COL = 0;
        
#endregion
        
#region " Variable Definition "
        
        private bool bLoadFlag;
        
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
        private bool CheckCondition()
        {
            
            try
            {
                if (dtpFrom.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    dtpFrom.Focus();
                    return false;
                }
                
                if (dtpTo.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    dtpTo.Focus();
                    return false;
                }
                
                if (dtpFrom.Value > dtpTo.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(160));
                    dtpFrom.Focus();
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

        private bool View_Service_List(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", "");

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_MODULE_NAME") != "");

            return true;
        }

        // View_Service_Error_Log_List()
        //       - View View_Service_Error_Log_List
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Service_Error_Log_List()
        {
            TRSNode in_node = new TRSNode("View_Service_Error_Log_List_In");
            TRSNode out_node = new TRSNode("View_Service_Error_Log_List_Out");
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdList);
            txtInMsg.Text = "";
            txtErrorMsgDetail.Text = "";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddString("SERVER_NAME", MPCF.Trim(txtServerName.Text));
            in_node.AddString("MSG_ID", MPCF.Trim(txtMsgId.Text));
            in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));

            /* 2013.06.12. Aiden. 조회 조건 추가 */
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("DB_ERROR_MSG", MPCF.Trim(txtDBErrMsg.Text));
            in_node.AddChar("STATUS_VALUE", MPCF.ToChar(cboStatusValue.Text));

            in_node.AddString("FROM_TRAN_TIME", MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddString("TO_TRAN_TIME", MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
            in_node.AddInt("NEXT_SEQ_NUM", int.MaxValue);

            spdList.SuspendLayout();
            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Error_Log_List", in_node, ref out_node) == false)
                {
                    spdList.ResumeLayout();
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    iCol = 0;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SYSTEM_NODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SERVER_NAME");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBNO");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SERVICE_NAME");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MSG_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("STATUS_VALUE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ERROR_MSG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DB_ERROR_MSG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetDouble("CONSUME_SEC");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                    if (spdList.ActiveSheet.RowCount == 100)
                    {
                        MPCF.FitColumnHeader(spdList);
                    }
                }

                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
            } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);

            if (spdList.ActiveSheet.RowCount < 100)
            {
                MPCF.FitColumnHeader(spdList);
            }
            spdList.ResumeLayout();

            return true;
        }


        // View_Service_Error_Log()
        //       - View View_Service_Error_Log
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Service_Error_Log(int seq_num)
        {
            TRSNode in_node = new TRSNode("View_Service_Error_Log_In");
            TRSNode out_node = new TRSNode("View_Service_Error_Log_Out");
   

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddInt("SEQ_NUM", seq_num);

            if (MPCR.CallService("SVM", "SVM_View_Service_Error_Log", in_node, ref out_node) == false)
            {
                return false;
            }

            txtInMsg.Text = out_node.GetString("IN_MSG").Replace("\n","\r\n");
            txtErrorMsgDetail.Text = out_node.GetString("ERROR_MSG_DETAIL").Replace("\n", "\r\n");

 
            return true;
        }

        //for first focus
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion
        
        private void frmSVMViewServiceError_Load(object sender, System.EventArgs e)
        {
            try
            {
                dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtpTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmSVMViewServiceError_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {

                    MPCF.FieldClear(this);
                    MPCF.ClearList(spdList, true);

                    bLoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdList_SelectionChanged(System.Object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int iRow = 0;
            
            try
            {            

                if (spdList.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }

                iRow = spdList.Sheets[0].ActiveRowIndex;

                View_Service_Error_Log(MPCF.ToInt(spdList.Sheets[0].GetValue(iRow, 0)));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }

                View_Service_Error_Log_List();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Bonus Code", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;
            View_Service_List(cdvService.GetListView);
        }

        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            cdvResID.DisplaySubItemIndex = 0;

            RASLIST.ViewResourceList(cdvResID.GetListView, '1', "", "", "", "", "", 0, "", "", ' ', "", true, null, "");
        }

        /* 2013.06.12. Aiden. spread 의 Excel Export 기능으로 변경 */
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

            spdList.ActiveSheet.Protect = false;
            spdList.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
        }

    }
}
