
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;

using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmPOPSetupMaterialLabel.vb
//   Description : Attach/Detach Label to Material Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - Update_MaterialLabel() : Attach Label To Material/ Detach Label From Material
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
    public class frmPOPSetupMaterialLabel : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmPOPSetupMaterialLabel()
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
        



        private System.Windows.Forms.Panel pnlMaterial;
        private System.Windows.Forms.GroupBox grbMaterial;
        private System.Windows.Forms.GroupBox grbAttachLabel;
        private System.Windows.Forms.Panel pnlAttachLabelMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private Miracom.UI.Controls.MCListView.MCListView lisAvailLabel;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachLabel;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        protected Button btnLabelExcel;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOPSetupMaterialLabel));
            this.grbAttachLabel = new System.Windows.Forms.GroupBox();
            this.pnlAttachLabelMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lisAvailLabel = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lisAttachLabel = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.pnlMaterial = new System.Windows.Forms.Panel();
            this.grbMaterial = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.btnLabelExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbAttachLabel.SuspendLayout();
            this.pnlAttachLabelMid.SuspendLayout();
            this.pnlMaterial.SuspendLayout();
            this.grbMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(366, 7);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(457, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(548, 7);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(639, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grbAttachLabel);
            this.pnlCenter.Controls.Add(this.pnlMaterial);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Material Label Setup";
            // 
            // grbAttachLabel
            // 
            this.grbAttachLabel.Controls.Add(this.pnlAttachLabelMid);
            this.grbAttachLabel.Controls.Add(this.lisAvailLabel);
            this.grbAttachLabel.Controls.Add(this.lisAttachLabel);
            this.grbAttachLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbAttachLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbAttachLabel.Location = new System.Drawing.Point(0, 47);
            this.grbAttachLabel.Name = "grbAttachLabel";
            this.grbAttachLabel.Size = new System.Drawing.Size(742, 459);
            this.grbAttachLabel.TabIndex = 1;
            this.grbAttachLabel.TabStop = false;
            this.grbAttachLabel.Resize += new System.EventHandler(this.grpAttachLabel_Resize);
            // 
            // pnlAttachLabelMid
            // 
            this.pnlAttachLabelMid.Controls.Add(this.btnLabelExcel);
            this.pnlAttachLabelMid.Controls.Add(this.btnDel);
            this.pnlAttachLabelMid.Controls.Add(this.btnAdd);
            this.pnlAttachLabelMid.Location = new System.Drawing.Point(330, 18);
            this.pnlAttachLabelMid.Name = "pnlAttachLabelMid";
            this.pnlAttachLabelMid.Size = new System.Drawing.Size(64, 153);
            this.pnlAttachLabelMid.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(20, 79);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.TabStop = false;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(20, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lisAvailLabel
            // 
            this.lisAvailLabel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lisAvailLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.lisAvailLabel.EnableSort = true;
            this.lisAvailLabel.EnableSortIcon = true;
            this.lisAvailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAvailLabel.FullRowSelect = true;
            this.lisAvailLabel.Location = new System.Drawing.Point(457, 16);
            this.lisAvailLabel.MultiSelect = false;
            this.lisAvailLabel.Name = "lisAvailLabel";
            this.lisAvailLabel.Size = new System.Drawing.Size(282, 440);
            this.lisAvailLabel.TabIndex = 2;
            this.lisAvailLabel.UseCompatibleStateImageBehavior = false;
            this.lisAvailLabel.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Available Label";
            this.ColumnHeader5.Width = 150;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 165;
            // 
            // lisAttachLabel
            // 
            this.lisAttachLabel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisAttachLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisAttachLabel.EnableSort = true;
            this.lisAttachLabel.EnableSortIcon = true;
            this.lisAttachLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachLabel.FullRowSelect = true;
            this.lisAttachLabel.Location = new System.Drawing.Point(3, 16);
            this.lisAttachLabel.Name = "lisAttachLabel";
            this.lisAttachLabel.Size = new System.Drawing.Size(297, 440);
            this.lisAttachLabel.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisAttachLabel.TabIndex = 0;
            this.lisAttachLabel.UseCompatibleStateImageBehavior = false;
            this.lisAttachLabel.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Attached Label";
            this.ColumnHeader3.Width = 150;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 165;
            // 
            // pnlMaterial
            // 
            this.pnlMaterial.Controls.Add(this.grbMaterial);
            this.pnlMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaterial.Location = new System.Drawing.Point(0, 0);
            this.pnlMaterial.Name = "pnlMaterial";
            this.pnlMaterial.Size = new System.Drawing.Size(742, 47);
            this.pnlMaterial.TabIndex = 0;
            // 
            // grbMaterial
            // 
            this.grbMaterial.Controls.Add(this.cdvMaterial);
            this.grbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMaterial.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbMaterial.Location = new System.Drawing.Point(0, 0);
            this.grbMaterial.Name = "grbMaterial";
            this.grbMaterial.Size = new System.Drawing.Size(742, 47);
            this.grbMaterial.TabIndex = 0;
            this.grbMaterial.TabStop = false;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = 2;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(715, 21);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 21;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 250;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // btnLabelExcel
            // 
            this.btnLabelExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLabelExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLabelExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnLabelExcel.Image")));
            this.btnLabelExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLabelExcel.Location = new System.Drawing.Point(3, 126);
            this.btnLabelExcel.Name = "btnLabelExcel";
            this.btnLabelExcel.Size = new System.Drawing.Size(24, 24);
            this.btnLabelExcel.TabIndex = 7;
            this.btnLabelExcel.Click += new System.EventHandler(this.btnLabelExcel_Click);
            // 
            // frmPOPSetupMaterialLabel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmPOPSetupMaterialLabel";
            this.Text = "Material Label Setup";
            this.Load += new System.EventHandler(this.frmPOPSetupMaterialLabel_Load);
            this.Activated += new System.EventHandler(this.frmPOPSetupMaterialLabel_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbAttachLabel.ResumeLayout(false);
            this.pnlAttachLabelMid.ResumeLayout(false);
            this.pnlMaterial.ResumeLayout(false);
            this.grbMaterial.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constant Definition"
        
        
        #endregion
        
        #region "Variable Definition"
        
        bool LoadFlag;
        
        #endregion
        
        #region "Function Definition"
        
        //-----------------------------------------------------------------------------
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        //-----------------------------------------------------------------------------
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    lisAttachLabel.Items.Clear();
                }
                else if (ProcStep == '2')
                {
                    
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
                case "Update_MaterialLabel":
                    
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        if (lisAvailLabel.SelectedIndices.Count == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAvailLabel.Focus();
                            return false;
                        }
                        
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        if (lisAttachLabel.SelectedIndices.Count == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAttachLabel.Focus();
                            return false;
                        }
                    }
                    break;
                    
            }
            return true;
        }
        
        //-----------------------------------------------------------------------------
        //
        // Update_MaterialLabel()
        //       - Attach Label To Material/ Detach Label From Material
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //       - ByVal iIndex As Integer : Index of Listview
        //
        //-----------------------------------------------------------------------------
        private bool Update_MateriaLabel(char ProcStep, int iIndex)
        {
            TRSNode in_node = new TRSNode("Update_MaterialLabel_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", cdvMaterial.Text);
                in_node.AddInt("MAT_VER", cdvMaterial.Version);                
                
                if (ProcStep == MPGC.MP_STEP_CREATE)
                {
                    in_node.AddString("LABEL_ID", lisAvailLabel.Items[iIndex].Text);
                }
                else if (ProcStep == MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("LABEL_ID", lisAttachLabel.Items[iIndex].Text);
                }
                
                if (MPCR.CallService("POP", "POP_Update_MaterialLabel", in_node, ref out_node) == false)
                {
                    return false;
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
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmPOPSetupMaterialLabel_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    grpAttachLabel_Resize(null, null);
                    
                    if (POPLIST.ViewLabelList(lisAvailLabel, '1', "", 0, "", null, "") == false)
                    {
                        return;
                    }
                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmPOPSetupMaterialLabel_Load(object sender, System.EventArgs e)
        {
            try
            {
                
                MPCF.InitListView(lisAvailLabel);
                MPCF.InitListView(lisAttachLabel);
                
                lisAvailLabel.MultiSelect = true;
                lisAttachLabel.MultiSelect = true;
                
                ClearData('1');
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void grpAttachLabel_Resize(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(grbAttachLabel, lisAttachLabel, lisAvailLabel, pnlAttachLabelMid, 50);
        }

        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData('1');
            if (cdvMaterial.Text.Trim() != "")
            {
                POPLIST.ViewLabelList(lisAttachLabel, '2', cdvMaterial.Text, cdvMaterial.Version, "", null, "");
            }
        }
        
        private void cdvmaterial_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvMaterial.Init();
            MPCF.InitListView(cdvMaterial.MaterialGetListView);
            cdvMaterial.MaterialColumns.Add("Security Group", 100, HorizontalAlignment.Left);
            cdvMaterial.MaterialColumns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvMaterial.SelectedSubItemIndex = 0;
            cdvMaterial.DisplaySubItemIndex = 0;
            cdvMaterial.SelectedDescIndex = 1;
            WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1');
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int iLastIndex = 0;
            ListViewItem itm;
            
            try
            {
                if (CheckCondition("Update_MaterialLabel", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                if (lisAttachLabel.Items.Count >= 1)
                {
                    return;
                }
                
                for (j = 0; j <= lisAvailLabel.Items.Count - 1; j++)
                {
                    if (lisAvailLabel.Items[j].Selected == true)
                    {
                        iLastIndex = j;
                        for (i = 0; i <= lisAttachLabel.Items.Count - 1; i++)
                        {
                            if (MPCF.Trim(lisAttachLabel.Items[i].Text) == lisAvailLabel.Items[j].Text)
                            {
                                break;
                            }
                        }
                        if (i > lisAttachLabel.Items.Count - 1)
                        {
                            if (Update_MateriaLabel(MPGC.MP_STEP_CREATE, j) == false)
                            {
                                return;
                            }
                            itm = lisAttachLabel.Items.Add(MPCF.Trim(lisAvailLabel.Items[j].Text), (int)SMALLICON_INDEX.IDX_LABEL);
                            itm.SubItems.Add(MPCF.Trim(lisAvailLabel.Items[j].SubItems[1].Text));
                            for (k = 0; k <= lisAttachLabel.Items.Count - 1; k++)
                            {
                                lisAttachLabel.Items[k].Selected = false;
                            }
                            MPCF.FindListItem(lisAttachLabel, lisAvailLabel.Items[j].Text, false);
                        }
                        
                        if (j < lisAvailLabel.Items.Count - 1)
                        {
                            lisAvailLabel.Items[j].Selected = false;
                        }
                        
                        if (lisAttachLabel.Items.Count >= 1)
                        {
                            return;
                        }
                        
                    }
                }
                
                if (iLastIndex < lisAvailLabel.Items.Count - 1)
                {
                    if (lisAvailLabel.SelectedItems.Count > 0)
                    {
                        lisAvailLabel.SelectedItems[0].Selected = false;
                    }
                    lisAvailLabel.Items[iLastIndex + 1].Selected = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            int i = 0;
            int iLastIndex = 0;
            
            try
            {
                if (CheckCondition("Update_MaterialLabel", MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                
                for (i = 0; i <= lisAttachLabel.Items.Count - 1; i++)
                {
                    if (i > lisAttachLabel.Items.Count - 1)
                    {
                        break;
                    }
                    if (lisAttachLabel.Items[i].Selected == true)
                    {
                        iLastIndex = i;
                        if (Update_MateriaLabel(MPGC.MP_STEP_DELETE, i) == false)
                        {
                            return;
                        }
                        lisAttachLabel.Items[i].Remove();
                        i--;
                    }
                }
                
                if (lisAttachLabel.Items.Count > 0)
                {
                    if (iLastIndex > 0 && iLastIndex <= lisAttachLabel.Items.Count - 1)
                    {
                        lisAttachLabel.Items[iLastIndex].Selected = true;
                    }
                    else
                    {
                        lisAttachLabel.Items[lisAttachLabel.Items.Count - 1].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnLabelExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Material : " + cdvMaterial.Text;

                MPCF.ExportToExcel(lisAttachLabel, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    //#End If
}
