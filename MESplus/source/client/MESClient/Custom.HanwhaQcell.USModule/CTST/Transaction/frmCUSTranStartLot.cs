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
using Infragistics.Win.UltraWinGrid;
using Miracom.CliFrx;
using Miracom.MESCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmCUSTranStartLot : SOIBaseForm02
    {
        public frmCUSTranStartLot()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum ORDER_LIST : int
        {
            ORDER_ID = 0,
            MAT_ID,
            MAT_VER,
            FLOW,
            FLOW_SEQ_NUM,
            ORD_QTY
        }

        //private const string CLEAR_ALL = "ALL";
        private const string CLEAR_LABEL_INIT = "CLEAR_LABEL_INIT";

        #endregion

        #region " Variable Definition "
        
        #endregion

        #region " Constant Definition "
        
        #endregion
        
        #region "Event Definition"

        private void frmCUSTranStartLot_Load(object sender, EventArgs e)
        {
            try
            {
                MPOF.ConvertCaption(this);


            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line Code", "Description" };

                // Show CodeView and Get Return Data
                cdvLine.Text = cdvLine.Show(cdvLine, "Code List", "GCM_View_Data_1", new string[] { HQGC.GCM_LINE_CODE }, display, header, "KEY_1");

                if (cdvLine.returnDatas == null)
                {
                    return;
                }

                txtLineDesc.Text = cdvLine.returnDatas[1];

                ViewOrderList();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Operation", "Description" };

                // Show CodeView and Get Return Data
                cdvOper.Text = cdvOper.Show(cdvOper, "Code List", "WIP_View_Oper_List_1", new string[] { }, display, header, "OPER");

                if (cdvOper.returnDatas == null)
                {
                    return;
                }

                txtOperDesc.Text = cdvOper.returnDatas[1];

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Resource", "Description" };

                // Show CodeView and Get Return Data
                cdvResID.Text = cdvResID.Show(cdvResID, "Code List", "RAS_View_Resource_List_1", new string[] { }, display, header, "RES_ID");

                if (cdvResID.returnDatas == null)
                {
                    return;
                }

                txtResDesc.Text = cdvResID.returnDatas[1];

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        #endregion




        #region "Function Definition"

        private bool ViewOrderList()
        {
            try
            {
                MPCF.ClearList(spdOrder);

                string[] sArgu = new string[1];
                sArgu[0] = HQCF.Trim(cdvLine.Text);

                DataTable dt = HQCF.MGetData("ORD_View_Production_Order_1", sArgu);

                spdOrder.ActiveSheet.RowCount = 0;

                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    spdOrder.ActiveSheet.RowCount++;

                    spdOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value = dt.Rows[iRow]["ORDER_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdOrder);

                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        #endregion






    }
}
