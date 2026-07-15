//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmBASViewGeneralCodeDataHistory.cs
//   Description : View General Code Data History
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewData() : View Data definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-04-24 16:14:11 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
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

namespace Miracom.BASCore
{
    public partial class frmBASViewGeneralCodeDataHistory : ViewForm01
    {
        public frmBASViewGeneralCodeDataHistory()
        {
            InitializeComponent();
        }


        #region " Constant Definition "

        private enum COLS_HIST_LIST
        {
            HIST_SEQ = 0,
            TRAN_TIME,
            KEY_1,
            KEY_2,
            KEY_3,
            KEY_4,
            KEY_5,
            KEY_6,
            KEY_7,
            KEY_8,
            KEY_9,
            KEY_10,
            DATA_1,
            DATA_2,
            DATA_3,
            DATA_4,
            DATA_5,
            DATA_6,
            DATA_7,
            DATA_8,
            DATA_9,
            DATA_10,
            OLD_DATA_1,
            OLD_DATA_2,
            OLD_DATA_3,
            OLD_DATA_4,
            OLD_DATA_5,
            OLD_DATA_6,
            OLD_DATA_7,
            OLD_DATA_8,
            OLD_DATA_9,
            OLD_DATA_10,
            DEL_FLAG,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME,
            TRAN_USER_ID
        }



        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        private string s_table_name;
        public string TableName
        {
            set
            {
                this.s_table_name = value;
                if (this.b_load_flag == true)
                {
                    //cdvTableName.Text = value;
                    txtTableName.Text = value;
                    btnView.PerformClick();
                }
            }
        }

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
            //return this.cdvTableName;
            return this.txtTableName;
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
            //if (MPCF.CheckValue(cdvTableName, 1) == false)
            if (MPCF.CheckValue(txtTableName, 1) == false)
            {
                return false;
            }

            return true;            
        }

