
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.TRSCore;

//'#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class udcQCMBatchInfo : System.Windows.Forms.UserControl
    {
        
        
        #region " Windows Form auto generated code "
        
        public udcQCMBatchInfo()
        {
            
            //???¸ì¶œ?€ Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
            InitializeComponent();
            
            //InitializeComponent()ë¥??¸ì¶œ???¤ìŒ??ì´ˆê¸°???‘ì—…??ì¶”ê??˜ì‹­?œì˜¤.
            this.spdBatchInfo.Tag = "Change Cell";
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
        
        //Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
        private System.ComponentModel.Container components = null;
        
        //ì°¸ê³ : ?¤ìŒ ?„ë¡œ?œì???Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
        //Windows Form ?”ìž?´ë„ˆë¥??¬ìš©?˜ì—¬ ?˜ì •?????ˆìŠµ?ˆë‹¤.
        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private FarPoint.Win.Spread.FpSpread spdBatchInfo;
        private FarPoint.Win.Spread.SheetView spdBatchInfo_LotInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            this.spdBatchInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdBatchInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchInfo_LotInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // spdBatchInfo
            // 
            this.spdBatchInfo.AccessibleDescription = "spdBatchInfo, LotInfo, Row 0, Column 0, Batch ID";
            this.spdBatchInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdBatchInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdBatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatchInfo.HorizontalScrollBar.Name = "";
            this.spdBatchInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdBatchInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdBatchInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdBatchInfo.Location = new System.Drawing.Point(0, 0);
            this.spdBatchInfo.MoveActiveOnFocus = false;
            this.spdBatchInfo.Name = "spdBatchInfo";
            this.spdBatchInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdBatchInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdBatchInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdBatchInfo_LotInfo});
            this.spdBatchInfo.Size = new System.Drawing.Size(714, 122);
            this.spdBatchInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdBatchInfo.TabIndex = 4;
            this.spdBatchInfo.TabStop = false;
            this.spdBatchInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdBatchInfo.TextTipDelay = 200;
            this.spdBatchInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdBatchInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatchInfo.VerticalScrollBar.Name = "";
            this.spdBatchInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdBatchInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdBatchInfo_LotInfo
            // 
            this.spdBatchInfo_LotInfo.Reset();
            this.spdBatchInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdBatchInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdBatchInfo_LotInfo.ColumnCount = 6;
            this.spdBatchInfo_LotInfo.RowCount = 12;
            this.spdBatchInfo_LotInfo.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(0, 0).Value = "Batch ID";
            this.spdBatchInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(0, 2).Value = "Batch Hist Seq";
            this.spdBatchInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(0, 4).Value = "Material(Ver)";
            this.spdBatchInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(1, 0).Value = "Insp Step";
            this.spdBatchInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(1, 2).Value = "Inspection Type";
            this.spdBatchInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(1, 4).Value = "Inspection Method";
            this.spdBatchInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(2, 0).Value = "Insp. Set ID";
            this.spdBatchInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(2, 2).Value = "Insp. Set Version";
            this.spdBatchInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(2, 4).Value = "Batch Qty";
            this.spdBatchInfo_LotInfo.Cells.Get(3, 0).Value = "Insp. Seq.";
            this.spdBatchInfo_LotInfo.Cells.Get(3, 2).Value = "Total Inspection";
            this.spdBatchInfo_LotInfo.Cells.Get(3, 4).Value = "Skip Result Record";
            this.spdBatchInfo_LotInfo.Cells.Get(4, 0).Value = "PO";
            this.spdBatchInfo_LotInfo.Cells.Get(4, 2).Value = "PO Item";
            this.spdBatchInfo_LotInfo.Cells.Get(4, 4).Value = "Invoice";
            this.spdBatchInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(5, 0).Value = "Box ID";
            this.spdBatchInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(5, 2).Value = "Vendor";
            this.spdBatchInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(5, 4).Value = "Return Delivery ID";
            this.spdBatchInfo_LotInfo.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(6, 0).Value = "Order ID";
            this.spdBatchInfo_LotInfo.Cells.Get(6, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(6, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(6, 2).Value = "Customer";
            this.spdBatchInfo_LotInfo.Cells.Get(6, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(6, 4).Value = "Item Count";
            this.spdBatchInfo_LotInfo.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(7, 0).Value = "Auto Final";
            this.spdBatchInfo_LotInfo.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(7, 2).Value = "Final Result";
            this.spdBatchInfo_LotInfo.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(7, 4).Value = "Bat Cmf 1";
            this.spdBatchInfo_LotInfo.Cells.Get(8, 0).Value = "Bat Cmf 2";
            this.spdBatchInfo_LotInfo.Cells.Get(8, 2).Value = "Bat Cmf 3";
            this.spdBatchInfo_LotInfo.Cells.Get(8, 4).Value = "Bat Cmf 4";
            this.spdBatchInfo_LotInfo.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(9, 0).Value = "Bat Cmf 5";
            this.spdBatchInfo_LotInfo.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(9, 2).Value = "Bat Cmf 6";
            this.spdBatchInfo_LotInfo.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(9, 4).Value = "Bat Cmf 7";
            this.spdBatchInfo_LotInfo.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(10, 0).Value = "Bat Cmf 8";
            this.spdBatchInfo_LotInfo.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(10, 2).Value = "Bat Cmf 9";
            this.spdBatchInfo_LotInfo.Cells.Get(10, 4).Value = "Bat Cmf 10";
            this.spdBatchInfo_LotInfo.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(11, 0).Value = "Comment";
            this.spdBatchInfo_LotInfo.Cells.Get(11, 1).ColumnSpan = 5;
            this.spdBatchInfo_LotInfo.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(11, 2).Value = "End Time";
            this.spdBatchInfo_LotInfo.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Cells.Get(11, 4).Value = "End Res ID";
            this.spdBatchInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdBatchInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdBatchInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdBatchInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdBatchInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdBatchInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchInfo_LotInfo.Columns.Get(0).Width = 105F;
            this.spdBatchInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(1).Locked = false;
            this.spdBatchInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchInfo_LotInfo.Columns.Get(1).Width = 127F;
            this.spdBatchInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdBatchInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdBatchInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdBatchInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchInfo_LotInfo.Columns.Get(2).Width = 105F;
            this.spdBatchInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(3).Locked = false;
            this.spdBatchInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchInfo_LotInfo.Columns.Get(3).Width = 127F;
            this.spdBatchInfo_LotInfo.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdBatchInfo_LotInfo.Columns.Get(4).Border = compoundBorder3;
            this.spdBatchInfo_LotInfo.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(4).Locked = true;
            this.spdBatchInfo_LotInfo.Columns.Get(4).Width = 105F;
            this.spdBatchInfo_LotInfo.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchInfo_LotInfo.Columns.Get(5).Locked = false;
            this.spdBatchInfo_LotInfo.Columns.Get(5).Width = 127F;
            this.spdBatchInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdBatchInfo_LotInfo.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdBatchInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdBatchInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdBatchInfo_LotInfo.RowHeader.Visible = false;
            this.spdBatchInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(6).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(7).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(8).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(9).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(10).Height = 17F;
            this.spdBatchInfo_LotInfo.Rows.Get(11).Height = 17F;
            this.spdBatchInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdBatchInfo_LotInfo.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdBatchInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcQCMBatchInfo
            // 
            this.Controls.Add(this.spdBatchInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcQCMBatchInfo";
            this.Size = new System.Drawing.Size(714, 122);
            this.Load += new System.EventHandler(this.udcBatchInfo_Load);
            this.Resize += new System.EventHandler(this.udcBatchInfo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchInfo_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Property Definition"
        
        public string HistSeq
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[0, 3].Value);
            }
        }
        
        public string MatID
        {
            get
            {
                string sMatId = "";
                int iMatVer = 0;

                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdBatchInfo.Sheets[0].Cells[0, 5].Text, ref sMatId, ref iMatVer);
                if (sMatId != "")
                {
                    sMatId = sMatId.Substring(0, sMatId.IndexOf(":"));
                }
                return sMatId;
            }
        }


        public int MatVer
        {
            get
            {
                string sMatId = "";
                int iMatVer = 0;

                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdBatchInfo.Sheets[0].Cells[0, 5].Text, ref sMatId, ref iMatVer);
                return iMatVer;
            }
        }
        
        public string InspType
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[1, 3].Value);
            }
        }
        
        public string InspMethod
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[1, 5].Value);
            }
        }
        
        public string InspSet
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[2, 1].Value);
            }
        }
        
        public string InspSetVersion
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[2, 3].Value);
            }
        }
        
        public string Qty1
        {
            get
            {
                string sQty1 = "";
                sQty1 = MPCF.Trim(spdBatchInfo.Sheets[0].Cells[2, 5].Text);
                //if (sQty1 != "")
                //{
                //    sQty1 = sQty1.Substring(0, sQty1.IndexOf("/"));
                //}
                return sQty1;
            }
        }
        
        //public string Qty2
        //{
        //    get
        //    {
        //        string sQty2 = "";
        //        sQty2 = MPCF.Trim(spdBatchInfo.Sheets[0].Cells[2, 5].Text);
        //        if (sQty2 != "")
        //        {
        //            sQty2 = sQty2.Substring(sQty2.IndexOf("/") + 1, sQty2.LastIndexOf("/") - sQty2.IndexOf("/") - 1);
        //        }
        //        return sQty2;
        //    }
        //}
        
        //public string Qty3
        //{
        //    get
        //    {
        //        string sQty3 = "";
        //        sQty3 = MPCF.Trim(spdBatchInfo.Sheets[0].Cells[2, 5].Text);
        //        if (sQty3 != "")
        //        {
        //            sQty3 = sQty3.Substring(sQty3.LastIndexOf("/") + 1);
        //        }
        //        return sQty3;
        //    }
        //}

        public string SkipResult
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[3, 5].Value);
            }
        }
        
        public string PO
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[4, 1].Value);
            }
        }
        
        public string POItem
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[4, 3].Value);
            }
        }
        
        public string Invoice
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[4, 5].Value);
            }
        }
        
        public string BoxID
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[5, 1].Value);
            }
        }
        
        public string Venodr
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[5, 3].Value);
            }
        }
        
        public string RetDlvID
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[5, 5].Value);
            }
        }
        
        public string OrderID
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[6, 1].Value);
            }
        }
        
        public string Customer
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[6, 3].Value);
            }
        }
        
        public string ItemCount
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[6, 5].Value);
            }
        }
        
        public string FinalDecision
        {
            get
            {
                return MPCF.Trim(spdBatchInfo.Sheets[0].Cells[7, 3].Value);
            }
        }
        
        #endregion
        
        #region "Function Definition"
        
        public bool ViewBatchInformation(string sBatchID, string sStep)
        {
            try
            {
                ClearBatchInfo();
                
                View_Batch_Info(sBatchID, sStep);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // View_Batch_Info()
        //       - View Batch Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Batch_Info(string sBatchID, string sStep)
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_INFO_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_INFO_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", sBatchID);

                if (MPCR.CallService("QCM", "QCM_View_Batch_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("SKIP_RESULT_RECORD") == 'Y')
                {
                    if (MPCF.Trim(sStep) == "RESULT")
                    {
                        MPCF.ShowMsgBox("This Batch must skip the result recording");
                        return false;
                    }
                }

                FarPoint.Win.Spread.SheetView with_1 = spdBatchInfo.Sheets[0];

                with_1.SetValue(0, 1, sBatchID);
                with_1.SetValue(0, 3, MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ")));
                with_1.SetValue(0, 5, MPCF.Trim(out_node.GetString("MAT_ID")) + " : " +
                                      MPCF.Trim(out_node.GetString("MAT_DESC")) + "(" +
                                      MPCF.Trim(out_node.GetInt("MAT_VER")) + ")");

                with_1.SetValue(1, 1, MPCF.Trim(out_node.GetString("INSP_STEP")));
                with_1.SetValue(1, 3, MPCF.Trim(out_node.GetString("INSP_TYPE")));
                with_1.SetValue(1, 5, MPCF.Trim(out_node.GetString("INSP_METHOD")));

                with_1.SetValue(2, 1, MPCF.Trim(out_node.GetString("INSP_SET_ID")));
                with_1.SetValue(2, 3, MPCF.Trim(out_node.GetInt("INSP_SET_VERSION")));
                with_1.SetValue(2, 5, MPCF.Trim(out_node.GetDouble("QTY_1")));

                with_1.SetValue(3, 1, MPCF.Trim(out_node.GetInt("INSP_SEQ")));
                //Modify by J.S. 2009.04.09
                with_1.SetValue(3, 3, MPCF.Trim(out_node.GetInt("TOTAL_INSP")));
                with_1.SetValue(3, 5, MPCF.Trim(out_node.GetChar("SKIP_RESULT_RECORD")));

                with_1.SetValue(4, 1, MPCF.Trim(out_node.GetString("PO")));
                with_1.SetValue(4, 3, MPCF.Trim(out_node.GetString("PO_ITEM")));
                with_1.SetValue(4, 5, MPCF.Trim(out_node.GetString("INVOICE")));

                with_1.SetValue(5, 1, MPCF.Trim(out_node.GetString("BOX_ID")));
                with_1.SetValue(5, 3, MPCF.Trim(out_node.GetString("VENDOR")));
                with_1.SetValue(5, 5, MPCF.Trim(out_node.GetString("RET_DLV_ID")));

                with_1.SetValue(6, 1, MPCF.Trim(out_node.GetString("ORDER_ID")));
                with_1.SetValue(6, 3, MPCF.Trim(out_node.GetString("CUSTOMER")));
                with_1.SetValue(6, 5, MPCF.Trim(out_node.GetInt("ITEM_COUNT")));

                with_1.SetValue(7, 1, MPCF.Trim(out_node.GetChar("AUTO_FINAL")));
                with_1.SetValue(7, 3, MPCF.Trim(out_node.GetString("FINAL_DECISION")));
                with_1.SetValue(7, 5, MPCF.Trim(out_node.GetString("BAT_CMF_1")));

                with_1.SetValue(8, 1, MPCF.Trim(out_node.GetString("BAT_CMF_2")));
                with_1.SetValue(8, 3, MPCF.Trim(out_node.GetString("BAT_CMF_3")));
                with_1.SetValue(8, 5, MPCF.Trim(out_node.GetString("BAT_CMF_4")));

                with_1.SetValue(9, 1, MPCF.Trim(out_node.GetString("BAT_CMF_5")));
                with_1.SetValue(9, 3, MPCF.Trim(out_node.GetString("BAT_CMF_6")));
                with_1.SetValue(9, 5, MPCF.Trim(out_node.GetString("BAT_CMF_7")));

                with_1.SetValue(10, 1, MPCF.Trim(out_node.GetString("BAT_CMF_8")));
                with_1.SetValue(10, 3, MPCF.Trim(out_node.GetString("BAT_CMF_9")));
                with_1.SetValue(10, 5, MPCF.Trim(out_node.GetString("BAT_CMF_10")));

                with_1.SetValue(11, 1, MPCF.Trim(out_node.GetString("COMMENT")));


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        // ClearBatchInfo()
        //       - Clear Batch Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public void ClearBatchInfo()
        {
            
            try
            {
                //Initilize spdBatchinfo
                spdBatchInfo.Sheets[0].Cells[0, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[0, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[0, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[1, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[1, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[1, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[2, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[2, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[2, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[3, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[3, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[3, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[4, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[4, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[4, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[5, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[5, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[5, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[6, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[6, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[6, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[7, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[7, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[7, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[8, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[8, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[8, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[9, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[9, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[9, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[10, 1].Text = "";
                spdBatchInfo.Sheets[0].Cells[10, 3].Text = "";
                spdBatchInfo.Sheets[0].Cells[10, 5].Text = "";
                spdBatchInfo.Sheets[0].Cells[11, 1].Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        #endregion
        
        private void udcBatchInfo_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                object temp_object = this.Controls;
                MPCF.ConvertMessage((System.Windows.Forms.Control.ControlCollection)temp_object);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void udcBatchInfo_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                int iDiffSize;
                
                iDiffSize = (this.Size.Width - 714) / 3;
                
                if (iDiffSize >= 0)
                {
                    spdBatchInfo.Sheets[0].Columns[1].Width = 125 + iDiffSize;
                    spdBatchInfo.Sheets[0].Columns[3].Width = 125 + iDiffSize;
                    spdBatchInfo.Sheets[0].Columns[5].Width = 125 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcBatchInfo.udcBatchInfo_Resize()\n" + ex.Message);
            }
            
        }
        
    }
    
    //#End If
    
}
