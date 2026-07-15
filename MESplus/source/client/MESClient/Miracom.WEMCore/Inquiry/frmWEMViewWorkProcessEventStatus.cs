using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMViewWorkProcessEventStatus : Miracom.CliFrx.BaseForm04
    {
        public frmWEMViewWorkProcessEventStatus()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private int mi_process_event_width;
        private string ms_current_step_id;
        private int mi_event_hist_seq;
        private bool mb_need_view_process_flag;

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

            spdProgress.ActiveSheet.ColumnCount = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(s_proc_type));
            in_node.AddString("PROC_ID", MPCF.Trim(s_proc_id));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process", in_node, ref out_node) == false)
            {
                return false;
            }

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
            }
            for (i = 0; i < spdProgress.ActiveSheet.ColumnCount; i++)
            {
                spdProgress.ActiveSheet.Columns[i].Width = spdProgress.ActiveSheet.Columns[i].GetPreferredWidth();
            }

            return true;
        }

        private bool ViewWorkProcessEvent(string s_proc_event_id, int i_hist_seq)
        {
            TRSNode in_node = new TRSNode("VIEW_EVENT_STATUS_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_STATUS_OUT");
            TRSNode step_node = new TRSNode("VIEW_PROCESS_STEP_OUT");
            string s_screen_id;
            List<TRSNode> lis_proced_step;
            int i, k;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("PROC_EVENT_ID", s_proc_event_id);

            if (MPCR.CallService("WEM", "WEM_View_Event_Status", in_node, ref out_node) == false)
            {
                return false;
            }

            txtEventStatus.Text = "";
            switch (out_node.GetChar("PROC_STATUS"))
            {
                case 'C': txtEventStatus.Text = MPCF.FindLanguage("Create", CAPTION_TYPE.LABEL); break;
                case 'P': txtEventStatus.Text = MPCF.FindLanguage("Process", CAPTION_TYPE.LABEL); break;
                case 'A': txtEventStatus.Text = MPCF.FindLanguage("Arbitrary Decision", CAPTION_TYPE.LABEL); break;
                case 'L': txtEventStatus.Text = MPCF.FindLanguage("Close", CAPTION_TYPE.LABEL); break;
            }

            if (mb_need_view_process_flag == true)
            {
                if (ViewWorkProcessID(out_node.GetString("WORK_PROC_TYPE"), out_node.GetString("PROC_ID")) == false) return false;
                mb_need_view_process_flag = false;
            }

            for (k = 0; k < spdProgress.ActiveSheet.ColumnCount; k++)
            {
                spdProgress.ActiveSheet.Cells[0, k].BackColor = Color.Empty;
                spdProgress.ActiveSheet.Cells[0, k].Tag = null;
            }

            lis_proced_step = out_node.GetList("PROCESSED_STEP_LIST");
            for (i = 0; i < lis_proced_step.Count; i++)
            {
                for (k = 0; k < spdProgress.ActiveSheet.ColumnCount; k++)
                {
                    if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, k].Value) == lis_proced_step[i].GetString("STEP_ID"))
                    {
                        if (i == 0)
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

                        if (i_hist_seq > 0 && i_hist_seq == lis_proced_step[i].GetInt("HIST_SEQ"))
                        {
                            spdProgress.ActiveSheet.Cells[0, k].BackColor = Color.Orange;
                        }
                        break;
                    }
                }
            }

            in_node.Init();
            out_node.Init();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("PROC_EVENT_ID", MPCF.Trim(s_proc_event_id));
            in_node.AddInt("HIST_SEQ", i_hist_seq);

            if (MPCR.CallService("WEM", "WEM_View_Event_Status_Detail", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvProcType.Text = out_node.GetString("WORK_PROC_TYPE");
            cdvProcID.Text = out_node.GetString("PROC_ID");
            cdvProcEventID.Text = out_node.GetString("PROC_EVENT_ID");
            txtEventDesc.Text = out_node.GetString("PROC_EVENT_DESC");
            txtComment.Text = out_node.GetString("TRAN_COMMENT");
            ms_current_step_id = out_node.GetString("STEP_ID");

            this.Text = MPCF.FindLanguage("View Work Process Event Status", CAPTION_TYPE.MENU) + "-" + cdvProcEventID.Text + "(" + ms_current_step_id + ")";


            in_node.Init();
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("WORK_PROC_TYPE", out_node.GetString("WORK_PROC_TYPE"));
            in_node.AddString("STEP_ID", out_node.GetString("STEP_ID"));

            if (MPCR.CallService("WEM", "WEM_View_Process_Step", in_node, ref step_node) == false)
            {
                return false;
            }

            s_screen_id = step_node.GetString("SCREEN_ID");

            udcScreen.InitFlexibleScreen();
            if (udcScreen.LoadDesign(s_screen_id) == false) return false;
            if (udcScreen.SetDataToScreen(out_node) == false) return false;

            List<TRSNode> lis_status;
            char c_status_type;
            string s_status_name;
            clsFlexibleScreenInputValue fsiv = new clsFlexibleScreenInputValue();

            lis_status = step_node.GetList("STATUS_LIST");
            for (i = 0; i < lis_status.Count; i++)
            {
                c_status_type = lis_status[i].GetChar("STATUS_TYPE");
                s_status_name = lis_status[i].GetString("STATUS");

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
                else if (c_status_type == 'U')
                {
                    switch (lis_status[i].GetChar("ST_FORMAT"))
                    {
                        case 'A':
                            fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.TEXT, 32700, Color.Empty, 'A', false);
                            if (lis_status[i].GetString("DATA_2") == "Y")
                            {
                                fsiv.SetMultiLineFlag(s_status_name, true);
                            }
                            break;
                        case 'C':
                            fsiv.AddCell(s_status_name, FSCREEN_CELL_TYPE.CHECKBOX, Color.Empty, 'A', false);
                            if (lis_status[i].GetString("DATA_3") == "Y")
                            {
                                fsiv.SetCheckBoxDesc(s_status_name, lis_status[i].GetString("STATUS_DESC"));
                                fsiv.SetDisplayDescFlag(s_status_name, true);
                            }
                            break;
                    }
                }
            }

            udcScreen.SetInputCellInfo(fsiv);
            udcScreen.ScreenLock = true;

            return true;
        }

        public void SetWorkProcessEvent(string s_proc_event_id, int i_hist_seq)
        {
            mb_need_view_process_flag = true;
            cdvProcEventID.Text = s_proc_event_id;
            mi_event_hist_seq = i_hist_seq;

            if (b_load_flag == true)
            {
                btnView.PerformClick();
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

        private void frmWEMViewWorkProcessEventStatus_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                btnCollapse.Enabled = true;
                btnExpand.Enabled = false;
                udcScreen.InitFlexibleScreen();

                if (MPCF.Trim(cdvProcEventID.Text) != "" && mi_event_hist_seq > 0)
                {
                    btnView.PerformClick();
                }

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

        private void cdvProcType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvProcID.Text = "";
            cdvProcEventID.Text = "";
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
            cdvProcEventID.Text = "";

            if (cdvProcID.Text != "")
            {
                if (ViewWorkProcessID(cdvProcType.Text, cdvProcID.Text) == false) return;
            }
        }

        private void cdvProcEventID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;
            if (MPCF.CheckValue(cdvProcID, 1) == false) return;

            cdvProcEventID.Init();
            MPCF.InitListView(cdvProcEventID.GetListView);
            cdvProcEventID.Columns.Add("Process Event ID", 150, HorizontalAlignment.Left);
            cdvProcEventID.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcEventID.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessEventList(cdvProcEventID.GetListView, cdvProcType.Text, cdvProcID.Text);
        }

        private void cdvProcEventID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            mi_event_hist_seq = 0;
            btnView.PerformClick();
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

        private void btnToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                sfdPDF.Filter = "PDF Files | *.pdf";
                sfdPDF.FileName = cdvProcEventID.Text + "(" + ms_current_step_id + ")";
                if (sfdPDF.ShowDialog() == DialogResult.OK)
                {
                    FarPoint.Win.Spread.PrintInfo printset = udcScreen.ScreenView.PrintInfo;
                    printset.Header = "/c /fu1 /fn\"Microsoft Sans Serif\" /fz\"20\"The process event status of " + cdvProcEventID.Text + " (" + ms_current_step_id + ")/n /fu0 /r /ds /ts";
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvProcEventID.Text) != "")
            {
                if (ViewWorkProcessEvent(cdvProcEventID.Text, mi_event_hist_seq) == false) return;
            }
        }

        private void spdProgress_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string[] s_hist_seq;

            if (MPCF.Trim(spdProgress.ActiveSheet.Cells[0, e.Column].Tag) == "") return;

            s_hist_seq = MPCF.Trim(spdProgress.ActiveSheet.Cells[0, e.Column].Tag).Split(',');
            mi_event_hist_seq = MPCF.ToInt(s_hist_seq[0]);

            btnView.PerformClick();
        }



    }
}
