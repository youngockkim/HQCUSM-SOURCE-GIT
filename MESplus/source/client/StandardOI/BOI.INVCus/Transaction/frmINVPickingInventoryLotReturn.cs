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
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
using SOI.MsgHandlerH101;
using SOI.DNM;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVPickingInventoryLotReturn : BOIBaseForm02
    {
        #region Enum

        public enum ColReqMst
        {
            MOVE_REQ_NO = 0,
            MOVE_DATE,
            FROM_STORE,
            TO_STORE,
            REASON,
            STATUS
        }

        public enum ColReqDtl
        {
            MATERIAL = 0,
            MATERIAL_DESC,
            WEIGHT_PINKING,
            UNIT
        }

        public enum ColReqLot
        {
            SELECT = 0,
            LOT_ID,
            MATERIAL,
            MATERIAL_DESC,
            QTY,
            UNIT
        }

        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;        

        private cinvReqMstReturn reqMst = null;
        //private List<cinvReqDtlReturn> lisReqDtl = null;
        //private List<cinvReqLotReturn> lisReqLot = null;
        

        #endregion

        #region Constructor

        public frmINVPickingInventoryLotReturn()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                
                InvisibleColumn();
                LockColumn();
                initSpread();

                GetDefaultValueFromReg();

                dtpMoveDate.SetValueAsDateTime(DateTime.Now);

                //tunner = new BOI.OIFrx.BOIControls.H101Tuner("LKH");
                
                

                // (Required) 
                bIsShown = true;
            }
        }
        
        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string slotId = string.Empty;
                string smatId = string.Empty;
                double lotQty = 0.0d;
                string smatDesc = string.Empty;
                string sunit = string.Empty;

                cinvReqDtlReturn reqDtl = null;
                cinvReqLotReturn reqLot = null;
                bool blnextReqDtl = false;
                if (e.KeyValue == (char)13)
                {
                    
                    if (MPCF.CheckValue(cdvFromStore, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cdvToStore, false) == false)
                    {
                        return;
                    }

                    if (MPCF.CheckValue(cdvReasonMove, false) == false)
                    {
                        return;
                    }
                   

                    TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                    TRSNode out_node = new TRSNode("VIEW_LOT_OUT");


                    slotId = MPCF.Trim(txtLotId.Text);

                    for (int i = 0; i < spdReqLotMove.Sheets[0].RowCount; i++)
                    {
                        if (MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(i, (int)ColReqLot.LOT_ID)) == MPCF.Trim(slotId))
                        {
                            //CMN164 ERROR - 이 Lot은 이미 존재 합니다. Lot을 확인 하세요.
                            MPCF.ShowMessage(MPCF.GetMessage(164), MSG_LEVEL.ERROR, true);                            
                            spdReqLotMove.Sheets[0].ActiveRowIndex = i;
                            spdReqLotMove.Sheets[0].SetActiveCell(i, 0, true);
                            return;
                        }
                    }


                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("LOT_ID", slotId);

                    if (MPCF.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                    {
                        return;
                    }
                    if (out_node.GetString("LOT_CMF_11") == "Y")
                    {
                        //CMN379 ERROR - 이 Lot 은 이미 다른 의 요청 에 할당되어 있습니다.
                        MPCF.ShowMessage(MPCF.GetMessage(379), MSG_LEVEL.ERROR, true);
                        return;
                    }
                    if (out_node.GetDouble("QTY_1") <= 0.00d)
                    {
                        //CMN380 CONFIRM - Lot의 Quantity가 0입니다. Lot을 확인하세요.
                        MPCF.ShowMessage(MPCF.GetMessage(380), MSG_LEVEL.ERROR, true);
                        txtLotId.Focus();
                        txtLotId.SelectAll();
                        return;
                    }
                    if (cdvFromStore.Tag.ToString() != out_node.GetString("OPER"))
                    {
                        //CMN412 ERROR - 출발 공정이 대상 LOT 공정과 상이합니다.
                        MPCF.ShowMessage(MPCF.GetMessage(412), MSG_LEVEL.ERROR, true);
                        return;
                    }

                    smatId = MPCF.Trim(out_node.GetString("MAT_ID"));
                    lotQty = MPCF.ToDbl(out_node.GetDouble("QTY_1"));
                    smatDesc = MPCF.Trim(out_node.GetString("MAT_DESC"));
                    sunit = MPCF.Trim(out_node.GetString("UNIT_1"));

                    if (reqMst == null)
                    {
                        reqMst = new cinvReqMstReturn("CINVREQMST_IN");
                        MPCF.SetInMsg(reqMst);
                        reqMst.ProcStep = '1';
                        reqMst.ReqType = MPCF.Trim(BIGC.B_REQ_TYPE_RETURN);
                        reqMst.MoveDate = MPCF.Trim(dtpMoveDate.GetValueAsString(8));
                        reqMst.MoveTime = MPCF.Trim(dtpMoveDate.GetValueAsString(8)) + MPCF.Trim(DateTime.Now.ToString("HHmmss"));
                        reqMst.ReqUserId = MPCF.Trim(reqMst.UserID);
                        reqMst.ReqStatus = 'R';
                        reqMst.FromFactory = MPCF.Trim(MPGV.gsFactory);
                        reqMst.FromStore = MPCF.Trim(cdvFromStore.Tag);
                        reqMst.ToStore = MPCF.Trim(cdvToStore.Tag);
                        reqMst.ReasonDtl = MPCF.Trim(cdvReasonMove.Tag);
                        reqMst.ToFactory = MPCF.Trim(MPGV.gsFactory);

                        reqMst.ReasonDtlDesc = MPCF.Trim(cdvReasonMove.Value);
                        reqMst.FromStoreDesc = MPCF.Trim(cdvFromStore.Value);
                        reqMst.ToStoreDesc = MPCF.Trim(cdvToStore.Value);

                        reqMst.AddRowSpread(spdReqMstMove);
                        
                    }

                    reqDtl = new cinvReqDtlReturn(smatId);
                    MPCF.SetInMsg(reqDtl);
                    reqDtl.MatId = MPCF.Trim(smatId);
                    reqDtl.MatVer = BIGC.B_MATERIAL_DEFAULT_VERSION;
                    reqDtl.ReqQty1 = lotQty;
                    reqDtl.MatDesc = smatDesc;
                    reqDtl.Unit = sunit;
                    if (reqMst.lisReqDtl == null)
                    {
                        reqMst.AddReqDtl(reqDtl);
                        reqDtl.AddRowSpread(spdReqDtlMove);

                        reqLot = new cinvReqLotReturn(slotId);
                        MPCF.SetInMsg(reqLot);
                        reqLot.LotId = MPCF.Trim(slotId);
                        reqLot.ReqQty1 = lotQty;
                        reqLot.MatId = smatId;
                        reqLot.MatDesc = smatDesc;
                        reqLot.Unit = sunit;

                        reqDtl.AddReqLot(reqLot);
                        reqLot.AddRowSpread(spdReqLotMove);
                    }
                    else
                    {
                        int irow = 0;
                        foreach (cinvReqDtlReturn reqDtlValue in reqMst.lisReqDtl)
                        {                            
                            if (reqDtlValue.Equals(reqDtl))
                            {
                                blnextReqDtl = true;
                                reqDtlValue.ReqQty1 += lotQty;
                                reqDtlValue.UpdateRowSpread(spdReqDtlMove, irow, (int)ColReqDtl.WEIGHT_PINKING, reqDtlValue.ReqQty1);

                                reqLot = new cinvReqLotReturn(slotId);
                                MPCF.SetInMsg(reqLot);
                                reqLot.LotId = MPCF.Trim(slotId);
                                reqLot.ReqQty1 = lotQty;
                                reqLot.MatId = smatId;
                                reqLot.MatDesc = smatDesc;
                                reqLot.Unit = sunit;

                                reqDtlValue.AddReqLot(reqLot);
                                reqLot.AddRowSpread(spdReqLotMove);

                            }
                            irow++;
                        }

                        if (blnextReqDtl == false)
                        {
                            reqMst.AddReqDtl(reqDtl);
                            reqDtl.AddRowSpread(spdReqDtlMove);

                            reqLot = new cinvReqLotReturn(slotId);
                            MPCF.SetInMsg(reqLot);
                            reqLot.LotId = MPCF.Trim(slotId);
                            reqLot.ReqQty1 = lotQty;
                            reqLot.MatId = smatId;
                            reqLot.MatDesc = smatDesc;
                            reqLot.Unit = sunit;

                            reqDtl.AddReqLot(reqLot);
                            reqLot.AddRowSpread(spdReqLotMove);
                        }
                    }


                    txtLotId.Focus();
                    txtLotId.SelectAll();

                    MPCF.FitColumnHeader(spdReqMstMove);
                    MPCF.FitColumnHeader(spdReqDtlMove);
                    MPCF.FitColumnHeader(spdReqLotMove);
                } 
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);                
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int irow = 0;
                string lotId = string.Empty;
                int iactiveRow = 0;
                int ilotRow = 0;
                if (spdReqLotMove.Sheets[0].RowCount > 0)
                {
                    iactiveRow = spdReqLotMove.Sheets[0].ActiveRowIndex;
                    lotId = MPCF.Trim(spdReqLotMove.Sheets[0].GetValue(iactiveRow, (int)ColReqLot.LOT_ID));
                    foreach (cinvReqDtlReturn reqDtl in reqMst.lisReqDtl)
                    {
                        ilotRow = 0;
                        foreach (cinvReqLotReturn reqLot in reqDtl.lisReqLot)
                        {
                            if (reqLot.LotId == lotId)
                            {
                                reqDtl.ReqQty1 -= reqLot.ReqQty1;
                                reqDtl.UpdateRowSpread(spdReqDtlMove, irow, (int)ColReqDtl.WEIGHT_PINKING, reqDtl.ReqQty1);
                                reqDtl.RemoveReqLot(ilotRow);
                                reqLot.RemoveRowSpread(spdReqLotMove, iactiveRow);
                                break;
                            }
                            ilotRow++;
                        }
                        if (reqDtl.lisReqLot.Count == 0)
                        {
                            reqMst.RemoveReqDtl(irow);
                            reqDtl.RemoveRowSpread(spdReqDtlMove, irow);
                            break;
                        }
                        irow++;
                    }
                    if (reqMst.lisReqDtl.Count == 0)
                    {
                        reqMst.RemoveRowSpread(spdReqMstMove, 0);
                        reqMst.Init();
                        reqMst = null;                        
                    }

                    txtLotId.Focus();
                    txtLotId.SelectAll();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string invReqNo = string.Empty;
                string reqDate = string.Empty;
                string args = string.Empty;
                if (spdReqMstMove.Sheets[0].RowCount == 0)
                {
                    //CMN107 ERROR - 데이타가 입력되지 않았습니다. 필요한 데이타를 입력해 주십시요.
                    MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, true);
                    return;
                }
                TRSNode picking_out_node = new TRSNode("PICKING_LOT_OUT");

                if (MPCF.CallService("BINV", "BINV_Tran_Picking_Material_For_Return", reqMst, ref picking_out_node) == false)
                {
                    return;
                }

                MPCF.ShowSuccessMessage(picking_out_node, false);

                invReqNo = picking_out_node.GetString("NEW_INV_REQ_NO");
                reqDate = reqMst.MoveDate;

                initSpread();

                reqMst.Init();
                reqMst = null;



                args = invReqNo + ":" + reqDate;
                //BICF.OpenMenu(BIGC.MP_FUNC_NAME_CINV2216, args);                
                BICF.OpenMenu(BIGC.MP_FUNC_NAME_OINV2215, args);
                return ;
                

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvToStroe_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER_GRP_1", BIGC.OPER_GRP_1_M);

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvToStore.Text = cdvToStore.Show(cdvToStore, "Store ID", "BWIP", "BWIP_View_Operation_List", in_node, "OPERATION_LIST", display, header, "OPER_SHORT_DESC");

                if (MPCF.Trim(cdvToStore.Text) != "")
                {
                    if (cdvToStore.returnDatas != null && cdvToStore.returnDatas.Count > 0)
                    {
                        cdvToStore.Tag = cdvToStore.returnDatas[0];
                        cdvToStore.Text = cdvToStore.returnDatas[1];

                        if (cdvFromStore.Tag.ToString() == cdvToStore.Tag.ToString())
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(476), MSG_LEVEL.WARNING, true);

                            cdvToStore.Text = "";
                            cdvToStore.Tag = "";

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

            //try
            //{
            //    TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            //    TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            //    // In Node Setup
            //    in_node.Init();
            //    MPCF.SetInMsg(in_node);
            //    in_node.ProcStep = '1';
            //    in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_FACTORY_LIST));

            //    // CodeView Column Header Setup
            //    string[] header = new string[] { "Factory", "Factory Desc" };

            //    // CodeView Display Column Setup
            //    string[] display = new string[] { "KEY_1", "DATA_1"};

            //    // Show
            //    cdvToStore.Text = cdvToStore.Show(cdvToStore, "Factory List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

            //    if (MPCF.Trim(cdvToStore.Text) != "")
            //    {
            //        if (cdvToStore.returnDatas.Count > 0)
            //        {
            //            cdvToStore.Tag = cdvToStore.returnDatas[0];                        
            //        }                    
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}
        }

        private void cdvFromStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                dvcArgu[2].sCondtion_ID = "FLOW";
                dvcArgu[2].sCondition_Value = "";

                dvcArgu[3].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[3].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvFromStore.Text = cdvFromStore.Show(cdvFromStore, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvFromStore.Text) != "")
                {
                    if (cdvFromStore.returnDatas != null && cdvFromStore.returnDatas.Count > 0)
                    {
                        cdvFromStore.Tag = cdvFromStore.returnDatas[0];

                        if (cdvFromStore.Tag.ToString() == cdvToStore.Tag.ToString())
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(476), MSG_LEVEL.WARNING, true);

                            cdvToStore.Text = "";
                            cdvToStore.Tag = "";

                            return;
                        }
                    }
                    else
                    {
                        //cdvFromStore.Tag = "";
                    }
                }
                else
                {
                    cdvFromStore.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvReasonMove_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup                
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_RSN_DETAIL));
                in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RGA);

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description", "Account Detail" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_3" };

                
                // Show
                cdvReasonMove.Text = cdvReasonMove.Show(cdvReasonMove, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvReasonMove.Text) != "")
                {
                    if (cdvReasonMove.returnDatas != null && cdvReasonMove.returnDatas.Count > 0)
                    {
                        cdvReasonMove.Tag = cdvReasonMove.returnDatas[0];                                                
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmINVPickingInventoryLotReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetDefaultValueToReg();            
        }

        #endregion

        #region Function
        private void InvisibleColumn()
        {
            spdReqMstMove.Sheets[0].Columns[(int)ColReqMst.MOVE_REQ_NO].Visible = false;    
            spdReqLotMove.Sheets[0].Columns[(int)ColReqLot.SELECT].Visible = false;            
        }

        private void LockColumn()
        {
            for (int i = 0; i < spdReqMstMove.Sheets[0].Columns.Count; i++)
            {
                spdReqMstMove.Sheets[0].Columns[i].Locked = true;
            }
            for (int i = 0; i < spdReqDtlMove.Sheets[0].Columns.Count; i++)
            {
                spdReqDtlMove.Sheets[0].Columns[i].Locked = true;
            }
            for (int i = 0; i < spdReqLotMove.Sheets[0].Columns.Count; i++)
            {
                spdReqLotMove.Sheets[0].Columns[i].Locked = true;
            }

        }

        private void initSpread()
        {
            MPCF.ClearList(spdReqMstMove);
            MPCF.ClearList(spdReqDtlMove);
            MPCF.ClearList(spdReqLotMove);            
        }       


  
        public void GetDefaultValueFromReg()
        {
            try
            {
                cdvFromStore.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvFromStore.Tag"));
                cdvFromStore.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvFromStore.Text"));

                cdvToStore.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvToStore.Tag"));
                cdvToStore.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvToStore.Text"));

                cdvReasonMove.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvReasonMove.Tag"));
                cdvReasonMove.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvReasonMove.Text"));      


                
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
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvFromStore.Tag", MPCF.Trim(cdvFromStore.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvFromStore.Text", MPCF.Trim(cdvFromStore.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvToStore.Tag", MPCF.Trim(cdvToStore.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvToStore.Text", MPCF.Trim(cdvToStore.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvReasonMove.Tag", MPCF.Trim(cdvReasonMove.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvReasonMove.Text", MPCF.Trim(cdvReasonMove.Text));


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion        

    }



    public class cinvReqMstReturn :TRSNode
    {                
        public string InvReqNo { get { return this.GetString("INV_REQ_NO"); } set { this.SetString("INV_REQ_NO", value); } }
        public string ReqType { get { return this.GetString("REQ_TYPE"); } set { this.SetString("REQ_TYPE", value); } }        
        public string MoveDate { get { return this.GetString("REQ_DATE"); } set { this.SetString("REQ_DATE", value); } }
        public string MoveTime { get { return this.GetString("REQ_TIME"); } set { this.SetString("REQ_TIME", value); } }
        public string ReqUserId { get { return this.GetString("REQ_USER_ID"); } set { this.SetString("REQ_USER_ID", value); } }       
        public char ReqStatus { get { return this.GetChar("REQ_STATUS"); } set { this.SetChar("REQ_STATUS", value); } }
        public string FromFactory { get { return this.GetString("REQ_CMF_1"); } set { this.SetString("REQ_CMF_1", value); } }        
        public string FromStore { get { return this.GetString("REQ_CMF_2"); } set { this.SetString("REQ_CMF_2", value); } }
        public string ToFactory { get { return this.GetString("REQ_CMF_3"); } set { this.SetString("REQ_CMF_3", value); } }
        public string ToStore { get { return this.GetString("REQ_CMF_4"); } set { this.SetString("REQ_CMF_4", value); } }
        public string ReasonDtl { get { return this.GetString("REQ_CMF_5"); } set { this.SetString("REQ_CMF_5", value); } }

        public string ReasonDtlDesc { get; set; }
        public string FromStoreDesc { get; set; }
        public string ToFactoryDesc { get; set; }
        public string ToStoreDesc { get; set; }

        public List<cinvReqDtlReturn> lisReqDtl { get; set; }
        
        public cinvReqMstReturn(string name) : base (name)
        {
                
        }

        public void AddReqDtl(cinvReqDtlReturn ReqDtlNode)
        {
            if (lisReqDtl == null)
            {
                lisReqDtl = new List<cinvReqDtlReturn>();
            }
            lisReqDtl.Add(ReqDtlNode);
            this.AddNode(ReqDtlNode, "MAT_LIST");         
        }

        public void RemoveReqDtl(int index)
        {
            this.lisReqDtl.RemoveAt(index);
            this.Lists[0].items.RemoveAt(index);
        }

        public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
        {
            int row = 0;
            row = spread.Sheets[0].Rows.Count++;
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.MOVE_REQ_NO, " ");
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.MOVE_DATE, MPCF.ToDate(this.MoveDate));
            spread.Sheets[0].SetTag(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.FROM_STORE, MPCF.Trim(this.FromStore));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.FROM_STORE, MPCF.Trim(this.FromStoreDesc));
            spread.Sheets[0].SetTag(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.TO_STORE, MPCF.Trim(this.ToStore));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.TO_STORE, MPCF.Trim(this.ToStoreDesc));
            spread.Sheets[0].SetTag(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.REASON, MPCF.Trim(this.ReasonDtl));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.REASON, MPCF.Trim(this.ReasonDtlDesc));
            spread.Sheets[0].SetTag(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.STATUS, BIGC.B_REQ_STATUS_REQUEST);
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqMst.STATUS, BIGC.B_REQ_STATUS_REQUEST_DESC);
        }

        public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
        {
            spread.Sheets[0].RemoveRows(row, 1);
        }
        
    }

    public class cinvReqDtlReturn : TRSNode
    {               
        public string MatId { get { return this.GetString("MAT_ID"); } set { this.SetString("MAT_ID", value); } }
        public int MatVer { get { return this.GetInt("MAT_VER"); } set { this.SetInt("MAT_VER", value); } }
        public double ReqQty1 { get { return this.GetDouble("REQ_QTY_1"); } set { this.SetDouble("REQ_QTY_1", value); } }

        public string MatDesc { get; set; }
        public string Unit { get; set; }        

        public List<cinvReqLotReturn> lisReqLot { get; set; }

        public cinvReqDtlReturn(string name) : base (name)
        {
            
        }

        public void AddReqLot(cinvReqLotReturn ReqLotNode)
        {
            if (lisReqLot == null)
            {
                lisReqLot = new List<cinvReqLotReturn>();
            }
            lisReqLot.Add(ReqLotNode);
            this.AddNode(ReqLotNode, "LOT_LIST");
        }

        public void RemoveReqLot(int index)
        {
            this.lisReqLot.RemoveAt(index);
            this.Lists[0].items.RemoveAt(index);
        }

        public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
        {
            int row = 0;
            row = spread.Sheets[0].Rows.Count++;
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqDtl.MATERIAL, MPCF.Trim(this.MatId));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqDtl.MATERIAL_DESC, MPCF.Trim(this.MatDesc));            
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqDtl.UNIT, MPCF.Trim(this.Unit));            
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqDtl.WEIGHT_PINKING, MPCF.Trim(this.ReqQty1));
            
        }

        public void UpdateRowSpread(FarPoint.Win.Spread.FpSpread spread, int row, int Colum, object value)
        {
            spread.Sheets[0].SetValue(row, Colum, value);
        }

        public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
        {
            spread.Sheets[0].RemoveRows(row, 1);
        }

        public override bool Equals(object obj)
        {
            if(this.MatId == ((cinvReqDtlReturn)obj).Name) 
            {
 	            return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
         
    }

    public class cinvReqLotReturn : TRSNode
    {        
        public string LotId { get { return this.GetString("LOT_ID"); } set { this.SetString("LOT_ID", value); } }
        public double ReqQty1 { get { return this.GetDouble("REQ_QTY_1"); } set { this.SetDouble("REQ_QTY_1", value); } }

        public string MatId { get; set; }
        public string MatDesc { get; set; }
        public string Unit { get; set; }

        public cinvReqLotReturn(string name) : base (name)
        {
        }

        public override bool Equals(object obj)
        {
            if(this.LotId == ((cinvReqLotReturn)obj).Name) 
            {
 	            return true;
            }
            return false;
        }

        public void AddRowSpread(FarPoint.Win.Spread.FpSpread spread)
        {
            int row = 0;
            row = spread.Sheets[0].Rows.Count++;
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqLot.LOT_ID, MPCF.Trim(this.LotId));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqLot.MATERIAL, MPCF.Trim(this.MatId));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqLot.MATERIAL_DESC, MPCF.Trim(this.MatDesc));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqLot.UNIT, MPCF.Trim(this.Unit));
            spread.Sheets[0].SetValue(row, (int)frmINVPickingInventoryLotReturn.ColReqLot.QTY, MPCF.Trim(this.ReqQty1));

        }

        public void RemoveRowSpread(FarPoint.Win.Spread.FpSpread spread, int row)
        {
            spread.Sheets[0].RemoveRows(row, 1);            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}


