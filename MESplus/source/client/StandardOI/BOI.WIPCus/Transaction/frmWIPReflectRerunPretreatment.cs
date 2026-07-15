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
using BOI.OIFrx.BOIControls;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPReflectRerunPretreatment : BOIBaseForm02
    {
        #region Enum
        enum BOM
        {
            MAT_ID,
            MAT_DESC,
            BOM_QTY,
            INPUT_QTY,
            BONUS_QTY
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

        //constant
        private const string RERUN_OPER = "R100";

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

        public frmWIPReflectRerunPretreatment()
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

                if (_lotId != string.Empty)
                {
                    boiLotInfo.View_Lot_Info(_lotId);
                    if (View_Oper(RERUN_OPER))
                    {
                        cdvOperID.Enabled = false;
                        btnView_Click(sender, e);
                    }
                }

                // (Required) 
                bIsShown = true;
            }
        }


        private void cdvOperID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER_GRP_1";
                dvcArgu[1].sCondition_Value = "";

                //dvcArgu[2].sCondtion_ID = "$FLOW";
                //dvcArgu[2].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvOperID.Text = cdvOperID.Show(cdvOperID, "Oper", "CINV2210-001", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvOperID.Text) != "")
                {
                    if (cdvOperID.returnDatas.Count > 0)
                    {
                        cdvOperID.Tag = cdvOperID.returnDatas[0];
                    }
                    else
                    {
                        cdvOperID.Tag = "";
                    }
                }
                else
                {
                    cdvOperID.Tag = "";
                }
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
                    sMatID = MPCF.Trim(_matId);
                    sOper = MPCF.Trim(cdvOperID.Tag);
                    sResID = MPCF.Trim("");
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
                    sMatID = MPCF.Trim(_matId);
                    sOper = MPCF.Trim(cdvOperID.Tag);
                    sResID = MPCF.Trim("");
                    if (AssemblyLoadLot(sMatID, sOper, sResID, _lotId) == true)
                    {
                        ViewLoadLotList(sMatID, sOper, sResID);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLoadWeight_Click(object sender, EventArgs e)
        {
            //로드셀 계근정보 가져오기
        }

        #endregion


        #region Function

        private bool CheckCondition(string FuncName)
        {
            int iRowCount = 0;

            try
            {
                switch (FuncName)
                {                    
                    case "RES_ID":
                        //작업지시
                        if (boiLotInfo.spdLotInfo.Sheets[0].Rows.Count < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "VIEW_LOAD_LOT":                        
                    
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
                in_node.AddString("OPER", oper);
                in_node.AddString("RES_ID", resID);
                in_node.AddString("LOT_ID", lotId);
                in_node.AddDouble("WEIGHT_MEASURE", MPCF.ToDbl(numInputQty.Value));
                in_node.AddChar("REINFORCE_FLAG", _reinforceFlag);
                in_node.AddChar("RERUN_FLAG", 'Y');
                

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


        private bool View_Oper(string oper)
        {
            // Pre-Search 
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", oper);

                if (MPCF.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvOperID.Tag = RERUN_OPER;
                cdvOperID.Text = out_node.GetString("OPER_DESC");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        

       

        
    }
}
