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

namespace Miracom.INVCore
{
    public partial class frmRealTest : Miracom.MESCore.ViewForm01
    {
        private bool b_load_flag;

        private string[] sGroupTableName = new string[10];

        public frmRealTest()
        {
            InitializeComponent();
        }

        #region " Function Definition "

        // View_SubLot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        //private bool View_SubLot_List()
        //{
        //    XML_Tag xmlInMsg = new XML_Tag();
        //    XML_Tag xmlOutMsg = new XML_Tag();

        //    TRSNode node = new TRSNode(TRSDefine.XMLCORE_TAG_BODY);
        //    TRSNode outNode = new TRSNode("Msg");

        //    MPCF.ClearList(spdList, true);

        //    node.AddProcStep('1');
        //    node.AddLanguage(MPGV.gcLanguage);
        //    node.AddUserID(MPGV.gsUserID);
        //    node.AddPassword(MPGV.gsPassword);
        //    node.AddFactory(MPGV.gsFactory);

        //    node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));


        //    xmlInMsg.xml_msg = node.GenerateXmlMsg();
        //    xmlInMsg.length = xmlInMsg.xml_msg.Length;


        //    if (INVCaster.XML_Test(xmlInMsg, ref xmlOutMsg) == false)
        //    {
        //        return false;
        //    }


        //    if (outNode.MeltToNode(xmlOutMsg.xml_msg))
        //    {
        //        int i;
        //        int iRow;
        //        int iCol;  
        //        FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

        //        TRSNode arrayNode = outNode.GetList(0);

        //        spdList.Sheets[0].RowCount = 1;

