
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
//#If _CRR = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASTranCarrierLot.vb
//   Description : Attach Lot to Carrier Form
//
//   MES Version : 4.1.0.0
//
//   Function List

//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Carrier_Lot() : Create/Update/Delete Carrier - Lot Relation
//       - SelectClear()           : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-01 : Created by GI Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASTranAttachCarrierToLot : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranAttachCarrierToLot()
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
        



        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Label lblLotDesc;
        private System.Windows.Forms.TextBox txtLotDesc;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.TextBox txtLotQty3;
        private System.Windows.Forms.TextBox txtLotQty2;
        private System.Windows.Forms.TextBox txtLotQty1;
        private System.Windows.Forms.Label lblLotQty;
        private System.Windows.Forms.TextBox txtNonAttachedQty3;
        private System.Windows.Forms.TextBox txtNonAttachedQty2;
        private System.Windows.Forms.TextBox txtNonAttachedQty1;
        private System.Windows.Forms.Label lblNonAttachedQty;
        private System.Windows.Forms.TextBox txtAttachedQty3;
        private System.Windows.Forms.TextBox txtAttachedQty2;
        private System.Windows.Forms.TextBox txtAttachedQty1;
        private System.Windows.Forms.Label lblAttachedQty;
        private System.Windows.Forms.GroupBox grpCrrInfo;
        private System.Windows.Forms.TextBox txtAttachQty3;
        private System.Windows.Forms.TextBox txtAttachQty2;
        private System.Windows.Forms.TextBox txtAttachQty1;
        private System.Windows.Forms.Label lblAttachQty;
        private System.Windows.Forms.Label lblCrrDesc;
        private System.Windows.Forms.TextBox txtCrrDesc;
        private System.Windows.Forms.Label lblCrrID;
        private System.Windows.Forms.TextBox txtCrrQty3;
        private System.Windows.Forms.TextBox txtCrrQty2;
        private System.Windows.Forms.TextBox txtCrrQty1;
        private System.Windows.Forms.Label lblCrrQty1;
        private System.Windows.Forms.Label lblCrrSize;
        private System.Windows.Forms.TextBox txtCrrSize;
        private System.Windows.Forms.GroupBox grpAttachedCrrList;
        private System.Windows.Forms.ColumnHeader colCrrID;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colQty3;
        private Miracom.UI.Controls.MCListView.MCListView lisCrrList;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.ColumnHeader colAQty1;
        private System.Windows.Forms.ColumnHeader colAQty2;
        private System.Windows.Forms.ColumnHeader colAQty3;
        private System.Windows.Forms.TextBox txtCrrAttachedQty3;
        private System.Windows.Forms.TextBox txtCrrAttachedQty2;
        private System.Windows.Forms.TextBox txtCrrAttachedQty1;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType;
        private Label lblCrrType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private Label lblCrrGroup;
        private System.Windows.Forms.Label lblCrrAttachedQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.txtLotQty3 = new System.Windows.Forms.TextBox();
            this.txtLotQty2 = new System.Windows.Forms.TextBox();
            this.txtLotQty1 = new System.Windows.Forms.TextBox();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.txtNonAttachedQty3 = new System.Windows.Forms.TextBox();
            this.txtNonAttachedQty2 = new System.Windows.Forms.TextBox();
            this.txtNonAttachedQty1 = new System.Windows.Forms.TextBox();
            this.lblNonAttachedQty = new System.Windows.Forms.Label();
            this.txtAttachedQty3 = new System.Windows.Forms.TextBox();
            this.txtAttachedQty2 = new System.Windows.Forms.TextBox();
            this.txtAttachedQty1 = new System.Windows.Forms.TextBox();
            this.lblAttachedQty = new System.Windows.Forms.Label();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.grpCrrInfo = new System.Windows.Forms.GroupBox();
            this.cdvCrrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType = new System.Windows.Forms.Label();
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrGroup = new System.Windows.Forms.Label();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtCrrQty3 = new System.Windows.Forms.TextBox();
            this.txtCrrQty2 = new System.Windows.Forms.TextBox();
            this.txtCrrQty1 = new System.Windows.Forms.TextBox();
            this.lblCrrQty1 = new System.Windows.Forms.Label();
            this.lblCrrSize = new System.Windows.Forms.Label();
            this.txtCrrSize = new System.Windows.Forms.TextBox();
            this.txtAttachQty3 = new System.Windows.Forms.TextBox();
            this.txtAttachQty2 = new System.Windows.Forms.TextBox();
            this.txtAttachQty1 = new System.Windows.Forms.TextBox();
            this.lblAttachQty = new System.Windows.Forms.Label();
            this.txtCrrAttachedQty3 = new System.Windows.Forms.TextBox();
            this.txtCrrAttachedQty2 = new System.Windows.Forms.TextBox();
            this.txtCrrAttachedQty1 = new System.Windows.Forms.TextBox();
            this.lblCrrAttachedQty1 = new System.Windows.Forms.Label();
            this.lblCrrDesc = new System.Windows.Forms.Label();
            this.txtCrrDesc = new System.Windows.Forms.TextBox();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.grpAttachedCrrList = new System.Windows.Forms.GroupBox();
            this.lisCrrList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCrrID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.grpLot.SuspendLayout();
            this.grpCrrInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.grpAttachedCrrList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpAttachedCrrList);
            this.pnlRight.Controls.Add(this.grpCrrInfo);
            this.pnlRight.Controls.Add(this.grpLot);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisLotList);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Detach";
            this.btnDelete.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Attach";
            this.btnUpdate.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Attach Carrier To Lot";
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.cdvMatID);
            this.pnlType.Controls.Add(this.cdvOper);
            this.pnlType.Controls.Add(this.cdvFlow);
            this.pnlType.Controls.Add(this.lblOperation);
            this.pnlType.Controls.Add(this.lblFlow);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(0, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(232, 86);
            this.pnlType.TabIndex = 0;
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(12, 7);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(206, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 75;
            this.cdvMatID.WidthMaterialAndVersion = 131;
            this.cdvMatID.WidthVersion = 50;
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
            this.cdvOper.Location = new System.Drawing.Point(87, 56);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(131, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 4;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 131;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(87, 32);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(131, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 2;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 131;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 58);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 3;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(12, 34);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 1;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotID,
            this.colDesc});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(0, 86);
            this.lisLotList.MultiSelect = false;
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(232, 420);
            this.lisLotList.TabIndex = 1;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.SelectedIndexChanged += new System.EventHandler(this.lisLotList_SelectedIndexChanged);
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 150;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.txtLotQty3);
            this.grpLot.Controls.Add(this.txtLotQty2);
            this.grpLot.Controls.Add(this.txtLotQty1);
            this.grpLot.Controls.Add(this.lblLotQty);
            this.grpLot.Controls.Add(this.txtNonAttachedQty3);
            this.grpLot.Controls.Add(this.txtNonAttachedQty2);
            this.grpLot.Controls.Add(this.txtNonAttachedQty1);
            this.grpLot.Controls.Add(this.lblNonAttachedQty);
            this.grpLot.Controls.Add(this.txtAttachedQty3);
            this.grpLot.Controls.Add(this.txtAttachedQty2);
            this.grpLot.Controls.Add(this.txtAttachedQty1);
            this.grpLot.Controls.Add(this.lblAttachedQty);
            this.grpLot.Controls.Add(this.lblLotDesc);
            this.grpLot.Controls.Add(this.txtLotDesc);
            this.grpLot.Controls.Add(this.lblLotID);
            this.grpLot.Controls.Add(this.txtLotID);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.Location = new System.Drawing.Point(0, 0);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(506, 120);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            // 
            // txtLotQty3
            // 
            this.txtLotQty3.Location = new System.Drawing.Point(402, 41);
            this.txtLotQty3.MaxLength = 11;
            this.txtLotQty3.Name = "txtLotQty3";
            this.txtLotQty3.ReadOnly = true;
            this.txtLotQty3.Size = new System.Drawing.Size(96, 20);
            this.txtLotQty3.TabIndex = 7;
            // 
            // txtLotQty2
            // 
            this.txtLotQty2.Location = new System.Drawing.Point(298, 41);
            this.txtLotQty2.MaxLength = 11;
            this.txtLotQty2.Name = "txtLotQty2";
            this.txtLotQty2.ReadOnly = true;
            this.txtLotQty2.Size = new System.Drawing.Size(96, 20);
            this.txtLotQty2.TabIndex = 6;
            // 
            // txtLotQty1
            // 
            this.txtLotQty1.Location = new System.Drawing.Point(194, 41);
            this.txtLotQty1.MaxLength = 11;
            this.txtLotQty1.Name = "txtLotQty1";
            this.txtLotQty1.ReadOnly = true;
            this.txtLotQty1.Size = new System.Drawing.Size(96, 20);
            this.txtLotQty1.TabIndex = 5;
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotQty.Location = new System.Drawing.Point(10, 44);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(72, 13);
            this.lblLotQty.TabIndex = 4;
            this.lblLotQty.Text = "Lot Qty 1/2/3";
            // 
            // txtNonAttachedQty3
            // 
            this.txtNonAttachedQty3.Location = new System.Drawing.Point(402, 91);
            this.txtNonAttachedQty3.MaxLength = 11;
            this.txtNonAttachedQty3.Name = "txtNonAttachedQty3";
            this.txtNonAttachedQty3.ReadOnly = true;
            this.txtNonAttachedQty3.Size = new System.Drawing.Size(96, 20);
            this.txtNonAttachedQty3.TabIndex = 15;
            // 
            // txtNonAttachedQty2
            // 
            this.txtNonAttachedQty2.Location = new System.Drawing.Point(298, 91);
            this.txtNonAttachedQty2.MaxLength = 11;
            this.txtNonAttachedQty2.Name = "txtNonAttachedQty2";
            this.txtNonAttachedQty2.ReadOnly = true;
            this.txtNonAttachedQty2.Size = new System.Drawing.Size(96, 20);
            this.txtNonAttachedQty2.TabIndex = 14;
            // 
            // txtNonAttachedQty1
            // 
            this.txtNonAttachedQty1.Location = new System.Drawing.Point(194, 91);
            this.txtNonAttachedQty1.MaxLength = 11;
            this.txtNonAttachedQty1.Name = "txtNonAttachedQty1";
            this.txtNonAttachedQty1.ReadOnly = true;
            this.txtNonAttachedQty1.Size = new System.Drawing.Size(96, 20);
            this.txtNonAttachedQty1.TabIndex = 13;
            // 
            // lblNonAttachedQty
            // 
            this.lblNonAttachedQty.AutoSize = true;
            this.lblNonAttachedQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNonAttachedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonAttachedQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNonAttachedQty.Location = new System.Drawing.Point(10, 94);
            this.lblNonAttachedQty.Name = "lblNonAttachedQty";
            this.lblNonAttachedQty.Size = new System.Drawing.Size(123, 13);
            this.lblNonAttachedQty.TabIndex = 12;
            this.lblNonAttachedQty.Text = "Non-Attached Qty 1/2/3";
            // 
            // txtAttachedQty3
            // 
            this.txtAttachedQty3.Location = new System.Drawing.Point(402, 66);
            this.txtAttachedQty3.MaxLength = 11;
            this.txtAttachedQty3.Name = "txtAttachedQty3";
            this.txtAttachedQty3.ReadOnly = true;
            this.txtAttachedQty3.Size = new System.Drawing.Size(96, 20);
            this.txtAttachedQty3.TabIndex = 11;
            // 
            // txtAttachedQty2
            // 
            this.txtAttachedQty2.Location = new System.Drawing.Point(298, 66);
            this.txtAttachedQty2.MaxLength = 11;
            this.txtAttachedQty2.Name = "txtAttachedQty2";
            this.txtAttachedQty2.ReadOnly = true;
            this.txtAttachedQty2.Size = new System.Drawing.Size(96, 20);
            this.txtAttachedQty2.TabIndex = 10;
            // 
            // txtAttachedQty1
            // 
            this.txtAttachedQty1.Location = new System.Drawing.Point(194, 66);
            this.txtAttachedQty1.MaxLength = 11;
            this.txtAttachedQty1.Name = "txtAttachedQty1";
            this.txtAttachedQty1.ReadOnly = true;
            this.txtAttachedQty1.Size = new System.Drawing.Size(96, 20);
            this.txtAttachedQty1.TabIndex = 9;
            // 
            // lblAttachedQty
            // 
            this.lblAttachedQty.AutoSize = true;
            this.lblAttachedQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachedQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachedQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttachedQty.Location = new System.Drawing.Point(10, 69);
            this.lblAttachedQty.Name = "lblAttachedQty";
            this.lblAttachedQty.Size = new System.Drawing.Size(100, 13);
            this.lblAttachedQty.TabIndex = 8;
            this.lblAttachedQty.Text = "Attached Qty 1/2/3";
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotDesc.Location = new System.Drawing.Point(194, 19);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 2;
            this.lblLotDesc.Text = "Description";
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotDesc.Location = new System.Drawing.Point(298, 16);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(200, 20);
            this.txtLotDesc.TabIndex = 3;
            this.txtLotDesc.TabStop = false;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotID.Location = new System.Drawing.Point(10, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.Location = new System.Drawing.Point(84, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(96, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.TabStop = false;
            // 
            // grpCrrInfo
            // 
            this.grpCrrInfo.Controls.Add(this.cdvCrrType);
            this.grpCrrInfo.Controls.Add(this.lblCrrType);
            this.grpCrrInfo.Controls.Add(this.cdvCrrGroup);
            this.grpCrrInfo.Controls.Add(this.lblCrrGroup);
            this.grpCrrInfo.Controls.Add(this.cdvCrrID);
            this.grpCrrInfo.Controls.Add(this.txtCrrQty3);
            this.grpCrrInfo.Controls.Add(this.txtCrrQty2);
            this.grpCrrInfo.Controls.Add(this.txtCrrQty1);
            this.grpCrrInfo.Controls.Add(this.lblCrrQty1);
            this.grpCrrInfo.Controls.Add(this.lblCrrSize);
            this.grpCrrInfo.Controls.Add(this.txtCrrSize);
            this.grpCrrInfo.Controls.Add(this.txtAttachQty3);
            this.grpCrrInfo.Controls.Add(this.txtAttachQty2);
            this.grpCrrInfo.Controls.Add(this.txtAttachQty1);
            this.grpCrrInfo.Controls.Add(this.lblAttachQty);
            this.grpCrrInfo.Controls.Add(this.txtCrrAttachedQty3);
            this.grpCrrInfo.Controls.Add(this.txtCrrAttachedQty2);
            this.grpCrrInfo.Controls.Add(this.txtCrrAttachedQty1);
            this.grpCrrInfo.Controls.Add(this.lblCrrAttachedQty1);
            this.grpCrrInfo.Controls.Add(this.lblCrrDesc);
            this.grpCrrInfo.Controls.Add(this.txtCrrDesc);
            this.grpCrrInfo.Controls.Add(this.lblCrrID);
            this.grpCrrInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCrrInfo.Location = new System.Drawing.Point(0, 338);
            this.grpCrrInfo.Name = "grpCrrInfo";
            this.grpCrrInfo.Size = new System.Drawing.Size(506, 168);
            this.grpCrrInfo.TabIndex = 2;
            this.grpCrrInfo.TabStop = false;
            this.grpCrrInfo.Text = "Carrier Information";
            // 
            // cdvCrrType
            // 
            this.cdvCrrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType.BtnToolTipText = "";
            this.cdvCrrType.DescText = "";
            this.cdvCrrType.DisplaySubItemIndex = -1;
            this.cdvCrrType.DisplayText = "";
            this.cdvCrrType.Focusing = null;
            this.cdvCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType.Index = 0;
            this.cdvCrrType.IsViewBtnImage = false;
            this.cdvCrrType.Location = new System.Drawing.Point(356, 15);
            this.cdvCrrType.MaxLength = 20;
            this.cdvCrrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.Name = "cdvCrrType";
            this.cdvCrrType.ReadOnly = true;
            this.cdvCrrType.SearchSubItemIndex = 0;
            this.cdvCrrType.SelectedDescIndex = -1;
            this.cdvCrrType.SelectedSubItemIndex = -1;
            this.cdvCrrType.SelectionStart = 0;
            this.cdvCrrType.Size = new System.Drawing.Size(142, 20);
            this.cdvCrrType.SmallImageList = null;
            this.cdvCrrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType.TabIndex = 3;
            this.cdvCrrType.TextBoxToolTipText = "";
            this.cdvCrrType.TextBoxWidth = 142;
            this.cdvCrrType.VisibleButton = true;
            this.cdvCrrType.VisibleColumnHeader = false;
            this.cdvCrrType.VisibleDescription = false;
            this.cdvCrrType.ButtonPress += new System.EventHandler(this.cdvCrrType_ButtonPress);
            // 
            // lblCrrType
            // 
            this.lblCrrType.AutoSize = true;
            this.lblCrrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType.Location = new System.Drawing.Point(271, 18);
            this.lblCrrType.Name = "lblCrrType";
            this.lblCrrType.Size = new System.Drawing.Size(64, 13);
            this.lblCrrType.TabIndex = 2;
            this.lblCrrType.Text = "Carrier Type";
            // 
            // cdvCrrGroup
            // 
            this.cdvCrrGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrGroup.BtnToolTipText = "";
            this.cdvCrrGroup.DescText = "";
            this.cdvCrrGroup.DisplaySubItemIndex = -1;
            this.cdvCrrGroup.DisplayText = "";
            this.cdvCrrGroup.Focusing = null;
            this.cdvCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrGroup.Index = 0;
            this.cdvCrrGroup.IsViewBtnImage = false;
            this.cdvCrrGroup.Location = new System.Drawing.Point(118, 15);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = true;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(142, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 142;
            this.cdvCrrGroup.VisibleButton = true;
            this.cdvCrrGroup.VisibleColumnHeader = false;
            this.cdvCrrGroup.VisibleDescription = false;
            this.cdvCrrGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrGroup_SelectedItemChanged);
            this.cdvCrrGroup.ButtonPress += new System.EventHandler(this.cdvCrrGroup_ButtonPress);
            // 
            // lblCrrGroup
            // 
            this.lblCrrGroup.AutoSize = true;
            this.lblCrrGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrGroup.Location = new System.Drawing.Point(10, 18);
            this.lblCrrGroup.Name = "lblCrrGroup";
            this.lblCrrGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCrrGroup.TabIndex = 0;
            this.lblCrrGroup.Text = "Carrier Group";
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(118, 40);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(142, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 5;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 142;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.ButtonPress += new System.EventHandler(this.cdvCrrID_ButtonPress);
            this.cdvCrrID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrrID_KeyPress);
            this.cdvCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvCrrID_TextChanged);
            // 
            // txtCrrQty3
            // 
            this.txtCrrQty3.Location = new System.Drawing.Point(402, 90);
            this.txtCrrQty3.MaxLength = 13;
            this.txtCrrQty3.Name = "txtCrrQty3";
            this.txtCrrQty3.ReadOnly = true;
            this.txtCrrQty3.Size = new System.Drawing.Size(96, 20);
            this.txtCrrQty3.TabIndex = 13;
            // 
            // txtCrrQty2
            // 
            this.txtCrrQty2.Location = new System.Drawing.Point(298, 90);
            this.txtCrrQty2.MaxLength = 13;
            this.txtCrrQty2.Name = "txtCrrQty2";
            this.txtCrrQty2.ReadOnly = true;
            this.txtCrrQty2.Size = new System.Drawing.Size(96, 20);
            this.txtCrrQty2.TabIndex = 12;
            // 
            // txtCrrQty1
            // 
            this.txtCrrQty1.Location = new System.Drawing.Point(194, 90);
            this.txtCrrQty1.MaxLength = 13;
            this.txtCrrQty1.Name = "txtCrrQty1";
            this.txtCrrQty1.ReadOnly = true;
            this.txtCrrQty1.Size = new System.Drawing.Size(96, 20);
            this.txtCrrQty1.TabIndex = 11;
            // 
            // lblCrrQty1
            // 
            this.lblCrrQty1.AutoSize = true;
            this.lblCrrQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrQty1.Location = new System.Drawing.Point(10, 93);
            this.lblCrrQty1.Name = "lblCrrQty1";
            this.lblCrrQty1.Size = new System.Drawing.Size(87, 13);
            this.lblCrrQty1.TabIndex = 10;
            this.lblCrrQty1.Text = "Carrier Qty 1/2/3";
            // 
            // lblCrrSize
            // 
            this.lblCrrSize.AutoSize = true;
            this.lblCrrSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrSize.Location = new System.Drawing.Point(271, 43);
            this.lblCrrSize.Name = "lblCrrSize";
            this.lblCrrSize.Size = new System.Drawing.Size(60, 13);
            this.lblCrrSize.TabIndex = 6;
            this.lblCrrSize.Text = "Carrier Size";
            // 
            // txtCrrSize
            // 
            this.txtCrrSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrrSize.Location = new System.Drawing.Point(356, 40);
            this.txtCrrSize.MaxLength = 6;
            this.txtCrrSize.Name = "txtCrrSize";
            this.txtCrrSize.ReadOnly = true;
            this.txtCrrSize.Size = new System.Drawing.Size(142, 20);
            this.txtCrrSize.TabIndex = 7;
            this.txtCrrSize.TabStop = false;
            // 
            // txtAttachQty3
            // 
            this.txtAttachQty3.Location = new System.Drawing.Point(402, 140);
            this.txtAttachQty3.MaxLength = 13;
            this.txtAttachQty3.Name = "txtAttachQty3";
            this.txtAttachQty3.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty3.TabIndex = 21;
            // 
            // txtAttachQty2
            // 
            this.txtAttachQty2.Location = new System.Drawing.Point(298, 140);
            this.txtAttachQty2.MaxLength = 13;
            this.txtAttachQty2.Name = "txtAttachQty2";
            this.txtAttachQty2.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty2.TabIndex = 20;
            // 
            // txtAttachQty1
            // 
            this.txtAttachQty1.Location = new System.Drawing.Point(194, 140);
            this.txtAttachQty1.MaxLength = 13;
            this.txtAttachQty1.Name = "txtAttachQty1";
            this.txtAttachQty1.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty1.TabIndex = 19;
            // 
            // lblAttachQty
            // 
            this.lblAttachQty.AutoSize = true;
            this.lblAttachQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttachQty.Location = new System.Drawing.Point(10, 143);
            this.lblAttachQty.Name = "lblAttachQty";
            this.lblAttachQty.Size = new System.Drawing.Size(88, 13);
            this.lblAttachQty.TabIndex = 18;
            this.lblAttachQty.Text = "Attach Qty 1/2/3";
            // 
            // txtCrrAttachedQty3
            // 
            this.txtCrrAttachedQty3.Location = new System.Drawing.Point(402, 115);
            this.txtCrrAttachedQty3.MaxLength = 13;
            this.txtCrrAttachedQty3.Name = "txtCrrAttachedQty3";
            this.txtCrrAttachedQty3.ReadOnly = true;
            this.txtCrrAttachedQty3.Size = new System.Drawing.Size(96, 20);
            this.txtCrrAttachedQty3.TabIndex = 17;
            // 
            // txtCrrAttachedQty2
            // 
            this.txtCrrAttachedQty2.Location = new System.Drawing.Point(298, 115);
            this.txtCrrAttachedQty2.MaxLength = 13;
            this.txtCrrAttachedQty2.Name = "txtCrrAttachedQty2";
            this.txtCrrAttachedQty2.ReadOnly = true;
            this.txtCrrAttachedQty2.Size = new System.Drawing.Size(96, 20);
            this.txtCrrAttachedQty2.TabIndex = 16;
            // 
            // txtCrrAttachedQty1
            // 
            this.txtCrrAttachedQty1.Location = new System.Drawing.Point(194, 115);
            this.txtCrrAttachedQty1.MaxLength = 13;
            this.txtCrrAttachedQty1.Name = "txtCrrAttachedQty1";
            this.txtCrrAttachedQty1.ReadOnly = true;
            this.txtCrrAttachedQty1.Size = new System.Drawing.Size(96, 20);
            this.txtCrrAttachedQty1.TabIndex = 15;
            // 
            // lblCrrAttachedQty1
            // 
            this.lblCrrAttachedQty1.AutoSize = true;
            this.lblCrrAttachedQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrAttachedQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrAttachedQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrAttachedQty1.Location = new System.Drawing.Point(10, 118);
            this.lblCrrAttachedQty1.Name = "lblCrrAttachedQty1";
            this.lblCrrAttachedQty1.Size = new System.Drawing.Size(100, 13);
            this.lblCrrAttachedQty1.TabIndex = 14;
            this.lblCrrAttachedQty1.Text = "Attached Qty 1/2/3";
            // 
            // lblCrrDesc
            // 
            this.lblCrrDesc.AutoSize = true;
            this.lblCrrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrDesc.Location = new System.Drawing.Point(10, 68);
            this.lblCrrDesc.Name = "lblCrrDesc";
            this.lblCrrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCrrDesc.TabIndex = 8;
            this.lblCrrDesc.Text = "Description";
            // 
            // txtCrrDesc
            // 
            this.txtCrrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrrDesc.Location = new System.Drawing.Point(194, 65);
            this.txtCrrDesc.MaxLength = 200;
            this.txtCrrDesc.Name = "txtCrrDesc";
            this.txtCrrDesc.ReadOnly = true;
            this.txtCrrDesc.Size = new System.Drawing.Size(304, 20);
            this.txtCrrDesc.TabIndex = 9;
            this.txtCrrDesc.TabStop = false;
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrID.Location = new System.Drawing.Point(10, 43);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 4;
            this.lblCrrID.Text = "Carrier ID";
            // 
            // grpAttachedCrrList
            // 
            this.grpAttachedCrrList.Controls.Add(this.lisCrrList);
            this.grpAttachedCrrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttachedCrrList.Location = new System.Drawing.Point(0, 120);
            this.grpAttachedCrrList.Name = "grpAttachedCrrList";
            this.grpAttachedCrrList.Size = new System.Drawing.Size(506, 218);
            this.grpAttachedCrrList.TabIndex = 1;
            this.grpAttachedCrrList.TabStop = false;
            this.grpAttachedCrrList.Text = "Attached Carrier List";
            // 
            // lisCrrList
            // 
            this.lisCrrList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCrrID,
            this.colSize,
            this.colQty1,
            this.colAQty1,
            this.colQty2,
            this.colAQty2,
            this.colQty3,
            this.colAQty3});
            this.lisCrrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCrrList.EnableSort = true;
            this.lisCrrList.EnableSortIcon = true;
            this.lisCrrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCrrList.FullRowSelect = true;
            this.lisCrrList.Location = new System.Drawing.Point(3, 16);
            this.lisCrrList.Name = "lisCrrList";
            this.lisCrrList.Size = new System.Drawing.Size(500, 199);
            this.lisCrrList.TabIndex = 0;
            this.lisCrrList.UseCompatibleStateImageBehavior = false;
            this.lisCrrList.View = System.Windows.Forms.View.Details;
            this.lisCrrList.SelectedIndexChanged += new System.EventHandler(this.lisCrrList_SelectedIndexChanged);
            // 
            // colCrrID
            // 
            this.colCrrID.Text = "Carrier ID";
            this.colCrrID.Width = 100;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 55;
            // 
            // colQty1
            // 
            this.colQty1.Text = "Qty 1";
            this.colQty1.Width = 55;
            // 
            // colAQty1
            // 
            this.colAQty1.Text = "Att Qty 1";
            this.colAQty1.Width = 55;
            // 
            // colQty2
            // 
            this.colQty2.Text = "Qty 2";
            this.colQty2.Width = 55;
            // 
            // colAQty2
            // 
            this.colAQty2.Text = "Att Qty 2";
            this.colAQty2.Width = 55;
            // 
            // colQty3
            // 
            this.colQty3.Text = "Qty 3";
            this.colQty3.Width = 55;
            // 
            // colAQty3
            // 
            this.colAQty3.Text = "Att Qty 3";
            this.colAQty3.Width = 55;
            // 
            // frmRASTranAttachCarrierToLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranAttachCarrierToLot";
            this.Text = "Attach Carrier To Lot";
            this.Activated += new System.EventHandler(this.frmRASTranAttachCarrierToLot_Activated);
            this.Load += new System.EventHandler(this.frmRASTranAttachCarrierToLot_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            this.grpCrrInfo.ResumeLayout(false);
            this.grpCrrInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.grpAttachedCrrList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag;

        private struct st_selected_lot_info
        {
            public string mat_id;
            public int mat_ver;
            public string flow;
            public string oper;
            public string res_id;
            public string port_id;

            public void reset()
            {
                mat_id = "";
                mat_ver = 0;
                flow = "";
                oper = "";
                res_id = "";
                port_id = "";
            }
        }
        private st_selected_lot_info lot_info;
        
        #endregion
        
        #region " Function Definition "
        
        // ViewLotListMFO()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewLotListMFO(string sMaterial, int iMatVer, string sFlow, string sOper)
        {
            try
            {

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
                int i;
                ListViewItem itmX;

                MPCF.InitListView(lisLotList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
              
                in_node.AddString("MAT_ID", sMaterial);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisLotList.Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_LOT);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_DESC")));
                    }

                    in_node.SetString("NEXT_LOT_ID", in_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("NEXT_LOT_ID") != "");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        // ViewLotInfo()
        //       -  View Lot info
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewLotInfo(string sLot)
        {

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_OUT");

            try
            {
                MPCF.FieldClear(grpLot);
                MPCF.FieldClear(grpCrrInfo);
                lot_info.reset();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLot);
                in_node.AddString("CRR_ID", "");

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotID.Text = MPCF.Trim(out_node.GetString("LOT_ID"));
                txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
                txtLotQty1.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtLotQty2.Text = MPCF.Trim(out_node.GetDouble("QTY_2"));
                txtLotQty3.Text = MPCF.Trim(out_node.GetDouble("QTY_3"));
                txtAttachedQty1.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_TOT_QTY_1"));
                txtAttachedQty2.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_TOT_QTY_2"));
                txtAttachedQty3.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_TOT_QTY_3"));
                txtNonAttachedQty1.Text = Convert.ToString(out_node.GetDouble("QTY_1") - out_node.GetDouble("CRR_LOT_TOT_QTY_1"));
                txtNonAttachedQty2.Text = Convert.ToString(out_node.GetDouble("QTY_2") - out_node.GetDouble("CRR_LOT_TOT_QTY_2"));
                txtNonAttachedQty3.Text = Convert.ToString(out_node.GetDouble("QTY_3") - out_node.GetDouble("CRR_LOT_TOT_QTY_3"));

                lot_info.mat_id = out_node.GetString("MAT_ID");
                lot_info.mat_ver = out_node.GetInt("MAT_VER");
                lot_info.flow = out_node.GetString("FLOW");
                lot_info.oper = out_node.GetString("OPER");
                lot_info.res_id = out_node.GetString("RES_ID");
                lot_info.port_id = out_node.GetString("PORT_ID");

                if (out_node.GetInt("SUBLOT_COUNT") > 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(252));
                    MPCF.FieldClear(grpLot);
                    MPCF.FieldClear(grpCrrInfo);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        // View_Carrier_Lot()
        //       -  View Carrier Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrierLot(string sLot, string sCrr)
        {

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLot);
                in_node.AddString("CRR_ID", sCrr);

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvCrrID.Text = MPCF.Trim(out_node.GetString("CRR_ID"));
                txtCrrDesc.Text = MPCF.Trim(out_node.GetString("CRR_DESC"));
                txtCrrSize.Text = MPCF.Trim(out_node.GetInt("CRR_SIZE"));
                txtCrrQty1.Text = MPCF.Trim(out_node.GetDouble("CRR_QTY_1"));
                txtCrrQty2.Text = MPCF.Trim(out_node.GetDouble("CRR_QTY_2"));
                txtCrrQty3.Text = MPCF.Trim(out_node.GetDouble("CRR_QTY_3"));
                txtCrrAttachedQty1.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_1"));
                txtCrrAttachedQty2.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_2"));
                txtCrrAttachedQty3.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_3"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        
        // ViewCarrierLotList()
        //       - View Carrier - Lot Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°??Factory
        //
        private bool ViewCarrierLotList(Control control, char c_step, string sCrr, string sLot, string sExtFactory)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_LIST_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
              
                if (sExtFactory != "")
                {
                    in_node.Factory = MPCF.Trim(sExtFactory);
                }
                else
                {
                    
                }
                in_node.AddString("CRR_ID", sCrr);
                in_node.AddString("LOT_ID", sLot);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")), (int)SMALLICON_INDEX.IDX_CARRIER);
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("CRR_SIZE")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_QTY_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_3")));
                        }
                    }

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                    in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                } while (out_node.GetString("NEXT_LOT_ID") != "" || out_node.GetInt("NEXT_CRR_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        private bool CheckCondition(string FuncName)
        {
            double dQty1;
            
            dQty1 = 0;

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvCrrID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                
            case "ADD_CRR":
                
                dQty1 = MPCF.ToDbl(txtAttachQty1.Text);
                if (dQty1 < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154));
                    txtAttachedQty1.Focus();
                    return false;
                }
                if (dQty1 > MPCF.ToDbl(txtCrrSize.Text) - MPCF.ToDbl(txtCrrQty1.Text))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(189));
                    return false;
                }
                if (dQty1 > MPCF.ToDbl(txtNonAttachedQty1.Text))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(189));
                    return false;
                }
                break;
                
            case "DEL_CRR":

                if (lisCrrList.SelectedItems.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisCrrList.Focus();
                    return false;
                }
                
                break;
                
        }
        
        return true;
        
    }
    
    
    // AttachLotToCarrier()
    //       - Attach Lot to Carrier - Lot Relation
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByVal sLot As String           :  Lot
    //       - ByVal sCrr As String           :  Carrier ID
    //
        private bool AttachLotToCarrier(string sLot, string sCrr, double qty1, double qty2, double qty3)
        {

            TRSNode in_node = new TRSNode("ATTACH_LOT_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLot);
                in_node.AddString("NEW_CRR_ID", sCrr);
                in_node.AddDouble("QTY_1", qty1);
                in_node.AddDouble("QTY_2", qty2);
                in_node.AddDouble("QTY_3", qty3);

                if (MPCR.CallService("RAS", "RAS_Attach_Lot_Carrier", in_node, ref out_node) == false)
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

    
    // DetachLotFromCarrier()
    //       - Attach Lot to Carrier - Lot Relation
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByVal sLot As String           :  Lot
    //       - ByVal sCrr As String           :  Carrier ID
    //
        private bool DetachLotFromCarrier(string sLot, string sCrr)
        {

            TRSNode in_node = new TRSNode("DETACH_LOT_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLot);
                in_node.AddString("CRR_ID", sCrr);

                in_node.AddDouble("QTY_1", MPCF.ToDbl(txtAttachQty1.Text));
                in_node.AddDouble("QTY_2", MPCF.ToDbl(txtAttachQty2.Text));
                in_node.AddDouble("QTY_3", MPCF.ToDbl(txtAttachQty3.Text));

                if (MPCR.CallService("RAS", "RAS_Detach_Lot_Carrier", in_node, ref out_node) == false)
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

    
    public virtual Control GetFisrtFocusItem()
    {
        
        try
        {
            return this.cdvMatID;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return null;
        }
        
    }
    
    #endregion

        private void frmRASTranAttachCarrierToLot_Load(object sender, EventArgs e)
        {
            lot_info = new st_selected_lot_info();
        }

        private void frmRASTranAttachCarrierToLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.InitListView(lisLotList);
                MPCF.InitListView(lisCrrList);
                
                b_load_flag = true;
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisLotList, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";

                if (cdvOper.Text == "") return;

                cdvCrrGroup.Text = "";
                cdvCrrType.Text = "";

                ViewLotListMFO(cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvOper.Text);

                if (lisLotList.Items.Count < 1)
                {
                    return;
                }

                lblDataCount.Text = MPCF.Trim(lisLotList.Items.Count);
                MPCF.FindListItem(lisLotList, txtLotID.Text, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisLotList, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisLotList, txtFind.Text, 0, true, false);
            
        }
        
        private void cdvMatID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            cdvOper.Text = "";
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvOper.Text = "";
        }
        private void cdvFlow_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            if (cdvMatID.Text == "")
            {
                WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");
            }
            else
            {
                WIPLIST.ViewFlowList(cdvFlow.GetListView, '2', cdvMatID.Text, cdvMatID.Version, "", null, "");
            }
            
        }
        
        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            if (cdvMatID.Text != "" && cdvFlow.Text != "")
            {
                WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, "", null, "");
            }
            else
            {
                if (cdvFlow.Text == "")
                {
                    if (cdvMatID.Text == "")
                    {
                        WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0, "", "", null, "");
                    }
                    else
                    {
                        WIPLIST.ViewOperationList(cdvOper.GetListView, '3', cdvMatID.Text, cdvMatID.Version, "", "", null, "");
                    }
                }
                else
                {
                    WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0, cdvFlow.Text, "", null, "");
                }
            }
        }
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void lisLotList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (lisLotList.SelectedItems.Count > 0)
            {
                txtLotID.Text = MPCF.Trim(lisLotList.SelectedItems[0].Text);

                if (ViewLotInfo(txtLotID.Text) == false) return;

                ViewCarrierLotList(lisCrrList, '3', "", txtLotID.Text, "");
            }
        }
        
        private void lisCrrList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisCrrList.SelectedItems.Count > 0)
            {
                MPCF.FieldClear(grpCrrInfo);

                cdvCrrID.Text = lisCrrList.SelectedItems[0].Text;
                ViewCarrierLot(txtLotID.Text, cdvCrrID.Text);
            }
        }

        private void cdvCrrID_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrID.Init();
            MPCF.InitListView(cdvCrrID.GetListView);
            cdvCrrID.Columns.Add("CrrID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvCrrID.GetListView, '1', cdvCrrGroup.Text, cdvCrrType.Text, "", ' ', lot_info.mat_id, lot_info.mat_ver, lot_info.flow, lot_info.oper, lot_info.res_id, lot_info.port_id, cdvCrrID.Text, null, "");
        }

        private void cdvCrrID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvCrrID.Text != "")
            {
                MPCF.FieldClear(grpCrrInfo, cdvCrrGroup, cdvCrrType, cdvCrrID);

                if (ViewCarrierLot(txtLotID.Text, cdvCrrID.Text) == true)
                {
                    txtAttachQty1.Text = txtNonAttachedQty1.Text;
                    txtAttachQty2.Text = txtNonAttachedQty2.Text;
                    txtAttachQty3.Text = txtNonAttachedQty3.Text;
                }
            }
        }
        
        private void cdvCrrID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvCrrID_SelectedItemChanged(null, null);
            }
        }
        
        private void cdvCrrID_TextChanged(object sender, System.EventArgs e)
        {
            if (cdvCrrID.Text == "")
            {
                MPCF.FieldClear(grpCrrInfo, cdvCrrGroup, cdvCrrType);
            }
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sLot;
            string sCrr;
            double dQty1;
            double dQty2;
            double dQty3;
            
            if (CheckCondition("ADD_CRR") == false)
            {
                return;
            }
            
            sCrr = cdvCrrID.Text;
            
            sLot = txtLotID.Text;
            dQty1 = MPCF.ToDbl(txtAttachQty1.Text);
            dQty2 = MPCF.ToDbl(txtAttachQty2.Text);
            dQty3 = MPCF.ToDbl(txtAttachQty3.Text);
            
            if (AttachLotToCarrier(sLot, sCrr, dQty1, dQty2, dQty3) == false)
            {
                return;
            }
            
                        
            if (ViewLotInfo(sLot) == false)
            {
                return;
            }
            if (ViewCarrierLotList(lisCrrList, '3', "", sLot, "") == false)
            {
                return;
            }
            
            MPCF.FieldClear(grpCrrInfo, cdvCrrGroup, cdvCrrType);
            MPCF.FindListItem(lisCrrList, sCrr, false);
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sLot;
            string sCrr;
            int i;
            
            if (CheckCondition("DEL_CRR") == false)
            {
                return;
            }
            
            sLot = txtLotID.Text;
            
            for (i = 0; i <= lisCrrList.SelectedItems.Count - 1; i++)
            {
                sCrr = lisCrrList.SelectedItems[i].Text;
                
                DetachLotFromCarrier(sLot, sCrr);
            }
            
            if (ViewLotInfo(sLot) == false)
            {
                return;
            }
            if (ViewCarrierLotList(lisCrrList, '3', "", sLot, "") == false)
            {
                return;
            }
            
            MPCF.FieldClear(grpCrrInfo);
            
        }
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMatID.Init();
            MPCF.InitListView(cdvMatID.MaterialGetListView);
            cdvMatID.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
            cdvMatID.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMatID.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialList(cdvMatID.MaterialGetListView, '1');
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvOper, 1) == false) return;

            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;

            if(MPCF.Trim(cdvOper.Text) == "")
                RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
            else
                RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView, ' ', lot_info.mat_id, lot_info.mat_ver, lot_info.flow, lot_info.oper, lot_info.res_id, lot_info.port_id);

            cdvCrrGroup.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) != "")
            {
                cdvCrrID.Text = "";
            }
        }

        private void cdvCrrType_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrType.Init();
            MPCF.InitListView(cdvCrrType.GetListView);
            cdvCrrType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvCrrType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCrrType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvCrrType.InsertEmptyRow(0, 1);
        }


    
    }


//#End If '_CRR

}
