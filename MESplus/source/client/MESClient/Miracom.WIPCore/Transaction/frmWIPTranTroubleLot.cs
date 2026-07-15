
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
    public class frmWIPTranTroubleLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranTroubleLot()
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

        private GroupBox grpTranInfo;
        private CheckBox chkComment3;
        private Label lblComment3;
        private CheckBox chkComment2;
        private Label lblComment2;
        private CheckBox chkComment1;
        private TextBox txtComment1;
        private Label lblComment1;
        private TextBox txtComment3;
        private TextBox txtComment2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private Label lblCauseRes;
        private Label lblCauseOper;
        private Label lblCauseFlow;
        private Label lblResID;
        private UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        private Label lblHoldCode;
        
        
        private System.ComponentModel.Container components = null;
        


        //肄붾뱶 ?몄쭛湲곕? ?ъ슜?섏뿬 ?섏젙?섏? 留덉떗?쒖삤.
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.chkComment3 = new System.Windows.Forms.CheckBox();
            this.lblComment3 = new System.Windows.Forms.Label();
            this.chkComment2 = new System.Windows.Forms.CheckBox();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.chkComment1 = new System.Windows.Forms.CheckBox();
            this.txtComment1 = new System.Windows.Forms.TextBox();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.txtComment3 = new System.Windows.Forms.TextBox();
            this.txtComment2 = new System.Windows.Forms.TextBox();
            this.cdvCauseRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
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
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
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
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
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
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            // 
            // txtLotID
            // 
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
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
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Trouble Lot";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.cdvHoldCode);
            this.grpTranInfo.Controls.Add(this.lblHoldCode);
            this.grpTranInfo.Controls.Add(this.chkComment3);
            this.grpTranInfo.Controls.Add(this.lblComment3);
            this.grpTranInfo.Controls.Add(this.chkComment2);
            this.grpTranInfo.Controls.Add(this.lblComment2);
            this.grpTranInfo.Controls.Add(this.chkComment1);
            this.grpTranInfo.Controls.Add(this.txtComment1);
            this.grpTranInfo.Controls.Add(this.lblComment1);
            this.grpTranInfo.Controls.Add(this.txtComment3);
            this.grpTranInfo.Controls.Add(this.txtComment2);
            this.grpTranInfo.Controls.Add(this.cdvCauseRes);
            this.grpTranInfo.Controls.Add(this.cdvCauseOper);
            this.grpTranInfo.Controls.Add(this.cdvCauseFlow);
            this.grpTranInfo.Controls.Add(this.cdvResID);
            this.grpTranInfo.Controls.Add(this.lblCauseRes);
            this.grpTranInfo.Controls.Add(this.lblCauseOper);
            this.grpTranInfo.Controls.Add(this.lblCauseFlow);
            this.grpTranInfo.Controls.Add(this.lblResID);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 235);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // cdvHoldCode
            // 
            this.cdvHoldCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCode.BtnToolTipText = "";
            this.cdvHoldCode.DescText = "";
            this.cdvHoldCode.DisplaySubItemIndex = -1;
            this.cdvHoldCode.DisplayText = "";
            this.cdvHoldCode.Focusing = null;
            this.cdvHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCode.Index = 0;
            this.cdvHoldCode.IsViewBtnImage = false;
            this.cdvHoldCode.Location = new System.Drawing.Point(113, 15);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = false;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(592, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 8;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 200;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = true;
            this.cdvHoldCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvHoldCode_SelectedItemChanged);
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(9, 18);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 28;
            this.lblHoldCode.Text = "Hold Code";
            // 
            // chkComment3
            // 
            this.chkComment3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment3.Location = new System.Drawing.Point(95, 189);
            this.chkComment3.Name = "chkComment3";
            this.chkComment3.Size = new System.Drawing.Size(13, 12);
            this.chkComment3.TabIndex = 26;
            this.chkComment3.CheckedChanged += new System.EventHandler(this.chkComment3_CheckedChanged);
            // 
            // lblComment3
            // 
            this.lblComment3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment3.Location = new System.Drawing.Point(8, 192);
            this.lblComment3.Name = "lblComment3";
            this.lblComment3.Size = new System.Drawing.Size(100, 14);
            this.lblComment3.TabIndex = 25;
            this.lblComment3.Text = "Result";
            this.lblComment3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkComment2
            // 
            this.chkComment2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment2.Location = new System.Drawing.Point(96, 142);
            this.chkComment2.Name = "chkComment2";
            this.chkComment2.Size = new System.Drawing.Size(13, 12);
            this.chkComment2.TabIndex = 23;
            this.chkComment2.CheckedChanged += new System.EventHandler(this.chkComment2_CheckedChanged);
            // 
            // lblComment2
            // 
            this.lblComment2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment2.Location = new System.Drawing.Point(8, 143);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(100, 14);
            this.lblComment2.TabIndex = 22;
            this.lblComment2.Text = "Reason";
            this.lblComment2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkComment1
            // 
            this.chkComment1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkComment1.Location = new System.Drawing.Point(95, 95);
            this.chkComment1.Name = "chkComment1";
            this.chkComment1.Size = new System.Drawing.Size(13, 12);
            this.chkComment1.TabIndex = 20;
            this.chkComment1.CheckedChanged += new System.EventHandler(this.chkComment1_CheckedChanged);
            // 
            // txtComment1
            // 
            this.txtComment1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment1.Location = new System.Drawing.Point(113, 92);
            this.txtComment1.Multiline = true;
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.ReadOnly = true;
            this.txtComment1.Size = new System.Drawing.Size(592, 40);
            this.txtComment1.TabIndex = 21;
            // 
            // lblComment1
            // 
            this.lblComment1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment1.Location = new System.Drawing.Point(8, 96);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(100, 14);
            this.lblComment1.TabIndex = 19;
            this.lblComment1.Text = "Estimate Reason";
            this.lblComment1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment3
            // 
            this.txtComment3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment3.Location = new System.Drawing.Point(113, 188);
            this.txtComment3.Multiline = true;
            this.txtComment3.Name = "txtComment3";
            this.txtComment3.ReadOnly = true;
            this.txtComment3.Size = new System.Drawing.Size(592, 40);
            this.txtComment3.TabIndex = 27;
            // 
            // txtComment2
            // 
            this.txtComment2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment2.Location = new System.Drawing.Point(113, 140);
            this.txtComment2.Multiline = true;
            this.txtComment2.Name = "txtComment2";
            this.txtComment2.ReadOnly = true;
            this.txtComment2.Size = new System.Drawing.Size(592, 40);
            this.txtComment2.TabIndex = 24;
            // 
            // cdvCauseRes
            // 
            this.cdvCauseRes.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseRes.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseRes.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseRes.BtnToolTipText = "";
            this.cdvCauseRes.DescText = "";
            this.cdvCauseRes.DisplaySubItemIndex = -1;
            this.cdvCauseRes.DisplayText = "";
            this.cdvCauseRes.Focusing = null;
            this.cdvCauseRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseRes.Index = 0;
            this.cdvCauseRes.IsViewBtnImage = false;
            this.cdvCauseRes.Location = new System.Drawing.Point(505, 66);
            this.cdvCauseRes.MaxLength = 20;
            this.cdvCauseRes.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.Name = "cdvCauseRes";
            this.cdvCauseRes.ReadOnly = false;
            this.cdvCauseRes.SearchSubItemIndex = 0;
            this.cdvCauseRes.SelectedDescIndex = -1;
            this.cdvCauseRes.SelectedSubItemIndex = -1;
            this.cdvCauseRes.SelectionStart = 0;
            this.cdvCauseRes.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseRes.SmallImageList = null;
            this.cdvCauseRes.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseRes.TabIndex = 15;
            this.cdvCauseRes.TextBoxToolTipText = "";
            this.cdvCauseRes.TextBoxWidth = 200;
            this.cdvCauseRes.VisibleButton = true;
            this.cdvCauseRes.VisibleColumnHeader = false;
            this.cdvCauseRes.VisibleDescription = false;
            this.cdvCauseRes.ButtonPress += new System.EventHandler(this.cdvCauseRes_ButtonPress);
            // 
            // cdvCauseOper
            // 
            this.cdvCauseOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseOper.BtnToolTipText = "";
            this.cdvCauseOper.DescText = "";
            this.cdvCauseOper.DisplaySubItemIndex = -1;
            this.cdvCauseOper.DisplayText = "";
            this.cdvCauseOper.Focusing = null;
            this.cdvCauseOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseOper.Index = 0;
            this.cdvCauseOper.IsViewBtnImage = false;
            this.cdvCauseOper.Location = new System.Drawing.Point(113, 66);
            this.cdvCauseOper.MaxLength = 10;
            this.cdvCauseOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.Name = "cdvCauseOper";
            this.cdvCauseOper.ReadOnly = false;
            this.cdvCauseOper.SearchSubItemIndex = 0;
            this.cdvCauseOper.SelectedDescIndex = -1;
            this.cdvCauseOper.SelectedSubItemIndex = -1;
            this.cdvCauseOper.SelectionStart = 0;
            this.cdvCauseOper.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseOper.SmallImageList = null;
            this.cdvCauseOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseOper.TabIndex = 11;
            this.cdvCauseOper.TextBoxToolTipText = "";
            this.cdvCauseOper.TextBoxWidth = 200;
            this.cdvCauseOper.VisibleButton = true;
            this.cdvCauseOper.VisibleColumnHeader = false;
            this.cdvCauseOper.VisibleDescription = false;
            this.cdvCauseOper.ButtonPress += new System.EventHandler(this.cdvCauseOper_ButtonPress);
            // 
            // cdvCauseFlow
            // 
            this.cdvCauseFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseFlow.BtnToolTipText = "";
            this.cdvCauseFlow.DescText = "";
            this.cdvCauseFlow.DisplaySubItemIndex = -1;
            this.cdvCauseFlow.DisplayText = "";
            this.cdvCauseFlow.Focusing = null;
            this.cdvCauseFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseFlow.Index = 0;
            this.cdvCauseFlow.IsViewBtnImage = false;
            this.cdvCauseFlow.Location = new System.Drawing.Point(505, 42);
            this.cdvCauseFlow.MaxLength = 20;
            this.cdvCauseFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.Name = "cdvCauseFlow";
            this.cdvCauseFlow.ReadOnly = false;
            this.cdvCauseFlow.SearchSubItemIndex = 0;
            this.cdvCauseFlow.SelectedDescIndex = -1;
            this.cdvCauseFlow.SelectedSubItemIndex = -1;
            this.cdvCauseFlow.SelectionStart = 0;
            this.cdvCauseFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseFlow.SmallImageList = null;
            this.cdvCauseFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseFlow.TabIndex = 13;
            this.cdvCauseFlow.TextBoxToolTipText = "";
            this.cdvCauseFlow.TextBoxWidth = 200;
            this.cdvCauseFlow.VisibleButton = true;
            this.cdvCauseFlow.VisibleColumnHeader = false;
            this.cdvCauseFlow.VisibleDescription = false;
            this.cdvCauseFlow.ButtonPress += new System.EventHandler(this.cdvCauseFlow_ButtonPress);
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(113, 42);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 9;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Location = new System.Drawing.Point(399, 69);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(100, 14);
            this.lblCauseRes.TabIndex = 14;
            this.lblCauseRes.Text = "Cause Resource";
            this.lblCauseRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCauseOper
            // 
            this.lblCauseOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseOper.Location = new System.Drawing.Point(8, 69);
            this.lblCauseOper.Name = "lblCauseOper";
            this.lblCauseOper.Size = new System.Drawing.Size(100, 14);
            this.lblCauseOper.TabIndex = 10;
            this.lblCauseOper.Text = "Cause Operation";
            this.lblCauseOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Location = new System.Drawing.Point(399, 44);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(100, 14);
            this.lblCauseFlow.TabIndex = 12;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResID
            // 
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(8, 44);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(100, 14);
            this.lblResID.TabIndex = 8;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranTroubleLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranTroubleLot";
            this.Text = "Trouble Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranTroubleLot_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranTroubleLot_Load);
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
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        public bool b_load_flag;
        public string sLotID = "";
        public string sOrgLotID = "";
        public int Hist_Seq = 0;
        
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
            //sLotID = "";
            //Hist_Seq = 0;

            MPCF.FieldClear(this, txtLotID);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (LOT.GetString("OPER") != "")
            {
#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false) return false;
#endif
            }
            if (ViewTroubleLot() == false) return false;

            //Add by J.S. Hold code선택해서 hist seq를 선택가능하게 수정
            if (cdvHoldCode.Enabled == true)
            {
                if (View_Lot_Hold_Code_List() == false) return false;
            }

            return true;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case "1":

                        MPCF.FieldClear(this);
                        sLotID = "";
                        Hist_Seq = 0;
                        break;
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
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "TROUBLE_LOT":

                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }

                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        // initCodeView()
        //       -   initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //       -
        private void InitCodeView()
        {
            
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            
            cdvCauseFlow.Init();
            MPCF.InitListView(cdvCauseFlow.GetListView);
            cdvCauseFlow.Columns.Add("Flow", 150, HorizontalAlignment.Left);
            cdvCauseFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCauseFlow.SelectedSubItemIndex = 0;
            
            cdvCauseOper.Init();
            MPCF.InitListView(cdvCauseOper.GetListView);
            cdvCauseOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvCauseOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCauseOper.SelectedSubItemIndex = 0;
            
            cdvCauseRes.Init();
            MPCF.InitListView(cdvCauseRes.GetListView);
            cdvCauseRes.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvCauseRes.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCauseRes.SelectedSubItemIndex = 0;
            
        }
        
        
        // ViewTroubleLot()
        //       - View Trouble Lot Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //        -
        //
        private bool ViewTroubleLot()
        {
            TRSNode in_node = new TRSNode("VIEW_TROUBLE_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_TROUBLE_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            if (sOrgLotID == txtLotID.Text.Trim())
            {
                in_node.AddInt("HIST_SEQ", Hist_Seq);
            }
            else
            {
                if (cdvHoldCode.Enabled == true && MPCF.Trim(cdvHoldCode.DescText) != "")
                {
                    in_node.AddInt("HIST_SEQ", cdvHoldCode.DescText);
                }
                else
                {
                    in_node.AddInt("HIST_SEQ", LOT.GetInt("LAST_HIST_SEQ"));
                }
            }

            if (MPCR.CallService("WIP", "WIP_View_Trouble_Lot", in_node, ref out_node) == false)
            {
                if (out_node.MsgCode == "WIP-0263")
                {
                    chkComment1.Enabled = false;
                    chkComment2.Enabled = false;
                    chkComment3.Enabled = false;
                    btnProcess.Enabled = false;
                    return false;
                }
                else
                {
                    return false;
                }
            }

            if (out_node.GetString("RELEASE_TRAN_TIME") == "")
            {
                chkComment1.Enabled = true;
                chkComment2.Enabled = true;
                chkComment3.Enabled = true;
                btnProcess.Enabled = true;
                MPCR.ChangeControlEnabled(this, btnProcess, true);
            }
            else
            {
                chkComment1.Enabled = false;
                chkComment2.Enabled = false;
                chkComment3.Enabled = false;
                btnProcess.Enabled = false;
            }
            
            cdvCauseFlow.Text = MPCF.Trim(out_node.GetString("CAUSE_FLOW"));
            cdvCauseOper.Text = MPCF.Trim(out_node.GetString("CAUSE_OPER"));
            cdvResID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
            cdvCauseRes.Text = MPCF.Trim(out_node.GetString("CAUSE_RES_ID"));
            txtComment.Text = MPCF.Trim(out_node.GetString("HOLD_COMMENT"));
            txtComment1.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_1"));
            txtComment2.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_2"));
            txtComment3.Text = MPCF.Trim(out_node.GetString("USER_COMMENT_3"));

            return true;

        }

        //
        // Trouble_Lot()
        //       - Trouble Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Trouble_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("TROUBLE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("HOLD_COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("USER_COMMENT_1", MPCF.Trim(txtComment1.Text));
                in_node.AddString("USER_COMMENT_2", MPCF.Trim(txtComment2.Text));
                in_node.AddString("USER_COMMENT_3", MPCF.Trim(txtComment3.Text));

                if (sOrgLotID == txtLotID.Text.Trim())
                {
                    in_node.AddInt("HIST_SEQ", Hist_Seq);
                }
                else
                {
                    if (cdvHoldCode.Enabled == true && MPCF.Trim(cdvHoldCode.DescText) != "")
                    {
                        in_node.AddInt("HIST_SEQ", cdvHoldCode.DescText);
                    }
                    else
                    {
                        in_node.AddInt("HIST_SEQ", LOT.GetInt("LAST_HIST_SEQ"));
                    }
                }

                //in_node.AddInt("HIST_SEQ", LOT.GetInt("LAST_HIST_SEQ"));

                if (MPCR.CallService("WIP", "WIP_Trouble_Lot", in_node, ref out_node) == false)
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


        // Release_Lot()
        //       -   Hold Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Lot_Hold_Code_List()
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LOT_HOLD_CODE_LIST_IN");
            TRSNode out_node = new TRSNode("LOT_HOLD_CODE_LIST_OUT");

            try
            {
                cdvHoldCode.Text = "";
                cdvHoldCode.Init();
                MPCF.InitListView(cdvHoldCode.GetListView);
                cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
                cdvHoldCode.Columns.Add("Tran Time", 200, HorizontalAlignment.Left);
                cdvHoldCode.Columns.Add("Hist Seq", 150, HorizontalAlignment.Left);
                cdvHoldCode.SelectedSubItemIndex = 0;
                //Modify J.S. 2012.06.13 display hist seq
                cdvHoldCode.SelectedDescIndex = 2;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_View_Lot_Hold_Code_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("HOLD_CODE"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("HIST_SEQ").ToString());
                    cdvHoldCode.GetListView.Items.Add(itmX);
                }


                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        #endregion
        
        private void frmWIPTranTroubleLot_Load(object sender, System.EventArgs e)
        {
            
            chkComment1.Enabled = true;
            chkComment2.Enabled = true;
            chkComment3.Enabled = true;
        }
        
        private void frmWIPTranTroubleLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    InitCodeView();
                    SetCMFItem(MPGC.MP_CMF_TRN_TROUBLE);
                    if (sLotID != "")
                    {
                        txtLotID.Text = sLotID;
                        ViewLotInfo(txtLotID.Text);

                        //Modify J.S. 2012.06.13 trouble lot list에서 호출하는 경우 hold code를 선택할 수 없다
                        cdvHoldCode.Enabled = false;
                    }
                    else
                    {
                        ClearData("1");
                        b_load_flag = true;
                        //Modify J.S. 2012.06.13 메뉴에서 직접 호출하는 경우 대비
                        if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                        {
                            txtLotID.Text = MPGV.gsCurrentLot_ID;

                            if (ViewLotInfo(txtLotID.Text) == false) return;

                        }
                    }

                    MPCR.ChangeControlEnabled(this, btnProcess, true);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCauseFlow_ButtonPress(System.Object sender, System.EventArgs e)
        {
            string sMat_ID;

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            sMat_ID = LOT.GetString("MAT_ID");
            if (sMat_ID == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                txtLotID.Focus();
                return;
            }
            
            WIPLIST.ViewFlowList(cdvCauseFlow.GetListView, '1', "", 0, "", null, "");
            
        }
        
        private void cdvCauseOper_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            
            if (cdvCauseFlow.Text != "")
            {
                WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '4', LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), cdvCauseFlow.Text, "", null, "");
            }
            else
            {
                WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '1', "", 0,"", "", null, "");
            }
            
        }
        
        private void cdvCauseRes_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            if (cdvCauseOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvCauseOper.Focus();
                return;
            }
            
            if (cdvCauseOper.Text != "")
            {
                #if _RAS
                RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false);
                #endif
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("TROUBLE_LOT") == false) return;
                if (Trouble_Lot('1') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void chkComment1_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtComment1.ReadOnly = ! chkComment1.Checked;
            
        }
        
        private void chkComment2_CheckedChanged(object sender, System.EventArgs e)
        {
            
            txtComment2.ReadOnly = ! chkComment2.Checked;
            
        }
        
        private void chkComment3_CheckedChanged(object sender, System.EventArgs e)
        {
            
            txtComment3.ReadOnly = ! chkComment3.Checked;
            
        }

        private void cdvHoldCode_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvHoldCode.DescText) != "")
            {
                ViewTroubleLot();
            }
        }

        private void txtLotID_TextChanged(object sender, EventArgs e)
        {
            cdvHoldCode.Init();
        }
    }
}
