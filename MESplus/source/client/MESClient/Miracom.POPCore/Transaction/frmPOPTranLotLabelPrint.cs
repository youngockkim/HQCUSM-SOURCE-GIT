
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;

using Miracom.TRSCore;

//#If _POP = True Then

namespace Miracom.POPCore
{
    public class frmPOPTranLotLabelPrint : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmPOPTranLotLabelPrint()
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
        



        private System.Windows.Forms.GroupBox grpPrintInfo;
        protected System.Windows.Forms.TextBox txtLabelDesc;
        protected System.Windows.Forms.TextBox txtLabelID;
        protected System.Windows.Forms.Label lblLabelID;
        protected System.Windows.Forms.TextBox txtCustomerMatID;
        protected System.Windows.Forms.Label lblCustomerMatID;
        protected System.Windows.Forms.TextBox txtCustomer;
        protected System.Windows.Forms.Label lblCustomer;
        protected System.Windows.Forms.Label lblPort;
        private CheckBox chkLot;
        private CheckBox chkRPrint;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLabelID;
        private CheckBox chkDefaultPrinter;
        private System.Windows.Forms.ComboBox cboPort;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpPrintInfo = new System.Windows.Forms.GroupBox();
            this.cdvLabelID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtLabelDesc = new System.Windows.Forms.TextBox();
            this.txtLabelID = new System.Windows.Forms.TextBox();
            this.lblLabelID = new System.Windows.Forms.Label();
            this.txtCustomerMatID = new System.Windows.Forms.TextBox();
            this.lblCustomerMatID = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.chkLot = new System.Windows.Forms.CheckBox();
            this.chkRPrint = new System.Windows.Forms.CheckBox();
            this.chkDefaultPrinter = new System.Windows.Forms.CheckBox();
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
            this.grpPrintInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLabelID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpPrintInfo);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // grpCMF
            // 
            this.grpCMF.Enabled = false;
            this.grpCMF.Visible = false;
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
            // pnlTranTime
            // 
            this.pnlTranTime.TabIndex = 5;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.TabIndex = 3;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.TabIndex = 4;
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.chkLot);
            this.grpTranTop.Controls.SetChildIndex(this.chkLot, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.pnlTranTime, 0);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 5;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkDefaultPrinter);
            this.pnlBottom.Controls.Add(this.chkRPrint);
            this.pnlBottom.Controls.Add(this.lblPort);
            this.pnlBottom.Controls.Add(this.cboPort);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cboPort, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblPort, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkRPrint, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkDefaultPrinter, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Lot Label Print";
            // 
            // grpPrintInfo
            // 
            this.grpPrintInfo.Controls.Add(this.cdvLabelID);
            this.grpPrintInfo.Controls.Add(this.txtLabelDesc);
            this.grpPrintInfo.Controls.Add(this.txtLabelID);
            this.grpPrintInfo.Controls.Add(this.lblLabelID);
            this.grpPrintInfo.Controls.Add(this.txtCustomerMatID);
            this.grpPrintInfo.Controls.Add(this.lblCustomerMatID);
            this.grpPrintInfo.Controls.Add(this.txtCustomer);
            this.grpPrintInfo.Controls.Add(this.lblCustomer);
            this.grpPrintInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrintInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrintInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPrintInfo.Location = new System.Drawing.Point(0, 0);
            this.grpPrintInfo.Name = "grpPrintInfo";
            this.grpPrintInfo.Size = new System.Drawing.Size(722, 242);
            this.grpPrintInfo.TabIndex = 0;
            this.grpPrintInfo.TabStop = false;
            this.grpPrintInfo.Text = "Print Information";
            // 
            // cdvLabelID
            // 
            this.cdvLabelID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLabelID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLabelID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLabelID.BtnToolTipText = "";
            this.cdvLabelID.ButtonWidth = 20;
            this.cdvLabelID.DescText = "";
            this.cdvLabelID.DisplaySubItemIndex = 0;
            this.cdvLabelID.DisplayText = "";
            this.cdvLabelID.Focusing = null;
            this.cdvLabelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvLabelID.Index = 0;
            this.cdvLabelID.IsViewBtnImage = false;
            this.cdvLabelID.Location = new System.Drawing.Point(120, 16);
            this.cdvLabelID.MaxLength = 10;
            this.cdvLabelID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLabelID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLabelID.Name = "cdvLabelID";
            this.cdvLabelID.ReadOnly = false;
            this.cdvLabelID.SameWidthHeightOfButton = false;
            this.cdvLabelID.SearchSubItemIndex = 0;
            this.cdvLabelID.SelectedDescIndex = -1;
            this.cdvLabelID.SelectedSubItemIndex = 0;
            this.cdvLabelID.SelectionStart = 0;
            this.cdvLabelID.Size = new System.Drawing.Size(180, 21);
            this.cdvLabelID.SmallImageList = null;
            this.cdvLabelID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLabelID.TabIndex = 1;
            this.cdvLabelID.TextBoxToolTipText = "";
            this.cdvLabelID.TextBoxWidth = 180;
            this.cdvLabelID.Visible = false;
            this.cdvLabelID.VisibleButton = true;
            this.cdvLabelID.VisibleColumnHeader = false;
            this.cdvLabelID.VisibleDescription = false;
            this.cdvLabelID.ButtonPress += new System.EventHandler(this.cdvLabelID_ButtonPress);
            // 
            // txtLabelDesc
            // 
            this.txtLabelDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelDesc.Location = new System.Drawing.Point(306, 16);
            this.txtLabelDesc.MaxLength = 12;
            this.txtLabelDesc.Name = "txtLabelDesc";
            this.txtLabelDesc.ReadOnly = true;
            this.txtLabelDesc.Size = new System.Drawing.Size(404, 20);
            this.txtLabelDesc.TabIndex = 2;
            this.txtLabelDesc.TabStop = false;
            // 
            // txtLabelID
            // 
            this.txtLabelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelID.Location = new System.Drawing.Point(120, 16);
            this.txtLabelID.MaxLength = 11;
            this.txtLabelID.Name = "txtLabelID";
            this.txtLabelID.ReadOnly = true;
            this.txtLabelID.Size = new System.Drawing.Size(180, 20);
            this.txtLabelID.TabIndex = 1;
            this.txtLabelID.TabStop = false;
            this.txtLabelID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLabelID
            // 
            this.lblLabelID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelID.Location = new System.Drawing.Point(15, 18);
            this.lblLabelID.Name = "lblLabelID";
            this.lblLabelID.Size = new System.Drawing.Size(100, 14);
            this.lblLabelID.TabIndex = 0;
            this.lblLabelID.Text = "Label";
            this.lblLabelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerMatID
            // 
            this.txtCustomerMatID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerMatID.Location = new System.Drawing.Point(456, 41);
            this.txtCustomerMatID.MaxLength = 19;
            this.txtCustomerMatID.Name = "txtCustomerMatID";
            this.txtCustomerMatID.ReadOnly = true;
            this.txtCustomerMatID.Size = new System.Drawing.Size(254, 20);
            this.txtCustomerMatID.TabIndex = 6;
            this.txtCustomerMatID.TabStop = false;
            // 
            // lblCustomerMatID
            // 
            this.lblCustomerMatID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomerMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerMatID.Location = new System.Drawing.Point(306, 44);
            this.lblCustomerMatID.Name = "lblCustomerMatID";
            this.lblCustomerMatID.Size = new System.Drawing.Size(104, 14);
            this.lblCustomerMatID.TabIndex = 5;
            this.lblCustomerMatID.Text = "Customer Mat ID";
            this.lblCustomerMatID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(120, 41);
            this.txtCustomer.MaxLength = 11;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(180, 20);
            this.txtCustomer.TabIndex = 4;
            this.txtCustomer.TabStop = false;
            this.txtCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCustomer
            // 
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(15, 44);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 14);
            this.lblCustomer.TabIndex = 3;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPort
            // 
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Location = new System.Drawing.Point(42, 13);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(42, 14);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.Items.AddRange(new object[] {
            "SPOOL",
            "LPT1",
            "LPT2",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cboPort.Location = new System.Drawing.Point(173, 10);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(136, 21);
            this.cboPort.TabIndex = 3;
            this.cboPort.SelectedIndexChanged += new System.EventHandler(this.cboPort_SelectedIndexChanged);
            // 
            // chkLot
            // 
            this.chkLot.AutoSize = true;
            this.chkLot.Checked = true;
            this.chkLot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLot.Location = new System.Drawing.Point(337, 16);
            this.chkLot.Name = "chkLot";
            this.chkLot.Size = new System.Drawing.Size(70, 17);
            this.chkLot.TabIndex = 2;
            this.chkLot.Text = "Lot Label";
            this.chkLot.Visible = false;
            this.chkLot.CheckedChanged += new System.EventHandler(this.chkLot_CheckedChanged);
            // 
            // chkRPrint
            // 
            this.chkRPrint.AutoSize = true;
            this.chkRPrint.Location = new System.Drawing.Point(71, 12);
            this.chkRPrint.Name = "chkRPrint";
            this.chkRPrint.Size = new System.Drawing.Size(96, 17);
            this.chkRPrint.TabIndex = 2;
            this.chkRPrint.Text = "Remote Printer";
            this.chkRPrint.CheckedChanged += new System.EventHandler(this.chkRPrint_CheckedChanged);
            // 
            // chkDefaultPrinter
            // 
            this.chkDefaultPrinter.AutoSize = true;
            this.chkDefaultPrinter.Location = new System.Drawing.Point(325, 12);
            this.chkDefaultPrinter.Name = "chkDefaultPrinter";
            this.chkDefaultPrinter.Size = new System.Drawing.Size(93, 17);
            this.chkDefaultPrinter.TabIndex = 10;
            this.chkDefaultPrinter.Text = "Default Printer";
            // 
            // frmPOPTranLotLabelPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmPOPTranLotLabelPrint";
            this.Text = "Print Lot Label";
            this.Activated += new System.EventHandler(this.frmWIPTranShipLot_Activated);
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
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpPrintInfo.ResumeLayout(false);
            this.grpPrintInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLabelID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Event Definition"
        //------------------------------------------
        private Rs232 m_CommPort = new Rs232(); //?대깽?몃? ?꾩옱??Form?먯꽌 諛쏄린?꾪빐?쒕뒗 WithEvent瑜??좎뼵?댁＜?댁빞 ?쒕떎.
        //------------------------------------------
        #endregion
        
        #region "Constant Defintion"
        
        #endregion
        
        #region "Variable Definition"
        
        private bool b_load_flag;
        
        private string[,] PrintData = new string[6, 2];
        string sPrintIP;
        string sUser;
        string sPassword;
        
        #endregion
        
        #region "Function Definition"

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID, cboPort, chkLot);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            GetLabel(LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), s_lot_id);
            return true;
        }
        
        //
        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {
            switch (iStep)
            {
                case 1:

                    MPCF.FieldClear(this, chkLot);
                    ClearLotSpread();
                    break;
            }
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {
            
            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Select();
                return false;
            }

            if (cboPort.Text.Trim() == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cboPort.Select();
                return false;
            }

            return true;
        }
        
        //
        // Update_LotLabel_Print_History()
        //       -   Update Lot Label Print History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Update_LotLabel_Print_History()
        {
            TRSNode in_node = new TRSNode("Update_LotLabel_Print_History_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = 'I';
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddString("ORDER_ID", LOT.GetString("ORDER_ID"));
                in_node.AddString("LABEL_ID", txtLabelID.Text);
                in_node.AddInt("QTY", 1);

                if (MPCR.CallService("POP", "POP_Update_LotLabel_Print_History", in_node, ref out_node) == false)
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
        
        private bool GetLabel(string sMatID, int iMatVer, string sLotID)
        {
            TRSNode in_node = new TRSNode("View_PrintInfo_In");
            TRSNode out_node = new TRSNode("View_PrintInfo_Out");

            
            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("LOT_ID", sLotID);

                if (MPCR.CallService("POP", "POP_View_PrintInfo", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLabelID.Text = out_node.GetString("LABEL_ID").TrimEnd();
                cdvLabelID.Text = out_node.GetString("LABEL_ID").TrimEnd();
                txtLabelDesc.Text = out_node.GetString("LABEL_DESC").TrimEnd();
                txtCustomer.Text = out_node.GetString("CUSTOMER").TrimEnd();
                txtCustomerMatID.Text = out_node.GetString("CUSTOMER_MAT_ID").TrimEnd();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        private bool Fill_PrintDatas(ref TRSNode out_node)
        {
            
            int i;
            int j;
            bool bFind = false;
            
            try
            {
                for (i = 0; i < PrintData.GetLength(0); i++)
                {
                    for (j = 0; j < PrintData.GetLength(1); j++)
                    {
                        PrintData[i, j] = " ";
                    }
                }
                
                PrintData[0, 0] = "LOT_ID";
                PrintData[0, 1] = txtLotID.Text.TrimEnd();
                
                PrintData[1, 0] = "MAT_ID";
                PrintData[1, 1] = LOT.GetString("MAT_ID");
                
                PrintData[2, 0] = "ORDER_ID";
                PrintData[2, 1] = LOT.GetString("ORDER_ID");
                
                PrintData[3, 0] = "CUSTOMER_MAT_ID";
                PrintData[3, 1] = txtCustomerMatID.Text.TrimEnd();
                
                PrintData[4, 0] = "CUSTOMER";
                PrintData[4, 1] = txtCustomer.Text.TrimEnd();
                
                PrintData[5, 0] = "MAT_DESC";
                PrintData[5, 1] = LOT.GetString("MAT_DESC");

                TRSNode item_list;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    item_list = out_node.GetList(0)[i];

                    if (item_list.GetChar("VARIABLE_FLAG") == 'Y')
                    {
                        
                        bFind = true;
                        
                        for (j = 0; j <= (PrintData.Length/2 - 1); j++)
                        {
                            if (MPCF.Trim(item_list.GetString("DATA")) == PrintData[j, 0].TrimEnd())
                            {
                                item_list.AddString("DATA" , PrintData[j, 1]);
                                bFind = true;
                                break;
                            }
                        }
                        
                        if (bFind == false)
                        {
                            return false;
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
        
        #endregion
        
        private void frmWIPTranShipLot_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                ClearData(1);

                chkDefaultPrinter.Enabled = false;
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                
                b_load_flag = true;
                
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("View_Label_Design_Out");            
            
            try
            {
                if (CheckCondition() == true)
                {
                    if (txtLabelID.Visible == true)
                    {
                        if (modPOPPrint.GetPrintInformation(txtLabelID.Text, txtLotID.Text, ref  out_node) == false)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (modPOPPrint.GetPrintInformation(cdvLabelID.Text, txtLotID.Text, ref  out_node) == false)
                        {
                            return;
                        }
                    }
                    /* Winspool.drv Win32 API를 이용하여, LPT나 COM등의 '포트'가 아닌, 특정 Printer Name에 ZPL Command raw data를 직접 전달 하는 방식 추가 */
                    if (MPCF.Mid(cboPort.Text, 0, 3) == modPOPPrint.POP_PRINT_PORT_SPOOL)
                    {
                        if (chkDefaultPrinter.Checked == true)
                        {
                            /* Zebra Printer 가 기본 프린터로 설정된 경우, 해당 프린터 Name을 가져옴 */
                            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                            modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                        }
                        else
                        {
                            // Allow the user to select a printer.
                            /* 기본 프린터로 설정되어 있지 않은 경우, Printer 선택 창을 띄어 사용자가 선택 하게 함. */
                            PrintDialog pd = new PrintDialog();
                            pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                            if (DialogResult.OK == pd.ShowDialog(this))
                            {
                                modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                            }
                        }
                    }

                    if (chkLot.Checked == true)
                    {
                        if (MPCF.Trim(out_node.GetString("LABEL_COMMAND")) != "")
                        {
                            if (modPOPPrint.ExcutePrintCommand(cboPort.Text, m_CommPort, out_node.GetString("LABEL_COMMAND"), chkRPrint.Checked, sPrintIP, sUser, sPassword) == false)
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (Fill_PrintDatas(ref out_node) == false)
                            {
                                return;
                            }

                            if (out_node.GetString("PRINTER_TYPE").Equals(modPOPPrint.POP_PRINT_TYPE_TPCL))
                            {
                                if (modPOPPrint.ExcutePrint(cboPort.Text, m_CommPort, ref out_node, modPOPPrint.POP_PRINT_TYPE_TPCL) == false)
                                    return;
                            }
                            else
                            {
                                if (modPOPPrint.ExcutePrint(cboPort.Text, m_CommPort, ref out_node) == false)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (modPOPPrint.ExcutePrintCommand(cboPort.Text, m_CommPort, out_node.GetString("LABEL_COMMAND"), chkRPrint.Checked, sPrintIP, sUser, sPassword) == false)
                        {
                            return;
                        }
                    }
                    
                    if (Update_LotLabel_Print_History() == false)
                    {
                        return;
                    }

                    txtLotID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkRPrint.Checked == true && cboPort.Text.Trim() != "")
            {
                try
                {
                    TRSNode in_node = new TRSNode("View_Data_In");
                    TRSNode out_node = new TRSNode("View_Data_Out");

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", "LABEL_PRINTER");
                    in_node.AddString("KEY_1", cboPort.Text);

                    if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    sPrintIP = MPCF.Trim(out_node.GetString("DATA_2"));
                    sUser = MPCF.Trim(out_node.GetString("DATA_3"));
                    sPassword = MPCF.Trim(out_node.GetString("DATA_4"));
                    return;
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox("frmPOPSetupLabelDesign.View_Data()\n" + ex.Message);
                    return;
                }
            }

            if (MPCF.Mid(cboPort.Text, 0, 3) == modPOPPrint.POP_PRINT_PORT_SPOOL)
            {
                chkDefaultPrinter.Enabled = true;
            }
            else
            {
                chkDefaultPrinter.Enabled = false;
            }
        }

        private void chkRPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRPrint.Checked == true)
            {
                cboPort.Items.Clear();

                if (BASLIST.ViewGCMDataList(cboPort, '1', "LABEL_PRINTER") == false)
                {
                    return;
                }
            }
            else
            {
                cboPort.Items.Clear();

                cboPort.Items.Add("SPOOL");
                cboPort.Items.Add("LPT1");
                cboPort.Items.Add("LPT2");
                cboPort.Items.Add("COM1");
                cboPort.Items.Add("COM2");
                cboPort.Items.Add("COM3");
                cboPort.Items.Add("COM4");
                cboPort.Items.Add("COM5");
                cboPort.Items.Add("COM6");
                cboPort.Items.Add("COM7");
                cboPort.Items.Add("COM8");
            }
        }

        private void chkLot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLot.Checked == true)
            {
                cdvLabelID.Visible = false;
                txtLabelID.Visible = true;
            }
            else
            {
                cdvLabelID.Visible = true;
                txtLabelID.Visible = false;
            }
        }

        private void cdvLabelID_ButtonPress(object sender, EventArgs e)
        {
            cdvLabelID.Init();
            MPCF.InitListView(cdvLabelID.GetListView);
            cdvLabelID.Columns.Add("Label", 100, HorizontalAlignment.Left);
            cdvLabelID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLabelID.SelectedSubItemIndex = 0;
            cdvLabelID.DisplaySubItemIndex = 0;
            POPLIST.ViewLabelList(cdvLabelID.GetListView, '1', "", 0, "", null, "");
        }
    }
    //#End If
}
