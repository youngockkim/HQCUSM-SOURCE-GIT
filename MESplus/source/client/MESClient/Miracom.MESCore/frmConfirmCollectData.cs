
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using FarPoint.Win.Spread;

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCSubCollectData.vb
//   Description : View Collect Data Result
//
//   SPC Version : 1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.MESCore
{
    public class frmConfirmCollectData : System.Windows.Forms.Form
    {
        
#region " Windows Form auto generated code "
        
        public frmConfirmCollectData()
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
        



        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnDataChange;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel pnlCenter;
        private FarPoint.Win.Spread.SheetView spdResult_Sheet1;
        public FarPoint.Win.Spread.FpSpread spdResult;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnDataChange = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.spdResult = new FarPoint.Win.Spread.FpSpread();
            this.spdResult_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPending);
            this.pnlBottom.Controls.Add(this.btnDataChange);
            this.pnlBottom.Controls.Add(this.btnContinue);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 252);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(662, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnPending
            // 
            this.btnPending.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPending.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnPending.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPending.Location = new System.Drawing.Point(419, 10);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(75, 23);
            this.btnPending.TabIndex = 0;
            this.btnPending.Text = "Pending";
            this.btnPending.Visible = false;
            // 
            // btnDataChange
            // 
            this.btnDataChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDataChange.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnDataChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDataChange.Location = new System.Drawing.Point(579, 10);
            this.btnDataChange.Name = "btnDataChange";
            this.btnDataChange.Size = new System.Drawing.Size(75, 23);
            this.btnDataChange.TabIndex = 2;
            this.btnDataChange.Text = "Data Change";
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnContinue.Location = new System.Drawing.Point(499, 10);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Continue";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.spdResult);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCenter.Size = new System.Drawing.Size(662, 252);
            this.pnlCenter.TabIndex = 0;
            // 
            // spdResult
            // 
            this.spdResult.AccessibleDescription = "spdResult, Sheet1, Row 0, Column 0, ";
            this.spdResult.BackColor = System.Drawing.SystemColors.Control;
            this.spdResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResult.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResult.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResult.HorizontalScrollBar.Name = "";
            this.spdResult.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdResult.HorizontalScrollBar.TabIndex = 2;
            this.spdResult.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResult.Location = new System.Drawing.Point(3, 3);
            this.spdResult.Name = "spdResult";
            this.spdResult.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResult.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResult.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResult_Sheet1});
            this.spdResult.Size = new System.Drawing.Size(656, 246);
            this.spdResult.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResult.TabIndex = 0;
            this.spdResult.TabStop = false;
            this.spdResult.TextTipDelay = 200;
            this.spdResult.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResult.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResult.VerticalScrollBar.Name = "";
            this.spdResult.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdResult.VerticalScrollBar.TabIndex = 3;
            this.spdResult.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdResult_Sheet1
            // 
            this.spdResult_Sheet1.Reset();
            this.spdResult_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdResult_Sheet1.ColumnCount = 5;
            this.spdResult_Sheet1.RowCount = 5;
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Character";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit ID";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Rule Type";
            this.spdResult_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Rule Description";
            this.spdResult_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResult_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResult_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdResult_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdResult_Sheet1.Columns.Get(0).Locked = true;
            this.spdResult_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(0).Width = 40F;
            this.spdResult_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResult_Sheet1.Columns.Get(1).Label = "Character";
            this.spdResult_Sheet1.Columns.Get(1).Locked = true;
            this.spdResult_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdResult_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(1).Width = 130F;
            this.spdResult_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResult_Sheet1.Columns.Get(2).Label = "Unit ID";
            this.spdResult_Sheet1.Columns.Get(2).Locked = true;
            this.spdResult_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(2).Width = 100F;
            this.spdResult_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(3).Label = "Rule Type";
            this.spdResult_Sheet1.Columns.Get(3).Locked = true;
            this.spdResult_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResult_Sheet1.Columns.Get(4).Label = "Rule Description";
            this.spdResult_Sheet1.Columns.Get(4).Locked = true;
            this.spdResult_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResult_Sheet1.Columns.Get(4).Width = 300F;
            this.spdResult_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResult_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResult_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResult_Sheet1.RowHeader.Visible = false;
            this.spdResult_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdResult_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResult_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmConfirmCollectData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnContinue;
            this.ClientSize = new System.Drawing.Size(662, 292);
            this.ControlBox = false;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(670, 300);
            this.Name = "frmConfirmCollectData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rule Check Result";
            this.Load += new System.EventHandler(this.frmEDCConfirmCollectData_Load);
            this.Closed += new System.EventHandler(this.frmEDCConfirmCollectData_Closed);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResult_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "

#endregion
        
#region " Event Implematations"
        
        private void frmEDCConfirmCollectData_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSubCollectData.frmEDCConfirmCollectData_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmEDCConfirmCollectData_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                //this.Dispose(true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSubCollectData.frmEDCConfirmCollectData_Closed()\n" + ex.Message);
            }
            
        }
        
#endregion
        
    }
    
}
