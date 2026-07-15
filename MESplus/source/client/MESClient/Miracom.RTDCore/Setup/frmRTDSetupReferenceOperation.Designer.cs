namespace Miracom.RTDCore
{
    partial class frmRTDSetupReferenceOperation
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.udcMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpOper = new System.Windows.Forms.GroupBox();
            this.cdvRefOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOper = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCreateInfo.SuspendLayout();
            this.grpOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRefOper)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpOper);
            this.pnlRight.Controls.Add(this.grpCreateInfo);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.udcMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // udcMFO
            // 
            this.udcMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMFO.IncludeFlowSeqNum = false;
            this.udcMFO.ListCond_ExtFactory = "";
            this.udcMFO.ListCond_Step = '1';
            this.udcMFO.Location = new System.Drawing.Point(3, 0);
            this.udcMFO.MaterialType = "";
            this.udcMFO.Name = "udcMFO";
            this.udcMFO.Size = new System.Drawing.Size(226, 506);
            this.udcMFO.TabIndex = 0;
            this.udcMFO.VisibleLevel1MFO = true;
            this.udcMFO.VisibleLevel2FO = true;
            this.udcMFO.VisibleLevel3O = true;
            this.udcMFO.VisibleLevel4MO = true;
            this.udcMFO.VisibleLevel5MF = false;
            this.udcMFO.VisibleLevel6M = false;
            this.udcMFO.VisibleLevel7F = false;
            this.udcMFO.VisibleLevel8Factory = false;
            this.udcMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.udcMFO.VisibleMaterialType = false;
            this.udcMFO.VisibleOnlySetData = true;
            this.udcMFO.VisibleViewType = true;
            this.udcMFO.AfterGetTree += new System.EventHandler(this.udcMFO_AfterGetTree);
            this.udcMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_AfterSelect);
            this.udcMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_LevelItemSelect);
            this.udcMFO.GetOnlySetData += new System.EventHandler(this.udcMFO_GetOnlySetData);
            this.udcMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.udcMFO_SetDataSelectedIndexChanged);
            this.udcMFO.SelectLevelChanged += new System.EventHandler(this.udcMFO_SelectLevelChanged);
            // 
            // grpCreateInfo
            // 
            this.grpCreateInfo.Controls.Add(this.txtUpdateTime);
            this.grpCreateInfo.Controls.Add(this.txtCreateTime);
            this.grpCreateInfo.Controls.Add(this.txtUpdateUser);
            this.grpCreateInfo.Controls.Add(this.lblUpdate);
            this.grpCreateInfo.Controls.Add(this.txtCreateUser);
            this.grpCreateInfo.Controls.Add(this.lblCreate);
            this.grpCreateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCreateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateInfo.Location = new System.Drawing.Point(0, 436);
            this.grpCreateInfo.Name = "grpCreateInfo";
            this.grpCreateInfo.Size = new System.Drawing.Size(506, 70);
            this.grpCreateInfo.TabIndex = 1;
            this.grpCreateInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(306, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(126, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(126, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpOper
            // 
            this.grpOper.Controls.Add(this.cdvRefOper);
            this.grpOper.Controls.Add(this.lblOper);
            this.grpOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOper.Location = new System.Drawing.Point(0, 0);
            this.grpOper.Name = "grpOper";
            this.grpOper.Size = new System.Drawing.Size(506, 436);
            this.grpOper.TabIndex = 0;
            this.grpOper.TabStop = false;
            // 
            // cdvRefOper
            // 
            this.cdvRefOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRefOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRefOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRefOper.BtnToolTipText = "";
            this.cdvRefOper.DescText = "";
            this.cdvRefOper.DisplaySubItemIndex = -1;
            this.cdvRefOper.DisplayText = "";
            this.cdvRefOper.Focusing = null;
            this.cdvRefOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRefOper.Index = 0;
            this.cdvRefOper.IsViewBtnImage = false;
            this.cdvRefOper.Location = new System.Drawing.Point(188, 38);
            this.cdvRefOper.MaxLength = 20;
            this.cdvRefOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRefOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRefOper.Name = "cdvRefOper";
            this.cdvRefOper.ReadOnly = false;
            this.cdvRefOper.SearchSubItemIndex = 0;
            this.cdvRefOper.SelectedDescIndex = -1;
            this.cdvRefOper.SelectedSubItemIndex = -1;
            this.cdvRefOper.SelectionStart = 0;
            this.cdvRefOper.Size = new System.Drawing.Size(200, 20);
            this.cdvRefOper.SmallImageList = null;
            this.cdvRefOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRefOper.TabIndex = 1;
            this.cdvRefOper.TextBoxToolTipText = "";
            this.cdvRefOper.TextBoxWidth = 200;
            this.cdvRefOper.VisibleButton = true;
            this.cdvRefOper.VisibleColumnHeader = false;
            this.cdvRefOper.VisibleDescription = false;
            this.cdvRefOper.ButtonPress += new System.EventHandler(this.cdvRefOper_ButtonPress);
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOper.Location = new System.Drawing.Point(18, 41);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(125, 13);
            this.lblOper.TabIndex = 0;
            this.lblOper.Text = "Reference Operation";
            this.lblOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmRTDSetupReferenceOperation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRTDSetupReferenceOperation";
            this.Text = "Reference Operation Setup";
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
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.grpOper.ResumeLayout(false);
            this.grpOper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRefOper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList udcMFO;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grpOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRefOper;
        private System.Windows.Forms.Label lblOper;
    }
}
