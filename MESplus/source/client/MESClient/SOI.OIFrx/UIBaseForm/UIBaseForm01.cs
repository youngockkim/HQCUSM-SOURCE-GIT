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

namespace SOI.OIFrx
{

    public partial class UIBaseForm01 : TranForm02
    {
        public UIBaseForm01()
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
                if (ctl is System.Windows.Forms.GroupBox)
                {
                    if (((GroupBox)ctl).Name.ToString().Equals("grpTranTop"))
                    {
                        if (obj is System.Windows.Forms.DateTimePicker)
                        {
                            if (((DateTimePicker)obj).Name.ToString().Equals("dtpTranMonth"))
                            {
                                ((DateTimePicker)obj).Format = DateTimePickerFormat.Custom;
                                ((DateTimePicker)obj).CustomFormat = "yyyy-MM";
                                ((DateTimePicker)obj).ShowUpDown = true;
                                ((DateTimePicker)obj).Value = DateTime.Now;
                            }
                        }
                    }
                }

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
                this.btnClose.BringToFront();

                foreach (Control ctlChild in this.grpTranTop.Controls)
                {
                    Object obj = ctlChild as object;

                    if (obj is MCCodeView)
                    {
                        if (((MCCodeView)obj).Name.ToString().Equals("cdvMatId"))
                        {
                            ((MCCodeView)obj).Init();
                        }
                    }
                    else if (obj is CheckBox)
                    {
                        if (((CheckBox)obj).Name.ToString().Equals("chkEa"))
                        {
                            ((CheckBox)obj).Checked = true;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                //pnlTranCenter
                foreach (Control ctlChild in this.pnlTranCenter.Controls)
                {
                    Object obj = ctlChild as object;

                    if (obj is udcSpread)
                    {
                        if (((udcSpread)obj).Name.ToString().Equals("udcSpread1"))
                        {
                            ((udcSpread)obj).spdData.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
                            ((udcSpread)obj).spdData.ColumnSplitBoxPolicy = SplitBoxPolicy.Never;
                            ((udcSpread)obj).spdData.RowSplitBoxPolicy = SplitBoxPolicy.Never;
                            ((udcSpread)obj).spdData.ActiveSheet.HorizontalGridLine = new GridLine(GridLineType.None);
                            ((udcSpread)obj).spdData.ActiveSheet.VerticalGridLine = new GridLine(GridLineType.None);
                            ((udcSpread)obj).spdData.BorderStyle = BorderStyle.FixedSingle;
                            ((udcSpread)obj).spdData.ActiveSheet.AlternatingRows[0].BackColor = Color.Empty;
                            ((udcSpread)obj).spdData.ActiveSheet.AlternatingRows[1].BackColor = Color.WhiteSmoke;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
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
        /// ViewDataText
        /// </summary>
        public void ViewDataText(udcSpread spd, List<string> lstInfo, List<string> lstnfo1, out DataTable dt)
        {
            ViewDataText(spd, lstInfo, lstnfo1, true, out dt);
        }
        public void ViewDataText(udcSpread ucSpd, List<string> lstInfo, List<string> lstInfo1, bool bMsg, out DataTable dt)
        {
            UCSpread sprMaker1 = new UCSpread();
            sprMaker1.TargetSpread = ucSpd.spdData;
            sprMaker1.TargetSheet = ucSpd.spdData.ActiveSheet;
            DataTable _dt = new DataTable();

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                sprMaker1.ViewDataText(ucSpd, lstInfo, lstInfo1, ViewSQL(), bMsg, out _dt);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                dt = _dt;
                return;
            }
            finally
            {
                dt = _dt;
                Cursor.Current = Cursors.Default;
            }
        }
        /// <summary>
        /// 참조 ViewData
        /// </summary>
        public bool ViewDataText(List<string> lstInfo, List<string> lstnfo1, out DataTable dt)
        {
            return ViewDataText(lstInfo, lstnfo1, true, out dt);
        }
        public bool ViewDataText(List<string> lstInfo, List<string> lstInfo1, bool bMsg, out DataTable dt)
        {
            UCSpread sprMaker1 = new UCSpread();
            DataTable _dt = new DataTable();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                sprMaker1.ViewDataText(lstInfo, lstInfo1, ViewSQL(), bMsg, out _dt);

                if (_dt != null && _dt.Rows.Count > 0)
                {
                    dt = _dt;
                    return true;
                }
                else
                {
                    _dt.Rows.Clear();
                    dt = _dt;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                dt = _dt;
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// ViewData UTF-8
        /// </summary>
        public void ViewData(udcSpread spd, List<string> lstInfo, List<string> lstnfo1, out DataTable dt)
        {
            ViewData(spd, lstInfo, lstnfo1, true, out dt);
        }
        public void ViewData(udcSpread ucSpd, List<string> lstInfo, List<string> lstInfo1, bool bMsg, out DataTable dt)
        {
            UCSpread sprMaker1 = new UCSpread();
            sprMaker1.TargetSpread = ucSpd.spdData;
            sprMaker1.TargetSheet = ucSpd.spdData.ActiveSheet;
            DataTable _dt = new DataTable();

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                sprMaker1.ViewData(ucSpd, lstInfo, lstInfo1, ViewSQL(), bMsg, out _dt);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                dt = _dt;
                return;
            }
            finally
            {
                dt = _dt;
            }
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// 참조 ViewData UTF-8
        /// </summary>
        public bool ViewData(List<string> lstInfo, List<string> lstnfo1, out DataTable dt)
        {
            return ViewData(lstInfo, lstnfo1, true, out dt);
        }
        public bool ViewData(List<string> lstInfo, List<string> lstInfo1, bool bMsg, out DataTable dt)
        {
            UCSpread sprMaker1 = new UCSpread();
            DataTable _dt = new DataTable();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                sprMaker1.ViewData(lstInfo, lstInfo1, ViewSQL(), bMsg, out _dt);

                if (_dt != null && _dt.Rows.Count > 0)
                {
                    dt = _dt;
                    return true;
                }
                else
                {
                    _dt.Rows.Clear();
                    dt = _dt;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                dt = _dt;
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// Condition View List
        /// </summary>
        /// <param name="control"></param>
        /// <param name="c_step"></param>
        /// <param name="sMatGrp"></param>
        /// <param name="sFilter"></param>
        /// <param name="parentNode"></param>
        /// <param name="sExtFactory"></param>
        /// <returns></returns>
        public bool ViewLIST(Control control, char c_step, List<string> lstInfo, string sFilter, TreeNode parentNode, string sExtFactory)
        {
            TRSNode in_node = new TRSNode("Sql_In");
            TRSNode out_node = new TRSNode("Sql_Out");
            StringBuilder sb;
            ArrayList a_list = new ArrayList();
            //int i;
            ListViewItem itmX;
            //TreeNode nodeX;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            sb = new StringBuilder();

            in_node.AddString("SQL", sb.AppendLine(ViewSQL().ToString()).ToString());

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                if (!(parentNode == null))
                {
                    parentNode.Nodes.Clear();
                }
                else
                {
                    MPCF.ClearList(control, true);
                }
            }

            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }
            for (int j = 0; j < out_node.GetList(1).Count; j++)
            {
                if (control is ListView)
                {
                    itmX = new ListViewItem(out_node.GetList("ROWS")[j].GetList("COLS")[0].GetString("DATA"));

                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmX.SubItems.Add(out_node.GetList("ROWS")[j].GetList("COLS")[1].GetString("DATA"));
                    }
                    ((ListView)control).Items.Add(itmX);
                }
            }

            return true;

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

        #region " Form Event Definition "
        /// <summary>
        /// Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIBaseForm01_Activated(object sender, EventArgs e)
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
        private void UIBaseForm01_Load(object sender, EventArgs e)
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
        #endregion

        #region " Event Definition "

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
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvView = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

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
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvView = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvView.Init();

            cdvView.Text = e.SelectedItem.SubItems[0].Text;
            if (iHColCnt > 0) cdvView.DescText = e.SelectedItem.SubItems[1].Text;
            if (iHColCnt > 0) cdvView.DisplayText = e.SelectedItem.SubItems[0].Text;

        }
        /// <summary>
        ///ButtonPress Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvView_ButtonPress(object sender, EventArgs e, List<string> lstCondition)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvView = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            try
            {
                cdvView.Init();
                MPCF.InitListView(cdvView.GetListView);
                cdvView.Columns.Add("_ID", 50, System.Windows.Forms.HorizontalAlignment.Left);
                cdvView.Columns.Add("_DESC", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvView.SelectedSubItemIndex = 0;
                cdvView.DisplaySubItemIndex = 1;

                if (this.ViewLIST(cdvView.GetListView, '1', lstCondition, string.Empty, null, string.Empty) == false)
                {
                    return;
                }

                if (cdvView.AddEmptyRow(1) == false)
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
        public void cdvView_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvView = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvView.Init();

            cdvView.Text = e.SelectedItem.SubItems[0].Text;
            cdvView.DescText = e.SelectedItem.SubItems[1].Text;
            cdvView.DisplayText = e.SelectedItem.SubItems[1].Text;

        }
        /// <summary>
        /// TextBox Text Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvView_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvView = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (cdvView.DisplayText.Trim().Equals(""))
            {
                cdvView.Text = "";
                cdvView.DescText = "";
            }
        }
        /// <summary>
        /// GCM CODE BUTTON PRESS EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcmCode_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            try
            {
                cdvGcm.Init();
                MPCF.InitListView(cdvGcm.GetListView);
                cdvGcm.Columns.Add("_ID", 50, System.Windows.Forms.HorizontalAlignment.Left);
                cdvGcm.Columns.Add("_DESC", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvGcm.SelectedSubItemIndex = 0;
                cdvGcm.DisplaySubItemIndex = 1;

                if (BASLIST.ViewGCMDataList(cdvGcm.GetListView, '1', cdvGcm.TextBoxToolTipText.Trim()) == false)
                {
                    return;
                }
                cdvGcm.InsertEmptyRow(0, 1);

                if (cdvGcm.AddEmptyRow(1) == false)
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
        /// GCM SELECTED ITEM CHANGED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcmCode_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvGcm.Init();

            cdvGcm.Text = e.SelectedItem.SubItems[0].Text;
            cdvGcm.DescText = e.SelectedItem.SubItems[1].Text;
            cdvGcm.DisplayText = e.SelectedItem.SubItems[0].Text;
        }
        /// <summary>
        /// TextBox Text Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcmCode_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            if (cdvGcm.DisplayText.Trim().Equals(""))
            {
                cdvGcm.Text = "";
                cdvGcm.DescText = "";
            }
        }
        /// <summary>
        /// GCM CODE BUTTON PRESS EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcm_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            try
            {
                cdvGcm.Init();
                MPCF.InitListView(cdvGcm.GetListView);
                cdvGcm.Columns.Add("_ID", 50, System.Windows.Forms.HorizontalAlignment.Left);
                cdvGcm.Columns.Add("_DESC", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvGcm.SelectedSubItemIndex = 0;
                cdvGcm.DisplaySubItemIndex = 1;

                if (BASLIST.ViewGCMDataList(cdvGcm.GetListView, '1', cdvGcm.TextBoxToolTipText.Trim()) == false)
                {
                    return;
                }
                cdvGcm.InsertEmptyRow(0, 1);

                if (cdvGcm.AddEmptyRow(1) == false)
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
        /// GCM SELECTED ITEM CHANGED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcm_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvGcm.Init();

            cdvGcm.Text = e.SelectedItem.SubItems[0].Text;
            cdvGcm.DescText = e.SelectedItem.SubItems[1].Text;
            cdvGcm.DisplayText = e.SelectedItem.SubItems[1].Text;
        }
        /// <summary>
        /// TextBox Text Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cdvGcm_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvGcm = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            if (cdvGcm.DisplayText.Trim().Equals(""))
            {
                cdvGcm.Text = "";
                cdvGcm.DescText = "";
            }
        }

        #region [Spread Event]

        /// <summary>
        /// Spread MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void spdData_MouseMove(object sender, MouseEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            FarPoint.Win.Spread.Model.CellRange cRange = fpSpd.GetCellFromPixel(0, 0, e.X, e.Y);

            if (cRange.Row > -1)
            {
                if (cRange.Column > -1)
                {
                    if (fpSpd.ActiveSheet.Columns[cRange.Column].Locked)
                    {
                        fpSpd.EditModePermanent = false;
                    }
                    else
                    {
                        fpSpd.EditModePermanent = true;
                        fpSpd.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Hand);
                    }
                }
            }

        }
        #endregion


        private void UIBaseForm01_FormClosed(object sender, FormClosedEventArgs e)
        {
            MiscUtil.HideStatusMessage();
        }
        #endregion

        private void UIBaseForm01_FormClosing(object sender, FormClosingEventArgs e)
        {
            MiscUtil.HideStatusMessage();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UIBaseForm01_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyValue != 8)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }

        }

    }
}
