
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Globalization;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;


namespace Miracom.RASCore
{
    public class frmRASTranSubEvent : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranSubEvent()
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
        



        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.GroupBox grpEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tabResource;
        private System.Windows.Forms.TabPage tbpResStatus;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtProcMode;
        private System.Windows.Forms.TextBox txtResourceType;
        private System.Windows.Forms.Label lblProcMode;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.TextBox txtLastEvent;
        private System.Windows.Forms.Label lblLastEvent;
        private System.Windows.Forms.TextBox txtLastEventTime;
        private System.Windows.Forms.Label lblLastEventTime;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResID;
        private System.Windows.Forms.Label lblSubResource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResource;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.GroupBox grpCurrentStatus;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrimaryChange;
        private System.Windows.Forms.TextBox txtChangeUpDown;
        private System.Windows.Forms.TextBox txtPrimaryCurrent;
        private System.Windows.Forms.TextBox txtCurrentStatus10;
        private System.Windows.Forms.TextBox txtCurrentStatus9;
        private System.Windows.Forms.TextBox txtCurrentStatus8;
        private System.Windows.Forms.TextBox txtCurrentStatus7;
        private System.Windows.Forms.TextBox txtCurrentStatus6;
        private System.Windows.Forms.TextBox txtCurrentStatus5;
        private System.Windows.Forms.TextBox txtCurrentStatus4;
        private System.Windows.Forms.TextBox txtCurrentStatus3;
        private System.Windows.Forms.TextBox txtCurrentStatus2;
        private System.Windows.Forms.TextBox txtCurrentStatus1;
        private System.Windows.Forms.TextBox txtCurrentUpDown;
        private System.Windows.Forms.Label lblPrimaryStatus;
        private System.Windows.Forms.Label lblCurrentStatus10;
        private System.Windows.Forms.Label lblCurrentStatus9;
        private System.Windows.Forms.Label lblCurrentStatus8;
        private System.Windows.Forms.Label lblCurrentStatus7;
        private System.Windows.Forms.Label lblCurrentStatus6;
        private System.Windows.Forms.Label lblCurrentStatus5;
        private System.Windows.Forms.Label lblCurrentStatus4;
        private System.Windows.Forms.Label lblCurrentStatus3;
        private System.Windows.Forms.Label lblCurrentStatus2;
        private System.Windows.Forms.Label lblCurrentStatus1;
        private TabPage tbpCMF;
        protected GroupBox grpCMF;
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
        private TabPage tbpCollectData;
        private Panel pnlCol;
        private GroupBox grpCol;
        private TextBox txtColSet;
        private TextBox txtColSetVersion;
        private Label lblColSetVersion;
        private Label lblColSet;
        private Panel pnlResData;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Label lblUpDown;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlRes = new System.Windows.Forms.Panel();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResource = new System.Windows.Forms.Label();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.txtLastEventTime = new System.Windows.Forms.TextBox();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.txtLastEvent = new System.Windows.Forms.TextBox();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.cdvSubResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblSubResource = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpResStatus = new System.Windows.Forms.TabPage();
            this.grpCurrentStatus = new System.Windows.Forms.GroupBox();
            this.cdvChangeStatus10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPrimaryChange = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtChangeUpDown = new System.Windows.Forms.TextBox();
            this.txtPrimaryCurrent = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus10 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus9 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus8 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus7 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus6 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus5 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus4 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus3 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus2 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus1 = new System.Windows.Forms.TextBox();
            this.txtCurrentUpDown = new System.Windows.Forms.TextBox();
            this.lblPrimaryStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus10 = new System.Windows.Forms.Label();
            this.lblCurrentStatus9 = new System.Windows.Forms.Label();
            this.lblCurrentStatus8 = new System.Windows.Forms.Label();
            this.lblCurrentStatus7 = new System.Windows.Forms.Label();
            this.lblCurrentStatus6 = new System.Windows.Forms.Label();
            this.lblCurrentStatus5 = new System.Windows.Forms.Label();
            this.lblCurrentStatus4 = new System.Windows.Forms.Label();
            this.lblCurrentStatus3 = new System.Windows.Forms.Label();
            this.lblCurrentStatus2 = new System.Windows.Forms.Label();
            this.lblCurrentStatus1 = new System.Windows.Forms.Label();
            this.lblUpDown = new System.Windows.Forms.Label();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtProcMode = new System.Windows.Forms.TextBox();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.lblProcMode = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblResType = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
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
            this.tbpCollectData = new System.Windows.Forms.TabPage();
            this.pnlResData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlCol = new System.Windows.Forms.Panel();
            this.grpCol = new System.Windows.Forms.GroupBox();
            this.txtColSet = new System.Windows.Forms.TextBox();
            this.txtColSetVersion = new System.Windows.Forms.TextBox();
            this.lblColSetVersion = new System.Windows.Forms.Label();
            this.lblColSet = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.grpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            this.grpResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tabResource.SuspendLayout();
            this.tbpResStatus.SuspendLayout();
            this.grpCurrentStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).BeginInit();
            this.grpComment.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
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
            this.tbpCollectData.SuspendLayout();
            this.pnlResData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlCol.SuspendLayout();
            this.grpCol.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMain);
            this.pnlCenter.Controls.Add(this.pnlRes);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Event";
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
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.grpEvent);
            this.pnlRes.Controls.Add(this.grpResource);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRes.Location = new System.Drawing.Point(0, 0);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRes.Size = new System.Drawing.Size(742, 140);
            this.pnlRes.TabIndex = 0;
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.cdvEventID);
            this.grpEvent.Controls.Add(this.lblEventID);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(3, 95);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(736, 45);
            this.grpEvent.TabIndex = 1;
            this.grpEvent.TabStop = false;
            // 
            // cdvEventID
            // 
            this.cdvEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = 0;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 12);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(604, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 1;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = true;
            this.cdvEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEventID_SelectedItemChanged);
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            this.cdvEventID.TextBoxTextChanged += new System.EventHandler(this.cdvEventID_TextBoxTextChanged);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(15, 17);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(57, 13);
            this.lblEventID.TabIndex = 0;
            this.lblEventID.Text = "Event ID";
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.cdvResID);
            this.grpResource.Controls.Add(this.lblResource);
            this.grpResource.Controls.Add(this.pnlTranTime);
            this.grpResource.Controls.Add(this.txtLastEventTime);
            this.grpResource.Controls.Add(this.lblLastEventTime);
            this.grpResource.Controls.Add(this.txtLastEvent);
            this.grpResource.Controls.Add(this.lblLastEvent);
            this.grpResource.Controls.Add(this.cdvSubResID);
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.lblSubResource);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(736, 95);
            this.grpResource.TabIndex = 0;
            this.grpResource.TabStop = false;
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
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
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
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(16, 20);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(78, 13);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "Resource ID";
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(428, 12);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 6;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 1);
            this.txtTranDateTime.Name = "txtTranDateTime";
            this.txtTranDateTime.ReadOnly = true;
            this.txtTranDateTime.Size = new System.Drawing.Size(157, 20);
            this.txtTranDateTime.TabIndex = 12;
            this.txtTranDateTime.TabStop = false;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranTime.Checked = false;
            this.dtpTranTime.CustomFormat = "HH:mm:ss";
            this.dtpTranTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranTime.Location = new System.Drawing.Point(225, 1);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTranTime.TabIndex = 11;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            this.chkTranDateTime.TabIndex = 10;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(139, 1);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 9;
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Location = new System.Drawing.Point(567, 66);
            this.txtLastEventTime.MaxLength = 30;
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(157, 20);
            this.txtLastEventTime.TabIndex = 10;
            this.txtLastEventTime.TabStop = false;
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.AutoSize = true;
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.Location = new System.Drawing.Point(432, 68);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(84, 13);
            this.lblLastEventTime.TabIndex = 9;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(566, 40);
            this.txtLastEvent.MaxLength = 12;
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(158, 20);
            this.txtLastEvent.TabIndex = 8;
            this.txtLastEvent.TabStop = false;
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Location = new System.Drawing.Point(432, 44);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 7;
            this.lblLastEvent.Text = "Last Event";
            // 
            // cdvSubResID
            // 
            this.cdvSubResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResID.BtnToolTipText = "";
            this.cdvSubResID.DescText = "";
            this.cdvSubResID.DisplaySubItemIndex = -1;
            this.cdvSubResID.DisplayText = "";
            this.cdvSubResID.Focusing = null;
            this.cdvSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResID.Index = 0;
            this.cdvSubResID.IsViewBtnImage = false;
            this.cdvSubResID.Location = new System.Drawing.Point(120, 42);
            this.cdvSubResID.MaxLength = 20;
            this.cdvSubResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.Name = "cdvSubResID";
            this.cdvSubResID.ReadOnly = false;
            this.cdvSubResID.SearchSubItemIndex = 0;
            this.cdvSubResID.SelectedDescIndex = -1;
            this.cdvSubResID.SelectedSubItemIndex = -1;
            this.cdvSubResID.SelectionStart = 0;
            this.cdvSubResID.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResID.SmallImageList = null;
            this.cdvSubResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResID.TabIndex = 3;
            this.cdvSubResID.TextBoxToolTipText = "";
            this.cdvSubResID.TextBoxWidth = 200;
            this.cdvSubResID.VisibleButton = true;
            this.cdvSubResID.VisibleColumnHeader = false;
            this.cdvSubResID.VisibleDescription = false;
            this.cdvSubResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubResID_SelectedItemChanged);
            this.cdvSubResID.ButtonPress += new System.EventHandler(this.cdvSubResID_ButtonPress);
            this.cdvSubResID.TextBoxTextChanged += new System.EventHandler(this.cdvSubResID_TextBoxTextChanged);
            this.cdvSubResID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvSubResID_KeyPress);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(14, 70);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblSubResource
            // 
            this.lblSubResource.AutoSize = true;
            this.lblSubResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResource.Location = new System.Drawing.Point(15, 44);
            this.lblSubResource.Name = "lblSubResource";
            this.lblSubResource.Size = new System.Drawing.Size(89, 13);
            this.lblSubResource.TabIndex = 2;
            this.lblSubResource.Text = "Sub Resource ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 68);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(198, 20);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabResource);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 140);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlMain.Size = new System.Drawing.Size(742, 366);
            this.pnlMain.TabIndex = 1;
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.tbpResStatus);
            this.tabResource.Controls.Add(this.tbpGeneral);
            this.tabResource.Controls.Add(this.tbpCMF);
            this.tabResource.Controls.Add(this.tbpCollectData);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResource.Location = new System.Drawing.Point(3, 5);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(736, 358);
            this.tabResource.TabIndex = 0;
            // 
            // tbpResStatus
            // 
            this.tbpResStatus.Controls.Add(this.grpCurrentStatus);
            this.tbpResStatus.Controls.Add(this.grpComment);
            this.tbpResStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpResStatus.Name = "tbpResStatus";
            this.tbpResStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResStatus.Size = new System.Drawing.Size(728, 332);
            this.tbpResStatus.TabIndex = 5;
            this.tbpResStatus.Text = "Sub Resource Status";
            // 
            // grpCurrentStatus
            // 
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus10);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus9);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus8);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus7);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus6);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus5);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus4);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus3);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus2);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus1);
            this.grpCurrentStatus.Controls.Add(this.cdvPrimaryChange);
            this.grpCurrentStatus.Controls.Add(this.txtChangeUpDown);
            this.grpCurrentStatus.Controls.Add(this.txtPrimaryCurrent);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus10);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus9);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus8);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus7);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus6);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus5);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus4);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus3);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus2);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus1);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentUpDown);
            this.grpCurrentStatus.Controls.Add(this.lblPrimaryStatus);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus10);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus9);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus8);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus7);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus6);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus5);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus4);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus3);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus2);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus1);
            this.grpCurrentStatus.Controls.Add(this.lblUpDown);
            this.grpCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCurrentStatus.Location = new System.Drawing.Point(3, 0);
            this.grpCurrentStatus.Name = "grpCurrentStatus";
            this.grpCurrentStatus.Size = new System.Drawing.Size(722, 283);
            this.grpCurrentStatus.TabIndex = 1;
            this.grpCurrentStatus.TabStop = false;
            // 
            // cdvChangeStatus10
            // 
            this.cdvChangeStatus10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus10.BtnToolTipText = "";
            this.cdvChangeStatus10.DescText = "";
            this.cdvChangeStatus10.DisplaySubItemIndex = -1;
            this.cdvChangeStatus10.DisplayText = "";
            this.cdvChangeStatus10.Focusing = null;
            this.cdvChangeStatus10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus10.Index = 0;
            this.cdvChangeStatus10.IsViewBtnImage = false;
            this.cdvChangeStatus10.Location = new System.Drawing.Point(384, 256);
            this.cdvChangeStatus10.MaxLength = 32767;
            this.cdvChangeStatus10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.Name = "cdvChangeStatus10";
            this.cdvChangeStatus10.ReadOnly = false;
            this.cdvChangeStatus10.SearchSubItemIndex = 0;
            this.cdvChangeStatus10.SelectedDescIndex = -1;
            this.cdvChangeStatus10.SelectedSubItemIndex = -1;
            this.cdvChangeStatus10.SelectionStart = 0;
            this.cdvChangeStatus10.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus10.SmallImageList = null;
            this.cdvChangeStatus10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus10.TabIndex = 35;
            this.cdvChangeStatus10.TextBoxToolTipText = "";
            this.cdvChangeStatus10.TextBoxWidth = 176;
            this.cdvChangeStatus10.VisibleButton = true;
            this.cdvChangeStatus10.VisibleColumnHeader = false;
            this.cdvChangeStatus10.VisibleDescription = false;
            this.cdvChangeStatus10.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus9
            // 
            this.cdvChangeStatus9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus9.BtnToolTipText = "";
            this.cdvChangeStatus9.DescText = "";
            this.cdvChangeStatus9.DisplaySubItemIndex = -1;
            this.cdvChangeStatus9.DisplayText = "";
            this.cdvChangeStatus9.Focusing = null;
            this.cdvChangeStatus9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus9.Index = 0;
            this.cdvChangeStatus9.IsViewBtnImage = false;
            this.cdvChangeStatus9.Location = new System.Drawing.Point(384, 234);
            this.cdvChangeStatus9.MaxLength = 32767;
            this.cdvChangeStatus9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.Name = "cdvChangeStatus9";
            this.cdvChangeStatus9.ReadOnly = false;
            this.cdvChangeStatus9.SearchSubItemIndex = 0;
            this.cdvChangeStatus9.SelectedDescIndex = -1;
            this.cdvChangeStatus9.SelectedSubItemIndex = -1;
            this.cdvChangeStatus9.SelectionStart = 0;
            this.cdvChangeStatus9.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus9.SmallImageList = null;
            this.cdvChangeStatus9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus9.TabIndex = 32;
            this.cdvChangeStatus9.TextBoxToolTipText = "";
            this.cdvChangeStatus9.TextBoxWidth = 176;
            this.cdvChangeStatus9.VisibleButton = true;
            this.cdvChangeStatus9.VisibleColumnHeader = false;
            this.cdvChangeStatus9.VisibleDescription = false;
            this.cdvChangeStatus9.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus8
            // 
            this.cdvChangeStatus8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus8.BtnToolTipText = "";
            this.cdvChangeStatus8.DescText = "";
            this.cdvChangeStatus8.DisplaySubItemIndex = -1;
            this.cdvChangeStatus8.DisplayText = "";
            this.cdvChangeStatus8.Focusing = null;
            this.cdvChangeStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus8.Index = 0;
            this.cdvChangeStatus8.IsViewBtnImage = false;
            this.cdvChangeStatus8.Location = new System.Drawing.Point(384, 212);
            this.cdvChangeStatus8.MaxLength = 32767;
            this.cdvChangeStatus8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.Name = "cdvChangeStatus8";
            this.cdvChangeStatus8.ReadOnly = false;
            this.cdvChangeStatus8.SearchSubItemIndex = 0;
            this.cdvChangeStatus8.SelectedDescIndex = -1;
            this.cdvChangeStatus8.SelectedSubItemIndex = -1;
            this.cdvChangeStatus8.SelectionStart = 0;
            this.cdvChangeStatus8.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus8.SmallImageList = null;
            this.cdvChangeStatus8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus8.TabIndex = 29;
            this.cdvChangeStatus8.TextBoxToolTipText = "";
            this.cdvChangeStatus8.TextBoxWidth = 176;
            this.cdvChangeStatus8.VisibleButton = true;
            this.cdvChangeStatus8.VisibleColumnHeader = false;
            this.cdvChangeStatus8.VisibleDescription = false;
            this.cdvChangeStatus8.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus7
            // 
            this.cdvChangeStatus7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus7.BtnToolTipText = "";
            this.cdvChangeStatus7.DescText = "";
            this.cdvChangeStatus7.DisplaySubItemIndex = -1;
            this.cdvChangeStatus7.DisplayText = "";
            this.cdvChangeStatus7.Focusing = null;
            this.cdvChangeStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus7.Index = 0;
            this.cdvChangeStatus7.IsViewBtnImage = false;
            this.cdvChangeStatus7.Location = new System.Drawing.Point(384, 190);
            this.cdvChangeStatus7.MaxLength = 32767;
            this.cdvChangeStatus7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.Name = "cdvChangeStatus7";
            this.cdvChangeStatus7.ReadOnly = false;
            this.cdvChangeStatus7.SearchSubItemIndex = 0;
            this.cdvChangeStatus7.SelectedDescIndex = -1;
            this.cdvChangeStatus7.SelectedSubItemIndex = -1;
            this.cdvChangeStatus7.SelectionStart = 0;
            this.cdvChangeStatus7.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus7.SmallImageList = null;
            this.cdvChangeStatus7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus7.TabIndex = 26;
            this.cdvChangeStatus7.TextBoxToolTipText = "";
            this.cdvChangeStatus7.TextBoxWidth = 176;
            this.cdvChangeStatus7.VisibleButton = true;
            this.cdvChangeStatus7.VisibleColumnHeader = false;
            this.cdvChangeStatus7.VisibleDescription = false;
            this.cdvChangeStatus7.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus6
            // 
            this.cdvChangeStatus6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus6.BtnToolTipText = "";
            this.cdvChangeStatus6.DescText = "";
            this.cdvChangeStatus6.DisplaySubItemIndex = -1;
            this.cdvChangeStatus6.DisplayText = "";
            this.cdvChangeStatus6.Focusing = null;
            this.cdvChangeStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus6.Index = 0;
            this.cdvChangeStatus6.IsViewBtnImage = false;
            this.cdvChangeStatus6.Location = new System.Drawing.Point(384, 168);
            this.cdvChangeStatus6.MaxLength = 32767;
            this.cdvChangeStatus6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.Name = "cdvChangeStatus6";
            this.cdvChangeStatus6.ReadOnly = false;
            this.cdvChangeStatus6.SearchSubItemIndex = 0;
            this.cdvChangeStatus6.SelectedDescIndex = -1;
            this.cdvChangeStatus6.SelectedSubItemIndex = -1;
            this.cdvChangeStatus6.SelectionStart = 0;
            this.cdvChangeStatus6.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus6.SmallImageList = null;
            this.cdvChangeStatus6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus6.TabIndex = 23;
            this.cdvChangeStatus6.TextBoxToolTipText = "";
            this.cdvChangeStatus6.TextBoxWidth = 176;
            this.cdvChangeStatus6.VisibleButton = true;
            this.cdvChangeStatus6.VisibleColumnHeader = false;
            this.cdvChangeStatus6.VisibleDescription = false;
            this.cdvChangeStatus6.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus5
            // 
            this.cdvChangeStatus5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus5.BtnToolTipText = "";
            this.cdvChangeStatus5.DescText = "";
            this.cdvChangeStatus5.DisplaySubItemIndex = -1;
            this.cdvChangeStatus5.DisplayText = "";
            this.cdvChangeStatus5.Focusing = null;
            this.cdvChangeStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus5.Index = 0;
            this.cdvChangeStatus5.IsViewBtnImage = false;
            this.cdvChangeStatus5.Location = new System.Drawing.Point(384, 146);
            this.cdvChangeStatus5.MaxLength = 32767;
            this.cdvChangeStatus5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.Name = "cdvChangeStatus5";
            this.cdvChangeStatus5.ReadOnly = false;
            this.cdvChangeStatus5.SearchSubItemIndex = 0;
            this.cdvChangeStatus5.SelectedDescIndex = -1;
            this.cdvChangeStatus5.SelectedSubItemIndex = -1;
            this.cdvChangeStatus5.SelectionStart = 0;
            this.cdvChangeStatus5.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus5.SmallImageList = null;
            this.cdvChangeStatus5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus5.TabIndex = 20;
            this.cdvChangeStatus5.TextBoxToolTipText = "";
            this.cdvChangeStatus5.TextBoxWidth = 176;
            this.cdvChangeStatus5.VisibleButton = true;
            this.cdvChangeStatus5.VisibleColumnHeader = false;
            this.cdvChangeStatus5.VisibleDescription = false;
            this.cdvChangeStatus5.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus4
            // 
            this.cdvChangeStatus4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus4.BtnToolTipText = "";
            this.cdvChangeStatus4.DescText = "";
            this.cdvChangeStatus4.DisplaySubItemIndex = -1;
            this.cdvChangeStatus4.DisplayText = "";
            this.cdvChangeStatus4.Focusing = null;
            this.cdvChangeStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus4.Index = 0;
            this.cdvChangeStatus4.IsViewBtnImage = false;
            this.cdvChangeStatus4.Location = new System.Drawing.Point(384, 124);
            this.cdvChangeStatus4.MaxLength = 32767;
            this.cdvChangeStatus4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.Name = "cdvChangeStatus4";
            this.cdvChangeStatus4.ReadOnly = false;
            this.cdvChangeStatus4.SearchSubItemIndex = 0;
            this.cdvChangeStatus4.SelectedDescIndex = -1;
            this.cdvChangeStatus4.SelectedSubItemIndex = -1;
            this.cdvChangeStatus4.SelectionStart = 0;
            this.cdvChangeStatus4.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus4.SmallImageList = null;
            this.cdvChangeStatus4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus4.TabIndex = 17;
            this.cdvChangeStatus4.TextBoxToolTipText = "";
            this.cdvChangeStatus4.TextBoxWidth = 176;
            this.cdvChangeStatus4.VisibleButton = true;
            this.cdvChangeStatus4.VisibleColumnHeader = false;
            this.cdvChangeStatus4.VisibleDescription = false;
            this.cdvChangeStatus4.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus3
            // 
            this.cdvChangeStatus3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus3.BtnToolTipText = "";
            this.cdvChangeStatus3.DescText = "";
            this.cdvChangeStatus3.DisplaySubItemIndex = -1;
            this.cdvChangeStatus3.DisplayText = "";
            this.cdvChangeStatus3.Focusing = null;
            this.cdvChangeStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus3.Index = 0;
            this.cdvChangeStatus3.IsViewBtnImage = false;
            this.cdvChangeStatus3.Location = new System.Drawing.Point(384, 102);
            this.cdvChangeStatus3.MaxLength = 32767;
            this.cdvChangeStatus3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.Name = "cdvChangeStatus3";
            this.cdvChangeStatus3.ReadOnly = false;
            this.cdvChangeStatus3.SearchSubItemIndex = 0;
            this.cdvChangeStatus3.SelectedDescIndex = -1;
            this.cdvChangeStatus3.SelectedSubItemIndex = -1;
            this.cdvChangeStatus3.SelectionStart = 0;
            this.cdvChangeStatus3.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus3.SmallImageList = null;
            this.cdvChangeStatus3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus3.TabIndex = 14;
            this.cdvChangeStatus3.TextBoxToolTipText = "";
            this.cdvChangeStatus3.TextBoxWidth = 176;
            this.cdvChangeStatus3.VisibleButton = true;
            this.cdvChangeStatus3.VisibleColumnHeader = false;
            this.cdvChangeStatus3.VisibleDescription = false;
            this.cdvChangeStatus3.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus2
            // 
            this.cdvChangeStatus2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus2.BtnToolTipText = "";
            this.cdvChangeStatus2.DescText = "";
            this.cdvChangeStatus2.DisplaySubItemIndex = -1;
            this.cdvChangeStatus2.DisplayText = "";
            this.cdvChangeStatus2.Focusing = null;
            this.cdvChangeStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus2.Index = 0;
            this.cdvChangeStatus2.IsViewBtnImage = false;
            this.cdvChangeStatus2.Location = new System.Drawing.Point(384, 80);
            this.cdvChangeStatus2.MaxLength = 32767;
            this.cdvChangeStatus2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.Name = "cdvChangeStatus2";
            this.cdvChangeStatus2.ReadOnly = false;
            this.cdvChangeStatus2.SearchSubItemIndex = 0;
            this.cdvChangeStatus2.SelectedDescIndex = -1;
            this.cdvChangeStatus2.SelectedSubItemIndex = -1;
            this.cdvChangeStatus2.SelectionStart = 0;
            this.cdvChangeStatus2.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus2.SmallImageList = null;
            this.cdvChangeStatus2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus2.TabIndex = 11;
            this.cdvChangeStatus2.TextBoxToolTipText = "";
            this.cdvChangeStatus2.TextBoxWidth = 176;
            this.cdvChangeStatus2.VisibleButton = true;
            this.cdvChangeStatus2.VisibleColumnHeader = false;
            this.cdvChangeStatus2.VisibleDescription = false;
            this.cdvChangeStatus2.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus1
            // 
            this.cdvChangeStatus1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus1.BtnToolTipText = "";
            this.cdvChangeStatus1.DescText = "";
            this.cdvChangeStatus1.DisplaySubItemIndex = -1;
            this.cdvChangeStatus1.DisplayText = "";
            this.cdvChangeStatus1.Focusing = null;
            this.cdvChangeStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus1.Index = 0;
            this.cdvChangeStatus1.IsViewBtnImage = false;
            this.cdvChangeStatus1.Location = new System.Drawing.Point(384, 58);
            this.cdvChangeStatus1.MaxLength = 32767;
            this.cdvChangeStatus1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.Name = "cdvChangeStatus1";
            this.cdvChangeStatus1.ReadOnly = false;
            this.cdvChangeStatus1.SearchSubItemIndex = 0;
            this.cdvChangeStatus1.SelectedDescIndex = -1;
            this.cdvChangeStatus1.SelectedSubItemIndex = -1;
            this.cdvChangeStatus1.SelectionStart = 0;
            this.cdvChangeStatus1.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus1.SmallImageList = null;
            this.cdvChangeStatus1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus1.TabIndex = 8;
            this.cdvChangeStatus1.TextBoxToolTipText = "";
            this.cdvChangeStatus1.TextBoxWidth = 176;
            this.cdvChangeStatus1.VisibleButton = true;
            this.cdvChangeStatus1.VisibleColumnHeader = false;
            this.cdvChangeStatus1.VisibleDescription = false;
            this.cdvChangeStatus1.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvPrimaryChange
            // 
            this.cdvPrimaryChange.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrimaryChange.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrimaryChange.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrimaryChange.BtnToolTipText = "";
            this.cdvPrimaryChange.DescText = "";
            this.cdvPrimaryChange.DisplaySubItemIndex = -1;
            this.cdvPrimaryChange.DisplayText = "";
            this.cdvPrimaryChange.Focusing = null;
            this.cdvPrimaryChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrimaryChange.Index = 0;
            this.cdvPrimaryChange.IsViewBtnImage = false;
            this.cdvPrimaryChange.Location = new System.Drawing.Point(384, 36);
            this.cdvPrimaryChange.MaxLength = 32767;
            this.cdvPrimaryChange.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.Name = "cdvPrimaryChange";
            this.cdvPrimaryChange.ReadOnly = false;
            this.cdvPrimaryChange.SearchSubItemIndex = 0;
            this.cdvPrimaryChange.SelectedDescIndex = -1;
            this.cdvPrimaryChange.SelectedSubItemIndex = -1;
            this.cdvPrimaryChange.SelectionStart = 0;
            this.cdvPrimaryChange.Size = new System.Drawing.Size(176, 20);
            this.cdvPrimaryChange.SmallImageList = null;
            this.cdvPrimaryChange.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrimaryChange.TabIndex = 5;
            this.cdvPrimaryChange.TextBoxToolTipText = "";
            this.cdvPrimaryChange.TextBoxWidth = 176;
            this.cdvPrimaryChange.VisibleButton = true;
            this.cdvPrimaryChange.VisibleColumnHeader = false;
            this.cdvPrimaryChange.VisibleDescription = false;
            this.cdvPrimaryChange.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // txtChangeUpDown
            // 
            this.txtChangeUpDown.Location = new System.Drawing.Point(384, 14);
            this.txtChangeUpDown.MaxLength = 4;
            this.txtChangeUpDown.Name = "txtChangeUpDown";
            this.txtChangeUpDown.ReadOnly = true;
            this.txtChangeUpDown.Size = new System.Drawing.Size(176, 20);
            this.txtChangeUpDown.TabIndex = 2;
            this.txtChangeUpDown.TabStop = false;
            // 
            // txtPrimaryCurrent
            // 
            this.txtPrimaryCurrent.Location = new System.Drawing.Point(168, 36);
            this.txtPrimaryCurrent.MaxLength = 30;
            this.txtPrimaryCurrent.Name = "txtPrimaryCurrent";
            this.txtPrimaryCurrent.ReadOnly = true;
            this.txtPrimaryCurrent.Size = new System.Drawing.Size(176, 20);
            this.txtPrimaryCurrent.TabIndex = 4;
            this.txtPrimaryCurrent.TabStop = false;
            // 
            // txtCurrentStatus10
            // 
            this.txtCurrentStatus10.Location = new System.Drawing.Point(168, 256);
            this.txtCurrentStatus10.MaxLength = 30;
            this.txtCurrentStatus10.Name = "txtCurrentStatus10";
            this.txtCurrentStatus10.ReadOnly = true;
            this.txtCurrentStatus10.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus10.TabIndex = 34;
            this.txtCurrentStatus10.TabStop = false;
            // 
            // txtCurrentStatus9
            // 
            this.txtCurrentStatus9.Location = new System.Drawing.Point(168, 234);
            this.txtCurrentStatus9.MaxLength = 30;
            this.txtCurrentStatus9.Name = "txtCurrentStatus9";
            this.txtCurrentStatus9.ReadOnly = true;
            this.txtCurrentStatus9.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus9.TabIndex = 31;
            this.txtCurrentStatus9.TabStop = false;
            // 
            // txtCurrentStatus8
            // 
            this.txtCurrentStatus8.Location = new System.Drawing.Point(168, 212);
            this.txtCurrentStatus8.MaxLength = 30;
            this.txtCurrentStatus8.Name = "txtCurrentStatus8";
            this.txtCurrentStatus8.ReadOnly = true;
            this.txtCurrentStatus8.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus8.TabIndex = 28;
            this.txtCurrentStatus8.TabStop = false;
            // 
            // txtCurrentStatus7
            // 
            this.txtCurrentStatus7.Location = new System.Drawing.Point(168, 190);
            this.txtCurrentStatus7.MaxLength = 30;
            this.txtCurrentStatus7.Name = "txtCurrentStatus7";
            this.txtCurrentStatus7.ReadOnly = true;
            this.txtCurrentStatus7.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus7.TabIndex = 25;
            this.txtCurrentStatus7.TabStop = false;
            // 
            // txtCurrentStatus6
            // 
            this.txtCurrentStatus6.Location = new System.Drawing.Point(168, 168);
            this.txtCurrentStatus6.MaxLength = 30;
            this.txtCurrentStatus6.Name = "txtCurrentStatus6";
            this.txtCurrentStatus6.ReadOnly = true;
            this.txtCurrentStatus6.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus6.TabIndex = 22;
            this.txtCurrentStatus6.TabStop = false;
            // 
            // txtCurrentStatus5
            // 
            this.txtCurrentStatus5.Location = new System.Drawing.Point(168, 146);
            this.txtCurrentStatus5.MaxLength = 30;
            this.txtCurrentStatus5.Name = "txtCurrentStatus5";
            this.txtCurrentStatus5.ReadOnly = true;
            this.txtCurrentStatus5.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus5.TabIndex = 19;
            this.txtCurrentStatus5.TabStop = false;
            // 
            // txtCurrentStatus4
            // 
            this.txtCurrentStatus4.Location = new System.Drawing.Point(168, 124);
            this.txtCurrentStatus4.MaxLength = 30;
            this.txtCurrentStatus4.Name = "txtCurrentStatus4";
            this.txtCurrentStatus4.ReadOnly = true;
            this.txtCurrentStatus4.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus4.TabIndex = 16;
            this.txtCurrentStatus4.TabStop = false;
            // 
            // txtCurrentStatus3
            // 
            this.txtCurrentStatus3.Location = new System.Drawing.Point(168, 102);
            this.txtCurrentStatus3.MaxLength = 30;
            this.txtCurrentStatus3.Name = "txtCurrentStatus3";
            this.txtCurrentStatus3.ReadOnly = true;
            this.txtCurrentStatus3.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus3.TabIndex = 13;
            this.txtCurrentStatus3.TabStop = false;
            // 
            // txtCurrentStatus2
            // 
            this.txtCurrentStatus2.Location = new System.Drawing.Point(168, 80);
            this.txtCurrentStatus2.MaxLength = 30;
            this.txtCurrentStatus2.Name = "txtCurrentStatus2";
            this.txtCurrentStatus2.ReadOnly = true;
            this.txtCurrentStatus2.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus2.TabIndex = 10;
            this.txtCurrentStatus2.TabStop = false;
            // 
            // txtCurrentStatus1
            // 
            this.txtCurrentStatus1.Location = new System.Drawing.Point(168, 58);
            this.txtCurrentStatus1.MaxLength = 30;
            this.txtCurrentStatus1.Name = "txtCurrentStatus1";
            this.txtCurrentStatus1.ReadOnly = true;
            this.txtCurrentStatus1.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus1.TabIndex = 7;
            this.txtCurrentStatus1.TabStop = false;
            // 
            // txtCurrentUpDown
            // 
            this.txtCurrentUpDown.Location = new System.Drawing.Point(168, 14);
            this.txtCurrentUpDown.MaxLength = 4;
            this.txtCurrentUpDown.Name = "txtCurrentUpDown";
            this.txtCurrentUpDown.ReadOnly = true;
            this.txtCurrentUpDown.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentUpDown.TabIndex = 1;
            this.txtCurrentUpDown.TabStop = false;
            // 
            // lblPrimaryStatus
            // 
            this.lblPrimaryStatus.AutoSize = true;
            this.lblPrimaryStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrimaryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryStatus.Location = new System.Drawing.Point(16, 39);
            this.lblPrimaryStatus.Name = "lblPrimaryStatus";
            this.lblPrimaryStatus.Size = new System.Drawing.Size(74, 13);
            this.lblPrimaryStatus.TabIndex = 3;
            this.lblPrimaryStatus.Text = "Primary Status";
            // 
            // lblCurrentStatus10
            // 
            this.lblCurrentStatus10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus10.Location = new System.Drawing.Point(16, 259);
            this.lblCurrentStatus10.Name = "lblCurrentStatus10";
            this.lblCurrentStatus10.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus10.TabIndex = 33;
            // 
            // lblCurrentStatus9
            // 
            this.lblCurrentStatus9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus9.Location = new System.Drawing.Point(16, 237);
            this.lblCurrentStatus9.Name = "lblCurrentStatus9";
            this.lblCurrentStatus9.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus9.TabIndex = 30;
            // 
            // lblCurrentStatus8
            // 
            this.lblCurrentStatus8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus8.Location = new System.Drawing.Point(16, 215);
            this.lblCurrentStatus8.Name = "lblCurrentStatus8";
            this.lblCurrentStatus8.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus8.TabIndex = 27;
            // 
            // lblCurrentStatus7
            // 
            this.lblCurrentStatus7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus7.Location = new System.Drawing.Point(16, 193);
            this.lblCurrentStatus7.Name = "lblCurrentStatus7";
            this.lblCurrentStatus7.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus7.TabIndex = 24;
            // 
            // lblCurrentStatus6
            // 
            this.lblCurrentStatus6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus6.Location = new System.Drawing.Point(16, 171);
            this.lblCurrentStatus6.Name = "lblCurrentStatus6";
            this.lblCurrentStatus6.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus6.TabIndex = 21;
            // 
            // lblCurrentStatus5
            // 
            this.lblCurrentStatus5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus5.Location = new System.Drawing.Point(16, 149);
            this.lblCurrentStatus5.Name = "lblCurrentStatus5";
            this.lblCurrentStatus5.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus5.TabIndex = 18;
            // 
            // lblCurrentStatus4
            // 
            this.lblCurrentStatus4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus4.Location = new System.Drawing.Point(16, 127);
            this.lblCurrentStatus4.Name = "lblCurrentStatus4";
            this.lblCurrentStatus4.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus4.TabIndex = 15;
            // 
            // lblCurrentStatus3
            // 
            this.lblCurrentStatus3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus3.Location = new System.Drawing.Point(16, 105);
            this.lblCurrentStatus3.Name = "lblCurrentStatus3";
            this.lblCurrentStatus3.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus3.TabIndex = 12;
            // 
            // lblCurrentStatus2
            // 
            this.lblCurrentStatus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus2.Location = new System.Drawing.Point(16, 83);
            this.lblCurrentStatus2.Name = "lblCurrentStatus2";
            this.lblCurrentStatus2.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus2.TabIndex = 9;
            // 
            // lblCurrentStatus1
            // 
            this.lblCurrentStatus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus1.Location = new System.Drawing.Point(16, 61);
            this.lblCurrentStatus1.Name = "lblCurrentStatus1";
            this.lblCurrentStatus1.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus1.TabIndex = 6;
            // 
            // lblUpDown
            // 
            this.lblUpDown.AutoSize = true;
            this.lblUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpDown.Location = new System.Drawing.Point(16, 17);
            this.lblUpDown.Name = "lblUpDown";
            this.lblUpDown.Size = new System.Drawing.Size(77, 13);
            this.lblUpDown.TabIndex = 0;
            this.lblUpDown.Text = "Up/Down Flag";
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 283);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(722, 46);
            this.grpComment.TabIndex = 3;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 13);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(590, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 332);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "Resource Infromation";
            this.tbpGeneral.Visible = false;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtProcMode);
            this.grpGeneral.Controls.Add(this.txtResourceType);
            this.grpGeneral.Controls.Add(this.lblProcMode);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.lblResType);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 329);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // txtProcMode
            // 
            this.txtProcMode.Location = new System.Drawing.Point(160, 67);
            this.txtProcMode.Name = "txtProcMode";
            this.txtProcMode.ReadOnly = true;
            this.txtProcMode.Size = new System.Drawing.Size(180, 20);
            this.txtProcMode.TabIndex = 6;
            this.txtProcMode.TabStop = false;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Location = new System.Drawing.Point(160, 19);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.ReadOnly = true;
            this.txtResourceType.Size = new System.Drawing.Size(180, 20);
            this.txtResourceType.TabIndex = 2;
            this.txtResourceType.TabStop = false;
            // 
            // lblProcMode
            // 
            this.lblProcMode.AutoSize = true;
            this.lblProcMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcMode.Location = new System.Drawing.Point(20, 69);
            this.lblProcMode.Name = "lblProcMode";
            this.lblProcMode.Size = new System.Drawing.Size(75, 13);
            this.lblProcMode.TabIndex = 5;
            this.lblProcMode.Text = "Process Mode";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(20, 117);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 9;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(20, 93);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 7;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(160, 115);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(180, 20);
            this.txtUpdateTime.TabIndex = 10;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(160, 91);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(180, 20);
            this.txtUpdateUser.TabIndex = 8;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(160, 43);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(180, 20);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(20, 45);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Location";
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(20, 22);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 1;
            this.lblResType.Text = "Resource Type";
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCMF.Size = new System.Drawing.Size(728, 332);
            this.tbpCMF.TabIndex = 6;
            this.tbpCMF.Text = "Customized Field";
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
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 326);
            this.grpCMF.TabIndex = 2;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(530, 208);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 77;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 180;
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
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(530, 184);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 75;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 180;
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
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(530, 160);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 73;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 180;
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
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(530, 136);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 71;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 180;
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
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(530, 112);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 69;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 180;
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
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(530, 88);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 67;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 180;
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
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(530, 64);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 65;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 180;
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
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(530, 40);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 63;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 180;
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
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(530, 232);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 79;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 180;
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
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(530, 16);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 61;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 180;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(384, 236);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 78;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(384, 212);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 76;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(384, 188);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 74;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(384, 164);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 72;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(384, 140);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 70;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(384, 116);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 68;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(384, 92);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 66;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(384, 68);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 64;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(384, 44);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 62;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(384, 20);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 60;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(163, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 57;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
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
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(163, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 55;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
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
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(163, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 53;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
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
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(163, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 51;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
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
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(163, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 49;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
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
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(163, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 47;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
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
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(163, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 45;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
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
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(163, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 43;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
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
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(163, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 59;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
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
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(163, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 41;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(17, 236);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 58;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(17, 212);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 56;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(17, 188);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 54;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(17, 164);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 52;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(17, 140);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 50;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(17, 116);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 48;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(17, 92);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 46;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(17, 68);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 44;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(17, 44);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 42;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(17, 20);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 40;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCollectData
            // 
            this.tbpCollectData.Controls.Add(this.pnlResData);
            this.tbpCollectData.Controls.Add(this.pnlCol);
            this.tbpCollectData.Location = new System.Drawing.Point(4, 22);
            this.tbpCollectData.Name = "tbpCollectData";
            this.tbpCollectData.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCollectData.Size = new System.Drawing.Size(728, 332);
            this.tbpCollectData.TabIndex = 7;
            this.tbpCollectData.Text = "Collect Resource Data";
            // 
            // pnlResData
            // 
            this.pnlResData.Controls.Add(this.spdData);
            this.pnlResData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResData.Location = new System.Drawing.Point(3, 50);
            this.pnlResData.Name = "pnlResData";
            this.pnlResData.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlResData.Size = new System.Drawing.Size(722, 279);
            this.pnlResData.TabIndex = 2;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 4;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 3);
            this.spdData.Name = "spdData";
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
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(722, 276);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 12;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 5;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 13;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            spdData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Opt Input";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = " Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Default Unit Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Default Unit Over Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = " Default Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = " Unit Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = " Value Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 12).Value = "1";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 16F;
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 25;
            textCellType1.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType2.MaxLength = 50;
            textCellType2.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 120F;
            this.spdData_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType3.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(2).Label = "Spec";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 100F;
            this.spdData_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Visible = false;
            this.spdData_Sheet1.Columns.Get(3).Width = 61F;
            this.spdData_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType5.MaxLength = 1;
            textCellType5.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 40F;
            this.spdData_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Visible = false;
            this.spdData_Sheet1.Columns.Get(5).Width = 96F;
            this.spdData_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType7;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Visible = false;
            this.spdData_Sheet1.Columns.Get(6).Width = 122F;
            this.spdData_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType8;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Visible = false;
            this.spdData_Sheet1.Columns.Get(7).Width = 84F;
            this.spdData_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(8).CellType = textCellType9;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Visible = false;
            this.spdData_Sheet1.Columns.Get(8).Width = 69F;
            this.spdData_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(9).CellType = textCellType10;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Visible = false;
            this.spdData_Sheet1.Columns.Get(9).Width = 77F;
            this.spdData_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType11.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(10).CellType = textCellType11;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 30F;
            textCellType12.MaxLength = 50;
            this.spdData_Sheet1.Columns.Get(11).CellType = textCellType12;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            textCellType13.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(12).CellType = textCellType13;
            this.spdData_Sheet1.Columns.Get(12).Label = "1";
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType14.MaxLength = 25;
            this.spdData_Sheet1.DefaultStyle.CellType = textCellType14;
            this.spdData_Sheet1.DefaultStyle.Locked = false;
            this.spdData_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdData_Sheet1.DefaultStyle.Renderer = textCellType14;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlCol
            // 
            this.pnlCol.Controls.Add(this.grpCol);
            this.pnlCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCol.Location = new System.Drawing.Point(3, 3);
            this.pnlCol.Name = "pnlCol";
            this.pnlCol.Size = new System.Drawing.Size(722, 47);
            this.pnlCol.TabIndex = 1;
            // 
            // grpCol
            // 
            this.grpCol.Controls.Add(this.txtColSet);
            this.grpCol.Controls.Add(this.txtColSetVersion);
            this.grpCol.Controls.Add(this.lblColSetVersion);
            this.grpCol.Controls.Add(this.lblColSet);
            this.grpCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCol.Location = new System.Drawing.Point(0, 0);
            this.grpCol.Name = "grpCol";
            this.grpCol.Size = new System.Drawing.Size(722, 47);
            this.grpCol.TabIndex = 0;
            this.grpCol.TabStop = false;
            // 
            // txtColSet
            // 
            this.txtColSet.Location = new System.Drawing.Point(120, 16);
            this.txtColSet.MaxLength = 25;
            this.txtColSet.Name = "txtColSet";
            this.txtColSet.ReadOnly = true;
            this.txtColSet.Size = new System.Drawing.Size(200, 20);
            this.txtColSet.TabIndex = 1;
            this.txtColSet.TabStop = false;
            // 
            // txtColSetVersion
            // 
            this.txtColSetVersion.Location = new System.Drawing.Point(572, 16);
            this.txtColSetVersion.MaxLength = 3;
            this.txtColSetVersion.Name = "txtColSetVersion";
            this.txtColSetVersion.ReadOnly = true;
            this.txtColSetVersion.Size = new System.Drawing.Size(144, 20);
            this.txtColSetVersion.TabIndex = 3;
            this.txtColSetVersion.TabStop = false;
            // 
            // lblColSetVersion
            // 
            this.lblColSetVersion.AutoSize = true;
            this.lblColSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVersion.Location = new System.Drawing.Point(454, 19);
            this.lblColSetVersion.Name = "lblColSetVersion";
            this.lblColSetVersion.Size = new System.Drawing.Size(110, 13);
            this.lblColSetVersion.TabIndex = 2;
            this.lblColSetVersion.Text = "Collection Set Version";
            // 
            // lblColSet
            // 
            this.lblColSet.AutoSize = true;
            this.lblColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSet.Location = new System.Drawing.Point(15, 19);
            this.lblColSet.Name = "lblColSet";
            this.lblColSet.Size = new System.Drawing.Size(72, 13);
            this.lblColSet.TabIndex = 0;
            this.lblColSet.Text = "Collection Set";
            // 
            // frmRASTranSubEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranSubEvent";
            this.Text = "Sub Resource Event";
            this.Activated += new System.EventHandler(this.frmRASTranEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASTranEvent_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRASTranEvent_KeyPress);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRes.ResumeLayout(false);
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            this.tbpResStatus.ResumeLayout(false);
            this.grpCurrentStatus.ResumeLayout(false);
            this.grpCurrentStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).EndInit();
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
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
            this.tbpCollectData.ResumeLayout(false);
            this.pnlResData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlCol.ResumeLayout(false);
            this.grpCol.ResumeLayout(false);
            this.grpCol.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "

        private const char CHANGE = 'Y';
        private const char NOTCHANGE = 'N';
        private const char INCREASE = '+';
        private const char DECREASE = '-';
        private const char OVERRIDE = 'O';
        private const char TIME = 'T';

        private const int CHAR_COL = 0;
        private const int CHAR_DESC_COL = 1;
        private const int SPEC_COL = 2;
        private const int OPT_INPUT_COL = 3;
        private const int VALUE_TYPE_COL = 4;
        private const int VALUE_COUNT_COL = 5;
        private const int DEF_UNIT_OVR_FLAG_COL = 6;
        private const int DEF_VALUE_COL = 7;
        private const int UNIT_TBL_COL = 8;
        private const int VALUE_TBL_COL = 9;
        private const int UNIT_SEQ_COL = 10;
        private const int UNIT_COL = 11;
        private const int VALUE_1_COL = 12;
        
        private const int VALUE_START_COL = 12;
        
        private const int MAX_DATA_COUNT = 1000;

        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string s_cur_res_id;
        private string s_cur_sub_res_id;

        public bool LoadFlag
        {
            get
            {
                return b_load_flag;
            }
            set
            {
                b_load_flag = value;
            }
        }
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this, cdvResID, cdvSubResID, null, null, null, false);
                }
                else
                {
                    MPCF.FieldClear(this, cdvResID, cdvSubResID, cdvEventID, null, null, false);
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
            int i, j;
            if (MPCF.CheckValue(cdvSubResID, 1) == false)
            {
                tabResource.SelectedTab = tbpGeneral;
                return false;
            }
            if (MPCF.CheckValue(cdvEventID, 1) == false)
            {
                tabResource.SelectedTab = tbpGeneral;
                return false;
            }
            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpGeneral) == false)
            {
                tabResource.SelectedTab = tbpCMF;
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                
            case "Collect_Res_Data":
                if (txtColSet.Text != "")
                {
                    if (spdData.ActiveSheet.RowCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        tabResource.SelectedTab = tbpCollectData;
                        spdData.Select();
                        return false;
                    }
                    else if (spdData.ActiveSheet.RowCount > MAX_DATA_COUNT)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(134));
                        tabResource.SelectedTab = tbpCollectData;
                        spdData.Select();
                        return false;
                    }

                    for (i = 0; i <= spdData.ActiveSheet.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, CHAR_COL)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdData.ActiveSheet.SetActiveCell(i, CHAR_COL);
                            tabResource.SelectedTab = tbpCollectData;
                            spdData.Select();
                            return false;
                        }

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, OPT_INPUT_COL)) != "Y")
                        {
                            for (j = UNIT_COL; j <= UNIT_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)); j++)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) == "" && MPCF.Trim(spdData.ActiveSheet.Cells[i, j].Tag) != "NULL")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, j);
                                    tabResource.SelectedTab = tbpCollectData;
                                    spdData.Select();
                                    return false;
                                }
                            }
                        }

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, VALUE_TYPE_COL)) == "N")
                        {
                            for (j = VALUE_START_COL; j <= VALUE_START_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)) - 1; j++)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) != "")
                                {
                                    if (MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j)) == false)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                        spdData.ActiveSheet.SetActiveCell(i, j);
                                        tabResource.SelectedTab = tbpCollectData;
                                        spdData.Select();
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                
                break;
                
        }
        
        return true;
        
    }
    
    
    //Private Function GetEventList() As Boolean
    
    //    Try
    //        cdvEventID.Init()
    //        InitListView(cdvEventID.GetListView)
    //        cdvEventID.Columns.Add("EventID", 50, HorizontalAlignment.Left)
    //        cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left)
    //        cdvEventID.SelectedSubItemIndex = 0
    
    //        If ViewEventList(cdvEventID.GetListView, '1') = False Then Return False
    
    //    Catch ex As Exception
    //        ShowMsgBox(ex.Message)
    //        Return False
    //    End Try
    
    //    Return True
    
    //End Function

        private bool Sub_Resource_Event(char ProcStep)
        {

            TRSNode in_node = new TRSNode("SUB_RESOURCE_EVENT_IN");
            TRSNode out_node = new TRSNode("SUB_RESOURCE_EVENT_OUT");
            TRSNode collect_res_data;
            TRSNode char_item;
            TRSNode value_item;
            TRSNode spec_out_mask_ary;
            TRSNode unit_item;
           
            int i;
            int j;
            int k;
            int i_row;
            int i_value_count;

            CultureInfo ci_inter = new CultureInfo("en-US");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SUBRES_ID", cdvSubResID.Text);
                in_node.AddString("EVENT_ID", cdvEventID.Text);
                in_node.AddString("CHG_PRI_STS", cdvPrimaryChange.Text);
                in_node.AddString("CHG_STS_1", cdvChangeStatus1.Text);
                in_node.AddString("CHG_STS_2", cdvChangeStatus2.Text);
                in_node.AddString("CHG_STS_3", cdvChangeStatus3.Text);
                in_node.AddString("CHG_STS_4", cdvChangeStatus4.Text);
                in_node.AddString("CHG_STS_5", cdvChangeStatus5.Text);
                in_node.AddString("CHG_STS_6", cdvChangeStatus6.Text);
                in_node.AddString("CHG_STS_7", cdvChangeStatus7.Text);
                in_node.AddString("CHG_STS_8", cdvChangeStatus8.Text);
                in_node.AddString("CHG_STS_9", cdvChangeStatus9.Text);
                in_node.AddString("CHG_STS_10", cdvChangeStatus10.Text);

                in_node.AddString("TRAN_CMF_1", cdvCMF1.Text);
                in_node.AddString("TRAN_CMF_2", cdvCMF2.Text);
                in_node.AddString("TRAN_CMF_3", cdvCMF3.Text);
                in_node.AddString("TRAN_CMF_4", cdvCMF4.Text);
                in_node.AddString("TRAN_CMF_5", cdvCMF5.Text);
                in_node.AddString("TRAN_CMF_6", cdvCMF6.Text);
                in_node.AddString("TRAN_CMF_7", cdvCMF7.Text);
                in_node.AddString("TRAN_CMF_8", cdvCMF8.Text);
                in_node.AddString("TRAN_CMF_9", cdvCMF9.Text);
                in_node.AddString("TRAN_CMF_10", cdvCMF10.Text);
                in_node.AddString("TRAN_CMF_11", cdvCMF11.Text);
                in_node.AddString("TRAN_CMF_12", cdvCMF12.Text);
                in_node.AddString("TRAN_CMF_13", cdvCMF13.Text);
                in_node.AddString("TRAN_CMF_14", cdvCMF14.Text);
                in_node.AddString("TRAN_CMF_15", cdvCMF15.Text);
                in_node.AddString("TRAN_CMF_16", cdvCMF16.Text);
                in_node.AddString("TRAN_CMF_17", cdvCMF17.Text);
                in_node.AddString("TRAN_CMF_18", cdvCMF18.Text);
                in_node.AddString("TRAN_CMF_19", cdvCMF19.Text);
                in_node.AddString("TRAN_CMF_20", cdvCMF20.Text);
                
                in_node.AddString("TRAN_COMMENT", txtComment.Text);

                if (MPCF.CheckNumeric(txtColSetVersion.Text) == true)
                {
                    in_node.AddString("COL_SET_ID", MPCF.Trim(txtColSet.Text));
                    in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVersion.Text));

                    /* EDC Collect Resource Data Node 구성 */
                    collect_res_data = in_node.AddNode("COLLECT_RES_DATA");

                    MPCR.SetInMsg(collect_res_data);
                    collect_res_data.ProcStep = ProcStep;
                    collect_res_data.AddChar("SUBRES_FLAG", 'Y');

                    if (chkTranDateTime.Checked == true)
                    {
                        collect_res_data.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                    }
                    collect_res_data.AddString("RES_ID", cdvResID.Text);
                    collect_res_data.AddString("SUBRES_ID", cdvSubResID.Text);
                    collect_res_data.AddString("EVENT_ID", cdvEventID.Text);
                    collect_res_data.AddString("COL_SET_ID", MPCF.Trim(txtColSet.Text));
                    collect_res_data.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVersion.Text));

                    char_item = collect_res_data.AddNode("CHAR_LIST");
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, UNIT_SEQ_COL)) == 1)
                        {
                            if (i != 0)
                            {
                                char_item = collect_res_data.AddNode("CHAR_LIST");
                            }
                            char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, CHAR_COL)));
                        }
                        unit_item = char_item.AddNode("UNIT_LIST");
                        unit_item.AddString("UNIT_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, UNIT_COL)));
                        unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, UNIT_SEQ_COL)));

                        i_value_count = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL));
                        for (j = 0; j < i_value_count; j++)
                        {
                            value_item = unit_item.AddNode("VALUE_LIST");

                            if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, VALUE_TYPE_COL)) == "N" &&
                                MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)) == true)
                            {
                                value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)).ToString(ci_inter.NumberFormat));
                            }
                            else
                            {
                                value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)));
                            }
                        }        
                    }
                }

                if (MessageCaster.CallService("RAS", "RAS_Sub_Resource_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                if (ProcStep == '1')
                {
                    if (in_node.GetList("COLLECT_RES_DATA").Count > 0)
                    {
                        i_row = 0;
                        collect_res_data = in_node.GetList("COLLECT_RES_DATA")[0];

                        for (i = 0; i < collect_res_data.GetList(0).Count; i++)
                        {
                            char_item = out_node.GetList("CHAR_LIST")[i];
                            for (k = 0; k < char_item.GetList(0).Count; k++)
                            {
                                unit_item = char_item.GetList("UNIT_LIST")[k];
                                spec_out_mask_ary = unit_item.GetArray("SPEC_OUT_MASK");

                                i_value_count = collect_res_data.GetList("CHAR_LIST")[i].GetList("UNIT_LIST")[k].GetList("VALUE_LIST").Count;

                                for (j = 0; j < i_value_count; j++)
                                {
                                    if (spec_out_mask_ary.GetChar(j.ToString()) == '1' ||
                                        spec_out_mask_ary.GetChar(j.ToString()) == '4' ||
                                        spec_out_mask_ary.GetChar(j.ToString()) == '5')
                                    {
                                        spdData.ActiveSheet.Cells[i_row, VALUE_START_COL + j].BackColor = Color.Red;
                                    }
                                    else if (spec_out_mask_ary.GetChar(j.ToString()) == '2' ||
                                             spec_out_mask_ary.GetChar(j.ToString()) == '3')
                                    {
                                        spdData.ActiveSheet.Cells[i_row, VALUE_START_COL + j].BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        spdData.ActiveSheet.Cells[i_row, VALUE_START_COL + j].BackColor = Color.White;
                                    }
                                }
                                i_row++;
                            } 
                        }

                        if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                        {
                            if (Result_Management(out_node) == false)
                            {
                                return false;
                            }
                        }
                    }

                    if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                    {
                        MPCR.ShowSuccessMsg(out_node);
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

        // Result_Management()
        //       - Manage result of data collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Collect_EDC_Data_Out As SPC_Collect_EDC_Data_Out_Tag
        //
        private bool Result_Management(TRSNode out_node)
        {

            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    this.tabResource.SelectedTab = this.tbpCollectData;
                    frmConfirmCollectData f = new frmConfirmCollectData();
                    FarPoint.Win.Spread.FpSpread temp_object = f.spdResult;
                    View_Result(temp_object, out_node);
                    f.ShowDialog(this);

                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Data Commit
                        //OOC History Insert
                        if (Sub_Resource_Event('4') == false)
                        {
                            return false;
                        }
                        //Data Change
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        spdData.Select();
                        return false;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        spdData.Select();
                        return false;
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

        // View_Result()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - 寃곌낵 ?쒖떆 ?ㅽ봽?덈뱶
        //       - ByVal Result_Out._C As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?쒓렇
        //       - ByVal c_step As String
        //
        public void View_Result(FarPoint.Win.Spread.FpSpread spdResult, TRSNode out_node)
        {
            int i, j;
            TRSNode unit_list;
            try
            {
                MPCF.ClearList(spdResult, true);

                for (i = 0; i < out_node.GetList("CHAR_LIST").Count; i++)
                {
                    for (j = 0; j < out_node.GetList("CHAR_LIST")[i].GetList("UNIT_LIST").Count; j++)
                    {
                        unit_list = out_node.GetList("CHAR_LIST")[i].GetList("UNIT_LIST")[j];
                        if (unit_list.GetChar("SPEC_OUT_TYPE") == ' ')
                        {

                        }
                        else
                        {
                            spdResult.Sheets[0].RowCount++;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_SEQ].Value = j + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_CHAR].Value = out_node.GetList("CHAR_LIST")[i].GetString("CHAR_ID");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_UNIT_ID].Value = unit_list.GetString("UNIT_ID");

                            if (unit_list.GetChar("SPEC_OUT_TYPE") == 'W')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOW";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('W', out_node);
                            }
                            else if (unit_list.GetChar("SPEC_OUT_TYPE") == 'S')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOS";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('S', out_node);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool View_Sub_Resource()
        {
            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_OUT");
            try
            {
                //FieldClear(Me, cdvSubResID, cdvEventID, txtEventDesc, txtChangeUpDown)

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SUBRES_ID", cdvSubResID.Text);

                if (MPCR.CallService("RAS", "RAS_View_Sub_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = MPCF.Trim(out_node.GetString("SUBRES_DESC"));
                txtResourceType.Text = MPCF.Trim(out_node.GetString("SUBRES_TYPE"));
                if (MPCF.Trim(out_node.GetChar("SUBRES_UP_DOWN_FLAG")) == "U")
                {
                    txtCurrentUpDown.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("SUBRES_UP_DOWN_FLAG")) == "D")
                {
                    txtCurrentUpDown.Text = "DOWN";
                }

                txtLastEvent.Text = MPCF.Trim(out_node.GetString("LAST_EVENT_ID"));
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_EVENT_TIME"));

                txtCurrentStatus1.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_1"));
                txtCurrentStatus2.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_2"));
                txtCurrentStatus3.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_3"));
                txtCurrentStatus4.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_4"));
                txtCurrentStatus5.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_5"));
                txtCurrentStatus6.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_6"));
                txtCurrentStatus7.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_7"));
                txtCurrentStatus8.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_8"));
                txtCurrentStatus9.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_9"));
                txtCurrentStatus10.Text = MPCF.Trim(out_node.GetString("SUBRES_STS_10"));
                txtPrimaryCurrent.Text = MPCF.Trim(out_node.GetString("SUBRES_PRI_STS"));

                if (out_node.GetChar("USE_FAC_PRT_FLAG") != 'Y')
                {
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_1")) != "")
                    {
                        lblCurrentStatus1.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                        lblCurrentStatus1.Visible = true;
                        txtCurrentStatus1.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus1.Visible = false;
                        txtCurrentStatus1.Visible = false;
                        cdvChangeStatus1.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_2")) != "")
                    {
                        lblCurrentStatus2.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                        lblCurrentStatus2.Visible = true;
                        txtCurrentStatus2.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus2.Visible = false;
                        txtCurrentStatus2.Visible = false;
                        cdvChangeStatus2.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_3")) != "")
                    {
                        lblCurrentStatus3.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                        lblCurrentStatus3.Visible = true;
                        txtCurrentStatus3.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus3.Visible = false;
                        txtCurrentStatus3.Visible = false;
                        cdvChangeStatus3.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_4")) != "")
                    {
                        lblCurrentStatus4.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                        lblCurrentStatus4.Visible = true;
                        txtCurrentStatus4.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus4.Visible = false;
                        txtCurrentStatus4.Visible = false;
                        cdvChangeStatus4.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_5")) != "")
                    {
                        lblCurrentStatus5.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                        lblCurrentStatus5.Visible = true;
                        txtCurrentStatus5.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus5.Visible = false;
                        txtCurrentStatus5.Visible = false;
                        cdvChangeStatus5.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_6")) != "")
                    {
                        lblCurrentStatus6.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                        lblCurrentStatus6.Visible = true;
                        txtCurrentStatus6.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus6.Visible = false;
                        txtCurrentStatus6.Visible = false;
                        cdvChangeStatus6.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_7")) != "")
                    {
                        lblCurrentStatus7.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                        lblCurrentStatus7.Visible = true;
                        txtCurrentStatus7.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus7.Visible = false;
                        txtCurrentStatus7.Visible = false;
                        cdvChangeStatus7.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_8")) != "")
                    {
                        lblCurrentStatus8.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                        lblCurrentStatus8.Visible = true;
                        txtCurrentStatus8.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus8.Visible = false;
                        txtCurrentStatus8.Visible = false;
                        cdvChangeStatus8.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_9")) != "")
                    {
                        lblCurrentStatus9.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                        lblCurrentStatus9.Visible = true;
                        txtCurrentStatus9.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus9.Visible = false;
                        txtCurrentStatus9.Visible = false;
                        cdvChangeStatus9.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_10")) != "")
                    {
                        lblCurrentStatus10.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
                        lblCurrentStatus10.Visible = true;
                        txtCurrentStatus10.Visible = true;
                    }
                    else
                    {
                        lblCurrentStatus10.Visible = false;
                        txtCurrentStatus10.Visible = false;
                        cdvChangeStatus10.Visible = false;
                    }
                }
                else
                {
                    View_Factory_ResStatus();
                }

                txtLocation.Text = MPCF.Trim(out_node.GetString("SUBRES_LOCATION"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool View_Event(char ProcStep)
        {


            TRSNode in_node = new TRSNode("VIEW_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_OUT");
            DateTime ThisMoment = DateTime.Now;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("EVENT_ID", cdvEventID.Text);

            if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {
                return false;
            }

            if (MPCF.Trim(out_node.GetString("COL_SET_ID")) != "")
            {
                txtColSet.Text = out_node.GetString("COL_SET_ID");
#if _EDC
                char temp_string = 'R';
                int iVer = 0;
                if (MPCR.FindColSetVersion('1', txtColSet.Text, ref iVer, "", "", 0, "", "", "", temp_string, spdData, false, 'Y') == false)
                {
                    // 에러가있더라도아래내용을계속수행
                    //return false;
                }
                else
                {
                    txtColSetVersion.Text = iVer.ToString();
                }
#endif
            }

            txtChangeUpDown.Visible = true;
            if (out_node.GetChar("CHG_UP_DOWN_FLAG") == CHANGE)
            {
                if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "U")
                {
                    txtChangeUpDown.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "D")
                {
                    txtChangeUpDown.Text = "DOWN";
                }
            }
            else
            {
                txtChangeUpDown.Text = txtCurrentUpDown.Text;
            }
            if (out_node.GetChar("CHG_PRI_STS_FLAG") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_PRI_STS")) != "")
                {
                    cdvPrimaryChange.VisibleButton = true;
                    cdvPrimaryChange.Tag = out_node.GetString("TBL_PRI_STS");
                }
                else
                {
                    cdvPrimaryChange.VisibleButton = false;
                }
                cdvPrimaryChange.Visible = true;
                cdvPrimaryChange.Text = out_node.GetString("CHG_PRI_STS");
                cdvPrimaryChange.ReadOnly = false;
                cdvPrimaryChange.BackColor = SystemColors.Window;
            }
            else
            {
                cdvPrimaryChange.Visible = true;
                cdvPrimaryChange.VisibleButton = false;
                cdvPrimaryChange.ReadOnly = true;
                cdvPrimaryChange.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_PRI_STS_FLAG") == CHANGE)
                {
                    cdvPrimaryChange.Text = out_node.GetString("CHG_PRI_STS");
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == INCREASE)
                {
                    cdvPrimaryChange.Text = Convert.ToString((MPCF.ToDbl(txtPrimaryCurrent.Text) + MPCF.ToDbl(out_node.GetString("CHG_PRI_STS"))));
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == DECREASE)
                {
                    cdvPrimaryChange.Text = Convert.ToString((MPCF.ToDbl(txtPrimaryCurrent.Text) - MPCF.ToDbl(out_node.GetString("CHG_PRI_STS"))));
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == NOTCHANGE)
                {
                    cdvPrimaryChange.Text = txtPrimaryCurrent.Text;
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == TIME)
                {
                    cdvPrimaryChange.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }
            if (lblCurrentStatus1.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_1") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_1")) != "")
                    {
                        cdvChangeStatus1.VisibleButton = true;
                        cdvChangeStatus1.Tag = out_node.GetString("TBL_1");
                    }
                    else
                    {
                        cdvChangeStatus1.VisibleButton = false;
                    }
                    cdvChangeStatus1.Visible = true;
                    cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    cdvChangeStatus1.ReadOnly = false;
                    cdvChangeStatus1.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus1.Visible = true;
                    cdvChangeStatus1.VisibleButton = false;
                    cdvChangeStatus1.ReadOnly = true;
                    cdvChangeStatus1.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_1") == CHANGE)
                    {
                        cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    }
                    else if (out_node.GetChar("CHG_FLAG_1") == INCREASE)
                    {
                        cdvChangeStatus1.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus1.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_1"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_1") == DECREASE)
                    {
                        cdvChangeStatus1.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus1.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_1"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_1") == NOTCHANGE)
                    {
                        cdvChangeStatus1.Text = txtCurrentStatus1.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_1") == TIME)
                    {
                        cdvChangeStatus1.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus2.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_2") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_2")) != "")
                    {
                        cdvChangeStatus2.VisibleButton = true;
                        cdvChangeStatus2.Tag = out_node.GetString("TBL_2");
                    }
                    else
                    {
                        cdvChangeStatus2.VisibleButton = false;
                    }
                    cdvChangeStatus2.Visible = true;
                    cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    cdvChangeStatus2.ReadOnly = false;
                    cdvChangeStatus2.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus2.Visible = true;
                    cdvChangeStatus2.VisibleButton = false;
                    cdvChangeStatus2.ReadOnly = true;
                    cdvChangeStatus2.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_2") == CHANGE)
                    {
                        cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    }
                    else if (out_node.GetChar("CHG_FLAG_2") == INCREASE)
                    {
                        cdvChangeStatus2.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus2.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_2"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_2") == DECREASE)
                    {
                        cdvChangeStatus2.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus2.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_2"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_2") == NOTCHANGE)
                    {
                        cdvChangeStatus2.Text = txtCurrentStatus2.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_2") == TIME)
                    {
                        cdvChangeStatus2.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus3.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_3") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_3")) != "")
                    {
                        cdvChangeStatus3.VisibleButton = true;
                        cdvChangeStatus3.Tag = out_node.GetString("TBL_3");
                    }
                    else
                    {
                        cdvChangeStatus3.VisibleButton = false;
                    }
                    cdvChangeStatus3.Visible = true;
                    cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    cdvChangeStatus3.ReadOnly = false;
                    cdvChangeStatus3.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus3.Visible = true;
                    cdvChangeStatus3.VisibleButton = false;
                    cdvChangeStatus3.ReadOnly = true;
                    cdvChangeStatus3.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_3") == CHANGE)
                    {
                        cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    }
                    else if (out_node.GetChar("CHG_FLAG_3") == INCREASE)
                    {
                        cdvChangeStatus3.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus3.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_3"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_3") == DECREASE)
                    {
                        cdvChangeStatus3.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus3.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_3"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_3") == NOTCHANGE)
                    {
                        cdvChangeStatus3.Text = txtCurrentStatus3.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_3") == TIME)
                    {
                        cdvChangeStatus3.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus4.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_4") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_4")) != "")
                    {
                        cdvChangeStatus4.VisibleButton = true;
                        cdvChangeStatus4.Tag = out_node.GetString("TBL_4");
                    }
                    else
                    {
                        cdvChangeStatus4.VisibleButton = false;
                    }
                    cdvChangeStatus4.Visible = true;
                    cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    cdvChangeStatus4.ReadOnly = false;
                    cdvChangeStatus4.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus4.Visible = true;
                    cdvChangeStatus4.VisibleButton = false;
                    cdvChangeStatus4.ReadOnly = true;
                    cdvChangeStatus4.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_4") == CHANGE)
                    {
                        cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    }
                    else if (out_node.GetChar("CHG_FLAG_4") == INCREASE)
                    {
                        cdvChangeStatus4.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus4.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_4"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_4") == DECREASE)
                    {
                        cdvChangeStatus4.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus4.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_4"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_4") == NOTCHANGE)
                    {
                        cdvChangeStatus4.Text = txtCurrentStatus4.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_4") == TIME)
                    {
                        cdvChangeStatus4.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus5.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_5") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_5")) != "")
                    {
                        cdvChangeStatus5.VisibleButton = true;
                        cdvChangeStatus5.Tag = out_node.GetString("TBL_5");
                    }
                    else
                    {
                        cdvChangeStatus5.VisibleButton = false;
                    }
                    cdvChangeStatus5.Visible = true;
                    cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    cdvChangeStatus5.ReadOnly = false;
                    cdvChangeStatus5.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus5.Visible = true;
                    cdvChangeStatus5.VisibleButton = false;
                    cdvChangeStatus5.ReadOnly = true;
                    cdvChangeStatus5.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_5") == CHANGE)
                    {
                        cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    }
                    else if (out_node.GetChar("CHG_FLAG_5") == INCREASE)
                    {
                        cdvChangeStatus5.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus5.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_5"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_5") == DECREASE)
                    {
                        cdvChangeStatus5.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus5.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_5"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_5") == NOTCHANGE)
                    {
                        cdvChangeStatus5.Text = txtCurrentStatus5.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_5") == TIME)
                    {
                        cdvChangeStatus5.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus6.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_6") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_6")) != "")
                    {
                        cdvChangeStatus6.VisibleButton = true;
                        cdvChangeStatus6.Tag = out_node.GetString("TBL_6");
                    }
                    else
                    {
                        cdvChangeStatus6.VisibleButton = false;
                    }
                    cdvChangeStatus6.Visible = true;
                    cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    cdvChangeStatus6.ReadOnly = false;
                    cdvChangeStatus6.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus6.Visible = true;
                    cdvChangeStatus6.VisibleButton = false;
                    cdvChangeStatus6.ReadOnly = true;
                    cdvChangeStatus6.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_6") == CHANGE)
                    {
                        cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    }
                    else if (out_node.GetChar("CHG_FLAG_6") == INCREASE)
                    {
                        cdvChangeStatus6.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus6.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_6"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_6") == DECREASE)
                    {
                        cdvChangeStatus6.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus6.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_6"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_6") == NOTCHANGE)
                    {
                        cdvChangeStatus6.Text = txtCurrentStatus6.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_6") == TIME)
                    {
                        cdvChangeStatus6.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus7.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_7") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_7")) != "")
                    {
                        cdvChangeStatus7.VisibleButton = true;
                        cdvChangeStatus7.Tag = out_node.GetString("TBL_7");
                    }
                    else
                    {
                        cdvChangeStatus7.VisibleButton = false;
                    }
                    cdvChangeStatus7.Visible = true;
                    cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    cdvChangeStatus7.ReadOnly = false;
                    cdvChangeStatus7.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus7.Visible = true;
                    cdvChangeStatus7.VisibleButton = false;
                    cdvChangeStatus7.ReadOnly = true;
                    cdvChangeStatus7.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_7") == CHANGE)
                    {
                        cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    }
                    else if (out_node.GetChar("CHG_FLAG_7") == INCREASE)
                    {
                        cdvChangeStatus7.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus7.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_7"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_7") == DECREASE)
                    {
                        cdvChangeStatus7.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus7.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_7"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_7") == NOTCHANGE)
                    {
                        cdvChangeStatus7.Text = txtCurrentStatus7.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_7") == TIME)
                    {
                        cdvChangeStatus7.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus8.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_8") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_8")) != "")
                    {
                        cdvChangeStatus8.VisibleButton = true;
                        cdvChangeStatus8.Tag = out_node.GetString("TBL_8");
                    }
                    else
                    {
                        cdvChangeStatus8.VisibleButton = false;
                    }
                    cdvChangeStatus8.Visible = true;
                    cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    cdvChangeStatus8.ReadOnly = false;
                    cdvChangeStatus8.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus8.Visible = true;
                    cdvChangeStatus8.VisibleButton = false;
                    cdvChangeStatus8.ReadOnly = true;
                    cdvChangeStatus8.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_8") == CHANGE)
                    {
                        cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    }
                    else if (out_node.GetChar("CHG_FLAG_8") == INCREASE)
                    {
                        cdvChangeStatus8.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus8.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_8"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_8") == DECREASE)
                    {
                        cdvChangeStatus8.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus8.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_8"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_8") == NOTCHANGE)
                    {
                        cdvChangeStatus8.Text = txtCurrentStatus8.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_8") == TIME)
                    {
                        cdvChangeStatus8.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus9.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_9") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_9")) != "")
                    {
                        cdvChangeStatus9.VisibleButton = true;
                        cdvChangeStatus9.Tag = out_node.GetString("TBL_9");
                    }
                    else
                    {
                        cdvChangeStatus9.VisibleButton = false;
                    }
                    cdvChangeStatus9.Visible = true;
                    cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    cdvChangeStatus9.ReadOnly = false;
                    cdvChangeStatus9.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus9.Visible = true;
                    cdvChangeStatus9.VisibleButton = false;
                    cdvChangeStatus9.ReadOnly = true;
                    cdvChangeStatus9.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_9") == CHANGE)
                    {
                        cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    }
                    else if (out_node.GetChar("CHG_FLAG_9") == INCREASE)
                    {
                        cdvChangeStatus9.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus9.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_9"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_9") == DECREASE)
                    {
                        cdvChangeStatus9.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus9.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_9"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_9") == NOTCHANGE)
                    {
                        cdvChangeStatus9.Text = txtCurrentStatus9.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_9") == TIME)
                    {
                        cdvChangeStatus9.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }
            if (lblCurrentStatus10.Visible == true)
            {
                if (out_node.GetChar("CHG_FLAG_10") == OVERRIDE)
                {
                    if (MPCF.Trim(out_node.GetString("TBL_10")) != "")
                    {
                        cdvChangeStatus10.VisibleButton = true;
                        cdvChangeStatus10.Tag = out_node.GetString("TBL_10");
                    }
                    else
                    {
                        cdvChangeStatus10.VisibleButton = false;
                    }
                    cdvChangeStatus10.Visible = true;
                    cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    cdvChangeStatus10.ReadOnly = false;
                    cdvChangeStatus10.BackColor = SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus10.Visible = true;
                    cdvChangeStatus10.VisibleButton = false;
                    cdvChangeStatus10.ReadOnly = true;
                    cdvChangeStatus10.BackColor = SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_10") == CHANGE)
                    {
                        cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    }
                    else if (out_node.GetChar("CHG_FLAG_10") == INCREASE)
                    {
                        cdvChangeStatus10.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus10.Text) + MPCF.ToDbl(out_node.GetString("CHG_STS_10"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_10") == DECREASE)
                    {
                        cdvChangeStatus10.Text = Convert.ToString((MPCF.ToDbl(txtCurrentStatus10.Text) - MPCF.ToDbl(out_node.GetString("CHG_STS_10"))));
                    }
                    else if (out_node.GetChar("CHG_FLAG_10") == NOTCHANGE)
                    {
                        cdvChangeStatus10.Text = txtCurrentStatus10.Text;
                    }
                    else if (out_node.GetChar("CHG_FLAG_10") == TIME)
                    {
                        cdvChangeStatus10.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }
                }
            }

            return true;

        }

    
    // View_Factory_ResStatus()
    //       -  View Factory Resource Status Prompt
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       -
        private bool View_Factory_ResStatus()
        {
            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("RES_STS_1")) != "")
                {
                    lblCurrentStatus1.Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                    lblCurrentStatus1.Visible = true;
                    txtCurrentStatus1.Visible = true;
                }
                else
                {
                    lblCurrentStatus1.Visible = false;
                    txtCurrentStatus1.Visible = false;
                    cdvChangeStatus1.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_2")) != "")
                {
                    lblCurrentStatus2.Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                    lblCurrentStatus2.Visible = true;
                    txtCurrentStatus2.Visible = true;
                }
                else
                {
                    lblCurrentStatus2.Visible = false;
                    txtCurrentStatus2.Visible = false;
                    cdvChangeStatus2.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_3")) != "")
                {
                    lblCurrentStatus3.Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                    lblCurrentStatus3.Visible = true;
                    txtCurrentStatus3.Visible = true;
                }
                else
                {
                    lblCurrentStatus3.Visible = false;
                    txtCurrentStatus3.Visible = false;
                    cdvChangeStatus3.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_4")) != "")
                {
                    lblCurrentStatus4.Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                    lblCurrentStatus4.Visible = true;
                    txtCurrentStatus4.Visible = true;
                }
                else
                {
                    lblCurrentStatus4.Visible = false;
                    txtCurrentStatus4.Visible = false;
                    cdvChangeStatus4.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_5")) != "")
                {
                    lblCurrentStatus5.Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                    lblCurrentStatus5.Visible = true;
                    txtCurrentStatus5.Visible = true;
                }
                else
                {
                    lblCurrentStatus5.Visible = false;
                    txtCurrentStatus5.Visible = false;
                    cdvChangeStatus5.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_6")) != "")
                {
                    lblCurrentStatus6.Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                    lblCurrentStatus6.Visible = true;
                    txtCurrentStatus6.Visible = true;
                }
                else
                {
                    lblCurrentStatus6.Visible = false;
                    txtCurrentStatus6.Visible = false;
                    cdvChangeStatus6.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_7")) != "")
                {
                    lblCurrentStatus7.Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                    lblCurrentStatus7.Visible = true;
                    txtCurrentStatus7.Visible = true;
                }
                else
                {
                    lblCurrentStatus7.Visible = false;
                    txtCurrentStatus7.Visible = false;
                    cdvChangeStatus7.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_8")) != "")
                {
                    lblCurrentStatus8.Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                    lblCurrentStatus8.Visible = true;
                    txtCurrentStatus8.Visible = true;
                }
                else
                {
                    lblCurrentStatus8.Visible = false;
                    txtCurrentStatus8.Visible = false;
                    cdvChangeStatus8.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_9")) != "")
                {
                    lblCurrentStatus9.Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                    lblCurrentStatus9.Visible = true;
                    txtCurrentStatus9.Visible = true;
                }
                else
                {
                    lblCurrentStatus9.Visible = false;
                    txtCurrentStatus9.Visible = false;
                    cdvChangeStatus9.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_10")) != "")
                {
                    lblCurrentStatus10.Text = MPCF.Trim(out_node.GetString("RES_STS_10"));
                    lblCurrentStatus10.Visible = true;
                    txtCurrentStatus10.Visible = true;
                }
                else
                {
                    lblCurrentStatus10.Visible = false;
                    txtCurrentStatus10.Visible = false;
                    cdvChangeStatus10.Visible = false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

    
    private void ChangeStatusClear()
    {
        txtChangeUpDown.Text = "";
        cdvPrimaryChange.Text = "";
        cdvChangeStatus1.Text = "";
        cdvChangeStatus2.Text = "";
        cdvChangeStatus3.Text = "";
        cdvChangeStatus4.Text = "";
        cdvChangeStatus5.Text = "";
        cdvChangeStatus6.Text = "";
        cdvChangeStatus7.Text = "";
        cdvChangeStatus8.Text = "";
        cdvChangeStatus9.Text = "";
        cdvChangeStatus10.Text = "";
    }
    
    private void ChangeFieldVisible()
    {
        txtChangeUpDown.Visible = false;
        cdvPrimaryChange.Visible = false;
        cdvChangeStatus1.Visible = false;
        cdvChangeStatus2.Visible = false;
        cdvChangeStatus3.Visible = false;
        cdvChangeStatus4.Visible = false;
        cdvChangeStatus5.Visible = false;
        cdvChangeStatus6.Visible = false;
        cdvChangeStatus7.Visible = false;
        cdvChangeStatus8.Visible = false;
        cdvChangeStatus9.Visible = false;
        cdvChangeStatus10.Visible = false;
    }
    
    private void InitCodeView()
    {
        
        if (cdvResID.DisplaySubItemIndex != cdvResID.SelectedSubItemIndex)
        {
            cdvResID_ButtonPress(null, null);
        }
        
        cdvSubResID.DisplaySubItemIndex = 0;
        cdvPrimaryChange.DisplaySubItemIndex = 0;
        cdvChangeStatus1.DisplaySubItemIndex = 0;
        cdvChangeStatus2.DisplaySubItemIndex = 0;
        cdvChangeStatus3.DisplaySubItemIndex = 0;
        cdvChangeStatus4.DisplaySubItemIndex = 0;
        cdvChangeStatus5.DisplaySubItemIndex = 0;
        cdvChangeStatus6.DisplaySubItemIndex = 0;
        cdvChangeStatus7.DisplaySubItemIndex = 0;
        cdvChangeStatus8.DisplaySubItemIndex = 0;
        cdvChangeStatus9.DisplaySubItemIndex = 0;
        cdvChangeStatus10.DisplaySubItemIndex = 0;
        
        cdvPrimaryChange.SelectedSubItemIndex = 0;
        cdvChangeStatus1.SelectedSubItemIndex = 0;
        cdvChangeStatus2.SelectedSubItemIndex = 0;
        cdvChangeStatus3.SelectedSubItemIndex = 0;
        cdvChangeStatus4.SelectedSubItemIndex = 0;
        cdvChangeStatus5.SelectedSubItemIndex = 0;
        cdvChangeStatus6.SelectedSubItemIndex = 0;
        cdvChangeStatus7.SelectedSubItemIndex = 0;
        cdvChangeStatus8.SelectedSubItemIndex = 0;
        cdvChangeStatus9.SelectedSubItemIndex = 0;
        cdvChangeStatus10.SelectedSubItemIndex = 0;
        
    }
    
    public virtual Control GetFisrtFocusItem()
    {
        
        try
        {
            return this.cdvResID;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return null;
        }
        
    }

    public void SetSubResourceId(string s_res_id, string s_sub_res_id)
    {
        s_cur_res_id = s_res_id;
        s_cur_sub_res_id = s_sub_res_id;
    }
    #endregion
    
    private void cdvSubResID_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        
        if (e.KeyChar == (char)13)
        {
            //Call View Resource Function
            View_Sub_Resource();
        }
        
    }
    
    private void frmRASTranEvent_Load(object sender, System.EventArgs e)
    {
        pnlTranTime.Visible = MPGO.UseBackDate();
        dtpTranDate.Enabled = chkTranDateTime.Checked;
        dtpTranTime.Enabled = chkTranDateTime.Checked;
        
    }
    
    private void frmRASTranEvent_Activated(object sender, System.EventArgs e)
    {
        try
        {
            //dtpTransTime = Now
            if (LoadFlag == false)
            {
                MPCF.FieldVisible(grpCurrentStatus, false, lblUpDown, lblPrimaryStatus, txtCurrentUpDown, txtPrimaryCurrent, null);
                ClearData('1');
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_EVENT, "lblCMF", "cdvCMF", grpCMF);
                InitCodeView();
                
                if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                {
                    cdvResID.Text = MPGV.gsCurrentRes_ID;
                    //View_Sub_Resource()
                }

                if (MPCF.Trim(s_cur_sub_res_id) != "")
                {
                    cdvResID.Text = s_cur_res_id;
                    cdvSubResID.Text = s_cur_sub_res_id;
                    cdvSubResID_SelectedItemChanged(null, null);
                }

                LoadFlag = true;
            }
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void frmRASTranEvent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            //Call View Resource Function
            View_Sub_Resource();
            RASLIST.ViewResEventList(cdvEventID, '1', cdvSubResID.Text, null, "");
        }
    }
    
    private void btnProcess_Click(System.Object sender, System.EventArgs e)
    {
        //Call Resource Event Function
        if (CheckCondition("Collect_Res_Data") == true)
        {
            if (Sub_Resource_Event('1') == true)
            {
                View_Sub_Resource();
                View_Event('1');
            }
        }
    }
    
    private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvEventID.Init();
        MPCF.InitListView(cdvEventID.GetListView);
        cdvEventID.Columns.Add("Event", 50, HorizontalAlignment.Left);
        cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvEventID.SelectedSubItemIndex = 0;
        RASLIST.ViewSubResEventList(cdvEventID.GetListView, '1', cdvResID.Text, cdvSubResID.Text, null, "");
    }
    
    private void cdvSubResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        ClearData('1');
        ChangeFieldVisible();
        cdvEventID.Init();
        View_Sub_Resource();
    }
    
    private void cdvSubResID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
    {
        ClearData('1');
        cdvEventID.Init();
    }
    
    private void cdvEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        ChangeStatusClear();
        MPCF.FieldClear(grpCol);
        MPCF.ClearList(spdData, true);
        View_Event('1');
        //View_Sub_Resource()
    }
    
    
    private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
    {
        MPCR.ProcGRPCMFButtonPress(sender);
    }
    
    private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        MPCR.CheckCMFKeyPress(sender, e);
    }
    
    private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        
        txtTranDateTime.Visible = ! chkTranDateTime.Checked;
        
        dtpTranDate.Enabled = chkTranDateTime.Checked;
        dtpTranTime.Enabled = chkTranDateTime.Checked;
        
    }
    
    private void cdvPrimaryChange_ButtonPress(System.Object sender, System.EventArgs e)
    {
        Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
        
        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
        
        cdvTemp.Init();
        MPCF.InitListView(cdvTemp.GetListView);
        cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
        cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvTemp.SelectedSubItemIndex = 0;
        BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));
        
    }
    
    private void cdvSubResID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvSubResID.Init();
        MPCF.InitListView(cdvSubResID.GetListView);
        cdvSubResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvSubResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvSubResID.SelectedSubItemIndex = 0;
        int temp_int = 0;

        RASLIST.ViewSubResourceList(cdvSubResID.GetListView, '5', cdvResID.Text, MPGV.gsFactory, "", "", false, null, ref temp_int);
    }
    
    private void cdvResID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvResID.Init();
        MPCF.InitListView(cdvResID.GetListView);
        cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
        cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvResID.SelectedSubItemIndex = 0;
        RASLIST.ViewResourceList(cdvResID.GetListView, false);
    }

        private void cdvEventID_TextBoxTextChanged(object sender, EventArgs e)
        {
            ChangeStatusClear();
            MPCF.FieldClear(grpCol);
            MPCF.ClearList(spdData, true);
        }
}

}
