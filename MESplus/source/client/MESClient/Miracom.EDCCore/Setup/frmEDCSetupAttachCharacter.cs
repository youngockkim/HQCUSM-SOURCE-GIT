
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using Miracom.MsgHandler;
using Miracom.UI.Controls;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCSetupAttachCharacter.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_Col_Set_Version_List() : View Collection Set Version
//       -  View_Character_By_Collection_List() : View Character List by Collection Set
//       -  Update_Attach_Character() : UpdateCharacter
//       -  Validation() : Spec Type and R Spec Type, Validation Check
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by W.Y. Choi
//       - 2008-01-14 : Modified by LAVERWON : All architecture changed
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.EDCCore
{
    public class frmEDCSetupAttachCharacter : Miracom.MESCore.SetupForm01
    {
        
#if _EDC

#region " Windows Form auto generated code "
        
        public frmEDCSetupAttachCharacter()
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

        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCollectionSet;
        private System.Windows.Forms.Label lblCollectionSet;
        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel pnlCharInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharID;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.TextBox txtUnitCount;
        private System.Windows.Forms.Label lblUnitCount;
        private System.Windows.Forms.Label lblValueCount;
        private System.Windows.Forms.TextBox txtValueCount;
        private System.Windows.Forms.Label lblDisplayPrecision;
        private System.Windows.Forms.TextBox txtDisplayPrecision;
        private System.Windows.Forms.CheckBox chkOptionalInput;
        private System.Windows.Forms.CheckBox chkBlankSave;
        private System.Windows.Forms.CheckBox chkDefaultUnit;
        private System.Windows.Forms.CheckBox chkDefaultUnitOvr;
        private System.Windows.Forms.Label lblDefaultValue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnitTable;
        private System.Windows.Forms.Label lblUnitTable;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValueTable;
        private System.Windows.Forms.Label lblValueTable;
        private System.Windows.Forms.Label lblSpecOutCount;
        private System.Windows.Forms.TextBox txtSpecOutCount;
        private System.Windows.Forms.Label lblUSL;
        private System.Windows.Forms.TextBox txtUpperSpecLimit;
        private System.Windows.Forms.Label lblLSL;
        private System.Windows.Forms.TextBox txtLowerSpecLimit;
        private System.Windows.Forms.Label lblUWL;
        private System.Windows.Forms.TextBox txtUpperWarnLimit;
        private System.Windows.Forms.Label lblSpecInfo;
        private System.Windows.Forms.TextBox txtSpecInfo;
        private System.Windows.Forms.Label lblLWL;
        private System.Windows.Forms.TextBox txtLowerWarnLimit;
        private System.Windows.Forms.Label lblSpecType;
        private System.Windows.Forms.ComboBox cboSpecType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDefaultValue;
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private System.Windows.Forms.Splitter spCenter;
        private System.Windows.Forms.Panel pnlCharacter;
        private FarPoint.Win.Spread.FpSpread spdCharacter;
        private FarPoint.Win.Spread.SheetView spdCharacter_Sheet1;
        private System.Windows.Forms.Label lblTargetValue;
        private TabControl tabAttachCharacter;
        private TabPage tbpGeneral;
        private TabPage tbpLimitInfo;
        private TabPage tbpUnitInfo;
        private GroupBox grpGeneral;
        private GroupBox grpLimitInfo;
        private GroupBox grpUnitInfo;
        private CheckBox chkDerivedFlag;
        private Panel pnlUnit;
        private Panel pnlUnitDescList;
        private FpSpread spdUnit;
        private SheetView spdUnit_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetValue;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private Button btnAllCheck;
        private Label lblAlarmCode2;
        private Label lblAlarmCode1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmCode2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmCode1;
        private CheckBox chkUnitNullFlag;
        private TabPage tbpAutoCalc;
        private GroupBox grpAutoCalc;
        private Button btnChange;
        private RadioButton rbtLastColData;
        private RadioButton rbtFirstColData;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseColSetVer;
        private Button btnDelCol;
        private Button btnAddRBracket;
        private Button btnAddLBracket;
        private ComboBox cboRBracket;
        private Label lblRBracket;
        private ComboBox cboLBracket;
        private Label lblLBracket;
        private Button btnAddOperator;
        private ComboBox cboOperator;
        private Label lblOperator;
        private Button btnAddOperand;
        private CheckBox chkOverrideRes;
        private CheckBox chkOverrideLot;
        private ComboBox cboUseValSeq;
        private ComboBox cboCalcType;
        private ComboBox cboUseUnitSeq;
        private Label lblUseValSeq;
        private Label lblCalcType;
        private Label lblUseUnitSeq;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseCharID;
        private Label lblUseChar;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseColSet;
        private Label lblUseColSet;
        private ComboBox cboValueType;
        private Label lblValueType;
        private FpSpread spdFormula;
        private SheetView spdFormula_Sheet1;
        private CheckBox chkUseCharUnitFlag;
        protected Button btnRefresh;
        private TextBox txtMinValueCount;
        private Label lblMinValueCount;
        private TextBox txtMinUnitCount;
        private Label lblMinUnitCount;
        private CheckBox chkOptUnitFlag;
        private CheckBox chkMinValueByLotQty;
        private CheckBox chkMinUnitByLotQty;
        private CheckBox chkNoUseSPMValue;
        private Button btnDown;
        private Button btnUp;
        private PictureBox pcbSpec;
        private TextBox txtDerivedParameter;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.White), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.White), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None, System.Drawing.Color.White));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDCSetupAttachCharacter));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvCollectionSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCollectionSet = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlCharInfo = new System.Windows.Forms.Panel();
            this.tabAttachCharacter = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkMinValueByLotQty = new System.Windows.Forms.CheckBox();
            this.txtMinValueCount = new System.Windows.Forms.TextBox();
            this.lblMinValueCount = new System.Windows.Forms.Label();
            this.txtDerivedParameter = new System.Windows.Forms.TextBox();
            this.chkDerivedFlag = new System.Windows.Forms.CheckBox();
            this.txtUnitCount = new System.Windows.Forms.TextBox();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUnitCount = new System.Windows.Forms.Label();
            this.cdvDefaultValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtValueCount = new System.Windows.Forms.TextBox();
            this.lblValueCount = new System.Windows.Forms.Label();
            this.lblDefaultValue = new System.Windows.Forms.Label();
            this.cdvValueTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValueTable = new System.Windows.Forms.Label();
            this.txtDisplayPrecision = new System.Windows.Forms.TextBox();
            this.lblDisplayPrecision = new System.Windows.Forms.Label();
            this.chkOptionalInput = new System.Windows.Forms.CheckBox();
            this.chkBlankSave = new System.Windows.Forms.CheckBox();
            this.tbpUnitInfo = new System.Windows.Forms.TabPage();
            this.grpUnitInfo = new System.Windows.Forms.GroupBox();
            this.pnlUnitDescList = new System.Windows.Forms.Panel();
            this.btnAllCheck = new System.Windows.Forms.Button();
            this.spdUnit = new FarPoint.Win.Spread.FpSpread();
            this.spdUnit_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUnit = new System.Windows.Forms.Panel();
            this.chkMinUnitByLotQty = new System.Windows.Forms.CheckBox();
            this.txtMinUnitCount = new System.Windows.Forms.TextBox();
            this.lblMinUnitCount = new System.Windows.Forms.Label();
            this.chkOptUnitFlag = new System.Windows.Forms.CheckBox();
            this.chkUseCharUnitFlag = new System.Windows.Forms.CheckBox();
            this.chkUnitNullFlag = new System.Windows.Forms.CheckBox();
            this.cdvUnitTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkDefaultUnit = new System.Windows.Forms.CheckBox();
            this.lblUnitTable = new System.Windows.Forms.Label();
            this.chkDefaultUnitOvr = new System.Windows.Forms.CheckBox();
            this.tbpLimitInfo = new System.Windows.Forms.TabPage();
            this.grpLimitInfo = new System.Windows.Forms.GroupBox();
            this.pcbSpec = new System.Windows.Forms.PictureBox();
            this.chkNoUseSPMValue = new System.Windows.Forms.CheckBox();
            this.lblAlarmCode2 = new System.Windows.Forms.Label();
            this.lblAlarmCode1 = new System.Windows.Forms.Label();
            this.cdvAlarmCode2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCode1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvTargetValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.txtUpperSpecLimit = new System.Windows.Forms.TextBox();
            this.lblUSL = new System.Windows.Forms.Label();
            this.lblSpecOutCount = new System.Windows.Forms.Label();
            this.txtLowerSpecLimit = new System.Windows.Forms.TextBox();
            this.txtSpecOutCount = new System.Windows.Forms.TextBox();
            this.lblLSL = new System.Windows.Forms.Label();
            this.cboSpecType = new System.Windows.Forms.ComboBox();
            this.lblSpecType = new System.Windows.Forms.Label();
            this.lblLWL = new System.Windows.Forms.Label();
            this.txtSpecInfo = new System.Windows.Forms.TextBox();
            this.txtLowerWarnLimit = new System.Windows.Forms.TextBox();
            this.txtUpperWarnLimit = new System.Windows.Forms.TextBox();
            this.lblUWL = new System.Windows.Forms.Label();
            this.lblSpecInfo = new System.Windows.Forms.Label();
            this.tbpAutoCalc = new System.Windows.Forms.TabPage();
            this.grpAutoCalc = new System.Windows.Forms.GroupBox();
            this.spdFormula = new FarPoint.Win.Spread.FpSpread();
            this.spdFormula_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnChange = new System.Windows.Forms.Button();
            this.rbtLastColData = new System.Windows.Forms.RadioButton();
            this.rbtFirstColData = new System.Windows.Forms.RadioButton();
            this.cdvUseColSetVer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnDelCol = new System.Windows.Forms.Button();
            this.btnAddRBracket = new System.Windows.Forms.Button();
            this.btnAddLBracket = new System.Windows.Forms.Button();
            this.cboRBracket = new System.Windows.Forms.ComboBox();
            this.lblRBracket = new System.Windows.Forms.Label();
            this.cboLBracket = new System.Windows.Forms.ComboBox();
            this.lblLBracket = new System.Windows.Forms.Label();
            this.btnAddOperator = new System.Windows.Forms.Button();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.btnAddOperand = new System.Windows.Forms.Button();
            this.chkOverrideRes = new System.Windows.Forms.CheckBox();
            this.chkOverrideLot = new System.Windows.Forms.CheckBox();
            this.cboUseValSeq = new System.Windows.Forms.ComboBox();
            this.cboCalcType = new System.Windows.Forms.ComboBox();
            this.cboUseUnitSeq = new System.Windows.Forms.ComboBox();
            this.lblUseValSeq = new System.Windows.Forms.Label();
            this.lblCalcType = new System.Windows.Forms.Label();
            this.lblUseUnitSeq = new System.Windows.Forms.Label();
            this.cdvUseCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUseChar = new System.Windows.Forms.Label();
            this.cdvUseColSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUseColSet = new System.Windows.Forms.Label();
            this.cboValueType = new System.Windows.Forms.ComboBox();
            this.lblValueType = new System.Windows.Forms.Label();
            this.pnlCharacter = new System.Windows.Forms.Panel();
            this.spdCharacter = new FarPoint.Win.Spread.FpSpread();
            this.spdCharacter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spCenter = new System.Windows.Forms.Splitter();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).BeginInit();
            this.pnlCharInfo.SuspendLayout();
            this.tabAttachCharacter.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefaultValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValueTable)).BeginInit();
            this.tbpUnitInfo.SuspendLayout();
            this.grpUnitInfo.SuspendLayout();
            this.pnlUnitDescList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).BeginInit();
            this.pnlUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnitTable)).BeginInit();
            this.tbpLimitInfo.SuspendLayout();
            this.grpLimitInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSpec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).BeginInit();
            this.tbpAutoCalc.SuspendLayout();
            this.grpAutoCalc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFormula_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseColSetVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseColSet)).BeginInit();
            this.pnlCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(366, 6);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(548, 6);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(457, 6);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(639, 6);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 505);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(734, 37);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCharacter);
            this.pnlCenter.Controls.Add(this.pnlCharInfo);
            this.pnlCenter.Controls.Add(this.spCenter);
            this.pnlCenter.Controls.Add(this.pnlVersion);
            this.pnlCenter.Location = new System.Drawing.Point(0, 43);
            this.pnlCenter.Size = new System.Drawing.Size(734, 462);
            this.pnlCenter.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Attach Character to Version";
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
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpOption);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(734, 43);
            this.pnlGrp.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvCollectionSet);
            this.grpOption.Controls.Add(this.lblCollectionSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(728, 43);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvCollectionSet
            // 
            this.cdvCollectionSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCollectionSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCollectionSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCollectionSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCollectionSet.BtnToolTipText = "";
            this.cdvCollectionSet.ButtonWidth = 20;
            this.cdvCollectionSet.DescText = "";
            this.cdvCollectionSet.DisplaySubItemIndex = 0;
            this.cdvCollectionSet.DisplayText = "";
            this.cdvCollectionSet.Focusing = null;
            this.cdvCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCollectionSet.Index = 0;
            this.cdvCollectionSet.IsViewBtnImage = false;
            this.cdvCollectionSet.Location = new System.Drawing.Point(120, 16);
            this.cdvCollectionSet.MaxLength = 25;
            this.cdvCollectionSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.Name = "cdvCollectionSet";
            this.cdvCollectionSet.ReadOnly = false;
            this.cdvCollectionSet.SameWidthHeightOfButton = false;
            this.cdvCollectionSet.SearchSubItemIndex = 0;
            this.cdvCollectionSet.SelectedDescIndex = 1;
            this.cdvCollectionSet.SelectedSubItemIndex = 0;
            this.cdvCollectionSet.SelectionStart = 0;
            this.cdvCollectionSet.Size = new System.Drawing.Size(601, 20);
            this.cdvCollectionSet.SmallImageList = null;
            this.cdvCollectionSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCollectionSet.TabIndex = 1;
            this.cdvCollectionSet.TextBoxToolTipText = "";
            this.cdvCollectionSet.TextBoxWidth = 200;
            this.cdvCollectionSet.VisibleButton = true;
            this.cdvCollectionSet.VisibleColumnHeader = false;
            this.cdvCollectionSet.VisibleDescription = true;
            this.cdvCollectionSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCollectionSet_SelectedItemChanged);
            this.cdvCollectionSet.ButtonPress += new System.EventHandler(this.cdvCollectionSet_ButtonPress);
            this.cdvCollectionSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_TextBoxKeyPress);
            this.cdvCollectionSet.TextBoxTextChanged += new System.EventHandler(this.cdvCollectionSet_TextBoxTextChanged);
            // 
            // lblCollectionSet
            // 
            this.lblCollectionSet.AutoSize = true;
            this.lblCollectionSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionSet.Location = new System.Drawing.Point(15, 19);
            this.lblCollectionSet.Name = "lblCollectionSet";
            this.lblCollectionSet.Size = new System.Drawing.Size(86, 13);
            this.lblCollectionSet.TabIndex = 0;
            this.lblCollectionSet.Text = "Collection Set";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(13, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlCharInfo
            // 
            this.pnlCharInfo.Controls.Add(this.tabAttachCharacter);
            this.pnlCharInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCharInfo.Location = new System.Drawing.Point(0, 220);
            this.pnlCharInfo.Name = "pnlCharInfo";
            this.pnlCharInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCharInfo.Size = new System.Drawing.Size(734, 242);
            this.pnlCharInfo.TabIndex = 1;
            // 
            // tabAttachCharacter
            // 
            this.tabAttachCharacter.Controls.Add(this.tbpGeneral);
            this.tabAttachCharacter.Controls.Add(this.tbpUnitInfo);
            this.tabAttachCharacter.Controls.Add(this.tbpLimitInfo);
            this.tabAttachCharacter.Controls.Add(this.tbpAutoCalc);
            this.tabAttachCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAttachCharacter.Location = new System.Drawing.Point(3, 0);
            this.tabAttachCharacter.Name = "tabAttachCharacter";
            this.tabAttachCharacter.SelectedIndex = 0;
            this.tabAttachCharacter.Size = new System.Drawing.Size(728, 242);
            this.tabAttachCharacter.TabIndex = 2;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(720, 216);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkMinValueByLotQty);
            this.grpGeneral.Controls.Add(this.txtMinValueCount);
            this.grpGeneral.Controls.Add(this.lblMinValueCount);
            this.grpGeneral.Controls.Add(this.txtDerivedParameter);
            this.grpGeneral.Controls.Add(this.chkDerivedFlag);
            this.grpGeneral.Controls.Add(this.txtUnitCount);
            this.grpGeneral.Controls.Add(this.lblCharacter);
            this.grpGeneral.Controls.Add(this.cdvCharID);
            this.grpGeneral.Controls.Add(this.lblUnitCount);
            this.grpGeneral.Controls.Add(this.cdvDefaultValue);
            this.grpGeneral.Controls.Add(this.txtValueCount);
            this.grpGeneral.Controls.Add(this.lblValueCount);
            this.grpGeneral.Controls.Add(this.lblDefaultValue);
            this.grpGeneral.Controls.Add(this.cdvValueTable);
            this.grpGeneral.Controls.Add(this.lblValueTable);
            this.grpGeneral.Controls.Add(this.txtDisplayPrecision);
            this.grpGeneral.Controls.Add(this.lblDisplayPrecision);
            this.grpGeneral.Controls.Add(this.chkOptionalInput);
            this.grpGeneral.Controls.Add(this.chkBlankSave);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(714, 213);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // chkMinValueByLotQty
            // 
            this.chkMinValueByLotQty.AutoSize = true;
            this.chkMinValueByLotQty.Enabled = false;
            this.chkMinValueByLotQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMinValueByLotQty.Location = new System.Drawing.Point(487, 111);
            this.chkMinValueByLotQty.Name = "chkMinValueByLotQty";
            this.chkMinValueByLotQty.Size = new System.Drawing.Size(160, 18);
            this.chkMinValueByLotQty.TabIndex = 18;
            this.chkMinValueByLotQty.Text = "Minimum Value by Lot QTY";
            this.chkMinValueByLotQty.CheckedChanged += new System.EventHandler(this.chkMinValueByLotQty_CheckedChanged);
            // 
            // txtMinValueCount
            // 
            this.txtMinValueCount.Location = new System.Drawing.Point(610, 90);
            this.txtMinValueCount.MaxLength = 4;
            this.txtMinValueCount.Name = "txtMinValueCount";
            this.txtMinValueCount.ReadOnly = true;
            this.txtMinValueCount.Size = new System.Drawing.Size(35, 20);
            this.txtMinValueCount.TabIndex = 16;
            this.txtMinValueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinValueCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblMinValueCount
            // 
            this.lblMinValueCount.AutoSize = true;
            this.lblMinValueCount.Enabled = false;
            this.lblMinValueCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinValueCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinValueCount.Location = new System.Drawing.Point(489, 92);
            this.lblMinValueCount.Name = "lblMinValueCount";
            this.lblMinValueCount.Size = new System.Drawing.Size(109, 13);
            this.lblMinValueCount.TabIndex = 15;
            this.lblMinValueCount.Text = "Minimum Value Count";
            // 
            // txtDerivedParameter
            // 
            this.txtDerivedParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDerivedParameter.Location = new System.Drawing.Point(13, 131);
            this.txtDerivedParameter.MaxLength = 2000;
            this.txtDerivedParameter.Multiline = true;
            this.txtDerivedParameter.Name = "txtDerivedParameter";
            this.txtDerivedParameter.ReadOnly = true;
            this.txtDerivedParameter.Size = new System.Drawing.Size(691, 68);
            this.txtDerivedParameter.TabIndex = 19;
            this.txtDerivedParameter.Visible = false;
            // 
            // chkDerivedFlag
            // 
            this.chkDerivedFlag.AutoSize = true;
            this.chkDerivedFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDerivedFlag.Location = new System.Drawing.Point(13, 113);
            this.chkDerivedFlag.Name = "chkDerivedFlag";
            this.chkDerivedFlag.Size = new System.Drawing.Size(120, 18);
            this.chkDerivedFlag.TabIndex = 17;
            this.chkDerivedFlag.Text = "Derived Parameter";
            this.chkDerivedFlag.CheckedChanged += new System.EventHandler(this.chkDerivedFlag_CheckedChanged);
            // 
            // txtUnitCount
            // 
            this.txtUnitCount.Location = new System.Drawing.Point(119, 41);
            this.txtUnitCount.MaxLength = 3;
            this.txtUnitCount.Name = "txtUnitCount";
            this.txtUnitCount.Size = new System.Drawing.Size(35, 20);
            this.txtUnitCount.TabIndex = 3;
            this.txtUnitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitCount.TextChanged += new System.EventHandler(this.txtUnitCount_TextChanged);
            this.txtUnitCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.Location = new System.Drawing.Point(15, 20);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(62, 13);
            this.lblCharacter.TabIndex = 0;
            this.lblCharacter.Text = "Character";
            // 
            // cdvCharID
            // 
            this.cdvCharID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCharID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharID.BtnToolTipText = "";
            this.cdvCharID.ButtonWidth = 20;
            this.cdvCharID.DescText = "";
            this.cdvCharID.DisplaySubItemIndex = 0;
            this.cdvCharID.DisplayText = "";
            this.cdvCharID.Focusing = null;
            this.cdvCharID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharID.Index = 0;
            this.cdvCharID.IsViewBtnImage = false;
            this.cdvCharID.Location = new System.Drawing.Point(120, 17);
            this.cdvCharID.MaxLength = 25;
            this.cdvCharID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.Name = "cdvCharID";
            this.cdvCharID.ReadOnly = false;
            this.cdvCharID.SameWidthHeightOfButton = false;
            this.cdvCharID.SearchSubItemIndex = 0;
            this.cdvCharID.SelectedDescIndex = 1;
            this.cdvCharID.SelectedSubItemIndex = 0;
            this.cdvCharID.SelectionStart = 0;
            this.cdvCharID.Size = new System.Drawing.Size(342, 20);
            this.cdvCharID.SmallImageList = null;
            this.cdvCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharID.TabIndex = 1;
            this.cdvCharID.TextBoxToolTipText = "";
            this.cdvCharID.TextBoxWidth = 145;
            this.cdvCharID.VisibleButton = true;
            this.cdvCharID.VisibleColumnHeader = false;
            this.cdvCharID.VisibleDescription = true;
            this.cdvCharID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCharID_SelectedItemChanged);
            this.cdvCharID.ButtonPress += new System.EventHandler(this.cdvCharID_ButtonPress);
            // 
            // lblUnitCount
            // 
            this.lblUnitCount.AutoSize = true;
            this.lblUnitCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitCount.Location = new System.Drawing.Point(14, 44);
            this.lblUnitCount.Name = "lblUnitCount";
            this.lblUnitCount.Size = new System.Drawing.Size(67, 13);
            this.lblUnitCount.TabIndex = 2;
            this.lblUnitCount.Text = "Unit Count";
            // 
            // cdvDefaultValue
            // 
            this.cdvDefaultValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefaultValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefaultValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDefaultValue.BtnToolTipText = "";
            this.cdvDefaultValue.ButtonWidth = 20;
            this.cdvDefaultValue.DescText = "";
            this.cdvDefaultValue.DisplaySubItemIndex = -1;
            this.cdvDefaultValue.DisplayText = "";
            this.cdvDefaultValue.Focusing = null;
            this.cdvDefaultValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDefaultValue.Index = 0;
            this.cdvDefaultValue.IsViewBtnImage = false;
            this.cdvDefaultValue.Location = new System.Drawing.Point(273, 65);
            this.cdvDefaultValue.MaxLength = 20;
            this.cdvDefaultValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDefaultValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDefaultValue.Name = "cdvDefaultValue";
            this.cdvDefaultValue.ReadOnly = false;
            this.cdvDefaultValue.SameWidthHeightOfButton = false;
            this.cdvDefaultValue.SearchSubItemIndex = 0;
            this.cdvDefaultValue.SelectedDescIndex = -1;
            this.cdvDefaultValue.SelectedSubItemIndex = -1;
            this.cdvDefaultValue.SelectionStart = 0;
            this.cdvDefaultValue.Size = new System.Drawing.Size(197, 20);
            this.cdvDefaultValue.SmallImageList = null;
            this.cdvDefaultValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDefaultValue.TabIndex = 10;
            this.cdvDefaultValue.TextBoxToolTipText = "";
            this.cdvDefaultValue.TextBoxWidth = 197;
            this.cdvDefaultValue.VisibleButton = true;
            this.cdvDefaultValue.VisibleColumnHeader = false;
            this.cdvDefaultValue.VisibleDescription = false;
            this.cdvDefaultValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharValue_TextBoxKeyPress);
            // 
            // txtValueCount
            // 
            this.txtValueCount.Location = new System.Drawing.Point(119, 65);
            this.txtValueCount.MaxLength = 4;
            this.txtValueCount.Name = "txtValueCount";
            this.txtValueCount.Size = new System.Drawing.Size(35, 20);
            this.txtValueCount.TabIndex = 8;
            this.txtValueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValueCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblValueCount
            // 
            this.lblValueCount.AutoSize = true;
            this.lblValueCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueCount.Location = new System.Drawing.Point(14, 68);
            this.lblValueCount.Name = "lblValueCount";
            this.lblValueCount.Size = new System.Drawing.Size(76, 13);
            this.lblValueCount.TabIndex = 7;
            this.lblValueCount.Text = "Value Count";
            // 
            // lblDefaultValue
            // 
            this.lblDefaultValue.AutoSize = true;
            this.lblDefaultValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefaultValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultValue.Location = new System.Drawing.Point(168, 68);
            this.lblDefaultValue.Name = "lblDefaultValue";
            this.lblDefaultValue.Size = new System.Drawing.Size(71, 13);
            this.lblDefaultValue.TabIndex = 9;
            this.lblDefaultValue.Text = "Default Value";
            // 
            // cdvValueTable
            // 
            this.cdvValueTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValueTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValueTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValueTable.BtnToolTipText = "";
            this.cdvValueTable.ButtonWidth = 20;
            this.cdvValueTable.DescText = "";
            this.cdvValueTable.DisplaySubItemIndex = -1;
            this.cdvValueTable.DisplayText = "";
            this.cdvValueTable.Focusing = null;
            this.cdvValueTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValueTable.Index = 0;
            this.cdvValueTable.IsViewBtnImage = false;
            this.cdvValueTable.Location = new System.Drawing.Point(273, 41);
            this.cdvValueTable.MaxLength = 20;
            this.cdvValueTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValueTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValueTable.Name = "cdvValueTable";
            this.cdvValueTable.ReadOnly = true;
            this.cdvValueTable.SameWidthHeightOfButton = false;
            this.cdvValueTable.SearchSubItemIndex = 0;
            this.cdvValueTable.SelectedDescIndex = -1;
            this.cdvValueTable.SelectedSubItemIndex = -1;
            this.cdvValueTable.SelectionStart = 0;
            this.cdvValueTable.Size = new System.Drawing.Size(197, 20);
            this.cdvValueTable.SmallImageList = null;
            this.cdvValueTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValueTable.TabIndex = 5;
            this.cdvValueTable.TextBoxToolTipText = "";
            this.cdvValueTable.TextBoxWidth = 197;
            this.cdvValueTable.VisibleButton = true;
            this.cdvValueTable.VisibleColumnHeader = false;
            this.cdvValueTable.VisibleDescription = false;
            this.cdvValueTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValueTable_SelectedItemChanged);
            this.cdvValueTable.ButtonPress += new System.EventHandler(this.cdvValueTable_ButtonPress);
            this.cdvValueTable.TextBoxTextChanged += new System.EventHandler(this.cdvValueTable_TextBoxTextChanged);
            // 
            // lblValueTable
            // 
            this.lblValueTable.AutoSize = true;
            this.lblValueTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTable.Location = new System.Drawing.Point(168, 44);
            this.lblValueTable.Name = "lblValueTable";
            this.lblValueTable.Size = new System.Drawing.Size(64, 13);
            this.lblValueTable.TabIndex = 4;
            this.lblValueTable.Text = "Value Table";
            // 
            // txtDisplayPrecision
            // 
            this.txtDisplayPrecision.Location = new System.Drawing.Point(119, 90);
            this.txtDisplayPrecision.MaxLength = 1;
            this.txtDisplayPrecision.Name = "txtDisplayPrecision";
            this.txtDisplayPrecision.Size = new System.Drawing.Size(35, 20);
            this.txtDisplayPrecision.TabIndex = 14;
            this.txtDisplayPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisplayPrecision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblDisplayPrecision
            // 
            this.lblDisplayPrecision.AutoSize = true;
            this.lblDisplayPrecision.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDisplayPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayPrecision.Location = new System.Drawing.Point(15, 92);
            this.lblDisplayPrecision.Name = "lblDisplayPrecision";
            this.lblDisplayPrecision.Size = new System.Drawing.Size(87, 13);
            this.lblDisplayPrecision.TabIndex = 13;
            this.lblDisplayPrecision.Text = "Display Precision";
            // 
            // chkOptionalInput
            // 
            this.chkOptionalInput.AutoSize = true;
            this.chkOptionalInput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOptionalInput.Location = new System.Drawing.Point(487, 44);
            this.chkOptionalInput.Name = "chkOptionalInput";
            this.chkOptionalInput.Size = new System.Drawing.Size(121, 18);
            this.chkOptionalInput.TabIndex = 6;
            this.chkOptionalInput.Text = "Optional Input Flag";
            this.chkOptionalInput.CheckedChanged += new System.EventHandler(this.chkOptionalInput_CheckedChanged);
            // 
            // chkBlankSave
            // 
            this.chkBlankSave.AutoSize = true;
            this.chkBlankSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBlankSave.Location = new System.Drawing.Point(487, 67);
            this.chkBlankSave.Name = "chkBlankSave";
            this.chkBlankSave.Size = new System.Drawing.Size(110, 18);
            this.chkBlankSave.TabIndex = 11;
            this.chkBlankSave.Text = "Blank Save Flag";
            // 
            // tbpUnitInfo
            // 
            this.tbpUnitInfo.Controls.Add(this.grpUnitInfo);
            this.tbpUnitInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpUnitInfo.Name = "tbpUnitInfo";
            this.tbpUnitInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpUnitInfo.Size = new System.Drawing.Size(720, 216);
            this.tbpUnitInfo.TabIndex = 2;
            this.tbpUnitInfo.Text = "Unit Information";
            // 
            // grpUnitInfo
            // 
            this.grpUnitInfo.Controls.Add(this.pnlUnitDescList);
            this.grpUnitInfo.Controls.Add(this.pnlUnit);
            this.grpUnitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnitInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnitInfo.Location = new System.Drawing.Point(3, 0);
            this.grpUnitInfo.Name = "grpUnitInfo";
            this.grpUnitInfo.Size = new System.Drawing.Size(714, 213);
            this.grpUnitInfo.TabIndex = 0;
            this.grpUnitInfo.TabStop = false;
            // 
            // pnlUnitDescList
            // 
            this.pnlUnitDescList.Controls.Add(this.btnAllCheck);
            this.pnlUnitDescList.Controls.Add(this.spdUnit);
            this.pnlUnitDescList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitDescList.Location = new System.Drawing.Point(360, 16);
            this.pnlUnitDescList.Name = "pnlUnitDescList";
            this.pnlUnitDescList.Size = new System.Drawing.Size(351, 194);
            this.pnlUnitDescList.TabIndex = 1;
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAllCheck.Location = new System.Drawing.Point(2, 4);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(92, 20);
            this.btnAllCheck.TabIndex = 0;
            this.btnAllCheck.Tag = "UNCHECK";
            this.btnAllCheck.Text = "All Check";
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // spdUnit
            // 
            this.spdUnit.AccessibleDescription = "spdUnit, Sheet1, Row 0, Column 0, ";
            this.spdUnit.BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spdUnit.EditModeReplace = true;
            this.spdUnit.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUnit.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit.HorizontalScrollBar.Name = "";
            this.spdUnit.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdUnit.HorizontalScrollBar.TabIndex = 2;
            this.spdUnit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit.Location = new System.Drawing.Point(0, 26);
            this.spdUnit.Name = "spdUnit";
            this.spdUnit.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdUnit.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdUnit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUnit_Sheet1});
            this.spdUnit.Size = new System.Drawing.Size(351, 168);
            this.spdUnit.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit.TabIndex = 1;
            this.spdUnit.TabStop = false;
            this.spdUnit.TextTipDelay = 200;
            this.spdUnit.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdUnit.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit.VerticalScrollBar.Name = "";
            this.spdUnit.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdUnit.VerticalScrollBar.TabIndex = 3;
            this.spdUnit.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdUnit_ButtonClicked);
            // 
            // spdUnit_Sheet1
            // 
            this.spdUnit_Sheet1.Reset();
            spdUnit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUnit_Sheet1.ColumnCount = 3;
            spdUnit_Sheet1.RowCount = 4;
            this.spdUnit_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Nullable";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Unit Definition";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = " ";
            this.spdUnit_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdUnit_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdUnit_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(0).Label = "Nullable";
            this.spdUnit_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(0).Width = 53F;
            this.spdUnit_Sheet1.Columns.Get(1).Border = complexBorder1;
            this.spdUnit_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdUnit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit_Sheet1.Columns.Get(1).Label = "Unit Definition";
            this.spdUnit_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(1).Width = 223F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdUnit_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdUnit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(2).Label = " ";
            this.spdUnit_Sheet1.Columns.Get(2).Locked = false;
            this.spdUnit_Sheet1.Columns.Get(2).Resizable = false;
            this.spdUnit_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdUnit_Sheet1.Columns.Get(2).Width = 20F;
            this.spdUnit_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit_Sheet1.RowHeader.Columns.Get(0).Width = 40F;
            this.spdUnit_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUnit
            // 
            this.pnlUnit.Controls.Add(this.chkMinUnitByLotQty);
            this.pnlUnit.Controls.Add(this.txtMinUnitCount);
            this.pnlUnit.Controls.Add(this.lblMinUnitCount);
            this.pnlUnit.Controls.Add(this.chkOptUnitFlag);
            this.pnlUnit.Controls.Add(this.chkUseCharUnitFlag);
            this.pnlUnit.Controls.Add(this.chkUnitNullFlag);
            this.pnlUnit.Controls.Add(this.cdvUnitTable);
            this.pnlUnit.Controls.Add(this.chkDefaultUnit);
            this.pnlUnit.Controls.Add(this.lblUnitTable);
            this.pnlUnit.Controls.Add(this.chkDefaultUnitOvr);
            this.pnlUnit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnit.Location = new System.Drawing.Point(3, 16);
            this.pnlUnit.Name = "pnlUnit";
            this.pnlUnit.Size = new System.Drawing.Size(357, 194);
            this.pnlUnit.TabIndex = 0;
            // 
            // chkMinUnitByLotQty
            // 
            this.chkMinUnitByLotQty.AutoSize = true;
            this.chkMinUnitByLotQty.Enabled = false;
            this.chkMinUnitByLotQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMinUnitByLotQty.Location = new System.Drawing.Point(177, 49);
            this.chkMinUnitByLotQty.Name = "chkMinUnitByLotQty";
            this.chkMinUnitByLotQty.Size = new System.Drawing.Size(152, 18);
            this.chkMinUnitByLotQty.TabIndex = 4;
            this.chkMinUnitByLotQty.Text = "Minimum Unit by Lot QTY";
            this.chkMinUnitByLotQty.CheckedChanged += new System.EventHandler(this.chkMinUnitByLotQty_CheckedChanged);
            // 
            // txtMinUnitCount
            // 
            this.txtMinUnitCount.Location = new System.Drawing.Point(136, 48);
            this.txtMinUnitCount.MaxLength = 4;
            this.txtMinUnitCount.Name = "txtMinUnitCount";
            this.txtMinUnitCount.ReadOnly = true;
            this.txtMinUnitCount.Size = new System.Drawing.Size(35, 20);
            this.txtMinUnitCount.TabIndex = 3;
            this.txtMinUnitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinUnitCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblMinUnitCount
            // 
            this.lblMinUnitCount.AutoSize = true;
            this.lblMinUnitCount.Enabled = false;
            this.lblMinUnitCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinUnitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinUnitCount.Location = new System.Drawing.Point(16, 50);
            this.lblMinUnitCount.Name = "lblMinUnitCount";
            this.lblMinUnitCount.Size = new System.Drawing.Size(101, 13);
            this.lblMinUnitCount.TabIndex = 2;
            this.lblMinUnitCount.Text = "Minimum Unit Count";
            // 
            // chkOptUnitFlag
            // 
            this.chkOptUnitFlag.AccessibleDescription = "";
            this.chkOptUnitFlag.AutoSize = true;
            this.chkOptUnitFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOptUnitFlag.Location = new System.Drawing.Point(15, 27);
            this.chkOptUnitFlag.Name = "chkOptUnitFlag";
            this.chkOptUnitFlag.Size = new System.Drawing.Size(116, 18);
            this.chkOptUnitFlag.TabIndex = 1;
            this.chkOptUnitFlag.Text = "Optional Unit Flag";
            this.chkOptUnitFlag.CheckedChanged += new System.EventHandler(this.chkOptUnitFlag_CheckedChanged);
            // 
            // chkUseCharUnitFlag
            // 
            this.chkUseCharUnitFlag.AccessibleDescription = "";
            this.chkUseCharUnitFlag.AutoSize = true;
            this.chkUseCharUnitFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseCharUnitFlag.Location = new System.Drawing.Point(15, 6);
            this.chkUseCharUnitFlag.Name = "chkUseCharUnitFlag";
            this.chkUseCharUnitFlag.Size = new System.Drawing.Size(181, 18);
            this.chkUseCharUnitFlag.TabIndex = 0;
            this.chkUseCharUnitFlag.Text = "Use Character Unit Prompt Flag";
            this.chkUseCharUnitFlag.CheckedChanged += new System.EventHandler(this.chkUseCharUnitFlag_CheckedChanged);
            // 
            // chkUnitNullFlag
            // 
            this.chkUnitNullFlag.AccessibleDescription = "";
            this.chkUnitNullFlag.AutoSize = true;
            this.chkUnitNullFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnitNullFlag.Location = new System.Drawing.Point(15, 84);
            this.chkUnitNullFlag.Name = "chkUnitNullFlag";
            this.chkUnitNullFlag.Size = new System.Drawing.Size(95, 18);
            this.chkUnitNullFlag.TabIndex = 5;
            this.chkUnitNullFlag.Text = "Unit Null Flag";
            this.chkUnitNullFlag.CheckedChanged += new System.EventHandler(this.chkUnitNullFlag_CheckedChanged);
            // 
            // cdvUnitTable
            // 
            this.cdvUnitTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnitTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnitTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnitTable.BtnToolTipText = "";
            this.cdvUnitTable.ButtonWidth = 20;
            this.cdvUnitTable.DescText = "";
            this.cdvUnitTable.DisplaySubItemIndex = 0;
            this.cdvUnitTable.DisplayText = "";
            this.cdvUnitTable.Focusing = null;
            this.cdvUnitTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnitTable.Index = 0;
            this.cdvUnitTable.IsViewBtnImage = false;
            this.cdvUnitTable.Location = new System.Drawing.Point(14, 167);
            this.cdvUnitTable.MaxLength = 20;
            this.cdvUnitTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnitTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnitTable.Name = "cdvUnitTable";
            this.cdvUnitTable.ReadOnly = true;
            this.cdvUnitTable.SameWidthHeightOfButton = false;
            this.cdvUnitTable.SearchSubItemIndex = 0;
            this.cdvUnitTable.SelectedDescIndex = 1;
            this.cdvUnitTable.SelectedSubItemIndex = 0;
            this.cdvUnitTable.SelectionStart = 0;
            this.cdvUnitTable.Size = new System.Drawing.Size(332, 20);
            this.cdvUnitTable.SmallImageList = null;
            this.cdvUnitTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnitTable.TabIndex = 9;
            this.cdvUnitTable.TextBoxToolTipText = "";
            this.cdvUnitTable.TextBoxWidth = 145;
            this.cdvUnitTable.VisibleButton = true;
            this.cdvUnitTable.VisibleColumnHeader = false;
            this.cdvUnitTable.VisibleDescription = true;
            this.cdvUnitTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvUnitTable_SelectedItemChanged);
            this.cdvUnitTable.ButtonPress += new System.EventHandler(this.cdvUnitTable_ButtonPress);
            // 
            // chkDefaultUnit
            // 
            this.chkDefaultUnit.AccessibleDescription = "";
            this.chkDefaultUnit.AutoSize = true;
            this.chkDefaultUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDefaultUnit.Location = new System.Drawing.Point(15, 105);
            this.chkDefaultUnit.Name = "chkDefaultUnit";
            this.chkDefaultUnit.Size = new System.Drawing.Size(111, 18);
            this.chkDefaultUnit.TabIndex = 6;
            this.chkDefaultUnit.Text = "Default Unit Flag";
            this.chkDefaultUnit.CheckedChanged += new System.EventHandler(this.chkDefaultUnit_CheckedChanged);
            // 
            // lblUnitTable
            // 
            this.lblUnitTable.AutoSize = true;
            this.lblUnitTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnitTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitTable.Location = new System.Drawing.Point(15, 151);
            this.lblUnitTable.Name = "lblUnitTable";
            this.lblUnitTable.Size = new System.Drawing.Size(56, 13);
            this.lblUnitTable.TabIndex = 8;
            this.lblUnitTable.Text = "Unit Table";
            // 
            // chkDefaultUnitOvr
            // 
            this.chkDefaultUnitOvr.AccessibleDescription = "";
            this.chkDefaultUnitOvr.AutoSize = true;
            this.chkDefaultUnitOvr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDefaultUnitOvr.Location = new System.Drawing.Point(15, 127);
            this.chkDefaultUnitOvr.Name = "chkDefaultUnitOvr";
            this.chkDefaultUnitOvr.Size = new System.Drawing.Size(154, 18);
            this.chkDefaultUnitOvr.TabIndex = 7;
            this.chkDefaultUnitOvr.Text = "Default Unit Override Flag";
            // 
            // tbpLimitInfo
            // 
            this.tbpLimitInfo.Controls.Add(this.grpLimitInfo);
            this.tbpLimitInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpLimitInfo.Name = "tbpLimitInfo";
            this.tbpLimitInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpLimitInfo.Size = new System.Drawing.Size(720, 216);
            this.tbpLimitInfo.TabIndex = 1;
            this.tbpLimitInfo.Text = "Limit Information";
            // 
            // grpLimitInfo
            // 
            this.grpLimitInfo.Controls.Add(this.pcbSpec);
            this.grpLimitInfo.Controls.Add(this.chkNoUseSPMValue);
            this.grpLimitInfo.Controls.Add(this.lblAlarmCode2);
            this.grpLimitInfo.Controls.Add(this.lblAlarmCode1);
            this.grpLimitInfo.Controls.Add(this.cdvAlarmCode2);
            this.grpLimitInfo.Controls.Add(this.cdvAlarmCode1);
            this.grpLimitInfo.Controls.Add(this.cdvTargetValue);
            this.grpLimitInfo.Controls.Add(this.lblTargetValue);
            this.grpLimitInfo.Controls.Add(this.txtUpperSpecLimit);
            this.grpLimitInfo.Controls.Add(this.lblUSL);
            this.grpLimitInfo.Controls.Add(this.lblSpecOutCount);
            this.grpLimitInfo.Controls.Add(this.txtLowerSpecLimit);
            this.grpLimitInfo.Controls.Add(this.txtSpecOutCount);
            this.grpLimitInfo.Controls.Add(this.lblLSL);
            this.grpLimitInfo.Controls.Add(this.cboSpecType);
            this.grpLimitInfo.Controls.Add(this.lblSpecType);
            this.grpLimitInfo.Controls.Add(this.lblLWL);
            this.grpLimitInfo.Controls.Add(this.txtSpecInfo);
            this.grpLimitInfo.Controls.Add(this.txtLowerWarnLimit);
            this.grpLimitInfo.Controls.Add(this.txtUpperWarnLimit);
            this.grpLimitInfo.Controls.Add(this.lblUWL);
            this.grpLimitInfo.Controls.Add(this.lblSpecInfo);
            this.grpLimitInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLimitInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLimitInfo.Location = new System.Drawing.Point(3, 0);
            this.grpLimitInfo.Name = "grpLimitInfo";
            this.grpLimitInfo.Size = new System.Drawing.Size(714, 213);
            this.grpLimitInfo.TabIndex = 0;
            this.grpLimitInfo.TabStop = false;
            // 
            // pcbSpec
            // 
            this.pcbSpec.Image = global::Miracom.EDCCore.Properties.Resources.SpecChart;
            this.pcbSpec.Location = new System.Drawing.Point(435, 15);
            this.pcbSpec.Name = "pcbSpec";
            this.pcbSpec.Size = new System.Drawing.Size(148, 191);
            this.pcbSpec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbSpec.TabIndex = 21;
            this.pcbSpec.TabStop = false;
            // 
            // chkNoUseSPMValue
            // 
            this.chkNoUseSPMValue.AutoSize = true;
            this.chkNoUseSPMValue.Location = new System.Drawing.Point(8, 12);
            this.chkNoUseSPMValue.Name = "chkNoUseSPMValue";
            this.chkNoUseSPMValue.Size = new System.Drawing.Size(141, 17);
            this.chkNoUseSPMValue.TabIndex = 0;
            this.chkNoUseSPMValue.Text = "No Use SPM Value Flag";
            this.chkNoUseSPMValue.UseVisualStyleBackColor = true;
            // 
            // lblAlarmCode2
            // 
            this.lblAlarmCode2.AutoSize = true;
            this.lblAlarmCode2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmCode2.Location = new System.Drawing.Point(592, 137);
            this.lblAlarmCode2.Name = "lblAlarmCode2";
            this.lblAlarmCode2.Size = new System.Drawing.Size(85, 13);
            this.lblAlarmCode2.TabIndex = 19;
            this.lblAlarmCode2.Text = "Warn. Out Alarm";
            // 
            // lblAlarmCode1
            // 
            this.lblAlarmCode1.AutoSize = true;
            this.lblAlarmCode1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmCode1.Location = new System.Drawing.Point(592, 12);
            this.lblAlarmCode1.Name = "lblAlarmCode1";
            this.lblAlarmCode1.Size = new System.Drawing.Size(84, 13);
            this.lblAlarmCode1.TabIndex = 17;
            this.lblAlarmCode1.Text = "Spec. Out Alarm";
            // 
            // cdvAlarmCode2
            // 
            this.cdvAlarmCode2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode2.BtnToolTipText = "";
            this.cdvAlarmCode2.ButtonWidth = 20;
            this.cdvAlarmCode2.DescText = "";
            this.cdvAlarmCode2.DisplaySubItemIndex = -1;
            this.cdvAlarmCode2.DisplayText = "";
            this.cdvAlarmCode2.Focusing = null;
            this.cdvAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode2.Index = 0;
            this.cdvAlarmCode2.IsViewBtnImage = false;
            this.cdvAlarmCode2.Location = new System.Drawing.Point(588, 156);
            this.cdvAlarmCode2.MaxLength = 20;
            this.cdvAlarmCode2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode2.Name = "cdvAlarmCode2";
            this.cdvAlarmCode2.ReadOnly = false;
            this.cdvAlarmCode2.SameWidthHeightOfButton = false;
            this.cdvAlarmCode2.SearchSubItemIndex = 0;
            this.cdvAlarmCode2.SelectedDescIndex = -1;
            this.cdvAlarmCode2.SelectedSubItemIndex = -1;
            this.cdvAlarmCode2.SelectionStart = 0;
            this.cdvAlarmCode2.Size = new System.Drawing.Size(120, 20);
            this.cdvAlarmCode2.SmallImageList = null;
            this.cdvAlarmCode2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode2.TabIndex = 20;
            this.cdvAlarmCode2.TextBoxToolTipText = "";
            this.cdvAlarmCode2.TextBoxWidth = 120;
            this.cdvAlarmCode2.VisibleButton = true;
            this.cdvAlarmCode2.VisibleColumnHeader = false;
            this.cdvAlarmCode2.VisibleDescription = false;
            this.cdvAlarmCode2.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cdvAlarmCode1
            // 
            this.cdvAlarmCode1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode1.BtnToolTipText = "";
            this.cdvAlarmCode1.ButtonWidth = 20;
            this.cdvAlarmCode1.DescText = "";
            this.cdvAlarmCode1.DisplaySubItemIndex = -1;
            this.cdvAlarmCode1.DisplayText = "";
            this.cdvAlarmCode1.Focusing = null;
            this.cdvAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode1.Index = 0;
            this.cdvAlarmCode1.IsViewBtnImage = false;
            this.cdvAlarmCode1.Location = new System.Drawing.Point(588, 31);
            this.cdvAlarmCode1.MaxLength = 20;
            this.cdvAlarmCode1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode1.Name = "cdvAlarmCode1";
            this.cdvAlarmCode1.ReadOnly = false;
            this.cdvAlarmCode1.SameWidthHeightOfButton = false;
            this.cdvAlarmCode1.SearchSubItemIndex = 0;
            this.cdvAlarmCode1.SelectedDescIndex = -1;
            this.cdvAlarmCode1.SelectedSubItemIndex = -1;
            this.cdvAlarmCode1.SelectionStart = 0;
            this.cdvAlarmCode1.Size = new System.Drawing.Size(120, 20);
            this.cdvAlarmCode1.SmallImageList = null;
            this.cdvAlarmCode1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode1.TabIndex = 18;
            this.cdvAlarmCode1.TextBoxToolTipText = "";
            this.cdvAlarmCode1.TextBoxWidth = 120;
            this.cdvAlarmCode1.VisibleButton = true;
            this.cdvAlarmCode1.VisibleColumnHeader = false;
            this.cdvAlarmCode1.VisibleDescription = false;
            this.cdvAlarmCode1.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cdvTargetValue
            // 
            this.cdvTargetValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetValue.BtnToolTipText = "";
            this.cdvTargetValue.ButtonWidth = 20;
            this.cdvTargetValue.DescText = "";
            this.cdvTargetValue.DisplaySubItemIndex = -1;
            this.cdvTargetValue.DisplayText = "";
            this.cdvTargetValue.Focusing = null;
            this.cdvTargetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetValue.Index = 0;
            this.cdvTargetValue.IsViewBtnImage = false;
            this.cdvTargetValue.Location = new System.Drawing.Point(310, 101);
            this.cdvTargetValue.MaxLength = 20;
            this.cdvTargetValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.Name = "cdvTargetValue";
            this.cdvTargetValue.ReadOnly = false;
            this.cdvTargetValue.SameWidthHeightOfButton = false;
            this.cdvTargetValue.SearchSubItemIndex = 0;
            this.cdvTargetValue.SelectedDescIndex = -1;
            this.cdvTargetValue.SelectedSubItemIndex = -1;
            this.cdvTargetValue.SelectionStart = 0;
            this.cdvTargetValue.Size = new System.Drawing.Size(120, 20);
            this.cdvTargetValue.SmallImageList = null;
            this.cdvTargetValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetValue.TabIndex = 12;
            this.cdvTargetValue.TextBoxToolTipText = "";
            this.cdvTargetValue.TextBoxWidth = 120;
            this.cdvTargetValue.VisibleButton = true;
            this.cdvTargetValue.VisibleColumnHeader = false;
            this.cdvTargetValue.VisibleDescription = false;
            this.cdvTargetValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharValue_TextBoxKeyPress);
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetValue.Location = new System.Drawing.Point(205, 104);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(68, 13);
            this.lblTargetValue.TabIndex = 11;
            this.lblTargetValue.Text = "Target Value";
            // 
            // txtUpperSpecLimit
            // 
            this.txtUpperSpecLimit.Location = new System.Drawing.Point(310, 37);
            this.txtUpperSpecLimit.MaxLength = 25;
            this.txtUpperSpecLimit.Name = "txtUpperSpecLimit";
            this.txtUpperSpecLimit.Size = new System.Drawing.Size(120, 20);
            this.txtUpperSpecLimit.TabIndex = 8;
            this.txtUpperSpecLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpperSpecLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_TextBoxKeyPress);
            // 
            // lblUSL
            // 
            this.lblUSL.AutoSize = true;
            this.lblUSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSL.Location = new System.Drawing.Point(205, 40);
            this.lblUSL.Name = "lblUSL";
            this.lblUSL.Size = new System.Drawing.Size(91, 13);
            this.lblUSL.TabIndex = 7;
            this.lblUSL.Text = "Upper Spec. Limit";
            // 
            // lblSpecOutCount
            // 
            this.lblSpecOutCount.AutoSize = true;
            this.lblSpecOutCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecOutCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecOutCount.Location = new System.Drawing.Point(8, 66);
            this.lblSpecOutCount.Name = "lblSpecOutCount";
            this.lblSpecOutCount.Size = new System.Drawing.Size(83, 13);
            this.lblSpecOutCount.TabIndex = 3;
            this.lblSpecOutCount.Text = "Spec Out Count";
            // 
            // txtLowerSpecLimit
            // 
            this.txtLowerSpecLimit.Location = new System.Drawing.Point(310, 166);
            this.txtLowerSpecLimit.MaxLength = 25;
            this.txtLowerSpecLimit.Name = "txtLowerSpecLimit";
            this.txtLowerSpecLimit.Size = new System.Drawing.Size(120, 20);
            this.txtLowerSpecLimit.TabIndex = 16;
            this.txtLowerSpecLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLowerSpecLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_TextBoxKeyPress);
            // 
            // txtSpecOutCount
            // 
            this.txtSpecOutCount.Location = new System.Drawing.Point(113, 63);
            this.txtSpecOutCount.MaxLength = 3;
            this.txtSpecOutCount.Name = "txtSpecOutCount";
            this.txtSpecOutCount.Size = new System.Drawing.Size(35, 20);
            this.txtSpecOutCount.TabIndex = 4;
            this.txtSpecOutCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSpecOutCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblLSL
            // 
            this.lblLSL.AutoSize = true;
            this.lblLSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLSL.Location = new System.Drawing.Point(205, 169);
            this.lblLSL.Name = "lblLSL";
            this.lblLSL.Size = new System.Drawing.Size(91, 13);
            this.lblLSL.TabIndex = 15;
            this.lblLSL.Text = "Lower Spec. Limit";
            // 
            // cboSpecType
            // 
            this.cboSpecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecType.Location = new System.Drawing.Point(113, 37);
            this.cboSpecType.Name = "cboSpecType";
            this.cboSpecType.Size = new System.Drawing.Size(76, 21);
            this.cboSpecType.TabIndex = 2;
            this.cboSpecType.SelectedIndexChanged += new System.EventHandler(this.cboSpecType_SelectedIndexChanged);
            // 
            // lblSpecType
            // 
            this.lblSpecType.AutoSize = true;
            this.lblSpecType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecType.Location = new System.Drawing.Point(8, 40);
            this.lblSpecType.Name = "lblSpecType";
            this.lblSpecType.Size = new System.Drawing.Size(68, 13);
            this.lblSpecType.TabIndex = 1;
            this.lblSpecType.Text = "Spec Type";
            // 
            // lblLWL
            // 
            this.lblLWL.AutoSize = true;
            this.lblLWL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLWL.Location = new System.Drawing.Point(205, 135);
            this.lblLWL.Name = "lblLWL";
            this.lblLWL.Size = new System.Drawing.Size(92, 13);
            this.lblLWL.TabIndex = 13;
            this.lblLWL.Text = "Lower Warn. Limit";
            // 
            // txtSpecInfo
            // 
            this.txtSpecInfo.Location = new System.Drawing.Point(8, 106);
            this.txtSpecInfo.MaxLength = 200;
            this.txtSpecInfo.Multiline = true;
            this.txtSpecInfo.Name = "txtSpecInfo";
            this.txtSpecInfo.Size = new System.Drawing.Size(181, 100);
            this.txtSpecInfo.TabIndex = 6;
            // 
            // txtLowerWarnLimit
            // 
            this.txtLowerWarnLimit.Location = new System.Drawing.Point(310, 132);
            this.txtLowerWarnLimit.MaxLength = 25;
            this.txtLowerWarnLimit.Name = "txtLowerWarnLimit";
            this.txtLowerWarnLimit.Size = new System.Drawing.Size(120, 20);
            this.txtLowerWarnLimit.TabIndex = 14;
            this.txtLowerWarnLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLowerWarnLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_TextBoxKeyPress);
            // 
            // txtUpperWarnLimit
            // 
            this.txtUpperWarnLimit.Location = new System.Drawing.Point(310, 70);
            this.txtUpperWarnLimit.MaxLength = 25;
            this.txtUpperWarnLimit.Name = "txtUpperWarnLimit";
            this.txtUpperWarnLimit.Size = new System.Drawing.Size(120, 20);
            this.txtUpperWarnLimit.TabIndex = 10;
            this.txtUpperWarnLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpperWarnLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumeric_TextBoxKeyPress);
            // 
            // lblUWL
            // 
            this.lblUWL.AutoSize = true;
            this.lblUWL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUWL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUWL.Location = new System.Drawing.Point(205, 73);
            this.lblUWL.Name = "lblUWL";
            this.lblUWL.Size = new System.Drawing.Size(92, 13);
            this.lblUWL.TabIndex = 9;
            this.lblUWL.Text = "Upper Warn. Limit";
            // 
            // lblSpecInfo
            // 
            this.lblSpecInfo.AutoSize = true;
            this.lblSpecInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecInfo.Location = new System.Drawing.Point(8, 90);
            this.lblSpecInfo.Name = "lblSpecInfo";
            this.lblSpecInfo.Size = new System.Drawing.Size(90, 13);
            this.lblSpecInfo.TabIndex = 5;
            this.lblSpecInfo.Text = "Spec. Information";
            // 
            // tbpAutoCalc
            // 
            this.tbpAutoCalc.Controls.Add(this.grpAutoCalc);
            this.tbpAutoCalc.Location = new System.Drawing.Point(4, 22);
            this.tbpAutoCalc.Name = "tbpAutoCalc";
            this.tbpAutoCalc.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpAutoCalc.Size = new System.Drawing.Size(720, 216);
            this.tbpAutoCalc.TabIndex = 3;
            this.tbpAutoCalc.Text = "Derived Information";
            // 
            // grpAutoCalc
            // 
            this.grpAutoCalc.Controls.Add(this.spdFormula);
            this.grpAutoCalc.Controls.Add(this.btnChange);
            this.grpAutoCalc.Controls.Add(this.rbtLastColData);
            this.grpAutoCalc.Controls.Add(this.rbtFirstColData);
            this.grpAutoCalc.Controls.Add(this.cdvUseColSetVer);
            this.grpAutoCalc.Controls.Add(this.btnDelCol);
            this.grpAutoCalc.Controls.Add(this.btnAddRBracket);
            this.grpAutoCalc.Controls.Add(this.btnAddLBracket);
            this.grpAutoCalc.Controls.Add(this.cboRBracket);
            this.grpAutoCalc.Controls.Add(this.lblRBracket);
            this.grpAutoCalc.Controls.Add(this.cboLBracket);
            this.grpAutoCalc.Controls.Add(this.lblLBracket);
            this.grpAutoCalc.Controls.Add(this.btnAddOperator);
            this.grpAutoCalc.Controls.Add(this.cboOperator);
            this.grpAutoCalc.Controls.Add(this.lblOperator);
            this.grpAutoCalc.Controls.Add(this.btnAddOperand);
            this.grpAutoCalc.Controls.Add(this.chkOverrideRes);
            this.grpAutoCalc.Controls.Add(this.chkOverrideLot);
            this.grpAutoCalc.Controls.Add(this.cboUseValSeq);
            this.grpAutoCalc.Controls.Add(this.cboCalcType);
            this.grpAutoCalc.Controls.Add(this.cboUseUnitSeq);
            this.grpAutoCalc.Controls.Add(this.lblUseValSeq);
            this.grpAutoCalc.Controls.Add(this.lblCalcType);
            this.grpAutoCalc.Controls.Add(this.lblUseUnitSeq);
            this.grpAutoCalc.Controls.Add(this.cdvUseCharID);
            this.grpAutoCalc.Controls.Add(this.lblUseChar);
            this.grpAutoCalc.Controls.Add(this.cdvUseColSet);
            this.grpAutoCalc.Controls.Add(this.lblUseColSet);
            this.grpAutoCalc.Controls.Add(this.cboValueType);
            this.grpAutoCalc.Controls.Add(this.lblValueType);
            this.grpAutoCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAutoCalc.Enabled = false;
            this.grpAutoCalc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAutoCalc.Location = new System.Drawing.Point(3, 0);
            this.grpAutoCalc.Name = "grpAutoCalc";
            this.grpAutoCalc.Size = new System.Drawing.Size(714, 213);
            this.grpAutoCalc.TabIndex = 1;
            this.grpAutoCalc.TabStop = false;
            // 
            // spdFormula
            // 
            this.spdFormula.AccessibleDescription = "spdFormula, Sheet1, Row 0, Column 0, ";
            this.spdFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spdFormula.BackColor = System.Drawing.SystemColors.Control;
            this.spdFormula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdFormula.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFormula.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdFormula.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFormula.HorizontalScrollBar.Name = "";
            this.spdFormula.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdFormula.HorizontalScrollBar.TabIndex = 14;
            this.spdFormula.HorizontalScrollBarHeight = 16;
            this.spdFormula.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdFormula.Location = new System.Drawing.Point(3, 170);
            this.spdFormula.Name = "spdFormula";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer1;
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
            this.spdFormula.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdFormula.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdFormula.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFormula.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFormula.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;
            this.spdFormula.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFormula_Sheet1});
            this.spdFormula.Size = new System.Drawing.Size(708, 38);
            this.spdFormula.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFormula.TabIndex = 30;
            this.spdFormula.TabStop = false;
            this.spdFormula.TextTipDelay = 200;
            this.spdFormula.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFormula.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFormula.VerticalScrollBar.Name = "";
            this.spdFormula.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdFormula.VerticalScrollBar.TabIndex = 15;
            this.spdFormula.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdFormula.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdFormula_SelectionChanged);
            // 
            // spdFormula_Sheet1
            // 
            this.spdFormula_Sheet1.Reset();
            spdFormula_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFormula_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFormula_Sheet1.ColumnCount = 100;
            spdFormula_Sheet1.ColumnHeader.RowCount = 0;
            spdFormula_Sheet1.RowCount = 1;
            spdFormula_Sheet1.RowHeader.ColumnCount = 0;
            this.spdFormula_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdFormula_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFormula_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdFormula_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFormula_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdFormula_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFormula_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFormula_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFormula_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdFormula_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdFormula_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFormula_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFormula_Sheet1.Rows.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdFormula_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFormula_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFormula_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdFormula_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnChange
            // 
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChange.Location = new System.Drawing.Point(415, 132);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 26);
            this.btnChange.TabIndex = 29;
            this.btnChange.Text = "Change Operand";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // rbtLastColData
            // 
            this.rbtLastColData.AutoSize = true;
            this.rbtLastColData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtLastColData.Location = new System.Drawing.Point(312, 39);
            this.rbtLastColData.Name = "rbtLastColData";
            this.rbtLastColData.Size = new System.Drawing.Size(124, 18);
            this.rbtLastColData.TabIndex = 14;
            this.rbtLastColData.TabStop = true;
            this.rbtLastColData.Text = "Last Collected Data";
            this.rbtLastColData.UseVisualStyleBackColor = true;
            // 
            // rbtFirstColData
            // 
            this.rbtFirstColData.AutoSize = true;
            this.rbtFirstColData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFirstColData.Location = new System.Drawing.Point(312, 14);
            this.rbtFirstColData.Name = "rbtFirstColData";
            this.rbtFirstColData.Size = new System.Drawing.Size(123, 18);
            this.rbtFirstColData.TabIndex = 13;
            this.rbtFirstColData.TabStop = true;
            this.rbtFirstColData.Text = "First Collected Data";
            this.rbtFirstColData.UseVisualStyleBackColor = true;
            // 
            // cdvUseColSetVer
            // 
            this.cdvUseColSetVer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUseColSetVer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUseColSetVer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUseColSetVer.BtnToolTipText = "";
            this.cdvUseColSetVer.ButtonWidth = 20;
            this.cdvUseColSetVer.DescText = "";
            this.cdvUseColSetVer.DisplaySubItemIndex = -1;
            this.cdvUseColSetVer.DisplayText = "";
            this.cdvUseColSetVer.Focusing = null;
            this.cdvUseColSetVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUseColSetVer.Index = 0;
            this.cdvUseColSetVer.IsViewBtnImage = false;
            this.cdvUseColSetVer.Location = new System.Drawing.Point(261, 38);
            this.cdvUseColSetVer.MaxLength = 25;
            this.cdvUseColSetVer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUseColSetVer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUseColSetVer.Name = "cdvUseColSetVer";
            this.cdvUseColSetVer.ReadOnly = true;
            this.cdvUseColSetVer.SameWidthHeightOfButton = false;
            this.cdvUseColSetVer.SearchSubItemIndex = 0;
            this.cdvUseColSetVer.SelectedDescIndex = -1;
            this.cdvUseColSetVer.SelectedSubItemIndex = -1;
            this.cdvUseColSetVer.SelectionStart = 0;
            this.cdvUseColSetVer.Size = new System.Drawing.Size(41, 20);
            this.cdvUseColSetVer.SmallImageList = null;
            this.cdvUseColSetVer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseColSetVer.TabIndex = 4;
            this.cdvUseColSetVer.TextBoxToolTipText = "";
            this.cdvUseColSetVer.TextBoxWidth = 41;
            this.cdvUseColSetVer.VisibleButton = true;
            this.cdvUseColSetVer.VisibleColumnHeader = false;
            this.cdvUseColSetVer.VisibleDescription = false;
            this.cdvUseColSetVer.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvUseColSetVer_SelectedItemChanged);
            this.cdvUseColSetVer.ButtonPress += new System.EventHandler(this.cdvUseColSetVer_ButtonPress);
            // 
            // btnDelCol
            // 
            this.btnDelCol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelCol.Location = new System.Drawing.Point(622, 132);
            this.btnDelCol.Name = "btnDelCol";
            this.btnDelCol.Size = new System.Drawing.Size(88, 26);
            this.btnDelCol.TabIndex = 27;
            this.btnDelCol.Text = "Delete Column";
            this.btnDelCol.UseVisualStyleBackColor = true;
            this.btnDelCol.Click += new System.EventHandler(this.btnDelCol_Click);
            // 
            // btnAddRBracket
            // 
            this.btnAddRBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddRBracket.Location = new System.Drawing.Point(670, 62);
            this.btnAddRBracket.Name = "btnAddRBracket";
            this.btnAddRBracket.Size = new System.Drawing.Size(40, 21);
            this.btnAddRBracket.TabIndex = 26;
            this.btnAddRBracket.Text = "Add";
            this.btnAddRBracket.UseVisualStyleBackColor = true;
            this.btnAddRBracket.Click += new System.EventHandler(this.btnAddRBracket_Click);
            // 
            // btnAddLBracket
            // 
            this.btnAddLBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddLBracket.Location = new System.Drawing.Point(670, 38);
            this.btnAddLBracket.Name = "btnAddLBracket";
            this.btnAddLBracket.Size = new System.Drawing.Size(40, 21);
            this.btnAddLBracket.TabIndex = 23;
            this.btnAddLBracket.Text = "Add";
            this.btnAddLBracket.UseVisualStyleBackColor = true;
            this.btnAddLBracket.Click += new System.EventHandler(this.btnAddLBracket_Click);
            // 
            // cboRBracket
            // 
            this.cboRBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRBracket.Items.AddRange(new object[] {
            ")",
            "))",
            ")))",
            "))))",
            ")))))",
            "))))))",
            ")))))))",
            "))))))))",
            ")))))))))",
            "))))))))))"});
            this.cboRBracket.Location = new System.Drawing.Point(496, 62);
            this.cboRBracket.Name = "cboRBracket";
            this.cboRBracket.Size = new System.Drawing.Size(170, 21);
            this.cboRBracket.TabIndex = 25;
            this.cboRBracket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // lblRBracket
            // 
            this.lblRBracket.AutoSize = true;
            this.lblRBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRBracket.Location = new System.Drawing.Point(440, 66);
            this.lblRBracket.Name = "lblRBracket";
            this.lblRBracket.Size = new System.Drawing.Size(50, 13);
            this.lblRBracket.TabIndex = 24;
            this.lblRBracket.Text = "Bracket )";
            // 
            // cboLBracket
            // 
            this.cboLBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLBracket.Items.AddRange(new object[] {
            "(",
            "((",
            "(((",
            "((((",
            "(((((",
            "((((((",
            "(((((((",
            "((((((((",
            "(((((((((",
            "(((((((((("});
            this.cboLBracket.Location = new System.Drawing.Point(496, 38);
            this.cboLBracket.Name = "cboLBracket";
            this.cboLBracket.Size = new System.Drawing.Size(170, 21);
            this.cboLBracket.TabIndex = 22;
            this.cboLBracket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // lblLBracket
            // 
            this.lblLBracket.AutoSize = true;
            this.lblLBracket.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLBracket.Location = new System.Drawing.Point(440, 42);
            this.lblLBracket.Name = "lblLBracket";
            this.lblLBracket.Size = new System.Drawing.Size(50, 13);
            this.lblLBracket.TabIndex = 21;
            this.lblLBracket.Text = "Bracket (";
            // 
            // btnAddOperator
            // 
            this.btnAddOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddOperator.Location = new System.Drawing.Point(670, 13);
            this.btnAddOperator.Name = "btnAddOperator";
            this.btnAddOperator.Size = new System.Drawing.Size(40, 21);
            this.btnAddOperator.TabIndex = 20;
            this.btnAddOperator.Text = "Add";
            this.btnAddOperator.UseVisualStyleBackColor = true;
            this.btnAddOperator.Click += new System.EventHandler(this.btnAddOperator_Click);
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownWidth = 500;
            this.cboOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperator.Items.AddRange(new object[] {
            "+ : m + n",
            "- : m - n",
            "* : m * n",
            "/ : m / n",
            "MOD : MOD(m, n) - Divides two numbers and returns only the remainder",
            "SIN : SIN(n) - Returns the sine of the specified angle",
            "ASIN : ASIN(n) - Returns the angle whose sine is the specified number",
            "COS : COS(n) - Returns the cosine of the specified angle",
            "ACOS : ACOS(n) - Returns the angle whose cosine is the specified number",
            "TAN : TAN(n) - Returns the tangent of the specified angle",
            "ATAN : ATAN(n) - Returns the angle whose tangent is the specified number",
            "ABS : ABS(n) - Returns the absolute value of a specified number",
            "CEIL : CEIL(n) - Returns the smallest integer greater than or equal to the specif" +
                "ied number",
            "FLOOR : FLOOR(n) - Returns the largest integer less than or equal to the specifie" +
                "d number",
            "ROUND : ROUND(m, n) - Rounds a value to the nearest integer or specified number o" +
                "f decimal places",
            "SIGN : SIGN(n) - Returns a value indicating the sign of a number",
            "POWER : POWER(m, n) - Returns a specified number raised to the specified power",
            "SQRT : SQRT(n) - Returns the square root of a specified number",
            "EXP : EXP(n) - Returns e raised to the specified power",
            "LOG : LOG(m, n) - Returns the logarithm of a specified number"});
            this.cboOperator.Location = new System.Drawing.Point(496, 13);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(170, 21);
            this.cboOperator.TabIndex = 19;
            this.cboOperator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(440, 17);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 18;
            this.lblOperator.Text = "Operator";
            // 
            // btnAddOperand
            // 
            this.btnAddOperand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddOperand.Location = new System.Drawing.Point(312, 132);
            this.btnAddOperand.Name = "btnAddOperand";
            this.btnAddOperand.Size = new System.Drawing.Size(100, 26);
            this.btnAddOperand.TabIndex = 17;
            this.btnAddOperand.Text = "Add Operand";
            this.btnAddOperand.UseVisualStyleBackColor = true;
            this.btnAddOperand.Click += new System.EventHandler(this.btnAddOperand_Click);
            // 
            // chkOverrideRes
            // 
            this.chkOverrideRes.AccessibleDescription = "";
            this.chkOverrideRes.AutoSize = true;
            this.chkOverrideRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverrideRes.Location = new System.Drawing.Point(312, 87);
            this.chkOverrideRes.Name = "chkOverrideRes";
            this.chkOverrideRes.Size = new System.Drawing.Size(121, 18);
            this.chkOverrideRes.TabIndex = 16;
            this.chkOverrideRes.Text = "Override Resource";
            // 
            // chkOverrideLot
            // 
            this.chkOverrideLot.AccessibleDescription = "";
            this.chkOverrideLot.AutoSize = true;
            this.chkOverrideLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverrideLot.Location = new System.Drawing.Point(312, 63);
            this.chkOverrideLot.Name = "chkOverrideLot";
            this.chkOverrideLot.Size = new System.Drawing.Size(90, 18);
            this.chkOverrideLot.TabIndex = 15;
            this.chkOverrideLot.Text = "Override Lot";
            // 
            // cboUseValSeq
            // 
            this.cboUseValSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboUseValSeq.Location = new System.Drawing.Point(108, 137);
            this.cboUseValSeq.Name = "cboUseValSeq";
            this.cboUseValSeq.Size = new System.Drawing.Size(194, 21);
            this.cboUseValSeq.TabIndex = 12;
            this.cboUseValSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // cboCalcType
            // 
            this.cboCalcType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCalcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCalcType.Items.AddRange(new object[] {
            "AV : Average",
            "SM : Sum",
            "MN : Minimum",
            "MX : Maximum",
            "VC : Value Count",
            "OV : One Value"});
            this.cboCalcType.Location = new System.Drawing.Point(108, 111);
            this.cboCalcType.Name = "cboCalcType";
            this.cboCalcType.Size = new System.Drawing.Size(194, 21);
            this.cboCalcType.TabIndex = 10;
            this.cboCalcType.SelectedIndexChanged += new System.EventHandler(this.cboCalcType_SelectedIndexChanged);
            this.cboCalcType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // cboUseUnitSeq
            // 
            this.cboUseUnitSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboUseUnitSeq.Location = new System.Drawing.Point(108, 86);
            this.cboUseUnitSeq.Name = "cboUseUnitSeq";
            this.cboUseUnitSeq.Size = new System.Drawing.Size(194, 21);
            this.cboUseUnitSeq.TabIndex = 8;
            this.cboUseUnitSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // lblUseValSeq
            // 
            this.lblUseValSeq.AutoSize = true;
            this.lblUseValSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseValSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseValSeq.Location = new System.Drawing.Point(9, 141);
            this.lblUseValSeq.Name = "lblUseValSeq";
            this.lblUseValSeq.Size = new System.Drawing.Size(81, 13);
            this.lblUseValSeq.TabIndex = 11;
            this.lblUseValSeq.Text = "Use Value Seq.";
            // 
            // lblCalcType
            // 
            this.lblCalcType.AutoSize = true;
            this.lblCalcType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcType.Location = new System.Drawing.Point(9, 115);
            this.lblCalcType.Name = "lblCalcType";
            this.lblCalcType.Size = new System.Drawing.Size(86, 13);
            this.lblCalcType.TabIndex = 9;
            this.lblCalcType.Text = "Calculation Type";
            // 
            // lblUseUnitSeq
            // 
            this.lblUseUnitSeq.AutoSize = true;
            this.lblUseUnitSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseUnitSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseUnitSeq.Location = new System.Drawing.Point(9, 90);
            this.lblUseUnitSeq.Name = "lblUseUnitSeq";
            this.lblUseUnitSeq.Size = new System.Drawing.Size(73, 13);
            this.lblUseUnitSeq.TabIndex = 7;
            this.lblUseUnitSeq.Text = "Use Unit Seq.";
            // 
            // cdvUseCharID
            // 
            this.cdvUseCharID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUseCharID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUseCharID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUseCharID.BtnToolTipText = "";
            this.cdvUseCharID.ButtonWidth = 20;
            this.cdvUseCharID.DescText = "";
            this.cdvUseCharID.DisplaySubItemIndex = -1;
            this.cdvUseCharID.DisplayText = "";
            this.cdvUseCharID.Focusing = null;
            this.cdvUseCharID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUseCharID.Index = 0;
            this.cdvUseCharID.IsViewBtnImage = false;
            this.cdvUseCharID.Location = new System.Drawing.Point(108, 62);
            this.cdvUseCharID.MaxLength = 25;
            this.cdvUseCharID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUseCharID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUseCharID.Name = "cdvUseCharID";
            this.cdvUseCharID.ReadOnly = true;
            this.cdvUseCharID.SameWidthHeightOfButton = false;
            this.cdvUseCharID.SearchSubItemIndex = 0;
            this.cdvUseCharID.SelectedDescIndex = -1;
            this.cdvUseCharID.SelectedSubItemIndex = -1;
            this.cdvUseCharID.SelectionStart = 0;
            this.cdvUseCharID.Size = new System.Drawing.Size(194, 20);
            this.cdvUseCharID.SmallImageList = null;
            this.cdvUseCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseCharID.TabIndex = 6;
            this.cdvUseCharID.TextBoxToolTipText = "";
            this.cdvUseCharID.TextBoxWidth = 194;
            this.cdvUseCharID.VisibleButton = true;
            this.cdvUseCharID.VisibleColumnHeader = false;
            this.cdvUseCharID.VisibleDescription = false;
            this.cdvUseCharID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvUseCharID_SelectedItemChanged);
            this.cdvUseCharID.ButtonPress += new System.EventHandler(this.cdvUseCharID_ButtonPress);
            // 
            // lblUseChar
            // 
            this.lblUseChar.AutoSize = true;
            this.lblUseChar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseChar.Location = new System.Drawing.Point(9, 66);
            this.lblUseChar.Name = "lblUseChar";
            this.lblUseChar.Size = new System.Drawing.Size(75, 13);
            this.lblUseChar.TabIndex = 5;
            this.lblUseChar.Text = "Use Character";
            // 
            // cdvUseColSet
            // 
            this.cdvUseColSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUseColSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUseColSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUseColSet.BtnToolTipText = "";
            this.cdvUseColSet.ButtonWidth = 20;
            this.cdvUseColSet.DescText = "";
            this.cdvUseColSet.DisplaySubItemIndex = -1;
            this.cdvUseColSet.DisplayText = "";
            this.cdvUseColSet.Focusing = null;
            this.cdvUseColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUseColSet.Index = 0;
            this.cdvUseColSet.IsViewBtnImage = false;
            this.cdvUseColSet.Location = new System.Drawing.Point(108, 38);
            this.cdvUseColSet.MaxLength = 25;
            this.cdvUseColSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUseColSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUseColSet.Name = "cdvUseColSet";
            this.cdvUseColSet.ReadOnly = true;
            this.cdvUseColSet.SameWidthHeightOfButton = false;
            this.cdvUseColSet.SearchSubItemIndex = 0;
            this.cdvUseColSet.SelectedDescIndex = -1;
            this.cdvUseColSet.SelectedSubItemIndex = -1;
            this.cdvUseColSet.SelectionStart = 0;
            this.cdvUseColSet.Size = new System.Drawing.Size(150, 20);
            this.cdvUseColSet.SmallImageList = null;
            this.cdvUseColSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseColSet.TabIndex = 3;
            this.cdvUseColSet.TextBoxToolTipText = "";
            this.cdvUseColSet.TextBoxWidth = 150;
            this.cdvUseColSet.VisibleButton = true;
            this.cdvUseColSet.VisibleColumnHeader = false;
            this.cdvUseColSet.VisibleDescription = false;
            this.cdvUseColSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvUseColSet_SelectedItemChanged);
            this.cdvUseColSet.ButtonPress += new System.EventHandler(this.cdvUseColSet_ButtonPress);
            // 
            // lblUseColSet
            // 
            this.lblUseColSet.AutoSize = true;
            this.lblUseColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseColSet.Location = new System.Drawing.Point(9, 42);
            this.lblUseColSet.Name = "lblUseColSet";
            this.lblUseColSet.Size = new System.Drawing.Size(94, 13);
            this.lblUseColSet.TabIndex = 2;
            this.lblUseColSet.Text = "Use Collection Set";
            // 
            // cboValueType
            // 
            this.cboValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboValueType.Items.AddRange(new object[] {
            "CC : Use Current Collection Set",
            "OC : Use Other Collection Set",
            "CV : Constant Value",
            "LS : Lot Status",
            "LA : Lot Attribute"});
            this.cboValueType.Location = new System.Drawing.Point(108, 13);
            this.cboValueType.Name = "cboValueType";
            this.cboValueType.Size = new System.Drawing.Size(194, 21);
            this.cboValueType.TabIndex = 1;
            this.cboValueType.SelectedIndexChanged += new System.EventHandler(this.cboValueType_SelectedIndexChanged);
            this.cboValueType.Click += new System.EventHandler(this.cboValueType_Click);
            this.cboValueType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDisable_KeyPress);
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueType.Location = new System.Drawing.Point(9, 16);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(71, 13);
            this.lblValueType.TabIndex = 0;
            this.lblValueType.Text = "Value Type";
            // 
            // pnlCharacter
            // 
            this.pnlCharacter.Controls.Add(this.spdCharacter);
            this.pnlCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacter.Location = new System.Drawing.Point(0, 108);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlCharacter.Size = new System.Drawing.Size(734, 112);
            this.pnlCharacter.TabIndex = 1;
            // 
            // spdCharacter
            // 
            this.spdCharacter.AccessibleDescription = "spdCharacter, Sheet1, Row 0, Column 0, ";
            this.spdCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.spdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCharacter.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCharacter.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.HorizontalScrollBar.Name = "";
            this.spdCharacter.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCharacter.HorizontalScrollBar.TabIndex = 2;
            this.spdCharacter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.Location = new System.Drawing.Point(3, 0);
            this.spdCharacter.Name = "spdCharacter";
            this.spdCharacter.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCharacter.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCharacter.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdCharacter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCharacter_Sheet1});
            this.spdCharacter.Size = new System.Drawing.Size(728, 109);
            this.spdCharacter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCharacter.TabIndex = 0;
            this.spdCharacter.TabStop = false;
            this.spdCharacter.TextTipDelay = 200;
            this.spdCharacter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCharacter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.VerticalScrollBar.Name = "";
            this.spdCharacter.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCharacter.VerticalScrollBar.TabIndex = 3;
            this.spdCharacter.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdCharacter_SelectionChanged);
            this.spdCharacter.SetViewportLeftColumn(0, 0, 2);
            this.spdCharacter.SetActiveViewport(0, -1, -1);
            // 
            // spdCharacter_Sheet1
            // 
            this.spdCharacter_Sheet1.Reset();
            spdCharacter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCharacter_Sheet1.ColumnCount = 24;
            spdCharacter_Sheet1.RowCount = 0;
            this.spdCharacter_Sheet1.ActiveColumnIndex = -1;
            this.spdCharacter_Sheet1.ActiveRowIndex = -1;
            this.spdCharacter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Value Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Display Precision";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Value Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Default Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Option Input";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Blank Save";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = " Default Unit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Spec. Type";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Spec. Out Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Target Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Spec. Information";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Derived Parameter";
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.spdCharacter_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(0).Label = "Character";
            this.spdCharacter_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(0).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(1).Label = "Description";
            this.spdCharacter_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(1).Width = 120F;
            this.spdCharacter_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(2).Label = "Unit Count";
            this.spdCharacter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(2).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(3).Label = "Value Count";
            this.spdCharacter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(3).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(4).Label = "Display Precision";
            this.spdCharacter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(4).Width = 55F;
            this.spdCharacter_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(5).Label = "Value Table";
            this.spdCharacter_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(5).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(6).Label = "Default Value";
            this.spdCharacter_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(6).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Label = "Option Input";
            this.spdCharacter_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Label = "Blank Save";
            this.spdCharacter_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Label = " Default Unit";
            this.spdCharacter_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(10).Label = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(10).Width = 55F;
            this.spdCharacter_Sheet1.Columns.Get(11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(11).Label = "Unit Table";
            this.spdCharacter_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(11).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Label = "Spec. Type";
            this.spdCharacter_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(13).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(13).Label = "Spec. Out Count";
            this.spdCharacter_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(14).Label = "Target Value";
            this.spdCharacter_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(15).Label = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(15).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(16).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(16).Label = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(16).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(17).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(17).Label = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(17).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(18).Label = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(18).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(19).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(19).Label = "Spec. Information";
            this.spdCharacter_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(19).Width = 200F;
            this.spdCharacter_Sheet1.Columns.Get(20).Label = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(20).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(21).Label = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(21).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(22).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Label = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(23).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(23).Label = "Derived Parameter";
            this.spdCharacter_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(23).Width = 200F;
            this.spdCharacter_Sheet1.FrozenColumnCount = 2;
            this.spdCharacter_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCharacter_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdCharacter_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCharacter_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdCharacter_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdCharacter_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spCenter
            // 
            this.spCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.spCenter.Location = new System.Drawing.Point(0, 105);
            this.spCenter.Name = "spCenter";
            this.spCenter.Size = new System.Drawing.Size(734, 3);
            this.spCenter.TabIndex = 3;
            this.spCenter.TabStop = false;
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.spdVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(0, 0);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3);
            this.pnlVersion.Size = new System.Drawing.Size(734, 105);
            this.pnlVersion.TabIndex = 0;
            // 
            // spdVersion
            // 
            this.spdVersion.AccessibleDescription = "spdVersion, Sheet1, Row 0, Column 0, ";
            this.spdVersion.BackColor = System.Drawing.SystemColors.Control;
            this.spdVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdVersion.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdVersion.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.HorizontalScrollBar.Name = "";
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdVersion.HorizontalScrollBar.TabIndex = 2;
            this.spdVersion.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.Location = new System.Drawing.Point(3, 3);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(728, 99);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 0;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdVersion.VerticalScrollBar.TabIndex = 3;
            this.spdVersion.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdVersion_SelectionChanged);
            this.spdVersion.SetViewportLeftColumn(0, 0, 1);
            this.spdVersion.SetActiveViewport(0, -1, -1);
            // 
            // spdVersion_Sheet1
            // 
            this.spdVersion_Sheet1.Reset();
            spdVersion_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdVersion_Sheet1.ColumnCount = 9;
            spdVersion_Sheet1.RowCount = 0;
            this.spdVersion_Sheet1.ActiveColumnIndex = -1;
            this.spdVersion_Sheet1.ActiveRowIndex = -1;
            this.spdVersion_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Version";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Apply Start Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Apply End Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Approval";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Approval Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Release Time";
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Label = "Version";
            this.spdVersion_Sheet1.Columns.Get(0).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Width = 45F;
            this.spdVersion_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(1).Label = "Apply Start Time";
            this.spdVersion_Sheet1.Columns.Get(1).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(1).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(2).Label = "Apply End Time";
            this.spdVersion_Sheet1.Columns.Get(2).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(2).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Label = "Approval";
            this.spdVersion_Sheet1.Columns.Get(3).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Width = 55F;
            this.spdVersion_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(4).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(4).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(5).Label = "Approval Time";
            this.spdVersion_Sheet1.Columns.Get(5).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(5).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 50F;
            this.spdVersion_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(7).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(7).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(8).Label = "Release Time";
            this.spdVersion_Sheet1.Columns.Get(8).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(8).Width = 110F;
            this.spdVersion_Sheet1.FrozenColumnCount = 1;
            this.spdVersion_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdVersion_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdVersion_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdVersion_Sheet1.RowHeader.Visible = false;
            this.spdVersion_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdVersion_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdVersion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataList.Location = new System.Drawing.Point(168, 17);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "cdvTableList";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.TabStop = false;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.Visible = false;
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(43, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(687, 263);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 20);
            this.btnDown.TabIndex = 18;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(644, 263);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 20);
            this.btnUp.TabIndex = 17;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmEDCSetupAttachCharacter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(734, 542);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmEDCSetupAttachCharacter";
            this.Text = "Attach Character to Version";
            this.Activated += new System.EventHandler(this.frmEDCSetupAttachCharacter_Activated);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.btnUp, 0);
            this.Controls.SetChildIndex(this.btnDown, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).EndInit();
            this.pnlCharInfo.ResumeLayout(false);
            this.tabAttachCharacter.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefaultValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValueTable)).EndInit();
            this.tbpUnitInfo.ResumeLayout(false);
            this.grpUnitInfo.ResumeLayout(false);
            this.pnlUnitDescList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).EndInit();
            this.pnlUnit.ResumeLayout(false);
            this.pnlUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnitTable)).EndInit();
            this.tbpLimitInfo.ResumeLayout(false);
            this.grpLimitInfo.ResumeLayout(false);
            this.grpLimitInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSpec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).EndInit();
            this.tbpAutoCalc.ResumeLayout(false);
            this.grpAutoCalc.ResumeLayout(false);
            this.grpAutoCalc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFormula_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseColSetVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseColSet)).EndInit();
            this.pnlCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Defintion"

        //spdVersion
        private const int COL1_VERSION = 0;

        //spdCharacter
        private const int COL2_CHAR_ID = 0;
        private const int COL2_UNIT_COUNT = 2;
        
        //spdUnit
        private const int COL3_NULL = 0;
        private const int COL3_UNIT = 1;
        private const int COL3_BUTTON = 2;
        
