
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
//   Description : Assign Lot to Carrier Form
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
    public class frmRASTranAssignSublotToCarrier : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranAssignSublotToCarrier()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.GroupBox grpLotInfo;
        private System.Windows.Forms.Panel pnlSublotMid;
        private System.Windows.Forms.Panel pnlSublotMidRight;
        private System.Windows.Forms.Panel pnlSublotMidLeft;
        private System.Windows.Forms.Panel pnlSublotMidMid;
        private System.Windows.Forms.Button btnAddSublot;
        private System.Windows.Forms.Button btnDelSublot;
        private System.Windows.Forms.ColumnHeader colSlot2;
        private System.Windows.Forms.ColumnHeader colSublot2;
        private System.Windows.Forms.ColumnHeader colLot2;
        private System.Windows.Forms.ColumnHeader colSlot1;
        private System.Windows.Forms.ColumnHeader colSublot1;
        private System.Windows.Forms.ColumnHeader colCrr1;
        private Miracom.UI.Controls.MCListView.MCListView lisCrrSublotList;
        private Miracom.UI.Controls.MCListView.MCListView lisSublotList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private Label lblCrrGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType;
        private Label lblCrrType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private Label lblCrrID;
        private Button btnUp;
        private Button btnDown;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASTranAssignSublotToCarrier));
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrGroup = new System.Windows.Forms.Label();
            this.cdvCrrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType = new System.Windows.Forms.Label();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.pnlSublotMid = new System.Windows.Forms.Panel();
            this.pnlSublotMidRight = new System.Windows.Forms.Panel();
            this.lisCrrSublotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSublot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSublotMidLeft = new System.Windows.Forms.Panel();
            this.lisSublotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSublot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCrr1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSublotMidMid = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAddSublot = new System.Windows.Forms.Button();
            this.btnDelSublot = new System.Windows.Forms.Button();
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
            this.grpLotInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.pnlSublotMid.SuspendLayout();
            this.pnlSublotMidRight.SuspendLayout();
            this.pnlSublotMidLeft.SuspendLayout();
            this.pnlSublotMidMid.SuspendLayout();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 531);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlSublotMid);
            this.pnlRight.Controls.Add(this.grpLotInfo);
            this.pnlRight.Size = new System.Drawing.Size(506, 531);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisLotList);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 531);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.Text = "Process";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 531);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 531);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Assign Sublot To Carrier";
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
            this.lisLotList.Size = new System.Drawing.Size(232, 445);
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
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_MaterialSelectedItemChanged);
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
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.cdvCrrGroup);
            this.grpLotInfo.Controls.Add(this.lblCrrGroup);
            this.grpLotInfo.Controls.Add(this.cdvCrrType);
            this.grpLotInfo.Controls.Add(this.lblCrrType);
            this.grpLotInfo.Controls.Add(this.cdvCrrID);
            this.grpLotInfo.Controls.Add(this.lblCrrID);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotInfo.Location = new System.Drawing.Point(0, 0);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(506, 60);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
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
            this.cdvCrrGroup.Location = new System.Drawing.Point(91, 11);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = true;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(123, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 123;
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
            this.lblCrrGroup.Location = new System.Drawing.Point(13, 14);
            this.lblCrrGroup.Name = "lblCrrGroup";
            this.lblCrrGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCrrGroup.TabIndex = 0;
            this.lblCrrGroup.Text = "Carrier Group";
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
            this.cdvCrrType.Location = new System.Drawing.Point(91, 35);
            this.cdvCrrType.MaxLength = 20;
            this.cdvCrrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.Name = "cdvCrrType";
            this.cdvCrrType.ReadOnly = true;
            this.cdvCrrType.SearchSubItemIndex = 0;
            this.cdvCrrType.SelectedDescIndex = -1;
            this.cdvCrrType.SelectedSubItemIndex = -1;
            this.cdvCrrType.SelectionStart = 0;
            this.cdvCrrType.Size = new System.Drawing.Size(123, 20);
            this.cdvCrrType.SmallImageList = null;
            this.cdvCrrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType.TabIndex = 5;
            this.cdvCrrType.TextBoxToolTipText = "";
            this.cdvCrrType.TextBoxWidth = 123;
            this.cdvCrrType.VisibleButton = true;
            this.cdvCrrType.VisibleColumnHeader = false;
            this.cdvCrrType.VisibleDescription = false;
            this.cdvCrrType.ButtonPress += new System.EventHandler(this.cdvCrrType_ButtonPress);
            // 
            // lblCrrType
            // 
            this.lblCrrType.AutoSize = true;
            this.lblCrrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType.Location = new System.Drawing.Point(13, 38);
            this.lblCrrType.Name = "lblCrrType";
            this.lblCrrType.Size = new System.Drawing.Size(64, 13);
            this.lblCrrType.TabIndex = 4;
            this.lblCrrType.Text = "Carrier Type";
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
            this.cdvCrrID.Location = new System.Drawing.Point(370, 11);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(123, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 3;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 123;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.ButtonPress += new System.EventHandler(this.cdvCrrID_ButtonPress);
            this.cdvCrrID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrrID_TextBoxKeyPress);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.Location = new System.Drawing.Point(296, 14);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(61, 13);
            this.lblCrrID.TabIndex = 2;
            this.lblCrrID.Text = "Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSublotMid
            // 
            this.pnlSublotMid.Controls.Add(this.pnlSublotMidRight);
            this.pnlSublotMid.Controls.Add(this.pnlSublotMidLeft);
            this.pnlSublotMid.Controls.Add(this.pnlSublotMidMid);
            this.pnlSublotMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSublotMid.Location = new System.Drawing.Point(0, 60);
            this.pnlSublotMid.Name = "pnlSublotMid";
            this.pnlSublotMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlSublotMid.Size = new System.Drawing.Size(506, 471);
            this.pnlSublotMid.TabIndex = 1;
            this.pnlSublotMid.Resize += new System.EventHandler(this.pnlSublot_Resize);
            // 
            // pnlSublotMidRight
            // 
            this.pnlSublotMidRight.Controls.Add(this.lisCrrSublotList);
            this.pnlSublotMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSublotMidRight.Location = new System.Drawing.Point(296, 5);
            this.pnlSublotMidRight.Name = "pnlSublotMidRight";
            this.pnlSublotMidRight.Size = new System.Drawing.Size(210, 466);
            this.pnlSublotMidRight.TabIndex = 1;
            // 
            // lisCrrSublotList
            // 
            this.lisCrrSublotList.AllowDrop = true;
            this.lisCrrSublotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot2,
            this.colSublot2,
            this.colLot2});
            this.lisCrrSublotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCrrSublotList.EnableSort = false;
            this.lisCrrSublotList.EnableSortIcon = true;
            this.lisCrrSublotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCrrSublotList.FullRowSelect = true;
            this.lisCrrSublotList.Location = new System.Drawing.Point(0, 0);
            this.lisCrrSublotList.Name = "lisCrrSublotList";
            this.lisCrrSublotList.Size = new System.Drawing.Size(210, 466);
            this.lisCrrSublotList.TabIndex = 0;
            this.lisCrrSublotList.UseCompatibleStateImageBehavior = false;
            this.lisCrrSublotList.View = System.Windows.Forms.View.Details;
            // 
            // colSlot2
            // 
            this.colSlot2.Text = "Slot";
            this.colSlot2.Width = 50;
            // 
            // colSublot2
            // 
            this.colSublot2.Text = "Sub Lot ID";
            this.colSublot2.Width = 100;
            // 
            // colLot2
            // 
            this.colLot2.Text = "Lot ID";
            this.colLot2.Width = 100;
            // 
            // pnlSublotMidLeft
            // 
            this.pnlSublotMidLeft.Controls.Add(this.lisSublotList);
            this.pnlSublotMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSublotMidLeft.Location = new System.Drawing.Point(0, 5);
            this.pnlSublotMidLeft.Name = "pnlSublotMidLeft";
            this.pnlSublotMidLeft.Size = new System.Drawing.Size(210, 466);
            this.pnlSublotMidLeft.TabIndex = 0;
            // 
            // lisSublotList
            // 
            this.lisSublotList.AllowDrop = true;
            this.lisSublotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot1,
            this.colSublot1,
            this.colCrr1});
            this.lisSublotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSublotList.EnableSort = false;
            this.lisSublotList.EnableSortIcon = true;
            this.lisSublotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSublotList.FullRowSelect = true;
            this.lisSublotList.Location = new System.Drawing.Point(0, 0);
            this.lisSublotList.Name = "lisSublotList";
            this.lisSublotList.Size = new System.Drawing.Size(210, 466);
            this.lisSublotList.TabIndex = 0;
            this.lisSublotList.UseCompatibleStateImageBehavior = false;
            this.lisSublotList.View = System.Windows.Forms.View.Details;
            // 
            // colSlot1
            // 
            this.colSlot1.Text = "Slot";
            this.colSlot1.Width = 50;
            // 
            // colSublot1
            // 
            this.colSublot1.Text = "Sub Lot ID";
            this.colSublot1.Width = 100;
            // 
            // colCrr1
            // 
            this.colCrr1.Text = "Carrier ID";
            this.colCrr1.Width = 100;
            // 
            // pnlSublotMidMid
            // 
            this.pnlSublotMidMid.Controls.Add(this.btnUp);
            this.pnlSublotMidMid.Controls.Add(this.btnDown);
            this.pnlSublotMidMid.Controls.Add(this.btnAddSublot);
            this.pnlSublotMidMid.Controls.Add(this.btnDelSublot);
            this.pnlSublotMidMid.Location = new System.Drawing.Point(222, 67);
            this.pnlSublotMidMid.Name = "pnlSublotMidMid";
            this.pnlSublotMidMid.Size = new System.Drawing.Size(63, 275);
            this.pnlSublotMidMid.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(36, 224);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(36, 248);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnAddSublot
            // 
            this.btnAddSublot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSublot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddSublot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSublot.Location = new System.Drawing.Point(19, 102);
            this.btnAddSublot.Name = "btnAddSublot";
            this.btnAddSublot.Size = new System.Drawing.Size(24, 24);
            this.btnAddSublot.TabIndex = 0;
            this.btnAddSublot.Text = ">";
            this.btnAddSublot.Click += new System.EventHandler(this.btnAddSublot_Click);
            // 
            // btnDelSublot
            // 
            this.btnDelSublot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelSublot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelSublot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelSublot.Location = new System.Drawing.Point(19, 132);
            this.btnDelSublot.Name = "btnDelSublot";
            this.btnDelSublot.Size = new System.Drawing.Size(24, 24);
            this.btnDelSublot.TabIndex = 1;
            this.btnDelSublot.Text = "<";
            this.btnDelSublot.Click += new System.EventHandler(this.btnDelSublot_Click);
            // 
            // frmRASTranAssignSublotToCarrier
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 571);
            this.Name = "frmRASTranAssignSublotToCarrier";
            this.Text = "Assign SublotTo Carrier";
            this.Activated += new System.EventHandler(this.frmRASTranForm_Activated);
            this.Load += new System.EventHandler(this.frmRASTranForm_Load);
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
            this.grpLotInfo.ResumeLayout(false);
            this.grpLotInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.pnlSublotMid.ResumeLayout(false);
            this.pnlSublotMidRight.ResumeLayout(false);
            this.pnlSublotMidLeft.ResumeLayout(false);
            this.pnlSublotMidMid.ResumeLayout(false);
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

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
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
        private bool ViewLotInfo(string sLot, string sCrr)
        {

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_OUT");

            try
            {
                lot_info.reset();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLot));
                in_node.AddString("CRR_ID", MPCF.Trim(sCrr));

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                lot_info.mat_id = out_node.GetString("MAT_ID");
                lot_info.mat_ver = out_node.GetInt("MAT_VER");
                lot_info.flow = out_node.GetString("FLOW");
                lot_info.oper = out_node.GetString("OPER");
                lot_info.res_id = out_node.GetString("RES_ID");
                lot_info.port_id = out_node.GetString("PORT_ID");

                if (out_node.GetInt("SUBLOT_COUNT") < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(253));
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


        private bool ViewSublotList(string sLotId)
        {

            int i;
            int ii;
            ListViewItem itm;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.InitListView(lisSublotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
            in_node.AddString("NEXT_CRR_ID", "");
            in_node.AddInt("NEXT_SLOT_NO", 0);

            ii = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itm = new ListViewItem("", (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");

                    lisSublotList.Items.Add(itm);
                }

                for (i = 0; i < out_node.GetList(0).Count; i++, ii++)
                {
                    lisSublotList.Items[ii].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                    lisSublotList.Items[ii].Text = out_node.GetList(0)[i].GetInt("SLOT_NO").ToString();
                    lisSublotList.Items[ii].SubItems[1].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBLOT_ID"));
                    lisSublotList.Items[ii].SubItems[2].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID"));
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            lisSublotList.Tag = "NOT_CHANGE";

            return true;

        }

        
        private bool CheckCondition()
        {
            if (lisLotList.SelectedItems.Count < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisLotList.Focus();
                return false;
            }

            if (MPCF.CheckValue(cdvCrrID, 1) == false) return false;

            return true;
        }

        // AssignCarrierSublot()
        //       - Assign sublot to carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool AssignCarrierSublot()
        {
            TRSNode in_node = new TRSNode("ASSIGN_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i_sublot_count;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(lisLotList.SelectedItems[0].Text));
                in_node.AddString("NEW_CRR_ID", MPCF.Trim(cdvCrrID.Text));

                i_sublot_count = 0;
                for (i = 0; i < lisCrrSublotList.Items.Count; i++)
                {
                    if (MPCF.Trim(lisCrrSublotList.Items[i].SubItems[1].Text) != "")
                    {
                        TRSNode list_item = in_node.AddNode("SUBLOT");                        
                        list_item.AddString("SUBLOT_ID", MPCF.Trim(lisCrrSublotList.Items[i].SubItems[1].Text));
                        list_item.AddInt("NEW_SLOT_NO", i + 1);
                        i_sublot_count++;
                    }
                }

                // No have sublot assigned to carrier
                if (i_sublot_count < 1) return true;

                if (MPCR.CallService("RAS", "RAS_Assign_Sublot_Carrier", in_node, ref out_node) == false)
                {
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


        // ReassignCarrierSublot()
        //       - Assign sublot to carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ReassignCarrierSublot()
        {
            TRSNode in_node = new TRSNode("ASSIGN_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i_sublot_count;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", MPCF.Trim(lisLotList.SelectedItems[0].Text));
                in_node.AddString("NEW_CRR_ID", "");
                i_sublot_count = 0;
                // For reassign sublot from selected carrier to empty.
                for (i = 0; i < lisSublotList.Items.Count; i++)
                {
                    if (MPCF.Trim(lisSublotList.Items[i].Tag) == "DEL")
                    {
                        TRSNode list_item = in_node.AddNode("SUBLOT");
                        list_item.AddString("SUBLOT_ID", MPCF.Trim(lisSublotList.Items[i].SubItems[1].Text));
                        list_item.AddInt("NEW_SLOT_NO", MPCF.ToInt(lisSublotList.Items[i].Text));
                        i_sublot_count++;
                    }
                }

                // No have sublot reassigned to empty
                if (i_sublot_count < 1) return true;

                if (MPCR.CallService("RAS", "RAS_Assign_Sublot_Carrier", in_node, ref out_node) == false)
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
                return this.cdvOper;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASTranForm_Load(object sender, System.EventArgs e)
        {
            lot_info = new st_selected_lot_info();
        }
        
        private void frmRASTranForm_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                pnlSublot_Resize(null, null);
                
                MPCF.InitListView(lisLotList);
                
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

                ViewLotListMFO(cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvOper.Text);

                lblDataCount.Text = lisLotList.Items.Count.ToString();
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

        private void cdvMatID_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
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
                        WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "",0, "", "", null, "");
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
        
        private void pnlSublot_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlSublotMid, pnlSublotMidLeft, pnlSublotMidRight, pnlSublotMidMid, 40);
        }
        
        private void lisLotList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (lisLotList.SelectedItems.Count > 0)
            {
                string s_lot_id = MPCF.Trim(lisLotList.SelectedItems[0].Text);

                cdvCrrID.Text = "";
                MPCF.InitListView(lisSublotList);
                MPCF.InitListView(lisCrrSublotList);

                if (ViewLotInfo(s_lot_id, cdvCrrID.Text) == false) return;

                ViewSublotList(s_lot_id);
            }
        }

        private void cdvCrrID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvCrrID_SelectedItemChanged(null, null);
            }
        }
        
        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvCrrID.Text != "")
            {
                if (RASLIST.ViewCarrierSublotList(lisCrrSublotList, '1', cdvCrrID.Text) == false) 
                    return;
                
                if (MPCF.Trim(lisSublotList.Tag) == "CHANGE")
                    ViewSublotList(lisLotList.SelectedItems[0].Text);
            }
        }
        
        private void cdvCrrID_ButtonPress(object sender, System.EventArgs e)
        {
            if (lisLotList.SelectedItems.Count < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisLotList.Focus();
                return;
            }

            cdvCrrID.Init();
            MPCF.InitListView(cdvCrrID.GetListView);
            cdvCrrID.Columns.Add("CrrID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvCrrID.GetListView, '1', cdvCrrGroup.Text, cdvCrrType.Text, "", ' ', lot_info.mat_id, lot_info.mat_ver, lot_info.flow, lot_info.oper, lot_info.res_id, lot_info.port_id, cdvCrrID.Text, null, "");
        }

        private void cdvCrrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCrrType.Init();
            MPCF.InitListView(cdvCrrType.GetListView);
            cdvCrrType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvCrrType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCrrType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvCrrType.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvOper, 1) == false) return;

            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvOper.Text) == "")
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
                lisCrrSublotList.Items.Clear();
            }
        }

        private void btnAddSublot_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_start_idx = 0;
            bool b_source_change;

            try
            {
                if (MPCF.CheckValue(cdvCrrID, 1) == false) return;
                if (lisSublotList.Items.Count < 1) return;
                if (lisCrrSublotList.Items.Count < 1) return;
                if (lisSublotList.SelectedItems.Count < 1) return;

                if (lisCrrSublotList.SelectedItems.Count < 1)   i_start_idx = 0;
                else                                            i_start_idx = lisCrrSublotList.SelectedItems[0].Index;

                b_source_change = false;
                for (i = 0; i < lisSublotList.SelectedItems.Count; i++)
                {
                    if (lisSublotList.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                    {
                        if (lisCrrSublotList.Items[i_start_idx].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY) break;

                        if (MPCF.FindListItem(lisCrrSublotList, lisSublotList.SelectedItems[i].SubItems[1].Text, 1, false) == false)
                        {
                            lisCrrSublotList.Items[i_start_idx].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW;
                            lisCrrSublotList.Items[i_start_idx].SubItems[1].Text = lisSublotList.SelectedItems[i].SubItems[1].Text;
                            lisCrrSublotList.Items[i_start_idx].SubItems[2].Text = lisLotList.SelectedItems[0].Text;

                            lisCrrSublotList.Items[i_start_idx].Selected = true;
                            lisCrrSublotList.Items[i_start_idx].EnsureVisible();
                            lisSublotList.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSublotList.SelectedItems[i].Tag = "";

                            b_source_change = true;
                            i_start_idx++;
                            if (i_start_idx > lisCrrSublotList.Items.Count - 1) break;
                        }
                    }
                }
                
                if (b_source_change == true)
                    lisSublotList.Tag = "CHANGE";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnDelSublot_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_source_index = 0;

            try
            {
                if (lisSublotList.Items.Count < 1) return;
                if (lisCrrSublotList.Items.Count < 1) return;
                if (lisCrrSublotList.SelectedItems.Count < 1) return;

                for (i = 0; i < lisCrrSublotList.SelectedItems.Count; i++)
                {
                    if (lisCrrSublotList.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL ||
                        lisCrrSublotList.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW)
                    {
                        if (MPCF.Trim(lisCrrSublotList.SelectedItems[i].SubItems[2].Text) != MPCF.Trim(lisLotList.SelectedItems[0].Text)) continue;

                        i_source_index = MPCF.FindListItemIndex(lisSublotList, lisCrrSublotList.SelectedItems[i].SubItems[1].Text, 1, false);
                        if (i_source_index < 0) continue;

                        // reassign already assigned sublot. Necessary update database 
                        if (MPCF.Trim(lisSublotList.Items[i_source_index].SubItems[2].Text) == MPCF.Trim(cdvCrrID.Text))
                        {
                            lisSublotList.Items[i_source_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                            lisSublotList.Items[i_source_index].Selected = true;
                            lisSublotList.Items[i_source_index].EnsureVisible();
                            lisSublotList.Items[i_source_index].Tag = "DEL";

                            lisCrrSublotList.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisCrrSublotList.SelectedItems[i].SubItems[1].Text = "";
                            lisCrrSublotList.SelectedItems[i].SubItems[2].Text = "";
                        }

                        // Just reassign carrier to sublot. No database update
                        else
                        {
                            lisSublotList.Items[i_source_index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                            lisSublotList.Items[i_source_index].Selected = true;
                            lisSublotList.Items[i_source_index].EnsureVisible();

                            lisCrrSublotList.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisCrrSublotList.SelectedItems[i].SubItems[1].Text = "";
                            lisCrrSublotList.SelectedItems[i].SubItems[2].Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            int i_image_index;
            string s_temp;

            if (lisCrrSublotList.SelectedItems.Count < 1) return;

            try
            {
                i_next = 0;
                for (i = 0; i < lisCrrSublotList.Items.Count; i++)
                {
                    if (lisCrrSublotList.Items[i].Selected == true &&
                        (lisCrrSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW ||
                         lisCrrSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL))
                    {
                        i_list_index = lisCrrSublotList.Items[i].Index;
                        if (i_list_index > i_next)
                        {
                            s_temp = lisCrrSublotList.Items[i_list_index].SubItems[1].Text;
                            lisCrrSublotList.Items[i_list_index].SubItems[1].Text = lisCrrSublotList.Items[i_list_index - 1].SubItems[1].Text;
                            lisCrrSublotList.Items[i_list_index - 1].SubItems[1].Text = s_temp;

                            s_temp = lisCrrSublotList.Items[i_list_index].SubItems[2].Text;
                            lisCrrSublotList.Items[i_list_index].SubItems[2].Text = lisCrrSublotList.Items[i_list_index - 1].SubItems[2].Text;
                            lisCrrSublotList.Items[i_list_index - 1].SubItems[2].Text = s_temp;

                            i_image_index = lisCrrSublotList.Items[i_list_index].ImageIndex;
                            lisCrrSublotList.Items[i_list_index].ImageIndex = lisCrrSublotList.Items[i_list_index - 1].ImageIndex;
                            lisCrrSublotList.Items[i_list_index - 1].ImageIndex = i_image_index;

                            lisCrrSublotList.Items[i_list_index].Selected = false;
                            lisCrrSublotList.Items[i_list_index - 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next;
            int i_list_index;
            int i_image_index;
            string s_temp;

            if (lisCrrSublotList.SelectedItems.Count < 1) return;

            try
            {
                i_next = lisCrrSublotList.Items.Count - 1;
                for (i = lisCrrSublotList.Items.Count - 1; i >= 0; i--)
                {
                    if (lisCrrSublotList.Items[i].Selected == true &&
                        (lisCrrSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL_NEW ||
                         lisCrrSublotList.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL))
                    {
                        i_list_index = lisCrrSublotList.Items[i].Index;
                        if (i_list_index < i_next)
                        {
                            s_temp = lisCrrSublotList.Items[i_list_index].SubItems[1].Text;
                            lisCrrSublotList.Items[i_list_index].SubItems[1].Text = lisCrrSublotList.Items[i_list_index + 1].SubItems[1].Text;
                            lisCrrSublotList.Items[i_list_index + 1].SubItems[1].Text = s_temp;

                            s_temp = lisCrrSublotList.Items[i_list_index].SubItems[2].Text;
                            lisCrrSublotList.Items[i_list_index].SubItems[2].Text = lisCrrSublotList.Items[i_list_index + 1].SubItems[2].Text;
                            lisCrrSublotList.Items[i_list_index + 1].SubItems[2].Text = s_temp;

                            i_image_index = lisCrrSublotList.Items[i_list_index].ImageIndex;
                            lisCrrSublotList.Items[i_list_index].ImageIndex = lisCrrSublotList.Items[i_list_index + 1].ImageIndex;
                            lisCrrSublotList.Items[i_list_index + 1].ImageIndex = i_image_index;

                            lisCrrSublotList.Items[i_list_index].Selected = false;
                            lisCrrSublotList.Items[i_list_index + 1].Selected = true;
                        }

                        if (i_list_index == i_next)
                        {
                            i_next--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return;
            if (AssignCarrierSublot() == false) return;
            if (ReassignCarrierSublot() == false) return;

            if (ViewSublotList(lisLotList.SelectedItems[0].Text) == false) return;
            if (RASLIST.ViewCarrierSublotList(lisCrrSublotList, '1', cdvCrrID.Text) == false) return;
        }


        


    }

//#End If '_CRR

}
