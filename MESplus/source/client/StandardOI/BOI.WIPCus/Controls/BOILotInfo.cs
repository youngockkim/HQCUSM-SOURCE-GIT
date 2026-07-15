using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace BOI.WIPCus.Controls
{
    public partial class BOILotInfo : UserControl
    {
        #region Property

        public string OrderId
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.ORDER_ID));
            }
        }

        public double OrderQty
        {
            get
            {
                return MPCF.ToDbl(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.ORDER_QTY));
            }
        }

        public string LotId
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.LOT_ID));
            }
        }

        public string MatId
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.MAT_ID));
            }

        }

        public string Flow
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.FLOW));
            }

        }

        public string Oper
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.OPER));
            }

        }


        public string ResId
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.RES_ID));
            }
        }

        public double LotQty
        {
            get
            {
                return MPCF.ToDbl(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.LOT_QTY));
            }
        }

        public string InspectionFlag
        {
            get
            {
                return MPCF.Trim(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.INSPECTION_FLAG));
            }
        }

        private List<int> visibleColums;
        public List<int> VisibleColums
        {
            get
            {
                return visibleColums;
            }
            set
            {                
                visibleColums = value;                                                       
            }
        }

        #endregion

        #region Constructor

        public BOILotInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        private void BOILotInfo_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdLotInfo);

                InvisibleColumn();
                VisibleColumn();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        public void View_Lot_Info(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCF.ClearList(spdLotInfo);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotId);

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return;
                }

                spdLotInfo_Sheet1.RowCount++;

                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.FACTORY].Value = out_node.GetString("FACTORY");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.ORDER_ID].Value = out_node.GetString("ORDER_ID");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.ORDER_QTY].Value = out_node.GetDouble("ORD_QTY");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.LOT_ID].Value = out_node.GetString("LOT_ID");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.LOT_QTY].Value = out_node.GetDouble("QTY_1");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.MAT_ID].Value = out_node.GetString("MAT_DESC");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.MAT_ID].Tag = out_node.GetString("MAT_ID");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.LINE_ID].Value = out_node.GetString("LINE_DESC");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.LINE_ID].Tag = out_node.GetString("LOT_CMF_4"); //LINE_ID
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.FLOW].Value = out_node.GetString("FLOW_DESC");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.FLOW].Tag = out_node.GetString("FLOW");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.OPER].Value = out_node.GetString("OPER_DESC");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.OPER].Tag = out_node.GetString("OPER");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.RES_ID].Value = out_node.GetString("RES_DESC");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.RES_ID].Tag = out_node.GetString("RES_ID");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.INSPECTION_FLAG].Value = out_node.GetString("LOT_CMF_13"); //INSPECTION_FLAG               

                //MPCF.FitColumnHeader(spdLotInfo);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            return;
        }

        private void InvisibleColumn()
        {
            try
            {
                spdLotInfo_Sheet1.Columns[(int)BIGC.LOT.FACTORY].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        public void VisibleColumn()
        {
            try
            {
                if (visibleColums != null)
                {
                    foreach (int i in visibleColums)
                    {
                        spdLotInfo_Sheet1.Columns[i].Visible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion
    }
}
