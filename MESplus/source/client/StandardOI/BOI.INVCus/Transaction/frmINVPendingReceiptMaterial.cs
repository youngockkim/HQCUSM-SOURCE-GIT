using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVPendingReceiptMaterial : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private MenuInfoTag menuInfo;

        private enum COL_LIST
        {
            COL_CHK = 0,
            COL_DLV_STS ,
            COL_DLV_STS_DESC,
            COL_DLV_NO , 
            COL_DLV_SEQ ,
            COL_DLV_DATE,
            COL_VENDOR_ID,
            COL_VENDOR_CODE,
            COL_VENDOR_DESC,
            COL_MAT_ID_CNT,
            COL_DLV_QTY,
            COL_PO_NO,
            COL_PO_SEQ,
            COL_DLV_TYPE,
            COL_DLV_TYPE_DESC
        }

        #endregion

        #region Constructor

        public frmINVPendingReceiptMaterial()
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            menuInfo = (MenuInfoTag)this.Tag;
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        #region BTN, TEXTBOX EVENT

        private void txtDlvNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter) View_Receipt_Material_List(txtDlvNo.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (View_Receipt_Material_List("") == false) return;
                CheckBox_Clear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Call_Popup() == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region Function

        private bool View_Receipt_Material_List(string sDlvNo)
        {
            try
            {

                MPCF.ClearList(spdList);

                // From Date 설정
                DateTime dtpDateTimeOut = new DateTime();
                string sToDate = "";
                string sFromDate = "";
                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        sFromDate = dtpDateTimeOut.ToString("yyyyMMdd");
                    }
                }

                // To Date 설정
                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        sToDate = dtpDateTimeOut.ToString("yyyyMMdd");
                    }
                }

                if (sDlvNo != "")    // 텍스트박스
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                    DataTable dt = null;
                    string s_column = "";
                    string sql = "";

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "DLV_NO";
                    dvcArgu[1].sCondition_Value = sDlvNo;

                    if (TPDR.GetDataOne(s_column, ref dt, "BINV1003-002", dvcArgu, false, false ,ref sql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        spdList.Sheets[0].RowCount += 1;
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_DATE].Value = dt.Rows[i]["DLV_DATE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_NO].Value = dt.Rows[i]["DLV_NO"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_QTY].Value = dt.Rows[i]["DLV_QTY_1"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_SEQ].Value = dt.Rows[i]["DLV_SEQ"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_STS].Value = dt.Rows[i]["DLV_STS"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_STS_DESC].Value = dt.Rows[i]["DLV_STS_DESC"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_ID].Value = dt.Rows[i]["VENDOR_ID"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_CODE].Value = dt.Rows[i]["VENDOR_CODE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_DESC].Value = dt.Rows[i]["VENDOR_DESC"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_MAT_ID_CNT].Value = dt.Rows[i]["MAT_ID_CNT"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_PO_NO].Value = dt.Rows[i]["PO_NO"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_PO_SEQ].Value = dt.Rows[i]["PO_SEQ"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_TYPE].Value = dt.Rows[i]["DLV_TYPE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_TYPE_DESC].Value = dt.Rows[i]["DLV_TYPE_DESC"].ToString();
                    }
                }
                else  //그외
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];
                    DataTable dt = null;
                    string s_column = "";
                    string sql = "";

                    dvcArgu[0].sCondtion_ID = "DLV_TYPE";
                    if (cdvDlvType.Text == "") dvcArgu[0].sCondition_Value = "";
                    else dvcArgu[0].sCondition_Value = cdvDlvType.Tag.ToString();

                    dvcArgu[1].sCondtion_ID = "FROM_DATE";
                    dvcArgu[1].sCondition_Value = sFromDate;

                    dvcArgu[2].sCondtion_ID = "TO_DATE";
                    dvcArgu[2].sCondition_Value = sToDate;

                    dvcArgu[3].sCondtion_ID = "FACTORY";
                    dvcArgu[3].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[4].sCondtion_ID = "DLV_NO";
                    dvcArgu[4].sCondition_Value = txtDlvNo.Text;

                    if (TPDR.GetDataOne(s_column, ref dt, "BINV1003-003", dvcArgu, false, false, ref sql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        spdList.Sheets[0].RowCount += 1;
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_DATE].Value = dt.Rows[i]["DLV_DATE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_NO].Value = dt.Rows[i]["DLV_NO"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_QTY].Value = dt.Rows[i]["DLV_QTY_1"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_SEQ].Value = dt.Rows[i]["DLV_SEQ"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_STS].Value = dt.Rows[i]["DLV_STS"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_STS_DESC].Value = dt.Rows[i]["DLV_STS_DESC"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_ID].Value = dt.Rows[i]["VENDOR_ID"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_CODE].Value = dt.Rows[i]["VENDOR_CODE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_VENDOR_DESC].Value = dt.Rows[i]["VENDOR_DESC"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_MAT_ID_CNT].Value = dt.Rows[i]["MAT_ID_CNT"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_PO_NO].Value = dt.Rows[i]["PO_NO"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_PO_SEQ].Value = dt.Rows[i]["PO_SEQ"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_TYPE].Value = dt.Rows[i]["DLV_TYPE"].ToString();
                        spdList.Sheets[0].Cells[spdList.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_TYPE_DESC].Value = dt.Rows[i]["DLV_TYPE_DESC"].ToString();
                    }
                }
              
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void CheckBox_Clear()
        {
            try
            {
                for (int i = 0; i < spdList.Sheets[0].RowCount; i++)
                {
                    spdList.Sheets[0].Cells[i, (int)COL_LIST.COL_CHK].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.WARNING, false);
                return;
            }
        }

        private bool Call_Popup()
        {
            try
            {
                int iSelectedCount = 0;
                int iSelectedIndex = 0;
                string sDlvNo = "";
                for (int i = 0; i < spdList.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdList.Sheets[0].Cells[i, (int)COL_LIST.COL_CHK].Value == true)
                    {
                        iSelectedCount++;
                        iSelectedIndex = i;
                    }
                }

                if (iSelectedCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(71), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (iSelectedCount >= 2)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(419), MSG_LEVEL.ERROR, false);
                    return false;
                }

                sDlvNo = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_NO].Text;

                /*
                 *  팝업 다이얼로그 호출
                 */
                //BICF.OpenMenu(BIGC.MP_FUNC_NAME_OINV1008, sDlvNo);
                frmINVInputProccess frm = new frmINVInputProccess();

                MenuInfoTag selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "Input Receipt";
                frm.Tag                      = selectedMenuInfo;

                frm.Dlv_no        = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_NO].Text      ;
                frm.Dlv_seq       = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_SEQ].Text     ;
                frm.Dlv_date      = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_DATE].Text    ;
                frm.Dlv_type      = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_TYPE].Text    ;
                frm.Dlv_type_desc = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_DLV_TYPE_DESC].Text;
                
                
                frm.Vendor_code   = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_VENDOR_CODE].Text ;
                frm.Vendor_desc   = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_VENDOR_DESC].Text ;
                frm.Po_no         = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_PO_NO].Text;
                frm.Po_seq        = spdList.Sheets[0].Cells[iSelectedIndex, (int)COL_LIST.COL_PO_SEQ].Text;
                frm.Po_sts        = "";

                frm.StartPosition   = FormStartPosition.CenterParent;
                frm.Width           = this.Width    - 5;
                frm.Height          = this.Height   - 5;
                

                
                frm.ShowDialog();

               

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.WARNING, false);
                return false;
            }
        }

        #endregion
 private void cdvDlvType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");
                
                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_REQ_TYPE));
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_DLV_TYPE)); /*JYD 20170405*/
                in_node.AddString("DATA_2", "Y");

                // CodeView Column Header Setup
                string[] header = new string[] { "DLV TYPE", "DESCRIPTION" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvDlvType.Text = cdvDlvType.Show(cdvDlvType, "INPUT TYPE", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvDlvType.Text) != "")
                {
                    if (cdvDlvType.returnDatas.Count > 0)
                    {
                        cdvDlvType.Text = cdvDlvType.returnDatas[1];
                        cdvDlvType.Tag = cdvDlvType.returnDatas[0];
                    }
                }
            }
            catch
            {
            }
        }
    }
}
