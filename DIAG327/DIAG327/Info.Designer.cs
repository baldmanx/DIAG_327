namespace DIAG327
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.info_comboBox = new System.Windows.Forms.ComboBox();
            this.info_richTextBox = new System.Windows.Forms.RichTextBox();
            this.info_label1 = new System.Windows.Forms.Label();
            this.info_label2 = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // info_comboBox
            // 
            this.info_comboBox.FormattingEnabled = true;
            this.info_comboBox.Items.AddRange(new object[] {
            "Температура охл. жидкости",
            "Соотношение воздух/топливо",
            "Положение дроссельной заслонки",
            "Скорость вращения двигателя",
            "Скор. вращ. двигателя на хол. ходу",
            "Желаемое положение  рег. хол. хода",
            "Текущее положение рег. хол. хода",
            "Коэфф. коррекции времени впрыска",
            "Угол опережения зажигания",
            "Скорость автомобиля",
            "Напряжение бортсети",
            "Желаемые обороты холостого хода",
            "Напряжение на датчике кислорода",
            "Флаги состояния на датчике СО",
            "Длительность импульса впрыска",
            "Массовый расход воздуха",
            "Цикловой расход воздуха",
            "Часовой расход топлива",
            "Путевой расход топлива"});
            this.info_comboBox.Location = new System.Drawing.Point(12, 54);
            this.info_comboBox.Name = "info_comboBox";
            this.info_comboBox.Size = new System.Drawing.Size(233, 21);
            this.info_comboBox.TabIndex = 6;
            this.info_comboBox.SelectedIndexChanged += new System.EventHandler(this.info_comboBox_SelectedIndexChanged);
            // 
            // info_richTextBox
            // 
            this.info_richTextBox.Location = new System.Drawing.Point(12, 81);
            this.info_richTextBox.Name = "info_richTextBox";
            this.info_richTextBox.Size = new System.Drawing.Size(397, 137);
            this.info_richTextBox.TabIndex = 7;
            this.info_richTextBox.Text = "";
            // 
            // info_label1
            // 
            this.info_label1.AutoSize = true;
            this.info_label1.Location = new System.Drawing.Point(9, 9);
            this.info_label1.Name = "info_label1";
            this.info_label1.Size = new System.Drawing.Size(411, 13);
            this.info_label1.TabIndex = 10;
            this.info_label1.Text = "Для того, чтобы воспользоваться справкой, выберите интересующий элемент";
            // 
            // info_label2
            // 
            this.info_label2.AutoSize = true;
            this.info_label2.Location = new System.Drawing.Point(12, 22);
            this.info_label2.Name = "info_label2";
            this.info_label2.Size = new System.Drawing.Size(317, 13);
            this.info_label2.TabIndex = 11;
            this.info_label2.Text = "из выпадающего списка, информация о нём появится ниже.";
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(334, 224);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(75, 23);
            this.close_button.TabIndex = 12;
            this.close_button.Text = "Закрыть";
            this.close_button.UseVisualStyleBackColor = true;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 256);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.info_label2);
            this.Controls.Add(this.info_label1);
            this.Controls.Add(this.info_richTextBox);
            this.Controls.Add(this.info_comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox info_comboBox;
        private System.Windows.Forms.RichTextBox info_richTextBox;
        private System.Windows.Forms.Label info_label1;
        private System.Windows.Forms.Label info_label2;
        private System.Windows.Forms.Button close_button;
    }
}