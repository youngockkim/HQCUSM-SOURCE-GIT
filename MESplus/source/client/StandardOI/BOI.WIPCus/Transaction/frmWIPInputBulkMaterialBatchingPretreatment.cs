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
using SOI.DNM;
using BOI.OIFrx;
using System.Collections;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPInputBulkMaterialBatchingPretreatment : BOIBaseForm02
    {
        #region Enum
        enum BOM
        {
            MAT_ID,
            MAT_DESC,
            BOM_QTY,
            INPUT_QTY            
        }

        enum ASSEMBLY
        {
            SEQ,            
            OPER,            
            MATERIAL,
            MATERIAL_DESC,
            MAT_LOT_ID,
            RES_ID,
            IN_DATETIME,
            QTY
        }


        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

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

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set { _oper = value; }
        }

        private string _flow = string.Empty;

        public string Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }

        private string _lineId = string.Empty;

        public string LineId
        {
            get { return _lineId; }
            set { _lineId = value; }
        }

        private string _matBomType = string.Empty;

        public string MatBomType
        {
            get { return _matBomType; }
            set { _matBomType = value; }
        }

        private char _reinforceFlag;

        public char ReinforceFlag
        {
            get { return _reinforceFlag; }
            set { _reinforceFlag = value; }
        }

        #endregion

        #region Constructor

        public frmWIPInputBulkMaterialBatchingPretreatment()
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
                if (_lotId != string.Empty)
                {
                    boiLotInfo.View_Lot_Info(_lotId);
                    ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId);                    
                }

                // (Required) 
                bIsShown = true;
            }
        }


        private void cdvStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;


                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvStoreID.Text = cdvStoreID.Show(cdvStoreID, "Oper", "CWIP8060-001", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvStoreID.Text) != "")
                {
                    if (cdvStoreID.returnDatas != null && cdvStoreID.returnDatas.Count > 0)
                    {
                        cdvStoreID.Tag = cdvStoreID.returnDatas[0];
                    }
                    else
                    {
                        //cdvStoreID.Tag = "";
                    }
                }
                else
                {
                    cdvStoreID.Tag = "";
                }

                btnView_Click(sender, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvTankId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("TANK_ID") == false)
                {
                    return;
                }

                BICF.ViewResource(cdvTankId, "", _lineId, MPCF.Trim(cdvStoreID.Tag));
                btnView_Click(sender, e);
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
                string sMatID = string.Empty;
                string sOper = string.Empty;
                string sResID = string.Empty;

                if (CheckCondition("VIEW_LOAD_LOT") == true)
                {
                    sMatID = MPCF.Trim(spdTargetMaterial_Sheet1.GetValue(spdTargetMaterial_Sheet1.ActiveRowIndex, (int)BOM.MAT_ID));
                    sOper = MPCF.Trim(cdvStoreID.Tag);
                    sResID = MPCF.Trim(cdvTankId.Tag);
                    if (ViewLoadLotList(sMatID, sOper, sResID) == false)
                    {
                        MPCF.ClearList(spdLoadLotList);
                    }
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
                string sMatID = string.Empty;
                string sOper = string.Empty;
                string sResID = string.Empty;

                if (CheckCondition("LOAD_LOT") == true)
                {
                    sMatID = MPCF.Trim(spdTargetMaterial_Sheet1.GetValue(spdTargetMaterial_Sheet1.ActiveRowIndex, (int)BOM.MAT_ID));
                    sOper = MPCF.Trim(cdvStoreID.Tag);
                    sResID = MPCF.Trim(cdvTankId.Tag);
                    if (AssemblyLoadLot(sMatID, sOper, sResID, _lotId) == true)
                    {
                        ViewLoadLotList(sMatID, sOper, sResID);
                        ViewBomList(_matId, _matBomType, _oper, _orderId, _lotId, sMatID);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        #endregion


        #region Function

        private bool CheckCondition(string FuncName)
        {

            try
            {
                switch (FuncName)
                {                    
                    case "TANK_ID":
                        //작업지시
                        if (boiLotInfo.spdLotInfo.Sheets[0].Rows.Count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "VIEW_LOAD_LOT":
                        
                        if (spdTargetMaterial.Sheets[0].ActiveRowIndex < 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(424), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        //if (MPCF.Trim(spdTargetMaterial_Sheet1.GetTag(spdTargetMaterial_Sheet1.ActiveRowIndex, (int)BOM.MAT_DESC)) == BIGC.B_MAT_TYPE_HG)
                        //{
                        //    if (MPCF.Trim(cdvTankId.Tag) == string.Empty)
                        //    {
                        //        MPCF.ShowMessage(MPCF.GetMessage(453), MSG_LEVEL.WARNING, true);
                        //        return false;
                        //    }
                        //}

                        break;

                    case "LOAD_LOT":
                        
                        if (spdLoadLotList.Sheets[0].RowCount < 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(439), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        if (MPCF.ToDbl(numInputQty.Value) <= 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(440), MSG_LEVEL.WARNING, true);
                            numInputQty.Focus();
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

        private bool ViewBomList(string matId, string matBomType, string oper, string orderId)
        {          

            try
            {
                MPCF.ClearList(spdTargetMaterial);
                TRSNode in_node = new TRSNode("VIEW_BOM_LIST_IN");
                TRSNode out_node;
                ArrayList lisWeight = new ArrayList();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", MPCF.Trim(orderId));
                in_node.AddString("LOT_ID", MPCF.Trim(_lotId));                
                in_node.AddString("P_MAT_ID", MPCF.Trim(matId));
                in_node.AddString("P_MAT_BOM_TYPE", MPCF.Trim(matBomType));                
                in_node.AddString("OPER", MPCF.Trim(oper));
                in_node.AddString("NEXT_C_MAT_ID", "");

                do
                {
                    out_node = new TRSNode("VIEW_BOM_LIST_OUT");

                    if (MPCF.CallService("BWIP", "BWIP_View_Bom_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisWeight.Add(out_node);

                    in_node.SetString("NEXT_C_MAT_ID", out_node.GetString("NEXT_C_MAT_ID"));
                } while (in_node.GetString("NEXT_C_MAT_ID") != "");


                int iRow = 0;
                foreach (object obj in lisWeight)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdTargetMaterial_Sheet1.RowCount++;
                        spdTargetMaterial_Sheet1.SetValue(iRow, (int)BOM.MAT_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("C_MAT_ID")));
                        spdTargetMaterial_Sheet1.SetValue(iRow, (int)BOM.MAT_DESC, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_DESC")));
                        spdTargetMaterial_Sheet1.SetTag(iRow, (int)BOM.MAT_DESC, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_TYPE")));
                        spdTargetMaterial_Sheet1.SetValue(iRow, (int)BOM.BOM_QTY, MPCF.ToDbl(out_node.GetList(0)[i].GetDouble("BOM_QTY")));
                        spdTargetMaterial_Sheet1.SetValue(iRow, (int)BOM.INPUT_QTY, MPCF.ToDbl(out_node.GetList(0)[i].GetDouble("INPUT_QTY")));
                    }
                }

                return true;             
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void ViewBomList(string matId, string matBomType, string oper, string orderId, string lotId, string selectedMatId = "")
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;
            string directViewID = string.Empty;
            int foundRow = -1;
            int foundColumn = -1;


            try
            {
                if (_reinforceFlag == 'Y')
                {
                    directViewID = "CWIP8050-003";
                }
                else
                {
                    directViewID = "CWIP8040-005";
                }

                spdTargetMaterial_Sheet1.RowCount = 0;

                dvcArgu[2].sCondtion_ID = "FACTORY";
                dvcArgu[2].sCondition_Value = MPGV.gsFactory;

                dvcArgu[3].sCondtion_ID = "MAT_ID";
                dvcArgu[3].sCondition_Value = matId;

                dvcArgu[4].sCondtion_ID = "MAT_BOM_TYPE";
                dvcArgu[4].sCondition_Value = matBomType;

                dvcArgu[5].sCondtion_ID = "OPER";
                dvcArgu[5].sCondition_Value = oper;

                dvcArgu[0].sCondtion_ID = "ORDER_ID";
                dvcArgu[0].sCondition_Value = orderId;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = lotId;

                if (TPDR.GetDataOne("", ref dt, directViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();
                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdTargetMaterial_Sheet1.RowCount++;

                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.MAT_DESC].Tag = MPCF.Trim(dt.Rows[i]["MAT_TYPE"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.BOM_QTY].Value = MPCF.ToDbl(dt.Rows[i]["BOM_QTY"].ToString());
                    spdTargetMaterial_Sheet1.Cells[i, (int)BOM.INPUT_QTY].Value = MPCF.ToDbl(dt.Rows[i]["INPUT_QTY"].ToString());
                }

                spdTargetMaterial.Search(0, selectedMatId, true, true, false, false, 0, 0, ref foundRow, ref foundColumn);
                if (foundRow >= 0)
                {
                    spdTargetMaterial_Sheet1.ActiveRowIndex = foundRow;
                    spdTargetMaterial_Sheet1.SetActiveCell(foundRow, 0);
                }



            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool ViewLoadLotList(string matId, string oper, string resID)
        {
            try
            {
                MPCF.ClearList(spdLoadLotList);
                TRSNode in_node = new TRSNode("View_Load_Lot_List_In");
                TRSNode out_node;
                ArrayList lisWeight = new ArrayList();               

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", MPCF.Trim(matId));
                in_node.AddInt("MAT_VER", MPCF.Trim(BIGC.B_MATERIAL_DEFAULT_VERSION));
                in_node.AddString("OPER", MPCF.Trim(oper));
                in_node.AddString("RES_ID", MPCF.Trim(resID));                               
                in_node.AddString("NEXT_LOAD_TIME", "");
             
                do
                {
                    out_node = new TRSNode("View_Load_Lot_List_Out");

                    if (MPCF.CallService("BINV", "BINV_View_Inventory_Lot_Load_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisWeight.Add(out_node);

                    in_node.SetString("NEXT_LOAD_TIME", out_node.GetString("NEXT_LOAD_TIME"));
                } while (in_node.GetString("NEXT_LOAD_TIME") != "");

                

                int iRow = 0;
                foreach (object obj in lisWeight)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdLoadLotList.Sheets[0].Rows.Count++;

                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.SEQ, iRow + 1);
                        spdLoadLotList.Sheets[0].SetTag(iRow, (int)ASSEMBLY.OPER, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.OPER, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.MATERIAL, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.MATERIAL_DESC, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_DESC")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.MAT_LOT_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        spdLoadLotList.Sheets[0].SetTag(iRow, (int)ASSEMBLY.RES_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.RES_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("RES_DESC")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.IN_DATETIME, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOAD_TIME")));
                        spdLoadLotList.Sheets[0].SetValue(iRow, (int)ASSEMBLY.QTY, MPCF.ToDbl(out_node.GetList(0)[i].GetDouble("LOAD_QTY_1")));

                    }
                }
                
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool AssemblyLoadLot(string matId, string oper, string resID, string lotId)
        {
            TRSNode in_node = new TRSNode("ASSEMBLY_LOAD_LOT_IN");
            TRSNode out_node = new TRSNode("ASSEMBLY_LOAD_LOT_OUT");


            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("MAT_ID", matId);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddChar("P_MAT_BOM_TYPE", _matBomType);
                in_node.AddString("OPER", oper);
                in_node.AddString("RES_ID", resID);
                in_node.AddString("LOT_ID", lotId);
                
                in_node.AddDouble("WEIGHT_MEASURE", MPCF.ToDbl(numInputQty.Value));
                in_node.AddChar("REINFORCE_FLAG", _reinforceFlag);
                

                if (MPCF.CallService("BWIP", "BWIP_Assembly_Load_Lot", in_node, ref out_node) == false)
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
            if (_reinforceFlag == 'Y')
            {
                spdTargetMaterial.Sheets[0].Columns[(int)BOM.INPUT_QTY].Visible = false;
            }
        }       

        #endregion

       

        
    }
}
