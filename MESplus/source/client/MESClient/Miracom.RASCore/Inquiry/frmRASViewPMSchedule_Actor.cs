
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using Infragistics.Win.UltraWinSchedule;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupPMSchedule.vb
//   Description : PM Schedule Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - SetCalendar() : Initialize Spread ans make Calendar Cell according to the Year & Month
//       - InitSpreadTip() : Initialize Spread Tool tip Enviromnent (Font, Color, Width..)
//       - CheckCondition() : Check the conditions before transaction
//       - Update_PM_Schedule_List() : Update PM Schedule List
//       - View_PM_Resource_List() :PM Schedule ?€?ì´ ?˜ëŠ” Resource Listë¥?ê°€?¸ì˜¨??
//       - View_PM_Schedule_List() :View PM Schedule List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-02 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewPMSchedule_Actor : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewPMSchedule_Actor()
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

        private System.ComponentModel.IContainer components;

        
        



        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel pnlCenterLeft;
        private System.Windows.Forms.Splitter splMain;
        private System.Windows.Forms.Panel pnlCenterRight;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private System.Windows.Forms.Label lblColorUnscheduled;
        private System.Windows.Forms.Label lblColorScheduled;
        private System.Windows.Forms.TabControl tabCalendar;
        private System.Windows.Forms.TabPage tbpMonthView;
        private Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle umvsMonth;
        private System.Windows.Forms.TabPage tbpYearView;
        private System.Windows.Forms.Panel pnlFOMid;
        private FarPoint.Win.Spread.FpSpread spdYear;
        private FarPoint.Win.Spread.SheetView spdYear_Sheet1;
        private System.Windows.Forms.GroupBox grpResType;
        private System.Windows.Forms.GroupBox grpCalendar;
        private System.Windows.Forms.GroupBox grpActionBackColor;
        private System.Windows.Forms.GroupBox grpPMInfo;
        private System.Windows.Forms.TextBox txtPMInfo;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarLook uclMonthLook;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarInfo uciMonthInfo;
        private System.Windows.Forms.PictureBox picComment;
        private System.Windows.Forms.ContextMenu ctxMenu;
        private System.Windows.Forms.MenuItem mnuPMInfo;
        private System.Windows.Forms.Label lblPMInfo;
        private System.Windows.Forms.Label lblActionBackColor;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.Label lblCalendar;
        private System.Windows.Forms.DateTimePicker dtpCalendar;
        private System.Windows.Forms.Panel pnlExcelOption;
        private System.Windows.Forms.RadioButton rbnSecond;
        private System.Windows.Forms.RadioButton rbnFirst;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewPMSchedule_Actor));
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlCenterLeft = new System.Windows.Forms.Panel();
            this.grpPMInfo = new System.Windows.Forms.GroupBox();
            this.txtPMInfo = new System.Windows.Forms.TextBox();
            this.lblPMInfo = new System.Windows.Forms.Label();
            this.grpActionBackColor = new System.Windows.Forms.GroupBox();
            this.lblColorUnscheduled = new System.Windows.Forms.Label();
            this.lblColorScheduled = new System.Windows.Forms.Label();
            this.lblActionBackColor = new System.Windows.Forms.Label();
            this.grpResType = new System.Windows.Forms.GroupBox();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.dtpCalendar = new System.Windows.Forms.DateTimePicker();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.splMain = new System.Windows.Forms.Splitter();
            this.pnlCenterRight = new System.Windows.Forms.Panel();
            this.tabCalendar = new System.Windows.Forms.TabControl();
            this.tbpMonthView = new System.Windows.Forms.TabPage();
            this.umvsMonth = new Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle();
            this.uciMonthInfo = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            this.uclMonthLook = new Infragistics.Win.UltraWinSchedule.UltraCalendarLook(this.components);
            this.tbpYearView = new System.Windows.Forms.TabPage();
            this.pnlFOMid = new System.Windows.Forms.Panel();
            this.spdYear = new FarPoint.Win.Spread.FpSpread();
            this.spdYear_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.picComment = new System.Windows.Forms.PictureBox();
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.mnuPMInfo = new System.Windows.Forms.MenuItem();
            this.pnlExcelOption = new System.Windows.Forms.Panel();
            this.rbnSecond = new System.Windows.Forms.RadioButton();
            this.rbnFirst = new System.Windows.Forms.RadioButton();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCenterLeft.SuspendLayout();
            this.grpPMInfo.SuspendLayout();
            this.grpActionBackColor.SuspendLayout();
            this.grpResType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            this.grpCalendar.SuspendLayout();
            this.pnlCenterRight.SuspendLayout();
            this.tabCalendar.SuspendLayout();
            this.tbpMonthView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.umvsMonth)).BeginInit();
            this.tbpYearView.SuspendLayout();
            this.pnlFOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdYear_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComment)).BeginInit();
            this.pnlExcelOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlExcelOption);
            this.pnlBottom.Controls.Add(this.picComment);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.picComment, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlExcelOption, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCenterRight);
            this.pnlCenter.Controls.Add(this.splMain);
            this.pnlCenter.Controls.Add(this.pnlCenterLeft);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View PM Schedule - In view of Actor";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlCenterLeft
            // 
            this.pnlCenterLeft.Controls.Add(this.grpPMInfo);
            this.pnlCenterLeft.Controls.Add(this.grpActionBackColor);
            this.pnlCenterLeft.Controls.Add(this.grpResType);
            this.pnlCenterLeft.Controls.Add(this.grpCalendar);
            this.pnlCenterLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCenterLeft.Location = new System.Drawing.Point(3, 0);
            this.pnlCenterLeft.Name = "pnlCenterLeft";
            this.pnlCenterLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlCenterLeft.Size = new System.Drawing.Size(177, 513);
            this.pnlCenterLeft.TabIndex = 0;
            // 
            // grpPMInfo
            // 
            this.grpPMInfo.Controls.Add(this.txtPMInfo);
            this.grpPMInfo.Controls.Add(this.lblPMInfo);
            this.grpPMInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPMInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPMInfo.Location = new System.Drawing.Point(0, 218);
            this.grpPMInfo.Name = "grpPMInfo";
            this.grpPMInfo.Size = new System.Drawing.Size(174, 295);
            this.grpPMInfo.TabIndex = 3;
            this.grpPMInfo.TabStop = false;
            // 
            // txtPMInfo
            // 
            this.txtPMInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPMInfo.BackColor = System.Drawing.Color.White;
            this.txtPMInfo.Location = new System.Drawing.Point(3, 36);
            this.txtPMInfo.Multiline = true;
            this.txtPMInfo.Name = "txtPMInfo";
            this.txtPMInfo.ReadOnly = true;
            this.txtPMInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPMInfo.Size = new System.Drawing.Size(168, 257);
            this.txtPMInfo.TabIndex = 1;
            // 
            // lblPMInfo
            // 
            this.lblPMInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPMInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMInfo.Location = new System.Drawing.Point(2, 9);
            this.lblPMInfo.Name = "lblPMInfo";
            this.lblPMInfo.Size = new System.Drawing.Size(167, 24);
            this.lblPMInfo.TabIndex = 0;
            this.lblPMInfo.Text = "PM Information";
            this.lblPMInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpActionBackColor
            // 
            this.grpActionBackColor.Controls.Add(this.lblColorUnscheduled);
            this.grpActionBackColor.Controls.Add(this.lblColorScheduled);
            this.grpActionBackColor.Controls.Add(this.lblActionBackColor);
            this.grpActionBackColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActionBackColor.Location = new System.Drawing.Point(0, 142);
            this.grpActionBackColor.Name = "grpActionBackColor";
            this.grpActionBackColor.Size = new System.Drawing.Size(174, 76);
            this.grpActionBackColor.TabIndex = 2;
            this.grpActionBackColor.TabStop = false;
            // 
            // lblColorUnscheduled
            // 
            this.lblColorUnscheduled.AutoSize = true;
            this.lblColorUnscheduled.BackColor = System.Drawing.Color.Yellow;
            this.lblColorUnscheduled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColorUnscheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorUnscheduled.Location = new System.Drawing.Point(91, 42);
            this.lblColorUnscheduled.Name = "lblColorUnscheduled";
            this.lblColorUnscheduled.Size = new System.Drawing.Size(66, 15);
            this.lblColorUnscheduled.TabIndex = 2;
            this.lblColorUnscheduled.Text = "Unschduled";
            this.lblColorUnscheduled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColorScheduled
            // 
            this.lblColorScheduled.AutoSize = true;
            this.lblColorScheduled.BackColor = System.Drawing.Color.Blue;
            this.lblColorScheduled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColorScheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorScheduled.Location = new System.Drawing.Point(13, 42);
            this.lblColorScheduled.Name = "lblColorScheduled";
            this.lblColorScheduled.Size = new System.Drawing.Size(60, 15);
            this.lblColorScheduled.TabIndex = 1;
            this.lblColorScheduled.Text = "Scheduled";
            this.lblColorScheduled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActionBackColor
            // 
            this.lblActionBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActionBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActionBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionBackColor.Location = new System.Drawing.Point(2, 9);
            this.lblActionBackColor.Name = "lblActionBackColor";
            this.lblActionBackColor.Size = new System.Drawing.Size(170, 24);
            this.lblActionBackColor.TabIndex = 0;
            this.lblActionBackColor.Text = "Action Backcolor";
            this.lblActionBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpResType
            // 
            this.grpResType.Controls.Add(this.cdvResType);
            this.grpResType.Controls.Add(this.lblResType);
            this.grpResType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResType.Location = new System.Drawing.Point(0, 71);
            this.grpResType.Name = "grpResType";
            this.grpResType.Size = new System.Drawing.Size(174, 71);
            this.grpResType.TabIndex = 1;
            this.grpResType.TabStop = false;
            // 
            // cdvResType
            // 
            this.cdvResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResType.BtnToolTipText = "";
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(10, 39);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = false;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedSubItemIndex = -1;
            this.cdvResType.SelectionStart = 0;
            this.cdvResType.Size = new System.Drawing.Size(148, 20);
            this.cdvResType.SmallImageList = null;
            this.cdvResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResType.TabIndex = 1;
            this.cdvResType.TextBoxToolTipText = "";
            this.cdvResType.TextBoxWidth = 148;
            this.cdvResType.VisibleButton = true;
            this.cdvResType.VisibleColumnHeader = false;
            this.cdvResType.VisibleDescription = false;
            this.cdvResType.ButtonPress += new System.EventHandler(this.cdvResType_ButtonPress);
            // 
            // lblResType
            // 
            this.lblResType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.Location = new System.Drawing.Point(2, 3);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(170, 24);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            this.lblResType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.dtpCalendar);
            this.grpCalendar.Controls.Add(this.lblCalendar);
            this.grpCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCalendar.Location = new System.Drawing.Point(0, 0);
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.Size = new System.Drawing.Size(174, 71);
            this.grpCalendar.TabIndex = 0;
            this.grpCalendar.TabStop = false;
            // 
            // dtpCalendar
            // 
            this.dtpCalendar.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendar.CustomFormat = "yyyy-MM";
            this.dtpCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCalendar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpCalendar.Location = new System.Drawing.Point(10, 39);
            this.dtpCalendar.Name = "dtpCalendar";
            this.dtpCalendar.ShowUpDown = true;
            this.dtpCalendar.Size = new System.Drawing.Size(148, 20);
            this.dtpCalendar.TabIndex = 1;
            this.dtpCalendar.Value = new System.DateTime(1973, 7, 11, 0, 0, 0, 0);
            this.dtpCalendar.TextChanged += new System.EventHandler(this.dtpCalendar_TextChanged);
            // 
            // lblCalendar
            // 
            this.lblCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendar.Location = new System.Drawing.Point(2, 3);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(170, 24);
            this.lblCalendar.TabIndex = 0;
            this.lblCalendar.Text = "Calendar";
            this.lblCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splMain
            // 
            this.splMain.Location = new System.Drawing.Point(180, 0);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(4, 513);
            this.splMain.TabIndex = 1;
            this.splMain.TabStop = false;
            // 
            // pnlCenterRight
            // 
            this.pnlCenterRight.Controls.Add(this.tabCalendar);
            this.pnlCenterRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterRight.Location = new System.Drawing.Point(184, 0);
            this.pnlCenterRight.Name = "pnlCenterRight";
            this.pnlCenterRight.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlCenterRight.Size = new System.Drawing.Size(555, 513);
            this.pnlCenterRight.TabIndex = 0;
            // 
            // tabCalendar
            // 
            this.tabCalendar.Controls.Add(this.tbpMonthView);
            this.tabCalendar.Controls.Add(this.tbpYearView);
            this.tabCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCalendar.ItemSize = new System.Drawing.Size(60, 18);
            this.tabCalendar.Location = new System.Drawing.Point(3, 0);
            this.tabCalendar.Name = "tabCalendar";
            this.tabCalendar.SelectedIndex = 0;
            this.tabCalendar.Size = new System.Drawing.Size(552, 513);
            this.tabCalendar.TabIndex = 0;
            this.tabCalendar.SelectedIndexChanged += new System.EventHandler(this.tabCalendar_SelectedIndexChanged);
            // 
            // tbpMonthView
            // 
            this.tbpMonthView.Controls.Add(this.umvsMonth);
            this.tbpMonthView.Location = new System.Drawing.Point(4, 22);
            this.tbpMonthView.Name = "tbpMonthView";
            this.tbpMonthView.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMonthView.Size = new System.Drawing.Size(544, 487);
            this.tbpMonthView.TabIndex = 0;
            this.tbpMonthView.Text = "Month View ";
            // 
            // umvsMonth
            // 
            this.umvsMonth.AutoAppointmentDialog = false;
            this.umvsMonth.CalendarInfo = this.uciMonthInfo;
            this.umvsMonth.CalendarLook = this.uclMonthLook;
            this.umvsMonth.DayDisplayStyle = Infragistics.Win.UltraWinSchedule.DayDisplayStyleEnum.Medium;
            this.umvsMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.umvsMonth.Location = new System.Drawing.Point(3, 3);
            this.umvsMonth.Name = "umvsMonth";
            this.umvsMonth.ScrollbarVisible = false;
            this.umvsMonth.Size = new System.Drawing.Size(538, 481);
            this.umvsMonth.TabIndex = 0;
            this.umvsMonth.TabStop = false;
            this.umvsMonth.TipStyleActivity = Infragistics.Win.UltraWinSchedule.TipStyleActivity.Notes;
            this.umvsMonth.WeekendDisplayStyle = Infragistics.Win.UltraWinSchedule.WeekendDisplayStyleEnum.Full;
            this.umvsMonth.YearDisplayStyle = Infragistics.Win.UltraWinSchedule.YearDisplayStyleEnum.FirstDayOfMonth;
            this.umvsMonth.BeforeScroll += new Infragistics.Win.UltraWinSchedule.BeforeScrollEventHandler(this.umvsMonth_BeforeScroll);
            this.umvsMonth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.umvsMonth_MouseUp);
            // 
            // uciMonthInfo
            // 
            this.uciMonthInfo.AppointmentActionsEnabled = false;
            this.uciMonthInfo.DataBindingsForAppointments.BindingContextControl = this;
            this.uciMonthInfo.DataBindingsForOwners.BindingContextControl = this;
            this.uciMonthInfo.AfterActiveDayChanged += new Infragistics.Win.UltraWinSchedule.AfterActiveDayChangedEventHandler(this.uciMonthInfo_AfterActiveDayChanged);
            // 
            // uclMonthLook
            // 
            this.uclMonthLook.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2003;
            // 
            // tbpYearView
            // 
            this.tbpYearView.Controls.Add(this.pnlFOMid);
            this.tbpYearView.Location = new System.Drawing.Point(4, 22);
            this.tbpYearView.Name = "tbpYearView";
            this.tbpYearView.Padding = new System.Windows.Forms.Padding(3);
            this.tbpYearView.Size = new System.Drawing.Size(544, 487);
            this.tbpYearView.TabIndex = 1;
            this.tbpYearView.Text = "Year View ";
            this.tbpYearView.Visible = false;
            // 
            // pnlFOMid
            // 
            this.pnlFOMid.Controls.Add(this.spdYear);
            this.pnlFOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFOMid.Location = new System.Drawing.Point(3, 3);
            this.pnlFOMid.Name = "pnlFOMid";
            this.pnlFOMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlFOMid.Size = new System.Drawing.Size(538, 481);
            this.pnlFOMid.TabIndex = 2;
            // 
            // spdYear
            // 
            this.spdYear.AccessibleDescription = "";
            this.spdYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdYear.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdYear.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdYear.HorizontalScrollBar.Name = "";
            this.spdYear.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdYear.HorizontalScrollBar.TabIndex = 2;
            this.spdYear.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdYear.Location = new System.Drawing.Point(0, 5);
            this.spdYear.Name = "spdYear";
            this.spdYear.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdYear_Sheet1});
            this.spdYear.Size = new System.Drawing.Size(538, 476);
            this.spdYear.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdYear.TabIndex = 0;
            this.spdYear.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdYear.TextTipAppearance = tipAppearance1;
            this.spdYear.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
            this.spdYear.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdYear.VerticalScrollBar.Name = "";
            this.spdYear.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdYear.VerticalScrollBar.TabIndex = 3;
            this.spdYear.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdYear.TextTipFetch += new FarPoint.Win.Spread.TextTipFetchEventHandler(this.spdYear_TextTipFetch);
            this.spdYear.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdYear_CellDoubleClick);
            this.spdYear.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdYear_EditChange);
            this.spdYear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdYear_MouseUp);
            this.spdYear.SetActiveViewport(0, -1, -1);
            // 
            // spdYear_Sheet1
            // 
            this.spdYear_Sheet1.Reset();
            spdYear_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdYear_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdYear_Sheet1.ColumnCount = 0;
            spdYear_Sheet1.ColumnHeader.RowCount = 2;
            spdYear_Sheet1.RowCount = 0;
            spdYear_Sheet1.RowHeader.ColumnCount = 3;
            this.spdYear_Sheet1.ActiveColumnIndex = -1;
            this.spdYear_Sheet1.ActiveRowIndex = -1;
            this.spdYear_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdYear_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdYear_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdYear_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdYear_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdYear_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdYear_Sheet1.ColumnHeader.Visible = false;
            this.spdYear_Sheet1.DataAutoSizeColumns = false;
            this.spdYear_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdYear_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdYear_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdYear_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdYear_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdYear_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // picComment
            // 
            this.picComment.Image = ((System.Drawing.Image)(resources.GetObject("picComment.Image")));
            this.picComment.Location = new System.Drawing.Point(412, 20);
            this.picComment.Name = "picComment";
            this.picComment.Size = new System.Drawing.Size(25, 12);
            this.picComment.TabIndex = 6;
            this.picComment.TabStop = false;
            this.picComment.Visible = false;
            // 
            // ctxMenu
            // 
            this.ctxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPMInfo});
            // 
            // mnuPMInfo
            // 
            this.mnuPMInfo.Index = 0;
            this.mnuPMInfo.Text = "View More Information";
            this.mnuPMInfo.Click += new System.EventHandler(this.mnuPMInfo_Click);
            // 
            // pnlExcelOption
            // 
            this.pnlExcelOption.Controls.Add(this.rbnSecond);
            this.pnlExcelOption.Controls.Add(this.rbnFirst);
            this.pnlExcelOption.Location = new System.Drawing.Point(48, 8);
            this.pnlExcelOption.Name = "pnlExcelOption";
            this.pnlExcelOption.Size = new System.Drawing.Size(196, 24);
            this.pnlExcelOption.TabIndex = 2;
            // 
            // rbnSecond
            // 
            this.rbnSecond.AutoSize = true;
            this.rbnSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnSecond.Location = new System.Drawing.Point(100, 2);
            this.rbnSecond.Name = "rbnSecond";
            this.rbnSecond.Size = new System.Drawing.Size(84, 17);
            this.rbnSecond.TabIndex = 1;
            this.rbnSecond.Text = "Second Half";
            // 
            // rbnFirst
            // 
            this.rbnFirst.AutoSize = true;
            this.rbnFirst.Checked = true;
            this.rbnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnFirst.Location = new System.Drawing.Point(16, 2);
            this.rbnFirst.Name = "rbnFirst";
            this.rbnFirst.Size = new System.Drawing.Size(66, 17);
            this.rbnFirst.TabIndex = 0;
            this.rbnFirst.TabStop = true;
            this.rbnFirst.Text = "First Half";
            // 
            // frmRASViewPMSchedule_Actor
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewPMSchedule_Actor";
            this.Text = "View PM Schedule - In view of Actor";
            this.Activated += new System.EventHandler(this.frmRASSetupPMSchedule_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupPMSchedule_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlCenterLeft.ResumeLayout(false);
            this.grpPMInfo.ResumeLayout(false);
            this.grpPMInfo.PerformLayout();
            this.grpActionBackColor.ResumeLayout(false);
            this.grpActionBackColor.PerformLayout();
            this.grpResType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            this.grpCalendar.ResumeLayout(false);
            this.pnlCenterRight.ResumeLayout(false);
            this.tabCalendar.ResumeLayout(false);
            this.tbpMonthView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.umvsMonth)).EndInit();
            this.tbpYearView.ResumeLayout(false);
            this.pnlFOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdYear_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComment)).EndInit();
            this.pnlExcelOption.ResumeLayout(false);
            this.pnlExcelOption.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_SCH_CNT = 1000;
        private const int MAX_RES_CNT = 50;
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        bool bInitComponentFlag = false;
        bool bMonthScroll = false;
        
        int iSelYear = 0;
        string sResID = null;
        string sPMPlanDate = null;
        
        #endregion
        
        #region " Function Definition "
        
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ('1', "2", "3")
        
        private void ClearData(char ProcStep, int RowIndex)
        {
            
            //            int i = 0;
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.ClearList(spdYear);
                }
                else if (ProcStep == '2')
                {
                    spdYear.Sheets[0].ClearRange(0, 0, spdYear.Sheets[0].RowCount - 1, spdYear.Sheets[0].ColumnCount - 1, true);
                    if (RowIndex > - 1)
                    {
                        spdYear.Sheets[0].Cells[0, 0, spdYear.Sheets[0].RowCount - 1, spdYear.Sheets[0].ColumnCount - 1].BackColor = System.Drawing.Color.Empty;
                    }
                }
                else if (ProcStep == '3')
                {
                    if (spdYear.Sheets[0].RowCount > RowIndex)
                    {
                        spdYear.Sheets[0].ClearRange(RowIndex, 0, 1, spdYear.Sheets[0].ColumnCount, true);
                        spdYear.Sheets[0].Cells[RowIndex, 0, RowIndex, spdYear.Sheets[0].ColumnCount - 1].BackColor = System.Drawing.Color.Empty;
                    }
                }
                else if (ProcStep == '4')
                {
                    umvsMonth.CalendarInfo.Notes.Clear();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // InitSpreadTip()
        //       - Set Environment Tooltip Display
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void InitSpreadTip()
        {
            
            Font tipfont = new Font("Arial", 11);
            FarPoint.Win.Spread.TipAppearance ttAppearance = new FarPoint.Win.Spread.TipAppearance();
            
            try
            {
                //Set text tip
                spdYear.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
                ttAppearance.BackColor = Color.FromArgb(255, 255, 192);
                ttAppearance.ForeColor = Color.FromArgb(0, 0, 80);
                ttAppearance.Font = tipfont;
                spdYear.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep, int RowIndex, int ColIndex)
        {
            bool returnValue;
            
            int i = 0;
            //            int j = 0;
            int iChkCnt = 0;
            FarPoint.Win.Spread.Model.CellRange cCellRange;
            int iStartRow = 0;
            int iEndRow = 0;
            
            try
            {
                returnValue = false;

                switch (MPCF.Trim(FuncName))
                {
                    
                case "Update_PM_Schedule_List":
                    
                    
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        //If modCommonFunction.CheckValue(cdvPMPeriod, "1") = False Then
                        //    Exit Function
                        //End If
                        
                        //If cdvPMPeriod.SelectedItem Is Nothing Then
                        //    Exit Function
                        //End If
                        
                        if (spdYear.Sheets[0].ColumnCount == 0 || spdYear.Sheets[0].RowCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(176));
                            spdYear.Select();
                            return returnValue;
                        }
                        
                        iChkCnt = spdYear.Sheets[0].SelectionCount;
                        
                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(176));
                            spdYear.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_SCH_CNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdYear.Select();
                            return false;
                        }
                        
                        if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[spdYear.Sheets[0].ActiveRowIndex, 0].Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(121));
                            spdYear.Select();
                            return false;
                        }
                        
                        if (dtpCalendar.Value.Year < DateTime.Now.Year)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(177));
                            spdYear.Select();
                            return returnValue;
                        }
                        else if (dtpCalendar.Value.Year == DateTime.Now.Year)
                        {
                            if (MPCF.CheckNumeric(spdYear.Sheets[0].ColumnHeader.Cells[0, spdYear.Sheets[0].ActiveColumnIndex].Text) == true)
                            {
                                if (MPCF.ToInt(spdYear.Sheets[0].ColumnHeader.Cells[0, spdYear.Sheets[0].ActiveColumnIndex].Text) < DateTime.Now.Month)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(177));
                                    spdYear.Select();
                                    return returnValue;
                                }
                                else if (MPCF.ToInt(spdYear.Sheets[0].ColumnHeader.Cells[0, spdYear.Sheets[0].ActiveColumnIndex].Text) == DateTime.Now.Month)
                                {
                                    if (MPCF.CheckNumeric(spdYear.Sheets[0].ColumnHeader.Cells[1, spdYear.Sheets[0].ActiveColumnIndex].Text) == true)
                                    {
                                        if (MPCF.ToInt(spdYear.Sheets[0].ColumnHeader.Cells[1, spdYear.Sheets[0].ActiveColumnIndex].Text) < DateTime.Now.Day)
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(177));
                                            spdYear.Select();
                                            return returnValue;
                                        }
                                    }
                                    else
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(178));
                                        spdYear.Select();
                                        return returnValue;
                                    }
                                }
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(178));
                                spdYear.Select();
                                return returnValue;
                            }
                        }
                        
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        
                        if (spdYear.Sheets[0].ColumnCount == 0 || spdYear.Sheets[0].RowCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(176));
                            spdYear.Select();
                            return returnValue;
                        }
                        
                        iChkCnt = spdYear.Sheets[0].SelectionCount;
                        
                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(176));
                            spdYear.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_SCH_CNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdYear.Select();
                            return false;
                        }
                        
                        foreach (FarPoint.Win.Spread.Model.CellRange tempLoopVar_cCellRange in spdYear.Sheets[0].GetSelections())
                        {
                            cCellRange = tempLoopVar_cCellRange;
                            if (cCellRange.RowCount == - 1)
                            {
                                iStartRow = 0;
                                iEndRow = spdYear.Sheets[0].RowCount - 1;
                            }
                            else
                            {
                                iStartRow = cCellRange.Row;
                                iEndRow = cCellRange.Row + cCellRange.RowCount - 1;
                            }
                            
                            for (i = iStartRow; i <= iEndRow; i++)
                            {
                                if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(121));
                                    spdYear.Select();
                                    return false;
                                }
                            }
                        }
                        
                    }
                    break;
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
            }}
            
