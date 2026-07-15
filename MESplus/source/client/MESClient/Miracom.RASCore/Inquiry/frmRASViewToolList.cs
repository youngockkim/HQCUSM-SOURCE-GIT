
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
//   File Name   : frmRASViewToolList.vb
//   Description : View Tool List Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Tool_Type() : View Tool Type Information and find available Prompt
//       - ViewToolList_Detail_Local() : View Tool List (Local)
//       - CheckCondition()      : Check the conditions before transaction
//       - ClearData()           : Clear Fields and Initialize Sheet
//       - InitCodeView()        : Initialize MCCodeView
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-08-08 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASViewToolList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewToolList()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolType;
        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.RadioButton optNormal;
        private System.Windows.Forms.RadioButton optScrap;
        private System.Windows.Forms.RadioButton optReturn;
        private System.Windows.Forms.RadioButton optAbnormal;
        private System.Windows.Forms.RadioButton optAll;
        private System.Windows.Forms.GroupBox grpOption2;
        private System.Windows.Forms.Label lblSubResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolSts;
        private System.Windows.Forms.Label lblToolSts;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtToolSetID;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.TextBox txtVendor;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvToolType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvToolSts = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.lblToolSts = new System.Windows.Forms.Label();
            this.cdvGrade = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGrade = new System.Windows.Forms.Label();
            this.grpOption2 = new System.Windows.Forms.GroupBox();
            this.optAll = new System.Windows.Forms.RadioButton();
            this.optAbnormal = new System.Windows.Forms.RadioButton();
            this.optReturn = new System.Windows.Forms.RadioButton();
            this.optScrap = new System.Windows.Forms.RadioButton();
            this.optNormal = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtToolSetID = new System.Windows.Forms.TextBox();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolSts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).BeginInit();
            this.grpOption2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
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
            this.pnlViewTop.Controls.Add(this.grpOption2);
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(742, 136);
            this.pnlViewTop.Controls.SetChildIndex(this.grpOption2, 0);
            this.pnlViewTop.Controls.SetChildIndex(this.grpOption, 0);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtVendor);
            this.grpOption.Controls.Add(this.txtToolSetID);
            this.grpOption.Controls.Add(this.Label1);
            this.grpOption.Controls.Add(this.cdvGrade);
            this.grpOption.Controls.Add(this.lblGrade);
            this.grpOption.Controls.Add(this.cdvToolSts);
            this.grpOption.Controls.Add(this.lblSubResID);
            this.grpOption.Controls.Add(this.lblToolSts);
            this.grpOption.Controls.Add(this.cdvToolType);
            this.grpOption.Controls.Add(this.lblToolType);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Size = new System.Drawing.Size(736, 96);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 136);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 370);
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
            this.lblFormTitle.Text = "View Tool List";
            // 
            // cdvToolType
            // 
            this.cdvToolType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolType.BtnToolTipText = "";
            this.cdvToolType.DescText = "";
            this.cdvToolType.DisplaySubItemIndex = -1;
            this.cdvToolType.DisplayText = "";
            this.cdvToolType.Focusing = null;
            this.cdvToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolType.Index = 0;
            this.cdvToolType.IsViewBtnImage = false;
            this.cdvToolType.Location = new System.Drawing.Point(120, 16);
            this.cdvToolType.MaxLength = 20;
            this.cdvToolType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.Name = "cdvToolType";
            this.cdvToolType.ReadOnly = true;
            this.cdvToolType.SearchSubItemIndex = 0;
            this.cdvToolType.SelectedDescIndex = -1;
            this.cdvToolType.SelectedSubItemIndex = -1;
            this.cdvToolType.SelectionStart = 0;
            this.cdvToolType.Size = new System.Drawing.Size(200, 20);
            this.cdvToolType.SmallImageList = null;
            this.cdvToolType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolType.TabIndex = 1;
            this.cdvToolType.TextBoxToolTipText = "";
            this.cdvToolType.TextBoxWidth = 200;
            this.cdvToolType.VisibleButton = true;
            this.cdvToolType.VisibleColumnHeader = false;
            this.cdvToolType.VisibleDescription = false;
            this.cdvToolType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolType_SelectedItemChanged);
            this.cdvToolType.ButtonPress += new System.EventHandler(this.cdvToolType_ButtonPress);
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.Location = new System.Drawing.Point(15, 19);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvToolSts
            // 
            this.cdvToolSts.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolSts.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolSts.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolSts.BtnToolTipText = "";
            this.cdvToolSts.DescText = "";
            this.cdvToolSts.DisplaySubItemIndex = -1;
            this.cdvToolSts.DisplayText = "";
            this.cdvToolSts.Focusing = null;
            this.cdvToolSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolSts.Index = 0;
            this.cdvToolSts.IsViewBtnImage = false;
            this.cdvToolSts.Location = new System.Drawing.Point(120, 64);
            this.cdvToolSts.MaxLength = 10;
            this.cdvToolSts.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolSts.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolSts.Name = "cdvToolSts";
            this.cdvToolSts.ReadOnly = false;
            this.cdvToolSts.SearchSubItemIndex = 0;
            this.cdvToolSts.SelectedDescIndex = -1;
            this.cdvToolSts.SelectedSubItemIndex = -1;
            this.cdvToolSts.SelectionStart = 0;
            this.cdvToolSts.Size = new System.Drawing.Size(200, 20);
            this.cdvToolSts.SmallImageList = null;
            this.cdvToolSts.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolSts.TabIndex = 7;
            this.cdvToolSts.TextBoxToolTipText = "";
            this.cdvToolSts.TextBoxWidth = 200;
            this.cdvToolSts.VisibleButton = true;
            this.cdvToolSts.VisibleColumnHeader = false;
            this.cdvToolSts.VisibleDescription = false;
            this.cdvToolSts.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCond_SelectedItemChanged);
            this.cdvToolSts.ButtonPress += new System.EventHandler(this.cdvToolSts_ButtonPress);
            this.cdvToolSts.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCond_TextBoxKeyPress);
            // 
            // lblSubResID
            // 
            this.lblSubResID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.Location = new System.Drawing.Point(370, 68);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(41, 13);
            this.lblSubResID.TabIndex = 8;
            this.lblSubResID.Text = "Vendor";
            this.lblSubResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToolSts
            // 
            this.lblToolSts.AutoSize = true;
            this.lblToolSts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolSts.Location = new System.Drawing.Point(15, 68);
            this.lblToolSts.Name = "lblToolSts";
            this.lblToolSts.Size = new System.Drawing.Size(61, 13);
            this.lblToolSts.TabIndex = 6;
            this.lblToolSts.Text = "Tool Status";
            this.lblToolSts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvGrade
            // 
            this.cdvGrade.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrade.BtnToolTipText = "";
            this.cdvGrade.DescText = "";
            this.cdvGrade.DisplaySubItemIndex = -1;
            this.cdvGrade.DisplayText = "";
            this.cdvGrade.Focusing = null;
            this.cdvGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrade.Index = 0;
            this.cdvGrade.IsViewBtnImage = false;
            this.cdvGrade.Location = new System.Drawing.Point(120, 40);
            this.cdvGrade.MaxLength = 1;
            this.cdvGrade.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrade.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrade.Name = "cdvGrade";
            this.cdvGrade.ReadOnly = true;
            this.cdvGrade.SearchSubItemIndex = 0;
            this.cdvGrade.SelectedDescIndex = -1;
            this.cdvGrade.SelectedSubItemIndex = -1;
            this.cdvGrade.SelectionStart = 0;
            this.cdvGrade.Size = new System.Drawing.Size(200, 20);
            this.cdvGrade.SmallImageList = null;
            this.cdvGrade.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrade.TabIndex = 3;
            this.cdvGrade.TextBoxToolTipText = "";
            this.cdvGrade.TextBoxWidth = 200;
            this.cdvGrade.VisibleButton = true;
            this.cdvGrade.VisibleColumnHeader = false;
            this.cdvGrade.VisibleDescription = false;
            this.cdvGrade.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCond_SelectedItemChanged);
            this.cdvGrade.ButtonPress += new System.EventHandler(this.cdvGrade_ButtonPress);
            this.cdvGrade.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCond_TextBoxKeyPress);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(15, 44);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 2;
            this.lblGrade.Text = "Grade";
            // 
            // grpOption2
            // 
            this.grpOption2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOption2.Controls.Add(this.optAll);
            this.grpOption2.Controls.Add(this.optAbnormal);
            this.grpOption2.Controls.Add(this.optReturn);
            this.grpOption2.Controls.Add(this.optScrap);
            this.grpOption2.Controls.Add(this.optNormal);
            this.grpOption2.Location = new System.Drawing.Point(3, 95);
            this.grpOption2.Name = "grpOption2";
            this.grpOption2.Size = new System.Drawing.Size(736, 36);
            this.grpOption2.TabIndex = 1;
            this.grpOption2.TabStop = false;
            // 
            // optAll
            // 
            this.optAll.AutoSize = true;
            this.optAll.Location = new System.Drawing.Point(606, 12);
            this.optAll.Name = "optAll";
            this.optAll.Size = new System.Drawing.Size(60, 17);
            this.optAll.TabIndex = 4;
            this.optAll.Text = "All Tool";
            // 
            // optAbnormal
            // 
            this.optAbnormal.AutoSize = true;
            this.optAbnormal.Location = new System.Drawing.Point(419, 12);
            this.optAbnormal.Name = "optAbnormal";
            this.optAbnormal.Size = new System.Drawing.Size(151, 17);
            this.optAbnormal.TabIndex = 3;
            this.optAbnormal.Text = "Scrapped + Returned Tool";
            // 
            // optReturn
            // 
            this.optReturn.AutoSize = true;
            this.optReturn.Location = new System.Drawing.Point(277, 12);
            this.optReturn.Name = "optReturn";
            this.optReturn.Size = new System.Drawing.Size(93, 17);
            this.optReturn.TabIndex = 2;
            this.optReturn.Text = "Returned Tool";
            // 
            // optScrap
            // 
            this.optScrap.AutoSize = true;
            this.optScrap.Location = new System.Drawing.Point(144, 12);
            this.optScrap.Name = "optScrap";
            this.optScrap.Size = new System.Drawing.Size(95, 17);
            this.optScrap.TabIndex = 1;
            this.optScrap.Text = "Scrapped Tool";
            // 
            // optNormal
            // 
            this.optNormal.AutoSize = true;
            this.optNormal.Checked = true;
            this.optNormal.Location = new System.Drawing.Point(24, 12);
            this.optNormal.Name = "optNormal";
            this.optNormal.Size = new System.Drawing.Size(82, 17);
            this.optNormal.TabIndex = 0;
            this.optNormal.TabStop = true;
            this.optNormal.Text = "Normal Tool";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(370, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Tool Set ID";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToolSetID
            // 
            this.txtToolSetID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToolSetID.Location = new System.Drawing.Point(480, 40);
            this.txtToolSetID.MaxLength = 20;
            this.txtToolSetID.Name = "txtToolSetID";
            this.txtToolSetID.Size = new System.Drawing.Size(200, 20);
            this.txtToolSetID.TabIndex = 5;
            this.txtToolSetID.TextChanged += new System.EventHandler(this.txtCond_TextChanged);
            this.txtToolSetID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCond_TextBoxKeyPress);
            // 
            // txtVendor
            // 
            this.txtVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVendor.Location = new System.Drawing.Point(480, 64);
            this.txtVendor.MaxLength = 20;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(200, 20);
            this.txtVendor.TabIndex = 9;
            this.txtVendor.TextChanged += new System.EventHandler(this.txtCond_TextChanged);
            this.txtVendor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCond_TextBoxKeyPress);
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
            this.spdHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdHistory.Location = new System.Drawing.Point(3, 3);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 364);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 1;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 3;
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetViewportTopRow(0, 0, 1);
            this.spdHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 62;
            spdHistory_Sheet1.RowCount = 5;
            this.spdHistory_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdHistory_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tool";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tool Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tool Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tool Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Tool Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tool Set Location";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Sub Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Material";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Operation";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Area ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Sub Area ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tool Location";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Vendor";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Vendor Tool ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Cell Count [X,Y,Z]";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Cell Size [X,Y,Z]";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Grade";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tool_Status_1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tool_Status_2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tool_Status_3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tool_Status_4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tool_Status_5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tool_Status_6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tool_Status_7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tool_Status_8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tool_Status_9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tool_Status_10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tool_Status_11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tool_Status_12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tool_Status_13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Tool_Status_14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Tool_Status_15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Tool_Status_16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Tool_Status_17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Tool_Status_18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Tool_Status_19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Tool_Status_20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Tool_Status_21";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Tool_Status_22";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Tool_Status_23";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Tool_Status_24";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Tool_Status_25";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Tool_Status_26";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Tool_Status_27";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Tool_Status_28";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Tool_Status_29";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Tool_Status_30";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Last Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Last Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Last Tool Event";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Last Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Create User";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Update User";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Update Time";
            this.spdHistory_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tool Type";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).Visible = false;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tool Status";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Tool Group";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Tool Set ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Tool Set Location";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Lot ID";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Sub Lot ID";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Resource";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 112F;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Material";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Operation";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Area ID";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Sub Area ID";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Tool Location";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Vendor";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Vendor Tool ID";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Cell Count [X,Y,Z]";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Cell Size [X,Y,Z]";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Grade";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Tool_Status_1";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Tool_Status_2";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Tool_Status_3";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Tool_Status_4";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Tool_Status_5";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Tool_Status_6";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Tool_Status_7";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Tool_Status_8";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Tool_Status_9";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Tool_Status_10";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Tool_Status_11";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Tool_Status_12";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Tool_Status_13";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Tool_Status_14";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Tool_Status_15";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Tool_Status_16";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Tool_Status_17";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Tool_Status_18";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Tool_Status_19";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Tool_Status_20";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Tool_Status_21";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Tool_Status_22";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Tool_Status_23";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Tool_Status_24";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Tool_Status_25";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "Tool_Status_26";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "Tool_Status_27";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "Tool_Status_28";
            this.spdHistory_Sheet1.Columns.Get(49).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(49).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "Tool_Status_29";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "Tool_Status_30";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Last Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(52).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Last Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(53).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Last Tool Event";
            this.spdHistory_Sheet1.Columns.Get(54).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Last Tran Time";
            this.spdHistory_Sheet1.Columns.Get(55).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 228F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "Create User";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "Update User";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(60).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "Update Time";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Width = 139F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.FrozenRowCount = 1;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmRASViewToolList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASViewToolList";
            this.Text = "View Tool List";
            this.Activated += new System.EventHandler(this.frmRASViewToolList_Activated);
            this.Load += new System.EventHandler(this.frmRASViewToolList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolSts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).EndInit();
            this.grpOption2.ResumeLayout(false);
            this.grpOption2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        private const int COL_HIST_SEQ = 0;
        private const int COL_TOOL_EVENT_ID = 1;
        private const int COL_TOOL_STS_1 = 22;
        private const int COL_TOOL_STS_30 = 51;
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        public bool LoadFlag
        {
            get
            {
                return b_load_flag;
            }
            set
            {
                b_load_flag = value;
            }
        }
        
        #endregion
        
        #region " Function Definition "
        
        //
        // InitCodeView()
        //       - Initalize MCCodeView Control and Make Header Title
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void initCodeView()
        {
            
            spdHistory.Sheets[0].SetColumnAllowAutoSort(0, true);
            
        }
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private void ClearData(char ProcStep)
        {
            int i;
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this, optNormal);
                    
                    MPCF.ClearList(spdHistory, true);
                    MPCF.FitColumnHeader(spdHistory);
                    
                    for (i = COL_TOOL_STS_1; i <= COL_TOOL_STS_30; i++)
                    {
                        spdHistory.Sheets[0].Columns[i].Visible = false;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, i].Text = "";
                    }
                    
                }
                else if (ProcStep == '2')
                {
                    MPCF.ClearList(spdHistory, true);
                    MPCF.FitColumnHeader(spdHistory);
                    
                    for (i = COL_TOOL_STS_1; i <= COL_TOOL_STS_30; i++)
                    {
                        spdHistory.Sheets[0].Columns[i].Visible = false;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, i].Text = "";
                    }
                    
                }
                else if (ProcStep == '3')
                {
                    MPCF.ClearList(spdHistory, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private bool View_Tool_Type()
        {
            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
              
            int i;
            int iCoL;
            
            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvToolType.Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                iCoL = COL_TOOL_STS_1;
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        spdHistory.Sheets[0].Columns[iCoL].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, iCoL].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                    }
                    iCoL++;
                }
                
                MPCF.FitColumnHeader(spdHistory);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // ViewToolList_Detail_Local()
        //       - View Tool List (Local)
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void ViewToolList_Detail_Local()
        {
            char sDeleteFlag = ' ';
            
            if (CheckCondition("View_Tool_List_Detail") == true)
            {
                if (spdHistory.Sheets[0].RowCount > 0)
                {
                    ClearData('3');
                }
                
                if (optNormal.Checked == true)
                {
                    sDeleteFlag = 'N';
                }
                else if (optScrap.Checked == true)
                {
                    sDeleteFlag = 'S';
                }
                else if (optReturn.Checked == true)
                {
                    sDeleteFlag = 'R';
                }
                else if (optAbnormal.Checked == true)
                {
                    sDeleteFlag = 'Y';
                }

                if (RASLIST.ViewToolList_Detail(spdHistory, '1', cdvToolType.Text, "", txtToolSetID.Text, cdvToolSts.Text, "", "", "", "", "", 0, "", "", "", "", txtVendor.Text, MPCF.ToChar(cdvGrade.Text), sDeleteFlag, null, false) == false)
                {
                    return;
                }
                
                if (spdHistory.Sheets[0].RowCount > 0)
                {
                    MPCF.FitColumnHeader(spdHistory);
                }
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

            if (MPCF.CheckValue(cdvToolType, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "View_Tool_List_Detail":
                    
                    break;
                    //Do Nothing
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvToolType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASViewToolList_Load(System.Object sender, System.EventArgs e)
        {
            initCodeView();
        }
        
        private void frmRASViewToolList_Activated(object sender, System.EventArgs e)
        {
            
            if (LoadFlag == false)
            {
                ClearData('1');
                LoadFlag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            ViewToolList_Detail_Local();
        }
        
        private void cdvCond_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            ClearData('3');
            if (cdvToolType.Text == "")
            {
                return;
            }
            btnView_Click(null, null);
            
        }
        
        private void cdvCond_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (((System.Windows.Forms.KeyPressEventArgs) e).KeyChar == (char)13)
            {
                btnView_Click(null, null);
            }
            else
            {
                ClearData('3');
            }
            
        }
        
        private void txtCond_TextChanged(System.Object sender, System.EventArgs e)
        {
            ClearData('3');
            //If Trim(cdvToolType.Text) = "" Then Exit Sub
            //btnView_Click(Nothing, Nothing)
        }
        
        private void cdvGrade_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvGrade.Init();
            MPCF.InitListView(cdvGrade.GetListView);
            cdvGrade.Columns.Add("Grade", 50, HorizontalAlignment.Left);
            cdvGrade.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrade.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvGrade.GetListView, '1', MPGC.MP_RAS_TOOL_GRADE) == true)
            {
                cdvGrade.AddEmptyRow(1);
            }
        }
        
        private void cdvToolSts_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvToolSts.Init();
            MPCF.InitListView(cdvToolSts.GetListView);
            cdvToolSts.Columns.Add("Tool Status", 50, HorizontalAlignment.Left);
            cdvToolSts.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolSts.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvToolSts.GetListView, '1', MPGC.MP_RAS_TOOL_STATUS) == true)
            {
                cdvToolSts.AddEmptyRow(1);
            }
        }
        
        private void cdvToolType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolType.Text != "")
            {
                View_Tool_Type();
            }
        }
        
        private void cdvToolType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToolType.Init();
            MPCF.InitListView(cdvToolType.GetListView);
            cdvToolType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvToolType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolType.SelectedSubItemIndex = 0;
            RASLIST.ViewToolTypeList(cdvToolType.GetListView, '1', 'N', 'N', null);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Tool Type : " + MPCF.Trim(cdvToolType.Text) + "\r";
            sCond = sCond + "Grade : " + MPCF.Trim(cdvGrade.Text) + "\r";
            sCond = sCond + "Tool Status : " + MPCF.Trim(cdvToolSts.Text) + "\r";
            sCond = sCond + "Tool Set ID : " + MPCF.Trim(txtToolSetID.Text) + "\r";
            sCond = sCond + "Vendor : " + MPCF.Trim(txtVendor.Text) + "\r";
            
            if (optNormal.Checked == true)
            {
                sCond = sCond + "* " + optNormal.Text + "\r";
            }
            else if (optScrap.Checked == true)
            {
                sCond = sCond + "* " + optScrap.Text + "\r";
            }
            else if (optReturn.Checked == true)
            {
                sCond = sCond + "* " + optReturn.Text + "\r";
            }
            else if (optAbnormal.Checked == true)
            {
                sCond = sCond + "* " + optAbnormal.Text + "\r";
            }
            else if (optAll.Checked == true)
            {
                sCond = sCond + "* " + optAll.Text + "\r";
            }

            MPCF.ExportToExcel(spdHistory, this.Text, sCond);
            
        }
        
    }
    
    //#End If
}
