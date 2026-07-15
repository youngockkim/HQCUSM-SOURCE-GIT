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
using System.Collections;
using BOI.OIFrx;

namespace BOI.INVCus
{

    #region Enum

    public enum ColOutResourceList
    {
        SELECT = 0,
        TANK_ID,
        TANK_NAME,
        WEIGHT_TANK,
        OPER,
        OPER_DESC,
        DEFAULT_TANK,
        CONFIRM_FLAG,
        IUD_FALG
    }

    #endregion


    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmINVEmptyTankPopup : frmPopupBase
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

        public string ReturnValue;

        public List<string> ReturnDatas;

        public List<List<string>> ReturnList;

        private string inOutFlag;

        public string InOutFlag
        {
            get { return inOutFlag; }
            set { inOutFlag = value; }
        }

        private string invReqNo;

        public string InvReqNo
        {
            get { return invReqNo; }
            set { invReqNo = value; }
        }

        private int invReqSeq;

        public int InvReqSeq
        {
            get { return invReqSeq; }
            set { invReqSeq = value; }
        }

        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        private double weightTank;

        public double WeightTank
        {
            get { return weightTank; }
            set { weightTank = value; }
        }

        private double weightReal;

        public double WeightReal
        {
            get { return weightReal; }
            set { weightReal = value; }
        }

        #endregion

        #region Constructor

        public frmINVEmptyTankPopup()
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
            //lblPopupTitle.Text = MPCF.FindLanguage(this.Title);

            MPCF.ClearList(spdCarResList);

            // Return Data 초기화
            ReturnDatas = new List<string>();

            // ReturnList Data 초기화
            ReturnList = new List<List<string>>();

            ViewResourceList();

            InvisibleColumn();
            
