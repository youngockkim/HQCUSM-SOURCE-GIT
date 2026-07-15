
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using FarPoint.Win.Spread;
using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSECSetupGroupFunction.vb
//   Description : Security Group Function Related Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - Add_GrpFunc() : Add Function To SpreadSheet
//       - Delete_GrpFunc() : Delete Function From SpreadSheet
//       - View_GrpFunc_List() : View all table list which is included in one factory
//       - Update_GrpFunc() : Attach Function to Security Group / Detach Function From Security Group
//       - Update_GrpFunc_List() : Update Security Group function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by SKJIN
//       - 2007-03-28 : Modified by H.J. Noh
//                      CheckCondition(string FuncName, char ProcStep) 의 
//                      Switch case 문의 "Update_GrpFunc_List" 조건에서
//                      (bool) 캐스팅후 true 인지 판별하는 부분에서 실행시에 
//                      항목 Check를 하지 않은 List에서 null에 대한 참조 오류가 발생
//                      => "== true" 를 "!=null" 로 수정
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.SECCore
{
    public class frmSECSetupGroupFunction : Miracom.MESCore.SetupForm01
    {

        #region " Windows Form auto generated code "

        public frmSECSetupGroupFunction()
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




        private System.Windows.Forms.GroupBox grpSecGrp;
        private System.Windows.Forms.Label lblSecGrp;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSecGrp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.TabControl tabFunc;
        private FarPoint.Win.Spread.FpSpread spdControl;
        private FarPoint.Win.Spread.FpSpread spdTab;
        private FarPoint.Win.Spread.FpSpread spdOption;
        private FarPoint.Win.Spread.FpSpread spdField;
        private FarPoint.Win.Spread.SheetView spdControl_Sheet1;
        private FarPoint.Win.Spread.SheetView spdTab_Sheet1;
        private FarPoint.Win.Spread.SheetView spdOption_Sheet1;
        private FarPoint.Win.Spread.SheetView spdField_Sheet1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpAttachFunc;
        private System.Windows.Forms.Panel pnlAttachFuncMid;
        private System.Windows.Forms.TabPage tbpAttachFunc;
        private System.Windows.Forms.TabPage tbpControls;
        private System.Windows.Forms.TabPage tbpTabPages;
        private System.Windows.Forms.TabPage tbpOptions;
        private Panel pnlFuncRight;
        private Panel pnlFuncRightMid;
        private Miracom.UI.Controls.MCListView.MCListView lisAvailFunc;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private Panel pnlFuncRightTop;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFGroup;
        private Label lblFGroup;
        private Button btnAddChild;
        private Button btnSeparator;
        private Panel pnlFuncLeft;
        private Panel pnlFuncLeftTop;
        private Panel pnlFuncLeftMid;
        private Miracom.UI.Controls.MCTreeView.MCTreeView tvAttachFunc;
        private CheckBox chkShortSHIFT;
        private CheckBox chkShortALT;
        private CheckBox chkShortCTRL;
        private Button btnShortApply;
        private ComboBox cboShortKey;
        private CheckBox chkAddToolBar;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPgmID;
        private Label lblProgramID;
        private Button btnExpand;
        private Button btnCollapse;
        private Button btnDown;
        private Button btnUp;
        private System.Windows.Forms.TabPage tbpFields;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType6 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType7 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType8 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType9 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType10 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType11 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType12 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType13 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType14 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType15 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType16 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType17 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType18 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType19 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType20 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType21 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType22 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType23 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType24 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType25 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType26 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType27 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType28 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType29 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType30 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType31 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType32 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSECSetupGroupFunction));
            this.grpSecGrp = new System.Windows.Forms.GroupBox();
            this.cdvPgmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProgramID = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cdvSecGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSecGrp = new System.Windows.Forms.Label();
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.tabFunc = new System.Windows.Forms.TabControl();
            this.tbpAttachFunc = new System.Windows.Forms.TabPage();
            this.grpAttachFunc = new System.Windows.Forms.GroupBox();
            this.pnlFuncLeft = new System.Windows.Forms.Panel();
            this.pnlFuncLeftMid = new System.Windows.Forms.Panel();
            this.tvAttachFunc = new Miracom.UI.Controls.MCTreeView.MCTreeView();
            this.pnlFuncLeftTop = new System.Windows.Forms.Panel();
            this.chkAddToolBar = new System.Windows.Forms.CheckBox();
            this.cboShortKey = new System.Windows.Forms.ComboBox();
            this.btnShortApply = new System.Windows.Forms.Button();
            this.chkShortSHIFT = new System.Windows.Forms.CheckBox();
            this.chkShortALT = new System.Windows.Forms.CheckBox();
            this.chkShortCTRL = new System.Windows.Forms.CheckBox();
            this.pnlFuncRight = new System.Windows.Forms.Panel();
            this.pnlFuncRightMid = new System.Windows.Forms.Panel();
            this.lisAvailFunc = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFuncRightTop = new System.Windows.Forms.Panel();
            this.cdvFGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFGroup = new System.Windows.Forms.Label();
            this.pnlAttachFuncMid = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnSeparator = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbpControls = new System.Windows.Forms.TabPage();
            this.spdControl = new FarPoint.Win.Spread.FpSpread();
            this.spdControl_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpTabPages = new System.Windows.Forms.TabPage();
            this.spdTab = new FarPoint.Win.Spread.FpSpread();
            this.spdTab_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpOptions = new System.Windows.Forms.TabPage();
            this.spdOption = new FarPoint.Win.Spread.FpSpread();
            this.spdOption_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpFields = new System.Windows.Forms.TabPage();
            this.spdField = new FarPoint.Win.Spread.FpSpread();
            this.spdField_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpSecGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPgmID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).BeginInit();
            this.pnlGrp.SuspendLayout();
            this.tabFunc.SuspendLayout();
            this.tbpAttachFunc.SuspendLayout();
            this.grpAttachFunc.SuspendLayout();
            this.pnlFuncLeft.SuspendLayout();
            this.pnlFuncLeftMid.SuspendLayout();
            this.pnlFuncLeftTop.SuspendLayout();
            this.pnlFuncRight.SuspendLayout();
            this.pnlFuncRightMid.SuspendLayout();
            this.pnlFuncRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).BeginInit();
            this.pnlAttachFuncMid.SuspendLayout();
            this.tbpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdControl_Sheet1)).BeginInit();
            this.tbpTabPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTab_Sheet1)).BeginInit();
            this.tbpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOption_Sheet1)).BeginInit();
            this.tbpFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdField_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(375, 8);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(466, 8);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(559, 8);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(651, 8);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExpand);
            this.pnlBottom.Controls.Add(this.btnCollapse);
            this.pnlBottom.Location = new System.Drawing.Point(0, 516);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(742, 37);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExpand, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabFunc);
            this.pnlCenter.Location = new System.Drawing.Point(0, 66);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 450);
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
            this.lblFormTitle.Text = "Security Group Function Setup";
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
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            // 
            // grpSecGrp
            // 
            this.grpSecGrp.Controls.Add(this.cdvPgmID);
            this.grpSecGrp.Controls.Add(this.lblProgramID);
            this.grpSecGrp.Controls.Add(this.lblDesc);
            this.grpSecGrp.Controls.Add(this.txtDesc);
            this.grpSecGrp.Controls.Add(this.cdvSecGrp);
            this.grpSecGrp.Controls.Add(this.lblSecGrp);
            this.grpSecGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSecGrp.Location = new System.Drawing.Point(3, 0);
            this.grpSecGrp.Name = "grpSecGrp";
            this.grpSecGrp.Size = new System.Drawing.Size(736, 66);
            this.grpSecGrp.TabIndex = 0;
            this.grpSecGrp.TabStop = false;
            // 
            // cdvPgmID
            // 
            this.cdvPgmID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPgmID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPgmID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPgmID.BtnToolTipText = "";
            this.cdvPgmID.DescText = "";
            this.cdvPgmID.DisplaySubItemIndex = -1;
            this.cdvPgmID.DisplayText = "";
            this.cdvPgmID.Focusing = null;
            this.cdvPgmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPgmID.Index = 1;
            this.cdvPgmID.IsViewBtnImage = false;
            this.cdvPgmID.Location = new System.Drawing.Point(120, 38);
            this.cdvPgmID.MaxLength = 20;
            this.cdvPgmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPgmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPgmID.Name = "cdvPgmID";
            this.cdvPgmID.ReadOnly = false;
            this.cdvPgmID.SearchSubItemIndex = 0;
            this.cdvPgmID.SelectedDescIndex = -1;
            this.cdvPgmID.SelectedSubItemIndex = -1;
            this.cdvPgmID.SelectionStart = 0;
            this.cdvPgmID.Size = new System.Drawing.Size(180, 20);
            this.cdvPgmID.SmallImageList = null;
            this.cdvPgmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPgmID.TabIndex = 5;
            this.cdvPgmID.TextBoxToolTipText = "";
            this.cdvPgmID.TextBoxWidth = 180;
            this.cdvPgmID.VisibleButton = true;
            this.cdvPgmID.VisibleColumnHeader = false;
            this.cdvPgmID.VisibleDescription = false;
            this.cdvPgmID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPgmID_SelectedItemChanged);
            this.cdvPgmID.ButtonPress += new System.EventHandler(this.cdvPgmID_ButtonPress);
            // 
            // lblProgramID
            // 
            this.lblProgramID.AutoSize = true;
            this.lblProgramID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProgramID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProgramID.Location = new System.Drawing.Point(15, 41);
            this.lblProgramID.Name = "lblProgramID";
            this.lblProgramID.Size = new System.Drawing.Size(70, 13);
            this.lblProgramID.TabIndex = 4;
            this.lblProgramID.Text = "Program ID";
            this.lblProgramID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(316, 17);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(388, 14);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(342, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TabStop = false;
            // 
            // cdvSecGrp
            // 
            this.cdvSecGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSecGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSecGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSecGrp.BtnToolTipText = "";
            this.cdvSecGrp.DescText = "";
            this.cdvSecGrp.DisplaySubItemIndex = -1;
            this.cdvSecGrp.DisplayText = "";
            this.cdvSecGrp.Focusing = null;
            this.cdvSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSecGrp.Index = 0;
            this.cdvSecGrp.IsViewBtnImage = false;
            this.cdvSecGrp.Location = new System.Drawing.Point(120, 14);
            this.cdvSecGrp.MaxLength = 20;
            this.cdvSecGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.Name = "cdvSecGrp";
            this.cdvSecGrp.ReadOnly = false;
            this.cdvSecGrp.SearchSubItemIndex = 0;
            this.cdvSecGrp.SelectedDescIndex = -1;
            this.cdvSecGrp.SelectedSubItemIndex = -1;
            this.cdvSecGrp.SelectionStart = 0;
            this.cdvSecGrp.Size = new System.Drawing.Size(180, 20);
            this.cdvSecGrp.SmallImageList = null;
            this.cdvSecGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSecGrp.TabIndex = 1;
            this.cdvSecGrp.TextBoxToolTipText = "";
            this.cdvSecGrp.TextBoxWidth = 180;
            this.cdvSecGrp.VisibleButton = true;
            this.cdvSecGrp.VisibleColumnHeader = false;
            this.cdvSecGrp.VisibleDescription = false;
            this.cdvSecGrp.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSecGrp_SelectedItemChanged);
            this.cdvSecGrp.ButtonPress += new System.EventHandler(this.cdvSecGrp_ButtonPress);
            this.cdvSecGrp.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvSecGrp_TextBoxKeyPress);
            // 
            // lblSecGrp
            // 
            this.lblSecGrp.AutoSize = true;
            this.lblSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSecGrp.Location = new System.Drawing.Point(15, 17);
            this.lblSecGrp.Name = "lblSecGrp";
            this.lblSecGrp.Size = new System.Drawing.Size(91, 13);
            this.lblSecGrp.TabIndex = 0;
            this.lblSecGrp.Text = "Security Group";
            this.lblSecGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpSecGrp);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 66);
            this.pnlGrp.TabIndex = 0;
            // 
            // tabFunc
            // 
            this.tabFunc.Controls.Add(this.tbpAttachFunc);
            this.tabFunc.Controls.Add(this.tbpControls);
            this.tabFunc.Controls.Add(this.tbpTabPages);
            this.tabFunc.Controls.Add(this.tbpOptions);
            this.tabFunc.Controls.Add(this.tbpFields);
            this.tabFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFunc.ItemSize = new System.Drawing.Size(60, 18);
            this.tabFunc.Location = new System.Drawing.Point(3, 0);
            this.tabFunc.Name = "tabFunc";
            this.tabFunc.SelectedIndex = 0;
            this.tabFunc.Size = new System.Drawing.Size(739, 450);
            this.tabFunc.TabIndex = 1;
            this.tabFunc.SelectedIndexChanged += new System.EventHandler(this.tabFunc_SelectedIndexChanged);
            // 
            // tbpAttachFunc
            // 
            this.tbpAttachFunc.Controls.Add(this.grpAttachFunc);
            this.tbpAttachFunc.Location = new System.Drawing.Point(4, 22);
            this.tbpAttachFunc.Name = "tbpAttachFunc";
            this.tbpAttachFunc.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpAttachFunc.Size = new System.Drawing.Size(731, 424);
            this.tbpAttachFunc.TabIndex = 0;
            this.tbpAttachFunc.Text = "Attach Function";
            // 
            // grpAttachFunc
            // 
            this.grpAttachFunc.Controls.Add(this.pnlFuncLeft);
            this.grpAttachFunc.Controls.Add(this.pnlFuncRight);
            this.grpAttachFunc.Controls.Add(this.pnlAttachFuncMid);
            this.grpAttachFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttachFunc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAttachFunc.Location = new System.Drawing.Point(3, 0);
            this.grpAttachFunc.Name = "grpAttachFunc";
            this.grpAttachFunc.Size = new System.Drawing.Size(725, 421);
            this.grpAttachFunc.TabIndex = 0;
            this.grpAttachFunc.TabStop = false;
            this.grpAttachFunc.Resize += new System.EventHandler(this.grpAttachFunc_Resize);
            // 
            // pnlFuncLeft
            // 
            this.pnlFuncLeft.Controls.Add(this.pnlFuncLeftMid);
            this.pnlFuncLeft.Controls.Add(this.pnlFuncLeftTop);
            this.pnlFuncLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFuncLeft.Location = new System.Drawing.Point(3, 16);
            this.pnlFuncLeft.Name = "pnlFuncLeft";
            this.pnlFuncLeft.Size = new System.Drawing.Size(290, 402);
            this.pnlFuncLeft.TabIndex = 0;
            // 
            // pnlFuncLeftMid
            // 
            this.pnlFuncLeftMid.Controls.Add(this.tvAttachFunc);
            this.pnlFuncLeftMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncLeftMid.Location = new System.Drawing.Point(0, 42);
            this.pnlFuncLeftMid.Name = "pnlFuncLeftMid";
            this.pnlFuncLeftMid.Size = new System.Drawing.Size(290, 360);
            this.pnlFuncLeftMid.TabIndex = 1;
            // 
            // tvAttachFunc
            // 
            this.tvAttachFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAttachFunc.Location = new System.Drawing.Point(0, 0);
            this.tvAttachFunc.Name = "tvAttachFunc";
            this.tvAttachFunc.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("tvAttachFunc.SelectedNodes")));
            this.tvAttachFunc.ShowNodeToolTips = true;
            this.tvAttachFunc.ShowRootLines = false;
            this.tvAttachFunc.Size = new System.Drawing.Size(290, 360);
            this.tvAttachFunc.TabIndex = 0;
            this.tvAttachFunc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAttachFunc_AfterSelect);
            // 
            // pnlFuncLeftTop
            // 
            this.pnlFuncLeftTop.Controls.Add(this.chkAddToolBar);
            this.pnlFuncLeftTop.Controls.Add(this.cboShortKey);
            this.pnlFuncLeftTop.Controls.Add(this.btnShortApply);
            this.pnlFuncLeftTop.Controls.Add(this.chkShortSHIFT);
            this.pnlFuncLeftTop.Controls.Add(this.chkShortALT);
            this.pnlFuncLeftTop.Controls.Add(this.chkShortCTRL);
            this.pnlFuncLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFuncLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncLeftTop.Name = "pnlFuncLeftTop";
            this.pnlFuncLeftTop.Size = new System.Drawing.Size(290, 42);
            this.pnlFuncLeftTop.TabIndex = 0;
            // 
            // chkAddToolBar
            // 
            this.chkAddToolBar.AutoSize = true;
            this.chkAddToolBar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAddToolBar.Location = new System.Drawing.Point(9, 22);
            this.chkAddToolBar.Name = "chkAddToolBar";
            this.chkAddToolBar.Size = new System.Drawing.Size(118, 18);
            this.chkAddToolBar.TabIndex = 4;
            this.chkAddToolBar.Text = "Add in the tool bar";
            // 
            // cboShortKey
            // 
            this.cboShortKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboShortKey.FormattingEnabled = true;
            this.cboShortKey.Items.AddRange(new object[] {
            "",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboShortKey.Location = new System.Drawing.Point(179, 0);
            this.cboShortKey.MaxDropDownItems = 10;
            this.cboShortKey.Name = "cboShortKey";
            this.cboShortKey.Size = new System.Drawing.Size(56, 21);
            this.cboShortKey.TabIndex = 3;
            // 
            // btnShortApply
            // 
            this.btnShortApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShortApply.Location = new System.Drawing.Point(241, 0);
            this.btnShortApply.Name = "btnShortApply";
            this.btnShortApply.Size = new System.Drawing.Size(41, 38);
            this.btnShortApply.TabIndex = 5;
            this.btnShortApply.Text = "Apply";
            this.btnShortApply.Click += new System.EventHandler(this.btnShortApply_Click);
            // 
            // chkShortSHIFT
            // 
            this.chkShortSHIFT.AutoSize = true;
            this.chkShortSHIFT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortSHIFT.Location = new System.Drawing.Point(117, 2);
            this.chkShortSHIFT.Name = "chkShortSHIFT";
            this.chkShortSHIFT.Size = new System.Drawing.Size(63, 18);
            this.chkShortSHIFT.TabIndex = 2;
            this.chkShortSHIFT.Text = "SHIFT";
            // 
            // chkShortALT
            // 
            this.chkShortALT.AutoSize = true;
            this.chkShortALT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortALT.Location = new System.Drawing.Point(69, 2);
            this.chkShortALT.Name = "chkShortALT";
            this.chkShortALT.Size = new System.Drawing.Size(52, 18);
            this.chkShortALT.TabIndex = 1;
            this.chkShortALT.Text = "ALT";
            // 
            // chkShortCTRL
            // 
            this.chkShortCTRL.AutoSize = true;
            this.chkShortCTRL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShortCTRL.Location = new System.Drawing.Point(9, 2);
            this.chkShortCTRL.Name = "chkShortCTRL";
            this.chkShortCTRL.Size = new System.Drawing.Size(60, 18);
            this.chkShortCTRL.TabIndex = 0;
            this.chkShortCTRL.Text = "CTRL";
            // 
            // pnlFuncRight
            // 
            this.pnlFuncRight.Controls.Add(this.pnlFuncRightMid);
            this.pnlFuncRight.Controls.Add(this.pnlFuncRightTop);
            this.pnlFuncRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFuncRight.Location = new System.Drawing.Point(427, 16);
            this.pnlFuncRight.Name = "pnlFuncRight";
            this.pnlFuncRight.Size = new System.Drawing.Size(295, 402);
            this.pnlFuncRight.TabIndex = 1;
            // 
            // pnlFuncRightMid
            // 
            this.pnlFuncRightMid.Controls.Add(this.lisAvailFunc);
            this.pnlFuncRightMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncRightMid.Location = new System.Drawing.Point(0, 28);
            this.pnlFuncRightMid.Name = "pnlFuncRightMid";
            this.pnlFuncRightMid.Size = new System.Drawing.Size(295, 374);
            this.pnlFuncRightMid.TabIndex = 1;
            // 
            // lisAvailFunc
            // 
            this.lisAvailFunc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lisAvailFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAvailFunc.EnableSort = true;
            this.lisAvailFunc.EnableSortIcon = true;
            this.lisAvailFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAvailFunc.FullRowSelect = true;
            this.lisAvailFunc.Location = new System.Drawing.Point(0, 0);
            this.lisAvailFunc.Name = "lisAvailFunc";
            this.lisAvailFunc.Size = new System.Drawing.Size(295, 374);
            this.lisAvailFunc.TabIndex = 0;
            this.lisAvailFunc.UseCompatibleStateImageBehavior = false;
            this.lisAvailFunc.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Available Function";
            this.ColumnHeader5.Width = 120;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 170;
            // 
            // pnlFuncRightTop
            // 
            this.pnlFuncRightTop.Controls.Add(this.cdvFGroup);
            this.pnlFuncRightTop.Controls.Add(this.lblFGroup);
            this.pnlFuncRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFuncRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncRightTop.Name = "pnlFuncRightTop";
            this.pnlFuncRightTop.Size = new System.Drawing.Size(295, 28);
            this.pnlFuncRightTop.TabIndex = 0;
            // 
            // cdvFGroup
            // 
            this.cdvFGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFGroup.BtnToolTipText = "";
            this.cdvFGroup.DescText = "";
            this.cdvFGroup.DisplaySubItemIndex = -1;
            this.cdvFGroup.DisplayText = "";
            this.cdvFGroup.Focusing = null;
            this.cdvFGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFGroup.Index = 0;
            this.cdvFGroup.IsViewBtnImage = false;
            this.cdvFGroup.Location = new System.Drawing.Point(95, 0);
            this.cdvFGroup.MaxLength = 20;
            this.cdvFGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.Name = "cdvFGroup";
            this.cdvFGroup.ReadOnly = false;
            this.cdvFGroup.SearchSubItemIndex = 0;
            this.cdvFGroup.SelectedDescIndex = -1;
            this.cdvFGroup.SelectedSubItemIndex = -1;
            this.cdvFGroup.SelectionStart = 0;
            this.cdvFGroup.Size = new System.Drawing.Size(192, 20);
            this.cdvFGroup.SmallImageList = null;
            this.cdvFGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFGroup.TabIndex = 0;
            this.cdvFGroup.TextBoxToolTipText = "";
            this.cdvFGroup.TextBoxWidth = 192;
            this.cdvFGroup.VisibleButton = true;
            this.cdvFGroup.VisibleColumnHeader = false;
            this.cdvFGroup.VisibleDescription = false;
            this.cdvFGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFGroup_SelectedItemChanged);
            this.cdvFGroup.ButtonPress += new System.EventHandler(this.cdvFGroup_ButtonPress);
            // 
            // lblFGroup
            // 
            this.lblFGroup.AutoSize = true;
            this.lblFGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFGroup.Location = new System.Drawing.Point(10, 2);
            this.lblFGroup.Name = "lblFGroup";
            this.lblFGroup.Size = new System.Drawing.Size(80, 13);
            this.lblFGroup.TabIndex = 0;
            this.lblFGroup.Text = "Function Group";
            this.lblFGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAttachFuncMid
            // 
            this.pnlAttachFuncMid.Controls.Add(this.btnDown);
            this.pnlAttachFuncMid.Controls.Add(this.btnUp);
            this.pnlAttachFuncMid.Controls.Add(this.btnAddChild);
            this.pnlAttachFuncMid.Controls.Add(this.btnSeparator);
            this.pnlAttachFuncMid.Controls.Add(this.btnDel);
            this.pnlAttachFuncMid.Controls.Add(this.btnAdd);
            this.pnlAttachFuncMid.Location = new System.Drawing.Point(330, 20);
            this.pnlAttachFuncMid.Name = "pnlAttachFuncMid";
            this.pnlAttachFuncMid.Size = new System.Drawing.Size(47, 236);
            this.pnlAttachFuncMid.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(3, 209);
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
            this.btnUp.Location = new System.Drawing.Point(3, 185);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddChild.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddChild.Location = new System.Drawing.Point(11, 6);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(24, 24);
            this.btnAddChild.TabIndex = 0;
            this.btnAddChild.Text = "<<";
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnSeparator
            // 
            this.btnSeparator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSeparator.Location = new System.Drawing.Point(11, 36);
            this.btnSeparator.Name = "btnSeparator";
            this.btnSeparator.Size = new System.Drawing.Size(24, 24);
            this.btnSeparator.TabIndex = 1;
            this.btnSeparator.Text = "< S";
            this.btnSeparator.Click += new System.EventHandler(this.btnSeparator_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(11, 109);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(11, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbpControls
            // 
            this.tbpControls.Controls.Add(this.spdControl);
            this.tbpControls.Location = new System.Drawing.Point(4, 22);
            this.tbpControls.Name = "tbpControls";
            this.tbpControls.Padding = new System.Windows.Forms.Padding(3);
            this.tbpControls.Size = new System.Drawing.Size(731, 424);
            this.tbpControls.TabIndex = 1;
            this.tbpControls.Text = "Controls";
            this.tbpControls.Visible = false;
            // 
            // spdControl
            // 
            this.spdControl.AccessibleDescription = "spdControl, Sheet1, Row 0, Column 0, ";
            this.spdControl.BackColor = System.Drawing.SystemColors.Control;
            this.spdControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdControl.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdControl.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdControl.HorizontalScrollBar.Name = "";
            this.spdControl.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdControl.HorizontalScrollBar.TabIndex = 4;
            this.spdControl.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdControl.Location = new System.Drawing.Point(3, 3);
            this.spdControl.Name = "spdControl";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdControl.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdControl.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdControl.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdControl.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdControl_Sheet1});
            this.spdControl.Size = new System.Drawing.Size(725, 418);
            this.spdControl.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdControl.TabIndex = 0;
            this.spdControl.TabStop = false;
            this.spdControl.TextTipDelay = 200;
            this.spdControl.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdControl.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdControl.VerticalScrollBar.Name = "";
            this.spdControl.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdControl.VerticalScrollBar.TabIndex = 5;
            this.spdControl.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdControl.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdControl_ComboSelChange);
            // 
            // spdControl_Sheet1
            // 
            this.spdControl_Sheet1.Reset();
            spdControl_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdControl_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdControl_Sheet1.ColumnCount = 23;
            spdControl_Sheet1.RowCount = 1;
            spdControl_Sheet1.RowHeader.ColumnCount = 0;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdControl_Sheet1.Cells.Get(0, 0).CellType = checkBoxCellType1;
            this.spdControl_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Cells.Get(0, 1).RowSpan = 2;
            this.spdControl_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdControl_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdControl_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdControl_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Function";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Control Name 1";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Control Name 2";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Control Name 3";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Control Name 4";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Control Name 5";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Control Name 6";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Control Name 7";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Control Name 8";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Control Name 9";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Control Name 10";
            this.spdControl_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Enable";
            this.spdControl_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdControl_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdControl_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top);
            this.spdControl_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdControl_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdControl_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(0).Width = 35F;
            this.spdControl_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(1).Label = "Function";
            this.spdControl_Sheet1.Columns.Get(1).Locked = true;
            this.spdControl_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(1).Width = 90F;
            this.spdControl_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(2).Label = "Description";
            this.spdControl_Sheet1.Columns.Get(2).Locked = true;
            this.spdControl_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(2).Width = 150F;
            this.spdControl_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(3).Label = "Control Name 1";
            this.spdControl_Sheet1.Columns.Get(3).Locked = true;
            this.spdControl_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(3).Width = 100F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "",
        "Yes"};
            this.spdControl_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
            this.spdControl_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(4).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(4).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(5).Label = "Control Name 2";
            this.spdControl_Sheet1.Columns.Get(5).Locked = true;
            this.spdControl_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(5).Width = 100F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType2.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(6).CellType = comboBoxCellType2;
            this.spdControl_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(6).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(6).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(7).Label = "Control Name 3";
            this.spdControl_Sheet1.Columns.Get(7).Locked = true;
            this.spdControl_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(7).Width = 100F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType3.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType3.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(8).CellType = comboBoxCellType3;
            this.spdControl_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(8).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(8).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(9).Label = "Control Name 4";
            this.spdControl_Sheet1.Columns.Get(9).Locked = true;
            this.spdControl_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(9).Width = 100F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType4.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType4.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(10).CellType = comboBoxCellType4;
            this.spdControl_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(10).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(10).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(11).Label = "Control Name 5";
            this.spdControl_Sheet1.Columns.Get(11).Locked = true;
            this.spdControl_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(11).Width = 100F;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType5.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType5.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(12).CellType = comboBoxCellType5;
            this.spdControl_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(12).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(12).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(13).Label = "Control Name 6";
            this.spdControl_Sheet1.Columns.Get(13).Locked = true;
            this.spdControl_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(13).Width = 100F;
            comboBoxCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType6.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType6.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(14).CellType = comboBoxCellType6;
            this.spdControl_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(14).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(14).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(15).Label = "Control Name 7";
            this.spdControl_Sheet1.Columns.Get(15).Locked = true;
            this.spdControl_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(15).Width = 100F;
            comboBoxCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType7.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType7.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(16).CellType = comboBoxCellType7;
            this.spdControl_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(16).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(16).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(17).Label = "Control Name 8";
            this.spdControl_Sheet1.Columns.Get(17).Locked = true;
            this.spdControl_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(17).Width = 100F;
            comboBoxCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType8.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType8.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(18).CellType = comboBoxCellType8;
            this.spdControl_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(18).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(18).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(19).Label = "Control Name 9";
            this.spdControl_Sheet1.Columns.Get(19).Locked = true;
            this.spdControl_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(19).Width = 100F;
            comboBoxCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType9.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType9.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(20).CellType = comboBoxCellType9;
            this.spdControl_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(20).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(20).Width = 45F;
            this.spdControl_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdControl_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdControl_Sheet1.Columns.Get(21).Label = "Control Name 10";
            this.spdControl_Sheet1.Columns.Get(21).Locked = true;
            this.spdControl_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(21).Width = 105F;
            comboBoxCellType10.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType10.Items = new string[] {
        "",
        "Yes"};
            comboBoxCellType10.ListOffset = 1;
            this.spdControl_Sheet1.Columns.Get(22).CellType = comboBoxCellType10;
            this.spdControl_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(22).Label = "Enable";
            this.spdControl_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdControl_Sheet1.Columns.Get(22).Width = 45F;
            this.spdControl_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdControl_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdControl_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdControl_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdControl_Sheet1.Rows.Get(0).Height = 18F;
            this.spdControl_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdControl_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdControl_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpTabPages
            // 
            this.tbpTabPages.Controls.Add(this.spdTab);
            this.tbpTabPages.Location = new System.Drawing.Point(4, 22);
            this.tbpTabPages.Name = "tbpTabPages";
            this.tbpTabPages.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTabPages.Size = new System.Drawing.Size(731, 424);
            this.tbpTabPages.TabIndex = 2;
            this.tbpTabPages.Text = "Tab Pages";
            this.tbpTabPages.Visible = false;
            // 
            // spdTab
            // 
            this.spdTab.AccessibleDescription = "spdTab, Sheet1, Row 0, Column 0, ";
            this.spdTab.BackColor = System.Drawing.SystemColors.Control;
            this.spdTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdTab.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdTab.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTab.HorizontalScrollBar.Name = "";
            this.spdTab.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdTab.HorizontalScrollBar.TabIndex = 6;
            this.spdTab.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTab.Location = new System.Drawing.Point(3, 3);
            this.spdTab.Name = "spdTab";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer3;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer3;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdTab.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdTab.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdTab.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdTab.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdTab_Sheet1});
            this.spdTab.Size = new System.Drawing.Size(725, 418);
            this.spdTab.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdTab.TabIndex = 2;
            this.spdTab.TabStop = false;
            this.spdTab.TextTipDelay = 200;
            this.spdTab.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdTab.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTab.VerticalScrollBar.Name = "";
            this.spdTab.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdTab.VerticalScrollBar.TabIndex = 7;
            this.spdTab.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTab.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdTab_ComboSelChange);
            // 
            // spdTab_Sheet1
            // 
            this.spdTab_Sheet1.Reset();
            spdTab_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdTab_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdTab_Sheet1.ColumnCount = 23;
            spdTab_Sheet1.RowCount = 1;
            spdTab_Sheet1.RowHeader.ColumnCount = 0;
            checkBoxCellType3.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdTab_Sheet1.Cells.Get(0, 0).CellType = checkBoxCellType3;
            this.spdTab_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdTab_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Cells.Get(0, 1).Border = complexBorder1;
            this.spdTab_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTab_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdTab_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTab_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Function";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tabpage Name 1";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tabpage Name 2";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Tabpage Name 3";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Tabpage Name 4";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Tabpage Name 5";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Tabpage Name 6";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tabpage Name 7";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tabpage Name 8";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tabpage Name 9";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tabpage Name 10";
            this.spdTab_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Enable";
            this.spdTab_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTab_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTab_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType4.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top);
            this.spdTab_Sheet1.Columns.Get(0).CellType = checkBoxCellType4;
            this.spdTab_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdTab_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(0).Width = 35F;
            this.spdTab_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(1).Label = "Function";
            this.spdTab_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(1).Width = 90F;
            this.spdTab_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(2).Label = "Description";
            this.spdTab_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(2).Width = 150F;
            this.spdTab_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(3).Label = "Tabpage Name 1";
            this.spdTab_Sheet1.Columns.Get(3).Locked = true;
            this.spdTab_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(3).Width = 110F;
            comboBoxCellType11.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType11.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(4).CellType = comboBoxCellType11;
            this.spdTab_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(4).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(4).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(5).Label = "Tabpage Name 2";
            this.spdTab_Sheet1.Columns.Get(5).Locked = true;
            this.spdTab_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(5).Width = 110F;
            comboBoxCellType12.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType12.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(6).CellType = comboBoxCellType12;
            this.spdTab_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(6).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(6).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(7).Label = "Tabpage Name 3";
            this.spdTab_Sheet1.Columns.Get(7).Locked = true;
            this.spdTab_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(7).Width = 110F;
            comboBoxCellType13.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType13.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(8).CellType = comboBoxCellType13;
            this.spdTab_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(8).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(8).Width = 47F;
            this.spdTab_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(9).Label = "Tabpage Name 4";
            this.spdTab_Sheet1.Columns.Get(9).Locked = true;
            this.spdTab_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(9).Width = 110F;
            comboBoxCellType14.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType14.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(10).CellType = comboBoxCellType14;
            this.spdTab_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(10).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(10).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(11).Label = "Tabpage Name 5";
            this.spdTab_Sheet1.Columns.Get(11).Locked = true;
            this.spdTab_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(11).Width = 110F;
            comboBoxCellType15.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType15.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(12).CellType = comboBoxCellType15;
            this.spdTab_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(12).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(12).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(13).Label = "Tabpage Name 6";
            this.spdTab_Sheet1.Columns.Get(13).Locked = true;
            this.spdTab_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(13).Width = 110F;
            comboBoxCellType16.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType16.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(14).CellType = comboBoxCellType16;
            this.spdTab_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(14).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(14).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(15).Label = "Tabpage Name 7";
            this.spdTab_Sheet1.Columns.Get(15).Locked = true;
            this.spdTab_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(15).Width = 110F;
            comboBoxCellType17.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType17.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(16).CellType = comboBoxCellType17;
            this.spdTab_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(16).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(16).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(17).Label = "Tabpage Name 8";
            this.spdTab_Sheet1.Columns.Get(17).Locked = true;
            this.spdTab_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(17).Width = 110F;
            comboBoxCellType18.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType18.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(18).CellType = comboBoxCellType18;
            this.spdTab_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(18).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(18).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(19).Label = "Tabpage Name 9";
            this.spdTab_Sheet1.Columns.Get(19).Locked = true;
            this.spdTab_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(19).Width = 110F;
            comboBoxCellType19.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType19.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(20).CellType = comboBoxCellType19;
            this.spdTab_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(20).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(20).Width = 45F;
            this.spdTab_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdTab_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(21).Label = "Tabpage Name 10";
            this.spdTab_Sheet1.Columns.Get(21).Locked = true;
            this.spdTab_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(21).Width = 110F;
            comboBoxCellType20.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType20.Items = new string[] {
        "",
        "Yes"};
            this.spdTab_Sheet1.Columns.Get(22).CellType = comboBoxCellType20;
            this.spdTab_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTab_Sheet1.Columns.Get(22).Label = "Enable";
            this.spdTab_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTab_Sheet1.Columns.Get(22).Width = 45F;
            this.spdTab_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdTab_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdTab_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTab_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdTab_Sheet1.Rows.Get(0).Height = 18F;
            this.spdTab_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTab_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdTab_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpOptions
            // 
            this.tbpOptions.Controls.Add(this.spdOption);
            this.tbpOptions.Location = new System.Drawing.Point(4, 22);
            this.tbpOptions.Name = "tbpOptions";
            this.tbpOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOptions.Size = new System.Drawing.Size(731, 424);
            this.tbpOptions.TabIndex = 3;
            this.tbpOptions.Text = "Options";
            this.tbpOptions.Visible = false;
            // 
            // spdOption
            // 
            this.spdOption.AccessibleDescription = "spdOption, Sheet1, Row 0, Column 0, ";
            this.spdOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOption.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOption.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOption.HorizontalScrollBar.Name = "";
            this.spdOption.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdOption.HorizontalScrollBar.TabIndex = 22;
            this.spdOption.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOption.Location = new System.Drawing.Point(3, 3);
            this.spdOption.Name = "spdOption";
            this.spdOption.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOption.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOption.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOption_Sheet1});
            this.spdOption.Size = new System.Drawing.Size(725, 418);
            this.spdOption.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOption.TabIndex = 3;
            this.spdOption.TabStop = false;
            this.spdOption.TextTipDelay = 200;
            this.spdOption.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOption.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOption.VerticalScrollBar.Name = "";
            this.spdOption.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdOption.VerticalScrollBar.TabIndex = 23;
            this.spdOption.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOption.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdOption_Change);
            // 
            // spdOption_Sheet1
            // 
            this.spdOption_Sheet1.Reset();
            spdOption_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOption_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOption_Sheet1.ColumnCount = 23;
            spdOption_Sheet1.RowCount = 1;
            spdOption_Sheet1.RowHeader.ColumnCount = 0;
            checkBoxCellType5.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdOption_Sheet1.Cells.Get(0, 0).CellType = checkBoxCellType5;
            this.spdOption_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOption_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Cells.Get(0, 1).RowSpan = 2;
            this.spdOption_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            comboBoxCellType21.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType21.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Cells.Get(0, 12).CellType = comboBoxCellType21;
            this.spdOption_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOption_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOption_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOption_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Function";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Option Name 1";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Option Name 2";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Option Name 3";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Option Name 4";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Option Name 5";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Option Name 6";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Option Name 7";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Option Name 8";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Option Name 9";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Option Name 10";
            this.spdOption_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Enable";
            this.spdOption_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOption_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOption_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType6.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top);
            this.spdOption_Sheet1.Columns.Get(0).CellType = checkBoxCellType6;
            this.spdOption_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdOption_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(0).Width = 35F;
            this.spdOption_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(1).Label = "Function";
            this.spdOption_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(1).Width = 90F;
            this.spdOption_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(2).Label = "Description";
            this.spdOption_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(2).Width = 150F;
            this.spdOption_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(3).Label = "Option Name 1";
            this.spdOption_Sheet1.Columns.Get(3).Locked = true;
            this.spdOption_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(3).Width = 100F;
            comboBoxCellType22.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType22.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(4).CellType = comboBoxCellType22;
            this.spdOption_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(4).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(4).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(5).Label = "Option Name 2";
            this.spdOption_Sheet1.Columns.Get(5).Locked = true;
            this.spdOption_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(5).Width = 100F;
            comboBoxCellType23.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType23.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(6).CellType = comboBoxCellType23;
            this.spdOption_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(6).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(6).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(7).Label = "Option Name 3";
            this.spdOption_Sheet1.Columns.Get(7).Locked = true;
            this.spdOption_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(7).Width = 100F;
            comboBoxCellType24.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType24.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(8).CellType = comboBoxCellType24;
            this.spdOption_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(8).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(8).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(9).Label = "Option Name 4";
            this.spdOption_Sheet1.Columns.Get(9).Locked = true;
            this.spdOption_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(9).Width = 100F;
            comboBoxCellType25.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType25.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(10).CellType = comboBoxCellType25;
            this.spdOption_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(10).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(10).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(11).Label = "Option Name 5";
            this.spdOption_Sheet1.Columns.Get(11).Locked = true;
            this.spdOption_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(11).Width = 100F;
            comboBoxCellType26.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType26.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(12).CellType = comboBoxCellType26;
            this.spdOption_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(12).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(12).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(13).Label = "Option Name 6";
            this.spdOption_Sheet1.Columns.Get(13).Locked = true;
            this.spdOption_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(13).Width = 100F;
            comboBoxCellType27.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType27.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(14).CellType = comboBoxCellType27;
            this.spdOption_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(14).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(14).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(15).Label = "Option Name 7";
            this.spdOption_Sheet1.Columns.Get(15).Locked = true;
            this.spdOption_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(15).Width = 100F;
            comboBoxCellType28.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType28.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(16).CellType = comboBoxCellType28;
            this.spdOption_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(16).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(16).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(17).Label = "Option Name 8";
            this.spdOption_Sheet1.Columns.Get(17).Locked = true;
            this.spdOption_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(17).Width = 100F;
            comboBoxCellType29.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType29.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(18).CellType = comboBoxCellType29;
            this.spdOption_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(18).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(18).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(19).Label = "Option Name 9";
            this.spdOption_Sheet1.Columns.Get(19).Locked = true;
            this.spdOption_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(19).Width = 100F;
            comboBoxCellType30.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType30.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(20).CellType = comboBoxCellType30;
            this.spdOption_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(20).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(20).Width = 45F;
            this.spdOption_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOption_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(21).Label = "Option Name 10";
            this.spdOption_Sheet1.Columns.Get(21).Locked = true;
            this.spdOption_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(21).Width = 102F;
            comboBoxCellType31.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType31.Items = new string[] {
        " ",
        "Yes"};
            this.spdOption_Sheet1.Columns.Get(22).CellType = comboBoxCellType31;
            this.spdOption_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOption_Sheet1.Columns.Get(22).Label = "Enable";
            this.spdOption_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOption_Sheet1.Columns.Get(22).Width = 45F;
            this.spdOption_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOption_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOption_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOption_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOption_Sheet1.Rows.Get(0).Height = 18F;
            this.spdOption_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOption_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOption_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpFields
            // 
            this.tbpFields.Controls.Add(this.spdField);
            this.tbpFields.Location = new System.Drawing.Point(4, 22);
            this.tbpFields.Name = "tbpFields";
            this.tbpFields.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFields.Size = new System.Drawing.Size(731, 424);
            this.tbpFields.TabIndex = 4;
            this.tbpFields.Text = "Fields";
            this.tbpFields.Visible = false;
            // 
            // spdField
            // 
            this.spdField.AccessibleDescription = "";
            this.spdField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdField.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdField.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdField.HorizontalScrollBar.Name = "";
            this.spdField.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdField.HorizontalScrollBar.TabIndex = 4;
            this.spdField.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdField.Location = new System.Drawing.Point(3, 3);
            this.spdField.Name = "spdField";
            this.spdField.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdField.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdField.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdField_Sheet1});
            this.spdField.Size = new System.Drawing.Size(725, 418);
            this.spdField.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdField.TabIndex = 4;
            this.spdField.TabStop = false;
            this.spdField.TextTipDelay = 200;
            this.spdField.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdField.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdField.VerticalScrollBar.Name = "";
            this.spdField.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdField.VerticalScrollBar.TabIndex = 5;
            this.spdField.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdField.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdField_Change);
            this.spdField.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdField_ComboSelChange);
            this.spdField.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdField_EditChange);
            // 
            // spdField_Sheet1
            // 
            this.spdField_Sheet1.Reset();
            spdField_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdField_Sheet1.ColumnCount = 5;
            spdField_Sheet1.ColumnHeader.RowCount = 2;
            spdField_Sheet1.RowCount = 1;
            spdField_Sheet1.RowHeader.ColumnCount = 0;
            checkBoxCellType7.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdField_Sheet1.Cells.Get(0, 0).CellType = checkBoxCellType7;
            this.spdField_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdField_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdField_Sheet1.Cells.Get(0, 1).RowSpan = 2;
            this.spdField_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdField_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdField_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdField_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Function";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Field Enable All";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Field Enable Mask";
            this.spdField_Sheet1.ColumnHeader.Cells.Get(1, 4).Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdField_Sheet1.ColumnHeader.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdField_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "---------1---------2---------3---------4---------5";
            this.spdField_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdField_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdField_Sheet1.ColumnHeader.Rows.Get(0).Height = 17F;
            this.spdField_Sheet1.ColumnHeader.Rows.Get(1).Height = 17F;
            checkBoxCellType8.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top);
            this.spdField_Sheet1.Columns.Get(0).CellType = checkBoxCellType8;
            this.spdField_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(0).Width = 35F;
            this.spdField_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdField_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdField_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(1).Width = 90F;
            this.spdField_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdField_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(2).Width = 150F;
            comboBoxCellType32.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType32.Items = new string[] {
        "",
        "Yes"};
            this.spdField_Sheet1.Columns.Get(3).CellType = comboBoxCellType32;
            this.spdField_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(3).Width = 96F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textCellType1.MaxLength = 50;
            this.spdField_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdField_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdField_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdField_Sheet1.Columns.Get(4).Label = "---------1---------2---------3---------4---------5";
            this.spdField_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdField_Sheet1.Columns.Get(4).Width = 377F;
            this.spdField_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdField_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdField_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdField_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdField_Sheet1.Rows.Get(0).Height = 18F;
            this.spdField_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdField_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(58, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 5;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(26, 6);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 4;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // frmSECSetupGroupFunction
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmSECSetupGroupFunction";
            this.Text = "Assign Function to Security Group";
            this.Activated += new System.EventHandler(this.frmSECSetupGroupFunction_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSECSetupGroupFunction_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSECSetupGroupFunction_FormClosed);
            this.Load += new System.EventHandler(this.frmSECSetupGroupFunction_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpSecGrp.ResumeLayout(false);
            this.grpSecGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPgmID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).EndInit();
            this.pnlGrp.ResumeLayout(false);
            this.tabFunc.ResumeLayout(false);
            this.tbpAttachFunc.ResumeLayout(false);
            this.grpAttachFunc.ResumeLayout(false);
            this.pnlFuncLeft.ResumeLayout(false);
            this.pnlFuncLeftMid.ResumeLayout(false);
            this.pnlFuncLeftTop.ResumeLayout(false);
            this.pnlFuncLeftTop.PerformLayout();
            this.pnlFuncRight.ResumeLayout(false);
            this.pnlFuncRightMid.ResumeLayout(false);
            this.pnlFuncRightTop.ResumeLayout(false);
            this.pnlFuncRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).EndInit();
            this.pnlAttachFuncMid.ResumeLayout(false);
            this.tbpControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdControl_Sheet1)).EndInit();
            this.tbpTabPages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTab_Sheet1)).EndInit();
            this.tbpOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOption_Sheet1)).EndInit();
            this.tbpFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdField_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        private const int CHECK_COL = 0;
        private const int FUNC_COL = 1;
        private const int FUNC_DESC_COL = 2;
        private const int NAME_1_COL = 3;
        private const int VALUE_1_COL = 4;
        private const int NAME_2_COL = 5;
        private const int VALUE_2_COL = 6;
        private const int NAME_3_COL = 7;
        private const int VALUE_3_COL = 8;
        private const int NAME_4_COL = 9;
        private const int VALUE_4_COL = 10;
        private const int NAME_5_COL = 11;
        private const int VALUE_5_COL = 12;
        private const int NAME_6_COL = 13;
        private const int VALUE_6_COL = 14;
        private const int NAME_7_COL = 15;
        private const int VALUE_7_COL = 16;
        private const int NAME_8_COL = 17;
        private const int VALUE_8_COL = 18;
        private const int NAME_9_COL = 19;
        private const int VALUE_9_COL = 20;
        private const int NAME_10_COL = 21;
        private const int VALUE_10_COL = 22;

        private const int FLD_EN_ALL_COL = 3;
        private const int FLD_EN_MASK_COL = 4;

        private const int MAX_FUNC_CNT = 2000;

        #endregion

        #region " Variable Definition "

        private bool LoadFlag;
        //private string sCellValue;
        private TabPage tbp_prev_tab;
        private bool b_change_grp_function_relation;
        private bool b_reload_grp_function_list;
        //Add by J.S. 2009.1.7 for refresh main menu
        private bool b_MESClient_update;

        #endregion

        #region " Function Definition "

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
                if (ProcStep == "1")
                {
                    txtDesc.Text = "";
                    MPCF.ClearList(spdControl);
                    MPCF.ClearList(spdTab);
                    MPCF.ClearList(spdField);
                    MPCF.ClearList(spdOption);
                    tvAttachFunc.Nodes.Clear();

                    MPCF.FitColumnHeader(spdControl);
                    MPCF.FitColumnHeader(spdTab);

                    chkAddToolBar.Checked = false;
                    chkShortCTRL.Checked = false;
                    chkShortALT.Checked = false;
                    chkShortSHIFT.Checked = false;
                    cboShortKey.Text = "";

                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(spdControl);
                    MPCF.ClearList(spdTab);
                    MPCF.ClearList(spdField);
                    MPCF.ClearList(spdOption);
                }
            }
            catch (Exception)
            {
            }
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char ProcStep)
        {
            int i = 0;
            int iChkCnt = 0;

            if (ProcStep == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.CheckValue(cdvSecGrp, 1) == false)
                {
                    return false;
                }

                if (MPCF.CheckValue(cdvPgmID, 1) == false)
                {
                    return false;
                }

                if (tabFunc.SelectedTab == this.tbpAttachFunc)
                {
                    iChkCnt = tvAttachFunc.GetNodeCount(true);
                    if (b_change_grp_function_relation == false)
                        iChkCnt = 0;
                }
                else if (tabFunc.SelectedTab == this.tbpOptions)
                {
                    for (i = 0; i <= spdOption.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdOption.Sheets[0].Cells[i, CHECK_COL].Value != null)
                        {
                            iChkCnt++;
                        }
                    }
                }
                else if (tabFunc.SelectedTab == this.tbpTabPages)
                {
                    for (i = 0; i <= spdTab.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdTab.Sheets[0].Cells[i, CHECK_COL].Value != null)
                        {
                            iChkCnt++;
                        }
                    }
                }
                else if (tabFunc.SelectedTab == this.tbpControls)
                {
                    for (i = 0; i <= spdControl.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdControl.Sheets[0].Cells[i, CHECK_COL].Value != null)
                        {
                            iChkCnt++;
                        }
                    }
                }
                //else if (tabFunc.SelectedTab == this.tbpFields)
                //{
                //    for (i = 0; i <= spdField.Sheets[0].RowCount - 1; i++)
                //    {
                //        if (spdField.Sheets[0].Cells[i, CHECK_COL) != null)
                //        {
                //            iChkCnt++;
                //        }
                //    }
                //}
                
                if (iChkCnt < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(133));
                    spdControl.Select();
                    return false;
                }
                else if (iChkCnt > MAX_FUNC_CNT)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(134));
                    spdControl.Select();
                    return false;
                }

            }

            return true;
        }

        // View_GrpFunc_List()
        //       - View Function List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String                    : ?뺤옣 Process Step
        //

        public bool View_GrpFunc_List(char ProcStep)
        {

            int i;
            int iLastRow = 0;

            string sYesFlag = "";

            TRSNode in_node = new TRSNode("VIEW_GRPFUNC_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_GRPFUNC_LIST_OUT");

            ClearData("2");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("PROGRAM_ID", cdvPgmID.Text);
            in_node.AddString("SEC_GRP_ID", cdvSecGrp.Text);
            in_node.AddString("NEXT_FUNC_NAME", "");

            //MPCF.ClearList(spdControl);
            //MPCF.ClearList(spdTab);
            //MPCF.ClearList(spdOption);
            //MPCF.ClearList(spdField);

            FarPoint.Win.Spread.SheetView with_1 = spdControl.Sheets[0];
            FarPoint.Win.Spread.SheetView with_2 = spdTab.Sheets[0];
            FarPoint.Win.Spread.SheetView with_3 = spdOption.Sheets[0];
            //FarPoint.Win.Spread.SheetView with_4 = spdField.Sheets[0];

            do
            {
                if (MPCR.CallService("SEC", "SEC_View_GrpFunc_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    //FarPoint.Win.Spread.SheetView with_1 = spdControl.Sheets[0];
                    with_1.RowCount++;
                    iLastRow = with_1.RowCount - 1;

                    with_1.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                    with_1.Cells[iLastRow, FUNC_DESC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_DESC"));

                    with_1.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_1"));
                    with_1.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_2"));
                    with_1.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_3"));
                    with_1.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_4"));
                    with_1.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_5"));
                    with_1.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_6"));
                    with_1.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_7"));
                    with_1.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_8"));
                    with_1.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_9"));
                    with_1.Cells[iLastRow, NAME_10_COL].Value =  MPCF.Trim(out_node.GetList(0)[i].GetString("CTL_NAME_10"));

                    with_1.Cells[iLastRow, VALUE_1_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_1")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_2_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_2")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_3_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_3")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_4_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_4")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_5_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_5")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_6_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_6")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_7_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_7")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_8_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_8")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_9_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_9")) == "Y") ? "Yes" : " ");
                    with_1.Cells[iLastRow, VALUE_10_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CTL_EN_FLAG_10")) == "Y") ? "Yes" : " ");


                    // FarPoint.Win.Spread.SheetView with_2 = spdTab.Sheets[0];
                    with_2.RowCount++;
                    iLastRow = with_2.RowCount - 1;

                    with_2.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                    with_2.Cells[iLastRow, FUNC_DESC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_DESC"));

                    with_2.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_1"));
                    with_2.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_2"));
                    with_2.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_3"));
                    with_2.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_4"));
                    with_2.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_5"));
                    with_2.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_6"));
                    with_2.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_7"));
                    with_2.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_8"));
                    with_2.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_9"));
                    with_2.Cells[iLastRow, NAME_10_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_10"));

                    for (int j = 1; j <= 10; j++)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TAB_NAME_" + j.ToString())) != "")
                        {
                            sYesFlag = (MPCF.Trim(out_node.GetList(0)[i].GetChar("TAB_DS_FLAG_" + j.ToString())) == "Y") ? " " : "Yes";
                        }
                        else
                        {
                            sYesFlag = " ";
                        }

                        with_2.Cells[iLastRow, (j * 2) + 2].Value = sYesFlag;
                    }

                    //FarPoint.Win.Spread.SheetView with_3 = spdOption.Sheets[0];
                    with_3.RowCount++;
                    iLastRow = with_3.RowCount - 1;

                    with_3.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                    with_3.Cells[iLastRow, FUNC_DESC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_DESC"));

                    with_3.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_1"));
                    with_3.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_2"));
                    with_3.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_3"));
                    with_3.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_4"));
                    with_3.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_5"));
                    with_3.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_6"));
                    with_3.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_7"));
                    with_3.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_8"));
                    with_3.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_9"));
                    with_3.Cells[iLastRow, NAME_10_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_10"));

                    for (int j = 1; j <= 10; j++)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_NAME_" + j.ToString())) != "")
                        {
                            sYesFlag = (MPCF.Trim(out_node.GetList(0)[i].GetString("OPT_VALUE_" + j.ToString())) == "Y") ? " " : "Yes";
                        }
                        else
                        {
                            sYesFlag = " ";
                        }

                        with_3.Cells[iLastRow, (j * 2) + 2].Value = sYesFlag;
                    }

                    //FarPoint.Win.Spread.SheetView with_4 = spdField.Sheets[0];
                    //with_4.RowCount++;
                    //iLastRow = with_4.RowCount - 1;

                    //with_4.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME"));
                    //with_4.Cells[iLastRow, FUNC_DESC_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_DESC"));

                    //with_4.Cells[iLastRow, FLD_EN_ALL_COL].Value = ((MPCF.Trim(out_node.GetList(0)[i].GetChar("FLD_EN_ALL_FLAG")) == "Y") ? "Yes" : " ");
                    //with_4.Cells[iLastRow, FLD_EN_MASK_COL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FLD_EN_MASK"));
                }

                in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));

            } while (in_node.GetString("NEXT_FUNC_NAME") != "");

            MPCF.FitColumnHeader(spdControl);
            MPCF.FitColumnHeader(spdTab);
            return true;

        }

        //
        // View_Function()
        //       - Add Function To spreadsheet
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep as String : Process Step
        //       - ByVal FuncName As String : Function Name
        //
        private bool Add_Function(string ProcStep, string FuncName)
        {
            int iLastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", FuncName);

                if (MPCR.CallService("SEC", "SEC_VIEW_FUNCTION", in_node, ref out_node) == false)
                {
                    return false;
                }

                FarPoint.Win.Spread.SheetView with_1 = spdControl.Sheets[0];
                with_1.RowCount++;
                iLastRow = with_1.RowCount - 1;

                with_1.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetString("FUNC_NAME"));

                with_1.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_1"));
                with_1.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_2"));
                with_1.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_3"));
                with_1.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_4"));
                with_1.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_5"));
                with_1.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_6"));
                with_1.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_7"));
                with_1.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_8"));
                with_1.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_9"));
                with_1.Cells[iLastRow, NAME_10_COL].Value = MPCF.Trim(out_node.GetString("CTL_NAME_10"));


                FarPoint.Win.Spread.SheetView with_2 = spdTab.Sheets[0];
                with_2.RowCount++;
                iLastRow = with_2.RowCount - 1;

                with_2.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetString("FUNC_NAME"));

                with_2.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_1"));
                with_2.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_2"));
                with_2.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_3"));
                with_2.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_4"));
                with_2.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_5"));
                with_2.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_6"));
                with_2.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_7"));
                with_2.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_8"));
                with_2.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_9"));
                with_2.Cells[iLastRow, NAME_10_COL].Value = MPCF.Trim(out_node.GetString("TAB_NAME_10"));


                FarPoint.Win.Spread.SheetView with_3 = spdOption.Sheets[0];
                with_3.RowCount++;
                iLastRow = with_3.RowCount - 1;

                with_3.Cells[iLastRow, FUNC_COL].Value = MPCF.Trim(out_node.GetString("FUNC_NAME"));

                with_3.Cells[iLastRow, NAME_1_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_1"));
                with_3.Cells[iLastRow, NAME_2_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_2"));
                with_3.Cells[iLastRow, NAME_3_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_3"));
                with_3.Cells[iLastRow, NAME_4_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_4"));
                with_3.Cells[iLastRow, NAME_5_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_5"));
                with_3.Cells[iLastRow, NAME_6_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_6"));
                with_3.Cells[iLastRow, NAME_7_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_7"));
                with_3.Cells[iLastRow, NAME_8_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_8"));
                with_3.Cells[iLastRow, NAME_9_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_9"));
                with_3.Cells[iLastRow, NAME_10_COL].Value = MPCF.Trim(out_node.GetString("OPT_NAME_10"));
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Delete_Function()
        //       - Delete Function From spreadsheet
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool Delete_Function(string FuncName)
        {
            int i;
            int iRow = -1;


            try
            {

                for (i = 0; i <= spdControl.Sheets[0].RowCount - 1; i++)
                {
                    if (MPCF.Trim(spdControl.Sheets[0].Cells[i, FUNC_COL].Value) == FuncName)
                    {
                        iRow = i;
                        break;
                    }
                }

                if (iRow < 0)
                {
                    return false;
                }
                else
                {
                    spdControl.Sheets[0].RemoveRows(iRow, 1);
                    spdTab.Sheets[0].RemoveRows(iRow, 1);
                    spdOption.Sheets[0].RemoveRows(iRow, 1);
                    //spdField.Sheets[0].RemoveRows(iRow, 1);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private void update_GetAttachMenuInfo(TreeNode node, string s_parent_level, ref TRSNode in_node)
        {
            string s_func_name;
            string s_disp_level;
            string s_short_cut;
            char c_separator;
            char c_add_tool_bar;
            int i_seq;

            try
            {
                i_seq = 47;
                c_separator = ' ';
                TRSNode msg_list;

                foreach (TreeNode n in node.Nodes)
                {
                    if (n.Text == "--------------------" || n.Text == "Attach New Menu...") continue;

                    c_separator = ' ';
                    i_seq++;

                    s_func_name = MPCF.SubtractString(n.Text, ":", false, false);
                    s_disp_level = s_parent_level + ((char)i_seq).ToString();

                    if (n.PrevNode != null)
                    {
                        if (n.PrevNode.Text == "--------------------")
                        {
                            c_separator = 'Y';
                        }
                    }

                    c_add_tool_bar = ' ';
                    s_short_cut = "";
                    if (MPCF.Trim(n.Tag).Length > 0)
                    {
                        c_add_tool_bar = MPCF.Trim(n.Tag)[0];
                    }
                    if (MPCF.Trim(n.Tag).Length > 1)
                    {
                        s_short_cut = MPCF.Trim(n.Tag).Substring(1);
                    }

                    msg_list = in_node.AddNode("GRP_FUNC_LIST");

                    msg_list.AddString("FUNC_NAME", s_func_name);
                    msg_list.AddString("DISP_LEVEL", s_disp_level);
                    msg_list.AddChar("SEPARATOR", c_separator);
                    msg_list.AddString("SHORT_CUT", s_short_cut);
                    msg_list.AddChar("ADD_TOOL_BAR", c_add_tool_bar);

                    update_GetAttachMenuInfo(n, s_disp_level + ".", ref in_node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        // update_GrpFunc_List()
        //       - Create/Update/Delete General Code Data List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool update_GrpFunc_List(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_GRPFUNC_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode msg_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("PROGRAM_ID", cdvPgmID.Text);
                in_node.AddString("SEC_GRP_ID", cdvSecGrp.Text);

                if (tabFunc.SelectedTab == this.tbpAttachFunc)
                {
                    in_node.ProcStep = MPGC.MP_STEP_CREATE;
                    in_node.SetChar("OPT", 'A');

                    //msg_list = in_node.AddNode("GRP_FUNC_LIST");

                    update_GetAttachMenuInfo(tvAttachFunc.Nodes[0], "", ref in_node);
                }
                else if (tabFunc.SelectedTab == this.tbpControls)
                {
                    in_node.SetChar("OPT", 'C');



                    for (i = 0; i <= spdControl.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdControl.Sheets[0].Cells[i, 0].Value != null &&
                            Convert.ToBoolean(spdControl.Sheets[0].Cells[i, 0].Value) == true)
                        {
                            msg_list = in_node.AddNode("GRP_FUNC_LIST");

                            msg_list.AddString("FUNC_NAME", MPCF.Trim(spdControl.Sheets[0].Cells[i, FUNC_COL].Value));
                            msg_list.AddChar("CTL_EN_FLAG_1", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_1_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_2", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_2_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_3", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_3_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_4", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_4_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_5", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_5_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_6", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_6_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_7", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_7_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_8", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_8_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_9", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_9_COL].Value) == "Yes") ? 'Y' : ' ');
                            msg_list.AddChar("CTL_EN_FLAG_10", (MPCF.Trim(spdControl.Sheets[0].Cells[i, VALUE_10_COL].Value) == "Yes") ? 'Y' : ' ');
                            //iIndex++;
                        }
                    }
                }
                else if (tabFunc.SelectedTab == this.tbpTabPages)
                {
                    in_node.SetChar("OPT", 'T');



                    for (i = 0; i <= spdTab.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdTab.Sheets[0].Cells[i, 0].Value != null &&
                            Convert.ToBoolean(spdTab.Sheets[0].Cells[i, 0].Value) == true)
                        {
                            msg_list = in_node.AddNode("GRP_FUNC_LIST");

                            msg_list.AddString("FUNC_NAME", MPCF.Trim(spdTab.Sheets[0].Cells[i, FUNC_COL].Value));
                            msg_list.AddChar("TAB_DS_FLAG_1", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_1_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_2", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_2_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_3", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_3_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_4", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_4_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_5", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_5_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_6", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_6_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_7", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_7_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_8", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_8_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_9", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_9_COL].Value) == "Yes") ? ' ' : 'Y');
                            msg_list.AddChar("TAB_DS_FLAG_10", (MPCF.Trim(spdTab.Sheets[0].Cells[i, VALUE_10_COL].Value) == "Yes") ? ' ' : 'Y');
                        }
                    }
                }
                else if (tabFunc.SelectedTab == this.tbpOptions)
                {
                    in_node.SetChar("OPT", 'O');


                    for (i = 0; i <= spdOption.Sheets[0].RowCount - 1; i++)
                    {
                        if (spdOption.Sheets[0].Cells[i, 0].Value != null &&
                            Convert.ToBoolean(spdOption.Sheets[0].Cells[i, 0].Value) == true)
                        {
                            msg_list = in_node.AddNode("GRP_FUNC_LIST");

                            msg_list.AddString("FUNC_NAME", MPCF.Trim(spdOption.Sheets[0].Cells[i, FUNC_COL].Value));
                            msg_list.AddString("OPT_VALUE_1", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_1_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_2", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_2_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_3", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_3_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_4", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_4_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_5", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_5_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_6", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_6_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_7", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_7_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_8", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_8_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_9", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_9_COL].Value) == "Yes") ? " " : "Y");
                            msg_list.AddString("OPT_VALUE_10", (MPCF.Trim(spdOption.Sheets[0].Cells[i, VALUE_10_COL].Value) == "Yes") ? " " : "Y");
                        }
                    }
                }
                //else if (tabFunc.SelectedTab == this.tbpFields)
                //{
                //    in_node.SetChar("OPT", 'F');



                //    for (i = 0; i <= spdField.Sheets[0].RowCount - 1; i++)
                //    {
                //        if (spdField.Sheets[0].Cells[i, 0) != null &&
                //            Convert.ToBoolean(spdField.Sheets[0].Cells[i, 0)) == true)
                //        {
                //            msg_list = in_node.AddNode("GRP_FUNC_LIST");

                //            msg_list.AddString("FUNC_NAME", MPCF.Trim(spdField.Sheets[0].Cells[i, FUNC_COL)));
                //            msg_list.AddChar("FLD_EN_ALL_FLAG", (MPCF.Trim(spdField.Sheets[0].Cells[i, FLD_EN_ALL_COL)) == "Yes") ? 'Y' : ' ');
                //            msg_list.AddString("FLD_EN_MASK", MPCF.Trim(spdField.Sheets[0].Cells[i, FLD_EN_MASK_COL)));
                //        }
                //    }

                //}

                if (MPCR.CallService("SEC", "SEC_Update_GrpFunc_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                View_GrpFunc_List('1');

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvSecGrp;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private void NodeSearch(TreeNode PNode)
        {
            try
            {
                int i_source_index;
                string s_func_id;

                foreach (TreeNode node in PNode.Nodes)
                {
                    if (node != null)
                    {
                        if (node.Text.IndexOf(':') > -1) // Attach New Menu... 제외 
                        {
                            s_func_id = node.Text.Substring(0, node.Text.IndexOf(':'));
                            i_source_index = MPCF.FindListItemIndex(lisAvailFunc, s_func_id, false);
                            if (i_source_index >= 0)
                            {
                                lisAvailFunc.Items[i_source_index].ForeColor = Color.Blue;
                            }

                            if (node.GetNodeCount(true) > 0)
                            {
                                NodeSearch(node);
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
           
        }

        private void DetachFunction(TreeNode node)
        {
            string s_func_id;
            int i_source_index;

            try
            {
                if (node.Text == "Attach New Menu...") 
                {
                    return;
                }
                else if (node.Text == "--------------------")
                {
                    node.Remove();
                    return;
                }

                if (node.Parent != null)
                {
                    s_func_id = node.Text.Substring(0, node.Text.IndexOf(':'));

                    i_source_index = MPCF.FindListItemIndex(lisAvailFunc, s_func_id, false);
                    if (i_source_index >= 0)
                    {
                        lisAvailFunc.Items[i_source_index].ForeColor = SystemColors.WindowText;
                    }

                    while (node.Nodes.Count > 1)
                    {
                        DetachFunction(node.Nodes[0]);
                    }
                    node.Remove();
                }

                b_change_grp_function_relation = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        private void frmSECSetupGroupFunction_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    grpAttachFunc_Resize(null, null);

                    if (SECLIST.ViewFunctionList(lisAvailFunc, "", "", cdvFGroup.Text) == false)
                    {
                        return;
                    }

                    tbp_prev_tab = tbpAttachFunc;
                    b_change_grp_function_relation = false;
                    b_reload_grp_function_list = true;
                    //Add by J.S. 2009.1.7 for refresh main menu
                    b_MESClient_update = false;

                    cdvPgmID.Text = MPGV.gsProgramID;

                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmSECSetupGroupFunction_Load(object sender, System.EventArgs e)
        {
            try
            {
                //Add by ICBAE 2012.06.08 - Field Mask 기능 삭제
                tabFunc.TabPages.Remove(tbpFields);
                MPCF.InitListView(lisAvailFunc);
                MPCF.InitTreeView(tvAttachFunc);

                lisAvailFunc.MultiSelect = true;

                ClearData("1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmSECSetupGroupFunction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b_change_grp_function_relation == true)
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(250), MessageBoxButtons.YesNo, 0) == DialogResult.Yes)
                {
                    tabFunc.SelectedTab = tbpAttachFunc;
                    btnUpdate.Focus();

                    e.Cancel = true;
                }
            }
        }

        private void frmSECSetupGroupFunction_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Add by J.S. 2009.01.07 for mrefresh main menu
            if (b_MESClient_update == true)
            {
                MPGV.gIMdiForm.MenuRefresh();
            }
        }


        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_attach_index;
            TreeNode node;
            string s_select_func;

            if (tvAttachFunc.SelectedNode == null) return;
            if (tvAttachFunc.SelectedNode.Parent == null) return;

            try
            {
                for (i = 0; i < lisAvailFunc.SelectedItems.Count; i++)
                {
                    s_select_func = MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[0].Text) + " : " + MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[1].Text);

                    if (MPCF.FindTreeNode(tvAttachFunc, s_select_func, "") == null)
                    {
                        i_attach_index = tvAttachFunc.SelectedNode.Index;

                        node = new TreeNode(s_select_func, (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);
                        node.Tag = MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[0].Tag);
                        tvAttachFunc.SelectedNode.Parent.Nodes.Insert(i_attach_index, node);

                        b_change_grp_function_relation = true;

                        lisAvailFunc.SelectedItems[i].SubItems[0].ForeColor = Color.Blue;
                        lisAvailFunc.SelectedItems[i].SubItems[1].ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            TreeNode node;

            if (tvAttachFunc.SelectedNode == null) return;

            try
            {
                for (i = 0; i < tvAttachFunc.SelectedNodes.Count; i++)
                {
                    node = (TreeNode)tvAttachFunc.SelectedNodes[i];
                    DetachFunction(node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            int i;
            int i_add_function;
            TreeNode node;
            string s_select_func;
            bool b_insert_item;

            if (tvAttachFunc.SelectedNode == null) return;

            try
            {
                if (tvAttachFunc.SelectedNode.Text == "--------------------" ||
                    tvAttachFunc.SelectedNode.Text == "Attach New Menu...") return;

                i_add_function = 0;
                b_insert_item = false;

                if (tvAttachFunc.SelectedNode.Nodes.Count > 1)
                {
                    b_insert_item = true;
                }

                for (i = 0; i < lisAvailFunc.SelectedItems.Count; i++)
                {
                    s_select_func = MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[0].Text) + " : " + MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[1].Text);

                    if (MPCF.FindTreeNode(tvAttachFunc, s_select_func, "") == null)
                    {
                        node = new TreeNode(s_select_func, (int)SMALLICON_INDEX.IDX_FUNCTION, (int)SMALLICON_INDEX.IDX_FUNCTION);
                        node.Tag = MPCF.Trim(lisAvailFunc.SelectedItems[i].SubItems[0].Tag);

                        if (b_insert_item == true)
                        {
                            tvAttachFunc.SelectedNode.Nodes.Insert(tvAttachFunc.SelectedNode.Nodes.Count - 1, node);
                        }
                        else
                        {
                            tvAttachFunc.SelectedNode.Nodes.Add(node);
                        }

                        i_add_function++;

                        lisAvailFunc.SelectedItems[i].SubItems[0].ForeColor = Color.Blue;
                        lisAvailFunc.SelectedItems[i].SubItems[1].ForeColor = Color.Blue;
                    }
                }

                if (i_add_function > 0 && b_insert_item == false)
                {
                    node = new TreeNode("Attach New Menu...", (int)SMALLICON_INDEX.IDX_VERSION_REQUEST, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
                    node.ForeColor = Color.Silver;
                    tvAttachFunc.SelectedNode.Nodes.Add(node);
                    tvAttachFunc.SelectedNode.Expand();
                }

                if (i_add_function > 0)
                    b_change_grp_function_relation = true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnSeparator_Click(object sender, EventArgs e)
        {
            int i_attach_index;
            TreeNode node;

            if (tvAttachFunc.SelectedNode == null) return;

            try
            {
                if (tvAttachFunc.SelectedNode == null) return;
                if (tvAttachFunc.SelectedNode.PrevNode == null) return;

                i_attach_index = tvAttachFunc.SelectedNode.Index;

                node = new TreeNode("--------------------", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                node.ForeColor = Color.Silver;
                tvAttachFunc.SelectedNode.Parent.Nodes.Insert(i_attach_index, node);

                b_change_grp_function_relation = true;
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
                int ActiveColumn = 0;
                int ActiveRow = 0;
                bool b_ret;

                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;


                if (tabFunc.SelectedTab == this.tbpOptions)
                {
                    ActiveColumn = spdOption.Sheets[0].ActiveColumnIndex;
                    ActiveRow = spdOption.Sheets[0].ActiveRowIndex;
                }
                else if (tabFunc.SelectedTab == this.tbpTabPages)
                {
                    ActiveColumn = spdTab.Sheets[0].ActiveColumnIndex;
                    ActiveRow = spdTab.Sheets[0].ActiveRowIndex;
                }
                else if (tabFunc.SelectedTab == this.tbpControls)
                {
                    ActiveColumn = spdControl.Sheets[0].ActiveColumnIndex;
                    ActiveRow = spdControl.Sheets[0].ActiveRowIndex;
                }
                //else if (tabFunc.SelectedTab == this.tbpFields)
                //{
                //    ActiveColumn = spdField.Sheets[0].ActiveColumnIndex;
                //    ActiveRow = spdField.Sheets[0].ActiveRowIndex;
                //}


                b_ret = update_GrpFunc_List(MPGC.MP_STEP_UPDATE);



                if (tabFunc.SelectedTab == this.tbpOptions)
                {
                    spdOption.Sheets[0].ActiveColumnIndex = 0;
                    spdOption.Sheets[0].ActiveRowIndex = ActiveRow;

                    //Modify by J.S. 2012.02.14 refresh후 이전 편집위치로 이동
                    spdOption.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                }
                else if (tabFunc.SelectedTab == this.tbpTabPages)
                {
                    spdTab.Sheets[0].ActiveColumnIndex = 0;
                    spdTab.Sheets[0].ActiveRowIndex = ActiveRow;

                    //Modify by J.S. 2012.02.14 refresh후 이전 편집위치로 이동
                    spdTab.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                }
                else if (tabFunc.SelectedTab == this.tbpControls)
                {
                    spdControl.Sheets[0].ActiveColumnIndex = 0;
                    spdControl.Sheets[0].ActiveRowIndex = ActiveRow;

                    //Modify by J.S. 2012.02.14 refresh후 이전 편집위치로 이동
                    spdControl.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                }
                //else if (tabFunc.SelectedTab == this.tbpFields)
                //{
                //    spdField.Sheets[0].ActiveColumnIndex = 0;
                //    spdField.Sheets[0].ActiveRowIndex = ActiveRow;

                //    //Modify by J.S. 2012.02.14 refresh후 이전 편집위치로 이동
                //    spdField.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                //}

                if (b_ret == true)
                {
                    if (tabFunc.SelectedTab == this.tbpAttachFunc)
                    {
                        b_change_grp_function_relation = false;
                        b_reload_grp_function_list = true;
                    }

                    //Add by J.S. 2009.1.7 for refresh main menu
                    if (MPCF.RTrim(cdvPgmID.Text) == "MESClient" && MPCF.Trim(cdvSecGrp.Text) == MPGV.gsUserGroup)
                    {
                        b_MESClient_update = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvSecGrp_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData("1");
            if (cdvSecGrp.Text != "")
            {
                txtDesc.Text = cdvSecGrp.SelectedItem.SubItems[1].Text;
                b_change_grp_function_relation = false;
                b_reload_grp_function_list = true;
                MPCF.InitTreeView(tvAttachFunc);
                SECLIST.ViewFunctionList(tvAttachFunc, cdvPgmID.Text, cdvSecGrp.Text, null, true);

                foreach (TreeNode node in tvAttachFunc.Nodes)
                {
                    if (node != null)
                    {
                        NodeSearch(node);
                    }
                }
                //MPCF.ShowMsgBox(tvAttachFunc.Nodes[0].Nodes.Count.ToString());
                //for (i = 0; i < lisTemp.SelectedItems.Count; i++)
                //{
                //    s_rcvr_id = lisTemp.SelectedItems[i].Text;
                //    if (MPCF.FindListItemIndex(lisRecvList, s_rcvr_id, false) < 0)
                //    {
                //        itmX = new ListViewItem(s_rcvr_id, i_icon_index);
                //        itmX.SubItems.Add(s_recv_type);
                //        itmX.SubItems.Add(s_recv_shift);
                //        lisRecvList.Items.Add(itmX);

                //        lisTemp.SelectedItems[i].ForeColor = Color.Blue;
                //    }
                //}
            }
        }

        private void cdvSecGrp_ButtonPress(object sender, System.EventArgs e)
        {
            cdvSecGrp.Init();
            MPCF.InitListView(cdvSecGrp.GetListView);
            cdvSecGrp.Columns.Add("Security Group", 100, HorizontalAlignment.Left);
            cdvSecGrp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvSecGrp.SelectedSubItemIndex = 0;
            SECLIST.ViewSecGroupList(cdvSecGrp.GetListView, '1', null, "");
        }

        private void spdControl_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdControl.Sheets[0].Cells[e.Row, 0].Value = true;
            }
        }

        private void spdTab_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdTab.Sheets[0].Cells[e.Row, 0].Value = true;
            }
        }

        private void spdField_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //if (e.Column > 0 && e.Row >= 0)
            //{
            //    spdField.Sheets[0].Cells[e.Row, 0].Value = true;
            //}
        }

        private void spdOption_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column > 0 && e.Row >= 0)
            {
                spdOption.Sheets[0].Cells[e.Row, 0].Value = true;
            }
        }

        private void spdField_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            //string sValue;
            //int i = 0;

            //if (e.Column > 0 && e.Row >= 0)
            //{
            //    spdField.Sheets[0].Cells[e.Row, 0].Value = true;
            //}

            //try
            //{
            //    if (e.Column != FLD_EN_MASK_COL)
            //    {
            //        return;
            //    }
            //    if (e.Row < 0)
            //    {
            //        return;
            //    }

            //    sValue = MPCF.Trim(spdField.Sheets[0].Cells[e.Row, e.Column].Value);

            //    if (sValue == null)
            //    {
            //        return;
            //    }

            //    for (i = 0; i <= sValue.Length - 1; i++)
            //    {
            //        if (sValue[i] != 'Y' && sValue[i] != 'N' && sValue[i] != ' ')
            //        {
            //            MPCF.ShowMsgBox(MPCF.GetMessage(138));
            //            if (sCellValue == null)
            //            {
            //                spdField.Sheets[0].Cells[e.Row, e.Column].Value = "";
            //            }
            //            else
            //            {
            //                spdField.Sheets[0].Cells[e.Row, e.Column].Value = sCellValue;
            //            }
            //            break;
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //}
        }

        private void spdField_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //try
            //{
            //    if (e.Column != FLD_EN_MASK_COL)
            //    {
            //        return;
            //    }
            //    if (e.Row < 0)
            //    {
            //        return;
            //    }

            //    sCellValue = MPCF.Trim(spdField.Sheets[0].Cells[e.Row, e.Column].Value);

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //}
        }

        private void cdvSecGrp_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void grpAttachFunc_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(grpAttachFunc, pnlFuncLeft, pnlFuncRight, pnlAttachFuncMid, 40);
        }

        private void cdvFGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvFGroup.Init();
            MPCF.InitListView(cdvFGroup.GetListView);
            cdvFGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvFGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFGroup.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvFGroup.GetListView, '1', MPGC.MP_SEC_FUNCTION_GROUP);
            cdvFGroup.InsertEmptyRow(0, 1);
        }

        private void cdvFGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;
            SECLIST.ViewFunctionList(lisAvailFunc, "", "", cdvFGroup.Text);

            foreach (TreeNode node in tvAttachFunc.Nodes)
            {
                if (node != null)
                {
                    NodeSearch(node);
                }
            }
        }

        private void tabFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbp_prev_tab == tbpAttachFunc &&
                (tabFunc.SelectedTab == tbpControls ||
                 /*tabFunc.SelectedTab == tbpFields ||*/
                 tabFunc.SelectedTab == tbpOptions ||
                 tabFunc.SelectedTab == tbpTabPages))
            {
                if (b_change_grp_function_relation == true)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(250), MessageBoxButtons.YesNo, 0) == DialogResult.Yes)
                    {
                        tabFunc.SelectedTab = tbpAttachFunc;
                        btnUpdate.Focus();
                        return;
                    }

                    cdvSecGrp_SelectedItemChanged(null, null);
                }

                if (b_reload_grp_function_list == true)
                {
                    if (View_GrpFunc_List('1') == true)
                    {
                        b_reload_grp_function_list = false;
                    }
                }
            }

            tbp_prev_tab = tabFunc.SelectedTab;
        }

        private void tvAttachFunc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            chkAddToolBar.Checked = false;
            chkShortCTRL.Checked = false;
            chkShortALT.Checked = false;
            chkShortSHIFT.Checked = false;
            cboShortKey.Text = "";

            if (e.Node.Tag == null) return;

            if (MPCF.Trim(e.Node.Tag).Length > 0)
            {
                chkAddToolBar.Checked = MPCF.Trim(e.Node.Tag)[0] == 'Y' ? true : false;

                if (MPCF.Trim(e.Node.Tag).Length > 1)
                {
                    chkShortCTRL.Checked = MPCF.Trim(e.Node.Tag)[1] == 'C' ? true : false;
                    chkShortALT.Checked = MPCF.Trim(e.Node.Tag)[2] == 'A' ? true : false;
                    chkShortSHIFT.Checked = MPCF.Trim(e.Node.Tag)[3] == 'S' ? true : false;
                    cboShortKey.Text = MPCF.Trim(e.Node.Tag).Substring(4);
                }
            }
        }

        private void btnShortApply_Click(object sender, EventArgs e)
        {
            if (tvAttachFunc.SelectedNode == null) return;
            if (tvAttachFunc.SelectedNode.Nodes.Count > 0) return;

            if (chkShortCTRL.Checked == true || chkShortALT.Checked == true || chkShortSHIFT.Checked == true)
            {
                if (MPCF.CheckValue(cboShortKey, 1) == false) return;
            }

            // F1 ~ F12 은 단독으로 선택 가능하지만 그외의 문자는 CTRL, ALT, SHIFT 조합이어야 한다.
            if (cboShortKey.SelectedIndex > 11)
            {
                if (chkShortCTRL.Checked == false && chkShortALT.Checked == false && chkShortSHIFT.Checked == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    chkShortCTRL.Focus();
                    return;
                }
            }

            string s_tmp;

            s_tmp = chkAddToolBar.Checked == true ? "Y" : "N";

            if (MPCF.Trim(cboShortKey.Text) != "")
            {
                s_tmp += chkShortCTRL.Checked == true ? "C" : "-";
                s_tmp += chkShortALT.Checked == true ? "A" : "-";
                s_tmp += chkShortSHIFT.Checked == true ? "S" : "-";
                s_tmp += cboShortKey.Text;
            }

            tvAttachFunc.SelectedNode.Tag = s_tmp;

            b_change_grp_function_relation = true;
        }

        private void cdvPgmID_ButtonPress(object sender, EventArgs e)
        {
            cdvPgmID.Init();
            MPCF.InitListView(cdvPgmID.GetListView);
            cdvPgmID.Columns.Add("Program ID", 50, HorizontalAlignment.Left);
            cdvPgmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPgmID.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPgmID.GetListView, '1', MPGC.MP_SEC_PROGRAM_LIST);
        }

        private void cdvPgmID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.CheckValue(cdvSecGrp, 1) == false) return;

            b_change_grp_function_relation = false;
            b_reload_grp_function_list = true;
            MPCF.InitTreeView(tvAttachFunc);
            SECLIST.ViewFunctionList(tvAttachFunc, cdvPgmID.Text, cdvSecGrp.Text, null, true);
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAttachFunc.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.Collapse(false);
                }
            }

            if (tvAttachFunc.Nodes.Count > 0)
            {
                tvAttachFunc.Nodes[0].Expand();
                tvAttachFunc.Nodes[0].EnsureVisible();
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAttachFunc.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.ExpandAll();
                }
            }

            if (tvAttachFunc.Nodes.Count > 0)
            {
                tvAttachFunc.Nodes[0].EnsureVisible();
            }
        }

        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_prev_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAttachFunc.SelectedNodes.Count < 1) return;

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAttachFunc.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(true));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);
                    if (tn_curr.Text == "Attach New Menu...") continue;

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.FirstNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.PrevNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_prev_index = tn_curr.PrevNode.Index;
                            tn_parent.Nodes.Insert(i_prev_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAttachFunc.SelectedNode = null;
                    tvAttachFunc.SelectedNodes = al_new_selected_nodes;

                    b_change_grp_function_relation = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAttachFunc.SelectedNodes.Count < 1) return;

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAttachFunc.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(false));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);
                    if (tn_curr.Text == "Attach New Menu...") continue;

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.LastNode.PrevNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.NextNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_next_index = tn_curr.NextNode.Index + 1;
                            tn_parent.Nodes.Insert(i_next_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAttachFunc.SelectedNode = null;
                    tvAttachFunc.SelectedNodes = al_new_selected_nodes;

                    b_change_grp_function_relation = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }


    public class TreeNodeComparer : IComparer
    {
        private bool is_ascending;

        public TreeNodeComparer(bool isAscending)
        {
            is_ascending = isAscending;
        }

        public int Compare(object x, object y)
        {
            string sTextX;
            string sTextY;
            int i_result;

            try
            {
                sTextX = ((TreeNode)x).Level.ToString("00000") + ((TreeNode)x).Index.ToString("00000");
                sTextY = ((TreeNode)y).Level.ToString("00000") + ((TreeNode)y).Index.ToString("00000");

                i_result = sTextX.CompareTo(sTextY);
                return (is_ascending ? i_result : i_result * -1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Compare Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }


}