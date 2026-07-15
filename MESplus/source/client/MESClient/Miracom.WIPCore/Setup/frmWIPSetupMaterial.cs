
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipSetupMaterial.vb
//   Description : MES Cient Form Material Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group / Cmf Property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Attach_Flow_ToMaterial() : Attach flow to Material
//       - Detach_Flow_FromMaterial() : Detach flow from Material
//       - VIEW_MATERIAL() : View Material
//       - Update_Material() : update Material
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
using Miracom.CliFrx;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPSetupMaterial : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupMaterial()
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
        



        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TabControl tabMaterial;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1;
        private System.Windows.Forms.Label lblDefaultQty3;
        private System.Windows.Forms.Label lblDefaultQty2;
        private System.Windows.Forms.Label lblDefaultQty1;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Label lblMatType;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpProperty;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.TabPage tbpCmf;
        private System.Windows.Forms.TabPage tbpFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private System.Windows.Forms.Label lblGroup10;
        private System.Windows.Forms.Label lblGroup9;
        private System.Windows.Forms.Label lblGroup8;
        private System.Windows.Forms.Label lblGroup7;
        private System.Windows.Forms.Label lblGroup6;
        private System.Windows.Forms.Label lblGroup5;
        private System.Windows.Forms.Label lblGroup4;
        private System.Windows.Forms.Label lblGroup3;
        private System.Windows.Forms.Label lblGroup2;
        private System.Windows.Forms.Label lblGroup1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.GroupBox grp1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBomSetID;
        private System.Windows.Forms.TextBox txtDefStrOper;
        private System.Windows.Forms.Label lblDefStrOper;
        private System.Windows.Forms.Label lblBomSetId;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPackType;
        private System.Windows.Forms.Label lblPackQty;
        private System.Windows.Forms.Label lblPackLotCnt;
        private System.Windows.Forms.Label lblPackType;
        private System.Windows.Forms.GroupBox grpOqc;
        private System.Windows.Forms.CheckBox chkOqcSampleRule;
        private System.Windows.Forms.CheckBox chkOqcSampleFlag;
        private System.Windows.Forms.CheckBox chkOqcFlag;
        private System.Windows.Forms.GroupBox grpIqc;
        private System.Windows.Forms.CheckBox chkIqcSampleRule;
        private System.Windows.Forms.CheckBox chkIqcSampleFlag;
        private System.Windows.Forms.CheckBox chkIqcFlag;
        private System.Windows.Forms.GroupBox grpStockLevel;
        private System.Windows.Forms.Label lblHEStockLevel;
        private System.Windows.Forms.Label lblHWStockLevel;
        private System.Windows.Forms.Label lblLWStockLevel;
        private System.Windows.Forms.Label lblLEStockLevel;
        private System.Windows.Forms.GroupBox grpDimension;
        private System.Windows.Forms.TextBox txtDimVtUnit;
        private System.Windows.Forms.TextBox txtDimHtUnit;
        private System.Windows.Forms.Label lblDimHtUnit;
        private System.Windows.Forms.Label lblDimHt;
        private System.Windows.Forms.TextBox txtDimHrUnit;
        private System.Windows.Forms.Label lblDimVtUnit;
        private System.Windows.Forms.Label lblDimVt;
        private System.Windows.Forms.Label lblDimHrUnit;
        private System.Windows.Forms.Label lblDimHr;
        private System.Windows.Forms.GroupBox grpWeight;
        private System.Windows.Forms.TextBox txtWetUnit;
        private System.Windows.Forms.Label lblWetUnit;
        private System.Windows.Forms.Label lblWetGross;
        private System.Windows.Forms.Label lblWetNet;
        private System.Windows.Forms.GroupBox grpVolume;
        private System.Windows.Forms.Label lblVolumeUnit;
        private System.Windows.Forms.TextBox txtVolumeUnit;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnDetach;
        private Miracom.UI.Controls.MCListView.MCListView lisFlow;
        private System.Windows.Forms.ColumnHeader colFlowAttachFlow;
        private System.Windows.Forms.ColumnHeader colFlowDesc;
        private System.Windows.Forms.Panel pnlGeneralRight;
        private System.Windows.Forms.GroupBox grpRelation;
        private System.Windows.Forms.TextBox txtMFGDevision;
        private System.Windows.Forms.Label lblMFGDevision;
        private System.Windows.Forms.CheckBox chkSubContractFlag;
        private System.Windows.Forms.TextBox txtCustomerMaterial;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtVendorMaterial;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.TextBox txtBaseMaterial;
        private System.Windows.Forms.Label lblCustomerMaterial;
        private System.Windows.Forms.Label lblVendorMaterial;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblBaseMaterial;
        private System.Windows.Forms.Panel pnlTarget;
        private System.Windows.Forms.GroupBox grpTarget;
        private System.Windows.Forms.Label lblTargetQty3;
        private System.Windows.Forms.Label lblTargetQty2;
        private System.Windows.Forms.Label lblTargetQty1;
        private System.Windows.Forms.Label lblTargetDueDay;
        private System.Windows.Forms.Label lblTargetYield;
        private System.Windows.Forms.Panel pnlAttachFlowMid;
        private System.Windows.Forms.ColumnHeader colFlowGroup;
        private Panel pnlFlowList;
        private Panel pnlFlowListTop;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOptionalGroup;
        private System.Windows.Forms.Label lblOptionalGroup;
        private Miracom.UI.Controls.MCListView.MCListView lisFlowList;
        private System.Windows.Forms.ColumnHeader colFlowList;
        private System.Windows.Forms.ColumnHeader colFlowDescription;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCustomer;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDefaultQty1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDefaultQty2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDefaultQty3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTargetQty3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTargetQty2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTargetQty1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTargetYield;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWetNet;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtWetGross;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtVolume;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDimHr;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDimVt;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtDimHt;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtPackLotCnt;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtPackQty;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLEStockLevel;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtLWStockLevel;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtHEStockLevel;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtHWStockLevel;
        private System.Windows.Forms.Button btnUndelete;
        private System.Windows.Forms.Label lblDeleteUser;
        private System.Windows.Forms.Label lblDeleteTime;
        private System.Windows.Forms.TextBox txtDeleteTime;
        private System.Windows.Forms.TextBox txtDeleteUser;
        private System.Windows.Forms.CheckBox chkDeleteFlag;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtTargetDueDay;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOptionalGroupOption;
        private System.Windows.Forms.Label lblOptionalGroupOption;
        private Miracom.MESCore.Controls.udcMaterialList udcMaterial;
        private Label lblVersion;
        private TextBox txtVersion;
        private CheckBox chkDeactiveFlag;
        private GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        protected Label lblCMF20;
        protected Label lblCMF19;
        protected Label lblCMF18;
        protected Label lblCMF17;
        protected Label lblCMF16;
        protected Label lblCMF15;
        protected Label lblCMF14;
        protected Label lblCMF13;
        protected Label lblCMF12;
        protected Label lblCMF11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected Label lblCMF10;
        protected Label lblCMF9;
        protected Label lblCMF8;
        protected Label lblCMF7;
        protected Label lblCMF6;
        protected Label lblCMF5;
        protected Label lblCMF4;
        protected Label lblCMF3;
        protected Label lblCMF2;
        protected Label lblCMF1;
        private Button btnVersionUp;
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Button btnDown;
        private Button btnUp;
        protected Button btnFlowExcel;
        private Label lblShortDesc;
        private TextBox txtShortDesc;
        private System.Windows.Forms.ColumnHeader colFlowGroupOption;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupMaterial));
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lblShortDesc = new System.Windows.Forms.Label();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabMaterial = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGeneralRight = new System.Windows.Forms.Panel();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.grpTarget = new System.Windows.Forms.GroupBox();
            this.txtTargetDueDay = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtTargetYield = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtTargetQty3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtTargetQty2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtTargetQty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblTargetQty3 = new System.Windows.Forms.Label();
            this.lblTargetQty2 = new System.Windows.Forms.Label();
            this.lblTargetQty1 = new System.Windows.Forms.Label();
            this.lblTargetDueDay = new System.Windows.Forms.Label();
            this.lblTargetYield = new System.Windows.Forms.Label();
            this.grpRelation = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtMFGDevision = new System.Windows.Forms.TextBox();
            this.lblMFGDevision = new System.Windows.Forms.Label();
            this.chkSubContractFlag = new System.Windows.Forms.CheckBox();
            this.txtCustomerMaterial = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtVendorMaterial = new System.Windows.Forms.TextBox();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.txtBaseMaterial = new System.Windows.Forms.TextBox();
            this.lblCustomerMaterial = new System.Windows.Forms.Label();
            this.lblVendorMaterial = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblBaseMaterial = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkDeactiveFlag = new System.Windows.Forms.CheckBox();
            this.chkDeleteFlag = new System.Windows.Forms.CheckBox();
            this.lblDeleteUser = new System.Windows.Forms.Label();
            this.txtDeleteTime = new System.Windows.Forms.TextBox();
            this.lblDeleteTime = new System.Windows.Forms.Label();
            this.txtDeleteUser = new System.Windows.Forms.TextBox();
            this.txtDefaultQty3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDefaultQty2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDefaultQty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMatType = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.cdvUnit3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDefaultQty3 = new System.Windows.Forms.Label();
            this.lblDefaultQty2 = new System.Windows.Forms.Label();
            this.lblDefaultQty1 = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.tbpProperty = new System.Windows.Forms.TabPage();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.txtPackQty = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtPackLotCnt = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cdvBomSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtDefStrOper = new System.Windows.Forms.TextBox();
            this.lblDefStrOper = new System.Windows.Forms.Label();
            this.lblBomSetId = new System.Windows.Forms.Label();
            this.cdvPackType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPackQty = new System.Windows.Forms.Label();
            this.lblPackLotCnt = new System.Windows.Forms.Label();
            this.lblPackType = new System.Windows.Forms.Label();
            this.grpOqc = new System.Windows.Forms.GroupBox();
            this.chkOqcSampleRule = new System.Windows.Forms.CheckBox();
            this.chkOqcSampleFlag = new System.Windows.Forms.CheckBox();
            this.chkOqcFlag = new System.Windows.Forms.CheckBox();
            this.grpIqc = new System.Windows.Forms.GroupBox();
            this.chkIqcSampleRule = new System.Windows.Forms.CheckBox();
            this.chkIqcSampleFlag = new System.Windows.Forms.CheckBox();
            this.chkIqcFlag = new System.Windows.Forms.CheckBox();
            this.grpStockLevel = new System.Windows.Forms.GroupBox();
            this.txtHWStockLevel = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtHEStockLevel = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtLWStockLevel = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtLEStockLevel = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblHEStockLevel = new System.Windows.Forms.Label();
            this.lblHWStockLevel = new System.Windows.Forms.Label();
            this.lblLWStockLevel = new System.Windows.Forms.Label();
            this.lblLEStockLevel = new System.Windows.Forms.Label();
            this.grpDimension = new System.Windows.Forms.GroupBox();
            this.txtDimHt = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDimVt = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDimHr = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDimVtUnit = new System.Windows.Forms.TextBox();
            this.txtDimHtUnit = new System.Windows.Forms.TextBox();
            this.lblDimHtUnit = new System.Windows.Forms.Label();
            this.lblDimHt = new System.Windows.Forms.Label();
            this.txtDimHrUnit = new System.Windows.Forms.TextBox();
            this.lblDimVtUnit = new System.Windows.Forms.Label();
            this.lblDimVt = new System.Windows.Forms.Label();
            this.lblDimHrUnit = new System.Windows.Forms.Label();
            this.lblDimHr = new System.Windows.Forms.Label();
            this.grpWeight = new System.Windows.Forms.GroupBox();
            this.txtWetGross = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWetNet = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtWetUnit = new System.Windows.Forms.TextBox();
            this.lblWetUnit = new System.Windows.Forms.Label();
            this.lblWetGross = new System.Windows.Forms.Label();
            this.lblWetNet = new System.Windows.Forms.Label();
            this.grpVolume = new System.Windows.Forms.GroupBox();
            this.txtVolume = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblVolumeUnit = new System.Windows.Forms.Label();
            this.txtVolumeUnit = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup10 = new System.Windows.Forms.Label();
            this.lblGroup9 = new System.Windows.Forms.Label();
            this.lblGroup8 = new System.Windows.Forms.Label();
            this.lblGroup7 = new System.Windows.Forms.Label();
            this.lblGroup6 = new System.Windows.Forms.Label();
            this.lblGroup5 = new System.Windows.Forms.Label();
            this.lblGroup4 = new System.Windows.Forms.Label();
            this.lblGroup3 = new System.Windows.Forms.Label();
            this.lblGroup2 = new System.Windows.Forms.Label();
            this.lblGroup1 = new System.Windows.Forms.Label();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpCmf = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.tbpFlow = new System.Windows.Forms.TabPage();
            this.pnlAttachFlowMid = new System.Windows.Forms.Panel();
            this.btnFlowExcel = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.pnlFlowList = new System.Windows.Forms.Panel();
            this.lisFlowList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colFlowList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFlowListTop = new System.Windows.Forms.Panel();
            this.cdvOptionalGroupOption = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOptionalGroupOption = new System.Windows.Forms.Label();
            this.cdvOptionalGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOptionalGroup = new System.Windows.Forms.Label();
            this.lisFlow = new Miracom.UI.Controls.MCListView.MCListView();
            this.colFlowAttachFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowGroupOption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUndelete = new System.Windows.Forms.Button();
            this.udcMaterial = new Miracom.MESCore.Controls.udcMaterialList();
            this.btnVersionUp = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabMaterial.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralRight.SuspendLayout();
            this.pnlTarget.SuspendLayout();
            this.grpTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetDueDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetYield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty1)).BeginInit();
            this.grpRelation.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1)).BeginInit();
            this.tbpProperty.SuspendLayout();
            this.grp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackLotCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBomSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPackType)).BeginInit();
            this.grpOqc.SuspendLayout();
            this.grpIqc.SuspendLayout();
            this.grpStockLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHWStockLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHEStockLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLWStockLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLEStockLevel)).BeginInit();
            this.grpDimension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimHt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimVt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimHr)).BeginInit();
            this.grpWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWetGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWetNet)).BeginInit();
            this.grpVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).BeginInit();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.tbpAttribute.SuspendLayout();
            this.tbpCmf.SuspendLayout();
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
            this.tbpFlow.SuspendLayout();
            this.pnlAttachFlowMid.SuspendLayout();
            this.pnlFlowList.SuspendLayout();
            this.pnlFlowListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroupOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
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
            this.txtFind.MaxLength = 30;
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpTop);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.udcMaterial);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Controls.Add(this.btnVersionUp);
            this.pnlBottom.Controls.Add(this.btnUndelete);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnUndelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnVersionUp, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Material Setup";
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.lblShortDesc);
            this.grpTop.Controls.Add(this.txtShortDesc);
            this.grpTop.Controls.Add(this.lblVersion);
            this.grpTop.Controls.Add(this.txtVersion);
            this.grpTop.Controls.Add(this.lblDesc);
            this.grpTop.Controls.Add(this.lblMaterial);
            this.grpTop.Controls.Add(this.txtDesc);
            this.grpTop.Controls.Add(this.txtMaterial);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(500, 91);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // lblShortDesc
            // 
            this.lblShortDesc.AutoSize = true;
            this.lblShortDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShortDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortDesc.Location = new System.Drawing.Point(15, 43);
            this.lblShortDesc.Name = "lblShortDesc";
            this.lblShortDesc.Size = new System.Drawing.Size(88, 13);
            this.lblShortDesc.TabIndex = 4;
            this.lblShortDesc.Text = "Short Description";
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortDesc.Location = new System.Drawing.Point(120, 40);
            this.txtShortDesc.MaxLength = 50;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.Size = new System.Drawing.Size(368, 20);
            this.txtShortDesc.TabIndex = 5;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(355, 19);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(431, 16);
            this.txtVersion.MaxLength = 6;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(57, 20);
            this.txtVersion.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(15, 19);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(52, 13);
            this.lblMaterial.TabIndex = 0;
            this.lblMaterial.Text = "Material";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 64);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(120, 16);
            this.txtMaterial.MaxLength = 30;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(200, 20);
            this.txtMaterial.TabIndex = 1;
            this.txtMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterial_KeyPress);
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabMaterial);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 91);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 422);
            this.pnlTab.TabIndex = 1;
            // 
            // tabMaterial
            // 
            this.tabMaterial.Controls.Add(this.tbpGeneral);
            this.tabMaterial.Controls.Add(this.tbpProperty);
            this.tabMaterial.Controls.Add(this.tbpGroup);
            this.tabMaterial.Controls.Add(this.tbpAttribute);
            this.tabMaterial.Controls.Add(this.tbpCmf);
            this.tabMaterial.Controls.Add(this.tbpFlow);
            this.tabMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMaterial.ItemSize = new System.Drawing.Size(60, 18);
            this.tabMaterial.Location = new System.Drawing.Point(0, 5);
            this.tabMaterial.Name = "tabMaterial";
            this.tabMaterial.SelectedIndex = 0;
            this.tabMaterial.Size = new System.Drawing.Size(500, 417);
            this.tabMaterial.TabIndex = 0;
            this.tabMaterial.SelectedIndexChanged += new System.EventHandler(this.tabMaterial_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGeneralRight);
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 0, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 391);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGeneralRight
            // 
            this.pnlGeneralRight.Controls.Add(this.pnlTarget);
            this.pnlGeneralRight.Controls.Add(this.grpRelation);
            this.pnlGeneralRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneralRight.Location = new System.Drawing.Point(243, 5);
            this.pnlGeneralRight.Name = "pnlGeneralRight";
            this.pnlGeneralRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGeneralRight.Size = new System.Drawing.Size(249, 383);
            this.pnlGeneralRight.TabIndex = 1;
            // 
            // pnlTarget
            // 
            this.pnlTarget.Controls.Add(this.grpTarget);
            this.pnlTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarget.Location = new System.Drawing.Point(3, 212);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTarget.Size = new System.Drawing.Size(243, 171);
            this.pnlTarget.TabIndex = 4;
            // 
            // grpTarget
            // 
            this.grpTarget.Controls.Add(this.txtTargetDueDay);
            this.grpTarget.Controls.Add(this.txtTargetYield);
            this.grpTarget.Controls.Add(this.txtTargetQty3);
            this.grpTarget.Controls.Add(this.txtTargetQty2);
            this.grpTarget.Controls.Add(this.txtTargetQty1);
            this.grpTarget.Controls.Add(this.lblTargetQty3);
            this.grpTarget.Controls.Add(this.lblTargetQty2);
            this.grpTarget.Controls.Add(this.lblTargetQty1);
            this.grpTarget.Controls.Add(this.lblTargetDueDay);
            this.grpTarget.Controls.Add(this.lblTargetYield);
            this.grpTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTarget.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpTarget.Location = new System.Drawing.Point(0, 5);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Size = new System.Drawing.Size(243, 166);
            this.grpTarget.TabIndex = 0;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "Target";
            // 
            // txtTargetDueDay
            // 
            this.txtTargetDueDay.Location = new System.Drawing.Point(132, 45);
            this.txtTargetDueDay.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetDueDay.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetDueDay.MaskInput = "nnnnnnnn.nn";
            this.txtTargetDueDay.Name = "txtTargetDueDay";
            this.txtTargetDueDay.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtTargetDueDay.PromptChar = ' ';
            this.txtTargetDueDay.Size = new System.Drawing.Size(104, 21);
            this.txtTargetDueDay.TabIndex = 3;
            // 
            // txtTargetYield
            // 
            this.txtTargetYield.Location = new System.Drawing.Point(132, 20);
            this.txtTargetYield.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetYield.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetYield.MaskInput = "nnnnnnnn.nn";
            this.txtTargetYield.Name = "txtTargetYield";
            this.txtTargetYield.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtTargetYield.PromptChar = ' ';
            this.txtTargetYield.Size = new System.Drawing.Size(104, 21);
            this.txtTargetYield.TabIndex = 1;
            // 
            // txtTargetQty3
            // 
            this.txtTargetQty3.Location = new System.Drawing.Point(132, 120);
            this.txtTargetQty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty3.MaskInput = "nnnnnnn.nnn";
            this.txtTargetQty3.Name = "txtTargetQty3";
            this.txtTargetQty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtTargetQty3.PromptChar = ' ';
            this.txtTargetQty3.Size = new System.Drawing.Size(104, 21);
            this.txtTargetQty3.TabIndex = 9;
            // 
            // txtTargetQty2
            // 
            this.txtTargetQty2.Location = new System.Drawing.Point(132, 95);
            this.txtTargetQty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty2.MaskInput = "nnnnnnn.nnn";
            this.txtTargetQty2.Name = "txtTargetQty2";
            this.txtTargetQty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtTargetQty2.PromptChar = ' ';
            this.txtTargetQty2.Size = new System.Drawing.Size(104, 21);
            this.txtTargetQty2.TabIndex = 7;
            // 
            // txtTargetQty1
            // 
            this.txtTargetQty1.Location = new System.Drawing.Point(132, 70);
            this.txtTargetQty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtTargetQty1.MaskInput = "nnnnnnn.nnn";
            this.txtTargetQty1.Name = "txtTargetQty1";
            this.txtTargetQty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtTargetQty1.PromptChar = ' ';
            this.txtTargetQty1.Size = new System.Drawing.Size(104, 21);
            this.txtTargetQty1.TabIndex = 5;
            // 
            // lblTargetQty3
            // 
            this.lblTargetQty3.AutoSize = true;
            this.lblTargetQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetQty3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetQty3.Location = new System.Drawing.Point(8, 123);
            this.lblTargetQty3.Name = "lblTargetQty3";
            this.lblTargetQty3.Size = new System.Drawing.Size(66, 13);
            this.lblTargetQty3.TabIndex = 8;
            this.lblTargetQty3.Text = "Target Qty 3";
            // 
            // lblTargetQty2
            // 
            this.lblTargetQty2.AutoSize = true;
            this.lblTargetQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetQty2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetQty2.Location = new System.Drawing.Point(8, 98);
            this.lblTargetQty2.Name = "lblTargetQty2";
            this.lblTargetQty2.Size = new System.Drawing.Size(66, 13);
            this.lblTargetQty2.TabIndex = 6;
            this.lblTargetQty2.Text = "Target Qty 2";
            // 
            // lblTargetQty1
            // 
            this.lblTargetQty1.AutoSize = true;
            this.lblTargetQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetQty1.Location = new System.Drawing.Point(8, 73);
            this.lblTargetQty1.Name = "lblTargetQty1";
            this.lblTargetQty1.Size = new System.Drawing.Size(66, 13);
            this.lblTargetQty1.TabIndex = 4;
            this.lblTargetQty1.Text = "Target Qty 1";
            // 
            // lblTargetDueDay
            // 
            this.lblTargetDueDay.AutoSize = true;
            this.lblTargetDueDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetDueDay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetDueDay.Location = new System.Drawing.Point(8, 48);
            this.lblTargetDueDay.Name = "lblTargetDueDay";
            this.lblTargetDueDay.Size = new System.Drawing.Size(83, 13);
            this.lblTargetDueDay.TabIndex = 2;
            this.lblTargetDueDay.Text = "Target Due Day";
            // 
            // lblTargetYield
            // 
            this.lblTargetYield.AutoSize = true;
            this.lblTargetYield.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetYield.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetYield.Location = new System.Drawing.Point(8, 23);
            this.lblTargetYield.Name = "lblTargetYield";
            this.lblTargetYield.Size = new System.Drawing.Size(64, 13);
            this.lblTargetYield.TabIndex = 0;
            this.lblTargetYield.Text = "Target Yield";
            // 
            // grpRelation
            // 
            this.grpRelation.Controls.Add(this.lblCustomer);
            this.grpRelation.Controls.Add(this.txtMFGDevision);
            this.grpRelation.Controls.Add(this.lblMFGDevision);
            this.grpRelation.Controls.Add(this.chkSubContractFlag);
            this.grpRelation.Controls.Add(this.txtCustomerMaterial);
            this.grpRelation.Controls.Add(this.txtCustomer);
            this.grpRelation.Controls.Add(this.txtVendorMaterial);
            this.grpRelation.Controls.Add(this.txtVendor);
            this.grpRelation.Controls.Add(this.txtBaseMaterial);
            this.grpRelation.Controls.Add(this.lblCustomerMaterial);
            this.grpRelation.Controls.Add(this.lblVendorMaterial);
            this.grpRelation.Controls.Add(this.lblVendor);
            this.grpRelation.Controls.Add(this.lblBaseMaterial);
            this.grpRelation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRelation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRelation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpRelation.Location = new System.Drawing.Point(3, 0);
            this.grpRelation.Name = "grpRelation";
            this.grpRelation.Size = new System.Drawing.Size(243, 212);
            this.grpRelation.TabIndex = 0;
            this.grpRelation.TabStop = false;
            this.grpRelation.Text = "Relation";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomer.Location = new System.Drawing.Point(8, 95);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Customer";
            // 
            // txtMFGDevision
            // 
            this.txtMFGDevision.Location = new System.Drawing.Point(132, 140);
            this.txtMFGDevision.MaxLength = 20;
            this.txtMFGDevision.Name = "txtMFGDevision";
            this.txtMFGDevision.Size = new System.Drawing.Size(104, 20);
            this.txtMFGDevision.TabIndex = 11;
            // 
            // lblMFGDevision
            // 
            this.lblMFGDevision.AutoSize = true;
            this.lblMFGDevision.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMFGDevision.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMFGDevision.Location = new System.Drawing.Point(8, 143);
            this.lblMFGDevision.Name = "lblMFGDevision";
            this.lblMFGDevision.Size = new System.Drawing.Size(70, 13);
            this.lblMFGDevision.TabIndex = 10;
            this.lblMFGDevision.Text = "MFG Division";
            // 
            // chkSubContractFlag
            // 
            this.chkSubContractFlag.AutoSize = true;
            this.chkSubContractFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSubContractFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSubContractFlag.Location = new System.Drawing.Point(8, 167);
            this.chkSubContractFlag.Name = "chkSubContractFlag";
            this.chkSubContractFlag.Size = new System.Drawing.Size(114, 18);
            this.chkSubContractFlag.TabIndex = 12;
            this.chkSubContractFlag.Text = "SubContract Flag";
            // 
            // txtCustomerMaterial
            // 
            this.txtCustomerMaterial.Location = new System.Drawing.Point(132, 116);
            this.txtCustomerMaterial.MaxLength = 30;
            this.txtCustomerMaterial.Name = "txtCustomerMaterial";
            this.txtCustomerMaterial.Size = new System.Drawing.Size(104, 20);
            this.txtCustomerMaterial.TabIndex = 9;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(132, 92);
            this.txtCustomer.MaxLength = 20;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(104, 20);
            this.txtCustomer.TabIndex = 7;
            // 
            // txtVendorMaterial
            // 
            this.txtVendorMaterial.Location = new System.Drawing.Point(132, 68);
            this.txtVendorMaterial.MaxLength = 30;
            this.txtVendorMaterial.Name = "txtVendorMaterial";
            this.txtVendorMaterial.Size = new System.Drawing.Size(104, 20);
            this.txtVendorMaterial.TabIndex = 5;
            // 
            // txtVendor
            // 
            this.txtVendor.Location = new System.Drawing.Point(132, 44);
            this.txtVendor.MaxLength = 20;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(104, 20);
            this.txtVendor.TabIndex = 3;
            // 
            // txtBaseMaterial
            // 
            this.txtBaseMaterial.Location = new System.Drawing.Point(132, 20);
            this.txtBaseMaterial.MaxLength = 30;
            this.txtBaseMaterial.Name = "txtBaseMaterial";
            this.txtBaseMaterial.Size = new System.Drawing.Size(104, 20);
            this.txtBaseMaterial.TabIndex = 1;
            // 
            // lblCustomerMaterial
            // 
            this.lblCustomerMaterial.AutoSize = true;
            this.lblCustomerMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomerMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomerMaterial.Location = new System.Drawing.Point(8, 119);
            this.lblCustomerMaterial.Name = "lblCustomerMaterial";
            this.lblCustomerMaterial.Size = new System.Drawing.Size(91, 13);
            this.lblCustomerMaterial.TabIndex = 8;
            this.lblCustomerMaterial.Text = "Customer Material";
            // 
            // lblVendorMaterial
            // 
            this.lblVendorMaterial.AutoSize = true;
            this.lblVendorMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVendorMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVendorMaterial.Location = new System.Drawing.Point(8, 71);
            this.lblVendorMaterial.Name = "lblVendorMaterial";
            this.lblVendorMaterial.Size = new System.Drawing.Size(81, 13);
            this.lblVendorMaterial.TabIndex = 4;
            this.lblVendorMaterial.Text = "Vendor Material";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVendor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVendor.Location = new System.Drawing.Point(8, 47);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 2;
            this.lblVendor.Text = "Vendor";
            // 
            // lblBaseMaterial
            // 
            this.lblBaseMaterial.AutoSize = true;
            this.lblBaseMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBaseMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBaseMaterial.Location = new System.Drawing.Point(8, 23);
            this.lblBaseMaterial.Name = "lblBaseMaterial";
            this.lblBaseMaterial.Size = new System.Drawing.Size(71, 13);
            this.lblBaseMaterial.TabIndex = 0;
            this.lblBaseMaterial.Text = "Base Material";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkDeactiveFlag);
            this.grpGeneral.Controls.Add(this.chkDeleteFlag);
            this.grpGeneral.Controls.Add(this.lblDeleteUser);
            this.grpGeneral.Controls.Add(this.txtDeleteTime);
            this.grpGeneral.Controls.Add(this.lblDeleteTime);
            this.grpGeneral.Controls.Add(this.txtDeleteUser);
            this.grpGeneral.Controls.Add(this.txtDefaultQty3);
            this.grpGeneral.Controls.Add(this.txtDefaultQty2);
            this.grpGeneral.Controls.Add(this.txtDefaultQty1);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.cdvType);
            this.grpGeneral.Controls.Add(this.lblMatType);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.cdvUnit3);
            this.grpGeneral.Controls.Add(this.cdvUnit2);
            this.grpGeneral.Controls.Add(this.cdvUnit1);
            this.grpGeneral.Controls.Add(this.lblDefaultQty3);
            this.grpGeneral.Controls.Add(this.lblDefaultQty2);
            this.grpGeneral.Controls.Add(this.lblDefaultQty1);
            this.grpGeneral.Controls.Add(this.lblUnit3);
            this.grpGeneral.Controls.Add(this.lblUnit2);
            this.grpGeneral.Controls.Add(this.lblUnit1);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(240, 383);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // chkDeactiveFlag
            // 
            this.chkDeactiveFlag.AutoSize = true;
            this.chkDeactiveFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeactiveFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDeactiveFlag.Location = new System.Drawing.Point(8, 373);
            this.chkDeactiveFlag.Name = "chkDeactiveFlag";
            this.chkDeactiveFlag.Size = new System.Drawing.Size(98, 18);
            this.chkDeactiveFlag.TabIndex = 27;
            this.chkDeactiveFlag.Text = "Deactive Flag";
            // 
            // chkDeleteFlag
            // 
            this.chkDeleteFlag.AutoSize = true;
            this.chkDeleteFlag.Enabled = false;
            this.chkDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeleteFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDeleteFlag.Location = new System.Drawing.Point(8, 350);
            this.chkDeleteFlag.Name = "chkDeleteFlag";
            this.chkDeleteFlag.Size = new System.Drawing.Size(86, 18);
            this.chkDeleteFlag.TabIndex = 26;
            this.chkDeleteFlag.Text = "Delete Flag";
            // 
            // lblDeleteUser
            // 
            this.lblDeleteUser.AutoSize = true;
            this.lblDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDeleteUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeleteUser.Location = new System.Drawing.Point(8, 308);
            this.lblDeleteUser.Name = "lblDeleteUser";
            this.lblDeleteUser.Size = new System.Drawing.Size(63, 13);
            this.lblDeleteUser.TabIndex = 22;
            this.lblDeleteUser.Text = "Delete User";
            // 
            // txtDeleteTime
            // 
            this.txtDeleteTime.Location = new System.Drawing.Point(116, 328);
            this.txtDeleteTime.MaxLength = 30;
            this.txtDeleteTime.Name = "txtDeleteTime";
            this.txtDeleteTime.ReadOnly = true;
            this.txtDeleteTime.Size = new System.Drawing.Size(116, 20);
            this.txtDeleteTime.TabIndex = 25;
            this.txtDeleteTime.TabStop = false;
            // 
            // lblDeleteTime
            // 
            this.lblDeleteTime.AutoSize = true;
            this.lblDeleteTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDeleteTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeleteTime.Location = new System.Drawing.Point(8, 332);
            this.lblDeleteTime.Name = "lblDeleteTime";
            this.lblDeleteTime.Size = new System.Drawing.Size(64, 13);
            this.lblDeleteTime.TabIndex = 24;
            this.lblDeleteTime.Text = "Delete Time";
            // 
            // txtDeleteUser
            // 
            this.txtDeleteUser.Location = new System.Drawing.Point(116, 304);
            this.txtDeleteUser.MaxLength = 20;
            this.txtDeleteUser.Name = "txtDeleteUser";
            this.txtDeleteUser.ReadOnly = true;
            this.txtDeleteUser.Size = new System.Drawing.Size(116, 20);
            this.txtDeleteUser.TabIndex = 23;
            this.txtDeleteUser.TabStop = false;
            // 
            // txtDefaultQty3
            // 
            this.txtDefaultQty3.Location = new System.Drawing.Point(116, 178);
            this.txtDefaultQty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty3.MaskInput = "nnnnnnn.nnn";
            this.txtDefaultQty3.Name = "txtDefaultQty3";
            this.txtDefaultQty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDefaultQty3.PromptChar = ' ';
            this.txtDefaultQty3.Size = new System.Drawing.Size(116, 21);
            this.txtDefaultQty3.TabIndex = 13;
            // 
            // txtDefaultQty2
            // 
            this.txtDefaultQty2.Location = new System.Drawing.Point(116, 153);
            this.txtDefaultQty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty2.MaskInput = "nnnnnnn.nnn";
            this.txtDefaultQty2.Name = "txtDefaultQty2";
            this.txtDefaultQty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDefaultQty2.PromptChar = ' ';
            this.txtDefaultQty2.Size = new System.Drawing.Size(116, 21);
            this.txtDefaultQty2.TabIndex = 11;
            // 
            // txtDefaultQty1
            // 
            this.txtDefaultQty1.Location = new System.Drawing.Point(116, 128);
            this.txtDefaultQty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDefaultQty1.MaskInput = "nnnnnnn.nnn";
            this.txtDefaultQty1.Name = "txtDefaultQty1";
            this.txtDefaultQty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDefaultQty1.PromptChar = ' ';
            this.txtDefaultQty1.Size = new System.Drawing.Size(116, 21);
            this.txtDefaultQty1.TabIndex = 9;
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(8, 259);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 18;
            this.lblUpdateUser.Text = "Update User";
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.ButtonWidth = 20;
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = 0;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(116, 20);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.MultiSelect = false;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SameWidthHeightOfButton = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedDescToQueryText = "";
            this.cdvType.SelectedSubItemIndex = 0;
            this.cdvType.SelectedValueToQueryText = "";
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(116, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 116;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblMatType
            // 
            this.lblMatType.AutoSize = true;
            this.lblMatType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMatType.Location = new System.Drawing.Point(8, 23);
            this.lblMatType.Name = "lblMatType";
            this.lblMatType.Size = new System.Drawing.Size(84, 13);
            this.lblMatType.TabIndex = 0;
            this.lblMatType.Text = "Material Type";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(116, 280);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateTime.TabIndex = 21;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(8, 283);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 20;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(116, 256);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateUser.TabIndex = 19;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(8, 211);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 14;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(116, 232);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(116, 20);
            this.txtCreateTime.TabIndex = 17;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(8, 235);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 16;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(116, 208);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(116, 20);
            this.txtCreateUser.TabIndex = 15;
            this.txtCreateUser.TabStop = false;
            // 
            // cdvUnit3
            // 
            this.cdvUnit3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3.BtnToolTipText = "";
            this.cdvUnit3.ButtonWidth = 20;
            this.cdvUnit3.DescText = "";
            this.cdvUnit3.DisplaySubItemIndex = -1;
            this.cdvUnit3.DisplayText = "";
            this.cdvUnit3.Focusing = null;
            this.cdvUnit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3.Index = 0;
            this.cdvUnit3.IsViewBtnImage = false;
            this.cdvUnit3.Location = new System.Drawing.Point(116, 98);
            this.cdvUnit3.MaxLength = 10;
            this.cdvUnit3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3.MultiSelect = false;
            this.cdvUnit3.Name = "cdvUnit3";
            this.cdvUnit3.ReadOnly = false;
            this.cdvUnit3.SameWidthHeightOfButton = false;
            this.cdvUnit3.SearchSubItemIndex = 0;
            this.cdvUnit3.SelectedDescIndex = -1;
            this.cdvUnit3.SelectedDescToQueryText = "";
            this.cdvUnit3.SelectedSubItemIndex = -1;
            this.cdvUnit3.SelectedValueToQueryText = "";
            this.cdvUnit3.SelectionStart = 0;
            this.cdvUnit3.Size = new System.Drawing.Size(116, 20);
            this.cdvUnit3.SmallImageList = null;
            this.cdvUnit3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3.TabIndex = 7;
            this.cdvUnit3.TextBoxToolTipText = "";
            this.cdvUnit3.TextBoxWidth = 116;
            this.cdvUnit3.VisibleButton = true;
            this.cdvUnit3.VisibleColumnHeader = false;
            this.cdvUnit3.VisibleDescription = false;
            this.cdvUnit3.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // cdvUnit2
            // 
            this.cdvUnit2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2.BtnToolTipText = "";
            this.cdvUnit2.ButtonWidth = 20;
            this.cdvUnit2.DescText = "";
            this.cdvUnit2.DisplaySubItemIndex = -1;
            this.cdvUnit2.DisplayText = "";
            this.cdvUnit2.Focusing = null;
            this.cdvUnit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2.Index = 0;
            this.cdvUnit2.IsViewBtnImage = false;
            this.cdvUnit2.Location = new System.Drawing.Point(116, 74);
            this.cdvUnit2.MaxLength = 10;
            this.cdvUnit2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2.MultiSelect = false;
            this.cdvUnit2.Name = "cdvUnit2";
            this.cdvUnit2.ReadOnly = false;
            this.cdvUnit2.SameWidthHeightOfButton = false;
            this.cdvUnit2.SearchSubItemIndex = 0;
            this.cdvUnit2.SelectedDescIndex = -1;
            this.cdvUnit2.SelectedDescToQueryText = "";
            this.cdvUnit2.SelectedSubItemIndex = -1;
            this.cdvUnit2.SelectedValueToQueryText = "";
            this.cdvUnit2.SelectionStart = 0;
            this.cdvUnit2.Size = new System.Drawing.Size(116, 20);
            this.cdvUnit2.SmallImageList = null;
            this.cdvUnit2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2.TabIndex = 5;
            this.cdvUnit2.TextBoxToolTipText = "";
            this.cdvUnit2.TextBoxWidth = 116;
            this.cdvUnit2.VisibleButton = true;
            this.cdvUnit2.VisibleColumnHeader = false;
            this.cdvUnit2.VisibleDescription = false;
            this.cdvUnit2.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // cdvUnit1
            // 
            this.cdvUnit1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1.BtnToolTipText = "";
            this.cdvUnit1.ButtonWidth = 20;
            this.cdvUnit1.DescText = "";
            this.cdvUnit1.DisplaySubItemIndex = 0;
            this.cdvUnit1.DisplayText = "";
            this.cdvUnit1.Focusing = null;
            this.cdvUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1.Index = 0;
            this.cdvUnit1.IsViewBtnImage = false;
            this.cdvUnit1.Location = new System.Drawing.Point(116, 50);
            this.cdvUnit1.MaxLength = 10;
            this.cdvUnit1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1.MultiSelect = false;
            this.cdvUnit1.Name = "cdvUnit1";
            this.cdvUnit1.ReadOnly = false;
            this.cdvUnit1.SameWidthHeightOfButton = false;
            this.cdvUnit1.SearchSubItemIndex = 0;
            this.cdvUnit1.SelectedDescIndex = -1;
            this.cdvUnit1.SelectedDescToQueryText = "";
            this.cdvUnit1.SelectedSubItemIndex = 0;
            this.cdvUnit1.SelectedValueToQueryText = "";
            this.cdvUnit1.SelectionStart = 0;
            this.cdvUnit1.Size = new System.Drawing.Size(116, 20);
            this.cdvUnit1.SmallImageList = null;
            this.cdvUnit1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1.TabIndex = 3;
            this.cdvUnit1.TextBoxToolTipText = "";
            this.cdvUnit1.TextBoxWidth = 116;
            this.cdvUnit1.VisibleButton = true;
            this.cdvUnit1.VisibleColumnHeader = false;
            this.cdvUnit1.VisibleDescription = false;
            this.cdvUnit1.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // lblDefaultQty3
            // 
            this.lblDefaultQty3.AutoSize = true;
            this.lblDefaultQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefaultQty3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultQty3.Location = new System.Drawing.Point(8, 181);
            this.lblDefaultQty3.Name = "lblDefaultQty3";
            this.lblDefaultQty3.Size = new System.Drawing.Size(69, 13);
            this.lblDefaultQty3.TabIndex = 12;
            this.lblDefaultQty3.Text = "Default Qty 3";
            // 
            // lblDefaultQty2
            // 
            this.lblDefaultQty2.AutoSize = true;
            this.lblDefaultQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefaultQty2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultQty2.Location = new System.Drawing.Point(8, 156);
            this.lblDefaultQty2.Name = "lblDefaultQty2";
            this.lblDefaultQty2.Size = new System.Drawing.Size(69, 13);
            this.lblDefaultQty2.TabIndex = 10;
            this.lblDefaultQty2.Text = "Default Qty 2";
            // 
            // lblDefaultQty1
            // 
            this.lblDefaultQty1.AutoSize = true;
            this.lblDefaultQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefaultQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultQty1.Location = new System.Drawing.Point(8, 131);
            this.lblDefaultQty1.Name = "lblDefaultQty1";
            this.lblDefaultQty1.Size = new System.Drawing.Size(69, 13);
            this.lblDefaultQty1.TabIndex = 8;
            this.lblDefaultQty1.Text = "Default Qty 1";
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit3.Location = new System.Drawing.Point(8, 101);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(35, 13);
            this.lblUnit3.TabIndex = 6;
            this.lblUnit3.Text = "Unit 3";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit2.Location = new System.Drawing.Point(8, 77);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(35, 13);
            this.lblUnit2.TabIndex = 4;
            this.lblUnit2.Text = "Unit 2";
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit1.Location = new System.Drawing.Point(8, 53);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(41, 13);
            this.lblUnit1.TabIndex = 2;
            this.lblUnit1.Text = "Unit 1";
            // 
            // tbpProperty
            // 
            this.tbpProperty.Controls.Add(this.grp1);
            this.tbpProperty.Controls.Add(this.grpOqc);
            this.tbpProperty.Controls.Add(this.grpIqc);
            this.tbpProperty.Controls.Add(this.grpStockLevel);
            this.tbpProperty.Controls.Add(this.grpDimension);
            this.tbpProperty.Controls.Add(this.grpWeight);
            this.tbpProperty.Controls.Add(this.grpVolume);
            this.tbpProperty.Location = new System.Drawing.Point(4, 22);
            this.tbpProperty.Name = "tbpProperty";
            this.tbpProperty.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpProperty.Size = new System.Drawing.Size(492, 384);
            this.tbpProperty.TabIndex = 1;
            this.tbpProperty.Text = "Properties";
            this.tbpProperty.Visible = false;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.txtPackQty);
            this.grp1.Controls.Add(this.txtPackLotCnt);
            this.grp1.Controls.Add(this.cdvBomSetID);
            this.grp1.Controls.Add(this.txtDefStrOper);
            this.grp1.Controls.Add(this.lblDefStrOper);
            this.grp1.Controls.Add(this.lblBomSetId);
            this.grp1.Controls.Add(this.cdvPackType);
            this.grp1.Controls.Add(this.lblPackQty);
            this.grp1.Controls.Add(this.lblPackLotCnt);
            this.grp1.Controls.Add(this.lblPackType);
            this.grp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grp1.Location = new System.Drawing.Point(250, 5);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(239, 156);
            this.grp1.TabIndex = 3;
            this.grp1.TabStop = false;
            // 
            // txtPackQty
            // 
            this.txtPackQty.Location = new System.Drawing.Point(112, 70);
            this.txtPackQty.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPackQty.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPackQty.MaskInput = "nnnnnnn.nnn";
            this.txtPackQty.Name = "txtPackQty";
            this.txtPackQty.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtPackQty.PromptChar = ' ';
            this.txtPackQty.Size = new System.Drawing.Size(122, 21);
            this.txtPackQty.TabIndex = 5;
            // 
            // txtPackLotCnt
            // 
            this.txtPackLotCnt.Location = new System.Drawing.Point(112, 45);
            this.txtPackLotCnt.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPackLotCnt.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPackLotCnt.MaskInput = "nnnnnnnnnn";
            this.txtPackLotCnt.Name = "txtPackLotCnt";
            this.txtPackLotCnt.PromptChar = ' ';
            this.txtPackLotCnt.Size = new System.Drawing.Size(122, 21);
            this.txtPackLotCnt.TabIndex = 3;
            // 
            // cdvBomSetID
            // 
            this.cdvBomSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBomSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBomSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBomSetID.BtnToolTipText = "";
            this.cdvBomSetID.ButtonWidth = 20;
            this.cdvBomSetID.DescText = "";
            this.cdvBomSetID.DisplaySubItemIndex = -1;
            this.cdvBomSetID.DisplayText = "";
            this.cdvBomSetID.Focusing = null;
            this.cdvBomSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBomSetID.Index = 0;
            this.cdvBomSetID.IsViewBtnImage = false;
            this.cdvBomSetID.Location = new System.Drawing.Point(112, 94);
            this.cdvBomSetID.MaxLength = 25;
            this.cdvBomSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBomSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBomSetID.MultiSelect = false;
            this.cdvBomSetID.Name = "cdvBomSetID";
            this.cdvBomSetID.ReadOnly = false;
            this.cdvBomSetID.SameWidthHeightOfButton = false;
            this.cdvBomSetID.SearchSubItemIndex = 0;
            this.cdvBomSetID.SelectedDescIndex = -1;
            this.cdvBomSetID.SelectedDescToQueryText = "";
            this.cdvBomSetID.SelectedSubItemIndex = -1;
            this.cdvBomSetID.SelectedValueToQueryText = "";
            this.cdvBomSetID.SelectionStart = 0;
            this.cdvBomSetID.Size = new System.Drawing.Size(122, 20);
            this.cdvBomSetID.SmallImageList = null;
            this.cdvBomSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBomSetID.TabIndex = 7;
            this.cdvBomSetID.TextBoxToolTipText = "";
            this.cdvBomSetID.TextBoxWidth = 122;
            this.cdvBomSetID.VisibleButton = true;
            this.cdvBomSetID.VisibleColumnHeader = false;
            this.cdvBomSetID.VisibleDescription = false;
            this.cdvBomSetID.ButtonPress += new System.EventHandler(this.cdvBomSetID_ButtonPress);
            // 
            // txtDefStrOper
            // 
            this.txtDefStrOper.Location = new System.Drawing.Point(112, 118);
            this.txtDefStrOper.MaxLength = 10;
            this.txtDefStrOper.Name = "txtDefStrOper";
            this.txtDefStrOper.Size = new System.Drawing.Size(122, 20);
            this.txtDefStrOper.TabIndex = 9;
            // 
            // lblDefStrOper
            // 
            this.lblDefStrOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefStrOper.Location = new System.Drawing.Point(8, 118);
            this.lblDefStrOper.Name = "lblDefStrOper";
            this.lblDefStrOper.Size = new System.Drawing.Size(100, 28);
            this.lblDefStrOper.TabIndex = 8;
            this.lblDefStrOper.Text = "Default Inv Operation";
            this.lblDefStrOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBomSetId
            // 
            this.lblBomSetId.AutoSize = true;
            this.lblBomSetId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBomSetId.Location = new System.Drawing.Point(8, 97);
            this.lblBomSetId.Name = "lblBomSetId";
            this.lblBomSetId.Size = new System.Drawing.Size(64, 13);
            this.lblBomSetId.TabIndex = 6;
            this.lblBomSetId.Text = "BOM Set ID";
            // 
            // cdvPackType
            // 
            this.cdvPackType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPackType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPackType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPackType.BtnToolTipText = "";
            this.cdvPackType.ButtonWidth = 20;
            this.cdvPackType.DescText = "";
            this.cdvPackType.DisplaySubItemIndex = 0;
            this.cdvPackType.DisplayText = "";
            this.cdvPackType.Focusing = null;
            this.cdvPackType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPackType.Index = 0;
            this.cdvPackType.IsViewBtnImage = false;
            this.cdvPackType.Location = new System.Drawing.Point(112, 20);
            this.cdvPackType.MaxLength = 1;
            this.cdvPackType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPackType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPackType.MultiSelect = false;
            this.cdvPackType.Name = "cdvPackType";
            this.cdvPackType.ReadOnly = false;
            this.cdvPackType.SameWidthHeightOfButton = false;
            this.cdvPackType.SearchSubItemIndex = 0;
            this.cdvPackType.SelectedDescIndex = -1;
            this.cdvPackType.SelectedDescToQueryText = "";
            this.cdvPackType.SelectedSubItemIndex = 0;
            this.cdvPackType.SelectedValueToQueryText = "";
            this.cdvPackType.SelectionStart = 0;
            this.cdvPackType.Size = new System.Drawing.Size(122, 20);
            this.cdvPackType.SmallImageList = null;
            this.cdvPackType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPackType.TabIndex = 1;
            this.cdvPackType.TextBoxToolTipText = "";
            this.cdvPackType.TextBoxWidth = 122;
            this.cdvPackType.VisibleButton = true;
            this.cdvPackType.VisibleColumnHeader = false;
            this.cdvPackType.VisibleDescription = false;
            this.cdvPackType.ButtonPress += new System.EventHandler(this.cdvPackType_ButtonPress);
            // 
            // lblPackQty
            // 
            this.lblPackQty.AutoSize = true;
            this.lblPackQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPackQty.Location = new System.Drawing.Point(8, 73);
            this.lblPackQty.Name = "lblPackQty";
            this.lblPackQty.Size = new System.Drawing.Size(51, 13);
            this.lblPackQty.TabIndex = 4;
            this.lblPackQty.Text = "Pack Qty";
            // 
            // lblPackLotCnt
            // 
            this.lblPackLotCnt.AutoSize = true;
            this.lblPackLotCnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPackLotCnt.Location = new System.Drawing.Point(8, 48);
            this.lblPackLotCnt.Name = "lblPackLotCnt";
            this.lblPackLotCnt.Size = new System.Drawing.Size(81, 13);
            this.lblPackLotCnt.TabIndex = 2;
            this.lblPackLotCnt.Text = "Pack Lot Count";
            // 
            // lblPackType
            // 
            this.lblPackType.AutoSize = true;
            this.lblPackType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPackType.Location = new System.Drawing.Point(8, 23);
            this.lblPackType.Name = "lblPackType";
            this.lblPackType.Size = new System.Drawing.Size(59, 13);
            this.lblPackType.TabIndex = 0;
            this.lblPackType.Text = "Pack Type";
            // 
            // grpOqc
            // 
            this.grpOqc.Controls.Add(this.chkOqcSampleRule);
            this.grpOqc.Controls.Add(this.chkOqcSampleFlag);
            this.grpOqc.Controls.Add(this.chkOqcFlag);
            this.grpOqc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOqc.Location = new System.Drawing.Point(375, 300);
            this.grpOqc.Name = "grpOqc";
            this.grpOqc.Size = new System.Drawing.Size(114, 84);
            this.grpOqc.TabIndex = 6;
            this.grpOqc.TabStop = false;
            this.grpOqc.Text = "OQC";
            // 
            // chkOqcSampleRule
            // 
            this.chkOqcSampleRule.AutoSize = true;
            this.chkOqcSampleRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOqcSampleRule.Location = new System.Drawing.Point(14, 58);
            this.chkOqcSampleRule.Name = "chkOqcSampleRule";
            this.chkOqcSampleRule.Size = new System.Drawing.Size(92, 18);
            this.chkOqcSampleRule.TabIndex = 2;
            this.chkOqcSampleRule.Text = "Sample Rule";
            // 
            // chkOqcSampleFlag
            // 
            this.chkOqcSampleFlag.AutoSize = true;
            this.chkOqcSampleFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOqcSampleFlag.Location = new System.Drawing.Point(14, 39);
            this.chkOqcSampleFlag.Name = "chkOqcSampleFlag";
            this.chkOqcSampleFlag.Size = new System.Drawing.Size(90, 18);
            this.chkOqcSampleFlag.TabIndex = 1;
            this.chkOqcSampleFlag.Text = "Sample Flag";
            // 
            // chkOqcFlag
            // 
            this.chkOqcFlag.AutoSize = true;
            this.chkOqcFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOqcFlag.Location = new System.Drawing.Point(14, 20);
            this.chkOqcFlag.Name = "chkOqcFlag";
            this.chkOqcFlag.Size = new System.Drawing.Size(52, 18);
            this.chkOqcFlag.TabIndex = 0;
            this.chkOqcFlag.Text = "Flag";
            // 
            // grpIqc
            // 
            this.grpIqc.Controls.Add(this.chkIqcSampleRule);
            this.grpIqc.Controls.Add(this.chkIqcSampleFlag);
            this.grpIqc.Controls.Add(this.chkIqcFlag);
            this.grpIqc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpIqc.Location = new System.Drawing.Point(250, 300);
            this.grpIqc.Name = "grpIqc";
            this.grpIqc.Size = new System.Drawing.Size(120, 84);
            this.grpIqc.TabIndex = 5;
            this.grpIqc.TabStop = false;
            this.grpIqc.Text = "IQC";
            // 
            // chkIqcSampleRule
            // 
            this.chkIqcSampleRule.AutoSize = true;
            this.chkIqcSampleRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIqcSampleRule.Location = new System.Drawing.Point(14, 58);
            this.chkIqcSampleRule.Name = "chkIqcSampleRule";
            this.chkIqcSampleRule.Size = new System.Drawing.Size(92, 18);
            this.chkIqcSampleRule.TabIndex = 2;
            this.chkIqcSampleRule.Text = "Sample Rule";
            // 
            // chkIqcSampleFlag
            // 
            this.chkIqcSampleFlag.AutoSize = true;
            this.chkIqcSampleFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIqcSampleFlag.Location = new System.Drawing.Point(14, 39);
            this.chkIqcSampleFlag.Name = "chkIqcSampleFlag";
            this.chkIqcSampleFlag.Size = new System.Drawing.Size(90, 18);
            this.chkIqcSampleFlag.TabIndex = 1;
            this.chkIqcSampleFlag.Text = "Sample Flag";
            // 
            // chkIqcFlag
            // 
            this.chkIqcFlag.AutoSize = true;
            this.chkIqcFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIqcFlag.Location = new System.Drawing.Point(14, 20);
            this.chkIqcFlag.Name = "chkIqcFlag";
            this.chkIqcFlag.Size = new System.Drawing.Size(52, 18);
            this.chkIqcFlag.TabIndex = 0;
            this.chkIqcFlag.Text = "Flag";
            // 
            // grpStockLevel
            // 
            this.grpStockLevel.Controls.Add(this.txtHWStockLevel);
            this.grpStockLevel.Controls.Add(this.txtHEStockLevel);
            this.grpStockLevel.Controls.Add(this.txtLWStockLevel);
            this.grpStockLevel.Controls.Add(this.txtLEStockLevel);
            this.grpStockLevel.Controls.Add(this.lblHEStockLevel);
            this.grpStockLevel.Controls.Add(this.lblHWStockLevel);
            this.grpStockLevel.Controls.Add(this.lblLWStockLevel);
            this.grpStockLevel.Controls.Add(this.lblLEStockLevel);
            this.grpStockLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpStockLevel.Location = new System.Drawing.Point(250, 167);
            this.grpStockLevel.Name = "grpStockLevel";
            this.grpStockLevel.Size = new System.Drawing.Size(239, 127);
            this.grpStockLevel.TabIndex = 4;
            this.grpStockLevel.TabStop = false;
            this.grpStockLevel.Text = "Stock Level";
            // 
            // txtHWStockLevel
            // 
            this.txtHWStockLevel.Location = new System.Drawing.Point(112, 95);
            this.txtHWStockLevel.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHWStockLevel.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHWStockLevel.MaskInput = "nnnnnnnnn.nnn";
            this.txtHWStockLevel.Name = "txtHWStockLevel";
            this.txtHWStockLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtHWStockLevel.PromptChar = ' ';
            this.txtHWStockLevel.Size = new System.Drawing.Size(122, 21);
            this.txtHWStockLevel.TabIndex = 7;
            // 
            // txtHEStockLevel
            // 
            this.txtHEStockLevel.Location = new System.Drawing.Point(112, 70);
            this.txtHEStockLevel.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHEStockLevel.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtHEStockLevel.MaskInput = "nnnnnnnnn.nnn";
            this.txtHEStockLevel.Name = "txtHEStockLevel";
            this.txtHEStockLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtHEStockLevel.PromptChar = ' ';
            this.txtHEStockLevel.Size = new System.Drawing.Size(122, 21);
            this.txtHEStockLevel.TabIndex = 5;
            // 
            // txtLWStockLevel
            // 
            this.txtLWStockLevel.Location = new System.Drawing.Point(112, 45);
            this.txtLWStockLevel.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtLWStockLevel.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtLWStockLevel.MaskInput = "nnnnnnnnn.nnn";
            this.txtLWStockLevel.Name = "txtLWStockLevel";
            this.txtLWStockLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtLWStockLevel.PromptChar = ' ';
            this.txtLWStockLevel.Size = new System.Drawing.Size(122, 21);
            this.txtLWStockLevel.TabIndex = 3;
            // 
            // txtLEStockLevel
            // 
            this.txtLEStockLevel.Location = new System.Drawing.Point(112, 20);
            this.txtLEStockLevel.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtLEStockLevel.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtLEStockLevel.MaskInput = "nnnnnnnnn.nnn";
            this.txtLEStockLevel.Name = "txtLEStockLevel";
            this.txtLEStockLevel.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtLEStockLevel.PromptChar = ' ';
            this.txtLEStockLevel.Size = new System.Drawing.Size(122, 21);
            this.txtLEStockLevel.TabIndex = 1;
            // 
            // lblHEStockLevel
            // 
            this.lblHEStockLevel.AutoSize = true;
            this.lblHEStockLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHEStockLevel.Location = new System.Drawing.Point(8, 73);
            this.lblHEStockLevel.Name = "lblHEStockLevel";
            this.lblHEStockLevel.Size = new System.Drawing.Size(54, 13);
            this.lblHEStockLevel.TabIndex = 4;
            this.lblHEStockLevel.Text = "High Error";
            // 
            // lblHWStockLevel
            // 
            this.lblHWStockLevel.AutoSize = true;
            this.lblHWStockLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHWStockLevel.Location = new System.Drawing.Point(8, 98);
            this.lblHWStockLevel.Name = "lblHWStockLevel";
            this.lblHWStockLevel.Size = new System.Drawing.Size(72, 13);
            this.lblHWStockLevel.TabIndex = 6;
            this.lblHWStockLevel.Text = "High Warning";
            // 
            // lblLWStockLevel
            // 
            this.lblLWStockLevel.AutoSize = true;
            this.lblLWStockLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLWStockLevel.Location = new System.Drawing.Point(8, 48);
            this.lblLWStockLevel.Name = "lblLWStockLevel";
            this.lblLWStockLevel.Size = new System.Drawing.Size(70, 13);
            this.lblLWStockLevel.TabIndex = 2;
            this.lblLWStockLevel.Text = "Low Warning";
            // 
            // lblLEStockLevel
            // 
            this.lblLEStockLevel.AutoSize = true;
            this.lblLEStockLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLEStockLevel.Location = new System.Drawing.Point(8, 23);
            this.lblLEStockLevel.Name = "lblLEStockLevel";
            this.lblLEStockLevel.Size = new System.Drawing.Size(52, 13);
            this.lblLEStockLevel.TabIndex = 0;
            this.lblLEStockLevel.Text = "Low Error";
            // 
            // grpDimension
            // 
            this.grpDimension.Controls.Add(this.txtDimHt);
            this.grpDimension.Controls.Add(this.txtDimVt);
            this.grpDimension.Controls.Add(this.txtDimHr);
            this.grpDimension.Controls.Add(this.txtDimVtUnit);
            this.grpDimension.Controls.Add(this.txtDimHtUnit);
            this.grpDimension.Controls.Add(this.lblDimHtUnit);
            this.grpDimension.Controls.Add(this.lblDimHt);
            this.grpDimension.Controls.Add(this.txtDimHrUnit);
            this.grpDimension.Controls.Add(this.lblDimVtUnit);
            this.grpDimension.Controls.Add(this.lblDimVt);
            this.grpDimension.Controls.Add(this.lblDimHrUnit);
            this.grpDimension.Controls.Add(this.lblDimHr);
            this.grpDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDimension.Location = new System.Drawing.Point(3, 203);
            this.grpDimension.Name = "grpDimension";
            this.grpDimension.Size = new System.Drawing.Size(244, 181);
            this.grpDimension.TabIndex = 2;
            this.grpDimension.TabStop = false;
            this.grpDimension.Text = "Dimension";
            // 
            // txtDimHt
            // 
            this.txtDimHt.Location = new System.Drawing.Point(112, 124);
            this.txtDimHt.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimHt.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimHt.MaskInput = "nnnnnnn.nnn";
            this.txtDimHt.Name = "txtDimHt";
            this.txtDimHt.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDimHt.PromptChar = ' ';
            this.txtDimHt.Size = new System.Drawing.Size(124, 21);
            this.txtDimHt.TabIndex = 9;
            // 
            // txtDimVt
            // 
            this.txtDimVt.Location = new System.Drawing.Point(112, 72);
            this.txtDimVt.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimVt.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimVt.MaskInput = "nnnnnnn.nnn";
            this.txtDimVt.Name = "txtDimVt";
            this.txtDimVt.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDimVt.PromptChar = ' ';
            this.txtDimVt.Size = new System.Drawing.Size(124, 21);
            this.txtDimVt.TabIndex = 5;
            // 
            // txtDimHr
            // 
            this.txtDimHr.Location = new System.Drawing.Point(112, 20);
            this.txtDimHr.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimHr.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtDimHr.MaskInput = "nnnnnnn.nnn";
            this.txtDimHr.Name = "txtDimHr";
            this.txtDimHr.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtDimHr.PromptChar = ' ';
            this.txtDimHr.Size = new System.Drawing.Size(124, 21);
            this.txtDimHr.TabIndex = 1;
            // 
            // txtDimVtUnit
            // 
            this.txtDimVtUnit.Location = new System.Drawing.Point(112, 98);
            this.txtDimVtUnit.MaxLength = 10;
            this.txtDimVtUnit.Name = "txtDimVtUnit";
            this.txtDimVtUnit.Size = new System.Drawing.Size(124, 20);
            this.txtDimVtUnit.TabIndex = 7;
            // 
            // txtDimHtUnit
            // 
            this.txtDimHtUnit.Location = new System.Drawing.Point(112, 150);
            this.txtDimHtUnit.MaxLength = 10;
            this.txtDimHtUnit.Name = "txtDimHtUnit";
            this.txtDimHtUnit.Size = new System.Drawing.Size(124, 20);
            this.txtDimHtUnit.TabIndex = 11;
            // 
            // lblDimHtUnit
            // 
            this.lblDimHtUnit.AutoSize = true;
            this.lblDimHtUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimHtUnit.Location = new System.Drawing.Point(8, 153);
            this.lblDimHtUnit.Name = "lblDimHtUnit";
            this.lblDimHtUnit.Size = new System.Drawing.Size(60, 13);
            this.lblDimHtUnit.TabIndex = 10;
            this.lblDimHtUnit.Text = "Height Unit";
            // 
            // lblDimHt
            // 
            this.lblDimHt.AutoSize = true;
            this.lblDimHt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimHt.Location = new System.Drawing.Point(8, 127);
            this.lblDimHt.Name = "lblDimHt";
            this.lblDimHt.Size = new System.Drawing.Size(38, 13);
            this.lblDimHt.TabIndex = 8;
            this.lblDimHt.Text = "Height";
            // 
            // txtDimHrUnit
            // 
            this.txtDimHrUnit.Location = new System.Drawing.Point(112, 46);
            this.txtDimHrUnit.MaxLength = 10;
            this.txtDimHrUnit.Name = "txtDimHrUnit";
            this.txtDimHrUnit.Size = new System.Drawing.Size(124, 20);
            this.txtDimHrUnit.TabIndex = 3;
            // 
            // lblDimVtUnit
            // 
            this.lblDimVtUnit.AutoSize = true;
            this.lblDimVtUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimVtUnit.Location = new System.Drawing.Point(8, 101);
            this.lblDimVtUnit.Name = "lblDimVtUnit";
            this.lblDimVtUnit.Size = new System.Drawing.Size(64, 13);
            this.lblDimVtUnit.TabIndex = 6;
            this.lblDimVtUnit.Text = "Vertical Unit";
            // 
            // lblDimVt
            // 
            this.lblDimVt.AutoSize = true;
            this.lblDimVt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimVt.Location = new System.Drawing.Point(8, 75);
            this.lblDimVt.Name = "lblDimVt";
            this.lblDimVt.Size = new System.Drawing.Size(42, 13);
            this.lblDimVt.TabIndex = 4;
            this.lblDimVt.Text = "Vertical";
            // 
            // lblDimHrUnit
            // 
            this.lblDimHrUnit.AutoSize = true;
            this.lblDimHrUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimHrUnit.Location = new System.Drawing.Point(8, 49);
            this.lblDimHrUnit.Name = "lblDimHrUnit";
            this.lblDimHrUnit.Size = new System.Drawing.Size(76, 13);
            this.lblDimHrUnit.TabIndex = 2;
            this.lblDimHrUnit.Text = "Horizontal Unit";
            // 
            // lblDimHr
            // 
            this.lblDimHr.AutoSize = true;
            this.lblDimHr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDimHr.Location = new System.Drawing.Point(8, 23);
            this.lblDimHr.Name = "lblDimHr";
            this.lblDimHr.Size = new System.Drawing.Size(54, 13);
            this.lblDimHr.TabIndex = 0;
            this.lblDimHr.Text = "Horizontal";
            // 
            // grpWeight
            // 
            this.grpWeight.Controls.Add(this.txtWetGross);
            this.grpWeight.Controls.Add(this.txtWetNet);
            this.grpWeight.Controls.Add(this.txtWetUnit);
            this.grpWeight.Controls.Add(this.lblWetUnit);
            this.grpWeight.Controls.Add(this.lblWetGross);
            this.grpWeight.Controls.Add(this.lblWetNet);
            this.grpWeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpWeight.Location = new System.Drawing.Point(3, 5);
            this.grpWeight.Name = "grpWeight";
            this.grpWeight.Size = new System.Drawing.Size(244, 106);
            this.grpWeight.TabIndex = 0;
            this.grpWeight.TabStop = false;
            this.grpWeight.Text = "Weight";
            // 
            // txtWetGross
            // 
            this.txtWetGross.Location = new System.Drawing.Point(112, 45);
            this.txtWetGross.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWetGross.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWetGross.MaskInput = "nnnnnnn.nnn";
            this.txtWetGross.Name = "txtWetGross";
            this.txtWetGross.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWetGross.PromptChar = ' ';
            this.txtWetGross.Size = new System.Drawing.Size(124, 21);
            this.txtWetGross.TabIndex = 3;
            // 
            // txtWetNet
            // 
            this.txtWetNet.Location = new System.Drawing.Point(112, 20);
            this.txtWetNet.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWetNet.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtWetNet.MaskInput = "nnnnnnn.nnn";
            this.txtWetNet.Name = "txtWetNet";
            this.txtWetNet.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtWetNet.PromptChar = ' ';
            this.txtWetNet.Size = new System.Drawing.Size(124, 21);
            this.txtWetNet.TabIndex = 1;
            // 
            // txtWetUnit
            // 
            this.txtWetUnit.Location = new System.Drawing.Point(112, 70);
            this.txtWetUnit.MaxLength = 10;
            this.txtWetUnit.Name = "txtWetUnit";
            this.txtWetUnit.Size = new System.Drawing.Size(124, 20);
            this.txtWetUnit.TabIndex = 5;
            // 
            // lblWetUnit
            // 
            this.lblWetUnit.AutoSize = true;
            this.lblWetUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWetUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWetUnit.Location = new System.Drawing.Point(8, 73);
            this.lblWetUnit.Name = "lblWetUnit";
            this.lblWetUnit.Size = new System.Drawing.Size(26, 13);
            this.lblWetUnit.TabIndex = 4;
            this.lblWetUnit.Text = "Unit";
            // 
            // lblWetGross
            // 
            this.lblWetGross.AutoSize = true;
            this.lblWetGross.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWetGross.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWetGross.Location = new System.Drawing.Point(8, 48);
            this.lblWetGross.Name = "lblWetGross";
            this.lblWetGross.Size = new System.Drawing.Size(34, 13);
            this.lblWetGross.TabIndex = 2;
            this.lblWetGross.Text = "Gross";
            // 
            // lblWetNet
            // 
            this.lblWetNet.AutoSize = true;
            this.lblWetNet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWetNet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblWetNet.Location = new System.Drawing.Point(8, 23);
            this.lblWetNet.Name = "lblWetNet";
            this.lblWetNet.Size = new System.Drawing.Size(24, 13);
            this.lblWetNet.TabIndex = 0;
            this.lblWetNet.Text = "Net";
            // 
            // grpVolume
            // 
            this.grpVolume.Controls.Add(this.txtVolume);
            this.grpVolume.Controls.Add(this.lblVolumeUnit);
            this.grpVolume.Controls.Add(this.txtVolumeUnit);
            this.grpVolume.Controls.Add(this.lblVolume);
            this.grpVolume.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpVolume.Location = new System.Drawing.Point(3, 116);
            this.grpVolume.Name = "grpVolume";
            this.grpVolume.Size = new System.Drawing.Size(244, 80);
            this.grpVolume.TabIndex = 1;
            this.grpVolume.TabStop = false;
            this.grpVolume.Text = "Volume";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(112, 20);
            this.txtVolume.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtVolume.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtVolume.MaskInput = "nnnnnnn.nnn";
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtVolume.PromptChar = ' ';
            this.txtVolume.Size = new System.Drawing.Size(124, 21);
            this.txtVolume.TabIndex = 1;
            // 
            // lblVolumeUnit
            // 
            this.lblVolumeUnit.AutoSize = true;
            this.lblVolumeUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVolumeUnit.Location = new System.Drawing.Point(8, 49);
            this.lblVolumeUnit.Name = "lblVolumeUnit";
            this.lblVolumeUnit.Size = new System.Drawing.Size(64, 13);
            this.lblVolumeUnit.TabIndex = 2;
            this.lblVolumeUnit.Text = "Volume Unit";
            // 
            // txtVolumeUnit
            // 
            this.txtVolumeUnit.Location = new System.Drawing.Point(112, 46);
            this.txtVolumeUnit.MaxLength = 10;
            this.txtVolumeUnit.Name = "txtVolumeUnit";
            this.txtVolumeUnit.Size = new System.Drawing.Size(124, 20);
            this.txtVolumeUnit.TabIndex = 3;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVolume.Location = new System.Drawing.Point(8, 23);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 0;
            this.lblVolume.Text = "Volume";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGroup.Size = new System.Drawing.Size(492, 384);
            this.tbpGroup.TabIndex = 2;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup10);
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Controls.Add(this.cdvGroup8);
            this.grpGroup.Controls.Add(this.cdvGroup7);
            this.grpGroup.Controls.Add(this.cdvGroup6);
            this.grpGroup.Controls.Add(this.cdvGroup5);
            this.grpGroup.Controls.Add(this.cdvGroup4);
            this.grpGroup.Controls.Add(this.cdvGroup3);
            this.grpGroup.Controls.Add(this.cdvGroup2);
            this.grpGroup.Controls.Add(this.cdvGroup1);
            this.grpGroup.Controls.Add(this.lblGroup10);
            this.grpGroup.Controls.Add(this.lblGroup9);
            this.grpGroup.Controls.Add(this.lblGroup8);
            this.grpGroup.Controls.Add(this.lblGroup7);
            this.grpGroup.Controls.Add(this.lblGroup6);
            this.grpGroup.Controls.Add(this.lblGroup5);
            this.grpGroup.Controls.Add(this.lblGroup4);
            this.grpGroup.Controls.Add(this.lblGroup3);
            this.grpGroup.Controls.Add(this.lblGroup2);
            this.grpGroup.Controls.Add(this.lblGroup1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 5);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 376);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "Material Group (1~10)";
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.ButtonWidth = 20;
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 9;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 234);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MultiSelect = false;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SameWidthHeightOfButton = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedDescToQueryText = "";
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectedValueToQueryText = "";
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 19;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.ButtonWidth = 20;
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 8;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 210);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MultiSelect = false;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SameWidthHeightOfButton = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedDescToQueryText = "";
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectedValueToQueryText = "";
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 17;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.TextBoxWidth = 200;
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            this.cdvGroup9.VisibleDescription = false;
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.ButtonWidth = 20;
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 7;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 186);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MultiSelect = false;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SameWidthHeightOfButton = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedDescToQueryText = "";
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectedValueToQueryText = "";
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 15;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.TextBoxWidth = 200;
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            this.cdvGroup8.VisibleDescription = false;
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.ButtonWidth = 20;
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 6;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 162);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MultiSelect = false;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SameWidthHeightOfButton = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedDescToQueryText = "";
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectedValueToQueryText = "";
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 13;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.TextBoxWidth = 200;
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            this.cdvGroup7.VisibleDescription = false;
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.ButtonWidth = 20;
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 5;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 138);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MultiSelect = false;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SameWidthHeightOfButton = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedDescToQueryText = "";
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectedValueToQueryText = "";
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 11;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.TextBoxWidth = 200;
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            this.cdvGroup6.VisibleDescription = false;
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.ButtonWidth = 20;
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 4;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 114);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MultiSelect = false;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SameWidthHeightOfButton = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedDescToQueryText = "";
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectedValueToQueryText = "";
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 9;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.TextBoxWidth = 200;
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            this.cdvGroup5.VisibleDescription = false;
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.ButtonWidth = 20;
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 3;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 90);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MultiSelect = false;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SameWidthHeightOfButton = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedDescToQueryText = "";
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectedValueToQueryText = "";
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 7;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.TextBoxWidth = 200;
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            this.cdvGroup4.VisibleDescription = false;
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.ButtonWidth = 20;
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 2;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 66);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MultiSelect = false;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SameWidthHeightOfButton = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedDescToQueryText = "";
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectedValueToQueryText = "";
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 5;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.TextBoxWidth = 200;
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            this.cdvGroup3.VisibleDescription = false;
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.ButtonWidth = 20;
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 1;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 42);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MultiSelect = false;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SameWidthHeightOfButton = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedDescToQueryText = "";
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectedValueToQueryText = "";
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 3;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.TextBoxWidth = 200;
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            this.cdvGroup2.VisibleDescription = false;
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.ButtonWidth = 20;
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 18);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MultiSelect = false;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SameWidthHeightOfButton = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedDescToQueryText = "";
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectedValueToQueryText = "";
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 1;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 200;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // lblGroup10
            // 
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup10.Location = new System.Drawing.Point(16, 237);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            // 
            // lblGroup9
            // 
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup9.Location = new System.Drawing.Point(16, 213);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            // 
            // lblGroup8
            // 
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup8.Location = new System.Drawing.Point(16, 189);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            // 
            // lblGroup7
            // 
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup7.Location = new System.Drawing.Point(16, 165);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            // 
            // lblGroup6
            // 
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup6.Location = new System.Drawing.Point(16, 141);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            // 
            // lblGroup5
            // 
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup5.Location = new System.Drawing.Point(16, 117);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            // 
            // lblGroup4
            // 
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup4.Location = new System.Drawing.Point(16, 93);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            // 
            // lblGroup3
            // 
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup3.Location = new System.Drawing.Point(16, 69);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            // 
            // lblGroup2
            // 
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup2.Location = new System.Drawing.Point(16, 45);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            // 
            // lblGroup1
            // 
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup1.Location = new System.Drawing.Point(16, 21);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(492, 391);
            this.tbpAttribute.TabIndex = 5;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = this.txtMaterial.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "MATERIAL";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(486, 385);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpCmf
            // 
            this.tbpCmf.Controls.Add(this.grpCMF);
            this.tbpCmf.Location = new System.Drawing.Point(4, 22);
            this.tbpCmf.Name = "tbpCmf";
            this.tbpCmf.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpCmf.Size = new System.Drawing.Size(492, 384);
            this.tbpCmf.TabIndex = 3;
            this.tbpCmf.Text = "Customized Field";
            this.tbpCmf.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.Location = new System.Drawing.Point(3, 5);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 376);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            this.grpCMF.Text = "Customized Field (1~20)";
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.ButtonWidth = 20;
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(347, 210);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MultiSelect = false;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SameWidthHeightOfButton = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedDescToQueryText = "";
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectedValueToQueryText = "";
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 130;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.ButtonWidth = 20;
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(347, 186);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MultiSelect = false;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SameWidthHeightOfButton = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedDescToQueryText = "";
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectedValueToQueryText = "";
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 130;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.ButtonWidth = 20;
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(347, 162);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MultiSelect = false;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SameWidthHeightOfButton = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedDescToQueryText = "";
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectedValueToQueryText = "";
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 130;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.ButtonWidth = 20;
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(347, 138);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MultiSelect = false;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SameWidthHeightOfButton = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedDescToQueryText = "";
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectedValueToQueryText = "";
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 130;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.ButtonWidth = 20;
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(347, 114);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MultiSelect = false;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SameWidthHeightOfButton = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedDescToQueryText = "";
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectedValueToQueryText = "";
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 130;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.ButtonWidth = 20;
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(347, 90);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MultiSelect = false;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SameWidthHeightOfButton = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedDescToQueryText = "";
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectedValueToQueryText = "";
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 130;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.ButtonWidth = 20;
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(347, 66);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MultiSelect = false;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SameWidthHeightOfButton = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedDescToQueryText = "";
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectedValueToQueryText = "";
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 130;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.ButtonWidth = 20;
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(347, 42);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MultiSelect = false;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SameWidthHeightOfButton = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedDescToQueryText = "";
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectedValueToQueryText = "";
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 130;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.ButtonWidth = 20;
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(347, 234);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MultiSelect = false;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SameWidthHeightOfButton = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedDescToQueryText = "";
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectedValueToQueryText = "";
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 130;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.ButtonWidth = 20;
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(347, 18);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MultiSelect = false;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SameWidthHeightOfButton = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedDescToQueryText = "";
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectedValueToQueryText = "";
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 130;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(251, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(251, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(251, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(251, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(251, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(251, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(251, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(251, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(251, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(251, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 20;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.ButtonWidth = 20;
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(104, 210);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MultiSelect = false;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SameWidthHeightOfButton = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedDescToQueryText = "";
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectedValueToQueryText = "";
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 130;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.ButtonWidth = 20;
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(104, 186);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MultiSelect = false;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SameWidthHeightOfButton = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedDescToQueryText = "";
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectedValueToQueryText = "";
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 130;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.ButtonWidth = 20;
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(104, 162);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MultiSelect = false;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SameWidthHeightOfButton = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedDescToQueryText = "";
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectedValueToQueryText = "";
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 130;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.ButtonWidth = 20;
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(104, 138);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MultiSelect = false;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SameWidthHeightOfButton = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedDescToQueryText = "";
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectedValueToQueryText = "";
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 130;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.ButtonWidth = 20;
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(104, 114);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MultiSelect = false;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SameWidthHeightOfButton = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedDescToQueryText = "";
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectedValueToQueryText = "";
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 130;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.ButtonWidth = 20;
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(104, 90);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MultiSelect = false;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SameWidthHeightOfButton = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedDescToQueryText = "";
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectedValueToQueryText = "";
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 130;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.ButtonWidth = 20;
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(104, 66);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MultiSelect = false;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SameWidthHeightOfButton = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedDescToQueryText = "";
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectedValueToQueryText = "";
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 130;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.ButtonWidth = 20;
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(104, 42);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MultiSelect = false;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SameWidthHeightOfButton = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedDescToQueryText = "";
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectedValueToQueryText = "";
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 130;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.ButtonWidth = 20;
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(104, 234);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MultiSelect = false;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SameWidthHeightOfButton = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedDescToQueryText = "";
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectedValueToQueryText = "";
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 130;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.ButtonWidth = 20;
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(104, 18);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MultiSelect = false;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SameWidthHeightOfButton = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedDescToQueryText = "";
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectedValueToQueryText = "";
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 130;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(8, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(8, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(8, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(8, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(8, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(8, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(8, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(8, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(8, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(8, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpFlow
            // 
            this.tbpFlow.Controls.Add(this.pnlAttachFlowMid);
            this.tbpFlow.Controls.Add(this.pnlFlowList);
            this.tbpFlow.Controls.Add(this.lisFlow);
            this.tbpFlow.Location = new System.Drawing.Point(4, 22);
            this.tbpFlow.Name = "tbpFlow";
            this.tbpFlow.Padding = new System.Windows.Forms.Padding(5);
            this.tbpFlow.Size = new System.Drawing.Size(492, 384);
            this.tbpFlow.TabIndex = 4;
            this.tbpFlow.Text = "Attach Flow";
            this.tbpFlow.Visible = false;
            this.tbpFlow.Resize += new System.EventHandler(this.tbpFlow_Resize);
            // 
            // pnlAttachFlowMid
            // 
            this.pnlAttachFlowMid.Controls.Add(this.btnFlowExcel);
            this.pnlAttachFlowMid.Controls.Add(this.btnDown);
            this.pnlAttachFlowMid.Controls.Add(this.btnUp);
            this.pnlAttachFlowMid.Controls.Add(this.btnAttach);
            this.pnlAttachFlowMid.Controls.Add(this.btnDetach);
            this.pnlAttachFlowMid.Location = new System.Drawing.Point(258, 58);
            this.pnlAttachFlowMid.Name = "pnlAttachFlowMid";
            this.pnlAttachFlowMid.Size = new System.Drawing.Size(46, 283);
            this.pnlAttachFlowMid.TabIndex = 1;
            // 
            // btnFlowExcel
            // 
            this.btnFlowExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFlowExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFlowExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnFlowExcel.Image")));
            this.btnFlowExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFlowExcel.Location = new System.Drawing.Point(3, 256);
            this.btnFlowExcel.Name = "btnFlowExcel";
            this.btnFlowExcel.Size = new System.Drawing.Size(24, 24);
            this.btnFlowExcel.TabIndex = 9;
            this.btnFlowExcel.Click += new System.EventHandler(this.btnFlowExcel_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(3, 228);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(3, 202);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(11, 115);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 2;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(11, 144);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 3;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // pnlFlowList
            // 
            this.pnlFlowList.Controls.Add(this.lisFlowList);
            this.pnlFlowList.Controls.Add(this.pnlFlowListTop);
            this.pnlFlowList.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFlowList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFlowList.Location = new System.Drawing.Point(311, 5);
            this.pnlFlowList.Name = "pnlFlowList";
            this.pnlFlowList.Size = new System.Drawing.Size(176, 374);
            this.pnlFlowList.TabIndex = 6;
            // 
            // lisFlowList
            // 
            this.lisFlowList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFlowList,
            this.colFlowDescription});
            this.lisFlowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisFlowList.EnableSort = true;
            this.lisFlowList.EnableSortIcon = true;
            this.lisFlowList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisFlowList.FullRowSelect = true;
            this.lisFlowList.HideSelection = false;
            this.lisFlowList.Location = new System.Drawing.Point(0, 74);
            this.lisFlowList.MultiSelect = false;
            this.lisFlowList.Name = "lisFlowList";
            this.lisFlowList.Size = new System.Drawing.Size(176, 300);
            this.lisFlowList.TabIndex = 4;
            this.lisFlowList.UseCompatibleStateImageBehavior = false;
            this.lisFlowList.View = System.Windows.Forms.View.Details;
            // 
            // colFlowList
            // 
            this.colFlowList.Text = "Flow";
            this.colFlowList.Width = 80;
            // 
            // colFlowDescription
            // 
            this.colFlowDescription.Text = "Description";
            this.colFlowDescription.Width = 200;
            // 
            // pnlFlowListTop
            // 
            this.pnlFlowListTop.Controls.Add(this.cdvOptionalGroupOption);
            this.pnlFlowListTop.Controls.Add(this.lblOptionalGroupOption);
            this.pnlFlowListTop.Controls.Add(this.cdvOptionalGroup);
            this.pnlFlowListTop.Controls.Add(this.lblOptionalGroup);
            this.pnlFlowListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFlowListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFlowListTop.Name = "pnlFlowListTop";
            this.pnlFlowListTop.Size = new System.Drawing.Size(176, 74);
            this.pnlFlowListTop.TabIndex = 3;
            // 
            // cdvOptionalGroupOption
            // 
            this.cdvOptionalGroupOption.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOptionalGroupOption.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOptionalGroupOption.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOptionalGroupOption.BtnToolTipText = "";
            this.cdvOptionalGroupOption.ButtonWidth = 20;
            this.cdvOptionalGroupOption.DescText = "";
            this.cdvOptionalGroupOption.DisplaySubItemIndex = 0;
            this.cdvOptionalGroupOption.DisplayText = "";
            this.cdvOptionalGroupOption.Focusing = null;
            this.cdvOptionalGroupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOptionalGroupOption.Index = 0;
            this.cdvOptionalGroupOption.IsViewBtnImage = false;
            this.cdvOptionalGroupOption.Location = new System.Drawing.Point(0, 52);
            this.cdvOptionalGroupOption.MaxLength = 1;
            this.cdvOptionalGroupOption.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroupOption.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroupOption.MultiSelect = false;
            this.cdvOptionalGroupOption.Name = "cdvOptionalGroupOption";
            this.cdvOptionalGroupOption.ReadOnly = false;
            this.cdvOptionalGroupOption.SameWidthHeightOfButton = false;
            this.cdvOptionalGroupOption.SearchSubItemIndex = 0;
            this.cdvOptionalGroupOption.SelectedDescIndex = -1;
            this.cdvOptionalGroupOption.SelectedDescToQueryText = "";
            this.cdvOptionalGroupOption.SelectedSubItemIndex = 0;
            this.cdvOptionalGroupOption.SelectedValueToQueryText = "";
            this.cdvOptionalGroupOption.SelectionStart = 0;
            this.cdvOptionalGroupOption.Size = new System.Drawing.Size(176, 20);
            this.cdvOptionalGroupOption.SmallImageList = null;
            this.cdvOptionalGroupOption.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOptionalGroupOption.TabIndex = 8;
            this.cdvOptionalGroupOption.TextBoxToolTipText = "";
            this.cdvOptionalGroupOption.TextBoxWidth = 176;
            this.cdvOptionalGroupOption.VisibleButton = false;
            this.cdvOptionalGroupOption.VisibleColumnHeader = false;
            this.cdvOptionalGroupOption.VisibleDescription = false;
            // 
            // lblOptionalGroupOption
            // 
            this.lblOptionalGroupOption.AutoSize = true;
            this.lblOptionalGroupOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptionalGroupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionalGroupOption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOptionalGroupOption.Location = new System.Drawing.Point(2, 38);
            this.lblOptionalGroupOption.Name = "lblOptionalGroupOption";
            this.lblOptionalGroupOption.Size = new System.Drawing.Size(112, 13);
            this.lblOptionalGroupOption.TabIndex = 7;
            this.lblOptionalGroupOption.Text = "Optional Group Option";
            // 
            // cdvOptionalGroup
            // 
            this.cdvOptionalGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOptionalGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOptionalGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOptionalGroup.BtnToolTipText = "";
            this.cdvOptionalGroup.ButtonWidth = 20;
            this.cdvOptionalGroup.DescText = "";
            this.cdvOptionalGroup.DisplaySubItemIndex = 0;
            this.cdvOptionalGroup.DisplayText = "";
            this.cdvOptionalGroup.Focusing = null;
            this.cdvOptionalGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOptionalGroup.Index = 0;
            this.cdvOptionalGroup.IsViewBtnImage = false;
            this.cdvOptionalGroup.Location = new System.Drawing.Point(0, 16);
            this.cdvOptionalGroup.MaxLength = 20;
            this.cdvOptionalGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroup.MultiSelect = false;
            this.cdvOptionalGroup.Name = "cdvOptionalGroup";
            this.cdvOptionalGroup.ReadOnly = false;
            this.cdvOptionalGroup.SameWidthHeightOfButton = false;
            this.cdvOptionalGroup.SearchSubItemIndex = 0;
            this.cdvOptionalGroup.SelectedDescIndex = -1;
            this.cdvOptionalGroup.SelectedDescToQueryText = "";
            this.cdvOptionalGroup.SelectedSubItemIndex = 0;
            this.cdvOptionalGroup.SelectedValueToQueryText = "";
            this.cdvOptionalGroup.SelectionStart = 0;
            this.cdvOptionalGroup.Size = new System.Drawing.Size(176, 20);
            this.cdvOptionalGroup.SmallImageList = null;
            this.cdvOptionalGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOptionalGroup.TabIndex = 6;
            this.cdvOptionalGroup.TextBoxToolTipText = "";
            this.cdvOptionalGroup.TextBoxWidth = 176;
            this.cdvOptionalGroup.VisibleButton = false;
            this.cdvOptionalGroup.VisibleColumnHeader = false;
            this.cdvOptionalGroup.VisibleDescription = false;
            // 
            // lblOptionalGroup
            // 
            this.lblOptionalGroup.AutoSize = true;
            this.lblOptionalGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptionalGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionalGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOptionalGroup.Location = new System.Drawing.Point(0, 1);
            this.lblOptionalGroup.Name = "lblOptionalGroup";
            this.lblOptionalGroup.Size = new System.Drawing.Size(78, 13);
            this.lblOptionalGroup.TabIndex = 5;
            this.lblOptionalGroup.Text = "Optional Group";
            // 
            // lisFlow
            // 
            this.lisFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFlowAttachFlow,
            this.colFlowDesc,
            this.colFlowGroup,
            this.colFlowGroupOption});
            this.lisFlow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisFlow.EnableSort = false;
            this.lisFlow.EnableSortIcon = true;
            this.lisFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisFlow.FullRowSelect = true;
            this.lisFlow.HideSelection = false;
            this.lisFlow.Location = new System.Drawing.Point(5, 5);
            this.lisFlow.MultiSelect = false;
            this.lisFlow.Name = "lisFlow";
            this.lisFlow.Size = new System.Drawing.Size(245, 374);
            this.lisFlow.TabIndex = 0;
            this.lisFlow.UseCompatibleStateImageBehavior = false;
            this.lisFlow.View = System.Windows.Forms.View.Details;
            this.lisFlow.SelectedIndexChanged += new System.EventHandler(this.lisFlow_SelectedIndexChanged);
            // 
            // colFlowAttachFlow
            // 
            this.colFlowAttachFlow.Text = "Attached Flow";
            this.colFlowAttachFlow.Width = 100;
            // 
            // colFlowDesc
            // 
            this.colFlowDesc.Text = "Description";
            this.colFlowDesc.Width = 200;
            // 
            // colFlowGroup
            // 
            this.colFlowGroup.Text = "Group";
            this.colFlowGroup.Width = 50;
            // 
            // colFlowGroupOption
            // 
            this.colFlowGroupOption.Text = "Option";
            this.colFlowGroupOption.Width = 50;
            // 
            // btnUndelete
            // 
            this.btnUndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndelete.Location = new System.Drawing.Point(558, 8);
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Size = new System.Drawing.Size(88, 26);
            this.btnUndelete.TabIndex = 3;
            this.btnUndelete.Text = "Undelete";
            this.btnUndelete.Click += new System.EventHandler(this.btnUndelete_Click);
            // 
            // udcMaterial
            // 
            this.udcMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMaterial.ListCond_ExtFactory = "";
            this.udcMaterial.ListCond_Step = '1';
            this.udcMaterial.Location = new System.Drawing.Point(3, 0);
            this.udcMaterial.MaterialType = "";
            this.udcMaterial.Name = "udcMaterial";
            this.udcMaterial.Size = new System.Drawing.Size(229, 511);
            this.udcMaterial.TabIndex = 0;
            this.udcMaterial.VisibleIncludeDeleteMaterialCheck = true;
            this.udcMaterial.VisibleMaterialType = true;
            this.udcMaterial.VisibleViewType = true;
            this.udcMaterial.AfterGetList += new System.EventHandler(this.udcMaterial_AfterGetList);
            this.udcMaterial.SelectedIndexChanged += new System.EventHandler(this.udcMaterial_SelectedIndexChanged);
            this.udcMaterial.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMaterial_AfterSelect);
            // 
            // btnVersionUp
            // 
            this.btnVersionUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVersionUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVersionUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVersionUp.Location = new System.Drawing.Point(285, 7);
            this.btnVersionUp.Name = "btnVersionUp";
            this.btnVersionUp.Size = new System.Drawing.Size(88, 26);
            this.btnVersionUp.TabIndex = 0;
            this.btnVersionUp.Text = "Version Up";
            this.btnVersionUp.Click += new System.EventHandler(this.btnVersionUp_Click);
            // 
            // frmWIPSetupMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupMaterial";
            this.Text = "Material Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupMaterial_Activated);
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
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.tabMaterial.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGeneralRight.ResumeLayout(false);
            this.pnlTarget.ResumeLayout(false);
            this.grpTarget.ResumeLayout(false);
            this.grpTarget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetDueDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetYield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTargetQty1)).EndInit();
            this.grpRelation.ResumeLayout(false);
            this.grpRelation.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultQty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1)).EndInit();
            this.tbpProperty.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackLotCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBomSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPackType)).EndInit();
            this.grpOqc.ResumeLayout(false);
            this.grpOqc.PerformLayout();
            this.grpIqc.ResumeLayout(false);
            this.grpIqc.PerformLayout();
            this.grpStockLevel.ResumeLayout(false);
            this.grpStockLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHWStockLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHEStockLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLWStockLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLEStockLevel)).EndInit();
            this.grpDimension.ResumeLayout(false);
            this.grpDimension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimHt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimVt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDimHr)).EndInit();
            this.grpWeight.ResumeLayout(false);
            this.grpWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWetGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWetNet)).EndInit();
            this.grpVolume.ResumeLayout(false);
            this.grpVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).EndInit();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpCmf.ResumeLayout(false);
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
            this.tbpFlow.ResumeLayout(false);
            this.pnlAttachFlowMid.ResumeLayout(false);
            this.pnlFlowList.ResumeLayout(false);
            this.pnlFlowListTop.ResumeLayout(false);
            this.pnlFlowListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroupOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroup)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_is_work = false;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_MATERIAL_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_MATERIAL_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_MATERIAL_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_MATERIAL_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_MATERIAL_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_MATERIAL_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_MATERIAL_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_MATERIAL_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_MATERIAL_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_MATERIAL_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_MATERIAL, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_MATERIAL, "lblCMF", "cdvCMF", grpCMF);
            
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtMaterial, 1) == false) return false;
            if (MPCF.CheckValue(txtVersion, 2) == false) return false;
            
            switch (FuncName)
            {
                case "CREATE":

                    if (MPCF.CheckValue(cdvType, 1) == false) return false;

                    if ((cdvUnit1.Text == "") &&(cdvUnit2.Text == "") &&(cdvUnit3.Text == ""))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabMaterial.SelectedTab = tbpGeneral;
                        cdvUnit1.Focus();
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabMaterial.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabMaterial.SelectedTab = tbpCmf;
                        return false;
                    }
                    break;

                case "UPDATE":
                case "VERSIONUP":

                    if (MPCF.CheckValue(cdvType, 1) == false) return false;
                    
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabMaterial.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabMaterial.SelectedTab = tbpCmf;
                        return false;
                    }
                    break;
                    
                case "ATTACH_FLOW":
                    
                    if (lisFlowList.SelectedItems.Count <= 0 || lisFlow.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    break;
                case "DETACH_FLOW":
                    
                    if (lisFlow.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    if (lisFlow.SelectedItems[0].Index >= lisFlow.Items.Count - 1)
                    {
                        return false;
                    }
                    break;
                case "UPDATE_OPTIONAL_GROUP":
                    
                    if (lisFlow.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    if (lisFlow.SelectedItems[0].Index >= lisFlow.Items.Count - 1)
                    {
                        return false;
                    }
                    break;
            }
            
            return true;
        }
        
        //
        // Attach_Flow_ToMaterial()
        //       - Attach flow to Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool Attach_Flow_ToMaterial(string sAttachFlow, string sBeforeFlow, int iBeforeFlowSeq)
        {
            TRSNode in_node = new TRSNode("ATTACH_FLOW_TOMATERIAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));
            in_node.AddString("FLOW", MPCF.Trim(sAttachFlow));
            in_node.AddString("ADD_BEFORE_FLOW", MPCF.Trim(sBeforeFlow));
            in_node.AddInt("ADD_BEFORE_FLOW_SEQ_NUM", iBeforeFlowSeq);

            if (MPCR.CallService("WIP", "WIP_Attach_Flow_ToMaterial", in_node, ref out_node) == false)
            {
                return false;
            }

            if (Update_Optional_Flow(sAttachFlow, iBeforeFlowSeq, true) == false)
            {
                cdvOptionalGroup.Text = "";
            }

            return true;
        }

        //
        // Detach_Flow_FromMaterial()
        //       - Detach flow from Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool Detach_Flow_FromMaterial(string sFlow, int iFlowSeqNum)
        {
            TRSNode in_node = new TRSNode("DETACH_FLOW_FROMMATERIAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));

            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddInt("FLOW_SEQ_NUM", iFlowSeqNum);

            if (MPCR.CallService("WIP", "WIP_Detach_Flow_FromMaterial", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        //
        // VIEW_MATERIAL()
        //       - View Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_Material()
        {
            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            txtMaterial.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
            txtDesc.Text = MPCF.Trim(out_node.GetString("MAT_DESC"));
            txtShortDesc.Text = MPCF.Trim(out_node.GetString("MAT_SHORT_DESC"));
            cdvType.Text = MPCF.Trim(out_node.GetString("MAT_TYPE"));

            cdvUnit1.Text = MPCF.Trim(out_node.GetString("UNIT1"));
            cdvUnit2.Text = MPCF.Trim(out_node.GetString("UNIT2"));
            cdvUnit3.Text = MPCF.Trim(out_node.GetString("UNIT3"));

            txtDefaultQty1.Value = out_node.GetDouble("DEF_QTY_1");
            txtDefaultQty2.Value = out_node.GetDouble("DEF_QTY_2");
            txtDefaultQty3.Value = out_node.GetDouble("DEF_QTY_3");

            txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            txtDeleteUser.Text = MPCF.Trim(out_node.GetString("DELETE_USER_ID"));
            txtDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("DELETE_TIME"));

            chkDeleteFlag.Checked = (out_node.GetChar("DELETE_FLAG") == 'Y') ? true : false;
            chkDeactiveFlag.Checked = (out_node.GetChar("DEACTIVE_FLAG") == 'Y') ? true : false;

            txtBaseMaterial.Text = MPCF.Trim(out_node.GetString("BASE_MAT_ID"));
            txtVendor.Text = MPCF.Trim(out_node.GetString("VENDOR_ID"));
            txtVendorMaterial.Text = MPCF.Trim(out_node.GetString("VENDOR_MAT_ID"));
            txtCustomer.Text = MPCF.Trim(out_node.GetString("CUSTOMER_ID"));
            txtCustomerMaterial.Text = MPCF.Trim(out_node.GetString("CUSTOMER_MAT_ID"));
            txtMFGDevision.Text = MPCF.Trim(out_node.GetString("MFG_DEVISION"));

            chkSubContractFlag.Checked = (out_node.GetChar("SUBCONTRACT_FLAG") == 'Y') ? true : false;

            txtTargetYield.Value = out_node.GetDouble("TARGET_YIELD");
            txtTargetDueDay.Value = out_node.GetDouble("TARGET_DUE_DAY");
            txtTargetQty1.Value = out_node.GetDouble("TARGET_QTY_1");
            txtTargetQty2.Value = out_node.GetDouble("TARGET_QTY_2");
            txtTargetQty3.Value = out_node.GetDouble("TARGET_QTY_3");

            txtWetNet.Value = out_node.GetDouble("WEIGHT_NET");
            txtWetGross.Value = out_node.GetDouble("WEIGHT_GROSS");
            txtWetUnit.Text = MPCF.Trim(out_node.GetString("WEIGHT_UNIT"));

            txtVolume.Value = out_node.GetDouble("VOLUME");
            txtVolumeUnit.Text = MPCF.Trim(out_node.GetString("VOLUME_UNIT"));

            txtDimHr.Value = out_node.GetDouble("DIMENSION_HR");
            txtDimHrUnit.Text = MPCF.Trim(out_node.GetString("DIMENSION_HR_UNIT"));
            txtDimVt.Value = out_node.GetDouble("DIMENSION_VT");
            txtDimVtUnit.Text = MPCF.Trim(out_node.GetString("DIMENSION_VT_UNIT"));
            txtDimHt.Value = out_node.GetDouble("DIMENSION_HT");
            txtDimHtUnit.Text = MPCF.Trim(out_node.GetString("DIMENSION_HT_UNIT"));

            cdvPackType.Text = MPCF.Trim(out_node.GetChar("PACK_TYPE").ToString());
            txtPackLotCnt.Value = out_node.GetInt("PACK_LOT_COUNT");
            txtPackQty.Value = out_node.GetDouble("PACK_QTY");

            cdvBomSetID.Text = MPCF.Trim(out_node.GetString("BOM_SET_ID"));
            txtDefStrOper.Text = MPCF.Trim(out_node.GetString("DEF_INV_OPER"));

            txtLEStockLevel.Value = out_node.GetDouble("LE_STOCK_LEVEL");
            txtLWStockLevel.Value = out_node.GetDouble("LW_STOCK_LEVEL");
            txtHEStockLevel.Value = out_node.GetDouble("HE_STOCK_LEVEL");
            txtHWStockLevel.Value = out_node.GetDouble("HW_STOCK_LEVEL");

            chkIqcFlag.Checked = (out_node.GetChar("IQC_FLAG") == 'Y') ? true : false;
            chkIqcSampleFlag.Checked = (out_node.GetChar("IQC_SAMPLE_FLAG") == 'Y') ? true : false;
            chkIqcSampleRule.Checked = (out_node.GetChar("IQC_SAMPLE_RULE") == 'Y') ? true : false;
            chkOqcFlag.Checked = (out_node.GetChar("OQC_FLAG") == 'Y') ? true : false;
            chkOqcSampleFlag.Checked = (out_node.GetChar("OQC_SAMPLE_FLAG") == 'Y') ? true : false;
            chkOqcSampleRule.Checked = (out_node.GetChar("OQC_SAMPLE_RULE") == 'Y') ? true : false;

            cdvGroup1.Text = MPCF.Trim(out_node.GetString("MAT_GRP_1"));
            cdvGroup2.Text = MPCF.Trim(out_node.GetString("MAT_GRP_2"));
            cdvGroup3.Text = MPCF.Trim(out_node.GetString("MAT_GRP_3"));
            cdvGroup4.Text = MPCF.Trim(out_node.GetString("MAT_GRP_4"));
            cdvGroup5.Text = MPCF.Trim(out_node.GetString("MAT_GRP_5"));
            cdvGroup6.Text = MPCF.Trim(out_node.GetString("MAT_GRP_6"));
            cdvGroup7.Text = MPCF.Trim(out_node.GetString("MAT_GRP_7"));
            cdvGroup8.Text = MPCF.Trim(out_node.GetString("MAT_GRP_8"));
            cdvGroup9.Text = MPCF.Trim(out_node.GetString("MAT_GRP_9"));
            cdvGroup10.Text = MPCF.Trim(out_node.GetString("MAT_GRP_10"));

            cdvCMF1.Text = MPCF.Trim(out_node.GetString("MAT_CMF_1"));
            cdvCMF2.Text = MPCF.Trim(out_node.GetString("MAT_CMF_2"));
            cdvCMF3.Text = MPCF.Trim(out_node.GetString("MAT_CMF_3"));
            cdvCMF4.Text = MPCF.Trim(out_node.GetString("MAT_CMF_4"));
            cdvCMF5.Text = MPCF.Trim(out_node.GetString("MAT_CMF_5"));
            cdvCMF6.Text = MPCF.Trim(out_node.GetString("MAT_CMF_6"));
            cdvCMF7.Text = MPCF.Trim(out_node.GetString("MAT_CMF_7"));
            cdvCMF8.Text = MPCF.Trim(out_node.GetString("MAT_CMF_8"));
            cdvCMF9.Text = MPCF.Trim(out_node.GetString("MAT_CMF_9"));
            cdvCMF10.Text = MPCF.Trim(out_node.GetString("MAT_CMF_10"));
            cdvCMF11.Text = MPCF.Trim(out_node.GetString("MAT_CMF_11"));
            cdvCMF12.Text = MPCF.Trim(out_node.GetString("MAT_CMF_12"));
            cdvCMF13.Text = MPCF.Trim(out_node.GetString("MAT_CMF_13"));
            cdvCMF14.Text = MPCF.Trim(out_node.GetString("MAT_CMF_14"));
            cdvCMF15.Text = MPCF.Trim(out_node.GetString("MAT_CMF_15"));
            cdvCMF16.Text = MPCF.Trim(out_node.GetString("MAT_CMF_16"));
            cdvCMF17.Text = MPCF.Trim(out_node.GetString("MAT_CMF_17"));
            cdvCMF18.Text = MPCF.Trim(out_node.GetString("MAT_CMF_18"));
            cdvCMF19.Text = MPCF.Trim(out_node.GetString("MAT_CMF_19"));
            cdvCMF20.Text = MPCF.Trim(out_node.GetString("MAT_CMF_20"));

            // 이미생성된Material은다시생성하지못하고version up/update/delete 만할수있도록create button을잠근다.
            btnCreate.Enabled = false;

            udcAttributeStatus.AttributeKey = txtMaterial.Text + " : " + txtVersion.Text;
            udcAttributeStatus.View();

            return true;

        }

        //
        // Update_Material()
        //       - update Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Update_Material(char ProcStep)
        {

            TRSNode in_node = new TRSNode("UPDATE_MATERIAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;
            TreeNode node;
            bool b_ret;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;

            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));

            in_node.AddString("MAT_DESC", MPCF.Trim(txtDesc.Text));
            in_node.AddString("MAT_SHORT_DESC", MPCF.Trim(txtShortDesc.Text));
            in_node.AddString("MAT_TYPE", MPCF.Trim(cdvType.Text));

            in_node.AddString("MAT_GRP_1", MPCF.Trim(cdvGroup1.Text));
            in_node.AddString("MAT_GRP_2", MPCF.Trim(cdvGroup2.Text));
            in_node.AddString("MAT_GRP_3", MPCF.Trim(cdvGroup3.Text));
            in_node.AddString("MAT_GRP_4", MPCF.Trim(cdvGroup4.Text));
            in_node.AddString("MAT_GRP_5", MPCF.Trim(cdvGroup5.Text));
            in_node.AddString("MAT_GRP_6", MPCF.Trim(cdvGroup6.Text));
            in_node.AddString("MAT_GRP_7", MPCF.Trim(cdvGroup7.Text));
            in_node.AddString("MAT_GRP_8", MPCF.Trim(cdvGroup8.Text));
            in_node.AddString("MAT_GRP_9", MPCF.Trim(cdvGroup9.Text));
            in_node.AddString("MAT_GRP_10", MPCF.Trim(cdvGroup10.Text));

            in_node.AddString("MAT_CMF_1", MPCF.Trim(cdvCMF1.Text));
            in_node.AddString("MAT_CMF_2", MPCF.Trim(cdvCMF2.Text));
            in_node.AddString("MAT_CMF_3", MPCF.Trim(cdvCMF3.Text));
            in_node.AddString("MAT_CMF_4", MPCF.Trim(cdvCMF4.Text));
            in_node.AddString("MAT_CMF_5", MPCF.Trim(cdvCMF5.Text));
            in_node.AddString("MAT_CMF_6", MPCF.Trim(cdvCMF6.Text));
            in_node.AddString("MAT_CMF_7", MPCF.Trim(cdvCMF7.Text));
            in_node.AddString("MAT_CMF_8", MPCF.Trim(cdvCMF8.Text));
            in_node.AddString("MAT_CMF_9", MPCF.Trim(cdvCMF9.Text));
            in_node.AddString("MAT_CMF_10", MPCF.Trim(cdvCMF10.Text));
            in_node.AddString("MAT_CMF_11", MPCF.Trim(cdvCMF11.Text));
            in_node.AddString("MAT_CMF_12", MPCF.Trim(cdvCMF12.Text));
            in_node.AddString("MAT_CMF_13", MPCF.Trim(cdvCMF13.Text));
            in_node.AddString("MAT_CMF_14", MPCF.Trim(cdvCMF14.Text));
            in_node.AddString("MAT_CMF_15", MPCF.Trim(cdvCMF15.Text));
            in_node.AddString("MAT_CMF_16", MPCF.Trim(cdvCMF16.Text));
            in_node.AddString("MAT_CMF_17", MPCF.Trim(cdvCMF17.Text));
            in_node.AddString("MAT_CMF_18", MPCF.Trim(cdvCMF18.Text));
            in_node.AddString("MAT_CMF_19", MPCF.Trim(cdvCMF19.Text));
            in_node.AddString("MAT_CMF_20", MPCF.Trim(cdvCMF20.Text));

            in_node.AddString("UNIT1", MPCF.Trim(cdvUnit1.Text));
            in_node.AddString("UNIT2", MPCF.Trim(cdvUnit2.Text));
            in_node.AddString("UNIT3", MPCF.Trim(cdvUnit3.Text));

            in_node.AddString("MFG_DEVISION", MPCF.Trim(txtMFGDevision.Text));
            in_node.AddChar("SUBCONTRACT_FLAG", chkSubContractFlag.Checked ? 'Y' : ' ');
            in_node.AddString("BASE_MAT_ID", MPCF.Trim(txtBaseMaterial.Text));

            in_node.AddString("VENDOR_ID", MPCF.Trim(txtVendor.Text));
            in_node.AddString("VENDOR_MAT_ID", MPCF.Trim(txtVendorMaterial.Text));
            in_node.AddString("CUSTOMER_ID", MPCF.Trim(txtCustomer.Text));
            in_node.AddString("CUSTOMER_MAT_ID", MPCF.Trim(txtCustomerMaterial.Text));

            in_node.AddDouble("DEF_QTY_1", MPCF.ToDbl(txtDefaultQty1.Text));
            in_node.AddDouble("DEF_QTY_2", MPCF.ToDbl(txtDefaultQty2.Text));
            in_node.AddDouble("DEF_QTY_3", MPCF.ToDbl(txtDefaultQty3.Text));

            in_node.AddDouble("WEIGHT_NET", MPCF.ToDbl(txtWetNet.Text));
            in_node.AddDouble("WEIGHT_GROSS", MPCF.ToDbl(txtWetGross.Text));
            in_node.AddString("WEIGHT_UNIT", MPCF.Trim(txtWetUnit.Text));

            in_node.AddDouble("VOLUME", MPCF.ToDbl(txtVolume.Text));
            in_node.AddString("VOLUME_UNIT", MPCF.Trim(txtVolumeUnit.Text));

            in_node.AddDouble("DIMENSION_HR", MPCF.ToDbl(txtDimHr.Text));
            in_node.AddString("DIMENSION_HR_UNIT", MPCF.Trim(txtDimHrUnit.Text));
            in_node.AddDouble("DIMENSION_VT", MPCF.ToDbl(txtDimVt.Text));
            in_node.AddString("DIMENSION_VT_UNIT", MPCF.Trim(txtDimVtUnit.Text));
            in_node.AddDouble("DIMENSION_HT", MPCF.ToDbl(txtDimHt.Text));
            in_node.AddString("DIMENSION_HT_UNIT", MPCF.Trim(txtDimHtUnit.Text));

            in_node.AddString("BOM_SET_ID", MPCF.Trim(cdvBomSetID.Text));
            in_node.AddString("DEF_INV_OPER", MPCF.Trim(txtDefStrOper.Text));

            in_node.AddChar("PACK_TYPE", MPCF.ToChar(cdvPackType.Text));
            in_node.AddInt("PACK_LOT_COUNT", MPCF.ToInt(MPCF.ToDbl(txtPackLotCnt.Text)));
            in_node.AddDouble("PACK_QTY", MPCF.ToDbl(txtPackQty.Text));

            in_node.AddDouble("LE_STOCK_LEVEL", MPCF.ToDbl(txtLEStockLevel.Text));
            in_node.AddDouble("LW_STOCK_LEVEL", MPCF.ToDbl(txtLWStockLevel.Text));
            in_node.AddDouble("HE_STOCK_LEVEL", MPCF.ToDbl(txtHEStockLevel.Text));
            in_node.AddDouble("HW_STOCK_LEVEL", MPCF.ToDbl(txtHWStockLevel.Text));

            in_node.AddChar("IQC_FLAG", chkIqcFlag.Checked ? 'Y' : ' ');
            in_node.AddChar("IQC_SAMPLE_FLAG", chkIqcSampleFlag.Checked ? 'Y' : ' ');
            in_node.AddChar("IQC_SAMPLE_RULE", chkIqcSampleRule.Checked ? 'Y' : ' ');

            in_node.AddChar("OQC_FLAG", chkOqcFlag.Checked ? 'Y' : ' ');
            in_node.AddChar("OQC_SAMPLE_FLAG", chkOqcSampleFlag.Checked ? 'Y' : ' ');
            in_node.AddChar("OQC_SAMPLE_RULE", chkOqcSampleRule.Checked ? 'Y' : ' ');

            in_node.AddDouble("TARGET_YIELD", MPCF.ToDbl(txtTargetYield.Text));
            in_node.AddDouble("TARGET_DUE_DAY", MPCF.ToDbl(txtTargetDueDay.Text));
            in_node.AddDouble("TARGET_QTY_1", MPCF.ToDbl(txtTargetQty1.Text));
            in_node.AddDouble("TARGET_QTY_2", MPCF.ToDbl(txtTargetQty2.Text));
            in_node.AddDouble("TARGET_QTY_3", MPCF.ToDbl(txtTargetQty3.Text));

            in_node.AddChar("DEACTIVE_FLAG", chkDeactiveFlag.Checked ? 'Y' : ' ');

            if (MPCR.CallService("WIP", "WIP_Update_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (MPGV.gbListAutoRefresh == false)
            {
                if (ProcStep == MPGC.MP_STEP_CREATE ||
                    ProcStep == MPGC.MP_STEP_VERSION_UP)
                {
                    // 버전업된버전을알수없으므로out_node.Get("H_MSG") 필드에업된버전을담아옴.
                    if (ProcStep == MPGC.MP_STEP_VERSION_UP)
                    {
                        txtVersion.Text = out_node.GetInt("MAT_VER").ToString();
                    }

                    switch (udcMaterial.ViewType)
                    {
                        case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                            node = new TreeNode(txtVersion.Text + " : " + txtDesc.Text, (int)SMALLICON_INDEX.IDX_MATERIAL, (int)SMALLICON_INDEX.IDX_MATERIAL);
                            if (udcMaterial.SelectedNode.Parent == null)
                            {
                                udcMaterial.SelectedNode.Nodes.Add(node);
                            }
                            else
                            {
                                udcMaterial.SelectedNode.Parent.Nodes.Add(node);
                            }
                            break;

                        default:
                            itm = udcMaterial.GetListView.Items.Add(txtMaterial.Text, (int)SMALLICON_INDEX.IDX_MATERIAL);
                            itm.SubItems.Add(txtVersion.Text);
                            itm.SubItems.Add(txtDesc.Text);
                            itm.Selected = true;
                            udcMaterial.GetListView.Sorting = SortOrder.Ascending;
                            udcMaterial.GetListView.Sort();
                            itm.EnsureVisible();
                            break;
                    }
                }
                else if (ProcStep == MPGC.MP_STEP_UPDATE)
                {
                    switch (udcMaterial.ViewType)
                    {
                        case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                            udcMaterial.SelectedNode.Text = MPCF.Trim(txtVersion.Text) + " : " + MPCF.Trim(txtDesc.Text);
                            break;

                        default:
                            udcMaterial.SelectedItem.SubItems[2].Text = MPCF.Trim(txtDesc.Text);
                            break;
                    }


                }
                else if (ProcStep == MPGC.MP_STEP_DELETE)
                {
                    b_ret = udcMaterial.FindMaterial(txtMaterial.Text, txtVersion.Text, false);
                    if (b_ret == true)
                    {
                        if (udcMaterial.IncludeDeleteMaterial == true)
                        {
                            switch (udcMaterial.ViewType)
                            {
                                case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                                    udcMaterial.SelectedNode.ForeColor = Color.Magenta;
                                    break;

                                default:
                                    udcMaterial.SelectedItem.ForeColor = Color.Magenta;
                                    break;
                            }
                        }
                        else
                        {
                            switch (udcMaterial.ViewType)
                            {
                                case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                                    udcMaterial.SelectedNode.Remove();
                                    break;

                                default:
                                    udcMaterial.SelectedItem.Remove();
                                    break;
                            }
                        }
                    }
                }
                else if (ProcStep == MPGC.MP_STEP_UNDELETE)
                {
                    b_ret = udcMaterial.FindMaterial(txtMaterial.Text, txtVersion.Text, false);
                    if (b_ret == true)
                    {
                        switch (udcMaterial.ViewType)
                        {
                            case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                                udcMaterial.SelectedNode.ForeColor = Color.Black;
                                break;

                            default:
                                udcMaterial.SelectedItem.ForeColor = Color.Black;
                                break;
                        }
                    }
                    else
                    {
                        switch (udcMaterial.ViewType)
                        {
                            case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                                node = new TreeNode(txtVersion.Text + " : " + txtDesc.Text, (int)SMALLICON_INDEX.IDX_MATERIAL, (int)SMALLICON_INDEX.IDX_MATERIAL);
                                if (udcMaterial.SelectedNode.Parent == null)
                                {
                                    udcMaterial.SelectedNode.Nodes.Add(node);
                                }
                                else
                                {
                                    udcMaterial.SelectedNode.Parent.Nodes.Add(node);
                                }
                                break;

                            default:
                                itm = udcMaterial.GetListView.Items.Add(txtMaterial.Text, (int)SMALLICON_INDEX.IDX_MATERIAL);
                                itm.SubItems.Add(txtVersion.Text);
                                itm.SubItems.Add(txtDesc.Text);
                                itm.Selected = true;
                                udcMaterial.GetListView.Sorting = SortOrder.Ascending;
                                udcMaterial.GetListView.Sort();
                                itm.EnsureVisible();
                                break;
                        }
                    }
                }

                lblDataCount.Text = udcMaterial.ListCount.ToString();
            }

            return true;

        }

        //
        // Update_Optional_Flow()
        //       - Update Optional Flow Group
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool Update_Optional_Flow(string sFlow, int iFlowSeqNum, bool bNoSuccessMessage)
        {
            TRSNode in_node = new TRSNode("UPDATE_OPTIONAL_FLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_UPDATE;

            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));

            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddInt("FLOW_SEQ_NUM", iFlowSeqNum);

            in_node.AddString("OPT_FLOW_GROUP", MPCF.Trim(cdvOptionalGroup.Text));
            in_node.AddChar("OPT_FLOW_OPTION_FLAG", MPCF.ToChar(cdvOptionalGroupOption.Text));

            if (MPCR.CallService("WIP", "WIP_Update_Optional_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            if (bNoSuccessMessage == false)
            {
                MPCR.ShowSuccessMsg(out_node);
            }

            return true;

        }

        
        private void InitCodeView()
        {
            cdvOptionalGroup.Init();
            cdvOptionalGroup.SelectedSubItemIndex = 0;
            cdvOptionalGroup.DisplaySubItemIndex = 0;
            
            cdvOptionalGroupOption.Init();
            cdvOptionalGroupOption.SelectedSubItemIndex = 0;
            cdvOptionalGroupOption.DisplaySubItemIndex = 0;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        
        private void frmWIPSetupMaterial_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    tbpFlow_Resize(null, null);

                    MPCF.FieldClear(this);

                    udcMaterial.Init();
                    MPCF.InitListView(lisFlowList);
                    MPCF.InitListView(lisFlow);
                    
                    SetGroupCmfItem();
                    
                    InitCodeView();

                    if (udcMaterial.VisibleDefaultFilter == false)
                    {
                        btnRefresh.PerformClick();
                    }

                    WIPLIST.ViewFlowList(lisFlowList, '1', "", 0, "", null, "");
                    if (lisFlowList.Items.Count > 0)
                    {
                        lisFlowList.Items[0].Selected = true;
                    }
                    
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void tabMaterial_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (tabMaterial.SelectedTab == tbpFlow)
            {
                btnCreate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
            
        }

        private void udcMaterial_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this.pnlRight);
            if (udcMaterial.SelectedItem != null)
            {
                if (udcMaterial.SelectedItem.ForeColor.Equals(Color.Magenta) == true)
                {
                    this.btnDelete.Visible = false;
                    this.btnUndelete.Visible = true;
                }
                else
                {
                    this.btnDelete.Visible = true;
                    this.btnUndelete.Visible = false;
                }

                txtMaterial.Text = udcMaterial.Text;
                txtVersion.Text = udcMaterial.Version.ToString();

                View_Material();

                WIPLIST.ViewFlowList(lisFlow, '2', udcMaterial.Text, udcMaterial.Version, "", null, "");

                ListViewItem itmX;

                itmX = lisFlow.Items.Insert(lisFlow.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_FLOW);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                
                //lisFlow.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_FLOW);
                lisFlow.Items[0].Selected = true;
                lisFlow.Items[0].EnsureVisible();
            }
            else
            {
                this.btnDelete.Visible = true;
                this.btnUndelete.Visible = false;
            }
        }

        private void udcMaterial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            if (udcMaterial.SelectedNode != null)
            {
                if (udcMaterial.SelectedNode.ForeColor.Equals(Color.Magenta) == true)
                {
                    this.btnDelete.Visible = false;
                    this.btnUndelete.Visible = true;
                }
                else
                {
                    this.btnDelete.Visible = true;
                    this.btnUndelete.Visible = false;
                }

                txtMaterial.Text = udcMaterial.Text;
                txtVersion.Text = "";

                if (udcMaterial.Version > 0)
                {
                    txtVersion.Text = udcMaterial.Version.ToString();

                    View_Material();

                    WIPLIST.ViewFlowList(lisFlow, '2', udcMaterial.Text, udcMaterial.Version, "", null, "");
                    
                    ListViewItem itmX;

                    itmX = lisFlow.Items.Insert(lisFlow.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_FLOW);
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add("");
                    itmX.SubItems.Add("");

                    //lisFlow.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_FLOW);
                    lisFlow.Items[0].Selected = true;
                    lisFlow.Items[0].EnsureVisible();
                }
                else
                {
                    MPCF.InitListView(lisFlow);
                }
            }
            else
            {
                this.btnDelete.Visible = true;
                this.btnUndelete.Visible = false;
            }
        }

        private void udcMaterial_AfterGetList(object sender, EventArgs e)
        {
            lblDataCount.Text = udcMaterial.ListCount.ToString();
        }
        
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }
        
        private void cdvControl_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            cdvTemp.Columns.Add("Unit", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_WIP_UNIT_TABLE);
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            switch (udcMaterial.ViewType)
            {
                case Miracom.MESCore.Controls.MatListViewType.LastActiveVersion:
                case Miracom.MESCore.Controls.MatListViewType.AllVersion:
                    MPCF.ExportToExcel(udcMaterial.GetListView, this.Text, "");
                    break;

                case Miracom.MESCore.Controls.MatListViewType.TreeViewList:
                    break;
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            udcMaterial.ViewList();

            if (udcMaterial.ListCount > 0)
            {
                if (MPCF.Trim(txtMaterial.Text) == "")
                {
                    if (udcMaterial.ViewType != Miracom.MESCore.Controls.MatListViewType.TreeViewList)
                    {
                        udcMaterial.GetListView.Items[0].Selected = true;
                    }
                }
                else
                {
                    udcMaterial.FindMaterial(txtMaterial.Text, txtVersion.Text, false);
                }
            }
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sAFlow;
            string sBFlow;
            int iBFlowSeqNum;
            ListViewItem itmX;
            
            if (CheckCondition("ATTACH_FLOW") == false)
            {
                return;
            }
            
            sAFlow = lisFlowList.SelectedItems[0].Text;
            sBFlow = lisFlow.SelectedItems[0].Text;
            iBFlowSeqNum = lisFlow.SelectedItems[0].Index + 1;
            
            if (sBFlow == "Attach ...")
            {
                sBFlow = "";
            }

            if (Attach_Flow_ToMaterial(sAFlow, sBFlow, iBFlowSeqNum) == true)
            {
                itmX = lisFlow.Items.Insert(lisFlow.SelectedItems[0].Index, sAFlow, (int)SMALLICON_INDEX.IDX_FLOW);
                //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                itmX.SubItems.Add(lisFlowList.SelectedItems[0].SubItems[1].Text);
                itmX.SubItems.Add(cdvOptionalGroup.Text);
                itmX.SubItems.Add(cdvOptionalGroupOption.Text);
                
                if (lisFlowList.SelectedItems[0].Index + 1 < lisFlowList.Items.Count)
                {
                    lisFlowList.Items[lisFlowList.SelectedItems[0].Index + 1].Selected = true;
                }
            }
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            int iIdx;
            
            if (CheckCondition("DETACH_FLOW") == false)
            {
                return;
            }
            if (lisFlow.SelectedItems[0].Text == "Attach ...")
            {
                return;
            }

            iIdx = lisFlow.SelectedItems[0].Index;
            if (Detach_Flow_FromMaterial(lisFlow.SelectedItems[0].Text, iIdx + 1) == true)
            {
                lisFlow.Items.RemoveAt(iIdx);
                
                if (lisFlow.Items.Count - 1 == iIdx && iIdx > 0)
                {
                    iIdx--;
                }
                lisFlow.Items[iIdx].Selected = true;
            }
            
        }

        private void btnVersionUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VERSIONUP") == true)
                {
                    if (Update_Material(MPGC.MP_STEP_VERSION_UP) == false)
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
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (Update_Material(MPGC.MP_STEP_CREATE) == false)
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
                if (tabMaterial.SelectedTab == tbpFlow)
                {
                    if (CheckCondition("UPDATE_OPTIONAL_GROUP") == true)
                    {
                        string sFlow;
                        int iFlowSeqNum;
                        sFlow = lisFlow.SelectedItems[0].Text;
                        iFlowSeqNum = lisFlow.SelectedItems[0].Index + 1;

                        if (Update_Optional_Flow(sFlow, iFlowSeqNum, false) == false)
                        {
                            return;
                        }
                        //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                        lisFlow.SelectedItems[0].SubItems[2].Text = MPCF.Trim(cdvOptionalGroup.Text);
                        lisFlow.SelectedItems[0].SubItems[3].Text = MPCF.Trim(cdvOptionalGroupOption.Text);
                    }
                }
                else
                {
                    if (CheckCondition("UPDATE") == true)
                    {
                        if (Update_Material(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
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
                if (CheckCondition("DELETE") == true)
                {
                    if (Update_Material(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
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
        
        private void btnUndelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("UNDELETE") == true)
                {
                    if (Update_Material(MPGC.MP_STEP_UNDELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
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
        
        private void tbpFlow_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(tbpFlow, lisFlow, pnlFlowList, pnlAttachFlowMid, 40);
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            udcMaterial.FindMaterial(txtFind.Text, "", true);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            udcMaterial.FindMaterial(txtFind.Text, "", true);
        }
        
        private void lisFlow_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisFlow.SelectedItems.Count > 0)
            {
                if (lisFlow.SelectedItems[0].Index < lisFlow.Items.Count - 1)
                {
                    //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                    cdvOptionalGroup.Text = lisFlow.SelectedItems[0].SubItems[2].Text;
                    cdvOptionalGroupOption.Text = lisFlow.SelectedItems[0].SubItems[3].Text;
                }
            }
        }

        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_WIP_MATERIAL_TYPE);
        }
        
        private void cdvPackType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvPackType.Init();
            MPCF.InitListView(cdvPackType.GetListView);
            cdvPackType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvPackType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPackType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPackType.GetListView, '1', MPGC.MP_WIP_MATERIAL_PACKTYPE);
        }
        
        private void cdvBomSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            #if _BOM
            cdvBomSetID.Init();
            MPCF.InitListView(cdvBomSetID.GetListView);
            cdvBomSetID.Columns.Add("Set ID", 50, HorizontalAlignment.Left);
            cdvBomSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBomSetID.SelectedSubItemIndex = 0;
            
            BOMLIST.ViewBOMSetList(cdvBomSetID.GetListView, '3', null, "", -1, -1, 'M', false);
            #endif

        }

        private void txtMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabMaterial.SelectedTab == tbpAttribute)
            {
                udcAttributeStatus.ClearValue();
            }
            if (e.KeyChar < (char)33 || e.KeyChar > (char)126) return;
            if (MPCF.Trim(txtMaterial.Text) == "") return;

            MPCR.ChangeControlEnabled(this, btnCreate, true);

            txtVersion.Text = "1";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string sAFlow, sBFlow;
            int iAFlowSeq, iBFlowSeq;
            ListView.SelectedListViewItemCollection lisItems = lisFlow.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisFlow.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisFlow.Items.Count - 2)
                return;
            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = 0; i < lisItems.Count; i++)
                {
                    if (lisItems[i].Index == 0)
                        continue;

                    if (lisItems[i].Index > lisFlow.Items.Count - 2)
                        continue;

                    iAFlowSeq = lisItems[i].Index;
                    iBFlowSeq = iAFlowSeq - 1;

                    if (lisFlow.Items[iBFlowSeq].Selected == true)
                        continue;

                    sAFlow = lisFlow.Items[iAFlowSeq].Text;
                    sBFlow = lisFlow.Items[iBFlowSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Flow_Sequence(sBFlow, iBFlowSeq + 1, sAFlow, iAFlowSeq + 1) == true)
                    {
                        Swap_List_Item(iAFlowSeq, iBFlowSeq);
                        lisFlow.Items[iAFlowSeq].Selected = false;
                        lisFlow.Items[iBFlowSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string sAFlow, sBFlow;
            int iAFlowSeq, iBFlowSeq;
            ListView.SelectedListViewItemCollection lisItems = lisFlow.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisFlow.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisFlow.Items.Count - 2)
                return;

            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = lisItems.Count - 1; i >= 0; i--)
                {
                    if (lisItems[i].Index > lisFlow.Items.Count - 3)
                        continue;

                    iAFlowSeq = lisItems[i].Index;
                    iBFlowSeq = iAFlowSeq + 1;

                    if (lisFlow.Items[iBFlowSeq].Selected == true)
                        continue;

                    sAFlow = lisFlow.Items[iAFlowSeq].Text;
                    sBFlow = lisFlow.Items[iBFlowSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Flow_Sequence(sAFlow, iAFlowSeq + 1, sBFlow, iBFlowSeq + 1) == true)
                    {
                        Swap_List_Item(iAFlowSeq, iBFlowSeq);
                        lisFlow.Items[iAFlowSeq].Selected = false;
                        lisFlow.Items[iBFlowSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }
        }

        private bool Swap_Flow_Sequence(string sAFlow, int iAFlowSeq, string sBFlow, int iBFlowSeq)
        {
            TRSNode in_node = new TRSNode("SWAP_FLOW_SEQ_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtVersion.Text));
            in_node.AddString("FLOW_1", MPCF.Trim(sAFlow));
            in_node.AddInt("FLOW_SEQ_NUM_1", iAFlowSeq);
            in_node.AddString("FLOW_2", MPCF.Trim(sBFlow));
            in_node.AddInt("FLOW_SEQ_NUM_2", iBFlowSeq);

            if (MPCR.CallService("WIP", "WIP_Swap_Flow_Seq", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }


        private void Swap_List_Item(int iAOperSeq, int iBOperSeq)
        {
            string sAFlow, sAGroup, sAOption, sADesc;
            string sBFlow, sBGroup, sBOption, sBDesc;
            
            //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
            sAFlow = lisFlow.Items[iAOperSeq].SubItems[0].Text;
            sADesc = lisFlow.Items[iAOperSeq].SubItems[1].Text;
            sAGroup = lisFlow.Items[iAOperSeq].SubItems[2].Text;
            sAOption = lisFlow.Items[iAOperSeq].SubItems[3].Text;

            sBFlow = lisFlow.Items[iBOperSeq].SubItems[0].Text;
            sBDesc = lisFlow.Items[iBOperSeq].SubItems[1].Text;
            sBGroup = lisFlow.Items[iBOperSeq].SubItems[2].Text;
            sBOption = lisFlow.Items[iBOperSeq].SubItems[3].Text;

            lisFlow.Items[iAOperSeq].SubItems[0].Text = sBFlow;
            lisFlow.Items[iAOperSeq].SubItems[1].Text = sBDesc;
            lisFlow.Items[iAOperSeq].SubItems[2].Text = sBGroup;
            lisFlow.Items[iAOperSeq].SubItems[3].Text = sBOption;

            lisFlow.Items[iBOperSeq].SubItems[0].Text = sAFlow;
            lisFlow.Items[iBOperSeq].SubItems[1].Text = sADesc;
            lisFlow.Items[iBOperSeq].SubItems[2].Text = sAGroup;
            lisFlow.Items[iBOperSeq].SubItems[3].Text = sAOption;
        }

        private void btnFlowExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;


                sCond = "Material : " + udcMaterial.SelectedItem.Text;


                MPCF.ExportToExcel(lisFlow, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }    
}
