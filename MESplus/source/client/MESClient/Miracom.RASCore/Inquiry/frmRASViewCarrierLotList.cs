//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewTool.vb
//   Description : View Resource Status Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  View_Tool_Type()              : View Tool Type information
//       -  View_Tool()              : View Tool information
//       -  SetGroupCmfItem()        : Set Group / Cmf Property to control
//       -  InitControl()            : Initial Group/Cmf Control
//       -  SetCmfItem()             : Set Cmf Property to control
//       -  SetGRPItem()             : Set Group  Property to control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by Jerome
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.RASCore
{
    public partial class frmRASViewCarrierLotList : Miracom.CliFrx.BaseForm04
    {

        #region " Windows Form auto generated code "
        
        public frmRASViewCarrierLotList()
        {
            InitializeComponent();
            //tabControl1.Resize += new EventHandler(MainForm_Resize);
            
            tabControl1.TabPages.Remove(tbpPage2);
            tabControl1.TabPages.Remove(tbpPage3);
            tabControl1.TabPages.Remove(tbpPage4);
            tabControl1.TabPages.Remove(tbpPage5);
            tabControl1.TabPages.Remove(tbpPage6);
            tabControl1.TabPages.Remove(tbpPage7);
            tabControl1.TabPages.Remove(tbpPage8);
            tabControl1.TabPages.Remove(tbpPage9);
            tabControl1.TabPages.Remove(tbpPage10);
            tabControl1.TabPages.Remove(tbpPage11);
        }
        
        #endregion

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        #endregion

        #region " Function Definition "

        //
        // View_Carrier_Lot_List()
        //       -  View Carrier Lot List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private void Display_Carrier_Info_In_Tab(TabPage tbp_page, FarPoint.Win.Spread.FpSpread spd_page, TRSNode crr_info)
        {
            int i;

            tabControl1.TabPages.Add(tbp_page);
            tbp_page.Text = MPCF.Trim(crr_info.GetString("CRR_ID"));

            spd_page.ActiveSheet.ColumnHeader.Visible = false;
            spd_page.ActiveSheet.RowHeader.Visible = false;
            spd_page.ActiveSheet.GrayAreaBackColor = Color.White;

            //Display the carrier information's on the Tab page 11
            spd_page.ActiveSheet.Cells[1, 0].Value = MPCF.Trim(crr_info.GetString("CRR_DESC"));
            spd_page.ActiveSheet.Cells[1, 1].Value = MPCF.Trim(crr_info.GetString("LOCATION"));
            spd_page.ActiveSheet.Cells[1, 2].Value = MPCF.Trim(crr_info.GetString("CRR_STATUS"));
            spd_page.ActiveSheet.Cells[1, 3].Value = MPCF.Trim(crr_info.GetString("CRR_TYPE1"));
            spd_page.ActiveSheet.Cells[1, 4].Value = MPCF.Trim(crr_info.GetInt("CRR_SIZE"));
            spd_page.ActiveSheet.Cells[1, 5].Value = MPCF.Trim(crr_info.GetString("PORT_ID"));
            spd_page.ActiveSheet.Cells[1, 6].Value = MPCF.Trim(crr_info.GetInt("USAGE_COUNT"));
            spd_page.ActiveSheet.Cells[1, 7].Value = MPCF.Trim(crr_info.GetInt("CLEAN_COUNT"));
            spd_page.ActiveSheet.RowCount = 4;

            //Display each wafer's informtion in the carrier on the Tab page 3
            for (i = 0; i < crr_info.GetList(0).Count; i++)
            {
                spd_page.ActiveSheet.RowCount++;
                spd_page.ActiveSheet.Cells[i + 4, 0].Value = MPCF.Trim(crr_info.GetList(0)[i].GetInt("SLOT_NO"));
                spd_page.ActiveSheet.Cells[i + 4, 1].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("SUBLOT_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 2].Value = MPCF.Trim(crr_info.GetList(0)[i].GetChar("GRADE"));
                spd_page.ActiveSheet.Cells[i + 4, 3].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("GRADE_CODE"));
                spd_page.ActiveSheet.Cells[i + 4, 4].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("LOT_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 5].Value = MPCF.Trim(crr_info.GetString("RES_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 6].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("SUBLOT_STATUS"));
                spd_page.ActiveSheet.Cells[i + 4, 7].Value = MPCF.Trim(crr_info.GetList(0)[i].GetChar("HOLD_FLAG"));
                spd_page.ActiveSheet.Cells[i + 4, 8].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("MAT_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 9].Value = MPCF.Trim(crr_info.GetList(0)[i].GetInt("MAT_VER"));
                spd_page.ActiveSheet.Cells[i + 4, 10].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("FLOW"));
                spd_page.ActiveSheet.Cells[i + 4, 11].Value = MPCF.Trim(crr_info.GetList(0)[i].GetInt("FLOW_SEQ_NUM"));
                spd_page.ActiveSheet.Cells[i + 4, 12].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("OPER"));
                spd_page.ActiveSheet.Cells[i + 4, 13].Value = MPCF.MakeDateFormat(crr_info.GetList(0)[i].GetString("START_TIME"));
                spd_page.ActiveSheet.Cells[i + 4, 14].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("START_RES_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 15].Value = MPCF.MakeDateFormat(crr_info.GetList(0)[i].GetString("END_TIME"));
                spd_page.ActiveSheet.Cells[i + 4, 16].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("END_RES_ID"));
                spd_page.ActiveSheet.Cells[i + 4, 17].Value = MPCF.Trim(crr_info.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                spd_page.ActiveSheet.Cells[i + 4, 18].Value = MPCF.MakeDateFormat(crr_info.GetList(0)[i].GetString("LAST_TRAN_TIME"));
            
            }
            //Auto adjust the data in the column
            MPCF.FitColumnHeader(spd_page);
        }

        private bool View_Carrier_Lot_List()
        {
            //Initializing the object for Lot status
            TRSNode in_node = new TRSNode("View_Carrier_Lot_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Carrier_Lot_List_Detail_Out");
            TRSNode crr_item;
                       
            int i,iSublotCount;
            int iRow;

            MPCF.ClearList(spdPage1, true);

            //use transaction case 2 for Lot Status and Carrier Def
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            // Set the next slot id and carrier id to be zero and empty respectively            
            in_node.AddInt("NEXT_SLOT_NO", 0);
            in_node.AddString("NEXT_CRR_ID", " ");
            
            //Get the optional lot ID or carrier ID from the form
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("CRR_ID", MPCF.Trim(cdvCarrierID.Text));

            //Retriving the information from the DB for both lot and carrier
            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                //fill in all the lot tab page columns
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    crr_item = out_node.GetList(0)[i];
                    //if there is no sublot information then break out of the loop
                    if (crr_item.GetList(0).Count == 0)
                        //break;
                        continue;

                    
                    //Fill in the information of all the sublot in carrier
                    for (iSublotCount = 0; iSublotCount < crr_item.GetList(0).Count; iSublotCount++)
                    {
                        //setting resizable to be true on the fpSpread1.Sheets
                        spdPage1.ActiveSheet.RowHeader.Columns.Default.Resizable = true;

                        iRow = spdPage1.ActiveSheet.RowCount;
                        spdPage1.ActiveSheet.RowCount++;

                        //Get this value from the MWIPSLTSTS DB table
                        spdPage1.ActiveSheet.Cells[iRow, 0].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetInt("SLOT_NO"));
                        spdPage1.ActiveSheet.Cells[iRow, 1].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("SUBLOT_ID"));
                        spdPage1.ActiveSheet.Cells[iRow, 2].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetChar("GRADE"));
                        spdPage1.ActiveSheet.Cells[iRow, 3].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("GRADE_CODE"));
                        spdPage1.ActiveSheet.Cells[iRow, 4].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("LOT_ID"));
                        spdPage1.ActiveSheet.Cells[iRow, 5].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("CRR_ID"));

                        //Get this value from the MRASCRRDEF DB table
                        spdPage1.ActiveSheet.Cells[iRow, 6].Value = MPCF.Trim(crr_item.GetString("CRR_STATUS"));
                        spdPage1.ActiveSheet.Cells[iRow, 7].Value = MPCF.Trim(crr_item.GetString("CRR_TYPE1"));
                        spdPage1.ActiveSheet.Cells[iRow, 8].Value = MPCF.Trim(crr_item.GetString("RES_ID"));

                        //Get this value from the MWIPSLTSTS DB table
                        spdPage1.ActiveSheet.Cells[iRow, 9].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("SUBLOT_STATUS"));
                        spdPage1.ActiveSheet.Cells[iRow, 10].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetChar("HOLD_FLAG"));
                        spdPage1.ActiveSheet.Cells[iRow, 11].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("MAT_ID"));
                        spdPage1.ActiveSheet.Cells[iRow, 12].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetInt("MAT_VER"));
                        spdPage1.ActiveSheet.Cells[iRow, 13].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("FLOW"));
                        spdPage1.ActiveSheet.Cells[iRow, 14].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetInt("FLOW_SEQ_NUM"));
                        spdPage1.ActiveSheet.Cells[iRow, 15].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("OPER"));
                        spdPage1.ActiveSheet.Cells[iRow, 16].Value = MPCF.MakeDateFormat(crr_item.GetList(0)[iSublotCount].GetString("START_TIME"));
                        spdPage1.ActiveSheet.Cells[iRow, 17].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("START_RES_ID"));
                        spdPage1.ActiveSheet.Cells[iRow, 18].Value = MPCF.MakeDateFormat(crr_item.GetList(0)[iSublotCount].GetString("END_TIME"));
                        spdPage1.ActiveSheet.Cells[iRow, 19].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("END_RES_ID"));
                        spdPage1.ActiveSheet.Cells[iRow, 20].Value = MPCF.Trim(crr_item.GetList(0)[iSublotCount].GetString("LAST_TRAN_CODE"));
                        spdPage1.ActiveSheet.Cells[iRow, 21].Value = MPCF.MakeDateFormat(crr_item.GetList(0)[iSublotCount].GetString("LAST_TRAN_TIME"));
                    }
                    
                    //show the carrier information on the tab page (max 10 carrier records)
                    if (i <= 10)
                    {
                            if ( i == 0)
                                Display_Carrier_Info_In_Tab(tbpPage2, spdPage2, out_node.GetList(0)[i]);
                            if ( i == 1)
                                Display_Carrier_Info_In_Tab(tbpPage3, spdPage3, out_node.GetList(0)[i]);
                            if ( i == 2)
                                Display_Carrier_Info_In_Tab(tbpPage4, spdPage4, out_node.GetList(0)[i]);
                            if ( i == 3)
                                Display_Carrier_Info_In_Tab(tbpPage5, spdPage5, out_node.GetList(0)[i]);
                            if ( i == 4)
                                Display_Carrier_Info_In_Tab(tbpPage6, spdPage6, out_node.GetList(0)[i]);
                            if ( i == 5)
                                Display_Carrier_Info_In_Tab(tbpPage7, spdPage7, out_node.GetList(0)[i]);
                            if ( i == 6)
                                Display_Carrier_Info_In_Tab(tbpPage8, spdPage8, out_node.GetList(0)[i]);
                            if ( i == 7)
                                Display_Carrier_Info_In_Tab(tbpPage9, spdPage9, out_node.GetList(0)[i]);
                            if ( i == 8)
                                Display_Carrier_Info_In_Tab(tbpPage10, spdPage10, out_node.GetList(0)[i]);
                            if (i == 9 )
                                Display_Carrier_Info_In_Tab(tbpPage11, spdPage11, out_node.GetList(0)[i]);
                        }
                    }

                    in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));
                    in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
                } while (in_node.GetString("NEXT_CRR_ID") != "" || in_node.GetInt("NEXT_SLOT_NO") > 0);

            MPCF.FitColumnHeader(spdPage1);
            return true;
        }

      #endregion


        private void btnView_Click(object sender, EventArgs e)
        {
            if ((MPCF.Trim(txtLotID.Text) == "") && (MPCF.Trim(cdvCarrierID.Text) == ""))
            {
                // Show the error message which can be defined in the MESMessage.xml file under MESCLient folder
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            else
            {
                tabControl1.TabPages.Remove(tbpPage2);
                tabControl1.TabPages.Remove(tbpPage3);
                tabControl1.TabPages.Remove(tbpPage4);
                tabControl1.TabPages.Remove(tbpPage5);
                tabControl1.TabPages.Remove(tbpPage6);
                tabControl1.TabPages.Remove(tbpPage7);
                tabControl1.TabPages.Remove(tbpPage8);
                tabControl1.TabPages.Remove(tbpPage9);
                tabControl1.TabPages.Remove(tbpPage10);
                tabControl1.TabPages.Remove(tbpPage11);
                View_Carrier_Lot_List();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
                string sCond;

                sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text) + "\r";
                sCond = sCond + "Material : " + MPCF.Trim(cdvCarrierID.Text);

                 if (tabControl1.SelectedTab == tbpPage1)
                {
                    if (MPCF.ExportToExcel(spdPage1, this.Text, sCond, true, true, true, -1, -1) == false)
                        return;
                }
                else if (tabControl1.SelectedTab == tbpPage2)
                {
                    if (MPCF.ExportToExcel(spdPage2, this.Text, sCond, true, true, true, -1, -1) == false)     
                        return;
                }
                else if (tabControl1.SelectedTab == tbpPage3)
                {
                    if (MPCF.ExportToExcel(spdPage3, this.Text, sCond, true, true, true, -1, -1) == false)
                        return;        
                }
                else if (tabControl1.SelectedTab == tbpPage4)
                {
                    if (MPCF.ExportToExcel(spdPage4, this.Text, sCond, true, true, true, -1, -1) == false)
                        return;
                }
                else if (tabControl1.SelectedTab == tbpPage5)
                {
                    if (MPCF.ExportToExcel(spdPage5, this.Text, sCond, true, true, true, -1, -1) == false)
                        return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage6)
                 {
                     if (MPCF.ExportToExcel(spdPage6, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage7)
                 {
                     if (MPCF.ExportToExcel(spdPage7, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage8)
                 {
                     if (MPCF.ExportToExcel(spdPage8, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage9)
                 {
                     if (MPCF.ExportToExcel(spdPage9, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage10)
                 {
                     if (MPCF.ExportToExcel(spdPage10, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
                 else if (tabControl1.SelectedTab == tbpPage11)
                 {
                     if (MPCF.ExportToExcel(spdPage11, this.Text, sCond, true, true, true, -1, -1) == false)
                         return;
                 }
        }

        private void cdvCarrierID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) == "" && MPCF.Trim(cdvCarrierType.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvCarrierID.Text) == "")
                    {
                        cdvCarrierID.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvCarrierID.Focus();
                        return;
                    }
                }
            }

            cdvCarrierID.Init();
            MPCF.InitListView(cdvCarrierID.GetListView);
            cdvCarrierID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCarrierID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCarrierID.SelectedSubItemIndex = 0;
         
            RASLIST.ViewCarrierList(cdvCarrierID.GetListView, '1', cdvCrrGroup.Text, cdvCarrierType.Text, txtLotID.Text, cdvCarrierID.Text);
            cdvCarrierID.InsertEmptyRow(0,1);
        }

        private void cdvCarrierType_ButtonPress(object sender, EventArgs e)
        {
            cdvCarrierType.Init();
            MPCF.InitListView(cdvCarrierType.GetListView);
            cdvCarrierType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvCarrierType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCarrierType.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvCarrierType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            cdvCarrierType.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
            cdvCrrGroup.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) != "")
            {
                cdvCarrierID.Text = "";
            }
        }

        private void frmRASViewCarrierLotList_Activated(object sender, EventArgs e)
        {
            if (MPGO.RequireCarrierFilter() == true)
            {
                lblOr.Visible = true;
            }
        }
      
    }
}


