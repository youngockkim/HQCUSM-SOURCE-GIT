
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranSplitExtLot.vb
//   Description : Split Extension Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetCreateCodeList() : Get Create Code List
//       - GetOwnerCodeList() : Get Owner Code List
//       - GetLotTypeList() : Get Lot Type List
//       - GetMaterialList() : Get Material List
//       - GetFlowList() : Get Flow List
//       - GetOperationList() : Get Operation List
//       - View_Material() : View Material Information
//       - View_Operation() : View Operation Information
//       - View_Lot() : View Lot Information
//       - Split_Lot() : Split Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-10 : Created by CM Koo
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
    public class frmWIPTranSplitLotExt : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranSplitLotExt()
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
        



        private System.Windows.Forms.GroupBox grpChildLot;
        private System.Windows.Forms.Panel pnlChildInfo;
        private System.Windows.Forms.TextBox txtChildLotDesc;
        private System.Windows.Forms.Label lblChildLotDesc;
        private System.Windows.Forms.TextBox txtChildLotID;
        private System.Windows.Forms.Label lblChildLotID;
        private System.Windows.Forms.TabPage tbpCreateCMF;
        private System.Windows.Forms.Label lblCreateCMF10;
        private System.Windows.Forms.Label lblCreateCMF9;
        private System.Windows.Forms.Label lblCreateCMF8;
        private System.Windows.Forms.Label lblCreateCMF7;
        private System.Windows.Forms.Label lblCreateCMF6;
        private System.Windows.Forms.Label lblCreateCMF5;
        private System.Windows.Forms.Label lblCreateCMF4;
        private System.Windows.Forms.Label lblCreateCMF3;
        private System.Windows.Forms.Label lblCreateCMF1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF1;
        private System.Windows.Forms.GroupBox grpCreateCMF;
        private System.Windows.Forms.Panel pnlCreateCMF;
        private System.Windows.Forms.GroupBox grpChildLotInfo;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.TextBox txtDueDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF19;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF18;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF17;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF16;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF15;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF14;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF13;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF12;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF20;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF11;
        private System.Windows.Forms.Label lblCreateCMF20;
        private System.Windows.Forms.Label lblCreateCMF19;
        private System.Windows.Forms.Label lblCreateCMF18;
        private System.Windows.Forms.Label lblCreateCMF17;
        private System.Windows.Forms.Label lblCreateCMF16;
        private System.Windows.Forms.Label lblCreateCMF15;
        private System.Windows.Forms.Label lblCreateCMF14;
        private System.Windows.Forms.Label lblCreateCMF13;
        private System.Windows.Forms.Label lblCreateCMF11;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.Label lblCreateCMF2;
        private System.Windows.Forms.Label lblCreateCMF12;
        private System.Windows.Forms.TabPage tbpSublotInfo;
        private System.Windows.Forms.GroupBox grpSublotInfo;
        private System.Windows.Forms.Panel pnlSubMother;
        private System.Windows.Forms.Panel pnlSubChild;
        private System.Windows.Forms.Panel pnlSplitSublot;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnUnSplit;
        private System.Windows.Forms.GroupBox grpMotherSubLot;
        private System.Windows.Forms.GroupBox grpChildSubLot;
        private System.Windows.Forms.Panel pnlSubMotherTop;
        private System.Windows.Forms.Panel pnlSubChildTop;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblMotherQty;
        private System.Windows.Forms.TextBox txtMoveQty3;
        private System.Windows.Forms.TextBox txtMoveQty2;
        private System.Windows.Forms.TextBox txtMoveQty1;
        private System.Windows.Forms.Label lblMoveQty;
        private System.Windows.Forms.Panel pnlSubChildMid;
        private System.Windows.Forms.Panel pnlSubMotherMid;
        private Miracom.UI.Controls.MCListView.MCListView lisMother;
        private System.Windows.Forms.ColumnHeader colSlot;
        private System.Windows.Forms.ColumnHeader colSubLot;
        private System.Windows.Forms.Button btnCalculation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private System.Windows.Forms.Label lblCrrID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChildCrrID;
        private System.Windows.Forms.Label lblChildCrrID;
        private System.Windows.Forms.ColumnHeader colLotID;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        private CheckBox chkNoAutoTermLot;
        private ColumnHeader colGrade;
        private Miracom.UI.Controls.MCListView.MCListView lisChild;
        private ColumnHeader colChildSlot;
        private ColumnHeader colChildSubLot;
        private ColumnHeader colChildLot;
        private ColumnHeader colChildGrade;
        private ColumnHeader colFromSlot;
        private Label lblUnit3;
        private Label lblUnit2;
        private Label lblUnit1;
        private Label lblQty3;
        private Label lblQty2;
        private TextBox txtMQty3;
        private TextBox txtMQty2;
        private TextBox txtMQty1;
        private Label lblQty1;
        private Button btnGenerate;
        private ColumnHeader colToSlot;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpChildLot = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtChildLotDesc = new System.Windows.Forms.TextBox();
            this.lblChildLotDesc = new System.Windows.Forms.Label();
            this.txtChildLotID = new System.Windows.Forms.TextBox();
            this.lblChildLotID = new System.Windows.Forms.Label();
            this.pnlChildInfo = new System.Windows.Forms.Panel();
            this.grpChildLotInfo = new System.Windows.Forms.GroupBox();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.txtMQty3 = new System.Windows.Forms.TextBox();
            this.txtMQty2 = new System.Windows.Forms.TextBox();
            this.txtMQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.chkNoAutoTermLot = new System.Windows.Forms.CheckBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.cdvChildCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChildCrrID = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotType = new System.Windows.Forms.Label();
            this.tbpCreateCMF = new System.Windows.Forms.TabPage();
            this.pnlCreateCMF = new System.Windows.Forms.Panel();
            this.grpCreateCMF = new System.Windows.Forms.GroupBox();
            this.lblCreateCMF12 = new System.Windows.Forms.Label();
            this.lblCreateCMF2 = new System.Windows.Forms.Label();
            this.cdvCreateCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCMF20 = new System.Windows.Forms.Label();
            this.lblCreateCMF19 = new System.Windows.Forms.Label();
            this.lblCreateCMF18 = new System.Windows.Forms.Label();
            this.lblCreateCMF17 = new System.Windows.Forms.Label();
            this.lblCreateCMF16 = new System.Windows.Forms.Label();
            this.lblCreateCMF15 = new System.Windows.Forms.Label();
            this.lblCreateCMF14 = new System.Windows.Forms.Label();
            this.lblCreateCMF13 = new System.Windows.Forms.Label();
            this.lblCreateCMF11 = new System.Windows.Forms.Label();
            this.cdvCreateCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCMF10 = new System.Windows.Forms.Label();
            this.lblCreateCMF9 = new System.Windows.Forms.Label();
            this.lblCreateCMF8 = new System.Windows.Forms.Label();
            this.lblCreateCMF7 = new System.Windows.Forms.Label();
            this.lblCreateCMF6 = new System.Windows.Forms.Label();
            this.lblCreateCMF5 = new System.Windows.Forms.Label();
            this.lblCreateCMF4 = new System.Windows.Forms.Label();
            this.lblCreateCMF3 = new System.Windows.Forms.Label();
            this.lblCreateCMF1 = new System.Windows.Forms.Label();
            this.tbpSublotInfo = new System.Windows.Forms.TabPage();
            this.grpSublotInfo = new System.Windows.Forms.GroupBox();
            this.pnlSplitSublot = new System.Windows.Forms.Panel();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnUnSplit = new System.Windows.Forms.Button();
            this.pnlSubChild = new System.Windows.Forms.Panel();
            this.grpChildSubLot = new System.Windows.Forms.GroupBox();
            this.pnlSubChildMid = new System.Windows.Forms.Panel();
            this.lisChild = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChildSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChildSubLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChildLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChildGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSubChildTop = new System.Windows.Forms.Panel();
            this.txtMoveQty3 = new System.Windows.Forms.TextBox();
            this.txtMoveQty2 = new System.Windows.Forms.TextBox();
            this.txtMoveQty1 = new System.Windows.Forms.TextBox();
            this.lblMoveQty = new System.Windows.Forms.Label();
            this.pnlSubMother = new System.Windows.Forms.Panel();
            this.grpMotherSubLot = new System.Windows.Forms.GroupBox();
            this.pnlSubMotherMid = new System.Windows.Forms.Panel();
            this.lisMother = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSubMotherTop = new System.Windows.Forms.Panel();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblMotherQty = new System.Windows.Forms.Label();
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
            this.grpChildLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.pnlChildInfo.SuspendLayout();
            this.grpChildLotInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChildCrrID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            this.tbpCreateCMF.SuspendLayout();
            this.pnlCreateCMF.SuspendLayout();
            this.grpCreateCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).BeginInit();
            this.tbpSublotInfo.SuspendLayout();
            this.grpSublotInfo.SuspendLayout();
            this.pnlSplitSublot.SuspendLayout();
            this.pnlSubChild.SuspendLayout();
            this.grpChildSubLot.SuspendLayout();
            this.pnlSubChildMid.SuspendLayout();
            this.pnlSubChildTop.SuspendLayout();
            this.pnlSubMother.SuspendLayout();
            this.grpMotherSubLot.SuspendLayout();
            this.pnlSubMotherMid.SuspendLayout();
            this.pnlSubMotherTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlChildInfo);
            this.pnlTranInfo.Controls.Add(this.grpChildLot);
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
            // pnlComment
            // 
            this.pnlComment.TabIndex = 2;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(12, 14);
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
            this.tabTran.Controls.Add(this.tbpSublotInfo);
            this.tabTran.Controls.Add(this.tbpCreateCMF);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCreateCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpSublotInfo, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
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
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Split Extension";
            // 
            // grpChildLot
            // 
            this.grpChildLot.BackColor = System.Drawing.SystemColors.Control;
            this.grpChildLot.Controls.Add(this.btnGenerate);
            this.grpChildLot.Controls.Add(this.cdvCrrID);
            this.grpChildLot.Controls.Add(this.lblCrrID);
            this.grpChildLot.Controls.Add(this.txtChildLotDesc);
            this.grpChildLot.Controls.Add(this.lblChildLotDesc);
            this.grpChildLot.Controls.Add(this.txtChildLotID);
            this.grpChildLot.Controls.Add(this.lblChildLotID);
            this.grpChildLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChildLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildLot.Location = new System.Drawing.Point(0, 0);
            this.grpChildLot.Name = "grpChildLot";
            this.grpChildLot.Size = new System.Drawing.Size(722, 68);
            this.grpChildLot.TabIndex = 0;
            this.grpChildLot.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGenerate.Location = new System.Drawing.Point(322, 15);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(74, 22);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate ID";
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(526, 16);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(184, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 4;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 184;
            this.cdvCrrID.Visible = false;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvCrrID_TextBoxTextChanged);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.Location = new System.Drawing.Point(418, 19);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(87, 13);
            this.lblCrrID.TabIndex = 3;
            this.lblCrrID.Text = "Mother Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCrrID.Visible = false;
            // 
            // txtChildLotDesc
            // 
            this.txtChildLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChildLotDesc.Location = new System.Drawing.Point(118, 40);
            this.txtChildLotDesc.MaxLength = 200;
            this.txtChildLotDesc.Name = "txtChildLotDesc";
            this.txtChildLotDesc.Size = new System.Drawing.Size(592, 20);
            this.txtChildLotDesc.TabIndex = 6;
            // 
            // lblChildLotDesc
            // 
            this.lblChildLotDesc.AutoSize = true;
            this.lblChildLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChildLotDesc.Location = new System.Drawing.Point(12, 43);
            this.lblChildLotDesc.Name = "lblChildLotDesc";
            this.lblChildLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblChildLotDesc.TabIndex = 5;
            this.lblChildLotDesc.Text = "Description";
            this.lblChildLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChildLotID
            // 
            this.txtChildLotID.Location = new System.Drawing.Point(118, 16);
            this.txtChildLotID.MaxLength = 25;
            this.txtChildLotID.Name = "txtChildLotID";
            this.txtChildLotID.Size = new System.Drawing.Size(200, 20);
            this.txtChildLotID.TabIndex = 1;
            this.txtChildLotID.TextChanged += new System.EventHandler(this.txtChildLotID_TextChanged);
            this.txtChildLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChildLotID_KeyPress);
            // 
            // lblChildLotID
            // 
            this.lblChildLotID.AutoSize = true;
            this.lblChildLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChildLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildLotID.Location = new System.Drawing.Point(12, 19);
            this.lblChildLotID.Name = "lblChildLotID";
            this.lblChildLotID.Size = new System.Drawing.Size(74, 13);
            this.lblChildLotID.TabIndex = 0;
            this.lblChildLotID.Text = "Child Lot ID";
            this.lblChildLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlChildInfo
            // 
            this.pnlChildInfo.Controls.Add(this.grpChildLotInfo);
            this.pnlChildInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildInfo.Location = new System.Drawing.Point(0, 68);
            this.pnlChildInfo.Name = "pnlChildInfo";
            this.pnlChildInfo.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlChildInfo.Size = new System.Drawing.Size(722, 174);
            this.pnlChildInfo.TabIndex = 1;
            // 
            // grpChildLotInfo
            // 
            this.grpChildLotInfo.Controls.Add(this.lblUnit3);
            this.grpChildLotInfo.Controls.Add(this.lblUnit2);
            this.grpChildLotInfo.Controls.Add(this.lblUnit1);
            this.grpChildLotInfo.Controls.Add(this.lblQty3);
            this.grpChildLotInfo.Controls.Add(this.lblQty2);
            this.grpChildLotInfo.Controls.Add(this.txtMQty3);
            this.grpChildLotInfo.Controls.Add(this.txtMQty2);
            this.grpChildLotInfo.Controls.Add(this.txtMQty1);
            this.grpChildLotInfo.Controls.Add(this.lblQty1);
            this.grpChildLotInfo.Controls.Add(this.chkNoAutoTermLot);
            this.grpChildLotInfo.Controls.Add(this.cdvFlow);
            this.grpChildLotInfo.Controls.Add(this.cdvMatID);
            this.grpChildLotInfo.Controls.Add(this.btnCalculation);
            this.grpChildLotInfo.Controls.Add(this.cdvChildCrrID);
            this.grpChildLotInfo.Controls.Add(this.lblChildCrrID);
            this.grpChildLotInfo.Controls.Add(this.cdvOper);
            this.grpChildLotInfo.Controls.Add(this.lblOper);
            this.grpChildLotInfo.Controls.Add(this.txtDueDate);
            this.grpChildLotInfo.Controls.Add(this.chkDueDate);
            this.grpChildLotInfo.Controls.Add(this.cboPriority);
            this.grpChildLotInfo.Controls.Add(this.lblCreateCode);
            this.grpChildLotInfo.Controls.Add(this.dtpDueDate);
            this.grpChildLotInfo.Controls.Add(this.cdvOwnerCode);
            this.grpChildLotInfo.Controls.Add(this.cdvCreateCode);
            this.grpChildLotInfo.Controls.Add(this.lblPriority);
            this.grpChildLotInfo.Controls.Add(this.lblOwnerCode);
            this.grpChildLotInfo.Controls.Add(this.cdvLotType);
            this.grpChildLotInfo.Controls.Add(this.lblLotType);
            this.grpChildLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildLotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildLotInfo.Location = new System.Drawing.Point(0, 4);
            this.grpChildLotInfo.Name = "grpChildLotInfo";
            this.grpChildLotInfo.Size = new System.Drawing.Size(722, 170);
            this.grpChildLotInfo.TabIndex = 0;
            this.grpChildLotInfo.TabStop = false;
            this.grpChildLotInfo.Text = "Child Lot Infomation";
            // 
            // lblUnit3
            // 
            this.lblUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnit3.Location = new System.Drawing.Point(213, 140);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(105, 13);
            this.lblUnit3.TabIndex = 12;
            this.lblUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnit2
            // 
            this.lblUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnit2.Location = new System.Drawing.Point(213, 116);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(105, 13);
            this.lblUnit2.TabIndex = 9;
            this.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnit1
            // 
            this.lblUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnit1.Location = new System.Drawing.Point(213, 92);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(105, 13);
            this.lblUnit1.TabIndex = 6;
            this.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty3.Location = new System.Drawing.Point(12, 138);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(32, 13);
            this.lblQty3.TabIndex = 10;
            this.lblQty3.Text = "Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty2.Location = new System.Drawing.Point(12, 114);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(32, 13);
            this.lblQty2.TabIndex = 7;
            this.lblQty2.Text = "Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMQty3
            // 
            this.txtMQty3.Location = new System.Drawing.Point(118, 136);
            this.txtMQty3.MaxLength = 11;
            this.txtMQty3.Name = "txtMQty3";
            this.txtMQty3.ReadOnly = true;
            this.txtMQty3.Size = new System.Drawing.Size(88, 20);
            this.txtMQty3.TabIndex = 11;
            // 
            // txtMQty2
            // 
            this.txtMQty2.Location = new System.Drawing.Point(118, 112);
            this.txtMQty2.MaxLength = 11;
            this.txtMQty2.Name = "txtMQty2";
            this.txtMQty2.ReadOnly = true;
            this.txtMQty2.Size = new System.Drawing.Size(88, 20);
            this.txtMQty2.TabIndex = 8;
            // 
            // txtMQty1
            // 
            this.txtMQty1.Location = new System.Drawing.Point(118, 88);
            this.txtMQty1.MaxLength = 11;
            this.txtMQty1.Name = "txtMQty1";
            this.txtMQty1.ReadOnly = true;
            this.txtMQty1.Size = new System.Drawing.Size(88, 20);
            this.txtMQty1.TabIndex = 5;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 90);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(37, 13);
            this.lblQty1.TabIndex = 4;
            this.lblQty1.Text = "Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNoAutoTermLot
            // 
            this.chkNoAutoTermLot.AutoSize = true;
            this.chkNoAutoTermLot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoAutoTermLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoAutoTermLot.Location = new System.Drawing.Point(352, 135);
            this.chkNoAutoTermLot.Name = "chkNoAutoTermLot";
            this.chkNoAutoTermLot.Size = new System.Drawing.Size(200, 18);
            this.chkNoAutoTermLot.TabIndex = 26;
            this.chkNoAutoTermLot.Text = "No Automatic Terminate Mother Lot";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 106;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 40);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_TextBoxTextChanged);
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(12, 16);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(306, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 106;
            this.cdvMatID.WidthMaterialAndVersion = 200;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.VersionChanged += new System.EventHandler(this.cdvMatID_TextBoxTextChanged);
            // 
            // btnCalculation
            // 
            this.btnCalculation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculation.Location = new System.Drawing.Point(584, 86);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(74, 22);
            this.btnCalculation.TabIndex = 23;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // cdvChildCrrID
            // 
            this.cdvChildCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChildCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChildCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChildCrrID.BtnToolTipText = "";
            this.cdvChildCrrID.DescText = "";
            this.cdvChildCrrID.DisplaySubItemIndex = -1;
            this.cdvChildCrrID.DisplayText = "";
            this.cdvChildCrrID.Focusing = null;
            this.cdvChildCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChildCrrID.Index = 0;
            this.cdvChildCrrID.IsViewBtnImage = false;
            this.cdvChildCrrID.Location = new System.Drawing.Point(458, 112);
            this.cdvChildCrrID.MaxLength = 20;
            this.cdvChildCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChildCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChildCrrID.Name = "cdvChildCrrID";
            this.cdvChildCrrID.ReadOnly = false;
            this.cdvChildCrrID.SearchSubItemIndex = 0;
            this.cdvChildCrrID.SelectedDescIndex = -1;
            this.cdvChildCrrID.SelectedSubItemIndex = -1;
            this.cdvChildCrrID.SelectionStart = 0;
            this.cdvChildCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvChildCrrID.SmallImageList = null;
            this.cdvChildCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChildCrrID.TabIndex = 25;
            this.cdvChildCrrID.TextBoxToolTipText = "";
            this.cdvChildCrrID.TextBoxWidth = 200;
            this.cdvChildCrrID.Visible = false;
            this.cdvChildCrrID.VisibleButton = true;
            this.cdvChildCrrID.VisibleColumnHeader = false;
            this.cdvChildCrrID.VisibleDescription = false;
            this.cdvChildCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChildCrrID_SelectedItemChanged);
            this.cdvChildCrrID.ButtonPress += new System.EventHandler(this.cdvChildCrrID_ButtonPress);
            this.cdvChildCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvChildCrrID_TextBoxTextChanged);
            // 
            // lblChildCrrID
            // 
            this.lblChildCrrID.AutoSize = true;
            this.lblChildCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChildCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildCrrID.Location = new System.Drawing.Point(352, 115);
            this.lblChildCrrID.Name = "lblChildCrrID";
            this.lblChildCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblChildCrrID.TabIndex = 24;
            this.lblChildCrrID.Text = "Carrier ID";
            this.lblChildCrrID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChildCrrID.Visible = false;
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(118, 64);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOper.Location = new System.Drawing.Point(12, 68);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            this.lblOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(458, 88);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(124, 20);
            this.txtDueDate.TabIndex = 22;
            this.txtDueDate.TabStop = false;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDueDate.Location = new System.Drawing.Point(352, 91);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(86, 18);
            this.chkDueDate.TabIndex = 21;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
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
            this.cboPriority.Location = new System.Drawing.Point(613, 62);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(45, 21);
            this.cboPriority.TabIndex = 20;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(352, 20);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 13;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(458, 88);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDueDate.TabIndex = 21;
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
            this.cdvOwnerCode.Location = new System.Drawing.Point(458, 40);
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
            this.cdvOwnerCode.TabIndex = 16;
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
            this.cdvCreateCode.Location = new System.Drawing.Point(458, 16);
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
            this.cdvCreateCode.TabIndex = 14;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 200;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblPriority
            // 
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(544, 67);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(64, 13);
            this.lblPriority.TabIndex = 19;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(352, 44);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 15;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(458, 64);
            this.cdvLotType.MaxLength = 1;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(80, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 18;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 80;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            this.cdvLotType.ButtonPress += new System.EventHandler(this.cdvLotType_ButtonPress);
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(352, 68);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 17;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreateCMF
            // 
            this.tbpCreateCMF.Controls.Add(this.pnlCreateCMF);
            this.tbpCreateCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateCMF.Name = "tbpCreateCMF";
            this.tbpCreateCMF.Size = new System.Drawing.Size(728, 422);
            this.tbpCreateCMF.TabIndex = 2;
            this.tbpCreateCMF.Text = "Create Customized Field";
            // 
            // pnlCreateCMF
            // 
            this.pnlCreateCMF.Controls.Add(this.grpCreateCMF);
            this.pnlCreateCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCreateCMF.Location = new System.Drawing.Point(0, 0);
            this.pnlCreateCMF.Name = "pnlCreateCMF";
            this.pnlCreateCMF.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCreateCMF.Size = new System.Drawing.Size(728, 422);
            this.pnlCreateCMF.TabIndex = 0;
            // 
            // grpCreateCMF
            // 
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF12);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF19);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF18);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF17);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF16);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF15);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF14);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF13);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF12);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF20);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF11);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF20);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF19);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF18);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF17);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF16);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF15);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF14);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF13);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF11);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF1);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF1);
            this.grpCreateCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCreateCMF.Name = "grpCreateCMF";
            this.grpCreateCMF.Size = new System.Drawing.Size(722, 416);
            this.grpCreateCMF.TabIndex = 0;
            this.grpCreateCMF.TabStop = false;
            // 
            // lblCreateCMF12
            // 
            this.lblCreateCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF12.Location = new System.Drawing.Point(373, 43);
            this.lblCreateCMF12.Name = "lblCreateCMF12";
            this.lblCreateCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF12.TabIndex = 22;
            this.lblCreateCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF2
            // 
            this.lblCreateCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF2.Location = new System.Drawing.Point(23, 43);
            this.lblCreateCMF2.Name = "lblCreateCMF2";
            this.lblCreateCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF2.TabIndex = 2;
            this.lblCreateCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCreateCMF19
            // 
            this.cdvCreateCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF19.BtnToolTipText = "";
            this.cdvCreateCMF19.DescText = "";
            this.cdvCreateCMF19.DisplaySubItemIndex = -1;
            this.cdvCreateCMF19.DisplayText = "";
            this.cdvCreateCMF19.Focusing = null;
            this.cdvCreateCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF19.Index = 0;
            this.cdvCreateCMF19.IsViewBtnImage = false;
            this.cdvCreateCMF19.Location = new System.Drawing.Point(520, 208);
            this.cdvCreateCMF19.MaxLength = 30;
            this.cdvCreateCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF19.Name = "cdvCreateCMF19";
            this.cdvCreateCMF19.ReadOnly = false;
            this.cdvCreateCMF19.SearchSubItemIndex = 0;
            this.cdvCreateCMF19.SelectedDescIndex = -1;
            this.cdvCreateCMF19.SelectedSubItemIndex = -1;
            this.cdvCreateCMF19.SelectionStart = 0;
            this.cdvCreateCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF19.SmallImageList = null;
            this.cdvCreateCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF19.TabIndex = 37;
            this.cdvCreateCMF19.TextBoxToolTipText = "";
            this.cdvCreateCMF19.TextBoxWidth = 180;
            this.cdvCreateCMF19.VisibleButton = true;
            this.cdvCreateCMF19.VisibleColumnHeader = false;
            this.cdvCreateCMF19.VisibleDescription = false;
            this.cdvCreateCMF19.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF18
            // 
            this.cdvCreateCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF18.BtnToolTipText = "";
            this.cdvCreateCMF18.DescText = "";
            this.cdvCreateCMF18.DisplaySubItemIndex = -1;
            this.cdvCreateCMF18.DisplayText = "";
            this.cdvCreateCMF18.Focusing = null;
            this.cdvCreateCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF18.Index = 0;
            this.cdvCreateCMF18.IsViewBtnImage = false;
            this.cdvCreateCMF18.Location = new System.Drawing.Point(520, 184);
            this.cdvCreateCMF18.MaxLength = 30;
            this.cdvCreateCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF18.Name = "cdvCreateCMF18";
            this.cdvCreateCMF18.ReadOnly = false;
            this.cdvCreateCMF18.SearchSubItemIndex = 0;
            this.cdvCreateCMF18.SelectedDescIndex = -1;
            this.cdvCreateCMF18.SelectedSubItemIndex = -1;
            this.cdvCreateCMF18.SelectionStart = 0;
            this.cdvCreateCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF18.SmallImageList = null;
            this.cdvCreateCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF18.TabIndex = 35;
            this.cdvCreateCMF18.TextBoxToolTipText = "";
            this.cdvCreateCMF18.TextBoxWidth = 180;
            this.cdvCreateCMF18.VisibleButton = true;
            this.cdvCreateCMF18.VisibleColumnHeader = false;
            this.cdvCreateCMF18.VisibleDescription = false;
            this.cdvCreateCMF18.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF17
            // 
            this.cdvCreateCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF17.BtnToolTipText = "";
            this.cdvCreateCMF17.DescText = "";
            this.cdvCreateCMF17.DisplaySubItemIndex = -1;
            this.cdvCreateCMF17.DisplayText = "";
            this.cdvCreateCMF17.Focusing = null;
            this.cdvCreateCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF17.Index = 0;
            this.cdvCreateCMF17.IsViewBtnImage = false;
            this.cdvCreateCMF17.Location = new System.Drawing.Point(520, 160);
            this.cdvCreateCMF17.MaxLength = 30;
            this.cdvCreateCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF17.Name = "cdvCreateCMF17";
            this.cdvCreateCMF17.ReadOnly = false;
            this.cdvCreateCMF17.SearchSubItemIndex = 0;
            this.cdvCreateCMF17.SelectedDescIndex = -1;
            this.cdvCreateCMF17.SelectedSubItemIndex = -1;
            this.cdvCreateCMF17.SelectionStart = 0;
            this.cdvCreateCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF17.SmallImageList = null;
            this.cdvCreateCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF17.TabIndex = 33;
            this.cdvCreateCMF17.TextBoxToolTipText = "";
            this.cdvCreateCMF17.TextBoxWidth = 180;
            this.cdvCreateCMF17.VisibleButton = true;
            this.cdvCreateCMF17.VisibleColumnHeader = false;
            this.cdvCreateCMF17.VisibleDescription = false;
            this.cdvCreateCMF17.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF16
            // 
            this.cdvCreateCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF16.BtnToolTipText = "";
            this.cdvCreateCMF16.DescText = "";
            this.cdvCreateCMF16.DisplaySubItemIndex = -1;
            this.cdvCreateCMF16.DisplayText = "";
            this.cdvCreateCMF16.Focusing = null;
            this.cdvCreateCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF16.Index = 0;
            this.cdvCreateCMF16.IsViewBtnImage = false;
            this.cdvCreateCMF16.Location = new System.Drawing.Point(520, 136);
            this.cdvCreateCMF16.MaxLength = 30;
            this.cdvCreateCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF16.Name = "cdvCreateCMF16";
            this.cdvCreateCMF16.ReadOnly = false;
            this.cdvCreateCMF16.SearchSubItemIndex = 0;
            this.cdvCreateCMF16.SelectedDescIndex = -1;
            this.cdvCreateCMF16.SelectedSubItemIndex = -1;
            this.cdvCreateCMF16.SelectionStart = 0;
            this.cdvCreateCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF16.SmallImageList = null;
            this.cdvCreateCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF16.TabIndex = 31;
            this.cdvCreateCMF16.TextBoxToolTipText = "";
            this.cdvCreateCMF16.TextBoxWidth = 180;
            this.cdvCreateCMF16.VisibleButton = true;
            this.cdvCreateCMF16.VisibleColumnHeader = false;
            this.cdvCreateCMF16.VisibleDescription = false;
            this.cdvCreateCMF16.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF15
            // 
            this.cdvCreateCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF15.BtnToolTipText = "";
            this.cdvCreateCMF15.DescText = "";
            this.cdvCreateCMF15.DisplaySubItemIndex = -1;
            this.cdvCreateCMF15.DisplayText = "";
            this.cdvCreateCMF15.Focusing = null;
            this.cdvCreateCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF15.Index = 0;
            this.cdvCreateCMF15.IsViewBtnImage = false;
            this.cdvCreateCMF15.Location = new System.Drawing.Point(520, 112);
            this.cdvCreateCMF15.MaxLength = 30;
            this.cdvCreateCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF15.Name = "cdvCreateCMF15";
            this.cdvCreateCMF15.ReadOnly = false;
            this.cdvCreateCMF15.SearchSubItemIndex = 0;
            this.cdvCreateCMF15.SelectedDescIndex = -1;
            this.cdvCreateCMF15.SelectedSubItemIndex = -1;
            this.cdvCreateCMF15.SelectionStart = 0;
            this.cdvCreateCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF15.SmallImageList = null;
            this.cdvCreateCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF15.TabIndex = 29;
            this.cdvCreateCMF15.TextBoxToolTipText = "";
            this.cdvCreateCMF15.TextBoxWidth = 180;
            this.cdvCreateCMF15.VisibleButton = true;
            this.cdvCreateCMF15.VisibleColumnHeader = false;
            this.cdvCreateCMF15.VisibleDescription = false;
            this.cdvCreateCMF15.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF14
            // 
            this.cdvCreateCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF14.BtnToolTipText = "";
            this.cdvCreateCMF14.DescText = "";
            this.cdvCreateCMF14.DisplaySubItemIndex = -1;
            this.cdvCreateCMF14.DisplayText = "";
            this.cdvCreateCMF14.Focusing = null;
            this.cdvCreateCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF14.Index = 0;
            this.cdvCreateCMF14.IsViewBtnImage = false;
            this.cdvCreateCMF14.Location = new System.Drawing.Point(520, 88);
            this.cdvCreateCMF14.MaxLength = 30;
            this.cdvCreateCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF14.Name = "cdvCreateCMF14";
            this.cdvCreateCMF14.ReadOnly = false;
            this.cdvCreateCMF14.SearchSubItemIndex = 0;
            this.cdvCreateCMF14.SelectedDescIndex = -1;
            this.cdvCreateCMF14.SelectedSubItemIndex = -1;
            this.cdvCreateCMF14.SelectionStart = 0;
            this.cdvCreateCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF14.SmallImageList = null;
            this.cdvCreateCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF14.TabIndex = 27;
            this.cdvCreateCMF14.TextBoxToolTipText = "";
            this.cdvCreateCMF14.TextBoxWidth = 180;
            this.cdvCreateCMF14.VisibleButton = true;
            this.cdvCreateCMF14.VisibleColumnHeader = false;
            this.cdvCreateCMF14.VisibleDescription = false;
            this.cdvCreateCMF14.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF13
            // 
            this.cdvCreateCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF13.BtnToolTipText = "";
            this.cdvCreateCMF13.DescText = "";
            this.cdvCreateCMF13.DisplaySubItemIndex = -1;
            this.cdvCreateCMF13.DisplayText = "";
            this.cdvCreateCMF13.Focusing = null;
            this.cdvCreateCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF13.Index = 0;
            this.cdvCreateCMF13.IsViewBtnImage = false;
            this.cdvCreateCMF13.Location = new System.Drawing.Point(520, 64);
            this.cdvCreateCMF13.MaxLength = 30;
            this.cdvCreateCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF13.Name = "cdvCreateCMF13";
            this.cdvCreateCMF13.ReadOnly = false;
            this.cdvCreateCMF13.SearchSubItemIndex = 0;
            this.cdvCreateCMF13.SelectedDescIndex = -1;
            this.cdvCreateCMF13.SelectedSubItemIndex = -1;
            this.cdvCreateCMF13.SelectionStart = 0;
            this.cdvCreateCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF13.SmallImageList = null;
            this.cdvCreateCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF13.TabIndex = 25;
            this.cdvCreateCMF13.TextBoxToolTipText = "";
            this.cdvCreateCMF13.TextBoxWidth = 180;
            this.cdvCreateCMF13.VisibleButton = true;
            this.cdvCreateCMF13.VisibleColumnHeader = false;
            this.cdvCreateCMF13.VisibleDescription = false;
            this.cdvCreateCMF13.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF12
            // 
            this.cdvCreateCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF12.BtnToolTipText = "";
            this.cdvCreateCMF12.DescText = "";
            this.cdvCreateCMF12.DisplaySubItemIndex = -1;
            this.cdvCreateCMF12.DisplayText = "";
            this.cdvCreateCMF12.Focusing = null;
            this.cdvCreateCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF12.Index = 0;
            this.cdvCreateCMF12.IsViewBtnImage = false;
            this.cdvCreateCMF12.Location = new System.Drawing.Point(520, 40);
            this.cdvCreateCMF12.MaxLength = 30;
            this.cdvCreateCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF12.Name = "cdvCreateCMF12";
            this.cdvCreateCMF12.ReadOnly = false;
            this.cdvCreateCMF12.SearchSubItemIndex = 0;
            this.cdvCreateCMF12.SelectedDescIndex = -1;
            this.cdvCreateCMF12.SelectedSubItemIndex = -1;
            this.cdvCreateCMF12.SelectionStart = 0;
            this.cdvCreateCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF12.SmallImageList = null;
            this.cdvCreateCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF12.TabIndex = 23;
            this.cdvCreateCMF12.TextBoxToolTipText = "";
            this.cdvCreateCMF12.TextBoxWidth = 180;
            this.cdvCreateCMF12.VisibleButton = true;
            this.cdvCreateCMF12.VisibleColumnHeader = false;
            this.cdvCreateCMF12.VisibleDescription = false;
            this.cdvCreateCMF12.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF20
            // 
            this.cdvCreateCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF20.BtnToolTipText = "";
            this.cdvCreateCMF20.DescText = "";
            this.cdvCreateCMF20.DisplaySubItemIndex = -1;
            this.cdvCreateCMF20.DisplayText = "";
            this.cdvCreateCMF20.Focusing = null;
            this.cdvCreateCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF20.Index = 0;
            this.cdvCreateCMF20.IsViewBtnImage = false;
            this.cdvCreateCMF20.Location = new System.Drawing.Point(520, 232);
            this.cdvCreateCMF20.MaxLength = 30;
            this.cdvCreateCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF20.Name = "cdvCreateCMF20";
            this.cdvCreateCMF20.ReadOnly = false;
            this.cdvCreateCMF20.SearchSubItemIndex = 0;
            this.cdvCreateCMF20.SelectedDescIndex = -1;
            this.cdvCreateCMF20.SelectedSubItemIndex = -1;
            this.cdvCreateCMF20.SelectionStart = 0;
            this.cdvCreateCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF20.SmallImageList = null;
            this.cdvCreateCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF20.TabIndex = 39;
            this.cdvCreateCMF20.TextBoxToolTipText = "";
            this.cdvCreateCMF20.TextBoxWidth = 180;
            this.cdvCreateCMF20.VisibleButton = true;
            this.cdvCreateCMF20.VisibleColumnHeader = false;
            this.cdvCreateCMF20.VisibleDescription = false;
            this.cdvCreateCMF20.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF11
            // 
            this.cdvCreateCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF11.BtnToolTipText = "";
            this.cdvCreateCMF11.DescText = "";
            this.cdvCreateCMF11.DisplaySubItemIndex = -1;
            this.cdvCreateCMF11.DisplayText = "";
            this.cdvCreateCMF11.Focusing = null;
            this.cdvCreateCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF11.Index = 0;
            this.cdvCreateCMF11.IsViewBtnImage = false;
            this.cdvCreateCMF11.Location = new System.Drawing.Point(520, 16);
            this.cdvCreateCMF11.MaxLength = 30;
            this.cdvCreateCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF11.Name = "cdvCreateCMF11";
            this.cdvCreateCMF11.ReadOnly = false;
            this.cdvCreateCMF11.SearchSubItemIndex = 0;
            this.cdvCreateCMF11.SelectedDescIndex = -1;
            this.cdvCreateCMF11.SelectedSubItemIndex = -1;
            this.cdvCreateCMF11.SelectionStart = 0;
            this.cdvCreateCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF11.SmallImageList = null;
            this.cdvCreateCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF11.TabIndex = 21;
            this.cdvCreateCMF11.TextBoxToolTipText = "";
            this.cdvCreateCMF11.TextBoxWidth = 180;
            this.cdvCreateCMF11.VisibleButton = true;
            this.cdvCreateCMF11.VisibleColumnHeader = false;
            this.cdvCreateCMF11.VisibleDescription = false;
            this.cdvCreateCMF11.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // lblCreateCMF20
            // 
            this.lblCreateCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF20.Location = new System.Drawing.Point(373, 234);
            this.lblCreateCMF20.Name = "lblCreateCMF20";
            this.lblCreateCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF20.TabIndex = 38;
            this.lblCreateCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF19
            // 
            this.lblCreateCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF19.Location = new System.Drawing.Point(373, 210);
            this.lblCreateCMF19.Name = "lblCreateCMF19";
            this.lblCreateCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF19.TabIndex = 36;
            this.lblCreateCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF18
            // 
            this.lblCreateCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF18.Location = new System.Drawing.Point(373, 186);
            this.lblCreateCMF18.Name = "lblCreateCMF18";
            this.lblCreateCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF18.TabIndex = 34;
            this.lblCreateCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF17
            // 
            this.lblCreateCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF17.Location = new System.Drawing.Point(373, 162);
            this.lblCreateCMF17.Name = "lblCreateCMF17";
            this.lblCreateCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF17.TabIndex = 32;
            this.lblCreateCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF16
            // 
            this.lblCreateCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF16.Location = new System.Drawing.Point(373, 138);
            this.lblCreateCMF16.Name = "lblCreateCMF16";
            this.lblCreateCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF16.TabIndex = 30;
            this.lblCreateCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF15
            // 
            this.lblCreateCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF15.Location = new System.Drawing.Point(373, 114);
            this.lblCreateCMF15.Name = "lblCreateCMF15";
            this.lblCreateCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF15.TabIndex = 28;
            this.lblCreateCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF14
            // 
            this.lblCreateCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF14.Location = new System.Drawing.Point(373, 90);
            this.lblCreateCMF14.Name = "lblCreateCMF14";
            this.lblCreateCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF14.TabIndex = 26;
            this.lblCreateCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF13
            // 
            this.lblCreateCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF13.Location = new System.Drawing.Point(373, 66);
            this.lblCreateCMF13.Name = "lblCreateCMF13";
            this.lblCreateCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF13.TabIndex = 24;
            this.lblCreateCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF11
            // 
            this.lblCreateCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF11.Location = new System.Drawing.Point(373, 20);
            this.lblCreateCMF11.Name = "lblCreateCMF11";
            this.lblCreateCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF11.TabIndex = 20;
            this.lblCreateCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCreateCMF9
            // 
            this.cdvCreateCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF9.BtnToolTipText = "";
            this.cdvCreateCMF9.DescText = "";
            this.cdvCreateCMF9.DisplaySubItemIndex = -1;
            this.cdvCreateCMF9.DisplayText = "";
            this.cdvCreateCMF9.Focusing = null;
            this.cdvCreateCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF9.Index = 0;
            this.cdvCreateCMF9.IsViewBtnImage = false;
            this.cdvCreateCMF9.Location = new System.Drawing.Point(170, 208);
            this.cdvCreateCMF9.MaxLength = 30;
            this.cdvCreateCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.Name = "cdvCreateCMF9";
            this.cdvCreateCMF9.ReadOnly = false;
            this.cdvCreateCMF9.SearchSubItemIndex = 0;
            this.cdvCreateCMF9.SelectedDescIndex = -1;
            this.cdvCreateCMF9.SelectedSubItemIndex = -1;
            this.cdvCreateCMF9.SelectionStart = 0;
            this.cdvCreateCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF9.SmallImageList = null;
            this.cdvCreateCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF9.TabIndex = 17;
            this.cdvCreateCMF9.TextBoxToolTipText = "";
            this.cdvCreateCMF9.TextBoxWidth = 180;
            this.cdvCreateCMF9.VisibleButton = true;
            this.cdvCreateCMF9.VisibleColumnHeader = false;
            this.cdvCreateCMF9.VisibleDescription = false;
            this.cdvCreateCMF9.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF8
            // 
            this.cdvCreateCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF8.BtnToolTipText = "";
            this.cdvCreateCMF8.DescText = "";
            this.cdvCreateCMF8.DisplaySubItemIndex = -1;
            this.cdvCreateCMF8.DisplayText = "";
            this.cdvCreateCMF8.Focusing = null;
            this.cdvCreateCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF8.Index = 0;
            this.cdvCreateCMF8.IsViewBtnImage = false;
            this.cdvCreateCMF8.Location = new System.Drawing.Point(170, 184);
            this.cdvCreateCMF8.MaxLength = 30;
            this.cdvCreateCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.Name = "cdvCreateCMF8";
            this.cdvCreateCMF8.ReadOnly = false;
            this.cdvCreateCMF8.SearchSubItemIndex = 0;
            this.cdvCreateCMF8.SelectedDescIndex = -1;
            this.cdvCreateCMF8.SelectedSubItemIndex = -1;
            this.cdvCreateCMF8.SelectionStart = 0;
            this.cdvCreateCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF8.SmallImageList = null;
            this.cdvCreateCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF8.TabIndex = 15;
            this.cdvCreateCMF8.TextBoxToolTipText = "";
            this.cdvCreateCMF8.TextBoxWidth = 180;
            this.cdvCreateCMF8.VisibleButton = true;
            this.cdvCreateCMF8.VisibleColumnHeader = false;
            this.cdvCreateCMF8.VisibleDescription = false;
            this.cdvCreateCMF8.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF7
            // 
            this.cdvCreateCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF7.BtnToolTipText = "";
            this.cdvCreateCMF7.DescText = "";
            this.cdvCreateCMF7.DisplaySubItemIndex = -1;
            this.cdvCreateCMF7.DisplayText = "";
            this.cdvCreateCMF7.Focusing = null;
            this.cdvCreateCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF7.Index = 0;
            this.cdvCreateCMF7.IsViewBtnImage = false;
            this.cdvCreateCMF7.Location = new System.Drawing.Point(170, 160);
            this.cdvCreateCMF7.MaxLength = 30;
            this.cdvCreateCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.Name = "cdvCreateCMF7";
            this.cdvCreateCMF7.ReadOnly = false;
            this.cdvCreateCMF7.SearchSubItemIndex = 0;
            this.cdvCreateCMF7.SelectedDescIndex = -1;
            this.cdvCreateCMF7.SelectedSubItemIndex = -1;
            this.cdvCreateCMF7.SelectionStart = 0;
            this.cdvCreateCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF7.SmallImageList = null;
            this.cdvCreateCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF7.TabIndex = 13;
            this.cdvCreateCMF7.TextBoxToolTipText = "";
            this.cdvCreateCMF7.TextBoxWidth = 180;
            this.cdvCreateCMF7.VisibleButton = true;
            this.cdvCreateCMF7.VisibleColumnHeader = false;
            this.cdvCreateCMF7.VisibleDescription = false;
            this.cdvCreateCMF7.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF6
            // 
            this.cdvCreateCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF6.BtnToolTipText = "";
            this.cdvCreateCMF6.DescText = "";
            this.cdvCreateCMF6.DisplaySubItemIndex = -1;
            this.cdvCreateCMF6.DisplayText = "";
            this.cdvCreateCMF6.Focusing = null;
            this.cdvCreateCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF6.Index = 0;
            this.cdvCreateCMF6.IsViewBtnImage = false;
            this.cdvCreateCMF6.Location = new System.Drawing.Point(170, 136);
            this.cdvCreateCMF6.MaxLength = 30;
            this.cdvCreateCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.Name = "cdvCreateCMF6";
            this.cdvCreateCMF6.ReadOnly = false;
            this.cdvCreateCMF6.SearchSubItemIndex = 0;
            this.cdvCreateCMF6.SelectedDescIndex = -1;
            this.cdvCreateCMF6.SelectedSubItemIndex = -1;
            this.cdvCreateCMF6.SelectionStart = 0;
            this.cdvCreateCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF6.SmallImageList = null;
            this.cdvCreateCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF6.TabIndex = 11;
            this.cdvCreateCMF6.TextBoxToolTipText = "";
            this.cdvCreateCMF6.TextBoxWidth = 180;
            this.cdvCreateCMF6.VisibleButton = true;
            this.cdvCreateCMF6.VisibleColumnHeader = false;
            this.cdvCreateCMF6.VisibleDescription = false;
            this.cdvCreateCMF6.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF5
            // 
            this.cdvCreateCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF5.BtnToolTipText = "";
            this.cdvCreateCMF5.DescText = "";
            this.cdvCreateCMF5.DisplaySubItemIndex = -1;
            this.cdvCreateCMF5.DisplayText = "";
            this.cdvCreateCMF5.Focusing = null;
            this.cdvCreateCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF5.Index = 0;
            this.cdvCreateCMF5.IsViewBtnImage = false;
            this.cdvCreateCMF5.Location = new System.Drawing.Point(170, 112);
            this.cdvCreateCMF5.MaxLength = 30;
            this.cdvCreateCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.Name = "cdvCreateCMF5";
            this.cdvCreateCMF5.ReadOnly = false;
            this.cdvCreateCMF5.SearchSubItemIndex = 0;
            this.cdvCreateCMF5.SelectedDescIndex = -1;
            this.cdvCreateCMF5.SelectedSubItemIndex = -1;
            this.cdvCreateCMF5.SelectionStart = 0;
            this.cdvCreateCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF5.SmallImageList = null;
            this.cdvCreateCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF5.TabIndex = 9;
            this.cdvCreateCMF5.TextBoxToolTipText = "";
            this.cdvCreateCMF5.TextBoxWidth = 180;
            this.cdvCreateCMF5.VisibleButton = true;
            this.cdvCreateCMF5.VisibleColumnHeader = false;
            this.cdvCreateCMF5.VisibleDescription = false;
            this.cdvCreateCMF5.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF4
            // 
            this.cdvCreateCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF4.BtnToolTipText = "";
            this.cdvCreateCMF4.DescText = "";
            this.cdvCreateCMF4.DisplaySubItemIndex = -1;
            this.cdvCreateCMF4.DisplayText = "";
            this.cdvCreateCMF4.Focusing = null;
            this.cdvCreateCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF4.Index = 0;
            this.cdvCreateCMF4.IsViewBtnImage = false;
            this.cdvCreateCMF4.Location = new System.Drawing.Point(170, 88);
            this.cdvCreateCMF4.MaxLength = 30;
            this.cdvCreateCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.Name = "cdvCreateCMF4";
            this.cdvCreateCMF4.ReadOnly = false;
            this.cdvCreateCMF4.SearchSubItemIndex = 0;
            this.cdvCreateCMF4.SelectedDescIndex = -1;
            this.cdvCreateCMF4.SelectedSubItemIndex = -1;
            this.cdvCreateCMF4.SelectionStart = 0;
            this.cdvCreateCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF4.SmallImageList = null;
            this.cdvCreateCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF4.TabIndex = 7;
            this.cdvCreateCMF4.TextBoxToolTipText = "";
            this.cdvCreateCMF4.TextBoxWidth = 180;
            this.cdvCreateCMF4.VisibleButton = true;
            this.cdvCreateCMF4.VisibleColumnHeader = false;
            this.cdvCreateCMF4.VisibleDescription = false;
            this.cdvCreateCMF4.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF3
            // 
            this.cdvCreateCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF3.BtnToolTipText = "";
            this.cdvCreateCMF3.DescText = "";
            this.cdvCreateCMF3.DisplaySubItemIndex = -1;
            this.cdvCreateCMF3.DisplayText = "";
            this.cdvCreateCMF3.Focusing = null;
            this.cdvCreateCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF3.Index = 0;
            this.cdvCreateCMF3.IsViewBtnImage = false;
            this.cdvCreateCMF3.Location = new System.Drawing.Point(170, 64);
            this.cdvCreateCMF3.MaxLength = 30;
            this.cdvCreateCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.Name = "cdvCreateCMF3";
            this.cdvCreateCMF3.ReadOnly = false;
            this.cdvCreateCMF3.SearchSubItemIndex = 0;
            this.cdvCreateCMF3.SelectedDescIndex = -1;
            this.cdvCreateCMF3.SelectedSubItemIndex = -1;
            this.cdvCreateCMF3.SelectionStart = 0;
            this.cdvCreateCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF3.SmallImageList = null;
            this.cdvCreateCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF3.TabIndex = 5;
            this.cdvCreateCMF3.TextBoxToolTipText = "";
            this.cdvCreateCMF3.TextBoxWidth = 180;
            this.cdvCreateCMF3.VisibleButton = true;
            this.cdvCreateCMF3.VisibleColumnHeader = false;
            this.cdvCreateCMF3.VisibleDescription = false;
            this.cdvCreateCMF3.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF2
            // 
            this.cdvCreateCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF2.BtnToolTipText = "";
            this.cdvCreateCMF2.DescText = "";
            this.cdvCreateCMF2.DisplaySubItemIndex = -1;
            this.cdvCreateCMF2.DisplayText = "";
            this.cdvCreateCMF2.Focusing = null;
            this.cdvCreateCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF2.Index = 0;
            this.cdvCreateCMF2.IsViewBtnImage = false;
            this.cdvCreateCMF2.Location = new System.Drawing.Point(170, 40);
            this.cdvCreateCMF2.MaxLength = 30;
            this.cdvCreateCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.Name = "cdvCreateCMF2";
            this.cdvCreateCMF2.ReadOnly = false;
            this.cdvCreateCMF2.SearchSubItemIndex = 0;
            this.cdvCreateCMF2.SelectedDescIndex = -1;
            this.cdvCreateCMF2.SelectedSubItemIndex = -1;
            this.cdvCreateCMF2.SelectionStart = 0;
            this.cdvCreateCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF2.SmallImageList = null;
            this.cdvCreateCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF2.TabIndex = 3;
            this.cdvCreateCMF2.TextBoxToolTipText = "";
            this.cdvCreateCMF2.TextBoxWidth = 180;
            this.cdvCreateCMF2.VisibleButton = true;
            this.cdvCreateCMF2.VisibleColumnHeader = false;
            this.cdvCreateCMF2.VisibleDescription = false;
            this.cdvCreateCMF2.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF10
            // 
            this.cdvCreateCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF10.BtnToolTipText = "";
            this.cdvCreateCMF10.DescText = "";
            this.cdvCreateCMF10.DisplaySubItemIndex = -1;
            this.cdvCreateCMF10.DisplayText = "";
            this.cdvCreateCMF10.Focusing = null;
            this.cdvCreateCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF10.Index = 0;
            this.cdvCreateCMF10.IsViewBtnImage = false;
            this.cdvCreateCMF10.Location = new System.Drawing.Point(170, 232);
            this.cdvCreateCMF10.MaxLength = 30;
            this.cdvCreateCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.Name = "cdvCreateCMF10";
            this.cdvCreateCMF10.ReadOnly = false;
            this.cdvCreateCMF10.SearchSubItemIndex = 0;
            this.cdvCreateCMF10.SelectedDescIndex = -1;
            this.cdvCreateCMF10.SelectedSubItemIndex = -1;
            this.cdvCreateCMF10.SelectionStart = 0;
            this.cdvCreateCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF10.SmallImageList = null;
            this.cdvCreateCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF10.TabIndex = 19;
            this.cdvCreateCMF10.TextBoxToolTipText = "";
            this.cdvCreateCMF10.TextBoxWidth = 180;
            this.cdvCreateCMF10.VisibleButton = true;
            this.cdvCreateCMF10.VisibleColumnHeader = false;
            this.cdvCreateCMF10.VisibleDescription = false;
            this.cdvCreateCMF10.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF1
            // 
            this.cdvCreateCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF1.BtnToolTipText = "";
            this.cdvCreateCMF1.DescText = "";
            this.cdvCreateCMF1.DisplaySubItemIndex = -1;
            this.cdvCreateCMF1.DisplayText = "";
            this.cdvCreateCMF1.Focusing = null;
            this.cdvCreateCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF1.Index = 0;
            this.cdvCreateCMF1.IsViewBtnImage = false;
            this.cdvCreateCMF1.Location = new System.Drawing.Point(170, 16);
            this.cdvCreateCMF1.MaxLength = 30;
            this.cdvCreateCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.Name = "cdvCreateCMF1";
            this.cdvCreateCMF1.ReadOnly = false;
            this.cdvCreateCMF1.SearchSubItemIndex = 0;
            this.cdvCreateCMF1.SelectedDescIndex = -1;
            this.cdvCreateCMF1.SelectedSubItemIndex = -1;
            this.cdvCreateCMF1.SelectionStart = 0;
            this.cdvCreateCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF1.SmallImageList = null;
            this.cdvCreateCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF1.TabIndex = 1;
            this.cdvCreateCMF1.TextBoxToolTipText = "";
            this.cdvCreateCMF1.TextBoxWidth = 180;
            this.cdvCreateCMF1.VisibleButton = true;
            this.cdvCreateCMF1.VisibleColumnHeader = false;
            this.cdvCreateCMF1.VisibleDescription = false;
            this.cdvCreateCMF1.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // lblCreateCMF10
            // 
            this.lblCreateCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF10.Location = new System.Drawing.Point(23, 235);
            this.lblCreateCMF10.Name = "lblCreateCMF10";
            this.lblCreateCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF10.TabIndex = 18;
            this.lblCreateCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF9
            // 
            this.lblCreateCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF9.Location = new System.Drawing.Point(23, 211);
            this.lblCreateCMF9.Name = "lblCreateCMF9";
            this.lblCreateCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF9.TabIndex = 16;
            this.lblCreateCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF8
            // 
            this.lblCreateCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF8.Location = new System.Drawing.Point(23, 187);
            this.lblCreateCMF8.Name = "lblCreateCMF8";
            this.lblCreateCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF8.TabIndex = 14;
            this.lblCreateCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF7
            // 
            this.lblCreateCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF7.Location = new System.Drawing.Point(23, 163);
            this.lblCreateCMF7.Name = "lblCreateCMF7";
            this.lblCreateCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF7.TabIndex = 12;
            this.lblCreateCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF6
            // 
            this.lblCreateCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF6.Location = new System.Drawing.Point(23, 139);
            this.lblCreateCMF6.Name = "lblCreateCMF6";
            this.lblCreateCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF6.TabIndex = 10;
            this.lblCreateCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF5
            // 
            this.lblCreateCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF5.Location = new System.Drawing.Point(23, 115);
            this.lblCreateCMF5.Name = "lblCreateCMF5";
            this.lblCreateCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF5.TabIndex = 8;
            this.lblCreateCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF4
            // 
            this.lblCreateCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF4.Location = new System.Drawing.Point(23, 91);
            this.lblCreateCMF4.Name = "lblCreateCMF4";
            this.lblCreateCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF4.TabIndex = 6;
            this.lblCreateCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF3
            // 
            this.lblCreateCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF3.Location = new System.Drawing.Point(23, 67);
            this.lblCreateCMF3.Name = "lblCreateCMF3";
            this.lblCreateCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF3.TabIndex = 4;
            this.lblCreateCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF1
            // 
            this.lblCreateCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF1.Location = new System.Drawing.Point(23, 20);
            this.lblCreateCMF1.Name = "lblCreateCMF1";
            this.lblCreateCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF1.TabIndex = 0;
            this.lblCreateCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpSublotInfo
            // 
            this.tbpSublotInfo.Controls.Add(this.grpSublotInfo);
            this.tbpSublotInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpSublotInfo.Name = "tbpSublotInfo";
            this.tbpSublotInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSublotInfo.Size = new System.Drawing.Size(728, 422);
            this.tbpSublotInfo.TabIndex = 3;
            this.tbpSublotInfo.Text = "Sub Lot Information";
            // 
            // grpSublotInfo
            // 
            this.grpSublotInfo.Controls.Add(this.pnlSplitSublot);
            this.grpSublotInfo.Controls.Add(this.pnlSubChild);
            this.grpSublotInfo.Controls.Add(this.pnlSubMother);
            this.grpSublotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSublotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSublotInfo.Location = new System.Drawing.Point(3, 3);
            this.grpSublotInfo.Name = "grpSublotInfo";
            this.grpSublotInfo.Size = new System.Drawing.Size(722, 416);
            this.grpSublotInfo.TabIndex = 0;
            this.grpSublotInfo.TabStop = false;
            this.grpSublotInfo.Resize += new System.EventHandler(this.grpSublotInfo_Resize);
            // 
            // pnlSplitSublot
            // 
            this.pnlSplitSublot.Controls.Add(this.btnSplit);
            this.pnlSplitSublot.Controls.Add(this.btnUnSplit);
            this.pnlSplitSublot.Location = new System.Drawing.Point(338, 93);
            this.pnlSplitSublot.Name = "pnlSplitSublot";
            this.pnlSplitSublot.Size = new System.Drawing.Size(46, 230);
            this.pnlSplitSublot.TabIndex = 7;
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplit.Location = new System.Drawing.Point(11, 89);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(24, 24);
            this.btnSplit.TabIndex = 0;
            this.btnSplit.Text = ">";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnUnSplit
            // 
            this.btnUnSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnSplit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnSplit.Location = new System.Drawing.Point(11, 118);
            this.btnUnSplit.Name = "btnUnSplit";
            this.btnUnSplit.Size = new System.Drawing.Size(24, 24);
            this.btnUnSplit.TabIndex = 1;
            this.btnUnSplit.Text = "<";
            this.btnUnSplit.Click += new System.EventHandler(this.btnUnSplit_Click);
            // 
            // pnlSubChild
            // 
            this.pnlSubChild.Controls.Add(this.grpChildSubLot);
            this.pnlSubChild.Location = new System.Drawing.Point(390, 20);
            this.pnlSubChild.Name = "pnlSubChild";
            this.pnlSubChild.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChild.Size = new System.Drawing.Size(328, 388);
            this.pnlSubChild.TabIndex = 1;
            // 
            // grpChildSubLot
            // 
            this.grpChildSubLot.Controls.Add(this.pnlSubChildMid);
            this.grpChildSubLot.Controls.Add(this.pnlSubChildTop);
            this.grpChildSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildSubLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildSubLot.Location = new System.Drawing.Point(3, 3);
            this.grpChildSubLot.Name = "grpChildSubLot";
            this.grpChildSubLot.Size = new System.Drawing.Size(322, 382);
            this.grpChildSubLot.TabIndex = 0;
            this.grpChildSubLot.TabStop = false;
            this.grpChildSubLot.Text = "Child Lot";
            // 
            // pnlSubChildMid
            // 
            this.pnlSubChildMid.Controls.Add(this.lisChild);
            this.pnlSubChildMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubChildMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubChildMid.Name = "pnlSubChildMid";
            this.pnlSubChildMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChildMid.Size = new System.Drawing.Size(316, 333);
            this.pnlSubChildMid.TabIndex = 1;
            // 
            // lisChild
            // 
            this.lisChild.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChildSlot,
            this.colChildSubLot,
            this.colChildLot,
            this.colChildGrade,
            this.colFromSlot});
            this.lisChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChild.EnableSort = true;
            this.lisChild.EnableSortIcon = true;
            this.lisChild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChild.FullRowSelect = true;
            this.lisChild.Location = new System.Drawing.Point(3, 3);
            this.lisChild.Name = "lisChild";
            this.lisChild.Size = new System.Drawing.Size(310, 327);
            this.lisChild.TabIndex = 2;
            this.lisChild.UseCompatibleStateImageBehavior = false;
            this.lisChild.View = System.Windows.Forms.View.Details;
            // 
            // colChildSlot
            // 
            this.colChildSlot.Text = "Slot No";
            this.colChildSlot.Width = 47;
            // 
            // colChildSubLot
            // 
            this.colChildSubLot.Text = "Sub Lot ID";
            this.colChildSubLot.Width = 90;
            // 
            // colChildLot
            // 
            this.colChildLot.Text = "Lot ID";
            this.colChildLot.Width = 90;
            // 
            // colChildGrade
            // 
            this.colChildGrade.Text = "G";
            this.colChildGrade.Width = 23;
            // 
            // colFromSlot
            // 
            this.colFromSlot.Text = "From Slot No";
            // 
            // pnlSubChildTop
            // 
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty3);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty2);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty1);
            this.pnlSubChildTop.Controls.Add(this.lblMoveQty);
            this.pnlSubChildTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubChildTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubChildTop.Name = "pnlSubChildTop";
            this.pnlSubChildTop.Size = new System.Drawing.Size(316, 30);
            this.pnlSubChildTop.TabIndex = 0;
            // 
            // txtMoveQty3
            // 
            this.txtMoveQty3.Location = new System.Drawing.Point(242, 2);
            this.txtMoveQty3.MaxLength = 11;
            this.txtMoveQty3.Name = "txtMoveQty3";
            this.txtMoveQty3.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty3.TabIndex = 3;
            // 
            // txtMoveQty2
            // 
            this.txtMoveQty2.Location = new System.Drawing.Point(172, 2);
            this.txtMoveQty2.MaxLength = 11;
            this.txtMoveQty2.Name = "txtMoveQty2";
            this.txtMoveQty2.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty2.TabIndex = 2;
            // 
            // txtMoveQty1
            // 
            this.txtMoveQty1.Location = new System.Drawing.Point(102, 2);
            this.txtMoveQty1.MaxLength = 11;
            this.txtMoveQty1.Name = "txtMoveQty1";
            this.txtMoveQty1.ReadOnly = true;
            this.txtMoveQty1.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty1.TabIndex = 1;
            this.txtMoveQty1.TabStop = false;
            // 
            // lblMoveQty
            // 
            this.lblMoveQty.AutoSize = true;
            this.lblMoveQty.Location = new System.Drawing.Point(6, 4);
            this.lblMoveQty.Name = "lblMoveQty";
            this.lblMoveQty.Size = new System.Drawing.Size(84, 13);
            this.lblMoveQty.TabIndex = 0;
            this.lblMoveQty.Text = "Move Qty 1/2/3";
            // 
            // pnlSubMother
            // 
            this.pnlSubMother.Controls.Add(this.grpMotherSubLot);
            this.pnlSubMother.Location = new System.Drawing.Point(8, 20);
            this.pnlSubMother.Name = "pnlSubMother";
            this.pnlSubMother.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMother.Size = new System.Drawing.Size(326, 388);
            this.pnlSubMother.TabIndex = 0;
            // 
            // grpMotherSubLot
            // 
            this.grpMotherSubLot.Controls.Add(this.pnlSubMotherMid);
            this.grpMotherSubLot.Controls.Add(this.pnlSubMotherTop);
            this.grpMotherSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotherSubLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMotherSubLot.Location = new System.Drawing.Point(3, 3);
            this.grpMotherSubLot.Name = "grpMotherSubLot";
            this.grpMotherSubLot.Size = new System.Drawing.Size(320, 382);
            this.grpMotherSubLot.TabIndex = 0;
            this.grpMotherSubLot.TabStop = false;
            this.grpMotherSubLot.Text = "Mother Lot";
            // 
            // pnlSubMotherMid
            // 
            this.pnlSubMotherMid.Controls.Add(this.lisMother);
            this.pnlSubMotherMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMotherMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubMotherMid.Name = "pnlSubMotherMid";
            this.pnlSubMotherMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMotherMid.Size = new System.Drawing.Size(314, 333);
            this.pnlSubMotherMid.TabIndex = 1;
            // 
            // lisMother
            // 
            this.lisMother.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot,
            this.colSubLot,
            this.colLotID,
            this.colGrade,
            this.colToSlot});
            this.lisMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMother.EnableSort = true;
            this.lisMother.EnableSortIcon = true;
            this.lisMother.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMother.FullRowSelect = true;
            this.lisMother.Location = new System.Drawing.Point(3, 3);
            this.lisMother.Name = "lisMother";
            this.lisMother.Size = new System.Drawing.Size(308, 327);
            this.lisMother.TabIndex = 1;
            this.lisMother.UseCompatibleStateImageBehavior = false;
            this.lisMother.View = System.Windows.Forms.View.Details;
            // 
            // colSlot
            // 
            this.colSlot.Text = "Slot No";
            this.colSlot.Width = 47;
            // 
            // colSubLot
            // 
            this.colSubLot.Text = "Sub Lot ID";
            this.colSubLot.Width = 90;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 90;
            // 
            // colGrade
            // 
            this.colGrade.Text = "G";
            this.colGrade.Width = 23;
            // 
            // colToSlot
            // 
            this.colToSlot.Text = "To Slot No";
            // 
            // pnlSubMotherTop
            // 
            this.pnlSubMotherTop.Controls.Add(this.txtQty3);
            this.pnlSubMotherTop.Controls.Add(this.txtQty2);
            this.pnlSubMotherTop.Controls.Add(this.txtQty1);
            this.pnlSubMotherTop.Controls.Add(this.lblMotherQty);
            this.pnlSubMotherTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMotherTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubMotherTop.Name = "pnlSubMotherTop";
            this.pnlSubMotherTop.Size = new System.Drawing.Size(314, 30);
            this.pnlSubMotherTop.TabIndex = 0;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(240, 2);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(68, 20);
            this.txtQty3.TabIndex = 3;
            this.txtQty3.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(170, 2);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(68, 20);
            this.txtQty2.TabIndex = 2;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 2);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(68, 20);
            this.txtQty1.TabIndex = 1;
            this.txtQty1.TabStop = false;
            // 
            // lblMotherQty
            // 
            this.lblMotherQty.AutoSize = true;
            this.lblMotherQty.Location = new System.Drawing.Point(6, 4);
            this.lblMotherQty.Name = "lblMotherQty";
            this.lblMotherQty.Size = new System.Drawing.Size(54, 13);
            this.lblMotherQty.TabIndex = 0;
            this.lblMotherQty.Text = "Qty 1/2/3";
            // 
            // frmWIPTranSplitLotExt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranSplitLotExt";
            this.Text = "Split Extension";
            this.Activated += new System.EventHandler(this.frmWIPTranSplitLotExt_Activated);
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
            this.grpChildLot.ResumeLayout(false);
            this.grpChildLot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.pnlChildInfo.ResumeLayout(false);
            this.grpChildLotInfo.ResumeLayout(false);
            this.grpChildLotInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChildCrrID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            this.tbpCreateCMF.ResumeLayout(false);
            this.pnlCreateCMF.ResumeLayout(false);
            this.grpCreateCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).EndInit();
            this.tbpSublotInfo.ResumeLayout(false);
            this.grpSublotInfo.ResumeLayout(false);
            this.pnlSplitSublot.ResumeLayout(false);
            this.pnlSubChild.ResumeLayout(false);
            this.grpChildSubLot.ResumeLayout(false);
            this.pnlSubChildMid.ResumeLayout(false);
            this.pnlSubChildTop.ResumeLayout(false);
            this.pnlSubChildTop.PerformLayout();
            this.pnlSubMother.ResumeLayout(false);
            this.grpMotherSubLot.ResumeLayout(false);
            this.pnlSubMotherMid.ResumeLayout(false);
            this.pnlSubMotherTop.ResumeLayout(false);
            this.pnlSubMotherTop.PerformLayout();
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
            MPCF.FieldClear(this, txtLotID, cboPriority);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */
            SetLotCMFInfo();
            /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */

            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (View_Operation(LOT.GetString("OPER")) == false)
            {
                return false;
            }


