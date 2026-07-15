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

namespace BOI.WIPCus
{
    public partial class frmWIPViewLotList : SOI.OIFrx.SOIPopup.frmPopupBase
    {
        public frmWIPViewLotList()
        {
            InitializeComponent();
        }

        //[Flags]
        public enum LOT
        {
            OPER_IN_TIME,
            MAT_ID,
            MAT_DESC,
            LOT_ID,
            QTY_1,
            LINE_ID,
            LINE_DESC,
            OPER,
            OPER_DESC,
            RES_ID,
            RES_DESC,
            ORDER_ID,
            NONE          
        }

        private string _lotId = string.Empty;

        public string LotId
        {
            get { return _lotId; }
            set { _lotId = value; }
        }

        private string _lineId = string.Empty;

        public string LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set { _oper = value; }
        }

        private string _resId = string.Empty;

        public string ResId
        {
            get { return _resId; }
            set { _resId = value; }
        }

        private string _orderId = string.Empty;

        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }


        private bool View_Lot_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[8];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "FROM_TIME";
                dvcArgu[1].sCondition_Value = dtFrDate.GetValueAsDateTime().ToString("yyyyMMdd000000");

                dvcArgu[2].sCondtion_ID = "TO_TIME";
                dvcArgu[2].sCondition_Value = dtToDate.GetValueAsDateTime().ToString("yyyyMMdd999999");

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLine.Tag);

                dvcArgu[4].sCondtion_ID = "OPER";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvOper.Tag);

                dvcArgu[5].sCondtion_ID = "RES_ID";
                dvcArgu[5].sCondition_Value = MPCF.Trim(cdvResource.Tag);

                dvcArgu[6].sCondtion_ID = "MAT_ID";
                dvcArgu[6].sCondition_Value = "";

                dvcArgu[7].sCondtion_ID = "ORDER_ID";
                dvcArgu[7].sCondition_Value = "";

                if (TPDR.GetDataOne("", ref dt, "COM0000-019", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.OPER_IN_TIME].Value = MPCF.MakeDateFormat(dt.Rows[i][LOT.OPER_IN_TIME.ToString()].ToString(), DATE_TIME_FORMAT.DATETIME);
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.MAT_ID].Value = dt.Rows[i][LOT.MAT_ID.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.MAT_DESC].Value = dt.Rows[i][LOT.MAT_DESC.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.LOT_ID].Value = dt.Rows[i][LOT.LOT_ID.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.QTY_1].Value = MPCF.ToDbl(dt.Rows[i][LOT.QTY_1.ToString()]);
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.LINE_ID].Value = dt.Rows[i][LOT.LINE_ID.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.LINE_DESC].Value = dt.Rows[i][LOT.LINE_DESC.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.OPER].Value = dt.Rows[i][LOT.OPER.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.OPER_DESC].Value = dt.Rows[i][LOT.OPER_DESC.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.RES_ID].Value = dt.Rows[i][LOT.RES_ID.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.RES_DESC].Value = dt.Rows[i][LOT.RES_DESC.ToString()].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)LOT.ORDER_ID].Value = dt.Rows[i][LOT.ORDER_ID.ToString()].ToString();
                    
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLineGroup(cdvLineGroup);
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag));
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvLine.Tag);

                dvcArgu[2].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[2].sCondition_Value = "";
                
                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Oper", "COM0000-020", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        cdvOper.Tag = cdvOper.returnDatas[0];                        
                    }
                    else
                    {
                        //cdvOper.Tag = "";
                    }
                }
                else
                {
                    cdvOper.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _lotId = string.Empty;
            _lineId = string.Empty;
            _oper = string.Empty;
            _resId = string.Empty;
            _orderId = string.Empty;

            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Lot_List();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount == 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                return;
            }

            _lotId = MPCF.Trim(spdWorkOrder_Sheet1.GetValue(spdWorkOrder_Sheet1.ActiveRowIndex, (int)LOT.LOT_ID));
            _lineId = MPCF.Trim(spdWorkOrder_Sheet1.GetValue(spdWorkOrder_Sheet1.ActiveRowIndex, (int)LOT.LINE_ID));
            _oper = MPCF.Trim(spdWorkOrder_Sheet1.GetValue(spdWorkOrder_Sheet1.ActiveRowIndex, (int)LOT.OPER));
            _resId = MPCF.Trim(spdWorkOrder_Sheet1.GetValue(spdWorkOrder_Sheet1.ActiveRowIndex, (int)LOT.RES_ID));
            _orderId = MPCF.Trim(spdWorkOrder_Sheet1.GetValue(spdWorkOrder_Sheet1.ActiveRowIndex, (int)LOT.ORDER_ID));
            DialogResult = DialogResult.OK;
        }

        private void frmWIPViewLotList_Load(object sender, EventArgs e)
        {
            dtFrDate.Value = DateTime.Now.AddDays(-7);
            dtToDate.Value = DateTime.Now.AddDays(7);
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewResource(cdvResource, MPCF.Trim(cdvLineGroup.Tag), MPCF.Trim(cdvLine.Tag), "");
        }
    }
}
