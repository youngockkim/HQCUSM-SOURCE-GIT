#define _ORD
#define _POP
#define _SPC
#define _RMS
#define _CRR
#define _ALM
#define _INV
#define _TOOL
#define _BOM
#define _QCM
#define _UTL
#define _RTD
#define _RCP
#define _EDC
#define _RAS

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.UTLCore;
using Miracom.SPCCore;

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCResourceListMain.vb
//   Description : View Resource List
//
//   SPC Version : 1.0.0
//
//   Function List
//       - View_Resource_List : View Resource List
//       -  SetArea : Setting Area at "frmMIDMain"
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCClient
{
    public class frmSPCResourceListMain : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCResourceListMain()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.TextBox txtTotRes;
        internal System.Windows.Forms.Label lblTotRes;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnExcel;
        internal System.Windows.Forms.Button btnRefresh;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.Label lblAutoRefresh;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoRefresh;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.ListView lisResourceList;
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
        internal System.Windows.Forms.ColumnHeader colLot1;
        internal System.Windows.Forms.ColumnHeader colLot2;
        internal System.Windows.Forms.ColumnHeader colLot3;
        internal System.Windows.Forms.ColumnHeader colLot4;
        internal System.Windows.Forms.ColumnHeader colLot5;
        internal System.Windows.Forms.ColumnHeader colLot6;
        internal System.Windows.Forms.ColumnHeader colLot7;
        internal System.Windows.Forms.ColumnHeader colLot8;
        internal System.Windows.Forms.ColumnHeader colLot9;
        internal System.Windows.Forms.ColumnHeader colLot10;
        internal System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        internal System.Windows.Forms.ColumnHeader colLastHistSeq;
        internal System.Windows.Forms.ColumnHeader colCreateUser;
        internal System.Windows.Forms.ColumnHeader colCreateTime;
        internal System.Windows.Forms.ColumnHeader colUpdateUser;
        internal System.Windows.Forms.ColumnHeader colUpdateTime;
        internal System.Windows.Forms.Timer tmrTimer;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            base.Load += new System.EventHandler(frmSPCResourceListMain_Load);
            base.Closed += new System.EventHandler(frmSPCResourceListMain_Closed);
            base.Activated += new System.EventHandler(frmSPCResourceListMain_Activated);
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSPCResourceListMain));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblAutoRefresh = new System.Windows.Forms.Label();
            this.chkAutoRefresh = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtTotRes = new System.Windows.Forms.TextBox();
            this.lblTotRes = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClose.Click += new System.EventHandler(btnClose_Click);
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnExcel.Click += new System.EventHandler(btnExcel_Click);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(cdvType_ButtonPress);
            this.lblType = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.lisResourceList = new System.Windows.Forms.ListView();
            this.lisResourceList.Click += new System.EventHandler(lisResourceList_Click);
            this.colSeq = new System.Windows.Forms.ColumnHeader();
            this.colRes = new System.Windows.Forms.ColumnHeader();
            this.colDesc = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colUpDown = new System.Windows.Forms.ColumnHeader();
            this.colPriSts = new System.Windows.Forms.ColumnHeader();
            this.colPrt1 = new System.Windows.Forms.ColumnHeader();
            this.colPrt2 = new System.Windows.Forms.ColumnHeader();
            this.colPrt3 = new System.Windows.Forms.ColumnHeader();
            this.colPrt4 = new System.Windows.Forms.ColumnHeader();
            this.colPrt5 = new System.Windows.Forms.ColumnHeader();
            this.colPrt6 = new System.Windows.Forms.ColumnHeader();
            this.colPrt7 = new System.Windows.Forms.ColumnHeader();
            this.colPrt8 = new System.Windows.Forms.ColumnHeader();
            this.colPrt9 = new System.Windows.Forms.ColumnHeader();
            this.colPrt10 = new System.Windows.Forms.ColumnHeader();
            this.colSts1 = new System.Windows.Forms.ColumnHeader();
            this.colSts2 = new System.Windows.Forms.ColumnHeader();
            this.colSts3 = new System.Windows.Forms.ColumnHeader();
            this.colSts4 = new System.Windows.Forms.ColumnHeader();
            this.colSts5 = new System.Windows.Forms.ColumnHeader();
            this.colSts6 = new System.Windows.Forms.ColumnHeader();
            this.colSts7 = new System.Windows.Forms.ColumnHeader();
            this.colSts8 = new System.Windows.Forms.ColumnHeader();
            this.colSts9 = new System.Windows.Forms.ColumnHeader();
            this.colSts10 = new System.Windows.Forms.ColumnHeader();
            this.colUseFac = new System.Windows.Forms.ColumnHeader();
            this.colLastEvent = new System.Windows.Forms.ColumnHeader();
            this.colLastEventTime = new System.Windows.Forms.ColumnHeader();
            this.colLastStartTime = new System.Windows.Forms.ColumnHeader();
            this.colLastEndTime = new System.Windows.Forms.ColumnHeader();
            this.colProcCount = new System.Windows.Forms.ColumnHeader();
            this.colMaxProcCount = new System.Windows.Forms.ColumnHeader();
            this.colLot1 = new System.Windows.Forms.ColumnHeader();
            this.colLot2 = new System.Windows.Forms.ColumnHeader();
            this.colLot3 = new System.Windows.Forms.ColumnHeader();
            this.colLot4 = new System.Windows.Forms.ColumnHeader();
            this.colLot5 = new System.Windows.Forms.ColumnHeader();
            this.colLot6 = new System.Windows.Forms.ColumnHeader();
            this.colLot7 = new System.Windows.Forms.ColumnHeader();
            this.colLot8 = new System.Windows.Forms.ColumnHeader();
            this.colLot9 = new System.Windows.Forms.ColumnHeader();
            this.colLot10 = new System.Windows.Forms.ColumnHeader();
            this.colLastActiveHistSeq = new System.Windows.Forms.ColumnHeader();
            this.colLastHistSeq = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.colCreateTime = new System.Windows.Forms.ColumnHeader();
            this.colUpdateUser = new System.Windows.Forms.ColumnHeader();
            this.colUpdateTime = new System.Windows.Forms.ColumnHeader();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.tmrTimer.Tick += new System.EventHandler(tmrTimer_Tick);
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.cdvType).BeginInit();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            //
            //pnlBottom
            //
            this.pnlBottom.Controls.Add(this.lblAutoRefresh);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.txtTotRes);
            this.pnlBottom.Controls.Add(this.lblTotRes);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.cdvType);
            this.pnlBottom.Controls.Add(this.lblType);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 33);
            this.pnlBottom.TabIndex = 0;
            //
            //lblAutoRefresh
            //
            this.lblAutoRefresh.Location = new System.Drawing.Point(280, 9);
            this.lblAutoRefresh.Name = "lblAutoRefresh";
            this.lblAutoRefresh.Size = new System.Drawing.Size(72, 14);
            this.lblAutoRefresh.TabIndex = 3;
            this.lblAutoRefresh.Text = "Auto Refresh";
            //
            //chkAutoRefresh
            //
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.FlatMode = true;
            this.chkAutoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoRefresh.Location = new System.Drawing.Point(260, 9);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(16, 14);
            this.chkAutoRefresh.TabIndex = 2;
            this.chkAutoRefresh.Text = "Auto Refresh";
            //
            //txtTotRes
            //
            this.txtTotRes.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.txtTotRes.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotRes.Location = new System.Drawing.Point(602, 9);
            this.txtTotRes.MaxLength = 10;
            this.txtTotRes.Name = "txtTotRes";
            this.txtTotRes.ReadOnly = true;
            this.txtTotRes.Size = new System.Drawing.Size(44, 13);
            this.txtTotRes.TabIndex = 7;
            this.txtTotRes.Text = "Tot Res";
            //
            //lblTotRes
            //
            this.lblTotRes.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblTotRes.AutoSize = true;
            this.lblTotRes.Location = new System.Drawing.Point(542, 8);
            this.lblTotRes.Name = "lblTotRes";
            this.lblTotRes.Size = new System.Drawing.Size(50, 16);
            this.lblTotRes.TabIndex = 6;
            this.lblTotRes.Text = "Tot Res :";
            this.lblTotRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //btnClose
            //
            this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            //
            //btnExcel
            //
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = (System.Drawing.Image) resources.GetObject("btnExcel.Image");
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(394, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            //
            //btnRefresh
            //
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = (System.Drawing.Image) resources.GetObject("btnRefresh.Image");
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(364, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            //
            //cdvType
            //
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(116, 6);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SelectedSubItemIndex = - 1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(138, 21);
            this.cdvType.SmallImageList = null;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            //
            //lblType
            //
            this.lblType.Location = new System.Drawing.Point(8, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(102, 14);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            //
            //pnlMid
            //
            this.pnlMid.Controls.Add(this.lisResourceList);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.DockPadding.All = 3;
            this.pnlMid.Location = new System.Drawing.Point(0, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(742, 513);
            this.pnlMid.TabIndex = 0;
            //
            //lisResourceList
            //
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colSeq, this.colRes, this.colDesc, this.colType, this.colUpDown, this.colPriSts, this.colPrt1, this.colPrt2, this.colPrt3, this.colPrt4, this.colPrt5, this.colPrt6, this.colPrt7, this.colPrt8, this.colPrt9, this.colPrt10, this.colSts1, this.colSts2, this.colSts3, this.colSts4, this.colSts5, this.colSts6, this.colSts7, this.colSts8, this.colSts9, this.colSts10, this.colUseFac, this.colLastEvent, this.colLastEventTime, this.colLastStartTime
            , this.colLastEndTime, this.colProcCount, this.colMaxProcCount, this.colLot1, this.colLot2, this.colLot3, this.colLot4, this.colLot5, this.colLot6, this.colLot7, this.colLot8, this.colLot9, this.colLot10, this.colLastActiveHistSeq, this.colLastHistSeq, this.colCreateUser, this.colCreateTime, this.colUpdateUser, this.colUpdateTime }
            );
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.Location = new System.Drawing.Point(3, 3);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(736, 507);
            this.lisResourceList.TabIndex = 0;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            //
            //colSeq
            //
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 50;
            //
            //colRes
            //
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 100;
            //
            //colDesc
            //
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 130;
            //
            //colType
            //
            this.colType.Text = "Res Type";
            this.colType.Width = 90;
            //
            //colUpDown
            //
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 70;
            //
            //colPriSts
            //
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 120;
            //
            //colPrt1
            //
            this.colPrt1.Text = "Status Prompt 1";
            this.colPrt1.Width = 120;
            //
            //colPrt2
            //
            this.colPrt2.Text = "Status Prompt 2";
            this.colPrt2.Width = 120;
            //
            //colPrt3
            //
            this.colPrt3.Text = "Status Prompt 3";
            this.colPrt3.Width = 120;
            //
            //colPrt4
            //
            this.colPrt4.Text = "Status Prompt 4";
            this.colPrt4.Width = 120;
            //
            //colPrt5
            //
            this.colPrt5.Text = "Status Prompt 5";
            this.colPrt5.Width = 120;
            //
            //colPrt6
            //
            this.colPrt6.Text = "Status Prompt 6";
            this.colPrt6.Width = 120;
            //
            //colPrt7
            //
            this.colPrt7.Text = "Status Prompt 7";
            this.colPrt7.Width = 120;
            //
            //colPrt8
            //
            this.colPrt8.Text = "Status Prompt 8";
            this.colPrt8.Width = 120;
            //
            //colPrt9
            //
            this.colPrt9.Text = "Status Prompt 9";
            this.colPrt9.Width = 120;
            //
            //colPrt10
            //
            this.colPrt10.Text = "Status Prompt 10";
            this.colPrt10.Width = 120;
            //
            //colSts1
            //
            this.colSts1.Text = "Status 1";
            this.colSts1.Width = 120;
            //
            //colSts2
            //
            this.colSts2.Text = "Status 2";
            this.colSts2.Width = 120;
            //
            //colSts3
            //
            this.colSts3.Text = "Status 3";
            this.colSts3.Width = 120;
            //
            //colSts4
            //
            this.colSts4.Text = "Status 4";
            this.colSts4.Width = 120;
            //
            //colSts5
            //
            this.colSts5.Text = "Status 5";
            this.colSts5.Width = 120;
            //
            //colSts6
            //
            this.colSts6.Text = "Status 6";
            this.colSts6.Width = 120;
            //
            //colSts7
            //
            this.colSts7.Text = "Status 7";
            this.colSts7.Width = 120;
            //
            //colSts8
            //
            this.colSts8.Text = "Status 8";
            this.colSts8.Width = 120;
            //
            //colSts9
            //
            this.colSts9.Text = "Status 9";
            this.colSts9.Width = 120;
            //
            //colSts10
            //
            this.colSts10.Text = "Status 10";
            this.colSts10.Width = 120;
            //
            //colUseFac
            //
            this.colUseFac.Text = "Use Fac Prt Flag";
            this.colUseFac.Width = 100;
            //
            //colLastEvent
            //
            this.colLastEvent.Text = "Last Event";
            this.colLastEvent.Width = 100;
            //
            //colLastEventTime
            //
            this.colLastEventTime.Text = "Last Event Time";
            this.colLastEventTime.Width = 120;
            //
            //colLastStartTime
            //
            this.colLastStartTime.Text = "Last Start Time";
            this.colLastStartTime.Width = 120;
            //
            //colLastEndTime
            //
            this.colLastEndTime.Text = "Last End Time";
            this.colLastEndTime.Width = 120;
            //
            //colProcCount
            //
            this.colProcCount.Text = "Proc Lot Count";
            this.colProcCount.Width = 100;
            //
            //colMaxProcCount
            //
            this.colMaxProcCount.Text = "Max Proc Count";
            this.colMaxProcCount.Width = 100;
            //
            //colLot1
            //
            this.colLot1.Text = "Proc Lot 1";
            this.colLot1.Width = 100;
            //
            //colLot2
            //
            this.colLot2.Text = "Proc Lot 2";
            this.colLot2.Width = 100;
            //
            //colLot3
            //
            this.colLot3.Text = "Proc Lot 3";
            this.colLot3.Width = 100;
            //
            //colLot4
            //
            this.colLot4.Text = "Proc Lot 4";
            this.colLot4.Width = 100;
            //
            //colLot5
            //
            this.colLot5.Text = "Proc Lot 5";
            this.colLot5.Width = 100;
            //
            //colLot6
            //
            this.colLot6.Text = "Proc Lot 6";
            this.colLot6.Width = 100;
            //
            //colLot7
            //
            this.colLot7.Text = "Proc Lot 7";
            this.colLot7.Width = 100;
            //
            //colLot8
            //
            this.colLot8.Text = "Proc Lot 8";
            this.colLot8.Width = 100;
            //
            //colLot9
            //
            this.colLot9.Text = "Proc Lot 9";
            this.colLot9.Width = 100;
            //
            //colLot10
            //
            this.colLot10.Text = "Proc Lot 10";
            this.colLot10.Width = 100;
            //
            //colLastActiveHistSeq
            //
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.Width = 120;
            //
            //colLastHistSeq
            //
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.Width = 100;
            //
            //colCreateUser
            //
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 110;
            //
            //colCreateTime
            //
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            //
            //colUpdateUser
            //
            this.colUpdateUser.Text = "Update User";
            this.colUpdateUser.Width = 110;
            //
            //colUpdateTime
            //
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 120;
            //
            //tmrTimer
            //
            this.tmrTimer.Interval = 60000;
            //
            //frmSPCResourceListMain
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCResourceListMain";
            this.Text = "Resource List Main";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.cdvType).EndInit();
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);
            
        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string sCurrentArea;
        private string sCurrentSubArea;
        
        #endregion
        
        #region " Function Implementations"
        
        // View_Resource_List()
        //       - View Resource List
        // Return Value
        //       - Boolean : True of False
        // Arguments
        //        -
        private void View_Resource_List()
        {
            
            try
            {
                if (sCurrentArea != "" && sCurrentSubArea != "")
                {
                    
                    //gaSelectRes_ID.Clear()
                    MPGV.gsCurrentRes_ID = "";
                    
                    RASLIST.ViewResourceListDetail(lisResourceList, cdvType.Text, "", sCurrentArea, sCurrentSubArea, "", false, true, "", false);
                    txtTotRes.Text = lisResourceList.Items.Count.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.View_Resource_List()" + "\r\n" + ex.Message);
            }
            
        }
        
        // SetArea()
        //       - Setting Area at "frmMIDMain"
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetArea(string sArea, string sSubArea)
        {
            
            try
            {
                sCurrentArea = sArea;
                sCurrentSubArea = sSubArea;
                cdvType.Text = "";
                
                if (b_load_flag == true)
                {
                    View_Resource_List();
                }
                else
                {
                    this.Top = 0;
                    this.Left = 0;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.SetArea()" + "\r\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implementations"
        
        private void frmSPCResourceListMain_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.SetTextboxStyle(this.Controls);
                chkAutoRefresh.Checked = false;
                if (MPGV.giAutoRefreshTime > 0)
                {
                    chkAutoRefresh.Checked = MPGV.gbAutoRefresh;
                    tmrTimer.Interval = MPGV.giAutoRefreshTime * 1000;
                }
                
                if (chkAutoRefresh.Checked == true)
                {
                    tmrTimer.Start();
                }
                else
                {
                    tmrTimer.Stop();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.frmSPCResourceListMain_Load()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void frmSPCResourceListMain_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gsCurrentRes_ID = "";
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.frmSPCResourceListMain_Closed()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void frmSPCResourceListMain_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    MPCF.InitListView(lisResourceList);
                    View_Resource_List();
                    
                    b_load_flag = true;
                }
                else
                {
                    if (chkAutoRefresh.Checked == true)
                    {
                        View_Resource_List();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.frmSPCResourceListMain_Activated()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.btnClose_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                View_Resource_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.btnRefresh_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            string sCond;
            
            try
            {
                sCond = "";
                if (cdvType.Text != "")
                {
                    sCond = sCond + "Res Type : " + cdvType.Text + "\r";
                }
                sCond = sCond + "Area     : " + sCurrentArea + "\r";
                sCond = sCond + "Sub Area : " + sCurrentSubArea;

                if (MPCF.ExportToExcel(lisResourceList, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.btnExcel_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            
            try
            {
                View_Resource_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.tmrTimer_Tick()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                View_Resource_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.cdvType_SelectedItemChanged()" + "\r\n" + ex.Message);
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
                cdvType.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
                BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE, -1, null, "", false, -1, -1, null);
                cdvType.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.cdvType_ButtonPress()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void lisResourceList_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisResourceList.SelectedItems.Count > 0)
                {
                    MPGV.gsCurrentRes_ID = lisResourceList.FocusedItem.SubItems[1].Text;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCResourceListMain.lisResourceList_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
}
