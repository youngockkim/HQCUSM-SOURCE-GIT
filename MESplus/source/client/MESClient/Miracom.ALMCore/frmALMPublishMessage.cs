using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

//#If _ALM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmALMPublishMessage.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-08-10 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.ALMCore
{
    public class frmALMPublishMessage : Miracom.CliFrx.BaseForm04
    {
        
        #region " Windows Form auto generated code "
        
        public frmALMPublishMessage()
        {
            InitializeComponent();
            this.spdAlarm.Tag = "Change Cell";
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

        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Button btnAck;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private TabControl tabAlarm;
        private TabPage tbpGeneral;
        private TabPage tbpList;
        private FarPoint.Win.Spread.FpSpread spdAlarm;
        private FarPoint.Win.Spread.SheetView spdAlarm_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private CheckBox chkSelAll;
        private System.Windows.Forms.Timer tmrTimer;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmALMPublishMessage));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder7 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder8 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder9 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder10 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder11 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder12 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder13 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType1 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType19 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType20 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType21 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType22 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType23 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType24 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType25 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType26 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType27 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType28 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType29 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType30 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType31 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType32 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType33 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAck = new System.Windows.Forms.Button();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.tabAlarm = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.spdAlarm = new FarPoint.Win.Spread.FpSpread();
            this.spdAlarm_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpList = new System.Windows.Forms.TabPage();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.chkSelAll = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabAlarm.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAlarm_Sheet1)).BeginInit();
            this.tbpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkSelAll);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnAck);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnAck, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkAutoRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkSelAll, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabAlarm);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Alarm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(4, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAck
            // 
            this.btnAck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAck.Location = new System.Drawing.Point(558, 7);
            this.btnAck.Name = "btnAck";
            this.btnAck.Size = new System.Drawing.Size(88, 26);
            this.btnAck.TabIndex = 3;
            this.btnAck.Text = "Acknowledge";
            this.btnAck.Click += new System.EventHandler(this.btnAck_Click);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoRefresh.Location = new System.Drawing.Point(33, 11);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(94, 18);
            this.chkAutoRefresh.TabIndex = 1;
            this.chkAutoRefresh.Text = "Auto Refresh";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // tabAlarm
            // 
            this.tabAlarm.Controls.Add(this.tbpGeneral);
            this.tabAlarm.Controls.Add(this.tbpList);
            this.tabAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAlarm.Location = new System.Drawing.Point(3, 3);
            this.tabAlarm.Name = "tabAlarm";
            this.tabAlarm.SelectedIndex = 0;
            this.tabAlarm.Size = new System.Drawing.Size(736, 510);
            this.tabAlarm.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.spdAlarm);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 484);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // spdAlarm
            // 
            this.spdAlarm.AccessibleDescription = "spdAlarm, Sheet1, Row 0, Column 0, ";
            this.spdAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAlarm.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAlarm.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAlarm.HorizontalScrollBar.Name = "";
            this.spdAlarm.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAlarm.HorizontalScrollBar.TabIndex = 34;
            this.spdAlarm.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAlarm.Location = new System.Drawing.Point(3, 3);
            this.spdAlarm.Name = "spdAlarm";
            this.spdAlarm.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAlarm.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAlarm.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAlarm_Sheet1});
            this.spdAlarm.Size = new System.Drawing.Size(722, 478);
            this.spdAlarm.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAlarm.TabIndex = 0;
            this.spdAlarm.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAlarm.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAlarm.VerticalScrollBar.Name = "";
            this.spdAlarm.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAlarm.VerticalScrollBar.TabIndex = 35;
            this.spdAlarm.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAlarm.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAlarm_ButtonClicked);
            // 
            // spdAlarm_Sheet1
            // 
            this.spdAlarm_Sheet1.Reset();
            spdAlarm_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAlarm_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAlarm_Sheet1.ColumnCount = 9;
            spdAlarm_Sheet1.RowCount = 8;
            textCellType1.Multiline = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 0).CellType = textCellType1;
            this.spdAlarm_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.spdAlarm_Sheet1.Cells.Get(0, 0).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 0).RowSpan = 7;
            this.spdAlarm_Sheet1.Cells.Get(0, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(0, 1).Border = bevelBorder1;
            this.spdAlarm_Sheet1.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(0, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 1).Value = "Subject";
            textCellType2.MaxLength = 1000;
            textCellType2.Multiline = true;
            textCellType2.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 2).CellType = textCellType2;
            this.spdAlarm_Sheet1.Cells.Get(0, 2).ColumnSpan = 7;
            this.spdAlarm_Sheet1.Cells.Get(0, 2).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(0, 5).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(1, 1).Border = bevelBorder2;
            this.spdAlarm_Sheet1.Cells.Get(1, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(1, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 1).Value = "Message";
            textCellType3.MaxLength = 1000;
            textCellType3.Multiline = true;
            textCellType3.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 2).CellType = textCellType3;
            this.spdAlarm_Sheet1.Cells.Get(1, 2).ColumnSpan = 7;
            this.spdAlarm_Sheet1.Cells.Get(1, 2).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(1, 5).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(2, 1).Border = bevelBorder3;
            this.spdAlarm_Sheet1.Cells.Get(2, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(2, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 1).Value = "Comments";
            textCellType4.MaxLength = 5000;
            textCellType4.Multiline = true;
            textCellType4.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 2).CellType = textCellType4;
            this.spdAlarm_Sheet1.Cells.Get(2, 2).ColumnSpan = 7;
            this.spdAlarm_Sheet1.Cells.Get(2, 2).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(2, 5).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(3, 1).Border = bevelBorder4;
            this.spdAlarm_Sheet1.Cells.Get(3, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(3, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 1).Value = "Source 1";
            textCellType5.Multiline = true;
            textCellType5.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 2).CellType = textCellType5;
            this.spdAlarm_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.spdAlarm_Sheet1.Cells.Get(3, 2).Locked = true;
            textCellType6.Multiline = true;
            textCellType6.ReadOnly = true;
            textCellType6.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 3).CellType = textCellType6;
            this.spdAlarm_Sheet1.Cells.Get(3, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 4).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(3, 4).Border = bevelBorder5;
            this.spdAlarm_Sheet1.Cells.Get(3, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 4).Value = "Source 2";
            textCellType7.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 5).CellType = textCellType7;
            this.spdAlarm_Sheet1.Cells.Get(3, 5).ColumnSpan = 2;
            this.spdAlarm_Sheet1.Cells.Get(3, 5).Locked = true;
            textCellType8.ReadOnly = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 6).CellType = textCellType8;
            this.spdAlarm_Sheet1.Cells.Get(3, 6).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 7).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(3, 7).Border = bevelBorder6;
            this.spdAlarm_Sheet1.Cells.Get(3, 7).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 7).Value = "Source 3";
            textCellType9.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(3, 8).CellType = textCellType9;
            this.spdAlarm_Sheet1.Cells.Get(3, 8).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(4, 1).Border = bevelBorder7;
            this.spdAlarm_Sheet1.Cells.Get(4, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(4, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 1).Value = "Desc 1";
            textCellType10.Multiline = true;
            textCellType10.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 2).CellType = textCellType10;
            this.spdAlarm_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdAlarm_Sheet1.Cells.Get(4, 2).Locked = true;
            textCellType11.Multiline = true;
            textCellType11.ReadOnly = true;
            textCellType11.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 3).CellType = textCellType11;
            this.spdAlarm_Sheet1.Cells.Get(4, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 4).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(4, 4).Border = bevelBorder8;
            this.spdAlarm_Sheet1.Cells.Get(4, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 4).Value = "Desc 2";
            textCellType12.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 5).CellType = textCellType12;
            this.spdAlarm_Sheet1.Cells.Get(4, 5).ColumnSpan = 2;
            this.spdAlarm_Sheet1.Cells.Get(4, 5).Locked = true;
            textCellType13.ReadOnly = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 6).CellType = textCellType13;
            this.spdAlarm_Sheet1.Cells.Get(4, 6).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 7).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(4, 7).Border = bevelBorder9;
            this.spdAlarm_Sheet1.Cells.Get(4, 7).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 7).Value = "Desc 3";
            textCellType14.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(4, 8).CellType = textCellType14;
            this.spdAlarm_Sheet1.Cells.Get(4, 8).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 1).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(5, 1).Border = bevelBorder10;
            this.spdAlarm_Sheet1.Cells.Get(5, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdAlarm_Sheet1.Cells.Get(5, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 1).Value = "Level";
            textCellType15.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 2).CellType = textCellType15;
            this.spdAlarm_Sheet1.Cells.Get(5, 2).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 3).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(5, 3).Border = bevelBorder11;
            this.spdAlarm_Sheet1.Cells.Get(5, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 3).Value = "Type";
            textCellType16.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 4).CellType = textCellType16;
            this.spdAlarm_Sheet1.Cells.Get(5, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 5).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(5, 5).Border = bevelBorder12;
            this.spdAlarm_Sheet1.Cells.Get(5, 5).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 5).Value = "Lot ID";
            textCellType17.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 6).CellType = textCellType17;
            this.spdAlarm_Sheet1.Cells.Get(5, 6).Locked = false;
            this.spdAlarm_Sheet1.Cells.Get(5, 6).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.spdAlarm_Sheet1.Cells.Get(5, 6).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.spdAlarm_Sheet1.Cells.Get(5, 6).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.spdAlarm_Sheet1.Cells.Get(5, 6).ParseFormatString = "n";
            this.spdAlarm_Sheet1.Cells.Get(5, 7).BackColor = System.Drawing.SystemColors.Control;
            this.spdAlarm_Sheet1.Cells.Get(5, 7).Border = bevelBorder13;
            this.spdAlarm_Sheet1.Cells.Get(5, 7).Locked = false;
            this.spdAlarm_Sheet1.Cells.Get(5, 7).Value = "Resource";
            textCellType18.WordWrap = true;
            this.spdAlarm_Sheet1.Cells.Get(5, 8).CellType = textCellType18;
            this.spdAlarm_Sheet1.Cells.Get(5, 8).Locked = true;
            imageCellType1.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType1.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType1.TransparencyTolerance = 0;
            this.spdAlarm_Sheet1.Cells.Get(6, 0).CellType = imageCellType1;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.ShadowSize = 2;
            this.spdAlarm_Sheet1.Cells.Get(6, 1).CellType = buttonCellType1;
            this.spdAlarm_Sheet1.Cells.Get(6, 1).ColumnSpan = 8;
            this.spdAlarm_Sheet1.Cells.Get(6, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAlarm_Sheet1.Cells.Get(6, 1).Locked = false;
            this.spdAlarm_Sheet1.Cells.Get(7, 0).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 0).ColumnSpan = 9;
            this.spdAlarm_Sheet1.Cells.Get(7, 0).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 1).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 1).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 2).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 2).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 3).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 3).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 4).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 4).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 5).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 5).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 6).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 6).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 7).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 7).Locked = true;
            this.spdAlarm_Sheet1.Cells.Get(7, 8).BackColor = System.Drawing.Color.Black;
            this.spdAlarm_Sheet1.Cells.Get(7, 8).Locked = true;
            this.spdAlarm_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAlarm_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAlarm_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAlarm_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAlarm_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdAlarm_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAlarm_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAlarm_Sheet1.ColumnHeader.Rows.Get(0).Height = 8F;
            this.spdAlarm_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(0).Width = 100F;
            this.spdAlarm_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(1).Locked = true;
            this.spdAlarm_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(2).Width = 90F;
            this.spdAlarm_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(6).Width = 90F;
            this.spdAlarm_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAlarm_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAlarm_Sheet1.Columns.Get(8).Width = 110F;
            this.spdAlarm_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAlarm_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdAlarm_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAlarm_Sheet1.RowHeader.Columns.Get(0).Width = 8F;
            this.spdAlarm_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAlarm_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAlarm_Sheet1.Rows.Get(7).Height = 5F;
            this.spdAlarm_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAlarm_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAlarm_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpList
            // 
            this.tbpList.Controls.Add(this.spdList);
            this.tbpList.Location = new System.Drawing.Point(4, 22);
            this.tbpList.Name = "tbpList";
            this.tbpList.Padding = new System.Windows.Forms.Padding(3);
            this.tbpList.Size = new System.Drawing.Size(728, 484);
            this.tbpList.TabIndex = 1;
            this.tbpList.Text = "List";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdList.HorizontalScrollBar.TabIndex = 10;
            this.spdList.Location = new System.Drawing.Point(3, 3);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(722, 478);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdList.VerticalScrollBar.TabIndex = 11;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 15;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Level";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Alarm ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Subject";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Message";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Comments";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Resource";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Issue Date\r\n";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Source 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Desc 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Source 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Desc 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Source 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Desc 3";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType19.Multiline = true;
            textCellType19.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(0).CellType = textCellType19;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(0).Label = "Level";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 50F;
            textCellType20.Multiline = true;
            textCellType20.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(1).CellType = textCellType20;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(1).Label = "Type";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType21.Multiline = true;
            textCellType21.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(2).CellType = textCellType21;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "Alarm ID";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 100F;
            textCellType22.Multiline = true;
            textCellType22.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(3).CellType = textCellType22;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(3).Label = "Subject";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 150F;
            textCellType23.MaxLength = 1000;
            textCellType23.Multiline = true;
            textCellType23.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(4).CellType = textCellType23;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Message";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 200F;
            textCellType24.MaxLength = 5000;
            textCellType24.Multiline = true;
            textCellType24.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(5).CellType = textCellType24;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(5).Label = "Comments";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 200F;
            textCellType25.Multiline = true;
            textCellType25.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(6).CellType = textCellType25;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(6).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 100F;
            textCellType26.Multiline = true;
            textCellType26.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(7).CellType = textCellType26;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(7).Label = "Resource";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 100F;
            textCellType27.Multiline = true;
            textCellType27.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(8).CellType = textCellType27;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(8).Label = "Issue Date\r\n";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 130F;
            textCellType28.Multiline = true;
            textCellType28.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(9).CellType = textCellType28;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(9).Label = "Source 1";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 100F;
            textCellType29.Multiline = true;
            textCellType29.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(10).CellType = textCellType29;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(10).Label = "Desc 1";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 100F;
            textCellType30.Multiline = true;
            textCellType30.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(11).CellType = textCellType30;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(11).Label = "Source 2";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 100F;
            textCellType31.Multiline = true;
            textCellType31.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(12).CellType = textCellType31;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(12).Label = "Desc 2";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 100F;
            textCellType32.Multiline = true;
            textCellType32.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(13).CellType = textCellType32;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(13).Label = "Source 3";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 100F;
            textCellType33.Multiline = true;
            textCellType33.WordWrap = true;
            this.spdList_Sheet1.Columns.Get(14).CellType = textCellType33;
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(14).Label = "Desc 3";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkSelAll
            // 
            this.chkSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSelAll.AutoSize = true;
            this.chkSelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSelAll.Location = new System.Drawing.Point(410, 11);
            this.chkSelAll.Name = "chkSelAll";
            this.chkSelAll.Size = new System.Drawing.Size(105, 18);
            this.chkSelAll.TabIndex = 2;
            this.chkSelAll.Text = "Select All Alarm";
            // 
            // frmALMPublishMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmALMPublishMessage";
            this.Text = "Alarm";
            this.Activated += new System.EventHandler(this.frmALMPublishMessage_Activated);
            this.Load += new System.EventHandler(this.frmALMPublishMessage_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabAlarm.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAlarm_Sheet1)).EndInit();
            this.tbpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        public bool b_load_flag;
        public string sAlarmType;
        public string sAlarmID;
        public string sSourceID1;
        public string sResID;
        public string sTranTime;
        
        #endregion
        
        #region "Function Definition"
        //
        // Ack_Alarm()
        //       - Acknowldge Lot Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Ack_Alarm(int iIndex)
        {
            int i;
            int j;

            TRSNode in_node = new TRSNode("ACK_ALARM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");


            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ALARM_ID", MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 2].Value));
                in_node.AddString("SOURCE_ID_1", MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 9].Value));
                in_node.AddString("TRAN_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 8].Tag));
                in_node.AddString("ACK_USER_ID", MPGV.gsUserID);

                if (MPCR.CallService("ALM", "ALM_Ack_Alarm", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < MPGV.giAlarmCnt; i++)
                {
                    if (MPGV.gtAlarmList[i].alarm_level.ToString() == MPCF.Mid(MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 0].Value), 0, 1) &&
                        MPGV.gtAlarmList[i].alarm_type.ToString() == MPCF.Mid(MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 1].Value), 0, 1) &&
                        MPGV.gtAlarmList[i].source_id_1 == MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 9].Value) &&
                        MPGV.gtAlarmList[i].create_time == MPCF.Trim(spdList.ActiveSheet.Cells[iIndex, 8].Tag))
                    {
                        for (j = i; j < MPGV.giAlarmCnt - 1; j++)
                        {
                            MPGV.gtAlarmList[j] = MPGV.gtAlarmList[j + 1];
                        }
                        MPGV.giAlarmCnt--;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        public bool ViewAlarmList()
        {
            int i, k;
            int i_row, i_list_row;
            string sAlarmLevel;
            string sAlarmType;
            string sComment;
            string sIssueDate;

            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType;

            try
            {
                spdAlarm.ActiveSheet.RowCount = 8;
                for (i = 0; i < 7; i++)
                {
                    spdAlarm.ActiveSheet.Rows[i].Height = 20;
                }
                spdAlarm.ActiveSheet.Rows[7].Height = 5;

                spdAlarm.ActiveSheet.Cells[0, 0].Value = null;
                spdAlarm.ActiveSheet.Cells[0, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[1, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[2, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[3, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[4, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[3, 5].Value = null;
                spdAlarm.ActiveSheet.Cells[4, 5].Value = null;
                spdAlarm.ActiveSheet.Cells[3, 8].Value = null;
                spdAlarm.ActiveSheet.Cells[4, 8].Value = null;
                spdAlarm.ActiveSheet.Cells[5, 2].Value = null;
                spdAlarm.ActiveSheet.Cells[5, 4].Value = null;
                spdAlarm.ActiveSheet.Cells[5, 6].Value = null;
                spdAlarm.ActiveSheet.Cells[5, 8].Value = null;
                spdAlarm.ActiveSheet.Cells[6, 1].Tag = null;
                btnCellType = (FarPoint.Win.Spread.CellType.ButtonCellType)spdAlarm.ActiveSheet.Cells[6, 1].CellType;
                btnCellType.Text = "";


                /** spdList *************************/
                MPCF.ClearList(spdList);
                /** spdList *************************/


                if (MPGV.giAlarmCnt > 0)
                {
                    i_row = 0;
                    for (i = 1; i < MPGV.giAlarmCnt; i++)
                    {
                        spdAlarm.ActiveSheet.RowCount += 8;
                        spdAlarm.ActiveSheet.CopyRange(0, 0, i_row + 8, 0, 8, 9, false);
                        i_row += 8;
                        spdAlarm.ActiveSheet.Rows[i_row + 7].Height = 5;
                    }
                }
                else
                {
                    for (i = 0; i < 8; i++)
                    {
                        spdAlarm.ActiveSheet.Rows[i].Height = 0;
                    }
                }

                i_row = 0;
                for (i = 0; i < MPGV.giAlarmCnt; i++)
                {
                    if (MPGV.gtAlarmList[i].alarm_level == MPGC.MP_ALM_LEVEL_ERROR)
                        sAlarmLevel = "Error";
                    else if (MPGV.gtAlarmList[i].alarm_level == MPGC.MP_ALM_LEVEL_WARN)
                        sAlarmLevel = "Warning";
                    else
                        sAlarmLevel = "Info";

                    if (MPGV.gtAlarmList[i].alarm_type == MPGC.MP_ALM_NORMAL)
                        sAlarmType = "Normal";
                    else
                        sAlarmType = "Resource";

                    sComment = "";
                    if (MPCF.Trim(MPGV.gtAlarmList[i].alarm_comment_1) != "")
                    {
                        sComment += MPGV.gtAlarmList[i].alarm_comment_1;
                    }
                    if (MPCF.Trim(MPGV.gtAlarmList[i].alarm_comment_2) != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += MPGV.gtAlarmList[i].alarm_comment_2;
                    }
                    if (MPCF.Trim(MPGV.gtAlarmList[i].alarm_comment_3) != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += MPGV.gtAlarmList[i].alarm_comment_3;
                    }
                    if (MPCF.Trim(MPGV.gtAlarmList[i].alarm_comment_4) != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += MPGV.gtAlarmList[i].alarm_comment_4;
                    }
                    if (MPCF.Trim(MPGV.gtAlarmList[i].alarm_comment_5) != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += MPGV.gtAlarmList[i].alarm_comment_5;
                    }

                    spdAlarm.ActiveSheet.Cells[0 + i_row, 0].Value = MPGV.gtAlarmList[i].alarm_id;
                    spdAlarm.ActiveSheet.Cells[0 + i_row, 2].Value = MPGV.gtAlarmList[i].alarm_subject;
                    spdAlarm.ActiveSheet.Cells[1 + i_row, 2].Value = MPGV.gtAlarmList[i].alarm_msg;
                    spdAlarm.ActiveSheet.Cells[2 + i_row, 2].Value = sComment;
                    spdAlarm.ActiveSheet.Cells[3 + i_row, 2].Value = MPGV.gtAlarmList[i].source_id_1;
                    spdAlarm.ActiveSheet.Cells[4 + i_row, 2].Value = MPGV.gtAlarmList[i].source_desc_1;
                    spdAlarm.ActiveSheet.Cells[3 + i_row, 5].Value = MPGV.gtAlarmList[i].source_id_2;
                    spdAlarm.ActiveSheet.Cells[4 + i_row, 5].Value = MPGV.gtAlarmList[i].source_desc_2;
                    spdAlarm.ActiveSheet.Cells[3 + i_row, 8].Value = MPGV.gtAlarmList[i].source_id_3;
                    spdAlarm.ActiveSheet.Cells[4 + i_row, 8].Value = MPGV.gtAlarmList[i].source_desc_3;
                    spdAlarm.ActiveSheet.Cells[5 + i_row, 2].Value = sAlarmLevel;
                    spdAlarm.ActiveSheet.Cells[5 + i_row, 4].Value = sAlarmType;
                    spdAlarm.ActiveSheet.Cells[5 + i_row, 6].Value = MPGV.gtAlarmList[i].lot_id;
                    spdAlarm.ActiveSheet.Cells[5 + i_row, 8].Value = MPGV.gtAlarmList[i].res_id;

                    if (MPGV.gtAlarmList[i].img_data == null)
                    {
                        spdAlarm.ActiveSheet.Rows[6 + i_row].Visible = false;
                    }
                    else
                    {
                        MemoryStream ms_buffer;

                        try
                        {
                            ms_buffer = new MemoryStream();
                            ms_buffer.Write(MPGV.gtAlarmList[i].img_data, 0, MPGV.gtAlarmList[i].img_data.Length);
                            ms_buffer.Position = 0;

                            btnCellType = (FarPoint.Win.Spread.CellType.ButtonCellType)spdAlarm.ActiveSheet.Cells[6 + i_row, 1].CellType;
                            btnCellType.Text = MPCF.FindLanguage("Show Image", CAPTION_TYPE.BUTTON);
                            spdAlarm.ActiveSheet.Cells[6 + i_row, 1].Tag = ms_buffer;
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                        }
                    }

                    if (MPGV.gtAlarmList[i].pdf_data != null)
                    {
                    }

                    int i_seq = 0;
                    for (k = i_row; k < i_row + 7; k++)
                    {
                        if (i_seq > 2)
                        {
                            spdAlarm.ActiveSheet.Rows[k].Height = spdAlarm.ActiveSheet.GetPreferredRowHeight(k);
                        }
                        else
                        {
                            Size sz = spdAlarm.ActiveSheet.GetPreferredCellSize(k, 2);
                            float f_cell_width = sz.Width * ((sz.Height / 20) + 1);
                            int i_span_count = spdAlarm.ActiveSheet.Cells[k, 2].ColumnSpan;
                            float f_cell_width_spaned = 0;

                            for (int mm = 0; mm < i_span_count; mm++)
                            {
                                f_cell_width_spaned += spdAlarm.ActiveSheet.Columns[2 + mm].Width;
                            }

                            spdAlarm.ActiveSheet.Rows[k].Height = 20 * (int)((f_cell_width / f_cell_width_spaned) + 1);
                        }
                        i_seq++;
                    }

                    i_row += 8;

                    /** spdList *************************/
                    sIssueDate = MPCF.MakeDateFormat(MPGV.gtAlarmList[i].create_time);

                    i_list_row = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    spdList.ActiveSheet.Cells[i_list_row, 0].Value = sAlarmLevel;
                    spdList.ActiveSheet.Cells[i_list_row, 1].Value = sAlarmType;
                    spdList.ActiveSheet.Cells[i_list_row, 2].Value = MPGV.gtAlarmList[i].alarm_id;
                    spdList.ActiveSheet.Cells[i_list_row, 3].Value = MPGV.gtAlarmList[i].alarm_subject;
                    spdList.ActiveSheet.Cells[i_list_row, 4].Value = MPGV.gtAlarmList[i].alarm_msg;
                    spdList.ActiveSheet.Cells[i_list_row, 5].Value = sComment;
                    spdList.ActiveSheet.Cells[i_list_row, 6].Value = MPGV.gtAlarmList[i].lot_id;
                    spdList.ActiveSheet.Cells[i_list_row, 7].Value = MPGV.gtAlarmList[i].res_id;
                    spdList.ActiveSheet.Cells[i_list_row, 8].Value = sIssueDate;
                    spdList.ActiveSheet.Cells[i_list_row, 8].Tag = MPGV.gtAlarmList[i].create_time;
                    spdList.ActiveSheet.Cells[i_list_row, 9].Value = MPGV.gtAlarmList[i].source_id_1;
                    spdList.ActiveSheet.Cells[i_list_row, 10].Value = MPGV.gtAlarmList[i].source_desc_1;
                    spdList.ActiveSheet.Cells[i_list_row, 11].Value = MPGV.gtAlarmList[i].source_id_2;
                    spdList.ActiveSheet.Cells[i_list_row, 12].Value = MPGV.gtAlarmList[i].source_desc_2;
                    spdList.ActiveSheet.Cells[i_list_row, 13].Value = MPGV.gtAlarmList[i].source_id_3;
                    spdList.ActiveSheet.Cells[i_list_row, 14].Value = MPGV.gtAlarmList[i].source_desc_3;

                    spdList.ActiveSheet.Rows[i_list_row].Height = spdList.ActiveSheet.GetPreferredRowHeight(i_list_row);
                    /** spdList *************************/

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        #endregion
        
        private void frmALMPublishMessage_Load(object sender, System.EventArgs e)
        {
            try
            {
                chkAutoRefresh.Checked = false;
                if (MPGV.giAutoRefreshTime > 0)
                {
                    chkAutoRefresh.Checked = MPGV.gbAutoRefresh;
                    tmrTimer.Interval = MPGV.giAutoRefreshTime * 1000;
                }
                
                if (chkAutoRefresh.Checked == true)
                {
                    tmrTimer.Start();
                }
                else
                {
                    tmrTimer.Stop();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmALMPublishMessage_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (ViewAlarmList() == false)
                    {
                        return;
                    }
                    b_load_flag = true;
                }
                else
                {
                    if (chkAutoRefresh.Checked == true)
                    {
                        ViewAlarmList();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnAck_Click(System.Object sender, System.EventArgs e)
        {
            int i, k;
            FarPoint.Win.Spread.Model.CellRange[] cr;

            if (chkSelAll.Checked == false)
            {
                cr = spdList.ActiveSheet.GetSelections();
                if (cr.Length < 1) return;

                for (i = 0; i < cr.Length; i++)
                {
                    for (k = 0; k < cr[i].RowCount; k++)
                    {
                        if (Ack_Alarm(cr[i].Row + k) == false) return;
                    }
                }
                for (i = cr.Length - 1; i >= 0; i--)
                {
                    for (k = cr[i].RowCount - 1; k >= 0; k--)
                    {
                        spdList.ActiveSheet.Rows[cr[i].Row + k].Remove();
                    }
                }
            }
            else
            {
                if (spdList.ActiveSheet.RowCount < 1) return;

                for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
                {
                    if (Ack_Alarm(i) == false) return;
                }
            }

            MPCF.ShowMsgBox(MPCF.GetMessage(52));

            ViewAlarmList();
            MPGV.gIMdiForm.SetAlarmMessage();
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            ViewAlarmList();
        }
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
			/* 2013.06.12. Aiden. Middleware 가 사용가능한지 확인 */
            if (MPIF.gInit.IsAvailableSendMessage == true)
            {
                ViewAlarmList();
            }
        }

        private void spdAlarm_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            MemoryStream ms_buffer;

            if (e.Column != 1) return;

            if ((ms_buffer = (MemoryStream)spdAlarm.ActiveSheet.Cells[e.Row, 1].Tag) != null)
            {
                frmALMPublishMessageSub frmImage = new frmALMPublishMessageSub();
                frmImage.SetImage(ms_buffer);
                frmImage.ShowDialog(this);
            }
        }

        
    }
    //#End If
}
