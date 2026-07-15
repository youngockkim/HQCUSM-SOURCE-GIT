using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using Miracom.UI;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using FarPoint.Win.Spread;
using Miracom.UI.Controls.MCCodeView;
using System.Threading;
using System.Media;
using System.IO;

namespace SOI.OIFrx
{

    public partial class UIBaseForm05 : BaseForm02
    {
        public UIBaseForm05()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        /// <summary>
        /// Tran Code
        /// </summary>
        public enum TranMode
        {
            Save, Delete, Start, Update, End, ExcelEnd, Print, View
        }
        #endregion

        #region " Variable Definition "
        #endregion

        #region " Properties "
        public string m_ViewSql { get; set; }

        #endregion

        #region " Function Definition "
        /// <summary>
        /// this.Control Initialize
        /// </summary>
        /// <param name="colControl"></param>
        /// <returns></returns>
        public bool InitControl(System.Windows.Forms.Control.ControlCollection colControl)
        {
            Control l_Control;

            try
            {
                l_Control = null;

                foreach (Control tempLoopVar_l_Control in colControl)
                {
                    l_Control = tempLoopVar_l_Control;
                    if (l_Control is Panel)
                    {
                        InitControl(l_Control.Controls);
                    }
                    else if (l_Control is GroupBox)
                    {
                        InitControl(l_Control.Controls);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Object Clone
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ObjectClone(Control ctl, object obj)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        /// <summary>
        /// initialze Condition
        /// </summary>
        /// <returns></returns>
        public bool initCondition(object objs)
        {
            try
            {
                MOGV.gsQueryStatementLong = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public string ViewSQL()
        {
            return m_ViewSql;
        }
        /// <summary>
        /// RealTime Caption Change
        /// </summary>
        /// <returns></returns>
        public bool CaptionChange()
        {
            try
            {
                MPCF.ConvertMessage(this.Controls);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Custom Caption Change
        /// </summary>
        /// <returns></returns>
        public bool CaptionChange(System.Windows.Forms.Control.ControlCollection colControl)
        {
            try
            {
                MPOF.ConvertMessage(this.Controls);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// DataTable Column을 생성하는 함수입니다.
        /// </summary>
        /// <param name="sDtName"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public DataTable CreateDataTable(string sDtName, object[,] oCol)
        {
            DataTable dt = new DataTable(sDtName);

            try
            {
                string sKey = string.Empty;
                DataColumn[] dc = null;
                int i = 0;

                if (oCol != null && oCol.GetLongLength(0) > 0)
                {
                    for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                    {
                        sKey = oCol[iCol, 0].ToString();
                        dt.Columns.Add(sKey, Type.GetType(oCol[iCol, 1].ToString()));
                        if (Boolean.Parse(oCol[iCol, 2].ToString()))
                        {
                            ++i;
                            dc[i].ColumnName = sKey;
                        }
                    }
                    if (i > 0)
                    {
                        dt.PrimaryKey = dc;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return dt;
        }
        /// <summary>
        /// Client IP
        /// </summary>
        public static string Client_IP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                foreach (IPAddress ipaddress in host.AddressList)
                {
                    if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = ipaddress.ToString();
                        break;
                    }
                }
                return ClientIP;
            }
        }
        public static string GetMACAddress
        {
            get
            {
                string MacAddress = string.Empty;
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.NetworkInterfaceType.ToString().Equals("Ethernet"))
                    {
                        PhysicalAddress pa = adapter.GetPhysicalAddress();
                        if (pa != null)
                        {
                            if (!string.IsNullOrEmpty(pa.ToString()))
                            {
                                MacAddress = pa.ToString();
                                break;
                            }
                        }
                    }
                }

                return MacAddress;
            }
        }

        #endregion

        #region [Event Handler]
        /// <summary>
        /// EventHandler
        /// </summary>
        private void EventHandler()
        {
        }
        #endregion

        #region " Form Event Definition "
        /// <summary>
        /// Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIBaseForm05_Activated(object sender, EventArgs e)
        {
            try
            {
                MOGV.gsQueryStatementLong = Environment.NewLine + "#####[ " + DateTime.Now.ToString() + " ]####[ " + this.Name.ToString() + " ]####################\r\n";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIBaseForm05_Load(object sender, EventArgs e)
        {
            try
            {
                MOGV.gsQueryStatementLong = Environment.NewLine + "#####[ " + DateTime.Now.ToString() + " ]####[ " + this.Name.ToString() + " ]####################\r\n";
                EventHandler();
                lblTopTitle.Text = this.Text;
                lblUserId.Text = MPGV.gsUserID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
            }
        }
        private void UIBaseForm05_FormClosing(object sender, FormClosingEventArgs e)
        {
            MiscUtil.HideStatusMessage();
        }
        private void UIBaseForm05_FormClosed(object sender, FormClosedEventArgs e)
        {
            MiscUtil.HideStatusMessage();
        }
        #endregion

        #region " Event Definition "
        #region [Control Event]

        /// <summary>
        /// Button Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="sQueryId">SQL ID</param>
        /// <param name="lstCondition">Agument</param>
        /// <param name="iHColCnt">ColumnHeader Count</param>
        public void cdvView_ButtonPress(object sender, EventArgs e, string sQueryId, string[] lstCondition, int iHColCnt)
        {
            Custom_MCCodeView cdvView = (Custom_MCCodeView)sender;

            try
            {
                if (sQueryId.Trim().Equals("")) return;
                if (iHColCnt.ToString().Equals("")) return;

                cdvView.Init();
                MPCF.InitListView(cdvView.GetListView);
                cdvView.Columns.Add("_ID", 50, System.Windows.Forms.HorizontalAlignment.Left);
                if (iHColCnt > 0) cdvView.Columns.Add("_DESC", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvView.SelectedSubItemIndex = 0;
                if (iHColCnt > 0) cdvView.DisplaySubItemIndex = 1;

                if (MPOF.MFillData(cdvView.GetListView, sQueryId, lstCondition) == false)
                {
                    return;
                }
                //EmptyRowTop
                if (cdvView.InsertEmptyRow(0, 1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /// <summary>
        /// SELECTED ITEM CHANGED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvView_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e, int iHColCnt)
        {
            Custom_MCCodeView cdvView = (Custom_MCCodeView)sender;

            cdvView.Init();

            cdvView.Text = e.SelectedItem.SubItems[0].Text;
            if (iHColCnt > 0) cdvView.DescText = e.SelectedItem.SubItems[1].Text;
            if (iHColCnt > 0) cdvView.DisplayText = e.SelectedItem.SubItems[0].Text;

        }
        #endregion
        #region [Spread Event]

        #endregion
        #endregion

    }
}
