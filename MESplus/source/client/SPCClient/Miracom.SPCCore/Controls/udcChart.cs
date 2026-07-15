
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : udcChart.vb
//   Description : View Chart Information Control
//
//   SPC Version : 1.0.0
//
//   Function List
//       - ViewChartInformation : View Chart Information
//       - View_Chart : View Chart Information
//       - View_Spec : View Spec Information
//       - ClearChartInfo : Clear Chart Information
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-11-01 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class udcChart : System.Windows.Forms.UserControl
    {
        
        
        #region " Windows Form auto generated code "
        
        public udcChart()
        {
            
            
            InitializeComponent();
            
            
            this.spdChartInfo.Tag = "Change Cell";
            
        }
        
        //UserControl?€ Disposeë¥??¬ì •?˜í•˜??êµ¬ì„± ?”ì†Œ ëª©ë¡???•ë¦¬?©ë‹ˆ??
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
        



        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.Panel pnlData;
        internal FarPoint.Win.Spread.FpSpread spdChartInfo;
        internal FarPoint.Win.Spread.SheetView spdChartInfo_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.EmptyBorder emptyBorder1 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder2 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder3 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder4 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder5 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder6 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder7 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.EmptyBorder emptyBorder8 = new FarPoint.Win.EmptyBorder();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.spdChartInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdChartInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.pnlCenter.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlData);
            this.pnlCenter.Controls.Add(this.lblChartID);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(730, 77);
            this.pnlCenter.TabIndex = 4;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.spdChartInfo);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 15);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(730, 62);
            this.pnlData.TabIndex = 1;
            // 
            // spdChartInfo
            // 
            this.spdChartInfo.AccessibleDescription = "spdChartInfo, Sheet1, Row 0, Column 0, USL";
            this.spdChartInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdChartInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdChartInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdChartInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.HorizontalScrollBar.Name = "";
            this.spdChartInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdChartInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdChartInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdChartInfo.Location = new System.Drawing.Point(0, 0);
            this.spdChartInfo.Name = "spdChartInfo";
            this.spdChartInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdChartInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdChartInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdChartInfo_Sheet1});
            this.spdChartInfo.Size = new System.Drawing.Size(730, 62);
            this.spdChartInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdChartInfo.TabIndex = 7;
            this.spdChartInfo.TabStop = false;
            this.spdChartInfo.TextTipDelay = 200;
            this.spdChartInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdChartInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.VerticalScrollBar.Name = "";
            this.spdChartInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdChartInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdChartInfo_Sheet1
            // 
            this.spdChartInfo_Sheet1.Reset();
            this.spdChartInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdChartInfo_Sheet1.ColumnCount = 8;
            this.spdChartInfo_Sheet1.RowCount = 7;
            this.spdChartInfo_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(0, 0).Value = "USL";
            this.spdChartInfo_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(0, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(0, 2).Value = "UCL";
            this.spdChartInfo_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(0, 3).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(0, 4).Value = "UCL2";
            this.spdChartInfo_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(0, 5).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(0, 6).Value = "Use Unit";
            this.spdChartInfo_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(0, 7).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).Value = "TARGET";
            this.spdChartInfo_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(1, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(1, 2).Value = "CL";
            this.spdChartInfo_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(1, 3).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(1, 4).Value = "CL2";
            this.spdChartInfo_Sheet1.Cells.Get(1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(1, 5).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Cells.Get(1, 6).Value = "Unit Count";
            this.spdChartInfo_Sheet1.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(1, 7).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(2, 0).Value = "LSL";
            this.spdChartInfo_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(2, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(2, 2).Value = "LCL";
            this.spdChartInfo_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(2, 3).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(2, 4).Value = "LCL2";
            this.spdChartInfo_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(2, 5).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(2, 6).Value = "Sample Size";
            this.spdChartInfo_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(2, 7).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(3, 0).Value = "Material";
            this.spdChartInfo_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdChartInfo_Sheet1.Cells.Get(3, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(3, 2).Value = "Material Ver";
            this.spdChartInfo_Sheet1.Cells.Get(3, 4).Value = "Operation";
            this.spdChartInfo_Sheet1.Cells.Get(3, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdChartInfo_Sheet1.Cells.Get(3, 5).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(3, 6).Value = "Character";
            this.spdChartInfo_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdChartInfo_Sheet1.Cells.Get(3, 7).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(4, 0).Value = "Resource";
            this.spdChartInfo_Sheet1.Cells.Get(4, 1).ColumnSpan = 3;
            this.spdChartInfo_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdChartInfo_Sheet1.Cells.Get(4, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(4, 4).Value = "Rule Type";
            this.spdChartInfo_Sheet1.Cells.Get(4, 5).ColumnSpan = 3;
            this.spdChartInfo_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdChartInfo_Sheet1.Cells.Get(4, 5).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 0).Border = emptyBorder1;
            this.spdChartInfo_Sheet1.Cells.Get(5, 1).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 1).Border = emptyBorder2;
            this.spdChartInfo_Sheet1.Cells.Get(5, 1).Locked = true;
            this.spdChartInfo_Sheet1.Cells.Get(5, 2).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 2).Border = emptyBorder3;
            this.spdChartInfo_Sheet1.Cells.Get(5, 3).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 3).Border = emptyBorder4;
            this.spdChartInfo_Sheet1.Cells.Get(5, 4).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 4).Border = emptyBorder5;
            this.spdChartInfo_Sheet1.Cells.Get(5, 5).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 5).Border = emptyBorder6;
            this.spdChartInfo_Sheet1.Cells.Get(5, 6).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 6).Border = emptyBorder7;
            this.spdChartInfo_Sheet1.Cells.Get(5, 7).BackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.Cells.Get(5, 7).Border = emptyBorder8;
            this.spdChartInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdChartInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdChartInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdChartInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Width = 77F;
            this.spdChartInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(1).Width = 100F;
            this.spdChartInfo_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(2).Border = bevelBorder2;
            this.spdChartInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(2).Width = 77F;
            this.spdChartInfo_Sheet1.Columns.Get(3).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(3).Width = 100F;
            this.spdChartInfo_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(4).Border = bevelBorder3;
            this.spdChartInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(4).Width = 77F;
            this.spdChartInfo_Sheet1.Columns.Get(5).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(5).Width = 100F;
            this.spdChartInfo_Sheet1.Columns.Get(6).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(6).Border = bevelBorder4;
            this.spdChartInfo_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(6).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(6).Width = 77F;
            this.spdChartInfo_Sheet1.Columns.Get(7).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(7).Width = 100F;
            this.spdChartInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdChartInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdChartInfo_Sheet1.RowHeader.Visible = false;
            this.spdChartInfo_Sheet1.Rows.Get(0).CellType = textCellType1;
            this.spdChartInfo_Sheet1.Rows.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Rows.Get(1).CellType = textCellType2;
            this.spdChartInfo_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Rows.Get(5).Height = 0F;
            this.spdChartInfo_Sheet1.Rows.Get(5).Visible = false;
            this.spdChartInfo_Sheet1.Rows.Get(6).Visible = false;
            this.spdChartInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdChartInfo_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblChartID
            // 
            this.lblChartID.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartID.Location = new System.Drawing.Point(0, 0);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(730, 15);
            this.lblChartID.TabIndex = 0;
            // 
            // udcChart
            // 
            this.Controls.Add(this.pnlCenter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcChart";
            this.Size = new System.Drawing.Size(730, 77);
            this.Load += new System.EventHandler(this.udcChart_Load);
            this.Resize += new System.EventHandler(this.udcChart_Resize);
            this.pnlCenter.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Properties Definition"

        private char m_sSyncEDCFlag = ' ';
        public string USL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 1].Value);
            }
        }
        
        public string UCL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 3].Value);
            }
        }
        
        public string CL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 3].Value);
            }
        }
        
        public string LCL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 3].Value);
            }
        }
        
        public string UCL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 5].Value);
            }
        }
        
        public string CL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 5].Value);
            }
        }
        
        public string LCL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 5].Value);
            }
        }
        
        public string LSL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 1].Value);
            }
        }
        
        public string Target
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 1].Value);
            }
        }
        
        public int SampleSize
        {
            get
            {
                if (spdChartInfo.Sheets[0].Cells[2, 7].Text == "")
                {
                    return 0;
                }
                else
                {
                    return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[2, 7].Value);
                }
            }
        }
        
        public int UnitCount
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[1, 7].Value);
            }
        }
        
        public char UseUnit
        {
            get
            {
                return MPCF.ToChar(spdChartInfo.Sheets[0].Cells[0, 7].Value);
            }
        }
        
        public string Character
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 7].Value);
            }
        }
        
        public string Material
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 1].Value);
            }
        }

        public int MaterialVer
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[3, 3].Value);
            }
        }
        
        public string Operation
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 5].Value);
            }
        }
        
        public string Resource
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 1].Value);
            }
        }
        
        public string RuleType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 5].Value);
            }
        }
        
        public string ChartGraphType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[5, 0].Value);
            }
        }
        
        public string LotorRes
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[5, 1].Value);
            }
        }
        
        public int Precision
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[5, 2].Value);
            }
        }
        
       
        public string ValueType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[5, 4].Value);
            }
        }
        
        public string SpecCheckType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[5, 5].Value);
            }
        }
        
        public int SpecOutCount
        {
            get
            {
                return (int)spdChartInfo.Sheets[0].Cells[5, 6].Value;
            }
        }
        
        public string DefaultUnitFlag
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[5, 7].Value);
            }
        }
        
        public string DefaultUnitOvrFlag
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[6, 0].Value);
            }
        }
        
        public string DefaultValue
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[6, 1].Value);
            }
        }
        
        public string UnitTable
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[6, 2].Value);
            }
        }
        
        public string ValueTable
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[6, 3].Value);
            }
        }

        public char SyncEDCFlag
        {
            get
            {
                return m_sSyncEDCFlag;
            }
            set
            {
                if (m_sSyncEDCFlag.Equals(value) == false)
                {
                    m_sSyncEDCFlag = value;
                }
            }
        }
        
        #endregion
        
        #region " Function Implementations"
        
        // ViewChartInformation()
        //       - View Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : ì°¨íŠ¸ ëª?
        //       - Optional ByVal bIgnoreError As Boolean = False : ?ëŸ¬ë©”ì‹œì§€ ë¬´ì‹œ ?¬ë?
        //
        public bool ViewChartInformation(string sChartID, bool bIgnoreError)
        {
            
            try
            {
                int iVer = 0;
                
                if (View_Chart(sChartID) == false)
                {
                    return false;
                }
                if (MPCR.Find_Spec_Version('1', sChartID, ref iVer, bIgnoreError) == true)
                {
                    if (View_Spec(iVer, sChartID) == false)
                    {
                        return false;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.ViewChartInformation()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : ì°¨íŠ¸ ëª?
        //
        private bool View_Chart(string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                string sRuleType;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));


                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                lblChartID.Text = " " + sChartID + " : " + out_node.GetString("CHART_DESC");
                
                if (out_node.GetInt("SAMPLE_SIZE") == 0)
                {
                    spdChartInfo.Sheets[0].Cells[2, 7].Value = "";
                }
                else
                {
                    spdChartInfo.Sheets[0].Cells[2, 7].Value = out_node.GetInt("SAMPLE_SIZE");
                }

                spdChartInfo.Sheets[0].Cells[1, 7].Value = out_node.GetInt("UNIT_COUNT");
                spdChartInfo.Sheets[0].Cells[0, 7].Value = out_node.GetChar("UNIT_USE_FLAG");
                spdChartInfo.Sheets[0].Cells[3, 7].Value = out_node.GetString("CHAR_ID");

                spdChartInfo.Sheets[0].Cells[3, 1].Value = out_node.GetString("MAT_ID");
                spdChartInfo.Sheets[0].Cells[3, 3].Value = out_node.GetInt("MAT_VER");
                spdChartInfo.Sheets[0].Cells[3, 5].Value = out_node.GetString("OPER");
                
                spdChartInfo.Sheets[0].Cells[4, 1].Value = out_node.GetString("RES_ID");
                
                sRuleType = "";
                sRuleType = (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(0, 1) == "Y") ? "A" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(1, 1) == "Y") ? "B" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(2, 1) == "Y") ? "C" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(3, 1) == "Y") ? "D" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(4, 1) == "Y") ? "E" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(5, 1) == "Y") ? "F" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(6, 1) == "Y") ? "G" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(7, 1) == "Y") ? "H" : "_";
                
                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XBARR" ||
                    MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XRS" ||
                    MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XBARS")
                {
                    
                    sRuleType += " / ";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(0, 1) == "Y") ? "A" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(1, 1) == "Y") ? "B" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(2, 1) == "Y") ? "C" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(3, 1) == "Y") ? "D" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(4, 1) == "Y") ? "E" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(5, 1) == "Y") ? "F" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(6, 1) == "Y") ? "G" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(7, 1) == "Y") ? "H" : "_";
                    
                }
                
                spdChartInfo.Sheets[0].Cells[4, 5].Value = sRuleType;
                spdChartInfo.Sheets[0].Cells[5, 0].Value = MPCF.Trim(out_node.GetString("GRAPH_TYPE"));
                spdChartInfo.Sheets[0].Cells[5, 1].Value = MPCF.Trim(out_node.GetChar("LOT_RES_FLAG"));
                spdChartInfo.Sheets[0].Cells[5, 2].Value = out_node.GetInt("PRECISION_LIMIT");
                //spdChartInfo.Sheets[0].Cells[5, 3].Value = MPCF.Trim(View_Chart_Out.view_chart_flag);
                //spdChartInfo.Sheets[0].Cells[5, 4].Value = MPCF.Trim(View_Chart_Out.value_type);
                spdChartInfo.Sheets[0].Cells[5, 5].Value = MPCF.Trim(out_node.GetChar("SPEC_CHECK_TYPE"));
                spdChartInfo.Sheets[0].Cells[5, 6].Value = out_node.GetInt("SPEC_OUT_COUNT");
                //spdChartInfo.Sheets[0].Cells[5, 7].Value = MPCF.Trim(View_Chart_Out.def_unit_flag);
                //spdChartInfo.Sheets[0].Cells[6, 0].Value = MPCF.Trim(View_Chart_Out.def_unit_ovr_flag);
                //spdChartInfo.Sheets[0].Cells[6, 1].Value = MPCF.Trim(View_Chart_Out.def_value);
                //spdChartInfo.Sheets[0].Cells[6, 2].Value = MPCF.Trim(View_Chart_Out.unit_tbl);
                //spdChartInfo.Sheets[0].Cells[6, 3].Value = MPCF.Trim(View_Chart_Out.value_tbl);

                SyncEDCFlag = out_node.GetChar("SYNC_EDC_FLAG");
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer : ë²„ì „
        //       - ByVal sChartID As String : ì°¨íŠ¸ ëª?
        //
        private bool View_Spec(int iVer, string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));
                in_node.AddInt("VERSION", iVer);

                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node, true) == false)
                {
                    return false;
                }
                
                spdChartInfo.Sheets[0].Cells[0, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), Precision);
                spdChartInfo.Sheets[0].Cells[0, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), Precision);
                spdChartInfo.Sheets[0].Cells[0, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), Precision);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ClearChartInfo()
        //       - Clear Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public void ClearChartInfo()
        {
            
            try
            {
                lblChartID.Text = "";
                spdChartInfo.Sheets[0].ClearRange(0, 1, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 3, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 5, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 7, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(5, 0, 1, 8, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.ClearChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void udcChart_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                int iDiffSize;
                
                iDiffSize = (this.Size.Width - 730) / 4;
                
                if (iDiffSize >= 0)
                {
                    spdChartInfo.Sheets[0].Columns[1].Width = 100 + iDiffSize;
                    spdChartInfo.Sheets[0].Columns[3].Width = 100 + iDiffSize;
                    spdChartInfo.Sheets[0].Columns[5].Width = 100 + iDiffSize;
                    spdChartInfo.Sheets[0].Columns[7].Width = 100 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.udcChart_Resize()\n" + ex.Message);
            }
            
        }
        
        private void udcChart_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.SetTextboxStyle(this.Controls);
                MPCF.ConvertMessage(this.Controls);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.udcChart_Load()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
