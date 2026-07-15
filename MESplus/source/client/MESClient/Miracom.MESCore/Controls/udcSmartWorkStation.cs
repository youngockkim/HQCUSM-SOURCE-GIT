using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using Miracom.CliFrx;
using Miracom.MESCore;
using System.Reflection;
using System.Collections;
using FarPoint.Win.Spread.CellType;

namespace Miracom.MESCore.Controls
{
    public partial class udcSmartWorkStation : UserControl
    {
        public udcSmartWorkStation()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        // User Control Display Direction
        private DISPLAY_DIRECTION m_display_direction;
        public DISPLAY_DIRECTION DisplayDirection
        {
            set { m_display_direction = value; }
            get { return m_display_direction; }
        }

        // Lot Id
        private string m_lot_id;
        public string LotId
        {
            set { m_lot_id = value; }
            get { return m_lot_id; }
        }

        // Lot Info
        private TRSNode m_lot_info;
        public TRSNode LotInfo
        {
            set { m_lot_info = value; }
            get { return m_lot_info; }
        }

        private int m_tran_count;
        public int TransactionCount
        {
            get { return m_tran_count; }
        }

        private struct TRAN
        {
            public string TRAN_CODE;
            public string FUNC_NAME;
            public string DISP_NAME;
            public int TRAN_SEQ;
            //public int ICON_INDEX;
            public bool IS_PROCESSED;
            public char REQUIRED_FLAG;
            public int PRIORITY;
            public char DISABLE_FLAG;
            public bool IS_TRANSACTION;
        }

        Dictionary<string, TRAN> listTran;
        #endregion

        #region " Function Definition "

        public void Init()
        {
            spdTran.ActiveSheet.RowCount = 0;
            spdTran.ActiveSheet.ColumnCount = 0;
            m_tran_count = 0;
        }

        /// <summary>
        /// View Transaction List
        /// </summary>
        /// <returns></returns>
        public bool ViewTransaction()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAN_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAN_OUT");
            TRSNode out_his = new TRSNode("VIEW_LOT_HIS_OUT");

            List<TRSNode> menu_list;
            List<TRSNode> hist_list;

            int iRow, iCol, i;

            TRAN tran_info;
            string tran_code;

