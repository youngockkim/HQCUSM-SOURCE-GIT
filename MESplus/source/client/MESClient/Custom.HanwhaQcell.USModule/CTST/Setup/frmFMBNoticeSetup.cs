/*---------------------------------------------------------------------------------------------------*/
//
//  Program Id      : frmFMBNoticeSetup.cs
//  Creator         : JGCHOI.
//  Create Date     : 2019.10.18
//  Description     : FMB보드 공지사항 등록
//  History         : 2019.10.18 - Create
//
/*---------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.UI;
using Miracom.UI.Controls.MCCodeView;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmFMBNoticeSetup : TranForm02
    {
        public frmFMBNoticeSetup()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private enum SPD_COL : int
        {
            COL_CHK = 0,
            DATE,
            PLANT,
            LINE,
            PRODUCT,
            PRODUCT_DESC,
            EXP_WATT_PER_PC,
            PLN_OUTPUT,
            PLN_YIELD,
            PLN_OUTPUT_GOOD_WATT,
            PLN_FEL_DEFECT_RATE,
            PLN_CELL_LOSS_IN_MODULE,
            PLN_CELL_LOSS_IN_CELL,
            CREATE_TIME,
            CREATE_USER_ID,
            UPDATE_TIME,
            UPDATE_USER_ID
        }

        private const string SPREAD_BTN_STATUS_CODE = "STATUS_CODE";
        private bool bExcelOpen = false;
        private SortedList<int, int> colList = null;
        #endregion

        #region " Variable Definition "
        
        bool bCheck = false;
        #endregion 

        #region " Function Definition "
        /// <summary>
        /// initialze Condition
        /// </summary>
        /// <returns></returns>
       
        /// <summary>
        /// 콘트롤 초기화 함수
        /// </summary>
        /// <param name="s_case"></param>
        /// <returns></returns>
        private bool ClearField(string s_case)
        {
            try
            {
                switch (s_case)
                {
                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : ClearField\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 벨리데이션
        /// </summary>
        /// <param name="s_case"></param>
        /// <returns></returns>
        private bool CheckValue()
        {
            try
            {
                foreach (Control ctr in grpViewNoticeInfo.Controls)
                {
                    if (ctr is GroupBox)
                    {
                        foreach (Control x in ctr.Controls)
                        {
                            if (x is TextBox && ((TextBox)x).Name.IndexOf("txtLine") >= 0)
                            {
                                if (HQCF.CheckStrMaxLength(((TextBox)x).Text.Trim(), 200, "UTF-8") == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(371) + " MAX=200");//Exceeded number of stored characters
                                    ((TextBox)x).SelectAll();
                                    return false;
                                }
                            }
                            else if(x is TextBox && ((TextBox)x).Name.IndexOf("txtLine") < 0)
                            {
                                if(((TextBox)x).Text.Trim() == string.Empty)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing.
                                    ((TextBox)x).Focus();
                                    return false;
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("Function : CheckValue()\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 스프레드 초기화
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// 출하계획 목록 조회
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <returns></returns>5
        private bool ViewNoticeInfo()
        {
            try
            {
                if(cdvDept.Text.Trim() == string.Empty)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(369));//Required input information is missing
                    cdvDept.Focus();
                    return false;
                }

                DataTable _dt = HQCF.MGetData("VIEW_FMB_NOTICE_INFO", new string[] {cdvDept.Text.Trim()});

                if (_dt == null || _dt.Rows.Count < 1)
                {
                    //데이터가 존재하지 않습니다.
                    MPCF.ShowMsgBox(MPCF.GetMessage(368));
                    btnClear.PerformClick();
                    return false;
                }

                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    txtLine1.Text = _dt.Rows[i]["LINE_1"].ToString();
                    txtLine2.Text = _dt.Rows[i]["LINE_2"].ToString();
                    txtLine3.Text = _dt.Rows[i]["LINE_3"].ToString();
                    txtLine4.Text = _dt.Rows[i]["LINE_4"].ToString();
                    txtLine5.Text = _dt.Rows[i]["LINE_5"].ToString();

                    txtFontSize1.Text = _dt.Rows[i]["FONT_SIZE_1"].ToString();
                    txtFontSize2.Text = _dt.Rows[i]["FONT_SIZE_2"].ToString();
                    txtFontSize3.Text = _dt.Rows[i]["FONT_SIZE_3"].ToString();
                    txtFontSize4.Text = _dt.Rows[i]["FONT_SIZE_4"].ToString();
                    txtFontSize5.Text = _dt.Rows[i]["FONT_SIZE_5"].ToString();

                    txtX1.Text = _dt.Rows[i]["LOC_X_1"].ToString();
                    txtX2.Text = _dt.Rows[i]["LOC_X_2"].ToString();
                    txtX3.Text = _dt.Rows[i]["LOC_X_3"].ToString();
                    txtX4.Text = _dt.Rows[i]["LOC_X_4"].ToString();
                    txtX5.Text = _dt.Rows[i]["LOC_X_5"].ToString();

                    txtY1.Text = _dt.Rows[i]["LOC_Y_1"].ToString();
                    txtY2.Text = _dt.Rows[i]["LOC_Y_2"].ToString();
                    txtY3.Text = _dt.Rows[i]["LOC_Y_3"].ToString();
                    txtY4.Text = _dt.Rows[i]["LOC_Y_4"].ToString();
                    txtY5.Text = _dt.Rows[i]["LOC_Y_5"].ToString();
                }

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipInfoByPeriod()
        {
            try
            {

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateNotice(char cProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                in_node.AddString("DEPARTMENT", cdvDept.Text.Trim());

                in_node.AddString("LINE_1", txtLine1.Text.Trim());
                in_node.AddString("LINE_2", txtLine2.Text.Trim());
                in_node.AddString("LINE_3", txtLine3.Text.Trim());
                in_node.AddString("LINE_4", txtLine4.Text.Trim());
                in_node.AddString("LINE_5", txtLine5.Text.Trim());

                in_node.AddInt("FONT_SIZE_1", int.Parse(txtFontSize1.Text.Trim() == "" ? "0" : txtFontSize1.Text.Trim()));
                in_node.AddInt("FONT_SIZE_2", int.Parse(txtFontSize2.Text.Trim() == "" ? "0" : txtFontSize2.Text.Trim()));
                in_node.AddInt("FONT_SIZE_3", int.Parse(txtFontSize3.Text.Trim() == "" ? "0" : txtFontSize3.Text.Trim()));
                in_node.AddInt("FONT_SIZE_4", int.Parse(txtFontSize4.Text.Trim() == "" ? "0" : txtFontSize4.Text.Trim()));
                in_node.AddInt("FONT_SIZE_5", int.Parse(txtFontSize5.Text.Trim() == "" ? "0" : txtFontSize5.Text.Trim()));

                in_node.AddInt("LOC_X_1", int.Parse(txtX1.Text.Trim() == "" ? "0" : txtX1.Text.Trim()));
                in_node.AddInt("LOC_X_2", int.Parse(txtX2.Text.Trim() == "" ? "0" : txtX2.Text.Trim()));
                in_node.AddInt("LOC_X_3", int.Parse(txtX3.Text.Trim() == "" ? "0" : txtX3.Text.Trim()));
                in_node.AddInt("LOC_X_4", int.Parse(txtX4.Text.Trim() == "" ? "0" : txtX4.Text.Trim()));
                in_node.AddInt("LOC_X_5", int.Parse(txtX5.Text.Trim() == "" ? "0" : txtX5.Text.Trim()));

                in_node.AddInt("LOC_Y_1", int.Parse(txtY1.Text.Trim() == "" ? "0" : txtY1.Text.Trim()));
                in_node.AddInt("LOC_Y_2", int.Parse(txtY2.Text.Trim() == "" ? "0" : txtY2.Text.Trim()));
                in_node.AddInt("LOC_Y_3", int.Parse(txtY3.Text.Trim() == "" ? "0" : txtY3.Text.Trim()));
                in_node.AddInt("LOC_Y_4", int.Parse(txtY4.Text.Trim() == "" ? "0" : txtY4.Text.Trim()));
                in_node.AddInt("LOC_Y_5", int.Parse(txtY5.Text.Trim() == "" ? "0" : txtY5.Text.Trim()));

                if (MPCR.CallService("CWIP", "CWIP_Update_Fmb_Notice", in_node, ref out_node) == false)
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

        private bool DeleteProductPlan()
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("UPDATE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_DELETE;

                in_node.AddString("DEPARTMENT", cdvDept.Text.Trim());

                if (MPCR.CallService("CWIP", "CWIP_Update_Fmb_Notice", in_node, ref out_node) == false)
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
              
        /// <summary>
        /// 스프레드 버튼 이벤트 
        /// </summary>
        /// <param name="s_case"></param>
        /// <param name="i_row"></param>
        /// <param name="i_column"></param>
        /// <returns></returns>
        
        /// <summary>
        /// Control Event Handler
        /// </summary>
        
        
        #endregion

        #region " Event Definition "

        private void frmFMBNoticeSetup_Load(object sender, EventArgs e)
        {
            txtLine1.SelectAll();
        }
        
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValue() == true)
                {   
                    //체크된 행이 삭제됩니다. 삭제하시겠습니까?
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(367), Application.ProductName, MessageBoxButtons.YesNo, 1) != DialogResult.Yes) return;

                    if (DeleteProductPlan() == true)
                    {
                        btnView.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

       
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void btnView_Click(object sender, EventArgs e)
        {
            if (ViewNoticeInfo() == false) return;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckValue() == true)
            {
                if (UpdateNotice(MPGC.MP_STEP_UPDATE) == true)
                {
                    btnView.PerformClick();
                }
            }
        }

        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctr in grpViewNoticeInfo.Controls)
                {
                    if (ctr is GroupBox)
                    {
                        foreach (Control x in ctr.Controls)
                        {
                            if(x is TextBox)  ((TextBox)x).Text = String.Empty;
                        }
                    }
                }
                cdvDept.Text = string.Empty;
                cdvDept.DescText = string.Empty;
                txtLine1.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvDept_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            string s_sql;

            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Material", 100, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.VisibleColumnHeader = true;
                cdvTemp.SelectedSubItemIndex = 0;
                cdvTemp.SelectedDescIndex = 1;

                s_sql = "SELECT KEY_1 DEPT_CODE, DATA_1 DEPT_DESC FROM MGCMTBLDAT ";
                s_sql += " WHERE FACTORY='" + MPGV.gsFactory + "' AND TABLE_NAME = '@DEPARTMENT' ";
                s_sql += " ORDER BY KEY_1 ";

                BASLIST.ViewQueryList(cdvTemp.GetListView, '1', s_sql, (int)SMALLICON_INDEX.IDX_MATERIAL, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDept_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            ViewNoticeInfo();
        }

        private void txtFontSize1_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtFontSize1.Text.Trim()) == false) txtFontSize1.Text = string.Empty;
        }

        private void txtFontSize2_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtFontSize2.Text.Trim()) == false) txtFontSize2.Text = string.Empty;
        }

        private void txtFontSize3_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtFontSize3.Text.Trim()) == false) txtFontSize3.Text = string.Empty;
        }

        private void txtFontSize4_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtFontSize4.Text.Trim()) == false) txtFontSize4.Text = string.Empty;
        }

        private void txtFontSize5_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtFontSize5.Text.Trim()) == false) txtFontSize5.Text = string.Empty;
        }

        private void txtX1_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtX1.Text.Trim()) == false) txtX1.Text = string.Empty;
        }

        private void txtX2_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtX2.Text.Trim()) == false) txtX2.Text = string.Empty;
        }

        private void txtX3_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtX3.Text.Trim()) == false) txtX3.Text = string.Empty;
        }

        private void txtX4_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtX4.Text.Trim()) == false) txtX4.Text = string.Empty;
        }

        private void txtX5_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtX5.Text.Trim()) == false) txtX5.Text = string.Empty;
        }

        private void txtY1_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtY1.Text.Trim()) == false) txtY1.Text = string.Empty;
        }

        private void txtY2_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtY2.Text.Trim()) == false) txtY2.Text = string.Empty;
        }

        private void txtY3_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtY3.Text.Trim()) == false) txtY3.Text = string.Empty;
        }

        private void txtY4_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtY4.Text.Trim()) == false) txtY4.Text = string.Empty;
        }

        private void txtY5_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.CheckNumeric(txtY5.Text.Trim()) == false) txtY5.Text = string.Empty;
        }
    }
}
