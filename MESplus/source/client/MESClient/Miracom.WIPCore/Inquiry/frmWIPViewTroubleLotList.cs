
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



namespace Miracom.WIPCore
{
    public class frmWIPViewTroubleLotList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewTroubleLotList()
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
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEngr;
        private System.Windows.Forms.Label lblEngr;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        private System.Windows.Forms.Label lblHoldCode;
        public System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.CheckBox chkIncludeCompleteHistory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType27 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType28 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType29 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType30 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType31 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType32 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType33 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType34 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType35 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType36 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType37 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType38 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType39 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType40 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType41 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType42 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType43 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType44 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType45 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType46 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType47 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType48 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType49 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType50 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType51 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType52 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvEngr = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEngr = new System.Windows.Forms.Label();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.chkIncludeCompleteHistory = new System.Windows.Forms.CheckBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEngr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(466, 8);
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 95);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.chkIncludeCompleteHistory);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.cdvHoldCode);
            this.grpOption.Controls.Add(this.cdvEngr);
            this.grpOption.Controls.Add(this.lblHoldCode);
            this.grpOption.Controls.Add(this.lblEngr);
            this.grpOption.Size = new System.Drawing.Size(742, 95);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 95);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 418);
            this.pnlViewMid.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Trouble Lot List";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.Location = new System.Drawing.Point(0, 3);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 415);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            this.spdList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdList_CellDoubleClick);
            this.spdList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdList_MouseUp);
            this.spdList.SetViewportLeftColumn(0, 0, 1);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 41;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Hold Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Hold Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Hold User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Estimate Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "User1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Time1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "User2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Time2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "User3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Time3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hist Seq.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Release Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Release Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Cause Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Cause Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Cause Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Qty1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Qty2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Qty3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Release User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Release Comment";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).CellType = textCellType27;
            this.spdList_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 97F;
            this.spdList_Sheet1.Columns.Get(1).CellType = textCellType28;
            this.spdList_Sheet1.Columns.Get(1).Label = "Hold Tran Time";
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 120F;
            this.spdList_Sheet1.Columns.Get(2).CellType = textCellType29;
            this.spdList_Sheet1.Columns.Get(2).Label = "Status";
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 89F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Hold Comment";
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 105F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Hold User";
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 77F;
            this.spdList_Sheet1.Columns.Get(5).Label = "Estimate Reason";
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 95F;
            this.spdList_Sheet1.Columns.Get(6).Label = "User1";
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Label = "Time1";
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Label = "Reason";
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Label = "User2";
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Label = "Time2";
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Label = "Result";
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Label = "User3";
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Label = "Time3";
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Label = "Hist Seq.";
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).CellType = textCellType30;
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(15).Label = "Release Hist Seq";
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 110F;
            this.spdList_Sheet1.Columns.Get(16).Label = "Release Tran Time";
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 105F;
            this.spdList_Sheet1.Columns.Get(17).CellType = textCellType31;
            this.spdList_Sheet1.Columns.Get(17).Label = "Material";
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 113F;
            this.spdList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).CellType = textCellType32;
            this.spdList_Sheet1.Columns.Get(19).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 113F;
            this.spdList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).CellType = textCellType33;
            this.spdList_Sheet1.Columns.Get(21).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 58F;
            this.spdList_Sheet1.Columns.Get(22).CellType = textCellType34;
            this.spdList_Sheet1.Columns.Get(22).Label = "Res ID";
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 89F;
            this.spdList_Sheet1.Columns.Get(23).CellType = textCellType35;
            this.spdList_Sheet1.Columns.Get(23).Label = "Cause Flow";
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 89F;
            this.spdList_Sheet1.Columns.Get(24).CellType = textCellType36;
            this.spdList_Sheet1.Columns.Get(24).Label = "Cause Oper";
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 76F;
            this.spdList_Sheet1.Columns.Get(25).CellType = textCellType37;
            this.spdList_Sheet1.Columns.Get(25).Label = "Cause Res ID";
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 89F;
            this.spdList_Sheet1.Columns.Get(26).CellType = textCellType38;
            this.spdList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(26).Label = "Qty1";
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 70F;
            this.spdList_Sheet1.Columns.Get(27).CellType = textCellType39;
            this.spdList_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(27).Label = "Qty2";
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 70F;
            this.spdList_Sheet1.Columns.Get(28).CellType = textCellType40;
            this.spdList_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(28).Label = "Qty3";
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 70F;
            this.spdList_Sheet1.Columns.Get(29).CellType = textCellType41;
            this.spdList_Sheet1.Columns.Get(29).Label = "CMF 1";
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 89F;
            this.spdList_Sheet1.Columns.Get(30).CellType = textCellType42;
            this.spdList_Sheet1.Columns.Get(30).Label = "CMF 2";
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 89F;
            this.spdList_Sheet1.Columns.Get(31).CellType = textCellType43;
            this.spdList_Sheet1.Columns.Get(31).Label = "CMF 3";
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 89F;
            this.spdList_Sheet1.Columns.Get(32).CellType = textCellType44;
            this.spdList_Sheet1.Columns.Get(32).Label = "CMF 4";
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 89F;
            this.spdList_Sheet1.Columns.Get(33).CellType = textCellType45;
            this.spdList_Sheet1.Columns.Get(33).Label = "CMF 5";
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 89F;
            this.spdList_Sheet1.Columns.Get(34).CellType = textCellType46;
            this.spdList_Sheet1.Columns.Get(34).Label = "CMF 6";
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 89F;
            this.spdList_Sheet1.Columns.Get(35).CellType = textCellType47;
            this.spdList_Sheet1.Columns.Get(35).Label = "CMF 7";
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 89F;
            this.spdList_Sheet1.Columns.Get(36).CellType = textCellType48;
            this.spdList_Sheet1.Columns.Get(36).Label = "CMF 8";
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 89F;
            this.spdList_Sheet1.Columns.Get(37).CellType = textCellType49;
            this.spdList_Sheet1.Columns.Get(37).Label = "CMF 9";
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 89F;
            this.spdList_Sheet1.Columns.Get(38).CellType = textCellType50;
            this.spdList_Sheet1.Columns.Get(38).Label = "CMF 10";
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 89F;
            this.spdList_Sheet1.Columns.Get(39).CellType = textCellType51;
            this.spdList_Sheet1.Columns.Get(39).Label = "Release User ID";
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 106F;
            this.spdList_Sheet1.Columns.Get(40).CellType = textCellType52;
            this.spdList_Sheet1.Columns.Get(40).Label = "Release Comment";
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 270F;
            this.spdList_Sheet1.FrozenColumnCount = 1;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvEngr
            // 
            this.cdvEngr.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEngr.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEngr.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEngr.BtnToolTipText = "";
            this.cdvEngr.ButtonWidth = 20;
            this.cdvEngr.DescText = "";
            this.cdvEngr.DisplaySubItemIndex = -1;
            this.cdvEngr.DisplayText = "";
            this.cdvEngr.Focusing = null;
            this.cdvEngr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEngr.Index = 0;
            this.cdvEngr.IsViewBtnImage = false;
            this.cdvEngr.Location = new System.Drawing.Point(120, 65);
            this.cdvEngr.MaxLength = 20;
            this.cdvEngr.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEngr.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEngr.MultiSelect = false;
            this.cdvEngr.Name = "cdvEngr";
            this.cdvEngr.ReadOnly = false;
            this.cdvEngr.SameWidthHeightOfButton = false;
            this.cdvEngr.SearchSubItemIndex = 0;
            this.cdvEngr.SelectedDescIndex = -1;
            this.cdvEngr.SelectedDescToQueryText = "";
            this.cdvEngr.SelectedSubItemIndex = -1;
            this.cdvEngr.SelectedValueToQueryText = "";
            this.cdvEngr.SelectionStart = 0;
            this.cdvEngr.Size = new System.Drawing.Size(200, 20);
            this.cdvEngr.SmallImageList = null;
            this.cdvEngr.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEngr.TabIndex = 4;
            this.cdvEngr.TextBoxToolTipText = "";
            this.cdvEngr.TextBoxWidth = 200;
            this.cdvEngr.VisibleButton = false;
            this.cdvEngr.VisibleColumnHeader = false;
            this.cdvEngr.VisibleDescription = false;
            // 
            // lblEngr
            // 
            this.lblEngr.AutoSize = true;
            this.lblEngr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEngr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngr.Location = new System.Drawing.Point(12, 67);
            this.lblEngr.Name = "lblEngr";
            this.lblEngr.Size = new System.Drawing.Size(49, 13);
            this.lblEngr.TabIndex = 3;
            this.lblEngr.Text = "Engineer";
            this.lblEngr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvHoldCode
            // 
            this.cdvHoldCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCode.BtnToolTipText = "";
            this.cdvHoldCode.ButtonWidth = 20;
            this.cdvHoldCode.DescText = "";
            this.cdvHoldCode.DisplaySubItemIndex = -1;
            this.cdvHoldCode.DisplayText = "";
            this.cdvHoldCode.Focusing = null;
            this.cdvHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCode.Index = 0;
            this.cdvHoldCode.IsViewBtnImage = false;
            this.cdvHoldCode.Location = new System.Drawing.Point(120, 40);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MultiSelect = false;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = false;
            this.cdvHoldCode.SameWidthHeightOfButton = false;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedDescToQueryText = "";
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectedValueToQueryText = "";
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(200, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 2;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 200;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = false;
            this.cdvHoldCode.ButtonPress += new System.EventHandler(this.cdvHoldCode_ButtonPress);
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(12, 43);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 1;
            this.lblHoldCode.Text = "Hold Code";
            this.lblHoldCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(558, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Trouble Lot";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
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
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // chkIncludeCompleteHistory
            // 
            this.chkIncludeCompleteHistory.AutoSize = true;
            this.chkIncludeCompleteHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeCompleteHistory.Location = new System.Drawing.Point(475, 41);
            this.chkIncludeCompleteHistory.Name = "chkIncludeCompleteHistory";
            this.chkIncludeCompleteHistory.Size = new System.Drawing.Size(206, 18);
            this.chkIncludeCompleteHistory.TabIndex = 5;
            this.chkIncludeCompleteHistory.Text = "Include Completed(Released) History";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(308, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmWIPViewTroubleLotList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewTroubleLotList";
            this.Text = "View Trouble Lot List";
            this.Activated += new System.EventHandler(this.frmWIPViewTroubleLotList_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewTroubleLotList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEngr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_dclic_flag;
        
        #endregion
        
        #region " Function Definition "
        
        private bool View_Trouble_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;
            int iRow;

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';

            if (chkIncludeCompleteHistory.Checked == true)
            {
                in_node.ProcStep = '2';
            }

            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("HOLD_CODE", MPCF.Trim(cdvHoldCode.Text));
            in_node.AddString("TRAN_USER_ID", MPCF.Trim(cdvEngr.Text), true);
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Trouble_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.Sheets[0].RowCount;
                    spdList.Sheets[0].RowCount++;

                    spdList.Sheets[0].Cells[iRow, 0].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                    spdList.Sheets[0].Cells[iRow, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("HOLD_TRAN_TIME"));
                    //status
                    if (out_node.GetList(0)[i].GetInt("RELEASE_HIST_SEQ") != 0)
                    {
                        spdList.Sheets[0].Cells[iRow, 2].Value = MPCF.FindLanguage("RELEASED", 0);
                    }
                    else if (out_node.GetList(0)[i].GetString("USER_TIME_3") != "")
                    {
                        spdList.Sheets[0].Cells[iRow, 2].Value = MPCF.FindLanguage("COMPLETED", 0);
                    }
                    else if (out_node.GetList(0)[i].GetString("USER_TIME_2") != "")
                    {
                        spdList.Sheets[0].Cells[iRow, 2].Value = MPCF.FindLanguage("SOLVING", 0);
                    }
                    else if (out_node.GetList(0)[i].GetString("USER_TIME_1") != "")
                    {
                        spdList.Sheets[0].Cells[iRow, 2].Value = MPCF.FindLanguage("FINDING", 0);
                    }
                    else
                    {
                        spdList.Sheets[0].Cells[iRow, 2].Value = MPCF.FindLanguage("OCCURRED", 0);
                    }

                    spdList.Sheets[0].Cells[iRow, 3].Value = out_node.GetList(0)[i].GetString("HOLD_COMMENT");
                    spdList.Sheets[0].Cells[iRow, 4].Value = out_node.GetList(0)[i].GetString("HOLD_USER_ID");

                    spdList.Sheets[0].Cells[iRow, 5].Value = out_node.GetList(0)[i].GetString("USER_COMMENT_1");
                    spdList.Sheets[0].Cells[iRow, 6].Value = out_node.GetList(0)[i].GetString("USER_ID_1");
                    spdList.Sheets[0].Cells[iRow, 7].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_1"));
                    spdList.Sheets[0].Cells[iRow, 8].Value = out_node.GetList(0)[i].GetString("USER_COMMENT_2");
                    spdList.Sheets[0].Cells[iRow, 9].Value = out_node.GetList(0)[i].GetString("USER_ID_2");
                    spdList.Sheets[0].Cells[iRow, 10].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_2"));
                    spdList.Sheets[0].Cells[iRow, 11].Value = out_node.GetList(0)[i].GetString("USER_COMMENT_3");
                    spdList.Sheets[0].Cells[iRow, 12].Value = out_node.GetList(0)[i].GetString("USER_ID_3");
                    spdList.Sheets[0].Cells[iRow, 13].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_3"));

                    spdList.Sheets[0].Cells[iRow, 14].Value = MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                    spdList.Sheets[0].Cells[iRow, 15].Value = MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("RELEASE_HIST_SEQ"));
                    spdList.Sheets[0].Cells[iRow, 16].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RELEASE_TRAN_TIME"));

                    spdList.Sheets[0].Cells[iRow, 17].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdList.Sheets[0].Cells[iRow, 18].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                    spdList.Sheets[0].Cells[iRow, 19].Value = out_node.GetList(0)[i].GetString("FLOW");
                    spdList.Sheets[0].Cells[iRow, 20].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");
                    spdList.Sheets[0].Cells[iRow, 21].Value = out_node.GetList(0)[i].GetString("OPER");
                    spdList.Sheets[0].Cells[iRow, 22].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdList.Sheets[0].Cells[iRow, 23].Value = out_node.GetList(0)[i].GetString("CAUSE_FLOW");
                    spdList.Sheets[0].Cells[iRow, 24].Value = out_node.GetList(0)[i].GetString("CAUSE_OPER");
                    spdList.Sheets[0].Cells[iRow, 25].Value = out_node.GetList(0)[i].GetString("CAUSE_RES_ID");
                    spdList.Sheets[0].Cells[iRow, 26].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));
                    spdList.Sheets[0].Cells[iRow, 27].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));
                    spdList.Sheets[0].Cells[iRow, 28].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));
                    spdList.Sheets[0].Cells[iRow, 29].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_1");
                    spdList.Sheets[0].Cells[iRow, 30].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_2");
                    spdList.Sheets[0].Cells[iRow, 31].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_3");
                    spdList.Sheets[0].Cells[iRow, 32].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_4");
                    spdList.Sheets[0].Cells[iRow, 33].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_5");
                    spdList.Sheets[0].Cells[iRow, 34].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_6");
                    spdList.Sheets[0].Cells[iRow, 35].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_7");
                    spdList.Sheets[0].Cells[iRow, 36].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_8");
                    spdList.Sheets[0].Cells[iRow, 37].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_9");
                    spdList.Sheets[0].Cells[iRow, 38].Value = out_node.GetList(0)[i].GetString("TRAN_CMF_10");
                    spdList.Sheets[0].Cells[iRow, 39].Value = out_node.GetList(0)[i].GetString("RELEASE_USER_ID");
                    spdList.Sheets[0].Cells[iRow, 40].Value = out_node.GetList(0)[i].GetString("RELEASE_COMMENT");
                }
                in_node.SetString("NEXT_TRAN_TIME", out_node.GetString("NEXT_TRAN_TIME"));
                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (out_node.GetString("NEXT_LOT_ID") != "");

            MPCF.FitColumnHeader(spdList);


            return true;

            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewTroubleLotList_Load(object sender, System.EventArgs e)
        {
            
            dtpFrom.Value = dtpTo.Value.AddDays(- 7);
            
        }
        
        private void frmWIPViewTroubleLotList_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            View_Trouble_Lot_List();
            
        }
        
        private bool GetTroubleLotForm(string sLotID, int iHistSeq)
        {
            
            frmWIPTranTroubleLot f;
            
            try
            {
                f = (frmWIPTranTroubleLot)MPCF.GetChildForm(MPGV.gfrmMDI, "frmWIPTranTroubleLot");
                if (f == null)
                {
                    f = new frmWIPTranTroubleLot();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.sLotID = sLotID;
                    f.sOrgLotID = sLotID;
                    f.Hist_Seq = iHistSeq;
                    f.Show();
                }
                else
                {
                    f.b_load_flag = false;
                    f.sLotID = sLotID;
                    f.sOrgLotID = sLotID;
                    f.Hist_Seq = iHistSeq;
                    f.Activate();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "GetTroubleLotForm()", 0, 1);
                return false;
            }
        }
        
        //Trouble lot
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (spdList.Sheets[0].RowCount < 1)
                {
                    return;
                }
                if (spdList.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                string sLotID = MPCF.Trim(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 0].Value);
                int iHistSeq = MPCF.ToInt(MPCF.ToDbl(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 14].Value));
                if (GetTroubleLotForm(sLotID, iHistSeq) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //private void spdList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
        //    try
        //    {
        //        if (spdList.Sheets[0].RowCount < 1)
        //        {
        //            return;
        //        }
        //        if (spdList.Sheets[0].ActiveRowIndex < 0)
        //        {
        //            return;
        //        }
        //        string sLotID = MPCF.Trim(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 0].Value);
        //        int iHistSeq = MPCF.ToInt(MPCF.ToDbl(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 14].Value));
        //        if (GetTroubleLotForm(sLotID, iHistSeq) == false)
        //        {
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //    }
        //}
        
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Version : " + cdvMaterial.Version + "\r";
            sCond = sCond + "Date : " + dtpFrom.Value.ToString("yyyy/MM/dd") + " ~ " + dtpTo.Value.ToString("yyyy/MM/dd");

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
        
    
        private void cdvHoldCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvHoldCode.Init();
            MPCF.InitListView(cdvHoldCode.GetListView);
            cdvHoldCode.Columns.Add("Code", 100, HorizontalAlignment.Left);
            cdvHoldCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvHoldCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);
        }

        //Add by J.S. 2012.06.13 focus°¡ È£ÃâÇÑ ÆûÀ¸·Î µ¹¾Æ¿À´Â ¹®Àç ¶§¹®¿¡ ¼öÁ¤
        private void spdList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (b_dclic_flag == true)
                {
                    if (spdList.Sheets[0].RowCount < 1)
                    {
                        return;
                    }
                    if (spdList.Sheets[0].ActiveRowIndex < 0)
                    {
                        return;
                    }
                    string sLotID = MPCF.Trim(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 0].Value);
                    int iHistSeq = MPCF.ToInt(MPCF.ToDbl(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 14].Value));
                    if (GetTroubleLotForm(sLotID, iHistSeq) == false)
                    {
                        return;
                    }
                }
                b_dclic_flag = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            b_dclic_flag = true;
        }
    }
    
}
