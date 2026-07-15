
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipViewLotStatus.vb
//   Description : MES Cient Form View Lot Status Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - InitCmfControl() : Initial Cmf Control
//       - SetCmfItem() : Set Cmf Item
//       - View_Lot() :View Lot Information
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-16 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPViewLotStatus : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotStatus()
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
        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.Panel pnlLotStatus;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.TabControl tabLotStatus;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TabPage tbpGeneral1;
        private System.Windows.Forms.TabPage tbpGeneral2;
        private System.Windows.Forms.TabPage tbpGeneral3;
        private System.Windows.Forms.TabPage tbpCrtCmfField;
        private System.Windows.Forms.GroupBox grpGen1Bottom;
        private System.Windows.Forms.GroupBox grpGen1Mid;
        private System.Windows.Forms.GroupBox grpGen3Mid;
        private System.Windows.Forms.CheckBox chkSampleWait;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.CheckBox chkUnitExist;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.CheckBox chkRework;
        private System.Windows.Forms.CheckBox chkTransit;
        private System.Windows.Forms.CheckBox chkInv;
        private System.Windows.Forms.CheckBox chkHold;
        private System.Windows.Forms.CheckBox chkLotDelete;
        private System.Windows.Forms.TextBox txtShipCode;
        private System.Windows.Forms.TextBox txtHoldCode;
        private System.Windows.Forms.TextBox txtOwnerCode;
        private System.Windows.Forms.TextBox txtCrtCode;
        private System.Windows.Forms.TextBox txtOperQty3;
        private System.Windows.Forms.TextBox txtCrtQty3;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtOperQty2;
        private System.Windows.Forms.TextBox txtCrtQty2;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtOperDesc;
        private System.Windows.Forms.TextBox txtDelReason;
        private System.Windows.Forms.TextBox txtSampleRes;
        private System.Windows.Forms.TextBox txtSplitFromLot;
        private System.Windows.Forms.TextBox txtLotStatus;
        private System.Windows.Forms.TextBox txtLotType;
        private System.Windows.Forms.TextBox txtOperQty1;
        private System.Windows.Forms.TextBox txtCrtQty1;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblDelReason;
        private System.Windows.Forms.Label lblSplitFromLot;
        private System.Windows.Forms.Label lblOperQty;
        private System.Windows.Forms.Label lblSampleRes;
        private System.Windows.Forms.Label lblShipCode;
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.Label lblCrtCode;
        private System.Windows.Forms.Label lblLotStatus;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.Label lblCreateQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtInvUnit;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtBatchSeq;
        private System.Windows.Forms.TextBox txtBatchID;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblBatchSeq;
        private System.Windows.Forms.Label lblBatchId;
        private System.Windows.Forms.Label lblInvUnit;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtLastActHistSeq;
        private System.Windows.Forms.TextBox txtLastHistSeq;
        private System.Windows.Forms.TextBox txtLastTrnTime;
        private System.Windows.Forms.TextBox txtLastTrnCode;
        private System.Windows.Forms.Label lblLastHistSeq;
        private System.Windows.Forms.Label lblLastActHistSeq;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblLastTrnTime;
        private System.Windows.Forms.Label lblLastTrnCode;
        private System.Windows.Forms.TextBox txtLotPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.GroupBox grpCmf;
        private System.Windows.Forms.TextBox txtCmf7;
        private System.Windows.Forms.TextBox txtCmf5;
        private System.Windows.Forms.TextBox txtCmf10;
        private System.Windows.Forms.TextBox txtCmf9;
        private System.Windows.Forms.TextBox txtCmf8;
        private System.Windows.Forms.TextBox txtCmf6;
        private System.Windows.Forms.TextBox txtCmf4;
        private System.Windows.Forms.TextBox txtCmf3;
        private System.Windows.Forms.TextBox txtCmf2;
        private System.Windows.Forms.TextBox txtCmf1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.Panel pnlResource;
        private System.Windows.Forms.GroupBox grpGen2Top;
        private System.Windows.Forms.TextBox txtResvResID;
        private System.Windows.Forms.Label lblResvRes;
        private System.Windows.Forms.GroupBox grpGen2Left;
        private System.Windows.Forms.TextBox txtLotDeleteTime;
        private System.Windows.Forms.TextBox txtOperInTime;
        private System.Windows.Forms.TextBox txtFlowInTime;
        private System.Windows.Forms.TextBox txtFactoryInTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtSchDueTime;
        private System.Windows.Forms.TextBox txtOrgDueTime;
        private System.Windows.Forms.TextBox txtShipTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblLotDeleteTime;
        private System.Windows.Forms.Label lblOperInTime;
        private System.Windows.Forms.Label lblFlowInTime;
        private System.Windows.Forms.Label lblFacInTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblSchDueTime;
        private System.Windows.Forms.Label lblOriDueTime;
        private System.Windows.Forms.Label lblShipTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.GroupBox grpBOM;
        private System.Windows.Forms.TextBox txtBOMHistSeq;
        private System.Windows.Forms.TextBox txtBOMSetVersion;
        private System.Windows.Forms.TextBox txtBOMSetID;
        private System.Windows.Forms.Label lblBOMHistSeq;
        private System.Windows.Forms.Label lblBOMSetVersion;
        private System.Windows.Forms.Label lblBOMSetID;
        private System.Windows.Forms.Panel pnlSeperator;
        private System.Windows.Forms.GroupBox grpGen2Right;
        private System.Windows.Forms.TextBox txtReworkEndOper;
        private System.Windows.Forms.TextBox txtReworkReturnOper;
        private System.Windows.Forms.TextBox txtReworkCnt;
        private System.Windows.Forms.TextBox txtReworkCode;
        private System.Windows.Forms.Label lblReworkEndOper;
        private System.Windows.Forms.Label lblReworkReturnOper;
        private System.Windows.Forms.Label lblReworkCnt;
        private System.Windows.Forms.Label lblReworkCode;
        private System.Windows.Forms.CheckBox chkNstd;
        private System.Windows.Forms.TextBox txtNstdReturnOper;
        private System.Windows.Forms.Label lblNstdReturnOper;
        private System.Windows.Forms.TextBox txtAddOrder3;
        private System.Windows.Forms.TextBox txtAddOrder2;
        private System.Windows.Forms.TextBox txtAddOrder1;
        private System.Windows.Forms.Label lblAddOrder3;
        private System.Windows.Forms.Label lblAddOrder2;
        private System.Windows.Forms.Label lblAddOrder1;
        private System.Windows.Forms.TextBox txtBomActHistSeq;
        private System.Windows.Forms.Label lblBomActHistSeq;
        private System.Windows.Forms.TextBox txtCmf17;
        private System.Windows.Forms.TextBox txtCmf15;
        private System.Windows.Forms.TextBox txtCmf20;
        private System.Windows.Forms.TextBox txtCmf19;
        private System.Windows.Forms.TextBox txtCmf18;
        private System.Windows.Forms.TextBox txtCmf16;
        private System.Windows.Forms.TextBox txtCmf14;
        private System.Windows.Forms.TextBox txtCmf13;
        private System.Windows.Forms.TextBox txtCmf12;
        private System.Windows.Forms.TextBox txtCmf11;
        private System.Windows.Forms.Label lblCMF20;
        private System.Windows.Forms.Label lblCMF19;
        private System.Windows.Forms.Label lblCMF18;
        private System.Windows.Forms.Label lblCMF17;
        private System.Windows.Forms.Label lblCMF16;
        private System.Windows.Forms.Label lblCMF15;
        private System.Windows.Forms.Label lblCMF14;
        private System.Windows.Forms.Label lblCMF13;
        private System.Windows.Forms.Label lblCMF12;
        private System.Windows.Forms.Label lblCMF11;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.TextBox txtRepairRetOper;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private TextBox txtFactory;
        private Label lblFactory;
        private TabPage tbpGeneral4;
        private TextBox txtStartQty3;
        private TextBox txtStartQty2;
        private TextBox txtStartQty1;
        private Label lblStartQty;
        private TextBox txtSubResID;
        private TextBox txtSaveResID2;
        private TextBox txtSaveResID1;
        private Label lblSubResID;
        private Label lblSaveResID1;
        private Miracom.MESCore.Controls.udcMaterial udcReworkReturnFlow;
        private Miracom.MESCore.Controls.udcMaterial udcReworkEndFlow;
        private Miracom.MESCore.Controls.udcMaterial udcNstdReturnFlow;
        private GroupBox grpCriticalResource;
        private GroupBox grpLotGroup;
        private Panel pnlReserve;
        private GroupBox grpReserve;
        private CheckBox chkReserveFlag1;
        private CheckBox chkReserveFlag2;
        private CheckBox chkReserveFlag3;
        private CheckBox chkReserveFlag4;
        private CheckBox chkReserveFlag5;
        private TextBox txtReserveField5;
        private TextBox txtReserveField3;
        private TextBox txtReserveField4;
        private TextBox txtReserveField2;
        private TextBox txtReserveField1;
        private Label lblResvField5;
        private Label lblResvField3;
        private Label lblResvField4;
        private Label lblResvField2;
        private Label lblResvField1;
        private Label CriticalResourceGroupID;
        private Label lblCriticalResourceID;
        private TextBox txtCriticalResourceGroupID;
        private TextBox txtCriticalResourceID;
        private Label lblLotGroupID1;
        private Label lblLotGroupID2;
        private Label lblHoldPrvGroupID;
        private Label lblLotGroupID3;
        private TextBox txtLotGroupID1;
        private TextBox txtLotGroupID2;
        private TextBox txtLotGroupID3;
        private TextBox txtHoldPrvGroupID;
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Button btnHistory;
        private TabPage tbpSubLot;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private GroupBox grpSublot;
        private TextBox txtLotLocation3;
        private Label lblLotLocation3;
        private TextBox txtLotLocation2;
        private Label lblLotLocation2;
        private TextBox txtLotLocation1;
        private Label lblLotLocation1;
        private TextBox txtStrRetOper;
        private Label lblStrRetOper;
        private TextBox txtStrRetFlowSeq;
        private Label lblStrRetFlowSeq;
        private TextBox txtStrRetFlow;
        private Label lblStrRetFlow;
        private TextBox txtFromToFlag;
        private Label lblFromTo;
        private TextBox txtPort;
        private Label lblPort;
        private Label lblYield3;
        private TextBox txtYield3;
        private Label lblYield2;
        private TextBox txtYield2;
        private Label lblYield1;
        private TextBox txtYield1;
        private Label lblGoodQty;
        private TextBox txtGoodQty;
        private TextBox txtReworkDepth;
        private TextBox txtReturnOption;
        private Label lblReturnOption;
        private TextBox txtReworkStopOper;
        private Label lblReworkStopOper;
        private TextBox txtNstdTime;
        private Label lblNstdTime;
        private TextBox txtReworkTime;
        private Label lblRwkTime;
        private CheckBox chkLocalRework;
        private UI.Controls.MCListView.MCListView lisEndResList;
        private ColumnHeader colEndResID;
        private ColumnHeader colEndQty;
        private UI.Controls.MCListView.MCListView lisStartResList;
        private ColumnHeader colStartResID;
        private ColumnHeader colStartQty;
        private UI.Controls.MCListView.MCListView lisCrrList;
        private ColumnHeader colCrrID;
        private ColumnHeader colCrrQty1;
        private ColumnHeader colCrrQty2;
        private ColumnHeader colCrrQty3;
        private TabPage tabLotExt;
        private GroupBox grpExt;
        private FarPoint.Win.Spread.FpSpread spdExtList;
        private FarPoint.Win.Spread.SheetView spdExtList_Sheet1;
        private System.Windows.Forms.Label lblRepairRetOper;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlLotStatus = new System.Windows.Forms.Panel();
            this.tabLotStatus = new System.Windows.Forms.TabControl();
            this.tbpGeneral1 = new System.Windows.Forms.TabPage();
            this.grpGen1Mid = new System.Windows.Forms.GroupBox();
            this.txtFromToFlag = new System.Windows.Forms.TextBox();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.txtLotPriority = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.chkSampleWait = new System.Windows.Forms.CheckBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkUnitExist = new System.Windows.Forms.CheckBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.chkNstd = new System.Windows.Forms.CheckBox();
            this.chkRework = new System.Windows.Forms.CheckBox();
            this.chkTransit = new System.Windows.Forms.CheckBox();
            this.chkInv = new System.Windows.Forms.CheckBox();
            this.chkHold = new System.Windows.Forms.CheckBox();
            this.chkLotDelete = new System.Windows.Forms.CheckBox();
            this.txtShipCode = new System.Windows.Forms.TextBox();
            this.txtHoldCode = new System.Windows.Forms.TextBox();
            this.txtOwnerCode = new System.Windows.Forms.TextBox();
            this.txtCrtCode = new System.Windows.Forms.TextBox();
            this.txtStartQty3 = new System.Windows.Forms.TextBox();
            this.txtOperQty3 = new System.Windows.Forms.TextBox();
            this.txtCrtQty3 = new System.Windows.Forms.TextBox();
            this.txtStartQty2 = new System.Windows.Forms.TextBox();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtOperQty2 = new System.Windows.Forms.TextBox();
            this.txtCrtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtOperDesc = new System.Windows.Forms.TextBox();
            this.txtDelReason = new System.Windows.Forms.TextBox();
            this.txtSampleRes = new System.Windows.Forms.TextBox();
            this.txtSplitFromLot = new System.Windows.Forms.TextBox();
            this.txtLotStatus = new System.Windows.Forms.TextBox();
            this.txtStartQty1 = new System.Windows.Forms.TextBox();
            this.txtLotType = new System.Windows.Forms.TextBox();
            this.txtOperQty1 = new System.Windows.Forms.TextBox();
            this.txtCrtQty1 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblDelReason = new System.Windows.Forms.Label();
            this.lblSplitFromLot = new System.Windows.Forms.Label();
            this.lblStartQty = new System.Windows.Forms.Label();
            this.lblOperQty = new System.Windows.Forms.Label();
            this.lblSampleRes = new System.Windows.Forms.Label();
            this.lblShipCode = new System.Windows.Forms.Label();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.lblCrtCode = new System.Windows.Forms.Label();
            this.lblLotStatus = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.lblCreateQty = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.grpGen1Bottom = new System.Windows.Forms.GroupBox();
            this.txtInvUnit = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtBatchSeq = new System.Windows.Forms.TextBox();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblBatchSeq = new System.Windows.Forms.Label();
            this.lblBatchId = new System.Windows.Forms.Label();
            this.lblInvUnit = new System.Windows.Forms.Label();
            this.tbpGeneral2 = new System.Windows.Forms.TabPage();
            this.grpGen2Right = new System.Windows.Forms.GroupBox();
            this.chkLocalRework = new System.Windows.Forms.CheckBox();
            this.txtReturnOption = new System.Windows.Forms.TextBox();
            this.lblReturnOption = new System.Windows.Forms.Label();
            this.txtReworkStopOper = new System.Windows.Forms.TextBox();
            this.lblReworkStopOper = new System.Windows.Forms.Label();
            this.txtReworkDepth = new System.Windows.Forms.TextBox();
            this.udcNstdReturnFlow = new Miracom.MESCore.Controls.udcMaterial();
            this.udcReworkEndFlow = new Miracom.MESCore.Controls.udcMaterial();
            this.udcReworkReturnFlow = new Miracom.MESCore.Controls.udcMaterial();
            this.txtRepairRetOper = new System.Windows.Forms.TextBox();
            this.lblRepairRetOper = new System.Windows.Forms.Label();
            this.txtNstdReturnOper = new System.Windows.Forms.TextBox();
            this.txtReworkEndOper = new System.Windows.Forms.TextBox();
            this.txtReworkReturnOper = new System.Windows.Forms.TextBox();
            this.txtReworkCnt = new System.Windows.Forms.TextBox();
            this.txtReworkCode = new System.Windows.Forms.TextBox();
            this.lblNstdReturnOper = new System.Windows.Forms.Label();
            this.lblReworkEndOper = new System.Windows.Forms.Label();
            this.lblReworkReturnOper = new System.Windows.Forms.Label();
            this.lblReworkCnt = new System.Windows.Forms.Label();
            this.lblReworkCode = new System.Windows.Forms.Label();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.grpGen2Left = new System.Windows.Forms.GroupBox();
            this.txtNstdTime = new System.Windows.Forms.TextBox();
            this.lblNstdTime = new System.Windows.Forms.Label();
            this.txtReworkTime = new System.Windows.Forms.TextBox();
            this.lblRwkTime = new System.Windows.Forms.Label();
            this.txtLotDeleteTime = new System.Windows.Forms.TextBox();
            this.txtOperInTime = new System.Windows.Forms.TextBox();
            this.txtFlowInTime = new System.Windows.Forms.TextBox();
            this.txtFactoryInTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtSchDueTime = new System.Windows.Forms.TextBox();
            this.txtOrgDueTime = new System.Windows.Forms.TextBox();
            this.txtShipTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblLotDeleteTime = new System.Windows.Forms.Label();
            this.lblOperInTime = new System.Windows.Forms.Label();
            this.lblFlowInTime = new System.Windows.Forms.Label();
            this.lblFacInTime = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblSchDueTime = new System.Windows.Forms.Label();
            this.lblOriDueTime = new System.Windows.Forms.Label();
            this.lblShipTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.pnlResource = new System.Windows.Forms.Panel();
            this.grpGen2Top = new System.Windows.Forms.GroupBox();
            this.lisEndResList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colEndResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisStartResList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colStartResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtSubResID = new System.Windows.Forms.TextBox();
            this.txtResvResID = new System.Windows.Forms.TextBox();
            this.txtSaveResID2 = new System.Windows.Forms.TextBox();
            this.txtSaveResID1 = new System.Windows.Forms.TextBox();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.lblResvRes = new System.Windows.Forms.Label();
            this.lblSaveResID1 = new System.Windows.Forms.Label();
            this.tbpGeneral3 = new System.Windows.Forms.TabPage();
            this.grpBOM = new System.Windows.Forms.GroupBox();
            this.txtStrRetOper = new System.Windows.Forms.TextBox();
            this.lblStrRetOper = new System.Windows.Forms.Label();
            this.txtStrRetFlowSeq = new System.Windows.Forms.TextBox();
            this.lblStrRetFlowSeq = new System.Windows.Forms.Label();
            this.txtStrRetFlow = new System.Windows.Forms.TextBox();
            this.lblStrRetFlow = new System.Windows.Forms.Label();
            this.txtLotLocation3 = new System.Windows.Forms.TextBox();
            this.lblLotLocation3 = new System.Windows.Forms.Label();
            this.txtLotLocation2 = new System.Windows.Forms.TextBox();
            this.lblLotLocation2 = new System.Windows.Forms.Label();
            this.txtLotLocation1 = new System.Windows.Forms.TextBox();
            this.lblLotLocation1 = new System.Windows.Forms.Label();
            this.txtBomActHistSeq = new System.Windows.Forms.TextBox();
            this.lblBomActHistSeq = new System.Windows.Forms.Label();
            this.txtAddOrder3 = new System.Windows.Forms.TextBox();
            this.txtAddOrder2 = new System.Windows.Forms.TextBox();
            this.txtAddOrder1 = new System.Windows.Forms.TextBox();
            this.lblAddOrder3 = new System.Windows.Forms.Label();
            this.lblAddOrder2 = new System.Windows.Forms.Label();
            this.lblAddOrder1 = new System.Windows.Forms.Label();
            this.txtBOMHistSeq = new System.Windows.Forms.TextBox();
            this.txtBOMSetVersion = new System.Windows.Forms.TextBox();
            this.txtBOMSetID = new System.Windows.Forms.TextBox();
            this.lblBOMHistSeq = new System.Windows.Forms.Label();
            this.lblBOMSetVersion = new System.Windows.Forms.Label();
            this.lblBOMSetID = new System.Windows.Forms.Label();
            this.grpGen3Mid = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtLastActHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastTrnTime = new System.Windows.Forms.TextBox();
            this.txtLastTrnCode = new System.Windows.Forms.TextBox();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.lblLastActHistSeq = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblLastTrnTime = new System.Windows.Forms.Label();
            this.lblLastTrnCode = new System.Windows.Forms.Label();
            this.tbpGeneral4 = new System.Windows.Forms.TabPage();
            this.grpCriticalResource = new System.Windows.Forms.GroupBox();
            this.lisCrrList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCrrID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCrrQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCrrQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCrrQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CriticalResourceGroupID = new System.Windows.Forms.Label();
            this.lblCriticalResourceID = new System.Windows.Forms.Label();
            this.txtCriticalResourceGroupID = new System.Windows.Forms.TextBox();
            this.txtCriticalResourceID = new System.Windows.Forms.TextBox();
            this.grpLotGroup = new System.Windows.Forms.GroupBox();
            this.lblGoodQty = new System.Windows.Forms.Label();
            this.txtGoodQty = new System.Windows.Forms.TextBox();
            this.lblYield3 = new System.Windows.Forms.Label();
            this.txtYield3 = new System.Windows.Forms.TextBox();
            this.lblYield2 = new System.Windows.Forms.Label();
            this.txtYield2 = new System.Windows.Forms.TextBox();
            this.lblYield1 = new System.Windows.Forms.Label();
            this.txtYield1 = new System.Windows.Forms.TextBox();
            this.lblLotGroupID1 = new System.Windows.Forms.Label();
            this.lblLotGroupID2 = new System.Windows.Forms.Label();
            this.lblHoldPrvGroupID = new System.Windows.Forms.Label();
            this.lblLotGroupID3 = new System.Windows.Forms.Label();
            this.txtLotGroupID1 = new System.Windows.Forms.TextBox();
            this.txtLotGroupID2 = new System.Windows.Forms.TextBox();
            this.txtLotGroupID3 = new System.Windows.Forms.TextBox();
            this.txtHoldPrvGroupID = new System.Windows.Forms.TextBox();
            this.pnlReserve = new System.Windows.Forms.Panel();
            this.grpReserve = new System.Windows.Forms.GroupBox();
            this.chkReserveFlag1 = new System.Windows.Forms.CheckBox();
            this.chkReserveFlag2 = new System.Windows.Forms.CheckBox();
            this.chkReserveFlag3 = new System.Windows.Forms.CheckBox();
            this.chkReserveFlag4 = new System.Windows.Forms.CheckBox();
            this.chkReserveFlag5 = new System.Windows.Forms.CheckBox();
            this.txtReserveField5 = new System.Windows.Forms.TextBox();
            this.txtReserveField3 = new System.Windows.Forms.TextBox();
            this.txtReserveField4 = new System.Windows.Forms.TextBox();
            this.txtReserveField2 = new System.Windows.Forms.TextBox();
            this.txtReserveField1 = new System.Windows.Forms.TextBox();
            this.lblResvField5 = new System.Windows.Forms.Label();
            this.lblResvField3 = new System.Windows.Forms.Label();
            this.lblResvField4 = new System.Windows.Forms.Label();
            this.lblResvField2 = new System.Windows.Forms.Label();
            this.lblResvField1 = new System.Windows.Forms.Label();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.tbpSubLot = new System.Windows.Forms.TabPage();
            this.grpSublot = new System.Windows.Forms.GroupBox();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpCrtCmfField = new System.Windows.Forms.TabPage();
            this.grpCmf = new System.Windows.Forms.GroupBox();
            this.txtCmf17 = new System.Windows.Forms.TextBox();
            this.txtCmf15 = new System.Windows.Forms.TextBox();
            this.txtCmf20 = new System.Windows.Forms.TextBox();
            this.txtCmf19 = new System.Windows.Forms.TextBox();
            this.txtCmf18 = new System.Windows.Forms.TextBox();
            this.txtCmf16 = new System.Windows.Forms.TextBox();
            this.txtCmf14 = new System.Windows.Forms.TextBox();
            this.txtCmf13 = new System.Windows.Forms.TextBox();
            this.txtCmf12 = new System.Windows.Forms.TextBox();
            this.txtCmf11 = new System.Windows.Forms.TextBox();
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
            this.txtCmf7 = new System.Windows.Forms.TextBox();
            this.txtCmf5 = new System.Windows.Forms.TextBox();
            this.txtCmf10 = new System.Windows.Forms.TextBox();
            this.txtCmf9 = new System.Windows.Forms.TextBox();
            this.txtCmf8 = new System.Windows.Forms.TextBox();
            this.txtCmf6 = new System.Windows.Forms.TextBox();
            this.txtCmf4 = new System.Windows.Forms.TextBox();
            this.txtCmf3 = new System.Windows.Forms.TextBox();
            this.txtCmf2 = new System.Windows.Forms.TextBox();
            this.txtCmf1 = new System.Windows.Forms.TextBox();
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
            this.tabLotExt = new System.Windows.Forms.TabPage();
            this.grpExt = new System.Windows.Forms.GroupBox();
            this.spdExtList = new FarPoint.Win.Spread.FpSpread();
            this.spdExtList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlLot = new System.Windows.Forms.Panel();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.lblFactory = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLotStatus.SuspendLayout();
            this.tabLotStatus.SuspendLayout();
            this.tbpGeneral1.SuspendLayout();
            this.grpGen1Mid.SuspendLayout();
            this.grpGen1Bottom.SuspendLayout();
            this.tbpGeneral2.SuspendLayout();
            this.grpGen2Right.SuspendLayout();
            this.grpGen2Left.SuspendLayout();
            this.pnlResource.SuspendLayout();
            this.grpGen2Top.SuspendLayout();
            this.tbpGeneral3.SuspendLayout();
            this.grpBOM.SuspendLayout();
            this.grpGen3Mid.SuspendLayout();
            this.tbpGeneral4.SuspendLayout();
            this.grpCriticalResource.SuspendLayout();
            this.grpLotGroup.SuspendLayout();
            this.pnlReserve.SuspendLayout();
            this.grpReserve.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.tbpSubLot.SuspendLayout();
            this.grpSublot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.tbpCrtCmfField.SuspendLayout();
            this.grpCmf.SuspendLayout();
            this.tabLotExt.SuspendLayout();
            this.grpExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtList_Sheet1)).BeginInit();
            this.pnlLot.SuspendLayout();
            this.grpLot.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(465, 7);
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistory);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlLotStatus);
            this.pnlCenter.Controls.Add(this.pnlLot);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            this.pnlCenter.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Status";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            // 
            // pnlLotStatus
            // 
            this.pnlLotStatus.Controls.Add(this.tabLotStatus);
            this.pnlLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotStatus.Location = new System.Drawing.Point(0, 70);
            this.pnlLotStatus.Name = "pnlLotStatus";
            this.pnlLotStatus.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlLotStatus.Size = new System.Drawing.Size(742, 443);
            this.pnlLotStatus.TabIndex = 1;
            // 
            // tabLotStatus
            // 
            this.tabLotStatus.Controls.Add(this.tbpGeneral1);
            this.tabLotStatus.Controls.Add(this.tbpGeneral2);
            this.tabLotStatus.Controls.Add(this.tbpGeneral3);
            this.tabLotStatus.Controls.Add(this.tbpGeneral4);
            this.tabLotStatus.Controls.Add(this.tbpAttribute);
            this.tabLotStatus.Controls.Add(this.tbpSubLot);
            this.tabLotStatus.Controls.Add(this.tbpCrtCmfField);
            this.tabLotStatus.Controls.Add(this.tabLotExt);
            this.tabLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLotStatus.ItemSize = new System.Drawing.Size(60, 18);
            this.tabLotStatus.Location = new System.Drawing.Point(3, 5);
            this.tabLotStatus.Name = "tabLotStatus";
            this.tabLotStatus.SelectedIndex = 0;
            this.tabLotStatus.Size = new System.Drawing.Size(736, 438);
            this.tabLotStatus.TabIndex = 0;
            // 
            // tbpGeneral1
            // 
            this.tbpGeneral1.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral1.Controls.Add(this.grpGen1Mid);
            this.tbpGeneral1.Controls.Add(this.grpGen1Bottom);
            this.tbpGeneral1.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral1.Name = "tbpGeneral1";
            this.tbpGeneral1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral1.Size = new System.Drawing.Size(728, 412);
            this.tbpGeneral1.TabIndex = 0;
            this.tbpGeneral1.Text = "General 1";
            // 
            // grpGen1Mid
            // 
            this.grpGen1Mid.Controls.Add(this.txtFromToFlag);
            this.grpGen1Mid.Controls.Add(this.lblFromTo);
            this.grpGen1Mid.Controls.Add(this.cdvFlow);
            this.grpGen1Mid.Controls.Add(this.cdvMaterial);
            this.grpGen1Mid.Controls.Add(this.chkRepair);
            this.grpGen1Mid.Controls.Add(this.txtLotPriority);
            this.grpGen1Mid.Controls.Add(this.lblPriority);
            this.grpGen1Mid.Controls.Add(this.chkSampleWait);
            this.grpGen1Mid.Controls.Add(this.chkSample);
            this.grpGen1Mid.Controls.Add(this.chkUnitExist);
            this.grpGen1Mid.Controls.Add(this.chkEnd);
            this.grpGen1Mid.Controls.Add(this.chkStart);
            this.grpGen1Mid.Controls.Add(this.chkNstd);
            this.grpGen1Mid.Controls.Add(this.chkRework);
            this.grpGen1Mid.Controls.Add(this.chkTransit);
            this.grpGen1Mid.Controls.Add(this.chkInv);
            this.grpGen1Mid.Controls.Add(this.chkHold);
            this.grpGen1Mid.Controls.Add(this.chkLotDelete);
            this.grpGen1Mid.Controls.Add(this.txtShipCode);
            this.grpGen1Mid.Controls.Add(this.txtHoldCode);
            this.grpGen1Mid.Controls.Add(this.txtOwnerCode);
            this.grpGen1Mid.Controls.Add(this.txtCrtCode);
            this.grpGen1Mid.Controls.Add(this.txtStartQty3);
            this.grpGen1Mid.Controls.Add(this.txtOperQty3);
            this.grpGen1Mid.Controls.Add(this.txtCrtQty3);
            this.grpGen1Mid.Controls.Add(this.txtStartQty2);
            this.grpGen1Mid.Controls.Add(this.txtQty3);
            this.grpGen1Mid.Controls.Add(this.txtOperQty2);
            this.grpGen1Mid.Controls.Add(this.txtCrtQty2);
            this.grpGen1Mid.Controls.Add(this.txtQty2);
            this.grpGen1Mid.Controls.Add(this.txtOperDesc);
            this.grpGen1Mid.Controls.Add(this.txtDelReason);
            this.grpGen1Mid.Controls.Add(this.txtSampleRes);
            this.grpGen1Mid.Controls.Add(this.txtSplitFromLot);
            this.grpGen1Mid.Controls.Add(this.txtLotStatus);
            this.grpGen1Mid.Controls.Add(this.txtStartQty1);
            this.grpGen1Mid.Controls.Add(this.txtLotType);
            this.grpGen1Mid.Controls.Add(this.txtOperQty1);
            this.grpGen1Mid.Controls.Add(this.txtCrtQty1);
            this.grpGen1Mid.Controls.Add(this.txtQty1);
            this.grpGen1Mid.Controls.Add(this.txtOper);
            this.grpGen1Mid.Controls.Add(this.lblDelReason);
            this.grpGen1Mid.Controls.Add(this.lblSplitFromLot);
            this.grpGen1Mid.Controls.Add(this.lblStartQty);
            this.grpGen1Mid.Controls.Add(this.lblOperQty);
            this.grpGen1Mid.Controls.Add(this.lblSampleRes);
            this.grpGen1Mid.Controls.Add(this.lblShipCode);
            this.grpGen1Mid.Controls.Add(this.lblHoldCode);
            this.grpGen1Mid.Controls.Add(this.lblOwnerCode);
            this.grpGen1Mid.Controls.Add(this.lblCrtCode);
            this.grpGen1Mid.Controls.Add(this.lblLotStatus);
            this.grpGen1Mid.Controls.Add(this.lblLotType);
            this.grpGen1Mid.Controls.Add(this.lblCreateQty);
            this.grpGen1Mid.Controls.Add(this.lblQty);
            this.grpGen1Mid.Controls.Add(this.lblOper);
            this.grpGen1Mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGen1Mid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen1Mid.Location = new System.Drawing.Point(3, 0);
            this.grpGen1Mid.Name = "grpGen1Mid";
            this.grpGen1Mid.Size = new System.Drawing.Size(722, 337);
            this.grpGen1Mid.TabIndex = 0;
            this.grpGen1Mid.TabStop = false;
            // 
            // txtFromToFlag
            // 
            this.txtFromToFlag.Location = new System.Drawing.Point(398, 278);
            this.txtFromToFlag.MaxLength = 10;
            this.txtFromToFlag.Name = "txtFromToFlag";
            this.txtFromToFlag.ReadOnly = true;
            this.txtFromToFlag.Size = new System.Drawing.Size(130, 20);
            this.txtFromToFlag.TabIndex = 42;
            this.txtFromToFlag.TabStop = false;
            // 
            // lblFromTo
            // 
            this.lblFromTo.AutoSize = true;
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(293, 281);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(69, 13);
            this.lblFromTo.TabIndex = 41;
            this.lblFromTo.Text = "From To Flag";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = true;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 115;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(15, 40);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = true;
            this.cdvFlow.Size = new System.Drawing.Size(699, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.TabStop = false;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = true;
            this.cdvFlow.VisibleFlowButton = false;
            this.cdvFlow.VisibleSequenceButton = false;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 212;
            this.cdvFlow.WidthSequence = 50;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
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
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(699, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.TabStop = false;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 115;
            this.cdvMaterial.WidthMaterialAndVersion = 212;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Enabled = false;
            this.chkRepair.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRepair.Location = new System.Drawing.Point(552, 187);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(86, 18);
            this.chkRepair.TabIndex = 49;
            this.chkRepair.TabStop = false;
            this.chkRepair.Text = "Repair Flag";
            // 
            // txtLotPriority
            // 
            this.txtLotPriority.Location = new System.Drawing.Point(130, 232);
            this.txtLotPriority.MaxLength = 10;
            this.txtLotPriority.Name = "txtLotPriority";
            this.txtLotPriority.ReadOnly = true;
            this.txtLotPriority.Size = new System.Drawing.Size(132, 20);
            this.txtLotPriority.TabIndex = 26;
            this.txtLotPriority.TabStop = false;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Location = new System.Drawing.Point(15, 235);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(56, 13);
            this.lblPriority.TabIndex = 25;
            this.lblPriority.Text = "Lot Priority";
            // 
            // chkSampleWait
            // 
            this.chkSampleWait.AutoSize = true;
            this.chkSampleWait.Enabled = false;
            this.chkSampleWait.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSampleWait.Location = new System.Drawing.Point(552, 281);
            this.chkSampleWait.Name = "chkSampleWait";
            this.chkSampleWait.Size = new System.Drawing.Size(115, 18);
            this.chkSampleWait.TabIndex = 53;
            this.chkSampleWait.TabStop = false;
            this.chkSampleWait.Text = "Sample Wait Flag";
            // 
            // chkSample
            // 
            this.chkSample.AutoSize = true;
            this.chkSample.Enabled = false;
            this.chkSample.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSample.Location = new System.Drawing.Point(552, 258);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(90, 18);
            this.chkSample.TabIndex = 52;
            this.chkSample.TabStop = false;
            this.chkSample.Text = "Sample Flag";
            // 
            // chkUnitExist
            // 
            this.chkUnitExist.AutoSize = true;
            this.chkUnitExist.Enabled = false;
            this.chkUnitExist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnitExist.Location = new System.Drawing.Point(552, 307);
            this.chkUnitExist.Name = "chkUnitExist";
            this.chkUnitExist.Size = new System.Drawing.Size(99, 18);
            this.chkUnitExist.TabIndex = 54;
            this.chkUnitExist.TabStop = false;
            this.chkUnitExist.Text = "Unit Exist Flag";
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.Enabled = false;
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(419, 307);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(74, 18);
            this.chkEnd.TabIndex = 44;
            this.chkEnd.TabStop = false;
            this.chkEnd.Text = "End Flag";
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.Enabled = false;
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(293, 307);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(77, 18);
            this.chkStart.TabIndex = 43;
            this.chkStart.TabStop = false;
            this.chkStart.Text = "Start Flag";
            // 
            // chkNstd
            // 
            this.chkNstd.AutoSize = true;
            this.chkNstd.Enabled = false;
            this.chkNstd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNstd.Location = new System.Drawing.Point(552, 163);
            this.chkNstd.Name = "chkNstd";
            this.chkNstd.Size = new System.Drawing.Size(121, 18);
            this.chkNstd.TabIndex = 48;
            this.chkNstd.TabStop = false;
            this.chkNstd.Text = "Non Standard Flag";
            // 
            // chkRework
            // 
            this.chkRework.AutoSize = true;
            this.chkRework.Enabled = false;
            this.chkRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRework.Location = new System.Drawing.Point(552, 139);
            this.chkRework.Name = "chkRework";
            this.chkRework.Size = new System.Drawing.Size(92, 18);
            this.chkRework.TabIndex = 47;
            this.chkRework.TabStop = false;
            this.chkRework.Text = "Rework Flag";
            // 
            // chkTransit
            // 
            this.chkTransit.AutoSize = true;
            this.chkTransit.Enabled = false;
            this.chkTransit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTransit.Location = new System.Drawing.Point(552, 235);
            this.chkTransit.Name = "chkTransit";
            this.chkTransit.Size = new System.Drawing.Size(87, 18);
            this.chkTransit.TabIndex = 51;
            this.chkTransit.TabStop = false;
            this.chkTransit.Text = "Transit Flag";
            // 
            // chkInv
            // 
            this.chkInv.AutoSize = true;
            this.chkInv.Enabled = false;
            this.chkInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInv.Location = new System.Drawing.Point(552, 211);
            this.chkInv.Name = "chkInv";
            this.chkInv.Size = new System.Drawing.Size(99, 18);
            this.chkInv.TabIndex = 50;
            this.chkInv.TabStop = false;
            this.chkInv.Text = "Inventory Flag";
            // 
            // chkHold
            // 
            this.chkHold.AutoSize = true;
            this.chkHold.Enabled = false;
            this.chkHold.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHold.Location = new System.Drawing.Point(552, 115);
            this.chkHold.Name = "chkHold";
            this.chkHold.Size = new System.Drawing.Size(77, 18);
            this.chkHold.TabIndex = 46;
            this.chkHold.TabStop = false;
            this.chkHold.Text = "Hold Flag";
            // 
            // chkLotDelete
            // 
            this.chkLotDelete.AutoSize = true;
            this.chkLotDelete.Enabled = false;
            this.chkLotDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLotDelete.Location = new System.Drawing.Point(552, 91);
            this.chkLotDelete.Name = "chkLotDelete";
            this.chkLotDelete.Size = new System.Drawing.Size(104, 18);
            this.chkLotDelete.TabIndex = 45;
            this.chkLotDelete.TabStop = false;
            this.chkLotDelete.Text = "Lot Delete Flag";
            // 
            // txtShipCode
            // 
            this.txtShipCode.Location = new System.Drawing.Point(398, 255);
            this.txtShipCode.MaxLength = 10;
            this.txtShipCode.Name = "txtShipCode";
            this.txtShipCode.ReadOnly = true;
            this.txtShipCode.Size = new System.Drawing.Size(130, 20);
            this.txtShipCode.TabIndex = 40;
            this.txtShipCode.TabStop = false;
            // 
            // txtHoldCode
            // 
            this.txtHoldCode.Location = new System.Drawing.Point(398, 232);
            this.txtHoldCode.MaxLength = 10;
            this.txtHoldCode.Name = "txtHoldCode";
            this.txtHoldCode.ReadOnly = true;
            this.txtHoldCode.Size = new System.Drawing.Size(130, 20);
            this.txtHoldCode.TabIndex = 38;
            this.txtHoldCode.TabStop = false;
            // 
            // txtOwnerCode
            // 
            this.txtOwnerCode.Location = new System.Drawing.Point(398, 208);
            this.txtOwnerCode.MaxLength = 10;
            this.txtOwnerCode.Name = "txtOwnerCode";
            this.txtOwnerCode.ReadOnly = true;
            this.txtOwnerCode.Size = new System.Drawing.Size(130, 20);
            this.txtOwnerCode.TabIndex = 36;
            this.txtOwnerCode.TabStop = false;
            // 
            // txtCrtCode
            // 
            this.txtCrtCode.Location = new System.Drawing.Point(398, 184);
            this.txtCrtCode.MaxLength = 10;
            this.txtCrtCode.Name = "txtCrtCode";
            this.txtCrtCode.ReadOnly = true;
            this.txtCrtCode.Size = new System.Drawing.Size(130, 20);
            this.txtCrtCode.TabIndex = 34;
            this.txtCrtCode.TabStop = false;
            // 
            // txtStartQty3
            // 
            this.txtStartQty3.Location = new System.Drawing.Point(398, 160);
            this.txtStartQty3.MaxLength = 10;
            this.txtStartQty3.Name = "txtStartQty3";
            this.txtStartQty3.ReadOnly = true;
            this.txtStartQty3.Size = new System.Drawing.Size(130, 20);
            this.txtStartQty3.TabIndex = 20;
            this.txtStartQty3.TabStop = false;
            // 
            // txtOperQty3
            // 
            this.txtOperQty3.Location = new System.Drawing.Point(398, 136);
            this.txtOperQty3.MaxLength = 10;
            this.txtOperQty3.Name = "txtOperQty3";
            this.txtOperQty3.ReadOnly = true;
            this.txtOperQty3.Size = new System.Drawing.Size(130, 20);
            this.txtOperQty3.TabIndex = 16;
            this.txtOperQty3.TabStop = false;
            // 
            // txtCrtQty3
            // 
            this.txtCrtQty3.Location = new System.Drawing.Point(398, 112);
            this.txtCrtQty3.MaxLength = 10;
            this.txtCrtQty3.Name = "txtCrtQty3";
            this.txtCrtQty3.ReadOnly = true;
            this.txtCrtQty3.Size = new System.Drawing.Size(130, 20);
            this.txtCrtQty3.TabIndex = 12;
            this.txtCrtQty3.TabStop = false;
            // 
            // txtStartQty2
            // 
            this.txtStartQty2.Location = new System.Drawing.Point(264, 160);
            this.txtStartQty2.MaxLength = 10;
            this.txtStartQty2.Name = "txtStartQty2";
            this.txtStartQty2.ReadOnly = true;
            this.txtStartQty2.Size = new System.Drawing.Size(132, 20);
            this.txtStartQty2.TabIndex = 19;
            this.txtStartQty2.TabStop = false;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(398, 88);
            this.txtQty3.MaxLength = 10;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(130, 20);
            this.txtQty3.TabIndex = 8;
            this.txtQty3.TabStop = false;
            // 
            // txtOperQty2
            // 
            this.txtOperQty2.Location = new System.Drawing.Point(264, 136);
            this.txtOperQty2.MaxLength = 10;
            this.txtOperQty2.Name = "txtOperQty2";
            this.txtOperQty2.ReadOnly = true;
            this.txtOperQty2.Size = new System.Drawing.Size(132, 20);
            this.txtOperQty2.TabIndex = 15;
            this.txtOperQty2.TabStop = false;
            // 
            // txtCrtQty2
            // 
            this.txtCrtQty2.Location = new System.Drawing.Point(264, 112);
            this.txtCrtQty2.MaxLength = 10;
            this.txtCrtQty2.Name = "txtCrtQty2";
            this.txtCrtQty2.ReadOnly = true;
            this.txtCrtQty2.Size = new System.Drawing.Size(132, 20);
            this.txtCrtQty2.TabIndex = 11;
            this.txtCrtQty2.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(264, 88);
            this.txtQty2.MaxLength = 10;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(132, 20);
            this.txtQty2.TabIndex = 7;
            this.txtQty2.TabStop = false;
            // 
            // txtOperDesc
            // 
            this.txtOperDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperDesc.Location = new System.Drawing.Point(294, 64);
            this.txtOperDesc.MaxLength = 200;
            this.txtOperDesc.Name = "txtOperDesc";
            this.txtOperDesc.ReadOnly = true;
            this.txtOperDesc.Size = new System.Drawing.Size(420, 20);
            this.txtOperDesc.TabIndex = 4;
            this.txtOperDesc.TabStop = false;
            // 
            // txtDelReason
            // 
            this.txtDelReason.Location = new System.Drawing.Point(130, 304);
            this.txtDelReason.MaxLength = 12;
            this.txtDelReason.Name = "txtDelReason";
            this.txtDelReason.ReadOnly = true;
            this.txtDelReason.Size = new System.Drawing.Size(132, 20);
            this.txtDelReason.TabIndex = 32;
            this.txtDelReason.TabStop = false;
            // 
            // txtSampleRes
            // 
            this.txtSampleRes.Location = new System.Drawing.Point(130, 255);
            this.txtSampleRes.MaxLength = 10;
            this.txtSampleRes.Name = "txtSampleRes";
            this.txtSampleRes.ReadOnly = true;
            this.txtSampleRes.Size = new System.Drawing.Size(132, 20);
            this.txtSampleRes.TabIndex = 28;
            this.txtSampleRes.TabStop = false;
            // 
            // txtSplitFromLot
            // 
            this.txtSplitFromLot.Location = new System.Drawing.Point(130, 280);
            this.txtSplitFromLot.MaxLength = 25;
            this.txtSplitFromLot.Name = "txtSplitFromLot";
            this.txtSplitFromLot.ReadOnly = true;
            this.txtSplitFromLot.Size = new System.Drawing.Size(132, 20);
            this.txtSplitFromLot.TabIndex = 30;
            this.txtSplitFromLot.TabStop = false;
            // 
            // txtLotStatus
            // 
            this.txtLotStatus.Location = new System.Drawing.Point(130, 208);
            this.txtLotStatus.MaxLength = 10;
            this.txtLotStatus.Name = "txtLotStatus";
            this.txtLotStatus.ReadOnly = true;
            this.txtLotStatus.Size = new System.Drawing.Size(132, 20);
            this.txtLotStatus.TabIndex = 24;
            this.txtLotStatus.TabStop = false;
            // 
            // txtStartQty1
            // 
            this.txtStartQty1.Location = new System.Drawing.Point(130, 160);
            this.txtStartQty1.MaxLength = 10;
            this.txtStartQty1.Name = "txtStartQty1";
            this.txtStartQty1.ReadOnly = true;
            this.txtStartQty1.Size = new System.Drawing.Size(132, 20);
            this.txtStartQty1.TabIndex = 18;
            this.txtStartQty1.TabStop = false;
            // 
            // txtLotType
            // 
            this.txtLotType.Location = new System.Drawing.Point(130, 184);
            this.txtLotType.MaxLength = 10;
            this.txtLotType.Name = "txtLotType";
            this.txtLotType.ReadOnly = true;
            this.txtLotType.Size = new System.Drawing.Size(132, 20);
            this.txtLotType.TabIndex = 22;
            this.txtLotType.TabStop = false;
            // 
            // txtOperQty1
            // 
            this.txtOperQty1.Location = new System.Drawing.Point(130, 136);
            this.txtOperQty1.MaxLength = 10;
            this.txtOperQty1.Name = "txtOperQty1";
            this.txtOperQty1.ReadOnly = true;
            this.txtOperQty1.Size = new System.Drawing.Size(132, 20);
            this.txtOperQty1.TabIndex = 14;
            this.txtOperQty1.TabStop = false;
            // 
            // txtCrtQty1
            // 
            this.txtCrtQty1.Location = new System.Drawing.Point(130, 112);
            this.txtCrtQty1.MaxLength = 10;
            this.txtCrtQty1.Name = "txtCrtQty1";
            this.txtCrtQty1.ReadOnly = true;
            this.txtCrtQty1.Size = new System.Drawing.Size(132, 20);
            this.txtCrtQty1.TabIndex = 10;
            this.txtCrtQty1.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(130, 88);
            this.txtQty1.MaxLength = 10;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(132, 20);
            this.txtQty1.TabIndex = 6;
            this.txtQty1.TabStop = false;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(130, 64);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(162, 20);
            this.txtOper.TabIndex = 3;
            this.txtOper.TabStop = false;
            // 
            // lblDelReason
            // 
            this.lblDelReason.AutoSize = true;
            this.lblDelReason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDelReason.Location = new System.Drawing.Point(15, 307);
            this.lblDelReason.Name = "lblDelReason";
            this.lblDelReason.Size = new System.Drawing.Size(96, 13);
            this.lblDelReason.TabIndex = 31;
            this.lblDelReason.Text = "Lot Delete Reason";
            // 
            // lblSplitFromLot
            // 
            this.lblSplitFromLot.AutoSize = true;
            this.lblSplitFromLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSplitFromLot.Location = new System.Drawing.Point(15, 283);
            this.lblSplitFromLot.Name = "lblSplitFromLot";
            this.lblSplitFromLot.Size = new System.Drawing.Size(78, 13);
            this.lblSplitFromLot.TabIndex = 29;
            this.lblSplitFromLot.Text = "From To Lot ID";
            // 
            // lblStartQty
            // 
            this.lblStartQty.AutoSize = true;
            this.lblStartQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartQty.Location = new System.Drawing.Point(15, 163);
            this.lblStartQty.Name = "lblStartQty";
            this.lblStartQty.Size = new System.Drawing.Size(79, 13);
            this.lblStartQty.TabIndex = 17;
            this.lblStartQty.Text = "Start Qty 1/2/3";
            // 
            // lblOperQty
            // 
            this.lblOperQty.AutoSize = true;
            this.lblOperQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperQty.Location = new System.Drawing.Point(15, 139);
            this.lblOperQty.Name = "lblOperQty";
            this.lblOperQty.Size = new System.Drawing.Size(92, 13);
            this.lblOperQty.TabIndex = 13;
            this.lblOperQty.Text = "Oper In Qty 1/2/3";
            // 
            // lblSampleRes
            // 
            this.lblSampleRes.AutoSize = true;
            this.lblSampleRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleRes.Location = new System.Drawing.Point(15, 258);
            this.lblSampleRes.Name = "lblSampleRes";
            this.lblSampleRes.Size = new System.Drawing.Size(75, 13);
            this.lblSampleRes.TabIndex = 27;
            this.lblSampleRes.Text = "Sample Result";
            // 
            // lblShipCode
            // 
            this.lblShipCode.AutoSize = true;
            this.lblShipCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShipCode.Location = new System.Drawing.Point(293, 258);
            this.lblShipCode.Name = "lblShipCode";
            this.lblShipCode.Size = new System.Drawing.Size(56, 13);
            this.lblShipCode.TabIndex = 39;
            this.lblShipCode.Text = "Ship Code";
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Location = new System.Drawing.Point(293, 235);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 37;
            this.lblHoldCode.Text = "Hold Code";
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Location = new System.Drawing.Point(293, 211);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(66, 13);
            this.lblOwnerCode.TabIndex = 35;
            this.lblOwnerCode.Text = "Owner Code";
            // 
            // lblCrtCode
            // 
            this.lblCrtCode.AutoSize = true;
            this.lblCrtCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCode.Location = new System.Drawing.Point(293, 187);
            this.lblCrtCode.Name = "lblCrtCode";
            this.lblCrtCode.Size = new System.Drawing.Size(66, 13);
            this.lblCrtCode.TabIndex = 33;
            this.lblCrtCode.Text = "Create Code";
            // 
            // lblLotStatus
            // 
            this.lblLotStatus.AutoSize = true;
            this.lblLotStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotStatus.Location = new System.Drawing.Point(15, 211);
            this.lblLotStatus.Name = "lblLotStatus";
            this.lblLotStatus.Size = new System.Drawing.Size(55, 13);
            this.lblLotStatus.TabIndex = 23;
            this.lblLotStatus.Text = "Lot Status";
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Location = new System.Drawing.Point(15, 187);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(49, 13);
            this.lblLotType.TabIndex = 21;
            this.lblLotType.Text = "Lot Type";
            // 
            // lblCreateQty
            // 
            this.lblCreateQty.AutoSize = true;
            this.lblCreateQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateQty.Location = new System.Drawing.Point(15, 115);
            this.lblCreateQty.Name = "lblCreateQty";
            this.lblCreateQty.Size = new System.Drawing.Size(88, 13);
            this.lblCreateQty.TabIndex = 9;
            this.lblCreateQty.Text = "Create Qty 1/2/3";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Location = new System.Drawing.Point(15, 91);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 13);
            this.lblQty.TabIndex = 5;
            this.lblQty.Text = "Qty 1/2/3";
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 67);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            // 
            // grpGen1Bottom
            // 
            this.grpGen1Bottom.Controls.Add(this.txtInvUnit);
            this.grpGen1Bottom.Controls.Add(this.txtOrderID);
            this.grpGen1Bottom.Controls.Add(this.txtBatchSeq);
            this.grpGen1Bottom.Controls.Add(this.txtBatchID);
            this.grpGen1Bottom.Controls.Add(this.lblOrderId);
            this.grpGen1Bottom.Controls.Add(this.lblBatchSeq);
            this.grpGen1Bottom.Controls.Add(this.lblBatchId);
            this.grpGen1Bottom.Controls.Add(this.lblInvUnit);
            this.grpGen1Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpGen1Bottom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen1Bottom.Location = new System.Drawing.Point(3, 337);
            this.grpGen1Bottom.Name = "grpGen1Bottom";
            this.grpGen1Bottom.Size = new System.Drawing.Size(722, 72);
            this.grpGen1Bottom.TabIndex = 1;
            this.grpGen1Bottom.TabStop = false;
            // 
            // txtInvUnit
            // 
            this.txtInvUnit.Location = new System.Drawing.Point(570, 16);
            this.txtInvUnit.MaxLength = 10;
            this.txtInvUnit.Name = "txtInvUnit";
            this.txtInvUnit.ReadOnly = true;
            this.txtInvUnit.Size = new System.Drawing.Size(132, 20);
            this.txtInvUnit.TabIndex = 7;
            this.txtInvUnit.TabStop = false;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(337, 16);
            this.txtOrderID.MaxLength = 25;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(132, 20);
            this.txtOrderID.TabIndex = 5;
            this.txtOrderID.TabStop = false;
            // 
            // txtBatchSeq
            // 
            this.txtBatchSeq.Location = new System.Drawing.Point(103, 40);
            this.txtBatchSeq.MaxLength = 25;
            this.txtBatchSeq.Name = "txtBatchSeq";
            this.txtBatchSeq.ReadOnly = true;
            this.txtBatchSeq.Size = new System.Drawing.Size(132, 20);
            this.txtBatchSeq.TabIndex = 3;
            this.txtBatchSeq.TabStop = false;
            // 
            // txtBatchID
            // 
            this.txtBatchID.Location = new System.Drawing.Point(103, 16);
            this.txtBatchID.MaxLength = 25;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.ReadOnly = true;
            this.txtBatchID.Size = new System.Drawing.Size(132, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.TabStop = false;
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderId.Location = new System.Drawing.Point(245, 19);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(47, 13);
            this.lblOrderId.TabIndex = 4;
            this.lblOrderId.Text = "Order ID";
            // 
            // lblBatchSeq
            // 
            this.lblBatchSeq.AutoSize = true;
            this.lblBatchSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchSeq.Location = new System.Drawing.Point(12, 43);
            this.lblBatchSeq.Name = "lblBatchSeq";
            this.lblBatchSeq.Size = new System.Drawing.Size(57, 13);
            this.lblBatchSeq.TabIndex = 2;
            this.lblBatchSeq.Text = "Batch Seq";
            // 
            // lblBatchId
            // 
            this.lblBatchId.AutoSize = true;
            this.lblBatchId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchId.Location = new System.Drawing.Point(12, 19);
            this.lblBatchId.Name = "lblBatchId";
            this.lblBatchId.Size = new System.Drawing.Size(49, 13);
            this.lblBatchId.TabIndex = 0;
            this.lblBatchId.Text = "Batch ID";
            // 
            // lblInvUnit
            // 
            this.lblInvUnit.AutoSize = true;
            this.lblInvUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvUnit.Location = new System.Drawing.Point(480, 19);
            this.lblInvUnit.Name = "lblInvUnit";
            this.lblInvUnit.Size = new System.Drawing.Size(73, 13);
            this.lblInvUnit.TabIndex = 6;
            this.lblInvUnit.Text = "Inventory Unit";
            // 
            // tbpGeneral2
            // 
            this.tbpGeneral2.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral2.Controls.Add(this.grpGen2Right);
            this.tbpGeneral2.Controls.Add(this.pnlSeperator);
            this.tbpGeneral2.Controls.Add(this.grpGen2Left);
            this.tbpGeneral2.Controls.Add(this.pnlResource);
            this.tbpGeneral2.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral2.Name = "tbpGeneral2";
            this.tbpGeneral2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral2.Size = new System.Drawing.Size(728, 412);
            this.tbpGeneral2.TabIndex = 1;
            this.tbpGeneral2.Text = "General 2";
            // 
            // grpGen2Right
            // 
            this.grpGen2Right.Controls.Add(this.chkLocalRework);
            this.grpGen2Right.Controls.Add(this.txtReturnOption);
            this.grpGen2Right.Controls.Add(this.lblReturnOption);
            this.grpGen2Right.Controls.Add(this.txtReworkStopOper);
            this.grpGen2Right.Controls.Add(this.lblReworkStopOper);
            this.grpGen2Right.Controls.Add(this.txtReworkDepth);
            this.grpGen2Right.Controls.Add(this.udcNstdReturnFlow);
            this.grpGen2Right.Controls.Add(this.udcReworkEndFlow);
            this.grpGen2Right.Controls.Add(this.udcReworkReturnFlow);
            this.grpGen2Right.Controls.Add(this.txtRepairRetOper);
            this.grpGen2Right.Controls.Add(this.lblRepairRetOper);
            this.grpGen2Right.Controls.Add(this.txtNstdReturnOper);
            this.grpGen2Right.Controls.Add(this.txtReworkEndOper);
            this.grpGen2Right.Controls.Add(this.txtReworkReturnOper);
            this.grpGen2Right.Controls.Add(this.txtReworkCnt);
            this.grpGen2Right.Controls.Add(this.txtReworkCode);
            this.grpGen2Right.Controls.Add(this.lblNstdReturnOper);
            this.grpGen2Right.Controls.Add(this.lblReworkEndOper);
            this.grpGen2Right.Controls.Add(this.lblReworkReturnOper);
            this.grpGen2Right.Controls.Add(this.lblReworkCnt);
            this.grpGen2Right.Controls.Add(this.lblReworkCode);
            this.grpGen2Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGen2Right.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen2Right.Location = new System.Drawing.Point(366, 120);
            this.grpGen2Right.Name = "grpGen2Right";
            this.grpGen2Right.Size = new System.Drawing.Size(359, 289);
            this.grpGen2Right.TabIndex = 2;
            this.grpGen2Right.TabStop = false;
            this.grpGen2Right.Text = "Rework Information";
            // 
            // chkLocalRework
            // 
            this.chkLocalRework.AutoSize = true;
            this.chkLocalRework.Enabled = false;
            this.chkLocalRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLocalRework.Location = new System.Drawing.Point(158, 199);
            this.chkLocalRework.Name = "chkLocalRework";
            this.chkLocalRework.Size = new System.Drawing.Size(121, 18);
            this.chkLocalRework.TabIndex = 15;
            this.chkLocalRework.TabStop = false;
            this.chkLocalRework.Text = "Local Rework Flag";
            // 
            // txtReturnOption
            // 
            this.txtReturnOption.Location = new System.Drawing.Point(158, 174);
            this.txtReturnOption.MaxLength = 50;
            this.txtReturnOption.Name = "txtReturnOption";
            this.txtReturnOption.ReadOnly = true;
            this.txtReturnOption.Size = new System.Drawing.Size(195, 20);
            this.txtReturnOption.TabIndex = 14;
            this.txtReturnOption.TabStop = false;
            // 
            // lblReturnOption
            // 
            this.lblReturnOption.AutoSize = true;
            this.lblReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReturnOption.Location = new System.Drawing.Point(20, 177);
            this.lblReturnOption.Name = "lblReturnOption";
            this.lblReturnOption.Size = new System.Drawing.Size(73, 13);
            this.lblReturnOption.TabIndex = 13;
            this.lblReturnOption.Text = "Return Option";
            // 
            // txtReworkStopOper
            // 
            this.txtReworkStopOper.Location = new System.Drawing.Point(158, 59);
            this.txtReworkStopOper.MaxLength = 10;
            this.txtReworkStopOper.Name = "txtReworkStopOper";
            this.txtReworkStopOper.ReadOnly = true;
            this.txtReworkStopOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkStopOper.TabIndex = 6;
            this.txtReworkStopOper.TabStop = false;
            // 
            // lblReworkStopOper
            // 
            this.lblReworkStopOper.AutoSize = true;
            this.lblReworkStopOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkStopOper.Location = new System.Drawing.Point(20, 62);
            this.lblReworkStopOper.Name = "lblReworkStopOper";
            this.lblReworkStopOper.Size = new System.Drawing.Size(95, 13);
            this.lblReworkStopOper.TabIndex = 5;
            this.lblReworkStopOper.Text = "Rework Stop Oper";
            // 
            // txtReworkDepth
            // 
            this.txtReworkDepth.Location = new System.Drawing.Point(240, 36);
            this.txtReworkDepth.MaxLength = 25;
            this.txtReworkDepth.Name = "txtReworkDepth";
            this.txtReworkDepth.ReadOnly = true;
            this.txtReworkDepth.Size = new System.Drawing.Size(80, 20);
            this.txtReworkDepth.TabIndex = 4;
            this.txtReworkDepth.TabStop = false;
            // 
            // udcNstdReturnFlow
            // 
            this.udcNstdReturnFlow.AddEmptyRowToLast = false;
            this.udcNstdReturnFlow.AddEmptyRowToTop = false;
            this.udcNstdReturnFlow.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.udcNstdReturnFlow.DisplaySubItemIndex = 0;
            this.udcNstdReturnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcNstdReturnFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcNstdReturnFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcNstdReturnFlow.LabelText = "NSTD Return Flow";
            this.udcNstdReturnFlow.ListCond_ExtFactory = "";
            this.udcNstdReturnFlow.ListCond_StepMaterial = '1';
            this.udcNstdReturnFlow.ListCond_StepVersion = '1';
            this.udcNstdReturnFlow.Location = new System.Drawing.Point(20, 219);
            this.udcNstdReturnFlow.MaterialEnabled = true;
            this.udcNstdReturnFlow.MaterialReadOnly = true;
            this.udcNstdReturnFlow.Name = "udcNstdReturnFlow";
            this.udcNstdReturnFlow.SearchSubItemIndex = 0;
            this.udcNstdReturnFlow.SelectedDescIndex = -1;
            this.udcNstdReturnFlow.SelectedSubItemIndex = 0;
            this.udcNstdReturnFlow.Size = new System.Drawing.Size(300, 20);
            this.udcNstdReturnFlow.TabIndex = 16;
            this.udcNstdReturnFlow.TabStop = false;
            this.udcNstdReturnFlow.VersionEnabled = true;
            this.udcNstdReturnFlow.VersionReadOnly = true;
            this.udcNstdReturnFlow.VisibleColumnHeader = false;
            this.udcNstdReturnFlow.VisibleDescription = false;
            this.udcNstdReturnFlow.VisibleMaterialButton = false;
            this.udcNstdReturnFlow.VisibleVersionButton = false;
            this.udcNstdReturnFlow.WidthButton = 20;
            this.udcNstdReturnFlow.WidthLabel = 138;
            this.udcNstdReturnFlow.WidthMaterialAndVersion = 162;
            this.udcNstdReturnFlow.WidthVersion = 50;
            // 
            // udcReworkEndFlow
            // 
            this.udcReworkEndFlow.AddEmptyRowToLast = false;
            this.udcReworkEndFlow.AddEmptyRowToTop = false;
            this.udcReworkEndFlow.AutoSize = true;
            this.udcReworkEndFlow.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.udcReworkEndFlow.DisplaySubItemIndex = 0;
            this.udcReworkEndFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcReworkEndFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcReworkEndFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcReworkEndFlow.LabelText = "Rework End Flow";
            this.udcReworkEndFlow.ListCond_ExtFactory = "";
            this.udcReworkEndFlow.ListCond_StepMaterial = '1';
            this.udcReworkEndFlow.ListCond_StepVersion = '1';
            this.udcReworkEndFlow.Location = new System.Drawing.Point(20, 128);
            this.udcReworkEndFlow.MaterialEnabled = true;
            this.udcReworkEndFlow.MaterialReadOnly = true;
            this.udcReworkEndFlow.Name = "udcReworkEndFlow";
            this.udcReworkEndFlow.SearchSubItemIndex = 0;
            this.udcReworkEndFlow.SelectedDescIndex = -1;
            this.udcReworkEndFlow.SelectedSubItemIndex = 0;
            this.udcReworkEndFlow.Size = new System.Drawing.Size(300, 20);
            this.udcReworkEndFlow.TabIndex = 10;
            this.udcReworkEndFlow.TabStop = false;
            this.udcReworkEndFlow.VersionEnabled = true;
            this.udcReworkEndFlow.VersionReadOnly = true;
            this.udcReworkEndFlow.VisibleColumnHeader = false;
            this.udcReworkEndFlow.VisibleDescription = false;
            this.udcReworkEndFlow.VisibleMaterialButton = false;
            this.udcReworkEndFlow.VisibleVersionButton = false;
            this.udcReworkEndFlow.WidthButton = 20;
            this.udcReworkEndFlow.WidthLabel = 138;
            this.udcReworkEndFlow.WidthMaterialAndVersion = 162;
            this.udcReworkEndFlow.WidthVersion = 50;
            // 
            // udcReworkReturnFlow
            // 
            this.udcReworkReturnFlow.AddEmptyRowToLast = false;
            this.udcReworkReturnFlow.AddEmptyRowToTop = false;
            this.udcReworkReturnFlow.AutoSize = true;
            this.udcReworkReturnFlow.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.udcReworkReturnFlow.DisplaySubItemIndex = 0;
            this.udcReworkReturnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcReworkReturnFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcReworkReturnFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcReworkReturnFlow.LabelText = "Rework Return Flow";
            this.udcReworkReturnFlow.ListCond_ExtFactory = "";
            this.udcReworkReturnFlow.ListCond_StepMaterial = '1';
            this.udcReworkReturnFlow.ListCond_StepVersion = '1';
            this.udcReworkReturnFlow.Location = new System.Drawing.Point(20, 82);
            this.udcReworkReturnFlow.MaterialEnabled = true;
            this.udcReworkReturnFlow.MaterialReadOnly = true;
            this.udcReworkReturnFlow.Name = "udcReworkReturnFlow";
            this.udcReworkReturnFlow.SearchSubItemIndex = 0;
            this.udcReworkReturnFlow.SelectedDescIndex = -1;
            this.udcReworkReturnFlow.SelectedSubItemIndex = 0;
            this.udcReworkReturnFlow.Size = new System.Drawing.Size(300, 20);
            this.udcReworkReturnFlow.TabIndex = 7;
            this.udcReworkReturnFlow.TabStop = false;
            this.udcReworkReturnFlow.VersionEnabled = true;
            this.udcReworkReturnFlow.VersionReadOnly = true;
            this.udcReworkReturnFlow.VisibleColumnHeader = false;
            this.udcReworkReturnFlow.VisibleDescription = false;
            this.udcReworkReturnFlow.VisibleMaterialButton = false;
            this.udcReworkReturnFlow.VisibleVersionButton = false;
            this.udcReworkReturnFlow.WidthButton = 20;
            this.udcReworkReturnFlow.WidthLabel = 138;
            this.udcReworkReturnFlow.WidthMaterialAndVersion = 162;
            this.udcReworkReturnFlow.WidthVersion = 50;
            // 
            // txtRepairRetOper
            // 
            this.txtRepairRetOper.Location = new System.Drawing.Point(158, 265);
            this.txtRepairRetOper.MaxLength = 20;
            this.txtRepairRetOper.Name = "txtRepairRetOper";
            this.txtRepairRetOper.ReadOnly = true;
            this.txtRepairRetOper.Size = new System.Drawing.Size(162, 20);
            this.txtRepairRetOper.TabIndex = 20;
            this.txtRepairRetOper.TabStop = false;
            // 
            // lblRepairRetOper
            // 
            this.lblRepairRetOper.AutoSize = true;
            this.lblRepairRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRepairRetOper.Location = new System.Drawing.Point(20, 268);
            this.lblRepairRetOper.Name = "lblRepairRetOper";
            this.lblRepairRetOper.Size = new System.Drawing.Size(99, 13);
            this.lblRepairRetOper.TabIndex = 19;
            this.lblRepairRetOper.Text = "Repair Return Oper";
            // 
            // txtNstdReturnOper
            // 
            this.txtNstdReturnOper.Location = new System.Drawing.Point(158, 242);
            this.txtNstdReturnOper.MaxLength = 10;
            this.txtNstdReturnOper.Name = "txtNstdReturnOper";
            this.txtNstdReturnOper.ReadOnly = true;
            this.txtNstdReturnOper.Size = new System.Drawing.Size(162, 20);
            this.txtNstdReturnOper.TabIndex = 18;
            this.txtNstdReturnOper.TabStop = false;
            // 
            // txtReworkEndOper
            // 
            this.txtReworkEndOper.Location = new System.Drawing.Point(158, 151);
            this.txtReworkEndOper.MaxLength = 10;
            this.txtReworkEndOper.Name = "txtReworkEndOper";
            this.txtReworkEndOper.ReadOnly = true;
            this.txtReworkEndOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkEndOper.TabIndex = 12;
            this.txtReworkEndOper.TabStop = false;
            // 
            // txtReworkReturnOper
            // 
            this.txtReworkReturnOper.Location = new System.Drawing.Point(158, 105);
            this.txtReworkReturnOper.MaxLength = 10;
            this.txtReworkReturnOper.Name = "txtReworkReturnOper";
            this.txtReworkReturnOper.ReadOnly = true;
            this.txtReworkReturnOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkReturnOper.TabIndex = 9;
            this.txtReworkReturnOper.TabStop = false;
            // 
            // txtReworkCnt
            // 
            this.txtReworkCnt.Location = new System.Drawing.Point(158, 36);
            this.txtReworkCnt.MaxLength = 25;
            this.txtReworkCnt.Name = "txtReworkCnt";
            this.txtReworkCnt.ReadOnly = true;
            this.txtReworkCnt.Size = new System.Drawing.Size(80, 20);
            this.txtReworkCnt.TabIndex = 3;
            this.txtReworkCnt.TabStop = false;
            // 
            // txtReworkCode
            // 
            this.txtReworkCode.Location = new System.Drawing.Point(158, 13);
            this.txtReworkCode.MaxLength = 10;
            this.txtReworkCode.Name = "txtReworkCode";
            this.txtReworkCode.ReadOnly = true;
            this.txtReworkCode.Size = new System.Drawing.Size(162, 20);
            this.txtReworkCode.TabIndex = 1;
            this.txtReworkCode.TabStop = false;
            // 
            // lblNstdReturnOper
            // 
            this.lblNstdReturnOper.AutoSize = true;
            this.lblNstdReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdReturnOper.Location = new System.Drawing.Point(20, 245);
            this.lblNstdReturnOper.Name = "lblNstdReturnOper";
            this.lblNstdReturnOper.Size = new System.Drawing.Size(98, 13);
            this.lblNstdReturnOper.TabIndex = 17;
            this.lblNstdReturnOper.Text = "NSTD Return Oper";
            // 
            // lblReworkEndOper
            // 
            this.lblReworkEndOper.AutoSize = true;
            this.lblReworkEndOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkEndOper.Location = new System.Drawing.Point(20, 154);
            this.lblReworkEndOper.Name = "lblReworkEndOper";
            this.lblReworkEndOper.Size = new System.Drawing.Size(92, 13);
            this.lblReworkEndOper.TabIndex = 11;
            this.lblReworkEndOper.Text = "Rework End Oper";
            // 
            // lblReworkReturnOper
            // 
            this.lblReworkReturnOper.AutoSize = true;
            this.lblReworkReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkReturnOper.Location = new System.Drawing.Point(20, 108);
            this.lblReworkReturnOper.Name = "lblReworkReturnOper";
            this.lblReworkReturnOper.Size = new System.Drawing.Size(105, 13);
            this.lblReworkReturnOper.TabIndex = 8;
            this.lblReworkReturnOper.Text = "Rework Return Oper";
            // 
            // lblReworkCnt
            // 
            this.lblReworkCnt.AutoSize = true;
            this.lblReworkCnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCnt.Location = new System.Drawing.Point(20, 39);
            this.lblReworkCnt.Name = "lblReworkCnt";
            this.lblReworkCnt.Size = new System.Drawing.Size(112, 13);
            this.lblReworkCnt.TabIndex = 2;
            this.lblReworkCnt.Text = "Rework Count/ Depth";
            // 
            // lblReworkCode
            // 
            this.lblReworkCode.AutoSize = true;
            this.lblReworkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCode.Location = new System.Drawing.Point(20, 16);
            this.lblReworkCode.Name = "lblReworkCode";
            this.lblReworkCode.Size = new System.Drawing.Size(72, 13);
            this.lblReworkCode.TabIndex = 0;
            this.lblReworkCode.Text = "Rework Code";
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeperator.Location = new System.Drawing.Point(363, 120);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(3, 289);
            this.pnlSeperator.TabIndex = 1;
            // 
            // grpGen2Left
            // 
            this.grpGen2Left.Controls.Add(this.txtNstdTime);
            this.grpGen2Left.Controls.Add(this.lblNstdTime);
            this.grpGen2Left.Controls.Add(this.txtReworkTime);
            this.grpGen2Left.Controls.Add(this.lblRwkTime);
            this.grpGen2Left.Controls.Add(this.txtLotDeleteTime);
            this.grpGen2Left.Controls.Add(this.txtOperInTime);
            this.grpGen2Left.Controls.Add(this.txtFlowInTime);
            this.grpGen2Left.Controls.Add(this.txtFactoryInTime);
            this.grpGen2Left.Controls.Add(this.txtCreateTime);
            this.grpGen2Left.Controls.Add(this.txtSchDueTime);
            this.grpGen2Left.Controls.Add(this.txtOrgDueTime);
            this.grpGen2Left.Controls.Add(this.txtShipTime);
            this.grpGen2Left.Controls.Add(this.txtEndTime);
            this.grpGen2Left.Controls.Add(this.txtStartTime);
            this.grpGen2Left.Controls.Add(this.lblLotDeleteTime);
            this.grpGen2Left.Controls.Add(this.lblOperInTime);
            this.grpGen2Left.Controls.Add(this.lblFlowInTime);
            this.grpGen2Left.Controls.Add(this.lblFacInTime);
            this.grpGen2Left.Controls.Add(this.lblCreateTime);
            this.grpGen2Left.Controls.Add(this.lblSchDueTime);
            this.grpGen2Left.Controls.Add(this.lblOriDueTime);
            this.grpGen2Left.Controls.Add(this.lblShipTime);
            this.grpGen2Left.Controls.Add(this.lblEndTime);
            this.grpGen2Left.Controls.Add(this.lblStartTime);
            this.grpGen2Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpGen2Left.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen2Left.Location = new System.Drawing.Point(3, 120);
            this.grpGen2Left.Name = "grpGen2Left";
            this.grpGen2Left.Size = new System.Drawing.Size(360, 289);
            this.grpGen2Left.TabIndex = 1;
            this.grpGen2Left.TabStop = false;
            this.grpGen2Left.Text = "Time Information";
            // 
            // txtNstdTime
            // 
            this.txtNstdTime.Location = new System.Drawing.Point(154, 266);
            this.txtNstdTime.MaxLength = 20;
            this.txtNstdTime.Name = "txtNstdTime";
            this.txtNstdTime.ReadOnly = true;
            this.txtNstdTime.Size = new System.Drawing.Size(162, 20);
            this.txtNstdTime.TabIndex = 23;
            this.txtNstdTime.TabStop = false;
            // 
            // lblNstdTime
            // 
            this.lblNstdTime.AutoSize = true;
            this.lblNstdTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdTime.Location = new System.Drawing.Point(15, 269);
            this.lblNstdTime.Name = "lblNstdTime";
            this.lblNstdTime.Size = new System.Drawing.Size(63, 13);
            this.lblNstdTime.TabIndex = 22;
            this.lblNstdTime.Text = "NSTD Time";
            // 
            // txtReworkTime
            // 
            this.txtReworkTime.Location = new System.Drawing.Point(154, 243);
            this.txtReworkTime.MaxLength = 10;
            this.txtReworkTime.Name = "txtReworkTime";
            this.txtReworkTime.ReadOnly = true;
            this.txtReworkTime.Size = new System.Drawing.Size(162, 20);
            this.txtReworkTime.TabIndex = 21;
            this.txtReworkTime.TabStop = false;
            // 
            // lblRwkTime
            // 
            this.lblRwkTime.AutoSize = true;
            this.lblRwkTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkTime.Location = new System.Drawing.Point(15, 246);
            this.lblRwkTime.Name = "lblRwkTime";
            this.lblRwkTime.Size = new System.Drawing.Size(70, 13);
            this.lblRwkTime.TabIndex = 20;
            this.lblRwkTime.Text = "Rework Time";
            // 
            // txtLotDeleteTime
            // 
            this.txtLotDeleteTime.Location = new System.Drawing.Point(154, 220);
            this.txtLotDeleteTime.MaxLength = 25;
            this.txtLotDeleteTime.Name = "txtLotDeleteTime";
            this.txtLotDeleteTime.ReadOnly = true;
            this.txtLotDeleteTime.Size = new System.Drawing.Size(162, 20);
            this.txtLotDeleteTime.TabIndex = 19;
            this.txtLotDeleteTime.TabStop = false;
            // 
            // txtOperInTime
            // 
            this.txtOperInTime.Location = new System.Drawing.Point(154, 197);
            this.txtOperInTime.MaxLength = 25;
            this.txtOperInTime.Name = "txtOperInTime";
            this.txtOperInTime.ReadOnly = true;
            this.txtOperInTime.Size = new System.Drawing.Size(162, 20);
            this.txtOperInTime.TabIndex = 17;
            this.txtOperInTime.TabStop = false;
            // 
            // txtFlowInTime
            // 
            this.txtFlowInTime.Location = new System.Drawing.Point(154, 174);
            this.txtFlowInTime.MaxLength = 25;
            this.txtFlowInTime.Name = "txtFlowInTime";
            this.txtFlowInTime.ReadOnly = true;
            this.txtFlowInTime.Size = new System.Drawing.Size(162, 20);
            this.txtFlowInTime.TabIndex = 15;
            this.txtFlowInTime.TabStop = false;
            // 
            // txtFactoryInTime
            // 
            this.txtFactoryInTime.Location = new System.Drawing.Point(154, 151);
            this.txtFactoryInTime.MaxLength = 25;
            this.txtFactoryInTime.Name = "txtFactoryInTime";
            this.txtFactoryInTime.ReadOnly = true;
            this.txtFactoryInTime.Size = new System.Drawing.Size(162, 20);
            this.txtFactoryInTime.TabIndex = 13;
            this.txtFactoryInTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(154, 128);
            this.txtCreateTime.MaxLength = 25;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(162, 20);
            this.txtCreateTime.TabIndex = 11;
            this.txtCreateTime.TabStop = false;
            // 
            // txtSchDueTime
            // 
            this.txtSchDueTime.Location = new System.Drawing.Point(154, 105);
            this.txtSchDueTime.MaxLength = 25;
            this.txtSchDueTime.Name = "txtSchDueTime";
            this.txtSchDueTime.ReadOnly = true;
            this.txtSchDueTime.Size = new System.Drawing.Size(162, 20);
            this.txtSchDueTime.TabIndex = 9;
            this.txtSchDueTime.TabStop = false;
            // 
            // txtOrgDueTime
            // 
            this.txtOrgDueTime.Location = new System.Drawing.Point(154, 82);
            this.txtOrgDueTime.MaxLength = 25;
            this.txtOrgDueTime.Name = "txtOrgDueTime";
            this.txtOrgDueTime.ReadOnly = true;
            this.txtOrgDueTime.Size = new System.Drawing.Size(162, 20);
            this.txtOrgDueTime.TabIndex = 7;
            this.txtOrgDueTime.TabStop = false;
            // 
            // txtShipTime
            // 
            this.txtShipTime.Location = new System.Drawing.Point(154, 59);
            this.txtShipTime.MaxLength = 25;
            this.txtShipTime.Name = "txtShipTime";
            this.txtShipTime.ReadOnly = true;
            this.txtShipTime.Size = new System.Drawing.Size(162, 20);
            this.txtShipTime.TabIndex = 5;
            this.txtShipTime.TabStop = false;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(154, 36);
            this.txtEndTime.MaxLength = 25;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(162, 20);
            this.txtEndTime.TabIndex = 3;
            this.txtEndTime.TabStop = false;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(154, 13);
            this.txtStartTime.MaxLength = 25;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(162, 20);
            this.txtStartTime.TabIndex = 1;
            this.txtStartTime.TabStop = false;
            // 
            // lblLotDeleteTime
            // 
            this.lblLotDeleteTime.AutoSize = true;
            this.lblLotDeleteTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDeleteTime.Location = new System.Drawing.Point(15, 223);
            this.lblLotDeleteTime.Name = "lblLotDeleteTime";
            this.lblLotDeleteTime.Size = new System.Drawing.Size(82, 13);
            this.lblLotDeleteTime.TabIndex = 18;
            this.lblLotDeleteTime.Text = "Lot Delete Time";
            // 
            // lblOperInTime
            // 
            this.lblOperInTime.AutoSize = true;
            this.lblOperInTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperInTime.Location = new System.Drawing.Point(15, 200);
            this.lblOperInTime.Name = "lblOperInTime";
            this.lblOperInTime.Size = new System.Drawing.Size(68, 13);
            this.lblOperInTime.TabIndex = 16;
            this.lblOperInTime.Text = "Oper In Time";
            // 
            // lblFlowInTime
            // 
            this.lblFlowInTime.AutoSize = true;
            this.lblFlowInTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlowInTime.Location = new System.Drawing.Point(15, 177);
            this.lblFlowInTime.Name = "lblFlowInTime";
            this.lblFlowInTime.Size = new System.Drawing.Size(67, 13);
            this.lblFlowInTime.TabIndex = 14;
            this.lblFlowInTime.Text = "Flow In Time";
            // 
            // lblFacInTime
            // 
            this.lblFacInTime.AutoSize = true;
            this.lblFacInTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFacInTime.Location = new System.Drawing.Point(15, 154);
            this.lblFacInTime.Name = "lblFacInTime";
            this.lblFacInTime.Size = new System.Drawing.Size(80, 13);
            this.lblFacInTime.TabIndex = 12;
            this.lblFacInTime.Text = "Factory In Time";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.Location = new System.Drawing.Point(15, 131);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 10;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblSchDueTime
            // 
            this.lblSchDueTime.AutoSize = true;
            this.lblSchDueTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSchDueTime.Location = new System.Drawing.Point(15, 108);
            this.lblSchDueTime.Name = "lblSchDueTime";
            this.lblSchDueTime.Size = new System.Drawing.Size(107, 13);
            this.lblSchDueTime.TabIndex = 8;
            this.lblSchDueTime.Text = "Scheduled Due Time";
            // 
            // lblOriDueTime
            // 
            this.lblOriDueTime.AutoSize = true;
            this.lblOriDueTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOriDueTime.Location = new System.Drawing.Point(15, 85);
            this.lblOriDueTime.Name = "lblOriDueTime";
            this.lblOriDueTime.Size = new System.Drawing.Size(91, 13);
            this.lblOriDueTime.TabIndex = 6;
            this.lblOriDueTime.Text = "Original Due Time";
            // 
            // lblShipTime
            // 
            this.lblShipTime.AutoSize = true;
            this.lblShipTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShipTime.Location = new System.Drawing.Point(15, 62);
            this.lblShipTime.Name = "lblShipTime";
            this.lblShipTime.Size = new System.Drawing.Size(54, 13);
            this.lblShipTime.TabIndex = 4;
            this.lblShipTime.Text = "Ship Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndTime.Location = new System.Drawing.Point(15, 39);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 2;
            this.lblEndTime.Text = "End Time";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartTime.Location = new System.Drawing.Point(15, 16);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time";
            // 
            // pnlResource
            // 
            this.pnlResource.Controls.Add(this.grpGen2Top);
            this.pnlResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResource.Location = new System.Drawing.Point(3, 0);
            this.pnlResource.Name = "pnlResource";
            this.pnlResource.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlResource.Size = new System.Drawing.Size(722, 120);
            this.pnlResource.TabIndex = 0;
            // 
            // grpGen2Top
            // 
            this.grpGen2Top.Controls.Add(this.lisEndResList);
            this.grpGen2Top.Controls.Add(this.lisStartResList);
            this.grpGen2Top.Controls.Add(this.txtPort);
            this.grpGen2Top.Controls.Add(this.lblPort);
            this.grpGen2Top.Controls.Add(this.txtSubResID);
            this.grpGen2Top.Controls.Add(this.txtResvResID);
            this.grpGen2Top.Controls.Add(this.txtSaveResID2);
            this.grpGen2Top.Controls.Add(this.txtSaveResID1);
            this.grpGen2Top.Controls.Add(this.lblSubResID);
            this.grpGen2Top.Controls.Add(this.lblResvRes);
            this.grpGen2Top.Controls.Add(this.lblSaveResID1);
            this.grpGen2Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGen2Top.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen2Top.Location = new System.Drawing.Point(0, 5);
            this.grpGen2Top.Name = "grpGen2Top";
            this.grpGen2Top.Size = new System.Drawing.Size(722, 110);
            this.grpGen2Top.TabIndex = 0;
            this.grpGen2Top.TabStop = false;
            this.grpGen2Top.Text = "Resource";
            // 
            // lisEndResList
            // 
            this.lisEndResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEndResID,
            this.colEndQty});
            this.lisEndResList.EnableSort = true;
            this.lisEndResList.EnableSortIcon = true;
            this.lisEndResList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEndResList.FullRowSelect = true;
            this.lisEndResList.Location = new System.Drawing.Point(188, 13);
            this.lisEndResList.Name = "lisEndResList";
            this.lisEndResList.Size = new System.Drawing.Size(175, 94);
            this.lisEndResList.TabIndex = 1;
            this.lisEndResList.UseCompatibleStateImageBehavior = false;
            this.lisEndResList.View = System.Windows.Forms.View.Details;
            // 
            // colEndResID
            // 
            this.colEndResID.Text = "End Resource";
            this.colEndResID.Width = 93;
            // 
            // colEndQty
            // 
            this.colEndQty.Text = "Qty";
            // 
            // lisStartResList
            // 
            this.lisStartResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStartResID,
            this.colStartQty});
            this.lisStartResList.EnableSort = true;
            this.lisStartResList.EnableSortIcon = true;
            this.lisStartResList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisStartResList.FullRowSelect = true;
            this.lisStartResList.Location = new System.Drawing.Point(11, 13);
            this.lisStartResList.Name = "lisStartResList";
            this.lisStartResList.Size = new System.Drawing.Size(175, 94);
            this.lisStartResList.TabIndex = 0;
            this.lisStartResList.UseCompatibleStateImageBehavior = false;
            this.lisStartResList.View = System.Windows.Forms.View.Details;
            // 
            // colStartResID
            // 
            this.colStartResID.Text = "Start Resource";
            this.colStartResID.Width = 93;
            // 
            // colStartQty
            // 
            this.colStartQty.Text = "Qty";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(517, 61);
            this.txtPort.MaxLength = 20;
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(166, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.TabStop = false;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Location = new System.Drawing.Point(380, 64);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(40, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port ID";
            // 
            // txtSubResID
            // 
            this.txtSubResID.Location = new System.Drawing.Point(517, 37);
            this.txtSubResID.MaxLength = 20;
            this.txtSubResID.Name = "txtSubResID";
            this.txtSubResID.ReadOnly = true;
            this.txtSubResID.Size = new System.Drawing.Size(166, 20);
            this.txtSubResID.TabIndex = 5;
            this.txtSubResID.TabStop = false;
            // 
            // txtResvResID
            // 
            this.txtResvResID.Location = new System.Drawing.Point(517, 13);
            this.txtResvResID.MaxLength = 20;
            this.txtResvResID.Name = "txtResvResID";
            this.txtResvResID.ReadOnly = true;
            this.txtResvResID.Size = new System.Drawing.Size(166, 20);
            this.txtResvResID.TabIndex = 3;
            this.txtResvResID.TabStop = false;
            // 
            // txtSaveResID2
            // 
            this.txtSaveResID2.Location = new System.Drawing.Point(618, 85);
            this.txtSaveResID2.MaxLength = 20;
            this.txtSaveResID2.Name = "txtSaveResID2";
            this.txtSaveResID2.ReadOnly = true;
            this.txtSaveResID2.Size = new System.Drawing.Size(98, 20);
            this.txtSaveResID2.TabIndex = 10;
            this.txtSaveResID2.TabStop = false;
            // 
            // txtSaveResID1
            // 
            this.txtSaveResID1.Location = new System.Drawing.Point(517, 85);
            this.txtSaveResID1.MaxLength = 20;
            this.txtSaveResID1.Name = "txtSaveResID1";
            this.txtSaveResID1.ReadOnly = true;
            this.txtSaveResID1.Size = new System.Drawing.Size(99, 20);
            this.txtSaveResID1.TabIndex = 9;
            this.txtSaveResID1.TabStop = false;
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Location = new System.Drawing.Point(380, 40);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 4;
            this.lblSubResID.Text = "Sub Resource ID";
            // 
            // lblResvRes
            // 
            this.lblResvRes.AutoSize = true;
            this.lblResvRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvRes.Location = new System.Drawing.Point(380, 16);
            this.lblResvRes.Name = "lblResvRes";
            this.lblResvRes.Size = new System.Drawing.Size(110, 13);
            this.lblResvRes.TabIndex = 2;
            this.lblResvRes.Text = "Reserve Resource ID";
            // 
            // lblSaveResID1
            // 
            this.lblSaveResID1.AutoSize = true;
            this.lblSaveResID1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSaveResID1.Location = new System.Drawing.Point(380, 88);
            this.lblSaveResID1.Name = "lblSaveResID1";
            this.lblSaveResID1.Size = new System.Drawing.Size(118, 13);
            this.lblSaveResID1.TabIndex = 8;
            this.lblSaveResID1.Text = "Save Resource ID 1/ 2";
            // 
            // tbpGeneral3
            // 
            this.tbpGeneral3.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral3.Controls.Add(this.grpBOM);
            this.tbpGeneral3.Controls.Add(this.grpGen3Mid);
            this.tbpGeneral3.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral3.Name = "tbpGeneral3";
            this.tbpGeneral3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral3.Size = new System.Drawing.Size(728, 412);
            this.tbpGeneral3.TabIndex = 2;
            this.tbpGeneral3.Text = "General 3";
            // 
            // grpBOM
            // 
            this.grpBOM.Controls.Add(this.txtStrRetOper);
            this.grpBOM.Controls.Add(this.lblStrRetOper);
            this.grpBOM.Controls.Add(this.txtStrRetFlowSeq);
            this.grpBOM.Controls.Add(this.lblStrRetFlowSeq);
            this.grpBOM.Controls.Add(this.txtStrRetFlow);
            this.grpBOM.Controls.Add(this.lblStrRetFlow);
            this.grpBOM.Controls.Add(this.txtLotLocation3);
            this.grpBOM.Controls.Add(this.lblLotLocation3);
            this.grpBOM.Controls.Add(this.txtLotLocation2);
            this.grpBOM.Controls.Add(this.lblLotLocation2);
            this.grpBOM.Controls.Add(this.txtLotLocation1);
            this.grpBOM.Controls.Add(this.lblLotLocation1);
            this.grpBOM.Controls.Add(this.txtBomActHistSeq);
            this.grpBOM.Controls.Add(this.lblBomActHistSeq);
            this.grpBOM.Controls.Add(this.txtAddOrder3);
            this.grpBOM.Controls.Add(this.txtAddOrder2);
            this.grpBOM.Controls.Add(this.txtAddOrder1);
            this.grpBOM.Controls.Add(this.lblAddOrder3);
            this.grpBOM.Controls.Add(this.lblAddOrder2);
            this.grpBOM.Controls.Add(this.lblAddOrder1);
            this.grpBOM.Controls.Add(this.txtBOMHistSeq);
            this.grpBOM.Controls.Add(this.txtBOMSetVersion);
            this.grpBOM.Controls.Add(this.txtBOMSetID);
            this.grpBOM.Controls.Add(this.lblBOMHistSeq);
            this.grpBOM.Controls.Add(this.lblBOMSetVersion);
            this.grpBOM.Controls.Add(this.lblBOMSetID);
            this.grpBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBOM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOM.Location = new System.Drawing.Point(3, 170);
            this.grpBOM.Name = "grpBOM";
            this.grpBOM.Size = new System.Drawing.Size(722, 239);
            this.grpBOM.TabIndex = 1;
            this.grpBOM.TabStop = false;
            // 
            // txtStrRetOper
            // 
            this.txtStrRetOper.Location = new System.Drawing.Point(542, 64);
            this.txtStrRetOper.MaxLength = 10;
            this.txtStrRetOper.Name = "txtStrRetOper";
            this.txtStrRetOper.ReadOnly = true;
            this.txtStrRetOper.Size = new System.Drawing.Size(162, 20);
            this.txtStrRetOper.TabIndex = 19;
            this.txtStrRetOper.TabStop = false;
            // 
            // lblStrRetOper
            // 
            this.lblStrRetOper.AutoSize = true;
            this.lblStrRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetOper.Location = new System.Drawing.Point(392, 67);
            this.lblStrRetOper.Name = "lblStrRetOper";
            this.lblStrRetOper.Size = new System.Drawing.Size(93, 13);
            this.lblStrRetOper.TabIndex = 18;
            this.lblStrRetOper.Text = "Store Return Oper";
            // 
            // txtStrRetFlowSeq
            // 
            this.txtStrRetFlowSeq.Location = new System.Drawing.Point(542, 40);
            this.txtStrRetFlowSeq.MaxLength = 10;
            this.txtStrRetFlowSeq.Name = "txtStrRetFlowSeq";
            this.txtStrRetFlowSeq.ReadOnly = true;
            this.txtStrRetFlowSeq.Size = new System.Drawing.Size(162, 20);
            this.txtStrRetFlowSeq.TabIndex = 17;
            this.txtStrRetFlowSeq.TabStop = false;
            // 
            // lblStrRetFlowSeq
            // 
            this.lblStrRetFlowSeq.AutoSize = true;
            this.lblStrRetFlowSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetFlowSeq.Location = new System.Drawing.Point(392, 43);
            this.lblStrRetFlowSeq.Name = "lblStrRetFlowSeq";
            this.lblStrRetFlowSeq.Size = new System.Drawing.Size(114, 13);
            this.lblStrRetFlowSeq.TabIndex = 16;
            this.lblStrRetFlowSeq.Text = "Store Return Flow Seq";
            // 
            // txtStrRetFlow
            // 
            this.txtStrRetFlow.Location = new System.Drawing.Point(542, 16);
            this.txtStrRetFlow.MaxLength = 20;
            this.txtStrRetFlow.Name = "txtStrRetFlow";
            this.txtStrRetFlow.ReadOnly = true;
            this.txtStrRetFlow.Size = new System.Drawing.Size(162, 20);
            this.txtStrRetFlow.TabIndex = 15;
            this.txtStrRetFlow.TabStop = false;
            // 
            // lblStrRetFlow
            // 
            this.lblStrRetFlow.AutoSize = true;
            this.lblStrRetFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetFlow.Location = new System.Drawing.Point(392, 19);
            this.lblStrRetFlow.Name = "lblStrRetFlow";
            this.lblStrRetFlow.Size = new System.Drawing.Size(92, 13);
            this.lblStrRetFlow.TabIndex = 14;
            this.lblStrRetFlow.Text = "Store Return Flow";
            // 
            // txtLotLocation3
            // 
            this.txtLotLocation3.Location = new System.Drawing.Point(542, 171);
            this.txtLotLocation3.MaxLength = 20;
            this.txtLotLocation3.Name = "txtLotLocation3";
            this.txtLotLocation3.ReadOnly = true;
            this.txtLotLocation3.Size = new System.Drawing.Size(162, 20);
            this.txtLotLocation3.TabIndex = 25;
            this.txtLotLocation3.TabStop = false;
            // 
            // lblLotLocation3
            // 
            this.lblLotLocation3.AutoSize = true;
            this.lblLotLocation3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation3.Location = new System.Drawing.Point(392, 174);
            this.lblLotLocation3.Name = "lblLotLocation3";
            this.lblLotLocation3.Size = new System.Drawing.Size(75, 13);
            this.lblLotLocation3.TabIndex = 24;
            this.lblLotLocation3.Text = "Lot Location 3";
            // 
            // txtLotLocation2
            // 
            this.txtLotLocation2.Location = new System.Drawing.Point(542, 147);
            this.txtLotLocation2.MaxLength = 20;
            this.txtLotLocation2.Name = "txtLotLocation2";
            this.txtLotLocation2.ReadOnly = true;
            this.txtLotLocation2.Size = new System.Drawing.Size(162, 20);
            this.txtLotLocation2.TabIndex = 23;
            this.txtLotLocation2.TabStop = false;
            // 
            // lblLotLocation2
            // 
            this.lblLotLocation2.AutoSize = true;
            this.lblLotLocation2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation2.Location = new System.Drawing.Point(392, 150);
            this.lblLotLocation2.Name = "lblLotLocation2";
            this.lblLotLocation2.Size = new System.Drawing.Size(75, 13);
            this.lblLotLocation2.TabIndex = 22;
            this.lblLotLocation2.Text = "Lot Location 2";
            // 
            // txtLotLocation1
            // 
            this.txtLotLocation1.Location = new System.Drawing.Point(542, 123);
            this.txtLotLocation1.MaxLength = 20;
            this.txtLotLocation1.Name = "txtLotLocation1";
            this.txtLotLocation1.ReadOnly = true;
            this.txtLotLocation1.Size = new System.Drawing.Size(162, 20);
            this.txtLotLocation1.TabIndex = 21;
            this.txtLotLocation1.TabStop = false;
            // 
            // lblLotLocation1
            // 
            this.lblLotLocation1.AutoSize = true;
            this.lblLotLocation1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation1.Location = new System.Drawing.Point(392, 126);
            this.lblLotLocation1.Name = "lblLotLocation1";
            this.lblLotLocation1.Size = new System.Drawing.Size(75, 13);
            this.lblLotLocation1.TabIndex = 20;
            this.lblLotLocation1.Text = "Lot Location 1";
            // 
            // txtBomActHistSeq
            // 
            this.txtBomActHistSeq.Location = new System.Drawing.Point(164, 88);
            this.txtBomActHistSeq.MaxLength = 20;
            this.txtBomActHistSeq.Name = "txtBomActHistSeq";
            this.txtBomActHistSeq.ReadOnly = true;
            this.txtBomActHistSeq.Size = new System.Drawing.Size(162, 20);
            this.txtBomActHistSeq.TabIndex = 7;
            this.txtBomActHistSeq.TabStop = false;
            // 
            // lblBomActHistSeq
            // 
            this.lblBomActHistSeq.AutoSize = true;
            this.lblBomActHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBomActHistSeq.Location = new System.Drawing.Point(16, 90);
            this.lblBomActHistSeq.Name = "lblBomActHistSeq";
            this.lblBomActHistSeq.Size = new System.Drawing.Size(107, 13);
            this.lblBomActHistSeq.TabIndex = 6;
            this.lblBomActHistSeq.Text = "BOM Active Hist Seq";
            // 
            // txtAddOrder3
            // 
            this.txtAddOrder3.Location = new System.Drawing.Point(164, 172);
            this.txtAddOrder3.MaxLength = 20;
            this.txtAddOrder3.Name = "txtAddOrder3";
            this.txtAddOrder3.ReadOnly = true;
            this.txtAddOrder3.Size = new System.Drawing.Size(162, 20);
            this.txtAddOrder3.TabIndex = 13;
            this.txtAddOrder3.TabStop = false;
            // 
            // txtAddOrder2
            // 
            this.txtAddOrder2.Location = new System.Drawing.Point(164, 148);
            this.txtAddOrder2.MaxLength = 20;
            this.txtAddOrder2.Name = "txtAddOrder2";
            this.txtAddOrder2.ReadOnly = true;
            this.txtAddOrder2.Size = new System.Drawing.Size(162, 20);
            this.txtAddOrder2.TabIndex = 11;
            this.txtAddOrder2.TabStop = false;
            // 
            // txtAddOrder1
            // 
            this.txtAddOrder1.Location = new System.Drawing.Point(164, 124);
            this.txtAddOrder1.MaxLength = 20;
            this.txtAddOrder1.Name = "txtAddOrder1";
            this.txtAddOrder1.ReadOnly = true;
            this.txtAddOrder1.Size = new System.Drawing.Size(162, 20);
            this.txtAddOrder1.TabIndex = 9;
            this.txtAddOrder1.TabStop = false;
            // 
            // lblAddOrder3
            // 
            this.lblAddOrder3.AutoSize = true;
            this.lblAddOrder3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder3.Location = new System.Drawing.Point(16, 174);
            this.lblAddOrder3.Name = "lblAddOrder3";
            this.lblAddOrder3.Size = new System.Drawing.Size(78, 13);
            this.lblAddOrder3.TabIndex = 12;
            this.lblAddOrder3.Text = "Add Order ID 3";
            // 
            // lblAddOrder2
            // 
            this.lblAddOrder2.AutoSize = true;
            this.lblAddOrder2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder2.Location = new System.Drawing.Point(16, 150);
            this.lblAddOrder2.Name = "lblAddOrder2";
            this.lblAddOrder2.Size = new System.Drawing.Size(78, 13);
            this.lblAddOrder2.TabIndex = 10;
            this.lblAddOrder2.Text = "Add Order ID 2";
            // 
            // lblAddOrder1
            // 
            this.lblAddOrder1.AutoSize = true;
            this.lblAddOrder1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder1.Location = new System.Drawing.Point(16, 126);
            this.lblAddOrder1.Name = "lblAddOrder1";
            this.lblAddOrder1.Size = new System.Drawing.Size(78, 13);
            this.lblAddOrder1.TabIndex = 8;
            this.lblAddOrder1.Text = "Add Order ID 1";
            // 
            // txtBOMHistSeq
            // 
            this.txtBOMHistSeq.Location = new System.Drawing.Point(164, 64);
            this.txtBOMHistSeq.MaxLength = 20;
            this.txtBOMHistSeq.Name = "txtBOMHistSeq";
            this.txtBOMHistSeq.ReadOnly = true;
            this.txtBOMHistSeq.Size = new System.Drawing.Size(162, 20);
            this.txtBOMHistSeq.TabIndex = 5;
            this.txtBOMHistSeq.TabStop = false;
            // 
            // txtBOMSetVersion
            // 
            this.txtBOMSetVersion.Location = new System.Drawing.Point(164, 40);
            this.txtBOMSetVersion.MaxLength = 20;
            this.txtBOMSetVersion.Name = "txtBOMSetVersion";
            this.txtBOMSetVersion.ReadOnly = true;
            this.txtBOMSetVersion.Size = new System.Drawing.Size(162, 20);
            this.txtBOMSetVersion.TabIndex = 3;
            this.txtBOMSetVersion.TabStop = false;
            // 
            // txtBOMSetID
            // 
            this.txtBOMSetID.Location = new System.Drawing.Point(164, 16);
            this.txtBOMSetID.MaxLength = 20;
            this.txtBOMSetID.Name = "txtBOMSetID";
            this.txtBOMSetID.ReadOnly = true;
            this.txtBOMSetID.Size = new System.Drawing.Size(162, 20);
            this.txtBOMSetID.TabIndex = 1;
            this.txtBOMSetID.TabStop = false;
            // 
            // lblBOMHistSeq
            // 
            this.lblBOMHistSeq.AutoSize = true;
            this.lblBOMHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMHistSeq.Location = new System.Drawing.Point(15, 67);
            this.lblBOMHistSeq.Name = "lblBOMHistSeq";
            this.lblBOMHistSeq.Size = new System.Drawing.Size(74, 13);
            this.lblBOMHistSeq.TabIndex = 4;
            this.lblBOMHistSeq.Text = "BOM Hist Seq";
            // 
            // lblBOMSetVersion
            // 
            this.lblBOMSetVersion.AutoSize = true;
            this.lblBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVersion.Location = new System.Drawing.Point(15, 43);
            this.lblBOMSetVersion.Name = "lblBOMSetVersion";
            this.lblBOMSetVersion.Size = new System.Drawing.Size(88, 13);
            this.lblBOMSetVersion.TabIndex = 2;
            this.lblBOMSetVersion.Text = "BOM Set Version";
            // 
            // lblBOMSetID
            // 
            this.lblBOMSetID.AutoSize = true;
            this.lblBOMSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetID.Location = new System.Drawing.Point(15, 19);
            this.lblBOMSetID.Name = "lblBOMSetID";
            this.lblBOMSetID.Size = new System.Drawing.Size(64, 13);
            this.lblBOMSetID.TabIndex = 0;
            this.lblBOMSetID.Text = "BOM Set ID";
            // 
            // grpGen3Mid
            // 
            this.grpGen3Mid.Controls.Add(this.txtComment);
            this.grpGen3Mid.Controls.Add(this.txtLastActHistSeq);
            this.grpGen3Mid.Controls.Add(this.txtLastHistSeq);
            this.grpGen3Mid.Controls.Add(this.txtLastTrnTime);
            this.grpGen3Mid.Controls.Add(this.txtLastTrnCode);
            this.grpGen3Mid.Controls.Add(this.lblLastHistSeq);
            this.grpGen3Mid.Controls.Add(this.lblLastActHistSeq);
            this.grpGen3Mid.Controls.Add(this.lblComment);
            this.grpGen3Mid.Controls.Add(this.lblLastTrnTime);
            this.grpGen3Mid.Controls.Add(this.lblLastTrnCode);
            this.grpGen3Mid.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGen3Mid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen3Mid.Location = new System.Drawing.Point(3, 0);
            this.grpGen3Mid.Name = "grpGen3Mid";
            this.grpGen3Mid.Size = new System.Drawing.Size(722, 170);
            this.grpGen3Mid.TabIndex = 0;
            this.grpGen3Mid.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(164, 64);
            this.txtComment.MaxLength = 400;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(540, 94);
            this.txtComment.TabIndex = 9;
            this.txtComment.TabStop = false;
            // 
            // txtLastActHistSeq
            // 
            this.txtLastActHistSeq.Location = new System.Drawing.Point(542, 40);
            this.txtLastActHistSeq.MaxLength = 25;
            this.txtLastActHistSeq.Name = "txtLastActHistSeq";
            this.txtLastActHistSeq.ReadOnly = true;
            this.txtLastActHistSeq.Size = new System.Drawing.Size(162, 20);
            this.txtLastActHistSeq.TabIndex = 7;
            this.txtLastActHistSeq.TabStop = false;
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(542, 16);
            this.txtLastHistSeq.MaxLength = 25;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(162, 20);
            this.txtLastHistSeq.TabIndex = 5;
            this.txtLastHistSeq.TabStop = false;
            // 
            // txtLastTrnTime
            // 
            this.txtLastTrnTime.Location = new System.Drawing.Point(164, 40);
            this.txtLastTrnTime.MaxLength = 25;
            this.txtLastTrnTime.Name = "txtLastTrnTime";
            this.txtLastTrnTime.ReadOnly = true;
            this.txtLastTrnTime.Size = new System.Drawing.Size(162, 20);
            this.txtLastTrnTime.TabIndex = 3;
            this.txtLastTrnTime.TabStop = false;
            // 
            // txtLastTrnCode
            // 
            this.txtLastTrnCode.Location = new System.Drawing.Point(164, 16);
            this.txtLastTrnCode.MaxLength = 12;
            this.txtLastTrnCode.Name = "txtLastTrnCode";
            this.txtLastTrnCode.ReadOnly = true;
            this.txtLastTrnCode.Size = new System.Drawing.Size(162, 20);
            this.txtLastTrnCode.TabIndex = 1;
            this.txtLastTrnCode.TabStop = false;
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.Location = new System.Drawing.Point(392, 19);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblLastHistSeq.TabIndex = 4;
            this.lblLastHistSeq.Text = "Last Hist Seq";
            // 
            // lblLastActHistSeq
            // 
            this.lblLastActHistSeq.AutoSize = true;
            this.lblLastActHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastActHistSeq.Location = new System.Drawing.Point(392, 43);
            this.lblLastActHistSeq.Name = "lblLastActHistSeq";
            this.lblLastActHistSeq.Size = new System.Drawing.Size(103, 13);
            this.lblLastActHistSeq.TabIndex = 6;
            this.lblLastActHistSeq.Text = "Last Active Hist Seq";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Location = new System.Drawing.Point(15, 67);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(74, 13);
            this.lblComment.TabIndex = 8;
            this.lblComment.Text = "Last Comment";
            // 
            // lblLastTrnTime
            // 
            this.lblLastTrnTime.AutoSize = true;
            this.lblLastTrnTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTrnTime.Location = new System.Drawing.Point(15, 43);
            this.lblLastTrnTime.Name = "lblLastTrnTime";
            this.lblLastTrnTime.Size = new System.Drawing.Size(112, 13);
            this.lblLastTrnTime.TabIndex = 2;
            this.lblLastTrnTime.Text = "Last Transaction Time";
            // 
            // lblLastTrnCode
            // 
            this.lblLastTrnCode.AutoSize = true;
            this.lblLastTrnCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTrnCode.Location = new System.Drawing.Point(15, 19);
            this.lblLastTrnCode.Name = "lblLastTrnCode";
            this.lblLastTrnCode.Size = new System.Drawing.Size(114, 13);
            this.lblLastTrnCode.TabIndex = 0;
            this.lblLastTrnCode.Text = "Last Transaction Code";
            // 
            // tbpGeneral4
            // 
            this.tbpGeneral4.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral4.Controls.Add(this.grpCriticalResource);
            this.tbpGeneral4.Controls.Add(this.grpLotGroup);
            this.tbpGeneral4.Controls.Add(this.pnlReserve);
            this.tbpGeneral4.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral4.Name = "tbpGeneral4";
            this.tbpGeneral4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral4.Size = new System.Drawing.Size(728, 412);
            this.tbpGeneral4.TabIndex = 4;
            this.tbpGeneral4.Text = "General 4";
            // 
            // grpCriticalResource
            // 
            this.grpCriticalResource.Controls.Add(this.lisCrrList);
            this.grpCriticalResource.Controls.Add(this.CriticalResourceGroupID);
            this.grpCriticalResource.Controls.Add(this.lblCriticalResourceID);
            this.grpCriticalResource.Controls.Add(this.txtCriticalResourceGroupID);
            this.grpCriticalResource.Controls.Add(this.txtCriticalResourceID);
            this.grpCriticalResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCriticalResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCriticalResource.Location = new System.Drawing.Point(363, 192);
            this.grpCriticalResource.Name = "grpCriticalResource";
            this.grpCriticalResource.Size = new System.Drawing.Size(362, 217);
            this.grpCriticalResource.TabIndex = 2;
            this.grpCriticalResource.TabStop = false;
            // 
            // lisCrrList
            // 
            this.lisCrrList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lisCrrList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCrrID,
            this.colCrrQty1,
            this.colCrrQty2,
            this.colCrrQty3});
            this.lisCrrList.EnableSort = true;
            this.lisCrrList.EnableSortIcon = true;
            this.lisCrrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCrrList.FullRowSelect = true;
            this.lisCrrList.Location = new System.Drawing.Point(17, 70);
            this.lisCrrList.Name = "lisCrrList";
            this.lisCrrList.Size = new System.Drawing.Size(300, 141);
            this.lisCrrList.TabIndex = 6;
            this.lisCrrList.UseCompatibleStateImageBehavior = false;
            this.lisCrrList.View = System.Windows.Forms.View.Details;
            // 
            // colCrrID
            // 
            this.colCrrID.Text = "Carrier";
            this.colCrrID.Width = 93;
            // 
            // colCrrQty1
            // 
            this.colCrrQty1.Text = "Qty 1";
            // 
            // colCrrQty2
            // 
            this.colCrrQty2.Text = "Qty 2";
            // 
            // colCrrQty3
            // 
            this.colCrrQty3.Text = "Qty 3";
            // 
            // CriticalResourceGroupID
            // 
            this.CriticalResourceGroupID.AutoSize = true;
            this.CriticalResourceGroupID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CriticalResourceGroupID.Location = new System.Drawing.Point(17, 23);
            this.CriticalResourceGroupID.Name = "CriticalResourceGroupID";
            this.CriticalResourceGroupID.Size = new System.Drawing.Size(133, 13);
            this.CriticalResourceGroupID.TabIndex = 0;
            this.CriticalResourceGroupID.Text = "Critical Resource Group ID";
            // 
            // lblCriticalResourceID
            // 
            this.lblCriticalResourceID.AutoSize = true;
            this.lblCriticalResourceID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCriticalResourceID.Location = new System.Drawing.Point(17, 49);
            this.lblCriticalResourceID.Name = "lblCriticalResourceID";
            this.lblCriticalResourceID.Size = new System.Drawing.Size(101, 13);
            this.lblCriticalResourceID.TabIndex = 2;
            this.lblCriticalResourceID.Text = "Critical Resource ID";
            // 
            // txtCriticalResourceGroupID
            // 
            this.txtCriticalResourceGroupID.Location = new System.Drawing.Point(155, 22);
            this.txtCriticalResourceGroupID.MaxLength = 20;
            this.txtCriticalResourceGroupID.Name = "txtCriticalResourceGroupID";
            this.txtCriticalResourceGroupID.ReadOnly = true;
            this.txtCriticalResourceGroupID.Size = new System.Drawing.Size(162, 20);
            this.txtCriticalResourceGroupID.TabIndex = 1;
            this.txtCriticalResourceGroupID.TabStop = false;
            // 
            // txtCriticalResourceID
            // 
            this.txtCriticalResourceID.Location = new System.Drawing.Point(155, 46);
            this.txtCriticalResourceID.MaxLength = 20;
            this.txtCriticalResourceID.Name = "txtCriticalResourceID";
            this.txtCriticalResourceID.ReadOnly = true;
            this.txtCriticalResourceID.Size = new System.Drawing.Size(162, 20);
            this.txtCriticalResourceID.TabIndex = 3;
            this.txtCriticalResourceID.TabStop = false;
            // 
            // grpLotGroup
            // 
            this.grpLotGroup.Controls.Add(this.lblGoodQty);
            this.grpLotGroup.Controls.Add(this.txtGoodQty);
            this.grpLotGroup.Controls.Add(this.lblYield3);
            this.grpLotGroup.Controls.Add(this.txtYield3);
            this.grpLotGroup.Controls.Add(this.lblYield2);
            this.grpLotGroup.Controls.Add(this.txtYield2);
            this.grpLotGroup.Controls.Add(this.lblYield1);
            this.grpLotGroup.Controls.Add(this.txtYield1);
            this.grpLotGroup.Controls.Add(this.lblLotGroupID1);
            this.grpLotGroup.Controls.Add(this.lblLotGroupID2);
            this.grpLotGroup.Controls.Add(this.lblHoldPrvGroupID);
            this.grpLotGroup.Controls.Add(this.lblLotGroupID3);
            this.grpLotGroup.Controls.Add(this.txtLotGroupID1);
            this.grpLotGroup.Controls.Add(this.txtLotGroupID2);
            this.grpLotGroup.Controls.Add(this.txtLotGroupID3);
            this.grpLotGroup.Controls.Add(this.txtHoldPrvGroupID);
            this.grpLotGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLotGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotGroup.Location = new System.Drawing.Point(3, 192);
            this.grpLotGroup.Name = "grpLotGroup";
            this.grpLotGroup.Size = new System.Drawing.Size(360, 217);
            this.grpLotGroup.TabIndex = 1;
            this.grpLotGroup.TabStop = false;
            // 
            // lblGoodQty
            // 
            this.lblGoodQty.AutoSize = true;
            this.lblGoodQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGoodQty.Location = new System.Drawing.Point(16, 192);
            this.lblGoodQty.Name = "lblGoodQty";
            this.lblGoodQty.Size = new System.Drawing.Size(52, 13);
            this.lblGoodQty.TabIndex = 14;
            this.lblGoodQty.Text = "Good Qty";
            // 
            // txtGoodQty
            // 
            this.txtGoodQty.Location = new System.Drawing.Point(153, 191);
            this.txtGoodQty.MaxLength = 20;
            this.txtGoodQty.Name = "txtGoodQty";
            this.txtGoodQty.ReadOnly = true;
            this.txtGoodQty.Size = new System.Drawing.Size(162, 20);
            this.txtGoodQty.TabIndex = 15;
            this.txtGoodQty.TabStop = false;
            // 
            // lblYield3
            // 
            this.lblYield3.AutoSize = true;
            this.lblYield3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield3.Location = new System.Drawing.Point(16, 168);
            this.lblYield3.Name = "lblYield3";
            this.lblYield3.Size = new System.Drawing.Size(39, 13);
            this.lblYield3.TabIndex = 12;
            this.lblYield3.Text = "Yield 3";
            // 
            // txtYield3
            // 
            this.txtYield3.Location = new System.Drawing.Point(153, 167);
            this.txtYield3.MaxLength = 20;
            this.txtYield3.Name = "txtYield3";
            this.txtYield3.ReadOnly = true;
            this.txtYield3.Size = new System.Drawing.Size(162, 20);
            this.txtYield3.TabIndex = 13;
            this.txtYield3.TabStop = false;
            // 
            // lblYield2
            // 
            this.lblYield2.AutoSize = true;
            this.lblYield2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield2.Location = new System.Drawing.Point(16, 144);
            this.lblYield2.Name = "lblYield2";
            this.lblYield2.Size = new System.Drawing.Size(39, 13);
            this.lblYield2.TabIndex = 10;
            this.lblYield2.Text = "Yield 2";
            // 
            // txtYield2
            // 
            this.txtYield2.Location = new System.Drawing.Point(153, 143);
            this.txtYield2.MaxLength = 20;
            this.txtYield2.Name = "txtYield2";
            this.txtYield2.ReadOnly = true;
            this.txtYield2.Size = new System.Drawing.Size(162, 20);
            this.txtYield2.TabIndex = 11;
            this.txtYield2.TabStop = false;
            // 
            // lblYield1
            // 
            this.lblYield1.AutoSize = true;
            this.lblYield1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield1.Location = new System.Drawing.Point(16, 120);
            this.lblYield1.Name = "lblYield1";
            this.lblYield1.Size = new System.Drawing.Size(39, 13);
            this.lblYield1.TabIndex = 8;
            this.lblYield1.Text = "Yield 1";
            // 
            // txtYield1
            // 
            this.txtYield1.Location = new System.Drawing.Point(153, 119);
            this.txtYield1.MaxLength = 20;
            this.txtYield1.Name = "txtYield1";
            this.txtYield1.ReadOnly = true;
            this.txtYield1.Size = new System.Drawing.Size(162, 20);
            this.txtYield1.TabIndex = 9;
            this.txtYield1.TabStop = false;
            // 
            // lblLotGroupID1
            // 
            this.lblLotGroupID1.AutoSize = true;
            this.lblLotGroupID1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotGroupID1.Location = new System.Drawing.Point(16, 21);
            this.lblLotGroupID1.Name = "lblLotGroupID1";
            this.lblLotGroupID1.Size = new System.Drawing.Size(77, 13);
            this.lblLotGroupID1.TabIndex = 0;
            this.lblLotGroupID1.Text = "Lot Group ID 1";
            // 
            // lblLotGroupID2
            // 
            this.lblLotGroupID2.AutoSize = true;
            this.lblLotGroupID2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotGroupID2.Location = new System.Drawing.Point(16, 47);
            this.lblLotGroupID2.Name = "lblLotGroupID2";
            this.lblLotGroupID2.Size = new System.Drawing.Size(77, 13);
            this.lblLotGroupID2.TabIndex = 2;
            this.lblLotGroupID2.Text = "Lot Group ID 2";
            // 
            // lblHoldPrvGroupID
            // 
            this.lblHoldPrvGroupID.AutoSize = true;
            this.lblHoldPrvGroupID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPrvGroupID.Location = new System.Drawing.Point(16, 96);
            this.lblHoldPrvGroupID.Name = "lblHoldPrvGroupID";
            this.lblHoldPrvGroupID.Size = new System.Drawing.Size(94, 13);
            this.lblHoldPrvGroupID.TabIndex = 6;
            this.lblHoldPrvGroupID.Text = "Hold Prv Group ID";
            // 
            // lblLotGroupID3
            // 
            this.lblLotGroupID3.AutoSize = true;
            this.lblLotGroupID3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotGroupID3.Location = new System.Drawing.Point(16, 71);
            this.lblLotGroupID3.Name = "lblLotGroupID3";
            this.lblLotGroupID3.Size = new System.Drawing.Size(77, 13);
            this.lblLotGroupID3.TabIndex = 4;
            this.lblLotGroupID3.Text = "Lot Group ID 3";
            // 
            // txtLotGroupID1
            // 
            this.txtLotGroupID1.Location = new System.Drawing.Point(153, 20);
            this.txtLotGroupID1.MaxLength = 20;
            this.txtLotGroupID1.Name = "txtLotGroupID1";
            this.txtLotGroupID1.ReadOnly = true;
            this.txtLotGroupID1.Size = new System.Drawing.Size(162, 20);
            this.txtLotGroupID1.TabIndex = 1;
            this.txtLotGroupID1.TabStop = false;
            // 
            // txtLotGroupID2
            // 
            this.txtLotGroupID2.Location = new System.Drawing.Point(153, 44);
            this.txtLotGroupID2.MaxLength = 20;
            this.txtLotGroupID2.Name = "txtLotGroupID2";
            this.txtLotGroupID2.ReadOnly = true;
            this.txtLotGroupID2.Size = new System.Drawing.Size(162, 20);
            this.txtLotGroupID2.TabIndex = 3;
            this.txtLotGroupID2.TabStop = false;
            // 
            // txtLotGroupID3
            // 
            this.txtLotGroupID3.Location = new System.Drawing.Point(153, 68);
            this.txtLotGroupID3.MaxLength = 20;
            this.txtLotGroupID3.Name = "txtLotGroupID3";
            this.txtLotGroupID3.ReadOnly = true;
            this.txtLotGroupID3.Size = new System.Drawing.Size(162, 20);
            this.txtLotGroupID3.TabIndex = 5;
            this.txtLotGroupID3.TabStop = false;
            // 
            // txtHoldPrvGroupID
            // 
            this.txtHoldPrvGroupID.Location = new System.Drawing.Point(153, 93);
            this.txtHoldPrvGroupID.MaxLength = 20;
            this.txtHoldPrvGroupID.Name = "txtHoldPrvGroupID";
            this.txtHoldPrvGroupID.ReadOnly = true;
            this.txtHoldPrvGroupID.Size = new System.Drawing.Size(162, 20);
            this.txtHoldPrvGroupID.TabIndex = 7;
            this.txtHoldPrvGroupID.TabStop = false;
            // 
            // pnlReserve
            // 
            this.pnlReserve.Controls.Add(this.grpReserve);
            this.pnlReserve.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReserve.Location = new System.Drawing.Point(3, 0);
            this.pnlReserve.Name = "pnlReserve";
            this.pnlReserve.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlReserve.Size = new System.Drawing.Size(722, 192);
            this.pnlReserve.TabIndex = 0;
            // 
            // grpReserve
            // 
            this.grpReserve.Controls.Add(this.chkReserveFlag1);
            this.grpReserve.Controls.Add(this.chkReserveFlag2);
            this.grpReserve.Controls.Add(this.chkReserveFlag3);
            this.grpReserve.Controls.Add(this.chkReserveFlag4);
            this.grpReserve.Controls.Add(this.chkReserveFlag5);
            this.grpReserve.Controls.Add(this.txtReserveField5);
            this.grpReserve.Controls.Add(this.txtReserveField3);
            this.grpReserve.Controls.Add(this.txtReserveField4);
            this.grpReserve.Controls.Add(this.txtReserveField2);
            this.grpReserve.Controls.Add(this.txtReserveField1);
            this.grpReserve.Controls.Add(this.lblResvField5);
            this.grpReserve.Controls.Add(this.lblResvField3);
            this.grpReserve.Controls.Add(this.lblResvField4);
            this.grpReserve.Controls.Add(this.lblResvField2);
            this.grpReserve.Controls.Add(this.lblResvField1);
            this.grpReserve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReserve.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpReserve.Location = new System.Drawing.Point(0, 5);
            this.grpReserve.Name = "grpReserve";
            this.grpReserve.Size = new System.Drawing.Size(722, 182);
            this.grpReserve.TabIndex = 0;
            this.grpReserve.TabStop = false;
            this.grpReserve.Text = "Reserve";
            // 
            // chkReserveFlag1
            // 
            this.chkReserveFlag1.AutoSize = true;
            this.chkReserveFlag1.Enabled = false;
            this.chkReserveFlag1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveFlag1.Location = new System.Drawing.Point(397, 21);
            this.chkReserveFlag1.Name = "chkReserveFlag1";
            this.chkReserveFlag1.Size = new System.Drawing.Size(104, 18);
            this.chkReserveFlag1.TabIndex = 10;
            this.chkReserveFlag1.TabStop = false;
            this.chkReserveFlag1.Text = "Reserve Flag 1";
            // 
            // chkReserveFlag2
            // 
            this.chkReserveFlag2.AutoSize = true;
            this.chkReserveFlag2.Enabled = false;
            this.chkReserveFlag2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveFlag2.Location = new System.Drawing.Point(397, 45);
            this.chkReserveFlag2.Name = "chkReserveFlag2";
            this.chkReserveFlag2.Size = new System.Drawing.Size(104, 18);
            this.chkReserveFlag2.TabIndex = 11;
            this.chkReserveFlag2.TabStop = false;
            this.chkReserveFlag2.Text = "Reserve Flag 2";
            // 
            // chkReserveFlag3
            // 
            this.chkReserveFlag3.AutoSize = true;
            this.chkReserveFlag3.Enabled = false;
            this.chkReserveFlag3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveFlag3.Location = new System.Drawing.Point(397, 69);
            this.chkReserveFlag3.Name = "chkReserveFlag3";
            this.chkReserveFlag3.Size = new System.Drawing.Size(104, 18);
            this.chkReserveFlag3.TabIndex = 12;
            this.chkReserveFlag3.TabStop = false;
            this.chkReserveFlag3.Text = "Reserve Flag 3";
            // 
            // chkReserveFlag4
            // 
            this.chkReserveFlag4.AutoSize = true;
            this.chkReserveFlag4.Enabled = false;
            this.chkReserveFlag4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveFlag4.Location = new System.Drawing.Point(397, 94);
            this.chkReserveFlag4.Name = "chkReserveFlag4";
            this.chkReserveFlag4.Size = new System.Drawing.Size(104, 18);
            this.chkReserveFlag4.TabIndex = 13;
            this.chkReserveFlag4.TabStop = false;
            this.chkReserveFlag4.Text = "Reserve Flag 4";
            // 
            // chkReserveFlag5
            // 
            this.chkReserveFlag5.AutoSize = true;
            this.chkReserveFlag5.Enabled = false;
            this.chkReserveFlag5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveFlag5.Location = new System.Drawing.Point(397, 118);
            this.chkReserveFlag5.Name = "chkReserveFlag5";
            this.chkReserveFlag5.Size = new System.Drawing.Size(104, 18);
            this.chkReserveFlag5.TabIndex = 14;
            this.chkReserveFlag5.TabStop = false;
            this.chkReserveFlag5.Text = "Reserve Flag 5";
            // 
            // txtReserveField5
            // 
            this.txtReserveField5.Location = new System.Drawing.Point(153, 115);
            this.txtReserveField5.MaxLength = 20;
            this.txtReserveField5.Name = "txtReserveField5";
            this.txtReserveField5.ReadOnly = true;
            this.txtReserveField5.Size = new System.Drawing.Size(162, 20);
            this.txtReserveField5.TabIndex = 9;
            this.txtReserveField5.TabStop = false;
            // 
            // txtReserveField3
            // 
            this.txtReserveField3.Location = new System.Drawing.Point(153, 66);
            this.txtReserveField3.MaxLength = 20;
            this.txtReserveField3.Name = "txtReserveField3";
            this.txtReserveField3.ReadOnly = true;
            this.txtReserveField3.Size = new System.Drawing.Size(162, 20);
            this.txtReserveField3.TabIndex = 5;
            this.txtReserveField3.TabStop = false;
            // 
            // txtReserveField4
            // 
            this.txtReserveField4.Location = new System.Drawing.Point(153, 91);
            this.txtReserveField4.MaxLength = 20;
            this.txtReserveField4.Name = "txtReserveField4";
            this.txtReserveField4.ReadOnly = true;
            this.txtReserveField4.Size = new System.Drawing.Size(162, 20);
            this.txtReserveField4.TabIndex = 7;
            this.txtReserveField4.TabStop = false;
            // 
            // txtReserveField2
            // 
            this.txtReserveField2.Location = new System.Drawing.Point(153, 42);
            this.txtReserveField2.MaxLength = 20;
            this.txtReserveField2.Name = "txtReserveField2";
            this.txtReserveField2.ReadOnly = true;
            this.txtReserveField2.Size = new System.Drawing.Size(162, 20);
            this.txtReserveField2.TabIndex = 3;
            this.txtReserveField2.TabStop = false;
            // 
            // txtReserveField1
            // 
            this.txtReserveField1.Location = new System.Drawing.Point(153, 18);
            this.txtReserveField1.MaxLength = 20;
            this.txtReserveField1.Name = "txtReserveField1";
            this.txtReserveField1.ReadOnly = true;
            this.txtReserveField1.Size = new System.Drawing.Size(162, 20);
            this.txtReserveField1.TabIndex = 1;
            this.txtReserveField1.TabStop = false;
            // 
            // lblResvField5
            // 
            this.lblResvField5.AutoSize = true;
            this.lblResvField5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvField5.Location = new System.Drawing.Point(16, 118);
            this.lblResvField5.Name = "lblResvField5";
            this.lblResvField5.Size = new System.Drawing.Size(81, 13);
            this.lblResvField5.TabIndex = 8;
            this.lblResvField5.Text = "Reserve Field 5";
            // 
            // lblResvField3
            // 
            this.lblResvField3.AutoSize = true;
            this.lblResvField3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvField3.Location = new System.Drawing.Point(16, 69);
            this.lblResvField3.Name = "lblResvField3";
            this.lblResvField3.Size = new System.Drawing.Size(81, 13);
            this.lblResvField3.TabIndex = 4;
            this.lblResvField3.Text = "Reserve Field 3";
            // 
            // lblResvField4
            // 
            this.lblResvField4.AutoSize = true;
            this.lblResvField4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvField4.Location = new System.Drawing.Point(16, 94);
            this.lblResvField4.Name = "lblResvField4";
            this.lblResvField4.Size = new System.Drawing.Size(81, 13);
            this.lblResvField4.TabIndex = 6;
            this.lblResvField4.Text = "Reserve Field 4";
            // 
            // lblResvField2
            // 
            this.lblResvField2.AutoSize = true;
            this.lblResvField2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvField2.Location = new System.Drawing.Point(16, 45);
            this.lblResvField2.Name = "lblResvField2";
            this.lblResvField2.Size = new System.Drawing.Size(81, 13);
            this.lblResvField2.TabIndex = 2;
            this.lblResvField2.Text = "Reserve Field 2";
            // 
            // lblResvField1
            // 
            this.lblResvField1.AutoSize = true;
            this.lblResvField1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvField1.Location = new System.Drawing.Point(15, 19);
            this.lblResvField1.Name = "lblResvField1";
            this.lblResvField1.Size = new System.Drawing.Size(81, 13);
            this.lblResvField1.TabIndex = 0;
            this.lblResvField1.Text = "Reserve Field 1";
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.BackColor = System.Drawing.SystemColors.Control;
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpAttribute.Size = new System.Drawing.Size(728, 412);
            this.tbpAttribute.TabIndex = 5;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = this.txtLotID.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "LOT";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 0);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(722, 409);
            this.udcAttributeStatus.TabIndex = 0;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // tbpSubLot
            // 
            this.tbpSubLot.BackColor = System.Drawing.SystemColors.Control;
            this.tbpSubLot.Controls.Add(this.grpSublot);
            this.tbpSubLot.Location = new System.Drawing.Point(4, 22);
            this.tbpSubLot.Name = "tbpSubLot";
            this.tbpSubLot.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpSubLot.Size = new System.Drawing.Size(728, 412);
            this.tbpSubLot.TabIndex = 6;
            this.tbpSubLot.Text = "Sublot";
            // 
            // grpSublot
            // 
            this.grpSublot.Controls.Add(this.spdList);
            this.grpSublot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSublot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSublot.Location = new System.Drawing.Point(3, 0);
            this.grpSublot.Name = "grpSublot";
            this.grpSublot.Size = new System.Drawing.Size(722, 409);
            this.grpSublot.TabIndex = 3;
            this.grpSublot.TabStop = false;
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 12;
            this.spdList.Location = new System.Drawing.Point(3, 16);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer5;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer5;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(716, 390);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 2;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 13;
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 85;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Slot No.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Carrier ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Owner Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Create Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Hold Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hold Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Oper In Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Oper In Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Inventory Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Transit Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tracking Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Inv Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Rework Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Rework Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Rework Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Rework Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Rework Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Rework End Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Rework End Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Rework Return Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "NSTD Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "NSTD Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "NSTD Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "NSTD Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Repair Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Repair Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Store Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Store Return Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Store Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Grade Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Cell Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Cell Judge";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Lot Base";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Last Hist Seq";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.Columns.Get(0).Label = "Slot No.";
            this.spdList_Sheet1.Columns.Get(0).Width = 50F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Sub Lot ID";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 101F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Material";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 103F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 82F;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 65F;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdList_Sheet1.Columns.Get(7).Label = "Qty 2";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 73F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(8).CellType = numberCellType2;
            this.spdList_Sheet1.Columns.Get(8).Label = "Qty 3";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 73F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Carrier ID";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 68F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Owner Code";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 79F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Create Code";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 79F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Status";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 67F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Hold Flag";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 66F;
            this.spdList_Sheet1.Columns.Get(14).Label = "Hold Code";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 70F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(15).CellType = numberCellType3;
            this.spdList_Sheet1.Columns.Get(15).Label = "Create Qty 2";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 80F;
            numberCellType4.DecimalPlaces = 3;
            numberCellType4.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(16).CellType = numberCellType4;
            this.spdList_Sheet1.Columns.Get(16).Label = "Create Qty 3";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 80F;
            numberCellType5.DecimalPlaces = 3;
            numberCellType5.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(17).CellType = numberCellType5;
            this.spdList_Sheet1.Columns.Get(17).Label = "Oper In Qty 2";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 84F;
            numberCellType6.DecimalPlaces = 3;
            numberCellType6.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(18).CellType = numberCellType6;
            this.spdList_Sheet1.Columns.Get(18).Label = "Oper In Qty 3";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 84F;
            this.spdList_Sheet1.Columns.Get(19).Label = "Inventory Flag";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 68F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Transit Flag";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 82F;
            this.spdList_Sheet1.Columns.Get(21).Label = "Tracking Flag";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 89F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Inv Unit";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Label = "Rework Flag";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 79F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Rework Code";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 85F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999D;
            numberCellType7.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(25).CellType = numberCellType7;
            this.spdList_Sheet1.Columns.Get(25).Label = "Rework Count";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 87F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Rework Return Flow";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 123F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Rework Return Oper";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 123F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Rework End Flow";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 117F;
            this.spdList_Sheet1.Columns.Get(29).Label = "Rework End Oper";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 113F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Rework Return Clear Flag";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 154F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Rework Time";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 120F;
            this.spdList_Sheet1.Columns.Get(32).Label = "NSTD Flag";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 62F;
            this.spdList_Sheet1.Columns.Get(33).Label = "NSTD Return Flow";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 118F;
            this.spdList_Sheet1.Columns.Get(34).Label = "NSTD Return Oper";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 114F;
            this.spdList_Sheet1.Columns.Get(35).Label = "NSTD Time";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 120F;
            this.spdList_Sheet1.Columns.Get(36).Label = "Repair Flag";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 61F;
            this.spdList_Sheet1.Columns.Get(37).Label = "Repair Return Oper";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 88F;
            this.spdList_Sheet1.Columns.Get(38).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 88F;
            this.spdList_Sheet1.Columns.Get(39).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 88F;
            this.spdList_Sheet1.Columns.Get(40).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 88F;
            this.spdList_Sheet1.Columns.Get(41).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 66F;
            this.spdList_Sheet1.Columns.Get(42).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(42).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 127F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 110F;
            this.spdList_Sheet1.Columns.Get(44).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 127F;
            this.spdList_Sheet1.Columns.Get(46).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 105F;
            this.spdList_Sheet1.Columns.Get(47).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(47).Width = 84F;
            this.spdList_Sheet1.Columns.Get(48).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 109F;
            this.spdList_Sheet1.Columns.Get(49).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 98F;
            this.spdList_Sheet1.Columns.Get(50).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 94F;
            this.spdList_Sheet1.Columns.Get(51).Label = "Location";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 69F;
            this.spdList_Sheet1.Columns.Get(52).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 79F;
            this.spdList_Sheet1.Columns.Get(53).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 79F;
            this.spdList_Sheet1.Columns.Get(54).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 79F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 79F;
            this.spdList_Sheet1.Columns.Get(56).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 79F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 79F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 79F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 79F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 79F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 79F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 80F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 80F;
            this.spdList_Sheet1.Columns.Get(64).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 80F;
            this.spdList_Sheet1.Columns.Get(65).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 80F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 80F;
            this.spdList_Sheet1.Columns.Get(67).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 80F;
            this.spdList_Sheet1.Columns.Get(68).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 80F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 80F;
            this.spdList_Sheet1.Columns.Get(70).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 80F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 80F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Cell Grade";
            this.spdList_Sheet1.Columns.Get(74).Width = 104F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Cell Judge";
            this.spdList_Sheet1.Columns.Get(75).Width = 114F;
            this.spdList_Sheet1.Columns.Get(77).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 101F;
            this.spdList_Sheet1.Columns.Get(78).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 119F;
            this.spdList_Sheet1.Columns.Get(79).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(79).Locked = true;
            this.spdList_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(79).Width = 129F;
            this.spdList_Sheet1.Columns.Get(80).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(80).Locked = true;
            this.spdList_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(80).Width = 104F;
            this.spdList_Sheet1.Columns.Get(81).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(81).Locked = true;
            this.spdList_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(81).Width = 128F;
            this.spdList_Sheet1.Columns.Get(82).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(82).Locked = true;
            this.spdList_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(82).Width = 220F;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.MaximumValue = 9999D;
            numberCellType8.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(83).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(83).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(83).Locked = true;
            this.spdList_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(83).Width = 130F;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.MaximumValue = 9999D;
            numberCellType9.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(84).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(84).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(84).Locked = true;
            this.spdList_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(84).Width = 91F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.RowHeader.Visible = false;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpCrtCmfField
            // 
            this.tbpCrtCmfField.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCrtCmfField.Controls.Add(this.grpCmf);
            this.tbpCrtCmfField.Location = new System.Drawing.Point(4, 22);
            this.tbpCrtCmfField.Name = "tbpCrtCmfField";
            this.tbpCrtCmfField.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCrtCmfField.Size = new System.Drawing.Size(728, 412);
            this.tbpCrtCmfField.TabIndex = 3;
            this.tbpCrtCmfField.Text = "Create Customized Field";
            // 
            // grpCmf
            // 
            this.grpCmf.Controls.Add(this.txtCmf17);
            this.grpCmf.Controls.Add(this.txtCmf15);
            this.grpCmf.Controls.Add(this.txtCmf20);
            this.grpCmf.Controls.Add(this.txtCmf19);
            this.grpCmf.Controls.Add(this.txtCmf18);
            this.grpCmf.Controls.Add(this.txtCmf16);
            this.grpCmf.Controls.Add(this.txtCmf14);
            this.grpCmf.Controls.Add(this.txtCmf13);
            this.grpCmf.Controls.Add(this.txtCmf12);
            this.grpCmf.Controls.Add(this.txtCmf11);
            this.grpCmf.Controls.Add(this.lblCMF20);
            this.grpCmf.Controls.Add(this.lblCMF19);
            this.grpCmf.Controls.Add(this.lblCMF18);
            this.grpCmf.Controls.Add(this.lblCMF17);
            this.grpCmf.Controls.Add(this.lblCMF16);
            this.grpCmf.Controls.Add(this.lblCMF15);
            this.grpCmf.Controls.Add(this.lblCMF14);
            this.grpCmf.Controls.Add(this.lblCMF13);
            this.grpCmf.Controls.Add(this.lblCMF12);
            this.grpCmf.Controls.Add(this.lblCMF11);
            this.grpCmf.Controls.Add(this.txtCmf7);
            this.grpCmf.Controls.Add(this.txtCmf5);
            this.grpCmf.Controls.Add(this.txtCmf10);
            this.grpCmf.Controls.Add(this.txtCmf9);
            this.grpCmf.Controls.Add(this.txtCmf8);
            this.grpCmf.Controls.Add(this.txtCmf6);
            this.grpCmf.Controls.Add(this.txtCmf4);
            this.grpCmf.Controls.Add(this.txtCmf3);
            this.grpCmf.Controls.Add(this.txtCmf2);
            this.grpCmf.Controls.Add(this.txtCmf1);
            this.grpCmf.Controls.Add(this.lblCMF10);
            this.grpCmf.Controls.Add(this.lblCMF9);
            this.grpCmf.Controls.Add(this.lblCMF8);
            this.grpCmf.Controls.Add(this.lblCMF7);
            this.grpCmf.Controls.Add(this.lblCMF6);
            this.grpCmf.Controls.Add(this.lblCMF5);
            this.grpCmf.Controls.Add(this.lblCMF4);
            this.grpCmf.Controls.Add(this.lblCMF3);
            this.grpCmf.Controls.Add(this.lblCMF2);
            this.grpCmf.Controls.Add(this.lblCMF1);
            this.grpCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCmf.Location = new System.Drawing.Point(3, 0);
            this.grpCmf.Name = "grpCmf";
            this.grpCmf.Size = new System.Drawing.Size(722, 409);
            this.grpCmf.TabIndex = 0;
            this.grpCmf.TabStop = false;
            // 
            // txtCmf17
            // 
            this.txtCmf17.Location = new System.Drawing.Point(519, 160);
            this.txtCmf17.MaxLength = 30;
            this.txtCmf17.Name = "txtCmf17";
            this.txtCmf17.ReadOnly = true;
            this.txtCmf17.Size = new System.Drawing.Size(180, 20);
            this.txtCmf17.TabIndex = 33;
            this.txtCmf17.TabStop = false;
            // 
            // txtCmf15
            // 
            this.txtCmf15.Location = new System.Drawing.Point(519, 112);
            this.txtCmf15.MaxLength = 30;
            this.txtCmf15.Name = "txtCmf15";
            this.txtCmf15.ReadOnly = true;
            this.txtCmf15.Size = new System.Drawing.Size(180, 20);
            this.txtCmf15.TabIndex = 29;
            this.txtCmf15.TabStop = false;
            // 
            // txtCmf20
            // 
            this.txtCmf20.Location = new System.Drawing.Point(519, 232);
            this.txtCmf20.MaxLength = 30;
            this.txtCmf20.Name = "txtCmf20";
            this.txtCmf20.ReadOnly = true;
            this.txtCmf20.Size = new System.Drawing.Size(180, 20);
            this.txtCmf20.TabIndex = 39;
            this.txtCmf20.TabStop = false;
            // 
            // txtCmf19
            // 
            this.txtCmf19.Location = new System.Drawing.Point(519, 208);
            this.txtCmf19.MaxLength = 30;
            this.txtCmf19.Name = "txtCmf19";
            this.txtCmf19.ReadOnly = true;
            this.txtCmf19.Size = new System.Drawing.Size(180, 20);
            this.txtCmf19.TabIndex = 37;
            this.txtCmf19.TabStop = false;
            // 
            // txtCmf18
            // 
            this.txtCmf18.Location = new System.Drawing.Point(519, 184);
            this.txtCmf18.MaxLength = 30;
            this.txtCmf18.Name = "txtCmf18";
            this.txtCmf18.ReadOnly = true;
            this.txtCmf18.Size = new System.Drawing.Size(180, 20);
            this.txtCmf18.TabIndex = 35;
            this.txtCmf18.TabStop = false;
            // 
            // txtCmf16
            // 
            this.txtCmf16.Location = new System.Drawing.Point(519, 136);
            this.txtCmf16.MaxLength = 30;
            this.txtCmf16.Name = "txtCmf16";
            this.txtCmf16.ReadOnly = true;
            this.txtCmf16.Size = new System.Drawing.Size(180, 20);
            this.txtCmf16.TabIndex = 31;
            this.txtCmf16.TabStop = false;
            // 
            // txtCmf14
            // 
            this.txtCmf14.Location = new System.Drawing.Point(519, 88);
            this.txtCmf14.MaxLength = 30;
            this.txtCmf14.Name = "txtCmf14";
            this.txtCmf14.ReadOnly = true;
            this.txtCmf14.Size = new System.Drawing.Size(180, 20);
            this.txtCmf14.TabIndex = 27;
            this.txtCmf14.TabStop = false;
            // 
            // txtCmf13
            // 
            this.txtCmf13.Location = new System.Drawing.Point(519, 64);
            this.txtCmf13.MaxLength = 30;
            this.txtCmf13.Name = "txtCmf13";
            this.txtCmf13.ReadOnly = true;
            this.txtCmf13.Size = new System.Drawing.Size(180, 20);
            this.txtCmf13.TabIndex = 25;
            this.txtCmf13.TabStop = false;
            // 
            // txtCmf12
            // 
            this.txtCmf12.Location = new System.Drawing.Point(519, 40);
            this.txtCmf12.MaxLength = 30;
            this.txtCmf12.Name = "txtCmf12";
            this.txtCmf12.ReadOnly = true;
            this.txtCmf12.Size = new System.Drawing.Size(180, 20);
            this.txtCmf12.TabIndex = 23;
            this.txtCmf12.TabStop = false;
            // 
            // txtCmf11
            // 
            this.txtCmf11.Location = new System.Drawing.Point(519, 16);
            this.txtCmf11.MaxLength = 30;
            this.txtCmf11.Name = "txtCmf11";
            this.txtCmf11.ReadOnly = true;
            this.txtCmf11.Size = new System.Drawing.Size(180, 20);
            this.txtCmf11.TabIndex = 21;
            this.txtCmf11.TabStop = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF20.Location = new System.Drawing.Point(372, 235);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 38;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF19.Location = new System.Drawing.Point(372, 211);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 36;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF18.Location = new System.Drawing.Point(372, 187);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 34;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF17.Location = new System.Drawing.Point(372, 163);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 32;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF16.Location = new System.Drawing.Point(372, 139);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 30;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF15.Location = new System.Drawing.Point(372, 115);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 28;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF14.Location = new System.Drawing.Point(372, 91);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 26;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF13.Location = new System.Drawing.Point(372, 67);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 24;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF12.Location = new System.Drawing.Point(372, 43);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 22;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF11.Location = new System.Drawing.Point(372, 20);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 20;
            // 
            // txtCmf7
            // 
            this.txtCmf7.Location = new System.Drawing.Point(169, 160);
            this.txtCmf7.MaxLength = 30;
            this.txtCmf7.Name = "txtCmf7";
            this.txtCmf7.ReadOnly = true;
            this.txtCmf7.Size = new System.Drawing.Size(180, 20);
            this.txtCmf7.TabIndex = 13;
            this.txtCmf7.TabStop = false;
            // 
            // txtCmf5
            // 
            this.txtCmf5.Location = new System.Drawing.Point(169, 112);
            this.txtCmf5.MaxLength = 30;
            this.txtCmf5.Name = "txtCmf5";
            this.txtCmf5.ReadOnly = true;
            this.txtCmf5.Size = new System.Drawing.Size(180, 20);
            this.txtCmf5.TabIndex = 9;
            this.txtCmf5.TabStop = false;
            // 
            // txtCmf10
            // 
            this.txtCmf10.Location = new System.Drawing.Point(169, 232);
            this.txtCmf10.MaxLength = 30;
            this.txtCmf10.Name = "txtCmf10";
            this.txtCmf10.ReadOnly = true;
            this.txtCmf10.Size = new System.Drawing.Size(180, 20);
            this.txtCmf10.TabIndex = 19;
            this.txtCmf10.TabStop = false;
            // 
            // txtCmf9
            // 
            this.txtCmf9.Location = new System.Drawing.Point(169, 208);
            this.txtCmf9.MaxLength = 30;
            this.txtCmf9.Name = "txtCmf9";
            this.txtCmf9.ReadOnly = true;
            this.txtCmf9.Size = new System.Drawing.Size(180, 20);
            this.txtCmf9.TabIndex = 17;
            this.txtCmf9.TabStop = false;
            // 
            // txtCmf8
            // 
            this.txtCmf8.Location = new System.Drawing.Point(169, 184);
            this.txtCmf8.MaxLength = 30;
            this.txtCmf8.Name = "txtCmf8";
            this.txtCmf8.ReadOnly = true;
            this.txtCmf8.Size = new System.Drawing.Size(180, 20);
            this.txtCmf8.TabIndex = 15;
            this.txtCmf8.TabStop = false;
            // 
            // txtCmf6
            // 
            this.txtCmf6.Location = new System.Drawing.Point(169, 136);
            this.txtCmf6.MaxLength = 30;
            this.txtCmf6.Name = "txtCmf6";
            this.txtCmf6.ReadOnly = true;
            this.txtCmf6.Size = new System.Drawing.Size(180, 20);
            this.txtCmf6.TabIndex = 11;
            this.txtCmf6.TabStop = false;
            // 
            // txtCmf4
            // 
            this.txtCmf4.Location = new System.Drawing.Point(169, 88);
            this.txtCmf4.MaxLength = 30;
            this.txtCmf4.Name = "txtCmf4";
            this.txtCmf4.ReadOnly = true;
            this.txtCmf4.Size = new System.Drawing.Size(180, 20);
            this.txtCmf4.TabIndex = 7;
            this.txtCmf4.TabStop = false;
            // 
            // txtCmf3
            // 
            this.txtCmf3.Location = new System.Drawing.Point(169, 64);
            this.txtCmf3.MaxLength = 30;
            this.txtCmf3.Name = "txtCmf3";
            this.txtCmf3.ReadOnly = true;
            this.txtCmf3.Size = new System.Drawing.Size(180, 20);
            this.txtCmf3.TabIndex = 5;
            this.txtCmf3.TabStop = false;
            // 
            // txtCmf2
            // 
            this.txtCmf2.Location = new System.Drawing.Point(169, 40);
            this.txtCmf2.MaxLength = 30;
            this.txtCmf2.Name = "txtCmf2";
            this.txtCmf2.ReadOnly = true;
            this.txtCmf2.Size = new System.Drawing.Size(180, 20);
            this.txtCmf2.TabIndex = 3;
            this.txtCmf2.TabStop = false;
            // 
            // txtCmf1
            // 
            this.txtCmf1.Location = new System.Drawing.Point(169, 16);
            this.txtCmf1.MaxLength = 30;
            this.txtCmf1.Name = "txtCmf1";
            this.txtCmf1.ReadOnly = true;
            this.txtCmf1.Size = new System.Drawing.Size(180, 20);
            this.txtCmf1.TabIndex = 1;
            this.txtCmf1.TabStop = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(23, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(23, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(23, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(23, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(23, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(23, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(23, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(23, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(23, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(23, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // tabLotExt
            // 
            this.tabLotExt.BackColor = System.Drawing.SystemColors.Control;
            this.tabLotExt.Controls.Add(this.grpExt);
            this.tabLotExt.Location = new System.Drawing.Point(4, 22);
            this.tabLotExt.Name = "tabLotExt";
            this.tabLotExt.Padding = new System.Windows.Forms.Padding(3);
            this.tabLotExt.Size = new System.Drawing.Size(728, 412);
            this.tabLotExt.TabIndex = 7;
            this.tabLotExt.Text = "Lot Extension";
            // 
            // grpExt
            // 
            this.grpExt.Controls.Add(this.spdExtList);
            this.grpExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExt.Location = new System.Drawing.Point(3, 3);
            this.grpExt.Name = "grpExt";
            this.grpExt.Size = new System.Drawing.Size(722, 406);
            this.grpExt.TabIndex = 0;
            this.grpExt.TabStop = false;
            // 
            // spdExtList
            // 
            this.spdExtList.AccessibleDescription = "spdExtList, Sheet1, Row 0, Column 0, ";
            this.spdExtList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdExtList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdExtList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdExtList.HorizontalScrollBar.Name = "";
            this.spdExtList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdExtList.HorizontalScrollBar.TabIndex = 20;
            this.spdExtList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdExtList.Location = new System.Drawing.Point(3, 16);
            this.spdExtList.Name = "spdExtList";
            this.spdExtList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdExtList_Sheet1});
            this.spdExtList.Size = new System.Drawing.Size(716, 387);
            this.spdExtList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdExtList.TabIndex = 0;
            this.spdExtList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdExtList.VerticalScrollBar.Name = "";
            this.spdExtList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdExtList.VerticalScrollBar.TabIndex = 21;
            this.spdExtList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdExtList_Sheet1
            // 
            this.spdExtList_Sheet1.Reset();
            spdExtList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdExtList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdExtList_Sheet1.ColumnCount = 2;
            this.spdExtList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdExtList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdExtList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdExtList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Property";
            this.spdExtList_Sheet1.ColumnHeader.Cells.Get(0, 0).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdExtList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Value";
            this.spdExtList_Sheet1.ColumnHeader.Cells.Get(0, 1).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdExtList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdExtList_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdExtList_Sheet1.Columns.Get(0).Label = "Property";
            this.spdExtList_Sheet1.Columns.Get(0).Locked = true;
            this.spdExtList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdExtList_Sheet1.Columns.Get(0).Width = 300F;
            this.spdExtList_Sheet1.Columns.Get(1).Label = "Value";
            this.spdExtList_Sheet1.Columns.Get(1).Locked = true;
            this.spdExtList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdExtList_Sheet1.Columns.Get(1).Width = 200F;
            this.spdExtList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdExtList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdExtList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdExtList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdExtList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdExtList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.grpLot);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLot.Location = new System.Drawing.Point(0, 0);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlLot.Size = new System.Drawing.Size(742, 70);
            this.pnlLot.TabIndex = 0;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.txtFactory);
            this.grpLot.Controls.Add(this.lblFactory);
            this.grpLot.Controls.Add(this.txtDesc);
            this.grpLot.Controls.Add(this.txtLotID);
            this.grpLot.Controls.Add(this.lblDesc);
            this.grpLot.Controls.Add(this.lblLotID);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 0);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(736, 70);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            // 
            // txtFactory
            // 
            this.txtFactory.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtFactory.Location = new System.Drawing.Point(524, 16);
            this.txtFactory.MaxLength = 10;
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.ReadOnly = true;
            this.txtFactory.Size = new System.Drawing.Size(200, 20);
            this.txtFactory.TabIndex = 3;
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactory.Location = new System.Drawing.Point(419, 19);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 2;
            this.lblFactory.Text = "Factory";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(604, 20);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(557, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmWIPViewLotStatus
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewLotStatus";
            this.Text = "View Lot Status";
            this.Activated += new System.EventHandler(this.frmWIPViewLotStatus_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewLotStatus_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlLotStatus.ResumeLayout(false);
            this.tabLotStatus.ResumeLayout(false);
            this.tbpGeneral1.ResumeLayout(false);
            this.grpGen1Mid.ResumeLayout(false);
            this.grpGen1Mid.PerformLayout();
            this.grpGen1Bottom.ResumeLayout(false);
            this.grpGen1Bottom.PerformLayout();
            this.tbpGeneral2.ResumeLayout(false);
            this.grpGen2Right.ResumeLayout(false);
            this.grpGen2Right.PerformLayout();
            this.grpGen2Left.ResumeLayout(false);
            this.grpGen2Left.PerformLayout();
            this.pnlResource.ResumeLayout(false);
            this.grpGen2Top.ResumeLayout(false);
            this.grpGen2Top.PerformLayout();
            this.tbpGeneral3.ResumeLayout(false);
            this.grpBOM.ResumeLayout(false);
            this.grpBOM.PerformLayout();
            this.grpGen3Mid.ResumeLayout(false);
            this.grpGen3Mid.PerformLayout();
            this.tbpGeneral4.ResumeLayout(false);
            this.grpCriticalResource.ResumeLayout(false);
            this.grpCriticalResource.PerformLayout();
            this.grpLotGroup.ResumeLayout(false);
            this.grpLotGroup.PerformLayout();
            this.pnlReserve.ResumeLayout(false);
            this.grpReserve.ResumeLayout(false);
            this.grpReserve.PerformLayout();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpSubLot.ResumeLayout(false);
            this.grpSublot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.tbpCrtCmfField.ResumeLayout(false);
            this.grpCmf.ResumeLayout(false);
            this.grpCmf.PerformLayout();
            this.tabLotExt.ResumeLayout(false);
            this.grpExt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdExtList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdExtList_Sheet1)).EndInit();
            this.pnlLot.ResumeLayout(false);
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // InitCmfControl()
        //       - Initial Cmf Control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void InitCmfControl()
        {
            ArrayList controls;
            int i;
            
            controls = MPCF.GetIndexedControl("lblCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((Label) controls[i]).Visible = false;
                ((Label) controls[i]).Text = "";
            }
            
            controls = MPCF.GetIndexedControl("txtCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((TextBox) controls[i]).Visible = false;
                ((TextBox) controls[i]).Text = "";
            }
        }
        
        // SetCmfItem()
        //       - Set Cmf Item
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList txtList;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            InitCmfControl();

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_LOT, ref out_node, "", true) == false)
            {
                return;
            }

            lblList = MPCF.GetIndexedControl("lblCmf", grpCmf);
            txtList = MPCF.GetIndexedControl("txtCmf", grpCmf);

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                lblTemp = (Label) lblList[i];
                txtTemp = (TextBox) txtList[i];

                lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");
                if (lblTemp.Text != "")
                {
                    lblTemp.Visible = true;
                    txtTemp.Visible = true;
                }
            }
        }

        // View_Lot()
        //       - View Lot Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //        -
        //
        private bool ViewLot(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            ListView lvItem = new ListView();       // Lot Type Items

            List<TRSNode> list_item;
            ListViewItem itmx;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtFactory.Text = out_node.GetString("FACTORY");
            txtDesc.Text = out_node.GetString("LOT_DESC");
            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            cdvMaterial.DescText = out_node.GetString("MAT_DESC");
            cdvFlow.Text = out_node.GetString("FLOW");
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            cdvFlow.DescText = out_node.GetString("FLOW_DESC");
            txtOper.Text = out_node.GetString("OPER");
            txtOperDesc.Text = out_node.GetString("OPER_DESC");
            txtQty1.Text = out_node.GetDouble("QTY_1").ToString("#####,##0.###");
            txtQty2.Text = out_node.GetDouble("QTY_2").ToString("#####,##0.###");
            txtQty3.Text = out_node.GetDouble("QTY_3").ToString("#####,##0.###");

            MPCF.InitListView(lvItem);
            lvItem.Columns.Add("LotType", 50, HorizontalAlignment.Left);
            lvItem.Columns.Add("Desc", 100, HorizontalAlignment.Left);

            BASLIST.ViewGCMDataList(lvItem, '1', MPGC.MP_WIP_LOT_TYPE);
            txtLotType.Text = "";

            for (int index = 0; index < lvItem.Items.Count; index++)
            {
                if (out_node.GetChar("LOT_TYPE") == MPCF.ToChar(lvItem.Items[index].SubItems[0].Text))
                {
                    txtLotType.Text = MPCF.Trim(lvItem.Items[index].SubItems[1].Text);
                }
            }
            
            txtOwnerCode.Text = out_node.GetString("OWNER_CODE");
            txtCrtCode.Text = out_node.GetString("CREATE_CODE");
            txtLotPriority.Text = out_node.GetChar("LOT_PRIORITY").ToString();
            txtLotStatus.Text = out_node.GetString("LOT_STATUS");
            chkHold.Checked = out_node.GetChar("HOLD_FLAG") == 'Y' ? true : false;
            txtHoldCode.Text = out_node.GetString("HOLD_CODE");

            txtStartQty1.Text = out_node.GetDouble("START_QTY_1").ToString("#####,##0.###");
            txtStartQty2.Text = out_node.GetDouble("START_QTY_2").ToString("#####,##0.###");
            txtStartQty3.Text = out_node.GetDouble("START_QTY_3").ToString("#####,##0.###");

            txtOperQty1.Text = out_node.GetDouble("OPER_IN_QTY_1").ToString("#####,##0.###");
            txtOperQty2.Text = out_node.GetDouble("OPER_IN_QTY_2").ToString("#####,##0.###");
            txtOperQty3.Text = out_node.GetDouble("OPER_IN_QTY_3").ToString("#####,##0.###");

            txtCrtQty1.Text = out_node.GetDouble("CREATE_QTY_1").ToString("#####,##0.###");
            txtCrtQty2.Text = out_node.GetDouble("CREATE_QTY_2").ToString("#####,##0.###");
            txtCrtQty3.Text = out_node.GetDouble("CREATE_QTY_3").ToString("#####,##0.###");

            chkInv.Checked = out_node.GetChar("INV_FLAG") == 'Y' ? true : false;
            chkTransit.Checked = out_node.GetChar("TRANSIT_FLAG") == 'Y' ? true : false;
            chkUnitExist.Checked = out_node.GetChar("UNIT_EXIST_FLAG") == 'Y' ? true : false;
            txtInvUnit.Text = out_node.GetString("INV_UNIT");

            chkRework.Checked = out_node.GetChar("RWK_FLAG") == 'Y' ? true : false;
            txtReworkCode.Text = out_node.GetString("RWK_CODE");
            txtReworkCnt.Text = out_node.GetInt("RWK_COUNT").ToString();
            txtReworkDepth.Text = out_node.GetInt("RWK_DEPTH").ToString();
            txtReworkStopOper.Text = out_node.GetString("RWK_STOP_OPER");
            udcReworkReturnFlow.Text = out_node.GetString("RWK_RET_FLOW");
            udcReworkReturnFlow.Version = out_node.GetInt("RWK_RET_FLOW_SEQ_NUM");
            txtReworkReturnOper.Text = out_node.GetString("RWK_RET_OPER");
            udcReworkEndFlow.Text = out_node.GetString("RWK_END_FLOW");
            udcReworkEndFlow.Version = out_node.GetInt("RWK_END_FLOW_SEQ_NUM");
            txtReworkEndOper.Text = out_node.GetString("RWK_END_OPER");
            switch (out_node.GetChar("RWK_RET_CLEAR_FLAG"))
            {
                case 'Y':
                    txtReturnOption.Text = "Clear Rework";
                    break;
                case 'A':
                    txtReturnOption.Text = "Clear Rework and Move to Next Operation";
                    break;
                case 'B':
                    txtReturnOption.Text = "Keep Rework and Move to Next Operation";
                    break;
                default:
                    if (chkRework.Checked == true)
                    {
                        txtReturnOption.Text = "Keep Rework";
                    }
                    else
                    {
                        txtReturnOption.Text = "";
                    }
                    break;
            }
            chkLocalRework.Checked = out_node.GetChar("LOCAL_REWORK_FLAG") == 'Y' ? true : false;
            txtReworkTime.Text = MPCF.MakeDateFormat(out_node.GetString("RWK_TIME"));

            chkNstd.Checked = out_node.GetChar("NSTD_FLAG") == 'Y' ? true : false;
            udcNstdReturnFlow.Text = out_node.GetString("NSTD_RET_FLOW");
            udcNstdReturnFlow.Version = out_node.GetInt("NSTD_RET_FLOW_SEQ_NUM");

            txtNstdReturnOper.Text = out_node.GetString("NSTD_RET_OPER");
            txtNstdTime.Text = MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME"));

            chkStart.Checked = out_node.GetChar("START_FLAG") == 'Y' ? true : false;
            txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            chkEnd.Checked = out_node.GetChar("END_FLAG") == 'Y' ? true : false;
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));

            MPCF.InitListView(lisStartResList);
            list_item = out_node.GetList("START_RES_LIST");
            if (list_item.Count > 0)
            {
                for (i = 0; i < list_item.Count; i++)
                {
                    itmx = new ListViewItem(list_item[i].GetString("RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                    itmx.SubItems.Add(list_item[i].GetDouble("QTY_1").ToString());

                    lisStartResList.Items.Add(itmx);
                }
            }
            else if (out_node.GetString("START_RES_ID") != "")
            {
                itmx = new ListViewItem(out_node.GetString("START_RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                itmx.SubItems.Add(out_node.GetDouble("QTY_1").ToString());

                lisStartResList.Items.Add(itmx);
            }

            MPCF.InitListView(lisEndResList);
            list_item = out_node.GetList("END_RES_LIST");
            if (list_item.Count > 0)
            {
                for (i = 0; i < list_item.Count; i++)
                {
                    itmx = new ListViewItem(list_item[i].GetString("RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                    itmx.SubItems.Add(list_item[i].GetDouble("QTY_1").ToString());

                    lisEndResList.Items.Add(itmx);
                }
            }
            else if (out_node.GetString("END_RES_ID") != "")
            {
                itmx = new ListViewItem(out_node.GetString("END_RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                itmx.SubItems.Add(out_node.GetDouble("QTY_1").ToString());

                lisEndResList.Items.Add(itmx);
            }

            txtSaveResID1.Text = out_node.GetString("SAVE_RES_ID_1");
            txtSaveResID2.Text = out_node.GetString("SAVE_RES_ID_2");
            txtSubResID.Text = out_node.GetString("SUBRES_ID");
            txtPort.Text = out_node.GetString("PORT_ID");

            chkSample.Checked = out_node.GetChar("SAMPLE_FLAG") == 'Y' ? true : false;
            chkSampleWait.Checked = out_node.GetChar("SAMPLE_WAIT_FLAG") == 'Y' ? true : false;
            switch (out_node.GetChar("SAMPLE_RESULT"))
            {
                case 'Y':

                    txtSampleRes.Text = "Good";
                    break;
                case 'N':

                    txtSampleRes.Text = "No Good";
                    break;
                default:

                    txtSampleRes.Text = "";
                    break;
            }
            txtSplitFromLot.Text = out_node.GetString("FROM_TO_LOT_ID");

            txtFromToFlag.Text = MPCF.Trim(out_node.GetChar("FROM_TO_FLAG"));

            txtShipCode.Text = out_node.GetString("SHIP_CODE");
            txtShipTime.Text = MPCF.MakeDateFormat(out_node.GetString("SHIP_TIME"));
            txtOrgDueTime.Text = MPCF.MakeDateFormat(out_node.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);
            txtSchDueTime.Text = MPCF.MakeDateFormat(out_node.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtFactoryInTime.Text = MPCF.MakeDateFormat(out_node.GetString("FAC_IN_TIME"));
            txtFlowInTime.Text = MPCF.MakeDateFormat(out_node.GetString("FLOW_IN_TIME"));
            txtOperInTime.Text = MPCF.MakeDateFormat(out_node.GetString("OPER_IN_TIME"));
            txtResvResID.Text = out_node.GetString("RESERVE_RES_ID");
            txtBatchID.Text = out_node.GetString("BATCH_ID");
            txtBatchSeq.Text = out_node.GetInt("BATCH_SEQ").ToString();
            txtOrderID.Text = out_node.GetString("ORDER_ID");
            txtAddOrder1.Text = out_node.GetString("ADD_ORDER_ID_1");
            txtAddOrder2.Text = out_node.GetString("ADD_ORDER_ID_2");
            txtAddOrder3.Text = out_node.GetString("ADD_ORDER_ID_3");
            txtCmf1.Text = out_node.GetString("LOT_CMF_1");
            txtCmf2.Text = out_node.GetString("LOT_CMF_2");
            txtCmf3.Text = out_node.GetString("LOT_CMF_3");
            txtCmf4.Text = out_node.GetString("LOT_CMF_4");
            txtCmf5.Text = out_node.GetString("LOT_CMF_5");
            txtCmf6.Text = out_node.GetString("LOT_CMF_6");
            txtCmf7.Text = out_node.GetString("LOT_CMF_7");
            txtCmf8.Text = out_node.GetString("LOT_CMF_8");
            txtCmf9.Text = out_node.GetString("LOT_CMF_9");
            txtCmf10.Text = out_node.GetString("LOT_CMF_10");
            txtCmf11.Text = out_node.GetString("LOT_CMF_11");
            txtCmf12.Text = out_node.GetString("LOT_CMF_12");
            txtCmf13.Text = out_node.GetString("LOT_CMF_13");
            txtCmf14.Text = out_node.GetString("LOT_CMF_14");
            txtCmf15.Text = out_node.GetString("LOT_CMF_15");
            txtCmf16.Text = out_node.GetString("LOT_CMF_16");
            txtCmf17.Text = out_node.GetString("LOT_CMF_17");
            txtCmf18.Text = out_node.GetString("LOT_CMF_18");
            txtCmf19.Text = out_node.GetString("LOT_CMF_19");
            txtCmf20.Text = out_node.GetString("LOT_CMF_20");

            chkLotDelete.Checked = out_node.GetChar("LOT_DEL_FLAG") == 'Y' ? true : false;
            txtDelReason.Text = out_node.GetString("LOT_DEL_CODE");
            txtLotDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("LOT_DEL_TIME"));

            txtLastTrnCode.Text = out_node.GetString("LAST_TRAN_CODE");
            txtLastTrnTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
            txtComment.Text = out_node.GetString("LAST_COMMENT");
            txtLastActHistSeq.Text = out_node.GetInt("LAST_ACTIVE_HIST_SEQ").ToString();
            txtLastHistSeq.Text = out_node.GetInt("LAST_HIST_SEQ").ToString();

            txtBOMSetID.Text = out_node.GetString("BOM_SET_ID");
            txtBOMSetVersion.Text = out_node.GetInt("BOM_SET_VERSION").ToString();
            txtBOMHistSeq.Text = out_node.GetInt("BOM_HIST_SEQ").ToString();
            txtBomActHistSeq.Text = out_node.GetInt("BOM_ACTIVE_HIST_SEQ").ToString();

            chkRepair.Checked = out_node.GetChar("REP_FLAG") == 'Y' ? true : false;
            txtRepairRetOper.Text = out_node.GetString("REP_RET_OPER");

            txtReserveField1.Text = out_node.GetString("RESV_FIELD_1");
            txtReserveField2.Text = out_node.GetString("RESV_FIELD_2");
            txtReserveField3.Text = out_node.GetString("RESV_FIELD_3");
            txtReserveField4.Text = out_node.GetString("RESV_FIELD_4");
            txtReserveField5.Text = out_node.GetString("RESV_FIELD_5");

            chkReserveFlag1.Checked = out_node.GetChar("RESV_FLAG_1") == 'Y' ? true : false;
            chkReserveFlag2.Checked = out_node.GetChar("RESV_FLAG_2") == 'Y' ? true : false;
            chkReserveFlag3.Checked = out_node.GetChar("RESV_FLAG_3") == 'Y' ? true : false;
            chkReserveFlag4.Checked = out_node.GetChar("RESV_FLAG_4") == 'Y' ? true : false;
            chkReserveFlag5.Checked = out_node.GetChar("RESV_FLAG_5") == 'Y' ? true : false;

            txtLotGroupID1.Text = out_node.GetString("LOT_GROUP_ID_1");
            txtLotGroupID2.Text = out_node.GetString("LOT_GROUP_ID_2");
            txtLotGroupID3.Text = out_node.GetString("LOT_GROUP_ID_3");
            txtHoldPrvGroupID.Text = out_node.GetString("HOLD_PRV_GRP_ID");

            txtCriticalResourceGroupID.Text = out_node.GetString("CRITICAL_RES_GROUP_ID");
            txtCriticalResourceID.Text = out_node.GetString("CRITICAL_RES_ID");

            MPCF.InitListView(lisCrrList);
            list_item = out_node.GetList("CRR_LIST");
            if (list_item.Count > 0)
            {
                for (i = 0; i < list_item.Count; i++)
                {
                    itmx = new ListViewItem(list_item[i].GetString("CRR_ID"), (int)SMALLICON_INDEX.IDX_CARRIER);
                    itmx.SubItems.Add(list_item[i].GetDouble("QTY_1").ToString());
                    itmx.SubItems.Add(list_item[i].GetDouble("QTY_2").ToString());
                    itmx.SubItems.Add(list_item[i].GetDouble("QTY_3").ToString());

                    lisCrrList.Items.Add(itmx);
                }
            }
            else if (out_node.GetString("CRR_ID") != "")
            {
                itmx = new ListViewItem(out_node.GetString("CRR_ID"), (int)SMALLICON_INDEX.IDX_CARRIER);
                itmx.SubItems.Add(out_node.GetDouble("QTY_1").ToString());
                itmx.SubItems.Add(out_node.GetDouble("QTY_2").ToString());
                itmx.SubItems.Add(out_node.GetDouble("QTY_3").ToString());

                lisCrrList.Items.Add(itmx);
            }

            txtStrRetFlow.Text = out_node.GetString("STR_RET_FLOW");
            txtStrRetFlowSeq.Text = out_node.GetInt("STR_RET_FLOW_SEQ_NUM").ToString();
            txtStrRetOper.Text = out_node.GetString("STR_RET_OPER");

            txtLotLocation1.Text = out_node.GetString("LOT_LOCATION_1");
            txtLotLocation2.Text = out_node.GetString("LOT_LOCATION_2");
            txtLotLocation3.Text = out_node.GetString("LOT_LOCATION_3");

            txtYield1.Text = out_node.GetDouble("YIELD_1").ToString();
            txtYield2.Text = out_node.GetDouble("YIELD_2").ToString();
            txtYield3.Text = out_node.GetDouble("YIELD_3").ToString();
            txtGoodQty.Text = out_node.GetDouble("GOOD_QTY").ToString();
            
            udcAttributeStatus.AttributeKey = txtLotID.Text;
            udcAttributeStatus.View();

            // 2012.05.02 - Add for Lot Extension
            int i_row;
            List<TRSNode> ext_list;

            MPCF.ClearList(spdExtList);
            ext_list = out_node.GetList("EXT_LIST");

            if (ext_list.Count > 0)
            {
                for (i = 2; i < ext_list[0].MemberCount; i++)
                {
                    i_row = spdExtList.ActiveSheet.RowCount;
                    spdExtList.ActiveSheet.RowCount++;

                    spdExtList.ActiveSheet.Cells[i_row, 0].Value = MPCF.Trim(ext_list[0].GetMember(i).Name);
                    spdExtList.ActiveSheet.Cells[i_row, 1].Value = MPCF.Trim(ext_list[0].GetMember(i).Value);
                }
            }
            // End 2012.05.02

            return true;

        }

        // View_SubLot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewSubLotList()
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");
            int i;

            int iRow;
            int iCol;
            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    sheet = spdList.Sheets[0];
                    iRow = sheet.RowCount;
                    sheet.RowCount++;
                    iCol = 0;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CRR_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_STATUS");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("INV_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("TRANSIT_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("INV_UNIT");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("NSTD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("REP_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REP_RET_OPER");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_FLOW");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("STR_RET_FLOW_SEQ_NUM");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("START_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("START_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("END_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("END_RES_ID");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG");

                    iCol++;
                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            sheet.Cells[iRow, iCol].Value = "Good";
                            break;
                        case 'N':

                            sheet.Cells[iRow, iCol].Value = "No Good";
                            break;
                        default:

                            sheet.Cells[iRow, iCol].Value = "";
                            break;
                    }
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESERVE_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_LOCATION");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_1");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_2");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_3");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_4");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_5");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_6");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_7");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_8");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_9");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_10");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_11");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_12");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_13");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_14");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_15");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_16");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_17");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_18");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_19");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_20");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("GRADE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");

                    //Add by J.S. 2009.02.18 Add CELL_JUDGE
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_BASE");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_DEL_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SUBLOT_DEL_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_TRAN_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_COMMENT");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ"));

                    iCol++;

                    if (out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG") == 'Y')
                    {
                        sheet.Rows[iRow].ForeColor = Color.Magenta;
                    }

                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            MPCF.FitColumnHeader(spdList);
            return true;
        }


        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnProcess_Click(btnProcess, null);
            }
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewLotStatus_Load(object sender, System.EventArgs e)
        {
            cdvMaterial.BackColor = SystemColors.Control;
            cdvFlow.BackColor = SystemColors.Control;            
        }
        
        private void frmWIPViewLotStatus_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                SetCmfItem();
                txtLotID.Focus();
                
                ActiveFormNow();

                b_load_flag = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text != "")
            {
                if (ViewLot('2', txtLotID.Text) == false)
                {
                    return;
                }

                //Add For V42
                if (ViewSubLotList() == false)
                {
                    //return;
                }

                this.Text = MPCF.FindLanguage("Lot Status", 0) + " (" + txtLotID.Text + ")";
                this.lblFormTitle.Text = this.Text;
            }
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text != "")
            {
                if (ViewLot('2', txtLotID.Text) == false)
                {
                    return;
                }

                MPGV.gsCurrentLot_ID = txtLotID.Text;

                try
                {
                    Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmWIPViewLotHistory");
                    if (f != null)
                    {
                        f.BringToFront();
                        f.Show();
                    }
                    else
                    {
                        f = new frmWIPViewLotHistory();
                        f.MdiParent = MPGV.gfrmMDI;
                        f.BringToFront();
                        f.Show();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }
        }  
    }
    
}
