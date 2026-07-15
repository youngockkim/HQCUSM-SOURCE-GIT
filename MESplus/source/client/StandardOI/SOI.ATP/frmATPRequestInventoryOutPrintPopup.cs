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

namespace SOI.ATP
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmATPRequestInventoryOutPrintPopup : frmPopupBase
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

        public ATPRequestInventoryOutPrintPopupModel model = new ATPRequestInventoryOutPrintPopupModel();

        #endregion

        #region Constructor

        public frmATPRequestInventoryOutPrintPopup()
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
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Convert Caption Spread Cell
            MPCF.ConvertCaptionSpreadCell(spdDocument);

            //  Set Data
            spdDocument.Sheets[0].Cells["C3"].Value = model.PlanDate;
            spdDocument.Sheets[0].Cells["E3"].Value = model.Line;
            spdDocument.Sheets[0].Cells["H3"].Value = model.PublishDate;

            int listCount = 0;
            for (int i = 5; i < 5 + model.List.Count; i++)
            {
                if (i > 5)
                {
                    spdDocument.Sheets[0].Rows.Count++;
                    spdDocument.Sheets[0].CopyRange(5, 0, spdDocument.Sheets[0].Rows.Count - 1, 0, 1, spdDocument.Sheets[0].Columns.Count, false);
                    spdDocument.Sheets[0].Rows[spdDocument.Sheets[0].Rows.Count - 1].Height = spdDocument.Sheets[0].Rows[5].Height;
                }

                spdDocument.Sheets[0].Cells[i, 0].Value = model.List[listCount].Seq;
                spdDocument.Sheets[0].Cells[i, 1].Value = model.List[listCount].InvMatID;
                spdDocument.Sheets[0].Cells[i, 2].Value = model.List[listCount].InvMatDesc;
                spdDocument.Sheets[0].Cells[i, 4].Value = model.List[listCount].ProdReqQty;
                spdDocument.Sheets[0].Cells[i, 5].Value = model.List[listCount].SafetyQty;
                spdDocument.Sheets[0].Cells[i, 6].Value = model.List[listCount].InvOutQty;
                spdDocument.Sheets[0].Cells[i, 7].Value = model.List[listCount].ReqQty;
                spdDocument.Sheets[0].Cells[i, 8].Value = model.List[listCount].InvQty;

                listCount++;
            }

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
            // 종료
            this.Close();
        }

        /// <summary>
        /// Print Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.PrintSpread(this.Owner, ((frmATPRequestInventoryOut)this.Owner).printOption, spdDocument) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(17), MSG_LEVEL.INFO, false);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        #endregion
    }

    public class ATPRequestInventoryOutPrintPopupModel
    {
        private string planDate;
        public string PlanDate
        {
            get { return planDate; }
            set { planDate = value; }
        }

        private string line;
        public string Line
        {
            get { return line; }
            set { line = value; }
        }

        private string publishDate;
        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        private List<ATPReqInvOutPrintPopupModelList> list;
        public List<ATPReqInvOutPrintPopupModelList> List
        {
            get { return list; }
            set { list = value; }
        }
    }

    public class ATPReqInvOutPrintPopupModelList
    {
        private string seq;
        public string Seq
        {
            get { return seq; }
            set { seq = value; }
        }

        private string invMatID;
        public string InvMatID
        {
            get { return invMatID; }
            set { invMatID = value; }
        }

        private string invMatDesc;
        public string InvMatDesc
        {
            get { return invMatDesc; }
            set { invMatDesc = value; }
        }

        private string prodReqQty;
        public string ProdReqQty
        {
            get { return prodReqQty; }
            set { prodReqQty = value; }
        }

        private string safetyQty;
        public string SafetyQty
        {
            get { return safetyQty; }
            set { safetyQty = value; }
        }

        private string invOutQty;
        public string InvOutQty
        {
            get { return invOutQty; }
            set { invOutQty = value; }
        }

        private string reqQty;
        public string ReqQty
        {
            get { return reqQty; }
            set { reqQty = value; }
        }

        private string invQty;
        public string InvQty
        {
            get { return invQty; }
            set { invQty = value; }
        }
    }
}
