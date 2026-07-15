using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIModel;
using System.IO.Ports;

namespace SOI.OIFrx.SOIPopup
{
    public partial class frmPrintOptionPopup : frmPopupBase
    {
        #region Property

        public string funcName;
        public PrintOptionModel printOption;

        /// <summary>
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

        public frmPrintOptionPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Print Option Popup 화면 로드 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrintOptionPopup_Load(object sender, EventArgs e)
        {
            // Get Print Option
            // 화면별 설정을 가져오지 못한 경우
            if (this.printOption == null)
            {
                this.printOption = new PrintOptionModel();
                if (MPOF.GetPrintOptionFromReg(ref this.printOption, this.funcName) == false)
                {
                    return;
                }
            }

            // Reset Option 
            if (SetOption() == false)
            {
                return;            
            }

            // Caption 변경
            MPOF.ConvertCaption(this);

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// OK 버튼 클릭 시 저장합니다.
        /// 레지스트리 및 화면별 Print Option에 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // 변수 저장
                this.printOption.Document.PrinterName = cboDocumentPrinterName.Text;
                this.printOption.Label.ConnectionType = cboLabelConnectType.Text;
                this.printOption.Label.PrinterName = cboLabelPrinterName.Text;
                this.printOption.Label.Port = cboLabelPort.Text;
                this.printOption.Label.BaudRate = MPOF.ToInt(cboLabelBaudRate.Text);
                this.printOption.Label.DataBit = MPOF.ToInt(cboLabelDataBit.Text);
                this.printOption.Label.Parity = (cboLabelParity.Text == "" ? Parity.None : (Parity)Enum.Parse(typeof(Parity), cboLabelParity.Text));
                this.printOption.Label.StopBits = (cboLabelStopBit.Text == "" ? StopBits.None : (StopBits)Enum.Parse(typeof(StopBits), cboLabelStopBit.Text));
                this.printOption.Label.Handshake = (cboLabelHandshake.Text == "" ? Handshake.None : (Handshake)Enum.Parse(typeof(Handshake), cboLabelHandshake.Text));

                // 레지스트리 저장
                if (MPOF.SetPrintOptionToReg(this.printOption, this.funcName) == false)
                {
                    return;
                }
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Close 버튼 클릭 시 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Label Connect Type에 따라 하단의 내용들을 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLabelConnectType_SelectionChanged(object sender, EventArgs e)
        {
            // COM인 경우
            if (cboLabelConnectType.SelectedItem.DisplayText.Equals("COM"))
            {
                tlpLabelCOMOption1.Visible = true;
                tlpLabelCOMOption2.Visible = true;
                tlpLabelCOMOption3.Visible = true;
                tlpLabelPrinter.Visible = false;
            }
            // Driver 인 경우
            else
            {
                tlpLabelCOMOption1.Visible = false;
                tlpLabelCOMOption2.Visible = false;
                tlpLabelCOMOption3.Visible = false;
                tlpLabelPrinter.Visible = true;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Option 화면을 구성합니다.
        /// 콤보박스의 데이터를 전역변수에 맞추어 구성합니다.
        /// </summary>
        /// <returns></returns>
        private bool SetOption()
        {
            try
            {
                // Connect Type
                for (int i = 0; i < cboLabelConnectType.Items.Count; i++)
                {
                    if (this.printOption.Label.ConnectionType.Equals(cboLabelConnectType.Items[i].DisplayText))
                    {
                        cboLabelConnectType.SelectedIndex = i;
                        break;
                    }
                }

                // Printer Name
                try
                {
                    List<string> printerList = clsPrinter.GetPrinterList();

                    if (printerList != null)
                    {
                        // Document Setting
                        cboDocumentPrinterName.Items.Clear();

                        for (int i = 0; i < printerList.Count; i++)
                        {
                            cboDocumentPrinterName.Items.Add(i, printerList[i]);
                            if (this.printOption.Document.PrinterName.Equals(printerList[i]))
                            {
                                cboDocumentPrinterName.SelectedIndex = i;
                            }
                        }

                        // Label Setting
                        cboLabelPrinterName.Items.Clear();

                        for (int i = 0; i < printerList.Count; i++)
                        {
                            cboLabelPrinterName.Items.Add(i, printerList[i]);
                            if(this.printOption.Label.PrinterName.Equals(printerList[i]))
                            {
                                cboLabelPrinterName.SelectedIndex = i;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, true);
                }
                
                // Port
                try
                {
                    // 현재 연결된 Print의 포트 리스트 
                    List<string> portList = clsPrinter.GetPortList();

                    cboLabelPort.Items.Clear();
                    if(portList != null)
                    {
                        for (int i = 0; i < portList.Count; i++)
                        {
                            cboLabelPort.Items.Add(i, portList[i]);
                            if (this.printOption.Label.Port.Equals(portList[i]))
                            {
                                cboLabelPort.SelectedIndex = i;
                            }
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, true);
                }

                // BaudRate
                for (int i = 0; i < cboLabelBaudRate.Items.Count; i++)
                {
                    if (this.printOption.Label.BaudRate.Equals(MPOF.ToInt(cboLabelBaudRate.Items[i].DisplayText)))
                    {
                        cboLabelBaudRate.SelectedIndex = i;
                    }
                }

                // Data Bit
                for (int i = 0; i < cboLabelDataBit.Items.Count; i++)
                {
                    if (this.printOption.Label.DataBit.Equals(MPOF.ToInt(cboLabelDataBit.Items[i].DisplayText)))
                    {
                        cboLabelDataBit.SelectedIndex = i;
                    }
                }

                // Parity
                cboLabelParity.Items.Clear();
                cboLabelParity.Items.Add(Parity.None, "None");
                cboLabelParity.Items.Add(Parity.Even, "Even");
                cboLabelParity.Items.Add(Parity.Odd, "Odd");
                cboLabelParity.Items.Add(Parity.Mark, "Mark");
                cboLabelParity.Items.Add(Parity.Space, "Space");
                for (int i = 0; i < cboLabelParity.Items.Count; i++)
                {
                    if (this.printOption.Label.Parity == ((Parity)cboLabelParity.Items[i].DataValue))
                    {
                        cboLabelParity.SelectedIndex = i;
                    }
                }

                // Stop Bit
                cboLabelStopBit.Items.Clear();
                cboLabelStopBit.Items.Add(StopBits.None, "None");
                cboLabelStopBit.Items.Add(StopBits.One, "1");
                cboLabelStopBit.Items.Add(StopBits.Two, "2");
                cboLabelStopBit.Items.Add(StopBits.OnePointFive, "1.5");
                for (int i = 0; i < cboLabelStopBit.Items.Count; i++)
                {
                    if (this.printOption.Label.StopBits == ((StopBits)cboLabelStopBit.Items[i].DataValue))
                    {
                        cboLabelStopBit.SelectedIndex = i;
                    }
                }

                // Handshake
                cboLabelHandshake.Items.Clear();
                cboLabelHandshake.Items.Add(Handshake.None, "None");
                cboLabelHandshake.Items.Add(Handshake.XOnXOff, "XOnXOff");
                cboLabelHandshake.Items.Add(Handshake.RequestToSend, "RequestToSend");
                cboLabelHandshake.Items.Add(Handshake.RequestToSendXOnXOff, "RequestToSendXOnXOff");
                for (int i = 0; i < cboLabelHandshake.Items.Count; i++)
                {
                    if (this.printOption.Label.Handshake == ((Handshake)cboLabelHandshake.Items[i].DataValue))
                    {
                        cboLabelHandshake.SelectedIndex = i;
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
