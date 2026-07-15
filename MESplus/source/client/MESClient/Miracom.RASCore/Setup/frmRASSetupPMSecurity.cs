
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
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupPMSecurity.vb
//   Description : PM Security Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//       - Update_PM_Security() : Create/Update/Delete PM Security
//       - CheckCondition()      : Check the conditions before transaction
//       - SelectClear()         : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-11 : Created by SK Jin
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASSetupPMSecurity : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupPMSecurity()
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
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.Panel pnlRelatedRes;
        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Splitter splRes;
        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtResid;
        private System.Windows.Forms.Panel pnlResTop;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Panel pnlUserTop;
        private Miracom.UI.Controls.MCListView.MCListView lisUser;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.TabControl tabResUser;
        private System.Windows.Forms.Splitter splUser;
        private System.Windows.Forms.TextBox txtUserDesc;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TabControl tabResource;
        private System.Windows.Forms.TabPage tbpAttachUser;
        private System.Windows.Forms.TabPage tbpUserPrivilege;
        private System.Windows.Forms.Panel pnlResMid;
        private System.Windows.Forms.Panel pnlResMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.Label lblResList;
        private System.Windows.Forms.Panel pnlResMidMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlResMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisRelatedResource;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.Panel pnlUserMid;
        private System.Windows.Forms.Panel pnlUserMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisUserlist;
        private System.Windows.Forms.Label lblUserList;
        private System.Windows.Forms.Panel pnlUserMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlUserMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisRelatedUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private FarPoint.Win.Spread.FpSpread spdResource;
        private FarPoint.Win.Spread.SheetView spdResource_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdUser;
        private FarPoint.Win.Spread.SheetView spdUser_Sheet1;
        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tbpAttachResource;
        private System.Windows.Forms.TabPage tbpResourcePrivilege;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabResUser = new System.Windows.Forms.TabControl();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpAttachUser = new System.Windows.Forms.TabPage();
            this.pnlUserMid = new System.Windows.Forms.Panel();
            this.pnlUserMidRight = new System.Windows.Forms.Panel();
            this.lisUserlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUserList = new System.Windows.Forms.Label();
            this.pnlUserMidMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlUserMidLeft = new System.Windows.Forms.Panel();
            this.lisRelatedUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUser = new System.Windows.Forms.Label();
            this.tbpUserPrivilege = new System.Windows.Forms.TabPage();
            this.spdUser = new FarPoint.Win.Spread.FpSpread();
            this.spdUser_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUserTop = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtResid = new System.Windows.Forms.TextBox();
            this.splUser = new System.Windows.Forms.Splitter();
            this.pnlResource = new System.Windows.Forms.Panel();
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.pnlRes = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tbpAttachResource = new System.Windows.Forms.TabPage();
            this.pnlResMid = new System.Windows.Forms.Panel();
            this.pnlResMidRight = new System.Windows.Forms.Panel();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResList = new System.Windows.Forms.Label();
            this.pnlResMidMid = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlResMidLeft = new System.Windows.Forms.Panel();
            this.lisRelatedResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRes = new System.Windows.Forms.Label();
            this.tbpResourcePrivilege = new System.Windows.Forms.TabPage();
            this.spdResource = new FarPoint.Win.Spread.FpSpread();
            this.spdResource_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlResTop = new System.Windows.Forms.Panel();
            this.txtUserDesc = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.splRes = new System.Windows.Forms.Splitter();
            this.pnlRelatedRes = new System.Windows.Forms.Panel();
            this.lisUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabResUser.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.tabResource.SuspendLayout();
            this.tbpAttachUser.SuspendLayout();
            this.pnlUserMid.SuspendLayout();
            this.pnlUserMidRight.SuspendLayout();
            this.pnlUserMidMid.SuspendLayout();
            this.pnlUserMidLeft.SuspendLayout();
            this.tbpUserPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUser_Sheet1)).BeginInit();
            this.pnlUserTop.SuspendLayout();
            this.pnlResource.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.tbpUser.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.grpRes.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tbpAttachResource.SuspendLayout();
            this.pnlResMid.SuspendLayout();
            this.pnlResMidRight.SuspendLayout();
            this.pnlResMidMid.SuspendLayout();
            this.pnlResMidLeft.SuspendLayout();
            this.tbpResourcePrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResource_Sheet1)).BeginInit();
            this.pnlResTop.SuspendLayout();
            this.pnlRelatedRes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(559, 8);
            this.btnProcess.Text = "Update";
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(651, 8);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "PM Security Setup";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabResUser);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTab.Size = new System.Drawing.Size(742, 506);
            this.pnlTab.TabIndex = 0;
            // 
            // tabResUser
            // 
            this.tabResUser.Controls.Add(this.tbpResource);
            this.tabResUser.Controls.Add(this.tbpUser);
            this.tabResUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResUser.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResUser.Location = new System.Drawing.Point(5, 5);
            this.tabResUser.Name = "tabResUser";
            this.tabResUser.SelectedIndex = 0;
            this.tabResUser.Size = new System.Drawing.Size(732, 496);
            this.tabResUser.TabIndex = 0;
            this.tabResUser.TabStop = false;
            this.tabResUser.SelectedIndexChanged += new System.EventHandler(this.tabResUser_SelectedIndexChanged);
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.pnlUser);
            this.tbpResource.Controls.Add(this.splUser);
            this.tbpResource.Controls.Add(this.pnlResource);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(724, 470);
            this.tbpResource.TabIndex = 0;
            this.tbpResource.Text = "Resource";
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.grpUser);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUser.Location = new System.Drawing.Point(230, 3);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(491, 464);
            this.pnlUser.TabIndex = 2;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.tabResource);
            this.grpUser.Controls.Add(this.pnlUserTop);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(491, 464);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            // 
            // tabResource
            // 
            this.tabResource.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabResource.Controls.Add(this.tbpAttachUser);
            this.tabResource.Controls.Add(this.tbpUserPrivilege);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.Location = new System.Drawing.Point(3, 46);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(485, 415);
            this.tabResource.TabIndex = 2;
            this.tabResource.SelectedIndexChanged += new System.EventHandler(this.tabResource_SelectedIndexChanged);
            // 
            // tbpAttachUser
            // 
            this.tbpAttachUser.Controls.Add(this.pnlUserMid);
            this.tbpAttachUser.Location = new System.Drawing.Point(4, 25);
            this.tbpAttachUser.Name = "tbpAttachUser";
            this.tbpAttachUser.Size = new System.Drawing.Size(477, 386);
            this.tbpAttachUser.TabIndex = 0;
            this.tbpAttachUser.Text = "Attach User ";
            // 
            // pnlUserMid
            // 
            this.pnlUserMid.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUserMid.Controls.Add(this.pnlUserMidRight);
            this.pnlUserMid.Controls.Add(this.pnlUserMidMid);
            this.pnlUserMid.Controls.Add(this.pnlUserMidLeft);
            this.pnlUserMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserMid.Location = new System.Drawing.Point(0, 0);
            this.pnlUserMid.Name = "pnlUserMid";
            this.pnlUserMid.Size = new System.Drawing.Size(477, 386);
            this.pnlUserMid.TabIndex = 3;
            this.pnlUserMid.Resize += new System.EventHandler(this.pnlUserMid_Resize);
            // 
            // pnlUserMidRight
            // 
            this.pnlUserMidRight.Controls.Add(this.lisUserlist);
            this.pnlUserMidRight.Controls.Add(this.lblUserList);
            this.pnlUserMidRight.Location = new System.Drawing.Point(257, 0);
            this.pnlUserMidRight.Name = "pnlUserMidRight";
            this.pnlUserMidRight.Size = new System.Drawing.Size(220, 393);
            this.pnlUserMidRight.TabIndex = 18;
            // 
            // lisUserlist
            // 
            this.lisUserlist.AllowDrop = true;
            this.lisUserlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisUserlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUserlist.EnableSort = true;
            this.lisUserlist.EnableSortIcon = true;
            this.lisUserlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUserlist.FullRowSelect = true;
            this.lisUserlist.Location = new System.Drawing.Point(0, 14);
            this.lisUserlist.Name = "lisUserlist";
            this.lisUserlist.Size = new System.Drawing.Size(220, 379);
            this.lisUserlist.TabIndex = 1;
            this.lisUserlist.UseCompatibleStateImageBehavior = false;
            this.lisUserlist.View = System.Windows.Forms.View.Details;
            this.lisUserlist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisUserlist_ColumnClick);
            this.lisUserlist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisUserList_ItemDrag);
            this.lisUserlist.Click += new System.EventHandler(this.lisUserList_Click);
            this.lisUserlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisUserList_DragDrop);
            this.lisUserlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisUserList_DragEnter);
            this.lisUserlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisUserList_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "User";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // lblUserList
            // 
            this.lblUserList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserList.Location = new System.Drawing.Point(0, 0);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(220, 14);
            this.lblUserList.TabIndex = 0;
            this.lblUserList.Text = "All User List";
            // 
            // pnlUserMidMid
            // 
            this.pnlUserMidMid.Controls.Add(this.btnDel);
            this.pnlUserMidMid.Controls.Add(this.btnAdd);
            this.pnlUserMidMid.Location = new System.Drawing.Point(222, 54);
            this.pnlUserMidMid.Name = "pnlUserMidMid";
            this.pnlUserMidMid.Size = new System.Drawing.Size(34, 126);
            this.pnlUserMidMid.TabIndex = 17;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(5, 66);
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
            this.btnAdd.Location = new System.Drawing.Point(5, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlUserMidLeft
            // 
            this.pnlUserMidLeft.Controls.Add(this.lisRelatedUser);
            this.pnlUserMidLeft.Controls.Add(this.lblUser);
            this.pnlUserMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlUserMidLeft.Name = "pnlUserMidLeft";
            this.pnlUserMidLeft.Size = new System.Drawing.Size(220, 393);
            this.pnlUserMidLeft.TabIndex = 16;
            // 
            // lisRelatedUser
            // 
            this.lisRelatedUser.AllowDrop = true;
            this.lisRelatedUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisRelatedUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRelatedUser.EnableSort = true;
            this.lisRelatedUser.EnableSortIcon = true;
            this.lisRelatedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRelatedUser.FullRowSelect = true;
            this.lisRelatedUser.Location = new System.Drawing.Point(0, 14);
            this.lisRelatedUser.Name = "lisRelatedUser";
            this.lisRelatedUser.Size = new System.Drawing.Size(220, 379);
            this.lisRelatedUser.TabIndex = 1;
            this.lisRelatedUser.UseCompatibleStateImageBehavior = false;
            this.lisRelatedUser.View = System.Windows.Forms.View.Details;
            this.lisRelatedUser.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisRelatedUser_ItemDrag);
            this.lisRelatedUser.Click += new System.EventHandler(this.lisRelatedUser_Click);
            this.lisRelatedUser.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisRelatedUser_DragDrop);
            this.lisRelatedUser.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisRelatedUser_DragEnter);
            this.lisRelatedUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisRelatedUser_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "User";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Description";
            this.ColumnHeader14.Width = 150;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(0, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(220, 14);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "PM Security";
            // 
            // tbpUserPrivilege
            // 
            this.tbpUserPrivilege.Controls.Add(this.spdUser);
            this.tbpUserPrivilege.Location = new System.Drawing.Point(4, 25);
            this.tbpUserPrivilege.Name = "tbpUserPrivilege";
            this.tbpUserPrivilege.Size = new System.Drawing.Size(477, 386);
            this.tbpUserPrivilege.TabIndex = 1;
            this.tbpUserPrivilege.Text = "Privilege ";
            // 
            // spdUser
            // 
            this.spdUser.AccessibleDescription = "spdUser, Sheet1, Row 0, Column 0, ";
            this.spdUser.BackColor = System.Drawing.SystemColors.Control;
            this.spdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdUser.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdUser.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUser.HorizontalScrollBar.Name = "";
            this.spdUser.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdUser.HorizontalScrollBar.TabIndex = 2;
            this.spdUser.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUser.Location = new System.Drawing.Point(0, 0);
            this.spdUser.Name = "spdUser";
            this.spdUser.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUser_Sheet1});
            this.spdUser.Size = new System.Drawing.Size(477, 386);
            this.spdUser.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUser.TabIndex = 3;
            this.spdUser.TabStop = false;
            this.spdUser.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUser.VerticalScrollBar.Name = "";
            this.spdUser.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdUser.VerticalScrollBar.TabIndex = 3;
            this.spdUser.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdUser_Sheet1
            // 
            this.spdUser_Sheet1.Reset();
            spdUser_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUser_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUser_Sheet1.ColumnCount = 5;
            spdUser_Sheet1.RowCount = 1;
            spdUser_Sheet1.RowHeader.ColumnCount = 0;
            this.spdUser_Sheet1.Cells.Get(0, 3).CellType = checkBoxCellType1;
            this.spdUser_Sheet1.Cells.Get(0, 4).CellType = checkBoxCellType2;
            this.spdUser_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUser_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUser_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUser_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "User";
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "PM Planner";
            this.spdUser_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "PM Actor";
            this.spdUser_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUser_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUser_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
            this.spdUser_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdUser_Sheet1.Columns.Get(0).Width = 41F;
            this.spdUser_Sheet1.Columns.Get(1).Label = "User";
            this.spdUser_Sheet1.Columns.Get(1).Locked = true;
            this.spdUser_Sheet1.Columns.Get(1).Width = 84F;
            this.spdUser_Sheet1.Columns.Get(2).Label = "Description";
            this.spdUser_Sheet1.Columns.Get(2).Locked = true;
            this.spdUser_Sheet1.Columns.Get(2).Width = 198F;
            checkBoxCellType4.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdUser_Sheet1.Columns.Get(3).CellType = checkBoxCellType4;
            this.spdUser_Sheet1.Columns.Get(3).Label = "PM Planner";
            this.spdUser_Sheet1.Columns.Get(3).Width = 73F;
            this.spdUser_Sheet1.Columns.Get(4).CellType = checkBoxCellType5;
            this.spdUser_Sheet1.Columns.Get(4).Label = "PM Actor";
            this.spdUser_Sheet1.Columns.Get(4).Width = 67F;
            this.spdUser_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUser_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUser_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUser_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUser_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUser_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUser_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUserTop
            // 
            this.pnlUserTop.Controls.Add(this.txtDesc);
            this.pnlUserTop.Controls.Add(this.txtResid);
            this.pnlUserTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserTop.Location = new System.Drawing.Point(3, 16);
            this.pnlUserTop.Name = "pnlUserTop";
            this.pnlUserTop.Size = new System.Drawing.Size(485, 30);
            this.pnlUserTop.TabIndex = 0;
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
            this.txtDesc.TabIndex = 12;
            this.txtDesc.TabStop = false;
            // 
            // txtResid
            // 
            this.txtResid.Location = new System.Drawing.Point(4, 0);
            this.txtResid.MaxLength = 20;
            this.txtResid.Name = "txtResid";
            this.txtResid.ReadOnly = true;
            this.txtResid.Size = new System.Drawing.Size(134, 20);
            this.txtResid.TabIndex = 11;
            this.txtResid.TabStop = false;
            // 
            // splUser
            // 
            this.splUser.Location = new System.Drawing.Point(227, 3);
            this.splUser.Name = "splUser";
            this.splUser.Size = new System.Drawing.Size(3, 464);
            this.splUser.TabIndex = 2;
            this.splUser.TabStop = false;
            // 
            // pnlResource
            // 
            this.pnlResource.Controls.Add(this.lisResource);
            this.pnlResource.Controls.Add(this.pnlType);
            this.pnlResource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResource.Location = new System.Drawing.Point(3, 3);
            this.pnlResource.Name = "pnlResource";
            this.pnlResource.Size = new System.Drawing.Size(224, 464);
            this.pnlResource.TabIndex = 1;
            // 
            // lisResource
            // 
            this.lisResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResource.EnableSort = true;
            this.lisResource.EnableSortIcon = true;
            this.lisResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResource.FullRowSelect = true;
            this.lisResource.Location = new System.Drawing.Point(0, 40);
            this.lisResource.MultiSelect = false;
            this.lisResource.Name = "lisResource";
            this.lisResource.Size = new System.Drawing.Size(224, 424);
            this.lisResource.TabIndex = 1;
            this.lisResource.UseCompatibleStateImageBehavior = false;
            this.lisResource.View = System.Windows.Forms.View.Details;
            this.lisResource.SelectedIndexChanged += new System.EventHandler(this.lisResource_SelectedIndexChanged);
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
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(4, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.pnlRes);
            this.tbpUser.Controls.Add(this.splRes);
            this.tbpUser.Controls.Add(this.pnlRelatedRes);
            this.tbpUser.Location = new System.Drawing.Point(4, 22);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUser.Size = new System.Drawing.Size(724, 470);
            this.tbpUser.TabIndex = 1;
            this.tbpUser.Text = "User";
            this.tbpUser.Visible = false;
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.grpRes);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRes.Location = new System.Drawing.Point(230, 3);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Size = new System.Drawing.Size(491, 464);
            this.pnlRes.TabIndex = 1;
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.tabUser);
            this.grpRes.Controls.Add(this.pnlResTop);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(0, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(491, 464);
            this.grpRes.TabIndex = 1;
            this.grpRes.TabStop = false;
            // 
            // tabUser
            // 
            this.tabUser.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabUser.Controls.Add(this.tbpAttachResource);
            this.tabUser.Controls.Add(this.tbpResourcePrivilege);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUser.Location = new System.Drawing.Point(3, 46);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(485, 415);
            this.tabUser.TabIndex = 3;
            this.tabUser.SelectedIndexChanged += new System.EventHandler(this.tabUser_SelectedIndexChanged);
            // 
            // tbpAttachResource
            // 
            this.tbpAttachResource.Controls.Add(this.pnlResMid);
            this.tbpAttachResource.Location = new System.Drawing.Point(4, 25);
            this.tbpAttachResource.Name = "tbpAttachResource";
            this.tbpAttachResource.Size = new System.Drawing.Size(477, 386);
            this.tbpAttachResource.TabIndex = 0;
            this.tbpAttachResource.Text = "Attach Resource ";
            // 
            // pnlResMid
            // 
            this.pnlResMid.Controls.Add(this.pnlResMidRight);
            this.pnlResMid.Controls.Add(this.pnlResMidMid);
            this.pnlResMid.Controls.Add(this.pnlResMidLeft);
            this.pnlResMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResMid.Location = new System.Drawing.Point(0, 0);
            this.pnlResMid.Name = "pnlResMid";
            this.pnlResMid.Size = new System.Drawing.Size(477, 386);
            this.pnlResMid.TabIndex = 2;
            this.pnlResMid.Resize += new System.EventHandler(this.pnlResMid_Resize);
            // 
            // pnlResMidRight
            // 
            this.pnlResMidRight.Controls.Add(this.lisResourceList);
            this.pnlResMidRight.Controls.Add(this.lblResList);
            this.pnlResMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResMidRight.Location = new System.Drawing.Point(257, 0);
            this.pnlResMidRight.Name = "pnlResMidRight";
            this.pnlResMidRight.Size = new System.Drawing.Size(220, 386);
            this.pnlResMidRight.TabIndex = 18;
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowDrop = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(0, 14);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(220, 372);
            this.lisResourceList.TabIndex = 1;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            this.lisResourceList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisResourceList_ColumnClick);
            this.lisResourceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisResourcelist_ItemDrag);
            this.lisResourceList.Click += new System.EventHandler(this.lisResourcelist_Click);
            this.lisResourceList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisResourcelist_DragDrop);
            this.lisResourceList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisResourcelist_DragEnter);
            this.lisResourceList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisResourcelist_MouseDown);
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
            this.lblResList.Size = new System.Drawing.Size(220, 14);
            this.lblResList.TabIndex = 0;
            this.lblResList.Text = "All Resource List";
            // 
            // pnlResMidMid
            // 
            this.pnlResMidMid.Controls.Add(this.btnDetach);
            this.pnlResMidMid.Controls.Add(this.btnAttach);
            this.pnlResMidMid.Location = new System.Drawing.Point(222, 54);
            this.pnlResMidMid.Name = "pnlResMidMid";
            this.pnlResMidMid.Size = new System.Drawing.Size(34, 126);
            this.pnlResMidMid.TabIndex = 17;
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(5, 66);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 1;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(5, 37);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlResMidLeft
            // 
            this.pnlResMidLeft.Controls.Add(this.lisRelatedResource);
            this.pnlResMidLeft.Controls.Add(this.lblRes);
            this.pnlResMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlResMidLeft.Name = "pnlResMidLeft";
            this.pnlResMidLeft.Size = new System.Drawing.Size(220, 386);
            this.pnlResMidLeft.TabIndex = 16;
            // 
            // lisRelatedResource
            // 
            this.lisRelatedResource.AllowDrop = true;
            this.lisRelatedResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisRelatedResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRelatedResource.EnableSort = true;
            this.lisRelatedResource.EnableSortIcon = true;
            this.lisRelatedResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRelatedResource.FullRowSelect = true;
            this.lisRelatedResource.Location = new System.Drawing.Point(0, 14);
            this.lisRelatedResource.Name = "lisRelatedResource";
            this.lisRelatedResource.Size = new System.Drawing.Size(220, 372);
            this.lisRelatedResource.TabIndex = 1;
            this.lisRelatedResource.UseCompatibleStateImageBehavior = false;
            this.lisRelatedResource.View = System.Windows.Forms.View.Details;
            this.lisRelatedResource.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisRelatedResource_ItemDrag);
            this.lisRelatedResource.Click += new System.EventHandler(this.lisRelatedResource_Click);
            this.lisRelatedResource.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisRelatedResource_DragDrop);
            this.lisRelatedResource.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisRelatedResource_DragEnter);
            this.lisRelatedResource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisRelatedResource_MouseDown);
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
            this.lblRes.TabIndex = 0;
            this.lblRes.Text = "PM Security";
            // 
            // tbpResourcePrivilege
            // 
            this.tbpResourcePrivilege.Controls.Add(this.spdResource);
            this.tbpResourcePrivilege.Location = new System.Drawing.Point(4, 25);
            this.tbpResourcePrivilege.Name = "tbpResourcePrivilege";
            this.tbpResourcePrivilege.Size = new System.Drawing.Size(477, 386);
            this.tbpResourcePrivilege.TabIndex = 1;
            this.tbpResourcePrivilege.Text = "Privilege ";
            this.tbpResourcePrivilege.Visible = false;
            // 
            // spdResource
            // 
            this.spdResource.AccessibleDescription = "spdResource, Sheet1, Row 0, Column 0, ";
            this.spdResource.BackColor = System.Drawing.SystemColors.Control;
            this.spdResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResource.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResource.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResource.HorizontalScrollBar.Name = "";
            this.spdResource.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdResource.HorizontalScrollBar.TabIndex = 2;
            this.spdResource.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResource.Location = new System.Drawing.Point(0, 0);
            this.spdResource.Name = "spdResource";
            this.spdResource.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResource_Sheet1});
            this.spdResource.Size = new System.Drawing.Size(477, 386);
            this.spdResource.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResource.TabIndex = 2;
            this.spdResource.TabStop = false;
            this.spdResource.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResource.VerticalScrollBar.Name = "";
            this.spdResource.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdResource.VerticalScrollBar.TabIndex = 3;
            this.spdResource.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdResource_Sheet1
            // 
            this.spdResource_Sheet1.Reset();
            spdResource_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResource_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResource_Sheet1.ColumnCount = 5;
            spdResource_Sheet1.RowCount = 1;
            spdResource_Sheet1.RowHeader.ColumnCount = 0;
            this.spdResource_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResource_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResource_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResource_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource";
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "PM Planner";
            this.spdResource_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "PM Actor";
            this.spdResource_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResource_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResource_Sheet1.Columns.Get(0).CellType = checkBoxCellType6;
            this.spdResource_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdResource_Sheet1.Columns.Get(0).Width = 37F;
            this.spdResource_Sheet1.Columns.Get(1).Label = "Resource";
            this.spdResource_Sheet1.Columns.Get(1).Locked = true;
            this.spdResource_Sheet1.Columns.Get(1).Width = 81F;
            this.spdResource_Sheet1.Columns.Get(2).Label = "Description";
            this.spdResource_Sheet1.Columns.Get(2).Locked = true;
            this.spdResource_Sheet1.Columns.Get(2).Width = 202F;
            this.spdResource_Sheet1.Columns.Get(3).CellType = checkBoxCellType7;
            this.spdResource_Sheet1.Columns.Get(3).Label = "PM Planner";
            this.spdResource_Sheet1.Columns.Get(3).Width = 65F;
            this.spdResource_Sheet1.Columns.Get(4).CellType = checkBoxCellType8;
            this.spdResource_Sheet1.Columns.Get(4).Label = "PM Actor";
            this.spdResource_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResource_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResource_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResource_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResource_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResource_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResource_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlResTop
            // 
            this.pnlResTop.Controls.Add(this.txtUserDesc);
            this.pnlResTop.Controls.Add(this.txtUser);
            this.pnlResTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResTop.Location = new System.Drawing.Point(3, 16);
            this.pnlResTop.Name = "pnlResTop";
            this.pnlResTop.Size = new System.Drawing.Size(485, 30);
            this.pnlResTop.TabIndex = 0;
            // 
            // txtUserDesc
            // 
            this.txtUserDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserDesc.Location = new System.Drawing.Point(142, 0);
            this.txtUserDesc.MaxLength = 200;
            this.txtUserDesc.Name = "txtUserDesc";
            this.txtUserDesc.ReadOnly = true;
            this.txtUserDesc.Size = new System.Drawing.Size(338, 20);
            this.txtUserDesc.TabIndex = 1;
            this.txtUserDesc.TabStop = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(4, 0);
            this.txtUser.MaxLength = 10;
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(134, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.TabStop = false;
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
            this.pnlRelatedRes.Controls.Add(this.lisUser);
            this.pnlRelatedRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRelatedRes.Location = new System.Drawing.Point(3, 3);
            this.pnlRelatedRes.Name = "pnlRelatedRes";
            this.pnlRelatedRes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlRelatedRes.Size = new System.Drawing.Size(224, 464);
            this.pnlRelatedRes.TabIndex = 0;
            // 
            // lisUser
            // 
            this.lisUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lisUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUser.EnableSort = true;
            this.lisUser.EnableSortIcon = true;
            this.lisUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUser.FullRowSelect = true;
            this.lisUser.Location = new System.Drawing.Point(0, 3);
            this.lisUser.MultiSelect = false;
            this.lisUser.Name = "lisUser";
            this.lisUser.Size = new System.Drawing.Size(224, 461);
            this.lisUser.TabIndex = 0;
            this.lisUser.UseCompatibleStateImageBehavior = false;
            this.lisUser.View = System.Windows.Forms.View.Details;
            this.lisUser.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisUser_ColumnClick);
            this.lisUser.SelectedIndexChanged += new System.EventHandler(this.lisUser_SelectedIndexChanged);
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "User";
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
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Operation";
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 150;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Operation";
            this.ColumnHeader3.Width = 100;
            // 
            // frmRASSetupPMSecurity
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmRASSetupPMSecurity";
            this.Text = "PM Security Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupPMSecurity_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupPMSecurity_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabResUser.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            this.tbpAttachUser.ResumeLayout(false);
            this.pnlUserMid.ResumeLayout(false);
            this.pnlUserMidRight.ResumeLayout(false);
            this.pnlUserMidMid.ResumeLayout(false);
            this.pnlUserMidLeft.ResumeLayout(false);
            this.tbpUserPrivilege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUser_Sheet1)).EndInit();
            this.pnlUserTop.ResumeLayout(false);
            this.pnlUserTop.PerformLayout();
            this.pnlResource.ResumeLayout(false);
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.tbpUser.ResumeLayout(false);
            this.pnlRes.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tbpAttachResource.ResumeLayout(false);
            this.pnlResMid.ResumeLayout(false);
            this.pnlResMidRight.ResumeLayout(false);
            this.pnlResMidMid.ResumeLayout(false);
            this.pnlResMidLeft.ResumeLayout(false);
            this.tbpResourcePrivilege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResource_Sheet1)).EndInit();
            this.pnlResTop.ResumeLayout(false);
            this.pnlResTop.PerformLayout();
            this.pnlRelatedRes.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        
        private const int CHECK_COL = 0;
        private const int ITEM_COL = 1;
        private const int DESC_COL = 2;
        private const int SCH_FLAG_COL = 3;
        private const int EVENT_FLAG_COL = 4;
        
        private const int MAX_DATA_CNT = 1000;
        
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
        private object SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
            return null;
        }
        
        // AddSheetData()
        //       - Add Data to FpSpread Control
        // Return Value
        //       -
        // Arguments
        //       - ByVal sValue1 as string : Value of Column Index=1
        //       - ByVal sValue2 as string : Value of Column Index=2
        //       - Optional ByVal sValue3 as string = "Y" : Value of Column Index=3
        //       - Optional ByVal sValue4 as string = "Y" : Value of Column Index=4
        //
        private void AddSheetData(FpSpread spdCtl, string sValue1, string sValue2, string sValue3, string sValue4)
        {
            
            spdCtl.ActiveSheet.RowCount++;
            spdCtl.ActiveSheet.SetValue(spdCtl.ActiveSheet.RowCount - 1, 1, MPCF.Trim(sValue1));
            spdCtl.ActiveSheet.SetValue(spdCtl.ActiveSheet.RowCount - 1, 2, MPCF.Trim(sValue2));
            spdCtl.ActiveSheet.SetValue(spdCtl.ActiveSheet.RowCount - 1, 3, ((sValue3 == "Y") ? true : false));
            spdCtl.ActiveSheet.SetValue(spdCtl.ActiveSheet.RowCount - 1, 4, ((sValue4 == "Y") ? true : false));
        }
        
        // DeleteSheetData()
        //       - Delete Data to FpSpread Control
        // Return Value
        //       -
        // Arguments
        //       - ByVal sValue1 as string : Value of Column Index=1
        //
        private void DeleteSheetData(FpSpread spdCtl, string sValue1)
        {
            
            int i = 0;
            object tmpValue = null;
            
            try
            {
                for (i = 0; i <= spdCtl.ActiveSheet.RowCount - 1; i++)
                {
                    tmpValue = spdCtl.ActiveSheet.GetValue(i, 1);
                    if (MPCF.Trim(tmpValue) == MPCF.Trim(sValue1))
                    {
                        spdCtl.ActiveSheet.RemoveRows(i, 1);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            
        }
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            int i = 0;
            int iChkCnt = 0;

            switch (MPCF.Trim(FuncName))
            {
                case "ATTACH_USER":
                    
                    if (lisResource.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisResource.Items.Count > 0)
                        {
                            lisResource.Items[0].Selected = true;
                            lisResource.Focus();
                        }
                        return false;
                    }
                    if (lisUserlist.SelectedItems.Count <= 0)
                    {
                        if (lisUserlist.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisUserlist.Items[0].Selected = true;
                            lisUserlist.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_USER":
                    
                    if (lisResource.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisResource.Items.Count > 0)
                        {
                            lisResource.Items[0].Selected = true;
                            lisResource.Focus();
                        }
                        return false;
                    }
                    if (lisRelatedUser.SelectedItems.Count <= 0)
                    {
                        if (lisRelatedUser.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisRelatedUser.Items[0].Selected = true;
                            lisRelatedUser.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_RES":
                    
                    if (lisUser.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisUser.Items.Count > 0)
                        {
                            lisUser.Items[0].Selected = true;
                            lisUser.Focus();
                        }
                        return false;
                    }
                    if (lisResourceList.SelectedItems.Count <= 0)
                    {
                        if (lisResourceList.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResourceList.Items[0].Selected = true;
                            lisResourceList.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_RES":
                    
                    if (lisUser.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisUser.Items.Count > 0)
                        {
                            lisUser.Items[0].Selected = true;
                            lisUser.Focus();
                        }
                        return false;
                    }
                    if (lisRelatedResource.SelectedItems.Count <= 0)
                    {
                        if (lisRelatedResource.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisRelatedResource.Items[0].Selected = true;
                            lisRelatedResource.Focus();
                        }
                        return false;
                    }
                    break;
                case "UPDATE_PM_SEC_LIST":
                    
                    if (tabResUser.SelectedTab == tbpResource)
                    {
                        if (lisResource.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisResource.Items.Count > 0)
                            {
                                lisResource.Items[0].Selected = true;
                                lisResource.Focus();
                            }
                            return false;
                        }
                        for (i = 0; i <= spdUser.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdUser.Sheets[0].GetValue(i, CHECK_COL) != null && Convert.ToBoolean(spdUser.Sheets[0].GetValue(i, CHECK_COL)) == true)
                            {
                                iChkCnt++;
                            }
                        }
                        
                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(133));
                            spdUser.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_DATA_CNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdUser.Select();
                            return false;
                        }
                    }
                    else if (tabResUser.SelectedTab == tbpUser)
                    {
                        if (lisUser.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisUser.Items.Count > 0)
                            {
                                lisUser.Items[0].Selected = true;
                                lisUser.Focus();
                            }
                            return false;
                        }
                        for (i = 0; i <= spdResource.Sheets[0].RowCount - 1; i++)
                        {
                            if (spdResource.Sheets[0].GetValue(i, CHECK_COL) != null && Convert.ToBoolean(spdResource.Sheets[0].GetValue(i, CHECK_COL)) == true)
                            {
                                iChkCnt++;
                            }
                        }
                        
                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(133));
                            spdResource.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_DATA_CNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdResource.Select();
                            return false;
                        }
                    }
                    break;
                    
            }
            
            return true;
        }
        
        // Update_PM_Security()
        //       - Create/Update/Delete PM Security
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String          :  ?•ìž¥ Process Step
        //       - ByVal sUser As String          :  Operation
        //       - ByVal sRes As String           :  Resource ID
        //
        private bool Update_PM_Security(char c_step, string sUser, string sRes, string sScheduleEnableFlag, string sEventEnableFlag)
        {
            TRSNode in_node = new TRSNode("Update_PM_Sec_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
              
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("USER_ID", sUser, true);
                in_node.AddString("RES_ID", sRes);
                in_node.AddChar("SCHEDULE_ENABLE_FLAG", MPCF.ToChar(sScheduleEnableFlag));
                in_node.AddChar("EVENT_ENABLE_FLAG", MPCF.ToChar(sEventEnableFlag));

                if (MPCR.CallService("RAS", "RAS_Update_PM_Security", in_node, ref out_node) == false)
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
        
        // Update_PM_Security_List()
        //       - Create/Update/Delete PM Security
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String          :  ?•ìž¥ Process Step
        //       - ByVal sUser As String          :  Operation
        //       - ByVal sRes As String           :  Resource ID
        //
        private bool Update_PM_Security_List(char c_step)
        {
            TRSNode in_node = new TRSNode("UPdate_PM_Sec_List_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
              
            int i;
            string sRes;
            string sUser;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddChar("OPT", 'F');

                if (tabResUser.SelectedTab == tbpResource)
                {
                    sRes = lisResource.SelectedItems[0].Text;
                    for (i = 0; i <= spdUser.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdUser.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdUser.Sheets[0].GetValue(i, 0)) == true)
                        {
                            TRSNode list = in_node.AddNode("PM_LIST");
                            list.AddString("USER_ID", MPCF.Trim(spdUser.Sheets[0].GetValue(i, 1)), true);
                            list.AddString("RES_ID", sRes);

                            if (spdUser.Sheets[0].GetValue(i, 3) != null)
                                list.AddChar("SCHEDULE_ENABLE_FLAG", (Convert.ToBoolean(spdUser.Sheets[0].GetValue(i, 3)) == true) ? 'Y' : ' ');

                            if (spdUser.Sheets[0].GetValue(i, 4) != null)
                                list.AddChar("EVENT_ENABLE_FLAG",  (Convert.ToBoolean(spdUser.Sheets[0].GetValue(i, 4)) == true) ? 'Y' : ' ');
                        }
                    }
                    
                }
                else if (tabResUser.SelectedTab == tbpUser)
                {
                    sUser = lisUser.SelectedItems[0].Text;
                    for (i = 0; i <= spdResource.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdResource.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdResource.Sheets[0].GetValue(i, 0)) == true)
                        {
                            TRSNode list = in_node.AddNode("PM_LIST");
                            list.AddString("USER_ID", sUser, true);
                            list.AddString("RES_ID", MPCF.Trim(spdResource.Sheets[0].GetValue(i, 1)));

                            if (spdResource.Sheets[0].GetValue(i, 3) != null)
                                list.AddChar("SCHEDULE_ENABLE_FLAG", (Convert.ToBoolean(spdResource.Sheets[0].GetValue(i, 3)) == true) ? 'Y' : ' ');

                            if (spdResource.Sheets[0].GetValue(i, 4) != null)
                                list.AddChar("EVENT_ENABLE_FLAG",  (Convert.ToBoolean(spdResource.Sheets[0].GetValue(i, 4)) == true) ? 'Y' : ' ');
                        }
                    }
                }

                if (MPCR.CallService("RAS", "RAS_Update_PM_Security_List", in_node, ref out_node) == false)
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
        
        //
        // View_PM_Security_List()
        //       - View PM Security List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdCtl As FpSpread                    : SpreadSheet Control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - ByVal sKey As String                        : Key ê°?(step='1' ?¼ê²½??Res_ID, step='2' ??ê²½ìš° User_ID)
        //
        public bool View_PM_Security_List(FpSpread spdCtl, char c_step, string sKey)
        {
            
            int i;

            TRSNode in_node = new TRSNode("View_PM_Sec_List_In");
            TRSNode out_node ;
              
            try
            {
                
                MPCF.ClearList(spdCtl);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                
                if (c_step == '1')
                {
                    in_node.AddString("NEXT_RES_ID", sKey);
                }
                else if (c_step == '2')
                {
                    in_node.AddString("NEXT_USER_ID", sKey, true);
                }
                
                do
                {
                    out_node = new TRSNode("View_PM_Sec_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_PM_Security_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (c_step == '1')
                        {
                            AddSheetData(spdCtl, out_node.GetList(0)[i].GetString("USER_ID"), out_node.GetList(0)[i].GetString("USER_DESC"), out_node.GetList(0)[i].GetChar("SCHEDULE_ENABLE_FLAG").ToString(), out_node.GetList(0)[i].GetChar("EVENT_ENABLE_FLAG").ToString());
                        }
                        else if (c_step == '2')
                        {
                            AddSheetData(spdCtl, out_node.GetList(0)[i].GetString("RES_ID"), out_node.GetList(0)[i].GetString("RES_DESC"), out_node.GetList(0)[i].GetChar("SCHEDULE_ENABLE_FLAG").ToString(), out_node.GetList(0)[i].GetChar("EVENT_ENABLE_FLAG").ToString());
                        }
                    }
                    in_node.SetString("NEXT_USER_ID", out_node.GetString("NEXT_USER_ID"), true);
                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));

                } while (in_node.GetString("NEXT_USER_ID") != "" && 
                         in_node.GetString("NEXT_RES_ID") != "") ;
                
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
                return this.tabResUser;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupPMSecurity_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    pnlUserMid_Resize(null, null);
                    pnlResMid_Resize(null, null);
                    
                    lisResource.Focus();
                    if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == false)
                    {
                        return;
                    }
                    else
                    {
                        if (lisResource.Items.Count > 0)
                        {
                            lisResource.Items[0].Selected = true;
                        }
                    }

                    if (RASLIST.ViewResourceList(lisResourceList, false) == false)
                    {
                        return;
                    }
                    if (SECLIST.ViewSECUserList(lisUser, '1', -1, null, "", "") == false)
                    {
                        return;
                    }
                    else
                    {
                        if (lisUser.Items.Count > 0)
                        {
                            lisUser.Items[0].Selected = true;
                        }
                    }
                    if (SECLIST.ViewSECUserList(lisUserlist, '1', -1, null, "", "") == false)
                    {
                        return;
                    }
                    btnProcess.Visible = false;
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
        
        private void frmRASSetupPMSecurity_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitListView(cdvType.GetListView);
                MPCF.InitListView(lisResource);
                MPCF.InitListView(lisRelatedResource);
                MPCF.InitListView(lisResourceList);
                MPCF.InitListView(lisUser);
                MPCF.InitListView(lisRelatedUser);
                MPCF.InitListView(lisUserlist);
                MPCF.ClearList(spdUser, true);
                MPCF.ClearList(spdResource, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                
            }
        }
        
        private void lisResource_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisRelatedUser, true);
            MPCF.ClearList(spdUser, true);
            MPCF.FieldClear(grpUser);
            if (lisResource.SelectedItems.Count > 0)
            {
                txtResid.Text = lisResource.SelectedItems[0].Text;
                txtDesc.Text = lisResource.SelectedItems[0].SubItems[1].Text;
                if (RASLIST.ViewPMSecurityList(lisRelatedUser, '1', lisResource.SelectedItems[0].Text, "") == true)
                {
                    View_PM_Security_List(spdUser, '1', lisResource.SelectedItems[0].Text);
                }
            }
        }
        
        private void lisUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisRelatedResource, true);
            MPCF.ClearList(spdResource, true);
            MPCF.FieldClear(grpRes);
            if (lisUser.SelectedItems.Count > 0)
            {
                txtUser.Text = lisUser.SelectedItems[0].Text;
                txtUserDesc.Text = lisUser.SelectedItems[0].SubItems[1].Text;
                if (RASLIST.ViewPMSecurityList(lisRelatedResource, '2', lisUser.SelectedItems[0].Text, "") == true)
                {
                    View_PM_Security_List(spdResource, '2', lisUser.SelectedItems[0].Text);
                }
            }
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            ListViewItem itmX;
            string[] sSelect = null;
            int iIdx = 0;
            int i;
            
            sSelect = new string[lisUserlist.SelectedItems.Count];
            SelectClear(lisRelatedUser);
            if (CheckCondition("ATTACH_USER", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            for (i = 0; i <= lisUserlist.SelectedItems.Count - 1; i++)
            {
                sUser = lisUserlist.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisRelatedUser, sUser, false) == false)
                {
                    if (Update_PM_Security(MPGC.MP_STEP_CREATE, sUser, sRes, "Y", "Y") == true)
                    {
                        sSelect[i] = sUser;
                        itmX = lisRelatedUser.Items.Add(sUser, (int)SMALLICON_INDEX.IDX_USER);
                        itmX.SubItems.Add(lisUserlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisUserlist.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedUser.Sorting = SortOrder.Ascending;
                        lisRelatedUser.Sort();
                        
                        AddSheetData(spdUser, sUser, lisUserlist.SelectedItems[i].SubItems[1].Text, "Y", "Y");
                        spdUser.Sheets[0].SortRows(1, true, false);
                        
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedUser, sSelect[j])
                        //Next
                        SelectClear(lisUserlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sUser;
                    iIdx = lisUserlist.SelectedItems[i].Index;
                }
            }
            //If ViewPMSecurityList(lisRelatedUser, '1', lisResource.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisUserlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisUserlist.Items.Count - 1)
                {
                    lisUserlist.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedUser, sSelect[i])
            //Next
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_USER", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            iCount = lisRelatedUser.SelectedItems.Count;
            SelectClear(lisUserlist);
            for (i = lisRelatedUser.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisRelatedUser.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                
                if (Update_PM_Security(MPGC.MP_STEP_DELETE, sUser, sRes, " ", " ") == true)
                {
                    iIdx = lisRelatedUser.SelectedItems[i].Index;
                    lisRelatedUser.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisUserlist, sUser, false);
                    DeleteSheetData(     spdUser, sUser);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedUser.Items.Count)
                {
                    lisRelatedUser.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int iIdx = 0;
            
            sSelect = new string[lisResourceList.SelectedItems.Count];
            SelectClear(lisRelatedResource);
            if (CheckCondition("ATTACH_RES", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            for (i = 0; i <= lisResourceList.SelectedItems.Count - 1; i++)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisResourceList.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRelatedResource, sRes, false) == false)
                {
                    if (Update_PM_Security(MPGC.MP_STEP_CREATE, sUser, sRes, "Y", "Y") == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRelatedResource.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itmX.SubItems.Add(lisResourceList.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisResourceList.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedResource.Sorting = SortOrder.Ascending;
                        lisRelatedResource.Sort();
                        
                        AddSheetData(spdResource, sRes, lisResourceList.SelectedItems[i].SubItems[1].Text, "Y", "Y");
                        spdResource.Sheets[0].SortRows(1, true, false);
                        
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedResource, sSelect[j])
                        //Next
                        SelectClear(lisResourceList);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisResourceList.SelectedItems[i].Index;
                }
            }
            //If ViewPMSecurityList(lisRelatedResource, "2", lisUser.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisResourceList);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisResourceList.Items.Count - 1)
                {
                    lisResourceList.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedResource, sSelect[i])
            //Next
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            iCount = lisRelatedResource.SelectedItems.Count;
            SelectClear(lisResourceList);
            for (i = lisRelatedResource.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisRelatedResource.SelectedItems[i].Text;
                
                if (Update_PM_Security(MPGC.MP_STEP_DELETE, sUser, sRes, " ", " ") == true)
                {
                    iIdx = lisRelatedResource.SelectedItems[i].Index;
                    lisRelatedResource.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisResourceList, sRes, false);
                    DeleteSheetData(     spdResource, sRes);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedResource.Items.Count)
                {
                    lisRelatedResource.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
            {
                if (lisResource.Items.Count > 0)
                {
                    lisResource.Items[0].Selected = true;
                }
                else
                {
                    MPCF.ClearList(lisRelatedUser, true);
                    MPCF.ClearList(spdUser, true);
                    txtResid.Text = "";
                    txtDesc.Text = "";
                }
            }
        }
        
        private void pnlUserMid_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlUserMid, pnlUserMidLeft, pnlUserMidRight, pnlUserMidMid, 40);
        }
        
        private void pnlResMid_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlResMid, pnlResMidLeft, pnlResMidRight, pnlResMidMid, 40);
        }
        
        private void lisRelatedUser_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisRelatedUser_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            ListViewItem itmX;
            string[] sSelect = null;
            int i;
            int iIdx = 0;
            
            sSelect = new string[lisUserlist.SelectedItems.Count];
            SelectClear(lisRelatedUser);
            if (CheckCondition("ATTACH_USER", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            for (i = 0; i <= lisUserlist.SelectedItems.Count - 1; i++)
            {
                sUser = lisUserlist.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisRelatedUser, sUser, false) == false)
                {
                    if (Update_PM_Security(MPGC.MP_STEP_CREATE, sUser, sRes, "Y", "Y") == true)
                    {
                        sSelect[i] = sUser;
                        itmX = lisRelatedUser.Items.Add(sUser, (int)SMALLICON_INDEX.IDX_USER);
                        itmX.SubItems.Add(lisUserlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisUserlist.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedUser.Sorting = SortOrder.Ascending;
                        lisRelatedUser.Sort();
                        
                        AddSheetData(spdUser, sUser, lisUserlist.SelectedItems[i].SubItems[1].Text, "Y", "Y");
                        spdUser.Sheets[0].SortRows(1, true, false);
                        
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedUser, sSelect[j])
                        //Next
                        SelectClear(lisUserlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sUser;
                    iIdx = lisUserlist.SelectedItems[i].Index;
                }
                
            }
            //If ViewPMSecurityList(lisRelatedUser, '1', lisResource.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisUserlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisUserlist.Items.Count - 1)
                {
                    lisUserlist.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedUser, sSelect[i])
            //Next
        }
        
        private void lisUserList_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisUserlist.DoDragDrop(lisUserlist.SelectedItems[0].Text, DragDropEffects.Copy);
        }
        
        private void lisRelatedResource_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisRelatedResource_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int iIdx = 0;
            
            sSelect = new string[lisResourceList.SelectedItems.Count];
            SelectClear(lisRelatedResource);
            if (CheckCondition("ATTACH_RES", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            for (i = 0; i <= lisResourceList.SelectedItems.Count - 1; i++)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisResourceList.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRelatedResource, sRes, false) == false)
                {
                    if (Update_PM_Security(MPGC.MP_STEP_CREATE, sUser, sRes, "Y", "Y") == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRelatedResource.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itmX.SubItems.Add(lisResourceList.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisResourceList.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedResource.Sorting = SortOrder.Ascending;
                        lisRelatedResource.Sort();
                        
                        AddSheetData(spdResource, sRes, lisResourceList.SelectedItems[i].SubItems[1].Text, "Y", "Y");
                        spdResource.Sheets[0].SortRows(1, true, false);
                        
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedResource, sSelect[j])
                        //Next
                        SelectClear(lisResourceList);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisResourceList.SelectedItems[i].Index;
                }
            }
            //If ViewPMSecurityList(lisRelatedResource, "2", lisUser.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisResourceList);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisResourceList.Items.Count - 1)
                {
                    lisResourceList.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedResource, sSelect[i])
            //Next
        }
        
        private void lisResourcelist_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisResourceList.DoDragDrop(lisResourceList.SelectedItems[0].Text, DragDropEffects.Copy);
        }
        
        private void lisUserList_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisUserList_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_USER", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            iCount = lisRelatedUser.SelectedItems.Count;
            SelectClear(lisUserlist);
            for (i = lisRelatedUser.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisRelatedUser.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                
                if (Update_PM_Security(MPGC.MP_STEP_DELETE, sUser, sRes, " ", " ") == true)
                {
                    iIdx = lisRelatedUser.SelectedItems[i].Index;
                    lisRelatedUser.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisUserlist, sUser, false);
                    DeleteSheetData(     spdUser, sUser);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedUser.Items.Count)
                {
                    lisRelatedUser.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void lisRelatedUser_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisRelatedUser.DoDragDrop(lisRelatedUser.SelectedItems[0].Text, DragDropEffects.Move);
        }
        
        private void lisRelatedUser_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisRelatedUser.AllowDrop = false;
            lisUserlist.AllowDrop = true;
        }
        
        private void lisUserList_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisUserlist.AllowDrop = false;
            lisRelatedUser.AllowDrop = true;
        }
        
        private void lisResourcelist_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisResourcelist_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES", MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            iCount = lisRelatedResource.SelectedItems.Count;
            SelectClear(lisResourceList);
            for (i = lisRelatedResource.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisRelatedResource.SelectedItems[i].Text;
                
                if (Update_PM_Security(MPGC.MP_STEP_DELETE, sUser, sRes, " ", " ") == true)
                {
                    iIdx = lisRelatedResource.SelectedItems[i].Index;
                    lisRelatedResource.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisResourceList, sRes, false);
                    DeleteSheetData(     spdResource, sRes);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedResource.Items.Count)
                {
                    lisRelatedResource.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void lisRelatedResource_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisRelatedResource.DoDragDrop(lisRelatedResource.SelectedItems[0].Text, DragDropEffects.Move);
        }
        
        private void lisRelatedResource_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisRelatedResource.AllowDrop = false;
            lisResourceList.AllowDrop = true;
        }
        
        private void lisResourcelist_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisResourceList.AllowDrop = false;
            lisRelatedResource.AllowDrop = true;
        }
        
        private void lisResourcelist_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisRelatedResource);
        }
        
        private void lisUserList_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisRelatedUser);
        }
        
        private void lisRelatedResource_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisResourceList);
        }
        
        private void lisRelatedUser_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisUserlist);
        }
        
        //private void btnProcess_Click(System.Object sender, System.EventArgs e)
        //{
        //    if (CheckCondition("UPDATE_PM_SEC_LIST", MPGC.MP_STEP_CREATE) == true)
        //    {
        //        Update_PM_Security_List(MPGC.MP_STEP_UPDATE);
        //    }
        //}

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition("UPDATE_PM_SEC_LIST", MPGC.MP_STEP_CREATE) == true)
            {
                Update_PM_Security_List(MPGC.MP_STEP_UPDATE);
            }
        }

        private void tabResource_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (tabResource.SelectedTab == tbpAttachUser)
            {
                btnProcess.Visible = false;
            }
            else if (tabResource.SelectedTab == tbpUserPrivilege)
            {
                btnProcess.Visible = true;
            }
        }
        
        private void tabUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (tabUser.SelectedTab == tbpAttachResource)
            {
                btnProcess.Visible = false;
            }
            else if (tabUser.SelectedTab == tbpResourcePrivilege)
            {
                btnProcess.Visible = true;
            }
        }
        
        private void tabResUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (tabResUser.SelectedTab == tbpResource)
            {
                if (tabResource.SelectedTab == tbpAttachUser)
                {
                    btnProcess.Visible = false;
                }
                else if (tabResource.SelectedTab == tbpUserPrivilege)
                {
                    btnProcess.Visible = true;
                }
            }
            else if (tabResUser.SelectedTab == tbpUser)
            {
                if (tabUser.SelectedTab == tbpAttachResource)
                {
                    btnProcess.Visible = false;
                }
                else if (tabUser.SelectedTab == tbpResourcePrivilege)
                {
                    btnProcess.Visible = true;
                }
            }
        }
        
        private void lisUserlist_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewSECUserList(lisUserlist, "1") = False Then
            //    Exit Sub
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }
        
        private void lisResourceList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewResourceList(lisResourceList, "1") = False Then
            //    Exit Sub
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }
        
        private void lisUser_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewSECUserList(lisUser, "1") = False Then
            //    Exit Sub
            //End If
            //If lisUser.Items.Count > 0 Then
            //    lisUser.Items.Item(0).Selected = True
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }

        
    }
    
}
