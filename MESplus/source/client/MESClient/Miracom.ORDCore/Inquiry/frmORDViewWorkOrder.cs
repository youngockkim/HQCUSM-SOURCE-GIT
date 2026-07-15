
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
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDViewWorkOrder : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDViewWorkOrder()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvWorkShift;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblWorkShift;
        private System.Windows.Forms.Label lblWorkDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResid;
        private System.Windows.Forms.RadioButton rbnOper;
        private System.Windows.Forms.RadioButton rbnRes;
        private FarPoint.Win.Spread.FpSpread spdWorkOrder;
        private FarPoint.Win.Spread.SheetView spdWorkOrder_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvWorkShift = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkShift = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResid = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnOper = new System.Windows.Forms.RadioButton();
            this.rbnRes = new System.Windows.Forms.RadioButton();
            this.spdWorkOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdWorkOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).BeginInit();
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
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvWorkShift);
            this.grpOption.Controls.Add(this.dtpWorkDate);
            this.grpOption.Controls.Add(this.lblWorkShift);
            this.grpOption.Controls.Add(this.lblWorkDate);
            this.grpOption.Controls.Add(this.cdvOper);
            this.grpOption.Controls.Add(this.cdvResid);
            this.grpOption.Controls.Add(this.rbnOper);
            this.grpOption.Controls.Add(this.rbnRes);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdWorkOrder);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Work Order";
            // 
            // cdvWorkShift
            // 
            this.cdvWorkShift.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvWorkShift.BorderHotColor = System.Drawing.Color.Black;
            this.cdvWorkShift.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvWorkShift.BtnToolTipText = "";
            this.cdvWorkShift.DescText = "";
            this.cdvWorkShift.DisplaySubItemIndex = -1;
            this.cdvWorkShift.DisplayText = "";
            this.cdvWorkShift.Focusing = null;
            this.cdvWorkShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvWorkShift.Index = 0;
            this.cdvWorkShift.IsViewBtnImage = false;
            this.cdvWorkShift.Location = new System.Drawing.Point(522, 40);
            this.cdvWorkShift.MaxLength = 1;
            this.cdvWorkShift.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvWorkShift.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvWorkShift.Name = "cdvWorkShift";
            this.cdvWorkShift.ReadOnly = true;
            this.cdvWorkShift.SearchSubItemIndex = 0;
            this.cdvWorkShift.SelectedDescIndex = -1;
            this.cdvWorkShift.SelectedSubItemIndex = -1;
            this.cdvWorkShift.SelectionStart = 0;
            this.cdvWorkShift.Size = new System.Drawing.Size(200, 20);
            this.cdvWorkShift.SmallImageList = null;
            this.cdvWorkShift.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvWorkShift.TabIndex = 7;
            this.cdvWorkShift.TextBoxToolTipText = "";
            this.cdvWorkShift.TextBoxWidth = 200;
            this.cdvWorkShift.VisibleButton = true;
            this.cdvWorkShift.VisibleColumnHeader = false;
            this.cdvWorkShift.VisibleDescription = false;
            this.cdvWorkShift.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvWorkShift_SelectedItemChanged);
            this.cdvWorkShift.ButtonPress += new System.EventHandler(this.cdvWorkShift_ButtonPress);
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(522, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(96, 20);
            this.dtpWorkDate.TabIndex = 5;
            // 
            // lblWorkShift
            // 
            this.lblWorkShift.AutoSize = true;
            this.lblWorkShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkShift.Location = new System.Drawing.Point(404, 43);
            this.lblWorkShift.Name = "lblWorkShift";
            this.lblWorkShift.Size = new System.Drawing.Size(57, 13);
            this.lblWorkShift.TabIndex = 6;
            this.lblWorkShift.Text = "Work Shift";
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Location = new System.Drawing.Point(404, 19);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(59, 13);
            this.lblWorkDate.TabIndex = 4;
            this.lblWorkDate.Text = "Work Date";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(120, 40);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            // 
            // cdvResid
            // 
            this.cdvResid.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResid.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResid.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResid.BtnToolTipText = "";
            this.cdvResid.DescText = "";
            this.cdvResid.DisplaySubItemIndex = -1;
            this.cdvResid.DisplayText = "";
            this.cdvResid.Focusing = null;
            this.cdvResid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResid.Index = 0;
            this.cdvResid.IsViewBtnImage = false;
            this.cdvResid.Location = new System.Drawing.Point(120, 16);
            this.cdvResid.MaxLength = 20;
            this.cdvResid.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResid.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResid.Name = "cdvResid";
            this.cdvResid.ReadOnly = false;
            this.cdvResid.SearchSubItemIndex = 0;
            this.cdvResid.SelectedDescIndex = -1;
            this.cdvResid.SelectedSubItemIndex = -1;
            this.cdvResid.SelectionStart = 0;
            this.cdvResid.Size = new System.Drawing.Size(200, 20);
            this.cdvResid.SmallImageList = null;
            this.cdvResid.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResid.TabIndex = 1;
            this.cdvResid.TextBoxToolTipText = "";
            this.cdvResid.TextBoxWidth = 200;
            this.cdvResid.VisibleButton = true;
            this.cdvResid.VisibleColumnHeader = false;
            this.cdvResid.VisibleDescription = false;
            this.cdvResid.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResid_SelectedItemChanged);
            this.cdvResid.ButtonPress += new System.EventHandler(this.cdvResid_ButtonPress);
            // 
            // rbnOper
            // 
            this.rbnOper.AutoSize = true;
            this.rbnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnOper.Location = new System.Drawing.Point(15, 40);
            this.rbnOper.Name = "rbnOper";
            this.rbnOper.Size = new System.Drawing.Size(54, 18);
            this.rbnOper.TabIndex = 2;
            this.rbnOper.Text = "Oper";
            this.rbnOper.CheckedChanged += new System.EventHandler(this.rbnResOper_CheckedChanged);
            // 
            // rbnRes
            // 
            this.rbnRes.AutoSize = true;
            this.rbnRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnRes.Location = new System.Drawing.Point(15, 16);
            this.rbnRes.Name = "rbnRes";
            this.rbnRes.Size = new System.Drawing.Size(77, 18);
            this.rbnRes.TabIndex = 0;
            this.rbnRes.Text = "Resource";
            this.rbnRes.CheckedChanged += new System.EventHandler(this.rbnResOper_CheckedChanged);
            // 
            // spdWorkOrder
            // 
            this.spdWorkOrder.AccessibleDescription = "";
            this.spdWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdWorkOrder.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdWorkOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.HorizontalScrollBar.Name = "";
            this.spdWorkOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdWorkOrder.HorizontalScrollBar.TabIndex = 2;
            this.spdWorkOrder.Location = new System.Drawing.Point(0, 3);
            this.spdWorkOrder.Name = "spdWorkOrder";
            this.spdWorkOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdWorkOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdWorkOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdWorkOrder_Sheet1});
            this.spdWorkOrder.Size = new System.Drawing.Size(742, 439);
            this.spdWorkOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdWorkOrder.TabIndex = 2;
            this.spdWorkOrder.TabStop = false;
            this.spdWorkOrder.TextTipDelay = 200;
            this.spdWorkOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdWorkOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.VerticalScrollBar.Name = "";
            this.spdWorkOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdWorkOrder.VerticalScrollBar.TabIndex = 3;
            // 
            // spdWorkOrder_Sheet1
            // 
            this.spdWorkOrder_Sheet1.Reset();
            spdWorkOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdWorkOrder_Sheet1.ColumnCount = 5;
            spdWorkOrder_Sheet1.RowCount = 5;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Shift";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Type";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Order Item";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Comment";
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Label = "Shift";
            this.spdWorkOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Width = 61F;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Label = "Type";
            this.spdWorkOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Width = 61F;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Label = "Work Order Item";
            this.spdWorkOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Width = 128F;
            this.spdWorkOrder_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdWorkOrder_Sheet1.Columns.Get(3).Label = "Qty";
            this.spdWorkOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Label = "Comment";
            this.spdWorkOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Width = 390F;
            this.spdWorkOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdWorkOrder_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdWorkOrder_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdWorkOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdWorkOrder_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmORDViewWorkOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDViewWorkOrder";
            this.Text = "View Work Order";
            this.Activated += new System.EventHandler(this.frmORDViewWorkOrder_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private bool b_load_flag = false;
        
        // ViewWorkOrderList()
        //       - ViewWorkOrderList
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool ViewWorkOrderList(Control control, char c_step)
        {
            TRSNode in_node = new TRSNode("View_PlannedLot_List_Detail_In");
            TRSNode out_node = new TRSNode("View_PlannedLot_List_Detail_Out");
            TRSNode work_order_list;

            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iLastRow;
            
            MPCF.ClearList(control, true);
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (rbnRes.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'R');
                }
                else if (rbnOper.Checked == true)
                {
                    in_node.AddChar("RES_OR_OPR_FLAG", 'O');
                }

                in_node.AddString("RES_ID", cdvResid.Text);
                in_node.AddString("OPER", cdvOper.Text);
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddChar("NEXT_WORK_SHIFT", ' ');
                
                if (cdvWorkShift.Text == "ALL" || cdvWorkShift.Text == "")
                {
                    in_node.AddChar("WORK_SHIFT", 'A');
                }
                else
                {
                    in_node.AddChar("WORK_SHIFT", MPCF.ToChar(cdvWorkShift.Text));
                }
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                do
                {
                    if (MPCR.CallService("ORD", "ORD_View_WorkOrder_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        
                        if (control is FarPoint.Win.Spread.FpSpread)
                        {
                            work_order_list = out_node.GetList(0)[i];

                            sheetX = ((FarPoint.Win.Spread.FpSpread) control).Sheets[0];
                            iLastRow = sheetX.RowCount;
                            sheetX.RowCount++;
                            sheetX.RowHeader.Rows[iLastRow].Label = MPCF.Trim(work_order_list.GetInt("SEQ_NUM"));
                            sheetX.SetValue(iLastRow, 0, MPCF.Trim(work_order_list.GetChar("WORK_SHIFT")));
                            if (work_order_list.GetChar("ORD_MAT_LOT_FLAG") == 'O')
                            {
                                sheetX.SetValue(iLastRow, 1, "ORDER");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(work_order_list.GetString("ORDER_ID")));
                            }
                            else if (work_order_list.GetChar("ORD_MAT_LOT_FLAG") == 'M')
                            {
                                sheetX.SetValue(iLastRow, 1, "MATERIAL");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(work_order_list.GetString("MAT_ID")));
                            }
                            else if (work_order_list.GetChar("ORD_MAT_LOT_FLAG") == 'L')
                            {
                                sheetX.SetValue(iLastRow, 1, "LOT");
                                sheetX.SetValue(iLastRow, 2, MPCF.Trim(work_order_list.GetString("LOT_ID")));
                            }
                            sheetX.SetValue(iLastRow, 3, MPCF.Trim(work_order_list.GetDouble("QTY")));
                            sheetX.SetValue(iLastRow, 4, MPCF.Trim(work_order_list.GetString("WORK_COMMENT")));
                        }
                    }
                    in_node.SetChar("NEXT_WORK_SHIFT", out_node.GetChar("NEXT_WORK_SHIFT"));
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                } while (in_node.GetChar("NEXT_WORK_SHIFT") != ' ' || in_node.GetInt("NEXT_SEQ_NUM") > 0);
                
                MPCF.FitColumnHeader((FarPoint.Win.Spread.FpSpread) control);
                
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
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                
            case "VIEW":
                
                if (rbnRes.Checked == true)
                {
                    if (MPCF.CheckValue(cdvResid, 1) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (MPCF.CheckValue(cdvOper, 1) == false)
                    {
                        return false;
                    }
                }
                break;
                
        }
        
        return true;
        
    }
    
    public virtual Control GetFisrtFocusItem()
    {
        
        try
        {
            if (this.cdvResid.Enabled == true)
            {
                return this.cdvResid;
            }
            else
            {
                return this.cdvOper;
            }
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return null;
        }
        
    }
    
    private void frmORDViewWorkOrder_Activated(object sender, System.EventArgs e)
    {
        if (b_load_flag == false)
        {
            MPCF.FitColumnHeader(this.spdWorkOrder);
            dtpWorkDate.Value = DateTime.Now;
            rbnRes.Checked = true;
            b_load_flag = true;
        }
    }
    
    private void btnView_Click(System.Object sender, System.EventArgs e)
    {
        if (CheckCondition("VIEW") == true)
        {
            ViewWorkOrderList(spdWorkOrder, '1');
        }
    }
    
    private void rbnResOper_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        MPCF.ClearList(spdWorkOrder, true);
        if (rbnRes.Checked == true)
        {
            cdvResid.Enabled = true;
            cdvResid.BackColor = SystemColors.Window;
            cdvOper.Enabled = false;
            cdvOper.BackColor = SystemColors.Control;
            cdvOper.Text = "";
        }
        else if (rbnOper.Checked == true)
        {
            cdvResid.Enabled = false;
            cdvResid.BackColor = SystemColors.Control;
            cdvOper.Enabled = true;
            cdvOper.BackColor = SystemColors.Window;
            cdvResid.Text = "";
        }
    }
    
    private void cdvWorkShift_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdWorkOrder, true);
    }
    
    private void cdvResid_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdWorkOrder, true);
    }
    
    private void cdvOper_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdWorkOrder, true);
    }
    
    private void btnExcel_Click(System.Object sender, System.EventArgs e)
    {
        string sCond;

        sCond = "Work Date : " + MPCF.MakeDateFormat(MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), DATE_TIME_FORMAT.DATE); 
        if (rbnRes.Checked == true)
        {
            sCond = sCond + "\r" + "Resource : " + cdvResid.Text;
        }
        else
        {
            sCond = sCond + "\r" + "Operation : " + cdvOper.Text;
        }
        if (cdvWorkShift.Text != "")
        {
            sCond = sCond + "\r" + "Work Shift : " + cdvWorkShift.Text;
        }
        
        MPCF.ExportToExcel(spdWorkOrder, this.Text, sCond);
        
    }
    
    private void cdvOper_ButtonPress(object sender, System.EventArgs e)
    {
        cdvOper.Init();
        MPCF.InitListView(cdvOper.GetListView);
        cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
        cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvOper.SelectedSubItemIndex = 0;
        
        WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0,"", "", null, "");
    }
    
    private void cdvResid_ButtonPress(object sender, System.EventArgs e)
    {
        cdvResid.Init();
        MPCF.InitListView(cdvResid.GetListView);
        cdvResid.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvResid.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvResid.SelectedSubItemIndex = 0;
        #if _RAS
        RASLIST.ViewResourceList(cdvResid.GetListView, false);
        #endif
    }
    
    private void cdvWorkShift_ButtonPress(object sender, System.EventArgs e)
    {
        ListViewItem itmX;
        cdvWorkShift.Init();
        MPCF.InitListView(cdvWorkShift.GetListView);
        cdvWorkShift.Columns.Add("Shift", 50, HorizontalAlignment.Left);
        cdvWorkShift.Columns.Add("Start", 100, HorizontalAlignment.Left);
        cdvWorkShift.SelectedSubItemIndex = 0;
        
        cdvWorkShift.AddEmptyRow(1);
        itmX = new ListViewItem("ALL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
        itmX.SubItems.Add("ALL SHIFT");
        cdvWorkShift.Items.Add(itmX);
        WIPLIST.ViewFactoryShiftList(cdvWorkShift.GetListView, '1');
    }
}
//#End If
}
