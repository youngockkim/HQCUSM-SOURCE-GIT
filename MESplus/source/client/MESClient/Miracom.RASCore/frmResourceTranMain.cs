using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.RASCore;
using Miracom.MESCore;
using System.Collections;
using System.Reflection;

namespace Miracom.RASCore
{
    public partial class frmResourceTranMain : Form
    {
        public frmResourceTranMain()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        // Sub Resource Spread
        private int COL_SUBRES_ID = 0;
        private int COL_SUBRES_DESC = 1;
        private int COL_SUBRES_TYPE = 2;
        private int COL_SUBRES_CHAMBER_GROUP = 3;
        private int COL_SUBRES_DEPENDENT_FLAG = 4;
        private int COL_SUBRES_LOCATION = 5;
        private int COL_SUBRES_UP_FLAG = 6;
        private int COL_SUBRES_PRI_STS = 7;
        private int COL_SUBRES_STS_1 = 8;
        private int COL_SUBRES_STS_2 = 9;
        private int COL_SUBRES_STS_3 = 10;
        private int COL_SUBRES_STS_4 = 11;
        private int COL_SUBRES_STS_5 = 12;
        private int COL_SUBRES_STS_6 = 13;
        private int COL_SUBRES_STS_7 = 14;
        private int COL_SUBRES_STS_8 = 15;
        private int COL_SUBRES_STS_9 = 16;
        private int COL_SUBRES_STS_10 = 17;

        // Port Spread
        private int COL_PORT_ID = 0;
        private int COL_PORT_DESC = 1;
        private int COL_PORT_TYPE = 2;
        private int COL_PORT_BATCH = 3;
        private int COL_PORT_ADD_PORT_TYPE = 4;
        //private int COL_PORT_LEVEL = 5;
        private int COL_PORT_TRANSFER_STATE = 6;
        private int COL_PORT_CARRIER_ID = 7;
        private int COL_PORT_LOT_ID = 8;
        private int COL_PORT_BCR_STATE = 9;
        private int COL_PORT_ASSOCIATION_STATE = 10;
        private int COL_PORT_ASSOCIATION_OBJECT_ID = 11;
        private int COL_PORT_ACCESS_MODE_STATE = 12;
        private int COL_PORT_RESERVATION_STATE = 13;
        private int COL_PORT_RESERVATION_OBJECT_ID = 14;

        // Lot List ListView
        //private int COL_LOT_ID = 1;
        //private int COL_MAT_ID = 4;
        //private int COL_MAT_VER = 5;
        //private int COL_FLOW = 6;
        //private int COL_FLOW_SEQ_NUM = 7;
        //private int COL_OPER = 8;

        // Lot Transaction List Spread
        //private int COL_TRAN_CODE = 0;
        //private int COL_TRAN_PROC = 1;

        // 트랜잭션 수행여부 확인용
        //private string TRAN_PROC = "PROC";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag = false;
        private TRSNode m_res_info;
        private TRSNode m_oper_info;
        //private string m_cur_oper;

//        private struct TRAN
//        {
//            public string TRAN_CODE;
//            public string FUNC_NAME;
//            public int TRAN_SEQ;
//            public bool IS_PROCESSED;
//
//            //public TRAN()
//            //{
//            //    TRAN_CODE = "";
//            //    IS_PROCESSED = false;
//            //}
//        }

        #endregion

        #region " Function Definition "

