using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASTranCarrierEvent : Miracom.MESCore.TranForm01
    {
        public frmRASTranCarrierEvent()
        {
            InitializeComponent();
        }

        private TRSNode crr_event_out;
        private int i_attr_row;
        private static string[] s_attr_name;
        
        private void InitEventInfo()
        {
            
            spdData.ActiveSheet.RowCount = 16;
            spdData.ActiveSheet.Cells[0,0].Tag = "CRR_STATUS";
            spdData.ActiveSheet.Cells[0, 0].Text = "Carrier Status";
            spdData.ActiveSheet.Cells[1,0].Tag ="LOCATION_1";
            spdData.ActiveSheet.Cells[1, 0].Text = "Locaton 1";
            spdData.ActiveSheet.Cells[2,0].Tag ="LOCATION_2";
            spdData.ActiveSheet.Cells[2, 0].Text = "Locaton 2";
            spdData.ActiveSheet.Cells[3,0].Tag ="LOCATION_3";
            spdData.ActiveSheet.Cells[3, 0].Text = "Locaton 3";
            spdData.ActiveSheet.Cells[4,0].Tag ="LOCATION_4";
            spdData.ActiveSheet.Cells[4, 0].Text = "Locaton 4";
            spdData.ActiveSheet.Cells[5,0].Tag ="LOCATION_5";
            spdData.ActiveSheet.Cells[5, 0].Text = "Locaton 5";
            spdData.ActiveSheet.Cells[6,0].Tag ="RES_ID";
            spdData.ActiveSheet.Cells[6, 0].Text = "Resource ID";
            spdData.ActiveSheet.Cells[7,0].Tag ="SUBRES_ID";
            spdData.ActiveSheet.Cells[7, 0].Text = "Sub Resource ID";
            spdData.ActiveSheet.Cells[8,0].Tag ="PORT_ID";
            spdData.ActiveSheet.Cells[8, 0].Text = "Port ID";
            spdData.ActiveSheet.Cells[9,0].Tag ="LOT_ID";
            spdData.ActiveSheet.Cells[9, 0].Text = "Lot ID";
            spdData.ActiveSheet.Cells[10,0].Tag ="QTY_1";
            spdData.ActiveSheet.Cells[10, 0].Text = "Qty 1";
            spdData.ActiveSheet.Cells[11,0].Tag ="QTY_2";
            spdData.ActiveSheet.Cells[11, 0].Text = "Qty 2";
            spdData.ActiveSheet.Cells[12,0].Tag ="QTY_3";
            spdData.ActiveSheet.Cells[12, 0].Text = "Qty 3";
            spdData.ActiveSheet.Cells[13, 0].Tag = "USAGE_COUNT";
            spdData.ActiveSheet.Cells[13, 0].Text = "Usage Count";
            spdData.ActiveSheet.Cells[14, 0].Tag = "CLEAN_COUNT";
            spdData.ActiveSheet.Cells[14, 0].Text = "Clean Count";
            spdData.ActiveSheet.Cells[15, 0].Tag = "NEED_CLEAN_FLAG";
            spdData.ActiveSheet.Cells[15, 0].Text = "Need Clean Flag";

            ViewCMFItem();

            View_Attribute_Name_List();           
            
        }
        
        private void ViewCMFItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i, i_seq, i_count;

            try
            {
                
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_CARRIER, ref out_node, "", true) == false)
                {
                    return;
                }

                i_count = 0;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                   if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        i_seq = i + 1;
                        spdData.ActiveSheet.RowCount++;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, 0].Tag = "CRR_CMF_" + i_seq.ToString();
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, 0].Text = out_node.GetList(0)[i].GetString("PROMPT");
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, 3].Tag = out_node.GetList(0)[i].GetString("TABLE_NAME");
                        i_count++;
                                             
                    }                   
                    
                }
                i_attr_row = 16 + i_count;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        public static bool View_Attribute_Name_List()
        {

            int i;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("List_In");
            TRSNode out_node;

            a_list = new ArrayList();

           
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';


            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_CARRIER);
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

            do
            {
                out_node = new TRSNode("List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                s_attr_name = new string[out_node.GetList(0).Count];
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    s_attr_name[i] = out_node.GetList(0)[i].GetString("ATTR_NAME");
                }
            }

            return true;
        }

        private bool ViewAttributeValue(string s_att_name, int i_row)
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_CARRIER);
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvCrrID.Text));
            in_node.AddString("ATTR_NAME", MPCF.Trim(s_att_name));
            
                if (MPCR.CallService("BAS", "BAS_View_Attribute", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdData.ActiveSheet.Cells[i_row, 1].Value = out_node.GetString("ATTR_VALUE");

                if (out_node.GetChar("VALID_TBL_TYPE") == 'A' || out_node.GetChar("VALID_TBL_TYPE") == 'Q')
                {
                    spdData.ActiveSheet.Cells[i_row, 3].Tag = out_node.GetString("VALID_TBL");
                }

                spdData.ActiveSheet.Rows[i_row].Height = spdData.ActiveSheet.GetPreferredRowHeight(i_row);

          
            return true;

        }

        private bool View_Carrier()
        {
            TRSNode in_node = new TRSNode("View_Carrier_In");
            TRSNode out_node = new TRSNode("View_Carrier_Out");
            int i;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }
                txtLastEvent.Text = out_node.GetString("LAST_TRAN_CODE");
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));

                spdData.ActiveSheet.Cells[0, 1].Value = out_node.GetString("CRR_STATUS");
                spdData.ActiveSheet.Cells[1, 1].Value = out_node.GetString("LOCATION_1");
                spdData.ActiveSheet.Cells[2, 1].Value = out_node.GetString("LOCATION_2");
                spdData.ActiveSheet.Cells[3, 1].Value = out_node.GetString("LOCATION_3");
                spdData.ActiveSheet.Cells[4, 1].Value = out_node.GetString("LOCATION_4");
                spdData.ActiveSheet.Cells[5, 1].Value = out_node.GetString("LOCATION_5");
                spdData.ActiveSheet.Cells[6, 1].Value = out_node.GetString("RES_ID");
                spdData.ActiveSheet.Cells[7, 1].Value = out_node.GetString("SUBRES_ID");
                spdData.ActiveSheet.Cells[8, 1].Value = out_node.GetString("PORT_ID");
                spdData.ActiveSheet.Cells[9, 1].Value = out_node.GetString("LOT_ID");
                spdData.ActiveSheet.Cells[10, 1].Value = out_node.GetDouble("QTY_1");
                spdData.ActiveSheet.Cells[11, 1].Value = out_node.GetDouble("QTY_2");
                spdData.ActiveSheet.Cells[12, 1].Value = out_node.GetDouble("QTY_3");
                spdData.ActiveSheet.Cells[13, 1].Value = out_node.GetInt("USAGE_COUNT");
                spdData.ActiveSheet.Cells[14, 1].Value = out_node.GetInt("CLEAN_COUNT");
                spdData.ActiveSheet.Cells[15, 1].Value = out_node.GetChar("NEED_CLEAN_FLAG");

                for (i = 16; i < i_attr_row; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 0].Tag) != "")
                    {
                        spdData.ActiveSheet.Cells[i, 1].Value = out_node.GetString(MPCF.Trim(spdData.ActiveSheet.Cells[i, 0].Tag));
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
        private bool View_Carrier_Event()
        {
            TRSNode in_node = new TRSNode("View_Carrier_Event_In");
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            int i;
            int j;
            double d_temp;

            try
            {
                //ClearData('1');
                crr_event_out = new TRSNode("View_Carrier_Event_Out");
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_EVENT_ID", MPCF.Trim(cdvCrrEventID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Event", in_node, ref crr_event_out) == false)
                {
                    return false;
                }
                cdvCrrEventID.DescText = crr_event_out.GetString("CRR_EVENT_DESC");

                for (i = 0; i < crr_event_out.GetList("CHG_LIST").Count; i++)
                {
                    for (j = 0; j < s_attr_name.Length; j++)
                    {
                        if (MPCF.Trim(s_attr_name[j]) == MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM")))
                        {
                            spdData.ActiveSheet.RowCount++;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount-1, 0].Value = crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM");
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, 0].Tag = crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM");
                            ViewAttributeValue(s_attr_name[j], spdData.ActiveSheet.RowCount - 1);
                        }
                    }
                    
                }
                for (j = 0; j < spdData.ActiveSheet.RowCount; j++)
                {
                    for (i = 0; i < crr_event_out.GetList("CHG_LIST").Count; i++)
                    {
                        if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_OPT") == '1')
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Tag) == MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM")) ||
                                MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Text) == MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM")))
                            {
                                spdData.ActiveSheet.Cells[j, 0].Font = new Font("MS Sans Serif", 8, FontStyle.Bold);
                                break;
                            }
                            
                        }
                        else
                        {
                            spdData.ActiveSheet.Cells[j, 0].Font = new Font("MS Sans Serif", 8, FontStyle.Regular);
                        }
                    }
                }

                // display forecast event item value.
                for (j = 0; j < spdData.ActiveSheet.RowCount; j++)
                {
                    spdData.ActiveSheet.Cells[j, 2].Value = MPCF.Trim(spdData.ActiveSheet.Cells[j, 1].Value);
                    spdData.ActiveSheet.Cells[j, 2].Locked = true;
                    spdData.ActiveSheet.Cells[j, 2].BackColor = System.Drawing.Color.WhiteSmoke;
                    spdData.ActiveSheet.Cells[j, 2].ColumnSpan = 2;
                    for (i = 0; i < crr_event_out.GetList("CHG_LIST").Count; i++)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Tag) == crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM") ||
                            MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Text) == crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM"))
                        {
                            if ((crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == 'Y') &&
                                MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_VALUE")) == "")
                            {
                                spdData.ActiveSheet.Cells[j, 2].Value = "";
                                spdData.ActiveSheet.Cells[j, 2].Locked = false;
                                spdData.ActiveSheet.Cells[j, 2].BackColor = System.Drawing.Color.White;
                                if (MPCF.Trim(spdData.ActiveSheet.Cells[j, 3].Tag) != "")
                                {
                                    btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                    btnCell.Text = "...";
                                    spdData.ActiveSheet.Cells[j, 3].CellType = btnCell;
                                    spdData.ActiveSheet.Cells[j, 2].ColumnSpan = 1;
                                }                                
                            }
                            else if ((crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == 'Y') &&
                                     MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_VALUE")) != "")
                            {
                                spdData.ActiveSheet.Cells[j, 2].Value = MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_VALUE"));
                                
                            }
                            else if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == 'R')
                            {
                                spdData.ActiveSheet.Cells[j, 2].Value = "";
                                
                            }
                            else if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == 'T')
                            {
                                spdData.ActiveSheet.Cells[j, 2].Value = MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT);
                                
                            }
                            else if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == '+')
                            {
                                d_temp = MPCF.ToDbl(spdData.ActiveSheet.Cells[j, 1].Value) + MPCF.ToDbl(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_VALUE"));
                                spdData.ActiveSheet.Cells[j, 2].Value = d_temp;
                                
                            }
                            else if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_FLAG") == '-')
                            {
                                d_temp = MPCF.ToDbl(spdData.ActiveSheet.Cells[j, 1].Value) - MPCF.ToDbl(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_VALUE"));
                                spdData.ActiveSheet.Cells[j, 2].Value = d_temp;
                                
                            }

                            break;
                        }

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

        private bool Carrier_Event(char ProcStep)
        {
            int j;
            int i;
            TRSNode in_node = new TRSNode("CRR_EVENT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("CRR_ID", cdvCrrID.Text);
                in_node.AddString("CRR_EVENT_ID", cdvCrrEventID.Text);
                in_node.AddString("TRAN_COMMENT", txtComment.Text);


                for (j = 0; j < spdData.ActiveSheet.RowCount; j++)
                {
                    for (i = 0; i < crr_event_out.GetList("CHG_LIST").Count; i++)
                    {
                        if (crr_event_out.GetList("CHG_LIST")[i].GetChar("CHG_OPT") == '1')
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Tag) == MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM")) ||
                                MPCF.Trim(spdData.ActiveSheet.Cells[j, 0].Text) == MPCF.Trim(crr_event_out.GetList("CHG_LIST")[i].GetString("CHG_ITEM")))
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.Cells[j, 2].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(j, 2);
                                    spdData.EditModePermanent = true;
                                    spdData.EditMode = true;
                                    return false;
                                }
                                break;
                            }                            
                        }
                    }
                }

                in_node.AddString("CRR_STATUS", MPCF.Trim(spdData.ActiveSheet.Cells[0, 2].Value));
                in_node.AddString("LOCATION_1", MPCF.Trim(spdData.ActiveSheet.Cells[1, 2].Value));
                in_node.AddString("LOCATION_2", MPCF.Trim(spdData.ActiveSheet.Cells[2, 2].Value));
                in_node.AddString("LOCATION_3", MPCF.Trim(spdData.ActiveSheet.Cells[3, 2].Value));
                in_node.AddString("LOCATION_4", MPCF.Trim(spdData.ActiveSheet.Cells[4, 2].Value));
                in_node.AddString("LOCATION_5", MPCF.Trim(spdData.ActiveSheet.Cells[5, 2].Value));
                in_node.AddString("RES_ID", MPCF.Trim(spdData.ActiveSheet.Cells[6, 2].Value));
                in_node.AddString("SUBRES_ID", MPCF.Trim(spdData.ActiveSheet.Cells[7, 2].Value));
                in_node.AddString("PORT_ID", MPCF.Trim(spdData.ActiveSheet.Cells[8, 2].Value));
                in_node.AddInt("USAGE_COUNT", MPCF.ToInt(spdData.ActiveSheet.Cells[13, 2].Value));
                in_node.AddInt("CLEAN_COUNT", MPCF.ToInt(spdData.ActiveSheet.Cells[14, 2].Value));
                in_node.AddChar("NEED_CLEAN_FLAG", MPCF.ToChar(spdData.ActiveSheet.Cells[15, 2].Value));
                
                for (i = 16; i < i_attr_row; i++)
                {
                    in_node.AddString(MPCF.Trim( spdData.ActiveSheet.Cells[i, 0].Tag), MPCF.Trim(spdData.ActiveSheet.Cells[i, 2].Value));
                }
                for (i = i_attr_row; i < spdData.ActiveSheet.RowCount; i++)
                {
                    in_node.AddString(MPCF.Trim(spdData.ActiveSheet.Cells[i, 0].Value), MPCF.Trim(spdData.ActiveSheet.Cells[i, 2].Value));
                }
             
                if (MPCR.CallService("RAS", "RAS_Carrier_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        private void cdvCrrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCrrType.Init();
            MPCF.InitListView(cdvCrrType.GetListView);
            cdvCrrType.Columns.Add("Carrier Type", 50, HorizontalAlignment.Left);
            cdvCrrType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCrrType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
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
                cdvCrrID.Text = "";
            }
        }
        private void cdvCrrID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) == "" && MPCF.Trim(cdvCrrType.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvCrrID.Text) == "")
                    {
                        cdvCrrID.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvCrrID.Focus();
                        return;
                    }
                }
            }

            cdvCrrID.Init();
            MPCF.InitListView(cdvCrrID.GetListView);
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvCrrID.GetListView, '1', cdvCrrGroup.Text, cdvCrrType.Text, cdvCrrID.Text);
        }

        private void cdvCrrEventID_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrEventID.Init();
            MPCF.InitListView(cdvCrrEventID.GetListView);
            cdvCrrEventID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrEventID.SelectedSubItemIndex = 0;
            cdvCrrEventID.DisplaySubItemIndex = 0;
            RASLIST.ViewCarrierEventList(cdvCrrEventID.GetListView, '1', null);
        }

        private void cdvCrrEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if(MPCF.Trim( cdvCrrEventID.Text ) != "")
            {
                spdData.ActiveSheet.RowCount = i_attr_row;
                View_Carrier_Event();                
            }
        }

        private void frmRASTranCarrierEvent_Load(object sender, EventArgs e)
        {
            InitEventInfo();            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Carrier_Event('1') == true)
            {
                spdData.ActiveSheet.RowCount = i_attr_row;
                View_Carrier();
                View_Carrier_Event();
            }
        }

        private void cdvCrrID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtLastEvent.Text = "";
            txtLastEventTime.Text = "";
            spdData.ActiveSheet.ClearRange(0, 1, spdData.ActiveSheet.RowCount, 1, true);
            spdData.ActiveSheet.RowCount = i_attr_row;
            if(MPCF.Trim( cdvCrrID.Text ) != "")
            {
                View_Carrier();
            }            
        }

        private void cdvCrrID_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvCrrEventID.Text = "";
            cdvCrrEventID.DescText = "";
            txtLastEvent.Text = "";
            txtLastEventTime.Text = "";
            spdData.ActiveSheet.ClearRange(0, 1, spdData.ActiveSheet.RowCount, 2, true);
            spdData.ActiveSheet.RowCount = i_attr_row;
            cdvCrrEventID.Text = "";
            cdvCrrEventID.DescText = "";
       }
       private void spdData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
       {
           try
           {
               cdvTableData.Init();
               cdvTableData.ViewPosition = Control.MousePosition;
               MPCF.InitListView(cdvTableData.GetListView);
               cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
               cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
               BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Column].Tag));

               if (cdvTableData.ShowPopupList(e.Row, e.Column) == false)
               {
                   return;
               }
           }
           catch (Exception ex)
           {
               MPCF.ShowMsgBox(ex.Message);
           }
       }

       private void cdvTableData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
       {
           spdData.ActiveSheet.Cells[e.Row, 2].Value = MPCF.Trim(e.SelectedItem.Text);
       }
       
    }
}

