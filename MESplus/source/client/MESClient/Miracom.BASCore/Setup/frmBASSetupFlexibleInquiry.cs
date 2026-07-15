using System;
using System.Collections;
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
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupFlexibleInquiry.vb
//   Description : MES Cient Form Attribute Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check Create/Update/Delete condition
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
    public class frmBASSetupFlexibleInquiry : Miracom.MESCore.SetupForm02
    {
        #region " Windows Form auto generated code "

        public frmBASSetupFlexibleInquiry()
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
        private Miracom.UI.Controls.MCListView.MCListView lisInquiryList;
        private System.Windows.Forms.ColumnHeader colInquiryID;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Panel pnlListTop;
        private System.Windows.Forms.Panel pnlListMid;
        private System.Windows.Forms.GroupBox grpAttributeName;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private System.Windows.Forms.GroupBox grpInquiryInfo;
        private System.Windows.Forms.TextBox txtInquiryTitle;
        private System.Windows.Forms.Label lblInquiryTitle;
        private System.Windows.Forms.TextBox txtInquiryDesc;
        private System.Windows.Forms.Label lblAttrDesc;
        private UI.Controls.MCCodeView.MCCodeView cdvInquiryGrp2;
        private Label lblInquiryID;
        private TextBox txtInquiryID;
        private UI.Controls.MCCodeView.MCCodeView cdvInquiryGrp;
        private Label lblInquiryGrp;
        private TabControl tabInquiry;
        private TabPage tbpArguments;
        private TabPage tbpSql;
        private FarPoint.Win.Spread.FpSpread spdArguments;
        private FarPoint.Win.Spread.SheetView spdArguments_Sheet1;
        private ColumnHeader colSQLID1;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private RichTextBox txtSql;
        private Label lblInquiryGrp2;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.ComplexBorder complexBorder3 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupFlexibleInquiry));
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.cdvInquiryGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInquiryGrp2 = new System.Windows.Forms.Label();
            this.pnlListMid = new System.Windows.Forms.Panel();
            this.lisInquiryList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colInquiryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSQLID1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpAttributeName = new System.Windows.Forms.GroupBox();
            this.cdvInquiryGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInquiryGrp = new System.Windows.Forms.Label();
            this.lblInquiryID = new System.Windows.Forms.Label();
            this.txtInquiryDesc = new System.Windows.Forms.TextBox();
            this.lblAttrDesc = new System.Windows.Forms.Label();
            this.txtInquiryID = new System.Windows.Forms.TextBox();
            this.txtInquiryTitle = new System.Windows.Forms.TextBox();
            this.lblInquiryTitle = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpInquiryInfo = new System.Windows.Forms.GroupBox();
            this.tabInquiry = new System.Windows.Forms.TabControl();
            this.tbpArguments = new System.Windows.Forms.TabPage();
            this.spdArguments = new FarPoint.Win.Spread.FpSpread();
            this.spdArguments_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpSql = new System.Windows.Forms.TabPage();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryGrp2)).BeginInit();
            this.pnlListMid.SuspendLayout();
            this.grpAttributeName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryGrp)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpInquiryInfo.SuspendLayout();
            this.tabInquiry.SuspendLayout();
            this.tbpArguments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdArguments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdArguments_Sheet1)).BeginInit();
            this.tbpSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 6;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlAttrInfo);
            this.pnlRight.Controls.Add(this.grpAttributeName);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlListMid);
            this.pnlLeft.Controls.Add(this.pnlListTop);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 5;
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
            this.lblFormTitle.Text = "BaseForm02";
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.cdvInquiryGrp2);
            this.pnlListTop.Controls.Add(this.lblInquiryGrp2);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 32);
            this.pnlListTop.TabIndex = 1;
            // 
            // cdvInquiryGrp2
            // 
            this.cdvInquiryGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInquiryGrp2.BtnToolTipText = "";
            this.cdvInquiryGrp2.DescText = "";
            this.cdvInquiryGrp2.DisplaySubItemIndex = -1;
            this.cdvInquiryGrp2.DisplayText = "";
            this.cdvInquiryGrp2.Focusing = null;
            this.cdvInquiryGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInquiryGrp2.Index = 0;
            this.cdvInquiryGrp2.IsViewBtnImage = false;
            this.cdvInquiryGrp2.Location = new System.Drawing.Point(88, 6);
            this.cdvInquiryGrp2.MaxLength = 20;
            this.cdvInquiryGrp2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryGrp2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryGrp2.Name = "cdvInquiryGrp2";
            this.cdvInquiryGrp2.ReadOnly = false;
            this.cdvInquiryGrp2.SearchSubItemIndex = 0;
            this.cdvInquiryGrp2.SelectedDescIndex = -1;
            this.cdvInquiryGrp2.SelectedSubItemIndex = -1;
            this.cdvInquiryGrp2.SelectionStart = 0;
            this.cdvInquiryGrp2.Size = new System.Drawing.Size(136, 20);
            this.cdvInquiryGrp2.SmallImageList = null;
            this.cdvInquiryGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInquiryGrp2.TabIndex = 2;
            this.cdvInquiryGrp2.TextBoxToolTipText = "";
            this.cdvInquiryGrp2.TextBoxWidth = 136;
            this.cdvInquiryGrp2.VisibleButton = true;
            this.cdvInquiryGrp2.VisibleColumnHeader = false;
            this.cdvInquiryGrp2.VisibleDescription = false;
            this.cdvInquiryGrp2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInquiryGrp2_SelectedItemChanged);
            this.cdvInquiryGrp2.ButtonPress += new System.EventHandler(this.cdvInquiryGrp2_ButtonPress);
            // 
            // lblInquiryGrp2
            // 
            this.lblInquiryGrp2.AutoSize = true;
            this.lblInquiryGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInquiryGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryGrp2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInquiryGrp2.Location = new System.Drawing.Point(5, 9);
            this.lblInquiryGrp2.Name = "lblInquiryGrp2";
            this.lblInquiryGrp2.Size = new System.Drawing.Size(70, 13);
            this.lblInquiryGrp2.TabIndex = 1;
            this.lblInquiryGrp2.Text = "Inquiry Group";
            // 
            // pnlListMid
            // 
            this.pnlListMid.Controls.Add(this.lisInquiryList);
            this.pnlListMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListMid.Location = new System.Drawing.Point(0, 32);
            this.pnlListMid.Name = "pnlListMid";
            this.pnlListMid.Size = new System.Drawing.Size(232, 481);
            this.pnlListMid.TabIndex = 1;
            // 
            // lisInquiryList
            // 
            this.lisInquiryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInquiryID,
            this.colDesc,
            this.colSQLID1});
            this.lisInquiryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisInquiryList.EnableSort = true;
            this.lisInquiryList.EnableSortIcon = true;
            this.lisInquiryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisInquiryList.FullRowSelect = true;
            this.lisInquiryList.Location = new System.Drawing.Point(0, 0);
            this.lisInquiryList.MultiSelect = false;
            this.lisInquiryList.Name = "lisInquiryList";
            this.lisInquiryList.Size = new System.Drawing.Size(232, 481);
            this.lisInquiryList.TabIndex = 0;
            this.lisInquiryList.UseCompatibleStateImageBehavior = false;
            this.lisInquiryList.View = System.Windows.Forms.View.Details;
            this.lisInquiryList.SelectedIndexChanged += new System.EventHandler(this.lisInquiryList_SelectedIndexChanged);
            // 
            // colInquiryID
            // 
            this.colInquiryID.Text = "Inquiry ID";
            this.colInquiryID.Width = 120;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 120;
            // 
            // colSQLID1
            // 
            this.colSQLID1.Text = "SQL ID";
            // 
            // grpAttributeName
            // 
            this.grpAttributeName.Controls.Add(this.cdvInquiryGrp);
            this.grpAttributeName.Controls.Add(this.lblInquiryGrp);
            this.grpAttributeName.Controls.Add(this.lblInquiryID);
            this.grpAttributeName.Controls.Add(this.txtInquiryDesc);
            this.grpAttributeName.Controls.Add(this.lblAttrDesc);
            this.grpAttributeName.Controls.Add(this.txtInquiryID);
            this.grpAttributeName.Controls.Add(this.txtInquiryTitle);
            this.grpAttributeName.Controls.Add(this.lblInquiryTitle);
            this.grpAttributeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttributeName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAttributeName.Location = new System.Drawing.Point(3, 0);
            this.grpAttributeName.Name = "grpAttributeName";
            this.grpAttributeName.Size = new System.Drawing.Size(500, 119);
            this.grpAttributeName.TabIndex = 0;
            this.grpAttributeName.TabStop = false;
            // 
            // cdvInquiryGrp
            // 
            this.cdvInquiryGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInquiryGrp.BtnToolTipText = "";
            this.cdvInquiryGrp.DescText = "";
            this.cdvInquiryGrp.DisplaySubItemIndex = -1;
            this.cdvInquiryGrp.DisplayText = "";
            this.cdvInquiryGrp.Focusing = null;
            this.cdvInquiryGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInquiryGrp.Index = 0;
            this.cdvInquiryGrp.IsViewBtnImage = false;
            this.cdvInquiryGrp.Location = new System.Drawing.Point(116, 40);
            this.cdvInquiryGrp.MaxLength = 20;
            this.cdvInquiryGrp.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInquiryGrp.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInquiryGrp.Name = "cdvInquiryGrp";
            this.cdvInquiryGrp.ReadOnly = false;
            this.cdvInquiryGrp.SearchSubItemIndex = 0;
            this.cdvInquiryGrp.SelectedDescIndex = -1;
            this.cdvInquiryGrp.SelectedSubItemIndex = -1;
            this.cdvInquiryGrp.SelectionStart = 0;
            this.cdvInquiryGrp.Size = new System.Drawing.Size(372, 20);
            this.cdvInquiryGrp.SmallImageList = null;
            this.cdvInquiryGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInquiryGrp.TabIndex = 6;
            this.cdvInquiryGrp.TextBoxToolTipText = "";
            this.cdvInquiryGrp.TextBoxWidth = 372;
            this.cdvInquiryGrp.VisibleButton = true;
            this.cdvInquiryGrp.VisibleColumnHeader = false;
            this.cdvInquiryGrp.VisibleDescription = false;
            this.cdvInquiryGrp.ButtonPress += new System.EventHandler(this.cdvInquiryGrp_ButtonPress);
            // 
            // lblInquiryGrp
            // 
            this.lblInquiryGrp.AutoSize = true;
            this.lblInquiryGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInquiryGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryGrp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInquiryGrp.Location = new System.Drawing.Point(16, 44);
            this.lblInquiryGrp.Name = "lblInquiryGrp";
            this.lblInquiryGrp.Size = new System.Drawing.Size(83, 13);
            this.lblInquiryGrp.TabIndex = 5;
            this.lblInquiryGrp.Text = "Inquiry Group";
            // 
            // lblInquiryID
            // 
            this.lblInquiryID.AutoSize = true;
            this.lblInquiryID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInquiryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInquiryID.Location = new System.Drawing.Point(16, 20);
            this.lblInquiryID.Name = "lblInquiryID";
            this.lblInquiryID.Size = new System.Drawing.Size(62, 13);
            this.lblInquiryID.TabIndex = 3;
            this.lblInquiryID.Text = "Inquiry ID";
            // 
            // txtInquiryDesc
            // 
            this.txtInquiryDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInquiryDesc.Location = new System.Drawing.Point(116, 88);
            this.txtInquiryDesc.MaxLength = 1000;
            this.txtInquiryDesc.Name = "txtInquiryDesc";
            this.txtInquiryDesc.Size = new System.Drawing.Size(372, 20);
            this.txtInquiryDesc.TabIndex = 10;
            // 
            // lblAttrDesc
            // 
            this.lblAttrDesc.AutoSize = true;
            this.lblAttrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrDesc.Location = new System.Drawing.Point(16, 92);
            this.lblAttrDesc.Name = "lblAttrDesc";
            this.lblAttrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblAttrDesc.TabIndex = 9;
            this.lblAttrDesc.Text = "Description";
            // 
            // txtInquiryID
            // 
            this.txtInquiryID.Location = new System.Drawing.Point(116, 16);
            this.txtInquiryID.MaxLength = 30;
            this.txtInquiryID.Name = "txtInquiryID";
            this.txtInquiryID.Size = new System.Drawing.Size(372, 20);
            this.txtInquiryID.TabIndex = 4;
            // 
            // txtInquiryTitle
            // 
            this.txtInquiryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInquiryTitle.Location = new System.Drawing.Point(116, 64);
            this.txtInquiryTitle.MaxLength = 50;
            this.txtInquiryTitle.Name = "txtInquiryTitle";
            this.txtInquiryTitle.Size = new System.Drawing.Size(372, 20);
            this.txtInquiryTitle.TabIndex = 8;
            // 
            // lblInquiryTitle
            // 
            this.lblInquiryTitle.AutoSize = true;
            this.lblInquiryTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInquiryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInquiryTitle.Location = new System.Drawing.Point(16, 68);
            this.lblInquiryTitle.Name = "lblInquiryTitle";
            this.lblInquiryTitle.Size = new System.Drawing.Size(74, 13);
            this.lblInquiryTitle.TabIndex = 7;
            this.lblInquiryTitle.Text = "Inquiry Title";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpInquiryInfo);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(3, 119);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(500, 394);
            this.pnlAttrInfo.TabIndex = 2;
            // 
            // grpInquiryInfo
            // 
            this.grpInquiryInfo.Controls.Add(this.tabInquiry);
            this.grpInquiryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInquiryInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInquiryInfo.Location = new System.Drawing.Point(0, 5);
            this.grpInquiryInfo.Name = "grpInquiryInfo";
            this.grpInquiryInfo.Size = new System.Drawing.Size(500, 389);
            this.grpInquiryInfo.TabIndex = 0;
            this.grpInquiryInfo.TabStop = false;
            this.grpInquiryInfo.Text = "Inquiry Information";
            // 
            // tabInquiry
            // 
            this.tabInquiry.Controls.Add(this.tbpArguments);
            this.tabInquiry.Controls.Add(this.tbpSql);
            this.tabInquiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInquiry.Location = new System.Drawing.Point(3, 16);
            this.tabInquiry.Name = "tabInquiry";
            this.tabInquiry.SelectedIndex = 0;
            this.tabInquiry.Size = new System.Drawing.Size(494, 370);
            this.tabInquiry.TabIndex = 1;
            // 
            // tbpArguments
            // 
            this.tbpArguments.BackColor = System.Drawing.SystemColors.Control;
            this.tbpArguments.Controls.Add(this.spdArguments);
            this.tbpArguments.Location = new System.Drawing.Point(4, 22);
            this.tbpArguments.Name = "tbpArguments";
            this.tbpArguments.Padding = new System.Windows.Forms.Padding(3);
            this.tbpArguments.Size = new System.Drawing.Size(486, 344);
            this.tbpArguments.TabIndex = 0;
            this.tbpArguments.Text = "Arguments";
            // 
            // spdArguments
            // 
            this.spdArguments.AccessibleDescription = "spdArguments, Sheet1, Row 0, Column 0, ";
            this.spdArguments.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdArguments.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdArguments.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdArguments.HorizontalScrollBar.Name = "";
            this.spdArguments.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdArguments.HorizontalScrollBar.TabIndex = 28;
            this.spdArguments.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdArguments.Location = new System.Drawing.Point(3, 3);
            this.spdArguments.Name = "spdArguments";
            this.spdArguments.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdArguments.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdArguments.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdArguments_Sheet1});
            this.spdArguments.Size = new System.Drawing.Size(480, 338);
            this.spdArguments.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdArguments.TabIndex = 1;
            this.spdArguments.TabStop = false;
            this.spdArguments.TextTipDelay = 200;
            this.spdArguments.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdArguments.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdArguments.VerticalScrollBar.Name = "";
            this.spdArguments.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdArguments.VerticalScrollBar.TabIndex = 29;
            this.spdArguments.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdArguments_ButtonClicked);
            // 
            // spdArguments_Sheet1
            // 
            this.spdArguments_Sheet1.Reset();
            spdArguments_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdArguments_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdArguments_Sheet1.ColumnCount = 6;
            spdArguments_Sheet1.RowCount = 20;
            this.spdArguments_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdArguments_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdArguments_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdArguments_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Require";
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Format";
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Size";
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdArguments_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Table";
            this.spdArguments_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdArguments_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdArguments_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdArguments_Sheet1.Columns.Get(0).Border = complexBorder1;
            this.spdArguments_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdArguments_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdArguments_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdArguments_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(0).Width = 124F;
            this.spdArguments_Sheet1.Columns.Get(1).Border = complexBorder2;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Y",
        "N"};
            this.spdArguments_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdArguments_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(1).Label = "Require";
            this.spdArguments_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(1).Width = 52F;
            this.spdArguments_Sheet1.Columns.Get(2).Border = complexBorder3;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "Ascii",
        "Number",
        "Float"};
            this.spdArguments_Sheet1.Columns.Get(2).CellType = comboBoxCellType2;
            this.spdArguments_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(2).Label = "Format";
            this.spdArguments_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(2).Width = 69F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 100D;
            numberCellType1.MinimumValue = 0D;
            this.spdArguments_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.spdArguments_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdArguments_Sheet1.Columns.Get(3).Label = "Size";
            this.spdArguments_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdArguments_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdArguments_Sheet1.Columns.Get(4).Label = "Table";
            this.spdArguments_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(4).Width = 97F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdArguments_Sheet1.Columns.Get(5).CellType = buttonCellType1;
            this.spdArguments_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdArguments_Sheet1.Columns.Get(5).Width = 22F;
            this.spdArguments_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdArguments_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdArguments_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdArguments_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdArguments_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdArguments_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdArguments_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpSql
            // 
            this.tbpSql.BackColor = System.Drawing.SystemColors.Control;
            this.tbpSql.Controls.Add(this.txtSql);
            this.tbpSql.Location = new System.Drawing.Point(4, 22);
            this.tbpSql.Name = "tbpSql";
            this.tbpSql.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSql.Size = new System.Drawing.Size(486, 344);
            this.tbpSql.TabIndex = 1;
            this.tbpSql.Text = "SQL";
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSql.Location = new System.Drawing.Point(3, 3);
            this.txtSql.MaxLength = 15000;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(480, 338);
            this.txtSql.TabIndex = 0;
            this.txtSql.Text = "";
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(180, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // frmBASSetupFlexibleInquiry
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBASSetupFlexibleInquiry";
            this.Text = "Flexible Inquiry Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupFlexibleInquirys_Activated);
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
            this.pnlListTop.ResumeLayout(false);
            this.pnlListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryGrp2)).EndInit();
            this.pnlListMid.ResumeLayout(false);
            this.grpAttributeName.ResumeLayout(false);
            this.grpAttributeName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInquiryGrp)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpInquiryInfo.ResumeLayout(false);
            this.tabInquiry.ResumeLayout(false);
            this.tbpArguments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdArguments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdArguments_Sheet1)).EndInit();
            this.tbpSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        #endregion

        #region "VariableDefinition"

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // initCodeView()
        //       -   initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //       -
        private void initCodeView()
        {
            ListViewItem itmX;
            ListView control;

            cdvTableList.Init();
            MPCF.InitListView(cdvTableList.GetListView);
            cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
            BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1');

            //Add by J.S. 2011.10.14 material,flow,oper, resource를 선택할수 있게 만들기 위해...
            control = cdvTableList.GetListView;

            // Add by Chris 2012.06.12 From_Time, To_Time 선택 가능 하게 하기 위해

            itmX = new ListViewItem("$TO_DATE", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("TO TIME");
            control.Items.Insert(0, itmX);

            itmX = new ListViewItem("$FROM_DATE", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("FROM TIME");
            control.Items.Insert(0, itmX);

            itmX = new ListViewItem("$RESOURCE", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("RESOURCE LIST");
            control.Items.Insert(0, itmX);

            itmX = new ListViewItem("$OPERATION", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("OPERATION LIST");
            control.Items.Insert(0, itmX);

            itmX = new ListViewItem("$FLOW", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("FLOW LIST");
            control.Items.Insert(0, itmX);

            itmX = new ListViewItem("$MATERIAL", (int)SMALLICON_INDEX.IDX_VERSION);
            itmX.SubItems.Add("MATERIAL LIST");
            control.Items.Insert(0, itmX);
        }

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분
        //
        private bool CheckCondition(char ProcStep)
        {

            if (MPCF.CheckValue(txtInquiryID, 1) == false)
            {
                return false;
            }

            switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
            {
                case MPGC.MP_STEP_CREATE:

                    if (MPCF.CheckValue(txtInquiryTitle, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInquiryGrp, 1) == false)
                    {
                        return false;
                    }
                    for (int i = 0; i < spdArguments.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 0].Value) != "")
                        {
                            if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 2].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                tabInquiry.SelectedIndex = 0;
                                spdArguments.ActiveSheet.SetActiveCell(i, 2);
                                spdArguments.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 3].Value) == "" || MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 3].Value) == "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdArguments.ActiveSheet.SetActiveCell(i, 3);
                                tabInquiry.SelectedIndex = 0;
                                spdArguments.Select();
                                return false;
                            }
                        }
                    }

                    if (MPCF.Trim(txtSql.Text) == "")
                    {
                        tabInquiry.SelectedIndex = 1;
                        txtSql.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }

                    break;


                case MPGC.MP_STEP_UPDATE:

                    if (MPCF.CheckValue(txtInquiryTitle, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInquiryGrp, 1) == false)
                    {
                        return false;
                    }
                    for (int i = 0; i < spdArguments.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 0].Value) != "")
                        {
                            if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 2].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                tabInquiry.SelectedIndex = 0;
                                spdArguments.ActiveSheet.SetActiveCell(i, 2);
                                spdArguments.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 3].Value) == "" || MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 3].Value) == "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdArguments.ActiveSheet.SetActiveCell(i, 3);
                                tabInquiry.SelectedIndex = 0;
                                spdArguments.Select();
                                return false;
                            }
                        }
                    }

                    if (MPCF.Trim(txtSql.Text) == "")
                    {
                        tabInquiry.SelectedIndex = 1;
                        txtSql.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }

                    break;

                case MPGC.MP_STEP_DELETE:

                    break;
            }

            return true;
        }

        // Get_InquiryID_List()
        //       - Get InquiryID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetInquiryIDList(ListView listView)
        {
            try
            {
                TRSNode in_node = new TRSNode("INQUIRY_ID_LIST_IN");
                TRSNode out_node = new TRSNode("INQUIRY_ID_LIST_OUT");
                ListViewItem viewItem;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("INQUIRY_GROUP", MPCF.Trim(cdvInquiryGrp2.Text));

                if (MPCR.CallService("BAS", "BAS_View_Flexible_Condition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("INQUIRY_ID"), (int)SMALLICON_INDEX.IDX_MODULE));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_DESC1"));
                    //viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_TITLE"));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("SQL_ID_1"));
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
        // Update_Flexible_Condition()
        //       - Create/Update/Delete flexible condition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool UpdateFlexibleCondition(char ProcStep)
        {
            int i;
            TRSNode node;
            string temp;

            TRSNode in_node = new TRSNode("Update_Flexible_Condition");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("INQUIRY_ID", MPCF.Trim(txtInquiryID.Text));
                in_node.AddString("INQUIRY_TITLE", MPCF.Trim(txtInquiryTitle.Text));
                in_node.AddString("INQUIRY_GROUP", MPCF.Trim(cdvInquiryGrp.Text));
                in_node.AddString("INQUIRY_DESC1", MPCF.Trim(txtInquiryDesc.Text));

                for (i = 0; i < 20; i++)
                {
                    node = in_node.AddNode("LIST");

                    node.AddString("PRT", MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 0].Value));
                    node.AddChar("REQ", MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 1].Value));
                    if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 2].Value) == "Ascii")
                    {
                        node.AddChar("FMT", 'A');
                    }
                    else if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 2].Value) == "Number")
                    {
                        node.AddChar("FMT", 'N');
                    }
                    else if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 2].Value) == "Float")
                    {
                        node.AddChar("FMT", 'F');
                    }
                    else
                    {
                        node.AddChar("FMT", ' ');
                    }
                    //Modify by J.S. 2011.10.10 avoid parse error
                    if (MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 3].Value) == "")
                    {
                        node.AddInt("SIZE", 0);
                    }
                    else
                    {
                        node.AddInt("SIZE", spdArguments.ActiveSheet.Cells[i, 3].Value);
                    }
                    node.AddString("TBL", MPCF.Trim(spdArguments.ActiveSheet.Cells[i, 4].Value));
                }

                temp = MPCF.RTrim(txtSql.Text);

                List<string> sqls = MPCF.ByteSplit(temp, 3000);
                for (i = 0; i < sqls.Count; i++)
                {
                    switch (i)
                    {
                        case 0: in_node.AddString("SQL_1", sqls[i]); break;
                        case 1: in_node.AddString("SQL_2", sqls[i]); break;
                        case 2: in_node.AddString("SQL_3", sqls[i]); break;
                        case 3: in_node.AddString("SQL_4", sqls[i]); break;
                        case 4: in_node.AddString("SQL_5", sqls[i]); break;
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Flexible_Condition", in_node, ref out_node) == false)
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

        private bool ViewInquiryCondition(string sInquiryID, string sSQLID1)
        {
            TRSNode in_node = new TRSNode("VIEW_INQUIRY_CONDITION_IN");
            TRSNode out_node = new TRSNode("VIEW_INQUIRY_CONDITION_OUT");

            try
            {
                spdArguments.ActiveSheet.ClearRange(0, 0, spdArguments.ActiveSheet.RowCount, spdArguments.ActiveSheet.ColumnCount, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INQUIRY_ID", sInquiryID);
                in_node.AddString("SQL_ID_1", sSQLID1);

                if (MPCR.CallService("BAS", "BAS_View_Flexible_Condition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(out_node.GetString("SQL_1"));
                sb.Append(out_node.GetString("SQL_2"));
                sb.Append(out_node.GetString("SQL_3"));
                sb.Append(out_node.GetString("SQL_4"));
                sb.Append(out_node.GetString("SQL_5"));

                txtSql.Text = sb.ToString();

                txtInquiryID.Text = out_node.GetString("INQUIRY_ID");
                txtInquiryTitle.Text = out_node.GetString("INQUIRY_TITLE");
                cdvInquiryGrp.Text = out_node.GetString("INQUIRY_GROUP");
                txtInquiryDesc.Text = out_node.GetString("INQUIRY_DESC1");

                string s_member_name;

                for (int i = 0; i < 20; i++)
                {
                    s_member_name = "PRT_" + (i + 1).ToString();
                    if (out_node.GetString(s_member_name) != "")
                    {
                        spdArguments.ActiveSheet.Cells[i, 0].Value = out_node.GetString(s_member_name);
                        s_member_name = "REQ_" + (i + 1).ToString();
                        spdArguments.ActiveSheet.Cells[i, 1].Value = out_node.GetChar(s_member_name);
                        s_member_name = "FMT_" + (i + 1).ToString();
                        switch (out_node.GetChar(s_member_name))
                        {
                            case 'A':
                                spdArguments.ActiveSheet.Cells[i, 2].Value = "Ascii";
                                break;
                            case 'N':
                                spdArguments.ActiveSheet.Cells[i, 2].Value = "Number";
                                break;
                            case 'F':
                                spdArguments.ActiveSheet.Cells[i, 2].Value = "Float";
                                break;
                            default:
                                spdArguments.ActiveSheet.Cells[i, 2].Value = "";
                                break;
                        }
                        s_member_name = "SIZE_" + (i + 1).ToString();
                        spdArguments.ActiveSheet.Cells[i, 3].Value = out_node.GetInt(s_member_name);
                        s_member_name = "TBL_" + (i + 1).ToString();
                        spdArguments.ActiveSheet.Cells[i, 4].Value = out_node.GetString(s_member_name);
                    }
                }

                //Add by J.S. 2011.10.28
                ChangeSyntaxColor();

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //Add by J.S. 2011.10.28
        private bool IsSQLSyntax(string sQuery)
        {
            for (int i = 0; i < MPGV.SqlSyntax.Length; i++)
            {
                if (MPCF.Trim(MPGV.SqlSyntax[i]) == MPCF.Trim(sQuery))
                {
                    return true;
                }
            }
            return false;
        }

        //Add by J.S. 2011.10.28
        private void ChangeSyntaxColor()
        {
            int iStart;
            int iLen = 0;
            iStart = 0;
            if (MPCF.Trim(txtSql.Text) == "")
            {
                return;
            }
            txtSql.SelectionStart = 0;
            txtSql.SelectionLength = txtSql.Text.Length;
            txtSql.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (iLen < txtSql.Text.Length)
            {
                if (txtSql.Text[iLen] == ' ')
                {
                    if (IsSQLSyntax(MPCF.ToUpper(txtSql.Text.Substring(iStart, iLen - iStart))) == true ||
                        txtSql.Text.Substring(iStart, iLen - iStart).IndexOf("$") > 0)
                    {
                        txtSql.SelectionStart = iStart;
                        txtSql.SelectionLength = iLen - iStart;
                        txtSql.SelectionColor = System.Drawing.Color.Blue;
                        txtSql.SelectionStart = iLen;
                        txtSql.SelectionLength = 0;
                        txtSql.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }
                    iStart = iLen;
                }

                iLen++;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisInquiryList;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmBASSetupFlexibleInquirys_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.InitListView(lisInquiryList);
                MPCF.FieldClear(this);

                initCodeView();

                btnRefresh.PerformClick();

                b_load_flag = true;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisInquiryList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisInquiryList, txtFind.Text, 0, true, false);
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                MPCF.InitListView(lisInquiryList);

                lblDataCount.Text = "";
                if (GetInquiryIDList(lisInquiryList) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisInquiryList.Items.Count);
                    if (lisInquiryList.Items.Count > 0)
                    {
                        if (MPCF.Trim(txtInquiryID.Text) == "")
                        {
                            lisInquiryList.Items[0].Selected = true;
                        }
                        else
                        {
                            MPCF.FindListItem(lisInquiryList, txtInquiryID.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Inquiry Group : " + cdvInquiryGrp2.Text;
            MPCF.ExportToExcel(lisInquiryList, this.Text, sCond);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (UpdateFlexibleCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            btnRefresh.PerformClick();
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (UpdateFlexibleCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            btnRefresh.PerformClick();
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (UpdateFlexibleCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }

            MPCF.FieldClear(this, lisInquiryList, cdvInquiryGrp2);

            btnRefresh.PerformClick();
        }


        private void cdvInquiryGrp2_ButtonPress(object sender, EventArgs e)
        {
            string s_table_name = "INQUIRY_GROUP";

            cdvInquiryGrp2.Init();
            MPCF.InitListView(cdvInquiryGrp2.GetListView);
            cdvInquiryGrp2.Columns.Add("Inquiry Group", 20, HorizontalAlignment.Left);
            cdvInquiryGrp2.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInquiryGrp2.GetListView, '1', s_table_name);
            cdvInquiryGrp2.InsertEmptyRow(0, 1);
        }

        private void cdvInquiryGrp_ButtonPress(object sender, EventArgs e)
        {
            string s_table_name = "INQUIRY_GROUP";

            cdvInquiryGrp.Init();
            MPCF.InitListView(cdvInquiryGrp.GetListView);
            cdvInquiryGrp.Columns.Add("Inquiry Group", 20, HorizontalAlignment.Left);
            cdvInquiryGrp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInquiryGrp.GetListView, '1', s_table_name);
        }

        private void cdvInquiryGrp2_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void lisInquiryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisInquiryList.SelectedItems.Count < 1)
            {
                return;
            }

            string sInquiryID;
            string sSQLID1;

            sInquiryID = MPCF.Trim(lisInquiryList.SelectedItems[0].Text);
            sSQLID1 = MPCF.Trim(lisInquiryList.SelectedItems[0].SubItems[2].Text);

            ViewInquiryCondition(sInquiryID, sSQLID1);
        }

        private void spdArguments_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, MCSSCodeViewSelChanged_EventArgs e)
        {
            spdArguments.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            if (spdArguments.ActiveSheet.Cells[e.Row, e.Col - 1].Text == "$TO_DATE" || spdArguments.ActiveSheet.Cells[e.Row, e.Col - 1].Text == "$FROM_DATE")
            {
                spdArguments.ActiveSheet.Cells[e.Row, e.Col - 2].Value = 8;
                spdArguments.ActiveSheet.Cells[e.Row, e.Col - 2].Locked = true;
            }
            else
            {
                spdArguments.ActiveSheet.Cells[e.Row, e.Col - 2].Locked = false;
            }
        }

    }
}
