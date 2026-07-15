using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
namespace Miracom.RASCore
{
    public partial class frmRASSetupCarrierEvent : Miracom.MESCore.SetupForm02
    {
        public frmRASSetupCarrierEvent()
        {
            InitializeComponent();
        }


        #region "Const Definition"
       
        private const string CHECKSHEET = "CHECKSHEET";
        private const string CHANGESHEET = "CHANGESHEET";

        private const string CHK_EQUAL = "= (Equal)";
        private const string CHK_NOT_EQUAL = "! (Not Equal)";
        private const string CHK_GREATER = "> (Greater than)";
        private const string CHK_LESS = "< (Less than)";
        private const string CHK_CHECK = "Y (Check)";
        private const string CHK_NOT_CHECK = "N (Not Check)";
        private const string CHK_GREATER_EQUAL = ">= (Greater than or equal)";
        private const string CHK_LESS_EQUAL = "<= (Less than or equal)";

        private const string CHG_INCREASE = "+ (Increase)";
        private const string CHG_DECREASE = "- (Decrease)";
        private const string CHG_TIME = "T (Time)";
        private const string CHG_RESET = "R (Reset)";
        private const string CHG_CHANGE = "Y (Change)";
        private const string CHG_NOT_CHANGE = "N (Not Change)";

        #endregion

        #region " Variable definition "
        bool b_load_flag;
        private string sBeforeType;
        string spdSheet;
        public struct CMFValue
        {
            public string prompt;
            public string format;
            public int size;
            public string table_name;
        }

        CMFValue[] cmfInfo;

        public struct AttrValue
        {
            public string attr_name;
            public string table_name;
            public int attr_size;
            public string attr_format;
        }

        AttrValue[] attrInfo;
        #endregion

        #region " Function definition "

