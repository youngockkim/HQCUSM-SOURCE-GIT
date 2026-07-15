//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranLabelIDMatching.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-08-09 : Created by bkwoo
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranLabelIDMatching : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranLabelIDMatching()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        private enum LOT_COL : int
        {
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            OPER,
            OPER_DESC,
            ORDER_ID,
            LABEL_TYPE,
            STARTUS,
            LAST_TRAN_TIME
        }

        private enum LOT_LIST : int
        {
            SEQ,
            LOT_ID,
            PROD_LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1
        }

        #endregion

        #region [Variable Definition]

        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private bool bIsShown = false;

        #endregion

        #region H101 Module

        private H101Tuner h101tuner = new H101Tuner();
        private delegate void H101DataReceived(TRSNode node);
        private H101DataReceived h101DataRecevied;

        private void h101tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            IAsyncResult r = BeginInvoke(h101DataRecevied, e.Node);
            EndInvoke(r);
        }

        private void OnH101DataReceived(TRSNode node)
        {
            try
            {
                if (node.GetString("_SERVICE_NAME") == "CUS_Proc_Lot_tcp")
                {
                    txtLabelID.Text = node.GetString("LOT_ID");

                    //시작 진행 LOT 리스트에 추가
                    spdLotInfo.ActiveSheet.AddRows(0, 1);
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = node.GetString("LOT_ID");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = node.GetString("MAT_ID");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = node.GetString("MAT_SHORT_DESC");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = node.GetDouble("QTY_1").ToString();
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = node.GetString("UNIT_1");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = node.GetString("OPER");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = node.GetString("OPER_DESC");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = node.GetString("ORDER_ID");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = node.GetString("LOT_STATUS");
                    spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(node.GetString("LAST_TRAN_TIME"));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        private void frmCUSTranLabelIDMatching_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (h101tuner.isTuned == true)
            {
                h101tuner.PublishCUSMsgUnTune();
                h101tuner.Dispose();
            }
        }

        private void InitH101Tuner()
        {
            try
            {
                if (h101tuner.isTuned == true)
                {
                    return;
                }

                string module = string.Empty;
                string channel = string.Empty;

                channel = BIGV.gsResId;

                h101DataRecevied += new H101DataReceived(OnH101DataReceived);
                h101tuner.DataReceived += new H101DataReceivedEventHandler(h101tuner_DataReceived);
                h101tuner.Module = "SOL";
                h101tuner.Channel = channel;
                h101tuner.MultiCast = true;
                h101tuner.UseRandomChannel = false;
                h101tuner.PublishCUSMsgTune();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        #endregion

        #region [FormDefinition]


        #endregion

        #region [Function Definition]

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdLotInfo);
                    MPCF.ClearList(spdLotList);
                    txtLabelID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Matching_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("LABEL_ID", MPCF.Trim(txtLabelID.Text));

                if (MPCF.CallService("CUS", "CWIP_Tran_Label_Matching", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                if (spdLotList.ActiveSheet.RowCount > 200) MPCF.ClearList(spdLotList);

                //종료 진행 LOT 리스트에 추가
                spdLotList.ActiveSheet.AddRows(0, 1);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.SEQ].Text = MPCF.Trim(spdLotList.ActiveSheet.RowCount);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LOT_ID].Text = out_node.GetString("LOT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PROD_LOT_ID].Text = out_node.GetString("PROD_LOT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Text = out_node.GetString("MAT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Text = out_node.GetString("MAT_SHORT_DESC");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.QTY_1].Text = out_node.GetDouble("QTY_1").ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.UNIT_1].Text = out_node.GetString("UNIT_1");

                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLotInfo(string sLotID)
        {
            try
            {
                MPCF.ClearList(spdLotInfo);

                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));                

                if (MPCF.CallService("CUS", "CUS_View_Lot", in_node, ref out_node) == false)
                    return false;

                spdLotInfo.ActiveSheet.AddRows(0, 1);
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = out_node.GetString("LOT_ID");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = out_node.GetString("MAT_ID");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = out_node.GetString("MAT_SHORT_DESC");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = out_node.GetDouble("QTY_1").ToString();
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = out_node.GetString("UNIT_1");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = out_node.GetString("OPER");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = out_node.GetString("OPER_DESC");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = out_node.GetString("ORDER_ID");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.LABEL_TYPE].Text = out_node.GetString("LABEL_TYPE");                
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = out_node.GetString("LOT_STATUS");
                spdLotInfo.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));

                MPCF.FitColumnHeader(spdLotInfo);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranLabelIDMatching_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

            if (BIGV.gbTunePublish == true)
            {
                InitH101Tuner();
            }

            MPCF.ClearList(spdLotInfo);
            MPCF.ClearList(spdLotList);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }

                    txtLabelID.Text = "";
                    txtLabelID.Focus();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtLabelID.Text = string.Empty;
            txtLotID.Text = string.Empty;
            MPCF.SetFocus(txtLotID);
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if (txtLabelID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLabelID.Focus();
                return;
            }

            if (Tran_Matching_Lot(txtLotID.Text) == false)
            {
                MPCF.SetFocus(txtLabelID);
                return;
            }
                        
            txtLotID.Text = "";
            txtLabelID.Text = "";
            MPCF.SetFocus(txtLotID);
        }

        private void txtLabelID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    txtLabelID.Text = MPCF.ToUpper(txtLabelID.Text); // 일괄 대문자

                    if (txtLotID.Text == "")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                        txtLotID.Focus();
                        return;
                    }

                    if (txtLabelID.Text == "")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                        txtLabelID.Focus();
                        return;
                    }

                    if (Tran_Matching_Lot(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLabelID);
                        return;
                    }

                    txtLotID.Text = "";
                    txtLabelID.Text = "";
                    txtLotID.Focus();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSTranLabelIDMatching_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

    }
}
