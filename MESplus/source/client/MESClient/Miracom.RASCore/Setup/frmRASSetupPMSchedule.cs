
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
//       - View_PM_Resource_List() :PM Schedule ????? ??? Resource List?????????
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

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public class frmRASSetupPMSchedule : Miracom.CliFrx.BaseForm04
    {

        #region " Windows Form auto generated code "

        public frmRASSetupPMSchedule()
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




        private System.Windows.Forms.Panel pnlCenterTop;
        private System.Windows.Forms.Panel pnlCenterMiddle;
        private System.Windows.Forms.Panel pnlTopLeft;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPMPeriod;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.GroupBox grpCalendar;
        private System.Windows.Forms.GroupBox grpPMPeriod;
        private System.Windows.Forms.GroupBox grpEtc;
        private System.Windows.Forms.Panel pnlTopCenter;
        private System.Windows.Forms.Panel pnlTopRight;
        private System.Windows.Forms.DateTimePicker dtpCalendar;
        private System.Windows.Forms.RadioButton rbnYearMonth;
        private System.Windows.Forms.RadioButton rbnYear;
        private System.Windows.Forms.RadioButton rbnPeriodic;
        private System.Windows.Forms.RadioButton rbnNonPeriodic;
        private System.Windows.Forms.Label lblColorUnscheduled;
        private System.Windows.Forms.Label lblColorScheduled;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnView;
        private FarPoint.Win.Spread.FpSpread spdCalendar;
        private FarPoint.Win.Spread.SheetView spdCalendar_Sheet1;
        private System.Windows.Forms.ContextMenu ctxMenu;
        private System.Windows.Forms.MenuItem mnuPMComment;
        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel pnlExcelOption;
        private System.Windows.Forms.RadioButton rbnFirst;
        private System.Windows.Forms.RadioButton rbnSecond;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupPMSchedule));
            this.pnlCenterTop = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.grpEtc = new System.Windows.Forms.GroupBox();
            this.lblColorUnscheduled = new System.Windows.Forms.Label();
            this.lblColorScheduled = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblResType = new System.Windows.Forms.Label();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlTopCenter = new System.Windows.Forms.Panel();
            this.grpPMPeriod = new System.Windows.Forms.GroupBox();
            this.cdvPMPeriod = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnPeriodic = new System.Windows.Forms.RadioButton();
            this.rbnNonPeriodic = new System.Windows.Forms.RadioButton();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.dtpCalendar = new System.Windows.Forms.DateTimePicker();
            this.rbnYearMonth = new System.Windows.Forms.RadioButton();
            this.rbnYear = new System.Windows.Forms.RadioButton();
            this.pnlCenterMiddle = new System.Windows.Forms.Panel();
            this.spdCalendar = new FarPoint.Win.Spread.FpSpread();
            this.spdCalendar_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.mnuPMComment = new System.Windows.Forms.MenuItem();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlExcelOption = new System.Windows.Forms.Panel();
            this.rbnSecond = new System.Windows.Forms.RadioButton();
            this.rbnFirst = new System.Windows.Forms.RadioButton();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCenterTop.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.grpEtc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            this.pnlTopCenter.SuspendLayout();
            this.grpPMPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPMPeriod)).BeginInit();
            this.pnlTopLeft.SuspendLayout();
            this.grpCalendar.SuspendLayout();
            this.pnlCenterMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar_Sheet1)).BeginInit();
            this.pnlExcelOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlExcelOption);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlExcelOption, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCenterMiddle);
            this.pnlCenter.Controls.Add(this.pnlCenterTop);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "PM Schedule Setup";
            // 
            // pnlCenterTop
            // 
            this.pnlCenterTop.Controls.Add(this.pnlTopRight);
            this.pnlCenterTop.Controls.Add(this.pnlTopCenter);
            this.pnlCenterTop.Controls.Add(this.pnlTopLeft);
            this.pnlCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenterTop.Location = new System.Drawing.Point(0, 0);
            this.pnlCenterTop.Name = "pnlCenterTop";
            this.pnlCenterTop.Padding = new System.Windows.Forms.Padding(1);
            this.pnlCenterTop.Size = new System.Drawing.Size(742, 92);
            this.pnlCenterTop.TabIndex = 0;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.grpEtc);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRight.Location = new System.Drawing.Point(442, 1);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Padding = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.pnlTopRight.Size = new System.Drawing.Size(299, 90);
            this.pnlTopRight.TabIndex = 2;
            // 
            // grpEtc
            // 
            this.grpEtc.Controls.Add(this.lblColorUnscheduled);
            this.grpEtc.Controls.Add(this.lblColorScheduled);
            this.grpEtc.Controls.Add(this.lblAreaID);
            this.grpEtc.Controls.Add(this.lblResType);
            this.grpEtc.Controls.Add(this.cdvResType);
            this.grpEtc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEtc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEtc.Location = new System.Drawing.Point(3, 1);
            this.grpEtc.Name = "grpEtc";
            this.grpEtc.Size = new System.Drawing.Size(293, 84);
            this.grpEtc.TabIndex = 0;
            this.grpEtc.TabStop = false;
            this.grpEtc.Text = " Resource Type && Etc";
            // 
            // lblColorUnscheduled
            // 
            this.lblColorUnscheduled.BackColor = System.Drawing.Color.Yellow;
            this.lblColorUnscheduled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColorUnscheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorUnscheduled.Location = new System.Drawing.Point(186, 50);
            this.lblColorUnscheduled.Name = "lblColorUnscheduled";
            this.lblColorUnscheduled.Size = new System.Drawing.Size(67, 20);
            this.lblColorUnscheduled.TabIndex = 4;
            this.lblColorUnscheduled.Text = "Unschduled";
            this.lblColorUnscheduled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColorScheduled
            // 
            this.lblColorScheduled.BackColor = System.Drawing.Color.Blue;
            this.lblColorScheduled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblColorScheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorScheduled.Location = new System.Drawing.Point(108, 50);
            this.lblColorScheduled.Name = "lblColorScheduled";
            this.lblColorScheduled.Size = new System.Drawing.Size(68, 20);
            this.lblColorScheduled.TabIndex = 3;
            this.lblColorScheduled.Text = "Scheduled";
            this.lblColorScheduled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(16, 52);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(88, 13);
            this.lblAreaID.TabIndex = 2;
            this.lblAreaID.Text = "Action Backcolor";
            this.lblAreaID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(16, 25);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            this.lblResType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResType.Location = new System.Drawing.Point(106, 23);
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
            // pnlTopCenter
            // 
            this.pnlTopCenter.Controls.Add(this.grpPMPeriod);
            this.pnlTopCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopCenter.Location = new System.Drawing.Point(208, 1);
            this.pnlTopCenter.Name = "pnlTopCenter";
            this.pnlTopCenter.Padding = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.pnlTopCenter.Size = new System.Drawing.Size(234, 90);
            this.pnlTopCenter.TabIndex = 1;
            // 
            // grpPMPeriod
            // 
            this.grpPMPeriod.Controls.Add(this.cdvPMPeriod);
            this.grpPMPeriod.Controls.Add(this.rbnPeriodic);
            this.grpPMPeriod.Controls.Add(this.rbnNonPeriodic);
            this.grpPMPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPMPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPMPeriod.Location = new System.Drawing.Point(3, 1);
            this.grpPMPeriod.Name = "grpPMPeriod";
            this.grpPMPeriod.Size = new System.Drawing.Size(228, 84);
            this.grpPMPeriod.TabIndex = 0;
            this.grpPMPeriod.TabStop = false;
            this.grpPMPeriod.Text = " PM Period";
            // 
            // cdvPMPeriod
            // 
            this.cdvPMPeriod.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPMPeriod.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPMPeriod.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPMPeriod.BtnToolTipText = "";
            this.cdvPMPeriod.DescText = "";
            this.cdvPMPeriod.DisplaySubItemIndex = -1;
            this.cdvPMPeriod.DisplayText = "";
            this.cdvPMPeriod.Focusing = null;
            this.cdvPMPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPMPeriod.Index = 0;
            this.cdvPMPeriod.IsViewBtnImage = false;
            this.cdvPMPeriod.Location = new System.Drawing.Point(16, 50);
            this.cdvPMPeriod.MaxLength = 20;
            this.cdvPMPeriod.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPMPeriod.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPMPeriod.Name = "cdvPMPeriod";
            this.cdvPMPeriod.ReadOnly = false;
            this.cdvPMPeriod.SearchSubItemIndex = 0;
            this.cdvPMPeriod.SelectedDescIndex = -1;
            this.cdvPMPeriod.SelectedSubItemIndex = -1;
            this.cdvPMPeriod.SelectionStart = 0;
            this.cdvPMPeriod.Size = new System.Drawing.Size(161, 20);
            this.cdvPMPeriod.SmallImageList = null;
            this.cdvPMPeriod.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPMPeriod.TabIndex = 2;
            this.cdvPMPeriod.TextBoxToolTipText = "";
            this.cdvPMPeriod.TextBoxWidth = 161;
            this.cdvPMPeriod.VisibleButton = true;
            this.cdvPMPeriod.VisibleColumnHeader = false;
            this.cdvPMPeriod.VisibleDescription = false;
            this.cdvPMPeriod.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPMPeriod_SelectedItemChanged);
            this.cdvPMPeriod.ButtonPress += new System.EventHandler(this.cdvPMPeriod_ButtonPress);
            // 
            // rbnPeriodic
            // 
            this.rbnPeriodic.AutoSize = true;
            this.rbnPeriodic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnPeriodic.Location = new System.Drawing.Point(118, 23);
            this.rbnPeriodic.Name = "rbnPeriodic";
            this.rbnPeriodic.Size = new System.Drawing.Size(63, 17);
            this.rbnPeriodic.TabIndex = 1;
            this.rbnPeriodic.Text = "Periodic";
            // 
            // rbnNonPeriodic
            // 
            this.rbnNonPeriodic.AutoSize = true;
            this.rbnNonPeriodic.Checked = true;
            this.rbnNonPeriodic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNonPeriodic.Location = new System.Drawing.Point(16, 23);
            this.rbnNonPeriodic.Name = "rbnNonPeriodic";
            this.rbnNonPeriodic.Size = new System.Drawing.Size(86, 17);
            this.rbnNonPeriodic.TabIndex = 0;
            this.rbnNonPeriodic.TabStop = true;
            this.rbnNonPeriodic.Text = "Non Periodic";
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.grpCalendar);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopLeft.Location = new System.Drawing.Point(1, 1);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Padding = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.pnlTopLeft.Size = new System.Drawing.Size(207, 90);
            this.pnlTopLeft.TabIndex = 0;
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.dtpCalendar);
            this.grpCalendar.Controls.Add(this.rbnYearMonth);
            this.grpCalendar.Controls.Add(this.rbnYear);
            this.grpCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCalendar.Location = new System.Drawing.Point(3, 1);
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.Size = new System.Drawing.Size(201, 84);
            this.grpCalendar.TabIndex = 0;
            this.grpCalendar.TabStop = false;
            this.grpCalendar.Text = " Calendar Mode";
            // 
            // dtpCalendar
            // 
            this.dtpCalendar.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendar.CustomFormat = "yyyy";
            this.dtpCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCalendar.Location = new System.Drawing.Point(16, 50);
            this.dtpCalendar.Name = "dtpCalendar";
            this.dtpCalendar.ShowUpDown = true;
            this.dtpCalendar.Size = new System.Drawing.Size(143, 20);
            this.dtpCalendar.TabIndex = 2;
            this.dtpCalendar.Value = new System.DateTime(2005, 5, 5, 9, 17, 11, 705);
            this.dtpCalendar.TextChanged += new System.EventHandler(this.dtpCalendar_TextChanged);
            // 
            // rbnYearMonth
            // 
            this.rbnYearMonth.AutoSize = true;
            this.rbnYearMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnYearMonth.Location = new System.Drawing.Point(78, 23);
            this.rbnYearMonth.Name = "rbnYearMonth";
            this.rbnYearMonth.Size = new System.Drawing.Size(89, 17);
            this.rbnYearMonth.TabIndex = 1;
            this.rbnYearMonth.Text = "Year && Month";
            this.rbnYearMonth.CheckedChanged += new System.EventHandler(this.rbnYearMonth_CheckedChanged);
            // 
            // rbnYear
            // 
            this.rbnYear.AutoSize = true;
            this.rbnYear.Checked = true;
            this.rbnYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnYear.Location = new System.Drawing.Point(16, 23);
            this.rbnYear.Name = "rbnYear";
            this.rbnYear.Size = new System.Drawing.Size(50, 17);
            this.rbnYear.TabIndex = 0;
            this.rbnYear.TabStop = true;
            this.rbnYear.Text = "Year ";
            // 
            // pnlCenterMiddle
            // 
            this.pnlCenterMiddle.Controls.Add(this.spdCalendar);
            this.pnlCenterMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterMiddle.Location = new System.Drawing.Point(0, 92);
            this.pnlCenterMiddle.Name = "pnlCenterMiddle";
            this.pnlCenterMiddle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenterMiddle.Size = new System.Drawing.Size(742, 414);
            this.pnlCenterMiddle.TabIndex = 0;
            // 
            // spdCalendar
            // 
            this.spdCalendar.AccessibleDescription = "";
            this.spdCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCalendar.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalendar.HorizontalScrollBar.Name = "";
            this.spdCalendar.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCalendar.HorizontalScrollBar.TabIndex = 2;
            this.spdCalendar.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalendar.Location = new System.Drawing.Point(3, 0);
            this.spdCalendar.Name = "spdCalendar";
            this.spdCalendar.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCalendar.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCalendar.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCalendar_Sheet1});
            this.spdCalendar.Size = new System.Drawing.Size(736, 414);
            this.spdCalendar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCalendar.TabIndex = 0;
            this.spdCalendar.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdCalendar.TextTipAppearance = tipAppearance1;
            this.spdCalendar.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
            this.spdCalendar.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalendar.VerticalScrollBar.Name = "";
            this.spdCalendar.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCalendar.VerticalScrollBar.TabIndex = 3;
            this.spdCalendar.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalendar.TextTipFetch += new FarPoint.Win.Spread.TextTipFetchEventHandler(this.spdCalendar_TextTipFetch);
            this.spdCalendar.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCalendar_CellDoubleClick);
            this.spdCalendar.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalendar_EditChange);
            this.spdCalendar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdCalendar_MouseUp);
            this.spdCalendar.SetActiveViewport(0, -1, -1);
            // 
            // spdCalendar_Sheet1
            // 
            this.spdCalendar_Sheet1.Reset();
            spdCalendar_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCalendar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCalendar_Sheet1.ColumnCount = 0;
            spdCalendar_Sheet1.ColumnHeader.RowCount = 2;
            spdCalendar_Sheet1.RowCount = 0;
            spdCalendar_Sheet1.RowHeader.ColumnCount = 3;
            this.spdCalendar_Sheet1.ActiveColumnIndex = -1;
            this.spdCalendar_Sheet1.ActiveRowIndex = -1;
            this.spdCalendar_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalendar_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCalendar_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalendar_Sheet1.ColumnHeader.Visible = false;
            this.spdCalendar_Sheet1.DataAutoSizeColumns = false;
            this.spdCalendar_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCalendar_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdCalendar_Sheet1.RowHeader.Columns.Get(1).Width = 38F;
            this.spdCalendar_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCalendar_Sheet1.Rows.Default.Height = 18F;
            this.spdCalendar_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCalendar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(558, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(467, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ctxMenu
            // 
            this.ctxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPMComment});
            // 
            // mnuPMComment
            // 
            this.mnuPMComment.Index = 0;
            this.mnuPMComment.Text = "PM Comment ";
            this.mnuPMComment.Click += new System.EventHandler(this.mnuPMComment_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlExcelOption
            // 
            this.pnlExcelOption.Controls.Add(this.rbnSecond);
            this.pnlExcelOption.Controls.Add(this.rbnFirst);
            this.pnlExcelOption.Location = new System.Drawing.Point(48, 8);
            this.pnlExcelOption.Name = "pnlExcelOption";
            this.pnlExcelOption.Size = new System.Drawing.Size(196, 24);
            this.pnlExcelOption.TabIndex = 3;
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
            // frmRASSetupPMSchedule
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupPMSchedule";
            this.Tag = "RAS1007";
            this.Text = "PM Schedule Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupPMSchedule_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupPMSchedule_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlCenterTop.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.grpEtc.ResumeLayout(false);
            this.grpEtc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            this.pnlTopCenter.ResumeLayout(false);
            this.grpPMPeriod.ResumeLayout(false);
            this.grpPMPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPMPeriod)).EndInit();
            this.pnlTopLeft.ResumeLayout(false);
            this.grpCalendar.ResumeLayout(false);
            this.grpCalendar.PerformLayout();
            this.pnlCenterMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar_Sheet1)).EndInit();
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

        private struct Schedule_List
        {
            public string ResID;
            public string PMPlanDate;
            public string PMPeriod;
            public string PMComment;
        }
        private List<Schedule_List> Overlap_List;

        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ('1', "2", "3")
        //
        private void ClearData(char ProcStep, int RowIndex)
        {
            //            int i = 0;

            try
            {
                if (ProcStep == '1')
                {
                    MPCF.ClearList(spdCalendar);
                }
                else if (ProcStep == '2')
                {
                    spdCalendar.Sheets[0].ClearRange(0, 0, spdCalendar.Sheets[0].RowCount - 1, spdCalendar.Sheets[0].ColumnCount - 1, true);
                    if (RowIndex > -1)
                    {
                        spdCalendar.Sheets[0].Cells[0, 0, spdCalendar.Sheets[0].RowCount - 1, spdCalendar.Sheets[0].ColumnCount - 1].BackColor = System.Drawing.Color.Empty;
                    }
                }
                else if (ProcStep == '3')
                {
                    if (spdCalendar.Sheets[0].RowCount > RowIndex)
                    {
                        spdCalendar.Sheets[0].ClearRange(RowIndex, 0, 1, spdCalendar.Sheets[0].ColumnCount, true);
                        spdCalendar.Sheets[0].Cells[RowIndex, 0, RowIndex, spdCalendar.Sheets[0].ColumnCount - 1].BackColor = System.Drawing.Color.Empty;
                    }
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

            //Set text tip
            spdCalendar.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            ttAppearance.BackColor = Color.FromArgb(255, 255, 192);
            ttAppearance.ForeColor = Color.FromArgb(0, 0, 80);
            ttAppearance.Font = tipfont;
            spdCalendar.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;

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
                            if (MPCF.CheckValue(cdvPMPeriod, 1) == false)
                            {
                                cdvPMPeriod.Focus();
                                return returnValue;
                            }

                            if (cdvPMPeriod.SelectedItem == null)
                            {
                                return returnValue;
                            }


                            if (spdCalendar.Sheets[0].ColumnCount == 0 || spdCalendar.Sheets[0].RowCount == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(176));
                                spdCalendar.Select();
                                return returnValue;
                            }

                            iChkCnt = spdCalendar.Sheets[0].SelectionCount;

                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(176));
                                spdCalendar.Select();
                                return false;
                            }
                            else if (iChkCnt > MAX_SCH_CNT)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(134));
                                spdCalendar.Select();
                                return false;
                            }

                            if (MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[spdCalendar.Sheets[0].ActiveRowIndex, 0].Text) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(121));
                                spdCalendar.Select();
                                return false;
                            }

                            if (dtpCalendar.Value.Year < DateTime.Now.Year)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(177));
                                spdCalendar.Select();
                                return returnValue;
                            }
                            else if (dtpCalendar.Value.Year == DateTime.Now.Year)
                            {
                                if (MPCF.CheckNumeric(spdCalendar.Sheets[0].ColumnHeader.Cells[0, spdCalendar.Sheets[0].ActiveColumnIndex].Text) == true)
                                {
                                    if (MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[0, spdCalendar.Sheets[0].ActiveColumnIndex].Text) < DateTime.Now.Month)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(177));
                                        spdCalendar.Select();
                                        return returnValue;
                                    }
                                    else if (MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[0, spdCalendar.Sheets[0].ActiveColumnIndex].Text) == DateTime.Now.Month)
                                    {
                                        if (MPCF.CheckNumeric(spdCalendar.Sheets[0].ColumnHeader.Cells[1, spdCalendar.Sheets[0].ActiveColumnIndex].Text) == true)
                                        {
                                            if (MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[1, spdCalendar.Sheets[0].ActiveColumnIndex].Text) < DateTime.Now.Day)
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(177));
                                                spdCalendar.Select();
                                                return returnValue;
                                            }
                                        }
                                        else
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(178));
                                            spdCalendar.Select();
                                            return returnValue;
                                        }
                                    }
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(178));
                                    spdCalendar.Select();
                                    return returnValue;
                                }
                            }

                        }
                        else if (ProcStep == MPGC.MP_STEP_DELETE)
                        {

                            if (spdCalendar.Sheets[0].ColumnCount == 0 || spdCalendar.Sheets[0].RowCount == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(176));
                                spdCalendar.Select();
                                return returnValue;
                            }

                            iChkCnt = spdCalendar.Sheets[0].SelectionCount;

                            if (iChkCnt == 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(176));
                                spdCalendar.Select();
                                return false;
                            }
                            else if (iChkCnt > MAX_SCH_CNT)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(134));
                                spdCalendar.Select();
                                return false;
                            }

                            foreach (FarPoint.Win.Spread.Model.CellRange tempLoopVar_cCellRange in spdCalendar.Sheets[0].GetSelections())
                            {
                                cCellRange = tempLoopVar_cCellRange;
                                if (cCellRange.RowCount == -1)
                                {
                                    iStartRow = 0;
                                    iEndRow = spdCalendar.Sheets[0].RowCount - 1;
                                }
                                else
                                {
                                    iStartRow = cCellRange.Row;
                                    iEndRow = cCellRange.Row + cCellRange.RowCount - 1;
                                }

                                for (i = iStartRow; i <= iEndRow; i++)
                                {
                                    if (MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(121));
                                        spdCalendar.Select();
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
            }
        }

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

            FarPoint.Win.Spread.SheetView with_1 = spdCalendar.Sheets[0];
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

            if (rbnYear.Checked == true)
            {
                for (i = 1; i <= 12; i++)
                {
                    for (j = 1; j <= System.DateTime.DaysInMonth(dtpCalendar.Value.Year, i); j++)
                    {
                        with_1.Columns.Add(with_1.ColumnCount, 1);
                        with_1.ColumnHeader.Cells[0, with_1.ColumnCount - 1].Text = MPCF.Trim(i);
                        with_1.ColumnHeader.Cells[1, with_1.ColumnCount - 1].Text = MPCF.Trim(j);
                    }
                    with_1.ColumnHeader.Cells[0, with_1.ColumnCount - (j - 1)].ColumnSpan = j - 1;
                }
            }
            else if (rbnYearMonth.Checked == true)
            {
                for (j = 1; j <= System.DateTime.DaysInMonth(dtpCalendar.Value.Year, dtpCalendar.Value.Month); j++)
                {
                    with_1.Columns.Add(with_1.ColumnCount, 1);
                    with_1.ColumnHeader.Cells[0, with_1.ColumnCount - 1].Text = MPCF.Trim(dtpCalendar.Value.Month);
                    with_1.ColumnHeader.Cells[1, with_1.ColumnCount - 1].Text = MPCF.Trim(j);
                }
                with_1.ColumnHeader.Cells[0, 0].ColumnSpan = j - 1;
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

            TRSNode in_node = new TRSNode("View_Carrier_Lot_List_In");
            TRSNode out_node;
            try
            {
                ClearData('1', 0);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("FROM_DATE", "");
                in_node.AddString("TO_DATE", "");
                in_node.AddString("PM_PLAN_YEAR", dtpCalendar.Value.Year.ToString("0000"));

                if (rbnYearMonth.Checked == true)
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
                in_node.AddString("NEXT_RES_ID", "");
                
                do
                {
                    out_node = new TRSNode("View_PM_Resource_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_PM_Resource_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                   

                    if (ProcStep == '1')
                    {
                        spdCalendar.Sheets[0].RowHeader.Columns[0].Width = 80;
                        spdCalendar.Sheets[0].RowHeader.Columns[1].Width = 100;
                        for (i = 0; i < out_node.GetList("RES_LIST").Count; i++)
                        {
                            spdCalendar.Sheets[0].RowCount++;
                            LastRow = spdCalendar.Sheets[0].RowCount - 1;

                            FarPoint.Win.Spread.SheetView with_1 = spdCalendar.Sheets[0];
                            with_1.RowHeader.Cells[LastRow, 0].Text = MPCF.Trim(out_node.GetList("RES_LIST")[i].GetString("RES_ID"));
                            with_1.RowHeader.Cells[LastRow, 1].Text = MPCF.Trim(out_node.GetList("RES_LIST")[i].GetString("RES_DESC"));
                            with_1.RowHeader.Cells[LastRow, 2].Text = MPCF.Trim(out_node.GetList("RES_LIST")[i].GetInt("PM_SCHEDULE_COUNT"));

                        }
                        in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));

                    }
                } while (in_node.GetString("NEXT_RES_ID") != "");

                if (spdCalendar.Sheets[0].RowCount > 0)
                {
                    spdCalendar.Sheets[0].Cells[0, 0, spdCalendar.Sheets[0].RowCount - 1, spdCalendar.Sheets[0].ColumnCount - 1].Locked = true;
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

            TRSNode in_node = new TRSNode("View_PM_Schedule_List_In");
            TRSNode out_node = new TRSNode("View_PM_Schedule_List_Out");
            TRSNode list;
           
            try
            {
                if (RowIndex == -1)
                {
                    ClearData('2', RowIndex);
                }
                else
                {
                    ClearData('3', RowIndex);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("FROM_DATE", "");
                in_node.AddString("TO_DATE", "");
                in_node.AddString("PM_PLAN_YEAR", dtpCalendar.Value.Year.ToString("0000"));


                if (rbnYearMonth.Checked == true)
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
                if (RowIndex == -1)
                {
                    for (i = 0; i < spdCalendar.Sheets[0].RowCount; i++)
                    {
                        if (MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && 
                            MPCF.CheckNumeric(spdCalendar.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                        {
                            if (MPCF.ToInt(spdCalendar.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                            {
                                if (iIndex >= MAX_RES_CNT)
                                {
                                    break;
                                }
                                list = in_node.AddNode("RES_LIST");

                                list.AddString("NEXT_RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text));
                                list.AddString("NEXT_PM_PLAN_DATE", "");
                                iIndex++;
                            }
                        }
                    }

                    LastRow = i;
                }
                else
                {
                    list = in_node.AddNode("RES_LIST");

                    list.AddString("NEXT_RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                    list.AddString("NEXT_PM_PLAN_DATE", "");
                    iIndex++;
                }

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_PM_Schedule_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (RowIndex == -1)
                    {
                        for (i = 0; i < out_node.GetList("PM_LIST").Count; i++)
                        {
                            if (i == 0)
                            {
                                for (j = 0; j < spdCalendar.Sheets[0].RowCount; j++)
                                {
                                    //iPMSchCnt = 0
                                    if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("RES_ID")) == MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[j, 0].Text))
                                    {
                                        iSelRow = j;
                                        break;
                                    }
                                }
                            }
                            else if (out_node.GetList("PM_LIST")[i].GetString("RES_ID") != out_node.GetList("PM_LIST")[i - 1].GetString("RES_ID"))                            
                            {
                                //spdYear.Sheets(0).RowHeader.Cells(iSelRow, 2).Text = CStr(iPMSchCnt)
                                //iPMSchCnt = 0
                                for (j = 0; j < spdCalendar.Sheets[0].RowCount; j++)
                                {
                                    if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("RES_ID")) == MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[j, 0].Text))
                                    {
                                        iSelRow = j;
                                        break;
                                    }
                                }
                            }

                            if (rbnYear.Checked == true)
                            {
                                dSelDate = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE"));
                                iSelCol = dSelDate.DayOfYear - 1;
                            }
                            else if (rbnYearMonth.Checked == true)
                            {
                                iSelCol = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE")).Day - 1;
                            }

                            //spdCalendar.Sheets[0].SetText(iSelRow, iSelCol, MPCF.Trim(View_PM_Schedule_List_Out.pm_schedule_list[i].pm_period));
                            spdCalendar.Sheets[0].SetValue(iSelRow, iSelCol, MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_PERIOD")));
                            spdCalendar.Sheets[0].Cells[iSelRow, iSelCol].Note = MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_COMMENT"));

                            if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "Y")
                            {
                                spdCalendar.Sheets[0].Cells[iSelRow, iSelCol].BackColor = System.Drawing.Color.Blue;
                            }
                            else if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "U")
                            {
                                spdCalendar.Sheets[0].Cells[iSelRow, iSelCol].BackColor = System.Drawing.Color.Yellow;
                            }

                            //iPMSchCnt += 1
                        }
                    }
                    else
                    {
                        iPMSchCnt += out_node.GetList("PM_LIST").Count;

                        for (i = 0; i < out_node.GetList("PM_LIST").Count; i++)
                        {
                            if (rbnYear.Checked == true)
                            {
                                dSelDate = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE"));
                                iSelCol = dSelDate.DayOfYear - 1;
                            }
                            else if (rbnYearMonth.Checked == true)
                            {
                                iSelCol = MPCF.ToDate(out_node.GetList("PM_LIST")[i].GetString("PM_PLAN_DATE")).Day - 1;
                            }

                            //spdCalendar.Sheets[0].SetText(RowIndex, iSelCol, MPCF.Trim(View_PM_Schedule_List_Out.pm_schedule_list[i].pm_period));
                            spdCalendar.Sheets[0].SetValue(RowIndex, iSelCol, MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_PERIOD")));
                            spdCalendar.Sheets[0].Cells[RowIndex, iSelCol].Note = MPCF.Trim(out_node.GetList("PM_LIST")[i].GetString("PM_COMMENT"));

                            if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "Y")
                            {
                                spdCalendar.Sheets[0].Cells[RowIndex, iSelCol].BackColor = System.Drawing.Color.Blue;
                            }
                            else if (MPCF.Trim(out_node.GetList("PM_LIST")[i].GetChar("PM_ACT_FLAG")) == "U")
                            {
                                spdCalendar.Sheets[0].Cells[RowIndex, iSelCol].BackColor = System.Drawing.Color.Yellow;
                            }
                        }

                        spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 2].Text = MPCF.Trim(iPMSchCnt);
                    }

                    iIndex = 0;
                    if (out_node.GetList("RES_LIST").Count > 0)
                    {
                        for (j = 0; j < out_node.GetList("RES_LIST").Count; j++)
                        {
                            in_node.GetList(0)[iIndex].SetString("NEXT_RES_ID", out_node.GetList("RES_LIST")[j].GetString("NEXT_RES_ID"));
                            in_node.GetList(0)[iIndex].SetString("NEXT_PM_PLAN_DATE", out_node.GetList("RES_LIST")[j].GetString("NEXT_PM_PLAN_DATE"));
                            iIndex++;
                        }
                    }

                    if (RowIndex == -1)
                    {
                        for (i = LastRow; i < spdCalendar.Sheets[0].RowCount; i++)
                        {
                            if (MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text) != "" && MPCF.CheckNumeric(spdCalendar.Sheets[0].RowHeader.Cells[i, 2].Text) == true)
                            {
                                if (MPCF.ToInt(spdCalendar.Sheets[0].RowHeader.Cells[i, 2].Text) > 0)
                                {
                                    if (iIndex >= MAX_RES_CNT)
                                    {
                                        break;
                                    }
                                    in_node.GetList(0)[iIndex].SetString("NEXT_RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text));
                                    in_node.GetList(0)[iIndex].SetString("NEXT_PM_PLAN_DATE", "");
                                    iIndex++;
                                }
                            }
                        }

                        LastRow = i;
                    }

                    //If RowIndex = -1 And iIndex = 0 Then
                    //    spdCalendar.Sheets(0).RowHeader.Cells(iSelRow, 2).Text = CStr(iPMSchCnt)
                    //End If

                } while (out_node.GetList("RES_LIST").Count > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_PM_Schedule_List()
        //       - Attach/Detach Collection Set to MFO
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_PM_Schedule_List(char ProcStep, int RowIndex)
        {
            int i, j, iIndex = 0, iPeriod = 0;
            string sPeriodUnit = "";
            int iStartCol = 0, iEndCol = 0, iStartRow = 0, iEndRow = 0;
            int iStartMonth = 0, iStartDay = 0;
            DateTime dTargetDate = new DateTime();
            string sTempStr = null;
            DateTime dSelDate = new DateTime();
            FarPoint.Win.Spread.Model.CellRange cCellRange;
            Schedule_List scl;

            TRSNode in_node = new TRSNode("Update_PM_Schedule_List_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
           
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                iIndex = 0;
                if (ProcStep == MPGC.MP_STEP_CREATE)
                {
                    iPeriod = MPCF.ToInt(cdvPMPeriod.SelectedItem.SubItems[2].Text);
                    sPeriodUnit = MPCF.Trim(cdvPMPeriod.SelectedItem.SubItems[3].Text);

                    if (RowIndex < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(176));
                        return false;
                    }

                    iStartCol = spdCalendar.Sheets[0].ActiveColumnIndex;
                    iStartMonth = MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text);
                    iStartDay = MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text);

                    if (rbnYearMonth.Checked == true)
                    {

                        if (rbnPeriodic.Checked == true)
                        {
                            if (sPeriodUnit == "D")
                            {
                                for (i = iStartCol; i <= spdCalendar.Sheets[0].ColumnCount - 1; i += iPeriod)
                                {
                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note);
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE", dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note));
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "W")
                            {
                                for (i = iStartCol; i <= spdCalendar.Sheets[0].ColumnCount - 1; i += iPeriod * 7)
                                {
                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note);
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID",  MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD",  MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE",dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", "");
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "M" || sPeriodUnit == "Q" || sPeriodUnit == "Y")
                            {
                                if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                                {
                                    //Do Nothing
                                }
                                else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                                {
                                    scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                    scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                    scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0');
                                    scl.PMComment = "";
                                    Overlap_List.Add(scl);
                                }
                                else
                                {
                                    TRSNode list = in_node.AddNode("PM_LIST");
                                    list.AddString("RES_ID", MPCF.Trim(MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text)));
                                    list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                    list.AddString("PM_PLAN_DATE", dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0'));
                                    list.AddString("PM_COMMENT", "");
                                    iIndex++;
                                }
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(179));
                                return false;
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(182));
                                return false;
                            }
                            else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(182));
                                return false;
                            }
                            else
                            {
                                TRSNode list = in_node.AddNode("PM_LIST");
                                list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0'));
                                list.AddString("PM_COMMENT", "");
                                iIndex++;
                            }
                        }

                    }
                    else if (rbnYear.Checked == true)
                    {
                        if (rbnPeriodic.Checked == true)
                        {
                            if (sPeriodUnit == "D")
                            {
                                for (i = iStartCol; i <= spdCalendar.Sheets[0].ColumnCount - 1; i += iPeriod)
                                {
                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note);
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note));
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "W")
                            {
                                for (i = iStartCol; i <= spdCalendar.Sheets[0].ColumnCount - 1; i += iPeriod * 7)
                                {
                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Note);
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", "");
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "M")
                            {
                                for (j = iStartMonth; j <= 12; j += iPeriod)
                                {
                                    if (j == iStartMonth)
                                    {
                                        dTargetDate = new System.DateTime(dtpCalendar.Value.Year, iStartMonth, iStartDay);
                                    }
                                    else
                                    {
                                        dTargetDate = dTargetDate.AddMonths(iPeriod);
                                    }
                                    i = dTargetDate.DayOfYear - 1;

                                    if (i >= spdCalendar.Sheets[0].ColumnCount - 1)
                                    {
                                        break;
                                    }

                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = "";
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", "");
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "Q")
                            {
                                for (j = iStartMonth; j <= 12; j += (3 * iPeriod))
                                {
                                    if (j == iStartMonth)
                                    {
                                        dTargetDate = new System.DateTime(dtpCalendar.Value.Year, iStartMonth, iStartDay);
                                    }
                                    else
                                    {
                                        dTargetDate = dTargetDate.AddMonths(3 * iPeriod);
                                    }

                                    i = dTargetDate.DayOfYear - 1;

                                    if (i >= spdCalendar.Sheets[0].ColumnCount - 1)
                                    {
                                        break;
                                    }

                                    if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        //Do Nothing
                                    }
                                    else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, i].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, i].BackColor.Name != "0")
                                    {
                                        scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                        scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                        scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0');
                                        scl.PMComment = "";
                                        Overlap_List.Add(scl);
                                    }
                                    else
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                        list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                        list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, i].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, i].Text)).PadLeft(2, '0'));
                                        list.AddString("PM_COMMENT", "");
                                        iIndex++;
                                    }
                                }
                            }
                            else if (sPeriodUnit == "Y")
                            {
                                if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                                {
                                    //Do Nothing
                                }
                                else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                                {
                                    scl.ResID = MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text);
                                    scl.PMPeriod = MPCF.Trim(cdvPMPeriod.Text);
                                    scl.PMPlanDate = dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0');
                                    scl.PMComment = "";
                                    Overlap_List.Add(scl);
                                }
                                else
                                {
                                    TRSNode list = in_node.AddNode("PM_LIST");
                                    list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                    list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                    list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0'));
                                    list.AddString("PM_COMMENT", "");
                                    iIndex++;
                                }
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(179));
                                return false;
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) == MPCF.Trim(cdvPMPeriod.Text) && spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(182));
                                return false;
                            }
                            else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].Text) != "" || spdCalendar.Sheets[0].Cells[RowIndex, iStartCol].BackColor.Name != "0")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(182));
                                return false;
                            }
                            else
                            {
                                TRSNode list = in_node.AddNode("PM_LIST");
                                list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[RowIndex, 0].Text));
                                list.AddString("PM_PERIOD", MPCF.Trim(cdvPMPeriod.Text));
                                list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, iStartCol].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, iStartCol].Text)).PadLeft(2, '0'));
                                list.AddString("PM_COMMENT", "");
                                iIndex++;
                            }
                        }
                    }

                }
                else if (ProcStep == MPGC.MP_STEP_DELETE)
                {

                    foreach (FarPoint.Win.Spread.Model.CellRange tempLoopVar_cCellRange in spdCalendar.Sheets[0].GetSelections())
                    {
                        cCellRange = tempLoopVar_cCellRange;
                        if (cCellRange.RowCount == -1 && cCellRange.ColumnCount == -1) //Sheet????? Cell??????????
                        {
                            iStartRow = 0;
                            iEndRow = spdCalendar.Sheets[0].RowCount - 1;
                            iStartCol = 0;
                            iEndCol = spdCalendar.Sheets[0].ColumnCount - 1;
                        }
                        else if (cCellRange.RowCount == -1 && cCellRange.ColumnCount > 0) //??? Column ??Cell ????? ????????
                        {
                            iStartRow = 0;
                            iEndRow = spdCalendar.Sheets[0].RowCount - 1;
                            iStartCol = cCellRange.Column;
                            iEndCol = cCellRange.Column + cCellRange.ColumnCount - 1;
                        }
                        else if (cCellRange.RowCount > 0 && cCellRange.ColumnCount == -1) //??? Row??Cell ????? ????????
                        {
                            iStartRow = cCellRange.Row;
                            iEndRow = cCellRange.Row + cCellRange.RowCount - 1;
                            iStartCol = 0;
                            iEndCol = spdCalendar.Sheets[0].ColumnCount - 1;
                        }
                        else //??? ?????Cell??? ????????
                        {
                            iStartRow = cCellRange.Row;
                            iEndRow = cCellRange.Row + cCellRange.RowCount - 1;
                            iStartCol = cCellRange.Column;
                            iEndCol = cCellRange.Column + cCellRange.ColumnCount - 1;
                        }

                        for (i = iStartRow; i <= iEndRow; i++)
                        {
                            for (j = iStartCol; j <= iEndCol; j++)
                            {
                                if (MPCF.Trim(spdCalendar.Sheets[0].Cells[i, j].Text) == "")
                                {
                                    //Do Nothing
                                }
                                else if (MPCF.Trim(spdCalendar.Sheets[0].Cells[i, j].Text) != "" && spdCalendar.Sheets[0].Cells[i, j].BackColor.Name != "0")
                                {
                                    //Do Nothing
                                }
                                else
                                {
                                    dSelDate = new System.DateTime(dtpCalendar.Value.Year, MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[0, j].Text), MPCF.ToInt(spdCalendar.Sheets[0].ColumnHeader.Cells[1, j].Text), 0, 0, 0);
                                    if (dSelDate >= new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0))
                                    {
                                        TRSNode list = in_node.AddNode("PM_LIST");
                                        list.AddString("RES_ID", MPCF.Trim(spdCalendar.Sheets[0].RowHeader.Cells[i, 0].Text));
                                        list.AddString("PM_PLAN_DATE",  dtpCalendar.Value.Year.ToString("0000") + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[0, j].Text)).PadLeft(2, '0') + (MPCF.Trim(spdCalendar.Sheets[0].ColumnHeader.Cells[1, j].Text)).PadLeft(2, '0'));
                                        iIndex++;
                                    }
                                }
                            }
                        }
                    }
                }

                if (iIndex == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(176));
                    return false;
                }

                if (Overlap_List.Count > 0)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(57), Application.ProductName, MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                    {
                        return false;
                    }
                }

                if (MPCR.CallService("RAS", "RAS_Update_PM_Schedule_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                else
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        //ShowMsgBox(GetMessage(52))
                        if (Overlap_List.Count > 0)
                        {
                            sTempStr = "(";
                            for (i = 0; i <= Overlap_List.Count - 1; i++)
                            {
                                if (i == 0)
                                {
                                    sTempStr = sTempStr + MPCF.MakeDateFormat(Overlap_List[i].PMPlanDate, DATE_TIME_FORMAT.DATE);
                                }
                                else
                                {
                                    sTempStr = sTempStr + " , " + MPCF.MakeDateFormat(Overlap_List[i].PMPlanDate, DATE_TIME_FORMAT.DATE);
                                }
                                if (sTempStr.Length > 340 && i < Overlap_List.Count - 1)
                                {
                                    sTempStr = sTempStr + " ......";
                                    break;
                                }
                            }
                            sTempStr = sTempStr + ")";
                            MPCF.ShowMsgBox(MPCF.GetMessage(56) + "\r\n" + sTempStr);
                        }

                        View_PM_Schedule_List('1', RowIndex);

                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        MPCR.ShowSuccessMsg(out_node);

                        for (i = iStartRow; i <= iEndRow; i++)
                        {
                            View_PM_Schedule_List('1', i);
                        }
                    }
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

                    SetCalendar();
                    InitSpreadTip();

                    if (View_PM_Resource_List('1') == false)
                    {
                        return;
                    }

                    if (View_PM_Schedule_List('1', -1) == false)
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
                dtpCalendar.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);

                cdvPMPeriod.Init();
                MPCF.InitListView(cdvPMPeriod.GetListView);
                cdvPMPeriod.Columns.Add("Period", 100, HorizontalAlignment.Left);
                cdvPMPeriod.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvPMPeriod.Columns.Add("PM ???", 200, HorizontalAlignment.Left);
                cdvPMPeriod.Columns.Add("PM ??? ???", 200, HorizontalAlignment.Left);
                cdvPMPeriod.Columns[2].Width = 0;
                cdvPMPeriod.Columns[3].Width = 0;
                cdvPMPeriod.SelectedSubItemIndex = 0;
                cdvPMPeriod.ReadOnly = true;

                bInitComponentFlag = true;

                Overlap_List = new List<Schedule_List>();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvPMPeriod_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            //If Trim(cdvPMPeriod.Text) = "" Then
            //    ClearData()
            //End If
        }

        private void cdvPMPeriod_ButtonPress(object sender, System.EventArgs e)
        {
            BASLIST.ViewGCMDataList(cdvPMPeriod.GetListView, '1', MPGC.MP_RAS_PM_PERIOD);
        }

        private void cdvResType_ButtonPress(System.Object sender, System.EventArgs e)
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

        private void spdCalendar_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdCalendar.Sheets[0].SetValue(e.Row, 0, true);
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {

            //        int i;

            if (View_PM_Resource_List('1') == false)
            {
                return;
            }

            if (View_PM_Schedule_List('1', -1) == false)
            {
                return;
            }

        }

        private void spdCalendar_CellDoubleClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (CheckCondition("Update_PM_Schedule_List", MPGC.MP_STEP_CREATE, -1, -1) == true)
            {
                Update_PM_Schedule_List(MPGC.MP_STEP_CREATE, e.Row);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("Update_PM_Schedule_List", MPGC.MP_STEP_DELETE, -1, -1) == true)
            {
                Update_PM_Schedule_List(MPGC.MP_STEP_DELETE, -1);
            }
        }

        private void spdCalendar_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange cCellRange;
            int iRow = -1;
            int iCol = -1;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cCellRange = spdCalendar.GetCellFromPixel(0, 0, e.X, e.Y);

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

                FarPoint.Win.Spread.SheetView with_1 = spdCalendar.Sheets[0];
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
                ctxMenu.Show(spdCalendar, new Point(e.X, e.Y));
            }
        }

        private void mnuPMComment_Click(System.Object sender, System.EventArgs e)
        {
            frmRASSetupPMComment frmComment = null;
            string sResID = null;
            string sPMPlanDate = null;
            string sPMPeriod = null;
            string sPMcomment = null;

            FarPoint.Win.Spread.SheetView with_1 = spdCalendar.Sheets[0];
            if (with_1.ActiveRowIndex < 0)
            {
                return;
            }
            if (with_1.ActiveColumnIndex < 0)
            {
                return;
            }
            if (MPCF.Trim(with_1.ColumnHeader.Cells[0, with_1.ActiveColumnIndex].Text) == "")
            {
                return;
            }
            if (MPCF.Trim(with_1.ColumnHeader.Cells[1, with_1.ActiveColumnIndex].Text) == "")
            {
                return;
            }
            if (with_1.Cells[with_1.ActiveRowIndex, with_1.ActiveColumnIndex].BackColor.Name != "0")
            {
                return;
            }

            sResID = MPCF.Trim(with_1.RowHeader.Cells[with_1.ActiveRowIndex, 0].Text);
            sPMPlanDate = MPCF.Trim(dtpCalendar.Value.Year).PadLeft(4, '0') + MPCF.Trim(with_1.ColumnHeader.Cells[0, with_1.ActiveColumnIndex].Text).PadLeft(2, '0') + MPCF.Trim(with_1.ColumnHeader.Cells[1, with_1.ActiveColumnIndex].Text).PadLeft(2, '0');
            sPMPeriod = MPCF.Trim(with_1.GetText(with_1.ActiveRowIndex, with_1.ActiveColumnIndex));
            sPMcomment = MPCF.Trim(with_1.GetNote(with_1.ActiveRowIndex, with_1.ActiveColumnIndex));

            frmComment = new frmRASSetupPMComment(sResID, MPCF.MakeDateFormat(sPMPlanDate, DATE_TIME_FORMAT.DATE), sPMPeriod, sPMcomment);
            if (frmComment.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                with_1.SetNote(with_1.ActiveRowIndex, with_1.ActiveColumnIndex, MPCF.Trim(frmComment.txtPMComment.Text));
                frmComment = null;
            }
        }

        private void spdCalendar_TextTipFetch(System.Object sender, FarPoint.Win.Spread.TextTipFetchEventArgs e)
        {
            //Display the cell note
            if (e.FetchCellNote && MPCF.Trim(spdCalendar.Sheets[0].Cells[e.Row, e.Column].Note) != "")
            {
                e.TipText = spdCalendar.Sheets[0].Cells[e.Row, e.Column].Note;
                e.WrapText = true;
                e.TipWidth = 130;
                e.ShowTip = true;
            }
        }

        private void rbnYearMonth_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (rbnYearMonth.Checked == true)
            {
                dtpCalendar.CustomFormat = "yyyy-MM";
                SetCalendar();
                pnlExcelOption.Visible = false;
            }
            else
            {
                dtpCalendar.CustomFormat = "yyyy";
                SetCalendar();
                pnlExcelOption.Visible = true;
            }
        }

        private void dtpCalendar_TextChanged(object sender, System.EventArgs e)
        {
            if (bInitComponentFlag == false)
            {
                return;
            }

            SetCalendar();
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond = "";
            int iStartCol;
            int iEndCol;
            DateTime dDate;
            if (rbnYearMonth.Checked == true)
            {
                sCond = "Year : " + this.dtpCalendar.Value.Year.ToString("0000") + "\n" + "Month : " + this.dtpCalendar.Value.Month.ToString("00") + "\n" + "Resource Type : " + cdvResType.Text;
                MPCF.ExportToExcel(spdCalendar, this.Text, sCond, true, true, true, -1, -1);
            }
            else
            {
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
                    iEndCol = spdCalendar.Sheets[0].ColumnCount - 1;
                }

                MPCF.ExportToExcel(spdCalendar, this.Text, sCond, true, true, true, iStartCol, iEndCol);
            }

        }


    }

}