#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false)
            {
                return false;
            }

            cdvChildCrrID.Init();
            MPCF.InitListView(cdvChildCrrID.GetListView);
#endif

            if (cdvCrrID.Items.Count < 1)
            {
                if (WIPLIST.ViewSublotList(lisMother, '1', txtLotID.Text, null) == false)
                {
                    return false;
                }
            }
            else if (cdvCrrID.Items.Count == 1)
            {
                cdvCrrID.Text = cdvCrrID.Items[0].Text;
                cdvCrrID_SelectedItemChanged(null, null);
            }
            else
            {
                lisMother.Items.Clear();
            }

            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");

            txtMoveQty1.Text = "0";
            txtMoveQty2.Text = "0";
            txtMoveQty3.Text = "0";

            cdvMatID.Text = LOT.GetString("MAT_ID");
            cdvMatID.Version = LOT.GetInt("MAT_VER");
            cdvFlow.Text = LOT.GetString("FLOW");
            cdvFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
            cdvOper.Text = LOT.GetString("OPER");

            cdvCreateCode.Text = LOT.GetString("CREATE_CODE");
            cdvOwnerCode.Text = LOT.GetString("OWNER_CODE");
            cdvLotType.Text = LOT.GetChar("LOT_TYPE").ToString();
            chkDueDate.Checked = true;


            // 2006.05.24. CM Koo.
            // GetSPDueDate ê°€ "" ??ê²½ìš°??ì²˜ë¦¬ ì¶”ê?
            if (MPCF.Trim(LOT.GetString("SCH_DUE_TIME")) == "")
            {
                this.dtpDueDate.Value = DateTime.Today;
            }
            else
            {
                this.dtpDueDate.Value = MPCF.ToDate(LOT.GetString("SCH_DUE_TIME"));
            }

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            MakeEmptySlot(lisChild);
            txtChildLotID_TextChanged(null, null);

            return true;
        }
        
                
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                switch (ProcStep)
                {
                    case "1":
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        ClearLotSpread();
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = !chkDueDate.Checked;
                        
                        MPCF.InitListView(lisMother);
                        MPCF.InitListView(lisChild);
                        
                        txtQty1.Text = "0";
                        txtQty2.Text = "0";
                        txtQty3.Text = "0";
                        
                        txtMoveQty1.Text = "0";
                        txtMoveQty2.Text = "0";
                        txtMoveQty3.Text = "0";

                        txtMQty1.Text = "0";
                        txtMQty2.Text = "0";
                        txtMQty3.Text = "0";
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
        private bool CheckCondition(string FuncName, char c_step)
        {
            string sQtyChk = "";

            switch (MPCF.Trim(FuncName))
            {
                case "SPLIT_LOT_EXT":

                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    //{
                    //    tabTran.SelectedTab = tbpGeneral;
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                    //    txtLotID.Focus();
                    //    return false;
                    //}
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (c_step == '1')
                    {
                        if (MPCF.CheckValue(txtChildLotID, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtChildLotID.Focus();
                            return false;
                        }
                    }
                    if (cdvMatID.CheckValue() == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvMatID.Focus();
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


                    if (MPCF.Trim(txtMQty1.Tag) != "")
                    {
                        if (txtMQty1.Text == "" || MPCF.ToDbl(txtMQty1.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                sQtyChk = "Qty1";
                            }
                        }
                    }
                    if (MPCF.Trim(txtMQty2.Tag) != "")
                    {
                        if (txtMQty2.Text == "" || MPCF.ToDbl(txtMQty2.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty2";
                            }
                        }
                    }
                    if (MPCF.Trim(txtMQty3.Tag) != "")
                    {
                        if (txtMQty3.Text == "" || MPCF.ToDbl(txtMQty3.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty3";
                            }
                        }
                    }
                    
                    if (sQtyChk != "")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(190), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            switch (sQtyChk)
                            {
                                case "Qty1":
                                    txtQty1.Focus();
                                    break;

                                case "Qty2":
                                    txtQty2.Focus();
                                    break;

                                case "Qty3":
                                    txtQty3.Focus();
                                    break;

                                default:
                                    break;
                            }

                            return false;
                        }
                    }

                    if (txtMQty1.Text != "" && txtMQty1.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_1") < MPCF.ToDbl(txtMQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty1.Text = "0";
                            txtMQty1.Focus();
                            return false;
                        }
                    }
                    if (txtMQty2.Text != "" && txtMQty2.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_2") < MPCF.ToDbl(txtMQty2.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty2.Text = "0";
                            txtMQty2.Focus();
                            return false;
                        }
                    }
                    if (txtMQty3.Text != "" && txtMQty3.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_3") < MPCF.ToDbl(txtMQty3.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty3.Text = "0";
                            txtMQty3.Focus();
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
                            if (txtDueDate.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtDueDate.Focus();
                                return false;
                            }
                        }
                    }
                    if (MPCF.CheckValue(cdvLotType, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvLotType.Focus();
                        return false;
                    }
                                        
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCreateCMF", "cdvCreateCMF", grpCreateCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCMF;
                        return false;
                    }
                    break;
                    
            }
            
            return true;            
        }


        /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */
        private bool SetLotCMFInfo()
        {
            try
            {
                cdvCreateCMF1.Text = LOT.GetString("LOT_CMF_1");
                cdvCreateCMF2.Text = LOT.GetString("LOT_CMF_2");
                cdvCreateCMF3.Text = LOT.GetString("LOT_CMF_3");
                cdvCreateCMF4.Text = LOT.GetString("LOT_CMF_4");
                cdvCreateCMF5.Text = LOT.GetString("LOT_CMF_5");
                cdvCreateCMF6.Text = LOT.GetString("LOT_CMF_6");
                cdvCreateCMF7.Text = LOT.GetString("LOT_CMF_7");
                cdvCreateCMF8.Text = LOT.GetString("LOT_CMF_8");
                cdvCreateCMF9.Text = LOT.GetString("LOT_CMF_9");
                cdvCreateCMF10.Text = LOT.GetString("LOT_CMF_10");
                cdvCreateCMF11.Text = LOT.GetString("LOT_CMF_11");
                cdvCreateCMF12.Text = LOT.GetString("LOT_CMF_12");
                cdvCreateCMF13.Text = LOT.GetString("LOT_CMF_13");
                cdvCreateCMF14.Text = LOT.GetString("LOT_CMF_14");
                cdvCreateCMF15.Text = LOT.GetString("LOT_CMF_15");
                cdvCreateCMF16.Text = LOT.GetString("LOT_CMF_16");
                cdvCreateCMF17.Text = LOT.GetString("LOT_CMF_17");
                cdvCreateCMF18.Text = LOT.GetString("LOT_CMF_18");
                cdvCreateCMF19.Text = LOT.GetString("LOT_CMF_19");
                cdvCreateCMF20.Text = LOT.GetString("LOT_CMF_20");
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // GetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetOperationList(string sFlow)
        {
            
            try
            {
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0,sFlow, "", null, "") == false)
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // View_Lot()
        //       - View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Lot(string sLotID)
        {

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }
            else
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(164));
            }

            lisChild.Items.Clear();

            return false;

        }

        //
        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Material(string sMatID, int iMatVer)
        {

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvFlow.Text = MPCF.Trim(out_node.GetString("FIRST_FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvOper.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }

        //
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
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvOper.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }

        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation(string sOper)
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(sOper));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            txtMQty1.Tag = out_node.GetString("UNIT_1");
            txtMQty2.Tag = out_node.GetString("UNIT_2");
            txtMQty3.Tag = out_node.GetString("UNIT_3");

            if (LOT.GetInt("SUBLOT_COUNT") < 1)
            {
                if (out_node.GetString("UNIT_1") != "")
                {
                    txtMQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                    txtMQty1.ReadOnly = false;
                    lblUnit1.Text = out_node.GetString("UNIT_1");
                }
                else
                {
                    txtMQty1.ReadOnly = true;
                    lblUnit1.Text = "";
                }
                if (out_node.GetString("UNIT_2") != "")
                {
                    txtMQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                    txtMQty2.ReadOnly = false;
                    lblUnit2.Text = out_node.GetString("UNIT_2");
                }
                else
                {
                    txtMQty2.ReadOnly = true;
                    lblUnit2.Text = "";
                }
                if (out_node.GetString("UNIT_3") != "")
                {
                    txtMQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                    txtMQty3.ReadOnly = false;
                    lblUnit3.Text = out_node.GetString("UNIT_3");
                }
                else
                {
                    txtMQty3.ReadOnly = true;
                    lblUnit3.Text = "";
                }
            }
            else
            {
                txtMQty1.ReadOnly = true;
                txtMQty2.ReadOnly = true;
                txtMQty3.ReadOnly = true;

                lblUnit1.Text = "";
                lblUnit2.Text = "";
                lblUnit3.Text = "";
            }


            if (out_node.GetString("UNIT_2") != "")
            {
                txtMoveQty2.ReadOnly = false;
            }
            else
            {
                txtMoveQty2.ReadOnly = true;
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                txtMoveQty3.ReadOnly = false;
            }
            else
            {
                txtMoveQty3.ReadOnly = true;
            }

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

            if (cdvMatID.CheckValue() == false)
            {
                return false;
            }
            //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            //{
            //    tabTran.SelectedTab = tbpGeneral;
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
            //    txtLotID.Focus();
            //}
            //if (MPCF.Trim(LOT.GetString("OPER")) == "")
            //{
            //    tabTran.SelectedTab = tbpGeneral;
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
            //    txtLotID.Focus();
            //}
            
            if (txtQty1.Text == "")
            {
                dQty1 = 0;
            }
            else
            {
                dQty1 = MPCF.ToDbl(txtQty1.Text);
            }

            if (MPCR.GetProcTime(cdvMatID.Text, cdvMatID.Version, LOT.GetString("FLOW"), LOT.GetInt("FLOW_SEQ_NUM"), LOT.GetString("OPER"), dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }
            
            //2006.04.25. CM Koo. CycleTime Unit???°ë¼ ?”í•˜???œê°„ ?¨ìœ„ë¥??¬ë¦¬ ?ìš©
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
        
        //
        // Split_Lot()
        //       - Split Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Split_Lot_Ext(char ProcStep)
        {

            TRSNode in_node = new TRSNode("SPLIT_LOT_EXT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;

            try
            {
                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_SPLIT,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "",
                                                "",
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                in_node.AddString("CHILD_CRR_ID", MPCF.Trim(cdvChildCrrID.Text));

                in_node.AddString("LOT_TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("LOT_TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("LOT_TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("LOT_TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("LOT_TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("LOT_TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("LOT_TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("LOT_TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("LOT_TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("LOT_TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCreateCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCreateCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCreateCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCreateCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCreateCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCreateCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCreateCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCreateCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCreateCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCreateCMF10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCreateCMF11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCreateCMF12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCreateCMF13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCreateCMF14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCreateCMF15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCreateCMF16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCreateCMF17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCreateCMF18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCreateCMF19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCreateCMF20.Text));

                in_node.AddString("CHILD_LOT_ID", MPCF.Trim(txtChildLotID.Text));
                in_node.AddString("CHILD_LOT_DESC", MPCF.Trim(txtChildLotDesc.Text));
                in_node.AddString("CHILD_MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("CHILD_MAT_VER", cdvMatID.Version);
                in_node.AddString("CHILD_FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("CHILD_FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("CHILD_OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("CHILD_CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("CHILD_OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("CHILD_LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                in_node.AddChar("CHILD_PRIORITY", MPCF.ToChar(cboPriority.Text));

                SetSplitSublot(ref in_node);

                /* 2007.12.6. Aiden */
                /* for able zero lot qty split */
                //if (Split_Lot_Ext_In._C.sublot_count < 1)
                //{
                //    return false;
                //}

                if (txtMQty1.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(txtMQty1.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_1", 0);
                }
                if (txtMQty2.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_2", MPCF.ToDbl(txtMQty2.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_2", 0);
                }
                if (txtMQty3.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_3", MPCF.ToDbl(txtMQty3.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_3", 0);
                }


                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("CHILD_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Split_Lot_Ext", in_node, ref out_node) == false)
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

        
        private void SetSplitSublot(ref TRSNode sp_in)
        {
            int i;
            int iCnt;
            TRSNode sublot_item;
            
            iCnt = MPCF.ToInt(txtMoveQty1.Text);
            if (iCnt < 1)
            {
                return;
            }
            
            iCnt = 0;
            for (i = 0; i <= lisChild.Items.Count - 1; i++)
            {
                if (lisChild.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL)
                {
                    sublot_item = sp_in.AddNode("SUBLOT");

                    sublot_item.AddInt("CHILD_SLOT_NO", MPCF.ToInt(lisChild.Items[i].Text));
                    sublot_item.AddString("SUBLOT_ID", lisChild.Items[i].SubItems[1].Text);
                }
            }
            
        }
        
        private void MakeEmptySlot(ListView lisList)
        {
            int i;
            int i_max_slot_count;
            ListViewItem itmx;
            
            lisList.Items.Clear();
            i_max_slot_count = MPGO.MaxSubLotSlotCount();

            for (i = 1; i <= i_max_slot_count; i++)
            {
                itmx = new ListViewItem(i.ToString(), (int)SMALLICON_INDEX.IDX_SLOT_EMPTY);
                itmx.SubItems.Add("");
                itmx.SubItems.Add("");
                itmx.SubItems.Add("");
                itmx.SubItems.Add("");
                
                lisList.Items.Add(itmx);
            }
            
        }

        private bool Generate_ID()
        {

            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", cdvMatID.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SPLIT");
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtChildLotID.Text = MPCF.Trim(out_node.GetString("GEN_ID"));
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion
        
        private void frmWIPTranSplitLotExt_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

                    #if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
                    lblChildCrrID.Visible = true;
                    cdvChildCrrID.Visible = true;
                    #endif
                    
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_SPLIT);
                    MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCreateCMF", "cdvCreateCMF", grpCreateCMF);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCreateCMF_ButtonPress(object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCreateCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void cdvMatID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvFlow.Text = "";
            cdvOper.Text = "";

            if (View_Material(cdvMatID.Text, cdvMatID.Version) == false)
            {
                return;
            }
            
        }
        
        private void cdvMatID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMatID.CheckValue() == false) return;
        
            cdvFlow.ListCond_MatID = cdvMatID.Text;
            cdvFlow.ListCond_MatVersion = cdvMatID.Version;

        }
        
        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (View_Flow() == false)
            {
                return;
            }
            
        }
        
        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
        }
        
        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMatID.CheckValue() == false)
            {
                return;
            }
            if (cdvFlow.CheckValue() == false)
            {
                return;
            }
            
            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //Add by J.S. 2009.02.18 unit2°¡ ÀÖ´Â °æ¿ì¿¡ ´ëÇÑ Ã³¸® ÇÊ¿ä
                txtMQty1.Text = txtMoveQty1.Text;
                txtMQty2.Text = txtMoveQty2.Text;
                txtMQty3.Text = txtMoveQty3.Text;

                if (CheckCondition("SPLIT_LOT_EXT", '1') == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SPLIT, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
                if (Split_Lot_Ext('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SPLIT, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtDueDate.Visible = ! chkDueDate.Checked;
            
        }
        
        private void btnSplit_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int iCnt = 0;
            int Index = 0;
            
            try
            {
                
                if (lisMother.Items.Count < 1)
                {
                    return;
                }
                if (lisChild.Items.Count < 1)
                {
                    return;
                }
                
                if (lisMother.SelectedItems.Count < 1)
                {
                    return;
                }
                
                if (lisChild.SelectedItems.Count < 1)
                {
                    Index = 0;
                }
                else
                {
                    Index = lisChild.SelectedItems[0].Index;
                }
                
                for (i = 0; i < lisMother.SelectedItems.Count; i++)
                {
                    if (lisMother.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL && 
                        lisMother.SelectedItems[i].SubItems[2].Text == MPCF.Trim(txtLotID.Text))
                    {
                        if (lisChild.Items[Index].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY)
                        {
                            break;
                        }

                        if (MPCF.ToDbl(txtQty1.Text) < 0.0005)
                        {
                            break;
                        }

                        txtMoveQty1.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty1.Text) + 1);
                        txtQty1.Text = Convert.ToString(MPCF.ToDbl(txtQty1.Text) - 1);
                        if (MPCF.ToDbl(txtQty2.Text) > 0.0005)
                        {
                            txtMoveQty2.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty2.Text) + MPCF.ToDbl(lisMother.SelectedItems[i].Tag));
                            txtQty2.Text = Convert.ToString(MPCF.ToDbl(txtQty2.Text) - MPCF.ToDbl(lisMother.SelectedItems[i].Tag));
                        }
                        
                        lisChild.Items[Index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                        lisChild.Items[Index].SubItems[1].Text = lisMother.SelectedItems[i].SubItems[1].Text;
                        lisChild.Items[Index].SubItems[2].Text = MPCF.Trim(txtChildLotID.Text);
                        lisChild.Items[Index].SubItems[3].Text = lisMother.SelectedItems[i].SubItems[3].Text;
                        lisChild.Items[Index].SubItems[4].Text = lisMother.SelectedItems[i].Text;
                        
                        lisChild.Items[Index].Selected = true;
                        lisChild.Items[Index].EnsureVisible();
                        lisMother.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                        lisMother.SelectedItems[i].SubItems[4].Text = Convert.ToString(Index + 1);
                        Index++;

                        //Modify by J.S. 2009.03.04 bug fix <=   ->   <
                        if (Index < lisChild.Items.Count)
                        {
                            //    lisTarget.ListItems(Index).Selected = True
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
                txtMoveQty1.Text = MPCF.ToInt(MPCF.ToDbl(txtMoveQty1.Text) + iCnt).ToString();
                txtMQty1.Text = txtMoveQty1.Text;
                txtMQty2.Text = txtMoveQty2.Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnUnSplit_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int iCnt = 0;
            int Index = 0;
            
            try
            {
                if (lisMother.Items.Count < 1)
                {
                    return;
                }
                if (lisChild.Items.Count < 1)
                {
                    return;
                }
                
                if (lisChild.SelectedItems.Count < 1)
                {
                    return;
                }
                
                for (i = 0; i <= lisChild.SelectedItems.Count - 1; i++)
                {
                    if (lisChild.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL && lisChild.SelectedItems[i].SubItems[2].Text == MPCF.Trim(txtChildLotID.Text))
                    {
                        //Modify by J.S. 2009.03.04 slot_no°¡ Áßº¹µÇ´Â case Áö¿ø
                        Index = MPCF.FindListItemIndex(lisMother, lisChild.SelectedItems[i].SubItems[1].Text, 1, false);
                        //Index = MPCF.ToInt(lisChild.SelectedItems[i].SubItems[4].Text) - 1;
                        if (lisMother.Items[Index].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_EMPTY)
                        {
                            break;
                        }
                        else
                        {
                            if (MPCF.ToDbl(txtMoveQty1.Text) < 0.0005)
                            {
                                break;
                            }

                            txtMoveQty1.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty1.Text) - 1);
                            txtQty1.Text = Convert.ToString(MPCF.ToDbl(txtQty1.Text) + 1);
                            if (MPCF.ToDbl(txtQty2.Text) > 0.0005)
                            {
                                txtMoveQty2.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty2.Text) - MPCF.ToDbl(lisMother.Items[Index].Tag));
                                txtQty2.Text = Convert.ToString(MPCF.ToDbl(txtQty2.Text) + MPCF.ToDbl(lisMother.Items[Index].Tag));
                            }

                            lisMother.Items[Index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                            lisMother.Items[Index].SubItems[4].Text = "";
                            lisMother.Items[Index].Selected = true;
                            lisMother.Items[Index].EnsureVisible();
                            lisChild.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisChild.SelectedItems[i].SubItems[1].Text = "";
                            lisChild.SelectedItems[i].SubItems[2].Text = "";
                            lisChild.SelectedItems[i].SubItems[3].Text = "";
                            lisChild.SelectedItems[i].SubItems[4].Text = "";
                            
                            if (Index <= lisChild.Items.Count)
                            {
                                //    lisTarget.ListItems(Index).Selected = True
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                
                txtMoveQty1.Text = MPCF.ToInt(MPCF.ToDbl(txtMoveQty1.Text) - iCnt).ToString();
                txtMQty1.Text = txtMoveQty1.Text;
                txtMQty2.Text = txtMoveQty2.Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtChildLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtChildLotDesc.Focus();
            }
        }
        
        private void txtChildLotID_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (txtChildLotID.Text == "")
            {
                grpSublotInfo.Enabled = false;
            }
            else
            {
                grpSublotInfo.Enabled = true;
            }
        }
        
        private void grpSublotInfo_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(grpSublotInfo, pnlSubMother, pnlSubChild, pnlSplitSublot, 40);
            
        }
            
        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text != "")
            {
                RASLIST.ViewCarrierSublotList(lisMother, '1', cdvCrrID.Text, true);
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                if (cdvChildCrrID.Items.Count > 0)
                {
                    if (cdvChildCrrID.Text == "")
                    {
                        lisChild.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisChild, '1', cdvChildCrrID.Text, true);
                    }
                }
                else
                {
                    if (txtChildLotID.Text != "")
                    {
                        if (WIPLIST.ViewSublotList(lisChild, '1', txtChildLotID.Text, null) == false)
                        {
                            return;
                        }
                    }
                }
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
                
            }
#endif //_CRR
        }
        
        private void cdvCrrID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text == "")
            {
                if (cdvCrrID.Items.Count > 0)
                {
                    lisMother.Items.Clear();
                }
                else
                {
                    if (WIPLIST.ViewSublotList(lisMother, '1', txtLotID.Text, null) == false)
                    {
                        return;
                    }
                }
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                if (cdvChildCrrID.Items.Count > 0)
                {
                    if (cdvChildCrrID.Text == "")
                    {
                        lisChild.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisChild, '1', cdvChildCrrID.Text, true);
                    }
                }
                else
                {
                    if (txtChildLotID.Text != "")
                    {
                        if (WIPLIST.ViewSublotList(lisChild, '1', txtChildLotID.Text, null) == false)
                        {
                            return;
                        }
                    }
                }
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
            }
