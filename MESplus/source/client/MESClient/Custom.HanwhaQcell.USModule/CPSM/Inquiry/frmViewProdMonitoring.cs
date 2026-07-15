//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmViewProdMonitoring.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCpsm() : View Cpsm definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023/10/09 14:18:34 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmViewProdMonitoring : ViewForm01
    {
        public frmViewProdMonitoring()
        {
            InitializeComponent();            
        }


        #region " Constant Definition "
        private enum LIST : int
        {
            BASE_CODE,
            SUB_CODE,
            DESC,
            LAST_TIME,
            BASE_DT,
            USER_ID,
            VERSION,
            STATUS,
            STATUS_MSG
        }


        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.cdvCategory;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ("1", "2")
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    // TODO
                }
                else if (c_case == '2')
                {
                    // TODO
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
        //       - string FuncName : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(cdvCategory, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "VIEW1":
                    // TODO
                    break;
                case "VIEW2":
                    // TODO
                    break;
            }

            return true;            
        }

        //
        // SetSheetHeader()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        private bool SetSheetHeader()
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdList.ActiveSheet;
                if (MPCF.Trim(cdvCategory.Text) == "MESOI")
                {
                    with_1.Columns[MPCF.ToInt(LIST.USER_ID)].Visible = true;
                    with_1.Columns[MPCF.ToInt(LIST.VERSION)].Visible = true;
                    with_1.ColumnHeader.Cells[0, MPCF.ToInt(LIST.STATUS)].Text = "Printer Status";
                }
                else
                {
                    with_1.Columns[MPCF.ToInt(LIST.USER_ID)].Visible = false;
                    with_1.Columns[MPCF.ToInt(LIST.VERSION)].Visible = false;
                    //with_1.Columns[MPCF.ToInt(LIST.USER_ID)].Visible = false;
                    //with_1.Columns[MPCF.ToInt(LIST.USER_ID)].Visible = false;
                    with_1.ColumnHeader.Cells[0, MPCF.ToInt(LIST.STATUS)].Text = "Status";
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
        // ViewProdMonitoringList()
        //       - View Prod_Monitoring List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewProdMonitoringList()
        {
            TRSNode in_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            char i_Proc_Step = '2';
            try
            {
                MPCF.ClearList(spdList);
                
                MPCR.SetInMsg(in_node);

                spdList.ActiveSheet.RowCount = 0;

                in_node.AddString("CATEGORY", MPCF.Trim(cdvCategory.Text));
                in_node.AddString("BASE_CODE", MPCF.Trim(txtMainCode.Text));
                in_node.AddString("SUB_CODE", MPCF.Trim(txtSubCode.Text));

                if (MPCF.Trim(cdvCategory.Text) == "MESOI")
                {
                    i_Proc_Step = '2';
                }
                else if (MPCF.Trim(cdvCategory.Text) == "CIM")
                {
                    i_Proc_Step = '3';
                }
                else if (MPCF.Trim(cdvCategory.Text) == "MC")
                {
                    i_Proc_Step = '4';
                }
                else if (MPCF.Trim(cdvCategory.Text) == "FMB")
                {
                    i_Proc_Step = '5';
                }
                in_node.ProcStep = i_Proc_Step;

                do
                {
                    TRSNode out_node = new TRSNode("CPSM_VIEW_PROD_MONITORING_LIST_OUT");

                    if (MPCR.CallService("CPSM", "CPSM_View_Prod_Monitoring_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = spdList.ActiveSheet;
                int i = 0;

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> spd_list = out_node.GetList("PROD_MONITORING_LIST");
                    foreach (TRSNode node in spd_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(LIST.BASE_CODE), MPCF.Trim(node.GetString("BASE_CODE")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.SUB_CODE), MPCF.Trim(node.GetString("SUB_CODE")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DESC), MPCF.Trim(node.GetString("DESCRIPTION")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.LAST_TIME), MPCF.Trim(MPCF.MakeDateFormat(node.GetString("LAST_TRAN_TIME"))));
                        with_1.SetValue(i, MPCF.ToInt(LIST.BASE_DT), MPCF.Trim(node.GetInt("BASE_DT_TIME")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.USER_ID), MPCF.Trim(node.GetString("TRAN_USER_ID")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.VERSION), MPCF.Trim(node.GetString("CLIENT_VERSION")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.STATUS), MPCF.Trim(node.GetString("STATUS")));
                        with_1.SetValue(i, MPCF.ToInt(LIST.STATUS_MSG), MPCF.Trim(node.GetString("STATUS_MSG")));
                        if (MPCF.Trim(node.GetString("CMF_1")) == "DT")
                        {
                            with_1.Rows[i].BackColor = Color.MistyRose;
                        }
                        i++;
                    }
                }

                //lblDataCount.Text = spdList.ActiveSheet.RowCount.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmViewProdMonitoring_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                cdvCategory.Text = "MESOI";
                spdList.ActiveSheet.RowCount = 0;
                // TODO
                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if (ViewProdMonitoringList() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Key ID : " + MPCF.Trim(cdvCategory.Text) + "\r";
            MPCF.ExportToExcel(spdList, this.Text, sCond);            
        }

        private void cdvCategory_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCategory.Init();
                MPCF.InitListView(cdvCategory.GetListView);
                cdvCategory.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCategory.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCategory.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvCategory.GetListView, '1', "@CPSM_CATEGORY");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCategory_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                SetSheetHeader();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


    }
}
