
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;

//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCViewResourceList.vb
//   Description : View Resource List
//
//   MES Version : 1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-05-10 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCViewResourceList : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewResourceList()
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
        



        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpOption;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIncludeDeleteRes;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubAreaID;
        internal System.Windows.Forms.Label lblSubAreaID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        internal System.Windows.Forms.Label lblArea;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        internal System.Windows.Forms.Label lblResType;
        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlMid;
        internal Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        internal System.Windows.Forms.ColumnHeader colSeq;
        internal System.Windows.Forms.ColumnHeader colRes;
        internal System.Windows.Forms.ColumnHeader colDesc;
        internal System.Windows.Forms.ColumnHeader colType;
        internal System.Windows.Forms.ColumnHeader colUpDown;
        internal System.Windows.Forms.ColumnHeader colPriSts;
        internal System.Windows.Forms.ColumnHeader colPrt1;
        internal System.Windows.Forms.ColumnHeader colPrt2;
        internal System.Windows.Forms.ColumnHeader colPrt3;
        internal System.Windows.Forms.ColumnHeader colPrt4;
        internal System.Windows.Forms.ColumnHeader colPrt5;
        internal System.Windows.Forms.ColumnHeader colPrt6;
        internal System.Windows.Forms.ColumnHeader colPrt7;
        internal System.Windows.Forms.ColumnHeader colPrt8;
        internal System.Windows.Forms.ColumnHeader colPrt9;
        internal System.Windows.Forms.ColumnHeader colPrt10;
        internal System.Windows.Forms.ColumnHeader colSts1;
        internal System.Windows.Forms.ColumnHeader colSts2;
        internal System.Windows.Forms.ColumnHeader colSts3;
        internal System.Windows.Forms.ColumnHeader colSts4;
        internal System.Windows.Forms.ColumnHeader colSts5;
        internal System.Windows.Forms.ColumnHeader colSts6;
        internal System.Windows.Forms.ColumnHeader colSts7;
        internal System.Windows.Forms.ColumnHeader colSts8;
        internal System.Windows.Forms.ColumnHeader colSts9;
        internal System.Windows.Forms.ColumnHeader colSts10;
        internal System.Windows.Forms.ColumnHeader colUseFac;
        internal System.Windows.Forms.ColumnHeader colLastEvent;
        internal System.Windows.Forms.ColumnHeader colLastEventTime;
        internal System.Windows.Forms.ColumnHeader colLastStartTime;
        internal System.Windows.Forms.ColumnHeader colLastEndTime;
        internal System.Windows.Forms.ColumnHeader colProcCount;
        internal System.Windows.Forms.ColumnHeader colMaxProcCount;
        internal System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        internal System.Windows.Forms.ColumnHeader colLastHistSeq;
        internal System.Windows.Forms.ColumnHeader colCreateUser;
        internal System.Windows.Forms.ColumnHeader colCreateTime;
        internal System.Windows.Forms.ColumnHeader colUpdateUser;
        internal System.Windows.Forms.ColumnHeader colUpdateTime;
        public System.Windows.Forms.Button btnExcel;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewResourceList));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkIncludeDeleteRes = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cdvSubAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblArea = new System.Windows.Forms.Label();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriSts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUseFac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastActiveHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpOption);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 72);
            this.pnlTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkIncludeDeleteRes);
            this.grpOption.Controls.Add(this.cdvSubAreaID);
            this.grpOption.Controls.Add(this.lblSubAreaID);
            this.grpOption.Controls.Add(this.cdvAreaID);
            this.grpOption.Controls.Add(this.lblArea);
            this.grpOption.Controls.Add(this.cdvType);
            this.grpOption.Controls.Add(this.lblResType);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 72);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // chkIncludeDeleteRes
            // 
            this.chkIncludeDeleteRes.AutoSize = true;
            this.chkIncludeDeleteRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeleteRes.Location = new System.Drawing.Point(15, 44);
            this.chkIncludeDeleteRes.Name = "chkIncludeDeleteRes";
            this.chkIncludeDeleteRes.Size = new System.Drawing.Size(145, 17);
            this.chkIncludeDeleteRes.TabIndex = 2;
            this.chkIncludeDeleteRes.Text = "Include Delete Resource";
            this.chkIncludeDeleteRes.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // cdvSubAreaID
            // 
            this.cdvSubAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaID.BtnToolTipText = "";
            this.cdvSubAreaID.DescText = "";
            this.cdvSubAreaID.DisplaySubItemIndex = -1;
            this.cdvSubAreaID.DisplayText = "";
            this.cdvSubAreaID.Focusing = null;
            this.cdvSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubAreaID.Index = 0;
            this.cdvSubAreaID.IsViewBtnImage = false;
            this.cdvSubAreaID.Location = new System.Drawing.Point(522, 41);
            this.cdvSubAreaID.MaxLength = 20;
            this.cdvSubAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.Name = "cdvSubAreaID";
            this.cdvSubAreaID.ReadOnly = false;
            this.cdvSubAreaID.SearchSubItemIndex = 0;
            this.cdvSubAreaID.SelectedDescIndex = -1;
            this.cdvSubAreaID.SelectedSubItemIndex = -1;
            this.cdvSubAreaID.SelectionStart = 0;
            this.cdvSubAreaID.Size = new System.Drawing.Size(200, 20);
            this.cdvSubAreaID.SmallImageList = null;
            this.cdvSubAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaID.TabIndex = 6;
            this.cdvSubAreaID.TextBoxToolTipText = "";
            this.cdvSubAreaID.TextBoxWidth = 200;
            this.cdvSubAreaID.VisibleButton = true;
            this.cdvSubAreaID.VisibleColumnHeader = false;
            this.cdvSubAreaID.VisibleDescription = false;
            this.cdvSubAreaID.ButtonPress += new System.EventHandler(this.cdvSubAreaID_ButtonPress);
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.AutoSize = true;
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubAreaID.Location = new System.Drawing.Point(418, 44);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(65, 13);
            this.lblSubAreaID.TabIndex = 5;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // cdvAreaID
            // 
            this.cdvAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaID.BtnToolTipText = "";
            this.cdvAreaID.DescText = "";
            this.cdvAreaID.DisplaySubItemIndex = -1;
            this.cdvAreaID.DisplayText = "";
            this.cdvAreaID.Focusing = null;
            this.cdvAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.Location = new System.Drawing.Point(522, 17);
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.Size = new System.Drawing.Size(200, 20);
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TabIndex = 4;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 200;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(418, 20);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(43, 13);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "Area ID";
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
            this.cdvType.Location = new System.Drawing.Point(120, 17);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(200, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 200;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.Location = new System.Drawing.Point(15, 20);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(8, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(558, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.lisResourceList);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 72);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMid.Size = new System.Drawing.Size(742, 434);
            this.pnlMid.TabIndex = 1;
            // 
            // lisResourceList
            // 
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colRes,
            this.colDesc,
            this.colType,
            this.colUpDown,
            this.colPriSts,
            this.colPrt1,
            this.colPrt2,
            this.colPrt3,
            this.colPrt4,
            this.colPrt5,
            this.colPrt6,
            this.colPrt7,
            this.colPrt8,
            this.colPrt9,
            this.colPrt10,
            this.colSts1,
            this.colSts2,
            this.colSts3,
            this.colSts4,
            this.colSts5,
            this.colSts6,
            this.colSts7,
            this.colSts8,
            this.colSts9,
            this.colSts10,
            this.colUseFac,
            this.colLastEvent,
            this.colLastEventTime,
            this.colLastStartTime,
            this.colLastEndTime,
            this.colProcCount,
            this.colMaxProcCount,
            this.colLastActiveHistSeq,
            this.colLastHistSeq,
            this.colCreateUser,
            this.colCreateTime,
            this.colUpdateUser,
            this.colUpdateTime});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(3, 3);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(736, 428);
            this.lisResourceList.TabIndex = 0;
            this.lisResourceList.TabStop = false;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 50;
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 130;
            // 
            // colType
            // 
            this.colType.Text = "Res Type";
            this.colType.Width = 90;
            // 
            // colUpDown
            // 
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 70;
            // 
            // colPriSts
            // 
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 120;
            // 
            // colPrt1
            // 
            this.colPrt1.Text = "Status Prompt 1";
            this.colPrt1.Width = 120;
            // 
            // colPrt2
            // 
            this.colPrt2.Text = "Status Prompt 2";
            this.colPrt2.Width = 120;
            // 
            // colPrt3
            // 
            this.colPrt3.Text = "Status Prompt 3";
            this.colPrt3.Width = 120;
            // 
            // colPrt4
            // 
            this.colPrt4.Text = "Status Prompt 4";
            this.colPrt4.Width = 120;
            // 
            // colPrt5
            // 
            this.colPrt5.Text = "Status Prompt 5";
            this.colPrt5.Width = 120;
            // 
            // colPrt6
            // 
            this.colPrt6.Text = "Status Prompt 6";
            this.colPrt6.Width = 120;
            // 
            // colPrt7
            // 
            this.colPrt7.Text = "Status Prompt 7";
            this.colPrt7.Width = 120;
            // 
            // colPrt8
            // 
            this.colPrt8.Text = "Status Prompt 8";
            this.colPrt8.Width = 120;
            // 
            // colPrt9
            // 
            this.colPrt9.Text = "Status Prompt 9";
            this.colPrt9.Width = 120;
            // 
            // colPrt10
            // 
            this.colPrt10.Text = "Status Prompt 10";
            this.colPrt10.Width = 120;
            // 
            // colSts1
            // 
            this.colSts1.Text = "Status 1";
            this.colSts1.Width = 120;
            // 
            // colSts2
            // 
            this.colSts2.Text = "Status 2";
            this.colSts2.Width = 120;
            // 
            // colSts3
            // 
            this.colSts3.Text = "Status 3";
            this.colSts3.Width = 120;
            // 
            // colSts4
            // 
            this.colSts4.Text = "Status 4";
            this.colSts4.Width = 120;
            // 
            // colSts5
            // 
            this.colSts5.Text = "Status 5";
            this.colSts5.Width = 120;
            // 
            // colSts6
            // 
            this.colSts6.Text = "Status 6";
            this.colSts6.Width = 120;
            // 
            // colSts7
            // 
            this.colSts7.Text = "Status 7";
            this.colSts7.Width = 120;
            // 
            // colSts8
            // 
            this.colSts8.Text = "Status 8";
            this.colSts8.Width = 120;
            // 
            // colSts9
            // 
            this.colSts9.Text = "Status 9";
            this.colSts9.Width = 120;
            // 
            // colSts10
            // 
            this.colSts10.Text = "Status 10";
            this.colSts10.Width = 120;
            // 
            // colUseFac
            // 
            this.colUseFac.Text = "Use Fac Prt Flag";
            this.colUseFac.Width = 100;
            // 
            // colLastEvent
            // 
            this.colLastEvent.Text = "Last Event";
            this.colLastEvent.Width = 100;
            // 
            // colLastEventTime
            // 
            this.colLastEventTime.Text = "Last Event Time";
            this.colLastEventTime.Width = 120;
            // 
            // colLastStartTime
            // 
            this.colLastStartTime.Text = "Last Start Time";
            this.colLastStartTime.Width = 120;
            // 
            // colLastEndTime
            // 
            this.colLastEndTime.Text = "Last End Time";
            this.colLastEndTime.Width = 120;
            // 
            // colProcCount
            // 
            this.colProcCount.Text = "Proc Lot Count";
            this.colProcCount.Width = 100;
            // 
            // colMaxProcCount
            // 
            this.colMaxProcCount.Text = "Max Proc Count";
            this.colMaxProcCount.Width = 100;
            // 
            // colLastActiveHistSeq
            // 
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.Width = 120;
            // 
            // colLastHistSeq
            // 
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.Width = 100;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 110;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.Text = "Update User";
            this.colUpdateUser.Width = 110;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 120;
            // 
            // frmSPCViewResourceList
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewResourceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Resource List Detail";
            this.Activated += new System.EventHandler(this.frmSPCViewResourceList_Activated);
            this.Load += new System.EventHandler(this.frmSPCViewResourceList_Load);
            this.pnlTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        private bool b_load_flag;
        #endregion
        
        #region " Function Implementation"
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCViewResourceList_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisResourceList);
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.frmSPCViewResourceList_Activated()\n" + ex.Message);
            }
            
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvType.Init();
                MPCF.InitListView(cdvType.GetListView);
                cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
                cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvType.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
                if (cdvType.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.cdvType_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvAreaID.Init();
                MPCF.InitListView(cdvAreaID.GetListView);
                cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
                cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvAreaID.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE);
                if (cdvAreaID.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.cdvAreaID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvSubAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE);
                if (cdvSubAreaID.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.cdvSubAreaID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                RASLIST.ViewResourceListDetail(lisResourceList, cdvType.Text, "", cdvAreaID.Text, cdvSubAreaID.Text, "", chkIncludeDeleteRes.Checked, true, "", false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewResourceList_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.frmSPCViewResourceList_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;

                sCond = "Resource Type : " + MPCF.Trim(cdvType.Text);
                MPCF.ExportToExcel(lisResourceList, this.Text, sCond);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewResourceList.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
