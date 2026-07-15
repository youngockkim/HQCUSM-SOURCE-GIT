namespace Miracom.MESCore
{
    partial class frmMDIMainCore
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIMainCore));
            this.imlSmallIcon = new System.Windows.Forms.ImageList(this.components);
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.tmrMsg = new System.Windows.Forms.Timer(this.components);
            this.tmrTimeStatus = new System.Windows.Forms.Timer(this.components);
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.tmrLogOutTime = new System.Windows.Forms.Timer(this.components);
            this.tmrSuccess = new System.Windows.Forms.Timer(this.components);
            this.MDIMainStatusBar = new System.Windows.Forms.StatusBar();
            this.stsMDIMainPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.stsMDIMainPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.stsMDIMainPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.stsMDIMainPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.stsMDIMainPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.stsMDIMainPanel6 = new System.Windows.Forms.StatusBarPanel();
            this.pgbMain = new System.Windows.Forms.ProgressBar();
            this.pnlAlarm = new System.Windows.Forms.Panel();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.pbxAlarm = new System.Windows.Forms.PictureBox();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbxMessage = new System.Windows.Forms.PictureBox();
            this.imlToolBar = new System.Windows.Forms.ImageList(this.components);
            this.ttpMain = new System.Windows.Forms.ToolTip(this.components);
            this.tmrCheckVersion = new System.Windows.Forms.Timer(this.components);
            this.tmrBBSMsg = new System.Windows.Forms.Timer(this.components);
            this.pnlBBSMessage = new System.Windows.Forms.Panel();
            this.lblBBSMessage = new System.Windows.Forms.Label();
            this.pbxBBSMessage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel6)).BeginInit();
            this.pnlAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlarm)).BeginInit();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).BeginInit();
            this.pnlBBSMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBBSMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // imlSmallIcon
            // 
            this.imlSmallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallIcon.ImageStream")));
            this.imlSmallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmallIcon.Images.SetKeyName(0, "");
            this.imlSmallIcon.Images.SetKeyName(1, "");
            this.imlSmallIcon.Images.SetKeyName(2, "");
            this.imlSmallIcon.Images.SetKeyName(3, "");
            this.imlSmallIcon.Images.SetKeyName(4, "");
            this.imlSmallIcon.Images.SetKeyName(5, "");
            this.imlSmallIcon.Images.SetKeyName(6, "");
            this.imlSmallIcon.Images.SetKeyName(7, "");
            this.imlSmallIcon.Images.SetKeyName(8, "");
            this.imlSmallIcon.Images.SetKeyName(9, "");
            this.imlSmallIcon.Images.SetKeyName(10, "");
            this.imlSmallIcon.Images.SetKeyName(11, "");
            this.imlSmallIcon.Images.SetKeyName(12, "");
            this.imlSmallIcon.Images.SetKeyName(13, "");
            this.imlSmallIcon.Images.SetKeyName(14, "");
            this.imlSmallIcon.Images.SetKeyName(15, "");
            this.imlSmallIcon.Images.SetKeyName(16, "");
            this.imlSmallIcon.Images.SetKeyName(17, "");
            this.imlSmallIcon.Images.SetKeyName(18, "");
            this.imlSmallIcon.Images.SetKeyName(19, "");
            this.imlSmallIcon.Images.SetKeyName(20, "");
            this.imlSmallIcon.Images.SetKeyName(21, "");
            this.imlSmallIcon.Images.SetKeyName(22, "");
            this.imlSmallIcon.Images.SetKeyName(23, "");
            this.imlSmallIcon.Images.SetKeyName(24, "");
            this.imlSmallIcon.Images.SetKeyName(25, "");
            this.imlSmallIcon.Images.SetKeyName(26, "");
            this.imlSmallIcon.Images.SetKeyName(27, "");
            this.imlSmallIcon.Images.SetKeyName(28, "");
            this.imlSmallIcon.Images.SetKeyName(29, "");
            this.imlSmallIcon.Images.SetKeyName(30, "");
            this.imlSmallIcon.Images.SetKeyName(31, "");
            this.imlSmallIcon.Images.SetKeyName(32, "");
            this.imlSmallIcon.Images.SetKeyName(33, "");
            this.imlSmallIcon.Images.SetKeyName(34, "");
            this.imlSmallIcon.Images.SetKeyName(35, "");
            this.imlSmallIcon.Images.SetKeyName(36, "");
            this.imlSmallIcon.Images.SetKeyName(37, "");
            this.imlSmallIcon.Images.SetKeyName(38, "");
            this.imlSmallIcon.Images.SetKeyName(39, "");
            this.imlSmallIcon.Images.SetKeyName(40, "");
            this.imlSmallIcon.Images.SetKeyName(41, "");
            this.imlSmallIcon.Images.SetKeyName(42, "");
            this.imlSmallIcon.Images.SetKeyName(43, "");
            this.imlSmallIcon.Images.SetKeyName(44, "");
            this.imlSmallIcon.Images.SetKeyName(45, "");
            this.imlSmallIcon.Images.SetKeyName(46, "");
            this.imlSmallIcon.Images.SetKeyName(47, "");
            this.imlSmallIcon.Images.SetKeyName(48, "");
            this.imlSmallIcon.Images.SetKeyName(49, "");
            this.imlSmallIcon.Images.SetKeyName(50, "");
            this.imlSmallIcon.Images.SetKeyName(51, "");
            this.imlSmallIcon.Images.SetKeyName(52, "");
            this.imlSmallIcon.Images.SetKeyName(53, "");
            this.imlSmallIcon.Images.SetKeyName(54, "");
            this.imlSmallIcon.Images.SetKeyName(55, "");
            this.imlSmallIcon.Images.SetKeyName(56, "");
            this.imlSmallIcon.Images.SetKeyName(57, "");
            this.imlSmallIcon.Images.SetKeyName(58, "");
            this.imlSmallIcon.Images.SetKeyName(59, "");
            this.imlSmallIcon.Images.SetKeyName(60, "");
            this.imlSmallIcon.Images.SetKeyName(61, "");
            this.imlSmallIcon.Images.SetKeyName(62, "");
            this.imlSmallIcon.Images.SetKeyName(63, "");
            this.imlSmallIcon.Images.SetKeyName(64, "");
            this.imlSmallIcon.Images.SetKeyName(65, "");
            this.imlSmallIcon.Images.SetKeyName(66, "");
            this.imlSmallIcon.Images.SetKeyName(67, "");
            this.imlSmallIcon.Images.SetKeyName(68, "");
            this.imlSmallIcon.Images.SetKeyName(69, "");
            this.imlSmallIcon.Images.SetKeyName(70, "");
            this.imlSmallIcon.Images.SetKeyName(71, "");
            this.imlSmallIcon.Images.SetKeyName(72, "");
            this.imlSmallIcon.Images.SetKeyName(73, "");
            this.imlSmallIcon.Images.SetKeyName(74, "");
            this.imlSmallIcon.Images.SetKeyName(75, "");
            this.imlSmallIcon.Images.SetKeyName(76, "");
            this.imlSmallIcon.Images.SetKeyName(77, "");
            this.imlSmallIcon.Images.SetKeyName(78, "");
            this.imlSmallIcon.Images.SetKeyName(79, "");
            this.imlSmallIcon.Images.SetKeyName(80, "");
            this.imlSmallIcon.Images.SetKeyName(81, "");
            this.imlSmallIcon.Images.SetKeyName(82, "");
            this.imlSmallIcon.Images.SetKeyName(83, "");
            this.imlSmallIcon.Images.SetKeyName(84, "");
            this.imlSmallIcon.Images.SetKeyName(85, "");
            this.imlSmallIcon.Images.SetKeyName(86, "");
            this.imlSmallIcon.Images.SetKeyName(87, "");
            this.imlSmallIcon.Images.SetKeyName(88, "");
            this.imlSmallIcon.Images.SetKeyName(89, "");
            this.imlSmallIcon.Images.SetKeyName(90, "");
            this.imlSmallIcon.Images.SetKeyName(91, "");
            this.imlSmallIcon.Images.SetKeyName(92, "");
            this.imlSmallIcon.Images.SetKeyName(93, "");
            this.imlSmallIcon.Images.SetKeyName(94, "");
            this.imlSmallIcon.Images.SetKeyName(95, "");
            this.imlSmallIcon.Images.SetKeyName(96, "");
            this.imlSmallIcon.Images.SetKeyName(97, "");
            this.imlSmallIcon.Images.SetKeyName(98, "");
            this.imlSmallIcon.Images.SetKeyName(99, "");
            this.imlSmallIcon.Images.SetKeyName(100, "");
            this.imlSmallIcon.Images.SetKeyName(101, "");
            this.imlSmallIcon.Images.SetKeyName(102, "");
            this.imlSmallIcon.Images.SetKeyName(103, "");
            this.imlSmallIcon.Images.SetKeyName(104, "White Image");
            this.imlSmallIcon.Images.SetKeyName(105, "");
            this.imlSmallIcon.Images.SetKeyName(106, "Subequip9.ico");
            this.imlSmallIcon.Images.SetKeyName(107, "Port_down.ico");
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Enabled = true;
            this.tmrAlarm.Interval = 1000;
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrAlarm_Tick);
            // 
            // tmrMsg
            // 
            this.tmrMsg.Enabled = true;
            this.tmrMsg.Interval = 1000;
            this.tmrMsg.Tick += new System.EventHandler(this.tmrMsg_Tick);
            // 
            // tmrTimeStatus
            // 
            this.tmrTimeStatus.Enabled = true;
            this.tmrTimeStatus.Interval = 1000;
            this.tmrTimeStatus.Tick += new System.EventHandler(this.tmrTimeStatus_Tick);
            // 
            // tmrProgress
            // 
            this.tmrProgress.Enabled = true;
            this.tmrProgress.Interval = 50;
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // tmrLogOutTime
            // 
            this.tmrLogOutTime.Enabled = true;
            this.tmrLogOutTime.Interval = 60000;
            this.tmrLogOutTime.Tick += new System.EventHandler(this.tmrLogOutTime_Tick);
            // 
            // tmrSuccess
            // 
            this.tmrSuccess.Enabled = true;
            this.tmrSuccess.Interval = 3000;
            this.tmrSuccess.Tick += new System.EventHandler(this.tmrSuccess_Tick);
            // 
            // MDIMainStatusBar
            // 
            this.MDIMainStatusBar.Enabled = false;
            this.MDIMainStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDIMainStatusBar.Location = new System.Drawing.Point(0, 373);
            this.MDIMainStatusBar.Name = "MDIMainStatusBar";
            this.MDIMainStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.stsMDIMainPanel1,
            this.stsMDIMainPanel2,
            this.stsMDIMainPanel3,
            this.stsMDIMainPanel4,
            this.stsMDIMainPanel5,
            this.stsMDIMainPanel6});
            this.MDIMainStatusBar.ShowPanels = true;
            this.MDIMainStatusBar.Size = new System.Drawing.Size(576, 20);
            this.MDIMainStatusBar.TabIndex = 3;
            this.MDIMainStatusBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.MDIMainStatusBar_DrawItem);
            // 
            // stsMDIMainPanel1
            // 
            this.stsMDIMainPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.stsMDIMainPanel1.Name = "stsMDIMainPanel1";
            this.stsMDIMainPanel1.Width = 150;
            // 
            // stsMDIMainPanel2
            // 
            this.stsMDIMainPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.stsMDIMainPanel2.Name = "stsMDIMainPanel2";
            this.stsMDIMainPanel2.Text = "Communication Status...";
            this.stsMDIMainPanel2.Width = 97;
            // 
            // stsMDIMainPanel3
            // 
            this.stsMDIMainPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.stsMDIMainPanel3.Name = "stsMDIMainPanel3";
            this.stsMDIMainPanel3.Text = "Site ID:              ";
            this.stsMDIMainPanel3.Width = 51;
            // 
            // stsMDIMainPanel4
            // 
            this.stsMDIMainPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.stsMDIMainPanel4.Name = "stsMDIMainPanel4";
            this.stsMDIMainPanel4.Text = "Factory:";
            this.stsMDIMainPanel4.Width = 55;
            // 
            // stsMDIMainPanel5
            // 
            this.stsMDIMainPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.stsMDIMainPanel5.Name = "stsMDIMainPanel5";
            this.stsMDIMainPanel5.Text = "User ID:";
            this.stsMDIMainPanel5.Width = 56;
            // 
            // stsMDIMainPanel6
            // 
            this.stsMDIMainPanel6.Name = "stsMDIMainPanel6";
            this.stsMDIMainPanel6.Width = 150;
            // 
            // pgbMain
            // 
            this.pgbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgbMain.Location = new System.Drawing.Point(2, 378);
            this.pgbMain.Name = "pgbMain";
            this.pgbMain.Size = new System.Drawing.Size(148, 12);
            this.pgbMain.TabIndex = 4;
            // 
            // pnlAlarm
            // 
            this.pnlAlarm.BackColor = System.Drawing.Color.White;
            this.pnlAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlarm.Controls.Add(this.lblAlarm);
            this.pnlAlarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlarm.Location = new System.Drawing.Point(0, 373);
            this.pnlAlarm.Name = "pnlAlarm";
            this.pnlAlarm.Size = new System.Drawing.Size(576, 0);
            this.pnlAlarm.TabIndex = 6;
            this.pnlAlarm.Visible = false;
            this.pnlAlarm.Click += new System.EventHandler(this.pnlAlarm_Click);
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.BackColor = System.Drawing.Color.PaleGreen;
            this.lblAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm.Location = new System.Drawing.Point(25, 0);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(0, 13);
            this.lblAlarm.TabIndex = 0;
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlarm.Click += new System.EventHandler(this.lblAlarm_Click);
            // 
            // pbxAlarm
            // 
            this.pbxAlarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbxAlarm.Image = ((System.Drawing.Image)(resources.GetObject("pbxAlarm.Image")));
            this.pbxAlarm.Location = new System.Drawing.Point(0, 0);
            this.pbxAlarm.Name = "pbxAlarm";
            this.pbxAlarm.Size = new System.Drawing.Size(25, 0);
            this.pbxAlarm.TabIndex = 1;
            this.pbxAlarm.TabStop = false;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.White;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.pbxMessage);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Location = new System.Drawing.Point(0, 373);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(576, 0);
            this.pnlMessage.TabIndex = 7;
            this.pnlMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(25, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(549, 0);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // pbxMessage
            // 
            this.pbxMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbxMessage.Image = ((System.Drawing.Image)(resources.GetObject("pbxMessage.Image")));
            this.pbxMessage.Location = new System.Drawing.Point(0, 0);
            this.pbxMessage.Name = "pbxMessage";
            this.pbxMessage.Size = new System.Drawing.Size(25, 0);
            this.pbxMessage.TabIndex = 1;
            this.pbxMessage.TabStop = false;
            // 
            // imlToolBar
            // 
            this.imlToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolBar.ImageStream")));
            this.imlToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imlToolBar.Images.SetKeyName(0, "0_Factory_Setup.ico");
            this.imlToolBar.Images.SetKeyName(1, "1_Material_Setup.ico");
            this.imlToolBar.Images.SetKeyName(2, "2_Flow_Setup.ico");
            this.imlToolBar.Images.SetKeyName(3, "3_Operation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(4, "4_Rework_Flow_Setup.ico");
            this.imlToolBar.Images.SetKeyName(5, "5_Cycle_Time_Setup.ico");
            this.imlToolBar.Images.SetKeyName(6, "6_Calendar_Setup_Detail.ico");
            this.imlToolBar.Images.SetKeyName(7, "");
            this.imlToolBar.Images.SetKeyName(8, "8_Create_Lot.ico");
            this.imlToolBar.Images.SetKeyName(9, "9_Start_Lot.ico");
            this.imlToolBar.Images.SetKeyName(10, "10_Multi_Start_Lot.ico");
            this.imlToolBar.Images.SetKeyName(11, "11_End_Lot.ico");
            this.imlToolBar.Images.SetKeyName(12, "12_Multi_End_Lot.ico");
            this.imlToolBar.Images.SetKeyName(13, "13_Move_Lot.ico");
            this.imlToolBar.Images.SetKeyName(14, "14_Rework_Lot.ico");
            this.imlToolBar.Images.SetKeyName(15, "15_Split_Lot.ico");
            this.imlToolBar.Images.SetKeyName(16, "16_Merge_Lot.ico");
            this.imlToolBar.Images.SetKeyName(17, "17_Skip_Lot.ico");
            this.imlToolBar.Images.SetKeyName(18, "18_Combine_Lot.ico");
            this.imlToolBar.Images.SetKeyName(19, "19_Hold_Lot.ico");
            this.imlToolBar.Images.SetKeyName(20, "20_Release_By_force.ico");
            this.imlToolBar.Images.SetKeyName(21, "21_Ship_Lot.ico");
            this.imlToolBar.Images.SetKeyName(22, "22_Receive_Lot.ico");
            this.imlToolBar.Images.SetKeyName(23, "23_Adapt_Lot.ico");
            this.imlToolBar.Images.SetKeyName(24, "24_Loss_Lot.ico");
            this.imlToolBar.Images.SetKeyName(25, "25_Bonus_Lot.ico");
            this.imlToolBar.Images.SetKeyName(26, "");
            this.imlToolBar.Images.SetKeyName(27, "27_Delete_Lot_History.ico");
            this.imlToolBar.Images.SetKeyName(28, "28_Resource_Setup.ico");
            this.imlToolBar.Images.SetKeyName(29, "29_Event_Setup.ico");
            this.imlToolBar.Images.SetKeyName(30, "30_Resource_Event.ico");
            this.imlToolBar.Images.SetKeyName(31, "");
            this.imlToolBar.Images.SetKeyName(32, "");
            this.imlToolBar.Images.SetKeyName(33, "");
            this.imlToolBar.Images.SetKeyName(34, "");
            this.imlToolBar.Images.SetKeyName(35, "");
            this.imlToolBar.Images.SetKeyName(36, "");
            this.imlToolBar.Images.SetKeyName(37, "37_General_Code_Data_Setup.ico");
            this.imlToolBar.Images.SetKeyName(38, "38_Message_Setup.ico");
            this.imlToolBar.Images.SetKeyName(39, "39_User_Setup.ico");
            this.imlToolBar.Images.SetKeyName(40, "40_Security_Group_Setup.ico");
            this.imlToolBar.Images.SetKeyName(41, "41_Assign_Function_to_Security_Group.ico");
            this.imlToolBar.Images.SetKeyName(42, "42_Function_Setup.ico");
            this.imlToolBar.Images.SetKeyName(43, "43_Privilege_Group_Setup.ico");
            this.imlToolBar.Images.SetKeyName(44, "44_Privilege_Definition_Setup.ico");
            this.imlToolBar.Images.SetKeyName(45, "45_Privilege_Group-User_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(46, "46_General_Code_Table_Setup.ico");
            this.imlToolBar.Images.SetKeyName(47, "47_Port_Setup.ico");
            this.imlToolBar.Images.SetKeyName(48, "48_Repair_Operation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(49, "49_SubLot_Option_Setup.ico");
            this.imlToolBar.Images.SetKeyName(50, "50_MFO_Option_Setup.ico");
            this.imlToolBar.Images.SetKeyName(51, "51_Resource_Group_Setup.ico");
            this.imlToolBar.Images.SetKeyName(52, "52_Resource_Resource_Group_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(53, "53_Resource_Event_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(54, "54_Resource_Labor_Setup.ico");
            this.imlToolBar.Images.SetKeyName(55, "55_Sub_Resource_Setup.ico");
            this.imlToolBar.Images.SetKeyName(56, "56_PM_Security_Setup.ico");
            this.imlToolBar.Images.SetKeyName(57, "57_PM_Schedule_Setup.ico");
            this.imlToolBar.Images.SetKeyName(58, "58_Check_Query_Setup.ico");
            this.imlToolBar.Images.SetKeyName(59, "59_Attach_Query_to_Check_List.ico");
            this.imlToolBar.Images.SetKeyName(60, "60_Check_Type_Definitionroup.ico");
            this.imlToolBar.Images.SetKeyName(61, "61_Carrier_Setup.ico");
            this.imlToolBar.Images.SetKeyName(62, "62_Carrier_Group_Setup.ico");
            this.imlToolBar.Images.SetKeyName(63, "63_Carrier_Event_Setup.ico");
            this.imlToolBar.Images.SetKeyName(64, "64_Tool_Type_Setup.ico");
            this.imlToolBar.Images.SetKeyName(65, "65_Tool_Event_Setup.ico");
            this.imlToolBar.Images.SetKeyName(66, "66_Tool_Setup.ico");
            this.imlToolBar.Images.SetKeyName(67, "67_Tool_Event_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(68, "68_Delete_Tool_History.ico");
            this.imlToolBar.Images.SetKeyName(69, "69_Repair_Lot.ico");
            this.imlToolBar.Images.SetKeyName(70, "70_Repair_End_Lot.ico");
            this.imlToolBar.Images.SetKeyName(71, "71_Local_Repair_Lot.ico");
            this.imlToolBar.Images.SetKeyName(72, "72_Store_Lot.ico");
            this.imlToolBar.Images.SetKeyName(73, "73_Un_store_Lot.ico");
            this.imlToolBar.Images.SetKeyName(74, "74_Open_Return_Lot.ico");
            this.imlToolBar.Images.SetKeyName(75, "75_Close_Return_Lot.ico");
            this.imlToolBar.Images.SetKeyName(76, "76_Make_Batch.ico");
            this.imlToolBar.Images.SetKeyName(77, "77_Release_Batch.ico");
            this.imlToolBar.Images.SetKeyName(78, "78_Start_Batch.ico");
            this.imlToolBar.Images.SetKeyName(79, "79_End_Batch.ico");
            this.imlToolBar.Images.SetKeyName(80, "80_Collect_Lot_Defect.ico");
            this.imlToolBar.Images.SetKeyName(81, "81_Clean_Lot_Defect.ico");
            this.imlToolBar.Images.SetKeyName(82, "82_Terminate_Lot.ico");
            this.imlToolBar.Images.SetKeyName(83, "83_Multi_Terminate_Lot.ico");
            this.imlToolBar.Images.SetKeyName(84, "84_Reserve_Lot.ico");
            this.imlToolBar.Images.SetKeyName(85, "85_Unreserve_Lot.ico");
            this.imlToolBar.Images.SetKeyName(86, "86_Make_SubLot_Batch.ico");
            this.imlToolBar.Images.SetKeyName(87, "87_Reserve_Lot_Batch.ico");
            this.imlToolBar.Images.SetKeyName(88, "88_Reserve_SubLot_Batch.ico");
            this.imlToolBar.Images.SetKeyName(89, "89_Sub_Resource_Event.ico");
            this.imlToolBar.Images.SetKeyName(90, "90_Delete_Resource_History.ico");
            this.imlToolBar.Images.SetKeyName(91, "91_Delete_Sub_Resource_History.ico");
            this.imlToolBar.Images.SetKeyName(92, "92_Clean_Carrier.ico");
            this.imlToolBar.Images.SetKeyName(93, "93_Attach_Lot_to_Carrier.ico");
            this.imlToolBar.Images.SetKeyName(94, "94_Attach_Carrier_to_Lot.ico");
            this.imlToolBar.Images.SetKeyName(95, "95_Assign_Sublot_to_Carrier.ico");
            this.imlToolBar.Images.SetKeyName(96, "96_Carrier_Change_Exchange.ico");
            this.imlToolBar.Images.SetKeyName(97, "97_Carrier_Event.ico");
            this.imlToolBar.Images.SetKeyName(98, "98_Tool_Event.ico");
            this.imlToolBar.Images.SetKeyName(99, "99_Docking_Window_Modeler.ico");
            this.imlToolBar.Images.SetKeyName(100, "100_Docking_ Window_Favorities.ico");
            this.imlToolBar.Images.SetKeyName(101, "101_Docking_ Window_Operation.ico");
            this.imlToolBar.Images.SetKeyName(102, "102_Docking_ Window_Resource.ico");
            this.imlToolBar.Images.SetKeyName(103, "103_Docking_Window_Dispatcher.ico");
            this.imlToolBar.Images.SetKeyName(104, "104_Help.ico");
            this.imlToolBar.Images.SetKeyName(105, "105_Send_Message.ico");
            this.imlToolBar.Images.SetKeyName(106, "106_Batch_Keep_Flag_Setup.ico");
            this.imlToolBar.Images.SetKeyName(107, "107_Yield_Setup.ico");
            this.imlToolBar.Images.SetKeyName(108, "108_Resource_MFO_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(109, "109_Carrier_Group_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(110, "110_Change_Port_State.ico");
            this.imlToolBar.Images.SetKeyName(111, "111_Change_Transfer_State.ico");
            this.imlToolBar.Images.SetKeyName(112, "112_Change_Association_State.ico");
            this.imlToolBar.Images.SetKeyName(113, "113_Change_Access_Mode_State.ico");
            this.imlToolBar.Images.SetKeyName(114, "114_Change_Reservation_State.ico");
            this.imlToolBar.Images.SetKeyName(115, "115_Make_Check_Result.ico");
            this.imlToolBar.Images.SetKeyName(116, "Amc Application.ico");
            this.imlToolBar.Images.SetKeyName(117, "117_Help_2.ico");
            this.imlToolBar.Images.SetKeyName(118, "118_Flexible_Header_Setup.ico");
            this.imlToolBar.Images.SetKeyName(119, "119_Calendar_Setup.ico");
            this.imlToolBar.Images.SetKeyName(120, "120_Calendar_Setup_Month.ico");
            this.imlToolBar.Images.SetKeyName(121, "121_Calendar_Setup_Year.ico");
            this.imlToolBar.Images.SetKeyName(122, "122_Future_Action_Setup.ico");
            this.imlToolBar.Images.SetKeyName(123, "123_Queue_Time_Setup.ico");
            this.imlToolBar.Images.SetKeyName(124, "124_ID_Generator_Setup.ico");
            this.imlToolBar.Images.SetKeyName(125, "125_ID_Generator_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(126, "126_Batch_Creation_Rule_Setup.ico");
            this.imlToolBar.Images.SetKeyName(127, "127_Batch__Creation_Rule_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(128, "128_BOM_Set_Setup.ico");
            this.imlToolBar.Images.SetKeyName(129, "129_Attach_Material_Setup.ico");
            this.imlToolBar.Images.SetKeyName(130, "130_Bom_Approval and_Release_Setup.ico");
            this.imlToolBar.Images.SetKeyName(131, "131_Character_Setup.ico");
            this.imlToolBar.Images.SetKeyName(132, "132_Collection_Set_Setup.ico");
            this.imlToolBar.Images.SetKeyName(133, "133_Attach_Character.ico");
            this.imlToolBar.Images.SetKeyName(134, "134_Attach_Collection_Set_to_MFO.ico");
            this.imlToolBar.Images.SetKeyName(135, "135_Edc_Approval_and_Release.ico");
            this.imlToolBar.Images.SetKeyName(136, "136_Recipe_Setup.ico");
            this.imlToolBar.Images.SetKeyName(137, "137_Recipe_Version_Setup.ico");
            this.imlToolBar.Images.SetKeyName(138, "138_Rcp_Approval_and_Release_Setup.ico");
            this.imlToolBar.Images.SetKeyName(139, "139_Attach_Recipe_To_MFO_Setup.ico");
            this.imlToolBar.Images.SetKeyName(140, "140_Dispatcher_Rule_Setup.ico");
            this.imlToolBar.Images.SetKeyName(141, "141_Dispatcher_Rule_Item_Setup.ico");
            this.imlToolBar.Images.SetKeyName(142, "142_Dispatcher_Setup.ico");
            this.imlToolBar.Images.SetKeyName(143, "143_Dispatcher_Simulation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(144, "144_Dispatcher_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(145, "145_Reference_Operation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(146, "146_Alarm_Setup.ico");
            this.imlToolBar.Images.SetKeyName(147, "147_Attach_Alarm_to_MFO_Resource.ico");
            this.imlToolBar.Images.SetKeyName(148, "2.10.2_AttachAlarmToResource.ico");
            this.imlToolBar.Images.SetKeyName(149, "149_Attribute_Setup.ico");
            this.imlToolBar.Images.SetKeyName(150, "150_Service_Member_Setup.ico");
            this.imlToolBar.Images.SetKeyName(151, "151_Member_Setup.ico");
            this.imlToolBar.Images.SetKeyName(152, "152_Work_Flow Modeler_WIP.ico");
            this.imlToolBar.Images.SetKeyName(153, "153_Work_Flow Modeler_RAS.ico");
            this.imlToolBar.Images.SetKeyName(154, "154_In_Store.ico");
            this.imlToolBar.Images.SetKeyName(155, "155_Out_Store.ico");
            this.imlToolBar.Images.SetKeyName(156, "156_Transfer_Store.ico");
            this.imlToolBar.Images.SetKeyName(157, "157_Convert_Inventory_Type_to_Lot.ico");
            this.imlToolBar.Images.SetKeyName(158, "158_Convert_Lot_to_Inventory_Type.ico");
            this.imlToolBar.Images.SetKeyName(159, "159_Consume.ico");
            this.imlToolBar.Images.SetKeyName(160, "160_Scrap.ico");
            this.imlToolBar.Images.SetKeyName(161, "161_Delete_Inventory_History.ico");
            this.imlToolBar.Images.SetKeyName(162, "162_Assembly_Lot.ico");
            this.imlToolBar.Images.SetKeyName(163, "163_Delete_BOM_History.ico");
            this.imlToolBar.Images.SetKeyName(164, "164_EDC_Collect_Lot_Data.ico");
            this.imlToolBar.Images.SetKeyName(165, "165_Change_Lot_Data.ico");
            this.imlToolBar.Images.SetKeyName(166, "166_Change_Resource_Data.ico");
            this.imlToolBar.Images.SetKeyName(167, "167_Delete_EDC Data_History.ico");
            this.imlToolBar.Images.SetKeyName(168, "168_Delete_Resource_Data_History.ico");
            this.imlToolBar.Images.SetKeyName(169, "169_Start_Sub_Lot.ico");
            this.imlToolBar.Images.SetKeyName(170, "170_End_Sub_Lot.ico");
            this.imlToolBar.Images.SetKeyName(171, "171_Rework_Sub.ico");
            this.imlToolBar.Images.SetKeyName(172, "172_Delete_Sub_Lot_History.ico");
            this.imlToolBar.Images.SetKeyName(173, "173_Split_Extension.ico");
            this.imlToolBar.Images.SetKeyName(174, "174_Merge_Extension.ico");
            this.imlToolBar.Images.SetKeyName(175, "175_Combine_Extension.ico");
            this.imlToolBar.Images.SetKeyName(176, "176_Loss_Extension.ico");
            this.imlToolBar.Images.SetKeyName(177, "177_Sort_Extension.ico");
            this.imlToolBar.Images.SetKeyName(178, "178_Raise_Alarm.ico");
            this.imlToolBar.Images.SetKeyName(179, "179_Clear_Alarm.ico");
            this.imlToolBar.Images.SetKeyName(180, "180_Adjust_Lot_Priority.ico");
            this.imlToolBar.Images.SetKeyName(181, "181_Manual_Re_Dispatch_Lot.ico");
            this.imlToolBar.Images.SetKeyName(182, "182_Lot_Label_Print.ico");
            this.imlToolBar.Images.SetKeyName(183, "183_Input_Attribute_Value.ico");
            this.imlToolBar.Images.SetKeyName(184, "184_Change_CMF_Value_WIP.ico");
            this.imlToolBar.Images.SetKeyName(185, "185_View_Lot_Status.ico");
            this.imlToolBar.Images.SetKeyName(186, "186_View_Lot_History.ico");
            this.imlToolBar.Images.SetKeyName(187, "187_View_Lot_History.ico");
            this.imlToolBar.Images.SetKeyName(188, "188_View_Resource_Status.ico");
            this.imlToolBar.Images.SetKeyName(189, "189_View_Resource_History.ico");
            this.imlToolBar.Images.SetKeyName(190, "190_View_Port_History.ico");
            this.imlToolBar.Images.SetKeyName(191, "191_View_Sub_Resource_History.ico");
            this.imlToolBar.Images.SetKeyName(192, "192_View_Resource_By_Group.ico");
            this.imlToolBar.Images.SetKeyName(193, "193_View_Resource_by_MFO.ico");
            this.imlToolBar.Images.SetKeyName(194, "194_View_Lot_by_Resource.ico");
            this.imlToolBar.Images.SetKeyName(195, "195_View_Event_by_Event_Group.ico");
            this.imlToolBar.Images.SetKeyName(196, "196_View_Lot_List_by_Resource_Group.ico");
            this.imlToolBar.Images.SetKeyName(197, "197_View_Resource_Down_History.ico");
            this.imlToolBar.Images.SetKeyName(198, "198_View_Resource_Labor.ico");
            this.imlToolBar.Images.SetKeyName(199, "199_View_Carrier_Status.ico");
            this.imlToolBar.Images.SetKeyName(200, "200_View_Carrier_History.ico");
            this.imlToolBar.Images.SetKeyName(201, "201_View_Carrier_History_by_Lot.ico");
            this.imlToolBar.Images.SetKeyName(202, "202_View_Carrier_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(203, "203_View_Tool.ico");
            this.imlToolBar.Images.SetKeyName(204, "204_View_Tool_List.ico");
            this.imlToolBar.Images.SetKeyName(205, "205_View_Tool_List_by_Operation.ico");
            this.imlToolBar.Images.SetKeyName(206, "206_View_Tool_List_By_Resource.ico");
            this.imlToolBar.Images.SetKeyName(207, "207_View_Tool_History.ico");
            this.imlToolBar.Images.SetKeyName(208, "208_View_Tool_Defect_Data.ico");
            this.imlToolBar.Images.SetKeyName(209, "209_View_Check_Result.ico");
            this.imlToolBar.Images.SetKeyName(210, "210_View_Lot_Data.ico");
            this.imlToolBar.Images.SetKeyName(211, "211_View_Alarm_History.ico");
            this.imlToolBar.Images.SetKeyName(212, "212_View_Lot_Recipe_History.ico");
            this.imlToolBar.Images.SetKeyName(213, "213_Production_Order_Setup.ico");
            this.imlToolBar.Images.SetKeyName(214, "214_Production_Plan_Setup.ico");
            this.imlToolBar.Images.SetKeyName(215, "215_Planned_Lot_Setup.ico");
            this.imlToolBar.Images.SetKeyName(216, "216_Work_Order_Setup.ico");
            this.imlToolBar.Images.SetKeyName(217, "217_View_Production_Order.ico");
            this.imlToolBar.Images.SetKeyName(218, "218_View_Production_Plan.ico");
            this.imlToolBar.Images.SetKeyName(219, "219_View_Planned_Lot.ico");
            this.imlToolBar.Images.SetKeyName(220, "220_View_Work_Order.ico");
            this.imlToolBar.Images.SetKeyName(221, "221_Create_Lot_Based_on_Order.ico");
            this.imlToolBar.Images.SetKeyName(222, "222_Create_Lot_Based_on_Plan.ico");
            this.imlToolBar.Images.SetKeyName(223, "223_Create_Planned_Lot.ico");
            this.imlToolBar.Images.SetKeyName(224, "224_Attach_Lot_to_Order.ico");
            this.imlToolBar.Images.SetKeyName(225, "225_Chart_Setup.ico");
            this.imlToolBar.Images.SetKeyName(226, "226_Spec_Management_Setup.ico");
            this.imlToolBar.Images.SetKeyName(227, "227_Attach_User_to_Chart_Setup.ico");
            this.imlToolBar.Images.SetKeyName(228, "228_Chart_Set_Setup.ico");
            this.imlToolBar.Images.SetKeyName(229, "229_Trouble_and_Action_Code_Setup.ico");
            this.imlToolBar.Images.SetKeyName(230, "230_Realtime_Monitoring_Control_Chart.ico");
            this.imlToolBar.Images.SetKeyName(231, "231_Control_Chart.ico");
            this.imlToolBar.Images.SetKeyName(232, "232_Capability_Analysis.ico");
            this.imlToolBar.Images.SetKeyName(233, "233_Multi_Realtime_Monitoring_Control_Chart.ico");
            this.imlToolBar.Images.SetKeyName(234, "234_View_EDC_Data.ico");
            this.imlToolBar.Images.SetKeyName(235, "235_View_OOC_History.ico");
            this.imlToolBar.Images.SetKeyName(236, "236_View_Process_Capability.ico");
            this.imlToolBar.Images.SetKeyName(237, "237_View_Excluded_EDC_History.ico");
            this.imlToolBar.Images.SetKeyName(238, "238_View_Chart_List.ico");
            this.imlToolBar.Images.SetKeyName(239, "239_Zoom_Out.ico");
            this.imlToolBar.Images.SetKeyName(240, "240_Save_Layout_Configuration.ico");
            this.imlToolBar.Images.SetKeyName(241, "241_Global_Option_Setup_fmb.ico");
            this.imlToolBar.Images.SetKeyName(242, "242_Resource_Image_Setup.ico");
            this.imlToolBar.Images.SetKeyName(243, "243_New_Layout.ico");
            this.imlToolBar.Images.SetKeyName(244, "244_New_User_Design.ico");
            this.imlToolBar.Images.SetKeyName(245, "245_Design_Mode.ico");
            this.imlToolBar.Images.SetKeyName(246, "246_Save_Design.ico");
            this.imlToolBar.Images.SetKeyName(247, "247_Add_Multi_Resource.ico");
            this.imlToolBar.Images.SetKeyName(248, "248_Reload.ico");
            this.imlToolBar.Images.SetKeyName(249, "249_Zoom_In.ico");
            this.imlToolBar.Images.SetKeyName(250, "250_Dispatch_Event_Configuration_Setup.ico");
            this.imlToolBar.Images.SetKeyName(251, "");
            this.imlToolBar.Images.SetKeyName(252, "252_Sampling_Procedure_Setup.ico");
            this.imlToolBar.Images.SetKeyName(253, "253_Inspection_Item_Setup.ico");
            this.imlToolBar.Images.SetKeyName(254, "254_Inspection_Set_Setup.ico");
            this.imlToolBar.Images.SetKeyName(255, "255_Attach_Inspection_Item_to_Version.ico");
            this.imlToolBar.Images.SetKeyName(256, "256_Approval_and_Release_Inspection_Set_Version.ico");
            this.imlToolBar.Images.SetKeyName(257, "257_Inspection_Material_Setup.ico");
            this.imlToolBar.Images.SetKeyName(258, "258_Label_Setup.ico");
            this.imlToolBar.Images.SetKeyName(259, "259_Label_Design_Setup.ico");
            this.imlToolBar.Images.SetKeyName(260, "260_Material_Label_Setup.ico");
            this.imlToolBar.Images.SetKeyName(261, "261_Image_Setup.ico");
            this.imlToolBar.Images.SetKeyName(262, "262_Disassemble_Lot.ico");
            this.imlToolBar.Images.SetKeyName(263, "263_Replace.ico");
            this.imlToolBar.Images.SetKeyName(264, "264_Modify_Lot_Recipe.ico");
            this.imlToolBar.Images.SetKeyName(265, "265_Modify_Sub_Lot_Recipe.ico");
            this.imlToolBar.Images.SetKeyName(266, "266_Create_QC_Batch.ico");
            this.imlToolBar.Images.SetKeyName(267, "267_Result_Recording.ico");
            this.imlToolBar.Images.SetKeyName(268, "268_Final_Decision.ico");
            this.imlToolBar.Images.SetKeyName(269, "269_View_Lot_Trace.ico");
            this.imlToolBar.Images.SetKeyName(270, "270_View_Material_by_Group.ico");
            this.imlToolBar.Images.SetKeyName(271, "271_View_Material_by_Flow.ico");
            this.imlToolBar.Images.SetKeyName(272, "272_View_Flow_by_Operation.ico");
            this.imlToolBar.Images.SetKeyName(273, "273_View_Lot_List_by_Operation.ico");
            this.imlToolBar.Images.SetKeyName(274, "274_View_Transit_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(275, "275_View_Hold_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(276, "276_View_Trouble_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(277, "");
            this.imlToolBar.Images.SetKeyName(278, "278_View_Rework_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(279, "279_View_Return_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(280, "280_View_Lot_Defect_List.ico");
            this.imlToolBar.Images.SetKeyName(281, "281_View_Batch_Status.ico");
            this.imlToolBar.Images.SetKeyName(282, "282_View_Batch_History.ico");
            this.imlToolBar.Images.SetKeyName(283, "283_View_Inventory_History.ico");
            this.imlToolBar.Images.SetKeyName(284, "284_View_Lot_Status_For_Assembly.ico");
            this.imlToolBar.Images.SetKeyName(285, "285_View_Lot_History_For_Assembly.ico");
            this.imlToolBar.Images.SetKeyName(286, "286_View_Material_List_by_BOM_Set_ID.ico");
            this.imlToolBar.Images.SetKeyName(287, "287_View_PM_Schedule_In_View_of_Planner.ico");
            this.imlToolBar.Images.SetKeyName(288, "288_View_PM_Schedule_In_View_of_Actor.ico");
            this.imlToolBar.Images.SetKeyName(289, "289_View_Lot_Data_by_Collection_Set.ico");
            this.imlToolBar.Images.SetKeyName(290, "290_View_Resource_Data.ico");
            this.imlToolBar.Images.SetKeyName(291, "291_View_Resource_Data_by_Collection_Set.ico");
            this.imlToolBar.Images.SetKeyName(292, "292_View_Character_by_Collection_Set.ico");
            this.imlToolBar.Images.SetKeyName(293, "293_View_Collection_Set_by_MFO.ico");
            this.imlToolBar.Images.SetKeyName(294, "294_View_Character_by_Group.ico");
            this.imlToolBar.Images.SetKeyName(295, "295_View_Collection_Set_by_Group.ico");
            this.imlToolBar.Images.SetKeyName(296, "296_View_Sub_Lot_Status.ico");
            this.imlToolBar.Images.SetKeyName(297, "297_View_Sub_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(298, "298_View_Sub_Lot_History.ico");
            this.imlToolBar.Images.SetKeyName(299, "299_View_SubLot_Loss_List.ico");
            this.imlToolBar.Images.SetKeyName(300, "300_View_SubLot_Recipe_History.ico");
            this.imlToolBar.Images.SetKeyName(301, "301_View_Dispatch_Event_Interface_History.ico");
            this.imlToolBar.Images.SetKeyName(302, "302_View_Pre_Dispatched_History.ico");
            this.imlToolBar.Images.SetKeyName(303, "303_View_Dispatched_Lot_List.ico");
            this.imlToolBar.Images.SetKeyName(304, "304_View_Dispatched_Resource_List.ico");
            this.imlToolBar.Images.SetKeyName(305, "305_View_QC_Batch_Status.ico");
            this.imlToolBar.Images.SetKeyName(306, "306_View_Inspection_History.ico");
            this.imlToolBar.Images.SetKeyName(307, "307_View_QC_Batch_List.ico");
            this.imlToolBar.Images.SetKeyName(308, "308_View_Attribute_Status.ico");
            this.imlToolBar.Images.SetKeyName(309, "309_View_Attribute_History.ico");
            this.imlToolBar.Images.SetKeyName(310, "310_View_Service_Member.ico");
            this.imlToolBar.Images.SetKeyName(311, "311_View_Data_List_by_Attribute.ico");
            this.imlToolBar.Images.SetKeyName(312, "312_Active_Service_Version_Setup.ico");
            this.imlToolBar.Images.SetKeyName(313, "313_Request_Reinspection.ico");
            this.imlToolBar.Images.SetKeyName(314, "314_View_Lot_Loss_List.ico");
            this.imlToolBar.Images.SetKeyName(315, "315_View_Lot_Bonus_List.ico");
            this.imlToolBar.Images.SetKeyName(316, "316_View_QC_Batch_History.ico");
            this.imlToolBar.Images.SetKeyName(317, "317_Start_Lot_Extension.ico");
            this.imlToolBar.Images.SetKeyName(318, "318_End_Lot_Extension.ico");
            this.imlToolBar.Images.SetKeyName(319, "319_Resource_Color_Setup.ico");
            this.imlToolBar.Images.SetKeyName(320, "320_View_Lot_Trace_Tree.ico");
            this.imlToolBar.Images.SetKeyName(321, "321_Privilege_Definition_Setup.ico");
            this.imlToolBar.Images.SetKeyName(322, "322_Global_Option_Setup.ico");
            this.imlToolBar.Images.SetKeyName(323, "323_Flexible_Screen_Setup.ico");
            this.imlToolBar.Images.SetKeyName(324, "324_Inquiry_Screen_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(325, "325_Flexible_Inquiry_Setup.ico");
            this.imlToolBar.Images.SetKeyName(326, "326_Group_Definition_Setup.ico");
            this.imlToolBar.Images.SetKeyName(327, "327_Customized_Field_Setup.ico");
            this.imlToolBar.Images.SetKeyName(328, "328_End_Lot_For_Step.ico");
            this.imlToolBar.Images.SetKeyName(329, "329_Step_MFO_Relation_Setup.ico");
            this.imlToolBar.Images.SetKeyName(330, "330_Input_Operation_Value_Setup_Setup.ico");
            this.imlToolBar.Images.SetKeyName(331, "331_Service_User_Routine_Setup.ico");
            this.imlToolBar.Images.SetKeyName(332, "332_Start_Lot_For_Step.ico");
            this.imlToolBar.Images.SetKeyName(333, "333_Count_Variance_Group.ico");
            this.imlToolBar.Images.SetKeyName(334, "334_Regenerate_Lot.ico");
            this.imlToolBar.Images.SetKeyName(335, "335_Delete_Lot_History_For_Step.ico");
            this.imlToolBar.Images.SetKeyName(336, "336_Scribe_Extension.ico");
            this.imlToolBar.Images.SetKeyName(337, "337_Delete_Start_Batch.ico");
            this.imlToolBar.Images.SetKeyName(338, "338_View_Lot_History_For_Step.ico");
            this.imlToolBar.Images.SetKeyName(339, "339_View_Carrier_Slot_History.ico");
            this.imlToolBar.Images.SetKeyName(340, "340_Flexible_Inquiry.ico");
            this.imlToolBar.Images.SetKeyName(341, "341_Attach_Chart_to_MFO.ico");
            this.imlToolBar.Images.SetKeyName(342, "342_EDC_Prompt_Setup.ico");
            this.imlToolBar.Images.SetKeyName(343, "343_Collect_Lot_Data.ico");
            this.imlToolBar.Images.SetKeyName(344, "344_Collect_Resource_Data.ico");
            this.imlToolBar.Images.SetKeyName(345, "345_Clear_Alarm.ico");
            this.imlToolBar.Images.SetKeyName(346, "346_Collect_EDC_Data_by_Chart_Set.ico");
            this.imlToolBar.Images.SetKeyName(347, "347_Collect_Resource_Data_by_Chart_Set_Type1.ico");
            this.imlToolBar.Images.SetKeyName(348, "348_Collect_Lot_Data_by_Chart_Set_Type2.ico");
            this.imlToolBar.Images.SetKeyName(349, "349_Collect_ Resource_Data_by_Chart_Set_Type2.ico");
            this.imlToolBar.Images.SetKeyName(350, "350_Collect_Lot_Data_by_Chart_Set_Type3.ico");
            this.imlToolBar.Images.SetKeyName(351, "351_Collect_Resource_Data_by_Chart_Set_Type3.ico");
            this.imlToolBar.Images.SetKeyName(352, "352_View_Spec_History.ico");
            this.imlToolBar.Images.SetKeyName(353, "353_View_Alarm_History.ico");
            this.imlToolBar.Images.SetKeyName(354, "354_View_Lot_List_by_Operation.ico");
            this.imlToolBar.Images.SetKeyName(355, "355_View_Resource_List_Detail.ico");
            this.imlToolBar.Images.SetKeyName(356, "356_Maintenance_Lot_Data.ico");
            this.imlToolBar.Images.SetKeyName(357, "357_Archive_option_Setup.ico");
            this.imlToolBar.Images.SetKeyName(358, "358_Archive_Table_key_ Setup.ico");
            this.imlToolBar.Images.SetKeyName(359, "359_Run_Archive_and_view_Archive_option_list.ico");
            this.imlToolBar.Images.SetKeyName(360, "360_Task_Manager.ico");
            this.imlToolBar.Images.SetKeyName(361, "361_Darchive.ico");
            this.imlToolBar.Images.SetKeyName(362, "362_Replication_Database.ico");
            this.imlToolBar.Images.SetKeyName(363, "363_Monitoring_Replication.ico");
            this.imlToolBar.Images.SetKeyName(364, "364_Setup_Batch_Job.ico");
            this.imlToolBar.Images.SetKeyName(365, "365_View_Log_history.ico");
            this.imlToolBar.Images.SetKeyName(366, "366_Create_View_Trigger.ico");
            this.imlToolBar.Images.SetKeyName(367, "367_View_Service_Performance.ico");
            this.imlToolBar.Images.SetKeyName(368, "368_View_Service_Error.ico");
            this.imlToolBar.Images.SetKeyName(369, "369_Input_Attribute_Value_By_Privilege.ico");
            this.imlToolBar.Images.SetKeyName(370, "370_Step_Setup.ico");
            // 
            // tmrCheckVersion
            // 
            this.tmrCheckVersion.Enabled = true;
            this.tmrCheckVersion.Interval = 60000;
            this.tmrCheckVersion.Tick += new System.EventHandler(this.tmrCheckVersion_Tick);
            // 
            // tmrBBSMsg
            // 
            this.tmrBBSMsg.Enabled = true;
            this.tmrBBSMsg.Interval = 1000;
            this.tmrBBSMsg.Tick += new System.EventHandler(this.tmrBBSMsg_Tick);
            // 
            // pnlBBSMessage
            // 
            this.pnlBBSMessage.BackColor = System.Drawing.Color.Maroon;
            this.pnlBBSMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBBSMessage.Controls.Add(this.lblBBSMessage);
            this.pnlBBSMessage.Controls.Add(this.pbxBBSMessage);
            this.pnlBBSMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBBSMessage.Location = new System.Drawing.Point(0, 373);
            this.pnlBBSMessage.Name = "pnlBBSMessage";
            this.pnlBBSMessage.Size = new System.Drawing.Size(576, 0);
            this.pnlBBSMessage.TabIndex = 9;
            this.pnlBBSMessage.Visible = false;
            this.pnlBBSMessage.Click += new System.EventHandler(this.pnlBBSMessage_Click);
            // 
            // lblBBSMessage
            // 
            this.lblBBSMessage.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblBBSMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBBSMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblBBSMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBBSMessage.Location = new System.Drawing.Point(25, 0);
            this.lblBBSMessage.Name = "lblBBSMessage";
            this.lblBBSMessage.Size = new System.Drawing.Size(549, 0);
            this.lblBBSMessage.TabIndex = 2;
            this.lblBBSMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBBSMessage.Click += new System.EventHandler(this.lblBBSMessage_Click);
            // 
            // pbxBBSMessage
            // 
            this.pbxBBSMessage.BackColor = System.Drawing.Color.White;
            this.pbxBBSMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbxBBSMessage.Image = ((System.Drawing.Image)(resources.GetObject("pbxBBSMessage.Image")));
            this.pbxBBSMessage.Location = new System.Drawing.Point(0, 0);
            this.pbxBBSMessage.Name = "pbxBBSMessage";
            this.pbxBBSMessage.Size = new System.Drawing.Size(25, 0);
            this.pbxBBSMessage.TabIndex = 1;
            this.pbxBBSMessage.TabStop = false;
            // 
            // frmMDIMainCore
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(576, 393);
            this.Controls.Add(this.pnlBBSMessage);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.pnlAlarm);
            this.Controls.Add(this.pgbMain);
            this.Controls.Add(this.MDIMainStatusBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMDIMainCore";
            this.Text = "frmMDIMainCore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMDIMainCore_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMDIMainCore_FormClosed);
            this.Load += new System.EventHandler(this.frmMDIMainCore_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMDIMainCore_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMDIMainPanel6)).EndInit();
            this.pnlAlarm.ResumeLayout(false);
            this.pnlAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlarm)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessage)).EndInit();
            this.pnlBBSMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBBSMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrAlarm;
        private System.Windows.Forms.Timer tmrMsg;
        private System.Windows.Forms.Timer tmrTimeStatus;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.Timer tmrLogOutTime;
        private System.Windows.Forms.Timer tmrSuccess;
        private System.Windows.Forms.StatusBar MDIMainStatusBar;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel1;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel2;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel3;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel4;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel5;
        private System.Windows.Forms.StatusBarPanel stsMDIMainPanel6;
        private System.Windows.Forms.Panel pnlAlarm;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.PictureBox pbxAlarm;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pbxMessage;
        private System.Windows.Forms.ToolTip ttpMain;
        protected System.Windows.Forms.ProgressBar pgbMain;
        protected System.Windows.Forms.ImageList imlSmallIcon;
        protected System.Windows.Forms.ImageList imlToolBar;
        private System.Windows.Forms.Timer tmrCheckVersion;
        private System.Windows.Forms.Timer tmrBBSMsg;
        private System.Windows.Forms.Panel pnlBBSMessage;
        private System.Windows.Forms.Label lblBBSMessage;
        private System.Windows.Forms.PictureBox pbxBBSMessage;
    }
}