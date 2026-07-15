
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;

//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCAlarmDisplay.vb
//   Description :
//
//   SPC Version : 1.0.0
//
//   Function List
//       - Ack_Lot_Alarm() : Acknowldge Alarm Message
//       - ViewAlarmList() : View Alarm List
//
//   Detail Description
//       -
//
//   History
//       - 2005-04-26 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class frmSPCAlarmDisplay : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCAlarmDisplay()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader7;
        internal System.Windows.Forms.ColumnHeader ColumnHeader8;
        internal System.Windows.Forms.ColumnHeader ColumnHeader9;
        internal System.Windows.Forms.ColumnHeader ColumnHeader10;
        internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        internal System.Windows.Forms.ColumnHeader ColumnHeader12;
        internal System.Windows.Forms.ColumnHeader ColumnHeader13;
        internal System.Windows.Forms.ColumnHeader ColumnHeader14;
        internal System.Windows.Forms.ColumnHeader ColumnHeader15;
        internal System.Windows.Forms.ColumnHeader ColumnHeader16;
        internal System.Windows.Forms.ColumnHeader ColumnHeader17;
        internal System.Windows.Forms.ColumnHeader ColumnHeader18;
        internal Miracom.UI.Controls.MCListView.MCListView lisAlarm;
        internal System.Windows.Forms.ColumnHeader ColumnHeader19;
        internal System.Windows.Forms.Button btnAcknowledge;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        internal System.Windows.Forms.ColumnHeader ColumnHeader20;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.lisAlarm = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAcknowledge);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcknowledge.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAcknowledge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAcknowledge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAcknowledge.Location = new System.Drawing.Point(558, 8);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(88, 26);
            this.btnAcknowledge.TabIndex = 0;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.lisAlarm);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            this.pnlCenter.TabIndex = 3;
            // 
            // lisAlarm
            // 
            this.lisAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader14,
            this.ColumnHeader20,
            this.ColumnHeader15,
            this.ColumnHeader16,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader17,
            this.ColumnHeader18,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.columnHeader23,
            this.ColumnHeader7,
            this.columnHeader24,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13,
            this.ColumnHeader19});
            this.lisAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAlarm.EnableSort = true;
            this.lisAlarm.EnableSortIcon = true;
            this.lisAlarm.FullRowSelect = true;
            this.lisAlarm.Location = new System.Drawing.Point(3, 3);
            this.lisAlarm.Name = "lisAlarm";
            this.lisAlarm.Size = new System.Drawing.Size(736, 503);
            this.lisAlarm.TabIndex = 2;
            this.lisAlarm.TabStop = false;
            this.lisAlarm.UseCompatibleStateImageBehavior = false;
            this.lisAlarm.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Alarm Level";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Alarm ID";
            this.ColumnHeader2.Width = 80;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Alarm Message";
            this.ColumnHeader14.Width = 200;
            // 
            // ColumnHeader20
            // 
            this.ColumnHeader20.Text = "Chart ID";
            this.ColumnHeader20.Width = 90;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "X / R";
            this.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader15.Width = 50;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "OOC Type";
            this.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader16.Width = 65;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Tran Time";
            this.ColumnHeader3.Width = 110;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "L / R";
            this.ColumnHeader4.Width = 40;
            // 
            // ColumnHeader17
            // 
            this.ColumnHeader17.Text = "Unit ID";
            // 
            // ColumnHeader18
            // 
            this.ColumnHeader18.Text = "Unit Seq";
            this.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Lot ID";
            this.ColumnHeader5.Width = 90;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Mat ID";
            this.ColumnHeader6.Width = 90;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Mat Ver";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Flow";
            this.ColumnHeader7.Width = 80;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Flow Seq";
            this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Oper";
            this.ColumnHeader8.Width = 70;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Proc Oper";
            this.ColumnHeader9.Width = 70;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Res ID";
            this.ColumnHeader10.Width = 90;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Proc Res ID";
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Event ID";
            this.ColumnHeader12.Width = 80;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Char ID";
            this.ColumnHeader13.Width = 80;
            // 
            // ColumnHeader19
            // 
            this.ColumnHeader19.Text = "Hist Seq";
            this.ColumnHeader19.Width = 0;
            // 
            // frmSPCAlarmDisplay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCAlarmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Display Message";
            this.Activated += new System.EventHandler(this.frmSPCAlarmDisplay_Activated);
            this.Load += new System.EventHandler(this.frmSPCAlarmDisplay_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        public bool b_load_flag;
        #endregion
        
        #region " Function Implementations"
        
        // Ack_Lot_Alarm()
        //       - Acknowldge Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iIndex As Integer
        //
        private bool Ack_Alarm(int iIndex)
        {
            ////int i;
            ////int j;
            ////SPC_Ack_Alarm_In_Tag Ack_Alarm_In = new SPC_Ack_Alarm_In_Tag();
            ////SPC_Cmn_Out_Tag Cmn_Out = new SPC_Cmn_Out_Tag();
            
            try
            {
                /*
                Ack_Alarm_In._C.h_passport = MPGV.gsPassport;
                Ack_Alarm_In._C.h_language = MPGV.gcLanguage;
                Ack_Alarm_In._C.h_factory = MPGV.gsFactory;
                Ack_Alarm_In._C.h_user_id = MPGV.gsUserID;
                Ack_Alarm_In._C.h_password = MPGV.gsPassword;
                Ack_Alarm_In._C.h_proc_step = '1';
                
                Ack_Alarm_In._C.chart_id = MPCF.Trim(lisAlarm.Items[iIndex].SubItems[3].Text);
                Ack_Alarm_In._C.hist_seq = MPCF.ToInt(lisAlarm.Items[iIndex].SubItems[21].Text);
                
                
                if (SPCCaster.SPC_Ack_Alarm(Ack_Alarm_In, ref Cmn_Out) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }
                if (Cmn_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(Cmn_Out.h_msg_code, Cmn_Out.h_msg, Cmn_Out.h_db_err_msg, Cmn_Out.h_field_msg));
                    return false;
                }
                
                for (i = 1; i <= MPGV.giSPCAlarmCnt; i++)
                {
                    if (MPCF.Trim(MPGV.gtSPCAlarmList[i].factory) == MPGV.gsFactory &&
                        MPCF.Trim(MPGV.gtSPCAlarmList[i].chart_id) == MPCF.Trim(lisAlarm.Items[iIndex].SubItems[3].Text) &&
                        MPGV.gtSPCAlarmList[i].hist_seq == MPCF.ToDbl(lisAlarm.Items[iIndex].SubItems[21].Text))
                    {
                        for (j = i; j <= MPGV.giSPCAlarmCnt - 1; j++)
                        {
                            MPGV.gtSPCAlarmList[j] = MPGV.gtSPCAlarmList[j + 1];
                        }
                        MPGV.giSPCAlarmCnt--;
                        break;
                    }
                }
                
                lisAlarm.Items[iIndex].Remove();
                */
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.Ack_Alarm()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewAlarmList()
        //       - View Alarm List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewAlarmList()
        {
            
            ListViewItem itemX;
            int i;
            int iLevelIcon;
            string sAlarmLevel;
            
            try
            {
                MPCF.InitListView(lisAlarm);
                
                for (i = 1; i <= MPGV.giSPCAlarmCnt; i++)
                {

                    if (MPGV.gtSPCAlarmList[i].alarm_level_flag == MPGC.MP_ALM_LEVEL_ERROR)
                    {
                        iLevelIcon = (int)SMALLICON_INDEX.IDX_ALARM_ERROR;
                        sAlarmLevel = "Error";
                    }
                    else if (MPGV.gtSPCAlarmList[i].alarm_level_flag == MPGC.MP_ALM_LEVEL_WARN)
                    {
                        iLevelIcon = (int)SMALLICON_INDEX.IDX_ALARM_WARN;
                        sAlarmLevel = "Warning";
                    }
                    else
                    {
                        iLevelIcon = (int)SMALLICON_INDEX.IDX_ALARM_INFO;
                        sAlarmLevel = "Info";
                    }
                    
                    
                    itemX = new ListViewItem(sAlarmLevel, iLevelIcon);
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].alarm_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].alarm_msg));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].chart_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].xr_flag));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].ooc_type));
                    itemX.SubItems.Add(MPCF.MakeDateFormat(MPGV.gtSPCAlarmList[i].tran_time));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].lot_res_flag));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].unit_id));
                    itemX.SubItems.Add(MPGV.gtSPCAlarmList[i].unit_seq.ToString());
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].lot_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].mat_id));
                    itemX.SubItems.Add(MPGV.gtSPCAlarmList[i].mat_ver.ToString());
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].flow));
                    itemX.SubItems.Add(MPGV.gtSPCAlarmList[i].flow_seq_num.ToString());
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].oper));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].proc_oper));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].res_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].proc_res_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].event_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].char_id));
                    itemX.SubItems.Add(MPCF.Trim(MPGV.gtSPCAlarmList[i].hist_seq));
                    
                    lisAlarm.Items.Add(itemX);
                    
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.ViewAlarmList()\n" + ex.Message);
                return false;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCAlarmDisplay_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                if (ViewAlarmList() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.frmSPCAlarmDisplay_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCAlarmDisplay_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (ViewAlarmList() == false)
                    {
                        return;
                    }
                    b_load_flag = true;
                }
                else
                {
                    ViewAlarmList();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.frmSPCAlarmDisplay_Activated()\n" + ex.Message);
            }
            
        }
        
        private void btnAcknowledge_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                int i;
                
                if (lisAlarm.SelectedItems.Count < 1)
                {
                    return;
                }
                
                for (i = 0; i <= lisAlarm.Items.Count - 1; i++)
                {
                    if (i >= lisAlarm.Items.Count || lisAlarm.Items.Count == 0)
                    {
                        break;
                    }
                    if (lisAlarm.Items[i].Selected == true)
                    {
                        if (Ack_Alarm(i) == false)
                        {
                            return;
                        }
                        i--;
                    }
                }
                
                if (i >= lisAlarm.Items.Count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
                }
                
                if (ViewAlarmList() == true)
                {
                    if (lisAlarm.Items.Count > 0)
                    {
                        lisAlarm.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAlarmDisplay.btnAcknowledge_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