#endregion
        
#region " Variable Definition"
        
        bool LoadFlag;
        
        public struct Unit_Def
        {
            public string CharacterID;
            public int UnitCount;
            public string UnitTable;
        }
        
        private struct CHAR_FORMULA_INFO
        {
            public string s_value_type;
            public string s_use_col_set_id;
            public int i_use_col_set_ver;
            public string s_use_char_id;
            public int i_use_unit_seq;
            public string s_calc_type;
            public int i_use_value_seq;
            public string s_const_value;
            public bool b_first_col_data;
            public bool b_last_col_data;
            public bool b_override_lot;
            public bool b_override_res;
            public string s_operator;
            public string s_bracket;

            public int i_unit_count;
            public int i_value_count;
        }


#endregion
        
#region " Function Definition"

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
                    case "1":   // When Form Loaded

                        //Initialize
                        MPCF.FieldClear(this);

                        MPCF.ClearList(spdVersion, true);
                        MPCF.ClearList(spdCharacter, true);
                        MPCF.ClearList(spdUnit, true);

                        cdvDefaultValue.VisibleButton = false;
                        cdvTargetValue.VisibleButton = false;

                        chkBlankSave.Enabled = false;

                        chkUnitNullFlag.Checked = false;
                        chkDefaultUnit.Checked = false;
                        pnlUnitDescList.Visible = false;
                        chkDefaultUnitOvr.Enabled = false;
                        chkDerivedFlag.Checked = false;
                        txtDerivedParameter.Visible = false;

                        AddSpecTypeItems(ref cboSpecType);

                        cboSpecType.SelectedIndex = 0;

                        cdvCharID.Tag = null;

                        break;

                    case "2":   // When Collection Set Selected 
                        
                        MPCF.FieldClear(this, cdvCollectionSet);
                        MPCF.ClearList(spdVersion, true);
                        MPCF.ClearList(spdCharacter, true);
                        MPCF.ClearList(spdUnit, true);

                        cdvDefaultValue.VisibleButton = false;
                        cdvTargetValue.VisibleButton = false;

                        chkUnitNullFlag.Checked = false;
                        chkBlankSave.Enabled = false;
                        chkDefaultUnit.Checked = false;
                        pnlUnitDescList.Visible = false;
                        chkDefaultUnitOvr.Enabled = false;
                        chkDerivedFlag.Checked = false;
                        txtDerivedParameter.Visible = false;

                        AddSpecTypeItems(ref cboSpecType);

                        cboSpecType.SelectedIndex = 0;

                        cdvCharID.Tag = null;

                        break;

                    case "3":   // When Collection Set Version List Clicked
                        
                        MPCF.ClearList(spdCharacter, true);
                        MPCF.ClearList(spdUnit, true);
                        MPCF.FieldClear(this.grpGeneral);
                        MPCF.FieldClear(this.grpUnitInfo);
                        MPCF.ClearList(spdUnit, true);
                        MPCF.FieldClear(this.grpLimitInfo);

                        cdvDefaultValue.VisibleButton = false;
                        cdvTargetValue.VisibleButton = false;

                        chkUnitNullFlag.Checked = false;
                        chkBlankSave.Enabled = false;
                        chkDefaultUnit.Checked = false;
                        pnlUnitDescList.Visible = false;
                        chkDefaultUnitOvr.Enabled = false;
                        chkDerivedFlag.Checked = false;
                        txtDerivedParameter.Visible = false;

                        cdvCharID.Tag = null;
                        
                        break;

                    case "4":   // When Character List Clicked

                        MPCF.FieldClear(this.grpGeneral);
                        MPCF.FieldClear(this.grpUnitInfo);
                        MPCF.ClearList(spdUnit, true);
                        MPCF.FieldClear(this.grpLimitInfo);

                        cdvDefaultValue.VisibleButton = false;
                        cdvTargetValue.VisibleButton = false;

                        chkUnitNullFlag.Checked = false;
                        chkBlankSave.Enabled = false;
                        chkDefaultUnit.Checked = false;
                        pnlUnitDescList.Visible = false;
                        chkDefaultUnitOvr.Enabled = false;
                        chkDerivedFlag.Checked = false;
                        txtDerivedParameter.Visible = false;

                        cdvCharID.Tag = null;

                        break;

                    case "5":   // When Character Changed

                        MPCF.FieldClear(this.grpGeneral, cdvCharID);
                        MPCF.FieldClear(this.grpUnitInfo);
                        MPCF.ClearList(spdUnit, true);
                        MPCF.FieldClear(this.grpLimitInfo);

                        cdvDefaultValue.VisibleButton = false;
                        cdvTargetValue.VisibleButton = false;

                        chkUnitNullFlag.Checked = false;
                        chkBlankSave.Enabled = false;
                        chkDefaultUnit.Checked = false;
                        pnlUnitDescList.Visible = false;
                        chkDefaultUnitOvr.Enabled = false;
                        chkDerivedFlag.Checked = false;
                        txtDerivedParameter.Visible = false;

                        cdvCharID.Tag = null;

                        break;
                }

                spdFormula.ActiveSheet.ColumnCount = 0;
                spdFormula.ActiveSheet.ColumnCount = 1;

                cboValueType.Text = "";
                cdvUseColSet.Text = "";
                cdvUseColSetVer.Text = "";
                cdvUseCharID.Text = "";
                cboUseUnitSeq.Text = "";
                cboUseUnitSeq.Items.Clear();
                cboCalcType.Text = "";
                cboUseValSeq.Text = "";
                cboUseValSeq.Items.Clear();
                cboUseValSeq.DropDownStyle = ComboBoxStyle.DropDown;
                lblUseValSeq.Text = MPCF.FindLanguage("Use Value Seq.", 0);

                rbtFirstColData.Checked = false;
                rbtLastColData.Checked = true;
                chkOverrideLot.Checked = false;
                chkOverrideRes.Checked = false;

                cboOperator.Text = "";
                cboLBracket.Text = "";
                cboRBracket.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(char ProcStep)
        {
            int i = 0;
            
            try
            {
                if (MPCF.CheckValue(cdvCollectionSet, 1) == false)
                {
                    cdvCollectionSet.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvCharID, 1) == false)
                {
                    tabAttachCharacter.SelectedTab = tbpGeneral;
                    cdvCharID.Focus();
                    return false;
                }
                if (spdVersion.ActiveSheet.RowCount == 0 || spdVersion.ActiveSheet.SelectionCount == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(152));
                    return false;
                }
                if ((MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 3)) != "" || MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 6)) != ""))
                {
                    return false;
                }
                
                switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                {
                    case MPGC.MP_STEP_CREATE:

                        // Unit Count Check
                        if (MPCF.CheckValue(txtUnitCount, 1) == false)
                        {
                            tabAttachCharacter.SelectedTab = tbpGeneral;
                            txtUnitCount.Focus();
                            txtUnitCount.SelectAll();
                            return false;
                        }
                        if (MPCF.CheckValue(txtUnitCount, 2, false, false, "", "" , "") == false)
                        {
                            tabAttachCharacter.SelectedTab = tbpGeneral;
                            txtUnitCount.Focus();
                            txtUnitCount.SelectAll();
                            return false;
                        }
                        else
                        {
                            if (MPCF.ToInt(txtUnitCount.Text) <= 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(141));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtUnitCount.Focus();
                                txtUnitCount.SelectAll();
                                return false;
                            }
                            if (MPCF.ToInt(txtUnitCount.Text) > MPGC.MP_UNIT_COUNT_MAX) // 500
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(141));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtUnitCount.Focus();
                                txtUnitCount.SelectAll();
                                return false;
                            }
                        }
                        
                        //Value Count Validation
                        if (MPCF.CheckValue(txtValueCount, 1) == false)
                        {
                            tabAttachCharacter.SelectedTab = tbpGeneral;
                            txtValueCount.Focus();
                            txtValueCount.SelectAll();
                            return false;
                        }
                        if (MPCF.CheckValue(txtValueCount, 2) == false)
                        {
                            tabAttachCharacter.SelectedTab = tbpGeneral;
                            txtValueCount.Focus();
                            txtValueCount.SelectAll();
                            return false;
                        }
                        else
                        {
                            if (MPCF.ToInt(txtValueCount.Text) <= 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(142));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtValueCount.Focus();
                                txtValueCount.SelectAll();
                                return false;
                            }
                            if (MPCF.ToInt(txtValueCount.Text) > MPGC.MP_VALUE_COUNT_MAX) // 1000
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(142));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtValueCount.Focus();
                                txtValueCount.SelectAll();
                                return false;
                            }
                        }
                        
                        if (chkDerivedFlag.Checked == true)
                        {
                            if (MPCF.ToInt(txtUnitCount.Text) > 1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(354));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtUnitCount.Focus();
                                txtUnitCount.SelectAll();
                                return false;
                            }
                            //if (MPCF.ToInt(txtValueCount.Text) > 1)
                            //{
                            //    MPCF.ShowMsgBox(MPCF.GetMessage(354));
                            //    tabAttachCharacter.SelectedTab = tbpGeneral;
                            //    txtValueCount.Focus();
                            //    txtValueCount.SelectAll();
                            //    return false;
                            //}
                        }

                        //Display PrecisionValidation
                        if (MPCF.Trim(txtDisplayPrecision.Text) != "")
                        {
                            if (MPCF.CheckValue(txtDisplayPrecision, 2, false, false, "", "" , "") == false)
                            {
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtDisplayPrecision.Focus();
                                txtDisplayPrecision.SelectAll();
                                return false;
                            }
                            if (MPCF.ToInt(txtDisplayPrecision.Text) > 9)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(175));
                                tabAttachCharacter.SelectedTab = tbpGeneral;
                                txtDisplayPrecision.Focus();
                                txtDisplayPrecision.SelectAll();
                                return false;
                            }
                        }

                        if (chkDefaultUnit.Checked == true)
                        {
                            for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                            {
                                if (Convert.ToBoolean(spdUnit.ActiveSheet.Cells[i, COL3_NULL].Value) == false)
                                {
                                    if (MPCF.Trim(spdUnit.ActiveSheet.Cells[i, COL3_UNIT].Value) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        tabAttachCharacter.SelectedTab = tbpUnitInfo;
                                        spdUnit.ActiveSheet.SetActiveCell(i, COL3_UNIT);
                                        return false;
                                    }
                                }
                            }
                        }
                                                
                        //Spec Out Count Validation
                        if (MPCF.Trim(txtSpecOutCount.Text) != "")
                        {
                            if (MPCF.CheckValue(txtSpecOutCount, 2) == false)
                            {
                                tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                txtSpecOutCount.Focus();
                                txtSpecOutCount.SelectAll();
                                return false;
                            }
                        }

                        // When Character Type is Numeric
                        if (MPCF.Trim(cdvCharID.Tag) == "N")
                        {                
                            if (cboSpecType.SelectedIndex == 1)
                            {
                                if (MPCF.CheckValue(txtUpperSpecLimit, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtUpperSpecLimit.Focus();
                                    txtUpperSpecLimit.SelectAll();
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLowerSpecLimit, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtLowerSpecLimit.Focus();
                                    txtLowerSpecLimit.SelectAll();
                                    return false;
                                }
                            }
                            else if (cboSpecType.SelectedIndex == 2)
                            {
                                if (MPCF.CheckValue(txtUpperSpecLimit, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtUpperSpecLimit.Focus();
                                    txtUpperSpecLimit.SelectAll();
                                    return false;
                                }
                            }
                            else if (cboSpecType.SelectedIndex == 3)
                            {
                                if (MPCF.CheckValue(txtLowerSpecLimit, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtLowerSpecLimit.Focus();
                                    txtLowerSpecLimit.SelectAll();
                                    return false;
                                }
                            }

                            if (MPCF.Trim(cdvDefaultValue.Text) != "")
                            {
                                if (MPCF.CheckValue(cdvDefaultValue, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpGeneral;
                                    cdvDefaultValue.Focus();
                                    return false;
                                }
                            }

                            if (MPCF.Trim(cdvTargetValue.Text) != "")
                            {
                                if (MPCF.CheckValue(cdvTargetValue, 2) == false)
                                {
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    cdvTargetValue.Focus();
                                    return false;
                                }
                            }

                            if (txtUpperSpecLimit.Text != "" && txtLowerSpecLimit.Text != "")
                            {
                                if (MPCF.ToDbl(txtUpperSpecLimit.Text) <= MPCF.ToDbl(txtLowerSpecLimit.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(261));
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtLowerSpecLimit.Focus();
                                    txtLowerSpecLimit.SelectAll();
                                    return false;
                                }
                            }

                            if (txtUpperWarnLimit.Text != "" && txtLowerWarnLimit.Text != "")
                            {
                                if (MPCF.ToDbl(txtUpperWarnLimit.Text) <= MPCF.ToDbl(txtLowerWarnLimit.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(262));
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtLowerWarnLimit.Focus();
                                    txtLowerWarnLimit.SelectAll();
                                    return false;
                                }
                            }    
                                                                                
                            if (txtUpperSpecLimit.Text != "" && txtUpperWarnLimit.Text != "")
                            {
                                if (MPCF.ToDbl(txtUpperSpecLimit.Text) <= MPCF.ToDbl(txtUpperWarnLimit.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(259));
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtUpperWarnLimit.Focus();
                                    txtUpperWarnLimit.SelectAll();
                                    return false;
                                }
                            }
                            
                            if (txtLowerWarnLimit.Text != "" && txtLowerSpecLimit.Text != "")
                            {
                                if (MPCF.ToDbl(txtLowerWarnLimit.Text) <= MPCF.ToDbl(txtLowerSpecLimit.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(260));
                                    tabAttachCharacter.SelectedTab = tbpLimitInfo;
                                    txtLowerSpecLimit.Focus();
                                    txtLowerSpecLimit.SelectAll();
                                    return false;
                                }
                            }                        
                                                                                    
                        }
                        
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        //Attach_Character()
        //      - Attach Character
        //Return Value
        //      - Boolean : True or False
        //Arguments
        //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)
        
        private bool Attach_Character(char ProcStep)
        {
            TRSNode in_node = new TRSNode("ATTACH_CHARACTER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode unit_item;
            
            int i = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("COL_SET_ID", cdvCollectionSet.Text);
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRow.Index, 0)));

                //General Tab
                in_node.AddString("CHAR_ID", MPCF.Trim(cdvCharID.Text));
                in_node.AddInt("UNIT_COUNT", MPCF.ToInt(txtUnitCount.Text));
                in_node.AddInt("VALUE_COUNT", MPCF.ToInt(txtValueCount.Text));
                in_node.AddInt("DISPLAY_PRECISION", MPCF.ToInt(txtDisplayPrecision.Text));
                in_node.AddString("VALUE_TBL", MPCF.Trim(cdvValueTable.Text));
                in_node.AddString("DEF_VALUE", MPCF.Trim(cdvDefaultValue.Text));
                in_node.AddChar("OPT_INPUT_FLAG", (chkOptionalInput.Checked == true ? 'Y' : ' '));
                in_node.AddChar("BLANK_REC_SAVE_FLAG", (chkBlankSave.Checked == true ? 'Y' : ' '));
                in_node.AddChar("DERIVED_PARAM_FLAG", (chkDerivedFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("NO_USE_SPM_VALUE_FLAG", (chkNoUseSPMValue.Checked == true ? 'Y' : ' '));

                in_node.AddInt("MIN_VALUE_COUNT", MPCF.ToInt(txtMinValueCount.Text));
                in_node.AddInt("MIN_UNIT_COUNT", MPCF.ToInt(txtMinUnitCount.Text));
                in_node.AddChar("OPT_UNIT_FLAG", (chkOptUnitFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("MIN_VALUE_BY_LOT_QTY", (chkMinValueByLotQty.Checked == true ? 'Y' : ' '));
                in_node.AddChar("MIN_UNIT_BY_LOT_QTY", (chkMinUnitByLotQty.Checked == true ? 'Y' : ' '));

                //Unit Information Tab
                if (chkUseCharUnitFlag.Checked == true)
                {
                    in_node.AddChar("DEF_UNIT_FLAG", 'C');
                    in_node.AddChar("DEF_UNIT_OVR_FLAG", ' ');
                    in_node.AddString("UNIT_TBL", "");
                }
                else
                {
                    if (chkUnitNullFlag.Checked == true)
                    {
                        in_node.AddChar("DEF_UNIT_FLAG", 'E');
                        in_node.AddChar("DEF_UNIT_OVR_FLAG", ' ');
                        in_node.AddString("UNIT_TBL", "");
                    }
                    else
                    {
                        in_node.AddChar("DEF_UNIT_FLAG", (chkDefaultUnit.Checked == true ? 'Y' : ' '));
                        in_node.AddChar("DEF_UNIT_OVR_FLAG", (chkDefaultUnitOvr.Checked == true ? 'Y' : ' '));
                        in_node.AddString("UNIT_TBL", MPCF.Trim(cdvUnitTable.Text));
                    }
                }                

                //Limit Information Tab
                if (cboSpecType.SelectedIndex == 1)
                {
                    in_node.AddChar("SPEC_TYPE", 'B');
                }
                else if (cboSpecType.SelectedIndex == 2)
                {
                    in_node.AddChar("SPEC_TYPE", 'U');
                }
                else if (cboSpecType.SelectedIndex == 3)
                {
                    in_node.AddChar("SPEC_TYPE", 'L');
                }
                in_node.AddInt("SPEC_OUT_COUNT", MPCF.ToInt(txtSpecOutCount.Text));
                in_node.AddString("TARGET_VALUE", MPCF.Trim(cdvTargetValue.Text));
                in_node.AddString("UPPER_SPEC_LIMIT", MPCF.Trim(txtUpperSpecLimit.Text));
                in_node.AddString("LOWER_SPEC_LIMIT", MPCF.Trim(txtLowerSpecLimit.Text));
                in_node.AddString("UPPER_WARN_LIMIT", MPCF.Trim(txtUpperWarnLimit.Text));
                in_node.AddString("LOWER_WARN_LIMIT", MPCF.Trim(txtLowerWarnLimit.Text));
                in_node.AddString("SPEC_INFO", MPCF.Trim(txtSpecInfo.Text));

                in_node.AddString("SPEC_OUT_ALARM", MPCF.Trim(cdvAlarmCode1.Text));
                in_node.AddString("WARN_OUT_ALARM", MPCF.Trim(cdvAlarmCode2.Text));

                // Default Unit List
                if (chkUnitNullFlag.Checked == false && chkDefaultUnit.Checked == true)
                {
                    for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                    {
                        unit_item = in_node.AddNode("DEF_UNIT_LIST");

                        unit_item.AddInt("UNIT_SEQ_NUM", i + 1);
                        unit_item.AddChar("NULL_FLAG", Convert.ToBoolean(spdUnit.ActiveSheet.GetValue(i, COL3_NULL)) == true ? 'Y' : ' ');
                        unit_item.AddString("DEF_UNIT_ID", MPCF.Trim(spdUnit.ActiveSheet.GetValue(i, COL3_UNIT)));
                    }
                }

                Attach_Character_Formula(in_node);

                if (MPCR.CallService("EDC", "EDC_Attach_Character", in_node, ref out_node) == false)
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
        
        // View_Attach_Character()
        //       - View Attach Character Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       -
        //
        private bool View_Attach_Character(int iRow)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_OUT");

            int i = 0;
            int iLastRow = 0;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvCollectionSet.Text));
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, COL1_VERSION)));
                in_node.AddString("CHAR_ID", MPCF.Trim(spdCharacter.ActiveSheet.GetValue(iRow, COL2_CHAR_ID).ToString()));

                if (MPCR.CallService("EDC", "EDC_View_Attach_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                // General
                cdvCharID.Text = MPCF.Trim(out_node.GetString("CHAR_ID"));
                cdvCharID.Tag = MPCF.Trim(out_node.GetChar("VALUE_TYPE"));
                txtUnitCount.Text = MPCF.Trim(out_node.GetInt("UNIT_COUNT"));
                txtValueCount.Text = MPCF.Trim(out_node.GetInt("VALUE_COUNT"));
                txtDisplayPrecision.Text = MPCF.Trim(out_node.GetInt("DISPLAY_PRECISION"));
                cdvValueTable.Text = MPCF.Trim(out_node.GetString("VALUE_TBL"));
                cdvDefaultValue.Text = MPCF.Trim(out_node.GetString("DEF_VALUE"));

                if (cdvValueTable.Text == "")
                {
                    cdvDefaultValue.VisibleButton = false;
                    cdvDefaultValue.ReadOnly = false;

                    cdvTargetValue.VisibleButton = false;
                    cdvTargetValue.ReadOnly = false;

                }
                else
                {
                    cdvDefaultValue.VisibleButton = true;
                    cdvDefaultValue.ReadOnly = true;

                    cdvDefaultValue.Init();
                    MPCF.InitListView(cdvDefaultValue.GetListView);
                    cdvDefaultValue.Columns.Add("Data", 50, HorizontalAlignment.Left);
                    cdvDefaultValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvDefaultValue.SelectedSubItemIndex = 0;
                    BASLIST.ViewGCMDataList(cdvDefaultValue.GetListView, '1', cdvValueTable.Text);
                    if (cdvDefaultValue.InsertEmptyRow(0, 1) == false)
                    {
                        return false;
                    }

                    cdvTargetValue.VisibleButton = true;
                    cdvTargetValue.ReadOnly = true;

                    cdvTargetValue.Init();
                    MPCF.InitListView(cdvTargetValue.GetListView);
                    cdvTargetValue.Columns.Add("Data", 50, HorizontalAlignment.Left);
                    cdvTargetValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvTargetValue.SelectedSubItemIndex = 0;
                    BASLIST.ViewGCMDataList(cdvTargetValue.GetListView, '1', cdvValueTable.Text);
                    if (cdvTargetValue.InsertEmptyRow(0, 1) == false)
                    {
                        return false;
                    }
                }

                chkOptionalInput.Checked = out_node.GetChar("OPT_INPUT_FLAG") == 'Y' ? true : false;
                chkBlankSave.Checked = out_node.GetChar("BLANK_REC_SAVE_FLAG") == 'Y' ? true : false;
                chkDerivedFlag.Checked = out_node.GetChar("DERIVED_PARAM_FLAG") == 'Y' ? true : false;
                chkNoUseSPMValue.Checked = out_node.GetChar("NO_USE_SPM_VALUE_FLAG") == 'Y' ? true : false;
                txtDerivedParameter.Text = out_node.GetString("DERIVED_PARAMETER");

                chkOptUnitFlag.Checked = out_node.GetChar("OPT_UNIT_FLAG") == 'Y' ? true : false;
                chkMinValueByLotQty.Checked = out_node.GetChar("MIN_VALUE_BY_LOT_QTY") == 'Y' ? true : false;
                chkMinUnitByLotQty.Checked = out_node.GetChar("MIN_UNIT_BY_LOT_QTY") == 'Y' ? true : false;
                txtMinValueCount.Text = MPCF.Trim(out_node.GetInt("MIN_VALUE_COUNT"));
                txtMinUnitCount.Text = MPCF.Trim(out_node.GetInt("MIN_UNIT_COUNT"));


                // Unit Information
                cdvUnitTable.Text = MPCF.Trim(out_node.GetString("UNIT_TBL"));
                if (MPCF.Trim(out_node.GetChar("DEF_UNIT_FLAG")) == "C")
                {
                    chkUseCharUnitFlag.Checked = true;
                }
                else
                {
                    chkUseCharUnitFlag.Checked = false;

                    if (MPCF.Trim(out_node.GetChar("DEF_UNIT_FLAG")) == "E")
                    {
                        chkUnitNullFlag.Checked = true;
                    }
                    else
                    {
                        chkUnitNullFlag.Checked = false;
                    }
                }                

                chkDefaultUnit.Checked = (MPCF.Trim(out_node.GetChar("DEF_UNIT_FLAG")) == "Y") ? true : false;                
                chkDefaultUnitOvr.Checked = (MPCF.Trim(out_node.GetChar("DEF_UNIT_OVR_FLAG")) == "Y") ? true : false;
                                
                // Limit Information
                if (MPCF.Trim(out_node.GetChar("VALUE_TYPE")) == "N")
                {
                    cboSpecType.Enabled = true;

                    if (MPCF.Trim(out_node.GetChar("SPEC_TYPE")) == "B")
                    {
                        cboSpecType.SelectedIndex = 1;
                    }
                    else if (MPCF.Trim(out_node.GetChar("SPEC_TYPE")) == "U")
                    {
                        cboSpecType.SelectedIndex = 2;
                    }
                    else if (MPCF.Trim(out_node.GetChar("SPEC_TYPE")) == "L")
                    {
                        cboSpecType.SelectedIndex = 3;
                    }
                    else
                    {
                        cboSpecType.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboSpecType.Enabled = false;
                }
                txtSpecOutCount.Text = MPCF.Trim(out_node.GetInt("SPEC_OUT_COUNT"));
                cdvTargetValue.Text = MPCF.Trim(out_node.GetString("TARGET_VALUE"));
                if (MPCF.Trim(out_node.GetChar("VALUE_TYPE")) == "N")
                {
                    SetEnableLimit(true);
                    txtUpperSpecLimit.Text = MPCF.Trim(out_node.GetString("UPPER_SPEC_LIMIT"));
                    txtLowerSpecLimit.Text = MPCF.Trim(out_node.GetString("LOWER_SPEC_LIMIT"));
                    txtUpperWarnLimit.Text = MPCF.Trim(out_node.GetString("UPPER_WARN_LIMIT"));
                    txtLowerWarnLimit.Text = MPCF.Trim(out_node.GetString("LOWER_WARN_LIMIT"));
                }
                else
                {
                    SetEnableLimit(false);
                }
               
                txtSpecInfo.Text = MPCF.Trim(out_node.GetString("SPEC_INFO"));
                cdvAlarmCode1.Text = MPCF.Trim(out_node.GetString("SPEC_OUT_ALARM"));
                cdvAlarmCode2.Text = MPCF.Trim(out_node.GetString("WARN_OUT_ALARM"));

                MPCF.ClearList(spdUnit);

                // Unit Information - Unit Defalut Value List
                if (MPCF.Trim(out_node.GetChar("DEF_UNIT_FLAG")) == "Y")
                {
                    pnlUnitDescList.Visible = true;

                    int iUnitCount = out_node.GetInt("UNIT_COUNT");

                    if (out_node.GetInt("UNIT_COUNT") > 0)
                    {
                        if (iUnitCount >= out_node.GetList(0).Count)
                        {
                            for (i = 0; i <= iUnitCount - 1; i++)
                            {
                                if (i <= out_node.GetList(0).Count - 1)
                                {
                                    spdUnit.ActiveSheet.RowCount++;

                                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NULL_FLAG")) == "Y")
                                    {
                                        if (i == 0)
                                        {
                                            btnAllCheck.Tag = "CHECK";
                                            btnAllCheck.Text = "All Uncheck";
                                        }
                                        spdUnit.ActiveSheet.SetValue(iLastRow, COL3_NULL, true);
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            btnAllCheck.Tag = "UNCHECK";
                                            btnAllCheck.Text = "All check";
                                        }
                                        spdUnit.ActiveSheet.SetValue(iLastRow, COL3_NULL, false);
                                    }
                                    spdUnit.ActiveSheet.SetValue(iLastRow, COL3_UNIT, MPCF.Trim(out_node.GetList(0)[i].GetString("DEF_UNIT_ID")));

                                    iLastRow++;
                                }
                                else
                                {
                                    spdUnit.ActiveSheet.RowCount++;

                                    iLastRow++;
                                }
                            }
                        }
                        else if (iUnitCount < out_node.GetList(0).Count)
                        {
                            for (i = 0; i <= iUnitCount - 1; i++)
                            {
                                if (i <= out_node.GetList(0).Count - 1)
                                {
                                    spdUnit.ActiveSheet.RowCount++;

                                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NULL_FLAG")) == "Y")
                                    {
                                        if (i == 0)
                                        {
                                            btnAllCheck.Tag = "CHECK";
                                            btnAllCheck.Text = "All Uncheck";
                                        }
                                        spdUnit.ActiveSheet.SetValue(iLastRow, COL3_NULL, true);
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            btnAllCheck.Tag = "UNCHECK";
                                            btnAllCheck.Text = "All check";
                                        }
                                        spdUnit.ActiveSheet.SetValue(iLastRow, COL3_NULL, false);
                                    }
                                    spdUnit.ActiveSheet.SetValue(iLastRow, COL3_UNIT, MPCF.Trim(out_node.GetList(0)[i].GetString("DEF_UNIT_ID")));

                                    iLastRow++;
                                }
                            }
                        }
                    }
                    else if (out_node.GetList(0).Count == 0)
                    {
                        for (i = 0; i <= iUnitCount - 1; i++)
                        {
                            spdUnit.ActiveSheet.RowCount++;

                            iLastRow++;
                        }
                    }
                }
                else
                {
                    pnlUnitDescList.Visible = false;
                }
                
                Set_Character_Formula(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
            
        }
        
        private void AddSpecTypeItems(ref ComboBox cboSpecType)
        {
            
            try
            {
                cboSpecType.Items.Clear();
                cboSpecType.Items.Add(" ");                                 // Index : 0
                cboSpecType.Items.Add(MPCF.FindLanguage("Both", 0));        // Index : 1
                cboSpecType.Items.Add(MPCF.FindLanguage("Upper", 0));       // Index : 2
                cboSpecType.Items.Add(MPCF.FindLanguage("Lower", 0));       // Index : 3
                                        
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvCollectionSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        //
        // View_Character()
        //       - View Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Default_Limit_by_Character(string sCharID)
        {
            TRSNode in_node = new TRSNode("VIEW_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_CHARACTER_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHAR_ID", MPCF.Trim(sCharID));

                if (MPCR.CallService("EDC", "EDC_View_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvCharID.Tag = MPCF.Trim(out_node.GetChar("VALUE_TYPE"));

                cdvValueTable.Text = MPCF.Trim(out_node.GetString("VALID_TABLE"));
                if (cdvValueTable.Text != "")
                {
                    cdvValueTable_SelectedItemChanged(null, null);
                }
                cdvTargetValue.Text = MPCF.Trim(out_node.GetString("TARGET_VALUE"));

                //Check Value Type
                if (MPCF.Trim(out_node.GetChar("VALUE_TYPE")) == "N")
                {
                    SetEnableLimit(true);

                    if ((MPCF.Trim(out_node.GetString("UPPER_SPEC_LIMIT")) != "" && MPCF.Trim(out_node.GetString("LOWER_SPEC_LIMIT")) != "") ||
                        (MPCF.Trim(out_node.GetString("UPPER_WARN_LIMIT")) != "" && MPCF.Trim(out_node.GetString("LOWER_WARN_LIMIT")) != ""))
                    {
                        cboSpecType.SelectedIndex = 1;  // Both
                    }
                    else if ((MPCF.Trim(out_node.GetString("UPPER_SPEC_LIMIT")) != "" && MPCF.Trim(out_node.GetString("LOWER_SPEC_LIMIT")) == "") ||
                        (MPCF.Trim(out_node.GetString("UPPER_WARN_LIMIT")) != "" && MPCF.Trim(out_node.GetString("LOWER_WARN_LIMIT")) == ""))
                    {
                        cboSpecType.SelectedIndex = 2;  // Upper
                    }
                    else if ((MPCF.Trim(out_node.GetString("UPPER_SPEC_LIMIT")) == "" && MPCF.Trim(out_node.GetString("LOWER_SPEC_LIMIT")) != "") ||
                    (MPCF.Trim(out_node.GetString("UPPER_WARN_LIMIT")) == "" && MPCF.Trim(out_node.GetString("LOWER_WARN_LIMIT")) != ""))
                    {
                        cboSpecType.SelectedIndex = 3;  // Lower
                    }
                    else
                    {
                        cboSpecType.SelectedIndex = 0;  // None
                    }

                    txtUpperSpecLimit.Text = out_node.GetString("UPPER_SPEC_LIMIT");
                    txtLowerSpecLimit.Text = out_node.GetString("LOWER_SPEC_LIMIT");
                    txtUpperWarnLimit.Text = out_node.GetString("UPPER_WARN_LIMIT");
                    txtLowerWarnLimit.Text = out_node.GetString("LOWER_WARN_LIMIT");
                    
                    // Unused Member
                    // View_Character_Out.upper_cust_limit
                    // View_Character_Out.lower_cust_limit
                }
                else
                {
                    SetEnableLimit(false);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // SetEnableLimit()
        //       - Specification and warning limit set enable or disable by value type
        // Return Value
        //       - 
        // Arguments
        //       - bool bNumericType : numeric type or ascii type
        //
        public void SetEnableLimit(bool bNumericType)
        {

            try
            {
                if (bNumericType == true)
                {
                    cboSpecType.Enabled = true;

                    this.txtSpecOutCount.ReadOnly = false;
                    this.txtUpperSpecLimit.ReadOnly = false;
                    this.txtLowerSpecLimit.ReadOnly = false;
                    this.txtUpperWarnLimit.ReadOnly = false;
                    this.txtLowerWarnLimit.ReadOnly = false;
                }
                else
                {
                    cboSpecType.Enabled = false;

                    this.txtSpecOutCount.Text = "";
                    this.txtUpperSpecLimit.Text = "";
                    this.txtLowerSpecLimit.Text = "";
                    this.txtUpperWarnLimit.Text = "";
                    this.txtLowerWarnLimit.Text = "";

                    this.txtSpecOutCount.ReadOnly = true;
                    this.txtUpperSpecLimit.ReadOnly = true;
                    this.txtLowerSpecLimit.ReadOnly = true;
                    this.txtUpperWarnLimit.ReadOnly = true;
                    this.txtLowerWarnLimit.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }        

    
        // View_Attach_Character()
        //       - View Attach Character Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       -
        //
        private bool View_Attach_Character(string s_col_set_id, int i_col_set_ver, string s_char)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_CHARACTER_OUT");
            int i = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", s_col_set_id);
                in_node.AddInt("COL_SET_VERSION", i_col_set_ver);
                in_node.AddString("CHAR_ID", s_char);

                if (MPCR.CallService("EDC", "EDC_View_Attach_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                cboUseUnitSeq.Items.Clear();
                for (i = 1; i <= out_node.GetInt("UNIT_COUNT"); i++)
                {
                    cboUseUnitSeq.Items.Add(i.ToString());
                }
                cboUseUnitSeq.Tag = i - 1;
                if (i == 2)
                {
                    cboUseUnitSeq.Text = "1";
                }

                cboUseValSeq.Items.Clear();
                for (i = 1; i <= out_node.GetInt("VALUE_COUNT"); i++)
                {
                    cboUseValSeq.Items.Add(i.ToString());
                }
                cboUseValSeq.Tag = i - 1;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private void Attach_Character_Formula(TRSNode in_node)
        {
            CHAR_FORMULA_INFO st_info;
            TRSNode fml_item;
            int i;

            for (i = 0; i < spdFormula.ActiveSheet.ColumnCount; i++)
            {
                if (spdFormula.ActiveSheet.Cells[0, i].Tag != null) break;
            }
            if (i >= spdFormula.ActiveSheet.ColumnCount) return;

            for (i = 0; i < spdFormula.ActiveSheet.ColumnCount; i++)
            {
                if (spdFormula.ActiveSheet.Cells[0, i].Tag == null) continue;

                st_info = (CHAR_FORMULA_INFO)spdFormula.ActiveSheet.Cells[0, i].Tag;

                fml_item = in_node.AddNode("FORMULA_LIST");
                fml_item.AddString("VALUE_TYPE", st_info.s_value_type);
                fml_item.AddString("USE_COL_SET_ID", st_info.s_use_col_set_id);
                fml_item.AddInt("USE_COL_SET_VER", st_info.i_use_col_set_ver);
                fml_item.AddString("USE_CHAR_ID", st_info.s_use_char_id);
                fml_item.AddInt("USE_UNIT_SEQ", st_info.i_use_unit_seq);
                fml_item.AddString("CALC_TYPE", st_info.s_calc_type);
                fml_item.AddInt("USE_VALUE_SEQ", st_info.i_use_value_seq);
                fml_item.AddString("CONST_VALUE", st_info.s_const_value);
                fml_item.AddChar("USE_FIRST_DATA", st_info.b_first_col_data == true ? 'Y' : ' ');
                fml_item.AddChar("USE_LAST_DATA", st_info.b_last_col_data == true ? 'Y' : ' ');
                fml_item.AddChar("OVERRIDE_LOT", st_info.b_override_lot == true ? 'Y' : ' ');
                fml_item.AddChar("OVERRIDE_RES", st_info.b_override_res == true ? 'Y' : ' ');
                fml_item.AddString("OPERATOR", st_info.s_operator);
                fml_item.AddString("BRACKET", st_info.s_bracket);
            }

            StringBuilder sb = new StringBuilder();
            string s_tmp;

            for (i = 0; i < spdFormula.ActiveSheet.ColumnCount; i++)
            {
                s_tmp = MPCF.Trim(spdFormula.ActiveSheet.Cells[0, i].Value);
                if (s_tmp == "") continue;

                if (spdFormula.ActiveSheet.Cells[0, i].Tag != null)
                {
                    s_tmp = "#" + s_tmp;
                }

                if (spdFormula.ActiveSheet.Cells[0, i].Font != null && spdFormula.ActiveSheet.Cells[0, i].Font.Bold == true)
                {
                    s_tmp = "@" + s_tmp;
                }

                if (sb.Length < 1)
                {
                    sb.Append(s_tmp);
                }
                else
                {
                    s_tmp = "|" + s_tmp;
                    sb.Append(s_tmp);
                }
            }

            s_tmp = sb.ToString();

            in_node.SetString("DERIVED_PARAMETER", s_tmp);
        }

        private void Set_Character_Formula(TRSNode out_node)
        {
            CHAR_FORMULA_INFO st_info;
            List<TRSNode> fml_list;
            System.Collections.ArrayList a_formulas;
            int i;

            fml_list = out_node.GetList("FORMULA_LIST");
            if (fml_list.Count < 1) return;

            a_formulas = new System.Collections.ArrayList();

            for (i = 0; i < fml_list.Count; i++)
            {
                st_info = new CHAR_FORMULA_INFO();

                st_info.s_value_type = fml_list[i].GetString("VALUE_TYPE");
                switch(st_info.s_value_type)
                {
                    case "OT":
                        st_info.s_operator = fml_list[i].GetString("OPERATOR");
                        break;

                    case "LB":
                    case "RB":
                        st_info.s_bracket = fml_list[i].GetString("BRACKET");
                        break;

                    case "CC":
                    case "OC":
                        st_info.s_use_col_set_id = fml_list[i].GetString("USE_COL_SET_ID");
                        st_info.i_use_col_set_ver = fml_list[i].GetInt("USE_COL_SET_VER");
                        st_info.s_use_char_id = fml_list[i].GetString("USE_CHAR_ID");
                        st_info.i_use_unit_seq = fml_list[i].GetInt("USE_UNIT_SEQ");
                        st_info.i_unit_count = fml_list[i].GetInt("USE_UNIT_COUNT");
                        st_info.s_calc_type = fml_list[i].GetString("CALC_TYPE");
                        if (st_info.s_calc_type.Equals("OV"))
                        {
                            st_info.i_use_value_seq = fml_list[i].GetInt("USE_VALUE_SEQ");
                            st_info.i_value_count = fml_list[i].GetInt("USE_VALUE_COUNT");
                        }
                        st_info.b_first_col_data = (fml_list[i].GetChar("USE_FIRST_DATA") == 'Y' ? true : false);
                        st_info.b_last_col_data = (fml_list[i].GetChar("USE_LAST_DATA") == 'Y' ? true : false);
                        st_info.b_override_lot = (fml_list[i].GetChar("OVERRIDE_LOT") == 'Y' ? true : false);
                        st_info.b_override_res = (fml_list[i].GetChar("OVERRIDE_RES") == 'Y' ? true : false);
                        break;

                    case "CV":
                        st_info.s_const_value = fml_list[i].GetString("CONST_VALUE");
                        break;

                    case "LS":
                    case "LA":
                        st_info.s_use_char_id = fml_list[i].GetString("USE_CHAR_ID");
                        break;
                }//end switch

                a_formulas.Add(st_info);

            }//end for

            string s_formula;
            string[] s_cells;
            int i_fml_seq;
            object o_formula_info;

            s_formula = out_node.GetString("DERIVED_PARAMETER");
            s_cells = s_formula.Split('|');

            spdFormula.ActiveSheet.ColumnCount = s_cells.Length + 1;
            spdFormula.ActiveSheet.Cells[0, 0, 0, s_cells.Length].Locked = true;
            spdFormula.ActiveSheet.Cells[0, 0, 0, s_cells.Length].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, 0, 0, s_cells.Length].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            i_fml_seq = 0;

            for (i = 0; i < s_cells.Length; i++)
            {
                o_formula_info = null;
                s_formula = s_cells[i];
                
                if (s_formula[0] == '@')
                {
                    spdFormula.ActiveSheet.Cells[0, i].Font = new Font(spdFormula.Font.Name, spdFormula.Font.Size, FontStyle.Bold);
                    s_formula = s_formula.Substring(1);
                }
                if (s_formula[0] == '#')
                {
                    o_formula_info = a_formulas[i_fml_seq];
                    i_fml_seq++;
                    s_formula = s_formula.Substring(1);
                }

                spdFormula.ActiveSheet.Cells[0, i].Value = s_formula;
                spdFormula.ActiveSheet.Cells[0, i].Tag = o_formula_info;

                spdFormula.ActiveSheet.Columns[i].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i);
            }
        }

        private bool ViewStatusColumnList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = '" + tableName + "' " +
                                     "       ORDER BY COLUMN_NAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool Change_Character_Seq(string s_col_set_id, int i_col_set_ver, string s_char_id, string s_char_id_next)
        {
            TRSNode in_node = new TRSNode("CHANGE_CHARACTER_SEQ_IN");
            TRSNode out_node = new TRSNode("CHANGE_CHARACTER_SEQ_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", s_col_set_id);
                in_node.AddInt("COL_SET_VERSION", i_col_set_ver);
                in_node.AddString("CHAR_ID", s_char_id);
                in_node.AddString("NEXT_CHAR_ID", s_char_id_next);
                
                if (MPCR.CallService("EDC", "EDC_Change_Char_Sequence", in_node, ref out_node) == false)
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
#endregion

        private void frmEDCSetupAttachCharacter_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    ClearData("1");

                    LoadFlag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                //Initialize ListView
                cdvCollectionSet.Init();
                MPCF.InitListView(cdvCollectionSet.GetListView);
                cdvCollectionSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
                cdvCollectionSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvCollectionSet.SelectedSubItemIndex = 0;
                cdvCollectionSet.SelectedDescIndex = 1;
                if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                ClearData("2");

                if (cdvCollectionSet.Text == "")
                {
                    return;
                }
                if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdVersion);

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
                
                MPCF.ClearList(spdCharacter);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvCollectionSet_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvCollectionSet.Text != "")
                    {
                        cdvCollectionSet_SelectedItemChanged(sender, null);
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCollectionSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                ClearData("2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            try
            {
                ClearData("3");

                if (cdvCollectionSet.Text == "" || (spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRow.Index, 0).ToString() == ""))
                {
                    return;
                }
                
                EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, spdVersion.ActiveSheet.GetValue(e.Range.Row, 0).ToString(), 'N');

                MPCF.FitColumnHeader(spdCharacter);

                if ((spdVersion.ActiveSheet.GetValue(e.Range.Row, 3).ToString() != "" || (string)spdVersion.ActiveSheet.GetValue(e.Range.Row, 6) != ""))
                {
                    
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void spdCharacter_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {

            try
            {
                if (spdCharacter.ActiveSheet.RowCount == 0)
                {
                    return;
                }

                ClearData("4");

                if (View_Attach_Character(spdCharacter.ActiveSheet.ActiveRowIndex) == false)
                {
                    return;
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

                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                if (Attach_Character(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                if (EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 0)), 'N') == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdCharacter);

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
                
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                    
                if (Attach_Character(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                if (EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 0)), 'N') == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdCharacter);
                
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
                
                if (CheckCondition(MPGC.MP_STEP_DELETE) == true)
                {
                    if (Attach_Character(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    
                    MPCF.ClearList(spdCharacter, true);
                    MPCF.FieldClear(this.grpGeneral);
                    MPCF.FieldClear(this.grpUnitInfo);
                    MPCF.ClearList(spdUnit, true);
                    MPCF.FieldClear(this.grpLimitInfo);
                    cdvDefaultValue.VisibleButton = false;
                    cdvCharID.Tag = null;
                   
                    if (cdvCollectionSet.Text == "" || (MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRow.Index, 0)) == ""))
                    {
                        return;
                    }
                    
                    EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 0)), 'N');

                    MPCF.FitColumnHeader(spdCharacter);
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            try
            {
                sCond = "Collection Set : " + MPCF.Trim(cdvCollectionSet.Text);
                MPCF.ExportToExcel(spdCharacter, this.Text, sCond);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvCharID_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                cdvCharID.Init();
                cdvCharID.Columns.Add("Character", 50, HorizontalAlignment.Left);
                cdvCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvCharID.SelectedSubItemIndex = 0;
                cdvCharID.SelectedDescIndex = 1;
                if (EDCLIST.ViewEDCCharacterList(cdvCharID.GetListView, '1', 'E') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCharID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                ClearData("5");

                if (cdvCharID.Text != "")
                {
                    // View Default Limit
                    if (View_Default_Limit_by_Character(MPCF.Trim( cdvCharID.Text)) == false)
                    {
                        return;
                    }

                    spdFormula.ActiveSheet.ColumnCount = 1;
                    spdFormula.ActiveSheet.SetActiveCell(0, 0);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
               
        private void cdvValueTable_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvDefaultValue.Init();
                cdvTargetValue.Init();
                
                if (cdvValueTable.Text == "")
                {
                    cdvDefaultValue.Text = "";
                    cdvDefaultValue.VisibleButton = false;
                    cdvDefaultValue.ReadOnly = false;

                    cdvTargetValue.Text = "";
                    cdvTargetValue.VisibleButton = false;
                    cdvTargetValue.ReadOnly = false;
                }
                else
                {
                    cdvDefaultValue.Text = "";
                    cdvDefaultValue.VisibleButton = true;
                    cdvDefaultValue.ReadOnly = true;
                    
                    MPCF.InitListView(cdvDefaultValue.GetListView);
                    cdvDefaultValue.Columns.Add("Data", 50, HorizontalAlignment.Left);
                    cdvDefaultValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvDefaultValue.SelectedSubItemIndex = 0;
                    BASLIST.ViewGCMDataList(cdvDefaultValue.GetListView, '1', cdvValueTable.Text);
                    cdvDefaultValue.InsertEmptyRow(0, 1);

                    cdvTargetValue.Text = "";
                    cdvTargetValue.VisibleButton = true;
                    cdvTargetValue.ReadOnly = true;

                    MPCF.InitListView(cdvTargetValue.GetListView);
                    cdvTargetValue.Columns.Add("Data", 50, HorizontalAlignment.Left);
                    cdvTargetValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvTargetValue.SelectedSubItemIndex = 0;
                    BASLIST.ViewGCMDataList(cdvTargetValue.GetListView, '1', cdvValueTable.Text);
                    cdvTargetValue.InsertEmptyRow(0, 1);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }        
        
        private void cdvValueTable_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvDefaultValue.Init();
                if (cdvValueTable.Text == "")
                {
                    cdvDefaultValue.VisibleButton = false;
                    cdvDefaultValue.ReadOnly = false;
                    cdvTargetValue.VisibleButton = false;
                    cdvTargetValue.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvValueTable_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvValueTable.Init();
                MPCF.InitListView(cdvValueTable.GetListView);
                cdvValueTable.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvValueTable.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvValueTable.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMTableList(cdvValueTable.GetListView, '1') == false)
                {
                    return;
                }
                cdvValueTable.InsertEmptyRow(0, 1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUnitTable_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvUnitTable.Init();
                MPCF.InitListView(cdvUnitTable.GetListView);
                cdvUnitTable.Columns.Add("Data", 50, HorizontalAlignment.Left);
                cdvUnitTable.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvUnitTable.SelectedSubItemIndex = 0;
                cdvUnitTable.SelectedDescIndex = 1;

                if (BASLIST.ViewGCMTableList(cdvUnitTable.GetListView, '1') == false)
                {
                    return;
                }
                
                cdvUnitTable.InsertEmptyRow(0, 1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvUnitTable_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                if (chkDefaultUnit.Checked == false)
                {
                    return;
                }

                if (MPCF.Trim(e.Text) == "")
                {
                    spdUnit.ActiveSheet.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 1;
                    spdUnit.ActiveSheet.Columns.Get(COL3_BUTTON).Visible = false;
                    spdUnit.ActiveSheet.Columns.Get(COL3_UNIT).Locked = false;
                }
                else
                {
                    spdUnit.ActiveSheet.Columns.Get(COL3_BUTTON).Visible = true;
                    spdUnit.ActiveSheet.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
                    spdUnit.ActiveSheet.Columns.Get(COL3_UNIT).Locked = true;
                }
                cdvValueTable.InsertEmptyRow(0, 1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }            
            
        private void chkOptionalInput_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (chkOptionalInput.Checked == true)
                {
                    chkBlankSave.Enabled = true;
                    lblMinValueCount.Enabled = true;
                    txtMinValueCount.ReadOnly = false;
                    chkMinValueByLotQty.Enabled = true;
                }
                else
                {
                    chkBlankSave.Checked = false;
                    chkBlankSave.Enabled = false;
                    chkMinValueByLotQty.Checked = false;
                    chkMinValueByLotQty.Enabled = false;

                    lblMinValueCount.Enabled = false;
                    txtMinValueCount.Text = "";
                    txtMinValueCount.ReadOnly = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void chkMinValueByLotQty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinValueByLotQty.Checked == true)
            {
                txtMinValueCount.Text = "";
                txtMinValueCount.ReadOnly = true;
            }
            else
            {
                txtMinValueCount.ReadOnly = false;
            }
        }

        private void chkDefaultUnit_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkDefaultUnit.Checked == true)
                {
                    chkDefaultUnitOvr.Enabled = true;
                    pnlUnitDescList.Visible = true;

                    if (spdUnit.ActiveSheet.RowCount != MPCF.ToInt(txtUnitCount.Text))
                    {
                        spdUnit.ActiveSheet.RowCount = MPCF.ToInt(txtUnitCount.Text);
                    }

                    if (MPCF.Trim(cdvUnitTable.Text) == "")
                    {
                        spdUnit.ActiveSheet.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 1;
                        spdUnit.ActiveSheet.Columns.Get(COL3_BUTTON).Visible = false;
                        spdUnit.ActiveSheet.Columns.Get(COL3_UNIT).Locked = false;
                    }
                    else
                    {
                        spdUnit.ActiveSheet.Columns.Get(COL3_BUTTON).Visible = true;
                        spdUnit.ActiveSheet.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
                        spdUnit.ActiveSheet.Columns.Get(COL3_UNIT).Locked = true;
                    }
                }
                else
                {
                    chkDefaultUnitOvr.Checked = false;
                    chkDefaultUnitOvr.Enabled = false;
                    pnlUnitDescList.Visible = false;
                }               
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
                
        private void cboSpecType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (cboSpecType.SelectedIndex == 1)         // Both
                {
                    //txtUpperSpecLimit.Text = "";
                    //txtLowerSpecLimit.Text = "";
                    //txtUpperWarnLimit.Text = "";
                    //txtLowerWarnLimit.Text = "";
                    txtUpperSpecLimit.ReadOnly = false;
                    txtLowerSpecLimit.ReadOnly = false;
                    txtUpperWarnLimit.ReadOnly = false;
                    txtLowerWarnLimit.ReadOnly = false;
                }
                else if (cboSpecType.SelectedIndex == 2)    // Upper
                {
                    //txtUpperSpecLimit.Text = "";
                    txtLowerSpecLimit.Text = "";
                    //txtUpperWarnLimit.Text = "";
                    txtLowerWarnLimit.Text = "";
                    txtUpperSpecLimit.ReadOnly = false;
                    txtLowerSpecLimit.ReadOnly = true;
                    txtUpperWarnLimit.ReadOnly = false;
                    txtLowerWarnLimit.ReadOnly = true;
                }
                else if (cboSpecType.SelectedIndex == 3)    // Lower
                {
                    txtUpperSpecLimit.Text = "";
                    //txtLowerSpecLimit.Text = "";
                    txtUpperWarnLimit.Text = "";
                    //txtLowerWarnLimit.Text = "";
                    txtUpperSpecLimit.ReadOnly = true;
                    txtLowerSpecLimit.ReadOnly = false;
                    txtUpperWarnLimit.ReadOnly = true;
                    txtLowerWarnLimit.ReadOnly = false;
                }
                else if (cboSpecType.SelectedIndex == 0)    // None
                {
                    txtUpperSpecLimit.Text = "";
                    txtLowerSpecLimit.Text = "";
                    txtUpperWarnLimit.Text = "";
                    txtLowerWarnLimit.Text = "";
                    txtUpperSpecLimit.ReadOnly = true;
                    txtLowerSpecLimit.ReadOnly = true;
                    txtUpperWarnLimit.ReadOnly = true;
                    txtLowerWarnLimit.ReadOnly = true;
                    cdvAlarmCode1.Text = "";
                    cdvAlarmCode2.Text = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdUnit_ButtonClicked(object sender,  FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == COL3_BUTTON)
                {
                    if (MPCF.Trim(cdvUnitTable.Text) == "")
                    {
                        return;
                    }

                    cdvDataList.Init();
                    cdvDataList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDataList.GetListView);
                    cdvDataList.Columns.Add("Value", 50, HorizontalAlignment.Left);
                    cdvDataList.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    if (BASLIST.ViewGCMDataList(cdvDataList.GetListView, '1', MPCF.Trim(cdvUnitTable.Text)) == false)
                    {
                        return;
                    }

                    cdvDataList.InsertEmptyRow(0, 1);

                    if (cdvDataList.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }              
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvDataList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {

            try
            {
                spdUnit.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkDerivedFlag_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (chkDerivedFlag.Checked == true)
                {
                    grpAutoCalc.Enabled = true;
                    txtDerivedParameter.Visible = true;

                    txtUnitCount.Text = "1";
                    txtUnitCount.Enabled = false;
                    txtUnitCount_TextChanged(null, null);
                }
                else
                {
                    grpAutoCalc.Enabled = false;
                    txtDerivedParameter.Text = "";
                    txtDerivedParameter.Visible = false;

                    txtUnitCount.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void CheckCharValue_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvCharID.Tag) != "N")
                {
                    return;
                }

                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.IndexOf(".") >= 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == (char)45)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.Length > 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void CheckNumeric_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.IndexOf(".") >= 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == (char)45)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.Length > 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void CheckInteger_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            int i = 0;

            try
            {
                if (MPCF.Trim(btnAllCheck.Tag) == "CHECK")
                {
                    btnAllCheck.Tag = "UNCHECK";
                    btnAllCheck.Text = "All Check";
                    for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                    {
                        spdUnit.ActiveSheet.SetValue(i, COL3_NULL, false);
                    }
                }
                else if (MPCF.Trim(btnAllCheck.Tag) == "UNCHECK")
                {
                    btnAllCheck.Tag = "CHECK";
                    btnAllCheck.Text = "All Uncheck";
                    for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                    {
                        spdUnit.ActiveSheet.SetValue(i, COL3_NULL, true);
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void txtUnitCount_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (chkDefaultUnit.Checked == true)
                {
                    btnAllCheck.Tag = "UNCHECK";
                    btnAllCheck.Text = "All Check";
                    spdUnit.ActiveSheet.RowCount = MPCF.ToInt(txtUnitCount.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvAlarmCode_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {

#if _ALM
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                cdvTemp.Init();
                cdvTemp.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;

                if (ALMLIST.ViewAlarmMsgList(cdvTemp.GetListView, '1', ' ') == false)
                {
                    return;
                }
#endif  // _ALM

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkUnitNullFlag_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (chkUnitNullFlag.Checked == true)
                {
                    chkDefaultUnit.Checked = false;
                    chkDefaultUnitOvr.Checked = false;
                    chkDefaultUnit.Enabled = false;                    
                    chkDefaultUnitOvr.Enabled = false;
                    lblUnitTable.Enabled = false;
                    cdvUnitTable.Enabled = false;
                    cdvUnitTable.Text = "";

                }
                else
                {
                    chkDefaultUnit.Enabled = true;
                    chkDefaultUnitOvr.Enabled = true;
                    lblUnitTable.Enabled = true;
                    cdvUnitTable.Enabled = true;
                    cdvUnitTable.Text = "";

                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cboValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboValueType.Text == "" || cboValueType.Text.Length < 2) return;

            switch (cboValueType.Text.Substring(0, 2))
            {
                case "CC":
                    cdvUseColSet.Text = cdvCollectionSet.Text;
                    cdvUseColSetVer.Text = MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRow.Index, 0));
                    cdvUseColSet.Enabled = false;
                    cdvUseColSetVer.Enabled = false;

                    rbtFirstColData.Checked = false;
                    rbtFirstColData.Enabled = false;
                    rbtLastColData.Checked = false;
                    rbtLastColData.Enabled = false;
                    chkOverrideLot.Checked = false;
                    chkOverrideLot.Enabled = false;
                    chkOverrideRes.Checked = false;
                    chkOverrideRes.Enabled = false;

                    lblUseChar.Text = MPCF.FindLanguage("Use Character", 0);
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboUseUnitSeq.Items.Clear();
                    cboCalcType.Text = "";

                    cdvUseCharID.Enabled = true;
                    cboUseUnitSeq.Enabled = true;
                    cboCalcType.Enabled = true;

                    cboUseValSeq.Text = "";
                    cboUseValSeq.Items.Clear();
                    cboUseValSeq.DropDownStyle = ComboBoxStyle.DropDown;
                    lblUseValSeq.Text = MPCF.FindLanguage("Use Value Seq.", 0);
                    cboUseValSeq.Enabled = false;
                    break;

                case "OC":
                    cdvUseColSet.Text = "";
                    cdvUseColSet.Enabled = true;
                    cdvUseColSetVer.Text = "";
                    cdvUseColSetVer.Enabled = true;

                    rbtFirstColData.Checked = false;
                    rbtFirstColData.Enabled = true;
                    rbtLastColData.Checked = true;
                    rbtLastColData.Enabled = true;
                    chkOverrideLot.Checked = false;
                    chkOverrideLot.Enabled = true;
                    chkOverrideRes.Checked = false;
                    chkOverrideRes.Enabled = true;

                    lblUseChar.Text = MPCF.FindLanguage("Use Character", 0);
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboUseUnitSeq.Items.Clear();
                    cboCalcType.Text = "";

                    cdvUseCharID.Enabled = true;
                    cboUseUnitSeq.Enabled = true;
                    cboCalcType.Enabled = true;

                    cboUseValSeq.Text = "";
                    cboUseValSeq.Items.Clear();
                    cboUseValSeq.DropDownStyle = ComboBoxStyle.DropDown;
                    lblUseValSeq.Text = MPCF.FindLanguage("Use Value Seq.", 0);
                    cboUseValSeq.Enabled = false;
                    break;

                case "CV":
                    cdvUseColSet.Text = "";
                    cdvUseColSet.Enabled = false;
                    cdvUseColSetVer.Text = "";
                    cdvUseColSetVer.Enabled = false;

                    rbtFirstColData.Checked = false;
                    rbtFirstColData.Enabled = false;
                    rbtLastColData.Checked = false;
                    rbtLastColData.Enabled = false;
                    chkOverrideLot.Checked = false;
                    chkOverrideLot.Enabled = false;
                    chkOverrideRes.Checked = false;
                    chkOverrideRes.Enabled = false;

                    lblUseChar.Text = MPCF.FindLanguage("Use Character", 0);
                    cdvUseCharID.Text = "";
                    cdvUseCharID.Enabled = false;
                    cboUseUnitSeq.Text = "";
                    cboUseUnitSeq.Items.Clear();
                    cboUseUnitSeq.Enabled = false;
                    cboCalcType.Text = "";
                    cboCalcType.Enabled = false;

                    cboUseValSeq.Enabled = true;
                    cboUseValSeq.Text = "";
                    cboUseValSeq.Items.Clear();
                    cboUseValSeq.DropDownStyle = ComboBoxStyle.Simple;
                    lblUseValSeq.Text = MPCF.FindLanguage("Use Value", 0);
                    break;

                case "LS":
                    cdvUseColSet.Text = "";
                    cdvUseColSet.Enabled = false;
                    cdvUseColSetVer.Text = "";
                    cdvUseColSetVer.Enabled = false;

                    rbtFirstColData.Checked = false;
                    rbtFirstColData.Enabled = false;
                    rbtLastColData.Checked = false;
                    rbtLastColData.Enabled = false;
                    chkOverrideLot.Checked = false;
                    chkOverrideLot.Enabled = false;
                    chkOverrideRes.Checked = false;
                    chkOverrideRes.Enabled = false;

                    lblUseChar.Text = MPCF.FindLanguage("Lot Status", 0);
                    cdvUseCharID.Text = "";
                    cdvUseCharID.Enabled = true;

                    cboUseUnitSeq.Text = "";
                    cboUseUnitSeq.Items.Clear();
                    cboUseUnitSeq.Enabled = false;
                    cboCalcType.Text = "";
                    cboCalcType.Enabled = false;

                    cboUseValSeq.Text = "";
                    cboUseValSeq.Text = "";
                    cboUseValSeq.Items.Clear();
                    cboUseValSeq.Enabled = false;
                    break;

                case "LA":
                    cdvUseColSet.Text = "";
                    cdvUseColSet.Enabled = false;
                    cdvUseColSetVer.Text = "";
                    cdvUseColSetVer.Enabled = false;

                    rbtFirstColData.Checked = false;
                    rbtFirstColData.Enabled = false;
                    rbtLastColData.Checked = false;
                    rbtLastColData.Enabled = false;
                    chkOverrideLot.Checked = false;
                    chkOverrideLot.Enabled = false;
                    chkOverrideRes.Checked = false;
                    chkOverrideRes.Enabled = false;

                    lblUseChar.Text = MPCF.FindLanguage("Lot Attribute", 0);
                    cdvUseCharID.Text = "";
                    cdvUseCharID.Enabled = true;

                    cboUseUnitSeq.Text = "";
                    cboUseUnitSeq.Items.Clear();
                    cboUseUnitSeq.Enabled = false;
                    cboCalcType.Text = "";
                    cboCalcType.Enabled = false;

                    cboUseValSeq.Text = "";
                    cboUseValSeq.Text = "";
                    cboUseValSeq.Items.Clear();
                    cboUseValSeq.Enabled = false;
                    break;
            }
        }

        private void cboValueType_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvCollectionSet, 1) == false) return;
            if (MPCF.CheckValue(cdvCharID, 1) == false)
            {
                tabAttachCharacter.SelectedTab = tbpGeneral;
                cdvCharID.Focus();
                return;
            }
        }

        private void cdvUseColSet_ButtonPress(object sender, EventArgs e)
        {
            cdvUseColSet.Init();
            MPCF.InitListView(cdvUseColSet.GetListView);
            cdvUseColSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvUseColSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvUseColSet.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCColSetList(cdvUseColSet.GetListView, '1', null, "", -1, -1, ' ', false) == false) return;
        }

        private void cdvUseColSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (e.Text.Equals(cdvCollectionSet.Text))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(355));
                cdvUseColSet.Text = "";
                cdvUseColSet.Focus();
            }

            cdvUseColSetVer.Text = "";
            cdvUseCharID.Text = "";
            cboUseUnitSeq.Text = "";
            cboCalcType.Text = "";
            cboUseValSeq.Text = "";

        }

        private void cdvUseColSetVer_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvUseColSet, 1) == false) return;

            cdvUseColSetVer.Init();
            cdvUseColSetVer.Columns.Add("Version", 50, HorizontalAlignment.Left);
            cdvUseColSetVer.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCColSetVersionList(cdvUseColSetVer.GetListView, '2', cdvUseColSet.Text, -1, null, "") == false) return;
        }

        private void cdvUseColSetVer_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvUseCharID.Text = "";
            cboUseUnitSeq.Text = "";
            cboCalcType.Text = "";
            cboUseValSeq.Text = "";
        }

        private void cdvUseCharID_ButtonPress(object sender, EventArgs e)
        {
            cdvUseCharID.Init();

            switch (cboValueType.Text.Substring(0, 2))
            {
                case "LS":
                    cdvUseCharID.Columns.Add("Column", 50, HorizontalAlignment.Left);
                    cdvUseCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvUseCharID.SelectedSubItemIndex = 0;
                    cdvUseCharID.DisplaySubItemIndex = 0;
                    ViewStatusColumnList(cdvUseCharID.GetListView, "MWIPLOTSTS");
                    break;
                
                case "LA":
                    cdvUseCharID.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                    cdvUseCharID.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    cdvUseCharID.SelectedSubItemIndex = 1;
                    cdvUseCharID.DisplaySubItemIndex = 1;
                    BASLIST.ViewAttributeNameList(cdvUseCharID.GetListView, '1', MPGC.MP_ATTR_TYPE_LOT);
                    break;

                default:
                    if (MPCF.CheckValue(cdvUseColSet, 1) == false) return;
                    if (MPCF.CheckValue(cdvUseColSetVer, 1) == false) return;

                    cdvUseCharID.Columns.Add("Character", 50, HorizontalAlignment.Left);
                    cdvUseCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    cdvUseCharID.SelectedSubItemIndex = 0;
                    cdvUseCharID.DisplaySubItemIndex = 0;
                    if (EDCLIST.ViewEDCAttachCharacterList(cdvUseCharID.GetListView, '4', -1, cdvUseColSet.Text, cdvUseColSetVer.Text, null, "", -1, -1, ' ') == false) return;
                    break;
            }
        }

        private void cdvUseCharID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            switch (cboValueType.Text.Substring(0, 2))
            {
                case "LS":
                case "LA":
                    cdvUseCharID.SelectedSubItemIndex = 0;
                    cdvUseCharID.DisplaySubItemIndex = 0;
                    break;

                default:
                    cboUseUnitSeq.Text = "";
                    cboCalcType.Text = "";
                    cboUseValSeq.Text = "";
                    View_Attach_Character(cdvUseColSet.Text, MPCF.ToInt(cdvUseColSetVer.Text), cdvUseCharID.Text);
                    break;
            }
        }

        private void cboCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboUseValSeq.Text = "";

            if (cboCalcType.Text != "" && cboCalcType.Text.Length > 2 && cboCalcType.Text.Substring(0, 2) == "OV")
            {
                if (MPCF.ToInt(txtValueCount.Text) > 1)
                {
                    cboUseValSeq.Enabled = false;
                    cboUseValSeq.Text = "Each Value Sequence";
                }
                else
                {   cboUseValSeq.Enabled = true;
                    if (MPCF.ToInt(cboUseValSeq.Tag) == 1)
                    {
                        cboUseValSeq.Text = "1";
                    }
                }
            }
            else
            {
                cboUseValSeq.Enabled = false;
            }
        }

        private void cboDisable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((ComboBox)sender).Name.Equals("cboUseValSeq") &&
                cboUseValSeq.DropDownStyle == ComboBoxStyle.Simple)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void spdFormula_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            CHAR_FORMULA_INFO st_info;
            int i;

            if (spdFormula.ActiveSheet.Cells[0, e.Range.Column].Tag == null) return;

            st_info = (CHAR_FORMULA_INFO)spdFormula.ActiveSheet.Cells[0, e.Range.Column].Tag;
            switch (st_info.s_value_type)
            {
                case "OT": // Operator
                    for (i = 0; i < cboOperator.Items.Count; i++)
                    {
                        if (st_info.s_operator.Equals(MPCF.SubtractString(cboOperator.Items[i].ToString(), ":", false, false)))
                        {
                            cboOperator.Text = cboOperator.Items[i].ToString();
                            break;
                        }
                    }
                    break;

                case "LB": // Left Bracket
                    cboLBracket.Text = st_info.s_bracket;
                    break;

                case "RB": // Left Bracket
                    cboRBracket.Text = st_info.s_bracket;
                    break;

                case "CC": // Use Current Collection Set

                    cboValueType.Text = "";
                    cdvUseColSet.Text = "";
                    cdvUseColSetVer.Text = "";
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboCalcType.Text = "";
                    cboUseValSeq.Text = "";

                    for (i = 0; i < cboValueType.Items.Count; i++)
                    {
                        if (st_info.s_value_type.Equals(MPCF.SubtractString(cboValueType.Items[i].ToString(), ":", false, false)))
                        {
                            cboValueType.Text = cboValueType.Items[i].ToString();
                            cboValueType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    cdvUseColSet.Text = st_info.s_use_col_set_id;
                    cdvUseColSetVer.Text = st_info.i_use_col_set_ver.ToString();
                    cdvUseCharID.Text = st_info.s_use_char_id;

                    cboUseUnitSeq.Items.Clear();
                    for (i = 1; i <= st_info.i_unit_count; i++)
                    {
                        cboUseUnitSeq.Items.Add(i.ToString());
                    }
                    cboUseUnitSeq.Text = st_info.i_use_unit_seq.ToString();

                    for (i = 0; i < cboCalcType.Items.Count; i++)
                    {
                        if (st_info.s_calc_type.Equals(MPCF.SubtractString(cboCalcType.Items[i].ToString(), ":", false, false)))
                        {
                            cboCalcType.Text = cboCalcType.Items[i].ToString();
                            cboCalcType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    if (st_info.s_calc_type.Equals("OV"))
                    {
                        cboUseValSeq.Items.Clear();
                        for (i = 1; i <= st_info.i_value_count; i++)
                        {
                            cboUseValSeq.Items.Add(i.ToString());
                        }

                        if (st_info.i_use_value_seq == 0)
                        {
                            cboUseValSeq.Text = "Each Value Sequence";
                        }
                        else
                        {
                            cboUseValSeq.Text = st_info.i_use_value_seq.ToString();
                        }
                    }

                    break;

                case "OC": // Use Other Collection Set

                    cboValueType.Text = "";
                    cdvUseColSet.Text = "";
                    cdvUseColSetVer.Text = "";
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboCalcType.Text = "";
                    cboUseValSeq.Text = "";

                    for (i = 0; i < cboValueType.Items.Count; i++)
                    {
                        if (st_info.s_value_type.Equals(MPCF.SubtractString(cboValueType.Items[i].ToString(), ":", false, false)))
                        {
                            cboValueType.Text = cboValueType.Items[i].ToString();
                            cboValueType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    cdvUseColSet.Text = st_info.s_use_col_set_id;
                    cdvUseColSetVer.Text = st_info.i_use_col_set_ver.ToString();
                    cdvUseCharID.Text = st_info.s_use_char_id;

                    cboUseUnitSeq.Items.Clear();
                    for (i = 1; i <= st_info.i_unit_count; i++)
                    {
                        cboUseUnitSeq.Items.Add(i.ToString());
                    }
                    cboUseUnitSeq.Text = st_info.i_use_unit_seq.ToString();

                    for (i = 0; i < cboCalcType.Items.Count; i++)
                    {
                        if (st_info.s_calc_type.Equals(MPCF.SubtractString(cboCalcType.Items[i].ToString(), ":", false, false)))
                        {
                            cboCalcType.Text = cboCalcType.Items[i].ToString();
                            cboCalcType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    if (st_info.s_calc_type.Equals("OV"))
                    {
                        cboUseValSeq.Items.Clear();
                        for (i = 1; i <= st_info.i_value_count; i++)
                        {
                            cboUseValSeq.Items.Add(i.ToString());
                        }
                        cboUseValSeq.Text = st_info.i_use_value_seq.ToString();
                    }

                    rbtFirstColData.Checked = st_info.b_first_col_data;
                    rbtLastColData.Checked = st_info.b_last_col_data;
                    chkOverrideLot.Checked = st_info.b_override_lot;
                    chkOverrideRes.Checked = st_info.b_override_res;

                    break;

                case "CV": // Constant Value

                    cboValueType.Text = "";
                    cdvUseColSet.Text = "";
                    cdvUseColSetVer.Text = "";
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboCalcType.Text = "";
                    cboUseValSeq.Text = "";

                    for (i = 0; i < cboValueType.Items.Count; i++)
                    {
                        if (st_info.s_value_type.Equals(MPCF.SubtractString(cboValueType.Items[i].ToString(), ":", false, false)))
                        {
                            cboValueType.Text = cboValueType.Items[i].ToString();
                            cboValueType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    cboUseValSeq.Text = st_info.s_const_value;
                    break;

                case "LS": // Lot Status
                case "LA": // Lot Attribute

                    cboValueType.Text = "";
                    cdvUseColSet.Text = "";
                    cdvUseColSetVer.Text = "";
                    cdvUseCharID.Text = "";
                    cboUseUnitSeq.Text = "";
                    cboCalcType.Text = "";
                    cboUseValSeq.Text = "";

                    for (i = 0; i < cboValueType.Items.Count; i++)
                    {
                        if (st_info.s_value_type.Equals(MPCF.SubtractString(cboValueType.Items[i].ToString(), ":", false, false)))
                        {
                            cboValueType.Text = cboValueType.Items[i].ToString();
                            cboValueType_SelectedIndexChanged(null, null);
                            break;
                        }
                    }

                    cdvUseCharID.Text = st_info.s_use_char_id;
                    break;
            }
        }

        private void btnAddOperand_Click(object sender, EventArgs e)
        {
            CHAR_FORMULA_INFO st_info;
            int i_col;

            if(MPCF.CheckValue(cboValueType, 1) == false) return;

            st_info = new CHAR_FORMULA_INFO();

            switch (cboValueType.Text.Substring(0, 2))
            {
                case "CC":
                    if (MPCF.CheckValue(cdvUseColSet, 1) == false) return;
                    if (MPCF.CheckValue(cdvUseColSetVer, 1) == false) return;
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    if (MPCF.CheckValue(cboUseUnitSeq, 1) == false) return;
                    if (MPCF.CheckValue(cboCalcType, 1) == false) return;
                    if (cboCalcType.Text.Substring(0, 2).Equals("OV"))
                    {
                        if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    }
                    break;

                case "OC":
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    if (MPCF.CheckValue(cboUseUnitSeq, 1) == false) return;
                    if (MPCF.CheckValue(cboCalcType, 1) == false) return;
                    if (cboCalcType.Text.Substring(0, 2).Equals("OV"))
                    {
                        if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    }
                    break;

                case "CV":
                    if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    if (MPCF.CheckNumeric(cboUseValSeq.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(110));
                        cboUseValSeq.Focus();
                        return;
                    }
                    break;

                case "LS":
                case "LA":
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    break;
            }

            st_info.s_value_type = cboValueType.Text.Substring(0, 2);
            st_info.s_use_col_set_id = cdvUseColSet.Text;
            st_info.i_use_col_set_ver = MPCF.ToInt(cdvUseColSetVer.Text);
            st_info.s_use_char_id = cdvUseCharID.Text;
            st_info.i_use_unit_seq = MPCF.ToInt(cboUseUnitSeq.Text);
            st_info.i_unit_count = MPCF.ToInt(cboUseUnitSeq.Tag);
            st_info.s_calc_type = (cboCalcType.Text.Length > 2 ? cboCalcType.Text.Substring(0, 2) : "");
            if (st_info.s_value_type.Equals("CV"))
            {
                st_info.s_const_value = cboUseValSeq.Text;
            }
            if (st_info.s_calc_type.Equals("OV"))
            {
                st_info.i_use_value_seq= MPCF.ToInt(cboUseValSeq.Text);
                st_info.i_value_count = MPCF.ToInt(cboUseValSeq.Tag);
            }
            st_info.b_first_col_data = rbtFirstColData.Checked;
            st_info.b_last_col_data = rbtLastColData.Checked;
            st_info.b_override_lot = chkOverrideLot.Checked;
            st_info.b_override_res = chkOverrideRes.Checked;

            i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
            spdFormula.ActiveSheet.Columns.Add(i_col, 1);
            spdFormula.ActiveSheet.Cells[0, i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].Locked = true;
            spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

            if (st_info.s_value_type.Equals("CV"))
            {
                spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_const_value;
            }
            else
            {
                spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_use_char_id;
            }
            spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

            spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
        }

        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cboOperator, 1) == false) return;

            CHAR_FORMULA_INFO st_info;
            int i_col;
            string s_operator = MPCF.SubtractString(cboOperator.Text, ":", false, false);

            st_info = new CHAR_FORMULA_INFO();
            st_info.s_value_type = "OT";
            st_info.s_operator = s_operator;

            switch (s_operator)
            {
                case "+":
                case "-":
                case "*":
                case "/":

                    i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
                    spdFormula.ActiveSheet.Columns.Add(i_col, 1);
                    spdFormula.ActiveSheet.Cells[0, i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col].Locked = true;
                    spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

                    spdFormula.ActiveSheet.Cells[0, i_col].Value = s_operator;
                    spdFormula.ActiveSheet.Cells[0, i_col].Font = new Font(spdFormula.Font.Name, spdFormula.Font.Size, FontStyle.Bold);
                    spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

                    spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);

                    break;

                case "SIN":
                case "ASIN":
                case "COS":
                case "ACOS":
                case "TAN":
                case "ATAN":
                case "EXP":
                case "SQRT":
                case "ABS":
                case "CEIL":
                case "FLOOR":
                case "SIGN":

                    i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
                    spdFormula.ActiveSheet.Columns.Add(i_col, 2);
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 1].Locked = true;
                    spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

                    spdFormula.ActiveSheet.Cells[0, i_col].Value = s_operator + "(";
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 1].Font = new Font(spdFormula.Font.Name, spdFormula.Font.Size, FontStyle.Bold);
                    spdFormula.ActiveSheet.Cells[0, i_col + 1].Value = ")";
                    spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

                    spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
                    spdFormula.ActiveSheet.Columns[i_col + 1].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col + 1);

                    break;

                case "MOD":
                case "LOG":
                case "ROUND":
                case "POWER":

                    i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
                    spdFormula.ActiveSheet.Columns.Add(i_col, 3);
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 2].Locked = true;
                    spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

                    spdFormula.ActiveSheet.Cells[0, i_col].Value = s_operator + "(";
                    spdFormula.ActiveSheet.Cells[0, i_col, 0, i_col + 2].Font = new Font(spdFormula.Font.Name, spdFormula.Font.Size, FontStyle.Bold);
                    spdFormula.ActiveSheet.Cells[0, i_col + 1].Value = ",";
                    spdFormula.ActiveSheet.Cells[0, i_col + 2].Value = ")";
                    spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

                    spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
                    spdFormula.ActiveSheet.Columns[i_col + 1].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col + 1);
                    spdFormula.ActiveSheet.Columns[i_col + 2].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col + 2);

                    break;

            }

        }

        private void btnAddLBracket_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cboLBracket, 1) == false) return;

            CHAR_FORMULA_INFO st_info;
            int i_col;

            st_info = new CHAR_FORMULA_INFO();
            st_info.s_value_type = "LB";
            st_info.s_bracket = cboLBracket.Text;

            i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
            spdFormula.ActiveSheet.Columns.Add(i_col, 1);
            spdFormula.ActiveSheet.Cells[0, i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].Locked = true;
            spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

            spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_bracket;
            spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

            spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
        }

        private void btnAddRBracket_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cboRBracket, 1) == false) return;

            CHAR_FORMULA_INFO st_info;
            int i_col;

            st_info = new CHAR_FORMULA_INFO();
            st_info.s_value_type = "RB";
            st_info.s_bracket = cboRBracket.Text;

            i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
            spdFormula.ActiveSheet.Columns.Add(i_col, 1);
            spdFormula.ActiveSheet.Cells[0, i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            spdFormula.ActiveSheet.Cells[0, i_col].Locked = true;
            spdFormula.ActiveSheet.SetActiveCell(0, i_col + 1);

            spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_bracket;
            spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

            spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
        }

        private void btnDelCol_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange[] crs = spdFormula.ActiveSheet.GetSelections();
            if (crs.Length < 1) return;

            int i;
            for(i = crs.Length - 1; i >= 0; i--)
            {
                spdFormula.ActiveSheet.Columns[crs[i].Column, crs[i].Column + crs[i].ColumnCount - 1].Remove();
            }

            if (spdFormula.ActiveSheet.ColumnCount > 0)
            {
                if (MPCF.Trim(spdFormula.ActiveSheet.Cells[0, spdFormula.ActiveSheet.ColumnCount - 1].Value) != "")
                {
                    spdFormula.ActiveSheet.ColumnCount += 1;
                }
            }
            else
            {
                spdFormula.ActiveSheet.ColumnCount = 1;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            CHAR_FORMULA_INFO st_info;
            int i_col;

            i_col = spdFormula.ActiveSheet.ActiveColumnIndex;
            if (spdFormula.ActiveSheet.Cells[0, i_col].Tag == null) return;
            st_info = (CHAR_FORMULA_INFO)spdFormula.ActiveSheet.Cells[0, i_col].Tag;

            if (st_info.s_value_type.Equals("OT") || st_info.s_value_type.Equals("LB") || st_info.s_value_type.Equals("RB"))
                return;

            if (MPCF.CheckValue(cboValueType, 1) == false) return;
            st_info.s_value_type = cboValueType.Text.Substring(0, 2);

            switch (st_info.s_value_type)
            {
                case "CC":
                    if (MPCF.CheckValue(cdvUseColSet, 1) == false) return;
                    if (MPCF.CheckValue(cdvUseColSetVer, 1) == false) return;
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    if (MPCF.CheckValue(cboUseUnitSeq, 1) == false) return;
                    if (MPCF.CheckValue(cboCalcType, 1) == false) return;
                    if (cboCalcType.Text.Substring(0, 2).Equals("OV"))
                    {
                        if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    }
                    break;

                case "OC":
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    if (MPCF.CheckValue(cboUseUnitSeq, 1) == false) return;
                    if (MPCF.CheckValue(cboCalcType, 1) == false) return;
                    if (cboCalcType.Text.Substring(0, 2).Equals("OV"))
                    {
                        if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    }
                    break;

                case "CV":
                    if (MPCF.CheckValue(cboUseValSeq, 1) == false) return;
                    if (MPCF.CheckNumeric(cboUseValSeq.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(110));
                        cboUseValSeq.Focus();
                        return;
    }
                    break;

                case "LS":
                case "LA":
                    if (MPCF.CheckValue(cdvUseCharID, 1) == false) return;
                    break;
            }

            st_info.s_use_col_set_id = cdvUseColSet.Text;
            st_info.i_use_col_set_ver = MPCF.ToInt(cdvUseColSetVer.Text);
            st_info.s_use_char_id = cdvUseCharID.Text;
            st_info.i_use_unit_seq = MPCF.ToInt(cboUseUnitSeq.Text);
            st_info.i_unit_count = MPCF.ToInt(cboUseUnitSeq.Tag);
            st_info.s_calc_type = (cboCalcType.Text.Length > 2 ? cboCalcType.Text.Substring(0, 2) : "");
            if (st_info.s_value_type.Equals("CV"))
            {
                st_info.s_const_value = cboUseValSeq.Text;
            }
            if (st_info.s_calc_type.Equals("OV"))
            {
                st_info.i_use_value_seq = MPCF.ToInt(cboUseValSeq.Text);
                st_info.i_value_count = MPCF.ToInt(cboUseValSeq.Tag);
            }
            st_info.b_first_col_data = rbtFirstColData.Checked;
            st_info.b_last_col_data = rbtLastColData.Checked;
            st_info.b_override_lot = chkOverrideLot.Checked;
            st_info.b_override_res = chkOverrideRes.Checked;

            if (st_info.s_value_type.Equals("CV"))
            {
                spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_const_value;
            }
            else
            {
                spdFormula.ActiveSheet.Cells[0, i_col].Value = st_info.s_use_char_id;
            }
            spdFormula.ActiveSheet.Cells[0, i_col].Tag = st_info;

            spdFormula.ActiveSheet.Columns[i_col].Width = spdFormula.ActiveSheet.GetPreferredColumnWidth(i_col);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i_row;

            if (spdCharacter.ActiveSheet.SelectionCount < 1) return;

            i_row = spdCharacter.ActiveSheet.GetSelection(0).Row;
            if (i_row == 0) return;

            string s_col_set_id;
            int i_col_set_ver;
            string s_char_id;
            string s_char_id_next;

            s_col_set_id = cdvCollectionSet.Text;
            i_col_set_ver = MPCF.ToInt(spdVersion.ActiveSheet.Cells[spdVersion.ActiveSheet.ActiveRowIndex, COL1_VERSION].Value);
            s_char_id = MPCF.Trim(spdCharacter.ActiveSheet.Cells[i_row - 1, COL2_CHAR_ID].Value);
            s_char_id_next = MPCF.Trim(spdCharacter.ActiveSheet.Cells[i_row, COL2_CHAR_ID].Value);

            if (Change_Character_Seq(s_col_set_id, i_col_set_ver, s_char_id, s_char_id_next) == false) return;

            spdCharacter.ActiveSheet.MoveRow(i_row - 1, i_row, true);

            spdCharacter.ActiveSheet.AddSelection(i_row - 1, 0, 1, 1);
            spdCharacter.ActiveSheet.RemoveSelection(i_row, 0, 1, 1);

            spdCharacter.ShowRow(spdCharacter.GetActiveRowViewportIndex(), i_row - 1, VerticalPosition.Center);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i_row;

            if (spdCharacter.ActiveSheet.SelectionCount < 1) return;

            i_row = spdCharacter.ActiveSheet.GetSelection(0).Row;
            if (i_row == spdCharacter.ActiveSheet.RowCount - 1) return;

            string s_col_set_id;
            int i_col_set_ver;
            string s_char_id;
            string s_char_id_next;

            s_col_set_id = cdvCollectionSet.Text;
            i_col_set_ver = MPCF.ToInt(spdVersion.ActiveSheet.Cells[spdVersion.ActiveSheet.ActiveRowIndex, COL1_VERSION].Value);
            s_char_id = MPCF.Trim(spdCharacter.ActiveSheet.Cells[i_row, COL2_CHAR_ID].Value);
            s_char_id_next = MPCF.Trim(spdCharacter.ActiveSheet.Cells[i_row + 1, COL2_CHAR_ID].Value);

            if (Change_Character_Seq(s_col_set_id, i_col_set_ver, s_char_id, s_char_id_next) == false) return;

            spdCharacter.ActiveSheet.MoveRow(i_row, i_row + 1, true);

            spdCharacter.ActiveSheet.AddSelection(i_row + 1, 0, 1, 1);
            spdCharacter.ActiveSheet.RemoveSelection(i_row, 0, 1, 1);

            spdCharacter.ShowRow(spdCharacter.GetActiveRowViewportIndex(), i_row + 1, VerticalPosition.Center);
        }

        private void chkUseCharUnitFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUseCharUnitFlag.Checked == true)
                {
                    chkOptUnitFlag.Checked = false;
                    chkUnitNullFlag.Checked = false;
                    chkDefaultUnit.Checked = false;
                    chkDefaultUnitOvr.Checked = false;
                    chkOptUnitFlag.Enabled = false;
                    chkUnitNullFlag.Enabled = false;
                    chkDefaultUnit.Enabled = false;
                    chkDefaultUnitOvr.Enabled = false;
                    lblUnitTable.Enabled = false;
                    cdvUnitTable.Text = "";
                    cdvUnitTable.Enabled = false;
                }
                else
                {
                    chkOptUnitFlag.Enabled = true;
                    chkUnitNullFlag.Enabled = true;
                    chkDefaultUnit.Enabled = true;
                    chkDefaultUnitOvr.Enabled = true;
                    lblUnitTable.Enabled = true;
                    cdvUnitTable.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkOptUnitFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOptUnitFlag.Checked == true)
            {
                lblMinUnitCount.Enabled = true;
                txtMinUnitCount.ReadOnly = false;

                chkMinUnitByLotQty.Enabled = true;
            }
            else
            {
                lblMinUnitCount.Enabled = false;
                txtMinUnitCount.ReadOnly = true;
                txtMinUnitCount.Text = "";

                chkMinUnitByLotQty.Checked = false;
                chkMinUnitByLotQty.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData("2");

                if (cdvCollectionSet.Text == "")
                {
                    return;
                }
                if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdVersion);

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCF.ClearList(spdCharacter);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkMinUnitByLotQty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinUnitByLotQty.Checked == true)
            {
                txtMinUnitCount.Text = "";
                txtMinUnitCount.ReadOnly = true;
            }
            else
            {
                txtMinUnitCount.ReadOnly = false;
            }
        }



#endif

    }
}
