
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranOpenReturnLot.vb
//   Description : Open Return Lot
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
    public class frmWIPTranOpenReturnLot : Miracom.MESCore.TranForm08
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranOpenReturnLot()
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
        



        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Panel pnlMidTop;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.TextBox txtQty;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblQty;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
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
            this.grpGeneral.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
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
            this.pnlTranInfo.Controls.Add(this.grpGeneral);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 54);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 54);
            this.pnlComment.Size = new System.Drawing.Size(728, 380);
            this.pnlComment.TabIndex = 1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.cdvMaterial);
            this.grpComment.Controls.Add(this.cdvCreateCode);
            this.grpComment.Controls.Add(this.lblCreateCode);
            this.grpComment.Controls.Add(this.txtQty);
            this.grpComment.Controls.Add(this.lblQty);
            this.grpComment.Size = new System.Drawing.Size(722, 380);
            this.grpComment.Controls.SetChildIndex(this.lblComment, 0);
            this.grpComment.Controls.SetChildIndex(this.txtComment, 0);
            this.grpComment.Controls.SetChildIndex(this.lblQty, 0);
            this.grpComment.Controls.SetChildIndex(this.txtQty, 0);
            this.grpComment.Controls.SetChildIndex(this.lblCreateCode, 0);
            this.grpComment.Controls.SetChildIndex(this.cdvCreateCode, 0);
            this.grpComment.Controls.SetChildIndex(this.cdvMaterial, 0);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(15, 92);
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 5;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(120, 88);
            this.txtComment.Multiline = true;
            this.txtComment.Size = new System.Drawing.Size(596, 77);
            this.txtComment.TabIndex = 6;
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
            this.btnProcess.Location = new System.Drawing.Point(559, 8);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(650, 8);
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
            this.lblFormTitle.Text = "Open Return Lot";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblLotID);
            this.grpGeneral.Controls.Add(this.txtLotID);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 51);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
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
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpTop);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMidTop.Size = new System.Drawing.Size(742, 47);
            this.pnlMidTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.dtpWorkDate);
            this.grpTop.Controls.Add(this.lblWorkDate);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 47);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(120, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(96, 20);
            this.dtpWorkDate.TabIndex = 1;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.Location = new System.Drawing.Point(15, 19);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(68, 13);
            this.lblWorkDate.TabIndex = 0;
            this.lblWorkDate.Text = "Work Date";
            // 
            // cdvCreateCode
            // 
            this.cdvCreateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCode.BtnToolTipText = "";
            this.cdvCreateCode.DescText = "";
            this.cdvCreateCode.DisplaySubItemIndex = -1;
            this.cdvCreateCode.DisplayText = "";
            this.cdvCreateCode.Focusing = null;
            this.cdvCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCode.Index = 0;
            this.cdvCreateCode.IsViewBtnImage = false;
            this.cdvCreateCode.Location = new System.Drawing.Point(120, 64);
            this.cdvCreateCode.MaxLength = 10;
            this.cdvCreateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.Name = "cdvCreateCode";
            this.cdvCreateCode.ReadOnly = false;
            this.cdvCreateCode.SearchSubItemIndex = 0;
            this.cdvCreateCode.SelectedDescIndex = -1;
            this.cdvCreateCode.SelectedSubItemIndex = -1;
            this.cdvCreateCode.SelectionStart = 0;
            this.cdvCreateCode.Size = new System.Drawing.Size(200, 20);
            this.cdvCreateCode.SmallImageList = null;
            this.cdvCreateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCode.TabIndex = 4;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 200;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(15, 67);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 3;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(120, 40);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(200, 20);
            this.txtQty.TabIndex = 2;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(15, 43);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(30, 13);
            this.lblQty.TabIndex = 1;
            this.lblQty.Text = "Qty ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvMaterial.Location = new System.Drawing.Point(15, 14);
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
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 105;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmWIPTranOpenReturnLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlMidTop);
            this.Name = "frmWIPTranOpenReturnLot";
            this.Text = "Open Return Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranOpenReturnLot_Activated);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlMidTop, 0);
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
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlMidTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        
        #endregion
        
        #region " Function Definition "
        // View_Lot()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Lot_Info(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }
            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");

            return true;
        }
        // Open_Return_Lot()
        //       -  Open Return Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool Open_Return_Lot()
        {

            TRSNode in_node = new TRSNode("OPEN_RETURNLOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("MAT_ID", cdvMaterial.Text);
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddDouble("QTY", MPCF.ToDbl(txtQty.Text));
                in_node.AddString("CREATE_CODE", cdvCreateCode.Text);
                in_node.AddString("CREATE_COMMENT", txtComment.Text);

                in_node.AddString("RMA_CMF_1", cdvCMF1.Text);
                in_node.AddString("RMA_CMF_2", cdvCMF2.Text);
                in_node.AddString("RMA_CMF_3", cdvCMF3.Text);
                in_node.AddString("RMA_CMF_4", cdvCMF4.Text);
                in_node.AddString("RMA_CMF_5", cdvCMF5.Text);
                in_node.AddString("RMA_CMF_6", cdvCMF6.Text);
                in_node.AddString("RMA_CMF_7", cdvCMF7.Text);
                in_node.AddString("RMA_CMF_8", cdvCMF8.Text);
                in_node.AddString("RMA_CMF_9", cdvCMF9.Text);
                in_node.AddString("RMA_CMF_10", cdvCMF10.Text);
                in_node.AddString("RMA_CMF_11", cdvCMF11.Text);
                in_node.AddString("RMA_CMF_12", cdvCMF12.Text);
                in_node.AddString("RMA_CMF_13", cdvCMF13.Text);
                in_node.AddString("RMA_CMF_14", cdvCMF14.Text);
                in_node.AddString("RMA_CMF_15", cdvCMF15.Text);
                in_node.AddString("RMA_CMF_16", cdvCMF16.Text);
                in_node.AddString("RMA_CMF_17", cdvCMF17.Text);
                in_node.AddString("RMA_CMF_18", cdvCMF18.Text);
                in_node.AddString("RMA_CMF_19", cdvCMF19.Text);
                in_node.AddString("RMA_CMF_20", cdvCMF20.Text);

                if (MPCR.CallService("WIP", "WIP_Open_ReturnLot", in_node, ref out_node) == false)
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
                case "OPEN":
                    
                    if (CheckCMFItemValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckNumeric(txtQty.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        txtQty.Focus();
                        return false;
                    }
                    break;
            }
            
            return true;
            
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
        
        private void frmWIPTranOpenReturnLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                dtpWorkDate.Value = DateTime.Now;
                SetCMFItem(MPGC.MP_CMF_TRN_RMA_OPEN);
                b_load_flag = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("OPEN") == false) return;

            Open_Return_Lot();
        }
            
        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_RMA_CREATE_CODE);
        }
    }
    
}
