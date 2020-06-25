﻿namespace IkeaUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Header = new System.Windows.Forms.Panel();
            this.pictureBox_IkeaLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_AccessLevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Clock = new System.Windows.Forms.Label();
            this.pictureBox_TrifidLogo = new System.Windows.Forms.PictureBox();
            this.tabControl_MainControl = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.groupBox_MainTabControlCameras = new System.Windows.Forms.GroupBox();
            this.tabControl_MainCameras = new System.Windows.Forms.TabControl();
            this.tabPage_LeftSide = new System.Windows.Forms.TabPage();
            this.Hwindow_LeftSide = new HalconDotNet.HSmartWindowControl();
            this.tabPage_RightSide = new System.Windows.Forms.TabPage();
            this.Hwindow_RightSide = new HalconDotNet.HSmartWindowControl();
            this.tabPage_FrontSide = new System.Windows.Forms.TabPage();
            this.Hwindow_FrontSide = new HalconDotNet.HSmartWindowControl();
            this.tabPage_BackSide = new System.Windows.Forms.TabPage();
            this.Hwindow_BackSide = new HalconDotNet.HSmartWindowControl();
            this.tabPage_UpperSide = new System.Windows.Forms.TabPage();
            this.Hwindow_UpperSide = new HalconDotNet.HSmartWindowControl();
            this.tabPage_LowerSide = new System.Windows.Forms.TabPage();
            this.Hwindow_LowerSide = new HalconDotNet.HSmartWindowControl();
            this.imageList_TabMainCameras = new System.Windows.Forms.ImageList(this.components);
            this.groupBox_MainStatistics = new System.Windows.Forms.GroupBox();
            this.label_MainStatisticsOverall = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label_MainStatisticsSuspicious = new System.Windows.Forms.Label();
            this.label_MainStatisticsOverCount = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label_MainStatisticsOK = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label_MainStatisticsNOK = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label_MainSystemMessage = new System.Windows.Forms.Label();
            this.label_MainPoznamka = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox_MainSystemMessage = new System.Windows.Forms.TextBox();
            this.textBox_MainPoznamka = new System.Windows.Forms.TextBox();
            this.groupBox_MainPodozrive = new System.Windows.Forms.GroupBox();
            this.progressBar_MainPodozrive = new System.Windows.Forms.ProgressBar();
            this.groupBox_MainDielce = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_MainSearchRecipe = new System.Windows.Forms.TextBox();
            this.listBox_MainRecipe = new System.Windows.Forms.ListBox();
            this.groupBox_MainRiadenie = new System.Windows.Forms.GroupBox();
            this.button_MainStop = new System.Windows.Forms.Button();
            this.button_MainSaveImg = new System.Windows.Forms.Button();
            this.button_MainStart = new System.Windows.Forms.Button();
            this.tabPage_Archive = new System.Windows.Forms.TabPage();
            this.groupBox_ArchiveDrawingSides = new System.Windows.Forms.GroupBox();
            this.dataGridView_ArchiveDrawingSides = new System.Windows.Forms.DataGridView();
            this.DrawingSideName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_TakeInfoFromDB = new System.Windows.Forms.Button();
            this.button_RefreshTable = new System.Windows.Forms.Button();
            this.groupBox_Holes = new System.Windows.Forms.GroupBox();
            this.dataGridView_HolesData = new System.Windows.Forms.DataGridView();
            this.TimeStampHoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusHoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Boards = new System.Windows.Forms.GroupBox();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrawingSidesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Hwindow = new System.Windows.Forms.GroupBox();
            this.Hwindow_ArchiveImage = new HalconDotNet.HSmartWindowControl();
            this.tabPage_Diagnostics = new System.Windows.Forms.TabPage();
            this.panel_DiagnosticsAutorization = new System.Windows.Forms.Panel();
            this.button_DiagnosticsChangePassword = new System.Windows.Forms.Button();
            this.button_DiagnosticsLogOff = new System.Windows.Forms.Button();
            this.button_DiagnosticsLogIn = new System.Windows.Forms.Button();
            this.textBox_UserPassword = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.button_DiagnosticsAutorisation = new System.Windows.Forms.Button();
            this.groupBox_DiagnosticsVstupy = new System.Windows.Forms.GroupBox();
            this.button_DiagnosticsInput7 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput6 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput5 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput4 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput3 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput2 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput1 = new System.Windows.Forms.Button();
            this.button_DiagnosticsInput0 = new System.Windows.Forms.Button();
            this.pictureBox_DiagnosticsInput6 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput0 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput5 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsInput1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox_DiagnosticsVykres = new System.Windows.Forms.GroupBox();
            this.Hwindow_Diagnostika = new HalconDotNet.HSmartWindowControl();
            this.groupBox_DiagnosticsOutputs = new System.Windows.Forms.GroupBox();
            this.button_DiagnosticsOutput15 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput7 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput14 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput6 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput13 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput5 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput12 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput4 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput11 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput3 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput10 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput2 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput9 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput8 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput1 = new System.Windows.Forms.Button();
            this.button_DiagnosticsOutput0 = new System.Windows.Forms.Button();
            this.pictureBox_DiagnosticsOutput14 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput6 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput11 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput0 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput8 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput15 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput13 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput5 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput12 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Indicator4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput10 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput9 = new System.Windows.Forms.PictureBox();
            this.pictureBox_DiagnosticsOutput1 = new System.Windows.Forms.PictureBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox_DiagnosticsCamSettings = new System.Windows.Forms.GroupBox();
            this.textBox_DiagnosticsGain = new System.Windows.Forms.TextBox();
            this.textBox_DiagnosticsExposureTime = new System.Windows.Forms.TextBox();
            this.listBox_DiagnosticsCamerasSettings = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_DiagnosticsGainSet = new System.Windows.Forms.Button();
            this.button_DiagnosticsExposureSet = new System.Windows.Forms.Button();
            this.label_Diagnostics = new System.Windows.Forms.Label();
            this.groupBox_DiagnosticsCamInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox_CamInfo1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo5 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo6 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo7 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo8 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo9 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo10 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo11 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo12 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo13 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CamInfo14 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_caminfo = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox_DiagnosticsDiscManagement = new System.Windows.Forms.GroupBox();
            this.label_AvailableSpaceE = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_AvailableSpaceC = new System.Windows.Forms.Label();
            this.label_AvailableSpaceD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_Simulation = new System.Windows.Forms.Timer(this.components);
            this.timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.timer_DiscsCheck = new System.Windows.Forms.Timer(this.components);
            this.panel_Footer = new System.Windows.Forms.Panel();
            this.pictureBox_FooterKeyBoard = new System.Windows.Forms.PictureBox();
            this.button_FooterExitApp = new System.Windows.Forms.Button();
            this.timer_CameraPing = new System.Windows.Forms.Timer(this.components);
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IkeaLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TrifidLogo)).BeginInit();
            this.tabControl_MainControl.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            this.groupBox_MainTabControlCameras.SuspendLayout();
            this.tabControl_MainCameras.SuspendLayout();
            this.tabPage_LeftSide.SuspendLayout();
            this.tabPage_RightSide.SuspendLayout();
            this.tabPage_FrontSide.SuspendLayout();
            this.tabPage_BackSide.SuspendLayout();
            this.tabPage_UpperSide.SuspendLayout();
            this.tabPage_LowerSide.SuspendLayout();
            this.groupBox_MainStatistics.SuspendLayout();
            this.groupBox_MainPodozrive.SuspendLayout();
            this.groupBox_MainDielce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_MainRiadenie.SuspendLayout();
            this.tabPage_Archive.SuspendLayout();
            this.groupBox_ArchiveDrawingSides.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ArchiveDrawingSides)).BeginInit();
            this.groupBox_Holes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HolesData)).BeginInit();
            this.groupBox_Boards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.groupBox_Hwindow.SuspendLayout();
            this.tabPage_Diagnostics.SuspendLayout();
            this.panel_DiagnosticsAutorization.SuspendLayout();
            this.groupBox_DiagnosticsVstupy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput1)).BeginInit();
            this.groupBox_DiagnosticsVykres.SuspendLayout();
            this.groupBox_DiagnosticsOutputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Indicator4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput1)).BeginInit();
            this.groupBox_DiagnosticsCamSettings.SuspendLayout();
            this.groupBox_DiagnosticsCamInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo14)).BeginInit();
            this.groupBox_DiagnosticsDiscManagement.SuspendLayout();
            this.panel_Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FooterKeyBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.BackColor = System.Drawing.Color.Silver;
            this.panel_Header.Controls.Add(this.pictureBox_IkeaLogo);
            this.panel_Header.Controls.Add(this.label1);
            this.panel_Header.Controls.Add(this.label_AccessLevel);
            this.panel_Header.Controls.Add(this.label6);
            this.panel_Header.Controls.Add(this.label_Clock);
            this.panel_Header.Controls.Add(this.pictureBox_TrifidLogo);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel_Header.Location = new System.Drawing.Point(0, 0);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(1920, 65);
            this.panel_Header.TabIndex = 7;
            // 
            // pictureBox_IkeaLogo
            // 
            this.pictureBox_IkeaLogo.ErrorImage = null;
            this.pictureBox_IkeaLogo.Image = global::IkeaUI.Properties.Resources.icons8_ikea_144;
            this.pictureBox_IkeaLogo.InitialImage = null;
            this.pictureBox_IkeaLogo.Location = new System.Drawing.Point(1807, -34);
            this.pictureBox_IkeaLogo.Name = "pictureBox_IkeaLogo";
            this.pictureBox_IkeaLogo.Size = new System.Drawing.Size(110, 130);
            this.pictureBox_IkeaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_IkeaLogo.TabIndex = 1;
            this.pictureBox_IkeaLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(747, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Systém na Meranie a Detekciu Dier";
            // 
            // label_AccessLevel
            // 
            this.label_AccessLevel.AutoSize = true;
            this.label_AccessLevel.Location = new System.Drawing.Point(265, 42);
            this.label_AccessLevel.Name = "label_AccessLevel";
            this.label_AccessLevel.Size = new System.Drawing.Size(72, 20);
            this.label_AccessLevel.TabIndex = 2;
            this.label_AccessLevel.Text = "Operátor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Úroveň prístupu:";
            // 
            // label_Clock
            // 
            this.label_Clock.AutoSize = true;
            this.label_Clock.Location = new System.Drawing.Point(134, 3);
            this.label_Clock.Name = "label_Clock";
            this.label_Clock.Size = new System.Drawing.Size(47, 20);
            this.label_Clock.TabIndex = 2;
            this.label_Clock.Text = "None";
            // 
            // pictureBox_TrifidLogo
            // 
            this.pictureBox_TrifidLogo.ErrorImage = null;
            this.pictureBox_TrifidLogo.Image = global::IkeaUI.Properties.Resources.logo_trifid;
            this.pictureBox_TrifidLogo.InitialImage = null;
            this.pictureBox_TrifidLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_TrifidLogo.Name = "pictureBox_TrifidLogo";
            this.pictureBox_TrifidLogo.Size = new System.Drawing.Size(125, 60);
            this.pictureBox_TrifidLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_TrifidLogo.TabIndex = 0;
            this.pictureBox_TrifidLogo.TabStop = false;
            // 
            // tabControl_MainControl
            // 
            this.tabControl_MainControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl_MainControl.Controls.Add(this.tabPage_Main);
            this.tabControl_MainControl.Controls.Add(this.tabPage_Archive);
            this.tabControl_MainControl.Controls.Add(this.tabPage_Diagnostics);
            this.tabControl_MainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_MainControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_MainControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl_MainControl.ItemSize = new System.Drawing.Size(80, 120);
            this.tabControl_MainControl.Location = new System.Drawing.Point(0, 65);
            this.tabControl_MainControl.Multiline = true;
            this.tabControl_MainControl.Name = "tabControl_MainControl";
            this.tabControl_MainControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl_MainControl.SelectedIndex = 0;
            this.tabControl_MainControl.Size = new System.Drawing.Size(1920, 1015);
            this.tabControl_MainControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_MainControl.TabIndex = 8;
            this.tabControl_MainControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_MainControl_DrawItem);
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Main.Controls.Add(this.groupBox_MainTabControlCameras);
            this.tabPage_Main.Controls.Add(this.groupBox_MainStatistics);
            this.tabPage_Main.Controls.Add(this.label_MainSystemMessage);
            this.tabPage_Main.Controls.Add(this.label_MainPoznamka);
            this.tabPage_Main.Controls.Add(this.textBox3);
            this.tabPage_Main.Controls.Add(this.textBox_MainSystemMessage);
            this.tabPage_Main.Controls.Add(this.textBox_MainPoznamka);
            this.tabPage_Main.Controls.Add(this.groupBox_MainPodozrive);
            this.tabPage_Main.Controls.Add(this.groupBox_MainDielce);
            this.tabPage_Main.Controls.Add(this.groupBox_MainRiadenie);
            this.tabPage_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage_Main.Location = new System.Drawing.Point(124, 4);
            this.tabPage_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Size = new System.Drawing.Size(1792, 1007);
            this.tabPage_Main.TabIndex = 0;
            this.tabPage_Main.Text = "Hlavná";
            // 
            // groupBox_MainTabControlCameras
            // 
            this.groupBox_MainTabControlCameras.Controls.Add(this.tabControl_MainCameras);
            this.groupBox_MainTabControlCameras.Location = new System.Drawing.Point(4, 4);
            this.groupBox_MainTabControlCameras.Name = "groupBox_MainTabControlCameras";
            this.groupBox_MainTabControlCameras.Size = new System.Drawing.Size(1509, 915);
            this.groupBox_MainTabControlCameras.TabIndex = 7;
            this.groupBox_MainTabControlCameras.TabStop = false;
            this.groupBox_MainTabControlCameras.Text = "Pohľady zo strán";
            // 
            // tabControl_MainCameras
            // 
            this.tabControl_MainCameras.Controls.Add(this.tabPage_LeftSide);
            this.tabControl_MainCameras.Controls.Add(this.tabPage_RightSide);
            this.tabControl_MainCameras.Controls.Add(this.tabPage_FrontSide);
            this.tabControl_MainCameras.Controls.Add(this.tabPage_BackSide);
            this.tabControl_MainCameras.Controls.Add(this.tabPage_UpperSide);
            this.tabControl_MainCameras.Controls.Add(this.tabPage_LowerSide);
            this.tabControl_MainCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_MainCameras.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_MainCameras.ImageList = this.imageList_TabMainCameras;
            this.tabControl_MainCameras.ItemSize = new System.Drawing.Size(250, 40);
            this.tabControl_MainCameras.Location = new System.Drawing.Point(3, 22);
            this.tabControl_MainCameras.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_MainCameras.Name = "tabControl_MainCameras";
            this.tabControl_MainCameras.Padding = new System.Drawing.Point(0, 0);
            this.tabControl_MainCameras.SelectedIndex = 0;
            this.tabControl_MainCameras.Size = new System.Drawing.Size(1503, 890);
            this.tabControl_MainCameras.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_MainCameras.TabIndex = 0;
            this.tabControl_MainCameras.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_MainCameras_DrawItem);
            // 
            // tabPage_LeftSide
            // 
            this.tabPage_LeftSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_LeftSide.Controls.Add(this.Hwindow_LeftSide);
            this.tabPage_LeftSide.ImageIndex = 1;
            this.tabPage_LeftSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_LeftSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_LeftSide.Name = "tabPage_LeftSide";
            this.tabPage_LeftSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_LeftSide.TabIndex = 0;
            this.tabPage_LeftSide.Text = "Ľavá strana";
            // 
            // Hwindow_LeftSide
            // 
            this.Hwindow_LeftSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_LeftSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_LeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_LeftSide.HDoubleClickToFitContent = true;
            this.Hwindow_LeftSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_LeftSide.HImagePart = new System.Drawing.Rectangle(0, 0, 800, 600);
            this.Hwindow_LeftSide.HKeepAspectRatio = true;
            this.Hwindow_LeftSide.HMoveContent = true;
            this.Hwindow_LeftSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_LeftSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_LeftSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_LeftSide.Name = "Hwindow_LeftSide";
            this.Hwindow_LeftSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_LeftSide.TabIndex = 1;
            this.Hwindow_LeftSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // tabPage_RightSide
            // 
            this.tabPage_RightSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_RightSide.Controls.Add(this.Hwindow_RightSide);
            this.tabPage_RightSide.ImageIndex = 1;
            this.tabPage_RightSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_RightSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_RightSide.Name = "tabPage_RightSide";
            this.tabPage_RightSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_RightSide.TabIndex = 1;
            this.tabPage_RightSide.Text = "Pravá strana";
            // 
            // Hwindow_RightSide
            // 
            this.Hwindow_RightSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_RightSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_RightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_RightSide.HDoubleClickToFitContent = true;
            this.Hwindow_RightSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_RightSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_RightSide.HKeepAspectRatio = true;
            this.Hwindow_RightSide.HMoveContent = true;
            this.Hwindow_RightSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_RightSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_RightSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_RightSide.Name = "Hwindow_RightSide";
            this.Hwindow_RightSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_RightSide.TabIndex = 0;
            this.Hwindow_RightSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // tabPage_FrontSide
            // 
            this.tabPage_FrontSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_FrontSide.Controls.Add(this.Hwindow_FrontSide);
            this.tabPage_FrontSide.ImageIndex = 1;
            this.tabPage_FrontSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_FrontSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_FrontSide.Name = "tabPage_FrontSide";
            this.tabPage_FrontSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_FrontSide.TabIndex = 2;
            this.tabPage_FrontSide.Text = "Predná strana";
            // 
            // Hwindow_FrontSide
            // 
            this.Hwindow_FrontSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_FrontSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_FrontSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_FrontSide.HDoubleClickToFitContent = true;
            this.Hwindow_FrontSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_FrontSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_FrontSide.HKeepAspectRatio = true;
            this.Hwindow_FrontSide.HMoveContent = true;
            this.Hwindow_FrontSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_FrontSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_FrontSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_FrontSide.Name = "Hwindow_FrontSide";
            this.Hwindow_FrontSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_FrontSide.TabIndex = 1;
            this.Hwindow_FrontSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // tabPage_BackSide
            // 
            this.tabPage_BackSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_BackSide.Controls.Add(this.Hwindow_BackSide);
            this.tabPage_BackSide.ImageIndex = 1;
            this.tabPage_BackSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_BackSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_BackSide.Name = "tabPage_BackSide";
            this.tabPage_BackSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_BackSide.TabIndex = 3;
            this.tabPage_BackSide.Text = "Zadná strana";
            // 
            // Hwindow_BackSide
            // 
            this.Hwindow_BackSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_BackSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_BackSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_BackSide.HDoubleClickToFitContent = true;
            this.Hwindow_BackSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_BackSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_BackSide.HKeepAspectRatio = true;
            this.Hwindow_BackSide.HMoveContent = true;
            this.Hwindow_BackSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_BackSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_BackSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_BackSide.Name = "Hwindow_BackSide";
            this.Hwindow_BackSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_BackSide.TabIndex = 2;
            this.Hwindow_BackSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // tabPage_UpperSide
            // 
            this.tabPage_UpperSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_UpperSide.Controls.Add(this.Hwindow_UpperSide);
            this.tabPage_UpperSide.ImageIndex = 1;
            this.tabPage_UpperSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_UpperSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_UpperSide.Name = "tabPage_UpperSide";
            this.tabPage_UpperSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_UpperSide.TabIndex = 4;
            this.tabPage_UpperSide.Text = "Horná strana";
            // 
            // Hwindow_UpperSide
            // 
            this.Hwindow_UpperSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_UpperSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_UpperSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_UpperSide.HDoubleClickToFitContent = true;
            this.Hwindow_UpperSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_UpperSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_UpperSide.HKeepAspectRatio = true;
            this.Hwindow_UpperSide.HMoveContent = true;
            this.Hwindow_UpperSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_UpperSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_UpperSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_UpperSide.Name = "Hwindow_UpperSide";
            this.Hwindow_UpperSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_UpperSide.TabIndex = 2;
            this.Hwindow_UpperSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // tabPage_LowerSide
            // 
            this.tabPage_LowerSide.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_LowerSide.Controls.Add(this.Hwindow_LowerSide);
            this.tabPage_LowerSide.ImageIndex = 1;
            this.tabPage_LowerSide.Location = new System.Drawing.Point(4, 44);
            this.tabPage_LowerSide.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_LowerSide.Name = "tabPage_LowerSide";
            this.tabPage_LowerSide.Size = new System.Drawing.Size(1495, 842);
            this.tabPage_LowerSide.TabIndex = 5;
            this.tabPage_LowerSide.Text = "Dolná strana";
            // 
            // Hwindow_LowerSide
            // 
            this.Hwindow_LowerSide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_LowerSide.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_LowerSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_LowerSide.HDoubleClickToFitContent = true;
            this.Hwindow_LowerSide.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_LowerSide.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_LowerSide.HKeepAspectRatio = true;
            this.Hwindow_LowerSide.HMoveContent = true;
            this.Hwindow_LowerSide.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_LowerSide.Location = new System.Drawing.Point(0, 0);
            this.Hwindow_LowerSide.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_LowerSide.Name = "Hwindow_LowerSide";
            this.Hwindow_LowerSide.Size = new System.Drawing.Size(1495, 842);
            this.Hwindow_LowerSide.TabIndex = 2;
            this.Hwindow_LowerSide.WindowSize = new System.Drawing.Size(1495, 842);
            // 
            // imageList_TabMainCameras
            // 
            this.imageList_TabMainCameras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_TabMainCameras.ImageStream")));
            this.imageList_TabMainCameras.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_TabMainCameras.Images.SetKeyName(0, "red.png");
            this.imageList_TabMainCameras.Images.SetKeyName(1, "gray.png");
            this.imageList_TabMainCameras.Images.SetKeyName(2, "green.png");
            // 
            // groupBox_MainStatistics
            // 
            this.groupBox_MainStatistics.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_MainStatistics.Controls.Add(this.label_MainStatisticsOverall);
            this.groupBox_MainStatistics.Controls.Add(this.label46);
            this.groupBox_MainStatistics.Controls.Add(this.label_MainStatisticsSuspicious);
            this.groupBox_MainStatistics.Controls.Add(this.label_MainStatisticsOverCount);
            this.groupBox_MainStatistics.Controls.Add(this.label44);
            this.groupBox_MainStatistics.Controls.Add(this.label_MainStatisticsOK);
            this.groupBox_MainStatistics.Controls.Add(this.label42);
            this.groupBox_MainStatistics.Controls.Add(this.label_MainStatisticsNOK);
            this.groupBox_MainStatistics.Controls.Add(this.label41);
            this.groupBox_MainStatistics.Controls.Add(this.label39);
            this.groupBox_MainStatistics.Location = new System.Drawing.Point(1518, 663);
            this.groupBox_MainStatistics.Name = "groupBox_MainStatistics";
            this.groupBox_MainStatistics.Size = new System.Drawing.Size(271, 258);
            this.groupBox_MainStatistics.TabIndex = 6;
            this.groupBox_MainStatistics.TabStop = false;
            this.groupBox_MainStatistics.Text = "Štatistika";
            // 
            // label_MainStatisticsOverall
            // 
            this.label_MainStatisticsOverall.AutoSize = true;
            this.label_MainStatisticsOverall.Location = new System.Drawing.Point(198, 164);
            this.label_MainStatisticsOverall.Name = "label_MainStatisticsOverall";
            this.label_MainStatisticsOverall.Size = new System.Drawing.Size(23, 20);
            this.label_MainStatisticsOverall.TabIndex = 0;
            this.label_MainStatisticsOverall.Text = "-1";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(17, 164);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(111, 20);
            this.label46.TabIndex = 0;
            this.label46.Text = "Celkový počet:";
            // 
            // label_MainStatisticsSuspicious
            // 
            this.label_MainStatisticsSuspicious.AutoSize = true;
            this.label_MainStatisticsSuspicious.Location = new System.Drawing.Point(198, 131);
            this.label_MainStatisticsSuspicious.Name = "label_MainStatisticsSuspicious";
            this.label_MainStatisticsSuspicious.Size = new System.Drawing.Size(23, 20);
            this.label_MainStatisticsSuspicious.TabIndex = 0;
            this.label_MainStatisticsSuspicious.Text = "-1";
            // 
            // label_MainStatisticsOverCount
            // 
            this.label_MainStatisticsOverCount.AutoSize = true;
            this.label_MainStatisticsOverCount.Location = new System.Drawing.Point(198, 98);
            this.label_MainStatisticsOverCount.Name = "label_MainStatisticsOverCount";
            this.label_MainStatisticsOverCount.Size = new System.Drawing.Size(23, 20);
            this.label_MainStatisticsOverCount.TabIndex = 0;
            this.label_MainStatisticsOverCount.Text = "-1";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(17, 131);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(140, 20);
            this.label44.TabIndex = 0;
            this.label44.Text = "Poč.podoz.dielcov:";
            // 
            // label_MainStatisticsOK
            // 
            this.label_MainStatisticsOK.AutoSize = true;
            this.label_MainStatisticsOK.Location = new System.Drawing.Point(198, 65);
            this.label_MainStatisticsOK.Name = "label_MainStatisticsOK";
            this.label_MainStatisticsOK.Size = new System.Drawing.Size(23, 20);
            this.label_MainStatisticsOK.TabIndex = 0;
            this.label_MainStatisticsOK.Text = "-1";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(17, 98);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(82, 20);
            this.label42.TabIndex = 0;
            this.label42.Text = "Nadpočet:";
            // 
            // label_MainStatisticsNOK
            // 
            this.label_MainStatisticsNOK.AutoSize = true;
            this.label_MainStatisticsNOK.Location = new System.Drawing.Point(198, 32);
            this.label_MainStatisticsNOK.Name = "label_MainStatisticsNOK";
            this.label_MainStatisticsNOK.Size = new System.Drawing.Size(23, 20);
            this.label_MainStatisticsNOK.TabIndex = 0;
            this.label_MainStatisticsNOK.Text = "-1";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(17, 65);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 20);
            this.label41.TabIndex = 0;
            this.label41.Text = "OK:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(17, 32);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(46, 20);
            this.label39.TabIndex = 0;
            this.label39.Text = "NOK:";
            // 
            // label_MainSystemMessage
            // 
            this.label_MainSystemMessage.Location = new System.Drawing.Point(950, 927);
            this.label_MainSystemMessage.Name = "label_MainSystemMessage";
            this.label_MainSystemMessage.Size = new System.Drawing.Size(72, 30);
            this.label_MainSystemMessage.TabIndex = 5;
            this.label_MainSystemMessage.Text = "Systém:";
            this.label_MainSystemMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_MainPoznamka
            // 
            this.label_MainPoznamka.Location = new System.Drawing.Point(6, 927);
            this.label_MainPoznamka.Name = "label_MainPoznamka";
            this.label_MainPoznamka.Size = new System.Drawing.Size(97, 30);
            this.label_MainPoznamka.TabIndex = 5;
            this.label_MainPoznamka.Text = "Poznámka:";
            this.label_MainPoznamka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1996, 924);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(450, 35);
            this.textBox3.TabIndex = 4;
            // 
            // textBox_MainSystemMessage
            // 
            this.textBox_MainSystemMessage.Location = new System.Drawing.Point(1028, 927);
            this.textBox_MainSystemMessage.Multiline = true;
            this.textBox_MainSystemMessage.Name = "textBox_MainSystemMessage";
            this.textBox_MainSystemMessage.Size = new System.Drawing.Size(474, 32);
            this.textBox_MainSystemMessage.TabIndex = 4;
            // 
            // textBox_MainPoznamka
            // 
            this.textBox_MainPoznamka.Location = new System.Drawing.Point(109, 927);
            this.textBox_MainPoznamka.Multiline = true;
            this.textBox_MainPoznamka.Name = "textBox_MainPoznamka";
            this.textBox_MainPoznamka.Size = new System.Drawing.Size(813, 32);
            this.textBox_MainPoznamka.TabIndex = 4;
            // 
            // groupBox_MainPodozrive
            // 
            this.groupBox_MainPodozrive.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_MainPodozrive.Controls.Add(this.progressBar_MainPodozrive);
            this.groupBox_MainPodozrive.Location = new System.Drawing.Point(1518, 571);
            this.groupBox_MainPodozrive.Name = "groupBox_MainPodozrive";
            this.groupBox_MainPodozrive.Size = new System.Drawing.Size(271, 86);
            this.groupBox_MainPodozrive.TabIndex = 3;
            this.groupBox_MainPodozrive.TabStop = false;
            this.groupBox_MainPodozrive.Text = "Podozrivé dielce";
            // 
            // progressBar_MainPodozrive
            // 
            this.progressBar_MainPodozrive.BackColor = System.Drawing.Color.DarkGray;
            this.progressBar_MainPodozrive.Location = new System.Drawing.Point(6, 38);
            this.progressBar_MainPodozrive.Maximum = 5;
            this.progressBar_MainPodozrive.Name = "progressBar_MainPodozrive";
            this.progressBar_MainPodozrive.Size = new System.Drawing.Size(263, 23);
            this.progressBar_MainPodozrive.TabIndex = 0;
            // 
            // groupBox_MainDielce
            // 
            this.groupBox_MainDielce.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_MainDielce.Controls.Add(this.pictureBox1);
            this.groupBox_MainDielce.Controls.Add(this.textBox_MainSearchRecipe);
            this.groupBox_MainDielce.Controls.Add(this.listBox_MainRecipe);
            this.groupBox_MainDielce.Location = new System.Drawing.Point(1518, 183);
            this.groupBox_MainDielce.Name = "groupBox_MainDielce";
            this.groupBox_MainDielce.Size = new System.Drawing.Size(271, 382);
            this.groupBox_MainDielce.TabIndex = 2;
            this.groupBox_MainDielce.TabStop = false;
            this.groupBox_MainDielce.Text = "Dielce";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IkeaUI.Properties.Resources.search_48px;
            this.pictureBox1.Location = new System.Drawing.Point(228, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_MainSearchRecipe
            // 
            this.textBox_MainSearchRecipe.Location = new System.Drawing.Point(6, 25);
            this.textBox_MainSearchRecipe.Name = "textBox_MainSearchRecipe";
            this.textBox_MainSearchRecipe.Size = new System.Drawing.Size(209, 26);
            this.textBox_MainSearchRecipe.TabIndex = 1;
            // 
            // listBox_MainRecipe
            // 
            this.listBox_MainRecipe.FormattingEnabled = true;
            this.listBox_MainRecipe.ItemHeight = 20;
            this.listBox_MainRecipe.Items.AddRange(new object[] {
            "ZSH09565",
            "DC02",
            "DC03",
            "DC04"});
            this.listBox_MainRecipe.Location = new System.Drawing.Point(6, 65);
            this.listBox_MainRecipe.Name = "listBox_MainRecipe";
            this.listBox_MainRecipe.Size = new System.Drawing.Size(259, 304);
            this.listBox_MainRecipe.TabIndex = 0;
            this.listBox_MainRecipe.SelectedIndexChanged += new System.EventHandler(this.listBox_MainRecipe_SelectedIndexChanged);
            // 
            // groupBox_MainRiadenie
            // 
            this.groupBox_MainRiadenie.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_MainRiadenie.Controls.Add(this.button_MainStop);
            this.groupBox_MainRiadenie.Controls.Add(this.button_MainSaveImg);
            this.groupBox_MainRiadenie.Controls.Add(this.button_MainStart);
            this.groupBox_MainRiadenie.Location = new System.Drawing.Point(1515, 6);
            this.groupBox_MainRiadenie.Name = "groupBox_MainRiadenie";
            this.groupBox_MainRiadenie.Size = new System.Drawing.Size(271, 171);
            this.groupBox_MainRiadenie.TabIndex = 1;
            this.groupBox_MainRiadenie.TabStop = false;
            this.groupBox_MainRiadenie.Text = "Riadenie";
            // 
            // button_MainStop
            // 
            this.button_MainStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_MainStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_MainStop.FlatAppearance.BorderSize = 2;
            this.button_MainStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MainStop.Location = new System.Drawing.Point(138, 25);
            this.button_MainStop.Name = "button_MainStop";
            this.button_MainStop.Size = new System.Drawing.Size(127, 60);
            this.button_MainStop.TabIndex = 2;
            this.button_MainStop.Text = "Stop";
            this.button_MainStop.UseVisualStyleBackColor = false;
            this.button_MainStop.Click += new System.EventHandler(this.button_MainStop_Click);
            // 
            // button_MainSaveImg
            // 
            this.button_MainSaveImg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_MainSaveImg.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_MainSaveImg.FlatAppearance.BorderSize = 2;
            this.button_MainSaveImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MainSaveImg.Location = new System.Drawing.Point(9, 116);
            this.button_MainSaveImg.Name = "button_MainSaveImg";
            this.button_MainSaveImg.Size = new System.Drawing.Size(256, 49);
            this.button_MainSaveImg.TabIndex = 1;
            this.button_MainSaveImg.Text = "Uložiť Aktuálny Obraz";
            this.button_MainSaveImg.UseVisualStyleBackColor = false;
            // 
            // button_MainStart
            // 
            this.button_MainStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_MainStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_MainStart.FlatAppearance.BorderSize = 2;
            this.button_MainStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MainStart.Location = new System.Drawing.Point(9, 25);
            this.button_MainStart.Name = "button_MainStart";
            this.button_MainStart.Size = new System.Drawing.Size(127, 60);
            this.button_MainStart.TabIndex = 1;
            this.button_MainStart.Text = "Štart";
            this.button_MainStart.UseVisualStyleBackColor = false;
            this.button_MainStart.Click += new System.EventHandler(this.button_MainStart_Click);
            // 
            // tabPage_Archive
            // 
            this.tabPage_Archive.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Archive.Controls.Add(this.groupBox_ArchiveDrawingSides);
            this.tabPage_Archive.Controls.Add(this.button_TakeInfoFromDB);
            this.tabPage_Archive.Controls.Add(this.button_RefreshTable);
            this.tabPage_Archive.Controls.Add(this.groupBox_Holes);
            this.tabPage_Archive.Controls.Add(this.groupBox_Boards);
            this.tabPage_Archive.Controls.Add(this.groupBox_Hwindow);
            this.tabPage_Archive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage_Archive.Location = new System.Drawing.Point(124, 4);
            this.tabPage_Archive.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_Archive.Name = "tabPage_Archive";
            this.tabPage_Archive.Size = new System.Drawing.Size(1792, 1007);
            this.tabPage_Archive.TabIndex = 1;
            this.tabPage_Archive.Text = "Archív";
            // 
            // groupBox_ArchiveDrawingSides
            // 
            this.groupBox_ArchiveDrawingSides.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_ArchiveDrawingSides.Controls.Add(this.dataGridView_ArchiveDrawingSides);
            this.groupBox_ArchiveDrawingSides.Location = new System.Drawing.Point(1192, 315);
            this.groupBox_ArchiveDrawingSides.Name = "groupBox_ArchiveDrawingSides";
            this.groupBox_ArchiveDrawingSides.Size = new System.Drawing.Size(594, 206);
            this.groupBox_ArchiveDrawingSides.TabIndex = 4;
            this.groupBox_ArchiveDrawingSides.TabStop = false;
            this.groupBox_ArchiveDrawingSides.Text = "Pohľady";
            // 
            // dataGridView_ArchiveDrawingSides
            // 
            this.dataGridView_ArchiveDrawingSides.AllowUserToAddRows = false;
            this.dataGridView_ArchiveDrawingSides.AllowUserToDeleteRows = false;
            this.dataGridView_ArchiveDrawingSides.AllowUserToResizeColumns = false;
            this.dataGridView_ArchiveDrawingSides.AllowUserToResizeRows = false;
            this.dataGridView_ArchiveDrawingSides.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ArchiveDrawingSides.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_ArchiveDrawingSides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ArchiveDrawingSides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrawingSideName,
            this.dataGridViewTextBoxColumn1,
            this.HolesCount,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView_ArchiveDrawingSides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ArchiveDrawingSides.Location = new System.Drawing.Point(3, 22);
            this.dataGridView_ArchiveDrawingSides.MultiSelect = false;
            this.dataGridView_ArchiveDrawingSides.Name = "dataGridView_ArchiveDrawingSides";
            this.dataGridView_ArchiveDrawingSides.RowHeadersVisible = false;
            this.dataGridView_ArchiveDrawingSides.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_ArchiveDrawingSides.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ArchiveDrawingSides.Size = new System.Drawing.Size(588, 181);
            this.dataGridView_ArchiveDrawingSides.TabIndex = 0;
            this.dataGridView_ArchiveDrawingSides.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ArchiveDrawingSides_CellClick);
            // 
            // DrawingSideName
            // 
            this.DrawingSideName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DrawingSideName.HeaderText = "Názov";
            this.DrawingSideName.Name = "DrawingSideName";
            this.DrawingSideName.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 80.58376F;
            this.dataGridViewTextBoxColumn1.HeaderText = "TimeStamp";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // HolesCount
            // 
            this.HolesCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HolesCount.HeaderText = "Poč. dier";
            this.HolesCount.Name = "HolesCount";
            this.HolesCount.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.FillWeight = 177.665F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // button_TakeInfoFromDB
            // 
            this.button_TakeInfoFromDB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_TakeInfoFromDB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_TakeInfoFromDB.FlatAppearance.BorderSize = 2;
            this.button_TakeInfoFromDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_TakeInfoFromDB.Location = new System.Drawing.Point(1580, 904);
            this.button_TakeInfoFromDB.Name = "button_TakeInfoFromDB";
            this.button_TakeInfoFromDB.Size = new System.Drawing.Size(100, 50);
            this.button_TakeInfoFromDB.TabIndex = 3;
            this.button_TakeInfoFromDB.Text = "Take";
            this.button_TakeInfoFromDB.UseVisualStyleBackColor = false;
            this.button_TakeInfoFromDB.Click += new System.EventHandler(this.button_TakeInfoFromDB_Click);
            // 
            // button_RefreshTable
            // 
            this.button_RefreshTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_RefreshTable.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_RefreshTable.FlatAppearance.BorderSize = 2;
            this.button_RefreshTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RefreshTable.Location = new System.Drawing.Point(1686, 904);
            this.button_RefreshTable.Name = "button_RefreshTable";
            this.button_RefreshTable.Size = new System.Drawing.Size(100, 50);
            this.button_RefreshTable.TabIndex = 3;
            this.button_RefreshTable.Text = "Obnoviť";
            this.button_RefreshTable.UseVisualStyleBackColor = false;
            this.button_RefreshTable.Click += new System.EventHandler(this.button_RefreshTable_Click);
            // 
            // groupBox_Holes
            // 
            this.groupBox_Holes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_Holes.Controls.Add(this.dataGridView_HolesData);
            this.groupBox_Holes.Location = new System.Drawing.Point(1192, 527);
            this.groupBox_Holes.Name = "groupBox_Holes";
            this.groupBox_Holes.Size = new System.Drawing.Size(594, 371);
            this.groupBox_Holes.TabIndex = 2;
            this.groupBox_Holes.TabStop = false;
            this.groupBox_Holes.Text = "Diery";
            // 
            // dataGridView_HolesData
            // 
            this.dataGridView_HolesData.AllowUserToAddRows = false;
            this.dataGridView_HolesData.AllowUserToDeleteRows = false;
            this.dataGridView_HolesData.AllowUserToResizeColumns = false;
            this.dataGridView_HolesData.AllowUserToResizeRows = false;
            this.dataGridView_HolesData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_HolesData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_HolesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HolesData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStampHoles,
            this.X,
            this.Y,
            this.Radius,
            this.StatusHoles});
            this.dataGridView_HolesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_HolesData.Location = new System.Drawing.Point(3, 22);
            this.dataGridView_HolesData.MultiSelect = false;
            this.dataGridView_HolesData.Name = "dataGridView_HolesData";
            this.dataGridView_HolesData.RowHeadersVisible = false;
            this.dataGridView_HolesData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_HolesData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_HolesData.Size = new System.Drawing.Size(588, 346);
            this.dataGridView_HolesData.TabIndex = 0;
            // 
            // TimeStampHoles
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TimeStampHoles.DefaultCellStyle = dataGridViewCellStyle3;
            this.TimeStampHoles.FillWeight = 80.58376F;
            this.TimeStampHoles.HeaderText = "TimeStamp";
            this.TimeStampHoles.Name = "TimeStampHoles";
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.X.DefaultCellStyle = dataGridViewCellStyle4;
            this.X.FillWeight = 80.58376F;
            this.X.HeaderText = "X[mm]";
            this.X.Name = "X";
            this.X.Width = 90;
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Y.DefaultCellStyle = dataGridViewCellStyle5;
            this.Y.FillWeight = 80.58376F;
            this.Y.HeaderText = "Y[mm]";
            this.Y.Name = "Y";
            this.Y.Width = 90;
            // 
            // Radius
            // 
            this.Radius.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Radius.DefaultCellStyle = dataGridViewCellStyle6;
            this.Radius.FillWeight = 80.58376F;
            this.Radius.HeaderText = "Radius[mm]";
            this.Radius.Name = "Radius";
            this.Radius.Width = 110;
            // 
            // StatusHoles
            // 
            this.StatusHoles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.StatusHoles.DefaultCellStyle = dataGridViewCellStyle7;
            this.StatusHoles.FillWeight = 177.665F;
            this.StatusHoles.HeaderText = "Status";
            this.StatusHoles.Name = "StatusHoles";
            // 
            // groupBox_Boards
            // 
            this.groupBox_Boards.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_Boards.Controls.Add(this.dataGridView_Data);
            this.groupBox_Boards.Location = new System.Drawing.Point(1192, 5);
            this.groupBox_Boards.Name = "groupBox_Boards";
            this.groupBox_Boards.Size = new System.Drawing.Size(594, 304);
            this.groupBox_Boards.TabIndex = 2;
            this.groupBox_Boards.TabStop = false;
            this.groupBox_Boards.Text = "Dielce";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.AllowUserToAddRows = false;
            this.dataGridView_Data.AllowUserToDeleteRows = false;
            this.dataGridView_Data.AllowUserToResizeColumns = false;
            this.dataGridView_Data.AllowUserToResizeRows = false;
            this.dataGridView_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Data.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialName,
            this.TimeStamp,
            this.DrawingSidesCount,
            this.Status});
            this.dataGridView_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Data.Location = new System.Drawing.Point(3, 22);
            this.dataGridView_Data.MultiSelect = false;
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.RowHeadersVisible = false;
            this.dataGridView_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Data.Size = new System.Drawing.Size(588, 279);
            this.dataGridView_Data.TabIndex = 1;
            this.dataGridView_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Data_CellClick);
            // 
            // MaterialName
            // 
            this.MaterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaterialName.HeaderText = "Názov";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.Width = 120;
            // 
            // TimeStamp
            // 
            this.TimeStamp.HeaderText = "TimeStamp";
            this.TimeStamp.Name = "TimeStamp";
            // 
            // DrawingSidesCount
            // 
            this.DrawingSidesCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DrawingSidesCount.HeaderText = "Poč.pohľadov";
            this.DrawingSidesCount.Name = "DrawingSidesCount";
            this.DrawingSidesCount.Width = 150;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // groupBox_Hwindow
            // 
            this.groupBox_Hwindow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_Hwindow.Controls.Add(this.Hwindow_ArchiveImage);
            this.groupBox_Hwindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Hwindow.Location = new System.Drawing.Point(4, 4);
            this.groupBox_Hwindow.Name = "groupBox_Hwindow";
            this.groupBox_Hwindow.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox_Hwindow.Size = new System.Drawing.Size(1181, 955);
            this.groupBox_Hwindow.TabIndex = 1;
            this.groupBox_Hwindow.TabStop = false;
            this.groupBox_Hwindow.Text = "Obraz";
            // 
            // Hwindow_ArchiveImage
            // 
            this.Hwindow_ArchiveImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_ArchiveImage.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_ArchiveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_ArchiveImage.HDoubleClickToFitContent = true;
            this.Hwindow_ArchiveImage.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_ArchiveImage.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.Hwindow_ArchiveImage.HKeepAspectRatio = true;
            this.Hwindow_ArchiveImage.HMoveContent = true;
            this.Hwindow_ArchiveImage.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.Hwindow_ArchiveImage.Location = new System.Drawing.Point(7, 26);
            this.Hwindow_ArchiveImage.Margin = new System.Windows.Forms.Padding(7);
            this.Hwindow_ArchiveImage.Name = "Hwindow_ArchiveImage";
            this.Hwindow_ArchiveImage.Size = new System.Drawing.Size(1167, 922);
            this.Hwindow_ArchiveImage.TabIndex = 0;
            this.Hwindow_ArchiveImage.WindowSize = new System.Drawing.Size(1167, 922);
            // 
            // tabPage_Diagnostics
            // 
            this.tabPage_Diagnostics.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage_Diagnostics.Controls.Add(this.panel_DiagnosticsAutorization);
            this.tabPage_Diagnostics.Controls.Add(this.button_DiagnosticsAutorisation);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsVstupy);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsVykres);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsOutputs);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsCamSettings);
            this.tabPage_Diagnostics.Controls.Add(this.label_Diagnostics);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsCamInfo);
            this.tabPage_Diagnostics.Controls.Add(this.groupBox_DiagnosticsDiscManagement);
            this.tabPage_Diagnostics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage_Diagnostics.Location = new System.Drawing.Point(124, 4);
            this.tabPage_Diagnostics.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_Diagnostics.Name = "tabPage_Diagnostics";
            this.tabPage_Diagnostics.Size = new System.Drawing.Size(1792, 1007);
            this.tabPage_Diagnostics.TabIndex = 2;
            this.tabPage_Diagnostics.Text = "Servis";
            // 
            // panel_DiagnosticsAutorization
            // 
            this.panel_DiagnosticsAutorization.BackColor = System.Drawing.Color.Silver;
            this.panel_DiagnosticsAutorization.Controls.Add(this.button_DiagnosticsChangePassword);
            this.panel_DiagnosticsAutorization.Controls.Add(this.button_DiagnosticsLogOff);
            this.panel_DiagnosticsAutorization.Controls.Add(this.button_DiagnosticsLogIn);
            this.panel_DiagnosticsAutorization.Controls.Add(this.textBox_UserPassword);
            this.panel_DiagnosticsAutorization.Controls.Add(this.label38);
            this.panel_DiagnosticsAutorization.Location = new System.Drawing.Point(166, 782);
            this.panel_DiagnosticsAutorization.Name = "panel_DiagnosticsAutorization";
            this.panel_DiagnosticsAutorization.Size = new System.Drawing.Size(331, 172);
            this.panel_DiagnosticsAutorization.TabIndex = 14;
            // 
            // button_DiagnosticsChangePassword
            // 
            this.button_DiagnosticsChangePassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsChangePassword.Enabled = false;
            this.button_DiagnosticsChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsChangePassword.Location = new System.Drawing.Point(193, 76);
            this.button_DiagnosticsChangePassword.Name = "button_DiagnosticsChangePassword";
            this.button_DiagnosticsChangePassword.Size = new System.Drawing.Size(101, 29);
            this.button_DiagnosticsChangePassword.TabIndex = 1;
            this.button_DiagnosticsChangePassword.Text = "Zmeniť";
            this.button_DiagnosticsChangePassword.UseVisualStyleBackColor = false;
            this.button_DiagnosticsChangePassword.Click += new System.EventHandler(this.button_DiagnosticsChangePassword_Click);
            // 
            // button_DiagnosticsLogOff
            // 
            this.button_DiagnosticsLogOff.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsLogOff.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsLogOff.Location = new System.Drawing.Point(78, 112);
            this.button_DiagnosticsLogOff.Name = "button_DiagnosticsLogOff";
            this.button_DiagnosticsLogOff.Size = new System.Drawing.Size(101, 29);
            this.button_DiagnosticsLogOff.TabIndex = 1;
            this.button_DiagnosticsLogOff.Text = "Odhlasiť sa";
            this.button_DiagnosticsLogOff.UseVisualStyleBackColor = false;
            this.button_DiagnosticsLogOff.Click += new System.EventHandler(this.button_DiagnosticsLogOff_Click);
            // 
            // button_DiagnosticsLogIn
            // 
            this.button_DiagnosticsLogIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsLogIn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsLogIn.Location = new System.Drawing.Point(78, 76);
            this.button_DiagnosticsLogIn.Name = "button_DiagnosticsLogIn";
            this.button_DiagnosticsLogIn.Size = new System.Drawing.Size(101, 29);
            this.button_DiagnosticsLogIn.TabIndex = 1;
            this.button_DiagnosticsLogIn.Text = "Prihlásiť sa";
            this.button_DiagnosticsLogIn.UseVisualStyleBackColor = false;
            this.button_DiagnosticsLogIn.Click += new System.EventHandler(this.button_DiagnosticsLogIn_Click);
            // 
            // textBox_UserPassword
            // 
            this.textBox_UserPassword.Location = new System.Drawing.Point(78, 29);
            this.textBox_UserPassword.Name = "textBox_UserPassword";
            this.textBox_UserPassword.Size = new System.Drawing.Size(216, 26);
            this.textBox_UserPassword.TabIndex = 0;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 32);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(58, 20);
            this.label38.TabIndex = 0;
            this.label38.Text = "Heslo: ";
            // 
            // button_DiagnosticsAutorisation
            // 
            this.button_DiagnosticsAutorisation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsAutorisation.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsAutorisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsAutorisation.Location = new System.Drawing.Point(8, 894);
            this.button_DiagnosticsAutorisation.Name = "button_DiagnosticsAutorisation";
            this.button_DiagnosticsAutorisation.Size = new System.Drawing.Size(120, 60);
            this.button_DiagnosticsAutorisation.TabIndex = 13;
            this.button_DiagnosticsAutorisation.Text = "Administrátor";
            this.button_DiagnosticsAutorisation.UseVisualStyleBackColor = false;
            this.button_DiagnosticsAutorisation.Click += new System.EventHandler(this.button_Autorization_Click);
            // 
            // groupBox_DiagnosticsVstupy
            // 
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput7);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput6);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput5);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput4);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput3);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput2);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput1);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.button_DiagnosticsInput0);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput6);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput3);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput0);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput7);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput5);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput4);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput2);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.pictureBox_DiagnosticsInput1);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label8);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label40);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label43);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label45);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label47);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label49);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label51);
            this.groupBox_DiagnosticsVstupy.Controls.Add(this.label52);
            this.groupBox_DiagnosticsVstupy.Location = new System.Drawing.Point(286, 244);
            this.groupBox_DiagnosticsVstupy.Name = "groupBox_DiagnosticsVstupy";
            this.groupBox_DiagnosticsVstupy.Size = new System.Drawing.Size(211, 528);
            this.groupBox_DiagnosticsVstupy.TabIndex = 12;
            this.groupBox_DiagnosticsVstupy.TabStop = false;
            this.groupBox_DiagnosticsVstupy.Text = "Vstupy";
            // 
            // button_DiagnosticsInput7
            // 
            this.button_DiagnosticsInput7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput7.Location = new System.Drawing.Point(111, 281);
            this.button_DiagnosticsInput7.Name = "button_DiagnosticsInput7";
            this.button_DiagnosticsInput7.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput7.TabIndex = 12;
            this.button_DiagnosticsInput7.Text = "Nastaviť";
            this.button_DiagnosticsInput7.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput7.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput6
            // 
            this.button_DiagnosticsInput6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput6.Location = new System.Drawing.Point(111, 246);
            this.button_DiagnosticsInput6.Name = "button_DiagnosticsInput6";
            this.button_DiagnosticsInput6.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput6.TabIndex = 12;
            this.button_DiagnosticsInput6.Text = "Nastaviť";
            this.button_DiagnosticsInput6.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput6.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput5
            // 
            this.button_DiagnosticsInput5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput5.Location = new System.Drawing.Point(111, 212);
            this.button_DiagnosticsInput5.Name = "button_DiagnosticsInput5";
            this.button_DiagnosticsInput5.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput5.TabIndex = 12;
            this.button_DiagnosticsInput5.Text = "Nastaviť";
            this.button_DiagnosticsInput5.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput5.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput4
            // 
            this.button_DiagnosticsInput4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput4.Location = new System.Drawing.Point(111, 177);
            this.button_DiagnosticsInput4.Name = "button_DiagnosticsInput4";
            this.button_DiagnosticsInput4.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput4.TabIndex = 12;
            this.button_DiagnosticsInput4.Text = "Nastaviť";
            this.button_DiagnosticsInput4.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput4.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput3
            // 
            this.button_DiagnosticsInput3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput3.Location = new System.Drawing.Point(111, 142);
            this.button_DiagnosticsInput3.Name = "button_DiagnosticsInput3";
            this.button_DiagnosticsInput3.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput3.TabIndex = 12;
            this.button_DiagnosticsInput3.Text = "Nastaviť";
            this.button_DiagnosticsInput3.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput3.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput2
            // 
            this.button_DiagnosticsInput2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput2.Location = new System.Drawing.Point(111, 107);
            this.button_DiagnosticsInput2.Name = "button_DiagnosticsInput2";
            this.button_DiagnosticsInput2.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput2.TabIndex = 12;
            this.button_DiagnosticsInput2.Text = "Nastaviť";
            this.button_DiagnosticsInput2.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput2.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput1
            // 
            this.button_DiagnosticsInput1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput1.Location = new System.Drawing.Point(111, 72);
            this.button_DiagnosticsInput1.Name = "button_DiagnosticsInput1";
            this.button_DiagnosticsInput1.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput1.TabIndex = 12;
            this.button_DiagnosticsInput1.Text = "Nastaviť";
            this.button_DiagnosticsInput1.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput1.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // button_DiagnosticsInput0
            // 
            this.button_DiagnosticsInput0.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsInput0.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsInput0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsInput0.Location = new System.Drawing.Point(111, 37);
            this.button_DiagnosticsInput0.Name = "button_DiagnosticsInput0";
            this.button_DiagnosticsInput0.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsInput0.TabIndex = 12;
            this.button_DiagnosticsInput0.Text = "Nastaviť";
            this.button_DiagnosticsInput0.UseVisualStyleBackColor = false;
            this.button_DiagnosticsInput0.Click += new System.EventHandler(this.button_DiagnosticsInput_Click);
            // 
            // pictureBox_DiagnosticsInput6
            // 
            this.pictureBox_DiagnosticsInput6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput6.Image")));
            this.pictureBox_DiagnosticsInput6.Location = new System.Drawing.Point(55, 246);
            this.pictureBox_DiagnosticsInput6.Name = "pictureBox_DiagnosticsInput6";
            this.pictureBox_DiagnosticsInput6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput6.TabIndex = 2;
            this.pictureBox_DiagnosticsInput6.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput3
            // 
            this.pictureBox_DiagnosticsInput3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput3.Image")));
            this.pictureBox_DiagnosticsInput3.Location = new System.Drawing.Point(55, 142);
            this.pictureBox_DiagnosticsInput3.Name = "pictureBox_DiagnosticsInput3";
            this.pictureBox_DiagnosticsInput3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput3.TabIndex = 3;
            this.pictureBox_DiagnosticsInput3.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput0
            // 
            this.pictureBox_DiagnosticsInput0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput0.Image")));
            this.pictureBox_DiagnosticsInput0.Location = new System.Drawing.Point(55, 37);
            this.pictureBox_DiagnosticsInput0.Name = "pictureBox_DiagnosticsInput0";
            this.pictureBox_DiagnosticsInput0.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput0.TabIndex = 4;
            this.pictureBox_DiagnosticsInput0.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput7
            // 
            this.pictureBox_DiagnosticsInput7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput7.Image")));
            this.pictureBox_DiagnosticsInput7.Location = new System.Drawing.Point(55, 281);
            this.pictureBox_DiagnosticsInput7.Name = "pictureBox_DiagnosticsInput7";
            this.pictureBox_DiagnosticsInput7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput7.TabIndex = 5;
            this.pictureBox_DiagnosticsInput7.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput5
            // 
            this.pictureBox_DiagnosticsInput5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput5.Image")));
            this.pictureBox_DiagnosticsInput5.Location = new System.Drawing.Point(55, 212);
            this.pictureBox_DiagnosticsInput5.Name = "pictureBox_DiagnosticsInput5";
            this.pictureBox_DiagnosticsInput5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput5.TabIndex = 6;
            this.pictureBox_DiagnosticsInput5.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput4
            // 
            this.pictureBox_DiagnosticsInput4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput4.Image")));
            this.pictureBox_DiagnosticsInput4.Location = new System.Drawing.Point(55, 177);
            this.pictureBox_DiagnosticsInput4.Name = "pictureBox_DiagnosticsInput4";
            this.pictureBox_DiagnosticsInput4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput4.TabIndex = 7;
            this.pictureBox_DiagnosticsInput4.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput2
            // 
            this.pictureBox_DiagnosticsInput2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput2.Image")));
            this.pictureBox_DiagnosticsInput2.Location = new System.Drawing.Point(55, 107);
            this.pictureBox_DiagnosticsInput2.Name = "pictureBox_DiagnosticsInput2";
            this.pictureBox_DiagnosticsInput2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput2.TabIndex = 8;
            this.pictureBox_DiagnosticsInput2.TabStop = false;
            // 
            // pictureBox_DiagnosticsInput1
            // 
            this.pictureBox_DiagnosticsInput1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsInput1.Image")));
            this.pictureBox_DiagnosticsInput1.Location = new System.Drawing.Point(55, 72);
            this.pictureBox_DiagnosticsInput1.Name = "pictureBox_DiagnosticsInput1";
            this.pictureBox_DiagnosticsInput1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsInput1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsInput1.TabIndex = 9;
            this.pictureBox_DiagnosticsInput1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "D00:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(11, 286);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(43, 20);
            this.label40.TabIndex = 0;
            this.label40.Text = "D07:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(11, 182);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(43, 20);
            this.label43.TabIndex = 0;
            this.label43.Text = "D04:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(11, 251);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(43, 20);
            this.label45.TabIndex = 0;
            this.label45.Text = "D06:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(11, 147);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(43, 20);
            this.label47.TabIndex = 0;
            this.label47.Text = "D03:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(11, 217);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(43, 20);
            this.label49.TabIndex = 0;
            this.label49.Text = "D05:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(11, 112);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(43, 20);
            this.label51.TabIndex = 0;
            this.label51.Text = "D02:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(11, 77);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(43, 20);
            this.label52.TabIndex = 0;
            this.label52.Text = "D01:";
            // 
            // groupBox_DiagnosticsVykres
            // 
            this.groupBox_DiagnosticsVykres.Controls.Add(this.Hwindow_Diagnostika);
            this.groupBox_DiagnosticsVykres.Location = new System.Drawing.Point(759, 71);
            this.groupBox_DiagnosticsVykres.Name = "groupBox_DiagnosticsVykres";
            this.groupBox_DiagnosticsVykres.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_DiagnosticsVykres.Size = new System.Drawing.Size(1030, 889);
            this.groupBox_DiagnosticsVykres.TabIndex = 5;
            this.groupBox_DiagnosticsVykres.TabStop = false;
            this.groupBox_DiagnosticsVykres.Text = "Výkres";
            // 
            // Hwindow_Diagnostika
            // 
            this.Hwindow_Diagnostika.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Hwindow_Diagnostika.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Hwindow_Diagnostika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hwindow_Diagnostika.HDoubleClickToFitContent = true;
            this.Hwindow_Diagnostika.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.Hwindow_Diagnostika.HImagePart = new System.Drawing.Rectangle(0, 0, 800, 480);
            this.Hwindow_Diagnostika.HKeepAspectRatio = true;
            this.Hwindow_Diagnostika.HMoveContent = true;
            this.Hwindow_Diagnostika.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelBackwardZoomsIn;
            this.Hwindow_Diagnostika.Location = new System.Drawing.Point(0, 19);
            this.Hwindow_Diagnostika.Margin = new System.Windows.Forms.Padding(0);
            this.Hwindow_Diagnostika.Name = "Hwindow_Diagnostika";
            this.Hwindow_Diagnostika.Size = new System.Drawing.Size(1030, 870);
            this.Hwindow_Diagnostika.TabIndex = 4;
            this.Hwindow_Diagnostika.WindowSize = new System.Drawing.Size(1030, 870);
            // 
            // groupBox_DiagnosticsOutputs
            // 
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput15);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput7);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput14);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput6);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput13);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput5);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput12);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput4);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput11);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput3);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput10);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput2);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput9);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput8);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput1);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.button_DiagnosticsOutput0);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput14);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput6);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput11);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput3);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput0);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput8);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput15);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput7);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput13);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput5);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput12);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_Indicator4);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput10);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput2);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput9);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.pictureBox_DiagnosticsOutput1);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label37);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label29);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label36);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label28);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label35);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label34);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label24);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label33);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label27);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label32);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label22);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label31);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label26);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label30);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label18);
            this.groupBox_DiagnosticsOutputs.Controls.Add(this.label19);
            this.groupBox_DiagnosticsOutputs.Location = new System.Drawing.Point(503, 244);
            this.groupBox_DiagnosticsOutputs.Name = "groupBox_DiagnosticsOutputs";
            this.groupBox_DiagnosticsOutputs.Size = new System.Drawing.Size(250, 605);
            this.groupBox_DiagnosticsOutputs.TabIndex = 3;
            this.groupBox_DiagnosticsOutputs.TabStop = false;
            this.groupBox_DiagnosticsOutputs.Text = "Výstupy";
            // 
            // button_DiagnosticsOutput15
            // 
            this.button_DiagnosticsOutput15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput15.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput15.Location = new System.Drawing.Point(109, 560);
            this.button_DiagnosticsOutput15.Name = "button_DiagnosticsOutput15";
            this.button_DiagnosticsOutput15.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput15.TabIndex = 12;
            this.button_DiagnosticsOutput15.Text = "Nastaviť";
            this.button_DiagnosticsOutput15.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput7
            // 
            this.button_DiagnosticsOutput7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput7.Location = new System.Drawing.Point(109, 281);
            this.button_DiagnosticsOutput7.Name = "button_DiagnosticsOutput7";
            this.button_DiagnosticsOutput7.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput7.TabIndex = 12;
            this.button_DiagnosticsOutput7.Text = "Nastaviť";
            this.button_DiagnosticsOutput7.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput14
            // 
            this.button_DiagnosticsOutput14.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput14.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput14.Location = new System.Drawing.Point(109, 525);
            this.button_DiagnosticsOutput14.Name = "button_DiagnosticsOutput14";
            this.button_DiagnosticsOutput14.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput14.TabIndex = 12;
            this.button_DiagnosticsOutput14.Text = "Nastaviť";
            this.button_DiagnosticsOutput14.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput6
            // 
            this.button_DiagnosticsOutput6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput6.Location = new System.Drawing.Point(109, 246);
            this.button_DiagnosticsOutput6.Name = "button_DiagnosticsOutput6";
            this.button_DiagnosticsOutput6.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput6.TabIndex = 12;
            this.button_DiagnosticsOutput6.Text = "Nastaviť";
            this.button_DiagnosticsOutput6.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput13
            // 
            this.button_DiagnosticsOutput13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput13.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput13.Location = new System.Drawing.Point(109, 490);
            this.button_DiagnosticsOutput13.Name = "button_DiagnosticsOutput13";
            this.button_DiagnosticsOutput13.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput13.TabIndex = 12;
            this.button_DiagnosticsOutput13.Text = "Nastaviť";
            this.button_DiagnosticsOutput13.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput5
            // 
            this.button_DiagnosticsOutput5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput5.Location = new System.Drawing.Point(109, 212);
            this.button_DiagnosticsOutput5.Name = "button_DiagnosticsOutput5";
            this.button_DiagnosticsOutput5.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput5.TabIndex = 12;
            this.button_DiagnosticsOutput5.Text = "Nastaviť";
            this.button_DiagnosticsOutput5.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput12
            // 
            this.button_DiagnosticsOutput12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput12.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput12.Location = new System.Drawing.Point(109, 455);
            this.button_DiagnosticsOutput12.Name = "button_DiagnosticsOutput12";
            this.button_DiagnosticsOutput12.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput12.TabIndex = 12;
            this.button_DiagnosticsOutput12.Text = "Nastaviť";
            this.button_DiagnosticsOutput12.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput4
            // 
            this.button_DiagnosticsOutput4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput4.Location = new System.Drawing.Point(109, 177);
            this.button_DiagnosticsOutput4.Name = "button_DiagnosticsOutput4";
            this.button_DiagnosticsOutput4.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput4.TabIndex = 12;
            this.button_DiagnosticsOutput4.Text = "Nastaviť";
            this.button_DiagnosticsOutput4.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput11
            // 
            this.button_DiagnosticsOutput11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput11.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput11.Location = new System.Drawing.Point(109, 420);
            this.button_DiagnosticsOutput11.Name = "button_DiagnosticsOutput11";
            this.button_DiagnosticsOutput11.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput11.TabIndex = 12;
            this.button_DiagnosticsOutput11.Text = "Nastaviť";
            this.button_DiagnosticsOutput11.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput3
            // 
            this.button_DiagnosticsOutput3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput3.Location = new System.Drawing.Point(109, 142);
            this.button_DiagnosticsOutput3.Name = "button_DiagnosticsOutput3";
            this.button_DiagnosticsOutput3.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput3.TabIndex = 12;
            this.button_DiagnosticsOutput3.Text = "Nastaviť";
            this.button_DiagnosticsOutput3.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput10
            // 
            this.button_DiagnosticsOutput10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput10.Location = new System.Drawing.Point(109, 385);
            this.button_DiagnosticsOutput10.Name = "button_DiagnosticsOutput10";
            this.button_DiagnosticsOutput10.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput10.TabIndex = 12;
            this.button_DiagnosticsOutput10.Text = "Nastaviť";
            this.button_DiagnosticsOutput10.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput2
            // 
            this.button_DiagnosticsOutput2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput2.Location = new System.Drawing.Point(109, 107);
            this.button_DiagnosticsOutput2.Name = "button_DiagnosticsOutput2";
            this.button_DiagnosticsOutput2.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput2.TabIndex = 12;
            this.button_DiagnosticsOutput2.Text = "Nastaviť";
            this.button_DiagnosticsOutput2.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput9
            // 
            this.button_DiagnosticsOutput9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput9.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput9.Location = new System.Drawing.Point(109, 350);
            this.button_DiagnosticsOutput9.Name = "button_DiagnosticsOutput9";
            this.button_DiagnosticsOutput9.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput9.TabIndex = 12;
            this.button_DiagnosticsOutput9.Text = "Nastaviť";
            this.button_DiagnosticsOutput9.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput8
            // 
            this.button_DiagnosticsOutput8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput8.Location = new System.Drawing.Point(109, 316);
            this.button_DiagnosticsOutput8.Name = "button_DiagnosticsOutput8";
            this.button_DiagnosticsOutput8.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput8.TabIndex = 12;
            this.button_DiagnosticsOutput8.Text = "Nastaviť";
            this.button_DiagnosticsOutput8.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput1
            // 
            this.button_DiagnosticsOutput1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput1.Location = new System.Drawing.Point(109, 72);
            this.button_DiagnosticsOutput1.Name = "button_DiagnosticsOutput1";
            this.button_DiagnosticsOutput1.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput1.TabIndex = 12;
            this.button_DiagnosticsOutput1.Text = "Nastaviť";
            this.button_DiagnosticsOutput1.UseVisualStyleBackColor = false;
            // 
            // button_DiagnosticsOutput0
            // 
            this.button_DiagnosticsOutput0.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsOutput0.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsOutput0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsOutput0.Location = new System.Drawing.Point(109, 37);
            this.button_DiagnosticsOutput0.Name = "button_DiagnosticsOutput0";
            this.button_DiagnosticsOutput0.Size = new System.Drawing.Size(83, 30);
            this.button_DiagnosticsOutput0.TabIndex = 12;
            this.button_DiagnosticsOutput0.Text = "Nastaviť";
            this.button_DiagnosticsOutput0.UseVisualStyleBackColor = false;
            this.button_DiagnosticsOutput0.Click += new System.EventHandler(this.button_DiagnosticsOutput0_Click);
            // 
            // pictureBox_DiagnosticsOutput14
            // 
            this.pictureBox_DiagnosticsOutput14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput14.Image")));
            this.pictureBox_DiagnosticsOutput14.Location = new System.Drawing.Point(55, 525);
            this.pictureBox_DiagnosticsOutput14.Name = "pictureBox_DiagnosticsOutput14";
            this.pictureBox_DiagnosticsOutput14.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput14.TabIndex = 2;
            this.pictureBox_DiagnosticsOutput14.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput6
            // 
            this.pictureBox_DiagnosticsOutput6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput6.Image")));
            this.pictureBox_DiagnosticsOutput6.Location = new System.Drawing.Point(55, 246);
            this.pictureBox_DiagnosticsOutput6.Name = "pictureBox_DiagnosticsOutput6";
            this.pictureBox_DiagnosticsOutput6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput6.TabIndex = 2;
            this.pictureBox_DiagnosticsOutput6.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput11
            // 
            this.pictureBox_DiagnosticsOutput11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput11.Image")));
            this.pictureBox_DiagnosticsOutput11.Location = new System.Drawing.Point(55, 420);
            this.pictureBox_DiagnosticsOutput11.Name = "pictureBox_DiagnosticsOutput11";
            this.pictureBox_DiagnosticsOutput11.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput11.TabIndex = 3;
            this.pictureBox_DiagnosticsOutput11.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput3
            // 
            this.pictureBox_DiagnosticsOutput3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput3.Image")));
            this.pictureBox_DiagnosticsOutput3.Location = new System.Drawing.Point(55, 142);
            this.pictureBox_DiagnosticsOutput3.Name = "pictureBox_DiagnosticsOutput3";
            this.pictureBox_DiagnosticsOutput3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput3.TabIndex = 3;
            this.pictureBox_DiagnosticsOutput3.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput0
            // 
            this.pictureBox_DiagnosticsOutput0.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput0.Image")));
            this.pictureBox_DiagnosticsOutput0.Location = new System.Drawing.Point(55, 37);
            this.pictureBox_DiagnosticsOutput0.Name = "pictureBox_DiagnosticsOutput0";
            this.pictureBox_DiagnosticsOutput0.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput0.TabIndex = 4;
            this.pictureBox_DiagnosticsOutput0.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput8
            // 
            this.pictureBox_DiagnosticsOutput8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput8.Image")));
            this.pictureBox_DiagnosticsOutput8.Location = new System.Drawing.Point(55, 316);
            this.pictureBox_DiagnosticsOutput8.Name = "pictureBox_DiagnosticsOutput8";
            this.pictureBox_DiagnosticsOutput8.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput8.TabIndex = 4;
            this.pictureBox_DiagnosticsOutput8.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput15
            // 
            this.pictureBox_DiagnosticsOutput15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput15.Image")));
            this.pictureBox_DiagnosticsOutput15.Location = new System.Drawing.Point(55, 560);
            this.pictureBox_DiagnosticsOutput15.Name = "pictureBox_DiagnosticsOutput15";
            this.pictureBox_DiagnosticsOutput15.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput15.TabIndex = 5;
            this.pictureBox_DiagnosticsOutput15.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput7
            // 
            this.pictureBox_DiagnosticsOutput7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput7.Image")));
            this.pictureBox_DiagnosticsOutput7.Location = new System.Drawing.Point(55, 281);
            this.pictureBox_DiagnosticsOutput7.Name = "pictureBox_DiagnosticsOutput7";
            this.pictureBox_DiagnosticsOutput7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput7.TabIndex = 5;
            this.pictureBox_DiagnosticsOutput7.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput13
            // 
            this.pictureBox_DiagnosticsOutput13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput13.Image")));
            this.pictureBox_DiagnosticsOutput13.Location = new System.Drawing.Point(55, 490);
            this.pictureBox_DiagnosticsOutput13.Name = "pictureBox_DiagnosticsOutput13";
            this.pictureBox_DiagnosticsOutput13.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput13.TabIndex = 6;
            this.pictureBox_DiagnosticsOutput13.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput5
            // 
            this.pictureBox_DiagnosticsOutput5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput5.Image")));
            this.pictureBox_DiagnosticsOutput5.Location = new System.Drawing.Point(55, 212);
            this.pictureBox_DiagnosticsOutput5.Name = "pictureBox_DiagnosticsOutput5";
            this.pictureBox_DiagnosticsOutput5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput5.TabIndex = 6;
            this.pictureBox_DiagnosticsOutput5.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput12
            // 
            this.pictureBox_DiagnosticsOutput12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput12.Image")));
            this.pictureBox_DiagnosticsOutput12.Location = new System.Drawing.Point(55, 455);
            this.pictureBox_DiagnosticsOutput12.Name = "pictureBox_DiagnosticsOutput12";
            this.pictureBox_DiagnosticsOutput12.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput12.TabIndex = 7;
            this.pictureBox_DiagnosticsOutput12.TabStop = false;
            // 
            // pictureBox_Indicator4
            // 
            this.pictureBox_Indicator4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Indicator4.Image")));
            this.pictureBox_Indicator4.Location = new System.Drawing.Point(55, 177);
            this.pictureBox_Indicator4.Name = "pictureBox_Indicator4";
            this.pictureBox_Indicator4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_Indicator4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Indicator4.TabIndex = 7;
            this.pictureBox_Indicator4.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput10
            // 
            this.pictureBox_DiagnosticsOutput10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput10.Image")));
            this.pictureBox_DiagnosticsOutput10.Location = new System.Drawing.Point(55, 385);
            this.pictureBox_DiagnosticsOutput10.Name = "pictureBox_DiagnosticsOutput10";
            this.pictureBox_DiagnosticsOutput10.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput10.TabIndex = 8;
            this.pictureBox_DiagnosticsOutput10.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput2
            // 
            this.pictureBox_DiagnosticsOutput2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput2.Image")));
            this.pictureBox_DiagnosticsOutput2.Location = new System.Drawing.Point(55, 107);
            this.pictureBox_DiagnosticsOutput2.Name = "pictureBox_DiagnosticsOutput2";
            this.pictureBox_DiagnosticsOutput2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput2.TabIndex = 8;
            this.pictureBox_DiagnosticsOutput2.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput9
            // 
            this.pictureBox_DiagnosticsOutput9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput9.Image")));
            this.pictureBox_DiagnosticsOutput9.Location = new System.Drawing.Point(55, 350);
            this.pictureBox_DiagnosticsOutput9.Name = "pictureBox_DiagnosticsOutput9";
            this.pictureBox_DiagnosticsOutput9.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput9.TabIndex = 9;
            this.pictureBox_DiagnosticsOutput9.TabStop = false;
            // 
            // pictureBox_DiagnosticsOutput1
            // 
            this.pictureBox_DiagnosticsOutput1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_DiagnosticsOutput1.Image")));
            this.pictureBox_DiagnosticsOutput1.Location = new System.Drawing.Point(55, 72);
            this.pictureBox_DiagnosticsOutput1.Name = "pictureBox_DiagnosticsOutput1";
            this.pictureBox_DiagnosticsOutput1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_DiagnosticsOutput1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_DiagnosticsOutput1.TabIndex = 9;
            this.pictureBox_DiagnosticsOutput1.TabStop = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 42);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(43, 20);
            this.label37.TabIndex = 0;
            this.label37.Text = "D00:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 321);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 20);
            this.label29.TabIndex = 0;
            this.label29.Text = "D08:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 565);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 20);
            this.label36.TabIndex = 0;
            this.label36.Text = "D15:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 286);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(43, 20);
            this.label28.TabIndex = 0;
            this.label28.Text = "D07:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 460);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(43, 20);
            this.label35.TabIndex = 0;
            this.label35.Text = "D12:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 530);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 20);
            this.label34.TabIndex = 0;
            this.label34.Text = "D14:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 182);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "D04:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(10, 425);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(43, 20);
            this.label33.TabIndex = 0;
            this.label33.Text = "D11:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 251);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "D06:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(10, 495);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 20);
            this.label32.TabIndex = 0;
            this.label32.Text = "D13:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 147);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "D03:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(10, 390);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(43, 20);
            this.label31.TabIndex = 0;
            this.label31.Text = "D10:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 217);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 20);
            this.label26.TabIndex = 0;
            this.label26.Text = "D05:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(10, 355);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 20);
            this.label30.TabIndex = 0;
            this.label30.Text = "D09:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "D02:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "D01:";
            // 
            // groupBox_DiagnosticsCamSettings
            // 
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.textBox_DiagnosticsGain);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.textBox_DiagnosticsExposureTime);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.listBox_DiagnosticsCamerasSettings);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.label16);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.label14);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.button_DiagnosticsGainSet);
            this.groupBox_DiagnosticsCamSettings.Controls.Add(this.button_DiagnosticsExposureSet);
            this.groupBox_DiagnosticsCamSettings.Location = new System.Drawing.Point(286, 71);
            this.groupBox_DiagnosticsCamSettings.Name = "groupBox_DiagnosticsCamSettings";
            this.groupBox_DiagnosticsCamSettings.Size = new System.Drawing.Size(467, 158);
            this.groupBox_DiagnosticsCamSettings.TabIndex = 2;
            this.groupBox_DiagnosticsCamSettings.TabStop = false;
            this.groupBox_DiagnosticsCamSettings.Text = "Nastavenia Kamier 1-14";
            // 
            // textBox_DiagnosticsGain
            // 
            this.textBox_DiagnosticsGain.Location = new System.Drawing.Point(132, 83);
            this.textBox_DiagnosticsGain.Name = "textBox_DiagnosticsGain";
            this.textBox_DiagnosticsGain.Size = new System.Drawing.Size(62, 26);
            this.textBox_DiagnosticsGain.TabIndex = 1;
            // 
            // textBox_DiagnosticsExposureTime
            // 
            this.textBox_DiagnosticsExposureTime.Location = new System.Drawing.Point(132, 45);
            this.textBox_DiagnosticsExposureTime.Name = "textBox_DiagnosticsExposureTime";
            this.textBox_DiagnosticsExposureTime.Size = new System.Drawing.Size(62, 26);
            this.textBox_DiagnosticsExposureTime.TabIndex = 1;
            // 
            // listBox_DiagnosticsCamerasSettings
            // 
            this.listBox_DiagnosticsCamerasSettings.FormattingEnabled = true;
            this.listBox_DiagnosticsCamerasSettings.ItemHeight = 20;
            this.listBox_DiagnosticsCamerasSettings.Items.AddRange(new object[] {
            "Cam1LsTopL",
            "Cam2LsTopR",
            "Cam3LsBottomL",
            "Cam4LsBottomR",
            "Cam5LsLeft",
            "Cam6LsRight",
            "Cam7ArFrontL",
            "Cam8ArFrontR",
            "Cam9ArRearL",
            "Cam10ArRearR",
            "Cam11ArTopL               ",
            "Cam12ArTopR",
            "Cam13ArBottomL",
            "Cam14ArBottomR"});
            this.listBox_DiagnosticsCamerasSettings.Location = new System.Drawing.Point(294, 25);
            this.listBox_DiagnosticsCamerasSettings.Name = "listBox_DiagnosticsCamerasSettings";
            this.listBox_DiagnosticsCamerasSettings.Size = new System.Drawing.Size(167, 84);
            this.listBox_DiagnosticsCamerasSettings.TabIndex = 0;
            this.listBox_DiagnosticsCamerasSettings.SelectedIndexChanged += new System.EventHandler(this.listBox_DiagnosticsCamerasSettings_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Zosilnenie:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(0, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Expozičná doba:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_DiagnosticsGainSet
            // 
            this.button_DiagnosticsGainSet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsGainSet.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsGainSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsGainSet.Location = new System.Drawing.Point(200, 83);
            this.button_DiagnosticsGainSet.Name = "button_DiagnosticsGainSet";
            this.button_DiagnosticsGainSet.Size = new System.Drawing.Size(88, 26);
            this.button_DiagnosticsGainSet.TabIndex = 12;
            this.button_DiagnosticsGainSet.Text = "Nastaviť";
            this.button_DiagnosticsGainSet.UseVisualStyleBackColor = false;
            this.button_DiagnosticsGainSet.Click += new System.EventHandler(this.button_DiagnosticsGainSet_Click);
            // 
            // button_DiagnosticsExposureSet
            // 
            this.button_DiagnosticsExposureSet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_DiagnosticsExposureSet.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_DiagnosticsExposureSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DiagnosticsExposureSet.Location = new System.Drawing.Point(200, 45);
            this.button_DiagnosticsExposureSet.Name = "button_DiagnosticsExposureSet";
            this.button_DiagnosticsExposureSet.Size = new System.Drawing.Size(88, 26);
            this.button_DiagnosticsExposureSet.TabIndex = 12;
            this.button_DiagnosticsExposureSet.Text = "Nastaviť";
            this.button_DiagnosticsExposureSet.UseVisualStyleBackColor = false;
            this.button_DiagnosticsExposureSet.Click += new System.EventHandler(this.button_DiagnosticsExposureSet_Click);
            // 
            // label_Diagnostics
            // 
            this.label_Diagnostics.AutoSize = true;
            this.label_Diagnostics.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Diagnostics.Location = new System.Drawing.Point(3, 3);
            this.label_Diagnostics.Name = "label_Diagnostics";
            this.label_Diagnostics.Size = new System.Drawing.Size(136, 25);
            this.label_Diagnostics.TabIndex = 1;
            this.label_Diagnostics.Text = "Diagnostika";
            // 
            // groupBox_DiagnosticsCamInfo
            // 
            this.groupBox_DiagnosticsCamInfo.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo1);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo2);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo3);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo4);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo5);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo6);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo7);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo8);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo9);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo10);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo11);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo12);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo13);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.pictureBox_CamInfo14);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label12);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label10);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label25);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label17);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label9);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label7);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label23);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label15);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label5);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label_caminfo);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label21);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label20);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label11);
            this.groupBox_DiagnosticsCamInfo.Controls.Add(this.label13);
            this.groupBox_DiagnosticsCamInfo.Location = new System.Drawing.Point(8, 244);
            this.groupBox_DiagnosticsCamInfo.Name = "groupBox_DiagnosticsCamInfo";
            this.groupBox_DiagnosticsCamInfo.Size = new System.Drawing.Size(236, 527);
            this.groupBox_DiagnosticsCamInfo.TabIndex = 0;
            this.groupBox_DiagnosticsCamInfo.TabStop = false;
            this.groupBox_DiagnosticsCamInfo.Text = "Kamery";
            // 
            // pictureBox_CamInfo1
            // 
            this.pictureBox_CamInfo1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo1.Image")));
            this.pictureBox_CamInfo1.Location = new System.Drawing.Point(141, 37);
            this.pictureBox_CamInfo1.Name = "pictureBox_CamInfo1";
            this.pictureBox_CamInfo1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo1.TabIndex = 1;
            this.pictureBox_CamInfo1.TabStop = false;
            // 
            // pictureBox_CamInfo2
            // 
            this.pictureBox_CamInfo2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo2.Image")));
            this.pictureBox_CamInfo2.Location = new System.Drawing.Point(141, 72);
            this.pictureBox_CamInfo2.Name = "pictureBox_CamInfo2";
            this.pictureBox_CamInfo2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo2.TabIndex = 1;
            this.pictureBox_CamInfo2.TabStop = false;
            // 
            // pictureBox_CamInfo3
            // 
            this.pictureBox_CamInfo3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo3.Image")));
            this.pictureBox_CamInfo3.Location = new System.Drawing.Point(141, 107);
            this.pictureBox_CamInfo3.Name = "pictureBox_CamInfo3";
            this.pictureBox_CamInfo3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo3.TabIndex = 1;
            this.pictureBox_CamInfo3.TabStop = false;
            // 
            // pictureBox_CamInfo4
            // 
            this.pictureBox_CamInfo4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo4.Image")));
            this.pictureBox_CamInfo4.Location = new System.Drawing.Point(141, 142);
            this.pictureBox_CamInfo4.Name = "pictureBox_CamInfo4";
            this.pictureBox_CamInfo4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo4.TabIndex = 1;
            this.pictureBox_CamInfo4.TabStop = false;
            // 
            // pictureBox_CamInfo5
            // 
            this.pictureBox_CamInfo5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo5.Image")));
            this.pictureBox_CamInfo5.Location = new System.Drawing.Point(141, 177);
            this.pictureBox_CamInfo5.Name = "pictureBox_CamInfo5";
            this.pictureBox_CamInfo5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo5.TabIndex = 1;
            this.pictureBox_CamInfo5.TabStop = false;
            // 
            // pictureBox_CamInfo6
            // 
            this.pictureBox_CamInfo6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo6.Image")));
            this.pictureBox_CamInfo6.Location = new System.Drawing.Point(141, 212);
            this.pictureBox_CamInfo6.Name = "pictureBox_CamInfo6";
            this.pictureBox_CamInfo6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo6.TabIndex = 1;
            this.pictureBox_CamInfo6.TabStop = false;
            // 
            // pictureBox_CamInfo7
            // 
            this.pictureBox_CamInfo7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo7.Image")));
            this.pictureBox_CamInfo7.Location = new System.Drawing.Point(141, 247);
            this.pictureBox_CamInfo7.Name = "pictureBox_CamInfo7";
            this.pictureBox_CamInfo7.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo7.TabIndex = 1;
            this.pictureBox_CamInfo7.TabStop = false;
            // 
            // pictureBox_CamInfo8
            // 
            this.pictureBox_CamInfo8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo8.Image")));
            this.pictureBox_CamInfo8.Location = new System.Drawing.Point(141, 283);
            this.pictureBox_CamInfo8.Name = "pictureBox_CamInfo8";
            this.pictureBox_CamInfo8.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo8.TabIndex = 1;
            this.pictureBox_CamInfo8.TabStop = false;
            // 
            // pictureBox_CamInfo9
            // 
            this.pictureBox_CamInfo9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo9.Image")));
            this.pictureBox_CamInfo9.Location = new System.Drawing.Point(141, 317);
            this.pictureBox_CamInfo9.Name = "pictureBox_CamInfo9";
            this.pictureBox_CamInfo9.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo9.TabIndex = 1;
            this.pictureBox_CamInfo9.TabStop = false;
            // 
            // pictureBox_CamInfo10
            // 
            this.pictureBox_CamInfo10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo10.Image")));
            this.pictureBox_CamInfo10.Location = new System.Drawing.Point(141, 352);
            this.pictureBox_CamInfo10.Name = "pictureBox_CamInfo10";
            this.pictureBox_CamInfo10.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo10.TabIndex = 1;
            this.pictureBox_CamInfo10.TabStop = false;
            // 
            // pictureBox_CamInfo11
            // 
            this.pictureBox_CamInfo11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo11.Image")));
            this.pictureBox_CamInfo11.Location = new System.Drawing.Point(141, 387);
            this.pictureBox_CamInfo11.Name = "pictureBox_CamInfo11";
            this.pictureBox_CamInfo11.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo11.TabIndex = 1;
            this.pictureBox_CamInfo11.TabStop = false;
            // 
            // pictureBox_CamInfo12
            // 
            this.pictureBox_CamInfo12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo12.Image")));
            this.pictureBox_CamInfo12.Location = new System.Drawing.Point(141, 422);
            this.pictureBox_CamInfo12.Name = "pictureBox_CamInfo12";
            this.pictureBox_CamInfo12.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo12.TabIndex = 1;
            this.pictureBox_CamInfo12.TabStop = false;
            // 
            // pictureBox_CamInfo13
            // 
            this.pictureBox_CamInfo13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo13.Image")));
            this.pictureBox_CamInfo13.Location = new System.Drawing.Point(141, 458);
            this.pictureBox_CamInfo13.Name = "pictureBox_CamInfo13";
            this.pictureBox_CamInfo13.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo13.TabIndex = 1;
            this.pictureBox_CamInfo13.TabStop = false;
            // 
            // pictureBox_CamInfo14
            // 
            this.pictureBox_CamInfo14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_CamInfo14.Image")));
            this.pictureBox_CamInfo14.Location = new System.Drawing.Point(141, 493);
            this.pictureBox_CamInfo14.Name = "pictureBox_CamInfo14";
            this.pictureBox_CamInfo14.Size = new System.Drawing.Size(30, 30);
            this.pictureBox_CamInfo14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CamInfo14.TabIndex = 1;
            this.pictureBox_CamInfo14.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 464);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Cam13:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Cam14:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(46, 427);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "Cam12:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(46, 288);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Cam8:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cam4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cam3:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(46, 392);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "Cam11:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(46, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Cam7:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cam2:";
            // 
            // label_caminfo
            // 
            this.label_caminfo.AutoSize = true;
            this.label_caminfo.Location = new System.Drawing.Point(46, 42);
            this.label_caminfo.Name = "label_caminfo";
            this.label_caminfo.Size = new System.Drawing.Size(55, 20);
            this.label_caminfo.TabIndex = 0;
            this.label_caminfo.Text = "Cam1:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(46, 322);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "Cam9:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(46, 357);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Cam10:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cam5:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cam6:";
            // 
            // groupBox_DiagnosticsDiscManagement
            // 
            this.groupBox_DiagnosticsDiscManagement.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label_AvailableSpaceE);
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label4);
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label_AvailableSpaceC);
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label_AvailableSpaceD);
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label3);
            this.groupBox_DiagnosticsDiscManagement.Controls.Add(this.label2);
            this.groupBox_DiagnosticsDiscManagement.Location = new System.Drawing.Point(8, 71);
            this.groupBox_DiagnosticsDiscManagement.Name = "groupBox_DiagnosticsDiscManagement";
            this.groupBox_DiagnosticsDiscManagement.Size = new System.Drawing.Size(236, 158);
            this.groupBox_DiagnosticsDiscManagement.TabIndex = 0;
            this.groupBox_DiagnosticsDiscManagement.TabStop = false;
            this.groupBox_DiagnosticsDiscManagement.Text = "Info úložiska";
            // 
            // label_AvailableSpaceE
            // 
            this.label_AvailableSpaceE.AutoSize = true;
            this.label_AvailableSpaceE.Location = new System.Drawing.Point(137, 112);
            this.label_AvailableSpaceE.Name = "label_AvailableSpaceE";
            this.label_AvailableSpaceE.Size = new System.Drawing.Size(23, 20);
            this.label_AvailableSpaceE.TabIndex = 0;
            this.label_AvailableSpaceE.Text = "-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Disk E:";
            // 
            // label_AvailableSpaceC
            // 
            this.label_AvailableSpaceC.AutoSize = true;
            this.label_AvailableSpaceC.Location = new System.Drawing.Point(137, 77);
            this.label_AvailableSpaceC.Name = "label_AvailableSpaceC";
            this.label_AvailableSpaceC.Size = new System.Drawing.Size(23, 20);
            this.label_AvailableSpaceC.TabIndex = 0;
            this.label_AvailableSpaceC.Text = "-1";
            // 
            // label_AvailableSpaceD
            // 
            this.label_AvailableSpaceD.AutoSize = true;
            this.label_AvailableSpaceD.Location = new System.Drawing.Point(137, 42);
            this.label_AvailableSpaceD.Name = "label_AvailableSpaceD";
            this.label_AvailableSpaceD.Size = new System.Drawing.Size(23, 20);
            this.label_AvailableSpaceD.TabIndex = 0;
            this.label_AvailableSpaceD.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Disk C:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Disk D:";
            // 
            // timer_Simulation
            // 
            this.timer_Simulation.Interval = 2000;
            this.timer_Simulation.Tick += new System.EventHandler(this.timer_Simulation_Tick);
            // 
            // timer_Clock
            // 
            this.timer_Clock.Interval = 1000;
            this.timer_Clock.Tick += new System.EventHandler(this.timer_Clock_Tick);
            // 
            // timer_DiscsCheck
            // 
            this.timer_DiscsCheck.Interval = 5000;
            this.timer_DiscsCheck.Tick += new System.EventHandler(this.timer_DiscsCheck_Tick);
            // 
            // panel_Footer
            // 
            this.panel_Footer.BackColor = System.Drawing.Color.Silver;
            this.panel_Footer.Controls.Add(this.pictureBox_FooterKeyBoard);
            this.panel_Footer.Controls.Add(this.button_FooterExitApp);
            this.panel_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Footer.Location = new System.Drawing.Point(0, 1029);
            this.panel_Footer.Name = "panel_Footer";
            this.panel_Footer.Size = new System.Drawing.Size(1920, 51);
            this.panel_Footer.TabIndex = 9;
            // 
            // pictureBox_FooterKeyBoard
            // 
            this.pictureBox_FooterKeyBoard.Image = global::IkeaUI.Properties.Resources.keyboard_40px;
            this.pictureBox_FooterKeyBoard.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_FooterKeyBoard.Name = "pictureBox_FooterKeyBoard";
            this.pictureBox_FooterKeyBoard.Size = new System.Drawing.Size(54, 45);
            this.pictureBox_FooterKeyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_FooterKeyBoard.TabIndex = 5;
            this.pictureBox_FooterKeyBoard.TabStop = false;
            this.pictureBox_FooterKeyBoard.Click += new System.EventHandler(this.pictureBox_FooterKeyBoard_Click);
            // 
            // button_FooterExitApp
            // 
            this.button_FooterExitApp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_FooterExitApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_FooterExitApp.FlatAppearance.BorderSize = 2;
            this.button_FooterExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_FooterExitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_FooterExitApp.Location = new System.Drawing.Point(1810, 6);
            this.button_FooterExitApp.Name = "button_FooterExitApp";
            this.button_FooterExitApp.Size = new System.Drawing.Size(100, 40);
            this.button_FooterExitApp.TabIndex = 4;
            this.button_FooterExitApp.Text = "Ukončiť";
            this.button_FooterExitApp.UseVisualStyleBackColor = false;
            this.button_FooterExitApp.Click += new System.EventHandler(this.button_ExitApp_Click);
            // 
            // timer_CameraPing
            // 
            this.timer_CameraPing.Interval = 5000;
            this.timer_CameraPing.Tick += new System.EventHandler(this.timer_CameraPing_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel_Footer);
            this.Controls.Add(this.tabControl_MainControl);
            this.Controls.Add(this.panel_Header);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Powered by Trifid";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IkeaLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TrifidLogo)).EndInit();
            this.tabControl_MainControl.ResumeLayout(false);
            this.tabPage_Main.ResumeLayout(false);
            this.tabPage_Main.PerformLayout();
            this.groupBox_MainTabControlCameras.ResumeLayout(false);
            this.tabControl_MainCameras.ResumeLayout(false);
            this.tabPage_LeftSide.ResumeLayout(false);
            this.tabPage_RightSide.ResumeLayout(false);
            this.tabPage_FrontSide.ResumeLayout(false);
            this.tabPage_BackSide.ResumeLayout(false);
            this.tabPage_UpperSide.ResumeLayout(false);
            this.tabPage_LowerSide.ResumeLayout(false);
            this.groupBox_MainStatistics.ResumeLayout(false);
            this.groupBox_MainStatistics.PerformLayout();
            this.groupBox_MainPodozrive.ResumeLayout(false);
            this.groupBox_MainDielce.ResumeLayout(false);
            this.groupBox_MainDielce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_MainRiadenie.ResumeLayout(false);
            this.tabPage_Archive.ResumeLayout(false);
            this.groupBox_ArchiveDrawingSides.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ArchiveDrawingSides)).EndInit();
            this.groupBox_Holes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HolesData)).EndInit();
            this.groupBox_Boards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.groupBox_Hwindow.ResumeLayout(false);
            this.tabPage_Diagnostics.ResumeLayout(false);
            this.tabPage_Diagnostics.PerformLayout();
            this.panel_DiagnosticsAutorization.ResumeLayout(false);
            this.panel_DiagnosticsAutorization.PerformLayout();
            this.groupBox_DiagnosticsVstupy.ResumeLayout(false);
            this.groupBox_DiagnosticsVstupy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsInput1)).EndInit();
            this.groupBox_DiagnosticsVykres.ResumeLayout(false);
            this.groupBox_DiagnosticsOutputs.ResumeLayout(false);
            this.groupBox_DiagnosticsOutputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Indicator4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DiagnosticsOutput1)).EndInit();
            this.groupBox_DiagnosticsCamSettings.ResumeLayout(false);
            this.groupBox_DiagnosticsCamSettings.PerformLayout();
            this.groupBox_DiagnosticsCamInfo.ResumeLayout(false);
            this.groupBox_DiagnosticsCamInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CamInfo14)).EndInit();
            this.groupBox_DiagnosticsDiscManagement.ResumeLayout(false);
            this.groupBox_DiagnosticsDiscManagement.PerformLayout();
            this.panel_Footer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FooterKeyBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Clock;
        private System.Windows.Forms.PictureBox pictureBox_IkeaLogo;
        private System.Windows.Forms.PictureBox pictureBox_TrifidLogo;
        private System.Windows.Forms.TabControl tabControl_MainControl;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.TabPage tabPage_Archive;
        private System.Windows.Forms.TabPage tabPage_Diagnostics;
        private System.Windows.Forms.Timer timer_Simulation;
        private System.Windows.Forms.Timer timer_Clock;
        private System.Windows.Forms.Timer timer_DiscsCheck;
        private System.Windows.Forms.GroupBox groupBox_Holes;
        private System.Windows.Forms.GroupBox groupBox_Boards;
        private System.Windows.Forms.GroupBox groupBox_Hwindow;
        private HalconDotNet.HSmartWindowControl Hwindow_ArchiveImage;
        private System.Windows.Forms.DataGridView dataGridView_HolesData;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsDiscManagement;
        private System.Windows.Forms.Label label_AvailableSpaceE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_AvailableSpaceC;
        private System.Windows.Forms.Label label_AvailableSpaceD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_TakeInfoFromDB;
        private System.Windows.Forms.Button button_RefreshTable;
        private System.Windows.Forms.Label label_Diagnostics;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsCamInfo;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo12;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo9;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo6;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo3;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo11;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo8;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo10;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo7;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo5;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo4;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo2;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_caminfo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_AccessLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_Footer;
        private System.Windows.Forms.Button button_FooterExitApp;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo14;
        private System.Windows.Forms.PictureBox pictureBox_CamInfo13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl_MainCameras;
        private System.Windows.Forms.TabPage tabPage_LeftSide;
        private System.Windows.Forms.TabPage tabPage_RightSide;
        private System.Windows.Forms.TabPage tabPage_FrontSide;
        private System.Windows.Forms.TabPage tabPage_BackSide;
        private System.Windows.Forms.TabPage tabPage_UpperSide;
        private System.Windows.Forms.TabPage tabPage_LowerSide;
        private HalconDotNet.HSmartWindowControl Hwindow_LeftSide;
        private HalconDotNet.HSmartWindowControl Hwindow_RightSide;
        private HalconDotNet.HSmartWindowControl Hwindow_FrontSide;
        private HalconDotNet.HSmartWindowControl Hwindow_BackSide;
        private HalconDotNet.HSmartWindowControl Hwindow_UpperSide;
        private HalconDotNet.HSmartWindowControl Hwindow_LowerSide;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsCamSettings;
        private System.Windows.Forms.TextBox textBox_DiagnosticsGain;
        private System.Windows.Forms.TextBox textBox_DiagnosticsExposureTime;
        private System.Windows.Forms.ListBox listBox_DiagnosticsCamerasSettings;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsOutputs;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput14;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput6;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput11;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput3;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput0;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput8;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput15;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput7;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput13;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput5;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput12;
        private System.Windows.Forms.PictureBox pictureBox_Indicator4;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput10;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput2;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput9;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsOutput1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox_MainRiadenie;
        private System.Windows.Forms.GroupBox groupBox_MainDielce;
        private System.Windows.Forms.GroupBox groupBox_MainPodozrive;
        private System.Windows.Forms.ListBox listBox_MainRecipe;
        private System.Windows.Forms.TextBox textBox_MainSearchRecipe;
        private System.Windows.Forms.ProgressBar progressBar_MainPodozrive;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsVykres;
        private HalconDotNet.HSmartWindowControl Hwindow_Diagnostika;
        private System.Windows.Forms.GroupBox groupBox_DiagnosticsVstupy;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput6;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput3;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput0;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput7;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput5;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput4;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput2;
        private System.Windows.Forms.PictureBox pictureBox_DiagnosticsInput1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label_MainSystemMessage;
        private System.Windows.Forms.Label label_MainPoznamka;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox_MainSystemMessage;
        private System.Windows.Forms.TextBox textBox_MainPoznamka;
        private System.Windows.Forms.Panel panel_DiagnosticsAutorization;
        private System.Windows.Forms.Button button_DiagnosticsChangePassword;
        private System.Windows.Forms.Button button_DiagnosticsLogIn;
        private System.Windows.Forms.TextBox textBox_UserPassword;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button button_DiagnosticsAutorisation;
        private System.Windows.Forms.PictureBox pictureBox_FooterKeyBoard;
        private System.Windows.Forms.GroupBox groupBox_MainStatistics;
        private System.Windows.Forms.Button button_DiagnosticsInput7;
        private System.Windows.Forms.Button button_DiagnosticsInput6;
        private System.Windows.Forms.Button button_DiagnosticsInput5;
        private System.Windows.Forms.Button button_DiagnosticsInput4;
        private System.Windows.Forms.Button button_DiagnosticsInput3;
        private System.Windows.Forms.Button button_DiagnosticsInput2;
        private System.Windows.Forms.Button button_DiagnosticsInput1;
        private System.Windows.Forms.Button button_DiagnosticsInput0;
        private System.Windows.Forms.Button button_DiagnosticsOutput15;
        private System.Windows.Forms.Button button_DiagnosticsOutput7;
        private System.Windows.Forms.Button button_DiagnosticsOutput14;
        private System.Windows.Forms.Button button_DiagnosticsOutput6;
        private System.Windows.Forms.Button button_DiagnosticsOutput13;
        private System.Windows.Forms.Button button_DiagnosticsOutput5;
        private System.Windows.Forms.Button button_DiagnosticsOutput12;
        private System.Windows.Forms.Button button_DiagnosticsOutput4;
        private System.Windows.Forms.Button button_DiagnosticsOutput11;
        private System.Windows.Forms.Button button_DiagnosticsOutput3;
        private System.Windows.Forms.Button button_DiagnosticsOutput10;
        private System.Windows.Forms.Button button_DiagnosticsOutput2;
        private System.Windows.Forms.Button button_DiagnosticsOutput9;
        private System.Windows.Forms.Button button_DiagnosticsOutput8;
        private System.Windows.Forms.Button button_DiagnosticsOutput1;
        private System.Windows.Forms.Button button_DiagnosticsOutput0;
        private System.Windows.Forms.Label label_MainStatisticsOverall;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label_MainStatisticsSuspicious;
        private System.Windows.Forms.Label label_MainStatisticsOverCount;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label_MainStatisticsOK;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label_MainStatisticsNOK;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button button_DiagnosticsGainSet;
        private System.Windows.Forms.Button button_DiagnosticsExposureSet;
        private System.Windows.Forms.Timer timer_CameraPing;
        private System.Windows.Forms.GroupBox groupBox_ArchiveDrawingSides;
        private System.Windows.Forms.DataGridView dataGridView_ArchiveDrawingSides;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrawingSidesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrawingSideName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStampHoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radius;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusHoles;
        public System.Windows.Forms.ImageList imageList_TabMainCameras;
        private System.Windows.Forms.Button button_MainStop;
        private System.Windows.Forms.Button button_MainStart;
        private System.Windows.Forms.Button button_MainSaveImg;
        private System.Windows.Forms.Button button_DiagnosticsLogOff;
        private System.Windows.Forms.GroupBox groupBox_MainTabControlCameras;
    }
}

