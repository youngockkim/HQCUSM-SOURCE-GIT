
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupQuery.cs
//   Description : Security Function Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Query() : View Security Function definition
//       - View_Query_List() : View all table list which is included in one factory
//       - Update_Function() : Create/Update/Delete Security Function definition
//       - View_User_Group_List() : View all user group list
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-02-26 : Created by James Kwon
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.RASCore
{
    public class frmRASSetupCheckQuery : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "

        public frmRASSetupCheckQuery()
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

        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.TextBox txtDataCode;
        private System.Windows.Forms.Label lblDataCode;
        private System.Windows.Forms.GroupBox grpQuery;
        private Miracom.UI.Controls.MCListView.MCListView lisDataCode;
        private GroupBox grpFuncGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Label lblGroup;
        private Label lblQuery;
        private GroupBox grpType;
        private TextBox txtMsg;
        private GroupBox grpCheckValue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTableName;
        private Label label1;
        private RadioButton rbnAscii;
        private RadioButton rbnNumeric;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDataType;
        private Label lblDataType;
        private System.Windows.Forms.Panel pnlFuncName;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisDataCode = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.cdvDataType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDataType = new System.Windows.Forms.Label();
            this.txtDataCode = new System.Windows.Forms.TextBox();
            this.lblDataCode = new System.Windows.Forms.Label();
            this.pnlFuncName = new System.Windows.Forms.Panel();
            this.grpCheckValue = new System.Windows.Forms.GroupBox();
            this.cdvTableName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rbnAscii = new System.Windows.Forms.RadioButton();
            this.rbnNumeric = new System.Windows.Forms.RadioButton();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.grpFuncGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataType)).BeginInit();
            this.pnlFuncName.SuspendLayout();
            this.grpCheckValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).BeginInit();
            this.grpType.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.grpFuncGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlFuncName);
            this.pnlRight.Controls.Add(this.grbTable);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisDataCode);
            this.pnlLeft.Controls.Add(this.grpFuncGroup);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Function Setup";
            // 
            // lisDataCode
            // 
            this.lisDataCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisDataCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisDataCode.EnableSort = true;
            this.lisDataCode.EnableSortIcon = true;
            this.lisDataCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDataCode.FullRowSelect = true;
            this.lisDataCode.HideSelection = false;
            this.lisDataCode.Location = new System.Drawing.Point(3, 39);
            this.lisDataCode.MultiSelect = false;
            this.lisDataCode.Name = "lisDataCode";
            this.lisDataCode.Size = new System.Drawing.Size(229, 471);
            this.lisDataCode.TabIndex = 1;
            this.lisDataCode.UseCompatibleStateImageBehavior = false;
            this.lisDataCode.View = System.Windows.Forms.View.Details;
            this.lisDataCode.SelectedIndexChanged += new System.EventHandler(this.lisFunc_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Query";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.cdvDataType);
            this.grbTable.Controls.Add(this.lblDataType);
            this.grbTable.Controls.Add(this.txtDataCode);
            this.grbTable.Controls.Add(this.lblDataCode);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(3, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(500, 67);
            this.grbTable.TabIndex = 0;
            this.grbTable.TabStop = false;
            // 
            // cdvDataType
            // 
            this.cdvDataType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDataType.BtnToolTipText = "";
            this.cdvDataType.DescText = "";
            this.cdvDataType.DisplaySubItemIndex = -1;
            this.cdvDataType.DisplayText = "";
            this.cdvDataType.Focusing = null;
            this.cdvDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataType.Index = 0;
            this.cdvDataType.IsViewBtnImage = false;
            this.cdvDataType.Location = new System.Drawing.Point(97, 16);
            this.cdvDataType.MaxLength = 20;
            this.cdvDataType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDataType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDataType.Name = "cdvDataType";
            this.cdvDataType.ReadOnly = false;
            this.cdvDataType.SearchSubItemIndex = 0;
            this.cdvDataType.SelectedDescIndex = -1;
            this.cdvDataType.SelectedSubItemIndex = -1;
            this.cdvDataType.SelectionStart = 0;
            this.cdvDataType.Size = new System.Drawing.Size(177, 20);
            this.cdvDataType.SmallImageList = null;
            this.cdvDataType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDataType.TabIndex = 1;
            this.cdvDataType.TextBoxToolTipText = "";
            this.cdvDataType.TextBoxWidth = 177;
            this.cdvDataType.VisibleButton = true;
            this.cdvDataType.VisibleColumnHeader = false;
            this.cdvDataType.VisibleDescription = false;
            this.cdvDataType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDataType_SelectedItemChanged);
            this.cdvDataType.ButtonPress += new System.EventHandler(this.cdvDataType_ButtonPress);
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataType.Location = new System.Drawing.Point(13, 17);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(72, 13);
            this.lblDataType.TabIndex = 0;
            this.lblDataType.Text = "Query Type";
            this.lblDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataCode
            // 
            this.txtDataCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataCode.Location = new System.Drawing.Point(97, 40);
            this.txtDataCode.MaxLength = 30;
            this.txtDataCode.Name = "txtDataCode";
            this.txtDataCode.Size = new System.Drawing.Size(177, 20);
            this.txtDataCode.TabIndex = 3;
            // 
            // lblDataCode
            // 
            this.lblDataCode.AutoSize = true;
            this.lblDataCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCode.Location = new System.Drawing.Point(13, 43);
            this.lblDataCode.Name = "lblDataCode";
            this.lblDataCode.Size = new System.Drawing.Size(73, 13);
            this.lblDataCode.TabIndex = 2;
            this.lblDataCode.Text = "Query Code";
            this.lblDataCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFuncName
            // 
            this.pnlFuncName.Controls.Add(this.grpCheckValue);
            this.pnlFuncName.Controls.Add(this.grpType);
            this.pnlFuncName.Controls.Add(this.grpQuery);
            this.pnlFuncName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncName.Location = new System.Drawing.Point(3, 67);
            this.pnlFuncName.Name = "pnlFuncName";
            this.pnlFuncName.Size = new System.Drawing.Size(500, 443);
            this.pnlFuncName.TabIndex = 1;
            // 
            // grpCheckValue
            // 
            this.grpCheckValue.Controls.Add(this.cdvTableName);
            this.grpCheckValue.Controls.Add(this.label1);
            this.grpCheckValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheckValue.Location = new System.Drawing.Point(0, 370);
            this.grpCheckValue.Name = "grpCheckValue";
            this.grpCheckValue.Size = new System.Drawing.Size(500, 73);
            this.grpCheckValue.TabIndex = 3;
            this.grpCheckValue.TabStop = false;
            // 
            // cdvTableName
            // 
            this.cdvTableName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTableName.BtnToolTipText = "";
            this.cdvTableName.DescText = "";
            this.cdvTableName.DisplaySubItemIndex = -1;
            this.cdvTableName.DisplayText = "";
            this.cdvTableName.Focusing = null;
            this.cdvTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableName.Index = 0;
            this.cdvTableName.IsViewBtnImage = false;
            this.cdvTableName.Location = new System.Drawing.Point(120, 21);
            this.cdvTableName.MaxLength = 20;
            this.cdvTableName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.Name = "cdvTableName";
            this.cdvTableName.ReadOnly = false;
            this.cdvTableName.SearchSubItemIndex = 0;
            this.cdvTableName.SelectedDescIndex = -1;
            this.cdvTableName.SelectedSubItemIndex = -1;
            this.cdvTableName.SelectionStart = 0;
            this.cdvTableName.Size = new System.Drawing.Size(177, 20);
            this.cdvTableName.SmallImageList = null;
            this.cdvTableName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTableName.TabIndex = 1;
            this.cdvTableName.TextBoxToolTipText = "";
            this.cdvTableName.TextBoxWidth = 177;
            this.cdvTableName.VisibleButton = true;
            this.cdvTableName.VisibleColumnHeader = false;
            this.cdvTableName.VisibleDescription = false;
            this.cdvTableName.ButtonPress += new System.EventHandler(this.cdvTableName_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Validate Table";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rbnAscii);
            this.grpType.Controls.Add(this.rbnNumeric);
            this.grpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpType.Location = new System.Drawing.Point(0, 322);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(500, 48);
            this.grpType.TabIndex = 2;
            this.grpType.TabStop = false;
            this.grpType.Text = "Input Data Type";
            // 
            // rbnAscii
            // 
            this.rbnAscii.AutoSize = true;
            this.rbnAscii.Checked = true;
            this.rbnAscii.Location = new System.Drawing.Point(62, 19);
            this.rbnAscii.Name = "rbnAscii";
            this.rbnAscii.Size = new System.Drawing.Size(52, 17);
            this.rbnAscii.TabIndex = 0;
            this.rbnAscii.TabStop = true;
            this.rbnAscii.Text = "ASCII";
            // 
            // rbnNumeric
            // 
            this.rbnNumeric.AutoSize = true;
            this.rbnNumeric.Location = new System.Drawing.Point(233, 19);
            this.rbnNumeric.Name = "rbnNumeric";
            this.rbnNumeric.Size = new System.Drawing.Size(64, 17);
            this.rbnNumeric.TabIndex = 1;
            this.rbnNumeric.Text = "Numeric";
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.txtMsg);
            this.grpQuery.Controls.Add(this.lblQuery);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQuery.Location = new System.Drawing.Point(0, 0);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(500, 322);
            this.grpQuery.TabIndex = 1;
            this.grpQuery.TabStop = false;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(62, 19);
            this.txtMsg.MaxLength = 1000;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(429, 297);
            this.txtMsg.TabIndex = 1;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.Location = new System.Drawing.Point(13, 16);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(40, 13);
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "Query";
            this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpFuncGroup
            // 
            this.grpFuncGroup.Controls.Add(this.cdvGroup);
            this.grpFuncGroup.Controls.Add(this.lblGroup);
            this.grpFuncGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFuncGroup.Location = new System.Drawing.Point(3, 3);
            this.grpFuncGroup.Name = "grpFuncGroup";
            this.grpFuncGroup.Size = new System.Drawing.Size(229, 36);
            this.grpFuncGroup.TabIndex = 0;
            this.grpFuncGroup.TabStop = false;
            // 
            // cdvGroup
            // 
            this.cdvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(89, 11);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(136, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 1;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 136;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(6, 13);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(62, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Query Type";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRASSetupCheckQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupCheckQuery";
            this.Text = "Check Query Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupQuery_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupQuery_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataType)).EndInit();
            this.pnlFuncName.ResumeLayout(false);
            this.grpCheckValue.ResumeLayout(false);
            this.grpCheckValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).EndInit();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.grpFuncGroup.ResumeLayout(false);
            this.grpFuncGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                }
                else if (ProcStep == "2")
                {
                    txtMsg.Text = "";
                    cdvTableName.Text = "";
                }
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
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Function":

                    if (MPCF.CheckValue(cdvDataType, 1) == false) return false;
                    if (MPCF.CheckValue(txtDataCode, 1) == false) return false;

                    switch (ProcStep)
                    {
                        case MPGC.MP_STEP_CREATE:

                            if (MPCF.CheckValue(txtMsg, 1) == false) return false;

                            break;
                            
                            
                        case MPGC.MP_STEP_UPDATE:

                            if (MPCF.CheckValue(txtMsg, 1) == false) return false;

                            break;
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // View_Query()
        //       - View Sheet Query Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Query()
        {
            TRSNode in_node = new TRSNode("View_Query_In");
            TRSNode out_node = new TRSNode("View_Query_Out");
    
            try
            {
                MPCF.FieldClear(pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DATA_TYPE", cdvGroup.Text);
                in_node.AddString("DATA_CODE", lisDataCode.SelectedItems[0].Text);

                if (MPCR.CallService("RAS", "RAS_View_Sheet_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvDataType.Text = out_node.GetString("DATA_TYPE");
                txtDataCode.Text = out_node.GetString("DATA_CODE");
                txtMsg.Text = out_node.GetString("SHEET_DATA");

                if (out_node.GetChar("RESULT_TYPE") == 'A')
                    rbnAscii.Checked = true;
                else
                    rbnNumeric.Checked = true;

                cdvTableName.Text = out_node.GetString("CHECK_VALUE");

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // Update_Function()
        //       - Create/Update/Delete Sheet Query Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Function(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("Update_Sheet_Query_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode list;
    
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("DATA_TYPE", cdvDataType.Text);

                list = in_node.AddNode("DATA_LIST");
                
                list.AddString("DATA_CODE", MPCF.Trim(txtDataCode.Text));
                list.AddString("SHEET_DATA", MPCF.Trim(txtMsg.Text));
                
                if(rbnAscii.Checked == true)
                    list.AddChar("RESULT_TYPE" , 'A');
                else
                    list.AddChar("RESULT_TYPE" ,'N');

                list.AddString("CHECK_VALUE" ,MPCF.Trim(cdvTableName.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Sheet_Query", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisDataCode.Items.Add(txtDataCode.Text, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itm.SubItems.Add(cdvDataType.Text);
                        itm.Selected = true;
                        lisDataCode.Sorting = SortOrder.Ascending;
                        lisDataCode.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisDataCode, MPCF.Trim(txtDataCode.Text), false) == true)
                        {
                            lisDataCode.SelectedItems[0].SubItems[1].Text = MPCF.Trim(cdvDataType.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisDataCode, MPCF.Trim(txtDataCode.Text), false);
                        if (idx != - 1)
                        {
                            lisDataCode.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisDataCode.Items.Count.ToString();
                }
                MPCR.ShowSuccessMsg(out_node);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvDataType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupQuery_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    btnRefresh.PerformClick();

                    ((Control)GetFisrtFocusItem()).Focus();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRASSetupQuery_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisDataCode);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Function", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Function", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Function", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    
                    ClearData("1");
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisFunc_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisDataCode.SelectedItems.Count > 0)
                {
                    View_Query();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            char cStep;

            try
            {
                lblDataCount.Text = "";
                if (MPCF.Trim(cdvGroup.Text) == "")
                    cStep = '1';
                else
                    cStep = '2';
                if (RASLIST.ViewSheetQueryList(lisDataCode, cStep, cdvGroup.Text) == false)
                {
                    return;
                }

                lblDataCount.Text = lisDataCode.Items.Count.ToString();
                if (lisDataCode.Items.Count > 0)
                {
                    if (MPCF.Trim(txtDataCode.Text) == "")
                    {
                        lisDataCode.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisDataCode, txtDataCode.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisDataCode, this.Text, "");
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisDataCode, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisDataCode, txtFind.Text, 0, true, false);
            
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            btnRefresh.PerformClick();
        }

        private void cdvGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvGroup.Init();
            MPCF.InitListView(cdvGroup.GetListView);
            cdvGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGroup.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvGroup.GetListView, '1', MPGC.MP_SHEET_QUERY_TYPE);
        }

        private void cdvDataType_ButtonPress(object sender, EventArgs e)
        {
            cdvDataType.Init();
            MPCF.InitListView(cdvDataType.GetListView);
            cdvDataType.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvDataType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvDataType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDataType.GetListView, '1', MPGC.MP_SHEET_QUERY_TYPE);

            cdvDataType.InsertEmptyRow(0, 1);
        }

        private void cdvDataType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtDataCode.Text = "";

            txtDataCode.Text = "";
            cdvTableName.Text = "";
        }

        private void cdvTableName_ButtonPress(object sender, EventArgs e)
        {
            cdvTableName.Init();
            MPCF.InitListView(cdvTableName.GetListView);
            cdvTableName.Columns.Add("Table Name", 150, HorizontalAlignment.Left);
            cdvTableName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTableName.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTableName.GetListView, '1');
        }
        
    }
    
}