            try
            {
                if (MPCF.Trim(LotId) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + " : Lot ID");
                    return false;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", LotId);

                if (MPCR.CallService("BAS", "BAS_View_Menu_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdTran.ActiveSheet.ColumnCount = 0;
                spdTran.ActiveSheet.RowCount = 0;

                menu_list = out_node.GetList("MENU_LIST");
                m_tran_count = menu_list.Count;
                if (m_tran_count > 0)
                {
                    if (GetLotHistory(ref out_his) == false)
                        return false;
                }

                listTran = new Dictionary<string, TRAN>();

                for (i = 0; i < menu_list.Count; i++)
                {
                    tran_info = new TRAN();
                    tran_info.TRAN_CODE = menu_list[i].GetString("TRAN_CODE");
                    tran_info.TRAN_SEQ = menu_list[i].GetInt("TRAN_SEQ");
                    tran_info.FUNC_NAME = menu_list[i].GetString("FUNC_NAME");
                    tran_info.DISP_NAME = menu_list[i].GetString("FUNC_DESC");
                    tran_info.REQUIRED_FLAG = menu_list[i].GetChar("REQUIRED_FLAG");
                    tran_info.PRIORITY = menu_list[i].GetInt("PRIORITY");
                    //tran_info.ICON_INDEX = menu_list[i].GetInt("ICON_INDEX");
                    tran_info.DISABLE_FLAG = menu_list[i].GetChar("DISABLE_FLAG");

                    if (tran_info.TRAN_CODE == "")
                    {
                        tran_info.TRAN_CODE = tran_info.FUNC_NAME + tran_info.TRAN_SEQ;
                        tran_info.IS_TRANSACTION = false;
                    }
                    else
                    {
                        tran_info.IS_TRANSACTION = true;
                    }

                    listTran.Add(tran_info.TRAN_CODE, tran_info);
                }

                hist_list = out_his.GetList("LIST");
                for (i = 0; i < hist_list.Count; i++)
                {
                    if (i == 0 && hist_list[i].GetChar("START_FLAG") == 'Y')
                    {
                        TRAN temp = (TRAN)listTran[MPGC.MP_TRAN_CODE_START];
                        temp.IS_PROCESSED = true;
                        listTran[MPGC.MP_TRAN_CODE_START] = temp;
                    }

                    tran_code = hist_list[i].GetString("TRAN_CODE");
                    if (listTran.ContainsKey(tran_code) == true)
                    {
                        TRAN temp = (TRAN)listTran[tran_code];
                        temp.IS_PROCESSED = true;
                        listTran[tran_code] = temp;
                    }
                }

                if (DisplayDirection == DISPLAY_DIRECTION.DISPLAY_LANDSCAPE)
                {
                    spdTran.ActiveSheet.RowCount = 1;
                }
                else
                {
                    spdTran.ActiveSheet.ColumnCount = 1;
                }

                int iPrevPriority = 0;
                foreach (string key in listTran.Keys)
                {
                    TRAN tran = (TRAN)listTran[key];
                    ButtonCellType btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = tran.DISP_NAME;
                    btnCell.WordWrap = true;

                    // Landspace => Increase Column
                    if (DisplayDirection == DISPLAY_DIRECTION.DISPLAY_LANDSCAPE)
                    {
                        // Priority Group별로 끊기
                        if (tran.PRIORITY == 0) { }// do not anything
                        else if (iPrevPriority != tran.PRIORITY)
                        {
                            iPrevPriority = tran.PRIORITY;

                            iCol = spdTran.ActiveSheet.ColumnCount;
                            if (iCol != 0)
                            {
                                spdTran.ActiveSheet.ColumnCount++;
                                spdTran.ActiveSheet.Cells[0, iCol].Text = "▶";
                                spdTran.ActiveSheet.Cells[0, iCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                spdTran.ActiveSheet.Cells[0, iCol].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                            }
                        }

                        iCol = spdTran.ActiveSheet.ColumnCount;
                        spdTran.ActiveSheet.ColumnCount++;

                        spdTran.ActiveSheet.Columns[iCol].Width = 100;
                        spdTran.ActiveSheet.Rows[0].Height = 40;

                        if (tran.IS_PROCESSED)
                        {
                            btnCell.ButtonColor = Color.Lime;
                            btnCell.UseVisualStyleBackColor = false;
                        }
                        if (tran.REQUIRED_FLAG == 'Y')
                        {
                            spdTran.ActiveSheet.Columns[iCol].Font = new Font(this.Font, FontStyle.Bold);
                        }
                        if (tran.DISABLE_FLAG == 'Y')
                        {
                            spdTran.ActiveSheet.Columns[iCol].Locked = true;
                        }
                        spdTran.ActiveSheet.Cells[0, iCol].CellType = btnCell;
                        spdTran.ActiveSheet.Cells[0, iCol].Tag = tran;
                    }
                    else // Portrait => Increase Row
                    {
                        // Priority Group별로 끊기
                        if (tran.PRIORITY == 0) { }// do not anything
                        else if (iPrevPriority != tran.PRIORITY)
                        {
                            iPrevPriority = tran.PRIORITY;
                            iRow = spdTran.ActiveSheet.RowCount;

                            if (iRow != 0)
                            {
                                spdTran.ActiveSheet.RowCount++;
                                spdTran.ActiveSheet.Cells[iRow, 0].Text = "▼";
                                spdTran.ActiveSheet.Cells[iRow, 0].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                spdTran.ActiveSheet.Cells[iRow, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            }
                        }

                        iRow = spdTran.ActiveSheet.RowCount;
                        spdTran.ActiveSheet.RowCount++;

                        spdTran.ActiveSheet.Rows[iRow].Height = 40;
                        spdTran.ActiveSheet.Columns[0].Width = 100;

                        if (tran.IS_PROCESSED)
                        {
                            btnCell.ButtonColor = Color.Lime;
                            btnCell.UseVisualStyleBackColor = false;
                        }
                        if (tran.REQUIRED_FLAG == 'Y')
                        {
                            spdTran.ActiveSheet.Rows[iRow].Font = new Font(this.Font, FontStyle.Bold);
                        }
                        if (tran.DISABLE_FLAG == 'Y')
                        {
                            spdTran.ActiveSheet.Rows[iRow].Locked = true;
                        }
                        spdTran.ActiveSheet.Cells[iRow, 0].CellType = btnCell;
                        spdTran.ActiveSheet.Cells[iRow, 0].Tag = tran;
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
        /// View function information and Show function window
        /// </summary>
        /// <param name="s_func_name"></param>
        /// <returns></returns>
        private bool ViewFunction(TRAN tran_info)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_OUT");

            string[] s_tmp;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FUNC_NAME", tran_info.FUNC_NAME);

                if (MPCR.CallService("SEC", "SEC_View_Function", in_node, ref out_node) == false)
                {
                    return false;
                }

                string sAssemFile = MPCF.Trim(out_node.GetString("ASSEMBLY_FILE"));
                string sAssemName = MPCF.Trim(out_node.GetString("ASSEMBLY_NAME"));

                s_tmp = sAssemName.Split('.');

                object obj = MPCF.GetChildForm(MPGV.gfrmMDI, s_tmp[s_tmp.Length - 1], true);
                if (obj == null)
                {
                    string s_dir = Application.StartupPath;
                    Assembly asm = Assembly.LoadFrom(s_dir + "\\" + sAssemFile);
                    obj = asm.CreateInstance(sAssemName);
                    if (obj == null) return false;

                    ((Form)obj).MdiParent = MPGV.gfrmMDI;
                    ((Form)obj).Tag = tran_info.FUNC_NAME;

                    if (MPCR.CheckSecurityFormControl((Form)obj) == false)
                    {
                        return false;
                    }

                    ((Form)obj).StartPosition = FormStartPosition.CenterParent;
                    ((Form)obj).Show();
                }

                try
                {
                    Control focus_control = null;
                    focus_control = (Control)obj.GetType().InvokeMember("GetFisrtFocusItem", BindingFlags.InvokeMethod, null, obj, null);
                    focus_control.Focus();
                }
                catch (MissingMethodException)
                {
                    return false;
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
        /// Get lot history in current(last) operation
        /// </summary>
        /// <param name="s_lot_id"></param>
        /// <param name="out_node"></param>
        /// <returns></returns>
        private bool GetLotHistory(ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("HISTORY_IN");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '5';
                in_node.AddString("LOT_ID", LotId);

                if (MPCR.CallService("WIP", "WIP_View_Lot_History", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition(TRAN tran_info)
        {
            TRAN tran;

            try
            {
                if (tran_info.TRAN_CODE == MPGC.MP_TRAN_CODE_END && listTran.ContainsKey(MPGC.MP_TRAN_CODE_START) == true)
                {
                    tran = (TRAN)listTran[MPGC.MP_TRAN_CODE_START];
                    if (tran.REQUIRED_FLAG == 'Y' && tran.IS_PROCESSED == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(329));
                        return false;
                    }
                }

                if (tran_info.PRIORITY > 1)
                {
                    foreach (string key in listTran.Keys)
                    {
                        tran = (TRAN)listTran[key];
                        if (tran_info.TRAN_CODE == key) continue;       // 동일한 트랜잭션이면 확인 할 필요없음
                        if (tran.PRIORITY > 0 && tran_info.PRIORITY - 1 == tran.PRIORITY)    // 이전 Priority가 완료되어 있는지 확인해야함
                        {
                            //sTranCode = tran.TRAN_CODE;
                            //// 이전 Priority가 Required이고 완료되었으면 일단 true 예약 
                            //if (tran.REQUIRED_FLAG == 'Y' && tran.IS_PROCESSED == true)
                            //    bReserve = true;
                            //// 이전 Priority가 Required가 아니어도 완료되어 있으면 일단 true 예약
                            //else if (tran.IS_PROCESSED == true)
                            //    bReserve = true;
                            // 이전 Priority가 Required인데 완료가 완됐으면 바로 아웃
                            if (tran.REQUIRED_FLAG == 'Y' && tran.IS_PROCESSED == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(340) + " : [" + tran_info.DISP_NAME + "]");
                                return false;
                            }
                        }
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
            
        #endregion

        private void udcSmartWorkStation_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdTran);

            if (DisplayDirection == DISPLAY_DIRECTION.DISPLAY_LANDSCAPE)
                this.MinimumSize = new Size(this.MinimumSize.Width, 60);
            else
                this.MinimumSize = new Size(160, this.MinimumSize.Height);
        }

        private void spdTran_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (spdTran.ActiveSheet.Cells[e.Row, e.Column].Tag == null) return;
            
            TRAN tran_info = (TRAN)spdTran.ActiveSheet.Cells[e.Row, e.Column].Tag;

            if (CheckCondition(tran_info) == false) return;
            ViewFunction(tran_info);

            if (tran_info.IS_TRANSACTION == false)
            {
                FarPoint.Win.Spread.CellType.ButtonCellType btn = (FarPoint.Win.Spread.CellType.ButtonCellType)spdTran.ActiveSheet.Cells[e.Row, e.Column].CellType;
                btn.ButtonColor = Color.Lime;
                btn.UseVisualStyleBackColor = false;

                spdTran.ActiveSheet.Cells[e.Row, e.Column].CellType = btn;

                spdTran.Refresh();
            }
        }
    }
}
