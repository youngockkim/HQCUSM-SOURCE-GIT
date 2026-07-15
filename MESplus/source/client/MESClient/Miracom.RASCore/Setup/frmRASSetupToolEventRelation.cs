
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
//   File Name   : frmRASSetupToolEventRelation.vb
//   Description : Attach event to Resource Form
//
//   MES Version : 4.1.0.0
//
//   Function List

//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Tool_Event_Relation() : Create/Update/Delete Resource - Event Relation
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
//#If _TOOL = True Then


namespace Miracom.RASCore
{
    public class frmRASSetupToolEventRelation : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupToolEventRelation()
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
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader17;
        private System.Windows.Forms.ColumnHeader ColumnHeader18;
        private System.Windows.Forms.Splitter splRes;
        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Splitter splEvent;
        private System.Windows.Forms.Panel Panel1;
        private Miracom.UI.Controls.MCListView.MCListView lisToolList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private Miracom.UI.Controls.MCListView.MCListView lisToolEventlist;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Button btnEventDel;
        private System.Windows.Forms.Button btnEventAdd;
        private System.Windows.Forms.Label lblAttachedToolEvent;
        private System.Windows.Forms.Label lblToolEventList;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.Label lblToolType2;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private Miracom.UI.Controls.MCListView.MCListView lisToolList2;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.Button btnToolDel;
        private System.Windows.Forms.Button btnToolAdd;
        private System.Windows.Forms.Label lblAttachedTool;
        private System.Windows.Forms.Label lblToolList;
        private System.Windows.Forms.TabControl tabToolEventRelation;
        private Miracom.UI.Controls.MCListView.MCListView lisToolEventList2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType2;
        private System.Windows.Forms.GroupBox grpTool;
        private System.Windows.Forms.GroupBox grpEvent;
        private System.Windows.Forms.Panel pnlToolMid;
        private System.Windows.Forms.Panel pnlToolMidMid;
        private System.Windows.Forms.Panel pnlToolMidRight;
        private System.Windows.Forms.Panel pnlToolMidLeft;
        private System.Windows.Forms.Panel pnlEventMid;
        private System.Windows.Forms.Panel pnlEventMidRight;
        private System.Windows.Forms.Panel pnlEventMidMid;
        private System.Windows.Forms.Panel pnlEventMidLeft;
        private System.Windows.Forms.Panel pnlRelatedEvent;
        private System.Windows.Forms.Panel pnlTool;
        private System.Windows.Forms.Panel pnlToolList;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.TabPage tbpTool;
        private System.Windows.Forms.TabPage tbpToolEvent;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachedEvent;
        protected Button btnTolEvtExcel;
        protected Button btnTolExcel;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachedTool;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupToolEventRelation));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabToolEventRelation = new System.Windows.Forms.TabControl();
            this.tbpTool = new System.Windows.Forms.TabPage();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.grpTool = new System.Windows.Forms.GroupBox();
            this.pnlToolMid = new System.Windows.Forms.Panel();
            this.pnlToolMidMid = new System.Windows.Forms.Panel();
            this.btnTolEvtExcel = new System.Windows.Forms.Button();
            this.btnEventDel = new System.Windows.Forms.Button();
            this.btnEventAdd = new System.Windows.Forms.Button();
            this.pnlToolMidRight = new System.Windows.Forms.Panel();
            this.lisToolEventlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblToolEventList = new System.Windows.Forms.Label();
            this.pnlToolMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachedEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAttachedToolEvent = new System.Windows.Forms.Label();
            this.splRes = new System.Windows.Forms.Splitter();
            this.pnlToolList = new System.Windows.Forms.Panel();
            this.lisToolList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlType = new System.Windows.Forms.Panel();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tbpToolEvent = new System.Windows.Forms.TabPage();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.pnlEventMid = new System.Windows.Forms.Panel();
            this.pnlEventMidRight = new System.Windows.Forms.Panel();
            this.lisToolList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblToolList = new System.Windows.Forms.Label();
            this.pnlEventMidMid = new System.Windows.Forms.Panel();
            this.btnTolExcel = new System.Windows.Forms.Button();
            this.btnToolDel = new System.Windows.Forms.Button();
            this.btnToolAdd = new System.Windows.Forms.Button();
            this.pnlEventMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachedTool = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAttachedTool = new System.Windows.Forms.Label();
            this.splEvent = new System.Windows.Forms.Splitter();
            this.pnlRelatedEvent = new System.Windows.Forms.Panel();
            this.lisToolEventList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblToolType2 = new System.Windows.Forms.Label();
            this.cdvType2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabToolEventRelation.SuspendLayout();
            this.tbpTool.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.grpTool.SuspendLayout();
            this.pnlToolMid.SuspendLayout();
            this.pnlToolMidMid.SuspendLayout();
            this.pnlToolMidRight.SuspendLayout();
            this.pnlToolMidLeft.SuspendLayout();
            this.pnlToolList.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.tbpToolEvent.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.grpEvent.SuspendLayout();
            this.pnlEventMid.SuspendLayout();
            this.pnlEventMidRight.SuspendLayout();
            this.pnlEventMidMid.SuspendLayout();
            this.pnlEventMidLeft.SuspendLayout();
            this.pnlRelatedEvent.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Tool Event Relation Setup";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabToolEventRelation);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(5);
            this.pnlTab.Size = new System.Drawing.Size(742, 513);
            this.pnlTab.TabIndex = 0;
            // 
            // tabToolEventRelation
            // 
            this.tabToolEventRelation.Controls.Add(this.tbpTool);
            this.tabToolEventRelation.Controls.Add(this.tbpToolEvent);
            this.tabToolEventRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabToolEventRelation.ItemSize = new System.Drawing.Size(60, 18);
            this.tabToolEventRelation.Location = new System.Drawing.Point(5, 5);
            this.tabToolEventRelation.Name = "tabToolEventRelation";
            this.tabToolEventRelation.SelectedIndex = 0;
            this.tabToolEventRelation.Size = new System.Drawing.Size(732, 503);
            this.tabToolEventRelation.TabIndex = 0;
            this.tabToolEventRelation.TabStop = false;
            // 
            // tbpTool
            // 
            this.tbpTool.Controls.Add(this.pnlTool);
            this.tbpTool.Controls.Add(this.splRes);
            this.tbpTool.Controls.Add(this.pnlToolList);
            this.tbpTool.Location = new System.Drawing.Point(4, 22);
            this.tbpTool.Name = "tbpTool";
            this.tbpTool.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTool.Size = new System.Drawing.Size(724, 477);
            this.tbpTool.TabIndex = 0;
            this.tbpTool.Text = "Tool";
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.grpTool);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTool.Location = new System.Drawing.Point(230, 3);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(491, 471);
            this.pnlTool.TabIndex = 1;
            this.pnlTool.Resize += new System.EventHandler(this.pnlTool_Resize);
            // 
            // grpTool
            // 
            this.grpTool.Controls.Add(this.pnlToolMid);
            this.grpTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTool.Location = new System.Drawing.Point(0, 0);
            this.grpTool.Name = "grpTool";
            this.grpTool.Size = new System.Drawing.Size(491, 471);
            this.grpTool.TabIndex = 0;
            this.grpTool.TabStop = false;
            // 
            // pnlToolMid
            // 
            this.pnlToolMid.Controls.Add(this.pnlToolMidMid);
            this.pnlToolMid.Controls.Add(this.pnlToolMidRight);
            this.pnlToolMid.Controls.Add(this.pnlToolMidLeft);
            this.pnlToolMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolMid.Location = new System.Drawing.Point(3, 16);
            this.pnlToolMid.Name = "pnlToolMid";
            this.pnlToolMid.Size = new System.Drawing.Size(485, 452);
            this.pnlToolMid.TabIndex = 0;
            // 
            // pnlToolMidMid
            // 
            this.pnlToolMidMid.Controls.Add(this.btnTolEvtExcel);
            this.pnlToolMidMid.Controls.Add(this.btnEventDel);
            this.pnlToolMidMid.Controls.Add(this.btnEventAdd);
            this.pnlToolMidMid.Location = new System.Drawing.Point(240, 32);
            this.pnlToolMidMid.Name = "pnlToolMidMid";
            this.pnlToolMidMid.Size = new System.Drawing.Size(38, 134);
            this.pnlToolMidMid.TabIndex = 1;
            // 
            // btnTolEvtExcel
            // 
            this.btnTolEvtExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTolEvtExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTolEvtExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTolEvtExcel.Image")));
            this.btnTolEvtExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTolEvtExcel.Location = new System.Drawing.Point(3, 107);
            this.btnTolEvtExcel.Name = "btnTolEvtExcel";
            this.btnTolEvtExcel.Size = new System.Drawing.Size(24, 24);
            this.btnTolEvtExcel.TabIndex = 6;
            this.btnTolEvtExcel.Click += new System.EventHandler(this.btnTolEvtExcel_Click);
            // 
            // btnEventDel
            // 
            this.btnEventDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEventDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEventDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventDel.Location = new System.Drawing.Point(7, 70);
            this.btnEventDel.Name = "btnEventDel";
            this.btnEventDel.Size = new System.Drawing.Size(24, 24);
            this.btnEventDel.TabIndex = 1;
            this.btnEventDel.Text = ">";
            this.btnEventDel.Click += new System.EventHandler(this.btnEventDel_Click);
            // 
            // btnEventAdd
            // 
            this.btnEventAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEventAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEventAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventAdd.Location = new System.Drawing.Point(7, 41);
            this.btnEventAdd.Name = "btnEventAdd";
            this.btnEventAdd.Size = new System.Drawing.Size(24, 24);
            this.btnEventAdd.TabIndex = 0;
            this.btnEventAdd.Text = "<";
            this.btnEventAdd.Click += new System.EventHandler(this.btnEventAdd_Click);
            // 
            // pnlToolMidRight
            // 
            this.pnlToolMidRight.Controls.Add(this.lisToolEventlist);
            this.pnlToolMidRight.Controls.Add(this.lblToolEventList);
            this.pnlToolMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlToolMidRight.Location = new System.Drawing.Point(293, 0);
            this.pnlToolMidRight.Name = "pnlToolMidRight";
            this.pnlToolMidRight.Size = new System.Drawing.Size(192, 452);
            this.pnlToolMidRight.TabIndex = 2;
            // 
            // lisToolEventlist
            // 
            this.lisToolEventlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisToolEventlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolEventlist.EnableSort = true;
            this.lisToolEventlist.EnableSortIcon = true;
            this.lisToolEventlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolEventlist.FullRowSelect = true;
            this.lisToolEventlist.Location = new System.Drawing.Point(0, 14);
            this.lisToolEventlist.Name = "lisToolEventlist";
            this.lisToolEventlist.Size = new System.Drawing.Size(192, 438);
            this.lisToolEventlist.TabIndex = 1;
            this.lisToolEventlist.UseCompatibleStateImageBehavior = false;
            this.lisToolEventlist.View = System.Windows.Forms.View.Details;
            this.lisToolEventlist.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisToolEventlist_ItemDrag);
            this.lisToolEventlist.Click += new System.EventHandler(this.lisToolEventlist_Click);
            this.lisToolEventlist.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisToolEventlist_DragDrop);
            this.lisToolEventlist.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisToolEventlist_DragEnter);
            this.lisToolEventlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisToolEventlist_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Tool Event";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // lblToolEventList
            // 
            this.lblToolEventList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToolEventList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolEventList.Location = new System.Drawing.Point(0, 0);
            this.lblToolEventList.Name = "lblToolEventList";
            this.lblToolEventList.Size = new System.Drawing.Size(192, 14);
            this.lblToolEventList.TabIndex = 0;
            this.lblToolEventList.Text = "All Tool Event List";
            // 
            // pnlToolMidLeft
            // 
            this.pnlToolMidLeft.Controls.Add(this.lisAttachedEvent);
            this.pnlToolMidLeft.Controls.Add(this.lblAttachedToolEvent);
            this.pnlToolMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlToolMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlToolMidLeft.Name = "pnlToolMidLeft";
            this.pnlToolMidLeft.Size = new System.Drawing.Size(218, 452);
            this.pnlToolMidLeft.TabIndex = 0;
            // 
            // lisAttachedEvent
            // 
            this.lisAttachedEvent.AllowDrop = true;
            this.lisAttachedEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisAttachedEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachedEvent.EnableSort = true;
            this.lisAttachedEvent.EnableSortIcon = true;
            this.lisAttachedEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachedEvent.FullRowSelect = true;
            this.lisAttachedEvent.Location = new System.Drawing.Point(0, 14);
            this.lisAttachedEvent.Name = "lisAttachedEvent";
            this.lisAttachedEvent.Size = new System.Drawing.Size(218, 438);
            this.lisAttachedEvent.TabIndex = 1;
            this.lisAttachedEvent.UseCompatibleStateImageBehavior = false;
            this.lisAttachedEvent.View = System.Windows.Forms.View.Details;
            this.lisAttachedEvent.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisAttachedEvent_ItemDrag);
            this.lisAttachedEvent.Click += new System.EventHandler(this.lisAttachedEvent_Click);
            this.lisAttachedEvent.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisAttachedEvent_DragDrop);
            this.lisAttachedEvent.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisAttachedEvent_DragEnter);
            this.lisAttachedEvent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisAttachedEvent_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Tool Event";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Description";
            this.ColumnHeader14.Width = 150;
            // 
            // lblAttachedToolEvent
            // 
            this.lblAttachedToolEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachedToolEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachedToolEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachedToolEvent.Location = new System.Drawing.Point(0, 0);
            this.lblAttachedToolEvent.Name = "lblAttachedToolEvent";
            this.lblAttachedToolEvent.Size = new System.Drawing.Size(218, 14);
            this.lblAttachedToolEvent.TabIndex = 0;
            this.lblAttachedToolEvent.Text = "Attached Tool Event";
            // 
            // splRes
            // 
            this.splRes.Location = new System.Drawing.Point(227, 3);
            this.splRes.Name = "splRes";
            this.splRes.Size = new System.Drawing.Size(3, 471);
            this.splRes.TabIndex = 2;
            this.splRes.TabStop = false;
            // 
            // pnlToolList
            // 
            this.pnlToolList.Controls.Add(this.lisToolList);
            this.pnlToolList.Controls.Add(this.pnlType);
            this.pnlToolList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlToolList.Location = new System.Drawing.Point(3, 3);
            this.pnlToolList.Name = "pnlToolList";
            this.pnlToolList.Size = new System.Drawing.Size(224, 471);
            this.pnlToolList.TabIndex = 0;
            // 
            // lisToolList
            // 
            this.lisToolList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisToolList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolList.EnableSort = true;
            this.lisToolList.EnableSortIcon = true;
            this.lisToolList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolList.FullRowSelect = true;
            this.lisToolList.Location = new System.Drawing.Point(0, 40);
            this.lisToolList.MultiSelect = false;
            this.lisToolList.Name = "lisToolList";
            this.lisToolList.Size = new System.Drawing.Size(224, 431);
            this.lisToolList.TabIndex = 1;
            this.lisToolList.UseCompatibleStateImageBehavior = false;
            this.lisToolList.View = System.Windows.Forms.View.Details;
            this.lisToolList.SelectedIndexChanged += new System.EventHandler(this.lisToolList_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Tool";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.lblToolType);
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(0, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(224, 40);
            this.pnlType.TabIndex = 0;
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Location = new System.Drawing.Point(4, 13);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(55, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
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
            // tbpToolEvent
            // 
            this.tbpToolEvent.Controls.Add(this.pnlEvent);
            this.tbpToolEvent.Controls.Add(this.splEvent);
            this.tbpToolEvent.Controls.Add(this.pnlRelatedEvent);
            this.tbpToolEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpToolEvent.Name = "tbpToolEvent";
            this.tbpToolEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tbpToolEvent.Size = new System.Drawing.Size(724, 477);
            this.tbpToolEvent.TabIndex = 1;
            this.tbpToolEvent.Text = "Tool Event";
            this.tbpToolEvent.Visible = false;
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.grpEvent);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvent.Location = new System.Drawing.Point(230, 3);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(491, 471);
            this.pnlEvent.TabIndex = 1;
            this.pnlEvent.Resize += new System.EventHandler(this.pnlEvent_Resize);
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.pnlEventMid);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(0, 0);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(491, 471);
            this.grpEvent.TabIndex = 1;
            this.grpEvent.TabStop = false;
            // 
            // pnlEventMid
            // 
            this.pnlEventMid.Controls.Add(this.pnlEventMidRight);
            this.pnlEventMid.Controls.Add(this.pnlEventMidMid);
            this.pnlEventMid.Controls.Add(this.pnlEventMidLeft);
            this.pnlEventMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventMid.Location = new System.Drawing.Point(3, 16);
            this.pnlEventMid.Name = "pnlEventMid";
            this.pnlEventMid.Size = new System.Drawing.Size(485, 452);
            this.pnlEventMid.TabIndex = 0;
            // 
            // pnlEventMidRight
            // 
            this.pnlEventMidRight.Controls.Add(this.lisToolList2);
            this.pnlEventMidRight.Controls.Add(this.lblToolList);
            this.pnlEventMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEventMidRight.Location = new System.Drawing.Point(293, 0);
            this.pnlEventMidRight.Name = "pnlEventMidRight";
            this.pnlEventMidRight.Size = new System.Drawing.Size(192, 452);
            this.pnlEventMidRight.TabIndex = 2;
            // 
            // lisToolList2
            // 
            this.lisToolList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisToolList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolList2.EnableSort = true;
            this.lisToolList2.EnableSortIcon = true;
            this.lisToolList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolList2.FullRowSelect = true;
            this.lisToolList2.Location = new System.Drawing.Point(0, 14);
            this.lisToolList2.Name = "lisToolList2";
            this.lisToolList2.Size = new System.Drawing.Size(192, 438);
            this.lisToolList2.TabIndex = 1;
            this.lisToolList2.UseCompatibleStateImageBehavior = false;
            this.lisToolList2.View = System.Windows.Forms.View.Details;
            this.lisToolList2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisToollist2_ItemDrag);
            this.lisToolList2.Click += new System.EventHandler(this.lisToollist2_Click);
            this.lisToolList2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisToollist2_DragDrop);
            this.lisToolList2.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisToollist2_DragEnter);
            this.lisToolList2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisToollist2_MouseDown);
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Tool";
            this.ColumnHeader9.Width = 100;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Description";
            this.ColumnHeader10.Width = 150;
            // 
            // lblToolList
            // 
            this.lblToolList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToolList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolList.Location = new System.Drawing.Point(0, 0);
            this.lblToolList.Name = "lblToolList";
            this.lblToolList.Size = new System.Drawing.Size(192, 14);
            this.lblToolList.TabIndex = 0;
            this.lblToolList.Text = "All Tool List";
            // 
            // pnlEventMidMid
            // 
            this.pnlEventMidMid.Controls.Add(this.btnTolExcel);
            this.pnlEventMidMid.Controls.Add(this.btnToolDel);
            this.pnlEventMidMid.Controls.Add(this.btnToolAdd);
            this.pnlEventMidMid.Location = new System.Drawing.Point(240, 32);
            this.pnlEventMidMid.Name = "pnlEventMidMid";
            this.pnlEventMidMid.Size = new System.Drawing.Size(38, 134);
            this.pnlEventMidMid.TabIndex = 1;
            // 
            // btnTolExcel
            // 
            this.btnTolExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTolExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTolExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTolExcel.Image")));
            this.btnTolExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTolExcel.Location = new System.Drawing.Point(3, 107);
            this.btnTolExcel.Name = "btnTolExcel";
            this.btnTolExcel.Size = new System.Drawing.Size(24, 24);
            this.btnTolExcel.TabIndex = 7;
            this.btnTolExcel.Click += new System.EventHandler(this.btnTolExcel_Click);
            // 
            // btnToolDel
            // 
            this.btnToolDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToolDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToolDel.Location = new System.Drawing.Point(7, 70);
            this.btnToolDel.Name = "btnToolDel";
            this.btnToolDel.Size = new System.Drawing.Size(24, 24);
            this.btnToolDel.TabIndex = 1;
            this.btnToolDel.Text = ">";
            this.btnToolDel.Click += new System.EventHandler(this.btnToolDel_Click);
            // 
            // btnToolAdd
            // 
            this.btnToolAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToolAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToolAdd.Location = new System.Drawing.Point(7, 41);
            this.btnToolAdd.Name = "btnToolAdd";
            this.btnToolAdd.Size = new System.Drawing.Size(24, 24);
            this.btnToolAdd.TabIndex = 0;
            this.btnToolAdd.Text = "<";
            this.btnToolAdd.Click += new System.EventHandler(this.btnToolAdd_Click);
            // 
            // pnlEventMidLeft
            // 
            this.pnlEventMidLeft.Controls.Add(this.lisAttachedTool);
            this.pnlEventMidLeft.Controls.Add(this.lblAttachedTool);
            this.pnlEventMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEventMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlEventMidLeft.Name = "pnlEventMidLeft";
            this.pnlEventMidLeft.Size = new System.Drawing.Size(218, 452);
            this.pnlEventMidLeft.TabIndex = 0;
            // 
            // lisAttachedTool
            // 
            this.lisAttachedTool.AllowDrop = true;
            this.lisAttachedTool.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisAttachedTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachedTool.EnableSort = true;
            this.lisAttachedTool.EnableSortIcon = true;
            this.lisAttachedTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachedTool.FullRowSelect = true;
            this.lisAttachedTool.Location = new System.Drawing.Point(0, 14);
            this.lisAttachedTool.Name = "lisAttachedTool";
            this.lisAttachedTool.Size = new System.Drawing.Size(218, 438);
            this.lisAttachedTool.TabIndex = 1;
            this.lisAttachedTool.UseCompatibleStateImageBehavior = false;
            this.lisAttachedTool.View = System.Windows.Forms.View.Details;
            this.lisAttachedTool.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisAttachedTool_ItemDrag);
            this.lisAttachedTool.Click += new System.EventHandler(this.lisAttachedTool_Click);
            this.lisAttachedTool.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisAttachedTool_DragDrop);
            this.lisAttachedTool.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisAttachedTool_DragEnter);
            this.lisAttachedTool.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisAttachedTool_MouseDown);
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Tool";
            this.ColumnHeader11.Width = 100;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Description";
            this.ColumnHeader12.Width = 150;
            // 
            // lblAttachedTool
            // 
            this.lblAttachedTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachedTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachedTool.Location = new System.Drawing.Point(0, 0);
            this.lblAttachedTool.Name = "lblAttachedTool";
            this.lblAttachedTool.Size = new System.Drawing.Size(218, 14);
            this.lblAttachedTool.TabIndex = 0;
            this.lblAttachedTool.Text = "Attached Tool";
            // 
            // splEvent
            // 
            this.splEvent.Location = new System.Drawing.Point(227, 3);
            this.splEvent.Name = "splEvent";
            this.splEvent.Size = new System.Drawing.Size(3, 471);
            this.splEvent.TabIndex = 18;
            this.splEvent.TabStop = false;
            // 
            // pnlRelatedEvent
            // 
            this.pnlRelatedEvent.Controls.Add(this.lisToolEventList2);
            this.pnlRelatedEvent.Controls.Add(this.Panel1);
            this.pnlRelatedEvent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRelatedEvent.Location = new System.Drawing.Point(3, 3);
            this.pnlRelatedEvent.Name = "pnlRelatedEvent";
            this.pnlRelatedEvent.Size = new System.Drawing.Size(224, 471);
            this.pnlRelatedEvent.TabIndex = 0;
            // 
            // lisToolEventList2
            // 
            this.lisToolEventList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lisToolEventList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolEventList2.EnableSort = true;
            this.lisToolEventList2.EnableSortIcon = true;
            this.lisToolEventList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolEventList2.FullRowSelect = true;
            this.lisToolEventList2.Location = new System.Drawing.Point(0, 40);
            this.lisToolEventList2.MultiSelect = false;
            this.lisToolEventList2.Name = "lisToolEventList2";
            this.lisToolEventList2.Size = new System.Drawing.Size(224, 431);
            this.lisToolEventList2.TabIndex = 1;
            this.lisToolEventList2.UseCompatibleStateImageBehavior = false;
            this.lisToolEventList2.View = System.Windows.Forms.View.Details;
            this.lisToolEventList2.SelectedIndexChanged += new System.EventHandler(this.lisToolEventList2_SelectedIndexChanged);
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Tool Event";
            this.ColumnHeader7.Width = 100;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Description";
            this.ColumnHeader8.Width = 150;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.lblToolType2);
            this.Panel1.Controls.Add(this.cdvType2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(224, 40);
            this.Panel1.TabIndex = 0;
            // 
            // lblToolType2
            // 
            this.lblToolType2.AutoSize = true;
            this.lblToolType2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType2.Location = new System.Drawing.Point(4, 13);
            this.lblToolType2.Name = "lblToolType2";
            this.lblToolType2.Size = new System.Drawing.Size(55, 13);
            this.lblToolType2.TabIndex = 0;
            this.lblToolType2.Text = "Tool Type";
            // 
            // cdvType2
            // 
            this.cdvType2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType2.BtnToolTipText = "";
            this.cdvType2.DescText = "";
            this.cdvType2.DisplaySubItemIndex = -1;
            this.cdvType2.DisplayText = "";
            this.cdvType2.Focusing = null;
            this.cdvType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType2.Index = 0;
            this.cdvType2.IsViewBtnImage = false;
            this.cdvType2.Location = new System.Drawing.Point(88, 11);
            this.cdvType2.MaxLength = 20;
            this.cdvType2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType2.Name = "cdvType2";
            this.cdvType2.ReadOnly = true;
            this.cdvType2.SearchSubItemIndex = 0;
            this.cdvType2.SelectedDescIndex = -1;
            this.cdvType2.SelectedSubItemIndex = -1;
            this.cdvType2.SelectionStart = 0;
            this.cdvType2.Size = new System.Drawing.Size(130, 20);
            this.cdvType2.SmallImageList = null;
            this.cdvType2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType2.TabIndex = 1;
            this.cdvType2.TextBoxToolTipText = "";
            this.cdvType2.TextBoxWidth = 130;
            this.cdvType2.VisibleButton = true;
            this.cdvType2.VisibleColumnHeader = false;
            this.cdvType2.VisibleDescription = false;
            this.cdvType2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType2_SelectedItemChanged);
            this.cdvType2.ButtonPress += new System.EventHandler(this.cdvType2_ButtonPress);
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
            // frmRASSetupToolEventRelation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlTab);
            this.Name = "frmRASSetupToolEventRelation";
            this.Text = "Tool - Event Relation Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupToolEventRelation_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupToolEventRelation_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabToolEventRelation.ResumeLayout(false);
            this.tbpTool.ResumeLayout(false);
            this.pnlTool.ResumeLayout(false);
            this.grpTool.ResumeLayout(false);
            this.pnlToolMid.ResumeLayout(false);
            this.pnlToolMidMid.ResumeLayout(false);
            this.pnlToolMidRight.ResumeLayout(false);
            this.pnlToolMidLeft.ResumeLayout(false);
            this.pnlToolList.ResumeLayout(false);
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.tbpToolEvent.ResumeLayout(false);
            this.pnlEvent.ResumeLayout(false);
            this.grpEvent.ResumeLayout(false);
            this.pnlEventMid.ResumeLayout(false);
            this.pnlEventMidRight.ResumeLayout(false);
            this.pnlEventMidMid.ResumeLayout(false);
            this.pnlEventMidLeft.ResumeLayout(false);
            this.pnlRelatedEvent.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType2)).EndInit();
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
        private bool CheckCondition(string FuncName, string sToolEvent)
        {
            
            if (sToolEvent == "Tool")
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "ATTACH_EVENT":

                        if (MPCF.CheckValue(cdvType, 1) == false)
                        {
                            return false;
                        }
                        if (lisToolList.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisToolList.Items.Count > 0)
                            {
                                lisToolList.Items[0].Selected = true;
                                lisToolList.Focus();
                            }
                            return false;
                        }
                        if (lisToolEventlist.SelectedItems.Count <= 0)
                        {
                            if (lisToolEventlist.Items.Count > 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisToolEventlist.Items[0].Selected = true;
                                lisToolEventlist.Focus();
                            }
                            return false;
                        }
                        break;
                    case "DETACH_EVENT":

                        if (MPCF.CheckValue(cdvType, 1) == false)
                        {
                            return false;
                        }
                        if (lisToolList.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisToolList.Items.Count > 0)
                            {
                                lisToolList.Items[0].Selected = true;
                                lisToolList.Focus();
                            }
                            return false;
                        }
                        if (lisAttachedEvent.SelectedItems.Count <= 0)
                        {
                            if (lisAttachedEvent.Items.Count > 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisAttachedEvent.Items[0].Selected = true;
                                lisAttachedEvent.Focus();
                            }
                            return false;
                        }
                        break;
                }
            }
            else if (sToolEvent == "Event")
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "ATTACH_EVENT":

                        if (MPCF.CheckValue(cdvType2, 1) == false)
                        {
                            return false;
                        }
                        if (lisToolEventList2.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisToolEventList2.Items.Count > 0)
                            {
                                lisToolEventList2.Items[0].Selected = true;
                                lisToolEventList2.Focus();
                            }
                            return false;
                        }
                        if (lisToolList2.SelectedItems.Count <= 0)
                        {
                            if (lisToolList2.Items.Count > 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisToolList2.Items[0].Selected = true;
                                lisToolList2.Focus();
                            }
                            return false;
                        }
                        break;
                    case "DETACH_EVENT":

                        if (MPCF.CheckValue(cdvType2, 1) == false)
                        {
                            return false;
                        }
                        if (lisToolEventList2.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisToolEventList2.Items.Count > 0)
                            {
                                lisToolEventList2.Items[0].Selected = true;
                                lisToolEventList2.Focus();
                            }
                            return false;
                        }
                        if (lisAttachedTool.SelectedItems.Count <= 0)
                        {
                            if (lisAttachedTool.Items.Count > 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                lisAttachedTool.Items[0].Selected = true;
                                lisAttachedTool.Focus();
                            }
                            return false;
                        }
                        break;
                }
            }
            
            return true;
        }
        
        // Update_Tool_Event_Relation()
        //       - Create/Update/Delete Resource - Event Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String, ByVal sToolEvent As String, ByVal sTool As String
        //
        private bool Update_Tool_Event_Relation(char ProcStep, string sToolEvent, string sTool, string sToolType)
        {
            TRSNode in_node = new TRSNode("UPDATE_TOOL_EVENT_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("TOOL_EVENT_ID", sToolEvent);
            in_node.AddString("TOOL_ID", sTool);
            in_node.AddString("TOOL_TYPE", sToolType);

            if (MPCR.CallService("RAS", "RAS_Update_Tool_Event_Relation", in_node, ref out_node) == false)
            {
                return false;
            }
             
            return true;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabToolEventRelation;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupToolEventRelation_Load(object sender, System.EventArgs e)
        {
            
            MPCF.InitListView(lisToolList);
            MPCF.InitListView(lisAttachedEvent);
            MPCF.InitListView(lisToolEventlist);
            
            MPCF.InitListView(lisToolEventList2);
            MPCF.InitListView(lisAttachedTool);
            MPCF.InitListView(lisToolList2);
            
        }
        
        private void frmRASSetupToolEventRelation_Activated(object sender, System.EventArgs e)
        {
            //            int i;
            //            ListViewItem itmX;
            
            if (b_load_flag == false)
            {
                
                pnlTool_Resize(null, null);
                pnlEvent_Resize(null, null);
                
                btnProcess.Visible = false;
                b_load_flag = true;
            }
            
        }
        
        private void btnEventAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sToolEvent;
            string sTool;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisToolEventlist.SelectedItems.Count];
            SelectClear(lisAttachedEvent);
            if (CheckCondition("ATTACH_EVENT", "Tool") == false)
            {
                return;
            }
            for (i = 0; i <= lisToolEventlist.SelectedItems.Count - 1; i++)
            {
                sToolEvent = lisToolEventlist.SelectedItems[i].Text;
                sTool = lisToolList.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisAttachedEvent, sToolEvent, false) == false)
                {
                    if (Update_Tool_Event_Relation(MPGC.MP_STEP_CREATE, sToolEvent, sTool, cdvType.Text) == true)
                    {
                        sSelect[i] = sToolEvent;
                        itmX = lisAttachedEvent.Items.Add(sToolEvent, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                        itmX.SubItems.Add(lisToolEventlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisToolEventlist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisAttachedEvent, sSelect[j], false);
                        }
                        SelectClear(lisToolEventlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sToolEvent;
                    iIdx = lisToolEventlist.SelectedItems[i].Index;
                }
            }
            if (RASLIST.ViewToolEventRelationList(lisAttachedEvent, '1', lisToolList.SelectedItems[0].Text, cdvType.Text, "", 'N', 'N', null) == false)
            {
                return;
            }
            SelectClear(lisToolEventlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisToolEventlist.Items.Count - 1)
                {
                    lisToolEventlist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisAttachedEvent, sSelect[i], false);
            }
            
        }
        
        private void btnEventDel_Click(System.Object sender, System.EventArgs e)
        {
            string sToolEvent;
            string sTool;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT", "Tool") == false)
            {
                return;
            }
            iCount = lisAttachedEvent.SelectedItems.Count;
            SelectClear(lisToolEventlist);
            for (i = lisAttachedEvent.SelectedItems.Count - 1; i >= 0; i--)
            {
                sToolEvent = lisAttachedEvent.SelectedItems[i].Text;
                sTool = lisToolList.SelectedItems[0].Text;
                if (Update_Tool_Event_Relation(MPGC.MP_STEP_DELETE, sToolEvent, sTool, cdvType.Text) == true)
                {
                    iIdx = lisAttachedEvent.SelectedItems[i].Index;
                    lisAttachedEvent.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisToolEventlist, sToolEvent, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisAttachedEvent.Items.Count)
                {
                    lisAttachedEvent.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void cdvType_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            
            RASLIST.ViewToolTypeList(cdvType.GetListView, '1', 'N', 'N', null);
            
        }
        
        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                //FieldClear(Me.pnlTool)
                MPCF.ClearList(lisToolList, true);
                MPCF.ClearList(lisAttachedEvent, true);
                MPCF.ClearList(lisToolEventlist, true);
                
                if (RASLIST.ViewToolList(lisToolList, '2', cdvType.Text, 'N', false, null) == false)
                {
                    return;
                }
                
                if (RASLIST.ViewToolEventList(lisToolEventlist, '1', cdvType.Text, 'N', null) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void pnlTool_Resize(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlToolMid, pnlToolMidLeft, pnlToolMidRight, pnlToolMidMid, 40);
            
        }
        
        private void pnlEvent_Resize(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlEventMid, pnlEventMidLeft, pnlEventMidRight, pnlEventMidMid, 40);
            
        }
        
        private void lisToolList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisAttachedEvent, true);
            MPCF.FieldClear(grpTool);
            if (lisToolList.SelectedItems.Count > 0)
            {
                RASLIST.ViewToolEventRelationList(lisAttachedEvent, '1', lisToolList.SelectedItems[0].Text, cdvType.Text, "", 'N', 'N', null);
            }
        }
        
        private void lisToolEventlist_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisToolEventlist.AllowDrop = false;
            lisAttachedEvent.AllowDrop = true;
            
        }
        
        private void lisToolEventlist_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisAttachedEvent);
            
        }
        
        private void lisToolEventlist_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisToolEventlist_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sToolEvent;
            string sTool;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT", "Tool") == false)
            {
                return;
            }
            iCount = lisAttachedEvent.SelectedItems.Count;
            SelectClear(lisToolEventlist);
            for (i = lisAttachedEvent.SelectedItems.Count - 1; i >= 0; i--)
            {
                sToolEvent = lisAttachedEvent.SelectedItems[i].Text;
                sTool = lisToolList.SelectedItems[0].Text;
                if (Update_Tool_Event_Relation(MPGC.MP_STEP_DELETE, sToolEvent, sTool, cdvType.Text) == true)
                {
                    iIdx = lisAttachedEvent.SelectedItems[i].Index;
                    lisAttachedEvent.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisToolEventlist, sToolEvent, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisAttachedEvent.Items.Count)
                {
                    lisAttachedEvent.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisToolEventlist_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisToolEventlist.DoDragDrop(lisToolEventlist.SelectedItems[0].Text, DragDropEffects.Copy);
            
        }
        
        private void lisAttachedEvent_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisAttachedEvent_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sToolEvent;
            string sTool;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisToolEventlist.SelectedItems.Count];
            SelectClear(lisAttachedEvent);
            if (CheckCondition("ATTACH_EVENT", "Tool") == false)
            {
                return;
            }
            for (i = 0; i <= lisToolEventlist.SelectedItems.Count - 1; i++)
            {
                sToolEvent = lisToolEventlist.SelectedItems[i].Text;
                sTool = lisToolList.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisAttachedEvent, sToolEvent, false) == false)
                {
                    if (Update_Tool_Event_Relation(MPGC.MP_STEP_CREATE, sToolEvent, sTool, cdvType.Text) == true)
                    {
                        sSelect[i] = sToolEvent;
                        itmX = lisAttachedEvent.Items.Add(sToolEvent, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                        itmX.SubItems.Add(lisToolEventlist.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisToolEventlist.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisAttachedEvent, sSelect[j], false);
                        }
                        SelectClear(lisToolEventlist);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sToolEvent;
                    iIdx = lisToolEventlist.SelectedItems[i].Index;
                }
            }
            
            if (RASLIST.ViewToolEventRelationList(lisAttachedEvent, '1', lisToolList.SelectedItems[0].Text, cdvType.Text, "", 'N', 'N', null) == false)
            {
                return;
            }
            
            SelectClear(lisToolEventlist);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisToolEventlist.Items.Count - 1)
                {
                    lisToolEventlist.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisAttachedEvent, sSelect[i], false);
            }
            
        }
        
        private void lisAttachedEvent_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisAttachedEvent.DoDragDrop(lisAttachedEvent.SelectedItems[0].Text, DragDropEffects.Move);
            
        }
        
        private void lisAttachedEvent_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisAttachedEvent.AllowDrop = false;
            lisToolEventlist.AllowDrop = true;
            
        }
        
        private void lisAttachedEvent_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisToolEventlist);
            
        }
        
        private void cdvType2_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            cdvType2.Init();
            MPCF.InitListView(cdvType2.GetListView);
            cdvType2.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType2.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvType2.SelectedSubItemIndex = 0;
            
            RASLIST.ViewToolTypeList(cdvType2.GetListView, '1', 'N', 'N', null);
            
        }
        
        private void cdvType2_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                //FieldClear(Me.pnlTool)
                MPCF.ClearList(lisToolEventList2, true);
                MPCF.ClearList(lisAttachedTool, true);
                MPCF.ClearList(lisToolList2, true);
                
                if (RASLIST.ViewToolList(lisToolList2, '2', cdvType2.Text, 'N', false, null) == false)
                {
                    return;
                }
                
                if (RASLIST.ViewToolEventList(lisToolEventList2, '1', cdvType2.Text, 'N', null) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisToolEventList2_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.ClearList(lisAttachedTool, true);
            MPCF.FieldClear(grpEvent);
            if (lisToolEventList2.SelectedItems.Count > 0)
            {
                RASLIST.ViewToolEventRelationList(lisAttachedTool, '2', "", cdvType2.Text, lisToolEventList2.SelectedItems[0].Text, 'N', 'N', null);
            }
        }
        
        private void btnToolAdd_Click(System.Object sender, System.EventArgs e)
        {
            string sToolEvent;
            string sTool;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisToolList2.SelectedItems.Count];
            SelectClear(lisAttachedTool);
            if (CheckCondition("ATTACH_EVENT", "Event") == false)
            {
                return;
            }
            for (i = 0; i <= lisToolList2.SelectedItems.Count - 1; i++)
            {
                sTool = lisToolList2.SelectedItems[i].Text;
                sToolEvent = lisToolEventList2.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisAttachedTool, sTool, false) == false)
                {
                    if (Update_Tool_Event_Relation(MPGC.MP_STEP_CREATE, sToolEvent, sTool, cdvType2.Text) == true)
                    {
                        sSelect[i] = sTool;
                        itmX = lisAttachedTool.Items.Add(sToolEvent, (int)SMALLICON_INDEX.IDX_TOOL);
                        itmX.SubItems.Add(lisToolList2.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisToolList2.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisAttachedTool, sSelect[j], false);
                        }
                        SelectClear(lisToolList2);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sTool;
                    iIdx = lisToolList2.SelectedItems[i].Index;
                }
            }
            
            if (RASLIST.ViewToolEventRelationList(lisAttachedTool, '2', "", cdvType2.Text, lisToolEventList2.SelectedItems[0].Text, 'N', 'N', null) == false)
            {
                return;
            }
            
            SelectClear(lisToolList2);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisToolList2.Items.Count - 1)
                {
                    lisToolList2.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisAttachedTool, sSelect[i], false);
            }
            
        }
        
        private void btnToolDel_Click(System.Object sender, System.EventArgs e)
        {
            string sToolEvent;
            string sTool;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT", "Event") == false)
            {
                return;
            }
            iCount = lisAttachedTool.SelectedItems.Count;
            SelectClear(lisToolList2);
            for (i = lisAttachedTool.SelectedItems.Count - 1; i >= 0; i--)
            {
                sTool = lisAttachedTool.SelectedItems[i].Text;
                sToolEvent = lisToolEventList2.SelectedItems[0].Text;
                if (Update_Tool_Event_Relation(MPGC.MP_STEP_DELETE, sToolEvent, sTool, cdvType2.Text) == true)
                {
                    iIdx = lisAttachedTool.SelectedItems[i].Index;
                    lisAttachedTool.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisToolList2, sTool, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisAttachedTool.Items.Count)
                {
                    lisAttachedTool.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisToollist2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisToolList2.AllowDrop = false;
            lisAttachedTool.AllowDrop = true;
            
        }
        
        private void lisToollist2_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisAttachedTool);
            
        }
        
        private void lisToollist2_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisToollist2_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sToolEvent;
            string sTool;
            int iIdx = 0;
            int i;
            int iCount;
            
            if (CheckCondition("DETACH_EVENT", "Event") == false)
            {
                return;
            }
            iCount = lisAttachedTool.SelectedItems.Count;
            SelectClear(lisToolList2);
            for (i = lisAttachedTool.SelectedItems.Count - 1; i >= 0; i--)
            {
                sTool = lisAttachedTool.SelectedItems[i].Text;
                sToolEvent = lisToolEventList2.SelectedItems[0].Text;
                if (Update_Tool_Event_Relation(MPGC.MP_STEP_DELETE, sToolEvent, sTool, cdvType2.Text) == true)
                {
                    iIdx = lisAttachedTool.SelectedItems[i].Index;
                    lisAttachedTool.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisToolList2, sTool, false);
                }
                else
                {
                    return;
                }
            }
            if (iCount == 1)
            {
                if (iIdx < lisAttachedTool.Items.Count)
                {
                    lisAttachedTool.Items[iIdx].Selected = true;
                }
            }
            
        }
        
        private void lisToollist2_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisToolList2.DoDragDrop(lisToolList2.SelectedItems[0].Text, DragDropEffects.Copy);
            
        }
        
        private void lisAttachedTool_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
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
        
        private void lisAttachedTool_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sToolEvent;
            string sTool;
            string[] sSelect = null;
            ListViewItem itmX;
            int i;
            int j;
            int iIdx = 0;
            
            sSelect = new string[lisToolList2.SelectedItems.Count];
            SelectClear(lisAttachedTool);
            if (CheckCondition("ATTACH_EVENT", "Event") == false)
            {
                return;
            }
            for (i = 0; i <= lisToolList2.SelectedItems.Count - 1; i++)
            {
                sTool = lisToolList2.SelectedItems[i].Text;
                sToolEvent = lisToolEventList2.SelectedItems[0].Text;
                if (MPCF.FindListItem(lisAttachedTool, sTool, false) == false)
                {
                    if (Update_Tool_Event_Relation(MPGC.MP_STEP_CREATE, sToolEvent, sTool, cdvType2.Text) == true)
                    {
                        sSelect[i] = sTool;
                        itmX = lisAttachedTool.Items.Add(sTool, (int)SMALLICON_INDEX.IDX_TOOL);
                        itmX.SubItems.Add(lisToolList2.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisToolList2.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= sSelect.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisAttachedTool, sSelect[j], false);
                        }
                        SelectClear(lisToolList2);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sTool;
                    iIdx = lisToolList2.SelectedItems[i].Index;
                }
            }
            
            if (RASLIST.ViewToolEventRelationList(lisAttachedTool, '2', "", cdvType2.Text, lisToolEventList2.SelectedItems[0].Text, 'N', 'N', null) == false)
            {
                return;
            }
            
            SelectClear(lisToolList2);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisToolList2.Items.Count - 1)
                {
                    lisToolList2.Items[iIdx + 1].Selected = true;
                }
            }
            for (i = 0; i <= sSelect.Length - 1; i++)
            {
                MPCF.FindListItem(lisAttachedTool, sSelect[i], false);
            }
            
        }
        
        private void lisAttachedTool_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
            lisAttachedTool.DoDragDrop(lisAttachedTool.SelectedItems[0].Text, DragDropEffects.Move);
            
        }
        
        private void lisAttachedTool_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            lisAttachedTool.AllowDrop = false;
            lisToolList2.AllowDrop = true;
            
        }
        
        private void lisAttachedTool_Click(System.Object sender, System.EventArgs e)
        {
            
            SelectClear(lisToolList2);
            
        }

        private void btnTolEvtExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                if (lisToolList.SelectedItems.Count == 0)
                    return;

                sCond = "Tool ID : " + lisToolList.SelectedItems[0].Text;

                MPCF.ExportToExcel(lisAttachedEvent, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnTolExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                if (lisToolEventList2.SelectedItems.Count == 0)
                    return;

                sCond = "Tool Event: " + lisToolEventList2.SelectedItems[0].Text;

                MPCF.ExportToExcel(lisAttachedTool, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    
    //#End If
}
