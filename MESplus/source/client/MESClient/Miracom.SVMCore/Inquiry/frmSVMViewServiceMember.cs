//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSVMViewServiceMember.cs
//   Description : View Service Member
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - View_Service() : View service
//       - View_Service_list() : View Service list
//       - View_Service_member_list() : View Service member list
//       - ViewModuleList() : 
//       - AddServiceMemberToSpread() : Add Service member Data into spdInMember or spdOutMember.
//       - AddRow() : Add one Row in spdMember
//       - UnderLine() : Add Under Line Border in spdMember
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-11-19 : Created by HyunJong Noh
//       - 2009-01-21 : Updated by Kyoungho Shin
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.SVMCore
{
    public partial class frmSVMViewServiceMember : SetupForm02
    {
        public frmSVMViewServiceMember()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_SEQ = 0;
        private const int COL_LEVEL = 1;
        private const int COL_MEMBER_NAME = 2;
        private const int COL_MEMBER_TYPE = 3;
        private const int COL_MEMBER_SIZE = 4;
        private const int COL_REQ_MEMBER_FLAG = 5;
        private const int COL_OVERRIDE_FLAG = 6;
        private const int COL_ARRY_TYPE = 7;
        private const int COL_USE_RANGE_FLAG = 8;
        private const int COL_RANGE_MIN = 9;
        private const int COL_RANGE_MAX = 10;
        private const int COL_PARENT_MEMBER_PATH = 11;
        private const int COL_BLANK = 12;

        #endregion

        #region " Variable Definition"

        bool b_load_flag = false;
               
        #endregion

        #region " Function Implementations"

        private void ClearData()
        {
            cdvModuleName.Text = "";
            txtServiceName.Text = "";
            txtServiceMode.Text = "";
            txtServiceDesc.Text = "";
            txtServiceCategory.Text = "";

            MPCF.ClearList(spdInMember, true);
            MPCF.ClearList(spdOutMember, true);
        }

        private bool View_Service()
        {
            if (lisService.SelectedItems.Count == 0)
                return false;

            TRSNode in_node = new TRSNode("View_Service_In");
            TRSNode out_node = new TRSNode("View_Service_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MODULE_NAME", lisService.SelectedItems[0].SubItems[0].Text);
            in_node.AddString("SERVICE_NAME", lisService.SelectedItems[0].SubItems[1].Text);

            if (MPCR.CallService("SVM", "SVM_View_Service", in_node, ref out_node) == false)
            {
                return false;
            }

            txtModuleName.Text = out_node.GetString("MODULE_NAME");
            txtServiceName.Text = out_node.GetString("SERVICE_NAME");

            switch (out_node.GetString("SERVICE_MODE"))
            {
                case "RR":
                    txtServiceMode.Text = "Request Reply";
                    break;
                case "RN":
                    txtServiceMode.Text = "Request No Reply";
                    break;
                case "MC":
                    txtServiceMode.Text = "MultiCast";
                    break;
                case "GM":
                    txtServiceMode.Text = "Guaranteed Multicast";
                    break;
                case "GU":
                    txtServiceMode.Text = "Guaranteed Unicast";
                    break;

            }

            switch (out_node.GetChar("SERVICE_CATEGORY"))
            {
                case 'I':
                    txtServiceCategory.Text = "Inquiry";
                    break;
                case 'T':
                    txtServiceCategory.Text = "Transaction";
                    break;
                case 'S':
                    txtServiceCategory.Text = "Setup";
                    break;
            }

            switch (MPGV.gcLanguage)
            {
                case '1':
                    txtServiceDesc.Text = out_node.GetString("SERVICE_DESC_1");
                    break;
                case '2':
                    txtServiceDesc.Text = out_node.GetString("SERVICE_DESC_2");
                    break;
                case '3':
                    txtServiceDesc.Text = out_node.GetString("SERVICE_DESC_3");
                    break;
            }

            txtMemberCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtMemberCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtMemberUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtMemberUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            return true;
        }

        private bool View_Service_List()
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");

            MPCF.InitListView(lisService);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModuleName.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lisService.Items.Add(new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                                         out_node.GetList(0)[i].GetString("SERVICE_NAME"),
                                                                         out_node.GetList(0)[i].GetString("SERVICE_DESC_1")}, (int)SMALLICON_INDEX.IDX_MODULE));
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            return true;
        }

        // View_Service_member_list()
        //       - View Service List
        // Return Value
        //       - Boolean True / False
        // Arguments
        //       - 
        private bool View_Service_member_list()
        {
            int iRow;

            if (lisService.SelectedItems.Count == 0)
                return false;

            MPCF.ClearList(spdInMember, true);
            MPCF.ClearList(spdOutMember, true);

            TRSNode in_node = new TRSNode("View_Service_Member_List_In");
            TRSNode out_node = new TRSNode("View_Service_Member_List_Out");

            List<ServiceMember> InMemberList = new List<ServiceMember>();
            List<ServiceMember> OutMemberList = new List<ServiceMember>();

            ServiceMember serviceMember;
            TRSNode item;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("MODULE_NAME", lisService.SelectedItems[0].SubItems[0].Text);
            in_node.AddString("SERVICE_NAME", lisService.SelectedItems[0].SubItems[1].Text);
            in_node.SetChar("DIRECTION", 'I');

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    serviceMember = new ServiceMember();
                    item = out_node.GetList(0)[i];

                    serviceMember.MODULE_NAME = item.GetString("MODULE_NAME");
                    serviceMember.SERVICE_NAME = item.GetString("SERVICE_NAME");
                    serviceMember.DIRECTION = item.GetChar("DIRECTION");
                    serviceMember.MEMBER_DEPTH = item.GetInt("MEMBER_DEPTH");
                    serviceMember.MEMBER_NAME = item.GetString("MEMBER_NAME");
                    serviceMember.MEMBER_PRT = item.GetString("MEMBER_PRT");
                    serviceMember.MEMBER_SEQ = item.GetInt("MEMBER_SEQ");
                    serviceMember.MEMBER_DESC_1 = item.GetString("MEMBER_DESC_1");
                    serviceMember.MEMBER_DESC_2 = item.GetString("MEMBER_DESC_2");
                    serviceMember.MEMBER_DESC_3 = item.GetString("MEMBER_DESC_3");
                    serviceMember.MEMBER_TYPE = item.GetString("MEMBER_TYPE");
                    serviceMember.MEMBER_SIZE = item.GetInt("MEMBER_SIZE");
                    serviceMember.REQ_MEMBER_FLAG = item.GetChar("REQ_MEMBER_FLAG");
                    serviceMember.PARENT_MEMBER_PATH = item.GetString("PARENT_MEMBER_PATH");
                    serviceMember.OVERRIDE_FLAG = item.GetChar("OVERRIDE_FLAG");
                    serviceMember.USE_RANGE_FLAG = item.GetChar("USE_RANGE_FLAG");
                    serviceMember.RANGE_MIN = item.GetDouble("RANGE_MIN");
                    serviceMember.RANGE_MAX = item.GetDouble("RANGE_MAX");

                    InMemberList.Add(serviceMember);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);


            in_node.SetChar("DIRECTION", 'O');
            
            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    serviceMember = new ServiceMember();
                    item = out_node.GetList(0)[i];

                    serviceMember.MODULE_NAME = item.GetString("MODULE_NAME");
                    serviceMember.SERVICE_NAME = item.GetString("SERVICE_NAME");
                    serviceMember.DIRECTION = item.GetChar("DIRECTION");
                    serviceMember.MEMBER_DEPTH = item.GetInt("MEMBER_DEPTH");
                    serviceMember.MEMBER_NAME = item.GetString("MEMBER_NAME");
                    serviceMember.MEMBER_PRT = item.GetString("MEMBER_PRT");
                    serviceMember.MEMBER_SEQ = item.GetInt("MEMBER_SEQ");
                    serviceMember.MEMBER_DESC_1 = item.GetString("MEMBER_DESC_1");
                    serviceMember.MEMBER_DESC_2 = item.GetString("MEMBER_DESC_2");
                    serviceMember.MEMBER_DESC_3 = item.GetString("MEMBER_DESC_3");
                    serviceMember.MEMBER_TYPE = item.GetString("MEMBER_TYPE");
                    serviceMember.MEMBER_SIZE = item.GetInt("MEMBER_SIZE");
                    serviceMember.REQ_MEMBER_FLAG = item.GetChar("REQ_MEMBER_FLAG");
                    serviceMember.PARENT_MEMBER_PATH = item.GetString("PARENT_MEMBER_PATH");
                    serviceMember.OVERRIDE_FLAG = item.GetChar("OVERRIDE_FLAG");
                    serviceMember.USE_RANGE_FLAG = item.GetChar("USE_RANGE_FLAG");
                    serviceMember.RANGE_MIN = item.GetDouble("RANGE_MIN");
                    serviceMember.RANGE_MAX = item.GetDouble("RANGE_MAX");

                    OutMemberList.Add(serviceMember);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);


            foreach (ServiceMember memberItem in InMemberList)
            {
                iRow = spdInMember.Sheets[0].RowCount;
                spdInMember.Sheets[0].RowCount++;

                AddServiceMemberToSpread(spdInMember, memberItem, iRow);
            }


            foreach (ServiceMember memberItem in OutMemberList)
            {
                iRow = spdOutMember.Sheets[0].RowCount;
                spdOutMember.Sheets[0].RowCount++;

                AddServiceMemberToSpread(spdOutMember, memberItem, iRow);
            }

            return true;
        }

        private bool ViewModuleList(ListView listView)
        {
            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }

            return true;

        }

        // AddServiceMemberToSpread()
        //       - Add Service Member Data into spdInMember or spdOutMember
        // Return Value
        //       -
        // Arguments
        //       -
        private void AddServiceMemberToSpread(FarPoint.Win.Spread.FpSpread spdMember, ServiceMember memberItem, int iRow)
        {
            string sDesc;
            int iSeq;

            if (iRow == 0)
            {
                iSeq = 1;
            }
            else
            {
                iSeq = (iRow / 2) + 1;
            }
            
            FarPoint.Win.Spread.SheetView with_1;
            with_1 = spdMember.Sheets[0];

            with_1.Cells[iRow, COL_SEQ].Value = iSeq;
            with_1.Cells[iRow, COL_LEVEL].Value = memberItem.MEMBER_DEPTH;
            with_1.Cells[iRow, COL_MEMBER_NAME].Value = memberItem.MEMBER_NAME;
            with_1.Cells[iRow, COL_MEMBER_TYPE].Value = memberItem.MEMBER_TYPE;

            if (memberItem.MEMBER_TYPE == "String")
            {
                with_1.Cells[iRow, COL_MEMBER_SIZE].Value = memberItem.MEMBER_SIZE;
            }
            else
            {
                with_1.Cells[iRow, COL_MEMBER_SIZE].Value = "";
            }

            with_1.Cells[iRow, COL_REQ_MEMBER_FLAG].Value = memberItem.REQ_MEMBER_FLAG;
            with_1.Cells[iRow, COL_OVERRIDE_FLAG].Value = memberItem.OVERRIDE_FLAG;
            with_1.Cells[iRow, COL_ARRY_TYPE].Value = memberItem.ARRAY_TYPE;
            with_1.Cells[iRow, COL_USE_RANGE_FLAG].Value = memberItem.USE_RANGE_FLAG;
            with_1.Cells[iRow, COL_RANGE_MIN].Value = memberItem.RANGE_MIN;
            with_1.Cells[iRow, COL_RANGE_MAX].Value = memberItem.RANGE_MAX;
            with_1.Cells[iRow, COL_PARENT_MEMBER_PATH].Value = memberItem.PARENT_MEMBER_PATH;

            switch (MPGV.gcLanguage)
            {
                case '1':
                    sDesc = memberItem.MEMBER_DESC_1;
                    AddRow(sDesc, spdMember);
                    break;
                case '2':
                    sDesc = memberItem.MEMBER_DESC_2;
                    AddRow(sDesc, spdMember);
                    break;
                case '3':
                    sDesc = memberItem.MEMBER_DESC_3;
                    AddRow(sDesc, spdMember);
                    break;
            }

            with_1.Cells[iRow, COL_MEMBER_NAME, iRow, with_1.ColumnCount - 1].Font = new Font(spdMember.Font.Name, spdMember.Font.Size, FontStyle.Bold);

            UnderLine(spdMember, iRow);
        }

        // AddRow()
        //       - Add one Row in spdMember
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void AddRow(string sDesc, FarPoint.Win.Spread.FpSpread spdMember)
        {
            int iRow;

            float fMemberSize;
            float fBlankSize;
            float fSeqSize;
            float fLevelSize;
            float fSpdMaxSize;
            

            FarPoint.Win.Spread.SheetView with_1 = spdMember.Sheets[0];
            FarPoint.Win.Spread.CellType.TextCellType txtCell = new FarPoint.Win.Spread.CellType.TextCellType();

            iRow = with_1.RowCount;
            with_1.RowCount++;

            fSeqSize = with_1.Cells[iRow, COL_SEQ].Column.Width;
            fLevelSize = with_1.Cells[iRow, COL_LEVEL].Column.Width;
            fMemberSize = with_1.Cells[iRow, COL_MEMBER_NAME].Column.Width;
            fBlankSize = with_1.Cells[iRow, COL_BLANK].Column.Width;

            fSpdMaxSize = spdMember.Size.Width - (fSeqSize + fLevelSize);
            with_1.Cells[iRow, COL_MEMBER_NAME].Column.Width = fSpdMaxSize;
                        
            txtCell.MaxLength = 1000;
            txtCell.WordWrap = true;
            txtCell.Multiline = true;
            with_1.Cells[iRow, COL_MEMBER_NAME, iRow, COL_BLANK].CellType = txtCell;

            with_1.Cells[iRow, COL_MEMBER_NAME].Font = new Font(spdMember.Font.Name, 8);
            with_1.Cells[iRow, COL_MEMBER_NAME].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            with_1.Cells[iRow, COL_MEMBER_NAME].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            with_1.Cells[iRow, COL_MEMBER_NAME].Value = MPCF.Trim(sDesc);
            with_1.Rows[iRow].Height = with_1.GetPreferredRowHeight(iRow) + 2.0f;

            with_1.Cells[iRow, COL_MEMBER_NAME].Column.Width = fMemberSize;
            with_1.AddSpanCell(iRow, COL_MEMBER_NAME, 1, COL_BLANK - COL_MEMBER_NAME + 1);
        }

        // UnderLine()
        //       - Add Under Line Border in spdMember
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void UnderLine(FarPoint.Win.Spread.FpSpread spdMember, int iRow)
        {
            spdMember.Sheets[0].Cells[spdMember.Sheets[0].RowCount - 1, COL_MEMBER_NAME, spdMember.Sheets[0].RowCount - 1, spdMember.Sheets[0].ColumnCount - 1].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        }

        #endregion

        private void frmSVMViewServiceMember_Load(object sender, EventArgs e)
        {

        }

        private void frmSVMViewServiceMember_Activated(object sender, EventArgs e)
        {
            if (b_load_flag != true)
            {
                View_Service_List();
                MPCF.ClearList(spdInMember, true);
                MPCF.ClearList(spdOutMember, true);
                b_load_flag = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Module Name : " + MPCF.Trim(txtModuleName.Text) + "\r";
            sCond = sCond + "Service Name : " + MPCF.Trim(txtServiceName.Text) + "\r";
            sCond = sCond + "Service Mode : " + MPCF.Trim(txtServiceMode.Text) + "\r";
            sCond = sCond + "Service Category : " + MPCF.Trim(txtServiceCategory.Text) + "\r";
            sCond = sCond + "Service Discription : " + MPCF.Trim(txtServiceDesc.Text) + "\r";

            if (tabMember.SelectedTab == tbpInput)
            {
                if (MPCF.ExportToExcel(spdInMember, this.Text, sCond) == false)
                {
                    return;
                }
            }
            else if (tabMember.SelectedTab == tbpOutput)
            {
                if (MPCF.ExportToExcel(spdOutMember, this.Text, sCond) == false)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lisService.SelectedItems.Count != 0)
            {
                ClearData();
                if (View_Service() == true)
                {
                    View_Service_member_list();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
 
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisService, this.Text, "");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_Service_List();
        }

        private void cdvModuleName_ButtonPress(object sender, EventArgs e)
        {
            cdvModuleName.Init();
            MPCF.InitListView(cdvModuleName.GetListView);
            cdvModuleName.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModuleName.SelectedSubItemIndex = 0;

            ViewModuleList(cdvModuleName.GetListView);
        }

        private void cdvModuleName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            View_Service_List();
        }

        private void lisService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisService.SelectedItems.Count != 0)
            {
                ClearData();
                if (View_Service() == true)
                {
                    View_Service_member_list();
                }
            }
        }

        private void spdMember_Resize(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.FpSpread spdMember;
            int i;
            float f_size;
            float f_blank_size;

            spdMember = (FarPoint.Win.Spread.FpSpread)sender;

            f_size = 0;
            f_blank_size = 0;
            for (i = 0; i < 12; i++)
            {
                f_size += spdMember.ActiveSheet.Columns[i].Width;
            }

            f_blank_size = (spdMember.Width - f_size) - 5;
            if (f_blank_size < 0)
            {
                f_blank_size = 0;
            }

            spdMember.ActiveSheet.Columns[12].Width = f_blank_size;            
        }

        private void spdMember_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            spdMember_Resize(sender, e);
        }
    }    
}