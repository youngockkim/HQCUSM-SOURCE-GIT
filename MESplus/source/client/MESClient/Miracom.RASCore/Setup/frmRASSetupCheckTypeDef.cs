//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupSheetTypeDef.cs
//   Description : MES Cient Form Set Sheet Type Defninition
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check Update condition
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-07-05 : Created by James Kwon
//      
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASSetupCheckTypeDef : Miracom.MESCore.SetupForm02
    {
        #region "VariableDefinition"

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        //
        // ViewSheetTypeDef()
        //       - View Sheet Type Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Sheet_Type As String
        //
        private bool ViewSheetTypeDef(char c_step, string Sheet_Type, char Type_Flag)
        {
            TRSNode in_node = new TRSNode("View_Sheet_Type_Def_In");
            TRSNode out_node = new TRSNode("View_Sheet_Type_Def_Out");
         
            int i;

            try
            {
                txtGrpCap1.Text = "";
                txtGrpCap2.Text = "";
                txtGrpCap3.Text = "";
                txtGrpCap4.Text = "";
                txtGrpCap5.Text = "";
                txtGrpCap6.Text = "";
                txtGrpCap7.Text = "";
                txtGrpCap8.Text = "";
                txtGrpCap9.Text = "";
                txtGrpCap10.Text = "";

                cdvGrpTable1.Text = "";
                cdvGrpTable2.Text = "";
                cdvGrpTable3.Text = "";
                cdvGrpTable4.Text = "";
                cdvGrpTable5.Text = "";
                cdvGrpTable6.Text = "";
                cdvGrpTable7.Text = "";
                cdvGrpTable8.Text = "";
                cdvGrpTable9.Text = "";
                cdvGrpTable10.Text = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("SHEET_TYPE", Sheet_Type);
                in_node.AddChar("TYPE_FLAG", Type_Flag);

                if (MPCR.CallService("RAS", "RAS_View_Sheet_Type_Def", in_node, ref out_node) == false)
                {
                    return false;
                }
               
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            txtGrpCap1.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable1.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 1:
                            txtGrpCap2.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable2.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 2:
                            txtGrpCap3.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable3.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 3:
                            txtGrpCap4.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable4.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 4:
                            txtGrpCap5.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable5.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 5:
                            txtGrpCap6.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable6.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 6:
                            txtGrpCap7.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable7.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 7:
                            txtGrpCap8.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable8.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 8:
                            txtGrpCap9.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable9.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
                        case 9:
                            txtGrpCap10.Text = out_node.GetList(0)[i].GetString("CAT_CAPTION");
                            cdvGrpTable10.Text = out_node.GetList(0)[i].GetString("CAT_TABLE");
                            break;
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

        //
        // UpdatePMSheet()
        //       - Change PM Sheet
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool UpdateSheetTypeDef(char c_step, string sheet_type, char type_flag)
        {
            TRSNode in_node = new TRSNode("Update_Sheet_Type_Def_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            int DataCnt = 0;
            TRSNode list;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("SHEET_TYPE", sheet_type);
                in_node.AddChar("TYPE_FLAG", type_flag);


                if (MPCF.Trim(txtGrpCap1.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION" ,txtGrpCap1.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable1.Text);

                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap2.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap2.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable2.Text);
                    
                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap3.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap3.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable3.Text);
                    
                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap4.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap4.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable4.Text);

                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap5.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap5.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable5.Text);

                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap6.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap6.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable6.Text);
                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap7.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap7.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable7.Text);
                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap8.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap8.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable8.Text);

                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap9.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap9.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable9.Text);

                    DataCnt++;
                }
                if (MPCF.Trim(txtGrpCap10.Text) != "")
                {
                    list = in_node.AddNode("DATA_LIST");
                    list.AddInt("CAT_SEQ", DataCnt);
                    list.AddString("CAT_CAPTION", txtGrpCap10.Text);
                    list.AddString("CAT_TABLE", cdvGrpTable10.Text);

                    DataCnt++;
                }

                if (MPCR.CallService("RAS", "RAS_Update_Sheet_Type_Def", in_node, ref out_node) == false)
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

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (MPCF.CheckValue(cboSheetType, 1) == false)
            {
                return false;
            }

            if (lisSheetType.SelectedItems.Count < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                lisSheetType.Focus();
                return false;
            }

            if (MPCF.Trim(txtGrpCap1.Text) == "" &&
               MPCF.Trim(txtGrpCap2.Text) == "" &&
               MPCF.Trim(txtGrpCap3.Text) == "" &&
               MPCF.Trim(txtGrpCap4.Text) == "" &&
               MPCF.Trim(txtGrpCap5.Text) == "" &&
               MPCF.Trim(txtGrpCap6.Text) == "" &&
               MPCF.Trim(txtGrpCap7.Text) == "" &&
               MPCF.Trim(txtGrpCap8.Text) == "" &&
               MPCF.Trim(txtGrpCap9.Text) == "" &&
               MPCF.Trim(txtGrpCap10.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtGrpCap1.Focus();
                return false;
            }


            return true;
        }

        #endregion

        public frmRASSetupCheckTypeDef()
        {
            InitializeComponent();
        }

        private void frmRASSetupSheetTypeDef_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisSheetType);
        }

        private void frmRASSetupSheetTypeDef_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;
            }
        }

        private void cboSheetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cboSheetType.Text) == "")
                return;

            if(cboSheetType.Text.Substring(0, 1) == "S")
                BASLIST.ViewGCMDataList(lisSheetType, '1', MPGC.MP_SHEET_SHEET_TYPE);
            else if(cboSheetType.Text.Substring(0, 1) == "D")
                BASLIST.ViewGCMDataList(lisSheetType, '1', MPGC.MP_SHEET_DATA_TYPE);
        }

        private void lisSheetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisSheetType.Items.Count <= 0)
                    return;

                if (lisSheetType.SelectedItems.Count <= 0)
                    return;

                if (ViewSheetTypeDef('1', MPCF.Trim(lisSheetType.SelectedItems[0].Text), MPCF.ToChar(cboSheetType.Text.Substring(0, 1))) == false)
                    return;

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGrpTable_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Table Name", 150, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTemp.GetListView, '1');
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                return;

            if (UpdateSheetTypeDef(MPGC.MP_STEP_UPDATE, lisSheetType.SelectedItems[0].Text, MPCF.ToChar(cboSheetType.Text.Substring(0, 1))) == false)
                return;

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
      
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                return;

           
            if (UpdateSheetTypeDef(MPGC.MP_STEP_DELETE, lisSheetType.SelectedItems[0].Text, MPCF.ToChar(cboSheetType.Text.Substring(0, 1))) == false)
                return;

            

            if (lisSheetType.Items.Count <= 0)
                return;

            if (lisSheetType.SelectedItems.Count <= 0)
                return;

            if (ViewSheetTypeDef('1', MPCF.Trim(lisSheetType.SelectedItems[0].Text), MPCF.ToChar(cboSheetType.Text.Substring(0, 1))) == false)
                return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (MPCF.Trim(cboSheetType.Text) == "")
                    return;

                if (cboSheetType.Text.Substring(0, 1) == "S")
                {
                    if (BASLIST.ViewGCMDataList(lisSheetType, '1', MPGC.MP_SHEET_SHEET_TYPE) == false)
                        return;
                }
                else if (cboSheetType.Text.Substring(0, 1) == "D")
                {
                    if (BASLIST.ViewGCMDataList(lisSheetType, '1', MPGC.MP_SHEET_DATA_TYPE) == false)
                        return;
                }

                lblDataCount.Text = lisSheetType.Items.Count.ToString();
                if (lisSheetType.Items.Count > 0)
                {
                    lisSheetType.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}

