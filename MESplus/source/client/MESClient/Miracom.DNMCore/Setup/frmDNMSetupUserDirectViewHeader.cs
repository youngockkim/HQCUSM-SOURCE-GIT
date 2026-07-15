using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Text;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmDNMSetupUserDirectViewHeader.cs
//   Description : Direct View Query Setup
//
//   MES Version : 5.3.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - UpdateDirectView() : Create/Update/Delete General code list
//       - ViewDirectView() :View General code list which is included in one general code table
//       - ViewDirectViewist() : View all table list which is included in one factory
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2014-05-27 : Created by Kelly Jung
//
//
//   Copyright(C) 1998-2014 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.DNMCore
{
    public class frmDNMSetupUserDirectViewHeader : Miracom.MESCore.SetupForm02
    {

        #region " Windows Form auto generated code "

        public frmDNMSetupUserDirectViewHeader()
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
        private ListView lisView;
        private GroupBox grpGeneral;
        private Label label1;
        private TextBox txtDesc;
        private TextBox txtViewID;
        private Label lblViewID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private GroupBox grpContents;
        private SplitContainer splHeader;
        private ListView lisHeader;
        private Panel panel1;
        private Button btnDown;
        private Button btnUp;
        private Button btnToRight;
        private Button btnToLeft;
        private ListView lisAttachHeader;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDNMSetupUserDirectViewHeader));
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtViewID = new System.Windows.Forms.TextBox();
            this.lblViewID = new System.Windows.Forms.Label();
            this.grpContents = new System.Windows.Forms.GroupBox();
            this.splHeader = new System.Windows.Forms.SplitContainer();
            this.lisAttachHeader = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisHeader = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.grpContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splHeader)).BeginInit();
            this.splHeader.Panel1.SuspendLayout();
            this.splHeader.Panel2.SuspendLayout();
            this.splHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpContents);
            this.pnlRight.Controls.Add(this.grpGeneral);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(282, 6);
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(555, 7);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "General Code Data Setup";
            // 
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.SystemColors.Control;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataList.Location = new System.Drawing.Point(0, 0);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "MCSPCodeView";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.VisibleColumnHeader = false;
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.Location = new System.Drawing.Point(0, 0);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 513);
            this.lisView.TabIndex = 0;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lisView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "View ID";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 172;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Controls.Add(this.txtViewID);
            this.grpGeneral.Controls.Add(this.lblViewID);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(506, 71);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.Location = new System.Drawing.Point(79, 42);
            this.txtDesc.MaxLength = 30;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(400, 20);
            this.txtDesc.TabIndex = 23;
            this.txtDesc.TabStop = false;
            // 
            // txtViewID
            // 
            this.txtViewID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtViewID.Location = new System.Drawing.Point(79, 19);
            this.txtViewID.MaxLength = 30;
            this.txtViewID.Name = "txtViewID";
            this.txtViewID.ReadOnly = true;
            this.txtViewID.Size = new System.Drawing.Size(206, 20);
            this.txtViewID.TabIndex = 22;
            this.txtViewID.TabStop = false;
            // 
            // lblViewID
            // 
            this.lblViewID.AutoSize = true;
            this.lblViewID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewID.Location = new System.Drawing.Point(16, 23);
            this.lblViewID.Name = "lblViewID";
            this.lblViewID.Size = new System.Drawing.Size(44, 13);
            this.lblViewID.TabIndex = 21;
            this.lblViewID.Text = "View ID";
            // 
            // grpContents
            // 
            this.grpContents.Controls.Add(this.splHeader);
            this.grpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpContents.Location = new System.Drawing.Point(0, 71);
            this.grpContents.Name = "grpContents";
            this.grpContents.Size = new System.Drawing.Size(506, 442);
            this.grpContents.TabIndex = 5;
            this.grpContents.TabStop = false;
            this.grpContents.Text = "Attach Header";
            // 
            // splHeader
            // 
            this.splHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splHeader.Location = new System.Drawing.Point(3, 16);
            this.splHeader.Name = "splHeader";
            // 
            // splHeader.Panel1
            // 
            this.splHeader.Panel1.Controls.Add(this.lisAttachHeader);
            // 
            // splHeader.Panel2
            // 
            this.splHeader.Panel2.Controls.Add(this.lisHeader);
            this.splHeader.Panel2.Controls.Add(this.panel1);
            this.splHeader.Size = new System.Drawing.Size(500, 423);
            this.splHeader.SplitterDistance = 239;
            this.splHeader.TabIndex = 2;
            // 
            // lisAttachHeader
            // 
            this.lisAttachHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lisAttachHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachHeader.FullRowSelect = true;
            this.lisAttachHeader.HideSelection = false;
            this.lisAttachHeader.Location = new System.Drawing.Point(0, 0);
            this.lisAttachHeader.Name = "lisAttachHeader";
            this.lisAttachHeader.Size = new System.Drawing.Size(239, 423);
            this.lisAttachHeader.TabIndex = 1;
            this.lisAttachHeader.UseCompatibleStateImageBehavior = false;
            this.lisAttachHeader.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Header";
            this.columnHeader6.Width = 69;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Display";
            this.columnHeader7.Width = 73;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Description";
            this.columnHeader8.Width = 88;
            // 
            // lisHeader
            // 
            this.lisHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lisHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisHeader.FullRowSelect = true;
            this.lisHeader.HideSelection = false;
            this.lisHeader.Location = new System.Drawing.Point(40, 0);
            this.lisHeader.Name = "lisHeader";
            this.lisHeader.Size = new System.Drawing.Size(217, 423);
            this.lisHeader.TabIndex = 0;
            this.lisHeader.UseCompatibleStateImageBehavior = false;
            this.lisHeader.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Header";
            this.columnHeader3.Width = 69;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Display";
            this.columnHeader4.Width = 73;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 88;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnToRight);
            this.panel1.Controls.Add(this.btnToLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 423);
            this.panel1.TabIndex = 1;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(7, 394);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 11;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(7, 368);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 10;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToRight.Location = new System.Drawing.Point(6, 219);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(24, 24);
            this.btnToRight.TabIndex = 9;
            this.btnToRight.Text = ">";
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToLeft.Location = new System.Drawing.Point(6, 190);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(24, 24);
            this.btnToLeft.TabIndex = 8;
            this.btnToLeft.Text = "< ";
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // frmDNMSetupUserDirectViewHeader
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmDNMSetupUserDirectViewHeader";
            this.Text = "Direct View User Header Setup";
            this.Activated += new System.EventHandler(this.frmDNMSetupUserDirectViewHeader_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpContents.ResumeLayout(false);
            this.splHeader.Panel1.ResumeLayout(false);
            this.splHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splHeader)).EndInit();
            this.splHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

       

        #endregion

        #region " Variable Definition "

        

        private bool b_load_flag;
       

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "UPDATE_VIEW":

                        break;
                    case "VIEW_VIEW":

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

        //
        // ViewDirectViewList()
        //       - View Direct View List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewList()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            ListViewItem itemX;
            int i;

            try
            {
                MPCF.ClearList(lisView);
                
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                
                do
                {
                    out_node = new TRSNode("VIEW_DIRECT_VIEW_LIST_OUT");

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        itemX = new ListViewItem(out_node.GetList("LIST")[i].GetString("VIEW_ID"), (int)SMALLICON_INDEX.IDX_INQUIRY);
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("VIEW_DESC"));
                        
                        lisView.Items.Add(itemX);
                    }
                    
                    in_node.SetString("NEXT_VIEW_ID", out_node.GetString("NEXT_VIEW_ID"));

                } while (in_node.GetString("NEXT_VIEW_ID") != "");

                MPCF.FitColumnHeader(lisView);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        //
        // ViewDirectViewHeaderList()
        //       - View Direct View Header List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewHeaderList()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_HEADER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_HEADER_LIST_OUT");

            ListViewItem itemX;
            int i;
            

            try
            {
                MPCF.ClearList(lisHeader);


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("VIEW_ID", txtViewID.Text);

                do
                {

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_Header_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        itemX = new ListViewItem(out_node.GetList("LIST")[i].GetString("COL_NAME"), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("DISPLAY_NAME"));
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("COL_DESC"));

                        lisHeader.Items.Add(itemX);
                    }

                    in_node.SetString("NEXT_COL_NAME", out_node.GetString("NEXT_COL_NAME"));

                } while (in_node.GetString("NEXT_COL_NAME") != "");

                MPCF.FitColumnHeader(lisHeader);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        //
        // ViewDirectViewHeaderList()
        //       - View Direct View User Header List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewUserHeaderList()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_USER_HEADER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_USER_HEADER_LIST_OUT");

            ListViewItem itemX;
            int i;
            int iIndex;

            try
            {
                MPCF.ClearList(lisAttachHeader);


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("VIEW_ID", txtViewID.Text);
                in_node.SetString("USER_ID", MPGV.gsUserID);

                do
                {

                    if (MPCR.CallService("DNM", "DNM_View_Header_User_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        itemX = new ListViewItem(out_node.GetList("LIST")[i].GetString("COL_NAME"), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("DISPLAY_NAME"));
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("COL_DESC"));

                        lisAttachHeader.Items.Add(itemX);
                    }

                    in_node.SetString("NEXT_COL_NAME", out_node.GetString("NEXT_COL_NAME"));

                } while (in_node.GetString("NEXT_COL_NAME") != "");
                lisAttachHeader.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                lisAttachHeader.Items[lisAttachHeader.Items.Count - 1].SubItems.Add("");
                lisAttachHeader.Items[lisAttachHeader.Items.Count - 1].SubItems.Add("");
                lisAttachHeader.Items[lisAttachHeader.Items.Count-1].Selected=true;

                MPCF.FitColumnHeader(lisAttachHeader);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // UpdateDirectViewHeader()
        //       - Create/Update/Delete Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDirectViewHeader(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DIRECT_VIEW_HEADER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.SetString("VIEW_ID", txtViewID.Text);
                in_node.SetString("USER_ID", MPGV.gsUserID);

                for (i = 0; i < lisAttachHeader.Items.Count-1; i++)
                {
                    node = in_node.AddNode("LIST");
                    node.SetInt("COL_SEQ", i+1);
                    node.SetString("COL_NAME", lisAttachHeader.Items[i].Text);
                    
                }

                if (MPCR.CallService("DNM", "DNM_Multi_Update_Header_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // ViewDirectView()
        //       - Single View Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectView()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_OUT");

            try
            {
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.SetString("VIEW_ID", txtViewID.Text);

                if (MPCR.CallService("DNM", "DNM_View_Direct_View", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("VIEW_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        private void DisplayExist()
        {
            int i;
            int j;
            bool bExist=false;

            try
            {
                for (i = 0; i <  lisHeader.Items.Count; i++)
                {
                    bExist = false;
                    for (j = 0; j < lisAttachHeader.Items.Count; j++)
                    {
                        if (lisHeader.Items[i].Text == lisAttachHeader.Items[j].Text)
                            bExist = true;
                    }
                    if (bExist == true)
                    {
                        lisHeader.Items[i].ForeColor = Color.Blue;
                        for(j=0;j<lisHeader.Items[i].SubItems.Count;j++)
                            lisHeader.Items[i].SubItems[j].ForeColor = Color.Blue;
                    }
                    else
                    {
                        lisHeader.Items[i].ForeColor = Color.Black;
                        for (j = 1; j < lisHeader.Items[i].SubItems.Count; j++)
                            lisHeader.Items[i].SubItems[j].ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        

        #endregion

        private void  frmDNMSetupUserDirectViewHeader_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisView);
                    MPCF.InitListView(lisHeader);
                    MPCF.InitListView(lisAttachHeader);

                    ViewDirectViewList();
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


       

        private void btnTblExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                MPCF.ExportToExcel(lisView, this.Text, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void lisView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected != true)
                return;

            txtViewID.Text = e.Item.Text;
            ViewDirectView();
            ViewDirectViewHeaderList();
            ViewDirectViewUserHeaderList();
            DisplayExist();
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int iSelect;
            int iTemp;

            try
            {
                if (lisAttachHeader.SelectedItems.Count == 0 || lisHeader.SelectedItems.Count == 0) 
                    return;

                iSelect = lisAttachHeader.SelectedItems[0].Index;
                iTemp = iSelect + lisHeader.SelectedItems.Count;
                for (i = 0; i < lisHeader.SelectedItems.Count; i++)
                {

                    for (j = 0; j < lisAttachHeader.Items.Count; j++)
                    {
                        if (lisAttachHeader.Items[j].Text == lisHeader.SelectedItems[i].Text)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(276));
                            return;
                        }

                    }
                }

                for (i = 0; i < lisHeader.SelectedItems.Count; i++)
                {

                    lisAttachHeader.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_MESSAGE);
                    lisAttachHeader.Items[lisAttachHeader.Items.Count - 1].SubItems.Add("");
                    lisAttachHeader.Items[lisAttachHeader.Items.Count - 1].SubItems.Add("");
                    for (j = lisAttachHeader.Items.Count-1; j > iSelect+i; j--)
                    {
                        lisAttachHeader.Items[j].Text = lisAttachHeader.Items[j-1].Text;
                        lisAttachHeader.Items[j].SubItems[1].Text = lisAttachHeader.Items[j - 1].SubItems[1].Text;
                        lisAttachHeader.Items[j].SubItems[2].Text = lisAttachHeader.Items[j - 1].SubItems[2].Text;
                    }

                    lisAttachHeader.Items[iSelect+i].Text = lisHeader.SelectedItems[i].Text;
                    lisAttachHeader.Items[iSelect+i].SubItems[1].Text = lisHeader.SelectedItems[i].SubItems[1].Text;
                    lisAttachHeader.Items[iSelect+i].SubItems[2].Text = lisHeader.SelectedItems[i].SubItems[2].Text;

                
                }
                lisAttachHeader.Items[iSelect].Selected = false;
                lisAttachHeader.Items[iTemp].Selected = true;
                DisplayExist();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            int i;

            try
            {

                for (i = lisAttachHeader.SelectedItems.Count-1; i >=0 ; i--)
                {
                    if (lisAttachHeader.SelectedItems[i].Text == "Attach ...")
                        continue;

                    lisAttachHeader.SelectedItems[i].Remove();
                }
                DisplayExist();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int iSelect;
            string sTemp_1;
            string sTemp_2;
            string sTemp_3;

            try
            {
                if (lisAttachHeader.SelectedItems[0].Text == "Attach ...")
                    return;

                if (lisAttachHeader.SelectedItems[0].Index == 0)
                    return;

                iSelect = lisAttachHeader.SelectedItems[0].Index;

                sTemp_1 = lisAttachHeader.Items[iSelect-1].Text;
                sTemp_2 = lisAttachHeader.Items[iSelect-1].SubItems[1].Text;
                sTemp_3 = lisAttachHeader.Items[iSelect-1].SubItems[2].Text;

                lisAttachHeader.Items[iSelect - 1].Text = lisAttachHeader.Items[iSelect].Text;
                lisAttachHeader.Items[iSelect - 1].SubItems[1].Text = lisAttachHeader.Items[iSelect].SubItems[1].Text;
                lisAttachHeader.Items[iSelect - 1].SubItems[2].Text = lisAttachHeader.Items[iSelect].SubItems[2].Text;

                lisAttachHeader.Items[iSelect].Text = sTemp_1;
                lisAttachHeader.Items[iSelect].SubItems[1].Text = sTemp_2;
                lisAttachHeader.Items[iSelect].SubItems[2].Text = sTemp_3;

                lisAttachHeader.Items[iSelect].Selected = false;
                lisAttachHeader.Items[iSelect-1].Selected = true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int iSelect;
            string sTemp_1;
            string sTemp_2;
            string sTemp_3;

            try
            {
                iSelect = lisAttachHeader.SelectedItems[0].Index;

                if (lisAttachHeader.SelectedItems[0].Text == "Attach ...")
                    return;

                if (lisAttachHeader.Items[iSelect+1].Text == "Attach ...")
                    return;

                

                sTemp_1 = lisAttachHeader.Items[iSelect + 1].Text;
                sTemp_2 = lisAttachHeader.Items[iSelect + 1].SubItems[1].Text;
                sTemp_3 = lisAttachHeader.Items[iSelect + 1].SubItems[2].Text;

                lisAttachHeader.Items[iSelect+1].Text = lisAttachHeader.Items[iSelect].Text;
                lisAttachHeader.Items[iSelect+1].SubItems[1].Text = lisAttachHeader.Items[iSelect].SubItems[1].Text;
                lisAttachHeader.Items[iSelect+1].SubItems[2].Text = lisAttachHeader.Items[iSelect].SubItems[2].Text;

                lisAttachHeader.Items[iSelect].Text = sTemp_1;
                lisAttachHeader.Items[iSelect].SubItems[1].Text = sTemp_2;
                lisAttachHeader.Items[iSelect].SubItems[2].Text = sTemp_3;

                lisAttachHeader.Items[iSelect].Selected = false;
                lisAttachHeader.Items[iSelect + 1].Selected = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckCondition("UPDATE_DIRECT_VIEW", '1') == true)
                {
                    if (UpdateDirectViewHeader(MPGC.MP_STEP_UPDATE) == false)
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisView, "Direct View List", null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewDirectViewList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisView, txtFind.Text, true, false);
        }

    }
}