        // ClearData()
        //       - Intialize Form Controls
        // Return Value
        //       - None
        // Arguments
        //       - ByVal ProcStep as String (Optional)
        //
        private void ClearData(char ProcStep)
        {
            int i;

            try
            {
                if (ProcStep == '1')
                {
                    spdCheckItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                    spdChangeItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                    spdCheckItem.ActiveSheet.SetActiveCell(0, 0);
                    spdChangeItem.ActiveSheet.SetActiveCell(0, 0);

                    for (i = 0; i < 30; i++)
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 2].ColumnSpan = 2;
                        spdChangeItem.ActiveSheet.Cells[i, 2].ColumnSpan = 2;
                    }

                }
                else if (ProcStep == '2')
                {

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int j;

            switch (MPCF.Trim(FuncName))
            {
                case "Update_Carrier_Event":

                    if (MPCF.CheckValue(txtCrrEventID, 1) == false)
                    {
                        return false;
                    }

                    if (ProcStep == MPGC.MP_STEP_CREATE || ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        try
                        {
                            for (j = 0; j < 30; j++)
                            {
                                if (MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)) != "")
                                {
                                    if (MPCF.Trim(spdCheckItem.ActiveSheet.GetText(j, 1)) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109) + " [Check Flag]");
                                        spdCheckItem.ActiveSheet.SetActiveCell(j, 1);
                                        spdCheckItem.Focus();
                                        return false;
                                    }
                                }

                                if (MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)) != "")
                                {
                                    if (MPCF.Trim(spdChangeItem.ActiveSheet.GetText(j, 1)) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109) + " [Change Flag]");
                                        spdChangeItem.ActiveSheet.SetActiveCell(j, 1);
                                        spdChangeItem.Focus();
                                        return false;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return false;
                        }
                    }
                    break;

            }

            return true;

        }

        //
        // Update_Carrier_Event()
        //       -  Update Carrier Event Action Setup
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?ïÏû• Process Step
        //
        private bool Update_Carrier_Event(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Carrier_Event_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode chg_list;
            TRSNode chk_list;
            ListViewItem item;
            int j;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CRR_EVENT_ID", MPCF.Trim(txtCrrEventID.Text));
                in_node.AddString("CRR_EVENT_DESC", MPCF.Trim(txtDesc.Text));
                
                in_node.AddChar("SYSTEM_FLAG", (chkSystemFlag.Checked == true ? 'Y' : ' '));
                
                for (j = 0; j < 30; j++)
                {
                    chk_list = in_node.AddNode("CHK_LIST");
                    chg_list = in_node.AddNode("CHG_LIST");

                    chk_list.AddInt("T", 0);
                    chg_list.AddInt("T", 0);

                    if (MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)) != "")
                    {
                        chk_list.AddString("CHK_ITEM", MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)));
                        if (MPCF.Trim(spdCheckItem.ActiveSheet.GetText(j, 1)).Substring(0, 2) == ">=")
                        {
                            chk_list.AddChar("CHK_FLAG", 'G');
                        }
                        else if (MPCF.Trim(spdCheckItem.ActiveSheet.GetText(j, 1)).Substring(0, 2) == "<=")
                        {
                            chk_list.AddChar("CHK_FLAG", 'L');
                        }
                        else
                        {
                            chk_list.AddChar("CHK_FLAG", MPCF.ToChar(MPCF.Trim(spdCheckItem.ActiveSheet.GetText(j, 1)).Substring(0, 1)));
                        }
                        
                        chk_list.AddString("CHK_VALUE", MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 2)));

                        chk_list.AddString("CHK_FIELD", MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 4)));
                    }

                    if (MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)) != "")
                    {
                        chg_list.AddString("CHG_ITEM", MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)));

                        chg_list.AddChar("CHG_FLAG", MPCF.ToChar(MPCF.Trim(spdChangeItem.ActiveSheet.GetText(j, 1)).Substring(0, 1)));
                        chg_list.AddString("CHG_VALUE", MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 2)));
                        chg_list.AddChar("CHG_OPT", MPCF.ToChar(MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 4))));
                    }
                }

                if (MPCR.CallService("RAS", "RAS_Update_Carrier_Event", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        item = lisCrrEvent.Items.Add(txtCrrEventID.Text, (int)SMALLICON_INDEX.IDX_EVENT);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisCrrEvent.Sorting = SortOrder.Ascending;
                        lisCrrEvent.Sort();
                        item.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisCrrEvent, MPCF.Trim(txtCrrEventID.Text), false) == true)
                        {
                            lisCrrEvent.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        if (MPCF.FindListItem(lisCrrEvent, MPCF.Trim(txtCrrEventID.Text), false) == true)
                        {
                            MPCF.FieldClear(this.pnlRight);
                            lisCrrEvent.SelectedItems[0].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisCrrEvent.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

       

        private bool View_Carrier_Event()
        {
            TRSNode in_node = new TRSNode("View_Carrier_Event_In");
            TRSNode out_node = new TRSNode("View_Carrier_Event_Out");
            List<TRSNode> list_item;
            int i;

            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_EVENT_ID", MPCF.Trim(lisCrrEvent.SelectedItems[0].Text));

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Event", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCrrEventID.Text = out_node.GetString("CRR_EVENT_ID");
                txtDesc.Text = out_node.GetString("CRR_EVENT_DESC");


                if (out_node.GetChar("SYSTEM_FLAG") == 'Y')
                {
                    chkSystemFlag.Checked = true;
                }
                else
                {
                    chkSystemFlag.Checked = false;
                }

                list_item = out_node.GetList("CHK_LIST");
                for (i = 0; i < list_item.Count; i++)
                {
                    spdCheckItem.ActiveSheet.SetText(i, 0, MPCF.Trim(list_item[i].GetString("CHK_ITEM")));

                    spdCheckItem.ActiveSheet.SetText(i, 1, MakeCheckFlag(MPCF.Trim(list_item[i].GetChar("CHK_FLAG"))));
                    //spdCheckItem.Sheets(0).SetText(i, 2, View_Carrier_Event_Out.chk_list[i].chk_value)

                    spdCheckItem.ActiveSheet.SetText(i, 4, MPCF.Trim(list_item[i].GetString("CHK_FIELD")));
                    if (MPCF.Trim(list_item[i].GetString("CHK_ITEM")) != "")
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 1].Locked = false;
                    }
                    if (MPCF.Trim(list_item[i].GetString("CHK_FIELD")) != "")
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 4].Locked = false;
                    }

                    View_SheetControl(list_item[i].GetString("CHK_ITEM"), i, CHECKSHEET);

                    spdCheckItem.ActiveSheet.SetText(i, 2, list_item[i].GetString("CHK_VALUE"));
                    if (list_item[i].GetChar("CHK_FLAG").ToString().Substring(0, 1) == "N")
                    {
                        CellSpan(i, 2, CHECKSHEET);
                        spdCheckItem.ActiveSheet.Cells[i, 2].Locked = true;
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 2].Locked = false;
                    }

                }

                list_item = out_node.GetList("CHG_LIST");
                for (i = 0; i < list_item.Count; i++)
                {
                    spdChangeItem.ActiveSheet.SetText(i, 0, MPCF.Trim(list_item[i].GetString("CHG_ITEM")));

                    spdChangeItem.ActiveSheet.SetText(i, 1, MakeChangeFlag(MPCF.Trim(list_item[i].GetChar("CHG_FLAG"))));
                    //spdChangeItem.Sheets(0).SetText(i, 2, View_Carrier_Event_Out.chg_list[i].chg_value)

                    if (MPCF.Trim(list_item[i].GetChar("CHG_OPT")) == "1")
                    {
                        spdChangeItem.ActiveSheet.SetText(i, 4, "Y");
                    }
                    else
                    {
                        spdChangeItem.ActiveSheet.SetText(i, 4, "");
                    }

                    if (MPCF.Trim(list_item[i].GetString("CHG_ITEM")) != "")
                    {
                        spdChangeItem.ActiveSheet.Cells[i, 1].Locked = false;
                        spdChangeItem.ActiveSheet.Cells[i, 2].Locked = false;

                        if (MPCF.Trim(list_item[i].GetChar("CHG_FLAG")) == "Y")
                        {
                            spdChangeItem.ActiveSheet.Cells[i, 4].Locked = false;
                            spdChangeItem.ActiveSheet.Cells[i, 4].BackColor = Color.White;
                        }
                        else
                        {
                            spdChangeItem.ActiveSheet.Cells[i, 4].Locked = true;
                            spdChangeItem.ActiveSheet.Cells[i, 4].BackColor = Color.WhiteSmoke;
                        }
                    }

                    View_SheetControl(list_item[i].GetString("CHG_ITEM"), i, CHANGESHEET);

                    spdChangeItem.ActiveSheet.SetText(i, 2, list_item[i].GetString("CHG_VALUE"));

                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //Cell??Span?òÍ∏∞
        private void CellSpan(int iRow, int iColSpan, string sheet)
        {

            FarPoint.Win.Spread.Cell sheetData;
            if (sheet == CHECKSHEET)
            {
                sheetData = spdCheckItem.ActiveSheet.Cells[iRow, 2];
            }
            else
            {
                sheetData = spdChangeItem.ActiveSheet.Cells[iRow, 2];
            }

            sheetData.ColumnSpan = iColSpan;

        }

        //Cell Text??Í∏∏Ïù¥Ï£ºÍ∏∞
        private void TextLength(int iRow, int iLength, string sheet)
        {

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
            txt.MaxLength = iLength;
            if (sheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[iRow, 2].CellType = txt;
                spdCheckItem.ActiveSheet.Cells[iRow, 2].Text = "";
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[iRow, 2].CellType = txt;
                spdChangeItem.ActiveSheet.Cells[iRow, 2].Text = "";
            }

        }

        //Cell??Î≤ÑÌäºÎßåÎì§Í∏?
        private void SheetBtn(int iRow, string sheet)
        {
            FarPoint.Win.Spread.CellType.ButtonCellType sheetButton = new FarPoint.Win.Spread.CellType.ButtonCellType();
            sheetButton.Text = "...";
            if (sheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[iRow, 3].CellType = sheetButton;
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[iRow, 3].CellType = sheetButton;
            }

        }

        //Cell¿« Modify(Span, GCMπˆ∆∞, Text±Ê¿Ã, Textº˝¿⁄≈∏¿‘ªÁ¿Ã¡Ó µÓ¿ª º≥¡§«—¥Ÿ.)
        private void SheetModity(string sGCM, int row, string format, int length, string sheetType)
        {

            if (sheetType == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[row, 2].Text = "";

                if (sGCM == "Y")
                {
                    spdCheckItem.ActiveSheet.Cells[row, 3].Locked = false;
                    CellSpan(row, 1, CHECKSHEET);
                    SheetBtn(row, CHECKSHEET);
                }
                else
                {
                    spdCheckItem.ActiveSheet.Cells[row, 3].Locked = true;
                    CellSpan(row, 2, CHECKSHEET);
                }

                TextLength(row, length, CHECKSHEET);

            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[row, 2].Text = "";

                if (sGCM == "Y")
                {
                    spdChangeItem.ActiveSheet.Cells[row, 3].Locked = false;
                    CellSpan(row, 1, CHANGESHEET);
                    SheetBtn(row, CHANGESHEET);
                }
                else
                {
                    spdChangeItem.ActiveSheet.Cells[row, 3].Locked = true;
                    CellSpan(row, 2, CHANGESHEET);
                }

                TextLength(row, length, CHANGESHEET);
            }

        }

        //Í∏∞Î≥∏Item??Add?úÎã§.
        private void ViewCMFValue()
        {
            int i;
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_CARRIER, ref out_node, "", true) == false)
            {
                return;
            }
            cmfInfo = new CMFValue[out_node.GetList(0).Count];
            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                {
                    cmfInfo[i].prompt = out_node.GetList(0)[i].GetString("PROMPT");
                    cmfInfo[i].table_name = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    cmfInfo[i].format = MPCF.Trim(out_node.GetList(0)[i].GetChar("FORMAT"));
                }
            }
        }
        private void InitCheckItems(List<string> list)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            int i;


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
                        
            in_node.AddString("SQL", "SELECT COLUMN_NAME FROM USER_TAB_COLUMNS WHERE TABLE_NAME = 'MRASCRRDEF' ORDER BY COLUMN_ID");

            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return;
            }

            list.Add("");

            for (i = 0; i < out_node.GetList("ROWS").Count; i++)
            {
                list.Add(out_node.GetList("ROWS")[i].GetList("COLS")[0].GetString("DATA"));
            }
            for (i = 0; i < cmfInfo.Length; i++)
            {
                if (MPCF.Trim(cmfInfo[i].prompt) != "")
                {
                    list.Add(MPCF.Trim(cmfInfo[i].prompt));
                }
            }            
            
            View_Attribute_Name_List();

            for (i = 0; i < attrInfo.Length; i++)
            {
                if (MPCF.Trim(attrInfo[i].attr_name) != "")
                {
                    list.Add(MPCF.Trim(attrInfo[i].attr_name));
                }
            }  
                      
        }

        private void InitChangeItems(List<string> list)
        {
            int i;
            list.Add("");
            list.Add("CRR_STATUS");
            list.Add("LOCATION_1");
            list.Add("LOCATION_2");
            list.Add("LOCATION_3");
            list.Add("LOCATION_4");
            list.Add("LOCATION_5");
            list.Add("RES_ID");
            list.Add("SUBRES_ID");
            list.Add("PORT_ID");
            list.Add("USAGE_COUNT");
            list.Add("CLEAN_COUNT");
            list.Add("NEED_CLEAN_FLAG");
            
            for (i = 0; i < cmfInfo.Length; i++)
            {
                if (MPCF.Trim(cmfInfo[i].prompt) != "")
                {
                    list.Add(MPCF.Trim(cmfInfo[i].prompt));
                }
            }

            View_Attribute_Name_List();

            for (i = 0; i < attrInfo.Length; i++)
            {
                if (MPCF.Trim(attrInfo[i].attr_name) != "")
                {
                    list.Add(MPCF.Trim(attrInfo[i].attr_name));
                }
            }

        }
        //Ï≤¥ÌÅ¨?¨Î?Î•??ïÏùò?úÎã§.
        private string MakeCheckFlag(string s)
        {
            string returnValue = string.Empty;
            if (s == "=")
            {
                returnValue = CHK_EQUAL;
                return returnValue;
            }
            else if (s == "!")
            {
                returnValue = CHK_NOT_EQUAL;
                return returnValue;
            }
            else if (s == "N")
            {
                returnValue = CHK_NOT_CHECK;
                return returnValue;
            }
            else if (s == ">")
            {
                returnValue = CHK_GREATER;
                return returnValue;
            }
            else if (s == "<")
            {
                returnValue = CHK_LESS;
                return returnValue;
            }
            else if (s == "G")
            {
                returnValue = CHK_GREATER_EQUAL;
                return returnValue;
            }
            else if (s == "L")
            {
                returnValue = CHK_LESS_EQUAL;
                return returnValue;
            }

            return returnValue;
        }

        //Î≥ÄÍ≤ΩÏó¨Î∂ÄÎ•??ïÏùò?úÎã§.
        private string MakeChangeFlag(string s)
        {
            string returnValue = string.Empty;
            if (s == "Y")
            {
                returnValue = CHG_CHANGE;
                return returnValue;
            }
            else if (s == "N")
            {
                returnValue = CHG_NOT_CHANGE;
                return returnValue;
            }
            else if (s == "+")
            {
                returnValue = CHG_INCREASE;
                return returnValue;
            }
            else if (s == "-")
            {
                returnValue = CHG_DECREASE;
                return returnValue;
            }
            else if (s == "T")
            {
                returnValue = CHG_TIME;
                return returnValue;
            }
            else if (s == "R")
            {
                returnValue = CHG_RESET;
                return returnValue;
            }

            return returnValue;
        }

        //Í∏∞Î≥∏Item?êÎã§ ?ïÏùò?úItem??Ï∂îÍ??úÎã§.
        private bool AddCarrierItem()
        {
            int i;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

            string[] sCheckItem = null;
            string[] sChangeItem = null;
            List<string> sCheckList = new List<string>();
            List<string> sChangeList = new List<string>();

            try
            {
                InitCheckItems(sCheckList);
                InitChangeItems(sChangeList);

                
                //Check Item??Spread???ÅÏö©?úÎã§.
                sCheckItem = new string[sCheckList.Count];
                for (i = 0; i < sCheckList.Count; i++)
                {
                    sCheckItem[i] = sCheckList[i];
                }
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = sCheckItem;
                spdCheckItem.ActiveSheet.Columns.Get(0).CellType = cboCellType;
                spdCheckItem.ActiveSheet.Columns.Get(4).CellType = cboCellType;

                //Change Item??Spread???ÅÏö©?úÎã§.
                sChangeItem = new string[sChangeList.Count];
                for (i = 0; i < sChangeList.Count; i++)
                {
                    sChangeItem[i] = sChangeList[i];
                }
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = sChangeItem;
                spdChangeItem.ActiveSheet.Columns.Get(0).CellType = cboCellType;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //?ïÏùò???ÑÏù¥?úÏóê ?∞Îùº ?¨Ìä∏Î•?Modify?úÎã§.
        private void View_SheetControl(string chkItem, int row, string sheetType)
        {
            int i;

            try
            {
                switch (chkItem)
                {
                    case "CRR_STATUS":
                        SheetModity("N", row, "A", 10, sheetType);
                        break;

                    case "LOCATION_1":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    case "LOCATION_2":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    case "LOCATION_3":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    case "LOCATION_4":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    case "LOCATION_5":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;

                    case "RES_ID":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;

                    case "SUBRES_ID":
                        SheetModity("N", row, "A", 20, sheetType);
                        break;

                    case "PORT_ID":
                        SheetModity("N", row, "A", 10, sheetType);
                        break;

                    case "LOT_ID":
                        SheetModity("N", row, "A", 25, sheetType);
                        break;

                    case "QTY_1":
                        SheetModity("N", row, "N", 12, sheetType);
                        break;
                    case "QTY_2":
                        SheetModity("N", row, "N", 12, sheetType);
                        break;
                    case "QTY_3":
                        SheetModity("N", row, "N", 12, sheetType);
                        break;
                   
                    //case "CRR_CMF_1" :
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_2":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_3":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_4":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_5":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_6":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_7":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_8":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_9":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_10":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_11":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_12":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_13":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_14":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_15":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_16":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_17":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_18":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_19":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;
                    //case "CRR_CMF_20":
                    //    SheetModity("N", row, "A", 30, sheetType);
                    //    break;

                    default:
                        if (sheetType == CHECKSHEET)
                        {
                            for (i = 0; i < cmfInfo.Length; i++)
                            {
                                if (MPCF.Trim(spdCheckItem.ActiveSheet.Cells[row, 0].Value) == MPCF.Trim(cmfInfo[i].prompt))
                                {
                                    if (MPCF.Trim(cmfInfo[i].table_name) != "")
                                    {
                                        spdCheckItem.ActiveSheet.Cells[row, 3].Tag = cmfInfo[i].table_name;
                                        SheetModity("Y", row, cmfInfo[i].format, 30, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, "A", 30, sheetType);
                                    }
                                    break;
                                }
                            }
                            for (i = 0; i < attrInfo.Length; i++)
                            {
                                if (MPCF.Trim(spdCheckItem.ActiveSheet.Cells[row, 0].Value) == MPCF.Trim(attrInfo[i].attr_name))
                                {
                                    if (MPCF.Trim(attrInfo[i].table_name) != "")
                                    {
                                        spdCheckItem.ActiveSheet.Cells[row, 3].Tag = attrInfo[i].table_name;
                                        SheetModity("Y", row, attrInfo[i].attr_format, attrInfo[i].attr_size, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, attrInfo[i].attr_format, attrInfo[i].attr_size, sheetType);
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (i = 0; i < cmfInfo.Length; i++)
                            {
                                if (MPCF.Trim(spdChangeItem.ActiveSheet.Cells[row, 0].Value) == MPCF.Trim(cmfInfo[i].prompt))
                                {
                                    if (MPCF.Trim(cmfInfo[i].table_name) != "")
                                    {
                                        spdChangeItem.ActiveSheet.Cells[row, 3].Tag = cmfInfo[i].table_name;
                                        SheetModity("Y", row, cmfInfo[i].format, 30, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, "A", 30, sheetType);
                                    }
                                    break;
                                }
                            }
                            for (i = 0; i < attrInfo.Length; i++)
                            {
                                if (MPCF.Trim(spdChangeItem.ActiveSheet.Cells[row, 0].Value) == MPCF.Trim(attrInfo[i].attr_name))
                                {
                                    if (MPCF.Trim(attrInfo[i].table_name) != "")
                                    {
                                        spdChangeItem.ActiveSheet.Cells[row, 3].Tag = attrInfo[i].table_name;
                                        SheetModity("Y", row, attrInfo[i].attr_format, attrInfo[i].attr_size, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, attrInfo[i].attr_format, attrInfo[i].attr_size, sheetType);
                                    }
                                    break;
                                }
                            }

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool View_Attribute_Name_List()
        {

            int i;
            ArrayList a_list;
            TRSNode in_node = new TRSNode("List_In");
            TRSNode out_node;

            a_list = new ArrayList();
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_CARRIER);
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

            do
            {
                out_node = new TRSNode("List_Out");

                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                attrInfo = new AttrValue[out_node.GetList(0).Count];
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    attrInfo[i].attr_name = out_node.GetList(0)[i].GetString("ATTR_NAME");
                    attrInfo[i].table_name = out_node.GetList(0)[i].GetString("VALID_TBL");
                    attrInfo[i].attr_size = out_node.GetList(0)[i].GetInt("ATTR_SIZE");
                    attrInfo[i].attr_format = MPCF.Trim(out_node.GetList(0)[i].GetChar("ATTR_FMT"));
                }
            }

            return true;
        }
        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtCrrEventID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASSetupCarrierEvent_Load(object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this);
            MPCF.InitListView(lisCrrEvent);
            ViewCMFValue();
            AddCarrierItem();
            if (RASLIST.ViewCarrierEventList(lisCrrEvent, '1', null) == true)
            {
                if (lisCrrEvent.Items.Count > 0)
                {
                    lisCrrEvent.Items[0].Selected = true;
                }
                lblDataCount.Text = MPCF.Trim(lisCrrEvent.Items.Count);
            }
            
        }

        private void frmRASSetupCarrierEvent_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {
                lblDataCount.Text = "";

                b_load_flag = true;
            }

        }
               
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Carrier_Event", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Carrier_Event(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Carrier_Event", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Carrier_Event(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Carrier_Event", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Carrier_Event(MPGC.MP_STEP_DELETE) == true)
                    {

                        if (MPGV.gbListAutoRefresh == true)
                        {
                            MPCF.FieldClear(this.pnlRight);
                            btnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisCrrEvent, this.Text, "");

        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            string SelectedItem;

            try
            {
                SelectedItem = MPCF.Trim(txtCrrEventID.Text);
                spdCheckItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                spdChangeItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                MPCF.InitListView(lisCrrEvent);
                lblDataCount.Text = "";

                if (RASLIST.ViewCarrierEventList(lisCrrEvent, '1', null) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisCrrEvent.Items.Count);
                }

                if (lisCrrEvent.Items.Count > 0 && SelectedItem != "")
                {
                    MPCF.FindListItem(lisCrrEvent, SelectedItem, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void lisCrrEvent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                ClearData('1');

                if (lisCrrEvent.SelectedItems.Count > 0)
                {
                    txtCrrEventID.Text = lisCrrEvent.SelectedItems[0].Text;

                    View_Carrier_Event();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdChangeItem_ComboDropDown(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            sBeforeType = e.EditingControl.Text;
        }

        private void spdCheckItem_ComboDropDown(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            sBeforeType = e.EditingControl.Text;
        }

        private void spdCheckItem_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i;
            string[] CheckItem = null;
            List<string> sCheckList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            try
            {
                if (e.Column == 0)
                {
                    if (sBeforeType != e.EditingControl.Text)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 1].Locked = true;
                        }
                        else
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 1].Locked = false;
                            spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        }

                        View_SheetControl(spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHECKSHEET);
                    }

                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == "")
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                    }

                }
                else if (e.Column == 1)
                {
                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                    {
                        CellSpan(e.Row, 2, CHECKSHEET);
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = false;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        View_SheetControl(spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHECKSHEET);
                    }
                }
                else if (e.Column == 2)
                {
                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                    }
                }

                if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text != "")
                {

                    if (e.Column == 4)
                    {

                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text)
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        }
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        }

                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text != "")
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        }

                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;

                        InitCheckItems(sCheckList);
                        CheckItem = new string[sCheckList.Count];
                        for (i = 0; i < sCheckList.Count; i++)
                        {
                            CheckItem[i] = sCheckList[i];
                        }
                        cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cboCellType.Items = CheckItem;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].CellType = cboCellType;
                    }
                }
                else
                {
                    if (e.Column == 1)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                    }
                    if (e.Column == 4)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdChangeItem_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 0)
            {

                CellSpan(e.Row, 2, CHANGESHEET);

                spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                spdChangeItem.ActiveSheet.Cells[e.Row, 4].BackColor = Color.WhiteSmoke;

                if (spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text != "")
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 1].Locked = false;
                }
                else
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 1].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                }

            }
            else if (e.Column == 1)
            {

                if (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text != "")
                {
                    //Modify by J.S 2007/01/27 CHG_INCREASE,CHG_DECREASE Ï∂îÍ?
                    if ((spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_CHANGE) || (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_RESET) || (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_INCREASE) || (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_DECREASE))
                    {
                        View_SheetControl(spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHANGESHEET);
                        spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = false;

                        if (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_CHANGE)
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                            spdChangeItem.ActiveSheet.Cells[e.Row, 4].BackColor = Color.White;
                        }
                        else
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                            spdChangeItem.ActiveSheet.Cells[e.Row, 4].BackColor = Color.WhiteSmoke;
                        }
                    }
                    else
                    {
                        CellSpan(e.Row, 2, CHANGESHEET);
                        if (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text.Substring(0, 1) == "N")
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        }
                        else
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        }
                        spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                        spdChangeItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                        spdChangeItem.ActiveSheet.Cells[e.Row, 4].BackColor = Color.WhiteSmoke;
                    }
                }
                else
                {

                    CellSpan(e.Row, 2, CHANGESHEET);
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].BackColor = Color.WhiteSmoke;
                }

            }

        }

        
        private void txtCrrEventID_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight, txtCrrEventID, null, null, null, null, false);
            ClearData('1');
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisCrrEvent, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisCrrEvent, txtFind.Text, 0, true, false);
        }

       
       
        private void spdCheckItem_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            try
            {

                if (e.Column == 2)
                {
                    spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                }
                if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                {
                    spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdChangeItem_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            try
            {

                if (e.Column == 2)
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                }
                if (spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdCheckItem_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            spdCheckItem.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }

        private void spdChangeItem_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            spdChangeItem.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }
        private void cdvTableList_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {

            if (spdSheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            }

            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
        }

        private void spdChangeItem_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            string sGCMData;

            sGCMData = MPCF.Trim( spdChangeItem.ActiveSheet.Cells[e.Row, 3].Tag);

            if (sGCMData != "")
            {
                cdvTableList.Init();
                cdvTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableList.GetListView);
                cdvTableList.Columns.Add("Table Name", 100, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 100, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', sGCMData);
                spdSheet = CHANGESHEET;
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
        }

        private void spdCheckItem_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sGCMData;

            sGCMData = MPCF.Trim(spdCheckItem.ActiveSheet.Cells[e.Row, 3].Tag);

            if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text != "")
            {
                cdvTableList.ViewPosition = Control.MousePosition;
                View_SheetControl(sGCMData, e.Row, CHECKSHEET);
                BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', sGCMData);
                spdSheet = CHECKSHEET;
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
        }

    }
}

