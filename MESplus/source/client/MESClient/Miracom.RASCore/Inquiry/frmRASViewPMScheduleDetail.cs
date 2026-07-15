
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupPMScheduleDetail.vb
//   Description : View PM Schedule Detail Information
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_PM_Schedule() :View PM Schedule
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-09 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewPMScheduleDetail : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewPMScheduleDetail()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        public frmRASViewPMScheduleDetail(string ResID, string PMPlanDate)
        {
            
            
            InitializeComponent();
            
            
            this.txtResID.Text = ResID;
            this.txtPMPlanDate.Text = PMPlanDate;
            
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
        



        private System.Windows.Forms.Panel pnlCenterTop;
        private System.Windows.Forms.Panel pnlCenterBottom;
        private System.Windows.Forms.TextBox txtPMPeriod;
        private System.Windows.Forms.Label lblPMPeriod;
        private System.Windows.Forms.TextBox txtPMPlanDate;
        private System.Windows.Forms.Label lblPMPlanDate;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblPMPlanTime;
        private System.Windows.Forms.Label lblPlanUserID;
        private System.Windows.Forms.Label lblPMActFlag;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtPMComment;
        private System.Windows.Forms.TextBox txtPMPlanTime;
        private System.Windows.Forms.TextBox txtPMPlanUser;
        private System.Windows.Forms.TextBox txtPMEvent;
        private System.Windows.Forms.Label lblPMEvent;
        private System.Windows.Forms.TextBox txtPMActHistSeq;
        private System.Windows.Forms.Label lblActHistSeq;
        private System.Windows.Forms.TextBox txtPMActUser;
        private System.Windows.Forms.Label lblPMActUser;
        private System.Windows.Forms.TextBox txtPMActComment;
        private System.Windows.Forms.Label lblPMActComment;
        private System.Windows.Forms.TextBox txtPMActTime;
        private System.Windows.Forms.Label lblPMActTime;
        private System.Windows.Forms.TextBox txtPMActFlag;
        private System.Windows.Forms.GroupBox grpPM;
        private System.Windows.Forms.GroupBox grpPMAct;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlCenterTop = new System.Windows.Forms.Panel();
            this.grpPM = new System.Windows.Forms.GroupBox();
            this.txtPMComment = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPMPlanTime = new System.Windows.Forms.TextBox();
            this.lblPMPlanTime = new System.Windows.Forms.Label();
            this.txtPMPlanUser = new System.Windows.Forms.TextBox();
            this.lblPlanUserID = new System.Windows.Forms.Label();
            this.txtPMEvent = new System.Windows.Forms.TextBox();
            this.lblPMEvent = new System.Windows.Forms.Label();
            this.txtPMPeriod = new System.Windows.Forms.TextBox();
            this.lblPMPeriod = new System.Windows.Forms.Label();
            this.txtPMPlanDate = new System.Windows.Forms.TextBox();
            this.lblPMPlanDate = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlCenterBottom = new System.Windows.Forms.Panel();
            this.grpPMAct = new System.Windows.Forms.GroupBox();
            this.txtPMActHistSeq = new System.Windows.Forms.TextBox();
            this.lblActHistSeq = new System.Windows.Forms.Label();
            this.txtPMActUser = new System.Windows.Forms.TextBox();
            this.lblPMActUser = new System.Windows.Forms.Label();
            this.txtPMActComment = new System.Windows.Forms.TextBox();
            this.lblPMActComment = new System.Windows.Forms.Label();
            this.txtPMActTime = new System.Windows.Forms.TextBox();
            this.lblPMActTime = new System.Windows.Forms.Label();
            this.txtPMActFlag = new System.Windows.Forms.TextBox();
            this.lblPMActFlag = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCenterTop.SuspendLayout();
            this.grpPM.SuspendLayout();
            this.pnlCenterBottom.SuspendLayout();
            this.grpPMAct.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCenterBottom);
            this.pnlCenter.Controls.Add(this.pnlCenterTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View PM Schedule - Detail";
            // 
            // pnlCenterTop
            // 
            this.pnlCenterTop.Controls.Add(this.grpPM);
            this.pnlCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenterTop.Location = new System.Drawing.Point(3, 3);
            this.pnlCenterTop.Name = "pnlCenterTop";
            this.pnlCenterTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlCenterTop.Size = new System.Drawing.Size(736, 265);
            this.pnlCenterTop.TabIndex = 0;
            // 
            // grpPM
            // 
            this.grpPM.Controls.Add(this.txtPMComment);
            this.grpPM.Controls.Add(this.Label1);
            this.grpPM.Controls.Add(this.txtPMPlanTime);
            this.grpPM.Controls.Add(this.lblPMPlanTime);
            this.grpPM.Controls.Add(this.txtPMPlanUser);
            this.grpPM.Controls.Add(this.lblPlanUserID);
            this.grpPM.Controls.Add(this.txtPMEvent);
            this.grpPM.Controls.Add(this.lblPMEvent);
            this.grpPM.Controls.Add(this.txtPMPeriod);
            this.grpPM.Controls.Add(this.lblPMPeriod);
            this.grpPM.Controls.Add(this.txtPMPlanDate);
            this.grpPM.Controls.Add(this.lblPMPlanDate);
            this.grpPM.Controls.Add(this.txtResID);
            this.grpPM.Controls.Add(this.lblResID);
            this.grpPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPM.Location = new System.Drawing.Point(3, 0);
            this.grpPM.Name = "grpPM";
            this.grpPM.Size = new System.Drawing.Size(730, 262);
            this.grpPM.TabIndex = 1;
            this.grpPM.TabStop = false;
            // 
            // txtPMComment
            // 
            this.txtPMComment.Location = new System.Drawing.Point(120, 95);
            this.txtPMComment.MaxLength = 400;
            this.txtPMComment.Multiline = true;
            this.txtPMComment.Name = "txtPMComment";
            this.txtPMComment.ReadOnly = true;
            this.txtPMComment.Size = new System.Drawing.Size(564, 150);
            this.txtPMComment.TabIndex = 13;
            this.txtPMComment.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(15, 98);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "PM Comment";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMPlanTime
            // 
            this.txtPMPlanTime.Location = new System.Drawing.Point(484, 68);
            this.txtPMPlanTime.MaxLength = 30;
            this.txtPMPlanTime.Name = "txtPMPlanTime";
            this.txtPMPlanTime.ReadOnly = true;
            this.txtPMPlanTime.Size = new System.Drawing.Size(200, 20);
            this.txtPMPlanTime.TabIndex = 11;
            this.txtPMPlanTime.TabStop = false;
            // 
            // lblPMPlanTime
            // 
            this.lblPMPlanTime.AutoSize = true;
            this.lblPMPlanTime.Location = new System.Drawing.Point(379, 71);
            this.lblPMPlanTime.Name = "lblPMPlanTime";
            this.lblPMPlanTime.Size = new System.Drawing.Size(73, 13);
            this.lblPMPlanTime.TabIndex = 10;
            this.lblPMPlanTime.Text = "PM Plan Time";
            this.lblPMPlanTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMPlanUser
            // 
            this.txtPMPlanUser.Location = new System.Drawing.Point(484, 42);
            this.txtPMPlanUser.MaxLength = 20;
            this.txtPMPlanUser.Name = "txtPMPlanUser";
            this.txtPMPlanUser.ReadOnly = true;
            this.txtPMPlanUser.Size = new System.Drawing.Size(200, 20);
            this.txtPMPlanUser.TabIndex = 9;
            this.txtPMPlanUser.TabStop = false;
            // 
            // lblPlanUserID
            // 
            this.lblPlanUserID.AutoSize = true;
            this.lblPlanUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanUserID.Location = new System.Drawing.Point(379, 45);
            this.lblPlanUserID.Name = "lblPlanUserID";
            this.lblPlanUserID.Size = new System.Drawing.Size(86, 13);
            this.lblPlanUserID.TabIndex = 8;
            this.lblPlanUserID.Text = "PM Plan User ID";
            this.lblPlanUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMEvent
            // 
            this.txtPMEvent.Location = new System.Drawing.Point(484, 15);
            this.txtPMEvent.MaxLength = 12;
            this.txtPMEvent.Name = "txtPMEvent";
            this.txtPMEvent.ReadOnly = true;
            this.txtPMEvent.Size = new System.Drawing.Size(200, 20);
            this.txtPMEvent.TabIndex = 7;
            this.txtPMEvent.TabStop = false;
            // 
            // lblPMEvent
            // 
            this.lblPMEvent.AutoSize = true;
            this.lblPMEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMEvent.Location = new System.Drawing.Point(379, 18);
            this.lblPMEvent.Name = "lblPMEvent";
            this.lblPMEvent.Size = new System.Drawing.Size(54, 13);
            this.lblPMEvent.TabIndex = 6;
            this.lblPMEvent.Text = "PM Event";
            this.lblPMEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMPeriod
            // 
            this.txtPMPeriod.Location = new System.Drawing.Point(120, 69);
            this.txtPMPeriod.MaxLength = 6;
            this.txtPMPeriod.Name = "txtPMPeriod";
            this.txtPMPeriod.ReadOnly = true;
            this.txtPMPeriod.Size = new System.Drawing.Size(200, 20);
            this.txtPMPeriod.TabIndex = 5;
            this.txtPMPeriod.TabStop = false;
            // 
            // lblPMPeriod
            // 
            this.lblPMPeriod.AutoSize = true;
            this.lblPMPeriod.Location = new System.Drawing.Point(15, 72);
            this.lblPMPeriod.Name = "lblPMPeriod";
            this.lblPMPeriod.Size = new System.Drawing.Size(56, 13);
            this.lblPMPeriod.TabIndex = 4;
            this.lblPMPeriod.Text = "PM Period";
            this.lblPMPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMPlanDate
            // 
            this.txtPMPlanDate.Location = new System.Drawing.Point(120, 43);
            this.txtPMPlanDate.MaxLength = 30;
            this.txtPMPlanDate.Name = "txtPMPlanDate";
            this.txtPMPlanDate.ReadOnly = true;
            this.txtPMPlanDate.Size = new System.Drawing.Size(200, 20);
            this.txtPMPlanDate.TabIndex = 3;
            this.txtPMPlanDate.TabStop = false;
            // 
            // lblPMPlanDate
            // 
            this.lblPMPlanDate.AutoSize = true;
            this.lblPMPlanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMPlanDate.Location = new System.Drawing.Point(15, 46);
            this.lblPMPlanDate.Name = "lblPMPlanDate";
            this.lblPMPlanDate.Size = new System.Drawing.Size(85, 13);
            this.lblPMPlanDate.TabIndex = 2;
            this.lblPMPlanDate.Text = "PM Plan Date";
            this.lblPMPlanDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(120, 16);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(200, 20);
            this.txtResID.TabIndex = 1;
            this.txtResID.TabStop = false;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(61, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCenterBottom
            // 
            this.pnlCenterBottom.Controls.Add(this.grpPMAct);
            this.pnlCenterBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterBottom.Location = new System.Drawing.Point(3, 268);
            this.pnlCenterBottom.Name = "pnlCenterBottom";
            this.pnlCenterBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCenterBottom.Size = new System.Drawing.Size(736, 235);
            this.pnlCenterBottom.TabIndex = 1;
            // 
            // grpPMAct
            // 
            this.grpPMAct.Controls.Add(this.txtPMActHistSeq);
            this.grpPMAct.Controls.Add(this.lblActHistSeq);
            this.grpPMAct.Controls.Add(this.txtPMActUser);
            this.grpPMAct.Controls.Add(this.lblPMActUser);
            this.grpPMAct.Controls.Add(this.txtPMActComment);
            this.grpPMAct.Controls.Add(this.lblPMActComment);
            this.grpPMAct.Controls.Add(this.txtPMActTime);
            this.grpPMAct.Controls.Add(this.lblPMActTime);
            this.grpPMAct.Controls.Add(this.txtPMActFlag);
            this.grpPMAct.Controls.Add(this.lblPMActFlag);
            this.grpPMAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPMAct.Location = new System.Drawing.Point(3, 3);
            this.grpPMAct.Name = "grpPMAct";
            this.grpPMAct.Size = new System.Drawing.Size(730, 229);
            this.grpPMAct.TabIndex = 2;
            this.grpPMAct.TabStop = false;
            this.grpPMAct.Text = "PM Action Information ";
            // 
            // txtPMActHistSeq
            // 
            this.txtPMActHistSeq.Location = new System.Drawing.Point(484, 47);
            this.txtPMActHistSeq.MaxLength = 10;
            this.txtPMActHistSeq.Name = "txtPMActHistSeq";
            this.txtPMActHistSeq.ReadOnly = true;
            this.txtPMActHistSeq.Size = new System.Drawing.Size(200, 20);
            this.txtPMActHistSeq.TabIndex = 9;
            this.txtPMActHistSeq.TabStop = false;
            // 
            // lblActHistSeq
            // 
            this.lblActHistSeq.AutoSize = true;
            this.lblActHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActHistSeq.Location = new System.Drawing.Point(379, 50);
            this.lblActHistSeq.Name = "lblActHistSeq";
            this.lblActHistSeq.Size = new System.Drawing.Size(80, 13);
            this.lblActHistSeq.TabIndex = 8;
            this.lblActHistSeq.Text = "Action Hist Seq";
            this.lblActHistSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMActUser
            // 
            this.txtPMActUser.Location = new System.Drawing.Point(484, 20);
            this.txtPMActUser.MaxLength = 20;
            this.txtPMActUser.Name = "txtPMActUser";
            this.txtPMActUser.ReadOnly = true;
            this.txtPMActUser.Size = new System.Drawing.Size(200, 20);
            this.txtPMActUser.TabIndex = 7;
            this.txtPMActUser.TabStop = false;
            // 
            // lblPMActUser
            // 
            this.lblPMActUser.AutoSize = true;
            this.lblPMActUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMActUser.Location = new System.Drawing.Point(379, 23);
            this.lblPMActUser.Name = "lblPMActUser";
            this.lblPMActUser.Size = new System.Drawing.Size(76, 13);
            this.lblPMActUser.TabIndex = 6;
            this.lblPMActUser.Text = "Action User ID";
            this.lblPMActUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMActComment
            // 
            this.txtPMActComment.Location = new System.Drawing.Point(120, 74);
            this.txtPMActComment.MaxLength = 400;
            this.txtPMActComment.Multiline = true;
            this.txtPMActComment.Name = "txtPMActComment";
            this.txtPMActComment.ReadOnly = true;
            this.txtPMActComment.Size = new System.Drawing.Size(564, 150);
            this.txtPMActComment.TabIndex = 5;
            this.txtPMActComment.TabStop = false;
            // 
            // lblPMActComment
            // 
            this.lblPMActComment.AutoSize = true;
            this.lblPMActComment.Location = new System.Drawing.Point(15, 77);
            this.lblPMActComment.Name = "lblPMActComment";
            this.lblPMActComment.Size = new System.Drawing.Size(84, 13);
            this.lblPMActComment.TabIndex = 4;
            this.lblPMActComment.Text = "Action Comment";
            this.lblPMActComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMActTime
            // 
            this.txtPMActTime.Location = new System.Drawing.Point(120, 48);
            this.txtPMActTime.MaxLength = 30;
            this.txtPMActTime.Name = "txtPMActTime";
            this.txtPMActTime.ReadOnly = true;
            this.txtPMActTime.Size = new System.Drawing.Size(200, 20);
            this.txtPMActTime.TabIndex = 3;
            this.txtPMActTime.TabStop = false;
            // 
            // lblPMActTime
            // 
            this.lblPMActTime.AutoSize = true;
            this.lblPMActTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMActTime.Location = new System.Drawing.Point(15, 51);
            this.lblPMActTime.Name = "lblPMActTime";
            this.lblPMActTime.Size = new System.Drawing.Size(63, 13);
            this.lblPMActTime.TabIndex = 2;
            this.lblPMActTime.Text = "Action Time";
            this.lblPMActTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMActFlag
            // 
            this.txtPMActFlag.Location = new System.Drawing.Point(120, 21);
            this.txtPMActFlag.MaxLength = 1;
            this.txtPMActFlag.Name = "txtPMActFlag";
            this.txtPMActFlag.ReadOnly = true;
            this.txtPMActFlag.Size = new System.Drawing.Size(200, 20);
            this.txtPMActFlag.TabIndex = 1;
            this.txtPMActFlag.TabStop = false;
            // 
            // lblPMActFlag
            // 
            this.lblPMActFlag.AutoSize = true;
            this.lblPMActFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMActFlag.Location = new System.Drawing.Point(15, 24);
            this.lblPMActFlag.Name = "lblPMActFlag";
            this.lblPMActFlag.Size = new System.Drawing.Size(60, 13);
            this.lblPMActFlag.TabIndex = 0;
            this.lblPMActFlag.Text = "Action Flag";
            this.lblPMActFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRASViewPMScheduleDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRASViewPMScheduleDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View PM Schedule - Detail";
            this.Activated += new System.EventHandler(this.frmRASViewPMScheduleDetail_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlCenterTop.ResumeLayout(false);
            this.grpPM.ResumeLayout(false);
            this.grpPM.PerformLayout();
            this.pnlCenterBottom.ResumeLayout(false);
            this.grpPMAct.ResumeLayout(false);
            this.grpPMAct.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag;
        #endregion
        
        #region " Function Definition "
        // View_PM_Schedule()
        //       -  View Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_PM_Schedule()
        {
            TRSNode in_node = new TRSNode("View_PM_Schedule_In");
            TRSNode out_node = new TRSNode("View_PM_Schedule_Out");
            
            try
            {
                MPCF.FieldClear(this, txtResID, txtPMPlanDate, null, null, null, false);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", txtResID.Text);
                in_node.AddString("PM_PLAN_DATE", MPCF.DestroyDateFormat(MPCF.Trim(txtPMPlanDate.Text), DATE_TIME_FORMAT.DATE));

                if (MPCR.CallService("RAS", "RAS_View_PM_Schedule", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                txtPMPeriod.Text = out_node.GetString("PM_PERIOD");
                txtPMPlanUser.Text = out_node.GetString("PM_PLAN_USER_ID");
                txtPMPlanTime.Text = MPCF.MakeDateFormat(out_node.GetString("PM_PLAN_TIME"));
                txtPMEvent.Text = out_node.GetString("PM_EVENT_ID");
                txtPMActFlag.Text = out_node.GetChar("PM_ACT_FLAG").ToString();
                txtPMActUser.Text = out_node.GetString("PM_ACT_USER_ID");
                txtPMActTime.Text = MPCF.MakeDateFormat(out_node.GetString("PM_ACT_TIME"));
                txtPMComment.Text = out_node.GetString("PM_COMMENT");
                txtPMActComment.Text = out_node.GetString("PM_ACT_COMMENT");
                txtPMActHistSeq.Text = out_node.GetInt("PM_ACT_HIST_SEQ").ToString();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Definition "
        
        private void frmRASViewPMScheduleDetail_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;
                if (txtResID.Text != "" && txtPMPlanDate.Text != "")
                {
                    View_PM_Schedule();
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (View_PM_Schedule() == false)
            {
                return;
            }
        }
        
        #endregion
        
    }
    
}
