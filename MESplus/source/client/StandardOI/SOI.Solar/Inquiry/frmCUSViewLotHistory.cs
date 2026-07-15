using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace SOI.Solar
{
    public partial class frmCUSViewLotHistory : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSViewLotHistory()
        {
            InitializeComponent();
        }

        public enum LOT
        {
            TRAN_TIME,
            TRAN_CODE,
            OPER,
            OPER_DESC,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            ORDER_ID,
            RES_ID,
            RES_DESC,
            FLOW,
            TRAN_USER_ID
        }

        public enum MAT
        {
            OPER,
            OPER_DESC,
            RES_ID,
            RES_DESC,
            MAT_ID,
            MAT_DESC,
            MAT_LOT_ID,
            MAT_QTY,
            UNIT_1,
            TRAN_TIME,
            TRAN_USER_ID
        }

        public enum LOSS
        {
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            LOSS_TYPE,
            POSITION,
            LOSS_CODE,
            LOSS_CODE_DESC,            
            TRAN_USER_ID,
            TRAN_TIME,
            RESULT_CODE,
            RESULT_CODE_DESC,
            RESULT_USER_ID,
            RESULT_TIME            
        }

        #region [Variable Definition]

        private bool bIsShown = false;

        #endregion

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Lot_History()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdLotList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_HISTORY", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList_Sheet1.RowCount++;                    
                    spdLotList_Sheet1.Cells[i, (int)LOT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.TRAN_CODE].Value = dt.Rows[i]["TRAN_CODE"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.QTY_1].Value = dt.Rows[i]["QTY_1"];
                    spdLotList_Sheet1.Cells[i, (int)LOT.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();                    
                    spdLotList_Sheet1.Cells[i, (int)LOT.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.FLOW].Value = dt.Rows[i]["FLOW"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        public void GetDefaultValueFromReg()
        {
            try
            {
                //cdvLineGroup.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void SetDefaultValueToReg()
        {
            try
            {
                //MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag", MPCF.Trim(cdvLineGroup.Tag));                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
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

        private bool View_Use_Material()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                spdUseMaterial_Sheet1.RowCount = 0;

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_USE_MATERIAL", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdUseMaterial.ActiveSheet.RowCount++;
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_LOT_ID].Value = dt.Rows[i]["MAT_LOT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_QTY].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdUseMaterial);

                spdUseMaterial.ActiveSheet.Columns[(int)MAT.MAT_DESC].Width = 150F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool View_Loss_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                spdLossList_Sheet1.RowCount = 0;

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOSS_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdLossList.ActiveSheet.RowCount++;
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();                    
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.LOSS_TYPE].Value = dt.Rows[i]["LOSS_TYPE"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.POSITION].Value = dt.Rows[i]["POSITION"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.LOSS_CODE].Value = dt.Rows[i]["LOSS_CODE"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.LOSS_CODE_DESC].Value = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.TRAN_TIME].Value = dt.Rows[i]["REQ_TIME"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.TRAN_USER_ID].Value = dt.Rows[i]["REQ_USER_ID"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.RESULT_CODE].Value = dt.Rows[i]["RESULT_CODE"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.RESULT_CODE_DESC].Value = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.RESULT_TIME].Value = dt.Rows[i]["RESULT_TIME"].ToString();
                    spdLossList.ActiveSheet.Cells[i, (int)LOSS.RESULT_USER_ID].Value = dt.Rows[i]["RESULT_USER_ID"].ToString();                    
                }

                MPCF.FitColumnHeader(spdLossList);

                spdLossList.ActiveSheet.Columns[(int)LOSS.MAT_DESC].Width = 150F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

            View_Lot_History();

            View_Use_Material();

            View_Loss_List();

			MPCF.SetFocusAndSelectAll(txtLotID);
        }

        private void frmCUSViewLotHistory_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            MPCF.ClearList(spdUseMaterial);
            MPCF.ClearList(spdLossList);
        }

        private void frmCUSViewLotHistory_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자
                btnView.PerformClick();
            }
        }
    }
}
