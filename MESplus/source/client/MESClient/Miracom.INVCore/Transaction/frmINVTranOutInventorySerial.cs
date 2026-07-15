
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
//   File Name   : frmINVTranOutInventory.vb
//   Description : Inventory Out Inventory Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - Out_Store() : Inventory In Store transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-12 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _INV = True Then

namespace Miracom.INVCore
{
    public class frmINVTranOutInventorySerial : Miracom.MESCore.TranForm09
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVTranOutInventorySerial()
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
        



        private System.Windows.Forms.GroupBox grpTransInfo;
        protected System.Windows.Forms.Label lblOutUnit1;
        protected System.Windows.Forms.TextBox txtOutQty1;
        protected System.Windows.Forms.Label lblOutQty1;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Picture picture1 = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpTransInfo = new System.Windows.Forms.GroupBox();
            this.lblOutUnit1 = new System.Windows.Forms.Label();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInventoryInfo.SuspendLayout();
            this.grpInventoryInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).BeginInit();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTransInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvMatID
            // 
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTransInfo);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlInventoryInfo, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.grpTransInfo, 0);
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvMatVersion
            // 
            this.cdvMatVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Out Qty";
            // 
            // grpTransInfo
            // 
            this.grpTransInfo.Controls.Add(this.lblOutUnit1);
            this.grpTransInfo.Controls.Add(this.txtOutQty1);
            this.grpTransInfo.Controls.Add(this.lblOutQty1);
            this.grpTransInfo.Controls.Add(this.spdData);
            this.grpTransInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTransInfo.Location = new System.Drawing.Point(3, 96);
            this.grpTransInfo.Name = "grpTransInfo";
            this.grpTransInfo.Size = new System.Drawing.Size(722, 279);
            this.grpTransInfo.TabIndex = 1;
            this.grpTransInfo.TabStop = false;
            // 
            // lblOutUnit1
            // 
            this.lblOutUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutUnit1.Location = new System.Drawing.Point(226, 19);
            this.lblOutUnit1.Name = "lblOutUnit1";
            this.lblOutUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblOutUnit1.TabIndex = 2;
            this.lblOutUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(120, 16);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(100, 20);
            this.txtOutQty1.TabIndex = 1;
            this.txtOutQty1.TabStop = false;
            this.txtOutQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutQty1.Location = new System.Drawing.Point(15, 19);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(100, 14);
            this.lblOutQty1.TabIndex = 0;
            this.lblOutQty1.Text = "Out Qty";
            this.lblOutQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.Location = new System.Drawing.Point(3, 36);
            this.spdData.Name = "spdData";
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(716, 240);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 6;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
            this.spdData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_EditChange);
            this.spdData.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdData_Change);
            this.spdData.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdData_EnterCell);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            this.spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdData_Sheet1.ColumnCount = 7;
            this.spdData_Sheet1.RowCount = 2;
            this.spdData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Serial Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Serial No.";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Material Unit";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Material Qty";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Material Type";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            picture1.AlignHorz = FarPoint.Win.HorizontalAlignment.Center;
            picture1.AlignVert = FarPoint.Win.VerticalAlignment.Center;
            picture1.TransparencyColor = System.Drawing.Color.Empty;
            picture1.TransparencyTolerance = 0;
            checkBoxCellType1.BackgroundImage = picture1;
            this.spdData_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 37F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Serial Seq";
            this.spdData_Sheet1.Columns.Get(2).Width = 65F;
            textCellType1.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(3).Label = "Serial No.";
            this.spdData_Sheet1.Columns.Get(3).Width = 229F;
            textCellType2.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(4).Label = "Material Unit";
            this.spdData_Sheet1.Columns.Get(4).Width = 117F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
            numberCellType1.MaximumValue = 9999999;
            numberCellType1.MinimumValue = 0;
            this.spdData_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.spdData_Sheet1.Columns.Get(5).Label = "Material Qty";
            this.spdData_Sheet1.Columns.Get(5).Width = 86F;
            textCellType3.MaxLength = 1;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(6).Label = "Material Type";
            this.spdData_Sheet1.Columns.Get(6).Width = 96F;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmINVTranOutInventorySerial
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmINVTranOutInventorySerial";
            this.Text = "Out Inventory";
            this.Activated += new System.EventHandler(this.frmINVTranOutInventorySerial_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).EndInit();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTransInfo.ResumeLayout(false);
            this.grpTransInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        string sCellValue;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, cdvMatID, cdvInvOper, null, null, null, false);
                        if (View_Inventory_Info_Serial('2', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text), cdvInvOper.Text) == false) // Modified by H.J. Noh
                        {
                            if (cdvMatID.Text == "")
                            {
                                cdvMatID.Focus();
                            }
                            else if (cdvInvOper.Text == "")
                            {
                                cdvInvOper.Focus();
                            }
                            
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

            switch (MPCF.Trim(FuncName))
            {
                case "OUT_Inventory":

                    if (MPCF.CheckValue(cdvMatID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInvOper, 1) == false)
                    {
                        return false;
                    }
                    if (txtOutQty1.ReadOnly == false)
                    {
                        if (txtOutQty1.Text == "" || txtOutQty1.Text == "0")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtOutQty1.Focus();
                            return false;
                        }
                        if (txtOutQty1.Text != "" && txtOutQty1.Text != "0")
                        {
                            if (MPCF.ToDbl(txtOutQty1.Text) > MPCF.ToDbl(txtQty1.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(169));
                                tabTran.SelectedTab = tbpGeneral;
                                txtOutQty1.Text = "0";
                                txtOutQty1.Focus();
                                return false;
                            }
                        }
                    }
                    
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        //
        // View_Inventory_Info_Serial()
        //       - Get Inventory Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inventory_Info_Serial(char c_step, string sMatID, int iMatVer, string sOper)
        {
            TRSNode in_node = new TRSNode("View_Inventory_Info_In");
            TRSNode out_node = new TRSNode("View_Inventory_Info_Out");
            int i;
            FarPoint.Win.Spread.SheetView sheetX;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("OPER", sOper);

                if (MPCR.CallService("INV", "INV_View_Inventory_Info_Serial", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                txtAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                txtLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));

                txtOutQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));


                MPCF.ClearList(spdData);
                sheetX = spdData.Sheets[0];
      
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    sheetX.RowCount++;
                    sheetX.Cells[i, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                    sheetX.Cells[i, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("SERIAL_SEQ"));
                    sheetX.Cells[i, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SERIAL_ID"));
                    sheetX.Cells[i, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT"));
                    sheetX.Cells[i, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetDouble("MAT_QTY"));
                    sheetX.Cells[i, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE"));
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        //
        // View_Material_Info()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Material_Info(string sMatID, int iMatVer)
        {
            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");
            
            in_node.ProcStep = '1';
            
            
            
            
            
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);


            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT1") != "")
            {
                txtOutQty1.ReadOnly = false;
                lblUnit1.Text = out_node.GetString("UNIT1");
                lblOutUnit1.Text = out_node.GetString("UNIT1");
            }
            else
            {
                txtOutQty1.ReadOnly = true;
                lblUnit1.Text = "";
                lblOutUnit1.Text = "";
            }
            
            return true;
            
        }
        
        //
        // Out_Inventory()
        //       - Inventory In Inventory
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Out_Inventory(char ProcStep)
        {            
            int i = 0;
            TRSNode in_node = new TRSNode("Out_Inventory_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode serial_list;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(txtLastHistSeq.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatVersion.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvInvOper.Text));
                in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(txtOutQty1.Text));

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));
            
                for (i = 0; i < spdData.Sheets[0].RowCount; i++)
                {
                    if (spdData.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdData.Sheets[0].GetValue(i, 0)) == true)
                    {
                        serial_list = in_node.AddNode("SERIAL_LIST");

                        serial_list.AddInt("HIST_SEQ", MPCF.ToInt(spdData.Sheets[0].GetValue(i, 1)));
                        serial_list.AddInt("SERIAL_SEQ",MPCF.ToInt(spdData.Sheets[0].GetValue(i, 2)));
                        serial_list.AddString("SERIAL_ID", MPCF.Trim(spdData.Sheets[0].GetValue(i, 3)));
                        serial_list.AddString("MAT_UNIT", MPCF.Trim(spdData.Sheets[0].GetValue(i, 4)));
                        serial_list.AddDouble("MAT_QTY", MPCF.ToDbl(spdData.Sheets[0].GetValue(i, 5)));
                        serial_list.AddChar("SERIAL_TYPE", MPCF.ToChar(spdData.Sheets[0].GetValue(i, 6)));
                    }
                }

                if (MPCR.CallService("INV", "INV_Out_Inventory_Serial", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        #endregion
        
        private void frmINVTranOutInventorySerial_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    SetCMFItem(MPGC.MP_CMF_TRN_OUT_INV);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvMatID.Text == "")
            {
                return;
            }
            if (View_Material_Info(cdvMatID.Text,MPCF.ToInt(cdvMatVersion.Text)) == false)
            {
                return;
            }
            if (cdvInvOper.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }
        
        private void cdvInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvInvOper.Text == "")
            {
                return;
            }
            if (cdvMatID.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("OUT_Inventory") == false) return;
                if (Out_Inventory('D') == false) return;

                ClearData('2');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            ClearData('2');
            
        }
        
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMatID.Init();
            MPCF.InitListView(cdvMatID.GetListView);
            cdvMatID.Columns.Add("Material", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMatID.SelectedSubItemIndex = 0;

            WIPLIST.ViewMaterialList(cdvMatID.GetListView, '1');
        }
        
        private void cdvInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInvOper.Init();
            MPCF.InitListView(cdvInvOper.GetListView);
            cdvInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvInvOper.GetListView, '6', "",0, "", "", null, "");
        }
        
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
            try
            {
                if (spdData.Sheets[0].Columns[1].Visible == false)
                {
                    return;
                }
                if (spdData.Sheets[0].RowCount == 0)
                {
                    spdData.Sheets[0].RowCount++;
                    return;
                }
                if (spdData.Sheets[0].ActiveRow == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdData_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            
            try
            {
                if (spdData.Sheets[0].Columns[1].Visible == false)
                {
                    return;
                }
                if (e.Row == spdData.Sheets[0].RowCount - 1)
                {
                    if (e.Column > 0)
                    {
                        if (MPCF.Trim(spdData.Sheets[0].Cells[e.Row, 1].Text) != "")
                        {
                            spdData.Sheets[0].RowCount++;
                            int i = 0;
                            for (i = 1; i <= 10; i++)
                            {
                                spdData.Sheets[0].Cells.Get(spdData.Sheets[0].RowCount - 1, i).BackColor = System.Drawing.Color.WhiteSmoke;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdData_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            string sValue;
            
            try
            {
                if (e.Column <= 0)
                {
                    return;
                }
                
                if (e.Column > 0 && e.Row >= 0)
                {
                    spdData.Sheets[0].SetValue(e.Row, 0, true);
                    spdData.Sheets[0].SetValue(e.Row, 3, 0);
                }

                sValue = MPCF.Trim(spdData.Sheets[0].GetValue(e.Row, e.Column));
                
                if (sValue == null)
                {
                    return;
                }
                
                //Add 1 Row
                if (spdData.Sheets[0].Columns[1].Visible == false)
                {
                    return;
                }
                
                if (e.Row == spdData.Sheets[0].RowCount - 1)
                {
                    if (e.Column > 0)
                    {
                        if (MPCF.Trim(spdData.Sheets[0].Cells[e.Row, 1].Text) != "")
                        {
                            spdData.Sheets[0].RowCount++;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            try
            {
                if (e.Column <= 0)
                {
                    return;
                }

                sCellValue = MPCF.Trim(spdData.Sheets[0].GetValue(e.Row, e.Column));
                
                if (sCellValue == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
    }
    //#End If
}
