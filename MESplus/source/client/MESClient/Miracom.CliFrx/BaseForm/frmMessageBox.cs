
using System.Data;
using System.Collections;
using System.Diagnostics;
using System;
using System.Windows.Forms;


namespace Miracom.CliFrx
{
    public class frmMessageBox : System.Windows.Forms.Form
    {

        #region " Windows Form 디자이너에서 생성한 코드 "

        public frmMessageBox()
        {

            //이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            
            //Init()
            //InitializeComponent()를 호출한 다음에 초기화 작업을 추가하십시오.
            
        }

        //Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

        private System.ComponentModel.IContainer components;

        //Windows Form 디자이너에 필요합니다.
        
        //참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
        //Windows Form 디자이너를 사용하여 수정할 수 있습니다.  
        //코드 편집기를 사용하여 수정하지 마십시오.
        private System.Windows.Forms.Panel pnlDetailMsg;
        private System.Windows.Forms.Panel pnlMsgTop;
        private System.Windows.Forms.Panel pnlRetryCancel;
        private System.Windows.Forms.Button btnRetryCancelCancel;
        private System.Windows.Forms.Button btnRetryCancelRetry;
        private System.Windows.Forms.Panel pnlAbortRetryIgnore;
        private System.Windows.Forms.Button btnAbortRetryIgnoreIgnore;
        private System.Windows.Forms.Button btnAbortRetryIgnoreRetry;
        private System.Windows.Forms.Button btnAbortRetryIgnoreAbort;
        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Button btnOKOK;
        private System.Windows.Forms.Panel pnlOKCancel;
        private System.Windows.Forms.Button btnOKCancelCancel;
        private System.Windows.Forms.Button btnOKCancelOK;
        private System.Windows.Forms.Panel pnlYesNoCancel;
        private System.Windows.Forms.Button btnYesNoCancelCancel;
        private System.Windows.Forms.Button btnYesNoCancelNo;
        private System.Windows.Forms.Button btnYesNoCancelYes;
        private System.Windows.Forms.Panel pnlYesNo;
        private System.Windows.Forms.Button btnYesNoNo;
        private System.Windows.Forms.Button btnYesNoYes;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.Button btnSimple;
        private ToolTip tltMessage;
        private Button btnWDetail;
        private Miracom.UI.Controls.MCListView.MCListView lisDetailMsg;
        private ColumnHeader colName;
        private ColumnHeader colValue;
        protected Button btnExcel;
        private PictureBox picWarning;
        private PictureBox picError;
        private System.Windows.Forms.Label Label1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
            this.pnlDetailMsg = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lisDetailMsg = new Miracom.UI.Controls.MCListView.MCListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMsgTop = new System.Windows.Forms.Panel();
            this.pnlRetryCancel = new System.Windows.Forms.Panel();
            this.btnRetryCancelCancel = new System.Windows.Forms.Button();
            this.btnRetryCancelRetry = new System.Windows.Forms.Button();
            this.pnlAbortRetryIgnore = new System.Windows.Forms.Panel();
            this.btnAbortRetryIgnoreIgnore = new System.Windows.Forms.Button();
            this.btnAbortRetryIgnoreRetry = new System.Windows.Forms.Button();
            this.btnAbortRetryIgnoreAbort = new System.Windows.Forms.Button();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.btnOKOK = new System.Windows.Forms.Button();
            this.pnlOKCancel = new System.Windows.Forms.Panel();
            this.btnOKCancelCancel = new System.Windows.Forms.Button();
            this.btnOKCancelOK = new System.Windows.Forms.Button();
            this.pnlYesNoCancel = new System.Windows.Forms.Panel();
            this.btnYesNoCancelCancel = new System.Windows.Forms.Button();
            this.btnYesNoCancelNo = new System.Windows.Forms.Button();
            this.btnYesNoCancelYes = new System.Windows.Forms.Button();
            this.pnlYesNo = new System.Windows.Forms.Panel();
            this.btnYesNoNo = new System.Windows.Forms.Button();
            this.btnYesNoYes = new System.Windows.Forms.Button();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnSimple = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.picWarning = new System.Windows.Forms.PictureBox();
            this.picError = new System.Windows.Forms.PictureBox();
            this.btnWDetail = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.tltMessage = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDetailMsg.SuspendLayout();
            this.pnlMsgTop.SuspendLayout();
            this.pnlRetryCancel.SuspendLayout();
            this.pnlAbortRetryIgnore.SuspendLayout();
            this.pnlOK.SuspendLayout();
            this.pnlOKCancel.SuspendLayout();
            this.pnlYesNoCancel.SuspendLayout();
            this.pnlYesNo.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetailMsg
            // 
            this.pnlDetailMsg.Controls.Add(this.btnExcel);
            this.pnlDetailMsg.Controls.Add(this.lisDetailMsg);
            this.pnlDetailMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailMsg.Location = new System.Drawing.Point(0, 98);
            this.pnlDetailMsg.Name = "pnlDetailMsg";
            this.pnlDetailMsg.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDetailMsg.Size = new System.Drawing.Size(522, 127);
            this.pnlDetailMsg.TabIndex = 1;
            this.pnlDetailMsg.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(429, 100);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lisDetailMsg
            // 
            this.lisDetailMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.lisDetailMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisDetailMsg.EnableSort = true;
            this.lisDetailMsg.EnableSortIcon = true;
            this.lisDetailMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDetailMsg.FullRowSelect = true;
            this.lisDetailMsg.Location = new System.Drawing.Point(3, 3);
            this.lisDetailMsg.MultiSelect = false;
            this.lisDetailMsg.Name = "lisDetailMsg";
            this.lisDetailMsg.Size = new System.Drawing.Size(421, 121);
            this.lisDetailMsg.TabIndex = 2;
            this.lisDetailMsg.UseCompatibleStateImageBehavior = false;
            this.lisDetailMsg.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 200;
            // 
            // pnlMsgTop
            // 
            this.pnlMsgTop.Controls.Add(this.pnlRetryCancel);
            this.pnlMsgTop.Controls.Add(this.pnlAbortRetryIgnore);
            this.pnlMsgTop.Controls.Add(this.pnlOK);
            this.pnlMsgTop.Controls.Add(this.pnlOKCancel);
            this.pnlMsgTop.Controls.Add(this.pnlYesNoCancel);
            this.pnlMsgTop.Controls.Add(this.pnlYesNo);
            this.pnlMsgTop.Controls.Add(this.pnlMessage);
            this.pnlMsgTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsgTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMsgTop.Name = "pnlMsgTop";
            this.pnlMsgTop.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnlMsgTop.Size = new System.Drawing.Size(522, 98);
            this.pnlMsgTop.TabIndex = 0;
            // 
            // pnlRetryCancel
            // 
            this.pnlRetryCancel.Controls.Add(this.btnRetryCancelCancel);
            this.pnlRetryCancel.Controls.Add(this.btnRetryCancelRetry);
            this.pnlRetryCancel.Location = new System.Drawing.Point(620, 1);
            this.pnlRetryCancel.Name = "pnlRetryCancel";
            this.pnlRetryCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlRetryCancel.TabIndex = 3;
            // 
            // btnRetryCancelCancel
            // 
            this.btnRetryCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRetryCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetryCancelCancel.Location = new System.Drawing.Point(5, 35);
            this.btnRetryCancelCancel.Name = "btnRetryCancelCancel";
            this.btnRetryCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnRetryCancelCancel.TabIndex = 1;
            this.btnRetryCancelCancel.Text = "Cancel";
            this.btnRetryCancelCancel.Click += new System.EventHandler(this.btnRetryCancelCancel_Click);
            // 
            // btnRetryCancelRetry
            // 
            this.btnRetryCancelRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetryCancelRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetryCancelRetry.Location = new System.Drawing.Point(5, 5);
            this.btnRetryCancelRetry.Name = "btnRetryCancelRetry";
            this.btnRetryCancelRetry.Size = new System.Drawing.Size(88, 26);
            this.btnRetryCancelRetry.TabIndex = 0;
            this.btnRetryCancelRetry.Text = "Retry";
            this.btnRetryCancelRetry.Click += new System.EventHandler(this.btnRetryCancelRetry_Click);
            // 
            // pnlAbortRetryIgnore
            // 
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreIgnore);
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreRetry);
            this.pnlAbortRetryIgnore.Controls.Add(this.btnAbortRetryIgnoreAbort);
            this.pnlAbortRetryIgnore.Location = new System.Drawing.Point(718, 1);
            this.pnlAbortRetryIgnore.Name = "pnlAbortRetryIgnore";
            this.pnlAbortRetryIgnore.Size = new System.Drawing.Size(98, 96);
            this.pnlAbortRetryIgnore.TabIndex = 4;
            // 
            // btnAbortRetryIgnoreIgnore
            // 
            this.btnAbortRetryIgnoreIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnAbortRetryIgnoreIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreIgnore.Location = new System.Drawing.Point(5, 65);
            this.btnAbortRetryIgnoreIgnore.Name = "btnAbortRetryIgnoreIgnore";
            this.btnAbortRetryIgnoreIgnore.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreIgnore.TabIndex = 2;
            this.btnAbortRetryIgnoreIgnore.Text = "Ignore";
            this.btnAbortRetryIgnoreIgnore.Click += new System.EventHandler(this.btnAbortRetryIgnoreIgnore_Click);
            // 
            // btnAbortRetryIgnoreRetry
            // 
            this.btnAbortRetryIgnoreRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnAbortRetryIgnoreRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreRetry.Location = new System.Drawing.Point(5, 35);
            this.btnAbortRetryIgnoreRetry.Name = "btnAbortRetryIgnoreRetry";
            this.btnAbortRetryIgnoreRetry.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreRetry.TabIndex = 1;
            this.btnAbortRetryIgnoreRetry.Text = "Retry";
            this.btnAbortRetryIgnoreRetry.Click += new System.EventHandler(this.btnAbortRetryIgnoreRetry_Click);
            // 
            // btnAbortRetryIgnoreAbort
            // 
            this.btnAbortRetryIgnoreAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbortRetryIgnoreAbort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAbortRetryIgnoreAbort.Location = new System.Drawing.Point(5, 5);
            this.btnAbortRetryIgnoreAbort.Name = "btnAbortRetryIgnoreAbort";
            this.btnAbortRetryIgnoreAbort.Size = new System.Drawing.Size(88, 26);
            this.btnAbortRetryIgnoreAbort.TabIndex = 0;
            this.btnAbortRetryIgnoreAbort.Text = "Abort";
            this.btnAbortRetryIgnoreAbort.Click += new System.EventHandler(this.btnAbortRetryIgnoreAbort_Click);
            // 
            // pnlOK
            // 
            this.pnlOK.Controls.Add(this.btnOKOK);
            this.pnlOK.Location = new System.Drawing.Point(914, 1);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(98, 96);
            this.pnlOK.TabIndex = 6;
            // 
            // btnOKOK
            // 
            this.btnOKOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKOK.Location = new System.Drawing.Point(5, 5);
            this.btnOKOK.Name = "btnOKOK";
            this.btnOKOK.Size = new System.Drawing.Size(88, 26);
            this.btnOKOK.TabIndex = 0;
            this.btnOKOK.Text = "OK";
            this.btnOKOK.Click += new System.EventHandler(this.btnOKOK_Click);
            // 
            // pnlOKCancel
            // 
            this.pnlOKCancel.Controls.Add(this.btnOKCancelCancel);
            this.pnlOKCancel.Controls.Add(this.btnOKCancelOK);
            this.pnlOKCancel.Location = new System.Drawing.Point(816, 1);
            this.pnlOKCancel.Name = "pnlOKCancel";
            this.pnlOKCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlOKCancel.TabIndex = 5;
            // 
            // btnOKCancelCancel
            // 
            this.btnOKCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOKCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKCancelCancel.Location = new System.Drawing.Point(5, 35);
            this.btnOKCancelCancel.Name = "btnOKCancelCancel";
            this.btnOKCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnOKCancelCancel.TabIndex = 1;
            this.btnOKCancelCancel.Text = "Cancel";
            this.btnOKCancelCancel.Click += new System.EventHandler(this.btnOKCancelCancel_Click);
            // 
            // btnOKCancelOK
            // 
            this.btnOKCancelOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKCancelOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKCancelOK.Location = new System.Drawing.Point(5, 5);
            this.btnOKCancelOK.Name = "btnOKCancelOK";
            this.btnOKCancelOK.Size = new System.Drawing.Size(88, 26);
            this.btnOKCancelOK.TabIndex = 0;
            this.btnOKCancelOK.Text = "OK";
            this.btnOKCancelOK.Click += new System.EventHandler(this.btnOKCancelOK_Click);
            // 
            // pnlYesNoCancel
            // 
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelCancel);
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelNo);
            this.pnlYesNoCancel.Controls.Add(this.btnYesNoCancelYes);
            this.pnlYesNoCancel.Location = new System.Drawing.Point(522, 1);
            this.pnlYesNoCancel.Name = "pnlYesNoCancel";
            this.pnlYesNoCancel.Size = new System.Drawing.Size(98, 96);
            this.pnlYesNoCancel.TabIndex = 2;
            // 
            // btnYesNoCancelCancel
            // 
            this.btnYesNoCancelCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnYesNoCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelCancel.Location = new System.Drawing.Point(5, 65);
            this.btnYesNoCancelCancel.Name = "btnYesNoCancelCancel";
            this.btnYesNoCancelCancel.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelCancel.TabIndex = 0;
            this.btnYesNoCancelCancel.Text = "Cancel";
            this.btnYesNoCancelCancel.Click += new System.EventHandler(this.btnYesNoCancelCancel_Click);
            // 
            // btnYesNoCancelNo
            // 
            this.btnYesNoCancelNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnYesNoCancelNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelNo.Location = new System.Drawing.Point(5, 35);
            this.btnYesNoCancelNo.Name = "btnYesNoCancelNo";
            this.btnYesNoCancelNo.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelNo.TabIndex = 2;
            this.btnYesNoCancelNo.Text = "No";
            this.btnYesNoCancelNo.Click += new System.EventHandler(this.btnYesNoCancelNo_Click);
            // 
            // btnYesNoCancelYes
            // 
            this.btnYesNoCancelYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYesNoCancelYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoCancelYes.Location = new System.Drawing.Point(5, 5);
            this.btnYesNoCancelYes.Name = "btnYesNoCancelYes";
            this.btnYesNoCancelYes.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoCancelYes.TabIndex = 1;
            this.btnYesNoCancelYes.Text = "Yes";
            this.btnYesNoCancelYes.Click += new System.EventHandler(this.btnYesNoCancelYes_Click);
            // 
            // pnlYesNo
            // 
            this.pnlYesNo.Controls.Add(this.btnYesNoNo);
            this.pnlYesNo.Controls.Add(this.btnYesNoYes);
            this.pnlYesNo.Location = new System.Drawing.Point(424, 1);
            this.pnlYesNo.Name = "pnlYesNo";
            this.pnlYesNo.Size = new System.Drawing.Size(98, 96);
            this.pnlYesNo.TabIndex = 0;
            // 
            // btnYesNoNo
            // 
            this.btnYesNoNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnYesNoNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoNo.Location = new System.Drawing.Point(5, 35);
            this.btnYesNoNo.Name = "btnYesNoNo";
            this.btnYesNoNo.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoNo.TabIndex = 1;
            this.btnYesNoNo.Text = "No";
            this.btnYesNoNo.Click += new System.EventHandler(this.btnYesNoNo_Click);
            // 
            // btnYesNoYes
            // 
            this.btnYesNoYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYesNoYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYesNoYes.Location = new System.Drawing.Point(5, 5);
            this.btnYesNoYes.Name = "btnYesNoYes";
            this.btnYesNoYes.Size = new System.Drawing.Size(88, 26);
            this.btnYesNoYes.TabIndex = 0;
            this.btnYesNoYes.Text = "Yes";
            this.btnYesNoYes.Click += new System.EventHandler(this.btnYesNoYes_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.btnDetail);
            this.pnlMessage.Controls.Add(this.btnSimple);
            this.pnlMessage.Controls.Add(this.btnCopy);
            this.pnlMessage.Controls.Add(this.grpMessage);
            this.pnlMessage.Controls.Add(this.Label1);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMessage.Location = new System.Drawing.Point(0, 3);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMessage.Size = new System.Drawing.Size(424, 92);
            this.pnlMessage.TabIndex = 1;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(381, 62);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(16, 22);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.TabStop = false;
            this.btnDetail.Tag = "VIEW";
            this.tltMessage.SetToolTip(this.btnDetail, "Expand field message");
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnSimple
            // 
            this.btnSimple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimple.Enabled = false;
            this.btnSimple.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSimple.Image = ((System.Drawing.Image)(resources.GetObject("btnSimple.Image")));
            this.btnSimple.Location = new System.Drawing.Point(381, 62);
            this.btnSimple.Name = "btnSimple";
            this.btnSimple.Size = new System.Drawing.Size(16, 22);
            this.btnSimple.TabIndex = 0;
            this.btnSimple.TabStop = false;
            this.btnSimple.Tag = "VIEW";
            this.tltMessage.SetToolTip(this.btnSimple, "Collapse field message");
            this.btnSimple.Visible = false;
            this.btnSimple.Click += new System.EventHandler(this.btnSimple_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.SystemColors.Control;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(398, 62);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(21, 22);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TabStop = false;
            this.btnCopy.Tag = "";
            this.tltMessage.SetToolTip(this.btnCopy, "Copy message");
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.picWarning);
            this.grpMessage.Controls.Add(this.picError);
            this.grpMessage.Controls.Add(this.btnWDetail);
            this.grpMessage.Controls.Add(this.lblMessage);
            this.grpMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMessage.Location = new System.Drawing.Point(3, -6);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(421, 96);
            this.grpMessage.TabIndex = 0;
            this.grpMessage.TabStop = false;
            // 
            // picWarning
            // 
            this.picWarning.ErrorImage = null;
            this.picWarning.Image = ((System.Drawing.Image)(resources.GetObject("picWarning.Image")));
            this.picWarning.Location = new System.Drawing.Point(3, 31);
            this.picWarning.Name = "picWarning";
            this.picWarning.Size = new System.Drawing.Size(40, 40);
            this.picWarning.TabIndex = 4;
            this.picWarning.TabStop = false;
            // 
            // picError
            // 
            this.picError.ErrorImage = null;
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(3, 31);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(40, 40);
            this.picError.TabIndex = 3;
            this.picError.TabStop = false;
            // 
            // btnWDetail
            // 
            this.btnWDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWDetail.Location = new System.Drawing.Point(361, 68);
            this.btnWDetail.Name = "btnWDetail";
            this.btnWDetail.Size = new System.Drawing.Size(16, 22);
            this.btnWDetail.TabIndex = 2;
            this.btnWDetail.TabStop = false;
            this.btnWDetail.Tag = "VIEW";
            this.btnWDetail.Text = "W";
            this.tltMessage.SetToolTip(this.btnWDetail, "Expand warning message");
            this.btnWDetail.Visible = false;
            this.btnWDetail.Click += new System.EventHandler(this.btnWDetail_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(39, 13);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(355, 77);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Location = new System.Drawing.Point(3, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(418, 86);
            this.Label1.TabIndex = 1;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tltMessage
            // 
            this.tltMessage.AutomaticDelay = 200;
            // 
            // frmMessageBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 225);
            this.Controls.Add(this.pnlDetailMsg);
            this.Controls.Add(this.pnlMsgTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MESplus";
            this.Closed += new System.EventHandler(this.frmMessageBox_Closed);
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            this.pnlDetailMsg.ResumeLayout(false);
            this.pnlMsgTop.ResumeLayout(false);
            this.pnlRetryCancel.ResumeLayout(false);
            this.pnlAbortRetryIgnore.ResumeLayout(false);
            this.pnlOK.ResumeLayout(false);
            this.pnlOKCancel.ResumeLayout(false);
            this.pnlYesNoCancel.ResumeLayout(false);
            this.pnlYesNo.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private const int MSG_BOX_HEIGHT = 128;
        private const int MSG_BOX_DETAIL_HEIGHT = 130;
        //private bool bShowDetailOutMsg = false;
        
        #endregion
        
        #region " Function Implementations"

        private void ShowButtonStyle(MessageBoxButtons btnStyle, int iDefaultFocus)
        {

            try
            {
                pnlOK.Dock = DockStyle.None;
                pnlOKCancel.Dock = DockStyle.None;
                pnlYesNo.Dock = DockStyle.None;
                pnlYesNoCancel.Dock = DockStyle.None;
                pnlRetryCancel.Dock = DockStyle.None;
                pnlAbortRetryIgnore.Dock = DockStyle.None;

                pnlOK.Visible = false;
                pnlOKCancel.Visible = false;
                pnlYesNo.Visible = false;
                pnlYesNoCancel.Visible = false;
                pnlRetryCancel.Visible = false;
                pnlAbortRetryIgnore.Visible = false;

                //Button Show
                switch (btnStyle)
                {
                    case MessageBoxButtons.OK:

                        pnlOK.Visible = true;
                        pnlOK.Dock = DockStyle.Fill;
                        btnOKOK.Select();
                        break;
                    case MessageBoxButtons.OKCancel:

                        pnlOKCancel.Visible = true;
                        pnlOKCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnOKCancelOK.TabIndex = 0;
                                btnOKCancelCancel.TabIndex = 1;
                                btnOKCancelOK.Select();
                                break;
                            case 2:

                                btnOKCancelOK.TabIndex = 1;
                                btnOKCancelCancel.TabIndex = 0;
                                btnOKCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.YesNo:

                        pnlYesNo.Visible = true;
                        pnlYesNo.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnYesNoYes.TabIndex = 0;
                                btnYesNoNo.TabIndex = 1;
                                btnYesNoYes.Select();
                                break;
                            case 2:

                                btnYesNoNo.TabIndex = 1;
                                btnYesNoYes.TabIndex = 0;
                                btnYesNoNo.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.YesNoCancel:

                        pnlYesNoCancel.Visible = true;
                        pnlYesNoCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnYesNoCancelYes.TabIndex = 0;
                                btnYesNoCancelNo.TabIndex = 1;
                                btnYesNoCancelCancel.TabIndex = 2;
                                btnYesNoCancelYes.Select();
                                break;
                            case 2:

                                btnYesNoCancelYes.TabIndex = 2;
                                btnYesNoCancelNo.TabIndex = 0;
                                btnYesNoCancelCancel.TabIndex = 1;
                                btnYesNoCancelNo.Select();
                                break;
                            case 3:

                                btnYesNoCancelYes.TabIndex = 1;
                                btnYesNoCancelNo.TabIndex = 2;
                                btnYesNoCancelCancel.TabIndex = 0;
                                btnYesNoCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.RetryCancel:

                        pnlRetryCancel.Visible = true;
                        pnlRetryCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnRetryCancelRetry.TabIndex = 0;
                                btnRetryCancelCancel.TabIndex = 1;
                                btnRetryCancelRetry.Select();
                                break;
                            case 2:

                                btnRetryCancelRetry.TabIndex = 1;
                                btnRetryCancelCancel.TabIndex = 0;
                                btnRetryCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:

                        pnlAbortRetryIgnore.Visible = true;
                        pnlAbortRetryIgnore.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnAbortRetryIgnoreAbort.TabIndex = 0;
                                btnAbortRetryIgnoreRetry.TabIndex = 1;
                                btnAbortRetryIgnoreIgnore.TabIndex = 2;
                                btnAbortRetryIgnoreAbort.Select();
                                break;
                            case 2:

                                btnAbortRetryIgnoreAbort.TabIndex = 2;
                                btnAbortRetryIgnoreRetry.TabIndex = 0;
                                btnAbortRetryIgnoreIgnore.TabIndex = 1;
                                btnAbortRetryIgnoreRetry.Select();
                                break;
                            case 3:

                                btnAbortRetryIgnoreAbort.TabIndex = 1;
                                btnAbortRetryIgnoreRetry.TabIndex = 2;
                                btnAbortRetryIgnoreIgnore.TabIndex = 0;
                                btnAbortRetryIgnoreIgnore.Select();
                                break;
                        }
                        break;
                    default:

                        break;
                }

                this.Height = MSG_BOX_HEIGHT;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.ShowButtonStyle()\n" + ex.Message);
                return;
            }
        }

        // Show()
        //       - Set sMessage Box Option
        // Return Value
        //       - System.Windows.Forms.DialogResult
        // Arguments
        //       - ByVal sMessage As String
        //       - Optional ByVal sCaption As String = ""
        //       - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //       - Optional ByVal iDefaultFocus As Integer = 1
        //
        public System.Windows.Forms.DialogResult Show(string sMessage, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus)
        {
            return Show(sMessage, sCaption, btnStyle, iDefaultFocus, null);
        }

        // Show()
        //       - Set sMessage Box Option
        // Return Value
        //       - System.Windows.Forms.DialogResult
        // Arguments
        //       - ByVal sMessage As String
        //       - Optional ByVal sCaption As String = ""
        //       - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //       - Optional ByVal iDefaultFocus As Integer = 1
        //
        public System.Windows.Forms.DialogResult Show(string sMessage, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner)
        {
            
            try
            {
                ShowButtonStyle(btnStyle, iDefaultFocus);

                picError.Visible = false;
                picWarning.Visible = false;
                lblMessage.Dock = DockStyle.Fill;

                //sMessage Show
                lblMessage.Text = sMessage;
                btnDetail.Visible = false;
                this.Text = sCaption;
                
                this.StartPosition = FormStartPosition.CenterParent;
                
                if (owner == null)
                {
                    return this.ShowDialog();
                }
                else
                {
                    return this.ShowDialog(owner);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.Show()\n" + ex.Message);
                return System.Windows.Forms.DialogResult.None;
            }
            
        }

         //Show()
         //      - Set sMessage Box Option
         //Return Value
         //      - System.Windows.Forms.DialogResult
         //Arguments
         //      - ByVal MsgString As clsMsgString
         //      - Optional ByVal sCaption As String = ""
         //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
         //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus)
        {
            return Show(MsgString, sCaption, btnStyle, iDefaultFocus, null, false);
        }

        //Show()
        //      - Set sMessage Box Option
        //Return Value
        //      - System.Windows.Forms.DialogResult
        //Arguments
        //      - ByVal MsgString As clsMsgString
        //      - Optional ByVal sCaption As String = ""
        //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner)
        {
            return Show(MsgString, sCaption, btnStyle, iDefaultFocus, owner, false);
        }
        
        //Show()
         //      - Set sMessage Box Option
         //Return Value
         //      - System.Windows.Forms.DialogResult
         //Arguments
         //      - ByVal MsgString As clsMsgString
         //      - Optional ByVal sCaption As String = ""
         //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
         //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner, bool isShowWarning)
        {
            try
            {
                int i, k;
                ListViewItem itmX;
                int i_temp_1, i_temp_2;
                int i_step = 0;
                int iStartIndex;
                int iEndIndex;
                string sFieldMsg = "";
                string sMsg = "";
                   
                MPCF.InitListView(lisDetailMsg);
                
                ShowButtonStyle(btnStyle, iDefaultFocus);
                
                //sMessage Show
                lblMessage.Text = MPCF.Trim(MsgString.ErrorMsg);

                switch (MsgString.MsgBoxIconType)
                {
                    case MSGBOX_ICON_TYPE.WARNING:
                        picError.Visible = false;
                        picWarning.Visible = true;
                        lblMessage.Dock = DockStyle.None;
                        break;

                    case MSGBOX_ICON_TYPE.ERROR:
                        picError.Visible = true;
                        picWarning.Visible = false;
                        lblMessage.Dock = DockStyle.None;
                        break;

                    case MSGBOX_ICON_TYPE.NONE:
                        picError.Visible = false;
                        picWarning.Visible = false;
                        lblMessage.Dock = DockStyle.Fill;
                        break;
                    
                    default:
                        picError.Visible = false;
                        picWarning.Visible = false;
                        lblMessage.Dock = DockStyle.Fill;
                        break;
                }
                
                this.Text = sCaption;
                if (MsgString.MsgCode.Trim() != "")
                {
                    this.Text += " [" + MsgString.MsgCode.Trim() + "]";
                }
                
                if (MsgString.DBErrorMsg.Trim() != "" || MsgString.FieldMsg.Count > 0)
                {
                    sFieldMsg = "";
                    sMsg = "";

                    btnDetail.Visible = true;
                    
                    if (MsgString.FieldMsg.Count > 0)
                    {
                        for (i = 0; i < MsgString.FieldMsg.Count; i++)
                        {
                            if (MsgString.IsNodeMsgFlag == false)
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[i]);
                                iStartIndex = 0;
                                iEndIndex = sFieldMsg.IndexOf(":");
                                if (iEndIndex >= 0)
                                {
                                    sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex) + 1);
                                    if (sMsg.Trim() != "")
                                    {
                                        itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        lisDetailMsg.Items.Add(itmX);
                                    }
                                }
                                while (true)
                                {
                                    if (i_step == 1)
                                    {
                                        iStartIndex = iEndIndex + 2;
                                    }
                                    else
                                    {
                                        iStartIndex = iEndIndex + 1;
                                    }
                                    
                                    if (iStartIndex >= sFieldMsg.Length)
                                    {
                                        break;
                                    }
                                    i_temp_1 = sFieldMsg.IndexOf("=", iStartIndex);
                                    i_temp_2 = sFieldMsg.IndexOf("]", iStartIndex);
                                    if (i_temp_1 < i_temp_2)
                                    {
                                        iEndIndex = i_temp_1;
                                        i_step = 1;
                                    }
                                    else
                                    {
                                        iEndIndex = i_temp_2;
                                        i_step = 2;
                                    }
                                    
                                    if (iEndIndex >= iStartIndex)
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                        if (sMsg.Trim() != "")
                                        {
                                            if (i_step == 1)
                                            {
                                                itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                                itmX.SubItems.Add("");
                                                lisDetailMsg.Items.Add(itmX);
                                            }
                                            else 
                                            {
                                                lisDetailMsg.Items[lisDetailMsg.Items.Count - 1].SubItems[1].Text = sMsg.Trim();
                                                
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (sFieldMsg.Length - iStartIndex));
                                        if (sMsg.Trim() != "")
                                        {
                                            itmX = new ListViewItem("");
                                            itmX.SubItems.Add(sMsg.Trim());
                                            lisDetailMsg.Items.Add(itmX);
                                        }
                                        break;
                                    }
                                   
                                }
                            }
                            else
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[i]);
                                iStartIndex = 0;
                                
                                iEndIndex = sFieldMsg.IndexOf("=", iStartIndex);
                                if (iEndIndex > 0)
                                {
                                    sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                    itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    iStartIndex = sFieldMsg.IndexOf("[")+1;
                                    iEndIndex = sFieldMsg.IndexOf("]", iStartIndex);
                                    if (iEndIndex > 0)
                                    {
                                        itmX.SubItems.Add(sFieldMsg.Substring(iStartIndex, iEndIndex - iStartIndex));
                                        lisDetailMsg.Items.Add(itmX);
                                    }

                                }
                                else
                                {
                                    itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    itmX.SubItems.Add("");
                                    lisDetailMsg.Items.Add(itmX);
                                }
                                
                           
                                
                            }
                        }
                    }
                }
                else
                {
                    btnDetail.Visible = false;
                }

                if (MsgString.DBErrorMsg.Trim() != "")
                {
                    itmX = new ListViewItem(MsgString.DBErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                    itmX.SubItems.Add("");
                    lisDetailMsg.Items.Add(itmX);

                }

                if (MsgString.OutNode.Count > 0)
                {
                    string s_item_name;
                    string s_lot_id = "";
                    btnDetail.Visible = true;
                    for (i = 0; i < MsgString.OutNode.Count; i++)
                    {
                        if (i > 0)
                        {
                            s_lot_id = MPCF.Trim(MsgString.OutNode[i].GetString("LOT_ID"));
                            if (MPCF.Trim(s_lot_id) != "")
                            {
                                s_lot_id += " : ";
                            }
                        }

                        for (k = 0; k < MsgString.OutNode[i].MemberCount; k++)
                        {
                            s_item_name = MsgString.OutNode[i].GetMember(k).Name;
                            itmX = new ListViewItem(s_lot_id + s_item_name, (int)SMALLICON_INDEX.IDX_MODULE);

                            itmX.SubItems.Add(MPCF.Trim(MsgString.OutNode[i].GetMember(k).Value));
                            lisDetailMsg.Items.Add(itmX);
                        }
                    }

                }

                if (isShowWarning == true)
                {
                    if (MPGV.gaWarningMsg.Count > 0)
                    {
                        sFieldMsg = "";

                        btnWDetail.Visible = true;
                        
                        for (i = 0; i < MPGV.gaWarningMsg.Count; i++)
                        {
                            MsgString = (ReturnMessageString)MPGV.gaWarningMsg[i];

                            itmX = new ListViewItem(MsgString.ErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                            itmX.SubItems.Add("");
                            lisDetailMsg.Items.Add(itmX);

                            if (MsgString.DBErrorMsg != "")
                            {
                                itmX = new ListViewItem(MsgString.DBErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                                itmX.SubItems.Add("");
                                lisDetailMsg.Items.Add(itmX);
                            }
                            for (k = 0; k < MsgString.FieldMsg.Count; k++)
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[k]);
                                iStartIndex = 0;
                                if (k == 0)
                                {
                                    itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    itmX.SubItems.Add("");
                                    lisDetailMsg.Items.Add(itmX);
                                }
                                else
                                {
                                    iEndIndex = sFieldMsg.IndexOf("=", iStartIndex);
                                    if (iEndIndex > 0)
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                        itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        iStartIndex = sFieldMsg.IndexOf("[") + 1;
                                        iEndIndex = sFieldMsg.IndexOf("]", iStartIndex);
                                        if (iEndIndex > 0)
                                        {
                                            itmX.SubItems.Add(sFieldMsg.Substring(iStartIndex, iEndIndex - iStartIndex));
                                            lisDetailMsg.Items.Add(itmX);
                                        }

                                    }
                                    else
                                    {
                                        itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        itmX.SubItems.Add("");
                                        lisDetailMsg.Items.Add(itmX);
                                    }

                                }
                            }
                        }                        
                    }
                }

                MPCF.FitColumnHeader(lisDetailMsg);
                
                this.StartPosition = FormStartPosition.CenterParent;
                
                if (owner == null)
                {
                    return this.ShowDialog();
                }
                else
                {
                    return this.ShowDialog(owner);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.Show()\n" + ex.Message + "\n" + ex.StackTrace);
                return System.Windows.Forms.DialogResult.None;
            }
        }
        
        #endregion
        
        
        private void frmMessageBox_Load(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                btnYesNoYes.Font = new System.Drawing.Font(btnYesNoYes.Font.Name, MPGV.giMessageSize);
                btnYesNoNo.Font = new System.Drawing.Font(btnYesNoNo.Font.Name, MPGV.giMessageSize);
                btnOKCancelOK.Font = new System.Drawing.Font(btnOKCancelOK.Font.Name, MPGV.giMessageSize);
                btnOKCancelCancel.Font = new System.Drawing.Font(btnOKCancelCancel.Font.Name, MPGV.giMessageSize);
                btnOKOK.Font = new System.Drawing.Font(btnOKOK.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelYes.Font = new System.Drawing.Font(btnYesNoCancelYes.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelNo.Font = new System.Drawing.Font(btnYesNoCancelNo.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelCancel.Font = new System.Drawing.Font(btnYesNoCancelCancel.Font.Name, MPGV.giMessageSize);
                
                lblMessage.Font = new System.Drawing.Font(lblMessage.Font.Name, MPGV.giMessageSize);

                this.Height = MSG_BOX_HEIGHT;
                MPCF.ToClientLanguage(this);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.frmMessageBox_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnOKOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnOKOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnOKCancelOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnOKCancelOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnOKCancelCancel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnOKCancelCancel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnYesNoCancelCancel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnYesNoCancelCancel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRetryCancelCancel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnRetryCancelCancel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnYesNoYes_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnYesNoYes_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnYesNoCancelYes_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnYesNoCancelYes_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnYesNoNo_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnYesNoNo_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnYesNoCancelNo_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnYesNoCancelNo_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRetryCancelRetry_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnRetryCancelRetry_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnAbortRetryIgnoreAbort_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnAbortRetryIgnoreAbort_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnAbortRetryIgnoreRetry_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnAbortRetryIgnoreRetry_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnAbortRetryIgnoreIgnore_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnAbortRetryIgnoreIgnore_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDetail_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                btnSimple.Visible = true;
                btnSimple.Enabled = true;
                btnDetail.Visible = false;
                btnDetail.Enabled = false;

                pnlDetailMsg.Visible = true;
                                
                this.Height = MSG_BOX_HEIGHT + MSG_BOX_DETAIL_HEIGHT;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnDetail_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnSimple_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                btnSimple.Visible = false;
                btnSimple.Enabled = false;
                btnDetail.Visible = true;
                btnDetail.Enabled = true;
                
                pnlDetailMsg.Visible = false;
                this.Height = MSG_BOX_HEIGHT;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnSimple_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Clipboard.SetDataObject(lblMessage.Text, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.btnCopy_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmMessageBox_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                //this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.frmMessageBox_Closed()\n" + ex.Message);
            }
            
        }
        
        private void btnWDetail_Click(object sender, EventArgs e)
        {
            if (pnlDetailMsg.Visible == false)
            {
                pnlDetailMsg.Visible = true;
                this.Height = MSG_BOX_HEIGHT + MSG_BOX_DETAIL_HEIGHT;
            }
            else
            {
                pnlDetailMsg.Visible = false;
                this.Height = MSG_BOX_HEIGHT;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisDetailMsg, lblMessage.Text, "");
        }
        
    }
    
}
