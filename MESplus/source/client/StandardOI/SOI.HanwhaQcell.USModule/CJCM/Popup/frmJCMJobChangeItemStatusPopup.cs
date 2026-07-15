using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmJCMJobChangeItemStatusPopup : frmPopupBase
    {
        #region Property

        private bool _result;
        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        #region Constructor

        public frmJCMJobChangeItemStatusPopup(string sOrderID, string sItemCode)
        {
            InitializeComponent();
            _result = false;
            m_order_id = sOrderID;
            m_item_code = sItemCode;
        }

        #endregion


        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private string m_order_id = string.Empty;
        private string m_item_code = string.Empty;
       
        #endregion


        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJCMJobChangeItemStatusPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            if (ViewJobChangeItem(m_order_id, m_item_code) == false)
            {
                Close();
            }

            // 활성화
            this.Activate();
        }
        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            if (_result == true)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else             
                this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (TranJobChangeItem('S') == true)
                {
                    if (chkSaveClose.Checked == true)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        ViewJobChangeItem(txtOrderID.Text, txtItemCode.Text);
                        _result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TranJobChangeItem('E') == true)
                {
                    if (chkSaveClose.Checked == true)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        ViewJobChangeItem(txtOrderID.Text, txtItemCode.Text);
                        _result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TranJobChangeItem('B') == true)
                {
                    if (chkSaveClose.Checked == true)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        ViewJobChangeItem(txtOrderID.Text, txtItemCode.Text);
                        _result = true;
                    }
                }                    
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        #endregion


        #region Functions

        private bool CheckCondition(char c_ActionFlag)
        {
            if (MPCF.CheckValue(txtOrderID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(txtItemCode, 1) == false)
            {
                return false;
            }

            DateTime _date = new DateTime();
            if (c_ActionFlag == 'S')
            {
                if (DateTime.TryParse(dtpStartTime.Value.ToString(), out _date) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(120), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            else if (c_ActionFlag == 'E')
            {
                if (DateTime.TryParse(dtpStartTime.Value.ToString(), out _date) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(120), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (DateTime.TryParse(dtpEndTime.Value.ToString(), out _date) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(120), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (DateTime.Parse(dtpEndTime.Value.ToString()) < DateTime.Parse(dtpStartTime.Value.ToString()))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(371), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            else
            {
                if (MPCF.CheckValue(txtStatus, 1) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool TranJobChangeItem(char c_ActionFlag)
        {
            try
            {

                if (CheckCondition(c_ActionFlag) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("TRAN_JOB_CHANGE_ITEM_IN");
                TRSNode out_node = new TRSNode("TRAN_JOB_CHANGE_ITEM_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;                
                in_node.AddString("ORDER_ID", MPCF.Trim(txtOrderID.Text));
                in_node.AddString("ITEM_CODE", MPCF.Trim(txtItemCode.Text));
                in_node.AddChar("ACTION_FLAG", c_ActionFlag);
                if (c_ActionFlag == 'S')                {
                    
                    in_node.AddChar("STATUS", 'S'); //Start
                    in_node.AddString("START_TIME", DateTime.Parse(dtpStartTime.Value.ToString()).ToString("yyyyMMddHHmmss"));
                    in_node.AddInt("WORK_TIME", 0);
                }
                else if (c_ActionFlag == 'E')
                {
                    in_node.AddChar("STATUS", 'E'); //End
                    in_node.AddString("END_TIME", DateTime.Parse(dtpEndTime.Value.ToString()).ToString("yyyyMMddHHmmss"));
                    TimeSpan _span = DateTime.Parse(dtpEndTime.Value.ToString()) - DateTime.Parse(dtpStartTime.Value.ToString());
                    in_node.AddInt("WORK_TIME", _span.TotalMinutes);
                }
                else if (c_ActionFlag == 'B')
                {
                    char c_status;
                    if (MPCF.Trim(txtStatus.Text) == "S")
                    {
                        c_status = 'W'; //Wait
                        in_node.AddString("START_TIME", "");
                        in_node.AddString("END_TIME", "");
                    }
                    else if (MPCF.Trim(txtStatus.Text) == "E")
                    {
                        c_status = 'S'; //Start
                        in_node.AddString("START_TIME", DateTime.Parse(dtpStartTime.Value.ToString()).ToString("yyyyMMddHHmmss"));
                        in_node.AddString("END_TIME", "");
                        in_node.AddInt("WORK_TIME", 0);
                    }
                    else
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, true);
                        return false;
                    }

                    in_node.AddChar("STATUS", c_status);
                    //in_node.AddString("END_TIME", DateTime.Parse(dtpEndTime.Value.ToString()).ToString("yyyyMMddHHmmss"));
                    //in_node.AddInt("WORK_TIME", 0);
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, true);
                    return false;
                }

                if (MPCF.CallService("CJCM", "CJCM_Update_Job_Change_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewJobChangeItem(string sOrderID, string sItemCode)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_JOB_CHANGE_ITEM_IN");
                TRSNode out_node = new TRSNode("VIEW_JOB_CHANGE_ITEM_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; // '5': Order List by Line ID including BOM, '6': Order List by Line ID and Order ID including BOM
                in_node.AddString("ORDER_ID", MPCF.Trim(sOrderID));
                in_node.AddString("ITEM_CODE", MPCF.Trim(sItemCode));
                if (MPCF.CallService("CJCM", "CJCM_View_Job_Change_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtOrderID.Text = MPCF.Trim(out_node.GetString("ORDER_ID"));
                txtMatID.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
                txtMatDesc.Text = MPCF.Trim(out_node.GetString("ORDER_DESC"));
                txtItemCode.Text = MPCF.Trim(out_node.GetString("ITEM_CODE"));
                txtItemName.Text = MPCF.Trim(out_node.GetString("ITEM_NAME"));
                txtStatus.Text = MPCF.Trim(out_node.GetChar("STATUS").ToString());
                txtStatusDesc.Text = MPCF.Trim(out_node.GetString("STATUS_DESC"));
                txtPlanStartDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_START_DATE"), DATE_TIME_FORMAT.DATE);
                txtPlanEndDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_END_DATE"), DATE_TIME_FORMAT.DATE);
                txtPlanStartDate.Text = txtPlanStartDate.Text + " " + MPCF.Trim(out_node.GetString("PLAN_START_HOUR")); ;
                txtPlanEndDate.Text = txtPlanEndDate.Text + " " + MPCF.Trim(out_node.GetString("PLAN_END_HOUR")); ;


                if (out_node.GetChar("STATUS") == 'W')
                {
                    dtpStartTime.Value = DateTime.Now;
                    dtpEndTime.Value = "";
                    dtpStartTime.Enabled = true;
                    dtpEndTime.Enabled = false;
                    btnStart.Enabled = true;
                    btnCancel.Enabled = false;
                    btnEnd.Enabled = false;
                }
                else if (out_node.GetChar("STATUS") == 'S')
                {
                    dtpStartTime.Value = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));                    
                    dtpEndTime.Value = DateTime.Now;
                    dtpStartTime.Enabled = false;
                    dtpEndTime.Enabled = true;
                    btnStart.Enabled = false;
                    btnEnd.Enabled = true;
                    btnCancel.Enabled = true;
                }
                else if (out_node.GetChar("STATUS") == 'E')
                {
                    dtpStartTime.Value = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
                    dtpEndTime.Value = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
                    dtpStartTime.Enabled = false;
                    dtpEndTime.Enabled = false;
                    btnStart.Enabled = false;
                    btnEnd.Enabled = false;
                    btnCancel.Enabled = true;
                }
                else
                {
                    if (MPCF.Trim(out_node.GetString("START_TIME")).Length == 14)
                        dtpStartTime.Value = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));

                    if (MPCF.Trim(out_node.GetString("END_TIME")).Length == 14)
                        dtpEndTime.Value = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));

                    btnCancel.Enabled = false;
                    btnStart.Enabled = false;
                    btnEnd.Enabled = false;
                }
                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        #endregion

       
    }
}
