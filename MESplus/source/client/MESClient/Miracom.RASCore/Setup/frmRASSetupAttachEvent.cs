
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
//   File Name   : frmRASSetupAttachEvent.vb
//   Description : Attach event to Resource Form
//
//   MES Version : 4.1.0.0
//
//   Function List

//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Resource_Event() : Create/Update/Delete Resource - Event Relation
//       - SelectClear()           : Clear Selected Items
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-14 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.RASCore
{
    public class frmRASSetupAttachEvent : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupAttachEvent()
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
        private System.Windows.Forms.TabControl tabResOper;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Panel pnlResource;
        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TabPage tbpEvent;
        private System.Windows.Forms.Panel pnlRelatedRes;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlReslist;
        private Miracom.UI.Controls.MCListView.MCListView lisEventBase;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.GroupBox grpEvent;
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.Panel pnlEventTop;
        private System.Windows.Forms.Panel pnlEventMid;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtResid;
        private System.Windows.Forms.Panel pnlEventMidLeft;
        private System.Windows.Forms.Panel pnlEventMidRight;
        private System.Windows.Forms.Panel pnlEventMidMid;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblEventList;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private Miracom.UI.Controls.MCListView.MCListView lisEvent;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private Miracom.UI.Controls.MCListView.MCListView lisEventlist;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Panel pnlResListTop;
        private System.Windows.Forms.Panel pnlResListMid;
        private System.Windows.Forms.TextBox txtEventDesc;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Panel pnlResListMidLeft;
        private System.Windows.Forms.Panel pnlResListMidMid;
        private System.Windows.Forms.Panel pnlResListMidRight;
        private System.Windows.Forms.Label lblRes;
        private Miracom.UI.Controls.MCListView.MCListView lisRes;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.Label lblResList;
        private Miracom.UI.Controls.MCListView.MCListView lisReslist;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Splitter splRes;
        private System.Windows.Forms.Splitter splEvent;
        private System.Windows.Forms.TabPage tbpSubResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader17;
        private System.Windows.Forms.ColumnHeader ColumnHeader18;
        private System.Windows.Forms.ColumnHeader ColumnHeader23;
        private System.Windows.Forms.ColumnHeader ColumnHeader24;
        private System.Windows.Forms.ColumnHeader ColumnHeader19;
        private System.Windows.Forms.ColumnHeader ColumnHeader20;
        private System.Windows.Forms.ColumnHeader ColumnHeader21;
        private System.Windows.Forms.ColumnHeader ColumnHeader22;
        private System.Windows.Forms.Panel pnlSubResource;
        private Miracom.UI.Controls.MCListView.MCListView lisSubResource;
        private System.Windows.Forms.Panel pnlSubType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubType;
        private System.Windows.Forms.Splitter splSubRes;
        private System.Windows.Forms.GroupBox grpSubResource;
        private System.Windows.Forms.Panel pnlSubResourceMid;
        private System.Windows.Forms.Panel pnlSubResourceMidMid;
        private System.Windows.Forms.Button btndelSub;
        private System.Windows.Forms.Button btnAddSub;
        private System.Windows.Forms.Panel pnlSubResourceMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisEventListSub;
        private System.Windows.Forms.Label libEventListSub;
        private System.Windows.Forms.Panel pnlSubResourceMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisEventSub;
        private System.Windows.Forms.Label lblEventSub;
        private System.Windows.Forms.Panel pnlEventTopSub;
        private System.Windows.Forms.TextBox txtSubResDesc;
        private System.Windows.Forms.TextBox txtSubRes;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.Label lblResID;
        protected Button btnSubResExcel;
        protected Button btnEvnExcel;
        protected Button btnResExcel;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupAttachEvent));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabResOper = new System.Windows.Forms.TabControl();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.pnlEventMid = new System.Windows.Forms.Panel();
            this.pnlEventMidMid = new System.Windows.Forms.Panel();
            this.btnResExcel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlEventMidRight = new System.Windows.Forms.Panel();
            this.lisEventlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEventList = new System.Windows.Forms.Label();
            this.pnlEventMidLeft = new System.Windows.Forms.Panel();
            this.lisEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEvent = new System.Windows.Forms.Label();
            this.pnlEventTop = new System.Windows.Forms.Panel();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtResid = new System.Windows.Forms.TextBox();
            this.splRes = new System.Windows.Forms.Splitter();
            this.pnlResource = new System.Windows.Forms.Panel();
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.tbpEvent = new System.Windows.Forms.TabPage();
            this.pnlReslist = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.pnlResListMid = new System.Windows.Forms.Panel();
            this.pnlResListMidRight = new System.Windows.Forms.Panel();
            this.lisReslist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResList = new System.Windows.Forms.Label();
            this.pnlResListMidMid = new System.Windows.Forms.Panel();
            this.btnEvnExcel = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlResListMidLeft = new System.Windows.Forms.Panel();
            this.lisRes = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRes = new System.Windows.Forms.Label();
            this.pnlResListTop = new System.Windows.Forms.Panel();
            this.txtEventDesc = new System.Windows.Forms.TextBox();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.splEvent = new System.Windows.Forms.Splitter();
            this.pnlRelatedRes = new System.Windows.Forms.Panel();
            this.lisEventBase = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpSubResource = new System.Windows.Forms.TabPage();
            this.grpSubResource = new System.Windows.Forms.GroupBox();
            this.pnlSubResourceMid = new System.Windows.Forms.Panel();
            this.pnlSubResourceMidMid = new System.Windows.Forms.Panel();
            this.btnSubResExcel = new System.Windows.Forms.Button();
            this.btndelSub = new System.Windows.Forms.Button();
            this.btnAddSub = new System.Windows.Forms.Button();
            this.pnlSubResourceMidRight = new System.Windows.Forms.Panel();
            this.lisEventListSub = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.libEventListSub = new System.Windows.Forms.Label();
            this.pnlSubResourceMidLeft = new System.Windows.Forms.Panel();
            this.lisEventSub = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEventSub = new System.Windows.Forms.Label();
            this.pnlEventTopSub = new System.Windows.Forms.Panel();
            this.txtSubResDesc = new System.Windows.Forms.TextBox();
            this.txtSubRes = new System.Windows.Forms.TextBox();
            this.splSubRes = new System.Windows.Forms.Splitter();
            this.pnlSubResource = new System.Windows.Forms.Panel();
            this.lisSubResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSubType = new System.Windows.Forms.Panel();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvSubType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabResOper.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.grpEvent.SuspendLayout();
            this.pnlEventMid.SuspendLayout();
            this.pnlEventMidMid.SuspendLayout();
            this.pnlEventMidRight.SuspendLayout();
            this.pnlEventMidLeft.SuspendLayout();
            this.pnlEventTop.SuspendLayout();
            this.pnlResource.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.tbpEvent.SuspendLayout();
            this.pnlReslist.SuspendLayout();
            this.grpRes.SuspendLayout();
            this.pnlResListMid.SuspendLayout();
            this.pnlResListMidRight.SuspendLayout();
            this.pnlResListMidMid.SuspendLayout();
            this.pnlResListMidLeft.SuspendLayout();
            this.pnlResListTop.SuspendLayout();
            this.pnlRelatedRes.SuspendLayout();
            this.tbpSubResource.SuspendLayout();
            this.grpSubResource.SuspendLayout();
            this.pnlSubResourceMid.SuspendLayout();
            this.pnlSubResourceMidMid.SuspendLayout();
            this.pnlSubResourceMidRight.SuspendLayout();
            this.pnlSubResourceMidLeft.SuspendLayout();
            this.pnlEventTopSub.SuspendLayout();
            this.pnlSubResource.SuspendLayout();
            this.pnlSubType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Resource - Event Relation Setup";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabResOper);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTab.Size = new System.Drawing.Size(742, 506);
            this.pnlTab.TabIndex = 0;
            // 
            // tabResOper
            // 
            this.tabResOper.Controls.Add(this.tbpResource);
            this.tabResOper.Controls.Add(this.tbpEvent);
            this.tabResOper.Controls.Add(this.tbpSubResource);
            this.tabResOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResOper.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResOper.Location = new System.Drawing.Point(5, 5);
            this.tabResOper.Name = "tabResOper";
            this.tabResOper.SelectedIndex = 0;
            this.tabResOper.Size = new System.Drawing.Size(732, 496);
            this.tabResOper.TabIndex = 0;
            this.tabResOper.TabStop = false;
            this.tabResOper.SelectedIndexChanged += new System.EventHandler(this.tabResOper_SelectedIndexChanged);
            this.tabResOper.Click += new System.EventHandler(this.tabResOper_Click);
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.pnlEvent);
            this.tbpResource.Controls.Add(this.splRes);
            this.tbpResource.Controls.Add(this.pnlResource);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(724, 470);
            this.tbpResource.TabIndex = 0;
            this.tbpResource.Text = "Resource";
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.grpEvent);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvent.Location = new System.Drawing.Point(230, 3);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(491, 464);
            this.pnlEvent.TabIndex = 2;
            this.pnlEvent.Resize += new System.EventHandler(this.pnlEvent_Resize);
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.pnlEventMid);
            this.grpEvent.Controls.Add(this.pnlEventTop);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(0, 0);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(491, 464);
            this.grpEvent.TabIndex = 0;
            this.grpEvent.TabStop = false;
            // 
            // pnlEventMid
            // 
            this.pnlEventMid.Controls.Add(this.pnlEventMidMid);
            this.pnlEventMid.Controls.Add(this.pnlEventMidRight);
            this.pnlEventMid.Controls.Add(this.pnlEventMidLeft);
            this.pnlEventMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventMid.Location = new System.Drawing.Point(3, 46);
            this.pnlEventMid.Name = "pnlEventMid";
            this.pnlEventMid.Size = new System.Drawing.Size(485, 415);
            this.pnlEventMid.TabIndex = 1;
            // 
            // pnlEventMidMid
            // 
            this.pnlEventMidMid.Controls.Add(this.btnResExcel);
            this.pnlEventMidMid.Controls.Add(this.btnDel);
            this.pnlEventMidMid.Controls.Add(this.btnAdd);
            this.pnlEventMidMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEventMidMid.Location = new System.Drawing.Point(218, 0);
            this.pnlEventMidMid.Name = "pnlEventMidMid";
            this.pnlEventMidMid.Size = new System.Drawing.Size(75, 415);
            this.pnlEventMidMid.TabIndex = 2;
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
            this.btnResExcel.TabIndex = 22;
            this.btnResExcel.Click += new System.EventHandler(this.btnResExcel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(25, 210);
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
            this.btnAdd.Location = new System.Drawing.Point(25, 181);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlEventMidRight
            // 
            this.pnlEventMidRight.Controls.Add(this.lisEventlist);
            this.pnlEventMidRight.Controls.Add(this.lblEventList);
            this.pnlEventMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEventMidRight.Location = new System.Drawing.Point(293, 0);
            this.pnlEventMidRight.Name = "pnlEventMidRight";
            this.pnlEventMidRight.Size = new System.Drawing.Size(192, 415);
            this.pnlEventMidRight.TabIndex = 3;
            // 
            // lisEventlist
            // 
            this.lisEventlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisEventlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEventlist.EnableSort = true;
            this.lisEventlist.EnableSortIcon = true;
            this.lisEventlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEventlist.FullRowSelect = true;
            this.lisEventlist.Location = new System.Drawing.Point(0, 14);
            this.lisEventlist.Name = "lisEventlist";
            this.lisEventlist.Size = new System.Drawing.Size(192, 401);
            this.lisEventlist.TabIndex = 1;
            this.lisEventlist.UseCompatibleStateImageBehavior = false;
            this.lisEventlist.View = System.Windows.Forms.View.Details;
            this.lisEventlist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisEventlist_ColumnClick);
            this.lisEventlist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisEventlist_ItemDrag);
            this.lisEventlist.Click += new System.EventHandler(this.lisEventlist_Click);
            this.lisEventlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisEventlist_DragDrop);
            this.lisEventlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisEventlist_DragEnter);
            this.lisEventlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisEventlist_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Event";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // lblEventList
            // 
            this.lblEventList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEventList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventList.Location = new System.Drawing.Point(0, 0);
            this.lblEventList.Name = "lblEventList";
            this.lblEventList.Size = new System.Drawing.Size(192, 14);
            this.lblEventList.TabIndex = 0;
            this.lblEventList.Text = "All Event List";
            // 
            // pnlEventMidLeft
            // 
            this.pnlEventMidLeft.Controls.Add(this.lisEvent);
            this.pnlEventMidLeft.Controls.Add(this.lblEvent);
            this.pnlEventMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEventMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlEventMidLeft.Name = "pnlEventMidLeft";
            this.pnlEventMidLeft.Size = new System.Drawing.Size(218, 415);
            this.pnlEventMidLeft.TabIndex = 1;
            // 
            // lisEvent
            // 
            this.lisEvent.AllowDrop = true;
            this.lisEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEvent.EnableSort = true;
            this.lisEvent.EnableSortIcon = true;
            this.lisEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEvent.FullRowSelect = true;
            this.lisEvent.Location = new System.Drawing.Point(0, 14);
            this.lisEvent.Name = "lisEvent";
            this.lisEvent.Size = new System.Drawing.Size(218, 401);
            this.lisEvent.TabIndex = 15;
            this.lisEvent.UseCompatibleStateImageBehavior = false;
            this.lisEvent.View = System.Windows.Forms.View.Details;
            this.lisEvent.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisEvent_ItemDrag);
            this.lisEvent.Click += new System.EventHandler(this.lisEvent_Click);
            this.lisEvent.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisEvent_DragDrop);
            this.lisEvent.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisEvent_DragEnter);
            this.lisEvent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisEvent_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Event";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Description";
            this.ColumnHeader14.Width = 150;
            // 
            // lblEvent
            // 
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Location = new System.Drawing.Point(0, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(218, 14);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Resource - Event Relation";
            // 
            // pnlEventTop
            // 
            this.pnlEventTop.Controls.Add(this.txtDesc);
            this.pnlEventTop.Controls.Add(this.txtResid);
            this.pnlEventTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEventTop.Location = new System.Drawing.Point(3, 16);
            this.pnlEventTop.Name = "pnlEventTop";
            this.pnlEventTop.Size = new System.Drawing.Size(485, 30);
            this.pnlEventTop.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(143, 0);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(338, 20);
            this.txtDesc.TabIndex = 11;
            this.txtDesc.TabStop = false;
            // 
            // txtResid
            // 
            this.txtResid.Location = new System.Drawing.Point(3, 0);
            this.txtResid.MaxLength = 20;
            this.txtResid.Name = "txtResid";
            this.txtResid.ReadOnly = true;
            this.txtResid.Size = new System.Drawing.Size(134, 20);
            this.txtResid.TabIndex = 10;
            this.txtResid.TabStop = false;
            // 
            // splRes
            // 
            this.splRes.Location = new System.Drawing.Point(227, 3);
            this.splRes.Name = "splRes";
            this.splRes.Size = new System.Drawing.Size(3, 464);
            this.splRes.TabIndex = 2;
            this.splRes.TabStop = false;
            // 
            // pnlResource
            // 
            this.pnlResource.Controls.Add(this.lisResource);
            this.pnlResource.Controls.Add(this.pnlType);
            this.pnlResource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResource.Location = new System.Drawing.Point(3, 3);
            this.pnlResource.Name = "pnlResource";
            this.pnlResource.Size = new System.Drawing.Size(224, 464);
            this.pnlResource.TabIndex = 0;
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
            // tbpEvent
            // 
            this.tbpEvent.Controls.Add(this.pnlReslist);
            this.tbpEvent.Controls.Add(this.splEvent);
            this.tbpEvent.Controls.Add(this.pnlRelatedRes);
            this.tbpEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpEvent.Name = "tbpEvent";
            this.tbpEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEvent.Size = new System.Drawing.Size(724, 470);
            this.tbpEvent.TabIndex = 1;
            this.tbpEvent.Text = "Event";
            this.tbpEvent.Visible = false;
            // 
            // pnlReslist
            // 
            this.pnlReslist.Controls.Add(this.grpRes);
            this.pnlReslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReslist.Location = new System.Drawing.Point(230, 3);
            this.pnlReslist.Name = "pnlReslist";
            this.pnlReslist.Size = new System.Drawing.Size(491, 464);
            this.pnlReslist.TabIndex = 1;
            this.pnlReslist.Resize += new System.EventHandler(this.pnlReslist_Resize);
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.pnlResListMid);
            this.grpRes.Controls.Add(this.pnlResListTop);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(0, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(491, 464);
            this.grpRes.TabIndex = 1;
            this.grpRes.TabStop = false;
            // 
            // pnlResListMid
            // 
            this.pnlResListMid.Controls.Add(this.pnlResListMidRight);
            this.pnlResListMid.Controls.Add(this.pnlResListMidMid);
            this.pnlResListMid.Controls.Add(this.pnlResListMidLeft);
            this.pnlResListMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResListMid.Location = new System.Drawing.Point(3, 46);
            this.pnlResListMid.Name = "pnlResListMid";
            this.pnlResListMid.Size = new System.Drawing.Size(485, 415);
            this.pnlResListMid.TabIndex = 1;
            // 
            // pnlResListMidRight
            // 
            this.pnlResListMidRight.Controls.Add(this.lisReslist);
            this.pnlResListMidRight.Controls.Add(this.lblResList);
            this.pnlResListMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResListMidRight.Location = new System.Drawing.Point(271, 0);
            this.pnlResListMidRight.Name = "pnlResListMidRight";
            this.pnlResListMidRight.Size = new System.Drawing.Size(214, 415);
            this.pnlResListMidRight.TabIndex = 3;
            // 
            // lisReslist
            // 
            this.lisReslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisReslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisReslist.EnableSort = true;
            this.lisReslist.EnableSortIcon = true;
            this.lisReslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisReslist.FullRowSelect = true;
            this.lisReslist.Location = new System.Drawing.Point(0, 14);
            this.lisReslist.Name = "lisReslist";
            this.lisReslist.Size = new System.Drawing.Size(214, 401);
            this.lisReslist.TabIndex = 16;
            this.lisReslist.UseCompatibleStateImageBehavior = false;
            this.lisReslist.View = System.Windows.Forms.View.Details;
            this.lisReslist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisReslist_ColumnClick);
            this.lisReslist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisReslist_ItemDrag);
            this.lisReslist.Click += new System.EventHandler(this.lisReslist_Click);
            this.lisReslist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisReslist_DragDrop);
            this.lisReslist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisReslist_DragEnter);
            this.lisReslist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisReslist_MouseDown);
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
            this.lblResList.Size = new System.Drawing.Size(214, 14);
            this.lblResList.TabIndex = 14;
            this.lblResList.Text = "All Resource List";
            // 
            // pnlResListMidMid
            // 
            this.pnlResListMidMid.Controls.Add(this.btnEvnExcel);
            this.pnlResListMidMid.Controls.Add(this.btnDetach);
            this.pnlResListMidMid.Controls.Add(this.btnAttach);
            this.pnlResListMidMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResListMidMid.Location = new System.Drawing.Point(212, 0);
            this.pnlResListMidMid.Name = "pnlResListMidMid";
            this.pnlResListMidMid.Size = new System.Drawing.Size(59, 415);
            this.pnlResListMidMid.TabIndex = 2;
            // 
            // btnEvnExcel
            // 
            this.btnEvnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEvnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEvnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnEvnExcel.Image")));
            this.btnEvnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEvnExcel.Location = new System.Drawing.Point(3, 388);
            this.btnEvnExcel.Name = "btnEvnExcel";
            this.btnEvnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnEvnExcel.TabIndex = 21;
            this.btnEvnExcel.Click += new System.EventHandler(this.btnEvnExcel_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Location = new System.Drawing.Point(17, 210);
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
            this.btnAttach.Location = new System.Drawing.Point(17, 181);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 16;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlResListMidLeft
            // 
            this.pnlResListMidLeft.Controls.Add(this.lisRes);
            this.pnlResListMidLeft.Controls.Add(this.lblRes);
            this.pnlResListMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResListMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlResListMidLeft.Name = "pnlResListMidLeft";
            this.pnlResListMidLeft.Size = new System.Drawing.Size(212, 415);
            this.pnlResListMidLeft.TabIndex = 1;
            // 
            // lisRes
            // 
            this.lisRes.AllowDrop = true;
            this.lisRes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRes.EnableSort = true;
            this.lisRes.EnableSortIcon = true;
            this.lisRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRes.FullRowSelect = true;
            this.lisRes.Location = new System.Drawing.Point(0, 14);
            this.lisRes.Name = "lisRes";
            this.lisRes.Size = new System.Drawing.Size(212, 401);
            this.lisRes.TabIndex = 15;
            this.lisRes.UseCompatibleStateImageBehavior = false;
            this.lisRes.View = System.Windows.Forms.View.Details;
            this.lisRes.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisRes_ItemDrag);
            this.lisRes.Click += new System.EventHandler(this.lisRes_Click);
            this.lisRes.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisRes_DragDrop);
            this.lisRes.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisRes_DragEnter);
            this.lisRes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisRes_MouseDown);
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
            this.lblRes.Size = new System.Drawing.Size(212, 14);
            this.lblRes.TabIndex = 13;
            this.lblRes.Text = "Resource - Event Relation";
            // 
            // pnlResListTop
            // 
            this.pnlResListTop.Controls.Add(this.txtEventDesc);
            this.pnlResListTop.Controls.Add(this.txtEvent);
            this.pnlResListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResListTop.Location = new System.Drawing.Point(3, 16);
            this.pnlResListTop.Name = "pnlResListTop";
            this.pnlResListTop.Size = new System.Drawing.Size(485, 30);
            this.pnlResListTop.TabIndex = 0;
            // 
            // txtEventDesc
            // 
            this.txtEventDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDesc.Location = new System.Drawing.Point(142, 0);
            this.txtEventDesc.MaxLength = 200;
            this.txtEventDesc.Name = "txtEventDesc";
            this.txtEventDesc.ReadOnly = true;
            this.txtEventDesc.Size = new System.Drawing.Size(338, 20);
            this.txtEventDesc.TabIndex = 11;
            this.txtEventDesc.TabStop = false;
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(4, 0);
            this.txtEvent.MaxLength = 20;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.ReadOnly = true;
            this.txtEvent.Size = new System.Drawing.Size(134, 20);
            this.txtEvent.TabIndex = 10;
            this.txtEvent.TabStop = false;
            // 
            // splEvent
            // 
            this.splEvent.Location = new System.Drawing.Point(227, 3);
            this.splEvent.Name = "splEvent";
            this.splEvent.Size = new System.Drawing.Size(3, 464);
            this.splEvent.TabIndex = 18;
            this.splEvent.TabStop = false;
            // 
            // pnlRelatedRes
            // 
            this.pnlRelatedRes.Controls.Add(this.lisEventBase);
            this.pnlRelatedRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRelatedRes.Location = new System.Drawing.Point(3, 3);
            this.pnlRelatedRes.Name = "pnlRelatedRes";
            this.pnlRelatedRes.Size = new System.Drawing.Size(224, 464);
            this.pnlRelatedRes.TabIndex = 0;
            // 
            // lisEventBase
            // 
            this.lisEventBase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lisEventBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEventBase.EnableSort = true;
            this.lisEventBase.EnableSortIcon = true;
            this.lisEventBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEventBase.FullRowSelect = true;
            this.lisEventBase.Location = new System.Drawing.Point(0, 0);
            this.lisEventBase.MultiSelect = false;
            this.lisEventBase.Name = "lisEventBase";
            this.lisEventBase.Size = new System.Drawing.Size(224, 464);
            this.lisEventBase.TabIndex = 0;
            this.lisEventBase.UseCompatibleStateImageBehavior = false;
            this.lisEventBase.View = System.Windows.Forms.View.Details;
            this.lisEventBase.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisEventBase_ColumnClick);
            this.lisEventBase.SelectedIndexChanged += new System.EventHandler(this.lisEventBase_SelectedIndexChanged);
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Event";
            this.ColumnHeader7.Width = 100;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Description";
            this.ColumnHeader8.Width = 130;
            // 
            // tbpSubResource
            // 
            this.tbpSubResource.Controls.Add(this.grpSubResource);
            this.tbpSubResource.Controls.Add(this.splSubRes);
            this.tbpSubResource.Controls.Add(this.pnlSubResource);
            this.tbpSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpSubResource.Location = new System.Drawing.Point(4, 22);
            this.tbpSubResource.Name = "tbpSubResource";
            this.tbpSubResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSubResource.Size = new System.Drawing.Size(724, 470);
            this.tbpSubResource.TabIndex = 2;
            this.tbpSubResource.Text = "Sub Resource";
            // 
            // grpSubResource
            // 
            this.grpSubResource.Controls.Add(this.pnlSubResourceMid);
            this.grpSubResource.Controls.Add(this.pnlEventTopSub);
            this.grpSubResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSubResource.Location = new System.Drawing.Point(230, 3);
            this.grpSubResource.Name = "grpSubResource";
            this.grpSubResource.Size = new System.Drawing.Size(491, 464);
            this.grpSubResource.TabIndex = 4;
            this.grpSubResource.TabStop = false;
            // 
            // pnlSubResourceMid
            // 
            this.pnlSubResourceMid.Controls.Add(this.pnlSubResourceMidMid);
            this.pnlSubResourceMid.Controls.Add(this.pnlSubResourceMidRight);
            this.pnlSubResourceMid.Controls.Add(this.pnlSubResourceMidLeft);
            this.pnlSubResourceMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubResourceMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubResourceMid.Name = "pnlSubResourceMid";
            this.pnlSubResourceMid.Size = new System.Drawing.Size(485, 415);
            this.pnlSubResourceMid.TabIndex = 1;
            this.pnlSubResourceMid.Resize += new System.EventHandler(this.pnlSubResourceMid_Resize);
            // 
            // pnlSubResourceMidMid
            // 
            this.pnlSubResourceMidMid.Controls.Add(this.btnSubResExcel);
            this.pnlSubResourceMidMid.Controls.Add(this.btndelSub);
            this.pnlSubResourceMidMid.Controls.Add(this.btnAddSub);
            this.pnlSubResourceMidMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubResourceMidMid.Location = new System.Drawing.Point(218, 0);
            this.pnlSubResourceMidMid.Name = "pnlSubResourceMidMid";
            this.pnlSubResourceMidMid.Size = new System.Drawing.Size(75, 415);
            this.pnlSubResourceMidMid.TabIndex = 2;
            // 
            // btnSubResExcel
            // 
            this.btnSubResExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubResExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubResExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnSubResExcel.Image")));
            this.btnSubResExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSubResExcel.Location = new System.Drawing.Point(3, 388);
            this.btnSubResExcel.Name = "btnSubResExcel";
            this.btnSubResExcel.Size = new System.Drawing.Size(24, 24);
            this.btnSubResExcel.TabIndex = 20;
            this.btnSubResExcel.Click += new System.EventHandler(this.btnSubResExcel_Click);
            // 
            // btndelSub
            // 
            this.btndelSub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndelSub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btndelSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelSub.Location = new System.Drawing.Point(25, 210);
            this.btndelSub.Name = "btndelSub";
            this.btndelSub.Size = new System.Drawing.Size(24, 24);
            this.btndelSub.TabIndex = 17;
            this.btndelSub.Text = ">";
            this.btndelSub.Click += new System.EventHandler(this.btndelSub_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSub.Location = new System.Drawing.Point(25, 181);
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Size = new System.Drawing.Size(24, 24);
            this.btnAddSub.TabIndex = 16;
            this.btnAddSub.Text = "<";
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // pnlSubResourceMidRight
            // 
            this.pnlSubResourceMidRight.Controls.Add(this.lisEventListSub);
            this.pnlSubResourceMidRight.Controls.Add(this.libEventListSub);
            this.pnlSubResourceMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSubResourceMidRight.Location = new System.Drawing.Point(293, 0);
            this.pnlSubResourceMidRight.Name = "pnlSubResourceMidRight";
            this.pnlSubResourceMidRight.Size = new System.Drawing.Size(192, 415);
            this.pnlSubResourceMidRight.TabIndex = 3;
            // 
            // lisEventListSub
            // 
            this.lisEventListSub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader19,
            this.ColumnHeader20});
            this.lisEventListSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEventListSub.EnableSort = true;
            this.lisEventListSub.EnableSortIcon = true;
            this.lisEventListSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEventListSub.FullRowSelect = true;
            this.lisEventListSub.Location = new System.Drawing.Point(0, 14);
            this.lisEventListSub.Name = "lisEventListSub";
            this.lisEventListSub.Size = new System.Drawing.Size(192, 401);
            this.lisEventListSub.TabIndex = 16;
            this.lisEventListSub.UseCompatibleStateImageBehavior = false;
            this.lisEventListSub.View = System.Windows.Forms.View.Details;
            this.lisEventListSub.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisEventListSub_ColumnClick);
            // 
            // ColumnHeader19
            // 
            this.ColumnHeader19.Text = "Event";
            this.ColumnHeader19.Width = 100;
            // 
            // ColumnHeader20
            // 
            this.ColumnHeader20.Text = "Description";
            this.ColumnHeader20.Width = 150;
            // 
            // libEventListSub
            // 
            this.libEventListSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.libEventListSub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.libEventListSub.Location = new System.Drawing.Point(0, 0);
            this.libEventListSub.Name = "libEventListSub";
            this.libEventListSub.Size = new System.Drawing.Size(192, 14);
            this.libEventListSub.TabIndex = 14;
            this.libEventListSub.Text = "All Event List";
            // 
            // pnlSubResourceMidLeft
            // 
            this.pnlSubResourceMidLeft.Controls.Add(this.lisEventSub);
            this.pnlSubResourceMidLeft.Controls.Add(this.lblEventSub);
            this.pnlSubResourceMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubResourceMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlSubResourceMidLeft.Name = "pnlSubResourceMidLeft";
            this.pnlSubResourceMidLeft.Size = new System.Drawing.Size(218, 415);
            this.pnlSubResourceMidLeft.TabIndex = 1;
            // 
            // lisEventSub
            // 
            this.lisEventSub.AllowDrop = true;
            this.lisEventSub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader21,
            this.ColumnHeader22});
            this.lisEventSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEventSub.EnableSort = true;
            this.lisEventSub.EnableSortIcon = true;
            this.lisEventSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEventSub.FullRowSelect = true;
            this.lisEventSub.Location = new System.Drawing.Point(0, 14);
            this.lisEventSub.Name = "lisEventSub";
            this.lisEventSub.Size = new System.Drawing.Size(218, 401);
            this.lisEventSub.TabIndex = 15;
            this.lisEventSub.UseCompatibleStateImageBehavior = false;
            this.lisEventSub.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader21
            // 
            this.ColumnHeader21.Text = "Event";
            this.ColumnHeader21.Width = 100;
            // 
            // ColumnHeader22
            // 
            this.ColumnHeader22.Text = "Description";
            this.ColumnHeader22.Width = 150;
            // 
            // lblEventSub
            // 
            this.lblEventSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEventSub.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventSub.Location = new System.Drawing.Point(0, 0);
            this.lblEventSub.Name = "lblEventSub";
            this.lblEventSub.Size = new System.Drawing.Size(218, 14);
            this.lblEventSub.TabIndex = 13;
            this.lblEventSub.Text = "Sub Resource - Event Relation";
            // 
            // pnlEventTopSub
            // 
            this.pnlEventTopSub.Controls.Add(this.txtSubResDesc);
            this.pnlEventTopSub.Controls.Add(this.txtSubRes);
            this.pnlEventTopSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEventTopSub.Location = new System.Drawing.Point(3, 16);
            this.pnlEventTopSub.Name = "pnlEventTopSub";
            this.pnlEventTopSub.Size = new System.Drawing.Size(485, 30);
            this.pnlEventTopSub.TabIndex = 0;
            // 
            // txtSubResDesc
            // 
            this.txtSubResDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubResDesc.Location = new System.Drawing.Point(143, 0);
            this.txtSubResDesc.MaxLength = 200;
            this.txtSubResDesc.Name = "txtSubResDesc";
            this.txtSubResDesc.ReadOnly = true;
            this.txtSubResDesc.Size = new System.Drawing.Size(338, 20);
            this.txtSubResDesc.TabIndex = 11;
            this.txtSubResDesc.TabStop = false;
            // 
            // txtSubRes
            // 
            this.txtSubRes.Location = new System.Drawing.Point(3, 0);
            this.txtSubRes.MaxLength = 20;
            this.txtSubRes.Name = "txtSubRes";
            this.txtSubRes.ReadOnly = true;
            this.txtSubRes.Size = new System.Drawing.Size(134, 20);
            this.txtSubRes.TabIndex = 10;
            this.txtSubRes.TabStop = false;
            // 
            // splSubRes
            // 
            this.splSubRes.Location = new System.Drawing.Point(227, 3);
            this.splSubRes.Name = "splSubRes";
            this.splSubRes.Size = new System.Drawing.Size(3, 464);
            this.splSubRes.TabIndex = 3;
            this.splSubRes.TabStop = false;
            // 
            // pnlSubResource
            // 
            this.pnlSubResource.Controls.Add(this.lisSubResource);
            this.pnlSubResource.Controls.Add(this.pnlSubType);
            this.pnlSubResource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubResource.Location = new System.Drawing.Point(3, 3);
            this.pnlSubResource.Name = "pnlSubResource";
            this.pnlSubResource.Size = new System.Drawing.Size(224, 464);
            this.pnlSubResource.TabIndex = 2;
            // 
            // lisSubResource
            // 
            this.lisSubResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader23,
            this.ColumnHeader24});
            this.lisSubResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSubResource.EnableSort = true;
            this.lisSubResource.EnableSortIcon = true;
            this.lisSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSubResource.FullRowSelect = true;
            this.lisSubResource.Location = new System.Drawing.Point(0, 60);
            this.lisSubResource.MultiSelect = false;
            this.lisSubResource.Name = "lisSubResource";
            this.lisSubResource.Size = new System.Drawing.Size(224, 404);
            this.lisSubResource.TabIndex = 1;
            this.lisSubResource.UseCompatibleStateImageBehavior = false;
            this.lisSubResource.View = System.Windows.Forms.View.Details;
            this.lisSubResource.SelectedIndexChanged += new System.EventHandler(this.lisSubResource_SelectedIndexChanged);
            // 
            // ColumnHeader23
            // 
            this.ColumnHeader23.Text = "Sub Resource";
            this.ColumnHeader23.Width = 100;
            // 
            // ColumnHeader24
            // 
            this.ColumnHeader24.Text = "Description";
            this.ColumnHeader24.Width = 150;
            // 
            // pnlSubType
            // 
            this.pnlSubType.Controls.Add(this.cdvResID);
            this.pnlSubType.Controls.Add(this.lblResID);
            this.pnlSubType.Controls.Add(this.cdvSubType);
            this.pnlSubType.Controls.Add(this.lblResType);
            this.pnlSubType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubType.Location = new System.Drawing.Point(0, 0);
            this.pnlSubType.Name = "pnlSubType";
            this.pnlSubType.Size = new System.Drawing.Size(224, 60);
            this.pnlSubType.TabIndex = 0;
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(88, 32);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = true;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(130, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 3;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 130;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cvdResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(4, 34);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 2;
            this.lblResID.Text = "Resource ID";
            // 
            // cdvSubType
            // 
            this.cdvSubType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubType.BtnToolTipText = "";
            this.cdvSubType.DescText = "";
            this.cdvSubType.DisplaySubItemIndex = -1;
            this.cdvSubType.DisplayText = "";
            this.cdvSubType.Focusing = null;
            this.cdvSubType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubType.Index = 0;
            this.cdvSubType.IsViewBtnImage = false;
            this.cdvSubType.Location = new System.Drawing.Point(88, 8);
            this.cdvSubType.MaxLength = 20;
            this.cdvSubType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubType.Name = "cdvSubType";
            this.cdvSubType.ReadOnly = true;
            this.cdvSubType.SearchSubItemIndex = 0;
            this.cdvSubType.SelectedDescIndex = -1;
            this.cdvSubType.SelectedSubItemIndex = -1;
            this.cdvSubType.SelectionStart = 0;
            this.cdvSubType.Size = new System.Drawing.Size(130, 20);
            this.cdvSubType.SmallImageList = null;
            this.cdvSubType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubType.TabIndex = 1;
            this.cdvSubType.TextBoxToolTipText = "";
            this.cdvSubType.TextBoxWidth = 130;
            this.cdvSubType.VisibleButton = true;
            this.cdvSubType.VisibleColumnHeader = false;
            this.cdvSubType.VisibleDescription = false;
            this.cdvSubType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubType_SelectedItemChanged);
            this.cdvSubType.ButtonPress += new System.EventHandler(this.cdvSubType_ButtonPress);
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Location = new System.Drawing.Point(4, 10);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Event";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 150;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Event";
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 150;
            // 
            // ColumnHeader17
            // 
            this.ColumnHeader17.Text = "Resource";
            this.ColumnHeader17.Width = 100;
            // 
            // ColumnHeader18
            // 
            this.ColumnHeader18.Text = "Description";
            this.ColumnHeader18.Width = 150;
            // 
            // frmRASSetupAttachEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmRASSetupAttachEvent";
            this.Text = "Resource - Event Relation Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupAttachEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupAttachEvent_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabResOper.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlEvent.ResumeLayout(false);
            this.grpEvent.ResumeLayout(false);
            this.pnlEventMid.ResumeLayout(false);
            this.pnlEventMidMid.ResumeLayout(false);
            this.pnlEventMidRight.ResumeLayout(false);
            this.pnlEventMidLeft.ResumeLayout(false);
            this.pnlEventTop.ResumeLayout(false);
            this.pnlEventTop.PerformLayout();
            this.pnlResource.ResumeLayout(false);
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.tbpEvent.ResumeLayout(false);
            this.pnlReslist.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.pnlResListMid.ResumeLayout(false);
            this.pnlResListMidRight.ResumeLayout(false);
            this.pnlResListMidMid.ResumeLayout(false);
            this.pnlResListMidLeft.ResumeLayout(false);
            this.pnlResListTop.ResumeLayout(false);
            this.pnlResListTop.PerformLayout();
            this.pnlRelatedRes.ResumeLayout(false);
            this.tbpSubResource.ResumeLayout(false);
            this.grpSubResource.ResumeLayout(false);
            this.pnlSubResourceMid.ResumeLayout(false);
            this.pnlSubResourceMidMid.ResumeLayout(false);
            this.pnlSubResourceMidRight.ResumeLayout(false);
            this.pnlSubResourceMidLeft.ResumeLayout(false);
            this.pnlEventTopSub.ResumeLayout(false);
            this.pnlEventTopSub.PerformLayout();
            this.pnlSubResource.ResumeLayout(false);
            this.pnlSubType.ResumeLayout(false);
            this.pnlSubType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubType)).EndInit();
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
                case "ATTACH_EVENT":
                    
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
                    if (lisEventlist.SelectedItems.Count <= 0)
                    {
                        if (lisEventlist.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisEventlist.Items[0].Selected = true;
                            lisEventlist.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_EVENT":
                    
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
                    if (lisEvent.SelectedItems.Count <= 0)
                    {
                        if (lisEvent.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisEvent.Items[0].Selected = true;
                            lisEvent.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_EVENT_SUB":
                    
                    if (lisSubResource.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisSubResource.Items.Count > 0)
                        {
                            lisSubResource.Items[0].Selected = true;
                            lisSubResource.Focus();
                        }
                        return false;
                    }
                    if (lisEventListSub.SelectedItems.Count <= 0)
                    {
                        if (lisEventListSub.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisEventListSub.Items[0].Selected = true;
                            lisEventListSub.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_EVENT_SUB":
                    
                    if (lisSubResource.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisSubResource.Items.Count > 0)
                        {
                            lisSubResource.Items[0].Selected = true;
                            lisSubResource.Focus();
                        }
                        return false;
                    }
                    if (lisEventSub.SelectedItems.Count <= 0)
                    {
                        if (lisEventSub.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisEventSub.Items[0].Selected = true;
                            lisEventSub.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_RES":
                    
                    if (lisEventBase.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisEventBase.Items.Count > 0)
                        {
                            lisEventBase.Items[0].Selected = true;
                            lisEventBase.Focus();
                        }
                        return false;
                    }
                    if (lisReslist.SelectedItems.Count <= 0)
                    {
                        if (lisReslist.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisReslist.Items[0].Selected = true;
                            lisReslist.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_RES":
                    
                    if (lisEventBase.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisEventBase.Items.Count > 0)
                        {
                            lisEventBase.Items[0].Selected = true;
                            lisEventBase.Focus();
                        }
                        return false;
                    }
                    if (lisRes.SelectedItems.Count <= 0)
                    {
                        if (lisRes.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisRes.Items[0].Selected = true;
                            lisRes.Focus();
                        }
                        return false;
                    }
                    break;
            }
            
            return true;
        }
        
        // Update_Resource_Event()
        //       - Create/Update/Delete Resource - Event Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String, ByVal sEvent As String, ByVal sRes As String
        //
        private bool Update_Resource_Event(char ProcStep, string sEvent, string sRes)
        {
            TRSNode in_node = new TRSNode("Update_Resource_Event_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("EVENT_ID", sEvent);
            in_node.AddString("RES_ID", sRes);

            if (MessageCaster.CallService("RAS", "RAS_Update_Resource_Event", in_node, ref out_node) == false)
            {
                MPCF.ShowMsgBox(MPMH.StatusMessage);
                return false;
            }

            if (out_node.StatusValue == MPGC.MP_WARN_STATUS || (out_node.MsgCate == MPGC.MP_MSG_CATE_WARN && out_node.MsgCode == "RAS-0088"))
            {
                if (MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg + "  " + MPCF.GetMessage(10), out_node.DBErrMsg, out_node.FieldMsg, MSGBOX_ICON_TYPE.WARNING), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }

                in_node.ProcStep = MPGC.MP_STEP_DELETE_FORCE;

                if (MPCR.CallService("RAS", "RAS_Update_Resource_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            else
            {
                if (MPCR.CheckContinueProc(out_node) == false)
                {
                    return false;
                }
            }

            return true;
        }
        
        // Update_Sub_Resource_Event()
        //       - Create/Update/Delete Sub Resource - Event Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String, ByVal sEvent As String, ByVal sRes As String
        //
        private bool Update_Sub_Resource_Event(char ProcStep, string sEvent, string sRes, string sSubRes)
        {
            TRSNode in_node = new TRSNode("Update_Sub_Resource_Event_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("EVENT_ID", sEvent);
            in_node.AddString("RES_ID", sRes);
            in_node.AddString("SUBRES_ID", sSubRes);

            if (MessageCaster.CallService("RAS", "RAS_Update_Sub_Resource_Event", in_node, ref out_node) == false)
            {
                MPCF.ShowMsgBox(MPMH.StatusMessage);
                return false;
            }

            if (out_node.StatusValue == MPGC.MP_WARN_STATUS || (out_node.MsgCate == MPGC.MP_MSG_CATE_WARN && out_node.MsgCode == "RAS-0088"))
            {
                if (MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg + "  " + MPCF.GetMessage(10), out_node.DBErrMsg, out_node.FieldMsg), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }

                in_node.ProcStep = MPGC.MP_STEP_DELETE_FORCE;

                if (MPCR.CallService("RAS", "RAS_Update_Sub_Resource_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            else
            {
                if (MPCR.CheckContinueProc(out_node) == false)
                {
                    return false;
                }    
            }

            return true;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabResOper;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupAttachEvent_Load(object sender, System.EventArgs e)
        {
            
            MPCF.InitListView(lisResource);
            MPCF.InitListView(lisEvent);
            MPCF.InitListView(lisEventlist);
            MPCF.InitListView(lisEventBase);
            MPCF.InitListView(lisRes);
            MPCF.InitListView(lisReslist);
            MPCF.InitListView(lisResource);
            MPCF.InitListView(lisEventSub);
            MPCF.InitListView(lisEventListSub);
            
        }
        
        private void frmRASSetupAttachEvent_Activated(object sender, System.EventArgs e)
        {
            int i;
            ListViewItem itmX;
            
            if (b_load_flag == false)
            {
                
                pnlEvent_Resize(null, null);
                pnlReslist_Resize(null, null);
                pnlSubResourceMid_Resize(null, null);
                
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
                if (RASLIST.ViewResourceList(lisReslist, false) == false)
                {
                    return;
                }
                if (RASLIST.ViewEventList(lisEventBase, '1', "", null, "") == false)
                {
                    return;
                }
                else
                {
                    if (lisEventBase.Items.Count > 0)
                    {
                        lisEventBase.Items[0].Selected = true;
                    }
                }
                if (RASLIST.ViewEventList(lisEventlist, '1', "", null, "") == false)
                {
                    return;
                }
                else
                {
                    // Copy Listview Item
                    for (i = 0; i <= lisEventlist.Items.Count - 1; i++)
                    {
                        itmX = new ListViewItem(lisEventlist.Items[i].Text, (int)SMALLICON_INDEX.IDX_EVENT);
                        itmX.SubItems.Add(lisEventlist.Items[i].SubItems[1]);
                        lisEventListSub.Items.Add(itmX);
                    }
                }
                
                btnProcess.Visible = false;
                b_load_flag = true;
            }
            
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisEventlist.SelectedItems.Count];

            SelectClear(lisEvent);
            if (CheckCondition("ATTACH_EVENT") == false)
            {
                return;
            }
            for (i = 0; i <= lisEventlist.SelectedItems.Count - 1; i++)
            {
                sEvent = lisEventlist.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisEvent, sEvent, false) == false)
                {
                    if (Update_Resource_Event(MPGC.MP_STEP_CREATE, sEvent, sRes) == true)
                    {
                        sSelect[i] = sEvent;
                        itmX = lisEvent.Items.Add(sEvent, (int)SMALLICON_INDEX.IDX_EVENT);
                        itmX.SubItems.Add(lisEventlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisEventlist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisEvent, sSelect[j], false);
                        }
                        SelectClear(lisEventlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sEvent;
                    iIdx = lisEventlist.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewResEventList(lisEvent, '1', lisResource.SelectedItems[0].Text, null, "") == false)
            {
                return;
            }
            SelectClear(lisEventlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisEventlist.Items.Count - 1)
                {
                    lisEventlist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisEvent, sSelect[i], false);
            }
            
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT") == false)
            {
                return;
            }
            iCount = lisEvent.SelectedItems.Count;
            SelectClear(lisEventlist);
            for (i = lisEvent.SelectedItems.Count - 1; i >= 0; i--)
            {
                sEvent = lisEvent.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (Update_Resource_Event(MPGC.MP_STEP_DELETE, sEvent, sRes) == true)
                {
                    iIdx = lisEvent.SelectedItems[i].Index;
                    lisEvent.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisEventlist, sEvent, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisEvent.Items.Count)
                {
                    lisEvent.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisReslist.SelectedItems.Count];
            if (CheckCondition("ATTACH_RES") == false)
            {
                return;
            }
            SelectClear(lisRes);
            for (i = 0; i <= lisReslist.SelectedItems.Count - 1; i++)
            {
                sEvent = lisEventBase.SelectedItems[0].Text;
                sRes = lisReslist.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRes, sRes, false) == false)
                {
                    if (Update_Resource_Event(MPGC.MP_STEP_CREATE, sEvent, sRes) == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRes.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itmX.SubItems.Add(lisReslist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisReslist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisRes, sSelect[j], false);
                        }
                        SelectClear(lisReslist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisReslist.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewResEventList(lisRes, '2', lisEventBase.SelectedItems[0].Text, null, "") == false)
            {
                return;
            }
            SelectClear(lisReslist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisReslist.Items.Count - 1)
                {
                    lisReslist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisRes, sSelect[i], false);
            }
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES") == false)
            {
                return;
            }
            iCount = lisRes.SelectedItems.Count;
            SelectClear(lisReslist);
            for (i = lisRes.SelectedItems.Count - 1; i >= 0; i--)
            {
                sEvent = lisEventBase.SelectedItems[0].Text;
                sRes = lisRes.SelectedItems[i].Text;
                
                if (Update_Resource_Event(MPGC.MP_STEP_DELETE, sEvent, sRes) == true)
                {
                    iIdx = lisRes.SelectedItems[i].Index;
                    lisRes.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisReslist, sRes, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRes.Items.Count)
                {
                    lisRes.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisResource_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            MPCF.ClearList(lisEvent, true);
            MPCF.FieldClear(grpEvent);
            if (lisResource.SelectedItems.Count > 0)
            {
                RASLIST.ViewResEventList(lisEvent, '1', lisResource.SelectedItems[0].Text, null, "");
                txtResid.Text = lisResource.SelectedItems[0].Text;
                txtDesc.Text = lisResource.SelectedItems[0].SubItems[1].Text;
            }
            
        }
        
        private void lisEventBase_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ClearList(lisRes, true);
            MPCF.FieldClear(grpRes);
            if (lisEventBase.SelectedItems.Count > 0)
            {
                RASLIST.ViewResEventList(lisRes, '2', lisEventBase.SelectedItems[0].Text, null, "");
                txtEvent.Text = lisEventBase.SelectedItems[0].Text;
                txtEventDesc.Text = lisEventBase.SelectedItems[0].SubItems[1].Text;
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
                    MPCF.ClearList(lisEvent, true);
                    txtResid.Text = "";
                    txtDesc.Text = "";
                }
            }
            
        }
        
        private void pnlEvent_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlEventMid, pnlEventMidLeft, pnlEventMidRight, pnlEventMidMid, 40);
            
        }
        
        private void pnlReslist_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlResListMid, pnlResListMidLeft, pnlResListMidRight, pnlResListMidMid, 40);
            
        }
        
        private void lisEvent_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisEvent_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sEvent;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisEventlist.SelectedItems.Count];
            SelectClear(lisEvent);
            if (CheckCondition("ATTACH_EVENT") == false)
            {
                return;
            }
            for (i = 0; i <= lisEventlist.SelectedItems.Count - 1; i++)
            {
                sEvent = lisEventlist.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisEvent, sEvent, false) == false)
                {
                    if (Update_Resource_Event(MPGC.MP_STEP_CREATE, sEvent, sRes) == true)
                    {
                        sSelect[i] = sEvent;
                        itmX = lisEvent.Items.Add(sEvent, (int)SMALLICON_INDEX.IDX_EVENT);
                        itmX.SubItems.Add(lisEventlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisEventlist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisEvent, sSelect[j], false);
                        }
                        SelectClear(lisEventlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sEvent;
                    iIdx = lisEventlist.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewResEventList(lisEvent, '1', lisResource.SelectedItems[0].Text, null, "") == false)
            {
                return;
            }
            SelectClear(lisEventlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisEventlist.Items.Count - 1)
                {
                    lisEventlist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisEvent, sSelect[i], false);
            }
            
        }
        
        private void lisEventlist_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisEventlist.DoDragDrop(lisEventlist.SelectedItems[0].Text, DragDropEffects.Copy);
            
        }
        
        private void lisRes_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisRes_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sEvent;
            string sRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisReslist.SelectedItems.Count];
            if (CheckCondition("ATTACH_RES") == false)
            {
                return;
            }
            SelectClear(lisRes);
            for (i = 0; i <= lisReslist.SelectedItems.Count - 1; i++)
            {
                sEvent = lisEventBase.SelectedItems[0].Text;
                sRes = lisReslist.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisRes, sRes, false) == false)
                {
                    if (Update_Resource_Event(MPGC.MP_STEP_CREATE, sEvent, sRes) == true)
                    {
                        sSelect[i] = sRes;
                        itmX = lisRes.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itmX.SubItems.Add(lisReslist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisReslist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisRes, sSelect[j], false);
                        }
                        SelectClear(lisReslist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sRes;
                    iIdx = lisReslist.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewResEventList(lisRes, '2', lisEventBase.SelectedItems[0].Text, null, "") == false)
            {
                return;
            }
            SelectClear(lisReslist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisReslist.Items.Count - 1)
                {
                    lisReslist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisRes, sSelect[i], false);
            }
            
        }
        
        private void lisReslist_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisReslist.DoDragDrop(lisReslist.SelectedItems[0].Text, DragDropEffects.Copy);
            
        }
        
        private void lisReslist_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisReslist_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sEvent;
            string sRes;
            int i;
            int iIdx = 0;
            int iCount;
            
            if (CheckCondition("DETACH_RES") == false)
            {
                return;
            }
            iCount = lisEventBase.SelectedItems.Count;
            SelectClear(lisReslist);
            for (i = lisRes.SelectedItems.Count - 1; i >= 0; i--)
            {
                sEvent = lisEventBase.SelectedItems[0].Text;
                sRes = lisRes.SelectedItems[i].Text;
                if (Update_Resource_Event(MPGC.MP_STEP_DELETE, sEvent, sRes) == true)
                {
                    iIdx = lisRes.SelectedItems[i].Index;
                    lisRes.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisReslist, sRes, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisRes.Items.Count)
                {
                    lisRes.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisRes_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisRes.DoDragDrop(lisRes.SelectedItems[0].Text, DragDropEffects.Move);
            
        }
        
        private void lisEventlist_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisEventlist_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sEvent;
            string sRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT") == false)
            {
                return;
            }
            iCount = lisEvent.SelectedItems.Count;
            SelectClear(lisEventlist);
            for (i = lisEvent.SelectedItems.Count - 1; i >= 0; i--)
            {
                sEvent = lisEvent.SelectedItems[i].Text;
                sRes = lisResource.SelectedItems[0].Text;
                if (Update_Resource_Event(MPGC.MP_STEP_DELETE, sEvent, sRes) == true)
                {
                    iIdx = lisEvent.SelectedItems[i].Index;
                    lisEvent.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisEventlist, sEvent, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisEvent.Items.Count)
                {
                    lisEvent.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisEvent_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisEvent.DoDragDrop(lisEvent.SelectedItems[0].Text, DragDropEffects.Move);
            
        }
        private void lisRes_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisRes.AllowDrop = false;
            lisReslist.AllowDrop = true;
            
        }
        
        private void lisReslist_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisReslist.AllowDrop = false;
            lisRes.AllowDrop = true;
            
        }
        
        private void lisEvent_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisEvent.AllowDrop = false;
            lisEventlist.AllowDrop = true;
            
        }
        
        private void lisEventlist_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisEventlist.AllowDrop = false;
            lisEvent.AllowDrop = true;
            
        }
        
        private void lisEventlist_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisEvent);
            
        }
        
        private void lisEvent_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisEventlist);
            
        }
        
        private void lisRes_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisReslist);
            
        }
        
        private void lisReslist_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisRes);
            
        }
        
        private void tabResOper_Click(object sender, System.EventArgs e)
        {
            
        }
        
        private void tabResOper_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (sender.SelectedIndex == 2)
            //{
            //    //If ViewSubResourceList(lisSubResource, "3", cdvSubType.Text) = False Then
            //    //    Exit Sub
            //    //Else
            //    //    If lisResource.Items.Count > 0 Then
            //    //        lisResource.Items.Item(0).Selected = True
            //    //    End If
            //    //End If
            //}
        }
        
        private void btnAddSub_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            string sSubRes;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisEventListSub.SelectedItems.Count];
            SelectClear(lisEventSub);
            if (CheckCondition("ATTACH_EVENT_SUB") == false)
            {
                return;
            }
            sRes = cdvResID.Text;
            for (i = 0; i <= lisEventListSub.SelectedItems.Count - 1; i++)
            {
                sEvent = lisEventListSub.SelectedItems[i].Text;
                sSubRes = lisSubResource.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisEventSub, sEvent, false) == false)
                {
                    if (Update_Sub_Resource_Event(MPGC.MP_STEP_CREATE, sEvent, sRes, sSubRes) == true)
                    {
                        sSelect[i] = sEvent;
                        itmX = lisEventSub.Items.Add(sEvent, (int)SMALLICON_INDEX.IDX_EVENT);
                        itmX.SubItems.Add(lisEventListSub.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisEventListSub.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisEventSub, sSelect[j], false);
                        }
                        SelectClear(lisEventListSub);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sEvent;
                    iIdx = lisEventListSub.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewSubResEventList(lisEventSub, '1', sRes, lisSubResource.SelectedItems[0].Text, null, "") == false)
            {
                return;
            }
            SelectClear(lisEventListSub);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisEventListSub.Items.Count - 1)
                {
                    lisEventListSub.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisEventSub, sSelect[i], false);
            }
        }
        
        private void btndelSub_Click(System.Object sender, System.EventArgs e)
        {
            string sEvent;
            string sRes;
            string sSubRes;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT_SUB") == false)
            {
                return;
            }
            iCount = lisEventSub.SelectedItems.Count;
            SelectClear(lisEventListSub);
            sRes = cdvResID.Text;
            for (i = lisEventSub.SelectedItems.Count - 1; i >= 0; i--)
            {
                sEvent = lisEventSub.SelectedItems[i].Text;
                sSubRes = lisSubResource.SelectedItems[0].Text;
                if (Update_Sub_Resource_Event(MPGC.MP_STEP_DELETE, sEvent, sRes, sSubRes) == true)
                {
                    iIdx = lisEventSub.SelectedItems[i].Index;
                    lisEventSub.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisEventListSub, sEvent, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisEventSub.Items.Count)
                {
                    lisEventSub.Items[iIdx].Selected = true;
                }
            }
        }
        
        private void lisSubResource_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.ClearList(lisEventSub, true);
            MPCF.FieldClear(grpSubResource);
            if (lisSubResource.SelectedItems.Count > 0)
            {
                RASLIST.ViewSubResEventList(lisEventSub, '1', cdvResID.Text, lisSubResource.SelectedItems[0].Text, null, "");
                txtSubRes.Text = lisSubResource.SelectedItems[0].Text;
                txtSubResDesc.Text = lisSubResource.SelectedItems[0].SubItems[1].Text;
            }
            
        }
        
        private void cdvSubType_ButtonPress(object sender, System.EventArgs e)
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
        
        private void cdvSubType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvResID.Text = "";
            txtSubRes.Text = "";
            txtSubResDesc.Text = "";
            MPCF.ClearList(lisSubResource, true);
            MPCF.ClearList(lisEventSub, true);
            
        }
        
        private void cvdResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            int temp_int = 0;

            if (RASLIST.ViewSubResourceList(lisSubResource, '5', cdvResID.Text, "", "", cdvSubType.Text, false, null, ref temp_int) == true)
            {
                if (lisSubResource.Items.Count > 0)
                {
                    lisSubResource.Items[0].Selected = true;
                }
                else
                {
                    MPCF.ClearList(lisEventSub, true);
                    txtSubRes.Text = "";
                    txtSubResDesc.Text = "";
                }
            }
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewResourceList(cdvResID.GetListView, "", cdvSubType.Text, false) == false)
            {
                return;
            }
            
        }
        
        private void pnlSubResourceMid_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlSubResourceMid, pnlSubResourceMidLeft, pnlSubResourceMidRight, pnlSubResourceMidMid, 40);
            
        }
        
        private void lisEventlist_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            try
            {
                //ViewEventList(lisEventlist, "1")
                //View ?´í›„ Sorting ?´ì•¼ ? ì??
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisReslist_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            try
            {
                //ViewResourceList(lisReslist, "1")
                //View ?´í›„ Sorting ?´ì•¼ ? ì??
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisEventListSub_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            try
            {
                //ViewEventList(lisEventListSub, "1")
                //View ?´í›„ Sorting ?´ì•¼ ? ì??
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisEventBase_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            try
            {
                //ViewEventList(lisEventBase, "1")
                //View ?´í›„ Sorting ?´ì•¼ ? ì??
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSubResExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sText = string.Empty;


                sText = this.Text + " - " + lisSubResource.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisEventSub, sText, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnEvnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sText = string.Empty;


                sText = this.Text + " - " + lisEventBase.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisRes, sText, "");
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
                string sCond = string.Empty;


                sCond = "Resource ID : " + lisResource.SelectedItems[0].Text;


                MPCF.ExportToExcel(lisEvent, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
    }
    
}
