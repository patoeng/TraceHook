namespace Traceability.Hook.Setting
{
    partial class HookSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HookSetting));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_MachineSerialNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_StartEdit = new System.Windows.Forms.Button();
            this.btn_ReloadSetting = new System.Windows.Forms.Button();
            this.cb_EnableTraceability = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_DbConnectionString = new System.Windows.Forms.TextBox();
            this.tb_AdminPassword = new System.Windows.Forms.TextBox();
            this.tb_PlcIpAddress = new System.Windows.Forms.TextBox();
            this.tb_UniqueIdentityLength = new System.Windows.Forms.TextBox();
            this.tb_NumberOfStation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Serial Number";
            // 
            // tb_MachineSerialNumber
            // 
            this.tb_MachineSerialNumber.Location = new System.Drawing.Point(183, 20);
            this.tb_MachineSerialNumber.Name = "tb_MachineSerialNumber";
            this.tb_MachineSerialNumber.ReadOnly = true;
            this.tb_MachineSerialNumber.Size = new System.Drawing.Size(231, 20);
            this.tb_MachineSerialNumber.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.btn_StartEdit);
            this.groupBox1.Controls.Add(this.btn_ReloadSetting);
            this.groupBox1.Controls.Add(this.cb_EnableTraceability);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_DbConnectionString);
            this.groupBox1.Controls.Add(this.tb_AdminPassword);
            this.groupBox1.Controls.Add(this.tb_PlcIpAddress);
            this.groupBox1.Controls.Add(this.tb_UniqueIdentityLength);
            this.groupBox1.Controls.Add(this.tb_NumberOfStation);
            this.groupBox1.Controls.Add(this.tb_MachineSerialNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 330);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(345, 267);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 51);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(264, 267);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 51);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_StartEdit
            // 
            this.btn_StartEdit.Location = new System.Drawing.Point(183, 267);
            this.btn_StartEdit.Name = "btn_StartEdit";
            this.btn_StartEdit.Size = new System.Drawing.Size(75, 51);
            this.btn_StartEdit.TabIndex = 4;
            this.btn_StartEdit.Text = "Start Edit";
            this.btn_StartEdit.UseVisualStyleBackColor = true;
            this.btn_StartEdit.Click += new System.EventHandler(this.btn_StartEdit_Click);
            // 
            // btn_ReloadSetting
            // 
            this.btn_ReloadSetting.Location = new System.Drawing.Point(102, 267);
            this.btn_ReloadSetting.Name = "btn_ReloadSetting";
            this.btn_ReloadSetting.Size = new System.Drawing.Size(75, 51);
            this.btn_ReloadSetting.TabIndex = 3;
            this.btn_ReloadSetting.Text = "Reload Setting";
            this.btn_ReloadSetting.UseVisualStyleBackColor = true;
            this.btn_ReloadSetting.Click += new System.EventHandler(this.btn_ReloadSetting_Click);
            // 
            // cb_EnableTraceability
            // 
            this.cb_EnableTraceability.AutoSize = true;
            this.cb_EnableTraceability.Enabled = false;
            this.cb_EnableTraceability.Location = new System.Drawing.Point(183, 103);
            this.cb_EnableTraceability.Name = "cb_EnableTraceability";
            this.cb_EnableTraceability.Size = new System.Drawing.Size(59, 17);
            this.cb_EnableTraceability.TabIndex = 2;
            this.cb_EnableTraceability.Text = "Enable";
            this.cb_EnableTraceability.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Database Connection String";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Admin Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Plc Ip Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Traceability System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unique Identity Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number Of Station";
            // 
            // tb_DbConnectionString
            // 
            this.tb_DbConnectionString.Location = new System.Drawing.Point(183, 126);
            this.tb_DbConnectionString.Multiline = true;
            this.tb_DbConnectionString.Name = "tb_DbConnectionString";
            this.tb_DbConnectionString.ReadOnly = true;
            this.tb_DbConnectionString.Size = new System.Drawing.Size(232, 58);
            this.tb_DbConnectionString.TabIndex = 1;
            // 
            // tb_AdminPassword
            // 
            this.tb_AdminPassword.Location = new System.Drawing.Point(184, 216);
            this.tb_AdminPassword.Name = "tb_AdminPassword";
            this.tb_AdminPassword.PasswordChar = '.';
            this.tb_AdminPassword.ReadOnly = true;
            this.tb_AdminPassword.Size = new System.Drawing.Size(231, 20);
            this.tb_AdminPassword.TabIndex = 1;
            // 
            // tb_PlcIpAddress
            // 
            this.tb_PlcIpAddress.Location = new System.Drawing.Point(183, 190);
            this.tb_PlcIpAddress.Name = "tb_PlcIpAddress";
            this.tb_PlcIpAddress.ReadOnly = true;
            this.tb_PlcIpAddress.Size = new System.Drawing.Size(231, 20);
            this.tb_PlcIpAddress.TabIndex = 1;
            // 
            // tb_UniqueIdentityLength
            // 
            this.tb_UniqueIdentityLength.Location = new System.Drawing.Point(183, 72);
            this.tb_UniqueIdentityLength.Name = "tb_UniqueIdentityLength";
            this.tb_UniqueIdentityLength.ReadOnly = true;
            this.tb_UniqueIdentityLength.Size = new System.Drawing.Size(231, 20);
            this.tb_UniqueIdentityLength.TabIndex = 1;
            // 
            // tb_NumberOfStation
            // 
            this.tb_NumberOfStation.Location = new System.Drawing.Point(183, 46);
            this.tb_NumberOfStation.Name = "tb_NumberOfStation";
            this.tb_NumberOfStation.ReadOnly = true;
            this.tb_NumberOfStation.Size = new System.Drawing.Size(231, 20);
            this.tb_NumberOfStation.TabIndex = 1;
            // 
            // HookSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 330);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HookSetting";
            this.Text = "Traceability Machine Setting";
            this.Load += new System.EventHandler(this.HookSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MachineSerialNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_DbConnectionString;
        private System.Windows.Forms.TextBox tb_UniqueIdentityLength;
        private System.Windows.Forms.TextBox tb_NumberOfStation;
        private System.Windows.Forms.CheckBox cb_EnableTraceability;
        private System.Windows.Forms.Button btn_StartEdit;
        private System.Windows.Forms.Button btn_ReloadSetting;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_PlcIpAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_AdminPassword;
    }
}