//            return returnValue;
//            
            
            //
            // SetCalendar()
            //       - Initialize SpreadSheet Control and display Calendar
            // Return Value
            //       -
            // Arguments
            //       -
            //
            private void SetCalendar()
            {
                
                int i;
                int j;
                DateTime dFromDate = new DateTime();
                DateTime dToDate = new DateTime();
                int iWeekCnt = 0;
                
                try
                {
                    //Month View
                    umvsMonth.CalendarInfo.Notes.Clear();
                    dFromDate = new DateTime(dtpCalendar.Value.Year, dtpCalendar.Value.Month, 1);
                    dToDate = dFromDate.AddMonths(1);
                    iWeekCnt = (int)Math.Round((((TimeSpan)dToDate.Subtract(dFromDate)).Days / (double)7) + 0.5);
                    umvsMonth.VisibleWeeks = iWeekCnt + 1;
                    
                    bMonthScroll = true;
                    umvsMonth.ScrollDayIntoView(dFromDate, true);
                    bMonthScroll = false;
                    
                    //Year View
                    if (iSelYear == dtpCalendar.Value.Year)
                    {
                        return;
                    }
                    
                    FarPoint.Win.Spread.SheetView with_1 = spdYear.Sheets[0];
                    with_1.ClearRange(0, 0, with_1.RowCount, with_1.ColumnCount, false);
                    with_1.RowCount = 0;
                    with_1.ColumnCount = 0;
                    with_1.ColumnHeader.Visible = true;
                    with_1.RowHeader.Visible = true;
                    with_1.RowHeader.ColumnCount = 0;
                    with_1.RowHeader.ColumnCount = 3;
                    with_1.ColumnHeader.RowCount = 0;
                    with_1.ColumnHeader.RowCount = 2;
                    with_1.Columns.Default.Width = 20;
                    with_1.RowHeader.Columns[0].Width = 50;
                    with_1.RowHeader.Columns[1].Width = 70;
                    with_1.RowHeader.Columns[2].Width = 20;
                    
                    for (i = 1; i <= 12; i++)
                    {
                        for (j = 1; j <= System.DateTime.DaysInMonth(dtpCalendar.Value.Year, i); j++)
                        {
                            with_1.Columns.Add(with_1.ColumnCount, 1);
                            with_1.ColumnHeader.Cells[0, with_1.ColumnCount - 1].Text =  MPCF.Trim(i);
                            with_1.ColumnHeader.Cells[1, with_1.ColumnCount - 1].Text = MPCF.Trim(j);
                        }
                        with_1.ColumnHeader.Cells[0, with_1.ColumnCount -(j - 1)].ColumnSpan = j - 1;
                    }
                    
                    iSelYear = dtpCalendar.Value.Year;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            
            //
            // View_PM_Resource_List()
            //       - View MFO-Collection Set Relation List
            // Return Value
            //       - Boolean : True or False
            // Arguments
            //       -
            //
            private bool View_PM_Resource_List(char ProcStep)
            {
                
                int i;
                int LastRow = 0;

                TRSNode in_node = new TRSNode("View_PM_Resource_List_In");
                TRSNode out_node;
                
                try
                {
                    ClearData('1', 0);

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = ProcStep;
                    in_node.AddString("FROM_DATE", "");
                    in_node.AddString("TO_DATE", "");
                    in_node.AddString("PM_PLAN_YEAR", dtpCalendar.Value.Year.ToString("0000"));
                    in_node.AddString("PM_PLAN_MONTH", "");
                    
                    if (cdvResType.SelectedItem == null)
                    {
                        in_node.AddString("RES_TYPE", "");
                    }
                    else
                    {
                        in_node.AddString("RES_TYPE", MPCF.Trim(cdvResType.SelectedItem.Text));
                    }

                    in_node.AddString("NEXT_RES_ID", "");
                    
                    do
                    {
                        out_node = new TRSNode("View_PM_Resource_List_Out");

                        if (MPCR.CallService("RAS", "RAS_View_PM_Resource_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                        
                        
                        spdYear.Sheets[0].RowHeader.Columns[0].Width = 80;
                        spdYear.Sheets[0].RowHeader.Columns[1].Width = 100;
                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            
                            spdYear.Sheets[0].RowCount++;
                            LastRow = spdYear.Sheets[0].RowCount - 1;
                            
                            FarPoint.Win.Spread.SheetView with_1 = spdYear.Sheets[0];
                            with_1.RowHeader.Cells[LastRow, 0].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                            with_1.RowHeader.Cells[LastRow, 1].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC"));
                            with_1.RowHeader.Cells[LastRow, 2].Text = MPCF.Trim(out_node.GetList(0)[i].GetInt("PM_SCHEDULE_COUNT"));
                        }
                        in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));

                    } while (in_node.GetString("NEXT_RES_ID") != "");
                        
                    if (spdYear.Sheets[0].RowCount > 0)
                    {
                        spdYear.Sheets[0].Cells[0, 0, spdYear.Sheets[0].RowCount - 1, spdYear.Sheets[0].ColumnCount - 1].Locked = true;
                    }
                    
                    return true;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return false;
                }
                
            }
            
            //
            // View_PM_Schedule_List()
            //       - View MFO-Collection Set Relation List
            // Return Value
            //       - Boolean : True or False
            // Arguments
            //       -
            //
            private bool View_PM_Schedule_List(char ProcStep, int RowIndex)
            {
                
                int i;
                int j;
                int LastRow = 0;
                int iPMSchCnt = 0;
                int iSelCol = 0;
                int iSelRow = 0;
                DateTime dSelDate = new DateTime();
                int iIndex = 0;
                Infragistics.Win.UltraWinSchedule.Note nNote = null;

                TRSNode in_node = new TRSNode("View_PM_Schedule_List_In");
                TRSNode out_node;
            
                try
                {
                    if (ProcStep == '1')
                    {
                        if (RowIndex == - 1)
                        {
                            ClearData('2', RowIndex);
                        }
                        else
                        {
                            ClearData('3', RowIndex);
                        }
                    }
                    else if (ProcStep == '2' || ProcStep == '3')
                    {
                        ClearData('4', 0);
                    }

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = ProcStep;

                    in_node.AddString("FROM_DATE", "");
                    in_node.AddString("TO_DATE", "");
                    in_node.AddString("PM_PLAN_YEAR", dtpCalendar.Value.Year.ToString("0000"));

                    
                    if (ProcStep == '2' || ProcStep == '3')
                    {
                        in_node.AddString("PM_PLAN_MONTH", dtpCalendar.Value.Month.ToString("00"));

                    }
                    else
                    {
                        in_node.AddString("PM_PLAN_MONTH", "");
                    }
                    
                    if (cdvResType.SelectedItem == null)
                    {
                        in_node.AddString("RES_TYPE", "");

                    }
                    else
                    {
                        in_node.AddString("RES_TYPE", MPCF.Trim(cdvResType.SelectedItem.Text));
                    }
                    
                    iIndex = 0;
                    
                    if (ProcStep == '1')
                    {
                        if (RowIndex == - 1)
                        {
                            for (i = 0; i <= spdYear.Sheets[0].RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && MPCF.CheckNumeric(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                                {
                                    if (MPCF.ToInt(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                                    {
                                        if (iIndex >= MAX_RES_CNT)
                                        {
                                            break;
                                        }
                                        iIndex++;
                                    }
                                }
                            }

                             iIndex = 0;
                            for (i = 0; i <= spdYear.Sheets[0].RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && MPCF.CheckNumeric(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                                {
                                    if (MPCF.ToInt(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                                    {
                                        if (iIndex >= MAX_RES_CNT)
                                        {
                                            break;
                                        }
                                        TRSNode list = in_node.AddNode("RES_LIST");
                                        list.AddString("NEXT_RES_ID", MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text));
                                        list.AddString("NEXT_PM_PLAN_DATE", "");
                                        iIndex++;
                                    }
                                }
                            }
                            
                            LastRow = i;
                            
                        }
                        else
                        {
                            TRSNode list = in_node.AddNode("RES_LIST");
                            list.AddString("NEXT_RES_ID", MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                            list.AddString("NEXT_PM_PLAN_DATE", "");
                            iIndex++;
                        }
                    }
                    
                    
                    do
                    {
                        out_node = new TRSNode("View_PM_Schedule_List_Out");

                        if (MPCR.CallService("RAS", "RAS_View_PM_Schedule_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        if (ProcStep == '1')
                        {
                            if (RowIndex == - 1)
                            {
                                for (i = 0; i <= out_node.GetList("PM_LIST").Count - 1; i++)
                                {
                                    if (i == 0)
                                    {
                                        for (j = 0; j <= spdYear.Sheets[0].RowCount - 1; j++)
                                        {
                                            if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("RES_ID")) == MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[j, 0].Text))
                                            {
                                                iSelRow = j;
                                                break;
                                            }
                                        }
                                    }
                                    else if (out_node.GetList("PM_LIST")[i].GetString("RES_ID") != out_node.GetList("PM_LIST")[i - 1].GetString("RES_ID"))
                                    {
                                        for (j = 0; j <= spdYear.Sheets[0].RowCount - 1; j++)
                                        {
                                            if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("RES_ID")) == MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[j, 0].Text))
                                            {
                                                iSelRow = j;
                                                break;
                                            }
                                        }
                                    }

                                    dSelDate = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE"));

                                    iSelCol = dSelDate.DayOfYear - 1;
                                    
                                    spdYear.Sheets[0].SetValue(iSelRow, iSelCol, MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_PERIOD")));
                                    spdYear.Sheets[0].Cells[iSelRow, iSelCol].Note = MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_COMMENT"));

                                    if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "Y")
                                    {
                                        spdYear.Sheets[0].Cells[iSelRow, iSelCol].BackColor = System.Drawing.Color.Blue;
                                    }
                                    else if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "U")
                                    {
                                        spdYear.Sheets[0].Cells[iSelRow, iSelCol].BackColor = System.Drawing.Color.Yellow;
                                    }
                                }
                            }
                            else
                            {
                                iPMSchCnt += out_node.GetList("PM_LIST").Count;

                                for (i = 0; i <= out_node.GetList("PM_LIST").Count - 1; i++)
                                {
                                    dSelDate = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE"));
                                    iSelCol = dSelDate.DayOfYear - 1;

                                    spdYear.Sheets[0].SetText(RowIndex, iSelCol, MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_PERIOD")));
                                    spdYear.Sheets[0].Cells[RowIndex, iSelCol].Note = MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_COMMENT"));

                                    if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "Y")
                                    {
                                        spdYear.Sheets[0].Cells[RowIndex, iSelCol].BackColor = System.Drawing.Color.Blue;
                                    }
                                    else if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "U")
                                    {
                                        spdYear.Sheets[0].Cells[RowIndex, iSelCol].BackColor = System.Drawing.Color.Yellow;
                                    }
                                }

                                spdYear.Sheets[0].RowHeader.Cells[RowIndex, 2].Text = MPCF.Trim(iPMSchCnt);
                            }

                            iIndex = 0;
                            if (RowIndex == -1)
                            {
                                for (i = LastRow; i <= spdYear.Sheets[0].RowCount - 1; i++)
                                {
                                    if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && MPCF.CheckNumeric(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                                    {
                                        if (MPCF.ToInt(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                                        {
                                            if (iIndex >= MAX_RES_CNT)
                                            {
                                                break;
                                            }
                                            iIndex++;
                                        }
                                    }
                                }
                            }

                            iIndex = 0;

                            if (out_node.GetList("RES_LIST").Count > 0)
                            {
                                for (j = 0; j <= out_node.GetList("RES_LIST").Count - 1; j++)
                                {
                                    in_node.GetList(0)[iIndex].SetString("NEXT_RES_ID", out_node.GetList("RES_LIST")[j].GetString("NEXT_RES_ID"));
                                    in_node.GetList(0)[iIndex].SetString("NEXT_PM_PLAN_DATE", out_node.GetList("RES_LIST")[j].GetString("NEXT_PM_PLAN_DATE"));
                                    iIndex++;
                                }
                            }
                            
                            if (RowIndex == - 1)
                            {
                                for (i = LastRow; i <= spdYear.Sheets[0].RowCount - 1; i++)
                                {
                                    if (MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && MPCF.CheckNumeric(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                                    {
                                        if (MPCF.ToInt(spdYear.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                                        {
                                            if (iIndex >= MAX_RES_CNT)
                                            {
                                                break;
                                            }
                                            in_node.GetList(0)[iIndex].AddString("NEXT_RES_ID", MPCF.Trim(spdYear.Sheets[0].RowHeader.Cells[i, 0].Text));
                                            in_node.GetList(0)[iIndex].AddString("NEXT_PM_PLAN_DATE", "");
                                            
                                            iIndex++;
                                        }
                                    }
                                }
                                
                                LastRow = i;
                            }
                            
                            //If RowIndex = -1 And iIndex = 0 Then
                            //    spdYear.Sheets(0).RowHeader.Cells(iSelRow, 2).Text = CStr(iPMSchCnt)
                            //End If
                            
                        }
                        else if (ProcStep == '2' || ProcStep == '3')
                        {
                            for (i = 0; i <= out_node.GetList("PM_LIST").Count - 1; i++)
                            {
                                if (nNote != null)
                                {
                                    nNote = null;
                                }
                                nNote = uciMonthInfo.Notes.Add(MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE")),
                                    MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("RES_ID")) + "\r\n" + "PM Period : " + MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_PERIOD")) + "\r\n" + "PM Comment : " + out_node.GetList("PM_LIST")[i].GetString("PM_COMMENT")
                                );
                                if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "Y")
                                {
                                    nNote.Appearance.BackColor = System.Drawing.Color.Blue;
                                }
                                else if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "U")
                                {
                                    nNote.Appearance.BackColor = System.Drawing.Color.Yellow;
                                }
                                if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("pm_comment")) != "")
                                {
                                    nNote.Appearance.Image = picComment.Image;
                                    nNote.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;
                                    nNote.Appearance.ImageVAlign = Infragistics.Win.VAlign.Top;
                                }
                            }

                            if (out_node.GetList("RES_LIST").Count > 0)
                            {
                                in_node.GetList(0)[0].SetString("NEXT_RES_ID", out_node.GetList("RES_LIST")[0].GetString("NEXT_RES_ID"));
                                in_node.GetList(0)[0].SetString("NEXT_PM_PLAN_DATE", out_node.GetList("RES_LIST")[0].GetString("NEXT_PM_PLAN_DATE"));                                
                            }
                        }
                        
                    } while (in_node.ListCount != 0 && in_node.GetList(0).Count !=0 && out_node.GetList(0)[0].GetString("NEXT_PM_PLAN_DATE") != "");
                    
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
                    return this.dtpCalendar;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return null;
                }
                
            }
            
            #endregion
            
            private void frmRASSetupPMSchedule_Activated(object sender, System.EventArgs e)
            {
                
                //        int i;
                
                try
                {
                    if (LoadFlag == false)
                    {
                        dtpCalendar.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);

                        SetCalendar();
                        InitSpreadTip();
                        
                        if (View_PM_Schedule_List('3', - 1) == false)
                        {
                            return;
                        }
                        
                        if (View_PM_Resource_List('2') == false)
                        {
                            return;
                        }
                        
                        if (View_PM_Schedule_List('1', - 1) == false)
                        {
                            return;
                        }
                        
                        LoadFlag = true;
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void frmRASSetupPMSchedule_Load(System.Object sender, System.EventArgs e)
            {
                
                try
                {
                    bInitComponentFlag = true;
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void cdvResType_ButtonPress(System.Object sender, System.EventArgs e)
            {
                
                try
                {
                    cdvResType.Init();
                    MPCF.InitListView(cdvResType.GetListView);
                    cdvResType.Columns.Add("Type", 100, HorizontalAlignment.Left);
                    cdvResType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvResType.SelectedSubItemIndex = 0;
                    cdvResType.ReadOnly = true;
                    BASLIST.ViewGCMDataList(cdvResType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
                    cdvResType.AddEmptyRow(1);
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void spdYear_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
            {
                
                try
                {
                    if (e.Column > 0 && e.Row >= 0)
                    {
                        spdYear.Sheets[0].SetValue(e.Row, 0, true);
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void btnProcess_Click(System.Object sender, System.EventArgs e)
            {
                
                try
                {
                    if (View_PM_Schedule_List('3', - 1) == false)
                    {
                        return;
                    }
                    
                    if (View_PM_Resource_List('2') == false)
                    {
                        return;
                    }
                    
                    if (View_PM_Schedule_List('1', - 1) == false)
                    {
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void spdYear_CellDoubleClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
            {
                
                //Dim frmPMInfo As frmRASViewPMScheduleDetail = Nothing
                //Dim sResID As String = Nothing
                //Dim sPMPlanDate As String = Nothing
                
                try
                {
                    //With spdYear.Sheets(0)
                    //    If .ActiveRowIndex < 0 Then Exit Sub
                    //    If .ActiveColumnIndex < 0 Then Exit Sub
                    //    If Trim(.ColumnHeader.Cells(0, .ActiveColumnIndex).Text) = "" Then Exit Sub
                    //    If Trim(.ColumnHeader.Cells(1, .ActiveColumnIndex).Text) = "" Then Exit Sub
                    
                    //    sResID = RTrim(.RowHeader.Cells(.ActiveRowIndex, 0).Text)
                    //    sPMPlanDate = RTrim(dtpCalendar.Value.Year.ToString).PadLeft(4, '0') & Trim(.ColumnHeader.Cells(0, .ActiveColumnIndex).Text.ToString).PadLeft(2, '0') & Trim(.ColumnHeader.Cells(1, .ActiveColumnIndex).Text.ToString).PadLeft(2, '0')
                    
                    //    frmPMInfo = New frmRASViewPMScheduleDetail(sResID, MakeDateFormat(sPMPlanDate, DATE_TIME_FORMAT.DATE))
                    //    frmPMInfo.ShowDialog()
                    
                    //End With
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void spdYear_TextTipFetch(System.Object sender, FarPoint.Win.Spread.TextTipFetchEventArgs e)
            {
                
                try
                {
                    //Display the cell note
                    if (e.FetchCellNote && MPCF.Trim(spdYear.Sheets[0].Cells[e.Row, e.Column].Note) != "")
                    {
                        e.TipText = spdYear.Sheets[0].Cells[e.Row, e.Column].Note;
                        e.WrapText = true;
                        e.TipWidth = 130;
                        e.ShowTip = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void dtpCalendar_TextChanged(object sender, System.EventArgs e)
            {
                
                int iPrevYear;
                
                try
                {
                    if (bInitComponentFlag == false)
                    {
                        return;
                    }
                    
                    iPrevYear = iSelYear;
                    
                    SetCalendar();
                    
                    if (View_PM_Schedule_List('3', - 1) == false)
                    {
                        return;
                    }
                    
                    if (iPrevYear != dtpCalendar.Value.Year)
                    {
                        if (View_PM_Resource_List('2') == false)
                        {
                            return;
                        }
                        
                        if (View_PM_Schedule_List('1', - 1) == false)
                        {
                            return;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox("dtpCalendar_TextChanged" + ex.Message);
                }
                
            }
            
            private void btnExcel_Click(System.Object sender, System.EventArgs e)
            {
                try
                {
                    string sCond = "";
                    int iStartCol;
                    int iEndCol;
                    DateTime dDate;
                    sCond = "Year : " + this.dtpCalendar.Value.Year.ToString("0000");
                    
                    dDate = new System.DateTime(dtpCalendar.Value.Year, 6, 30);
                    if (rbnFirst.Checked == true)
                    {
                        iStartCol = 0;
                        iEndCol = dDate.DayOfYear - 1;
                    }
                    else
                    {
                        iStartCol = dDate.DayOfYear;
                        iEndCol = spdYear.Sheets[0].ColumnCount - 1;
                    }
                    if (tabCalendar.SelectedIndex == 0)
                    {
                        //Do Nothing
                    }
                    else
                    {
                        MPCF.ExportToExcel(spdYear, this.Text, sCond, true, true, true, iStartCol, iEndCol);
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void umvsMonth_BeforeScroll(object sender, Infragistics.Win.UltraWinSchedule.BeforeScrollEventArgs e)
            {
                
                try
                {
                    if (bMonthScroll == false)
                    {
                        e.Cancel = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void uciMonthInfo_AfterActiveDayChanged(object sender, Infragistics.Win.UltraWinSchedule.AfterActiveDayChangedEventArgs e)
            {
                Infragistics.Win.UltraWinSchedule.Note nNote;
                
                try
                {
                    if (umvsMonth.ActiveOwner != null)
                    {
                        return;
                    }
                    
                    txtPMInfo.Text = "";
                    
                    foreach (Infragistics.Win.UltraWinSchedule.Note tempLoopVar_nNote in uciMonthInfo.ActiveDay.Notes)
                    {
                        nNote = tempLoopVar_nNote;
                        if (nNote == null)
                        {
                            goto endOfForLoop;
                        }
                        //If Trim(txtPMInfo.Text) <> "" Then
                        //    txtPMInfo.Text = txtPMInfo.Text _
                        //       & (char)13 & "------------------------------------" & (char)13
                        //End If
                        txtPMInfo.Text = txtPMInfo.Text + "------------------------------------------------" + "\r\n" + MPCF.SubtractString(nNote.Description, "\r\n", false, false) + "\r\n" + "------------------------------------------------" + "\r\n" + MPCF.SubtractString(nNote.Description, "\r\n", true, false) + "\r\n";
                    }
endOfForLoop:
                    1.GetHashCode() ; //nop
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void mnuPMInfo_Click(System.Object sender, System.EventArgs e)
            {
                
                frmRASViewPMScheduleDetail frmPMInfo = null;
                
                try
                {
                    if (sResID == "" || sPMPlanDate == "")
                    {
                        return;
                    }
                    
                    frmPMInfo = new frmRASViewPMScheduleDetail(sResID, MPCF.MakeDateFormat(sPMPlanDate, DATE_TIME_FORMAT.DATE));
                    frmPMInfo.ShowDialog(this);
                    frmPMInfo = null;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void umvsMonth_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                
                Infragistics.Win.UltraWinSchedule.Note nNote = null;
                Infragistics.Win.UltraWinSchedule.Day dDate = null;
                
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        
                        sResID = null;
                        sPMPlanDate = null;
                        
                        nNote = umvsMonth.GetNoteFromPoint(e.X, e.Y);
                        dDate = umvsMonth.GetDayFromPoint(e.X, e.Y);
                        
                        if (nNote == null)
                        {
                            return;
                        }
                        if (dDate == null)
                        {
                            return;
                        }
                        
                        nNote.Selected = true;
                        uciMonthInfo.ActiveDay = dDate;

                        sResID = MPCF.Trim(MPCF.SubtractString(nNote.Description, "\r\n", false, false));
                        sPMPlanDate = dDate.Date.Year.ToString("0000") + dDate.Date.Month.ToString("00") + dDate.Date.Day.ToString("00");
                        
                        ctxMenu.Show(umvsMonth, new Point(e.X, e.Y));
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void spdYear_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
            {
                
                FarPoint.Win.Spread.Model.CellRange cCellRange;
                int iRow = - 1;
                int iCol = - 1;
                
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        
                        sResID = null;
                        sPMPlanDate = null;
                        
                        cCellRange = spdYear.GetCellFromPixel(0, 0, e.X, e.Y);
                        
                        if (cCellRange == null)
                        {
                            return;
                        }
                        iRow = cCellRange.Row;
                        iCol = cCellRange.Column;
                        if (iRow < 0 || iCol < 0)
                        {
                            return;
                        }
                        
                        FarPoint.Win.Spread.SheetView with_1 = spdYear.Sheets[0];
                        with_1.SetActiveCell(iRow, iCol);

                        if (MPCF.Trim(with_1.GetText(iRow, iCol)) == "")
                        {
                            return;
                        }
                        if (MPCF.Trim(with_1.RowHeader.Cells[iRow, 0].Text) == "")
                        {
                            return;
                        }
                        if (MPCF.Trim(with_1.ColumnHeader.Cells[0, iCol].Text) == "")
                        {
                            return;
                        }
                        if (MPCF.Trim(with_1.ColumnHeader.Cells[1, iCol].Text) == "")
                        {
                            return;
                        }
                        sResID = MPCF.Trim(with_1.RowHeader.Cells[with_1.ActiveRowIndex, 0].Text);
                        sPMPlanDate = MPCF.Trim(dtpCalendar.Value.Year).PadLeft(4, '0') +
                                      MPCF.Trim(with_1.ColumnHeader.Cells[0, with_1.ActiveColumnIndex].Text).PadLeft(2, '0') +
                                      MPCF.Trim(with_1.ColumnHeader.Cells[1, with_1.ActiveColumnIndex].Text).PadLeft(2, '0');
                        
                        ctxMenu.Show(spdYear, new Point(e.X, e.Y));
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                
            }
            
            private void tabCalendar_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                try
                {
                    if (tabCalendar.SelectedTab == tbpMonthView)
                    {
                        btnExcel.Visible = false;
                        pnlExcelOption.Visible = false;
                    }
                    else
                    {
                        btnExcel.Visible = true;
                        pnlExcelOption.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }
            
            
        }
        
    }
