
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipSetupFactory.vb
//   Description : MES Cient Form Factory Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//        - View_Factory() : View Factory Infor
//        - Update_Factory() : Update Factory Infor
//        - Get_FacCmf_Data() : Get FacCmf Data
//        - Update_Factory_Cmf() : Update Factory Customized Field Value
//        - View_Ship_Factory() : View Shipping Factory Infor
//        - Update_Ship_Factory() : Update Shipping Factory Infor
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by CM Koo
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
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Miracom.CliFrx;
using Miracom.TRSCore;



namespace Miracom.WIPCore
{
    public class frmWIPSetupFactory : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupFactory()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.TabControl tabFactory;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlShipFacDef;
        private System.Windows.Forms.GroupBox grpFac;
        private MCCodeView cdvToFactory;
        private System.Windows.Forms.CheckBox chkTerminate;
        private System.Windows.Forms.Label lblTransitOper;
        private System.Windows.Forms.Label lblShippingFac;
        private System.Windows.Forms.Panel pnlShipFacList;
        private Miracom.UI.Controls.MCListView.MCListView lisShipFac;
        private System.Windows.Forms.ColumnHeader colToFac;
        private System.Windows.Forms.ColumnHeader colIntranOper;
        private System.Windows.Forms.GroupBox grpFactory;
        private System.Windows.Forms.TextBox txtFactoryDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblFacName;
        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Panel pnlFacMid;
        private System.Windows.Forms.Panel pnlFacTop;
        private System.Windows.Forms.TabPage tbpShipFac;
        private System.Windows.Forms.GroupBox grpResSts;
        private System.Windows.Forms.TextBox txtResSts10;
        private System.Windows.Forms.TextBox txtResSts9;
        private System.Windows.Forms.TextBox txtResSts8;
        private System.Windows.Forms.TextBox txtResSts7;
        private System.Windows.Forms.TextBox txtResSts6;
        private System.Windows.Forms.Label lblEquipPrompt10;
        private System.Windows.Forms.Label lblEquipPrompt9;
        private System.Windows.Forms.Label lblEquipPrompt8;
        private System.Windows.Forms.Label lblEquipPrompt7;
        private System.Windows.Forms.Label lblEquipPrompt6;
        private System.Windows.Forms.TextBox txtResSts5;
        private System.Windows.Forms.TextBox txtResSts4;
        private System.Windows.Forms.TextBox txtResSts3;
        private System.Windows.Forms.TextBox txtResSts2;
        private System.Windows.Forms.TextBox txtResSts1;
        private System.Windows.Forms.Label lblEquipPrompt5;
        private System.Windows.Forms.Label lblEquipPrompt4;
        private System.Windows.Forms.Label lblEquipPrompt3;
        private System.Windows.Forms.Label lblEquipPrompt2;
        private System.Windows.Forms.Label lblEquipPrompt1;
        private System.Windows.Forms.Panel pnlGenTop;
        private System.Windows.Forms.Panel pnlGenMid;
        private System.Windows.Forms.Panel pnlGenTopLeft;
        private System.Windows.Forms.GroupBox grpProperties;
        private MCCodeView cdvFactoryType;
        private System.Windows.Forms.CheckBox chkRemoteFac;
        private System.Windows.Forms.TextBox txtDaysPerWeek;
        private System.Windows.Forms.Label lblHoursPerDay;
        private System.Windows.Forms.Label lblDaysPerWeek;
        private System.Windows.Forms.Label lblFactoryType;
        private System.Windows.Forms.Panel pnlGenTopMid;
        private System.Windows.Forms.GroupBox grpFactoryGrp;
        private System.Windows.Forms.TextBox txtFactoryGrp5;
        private System.Windows.Forms.TextBox txtFactoryGrp4;
        private System.Windows.Forms.TextBox txtFactoryGrp3;
        private System.Windows.Forms.TextBox txtFactoryGrp2;
        private System.Windows.Forms.TextBox txtFactoryGrp1;
        private System.Windows.Forms.Label lblFactoryGrp5;
        private System.Windows.Forms.Label lblFactoryGrp4;
        private System.Windows.Forms.Label lblFactoryGrp3;
        private System.Windows.Forms.Label lblFactoryGrp2;
        private System.Windows.Forms.Label lblFactoryGrp1;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private MCCodeView cdvTransitOper;
        private System.Windows.Forms.Splitter sptShipFactory;
        private System.Windows.Forms.ContextMenu ctxSpread;
        private System.Windows.Forms.GroupBox grpShift;
        private MCCodeView cdvShift4;
        private MCCodeView cdvShift3;
        private MCCodeView cdvShift2;
        private MCCodeView cdvShift1;
        private System.Windows.Forms.CheckBox chkVariable;
        private System.Windows.Forms.Label lblShift4Day;
        private System.Windows.Forms.Label lblShift3Day;
        private System.Windows.Forms.Label lblShift2Day;
        private System.Windows.Forms.Label lblShift1Day;
        private System.Windows.Forms.TextBox txtShift4Start;
        private System.Windows.Forms.TextBox txtShift3Start;
        private System.Windows.Forms.TextBox txtShift2Start;
        private System.Windows.Forms.TextBox txtShift1Start;
        private System.Windows.Forms.Label lblShift4Start;
        private System.Windows.Forms.Label lblShift3Start;
        private System.Windows.Forms.Label lblShift2Start;
        private System.Windows.Forms.Label lblShift1Start;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtHoursPerDay;
        private System.Windows.Forms.Button btnRefresh;
        private CheckBox chkRemote;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupFactory));
            this.pnlFacMid = new System.Windows.Forms.Panel();
            this.tabFactory = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGenMid = new System.Windows.Forms.Panel();
            this.grpShift = new System.Windows.Forms.GroupBox();
            this.lblShift4Start = new System.Windows.Forms.Label();
            this.lblShift3Start = new System.Windows.Forms.Label();
            this.lblShift2Start = new System.Windows.Forms.Label();
            this.lblShift1Start = new System.Windows.Forms.Label();
            this.cdvShift4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvShift3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvShift2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvShift1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkVariable = new System.Windows.Forms.CheckBox();
            this.lblShift4Day = new System.Windows.Forms.Label();
            this.lblShift3Day = new System.Windows.Forms.Label();
            this.lblShift2Day = new System.Windows.Forms.Label();
            this.lblShift1Day = new System.Windows.Forms.Label();
            this.txtShift4Start = new System.Windows.Forms.TextBox();
            this.txtShift3Start = new System.Windows.Forms.TextBox();
            this.txtShift2Start = new System.Windows.Forms.TextBox();
            this.txtShift1Start = new System.Windows.Forms.TextBox();
            this.pnlGenTop = new System.Windows.Forms.Panel();
            this.pnlGenTopMid = new System.Windows.Forms.Panel();
            this.grpFactoryGrp = new System.Windows.Forms.GroupBox();
            this.txtFactoryGrp5 = new System.Windows.Forms.TextBox();
            this.txtFactoryGrp4 = new System.Windows.Forms.TextBox();
            this.txtFactoryGrp3 = new System.Windows.Forms.TextBox();
            this.txtFactoryGrp2 = new System.Windows.Forms.TextBox();
            this.txtFactoryGrp1 = new System.Windows.Forms.TextBox();
            this.lblFactoryGrp5 = new System.Windows.Forms.Label();
            this.lblFactoryGrp4 = new System.Windows.Forms.Label();
            this.lblFactoryGrp3 = new System.Windows.Forms.Label();
            this.lblFactoryGrp2 = new System.Windows.Forms.Label();
            this.lblFactoryGrp1 = new System.Windows.Forms.Label();
            this.pnlGenTopLeft = new System.Windows.Forms.Panel();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.txtHoursPerDay = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cdvFactoryType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkRemoteFac = new System.Windows.Forms.CheckBox();
            this.txtDaysPerWeek = new System.Windows.Forms.TextBox();
            this.lblHoursPerDay = new System.Windows.Forms.Label();
            this.lblDaysPerWeek = new System.Windows.Forms.Label();
            this.lblFactoryType = new System.Windows.Forms.Label();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.grpResSts = new System.Windows.Forms.GroupBox();
            this.txtResSts10 = new System.Windows.Forms.TextBox();
            this.txtResSts9 = new System.Windows.Forms.TextBox();
            this.txtResSts8 = new System.Windows.Forms.TextBox();
            this.txtResSts7 = new System.Windows.Forms.TextBox();
            this.txtResSts6 = new System.Windows.Forms.TextBox();
            this.lblEquipPrompt10 = new System.Windows.Forms.Label();
            this.lblEquipPrompt9 = new System.Windows.Forms.Label();
            this.lblEquipPrompt8 = new System.Windows.Forms.Label();
            this.lblEquipPrompt7 = new System.Windows.Forms.Label();
            this.lblEquipPrompt6 = new System.Windows.Forms.Label();
            this.txtResSts5 = new System.Windows.Forms.TextBox();
            this.txtResSts4 = new System.Windows.Forms.TextBox();
            this.txtResSts3 = new System.Windows.Forms.TextBox();
            this.txtResSts2 = new System.Windows.Forms.TextBox();
            this.txtResSts1 = new System.Windows.Forms.TextBox();
            this.lblEquipPrompt5 = new System.Windows.Forms.Label();
            this.lblEquipPrompt4 = new System.Windows.Forms.Label();
            this.lblEquipPrompt3 = new System.Windows.Forms.Label();
            this.lblEquipPrompt2 = new System.Windows.Forms.Label();
            this.lblEquipPrompt1 = new System.Windows.Forms.Label();
            this.tbpShipFac = new System.Windows.Forms.TabPage();
            this.sptShipFactory = new System.Windows.Forms.Splitter();
            this.pnlShipFacDef = new System.Windows.Forms.Panel();
            this.grpFac = new System.Windows.Forms.GroupBox();
            this.cdvTransitOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.cdvToFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkRemote = new System.Windows.Forms.CheckBox();
            this.chkTerminate = new System.Windows.Forms.CheckBox();
            this.lblTransitOper = new System.Windows.Forms.Label();
            this.lblShippingFac = new System.Windows.Forms.Label();
            this.pnlShipFacList = new System.Windows.Forms.Panel();
            this.lisShipFac = new Miracom.UI.Controls.MCListView.MCListView();
            this.colToFac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIntranOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFacTop = new System.Windows.Forms.Panel();
            this.grpFactory = new System.Windows.Forms.GroupBox();
            this.txtFactoryDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblFacName = new System.Windows.Forms.Label();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.ctxSpread = new System.Windows.Forms.ContextMenu();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFacMid.SuspendLayout();
            this.tabFactory.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGenMid.SuspendLayout();
            this.grpShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift1)).BeginInit();
            this.pnlGenTop.SuspendLayout();
            this.pnlGenTopMid.SuspendLayout();
            this.grpFactoryGrp.SuspendLayout();
            this.pnlGenTopLeft.SuspendLayout();
            this.grpProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoursPerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactoryType)).BeginInit();
            this.tbpResource.SuspendLayout();
            this.grpResSts.SuspendLayout();
            this.tbpShipFac.SuspendLayout();
            this.pnlShipFacDef.SuspendLayout();
            this.grpFac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTransitOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).BeginInit();
            this.pnlShipFacList.SuspendLayout();
            this.pnlFacTop.SuspendLayout();
            this.grpFactory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlFacMid);
            this.pnlCenter.Controls.Add(this.pnlFacTop);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            this.pnlCenter.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // pnlFacMid
            // 
            this.pnlFacMid.Controls.Add(this.tabFactory);
            this.pnlFacMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFacMid.Location = new System.Drawing.Point(0, 74);
            this.pnlFacMid.Name = "pnlFacMid";
            this.pnlFacMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlFacMid.Size = new System.Drawing.Size(742, 439);
            this.pnlFacMid.TabIndex = 1;
            // 
            // tabFactory
            // 
            this.tabFactory.Controls.Add(this.tbpGeneral);
            this.tabFactory.Controls.Add(this.tbpResource);
            this.tabFactory.Controls.Add(this.tbpShipFac);
            this.tabFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFactory.ItemSize = new System.Drawing.Size(60, 18);
            this.tabFactory.Location = new System.Drawing.Point(3, 3);
            this.tabFactory.Name = "tabFactory";
            this.tabFactory.SelectedIndex = 0;
            this.tabFactory.Size = new System.Drawing.Size(736, 436);
            this.tabFactory.TabIndex = 0;
            this.tabFactory.SelectedIndexChanged += new System.EventHandler(this.tabFactory_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGenMid);
            this.tbpGeneral.Controls.Add(this.pnlGenTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 410);
            this.tbpGeneral.TabIndex = 5;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGenMid
            // 
            this.pnlGenMid.Controls.Add(this.grpShift);
            this.pnlGenMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenMid.Location = new System.Drawing.Point(0, 156);
            this.pnlGenMid.Name = "pnlGenMid";
            this.pnlGenMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlGenMid.Size = new System.Drawing.Size(728, 254);
            this.pnlGenMid.TabIndex = 1;
            // 
            // grpShift
            // 
            this.grpShift.Controls.Add(this.lblShift4Start);
            this.grpShift.Controls.Add(this.lblShift3Start);
            this.grpShift.Controls.Add(this.lblShift2Start);
            this.grpShift.Controls.Add(this.lblShift1Start);
            this.grpShift.Controls.Add(this.cdvShift4);
            this.grpShift.Controls.Add(this.cdvShift3);
            this.grpShift.Controls.Add(this.cdvShift2);
            this.grpShift.Controls.Add(this.cdvShift1);
            this.grpShift.Controls.Add(this.chkVariable);
            this.grpShift.Controls.Add(this.lblShift4Day);
            this.grpShift.Controls.Add(this.lblShift3Day);
            this.grpShift.Controls.Add(this.lblShift2Day);
            this.grpShift.Controls.Add(this.lblShift1Day);
            this.grpShift.Controls.Add(this.txtShift4Start);
            this.grpShift.Controls.Add(this.txtShift3Start);
            this.grpShift.Controls.Add(this.txtShift2Start);
            this.grpShift.Controls.Add(this.txtShift1Start);
            this.grpShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpShift.Location = new System.Drawing.Point(3, 3);
            this.grpShift.Name = "grpShift";
            this.grpShift.Size = new System.Drawing.Size(722, 248);
            this.grpShift.TabIndex = 0;
            this.grpShift.TabStop = false;
            this.grpShift.Text = "Shifts Definition";
            // 
            // lblShift4Start
            // 
            this.lblShift4Start.AutoSize = true;
            this.lblShift4Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift4Start.Location = new System.Drawing.Point(380, 123);
            this.lblShift4Start.Name = "lblShift4Start";
            this.lblShift4Start.Size = new System.Drawing.Size(65, 13);
            this.lblShift4Start.TabIndex = 15;
            this.lblShift4Start.Text = "Shift 4  Start";
            // 
            // lblShift3Start
            // 
            this.lblShift3Start.AutoSize = true;
            this.lblShift3Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift3Start.Location = new System.Drawing.Point(380, 99);
            this.lblShift3Start.Name = "lblShift3Start";
            this.lblShift3Start.Size = new System.Drawing.Size(65, 13);
            this.lblShift3Start.TabIndex = 11;
            this.lblShift3Start.Text = "Shift 3  Start";
            // 
            // lblShift2Start
            // 
            this.lblShift2Start.AutoSize = true;
            this.lblShift2Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift2Start.Location = new System.Drawing.Point(380, 75);
            this.lblShift2Start.Name = "lblShift2Start";
            this.lblShift2Start.Size = new System.Drawing.Size(65, 13);
            this.lblShift2Start.TabIndex = 7;
            this.lblShift2Start.Text = "Shift 2  Start";
            // 
            // lblShift1Start
            // 
            this.lblShift1Start.AutoSize = true;
            this.lblShift1Start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift1Start.Location = new System.Drawing.Point(380, 51);
            this.lblShift1Start.Name = "lblShift1Start";
            this.lblShift1Start.Size = new System.Drawing.Size(65, 13);
            this.lblShift1Start.TabIndex = 3;
            this.lblShift1Start.Text = "Shift 1  Start";
            // 
            // cdvShift4
            // 
            this.cdvShift4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift4.BtnToolTipText = "";
            this.cdvShift4.DescText = "";
            this.cdvShift4.DisplaySubItemIndex = -1;
            this.cdvShift4.DisplayText = "";
            this.cdvShift4.Focusing = null;
            this.cdvShift4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift4.Index = 0;
            this.cdvShift4.IsViewBtnImage = false;
            this.cdvShift4.Location = new System.Drawing.Point(146, 120);
            this.cdvShift4.MaxLength = 1;
            this.cdvShift4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift4.Name = "cdvShift4";
            this.cdvShift4.ReadOnly = false;
            this.cdvShift4.SearchSubItemIndex = 0;
            this.cdvShift4.SelectedDescIndex = -1;
            this.cdvShift4.SelectedSubItemIndex = -1;
            this.cdvShift4.SelectionStart = 0;
            this.cdvShift4.Size = new System.Drawing.Size(195, 20);
            this.cdvShift4.SmallImageList = null;
            this.cdvShift4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift4.TabIndex = 14;
            this.cdvShift4.TextBoxToolTipText = "";
            this.cdvShift4.TextBoxWidth = 195;
            this.cdvShift4.VisibleButton = true;
            this.cdvShift4.VisibleColumnHeader = false;
            this.cdvShift4.VisibleDescription = false;
            this.cdvShift4.TextBoxTextChanged += new System.EventHandler(this.cdvShift4_TextBoxTextChanged);
            // 
            // cdvShift3
            // 
            this.cdvShift3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift3.BtnToolTipText = "";
            this.cdvShift3.DescText = "";
            this.cdvShift3.DisplaySubItemIndex = -1;
            this.cdvShift3.DisplayText = "";
            this.cdvShift3.Focusing = null;
            this.cdvShift3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift3.Index = 0;
            this.cdvShift3.IsViewBtnImage = false;
            this.cdvShift3.Location = new System.Drawing.Point(146, 96);
            this.cdvShift3.MaxLength = 1;
            this.cdvShift3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift3.Name = "cdvShift3";
            this.cdvShift3.ReadOnly = false;
            this.cdvShift3.SearchSubItemIndex = 0;
            this.cdvShift3.SelectedDescIndex = -1;
            this.cdvShift3.SelectedSubItemIndex = -1;
            this.cdvShift3.SelectionStart = 0;
            this.cdvShift3.Size = new System.Drawing.Size(195, 20);
            this.cdvShift3.SmallImageList = null;
            this.cdvShift3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift3.TabIndex = 10;
            this.cdvShift3.TextBoxToolTipText = "";
            this.cdvShift3.TextBoxWidth = 195;
            this.cdvShift3.VisibleButton = true;
            this.cdvShift3.VisibleColumnHeader = false;
            this.cdvShift3.VisibleDescription = false;
            this.cdvShift3.TextBoxTextChanged += new System.EventHandler(this.cdvShift3_TextBoxTextChanged);
            // 
            // cdvShift2
            // 
            this.cdvShift2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift2.BtnToolTipText = "";
            this.cdvShift2.DescText = "";
            this.cdvShift2.DisplaySubItemIndex = -1;
            this.cdvShift2.DisplayText = "";
            this.cdvShift2.Focusing = null;
            this.cdvShift2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift2.Index = 0;
            this.cdvShift2.IsViewBtnImage = false;
            this.cdvShift2.Location = new System.Drawing.Point(146, 72);
            this.cdvShift2.MaxLength = 1;
            this.cdvShift2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift2.Name = "cdvShift2";
            this.cdvShift2.ReadOnly = false;
            this.cdvShift2.SearchSubItemIndex = 0;
            this.cdvShift2.SelectedDescIndex = -1;
            this.cdvShift2.SelectedSubItemIndex = -1;
            this.cdvShift2.SelectionStart = 0;
            this.cdvShift2.Size = new System.Drawing.Size(195, 20);
            this.cdvShift2.SmallImageList = null;
            this.cdvShift2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift2.TabIndex = 6;
            this.cdvShift2.TextBoxToolTipText = "";
            this.cdvShift2.TextBoxWidth = 195;
            this.cdvShift2.VisibleButton = true;
            this.cdvShift2.VisibleColumnHeader = false;
            this.cdvShift2.VisibleDescription = false;
            this.cdvShift2.TextBoxTextChanged += new System.EventHandler(this.cdvShift2_TextBoxTextChanged);
            // 
            // cdvShift1
            // 
            this.cdvShift1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift1.BtnToolTipText = "";
            this.cdvShift1.DescText = "";
            this.cdvShift1.DisplaySubItemIndex = -1;
            this.cdvShift1.DisplayText = "";
            this.cdvShift1.Focusing = null;
            this.cdvShift1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift1.Index = 0;
            this.cdvShift1.IsViewBtnImage = false;
            this.cdvShift1.Location = new System.Drawing.Point(146, 48);
            this.cdvShift1.MaxLength = 1;
            this.cdvShift1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift1.Name = "cdvShift1";
            this.cdvShift1.ReadOnly = false;
            this.cdvShift1.SearchSubItemIndex = 0;
            this.cdvShift1.SelectedDescIndex = -1;
            this.cdvShift1.SelectedSubItemIndex = -1;
            this.cdvShift1.SelectionStart = 0;
            this.cdvShift1.Size = new System.Drawing.Size(195, 20);
            this.cdvShift1.SmallImageList = null;
            this.cdvShift1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift1.TabIndex = 2;
            this.cdvShift1.TextBoxToolTipText = "";
            this.cdvShift1.TextBoxWidth = 195;
            this.cdvShift1.VisibleButton = true;
            this.cdvShift1.VisibleColumnHeader = false;
            this.cdvShift1.VisibleDescription = false;
            // 
            // chkVariable
            // 
            this.chkVariable.AutoSize = true;
            this.chkVariable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkVariable.Location = new System.Drawing.Point(18, 28);
            this.chkVariable.Name = "chkVariable";
            this.chkVariable.Size = new System.Drawing.Size(94, 18);
            this.chkVariable.TabIndex = 0;
            this.chkVariable.Text = "Variable Shift";
            this.chkVariable.CheckedChanged += new System.EventHandler(this.chkVariable_CheckedChanged);
            // 
            // lblShift4Day
            // 
            this.lblShift4Day.AutoSize = true;
            this.lblShift4Day.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift4Day.Location = new System.Drawing.Point(18, 123);
            this.lblShift4Day.Name = "lblShift4Day";
            this.lblShift4Day.Size = new System.Drawing.Size(62, 13);
            this.lblShift4Day.TabIndex = 13;
            this.lblShift4Day.Text = "Shift 4  Day";
            // 
            // lblShift3Day
            // 
            this.lblShift3Day.AutoSize = true;
            this.lblShift3Day.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift3Day.Location = new System.Drawing.Point(18, 99);
            this.lblShift3Day.Name = "lblShift3Day";
            this.lblShift3Day.Size = new System.Drawing.Size(62, 13);
            this.lblShift3Day.TabIndex = 9;
            this.lblShift3Day.Text = "Shift 3  Day";
            // 
            // lblShift2Day
            // 
            this.lblShift2Day.AutoSize = true;
            this.lblShift2Day.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift2Day.Location = new System.Drawing.Point(18, 75);
            this.lblShift2Day.Name = "lblShift2Day";
            this.lblShift2Day.Size = new System.Drawing.Size(62, 13);
            this.lblShift2Day.TabIndex = 5;
            this.lblShift2Day.Text = "Shift 2  Day";
            // 
            // lblShift1Day
            // 
            this.lblShift1Day.AutoSize = true;
            this.lblShift1Day.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift1Day.Location = new System.Drawing.Point(18, 51);
            this.lblShift1Day.Name = "lblShift1Day";
            this.lblShift1Day.Size = new System.Drawing.Size(62, 13);
            this.lblShift1Day.TabIndex = 1;
            this.lblShift1Day.Text = "Shift 1  Day";
            // 
            // txtShift4Start
            // 
            this.txtShift4Start.Location = new System.Drawing.Point(510, 120);
            this.txtShift4Start.MaxLength = 4;
            this.txtShift4Start.Name = "txtShift4Start";
            this.txtShift4Start.Size = new System.Drawing.Size(195, 20);
            this.txtShift4Start.TabIndex = 16;
            this.txtShift4Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShift4Start_KeyPress);
            // 
            // txtShift3Start
            // 
            this.txtShift3Start.Location = new System.Drawing.Point(510, 96);
            this.txtShift3Start.MaxLength = 4;
            this.txtShift3Start.Name = "txtShift3Start";
            this.txtShift3Start.Size = new System.Drawing.Size(195, 20);
            this.txtShift3Start.TabIndex = 12;
            this.txtShift3Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShift3Start_KeyPress);
            // 
            // txtShift2Start
            // 
            this.txtShift2Start.Location = new System.Drawing.Point(510, 72);
            this.txtShift2Start.MaxLength = 4;
            this.txtShift2Start.Name = "txtShift2Start";
            this.txtShift2Start.Size = new System.Drawing.Size(195, 20);
            this.txtShift2Start.TabIndex = 8;
            this.txtShift2Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShift2Start_KeyPress);
            // 
            // txtShift1Start
            // 
            this.txtShift1Start.Location = new System.Drawing.Point(510, 48);
            this.txtShift1Start.MaxLength = 4;
            this.txtShift1Start.Name = "txtShift1Start";
            this.txtShift1Start.Size = new System.Drawing.Size(195, 20);
            this.txtShift1Start.TabIndex = 4;
            this.txtShift1Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShift1Start_KeyPress);
            // 
            // pnlGenTop
            // 
            this.pnlGenTop.Controls.Add(this.pnlGenTopMid);
            this.pnlGenTop.Controls.Add(this.pnlGenTopLeft);
            this.pnlGenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGenTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGenTop.Name = "pnlGenTop";
            this.pnlGenTop.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlGenTop.Size = new System.Drawing.Size(728, 156);
            this.pnlGenTop.TabIndex = 0;
            // 
            // pnlGenTopMid
            // 
            this.pnlGenTopMid.Controls.Add(this.grpFactoryGrp);
            this.pnlGenTopMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenTopMid.Location = new System.Drawing.Point(366, 5);
            this.pnlGenTopMid.Name = "pnlGenTopMid";
            this.pnlGenTopMid.Size = new System.Drawing.Size(359, 148);
            this.pnlGenTopMid.TabIndex = 1;
            // 
            // grpFactoryGrp
            // 
            this.grpFactoryGrp.Controls.Add(this.txtFactoryGrp5);
            this.grpFactoryGrp.Controls.Add(this.txtFactoryGrp4);
            this.grpFactoryGrp.Controls.Add(this.txtFactoryGrp3);
            this.grpFactoryGrp.Controls.Add(this.txtFactoryGrp2);
            this.grpFactoryGrp.Controls.Add(this.txtFactoryGrp1);
            this.grpFactoryGrp.Controls.Add(this.lblFactoryGrp5);
            this.grpFactoryGrp.Controls.Add(this.lblFactoryGrp4);
            this.grpFactoryGrp.Controls.Add(this.lblFactoryGrp3);
            this.grpFactoryGrp.Controls.Add(this.lblFactoryGrp2);
            this.grpFactoryGrp.Controls.Add(this.lblFactoryGrp1);
            this.grpFactoryGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFactoryGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFactoryGrp.Location = new System.Drawing.Point(0, 0);
            this.grpFactoryGrp.Name = "grpFactoryGrp";
            this.grpFactoryGrp.Size = new System.Drawing.Size(359, 148);
            this.grpFactoryGrp.TabIndex = 0;
            this.grpFactoryGrp.TabStop = false;
            this.grpFactoryGrp.Text = "Factory Group (1~5)";
            // 
            // txtFactoryGrp5
            // 
            this.txtFactoryGrp5.Location = new System.Drawing.Point(146, 112);
            this.txtFactoryGrp5.MaxLength = 30;
            this.txtFactoryGrp5.Name = "txtFactoryGrp5";
            this.txtFactoryGrp5.Size = new System.Drawing.Size(195, 20);
            this.txtFactoryGrp5.TabIndex = 9;
            // 
            // txtFactoryGrp4
            // 
            this.txtFactoryGrp4.Location = new System.Drawing.Point(146, 88);
            this.txtFactoryGrp4.MaxLength = 30;
            this.txtFactoryGrp4.Name = "txtFactoryGrp4";
            this.txtFactoryGrp4.Size = new System.Drawing.Size(195, 20);
            this.txtFactoryGrp4.TabIndex = 7;
            // 
            // txtFactoryGrp3
            // 
            this.txtFactoryGrp3.Location = new System.Drawing.Point(146, 64);
            this.txtFactoryGrp3.MaxLength = 30;
            this.txtFactoryGrp3.Name = "txtFactoryGrp3";
            this.txtFactoryGrp3.Size = new System.Drawing.Size(195, 20);
            this.txtFactoryGrp3.TabIndex = 5;
            // 
            // txtFactoryGrp2
            // 
            this.txtFactoryGrp2.Location = new System.Drawing.Point(146, 40);
            this.txtFactoryGrp2.MaxLength = 30;
            this.txtFactoryGrp2.Name = "txtFactoryGrp2";
            this.txtFactoryGrp2.Size = new System.Drawing.Size(195, 20);
            this.txtFactoryGrp2.TabIndex = 3;
            // 
            // txtFactoryGrp1
            // 
            this.txtFactoryGrp1.Location = new System.Drawing.Point(146, 16);
            this.txtFactoryGrp1.MaxLength = 30;
            this.txtFactoryGrp1.Name = "txtFactoryGrp1";
            this.txtFactoryGrp1.Size = new System.Drawing.Size(195, 20);
            this.txtFactoryGrp1.TabIndex = 1;
            // 
            // lblFactoryGrp5
            // 
            this.lblFactoryGrp5.AutoSize = true;
            this.lblFactoryGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryGrp5.Location = new System.Drawing.Point(18, 115);
            this.lblFactoryGrp5.Name = "lblFactoryGrp5";
            this.lblFactoryGrp5.Size = new System.Drawing.Size(45, 13);
            this.lblFactoryGrp5.TabIndex = 8;
            this.lblFactoryGrp5.Text = "Group 5";
            // 
            // lblFactoryGrp4
            // 
            this.lblFactoryGrp4.AutoSize = true;
            this.lblFactoryGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryGrp4.Location = new System.Drawing.Point(18, 91);
            this.lblFactoryGrp4.Name = "lblFactoryGrp4";
            this.lblFactoryGrp4.Size = new System.Drawing.Size(45, 13);
            this.lblFactoryGrp4.TabIndex = 6;
            this.lblFactoryGrp4.Text = "Group 4";
            // 
            // lblFactoryGrp3
            // 
            this.lblFactoryGrp3.AutoSize = true;
            this.lblFactoryGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryGrp3.Location = new System.Drawing.Point(18, 67);
            this.lblFactoryGrp3.Name = "lblFactoryGrp3";
            this.lblFactoryGrp3.Size = new System.Drawing.Size(45, 13);
            this.lblFactoryGrp3.TabIndex = 4;
            this.lblFactoryGrp3.Text = "Group 3";
            // 
            // lblFactoryGrp2
            // 
            this.lblFactoryGrp2.AutoSize = true;
            this.lblFactoryGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryGrp2.Location = new System.Drawing.Point(18, 43);
            this.lblFactoryGrp2.Name = "lblFactoryGrp2";
            this.lblFactoryGrp2.Size = new System.Drawing.Size(45, 13);
            this.lblFactoryGrp2.TabIndex = 2;
            this.lblFactoryGrp2.Text = "Group 2";
            // 
            // lblFactoryGrp1
            // 
            this.lblFactoryGrp1.AutoSize = true;
            this.lblFactoryGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryGrp1.Location = new System.Drawing.Point(18, 19);
            this.lblFactoryGrp1.Name = "lblFactoryGrp1";
            this.lblFactoryGrp1.Size = new System.Drawing.Size(45, 13);
            this.lblFactoryGrp1.TabIndex = 0;
            this.lblFactoryGrp1.Text = "Group 1";
            // 
            // pnlGenTopLeft
            // 
            this.pnlGenTopLeft.Controls.Add(this.grpProperties);
            this.pnlGenTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGenTopLeft.Location = new System.Drawing.Point(3, 5);
            this.pnlGenTopLeft.Name = "pnlGenTopLeft";
            this.pnlGenTopLeft.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlGenTopLeft.Size = new System.Drawing.Size(363, 148);
            this.pnlGenTopLeft.TabIndex = 0;
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.txtHoursPerDay);
            this.grpProperties.Controls.Add(this.cdvFactoryType);
            this.grpProperties.Controls.Add(this.chkRemoteFac);
            this.grpProperties.Controls.Add(this.txtDaysPerWeek);
            this.grpProperties.Controls.Add(this.lblHoursPerDay);
            this.grpProperties.Controls.Add(this.lblDaysPerWeek);
            this.grpProperties.Controls.Add(this.lblFactoryType);
            this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpProperties.Location = new System.Drawing.Point(0, 0);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(358, 148);
            this.grpProperties.TabIndex = 0;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Properties";
            // 
            // txtHoursPerDay
            // 
            this.txtHoursPerDay.Location = new System.Drawing.Point(146, 88);
            this.txtHoursPerDay.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHoursPerDay.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHoursPerDay.MaskInput = "nn.nn";
            this.txtHoursPerDay.MaxValue = 24;
            this.txtHoursPerDay.MinValue = 0;
            this.txtHoursPerDay.Name = "txtHoursPerDay";
            this.txtHoursPerDay.Nullable = true;
            this.txtHoursPerDay.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtHoursPerDay.PromptChar = ' ';
            this.txtHoursPerDay.Size = new System.Drawing.Size(195, 20);
            this.txtHoursPerDay.TabIndex = 6;
            this.txtHoursPerDay.Value = null;
            this.txtHoursPerDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoursPerDay_KeyPress);
            // 
            // cdvFactoryType
            // 
            this.cdvFactoryType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFactoryType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFactoryType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFactoryType.BtnToolTipText = "";
            this.cdvFactoryType.DescText = "";
            this.cdvFactoryType.DisplaySubItemIndex = -1;
            this.cdvFactoryType.DisplayText = "";
            this.cdvFactoryType.Focusing = null;
            this.cdvFactoryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFactoryType.Index = 0;
            this.cdvFactoryType.IsViewBtnImage = false;
            this.cdvFactoryType.Location = new System.Drawing.Point(146, 16);
            this.cdvFactoryType.MaxLength = 2;
            this.cdvFactoryType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFactoryType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFactoryType.Name = "cdvFactoryType";
            this.cdvFactoryType.ReadOnly = false;
            this.cdvFactoryType.SearchSubItemIndex = 0;
            this.cdvFactoryType.SelectedDescIndex = -1;
            this.cdvFactoryType.SelectedSubItemIndex = -1;
            this.cdvFactoryType.SelectionStart = 0;
            this.cdvFactoryType.Size = new System.Drawing.Size(195, 20);
            this.cdvFactoryType.SmallImageList = null;
            this.cdvFactoryType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFactoryType.TabIndex = 1;
            this.cdvFactoryType.TextBoxToolTipText = "";
            this.cdvFactoryType.TextBoxWidth = 195;
            this.cdvFactoryType.VisibleButton = true;
            this.cdvFactoryType.VisibleColumnHeader = false;
            this.cdvFactoryType.VisibleDescription = false;
            // 
            // chkRemoteFac
            // 
            this.chkRemoteFac.AutoSize = true;
            this.chkRemoteFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRemoteFac.Location = new System.Drawing.Point(18, 41);
            this.chkRemoteFac.Name = "chkRemoteFac";
            this.chkRemoteFac.Size = new System.Drawing.Size(107, 18);
            this.chkRemoteFac.TabIndex = 2;
            this.chkRemoteFac.Text = "Remote Factory";
            // 
            // txtDaysPerWeek
            // 
            this.txtDaysPerWeek.Location = new System.Drawing.Point(146, 64);
            this.txtDaysPerWeek.MaxLength = 5;
            this.txtDaysPerWeek.Name = "txtDaysPerWeek";
            this.txtDaysPerWeek.Size = new System.Drawing.Size(195, 20);
            this.txtDaysPerWeek.TabIndex = 4;
            this.txtDaysPerWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDaysPerWeek_KeyPress);
            // 
            // lblHoursPerDay
            // 
            this.lblHoursPerDay.AutoSize = true;
            this.lblHoursPerDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoursPerDay.Location = new System.Drawing.Point(18, 91);
            this.lblHoursPerDay.Name = "lblHoursPerDay";
            this.lblHoursPerDay.Size = new System.Drawing.Size(76, 13);
            this.lblHoursPerDay.TabIndex = 5;
            this.lblHoursPerDay.Text = "Hours Per Day";
            // 
            // lblDaysPerWeek
            // 
            this.lblDaysPerWeek.AutoSize = true;
            this.lblDaysPerWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDaysPerWeek.Location = new System.Drawing.Point(18, 67);
            this.lblDaysPerWeek.Name = "lblDaysPerWeek";
            this.lblDaysPerWeek.Size = new System.Drawing.Size(82, 13);
            this.lblDaysPerWeek.TabIndex = 3;
            this.lblDaysPerWeek.Text = "Days Per Week";
            // 
            // lblFactoryType
            // 
            this.lblFactoryType.AutoSize = true;
            this.lblFactoryType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactoryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactoryType.Location = new System.Drawing.Point(18, 19);
            this.lblFactoryType.Name = "lblFactoryType";
            this.lblFactoryType.Size = new System.Drawing.Size(81, 13);
            this.lblFactoryType.TabIndex = 0;
            this.lblFactoryType.Text = "Factory Type";
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.grpResSts);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpResource.Size = new System.Drawing.Size(728, 410);
            this.tbpResource.TabIndex = 7;
            this.tbpResource.Text = "Resource Status";
            this.tbpResource.Visible = false;
            // 
            // grpResSts
            // 
            this.grpResSts.Controls.Add(this.txtResSts10);
            this.grpResSts.Controls.Add(this.txtResSts9);
            this.grpResSts.Controls.Add(this.txtResSts8);
            this.grpResSts.Controls.Add(this.txtResSts7);
            this.grpResSts.Controls.Add(this.txtResSts6);
            this.grpResSts.Controls.Add(this.lblEquipPrompt10);
            this.grpResSts.Controls.Add(this.lblEquipPrompt9);
            this.grpResSts.Controls.Add(this.lblEquipPrompt8);
            this.grpResSts.Controls.Add(this.lblEquipPrompt7);
            this.grpResSts.Controls.Add(this.lblEquipPrompt6);
            this.grpResSts.Controls.Add(this.txtResSts5);
            this.grpResSts.Controls.Add(this.txtResSts4);
            this.grpResSts.Controls.Add(this.txtResSts3);
            this.grpResSts.Controls.Add(this.txtResSts2);
            this.grpResSts.Controls.Add(this.txtResSts1);
            this.grpResSts.Controls.Add(this.lblEquipPrompt5);
            this.grpResSts.Controls.Add(this.lblEquipPrompt4);
            this.grpResSts.Controls.Add(this.lblEquipPrompt3);
            this.grpResSts.Controls.Add(this.lblEquipPrompt2);
            this.grpResSts.Controls.Add(this.lblEquipPrompt1);
            this.grpResSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResSts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResSts.Location = new System.Drawing.Point(3, 5);
            this.grpResSts.Name = "grpResSts";
            this.grpResSts.Size = new System.Drawing.Size(722, 402);
            this.grpResSts.TabIndex = 0;
            this.grpResSts.TabStop = false;
            // 
            // txtResSts10
            // 
            this.txtResSts10.Location = new System.Drawing.Point(146, 232);
            this.txtResSts10.MaxLength = 30;
            this.txtResSts10.Name = "txtResSts10";
            this.txtResSts10.Size = new System.Drawing.Size(192, 20);
            this.txtResSts10.TabIndex = 19;
            // 
            // txtResSts9
            // 
            this.txtResSts9.Location = new System.Drawing.Point(146, 208);
            this.txtResSts9.MaxLength = 30;
            this.txtResSts9.Name = "txtResSts9";
            this.txtResSts9.Size = new System.Drawing.Size(192, 20);
            this.txtResSts9.TabIndex = 17;
            // 
            // txtResSts8
            // 
            this.txtResSts8.Location = new System.Drawing.Point(146, 184);
            this.txtResSts8.MaxLength = 30;
            this.txtResSts8.Name = "txtResSts8";
            this.txtResSts8.Size = new System.Drawing.Size(192, 20);
            this.txtResSts8.TabIndex = 15;
            // 
            // txtResSts7
            // 
            this.txtResSts7.Location = new System.Drawing.Point(146, 160);
            this.txtResSts7.MaxLength = 30;
            this.txtResSts7.Name = "txtResSts7";
            this.txtResSts7.Size = new System.Drawing.Size(192, 20);
            this.txtResSts7.TabIndex = 13;
            // 
            // txtResSts6
            // 
            this.txtResSts6.Location = new System.Drawing.Point(146, 136);
            this.txtResSts6.MaxLength = 30;
            this.txtResSts6.Name = "txtResSts6";
            this.txtResSts6.Size = new System.Drawing.Size(192, 20);
            this.txtResSts6.TabIndex = 11;
            // 
            // lblEquipPrompt10
            // 
            this.lblEquipPrompt10.AutoSize = true;
            this.lblEquipPrompt10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt10.Location = new System.Drawing.Point(68, 235);
            this.lblEquipPrompt10.Name = "lblEquipPrompt10";
            this.lblEquipPrompt10.Size = new System.Drawing.Size(19, 13);
            this.lblEquipPrompt10.TabIndex = 18;
            this.lblEquipPrompt10.Text = "10";
            // 
            // lblEquipPrompt9
            // 
            this.lblEquipPrompt9.AutoSize = true;
            this.lblEquipPrompt9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt9.Location = new System.Drawing.Point(68, 211);
            this.lblEquipPrompt9.Name = "lblEquipPrompt9";
            this.lblEquipPrompt9.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt9.TabIndex = 16;
            this.lblEquipPrompt9.Text = "9";
            // 
            // lblEquipPrompt8
            // 
            this.lblEquipPrompt8.AutoSize = true;
            this.lblEquipPrompt8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt8.Location = new System.Drawing.Point(68, 187);
            this.lblEquipPrompt8.Name = "lblEquipPrompt8";
            this.lblEquipPrompt8.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt8.TabIndex = 14;
            this.lblEquipPrompt8.Text = "8";
            // 
            // lblEquipPrompt7
            // 
            this.lblEquipPrompt7.AutoSize = true;
            this.lblEquipPrompt7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt7.Location = new System.Drawing.Point(68, 163);
            this.lblEquipPrompt7.Name = "lblEquipPrompt7";
            this.lblEquipPrompt7.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt7.TabIndex = 12;
            this.lblEquipPrompt7.Text = "7";
            // 
            // lblEquipPrompt6
            // 
            this.lblEquipPrompt6.AutoSize = true;
            this.lblEquipPrompt6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt6.Location = new System.Drawing.Point(68, 139);
            this.lblEquipPrompt6.Name = "lblEquipPrompt6";
            this.lblEquipPrompt6.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt6.TabIndex = 10;
            this.lblEquipPrompt6.Text = "6";
            // 
            // txtResSts5
            // 
            this.txtResSts5.Location = new System.Drawing.Point(146, 112);
            this.txtResSts5.MaxLength = 30;
            this.txtResSts5.Name = "txtResSts5";
            this.txtResSts5.Size = new System.Drawing.Size(192, 20);
            this.txtResSts5.TabIndex = 9;
            // 
            // txtResSts4
            // 
            this.txtResSts4.Location = new System.Drawing.Point(146, 88);
            this.txtResSts4.MaxLength = 30;
            this.txtResSts4.Name = "txtResSts4";
            this.txtResSts4.Size = new System.Drawing.Size(192, 20);
            this.txtResSts4.TabIndex = 7;
            // 
            // txtResSts3
            // 
            this.txtResSts3.Location = new System.Drawing.Point(146, 64);
            this.txtResSts3.MaxLength = 30;
            this.txtResSts3.Name = "txtResSts3";
            this.txtResSts3.Size = new System.Drawing.Size(192, 20);
            this.txtResSts3.TabIndex = 5;
            // 
            // txtResSts2
            // 
            this.txtResSts2.Location = new System.Drawing.Point(146, 40);
            this.txtResSts2.MaxLength = 30;
            this.txtResSts2.Name = "txtResSts2";
            this.txtResSts2.Size = new System.Drawing.Size(192, 20);
            this.txtResSts2.TabIndex = 3;
            // 
            // txtResSts1
            // 
            this.txtResSts1.Location = new System.Drawing.Point(146, 16);
            this.txtResSts1.MaxLength = 30;
            this.txtResSts1.Name = "txtResSts1";
            this.txtResSts1.Size = new System.Drawing.Size(192, 20);
            this.txtResSts1.TabIndex = 1;
            // 
            // lblEquipPrompt5
            // 
            this.lblEquipPrompt5.AutoSize = true;
            this.lblEquipPrompt5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt5.Location = new System.Drawing.Point(68, 115);
            this.lblEquipPrompt5.Name = "lblEquipPrompt5";
            this.lblEquipPrompt5.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt5.TabIndex = 8;
            this.lblEquipPrompt5.Text = "5";
            // 
            // lblEquipPrompt4
            // 
            this.lblEquipPrompt4.AutoSize = true;
            this.lblEquipPrompt4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt4.Location = new System.Drawing.Point(68, 91);
            this.lblEquipPrompt4.Name = "lblEquipPrompt4";
            this.lblEquipPrompt4.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt4.TabIndex = 6;
            this.lblEquipPrompt4.Text = "4";
            // 
            // lblEquipPrompt3
            // 
            this.lblEquipPrompt3.AutoSize = true;
            this.lblEquipPrompt3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt3.Location = new System.Drawing.Point(68, 67);
            this.lblEquipPrompt3.Name = "lblEquipPrompt3";
            this.lblEquipPrompt3.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt3.TabIndex = 4;
            this.lblEquipPrompt3.Text = "3";
            // 
            // lblEquipPrompt2
            // 
            this.lblEquipPrompt2.AutoSize = true;
            this.lblEquipPrompt2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt2.Location = new System.Drawing.Point(68, 43);
            this.lblEquipPrompt2.Name = "lblEquipPrompt2";
            this.lblEquipPrompt2.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt2.TabIndex = 2;
            this.lblEquipPrompt2.Text = "2";
            // 
            // lblEquipPrompt1
            // 
            this.lblEquipPrompt1.AutoSize = true;
            this.lblEquipPrompt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEquipPrompt1.Location = new System.Drawing.Point(68, 19);
            this.lblEquipPrompt1.Name = "lblEquipPrompt1";
            this.lblEquipPrompt1.Size = new System.Drawing.Size(13, 13);
            this.lblEquipPrompt1.TabIndex = 0;
            this.lblEquipPrompt1.Text = "1";
            // 
            // tbpShipFac
            // 
            this.tbpShipFac.Controls.Add(this.sptShipFactory);
            this.tbpShipFac.Controls.Add(this.pnlShipFacDef);
            this.tbpShipFac.Controls.Add(this.pnlShipFacList);
            this.tbpShipFac.Location = new System.Drawing.Point(4, 22);
            this.tbpShipFac.Name = "tbpShipFac";
            this.tbpShipFac.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tbpShipFac.Size = new System.Drawing.Size(728, 410);
            this.tbpShipFac.TabIndex = 3;
            this.tbpShipFac.Text = "Shipping Factory";
            this.tbpShipFac.Visible = false;
            // 
            // sptShipFactory
            // 
            this.sptShipFactory.Location = new System.Drawing.Point(250, 5);
            this.sptShipFactory.MinSize = 250;
            this.sptShipFactory.Name = "sptShipFactory";
            this.sptShipFactory.Size = new System.Drawing.Size(4, 405);
            this.sptShipFactory.TabIndex = 0;
            this.sptShipFactory.TabStop = false;
            // 
            // pnlShipFacDef
            // 
            this.pnlShipFacDef.Controls.Add(this.grpFac);
            this.pnlShipFacDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShipFacDef.Location = new System.Drawing.Point(250, 5);
            this.pnlShipFacDef.Name = "pnlShipFacDef";
            this.pnlShipFacDef.Padding = new System.Windows.Forms.Padding(5, 0, 3, 3);
            this.pnlShipFacDef.Size = new System.Drawing.Size(478, 405);
            this.pnlShipFacDef.TabIndex = 1;
            // 
            // grpFac
            // 
            this.grpFac.Controls.Add(this.cdvTransitOper);
            this.grpFac.Controls.Add(this.btnDetach);
            this.grpFac.Controls.Add(this.btnAttach);
            this.grpFac.Controls.Add(this.cdvToFactory);
            this.grpFac.Controls.Add(this.chkRemote);
            this.grpFac.Controls.Add(this.chkTerminate);
            this.grpFac.Controls.Add(this.lblTransitOper);
            this.grpFac.Controls.Add(this.lblShippingFac);
            this.grpFac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFac.Location = new System.Drawing.Point(5, 0);
            this.grpFac.Name = "grpFac";
            this.grpFac.Size = new System.Drawing.Size(470, 402);
            this.grpFac.TabIndex = 0;
            this.grpFac.TabStop = false;
            // 
            // cdvTransitOper
            // 
            this.cdvTransitOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTransitOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTransitOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTransitOper.BtnToolTipText = "";
            this.cdvTransitOper.DescText = "";
            this.cdvTransitOper.DisplaySubItemIndex = -1;
            this.cdvTransitOper.DisplayText = "";
            this.cdvTransitOper.Focusing = null;
            this.cdvTransitOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTransitOper.Index = 0;
            this.cdvTransitOper.IsViewBtnImage = false;
            this.cdvTransitOper.Location = new System.Drawing.Point(218, 40);
            this.cdvTransitOper.MaxLength = 10;
            this.cdvTransitOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTransitOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTransitOper.Name = "cdvTransitOper";
            this.cdvTransitOper.ReadOnly = false;
            this.cdvTransitOper.SearchSubItemIndex = 0;
            this.cdvTransitOper.SelectedDescIndex = -1;
            this.cdvTransitOper.SelectedSubItemIndex = -1;
            this.cdvTransitOper.SelectionStart = 0;
            this.cdvTransitOper.Size = new System.Drawing.Size(195, 20);
            this.cdvTransitOper.SmallImageList = null;
            this.cdvTransitOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTransitOper.TabIndex = 3;
            this.cdvTransitOper.TextBoxToolTipText = "";
            this.cdvTransitOper.TextBoxWidth = 195;
            this.cdvTransitOper.VisibleButton = true;
            this.cdvTransitOper.VisibleColumnHeader = false;
            this.cdvTransitOper.VisibleDescription = false;
            this.cdvTransitOper.ButtonPress += new System.EventHandler(this.cdvTransitOper_ButtonPress);
            // 
            // btnDetach
            // 
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Location = new System.Drawing.Point(31, 53);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 7;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Location = new System.Drawing.Point(31, 24);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 6;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // cdvToFactory
            // 
            this.cdvToFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToFactory.BtnToolTipText = "";
            this.cdvToFactory.DescText = "";
            this.cdvToFactory.DisplaySubItemIndex = -1;
            this.cdvToFactory.DisplayText = "";
            this.cdvToFactory.Focusing = null;
            this.cdvToFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFactory.Index = 0;
            this.cdvToFactory.IsViewBtnImage = false;
            this.cdvToFactory.Location = new System.Drawing.Point(218, 16);
            this.cdvToFactory.MaxLength = 10;
            this.cdvToFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.Name = "cdvToFactory";
            this.cdvToFactory.ReadOnly = false;
            this.cdvToFactory.SearchSubItemIndex = 0;
            this.cdvToFactory.SelectedDescIndex = -1;
            this.cdvToFactory.SelectedSubItemIndex = -1;
            this.cdvToFactory.SelectionStart = 0;
            this.cdvToFactory.Size = new System.Drawing.Size(195, 20);
            this.cdvToFactory.SmallImageList = null;
            this.cdvToFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToFactory.TabIndex = 1;
            this.cdvToFactory.TextBoxToolTipText = "";
            this.cdvToFactory.TextBoxWidth = 195;
            this.cdvToFactory.VisibleButton = true;
            this.cdvToFactory.VisibleColumnHeader = false;
            this.cdvToFactory.VisibleDescription = false;
            // 
            // chkRemote
            // 
            this.chkRemote.AutoSize = true;
            this.chkRemote.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRemote.Location = new System.Drawing.Point(90, 87);
            this.chkRemote.Name = "chkRemote";
            this.chkRemote.Size = new System.Drawing.Size(136, 18);
            this.chkRemote.TabIndex = 5;
            this.chkRemote.Text = "Remote Shipping Flag";
            this.chkRemote.CheckStateChanged += new System.EventHandler(this.chkRemote_CheckStateChanged);
            // 
            // chkTerminate
            // 
            this.chkTerminate.AutoSize = true;
            this.chkTerminate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTerminate.Location = new System.Drawing.Point(90, 67);
            this.chkTerminate.Name = "chkTerminate";
            this.chkTerminate.Size = new System.Drawing.Size(102, 18);
            this.chkTerminate.TabIndex = 4;
            this.chkTerminate.Text = "Terminate Flag";
            this.chkTerminate.CheckStateChanged += new System.EventHandler(this.chkTerminate_CheckStateChanged);
            // 
            // lblTransitOper
            // 
            this.lblTransitOper.AutoSize = true;
            this.lblTransitOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransitOper.Location = new System.Drawing.Point(90, 43);
            this.lblTransitOper.Name = "lblTransitOper";
            this.lblTransitOper.Size = new System.Drawing.Size(88, 13);
            this.lblTransitOper.TabIndex = 2;
            this.lblTransitOper.Text = "Transit Operation";
            // 
            // lblShippingFac
            // 
            this.lblShippingFac.AutoSize = true;
            this.lblShippingFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShippingFac.Location = new System.Drawing.Point(90, 19);
            this.lblShippingFac.Name = "lblShippingFac";
            this.lblShippingFac.Size = new System.Drawing.Size(58, 13);
            this.lblShippingFac.TabIndex = 0;
            this.lblShippingFac.Text = "To Factory";
            // 
            // pnlShipFacList
            // 
            this.pnlShipFacList.Controls.Add(this.lisShipFac);
            this.pnlShipFacList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShipFacList.Location = new System.Drawing.Point(0, 5);
            this.pnlShipFacList.Name = "pnlShipFacList";
            this.pnlShipFacList.Padding = new System.Windows.Forms.Padding(3);
            this.pnlShipFacList.Size = new System.Drawing.Size(250, 405);
            this.pnlShipFacList.TabIndex = 0;
            // 
            // lisShipFac
            // 
            this.lisShipFac.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colToFac,
            this.colIntranOper});
            this.lisShipFac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisShipFac.EnableSort = true;
            this.lisShipFac.EnableSortIcon = true;
            this.lisShipFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisShipFac.FullRowSelect = true;
            this.lisShipFac.GridLines = true;
            this.lisShipFac.HideSelection = false;
            this.lisShipFac.Location = new System.Drawing.Point(3, 3);
            this.lisShipFac.MultiSelect = false;
            this.lisShipFac.Name = "lisShipFac";
            this.lisShipFac.Size = new System.Drawing.Size(244, 399);
            this.lisShipFac.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisShipFac.TabIndex = 0;
            this.lisShipFac.UseCompatibleStateImageBehavior = false;
            this.lisShipFac.View = System.Windows.Forms.View.Details;
            this.lisShipFac.SelectedIndexChanged += new System.EventHandler(this.lisShipFac_SelectedIndexChanged);
            // 
            // colToFac
            // 
            this.colToFac.Text = "To Factory";
            this.colToFac.Width = 97;
            // 
            // colIntranOper
            // 
            this.colIntranOper.Text = "Transit Operation";
            this.colIntranOper.Width = 126;
            // 
            // pnlFacTop
            // 
            this.pnlFacTop.Controls.Add(this.grpFactory);
            this.pnlFacTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFacTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFacTop.Name = "pnlFacTop";
            this.pnlFacTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlFacTop.Size = new System.Drawing.Size(742, 74);
            this.pnlFacTop.TabIndex = 0;
            // 
            // grpFactory
            // 
            this.grpFactory.Controls.Add(this.txtFactoryDesc);
            this.grpFactory.Controls.Add(this.lblDesc);
            this.grpFactory.Controls.Add(this.lblFacName);
            this.grpFactory.Controls.Add(this.txtFactory);
            this.grpFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFactory.Location = new System.Drawing.Point(3, 0);
            this.grpFactory.Name = "grpFactory";
            this.grpFactory.Size = new System.Drawing.Size(736, 71);
            this.grpFactory.TabIndex = 0;
            this.grpFactory.TabStop = false;
            // 
            // txtFactoryDesc
            // 
            this.txtFactoryDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFactoryDesc.Location = new System.Drawing.Point(154, 40);
            this.txtFactoryDesc.MaxLength = 200;
            this.txtFactoryDesc.Name = "txtFactoryDesc";
            this.txtFactoryDesc.Size = new System.Drawing.Size(558, 20);
            this.txtFactoryDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(26, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblFacName
            // 
            this.lblFacName.AutoSize = true;
            this.lblFacName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacName.Location = new System.Drawing.Point(26, 19);
            this.lblFacName.Name = "lblFacName";
            this.lblFacName.Size = new System.Drawing.Size(49, 13);
            this.lblFacName.TabIndex = 0;
            this.lblFacName.Text = "Factory";
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(154, 16);
            this.txtFactory.MaxLength = 10;
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(195, 20);
            this.txtFactory.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmWIPSetupFactory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupFactory";
            this.Text = "Factory Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupFactory_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFacMid.ResumeLayout(false);
            this.tabFactory.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGenMid.ResumeLayout(false);
            this.grpShift.ResumeLayout(false);
            this.grpShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift1)).EndInit();
            this.pnlGenTop.ResumeLayout(false);
            this.pnlGenTopMid.ResumeLayout(false);
            this.grpFactoryGrp.ResumeLayout(false);
            this.grpFactoryGrp.PerformLayout();
            this.pnlGenTopLeft.ResumeLayout(false);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoursPerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactoryType)).EndInit();
            this.tbpResource.ResumeLayout(false);
            this.grpResSts.ResumeLayout(false);
            this.grpResSts.PerformLayout();
            this.tbpShipFac.ResumeLayout(false);
            this.pnlShipFacDef.ResumeLayout(false);
            this.grpFac.ResumeLayout(false);
            this.grpFac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTransitOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).EndInit();
            this.pnlShipFacList.ResumeLayout(false);
            this.pnlFacTop.ResumeLayout(false);
            this.grpFactory.ResumeLayout(false);
            this.grpFactory.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const string GCM_GRP_TABLE_NAME = "GROUP_ITEM_NAME";
        private const string GCM_CMF_TABLE_NAME = "CMF_ITEM_NAME";
        private const string GCM_FACTORY_TYPE = "FACTORY_TYPE";
        private const string _DEFAULT_GCM_TABLE = "Default GCM Table";
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;

        private bool b_sec_chk_create;
        private bool b_sec_chk_update;
        private bool b_sec_chk_delete;

        #endregion

        #region " Function Definition "

        // initCodeView()
        //       -   initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //       -
        private void initCodeView()
        {
            cdvFactoryType.Init();
            MPCF.InitListView(cdvFactoryType.GetListView);
            cdvFactoryType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvFactoryType.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvFactoryType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvFactoryType.GetListView, '1', GCM_FACTORY_TYPE, (int)SMALLICON_INDEX.IDX_FACTORY, null, "");

            ListViewItem itmX;

            cdvShift1.Init();
            MPCF.InitListView(cdvShift1.GetListView);
            cdvShift1.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvShift1.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvShift1.SelectedSubItemIndex = 0;
            itmX = new ListViewItem("P", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Yesterday");
            cdvShift1.Items.Add(itmX);
            itmX = new ListViewItem("T", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Today");
            cdvShift1.Items.Add(itmX);
            itmX = new ListViewItem("N", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Tomorrow");
            cdvShift1.Items.Add(itmX);

            cdvShift2.Init();
            MPCF.InitListView(cdvShift2.GetListView);
            cdvShift2.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvShift2.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvShift2.SelectedSubItemIndex = 0;
            itmX = new ListViewItem("P", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Yesterday");
            cdvShift2.Items.Add(itmX);
            itmX = new ListViewItem("T", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Today");
            cdvShift2.Items.Add(itmX);
            itmX = new ListViewItem("N", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Tomorrow");
            cdvShift2.Items.Add(itmX);

            cdvShift3.Init();
            MPCF.InitListView(cdvShift3.GetListView);
            cdvShift3.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvShift3.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvShift3.SelectedSubItemIndex = 0;
            itmX = new ListViewItem("P", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Yesterday");
            cdvShift3.Items.Add(itmX);
            itmX = new ListViewItem("T", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Today");
            cdvShift3.Items.Add(itmX);
            itmX = new ListViewItem("N", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Tomorrow");
            cdvShift3.Items.Add(itmX);

            cdvShift4.Init();
            MPCF.InitListView(cdvShift4.GetListView);
            cdvShift4.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvShift4.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvShift4.SelectedSubItemIndex = 0;
            itmX = new ListViewItem("P", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Yesterday");
            cdvShift4.Items.Add(itmX);
            itmX = new ListViewItem("T", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Today");
            cdvShift4.Items.Add(itmX);
            itmX = new ListViewItem("N", (int)SMALLICON_INDEX.IDX_MONTH);
            itmX.SubItems.Add("Tomorrow");
            cdvShift4.Items.Add(itmX);
            
            cdvToFactory.Init();
            MPCF.InitListView(cdvToFactory.GetListView);
            cdvToFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvToFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvToFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvToFactory.GetListView, '1', null);
            int i;
            i = 0;
            while (i < cdvToFactory.Items.Count)
            {
                if (MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsFactory || MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsCentralFactory)
                {
                    cdvToFactory.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            cdvTransitOper.Init();
            MPCF.InitListView(cdvTransitOper.GetListView);
            cdvTransitOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvTransitOper.Columns.Add("Oper Desc", 100, HorizontalAlignment.Left);
            cdvTransitOper.SelectedSubItemIndex = 0;
            View_Transit_Operation_List(cdvTransitOper.GetListView);

        }

        // CheckCondition()
        //       -   Check update factory condition
        // Return Value
        //       -
        // Arguments
        //       -
        private bool CheckCondition(string sFunc)
        {

            if (MPCF.CheckValue(txtFactory, 1) == false)
            {
                return false;
            }

            switch (sFunc)
            {
                case "FACTORY_CREATE":
                    if (MPCF.ToDbl(txtDaysPerWeek.Text) > 7)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(189) + " (7)");
                        txtDaysPerWeek.Focus();
                        return false;
                    }
                    if (MPCF.ToDbl(txtHoursPerDay.Text) > 24)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(189) + " (24)");
                        txtHoursPerDay.Focus();
                        return false;
                    }
                    if (chkVariable.Checked == false)
                    {
                        if (MPCF.CheckValue(cdvShift1, 1) == false)
                        {
                            return false;
                        }
                        if (cdvShift2.Text == "" && (cdvShift3.Text != "" || cdvShift4.Text != ""))
                        {
                            cdvShift3.Text = "";
                            cdvShift4.Text = "";
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            cdvShift2.Focus();
                            return false;
                        }
                        if (cdvShift3.Text == "" && cdvShift4.Text != "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            cdvShift4.Text = "";
                            cdvShift3.Focus();
                            return false;
                        }
                        if (cdvShift1.Text != "")
                        {
                            if (cdvShift1.Text != "P" && cdvShift1.Text != "T" && cdvShift1.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift1.Focus();
                                return false;
                            }
                        }
                        if (cdvShift2.Text != "")
                        {
                            if (cdvShift2.Text != "P" && cdvShift2.Text != "T" && cdvShift2.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift2.Focus();
                                return false;
                            }
                        }
                        if (cdvShift3.Text != "")
                        {
                            if (cdvShift3.Text != "P" && cdvShift3.Text != "T" && cdvShift3.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift3.Focus();
                                return false;
                            }
                        }
                        if (cdvShift4.Text != "")
                        {
                            if (cdvShift4.Text != "P" && cdvShift4.Text != "T" && cdvShift4.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift4.Focus();
                                return false;
                            }
                        }
                    }
                    break;


                case "FACTORY_UPDATE":

                    if (MPCF.ToDbl(txtDaysPerWeek.Text) > 7)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(189) + " (7)");
                        txtDaysPerWeek.Focus();
                        return false;
                    }
                    if (MPCF.ToDbl(txtHoursPerDay.Text) > 24)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(189) + " (24)");
                        txtHoursPerDay.Focus();
                        return false;
                    }
                    if (chkVariable.Checked == false)
                    {
                        if (MPCF.CheckValue(cdvShift1, 1) == false)
                        {
                            return false;
                        }
                        if (cdvShift2.Text == "" && (cdvShift3.Text != "" || cdvShift4.Text != ""))
                        {
                            cdvShift3.Text = "";
                            cdvShift4.Text = "";
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            cdvShift2.Focus();
                            return false;
                        }
                        if (cdvShift3.Text == "" && cdvShift4.Text != "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            cdvShift4.Text = "";
                            cdvShift3.Focus();
                            return false;
                        }
                        if (cdvShift1.Text != "")
                        {
                            if (cdvShift1.Text != "P" && cdvShift1.Text != "T" && cdvShift1.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift1.Focus();
                                return false;
                            }
                        }
                        if (cdvShift2.Text != "")
                        {
                            if (cdvShift2.Text != "P" && cdvShift2.Text != "T" && cdvShift2.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift2.Focus();
                                return false;
                            }
                        }
                        if (cdvShift3.Text != "")
                        {
                            if (cdvShift3.Text != "P" && cdvShift3.Text != "T" && cdvShift3.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift3.Focus();
                                return false;
                            }
                        }
                        if (cdvShift4.Text != "")
                        {
                            if (cdvShift4.Text != "P" && cdvShift4.Text != "T" && cdvShift4.Text != "N")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(185));
                                cdvShift4.Focus();
                                return false;
                            }
                        }
                    }
                    break;

                case "FACTORY_DELETE":

                    break;

            }

            return true;

        }

        // View_Factory()
        //       - View Factory
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_Factory(string sFactory)
        {
            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            MPCF.FieldClear(this.tbpGeneral);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.Factory = MPCF.Trim(sFactory);

            if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
            {
                return false;
            }
            txtFactory.Text = MPCF.Trim(out_node.GetString("FACTORY"));
            txtFactoryDesc.Text = MPCF.Trim(out_node.GetString("FAC_DESC"));

            txtFactoryGrp1.Text = MPCF.Trim(out_node.GetString("FAC_GRP_1"));
            txtFactoryGrp2.Text = MPCF.Trim(out_node.GetString("FAC_GRP_2"));
            txtFactoryGrp3.Text = MPCF.Trim(out_node.GetString("FAC_GRP_3"));
            txtFactoryGrp4.Text = MPCF.Trim(out_node.GetString("FAC_GRP_4"));
            txtFactoryGrp5.Text = MPCF.Trim(out_node.GetString("FAC_GRP_5"));

            cdvFactoryType.Text = MPCF.Trim(out_node.GetString("FAC_TYPE"));

            txtDaysPerWeek.Text = out_node.GetDouble("DAYS_PER_WEEK").ToString();
            txtHoursPerDay.Text = out_node.GetDouble("HOURS_PER_DAY").ToString();
            chkVariable.Checked = out_node.GetChar("VARIABLE_SHIFT_FLAG") == 'Y' ? true : false;

            if (chkVariable.Checked == false)
            {
                cdvShift1.ReadOnly = false;

                cdvShift1.VisibleButton = true;
                cdvShift1.BackColor = SystemColors.Window;
                txtShift1Start.ReadOnly = false;
                cdvShift2.ReadOnly = false;

                cdvShift2.VisibleButton = true;
                cdvShift2.BackColor = SystemColors.Window;
                txtShift2Start.ReadOnly = false;
                cdvShift3.ReadOnly = false;

                cdvShift3.VisibleButton = true;
                cdvShift3.BackColor = SystemColors.Window;
                txtShift3Start.ReadOnly = false;
                cdvShift4.ReadOnly = false;

                cdvShift4.VisibleButton = true;
                cdvShift4.BackColor = SystemColors.Window;
                txtShift4Start.ReadOnly = false;

                txtShift1Start.Text = MPCF.Trim(out_node.GetString("SHIFT_1_START"));
                cdvShift1.Text = MPCF.Trim(out_node.GetChar("SHIFT_1_DAY_FLAG"));
                txtShift2Start.Text = MPCF.Trim(out_node.GetString("SHIFT_2_START"));
                cdvShift2.Text = MPCF.Trim(out_node.GetChar("SHIFT_2_DAY_FLAG"));
                txtShift3Start.Text = MPCF.Trim(out_node.GetString("SHIFT_3_START"));
                cdvShift3.Text = MPCF.Trim(out_node.GetChar("SHIFT_3_DAY_FLAG"));
                txtShift4Start.Text = MPCF.Trim(out_node.GetString("SHIFT_4_START"));
                cdvShift4.Text = MPCF.Trim(out_node.GetChar("SHIFT_4_DAY_FLAG"));
            }
            else
            {
                cdvShift1.Text = "";

                cdvShift1.BackColor = SystemColors.Control;
                cdvShift1.ReadOnly = true;
                cdvShift1.VisibleButton = false;
                txtShift1Start.Text = "";
                txtShift1Start.ReadOnly = true;
                cdvShift2.Text = "";

                cdvShift2.BackColor = SystemColors.Control;
                cdvShift2.ReadOnly = true;
                cdvShift2.VisibleButton = false;
                txtShift2Start.Text = "";
                txtShift2Start.ReadOnly = true;
                cdvShift3.Text = "";

                cdvShift3.BackColor = SystemColors.Control;
                cdvShift3.ReadOnly = true;
                cdvShift3.VisibleButton = false;
                txtShift3Start.Text = "";
                txtShift3Start.ReadOnly = true;
                cdvShift4.Text = "";

                cdvShift4.BackColor = SystemColors.Control;
                cdvShift4.ReadOnly = true;
                cdvShift4.VisibleButton = false;
                txtShift4Start.Text = "";
                txtShift4Start.ReadOnly = true;
            }

            chkRemoteFac.Checked = out_node.GetChar("REMOTE_FAC_FLAG") == 'Y' ? true : false;

            txtResSts1.Text = out_node.GetString("RES_STS_1");
            txtResSts2.Text = out_node.GetString("RES_STS_2");
            txtResSts3.Text = out_node.GetString("RES_STS_3");
            txtResSts4.Text = out_node.GetString("RES_STS_4");
            txtResSts5.Text = out_node.GetString("RES_STS_5");
            txtResSts6.Text = out_node.GetString("RES_STS_6");
            txtResSts7.Text = out_node.GetString("RES_STS_7");
            txtResSts8.Text = out_node.GetString("RES_STS_8");
            txtResSts9.Text = out_node.GetString("RES_STS_9");
            txtResSts10.Text = out_node.GetString("RES_STS_10");

            return true;
        }

        // Update_Factory()
        //       - Update Factory Infor
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String : MP_STEP_CREATE/UPDATE/DELETE
        private bool Update_Factory(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_FACTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_DELETE)
            {
                in_node.AddString("NEW_FACTORY", MPCF.Trim(txtFactory.Text));

            }
            else
            {
                in_node.Factory = MPCF.Trim(txtFactory.Text);
            }
            in_node.AddString("FAC_DESC", MPCF.Trim(txtFactoryDesc.Text));
            in_node.AddString("FAC_GRP_1", MPCF.Trim(txtFactoryGrp1.Text));
            in_node.AddString("FAC_GRP_2", MPCF.Trim(txtFactoryGrp2.Text));
            in_node.AddString("FAC_GRP_3", MPCF.Trim(txtFactoryGrp3.Text));
            in_node.AddString("FAC_GRP_4", MPCF.Trim(txtFactoryGrp4.Text));
            in_node.AddString("FAC_GRP_5", MPCF.Trim(txtFactoryGrp5.Text));
            in_node.AddString("FAC_TYPE", MPCF.Trim(cdvFactoryType.Text));
            if (MPCF.CheckNumeric(txtHoursPerDay.Text))
            {
                in_node.AddDouble("HOURS_PER_DAY", MPCF.ToDbl(txtHoursPerDay.Text));
            }
            else
            {
                in_node.AddDouble("HOURS_PER_DAY", 0);
            }
            if (MPCF.CheckNumeric(txtDaysPerWeek.Text))
            {
                in_node.AddDouble("DAYS_PER_WEEK", MPCF.ToDbl(txtDaysPerWeek.Text));
            }
            else
            {
                in_node.AddDouble("DAYS_PER_WEEK", 0);
            }
            in_node.AddChar("VARIABLE_SHIFT_FLAG", chkVariable.Checked == true ? 'Y' : ' ');
            in_node.AddString("SHIFT_1_START", MPCF.Trim(txtShift1Start.Text));
            in_node.AddChar("SHIFT_1_DAY_FLAG", MPCF.ToChar(cdvShift1.Text));
            in_node.AddString("SHIFT_2_START", MPCF.Trim(txtShift2Start.Text));
            in_node.AddChar("SHIFT_2_DAY_FLAG", MPCF.ToChar(cdvShift2.Text));
            in_node.AddString("SHIFT_3_START", MPCF.Trim(txtShift3Start.Text));
            in_node.AddChar("SHIFT_3_DAY_FLAG", MPCF.ToChar(cdvShift3.Text));
            in_node.AddString("SHIFT_4_START", MPCF.Trim(txtShift4Start.Text));
            in_node.AddChar("SHIFT_4_DAY_FLAG", MPCF.ToChar(cdvShift4.Text));
            in_node.AddChar("REMOTE_FAC_FLAG", chkRemoteFac.Checked == true ? 'Y' : ' ');
            in_node.AddString("RES_STS_1", MPCF.Trim(txtResSts1.Text));
            in_node.AddString("RES_STS_2", MPCF.Trim(txtResSts2.Text));
            in_node.AddString("RES_STS_3", MPCF.Trim(txtResSts3.Text));
            in_node.AddString("RES_STS_4", MPCF.Trim(txtResSts4.Text));
            in_node.AddString("RES_STS_5", MPCF.Trim(txtResSts5.Text));
            in_node.AddString("RES_STS_6", MPCF.Trim(txtResSts6.Text));
            in_node.AddString("RES_STS_7", MPCF.Trim(txtResSts7.Text));
            in_node.AddString("RES_STS_8", MPCF.Trim(txtResSts8.Text));
            in_node.AddString("RES_STS_9", MPCF.Trim(txtResSts9.Text));
            in_node.AddString("RES_STS_10", MPCF.Trim(txtResSts10.Text));

            if (MPCR.CallService("WIP", "WIP_Update_Factory", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;
        }

        // View_Ship_Factory()
        //       - View Shipping Factory
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool View_Ship_Factory()
        {
            TRSNode in_node = new TRSNode("VIEW_SHIP_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SHIP_FACTORY_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FACTORY_TO", MPCF.Trim(cdvToFactory.Text));
            in_node.AddString("TRANSIT_OPER", MPCF.Trim(cdvTransitOper.Text));

            if (MPCR.CallService("WIP", "WIP_View_Ship_Factory", in_node, ref out_node) == false)
            {
                return false;
            }
            cdvToFactory.Text = MPCF.Trim(out_node.GetString("FACTORY_TO"));

            chkTerminate.Checked = out_node.GetChar("AUTO_TERM_FLAG") == 'Y' ? true : false;
            if (chkTerminate.Checked == true)
            {
                cdvTransitOper.Text = "";
                cdvTransitOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvTransitOper.Enabled = false;
            }
            else
            {
                cdvTransitOper.Enabled = true;
                cdvTransitOper.Text = out_node.GetString("TRANSIT_OPER");
                cdvTransitOper.BackColor = Color.White;
            }

            //Add by J.S. 2009.03.05 for remote shipping
            //Transit oper°¡ ÀÖ¾î¾ß ÇÑ´Ù.
            chkRemote.Checked = out_node.GetChar("REMOTE_FLAG") == 'Y' ? true : false;
            if (chkRemote.Checked == true)
            {
                cdvTransitOper.Enabled = true;
                cdvTransitOper.Text = out_node.GetString("TRANSIT_OPER");
                cdvTransitOper.BackColor = Color.White;
            }


            return true;
        }

        // Update_Ship_Factory()
        //       - Update Shipping Factory
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String : MP_STEP_CREATE/UPDATE/DELETE
        private bool Update_Ship_Factory(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_SHIP_FACTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem item;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("FACTORY_TO", MPCF.Trim(cdvToFactory.Text));
            in_node.AddString("TRANSIT_OPER", MPCF.Trim(cdvTransitOper.Text));
            in_node.AddChar("AUTO_TERM_FLAG", chkTerminate.Checked == true ? 'Y' : ' ');
            //Add by J.S. 2009.03.05 for remote shipping
            in_node.AddChar("REMOTE_FLAG", chkRemote.Checked == true ? 'Y' : ' ');

            if (MPCR.CallService("WIP", "WIP_Update_Ship_Factory", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (c_step == '1')
            {
                item = lisShipFac.Items.Add(MPCF.Trim(cdvToFactory.Text));
                item.SubItems.Add(MPCF.Trim(cdvTransitOper.Text));
                item.Selected = true;
            }
            else if (c_step == '2')
            {
                for (i = 0; i <= lisShipFac.Items.Count - 1; i++)
                {
                    if (lisShipFac.Items[i].Text == MPCF.Trim(cdvToFactory.Text))
                    {
                        lisShipFac.Items[i].Selected = true;
                        lisShipFac.Items[i].SubItems[1].Text = MPCF.Trim(cdvTransitOper.Text);
                        break;
                    }
                }
            }
            else if (c_step == '3')
            {
                for (i = 0; i <= lisShipFac.Items.Count - 1; i++)
                {
                    if (lisShipFac.Items[i].Text == MPCF.Trim(cdvToFactory.Text))
                    {
                        lisShipFac.Items[i].Remove();
                        break;
                    }
                }
            }

            return true;
        }

        private bool View_Transit_Operation_List(Control control)
        {
            int i;
            ListViewItem itmX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            MPCF.InitListView((ListView)control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '5';

            in_node.AddString("TARGET_FACTORY", MPCF.Trim(cdvToFactory.Text));

            do
            {
                out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("OPER"), (int)SMALLICON_INDEX.IDX_OPER);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER_DESC"));
                    }

                    ((ListView)control).Items.Add(itmX);
                }
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.txtFactory;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPSetupFactory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                if (btnCreate.Enabled == false)
                    b_sec_chk_create = false;
                else
                    b_sec_chk_create = true;
                if (btnUpdate.Enabled == false)
                    b_sec_chk_update = false;
                else
                    b_sec_chk_update = true;
                if (btnDelete.Enabled == false)
                    b_sec_chk_delete = false;
                else
                    b_sec_chk_delete = true;

                tabFactory.TabPages[0].Select();

                MPCF.FieldClear(this);               
                MPCF.InitListView(lisShipFac);

                txtFactory.Text = MPCF.Trim(MPGV.gsFactory);
                if (txtFactory.Text == MPGV.gsCentralFactory)
                {
                    txtFactory.ReadOnly = false;
                    if (b_sec_chk_create != false)   
                        btnCreate.Enabled = true;
                    if (b_sec_chk_delete != false)
                        btnDelete.Enabled = true;
                }
                else
                {
                    txtFactory.ReadOnly = true;
                    btnCreate.Enabled = false;
                    btnDelete.Enabled = false;
                }

                initCodeView();

                View_Factory(txtFactory.Text);
                
                b_load_flag = true;
            }
        }

        private void chkTerminate_CheckStateChanged(System.Object sender, System.EventArgs e)
        {
            if (chkTerminate.Checked == true)
            {
                if (chkRemote.Checked != true)
                {
                    cdvTransitOper.Text = "";
                    cdvTransitOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                    cdvTransitOper.Enabled = false;
                }
            }
            else
            {
                cdvTransitOper.Enabled = true;
                cdvTransitOper.BackColor = Color.White;
            }

            if (chkRemote.Checked == true)
            {
                cdvTransitOper.Enabled = true;
                cdvTransitOper.BackColor = Color.White;
            }
        }

        private void chkRemote_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkRemote.Checked == true)
            {
                //Remote shipping ÀÏ¶§´Â ¹«Á¶°Ç ÅÍ¹Ì³×ÀÌÆ® µÊ.
                chkTerminate.Checked = true;
                chkTerminate.Enabled = false;

                cdvTransitOper.Enabled = true;
                cdvTransitOper.BackColor = Color.White;
            }
            else
            {
                chkTerminate.Enabled = true;

                cdvTransitOper.Text = "";
                cdvTransitOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvTransitOper.Enabled = false;
            }
        }


        private void tabFactory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (b_sec_chk_create != false)
                btnCreate.Enabled = true;
            if (b_sec_chk_update != false)
                btnUpdate.Enabled = true;
            if (b_sec_chk_delete != false)
                btnDelete.Enabled = true;

            if (tabFactory.SelectedTab == tbpGeneral)
            {
                if (MPCF.Trim(MPGV.gsFactory) == MPGV.gsCentralFactory)
                {
                    txtFactory.ReadOnly = false;
                }
                else
                {
                    txtFactory.ReadOnly = true;
                    btnCreate.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                btnCreate.Enabled = false;
                btnDelete.Enabled = false;

                if (tabFactory.SelectedTab == tbpShipFac)
                {
                    WIPLIST.ViewShipFacList(lisShipFac, '1', null, "");
                    btnUpdate.Enabled = false;
                }
            }

        }

        private void txtDaysPerWeek_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtHoursPerDay_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtShift1Start_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtShift2Start_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtShift3Start_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtShift4Start_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void lisShipFac_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlShipFacDef);

            if (lisShipFac.SelectedItems.Count > 0)
            {
                cdvToFactory.Text = lisShipFac.SelectedItems[0].Text;
                cdvTransitOper.Text = lisShipFac.SelectedItems[0].SubItems[1].Text;
                View_Ship_Factory();
            }
        }
        
        private void cdvTransitOper_ButtonPress(object sender, System.EventArgs e)
        {
            if (cdvToFactory.Text == "")
            {
                cdvToFactory.Focus();
                return;
            }

            if (View_Transit_Operation_List(cdvTransitOper.GetListView) == false)
            {
                return;
            }

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (tabFactory.SelectedTab == tbpGeneral || tabFactory.SelectedTab == tbpResource)
            {
                if (tabFactory.SelectedTab == tbpGeneral)
                {
                    if (CheckCondition("FACTORY_CREATE") == false)
                    {
                        return;
                    }
                }

                Update_Factory(MPGC.MP_STEP_CREATE);
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (tabFactory.SelectedTab == tbpGeneral || tabFactory.SelectedTab == tbpResource)
            {
                if (tabFactory.SelectedTab == tbpGeneral)
                {
                    if (CheckCondition("FACTORY_UPDATE") == false)
                    {
                        return;
                    }
                }
                Update_Factory(MPGC.MP_STEP_UPDATE);
            }
            
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (tabFactory.SelectedTab == tbpGeneral || tabFactory.SelectedTab == tbpResource)
            {
                if (tabFactory.SelectedTab == tbpGeneral)
                {
                    if (CheckCondition("FACTORY_DELETE") == false)
                    {
                        return;
                    }
                }
                if (Update_Factory(MPGC.MP_STEP_DELETE) == true)
                {
                    View_Factory(MPGV.gsFactory);
                }
            }
           
        }

        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            Update_Ship_Factory(MPGC.MP_STEP_UPDATE);
            WIPLIST.ViewShipFacList(lisShipFac, '1', null, "");
        }

        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            Update_Ship_Factory(MPGC.MP_STEP_DELETE);
            WIPLIST.ViewShipFacList(lisShipFac, '1', null, "");
        }

        private void chkVariable_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkVariable.Checked == true)
            {
                cdvShift1.Text = "";

                cdvShift1.BackColor = SystemColors.Control;
                cdvShift1.ReadOnly = true;
                cdvShift1.VisibleButton = false;
                txtShift1Start.Text = "";
                txtShift1Start.ReadOnly = true;
                cdvShift2.Text = "";

                cdvShift2.BackColor = SystemColors.Control;
                cdvShift2.ReadOnly = true;
                cdvShift2.VisibleButton = false;
                txtShift2Start.Text = "";
                txtShift2Start.ReadOnly = true;
                cdvShift3.Text = "";

                cdvShift3.BackColor = SystemColors.Control;
                cdvShift3.ReadOnly = true;
                cdvShift3.VisibleButton = false;
                txtShift3Start.Text = "";
                txtShift3Start.ReadOnly = true;
                cdvShift4.Text = "";

                cdvShift4.BackColor = SystemColors.Control;
                cdvShift4.ReadOnly = true;
                cdvShift4.VisibleButton = false;
                txtShift4Start.Text = "";
                txtShift4Start.ReadOnly = true;
            }
            else
            {
                cdvShift1.ReadOnly = false;

                cdvShift1.VisibleButton = true;
                cdvShift1.BackColor = SystemColors.Window;
                txtShift1Start.ReadOnly = false;
                cdvShift2.ReadOnly = false;

                cdvShift2.VisibleButton = true;
                cdvShift2.BackColor = SystemColors.Window;
                txtShift2Start.ReadOnly = false;
                cdvShift3.ReadOnly = false;

                cdvShift3.VisibleButton = true;
                cdvShift3.BackColor = SystemColors.Window;
                txtShift3Start.ReadOnly = false;
                cdvShift4.ReadOnly = false;

                cdvShift4.VisibleButton = true;
                cdvShift4.BackColor = SystemColors.Window;
                txtShift4Start.ReadOnly = false;
            }

        }

        private void cdvShift2_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (cdvShift2.Text != "")
            {
                if (cdvShift1.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    cdvShift2.Text = "";
                    cdvShift1.Focus();
                }
                else if ((cdvShift1.Text == "T" && cdvShift2.Text == "P") || (cdvShift1.Text == "N" && (cdvShift2.Text == "P" || cdvShift2.Text == "T")))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(174));
                    cdvShift2.Text = "";
                    cdvShift2.Focus();
                }
            }
        }

        private void cdvShift3_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (cdvShift3.Text != "")
            {
                if (cdvShift2.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    cdvShift3.Text = "";
                    cdvShift2.Focus();
                }
                else if ((cdvShift2.Text == "T" && cdvShift3.Text == "P") || (cdvShift2.Text == "N" && (cdvShift3.Text == "P" || cdvShift3.Text == "T")))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(174));
                    cdvShift3.Text = "";
                    cdvShift3.Focus();
                }
            }
        }

        private void cdvShift4_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (cdvShift4.Text != "")
            {
                if (cdvShift3.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    cdvShift4.Text = "";
                    cdvShift3.Focus();
                }
                else if ((cdvShift3.Text == "T" && cdvShift4.Text == "P") || (cdvShift3.Text == "N" && (cdvShift4.Text == "P" || cdvShift4.Text == "T")))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(174));
                    cdvShift4.Text = "";
                    cdvShift4.Focus();
                }
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                View_Factory(txtFactory.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


    }

}
