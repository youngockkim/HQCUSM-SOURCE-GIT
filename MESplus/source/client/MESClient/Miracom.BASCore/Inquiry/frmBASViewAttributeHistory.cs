using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.UI.Controls;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewAttributeHistory.vb
//   Description : MES Cient Form Attribute Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-07-05 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

namespace Miracom.BASCore
{
    public partial class frmBASViewAttributeHistory : Miracom.MESCore.ViewForm01
    {
        #region " Windows Form auto generated code "

        public frmBASViewAttributeHistory()
        {
            InitializeComponent();
        }

        private CheckBox chkIncludeDelHistory;
        private Panel pnlPeriod;
        private DateTimePicker dtpFrom;
        private Label lblPeriod;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrKey;
        private Label lblAttrKey;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private Label lblAttrType;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private Button btnDetail;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private Label lblAttrName;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvAttrKey = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnDetail = new System.Windows.Forms.Button();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(468, 7);
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 94);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvAttrName);
            this.grpOption.Controls.Add(this.lblAttrName);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.cdvAttrKey);
            this.grpOption.Controls.Add(this.lblAttrKey);
            this.grpOption.Controls.Add(this.cdvAttrType);
            this.grpOption.Controls.Add(this.lblAttrType);
            this.grpOption.Size = new System.Drawing.Size(742, 94);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 94);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 419);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDetail);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDetail, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(3, 27);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 4;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.chkIncludeDelHistory);
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(470, 17);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 43);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(55, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(148, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // cdvAttrKey
            // 
            this.cdvAttrKey.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrKey.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrKey.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrKey.BtnToolTipText = "";
            this.cdvAttrKey.ButtonWidth = 20;
            this.cdvAttrKey.DescText = "";
            this.cdvAttrKey.DisplaySubItemIndex = 0;
            this.cdvAttrKey.DisplayText = "";
            this.cdvAttrKey.Focusing = null;
            this.cdvAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrKey.Index = 0;
            this.cdvAttrKey.IsViewBtnImage = false;
            this.cdvAttrKey.Location = new System.Drawing.Point(77, 41);
            this.cdvAttrKey.MaxLength = 100;
            this.cdvAttrKey.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.MultiSelect = false;
            this.cdvAttrKey.Name = "cdvAttrKey";
            this.cdvAttrKey.ReadOnly = false;
            this.cdvAttrKey.SameWidthHeightOfButton = false;
            this.cdvAttrKey.SearchSubItemIndex = 0;
            this.cdvAttrKey.SelectedDescIndex = -1;
            this.cdvAttrKey.SelectedDescToQueryText = "";
            this.cdvAttrKey.SelectedSubItemIndex = 0;
            this.cdvAttrKey.SelectedValueToQueryText = "";
            this.cdvAttrKey.SelectionStart = 0;
            this.cdvAttrKey.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrKey.SmallImageList = null;
            this.cdvAttrKey.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrKey.TabIndex = 3;
            this.cdvAttrKey.TextBoxToolTipText = "";
            this.cdvAttrKey.TextBoxWidth = 200;
            this.cdvAttrKey.VisibleButton = true;
            this.cdvAttrKey.VisibleColumnHeader = false;
            this.cdvAttrKey.VisibleDescription = false;
            this.cdvAttrKey.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrKey_SelectedItemChanged);
            this.cdvAttrKey.ButtonPress += new System.EventHandler(this.cdvAttrKey_ButtonPress);
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.AutoSize = true;
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(14, 45);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(28, 13);
            this.lblAttrKey.TabIndex = 2;
            this.lblAttrKey.Text = "Key";
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.ButtonWidth = 20;
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = 0;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(77, 17);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MultiSelect = false;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SameWidthHeightOfButton = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedDescToQueryText = "";
            this.cdvAttrType.SelectedSubItemIndex = 0;
            this.cdvAttrType.SelectedValueToQueryText = "";
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 200;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(14, 21);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(35, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Type";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 0;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer4;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer4;
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
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 419);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 11;
            this.spdHistory.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdHistory_CellDoubleClick);
            this.spdHistory.SetViewportLeftColumn(0, 0, 1);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 17;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Attribute Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "ArraySeq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Old Value";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Null";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Key Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Hist Start Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Hist Delele Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 55F;
            textCellType1.MaxLength = 100;
            textCellType1.Multiline = true;
            textCellType1.WordWrap = true;
            this.spdHistory_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Attribute Name";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 150F;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "ArraySeq";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            textCellType2.MaxLength = 110;
            textCellType2.Multiline = true;
            textCellType2.WordWrap = true;
            this.spdHistory_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Old Value";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 180F;
            textCellType3.MaxLength = 110;
            textCellType3.Multiline = true;
            textCellType3.WordWrap = true;
            this.spdHistory_Sheet1.Columns.Get(4).CellType = textCellType3;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 180F;
            this.spdHistory_Sheet1.Columns.Get(5).CellType = textCellType4;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Null";
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 30F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 101F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Key Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Hist Start Seq";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Hist Delele Flag";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 200F;
            this.spdHistory_Sheet1.Columns.Get(16).Visible = false;
            this.spdHistory_Sheet1.FrozenColumnCount = 1;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(1).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(2).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(3).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(4).Height = 18F;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(558, 7);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(88, 26);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "Detail";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // cdvAttrName
            // 
            this.cdvAttrName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrName.BtnToolTipText = "";
            this.cdvAttrName.ButtonWidth = 20;
            this.cdvAttrName.DescText = "";
            this.cdvAttrName.DisplaySubItemIndex = 0;
            this.cdvAttrName.DisplayText = "";
            this.cdvAttrName.Focusing = null;
            this.cdvAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrName.Index = 0;
            this.cdvAttrName.IsViewBtnImage = false;
            this.cdvAttrName.Location = new System.Drawing.Point(77, 65);
            this.cdvAttrName.MaxLength = 100;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MultiSelect = false;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = false;
            this.cdvAttrName.SameWidthHeightOfButton = false;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedDescToQueryText = "";
            this.cdvAttrName.SelectedSubItemIndex = 0;
            this.cdvAttrName.SelectedValueToQueryText = "";
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(365, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 5;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 365;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            this.cdvAttrName.ButtonPress += new System.EventHandler(this.cdvAttrName_ButtonPress);
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(14, 69);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(35, 13);
            this.lblAttrName.TabIndex = 4;
            this.lblAttrName.Text = "Name";
            // 
            // frmBASViewAttributeHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASViewAttributeHistory";
            this.Text = "View Attribute History";
            this.Activated += new System.EventHandler(this.frmBASViewAttributeHistory_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        private const int MAX_VALUE_COUNT = 1000;

        private enum COLUMNS
        {
            HistSeq = 0,
            AttrName,
            ArraySeq,
            AttrOldValue,
            AttrNewValue,
            NullFlag,
            TranTime,
            TranUser,
            SysTranTime,
            KeyHistSeq,
            PrevActiveHistSeq,
            HistStartSeq,
            HistDelFlag,
            HistDelTime,
            HistDelUser,
            HistDelComment
        }

        #endregion

        #region " Variable Definition"

        bool b_load_flag;

        #endregion

        #region " Function Definition"

        // CheckCondition()
        //       - check View condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvAttrKey, 1) == false)
            {
                return false;
            }

            return true;
        }

        private bool ViewAttributeHistory()
        { 
            TRSNode in_node = new TRSNode("ATTRIBUTE_HISTORY_LIST_IN");
            TRSNode out_node = new TRSNode("ATTRIBUTE_HISTORY_LIST_OUT");
            List<TRSNode> hist_list;
            DateTimePicker newToData = dtpTo;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddChar("INCLUDE_DEL_HIST", (chkIncludeDelHistory.Checked ? 'Y' : ' '));
            in_node.AddString("ATTR_TYPE", cdvAttrType.Text);
            in_node.AddString("ATTR_KEY", cdvAttrKey.Text);
            in_node.AddString("ATTR_NAME", cdvAttrName.Text);
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_HIST_SEQ", 0);
            in_node.AddString("FROM_TRAN_TIME", MPCF.FromDate((DateTimePicker)dtpFrom));
            in_node.AddString("TO_TRAN_TIME", MPCF.ToDate((DateTimePicker)dtpTo));

            do
            {

                if (MPCR.CallService("BAS", "BAS_View_Attribute_History_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_list = out_node.GetList("HIST_LIST");

                for (int i = 0; i < hist_list.Count; i++)
                {
                    /** #1088  Attribute Array   SSKIM  2012-11-20   **/
                    if (hist_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                    {
                        PrintAttributeHistoryToSpread(spdHistory, hist_list[i], hist_list[i].GetChar("ARRAY_SEPARATOR"));
                    }
                    else
                    {
                        PrintAttributeHistoryToSpread(spdHistory, hist_list[i]);
                    }
                }

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_HIST_SEQ") > 0);

            //TranTime,HistSeq,AttrName,ArraySeq
            FarPoint.Win.Spread.SortInfo[] sorter = new FarPoint.Win.Spread.SortInfo[4];
            sorter[0] = new FarPoint.Win.Spread.SortInfo((int)COLUMNS.TranTime, false, System.Collections.Comparer.Default);
            sorter[1] = new FarPoint.Win.Spread.SortInfo((int)COLUMNS.AttrName, false, System.Collections.Comparer.Default);
            sorter[2] = new FarPoint.Win.Spread.SortInfo((int)COLUMNS.ArraySeq, true, System.Collections.Comparer.Default);

            spdHistory.ActiveSheet.SortRows(0, spdHistory.ActiveSheet.RowCount, sorter);
            MPCF.FitColumnHeader(spdHistory, (int)COLUMNS.TranTime, -1);
             
            return true;
        }

        private void PrintAttributeHistoryToSpread(FarPoint.Win.Spread.FpSpread spd, TRSNode node)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;

            sheetX = spd.ActiveSheet;
            iRow = sheetX.RowCount;
            sheetX.RowCount++;

            if (node.GetChar("HIST_DEL_FLAG") == 'Y')
            {
                sheetX.Rows[iRow].ForeColor = Color.Magenta;
            }
            else
            {
                sheetX.Rows[iRow].ForeColor = Color.Black;
            }

            if (node.GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y' &&
                node.GetString("ATTR_OLD_VALUE").Length > 99)
            {
                string old_value = node.GetString("ATTR_OLD_VALUE");
                node.SetString("ATTR_OLD_VALUE", old_value += "...");
            }
            if (node.GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y' &&
                node.GetString("ATTR_NEW_VALUE").Length > 99)
            {
                string new_value = node.GetString("ATTR_NEW_VALUE");
                node.SetString("ATTR_NEW_VALUE", new_value += "...");
            }

            sheetX.Cells[iRow, (int)COLUMNS.HistSeq].Value = node.GetInt("HIST_SEQ");

            sheetX.Cells[iRow, (int)COLUMNS.AttrName].Value = node.GetString("ATTR_NAME");
            sheetX.Cells[iRow, (int)COLUMNS.AttrName].Tag = node.GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");


            sheetX.Cells[iRow, (int)COLUMNS.ArraySeq].Value = 0;
            sheetX.Cells[iRow, (int)COLUMNS.AttrOldValue].Value = node.GetString("ATTR_OLD_VALUE");

            if (node.GetChar("NULL_FLAG") == 'Y')
                sheetX.Cells[iRow, (int)COLUMNS.AttrNewValue].Value = "[Null]";
            else
                sheetX.Cells[iRow, (int)COLUMNS.AttrNewValue].Value = node.GetString("ATTR_NEW_VALUE");

            sheetX.Cells[iRow, (int)COLUMNS.NullFlag].Value = node.GetChar("NULL_FLAG");
            sheetX.Cells[iRow, (int)COLUMNS.TranTime].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));
            sheetX.Cells[iRow, (int)COLUMNS.TranUser].Value = node.GetString("TRAN_USER_ID");
            sheetX.Cells[iRow, (int)COLUMNS.SysTranTime].Value = MPCF.MakeDateFormat(node.GetString("SYS_TRAN_TIME"));
            sheetX.Cells[iRow, (int)COLUMNS.KeyHistSeq].Value = node.GetInt("KEY_HIST_SEQ");
            sheetX.Cells[iRow, (int)COLUMNS.PrevActiveHistSeq].Value = node.GetInt("PREV_ACTIVE_HIST_SEQ");
            sheetX.Cells[iRow, (int)COLUMNS.HistStartSeq].Value = node.GetInt("HIST_START_SEQ");
            sheetX.Cells[iRow, (int)COLUMNS.HistDelFlag].Value = node.GetChar("HIST_DEL_FLAG");
            sheetX.Cells[iRow, (int)COLUMNS.HistDelTime].Value = MPCF.MakeDateFormat(node.GetString("HIST_DEL_TIME"));
            sheetX.Cells[iRow, (int)COLUMNS.HistDelUser].Value = node.GetString("HIST_DEL_USER_ID");
            sheetX.Cells[iRow, (int)COLUMNS.HistDelComment].Value = node.GetString("HIST_DEL_COMMENT");

            sheetX.Rows[iRow].Height = sheetX.GetPreferredRowHeight(iRow);
        }

        private void PrintAttributeHistoryToSpread(FarPoint.Win.Spread.FpSpread spd, TRSNode node, char c_separator)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i_row;
            int i_start_row;

            sheetX = spd.ActiveSheet;
            i_start_row = sheetX.RowCount;
            
            string[] sa_old_values = node.GetString("ATTR_OLD_VALUE").Split(c_separator);
            string[] sa_new_values = node.GetString("ATTR_NEW_VALUE").Split(c_separator);
            int i_array_index = 0;

            if (sa_old_values.Length >= sa_new_values.Length)
            {
                // ATTR_OLD_VALUE
                foreach (string s_value in sa_old_values)
                {
                    i_row = sheetX.RowCount;
                    sheetX.RowCount++;

                    sheetX.Cells[i_row, (int)COLUMNS.AttrOldValue].Value = s_value;

                    if (node.GetChar("NULL_FLAG") == 'Y')
                    {
                        sheetX.Cells[i_row, (int)COLUMNS.AttrNewValue].Value = "[Null]";
                    }
                    else
                    {
                        if (i_array_index < sa_new_values.Length)
                        {
                            sheetX.Cells[i_row, (int)COLUMNS.AttrNewValue].Value = sa_new_values[i_array_index];
                        }
                    }
                    i_array_index++;
                    sheetX.Cells[i_row, (int)COLUMNS.ArraySeq].Value = i_array_index;
                }
            }
            else
            {
                // ATTR_NEW_VALUE
                foreach (string s_value in sa_new_values)
                {
                    i_row = sheetX.RowCount;
                    sheetX.RowCount++;

                    if (i_array_index < sa_old_values.Length)
                    {
                        sheetX.Cells[i_row, (int)COLUMNS.AttrOldValue].Value = sa_old_values[i_array_index];
                    } 

                    if (node.GetChar("NULL_FLAG") == 'Y' )
                    {
                        sheetX.Cells[i_row, (int)COLUMNS.AttrNewValue].Value = "[Null]";
                    }
                    else
                    {
                        sheetX.Cells[i_row, (int)COLUMNS.AttrNewValue].Value = s_value;
                    }
                    i_array_index++;
                    sheetX.Cells[i_row, (int)COLUMNS.ArraySeq].Value = i_array_index;
                }
            }

            //value 이외의 데이터 설정
            for (i_row = i_start_row; i_row < sheetX.RowCount; i_row++)
            {
                if (node.GetChar("HIST_DEL_FLAG") == 'Y')
                {
                    sheetX.Rows[i_row].ForeColor = Color.Magenta;
                }
                else
                {
                    sheetX.Rows[i_row].ForeColor = Color.Black;
                }

                sheetX.Cells[i_row, (int)COLUMNS.HistSeq].Value = node.GetInt("HIST_SEQ");

                sheetX.Cells[i_row, (int)COLUMNS.AttrName].Value = node.GetString("ATTR_NAME");
                sheetX.Cells[i_row, (int)COLUMNS.AttrName].Tag = node.GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                sheetX.Cells[i_row, (int)COLUMNS.NullFlag].Value = node.GetChar("NULL_FLAG");
                sheetX.Cells[i_row, (int)COLUMNS.TranTime].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));
                sheetX.Cells[i_row, (int)COLUMNS.TranUser].Value = node.GetString("TRAN_USER_ID");
                sheetX.Cells[i_row, (int)COLUMNS.SysTranTime].Value = MPCF.MakeDateFormat(node.GetString("SYS_TRAN_TIME"));
                sheetX.Cells[i_row, (int)COLUMNS.KeyHistSeq].Value = node.GetInt("KEY_HIST_SEQ");
                sheetX.Cells[i_row, (int)COLUMNS.PrevActiveHistSeq].Value = node.GetInt("PREV_ACTIVE_HIST_SEQ");
                sheetX.Cells[i_row, (int)COLUMNS.HistStartSeq].Value = node.GetInt("HIST_START_SEQ");
                sheetX.Cells[i_row, (int)COLUMNS.HistDelFlag].Value = node.GetChar("HIST_DEL_FLAG");
                sheetX.Cells[i_row, (int)COLUMNS.HistDelTime].Value = MPCF.MakeDateFormat(node.GetString("HIST_DEL_TIME"));
                sheetX.Cells[i_row, (int)COLUMNS.HistDelUser].Value = node.GetString("HIST_DEL_USER_ID");
                sheetX.Cells[i_row, (int)COLUMNS.HistDelComment].Value = node.GetString("HIST_DEL_COMMENT");

                sheetX.Rows[i_row].Height = sheetX.GetPreferredRowHeight(i_row);
            }
        }

        public void ShowHistory(string s_attr_type, string s_attr_key)
        {
            cdvAttrType.Text = s_attr_type;
            cdvAttrType_SelectedItemChanged(null, null);
            cdvAttrKey.Text = s_attr_key;
            cdvAttrKey_SelectedItemChanged(null, null);
        }
        
        #endregion

        private void frmBASViewAttributeHistory_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory);

                dtpFrom.Value = DateTime.Now.AddDays(-3);
                dtpTo.Value = DateTime.Now;

                spdHistory_Sheet1.Columns[(int)COLUMNS.ArraySeq].Visible = false;

                b_load_flag = true;
            }
        }

        private void cdvAttrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvAttrKey.Text = "";
            cdvAttrKey.VisibleButton = true;

            switch (cdvAttrType.Text)
            {
                case "FACTORY":

                    break;
                case "MATERIAL":

                    break;
                case "FLOW":

                    break;
                case "OPER":

                    break;
                case "BOM":

                    break;
                case "RESOURCE":

                    break;
                case "CARRIER":

                    break;
                default:

                    cdvAttrKey.VisibleButton = false;
                    break;
            }

        }

        private void cdvAttrKey_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }

            cdvAttrKey.Init();
            MPCF.InitListView(cdvAttrKey.GetListView);
            cdvAttrKey.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrKey.SelectedSubItemIndex = 0;

            switch (cdvAttrType.Text)
            {
                case "FACTORY":

                    WIPLIST.ViewFactoryList(cdvAttrKey.GetListView, '1', null);
                    break;
                case "MATERIAL":

                    cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    WIPLIST.ViewMaterialList(cdvAttrKey.GetListView, '1');
                    break;
                case "FLOW":

                    WIPLIST.ViewFlowList(cdvAttrKey.GetListView, '1', "", 0, "", null, "");
                    break;
                case "OPER":

                    WIPLIST.ViewOperationList(cdvAttrKey.GetListView, '1', "", 0, "", "", null, "");
                    break;
                case "BOM":

                    #if _BOM
                    BOMLIST.ViewBOMSetList(cdvAttrKey.GetListView, '1', null, "", -1, -1, ' ', true);
                    #endif
                    break;
                case "RESOURCE":

                    RASLIST.ViewResourceList(cdvAttrKey.GetListView, false);
                    break;
                case "CARRIER":

                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(cdvAttrKey.Text) == "")
                        {
                            cdvAttrKey.IsPopup = false;
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            cdvAttrKey.Focus();
                            return;
                        }
                    }
                    RASLIST.ViewCarrierList(cdvAttrKey.GetListView, '1', "", "", cdvAttrKey.Text);
                    break;
            }

        }

        private void cdvAttrKey_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAttrType.Text == "MATERIAL")
                if (e != null)
                    cdvAttrKey.Text = e.SelectedItem.SubItems[0].Text + " : " + e.SelectedItem.SubItems[1].Text;

            btnView.PerformClick();
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Seq", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Type", 200, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);

            if (CheckCondition() == false)
            {
                return;
            }

            ViewAttributeHistory();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(spdHistory, "Attribute History List", "TYPE = " + cdvAttrType.Text + " KEY = " + cdvAttrKey.Text + " Period :" + dtpFrom.Value + " ~ " + dtpTo.Value);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (spdHistory.ActiveSheet == null)
                return;
            if (spdHistory.ActiveSheet.ActiveRow == null)
                return;

            if (MPCF.Trim(spdHistory.ActiveSheet.Cells[spdHistory.ActiveSheet.ActiveRowIndex, (int)COLUMNS.AttrName].Tag) == "Y")
            {
                frmBASAttributeHistoryDetail f = new frmBASAttributeHistoryDetail();
                f.AttributeKey = cdvAttrKey.Text;
                f.AttributeType = cdvAttrType.Text;
                f.AttributeName = MPCF.Trim(spdHistory.ActiveSheet.Cells[spdHistory.ActiveSheet.ActiveRowIndex, (int)COLUMNS.AttrName].Value);
                f.AttributeHistSeq = MPCF.ToInt(spdHistory.ActiveSheet.Cells[spdHistory.ActiveSheet.ActiveRowIndex, (int)COLUMNS.HistSeq].Value);

                f.ShowDialog(this);
            }

        }

        private void spdHistory_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            btnDetail.PerformClick();
        }

        
    }
}