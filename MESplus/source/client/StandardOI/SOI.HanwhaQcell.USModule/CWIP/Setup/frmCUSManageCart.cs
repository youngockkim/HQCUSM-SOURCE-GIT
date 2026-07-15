using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;

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
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button\

    public partial class frmCUSManageCart : SOIBaseForm02
    {
        #region Property

        const int ENTER = 13;
        string sBoxID = string.Empty;

        // RFID Property
        clsCustomBaseTcpComm _tcpComm = new clsCustomBaseTcpComm();
        CONNECTED_STATUS _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
        string _ip = "192.168.0.79";
        string _portNo = "33000";
        byte[] _receiveByte = new byte[1024];
        byte[] _receiveByteTemp = new byte[1024];
        RFID_Antena _readAntena = RFID_Antena.IO_1;
        RFID_Antena _writeAntena = RFID_Antena.IO_1;
        // RFID Property

        #endregion

        #region Constructor

        public frmCUSManageCart()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            LACK_ID,
            PACK_ID,
            CELL_BOX_ID,
            PACK_QTY
        }

        #endregion

        #region [Variable Definition]

        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        public frmCWIPFullcellCartLabelPopup frmCWIPFullcellCartLabelPopup;
        public string p_order_id;
        public string p_lack_id;

        public enum RFID_Antena
        {
            IO_1 = 1
        }

        #endregion

        #region Event Handler

        private void frmCUSManageCart_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLotList);
            SetupPrtOpt();
        }


        private void txtLackID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLackID.Text) != "")
                {
                    txtLackID.Text = MPCF.ToUpper(txtLackID.Text); // 일괄 대문자

                    if (e.KeyChar == (char)13)
                    {

                        MPCF.ClearList(spdLotList);

                        if (ViewLackInfo(txtLackID.Text) != false)
                        {
                            if (ViewPackLotList(txtLackID.Text) != false)
                            {

                            }
                            else
                            {
                                txtLackID.Focus();
                                txtLackID.SelectAll();
                                return;
                            }
                        }
                        else
                        {
                            txtLackID.Focus();
                            txtLackID.SelectAll();
                            return;
                        }
                        /*
                        if (ViewLackInfo(txtLackID.Text) != false)
                        {
                            //ViewPackLotList(txtPackID.Text);
                        }
                        */

                        p_lack_id = txtLackID.Text; // 캐리어 정보 담아두기
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }


        private void txtLackID_Click(object sender, EventArgs e)
        {
            try
            {
                txtLackID.Focus();
                txtLackID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("CLEAR"))
                    return;
                if (Clear_Cart() != false)
                {
                    ClearData("1");
                    txtCellBoxID1.Text = string.Empty;
                    //txtCellBoxID2.Text = string.Empty;
                    MPCF.SetFocus(txtCellBoxID1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("CANCEL"))
                return;
            if (Detach_Lot() != false)
            {
                ClearData("1");

                txtCellBoxID1.Focus();
                txtCellBoxID1.SelectAll();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Terminalize();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("CLEAR"))
                return;
            if (Clear_Cart() != false)
            {
                ClearData("1");
                txtLackID.Focus();
                txtLackID.SelectAll();
            }
        }


        private void txtCellBoxID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string sCellBoxID = string.Empty;

                if (e.KeyChar == (char)13)
                {

                    MPCF.ClearList(spdLotList);

                    if (!CheckCondition("VIEW2"))
                        return;

                    if (txtCellBoxID1.Text.Length <= 12)
                    {
                        sCellBoxID = txtCellBoxID1.Text;
                    }
                    else
                    {
                        sCellBoxID = txtCellBoxID1.Text.Substring(0, 12);
                    }

                    if (ViewPackLot_2(sCellBoxID) != false)
                    {

                    }
                    else
                    {
                        txtCellBoxID1.Focus();
                        txtCellBoxID1.SelectAll();
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }
        
        private void frmCUSManageCart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminalize();
        }

        private void soiButton2_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            //            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion

        #region Function
        
        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdLotList);
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW1":


                        break;

                    case "VIEW2":

                        if (string.IsNullOrEmpty(txtCellBoxID1.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(506));
                            MPCF.SetFocus(txtCellBoxID1);
                            return false;
                        }


                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (txtCellBoxID1.Text.Substring(0, 12) == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.CELL_BOX_ID].Text)
                            {
                                //MPCF.ShowMessage(MPCF.GetMessage(501), MSG_LEVEL.ERROR, false);
                                MPCF.ShowMsgBox(MPCF.GetMessage(501));
                                txtCellBoxID1.Text = "";
                                MPCF.SetFocus(txtCellBoxID1);
                                return false;
                            }
                        }

                        break;

                    case "VIEW3":


                        break;

                    case "CLEAR":

                        if (string.IsNullOrEmpty(txtLackID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(533));
                            MPCF.SetFocus(txtLackID);
                            return false;
                        }
                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtLackID);
                            return false;
                        }
                        break;

                    case "CANCEL":

                        if (string.IsNullOrEmpty(txtCellBoxID1.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(501));
                            MPCF.SetFocus(txtCellBoxID1);
                            return false;
                        }
                        if (spdLotList.ActiveSheet.RowCount != 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(txtCellBoxID1);
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

        private bool Clear_Cart()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LACK_ID", MPCF.Trim(txtLackID.Text));
                in_node.AddChar("PACK_TYPE", 'F');               // PACK TYPE
                in_node.AddString("USER_ID", MPGV.gsUserID);

                if (MPCF.ShowMsgBox(MPCF.GetMessage(542), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Cart", in_node, ref out_node) == false)
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

        private bool Detach_Lot()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("CELL_BOX_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Text));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.ShowMsgBox(MPCF.GetMessage(543), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Cart", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(556), MSG_LEVEL.ERROR, false);
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

        private bool ViewPackLotList(string sCartID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;

            ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // View Lot for Validation
                //ViewPackLot(sLotID);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.CallService("CRPT", "CRPT_View_Manage_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value = out_list.GetString("CARRIER_ID"); // Cart
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Value = out_list.GetString("MAGAZINE"); // Magazine
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Value = out_list.GetString("SMALLBOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_QTY].Value = out_list.GetInt("CNT");

                }

                txtLoadCount.Text = (out_node.GetList(0).Count).ToString();


                MPCF.FitColumnHeader(spdLotList);

                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewPackLot_2(string sCellBoxID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");

            ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // View Lot for Validation
                //ViewPackLot(sLotID);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("CELL_BOX_ID", MPCF.Trim(sCellBoxID));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.CallService("CRPT", "CRPT_View_Manage_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                spdLotList.ActiveSheet.RowCount++;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = out_node.GetString("CARRIER_ID"); // Cart
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = out_node.GetString("MAGAZINE"); // Magazine
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Value = out_node.GetString("SMALLBOX_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = out_node.GetInt("CNT");

                MPCF.FitColumnHeader(spdLotList);

                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLackInfo(string sLotID)
        {
            try {
                TRSNode in_node = new TRSNode("VIEW_CRR_IN");
                TRSNode out_node = new TRSNode("VIEW_CRR_OUT");

                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("CRR_ID", sLotID);

                    if (MPCF.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                    {
                        if (out_node.GetList(0) == null)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(538), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        return false;
                    }

                    //txtLoadCount.Text = out_node.GetInt("USAGE_COUNT").ToString();
                    txtLimitCount.Text = out_node.GetInt("CRR_SIZE").ToString();
                                   
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewPackLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_PACK_IN");
            TRSNode out_node = new TRSNode("VIEW_PACK_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LACK_ID", sLotId);

                if (MPCF.CallService("CUS", "CWIP_View_Pack_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool AddItems(string sLotID)
        {
            try
            {
                int iRow = 0;
                TRSNode in_node = new TRSNode("VIEW_PACK_IN");
                TRSNode out_node = new TRSNode("VIEW_PACK_OUT");


                // sLotID Validation Check
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", sLotID);
                //in_node.AddString("ORDER_ID", cdvOrderNo.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Fullcell_Lot_Validation", in_node, ref out_node) == false)
                {
                    return false;                      
                }

                double cellboxPower = 0;
                string cellboxGrade = string.Empty;
                double orderPower = 0;
                string orderGrade = string.Empty;
                
                cellboxPower = Convert.ToDouble(out_node.GetString("EFFICIENCY"));
                cellboxPower = cellboxPower / 100;
                cellboxGrade = out_node.GetString("GRADE");
                orderPower = Convert.ToDouble(out_node.GetString("POWERGRADE"));
                orderGrade = out_node.GetString("QUALITYGRADE");

                string.Format("##.##", cellboxPower);
                string.Format("##.##", orderPower);

                if (cellboxPower == 0 || cellboxGrade == "" || orderPower == 0 || orderGrade == "")
                {
                    return false;
                }

                /*
                if (cellboxPower.Equals(orderPower) == false || cellboxGrade.Equals(orderGrade) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(514));
                    return false;
                }
                */


                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        public IORESULT Initialize()
        {
            IORESULT result = IORESULT.SUCCEEDED;
            _tcpComm.CONNECTEDSTATUS += new clsCustomBaseTcpComm.degCONNECTEDSTATUS(ConnectedStatusEvent);

            _ip = "192.168.0.79";
            _portNo = "33000";
            _readAntena = (RFID_Antena)ushort.Parse("1");
            _writeAntena = (RFID_Antena)ushort.Parse("1");
            _tcpComm.IsLog = false;
            _tcpComm.IsReceiveString = true;
            result = _tcpComm.Initialize(_ip, _portNo, SERVER_CLIENT.Client, 10000);//setting[0] : ip, setting[1] : port

            if (result != IORESULT.SUCCEEDED)
            {
                Console.WriteLine(string.Format("Failed Open : {0}", _ip));
                //btnRFID.Text = "RFID(Off)";
                return IORESULT.FAILED;
            }
            //btnRFID.Text = "RFID(On)";
            return IORESULT.SUCCEEDED;
        }

        public IORESULT Terminalize()
        {
            IORESULT result = IORESULT.SUCCEEDED;

            result = _tcpComm.DeInitialize();

            if (result != IORESULT.SUCCEEDED)
            {
                Console.WriteLine(string.Format("Failed Close"));
                return IORESULT.FAILED;
            }
            //btnRFID.Text = "RFID(Off)";
            return result;
        }

        public void ConnectedStatusEvent(CONNECTED_STATUS connectedStatus)
        {
            _connectedStatus = connectedStatus;
            Console.WriteLine("{0} : ConnectedStatusEvent  = {1}", _ip, _connectedStatus.ToString());

            if (_connectedStatus == CONNECTED_STATUS.CONNECTED)
            {
                _tcpComm.ReceiveAllClear();
            }
        }

        public string ReadRfid()
        {
            string result = string.Empty;
            IORESULT ioResult = IORESULT.SUCCEEDED;
            lock (this)
            {
                string receive = string.Empty;
                string strCmd = string.Empty;
                int startAddress = 0;
                int length = 14;
                RFID_Antena enAntena = RFID_Antena.IO_1;
                _tcpComm.ReceiveAllClear();

                enAntena = (RFID_Antena)ushort.Parse("1");

                if (enAntena == RFID_Antena.IO_1)
                    enAntena = _readAntena;
                else if (enAntena == RFID_Antena.IO_1)
                    enAntena = _writeAntena;

                startAddress = 0;
                length = 14;
                strCmd = string.Format("RD_{0:00}_{1:00000}_{2:0000}\r\n", (ushort)enAntena, startAddress, length);
                byte[] command = Encoding.ASCII.GetBytes(strCmd);
                ioResult = _tcpComm.Send(command,10);
                if (ioResult == IORESULT.SUCCEEDED)
                {
                    string rfid_magazine_id = string.Empty;
                    ioResult = _tcpComm.Receive(ref rfid_magazine_id, 13, 1);

                    if (ioResult == IORESULT.SUCCEEDED)
                    {
                        result = rfid_magazine_id.Substring(20, 14);
                        //btnRFID.Text = "RFID(On)";
                    }
                }
                else
                {
                    //btnRFID.Text = "RFID(Off)";
                }
            }
            return result;
        }
        private void txtCellBoxID1_Click(object sender, EventArgs e)
        {
            try
            {
                txtCellBoxID1.Focus();
                txtCellBoxID1.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        

    }
}