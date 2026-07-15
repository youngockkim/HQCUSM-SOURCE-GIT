using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button

    public partial class frmCWIPCellScrapManagementLb_Tb_v1 : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bEdited = false;
        private bool bIsShown = false;

        FarPoint.Win.Spread.CellType.ComboBoxCellType m_cmbLossCause;
        TRSNode m_outNodeLossCause;

        public enum TABBER_STATUS
        {
            NO,
            EQ,
            LEFT,
            RIGHT
        }

        public enum TABBER_LIST
        {
            RES_DESC,
            OPER_SUB_NAME,
            WORK_DATE,
            FACTORY,
            LINE_ID,
            RES_ID,
            OPER_ID,
            OPER_SUB_ID,
            WORK_SHIFT,
            OPERATOR_ID,
            LOSS_QTY,
            LOSS_CAUSE,
            LOSS_COMMENT,
            LOSS_LB,
            LOSS_LB_CHECK,
            BOX_USE,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        public enum COLUMN_LIST
        {
            RES_DESC,
            OPER_SUB_NAME,
            RES_ID,
            OPER_ID,
            OPER_SUB_ID,
            BOX_USE,
            LOSS_QTY,
            LOSS_CAUSE,
            LOSS_COMMENT
        }

        #endregion

        #region [Constant Definition]

        int LB_DESIRED_DECIMAL_POINT = 2;
        int DEFAULT_ROW_HEIGHT = 35;
        double DEFAULT_LB_WEIGHT_WITH_BOX_USE = 1.85;
        string MSG_SCRAP_LBS_INPUT_BIGGER_THAN_VALUE = "Please enter Scrap Lbs bigger than 1.85.";

        #endregion

        #region Constructor

        public frmCWIPCellScrapManagementLb_Tb_v1()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            getLineLocationList();

            SetQuadrantData();

            SetLossCause();

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            spdList._UseAutoHeight = false;
        }

        private void SetQuadrantData()
        {
            //get date
            Dtpscrapdt.Value = DateTime.Today;
            //GET LINE 
            TRSNode in_node = new TRSNode("GCM_DATA_QUADRANT_IN");
            TRSNode out_node = new TRSNode("GCM_DATA_QUADRANT_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '5';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.TABBER_GROUP_QUAD));
            int i;
            if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    cboQuadrant.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                }
            }
        }

        private void SetLossCause()
        {
            this.m_cmbLossCause = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

            //get date
            Dtpscrapdt.Value = DateTime.Today;
            //GET LINE 
            TRSNode in_node = new TRSNode("GCM_DATA_QUADRANT_IN");
            if (m_outNodeLossCause != null)
                m_outNodeLossCause = null;

            m_outNodeLossCause = new TRSNode("GCM_LOSS_CAUSE");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            int i;
            in_node.ProcStep = '5';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.TABBER_ROOT_CAUSE));
            List<string> listData = new List<string>();
            List<string> listCode = new List<string>();

            if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref m_outNodeLossCause) == true)
            {
                for (i = 0; i < m_outNodeLossCause.GetList(0).Count; i++)
                {
                    out_list = m_outNodeLossCause.GetList(0)[i];

                    listData.Add(out_list.GetString("DATA_1"));
                    listCode.Add(out_list.GetString("KEY_1"));
                }
                m_cmbLossCause.Items = listData.ToArray();
                m_cmbLossCause.ItemData = listCode.ToArray();
                if (m_cmbLossCause.ListControl != null)
                {
                    //m_cmbLossCause.ListControl.BackColor = Color.Red;
                }
            }

        }

        private string FindColumnCode(string value)
        {
            for (int inx = 0; inx <= m_cmbLossCause.Items.Length - 1; inx++)
            {
                if (m_cmbLossCause.Items[inx].Equals(value))
                    return m_cmbLossCause.ItemData[inx];
            }

            return "";
        }

        private string FindColumnValue(string code)
        {
            for (int inx = 0; inx <= m_cmbLossCause.ItemData.Length - 1; inx++)
            {
                if (m_cmbLossCause.ItemData[inx].Equals(code))
                    return m_cmbLossCause.Items[inx];
            }

            return "";
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        //LINE CHANGE EVENT
        //btnProcess_Click();

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdList);
                if (ViewTabberStatusList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        /// 


        private bool sumit_view()
        {
            if (Dtpscrapdt.Value != "" && cboLineId.Value != "" && cboShift.Text != "" && cdvOperator.Text != "")
            {
                ViewTabberStatusList();
            }

            return true;
        }

        private bool cleardata()
        {

            spdList.ActiveSheet.Rows.Clear();


            return true;
        }

        private bool ViewTabberStatusList()
        {
            try
            {
                DateTime dtpFromDateTimeOut = new DateTime();

                if (cboShift.Text == "")
                {
                    MPCF.ShowMsgBox("Please Seleted Work Shift");
                    cboShift.Focus();
                    return false;
                }

                if (cboLineId.Text == "")
                {
                    MPCF.ShowMsgBox("Please Seleted Lince Code");
                    cboLineId.Focus();
                    return false;
                }

                if (this.cboQuadrant.Text == "")
                {
                    MPCF.ShowMsgBox("Please Selet Quadrant");
                    cdvOperator.Focus();
                    return false;
                }

                if (cdvOperator.Text == "")
                {
                    MPCF.ShowMsgBox("Please Selet Operator");
                    cdvOperator.Focus();
                    return false;
                }

                cleardata();

                TRSNode in_node = new TRSNode("VIEW_SCRAP_LIST_IN");
                TRSNode out_node_mst = new TRSNode("VIEW_SCRAP_MST_LIST_OUT");
                TRSNode out_node = new TRSNode("VIEW_SCRAP_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", cboLineId.Value);
                if (Dtpscrapdt.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(Dtpscrapdt.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("OPER_ID", MPCF.Trim(cboQuadrant.Value));
                in_node.AddString("OPERATOR_ID", MPCF.Trim(cdvOperator.Code));

                if (MPCF.CallService("CWIP", "CWIP_View_Scraplb_Tb_Mst_List", in_node, ref out_node_mst) == false)
                {
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_View_ScrapLb_Tb_List", in_node, ref out_node) == false)
                {
                    return false;
                }


                int knx = 0;
                int oldOperIdIdx = 0;
                int mst_max_count = out_node_mst.GetList(0).Count;
                TRSNode out_mst_list;
                string oldOperId = "";
                for (int jnx = 0; jnx < mst_max_count; jnx++)
                {
                    out_mst_list = out_node_mst.GetList(0)[jnx];
                    spdList.ActiveSheet.AddRows(jnx, 1);
                    char[] chars = { '-' };

                    string oper_id = out_mst_list.GetString("RES_DESC");
                    string newOperId = "";
                    int pos = oper_id.IndexOfAny(chars);
                    if (pos > 0)
                    {
                        newOperId = oper_id.Substring(pos + 1).Trim();
                    }

                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.RES_DESC].Value = newOperId;
                    if (oldOperId.CompareTo(newOperId) != 0)
                    {
                        if (jnx != 0 )
                        {
                            spdList.ActiveSheet.AddSpanCell(oldOperIdIdx, (int)COLUMN_LIST.RES_DESC, jnx - oldOperIdIdx, 1);
                            knx++;
                        }
                        oldOperId = newOperId;
                        oldOperIdIdx = jnx;
                    }
                    else
                    {
                        if ( jnx == mst_max_count -1 )
                        {
                            spdList.ActiveSheet.AddSpanCell(oldOperIdIdx, (int)COLUMN_LIST.RES_DESC, jnx - oldOperIdIdx +1, 1);
                        }
                    }

                    if (knx % 2 == 0)
                    {
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.RES_DESC].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_SUB_NAME].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.RES_ID].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_ID].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_SUB_ID].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_COMMENT].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.BOX_USE].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_QTY].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));

                    }

                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_SUB_NAME].Value = out_mst_list.GetString("OPER_SUB_NAME");
                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.RES_ID].Value = out_mst_list.GetString("RES_ID");
                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_ID].Value = out_mst_list.GetString("OPER_ID");
                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.OPER_SUB_ID].Value = out_mst_list.GetString("OPER_SUB_ID");
                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].Value = " ";
                    spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_COMMENT].Value = " ";

                    if (out_mst_list.GetString("OPER_SUB_NAME").ToUpper().CompareTo("LAYUP") == 0)
                    {
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].CellType = this.m_cmbLossCause;
                    }
                    else
                    {
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].CellType = new FarPoint.Win.Spread.CellType.EmptyCellType();
                        spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))), ((int)(((byte)(80)))));
                    }
                    spdList.ActiveSheet.Rows[jnx].Height = DEFAULT_ROW_HEIGHT;

                    int max_count = out_node.GetList(0).Count;
                    string res_id = string.Empty;
                    TRSNode out_list;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        try
                        {
                            out_list = out_node.GetList(0)[i];

                            if (out_list.GetString("FACTORY").Equals(out_mst_list.GetString("FACTORY")) == false ||
                                 out_list.GetString("LINE_ID").Equals(out_mst_list.GetString("LINE_ID")) == false ||
                                 out_list.GetString("OPER_ID").Equals(out_mst_list.GetString("OPER_ID")) == false ||
                                 out_list.GetString("RES_ID").Equals(out_mst_list.GetString("RES_ID")) == false ||
                                 out_list.GetString("OPER_SUB_ID").Equals(out_mst_list.GetString("OPER_SUB_ID")) == false
                               )
                            {
                                continue;
                            }
                            spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.BOX_USE].Value = out_list.GetString("BOX_USE");
                            if (out_list.GetDouble("LOSS_QTY") >= 0)
                            {
                                spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_QTY].Value = out_list.GetDouble("LOSS_QTY");
                            }
                            spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_CAUSE].Value = this.FindColumnValue(out_list.GetString("LOSS_CAUSE"));
                            spdList.ActiveSheet.Cells[jnx, (int)COLUMN_LIST.LOSS_COMMENT].Value = out_list.GetString("LOSS_COMMENT");

                        }
                        catch (System.Exception ex)
                        {
                            MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                            return false;
                        }
                    }
                }

                MPCF.ShowSuccessMessage(out_node, false);


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }


            bEdited = false;
        }

        private bool getLineLocationList()
        {

            //get date
            Dtpscrapdt.Value = DateTime.Today;
            //GET LINE 
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", "E1");//Eagle2 - 2023/08/28 이글1만 나오도록 수정

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                int i;
                if (MPCF.CallService("CWIP", "CWIP_View_Line_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboLineId.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool getShiftList()
        {
            try
            {
                cboShift.Items.Clear();
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (Dtpscrapdt.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(Dtpscrapdt.Value)).ToString("yyyyMMdd"));
                }

                int i;
                if (MPCF.CallService("CBAS", "CBAS_View_Shift_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboShift.Items.Add(out_list.GetString("shift"), out_list.GetString("SHIFT"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        //UPDATE
        private bool Update_Tabber_Status_List(char act_type)
        {

            DateTime dtpFromDateTimeOut = new DateTime();

            if (cboShift.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Work Shift");
                cboShift.Focus();
                return false;
            }

            if (cboLineId.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Lince Code");
                cboLineId.Focus();
                return false;
            }
            if (this.cboQuadrant.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Quadrant Code");
                cdvOperator.Focus();
                return false;
            }

            if (cdvOperator.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Operator");
                cdvOperator.Focus();
                return false;
            }

            if (this.cboShift.Text == "")
            {
                MPCF.ShowMsgBox("Please Seleted Work Shift");
                cdvOperator.Focus();
                return false;
            }

            if (!validateRules())
                return false;


            string check_update;

            TRSNode in_node = new TRSNode("UPDATE_SCRAP_IN");
            TRSNode out_node = new TRSNode("UPDATE_SCRAP_OUT");
            TRSNode work_list = null;

            check_update = "";
            try
            {
                DateTime dtpScrapDateTimeOut = new DateTime();
                bool bTrySuccess = DateTime.TryParse(Dtpscrapdt.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = act_type;
                in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                in_node.AddString("LINE_ID", MPCF.Trim(cboLineId.Value));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("OPERATOR_ID", cdvOperator.Code);


                for (int i = 0; i < spdList.ActiveSheet.RowCount; i++)
                {
                    string resId = String.Empty;
                    string lossCause = MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.LOSS_CAUSE].Value);

                    check_update = "X";

                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("RES_ID", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.RES_ID].Value));
                    work_list.AddString("OPER_ID", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.OPER_ID].Value));
                    work_list.AddString("OPER_SUB_ID", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.OPER_SUB_ID].Value));
                    work_list.AddString("BOX_USE", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.BOX_USE].Value));
                    if (MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.LOSS_QTY].Value).Length <= 0)
                    {
                        work_list.AddDouble("LOSS_QTY", -1.0);
                    }
                    else
                    {
                        work_list.AddDouble("LOSS_QTY", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.LOSS_QTY].Value));
                    }
                    if (lossCause.Length > 0)
                    {
                        work_list.AddString("LOSS_CAUSE", FindColumnCode(lossCause));
                    }
                    work_list.AddString("LOSS_COMMENT", MPCF.Trim(spdList.ActiveSheet.Cells[i, (int)COLUMN_LIST.LOSS_COMMENT].Value));
                }

                if (check_update != "X")
                {
                    MPCF.ShowMsgBox("Please Enter LB");
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_Update_ScrapLb_List_Tb", in_node, ref out_node) == false)
                {
                    return false;
                }


                //btnSave.Enabled = true;
                MPCF.ShowSuccessMessage(out_node, false);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            bEdited = false;
        }

        private void clearSelectedRow(int row)
        {
            spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.BOX_USE].Value = "";
            spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value = "";
            spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_CAUSE].Value = " ";
            spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_COMMENT].Value = " ";
        }
        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Update_Tabber_Status_List('I') == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cboShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cboShift.Text = cboShift.Show(cboShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void cboLineId_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                //btnSave.Enabled = false;
                cdvOperator.Text = "";
                cdvOperator.Description = "";
                sumit_view();


                //btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void Dtpscrapdt_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();
                //btnSave.Enabled = false;
                cdvOperator.Text = "";
                cdvOperator.Description = "";
                sumit_view();

                getShiftList();

                //btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private void cboShift_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();

                //btnProcess.PerformClick();
                //btnSave.Enabled = false;
                cdvOperator.Text = "";
                cdvOperator.Description = "";
                sumit_view();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Update_Tabber_Status_List('U') == false)
            {
                return;
            }
            else
            {
                btnProcess.PerformClick();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Update_Tabber_Status_List('D') == false)
            {
                return;
            }
            else
            {
                btnProcess.PerformClick();
            }
        }


        //숫자여부/Null 값 여부 검증
        private bool validateNumbernDecimalPoint(string cellValue, int desiredDecimalPoint)
        {
            float result;

            if (cellValue.Trim().Length <= 0)
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);
                return true;
            }

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            if (float.TryParse(cellValue, style, CultureInfo.InvariantCulture, out result) == false)
            {
                MPCF.ShowMessage("Please write two decimal places only (0.00 lbs).", MSG_LEVEL.ERROR, false);
                return false;
            }

            int posPoint = cellValue.IndexOf(".");
            if (posPoint <= 0 || cellValue.Length - (posPoint + 1) != 2)
            {
                MPCF.ShowMessage("Please write two decimal places only (0.00 lbs).", MSG_LEVEL.ERROR, false);
                return false;
            }
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);
            return true;
        }

        private void cboQuadrant_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvOperator.Text = "";
                cdvOperator.Description = "";

                cleardata();

                //btnProcess.PerformClick();
                //btnSave.Enabled = false;
                sumit_view();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperator_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                cleardata();

                //btnProcess.PerformClick();
                //btnSave.Enabled = false;
                sumit_view();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperator_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.WORKER_SHIFT));
                in_node.AddString("KEY_2", this.cboShift.Text);

                string[] header = new string[] { "ID", "Name" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                this.cdvOperator.Text = cdvOperator.Show(cdvOperator, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        //2023.06.21
        //Box Usage = Yes인 경우, 계산 로직에서 1.85를 뺍니다.
        //Box Usage = No인 경우, 박스무게 상관 없음.
        //Scrab Lbs = 0인 경우, Box Usage 옵션에 관계없이 합계는 0이어야 합니다.
        private bool validateBoxUses(int row)
        {
            string boxUse = MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.BOX_USE].Value);
            string lossQty = MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value);
            if (boxUse.Length > 0)
            {
                if (lossQty.Trim().Length <= 0)
                {
                    MPCF.ShowMessage("Please, Enter Scrab Lbs.", MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            else
            {
                if (lossQty.Trim().Length > 0)
                {
                    MPCF.ShowMessage("Please, select the box usage.", MSG_LEVEL.ERROR, false);
                    return false;
                }
            }

            return true;
        }

        //2023.06.21
        //'NG Before' 값을 입력했다면 'NG After' 값을 입력해야 합니다.
        //'NG Before' 값은 'NG After' 값보다 크거나 같아야 합니다.
        private bool validateNGEvent(int row)
        {
            string operSubId = MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.OPER_SUB_ID].Value);
            string qty = MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value);

            if (operSubId == "10")
            {
                float fAfterQty = -1;
                float fBeforeQty = -1;

                if (qty.Length > 0)
                {
                    if (!float.TryParse(MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value), out fBeforeQty))
                    {
                        MPCF.ShowMessage("NGBefore data parser error occurred.", MSG_LEVEL.ERROR, false);
                        return false;
                    }
                    if (spdList.ActiveSheet.RowCount - 1 >= row + 1)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.OPER_SUB_ID].Value) == "20" &&
                           !float.TryParse(MPCF.Trim(spdList.ActiveSheet.Cells[row + 1, (int)COLUMN_LIST.LOSS_QTY].Value), out fAfterQty))
                        {
                            MPCF.ShowMessage("NGAfter data parser error occurred.", MSG_LEVEL.ERROR, false);
                            return false;
                        }


                        if (MPCF.Trim(spdList.ActiveSheet.Cells[row + 1, (int)COLUMN_LIST.LOSS_QTY].Value).Length <= 0)
                        {
                            MPCF.ShowMessage("If NG Before value was entered, NG After value must be entered.", MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        if (fBeforeQty < fAfterQty)
                        {
                            MPCF.ShowMessage("NG Before value must be greater or equal to NG After", MSG_LEVEL.ERROR, false);
                            return false;
                        }
                    }
                    else
                    {
                        MPCF.ShowMessage("NG After row must be exist.", MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }

            }
            if (operSubId == "20")
            {
                float fAfterQty = -1;
                float fBeforeQty = -1;

                if (qty.Length > 0)
                {
                    if (row - 1 >= 0)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[row - 1, (int)COLUMN_LIST.OPER_SUB_ID].Value) == "10" &&
                           !float.TryParse(MPCF.Trim(spdList.ActiveSheet.Cells[row - 1, (int)COLUMN_LIST.LOSS_QTY].Value), out fBeforeQty))
                        {
                            MPCF.ShowMessage("NGBefore data parser error occurred.", MSG_LEVEL.ERROR, false);
                            return false;
                        }
                    }
                    else
                    {
                        MPCF.ShowMessage("NG After row must be exist.", MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    if (MPCF.Trim(spdList.ActiveSheet.Cells[row - 1, (int)COLUMN_LIST.LOSS_QTY].Value).Length <= 0)
                    {
                        MPCF.ShowMessage("There is no NG Before value.", MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    if (!float.TryParse(MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value), out fAfterQty))
                    {
                        MPCF.ShowMessage("NGAfter data parser error occurred.", MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    if (fBeforeQty < fAfterQty)
                    {
                        MPCF.ShowMessage("NG Before value must be greater or equal to NG After", MSG_LEVEL.ERROR, false);
                        return false;
                    }

                }
            }

            return true;
        }

        //2023.06.21
        //'Layup'에 Scrab Lb가 입력된 경우 Root Cause를 선택해야 합니다.
        //'Others'에 Scrab Lb가 입력된 경우 코멘트를 입력해야 합니다.
        //RT-09(Special Event)를 선택하면 코멘트를 입력해야 합니다.
        private bool validateRootcauses(int row)
        {
            if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.OPER_SUB_ID].Value) == "30")
            {
                if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value).Length > 0 &&
                    MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_CAUSE].Text).Length <= 0)
                {
                    MPCF.ShowMessage("When Layup has Scrab Lb, Root Cause must be selected.", MSG_LEVEL.ERROR, false);
                    return false;
                }
                else
                {

                    if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_CAUSE].Value) == "RT09" &&
                        MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_COMMENT].Value).Length <= 0)
                    {
                        MPCF.ShowMessage("If RT-09 (Special Event) is selected, comment must be entered.", MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
            }

            return true;
        }

        //2023.06.21
        //Layup에 Scrab Lb가 입력된 경우 Root Cause를 선택해야 합니다.
        //Others에 Scrab Lb가 입력된 경우 코멘트를 입력해야 합니다.
        //RT-09(Special Event)를 선택하면 코멘트를 입력해야 합니다.
        private bool validateComments(int row)
        {
            if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.OPER_SUB_ID].Value) == "50")
            {
                if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_QTY].Value).Length > 0 &&
                    MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_COMMENT].Text).Length <= 0)
                {
                    MPCF.ShowMessage("When Others has Scrab Lb, comment must be entered.", MSG_LEVEL.ERROR, false);
                    return false;
                }
            }

            string specialEvent = FindColumnValue("RT09");
            string cause = spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_CAUSE].Value.ToString();
            if (cause.Length > 0 &&
                MPCF.Trim(cause).CompareTo(specialEvent) == 0 &&
                MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.LOSS_COMMENT].Value).Length <= 0)
            {
                MPCF.ShowMessage("If RT-09 (Special Event) is selected, comment must be entered.", MSG_LEVEL.ERROR, false);
                spdList.ActiveSheet.SetActiveCell(row, (int)COLUMN_LIST.LOSS_COMMENT);
                return false;
            }

            return true;
        }

        private bool validateBoxUsageWeight(int row, int col, bool isFocusEvent)
        {
            if (col == (int)COLUMN_LIST.LOSS_QTY)
            {
                double value = -1.0;
                if (MPCF.Trim(spdList.ActiveSheet.Cells[row, (int)COLUMN_LIST.BOX_USE].Value).Equals("Y") &&
                    double.TryParse(MPCF.Trim(spdList.ActiveSheet.Cells[row, col].Value).ToString(), out value))
                {
                    if (value < DEFAULT_LB_WEIGHT_WITH_BOX_USE)
                    {
                        if (isFocusEvent)
                        {
                            MPCF.ShowMsgBox(MSG_SCRAP_LBS_INPUT_BIGGER_THAN_VALUE, MessageBoxButtons.OK, MSG_LEVEL.NONE, "");
                        }
                        else
                        {
                            MPCF.ShowMessage(MSG_SCRAP_LBS_INPUT_BIGGER_THAN_VALUE, MSG_LEVEL.ERROR, false);
                        }
                        spdList.ActiveSheet.SetActiveCell(row, col);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool validateRules()
        {
            for (int inx = 0; inx < spdList.ActiveSheet.RowCount; inx++)
            {
                // box 사용여부 관련 
                if (!validateBoxUses(inx))
                    return false;

                // Box Flag가 Y인경우 Box무게보다 커야 함. 
                if (!validateBoxUsageWeight(inx, (int)COLUMN_LIST.LOSS_QTY, false))
                    return false;

                // Root cause관련
                if (!validateRootcauses(inx))
                    return false;

                // NGBefore, NGAfter 관련
                if (!validateNGEvent(inx))
                    return false;

                // NGBefore, NGAfter 관련
                if (!validateComments(inx))
                    return false;

            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmCWIPCellScrapManagementLb_Tb_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = "Are you sure you want to leave this page? Please make sure saving entered data prior to exiting the page.";
            if (bEdited)
            {
                if (sender == null)
                    return;

                if (MPCF.ShowMsgBox(msg, MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void spdList_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            bEdited = true;
        }

        private void spdList_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (validateBoxUsageWeight(e.Row, e.Column, true) == false)
            {
                e.Cancel = true;
                return;
            }
        }

        private void spdList_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (spdList.ActiveSheet.ActiveCell.Column.Index == (int)COLUMN_LIST.LOSS_QTY &&
                e.KeyChar == 13)
            {
                if (validateBoxUsageWeight(spdList.ActiveSheet.ActiveCell.Row.Index, spdList.ActiveSheet.ActiveCell.Column.Index, true))
                {
                    return;
                }
            }
        }

        private void spdList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.F8)
            {
                clearSelectedRow(spdList.ActiveSheet.ActiveRow.Index);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearSelectedRow(spdList.ActiveSheet.ActiveRow.Index);
        }
    }
}