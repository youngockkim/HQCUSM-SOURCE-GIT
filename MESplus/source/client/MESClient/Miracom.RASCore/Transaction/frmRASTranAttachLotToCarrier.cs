
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
//   File Name   : frmRASTranAttachLotToCarrier.vb
//   Description : Attach and Detach Lot to Carrier Form
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
//       - 2006-02-03 : Created by Aiden Koo.
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASTranAttachLotToCarrier : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranAttachLotToCarrier()
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




        private Miracom.UI.Controls.MCListView.MCListView lisCarrier;
        private System.Windows.Forms.Label lblCrrQty1;
        private System.Windows.Forms.Label lblCrrSize;
        private System.Windows.Forms.TextBox txtCrrSize;
        private System.Windows.Forms.Label lblCrrID;
        private System.Windows.Forms.TextBox txtCrrID;
        private System.Windows.Forms.Label lblLotDesc;
        private System.Windows.Forms.TextBox txtLotDesc;
        private System.Windows.Forms.Label lblLotCarrier;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colAQty1;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colNQty1;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colAQty2;
        private System.Windows.Forms.ColumnHeader colNQty2;
        private System.Windows.Forms.ColumnHeader colQty3;
        private System.Windows.Forms.ColumnHeader colAQty3;
        private System.Windows.Forms.ColumnHeader colNQty3;
        private System.Windows.Forms.ColumnHeader colCrrID;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Label lblCrrDesc;
        private System.Windows.Forms.TextBox txtCrrDesc;
        private System.Windows.Forms.TextBox txtCrrQty3;
        private System.Windows.Forms.TextBox txtCrrQty2;
        private System.Windows.Forms.TextBox txtCrrQty1;
        private System.Windows.Forms.GroupBox grpLotInfo;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.GroupBox grpAttachedLotList;
        private System.Windows.Forms.TextBox txtAttachedQty3;
        private System.Windows.Forms.TextBox txtAttachedQty2;
        private System.Windows.Forms.TextBox txtAttachedQty1;
        private System.Windows.Forms.Label lblAttachedQty;
        private System.Windows.Forms.TextBox txtNonAttachedQty3;
        private System.Windows.Forms.TextBox txtNonAttachedQty2;
        private System.Windows.Forms.TextBox txtNonAttachedQty1;
        private System.Windows.Forms.Label lblNonAttachedQty;
        private System.Windows.Forms.TextBox txtAttachQty3;
        private System.Windows.Forms.TextBox txtAttachQty2;
        private System.Windows.Forms.TextBox txtAttachQty1;
        private System.Windows.Forms.Label lblAttachQty;
        private System.Windows.Forms.TextBox txtLotQty3;
        private System.Windows.Forms.TextBox txtLotQty2;
        private System.Windows.Forms.TextBox txtLotQty1;
        private System.Windows.Forms.Label lblLotQty;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private Label lblCrrGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private Label lblType;
        private System.Windows.Forms.GroupBox grpCarrier;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisCarrier = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCrrID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCarrier = new System.Windows.Forms.GroupBox();
            this.txtCrrQty3 = new System.Windows.Forms.TextBox();
            this.txtCrrQty2 = new System.Windows.Forms.TextBox();
            this.txtCrrQty1 = new System.Windows.Forms.TextBox();
            this.lblCrrDesc = new System.Windows.Forms.Label();
            this.txtCrrDesc = new System.Windows.Forms.TextBox();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtCrrID = new System.Windows.Forms.TextBox();
            this.lblCrrQty1 = new System.Windows.Forms.Label();
            this.lblCrrSize = new System.Windows.Forms.Label();
            this.txtCrrSize = new System.Windows.Forms.TextBox();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.txtLotQty3 = new System.Windows.Forms.TextBox();
            this.txtLotQty2 = new System.Windows.Forms.TextBox();
            this.txtLotQty1 = new System.Windows.Forms.TextBox();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.txtAttachQty3 = new System.Windows.Forms.TextBox();
            this.txtAttachQty2 = new System.Windows.Forms.TextBox();
            this.txtAttachQty1 = new System.Windows.Forms.TextBox();
            this.lblAttachQty = new System.Windows.Forms.Label();
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
            this.lblLotCarrier = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.grpAttachedLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrGroup = new System.Windows.Forms.Label();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCarrier.SuspendLayout();
            this.grpLotInfo.SuspendLayout();
            this.grpAttachedLotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
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
            this.pnlRight.Controls.Add(this.grpAttachedLotList);
            this.pnlRight.Controls.Add(this.grpLotInfo);
            this.pnlRight.Controls.Add(this.grpCarrier);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Size = new System.Drawing.Size(232, 90);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.cdvCrrGroup);
            this.grpFilter.Controls.Add(this.lblCrrGroup);
            this.grpFilter.Controls.Add(this.cdvType);
            this.grpFilter.Controls.Add(this.lblType);
            this.grpFilter.Size = new System.Drawing.Size(232, 88);
            this.grpFilter.Controls.SetChildIndex(this.rbnFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.rbnNoFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.btnFilterView, 0);
            this.grpFilter.Controls.SetChildIndex(this.txtFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.lblType, 0);
            this.grpFilter.Controls.SetChildIndex(this.cdvType, 0);
            this.grpFilter.Controls.SetChildIndex(this.lblCrrGroup, 0);
            this.grpFilter.Controls.SetChildIndex(this.cdvCrrGroup, 0);
            // 
            // btnFilterView
            // 
            this.btnFilterView.Location = new System.Drawing.Point(184, 62);
            this.btnFilterView.Size = new System.Drawing.Size(39, 20);
            this.btnFilterView.TabIndex = 7;
            this.btnFilterView.Click += new System.EventHandler(this.btnFilterView_Click);
            // 
            // rbnNoFilter
            // 
            this.rbnNoFilter.AutoSize = true;
            this.rbnNoFilter.Location = new System.Drawing.Point(131, 65);
            this.rbnNoFilter.Size = new System.Drawing.Size(36, 17);
            this.rbnNoFilter.TabIndex = 6;
            // 
            // rbnFilter
            // 
            this.rbnFilter.Location = new System.Drawing.Point(8, 65);
            this.rbnFilter.TabIndex = 4;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCarrier);
            this.pnlLeft.Location = new System.Drawing.Point(0, 90);
            this.pnlLeft.Size = new System.Drawing.Size(232, 416);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 62);
            this.txtFilter.MaxLength = 20;
            this.txtFilter.TabIndex = 5;
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
            this.lblFormTitle.Text = "Attach Lot To Carrier";
            // 
            // lisCarrier
            // 
            this.lisCarrier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCrrID,
            this.colDesc});
            this.lisCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCarrier.EnableSort = true;
            this.lisCarrier.EnableSortIcon = true;
            this.lisCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCarrier.FullRowSelect = true;
            this.lisCarrier.Location = new System.Drawing.Point(0, 0);
            this.lisCarrier.MultiSelect = false;
            this.lisCarrier.Name = "lisCarrier";
            this.lisCarrier.Size = new System.Drawing.Size(232, 416);
            this.lisCarrier.TabIndex = 0;
            this.lisCarrier.UseCompatibleStateImageBehavior = false;
            this.lisCarrier.View = System.Windows.Forms.View.Details;
            this.lisCarrier.SelectedIndexChanged += new System.EventHandler(this.lisCarrier_SelectedIndexChanged);
            // 
            // colCrrID
            // 
            this.colCrrID.Text = "Carrier ID";
            this.colCrrID.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 150;
            // 
            // grpCarrier
            // 
            this.grpCarrier.Controls.Add(this.txtCrrQty3);
            this.grpCarrier.Controls.Add(this.txtCrrQty2);
            this.grpCarrier.Controls.Add(this.txtCrrQty1);
            this.grpCarrier.Controls.Add(this.lblCrrDesc);
            this.grpCarrier.Controls.Add(this.txtCrrDesc);
            this.grpCarrier.Controls.Add(this.lblCrrID);
            this.grpCarrier.Controls.Add(this.txtCrrID);
            this.grpCarrier.Controls.Add(this.lblCrrQty1);
            this.grpCarrier.Controls.Add(this.lblCrrSize);
            this.grpCarrier.Controls.Add(this.txtCrrSize);
            this.grpCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCarrier.Location = new System.Drawing.Point(0, 0);
            this.grpCarrier.Name = "grpCarrier";
            this.grpCarrier.Size = new System.Drawing.Size(506, 94);
            this.grpCarrier.TabIndex = 0;
            this.grpCarrier.TabStop = false;
            // 
            // txtCrrQty3
            // 
            this.txtCrrQty3.Location = new System.Drawing.Point(442, 66);
            this.txtCrrQty3.MaxLength = 13;
            this.txtCrrQty3.Name = "txtCrrQty3";
            this.txtCrrQty3.ReadOnly = true;
            this.txtCrrQty3.Size = new System.Drawing.Size(56, 20);
            this.txtCrrQty3.TabIndex = 9;
            // 
            // txtCrrQty2
            // 
            this.txtCrrQty2.Location = new System.Drawing.Point(384, 66);
            this.txtCrrQty2.MaxLength = 13;
            this.txtCrrQty2.Name = "txtCrrQty2";
            this.txtCrrQty2.ReadOnly = true;
            this.txtCrrQty2.Size = new System.Drawing.Size(56, 20);
            this.txtCrrQty2.TabIndex = 8;
            // 
            // txtCrrQty1
            // 
            this.txtCrrQty1.Location = new System.Drawing.Point(326, 66);
            this.txtCrrQty1.MaxLength = 13;
            this.txtCrrQty1.Name = "txtCrrQty1";
            this.txtCrrQty1.ReadOnly = true;
            this.txtCrrQty1.Size = new System.Drawing.Size(56, 20);
            this.txtCrrQty1.TabIndex = 7;
            // 
            // lblCrrDesc
            // 
            this.lblCrrDesc.AutoSize = true;
            this.lblCrrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrDesc.Location = new System.Drawing.Point(10, 44);
            this.lblCrrDesc.Name = "lblCrrDesc";
            this.lblCrrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCrrDesc.TabIndex = 2;
            this.lblCrrDesc.Text = "Description";
            // 
            // txtCrrDesc
            // 
            this.txtCrrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrrDesc.Location = new System.Drawing.Point(118, 41);
            this.txtCrrDesc.MaxLength = 200;
            this.txtCrrDesc.Name = "txtCrrDesc";
            this.txtCrrDesc.ReadOnly = true;
            this.txtCrrDesc.Size = new System.Drawing.Size(380, 20);
            this.txtCrrDesc.TabIndex = 3;
            this.txtCrrDesc.TabStop = false;
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrID.Location = new System.Drawing.Point(10, 19);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 0;
            this.lblCrrID.Text = "Carrier ID";
            // 
            // txtCrrID
            // 
            this.txtCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrrID.Location = new System.Drawing.Point(118, 16);
            this.txtCrrID.MaxLength = 20;
            this.txtCrrID.Name = "txtCrrID";
            this.txtCrrID.ReadOnly = true;
            this.txtCrrID.Size = new System.Drawing.Size(96, 20);
            this.txtCrrID.TabIndex = 1;
            this.txtCrrID.TabStop = false;
            // 
            // lblCrrQty1
            // 
            this.lblCrrQty1.AutoSize = true;
            this.lblCrrQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrQty1.Location = new System.Drawing.Point(224, 69);
            this.lblCrrQty1.Name = "lblCrrQty1";
            this.lblCrrQty1.Size = new System.Drawing.Size(87, 13);
            this.lblCrrQty1.TabIndex = 6;
            this.lblCrrQty1.Text = "Carrier Qty 1/2/3";
            // 
            // lblCrrSize
            // 
            this.lblCrrSize.AutoSize = true;
            this.lblCrrSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrSize.Location = new System.Drawing.Point(10, 69);
            this.lblCrrSize.Name = "lblCrrSize";
            this.lblCrrSize.Size = new System.Drawing.Size(60, 13);
            this.lblCrrSize.TabIndex = 4;
            this.lblCrrSize.Text = "Carrier Size";
            // 
            // txtCrrSize
            // 
            this.txtCrrSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrrSize.Location = new System.Drawing.Point(118, 66);
            this.txtCrrSize.MaxLength = 6;
            this.txtCrrSize.Name = "txtCrrSize";
            this.txtCrrSize.ReadOnly = true;
            this.txtCrrSize.Size = new System.Drawing.Size(96, 20);
            this.txtCrrSize.TabIndex = 5;
            this.txtCrrSize.TabStop = false;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.txtLotQty3);
            this.grpLotInfo.Controls.Add(this.txtLotQty2);
            this.grpLotInfo.Controls.Add(this.txtLotQty1);
            this.grpLotInfo.Controls.Add(this.lblLotQty);
            this.grpLotInfo.Controls.Add(this.txtAttachQty3);
            this.grpLotInfo.Controls.Add(this.txtAttachQty2);
            this.grpLotInfo.Controls.Add(this.txtAttachQty1);
            this.grpLotInfo.Controls.Add(this.lblAttachQty);
            this.grpLotInfo.Controls.Add(this.txtNonAttachedQty3);
            this.grpLotInfo.Controls.Add(this.txtNonAttachedQty2);
            this.grpLotInfo.Controls.Add(this.txtNonAttachedQty1);
            this.grpLotInfo.Controls.Add(this.lblNonAttachedQty);
            this.grpLotInfo.Controls.Add(this.txtAttachedQty3);
            this.grpLotInfo.Controls.Add(this.txtAttachedQty2);
            this.grpLotInfo.Controls.Add(this.txtAttachedQty1);
            this.grpLotInfo.Controls.Add(this.lblAttachedQty);
            this.grpLotInfo.Controls.Add(this.lblLotDesc);
            this.grpLotInfo.Controls.Add(this.txtLotDesc);
            this.grpLotInfo.Controls.Add(this.lblLotCarrier);
            this.grpLotInfo.Controls.Add(this.txtLotID);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpLotInfo.Location = new System.Drawing.Point(0, 362);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(506, 144);
            this.grpLotInfo.TabIndex = 2;
            this.grpLotInfo.TabStop = false;
            this.grpLotInfo.Text = "Lot Information";
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
            // txtAttachQty3
            // 
            this.txtAttachQty3.Location = new System.Drawing.Point(402, 116);
            this.txtAttachQty3.MaxLength = 11;
            this.txtAttachQty3.Name = "txtAttachQty3";
            this.txtAttachQty3.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty3.TabIndex = 19;
            // 
            // txtAttachQty2
            // 
            this.txtAttachQty2.Location = new System.Drawing.Point(298, 116);
            this.txtAttachQty2.MaxLength = 11;
            this.txtAttachQty2.Name = "txtAttachQty2";
            this.txtAttachQty2.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty2.TabIndex = 18;
            // 
            // txtAttachQty1
            // 
            this.txtAttachQty1.Location = new System.Drawing.Point(194, 116);
            this.txtAttachQty1.MaxLength = 11;
            this.txtAttachQty1.Name = "txtAttachQty1";
            this.txtAttachQty1.Size = new System.Drawing.Size(96, 20);
            this.txtAttachQty1.TabIndex = 17;
            // 
            // lblAttachQty
            // 
            this.lblAttachQty.AutoSize = true;
            this.lblAttachQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttachQty.Location = new System.Drawing.Point(10, 119);
            this.lblAttachQty.Name = "lblAttachQty";
            this.lblAttachQty.Size = new System.Drawing.Size(88, 13);
            this.lblAttachQty.TabIndex = 16;
            this.lblAttachQty.Text = "Attach Qty 1/2/3";
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
            this.lblLotDesc.Location = new System.Drawing.Point(255, 19);
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
            this.txtLotDesc.Location = new System.Drawing.Point(326, 16);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(172, 20);
            this.txtLotDesc.TabIndex = 3;
            this.txtLotDesc.TabStop = false;
            // 
            // lblLotCarrier
            // 
            this.lblLotCarrier.AutoSize = true;
            this.lblLotCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotCarrier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotCarrier.Location = new System.Drawing.Point(10, 19);
            this.lblLotCarrier.Name = "lblLotCarrier";
            this.lblLotCarrier.Size = new System.Drawing.Size(25, 13);
            this.lblLotCarrier.TabIndex = 0;
            this.lblLotCarrier.Text = "Lot ";
            // 
            // txtLotID
            // 
            this.txtLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.Location = new System.Drawing.Point(118, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(120, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.TabStop = false;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // grpAttachedLotList
            // 
            this.grpAttachedLotList.Controls.Add(this.lisLotList);
            this.grpAttachedLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttachedLotList.Location = new System.Drawing.Point(0, 94);
            this.grpAttachedLotList.Name = "grpAttachedLotList";
            this.grpAttachedLotList.Size = new System.Drawing.Size(506, 268);
            this.grpAttachedLotList.TabIndex = 1;
            this.grpAttachedLotList.TabStop = false;
            this.grpAttachedLotList.Text = "Attached Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotID,
            this.colQty1,
            this.colAQty1,
            this.colNQty1,
            this.colQty2,
            this.colAQty2,
            this.colNQty2,
            this.colQty3,
            this.colAQty3,
            this.colNQty3});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(500, 249);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.SelectedIndexChanged += new System.EventHandler(this.lisLotList_SelectedIndexChanged);
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 100;
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
            // colNQty1
            // 
            this.colNQty1.Text = "N-Att Qty 1";
            this.colNQty1.Width = 55;
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
            // colNQty2
            // 
            this.colNQty2.Text = "N-Att Qty 2";
            this.colNQty2.Width = 55;
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
            // colNQty3
            // 
            this.colNQty3.Text = "N-Att Qty 3";
            this.colNQty3.Width = 55;
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
            this.cdvCrrGroup.Location = new System.Drawing.Point(93, 12);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = true;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(130, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 130;
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
            this.lblCrrGroup.Location = new System.Drawing.Point(9, 15);
            this.lblCrrGroup.Name = "lblCrrGroup";
            this.lblCrrGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCrrGroup.TabIndex = 0;
            this.lblCrrGroup.Text = "Carrier Group";
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(93, 37);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(130, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 3;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 130;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(9, 39);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(64, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Carrier Type";
            // 
            // frmRASTranAttachLotToCarrier
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranAttachLotToCarrier";
            this.Text = "Attach Lot To Carrier";
            this.VisibleFilterBox = true;
            this.Activated += new System.EventHandler(this.frmRASTranForm_Activated);
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
            this.grpCarrier.ResumeLayout(false);
            this.grpCarrier.PerformLayout();
            this.grpLotInfo.ResumeLayout(false);
            this.grpLotInfo.PerformLayout();
            this.grpAttachedLotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        bool b_load_flag;

        #endregion
        
        #region " Function Definition "
        
        // View_Carrier()
        //       -  View Carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrier(string sCrr)
        {

            TRSNode in_node = new TRSNode("VIEW_CARRIER_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_OUT");

            try
            {

                MPCF.FieldClear(grpCarrier);
                MPCF.FieldClear(grpLotInfo);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", sCrr);

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCrrID.Text = MPCF.Trim(out_node.GetString("CRR_ID"));
                txtCrrDesc.Text = MPCF.Trim(out_node.GetString("CRR_DESC"));
                txtCrrSize.Text = MPCF.Trim(out_node.GetInt("CRR_SIZE"));
                txtCrrQty1.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtCrrQty2.Text = MPCF.Trim(out_node.GetDouble("QTY_2"));
                txtCrrQty3.Text = MPCF.Trim(out_node.GetDouble("QTY_3"));

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
                            itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_LOT);
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_1") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_2")));
                            if (out_node.GetList(0)[i].GetDouble("LOT_QTY_2") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_2") < 0)
                            {
                                itmX.SubItems.Add("0");
                            }
                            else
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_2") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_2")));
                            }
                            
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_3")));
                            if (out_node.GetList(0)[i].GetDouble("LOT_QTY_3") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_3") < 0)
                            {
                                itmX.SubItems.Add("0");
                            }
                            else
                            {
                                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_3") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_3")));
                            }
                            
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

                MPCF.FieldClear(grpLotInfo);

                txtLotID.Text = MPCF.Trim(out_node.GetString("LOT_ID"));
                txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
                txtLotQty1.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtLotQty2.Text = MPCF.Trim(out_node.GetDouble("QTY_2"));
                txtLotQty3.Text = MPCF.Trim(out_node.GetDouble("QTY_3"));
                txtAttachedQty1.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_1"));
                txtAttachedQty2.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_2"));
                txtAttachedQty3.Text = MPCF.Trim(out_node.GetDouble("CRR_LOT_QTY_3"));
                txtNonAttachedQty1.Text = Convert.ToString(out_node.GetDouble("QTY_1") - out_node.GetDouble("CRR_LOT_TOT_QTY_1"));
                txtNonAttachedQty2.Text = Convert.ToString(out_node.GetDouble("QTY_2") - out_node.GetDouble("CRR_LOT_TOT_QTY_2"));
                txtNonAttachedQty3.Text = Convert.ToString(out_node.GetDouble("QTY_3") - out_node.GetDouble("CRR_LOT_TOT_QTY_3"));

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

            if (MPCF.CheckValue(txtCrrID, 1) == false) return false;
            if (MPCF.CheckValue(txtLotID, 1) == false) return false;
            if (ViewLotInfo(txtLotID.Text) == false) return false;
                        
            dQty1 = 0;
            switch (MPCF.Trim(FuncName))
            {
                case "ADD_LOT":

                        dQty1 = MPCF.ToDbl(txtAttachQty1.Text);
                        if (dQty1 < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(154));
                            return false;
                        }
                        if (dQty1 > MPCF.ToDbl(txtCrrSize.Text) - MPCF.ToDbl(txtCrrQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(189));
                            return false;
                        }
                    break;
                    
                case "DEL_LOT":
                    
                    break;
                    
            }
            
            return true;
            
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
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLot);
                in_node.AddString("CRR_ID", "");

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetInt("SUBLOT_COUNT") > 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(252));
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
                return this.cdvCrrGroup;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASTranForm_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.InitListView(lisCarrier);
                MPCF.InitListView(lisLotList);

                b_load_flag = true;
            }
        }

        private void btnFilterView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisCarrier, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (rbnFilter.Checked == true)
                {
                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(txtFilter.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            txtFilter.Focus();
                            return;
                        }
                    }
                }
                if (RASLIST.ViewCarrierList(lisCarrier, '1', cdvCrrGroup.Text, cdvType.Text, txtFilter.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                if (lisCarrier.Items.Count > 0)
                {
                    MPCF.FindListItem(lisCarrier, txtCrrID.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisCarrier, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisCarrier, txtFind.Text, 0, true, false);
            
        }
                
        private void lisCarrier_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (lisCarrier.SelectedItems.Count > 0)
            {
                txtCrrID.Text = MPCF.Trim(lisCarrier.SelectedItems[0].Text);
                
                ViewCarrier(txtCrrID.Text);
                ViewCarrierLotList(lisLotList, '1', txtCrrID.Text, "", "");
            }
        }
        
        private void lisLotList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisLotList.SelectedItems.Count > 0)
            {
                txtLotID.Text = lisLotList.SelectedItems[0].Text;
                ViewCarrierLot(txtLotID.Text, txtCrrID.Text);
            }
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtLotID.Text != "")
                {
                    if (ViewCarrierLot(txtLotID.Text, txtCrrID.Text) == true)
                    {
                        txtAttachQty1.Text = txtNonAttachedQty1.Text;
                        txtAttachQty2.Text = txtNonAttachedQty2.Text;
                        txtAttachQty3.Text = txtNonAttachedQty3.Text;
                    }
                }
            }
        }

        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.FieldClear(grpLotInfo);
            }
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sLot;
            string sCrr;
            double dQty1;
            double dQty2;
            double dQty3;

            if (CheckCondition("ADD_LOT") == false)
            {
                return;
            }
            
            sCrr = txtCrrID.Text;
            
            sLot = txtLotID.Text;
            dQty1 = MPCF.ToDbl(txtAttachQty1.Text);
            dQty2 = MPCF.ToDbl(txtAttachQty2.Text);
            dQty3 = MPCF.ToDbl(txtAttachQty3.Text);
            
            if (AttachLotToCarrier(sLot, sCrr, dQty1, dQty2, dQty3) == false)
            {
                return;
            }
            
            if (ViewCarrier(sCrr) == false)
            {
                return;
            }
            if (ViewCarrierLotList(lisLotList, '1', sCrr, "", "") == false)
            {
                return;
            }

            MPCF.FieldClear(grpLotInfo);
            MPCF.FindListItem(lisLotList, sLot, false);
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sLot;
            string sCrr;
            int i;

            if (CheckCondition("DEL_LOT") == false)
            {
                return;
            }
            
            sCrr = txtCrrID.Text;

            for (i = 0; i <= lisLotList.SelectedItems.Count - 1; i++)
            {
                sLot = lisLotList.SelectedItems[i].Text;
                
                DetachLotFromCarrier(sLot, sCrr);
            }
            
            if (ViewCarrier(sCrr) == false)
            {
                return;
            }
            if (ViewCarrierLotList(lisLotList, '1', sCrr, "", "") == false)
            {
                return;
            }

            MPCF.FieldClear(grpLotInfo);
            
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvType.InsertEmptyRow(0, 1);
        }

        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
            cdvCrrGroup.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(grpLotInfo);
            MPCF.FieldClear(grpCarrier);
            lisLotList.Items.Clear();
            lisCarrier.Items.Clear();
            
            if (MPCF.Trim(txtFilter.Text) != "")
            {
                btnRefresh.PerformClick();
            }
            else
            {
                if(txtFilter.Enabled == true)
                    txtFilter.Focus();
            }
        }

  }
    
    
    //#End If '_CRR
}
