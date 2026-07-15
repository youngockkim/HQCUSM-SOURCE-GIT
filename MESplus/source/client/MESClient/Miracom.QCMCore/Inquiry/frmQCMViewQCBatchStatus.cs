
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmQCMViewQCBatchStatus.vb
//   Description : View QC Batch Status
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Request_Reinspection() : Result Record transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public partial  class frmQCMViewQCBatchStatus : Miracom.MESCore.ViewForm01
    {
        public frmQCMViewQCBatchStatus()
        {
            InitializeComponent();
        }

        #region " Constant Definition"

        private const int COL_INSP_ITEM = 0;
        private const int COL_INSP_ITEM_DESC = 1;
        private const int COL_INSP_METHOD = 2;
        private const int COL_SMP_PROC = 3;
        private const int COL_SMP_PROC_TYPE = 4;
        private const int COL_SMP_PROC_RATE = 5;
        private const int COL_FIX_SMP_QTY = 6;
        private const int COL_SMP_PROC_UNIT = 7;
        private const int COL_DET_VALUE = 8;
        private const int COL_DET_UNIT = 9;
        private const int COL_CHK_DET_FLAG = 10;
        private const int COL_SAMP_QTY = 11;
        private const int COL_TEST_QTY = 12;
        private const int COL_DEFECT_QTY = 13;
        private const int COL_DEFECT_CODE = 14;
        private const int COL_RESULT = 15;
        private const int COL_COMMENT = 16;
        private const int COL_TRAN_TIME = 17;
        private const int COL_USER = 18;
        private const int COL_DEFECT_GROUP = 19;

        #endregion

        #region " Variable Definition "

        private bool bLoadFlag;
        private int iCurRow = -1;
        private int iPreRow = -1;

        public struct Defect
        {
            public string DefectCode;
            public double Qty;
        }

        public struct Defect_Tag
        {
            public double DefectQty;
            public Defect[] Defect;
        }

        private Defect_Tag[] DefectList;

        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {

            try
            {
                switch (ProcStep)
                {
                    case '1':

                        MPCF.FieldClear(this);
                        ctrlBatchInfo.ClearBatchInfo();
                        MPCF.ClearList(spdInspItem, true);
                        MPCF.ClearList(spdDefect, true);
                        spdDefect.Sheets[0].Rows.Count = 20;
                        break; 
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        } 

        private bool View_Batch_Item_List(string sInspItem)
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_ITEM_LIST_OUT");

            ListViewItem itmX;
            int i;

            try
            {

                MPCF.InitListView(lisItem);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("BATCH_HIST_SEQ", ctrlBatchInfo.HistSeq);
                in_node.AddString("INSP_SET_ID", ctrlBatchInfo.InspSet);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                in_node.AddString("INSP_ITEM", sInspItem);
                in_node.AddString("NEXT_ITEM_ID", "");

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Batch_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(System.Convert.ToString(i + 1));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_ID"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("ITEM_QTY_1").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RESULT_FLAG").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DEFECT_CODE"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ISP_COMMENT"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_STATUS"));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_ID"));

                        lisItem.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_ITEM_ID", out_node.GetString("NEXT_ITEM_ID"));

                } while (in_node.GetString("NEXT_ITEM_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }


        private bool View_Attach_Insp_Item_List_Detail(string sBatchId, string sInsptSet, int iInspSetVer)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_DETAIL_OUT");

            int i;
            int j;
            int iCount;
            int iDefectCount;
            int LastRow = 0;

            try
            {
                //InitListView(lisInspItem)
                spdInspItem.Sheets[0].Rows.Count = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("BATCH_ID", MPCF.Trim(sBatchId));
                in_node.AddString("INSP_SET_ID", MPCF.Trim(sInsptSet));
                in_node.AddInt("INSP_SET_VERSION", iInspSetVer);
                in_node.AddInt("NEXT_SEQ_NUM", 0);

                do
                {

                    if (MPCR.CallService("QCM", "QCM_View_Attach_Insp_Item_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    iCount = out_node.GetList(0).Count;
                    DefectList = new Defect_Tag[iCount - 1 + 1];
                    spdInspItem.Sheets[0].Rows.Count = iCount;

                    for (i = 0; i <= iCount - 1; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                        with_1.SetValue(LastRow, COL_INSP_ITEM, out_node.GetList(0)[i].GetString("INSP_ITEM"));
                        with_1.SetValue(LastRow, COL_INSP_ITEM_DESC, out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        with_1.SetValue(LastRow, COL_INSP_METHOD, out_node.GetList(0)[i].GetString("INSP_METHOD"));
                        with_1.SetValue(LastRow, COL_SMP_PROC, out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                        with_1.SetValue(LastRow, COL_SMP_PROC_TYPE, out_node.GetList(0)[i].GetString("SAMPLE_PROC_TYPE"));
                        with_1.SetValue(LastRow, COL_SMP_PROC_RATE, (out_node.GetList(0)[i].GetInt("SAMPLE_RATE").ToString() + "%"));
                        with_1.SetValue(LastRow, COL_FIX_SMP_QTY, out_node.GetList(0)[i].GetDouble("FIX_SAMPLE_QTY"));
                        with_1.SetValue(LastRow, COL_SMP_PROC_UNIT, out_node.GetList(0)[i].GetString("SAMPLE_UNIT"));
                        with_1.SetValue(LastRow, COL_DET_VALUE, out_node.GetList(0)[i].GetDouble("DETERMINE_VALUE"));
                        with_1.SetValue(LastRow, COL_DET_UNIT, out_node.GetList(0)[i].GetString("DETERMINE_UNIT"));
                        with_1.SetValue(LastRow, COL_CHK_DET_FLAG, out_node.GetList(0)[i].GetString("CHECK_DETERMINE_FLAG"));
                        with_1.SetValue(LastRow, COL_SAMP_QTY, out_node.GetList(0)[i].GetDouble("SAMPLE_QTY"));
                        with_1.SetValue(LastRow, COL_TEST_QTY, out_node.GetList(0)[i].GetDouble("TEST_QTY"));
                        with_1.SetValue(LastRow, COL_DEFECT_QTY, out_node.GetList(0)[i].GetDouble("DEFECT_QTY"));
                        if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'P')
                        {
                            with_1.SetValue(LastRow, COL_RESULT, "PASS");
                        }
                        else if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'F')
                        {
                            with_1.SetValue(LastRow, COL_RESULT, "FAIL");
                        }
                        else
                        {
                            with_1.SetValue(LastRow, COL_RESULT, " ");
                        }
                        with_1.SetValue(LastRow, COL_COMMENT, (out_node.GetList(0)[i].GetString("ISP_COMMENT")));
                        with_1.SetValue(LastRow, COL_TRAN_TIME, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        with_1.SetValue(LastRow, COL_USER, out_node.GetList(0)[i].GetString("USER_ID"));
                        with_1.SetValue(LastRow, COL_DEFECT_GROUP, out_node.GetList(0)[i].GetString("DEFECT_GRP"));

                        DefectList[i].DefectQty = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");
                        iDefectCount = out_node.GetList(0)[i].GetList(0).Count;

                        if (iDefectCount > 0)
                        {
                            with_1.SetValue(LastRow, COL_DEFECT_CODE, "V");

                            DefectList[i].Defect = new Defect[out_node.GetList(0).Count];

                            for (j = 0; j <= iDefectCount - 1; j++)
                            {
                                DefectList[i].Defect[j] = new Defect();
                                DefectList[i].Defect[j].DefectCode = out_node.GetList(0)[i].GetList(0)[j].GetString("DEFECT_CODE");
                                DefectList[i].Defect[j].Qty = out_node.GetList(0)[i].GetList(0)[j].GetDouble("QTY_1");
                            }
                        }

                        LastRow++;
                    }

                    MPCF.FitColumnHeader(spdInspItem);

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);

                Get_Defect_Code();

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void Get_Defect_Code()
        {

            int i; 

            try
            {

                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                //Clear spdDefect
                for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                {
                    spdDefect.Sheets[0].Cells[i, 0].Text = "";
                    spdDefect.Sheets[0].Cells[i, 1].Text = "";
                }

                //Get Current Defect Code List
                if (DefectList[iCurRow].DefectQty > 0)
                {
                    for (i = 0; i <= DefectList[iCurRow].Defect.Length - 1; i++)
                    {
                        spdDefect.Sheets[0].SetValue(i, 0, DefectList[iCurRow].Defect[i].DefectCode);
                        spdDefect.Sheets[0].SetValue(i, 1, DefectList[iCurRow].Defect[i].Qty);
                    }
                }


            }
            catch (Exception)
            {
            }
        } 

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtBatchID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmQCMViewQCBatchStatus_Load(object sender, EventArgs e)
        {

        }

        private void frmQCMViewQCBatchStatus_Activated(object sender, EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_FINAL, "lblCMF", "cdvCMF", grpCMF);
                    ClearData('1');

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        } 

        private void cdvCMF_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        } 
  

        private void cdvInspItem_ButtonPress(object sender, EventArgs e)
        {
            cdvInspItem.Init();
            MPCF.InitListView(cdvInspItem.GetListView);
            cdvInspItem.Columns.Add("Insp. Item", 50, HorizontalAlignment.Left);
            cdvInspItem.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvInspItem.SelectedSubItemIndex = 0;
            QCMLIST.ViewAttachInspectionItemList(cdvInspItem.GetListView, '1', ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion), null, "");
        }

        private void cdvInspItem_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            int i;

            try
            {

                if (cdvInspItem.Text != "")
                {
                    for (i = 0; i <= spdInspItem.Sheets[0].Rows.Count - 1; i++)
                    {
                        if (cdvInspItem.Text == MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_INSP_ITEM)))
                        {
                            txtSeq.Text = (i + 1).ToString();
                            cdvInspItem.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_INSP_ITEM));
                            txtResult.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_RESULT));
                            txtItemCount.Text = ctrlBatchInfo.ItemCount;
                            txtTestQty.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_TEST_QTY));
                            txtDefectQty.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_DEFECT_QTY));
                            break;
                        }
                    }
                    View_Batch_Item_List(cdvInspItem.Text);
                }

            }
            catch (Exception)
            {

            }
        }

        private void spdInspItem_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                if (with_1.Rows.Count <= 0)
                {
                    return;
                }

                if (e.Row < 0)
                {
                    return;
                }

                iCurRow = e.Row;

                txtDefectInspItem.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_ITEM));

                if (e.Column == COL_DEFECT_CODE)
                {
                    grpDefect.Size = new System.Drawing.Size(250, grpInspItem.Size.Height);
                    grpDefect.Visible = true;
                }

                if (iPreRow == iCurRow)
                {
                    return;
                }

                if (MPCF.Trim(ctrlBatchInfo.InspMethod) != MPGC.MP_QCM_INSP_METHOD_Q)
                {

                    MPCF.InitListView(lisItem);

                    txtSeq.Text = (iCurRow + 1).ToString();
                    cdvInspItem.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_ITEM));
                    txtResult.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_RESULT));
                    txtItemCount.Text = ctrlBatchInfo.ItemCount;
                    txtTestQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_TEST_QTY));
                    txtDefectQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_DEFECT_QTY));
                    if (cdvInspItem.Text != "")
                    {
                        View_Batch_Item_List(cdvInspItem.Text);
                    }
                }

                Get_Defect_Code();

                iPreRow = iCurRow;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnHideDefect_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                grpDefect.Size = new System.Drawing.Size(0, grpInspItem.Size.Height); //Width in Show : 250
                grpDefect.Visible = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtBatchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (txtBatchID.Text != "")
                    {
                        MPCF.InitListView(lisItem);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            return;
                        }
                        if (MPCF.Trim(ctrlBatchInfo.InspSet) != "" && MPCF.Trim(ctrlBatchInfo.InspSetVersion) != "")
                        {
                            View_Attach_Insp_Item_List_Detail(txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }         
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            { 
                if (txtBatchID.Text != "")
                {
                    MPCF.InitListView(lisItem);
                    if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                    {
                        return;
                    }
                    if (MPCF.Trim(ctrlBatchInfo.InspSet) != "" && MPCF.Trim(ctrlBatchInfo.InspSetVersion) != "")
                    {
                        View_Attach_Insp_Item_List_Detail(txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                    }
                } 
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }       
        } 
    }
    //#End If
}


