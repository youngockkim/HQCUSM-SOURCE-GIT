using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewAttributeStatus.vb
//   Description : MES Cient Form Attribute Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-07-05 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

namespace Miracom.BASCore
{
    public partial class frmBASViewAttributeStatus : Miracom.MESCore.ViewForm01
    {
        #region " Windows Form auto generated code "

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrKey;
        private Label lblAttrKey;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private NumericUpDown nudToAttrSeq;
        private NumericUpDown nudFromAttrSeq;
        private Label label3;
        private Label lblAttrSeq;
        private udcAttributeStatus udcAttributeStatus;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private Label lblAttrName;
        private Label lblAttrType;

        public frmBASViewAttributeStatus()
        {
            InitializeComponent();
        }

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

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.cdvAttrKey = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.nudToAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.nudFromAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAttrSeq = new System.Windows.Forms.Label();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 66);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvAttrName);
            this.grpOption.Controls.Add(this.lblAttrName);
            this.grpOption.Controls.Add(this.nudToAttrSeq);
            this.grpOption.Controls.Add(this.nudFromAttrSeq);
            this.grpOption.Controls.Add(this.label3);
            this.grpOption.Controls.Add(this.lblAttrSeq);
            this.grpOption.Controls.Add(this.cdvAttrKey);
            this.grpOption.Controls.Add(this.lblAttrKey);
            this.grpOption.Controls.Add(this.cdvAttrType);
            this.grpOption.Controls.Add(this.lblAttrType);
            this.grpOption.Size = new System.Drawing.Size(742, 66);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.udcAttributeStatus);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 66);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 447);
            this.pnlViewMid.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // cdvAttrKey
            // 
            this.cdvAttrKey.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrKey.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrKey.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrKey.BtnToolTipText = "";
            this.cdvAttrKey.DescText = "";
            this.cdvAttrKey.DisplaySubItemIndex = 0;
            this.cdvAttrKey.DisplayText = "";
            this.cdvAttrKey.Focusing = null;
            this.cdvAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrKey.Index = 0;
            this.cdvAttrKey.IsViewBtnImage = false;
            this.cdvAttrKey.Location = new System.Drawing.Point(77, 39);
            this.cdvAttrKey.MaxLength = 100;
            this.cdvAttrKey.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.Name = "cdvAttrKey";
            this.cdvAttrKey.ReadOnly = false;
            this.cdvAttrKey.SearchSubItemIndex = 0;
            this.cdvAttrKey.SelectedDescIndex = -1;
            this.cdvAttrKey.SelectedSubItemIndex = 0;
            this.cdvAttrKey.SelectionStart = 0;
            this.cdvAttrKey.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrKey.SmallImageList = null;
            this.cdvAttrKey.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrKey.TabIndex = 5;
            this.cdvAttrKey.TextBoxToolTipText = "";
            this.cdvAttrKey.TextBoxWidth = 200;
            this.cdvAttrKey.VisibleButton = true;
            this.cdvAttrKey.VisibleColumnHeader = false;
            this.cdvAttrKey.VisibleDescription = false;
            this.cdvAttrKey.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrKey_SelectedItemChanged);
            this.cdvAttrKey.ButtonPress += new System.EventHandler(this.cdvAttrKey_ButtonPress);
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.AutoSize = true;
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(14, 42);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(28, 13);
            this.lblAttrKey.TabIndex = 4;
            this.lblAttrKey.Text = "Key";
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = 0;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(77, 14);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = 0;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 200;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(14, 17);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(35, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Type";
            // 
            // nudToAttrSeq
            // 
            this.nudToAttrSeq.Location = new System.Drawing.Point(530, 39);
            this.nudToAttrSeq.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudToAttrSeq.Name = "nudToAttrSeq";
            this.nudToAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudToAttrSeq.TabIndex = 9;
            this.nudToAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudToAttrSeq.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudFromAttrSeq
            // 
            this.nudFromAttrSeq.Location = new System.Drawing.Point(410, 39);
            this.nudFromAttrSeq.Name = "nudFromAttrSeq";
            this.nudFromAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudFromAttrSeq.TabIndex = 7;
            this.nudFromAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(503, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttrSeq
            // 
            this.lblAttrSeq.AutoSize = true;
            this.lblAttrSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrSeq.Location = new System.Drawing.Point(347, 42);
            this.lblAttrSeq.Name = "lblAttrSeq";
            this.lblAttrSeq.Size = new System.Drawing.Size(56, 13);
            this.lblAttrSeq.TabIndex = 6;
            this.lblAttrSeq.Text = "Sequence";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeKey = "";
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(0, 0);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(742, 447);
            this.udcAttributeStatus.TabIndex = 0;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // cdvAttrName
            // 
            this.cdvAttrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvAttrName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrName.BtnToolTipText = "";
            this.cdvAttrName.DescText = "";
            this.cdvAttrName.DisplaySubItemIndex = 0;
            this.cdvAttrName.DisplayText = "";
            this.cdvAttrName.Focusing = null;
            this.cdvAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrName.Index = 0;
            this.cdvAttrName.IsViewBtnImage = false;
            this.cdvAttrName.Location = new System.Drawing.Point(410, 14);
            this.cdvAttrName.MaxLength = 100;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = false;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedSubItemIndex = 0;
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(326, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 3;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 326;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            this.cdvAttrName.ButtonPress += new System.EventHandler(this.cdvAttrName_ButtonPress);
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(347, 17);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(35, 13);
            this.lblAttrName.TabIndex = 2;
            this.lblAttrName.Text = "Name";
            // 
            // frmBASViewAttributeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASViewAttributeStatus";
            this.Text = "View Attribute Status";
            this.Activated += new System.EventHandler(this.frmBASViewAttributeStatus_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        private const int MAX_VALUE_COUNT = 1000;

        #endregion 

        #region " Variable Definition"

        bool b_load_flag;

        #endregion

        #region " Function Definition"
        
        // CheckCondition()
        //       - check View condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvAttrKey, 1) == false)
            {
                return false;
            }
            return true;

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvAttrType;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }
        #endregion

        private void frmBASViewAttributeStatus_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                nudToAttrSeq.Value = 10000;

                b_load_flag = true;
            }
        }

        private void cdvAttrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvAttrKey.Text = "";
            cdvAttrKey.VisibleButton = true;

            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:

                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:

                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:

                    break;
                case MPGC.MP_ATTR_TYPE_OPER:

                    break;
                case MPGC.MP_ATTR_TYPE_BOM:

                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:

                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    break;
                default:

                    cdvAttrKey.VisibleButton = false;
                    break;
            }

        }

        private void cdvAttrKey_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }

            cdvAttrKey.Init();
            MPCF.InitListView(cdvAttrKey.GetListView);
            cdvAttrKey.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrKey.SelectedSubItemIndex = 0;

            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:

                    WIPLIST.ViewFactoryList(cdvAttrKey.GetListView, '1', null);
                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:

                    cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    WIPLIST.ViewMaterialList(cdvAttrKey.GetListView, '1');
                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:

                    WIPLIST.ViewFlowList(cdvAttrKey.GetListView, '1', "", 0, "", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_OPER:

                    WIPLIST.ViewOperationList(cdvAttrKey.GetListView, '1', "", 0, "", "", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_BOM:

#if _BOM
                    BOMLIST.ViewBOMSetList(cdvAttrKey.GetListView, '1', null, "", -1, -1, ' ', true);
#endif
                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:

                    RASLIST.ViewResourceList(cdvAttrKey.GetListView, false);
                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(cdvAttrKey.Text) == "")
                        {
                            cdvAttrKey.IsPopup = false;
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            cdvAttrKey.Focus();
                            return;
                        }
                    }
                    RASLIST.ViewCarrierList(cdvAttrKey.GetListView, '1', "", "", cdvAttrKey.Text);
                    break;
            }

        }

        private void cdvAttrKey_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAttrType.Text == MPGC.MP_ATTR_TYPE_MATERIAL)
                if (e != null)
                    cdvAttrKey.Text = e.SelectedItem.SubItems[0].Text + " : " + e.SelectedItem.SubItems[1].Text;

            btnView.PerformClick();
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false)
                return;

            udcAttributeStatus.AttributeType= this.cdvAttrType.Text;
            udcAttributeStatus.AttributeKey = this.cdvAttrKey.Text;
            udcAttributeStatus.AttributeName = cdvAttrName.Text;
            udcAttributeStatus.FromSequence = (int)nudFromAttrSeq.Value;
            udcAttributeStatus.ToSequence = (int)nudToAttrSeq.Value;
            udcAttributeStatus.View();
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Seq", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Type", 200, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Attr Type : " + MPCF.Trim(cdvAttrType.Text) + "\r";
            sCond += "Attr Name : " + MPCF.Trim(cdvAttrName.Text) + "\r";
            sCond += "Attr Key  : " + MPCF.Trim(cdvAttrKey.Text) + "\r";
            sCond += "Sequence  : " + MPCF.Trim(nudFromAttrSeq.Value) + "~" + MPCF.Trim(nudToAttrSeq.Value) + "\r";
            MPCF.ExportToExcel(udcAttributeStatus. GetSpread(), this.Text, sCond);  
        }

    }
}