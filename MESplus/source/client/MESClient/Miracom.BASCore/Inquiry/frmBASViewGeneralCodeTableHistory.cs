//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmBASViewGeneralCodeTableHistory.cs
//   Description : View General Code Table History
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewTable() : View Table definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-04-13 13:37:06 : XXXX Created by generator in DEV Tools
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
    public partial class frmBASViewGeneralCodeTableHistory : ViewForm01
    {
        public frmBASViewGeneralCodeTableHistory()
        {
            InitializeComponent();
        }


        #region " Constant Definition "




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
        // BASViewTableHistory()
        //       - Views the table history of GCM table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewTableHistory()
        {
            TRSNode in_node = new TRSNode("BAS_VIEW_TABLE_HISTORY_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            int i_row;

            try
            {
                MPCF.ClearList(spdHistory);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

//                in_node.AddString("TABLE_NAME", cdvTableName.Text);
                in_node.AddString("TABLE_NAME", txtTableName.Text);
                in_node.AddString("FROM_TIME", MPCF.FromDate((DateTimePicker)dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate((DateTimePicker)dtpTo));
                in_node.AddInt("NEXT_HIST_SEQ", Int32.MaxValue);

                do
                {
                    TRSNode out_node = new TRSNode("BAS_VIEW_TABLE_HISTORY_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Table_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.AddRange(out_node.GetList("HIST_LIST"));

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                if (out_list.Count < 1) return true;

                i_row = 0;
                spdHistory.ActiveSheet.AddRows(i_row, out_list.Count);
                foreach (TRSNode node in out_list)
                {
                    int col = 0;
                    spdHistory.ActiveSheet.Cells[i_row, col++].Text = MPCF.Trim(node.GetInt("HIST_SEQ"));
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = MPCF.MakeDateFormat(node.GetString("TRAN_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetChar("SYS_TBL_FLAG");
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetChar("CENTRAL_FLAG");
                    if (node.GetChar("TABLE_TYPE") != ' ')
                    {
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = Enum.GetName(typeof(GCM_TABLE_TYPE), node.GetChar("TABLE_TYPE"));
                    }
                    else
                    {
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = ' ';
                    }
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetChar("USE_SQL_FLAG");
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString("TABLE_GROUP");
                        
                    for (int i = 1; i <= 10; i++)
                    {
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("KEY_{0}_PRT", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = Enum.GetName(typeof(VAR_TYPE), node.GetChar(String.Format("KEY_{0}_FMT", i)));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetInt(String.Format("KEY_{0}_SIZE", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("KEY_{0}_TBL", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("KEY_{0}_COL", i));
                    }
                    for (int i = 1; i <= 10; i++)
                    {
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("DATA_{0}_PRT", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = Enum.GetName(typeof(VAR_TYPE), node.GetChar(String.Format("DATA_{0}_FMT", i)));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetInt(String.Format("DATA_{0}_SIZE", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("DATA_{0}_TBL", i));
                        spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString(String.Format("DATA_{0}_COL", i));
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append(node.GetString("SQL_1")).Append(node.GetString("SQL_2")).Append(node.GetString("SQL_3"))
                        .Append(node.GetString("SQL_4")).Append(node.GetString("SQL_5"));
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = sb.ToString();
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetChar("SEC_CHK_FLAG");
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetChar("DEL_FLAG");
                    if (node.GetChar("DEL_FLAG") == 'Y')
                    {
                        spdHistory.ActiveSheet.Rows[i_row].BackColor = Color.Magenta;
                    }
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString("CREATE_USER_ID");
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = MPCF.MakeDateFormat(node.GetString("CREATE_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString("UPDATE_USER_ID");
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = MPCF.MakeDateFormat(node.GetString("UPDATE_TIME"));
                    spdHistory.ActiveSheet.Cells[i_row, col++].Value = node.GetString("TRAN_USER_ID");
                    i_row++;
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

        private void frmBASViewGeneralCodeTableHistory_Activated(object sender, System.EventArgs e)
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
            //if (String.IsNullOrEmpty(cdvTableName.Text)) return;
            if (String.IsNullOrEmpty(txtTableName.Text)) return;

            if(ViewTableHistory() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            //sCond = "Table Name : " + MPCF.Trim(cdvTableName.Text) + "\r";
            sCond = "Table Name : " + MPCF.Trim(txtTableName.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
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

        private void cdvTableName_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            //btnView.PerformClick();
        }


    }
}
