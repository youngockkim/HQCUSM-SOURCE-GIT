using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public class udcAttributeStatus : UserControl
    {
        #region 구성 요소 디자이너에서 생성한 코드

        public udcAttributeStatus()
        {
            InitializeComponent();
        }

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

        private Panel pnlBottom;
        private GroupBox grpAttributeStatus;
        private FarPoint.Win.Spread.FpSpread spdAttrValue;
        private FarPoint.Win.Spread.SheetView spdAttrValue_Sheet1;
        private GroupBox grpBottom;
        private Button btnHistory;
        private Button btnDetail;

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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer6 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer6 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer7 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer7 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer8 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer8 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer9 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer9 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.grpBottom = new System.Windows.Forms.GroupBox();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.grpAttributeStatus = new System.Windows.Forms.GroupBox();
            this.spdAttrValue = new FarPoint.Win.Spread.FpSpread();
            this.spdAttrValue_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlBottom.SuspendLayout();
            this.grpBottom.SuspendLayout();
            this.grpAttributeStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).BeginInit();
            this.SuspendLayout();
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
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            columnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer6.Name = "columnHeaderRenderer6";
            columnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer6.TextRotationAngle = 0D;
            rowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer6.Name = "rowHeaderRenderer6";
            rowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer6.TextRotationAngle = 0D;
            columnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer7.Name = "columnHeaderRenderer7";
            columnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer7.TextRotationAngle = 0D;
            rowHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer7.Name = "rowHeaderRenderer7";
            rowHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer7.TextRotationAngle = 0D;
            columnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer8.Name = "columnHeaderRenderer8";
            columnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer8.TextRotationAngle = 0D;
            rowHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer8.Name = "rowHeaderRenderer8";
            rowHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer8.TextRotationAngle = 0D;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 287);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(500, 45);
            this.pnlBottom.TabIndex = 1;
            // 
            // grpBottom
            // 
            this.grpBottom.Controls.Add(this.btnDelRow);
            this.grpBottom.Controls.Add(this.btnUpdate);
            this.grpBottom.Controls.Add(this.btnDetail);
            this.grpBottom.Controls.Add(this.btnHistory);
            this.grpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBottom.Location = new System.Drawing.Point(0, 0);
            this.grpBottom.Name = "grpBottom";
            this.grpBottom.Size = new System.Drawing.Size(500, 45);
            this.grpBottom.TabIndex = 0;
            this.grpBottom.TabStop = false;
            // 
            // btnDelRow
            // 
            this.btnDelRow.Enabled = false;
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelRow.Location = new System.Drawing.Point(6, 12);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(88, 26);
            this.btnDelRow.TabIndex = 4;
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(223, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(314, 12);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(88, 26);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "Detail";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(405, 12);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 2;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // grpAttributeStatus
            // 
            this.grpAttributeStatus.Controls.Add(this.spdAttrValue);
            this.grpAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttributeStatus.Location = new System.Drawing.Point(0, 0);
            this.grpAttributeStatus.Name = "grpAttributeStatus";
            this.grpAttributeStatus.Size = new System.Drawing.Size(500, 287);
            this.grpAttributeStatus.TabIndex = 0;
            this.grpAttributeStatus.TabStop = false;
            this.grpAttributeStatus.Text = "Attributes";
            this.grpAttributeStatus.Resize += new System.EventHandler(this.grpAttributeStatus_Resize);
            // 
            // spdAttrValue
            // 
            this.spdAttrValue.AccessibleDescription = "spdAttrValue, Sheet1, Row 0, Column 0, ";
            this.spdAttrValue.BackColor = System.Drawing.SystemColors.Control;
            this.spdAttrValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAttrValue.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAttrValue.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.HorizontalScrollBar.Name = "";
            this.spdAttrValue.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAttrValue.HorizontalScrollBar.TabIndex = 14;
            this.spdAttrValue.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.Location = new System.Drawing.Point(3, 16);
            this.spdAttrValue.Name = "spdAttrValue";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            columnHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer9.Name = "";
            columnHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer9.TextRotationAngle = 0D;
            namedStyle1.Renderer = columnHeaderRenderer9;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            rowHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer9.Name = "";
            rowHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer9.TextRotationAngle = 0D;
            namedStyle2.Renderer = rowHeaderRenderer9;
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
            this.spdAttrValue.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdAttrValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdAttrValue.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAttrValue.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAttrValue.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAttrValue_Sheet1});
            this.spdAttrValue.Size = new System.Drawing.Size(494, 268);
            this.spdAttrValue.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAttrValue.TabIndex = 0;
            this.spdAttrValue.TextTipDelay = 200;
            this.spdAttrValue.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAttrValue.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.VerticalScrollBar.Name = "";
            this.spdAttrValue.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAttrValue.VerticalScrollBar.TabIndex = 15;
            this.spdAttrValue.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdAttrValue_EnterCell);
            this.spdAttrValue.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdAttrValue_CellDoubleClick);
            this.spdAttrValue.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_ButtonClicked);
            this.spdAttrValue.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_EditChange);
            // 
            // spdAttrValue_Sheet1
            // 
            this.spdAttrValue_Sheet1.Reset();
            spdAttrValue_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAttrValue_Sheet1.ColumnCount = 14;
            spdAttrValue_Sheet1.RowCount = 3;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Null";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Array Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Array Separator";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Value Format";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Value Size";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Valid Table";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Table Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Allow Blank";
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAttrValue_Sheet1.Columns.Get(0).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Width = 25F;
            this.spdAttrValue_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(1).Label = "Name";
            this.spdAttrValue_Sheet1.Columns.Get(1).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdAttrValue_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(1).Width = 170F;
            this.spdAttrValue_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(2).Label = "Description";
            this.spdAttrValue_Sheet1.Columns.Get(2).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdAttrValue_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(2).Width = 170F;
            this.spdAttrValue_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 110;
            textCellType1.Multiline = true;
            textCellType1.WordWrap = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(3).Label = "Current Value";
            this.spdAttrValue_Sheet1.Columns.Get(3).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(3).Width = 80F;
            this.spdAttrValue_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.White;
            this.spdAttrValue_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdAttrValue_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdAttrValue_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(4).Width = 80F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdAttrValue_Sheet1.Columns.Get(5).CellType = buttonCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(5).Resizable = false;
            this.spdAttrValue_Sheet1.Columns.Get(5).Width = 20F;
            this.spdAttrValue_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdAttrValue_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Label = "Null";
            this.spdAttrValue_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Width = 30F;
            this.spdAttrValue_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAttrValue_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAttrValue_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvTableData
            // 
            this.cdvTableData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableData.Location = new System.Drawing.Point(189, 17);
            this.cdvTableData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Name = "cdvTableData";
            this.cdvTableData.Size = new System.Drawing.Size(20, 20);
            this.cdvTableData.SmallImageList = null;
            this.cdvTableData.TabIndex = 0;
            this.cdvTableData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableData.VisibleColumnHeader = false;
            this.cdvTableData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableData_SelectedItemChanged);
            // 
            // udcAttributeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpAttributeStatus);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "udcAttributeStatus";
            this.Size = new System.Drawing.Size(500, 332);
            this.pnlBottom.ResumeLayout(false);
            this.grpBottom.ResumeLayout(false);
            this.grpAttributeStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "
        /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
        public enum udcAttributeStatusLayout
        {
            VIEW,
            VIEW_AND_UPDATE
        }

        private enum ATTR_COL
        {
            CHECK,             // 0
            ATTR_NAME,         // 1
            ATTR_DESC,         // 2
            OLD_VALUE,         // 3
            NEW_VALUE,         // 4
            NEW_VALUE_BTN,     // 5
            NULL,              // 6
            ARRAY_TYPE_FLAG,   // 7
            ARRAY_SEPERATOR,   // 8
            VALUE_FORMAT,      // 9
            VALUE_SIZE,        // 10
            VALID_TABLE_NAME,  // 11
            VALID_TABLE_TYPE,  // 12
            ALLOW_BLANK
        }
        
        private const int MAX_VALUE_COUNT = 500;
        /*** End of Add (2012.04.13) ***/
        #endregion

        #region " Variable Definition "

        private string sAttrType ="";
        private string sAttrName ="";
        private string sAttrKey ="";
        private int iAttrFrom = 0;
        private Button btnUpdate;
        private int iAttrTo = Int32.MaxValue;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
        private Button btnDelRow;

        /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
        private udcAttributeStatusLayout m_layout = udcAttributeStatusLayout.VIEW;
        /*** End of Add (2012.04.13) ***/

        private string sAttrFactory = "";

        /// <summary>
        /// true : DataType이 ArrayType인 경우 NullCell을 Merge해서 보여준다.
        /// </summary>
        private bool bNullCheckMerge = false;

        #endregion

        #region " Property Definition "

        private FarPoint.Win.Spread.SheetView svData
        {
            get { return spdAttrValue_Sheet1; }
        }

        public string AttributeType
        {
            get
            {
                return sAttrType;
            }
            set
            {
                sAttrType = value;
            }
        }

        public string AttributeName
        {
            get
            {
                return sAttrName;
            }
            set
            {
                sAttrName = value;
            }
        }

        public string AttributeKey
        {
            get
            {
                return sAttrKey;
            }
            set
            {
                sAttrKey = value;
            }
        }

        public string AttributeFactory
        {
            get
            {
                return sAttrFactory;
            }
            set
            {
                sAttrFactory = value;
            }
        }

        public int FromSequence
        {
            get
            {
                return iAttrFrom;
            }
            set
            {
                iAttrFrom = value;
            }
        }

        public int ToSequence
        {
            get
            {
                return iAttrTo;
            }
            set
            {
                iAttrTo = value;
            }
        }

        /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public udcAttributeStatusLayout AttributeLayout
        {
            get
            {
                return m_layout;
            }
            set
            {
                m_layout = value;
                SetLayout(m_layout);
            }
        }
        /*** End of Add (2012.04.13) ***/

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableUpdateButton
        {
            get
            {
                return btnUpdate.Enabled;
            }
            set
            {
                btnUpdate.Enabled = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VisibleUpdateButton
        {
            get
            {
                return btnUpdate.Visible;
            }
            set
            {
                btnUpdate.Visible = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableHistoryButton
        {
            get
            {
                return btnHistory.Enabled;
            }
            set
            {
                btnHistory.Enabled = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VisibleHistoryButton
        {
            get
            {
                return btnHistory.Visible;
            }
            set
            {
                btnHistory.Visible = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnableDetailButton
        {
            get
            {
                return btnDetail.Enabled;
            }
            set
            {
                btnDetail.Enabled = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VisibleDetailButton
        {
            get
            {
                return btnDetail.Visible;
            }
            set
            {
                btnDetail.Visible = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CheckedItemCount
        {
            get
            {
                string attr_name = "";
                int n = 0;
                int i, iRows = spdAttrValue.ActiveSheet.RowCount;
                for (i = 0; i < iRows; i++)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value != null && Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value) == true)
                    {
                        if (attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Value))
                        {
                            attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Value);
                            n++;
                        }
                    }
                }
                return n;
            }
        }


        #endregion

        #region " Function Definition"

        /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
        // ViewAttributeValue()
        //       - View Attribute Value
        // Return Value
        //       - boolean : True / False
        private bool ViewAttributeValue(string SpecRelId, int SpecRelVer, string CharID)
        {
            int i, i_row = 0;
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");
            List<TRSNode> value_list;

            MPCF.ClearList(spdAttrValue, true);

            MPCR.SetInMsg(in_node);

            if (MPCF.Trim(sAttrFactory) != "")
            {
                in_node.Factory = sAttrFactory;
            }

            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(sAttrType));
            in_node.AddString("ATTR_KEY", MPCF.Trim(sAttrKey));
            in_node.AddString("ATTR_NAME", MPCF.Trim(sAttrName));
            in_node.AddInt("ATTR_FROM", iAttrFrom);
            in_node.AddInt("ATTR_TO", iAttrTo);
            if (sAttrType == MPGC.MP_ATTR_TYPE_SPEC)
            {
                in_node.AddString("SPEC_REL_ID", MPCF.Trim(SpecRelId));
                in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(SpecRelVer));
                in_node.AddString("CHAR_ID", MPCF.Trim(CharID));
            }

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Value_Brief", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    value_list = out_node.GetList("VALUE_LIST");
                    for (i = 0; i < value_list.Count; i++)
                    {
                        /** Array Type 일 경우 Row 추가 부분 변경 **/
                        /** End of  2012-11-15   **/
                        if (value_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                        {
                            string[] sa_attr_values = value_list[i].GetString("ATTR_VALUE").Split(value_list[i].GetChar("ARRAY_SEPARATOR"));
                            int i_first_row = spdAttrValue.ActiveSheet.RowCount;
                            for (int i_cnt = 0; i_cnt < sa_attr_values.Length; i_cnt++)
                            {
                                /* ROW 추가 */
                                i_row = spdAttrValue.ActiveSheet.RowCount;
                                spdAttrValue.ActiveSheet.RowCount++;

                                /** 값 설정  **/
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                                spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");
                                spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                                spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                                spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                                spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                                spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                                spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");

                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = sa_attr_values[i_cnt];
                                //spdAttrValue.ActiveSheet.Cells[i_row, 4].Value = sa_attr_values[i_cnt];

                                /* Cell 타입 지정 */
                                SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                                if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                                {
                                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                                }
                            }

                            if (m_layout == udcAttributeStatusLayout.VIEW_AND_UPDATE)
                            {
                                if (value_list[i].GetChar("NULL_FLAG") == 'Y' || (sa_attr_values.Length == 1 && sa_attr_values[0] == ""))
                                {
                                    ;
                                }
                                else
                                {
                                    AddArrayTypeRow(i_row, false);
                                }
                            }
                        }
                        else
                        {
                            /* ROW 추가 */
                            i_row = spdAttrValue.ActiveSheet.RowCount;
                            spdAttrValue.ActiveSheet.RowCount++;

                            /** 값 설정  **/
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                            spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                            spdAttrValue.ActiveSheet.Cells[i_row, 3].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");
                            spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                            spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                            spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                            spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                            spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                            spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");

                            /* Cell 타입 지정 */
                            SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                            if (value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y')
                            {
                                string value = value_list[i].GetString("ATTR_VALUE");
                                value_list[i].SetString("ATTR_VALUE", value += " ...");
                            }

                            if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                            }
                            else
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = value_list[i].GetString("ATTR_VALUE");
                            }

                            spdAttrValue.ActiveSheet.Rows[i_row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(i_row);
                        }
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        private void SetCellTypeByAttribute(TRSNode out_node, FarPoint.Win.Spread.Cell cell)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            CultureInfo ci_local = CultureInfo.CurrentCulture;

            int i_row = cell.Row.Index;

            switch (out_node.GetChar("ATTR_FMT"))
            {
                case 'A':
                    txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                    txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                    txtCell.MaxLength = out_node.GetInt("ATTR_SIZE");
                    txtCell.WordWrap = true;
                    txtCell.Multiline = true;

                    cell.CellType = txtCell;
                    break;
                case 'N':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;

                    cell.CellType = numCell;
                    break;
                case 'F':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 3;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;
                    numCell.DecimalSeparator = ci_local.NumberFormat.NumberDecimalSeparator;

                    cell.CellType = numCell;
                    break;
            }

            if (out_node.GetString("VALID_TBL") == "")
            {
                spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
            }
            else
            {
                // Cell 타입 지정
                if (out_node.GetChar("VALID_TBL_TYPE") == 'A' || out_node.GetChar("VALID_TBL_TYPE") == 'Q')
                {
                    btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = "...";
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].CellType = btnCell;
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].Tag = out_node.GetString("VALID_TBL");
                }
                else
                {
                    spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
                }

                if (out_node.GetChar("ALLOW_BLANK") == 'Y')
                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Tag = 'Y';
            }
        }

        private void SetCellTypeByAttribute(FarPoint.Win.Spread.SheetView spdView, FarPoint.Win.Spread.Cell cell)
        {
            TRSNode a_node;
            int i_row = cell.Row.Index;

            a_node = new TRSNode("Cell Format");
            a_node.AddChar("ATTR_FMT", MPCF.ToChar(spdView.Cells[cell.Row.Index, 9].Value));
            a_node.AddInt("ATTR_SIZE", MPCF.ToInt(spdView.Cells[cell.Row.Index, 10].Value));
            a_node.AddString("VALID_TBL", MPCF.Trim(spdView.Cells[cell.Row.Index, 11].Value));
            a_node.AddChar("VALID_TBL_TYPE", MPCF.ToChar(spdView.Cells[cell.Row.Index, 12].Value));
            a_node.AddChar("ALLOW_BLANK", MPCF.ToChar(spdView.Cells[cell.Row.Index, 13].Value));

            SetCellTypeByAttribute(a_node, cell);
        }

        private void AddArrayTypeRow(int i_row, bool b_update_check)
        {
            bool b_insert_row;

            try
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, (int)ATTR_COL.ARRAY_TYPE_FLAG].Value) != "Y") return;
                b_insert_row = false;

                /* Add New Empty Row */
                if (i_row + 1 < spdAttrValue.ActiveSheet.RowCount)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Value != spdAttrValue.ActiveSheet.Cells[i_row + 1, (int)ATTR_COL.ATTR_NAME].Value)
                    {
                        b_insert_row = true;
                        spdAttrValue.ActiveSheet.Rows.Add(i_row + 1, 1);
                    }
                }
                else if (i_row + 1 == spdAttrValue.ActiveSheet.RowCount)
                {
                    b_insert_row = true;
                    spdAttrValue.ActiveSheet.RowCount++;
                }
                if (b_insert_row == true)
                {
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value = spdAttrValue.ActiveSheet.Cells[i_row, 1].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 2].Value = spdAttrValue.ActiveSheet.Cells[i_row, 2].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 4].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 7].Value = spdAttrValue.ActiveSheet.Cells[i_row, 7].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 8].Value = spdAttrValue.ActiveSheet.Cells[i_row, 8].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 9].Value = spdAttrValue.ActiveSheet.Cells[i_row, 9].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 10].Value = spdAttrValue.ActiveSheet.Cells[i_row, 10].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 11].Value = spdAttrValue.ActiveSheet.Cells[i_row, 11].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 12].Value = spdAttrValue.ActiveSheet.Cells[i_row, 12].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 13].Value = spdAttrValue.ActiveSheet.Cells[i_row, 13].Value;

                    SetCellTypeByAttribute(spdAttrValue.ActiveSheet, spdAttrValue.ActiveSheet.Cells[i_row + 1, 4]);
                }

                SetArrayTypeRow(i_row, b_update_check);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetArrayTypeRow(int i_row, bool b_update_check)
        {
            SetArrayTypeRow(i_row, b_update_check, false, false);
        }
        private void SetArrayTypeRow(int i_row, bool b_update_check, bool b_update_null, bool b_set_null)
        {
            int i_first_row, i_last_row;
            int i_length = 0;

            i_first_row = i_last_row = i_row;

            try
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, (int)ATTR_COL.ARRAY_TYPE_FLAG].Value) != "Y") return;

                /*Find Row*/
                for (int i = i_row; i >= 0; i--)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Value != spdAttrValue.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Value)
                        break;
                    i_first_row = i;
                }
                for (int i = i_row; i < spdAttrValue_Sheet1.RowCount; i++)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Value != spdAttrValue.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Value)
                        break;
                    i_last_row = i;
                }
                i_length = i_last_row - i_first_row + 1;

                /*CheckBox Check*/
                if (b_update_check)
                {
                    for (int i = i_first_row ; i < i_last_row; i++)
                    {
                        spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value = true;
                    }
                }
                /*Null Value*/
                if (b_update_null)
                {
                    if (b_set_null)
                    {
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.CHECK].Value = true;
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE].Value = "[Null]";
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE].Locked = true;
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE_BTN].Locked = true;
                    }
                    else
                    {
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE].Value = "";
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE].Locked = false;
                        spdAttrValue.ActiveSheet.Cells[i_first_row, (int)ATTR_COL.NEW_VALUE_BTN].Locked = false;
                    }
                    for (int i = i_first_row + 1; i <= i_last_row; i++)
                    {
                        if (b_set_null)
                        {
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value = "";
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Locked = true;
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE_BTN].Locked = true;
                        }
                        else
                        {
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Locked = false;
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE_BTN].Locked = false;
                        }
                    }
                }
                else
                {
                    /*Null Check*/
                    spdAttrValue_Sheet1.Cells[i_first_row, (int)ATTR_COL.NULL].Locked = false;
                    for (int i = i_first_row + 1; i <= i_last_row; i++)
                    {
                        spdAttrValue_Sheet1.Cells[i, (int)ATTR_COL.NULL].Locked = true;
                    }
                    /*Null Flag RowSpan*/
                    if (bNullCheckMerge) spdAttrValue_Sheet1.Cells[i_first_row, (int)ATTR_COL.NULL].RowSpan = i_length;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetButtonEnable(int i_row)
        {
            if (i_row < 0 || svData.RowCount == 0)
            {
                btnDelRow.Enabled = false;
                return;
            }
            if (MPCF.Trim(svData.Cells[i_row, (int)ATTR_COL.ARRAY_TYPE_FLAG].Value) == "Y")
            {
                /*If Current Row is last row then Disable Button */
                if (i_row == svData.Rows.Count - 1) btnDelRow.Enabled = false;
                else if (svData.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Value != svData.Cells[i_row + 1, (int)ATTR_COL.ATTR_NAME].Value) btnDelRow.Enabled = false;
                else btnDelRow.Enabled = true;
                return;
            }
            
            btnDelRow.Enabled = false;
        }

        /*** End of Modification (2012.04.13) ***/

        //
        // UpdateAttributeValue()
        //       - Change Attribute Value information
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       -
        //
        private bool UpdateAttributeValue()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item = null;
            int i, iStart, iCount;

            MPCR.SetInMsg(in_node);

            if (MPCF.Trim(sAttrFactory) != "")
            {
                in_node.Factory = sAttrFactory;
            }

            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", AttributeType);
            in_node.AddString("ATTR_KEY", AttributeKey);

            iStart = 0;
            iCount = spdAttrValue.ActiveSheet.RowCount;

            try
            {
                do
                {
                    if (iCount > MAX_VALUE_COUNT)
                        iCount = MAX_VALUE_COUNT;

                    for (i = iStart; i < iCount + iStart; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 0].Value == true)
                        {
                            if (spdAttrValue.ActiveSheet.Cells[i, 6].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 6].Value == true)
                            {
                                list_item = in_node.AddNode("VALUE_LIST");

                                list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                list_item.AddChar("NULL_FLAG", 'Y');
                                list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));

                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;
                                        i++;
                                    }
                                    i--;
                                }
                            }
                            else
                            {
                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type 일경우  병합해서 전송함
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    string s_separator = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 8].Value);
                                    string s_attr_value = "";
                                    int i_last_active_hist_seq = MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag);
                                    int i_array_value_count = 0;

                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;

                                        if (i_array_value_count < 1)
                                        {
                                            if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                            {
                                                s_attr_value = MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                            }
                                            else
                                            {
                                                s_attr_value = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 3].Value) == "" &&
                                                MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value) == "" &&
                                                (i + 1 == spdAttrValue.ActiveSheet.RowCount ||
                                                 s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value)))
                                            {
                                                ; // 위 조건일때 제외
                                            }
                                            else
                                            {
                                                if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                                }
                                                else
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                                }
                                            }
                                        }

                                        i++;
                                        i_array_value_count++;
                                    }
                                    i--;

                                    list_item = in_node.AddNode("VALUE_LIST");

                                    list_item.AddString("ATTR_NAME", s_attr_name);
                                    list_item.AddString("ATTR_VALUE", s_attr_value);
                                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", i_last_active_hist_seq);
                                }
                                else //기존 저장 로직 부분
                                {
                                    if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.TextCellType == true)
                                    { //Add by J.S. 2011.04.11 Ascii Type인 경우 어떠한 변환도 없이 처리 해야 한다.
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                    else if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                    {
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value)));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                }
                            }
                        }
                    }


                    if (MPCR.CallService("BAS", "BAS_Update_Attribute_Value", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (spdAttrValue.ActiveSheet.RowCount - (iCount + iStart) > 0)
                    {
                        iStart += iCount;
                        iCount = spdAttrValue.ActiveSheet.RowCount - iCount;
                    }
                    else
                    {
                        iStart = 0;
                        iCount = 0;
                    }

                } while (iStart != 0 || iCount != 0);

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public bool SetAttributeValue(TRSNode in_node)
        {
            TRSNode list_item = null;
            int i, iStart, iCount;

            //MPCR.SetInMsg(in_node);

            //if (MPCF.Trim(sAttrFactory) != "")
            //{
            //    in_node.Factory = sAttrFactory;
            //}

            //in_node.ProcStep = '1';

            if (CheckedItemCount <= 0) return false;

            try
            {
                in_node.AddString("ATTR_TYPE", AttributeType);
                in_node.AddString("ATTR_KEY", AttributeKey);

                iStart = 0;
                iCount = spdAttrValue.ActiveSheet.RowCount;

                //do
                //{
                //    if (iCount > MAX_VALUE_COUNT)
                //        iCount = MAX_VALUE_COUNT;

                    for (i = iStart; i < iCount + iStart; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 0].Value == true)
                        {
                            if (spdAttrValue.ActiveSheet.Cells[i, 6].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 6].Value == true)
                            {
                                list_item = in_node.AddNode("VALUE_LIST");

                                list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                list_item.AddChar("NULL_FLAG", 'Y');
                                list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));

                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;
                                        i++;
                                    }
                                    i--;
                                }
                            }
                            else
                            {
                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type 일경우  병합해서 전송함
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    string s_separator = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 8].Value);
                                    string s_attr_value = "";
                                    int i_last_active_hist_seq = MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag);
                                    int i_array_value_count = 0;

                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;

                                        if (i_array_value_count < 1)
                                        {
                                            if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                            {
                                                s_attr_value = MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                            }
                                            else
                                            {
                                                s_attr_value = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 3].Value) == "" &&
                                                MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value) == "" &&
                                                (i + 1 == spdAttrValue.ActiveSheet.RowCount ||
                                                 s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value)))
                                            {
                                                ; // 위 조건일때 제외
                                            }
                                            else
                                            {
                                                if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                                }
                                                else
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                                }
                                            }
                                        }

                                        i++;
                                        i_array_value_count++;
                                    }
                                    i--;

                                    list_item = in_node.AddNode("VALUE_LIST");

                                    list_item.AddString("ATTR_NAME", s_attr_name);
                                    list_item.AddString("ATTR_VALUE", s_attr_value);
                                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", i_last_active_hist_seq);
                                }
                                else //기존 저장 로직 부분
                                {
                                    if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.TextCellType == true)
                                    { //Add by J.S. 2011.04.11 Ascii Type인 경우 어떠한 변환도 없이 처리 해야 한다.
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                    else if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                    {
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value)));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                }
                            }
                        }
                    }
                    //if (spdAttrValue.ActiveSheet.RowCount - (iCount + iStart) > 0)
                    //{
                    //    iStart += iCount;
                    //    iCount = spdAttrValue.ActiveSheet.RowCount - iCount;
                    //}
                    //else
                    //{
                    //    iStart = 0;
                    //    iCount = 0;
                    //}
                //} while (iStart != 0 || iCount != 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분
        //
        public bool CheckCondition(char ProcStep)
        {
            switch (ProcStep)
            {
                case 'V':

                    break;
                case MPGC.MP_STEP_UPDATE:
                    bool bCheck = false;
                    bool bNullCheck = false;
                    int i, iRows = spdAttrValue.ActiveSheet.RowCount;
                    for (i = 0; i < iRows; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value != null && Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value) == true)
                        {
                            bCheck = true;
                        }
                        if (bCheck)
                        {
                            if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NULL].Value) == true)
                            {
                                bNullCheck = true;
                                break;
                            }
                        }
                    }

                    if (!bCheck) return false;
                    if (bNullCheck)
                    {
                        //Modified by DM KIM 2014.01.21  Message Number를 53 -> 64로 변경
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(64), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                            return false;
                    }
                    break;
            }

            return true;

        }

        public void ClearList()
        {
            MPCF.ClearList(spdAttrValue, true);
        }

        public void ClearValue()
        {
            spdAttrValue.ActiveSheet.ClearRange(0, 0, spdAttrValue.ActiveSheet.RowCount, 1, true);
            spdAttrValue.ActiveSheet.ClearRange(0, 3, spdAttrValue.ActiveSheet.RowCount, spdAttrValue.ActiveSheet.ColumnCount-3, true);
        }

        public FarPoint.Win.Spread.FpSpread GetSpread()
        {
            return spdAttrValue;
        }

        public Button GetUpdateButton()
        {
            return btnUpdate;
        }

        public Button GetHistoryButton()
        {
            return btnHistory;
        }

        public Button GetDetailButton()
        {
            return btnDetail;
        }

        public bool View()
        {
            return ViewAttributeValue("", 0, "");
        }
        public bool ViewbySPM(string SpecRelID, int SpecRelVer, string CharID)
        {
            return ViewAttributeValue(SpecRelID, SpecRelVer, CharID);
        }

        public void SetLayout(udcAttributeStatusLayout layout)
        {
            m_layout = layout;

            spdAttrValue.ActiveSheet.RowCount = 0;
            spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.CHECK].Visible = false;
            spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.NEW_VALUE, (int)ATTR_COL.NULL].Visible = false;

            /** #1088  Spread 스타일 지정을 위한 추가 필드 숨김처리(2012-11-19 SSKIM **/
            spdAttrValue.ActiveSheet.Columns[7].Visible = false;
            spdAttrValue.ActiveSheet.Columns[8].Visible = false;
            spdAttrValue.ActiveSheet.Columns[9].Visible = false;
            spdAttrValue.ActiveSheet.Columns[10].Visible = false;
            spdAttrValue.ActiveSheet.Columns[11].Visible = false;
            spdAttrValue.ActiveSheet.Columns[12].Visible = false;
            spdAttrValue.ActiveSheet.Columns[13].Visible = false;
            /** End of 2012-11-19  **/

            switch (m_layout)
            {
                case udcAttributeStatusLayout.VIEW:
                    btnUpdate.Visible = false;
                    btnDelRow.Visible = false;
                    break;

                case udcAttributeStatusLayout.VIEW_AND_UPDATE:
                    spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.CHECK].Visible = true;
                    spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.NEW_VALUE, (int)ATTR_COL.NULL].Visible = true;
                    btnUpdate.Visible = true;
                    btnDelRow.Visible = true;
                    btnUpdate.Enabled = true;
                    btnDelRow.Enabled = true;
                    break;
            }
        }
        /*** End of Add (2012.04.13) ***/

        #endregion

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (sAttrType != null && sAttrType != "")
            {
                try
                {
                    Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmBASViewAttributeHistory");
                    if (f != null)
                    {
                        f.BringToFront();
                        f.Show();
                        ((frmBASViewAttributeHistory)f).ShowHistory(this.sAttrType, this.sAttrKey);
                    }
                    else
                    {
                        f = new frmBASViewAttributeHistory();
                        f.MdiParent = MPGV.gfrmMDI;
                        f.BringToFront();
                        f.Show();
                        ((frmBASViewAttributeHistory)f).ShowHistory(this.sAttrType, this.sAttrKey);
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (spdAttrValue.ActiveSheet == null)
                return;
            if (spdAttrValue.ActiveSheet.ActiveRow == null)
                return;

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[spdAttrValue.ActiveSheet.ActiveRowIndex, (int)ATTR_COL.OLD_VALUE].Tag) == "Y")
            {
                frmBASAttributeDetail f = new frmBASAttributeDetail();
                f.AttributeKey = sAttrKey;
                f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[spdAttrValue.ActiveSheet.ActiveRowIndex, (int)ATTR_COL.ATTR_NAME].Value);
                f.AttributeType = sAttrType;
                f.ShowDialog(this);
            }
        }

        private void grpAttributeStatus_Resize(object sender, EventArgs e)
        {
            int i_gap;
            i_gap = grpAttributeStatus.Width - 500;
            if ((80 + i_gap) > 0)
            {
                /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
                //spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.OLD_VALUE].Width = 80 + i_gap;
                if (this.m_layout == udcAttributeStatusLayout.VIEW_AND_UPDATE)
                    MPCF.FitColumnHeader(spdAttrValue, (int)ATTR_COL.OLD_VALUE, (int)ATTR_COL.NEW_VALUE);
                else
                    spdAttrValue.ActiveSheet.Columns[(int)ATTR_COL.OLD_VALUE].Width = 80 + i_gap;
                /*** End of Modification (2012.04.13) ***/
            }
        }

        private void spdAttrValue_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            btnDetail.PerformClick();
        }

        /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateAttributeValue() == false) return;

            View();
        }

        private void spdAttrValue_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == (int)ATTR_COL.NEW_VALUE)
            {
                spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                AddArrayTypeRow(e.Row, true);
                SetButtonEnable(svData.ActiveRowIndex);
            }
        }

        private void spdAttrValue_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (e.Column == (int)ATTR_COL.NEW_VALUE)
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 4].Tag) == "Y")
                {
                    frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                    f.AttributeKey = this.AttributeKey;
                    f.AttributeType = this.AttributeType;
                    f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
                    f.AttributeDesc = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 2].Value);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = f.AttributeValue;
                        spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                        spdAttrValue.ActiveSheet.Rows[e.Row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(e.Row);
                    }

                    if (f.IsDisposed == false) f.Dispose();
                }
            }

            if (m_layout == udcAttributeStatusLayout.VIEW_AND_UPDATE)
            {
                SetButtonEnable(e.Row);
            }
        }

        private void spdAttrValue_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            bool b_set_null = false;

            try
            {
                if (e.Column == (int)ATTR_COL.NULL)
                {
                    if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NULL].Value) == true)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].CellType is FarPoint.Win.Spread.CellType.NumberCellType == false)
                        {
                            b_set_null = true;
                        }
                    }

                    /*Array Type Row*/
                    if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.ARRAY_TYPE_FLAG].Value) == "Y")
                    {
                        SetArrayTypeRow(e.Row, true, true, b_set_null);
                    }
                    else
                    {
                        int i = e.Row;
                        spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value = true;
                        if (b_set_null)
                        {
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value = "[Null]";
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Locked = true;
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE_BTN].Locked = true;
                        }
                        else
                        {
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value = "";
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Locked = false;
                            spdAttrValue.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE_BTN].Locked = false;
                        }
                    }

                    return;
                }

                cdvTableData.Init();
                cdvTableData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableData.GetListView);
                cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, e.Column].Tag));

                if (MPCF.ToChar(spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.OLD_VALUE].Tag) == 'Y')
                    cdvTableData.InsertEmptyRow(0, 1);

                if (cdvTableData.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTableData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Value = MPCF.Trim(e.SelectedItem.Text);
            spdAttrValue.ActiveSheet.Cells[e.Row, (int)ATTR_COL.CHECK].Value = true;
            AddArrayTypeRow(e.Row, true);
            SetButtonEnable(svData.ActiveRowIndex);
        }
        /*** End of Add (2012.04.13) ***/

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                int i_row = svData.ActiveRowIndex;

                svData.Rows[i_row].Remove();

                SetArrayTypeRow(i_row, true);

                SetButtonEnable(svData.ActiveRowIndex);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }         

    }
}
