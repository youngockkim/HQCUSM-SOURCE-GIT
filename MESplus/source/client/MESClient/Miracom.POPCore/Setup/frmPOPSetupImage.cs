
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using System.IO;
using System.Drawing.Imaging;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmPOPSetupImage.vb
//   Description : Image Definition Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Image() : View Image definition
//       - Update_Image() : Create/Update/Delete Image definition
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by HS Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _POP = True Then

namespace Miracom.POPCore
{
    public class frmPOPSetupImage : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmPOPSetupImage()
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
        
        //참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
        //Windows Form 디자이너를 사용하여 수정할 수 있습니다.  
        //코드 편집기를 사용하여 수정하지 마십시오.
        private System.Windows.Forms.GroupBox grbImage;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private Miracom.UI.Controls.MCListView.MCListView lisImage;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.TextBox txtDesc1;
        private PictureBox picImage;
        private System.Windows.Forms.Label Label1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grbImage = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lisImage = new Miracom.UI.Controls.MCListView.MCListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbImage.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.picImage);
            this.pnlRight.Controls.Add(this.GroupBox1);
            this.pnlRight.Controls.Add(this.grbImage);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisImage);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(463, 8);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(555, 8);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(371, 8);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(647, 8);
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Image Setup";
            // 
            // grbImage
            // 
            this.grbImage.Controls.Add(this.txtDesc);
            this.grbImage.Controls.Add(this.Label6);
            this.grbImage.Controls.Add(this.txtImage);
            this.grbImage.Controls.Add(this.lblImage);
            this.grbImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbImage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbImage.Location = new System.Drawing.Point(0, 0);
            this.grbImage.Name = "grbImage";
            this.grbImage.Size = new System.Drawing.Size(503, 71);
            this.grbImage.TabIndex = 0;
            this.grbImage.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(360, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(100, 14);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImage
            // 
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImage.Location = new System.Drawing.Point(120, 16);
            this.txtImage.MaxLength = 8;
            this.txtImage.Name = "txtImage";
            this.txtImage.ReadOnly = true;
            this.txtImage.Size = new System.Drawing.Size(200, 20);
            this.txtImage.TabIndex = 1;
            this.txtImage.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(15, 19);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(100, 14);
            this.lblImage.TabIndex = 0;
            this.lblImage.Text = "Image Name";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtDesc1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnFileOpen);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Controls.Add(this.txtFile);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(0, 71);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(503, 121);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc1.Location = new System.Drawing.Point(120, 40);
            this.txtDesc1.MaxLength = 50;
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(360, 20);
            this.txtDesc1.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(16, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 14);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Description";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileOpen.Location = new System.Drawing.Point(412, 16);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(70, 20);
            this.btnFileOpen.TabIndex = 2;
            this.btnFileOpen.Text = "File Open";
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 64);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 6;
            this.txtCreateUser.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(302, 90);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(178, 20);
            this.txtUpdateTime.TabIndex = 10;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(302, 64);
            this.txtCreateTime.MaxLength = 20;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(178, 20);
            this.txtCreateTime.TabIndex = 7;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 90);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 9;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(16, 93);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(100, 14);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreate
            // 
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(16, 67);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(100, 14);
            this.lblCreate.TabIndex = 5;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(120, 16);
            this.txtFile.MaxLength = 100;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(362, 20);
            this.txtFile.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(16, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(100, 14);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "File";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisImage
            // 
            this.lisImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDescription});
            this.lisImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisImage.EnableSort = true;
            this.lisImage.EnableSortIcon = true;
            this.lisImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisImage.FullRowSelect = true;
            this.lisImage.Location = new System.Drawing.Point(3, 3);
            this.lisImage.MultiSelect = false;
            this.lisImage.Name = "lisImage";
            this.lisImage.Size = new System.Drawing.Size(226, 500);
            this.lisImage.TabIndex = 0;
            this.lisImage.UseCompatibleStateImageBehavior = false;
            this.lisImage.View = System.Windows.Forms.View.Details;
            this.lisImage.SelectedIndexChanged += new System.EventHandler(this.lisImage_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Image";
            this.colName.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 200;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(0, 192);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(503, 314);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 6;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            // 
            // frmPOPSetupImage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmPOPSetupImage";
            this.Text = "Image Setup";
            this.Activated += new System.EventHandler(this.frmPOPSetupImage_Activated);
            this.Load += new System.EventHandler(this.frmPOPSetupImage_Load);
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
            this.grbImage.ResumeLayout(false);
            this.grbImage.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constant Definition"
        
        
        #endregion
        
        #region "Variable Definition"
        
        bool b_load_flag;
        string strImageFilePath;
        
        #endregion
        
        #region "Function Definition"
        
        //-----------------------------------------------------------------------------
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        //-----------------------------------------------------------------------------
        private void ClearData(char ProcStep)
        {
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this);
                }
                else if (ProcStep == '2')
                {
                    txtFile.Text = "";
                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";
                }
            }
            catch (Exception)
            {
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        //-----------------------------------------------------------------------------
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            switch (FuncName.TrimEnd())
            {
                case "Update_Image":

                    //'If modCommonFunction.CheckValue(txtImage, 1, false, false, "", "", "") = False Then
                    //'    Return False
                    //'End If
                    
                    switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                    {
                        case MPGC.MP_STEP_CREATE:
                            break;
                            
                            
                            
                        case MPGC.MP_STEP_UPDATE:
                            
                            break;
                            
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Image()
        //       - View Image Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Image()
        {
            TRSNode in_node = new TRSNode("View_Image_In");
            TRSNode out_node = new TRSNode("View_Image_Out");
            
            try
            {
                MPCF.FieldClear(pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("IMAGE_ID", lisImage.SelectedItems[0].Text);
                
                if (MPCR.CallService("POP", "POP_View_Image", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtImage.Text = out_node.GetString("IMAGE_ID");
                txtImage.ReadOnly = true;
                txtDesc.Text = out_node.GetString("IMAGE_DESC");
                txtDesc.ReadOnly = true;
                txtDesc1.Text = out_node.GetString("IMAGE_DESC");
                
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // Update_Image()
        //       - Create/Update/Delete Image Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Image(char ProcStep)
        {
            ListViewItem itm;
            StreamReader sr;
            //int i_start = 0;
            //int i_end = 0;
            int i;
            string s_image_data;
            List<string> sList = new List<string>();
            byte[] file_buffer;

            TRSNode in_node = new TRSNode("Update_Image_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode item_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("IMAGE_ID", txtImage.Text);
                in_node.AddString("IMAGE_DESC", txtDesc1.Text.TrimEnd());
                if (OpenFileDialog1.FileName.ToUpper().EndsWith(".BMP"))
                {
                    in_node.AddString("FILE", MPCF.Trim(OpenFileDialog1.FileName.Split('\\')[OpenFileDialog1.FileName.Split('\\').Length - 1]));                    
                }

                if (ProcStep == MPGC.MP_STEP_CREATE)
                {
                    //BMP가 아닐때
                    if (OpenFileDialog1.FileName.ToUpper().EndsWith(".BMP"))
                    {
                        if (MPCF.Trim(picImage.Tag) != "")
                        {
                            item_list = in_node.AddNode("IMAGE_LIST");

                            item_list.AddInt("SEQ_NUM", 1);
                            item_list.AddString("IMAGE_DATA", MPCF.Trim(OpenFileDialog1.FileName.Split('\\')[OpenFileDialog1.FileName.Split('\\').Length - 1]));
                            
                            if (picImage.Tag != null)
                            {
                                file_buffer = (byte[])picImage.Tag;
                                in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                            }
                        }
                    }
                    else
                    {                        
                        sr = new StreamReader(strImageFilePath, System.Text.Encoding.GetEncoding(949));
                        s_image_data = sr.ReadLine();
                        do
                        {
                            sList.Add(s_image_data);
                            s_image_data = sr.ReadLine();
                        } while (s_image_data != null);
                        sr.Close();

                        //i_start = sList[0].IndexOf("~DG") + 4;
                        //i_end = sList[0].IndexOf(",");
                        //txtImage.Text = sList[0].Substring(i_start - 1, i_end - i_start);

                        //in_node.AddString("IMAGE_ID", txtImage.Text);                    

                        for (i = 0; i < sList.Count; i++)
                        {
                            item_list = in_node.AddNode("IMAGE_LIST");

                            item_list.AddInt("SEQ_NUM", i + 1);
                            item_list.AddString("IMAGE_DATA", sList[i]);
                        }
                    }
                }
                
                if (MPCR.CallService("POP", "POP_Update_Image", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisImage.Items.Add(txtImage.Text.Trim(), (int)SMALLICON_INDEX.IDX_FUNCTION);
                        itm.SubItems.Add(txtDesc1.Text.Trim());
                        itm.Selected = true;
                        lisImage.Sorting = SortOrder.Ascending;
                        lisImage.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisImage, txtImage.Text.TrimEnd(), false) == true)
                        {
                            lisImage.SelectedItems[0].SubItems[1].Text = txtDesc1.Text.TrimEnd();
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        i = MPCF.FindListItemIndex(lisImage, txtImage.Text.TrimEnd(), false);
                        if (i < 0)
                        {
                            lisImage.Items[i].Remove();
                        }
                    }
                    lblDataCount.Text = lisImage.Items.Count.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisImage;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmPOPSetupImage_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (POPLIST.ViewImageList(lisImage, '1', null, "", -1, -1) == true)
                    {
                        lblDataCount.Text = lisImage.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisImage.Items.Count > 0)
                    {
                        lisImage.Items[0].Selected = true;
                    }
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmPOPSetupImage_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisImage);
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
                if (CheckCondition("Update_Image", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Image(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
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
                if (CheckCondition("Update_Image", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Image(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
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
                if (CheckCondition("Update_Image", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Image(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('1');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisImage_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisImage.SelectedItems.Count > 0)
                {
                    View_Image();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (POPLIST.ViewImageList(lisImage, '1', null, "", -1, -1) == false)
                {
                    return;
                }
                lblDataCount.Text = lisImage.Items.Count.ToString();
                if (lisImage.Items.Count > 0)
                {
                    MPCF.FindListItem(lisImage, txtImage.Text.Trim(), false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisImage, this.Text, "");
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisImage, txtFind.Text.Trim(), true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisImage, txtFind.Text.Trim(), 0, true, false);
            
        }
        
        private void btnFileOpen_Click(System.Object sender, System.EventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            OpenFileDialog1.Filter = "Image Files(*.GRF;*.BMP)|*.GRF;*.BMP"; //Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (txtImage.Text == "")
                {
                    txtImage.ReadOnly = false;
                    txtDesc.ReadOnly = false;
                }
                else
                {
                    MPCF.FieldClear(this);

                    txtImage.ReadOnly = false;
                    txtDesc.ReadOnly = false;
                }
                
                txtFile.Text = OpenFileDialog1.FileName;
                strImageFilePath = OpenFileDialog1.FileName;

                if (OpenFileDialog1.FileName.ToUpper().EndsWith(".BMP"))
                {
                    finfo = new FileInfo(OpenFileDialog1.FileName);
                    if (finfo.Exists == true)
                    {
                        picImage.Image = Image.FromFile(OpenFileDialog1.FileName);

                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        picImage.Tag = file_buffer;
                        br.Close();                        
                    }
                }                
            }
            
        }
        
    }
    //#End If
}
