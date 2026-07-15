
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupOperation.vb
//   Description : Operation Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-20 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public class frmSetupFavorites : Miracom.CliFrx.BaseForm04
    {

        #region " Windows Form 디자이너에서 생성한 코드 "

        public frmSetupFavorites()
        {

            //이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

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

        //Windows Form 디자이너에 필요합니다.
        private System.ComponentModel.Container components = null;
        
        //참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
        //Windows Form 디자이너를 사용하여 수정할 수 있습니다.  
        //코드 편집기를 사용하여 수정하지 마십시오.
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Panel pnlFavoBottom;
        private System.Windows.Forms.Panel pnlFavoMid;
        private Miracom.UI.Controls.MCListView.MCListView lisFavorites;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.GroupBox grpAvailFunc;
        private System.Windows.Forms.GroupBox grpSelectedFunc;
        private System.Windows.Forms.Button btnAlias;
        private Miracom.UI.Controls.MCListView.MCListView lisAvailFuncList;
        private System.Windows.Forms.ColumnHeader colFuncText;
        private System.Windows.Forms.ColumnHeader colFuncDesc;
        private System.Windows.Forms.ColumnHeader colFuncText1;
        private System.Windows.Forms.ColumnHeader colFuncDesc1;
        private System.Windows.Forms.Panel pnlMidMid;
        private System.Windows.Forms.Button btnAttach;
        private Panel panel1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPgmID;
        private Label lblProgramID;
        private Panel pnlFuncRightTop;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFGroup;
        private Label lblFGroup;
        private System.Windows.Forms.Button btnDetach;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetupFavorites));
            this.pnlMid = new System.Windows.Forms.Panel();
            this.pnlMidMid = new System.Windows.Forms.Panel();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.grpAvailFunc = new System.Windows.Forms.GroupBox();
            this.lisAvailFuncList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colFuncText1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncDesc1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFuncRightTop = new System.Windows.Forms.Panel();
            this.cdvFGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFGroup = new System.Windows.Forms.Label();
            this.grpSelectedFunc = new System.Windows.Forms.GroupBox();
            this.pnlFavoMid = new System.Windows.Forms.Panel();
            this.lisFavorites = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdvPgmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProgramID = new System.Windows.Forms.Label();
            this.pnlFavoBottom = new System.Windows.Forms.Panel();
            this.btnAlias = new System.Windows.Forms.Button();
            this.lblAlias = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.pnlMidMid.SuspendLayout();
            this.grpAvailFunc.SuspendLayout();
            this.pnlFuncRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).BeginInit();
            this.grpSelectedFunc.SuspendLayout();
            this.pnlFavoMid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPgmID)).BeginInit();
            this.pnlFavoBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 509);
            this.pnlBottom.Size = new System.Drawing.Size(742, 37);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Favorites Setup";
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.pnlMidMid);
            this.pnlMid.Controls.Add(this.grpAvailFunc);
            this.pnlMid.Controls.Add(this.grpSelectedFunc);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.pnlMid.Size = new System.Drawing.Size(742, 509);
            this.pnlMid.TabIndex = 0;
            this.pnlMid.Resize += new System.EventHandler(this.pnlMid_Resize);
            // 
            // pnlMidMid
            // 
            this.pnlMidMid.Controls.Add(this.btnAttach);
            this.pnlMidMid.Controls.Add(this.btnDetach);
            this.pnlMidMid.Location = new System.Drawing.Point(370, 96);
            this.pnlMidMid.Name = "pnlMidMid";
            this.pnlMidMid.Size = new System.Drawing.Size(44, 146);
            this.pnlMidMid.TabIndex = 1;
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Location = new System.Drawing.Point(10, 47);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Location = new System.Drawing.Point(10, 76);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 1;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // grpAvailFunc
            // 
            this.grpAvailFunc.Controls.Add(this.lisAvailFuncList);
            this.grpAvailFunc.Controls.Add(this.pnlFuncRightTop);
            this.grpAvailFunc.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpAvailFunc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAvailFunc.Location = new System.Drawing.Point(441, 4);
            this.grpAvailFunc.Name = "grpAvailFunc";
            this.grpAvailFunc.Size = new System.Drawing.Size(299, 503);
            this.grpAvailFunc.TabIndex = 1;
            this.grpAvailFunc.TabStop = false;
            this.grpAvailFunc.Text = "Available Function List";
            // 
            // lisAvailFuncList
            // 
            this.lisAvailFuncList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFuncText1,
            this.colFuncDesc1});
            this.lisAvailFuncList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAvailFuncList.EnableSort = true;
            this.lisAvailFuncList.EnableSortIcon = true;
            this.lisAvailFuncList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAvailFuncList.FullRowSelect = true;
            this.lisAvailFuncList.HideSelection = false;
            this.lisAvailFuncList.Location = new System.Drawing.Point(3, 44);
            this.lisAvailFuncList.Name = "lisAvailFuncList";
            this.lisAvailFuncList.Size = new System.Drawing.Size(293, 456);
            this.lisAvailFuncList.TabIndex = 1;
            this.lisAvailFuncList.UseCompatibleStateImageBehavior = false;
            this.lisAvailFuncList.View = System.Windows.Forms.View.Details;
            // 
            // colFuncText1
            // 
            this.colFuncText1.Text = "Function";
            this.colFuncText1.Width = 100;
            // 
            // colFuncDesc1
            // 
            this.colFuncDesc1.Text = "Function Desc";
            this.colFuncDesc1.Width = 250;
            // 
            // pnlFuncRightTop
            // 
            this.pnlFuncRightTop.Controls.Add(this.cdvFGroup);
            this.pnlFuncRightTop.Controls.Add(this.lblFGroup);
            this.pnlFuncRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFuncRightTop.Location = new System.Drawing.Point(3, 16);
            this.pnlFuncRightTop.Name = "pnlFuncRightTop";
            this.pnlFuncRightTop.Size = new System.Drawing.Size(293, 28);
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
            this.cdvFGroup.Location = new System.Drawing.Point(96, 0);
            this.cdvFGroup.MaxLength = 20;
            this.cdvFGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.Name = "cdvFGroup";
            this.cdvFGroup.ReadOnly = false;
            this.cdvFGroup.SearchSubItemIndex = 0;
            this.cdvFGroup.SelectedDescIndex = -1;
            this.cdvFGroup.SelectedSubItemIndex = -1;
            this.cdvFGroup.SelectionStart = 0;
            this.cdvFGroup.Size = new System.Drawing.Size(190, 20);
            this.cdvFGroup.SmallImageList = null;
            this.cdvFGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFGroup.TabIndex = 1;
            this.cdvFGroup.TextBoxToolTipText = "";
            this.cdvFGroup.TextBoxWidth = 190;
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
            // grpSelectedFunc
            // 
            this.grpSelectedFunc.Controls.Add(this.pnlFavoMid);
            this.grpSelectedFunc.Controls.Add(this.panel1);
            this.grpSelectedFunc.Controls.Add(this.pnlFavoBottom);
            this.grpSelectedFunc.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpSelectedFunc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelectedFunc.Location = new System.Drawing.Point(2, 4);
            this.grpSelectedFunc.Name = "grpSelectedFunc";
            this.grpSelectedFunc.Size = new System.Drawing.Size(287, 503);
            this.grpSelectedFunc.TabIndex = 0;
            this.grpSelectedFunc.TabStop = false;
            this.grpSelectedFunc.Text = "Favorites Function List";
            // 
            // pnlFavoMid
            // 
            this.pnlFavoMid.Controls.Add(this.lisFavorites);
            this.pnlFavoMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFavoMid.Location = new System.Drawing.Point(3, 44);
            this.pnlFavoMid.Name = "pnlFavoMid";
            this.pnlFavoMid.Size = new System.Drawing.Size(281, 425);
            this.pnlFavoMid.TabIndex = 1;
            // 
            // lisFavorites
            // 
            this.lisFavorites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colFuncText,
            this.colFuncDesc});
            this.lisFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisFavorites.EnableSort = true;
            this.lisFavorites.EnableSortIcon = true;
            this.lisFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisFavorites.FullRowSelect = true;
            this.lisFavorites.HideSelection = false;
            this.lisFavorites.Location = new System.Drawing.Point(0, 0);
            this.lisFavorites.Name = "lisFavorites";
            this.lisFavorites.Size = new System.Drawing.Size(281, 425);
            this.lisFavorites.TabIndex = 0;
            this.lisFavorites.UseCompatibleStateImageBehavior = false;
            this.lisFavorites.View = System.Windows.Forms.View.Details;
            this.lisFavorites.SelectedIndexChanged += new System.EventHandler(this.lisFavorites_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Tag = "SEQ";
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 40;
            // 
            // colFuncText
            // 
            this.colFuncText.Text = "Function";
            this.colFuncText.Width = 100;
            // 
            // colFuncDesc
            // 
            this.colFuncDesc.Text = "Function Desc";
            this.colFuncDesc.Width = 250;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdvPgmID);
            this.panel1.Controls.Add(this.lblProgramID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 28);
            this.panel1.TabIndex = 0;
            // 
            // cdvPgmID
            // 
            this.cdvPgmID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvPgmID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPgmID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPgmID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPgmID.BtnToolTipText = "";
            this.cdvPgmID.DescText = "";
            this.cdvPgmID.DisplaySubItemIndex = -1;
            this.cdvPgmID.DisplayText = "";
            this.cdvPgmID.Focusing = null;
            this.cdvPgmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPgmID.Index = 0;
            this.cdvPgmID.IsViewBtnImage = false;
            this.cdvPgmID.Location = new System.Drawing.Point(84, 0);
            this.cdvPgmID.MaxLength = 20;
            this.cdvPgmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPgmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPgmID.Name = "cdvPgmID";
            this.cdvPgmID.ReadOnly = false;
            this.cdvPgmID.SearchSubItemIndex = 0;
            this.cdvPgmID.SelectedDescIndex = -1;
            this.cdvPgmID.SelectedSubItemIndex = -1;
            this.cdvPgmID.SelectionStart = 0;
            this.cdvPgmID.Size = new System.Drawing.Size(190, 20);
            this.cdvPgmID.SmallImageList = null;
            this.cdvPgmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPgmID.TabIndex = 1;
            this.cdvPgmID.TextBoxToolTipText = "";
            this.cdvPgmID.TextBoxWidth = 190;
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
            this.lblProgramID.Location = new System.Drawing.Point(7, 3);
            this.lblProgramID.Name = "lblProgramID";
            this.lblProgramID.Size = new System.Drawing.Size(70, 13);
            this.lblProgramID.TabIndex = 0;
            this.lblProgramID.Text = "Program ID";
            this.lblProgramID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFavoBottom
            // 
            this.pnlFavoBottom.Controls.Add(this.btnAlias);
            this.pnlFavoBottom.Controls.Add(this.lblAlias);
            this.pnlFavoBottom.Controls.Add(this.txtAlias);
            this.pnlFavoBottom.Controls.Add(this.btnUp);
            this.pnlFavoBottom.Controls.Add(this.btnDown);
            this.pnlFavoBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFavoBottom.Location = new System.Drawing.Point(3, 469);
            this.pnlFavoBottom.Name = "pnlFavoBottom";
            this.pnlFavoBottom.Size = new System.Drawing.Size(281, 31);
            this.pnlFavoBottom.TabIndex = 0;
            // 
            // btnAlias
            // 
            this.btnAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlias.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAlias.Location = new System.Drawing.Point(236, 4);
            this.btnAlias.Name = "btnAlias";
            this.btnAlias.Size = new System.Drawing.Size(42, 24);
            this.btnAlias.TabIndex = 4;
            this.btnAlias.Text = "OK";
            this.btnAlias.Click += new System.EventHandler(this.btnAlias_Click);
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlias.Location = new System.Drawing.Point(68, 9);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(29, 13);
            this.lblAlias.TabIndex = 2;
            this.lblAlias.Text = "Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlias.Location = new System.Drawing.Point(102, 6);
            this.txtAlias.MaxLength = 50;
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(129, 20);
            this.txtAlias.TabIndex = 3;
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(3, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(22, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(28, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(22, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // frmSetupFavorites
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Name = "frmSetupFavorites";
            this.Text = "Favorites Setup";
            this.Activated += new System.EventHandler(this.frmSetupFavorites_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetupFavorites_FormClosed);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlMid, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlMidMid.ResumeLayout(false);
            this.grpAvailFunc.ResumeLayout(false);
            this.pnlFuncRightTop.ResumeLayout(false);
            this.pnlFuncRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).EndInit();
            this.grpSelectedFunc.ResumeLayout(false);
            this.pnlFavoMid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPgmID)).EndInit();
            this.pnlFavoBottom.ResumeLayout(false);
            this.pnlFavoBottom.PerformLayout();
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
        
        private void GetFunctionList()
        {
            SECLIST.ViewFunctionList(lisAvailFuncList, cdvPgmID.Text, MPGV.gsUserGroup, cdvFGroup.Text);
        }
        
        private void GetFavoritesList()
        {
            SECLIST.ViewFavoritesList(lisFavorites, '1', cdvPgmID.Text, null, "");
        }
        
        private bool Update_Favorites(char c_step, int iSeqNum, string sFuncName, string sUserFuncDesc)
        {
            TRSNode in_node = new TRSNode("UPDATE_FAVORITES_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("PROGRAM_ID", cdvPgmID.Text);
            in_node.AddInt("SEQ_NUM", iSeqNum);
            in_node.AddString("FUNC_NAME", sFuncName);
            in_node.AddString("USER_FUNC_DESC", sUserFuncDesc);

            if (MPCR.CallService("SEC", "SEC_Update_Favorites", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisFavorites;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }
        
        #endregion
        
        private void frmSetupFavorites_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                pnlMid_Resize(null, null);
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisFavorites);
                MPCF.InitListView(lisAvailFuncList);

                cdvPgmID.Text = MPGV.gsProgramID;

                GetFunctionList();
                GetFavoritesList();
                
                //Add by J.S. 2009.02.13
                //favorites수정시 LotListMain, ResourceListMain시 submenu를 refresh하기위한 변수 
                MPGV.gbFavoriteChangeForLotListMain = true;
                MPGV.gbFavoriteChangeForResourceListMain = true;

                b_load_flag = true;
            }
        }

        private void frmSetupFavorites_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Add by J.S. 2009.02.13
            //favorites수정시 LotListMain, ResourceListMain시 submenu를 refresh하기위한 변수 
            MPGV.gbFavoriteChangeForLotListMain = true;
            MPGV.gbFavoriteChangeForResourceListMain = true;

            MPGV.gIMdiForm.FavoritesRefresh();
        }
        
        private void pnlMid_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(pnlMid, grpSelectedFunc, grpAvailFunc, pnlMidMid, 50);
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListViewItem itmX;
            
            string sFuncName;
            string sUserFuncDesc;
            int iSeqNum;

            if (lisAvailFuncList.SelectedItems.Count < 1) return;
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;
            
            for (i = 0; i < lisAvailFuncList.SelectedItems.Count; i++)
            {
                sFuncName = lisAvailFuncList.SelectedItems[i].Text;
                if (MPCF.FindListItemIndex(lisFavorites, sFuncName, 1, false) < 0)
                {
                    sUserFuncDesc = lisAvailFuncList.SelectedItems[i].SubItems[1].Text;
                    
                    if (lisFavorites.SelectedItems.Count > 0)
                    {
                        iSeqNum = lisFavorites.SelectedItems[0].Index + 1;
                    }
                    else
                    {
                        iSeqNum = lisFavorites.Items.Count + 1;
                    }
                    
                    if (Update_Favorites(MPGC.MP_STEP_CREATE, iSeqNum, sFuncName, sUserFuncDesc) == false)
                    {
                        return;
                    }
                    
                    itmX = new ListViewItem(iSeqNum.ToString(), (int)SMALLICON_INDEX.IDX_FUNCTION);
                    itmX.SubItems.Add(sFuncName);
                    itmX.SubItems.Add(sUserFuncDesc);
                    lisFavorites.Items.Insert(iSeqNum - 1, itmX);
                }
            }
            
            for (i = 0; i <= lisFavorites.Items.Count - 1; i++)
            {
                lisFavorites.Items[i].Text = MPCF.Trim(i + 1);
            }
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            string sFuncName;
            string sUserFuncDesc;
            int iSeqNum;

            if (lisFavorites.SelectedItems.Count < 1) return;
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;
            
            i = 0;
            while (i < lisFavorites.Items.Count)
            {
                if (lisFavorites.Items[i].Selected == true)
                {
                    sFuncName = lisFavorites.Items[i].SubItems[1].Text;
                    sUserFuncDesc = lisFavorites.Items[i].SubItems[2].Text;
                    iSeqNum = lisFavorites.Items[i].Index + 1;
                    
                    if (Update_Favorites(MPGC.MP_STEP_DELETE, iSeqNum, sFuncName, sUserFuncDesc) == false)
                    {
                        return;
                    }
                    
                    lisFavorites.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            
            for (i = 0; i <= lisFavorites.Items.Count - 1; i++)
            {
                lisFavorites.Items[i].Text = MPCF.Trim(i + 1);
            }
            
        }
        
        private void btnUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            string sFuncName;
            string sUserFuncDesc;
            int iSeqNum;

            if (lisFavorites.SelectedItems.Count < 1) return;
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;
            
            for (i = 0; i <= lisFavorites.SelectedItems.Count - 1; i++)
            {
                iSeqNum = lisFavorites.SelectedItems[i].Index;
                if (iSeqNum > 0)
                {
                    if (lisFavorites.Items[iSeqNum - 1].Selected == false)
                    {
                        sFuncName = lisFavorites.SelectedItems[i].SubItems[1].Text;
                        sUserFuncDesc = lisFavorites.SelectedItems[i].SubItems[2].Text;

                        if (b_is_work == false)
                        {
                            b_is_work = true;
                            if (Update_Favorites(MPGC.MP_STEP_UPDATE, iSeqNum, sFuncName, sUserFuncDesc) == false)
                            {
                                return;
                            }

                            lisFavorites.Items[iSeqNum].SubItems[1].Text = lisFavorites.Items[iSeqNum - 1].SubItems[1].Text;
                            lisFavorites.Items[iSeqNum].SubItems[2].Text = lisFavorites.Items[iSeqNum - 1].SubItems[2].Text;
                            lisFavorites.Items[iSeqNum].Selected = false;

                            lisFavorites.Items[iSeqNum - 1].SubItems[1].Text = sFuncName;
                            lisFavorites.Items[iSeqNum - 1].SubItems[2].Text = sUserFuncDesc;
                            lisFavorites.Items[iSeqNum - 1].Selected = true;

                            b_is_work = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            
        }
        
        private void btnDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            string sFuncName;
            string sUserFuncDesc;
            int iSeqNum;

            if (lisFavorites.SelectedItems.Count < 1) return;
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;
            
            for (i = lisFavorites.SelectedItems.Count - 1; i >= 0; i--)
            {
                iSeqNum = lisFavorites.SelectedItems[i].Index + 2;
                if (iSeqNum <= lisFavorites.Items.Count)
                {
                    if (lisFavorites.Items[iSeqNum - 1].Selected == false)
                    {
                        sFuncName = lisFavorites.SelectedItems[i].SubItems[1].Text;
                        sUserFuncDesc = lisFavorites.SelectedItems[i].SubItems[2].Text;

                        if (b_is_work == false)
                        {
                            b_is_work = true;
                            if (Update_Favorites(MPGC.MP_STEP_UPDATE, iSeqNum, sFuncName, sUserFuncDesc) == false)
                            {
                                return;
                            }

                            lisFavorites.Items[iSeqNum - 2].SubItems[1].Text = lisFavorites.Items[iSeqNum - 1].SubItems[1].Text;
                            lisFavorites.Items[iSeqNum - 2].SubItems[2].Text = lisFavorites.Items[iSeqNum - 1].SubItems[2].Text;
                            lisFavorites.Items[iSeqNum - 2].Selected = false;

                            lisFavorites.Items[iSeqNum - 1].SubItems[1].Text = sFuncName;
                            lisFavorites.Items[iSeqNum - 1].SubItems[2].Text = sUserFuncDesc;
                            lisFavorites.Items[iSeqNum - 1].Selected = true;

                            b_is_work = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            
        }
        
        private void lisFavorites_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                
                if (lisFavorites.SelectedItems.Count > 0)
                {
                    txtAlias.Text = lisFavorites.SelectedItems[0].SubItems[2].Text;
                    txtAlias.Tag = lisFavorites.SelectedItems[0].SubItems[0].Text + ":" + lisFavorites.SelectedItems[0].SubItems[1].Text;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnAlias_Click(System.Object sender, System.EventArgs e)
        {
            string sFuncName;
            string sUserFuncDesc;
            int iSeqNum;

            if (txtAlias.Text == "") return;
            if (lisFavorites.SelectedItems.Count == 0) return;
            if (MPCF.CheckValue(cdvPgmID, 1) == false) return;


            
            sUserFuncDesc = txtAlias.Text;
            iSeqNum = MPCF.ToInt(MPCF.SubtractString(MPCF.Trim(txtAlias.Tag), ":", false, false));
            if (lisFavorites.Items[iSeqNum - 1].SubItems[2].Text == sUserFuncDesc)
            {
                return;
            }
            
            sFuncName = MPCF.SubtractString(MPCF.Trim(txtAlias.Tag), ":", true, false);
            
            if (Update_Favorites(MPGC.MP_STEP_UPDATE, iSeqNum, sFuncName, sUserFuncDesc) == false)
            {
                return;
            }
            
            txtAlias.Text = "";
            txtAlias.Tag = null;
            
            GetFavoritesList();
            
            lisFavorites.Items[iSeqNum - 1].Selected = true;
            
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
            GetFunctionList();
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
            GetFunctionList();
            GetFavoritesList();
        }


    }
    
}
