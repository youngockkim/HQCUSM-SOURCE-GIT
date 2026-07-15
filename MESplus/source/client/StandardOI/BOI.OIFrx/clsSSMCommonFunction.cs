#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SOI.CliFrx;
using System.Runtime.InteropServices;
using Miracom.TRSCore;
using SOI.OIFrx.SOIModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Globalization;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIControls;
using System.Management;
using System.Security.Principal;
using Infragistics.Win.UltraWinSchedule;
using System.Drawing;
using System.Net;
using FarPoint.Win.Spread;
using System.Xml.Linq;
using Infragistics.Win.Misc;
using SOI.OIFrx.SOIThemes;
using BOI.OIFrx.BOIPopup;
using SOI.OIFrx.SOIBaseForm;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.IO.Ports;
using System.IO.Compression;
using SOI.OIFrx;

using SOI.DNM;

namespace BOI.OIFrx
{
    public class BICF : CMNF
    {
        #region Property

        private static frmLargeKeyPad keyPad = null;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private static List<string> randomChannelValues = new List<string>();

        #endregion

        public BICF()
        {
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        public static void ShowKeyPad(Point MousePosition, int width, int height, Control Updatectrl)
        {
            try
            {                
                if (keyPad == null                                          
                    || keyPad.IsDisposed == true)
                {                    
                    keyPad = new frmLargeKeyPad();
                    keyPad.Owner = MPGV.gfrmMDI;

                    Point controlLocation = MousePosition;

                    keyPad.Left = controlLocation.X + width - keyPad.Width;
                    keyPad.Top = controlLocation.Y + height + 3;

                    // Mouse 클릭 위치를 확인
                    Rectangle rect = Screen.GetWorkingArea(Control.MousePosition);

                    // 우측 하단에 표시되는 경우 컨트롤 상단에 표시.
                    // 우측화면 넘어 컨트롤 자체가 보이지 않는 경우는 없다고 가정.
                    if (controlLocation.Y + keyPad.Height > rect.Top + rect.Height)
                    {
                        keyPad.Left = controlLocation.X + width - keyPad.Width;
                        keyPad.Top = controlLocation.Y - keyPad.Height - 3;
                    }

                    keyPad.Tag = Updatectrl;
                    keyPad.ShowDialog();
                    //keyPad.Show();
                    keyPad.TopLevel = true;


                    Updatectrl.Update();
                }
            }
            finally
            {
                if (keyPad != null)
                {
                    keyPad.Dispose();
                }
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedMenuInfo"></param>
        /// 
        public static void OpenMenu(string sFuncName)
        {
            OpenMenu(sFuncName, "");
        }
        public static void OpenMenu(string sFuncName, string s_args)
        {            
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_DETAIL_OUT");

            MenuInfoTag selectedMenuInfo;
            Control cFocusControl;                
            
            try
            {
                // Favorite Menu 조회
                MPGV.gIMdiForm.GetFavFunctionList();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", sFuncName);

                if (MPCF.CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node) == false)
                {
                    return;
                }

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.c_func_type = out_node.GetChar("FUNC_TYPE");
                selectedMenuInfo.s_assembly_file = out_node.GetString("ASSEMBLY_FILE");
                selectedMenuInfo.s_assembly_name = out_node.GetString("ASSEMBLY_NAME");
                selectedMenuInfo.s_func_name = out_node.GetString("FUNC_NAME");
                selectedMenuInfo.s_func_desc = out_node.GetString("FUNC_DESC");
                selectedMenuInfo.s_args = s_args;

                cFocusControl = MPGV.gIMdiForm.OpenMenu(selectedMenuInfo);
                if (cFocusControl != null)
                {
                    cFocusControl.Focus();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage("OpenMenu()\n" + ex.Message);
            }
        }

        public static bool CheckSpreadCell(FarPoint.Win.Spread.FpSpread spdData, int i_ColHeaderRow, int i_Col, bool b_isColHeaderCheckBox)
        {
            return CheckSpreadCell(spdData, i_ColHeaderRow, i_Col, true, b_isColHeaderCheckBox);
        }

        public static bool CheckSpreadCell(FarPoint.Win.Spread.FpSpread spdData, int i_Col, bool b_checked)
        {
            return CheckSpreadCell(spdData, 0, i_Col, b_checked, false);
        }

        /// <summary>
        /// Spread 전체 선택
        /// </summary>
        /// <param name="spdData"></param>
        /// <param name="i_ColHeaderRow"></param>
        /// <param name="i_Col"></param>
        /// <param name="b_checked"></param>
        /// <param name="b_isColHeaderCheckBox"></param>
        /// <returns></returns>
        public static bool CheckSpreadCell(FarPoint.Win.Spread.FpSpread spdData, int i_ColHeaderRow, int i_Col, bool b_checked, bool b_isColHeaderCheckBox)
        {
            try
            {
                if (b_isColHeaderCheckBox)
                {
                    if (spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                    {
                        spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Locked = false;

                        if (spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value == null ||
                        spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value.Equals("") ||
                        spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value.Equals(false))
                        {
                            spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value = true;
                        }
                        else
                        {
                            spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value = !Convert.ToBoolean(spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value);
                        }

                        for (int i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            spdData.ActiveSheet.Cells[i, i_Col].Value = spdData.ActiveSheet.ColumnHeader.Cells[i_ColHeaderRow, i_Col].Value;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        spdData.ActiveSheet.Cells[i, i_Col].Value = b_checked;
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 지정한 Cell로 포커스 이동
        /// </summary>
        /// <param name="fps"></param>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        public static void SetPosition(FarPoint.Win.Spread.FpSpread fps, int iRow, int iCol)
        {
            fps.ActiveSheet.ActiveRowIndex = iRow;
            fps.ActiveSheet.ActiveColumnIndex = iCol;
            fps.ActiveSheet.Models.Selection.SetSelection(iRow, 0, 1, fps.ActiveSheet.ColumnCount);
            fps.ShowCell(fps.GetActiveRowViewportIndex()
                            , fps.GetActiveColumnViewportIndex()
                            , iRow
                            , 0
                            , FarPoint.Win.Spread.VerticalPosition.Center
                            , FarPoint.Win.Spread.HorizontalPosition.Left);
        }

        /// <summary>
        /// 라인 그룹 조회(권한 그룹 적용)
        /// </summary>
        /// <param name="cdvLineGroup"></param>
        /// <returns></returns>
        public static bool ViewLineGroup(BOI.OIFrx.BOIControls.BOICodeView cdvLineGroup)
        {
            return ViewLineGroup(cdvLineGroup, "");
        }

        public static bool ViewLineGroup(BOI.OIFrx.BOIControls.BOICodeView cdvLineGroup, string useManagementFlag)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            string sViewId = string.Empty;

            try
            {
                if (useManagementFlag != "")
                {
                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "LINE_CMF_2";
                    dvcArgu[1].sCondition_Value = useManagementFlag;

                    dvcArgu[2].sCondtion_ID = "USER_ID";
                    dvcArgu[2].sCondition_Value = MPGV.gsUserID;

                    sViewId = "COM0000-026";
                }
                else
                {
                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "TABLE_NAME";
                    dvcArgu[1].sCondition_Value = BIGC.B_GCM_B_LINE_GROUP;

                    dvcArgu[2].sCondtion_ID = "USER_ID";
                    dvcArgu[2].sCondition_Value = MPGV.gsUserID;

                    sViewId = "COM0000-012";
                }

                // CodeView Column Header Setup
                string[] header = new string[] { "Line Group", "Line Group Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "LINE_GROUP", "DATA_1" };

                // Show
                cdvLineGroup.Text = cdvLineGroup.Show(cdvLineGroup, "Line Group", sViewId, dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvLineGroup.Text) != "")
                {
                    if (cdvLineGroup.returnDatas != null && cdvLineGroup.returnDatas.Count > 0)
                    {
                        cdvLineGroup.Tag = cdvLineGroup.returnDatas[0];
                    }
                    else
                    {
                        cdvLineGroup.Tag = "";
                    }
                }
                else
                {
                    cdvLineGroup.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 라인 조회(권한 그룹 적용)
        /// </summary>
        /// <param name="cdvLine"></param>
        /// <param name="s_line_group"></param>
        /// <returns></returns>

        public static bool ViewLine(BOI.OIFrx.BOIControls.BOICodeView cdvLine, string s_line_group)
        {
            return ViewLine(cdvLine, s_line_group, "");
        }

        public static bool ViewLine(BOI.OIFrx.BOIControls.BOICodeView cdvLine, string s_line_group, string useManagementFlag)
        {
            TPDR.DirectViewCond[] dvcArgu = null;
            string sViewId = string.Empty;

            try
            {
                if (useManagementFlag != "")
                {
                    dvcArgu = new TPDR.DirectViewCond[4];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "LINE_GROUP";
                    dvcArgu[1].sCondition_Value = s_line_group;

                    dvcArgu[2].sCondtion_ID = "USER_ID";
                    dvcArgu[2].sCondition_Value = MPGV.gsUserID;

                    dvcArgu[3].sCondtion_ID = "LINE_CMF_2";
                    dvcArgu[3].sCondition_Value = useManagementFlag;

                    sViewId = "COM0000-027";
                }
                else
                {
                    dvcArgu = new TPDR.DirectViewCond[3];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "LINE_GROUP";
                    dvcArgu[1].sCondition_Value = s_line_group;

                    dvcArgu[2].sCondtion_ID = "USER_ID";
                    dvcArgu[2].sCondition_Value = MPGV.gsUserID;

                    sViewId = "COM0000-013";
                }


                // CodeView Column Header Setup
                string[] header = new string[] { "Line", "Line Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "LINE_ID", "LINE_DESC" };

                // Show
                cdvLine.Text = cdvLine.Show(cdvLine, "Line", sViewId, dvcArgu, display, header, "LINE_DESC", -1);

                if (MPCF.Trim(cdvLine.Text) != "")
                {
                    if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                    {
                        cdvLine.Tag = cdvLine.returnDatas[0];
                    }
                    else
                        cdvLine.Tag = "";
                }
                else
                    cdvLine.Tag = "";
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        public static bool ViewResource(BOI.OIFrx.BOIControls.BOICodeView cdvResource, string s_line_group, string s_line, string s_oper)
        {
            return ViewResource(cdvResource, s_line_group, s_line, s_oper, "N");
        }

        /// <summary>
        /// 설비 조회(권한 그룹 적용) - 라인 그룹, 라인
        /// </summary>
        /// <param name="cdvResource"></param>
        /// <param name="s_line_group"></param>
        /// <param name="s_line"></param>
        /// <returns></returns>
        public static bool ViewResource(BOI.OIFrx.BOIControls.BOICodeView cdvResource, string s_line_group, string s_line, string s_oper, string s_mold_pack_flag)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            string s_view_id = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_GROUP";
                dvcArgu[1].sCondition_Value = s_line_group;

                dvcArgu[2].sCondtion_ID = "LINE_ID";
                dvcArgu[2].sCondition_Value = s_line;

                dvcArgu[3].sCondtion_ID = "USER_ID";
                dvcArgu[3].sCondition_Value = MPGV.gsUserID;

                dvcArgu[4].sCondtion_ID = "OPER";
                dvcArgu[4].sCondition_Value = s_oper;

                dvcArgu[5].sCondtion_ID = "MOLD_PACK_FLAG";
                dvcArgu[5].sCondition_Value = s_mold_pack_flag;

                // Show
                if (s_oper == "")
                    s_view_id = "COM0000-014";
                else
                    s_view_id = "COM0000-011"; //전처리에서 사용하고 있습니다. 수정시 말씀해 주세요.

                cdvResource.Text = cdvResource.Show(cdvResource, "Resource", s_view_id, dvcArgu, "RES_DESC", -1);

                if (MPCF.Trim(cdvResource.Text) != "")
                {
                    if (cdvResource.returnDatas != null && cdvResource.returnDatas.Count > 0)
                    {
                        cdvResource.Tag = cdvResource.returnDatas[0];
                    }
                    else
                        cdvResource.Tag = "";
                }
                else
                    cdvResource.Tag = "";
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 조회 조건을 Registry에 저장할 대상 Controls을 구함.
        /// </summary>
        /// <param name="baseControl"></param>
        /// <param name="scCondtions"></param>
        public static void SearchControl(Control baseControl, List<BIGV.SearchCondition> scCondtions)
        {
            BIGV.SearchCondition scCondition = null;

            try
            {
                foreach (Control ctrl in baseControl.Controls)
                {
                    if (ctrl is BOI.OIFrx.BOIControls.BOICodeView)
                    {
                        if ((ctrl as BOI.OIFrx.BOIControls.BOICodeView).SaveRegistry)
                        {
                            scCondition = new BIGV.SearchCondition();
                            scCondition.s_ctrl_name = (ctrl as BOI.OIFrx.BOIControls.BOICodeView).Name;
                            scCondition.s_code = MPCF.Trim((ctrl as BOI.OIFrx.BOIControls.BOICodeView).Tag);
                            scCondition.s_code_desc = (ctrl as BOI.OIFrx.BOIControls.BOICodeView).Text;

                            scCondtions.Add(scCondition);
                        }
                    }
                    else if (ctrl is BOI.OIFrx.BOIControls.BOIMatCodeView)
                    {
                        if ((ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).SaveRegistry)
                        {
                            scCondition = new BIGV.SearchCondition();
                            scCondition.s_ctrl_name = (ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).Name;
                            scCondition.s_code = MPCF.Trim((ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).Tag);
                            scCondition.s_code_desc = (ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).Text;

                            scCondtions.Add(scCondition);
                        }
                    }
                    //else if (ctrl is SOI.OIFrx.SOIControls.SOICodeView)
                    //{
                    //    if ((ctrl as SOI.OIFrx.SOIControls.SOICodeView).SaveRegistry)
                    //    {
                    //        scCondition = new BIGV.SearchCondition();
                    //        scCondition.s_ctrl_name = (ctrl as SOI.OIFrx.SOIControls.SOICodeView).Name;
                    //        scCondition.s_code = MPCF.Trim((ctrl as SOI.OIFrx.SOIControls.SOICodeView).Tag);
                    //        scCondition.s_code_desc = (ctrl as SOI.OIFrx.SOIControls.SOICodeView).Text;

                    //        scCondtions.Add(scCondition);
                    //    }
                    //}

                    SearchControl(ctrl, scCondtions);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("SearchControl() : " + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// 조회 조건 Registry에 저장
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool SaveCondition(Control control)
        {
            int i = 0;
            List<BIGV.SearchCondition> scConditions = new List<BIGV.SearchCondition>();

            try
            {
                SearchControl(control, scConditions);

                for (i = 0; i < scConditions.Count; i++)
                {
                    MPCF.SaveRegSetting(Application.ProductName, control.Name, scConditions[i].s_ctrl_name, scConditions[i].s_code + "|" + scConditions[i].s_code_desc);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("SaveCondition() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        public static Control FindControl(Control baseControl, string name)
        {
            Control cRet = null;

            foreach (Control ctrl in baseControl.Controls)
            {
                if (String.Compare(ctrl.Name, name, true) == 0)
                    return ctrl;

                if((cRet = FindControl(ctrl, name)) != null)
                    return cRet;
            }

            return null;
        }

        /// <summary>
        /// Registry에 저장된 조회 조건을 화면에 표시
        /// </summary>
        /// <param name="control"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public static bool GetCondition(Control control)
        {
            int i = 0;
            List<BIGV.SearchCondition> scConditions = new List<BIGV.SearchCondition>();
            string s_value = "";
            string[] s_values;

            Control[] ctrls = null;
            Control ctrl = null;

            try
            {
                SearchControl(control, scConditions);

                for (i = 0; i < scConditions.Count; i++)
                {
                    s_value = MPCF.GetRegSetting(Application.ProductName, control.Name, scConditions[i].s_ctrl_name, "");
                    if (s_value != "")
                    {
                        s_values = s_value.Split('|');
                        scConditions[i].s_code = s_values[0];
                        scConditions[i].s_code_desc = s_values[1];

                        //ctrl = FindControl(control, scConditions[i].s_ctrl_name);
                        ctrls = control.Controls.Find(scConditions[i].s_ctrl_name, true);
                        if (ctrls == null)
                            ctrl = null;
                        else
                            ctrl = ctrls[0];

                        if (ctrl is BOI.OIFrx.BOIControls.BOICodeView)
                        {
                            if ((ctrl as BOI.OIFrx.BOIControls.BOICodeView).SaveRegistry)
                            {
                                (ctrl as BOI.OIFrx.BOIControls.BOICodeView).Tag = scConditions[i].s_code;
                                (ctrl as BOI.OIFrx.BOIControls.BOICodeView).Text = scConditions[i].s_code_desc;
                            }
                        }
                        else if (ctrl is BOI.OIFrx.BOIControls.BOIMatCodeView)
                        {
                            if ((ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).SaveRegistry)
                            {
                                (ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).Tag = scConditions[i].s_code;
                                (ctrl as BOI.OIFrx.BOIControls.BOIMatCodeView).Text = scConditions[i].s_code_desc;
                            }
                        }
                        //else if (ctrl is SOI.OIFrx.SOIControls.SOICodeView)
                        //{
                        //    if ((ctrl as SOI.OIFrx.SOIControls.SOICodeView).SaveRegistry)
                        //    {
                        //        (ctrl as SOI.OIFrx.SOIControls.SOICodeView).Tag = scConditions[i].s_code;
                        //        (ctrl as SOI.OIFrx.SOIControls.SOICodeView).Text = scConditions[i].s_code_desc;
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("GetCondition() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        public static bool GetGCMAttributData(TRSNode attr_node, string s_factory, string s_attr_type, string s_attr_key)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_LIST_OUT");
            int i;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("FACTORY", s_factory);
                in_node.SetString("ATTR_TYPE", s_attr_type);
                in_node.SetString("ATTR_KEY", s_attr_key);

                if (MPCF.CallService("BAS", "BAS_View_Attribute_Value", in_node, ref out_node, false) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList("VALUE_LIST").Count; i++)
                {
                    attr_node.SetString(out_node.GetList("VALUE_LIST")[i].GetString("ATTR_NAME"), out_node.GetList("VALUE_LIST")[i].GetString("ATTR_VALUE"));
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static bool ViewDynaimcQuery(string QueryStatement, ref DataTable dt, string ViewID, TPDR.DirectViewCond[] Cond, bool bIcon, bool bBGColor, ref string sSql)
        {
            TRSNode in_node = new TRSNode("DYNAMIC_QUERY_IN");
            TRSNode out_node;
            //TRSNode out_node = new TRSNode("DYNAMIC_QUERY_OUT");
            TRSNode list_item;
            string sTypeName;
            int i;
            try
            {                                               

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("VIEW_ID", ViewID);
                for (i = 0; i < Cond.Length; i++)
                {
                    list_item = in_node.AddNode("VARIABLE_LIST");
                    list_item.AddString("VARIABLE_DATA", Cond[i].sCondtion_ID);
                    
                    if (Cond[i].sCondition_Type == "" || Cond[i].sCondition_Type == null)
                    {
                        sTypeName = Cond[i].sCondition_Value.GetType().Name;
                        if (sTypeName == "Int16" || sTypeName == "Int32" || sTypeName == "Int64")
                        {
                            sTypeName = "INT";
                            list_item.AddString("VARIABLE_TYPE", sTypeName);
                        }
                        else if (sTypeName == "Double")
                        {
                            sTypeName = "DOUBLE";
                            list_item.AddString("VARIABLE_TYPE", sTypeName);
                        }
                        else if (sTypeName == "Single")
                        {
                            sTypeName = "FLOAT";
                            list_item.AddString("VARIABLE_TYPE", sTypeName);
                        }
                        else
                        {
                            sTypeName = "STRING";
                            list_item.AddString("VARIABLE_TYPE", sTypeName);
                        }
                    }                    
                    else
                    {
                        list_item.AddString("VARIABLE_TYPE", Cond[i].sCondition_Type);
                    }                   

                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("DATA", Cond[i].sCondition_Value);
                }              

                do
                {
                    out_node = new TRSNode("DYNAMIC_QUERY_OUT");

                    if (MPCF.CallService("BCOM", "BCOM_View_Dynamic_Query_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < in_node.GetList("VARIABLE_LIST").Count; i++)
                    {
                        for (int j = 0; j < out_node.GetList("DYNAMIC_NEXT_DATA_LIST").Count; j++)
                        {
                            for (int k = 0; k < out_node.GetList("DYNAMIC_NEXT_DATA_LIST")[j].MemberCount; k++)
                            {
                                if (in_node.GetList("VARIABLE_LIST")[i].GetString("VARIABLE_DATA") == out_node.GetList("DYNAMIC_NEXT_DATA_LIST")[j].GetMember(k).Name)
                                {
                                    in_node.GetList("DATA_LIST")[i].SetString("DATA", out_node.GetList("DYNAMIC_NEXT_DATA_LIST")[j].GetMember(k).Value);
                                }
                            }                            
                        }                        
                    }
                    dt = ConvertToDataTable(dt, out_node);                                
                } while (out_node.GetList("DYNAMIC_NEXT_DATA_LIST").Count != 0);              


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// BAS_SQL_Query_Out_Tag를 DataTable로 변환한다. 기존 DataTable에 Record를 추가할 경우 사용.
        /// </summary>
        /// <param name="cur_dt">기존 DataTable</param>
        /// <param name="Query_Out">BAS_SQL_Query_Out_Tag</param>
        /// <returns>변환된 DataTable</returns>
        public static DataTable ConvertToDataTable(DataTable cur_dt, TRSNode query_out)
        {
            int r;
            int c;
            DataTable dt;
            DataColumn dc;
            DataRow dr;

            List<TRSNode> col_list;
            List<TRSNode> row_list;
            //TRSNode data_node;
            string data = string.Empty;

            if (cur_dt == null)
            {

                if (query_out.GetList("DYNAMIC_COLUMN_LIST").Count < 1) return null;

                dt = new DataTable("DataTable");

                col_list = query_out.GetList("DYNAMIC_COLUMN_LIST");
                for (c = 0; c < col_list.Count; c++)
                {
                    dc = new DataColumn(col_list[c].GetString("COLUMN"));

                    /*TYPE은 전부 VARCHAR2 추후 변경
                    switch (col_list[c].GetString("TYPE"))
                    {
                        case "INT":
                            dc.DataType = System.Type.GetType("System.Int32");
                            dc.DefaultValue = 0;
                            break;
                        case "LNG":
                            dc.DataType = System.Type.GetType("System.Int64");
                            dc.DefaultValue = 0;
                            break;
                        case "DBL":
                            dc.DataType = System.Type.GetType("System.Double");
                            dc.DefaultValue = 0;
                            break;
                        case "CHR":
                            dc.DataType = System.Type.GetType("System.String");
                            dc.DefaultValue = "";
                            break;
                        case "STR":
                            dc.DataType = System.Type.GetType("System.String");
                            dc.DefaultValue = "";
                            break;
                    }
                    */
                    dt.Columns.Add(dc);
                }
            }
            else
            {
                dt = cur_dt;
            }
           

            row_list = query_out.GetList("DYNAMIC_DATA_LIST");
            for (r = 0; r < row_list.Count; r++)
            {
                dr = dt.NewRow();

                for (c = 0; c < dt.Columns.Count; c++)
                {
                    data = row_list[r].GetString(dt.Columns[c].ColumnName);
                    if (data == string.Empty)
                    {
                        dr[c] = " ";
                    }
                    else
                    {
                        dr[c] = data;
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }



        public static bool Fill_PrintDatas(ref TRSNode print_node, string[] PrintDataArray, out string sPrintString)
        {

            int i;
            int j;
            //bool bFind = false;
            sPrintString = string.Empty;
            try
            {

                //TRSNode item_list;
                for (i = 0; i < print_node.Members.Count; i++)
                {
                    string sFromStr = "$" + MPCF.Trim(print_node.Members[i].Name.ToString());
                    string sToStr = MPCF.Trim(print_node.Members[i].Value.ToString());

                    if(sFromStr == "$QTY")
                    {
                        sToStr = MPCF.ToDbl(sToStr).ToString("###,##0.##");
                    }

                    for (int x = 0; x < PrintDataArray.Length; x++)
                    {
                        PrintDataArray[x] = PrintDataArray[x].Replace(sFromStr, sToStr);
                    }

                    

                    //bFind = true;

                    //for (j = 0; j <= (PrintData.Length/2 - 1); j++)
                    //{
                    //    if (MPCF.Trim(item_list.GetString("DATA")) == PrintData[j, 0].TrimEnd())
                    //    {
                    //        item_list.AddString("DATA" , PrintData[j, 1]);
                    //        bFind = true;
                    //        break;
                    //    }
                    //}

                    //if (bFind == false)
                    //{
                    //    return false;
                    //}
                }

                for (j = 0; j <= (PrintDataArray.Length - 1); j++)
                {
                    sPrintString += PrintDataArray[j];
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
        /// 작업지시의 유통기간 조회
        /// </summary>
        /// <returns></returns>
        public static bool View_Shelf_Life(string s_order_id, SOI.OIFrx.SOIControls.SOIComboBox cboShelf)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";
            int i = 0;

            try
            {
                cboShelf.Items.Clear();

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = s_order_id;

                if (TPDR.GetDataOne("", ref dt, "CWIP8540-002", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    cboShelf.Items.Add(dt.Rows[i]["EXP_DATE"].ToString());
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Shelf_Life() : " + ex.Message, MSG_LEVEL.ERROR, true);
            }

            return true;
        }

        public static double ChangeWMValue(string sValue)
        {
            string substrvalue01 = string.Empty;
            string substrvalue02 = string.Empty;
            double dvalue = 0.0d;
            try
            {
                substrvalue01 = sValue.Substring(sValue.Length - 9, sValue.Length - (sValue.Length - 7));
                substrvalue02 = sValue.Substring(7, sValue.Length - 9);
                if (double.TryParse(substrvalue01, out dvalue) == false)
                {
                    if (double.TryParse(substrvalue02, out dvalue) == false)
                    {
                        dvalue = 0.0d;
                    }
                }                
            }
            catch
            {
                dvalue = 0.0d;
            }

            return dvalue;
        }

        public static double GetTankWeightFromLoadCell(string tankId)
        {                  
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";
            double loadCellWeight = 0.0d;
            try
            {
                loadCellWeight = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "RES_ID";
                dvcArgu[1].sCondition_Value = tankId;

                if (TPDR.GetDataOne("", ref dt, "CWIP8040-007", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return loadCellWeight;
                }

                loadCellWeight = MPCF.ToDbl(dt.Rows[0]["TANK_WEIGHT"].ToString());
            }
            catch
            {
                loadCellWeight = 0;
            }
            return loadCellWeight;
        }


        public static bool GetRandomChannelValue(out string randomValue)
        {            
            try
            {
                while (true)
                {
                    lock (syncLock)
                    { // synchronize                    
                        randomValue = string.Format("{0:D4}", random.Next(1, 1000));

                        if (randomChannelValues.Contains(randomValue))
                        {
                            continue;
                        }
                        else
                        {
                            randomChannelValues.Add(randomValue);
                            break;
                        }
                    }
                    
                }
                return true;

            }
            catch (Exception ex)
            {
                randomValue = "";
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }            
        }

        public static bool RemoveRandomChannelValue(string randomValue)
        {
            try
            {
                randomChannelValues.Remove(randomValue);                
                return true;

            }
            catch (Exception ex)
            {                
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        
    }
}
