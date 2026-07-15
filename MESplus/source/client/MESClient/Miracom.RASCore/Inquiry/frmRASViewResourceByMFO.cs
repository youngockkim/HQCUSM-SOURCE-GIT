//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewResourceByMFO.vb
//   Description : View Resource List by MFO
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData()           : Clear Fields and Initialize Sheet
//       - InitCodeView()        : Initialize MCCodeView
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-02-25 : Created by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;

namespace Miracom.RASCore
{
    public partial class frmRASViewResourceByMFO : Miracom.MESCore.ViewForm01
    {
        public frmRASViewResourceByMFO()
        {
            InitializeComponent();
        }

        #region "Function Definition"

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvMaterial;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASViewResourceByMFO_Activated(object sender, EventArgs e)
        {
            MPCF.ClearList(spdRes, true);
            MPCF.FitColumnHeader(spdRes);

            spdRes.Sheets[0].SetColumnAllowAutoSort(0, 28, true);
            MPCF.FitColumnHeader(spdRes);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            char cMFO_level = ' ';

            if (MPCF.Trim(cdvResGroup.Text) != "" &&
                (MPCF.Trim(cdvMaterial.Text) != "" ||
                 MPCF.Trim(cdvFlow.Text) != "" ||
                 MPCF.Trim(cdvOperation.Text) != ""))
            {
                cMFO_level = 'G';
            }
            else if (MPCF.Trim(cdvResGroup.Text) == "" &&
                     (MPCF.Trim(cdvMaterial.Text) != "" ||
                      MPCF.Trim(cdvFlow.Text) != "" ||
                      MPCF.Trim(cdvOperation.Text) != ""))
            {
                cMFO_level = ' ';
            }

            MPCF.ClearList(spdRes);
            RASLIST.ViewResourceListDetail(spdRes, MPCF.Trim(cdvType.Text), MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOperation.Text), MPCF.Trim(cdvResGroup.Text), cMFO_level, "", false, "", false);
            MPCF.FitColumnHeader(spdRes);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Resource Type : " + MPCF.Trim(cdvType.Text);
            MPCF.ExportToExcel(spdRes, this.Text, sCond);

        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            cdvOperation.Text = "";
            MPCF.ClearList(spdRes);
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                cdvFlow.ListCond_Step = '1';
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvOperation.Text = "";
            MPCF.ClearList(spdRes);
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvFlow.Text) == "")
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
                cdvOperation.AddEmptyRow(1);
            }
            else
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, MPCF.Trim(cdvFlow.Text), "", null, "");
                cdvOperation.AddEmptyRow(1);
            }

        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            cdvType.AddEmptyRow(1);
        }

        private void cdvResGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvResGroup.Init();
            MPCF.InitListView(cdvResGroup.GetListView);
            cdvResGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvResGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResGroup.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvMaterial.Text) != "" ||
                MPCF.Trim(cdvFlow.Text) != "" ||
                MPCF.Trim(cdvOperation.Text) != "")
            {
                if (RASLIST.ViewResourceGroupList(cdvResGroup.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text) == false) return;
                cdvResGroup.AddEmptyRow(1);
            }
            else
            {
                if (RASLIST.ViewResourceGroupList(cdvResGroup.GetListView, '1') == false) return;
                cdvResGroup.AddEmptyRow(1);
            }
        }

        private void ctxCopy_Click(System.Object sender, System.EventArgs e)
        {
            spdRes_Sheet1.ClipboardCopy();
        }
    }
}

