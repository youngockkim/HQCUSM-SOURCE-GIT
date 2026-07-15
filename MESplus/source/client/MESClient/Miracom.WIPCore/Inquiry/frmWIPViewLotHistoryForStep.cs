
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewLotHistoryForStep.cs
//   Description : MES Cient Form View Lot History For Step
//
//   MES Version : 5.2.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-01-09 : Created by Simon Kim
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

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPViewLotHistoryForStep : Miracom.MESCore.ViewForm01
    {
        public frmWIPViewLotHistoryForStep()
        {
            InitializeComponent();
        }

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
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":

                    if (dtpFrom.Value > dtpTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(120));
                        dtpFrom.Value = DateTime.Today.AddMonths(-1);
                        return false;
                    }
                    break;

            }

            return true;

        }
        // View_Lot_Info()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Lot_Info(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtLotDesc.Text = out_node.GetString("LOT_DESC");

            return true;

        }


        // View_History_For_Step()
        //       -   View Lot History For Step
        // Return Value
        //       -
        // Arguments
        //       -
        private void View_History_For_Step()
        {

            string sFromTime;
            string sToTime;
            char sIncludeDelHistory;

            if (txtLotID.Text != "")
            {
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);

                if (chkIncludeDelHistory.Checked == true)
                {
                    sIncludeDelHistory = 'Y';
                }
                else
                {
                    sIncludeDelHistory = ' ';
                }


                if (WIPLIST.ViewLotHistoryForStep(spdHistory, '1', txtLotID.Text, sFromTime, sToTime, sIncludeDelHistory, null, false) == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(spdHistory);

            }

        }

        #endregion

        private void frmWIPViewLotHistoryForStep_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.ClearList(spdHistory, true);
                MPCF.FitColumnHeader(spdHistory);

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    View_History_For_Step();
                }

                b_load_flag = true;
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MPCF.ClearList(spdHistory, true);
                if (View_Lot_Info('2', txtLotID.Text) == false)
                {
                    return;
                }
                if (CheckCondition("VIEW") == false)
                {
                    View_History_For_Step();
                }                
            }
        }

        private void txtLotID_TextChanged(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.ClearList(spdHistory, true);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);

            if (View_Lot_Info('2', txtLotID.Text) == false)
            {
                return;
            }

            if (CheckCondition("VIEW") == true)
            {
                View_History_For_Step();
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
                        
            if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }            
        }
    }
}
