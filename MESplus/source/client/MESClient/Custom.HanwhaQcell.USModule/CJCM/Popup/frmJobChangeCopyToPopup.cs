//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmJobChangeCopyToPopup.cs
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
    public partial class frmJobChangeCopyToPopup : BaseForm04
    {
        public frmJobChangeCopyToPopup()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(600, 280);
            btnClose.Location = new Point(484, 7);
        }


        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string m_ord_id;
        private string m_to_ord_id;
        private string m_line_code;
        private string m_line_desc;
        private string m_mat_id;
        private string m_mat_desc;
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

        public string TO_ORDER_ID
        {
            get
            {
                if (m_to_ord_id == null)
                {
                    m_to_ord_id = "";
                }
                return m_to_ord_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_to_ord_id = "";
                }
                m_to_ord_id = value;
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

        public string LINE_DESC
        {
            get
            {
                if (m_line_desc == null)
                {
                    m_line_desc = "";
                }
                return m_line_desc;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_line_desc = "";
                }
                m_line_desc = value;
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
            return this.txtToWorkOrder;
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
        // CJCMCopyJobChangeMaster()
        //       - Copy Job_Change_Master
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CJCMCopyJobChangeMaster()
        {
            TRSNode in_node = new TRSNode("CJCM_COPY_JOB_CHANGE_MASTER_IN");
            TRSNode out_node = new TRSNode("CJCM_COPY_JOB_CHANGE_MASTER_OUT");

            try
            {

                if (MPCF.CheckValue(txtFromWorkOrder, 1) == false)
                {
                    return false;
                }

                if (MPCF.CheckValue(txtToWorkOrder, 1) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtToOrderSeq, 1) == false)
                {
                    return false;
                }

                if (MPCF.CheckValue(cdvToLine, 1) == false)
                {
                    return false;
                }

                //if (MPCF.Trim(txtToWorkOrder.Text) == MPCF.Trim(txtFromWorkOrder.Text))
                //{
                //    MPCF.ShowMsgBox("The same value as the copy target order has been entered.");
                //    return false;
                //}

                TO_ORDER_ID = MPCF.Trim(txtFromWorkOrder.Text) + MPCF.Trim(txtToOrderSeq.Text);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE; // 'I'

                in_node.AddString("ORDER_ID", MPCF.Trim(txtFromWorkOrder.Text));
                in_node.AddString("TO_ORDER_ID", TO_ORDER_ID );
                in_node.AddString("LINE_ID", MPCF.Trim(cdvToLine.Text));

                if (MPCR.CallService("CJCM", "CJCM_Copy_Job_Change_Master", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmJobChangeCopyToPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);

                txtFromWorkOrder.Text = ORDER_ID;
                txtToWorkOrder.Text = ORDER_ID;

                txtFromMatID.Text = MAT_ID;
                txtFromMatDesc.Text = MAT_DESC;
                txtFromStartDate.Text = START_DATE;
                cdvFromLine.Text = LINE_CODE;
                cdvFromLine.DescText = LINE_DESC;

                // TODO
                b_load_flag = true;
            }
        }

        private void cdvToLine_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvToLine.Init();
                MPCF.InitListView(cdvToLine.GetListView);
                cdvToLine.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvToLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvToLine.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvToLine.GetListView, '1', HQGC.GCM_LINE_CODE) == true)
                {
                    cdvToLine.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (CJCMCopyJobChangeMaster() == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
