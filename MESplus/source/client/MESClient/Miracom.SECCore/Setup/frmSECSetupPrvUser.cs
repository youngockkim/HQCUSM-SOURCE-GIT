
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSECSetupPrvUser.vb
//   Description : Privilege Group - User Relation Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//       - Update_Privilege_Group_User() : Create/Update/Delete Privilege Group - User Relation
//       - CheckCondition()      : Check the conditions before transaction
//       - SelectClear()         : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-04-22 : Created by SK Jin
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.SECCore
{
    public class frmSECSetupPrvUser : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmSECSetupPrvUser()
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
        private System.Windows.Forms.Panel pnlPrvGrpource;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlPrvGrpTop;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Panel pnlUserTop;
        private Miracom.UI.Controls.MCListView.MCListView lisUser;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Splitter splUser;
        private System.Windows.Forms.TextBox txtUserDesc;
        private System.Windows.Forms.TextBox txtUser;
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
        private System.Windows.Forms.Panel pnlPrvGrpMid;
        private System.Windows.Forms.Panel pnlPrvGrpMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisPrvGrpList;
        private System.Windows.Forms.Label lblPrvGrpList;
        private System.Windows.Forms.Panel pnlPrvGrpMidMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlPrvGrpMidLeft;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.TabControl tabPrvUser;
        private System.Windows.Forms.TabPage tbpPrvGrp;
        private System.Windows.Forms.GroupBox grpPrvGrp;
        private System.Windows.Forms.Label lblPrvGrp;
        private Miracom.UI.Controls.MCListView.MCListView lisRelatedPrvGrp;
        private Miracom.UI.Controls.MCListView.MCListView lisPrvGrp;
        private System.Windows.Forms.Panel pnlRelatedPrvGrp;
        private System.Windows.Forms.Panel pnlPrvGrp;
        private System.Windows.Forms.Splitter splPrvGrp;
        protected Button btnRefresh;
        protected Button btnUserRefresh;
        protected Button btnGroupRefresh;
        private Panel pnlUserLabel;
        private Panel pnlGroupLabel;
        private Panel pnlGrpLabel;
        protected Button btnGrpRefresh;
        private Panel pnlUsrLabel;
        protected Button btnUsrRefresh;
        private System.Windows.Forms.TextBox txtPrvGrp;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSECSetupPrvUser));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabPrvUser = new System.Windows.Forms.TabControl();
            this.tbpPrvGrp = new System.Windows.Forms.TabPage();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.pnlUserMid = new System.Windows.Forms.Panel();
            this.pnlUserMidRight = new System.Windows.Forms.Panel();
            this.lisUserlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUserLabel = new System.Windows.Forms.Panel();
            this.btnUserRefresh = new System.Windows.Forms.Button();
            this.lblUserList = new System.Windows.Forms.Label();
            this.pnlUserMidMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlUserMidLeft = new System.Windows.Forms.Panel();
            this.lisRelatedUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGroupLabel = new System.Windows.Forms.Panel();
            this.btnGroupRefresh = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlUserTop = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtPrvGrp = new System.Windows.Forms.TextBox();
            this.splUser = new System.Windows.Forms.Splitter();
            this.pnlPrvGrpource = new System.Windows.Forms.Panel();
            this.lisPrvGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.pnlPrvGrp = new System.Windows.Forms.Panel();
            this.grpPrvGrp = new System.Windows.Forms.GroupBox();
            this.pnlPrvGrpMid = new System.Windows.Forms.Panel();
            this.pnlPrvGrpMidRight = new System.Windows.Forms.Panel();
            this.lisPrvGrpList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUsrLabel = new System.Windows.Forms.Panel();
            this.btnUsrRefresh = new System.Windows.Forms.Button();
            this.lblPrvGrpList = new System.Windows.Forms.Label();
            this.pnlPrvGrpMidMid = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlPrvGrpMidLeft = new System.Windows.Forms.Panel();
            this.lisRelatedPrvGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGrpLabel = new System.Windows.Forms.Panel();
            this.btnGrpRefresh = new System.Windows.Forms.Button();
            this.lblPrvGrp = new System.Windows.Forms.Label();
            this.pnlPrvGrpTop = new System.Windows.Forms.Panel();
            this.txtUserDesc = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.splPrvGrp = new System.Windows.Forms.Splitter();
            this.pnlRelatedPrvGrp = new System.Windows.Forms.Panel();
            this.lisUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabPrvUser.SuspendLayout();
            this.tbpPrvGrp.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.pnlUserMid.SuspendLayout();
            this.pnlUserMidRight.SuspendLayout();
            this.pnlUserLabel.SuspendLayout();
            this.pnlUserMidMid.SuspendLayout();
            this.pnlUserMidLeft.SuspendLayout();
            this.pnlGroupLabel.SuspendLayout();
            this.pnlUserTop.SuspendLayout();
            this.pnlPrvGrpource.SuspendLayout();
            this.tbpUser.SuspendLayout();
            this.pnlPrvGrp.SuspendLayout();
            this.grpPrvGrp.SuspendLayout();
            this.pnlPrvGrpMid.SuspendLayout();
            this.pnlPrvGrpMidRight.SuspendLayout();
            this.pnlUsrLabel.SuspendLayout();
            this.pnlPrvGrpMidMid.SuspendLayout();
            this.pnlPrvGrpMidLeft.SuspendLayout();
            this.pnlGrpLabel.SuspendLayout();
            this.pnlPrvGrpTop.SuspendLayout();
            this.pnlRelatedPrvGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(559, 8);
            this.btnProcess.TabIndex = 16;
            this.btnProcess.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(651, 8);
            this.btnClose.TabIndex = 17;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Privilege Group - User Relation Setup";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabPrvUser);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTab.Size = new System.Drawing.Size(742, 513);
            this.pnlTab.TabIndex = 0;
            // 
            // tabPrvUser
            // 
            this.tabPrvUser.Controls.Add(this.tbpPrvGrp);
            this.tabPrvUser.Controls.Add(this.tbpUser);
            this.tabPrvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrvUser.ItemSize = new System.Drawing.Size(60, 18);
            this.tabPrvUser.Location = new System.Drawing.Point(5, 5);
            this.tabPrvUser.Name = "tabPrvUser";
            this.tabPrvUser.SelectedIndex = 0;
            this.tabPrvUser.Size = new System.Drawing.Size(732, 503);
            this.tabPrvUser.TabIndex = 0;
            this.tabPrvUser.TabStop = false;
            // 
            // tbpPrvGrp
            // 
            this.tbpPrvGrp.Controls.Add(this.pnlUser);
            this.tbpPrvGrp.Controls.Add(this.splUser);
            this.tbpPrvGrp.Controls.Add(this.pnlPrvGrpource);
            this.tbpPrvGrp.Location = new System.Drawing.Point(4, 22);
            this.tbpPrvGrp.Name = "tbpPrvGrp";
            this.tbpPrvGrp.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPrvGrp.Size = new System.Drawing.Size(724, 477);
            this.tbpPrvGrp.TabIndex = 0;
            this.tbpPrvGrp.Text = "Privilege Group";
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.grpUser);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUser.Location = new System.Drawing.Point(230, 3);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(491, 471);
            this.pnlUser.TabIndex = 1;
            this.pnlUser.Resize += new System.EventHandler(this.pnlUser_Resize);
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.pnlUserMid);
            this.grpUser.Controls.Add(this.pnlUserTop);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(491, 471);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            // 
            // pnlUserMid
            // 
            this.pnlUserMid.Controls.Add(this.pnlUserMidRight);
            this.pnlUserMid.Controls.Add(this.pnlUserMidMid);
            this.pnlUserMid.Controls.Add(this.pnlUserMidLeft);
            this.pnlUserMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserMid.Location = new System.Drawing.Point(3, 46);
            this.pnlUserMid.Name = "pnlUserMid";
            this.pnlUserMid.Size = new System.Drawing.Size(485, 422);
            this.pnlUserMid.TabIndex = 1;
            // 
            // pnlUserMidRight
            // 
            this.pnlUserMidRight.Controls.Add(this.lisUserlist);
            this.pnlUserMidRight.Controls.Add(this.pnlUserLabel);
            this.pnlUserMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUserMidRight.Location = new System.Drawing.Point(265, 0);
            this.pnlUserMidRight.Name = "pnlUserMidRight";
            this.pnlUserMidRight.Size = new System.Drawing.Size(220, 422);
            this.pnlUserMidRight.TabIndex = 2;
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
            this.lisUserlist.Location = new System.Drawing.Point(0, 24);
            this.lisUserlist.Name = "lisUserlist";
            this.lisUserlist.Size = new System.Drawing.Size(220, 398);
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
            // pnlUserLabel
            // 
            this.pnlUserLabel.Controls.Add(this.btnUserRefresh);
            this.pnlUserLabel.Controls.Add(this.lblUserList);
            this.pnlUserLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlUserLabel.Name = "pnlUserLabel";
            this.pnlUserLabel.Size = new System.Drawing.Size(220, 24);
            this.pnlUserLabel.TabIndex = 0;
            // 
            // btnUserRefresh
            // 
            this.btnUserRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnUserRefresh.Image")));
            this.btnUserRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUserRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnUserRefresh.Name = "btnUserRefresh";
            this.btnUserRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnUserRefresh.TabIndex = 20;
            this.btnUserRefresh.Click += new System.EventHandler(this.btnUserRefresh_Click);
            // 
            // lblUserList
            // 
            this.lblUserList.AutoSize = true;
            this.lblUserList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserList.Location = new System.Drawing.Point(3, 6);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(62, 13);
            this.lblUserList.TabIndex = 1;
            this.lblUserList.Text = "All User List";
            this.lblUserList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserMidMid
            // 
            this.pnlUserMidMid.Controls.Add(this.btnDel);
            this.pnlUserMidMid.Controls.Add(this.btnAdd);
            this.pnlUserMidMid.Location = new System.Drawing.Point(227, 54);
            this.pnlUserMidMid.Name = "pnlUserMidMid";
            this.pnlUserMidMid.Size = new System.Drawing.Size(34, 126);
            this.pnlUserMidMid.TabIndex = 1;
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
            this.pnlUserMidLeft.Controls.Add(this.pnlGroupLabel);
            this.pnlUserMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlUserMidLeft.Name = "pnlUserMidLeft";
            this.pnlUserMidLeft.Size = new System.Drawing.Size(220, 422);
            this.pnlUserMidLeft.TabIndex = 0;
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
            this.lisRelatedUser.Location = new System.Drawing.Point(0, 24);
            this.lisRelatedUser.Name = "lisRelatedUser";
            this.lisRelatedUser.Size = new System.Drawing.Size(220, 398);
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
            // pnlGroupLabel
            // 
            this.pnlGroupLabel.Controls.Add(this.btnGroupRefresh);
            this.pnlGroupLabel.Controls.Add(this.lblUser);
            this.pnlGroupLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroupLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupLabel.Name = "pnlGroupLabel";
            this.pnlGroupLabel.Size = new System.Drawing.Size(220, 24);
            this.pnlGroupLabel.TabIndex = 0;
            // 
            // btnGroupRefresh
            // 
            this.btnGroupRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGroupRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGroupRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupRefresh.Image")));
            this.btnGroupRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGroupRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnGroupRefresh.Name = "btnGroupRefresh";
            this.btnGroupRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnGroupRefresh.TabIndex = 19;
            this.btnGroupRefresh.Click += new System.EventHandler(this.btnGrpRefresh_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(3, 6);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Privilege Group - User Relation";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserTop
            // 
            this.pnlUserTop.Controls.Add(this.txtDesc);
            this.pnlUserTop.Controls.Add(this.txtPrvGrp);
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
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TabStop = false;
            // 
            // txtPrvGrp
            // 
            this.txtPrvGrp.Location = new System.Drawing.Point(4, 0);
            this.txtPrvGrp.MaxLength = 20;
            this.txtPrvGrp.Name = "txtPrvGrp";
            this.txtPrvGrp.ReadOnly = true;
            this.txtPrvGrp.Size = new System.Drawing.Size(134, 20);
            this.txtPrvGrp.TabIndex = 0;
            this.txtPrvGrp.TabStop = false;
            // 
            // splUser
            // 
            this.splUser.Location = new System.Drawing.Point(227, 3);
            this.splUser.Name = "splUser";
            this.splUser.Size = new System.Drawing.Size(3, 471);
            this.splUser.TabIndex = 0;
            this.splUser.TabStop = false;
            // 
            // pnlPrvGrpource
            // 
            this.pnlPrvGrpource.Controls.Add(this.lisPrvGrp);
            this.pnlPrvGrpource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrvGrpource.Location = new System.Drawing.Point(3, 3);
            this.pnlPrvGrpource.Name = "pnlPrvGrpource";
            this.pnlPrvGrpource.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlPrvGrpource.Size = new System.Drawing.Size(224, 471);
            this.pnlPrvGrpource.TabIndex = 0;
            // 
            // lisPrvGrp
            // 
            this.lisPrvGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPrvGrp.EnableSort = true;
            this.lisPrvGrp.EnableSortIcon = true;
            this.lisPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPrvGrp.FullRowSelect = true;
            this.lisPrvGrp.Location = new System.Drawing.Point(0, 3);
            this.lisPrvGrp.MultiSelect = false;
            this.lisPrvGrp.Name = "lisPrvGrp";
            this.lisPrvGrp.Size = new System.Drawing.Size(224, 468);
            this.lisPrvGrp.TabIndex = 0;
            this.lisPrvGrp.UseCompatibleStateImageBehavior = false;
            this.lisPrvGrp.View = System.Windows.Forms.View.Details;
            this.lisPrvGrp.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisPrvGrp_ColumnClick);
            this.lisPrvGrp.SelectedIndexChanged += new System.EventHandler(this.lisPrvGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Privilege Group";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.pnlPrvGrp);
            this.tbpUser.Controls.Add(this.splPrvGrp);
            this.tbpUser.Controls.Add(this.pnlRelatedPrvGrp);
            this.tbpUser.Location = new System.Drawing.Point(4, 22);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUser.Size = new System.Drawing.Size(724, 477);
            this.tbpUser.TabIndex = 1;
            this.tbpUser.Text = "User";
            this.tbpUser.Visible = false;
            // 
            // pnlPrvGrp
            // 
            this.pnlPrvGrp.Controls.Add(this.grpPrvGrp);
            this.pnlPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrvGrp.Location = new System.Drawing.Point(230, 3);
            this.pnlPrvGrp.Name = "pnlPrvGrp";
            this.pnlPrvGrp.Size = new System.Drawing.Size(491, 471);
            this.pnlPrvGrp.TabIndex = 1;
            this.pnlPrvGrp.Resize += new System.EventHandler(this.pnlPrvGrp_Resize);
            // 
            // grpPrvGrp
            // 
            this.grpPrvGrp.Controls.Add(this.pnlPrvGrpMid);
            this.grpPrvGrp.Controls.Add(this.pnlPrvGrpTop);
            this.grpPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrvGrp.Location = new System.Drawing.Point(0, 0);
            this.grpPrvGrp.Name = "grpPrvGrp";
            this.grpPrvGrp.Size = new System.Drawing.Size(491, 471);
            this.grpPrvGrp.TabIndex = 0;
            this.grpPrvGrp.TabStop = false;
            // 
            // pnlPrvGrpMid
            // 
            this.pnlPrvGrpMid.Controls.Add(this.pnlPrvGrpMidRight);
            this.pnlPrvGrpMid.Controls.Add(this.pnlPrvGrpMidMid);
            this.pnlPrvGrpMid.Controls.Add(this.pnlPrvGrpMidLeft);
            this.pnlPrvGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrvGrpMid.Location = new System.Drawing.Point(3, 46);
            this.pnlPrvGrpMid.Name = "pnlPrvGrpMid";
            this.pnlPrvGrpMid.Size = new System.Drawing.Size(485, 422);
            this.pnlPrvGrpMid.TabIndex = 1;
            // 
            // pnlPrvGrpMidRight
            // 
            this.pnlPrvGrpMidRight.Controls.Add(this.lisPrvGrpList);
            this.pnlPrvGrpMidRight.Controls.Add(this.pnlUsrLabel);
            this.pnlPrvGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPrvGrpMidRight.Location = new System.Drawing.Point(265, 0);
            this.pnlPrvGrpMidRight.Name = "pnlPrvGrpMidRight";
            this.pnlPrvGrpMidRight.Size = new System.Drawing.Size(220, 422);
            this.pnlPrvGrpMidRight.TabIndex = 2;
            // 
            // lisPrvGrpList
            // 
            this.lisPrvGrpList.AllowDrop = true;
            this.lisPrvGrpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisPrvGrpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPrvGrpList.EnableSort = true;
            this.lisPrvGrpList.EnableSortIcon = true;
            this.lisPrvGrpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPrvGrpList.FullRowSelect = true;
            this.lisPrvGrpList.Location = new System.Drawing.Point(0, 24);
            this.lisPrvGrpList.Name = "lisPrvGrpList";
            this.lisPrvGrpList.Size = new System.Drawing.Size(220, 398);
            this.lisPrvGrpList.TabIndex = 6;
            this.lisPrvGrpList.UseCompatibleStateImageBehavior = false;
            this.lisPrvGrpList.View = System.Windows.Forms.View.Details;
            this.lisPrvGrpList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisPrvGrpList_ColumnClick);
            this.lisPrvGrpList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisPrvGrplist_ItemDrag);
            this.lisPrvGrpList.Click += new System.EventHandler(this.lisPrvGrplist_Click);
            this.lisPrvGrpList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisPrvGrplist_DragDrop);
            this.lisPrvGrpList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisPrvGrplist_DragEnter);
            this.lisPrvGrpList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisPrvGrplist_MouseDown);
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Privilege";
            this.ColumnHeader9.Width = 100;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Description";
            this.ColumnHeader10.Width = 150;
            // 
            // pnlUsrLabel
            // 
            this.pnlUsrLabel.Controls.Add(this.btnUsrRefresh);
            this.pnlUsrLabel.Controls.Add(this.lblPrvGrpList);
            this.pnlUsrLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUsrLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlUsrLabel.Name = "pnlUsrLabel";
            this.pnlUsrLabel.Size = new System.Drawing.Size(220, 24);
            this.pnlUsrLabel.TabIndex = 0;
            // 
            // btnUsrRefresh
            // 
            this.btnUsrRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUsrRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsrRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnUsrRefresh.Image")));
            this.btnUsrRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUsrRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnUsrRefresh.Name = "btnUsrRefresh";
            this.btnUsrRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnUsrRefresh.TabIndex = 20;
            this.btnUsrRefresh.Click += new System.EventHandler(this.btnUsrRefresh_Click);
            // 
            // lblPrvGrpList
            // 
            this.lblPrvGrpList.AutoSize = true;
            this.lblPrvGrpList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrvGrpList.Location = new System.Drawing.Point(3, 6);
            this.lblPrvGrpList.Name = "lblPrvGrpList";
            this.lblPrvGrpList.Size = new System.Drawing.Size(112, 13);
            this.lblPrvGrpList.TabIndex = 0;
            this.lblPrvGrpList.Text = "All Privilege Group List";
            // 
            // pnlPrvGrpMidMid
            // 
            this.pnlPrvGrpMidMid.Controls.Add(this.btnDetach);
            this.pnlPrvGrpMidMid.Controls.Add(this.btnAttach);
            this.pnlPrvGrpMidMid.Location = new System.Drawing.Point(227, 54);
            this.pnlPrvGrpMidMid.Name = "pnlPrvGrpMidMid";
            this.pnlPrvGrpMidMid.Size = new System.Drawing.Size(34, 126);
            this.pnlPrvGrpMidMid.TabIndex = 1;
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(5, 66);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 5;
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
            this.btnAttach.TabIndex = 4;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlPrvGrpMidLeft
            // 
            this.pnlPrvGrpMidLeft.Controls.Add(this.lisRelatedPrvGrp);
            this.pnlPrvGrpMidLeft.Controls.Add(this.pnlGrpLabel);
            this.pnlPrvGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrvGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlPrvGrpMidLeft.Name = "pnlPrvGrpMidLeft";
            this.pnlPrvGrpMidLeft.Size = new System.Drawing.Size(220, 422);
            this.pnlPrvGrpMidLeft.TabIndex = 0;
            // 
            // lisRelatedPrvGrp
            // 
            this.lisRelatedPrvGrp.AllowDrop = true;
            this.lisRelatedPrvGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisRelatedPrvGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRelatedPrvGrp.EnableSort = true;
            this.lisRelatedPrvGrp.EnableSortIcon = true;
            this.lisRelatedPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRelatedPrvGrp.FullRowSelect = true;
            this.lisRelatedPrvGrp.Location = new System.Drawing.Point(0, 24);
            this.lisRelatedPrvGrp.Name = "lisRelatedPrvGrp";
            this.lisRelatedPrvGrp.Size = new System.Drawing.Size(220, 398);
            this.lisRelatedPrvGrp.TabIndex = 3;
            this.lisRelatedPrvGrp.UseCompatibleStateImageBehavior = false;
            this.lisRelatedPrvGrp.View = System.Windows.Forms.View.Details;
            this.lisRelatedPrvGrp.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisRelatedPrvGrp_ItemDrag);
            this.lisRelatedPrvGrp.Click += new System.EventHandler(this.lisRelatedPrvGrp_Click);
            this.lisRelatedPrvGrp.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisRelatedPrvGrp_DragDrop);
            this.lisRelatedPrvGrp.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisRelatedPrvGrp_DragEnter);
            this.lisRelatedPrvGrp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisRelatedPrvGrp_MouseDown);
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Privilege Group";
            this.ColumnHeader11.Width = 100;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Description";
            this.ColumnHeader12.Width = 150;
            // 
            // pnlGrpLabel
            // 
            this.pnlGrpLabel.Controls.Add(this.btnGrpRefresh);
            this.pnlGrpLabel.Controls.Add(this.lblPrvGrp);
            this.pnlGrpLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrpLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpLabel.Name = "pnlGrpLabel";
            this.pnlGrpLabel.Size = new System.Drawing.Size(220, 24);
            this.pnlGrpLabel.TabIndex = 0;
            // 
            // btnGrpRefresh
            // 
            this.btnGrpRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGrpRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrpRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnGrpRefresh.Image")));
            this.btnGrpRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGrpRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnGrpRefresh.Name = "btnGrpRefresh";
            this.btnGrpRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnGrpRefresh.TabIndex = 19;
            this.btnGrpRefresh.Click += new System.EventHandler(this.btnGrpRefresh_Click_1);
            // 
            // lblPrvGrp
            // 
            this.lblPrvGrp.AutoSize = true;
            this.lblPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrvGrp.Location = new System.Drawing.Point(3, 6);
            this.lblPrvGrp.Name = "lblPrvGrp";
            this.lblPrvGrp.Size = new System.Drawing.Size(152, 13);
            this.lblPrvGrp.TabIndex = 0;
            this.lblPrvGrp.Text = "Privilege Group - User Relation";
            // 
            // pnlPrvGrpTop
            // 
            this.pnlPrvGrpTop.Controls.Add(this.txtUserDesc);
            this.pnlPrvGrpTop.Controls.Add(this.txtUser);
            this.pnlPrvGrpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrvGrpTop.Location = new System.Drawing.Point(3, 16);
            this.pnlPrvGrpTop.Name = "pnlPrvGrpTop";
            this.pnlPrvGrpTop.Size = new System.Drawing.Size(485, 30);
            this.pnlPrvGrpTop.TabIndex = 0;
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
            this.txtUserDesc.TabIndex = 2;
            this.txtUserDesc.TabStop = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(4, 0);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(134, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.TabStop = false;
            // 
            // splPrvGrp
            // 
            this.splPrvGrp.Location = new System.Drawing.Point(227, 3);
            this.splPrvGrp.Name = "splPrvGrp";
            this.splPrvGrp.Size = new System.Drawing.Size(3, 471);
            this.splPrvGrp.TabIndex = 18;
            this.splPrvGrp.TabStop = false;
            // 
            // pnlRelatedPrvGrp
            // 
            this.pnlRelatedPrvGrp.Controls.Add(this.lisUser);
            this.pnlRelatedPrvGrp.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRelatedPrvGrp.Location = new System.Drawing.Point(3, 3);
            this.pnlRelatedPrvGrp.Name = "pnlRelatedPrvGrp";
            this.pnlRelatedPrvGrp.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlRelatedPrvGrp.Size = new System.Drawing.Size(224, 471);
            this.pnlRelatedPrvGrp.TabIndex = 0;
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
            this.lisUser.Size = new System.Drawing.Size(224, 468);
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
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmSECSetupPrvUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmSECSetupPrvUser";
            this.Text = "Privilege Group - User Relation Setup";
            this.Activated += new System.EventHandler(this.frmSECSetupPrvUser_Activated);
            this.Load += new System.EventHandler(this.frmSECSetupPrvUser_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabPrvUser.ResumeLayout(false);
            this.tbpPrvGrp.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.pnlUserMid.ResumeLayout(false);
            this.pnlUserMidRight.ResumeLayout(false);
            this.pnlUserLabel.ResumeLayout(false);
            this.pnlUserLabel.PerformLayout();
            this.pnlUserMidMid.ResumeLayout(false);
            this.pnlUserMidLeft.ResumeLayout(false);
            this.pnlGroupLabel.ResumeLayout(false);
            this.pnlGroupLabel.PerformLayout();
            this.pnlUserTop.ResumeLayout(false);
            this.pnlUserTop.PerformLayout();
            this.pnlPrvGrpource.ResumeLayout(false);
            this.tbpUser.ResumeLayout(false);
            this.pnlPrvGrp.ResumeLayout(false);
            this.grpPrvGrp.ResumeLayout(false);
            this.pnlPrvGrpMid.ResumeLayout(false);
            this.pnlPrvGrpMidRight.ResumeLayout(false);
            this.pnlUsrLabel.ResumeLayout(false);
            this.pnlUsrLabel.PerformLayout();
            this.pnlPrvGrpMidMid.ResumeLayout(false);
            this.pnlPrvGrpMidLeft.ResumeLayout(false);
            this.pnlGrpLabel.ResumeLayout(false);
            this.pnlGrpLabel.PerformLayout();
            this.pnlPrvGrpTop.ResumeLayout(false);
            this.pnlPrvGrpTop.PerformLayout();
            this.pnlRelatedPrvGrp.ResumeLayout(false);
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
        private object SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
            return null;
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
                case "ATTACH_USER":
                    
                    if (lisPrvGrp.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
                            lisPrvGrp.Focus();
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
                    
                    if (lisPrvGrp.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
                            lisPrvGrp.Focus();
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
                case "ATTACH_PRVGRP":
                    
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
                    if (lisPrvGrpList.SelectedItems.Count <= 0)
                    {
                        if (lisPrvGrpList.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisPrvGrpList.Items[0].Selected = true;
                            lisPrvGrpList.Focus();
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
                    if (lisRelatedPrvGrp.SelectedItems.Count <= 0)
                    {
                        if (lisRelatedPrvGrp.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisRelatedPrvGrp.Items[0].Selected = true;
                            lisRelatedPrvGrp.Focus();
                        }
                        return false;
                    }
                    break;
            }
            
            return true;
        }
        
        // Update_Privilege_Group_User()
        //       - Create/Update/Delete Privilege Group - User Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String          :  ?•ìž¥ Process Step
        //       - ByVal sUser As String          :  Operation
        //       - ByVal sRes As String           :  Resource ID
        //
        private bool Update_Privilege_Group_User(char c_step, string sUser, string sRes)
        {
            TRSNode in_node = new TRSNode("UPDATE_PRIVILEGE_GROUP_USER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("USER_ID", sUser, true);
                in_node.AddString("PRV_GRP_ID", sRes);

                if (MPCR.CallService("SEC", "SEC_Update_Privilege_Group_User", in_node, ref out_node) == false)
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
                return this.tabPrvUser;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmSECSetupPrvUser_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    pnlUser_Resize(null, null);
                    pnlPrvGrp_Resize(null, null);
                    
                    lisPrvGrp.Focus();
                    if (SECLIST.ViewPrvGroupList(lisPrvGrp, '1', null, "") == false)
                    {
                        return;
                    }
                    else
                    {
                        if (lisPrvGrp.Items.Count > 0)
                        {
                            lisPrvGrp.Items[0].Selected = true;
                        }
                    }
                    
                    if (SECLIST.ViewPrvGroupList(lisPrvGrpList, '1', null, "") == false)
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
        
        private void frmSECSetupPrvUser_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisPrvGrp);
                MPCF.InitListView(lisRelatedPrvGrp);
                MPCF.InitListView(lisPrvGrpList);
                MPCF.InitListView(lisUser);
                MPCF.InitListView(lisRelatedUser);
                MPCF.InitListView(lisUserlist);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                
            }
        }
        
        private void lisPrvGrp_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisRelatedUser, true);
            MPCF.FieldClear(grpUser);
            if (lisPrvGrp.SelectedItems.Count > 0)
            {
                SECLIST.ViewPrvGrpUserList(lisRelatedUser, '1', lisPrvGrp.SelectedItems[0].Text, "");
                txtPrvGrp.Text = lisPrvGrp.SelectedItems[0].Text;
                txtDesc.Text = lisPrvGrp.SelectedItems[0].SubItems[1].Text;
            }
        }
        
        private void lisUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisRelatedPrvGrp, true);
            MPCF.FieldClear(grpPrvGrp);
            if (lisUser.SelectedItems.Count > 0)
            {
                SECLIST.ViewPrvGrpUserList(lisRelatedPrvGrp, '2', lisUser.SelectedItems[0].Text, "");
                txtUser.Text = lisUser.SelectedItems[0].Text;
                txtUserDesc.Text = lisUser.SelectedItems[0].SubItems[1].Text;
            }
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            ListViewItem itmX;
            string[] sSelect = null;
            int i;
            int iIdx = 0;
            
            sSelect = new string[lisUserlist.SelectedItems.Count];
            SelectClear(lisRelatedUser);
            if (CheckCondition("ATTACH_USER") == false)
            {
                return;
            }
            for (i = 0; i <= lisUserlist.SelectedItems.Count - 1; i++)
            {
                sUser = lisUserlist.SelectedItems[i].Text;
                sRes = lisPrvGrp.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisRelatedUser, sUser, false) == false)
                {
                    if (Update_Privilege_Group_User(MPGC.MP_STEP_CREATE, sUser, sRes) == true)
                    {
                        sSelect[i] = sUser;
                        itmX = lisRelatedUser.Items.Add(sUser, (int)SMALLICON_INDEX.IDX_USER);
                        itmX.SubItems.Add(lisUserlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisUserlist.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedUser.Sorting = SortOrder.Ascending;
                        lisRelatedUser.Sort();
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedUser, sSelect(j))
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
            //If ViewPrvGrpUserList(lisRelatedUser, "1", lisPrvGrp.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisUserlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisUserlist.Items.Count - 1)
                {
                    lisUserlist.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedUser, sSelect(i))
            //Next
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_USER") == false)
            {
                return;
            }
            iCount = lisRelatedUser.SelectedItems.Count;
            SelectClear(lisUserlist);
            for (i = lisRelatedUser.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisRelatedUser.SelectedItems[i].Text;
                sRes = lisPrvGrp.SelectedItems[0].Text;
                
                if (Update_Privilege_Group_User(MPGC.MP_STEP_DELETE, sUser, sRes) == true)
                {
                    iIdx = lisRelatedUser.SelectedItems[i].Index;
                    lisRelatedUser.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisUserlist, sUser, false);
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
            
            sSelect = new string[lisPrvGrpList.SelectedItems.Count];
            SelectClear(lisRelatedPrvGrp);
            if (CheckCondition("ATTACH_PRVGRP") == false)
            {
                return;
            }
            for (i = 0; i <= lisPrvGrpList.SelectedItems.Count - 1; i++)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisPrvGrpList.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRelatedPrvGrp, sRes, false) == false)
                {
                    if (Update_Privilege_Group_User(MPGC.MP_STEP_CREATE, sUser, sRes) == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRelatedPrvGrp.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                        itmX.SubItems.Add(lisPrvGrpList.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisPrvGrpList.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedPrvGrp.Sorting = SortOrder.Ascending;
                        lisRelatedPrvGrp.Sort();
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedPrvGrp, sSelect(j))
                        //Next
                        SelectClear(lisPrvGrpList);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisPrvGrpList.SelectedItems[i].Index;
                }
            }
            //If ViewPrvGrpUserList(lisRelatedPrvGrp, "2", lisUser.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisPrvGrpList);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisPrvGrpList.Items.Count - 1)
                {
                    lisPrvGrpList.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedPrvGrp, sSelect(i))
            //Next
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sUser;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES") == false)
            {
                return;
            }
            iCount = lisRelatedPrvGrp.SelectedItems.Count;
            SelectClear(lisPrvGrpList);
            for (i = lisRelatedPrvGrp.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisRelatedPrvGrp.SelectedItems[i].Text;
                
                if (Update_Privilege_Group_User(MPGC.MP_STEP_DELETE, sUser, sRes) == true)
                {
                    iIdx = lisRelatedPrvGrp.SelectedItems[i].Index;
                    lisRelatedPrvGrp.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisPrvGrpList, sRes, false);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedPrvGrp.Items.Count)
                {
                    lisRelatedPrvGrp.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void pnlUser_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlUserMid, pnlUserMidLeft, pnlUserMidRight, pnlUserMidMid, 40);
        }
        
        private void pnlPrvGrp_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlPrvGrpMid, pnlPrvGrpMidLeft, pnlPrvGrpMidRight, pnlPrvGrpMidMid, 40);
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
            if (CheckCondition("ATTACH_USER") == false)
            {
                return;
            }
            for (i = 0; i <= lisUserlist.SelectedItems.Count - 1; i++)
            {
                sUser = lisUserlist.SelectedItems[i].Text;
                sRes = lisPrvGrp.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisRelatedUser, sUser, false) == false)
                {
                    if (Update_Privilege_Group_User(MPGC.MP_STEP_CREATE, sUser, sRes) == true)
                    {
                        sSelect[i] = sUser;
                        itmX = lisRelatedUser.Items.Add(sUser, (int)SMALLICON_INDEX.IDX_USER);
                        itmX.SubItems.Add(lisUserlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisUserlist.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedUser.Sorting = SortOrder.Ascending;
                        lisRelatedUser.Sort();
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedUser, sSelect(j))
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
            //If ViewPrvGrpUserList(lisRelatedUser, "1", lisPrvGrp.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisUserlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisUserlist.Items.Count - 1)
                {
                    lisUserlist.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedUser, sSelect(i))
            //Next
        }
        
        private void lisUserList_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisUserlist.DoDragDrop(lisUserlist.SelectedItems[0].Text, DragDropEffects.Copy);
        }
        
        private void lisRelatedPrvGrp_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisRelatedPrvGrp_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int iIdx = 0;
            
            sSelect = new string[lisPrvGrpList.SelectedItems.Count];
            SelectClear(lisRelatedPrvGrp);
            if (CheckCondition("ATTACH_PRVGRP") == false)
            {
                return;
            }
            for (i = 0; i <= lisPrvGrpList.SelectedItems.Count - 1; i++)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisPrvGrpList.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRelatedPrvGrp, sRes, false) == false)
                {
                    if (Update_Privilege_Group_User(MPGC.MP_STEP_CREATE, sUser, sRes) == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRelatedPrvGrp.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP);
                        itmX.SubItems.Add(lisPrvGrpList.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisPrvGrpList.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisRelatedPrvGrp.Sorting = SortOrder.Ascending;
                        lisRelatedPrvGrp.Sort();
                    }
                    else
                    {
                        //For j = 0 To sSelect.Length - 1
                        //    FindListItem(lisRelatedPrvGrp, sSelect(j))
                        //Next
                        SelectClear(lisPrvGrpList);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisPrvGrpList.SelectedItems[i].Index;
                }
            }
            //If ViewPrvGrpUserList(lisRelatedPrvGrp, "2", lisUser.SelectedItems(0).Text) = False Then Exit Sub
            SelectClear(lisPrvGrpList);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisPrvGrpList.Items.Count - 1)
                {
                    lisPrvGrpList.Items[iIdx + 1].Selected = true;
                }
            }
            //For i = 0 To sSelect.Length - 1
            //    FindListItem(lisRelatedPrvGrp, sSelect(i))
            //Next
        }
        
        private void lisPrvGrplist_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisPrvGrpList.DoDragDrop(lisPrvGrpList.SelectedItems[0].Text, DragDropEffects.Copy);
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
            
            if (CheckCondition("DETACH_USER") == false)
            {
                return;
            }
            iCount = lisRelatedUser.SelectedItems.Count;
            SelectClear(lisUserlist);
            for (i = lisRelatedUser.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisRelatedUser.SelectedItems[i].Text;
                sRes = lisPrvGrp.SelectedItems[0].Text;
                
                if (Update_Privilege_Group_User(MPGC.MP_STEP_DELETE, sUser, sRes) == true)
                {
                    iIdx = lisRelatedUser.SelectedItems[i].Index;
                    lisRelatedUser.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisUserlist, sUser, false);
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
        
        private void lisPrvGrplist_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisPrvGrplist_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sUser;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES") == false)
            {
                return;
            }
            iCount = lisRelatedPrvGrp.SelectedItems.Count;
            SelectClear(lisPrvGrpList);
            for (i = lisRelatedPrvGrp.SelectedItems.Count - 1; i >= 0; i--)
            {
                sUser = lisUser.SelectedItems[0].Text;
                sRes = lisRelatedPrvGrp.SelectedItems[i].Text;
                
                if (Update_Privilege_Group_User(MPGC.MP_STEP_DELETE, sUser, sRes) == true)
                {
                    iIdx = lisRelatedPrvGrp.SelectedItems[i].Index;
                    lisRelatedPrvGrp.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisPrvGrpList, sRes, false);
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRelatedPrvGrp.Items.Count)
                {
                    lisRelatedPrvGrp.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void lisRelatedPrvGrp_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisRelatedPrvGrp.DoDragDrop(lisRelatedPrvGrp.SelectedItems[0].Text, DragDropEffects.Move);
        }
        
        private void lisRelatedPrvGrp_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisRelatedPrvGrp.AllowDrop = false;
            lisPrvGrpList.AllowDrop = true;
        }
        
        private void lisPrvGrplist_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisPrvGrpList.AllowDrop = false;
            lisRelatedPrvGrp.AllowDrop = true;
        }
        
        private void lisPrvGrplist_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisRelatedPrvGrp);
        }
        
        private void lisUserList_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisRelatedUser);
        }
        
        private void lisRelatedPrvGrp_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisPrvGrpList);
        }
        
        private void lisRelatedUser_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisUserlist);
        }
        
        private void lisPrvGrp_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewPrvGroupList(lisPrvGrp, "1") = False Then
            //    Exit Sub
            //Else
            //    If lisPrvGrp.Items.Count > 0 Then
            //        lisPrvGrp.Items.Item(0).Selected = True
            //    End If
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }
        
        private void lisUserlist_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewSECUserList(lisUserlist, "1") = False Then
            //    Exit Sub
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }
        
        private void lisUser_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewSECUserList(lisUser, "1") = False Then
            //    Exit Sub
            //Else
            //    If lisUser.Items.Count > 0 Then
            //        lisUser.Items.Item(0).Selected = True
            //    End If
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }
        
        private void lisPrvGrpList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewPrvGroupList(lisPrvGrpList, "1") = False Then
            //    Exit Sub
            //End If
            //View ?´í›„ Sorting ?´ì•¼ ? ì??
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (SECLIST.ViewPrvGroupList(lisPrvGrp, '1', null, "") == false)
            {
                return;
            }
            else
            {
                if (lisPrvGrp.Items.Count > 0)
                {
                    lisPrvGrp.Items[0].Selected = true;
                }
            }

            if (SECLIST.ViewPrvGroupList(lisPrvGrpList, '1', null, "") == false)
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
        }

        private void btnGrpRefresh_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisRelatedUser, true);
            if (lisPrvGrp.SelectedItems.Count > 0)
            {
                SECLIST.ViewPrvGrpUserList(lisRelatedUser, '1', lisPrvGrp.SelectedItems[0].Text, "");
            }
        }

        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            if (SECLIST.ViewSECUserList(lisUserlist, '1', -1, null, "", "") == false)
            {
                return;
            }
        }

        private void btnGrpRefresh_Click_1(object sender, EventArgs e)
        {
            MPCF.ClearList(lisRelatedPrvGrp, true);
            if (lisUser.SelectedItems.Count > 0)
            {
                SECLIST.ViewPrvGrpUserList(lisRelatedPrvGrp, '2', lisUser.SelectedItems[0].Text, "");
            }
        }

        private void btnUsrRefresh_Click(object sender, EventArgs e)
        {
            if (SECLIST.ViewPrvGroupList(lisPrvGrpList, '1', null, "") == false)
            {
                return;
            }
        }
        
    }
    
}
