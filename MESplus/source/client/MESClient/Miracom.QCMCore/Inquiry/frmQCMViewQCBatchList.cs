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

namespace Miracom.QCMCore
{
    public partial class frmQCMViewQCBatchList : Miracom.MESCore.ViewForm01
    {
        public frmQCMViewQCBatchList()
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

        // View_QC_Batch_List()
        //       - View all QC Batch List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : ListÍ∞Ä ?§Ïñ¥Í∞?control
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterÎ°??úÏûë?òÎäî Flow
        //        - Optional ByVal sOper As String = ""        : sOperÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialÎ•?Í∞ÄÏß?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?êÏÑú Ï∂îÍ???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?ÑÏû¨ FactoryÍ∞Ä ?ÑÎãåÍ≤ΩÏö∞???Ä??Factory
        //
        private bool View_QC_Batch_List()
        {

            FarPoint.Win.Spread.SheetView shtList;
            int i;
            int iRow;
            int iCol;

            try
            {

                MPCF.ClearList(spdList, true);

                TRSNode in_node = new TRSNode("VIEW_QC_BATCH_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_QC_BATCH_LIST_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                
                in_node.AddString("INSP_METHOD", MPCF.Trim(cdvInspMethod.Text));
                in_node.AddString("INSP_TYPE", MPCF.Trim(cdvInspType.Text));
                in_node.AddString("INSP_SET_ID", MPCF.Trim(cdvInspSetID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatID.Version));
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddString("NEXT_BATCH_ID", "");

                shtList = spdList.Sheets[0];

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_QC_Batch_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        TRSNode node = out_node.GetList(0)[i];

                        iRow = shtList.RowCount;

                        shtList.RowCount++;

                        iCol = 0;

                        shtList.Cells[iRow, iCol].Value = node.GetString("BATCH_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetChar("BATCH_DEL_FLAG");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("MAT_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("MAT_VER");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("MAT_DESC");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("ORDER_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("RES_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("INSP_SET_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("INSP_SET_VERSION");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("INSP_TYPE");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("INSP_METHOD");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetChar("TOT_INSP");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetChar("SKIP_RESULT_RECORD");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetChar("AUTO_FINAL");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("ITEM_COUNT");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetDouble("TOT_QTY_1");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("INSP_STEP");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BATCH_STATUS");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("PO");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("PO_ITEM");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("VENDOR");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("CUSOTMER");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("FINAL_DECISION");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_1");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_2");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_3");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_4");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_5");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_6");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_7");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_8");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_9");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("BAT_CMF_10");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("LAST_HIST_SEQ");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("ITEM_RESULT_SEQ");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetInt("INSP_SEQ");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("LAST_TRAN_CODE");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("LAST_COMMENT");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(node.GetString("CREATE_TIME"));

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("CREATE_USER_ID");

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(node.GetString("UPDATE_TIME"));

                        iCol++;
                        shtList.Cells[iRow, iCol].Value = node.GetString("UPDATE_USER_ID");

                        iCol++;

                    }

                    in_node.SetString("NEXT_BATCH_ID", out_node.GetString("NEXT_BATCH_ID"));

                } while (in_node.GetString("NEXT_BATCH_ID") != "");


                MPCF.FitColumnHeader(spdList);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.dtpFrom;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmQCMViewQCBatchList_Load(object sender, EventArgs e)
        {

        }

        private void frmQCMViewQCBatchList_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                dtpFrom.Value = DateTime.Today.AddMonths(-1);
                dtpTo.Value = DateTime.Today;

                b_load_flag = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            View_QC_Batch_List();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            FarPoint.Win.Spread.FpSpread spdData = null;

            spdData = spdList;

            sCond =  "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom), DATE_TIME_FORMAT.NONE) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdData, this.Text, sCond);
        } 

        private void cdvInspType_ButtonPress(object sender, EventArgs e)
        {
            cdvInspType.Init();
            MPCF.InitListView(cdvInspType.GetListView);
            cdvInspType.Columns.Add("Insp. Type", 100, HorizontalAlignment.Left);
            cdvInspType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInspType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspType.GetListView, '1', MPGC.MP_QCM_INSP_TYPE);
        }

        private void cdvMatID_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            //if (View_Inspection_Material_Info(cdvMatID.Text, cdvMatID.Version) == false)
            //{
            //    return;
            //}
        }

        private void cdvMatID_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvMatID.Text == "")
            {
                return;
            }
            //if (View_Inspection_Material_Info(cdvMatID.Text, cdvMatID.Version) == false)
            //{
            //    return;
            //}
        }

        private void cdvInspMethod_ButtonPress(object sender, EventArgs e)
        {
            cdvInspMethod.Init();
            MPCF.InitListView(cdvInspMethod.GetListView);
            cdvInspMethod.Columns.Add("Insp. Method", 100, HorizontalAlignment.Left);
            cdvInspMethod.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvInspMethod.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspMethod.GetListView, '1', MPGC.MP_QCM_INSP_METHOD);
        }

        private void cdvIQCInspSetID_ButtonPress(object sender, EventArgs e)
        {
            cdvInspSetID.Init();
            MPCF.InitListView(cdvInspSetID.GetListView);
            cdvInspSetID.Columns.Add("Inspection Set", 100, HorizontalAlignment.Left);
            cdvInspSetID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvInspSetID.GetListView, '1', cdvInspType.Text, "", null, "");
        } 
    }
}



