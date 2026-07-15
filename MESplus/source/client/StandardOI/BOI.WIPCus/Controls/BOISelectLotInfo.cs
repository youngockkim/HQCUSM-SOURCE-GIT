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
    public partial class BOISelectLotInfo : UserControl
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

        private char _matBomType = ' ';

        public char MatBomType
        {
            get { return _matBomType; }
            set { _matBomType = value; }
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
        public delegate void LotButtonClickHandler(object sender, LotButtonClickEventArgs e);
        public event LotButtonClickHandler LotButtonClick;

        #endregion

        #region Constructor

        public BOISelectLotInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        private void BOISelectLotInfo_Load(object sender, EventArgs e)
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

        private void btnViewLot_Click(object sender, EventArgs e)
        {
            frmWIPViewLotList frm = new frmWIPViewLotList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                View_Lot_Info(frm.LotId);
                if (LotButtonClick != null)
                {
                    OnLotButtonClick(sender, new LotButtonClickEventArgs());
                }
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
                spdLotInfo_Sheet1.RowCount = 0;
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
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.LOT_QTY].Value = out_node.GetDouble("QTY_1");
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.INSPECTION_FLAG].Value = out_node.GetString("LOT_CMF_13"); //INSPECTION_FLAG               
                spdLotInfo_Sheet1.Cells[0, (int)BIGC.LOT.MAT_BOM_TYPE].Value = out_node.GetChar("MAT_BOM_TYPE"); //INSPECTION_FLAG               

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

        private void OnLotButtonClick(object sender, LotButtonClickEventArgs e)
        {
            if (LotButtonClick != null)
            {
                e.OrderId = MPCF.Trim(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.ORDER_ID));
                e.LotId = MPCF.Trim(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.LOT_ID));
                e.MatId = MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.MAT_ID));
                e.LineId = MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.LINE_ID));
                e.Oper = MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.OPER));
                e.ResId = MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.RES_ID));
                e.Flow = MPCF.Trim(spdLotInfo_Sheet1.GetTag(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.FLOW));
                e.MatBomType = MPCF.ToChar(spdLotInfo_Sheet1.GetValue(spdLotInfo_Sheet1.ActiveRowIndex, (int)BIGC.LOT.MAT_BOM_TYPE)); 
                LotButtonClick(this, e);
            }
        }

        #endregion

        
    }

    public class LotButtonClickEventArgs
    {
        private string _orderId = string.Empty;

        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private string _lotId = string.Empty;

        public string LotId
        {
            get { return _lotId; }
            set { _lotId = value; }
        }

        private string _matId = string.Empty;

        public string MatId
        {
            get { return _matId; }
            set { _matId = value; }
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

        private string _flow = string.Empty;

        public string Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }

        private char _matBomType = ' ';

        public char MatBomType
        {
            get { return _matBomType; }
            set { _matBomType = value; }
        }



        public LotButtonClickEventArgs()
        {            
            
        }


    }
}
