
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranReceiveLot.vb
//   Description : Receive Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Material() : View Material Information
//       - View_Operation() : View Operation Information
//       - View_Lot_Info() : View Lot Information
//       - Receive_Lot() : Receive Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by CM Koo
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
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPTranReceiveLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranReceiveLot()
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
        



        private System.Windows.Forms.GroupBox grpReceive;
        private System.Windows.Forms.Label lblCreateCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOper;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.ComboBox cboPriority;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCarrier;
        private System.Windows.Forms.Label lblCarrier;
        private Miracom.MESCore.Controls.udcMaterial cdvToMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        protected System.Windows.Forms.Button btnCalculation;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpReceive = new System.Windows.Forms.GroupBox();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvToMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.cdvCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.cdvToOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblToOper = new System.Windows.Forms.Label();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpReceive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOper)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpReceive);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            this.pnlTranInfo.TabIndex = 1;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 415);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 376);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 379);
            this.pnlComment.TabIndex = 2;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
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
            // txtTranDateTime
            // 
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Receive Lot";
            // 
            // grpReceive
            // 
            this.grpReceive.Controls.Add(this.cdvToFlow);
            this.grpReceive.Controls.Add(this.cdvToMaterial);
            this.grpReceive.Controls.Add(this.btnCalculation);
            this.grpReceive.Controls.Add(this.cdvCarrier);
            this.grpReceive.Controls.Add(this.lblCarrier);
            this.grpReceive.Controls.Add(this.cboPriority);
            this.grpReceive.Controls.Add(this.txtDueDate);
            this.grpReceive.Controls.Add(this.chkDueDate);
            this.grpReceive.Controls.Add(this.dtpDueDate);
            this.grpReceive.Controls.Add(this.lblQty23);
            this.grpReceive.Controls.Add(this.lblCreateCode);
            this.grpReceive.Controls.Add(this.cdvOwnerCode);
            this.grpReceive.Controls.Add(this.cdvCreateCode);
            this.grpReceive.Controls.Add(this.lblPriority);
            this.grpReceive.Controls.Add(this.lblOwnerCode);
            this.grpReceive.Controls.Add(this.txtNewQty3);
            this.grpReceive.Controls.Add(this.txtNewQty2);
            this.grpReceive.Controls.Add(this.txtNewQty1);
            this.grpReceive.Controls.Add(this.cdvToOper);
            this.grpReceive.Controls.Add(this.lblQty1);
            this.grpReceive.Controls.Add(this.lblToOper);
            this.grpReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpReceive.Location = new System.Drawing.Point(0, 0);
            this.grpReceive.Name = "grpReceive";
            this.grpReceive.Size = new System.Drawing.Size(722, 235);
            this.grpReceive.TabIndex = 0;
            this.grpReceive.TabStop = false;
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.FlowReadOnly = false;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 106;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '2';
            this.cdvToFlow.Location = new System.Drawing.Point(12, 40);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvToFlow.TabIndex = 1;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 200;
            this.cdvToFlow.WidthSequence = 50;
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_ButtonPress);
            this.cdvToFlow.FlowTextChanged += new System.EventHandler(this.cdvToFlow_TextBoxTextChanged);
            // 
            // cdvToMaterial
            // 
            this.cdvToMaterial.AddEmptyRowToLast = false;
            this.cdvToMaterial.AddEmptyRowToTop = false;
            this.cdvToMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMaterial.DisplaySubItemIndex = 0;
            this.cdvToMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelText = "To Material";
            this.cdvToMaterial.ListCond_ExtFactory = "";
            this.cdvToMaterial.ListCond_StepMaterial = '1';
            this.cdvToMaterial.ListCond_StepVersion = '1';
            this.cdvToMaterial.Location = new System.Drawing.Point(12, 16);
            this.cdvToMaterial.MaterialEnabled = true;
            this.cdvToMaterial.MaterialReadOnly = false;
            this.cdvToMaterial.Name = "cdvToMaterial";
            this.cdvToMaterial.SearchSubItemIndex = 0;
            this.cdvToMaterial.SelectedDescIndex = -1;
            this.cdvToMaterial.SelectedSubItemIndex = 0;
            this.cdvToMaterial.Size = new System.Drawing.Size(306, 20);
            this.cdvToMaterial.TabIndex = 0;
            this.cdvToMaterial.VersionEnabled = true;
            this.cdvToMaterial.VersionReadOnly = false;
            this.cdvToMaterial.VisibleColumnHeader = false;
            this.cdvToMaterial.VisibleDescription = false;
            this.cdvToMaterial.VisibleMaterialButton = true;
            this.cdvToMaterial.VisibleVersionButton = true;
            this.cdvToMaterial.WidthButton = 20;
            this.cdvToMaterial.WidthLabel = 106;
            this.cdvToMaterial.WidthMaterialAndVersion = 200;
            this.cdvToMaterial.WidthVersion = 50;
            this.cdvToMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMaterial_SelectedItemChanged);
            this.cdvToMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMaterial_SelectedItemChanged);
            this.cdvToMaterial.VersionChanged += new System.EventHandler(this.cdvToMaterial_TextBoxTextChanged);
            // 
            // btnCalculation
            // 
            this.btnCalculation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculation.Location = new System.Drawing.Point(604, 87);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(74, 22);
            this.btnCalculation.TabIndex = 17;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // cdvCarrier
            // 
            this.cdvCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCarrier.BtnToolTipText = "";
            this.cdvCarrier.DescText = "";
            this.cdvCarrier.DisplaySubItemIndex = -1;
            this.cdvCarrier.DisplayText = "";
            this.cdvCarrier.Focusing = null;
            this.cdvCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCarrier.Index = 0;
            this.cdvCarrier.IsViewBtnImage = false;
            this.cdvCarrier.Location = new System.Drawing.Point(478, 112);
            this.cdvCarrier.MaxLength = 20;
            this.cdvCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.Name = "cdvCarrier";
            this.cdvCarrier.ReadOnly = false;
            this.cdvCarrier.SearchSubItemIndex = 0;
            this.cdvCarrier.SelectedDescIndex = -1;
            this.cdvCarrier.SelectedSubItemIndex = -1;
            this.cdvCarrier.SelectionStart = 0;
            this.cdvCarrier.Size = new System.Drawing.Size(200, 20);
            this.cdvCarrier.SmallImageList = null;
            this.cdvCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCarrier.TabIndex = 19;
            this.cdvCarrier.TextBoxToolTipText = "";
            this.cdvCarrier.TextBoxWidth = 200;
            this.cdvCarrier.Visible = false;
            this.cdvCarrier.VisibleButton = true;
            this.cdvCarrier.VisibleColumnHeader = false;
            this.cdvCarrier.VisibleDescription = false;
            this.cdvCarrier.ButtonPress += new System.EventHandler(this.cdvCarrier_ButtonPress);
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(362, 116);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(51, 13);
            this.lblCarrier.TabIndex = 18;
            this.lblCarrier.Text = "Carrier ID";
            this.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCarrier.Visible = false;
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.Items.AddRange(new object[] {
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.cboPriority.Location = new System.Drawing.Point(478, 64);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(200, 21);
            this.cboPriority.TabIndex = 14;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(478, 89);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(124, 20);
            this.txtDueDate.TabIndex = 16;
            this.txtDueDate.TabStop = false;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDueDate.Location = new System.Drawing.Point(362, 91);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(86, 18);
            this.chkDueDate.TabIndex = 15;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(478, 89);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDueDate.TabIndex = 16;
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(64, 92);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(48, 13);
            this.lblQty23.TabIndex = 5;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(362, 19);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 9;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOwnerCode
            // 
            this.cdvOwnerCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOwnerCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOwnerCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOwnerCode.BtnToolTipText = "";
            this.cdvOwnerCode.DescText = "";
            this.cdvOwnerCode.DisplaySubItemIndex = -1;
            this.cdvOwnerCode.DisplayText = "";
            this.cdvOwnerCode.Focusing = null;
            this.cdvOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOwnerCode.Index = 0;
            this.cdvOwnerCode.IsViewBtnImage = false;
            this.cdvOwnerCode.Location = new System.Drawing.Point(478, 40);
            this.cdvOwnerCode.MaxLength = 10;
            this.cdvOwnerCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.Name = "cdvOwnerCode";
            this.cdvOwnerCode.ReadOnly = false;
            this.cdvOwnerCode.SearchSubItemIndex = 0;
            this.cdvOwnerCode.SelectedDescIndex = -1;
            this.cdvOwnerCode.SelectedSubItemIndex = -1;
            this.cdvOwnerCode.SelectionStart = 0;
            this.cdvOwnerCode.Size = new System.Drawing.Size(200, 20);
            this.cdvOwnerCode.SmallImageList = null;
            this.cdvOwnerCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOwnerCode.TabIndex = 12;
            this.cdvOwnerCode.TextBoxToolTipText = "";
            this.cdvOwnerCode.TextBoxWidth = 200;
            this.cdvOwnerCode.VisibleButton = true;
            this.cdvOwnerCode.VisibleColumnHeader = false;
            this.cdvOwnerCode.VisibleDescription = false;
            this.cdvOwnerCode.ButtonPress += new System.EventHandler(this.cdvOwnerCode_ButtonPress);
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
            this.cdvCreateCode.Location = new System.Drawing.Point(478, 16);
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
            this.cdvCreateCode.TabIndex = 10;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 200;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(362, 67);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 13;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(362, 43);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 11;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(252, 88);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty3.TabIndex = 8;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewQty3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewQty_KeyPress);
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(185, 88);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty2.TabIndex = 7;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewQty2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewQty_KeyPress);
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(118, 88);
            this.txtNewQty1.MaxLength = 11;
            this.txtNewQty1.Name = "txtNewQty1";
            this.txtNewQty1.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty1.TabIndex = 6;
            this.txtNewQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewQty1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewQty_KeyPress);
            // 
            // cdvToOper
            // 
            this.cdvToOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToOper.BtnToolTipText = "";
            this.cdvToOper.DescText = "";
            this.cdvToOper.DisplaySubItemIndex = -1;
            this.cdvToOper.DisplayText = "";
            this.cdvToOper.Focusing = null;
            this.cdvToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.Index = 0;
            this.cdvToOper.IsViewBtnImage = false;
            this.cdvToOper.Location = new System.Drawing.Point(118, 64);
            this.cdvToOper.MaxLength = 10;
            this.cdvToOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToOper.Name = "cdvToOper";
            this.cdvToOper.ReadOnly = false;
            this.cdvToOper.SearchSubItemIndex = 0;
            this.cdvToOper.SelectedDescIndex = -1;
            this.cdvToOper.SelectedSubItemIndex = -1;
            this.cdvToOper.SelectionStart = 0;
            this.cdvToOper.Size = new System.Drawing.Size(200, 20);
            this.cdvToOper.SmallImageList = null;
            this.cdvToOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToOper.TabIndex = 3;
            this.cdvToOper.TextBoxToolTipText = "";
            this.cdvToOper.TextBoxWidth = 200;
            this.cdvToOper.VisibleButton = true;
            this.cdvToOper.VisibleColumnHeader = false;
            this.cdvToOper.VisibleDescription = false;
            this.cdvToOper.ButtonPress += new System.EventHandler(this.cdvToOper_ButtonPress);
            this.cdvToOper.TextBoxTextChanged += new System.EventHandler(this.cdvToOper_TextBoxTextChanged);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 92);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(57, 13);
            this.lblQty1.TabIndex = 4;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToOper
            // 
            this.lblToOper.AutoSize = true;
            this.lblToOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToOper.Location = new System.Drawing.Point(12, 67);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(81, 13);
            this.lblToOper.TabIndex = 2;
            this.lblToOper.Text = "To Operation";
            this.lblToOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranReceiveLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranReceiveLot";
            this.Text = "Receive Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranReceiveLot_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
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
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpReceive.ResumeLayout(false);
            this.grpReceive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOper)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            cdvToFlow.Init();
            cdvToOper.Items.Clear();

            MPCF.FieldClear(this, txtLotID);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            cdvToMaterial.Text = LOT.GetString("MAT_ID");
            cdvToMaterial.Version = LOT.GetInt("MAT_VER");
            if (View_Material() == false)
            {
                cdvToMaterial.Text = "";
            }
            cdvCreateCode.Text = LOT.GetString("CREATE_CODE");
            cdvOwnerCode.Text = LOT.GetString("OWNER_CODE");
            cboPriority.Text = LOT.GetChar("LOT_PRIORITY").ToString();

            return true;
        }

        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {
            ClearLotSpread();

            cdvToFlow.Init();
            cdvToOper.Items.Clear();
            
            switch (iStep)
            {
                case 0:

                    MPCF.FieldClear(this);
                    cboPriority.SelectedIndex = 4;
                    txtDueDate.Visible = ! chkDueDate.Checked;
                    break;
            }
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        //
        private bool CheckCondition()
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (cdvToMaterial.CheckValue() == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToMaterial.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvToOper, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToOper.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvCreateCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvCreateCode.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvOwnerCode.Focus();
                return false;
            }
            if (txtNewQty1.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty1, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty1.Focus();
                    return false;
                }
            }
            if (txtNewQty2.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty2, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty1.Focus();
                    return false;
                }
            }
            if (txtNewQty3.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty3, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty1.Focus();
                    return false;
                }
            }
            
            if (MPGO.AutoCalDueDate() == false)
            {
                if (chkDueDate.Checked == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    chkDueDate.Focus();
                    return false;
                }
            }
            else
            {
                if (chkDueDate.Checked == false)
                {
                    if (MPCF.Trim(txtDueDate.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtDueDate.Focus();
                        return false;
                    }
                }
            }
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }
            
            return true;
            
        }
        
        
        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Material()
        {

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvToMaterial.Text));
            in_node.AddInt("MAT_VER", cdvToMaterial.Version);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node, true) == false)
            {
                return false;
            }

            cdvToFlow.Text = out_node.GetString("FIRST_FLOW");
            cdvToFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvToOper.Text = out_node.GetString("FIRST_OPER");

            return true;

        }

        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Flow()
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvToFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvToOper.Text = out_node.GetString("FIRST_OPER");

            return true;

        }


        //
        // SetDueDate()
        //       - Due Date Auto Calculation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetDueDate()
        {
            
            double dSumQueueTime = 0;
            double dSumProcTime = 0;
            double dSumQueueProcTime = 0;
            double dQty1 = 0;
            
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            if (cdvToMaterial.CheckValue() == false)
            {
                return false;
            }
            if (cdvToFlow.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToOper, 1) == false)
            {
                return false;
            }
            
            if (txtNewQty1.Text == "")
            {
                dQty1 = 0;
            }
            else
            {
                dQty1 = MPCF.ToDbl(txtNewQty1.Text);
            }

            if (MPCR.GetProcTime(MPCF.Trim(cdvToMaterial.Text), cdvToMaterial.Version, MPCF.Trim(cdvToFlow.Text), cdvToFlow.Sequence, MPCF.Trim(cdvToOper.Text), dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }
            
            //2006.04.25. CM Koo. CycleTime Unit???∞Îùº ?îÌïò???úÍ∞Ñ ?®ÏúÑÎ•??¨Î¶¨ ?ÅÏö©
            if (MPGO.CycleTimeUnit() == "M")
            {
                dtpDueDate.Value = DateTime.Now.AddMinutes(dSumQueueProcTime);
            }
            else
            {
                dtpDueDate.Value = DateTime.Now.AddHours(dSumQueueProcTime);
            }
            txtDueDate.Text = MPCF.MakeDateFormat(MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), DATE_TIME_FORMAT.DATE);
            return true;
        }
        
        // Receive_Lot()
        //       -   Receive Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Receive_Lot()
        {
            TRSNode in_node = new TRSNode("RECEIVE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("TO_MAT_ID", MPCF.Trim(cdvToMaterial.Text));
                in_node.AddInt("TO_MAT_VER", cdvToMaterial.Version);
                in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Text));
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
#if _CRR
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCarrier.Text));
#endif //_CRR
                in_node.AddChar("LOT_PRIORITY", (MPCF.Trim(cboPriority.Text) == "") ? '5' : (MPCF.ToChar(cboPriority.Text)));

                in_node.AddDouble("QTY_1", (txtNewQty1.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty1.Text)));
                in_node.AddDouble("QTY_2", (txtNewQty2.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty2.Text)));
                in_node.AddDouble("QTY_3", (txtNewQty3.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty3.Text)));

                in_node.AddString("DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Receive_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        #endregion
        
        private void frmWIPTranReceiveLot_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
#if _CRR
                lblCarrier.Visible = true;
                cdvCarrier.Visible = true;
#endif //_CRR
                
                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_RECEIVE);

                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                
                b_load_flag = true;
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (MPCF.Trim(txtLotID.Text) == "")
            {
                ClearData(0);
            }
        }
        
        private void cdvToMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvToFlow.Text = "";
            cdvToOper.Text = "";
            
            if (View_Material() == false)
            {
                return;
            }
            
        }
        
        private void cdvToMaterial_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
            cdvToFlow.Text = "";
            cdvToOper.Text = "";
            
        }
        
        private void cdvToFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToMaterial.CheckValue() == false) return;

            cdvToFlow.ListCond_MatID = cdvToMaterial.Text;
            cdvToFlow.ListCond_MatVersion = cdvToMaterial.Version;
        }
        
        private void cdvToFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (View_Flow() == false)
            {
                return;
            }
            
        }
        
        private void cdvToFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
            cdvToOper.Text = "";
            
        }
        
        private void cdvToOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
            txtNewQty1.Text = "";
            txtNewQty2.Text = "";
            txtNewQty3.Text = "";
            
        }
        
        private void cdvToOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToMaterial.CheckValue() == false) return;
            if (cdvToFlow.CheckValue() == false) return;

            cdvToOper.Init();
            MPCF.InitListView(cdvToOper.GetListView);
            cdvToOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvToOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvToOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvToOper.GetListView, '2', "", 0,cdvToFlow.Text, "", null, "");
            
        }
        
        private void txtNewQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    if (e.KeyChar != (char)46)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;
            
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_RECEIVE, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
            if (Receive_Lot() == false) return;
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_RECEIVE, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

            ViewLotInfo(txtLotID.Text);            
        }
        
        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtDueDate.Visible = ! chkDueDate.Checked;
            
        }
        
        private void cdvCarrier_ButtonPress(object sender, System.EventArgs e)
        {
#if _CRR
            try
            {
                cdvCarrier.Init();
                MPCF.InitListView(cdvCarrier.GetListView);
                cdvCarrier.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCarrier.SelectedSubItemIndex = 0;

                if (RASLIST.ViewCarrierList(cdvCarrier.GetListView, '2', "", "", "", ' ', cdvToMaterial.Text, cdvToMaterial.Version, cdvToFlow.Text, cdvToOper.Text, "", "", cdvCarrier.Text, null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif //_CRR
        }
                
        private void btnCalculation_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (SetDueDate() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
            
        }
        
        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }
    }
    
}
