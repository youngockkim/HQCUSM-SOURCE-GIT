using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMTranWorkProcessEvent : Miracom.MESCore.TranForm01
    {
        public frmWEMTranWorkProcessEvent()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private int mi_process_event_width;
        private bool mb_writable_status;
        private string ms_current_step_id;
        private string ms_first_step_id;

        #endregion

        #region " Function Definition "

        private bool ViewWorkProcessID(string s_proc_type, string s_proc_id)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_ID_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_ID_OUT");
            List<TRSNode> lis_step;
            List<string> ls_step_groups;
            int i;
            int i_col;
            string s_step_group;
            string s_prev_step_group;
            ListViewItem itm;

            spdProgress.ActiveSheet.ColumnCount = 0;
            ms_first_step_id = "";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(s_proc_type));
            in_node.AddString("PROC_ID", MPCF.Trim(s_proc_id));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process", in_node, ref out_node) == false)
            {
                return false;
            }

            this.Text = out_node.GetString("TITLE");
            btnGenEventID.Tag = out_node.GetString("ID_GEN_RULE");

            btnGenEventID.Enabled = false;
            if (MPCF.Trim(btnGenEventID.Tag) != "")
            {
                btnGenEventID.Enabled = true;
            }

            cdvNextStep.Init();
            MPCF.InitListView(cdvNextStep.GetListView);
            cdvNextStep.Columns.Add("Step ID", 50, HorizontalAlignment.Left);
            cdvNextStep.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvNextStep.SelectedSubItemIndex = 0;
            cdvNextStep.AddEmptyRow(1);

            ls_step_groups = new List<string>();
            s_prev_step_group = "";

            lis_step = out_node.GetList("STEP_LIST");
            for (i = 0; i < lis_step.Count; i++)
            {
                i_col = spdProgress.ActiveSheet.ColumnCount;
                spdProgress.ActiveSheet.ColumnCount++;

                s_step_group = lis_step[i].GetString("STEP_GROUP");
                if (s_prev_step_group != "" && s_prev_step_group != s_step_group)
                {
                    if (ls_step_groups.Contains(s_prev_step_group) == true)
                    {
                        ls_step_groups.Remove(s_prev_step_group);
                        spdProgress.ActiveSheet.Cells[0, i_col].Value = ")";
                        i_col++;
                        spdProgress.ActiveSheet.ColumnCount++;
                    }
                }
                s_prev_step_group = s_step_group;

                if (i > 0)
                {
                    if (ls_step_groups.Count > 0)
                    {
                        spdProgress.ActiveSheet.Cells[0, i_col].Value = ",";
                    }
                    else
                    {
                        spdProgress.ActiveSheet.Cells[0, i_col].Value = ">";
                    }

                    i_col++;
                    spdProgress.ActiveSheet.ColumnCount++;
                }

                if (s_step_group != "")
                {
                    if (ls_step_groups.Contains(s_step_group) == false)
                    {
                        ls_step_groups.Add(s_step_group);
                        spdProgress.ActiveSheet.Cells[0, i_col].Value = "(";
                        i_col++;
                        spdProgress.ActiveSheet.ColumnCount++;
                    }
                }

                spdProgress.ActiveSheet.Cells[0, i_col].Value = lis_step[i].GetString("STEP_ID");
                spdProgress.ActiveSheet.Cells[0, i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdProgress.ActiveSheet.Cells[0, i_col].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                itm = new ListViewItem(lis_step[i].GetString("STEP_ID"), (int)SMALLICON_INDEX.IDX_MODULE);
                itm.SubItems.Add(lis_step[i].GetString("STEP_DESC"));
                cdvNextStep.Items.Add(itm);

                if (i == 0)
                {
                    ms_first_step_id = lis_step[i].GetString("STEP_ID");
                }
            }
            for (i = 0; i < spdProgress.ActiveSheet.ColumnCount; i++)
            {
                spdProgress.ActiveSheet.Columns[i].Width = spdProgress.ActiveSheet.Columns[i].GetPreferredWidth();
            }

            return true;
        }

        private bool ViewProcessStep(string s_proc_type, string s_proc_id, string s_step_id)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_STEP_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_STEP_OUT");
            string s_assign_option;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(s_proc_type));
            in_node.AddString("PROC_ID", MPCF.Trim(s_proc_id));
            in_node.AddString("STEP_ID", MPCF.Trim(s_step_id));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process_Step", in_node, ref out_node) == false)
            {
                return false;
            }

            /* ASSIGN_OPTION : Readable | Writable = 0, Receive Notification = 1, Allow Skip = 2, Approver = 3, Allow goto any step = 4, System Reserve = 5 ~ 29 */
            s_assign_option = out_node.GetString("ASSIGN_OPTION");

            grpNextStepApprover.Visible = false;
            if (out_node.GetChar("INPUT_APPROVER_FLAG") == 'Y')
            {
                grpNextStepApprover.Visible = true;
                cdvNextUserID.Text = "";
                rbnUser.Checked = true;
            }

            chkArbitrary.Tag = null;
            chkApproval.Tag = null;
            chkSkip.Tag = null;

            chkArbitrary.Enabled = false;
            chkArbitrary.Checked = false;

            chkApproval.Enabled = false;
            chkApproval.Checked = false;

            chkSkip.Enabled = false;
            chkSkip.Checked = false;

            chkArbitrary.Tag = out_node.GetChar("ARBITRARY_FLAG");

            if (out_node.GetChar("OPTIONAL_FLAG") == 'Y' || s_assign_option[2] == 'Y')
            {
                chkSkip.Enabled = true;
                chkSkip.Tag = 'Y';
            }

            if (s_assign_option[3] == 'Y')
            {
                chkApproval.Enabled = true;
                chkApproval.Tag = 'Y';
            }

            mb_writable_status = false;
            if (s_assign_option[0] == 'W')
            {
                mb_writable_status = true;
            }

            return true;
        }

        private bool ViewProcessStepStatus(string s_proc_type, string s_step_id, string s_proc_event_id)
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_STEP_STATUS_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_STEP_STATUS_OUT");
            TRSNode step_node = new TRSNode("VIEW_PROCESS_STEP_OUT");
            string s_screen_id;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(s_proc_type));
            in_node.AddString("STEP_ID", MPCF.Trim(s_step_id));
            in_node.AddString("PROC_EVENT_ID", MPCF.Trim(s_proc_event_id));

            if (MPCR.CallService("WEM", "WEM_View_Event_Step_Status", in_node, ref out_node) == false)
            {
                return false;
            }

            in_node.Init();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(s_proc_type));
            in_node.AddString("STEP_ID", MPCF.Trim(s_step_id));

            if (MPCR.CallService("WEM", "WEM_View_Process_Step", in_node, ref step_node) == false)
            {
                return false;
            }

            s_screen_id = step_node.GetString("SCREEN_ID");

            udcScreen.InitFlexibleScreen();
            if (udcScreen.LoadDesign(s_screen_id) == false) return false;
            if (udcScreen.SetDataToScreen(out_node) == false) return false;

            udcScreen.ScreenLock = !mb_writable_status;
            if (mb_writable_status == true)
            {
                udcScreen.ScreenLockBackColor = Color.Empty;
            }
            else
            {
                udcScreen.ScreenLockBackColor = Color.WhiteSmoke;
            }


            List<TRSNode> lis_status;
            int i;
            int i_value_size;
            char c_input_type;
            char c_st_format;
            char c_required;
            char c_status_type;
            string s_status_name;
            string s_gcm_table_name;
            char c_multi_line_flag;
            string s_status_desc;
            char c_display_desc_flag; 

            Color back_color;
            clsFlexibleScreenInputValue fsiv = new clsFlexibleScreenInputValue();

            lis_status = step_node.GetList("STATUS_LIST");
            for (i = 0; i < lis_status.Count; i++)
            {
                back_color = Color.FromArgb(lis_status[i].GetInt("BACK_COLOR"));
                i_value_size = lis_status[i].GetInt("ST_SIZE");
                c_input_type = lis_status[i].GetChar("INPUT_TYPE");
                c_st_format = lis_status[i].GetChar("ST_FORMAT");
                c_required = lis_status[i].GetChar("REQUIRED_FLAG");
                c_status_type = lis_status[i].GetChar("STATUS_TYPE");
                s_status_name = lis_status[i].GetString("STATUS");
                s_gcm_table_name = lis_status[i].GetString("DATA_1");
                c_multi_line_flag = MPCF.ToChar(lis_status[i].GetString("DATA_2"));
                s_status_desc = lis_status[i].GetString("STATUS_DESC");
                c_display_desc_flag = MPCF.ToChar(lis_status[i].GetString("DATA_3"));

                if (c_status_type == 'I' || c_status_type == 'F')
                {
                    string s_file_name;
                    string s_bin_data_name;
                    byte[] file_buffer;
                    int i_bin_data_index;

                    s_file_name = out_node.GetString(s_status_name);
                    if (MPCF.Trim(s_file_name) != "")
                    {
                        i_bin_data_index = MPCF.ToInt(s_file_name.Substring(0, 2));
                        s_file_name = s_file_name.Substring(3);

                        s_bin_data_name = MPGC.MP_BIN_DATA_1.Substring(0, MPGC.MP_BIN_DATA_1.Length - 1);
                        s_bin_data_name += i_bin_data_index.ToString();

                        file_buffer = out_node.GetBlob(s_bin_data_name);
                        if (file_buffer == null)
                        {
                            if (c_status_type == 'I')
                            {
                                udcScreen.SetImageCell(s_status_name, null);
                            }
                            else if (c_status_type == 'F')
                            {
                                udcScreen.SetHyperLinkCell(s_status_name, "", "");
                            }
                        }
                        else
                        {
                            if (c_status_type == 'I')
                            {
                                MemoryStream ms_buffer;
                                ms_buffer = new MemoryStream();
                                ms_buffer.Write(file_buffer, 0, file_buffer.Length);
                                ms_buffer.Position = 0;

                                udcScreen.SetImageCell(s_status_name, Image.FromStream(ms_buffer));
                            }
                            else if (c_status_type == 'F')
                            {
                                s_bin_data_name = s_file_name;
                                s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_bin_data_name;
                                FileStream fs = File.Open(s_file_name, FileMode.Create);
                                BinaryWriter writer = new BinaryWriter(fs);
                                writer.Write(file_buffer, 0, file_buffer.Length);
                                writer.Close();

                                udcScreen.SetHyperLinkCell(s_status_name, s_file_name, s_bin_data_name);
                            }
                        }
                    }
                }

                if (c_status_type == 'U')
                {
                    if (MPCF.Trim(s_gcm_table_name) == "")
                    {
                        switch (c_st_format)
                        {
                            case 'A':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                if (c_multi_line_flag == 'Y')
                                {
                                    fsiv.SetMultiLineFlag(s_status_name, true);
                                }
                                break;
                            case 'N':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.NUMBER, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case 'F':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.FLOAT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case 'D':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.DATE, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case 'T':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TIME, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case 'M':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.DATETIME, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case 'C':
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.CHECKBOX, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                if (c_display_desc_flag == 'Y')
                                {
                                    fsiv.SetCheckBoxDesc(s_status_name, s_status_desc);
                                    fsiv.SetDisplayDescFlag(s_status_name, true);
                                }
                                break;

                            case '1': //Current Date
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.DATE, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '2': //Current Time
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TIME, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '3': //Current DateTime
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.DATETIME, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '4': //Current Shift
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '5': //Login User ID
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '6': //Login User Desc
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                            case '7': //Login Factory
                                c_input_type = c_input_type == 'I' ? 'A' : c_input_type;
                                fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, i_value_size, back_color, c_input_type, (c_required == 'Y' ? true : false));
                                break;
                        }
                    }
                    else
                    {
                        fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.COMBOBOX, back_color, c_input_type, (c_required == 'Y' ? true : false));

                        ListView lisTemp = new ListView();
                        lisTemp.Columns.Add("Code", 50, HorizontalAlignment.Left);
                        lisTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        BASLIST.ViewGCMDataList(lisTemp, '1', s_gcm_table_name);

                        for (int k = 0; k < lisTemp.Items.Count; k++)
                        {
                            fsiv.SetComboItem(s_status_name, lisTemp.Items[k].SubItems[0].Text, lisTemp.Items[k].SubItems[1].Text);
                        }
                    }
                }
                else if (c_status_type == 'A' || c_status_type == 'T')
                {
                    fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.VIEW_ONLY, back_color, 'V', false);
                }
                else if (c_status_type == 'I')
                {
                    fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.IMAGE, back_color, c_input_type, (c_required == 'Y' ? true : false));
                }
                else if (c_status_type == 'F')
                {
                    fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.HYPERLINK, back_color, c_input_type, (c_required == 'Y' ? true : false));
                }
            }//end for

            udcScreen.SetInputCellInfo(fsiv);

            return true;
        }

        private bool ViewProcessEventList()
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_LIST_OUT");
            List<TRSNode> lis_proc_event;
            ListViewItem itm;
            int i;

            MPCF.InitListView(lisEvent);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ASSIGNED_USER_ID", MPGV.gsUserID);

            if (MPCR.CallService("WEM", "WEM_View_Event_List", in_node, ref out_node) == false)
            {
                return false;
            }

            lis_proc_event = out_node.GetList("PROC_EVENT_LIST");
            for (i = 0; i < lis_proc_event.Count; i++)
            {
                itm = new ListViewItem(lis_proc_event[i].GetString("PROC_EVENT_ID"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                itm.SubItems.Add(lis_proc_event[i].GetString("PROC_EVENT_DESC"));
                itm.SubItems.Add(lis_proc_event[i].GetString("STEP_ID"));
                itm.SubItems.Add(lis_proc_event[i].GetString("PROC_ID"));
                itm.SubItems.Add(lis_proc_event[i].GetString("WORK_PROC_TYPE"));

                lisEvent.Items.Add(itm);
            }

            return true;
        }

        private bool ViewProcessEvent(string s_proc_event_id)
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_STATUS_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_STATUS_OUT");
            List<TRSNode> lis_proced_step;
            int i, k;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("PROC_EVENT_ID", s_proc_event_id);

            if (MPCR.CallService("WEM", "WEM_View_Event_Status", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvProcType.Text = out_node.GetString("WORK_PROC_TYPE");
            cdvProcID.Text = out_node.GetString("PROC_ID");
            txtEventID.Text = out_node.GetString("PROC_EVENT_ID");
            txtEventDesc.Text = out_node.GetInt("LAST_ACTIVE_HIST_SEQ").ToString();
            ms_current_step_id = out_node.GetString("STEP_ID");

            if (ViewWorkProcessID(cdvProcType.Text, cdvProcID.Text) == false) return false;
            if (ViewProcessStep(cdvProcType.Text, cdvProcID.Text, ms_current_step_id) == false) return false;
            if (ViewProcessStepStatus(cdvProcType.Text, ms_current_step_id, s_proc_event_id) == false) return false;

            if (out_node.GetChar("USER_CAN_APPROVAL_FLAG") == 'Y' && chkApproval.Enabled == false)
            {
                chkApproval.Enabled = true;
                chkApproval.Tag = 'Y';
            }

            lis_proced_step = out_node.GetList("PROCESSED_STEP_LIST");
            for (i = 0; i < lis_proced_step.Count; i++)
            {
                for (k = 0; k < spdProgress.ActiveSheet.ColumnCount; k++)
                {
                    if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, k].Value) == lis_proced_step[i].GetString("STEP_ID"))
                    {
                        if(i == 0)
                        {
                            spdProgress.ActiveSheet.Cells[0, k].BackColor = Color.Cyan;
                        }
                        else if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, k].Tag) == "")
                        {
                            spdProgress.ActiveSheet.Cells[0, k].BackColor = Color.GreenYellow;
                        }

                        if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, k].Tag) == "")
                        {
                            spdProgress.ActiveSheet.Cells[0, k].Tag = lis_proced_step[i].GetInt("HIST_SEQ").ToString();
                        }
                        else
                        {
                            spdProgress.ActiveSheet.Cells[0, k].Tag = MPCF.Trim(spdProgress.ActiveSheet.Cells[0, k].Tag) + "," + lis_proced_step[i].GetInt("HIST_SEQ").ToString();
                        }
                        break;
                    }
                }
            }

            return true;
        }

        private bool GenerateEventID()
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '2';
                in_node.AddString("RULE_ID", MPCF.Trim(btnGenEventID.Tag));

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtEventID.Text = MPCF.Trim(out_node.GetString("GEN_ID"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return false;

            if (chkNew.Checked == true)
            {
                if (MPCF.CheckValue(cdvProcID, 1) == false) return false;
                if (MPCF.CheckValue(txtEventID, 1) == false) return false;
            }
            else
            {
                if (lisEvent.SelectedItems.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    lisEvent.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ProcessEvent()
        {
            TRSNode in_node = new TRSNode("PROC_EVENT_IN");
            TRSNode out_node = new TRSNode("PROC_EVENT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (chkNew.Checked == true)
            {
                in_node.AddChar("CREATE_EVENT_FLAG", 'Y');
                in_node.AddString("PROC_EVENT_ID", txtEventID.Text);
                in_node.AddString("PROC_EVENT_DESC", txtEventDesc.Text);

                in_node.AddString("WORK_PROC_TYPE", cdvProcType.Text);
                in_node.AddString("PROC_ID", cdvProcID.Text);
                in_node.AddString("STEP_ID", ms_first_step_id);
            }
            else
            {
                in_node.AddString("PROC_EVENT_ID", txtEventID.Text);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(txtEventDesc.Text));

                in_node.AddChar("APPROVAL_FLAG", chkApproval.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SKIP_STEP_FLAG", chkSkip.Checked == true ? 'Y' : ' ');
                in_node.AddChar("ARBITRARY_FLAG", chkArbitrary.Checked == true ? 'Y' : ' ');
            }

            in_node.AddString("TRAN_COMMENT", txtComment.Text);
            in_node.AddString("NEXT_STEP_ID", cdvNextStep.Text);
            if (MPCF.Trim(cdvNextUserID.Text) != "")
            {
                in_node.AddString("NEXT_APPROVER", cdvNextUserID.Text);
                if (rbnUser.Checked == true) in_node.AddChar("NEXT_APPROVER_TYPE", 'U');
                if (rbnSecGroup.Checked == true) in_node.AddChar("NEXT_APPROVER_TYPE", 'S');
                if (rbnPrvGroup.Checked == true) in_node.AddChar("NEXT_APPROVER_TYPE", 'P');
            }

            if (mb_writable_status == true && chkSkip.Checked == false)
            {
                clsFlexibleScreenInputValue fsiv = udcScreen.GetInputCellValue();
                if (fsiv == null) return false;

                fsiv.SetInputValueToTRSNode(in_node);
            }

            if (MPCR.CallService("WEM", "WEM_Process_Event", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private void ClearField(int i_case)
        {
            switch (i_case)
            {
                case 1:
                    spdProgress.ActiveSheet.ColumnCount = 0;
                    udcScreen.InitFlexibleScreen();
                    cdvNextStep.Text = "";
                    txtComment.Text = "";
                    break;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvProcType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWEMSetupProcessAction_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisEvent);

                pnlNewEvent.Visible = false;
                pnlNewEvent.Location = new Point(7, 107);

                btnCollapse.Enabled = true;
                btnExpand.Enabled = false;

                grpNextStepApprover.Visible = false;
                udcScreen.InitFlexibleScreen();
                btnRefresh.PerformClick();

                b_load_flag = true;
            }
        }

        private void cdvProcType_ButtonPress(object sender, EventArgs e)
        {
            cdvProcType.Init();
            MPCF.InitListView(cdvProcType.GetListView);
            cdvProcType.Columns.Add("Process Type", 150, HorizontalAlignment.Left);
            cdvProcType.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcType.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessTypeList(cdvProcType.GetListView);
        }

        private void cdvProcID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;

            cdvProcID.Init();
            MPCF.InitListView(cdvProcID.GetListView);
            cdvProcID.Columns.Add("Process ID", 150, HorizontalAlignment.Left);
            cdvProcID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcID.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessList(cdvProcID.GetListView, cdvProcType.Text);
        }

        private void cdvProcID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvProcID.Text != "")
            {
                if (ViewWorkProcessID(cdvProcType.Text, cdvProcID.Text) == false) return;
            }
        }

        private void splProcEventID_SplitterMoved(object sender, SplitterEventArgs e)
        {
            btnCollapse.Location = new Point(splProcEventID.Location.X, btnCollapse.Location.Y);
            btnExpand.Location = new Point(splProcEventID.Location.X, btnExpand.Location.Y);
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            mi_process_event_width = pnlProcEventID.Width;
            pnlProcEventID.Width = 0;

            btnCollapse.Enabled = false;
            btnExpand.Enabled = true;

            splProcEventID_SplitterMoved(null, null);
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            pnlProcEventID.Width = mi_process_event_width;

            btnCollapse.Enabled = true;
            btnExpand.Enabled = false;

            splProcEventID_SplitterMoved(null, null);
        }

        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {
            string s_step_id;

            if (chkNew.Checked == true)
            {
                if (MPCF.CheckValue(cdvProcType, 1) == false)
                {
                    chkNew.Checked = false;
                    return;
                }

                if (MPCF.CheckValue(cdvProcID, 1) == false)
                {
                    chkNew.Checked = false;
                    return;
                }

                pnlNewEvent.Visible = true;
                lisEvent.Visible = false;

                txtEventID.Text = "";
                txtEventDesc.Text = "";
                ms_first_step_id = "";

                udcScreen.InitFlexibleScreen();

                if (ViewWorkProcessID(cdvProcType.Text, cdvProcID.Text) == false) return;

                if (ms_first_step_id != "")
                {
                    s_step_id = ms_first_step_id;
                    ms_current_step_id = s_step_id;

                    if (ViewProcessStep(cdvProcType.Text, cdvProcID.Text, s_step_id) == false) return;
                    if (ViewProcessStepStatus(cdvProcType.Text, s_step_id, "") == false) return;
                }

                chkApproval.Checked = false;
                chkApproval.Enabled = false;
                chkSkip.Enabled = false;
            }
            else
            {
                pnlNewEvent.Visible = false;
                lisEvent.Visible = true;
            }
        }

        private void rbnNextUser_CheckedChanged(object sender, EventArgs e)
        {
            cdvNextUserID.Init();
            MPCF.InitListView(cdvNextUserID.GetListView);
            cdvNextUserID.Columns.Add("User ID", 150, HorizontalAlignment.Left);
            cdvNextUserID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvNextUserID.SelectedSubItemIndex = 0;

            cdvNextUserID.Text = "";
            if (rbnUser.Checked == true)
            {
                SECLIST.ViewSECUserList(cdvNextUserID.GetListView);
            }
            else if (rbnSecGroup.Checked == true)
            {
                SECLIST.ViewSecGroupList(cdvNextUserID.GetListView);
            }
            else if (rbnPrvGroup.Checked == true)
            {
                SECLIST.ViewPrvGroupList(cdvNextUserID.GetListView);
            }
        }

        private void btnGenEventID_Click(object sender, EventArgs e)
        {
            GenerateEventID();
        }

        private void chkApproval_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApproval.Checked == true)
            {
                if (MPCF.Trim(chkArbitrary.Tag) == "Y")
                {
                    chkArbitrary.Enabled = true;
                }
                else
                {
                    chkArbitrary.Checked = false;
                    chkArbitrary.Enabled = false;
                }

                chkSkip.Checked = false;
                chkSkip.Enabled = false;
            }
            else
            {
                chkArbitrary.Checked = false;
                chkArbitrary.Enabled = false;

                if (MPCF.Trim(chkSkip.Tag) == "Y")
                {
                    chkSkip.Enabled = true;
                }
                else
                {
                    chkSkip.Checked = false;
                    chkSkip.Enabled = false;
                }
            }
        }

        private void chkSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkip.Checked == true)
            {
                chkApproval.Checked = false;
                chkApproval.Enabled = false;
            }
            else
            {
                if (MPCF.Trim(chkApproval.Tag) == "Y")
                {
                    chkApproval.Enabled = true;
                }
                else
                {
                    chkApproval.Checked = false;
                    chkApproval.Enabled = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string s_proc_event_id = "";
            if (lisEvent.SelectedItems.Count > 0)
            {
                s_proc_event_id = lisEvent.SelectedItems[0].Text;
            }

            if (ViewProcessEventList() == false) return;

            if (s_proc_event_id != "")
            {
                MPCF.FindListItem(lisEvent, s_proc_event_id, false);
            }

            chkNew.Checked = false;
        }

        private void lisEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisEvent.SelectedItems.Count < 1) return;

            string s_proc_event_id = lisEvent.SelectedItems[0].Text;
            if (ViewProcessEvent(s_proc_event_id) == false) return;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return;
            if (ProcessEvent() == false) return;

            ClearField(1);
            btnRefresh.PerformClick();
        }

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                sfdPDF.Filter = "PDF Files | *.pdf";
                sfdPDF.FileName = txtEventID.Text + "(" + ms_current_step_id + ")";
                if (sfdPDF.ShowDialog() == DialogResult.OK)
                {
                    FarPoint.Win.Spread.PrintInfo printset = udcScreen.ScreenView.PrintInfo;
                    printset.Header = "/c /fu1 /fn\"Microsoft Sans Serif\" /fz\"20\"" + txtEventID.Text + " (" + ms_current_step_id + ")/n /fu0 /r /ds /ts";
                    printset.PrintToPdf = true;
                    //printset.Orientation = FarPoint.Win.Spread.PrintOrientation.Auto;
                    printset.ShowColor = true;
                    printset.PdfFileName = sfdPDF.FileName;

                    // Assign the printer settings and print
                    //udcScreen.ScreenView.PrintInfo = printset;
                    udcScreen.ScreenSpread.PrintSheet(0);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdProgress_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string[] s_hist_seq;
            int i_hist_seq;
            int i;

            if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, e.Column].Tag) == "") return;

            e.Cancel = true;

            s_hist_seq = MPCF.Trim(spdProgress.ActiveSheet.Cells[0, e.Column].Tag).Split(',');
            for (i = 0; i < s_hist_seq.Length; i++)
            {
                i_hist_seq = MPCF.ToInt(s_hist_seq[i]);

                frmWEMViewWorkProcessEventStatus f = new frmWEMViewWorkProcessEventStatus();
                f.MdiParent = MPGV.gfrmMDI;
                f.SetWorkProcessEvent(txtEventID.Text, i_hist_seq);
                f.Show();
            }
        }
    
    
    
    }
}
