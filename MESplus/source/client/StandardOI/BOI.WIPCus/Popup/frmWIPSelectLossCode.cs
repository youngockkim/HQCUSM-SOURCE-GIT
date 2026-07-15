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
using BOI.OIFrx;
using System.Collections;

namespace BOI.WIPCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPSelectLossCode : frmPopupBase
    {
        private string _sOper;
        private string _sColSetId;
        private string _sColSetDesc;

        public string Oper
        {
            get { return _sOper; }
            set { _sOper = value; }
        }

        public string lossCode = string.Empty;
        public string lossDesc = string.Empty;
        public string colSetId = string.Empty;
        public string colSetDesc = string.Empty;

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

        #endregion

        #region Constructor

        public frmWIPSelectLossCode(string args)
        {
            InitializeComponent();
            if (args.Split(':').Length == 2)
            {
                _sColSetId = args.Split(':')[0];
                _sColSetDesc = args.Split(':')[1];
            }
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
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdLossList);
            if (_sColSetId != string.Empty)
            {
                cdvColSetID.Text = _sColSetDesc;
                cdvColSetID.Tag = _sColSetId;

                btnView.PerformClick();
            }

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
            // 종료
            this.Close();
        }

        #endregion

        private void cdvColSetID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOSS_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", _sOper);
                in_node.AddString("COL_GRP_1", BIGC.B_COL_GRP_1_PB);

                // CodeView Column Header Setup
                string[] header = new string[] { "Col Set ID", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "COL_SET_ID", "COL_SET_DESC" };

                // Show
                cdvColSetID.Text = cdvColSetID.Show(cdvColSetID, "Loss", "BWIP", "BWIP_View_Collection_Set_List", in_node, "COLLECTION_SET_LIST", display, header, "COL_SET_DESC");

                if (MPCF.Trim(cdvColSetID.Text) != "")
                {
                    if (cdvColSetID.returnDatas != null && cdvColSetID.returnDatas.Count > 0)
                    {
                        cdvColSetID.Tag = cdvColSetID.returnDatas[0];
                        cdvColSetID.Text = cdvColSetID.returnDatas[1];

                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #region Function

        private void ViewChar()
        {
            TRSNode in_node = new TRSNode("VIEW_LOSS_CODE_IN");
            TRSNode out_node = new TRSNode("VIEW_LOSS_CODE_OUT");

            try
            {
                if (MPCF.Trim(cdvColSetID.Text) == "" || MPCF.Trim(cdvColSetID.Tag) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                    cdvColSetID.Focus();
                    return;
                }

                MPCF.ClearList(spdLossList);

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", _sOper);
                in_node.AddString("COL_GRP_1", BIGC.B_COL_GRP_1_PB);

                if (MPCF.CallService("BWIP", "BWIP_View_Collection_Character", in_node, ref out_node) == false)
                {
                    return;
                }

                if (out_node.GetList("DATA_LIST").Count > 0)
                {
                    for (int i = 0; i < out_node.GetList("DATA_LIST").Count; i++)
                    {
                       spdLossList.Sheets[0].RowCount++;
                       spdLossList.Sheets[0].Cells[i, 0].Value = out_node.GetList("DATA_LIST")[i].GetString("LOSS_CODE");
                       spdLossList.Sheets[0].Cells[i, 1].Value = out_node.GetList("DATA_LIST")[i].GetString("LOSS_DESC");
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewChar();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdLossList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                lossCode = spdLossList.Sheets[0].Cells[e.Row, 0].Value.ToString();
                lossDesc = spdLossList.Sheets[0].Cells[e.Row, 1].Value.ToString();

                colSetId = cdvColSetID.Tag.ToString();
                colSetDesc = cdvColSetID.Text;

                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