        /// <summary>
        /// Validation Function
        /// </summary>
        /// <param name="sCondType">Check Type</param>
        /// <returns>true or false</returns>
        private bool CheckCondition(string sCondType)
        {
            return CheckCondition(sCondType, null);
        }
        private bool CheckCondition(string sCondType, object cond)
        {
            //int i = 0;
            if (MPCF.CheckValue(cdvResId, 1) == false) return false;

            switch (sCondType)
            {
                case "EVENT":
                    if (MPCF.CheckValue(cdvEventID, 1) == false) return false;
                    break;

                case "TRAN":
                    if (m_oper_info == null) return false;
                    if (cond != null)
                    {
                        //if ((string)cond == MPGC.MP_TRAN_CODE_END && m_oper_info.GetChar("START_REQUIRE_FLAG") == 'Y')
                        //{
                        //   for (i = 0; i < spdLotTran.ActiveSheet.RowCount; i++)
                        //   {
                        //       if (MPCF.Trim(spdLotTran.ActiveSheet.Cells[i, COL_TRAN_CODE].Value) == MPGC.MP_TRAN_CODE_START &&
                        //           MPCF.Trim(spdLotTran.ActiveSheet.Cells[i, COL_TRAN_PROC].Tag) != TRAN_PROC)
                        //       {
                        //           // Start Req Error
                        //           MPCF.ShowMsgBox(MPCF.GetMessage(329));
                        //           return false;
                        //       }
                        //   }
                        //}
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Set Resource id, Window width and height
        /// </summary>
        /// <param name="sResid">Resource id</param>
        /// <param name="iWidth">Window width</param>
        /// <param name="iHeight">Window height</param>
        public void SetResource(string sResid, int iWidth, int iHeight)
        {

            try
            {
                udcLotList.SetInfo(this.Name);
                cdvResId.Text = sResid;
                
                if (this.Width + 4 > iWidth)
                {
                    this.Left = 0;
                    this.Width = iWidth - 4;
                }
                if (this.Height + 4 > iHeight)
                {
                    this.Top = 0;
                    this.Height = iHeight - 4;
                }

                if (b_load_flag == true)
                {
                    btnRefresh.PerformClick();
                }
                else
                {
                    this.Top = 0;
                    this.Left = 0;
                    this.Width = iWidth - 4;
                    this.Height = iHeight - 4;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /// <summary>
        /// View Resource Status
        /// </summary>
        /// <param name="s_res_id">Resource id</param>
        /// <returns></returns>
        private bool ViewResource(string s_res_id)
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");

            try
            {
                udcResStatus.ProcStep = '1';
                udcResStatus.ResID = s_res_id;
                udcResStatus.ScreenID = "DefaultResStatus";
                if (udcResStatus.LoadDesign() == false) return false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", s_res_id);

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    TRSNode factory_in = new TRSNode("View_Factory_In");
                    TRSNode factory_out = new TRSNode("View_Factory_Out");

                    MPCR.SetInMsg(factory_in);
                    factory_in.ProcStep = '1';

                    if (MPCR.CallService("WIP", "WIP_View_Factory", factory_in, ref factory_out) == false)
                    {
                        return false;
                    }

                    out_node.SetString("RES_STS_PRT_1", MPCF.Trim(factory_out.GetString("RES_STS_1")));
                    out_node.SetString("RES_STS_PRT_2", MPCF.Trim(factory_out.GetString("RES_STS_2")));
                    out_node.SetString("RES_STS_PRT_3", MPCF.Trim(factory_out.GetString("RES_STS_3")));
                    out_node.SetString("RES_STS_PRT_4", MPCF.Trim(factory_out.GetString("RES_STS_4")));
                    out_node.SetString("RES_STS_PRT_5", MPCF.Trim(factory_out.GetString("RES_STS_5")));
                    out_node.SetString("RES_STS_PRT_6", MPCF.Trim(factory_out.GetString("RES_STS_6")));
                    out_node.SetString("RES_STS_PRT_7", MPCF.Trim(factory_out.GetString("RES_STS_7")));
                    out_node.SetString("RES_STS_PRT_8", MPCF.Trim(factory_out.GetString("RES_STS_8")));
                    out_node.SetString("RES_STS_PRT_9", MPCF.Trim(factory_out.GetString("RES_STS_9")));
                    out_node.SetString("RES_STS_PRT_10", MPCF.Trim(factory_out.GetString("RES_STS_10")));
                }

                if (udcResStatus.SetDataToScreen(out_node) == false) return false;

                m_res_info = out_node;

                txtResDesc.Text = m_res_info.GetString("RES_DESC");
                MPGV.gsCurrentRes_ID = MPCF.Trim(cdvResId.Text);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View lot by resource
        /// </summary>
        /// <returns>true or false</returns>
        private bool ViewLotList()
        {
            try
            {
                return udcLotList.ViewLotList('1', cdvResId.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View sub resource information
        /// </summary>
        /// <returns>true or false</returns>
        private bool ViewSubResList()
        {
            TRSNode in_node = new TRSNode("View_SubRes_List_In");
            TRSNode out_node = new TRSNode("View_SubRes_List_Out");
            TRSNode list_item;

            try
            {
                if (CheckCondition("SUBRES") == false)
                {
                    return false;
                }

                MPCF.ClearList(spdSubRes);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResId.Text));
                in_node.AddChar("DELETE_FLAG", ' ');
                in_node.AddString("NEXT_SUBRES_ID", "");

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        list_item = out_node.GetList(0)[i];
                        spdSubRes.ActiveSheet.RowCount++;
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_ID].Text = list_item.GetString("SUBRES_ID");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_DESC].Text = list_item.GetString("SUBRES_DESC");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_TYPE].Text = list_item.GetString("SUBRES_TYPE");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_CHAMBER_GROUP].Text = list_item.GetString("CHAMBER_GRP_ID");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_DEPENDENT_FLAG].Text = MPCF.Trim(list_item.GetChar("CHAMBER_TYPE_FLAG"));
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_LOCATION].Text = list_item.GetString("SUBRES_LOCATION");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_UP_FLAG].Text = MPCF.Trim(list_item.GetChar("SUBRES_UP_DOWN_FLAG"));
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_PRI_STS].Text = list_item.GetString("SUBRES_PRI_STS");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_1].Text = list_item.GetString("RES_STS_PRT_1") == "" ? "-" : list_item.GetString("RES_STS_PRT_1");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_2].Text = list_item.GetString("RES_STS_PRT_2") == "" ? "-" : list_item.GetString("RES_STS_PRT_2");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_3].Text = list_item.GetString("RES_STS_PRT_3") == "" ? "-" : list_item.GetString("RES_STS_PRT_3");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_4].Text = list_item.GetString("RES_STS_PRT_4") == "" ? "-" : list_item.GetString("RES_STS_PRT_4");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_5].Text = list_item.GetString("RES_STS_PRT_5") == "" ? "-" : list_item.GetString("RES_STS_PRT_5");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_6].Text = list_item.GetString("RES_STS_PRT_6") == "" ? "-" : list_item.GetString("RES_STS_PRT_6");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_7].Text = list_item.GetString("RES_STS_PRT_7") == "" ? "-" : list_item.GetString("RES_STS_PRT_7");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_8].Text = list_item.GetString("RES_STS_PRT_8") == "" ? "-" : list_item.GetString("RES_STS_PRT_8");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_9].Text = list_item.GetString("RES_STS_PRT_9") == "" ? "-" : list_item.GetString("RES_STS_PRT_9");
                        spdSubRes.ActiveSheet.ColumnHeader.Cells[0, COL_SUBRES_STS_10].Text = list_item.GetString("RES_STS_PRT_10") == "" ? "-" : list_item.GetString("RES_STS_PRT_10");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_1].Text = list_item.GetString("SUBRES_STS_1");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_2].Text = list_item.GetString("SUBRES_STS_2");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_3].Text = list_item.GetString("SUBRES_STS_3");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_4].Text = list_item.GetString("SUBRES_STS_4");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_5].Text = list_item.GetString("SUBRES_STS_5");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_6].Text = list_item.GetString("SUBRES_STS_6");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_7].Text = list_item.GetString("SUBRES_STS_7");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_8].Text = list_item.GetString("SUBRES_STS_8");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_9].Text = list_item.GetString("SUBRES_STS_9");
                        spdSubRes.ActiveSheet.Cells[i, COL_SUBRES_STS_10].Text = list_item.GetString("SUBRES_STS_10");
                    }
                    in_node.SetString("NEXT_SUBRES_ID", out_node.GetString("NEXT_SUBRES_ID"));
                } while (in_node.GetString("NEXT_SUBRES_ID") != "");

                if (spdSubRes.ActiveSheet.RowCount < 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Port information
        /// </summary>
        /// <returns>true or false</returns>
        private bool ViewPortList()
        {
            TRSNode in_node = new TRSNode("View_Port_List_In");
            TRSNode out_node = new TRSNode("View_Port_List_Out");
            TRSNode list_item;

            try
            {
                if (CheckCondition("PORT") == false)
                {
                    return false;
                }

                MPCF.ClearList(spdPort);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResId.Text));

                if (MPCR.CallService("RAS", "RAS_View_Port_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    list_item = out_node.GetList(0)[i];
                    spdPort.ActiveSheet.RowCount++;
                    spdPort.ActiveSheet.Cells[i, COL_PORT_ID].Text = list_item.GetString("PORT_ID");
                    spdPort.ActiveSheet.Cells[i, COL_PORT_DESC].Text = list_item.GetString("PORT_DESC");
                    if (list_item.GetChar("PORT_TYPE") == 'L')
                    {
                        spdPort.ActiveSheet.Cells[i, COL_PORT_TYPE].Text = "LOAD";
                    }
                    else if (list_item.GetChar("PORT_TYPE") == 'U')
                    {
                        spdPort.ActiveSheet.Cells[i, COL_PORT_TYPE].Text = "UNLOAD";
                    }
                    else
                    {
                        spdPort.ActiveSheet.Cells[i, COL_PORT_TYPE].Text = "BOTH";
                    }
                    spdPort.ActiveSheet.Cells[i, COL_PORT_ADD_PORT_TYPE].Text = MPCF.Trim(list_item.GetChar("ADD_PORT_TYPE"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_BATCH].Text = MPCF.Trim(list_item.GetChar("PORT_BATCH_FLAG"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_TRANSFER_STATE].Text = list_item.GetString("TRS_STATE");
                    spdPort.ActiveSheet.Cells[i, COL_PORT_CARRIER_ID].Text = list_item.GetString("CRR_ID");
                    spdPort.ActiveSheet.Cells[i, COL_PORT_LOT_ID].Text = list_item.GetString("LOT_ID");
                    spdPort.ActiveSheet.Cells[i, COL_PORT_BCR_STATE].Text = MPCF.Trim(list_item.GetChar("BCR_STATUS_FLAG"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_ASSOCIATION_STATE].Text = MPCF.Trim(list_item.GetChar("ASC_STATE"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_ASSOCIATION_OBJECT_ID].Text = list_item.GetString("ASC_OBJ_ID");
                    spdPort.ActiveSheet.Cells[i, COL_PORT_ACCESS_MODE_STATE].Text = MPCF.Trim(list_item.GetChar("ACC_STATE"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_RESERVATION_STATE].Text = MPCF.Trim(list_item.GetChar("RSV_STATE"));
                    spdPort.ActiveSheet.Cells[i, COL_PORT_RESERVATION_OBJECT_ID].Text = list_item.GetString("RSV_OBJ_ID");
                }

                if (spdPort.ActiveSheet.RowCount < 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get lot history in current(last) operation
        /// </summary>
        /// <param name="s_lot_id"></param>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool GetLotHistory(string s_lot_id, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("HISTORY_IN");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("LOT_ID", s_lot_id);

                if (MPCR.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Service Result by Step
        /// </summary>
        /// <param name="i_step"></param>
        /// <returns></returns>
        private bool ViewList(int i_step)
        {
            bool bPort = grpPortInfo.Visible;
            bool bSubRes = grpSubResInfo.Visible;

            if (MPCF.Trim(cdvResId.Text) == "") return false;

            switch (i_step)
            {
                case 1: // After Form Load or Refresh 
                    if (ViewResource(MPCF.Trim(cdvResId.Text)) == false)
                    {
                        break;
                    }
                    if (ViewSubResList() == false)
                    {
                        bSubRes = false;
                        grpPortInfo.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        bSubRes = true;
                        grpPortInfo.Dock = DockStyle.Bottom;
                    }
                    if (ViewPortList() == false)
                    {
                        bPort = false;
                        grpSubResInfo.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        bPort = true;
                        grpPortInfo.Visible = true;
                    }
                    if (ViewLotList() == false)
                    {
                        break;
                    }
                    break;
                case 2: // Resource Event or Subresource Event
                    if (ViewResource(MPCF.Trim(cdvResId.Text)) == false)
                    {
                        break;
                    }
                    if (ViewSubResList() == false)
                    {
                        bSubRes = false;
                        grpPortInfo.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        bSubRes = true;
                        grpPortInfo.Dock = DockStyle.Bottom;
                    }
                    break;
                case 3: // Change Port State
                    if (ViewPortList() == false)
                    {
                        bPort = false;
                        grpSubResInfo.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        bPort = true;
                    }
                    break;
                case 4: // After Lot Transaction
                    if (ViewLotList() == false)
                    {
                        break;
                    }
                    break;
            }

            if (bSubRes == false && bPort == false)
            {
                pnlSubInfo.Visible = false;
            }
            else
            {
                grpSubResInfo.Visible = bSubRes;
                grpPortInfo.Visible = bPort;
                pnlSubInfo.Visible = true;
            }
                   
            return true;
        }

        /// <summary>
        /// Get function information and Show function window
        /// </summary>
        /// <param name="s_func_name"></param>
        /// <returns></returns>
        private bool ViewFunction(string s_func_name)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            string[] s_tmp;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", s_func_name);

                if (MPCR.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }

                string sAssemFile = MPCF.Trim(out_node.GetString("ASSEMBLY_FILE"));
                string sAssemName = MPCF.Trim(out_node.GetString("ASSEMBLY_NAME"));

                s_tmp = sAssemName.Split('.');

                object obj = MPCF.GetChildForm(MPGV.gfrmMDI, s_tmp[s_tmp.Length - 1], true);
                if (obj == null)
                {
                    string s_dir = Application.StartupPath;
                    Assembly asm = Assembly.LoadFrom(s_dir + "\\" + sAssemFile);
                    obj = asm.CreateInstance(sAssemName);
                    if (obj == null) return false;

                    ((Form)obj).MdiParent = MPGV.gfrmMDI;
                    ((Form)obj).Tag = s_func_name;

                    if (MPCR.CheckSecurityFormControl((Form)obj) == false)
                    {
                        return false;
                    }

                    ((Form)obj).StartPosition = FormStartPosition.CenterParent;
                    ((Form)obj).Show();
                }

                try
                {
                    Control focus_control = null;
                    focus_control = (Control)obj.GetType().InvokeMember("GetFisrtFocusItem", BindingFlags.InvokeMethod, null, obj, null);
                    focus_control.Focus();
                }
                catch (MissingMethodException)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Get operation inforamtion
        /// </summary>
        /// <param name="s_oper"></param>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool GetOperationInfo(string s_oper)
        {
            TRSNode in_node = new TRSNode("OPER_IN");
            TRSNode out_node = new TRSNode("OPER_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", s_oper);

                if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                m_oper_info = out_node;
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
                return this.cdvResId;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmResourceTranMain_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmResourceTranMain_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                udcLotList.Init();
                udcLotList.ModuleName = "RAS";
                udcLotList.ServiceName = "RAS_View_LotByRes_List";
                udcLotList.ParentPath = "LOT_LIST";

                ViewList(1);

                MPGV.gbFavoriteChangeForLotListMain = false;
                b_load_flag = true;
            }
            else
            {
                if (MPGV.gbFavoriteChangeForLotListMain == true)
                {
                    MPGV.gbFavoriteChangeForLotListMain = false;
                    udcLotList.GetSubMenu();
                }
            }
        }

        private void cdvResEvent_ButtonPress(object sender, EventArgs e)
        {
            cdvEventID.Init();
            cdvEventID.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            cdvEventID.DisplaySubItemIndex = 0;
            cdvEventID.SelectedDescIndex = 1;
            cdvEventID.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
            RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResId.Text, null, "");
        }

        private void btnResEvent_Click(object sender, EventArgs e)
        {
            frmRASTranEvent f = new frmRASTranEvent();

            try
            {
                if (CheckCondition("EVENT") == false) return;

                f.SetEventId(MPCF.Trim(cdvEventID.Text));
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);

                ViewList(2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdSubRes_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            frmRASTranSubEvent f = new frmRASTranSubEvent();

            int iRow;

            try
            {
                if (CheckCondition("SUB_EVENT") == false) return;

                iRow = spdSubRes.ActiveSheet.ActiveRowIndex;
                f.SetSubResourceId(cdvResId.Text, MPCF.Trim(spdSubRes.ActiveSheet.Cells[iRow, COL_SUBRES_ID].Text));
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);

                ViewList(2);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdPort_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            frmRASTranChangePortStatus f = new frmRASTranChangePortStatus();

            int iRow;

            try
            {
                if (CheckCondition("CHANGE_PORT") == false) return;

                iRow = spdPort.ActiveSheet.ActiveRowIndex;
                f.SetPortId(cdvResId.Text, MPCF.Trim(spdPort.ActiveSheet.Cells[iRow, COL_PORT_ID].Text));
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);

                ViewList(3);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewList(1);
        }

        private void cdvResId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewList(1);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewList(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cdvResId_ButtonPress(object sender, EventArgs e)
        {
            cdvResId.Init();
            MPCF.InitListView(cdvResId.GetListView);
            cdvResId.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResId.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResId.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResId.GetListView, false);
        }

        private void cdvResId_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnView.PerformClick();
        }

        private void udcLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            udcWorkStation.LotId = MPGV.gsCurrentLot_ID;
            udcWorkStation.ViewTransaction();
        }
    }
}