        //
        // BASViewDataHistory()
        //       - View General Code Data History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewDataHistory()
        {
            TRSNode in_node = new TRSNode("BAS_VIEW_DATA_HISTORY_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(spdHistory);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //in_node.AddString("TABLE_NAME", cdvTableName.Text);
                in_node.AddString("TABLE_NAME", txtTableName.Text);
                in_node.AddInt("NEXT_HIST_SEQ", Int32.MaxValue);
                in_node.AddString("KEY_1", txtKey1.Text);
                in_node.AddString("KEY_2", txtKey2.Text);
                in_node.AddString("KEY_3", txtKey3.Text);
                in_node.AddString("KEY_4", txtKey4.Text);
                in_node.AddString("KEY_5", txtKey5.Text);
                in_node.AddString("KEY_6", txtKey6.Text);
                in_node.AddString("KEY_7", txtKey7.Text);
                in_node.AddString("KEY_8", txtKey8.Text);
                in_node.AddString("KEY_9", txtKey9.Text);
                in_node.AddString("KEY_10", txtKey10.Text);
                in_node.AddString("FROM_TIME", MPCF.FromDate((DateTimePicker)dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate((DateTimePicker)dtpTo));

                do
                {
                    TRSNode out_node = new TRSNode("BAS_VIEW_DATA_HISTORY_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Data_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    int i_row;
                    List<TRSNode> hist_list = out_node.GetList("HIST_LIST");
                    foreach (TRSNode node in hist_list)
                    {
                        i_row = spdHistory.ActiveSheet.RowCount;
                        spdHistory.ActiveSheet.RowCount++;

                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.HIST_SEQ].Value = node.GetInt("HIST_SEQ");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_1].Value = node.GetString("KEY_1");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_2].Value = node.GetString("KEY_2");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_3].Value = node.GetString("KEY_3");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_4].Value = node.GetString("KEY_4");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_5].Value = node.GetString("KEY_5");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_6].Value = node.GetString("KEY_6");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_7].Value = node.GetString("KEY_7");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_8].Value = node.GetString("KEY_8");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_9].Value = node.GetString("KEY_9");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.KEY_10].Value = node.GetString("KEY_10");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_1].Value = node.GetString("DATA_1");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_2].Value = node.GetString("DATA_2");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_3].Value = node.GetString("DATA_3");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_4].Value = node.GetString("DATA_4");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_5].Value = node.GetString("DATA_5");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_6].Value = node.GetString("DATA_6");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_7].Value = node.GetString("DATA_7");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_8].Value = node.GetString("DATA_8");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_9].Value = node.GetString("DATA_9");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DATA_10].Value = node.GetString("DATA_10");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_1].Value = node.GetString("OLD_DATA_1");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_2].Value = node.GetString("OLD_DATA_2");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_3].Value = node.GetString("OLD_DATA_3");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_4].Value = node.GetString("OLD_DATA_4");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_5].Value = node.GetString("OLD_DATA_5");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_6].Value = node.GetString("OLD_DATA_6");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_7].Value = node.GetString("OLD_DATA_7");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_8].Value = node.GetString("OLD_DATA_8");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_9].Value = node.GetString("OLD_DATA_9");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.OLD_DATA_10].Value = node.GetString("OLD_DATA_10");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.DEL_FLAG].Value = node.GetChar("DEL_FLAG");
                        if (node.GetChar("DEL_FLAG") == 'Y')
                        {
                            spdHistory.ActiveSheet.Rows[i_row].BackColor = Color.Magenta;
                        }
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.CREATE_USER_ID].Value = node.GetString("CREATE_USER_ID");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(node.GetString("CREATE_TIME"));
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.UPDATE_USER_ID].Value = node.GetString("UPDATE_USER_ID");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(node.GetString("UPDATE_TIME"));
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.TRAN_USER_ID].Value = node.GetString("TRAN_USER_ID");
                        spdHistory.ActiveSheet.Cells[i_row, (int)COLS_HIST_LIST.TRAN_TIME].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));
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


        #endregion

        private void frmBASViewGeneralCodeDataHistory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory);

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                if (string.IsNullOrEmpty(this.s_table_name) == false)
                {
                    //cdvTableName.Text = this.s_table_name;
                    txtTableName.Text = this.s_table_name;
                    btnView.PerformClick();
                }
                
                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if(ViewDataHistory() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            //sCond = "Table Name : " + MPCF.Trim(cdvTableName.Text) + "\r";
            sCond = "Table Name : " + MPCF.Trim(txtTableName.Text) + "\r";
            sCond += "Key 1 : " + MPCF.Trim(txtKey1.Text) + "\r";
            sCond += "Key 2 : " + MPCF.Trim(txtKey2.Text) + "\r";
            sCond += "Key 3 : " + MPCF.Trim(txtKey3.Text) + "\r";
            sCond += "Key 4 : " + MPCF.Trim(txtKey4.Text) + "\r";
            sCond += "Key 5 : " + MPCF.Trim(txtKey5.Text) + "\r";
            sCond += "Key 6 : " + MPCF.Trim(txtKey6.Text) + "\r";
            sCond += "Key 7 : " + MPCF.Trim(txtKey7.Text) + "\r";
            sCond += "Key 8 : " + MPCF.Trim(txtKey8.Text) + "\r";
            sCond += "Key 9 : " + MPCF.Trim(txtKey9.Text) + "\r";
            sCond += "Key 10 : " + MPCF.Trim(txtKey10.Text) + "\r";

            sCond += "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdHistory, this.Text, sCond);            
        }

        private void cdvTableName_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvTableName.Init();
                MPCF.InitListView(cdvTableName.GetListView);
                cdvTableName.Columns.Add("Table", 150, HorizontalAlignment.Left);
                cdvTableName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvTableName.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMTableList(cdvTableName.GetListView, '1');
                cdvTableName.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }


    }
}
