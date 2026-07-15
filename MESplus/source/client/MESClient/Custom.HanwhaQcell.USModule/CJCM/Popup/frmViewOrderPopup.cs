//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmViewOrderPopup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewItem() : View item definition
//       - UpdateItem() : Create/Update/Delete item
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023/08/15 08:43:54 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmViewOrderPopup : BaseForm04
    {
        public frmViewOrderPopup()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum ORD_LIST : int
        {
            ORDER_ID = 0,
            MAT_ID,
            MAT_DESC,
            LINE_CODE,
            LINE_NAME,
            START_DATE,
            ORD_QTY,
            MGR_ID,
            MGR_NAME,
            DEPT,
            ALARM
        }

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string m_ord_id;
        private string m_line_code;
        private string m_mat_id;
        private string m_mat_desc;
        private string m_mgr_id;
        private string m_mgr_name;
        private string m_dept;
        private string m_alarm_code;
        private string s_start_date;


        public string ORDER_ID
        {
            get
            {
                if (m_ord_id == null)
                {
                    m_ord_id = "";
                }
                return m_ord_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_ord_id = "";
                }
                m_ord_id = value;
            }
        }

        public string LINE_CODE
        {
            get
            {
                if (m_line_code == null)
                {
                    m_line_code = "";
                }
                return m_line_code;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_line_code = "";
                }
                m_line_code = value;
            }
        }

        public string START_DATE
        {
            get
            {
                if (s_start_date == null)
                {
                    s_start_date = "";
                }
                return s_start_date;
            }
            set
            {
                if (value == null || value == "")
                {
                    s_start_date = "";
                }
                s_start_date = value;
            }
        }

        public string MAT_ID
        {
            get
            {
                if (m_mat_id == null)
                {
                    m_mat_id = "";
                }
                return m_mat_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_mat_id = "";
                }
                m_mat_id = value;
            }
        }

        public string MAT_DESC
        {
            get
            {
                if (m_mat_desc == null)
                {
                    m_mat_desc = "";
                }
                return m_mat_desc;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_mat_desc = "";
                }
                m_mat_desc = value;
            }
        }

        public string MANAGER_ID
        {
            get
            {
                if (m_mgr_id == null)
                {
                    m_mgr_id = "";
                }
                return m_mgr_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_mgr_id = "";
                }
                m_mgr_id = value;
            }
        }

        public string MANAGER_NAME
        {
            get
            {
                if (m_mgr_name == null)
                {
                    m_mgr_name = "";
                }
                return m_mgr_name;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_mgr_name = "";
                }
                m_mgr_name = value;
            }
        }

        public string DEPT
        {
            get
            {
                if (m_dept == null)
                {
                    m_dept = "";
                }
                return m_dept;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_dept = "";
                }
                m_dept = value;
            }
        }

        public string ALARM_CODE
        {
            get
            {
                if (m_alarm_code == null)
                {
                    m_alarm_code = "";
                }
                return m_alarm_code;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_alarm_code = "";
                }
                m_alarm_code = value;
            }
        }
        #endregion

        #region " Function Definition "

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.txtOrderID;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ("1", "2")
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    // TODO
                }
                else if (c_case == '2')
                {
                    // TODO
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        //
        // ORDViewOrderList()
        //       - Views the order information list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ORDViewOrderList()
        {
            TRSNode in_node = new TRSNode("ORD_VIEW_ORDER_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(pnlMain);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FROM_DATE", dtpOrderDateFrom.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpOrderDateTo.Value.ToString("yyyyMMdd"));
                in_node.AddString("ORDER_ID", MPCF.Trim(txtOrderID.Text));
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLine.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));

                do
                {
                    TRSNode out_node = new TRSNode("ORD_VIEW_ORDER_LIST_OUT");

                    if (MPCR.CallService("CJCM", "CJCM_View_Order_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                    //in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));
                } while (in_node.GetString("NEXT_ORDER_ID") != "");


                FarPoint.Win.Spread.SheetView with_1 = spdOrderList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> ord_list = out_node.GetList("ORDER_LIST");
                    foreach (TRSNode node in ord_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.ORDER_ID), node.GetString("ORDER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MAT_ID), node.GetString("MAT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MAT_DESC), node.GetString("MAT_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.LINE_CODE), node.GetString("LINE_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.LINE_NAME), node.GetString("LINE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.START_DATE), MPCF.MakeDateFormat(node.GetString("START_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.ORD_QTY), node.GetDouble("PROD_QTY"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MGR_ID), node.GetString("MANAGER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MGR_NAME), node.GetString("MANAGER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.DEPT), node.GetString("DEPT_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.ALARM), node.GetString("ALARM_CODE"));
                        i++;                   
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

        #endregion

        private void frmViewOrderPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);

                spdOrderList.ActiveSheet.RowCount = 0;

                dtpOrderDateFrom.Value = DateTime.Now.AddDays(-10);
                dtpOrderDateTo.Value = DateTime.Now.AddMonths(1);

                txtOrderID.Text = ORDER_ID;

                // TODO
                b_load_flag = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ORDViewOrderList();
        }

        private void cdvLine_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Init();
                MPCF.InitListView(cdvLine.GetListView);
                cdvLine.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvLine.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvLine.GetListView, '1', HQGC.GCM_LINE_CODE) == true)
                {
                    cdvLine.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdOrderList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ORDER_ID = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.ORDER_ID)).ToString();
            MAT_ID = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.MAT_ID)).ToString();
            MAT_DESC = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.MAT_DESC)).ToString();
            MANAGER_ID = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.MGR_ID)).ToString();
            MANAGER_NAME = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.MGR_NAME)).ToString();
            DEPT = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.DEPT)).ToString();
            ALARM_CODE = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.ALARM)).ToString();
            LINE_CODE = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.LINE_CODE)).ToString();
            START_DATE = spdOrderList.ActiveSheet.GetValue(e.Row, MPCF.ToInt(ORD_LIST.START_DATE)).ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }



    }
}
