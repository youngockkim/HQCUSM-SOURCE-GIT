using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.CliFrx;
using SOI.OIFrx.SOIModel;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCWIPTabberJigRepair : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string[,] m_strJigRepairReason;

        #endregion

        #region Constructor

        public frmCWIPTabberJigRepair()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_common_line;
        public string chk_auto;
        public bool mbKeyPressed = false;

        public enum DATA_LIST
        {
            MODE,
            MODE_STATE,
            JGR_PROC,
            JGR_PROC_NAME,
            WORK_DATE,
            SEQ,
            WORK_TIME,
            JIG_NO,
            WRKR_NAME,
            DEPT_NO,
            DEPT_NAME,
            WORK_LINE,
            TABBER,
            REASON_CD,
            REASON,
            REMARK,
        }


        #endregion

        #region [Variable Definition]
        
        #endregion


        #region Function
        
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "CREATE":
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                                              
                        break;

                    case "VIEW":
                        //if (MPCF.CheckValue(dtpDate, false) == false)
                        //{
                        //    return false;
                        //}

                        break;

                    case "UPDATE":
                        if (spdJigRepair.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(590));
                            return false;
                        }


                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }
                         


                        break;
                    case "APPEND":
                        if (MPCF.CheckValue(cboJigRepairProcess, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvDepartment, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtName, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtJigNo, false) == false)
                        {
                            return false;
                        }
                         
                        break;

                    case "DELETE":
                        if (spdJigRepair.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox( "Please, select the row to delete.");
                            return false;
                        }

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private string getJigRepairReasonName(string text)
        {
            string strNames = "";
            string[] list = text.Split(',');
            for (int inx = 0; inx <= m_strJigRepairReason.GetUpperBound(0); inx++)
            {
                for (int jnx = 0; jnx < list.Length; jnx++)
                {
                    if (m_strJigRepairReason[inx, 0].Equals(list[jnx]))
                    {
                        strNames = strNames + (jnx == 0 ? "" : ",") + m_strJigRepairReason[inx, 1];
                    }
                }
            }

            return strNames;
        }

        private string getJigRepairInfo(string text, bool bCode)
        {

            for (int inx = 0; inx < m_strJigRepairReason.Length; inx++)
            {
                if (m_strJigRepairReason[inx, 1].Equals(text))
                {
                    return m_strJigRepairReason[inx, bCode?0:1];
                }
            }

            return "";
        }

        private string getJigRepairStatus(bool bCode)
        {
            string status = "";

            if (chkPinSpring.Checked)
            {
                status = getJigRepairInfo(chkPinSpring.Text, bCode);
                
            }
            if (chkPad.Checked)
            {
                status = status.Length > 0 ? status + "," + getJigRepairInfo(chkPad.Text, bCode) : getJigRepairInfo(chkPad.Text, bCode);

            }
            if (chkFrame.Checked)
            {
                status = status.Length > 0 ? status + "," + getJigRepairInfo(chkFrame.Text, bCode) : getJigRepairInfo(chkFrame.Text, bCode); 

            }
            if (chkDefect.Checked)
            {
                status = status.Length > 0 ? status + "," + getJigRepairInfo(chkDefect.Text, bCode) : getJigRepairInfo(chkDefect.Text, bCode); 

            }
            if (chkOther.Checked)
            {
                status = status.Length > 0 ? status + "," + getJigRepairInfo(chkOther.Text, bCode) : getJigRepairInfo(chkOther.Text, bCode); 

            }

            return status;
        }
        
        private void setJigRepairStatus(string strCodes)
        {
            string[] list = strCodes.Split(',');

            for (int jnx = 0; jnx < list.Length; jnx++)
            {
                if (list[jnx].Equals("JRR100"))
                {
                    chkPinSpring.Checked = true;
                }
                if (list[jnx].Equals("JRR200"))
                {
                    chkPad.Checked = true;
                }
                if (list[jnx].Equals("JRR300"))
                {
                    chkFrame.Checked = true;
                }
                if (list[jnx].Equals("JRR400"))
                {
                    chkDefect.Checked = true;
                }
                if (list[jnx].Equals("JRR500"))
                {
                    chkOther.Checked = true;
                }
            }
        }

        private bool ViewJigRepairList()
        {
            try
            {
                int i;


                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdJigRepair);

                TRSNode in_node = new TRSNode("VIEW_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                //if (dtpDate.Value != null)
                //{
                //    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                //    if (bTrySuccess == true)
                //    {
                //        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                //    }
                //}

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("WORK_DATE", dtpFromDateTimeOut);

                if (MPCF.CallService("CRAS", "CRAS_View_Tabber_Jig_Repair_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdJigRepair.ActiveSheet.RowCount = 0;


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdJigRepair.ActiveSheet.RowCount++;
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.MODE].Value = 'U';
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.SEQ].Value = out_list.GetInt("JGR_SEQ");
                    if (out_list.GetString("WORK_TIME").Length == 4)
                    {
                        spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_TIME].Value = out_list.GetString("WORK_TIME").Substring(0, 2) + ":" + out_list.GetString("WORK_TIME").Substring(2, 2);
                    }
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.JGR_PROC].Value = out_list.GetString("JGR_PROC");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.JGR_PROC_NAME].Value = out_list.GetString("JGR_PROC_NAME");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_LINE].Value = out_list.GetString("LINE_ID");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.TABBER].Value = out_list.GetString("RES_ID");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.JIG_NO].Value = out_list.GetString("JIG_NO");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.WRKR_NAME].Value = out_list.GetString("WRKR_NAME");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.DEPT_NO].Value = out_list.GetString("DEPT_CD");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.DEPT_NAME].Value = out_list.GetString("DEPT_NAME");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.REASON_CD].Value = out_list.GetString("JGR_RSN");
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.REASON].Value = this.getJigRepairReasonName(out_list.GetString("JGR_RSN"));
                    spdJigRepair.ActiveSheet.Cells[i, (int)DATA_LIST.REMARK].Value = out_list.GetString("JGR_REMARKS"); 

                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdateData(TRSNode out_node)
        {
            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode list_item;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'U';

                for (int row = 0; row < spdJigRepair.ActiveSheet.RowCount; row++)
                {
                    if (spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE_STATE].Value == null || 
                        spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE_STATE].Value.ToString().Equals("*") == false)
                    {
                        continue;
                    }
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.ProcStep = (char)spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE].Value;
                    list_item.AddString("FACTORY", MPGV.gsFactory); 
                    list_item.AddString("WORK_DATE", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_DATE].Value);
                    list_item.AddInt("JGR_SEQ", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.SEQ].Value);
                    list_item.AddString("JGR_PROC", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JGR_PROC].Value);
                    list_item.AddString("LINE_ID", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value);
                    list_item.AddString("RES_ID", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.TABBER].Value);
                    list_item.AddString("WORK_TIME", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value.ToString().Replace(":",""));
                    list_item.AddString("JIG_NO", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JIG_NO].Value);
                    list_item.AddString("WRKR_NAME", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WRKR_NAME].Value);
                    list_item.AddString("DEPT_CD", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.DEPT_NO].Value);
                    list_item.AddString("JGR_RSN", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REASON_CD].Value);
                    list_item.AddString("JGR_REMARKS", spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REMARK].Value);
                }

                if (MPCF.CallService("CRAS", "CRAS_Update_Tabber_Jig_Repair", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(out_node.Msg);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private String getLineLocation(String strLine)
        {
            int inx;
            TRSNode out_list;

            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                if (MPCF.CallService("CWIP", "CWIP_View_Line_List", in_node, ref out_node) == false)
                {
                    return "";
                }
                for (inx = 0; inx < out_node.GetList(0).Count; inx++)
                {
                    out_list = out_node.GetList(0)[inx];
                    if (out_list.GetString("KEY_1").Equals(strLine) )
                        return out_list.GetString("DATA_7");
                }

                return "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return "";
            }
        }

        private bool updateGrid(int row, char status)
        {
            try
            {
                DateTime dtpFromDateTimeOut = new DateTime();

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                         spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_DATE].Value = dtpFromDateTimeOut.ToString("yyyyMMdd");
                    }
                }
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.DEPT_NO].Value = cdvDepartment.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.DEPT_NAME].Value = cdvDepartment.Description;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WRKR_NAME].Value = txtName.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.TABBER].Value = cdvTabber.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value = soiHour.Text + ":" + soiMin.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value = cdvLineID.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REMARK].Value = txtRemarks.Text;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REASON_CD].Value = getJigRepairStatus(true);
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REASON].Value = getJigRepairStatus(false);
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JGR_PROC].Value = cboJigRepairProcess.Value;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JGR_PROC_NAME].Value = cboJigRepairProcess.Text;

                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE].Value = status;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE_STATE].Value = "*";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool updateView(int row, bool isCellClicked)
        {
            try
            {
                if (isCellClicked == true)
                {
                    txtJigNo.Enabled = false;
                    soiGridClicked.Text = "1";
                }
                else
                {
                    txtJigNo.Enabled = true;
                    soiGridClicked.Text = "";
                }
                txtJigNo.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JIG_NO].Value.ToString();
                cdvDepartment.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.DEPT_NO].Value.ToString();
                cdvDepartment.Description = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.DEPT_NAME].Value.ToString();
                txtName.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WRKR_NAME].Value.ToString();
                cdvTabber.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.TABBER].Value.ToString();
                if (spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value != null && 
                    spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value.ToString().Length > 4)
                {
                    soiHour.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value.ToString().Substring(0, 2);
                    soiMin.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_TIME].Value.ToString().Substring(3, 2);
                }
                cdvLineID.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value.ToString();

                txtRemarks.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REMARK].Value.ToString();
                setJigRepairStatus(spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.REASON_CD].Value.ToString());
                //cboJigRepairProcess.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JGR_PROC].Value;
                if (spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.SEQ].Value != null)
                {
                    txtSEQ.Text = spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.SEQ].Value.ToString();
                }
                //spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE].Value = status;
                //spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.MODE_STATE].Value = "*";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        #endregion Function

        #region Event Handler

        private void frmCWIPTabberJigRepair_Load(object sender, EventArgs e)
        {
            initialize();

            // Init
            dtpDate.Value = DateTime.Today;

            chk_auto_validation = "";
            chk_auto = "";
            chk_common_line = "";


            MPCF.ConvertCaption(this);

            getJigRepairProcess();
            getJigRepairReasonList();

            MPCF.ClearList(spdJigRepair);
        }

        private void getJigRepairReasonList()
        {

            TRSNode out_list;

            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode out_node = new TRSNode("DATA_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@JIG_REPAIR_REASON"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }
                m_strJigRepairReason = new string[out_node.GetList(0).Count,2];
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    this.m_strJigRepairReason[i,0] = out_list.GetString("KEY_1");
                    this.m_strJigRepairReason[i,1] = out_list.GetString("DATA_1");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }             
        }


        private void initialize() 
        {
 
        }

        private void frmCUSDATA_LIST_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

         
        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = "C:\\";

                //pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                //pop.FilterIndex = 1;

                //if (pop.ShowDialog() == DialogResult.OK)
                //{
                //    spdFqcLog.Sheets[0].Protect = false;
                //    spdFqcLog.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                //    spdFqcLog.Sheets[0].Protect = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void set_view()
        {
            txt_clear();
        
            btnADD.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void set_update()
        {
            btnADD.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true ;
        }

        private void set_create()
        {
            txt_clear();

            btnADD.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
         

        private void txt_clear()
        {
            txtJigNo.Enabled = true;
            txtSEQ.Text = "";
            txtJigNo.Text = "";
            dtpDate.Value = dtpDate.Value;
            cdvTabber.Text = "";
            soiHour.SelectedIndex = 0;
            soiMin.SelectedIndex = 0;
            cdvLineID.Text = "";

            txtRemarks.Text = "";            

            chkPinSpring.Checked = false;
            chkPad.Checked = false;
            chkFrame.Checked = false;
            chkDefect.Checked = false;
            chkOther.Checked = false;

            soiGridClicked.Text = "";
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();
            set_create();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                if (ViewJigRepairList() == false)
                {
                    return;
                }
                set_view();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(451), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                spdJigRepair.ActiveSheet.Cells[spdJigRepair.ActiveSheet.ActiveRow.Index, (int)DATA_LIST.MODE].Value = 'D';
                spdJigRepair.ActiveSheet.Cells[spdJigRepair.ActiveSheet.ActiveRow.Index, (int)DATA_LIST.MODE_STATE].Value = '*';
                spdJigRepair.ActiveSheet.RemoveRows(spdJigRepair.ActiveSheet.ActiveRow.Index, 1);
                txtJigNo.Text = "";

                txt_clear();
                set_create();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        } 
                     
 
        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("APPEND") == false)
                {
                    return;
                }

                int row = spdJigRepair.ActiveSheet.RowCount++;
                spdJigRepair.ActiveSheet.Cells[row, (int)DATA_LIST.JIG_NO].Value = txtJigNo.Text;
                string time = DateTime.Now.ToString("HH:mm");
                
                if ( time.Length == 5 ) {
                    soiHour.Text = time.Substring(0, 2);
                    soiMin.Text = time.Substring(3, 2);
                }

                if (updateGrid(row, MPGC.MP_STEP_CREATE) == false)
                {
                    MPCF.ShowMessage("An error has occurred during data update.", MSG_LEVEL.ERROR, false);
                    return;
                }
                //txt_clear();
                txtJigNo.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.Model.CellRange[] selections;

                selections = spdJigRepair.ActiveSheet.GetSelections();

                foreach (var range in selections)
                {
                    char status = spdJigRepair.ActiveSheet.Cells[range.Row, (int)DATA_LIST.SEQ].Value == null ? MPGC.MP_STEP_CREATE : MPGC.MP_STEP_UPDATE;                    
                    if (updateGrid(range.Row, status) == false)
                    {
                        MPCF.ShowMessage("An error has occurred during data update.", MSG_LEVEL.ERROR, false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
             
            // Refresh
            btnView.PerformClick(); 

        }

        private void enableTransaction(bool bEnable)
        {
            btnADD.Enabled = bEnable;
            btnDelete.Enabled = bEnable;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) )
            {
                txt_clear();

                if (validateData() == false)
                {
                    MPCF.ShowMessage("Only digits and '.' are allowed in the barcode serial number.", MSG_LEVEL.ERROR, false);
                    return;
                }

                return;
            }

            //숫자와 백스페이스만 입력
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            
            mbKeyPressed = true;
        }
        private void txtOperator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                // Refresh
                btnView.PerformClick();
            }
        } 

        private bool validateData()
        { 

            return true;
        }

        private void getJigRepairProcess()
        {
            TRSNode out_list;

            try
            {
                TRSNode in_node = new TRSNode("DATA_IN");
                TRSNode out_node = new TRSNode("DATA_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@JIG_REPAIR_PROCESS"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return ;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    cboJigRepairProcess.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }




        private void cdvDepartment_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEPARTMENT));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvDepartment.Text = cdvDepartment.Show(cdvDepartment, "Department", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void cdvTabber_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'F';
                in_node.AddString("TABLE_NAME", "@E10_EQP");
                in_node.AddString("KEY_1", "TABBER");
                in_node.AddString("KEY_2", this.getLineLocation(cdvLineID.Text));
                in_node.AddString("KEY_3", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Line ID", "Tabber EQ ID" };
                string[] display = new string[] { "KEY_3", "KEY_4" };
                cdvTabber.Text = cdvTabber.Show(cdvTabber, "Tabber EQ", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_4");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode out_node = new TRSNode("DATA_OUT");

                if (UpdateData(out_node))
                {
                    // Refresh
                    btnClear.PerformClick();

                    cdvDepartment.Text = "";
                    cdvDepartment.Description = "";
                    txtName.Text = "";
                    cboJigRepairProcess.Text = "";
                    MPCF.ClearList(spdJigRepair);

                    MPCF.ShowSuccessMessage(out_node, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdJigRepair_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            txt_clear();
            updateView(e.Row, true);
            set_update();
        }

        private void cboJigRepairProcess_SelectionChanged(object sender, EventArgs e)
        {
            if (cboJigRepairProcess.Value == null)
            {
                return;
            }

            if (cboJigRepairProcess.Value.Equals("JRP001"))
            {
                cdvLineID.Enabled = true;
                cdvTabber.Enabled = true;

                chkDefect.Enabled = true;
                chkFrame.Enabled = true;
                chkOther.Enabled = true;
                chkPinSpring.Enabled = true;
                chkPad.Enabled = true;
                txtRemarks.Enabled = true;
            }
            else if (cboJigRepairProcess.Value.Equals("JRP002"))
            {
                cdvLineID.Text = "";
                cdvLineID.Enabled = false;
                cdvTabber.Text = "";
                cdvTabber.Enabled = false;

                chkDefect.Enabled = true;
                chkFrame.Enabled = true;
                chkOther.Enabled = true;
                chkPinSpring.Enabled = true;
                chkPad.Enabled = true;

                txtRemarks.Enabled = true;
            }
            else if (cboJigRepairProcess.Value.Equals("JRP003"))
            {
                cdvLineID.Enabled = true;
                cdvTabber.Enabled = true;

                chkDefect.Checked = false;
                chkDefect.Enabled = false;

                chkFrame.Checked = false;
                chkFrame.Enabled = false;

                chkOther.Checked = false;
                chkOther.Enabled = false;

                chkPinSpring.Checked = false;
                chkPinSpring.Enabled = false;

                chkPad.Checked = false;
                chkPad.Enabled = false;

                txtRemarks.Enabled = false;
                txtRemarks.Text = "";
            }
        } 


        private void txtJigNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //txt_clear();

                if (validateData() == false)
                {
                    MPCF.ShowMessage("The jig number is limited to 5 characters.", MSG_LEVEL.ERROR, false);
                    return;
                }

                dtpDate.Value = DateTime.Today;

                //when barcode scan
                if (chkScanner.Checked)
                {
                    if (btnADD.Enabled == false)
                    {
                        this.CheckCondition("APPEND");
                    }
                    btnADD.PerformClick();
                }
                return;
            }

            //숫자와 백스페이스만 입력
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }

            mbKeyPressed = true;
        }

        private void txtJigNo_ValueChanged(object sender, EventArgs e)
        {

        }
        private void txtJigNo_TextChanged(object sender, EventArgs e)
        {
            if ((txtJigNo.Text.EndsWith("\r") || txtJigNo.Text.EndsWith("\n")) &&
                txtSEQ.Text.Trim().Length == 0 && soiGridClicked.Text.Length == 0)
            {
                //txt_clear();

                if (validateData() == false)
                {
                    MPCF.ShowMessage("The jig number is limited to 5 characters.", MSG_LEVEL.ERROR, false);
                    return;
                }
                
                dtpDate.Value = DateTime.Today;

                //when barcode scan
                if (chkScanner.Checked)
                {
                    if (btnADD.Enabled == false)
                    {
                        this.CheckCondition("APPEND");
                    }
                    btnADD.PerformClick();
                }
            }
        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        #endregion 





         


    }
}
