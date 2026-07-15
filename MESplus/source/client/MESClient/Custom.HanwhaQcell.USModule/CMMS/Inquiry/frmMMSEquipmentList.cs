//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSEquipmentList.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-04-10 15:25:03 : XXXX Created by generator in DEV Tools
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
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSEquipmentList : BaseForm04
    {
        public frmMMSEquipmentList()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum LIST : int
        {
            EQUIP_TYPE,
            TYPE_NAME,
            EQUIP_ID,
            EQUIP_NAME,
            DEPT_CODE,
            DEPT_NAME,
            PLACE_CODE,
            PLACE_NAME,
            USE_DIV,
            DIV_NAME,
            MAKER,
            MODEL,
            SERIAL,
            CALI_DATE,
            RESULT,
            PLAN_DATE,
            REMAIN_DAYS,
            INSP_CODE,
            INSP_NAME,
            DESC
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
            return this.cdvEquipType;
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
        // ViewEquipmentLedgerList()
        //       - View Equipment_Ledger List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentLedgerList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            string sRemainFlag = ""; //ZPMN
            try
            {
                MPCF.ClearList(grbMain);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("EQUIP_ID", cdvEquipCode.Text);
                in_node.AddString("EQUIP_TYPE", cdvEquipType.Text);
                in_node.AddString("USE_DEPT_CODE", cdvUseDept.Text);
                in_node.AddString("EQUIP_PLACE_CODE", cdvInstPalce.Text);
                if (rdoActive.Checked == true)
                {
                    in_node.AddString("USE_DIV", "0");
                }
                else if (rdoTrouble.Checked == true)
                {
                    in_node.AddString("USE_DIV", "1");
                }
                else if (rdoInactive.Checked == true)
                {
                    in_node.AddString("USE_DIV", "2");
                }
                if (chkCaliPlanDate.Checked == true)
                {
                    in_node.AddString("PLAN_FR_DATE", dtpPlanFromDate.Value.ToString("yyyyMMdd"));
                    in_node.AddString("PLAN_TO_DATE", dtpPlanToDate.Value.ToString("yyyyMMdd"));
                }

                if (chkRemainDay.Checked == true)
                {
                    if (chkToZero.Checked == true) sRemainFlag += "Z";
                    if (chkNothing.Checked == true) sRemainFlag += "N";
                    if (chkoOneToMillion.Checked == true) sRemainFlag += "M";
                    if (chkMillionTo.Checked == true) sRemainFlag += "P";
                }
                else
                {
                    sRemainFlag = "ZPMN";
                }
                in_node.AddString("REMAIN_FLAG", sRemainFlag);

                spdEquipList.ActiveSheet.RowCount = 0;

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_CMMS_Equip_List_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                    in_node.SetString("NEXT_EQUIP_ID", out_node.GetString("NEXT_EQUIP_ID"));

                } while (in_node.GetString("NEXT_EQUIP_ID") != "");

                FarPoint.Win.Spread.SheetView with_1 = spdEquipList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_ledger_list = out_node.GetList("CMMS_EQUIP_LIST");
                    foreach (TRSNode node in equipment_ledger_list)
                    {
                        with_1.RowCount = i + 1;

                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_TYPE), node.GetString("EQUIP_TYPE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.TYPE_NAME), node.GetString("EQUIP_TYPE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DEPT_CODE), node.GetString("USE_DEPT_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DEPT_NAME), node.GetString("USE_DEPT_NAME"));

                        with_1.SetValue(i, MPCF.ToInt(LIST.PLACE_CODE), node.GetString("EQUIP_PLACE_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLACE_NAME), node.GetString("EQUIP_PLACE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.USE_DIV), node.GetString("USE_DIV"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DIV_NAME), node.GetString("DIV_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.MAKER), node.GetString("EQUIP_MAKER"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.MODEL), node.GetString("EQUIP_MODEL"));

                        with_1.SetValue(i, MPCF.ToInt(LIST.SERIAL), node.GetString("SERIAL_NO"));
                        if (MPCF.Trim(node.GetString("LAST_CALI_DATE")) != "")
                            with_1.SetValue(i, MPCF.ToInt(LIST.CALI_DATE), MPCF.MakeDateFormat(node.GetString("LAST_CALI_DATE"), DATE_TIME_FORMAT.DATE));
                        else
                            with_1.SetValue(i, MPCF.ToInt(LIST.CALI_DATE), "");

                        with_1.SetValue(i, MPCF.ToInt(LIST.RESULT), node.GetString("LAST_CALI_RESULT"));

                        if (MPCF.Trim(node.GetString("NEXT_CALI_DATE")) != "")
                            with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("NEXT_CALI_DATE"), DATE_TIME_FORMAT.DATE));
                        else
                            with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_DATE), "");

                        with_1.SetValue(i, MPCF.ToInt(LIST.REMAIN_DAYS), node.GetString("REMAIN_DAY"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.INSP_CODE), node.GetString("CALI_INSTITUTE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.INSP_NAME), node.GetString("CALI_INS_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DESC), node.GetString("EQUIP_DESC"));
                        if (MPCF.Trim(node.GetString("REMAIN_DAY")) != "-" && MPCF.Trim(node.GetString("REMAIN_DAY")) != "")
                        {
                            int i_days = MPCF.ToInt(MPCF.ToDbl(node.GetString("REMAIN_DAY")) - 0.49);
                            with_1.SetValue(i, MPCF.ToInt(LIST.REMAIN_DAYS), i_days);
                            
                            if (i_days < 100 && i_days > 0)
                            {
                                with_1.Cells[i, MPCF.ToInt(LIST.EQUIP_ID)].BackColor = Color.DarkTurquoise;
                            }
                            else if (i_days < 1)
                            {
                                with_1.Cells[i, MPCF.ToInt(LIST.EQUIP_ID)].BackColor = Color.Crimson;
                            }
                            else if (i_days > 99)
                            {
                                with_1.Cells[i, MPCF.ToInt(LIST.EQUIP_ID)].BackColor = Color.LightCyan;
                            }
                        }


                        i++;
                    }
                }

                //with_1.Rows[0].Height

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        private void frmMMSEquipmentList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);

                this.spdEquipList.ActiveSheet.RowCount = 0;
                spdEquipList.ActiveSheet.FrozenColumnCount = (int)LIST.DEPT_CODE;

                dtpPlanFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpPlanToDate.Value = DateTime.Now.AddMonths(1);

                rdoActive.Checked = true;

                dtpPlanFromDate.Enabled = false;
                dtpPlanToDate.Enabled = false;
                grpRemainDay.Enabled = false;

                chkToZero.Checked = false;
                chkoOneToMillion.Checked = false;
                chkMillionTo.Checked = false;
                chkNothing.Checked = false;


                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if (ViewEquipmentLedgerList() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            sCond = "Key ID : " + MPCF.Trim(this.Text) + "\r";
            //sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpPlanFromDate)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpPlanToDate));
            Custom.Common.HQCE.ExportToExcel(spdEquipList, this.Text, sCond, true, true, true, -1, -1, 0, false);     
        }

        private void cdvEquipCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEquipCode.Init();
                MPCF.InitListView(cdvEquipCode.GetListView);
                cdvEquipCode.Columns.Add("Code", 100, HorizontalAlignment.Left);
                cdvEquipCode.Columns.Add("Desc", 150, HorizontalAlignment.Left);
                if (HQCF.ViewStandardEquipmentList(cdvEquipCode.GetListView, '5', 'Y', MPCF.Trim(cdvEquipType.Text)) == true)
                {
                    cdvEquipCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUseDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUseDept.Init();
                MPCF.InitListView(cdvUseDept.GetListView);
                cdvUseDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvUseDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvUseDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvUseDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvUseDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvInstPalce_ButtonPress(object sender, EventArgs e)
        {
            cdvInstPalce.Init();
            MPCF.InitListView(cdvInstPalce.GetListView);
            cdvInstPalce.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvInstPalce.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvInstPalce.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvInstPalce.GetListView, '1', MPGC.MP_GCM_MMS_PLACE_CODE) == true)
            {
                cdvInstPalce.InsertEmptyRow(0, 1);
            }
        }

        private void cdvEquipType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEquipType.Init();
                MPCF.InitListView(cdvEquipType.GetListView);
                cdvEquipType.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvEquipType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvEquipType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvEquipType.GetListView, '1', MPGC.MP_GCM_MMS_EQUIP_TYPE) == true)
                {
                    cdvEquipType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkCaliPlanDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPlanFromDate.Enabled = chkCaliPlanDate.Checked;
            dtpPlanToDate.Enabled = chkCaliPlanDate.Checked;
        }

        private void chkRemainDay_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRemainDay.Checked == true)
            {
                grpRemainDay.Enabled = true;
            }
            else
            {
                grpRemainDay.Enabled = false;
                chkToZero.Checked = false;
                chkoOneToMillion.Checked = false;
                chkMillionTo.Checked = false;
                chkNothing.Checked = false;
            }

        }

    }
}
