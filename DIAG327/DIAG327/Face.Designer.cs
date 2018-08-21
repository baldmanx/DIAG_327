namespace DIAG327
{
    partial class Face
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Face));
            this.auto_groupBox = new System.Windows.Forms.GroupBox();
            this.auto_info_label = new System.Windows.Forms.Label();
            this.ecu_groupBox = new System.Windows.Forms.GroupBox();
            this.ecu_label = new System.Windows.Forms.Label();
            this.add_eq_groupBox = new System.Windows.Forms.GroupBox();
            this.additional_equipment_label = new System.Windows.Forms.Label();
            this.info_button = new System.Windows.Forms.Button();
            this.about_button = new System.Windows.Forms.Button();
            this.device_status_label = new System.Windows.Forms.Label();
            this.port_status_label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.go_to_diag_button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.auto_groupBox.SuspendLayout();
            this.ecu_groupBox.SuspendLayout();
            this.add_eq_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // auto_groupBox
            // 
            this.auto_groupBox.Controls.Add(this.auto_info_label);
            this.auto_groupBox.Location = new System.Drawing.Point(12, 49);
            this.auto_groupBox.Name = "auto_groupBox";
            this.auto_groupBox.Size = new System.Drawing.Size(326, 60);
            this.auto_groupBox.TabIndex = 0;
            this.auto_groupBox.TabStop = false;
            this.auto_groupBox.Text = "Автомобиль";
            // 
            // auto_info_label
            // 
            this.auto_info_label.AutoSize = true;
            this.auto_info_label.Location = new System.Drawing.Point(6, 25);
            this.auto_info_label.Name = "auto_info_label";
            this.auto_info_label.Size = new System.Drawing.Size(0, 13);
            this.auto_info_label.TabIndex = 0;
            // 
            // ecu_groupBox
            // 
            this.ecu_groupBox.Controls.Add(this.ecu_label);
            this.ecu_groupBox.Location = new System.Drawing.Point(12, 115);
            this.ecu_groupBox.Name = "ecu_groupBox";
            this.ecu_groupBox.Size = new System.Drawing.Size(326, 60);
            this.ecu_groupBox.TabIndex = 1;
            this.ecu_groupBox.TabStop = false;
            this.ecu_groupBox.Text = "ЭБУ";
            // 
            // ecu_label
            // 
            this.ecu_label.AutoSize = true;
            this.ecu_label.Location = new System.Drawing.Point(6, 27);
            this.ecu_label.Name = "ecu_label";
            this.ecu_label.Size = new System.Drawing.Size(0, 13);
            this.ecu_label.TabIndex = 0;
            // 
            // add_eq_groupBox
            // 
            this.add_eq_groupBox.Controls.Add(this.additional_equipment_label);
            this.add_eq_groupBox.Location = new System.Drawing.Point(12, 181);
            this.add_eq_groupBox.Name = "add_eq_groupBox";
            this.add_eq_groupBox.Size = new System.Drawing.Size(326, 60);
            this.add_eq_groupBox.TabIndex = 1;
            this.add_eq_groupBox.TabStop = false;
            this.add_eq_groupBox.Text = "Система, тип двигателя";
            // 
            // additional_equipment_label
            // 
            this.additional_equipment_label.AutoSize = true;
            this.additional_equipment_label.Location = new System.Drawing.Point(6, 25);
            this.additional_equipment_label.Name = "additional_equipment_label";
            this.additional_equipment_label.Size = new System.Drawing.Size(0, 13);
            this.additional_equipment_label.TabIndex = 0;
            // 
            // info_button
            // 
            this.info_button.Enabled = false;
            this.info_button.Location = new System.Drawing.Point(173, 12);
            this.info_button.Name = "info_button";
            this.info_button.Size = new System.Drawing.Size(75, 23);
            this.info_button.TabIndex = 3;
            this.info_button.Text = "Справка";
            this.info_button.UseVisualStyleBackColor = true;
            this.info_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // about_button
            // 
            this.about_button.Enabled = false;
            this.about_button.Location = new System.Drawing.Point(254, 12);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(84, 23);
            this.about_button.TabIndex = 4;
            this.about_button.Text = "О программе";
            this.about_button.UseVisualStyleBackColor = true;
            this.about_button.Click += new System.EventHandler(this.about_button_Click);
            // 
            // device_status_label
            // 
            this.device_status_label.AutoSize = true;
            this.device_status_label.Location = new System.Drawing.Point(9, 291);
            this.device_status_label.Name = "device_status_label";
            this.device_status_label.Size = new System.Drawing.Size(121, 13);
            this.device_status_label.TabIndex = 5;
            this.device_status_label.Text = "Состояние устройства";
            // 
            // port_status_label
            // 
            this.port_status_label.AutoSize = true;
            this.port_status_label.Location = new System.Drawing.Point(170, 291);
            this.port_status_label.Name = "port_status_label";
            this.port_status_label.Size = new System.Drawing.Size(32, 13);
            this.port_status_label.TabIndex = 6;
            this.port_status_label.Text = "Порт";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(47)))), ((int)(((byte)(145)))));
            this.progressBar.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.progressBar.Location = new System.Drawing.Point(12, 247);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(226, 38);
            this.progressBar.Step = 8;
            this.progressBar.TabIndex = 7;
            this.progressBar.EnabledChanged += new System.EventHandler(this.progressBar_EnabledChanged);
            // 
            // go_to_diag_button
            // 
            this.go_to_diag_button.Enabled = false;
            this.go_to_diag_button.Location = new System.Drawing.Point(257, 247);
            this.go_to_diag_button.Name = "go_to_diag_button";
            this.go_to_diag_button.Size = new System.Drawing.Size(81, 38);
            this.go_to_diag_button.TabIndex = 8;
            this.go_to_diag_button.Text = "Перейти к диагностике";
            this.go_to_diag_button.UseVisualStyleBackColor = true;
            this.go_to_diag_button.Click += new System.EventHandler(this.go_to_diag_button_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 40);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Face
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(346, 313);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.go_to_diag_button);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.port_status_label);
            this.Controls.Add(this.device_status_label);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.info_button);
            this.Controls.Add(this.add_eq_groupBox);
            this.Controls.Add(this.ecu_groupBox);
            this.Controls.Add(this.auto_groupBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(362, 352);
            this.MinimumSize = new System.Drawing.Size(362, 352);
            this.Name = "Face";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Diag327";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Face_FormClosing);
            this.auto_groupBox.ResumeLayout(false);
            this.auto_groupBox.PerformLayout();
            this.ecu_groupBox.ResumeLayout(false);
            this.ecu_groupBox.PerformLayout();
            this.add_eq_groupBox.ResumeLayout(false);
            this.add_eq_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox auto_groupBox;
        private System.Windows.Forms.GroupBox ecu_groupBox;
        private System.Windows.Forms.GroupBox add_eq_groupBox;
        private System.Windows.Forms.Button info_button;
        private System.Windows.Forms.Button about_button;
        private System.Windows.Forms.Label device_status_label;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button go_to_diag_button;
        private System.Windows.Forms.Label auto_info_label;
        private System.Windows.Forms.Label ecu_label;
        private System.Windows.Forms.Label additional_equipment_label;
        public System.Windows.Forms.Label port_status_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected internal System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

