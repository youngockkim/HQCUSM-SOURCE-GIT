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

namespace SOI.CINV.Popup
{

    #region Enum

    public enum ColResourceList
    {
        SELECT = 0,
        TANK_ID,
        TANK_NAME,        
        WEIGHT_TANK
    }

    #endregion


    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCINVViewResourceListPopup : frmPopupBase
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

        #endregion

        #region Constructor

        public frmCINVViewResourceListPopup()
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
            ReturnDatas.Clear();
            ReturnList.Clear();
            ReturnValue = "";
            this.inOutFlag = "";
            // 종료
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Datas;
                // 데이터 소스가 없거나 데이터가 없는 경우
                if (spdCarResList.Sheets[0].Rows.Count == 0)
                {
                    return;
                }

                // 선택된 Row가 없는 경우
                if (spdCarResList.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }

                // 선택된 Row 데이터 저장                
                this.ReturnValue = MPCF.Trim(spdCarResList.Sheets[0].GetValue(spdCarResList.Sheets[0].ActiveRowIndex, (int)ColResourceList.TANK_ID));

                this.ReturnDatas.Clear();
                this.ReturnList.Clear();
                for (int i = 0; i < spdCarResList.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdCarResList.Sheets[0].Cells[i, (int)ColResourceList.SELECT].Value == true)
                    {
                        Datas = new List<string>();
                        for (int j = 0; j < spdCarResList.Sheets[0].Columns.Count; j++)
                        {
                            Datas.Add(MPCF.Trim(spdCarResList.Sheets[0].Cells[i,j].Value));
                        }
                        this.ReturnList.Add(Datas);
                    }
                }
                if (chkonInOutFlag.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    this.inOutFlag = MPCF.Trim(chkonInOutFlag.OnStateKey);
                }
                else
                {
                    this.inOutFlag = MPCF.Trim(chkonInOutFlag.OffStateKey);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

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
                if (e.Row > -1)
                {
                    spdCarResList.Sheets[0].Columns[(int)ColResourceList.SELECT].Locked = false;
                    if (spdCarResList.Sheets[0].GetValue(e.Row, (int)ColResourceList.SELECT) == null || 
                        (bool)spdCarResList.Sheets[0].GetValue(e.Row, (int)ColResourceList.SELECT) == false)
                    {                        
                        spdCarResList.Sheets[0].SetValue(e.Row, (int)ColResourceList.SELECT, true);
                    }
                    else
                    {
                        if (e.Column != (int)ColResourceList.WEIGHT_TANK)
                        {
                            spdCarResList.Sheets[0].SetValue(e.Row, (int)ColResourceList.SELECT, false);
                        }
                    }
                    spdCarResList.Sheets[0].Columns[(int)ColResourceList.SELECT].Locked = true;

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
            TRSNode in_node = new TRSNode("View_Resource_List_Ln");
            

            TRSNode out_node;            
            ArrayList lisHist = new ArrayList();
            int iResourceCount = 0;            

            try
            {
                MPCF.ClearList(this.spdCarResList);
                
                MPCF.SetInMsg(in_node);
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.SetString("RESG_ID", BIGC.MP_RES_GROUP_RAWMILKTANK);                  

                do
                {
                    out_node = new TRSNode("View_Resource_List_Out");

                    if (MPCF.CallService("RAS", "Ras_View_Resource_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);


                    in_node.SetString("NEXT_RESG_ID", out_node.GetString("NEXT_RESG_ID"));
                } while (in_node.GetString("NEXT_RESG_ID") != "");

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
                        spdCarResList.Sheets[0].Cells[iRow, (int)ColResourceList.WEIGHT_TANK].Value = 0;                        
                      
                        iResourceCount++;
                    }
                }                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

       
        #endregion

      

        
    }
}
