//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranFQCProcess.cs
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
    public partial class frmCUSTranFQCProcess : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranFQCProcess()
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
                    txtLotID.Text = node.GetString("LOT_ID");

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

        private void frmCUSTranFQCProcess_FormClosing(object sender, FormClosingEventArgs e)
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
                    txtLotID.Text = string.Empty;
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
        private bool Tran_Process(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                if(rdbOK.Checked)
                {
                    in_node.AddString("RESULT", rdbOK.Text);   
                }
                else
                {
                    in_node.AddString("RESULT", rdbNG.Text);
                }

                //in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Tag));
                //in_node.AddString("RESULT", MPCF.Trim(cdvJudgment.Tag));

                if (MPCF.CallService("CUS", "CWIP_Tran_FQC_Process", in_node, ref out_node) == false)
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

        private void frmCUSTranFQCProcess_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

            if (BIGV.gbTunePublish == true)
            {
                InitH101Tuner();
            }

            MPCF.ClearList(spdLotInfo);

            rdbOK.Text = "OK";
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
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

            //if (cdvGrade.Text == "")
            //{
            //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
            //    cdvGrade.Focus();
            //    return;
            //}

            //if (cdvJudgment.Text == "")
            //{
            //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
            //    cdvJudgment.Focus();
            //    return;
            //}

            if (Tran_Process(txtLotID.Text) == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }

            txtLotID.Text = "";
            cdvGrade.Text = "";
            cdvJudgment.Text = "";
            MPCF.SetFocus(txtLotID);
        }

        private void cdvJudgment_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                //ClearData("1");

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "OKNG";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1" };

                // Show
                cdvJudgment.Text = cdvJudgment.Show(cdvJudgment, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "KEY_1", -1);

                if (MPCF.Trim(cdvJudgment.Text) != "")
                {
                    if (cdvJudgment.returnDatas != null && cdvJudgment.returnDatas.Count > 0)
                    {
                        cdvJudgment.Tag = cdvJudgment.returnDatas[0];
                    }
                }
                else
                {
                    cdvJudgment.Tag = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                //ClearData("1");

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@FQC_GRADE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvGrade.Text = cdvGrade.Show(cdvGrade, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvGrade.Text) != "")
                {
                    if (cdvGrade.returnDatas != null && cdvGrade.returnDatas.Count > 0)
                    {
                        cdvGrade.Tag = cdvGrade.returnDatas[0];
                    }
                }
                else
                {
                    cdvGrade.Tag = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
