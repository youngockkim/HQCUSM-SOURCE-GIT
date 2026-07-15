
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

//#If _ALM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmALMTranRaiseAlarm.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - initControl() : initial Controls
//       - CheckCondition : Check the Conditions before Transaction
//       - Raise_Alarm() : Raise Lot Alarm
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-08-10 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.ALMCore
{
    public class frmALMTranRaiseAlarm : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmALMTranRaiseAlarm()
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
        



        private System.Windows.Forms.TextBox txtAlarmMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblAlarmID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtSourceID1;
        private System.Windows.Forms.Label lblSourceID1;
        private System.Windows.Forms.TextBox txtSourceDesc1;
        private System.Windows.Forms.Label lblSourceDesc1;
        private System.Windows.Forms.TextBox txtSourceID2;
        private System.Windows.Forms.Label lblSourceID2;
        private System.Windows.Forms.TextBox txtSourceDesc2;
        private System.Windows.Forms.Label lblSourceDesc2;
        private System.Windows.Forms.TextBox txtSourceID3;
        private System.Windows.Forms.Label lblSourceID3;
        private System.Windows.Forms.TextBox txtSourceDesc3;
        private System.Windows.Forms.Label lblSourceDesc3;
        private TextBox txtAlarmSubject;
        private Label lblSubject;
        private CheckBox chkSetClear;
        private TextBox txtComment5;
        private Label lblComment5;
        private TextBox txtComment4;
        private Label lblComment4;
        private TextBox txtComment3;
        private Label lblComment3;
        private TextBox txtComment2;
        private Label lblComment2;
        private TextBox txtComment1;
        private Label lblComment1;
        private System.Windows.Forms.GroupBox grpAlarmInformation;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpAlarmInformation = new System.Windows.Forms.GroupBox();
            this.txtComment5 = new System.Windows.Forms.TextBox();
            this.lblComment5 = new System.Windows.Forms.Label();
            this.txtComment4 = new System.Windows.Forms.TextBox();
            this.lblComment4 = new System.Windows.Forms.Label();
            this.txtComment3 = new System.Windows.Forms.TextBox();
            this.lblComment3 = new System.Windows.Forms.Label();
            this.txtComment2 = new System.Windows.Forms.TextBox();
            this.lblComment2 = new System.Windows.Forms.Label();
            this.txtComment1 = new System.Windows.Forms.TextBox();
            this.lblComment1 = new System.Windows.Forms.Label();
            this.chkSetClear = new System.Windows.Forms.CheckBox();
            this.txtAlarmSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSourceDesc3 = new System.Windows.Forms.TextBox();
            this.lblSourceDesc3 = new System.Windows.Forms.Label();
            this.txtSourceID3 = new System.Windows.Forms.TextBox();
            this.lblSourceID3 = new System.Windows.Forms.Label();
            this.txtSourceDesc2 = new System.Windows.Forms.TextBox();
            this.lblSourceDesc2 = new System.Windows.Forms.Label();
            this.txtSourceID2 = new System.Windows.Forms.TextBox();
            this.lblSourceID2 = new System.Windows.Forms.Label();
            this.txtSourceDesc1 = new System.Windows.Forms.TextBox();
            this.lblSourceDesc1 = new System.Windows.Forms.Label();
            this.txtSourceID1 = new System.Windows.Forms.TextBox();
            this.lblSourceID1 = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvAlarmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtAlarmMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblAlarmID = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpAlarmInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpAlarmInformation);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Raise Lot Alarm";
            // 
            // grpAlarmInformation
            // 
            this.grpAlarmInformation.Controls.Add(this.txtComment5);
            this.grpAlarmInformation.Controls.Add(this.lblComment5);
            this.grpAlarmInformation.Controls.Add(this.txtComment4);
            this.grpAlarmInformation.Controls.Add(this.lblComment4);
            this.grpAlarmInformation.Controls.Add(this.txtComment3);
            this.grpAlarmInformation.Controls.Add(this.lblComment3);
            this.grpAlarmInformation.Controls.Add(this.txtComment2);
            this.grpAlarmInformation.Controls.Add(this.lblComment2);
            this.grpAlarmInformation.Controls.Add(this.txtComment1);
            this.grpAlarmInformation.Controls.Add(this.lblComment1);
            this.grpAlarmInformation.Controls.Add(this.chkSetClear);
            this.grpAlarmInformation.Controls.Add(this.txtAlarmSubject);
            this.grpAlarmInformation.Controls.Add(this.lblSubject);
            this.grpAlarmInformation.Controls.Add(this.txtSourceDesc3);
            this.grpAlarmInformation.Controls.Add(this.lblSourceDesc3);
            this.grpAlarmInformation.Controls.Add(this.txtSourceID3);
            this.grpAlarmInformation.Controls.Add(this.lblSourceID3);
            this.grpAlarmInformation.Controls.Add(this.txtSourceDesc2);
            this.grpAlarmInformation.Controls.Add(this.lblSourceDesc2);
            this.grpAlarmInformation.Controls.Add(this.txtSourceID2);
            this.grpAlarmInformation.Controls.Add(this.lblSourceID2);
            this.grpAlarmInformation.Controls.Add(this.txtSourceDesc1);
            this.grpAlarmInformation.Controls.Add(this.lblSourceDesc1);
            this.grpAlarmInformation.Controls.Add(this.txtSourceID1);
            this.grpAlarmInformation.Controls.Add(this.lblSourceID1);
            this.grpAlarmInformation.Controls.Add(this.txtLotID);
            this.grpAlarmInformation.Controls.Add(this.lblLotID);
            this.grpAlarmInformation.Controls.Add(this.cdvResID);
            this.grpAlarmInformation.Controls.Add(this.lblResID);
            this.grpAlarmInformation.Controls.Add(this.cdvAlarmID);
            this.grpAlarmInformation.Controls.Add(this.txtAlarmMessage);
            this.grpAlarmInformation.Controls.Add(this.lblMessage);
            this.grpAlarmInformation.Controls.Add(this.lblAlarmID);
            this.grpAlarmInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlarmInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAlarmInformation.Location = new System.Drawing.Point(3, 3);
            this.grpAlarmInformation.Name = "grpAlarmInformation";
            this.grpAlarmInformation.Size = new System.Drawing.Size(736, 507);
            this.grpAlarmInformation.TabIndex = 0;
            this.grpAlarmInformation.TabStop = false;
            this.grpAlarmInformation.Text = "Alarm Information";
            // 
            // txtComment5
            // 
            this.txtComment5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment5.Location = new System.Drawing.Point(119, 469);
            this.txtComment5.MaxLength = 1000;
            this.txtComment5.Name = "txtComment5";
            this.txtComment5.Size = new System.Drawing.Size(608, 20);
            this.txtComment5.TabIndex = 32;
            // 
            // lblComment5
            // 
            this.lblComment5.AutoSize = true;
            this.lblComment5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment5.Location = new System.Drawing.Point(13, 473);
            this.lblComment5.Name = "lblComment5";
            this.lblComment5.Size = new System.Drawing.Size(60, 13);
            this.lblComment5.TabIndex = 31;
            this.lblComment5.Text = "Comment 5";
            this.lblComment5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment4
            // 
            this.txtComment4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment4.Location = new System.Drawing.Point(119, 444);
            this.txtComment4.MaxLength = 1000;
            this.txtComment4.Name = "txtComment4";
            this.txtComment4.Size = new System.Drawing.Size(608, 20);
            this.txtComment4.TabIndex = 30;
            // 
            // lblComment4
            // 
            this.lblComment4.AutoSize = true;
            this.lblComment4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment4.Location = new System.Drawing.Point(13, 448);
            this.lblComment4.Name = "lblComment4";
            this.lblComment4.Size = new System.Drawing.Size(60, 13);
            this.lblComment4.TabIndex = 29;
            this.lblComment4.Text = "Comment 4";
            this.lblComment4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment3
            // 
            this.txtComment3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment3.Location = new System.Drawing.Point(119, 419);
            this.txtComment3.MaxLength = 1000;
            this.txtComment3.Name = "txtComment3";
            this.txtComment3.Size = new System.Drawing.Size(608, 20);
            this.txtComment3.TabIndex = 28;
            // 
            // lblComment3
            // 
            this.lblComment3.AutoSize = true;
            this.lblComment3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment3.Location = new System.Drawing.Point(13, 423);
            this.lblComment3.Name = "lblComment3";
            this.lblComment3.Size = new System.Drawing.Size(60, 13);
            this.lblComment3.TabIndex = 27;
            this.lblComment3.Text = "Comment 3";
            this.lblComment3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment2
            // 
            this.txtComment2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment2.Location = new System.Drawing.Point(119, 394);
            this.txtComment2.MaxLength = 1000;
            this.txtComment2.Name = "txtComment2";
            this.txtComment2.Size = new System.Drawing.Size(608, 20);
            this.txtComment2.TabIndex = 26;
            // 
            // lblComment2
            // 
            this.lblComment2.AutoSize = true;
            this.lblComment2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment2.Location = new System.Drawing.Point(13, 398);
            this.lblComment2.Name = "lblComment2";
            this.lblComment2.Size = new System.Drawing.Size(60, 13);
            this.lblComment2.TabIndex = 25;
            this.lblComment2.Text = "Comment 2";
            this.lblComment2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment1
            // 
            this.txtComment1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment1.Location = new System.Drawing.Point(119, 369);
            this.txtComment1.MaxLength = 1000;
            this.txtComment1.Name = "txtComment1";
            this.txtComment1.Size = new System.Drawing.Size(608, 20);
            this.txtComment1.TabIndex = 24;
            // 
            // lblComment1
            // 
            this.lblComment1.AutoSize = true;
            this.lblComment1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment1.Location = new System.Drawing.Point(13, 373);
            this.lblComment1.Name = "lblComment1";
            this.lblComment1.Size = new System.Drawing.Size(60, 13);
            this.lblComment1.TabIndex = 23;
            this.lblComment1.Text = "Comment 1";
            this.lblComment1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSetClear
            // 
            this.chkSetClear.AutoSize = true;
            this.chkSetClear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSetClear.Enabled = false;
            this.chkSetClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSetClear.Location = new System.Drawing.Point(373, 17);
            this.chkSetClear.Name = "chkSetClear";
            this.chkSetClear.Size = new System.Drawing.Size(98, 18);
            this.chkSetClear.TabIndex = 2;
            this.chkSetClear.Text = "Set Clear Flag";
            // 
            // txtAlarmSubject
            // 
            this.txtAlarmSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlarmSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarmSubject.Location = new System.Drawing.Point(119, 239);
            this.txtAlarmSubject.MaxLength = 200;
            this.txtAlarmSubject.Name = "txtAlarmSubject";
            this.txtAlarmSubject.Size = new System.Drawing.Size(608, 20);
            this.txtAlarmSubject.TabIndex = 20;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(13, 243);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(72, 13);
            this.lblSubject.TabIndex = 19;
            this.lblSubject.Text = "Alarm Subject";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceDesc3
            // 
            this.txtSourceDesc3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDesc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDesc3.Location = new System.Drawing.Point(119, 215);
            this.txtSourceDesc3.MaxLength = 200;
            this.txtSourceDesc3.Name = "txtSourceDesc3";
            this.txtSourceDesc3.Size = new System.Drawing.Size(250, 20);
            this.txtSourceDesc3.TabIndex = 18;
            // 
            // lblSourceDesc3
            // 
            this.lblSourceDesc3.AutoSize = true;
            this.lblSourceDesc3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceDesc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDesc3.Location = new System.Drawing.Point(13, 219);
            this.lblSourceDesc3.Name = "lblSourceDesc3";
            this.lblSourceDesc3.Size = new System.Drawing.Size(78, 13);
            this.lblSourceDesc3.TabIndex = 17;
            this.lblSourceDesc3.Text = "Source Desc 3";
            this.lblSourceDesc3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceID3
            // 
            this.txtSourceID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceID3.Location = new System.Drawing.Point(119, 190);
            this.txtSourceID3.MaxLength = 30;
            this.txtSourceID3.Name = "txtSourceID3";
            this.txtSourceID3.Size = new System.Drawing.Size(200, 20);
            this.txtSourceID3.TabIndex = 16;
            // 
            // lblSourceID3
            // 
            this.lblSourceID3.AutoSize = true;
            this.lblSourceID3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceID3.Location = new System.Drawing.Point(13, 194);
            this.lblSourceID3.Name = "lblSourceID3";
            this.lblSourceID3.Size = new System.Drawing.Size(64, 13);
            this.lblSourceID3.TabIndex = 15;
            this.lblSourceID3.Text = "Source ID 3";
            this.lblSourceID3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceDesc2
            // 
            this.txtSourceDesc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDesc2.Location = new System.Drawing.Point(119, 165);
            this.txtSourceDesc2.MaxLength = 200;
            this.txtSourceDesc2.Name = "txtSourceDesc2";
            this.txtSourceDesc2.Size = new System.Drawing.Size(250, 20);
            this.txtSourceDesc2.TabIndex = 14;
            // 
            // lblSourceDesc2
            // 
            this.lblSourceDesc2.AutoSize = true;
            this.lblSourceDesc2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDesc2.Location = new System.Drawing.Point(13, 169);
            this.lblSourceDesc2.Name = "lblSourceDesc2";
            this.lblSourceDesc2.Size = new System.Drawing.Size(78, 13);
            this.lblSourceDesc2.TabIndex = 13;
            this.lblSourceDesc2.Text = "Source Desc 2";
            this.lblSourceDesc2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceID2
            // 
            this.txtSourceID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceID2.Location = new System.Drawing.Point(119, 140);
            this.txtSourceID2.MaxLength = 30;
            this.txtSourceID2.Name = "txtSourceID2";
            this.txtSourceID2.Size = new System.Drawing.Size(200, 20);
            this.txtSourceID2.TabIndex = 12;
            // 
            // lblSourceID2
            // 
            this.lblSourceID2.AutoSize = true;
            this.lblSourceID2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceID2.Location = new System.Drawing.Point(13, 144);
            this.lblSourceID2.Name = "lblSourceID2";
            this.lblSourceID2.Size = new System.Drawing.Size(64, 13);
            this.lblSourceID2.TabIndex = 11;
            this.lblSourceID2.Text = "Source ID 2";
            this.lblSourceID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceDesc1
            // 
            this.txtSourceDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDesc1.Location = new System.Drawing.Point(119, 115);
            this.txtSourceDesc1.MaxLength = 200;
            this.txtSourceDesc1.Name = "txtSourceDesc1";
            this.txtSourceDesc1.Size = new System.Drawing.Size(250, 20);
            this.txtSourceDesc1.TabIndex = 10;
            // 
            // lblSourceDesc1
            // 
            this.lblSourceDesc1.AutoSize = true;
            this.lblSourceDesc1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDesc1.Location = new System.Drawing.Point(13, 119);
            this.lblSourceDesc1.Name = "lblSourceDesc1";
            this.lblSourceDesc1.Size = new System.Drawing.Size(78, 13);
            this.lblSourceDesc1.TabIndex = 9;
            this.lblSourceDesc1.Text = "Source Desc 1";
            this.lblSourceDesc1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceID1
            // 
            this.txtSourceID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceID1.Location = new System.Drawing.Point(119, 90);
            this.txtSourceID1.MaxLength = 30;
            this.txtSourceID1.Name = "txtSourceID1";
            this.txtSourceID1.Size = new System.Drawing.Size(200, 20);
            this.txtSourceID1.TabIndex = 8;
            // 
            // lblSourceID1
            // 
            this.lblSourceID1.AutoSize = true;
            this.lblSourceID1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceID1.Location = new System.Drawing.Point(13, 94);
            this.lblSourceID1.Name = "lblSourceID1";
            this.lblSourceID1.Size = new System.Drawing.Size(75, 13);
            this.lblSourceID1.TabIndex = 7;
            this.lblSourceID1.Text = "Source ID 1";
            this.lblSourceID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.Location = new System.Drawing.Point(119, 40);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 4;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(13, 44);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 3;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(119, 65);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 6;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(13, 69);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 5;
            this.lblResID.Text = "Resource ID";
            // 
            // cdvAlarmID
            // 
            this.cdvAlarmID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmID.BtnToolTipText = "";
            this.cdvAlarmID.DescText = "";
            this.cdvAlarmID.DisplaySubItemIndex = -1;
            this.cdvAlarmID.DisplayText = "";
            this.cdvAlarmID.Focusing = null;
            this.cdvAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmID.Index = 0;
            this.cdvAlarmID.IsViewBtnImage = false;
            this.cdvAlarmID.Location = new System.Drawing.Point(119, 15);
            this.cdvAlarmID.MaxLength = 20;
            this.cdvAlarmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmID.Name = "cdvAlarmID";
            this.cdvAlarmID.ReadOnly = false;
            this.cdvAlarmID.SearchSubItemIndex = 0;
            this.cdvAlarmID.SelectedDescIndex = -1;
            this.cdvAlarmID.SelectedSubItemIndex = -1;
            this.cdvAlarmID.SelectionStart = 0;
            this.cdvAlarmID.Size = new System.Drawing.Size(200, 20);
            this.cdvAlarmID.SmallImageList = null;
            this.cdvAlarmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmID.TabIndex = 1;
            this.cdvAlarmID.TextBoxToolTipText = "";
            this.cdvAlarmID.TextBoxWidth = 200;
            this.cdvAlarmID.VisibleButton = true;
            this.cdvAlarmID.VisibleColumnHeader = false;
            this.cdvAlarmID.VisibleDescription = false;
            this.cdvAlarmID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAlarmID_SelectedItemChanged);
            this.cdvAlarmID.ButtonPress += new System.EventHandler(this.cdvAlarmID_ButtonPress);
            // 
            // txtAlarmMessage
            // 
            this.txtAlarmMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlarmMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarmMessage.Location = new System.Drawing.Point(119, 264);
            this.txtAlarmMessage.MaxLength = 1000;
            this.txtAlarmMessage.Multiline = true;
            this.txtAlarmMessage.Name = "txtAlarmMessage";
            this.txtAlarmMessage.Size = new System.Drawing.Size(608, 100);
            this.txtAlarmMessage.TabIndex = 22;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(13, 268);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(79, 13);
            this.lblMessage.TabIndex = 21;
            this.lblMessage.Text = "Alarm Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(15, 19);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(55, 13);
            this.lblAlarmID.TabIndex = 0;
            this.lblAlarmID.Text = "Alarm ID";
            this.lblAlarmID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmALMTranRaiseAlarm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmALMTranRaiseAlarm";
            this.Text = "Raise Alarm";
            this.Activated += new System.EventHandler(this.frmALMTranRaiseAlarm_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpAlarmInformation.ResumeLayout(false);
            this.grpAlarmInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvAlarmID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(txtSourceID1, 1) == false)
            {
                return false;
            }

            return true;
        }

        //
        // ViewAlarmMsg
        //       - View Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewAlarmMsg()
        {
            TRSNode in_node = new TRSNode("VIEW_ALARM_MSG_IN");
            TRSNode out_node = new TRSNode("VIEW_ALARM_MSG_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ALARM_ID", cdvAlarmID.Text);


            if (MPCR.CallService("ALM", "ALM_View_Alarm_Msg", in_node, ref out_node) == false)
            {                
                return false;
            }

            txtAlarmSubject.Text = out_node.GetString("ALARM_SUBJECT");
            switch (in_node.Language)
            {
                case '1':
                    txtAlarmMessage.Text = out_node.GetString("ALARM_MSG_1");
                    break;
                case '2':
                    txtAlarmMessage.Text = out_node.GetString("ALARM_MSG_2");
                    break;
                case '3':
                    txtAlarmMessage.Text = out_node.GetString("ALARM_MSG_3");
                    break;
            }

            txtComment1.Text = out_node.GetString("ALARM_COMMENT_1");
            txtComment2.Text = out_node.GetString("ALARM_COMMENT_2");
            txtComment3.Text = out_node.GetString("ALARM_COMMENT_3");
            txtComment4.Text = out_node.GetString("ALARM_COMMENT_4");
            txtComment5.Text = out_node.GetString("ALARM_COMMENT_5");

            return true;
        }
        
        // Raise_Alarm()
        //       -   Raise Lot Alarm
        // Return Value
        //       -
        // Arguments
        //       -
        private bool Raise_Alarm()
        {
            TRSNode in_node = new TRSNode("RAISE_ALARM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ALARM_ID", MPCF.Trim(cdvAlarmID.Text));
                in_node.AddString("ALARM_MSG", MPCF.Trim(txtAlarmMessage.Text));
                in_node.AddString("ALARM_SUBJECT", MPCF.Trim(txtAlarmSubject.Text));

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddChar("SET_CLEAR_FLAG", chkSetClear.Checked == true ? 'Y' : ' ');

                in_node.AddString("SOURCE_ID_1", MPCF.Trim(txtSourceID1.Text));
                in_node.AddString("SOURCE_DESC_1", MPCF.Trim(txtSourceDesc1.Text));
                in_node.AddString("SOURCE_ID_2", MPCF.Trim(txtSourceID2.Text));
                in_node.AddString("SOURCE_DESC_2", MPCF.Trim(txtSourceDesc2.Text));
                in_node.AddString("SOURCE_ID_3", MPCF.Trim(txtSourceID3.Text));
                in_node.AddString("SOURCE_DESC_3", MPCF.Trim(txtSourceDesc3.Text));

                in_node.AddString("ALARM_COMMENT_1", MPCF.Trim(txtComment1.Text));
                in_node.AddString("ALARM_COMMENT_2", MPCF.Trim(txtComment2.Text));
                in_node.AddString("ALARM_COMMENT_3", MPCF.Trim(txtComment3.Text));
                in_node.AddString("ALARM_COMMENT_4", MPCF.Trim(txtComment4.Text));
                in_node.AddString("ALARM_COMMENT_5", MPCF.Trim(txtComment5.Text));

                if (MPCR.CallService("ALM", "ALM_Raise_Alarm", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
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
                return this.cdvAlarmID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmALMTranRaiseAlarm_Activated(object sender, System.EventArgs e)
        {            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                b_load_flag = true;
            }            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {            
            if (CheckCondition() == false)
            {
                return;
            }

            Raise_Alarm();
        }
        
        private void cdvAlarmID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewAlarmMsg();
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            #if _RAS
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
            #endif
        }
        
        private void cdvAlarmID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm", 150, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Message", 200, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', ' ');
        }

        private void cdvResID_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvResID.Text) == "")
            {
                chkSetClear.Checked = false;
                chkSetClear.Enabled = false;
            }
            else
            {
                chkSetClear.Enabled = true;
            }
        }
    }
    //#End If
}
