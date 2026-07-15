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
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.WIPCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPSelectBatchingOrderPopup : frmPopupBase
    {
        #region Property

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
        private enum ORDER
        {
            ORD_DATE = 0,
            ORDER_ID,
            MAT_ID,
            MAT_BOM_TYPE,
            MAT_DESC,
            ORD_QTY,
            PROD_QTY,
            UNIT,
            LINE,
            RES,
            ORD_START_TIME,
            ORD_END_TIME,
            ORD_STS
        }

        private enum BOM
        {
            INV_MAT_ID = 0,
            INV_MAT_DESC,
            BOM_QTY,
            UNIT
        }

        private string s_selected_order;

        private double dOrderQty;

        public double DOrderQty
        {
            get { return dOrderQty; }
            set { dOrderQty = value; }
        }

        private string sMatId;

        public string SMatId
        {
            get { return sMatId; }
            set { sMatId = value; }
        }

        private string sMatType;

        public string SMatType
        {
            get { return sMatType; }
            set { sMatType = value; }
        }

        private string sOrderId;

        public string SOrderId
        {
            get { return sOrderId; }
            set { sOrderId = value; }
        }

        private string sMatBomType;

        public string SMatBomType
        {
            get { return sMatBomType; }
            set { sMatBomType = value; }
        }

        private string sMatDesc;

        public string SMatDesc
        {
            get { return sMatDesc; }
            set { sMatDesc = value; }
        }

    
        #endregion

        #region Constructor

        public frmWIPSelectBatchingOrderPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            dtpOrderDate.Value = System.DateTime.Today.AddDays(-7);
            dtpToDate.Value =  System.DateTime.Today;

            MPCF.ClearList(spdWorkOrder);

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
            // save registry
            SetDefaultValueToReg();
            this.Close();
        }


        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                BICF.ViewLineGroup(cdvLineGroup);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
            return;
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag.ToString()));
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLineGroup_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Tag = "";
                cdvLine.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;

                BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_P);

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "View Mat List";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (MPCF.Trim(frm.OUT_MAT_ID) == "")
                {
                    frm.ShowDialog();
                }
                txtMatDesc.Text = frm.OUT_MAT_DESC;
                cdvMatID.Text = frm.OUT_MAT_ID;
                txtMatUnit.Text = frm.OUT_MAT_UNIT_1;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdWorkOrder_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                if (spdWorkOrder.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;
                s_selected_order = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[e.Row, (int)ORDER.ORDER_ID].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_ORDER_LIST") == true)
                {
                    ViewOrderList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)spdWorkOrder.Sheets[0].SelectionCount <= 0)
                {
                    return;
                }
                sOrderId = MPCF.Trim(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, (int)ORDER.ORDER_ID].Value);
                dOrderQty = MPCF.ToDbl(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, (int)ORDER.ORD_QTY].Value);
                sMatId = MPCF.Trim(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, (int)ORDER.MAT_ID].Value);
                sMatDesc = MPCF.Trim(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, (int)ORDER.MAT_DESC].Value);
                sMatBomType = MPCF.Trim(spdWorkOrder.Sheets[0].Cells[spdWorkOrder.Sheets[0].ActiveRowIndex, (int)ORDER.MAT_BOM_TYPE].Value);
                // save registry
                SetDefaultValueToReg();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

       
        #region Function

        public void GetDefaultValueFromReg()
        {
            try
            {
                cdvLineGroup.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Text"));
                cdvLineGroup.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag"));

                cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
                cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Tag"));

                cdvMatID.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvMatID.Text"));
                cdvMatID.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvMatID.Tag"));

                txtMatUnit.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtMatUnit.Text"));

                txtMatDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtMatDesc.Text"));
                
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
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Text", MPCF.Trim(cdvLineGroup.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLineGroup.Tag", MPCF.Trim(cdvLineGroup.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvMatID.Text", MPCF.Trim(cdvMatID.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvMatID.Tag", MPCF.Trim(cdvMatID.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtMatUnit.Text", MPCF.Trim(txtMatUnit.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtMatDesc.Text", MPCF.Trim(txtMatDesc.Text));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool ViewOrderList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORD_DATE";
                dvcArgu[1].sCondition_Value = dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "ORD_TO_DATE";
                dvcArgu[2].sCondition_Value = dtpToDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                if (MPCF.Trim(cdvLine.Text) == "")
                {
                    dvcArgu[3].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLine.Tag);
                }

                dvcArgu[4].sCondtion_ID = "LINE_GRP";
                if (MPCF.Trim(cdvLineGroup.Text) == "")
                {
                    dvcArgu[4].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[4].sCondition_Value = MPCF.Trim(cdvLineGroup.Tag);
                }

                dvcArgu[5].sCondtion_ID = "ORD_STATUS";
                dvcArgu[5].sCondition_Value = MPCF.Trim(rdoStatus.Items[rdoStatus.CheckedIndex].DataValue.ToString());

                dvcArgu[6].sCondtion_ID = "MAT_ID";
                if (MPCF.Trim(cdvMatID.Text) == "")
                {
                    dvcArgu[6].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[6].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                }

                if (TPDR.GetDataOne("", ref dt, "CWIP8010-003", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_DATE].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    if (i == 0)
                    {
                        s_selected_order = dt.Rows[i]["ORDER_ID"].ToString();
                    }
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_BOM_TYPE].Value = dt.Rows[i]["MAT_BOM_TYPE"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_QTY].Value = dt.Rows[i]["ORD_QTY"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.PROD_QTY].Value = dt.Rows[i]["PROD_QTY"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.UNIT].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.LINE].Value = dt.Rows[i]["LINE_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.RES].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_START_TIME].Value = dt.Rows[i]["ORD_START_TIME"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_END_TIME].Value = dt.Rows[i]["ORD_END_TIME"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORDER.ORD_STS].Value = dt.Rows[i]["ORDER_STATUS"].ToString();
                }
                MPCF.FitColumnHeader(spdWorkOrder);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }


        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW_ORDER_LIST":
                        //LINE GROUP  
                        if (MPCF.Trim(cdvLineGroup.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLineGroup.Focus();
                            return false;
                        }

                        //LINE
                        if (MPCF.Trim(cdvLine.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvLine.Focus();
                            return false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }
        #endregion

        private void frmWIPSelectBatchingOrderPopup_Shown(object sender, EventArgs e)
        {
            GetDefaultValueFromReg();
        }

        
    }
}
