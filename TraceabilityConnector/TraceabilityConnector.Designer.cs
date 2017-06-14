namespace TraceabilityConnector
{
    partial class TraceabilityConnector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraceabilityConnector));
            this.tmr_Scanner = new System.Windows.Forms.Timer(this.components);
            this.tb_ShowInformation = new System.Windows.Forms.TextBox();
            this.btn_Initialize = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_PlcConnection = new System.Windows.Forms.Label();
            this.lbl_plcIpAddress = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_MachineFamily = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_MachineName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_MachineCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEmbedded = new System.Windows.Forms.GroupBox();
            this.btn_LoadReference = new System.Windows.Forms.Button();
            this.lbl_PreviousMachine = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Sequence = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Article = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Reference = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.lbl_LoadingDataMatrix = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_LoadingStatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl_UnloadingDataMatrix = new System.Windows.Forms.Label();
            this.lbl_UnloadingState = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btn_WriteToLoading = new System.Windows.Forms.Button();
            this.btn_WriteToUnloading = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_ByPass = new System.Windows.Forms.Button();
            this.chb_ScanLamp = new System.Windows.Forms.CheckBox();
            this.lbl_VirtualIndexer = new System.Windows.Forms.Label();
            this.lbl_TraceabilityStates = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_Indexer = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gb_MachineSimulation = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.btn_IndexTable = new System.Windows.Forms.Button();
            this.btn_SetProcessNok = new System.Windows.Forms.Button();
            this.btn_SetProcessOk = new System.Windows.Forms.Button();
            this.btn_SetRequestCheck = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmr_PlcRetry = new System.Windows.Forms.Timer(this.components);
            this.gb_Embedded = new System.Windows.Forms.GroupBox();
            this.lbl_OrderNumber = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbl_GenerateResult = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl_GeneratedDataMatrix = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnAlarmClear = new System.Windows.Forms.Button();
            this.tmr_CLock = new System.Windows.Forms.Timer(this.components);
            this.lbl_Clock = new System.Windows.Forms.Label();
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.gbEmbedded.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gb_MachineSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_Embedded.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_Scanner
            // 
            this.tmr_Scanner.Tick += new System.EventHandler(this.tmr_Scanner_Tick);
            // 
            // tb_ShowInformation
            // 
            this.tb_ShowInformation.Location = new System.Drawing.Point(513, 45);
            this.tb_ShowInformation.Multiline = true;
            this.tb_ShowInformation.Name = "tb_ShowInformation";
            this.tb_ShowInformation.ReadOnly = true;
            this.tb_ShowInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_ShowInformation.Size = new System.Drawing.Size(366, 101);
            this.tb_ShowInformation.TabIndex = 0;
            this.tb_ShowInformation.WordWrap = false;
            // 
            // btn_Initialize
            // 
            this.btn_Initialize.Location = new System.Drawing.Point(12, 593);
            this.btn_Initialize.Name = "btn_Initialize";
            this.btn_Initialize.Size = new System.Drawing.Size(75, 42);
            this.btn_Initialize.TabIndex = 1;
            this.btn_Initialize.Text = "Initialize";
            this.btn_Initialize.UseVisualStyleBackColor = true;
            this.btn_Initialize.Click += new System.EventHandler(this.btn_Initialize_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.Location = new System.Drawing.Point(93, 593);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(75, 42);
            this.btn_Setting.TabIndex = 2;
            this.btn_Setting.Text = "Setting";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lbl_PlcConnection);
            this.groupBox1.Controls.Add(this.lbl_plcIpAddress);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_MachineFamily);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_MachineName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_MachineCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 145);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Machine Information";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Plc Connection";
            // 
            // lbl_PlcConnection
            // 
            this.lbl_PlcConnection.AutoSize = true;
            this.lbl_PlcConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PlcConnection.ForeColor = System.Drawing.Color.Green;
            this.lbl_PlcConnection.Location = new System.Drawing.Point(123, 123);
            this.lbl_PlcConnection.Name = "lbl_PlcConnection";
            this.lbl_PlcConnection.Size = new System.Drawing.Size(45, 16);
            this.lbl_PlcConnection.TabIndex = 1;
            this.lbl_PlcConnection.Text = "label2";
            // 
            // lbl_plcIpAddress
            // 
            this.lbl_plcIpAddress.AutoSize = true;
            this.lbl_plcIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_plcIpAddress.ForeColor = System.Drawing.Color.Green;
            this.lbl_plcIpAddress.Location = new System.Drawing.Point(123, 98);
            this.lbl_plcIpAddress.Name = "lbl_plcIpAddress";
            this.lbl_plcIpAddress.Size = new System.Drawing.Size(45, 16);
            this.lbl_plcIpAddress.TabIndex = 1;
            this.lbl_plcIpAddress.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Plc Ip Adress";
            // 
            // lbl_MachineFamily
            // 
            this.lbl_MachineFamily.AutoSize = true;
            this.lbl_MachineFamily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MachineFamily.ForeColor = System.Drawing.Color.Green;
            this.lbl_MachineFamily.Location = new System.Drawing.Point(123, 75);
            this.lbl_MachineFamily.Name = "lbl_MachineFamily";
            this.lbl_MachineFamily.Size = new System.Drawing.Size(45, 16);
            this.lbl_MachineFamily.TabIndex = 1;
            this.lbl_MachineFamily.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Machine Family";
            // 
            // lbl_MachineName
            // 
            this.lbl_MachineName.AutoSize = true;
            this.lbl_MachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MachineName.ForeColor = System.Drawing.Color.Green;
            this.lbl_MachineName.Location = new System.Drawing.Point(123, 53);
            this.lbl_MachineName.Name = "lbl_MachineName";
            this.lbl_MachineName.Size = new System.Drawing.Size(45, 16);
            this.lbl_MachineName.TabIndex = 1;
            this.lbl_MachineName.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Machine Name";
            // 
            // lbl_MachineCode
            // 
            this.lbl_MachineCode.AutoSize = true;
            this.lbl_MachineCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MachineCode.ForeColor = System.Drawing.Color.Green;
            this.lbl_MachineCode.Location = new System.Drawing.Point(123, 29);
            this.lbl_MachineCode.Name = "lbl_MachineCode";
            this.lbl_MachineCode.Size = new System.Drawing.Size(45, 16);
            this.lbl_MachineCode.TabIndex = 1;
            this.lbl_MachineCode.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Code";
            // 
            // gbEmbedded
            // 
            this.gbEmbedded.Controls.Add(this.btn_LoadReference);
            this.gbEmbedded.Controls.Add(this.lbl_PreviousMachine);
            this.gbEmbedded.Controls.Add(this.label8);
            this.gbEmbedded.Controls.Add(this.lbl_Sequence);
            this.gbEmbedded.Controls.Add(this.label7);
            this.gbEmbedded.Controls.Add(this.lbl_Article);
            this.gbEmbedded.Controls.Add(this.label5);
            this.gbEmbedded.Controls.Add(this.lbl_Reference);
            this.gbEmbedded.Controls.Add(this.label3);
            this.gbEmbedded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEmbedded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gbEmbedded.Location = new System.Drawing.Point(12, 163);
            this.gbEmbedded.Name = "gbEmbedded";
            this.gbEmbedded.Size = new System.Drawing.Size(494, 120);
            this.gbEmbedded.TabIndex = 6;
            this.gbEmbedded.TabStop = false;
            this.gbEmbedded.Text = "Reference Information";
            this.gbEmbedded.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_LoadReference
            // 
            this.btn_LoadReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadReference.Location = new System.Drawing.Point(385, 11);
            this.btn_LoadReference.Name = "btn_LoadReference";
            this.btn_LoadReference.Size = new System.Drawing.Size(104, 23);
            this.btn_LoadReference.TabIndex = 2;
            this.btn_LoadReference.Text = "Load Reference";
            this.btn_LoadReference.UseVisualStyleBackColor = true;
            this.btn_LoadReference.Visible = false;
            this.btn_LoadReference.Click += new System.EventHandler(this.btn_LoadReference_Click);
            // 
            // lbl_PreviousMachine
            // 
            this.lbl_PreviousMachine.AutoSize = true;
            this.lbl_PreviousMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PreviousMachine.ForeColor = System.Drawing.Color.Green;
            this.lbl_PreviousMachine.Location = new System.Drawing.Point(122, 92);
            this.lbl_PreviousMachine.Name = "lbl_PreviousMachine";
            this.lbl_PreviousMachine.Size = new System.Drawing.Size(45, 16);
            this.lbl_PreviousMachine.TabIndex = 1;
            this.lbl_PreviousMachine.Text = "label2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Prev Machine";
            // 
            // lbl_Sequence
            // 
            this.lbl_Sequence.AutoSize = true;
            this.lbl_Sequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sequence.ForeColor = System.Drawing.Color.Green;
            this.lbl_Sequence.Location = new System.Drawing.Point(122, 67);
            this.lbl_Sequence.Name = "lbl_Sequence";
            this.lbl_Sequence.Size = new System.Drawing.Size(45, 16);
            this.lbl_Sequence.TabIndex = 1;
            this.lbl_Sequence.Text = "label2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sequence";
            // 
            // lbl_Article
            // 
            this.lbl_Article.AutoSize = true;
            this.lbl_Article.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Article.ForeColor = System.Drawing.Color.Green;
            this.lbl_Article.Location = new System.Drawing.Point(122, 46);
            this.lbl_Article.Name = "lbl_Article";
            this.lbl_Article.Size = new System.Drawing.Size(45, 16);
            this.lbl_Article.TabIndex = 1;
            this.lbl_Article.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Article";
            // 
            // lbl_Reference
            // 
            this.lbl_Reference.AutoSize = true;
            this.lbl_Reference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reference.ForeColor = System.Drawing.Color.Green;
            this.lbl_Reference.Location = new System.Drawing.Point(122, 23);
            this.lbl_Reference.Name = "lbl_Reference";
            this.lbl_Reference.Size = new System.Drawing.Size(45, 16);
            this.lbl_Reference.TabIndex = 1;
            this.lbl_Reference.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reference";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(88, 31);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(103, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "CAD503P7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Reference";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_Message);
            this.groupBox3.Controls.Add(this.lbl_LoadingDataMatrix);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lbl_LoadingStatus);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(14, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 101);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loading Status";
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Green;
            this.lbl_Message.Location = new System.Drawing.Point(120, 67);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(45, 16);
            this.lbl_Message.TabIndex = 1;
            this.lbl_Message.Text = "label2";
            // 
            // lbl_LoadingDataMatrix
            // 
            this.lbl_LoadingDataMatrix.AutoSize = true;
            this.lbl_LoadingDataMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoadingDataMatrix.ForeColor = System.Drawing.Color.Green;
            this.lbl_LoadingDataMatrix.Location = new System.Drawing.Point(121, 45);
            this.lbl_LoadingDataMatrix.Name = "lbl_LoadingDataMatrix";
            this.lbl_LoadingDataMatrix.Size = new System.Drawing.Size(45, 16);
            this.lbl_LoadingDataMatrix.TabIndex = 1;
            this.lbl_LoadingDataMatrix.Text = "label2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Message";
            // 
            // lbl_LoadingStatus
            // 
            this.lbl_LoadingStatus.AutoSize = true;
            this.lbl_LoadingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoadingStatus.ForeColor = System.Drawing.Color.Green;
            this.lbl_LoadingStatus.Location = new System.Drawing.Point(121, 25);
            this.lbl_LoadingStatus.Name = "lbl_LoadingStatus";
            this.lbl_LoadingStatus.Size = new System.Drawing.Size(45, 16);
            this.lbl_LoadingStatus.TabIndex = 1;
            this.lbl_LoadingStatus.Text = "label2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Data Matrix";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "State";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl_UnloadingDataMatrix);
            this.groupBox4.Controls.Add(this.lbl_UnloadingState);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox4.Location = new System.Drawing.Point(14, 400);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(493, 86);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unloading Status";
            // 
            // lbl_UnloadingDataMatrix
            // 
            this.lbl_UnloadingDataMatrix.AutoSize = true;
            this.lbl_UnloadingDataMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UnloadingDataMatrix.ForeColor = System.Drawing.Color.Green;
            this.lbl_UnloadingDataMatrix.Location = new System.Drawing.Point(121, 45);
            this.lbl_UnloadingDataMatrix.Name = "lbl_UnloadingDataMatrix";
            this.lbl_UnloadingDataMatrix.Size = new System.Drawing.Size(45, 16);
            this.lbl_UnloadingDataMatrix.TabIndex = 1;
            this.lbl_UnloadingDataMatrix.Text = "label2";
            // 
            // lbl_UnloadingState
            // 
            this.lbl_UnloadingState.AutoSize = true;
            this.lbl_UnloadingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UnloadingState.ForeColor = System.Drawing.Color.Green;
            this.lbl_UnloadingState.Location = new System.Drawing.Point(121, 25);
            this.lbl_UnloadingState.Name = "lbl_UnloadingState";
            this.lbl_UnloadingState.Size = new System.Drawing.Size(45, 16);
            this.lbl_UnloadingState.TabIndex = 1;
            this.lbl_UnloadingState.Text = "label2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(15, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "Data Matrix";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(15, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "State";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(17, 81);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(274, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "338911081993CAD503P700002";
            // 
            // btn_WriteToLoading
            // 
            this.btn_WriteToLoading.Location = new System.Drawing.Point(17, 107);
            this.btn_WriteToLoading.Name = "btn_WriteToLoading";
            this.btn_WriteToLoading.Size = new System.Drawing.Size(124, 23);
            this.btn_WriteToLoading.TabIndex = 12;
            this.btn_WriteToLoading.Text = "WriteToLoading";
            this.btn_WriteToLoading.UseVisualStyleBackColor = true;
            this.btn_WriteToLoading.Click += new System.EventHandler(this.btn_WriteToLoading_Click);
            // 
            // btn_WriteToUnloading
            // 
            this.btn_WriteToUnloading.Location = new System.Drawing.Point(17, 230);
            this.btn_WriteToUnloading.Name = "btn_WriteToUnloading";
            this.btn_WriteToUnloading.Size = new System.Drawing.Size(130, 23);
            this.btn_WriteToUnloading.TabIndex = 13;
            this.btn_WriteToUnloading.Text = "WriteToUnloading";
            this.btn_WriteToUnloading.UseVisualStyleBackColor = true;
            this.btn_WriteToUnloading.Click += new System.EventHandler(this.btn_WriteToUnloading_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_ByPass);
            this.groupBox5.Controls.Add(this.chb_ScanLamp);
            this.groupBox5.Controls.Add(this.lbl_VirtualIndexer);
            this.groupBox5.Controls.Add(this.lbl_TraceabilityStates);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox5.Location = new System.Drawing.Point(14, 492);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(493, 88);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Traceability Status";
            // 
            // btn_ByPass
            // 
            this.btn_ByPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ByPass.Location = new System.Drawing.Point(402, 59);
            this.btn_ByPass.Name = "btn_ByPass";
            this.btn_ByPass.Size = new System.Drawing.Size(68, 23);
            this.btn_ByPass.TabIndex = 2;
            this.btn_ByPass.Text = "By Pass";
            this.btn_ByPass.UseVisualStyleBackColor = true;
            this.btn_ByPass.Click += new System.EventHandler(this.btn_ByPass_Click);
            // 
            // chb_ScanLamp
            // 
            this.chb_ScanLamp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_ScanLamp.AutoSize = true;
            this.chb_ScanLamp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chb_ScanLamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_ScanLamp.Location = new System.Drawing.Point(450, 22);
            this.chb_ScanLamp.Name = "chb_ScanLamp";
            this.chb_ScanLamp.Size = new System.Drawing.Size(20, 23);
            this.chb_ScanLamp.TabIndex = 2;
            this.chb_ScanLamp.Text = " ";
            this.chb_ScanLamp.UseVisualStyleBackColor = true;
            // 
            // lbl_VirtualIndexer
            // 
            this.lbl_VirtualIndexer.AutoSize = true;
            this.lbl_VirtualIndexer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VirtualIndexer.ForeColor = System.Drawing.Color.Green;
            this.lbl_VirtualIndexer.Location = new System.Drawing.Point(120, 50);
            this.lbl_VirtualIndexer.Name = "lbl_VirtualIndexer";
            this.lbl_VirtualIndexer.Size = new System.Drawing.Size(45, 16);
            this.lbl_VirtualIndexer.TabIndex = 1;
            this.lbl_VirtualIndexer.Text = "label2";
            // 
            // lbl_TraceabilityStates
            // 
            this.lbl_TraceabilityStates.AutoSize = true;
            this.lbl_TraceabilityStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TraceabilityStates.ForeColor = System.Drawing.Color.Green;
            this.lbl_TraceabilityStates.Location = new System.Drawing.Point(121, 25);
            this.lbl_TraceabilityStates.Name = "lbl_TraceabilityStates";
            this.lbl_TraceabilityStates.Size = new System.Drawing.Size(45, 16);
            this.lbl_TraceabilityStates.TabIndex = 1;
            this.lbl_TraceabilityStates.Text = "label2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Virtual Indexer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(379, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Scanner";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "State";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_Indexer
            // 
            this.lb_Indexer.FormattingEnabled = true;
            this.lb_Indexer.Location = new System.Drawing.Point(513, 165);
            this.lb_Indexer.Name = "lb_Indexer";
            this.lb_Indexer.Size = new System.Drawing.Size(366, 95);
            this.lb_Indexer.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(513, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Virtual Indexer";
            // 
            // gb_MachineSimulation
            // 
            this.gb_MachineSimulation.Controls.Add(this.button2);
            this.gb_MachineSimulation.Controls.Add(this.btn_Hide);
            this.gb_MachineSimulation.Controls.Add(this.btn_IndexTable);
            this.gb_MachineSimulation.Controls.Add(this.btn_SetProcessNok);
            this.gb_MachineSimulation.Controls.Add(this.btn_SetProcessOk);
            this.gb_MachineSimulation.Controls.Add(this.btn_SetRequestCheck);
            this.gb_MachineSimulation.Controls.Add(this.textBox4);
            this.gb_MachineSimulation.Controls.Add(this.label21);
            this.gb_MachineSimulation.Controls.Add(this.label18);
            this.gb_MachineSimulation.Controls.Add(this.label6);
            this.gb_MachineSimulation.Controls.Add(this.btn_WriteToUnloading);
            this.gb_MachineSimulation.Controls.Add(this.button1);
            this.gb_MachineSimulation.Controls.Add(this.textBox1);
            this.gb_MachineSimulation.Controls.Add(this.btn_WriteToLoading);
            this.gb_MachineSimulation.Controls.Add(this.textBox5);
            this.gb_MachineSimulation.Location = new System.Drawing.Point(557, 291);
            this.gb_MachineSimulation.Name = "gb_MachineSimulation";
            this.gb_MachineSimulation.Size = new System.Drawing.Size(322, 344);
            this.gb_MachineSimulation.TabIndex = 15;
            this.gb_MachineSimulation.TabStop = false;
            this.gb_MachineSimulation.Text = "Machine Simulation";
            this.gb_MachineSimulation.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Hide
            // 
            this.btn_Hide.Location = new System.Drawing.Point(241, 312);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(75, 23);
            this.btn_Hide.TabIndex = 18;
            this.btn_Hide.Text = "Hide";
            this.btn_Hide.UseVisualStyleBackColor = true;
            this.btn_Hide.Click += new System.EventHandler(this.btn_Hide_Click);
            // 
            // btn_IndexTable
            // 
            this.btn_IndexTable.Location = new System.Drawing.Point(17, 289);
            this.btn_IndexTable.Name = "btn_IndexTable";
            this.btn_IndexTable.Size = new System.Drawing.Size(130, 23);
            this.btn_IndexTable.TabIndex = 17;
            this.btn_IndexTable.Text = "Index Table";
            this.btn_IndexTable.UseVisualStyleBackColor = true;
            this.btn_IndexTable.Click += new System.EventHandler(this.btn_IndexTable_Click);
            // 
            // btn_SetProcessNok
            // 
            this.btn_SetProcessNok.Location = new System.Drawing.Point(154, 260);
            this.btn_SetProcessNok.Name = "btn_SetProcessNok";
            this.btn_SetProcessNok.Size = new System.Drawing.Size(117, 23);
            this.btn_SetProcessNok.TabIndex = 16;
            this.btn_SetProcessNok.Text = "Process Result NOk";
            this.btn_SetProcessNok.UseVisualStyleBackColor = true;
            this.btn_SetProcessNok.Click += new System.EventHandler(this.btn_SetProcessNok_Click);
            // 
            // btn_SetProcessOk
            // 
            this.btn_SetProcessOk.Location = new System.Drawing.Point(17, 260);
            this.btn_SetProcessOk.Name = "btn_SetProcessOk";
            this.btn_SetProcessOk.Size = new System.Drawing.Size(130, 23);
            this.btn_SetProcessOk.TabIndex = 15;
            this.btn_SetProcessOk.Text = "Process Result Ok";
            this.btn_SetProcessOk.UseVisualStyleBackColor = true;
            this.btn_SetProcessOk.Click += new System.EventHandler(this.btn_SetProcessOk_Click);
            // 
            // btn_SetRequestCheck
            // 
            this.btn_SetRequestCheck.Location = new System.Drawing.Point(17, 137);
            this.btn_SetRequestCheck.Name = "btn_SetRequestCheck";
            this.btn_SetRequestCheck.Size = new System.Drawing.Size(174, 23);
            this.btn_SetRequestCheck.TabIndex = 14;
            this.btn_SetRequestCheck.Text = "Request Traceability Check";
            this.btn_SetRequestCheck.UseVisualStyleBackColor = true;
            this.btn_SetRequestCheck.Click += new System.EventHandler(this.btn_SetRequestCheck_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 182);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Data Matrix";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Data Matrix";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 201);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "338911081993CAD503P700002";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(513, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "Warning and Alarm";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::TraceabilityConnector.Properties.Resources.sch;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(563, 380);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tmr_PlcRetry
            // 
            this.tmr_PlcRetry.Interval = 10000;
            this.tmr_PlcRetry.Tick += new System.EventHandler(this.tmr_PlcRetry_Tick);
            // 
            // gb_Embedded
            // 
            this.gb_Embedded.Controls.Add(this.lbl_OrderNumber);
            this.gb_Embedded.Controls.Add(this.label25);
            this.gb_Embedded.Controls.Add(this.lbl_GenerateResult);
            this.gb_Embedded.Controls.Add(this.label24);
            this.gb_Embedded.Controls.Add(this.lbl_GeneratedDataMatrix);
            this.gb_Embedded.Controls.Add(this.label26);
            this.gb_Embedded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Embedded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gb_Embedded.Location = new System.Drawing.Point(12, 291);
            this.gb_Embedded.Name = "gb_Embedded";
            this.gb_Embedded.Size = new System.Drawing.Size(494, 195);
            this.gb_Embedded.TabIndex = 16;
            this.gb_Embedded.TabStop = false;
            this.gb_Embedded.Text = "Datamatrix Generate";
            this.gb_Embedded.Visible = false;
            this.gb_Embedded.Enter += new System.EventHandler(this.gb_Embedded_Enter);
            // 
            // lbl_OrderNumber
            // 
            this.lbl_OrderNumber.AutoSize = true;
            this.lbl_OrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderNumber.ForeColor = System.Drawing.Color.Green;
            this.lbl_OrderNumber.Location = new System.Drawing.Point(125, 38);
            this.lbl_OrderNumber.Name = "lbl_OrderNumber";
            this.lbl_OrderNumber.Size = new System.Drawing.Size(17, 16);
            this.lbl_OrderNumber.TabIndex = 7;
            this.lbl_OrderNumber.Text = "   ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(19, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 16);
            this.label25.TabIndex = 6;
            this.label25.Text = "Order Number";
            // 
            // lbl_GenerateResult
            // 
            this.lbl_GenerateResult.AutoSize = true;
            this.lbl_GenerateResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GenerateResult.ForeColor = System.Drawing.Color.Green;
            this.lbl_GenerateResult.Location = new System.Drawing.Point(125, 90);
            this.lbl_GenerateResult.Name = "lbl_GenerateResult";
            this.lbl_GenerateResult.Size = new System.Drawing.Size(17, 16);
            this.lbl_GenerateResult.TabIndex = 4;
            this.lbl_GenerateResult.Text = "   ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(19, 90);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 16);
            this.label24.TabIndex = 2;
            this.label24.Text = "Result";
            // 
            // lbl_GeneratedDataMatrix
            // 
            this.lbl_GeneratedDataMatrix.AutoSize = true;
            this.lbl_GeneratedDataMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GeneratedDataMatrix.ForeColor = System.Drawing.Color.Green;
            this.lbl_GeneratedDataMatrix.Location = new System.Drawing.Point(125, 64);
            this.lbl_GeneratedDataMatrix.Name = "lbl_GeneratedDataMatrix";
            this.lbl_GeneratedDataMatrix.Size = new System.Drawing.Size(17, 16);
            this.lbl_GeneratedDataMatrix.TabIndex = 5;
            this.lbl_GeneratedDataMatrix.Text = "   ";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(19, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 16);
            this.label26.TabIndex = 3;
            this.label26.Text = "Data Matrix";
            // 
            // btnAlarmClear
            // 
            this.btnAlarmClear.Location = new System.Drawing.Point(804, 16);
            this.btnAlarmClear.Name = "btnAlarmClear";
            this.btnAlarmClear.Size = new System.Drawing.Size(75, 23);
            this.btnAlarmClear.TabIndex = 17;
            this.btnAlarmClear.Text = "Clear";
            this.btnAlarmClear.UseVisualStyleBackColor = true;
            this.btnAlarmClear.Click += new System.EventHandler(this.btnAlarmClear_Click);
            // 
            // tmr_CLock
            // 
            this.tmr_CLock.Interval = 1000;
            this.tmr_CLock.Tick += new System.EventHandler(this.tmr_CLock_Tick);
            // 
            // lbl_Clock
            // 
            this.lbl_Clock.AutoSize = true;
            this.lbl_Clock.Location = new System.Drawing.Point(248, 4);
            this.lbl_Clock.Name = "lbl_Clock";
            this.lbl_Clock.Size = new System.Drawing.Size(0, 13);
            this.lbl_Clock.TabIndex = 8;
            // 
            // myNotifyIcon
            // 
            this.myNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.myNotifyIcon.BalloonTipTitle = "Traceability";
            this.myNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotifyIcon.Icon")));
            this.myNotifyIcon.Text = "Traceability Connector";
            this.myNotifyIcon.Visible = true;
            this.myNotifyIcon.Click += new System.EventHandler(this.myNotifyIcon_Click);
            // 
            // TraceabilityConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 639);
            this.Controls.Add(this.btnAlarmClear);
            this.Controls.Add(this.gb_Embedded);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gb_MachineSimulation);
            this.Controls.Add(this.lb_Indexer);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_Clock);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gbEmbedded);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.btn_Initialize);
            this.Controls.Add(this.tb_ShowInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TraceabilityConnector";
            this.Text = "Traceability Connector Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TraceabilityConnector_FormClosing_1);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.VisibleChanged += new System.EventHandler(this.TraceabilityConnector_VisibleChanged);
            this.Resize += new System.EventHandler(this.TraceabilityConnector_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEmbedded.ResumeLayout(false);
            this.gbEmbedded.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gb_MachineSimulation.ResumeLayout(false);
            this.gb_MachineSimulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_Embedded.ResumeLayout(false);
            this.gb_Embedded.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_Scanner;
        private System.Windows.Forms.TextBox tb_ShowInformation;
        private System.Windows.Forms.Button btn_Initialize;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_MachineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_MachineCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbEmbedded;
        private System.Windows.Forms.Label lbl_Sequence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Article;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Reference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_MachineFamily;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_PreviousMachine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_LoadingStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_LoadingDataMatrix;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_UnloadingDataMatrix;
        private System.Windows.Forms.Label lbl_UnloadingState;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btn_WriteToLoading;
        private System.Windows.Forms.Button btn_WriteToUnloading;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_plcIpAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_PlcConnection;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_TraceabilityStates;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chb_ScanLamp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb_Indexer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_VirtualIndexer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_LoadReference;
        private System.Windows.Forms.GroupBox gb_MachineSimulation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_SetRequestCheck;
        private System.Windows.Forms.Button btn_SetProcessNok;
        private System.Windows.Forms.Button btn_SetProcessOk;
        private System.Windows.Forms.Button btn_IndexTable;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.Button btn_ByPass;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tmr_PlcRetry;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gb_Embedded;
        private System.Windows.Forms.Button btnAlarmClear;
        private System.Windows.Forms.Label lbl_GenerateResult;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl_GeneratedDataMatrix;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbl_OrderNumber;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer tmr_CLock;
        private System.Windows.Forms.Label lbl_Clock;
        private System.Windows.Forms.NotifyIcon myNotifyIcon;
    }
}

