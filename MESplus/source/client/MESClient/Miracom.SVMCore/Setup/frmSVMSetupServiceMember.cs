
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSVMSetupServiceMember.cs
//   Description : Setup Service and Service Memeber Definition
//
//   MES Version : 5.0.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check Condition
//       - CheckAndSetEnables() : Check wether Set Enable or Set Diable
//       - SetReadOnly() : Set some controls's readonly property to true
//       - SetExportEnables() : Set Enables for export work
//       - SetServiceMember() : 
//       - IsEssentialMember() : Check member name is essential.
//       - AddMemberToTRSNode() : Add Members to TRSNode
//       - AddTreeNodeToTRSNode() : Tree node to TRSNode
//       - TraverTreeNode() : Traver Tree node
//       - Create_Init_Members() : Create essential member for new service (Only Draw Tree Node. No Insert Member Data).
//       - Delete_All_Service_Member() : Delete all service members when service is deleted
//       - View_Service() : View service
//       - View_Service_list() : View Service list
//       - View_Service_member_list() : View Service member list
//       - View_Member_List() :  View member list
//       - Create_Service() : Create service
//       - Update_Service() : Update service
//       - Delete_Service() : Delete all service members when service is deleted
//       - Update_Service_member_list() : Update service member list
//       - AddAttachNode() : Add Node to tree that name is "Attach Node..."
//       - GetIconIndex() : Get small icon index by member type and name
//       - GetServiceMembersToService() : Get Service members of selected service
//       - AddServiceMemberToTreeNode() : Add Service member to TreeNode for display
//       - InsertServiceMemberToTreeNode() : Insert Service member to TreeNode for display
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-11-19 : Created by HyunJong Noh
//       - 2009-04-16 : Modified by Phillip
//       - 2010-01-14 : Modified by InChul Bae
//       - 2011-01-13 : Modified by DooHyun Kim
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
using System.Xml.Serialization;
using System.IO;
using System.Collections;

using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using System.Reflection;


namespace Miracom.SVMCore
{
    public partial class frmSVMSetupServiceMember : Miracom.MESCore.SetupForm02
    {

        #region " Variable Definition"
        private bool b_load_flag = false;
        private bool b_export_stop = false;

        private bool old_override_flag;
        private bool new_override_flag;

        private string old_member_type;
        private string old_member_name;

        #endregion

        #region " Function Implementations"

        private void ClearData()
        {
            cdvModuleName.Text = "";
            txtServiceName.Text = "";
            cbxServiceMode.SelectedIndex = -1;
            cbxServiceCategory.SelectedIndex = -1;
            cbxServiceType.SelectedIndex = -1;
            cbxLogLevel.SelectedIndex = -1;
            txtServiceDesc_1.Text = "";
            txtServiceDesc_2.Text = "";
            txtServiceDesc_3.Text = "";
            rbnOptional.Checked = true;
            cdvMemberName.Text = "";
            txtMemberPrompt.Text = "";
            txtMemberDesc_1.Text = "";
            txtMemberDesc_2.Text = "";
            txtMemberDesc_3.Text = "";
            cdvSLibName.Text = "";
            txtMemberSize.Text = "";
            cbxMemberType.SelectedIndex = -1;
            trvInMember.Nodes.Clear();
            trvOutMember.Nodes.Clear();
            txtExport.Text = "";

            chkOverride.Checked = false;
            chkUseRange.Checked = false;
            nudRangeMax.Value = 0;
            nudRangeMin.Value = 0;

            SetReadOnly(true);

            btnCreateMember.Enabled = false;
            chkCreateDefault.Checked = true;

            MPCF.FieldClear(grpCMF);
        }

        private bool CheckCondition(string FuncName, char step)
        {
            switch (FuncName)
            {
                case "Service":
                    if (MPCF.CheckValue(cdvModuleName, 1) == false)
                    {
                        cdvModuleName.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtServiceName, 1) == false)
                    {
                        txtServiceName.Focus();
                        return false;
                    }

                    if (step != MPGC.MP_STEP_DELETE)
                    {
                        if (MPCF.CheckValue(cbxServiceMode, 1) == false)
                        {
                            cbxServiceMode.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cbxServiceCategory, 1) == false)
                        {
                            cbxServiceCategory.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(txtServiceDesc_1, 1) == false)
                        {
                            txtServiceDesc_1.Focus();
                            return false;
                        }
                        //CMF Validation Check
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            return false;
                        }

                        if (cbxServiceType.SelectedIndex < 0)
                        {
                            cbxServiceType.SelectedIndex = 2;
                        }

                        if (cbxLogLevel.SelectedIndex < 0)
                        {
                            cbxLogLevel.SelectedIndex = 0;
                        }

                    }

                    break;