        //        for (i = 0; i <= arrayNode.GetMember("Count").GetInt() - 1; i++)
        //        {
        //            sheet = spdList.Sheets[0];
        //            //iRow = sheet.RowCount;
        //            //sheet.RowCount++;
        //            iRow = 0;
        //            iCol = 0;

        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("SLOT_NO").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("SUBLOT_ID").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("MAT_ID").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("MAT_VER").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("FLOW").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("FLOW_SEQ_NUM").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("OPER").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", arrayNode.GetList(i).GetMember("QTY_2").GetDouble());

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", arrayNode.GetList(i).GetMember("QTY_3").GetDouble());

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("CRR_ID").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("OWNER_CODE").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("CREATE_CODE").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("SUBLOT_STATUS").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("HOLD_FLAG").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("HOLD_CODE").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].create_qty_2);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].create_qty_3);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].oper_in_qty_2);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].oper_in_qty_3);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("INV_FLAG").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("TRANSIT_FLAG").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].unit_exist_flag);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].inv_unit);

        //            iCol++;

        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("RWK_FLAG").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("RWK_CODE").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].rwk_count);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_flow);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_oper);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_end_flow);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_end_oper);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_clear_flag);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].rwk_time);

        //            iCol++;

        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_flag);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_ret_flow);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_ret_oper);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].nstd_time);

        //            iCol++;

        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("START_FLAG").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].start_time);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("START_RES_ID").Value);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("END_FLAG").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].end_time);

        //            iCol++;
        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("END_RES_ID").Value);

        //            iCol++;

        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sample_flag);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sample_wait_flag);

        //            iCol++;
        //            //switch (View_SubLot_List_Out.sublot_list[i].sample_result)
        //            //{
        //            //    case 'Y':

        //            //        sheet.Cells[iRow, iCol].Value = "Good";
        //            //        break;
        //            //    case 'N':

        //            //        sheet.Cells[iRow, iCol].Value = "No Good";
        //            //        break;
        //            //    default:

        //            //        sheet.Cells[iRow, iCol].Value = "";
        //            //        break;
        //            //}
        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].reserve_res_id);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_location);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_1);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_2);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_3);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_4);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_5);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_6);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_7);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_8);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_9);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_10);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_11);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_12);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_13);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_14);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_15);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_16);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_17);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_18);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_19);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_20);

        //            iCol++;

        //            sheet.Cells[iRow, iCol].Value = MPCF.Trim(arrayNode.GetList(i).GetMember("GRADE").Value);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].grade_code);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].cell_grade);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].lot_base);

        //            iCol++;

        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_del_flag);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_del_code);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].sublot_del_time);

        //            iCol++;

        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].last_tran_code);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].last_tran_time);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].last_comment);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].last_active_hist_seq);

        //            iCol++;
        //            //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].last_hist_seq);

        //            iCol++;

        //            //if (View_SubLot_List_Out.sublot_list[i].sublot_del_flag == 'Y')
        //            //{
        //            //    sheet.Rows[iRow].ForeColor = Color.Magenta;
        //            //}
        //        }
        //    }

        //    MPCF.FitColumnHeader(spdList);

        //    return true;
        //}


        private bool View_SubLot_List()
        {
            TRSNode in_node = new TRSNode("WIP_View_SubLot_List");
            TRSNode out_node = new TRSNode("Msg");

            MPCF.ClearList(spdList, true);
                        
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            
            if (MPCR.CallService("TEST", "TEST_SERVICE", in_node, ref out_node, DeliveryMode.RReply) == false)
            {
                return false;
            }
            else
            {
                int i;
                int iRow;
                int iCol;
                FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

                spdList.Sheets[0].RowCount = 1;

                for (i = 0; i <= out_node.GetList(0).Count - 1; i++)
                {
                    sheet = spdList.Sheets[0];
                    //iRow = sheet.RowCount;
                    //sheet.RowCount++;
                    iRow = 0;
                    iCol = 0;

                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("SLOT_NO").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("SUBLOT_ID").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("MAT_ID").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("MAT_VER").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("FLOW").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("FLOW_SEQ_NUM").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("OPER").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("CRR_ID").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("OWNER_CODE").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("CREATE_CODE").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("SUBLOT_STATUS").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("HOLD_FLAG").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("HOLD_CODE").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].create_qty_2);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].create_qty_3);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].oper_in_qty_2);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", View_SubLot_List_Out.sublot_list[i].oper_in_qty_3);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("INV_FLAG").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("TRANSIT_FLAG").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].unit_exist_flag);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].inv_unit);

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("RWK_FLAG").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("RWK_CODE").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].rwk_count);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_flow);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_oper);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_end_flow);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_end_oper);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].rwk_ret_clear_flag);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].rwk_time);

                    iCol++;

                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_flag);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_ret_flow);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].nstd_ret_oper);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].nstd_time);

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("START_FLAG").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].start_time);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("START_RES_ID").Value);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("END_FLAG").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].end_time);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("END_RES_ID").Value);

                    iCol++;

                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sample_flag);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sample_wait_flag);

                    iCol++;
                    //switch (View_SubLot_List_Out.sublot_list[i].sample_result)
                    //{
                    //    case 'Y':

                    //        sheet.Cells[iRow, iCol].Value = "Good";
                    //        break;
                    //    case 'N':

                    //        sheet.Cells[iRow, iCol].Value = "No Good";
                    //        break;
                    //    default:

                    //        sheet.Cells[iRow, iCol].Value = "";
                    //        break;
                    //}
                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].reserve_res_id);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_location);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_1);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_2);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_3);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_4);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_5);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_6);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_7);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_8);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_9);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_10);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_11);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_12);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_13);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_14);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_15);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_16);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_17);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_18);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_19);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_cmf_20);

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetMember("GRADE").Value);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].grade_code);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].cell_grade);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].lot_base);

                    iCol++;

                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_del_flag);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].sublot_del_code);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].sublot_del_time);

                    iCol++;

                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].last_tran_code);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(View_SubLot_List_Out.sublot_list[i].last_tran_time);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Trim(View_SubLot_List_Out.sublot_list[i].last_comment);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].last_active_hist_seq);

                    iCol++;
                    //sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", View_SubLot_List_Out.sublot_list[i].last_hist_seq);

                    iCol++;

                    //if (View_SubLot_List_Out.sublot_list[i].sublot_del_flag == 'Y')
                    //{
                    //    sheet.Rows[iRow].ForeColor = Color.Magenta;
                    //}
                }
            }

            MPCF.FitColumnHeader(spdList);

            return true;
        }

        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
            }
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtLotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRealTest_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                ActiveFormNow();

                b_load_flag = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            View_SubLot_List();
            this.Text = MPCF.FindLanguage("Sub Lot List", 0) + " (" + txtLotID.Text + ")";
            this.lblFormTitle.Text = this.Text;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text);

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }
    }
}