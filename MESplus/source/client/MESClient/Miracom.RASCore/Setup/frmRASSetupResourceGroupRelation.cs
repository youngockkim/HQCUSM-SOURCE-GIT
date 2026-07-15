//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupResourceGroupRelation.cs
//   Description : Resource - Operation Relation Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//       - Update_Resouce_Oper() : Create/Update/Delete Resource - Operation Relation
//       - CheckCondition()      : Check the conditions before transaction
//       - SelectClear()         : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-11 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public class frmRASSetupResourceGroupRelation : Miracom.MESCore.TranForm01
    {
        
#region " Windows Form auto generated code "
        
        public frmRASSetupResourceGroupRelation()
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
        



        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabResGroup;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlResource;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.Panel pnlRelatedRes;
        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCListView.MCListView lisResList1;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Splitter splGrp;
        private System.Windows.Forms.Splitter splRes;
        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.Panel pnlGroup1;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.Panel pnlGrpTop;
        private System.Windows.Forms.Panel pnlGrpMid;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.Panel pnlGrpMidLeft;
        private System.Windows.Forms.Panel pnlGrpMidMid;
        private System.Windows.Forms.Panel pnlGrpMidRight;
        private System.Windows.Forms.Label lblGroup;
        private Miracom.UI.Controls.MCListView.MCListView lisResGrpRel1;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.Label lblGroupList;
        private Miracom.UI.Controls.MCListView.MCListView lisGroupList1;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlResTop;
        private System.Windows.Forms.Panel pnlResMid;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Panel pnlResMidLeft;
        private System.Windows.Forms.Panel pnlResMidMid;
        private System.Windows.Forms.Panel pnlResMidRight;
        private System.Windows.Forms.Label lblRes;
        private Miracom.UI.Controls.MCListView.MCListView lisResGrpRel2;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.Label lblResList;
        private Miracom.UI.Controls.MCListView.MCListView lisResList2;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.Button btnDetach;
        private Miracom.UI.Controls.MCListView.MCListView lisGroupList2;
        protected Button btnResGrpExcel;
        protected Button btnResExcel;
        protected Panel pnlFind;
        protected Label lblDataCount;
        protected Label lblDataCountBase;
        protected Button btnExcel;
        protected Button btnRefresh;
        protected Button btnNext;
        protected TextBox txtFind;
        private System.Windows.Forms.Button btnAttach;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupResourceGroupRelation));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabResGroup = new System.Windows.Forms.TabControl();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.pnlGroup1 = new System.Windows.Forms.Panel();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.pnlGrpMid = new System.Windows.Forms.Panel();
            this.pnlGrpMidRight = new System.Windows.Forms.Panel();
            this.lisGroupList1 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList = new System.Windows.Forms.Label();
            this.pnlGrpMidMid = new System.Windows.Forms.Panel();
            this.btnResGrpExcel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlGrpMidLeft = new System.Windows.Forms.Panel();
            this.lisResGrpRel1 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlGrpTop = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.splGrp = new System.Windows.Forms.Splitter();
            this.pnlResource = new System.Windows.Forms.Panel();
            this.lisResList1 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.pnlRes = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.pnlResMid = new System.Windows.Forms.Panel();
            this.pnlResMidRight = new System.Windows.Forms.Panel();
            this.lisResList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResList = new System.Windows.Forms.Label();
            this.pnlResMidMid = new System.Windows.Forms.Panel();
            this.btnResExcel = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlResMidLeft = new System.Windows.Forms.Panel();
            this.lisResGrpRel2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRes = new System.Windows.Forms.Label();
            this.pnlResTop = new System.Windows.Forms.Panel();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.splRes = new System.Windows.Forms.Splitter();
            this.pnlRelatedRes = new System.Windows.Forms.Panel();
            this.lisGroupList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBase = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabResGroup.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlGroup1.SuspendLayout();
            this.grpGroup.SuspendLayout();
            this.pnlGrpMid.SuspendLayout();
            this.pnlGrpMidRight.SuspendLayout();
            this.pnlGrpMidMid.SuspendLayout();
            this.pnlGrpMidLeft.SuspendLayout();
            this.pnlGrpTop.SuspendLayout();
            this.pnlResource.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.tbpGroup.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.grpRes.SuspendLayout();
            this.pnlResMid.SuspendLayout();
            this.pnlResMidRight.SuspendLayout();
            this.pnlResMidMid.SuspendLayout();
            this.pnlResMidLeft.SuspendLayout();
            this.pnlResTop.SuspendLayout();
            this.pnlRelatedRes.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(559, 8);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(651, 8);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabResGroup);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTab.Size = new System.Drawing.Size(742, 506);
            this.pnlTab.TabIndex = 0;
            // 
            // tabResGroup
            // 
            this.tabResGroup.Controls.Add(this.tbpResource);
            this.tabResGroup.Controls.Add(this.tbpGroup);
            this.tabResGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResGroup.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResGroup.Location = new System.Drawing.Point(5, 5);
            this.tabResGroup.Name = "tabResGroup";
            this.tabResGroup.SelectedIndex = 0;
            this.tabResGroup.Size = new System.Drawing.Size(732, 496);
            this.tabResGroup.TabIndex = 0;
            this.tabResGroup.TabStop = false;
            this.tabResGroup.SelectedIndexChanged += new System.EventHandler(this.tabResGroup_SelectedIndexChanged);
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.pnlGroup1);
            this.tbpResource.Controls.Add(this.splGrp);
            this.tbpResource.Controls.Add(this.pnlResource);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(724, 470);
            this.tbpResource.TabIndex = 0;
            this.tbpResource.Text = "Resource";
            // 
            // pnlGroup1
            // 
            this.pnlGroup1.Controls.Add(this.grpGroup);
            this.pnlGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroup1.Location = new System.Drawing.Point(230, 3);
            this.pnlGroup1.Name = "pnlGroup1";
            this.pnlGroup1.Size = new System.Drawing.Size(491, 464);
            this.pnlGroup1.TabIndex = 2;
            this.pnlGroup1.Resize += new System.EventHandler(this.pnlGroup1_Resize);
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.pnlGrpMid);
            this.grpGroup.Controls.Add(this.pnlGrpTop);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.Location = new System.Drawing.Point(0, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(491, 464);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            // 
            // pnlGrpMid
            // 
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidRight);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidMid);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidLeft);
            this.pnlGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpMid.Location = new System.Drawing.Point(3, 46);
            this.pnlGrpMid.Name = "pnlGrpMid";
            this.pnlGrpMid.Size = new System.Drawing.Size(485, 415);
            this.pnlGrpMid.TabIndex = 1;
            // 
            // pnlGrpMidRight
            // 
            this.pnlGrpMidRight.Controls.Add(this.lisGroupList1);
            this.pnlGrpMidRight.Controls.Add(this.lblGroupList);
            this.pnlGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrpMidRight.Location = new System.Drawing.Point(259, 0);
            this.pnlGrpMidRight.Name = "pnlGrpMidRight";
            this.pnlGrpMidRight.Size = new System.Drawing.Size(226, 415);
            this.pnlGrpMidRight.TabIndex = 18;
            // 
            // lisGroupList1
            // 
            this.lisGroupList1.AllowDrop = true;
            this.lisGroupList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisGroupList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGroupList1.EnableSort = true;
            this.lisGroupList1.EnableSortIcon = true;
            this.lisGroupList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGroupList1.FullRowSelect = true;
            this.lisGroupList1.Location = new System.Drawing.Point(0, 14);
            this.lisGroupList1.Name = "lisGroupList1";
            this.lisGroupList1.Size = new System.Drawing.Size(226, 401);
            this.lisGroupList1.TabIndex = 1;
            this.lisGroupList1.UseCompatibleStateImageBehavior = false;
            this.lisGroupList1.View = System.Windows.Forms.View.Details;
            this.lisGroupList1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisGroupList1_ItemDrag);
            this.lisGroupList1.Click += new System.EventHandler(this.lisGroupList1_Click);
            this.lisGroupList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisGroupList1_DragDrop);
            this.lisGroupList1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisGroupList1_DragEnter);
            this.lisGroupList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisGroupList1_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Resource Group";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // lblGroupList
            // 
            this.lblGroupList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroupList.Location = new System.Drawing.Point(0, 0);
            this.lblGroupList.Name = "lblGroupList";
            this.lblGroupList.Size = new System.Drawing.Size(226, 14);
            this.lblGroupList.TabIndex = 0;
            this.lblGroupList.Text = "All Resource Group List";
            // 
            // pnlGrpMidMid
            // 
            this.pnlGrpMidMid.Controls.Add(this.btnResGrpExcel);
            this.pnlGrpMidMid.Controls.Add(this.btnDel);
            this.pnlGrpMidMid.Controls.Add(this.btnAdd);
            this.pnlGrpMidMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidMid.Location = new System.Drawing.Point(208, 0);
            this.pnlGrpMidMid.Name = "pnlGrpMidMid";
            this.pnlGrpMidMid.Size = new System.Drawing.Size(50, 415);
            this.pnlGrpMidMid.TabIndex = 17;
            // 
            // btnResGrpExcel
            // 
            this.btnResGrpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResGrpExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResGrpExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnResGrpExcel.Image")));
            this.btnResGrpExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResGrpExcel.Location = new System.Drawing.Point(3, 388);
            this.btnResGrpExcel.Name = "btnResGrpExcel";
            this.btnResGrpExcel.Size = new System.Drawing.Size(24, 24);
            this.btnResGrpExcel.TabIndex = 19;
            this.btnResGrpExcel.Click += new System.EventHandler(this.btnResGrpExcel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(13, 210);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlGrpMidLeft
            // 
            this.pnlGrpMidLeft.Controls.Add(this.lisResGrpRel1);
            this.pnlGrpMidLeft.Controls.Add(this.lblGroup);
            this.pnlGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMidLeft.Name = "pnlGrpMidLeft";
            this.pnlGrpMidLeft.Size = new System.Drawing.Size(208, 415);
            this.pnlGrpMidLeft.TabIndex = 16;
            // 
            // lisResGrpRel1
            // 
            this.lisResGrpRel1.AllowDrop = true;
            this.lisResGrpRel1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisResGrpRel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResGrpRel1.EnableSort = true;
            this.lisResGrpRel1.EnableSortIcon = true;
            this.lisResGrpRel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResGrpRel1.FullRowSelect = true;
            this.lisResGrpRel1.Location = new System.Drawing.Point(0, 14);
            this.lisResGrpRel1.Name = "lisResGrpRel1";
            this.lisResGrpRel1.Size = new System.Drawing.Size(208, 401);
            this.lisResGrpRel1.TabIndex = 1;
            this.lisResGrpRel1.UseCompatibleStateImageBehavior = false;
            this.lisResGrpRel1.View = System.Windows.Forms.View.Details;
            this.lisResGrpRel1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisResGrpRel1_ItemDrag);
            this.lisResGrpRel1.Click += new System.EventHandler(this.lisResGrpRel1_Click);
            this.lisResGrpRel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisResGrpRel1_DragDrop);
            this.lisResGrpRel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisResGrpRel1_DragEnter);
            this.lisResGrpRel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisResGrpRel1_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Resource Group";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Description";
            this.ColumnHeader14.Width = 150;
            // 
            // lblGroup
            // 
            this.lblGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(0, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(208, 14);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Resource - Resource Group Relation";
            // 
            // pnlGrpTop
            // 
            this.pnlGrpTop.Controls.Add(this.txtDesc);
            this.pnlGrpTop.Controls.Add(this.txtResID);
            this.pnlGrpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrpTop.Location = new System.Drawing.Point(3, 16);
            this.pnlGrpTop.Name = "pnlGrpTop";
            this.pnlGrpTop.Size = new System.Drawing.Size(485, 30);
            this.pnlGrpTop.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 0);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(338, 20);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TabStop = false;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(4, 0);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(134, 20);
            this.txtResID.TabIndex = 0;
            this.txtResID.TabStop = false;
            // 
            // splGrp
            // 
            this.splGrp.Location = new System.Drawing.Point(227, 3);
            this.splGrp.Name = "splGrp";
            this.splGrp.Size = new System.Drawing.Size(3, 464);
            this.splGrp.TabIndex = 2;
            this.splGrp.TabStop = false;
            // 
            // pnlResource
            // 
            this.pnlResource.Controls.Add(this.lisResList1);
            this.pnlResource.Controls.Add(this.pnlType);
            this.pnlResource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResource.Location = new System.Drawing.Point(3, 3);
            this.pnlResource.Name = "pnlResource";
            this.pnlResource.Size = new System.Drawing.Size(224, 464);
            this.pnlResource.TabIndex = 1;
            // 
            // lisResList1
            // 
            this.lisResList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisResList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList1.EnableSort = true;
            this.lisResList1.EnableSortIcon = true;
            this.lisResList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResList1.FullRowSelect = true;
            this.lisResList1.Location = new System.Drawing.Point(0, 40);
            this.lisResList1.MultiSelect = false;
            this.lisResList1.Name = "lisResList1";
            this.lisResList1.Size = new System.Drawing.Size(224, 424);
            this.lisResList1.TabIndex = 1;
            this.lisResList1.UseCompatibleStateImageBehavior = false;
            this.lisResList1.View = System.Windows.Forms.View.Details;
            this.lisResList1.SelectedIndexChanged += new System.EventHandler(this.lisResList1_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Resource";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(0, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(224, 40);
            this.pnlType.TabIndex = 0;
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
            this.cdvType.Location = new System.Drawing.Point(88, 11);
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
            this.cdvType.TabIndex = 1;
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
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(4, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(82, 14);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.pnlRes);
            this.tbpGroup.Controls.Add(this.splRes);
            this.tbpGroup.Controls.Add(this.pnlRelatedRes);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGroup.Size = new System.Drawing.Size(724, 470);
            this.tbpGroup.TabIndex = 1;
            this.tbpGroup.Text = "Resource Group";
            this.tbpGroup.Visible = false;
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.grpRes);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRes.Location = new System.Drawing.Point(230, 3);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Size = new System.Drawing.Size(491, 464);
            this.pnlRes.TabIndex = 1;
            this.pnlRes.Resize += new System.EventHandler(this.pnlRes_Resize);
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.pnlResMid);
            this.grpRes.Controls.Add(this.pnlResTop);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(0, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(491, 464);
            this.grpRes.TabIndex = 1;
            this.grpRes.TabStop = false;
            // 
            // pnlResMid
            // 
            this.pnlResMid.Controls.Add(this.pnlResMidRight);
            this.pnlResMid.Controls.Add(this.pnlResMidMid);
            this.pnlResMid.Controls.Add(this.pnlResMidLeft);
            this.pnlResMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResMid.Location = new System.Drawing.Point(3, 46);
            this.pnlResMid.Name = "pnlResMid";
            this.pnlResMid.Size = new System.Drawing.Size(485, 415);
            this.pnlResMid.TabIndex = 1;
            // 
            // pnlResMidRight
            // 
            this.pnlResMidRight.Controls.Add(this.lisResList2);
            this.pnlResMidRight.Controls.Add(this.lblResList);
            this.pnlResMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResMidRight.Location = new System.Drawing.Point(287, 0);
            this.pnlResMidRight.Name = "pnlResMidRight";
            this.pnlResMidRight.Size = new System.Drawing.Size(198, 415);
            this.pnlResMidRight.TabIndex = 18;
            // 
            // lisResList2
            // 
            this.lisResList2.AllowDrop = true;
            this.lisResList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisResList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList2.EnableSort = true;
            this.lisResList2.EnableSortIcon = true;
            this.lisResList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResList2.FullRowSelect = true;
            this.lisResList2.Location = new System.Drawing.Point(0, 14);
            this.lisResList2.Name = "lisResList2";
            this.lisResList2.Size = new System.Drawing.Size(198, 401);
            this.lisResList2.TabIndex = 16;
            this.lisResList2.UseCompatibleStateImageBehavior = false;
            this.lisResList2.View = System.Windows.Forms.View.Details;
            this.lisResList2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisResList2_ItemDrag);
            this.lisResList2.Click += new System.EventHandler(this.lisResList2_Click);
            this.lisResList2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisResList2_DragDrop);
            this.lisResList2.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisResList2_DragEnter);
            this.lisResList2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisResList2_MouseDown);
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Resource";
            this.ColumnHeader9.Width = 100;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Description";
            this.ColumnHeader10.Width = 150;
            // 
            // lblResList
            // 
            this.lblResList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResList.Location = new System.Drawing.Point(0, 0);
            this.lblResList.Name = "lblResList";
            this.lblResList.Size = new System.Drawing.Size(198, 14);
            this.lblResList.TabIndex = 14;
            this.lblResList.Text = "All Resource List";
            // 
            // pnlResMidMid
            // 
            this.pnlResMidMid.Controls.Add(this.btnResExcel);
            this.pnlResMidMid.Controls.Add(this.btnDetach);
            this.pnlResMidMid.Controls.Add(this.btnAttach);
            this.pnlResMidMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResMidMid.Location = new System.Drawing.Point(220, 0);
            this.pnlResMidMid.Name = "pnlResMidMid";
            this.pnlResMidMid.Size = new System.Drawing.Size(67, 415);
            this.pnlResMidMid.TabIndex = 17;
            // 
            // btnResExcel
            // 
            this.btnResExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnResExcel.Image")));
            this.btnResExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResExcel.Location = new System.Drawing.Point(3, 388);
            this.btnResExcel.Name = "btnResExcel";
            this.btnResExcel.Size = new System.Drawing.Size(24, 24);
            this.btnResExcel.TabIndex = 20;
            this.btnResExcel.Click += new System.EventHandler(this.btnResExcel_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(21, 210);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 17;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(21, 181);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 16;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlResMidLeft
            // 
            this.pnlResMidLeft.Controls.Add(this.lisResGrpRel2);
            this.pnlResMidLeft.Controls.Add(this.lblRes);
            this.pnlResMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlResMidLeft.Name = "pnlResMidLeft";
            this.pnlResMidLeft.Size = new System.Drawing.Size(220, 415);
            this.pnlResMidLeft.TabIndex = 16;
            // 
            // lisResGrpRel2
            // 
            this.lisResGrpRel2.AllowDrop = true;
            this.lisResGrpRel2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisResGrpRel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResGrpRel2.EnableSort = true;
            this.lisResGrpRel2.EnableSortIcon = true;
            this.lisResGrpRel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResGrpRel2.FullRowSelect = true;
            this.lisResGrpRel2.Location = new System.Drawing.Point(0, 14);
            this.lisResGrpRel2.Name = "lisResGrpRel2";
            this.lisResGrpRel2.Size = new System.Drawing.Size(220, 401);
            this.lisResGrpRel2.TabIndex = 15;
            this.lisResGrpRel2.UseCompatibleStateImageBehavior = false;
            this.lisResGrpRel2.View = System.Windows.Forms.View.Details;
            this.lisResGrpRel2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisResGrpRel2_ItemDrag);
            this.lisResGrpRel2.Click += new System.EventHandler(this.lisResGrpRel2_Click);
            this.lisResGrpRel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisResGrpRel2_DragDrop);
            this.lisResGrpRel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisResGrpRel2_DragEnter);
            this.lisResGrpRel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisResGrpRel2_MouseDown);
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Resource";
            this.ColumnHeader11.Width = 100;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Description";
            this.ColumnHeader12.Width = 150;
            // 
            // lblRes
            // 
            this.lblRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRes.Location = new System.Drawing.Point(0, 0);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(220, 14);
            this.lblRes.TabIndex = 13;
            this.lblRes.Text = "Resource - Resource Group Relation";
            // 
            // pnlResTop
            // 
            this.pnlResTop.Controls.Add(this.txtGroupDesc);
            this.pnlResTop.Controls.Add(this.txtGroup);
            this.pnlResTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResTop.Location = new System.Drawing.Point(3, 16);
            this.pnlResTop.Name = "pnlResTop";
            this.pnlResTop.Size = new System.Drawing.Size(485, 30);
            this.pnlResTop.TabIndex = 0;
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupDesc.Location = new System.Drawing.Point(142, 0);
            this.txtGroupDesc.MaxLength = 200;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.ReadOnly = true;
            this.txtGroupDesc.Size = new System.Drawing.Size(338, 20);
            this.txtGroupDesc.TabIndex = 11;
            this.txtGroupDesc.TabStop = false;
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(4, 0);
            this.txtGroup.MaxLength = 20;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(134, 20);
            this.txtGroup.TabIndex = 10;
            this.txtGroup.TabStop = false;
            // 
            // splRes
            // 
            this.splRes.Location = new System.Drawing.Point(227, 3);
            this.splRes.Name = "splRes";
            this.splRes.Size = new System.Drawing.Size(3, 464);
            this.splRes.TabIndex = 18;
            this.splRes.TabStop = false;
            // 
            // pnlRelatedRes
            // 
            this.pnlRelatedRes.Controls.Add(this.lisGroupList2);
            this.pnlRelatedRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRelatedRes.Location = new System.Drawing.Point(3, 3);
            this.pnlRelatedRes.Name = "pnlRelatedRes";
            this.pnlRelatedRes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlRelatedRes.Size = new System.Drawing.Size(224, 464);
            this.pnlRelatedRes.TabIndex = 0;
            // 
            // lisGroupList2
            // 
            this.lisGroupList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lisGroupList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGroupList2.EnableSort = true;
            this.lisGroupList2.EnableSortIcon = true;
            this.lisGroupList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGroupList2.FullRowSelect = true;
            this.lisGroupList2.Location = new System.Drawing.Point(0, 3);
            this.lisGroupList2.MultiSelect = false;
            this.lisGroupList2.Name = "lisGroupList2";
            this.lisGroupList2.Size = new System.Drawing.Size(224, 461);
            this.lisGroupList2.TabIndex = 0;
            this.lisGroupList2.UseCompatibleStateImageBehavior = false;
            this.lisGroupList2.View = System.Windows.Forms.View.Details;
            this.lisGroupList2.SelectedIndexChanged += new System.EventHandler(this.lisGroupList2_SelectedIndexChanged);
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Resource Group";
            this.ColumnHeader7.Width = 100;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Description";
            this.ColumnHeader8.Width = 130;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 150;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 150;
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBase);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(239, 40);
            this.pnlFind.TabIndex = 2;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(11, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(40, 12);
            this.lblDataCount.TabIndex = 1;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBase.Location = new System.Drawing.Point(10, 9);
            this.lblDataCountBase.Name = "lblDataCountBase";
            this.lblDataCountBase.Size = new System.Drawing.Size(42, 21);
            this.lblDataCountBase.TabIndex = 0;
            this.lblDataCountBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(206, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(180, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(154, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(54, 9);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 20);
            this.txtFind.TabIndex = 2;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // frmRASSetupResourceGroupRelation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmRASSetupResourceGroupRelation";
            this.Text = "Resource - Resource Group Relation Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupResourceGroupRelation_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupResourceGroupRelation_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabResGroup.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlGroup1.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            this.pnlGrpMid.ResumeLayout(false);
            this.pnlGrpMidRight.ResumeLayout(false);
            this.pnlGrpMidMid.ResumeLayout(false);
            this.pnlGrpMidLeft.ResumeLayout(false);
            this.pnlGrpTop.ResumeLayout(false);
            this.pnlGrpTop.PerformLayout();
            this.pnlResource.ResumeLayout(false);
            this.pnlType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.tbpGroup.ResumeLayout(false);
            this.pnlRes.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.pnlResMid.ResumeLayout(false);
            this.pnlResMidRight.ResumeLayout(false);
            this.pnlResMidMid.ResumeLayout(false);
            this.pnlResMidLeft.ResumeLayout(false);
            this.pnlResTop.ResumeLayout(false);
            this.pnlResTop.PerformLayout();
            this.pnlRelatedRes.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.ResumeLayout(false);

        }
        
#endregion

#region " Variable Definition "
        
        bool b_load_flag;

#endregion

#region " Function Definition "

        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        private void SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
        }
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "ATTACH_GROUP":
                    
                    if (lisResList1.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisResList1.Items.Count > 0)
                        {
                            lisResList1.Items[0].Selected = true;
                            lisResList1.Focus();
                        }
                        return false;
                    }
                    if (lisGroupList1.SelectedItems.Count <= 0)
                    {
                        if (lisGroupList1.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisGroupList1.Items[0].Selected = true;
                            lisGroupList1.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_GROUP":
                    
                    if (lisResList1.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisResList1.Items.Count > 0)
                        {
                            lisResList1.Items[0].Selected = true;
                            lisResList1.Focus();
                        }
                        return false;
                    }
                    if (lisResGrpRel1.SelectedItems.Count <= 0)
                    {
                        if (lisResGrpRel1.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResGrpRel1.Items[0].Selected = true;
                            lisResGrpRel1.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_RES":

                    if (lisGroupList2.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisGroupList2.Items.Count > 0)
                        {
                            lisGroupList2.Items[0].Selected = true;
                            lisGroupList2.Focus();
                        }
                        return false;
                    }
                    if (lisResList2.SelectedItems.Count <= 0)
                    {
                        if (lisResList2.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResList2.Items[0].Selected = true;
                            lisResList2.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_RES":

                    if (lisGroupList2.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisGroupList2.Items.Count > 0)
                        {
                            lisGroupList2.Items[0].Selected = true;
                            lisGroupList2.Focus();
                        }
                        return false;
                    }
                    if (lisResGrpRel2.SelectedItems.Count <= 0)
                    {
                        if (lisResGrpRel2.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResGrpRel2.Items[0].Selected = true;
                            lisResGrpRel2.Focus();
                        }
                        return false;
                    }
                    break;
            }
            
            return true;
        }

        // UpdateResourceGroupRelation()
        //       - Create/Update/Delete Resource - Group Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char c_step           : Process Step
        //       - string s_group       : Resource group id
        //       - string s_res         : Resource ID
        //
        private bool UpdateResourceGroupRelation(char c_step, string s_group, string s_res)
        {
            TRSNode in_node = new TRSNode("Update_Resource_Group_Relation_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
           
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("RESG_ID", s_group);
                in_node.AddString("RES_ID", s_res);
                
                if (MPCR.CallService("RAS", "RAS_Update_Resource_Group_Relation", in_node, ref out_node) == false)
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabResGroup;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion
        
        private void frmRASSetupResourceGroupRelation_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                lblDataCount.Text = "";

                pnlGroup1_Resize(null, null);
                pnlRes_Resize(null, null);
                
                lisResList1.Focus();

                if (RASLIST.ViewResourceGroupList(lisGroupList1, '1') == false) return;
                if (RASLIST.ViewResourceList(lisResList1, "", cdvType.Text, false) == false) return;
                if (lisResList1.Items.Count > 0)
                    lisResList1.Items[0].Selected = true;

                // Added by DM KIM 2013.09.02 
                lblDataCount.Text = lisResList1.Items.Count.ToString();

                if (RASLIST.ViewResourceList(lisResList2, false) == false) return;
                if (RASLIST.ViewResourceGroupList(lisGroupList2, '1') == false) return;
                if (lisGroupList2.Items.Count > 0)
                    lisGroupList2.Items[0].Selected = true;
                
                btnProcess.Visible = false;
                b_load_flag = true;
            }
        }
        
        private void frmRASSetupResourceGroupRelation_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisResList1);
                MPCF.InitListView(lisResList2);
                MPCF.InitListView(lisResGrpRel1);
                MPCF.InitListView(lisResGrpRel2);
                MPCF.InitListView(lisGroupList1);
                MPCF.InitListView(lisGroupList2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisResList1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.InitListView(lisResGrpRel1);
            MPCF.FieldClear(grpGroup);
            if (lisResList1.SelectedItems.Count > 0)
            {
                RASLIST.ViewResourceGroupList(lisResGrpRel1, '2', lisResList1.SelectedItems[0].Text);
                txtResID.Text = lisResList1.SelectedItems[0].Text;
                txtDesc.Text = lisResList1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void lisGroupList2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MPCF.InitListView(lisResGrpRel2);
            MPCF.FieldClear(grpRes);
            if (lisGroupList2.SelectedItems.Count > 0)
            {
                RASLIST.ViewResourceList(lisResGrpRel2, lisGroupList2.SelectedItems[0].Text, "", false);
                txtGroup.Text = lisGroupList2.SelectedItems[0].Text;
                txtGroupDesc.Text = lisGroupList2.SelectedItems[0].SubItems[1].Text;
            }
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            string s_res;
            ListViewItem itmX;
            string[] s_select = null;
            int i;
            int j;
            int i_idx = 0;
            
            s_select = new string[lisGroupList1.SelectedItems.Count];
            SelectClear(lisResGrpRel1);

            if (CheckCondition("ATTACH_GROUP") == false) return;
            
            for (i = 0; i <= lisGroupList1.SelectedItems.Count - 1; i++)
            {
                s_group = lisGroupList1.SelectedItems[i].Text;
                s_res = lisResList1.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisResGrpRel1, s_group, false) == false)
                {
                    if (UpdateResourceGroupRelation(MPGC.MP_STEP_CREATE, s_group, s_res) == true)
                    {
                        s_select[i] = s_group;
                        itmX = lisResGrpRel1.Items.Add(s_group, (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                        itmX.SubItems.Add(lisGroupList1.SelectedItems[i].SubItems[1].Text);
                        i_idx = lisGroupList1.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= s_select.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisResGrpRel1, s_select[j], false);
                        }
                        SelectClear(lisGroupList1);
                        return;
                    }
                }
                else
                {
                    s_select[i] = s_group;
                    i_idx = lisGroupList1.SelectedItems[i].Index;
                }
            }
            
            SelectClear(lisGroupList1);

            if (s_select.Length == 1)
            {
                if (i_idx < lisGroupList1.Items.Count - 1)
                {
                    lisGroupList1.Items[i_idx + 1].Selected = true;
                }
            }
            
            for (i = 0; i <= s_select.Length - 1; i++)
            {
                MPCF.FindListItem(lisResGrpRel1, s_select[i], false);
            }
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            string s_res;
            int i_idx = 0;
            int i;
            int i_count;
            
            if (CheckCondition("DETACH_GROUP") == false) return;

            i_count = lisResGrpRel1.SelectedItems.Count;
            SelectClear(lisGroupList1);
            
            for (i = lisResGrpRel1.SelectedItems.Count - 1; i >= 0; i--)
            {
                s_group = lisResGrpRel1.SelectedItems[i].Text;
                s_res = lisResList1.SelectedItems[0].Text;
                
                if (UpdateResourceGroupRelation(MPGC.MP_STEP_DELETE, s_group, s_res) == true)
                {
                    i_idx = lisResGrpRel1.SelectedItems[i].Index;
                    lisResGrpRel1.Items.RemoveAt(i_idx);
                    MPCF.FindListItem(lisGroupList1, s_group, false);
                }
            }
            if (i_count == 1)
            {
                if (i_idx < lisResGrpRel1.Items.Count)
                {
                    lisResGrpRel1.Items[i_idx].Selected = true;
                }
            }
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            string s_res;
            string[] s_select = null;
            ListViewItem itmX;
            int i;
            int j;
            int i_idx = 0;
            
            s_select = new string[lisResList2.SelectedItems.Count];
            SelectClear(lisResGrpRel2);

            if (CheckCondition("ATTACH_RES") == false) return;

            for (i = 0; i <= lisResList2.SelectedItems.Count - 1; i++)
            {
                s_group = lisGroupList2.SelectedItems[0].Text;
                s_res = lisResList2.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisResGrpRel2, s_res, false) == false)
                {
                    if (UpdateResourceGroupRelation(MPGC.MP_STEP_CREATE, s_group, s_res) == true)
                    {
                        s_select[i] = s_res;
                        itmX = lisResGrpRel2.Items.Add(s_res, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itmX.SubItems.Add(lisResList2.SelectedItems[i].SubItems[1].Text);
                        i_idx = lisResList2.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= s_select.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisResGrpRel2, s_select[j], false);
                        }
                        SelectClear(lisResList2);
                        return;
                    }
                }
                else
                {
                    s_select[i] = s_res;
                    i_idx = lisResList2.SelectedItems[i].Index;
                }
            }

            SelectClear(lisResList2);
            if (s_select.Length == 1)
            {
                if (i_idx < lisResList2.Items.Count - 1)
                {
                    lisResList2.Items[i_idx + 1].Selected = true;
                }
            }
            for (i = 0; i <= s_select.Length - 1; i++)
            {
                MPCF.FindListItem(lisResGrpRel2, s_select[i], false);
            }
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            string s_res;
            int i;
            int i_idx = 0;
            int i_count;
            
            if (CheckCondition("DETACH_RES") == false) return;

            i_count = lisResGrpRel2.SelectedItems.Count;
            SelectClear(lisResList2);

            for (i = lisResGrpRel2.SelectedItems.Count - 1; i >= 0; i--)
            {
                s_group = lisGroupList2.SelectedItems[0].Text;
                s_res = lisResGrpRel2.SelectedItems[i].Text;
                
                if (UpdateResourceGroupRelation(MPGC.MP_STEP_DELETE, s_group, s_res) == true)
                {
                    i_idx = lisResGrpRel2.SelectedItems[i].Index;
                    lisResGrpRel2.Items.RemoveAt(i_idx);
                    MPCF.FindListItem(lisResList2, s_res, false);
                }
            }
            if (i_count == 1)
            {
                if (i_idx < lisResGrpRel2.Items.Count)
                {
                    lisResGrpRel2.Items[i_idx].Selected = true;
                }
            }
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            cdvType.AddEmptyRow(1);
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (RASLIST.ViewResourceList(lisResList1, "", cdvType.Text, false) == false) return;

            lblDataCount.Text = lisResList1.Items.Count.ToString();

            if (lisResList1.Items.Count > 0)
            {
                lisResList1.Items[0].Selected = true;
            }
            else
            {
                MPCF.InitListView(lisResGrpRel1);
                txtResID.Text = "";
                txtDesc.Text = "";
            }
        }

        private void pnlGroup1_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlGrpMid, pnlGrpMidLeft, pnlGrpMidRight, pnlGrpMidMid, 40);
        }

        private void pnlRes_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlResMid, pnlResMidLeft, pnlResMidRight, pnlResMidMid, 40);
        }

        private void lisResGrpRel1_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            
        }

        private void lisResGrpRel1_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void lisResGrpRel1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisResGrpRel1.DoDragDrop(lisResGrpRel1.SelectedItems[0].Text, DragDropEffects.Move);
        }

        private void lisResGrpRel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisResGrpRel1.AllowDrop = false;
            lisGroupList1.AllowDrop = true;
        }

        private void lisResGrpRel2_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisResGrpRel2_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            btnAttach_Click(null, null);
        }

        private void lisResGrpRel2_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisResGrpRel2.DoDragDrop(lisResGrpRel2.SelectedItems[0].Text, DragDropEffects.Move);
        }

        private void lisResGrpRel2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisResGrpRel2.AllowDrop = false;
            lisResList2.AllowDrop = true;
        }

        private void lisGroupList1_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisGroupList1.DoDragDrop(lisGroupList1.SelectedItems[0].Text, DragDropEffects.Copy);
        }

        private void lisGroupList1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisGroupList1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            btnDel_Click(null, null);
        }

        private void lisGroupList1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisGroupList1.AllowDrop = false;
            lisResGrpRel1.AllowDrop = true;
        }

        private void lisResList2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisResList2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            btnDetach_Click(null, null);
        }

        private void lisResList2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisResList2.AllowDrop = false;
            lisResGrpRel2.AllowDrop = true;
        }

        private void lisResList2_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisResList2.DoDragDrop(lisResList2.SelectedItems[0].Text, DragDropEffects.Copy);
        }

        private void lisGroupList1_Click(object sender, System.EventArgs e)
        {
            SelectClear(lisResGrpRel1);
        }

        private void lisResGrpRel1_Click(object sender, System.EventArgs e)
        {
            SelectClear(lisGroupList1);
        }

        private void lisResGrpRel2_Click(object sender, System.EventArgs e)
        {
            SelectClear(lisResList2);
        }

        private void lisResList2_Click(object sender, System.EventArgs e)
        {
            SelectClear(lisResGrpRel2);
        }

        private void btnResGrpExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sText = string.Empty;


                sText = this.Text + " - " + lisResList1.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisResGrpRel1, sText, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnResExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sText = string.Empty;


                sText = this.Text + " - " + lisGroupList2.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisResGrpRel2, sText, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            if (tabResGroup.SelectedIndex == 0)
            {
                MPCF.FindListItemPartial(lisResList1, txtFind.Text, 0, true, false);
            }
            else
            {
                MPCF.FindListItemPartial(lisGroupList2, txtFind.Text, 0, true, false);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (tabResGroup.SelectedIndex == 0)
            {
                MPCF.ExportToExcel(lisResList1, this.Text, "");
            }
            else
            {
                MPCF.ExportToExcel(lisGroupList2, this.Text, "");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            try
            {
                lblDataCount.Text = "";

                if (tabResGroup.SelectedIndex == 0)
                {
                    if (RASLIST.ViewResourceList(lisResList1, "", cdvType.Text, false) == false) return;
                    lblDataCount.Text = lisResList1.Items.Count.ToString();
                    if (lisResList1.Items.Count > 0)
                        lisResList1.Items[0].Selected = true;
                }
                else
                {
                    if (RASLIST.ViewResourceGroupList(lisGroupList2, '1') == false) return;
                    lblDataCount.Text = lisGroupList2.Items.Count.ToString();
                    if (lisGroupList2.Items.Count > 0)
                        lisGroupList2.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabResGroup.SelectedIndex == 0)
            {
                MPCF.FindListItemNextPartial(lisResList1, txtFind.Text, true, false);
            }
            else
            {
                MPCF.FindListItemNextPartial(lisGroupList2, txtFind.Text, true, false);
            }
            
        }

        private void tabResGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabResGroup.SelectedIndex == 0)
            {
                lblDataCount.Text = lisResList1.Items.Count.ToString();
            }
            else
            {
                lblDataCount.Text = lisGroupList2.Items.Count.ToString();
            }
        }
    }
    
}
