using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public partial class frmConfirmMessageBox : Form
    {
        public frmConfirmMessageBox()
        {
            InitializeComponent();
        }

        #region " Properties Definition "

        public bool ReasonTextVisible
        {
            set
            {
                mb_input_reason = false;
                this.lblReason.Visible = false;
                this.cdvReason.Visible = false;

                this.txtReason.Visible = value;

                if (value == true)
                {
                    this.cdvReason.Visible = false;

                    this.lblReason.Visible = value;
                    mb_input_reason_code = false;
                    mb_input_reason = true;
                }
            }
        }

        public bool ReasonCodeViewVisible
        {
            set
            {
                mb_input_reason = false;
                this.lblReason.Visible = false;
                this.txtReason.Visible = false;

                this.cdvReason.Visible = value;

                if (value == true)
                {
                    this.txtReason.Visible = false;

                    this.lblReason.Visible = value;
                    mb_input_reason_code = true;
                    mb_input_reason = true;
                }
            }
        }

        #endregion

        public string ReasonCode
        {
            get
            {
                if (mb_input_reason == false)
                    return "";

                if (mb_input_reason_code == true)
                    return cdvReason.Text;
                else
                    return txtReason.Text;

                return "";
            }
        }

        #region " Variable Definition "

        private const int MSG_BOX_HEIGHT = 128;
        private const int MSG_BOX_DETAIL_HEIGHT = 130;
        //private bool bShowDetailOutMsg = false;
        private bool mb_input_reason;
        private bool mb_input_reason_code;

        #endregion

        #region " Function Implementations"

        /// <summary>
        /// Initialze codeview control
        /// </summary>
        /// <returns></returns>
        private bool cdvInit(string TableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            List<TRSNode> Rows;

            ListViewItem itmX;

            string sQuery = string.Empty;

            try
            {
                cdvReason.Init();
                MPCF.InitListView(cdvReason.GetListView);
                cdvReason.Columns.Add("Code", 100, HorizontalAlignment.Left);
                cdvReason.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvReason.SelectedSubItemIndex = 0;

                sQuery =          "SELECT KEY_1, DATA_1 FROM MGCMTBLDAT WHERE FACTORY = '" + MPGV.gsFactory + "' ";
                sQuery = sQuery + "AND TABLE_NAME = '" + TableName + "' ";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SQL", sQuery);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                Rows = out_node.GetList("ROWS");
                foreach (TRSNode Row in Rows)
                {
                    itmX = new ListViewItem(Row.GetList("COLS")[0].GetString("DATA"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(Row.GetList("COLS")[1].GetString("DATA"));
                    cdvReason.GetListView.Items.Add(itmX);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void ShowButtonStyle(MessageBoxButtons btnStyle, int iDefaultFocus)
        {

            try
            {
                pnlOK.Dock = DockStyle.None;
                pnlOKCancel.Dock = DockStyle.None;
                pnlYesNo.Dock = DockStyle.None;
                pnlYesNoCancel.Dock = DockStyle.None;
                pnlRetryCancel.Dock = DockStyle.None;
                pnlAbortRetryIgnore.Dock = DockStyle.None;

                pnlOK.Visible = false;
                pnlOKCancel.Visible = false;
                pnlYesNo.Visible = false;
                pnlYesNoCancel.Visible = false;
                pnlRetryCancel.Visible = false;
                pnlAbortRetryIgnore.Visible = false;

                //Button Show
                switch (btnStyle)
                {
                    case MessageBoxButtons.OK:

                        pnlOK.Visible = true;
                        pnlOK.Dock = DockStyle.Fill;
                        btnOKOK.Select();
                        break;
                    case MessageBoxButtons.OKCancel:

                        pnlOKCancel.Visible = true;
                        pnlOKCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnOKCancelOK.TabIndex = 0;
                                btnOKCancelCancel.TabIndex = 1;
                                btnOKCancelOK.Select();
                                break;
                            case 2:

                                btnOKCancelOK.TabIndex = 1;
                                btnOKCancelCancel.TabIndex = 0;
                                btnOKCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.YesNo:

                        pnlYesNo.Visible = true;
                        pnlYesNo.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnYesNoYes.TabIndex = 0;
                                btnYesNoNo.TabIndex = 1;
                                btnYesNoYes.Select();
                                break;
                            case 2:

                                btnYesNoNo.TabIndex = 1;
                                btnYesNoYes.TabIndex = 0;
                                btnYesNoNo.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.YesNoCancel:

                        pnlYesNoCancel.Visible = true;
                        pnlYesNoCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnYesNoCancelYes.TabIndex = 0;
                                btnYesNoCancelNo.TabIndex = 1;
                                btnYesNoCancelCancel.TabIndex = 2;
                                btnYesNoCancelYes.Select();
                                break;
                            case 2:

                                btnYesNoCancelYes.TabIndex = 2;
                                btnYesNoCancelNo.TabIndex = 0;
                                btnYesNoCancelCancel.TabIndex = 1;
                                btnYesNoCancelNo.Select();
                                break;
                            case 3:

                                btnYesNoCancelYes.TabIndex = 1;
                                btnYesNoCancelNo.TabIndex = 2;
                                btnYesNoCancelCancel.TabIndex = 0;
                                btnYesNoCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.RetryCancel:

                        pnlRetryCancel.Visible = true;
                        pnlRetryCancel.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnRetryCancelRetry.TabIndex = 0;
                                btnRetryCancelCancel.TabIndex = 1;
                                btnRetryCancelRetry.Select();
                                break;
                            case 2:

                                btnRetryCancelRetry.TabIndex = 1;
                                btnRetryCancelCancel.TabIndex = 0;
                                btnRetryCancelCancel.Select();
                                break;
                        }
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:

                        pnlAbortRetryIgnore.Visible = true;
                        pnlAbortRetryIgnore.Dock = DockStyle.Fill;
                        switch (iDefaultFocus)
                        {
                            case 1:

                                btnAbortRetryIgnoreAbort.TabIndex = 0;
                                btnAbortRetryIgnoreRetry.TabIndex = 1;
                                btnAbortRetryIgnoreIgnore.TabIndex = 2;
                                btnAbortRetryIgnoreAbort.Select();
                                break;
                            case 2:

                                btnAbortRetryIgnoreAbort.TabIndex = 2;
                                btnAbortRetryIgnoreRetry.TabIndex = 0;
                                btnAbortRetryIgnoreIgnore.TabIndex = 1;
                                btnAbortRetryIgnoreRetry.Select();
                                break;
                            case 3:

                                btnAbortRetryIgnoreAbort.TabIndex = 1;
                                btnAbortRetryIgnoreRetry.TabIndex = 2;
                                btnAbortRetryIgnoreIgnore.TabIndex = 0;
                                btnAbortRetryIgnoreIgnore.Select();
                                break;
                        }
                        break;
                    default:

                        break;
                }

                this.Height = MSG_BOX_HEIGHT;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmMessageBox.ShowButtonStyle()\n" + ex.Message);
                return;
            }
        }

        // Show()
        //       - Set sMessage Box Option
        // Return Value
        //       - System.Windows.Forms.DialogResult
        // Arguments
        //       - ByVal sMessage As String
        //       - Optional ByVal sCaption As String = ""
        //       - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //       - Optional ByVal iDefaultFocus As Integer = 1
        //
        public System.Windows.Forms.DialogResult Show(string sMessage, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, bool ReasonVisible, string ReasonTable)
        {
            return Show(sMessage, sCaption, btnStyle, iDefaultFocus, null, ReasonVisible, ReasonTable);
        }

        // Show()
        //       - Set sMessage Box Option
        // Return Value
        //       - System.Windows.Forms.DialogResult
        // Arguments
        //       - ByVal sMessage As String
        //       - Optional ByVal sCaption As String = ""
        //       - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //       - Optional ByVal iDefaultFocus As Integer = 1
        //
        public System.Windows.Forms.DialogResult Show(string sMessage, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner, bool ReasonVisible, string ReasonTable)
        {

            try
            {
                ShowButtonStyle(btnStyle, iDefaultFocus);

                if (ReasonVisible == true)
                {
                    if (ReasonTable != "")
                    {
                        ReasonCodeViewVisible = true;
                        cdvInit(ReasonTable);
                    }
                    else
                        ReasonTextVisible = true;
                }
                else
                {
                    ReasonTextVisible = false;
                    ReasonCodeViewVisible = false;
                }

                //sMessage Show
                lblMessage.Text = sMessage;
                btnDetail.Visible = false;
                this.Text = sCaption;

                this.StartPosition = FormStartPosition.CenterParent;

                if (owner == null)
                {
                    return this.ShowDialog();
                }
                else
                {
                    return this.ShowDialog(owner);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.Show()\n" + ex.Message);
                return System.Windows.Forms.DialogResult.None;
            }

        }

        //Show()
        //      - Set sMessage Box Option
        //Return Value
        //      - System.Windows.Forms.DialogResult
        //Arguments
        //      - ByVal MsgString As clsMsgString
        //      - Optional ByVal sCaption As String = ""
        //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, bool ReasonVisible, string ReasonTable)
        {
            return Show(MsgString, sCaption, btnStyle, iDefaultFocus, null, false, ReasonVisible, ReasonTable);
        }

        //Show()
        //      - Set sMessage Box Option
        //Return Value
        //      - System.Windows.Forms.DialogResult
        //Arguments
        //      - ByVal MsgString As clsMsgString
        //      - Optional ByVal sCaption As String = ""
        //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner, bool ReasonVisible, string ReasonTable)
        {
            return Show(MsgString, sCaption, btnStyle, iDefaultFocus, owner, false, ReasonVisible, ReasonTable);
        }

        //Show()
        //      - Set sMessage Box Option
        //Return Value
        //      - System.Windows.Forms.DialogResult
        //Arguments
        //      - ByVal MsgString As clsMsgString
        //      - Optional ByVal sCaption As String = ""
        //      - Optional ByVal btnStyle As MessageBoxButtons = MessageBoxButtons.OK
        //      - Optional ByVal iDefaultFocus As Integer = 1
        public System.Windows.Forms.DialogResult Show(ReturnMessageString MsgString, string sCaption, MessageBoxButtons btnStyle, int iDefaultFocus, Form owner, bool isShowWarning, bool ReasonVisible, string ReasonTable)
        {
            try
            {
                int i, k;
                ListViewItem itmX;
                int i_temp_1, i_temp_2;
                int i_step = 0;
                int iStartIndex;
                int iEndIndex;
                string sFieldMsg = "";
                string sMsg = "";

                MPCF.InitListView(lisDetailMsg);

                ShowButtonStyle(btnStyle, iDefaultFocus);

                if (ReasonVisible == true)
                {
                    if (ReasonTable != "")
                    {
                        ReasonCodeViewVisible = true;
                        cdvInit(ReasonTable);
                    }
                    else
                        ReasonTextVisible = true;
                }
                else
                {
                    ReasonTextVisible = false;
                    ReasonCodeViewVisible = false;
                }

                //sMessage Show
                lblMessage.Text = MPCF.Trim(MsgString.ErrorMsg);

                this.Text = sCaption;
                if (MsgString.MsgCode.Trim() != "")
                {
                    this.Text += " [" + MsgString.MsgCode.Trim() + "]";
                }

                if (MsgString.DBErrorMsg.Trim() != "" || MsgString.FieldMsg.Count > 0)
                {
                    sFieldMsg = "";
                    sMsg = "";

                    btnDetail.Visible = true;

                    if (MsgString.FieldMsg.Count > 0)
                    {
                        for (i = 0; i < MsgString.FieldMsg.Count; i++)
                        {
                            if (MsgString.IsNodeMsgFlag == false)
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[i]);
                                iStartIndex = 0;
                                iEndIndex = sFieldMsg.IndexOf(":");
                                if (iEndIndex >= 0)
                                {
                                    sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex) + 1);
                                    if (sMsg.Trim() != "")
                                    {
                                        itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        lisDetailMsg.Items.Add(itmX);
                                    }
                                }
                                while (true)
                                {
                                    if (i_step == 1)
                                    {
                                        iStartIndex = iEndIndex + 2;
                                    }
                                    else
                                    {
                                        iStartIndex = iEndIndex + 1;
                                    }

                                    if (iStartIndex >= sFieldMsg.Length)
                                    {
                                        break;
                                    }
                                    i_temp_1 = sFieldMsg.IndexOf("=", iStartIndex);
                                    i_temp_2 = sFieldMsg.IndexOf("]", iStartIndex);
                                    if (i_temp_1 < i_temp_2)
                                    {
                                        iEndIndex = i_temp_1;
                                        i_step = 1;
                                    }
                                    else
                                    {
                                        iEndIndex = i_temp_2;
                                        i_step = 2;
                                    }

                                    if (iEndIndex >= iStartIndex)
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                        if (sMsg.Trim() != "")
                                        {
                                            if (i_step == 1)
                                            {
                                                itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                                itmX.SubItems.Add("");
                                                lisDetailMsg.Items.Add(itmX);
                                            }
                                            else
                                            {
                                                lisDetailMsg.Items[lisDetailMsg.Items.Count - 1].SubItems[1].Text = sMsg.Trim();

                                            }
                                        }
                                    }
                                    else
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (sFieldMsg.Length - iStartIndex));
                                        if (sMsg.Trim() != "")
                                        {
                                            itmX = new ListViewItem("");
                                            itmX.SubItems.Add(sMsg.Trim());
                                            lisDetailMsg.Items.Add(itmX);
                                        }
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[i]);
                                iStartIndex = 0;

                                iEndIndex = sFieldMsg.IndexOf("=", iStartIndex);
                                if (iEndIndex > 0)
                                {
                                    sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                    itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    iStartIndex = sFieldMsg.IndexOf("[") + 1;
                                    iEndIndex = sFieldMsg.IndexOf("]", iStartIndex);
                                    if (iEndIndex > 0)
                                    {
                                        itmX.SubItems.Add(sFieldMsg.Substring(iStartIndex, iEndIndex - iStartIndex));
                                        lisDetailMsg.Items.Add(itmX);
                                    }

                                }
                                else
                                {
                                    itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    itmX.SubItems.Add("");
                                    lisDetailMsg.Items.Add(itmX);
                                }



                            }
                        }
                    }
                }
                else
                {
                    btnDetail.Visible = false;
                }

                if (MsgString.DBErrorMsg.Trim() != "")
                {
                    itmX = new ListViewItem(MsgString.DBErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                    itmX.SubItems.Add("");
                    lisDetailMsg.Items.Add(itmX);

                }

                if (MsgString.OutNode.Count > 0)
                {
                    string s_item_name;
                    string s_lot_id = "";
                    btnDetail.Visible = true;
                    for (i = 0; i < MsgString.OutNode.Count; i++)
                    {
                        if (i > 0)
                        {
                            s_lot_id = MPCF.Trim(MsgString.OutNode[i].GetString("LOT_ID"));
                            if (MPCF.Trim(s_lot_id) != "")
                            {
                                s_lot_id += " : ";
                            }
                        }

                        for (k = 0; k < MsgString.OutNode[i].MemberCount; k++)
                        {
                            s_item_name = MsgString.OutNode[i].GetMember(k).Name;
                            itmX = new ListViewItem(s_lot_id + s_item_name, (int)SMALLICON_INDEX.IDX_MODULE);

                            itmX.SubItems.Add(MPCF.Trim(MsgString.OutNode[i].GetMember(k).Value));
                            lisDetailMsg.Items.Add(itmX);
                        }
                    }

                }

                if (isShowWarning == true)
                {
                    if (MPGV.gaWarningMsg.Count > 0)
                    {
                        sFieldMsg = "";

                        btnWDetail.Visible = true;

                        for (i = 0; i < MPGV.gaWarningMsg.Count; i++)
                        {
                            MsgString = (ReturnMessageString)MPGV.gaWarningMsg[i];

                            itmX = new ListViewItem(MsgString.ErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                            itmX.SubItems.Add("");
                            lisDetailMsg.Items.Add(itmX);

                            if (MsgString.DBErrorMsg != "")
                            {
                                itmX = new ListViewItem(MsgString.DBErrorMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                                itmX.SubItems.Add("");
                                lisDetailMsg.Items.Add(itmX);
                            }
                            for (k = 0; k < MsgString.FieldMsg.Count; k++)
                            {
                                sFieldMsg = MPCF.Trim(MsgString.FieldMsg[k]);
                                iStartIndex = 0;
                                if (k == 0)
                                {
                                    itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                    itmX.SubItems.Add("");
                                    lisDetailMsg.Items.Add(itmX);
                                }
                                else
                                {
                                    iEndIndex = sFieldMsg.IndexOf("=", iStartIndex);
                                    if (iEndIndex > 0)
                                    {
                                        sMsg = sFieldMsg.Substring(iStartIndex, (iEndIndex - iStartIndex));
                                        itmX = new ListViewItem(sMsg.Trim(), (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        iStartIndex = sFieldMsg.IndexOf("[") + 1;
                                        iEndIndex = sFieldMsg.IndexOf("]", iStartIndex);
                                        if (iEndIndex > 0)
                                        {
                                            itmX.SubItems.Add(sFieldMsg.Substring(iStartIndex, iEndIndex - iStartIndex));
                                            lisDetailMsg.Items.Add(itmX);
                                        }

                                    }
                                    else
                                    {
                                        itmX = new ListViewItem(sFieldMsg, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                                        itmX.SubItems.Add("");
                                        lisDetailMsg.Items.Add(itmX);
                                    }

                                }
                            }
                        }
                    }
                }

                MPCF.FitColumnHeader(lisDetailMsg);

                this.StartPosition = FormStartPosition.CenterParent;

                if (owner == null)
                {
                    return this.ShowDialog();
                }
                else
                {
                    return this.ShowDialog(owner);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.Show()\n" + ex.Message);
                return System.Windows.Forms.DialogResult.None;
            }
        }

        #endregion

        private void frmConfirmMessageBox_Load(object sender, EventArgs e)
        {
            try
            {
                btnYesNoYes.Font = new System.Drawing.Font(btnYesNoYes.Font.Name, MPGV.giMessageSize);
                btnYesNoNo.Font = new System.Drawing.Font(btnYesNoNo.Font.Name, MPGV.giMessageSize);
                btnOKCancelOK.Font = new System.Drawing.Font(btnOKCancelOK.Font.Name, MPGV.giMessageSize);
                btnOKCancelCancel.Font = new System.Drawing.Font(btnOKCancelCancel.Font.Name, MPGV.giMessageSize);
                btnOKOK.Font = new System.Drawing.Font(btnOKOK.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelYes.Font = new System.Drawing.Font(btnYesNoCancelYes.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelNo.Font = new System.Drawing.Font(btnYesNoCancelNo.Font.Name, MPGV.giMessageSize);
                btnYesNoCancelCancel.Font = new System.Drawing.Font(btnYesNoCancelCancel.Font.Name, MPGV.giMessageSize);

                lblMessage.Font = new System.Drawing.Font(lblMessage.Font.Name, MPGV.giMessageSize);

                this.Height = MSG_BOX_HEIGHT;
                MPCF.ToClientLanguage(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.frmMessageBox_Load()\n" + ex.Message);
            }
        }

        private void btnWDetail_Click(object sender, EventArgs e)
        {
            if (pnlDetailMsg.Visible == false)
            {
                pnlDetailMsg.Visible = true;
                this.Height = MSG_BOX_HEIGHT + MSG_BOX_DETAIL_HEIGHT;
            }
            else
            {
                pnlDetailMsg.Visible = false;
                this.Height = MSG_BOX_HEIGHT;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            try
            {
                btnSimple.Visible = true;
                btnSimple.Enabled = true;
                btnDetail.Visible = false;
                btnDetail.Enabled = false;

                pnlDetailMsg.Visible = true;

                this.Height = MSG_BOX_HEIGHT + MSG_BOX_DETAIL_HEIGHT;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnDetail_Click()\n" + ex.Message);
            }
        }

        private void btnSimple_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                btnSimple.Visible = false;
                btnSimple.Enabled = false;
                btnDetail.Visible = true;
                btnDetail.Enabled = true;

                pnlDetailMsg.Visible = false;
                this.Height = MSG_BOX_HEIGHT;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnSimple_Click()\n" + ex.Message);
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(lblMessage.Text, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnCopy_Click()\n" + ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisDetailMsg, lblMessage.Text, "");
        }

        private void btnOKOK_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnOKOK_Click()\n" + ex.Message);
            }

        }

        private void btnOKCancelOK_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnOKCancelOK_Click()\n" + ex.Message);
            }

        }

        private void btnOKCancelCancel_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnOKCancelCancel_Click()\n" + ex.Message);
            }

        }

        private void btnYesNoCancelCancel_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnYesNoCancelCancel_Click()\n" + ex.Message);
            }

        }

        private void btnRetryCancelCancel_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnRetryCancelCancel_Click()\n" + ex.Message);
            }

        }

        private void btnYesNoYes_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnYesNoYes_Click()\n" + ex.Message);
            }

        }

        private void btnYesNoCancelYes_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnYesNoCancelYes_Click()\n" + ex.Message);
            }

        }

        private void btnYesNoNo_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnYesNoNo_Click()\n" + ex.Message);
            }

        }

        private void btnYesNoCancelNo_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnYesNoCancelNo_Click()\n" + ex.Message);
            }

        }

        private void btnRetryCancelRetry_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnRetryCancelRetry_Click()\n" + ex.Message);
            }

        }

        private void btnAbortRetryIgnoreAbort_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnAbortRetryIgnoreAbort_Click()\n" + ex.Message);
            }

        }

        private void btnAbortRetryIgnoreRetry_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnAbortRetryIgnoreRetry_Click()\n" + ex.Message);
            }

        }

        private void btnAbortRetryIgnoreIgnore_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmConfirmMessageBox.btnAbortRetryIgnoreIgnore_Click()\n" + ex.Message);
            }

        }
    }
}
