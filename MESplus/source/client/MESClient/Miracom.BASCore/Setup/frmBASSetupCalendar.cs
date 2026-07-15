
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupCalendar.vb
//   Description : Calendar Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Calendar()       : Create/Update/Delete Resource - Event Relation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.BASCore
{
    public class frmBASSetupCalendar : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmBASSetupCalendar()
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
        



        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.GroupBox grpCalendar;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCalendarType;
        private System.Windows.Forms.Label lblCalendarType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCalendarID;
        private System.Windows.Forms.Label lblCalendar;
        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.Label lblDayCount;
        private System.Windows.Forms.Label lblStartDay;
        private System.Windows.Forms.Label lblEndDay;
        private System.Windows.Forms.TextBox txtDayCount;
        private System.Windows.Forms.TextBox txtStartDay;
        private System.Windows.Forms.TextBox txtEndDay;
        private System.Windows.Forms.ComboBox cboFirstDayofWeek;
        private System.Windows.Forms.Label lblFirstDayofWeek;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblWorkHoursofMonday;
        private System.Windows.Forms.Label lblWorkHoursofTuesday;
        private System.Windows.Forms.Label lblWorkHoursofWednesday;
        private System.Windows.Forms.Label lblWorkHoursofThursday;
        private System.Windows.Forms.Label lblWorkHoursofFriday;
        private System.Windows.Forms.Label lblWorkHoursofSaturday;
        private System.Windows.Forms.Label lblWorkHoursofSunday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofMonday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofTuesday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofWednesday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofThursday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofFriday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofSaturday;
        private System.Windows.Forms.CheckBox chkIsHolidayMonday;
        private System.Windows.Forms.CheckBox chkHolidayTuesday;
        private System.Windows.Forms.CheckBox chkHolidayWednesday;
        private System.Windows.Forms.CheckBox chkHolidayThursday;
        private System.Windows.Forms.CheckBox chkHolidayFriday;
        private System.Windows.Forms.CheckBox chkHolidaySaturday;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWorkHoursofSunday;
        private System.Windows.Forms.CheckBox chkHolidaySunday;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cdvCalendarType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCalendarType = new System.Windows.Forms.Label();
            this.cdvCalendarID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.cboFirstDayofWeek = new System.Windows.Forms.ComboBox();
            this.lblFirstDayofWeek = new System.Windows.Forms.Label();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.txtDayCount = new System.Windows.Forms.TextBox();
            this.lblDayCount = new System.Windows.Forms.Label();
            this.lblStartDay = new System.Windows.Forms.Label();
            this.lblEndDay = new System.Windows.Forms.Label();
            this.txtStartDay = new System.Windows.Forms.TextBox();
            this.txtEndDay = new System.Windows.Forms.TextBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkHolidaySunday = new System.Windows.Forms.CheckBox();
            this.chkHolidaySaturday = new System.Windows.Forms.CheckBox();
            this.chkHolidayFriday = new System.Windows.Forms.CheckBox();
            this.chkHolidayThursday = new System.Windows.Forms.CheckBox();
            this.chkHolidayWednesday = new System.Windows.Forms.CheckBox();
            this.chkHolidayTuesday = new System.Windows.Forms.CheckBox();
            this.chkIsHolidayMonday = new System.Windows.Forms.CheckBox();
            this.txtWorkHoursofSunday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofSaturday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofFriday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofThursday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofWednesday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofTuesday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWorkHoursofMonday = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblWorkHoursofSunday = new System.Windows.Forms.Label();
            this.lblWorkHoursofSaturday = new System.Windows.Forms.Label();
            this.lblWorkHoursofFriday = new System.Windows.Forms.Label();
            this.lblWorkHoursofThursday = new System.Windows.Forms.Label();
            this.lblWorkHoursofWednesday = new System.Windows.Forms.Label();
            this.lblWorkHoursofTuesday = new System.Windows.Forms.Label();
            this.lblWorkHoursofMonday = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            this.grpCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCalendarType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCalendarID)).BeginInit();
            this.pnlDisplay.SuspendLayout();
            this.grpDisplay.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofSunday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofSaturday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofFriday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofThursday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofWednesday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofTuesday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofMonday)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "Create";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlDisplay);
            this.pnlCenter.Controls.Add(this.pnlCalendar);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Calendar Setup";
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Controls.Add(this.grpCalendar);
            this.pnlCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCalendar.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCalendar.Size = new System.Drawing.Size(742, 73);
            this.pnlCalendar.TabIndex = 0;
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.cboYear);
            this.grpCalendar.Controls.Add(this.lblYear);
            this.grpCalendar.Controls.Add(this.cdvCalendarType);
            this.grpCalendar.Controls.Add(this.lblCalendarType);
            this.grpCalendar.Controls.Add(this.cdvCalendarID);
            this.grpCalendar.Controls.Add(this.lblCalendar);
            this.grpCalendar.Controls.Add(this.cboFirstDayofWeek);
            this.grpCalendar.Controls.Add(this.lblFirstDayofWeek);
            this.grpCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCalendar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCalendar.Location = new System.Drawing.Point(3, 0);
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.Size = new System.Drawing.Size(736, 73);
            this.grpCalendar.TabIndex = 0;
            this.grpCalendar.TabStop = false;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.Location = new System.Drawing.Point(120, 40);
            this.cboYear.MaxLength = 4;
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(200, 21);
            this.cboYear.TabIndex = 5;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(15, 43);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year";
            // 
            // cdvCalendarType
            // 
            this.cdvCalendarType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCalendarType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCalendarType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCalendarType.BtnToolTipText = "";
            this.cdvCalendarType.DescText = "";
            this.cdvCalendarType.DisplaySubItemIndex = -1;
            this.cdvCalendarType.DisplayText = "";
            this.cdvCalendarType.Focusing = null;
            this.cdvCalendarType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCalendarType.Index = 0;
            this.cdvCalendarType.IsViewBtnImage = false;
            this.cdvCalendarType.Location = new System.Drawing.Point(120, 16);
            this.cdvCalendarType.MaxLength = 1;
            this.cdvCalendarType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCalendarType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCalendarType.Name = "cdvCalendarType";
            this.cdvCalendarType.ReadOnly = false;
            this.cdvCalendarType.SearchSubItemIndex = 0;
            this.cdvCalendarType.SelectedDescIndex = -1;
            this.cdvCalendarType.SelectedSubItemIndex = -1;
            this.cdvCalendarType.SelectionStart = 0;
            this.cdvCalendarType.Size = new System.Drawing.Size(200, 20);
            this.cdvCalendarType.SmallImageList = null;
            this.cdvCalendarType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCalendarType.TabIndex = 1;
            this.cdvCalendarType.TextBoxToolTipText = "";
            this.cdvCalendarType.TextBoxWidth = 200;
            this.cdvCalendarType.VisibleButton = true;
            this.cdvCalendarType.VisibleColumnHeader = false;
            this.cdvCalendarType.VisibleDescription = false;
            this.cdvCalendarType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCalendarType_SelectedItemChanged);
            this.cdvCalendarType.TextBoxTextChanged += new System.EventHandler(this.cdvCalendarType_TextBoxTextChanged);
            // 
            // lblCalendarType
            // 
            this.lblCalendarType.AutoSize = true;
            this.lblCalendarType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalendarType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendarType.Location = new System.Drawing.Point(15, 19);
            this.lblCalendarType.Name = "lblCalendarType";
            this.lblCalendarType.Size = new System.Drawing.Size(76, 13);
            this.lblCalendarType.TabIndex = 0;
            this.lblCalendarType.Text = "Calendar Type";
            // 
            // cdvCalendarID
            // 
            this.cdvCalendarID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCalendarID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCalendarID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCalendarID.BtnToolTipText = "";
            this.cdvCalendarID.DescText = "";
            this.cdvCalendarID.DisplaySubItemIndex = -1;
            this.cdvCalendarID.DisplayText = "";
            this.cdvCalendarID.Focusing = null;
            this.cdvCalendarID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCalendarID.Index = 0;
            this.cdvCalendarID.IsViewBtnImage = false;
            this.cdvCalendarID.Location = new System.Drawing.Point(458, 16);
            this.cdvCalendarID.MaxLength = 20;
            this.cdvCalendarID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCalendarID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCalendarID.Name = "cdvCalendarID";
            this.cdvCalendarID.ReadOnly = false;
            this.cdvCalendarID.SearchSubItemIndex = 0;
            this.cdvCalendarID.SelectedDescIndex = -1;
            this.cdvCalendarID.SelectedSubItemIndex = -1;
            this.cdvCalendarID.SelectionStart = 0;
            this.cdvCalendarID.Size = new System.Drawing.Size(200, 20);
            this.cdvCalendarID.SmallImageList = null;
            this.cdvCalendarID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCalendarID.TabIndex = 3;
            this.cdvCalendarID.TextBoxToolTipText = "";
            this.cdvCalendarID.TextBoxWidth = 200;
            this.cdvCalendarID.VisibleButton = true;
            this.cdvCalendarID.VisibleColumnHeader = false;
            this.cdvCalendarID.VisibleDescription = false;
            this.cdvCalendarID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCalendarID_SelectedItemChanged);
            this.cdvCalendarID.ButtonPress += new System.EventHandler(this.cdvCalendarID_ButtonPress);
            this.cdvCalendarID.TextBoxTextChanged += new System.EventHandler(this.cdvCalendarID_TextBoxTextChanged);
            // 
            // lblCalendar
            // 
            this.lblCalendar.AutoSize = true;
            this.lblCalendar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendar.Location = new System.Drawing.Point(352, 19);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(63, 13);
            this.lblCalendar.TabIndex = 2;
            this.lblCalendar.Text = "Calendar ID";
            // 
            // cboFirstDayofWeek
            // 
            this.cboFirstDayofWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFirstDayofWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFirstDayofWeek.Location = new System.Drawing.Point(458, 40);
            this.cboFirstDayofWeek.MaxLength = 4;
            this.cboFirstDayofWeek.Name = "cboFirstDayofWeek";
            this.cboFirstDayofWeek.Size = new System.Drawing.Size(200, 21);
            this.cboFirstDayofWeek.TabIndex = 7;
            // 
            // lblFirstDayofWeek
            // 
            this.lblFirstDayofWeek.AutoSize = true;
            this.lblFirstDayofWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFirstDayofWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstDayofWeek.Location = new System.Drawing.Point(352, 43);
            this.lblFirstDayofWeek.Name = "lblFirstDayofWeek";
            this.lblFirstDayofWeek.Size = new System.Drawing.Size(92, 13);
            this.lblFirstDayofWeek.TabIndex = 6;
            this.lblFirstDayofWeek.Text = "First Day of Week";
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Controls.Add(this.grpDisplay);
            this.pnlDisplay.Controls.Add(this.grpOptions);
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(0, 73);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlDisplay.Size = new System.Drawing.Size(742, 440);
            this.pnlDisplay.TabIndex = 1;
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.txtDayCount);
            this.grpDisplay.Controls.Add(this.lblDayCount);
            this.grpDisplay.Controls.Add(this.lblStartDay);
            this.grpDisplay.Controls.Add(this.lblEndDay);
            this.grpDisplay.Controls.Add(this.txtStartDay);
            this.grpDisplay.Controls.Add(this.txtEndDay);
            this.grpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDisplay.Location = new System.Drawing.Point(3, 208);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(736, 232);
            this.grpDisplay.TabIndex = 1;
            this.grpDisplay.TabStop = false;
            // 
            // txtDayCount
            // 
            this.txtDayCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDayCount.Location = new System.Drawing.Point(120, 16);
            this.txtDayCount.Name = "txtDayCount";
            this.txtDayCount.ReadOnly = true;
            this.txtDayCount.Size = new System.Drawing.Size(200, 20);
            this.txtDayCount.TabIndex = 1;
            this.txtDayCount.TabStop = false;
            // 
            // lblDayCount
            // 
            this.lblDayCount.AutoSize = true;
            this.lblDayCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDayCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayCount.Location = new System.Drawing.Point(15, 19);
            this.lblDayCount.Name = "lblDayCount";
            this.lblDayCount.Size = new System.Drawing.Size(57, 13);
            this.lblDayCount.TabIndex = 0;
            this.lblDayCount.Text = "Day Count";
            // 
            // lblStartDay
            // 
            this.lblStartDay.AutoSize = true;
            this.lblStartDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDay.Location = new System.Drawing.Point(15, 43);
            this.lblStartDay.Name = "lblStartDay";
            this.lblStartDay.Size = new System.Drawing.Size(51, 13);
            this.lblStartDay.TabIndex = 2;
            this.lblStartDay.Text = "Start Day";
            // 
            // lblEndDay
            // 
            this.lblEndDay.AutoSize = true;
            this.lblEndDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDay.Location = new System.Drawing.Point(15, 67);
            this.lblEndDay.Name = "lblEndDay";
            this.lblEndDay.Size = new System.Drawing.Size(48, 13);
            this.lblEndDay.TabIndex = 4;
            this.lblEndDay.Text = "End Day";
            // 
            // txtStartDay
            // 
            this.txtStartDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDay.Location = new System.Drawing.Point(120, 40);
            this.txtStartDay.Name = "txtStartDay";
            this.txtStartDay.ReadOnly = true;
            this.txtStartDay.Size = new System.Drawing.Size(200, 20);
            this.txtStartDay.TabIndex = 3;
            this.txtStartDay.TabStop = false;
            // 
            // txtEndDay
            // 
            this.txtEndDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDay.Location = new System.Drawing.Point(120, 64);
            this.txtEndDay.Name = "txtEndDay";
            this.txtEndDay.ReadOnly = true;
            this.txtEndDay.Size = new System.Drawing.Size(200, 20);
            this.txtEndDay.TabIndex = 5;
            this.txtEndDay.TabStop = false;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkHolidaySunday);
            this.grpOptions.Controls.Add(this.chkHolidaySaturday);
            this.grpOptions.Controls.Add(this.chkHolidayFriday);
            this.grpOptions.Controls.Add(this.chkHolidayThursday);
            this.grpOptions.Controls.Add(this.chkHolidayWednesday);
            this.grpOptions.Controls.Add(this.chkHolidayTuesday);
            this.grpOptions.Controls.Add(this.chkIsHolidayMonday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofSunday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofSaturday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofFriday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofThursday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofWednesday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofTuesday);
            this.grpOptions.Controls.Add(this.txtWorkHoursofMonday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofSunday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofSaturday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofFriday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofThursday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofWednesday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofTuesday);
            this.grpOptions.Controls.Add(this.lblWorkHoursofMonday);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOptions.Location = new System.Drawing.Point(3, 3);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(736, 205);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Work Hours of Day";
            // 
            // chkHolidaySunday
            // 
            this.chkHolidaySunday.AutoSize = true;
            this.chkHolidaySunday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidaySunday.Location = new System.Drawing.Point(188, 20);
            this.chkHolidaySunday.Name = "chkHolidaySunday";
            this.chkHolidaySunday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidaySunday.TabIndex = 2;
            this.chkHolidaySunday.Text = "Holiday Flag";
            this.chkHolidaySunday.CheckedChanged += new System.EventHandler(this.chkHolidaySunday_CheckedChanged);
            // 
            // chkHolidaySaturday
            // 
            this.chkHolidaySaturday.AutoSize = true;
            this.chkHolidaySaturday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidaySaturday.Location = new System.Drawing.Point(188, 175);
            this.chkHolidaySaturday.Name = "chkHolidaySaturday";
            this.chkHolidaySaturday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidaySaturday.TabIndex = 20;
            this.chkHolidaySaturday.Text = "Holiday Flag";
            this.chkHolidaySaturday.CheckedChanged += new System.EventHandler(this.chkHolidaySaturday_CheckedChanged);
            // 
            // chkHolidayFriday
            // 
            this.chkHolidayFriday.AutoSize = true;
            this.chkHolidayFriday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidayFriday.Location = new System.Drawing.Point(188, 149);
            this.chkHolidayFriday.Name = "chkHolidayFriday";
            this.chkHolidayFriday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidayFriday.TabIndex = 17;
            this.chkHolidayFriday.Text = "Holiday Flag";
            this.chkHolidayFriday.CheckedChanged += new System.EventHandler(this.chkHolidayFriday_CheckedChanged);
            // 
            // chkHolidayThursday
            // 
            this.chkHolidayThursday.AutoSize = true;
            this.chkHolidayThursday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidayThursday.Location = new System.Drawing.Point(188, 123);
            this.chkHolidayThursday.Name = "chkHolidayThursday";
            this.chkHolidayThursday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidayThursday.TabIndex = 14;
            this.chkHolidayThursday.Text = "Holiday Flag";
            this.chkHolidayThursday.CheckedChanged += new System.EventHandler(this.chkHolidayThursday_CheckedChanged);
            // 
            // chkHolidayWednesday
            // 
            this.chkHolidayWednesday.AutoSize = true;
            this.chkHolidayWednesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidayWednesday.Location = new System.Drawing.Point(188, 97);
            this.chkHolidayWednesday.Name = "chkHolidayWednesday";
            this.chkHolidayWednesday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidayWednesday.TabIndex = 11;
            this.chkHolidayWednesday.Text = "Holiday Flag";
            this.chkHolidayWednesday.CheckedChanged += new System.EventHandler(this.chkHolidayWednesday_CheckedChanged);
            // 
            // chkHolidayTuesday
            // 
            this.chkHolidayTuesday.AutoSize = true;
            this.chkHolidayTuesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHolidayTuesday.Location = new System.Drawing.Point(188, 71);
            this.chkHolidayTuesday.Name = "chkHolidayTuesday";
            this.chkHolidayTuesday.Size = new System.Drawing.Size(90, 18);
            this.chkHolidayTuesday.TabIndex = 8;
            this.chkHolidayTuesday.Text = "Holiday Flag";
            this.chkHolidayTuesday.CheckedChanged += new System.EventHandler(this.chkHolidayTuesday_CheckedChanged);
            // 
            // chkIsHolidayMonday
            // 
            this.chkIsHolidayMonday.AutoSize = true;
            this.chkIsHolidayMonday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIsHolidayMonday.Location = new System.Drawing.Point(188, 45);
            this.chkIsHolidayMonday.Name = "chkIsHolidayMonday";
            this.chkIsHolidayMonday.Size = new System.Drawing.Size(90, 18);
            this.chkIsHolidayMonday.TabIndex = 5;
            this.chkIsHolidayMonday.Text = "Holiday Flag";
            this.chkIsHolidayMonday.CheckedChanged += new System.EventHandler(this.chkIsHolidayMonday_CheckedChanged);
            // 
            // txtWorkHoursofSunday
            // 
            this.txtWorkHoursofSunday.Location = new System.Drawing.Point(120, 16);
            this.txtWorkHoursofSunday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofSunday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofSunday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofSunday.MaxValue = 24;
            this.txtWorkHoursofSunday.MinValue = 0;
            this.txtWorkHoursofSunday.Name = "txtWorkHoursofSunday";
            this.txtWorkHoursofSunday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofSunday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofSunday.TabIndex = 1;
            this.txtWorkHoursofSunday.Value = 24D;
            // 
            // txtWorkHoursofSaturday
            // 
            this.txtWorkHoursofSaturday.Location = new System.Drawing.Point(120, 173);
            this.txtWorkHoursofSaturday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofSaturday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofSaturday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofSaturday.MaxValue = 24;
            this.txtWorkHoursofSaturday.MinValue = 0;
            this.txtWorkHoursofSaturday.Name = "txtWorkHoursofSaturday";
            this.txtWorkHoursofSaturday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofSaturday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofSaturday.TabIndex = 19;
            this.txtWorkHoursofSaturday.Value = 24D;
            // 
            // txtWorkHoursofFriday
            // 
            this.txtWorkHoursofFriday.Location = new System.Drawing.Point(120, 147);
            this.txtWorkHoursofFriday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofFriday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofFriday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofFriday.MaxValue = 24;
            this.txtWorkHoursofFriday.MinValue = 0;
            this.txtWorkHoursofFriday.Name = "txtWorkHoursofFriday";
            this.txtWorkHoursofFriday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofFriday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofFriday.TabIndex = 16;
            this.txtWorkHoursofFriday.Value = 24D;
            // 
            // txtWorkHoursofThursday
            // 
            this.txtWorkHoursofThursday.Location = new System.Drawing.Point(120, 121);
            this.txtWorkHoursofThursday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofThursday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofThursday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofThursday.MaxValue = 24;
            this.txtWorkHoursofThursday.MinValue = 0;
            this.txtWorkHoursofThursday.Name = "txtWorkHoursofThursday";
            this.txtWorkHoursofThursday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofThursday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofThursday.TabIndex = 13;
            this.txtWorkHoursofThursday.Value = 24D;
            // 
            // txtWorkHoursofWednesday
            // 
            this.txtWorkHoursofWednesday.Location = new System.Drawing.Point(120, 95);
            this.txtWorkHoursofWednesday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofWednesday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofWednesday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofWednesday.MaxValue = 24;
            this.txtWorkHoursofWednesday.MinValue = 0;
            this.txtWorkHoursofWednesday.Name = "txtWorkHoursofWednesday";
            this.txtWorkHoursofWednesday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofWednesday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofWednesday.TabIndex = 10;
            this.txtWorkHoursofWednesday.Value = 24D;
            // 
            // txtWorkHoursofTuesday
            // 
            this.txtWorkHoursofTuesday.Location = new System.Drawing.Point(120, 69);
            this.txtWorkHoursofTuesday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofTuesday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofTuesday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofTuesday.MaxValue = 24;
            this.txtWorkHoursofTuesday.MinValue = 0;
            this.txtWorkHoursofTuesday.Name = "txtWorkHoursofTuesday";
            this.txtWorkHoursofTuesday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofTuesday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofTuesday.TabIndex = 7;
            this.txtWorkHoursofTuesday.Value = 24D;
            // 
            // txtWorkHoursofMonday
            // 
            this.txtWorkHoursofMonday.Location = new System.Drawing.Point(120, 43);
            this.txtWorkHoursofMonday.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofMonday.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWorkHoursofMonday.MaskInput = "{LOC}nn.nn";
            this.txtWorkHoursofMonday.MaxValue = 24;
            this.txtWorkHoursofMonday.MinValue = 0;
            this.txtWorkHoursofMonday.Name = "txtWorkHoursofMonday";
            this.txtWorkHoursofMonday.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWorkHoursofMonday.Size = new System.Drawing.Size(54, 20);
            this.txtWorkHoursofMonday.TabIndex = 4;
            this.txtWorkHoursofMonday.Value = 24D;
            // 
            // lblWorkHoursofSunday
            // 
            this.lblWorkHoursofSunday.AutoSize = true;
            this.lblWorkHoursofSunday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofSunday.Location = new System.Drawing.Point(16, 20);
            this.lblWorkHoursofSunday.Name = "lblWorkHoursofSunday";
            this.lblWorkHoursofSunday.Size = new System.Drawing.Size(43, 13);
            this.lblWorkHoursofSunday.TabIndex = 0;
            this.lblWorkHoursofSunday.Text = "Sunday";
            // 
            // lblWorkHoursofSaturday
            // 
            this.lblWorkHoursofSaturday.AutoSize = true;
            this.lblWorkHoursofSaturday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofSaturday.Location = new System.Drawing.Point(15, 175);
            this.lblWorkHoursofSaturday.Name = "lblWorkHoursofSaturday";
            this.lblWorkHoursofSaturday.Size = new System.Drawing.Size(49, 13);
            this.lblWorkHoursofSaturday.TabIndex = 18;
            this.lblWorkHoursofSaturday.Text = "Saturday";
            // 
            // lblWorkHoursofFriday
            // 
            this.lblWorkHoursofFriday.AutoSize = true;
            this.lblWorkHoursofFriday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofFriday.Location = new System.Drawing.Point(15, 149);
            this.lblWorkHoursofFriday.Name = "lblWorkHoursofFriday";
            this.lblWorkHoursofFriday.Size = new System.Drawing.Size(35, 13);
            this.lblWorkHoursofFriday.TabIndex = 15;
            this.lblWorkHoursofFriday.Text = "Friday";
            // 
            // lblWorkHoursofThursday
            // 
            this.lblWorkHoursofThursday.AutoSize = true;
            this.lblWorkHoursofThursday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofThursday.Location = new System.Drawing.Point(15, 123);
            this.lblWorkHoursofThursday.Name = "lblWorkHoursofThursday";
            this.lblWorkHoursofThursday.Size = new System.Drawing.Size(51, 13);
            this.lblWorkHoursofThursday.TabIndex = 12;
            this.lblWorkHoursofThursday.Text = "Thursday";
            // 
            // lblWorkHoursofWednesday
            // 
            this.lblWorkHoursofWednesday.AutoSize = true;
            this.lblWorkHoursofWednesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofWednesday.Location = new System.Drawing.Point(15, 97);
            this.lblWorkHoursofWednesday.Name = "lblWorkHoursofWednesday";
            this.lblWorkHoursofWednesday.Size = new System.Drawing.Size(64, 13);
            this.lblWorkHoursofWednesday.TabIndex = 9;
            this.lblWorkHoursofWednesday.Text = "Wednesday";
            // 
            // lblWorkHoursofTuesday
            // 
            this.lblWorkHoursofTuesday.AutoSize = true;
            this.lblWorkHoursofTuesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofTuesday.Location = new System.Drawing.Point(15, 71);
            this.lblWorkHoursofTuesday.Name = "lblWorkHoursofTuesday";
            this.lblWorkHoursofTuesday.Size = new System.Drawing.Size(48, 13);
            this.lblWorkHoursofTuesday.TabIndex = 6;
            this.lblWorkHoursofTuesday.Text = "Tuesday";
            // 
            // lblWorkHoursofMonday
            // 
            this.lblWorkHoursofMonday.AutoSize = true;
            this.lblWorkHoursofMonday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkHoursofMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkHoursofMonday.Location = new System.Drawing.Point(15, 45);
            this.lblWorkHoursofMonday.Name = "lblWorkHoursofMonday";
            this.lblWorkHoursofMonday.Size = new System.Drawing.Size(45, 13);
            this.lblWorkHoursofMonday.TabIndex = 3;
            this.lblWorkHoursofMonday.Text = "Monday";
            // 
            // frmBASSetupCalendar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupCalendar";
            this.Text = "Calendar Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupCalendar_Activated);
            this.Load += new System.EventHandler(this.frmBASSetupCalendar_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlCalendar.ResumeLayout(false);
            this.grpCalendar.ResumeLayout(false);
            this.grpCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCalendarType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCalendarID)).EndInit();
            this.pnlDisplay.ResumeLayout(false);
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofSunday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofSaturday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofFriday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofThursday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofWednesday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofTuesday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkHoursofMonday)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition "
        
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
                case "VIEW":
                    
                    if (cdvCalendarType.Text == "")
                    {
                        cdvCalendarType.Focus();
                        return false;
                    }
                    if (cdvCalendarID.Text == "")
                    {
                        cdvCalendarID.Focus();
                        return false;
                    }
                    break;
                case "UPDATE":
                    
                    if (cdvCalendarType.Text == "")
                    {
                        cdvCalendarType.Focus();
                        return false;
                    }
                    if (cdvCalendarID.Text == "")
                    {
                        cdvCalendarID.Focus();
                        return false;
                    }
                    break;
                default:
                    
                    break;
                    
            }
            
            return true;
        }
        
        // InitYear()
        //       - Initialize Year List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool InitCombo()
        {
            int i;
            int lCurYear;
            
            lCurYear = DateTime.Now.Year;
            
            for (i = lCurYear - 5; i <= lCurYear + 5; i++)
            {
                cboYear.Items.Add(i);
            }
            
            cboYear.SelectedIndex = 5;
            
            return true;
        }
        
        // GetCalendarType()
        //       - Get Calendar Type
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool GetCalendarType()
        {
            
            ListViewItem itmx = null;
            
            cdvCalendarType.Init();
            MPCF.InitListView(cdvCalendarType.GetListView);
            cdvCalendarType.Columns.Add("Calendar Type", 50, HorizontalAlignment.Left);
            cdvCalendarType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCalendarType.SelectedSubItemIndex = 0;
            
            itmx = new ListViewItem("F", (int)SMALLICON_INDEX.IDX_CALENDAR);
            itmx.SubItems.Add("FACTORY");
            cdvCalendarType.Items.Add(itmx);
            
            itmx = new ListViewItem("W", (int)SMALLICON_INDEX.IDX_CALENDAR);
            itmx.SubItems.Add("WORK");
            cdvCalendarType.Items.Add(itmx);
            
            return true;
            
        }
        
        private bool View_Calendar()
        {
            TRSNode in_node = new TRSNode("VIEW_CALENDAR_IN");
            TRSNode out_node = new TRSNode("VIEW_CALENDAR_OUT");

            
            txtDayCount.Text = "";
            txtStartDay.Text = "";
            txtEndDay.Text = "";
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddChar("CALENDAR_TYPE", MPCF.ToChar(MPCF.Trim(cdvCalendarType.Text)));
            in_node.AddString("CALENDAR_ID", MPCF.Trim(cdvCalendarID.Text));
            in_node.AddInt("YEAR", MPCF.ToInt(cboYear.Text));

            if (MPCR.CallService("BAS", "BAS_View_Calendar", in_node, ref out_node) == false)
            {
                return false;
            }


            txtDayCount.Text = out_node.GetInt("DAY_COUNT").ToString();
            txtStartDay.Text = MPCF.MakeDateFormat(out_node.GetString("START_DAY"), DATE_TIME_FORMAT.DATE);
            txtEndDay.Text = MPCF.MakeDateFormat(out_node.GetString("END_DAY"), DATE_TIME_FORMAT.DATE);
            
            return true;
        }
        
        private bool Update_Calendar_List()
        {
            TRSNode in_node = new TRSNode("UPDATE_CALENDAR_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            
            in_node.AddChar("CALENDAR_TYPE", MPCF.ToChar(MPCF.Trim(cdvCalendarType.Text)));
            in_node.AddString("CALENDAR_ID", MPCF.Trim(cdvCalendarID.Text));

            in_node.AddInt("YEAR", MPCF.ToInt(cboYear.Text));

            in_node.AddInt("FIRST_DAY_OF_WEEK", cboFirstDayofWeek.SelectedIndex);
            in_node.AddDouble("WORK_HOURS_MONDAY", (double)this.txtWorkHoursofMonday.Value);
            in_node.AddDouble("WORK_HOURS_TUESDAY", (double)this.txtWorkHoursofTuesday.Value);
            in_node.AddDouble("WORK_HOURS_WEDNESDAY", (double)this.txtWorkHoursofWednesday.Value);
            in_node.AddDouble("WORK_HOURS_THURSDAY", (double)this.txtWorkHoursofThursday.Value);
            in_node.AddDouble("WORK_HOURS_FRIDAY", (double)this.txtWorkHoursofFriday.Value);
            in_node.AddDouble("WORK_HOURS_SATURDAY", (double)this.txtWorkHoursofSaturday.Value);
            in_node.AddDouble("WORK_HOURS_SUNDAY", (double)this.txtWorkHoursofSunday.Value);
            in_node.AddChar("IS_HOLIDAY_MONDAY", (this.chkIsHolidayMonday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_TUESDAY", (this.chkHolidayTuesday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_WEDNESDAY", (this.chkHolidayWednesday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_THURSDAY", (this.chkHolidayThursday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_FRIDAY", (this.chkHolidayFriday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_SATURDAY", (this.chkHolidaySaturday.Checked ? 'Y' : 'N'));
            in_node.AddChar("IS_HOLIDAY_SUNDAY", (this.chkHolidaySunday.Checked ? 'Y' : 'N'));


            if (MPCR.CallService("BAS", "BAS_Update_Calendar_List", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            
            return true;
        }
        
        private bool View_Calendar_List()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CALENDAR_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_CALENDAR_LIST_OUT");
                int i;
                ListViewItem itmx = null;
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';  // 1 : Calendar List,  2 : Work Calendar ID List
                in_node.AddInt("YEAR", MPCF.ToInt(cboYear.Text));
                in_node.AddChar("CALENDAR_TYPE", MPCF.ToChar(cdvCalendarType.Text));


                if (MPCR.CallService("BAS", "BAS_View_Calendar_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                cdvCalendarID.Init();
                MPCF.InitListView(cdvCalendarID.GetListView);
                cdvCalendarID.Columns.Add("Calendar ID", 200, HorizontalAlignment.Left);
                cdvCalendarID.SelectedSubItemIndex = 0;
                cdvCalendarID.DisplaySubItemIndex = 0;
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    //object with_1 = View_Calendar_List_Out.calendar_list[i];
                    itmx = new ListViewItem(out_node.GetList(0)[i].GetString("CALENDAR_ID"), (int)SMALLICON_INDEX.IDX_CALENDAR);
                    cdvCalendarID.Items.Add(itmx);
                    
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // SetDayList()
        //       - Initialize first day of week list
        // Return Value
        //       -
        // Arguments
        //       -
        // History
        //       - 200500811/Laverwon : ì£¼ì˜ ?œìž‘ ?”ì¼???¤ì •?˜ê¸° ?„í•´???ì„±
        //
        private void SetDayList()
        {
            
            try
            {
                cboFirstDayofWeek.Items.Clear();
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Sunday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Monday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Tuesday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Wednesday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Thursday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Friday", 0));
                cboFirstDayofWeek.Items.Add(MPCF.FindLanguage("Saturday", 0));
                cboFirstDayofWeek.SelectedIndex = 0;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        // SetDefaultWorkHours()
        //       - Initialize work hours of day
        // Return Value
        //       -
        // Arguments
        //       -
        // History
        //       - 200500811/Laverwon : ?”ì¼ë³??‘ì—… ?œê°„???¤ì •?˜ê¸° ?„í•´???ì„±
        //
        private void SetDefaultWorkHours()
        {
            
            try
            {
                this.txtWorkHoursofMonday.Value  = 24;
                this.txtWorkHoursofTuesday.Value = 24;
                this.txtWorkHoursofWednesday.Value = 24;
                this.txtWorkHoursofThursday.Value = 24;
                this.txtWorkHoursofFriday.Value = 24;
                this.txtWorkHoursofSaturday.Value = 24;
                this.txtWorkHoursofSunday.Value = 24;

                if (this.chkIsHolidayMonday.Checked == true)
                    this.txtWorkHoursofMonday.Value = 0;
                if (this.chkHolidayTuesday.Checked == true)
                    this.txtWorkHoursofTuesday.Value = 0;
                if (this.chkHolidayWednesday.Checked == true)
                    this.txtWorkHoursofWednesday.Value = 0;
                if (this.chkHolidayThursday.Checked == true)
                    this.txtWorkHoursofThursday.Value = 0;
                if (this.chkHolidayFriday.Checked == true)
                    this.txtWorkHoursofFriday.Value = 0;
                if (this.chkHolidaySaturday.Checked == true)
                    this.txtWorkHoursofSaturday.Value = 0;
                if (this.chkHolidaySunday.Checked == true)
                    this.txtWorkHoursofSunday.Value = 0;                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvCalendarID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmBASSetupCalendar_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmBASSetupCalendar_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    SetDayList();
                    SetDefaultWorkHours();
                    if (GetCalendarType() == false)
                    {
                        return;
                    }
                    if (InitCombo() == false)
                    {
                        return;
                    }

                    cdvCalendarID.Init();
                    MPCF.InitListView(cdvCalendarID.GetListView);
                    cdvCalendarID.Columns.Add("Calendar ID", 200, HorizontalAlignment.Left);
                    cdvCalendarID.SelectedSubItemIndex = 0;
                    cdvCalendarID.DisplaySubItemIndex = 0;

                    cdvCalendarType.Text = "F";
                    cdvCalendarID.Text = MPGV.gsFactory;
                    cdvCalendarID.VisibleButton = false;
                    cdvCalendarID.ReadOnly = true;

                    View_Calendar();
                    
                    LoadFlag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCalendarID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                View_Calendar_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cboYear_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                View_Calendar();
                cboFirstDayofWeek.SelectedIndex = 0;
                SetDefaultWorkHours();
                
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
                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }
                if (Update_Calendar_List() == true)
                {
                    View_Calendar();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCalendarID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                txtDayCount.Text = "";
                txtStartDay.Text = "";
                txtEndDay.Text = "";
                cboFirstDayofWeek.SelectedIndex = 0;
                SetDefaultWorkHours();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCalendarType_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvCalendarID.Text = "";
                txtDayCount.Text = "";
                txtStartDay.Text = "";
                txtEndDay.Text = "";
                cboFirstDayofWeek.SelectedIndex = 0;
                SetDefaultWorkHours();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCalendarID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                View_Calendar();
                cboFirstDayofWeek.SelectedIndex = 0;
                SetDefaultWorkHours();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            
        }
        
        private void cdvCalendarType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvCalendarID.Text = "";
                cdvCalendarID.VisibleButton = true;
                cdvCalendarID.ReadOnly = false;

                if (cdvCalendarType.Text == "F")
                {
                    cdvCalendarID.Text = MPGV.gsFactory;
                    cdvCalendarID.VisibleButton = false;
                    cdvCalendarID.ReadOnly = true;
                }
                
                cboFirstDayofWeek.SelectedIndex = 0;
                SetDefaultWorkHours();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkIsHolidayMonday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkIsHolidayMonday.Checked == true)
                    txtWorkHoursofMonday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidayTuesday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidayTuesday.Checked == true)
                    txtWorkHoursofTuesday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidayWednesday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidayWednesday.Checked == true)
                    txtWorkHoursofWednesday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidayThursday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidayThursday.Checked == true)
                    txtWorkHoursofThursday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidayFriday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidayFriday.Checked == true)
                    txtWorkHoursofFriday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidaySaturday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidaySaturday.Checked == true)
                    txtWorkHoursofSaturday.Value = 0;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkHolidaySunday_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkHolidaySunday.Checked == true)
                    txtWorkHoursofSunday.Value = 0;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
    }
    
}
