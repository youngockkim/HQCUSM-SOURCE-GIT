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

namespace SOI.WIP
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPViewShipLotTemplatePopup : frmPopupBase
    {
        #region Property

        public WIPViewShipLotTemplatePopupModel model = new WIPViewShipLotTemplatePopupModel();
        private FarPoint.Win.Spread.SheetView originalView;

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

        public frmWIPViewShipLotTemplatePopup()
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
            if (model.ReadOnlyFlag == true)
            {
                if (model.FileData != null)
                {
                    ImportFromByteArray();

                    btnInput.Visible = false;
                }
                else
                {
                    btnInput.Visible = false;
                }
            }
            // Reload가 아닌 경우
            else if (model.ReloadFlag == false)
            {
                // Convert Caption Spread Cell
                MPCF.ConvertCaptionSpreadCell(spdDocument);

                BindData();

                // Caption 변경
                MPCF.ConvertCaption(this);
            }
            // Reload인 경우
            else
            {
                originalView = (FarPoint.Win.Spread.SheetView)FarPoint.Win.Serializer.LoadObjectXml(spdDocument.Sheets[0].GetType(), FarPoint.Win.Serializer.GetObjectXml(spdDocument.Sheets[0], "CopySheet"), "CopySheet");
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
            try
            {
                if (model.ReadOnlyFlag == false)
                {
                    if (string.IsNullOrEmpty(model.FilePath) == true)
                    {
                        model.FilePath = MPCF.ExcelExportToFile(spdDocument, SAVE_FILE_TYPE.xlsx);
                        MPCF.ShowMessageClear();
                    }

                    if (originalView != null)
                    {
                        spdDocument.Sheets.Clear();
                        spdDocument.Sheets.Add(originalView);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                // 종료
                this.Close();
            }
        }

        /// <summary>
        /// Input Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                model.FilePath = MPCF.ExcelExportToFile(spdDocument, SAVE_FILE_TYPE.xlsx);
                MPCF.ShowMessageClear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Lot Data Binding
        /// </summary>
        private void BindData()
        {
            try
            {
                if (model.LOT != null
                    && model.ORDER != null)
                {
                    spdDocument.Sheets[0].Cells["B3"].Value = model.ORDER.GetString("CUSTOMER_ID");
                    spdDocument.Sheets[0].Cells["B4"].Value = string.Empty;
                    spdDocument.Sheets[0].Cells["B5"].Value = model.LOT.GetString("OPER");
                    spdDocument.Sheets[0].Cells["B6"].Value = model.ORDER.GetString("WORK_LINE");
                    spdDocument.Sheets[0].Cells["E3"].Value = model.LOT.GetString("LOT_ID");
                    spdDocument.Sheets[0].Cells["E4"].Value = model.LOT.GetString("MAT_ID");
                    DateTime dt = DateTime.Now;
                    spdDocument.Sheets[0].Cells["E5"].Value = MPCF.MakeDateFormat(dt.ToString(), DATE_TIME_FORMAT.DATETIME);
                    spdDocument.Sheets[0].Cells["H3"].Value = MPCF.MakeNumberFormat(model.LOT.GetDouble("QTY_1"));
                    spdDocument.Sheets[0].Cells["H4"].Value = model.ORDER.GetString("ORDER_ID");
                    spdDocument.Sheets[0].Cells["H5"].Value = MPGV.gsUserID;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Import From Byte Array
        /// </summary>
        private void ImportFromByteArray()
        {
            try
            {
                MPCF.ExcelImportFromFile(MPCF.ByteArrayToExcelFile(model.FileData, SAVE_FILE_TYPE.xlsx), spdDocument);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion
    }

    public class WIPViewShipLotTemplatePopupModel
    {
        private bool _reloadFlag;
        public bool ReloadFlag
        {
            get
            {
                return _reloadFlag;
            }
            set
            {
                _reloadFlag = value;
            }
        }

        private bool _readOnlyFlag;
        public bool ReadOnlyFlag
        {
            get 
            { 
                return _readOnlyFlag; 
            }
            set 
            { 
                _readOnlyFlag = value;    
            }
        }

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }

        private byte[] _fileData;
        public byte[] FileData
        {
            get
            {
                return _fileData;
            }
            set
            {
                _fileData = value;
            }
        }

        public TRSNode LOT;
        public TRSNode ORDER;
    }
}