#endif //_CRR            
        }
        
        private void cdvChildCrrID_ButtonPress(System.Object sender, System.EventArgs e)
        {
#if _CRR
            cdvChildCrrID.Init();
            MPCF.InitListView(cdvChildCrrID.GetListView);
            cdvChildCrrID.Columns.Add("Carrier", 50, HorizontalAlignment.Left);
            cdvChildCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChildCrrID.SelectedSubItemIndex = 0;

            RASLIST.ViewCarrierList(cdvChildCrrID.GetListView, '2', "", "", "", ' ', cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvOper.Text, LOT.GetString("START_RES_ID"), LOT.GetString("PORT_ID"), cdvChildCrrID.Text, null, "");
#endif //_CRR    
        }
        
        private void cdvChildCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Items.Count > 0)
            {
                if (cdvCrrID.Text == "")
                {
                    lisMother.Items.Clear();
                }
                else
                {
                    RASLIST.ViewCarrierSublotList(lisMother, '1', cdvCrrID.Text, true);
                }
            }
            else
            {
                if (WIPLIST.ViewSublotList(lisMother, '1', txtLotID.Text, null) == false)
                {
                    return;
                }
            }
            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
            
            if (cdvChildCrrID.Text != "")
            {
                RASLIST.ViewCarrierSublotList(lisChild, '1', cdvChildCrrID.Text, true);
            }
            else
            {
                MakeEmptySlot(lisChild);
            }
            txtMoveQty1.Text = "0";
            txtMoveQty2.Text = "0";
            txtMoveQty3.Text = "0";
#endif //_CRR            
        }
        
        private void cdvChildCrrID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvChildCrrID.Text == "")
            {
                if (cdvCrrID.Items.Count > 0)
                {
                    if (cdvCrrID.Text == "")
                    {
                        lisMother.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisMother, '1', cdvCrrID.Text, true);
                    }
                }
                else
                {
                    if (WIPLIST.ViewSublotList(lisMother, '1', txtLotID.Text, null) == false)
                    {
                        return;
                    }
                }
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                MakeEmptySlot(lisChild);
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
                
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
            cdvCreateCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
            
        }
        
        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
            
        }
        
        private void cdvLotType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("LotType", 50, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("SPLIT_LOT_EXT", '2') == false) return;
            Generate_ID();
        }

    }
    
}
