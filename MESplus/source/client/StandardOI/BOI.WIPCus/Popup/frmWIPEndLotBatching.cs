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
using BOI.OIFrx.BOIControls;
using BOI.OIFrx;
namespace BOI.WIPCus
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPEndLotBatching : frmPopupBase
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        

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

        private double _endQty = 0.0d;

        public double EndQty
        {
            get { return _endQty; }
            set
            {
                _endQty = value;
                numEndQty.Value = _endQty;
            }
        }

        private double _loadCellWeight = 0.0d;

        public double LoadCellWeight
        {
            get { return _loadCellWeight; }
            set 
            { 
                _loadCellWeight = value;
                numLoadCellWeight.Value = _loadCellWeight;
            }
        }

        

        #endregion

        #region H101 Module

        private H101Tuner h101tuner = new H101Tuner();
        private delegate void H101DataReceived(TRSNode node);
        private H101DataReceived h101DataRecevied;

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set { _oper = value; }
        }

        private string _resID = string.Empty;

        public string ResID
        {
            get { return _resID; }
            set { _resID = value; }
        }

        private void btnLoadCell_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("GET_LOADCELL_IN");
            TRSNode out_node = new TRSNode("GET_LOADCELL_OUT");
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("_MES_MODULE", h101tuner.Module);
                in_node.AddString("_MES_CHANNEL", h101tuner.Channel);
                in_node.AddChar("_MES_REPLY_FLAG", 'Y');
                in_node.AddString("RES_ID", _resID);
                in_node.AddString("CHAR_ID", BIGC.CHR_CRDR001);
                in_node.AddString("VALUE", "");

                if (MPCF.CallService("BEIS", "BEIS_Request_Resource_Data", in_node, SOI.MsgHandlerH101.DeliveryMode.Unicast, false) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void h101tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            IAsyncResult r = BeginInvoke(h101DataRecevied, e.Node);
            EndInvoke(r);
        }

        private void OnH101DataReceived(TRSNode node)
        {
            try
            {
                numLoadCellWeight.Value = MPCF.ToDbl(node.GetString("VALUE"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }


        private void frmWIPEndLotBatching_FormClosing(object sender, FormClosingEventArgs e)
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

                string module = string.Empty;
                string channel = string.Empty;
                module = Oper + ResID;
                channel = Oper + "/" + ResID;

                h101DataRecevied += new H101DataReceived(OnH101DataReceived);
                h101tuner.DataReceived += new H101DataReceivedEventHandler(h101tuner_DataReceived);
                h101tuner.Module = module;
                h101tuner.Channel = channel;
                h101tuner.MultiCast = true;
                h101tuner.UseRandomChannel = true;
                h101tuner.PublishCUSMsgTune();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }

        }


        #endregion

        #region Constructor

        public frmWIPEndLotBatching()
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
            // Caption 변경
            MPCF.ConvertCaption(this);

            #region H101 Module
            InitH101Tuner();
            #endregion

            // 활성화
            this.Activate();
            
        }

       

        private void frmWIPEndLotBatching_Activated(object sender, EventArgs e)
        {
             // (Required) 
            if (bIsShown == false)
            {
                this.btnClose.Focus();
                btnLoadCell_Click(sender, e);
                bIsShown = true;
            }
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //_endQty = MPCF.ToDbl(numEndQty.Value);
            _loadCellWeight = MPCF.ToDbl(numLoadCellWeight.Value);
            if (_loadCellWeight <= 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, true);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        

       
       
        #endregion                      

        #region Function

        #endregion

        

        
    }
}