            // Caption 변경
            MPCF.ConvertCaption(this);

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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ToDbl(numRemainQty.Value) > 0.0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(473), MessageBoxButtons.OK, MSG_LEVEL.ERROR, "", true);
                    return;
                }
                else if (MPCF.ToDbl(numWhtQty.Value) < MPCF.ToDbl(numInQty.Value))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(431), MessageBoxButtons.OK, MSG_LEVEL.ERROR, "", true);
                    return;
                }

                double dsumWeightTank = 0.0d;
                if (UpdateWeightRawmilk() == true)
                {
                    for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                    {
                        dsumWeightTank += MPCF.ToDbl(spdCarResList.Sheets[0].GetValue(i, (int)ColOutResourceList.WEIGHT_TANK));
                    }
                    this.weightTank = dsumWeightTank;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }



        private void spdCarResList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //double temp = MPCF.ToDbl(spdCarResList.Sheets[0].Cells[i, j].Value);
                if (MPCF.ToChar(spdCarResList.Sheets[0].Cells[e.Row, (int)ColResourceList.CONFIRM_FLAG].Value) == 'Y')
                {
                    MPCF.ShowMessage(MPCF.GetMessage(433), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (e.Row > -1)
                {
                    spdCarResList.Sheets[0].Columns[(int)ColOutResourceList.SELECT].Locked = false;
                    if (spdCarResList.Sheets[0].GetValue(e.Row, (int)ColOutResourceList.SELECT) == null ||
                        (bool)spdCarResList.Sheets[0].GetValue(e.Row, (int)ColOutResourceList.SELECT) == false)
                    {
                        spdCarResList.Sheets[0].SetValue(e.Row, (int)ColOutResourceList.SELECT, true);
                    }
                    else
                    {
                        if (e.Column != (int)ColOutResourceList.WEIGHT_TANK)
                        {
                            spdCarResList.Sheets[0].SetValue(e.Row, (int)ColOutResourceList.SELECT, false);
                        }
                    }
                    spdCarResList.Sheets[0].Columns[(int)ColOutResourceList.SELECT].Locked = true;

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }



        #endregion

        #region Function

        private bool ViewResourceList()
        {
            TRSNode in_node = new TRSNode("View_Resource_List_In");


            TRSNode out_node;
            ArrayList lisHist = new ArrayList();
            int iResourceCount = 0;

            try
            {
                MPCF.ClearList(this.spdCarResList);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("INV_REQ_NO", invReqNo);
                in_node.AddInt("INV_REQ_SEQ", InvReqSeq);
                in_node.AddString("TABLE_NAME", BIGC.B_GCM_B_DAIRY_INPUT_RES);
                in_node.AddString("KEY_1", material);
                in_node.AddString("KEY_2", MPGV.gsUserTeam);
                //in_node.AddString("NEXT_RES_ID", "");                
                do
                {
                    out_node = new TRSNode("View_Resource_List_Out");

                    if (MPCF.CallService("BINV", "BINV_View_Rawmilk_Tank_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);


                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

                int iRow = 0;
                foreach (object obj in lisHist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    //spdHistory.ActiveSheet.RowCount = out_node.GetList(0).Count;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdCarResList.Sheets[0].Rows.Count;
                        spdCarResList.Sheets[0].RowCount++;

                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.TANK_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.TANK_NAME].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.CONFIRM_FLAG].Value = out_node.GetList(0)[i].GetString("CMF_1");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.OPER].Value = out_node.GetList(0)[i].GetString("DATA_2");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.OPER_DESC].Value = out_node.GetList(0)[i].GetString("OPER_DESC");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.DEFAULT_TANK].Value = out_node.GetList(0)[i].GetString("DATA_1");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.WEIGHT_TANK].Value = out_node.GetList(0)[i].GetDouble("WEIGHT_REAL");
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.IUD_FALG].Value = out_node.GetList(0)[i].GetChar("IUD_FLAG");

                        iResourceCount++;
                    }
                }

                // WEIGHT REAL
                numWhtQty.Value = MPCF.ToDbl(weightReal);
                numInQty.Value = MPCF.ToDbl(out_node.GetDouble("WEIGHT_REAL_TOTAL"));
                // REMAIN QTY
                numRemainQty.Value = MPCF.ToDbl(weightReal) - MPCF.ToDbl(out_node.GetDouble("WEIGHT_REAL_TOTAL"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }


        private bool SetAuto()
        {
            int iActiveRow = 0;
            double dSumQty = 0.0;
            try
            {
                //double dsumWeightTank = 0.0d;
                //int i_default_row =0;
                //for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                //{
                //    dsumWeightTank += MPCF.ToDbl(spdCarResList.Sheets[0].GetValue(i, (int)ColResourceList.WEIGHT_TANK));
                //    if (MPCF.ToChar(spdCarResList.Sheets[0].GetValue(i, (int)ColResourceList.DEFAULT_TANK)) == 'Y') {
                //        i_default_row = i;
                //    }
                //}

                //if (dsumWeightTank <= 0.0) {
                //    spdCarResList.Sheets[0].SetValue(i_default_row, (int)ColResourceList.WEIGHT_TANK, weightReal);
                //}

                //TRSNode in_node = new TRSNode("View_Resource_List_In");
                //TRSNode out_node;

                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '2';
                //in_node.AddString("INV_REQ_NO", invReqNo);
                //in_node.AddInt("INV_REQ_SEQ", InvReqSeq);
                //in_node.AddString("TABLE_NAME", BIGC.B_GCM_B_DAIRY_INPUT_RES);
                //in_node.AddString("KEY_1", material);
                //in_node.AddString("KEY_2", MPGV.gsUserTeam);
                ////in_node.AddString("NEXT_RES_ID", "");                
                //do
                //{
                //    out_node = new TRSNode("View_Resource_List_Out");

                //    if (MPCF.CallService("BINV", "BINV_View_Rawmilk_Tank_List", in_node, ref out_node) == false)
                //    {
                //        return false;
                //    }

                //    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                //    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                //    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                //} while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

                //if (MPCF.ToDbl(out_node.GetDouble("WEIGHT_REAL_TOTAL")) <= 0.0)
                //{
                //    for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                //    {
                //        if (MPCF.ToChar(spdCarResList.Sheets[0].GetValue(i, (int)ColResourceList.DEFAULT_TANK)) == 'Y')
                //        {
                //            spdCarResList.Sheets[0].SetValue(i, (int)ColResourceList.WEIGHT_TANK, weightReal);
                //        }
                //        else
                //        {
                //            spdCarResList.Sheets[0].SetValue(i, (int)ColResourceList.WEIGHT_TANK, 0);
                //        }
                //    }
                //    numRemainQty.Value = 0.0;
                //    numInQty.Value = weightReal;
                //}

                iActiveRow = spdCarResList.Sheets[0].ActiveRowIndex;
                if (iActiveRow < 0)  //선택된 항목이 없을때 예외처리.
                {
                    return false;
                }

                if (MPCF.ToDbl(numRemainQty.Value) <= 0.0) // 남은수량이 0이하일때 에러처리
                {
                    return false;
                }

                spdCarResList.Sheets[0].SetValue(iActiveRow, (int)ColResourceList.WEIGHT_TANK, numRemainQty.Value);

                for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                {
                    dSumQty += MPCF.ToDbl(spdCarResList.Sheets[0].GetValue(i, (int)ColResourceList.WEIGHT_TANK));
                }

                numInQty.Value = dSumQty;
                numRemainQty.Value = MPCF.ToDbl(numWhtQty.Value) - dSumQty;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdateWeightRawmilk()
        {
            TRSNode in_node = new TRSNode("UPDATE_RAWMILK_TANK_IN");
            TRSNode out_node = new TRSNode("UPDATE_RAWMILK_TANK_OUT");
            TRSNode tank_list;

            try
            {

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("INV_REQ_NO", MPCF.Trim(invReqNo));
                in_node.AddInt("INV_REQ_SEQ", InvReqSeq);
                in_node.AddDouble("WEIGHT_MEASURE", weightReal);

                for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                {
                    if (MPCF.ToDbl(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.WEIGHT_TANK].Value) > 0 ||
                        (MPCF.ToDbl(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.WEIGHT_TANK].Value) == 0 &&
                        MPCF.ToChar(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.IUD_FALG].Value) == 'U'))
                    {

                        tank_list = in_node.AddNode("TANK_LIST");
                        MPCF.SetInMsg(tank_list);
                        if (MPCF.ToDbl(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.WEIGHT_TANK].Value) == 0 &&
                        MPCF.ToChar(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.IUD_FALG].Value) == 'U')
                        {
                            tank_list.ProcStep = 'D';
                        }
                        else
                        {
                            tank_list.ProcStep = MPCF.ToChar(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.IUD_FALG].Value);
                        }
                        tank_list.AddString("INV_REQ_NO", MPCF.Trim(invReqNo));
                        tank_list.AddInt("INV_REQ_SEQ", MPCF.ToInt(invReqSeq));
                        tank_list.AddString("RES_ID", MPCF.Trim(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.TANK_ID].Value));
                        tank_list.AddString("RESG_ID", MPCF.Trim(""));
                        tank_list.AddString("WEIGHT_DATE", MPCF.Trim(""));
                        tank_list.AddDouble("WEIGHT_MEASURE", 0);
                        tank_list.AddDouble("WEIGHT_REAL", MPCF.ToDbl(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.WEIGHT_TANK].Value));
                        tank_list.AddString("CMF_1", MPCF.Trim(""));
                        tank_list.AddString("CMF_2", MPCF.Trim(""));
                        tank_list.AddString("CMF_3", MPCF.Trim(""));
                        tank_list.AddString("CMF_4", MPCF.Trim(""));
                        tank_list.AddString("CMF_5", MPCF.Trim(""));
                        tank_list.AddString("CMF_6", MPCF.Trim(""));
                        tank_list.AddString("CMF_7", MPCF.Trim(""));
                        tank_list.AddString("CMF_8", MPCF.Trim(""));
                        tank_list.AddString("CMF_9", MPCF.Trim(""));
                        tank_list.AddString("CMF_10", MPCF.Trim(""));
                        in_node.AddString("CREATE_OPER", MPCF.Trim(spdCarResList.Sheets[0].Cells[i, (int)ColOutResourceList.OPER].Value));
                    }
                }
                if (MPCF.CallService("BINV", "BINV_Tran_Rawmilk_In_Out", in_node, ref out_node) == false)
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


        private void InvisibleColumn()
        {
            spdCarResList.Sheets[0].Columns[(int)ColOutResourceList.SELECT].Visible = false;
            spdCarResList.Sheets[0].Columns[(int)ColOutResourceList.IUD_FALG].Visible = false;


        }
        #endregion

        private void spdCarResList_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    //int i = e.Row;
                    //int j = e.Column;



                    double dsumWeightTank = 0.0d;

                    for (int i = 0; i < spdCarResList.Sheets[0].RowCount; i++)
                    {
                        dsumWeightTank += MPCF.ToDbl(spdCarResList.Sheets[0].GetValue(i, (int)ColOutResourceList.WEIGHT_TANK));
                    }
                    numInQty.Value = dsumWeightTank;
                    numRemainQty.Value = weightReal - dsumWeightTank;

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }


        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetAuto() == true)
                {

                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }


    }
}