                case "Member":
                    if (MPCF.CheckValue(cdvMemberName, 1) == false)
                    {
                        cdvMemberName.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cbxMemberType, 1) == false)
                    {
                        cbxMemberType.Focus();
                        return false;
                    }
                    if (cbxMemberType.Text == "String")
                    {
                        if (MPCF.CheckValue(txtMemberSize, 1) == false)
                        {
                            txtMemberSize.Focus();
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(txtMemberDesc_1, 1) == false)
                    {
                        txtServiceDesc_1.Focus();
                        return false;
                    }
                    if (chkUseRange.Checked)
                    {
                        if (nudRangeMin.Value.ToString() == "")
                        {
                            if (MPCF.CheckValue(nudRangeMin, 1) == false)
                            {
                                nudRangeMin.Focus();
                                return false;
                            }
                        }
                        if (nudRangeMax.Value.ToString() == "")
                        {
                            if (MPCF.CheckValue(nudRangeMax, 1) == false)
                            {
                                nudRangeMax.Focus();
                                return false;
                            }
                        }
                    }
                    break;
            }

            return true;
        }

        private bool CheckAndSetEnables(TreeNode treeNode)
        {
            btnCreateMember.Enabled = false;

            // Root Node인 경우
            if (treeNode.Tag == null && treeNode.Name != "Attach Node...")
            {
                MPCR.ChangeControlEnabled(this, btnAddMemberChild, true);
                btnAddMember.Enabled = false;
                btnModifyMember.Enabled = false;
                btnDeleteMember.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnInto.Enabled = false;
                btnGoout.Enabled = false;
                return false;
            }
            // Attach Node인 경우
            else if (treeNode.Name == "Attach Node...")
            {
                MPCR.ChangeControlEnabled(this, btnAddMember, true);
                btnAddMemberChild.Enabled = false;
                btnModifyMember.Enabled = false;
                btnDeleteMember.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnInto.Enabled = false;
                btnGoout.Enabled = false;
                return false;
            }

            ServiceMember serviceMember = (ServiceMember)treeNode.Tag;

            // 필수 요소인 경우 Modify, Delete 버튼 비활성화
            if (IsEssentialMember(treeNode, tabMember.SelectedIndex == 0))
            {
                if (serviceMember.OVERRIDE_FLAG == 'Y')
                {
                    btnAddMember.Enabled = false;
                    btnAddMemberChild.Enabled = false;
                    MPCR.ChangeControlEnabled(this, btnModifyMember, true);
                    btnDeleteMember.Enabled = false;
                    btnUp.Enabled = false;
                    btnDown.Enabled = false;
                    btnInto.Enabled = false;
                    btnGoout.Enabled = false;
                }
                else
                {
                    btnAddMember.Enabled = false;
                    btnAddMemberChild.Enabled = false;
                    btnModifyMember.Enabled = false;
                    btnDeleteMember.Enabled = false;
                    btnUp.Enabled = false;
                    btnDown.Enabled = false;
                    btnInto.Enabled = false;
                    btnGoout.Enabled = false;
                }
            }
            // Array 인 경우 처리
            else if (serviceMember.MEMBER_TYPE == "Array")
            {
                MPCR.ChangeControlEnabled(this, btnAddMember, true);
                btnAddMemberChild.Enabled = false;
                MPCR.ChangeControlEnabled(this, btnModifyMember, true);
                MPCR.ChangeControlEnabled(this, btnDeleteMember, true);
                MPCR.ChangeControlEnabled(this, btnUp, true);
                MPCR.ChangeControlEnabled(this, btnDown, true);
                MPCR.ChangeControlEnabled(this, btnInto, true);
                MPCR.ChangeControlEnabled(this, btnGoout, true);
            }
            // 그밖의 노드인 경우 처리
            else
            {
                MPCR.ChangeControlEnabled(this, btnAddMember, true);
                MPCR.ChangeControlEnabled(this, btnAddMemberChild, true);
                MPCR.ChangeControlEnabled(this, btnModifyMember, true);
                MPCR.ChangeControlEnabled(this, btnDeleteMember, true);
                MPCR.ChangeControlEnabled(this, btnUp, true);
                MPCR.ChangeControlEnabled(this, btnDown, true);
                MPCR.ChangeControlEnabled(this, btnInto, true);
                MPCR.ChangeControlEnabled(this, btnGoout, true);
            }


            return true;
        }

        private void SetReadOnly(bool value)
        {
            cbxMemberType.Enabled = !value;
            cbxArrayType.Enabled = !value;
            txtMemberSize.ReadOnly = value;
            chkUseRange.Enabled = !value;
            if (chkUseRange.Checked && chkUseRange.Enabled)
            {
                nudRangeMin.Enabled = true;
                nudRangeMax.Enabled = true;
            }
            else
            {
                nudRangeMin.Enabled = false;
                nudRangeMax.Enabled = false;
            }
            txtMemberDesc_1.ReadOnly = value;
            txtMemberDesc_2.ReadOnly = value;
            txtMemberDesc_3.ReadOnly = value;
        }

        private void SetExportEnables(bool value)
        {
            MPCR.ChangeControlEnabled(this, btnExport, value);
            MPCR.ChangeControlEnabled(this, btnExportFile, value);
            MPCR.ChangeControlEnabled(this, btnCreate, value);
            MPCR.ChangeControlEnabled(this, btnUpdate, value);
            MPCR.ChangeControlEnabled(this, btnDelete, value);

            txtExportFile.Enabled = value;
            cdvExportModule.Enabled = value;

            txtErrorCodeExportFile.Enabled = value;
            MPCR.ChangeControlEnabled(this, btnErrorCodeExport, value);
            MPCR.ChangeControlEnabled(this, btnErrorCodeExportFile, value);

            txtTableDescExportFile.Enabled = value;
            MPCR.ChangeControlEnabled(this, btnTableDescExport, value);
            MPCR.ChangeControlEnabled(this, btnTableDescExportFile, value);
        }

        // Modified By InChul Bae - For Conditional Mandatory Check
        private void SetNodeFontStyle(ref TreeNode node, char cReqFlag, bool isOverride)
        {
            if (cReqFlag == 'M')
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Bold | FontStyle.Underline : FontStyle.Bold));
            }
            else if (cReqFlag == 'C')
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Italic | FontStyle.Underline : FontStyle.Italic));
            }
            else
            {
                node.NodeFont = new Font("Microsoft Sans Serif", 8.25f, (isOverride ? FontStyle.Regular | FontStyle.Underline : FontStyle.Regular));
            }
        }

        private void SetServiceMember(ref ServiceMember serviceMember, int depth, char direction)
        {
            serviceMember.MODULE_NAME = cdvModuleName.Text;
            serviceMember.SERVICE_NAME = txtServiceName.Text;
            serviceMember.DIRECTION = direction;

            serviceMember.MEMBER_DEPTH = depth;

            serviceMember.MEMBER_NAME = cdvMemberName.Text;
            serviceMember.MEMBER_PRT = txtMemberPrompt.Text;
            serviceMember.MEMBER_SEQ = 100;
            serviceMember.MEMBER_DESC_1 = txtMemberDesc_1.Text;
            serviceMember.MEMBER_DESC_2 = txtMemberDesc_2.Text;
            serviceMember.MEMBER_DESC_3 = txtMemberDesc_3.Text;
            serviceMember.MEMBER_TYPE = cbxMemberType.Text;
            serviceMember.ARRAY_TYPE = cbxArrayType.Text;
            serviceMember.MEMBER_SIZE = MPCF.ToInt(txtMemberSize.Text);

            // Mandatory, Optional radio button
            // Modified by InChul Bae - Conditional Mandatory 추가
            if (rbnMandatory.Checked)
                serviceMember.REQ_MEMBER_FLAG = 'M';
            else if (rbnCondMandatory.Checked)
                serviceMember.REQ_MEMBER_FLAG = 'C';
            else
                serviceMember.REQ_MEMBER_FLAG = 'O';

            // Override Field
            if (chkOverride.Checked)
                serviceMember.OVERRIDE_FLAG = 'Y';
            else
                serviceMember.OVERRIDE_FLAG = ' ';

            // Use Range Field
            if (chkUseRange.Checked)
            {
                serviceMember.USE_RANGE_FLAG = 'Y';
                serviceMember.RANGE_MIN = double.Parse(nudRangeMin.Value.ToString());
                serviceMember.RANGE_MAX = double.Parse(nudRangeMax.Value.ToString());
            }
            else
            {
                serviceMember.USE_RANGE_FLAG = ' ';
                serviceMember.RANGE_MIN = 0.0f;
                serviceMember.RANGE_MAX = 0.0f;
            }
        }

        private void SetRanges(string valueType)
        {
            double default_min = -99999999999999.0000;
            double default_max = 99999999999999.0000;

            short rangeValue_short = 32767;
            int rangeValue_int = 2147483647;
            long rangeValue_long = 99999999999999;

            ushort rangeValue_ushort = 65535;
            uint rangeValue_uint = 4294967295;
            ulong rangeValue_ulong = 99999999999999;

            int decimalPlaces = 0;
            decimal range_min = 0;
            decimal range_max = 0;


            switch (valueType)
            {
                case "String":
                case "Char":
                case "Binary":
                case "Boolean":
                case "Datetime":
                case "Blob":
                case "List":
                case "Array":
                case "Float":
                case "Double":
                    decimalPlaces = 4;
                    range_min = (decimal)default_min;
                    range_max = (decimal)default_max;
                    break;
                /* Unsigned */
                case "UShort":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_ushort;
                    break;
                case "UInt":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_uint;
                    break;
                case "ULong":
                    decimalPlaces = 0;
                    range_min = 0;
                    range_max = rangeValue_ulong;
                    break;
                /* Signed */
                case "Short":
                    decimalPlaces = 0;
                    range_min = -1 - rangeValue_short;
                    range_max = rangeValue_short;
                    break;
                case "Int":
                    decimalPlaces = 0;
                    range_min = -1 - rangeValue_int;
                    range_max = rangeValue_int;
                    break;
                case "Long":
                    decimalPlaces = 0;
                    range_min = 0 - rangeValue_long;
                    range_max = rangeValue_long;
                    break;
            }

            nudRangeMin.DecimalPlaces = decimalPlaces;
            nudRangeMax.DecimalPlaces = decimalPlaces;
            nudRangeMin.Minimum = range_min;
            nudRangeMin.Maximum = range_max;
            nudRangeMax.Minimum = range_min;
            nudRangeMax.Maximum = range_max;
        }

        private bool IsEssentialMember(TreeNode node, bool IsInMember)
        {
            if (node == null || node.Tag == null)
                return false;

            ServiceMember serviceMember = (ServiceMember)node.Tag;

            // 필수 항목들은 최상위에만 적용되고 있는것을 기본으로 고려
            if (serviceMember.MEMBER_DEPTH != 0)
                return false;

            if (IsInMember)
            {
                switch (serviceMember.MEMBER_NAME)
                {
                    //In Part
                    case TRSDefine.IN_FACTORY:
                    case TRSDefine.IN_LANGUAGE:
                    case TRSDefine.IN_PASSPORT:
                    case TRSDefine.IN_PASSWORD:
                    case TRSDefine.IN_PROCSTEP:
                    case TRSDefine.IN_USERID:
                    case TRSDefine.IN_LOGLEVEL:
                        return true;
                    //Out Part
                }
            }
            else
            {
                switch (serviceMember.MEMBER_NAME)
                {
                    case TRSDefine.OUT_DBERRMSG:
                    case TRSDefine.OUT_FIELDMSG:
                    case TRSDefine.OUT_MSG:
                    case TRSDefine.OUT_MSGCATE:
                    case TRSDefine.OUT_MSGCODE:
                    case TRSDefine.OUT_STATUSVALUE:
                        return true;
                }
            }

            return false;
        }

        private bool IsEssentialMember(ServiceMember serviceMember)
        {

            // 필수 항목들은 최상위에만 적용되고 있는것을 기본으로 고려
            if (serviceMember.MEMBER_DEPTH != 0)
                return false;

            if (serviceMember.DIRECTION == 'I')
            {
                switch (serviceMember.MEMBER_NAME)
                {
                    //In Part
                    case TRSDefine.IN_FACTORY:
                    case TRSDefine.IN_LANGUAGE:
                    case TRSDefine.IN_PASSPORT:
                    case TRSDefine.IN_PASSWORD:
                    case TRSDefine.IN_PROCSTEP:
                    case TRSDefine.IN_USERID:
                    case TRSDefine.IN_LOGLEVEL:
                        return true;
                    //Out Part
                }
            }
            else
            {
                switch (serviceMember.MEMBER_NAME)
                {
                    case TRSDefine.OUT_DBERRMSG:
                    case TRSDefine.OUT_FIELDMSG:
                    case TRSDefine.OUT_MSG:
                    case TRSDefine.OUT_MSGCATE:
                    case TRSDefine.OUT_MSGCODE:
                    case TRSDefine.OUT_STATUSVALUE:
                        return true;
                }
            }

            return false;

        }

        private void AddMemberToTRSNode(ref TRSNode node, string module, string service, Member serviceMember)
        {

            TRSNode item;
            if (node == null || serviceMember == null)
                return;

            item = node.AddNode("MEMBER_LIST");

            item.AddChar("DIRECTION", serviceMember.Direction);
            item.AddInt("MEMBER_DEPTH", serviceMember.Depth);
            item.AddString("MEMBER_NAME", serviceMember.Name);
            item.AddString("MEMBER_PRT", serviceMember.Prompt);
            item.AddInt("MEMBER_SEQ", serviceMember.Sequence);
            item.AddChar("REQ_MEMBER_FLAG", serviceMember.RequireFlag);
            item.AddString("PARENT_MEMBER_PATH", serviceMember.ParentPath);
            item.AddChar("OVERRIDE_FLAG", serviceMember.OverrideFlag);

            item.AddString("MEMBER_DESC_1", serviceMember.Desc1);
            item.AddString("MEMBER_DESC_2", serviceMember.Desc2);
            item.AddString("MEMBER_DESC_3", serviceMember.Desc3);
            item.AddString("MEMBER_TYPE", serviceMember.Type);
            item.AddString("ARRAY_TYPE", serviceMember.ArrayType);
            item.AddInt("MEMBER_SIZE", serviceMember.Size);
            item.AddChar("USE_RANGE_FLAG", serviceMember.UseRangeFlag);
            item.AddDouble("RANGE_MIN", serviceMember.RangeMin);
            item.AddDouble("RANGE_MAX", serviceMember.RangeMax);
            item.AddString("MEMBER_PATH", serviceMember.MemberPath);
        }

        private void AddTreeNodeToTRSNode(ref TRSNode node, TreeNode treeNode)
        {
            TRSNode item;
            if (node == null || treeNode == null || treeNode.Tag == null)
                return;

            ServiceMember serviceMember = (ServiceMember)treeNode.Tag;

            item = node.AddNode("MEMBER_LIST");

            item.AddChar("DIRECTION", serviceMember.DIRECTION);
            item.AddInt("MEMBER_DEPTH", serviceMember.MEMBER_DEPTH);
            item.AddString("MEMBER_NAME", serviceMember.MEMBER_NAME);
            item.AddString("MEMBER_PRT", serviceMember.MEMBER_PRT);
            item.AddInt("MEMBER_SEQ", treeNode.Index);
            item.AddChar("REQ_MEMBER_FLAG", serviceMember.REQ_MEMBER_FLAG);
            item.AddString("PARENT_MEMBER_PATH", serviceMember.PARENT_MEMBER_PATH);
            item.AddChar("OVERRIDE_FLAG", serviceMember.OVERRIDE_FLAG);

            item.AddString("MEMBER_DESC_1", serviceMember.MEMBER_DESC_1);
            item.AddString("MEMBER_DESC_2", serviceMember.MEMBER_DESC_2);
            item.AddString("MEMBER_DESC_3", serviceMember.MEMBER_DESC_3);
            item.AddString("MEMBER_TYPE", serviceMember.MEMBER_TYPE);
            item.AddString("ARRAY_TYPE", serviceMember.ARRAY_TYPE);
            item.AddInt("MEMBER_SIZE", serviceMember.MEMBER_SIZE);
            item.AddChar("USE_RANGE_FLAG", serviceMember.USE_RANGE_FLAG);
            item.AddDouble("RANGE_MIN", serviceMember.RANGE_MIN);
            item.AddDouble("RANGE_MAX", serviceMember.RANGE_MAX);
            item.AddString("MEMBER_PATH", serviceMember.MEMBER_PATH);
        }

        private void TraverTreeNode(ref TRSNode node, TreeNode treeNode)
        {
            if (treeNode == null)
                return;

            AddTreeNodeToTRSNode(ref node, treeNode);

            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                TraverTreeNode(ref node, treeNode.Nodes[i]);
            }
        }

        private void TraverTreeNode(ref TRSNode node, TreeView treeView)
        {
            if (treeView == null)
                return;

            TreeNode treeNode = treeView.Nodes[0];

            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                TraverTreeNode(ref node, treeNode.Nodes[i]);
            }
        }

        private void Default_Members(ref TRSNode in_node)
        {
            TRSNode default_item;

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_PASSPORT);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_PASSPORT);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_PASSPORT);
            default_item.AddInt("MEMBER_SEQ", 0);
            default_item.AddString("MEMBER_TYPE", "String");
            default_item.AddInt("MEMBER_SIZE", 100);
            default_item.AddChar("REQ_MEMBER_FLAG", 'O');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_PASSPORT);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_LANGUAGE);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_LANGUAGE);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_LANGUAGE);
            default_item.AddInt("MEMBER_SEQ", 1);
            default_item.AddString("MEMBER_TYPE", "Char");
            default_item.AddInt("MEMBER_SIZE", 1);
            default_item.AddChar("REQ_MEMBER_FLAG", 'O');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_LANGUAGE);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_LOGLEVEL);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_LOGLEVEL);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_LOGLEVEL);
            default_item.AddInt("MEMBER_SEQ", 2);
            default_item.AddString("MEMBER_TYPE", "Char");
            default_item.AddInt("MEMBER_SIZE", 1);
            default_item.AddChar("REQ_MEMBER_FLAG", 'O');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_LOGLEVEL);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_FACTORY);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_FACTORY);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_FACTORY);
            default_item.AddInt("MEMBER_SEQ", 3);
            default_item.AddString("MEMBER_TYPE", "String");
            default_item.AddInt("MEMBER_SIZE", 10);
            default_item.AddChar("REQ_MEMBER_FLAG", 'M');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_FACTORY);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_USERID);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_USERID);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_USERID);
            default_item.AddInt("MEMBER_SEQ", 4);
            default_item.AddString("MEMBER_TYPE", "String");
            default_item.AddInt("MEMBER_SIZE", 20);
            default_item.AddChar("REQ_MEMBER_FLAG", 'O');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_USERID);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_PASSWORD);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_PASSWORD);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_PASSWORD);
            default_item.AddInt("MEMBER_SEQ", 5);
            default_item.AddString("MEMBER_TYPE", "String");
            default_item.AddInt("MEMBER_SIZE", 20);
            default_item.AddChar("REQ_MEMBER_FLAG", 'O');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_PASSWORD);

            default_item = in_node.AddNode("MEMBER_LIST");
            default_item.AddChar("DIRECTION", 'I');
            default_item.AddInt("MEMBER_DEPTH", 0);
            default_item.AddString("MEMBER_NAME", TRSDefine.IN_PROCSTEP);
            default_item.AddString("MEMBER_PRT", TRSDefine.IN_PROCSTEP);
            default_item.AddString("MEMBER_DESC_1", TRSDefine.IN_PROCSTEP);
            default_item.AddInt("MEMBER_SEQ", 6);
            default_item.AddString("MEMBER_TYPE", "Char");
            default_item.AddInt("MEMBER_SIZE", 1);
            default_item.AddChar("REQ_MEMBER_FLAG", 'M');
            default_item.AddChar("OVERRIDE_FLAG", ' ');
            default_item.AddChar("USE_RANGE_FLAG", ' ');
            default_item.AddDouble("RANGE_MIN", 0.0f);
            default_item.AddDouble("RANGE_MAX", 0.0f);
            default_item.AddString("MEMBER_PATH", TRSDefine.IN_PROCSTEP);

            // Modified by InChul Bae - Request Reply를 제외한 Service Mode에서 Default Out Member를 생성하지 않기 위해 변경
            if (cbxServiceMode.Text == "Request Reply")
            {
                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_STATUSVALUE);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_STATUSVALUE);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_STATUSVALUE);
                default_item.AddInt("MEMBER_SEQ", 0);
                default_item.AddString("MEMBER_TYPE", "Char");
                default_item.AddInt("MEMBER_SIZE", 1);
                default_item.AddChar("REQ_MEMBER_FLAG", 'M');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddDouble("RANGE_MIN", 0.0f);
                default_item.AddDouble("RANGE_MAX", 0.0f);
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_STATUSVALUE);

                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_MSGCODE);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_MSGCODE);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_MSGCODE);
                default_item.AddInt("MEMBER_SEQ", 1);
                default_item.AddString("MEMBER_TYPE", "String");
                default_item.AddInt("MEMBER_SIZE", 10);
                default_item.AddChar("REQ_MEMBER_FLAG", 'M');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddDouble("RANGE_MIN", 0.0f);
                default_item.AddDouble("RANGE_MAX", 0.0f);
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_MSGCODE);

                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_MSG);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_MSG);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_MSG);
                default_item.AddInt("MEMBER_SEQ", 2);
                default_item.AddString("MEMBER_TYPE", "String");
                default_item.AddInt("MEMBER_SIZE", 200);
                default_item.AddChar("REQ_MEMBER_FLAG", 'M');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddDouble("RANGE_MIN", 0.0f);
                default_item.AddDouble("RANGE_MAX", 0.0f);
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_MSG);

                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_MSGCATE);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_MSGCATE);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_MSGCATE);
                default_item.AddInt("MEMBER_SEQ", 3);
                default_item.AddString("MEMBER_TYPE", "Char");
                default_item.AddInt("MEMBER_SIZE", 1);
                default_item.AddChar("REQ_MEMBER_FLAG", 'M');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_MSGCATE);

                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_FIELDMSG);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_FIELDMSG);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_FIELDMSG);
                default_item.AddInt("MEMBER_SEQ", 4);
                default_item.AddString("MEMBER_TYPE", "List");
                default_item.AddInt("MEMBER_SIZE", 200);
                default_item.AddChar("REQ_MEMBER_FLAG", 'O');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddDouble("RANGE_MIN", 0.0f);
                default_item.AddDouble("RANGE_MAX", 0.0f);
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_FIELDMSG);

                default_item = in_node.AddNode("MEMBER_LIST");
                default_item.AddChar("DIRECTION", 'O');
                default_item.AddInt("MEMBER_DEPTH", 0);
                default_item.AddString("MEMBER_NAME", TRSDefine.OUT_DBERRMSG);
                default_item.AddString("MEMBER_PRT", TRSDefine.OUT_DBERRMSG);
                default_item.AddString("MEMBER_DESC_1", TRSDefine.OUT_DBERRMSG);
                default_item.AddInt("MEMBER_SEQ", 5);
                default_item.AddString("MEMBER_TYPE", "String");
                default_item.AddInt("MEMBER_SIZE", 200);
                default_item.AddChar("REQ_MEMBER_FLAG", 'O');
                default_item.AddChar("OVERRIDE_FLAG", ' ');
                default_item.AddChar("USE_RANGE_FLAG", ' ');
                default_item.AddDouble("RANGE_MIN", 0.0f);
                default_item.AddDouble("RANGE_MAX", 0.0f);
                default_item.AddString("MEMBER_PATH", TRSDefine.OUT_DBERRMSG);
            }          
        }

        private bool Create_Init_Members()
        { 
            trvInMember.Nodes.Clear();
            trvOutMember.Nodes.Clear();

            TRSNode in_node = new TRSNode("View_Service_Member_List_In");

            List<ServiceMember> InMemberList = new List<ServiceMember>();
            List<ServiceMember> OutMemberList = new List<ServiceMember>();

            ServiceMember serviceMember;
            TRSNode default_item;
            TreeNode InTreeNode = null;
            TreeNode OutTreeNode = null;

            MPCR.SetInMsg(in_node);

            // Added by Phillip 2009. 4. 16 (MODUL_NAME and SERVICE_NAME field를 Root에 포함시키게 변경)
            Default_Members(ref in_node);

            for (int i = 0; i < in_node.GetList(0).Count; i++)
            {
                serviceMember = new ServiceMember();
                default_item = in_node.GetList(0)[i];

                serviceMember.DIRECTION = default_item.GetChar("DIRECTION");
                serviceMember.MEMBER_DEPTH = default_item.GetInt("MEMBER_DEPTH");
                serviceMember.MEMBER_NAME = default_item.GetString("MEMBER_NAME");
                serviceMember.MEMBER_PRT = default_item.GetString("MEMBER_PRT");
                serviceMember.MEMBER_DESC_1 = default_item.GetString("MEMBER_DESC_1");
                serviceMember.MEMBER_SEQ = default_item.GetInt("MEMBER_SEQ");
                serviceMember.MEMBER_TYPE = default_item.GetString("MEMBER_TYPE");
                serviceMember.MEMBER_SIZE = default_item.GetInt("MEMBER_SIZE");
                serviceMember.REQ_MEMBER_FLAG = default_item.GetChar("REQ_MEMBER_FLAG");
                serviceMember.OVERRIDE_FLAG = default_item.GetChar("OVERRIDE_FLAG");
                serviceMember.USE_RANGE_FLAG = default_item.GetChar("USE_RANGE_FLAG");
                serviceMember.RANGE_MIN = default_item.GetDouble("RANGE_MIN");
                serviceMember.RANGE_MAX = default_item.GetDouble("RANGE_MAX");
                serviceMember.MEMBER_PATH = default_item.GetString("MEMBER_PATH");

                if (serviceMember.DIRECTION == 'I')
                    InMemberList.Add(serviceMember);
                else
                    OutMemberList.Add(serviceMember);
            }

            InTreeNode = trvInMember.Nodes.Add("[In Member]");

            foreach (ServiceMember memberItem in InMemberList)
            {
                AddServiceMemberToTreeNode(InTreeNode, memberItem);
            }

            AddAttachNode(InTreeNode);


            OutTreeNode = trvOutMember.Nodes.Add("[Out Member]");

            foreach (ServiceMember memberItem in OutMemberList)
            {
                AddServiceMemberToTreeNode(OutTreeNode, memberItem);
            }

            AddAttachNode(OutTreeNode);

            InTreeNode.ExpandAll();
            OutTreeNode.ExpandAll();
            InTreeNode.EnsureVisible();
            OutTreeNode.EnsureVisible();

            return true;
        }

        private bool View_Service(ref TRSNode out_node)
        {
            if (lisService.SelectedItems.Count == 0)
                return false;

            TRSNode in_node = new TRSNode("View_Service_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MODULE_NAME", lisService.SelectedItems[0].SubItems[0].Text);
            in_node.AddString("SERVICE_NAME", lisService.SelectedItems[0].SubItems[1].Text);

            if (MPCR.CallService("SVM", "SVM_View_Service", in_node, ref out_node, false) == false)
            {
                return false;
            }

            cdvModuleName.Text = out_node.GetString("MODULE_NAME");
            txtServiceName.Text = out_node.GetString("SERVICE_NAME");
            
            txtServiceDesc_1.Text = out_node.GetString("SERVICE_DESC_1");
            txtServiceDesc_2.Text = out_node.GetString("SERVICE_DESC_2");
            txtServiceDesc_3.Text = out_node.GetString("SERVICE_DESC_3");

            cdvSLibName.Text = out_node.GetString("SHARED_LIB_NAME");

            if (out_node.GetChar("SEC_CHK_FLAG") == 'Y')
            {
                chkSecurity.Checked = true;
            }
            else
            {
                chkSecurity.Checked = false;
            }

            switch (out_node.GetString("SERVICE_MODE"))
            {
                case "RR":
                    cbxServiceMode.Text = "Request Reply";
                    break;
                case "RN":
                    cbxServiceMode.Text = "Request No Reply";
                    break;
                case "MC":
                    cbxServiceMode.Text = "MultiCast";
                    break;
                case "GU":
                    cbxServiceMode.Text = "Garuanteed Unicast";
                    break;
                case "GM":
                    cbxServiceMode.Text = "Garuanteed Multicast";
                    break;
            }

            switch (out_node.GetChar("SERVICE_CATEGORY"))
            {
                case 'I':
                    cbxServiceCategory.Text = "Inquiry";
                    break;
                case 'S':
                    cbxServiceCategory.Text = "Setup";
                    break;
                case 'T':
                    cbxServiceCategory.Text = "Transaction";
                    break;
            }

            switch (out_node.GetChar("SERVICE_TYPE"))
            {
                case 'S':
                    cbxServiceType.SelectedIndex = 0;
                    break;
                case 'I':
                    cbxServiceType.SelectedIndex = 1;
                    break;
                case 'G':
                    cbxServiceType.SelectedIndex = 2;
                    break;
                default:
                    cbxServiceType.SelectedIndex = 2;
                    break;
            }

            switch (out_node.GetChar("LOG_LEVEL"))
            {
                case '0':
                    cbxLogLevel.SelectedIndex = 1;
                    break;
                case '1':
                    cbxLogLevel.SelectedIndex = 2;
                    break;
                case '2':
                    cbxLogLevel.SelectedIndex = 3;
                    break;
                case '3':
                    cbxLogLevel.SelectedIndex = 4;
                    break;
                default:
                    cbxLogLevel.SelectedIndex = 0;
                    break;
            }

            cdvCMF1.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_1"));
            cdvCMF2.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_2"));
            cdvCMF3.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_3"));
            cdvCMF4.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_4"));
            cdvCMF5.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_5"));
            cdvCMF6.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_6"));
            cdvCMF7.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_7"));
            cdvCMF8.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_8"));
            cdvCMF9.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_9"));
            cdvCMF10.Text = MPCF.Trim(out_node.GetString("SERVICE_CMF_10"));

            txtServiceCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtServiceCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtServiceUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtServiceUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            return true;
        }

        private bool View_Service_list()
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem viewItem;

            MPCF.InitListView(lisService);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvSelectModule.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = lisService.Items.Add(new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MODULE_NAME"), 
                                                                                    out_node.GetList(0)[i].GetString("SERVICE_NAME"), 
                                                                                    out_node.GetList(0)[i].GetString("SERVICE_DESC_1")},
                                                                                    (int)SMALLICON_INDEX.IDX_MODULE));
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            MPCF.FitColumnHeader(lisService);

            lblDataCount.Text = out_node.GetList(0).Count.ToString();

            return true;
        }

        private bool View_Service_member()
        {
            TRSNode in_node = new TRSNode("View_Member_In");
            TRSNode out_node = new TRSNode("View_Member_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MEMBER_NAME", cdvMemberName.Text);

            if (MPCR.CallService("SVM", "SVM_View_Member", in_node, ref out_node, true) == false)
            {
                return false;
            }

            if (out_node.GetString("MEMBER_NAME") != "")
            {
                cdvMemberName.Text = out_node.GetString("MEMBER_NAME");
                txtMemberDesc_1.Text = out_node.GetString("MEMBER_DESC_1");
                txtMemberDesc_2.Text = out_node.GetString("MEMBER_DESC_2");
                txtMemberDesc_3.Text = out_node.GetString("MEMBER_DESC_3");

                txtMemberCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtMemberCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtMemberUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtMemberUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                if (out_node.GetChar("OVERRIDE_FLAG") == 'Y')
                {
                    chkOverride.Checked = true;
                }
                else
                {
                    chkOverride.Checked = false;
                }

                if (out_node.GetChar("USE_RANGE_FLAG") == 'Y')
                {
                    chkUseRange.Checked = true;
                    nudRangeMin.Value = decimal.Parse(out_node.GetDouble("RANGE_MIN").ToString());
                    nudRangeMax.Value = decimal.Parse(out_node.GetDouble("RANGE_MAX").ToString());
                }
                else
                {
                    chkUseRange.Checked = false;
                    nudRangeMin.Value = 0;
                    nudRangeMax.Value = 0;
                }

                txtMemberSize.Text = out_node.GetInt("MEMBER_SIZE").ToString();
                cbxMemberType.Text = out_node.GetString("MEMBER_TYPE");
                cbxArrayType.Text = out_node.GetString("ARRAY_TYPE");

                rbnOptional.Checked = true;
            }

            return true;
        }

        private bool View_Service_member_list()
        {
            if (lisService.SelectedItems.Count == 0)
                return false;

            trvInMember.Nodes.Clear();
            trvOutMember.Nodes.Clear();

            TRSNode in_node = new TRSNode("View_Service_Member_List_In");
            TRSNode out_node = new TRSNode("View_Service_Member_List_Out");
            List<ServiceMember> InMemberList = new List<ServiceMember>();
            List<ServiceMember> OutMemberList = new List<ServiceMember>();

            ServiceMember serviceMember;
            TRSNode item;
            TreeNode InTreeNode = null;
            TreeNode OutTreeNode = null;
            TreeNode tn_parent;
            int i_member_count;

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

                i_member_count = out_node.GetList(0).Count;
                for (int i = 0; i < i_member_count; i++)
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
                    serviceMember.MEMBER_PATH = item.GetString("MEMBER_PATH");
                    serviceMember.ARRAY_TYPE = item.GetString("ARRAY_TYPE");

                    serviceMember.MEMBER_SIZE = item.GetInt("MEMBER_SIZE");

                    // added by Phillip 2009. 04. 20 
                    // modified by InChul Bae - Conditional Mandatory 추가
                    if (item.GetChar("REQ_MEMBER_FLAG") != 'M' && item.GetChar("REQ_MEMBER_FLAG") != 'O' && item.GetChar("REQ_MEMBER_FLAG") != 'C')
                    {
                        serviceMember.REQ_MEMBER_FLAG = 'O';
                    }
                    else
                    {
                        serviceMember.REQ_MEMBER_FLAG = item.GetChar("REQ_MEMBER_FLAG");
                    }

                    serviceMember.PARENT_MEMBER_PATH = item.GetString("PARENT_MEMBER_PATH");

                    if (item.GetChar("OVERRIDE_FLAG") != 'Y' && item.GetChar("OVERRIDE_FLAG") != ' ')
                    {
                        serviceMember.OVERRIDE_FLAG = ' ';
                    }
                    else
                    {
                        serviceMember.OVERRIDE_FLAG = item.GetChar("OVERRIDE_FLAG");
                    }

                    if (item.GetChar("USE_RANGE_FLAG") != 'Y' && item.GetChar("USE_RANGE_FLAG") != ' ')
                    {
                        serviceMember.USE_RANGE_FLAG = ' ';
                    }
                    else
                    {
                        serviceMember.USE_RANGE_FLAG = item.GetChar("USE_RANGE_FLAG");
                    }

                    serviceMember.RANGE_MIN = item.GetDouble("RANGE_MIN");
                    serviceMember.RANGE_MAX = item.GetDouble("RANGE_MAX");

                    serviceMember.CREATE_USER_ID = item.GetString("CREATE_USER_ID");
                    serviceMember.CREATE_TIME = item.GetString("CREATE_TIME");
                    serviceMember.UPDATE_USER_ID = item.GetString("UPDATE_USER_ID");
                    serviceMember.UPDATE_TIME = item.GetString("UPDATE_TIME");

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

                i_member_count = out_node.GetList(0).Count;
                for (int i = 0; i < i_member_count; i++)
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
                    serviceMember.ARRAY_TYPE = item.GetString("ARRAY_TYPE");
                    serviceMember.MEMBER_SIZE = item.GetInt("MEMBER_SIZE");
                    serviceMember.REQ_MEMBER_FLAG = item.GetChar("REQ_MEMBER_FLAG");
                    serviceMember.PARENT_MEMBER_PATH = item.GetString("PARENT_MEMBER_PATH");
                    serviceMember.OVERRIDE_FLAG = item.GetChar("OVERRIDE_FLAG");
                    serviceMember.USE_RANGE_FLAG = item.GetChar("USE_RANGE_FLAG");
                    serviceMember.RANGE_MIN = item.GetDouble("RANGE_MIN");
                    serviceMember.RANGE_MAX = item.GetDouble("RANGE_MAX");

                    serviceMember.CREATE_USER_ID = item.GetString("CREATE_USER_ID");
                    serviceMember.CREATE_TIME = item.GetString("CREATE_TIME");
                    serviceMember.UPDATE_USER_ID = item.GetString("UPDATE_USER_ID");
                    serviceMember.UPDATE_TIME = item.GetString("UPDATE_TIME");
                    serviceMember.MEMBER_PATH = item.GetString("MEMBER_PATH");

                    OutMemberList.Add(serviceMember);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);


            InTreeNode = trvInMember.Nodes.Add("[In Member]");

            tn_parent = null;
            foreach (ServiceMember memberItem in InMemberList)
            {
                if (memberItem.MEMBER_DEPTH == 0)
                {
                    tn_parent = InTreeNode;
                }
                else
                {
                    if (tn_parent != null && tn_parent.Tag != null)
                    {
                        if (((ServiceMember)(tn_parent.Tag)).MEMBER_PATH != memberItem.PARENT_MEMBER_PATH)
                        {
                            tn_parent = GetParentTreeNode(InTreeNode, memberItem.PARENT_MEMBER_PATH);
                        }
                    }
                    else
                    {
                        tn_parent = GetParentTreeNode(InTreeNode, memberItem.PARENT_MEMBER_PATH);
                    }
                }

                if (tn_parent != null)
                {
                    AddServiceMemberToTreeNode(tn_parent, memberItem);
                    AddAttachNode(tn_parent);
                }
            }

            if (InMemberList.Count == 0)
            {
                AddAttachNode(InTreeNode);
            }

            
            OutTreeNode = trvOutMember.Nodes.Add("[Out Member]");

            tn_parent = null;
            foreach (ServiceMember memberItem in OutMemberList)
            {
                if (memberItem.MEMBER_DEPTH == 0)
                {
                    tn_parent = OutTreeNode;
                }
                else
                {
                    if (tn_parent != null && tn_parent.Tag != null)
                    {
                        if (((ServiceMember)(tn_parent.Tag)).MEMBER_PATH != memberItem.PARENT_MEMBER_PATH)
                        {
                            tn_parent = GetParentTreeNode(OutTreeNode, memberItem.PARENT_MEMBER_PATH);
                        }
                    }
                    else
                    {
                        tn_parent = GetParentTreeNode(OutTreeNode, memberItem.PARENT_MEMBER_PATH);
                    }
                }

                if (tn_parent != null)
                {
                    AddServiceMemberToTreeNode(tn_parent, memberItem);
                    AddAttachNode(tn_parent);
                }
            }

            if (OutMemberList.Count == 0)
            {
                AddAttachNode(OutTreeNode);
            }

            InTreeNode.ExpandAll();
            OutTreeNode.ExpandAll();
            InTreeNode.EnsureVisible();
            OutTreeNode.EnsureVisible();

            return true;
        }

        private bool View_Member_List(ListView listView)
        {
            TRSNode in_node = new TRSNode("View_Member_List_In");
            TRSNode out_node = new TRSNode("View_Member_List_Out");

            ListViewItem viewItem;
            string member_name = "";
            int count = 0;

            MPCR.SetInMsg(in_node);


            if (cdvMemberName.Text.Trim() == "")
                in_node.ProcStep = '1';
            else
                in_node.ProcStep = '3';

            in_node.AddString("MEMBER_NAME", cdvMemberName.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Member_List", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MEMBER_NAME"),
                                                                   (int)SMALLICON_INDEX.IDX_MODULE));
                    count++;
                    member_name = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                }

                in_node.SetString("MEMBER_NAME", out_node.GetString("NEXT_MEMBER_NAME"));
            } while (in_node.GetString("MEMBER_NAME") != "");

            return true;
        }

        private bool View_Module_List(ListView listView, char step)
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

        private bool View_Shared_Lib_List(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT DISTINCT SHARED_LIB_NAME FROM MSVMSVCDEF ORDER BY SHARED_LIB_NAME");

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool Update_Service(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_SERVICE_IN");
            TRSNode out_node = new TRSNode("UPDATE_SERVICE_OUT");

            if (CheckCondition("Service", c_proc_step) == false)
                return false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_proc_step;
            in_node.AddString("MODULE_NAME", cdvModuleName.Text);
            in_node.AddString("SERVICE_NAME", txtServiceName.Text);

            if (c_proc_step != MPGC.MP_STEP_DELETE)
            {
                switch (cbxServiceMode.Text)
                {
                    case "Request Reply":
                        in_node.AddString("SERVICE_MODE", "RR");
                        break;
                    case "Request No Reply":
                        in_node.AddString("SERVICE_MODE", "RN");
                        break;
                    case "MultiCast":
                        in_node.AddString("SERVICE_MODE", "MC");
                        break;
                    case "Garuanteed Unicast":
                        in_node.AddString("SERVICE_MODE", "GU");
                        break;
                    case "Garuanteed Multicast":
                        in_node.AddString("SERVICE_MODE", "GM");
                        break;
                }

                in_node.AddChar("SERVICE_CATEGORY", cbxServiceCategory.Text[0]);
                in_node.AddChar("SERVICE_TYPE", cbxServiceType.Text[0]);
                in_node.AddChar("LOG_LEVEL", cbxLogLevel.Text[0]);

                in_node.AddString("SERVICE_DESC_1", txtServiceDesc_1.Text);
                in_node.AddString("SERVICE_DESC_2", txtServiceDesc_2.Text);
                in_node.AddString("SERVICE_DESC_3", txtServiceDesc_3.Text);

                in_node.AddString("SERVICE_CMF_1", cdvCMF1.Text);
                in_node.AddString("SERVICE_CMF_2", cdvCMF2.Text);
                in_node.AddString("SERVICE_CMF_3", cdvCMF3.Text);
                in_node.AddString("SERVICE_CMF_4", cdvCMF4.Text);
                in_node.AddString("SERVICE_CMF_5", cdvCMF5.Text);
                in_node.AddString("SERVICE_CMF_6", cdvCMF6.Text);
                in_node.AddString("SERVICE_CMF_7", cdvCMF7.Text);
                in_node.AddString("SERVICE_CMF_8", cdvCMF8.Text);
                in_node.AddString("SERVICE_CMF_9", cdvCMF9.Text);
                in_node.AddString("SERVICE_CMF_10", cdvCMF10.Text);

                if (chkSecurity.CheckState == CheckState.Checked)
                    in_node.AddChar("SEC_CHK_FLAG", 'Y');

                if (chkCreateDefault.Checked == true)
                {
                    in_node.AddChar("CREATE_DEFAULT_MEMBER_FLAG", 'Y');
                    Default_Members(ref in_node);
                }

                in_node.AddString("SHARED_LIB_NAME", cdvSLibName.Text);
            }

            if (MPCR.CallService("SVM", "SVM_Update_Service", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private bool Update_Service_member_list()
        {
            TRSNode in_node = new TRSNode("UPDATE_SERVICE_MEMBER_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_SERVICE_MEMBER_LIST_OUT");
            TRSNode service;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_CREATE;
            in_node.AddString("MODULE_NAME", cdvModuleName.Text);
            in_node.AddString("SERVICE_NAME", txtServiceName.Text);

            service = in_node.AddNode("SERVICE_INFO");

            switch (cbxServiceMode.Text)
            {
                case "Request Reply":
                    service.AddString("SERVICE_MODE", "RR");
                    break;
                case "Request No Reply":
                    service.AddString("SERVICE_MODE", "RN");
                    break;
                case "MultiCast":
                    service.AddString("SERVICE_MODE", "MC");
                    break;
                case "Garuanteed Unicast":
                    service.AddString("SERVICE_MODE", "GU");
                    break;
                case "Garuanteed Multicast":
                    service.AddString("SERVICE_MODE", "GM");
                    break;
            }

            service.AddChar("SERVICE_CATEGORY", cbxServiceCategory.Text[0]);
            service.AddChar("SERVICE_TYPE", cbxServiceType.Text[0]);
            service.AddChar("LOG_LEVEL", cbxLogLevel.Text[0]);

            service.AddString("SERVICE_DESC_1", txtServiceDesc_1.Text);
            service.AddString("SERVICE_DESC_2", txtServiceDesc_2.Text);
            service.AddString("SERVICE_DESC_3", txtServiceDesc_3.Text);

            service.AddString("SERVICE_CMF_1", cdvCMF1.Text);
            service.AddString("SERVICE_CMF_2", cdvCMF2.Text);
            service.AddString("SERVICE_CMF_3", cdvCMF3.Text);
            service.AddString("SERVICE_CMF_4", cdvCMF4.Text);
            service.AddString("SERVICE_CMF_5", cdvCMF5.Text);
            service.AddString("SERVICE_CMF_6", cdvCMF6.Text);
            service.AddString("SERVICE_CMF_7", cdvCMF7.Text);
            service.AddString("SERVICE_CMF_8", cdvCMF8.Text);
            service.AddString("SERVICE_CMF_9", cdvCMF9.Text);
            service.AddString("SERVICE_CMF_10", cdvCMF10.Text);

            if (chkSecurity.CheckState == CheckState.Checked)
                service.AddChar("SEC_CHK_FLAG", 'Y');

            service.AddString("SHARED_LIB_NAME", cdvSLibName.Text);

            TraverTreeNode(ref in_node, trvInMember);
            TraverTreeNode(ref in_node, trvOutMember);

            if (MPCR.CallService("SVM", "SVM_Update_Service_Member_List", in_node, ref out_node, false) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private void AddAttachNode(TreeNode treeNode)
        {
            TreeNode[] collection = treeNode.Nodes.Find("Attach Node...", false);

            if (collection.Length != 0)
                treeNode.Nodes.Remove(collection[0]);

            treeNode.Nodes.Add("Attach Node...", "Attach Node...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
        }

        private int GetIconIndex(ServiceMember member)
        {
            int icon_index = (int)SMALLICON_INDEX.IDX_VERSION_REQUEST;

            if (IsEssentialMember(member))
            {
                icon_index = (int)SMALLICON_INDEX.IDX_KEY;
            }
            else
            {
                switch (member.MEMBER_TYPE)
                {
                    case "String":
                    case "Binary":
                    case "Boolean":
                    case "Char":
                    case "UByte":
                    case "UShort":
                    case "UInt":
                    case "ULong":
                    case "Float":
                    case "Double":
                    case "Byte":
                    case "Short":
                    case "Int":
                    case "Long":
                        break;
                    case "Array":
                        icon_index = (int)SMALLICON_INDEX.IDX_CODE_TABLE;
                        break;
                    case "List":
                        icon_index = (int)SMALLICON_INDEX.IDX_STOCKER;
                        break;
                }
            }

            return icon_index;
        }

        private TreeNode GetParentTreeNode(TreeNode tn_parent, string s_parent_path)
        {
            ServiceMember sm;
            TreeNode tn_ret;

            foreach (TreeNode tn in tn_parent.Nodes)
            {
                if (tn.Tag != null)
                {
                    sm = (ServiceMember)tn.Tag;

                    if (sm.MEMBER_PATH == s_parent_path)
                    {
                        return tn;
                    }
                }

                if (tn.Nodes.Count > 0)
                {
                    tn_ret = GetParentTreeNode(tn, s_parent_path);

                    if (tn_ret != null)
                    {
                        return tn_ret;
                    }
                }
            }

            return null;
        }

        private bool GetServiceMembersToService(TRSNode in_node, ref TRSNode out_node, ref Service service)
        {
            Member serviceMember;
            TRSNode item;

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    txtExport.AppendText(out_node.Msg + "\r\n");
                    txtExport.AppendText(out_node.DBErrMsg + "\r\n");
                    SetExportEnables(true);
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    serviceMember = new Member();
                    item = out_node.GetList(0)[i];

                    txtExport.AppendText("\t\t" + item.GetString("MEMBER_NAME") + "\r\n");

                    serviceMember.Direction = item.GetChar("DIRECTION");
                    serviceMember.MemberPath = item.GetString("MEMBER_PATH");
                    serviceMember.Depth = item.GetInt("MEMBER_DEPTH");
                    serviceMember.Name = item.GetString("MEMBER_NAME");
                    serviceMember.Prompt = item.GetString("MEMBER_PRT");
                    serviceMember.Sequence = item.GetInt("MEMBER_SEQ");

                    serviceMember.Desc1 = item.GetString("MEMBER_DESC_1");
                    serviceMember.Desc2 = item.GetString("MEMBER_DESC_2");
                    serviceMember.Desc3 = item.GetString("MEMBER_DESC_3");

                    serviceMember.Type = item.GetString("MEMBER_TYPE");
                    serviceMember.ArrayType = item.GetString("ARRAY_TYPE");
                    serviceMember.Size = item.GetInt("MEMBER_SIZE");
                    serviceMember.RequireFlag = item.GetChar("REQ_MEMBER_FLAG");
                    serviceMember.ParentPath = item.GetString("PARENT_MEMBER_PATH");
                    serviceMember.OverrideFlag = item.GetChar("OVERRIDE_FLAG");
                    serviceMember.UseRangeFlag = item.GetChar("USE_RANGE_FLAG");
                    serviceMember.RangeMin = item.GetDouble("RANGE_MIN");
                    serviceMember.RangeMax = item.GetDouble("RANGE_MAX");

                    serviceMember.CreateUserId = item.GetString("CREATE_USER_ID");
                    serviceMember.CreateTime = item.GetString("CREATE_TIME");
                    serviceMember.UpdateUserId = item.GetString("UPDATE_USER_ID");
                    serviceMember.UpdateTime = item.GetString("UPDATE_TIME");

                    if (serviceMember.Direction == 'I')
                        service.InMembers.Add(serviceMember);
                    else
                        service.OutMembers.Add(serviceMember);
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            return true;
        }

        private TreeNode AddServiceMemberToTreeNode(TreeNode targetNode, ServiceMember memberItem)
        {
            int icon_index = GetIconIndex(memberItem);

            TreeNode treeNode = targetNode.Nodes.Add(memberItem.MEMBER_NAME,
                                                     " ",
                                                     icon_index,
                                                     icon_index);

            treeNode.Tag = memberItem;

            SetNodeFontStyle(ref treeNode, memberItem.REQ_MEMBER_FLAG, (memberItem.OVERRIDE_FLAG == 'Y'));

            if (memberItem.MEMBER_TYPE == "String")
                treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE + "(" + memberItem.MEMBER_SIZE.ToString() + ")";
            else
            {
                if (memberItem.MEMBER_TYPE == "Array")
                    treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE + " : " + memberItem.ARRAY_TYPE;
                else
                    treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE;
            }

            return treeNode;
        }

        private TreeNode InsertServiceMemberToTreeNode(ref TreeNode targetNode, ServiceMember memberItem, int index)
        {
            TreeNode treeNode;
            int icon_index = GetIconIndex(memberItem);


            treeNode = targetNode.Nodes.Insert(index,
                                               memberItem.MEMBER_NAME,
                                               " ",
                                               icon_index,
                                               icon_index);

            treeNode.Tag = memberItem;

            SetNodeFontStyle(ref treeNode, memberItem.REQ_MEMBER_FLAG, (memberItem.OVERRIDE_FLAG == 'Y'));

            if (memberItem.MEMBER_TYPE == "String")
                treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE + "(" + memberItem.MEMBER_SIZE.ToString() + ")";
            else
            {
                if (memberItem.MEMBER_TYPE == "Array")
                    treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE + " : " + memberItem.ARRAY_TYPE;
                else
                    treeNode.Text = memberItem.MEMBER_NAME + " : " + memberItem.MEMBER_TYPE;
            }

            return treeNode;
        }

        private void SetChildMemberPath(string s_member_name, string s_member_path, TreeNode node)
        {
            int i;
            ServiceMember serviceMember;

            for (i = 0; i < node.Nodes.Count; i++)
            {
                if (node.Nodes[i].Tag != null)
                {
                    serviceMember = (ServiceMember)node.Nodes[i].Tag;

                    serviceMember.PARENT_MEMBER_PATH = s_member_path;
                    serviceMember.MEMBER_PATH = s_member_path + "/" + serviceMember.MEMBER_NAME;

                    if (node.Nodes[i].Nodes.Count > 0)
                    {
                        SetChildMemberPath(serviceMember.MEMBER_NAME, serviceMember.MEMBER_PATH, node.Nodes[i]);
                    }
                }
            }
        }

        private void GetTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                e.Handled = true;

                cdvMemberName_ButtonPress(null, null);

                // 유사한 Item이 하나 있는경우
                if (cdvMemberName.GetListView.Items.Count == 1)
                {
                    // 리스트된 하나의 Item이 일치하는 경우 - 해당 Item을 선택하여 처리한다.
                    if (cdvMemberName.GetListView.Items[0].SubItems[0].Text == cdvMemberName.Text)
                    {
                        cdvMemberName.GetListView.Items[0].Selected = true;
                        cdvMemberName_SelectedItemChanged(null, null);
                        btnCreateMember.Enabled = false;
                        chkOverride.Checked = false;
                        chkOverride_CheckedChanged(null, null);
                        SetReadOnly(true);

                        //정상적으로 로드 되었음을 표시해줌. - Reload 메시지 방지.
                        old_member_name = cdvMemberName.Text;
                        new_override_flag = chkOverride.Checked;
                        old_override_flag = chkOverride.Checked;
                        old_member_type = cbxMemberType.Text;
                    }
                    // 일치되는 Item이 없는경우 - 리스를 보여준다.
                    else
                    {
                        // Shift 키와 조합하여 입력한 경우 하나의 항목이 일치하지 않으면 Create mode로 적용된다.
                        if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.Return) && e.Modifiers == Keys.Shift)
                        {
                            MPCR.ChangeControlEnabled(this, btnCreateMember, true);
                            SetReadOnly(false);
                        }
                        // 일반적으로 입력한 경우 하나의 항목이 일치하지 않으면 리스를 보여준다.
                        else
                        {
                            btnCreateMember.Enabled = false;
                            SetReadOnly(false);

                            cdvMemberName.ShowPopUp();
                        }
                    }
                }
                // 유사한 Item이 다수인 경우 - 리스트를 보여준다.
                else if (cdvMemberName.GetListView.Items.Count != 0)
                {
                    btnCreateMember.Enabled = false;
                    SetReadOnly(true);

                    cdvMemberName.ShowPopUp();
                }
                // 유사한 Item이 없는경우 - Create 모드
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreateMember, true);
                    SetReadOnly(false);
                }
            }
        }

        #endregion

        public frmSVMSetupServiceMember()
        {
            InitializeComponent();
            cdvMemberName.GetTextBox.KeyUp += new KeyEventHandler(GetTextBox_KeyUp);
        }


        private void frmSVMSetupServiceMember_Activated(object sender, EventArgs e)
        {
            if (b_load_flag != true)
            {
                ToolTip tTReqApply = new ToolTip();

                tTReqApply.AutoPopDelay = 5000;
                tTReqApply.InitialDelay = 1000;
                tTReqApply.ReshowDelay = 500;
                tTReqApply.ShowAlways = true;

                tTReqApply.SetToolTip(this.btnReqApply, "Apply Required to Selected Node");

                View_Service_list();

                MPCF.InitTreeView(trvInMember);
                MPCF.InitTreeView(trvOutMember);

                MPCR.SetCMFItem(MPGC.MP_CMF_SERVICE, "lblCmf", "cdvCmf", grpCMF);

                ClearData();

                b_load_flag = true;
            }
        }
                
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Update_Service(MPGC.MP_STEP_CREATE) == true)
            {
                string service_name = txtServiceName.Text;

                ClearData();
                View_Service_list();
                MPCF.FindListItem(lisService, service_name, 1, true);

                Create_Init_Members();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tbpService || tabMain.SelectedTab == tbpCMF)
            {
                if (Update_Service(MPGC.MP_STEP_UPDATE) == true)
                {                    
                    string service_name = txtServiceName.Text;

                    ClearData();
                    View_Service_list();
                    MPCF.FindListItem(lisService, service_name, 1, true);                    
                }
            }
            else if (tabMain.SelectedTab == tbpMember)
            {
                Update_Service_member_list();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (Update_Service(MPGC.MP_STEP_DELETE) == true)
            {
                ServiceMember serviceMember = new ServiceMember();
                serviceMember.MODULE_NAME = cdvModuleName.Text;
                serviceMember.SERVICE_NAME = txtServiceName.Text;

                ClearData();
                View_Service_list();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_Service_list();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode treeNode = null;
            TreeNode parentNode = null;
            TreeNode[] findNodes = null;

            bool isInMemberTable = false;

            int depth;
            char direction = ' ';

            if (CheckCondition("Member", ' ') != true)
                return;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
                direction = 'I';
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
                direction = 'O';
            }

            // 선택된 노드가 없는경우 작업을 진행하지 않음
            if (treeView.SelectedNode == null)
                return;

            // 새로운 멤버인 상태이면서 Member Table에 추가된지도 않았으며 
            // Override 상태도 아닌 Member는 추가를 허용하지 않음
            if (btnCreateMember.Enabled == true && chkOverride.Checked == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(287));
                return;
            }

            isInMemberTable = IsInMemberTable(cdvMemberName.Text);

            // Override가 아니면서 Member Table에 존재하지 않는 이름으로 추가하려고 하는 경우 허용하지 않음
            if (chkOverride.Checked == false && !isInMemberTable)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(288));
                return;
            }

            // Override 상태가 아니면서
            // Member Table에 존재하나 현재 이름만 변경하여 적용한 상태인경우
            // 값들을 Reload 하여 적용하고 추가할지, 취소할지를 선택
            if (old_member_name != cdvMemberName.Text && isInMemberTable && !chkOverride.Checked)
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(289), MessageBoxButtons.OKCancel, 2) == System.Windows.Forms.DialogResult.OK)
                {
                    View_Service_member();
                }
                else
                {
                    return;   
                }
            }

            ServiceMember serviceMember = new ServiceMember();
            ServiceMember parentMember = (ServiceMember)treeView.SelectedNode.Parent.Tag;

            if (parentMember == null)
                depth = 0;
            else
                depth = parentMember.MEMBER_DEPTH + 1;
            
            SetServiceMember(ref serviceMember, depth, direction);

            if (parentMember == null)
            {
                serviceMember.MEMBER_PATH = serviceMember.MEMBER_NAME;
            }
            else
            {
                serviceMember.MEMBER_PATH = parentMember.MEMBER_PATH + "/" + serviceMember.MEMBER_NAME;
                serviceMember.PARENT_MEMBER_PATH = parentMember.MEMBER_PATH;
            }

            // Root Node가 아닌경우 Sibling을 추가할 수 있음
            if (treeView.SelectedNode.Parent != null)
            {
                // 기존에 같은 이름의 노드가 존재하는지 확인
                findNodes = treeView.SelectedNode.Parent.Nodes.Find(cdvMemberName.Text, false);

                // 기존에 같은 이름의 노드가 존재하지 않는 경우
                if (findNodes.Length < 1)
                {
                    int selectedNodeIndex = treeView.SelectedNode.Index;

                    if (IsEssentialMember(treeView.SelectedNode, tabMember.SelectedIndex == 0))
                        selectedNodeIndex = 6;

                    parentNode = treeView.SelectedNode.Parent;
                    treeNode = InsertServiceMemberToTreeNode(ref parentNode, serviceMember, selectedNodeIndex);

                    //treeView.SelectedNode = treeNode;

                    MPCR.ChangeControlEnabled(this, btnAddMemberChild, true);
                    MPCR.ChangeControlEnabled(this, btnModifyMember, true);
                    MPCR.ChangeControlEnabled(this, btnDeleteMember, true);

                    treeView.SelectedNode.EnsureVisible();

                    CheckAndSetEnables(treeView.SelectedNode);                    
                }
                else
                {
                    treeView.SelectedNode = findNodes[0];
                    findNodes[0].EnsureVisible();
                }
            }
        }

        private void btnAddMemberChild_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode treeNode = null;
            ServiceMember serviceMember;
            ServiceMember selectedMember;
            int depth;
            char direction = ' ';

            bool isInMemberTable = false;

            if (CheckCondition("Member", ' ') != true)
                return;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
                direction = 'I';
            }
            else
            {
                treeView = trvOutMember;
                direction = 'O';
            }

            // 선택된 노드가 없는경우 작업을 진행하지 않음
            if (treeView.SelectedNode == null)
                return;

            // 선택된 노드가 Root나 Attach Node 인경우 작업을 진행하지 않음.
            if (treeView.SelectedNode.Tag == null)
                return;


            // 새로운 멤버인 상태이면서 Member Table에 추가되지도 않았으며 
            // Override 상태도 아닌 Member는 추가를 허용하지 않음
            if (btnCreateMember.Enabled == true && chkOverride.Checked == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(287));
                return;
            }

            isInMemberTable = IsInMemberTable(cdvMemberName.Text);

            // Override가 아니면서 Member Table에 존재하지 않는 이름으로 추가하려고 하는 경우 허용하지 않음
            if (chkOverride.Checked == false && !isInMemberTable)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(288));
                return;
            }

            // Override 상태가 아니면서
            // Member Table에 존재하나 현재 이름만 변경하여 적용한 상태인경우
            // 값들을 Reload 하여 적용하고 추가할지, 취소할지를 선택
            if (old_member_name != cdvMemberName.Text && isInMemberTable && !chkOverride.Checked)
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(289), MessageBoxButtons.OKCancel, 2) == System.Windows.Forms.DialogResult.OK)
                {
                    View_Service_member();
                }
                else
                {
                    return;
                }
            }

            serviceMember = new ServiceMember();
            selectedMember = (ServiceMember)treeView.SelectedNode.Tag;

            
            if (selectedMember == null)
                depth = 0;
            else
                depth = selectedMember.MEMBER_DEPTH + 1;

            SetServiceMember(ref serviceMember, depth, direction);

            if (selectedMember == null)
            {
                serviceMember.MEMBER_PATH = serviceMember.MEMBER_NAME;
            }
            else
            {
                serviceMember.MEMBER_PATH = selectedMember.MEMBER_PATH + "/" + serviceMember.MEMBER_NAME;
                serviceMember.PARENT_MEMBER_PATH = selectedMember.MEMBER_PATH;
            }

            if (treeView.SelectedNode.Nodes.Find(cdvMemberName.Text, false).Length == 0)
            {
                treeNode = AddServiceMemberToTreeNode(treeView.SelectedNode, serviceMember);
                treeView.SelectedNode = treeNode;
                treeView.SelectedNode.EnsureVisible();
            }

            CheckAndSetEnables(treeView.SelectedNode);
            
            AddAttachNode(treeView.SelectedNode.Parent);

        }        

        private void btnModifyMember_Click(object sender, EventArgs e)
        {
            int iconIndex;
            TreeView treeView = null;
            TreeNode selectedNode = null;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
            }            

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;

            if (selectedNode.Tag == null)
                return;

            // Override 상태가 아닌경우
            // Member 이름 변경하는것은 문제가 될 수 있으므로 허용하지 않음.
            // 혹은 Override 상태가 아닌경우 해당 Member가 Member Table에 있는경우가 아니면 허용하지 않음
            if (old_member_name != cdvMemberName.Text &&
                (chkOverride.Checked == false && !IsInMemberTable(cdvMemberName.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(290));
                cdvMemberName.Text = old_member_name;
                return;
            }

            // 다른 Type 이었던 Member를 Array 타입으로 변경하고자 하는경우
            //  Child가 있는것은 허용하지 않음
            if (old_member_type != cbxMemberType.Text)
            {
                if (cbxMemberType.Text == "Array")
                {
                    if (selectedNode.Nodes.Count != 0)
                    {
                        return;
                    }
                }
            }
            
            if (CheckCondition("Member", ' ') != true)
                return;            

            if (old_override_flag == new_override_flag)
            {
                if (chkOverride.Checked == false)
                {
                    if (IsEssentialMember(selectedNode, tabMember.SelectedIndex == 0))
                        return;
                }
            }

            ServiceMember selectedMember = (ServiceMember)selectedNode.Tag;


            // 변경하려는 동일한 이름이 Sibling으로 있는경우 허용하지 않는다.
            if (selectedNode.Parent != null)
            {
                if (selectedNode.Parent.Nodes.ContainsKey(cdvMemberName.Text))
                {
                    if (selectedNode.Parent.Nodes.IndexOfKey(cdvMemberName.Text) != selectedNode.Index)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(291));
                        return;
                    }
                }
            }

            // Child Node들의 경우 Parent 이름이 변경된경우 이를 적용해 준다.
            if (cdvMemberName.Text != selectedMember.MEMBER_NAME)
            {
                ServiceMember parentMember = (ServiceMember)selectedNode.Parent.Tag;

                if (parentMember == null)
                {
                    selectedMember.MEMBER_PATH = cdvMemberName.Text;
                }
                else
                {
                    selectedMember.MEMBER_PATH = parentMember.MEMBER_PATH + "/" + cdvMemberName.Text;
                }

                SetChildMemberPath(cdvMemberName.Text, selectedMember.MEMBER_PATH, selectedNode);
            }

            SetServiceMember(ref selectedMember, selectedMember.MEMBER_DEPTH, selectedMember.DIRECTION);

            // Modified By InChul Bae - Conditional Mandatory 추가
            if (rbnMandatory.Checked)
                SetNodeFontStyle(ref selectedNode, 'M', chkOverride.Checked);
            else if (rbnCondMandatory.Checked)
                SetNodeFontStyle(ref selectedNode, 'C', chkOverride.Checked);
            else
                SetNodeFontStyle(ref selectedNode, 'O', chkOverride.Checked);

            iconIndex = GetIconIndex(selectedMember);

            selectedNode.ImageIndex = iconIndex;
            selectedNode.SelectedImageIndex = iconIndex;

            selectedNode.Tag = selectedMember;

            if (selectedMember.MEMBER_TYPE == "String")
                selectedNode.Text = cdvMemberName.Text + " : " + cbxMemberType.Text + "(" + txtMemberSize.Text + ") ";
            else
            {
                if (selectedMember.MEMBER_TYPE == "Array")
                    selectedNode.Text = cdvMemberName.Text + " : " + cbxMemberType.Text + " : " + cbxArrayType.Text;
                else
                    selectedNode.Text = cdvMemberName.Text + " : " + cbxMemberType.Text;
            }


            old_override_flag = chkOverride.Checked;
            new_override_flag = chkOverride.Checked;
            old_member_type = cbxMemberType.Text;
            old_member_name = cdvMemberName.Text;

            selectedNode.Name = cdvMemberName.Text;
        }

        private void btnCreateMember_Click(object sender, EventArgs e)
        {
            if (CheckCondition("Member", ' '))
            {
                TRSNode in_node = new TRSNode("Update_Member_In");
                TRSNode out_node = new TRSNode("Update_Member_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;

                in_node.AddString("MEMBER_NAME", cdvMemberName.Text);
                in_node.AddString("MEMBER_DESC_1", txtMemberDesc_1.Text);
                in_node.AddString("MEMBER_DESC_2", txtMemberDesc_2.Text);
                in_node.AddString("MEMBER_DESC_3", txtMemberDesc_3.Text);
                in_node.AddInt("MEMBER_SIZE", MPCF.ToInt(txtMemberSize.Text));
                in_node.AddString("MEMBER_TYPE", cbxMemberType.Text);
                in_node.AddString("ARRAY_TYPE", cbxArrayType.Text);

                if (chkUseRange.Checked)
                {
                    in_node.AddChar("USE_RANGE_FLAG", 'Y');
                    in_node.AddDouble("RANGE_MIN", double.Parse(nudRangeMin.Value.ToString()));
                    in_node.AddDouble("RANGE_MAX", double.Parse(nudRangeMax.Value.ToString()));
                }
                else
                {
                    in_node.AddChar("USE_RANGE", ' ');
                }
                

                if (MPCR.CallService("SVM", "SVM_Update_Member", in_node, ref out_node) == false)
                {
                    return;
                }

                MPCR.ShowSuccessMsg(out_node);

                btnCreateMember.Enabled = false;
                chkOverride.Checked = false;

                SetReadOnly(true);

                View_Service_member();

                //정상적으로 로드 되었음을 표시해줌. - Reload 메시지 방지.
                old_member_name = cdvMemberName.Text;
                new_override_flag = chkOverride.Checked;
                old_override_flag = chkOverride.Checked;
                old_member_type = cbxMemberType.Text;
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode selectedNode = null;
            ServiceMember selectedMember;

            if (tabMember.SelectedIndex == 0)
                treeView = trvInMember;
            else if (tabMember.SelectedIndex == 1)
                treeView = trvOutMember;

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;

            if (IsEssentialMember(selectedNode, tabMember.SelectedIndex == 0))
                return;

            if (selectedNode.Tag == null)
                return;

            selectedMember = (ServiceMember)selectedNode.Tag;

            selectedNode.Parent.Nodes.Remove(selectedNode);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExchageModule exportModule = new ExchageModule();
            Service service;
            TRSNode in_node;
            TRSNode out_node;
            
            b_export_stop = false;

            if (cdvExportModule.Text == "")
                return;

            if (txtExportFile.Text == "")
                return;

            // Export중에Disable
            SetExportEnables(false);

            txtExport.Text = "";
            txtExport.AppendText("Start Export\r\n");

            // Init progressBar
            progressBarExport.Value = 0;
            txtExport.Focus();


            exportModule.Name = cdvExportModule.Text;

            in_node = new TRSNode("View_Service_List_In");
            out_node = new TRSNode("View_Service_List_Out");
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvExportModule.Text);

            do
            {
                if (b_export_stop)
                {                    
                    SetExportEnables(true);
                    txtExport.Focus();
                    txtExport.AppendText("<User Stop>..." + "\r\n");
                    return;
                }

                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    txtExport.AppendText(out_node.Msg + "\r\n");
                    txtExport.AppendText(out_node.DBErrMsg + "\r\n");
                    SetExportEnables(true);
                    return;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    service = new Service();
                    service.Name = out_node.GetList(0)[i].GetString("SERVICE_NAME");

                    service.Desc1 = out_node.GetList(0)[i].GetString("SERVICE_DESC_1");
                    service.Desc2 = out_node.GetList(0)[i].GetString("SERVICE_DESC_2");
                    service.Desc3 = out_node.GetList(0)[i].GetString("SERVICE_DESC_3");

                    service.Category = out_node.GetList(0)[i].GetChar("SERVICE_CATEGORY");
                    service.Mode = out_node.GetList(0)[i].GetString("SERVICE_MODE");

                    service.CreateUserId = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                    service.CreateTime = out_node.GetList(0)[i].GetString("CREATE_TIME");
                    service.UpdateUserId = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                    service.UpdateTime = out_node.GetList(0)[i].GetString("UPDATE_TIME");

                    service.SecurityCheckRequired = out_node.GetList(0)[i].GetChar("SEC_CHK_FLAG");
                    service.SharedLibName = out_node.GetList(0)[i].GetString("SHARED_LIB_NAME");

                    exportModule.Services.Add(service);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");


            // set progressBar Max
            progressBarExport.Maximum = exportModule.Services.Count + 1;

            in_node = new TRSNode("View_Service_Member_List_In");
            out_node = new TRSNode("View_Service_Member_List_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("MODULE_NAME", exportModule.Name);
           

            for (int j = 0; j < exportModule.Services.Count; j++)
            {
                txtProgress.Text = (j + 1).ToString() + "/" + exportModule.Services.Count.ToString();

                if (b_export_stop)
                {
                    SetExportEnables(true);
                    txtExport.Focus();
                    txtExport.AppendText("<User Stop>..." + "\r\n");
                    return;
                }
                               

                service = exportModule.Services[j];
                                
                in_node.SetString("SERVICE_NAME", service.Name);
                txtExport.AppendText("\r\n\t" + service.Name + "\r\n");
                
                in_node.SetChar("DIRECTION", 'I');                
                txtExport.AppendText("\t\tReads In Members from database\r\n");
                if (GetServiceMembersToService(in_node, ref out_node, ref service) == false)
                    return;

                in_node.SetChar("DIRECTION", 'O');
                txtExport.AppendText("\t\tReads Out Members from database\r\n");
                if (GetServiceMembersToService(in_node, ref out_node, ref service) == false)
                    return;

                progressBarExport.Increment(1);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ExchageModule));
            TextWriter writer = new StreamWriter(txtExportFile.Text);
            
            serializer.Serialize(writer, exportModule);
            writer.Close();

            progressBarExport.Increment(1);

            txtExport.AppendText("Export Complete...\r\n");

            SetExportEnables(true);

            progressBarExport.Value = 0;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtImportFile.Text == "")
                return;

            // Import 중 Disable
            grbImport.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtImport.Focus();

            txtImport.Text = "";

            progressBarImport.Value = 0;

            int count = 0;
            TRSNode in_node;
            TRSNode out_node;
            ExchageModule module;
            Service service;
            XmlSerializer serializer = new XmlSerializer(typeof(ExchageModule));
            TextReader reader = new StreamReader(openFileDialog.FileName);

            TRSNode service_info;

            module = (ExchageModule)serializer.Deserialize(reader);
            reader.Close();

            for (int i = 0; i < module.Services.Count; i++)
            {
                count++;
                count += module.Services[i].InMembers.Count;
                count += module.Services[i].OutMembers.Count;
            }

            progressBarImport.Maximum = count;

            txtImport.AppendText("Start Import...\r\n");

            for (int i = 0; i < module.Services.Count; i++)
            {
                service = module.Services[i];

                txtImport.AppendText(service.Name + "\r\n");

                in_node = new TRSNode("UPDATE_SERVICE_MEMBER_LIST_IN");
                out_node = new TRSNode("UPDATE_SERVICE_MEMBER_LIST_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;

                in_node.AddString("MODULE_NAME", module.Name);
                in_node.AddString("SERVICE_NAME", service.Name);

                service_info = in_node.AddNode("SERVICE_INFO");

                service_info.AddString("SERVICE_MODE", service.Mode);
                service_info.AddChar("SERVICE_CATEGORY", service.Category);

                service_info.AddString("SERVICE_DESC_1", service.Desc1);
                service_info.AddString("SERVICE_DESC_2", service.Desc2);
                service_info.AddString("SERVICE_DESC_3", service.Desc3);
                service_info.AddChar("SEC_CHK_FLAG", service.SecurityCheckRequired);

                service_info.AddString("SHARED_LIB_NAME", service.SharedLibName);

                txtImport.AppendText("\tImport Prepare : In Members\r\n");
                for (int j = 0; j < service.InMembers.Count; j++)
                {
                    txtImport.AppendText("\t\t" + service.InMembers[j].Name + "\r\n");
                    AddMemberToTRSNode(ref in_node, module.Name, service.Name, service.InMembers[j]);
                    progressBarImport.Increment(1);
                }

                txtImport.AppendText("\tImport Prepare : Out Members\r\n");
                for (int j = 0; j < service.OutMembers.Count; j++)
                {
                    txtImport.AppendText("\t\t" + service.OutMembers[j].Name + "\r\n");
                    AddMemberToTRSNode(ref in_node, module.Name, service.Name, service.OutMembers[j]);
                    progressBarImport.Increment(1);
                }

                txtImport.AppendText("\tImport ServiceMembers\r\n");
                if (MPCR.CallService("SVM", "SVM_Update_Service_Member_List", in_node, ref out_node) == false)
                {
                    txtImport.AppendText(out_node.Msg + "\r\n");
                    txtImport.AppendText(out_node.DBErrMsg + "\r\n");
                    grbImport.Enabled = true;

                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                    return;
                }

                progressBarImport.Increment(1);
            }

            txtImport.AppendText("Import Complete...\r\n");

            grbImport.Enabled = true;

            MPCR.ChangeControlEnabled(this, btnCreate, true);
            MPCR.ChangeControlEnabled(this, btnUpdate, true);
            MPCR.ChangeControlEnabled(this, btnDelete, true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisService, this.Text, "");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisService, txtFind.Text, true, false);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode selectedNode = null;
            TreeNode tempNode = null;
            int selectedNodeIndex;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
            }

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;
            
            // 필수 항목인 경우 처리 하지 않음
            if(IsEssentialMember(selectedNode, tabMember.SelectedIndex == 0))
                return;           

            if (selectedNode.Parent == null)
                return;
            
            if (selectedNode.Index == 0)
                return;

            // 필수 항목이 아닌 항목이 필수항목 사이로 이동하는것 방지.
            if (IsEssentialMember(selectedNode.PrevNode, tabMember.SelectedIndex == 0))
                return;

            tempNode = (TreeNode)treeView.SelectedNode.Clone();
            selectedNodeIndex = selectedNode.Index;

            selectedNode.Parent.Nodes.Insert(selectedNodeIndex - 1, tempNode);
            selectedNode.Parent.Nodes.Remove(selectedNode);
            treeView.SelectedNode = tempNode;

            if (tempNode.Nodes.Count != 0)
                tempNode.ExpandAll();
            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode selectedNode = null;
            TreeNode tempNode = null;
            int selectedNodeIndex;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
            }

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;

            if (selectedNode.NextNode != null && selectedNode.NextNode.Name == "Attach Node...")
                return;

            // 필수 항목인 경우 처리 하지 않음
            if (IsEssentialMember(selectedNode, tabMember.SelectedIndex == 0))
                return;

            if (selectedNode.Parent == null)
                return;

            if (selectedNode.Index == selectedNode.Parent.Nodes.Count - 1)
                return;

            tempNode = (TreeNode)treeView.SelectedNode.Clone();
            selectedNodeIndex = selectedNode.Index;

            selectedNode.Parent.Nodes.Insert(selectedNodeIndex + 2, tempNode);
            selectedNode.Parent.Nodes.Remove(selectedNode);
            treeView.SelectedNode = tempNode;

            if (tempNode.Nodes.Count != 0)
                tempNode.ExpandAll();
            
        }

        private void btnInto_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode selectedNode = null;
            TreeNode tempNode = null;
            TreeNode parentNode = null;
            int i_node_count;
            ServiceMember sm_member;
            ServiceMember sm_parent;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
            }

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;

            if (selectedNode.Index < 1)
                return;

            if (selectedNode.Name == "Attach Node...")
                return;

            // 필수 항목인 경우 처리 하지 않음
            if (IsEssentialMember(selectedNode, tabMember.SelectedIndex == 0))
                return;

            if (selectedNode.Parent == null)
                return;

            // 필수 항목이 아닌 항목이 필수항목 사이로 이동하는것 방지.
            if (IsEssentialMember(selectedNode.PrevNode, tabMember.SelectedIndex == 0))
                return;

            parentNode = selectedNode.Parent.Nodes[selectedNode.Index - 1];

            if (parentNode.Nodes.Find(selectedNode.Name, false).Length > 0)
                return;

            tempNode = (TreeNode)treeView.SelectedNode.Clone();

            sm_member = (ServiceMember)tempNode.Tag;
            sm_parent = (ServiceMember)parentNode.Tag;

            sm_member.MEMBER_DEPTH++;
            sm_member.MEMBER_PATH = sm_parent.MEMBER_PATH + "/" + sm_member.MEMBER_NAME;
            sm_member.PARENT_MEMBER_PATH = sm_parent.MEMBER_PATH;

            i_node_count = parentNode.Nodes.Count;
            parentNode.Nodes.Insert(i_node_count - 1, tempNode);
            selectedNode.Parent.Nodes.Remove(selectedNode);
            treeView.SelectedNode = tempNode;

            if (tempNode.Nodes.Count != 0)
                tempNode.ExpandAll();

            AddAttachNode(parentNode);

        }

        private void btnGoout_Click(object sender, EventArgs e)
        {
            TreeView treeView = null;
            TreeNode selectedNode = null;
            TreeNode tempNode = null;
            TreeNode parentNode = null;
            int i_node_index;
            ServiceMember sm_member;
            ServiceMember sm_parent;

            if (tabMember.SelectedIndex == 0)
            {
                treeView = trvInMember;
            }
            else if (tabMember.SelectedIndex == 1)
            {
                treeView = trvOutMember;
            }

            if (treeView.SelectedNode == null)
                return;

            selectedNode = treeView.SelectedNode;

            if (selectedNode.Name == "Attach Node...")
                return;

            if (selectedNode.Parent == null)
                return;

            parentNode = selectedNode.Parent.Parent;

            if (parentNode == null)
                return;

            if (parentNode.Nodes.Find(selectedNode.Name, false).Length > 0)
                return;

            tempNode = (TreeNode)treeView.SelectedNode.Clone();

            sm_member = (ServiceMember)tempNode.Tag;
            sm_parent = (ServiceMember)parentNode.Tag;

            sm_member.MEMBER_DEPTH--;
            if (sm_parent == null)
            {
                sm_member.MEMBER_PATH = sm_member.MEMBER_NAME;
                sm_member.PARENT_MEMBER_PATH = "";
            }
            else
            {
                sm_member.MEMBER_PATH = sm_parent.MEMBER_PATH + "/" + sm_member.MEMBER_NAME;
                sm_member.PARENT_MEMBER_PATH = sm_parent.MEMBER_PATH;
            }

            i_node_index = selectedNode.Parent.Index;
            parentNode.Nodes.Insert(i_node_index + 1, tempNode);
            selectedNode.Parent.Nodes.Remove(selectedNode);
            treeView.SelectedNode = tempNode;

            if (tempNode.Nodes.Count != 0)
                tempNode.ExpandAll();

        }

        private void btnExportStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void cdvModuleName_ButtonPress(object sender, EventArgs e)
        {
            cdvModuleName.Init();
            MPCF.InitListView(cdvModuleName.GetListView);
            cdvModuleName.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModuleName.SelectedSubItemIndex = 0;

            View_Module_List(cdvModuleName.GetListView, '4');
        }

        private void cdvSelectModule_ButtonPress(object sender, EventArgs e)
        {
            cdvSelectModule.Init();
            MPCF.InitListView(cdvSelectModule.GetListView);
            cdvSelectModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvSelectModule.SelectedSubItemIndex = 0;

            View_Module_List(cdvSelectModule.GetListView, '4');
        }

        private void cdvSelectModule_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            View_Service_list();
        }        

        private void cdvMemberName_ButtonPress(object sender, EventArgs e)
        {
            cdvMemberName.Init();
            MPCF.InitListView(cdvMemberName.GetListView);
            cdvMemberName.Columns.Add("Member Name", 50, HorizontalAlignment.Left);
            cdvMemberName.SelectedSubItemIndex = 0;

            View_Member_List(cdvMemberName.GetListView);
        }

        private void cdvMemberName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            View_Service_member();
            SetReadOnly(true);

            //정상적으로 로드 되었음을 표시해줌. - Reload 메시지 방지.
            old_member_name = cdvMemberName.Text;
            new_override_flag = chkOverride.Checked;
            old_override_flag = chkOverride.Checked;
            old_member_type = cbxMemberType.Text;   
        }        

        private void cbxMemberType_TextChanged(object sender, EventArgs e)
        {
            if (cbxMemberType.Items.Contains(cbxMemberType.Text) == false)
            {
                cbxMemberType.SelectedIndex = -1;
                cbxMemberType.Text = "";
            }
            else
            {
                // Default Setting 적용
                lblRange.Visible = false;
                chkUseRange.Visible = false;
                chkUseRange.Checked = false;
                nudRangeMin.Visible = false;
                nudRangeMin.Enabled = false;
                lblBetween.Visible = false;
                nudRangeMax.Visible = false;
                nudRangeMax.Enabled = false;

                lblArrayType.Visible = false;
                cbxArrayType.Visible = false;
                cbxArrayType.SelectedIndex = -1;

                lblMemberSize.Visible = false;
                txtMemberSize.Visible = false;

                // 세부 항목별 Setting 적용
                switch (cbxMemberType.Text)
                {
                    case "String":
                        lblMemberSize.Visible = true;
                        txtMemberSize.Visible = true;
                        break;
                    case "Array":
                        lblArrayType.Visible = true;
                        cbxArrayType.Visible = true;
                        break;
                    case "List":
                    case "Datetime":
                    case "Blob":
                    case "Boolean":
                        break;
                    case "Char":
                        txtMemberSize.Text = "";
                        break;
                    default:
                        txtMemberSize.Text = "";
                        lblRange.Visible = true;
                        chkUseRange.Visible = true;
                        nudRangeMin.Visible = true;
                        lblBetween.Visible = true;
                        nudRangeMax.Visible = true;
                        break;
                }

                SetRanges(cbxMemberType.Text);
            }
        }

        private void cbxMemberType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cdvExportModule_ButtonPress(object sender, EventArgs e)
        {
            cdvExportModule.Init();
            MPCF.InitListView(cdvExportModule.GetListView);
            cdvExportModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvExportModule.SelectedSubItemIndex = 0;

            View_Module_List(cdvExportModule.GetListView, '4');
            
            txtExportFile.Text = "";            
            txtProgress.Text = "";
            txtExport.Text = "";
        }

        private void cdvExportModule2_ButtonPress(object sender, EventArgs e)
        {
            cdvInsertExportModule.Init();
            MPCF.InitListView(cdvInsertExportModule.GetListView);
            cdvInsertExportModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvInsertExportModule.SelectedSubItemIndex = 0;

            View_Module_List(cdvInsertExportModule.GetListView, '4');
            
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XML | *.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImportFile.Text = openFileDialog.FileName;
            }
        }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExportFile.Text = saveFileDialog.FileName;

                txtProgress.Text = "";
                txtExport.Text = "";
            }
        }
       
        private void btnExportFile2_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "SQL | *.sql";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInsertExportFile.Text = saveFileDialog.FileName;

                txtProgress.Text = "";
                txtExport.Text = "";
            }
        }  

        private void cbxServiceMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxServiceCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkUseRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseRange.Checked)
            {
                nudRangeMin.Enabled = true;
                nudRangeMax.Enabled = true;
            }
            else
            {
                nudRangeMin.Enabled = false;
                nudRangeMax.Enabled = false;
            }
        }

        private void chkOverride_CheckedChanged(object sender, EventArgs e)
        {

            TreeNode node;

            if (tabMember.SelectedIndex == 0)
                node = trvInMember.SelectedNode;
            else
                node = trvOutMember.SelectedNode;

            if (node != null && btnCreateMember.Enabled == false)
                CheckAndSetEnables(node);


            if (chkOverride.Checked)
            {
                MPCR.ChangeControlEnabled(this, btnModifyMember, true);
                SetReadOnly(false);
            }
            else
            {
                if (cdvMemberName.Text.Trim() != "")
                {
                    if (IsInMemberTable(cdvMemberName.Text))
                    {
                        SetReadOnly(true);
                    }
                    else
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(292));
                        chkOverride.Checked = true;
                    }
                }
            }

            new_override_flag = chkOverride.Checked;
        }

        private bool IsInMemberTable(string member_name)
        {
            TRSNode in_node = new TRSNode("View_Member_In");
            TRSNode out_node = new TRSNode("View_Member_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MEMBER_NAME", member_name);

            if (MPCR.CallService("SVM", "SVM_View_Member", in_node, ref out_node, DeliveryMode.RReply, true))
            {
                if (out_node.GetString("MEMBER_NAME") != "")
                    return true;
            }

            return false;
        }

        private void txtMemberSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisService, txtFind.Text, 1, true, false);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ServiceMember serviceMember;
            
            if (CheckAndSetEnables(e.Node) == false)
                return;

            serviceMember = (ServiceMember)e.Node.Tag;

            cdvMemberName.Text = serviceMember.MEMBER_NAME;
            txtMemberPrompt.Text = serviceMember.MEMBER_PRT;
            txtMemberDesc_1.Text = serviceMember.MEMBER_DESC_1;
            txtMemberDesc_2.Text = serviceMember.MEMBER_DESC_2;
            txtMemberDesc_3.Text = serviceMember.MEMBER_DESC_3;
            cbxMemberType.Text = serviceMember.MEMBER_TYPE;
            cbxArrayType.Text = serviceMember.ARRAY_TYPE;
            txtMemberSize.Text = serviceMember.MEMBER_SIZE.ToString();

            txtMemberCreateUser.Text = serviceMember.CREATE_USER_ID;
            txtMemberCreateTime.Text = MPCF.MakeDateFormat(serviceMember.CREATE_TIME);
            txtMemberUpdateUser.Text = serviceMember.UPDATE_USER_ID;
            txtMemberUpdateTime.Text = MPCF.MakeDateFormat(serviceMember.UPDATE_TIME);

            if (serviceMember.OVERRIDE_FLAG == 'Y')
            {
                chkOverride.Checked = true;
                SetReadOnly(false);
            }
            else
            {
                chkOverride.Checked = false;
                SetReadOnly(true);
            }

            if (serviceMember.USE_RANGE_FLAG == 'Y')
            {
                chkUseRange.Checked = true;
                nudRangeMin.Text = serviceMember.RANGE_MIN.ToString();
                nudRangeMax.Text = serviceMember.RANGE_MAX.ToString();
            }
            else
            {
                chkUseRange.Checked = false;
                nudRangeMin.Text = "";
                nudRangeMax.Text = "";
            }

            // Modified By InChul Bae - Conditional Mandatory 추가
            if (serviceMember.REQ_MEMBER_FLAG == 'M')
                rbnMandatory.Checked = true;
            else if (serviceMember.REQ_MEMBER_FLAG == 'C')
                rbnCondMandatory.Checked = true;
            else
                rbnOptional.Checked = true;

            //정상적으로 로드 되었음을 표시해줌. - Reload 메시지 방지.
            old_member_name = cdvMemberName.Text;
            old_override_flag = chkOverride.Checked;
            new_override_flag = chkOverride.Checked;
            old_member_type = cbxMemberType.Text;
        }       
        
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tbpMember)
            {
                btnCreate.Enabled = false;
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                btnDelete.Enabled = false;
            }
            else if (tabMain.SelectedTab == tbpCopy)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
        }

        private void lisService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisService.SelectedItems.Count != 0)
            {
                cdvToModule.Text = lisService.SelectedItems[0].SubItems[0].Text;
                txtToService.Text = lisService.SelectedItems[0].SubItems[1].Text;
                cdvInsertExportModule.Text = lisService.SelectedItems[0].SubItems[0].Text;
                txtInsertServiceName.Text = lisService.SelectedItems[0].SubItems[1].Text;

                ClearData();
                TRSNode service_node = new TRSNode("View_Service_Out"); ;

                if (View_Service(ref service_node) == true)
                {
                    if (service_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                    {
                        View_Service_member_list();
                    }
                    else
                    {
                        MPCR.CheckContinueProc(service_node);
                    }
                }
            }
        }

        private void btnModifyMember_EnabledChanged(object sender, EventArgs e)
        {
            MPCR.ChangeControlEnabled(this, btnReqApply, btnModifyMember.Enabled);
        }

        private void btnReqApply_Click(object sender, EventArgs e)
        {
            int i;
            Miracom.UI.Controls.MCTreeView.MCTreeView tvMember;
            ServiceMember serviceMember;
            TreeNode node;

            if(tabMember.SelectedTab == tbpInput)
            {
                tvMember = trvInMember;
            }
            else
            {
                tvMember = trvOutMember;
            }

            for (i = 0; i < tvMember.SelectedNodes.Count; i++)
            {
                node = (TreeNode)tvMember.SelectedNodes[i];
                serviceMember = (ServiceMember)node.Tag;

                // Modified By InChul Bae - Conditional Mandatory 추가
                if (rbnMandatory.Checked == true)
                    serviceMember.REQ_MEMBER_FLAG = 'M';
                else if (rbnCondMandatory.Checked == true)
                    serviceMember.REQ_MEMBER_FLAG = 'C';
                else
                    serviceMember.REQ_MEMBER_FLAG = 'O';

                if (rbnMandatory.Checked)
                    SetNodeFontStyle(ref node, 'M', (serviceMember.OVERRIDE_FLAG == 'Y'));
                else if (rbnCondMandatory.Checked)
                    SetNodeFontStyle(ref node, 'C', (serviceMember.OVERRIDE_FLAG == 'Y'));
                else
                    SetNodeFontStyle(ref node, 'O', (serviceMember.OVERRIDE_FLAG == 'Y'));
            }
        }

        private void btnErrorCodeExportFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtErrorCodeExportFile.Text = saveFileDialog.FileName;
                txtExport.Text = "";
            }
        }

        private void btnErrorCodeExport_Click(object sender, EventArgs e)
        {
            int i;
            Reference reference = new Reference();
            ReferenceData data = null;

            TRSNode in_node = new TRSNode("Message_List_In");
            TRSNode out_node;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';

            if (txtErrorCodeExportFile.Text == "")
                return;

            txtExport.Text = "";

            b_export_stop = false;

            // Export중에Disable
            SetExportEnables(false);


            reference.Name = "Error_Code";
            reference.Version = 1.0;


            txtExport.AppendText("\tReads Msg Codes from database\r\n");
            do
            {
                out_node = new TRSNode("Message_List_Out");

                if (b_export_stop)
                {
                    SetExportEnables(true);
                    txtExport.Focus();
                    txtExport.AppendText("<User Stop>..." + "\r\n");
                    return;
                }


                if (MPCR.CallService("BAS", "BAS_View_Message_List", in_node, ref out_node, false) == false)
                {
                    txtExport.AppendText(out_node.Msg + "\r\n");
                    txtExport.AppendText(out_node.DBErrMsg + "\r\n");
                    SetExportEnables(true);
                    return;
                }

                progressBarExport.Value = 0;

                progressBarExport.Maximum = out_node.GetList(0).Count;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    data = new ReferenceData();                   

                    data.Key = out_node.GetList(0)[i].GetString("MSG_ID");
                    data.Desc1 = out_node.GetList(0)[i].GetString("MSG_1");
                    data.Desc2 = out_node.GetList(0)[i].GetString("MSG_2");
                    data.Desc3 = out_node.GetList(0)[i].GetString("MSG_3");
                    reference.List.Add(data);

                    txtExport.AppendText("\t\tMSG_ID : " + data.Key +"\r\n");

                    progressBarExport.Increment(1);
                }

                in_node.SetString("NEXT_MSG_ID", out_node.GetString("NEXT_MSG_ID"));

            } while (in_node.GetString("NEXT_MSG_ID") != "");

            XmlSerializer serializer = new XmlSerializer(typeof(Reference));
            TextWriter writer = new StreamWriter(txtErrorCodeExportFile.Text);

            serializer.Serialize(writer, reference);
            writer.Close();

            txtExport.AppendText("Export Complete...\r\n");

            progressBarExport.Value = 0;

            SetExportEnables(true);
        }

        private void btnErrorCodeStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        // Table Commnet Export to XML (By Phillip)
        private void btnTableDescExportFile_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "XML | *.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtTableDescExportFile.Text = saveFileDialog.FileName;
                txtProgress.Text = "";
                txtExport.Text = "";
            }
        }

        private void btnTableDescExport_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            ReferenceData data = null;

            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node;

            string sQuery = "SELECT table_name, comments from user_tab_comments where length(table_name) = 10 and comments is not null and comments <> ' ' order by table_name";
            int i;

            if (txtTableDescExportFile.Text == "")
                return;

            txtExport.Text = "";

            b_export_stop = false;

            // Export중에Disable
            SetExportEnables(false);

            reference.Name = "Table_Name";
            reference.Version = 1.0;

            txtExport.AppendText("\tReads Table Comments from database\r\n");
            do
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", sQuery);

                out_node = new TRSNode("SQL_OUT");

                if (b_export_stop)
                {
                    SetExportEnables(true);
                    txtExport.Focus();
                    txtExport.AppendText("<User Stop>..." + "\r\n");
                    return;
                }


                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node, false) == false)
                {
                    txtExport.AppendText(out_node.Msg + "\r\n");
                    txtExport.AppendText(out_node.DBErrMsg + "\r\n");
                    SetExportEnables(true);
                    return;
                }

                progressBarExport.Value = 0;

                progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                {
                    data = new ReferenceData();                                       

                    data.Key = out_node.GetList("ROWS")[i].GetList("COLS")[0].GetString("DATA");
                    data.Desc1 = out_node.GetList("ROWS")[i].GetList("COLS")[1].GetString("DATA");
                    reference.List.Add(data);

                    txtExport.AppendText("\t" + data.Key + "\n");
                    progressBarExport.Increment(1);                    
                }

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (out_node.GetInt("NEXT_ROW") > 0);

            XmlSerializer serializer = new XmlSerializer(typeof(Reference));
            TextWriter writer = new StreamWriter(txtTableDescExportFile.Text);

            serializer.Serialize(writer, reference);
            writer.Close();

            txtExport.AppendText("Export Complete...\r\n");

            progressBarExport.Value = 0;

            SetExportEnables(true);
        }

        private void btnTableDescStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void cbxArrayType_TextChanged(object sender, EventArgs e)
        {
            if (cbxMemberType.Text == "Array")
            {
                if (cbxArrayType.Items.Contains(cbxArrayType.Text) == false)
                {
                    cbxArrayType.SelectedIndex = -1;
                    cbxArrayType.Text = "";
                }
                else
                {
                    lblRange.Visible = false;
                    chkUseRange.Visible = false;
                    chkUseRange.Checked = false;
                    nudRangeMin.Visible = false;
                    nudRangeMin.Enabled = false;
                    lblBetween.Visible = false;
                    nudRangeMax.Visible = false;
                    nudRangeMax.Enabled = false;

                    lblMemberSize.Visible = false;
                    txtMemberSize.Visible = false;

                    // 세부 항목별 Setting 적용
                    switch (cbxArrayType.Text)
                    {
                        case "String":
                            lblMemberSize.Visible = true;
                            txtMemberSize.Visible = true;
                            break;
                        case "Array":
                        case "List":
                        case "Datetime":
                        case "Blob":
                        case "Boolean":
                            break;
                        case "Char":
                            txtMemberSize.Text = "";
                            break;
                        default:
                            txtMemberSize.Text = "";
                            lblRange.Visible = true;
                            chkUseRange.Visible = true;
                            nudRangeMin.Visible = true;
                            lblBetween.Visible = true;
                            nudRangeMax.Visible = true;
                            break;
                    }

                    SetRanges(cbxMemberType.Text);
                }
            }
        }

        private void cdvSLibName_ButtonPress(object sender, EventArgs e)
        {
            cdvSLibName.Init();
            MPCF.InitListView(cdvSLibName.GetListView);
            cdvSLibName.Columns.Add("Shared Lib Name", 50, HorizontalAlignment.Left);
            cdvSLibName.SelectedSubItemIndex = 0;

            View_Shared_Lib_List(cdvSLibName.GetListView);
        }

        private void cdvToModule_ButtonPress(object sender, EventArgs e)
        {
            cdvToModule.Init();
            MPCF.InitListView(cdvToModule.GetListView);
            cdvToModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvToModule.SelectedSubItemIndex = 0;

            View_Module_List(cdvToModule.GetListView, '4');
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("Update_Service_In");
            TRSNode out_node = new TRSNode("Update_Service_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_COPY;

            in_node.AddString("FROM_MODULE_NAME", lisService.SelectedItems[0].SubItems[0].Text);
            in_node.AddString("FROM_SERVICE_NAME", lisService.SelectedItems[0].SubItems[1].Text);
            in_node.AddString("MODULE_NAME", cdvToModule.Text);
            in_node.AddString("SERVICE_NAME", txtToService.Text);

            if (MPCR.CallService("SVM", "SVM_Update_Service", in_node, ref out_node, true) == false)
            {
                return ;
            }

            MPCR.ShowSuccessMsg(out_node);
        }

        private void txtServiceName_TextChanged(object sender, EventArgs e)
        {
            chkCreateDefault.Checked = true;
        }

        private void cdvCMF_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                MPCR.CheckCMFKeyPress(sender, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInsertExport_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query;
            string data;
            int i, k;
            string temp = null;
            string cmt = null;
            StringBuilder script = null;
            string sServiceName;
            string[] sServices;
            int i_service_index;
            int i_service_count;
            bool b_service_list_generate;
            bool b_get_next;

            List<TRSNode> lRows;
            List<TRSNode> lCols;

            txtExport.Text = "";
            sServiceName = "";
            i_service_index = 0;
            i_service_count = 0;
            sServices = null;
            b_service_list_generate = false;
            b_get_next = false;

            if (txtServiceList.Visible == true)
            {
                if (MPCF.Trim(txtServiceList.Text) == "")
                {
                    txtExport.Visible = true;

                    txtServiceList.Dock = DockStyle.None;
                    txtServiceList.Visible = false;
                    txtServiceList.Text = "";

                    return;
                }

                sServices = txtServiceList.Text.Split('\n');

                txtExport.Visible = true;

                txtServiceList.Dock = DockStyle.None;
                txtServiceList.Visible = false;
                txtServiceList.Text = "";

                if (sServices.Length < 1)
                {
                    return;
                }

                sServiceName = sServices[0];
                i_service_count = sServices.Length;
                b_service_list_generate = true;
            }
            else
            {
                sServiceName = txtInsertServiceName.Text;
                i_service_count = 1;
            }

            script = new StringBuilder();
            progressBarExport.Value = 0;
            progressBarExport.Maximum = i_service_count;

            while(i_service_index < i_service_count)
            {
                #region rdobutton 체크
                if (rboService.Checked == true)
                {
                    if (sServiceName == "") return;
                    if (chkInMbrTable.Checked == false) 
                    {
                        Query = "SELECT * FROM MSVMSVCDEF WHERE SERVICE_NAME = '" + sServiceName + "'";
                        cmt = "MSVMSVCDEF Table(Service) : " + sServiceName;
                    } 
                    else
                    {
                        Query = "SELECT * FROM MSVMSVCMBR WHERE SERVICE_NAME = '" + sServiceName + "' ORDER BY DIRECTION, MEMBER_DEPTH, PARENT_MEMBER_PATH, MEMBER_SEQ, MEMBER_PATH";
                        cmt = "MSVMSVCMBR Table(Service) : " + sServiceName;
                    }
                }
                else if (rboModule.Checked == true)
                {
                    if (cdvInsertExportModule.Text == "") return;
                    if (chkInMbrTable.Checked == false) 
                    {
                        Query = "SELECT * FROM MSVMSVCDEF WHERE MODULE_NAME = '" + cdvInsertExportModule.Text + "' ORDER BY SERVICE_NAME";
                        cmt = "MSVMSVCDEF Table(Module) : " + cdvInsertExportModule.Text;
                    }
                    else
                    {
                        Query = "SELECT * FROM MSVMSVCMBR WHERE MODULE_NAME = '" + cdvInsertExportModule.Text + "' ORDER BY SERVICE_NAME, DIRECTION, MEMBER_DEPTH, PARENT_MEMBER_PATH, MEMBER_SEQ, MEMBER_PATH";
                        cmt = "MSVMSVCMBR Table(Module) : " + cdvInsertExportModule.Text;
                    }
                }
                else
                {
                    if (chkInMbrTable.Checked == false) 
                    {
                        Query = "SELECT * FROM MSVMSVCDEF ORDER BY MODULE_NAME, SERVICE_NAME";
                        cmt = "MSVMSVCDEF Table";
                    }
                    else 
                    {
                        Query = "SELECT * FROM MSVMSVCMBR ORDER BY MODULE_NAME, SERVICE_NAME, DIRECTION, MEMBER_DEPTH, PARENT_MEMBER_PATH, MEMBER_SEQ, MEMBER_PATH";
                        cmt = "MSVMSVCMBR Table";
                    }
                } 
                #endregion

                try
                {
                    in_node.Init();
                    out_node.Init();

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("SQL", Query);
                
                    do
                    {
                        if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                        {
                            return;
                        }

                        #region 컬럼명 셋팅
                        if (b_get_next == false)
                        {
                            if (chkInMbrTable.Checked == false)
                            {
                                temp = "INSERT INTO MSVMSVCDEF(";
                            }
                            else
                            {
                                if (chkIncDelMbrs.Checked == true)
                                {
                                    string sModuleName = cdvInsertExportModule.Text;

                                    if (sModuleName == "" || b_service_list_generate == true)
                                    {
                                        int i_module_name_index;

                                        i_module_name_index = -1;
                                        lCols = out_node.GetList("COLUMNS");
                                        for (i = 0; i < lCols.Count; i++)
                                        {
                                            if (lCols[i].GetString("NAME") == "MODULE_NAME")
                                            {
                                                i_module_name_index = i;
                                                break;
                                            }
                                        }

                                        lRows = out_node.GetList("ROWS");
                                        for (i = 0; i < lRows.Count; i++)
                                        {
                                            lCols = lRows[i].GetList("COLS");
                                            sModuleName = MPCF.Trim(lCols[i_module_name_index].GetString("DATA"));
                                            break;
                                        }
                                    }

                                    script.Append("DELETE FROM MSVMSVCMBR WHERE MODULE_NAME = '" + sModuleName + "' AND SERVICE_NAME = '" + sServiceName + "';\r\n");
                                }
                                temp = "INSERT INTO MSVMSVCMBR(";
                            }

                            lCols = out_node.GetList("COLUMNS");
                            for (i = 0; i < lCols.Count; i++)
                            {
                                temp += lCols[i].GetString("NAME");
                                if (i < lCols.Count - 1) temp += ", ";
                            }
                            temp += ") VALUES(";
                            script.Append("/* Start [" + cmt + "] */\r\n");
                        }

                        script.Append(temp);
                        #endregion

                        //Request Reply Timeout 발생시 옵션에서 TimeOut시간을 늘려주어야함
                        #region Data값 받기

                        lRows = out_node.GetList("ROWS");
                        for (i = 0; i < lRows.Count; i++)
                        {
                            lCols = lRows[i].GetList("COLS");
                            for (k = 0; k < lCols.Count; k++)
                            {
                                data = MPCF.Trim(lCols[k].GetString("DATA"));

                                if (data == "")
                                {
                                    script.Append("' ");
                                    if (k < lCols.Count - 1) script.Append("', ");
                                    else script.Append("'");
                                }
                                else
                                {
                                    script.Append("'");
                                    if (data.Contains("'"))
                                    {
                                        data = data.Replace("'", "''");
                                    }

                                    script.Append(data);
                                    if (k < lCols.Count - 1) script.Append("', ");
                                    else script.Append("'");
                                }
                            }
                            script.Append(");\r\n");

                            if (b_export_stop) //Stop 처리
                            {
                                txtExport.Focus();
                                txtExport.AppendText("<User Stop>..." + "\r\n");
                                b_export_stop = false;
                                return;
                            }
                            if (i < lRows.Count - 1) script.Append(temp);
                        }

                        in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

                        b_get_next = false;
                        if (in_node.GetInt("NEXT_ROW") > 0)
                        {
                            b_get_next = true;
                        }
                        else
                        {
                            script.Append("/* End [" + cmt + "] */\r\n\r\n");
                        }

                    } while (b_get_next == true); 
                    #endregion
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    progressBarExport.Value = 0;
                    return;
                }

                i_service_index++;
                progressBarExport.Value = i_service_index;

                if (b_service_list_generate == true && i_service_index < i_service_count)
                {
                    sServiceName = sServices[i_service_index];
                }
            }//end while

            txtExport.Text = script.ToString();
            txtExport.Select(0, txtExport.Text.Length);
            txtExport.SelectionFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

            if (txtInsertExportFile.Text != "")
            {
                StreamWriter write = null;

                try
                {
                    write = new StreamWriter(txtInsertExportFile.Text, false, Encoding.GetEncoding("EUC-KR"));
                    write.Write(script);
                    write.Close();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    progressBarExport.Value = 0;

                    if (write != null)
                    {
                        write.Close();
                    }

                    return;
                }
            }

            progressBarExport.Value = 0;
            return;
        }

        private void btnClipCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtExport.Text) != "")
                {
                    Clipboard.SetText(txtExport.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInsertExportStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void chkInMbrTable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInMbrTable.Checked == true && rboService.Checked == true)
            {
                chkIncDelMbrs.Enabled = chkInMbrTable.Checked;
            }
            else
            {
                chkIncDelMbrs.Enabled = false;
                chkIncDelMbrs.Checked = false;
            }
        }

        private void rboInsertExport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInMbrTable.Checked == true && rboService.Checked == true)
            {
                chkIncDelMbrs.Enabled = chkInMbrTable.Checked;
            }
            else
            {
                chkIncDelMbrs.Enabled = false;
                chkIncDelMbrs.Checked = false;
            }
        }

        private void lblExpService_DoubleClick(object sender, EventArgs e)
        {
            if (rboService.Checked == true && chkInMbrTable.Checked == true)
            {
                if (txtExport.Visible == true)
                {
                    txtServiceList.Dock = DockStyle.Fill;
                    txtServiceList.Visible = true;

                    txtExport.Visible = false;
                }
                else
                {
                    txtExport.Visible = true;

                    txtServiceList.Dock = DockStyle.None;
                    txtServiceList.Visible = false;
                    txtServiceList.Text = "";
                }
            }
        }
    }
}