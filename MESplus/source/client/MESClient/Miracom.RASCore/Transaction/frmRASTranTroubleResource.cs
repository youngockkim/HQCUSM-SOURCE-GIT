
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
//   File Name   : frmRASTranTroubleResource.vb
//   Description : Trouble Resource Data Input
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
//       - 2004-08-12 : Created by Chanmo Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------



namespace Miracom.RASCore
{
    public class frmRASTranTroubleResource : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranTroubleResource()
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
        



        private System.Windows.Forms.Panel pnlTroubleTop;
        private System.Windows.Forms.GroupBox grpResInfo;
        private System.Windows.Forms.Panel pnlResInfoMain;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        private System.Windows.Forms.Panel pnlResID;
        private System.Windows.Forms.Label lblResID;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        private System.Windows.Forms.Panel pnlTroubleMid;
        private System.Windows.Forms.GroupBox grpTroubleInfo;
        private System.Windows.Forms.TextBox txtComment1;
        private System.Windows.Forms.TextBox txtComment3;
        private System.Windows.Forms.TextBox txtComment2;
        private System.Windows.Forms.CheckBox chkComment3;
        private System.Windows.Forms.Label lblComment3;
        private System.Windows.Forms.CheckBox chkComment2;
        private System.Windows.Forms.Label lblComment2;
        private System.Windows.Forms.CheckBox chkComment1;
        private System.Windows.Forms.Label lblComment1;
        internal System.Windows.Forms.TextBox txtResID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlTroubleTop = new System.Windows.Forms.Panel();
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.pnlResInfoMain = new System.Windows.Forms.Panel();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlResID = new System.Windows.Forms.Panel();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlTroubleMid = new System.Windows.Forms.Panel();
            this.grpTroubleInfo = new System.Windows.Forms.GroupBox();
            this.chkComment3 = new System.Windows.Forms.CheckBox();
            this.lblComment3 = new System.Windows.Forms.Label();
            this.chkComment2 = new System.Windows.Forms.CheckBox();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.chkComment1 = new System.Windows.Forms.CheckBox();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.txtComment1 = new System.Windows.Forms.TextBox();
            this.txtComment3 = new System.Windows.Forms.TextBox();
            this.txtComment2 = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTroubleTop.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            this.pnlResInfoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.pnlResID.SuspendLayout();
            this.pnlTroubleMid.SuspendLayout();
            this.grpTroubleInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlTroubleMid);
            this.pnlCenter.Controls.Add(this.pnlTroubleTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Trouble Resource";
            // 
            // pnlTroubleTop
            // 
            this.pnlTroubleTop.Controls.Add(this.grpResInfo);
            this.pnlTroubleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTroubleTop.Location = new System.Drawing.Point(3, 0);
            this.pnlTroubleTop.Name = "pnlTroubleTop";
            this.pnlTroubleTop.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTroubleTop.Size = new System.Drawing.Size(736, 172);
            this.pnlTroubleTop.TabIndex = 0;
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.pnlResInfoMain);
            this.grpResInfo.Controls.Add(this.pnlResID);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(0, 5);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(736, 167);
            this.grpResInfo.TabIndex = 0;
            this.grpResInfo.TabStop = false;
            this.grpResInfo.Text = "Resource Information";
            // 
            // pnlResInfoMain
            // 
            this.pnlResInfoMain.Controls.Add(this.spdResInfo);
            this.pnlResInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResInfoMain.Location = new System.Drawing.Point(3, 46);
            this.pnlResInfoMain.Name = "pnlResInfoMain";
            this.pnlResInfoMain.Size = new System.Drawing.Size(730, 118);
            this.pnlResInfoMain.TabIndex = 1;
            // 
            // spdResInfo
            // 
            this.spdResInfo.About = "2.5.2008.2005";
            this.spdResInfo.AccessibleDescription = "";
            this.spdResInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdResInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdResInfo.Location = new System.Drawing.Point(0, 0);
            this.spdResInfo.MoveActiveOnFocus = false;
            this.spdResInfo.Name = "spdResInfo";
            this.spdResInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdResInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdResInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResInfo_LotInfo});
            this.spdResInfo.Size = new System.Drawing.Size(730, 118);
            this.spdResInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResInfo.TabIndex = 0;
            this.spdResInfo.TabStop = false;
            this.spdResInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdResInfo.TextTipAppearance = tipAppearance1;
            this.spdResInfo.TextTipDelay = 200;
            this.spdResInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            // 
            // spdResInfo_LotInfo
            // 
            this.spdResInfo_LotInfo.Reset();
            this.spdResInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdResInfo_LotInfo.ColumnCount = 4;
            this.spdResInfo_LotInfo.RowCount = 6;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).Value = "Up/Down Flag";
            this.spdResInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).Value = "Primary Status";
            this.spdResInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdResInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdResInfo_LotInfo.Columns.Get(0).CellType = textCellType1;
            this.spdResInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(1).CellType = textCellType2;
            this.spdResInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(1).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(1).Width = 199F;
            this.spdResInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdResInfo_LotInfo.Columns.Get(2).CellType = textCellType3;
            this.spdResInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(3).CellType = textCellType4;
            this.spdResInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(3).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(3).Width = 199F;
            this.spdResInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdResInfo_LotInfo.RowHeader.Visible = false;
            this.spdResInfo_LotInfo.Rows.Get(0).Height = 19F;
            this.spdResInfo_LotInfo.Rows.Get(1).Height = 19F;
            this.spdResInfo_LotInfo.Rows.Get(2).Height = 19F;
            this.spdResInfo_LotInfo.Rows.Get(3).Height = 19F;
            this.spdResInfo_LotInfo.Rows.Get(4).Height = 19F;
            this.spdResInfo_LotInfo.Rows.Get(5).Height = 19F;
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlResID
            // 
            this.pnlResID.Controls.Add(this.txtResID);
            this.pnlResID.Controls.Add(this.lblResID);
            this.pnlResID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResID.Location = new System.Drawing.Point(3, 16);
            this.pnlResID.Name = "pnlResID";
            this.pnlResID.Size = new System.Drawing.Size(730, 30);
            this.pnlResID.TabIndex = 0;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(120, 0);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.Size = new System.Drawing.Size(200, 20);
            this.txtResID.TabIndex = 1;
            this.txtResID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResID_KeyPress);
            this.txtResID.TextChanged += new System.EventHandler(this.txtResID_TextChanged);
            // 
            // lblResID
            // 
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 3);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(100, 14);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTroubleMid
            // 
            this.pnlTroubleMid.Controls.Add(this.grpTroubleInfo);
            this.pnlTroubleMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTroubleMid.Location = new System.Drawing.Point(3, 172);
            this.pnlTroubleMid.Name = "pnlTroubleMid";
            this.pnlTroubleMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlTroubleMid.Size = new System.Drawing.Size(736, 334);
            this.pnlTroubleMid.TabIndex = 1;
            // 
            // grpTroubleInfo
            // 
            this.grpTroubleInfo.Controls.Add(this.chkComment3);
            this.grpTroubleInfo.Controls.Add(this.lblComment3);
            this.grpTroubleInfo.Controls.Add(this.chkComment2);
            this.grpTroubleInfo.Controls.Add(this.lblComment2);
            this.grpTroubleInfo.Controls.Add(this.chkComment1);
            this.grpTroubleInfo.Controls.Add(this.lblComment1);
            this.grpTroubleInfo.Controls.Add(this.txtComment1);
            this.grpTroubleInfo.Controls.Add(this.txtComment3);
            this.grpTroubleInfo.Controls.Add(this.txtComment2);
            this.grpTroubleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTroubleInfo.Location = new System.Drawing.Point(0, 3);
            this.grpTroubleInfo.Name = "grpTroubleInfo";
            this.grpTroubleInfo.Size = new System.Drawing.Size(736, 331);
            this.grpTroubleInfo.TabIndex = 0;
            this.grpTroubleInfo.TabStop = false;
            this.grpTroubleInfo.Text = "Trouble Resource Information";
            // 
            // chkComment3
            // 
            this.chkComment3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment3.Location = new System.Drawing.Point(112, 137);
            this.chkComment3.Name = "chkComment3";
            this.chkComment3.Size = new System.Drawing.Size(13, 12);
            this.chkComment3.TabIndex = 7;
            this.chkComment3.CheckedChanged += new System.EventHandler(this.chkComment3_CheckedChanged);
            // 
            // lblComment3
            // 
            this.lblComment3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment3.Location = new System.Drawing.Point(20, 136);
            this.lblComment3.Name = "lblComment3";
            this.lblComment3.Size = new System.Drawing.Size(106, 14);
            this.lblComment3.TabIndex = 6;
            this.lblComment3.Text = "Comment3";
            this.lblComment3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkComment2
            // 
            this.chkComment2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment2.Location = new System.Drawing.Point(112, 81);
            this.chkComment2.Name = "chkComment2";
            this.chkComment2.Size = new System.Drawing.Size(13, 12);
            this.chkComment2.TabIndex = 4;
            this.chkComment2.CheckedChanged += new System.EventHandler(this.chkComment2_CheckedChanged);
            // 
            // lblComment2
            // 
            this.lblComment2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment2.Location = new System.Drawing.Point(20, 80);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(106, 14);
            this.lblComment2.TabIndex = 3;
            this.lblComment2.Text = "Comment2";
            this.lblComment2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkComment1
            // 
            this.chkComment1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment1.Location = new System.Drawing.Point(112, 25);
            this.chkComment1.Name = "chkComment1";
            this.chkComment1.Size = new System.Drawing.Size(13, 12);
            this.chkComment1.TabIndex = 1;
            this.chkComment1.CheckedChanged += new System.EventHandler(this.chkComment1_CheckedChanged);
            // 
            // lblComment1
            // 
            this.lblComment1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment1.Location = new System.Drawing.Point(20, 24);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(106, 14);
            this.lblComment1.TabIndex = 0;
            this.lblComment1.Text = "Comment1";
            this.lblComment1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment1
            // 
            this.txtComment1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment1.Location = new System.Drawing.Point(138, 16);
            this.txtComment1.Multiline = true;
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.ReadOnly = true;
            this.txtComment1.Size = new System.Drawing.Size(586, 52);
            this.txtComment1.TabIndex = 2;
            // 
            // txtComment3
            // 
            this.txtComment3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment3.Location = new System.Drawing.Point(138, 128);
            this.txtComment3.Multiline = true;
            this.txtComment3.Name = "txtComment3";
            this.txtComment3.ReadOnly = true;
            this.txtComment3.Size = new System.Drawing.Size(586, 52);
            this.txtComment3.TabIndex = 8;
            // 
            // txtComment2
            // 
            this.txtComment2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment2.Location = new System.Drawing.Point(138, 72);
            this.txtComment2.Multiline = true;
            this.txtComment2.Name = "txtComment2";
            this.txtComment2.ReadOnly = true;
            this.txtComment2.Size = new System.Drawing.Size(586, 52);
            this.txtComment2.TabIndex = 5;
            // 
            // frmRASTranTroubleResource
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranTroubleResource";
            this.Text = "Trouble Resource";
            this.Activated += new System.EventHandler(this.frmRASTranTroubleResource_Activated);
            this.Load += new System.EventHandler(this.frmRASTranTroubleResource_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTroubleTop.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            this.pnlResInfoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.pnlResID.ResumeLayout(false);
            this.pnlResID.PerformLayout();
            this.pnlTroubleMid.ResumeLayout(false);
            this.grpTroubleInfo.ResumeLayout(false);
            this.grpTroubleInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "

        internal bool b_load_flag;
        private int iDownHistSeq;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                iDownHistSeq = 0;
                
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        ClearResInfo();
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, txtResID, null, null, null, null, false);
                        if (View_Resource() == false)
                        {
                            return;
                        }
                        break;
                        
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void ClearResInfo()
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
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition()
        {
            bool bChecked = false;

            if (MPCF.CheckValue(txtResID, 1) == false)
            {
                return false;
            }
            if (chkComment1.Checked == true)
            {
                if (MPCF.CheckValue(txtComment1, 1) == false)
                {
                    return false;
                }
                bChecked = true;
            }
            if (chkComment2.Checked == true)
            {
                if (MPCF.CheckValue(txtComment2, 1) == false)
                {
                    return false;
                }
                bChecked = true;
            }
            if (chkComment3.Checked == true)
            {
                if (MPCF.CheckValue(txtComment3, 1) == false)
                {
                    return false;
                }
                bChecked = true;
            }
            if (bChecked == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                chkComment1.Focus();
                return false;
            }
            
            return true;
            
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

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                ClearResInfo();
                txtComment1.ReadOnly = true;
                txtComment2.ReadOnly = true;
                txtComment3.ReadOnly = true;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(txtResID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                iDownHistSeq = out_node.GetInt("LAST_DOWN_HIST_SEQ");
                View_Resource_Down_History();

                if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "U")
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";

                    chkComment1.Visible = false;
                    chkComment2.Visible = false;
                    chkComment3.Visible = false;

                    btnProcess.Enabled = false;

                }
                else if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "D")
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";

                    chkComment1.Visible = true;
                    chkComment2.Visible = true;
                    chkComment3.Visible = true;

                    MPCR.ChangeControlEnabled(this, btnProcess, true);
                }
                spdResInfo.Sheets[0].Cells[0, 3].Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));

                spdResInfo.Sheets[0].Cells[1, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                if (MPCF.Trim(out_node.GetChar("USE_FAC_PRT_FLAG")) == "Y")
                {
                    View_Factory_ResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                    spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                    spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                    spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                    spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                    spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                    spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                    spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                    spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                    spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

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

                spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        //
        // View_Resource_Down_History()
        //       - Get Resource Down History Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Resource_Down_History()
        {

            TRSNode in_node = new TRSNode("VIEW_RESOURCE_DOWN_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_DOWN_HISTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(txtResID.Text));
                in_node.AddInt("DOWN_HIST_SEQ", iDownHistSeq);

                if (MPCR.CallService("RAS", "RAS_View_Resource_Down_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtComment1.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_1"));
                txtComment2.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_2"));
                txtComment3.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_3"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //
        // Trouble_Resource()
        //       - Trouble Rescource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool Trouble_Resource()
        {

            TRSNode in_node = new TRSNode("TROUBLE_RESOURCE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(txtResID.Text));
                in_node.AddInt("DOWN_HIST_SEQ", iDownHistSeq);

                if (chkComment1.Checked == true)
                {
                    in_node.AddString("USER_COMMENT_1", MPCF.Trim(txtComment1.Text));
                }
                if (chkComment2.Checked == true)
                {
                    in_node.AddString("USER_COMMENT_2", MPCF.Trim(txtComment2.Text));
                }
                if (chkComment3.Checked == true)
                {
                    in_node.AddString("USER_COMMENT_3", MPCF.Trim(txtComment3.Text));
                }

                if (MPCR.CallService("RAS", "RAS_Trouble_Resource", in_node, ref out_node) == false)
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

        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASTranTroubleResource_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmRASTranTroubleResource_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                chkComment1.Visible = false;
                chkComment2.Visible = false;
                chkComment3.Visible = false;
                
                txtComment1.ReadOnly = true;
                txtComment2.ReadOnly = true;
                txtComment3.ReadOnly = true;

                MPCR.ChangeControlEnabled(this, btnProcess, true);
                
                if (txtResID.Text != "")
                {
                    ClearData('2');
                }
                else
                {
                    ClearData('1');
                }

                b_load_flag = true;
            }
            
            
        }
        
        private void txtResID_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtResID.Text != "")
                {
                    ClearData('2');
                }
            }
        }
        
        private void txtResID_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (txtResID.Text == "")
            {
                ClearData('1');
            }
        }
        
        private void chkComment1_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtComment1.ReadOnly = ! chkComment1.Checked;
            
        }
        
        private void chkComment2_CheckedChanged(object sender, System.EventArgs e)
        {
            
            txtComment2.ReadOnly = ! chkComment2.Checked;
            
        }
        
        private void chkComment3_CheckedChanged(object sender, System.EventArgs e)
        {
            
            txtComment3.ReadOnly = ! chkComment3.Checked;
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == true)
                {
                    if (Trouble_Resource() == false)
                    {
                        return;
                    }
                    ClearData('2');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        
    }
    
}
