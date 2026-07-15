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
    public partial class frmATPShipmentPrintPopup : frmPopupBase
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

        public ATPShipmentPrintPopupModel model = new ATPShipmentPrintPopupModel();

        #endregion

        #region Constructor

        public frmATPShipmentPrintPopup()
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
            spdDocument.Sheets[0].Cells["C3"].Value = model.Supplier;
            spdDocument.Sheets[0].Cells["C4"].Value = model.InvoiceNumber;
            spdDocument.Sheets[0].Cells["C5"].Value = model.Consumer;
            spdDocument.Sheets[0].Cells["F3"].Value = model.CarNumber;
            spdDocument.Sheets[0].Cells["F4"].Value = model.Contact;
            spdDocument.Sheets[0].Cells["F5"].Value = model.IssueDate;

            int listCount = 0;
            for (int i = 7; i < 7 + model.List.Count; i++)
            {
                if (i > 7)
                {
                    spdDocument.Sheets[0].Rows.Count++;
                    spdDocument.Sheets[0].CopyRange(7, 0, spdDocument.Sheets[0].Rows.Count - 1, 0, 1, spdDocument.Sheets[0].Columns.Count, false);
                    spdDocument.Sheets[0].Rows[spdDocument.Sheets[0].Rows.Count - 1].Height = spdDocument.Sheets[0].Rows[7].Height;
                }

                spdDocument.Sheets[0].Cells[i, 0].Value = model.List[listCount].Seq;
                spdDocument.Sheets[0].Cells[i, 1].Value = model.List[listCount].MatID;
                spdDocument.Sheets[0].Cells[i, 3].Value = model.List[listCount].MatDesc;
                spdDocument.Sheets[0].Cells[i, 5].Value = model.List[listCount].Qty;
                spdDocument.Sheets[0].Cells[i, 6].Value = model.List[listCount].Ramark;

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
                if (MPCF.PrintSpread(this.Owner, ((frmATPShipment)this.Owner).printOption, spdDocument) == true)
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

    public class ATPShipmentPrintPopupModel
    {
        private string supplier;
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        private string carNumber;
        public string CarNumber
        {
            get { return carNumber; }
            set { carNumber = value; }
        }

        private string invoiceNumber;
        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        private string contact;
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        private string consumer;
        public string Consumer
        {
            get { return consumer; }
            set { consumer = value; }
        }

        private string issueDate;
        public string IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        private List<ATPShipmentPrintPopupModelList> list;
        public List<ATPShipmentPrintPopupModelList> List
        {
            get { return list; }
            set { list = value; }
        }
    }

    public class ATPShipmentPrintPopupModelList
    {
        private string seq;
        public string Seq
        {
            get { return seq; }
            set { seq = value; }
        }

        private string matID;
        public string MatID
        {
            get { return matID; }
            set { matID = value; }
        }

        private string matDesc;
        public string MatDesc
        {
            get { return matDesc; }
            set { matDesc = value; }
        }

        private string qty;
        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private string remark;
        public string Ramark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
