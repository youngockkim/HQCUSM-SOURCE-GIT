

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCloseReturnLot.vb
//   Description : Close Return Lot
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-13 : Created by H.K.KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPTranCloseReturnLot : Miracom.MESCore.TranForm08
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranCloseReturnLot()
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
        



        private System.Windows.Forms.Panel pnlTranTop;
        private System.Windows.Forms.GroupBox grpTranTop;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblWorkDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResultCode;
        private System.Windows.Forms.Label lblResultCode;
        private System.Windows.Forms.GroupBox grpLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.GroupBox grpOpen;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreateUser;
        protected System.Windows.Forms.TextBox txtOpenComment;
        private System.Windows.Forms.Label lblOpenComment;
        private System.Windows.Forms.TextBox txtHistExistFlag;
        private System.Windows.Forms.Label lblHistExistFlag;
        private System.Windows.Forms.TextBox txtRMAStatus;
        private System.Windows.Forms.Label lblRMAStatus;
        private System.Windows.Forms.TextBox txtCreateCode;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.TextBox txtQty;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblQty;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlTranTop = new System.Windows.Forms.Panel();
            this.grpTranTop = new System.Windows.Forms.GroupBox();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.cdvResultCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResultCode = new System.Windows.Forms.Label();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.grpOpen = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtOpenComment = new System.Windows.Forms.TextBox();
            this.lblOpenComment = new System.Windows.Forms.Label();
            this.txtHistExistFlag = new System.Windows.Forms.TextBox();
            this.lblHistExistFlag = new System.Windows.Forms.Label();
            this.txtRMAStatus = new System.Windows.Forms.TextBox();
            this.lblRMAStatus = new System.Windows.Forms.Label();
            this.txtCreateCode = new System.Windows.Forms.TextBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).BeginInit();
            this.grpOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 463);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 437);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpOpen);
            this.pnlTranInfo.Controls.Add(this.grpLotID);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 282);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 282);
            this.pnlComment.Size = new System.Drawing.Size(728, 152);
            this.pnlComment.TabIndex = 1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.cdvResultCode);
            this.grpComment.Controls.Add(this.lblResultCode);
            this.grpComment.Size = new System.Drawing.Size(722, 152);
            this.grpComment.Text = "Close Information";
            this.grpComment.Controls.SetChildIndex(this.lblComment, 0);
            this.grpComment.Controls.SetChildIndex(this.txtComment, 0);
            this.grpComment.Controls.SetChildIndex(this.lblResultCode, 0);
            this.grpComment.Controls.SetChildIndex(this.cdvResultCode, 0);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(15, 44);
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 2;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(120, 40);
            this.txtComment.Multiline = true;
            this.txtComment.Size = new System.Drawing.Size(576, 102);
            this.txtComment.TabIndex = 3;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 437);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 431);
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Location = new System.Drawing.Point(0, 47);
            this.pnlCenter.Size = new System.Drawing.Size(742, 466);
            this.pnlCenter.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Close Return Lot";
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Controls.Add(this.grpTranTop);
            this.pnlTranTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTranTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTranTop.Name = "pnlTranTop";
            this.pnlTranTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(742, 47);
            this.pnlTranTop.TabIndex = 0;
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.dtpWorkDate);
            this.grpTranTop.Controls.Add(this.lblWorkDate);
            this.grpTranTop.Controls.Add(this.lblLotID);
            this.grpTranTop.Controls.Add(this.txtLotID);
            this.grpTranTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTranTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranTop.Location = new System.Drawing.Point(3, 0);
            this.grpTranTop.Name = "grpTranTop";
            this.grpTranTop.Size = new System.Drawing.Size(736, 47);
            this.grpTranTop.TabIndex = 0;
            this.grpTranTop.TabStop = false;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(631, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(96, 20);
            this.dtpWorkDate.TabIndex = 3;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.Location = new System.Drawing.Point(526, 19);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(68, 13);
            this.lblWorkDate.TabIndex = 2;
            this.lblWorkDate.Text = "Work Date";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // cdvResultCode
            // 
            this.cdvResultCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResultCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResultCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResultCode.BtnToolTipText = "";
            this.cdvResultCode.DescText = "";
            this.cdvResultCode.DisplaySubItemIndex = -1;
            this.cdvResultCode.DisplayText = "";
            this.cdvResultCode.Focusing = null;
            this.cdvResultCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResultCode.Index = 0;
            this.cdvResultCode.IsViewBtnImage = false;
            this.cdvResultCode.Location = new System.Drawing.Point(120, 16);
            this.cdvResultCode.MaxLength = 10;
            this.cdvResultCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResultCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResultCode.Name = "cdvResultCode";
            this.cdvResultCode.ReadOnly = false;
            this.cdvResultCode.SearchSubItemIndex = 0;
            this.cdvResultCode.SelectedDescIndex = -1;
            this.cdvResultCode.SelectedSubItemIndex = -1;
            this.cdvResultCode.SelectionStart = 0;
            this.cdvResultCode.Size = new System.Drawing.Size(200, 20);
            this.cdvResultCode.SmallImageList = null;
            this.cdvResultCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResultCode.TabIndex = 1;
            this.cdvResultCode.TextBoxToolTipText = "";
            this.cdvResultCode.TextBoxWidth = 200;
            this.cdvResultCode.VisibleButton = true;
            this.cdvResultCode.VisibleColumnHeader = false;
            this.cdvResultCode.VisibleDescription = false;
            this.cdvResultCode.ButtonPress += new System.EventHandler(this.cdvResultCode_ButtonPress);
            // 
            // lblResultCode
            // 
            this.lblResultCode.AutoSize = true;
            this.lblResultCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResultCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultCode.Location = new System.Drawing.Point(15, 19);
            this.lblResultCode.Name = "lblResultCode";
            this.lblResultCode.Size = new System.Drawing.Size(76, 13);
            this.lblResultCode.TabIndex = 0;
            this.lblResultCode.Text = "Result Code";
            this.lblResultCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpLotID
            // 
            this.grpLotID.Location = new System.Drawing.Point(0, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(200, 100);
            this.grpLotID.TabIndex = 2;
            this.grpLotID.TabStop = false;
            // 
            // grpOpen
            // 
            this.grpOpen.Controls.Add(this.cdvMaterial);
            this.grpOpen.Controls.Add(this.txtCreateTime);
            this.grpOpen.Controls.Add(this.lblCreateTime);
            this.grpOpen.Controls.Add(this.txtCreateUser);
            this.grpOpen.Controls.Add(this.lblCreateUser);
            this.grpOpen.Controls.Add(this.txtOpenComment);
            this.grpOpen.Controls.Add(this.lblOpenComment);
            this.grpOpen.Controls.Add(this.txtHistExistFlag);
            this.grpOpen.Controls.Add(this.lblHistExistFlag);
            this.grpOpen.Controls.Add(this.txtRMAStatus);
            this.grpOpen.Controls.Add(this.lblRMAStatus);
            this.grpOpen.Controls.Add(this.txtCreateCode);
            this.grpOpen.Controls.Add(this.lblCreateCode);
            this.grpOpen.Controls.Add(this.txtQty);
            this.grpOpen.Controls.Add(this.lblQty);
            this.grpOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOpen.Location = new System.Drawing.Point(3, 3);
            this.grpOpen.Name = "grpOpen";
            this.grpOpen.Size = new System.Drawing.Size(722, 279);
            this.grpOpen.TabIndex = 1;
            this.grpOpen.TabStop = false;
            this.grpOpen.Text = "Open Information";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(15, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(305, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 105;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(496, 88);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(200, 20);
            this.txtCreateTime.TabIndex = 12;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateTime.Location = new System.Drawing.Point(392, 91);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 11;
            this.lblCreateTime.Text = "Create Time";
            this.lblCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(496, 64);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(200, 20);
            this.txtCreateUser.TabIndex = 10;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateUser.Location = new System.Drawing.Point(392, 67);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(77, 13);
            this.lblCreateUser.TabIndex = 9;
            this.lblCreateUser.Text = "Create User ID";
            this.lblCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOpenComment
            // 
            this.txtOpenComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpenComment.Location = new System.Drawing.Point(120, 111);
            this.txtOpenComment.MaxLength = 400;
            this.txtOpenComment.Multiline = true;
            this.txtOpenComment.Name = "txtOpenComment";
            this.txtOpenComment.ReadOnly = true;
            this.txtOpenComment.Size = new System.Drawing.Size(576, 80);
            this.txtOpenComment.TabIndex = 14;
            this.txtOpenComment.TabStop = false;
            // 
            // lblOpenComment
            // 
            this.lblOpenComment.AutoSize = true;
            this.lblOpenComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOpenComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenComment.Location = new System.Drawing.Point(15, 115);
            this.lblOpenComment.Name = "lblOpenComment";
            this.lblOpenComment.Size = new System.Drawing.Size(80, 13);
            this.lblOpenComment.TabIndex = 13;
            this.lblOpenComment.Text = "Open Comment";
            this.lblOpenComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHistExistFlag
            // 
            this.txtHistExistFlag.Location = new System.Drawing.Point(496, 40);
            this.txtHistExistFlag.MaxLength = 10;
            this.txtHistExistFlag.Name = "txtHistExistFlag";
            this.txtHistExistFlag.ReadOnly = true;
            this.txtHistExistFlag.Size = new System.Drawing.Size(200, 20);
            this.txtHistExistFlag.TabIndex = 8;
            this.txtHistExistFlag.TabStop = false;
            // 
            // lblHistExistFlag
            // 
            this.lblHistExistFlag.AutoSize = true;
            this.lblHistExistFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHistExistFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistExistFlag.Location = new System.Drawing.Point(392, 43);
            this.lblHistExistFlag.Name = "lblHistExistFlag";
            this.lblHistExistFlag.Size = new System.Drawing.Size(73, 13);
            this.lblHistExistFlag.TabIndex = 7;
            this.lblHistExistFlag.Text = "Hist Exist Flag";
            this.lblHistExistFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRMAStatus
            // 
            this.txtRMAStatus.Location = new System.Drawing.Point(496, 16);
            this.txtRMAStatus.MaxLength = 10;
            this.txtRMAStatus.Name = "txtRMAStatus";
            this.txtRMAStatus.ReadOnly = true;
            this.txtRMAStatus.Size = new System.Drawing.Size(200, 20);
            this.txtRMAStatus.TabIndex = 6;
            this.txtRMAStatus.TabStop = false;
            // 
            // lblRMAStatus
            // 
            this.lblRMAStatus.AutoSize = true;
            this.lblRMAStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRMAStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMAStatus.Location = new System.Drawing.Point(392, 19);
            this.lblRMAStatus.Name = "lblRMAStatus";
            this.lblRMAStatus.Size = new System.Drawing.Size(37, 13);
            this.lblRMAStatus.TabIndex = 5;
            this.lblRMAStatus.Text = "Status";
            this.lblRMAStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateCode
            // 
            this.txtCreateCode.Location = new System.Drawing.Point(120, 64);
            this.txtCreateCode.MaxLength = 10;
            this.txtCreateCode.Name = "txtCreateCode";
            this.txtCreateCode.ReadOnly = true;
            this.txtCreateCode.Size = new System.Drawing.Size(200, 20);
            this.txtCreateCode.TabIndex = 4;
            this.txtCreateCode.TabStop = false;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(15, 67);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(66, 13);
            this.lblCreateCode.TabIndex = 3;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(120, 40);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(200, 20);
            this.txtQty.TabIndex = 2;
            this.txtQty.TabStop = false;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(15, 43);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(26, 13);
            this.lblQty.TabIndex = 1;
            this.lblQty.Text = "Qty ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranCloseReturnLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlTranTop);
            this.Name = "frmWIPTranCloseReturnLot";
            this.Text = "Close Return Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranCloseReturnLot_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranCloseReturnLot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmWIPTranCloseReturnLot_KeyPress);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlTranTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).EndInit();
            this.grpOpen.ResumeLayout(false);
            this.grpOpen.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constrant Definition"
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        
        #endregion
        
        #region " Function Definition "

        private bool View_Return_Lot()
        {
            TRSNode in_node = new TRSNode("View_ReturnLot_In");
            TRSNode out_node = new TRSNode("View_ReturnLot_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
            
            if (MPCR.CallService("WIP", "WIP_View_ReturnLot", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            txtQty.Text = out_node.GetDouble("QTY").ToString();
            txtCreateCode.Text = out_node.GetString("CREATE_CODE");
            if (out_node.GetString("RMA_STATUS") == "O")
            {
                txtRMAStatus.Text = "OPEN";
            }
            else if (out_node.GetString("RMA_STATUS") == "C")
            {
                txtRMAStatus.Text = "CLOSE";
            }
            txtHistExistFlag.Text = out_node.GetChar("HIST_EXIST_FLAG").ToString();
            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtOpenComment.Text = out_node.GetString("CREATE_COMMENT");
            cdvResultCode.Text = out_node.GetString("RESULT_CODE");
            txtComment.Text = out_node.GetString("RESULT_COMMENT");
            cdvCMF1.Text = out_node.GetString("RESULT_CMF_1");
            cdvCMF2.Text = out_node.GetString("RESULT_CMF_2");
            cdvCMF3.Text = out_node.GetString("RESULT_CMF_3");
            cdvCMF4.Text = out_node.GetString("RESULT_CMF_4");
            cdvCMF5.Text = out_node.GetString("RESULT_CMF_5");
            cdvCMF6.Text = out_node.GetString("RESULT_CMF_6");
            cdvCMF7.Text = out_node.GetString("RESULT_CMF_7");
            cdvCMF8.Text = out_node.GetString("RESULT_CMF_8");
            cdvCMF9.Text = out_node.GetString("RESULT_CMF_9");
            cdvCMF10.Text = out_node.GetString("RESULT_CMF_10");

            return true;
        }
        private bool Close_Return_Lot()
        {
            TRSNode in_node = new TRSNode("Close_ReturnLot_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));

                in_node.AddString("RESULT_CODE", cdvResultCode.Text);
                in_node.AddString("RESULT_COMMENT", txtComment.Text);

                in_node.AddString("RESULT_CMF_1", cdvCMF1.Text);
                in_node.AddString("RESULT_CMF_2", cdvCMF2.Text);
                in_node.AddString("RESULT_CMF_3", cdvCMF3.Text);
                in_node.AddString("RESULT_CMF_4", cdvCMF4.Text);
                in_node.AddString("RESULT_CMF_5", cdvCMF5.Text);
                in_node.AddString("RESULT_CMF_6", cdvCMF6.Text);
                in_node.AddString("RESULT_CMF_7", cdvCMF7.Text);
                in_node.AddString("RESULT_CMF_8", cdvCMF8.Text);
                in_node.AddString("RESULT_CMF_9", cdvCMF9.Text);
                in_node.AddString("RESULT_CMF_10", cdvCMF10.Text);
                in_node.AddString("RESULT_CMF_11", cdvCMF11.Text);
                in_node.AddString("RESULT_CMF_12", cdvCMF12.Text);
                in_node.AddString("RESULT_CMF_13", cdvCMF13.Text);
                in_node.AddString("RESULT_CMF_14", cdvCMF14.Text);
                in_node.AddString("RESULT_CMF_15", cdvCMF15.Text);
                in_node.AddString("RESULT_CMF_16", cdvCMF16.Text);
                in_node.AddString("RESULT_CMF_17", cdvCMF17.Text);
                in_node.AddString("RESULT_CMF_18", cdvCMF18.Text);
                in_node.AddString("RESULT_CMF_19", cdvCMF19.Text);
                in_node.AddString("RESULT_CMF_20", cdvCMF20.Text);

                if (MPCR.CallService("WIP", "WIP_Close_ReturnLot", in_node, ref out_node) == false)
                {
                    return false;
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

        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CLOSE":
                    
                    if (CheckCMFItemValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvResultCode, 1) == false)
                    {
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsReturnLotID) != "")
            {
                txtLotID.Text = MPGV.gsReturnLotID;
                dtpWorkDate.Value = MPCF.ToDate(MPGV.gsWorkDate);
                View_Return_Lot();
            }
        }
        private string MakeString(string sWorkDate)
        {
            
            return sWorkDate.Substring(0, 4) + sWorkDate.Substring(5, 2) + sWorkDate.Substring(8, 2) + "000000";
            
        }
        
        public override Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.dtpWorkDate;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPTranCloseReturnLot_Load(object sender, System.EventArgs e)
        {
            cdvMaterial.BackColor = SystemColors.Control;
        }
        
        private void frmWIPTranCloseReturnLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                dtpWorkDate.Value = DateTime.Today;
                SetCMFItem(MPGC.MP_CMF_TRN_RMA_CLOSE);

                ActiveFormNow();

                b_load_flag = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CLOSE") == false) return;
            if (Close_Return_Lot() == false) return;
        
            View_Return_Lot();
        }
        
        private void frmWIPTranCloseReturnLot_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtLotID.Text == "")
                {
                    return;
                }
                View_Return_Lot();
            }
        }
        
        private void cdvResultCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResultCode.Init();
            MPCF.InitListView(cdvResultCode.GetListView);
            cdvResultCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvResultCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResultCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvResultCode.GetListView, '1', MPGC.MP_RMA_RESULT_CODE);
            
        }
    }
    
}
