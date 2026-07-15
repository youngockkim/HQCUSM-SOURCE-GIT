using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewAnswerfortheChecklist.cs
//   Description : View Answer for the Checklist
//
//   MES Version : 5.3.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-14 : Created by Yeonggon Son
//       - 2013-02-21 : Modified by mhim
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.BASCore
{
    public partial class frmBASViewAnswerfortheChecklist : frmCheckListTranMain
    {
        public frmBASViewAnswerfortheChecklist()
        {
            InitializeComponent();
        }

        #region " Function Definition "

        public override bool InitForm()
        {
            if (base.InitForm() == false) return false;
            b_read_only = true;
            chkCompleteFlag.Enabled = false;
            return true;
        }

        public override bool ViewMain(string check_id)
        {
            try
            {
                ClearData("2");

                if (base.ViewHistoryList(MPCF.Trim(cdvChecklistID.Text)) == false)
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

        public override bool ViewHistoryList(string chklist_id)
        {
            if (base.ViewHistoryList(chklist_id) == false) return false;
            //if (lisCheckHistory.Items.Count > 0)
            //{
            //    lisCheckHistory.Items[0].Selected = true;
            //}
            return true;
        }

        public override bool ViewHistory(string chklist_id, int check_history_seq)
        {
            if (base.ViewHistory(chklist_id, check_history_seq) == false) return false;

            DisplayKeyPrompt();

            if (ViewQueryAnswer(chklist_id, check_history_seq) == false) return false;

            return true;
        }


        #endregion
    }
}
