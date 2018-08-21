namespace DIAG327
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.description_label1 = new System.Windows.Forms.Label();
            this.description_label2 = new System.Windows.Forms.Label();
            this.description_label3 = new System.Windows.Forms.Label();
            this.description_label4 = new System.Windows.Forms.Label();
            this.description_label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // description_label1
            // 
            this.description_label1.AutoSize = true;
            this.description_label1.Location = new System.Drawing.Point(12, 67);
            this.description_label1.Name = "description_label1";
            this.description_label1.Size = new System.Drawing.Size(320, 13);
            this.description_label1.TabIndex = 1;
            this.description_label1.Text = "Программа для диагностики автомобилей с ЭБУ Январь 5.1 ";
            // 
            // description_label2
            // 
            this.description_label2.AutoSize = true;
            this.description_label2.Location = new System.Drawing.Point(12, 80);
            this.description_label2.Name = "description_label2";
            this.description_label2.Size = new System.Drawing.Size(314, 13);
            this.description_label2.TabIndex = 2;
            this.description_label2.Text = "и Январь 7.2 при помощи диагностического кабеля ELM327";
            // 
            // description_label3
            // 
            this.description_label3.AutoSize = true;
            this.description_label3.Location = new System.Drawing.Point(12, 93);
            this.description_label3.Name = "description_label3";
            this.description_label3.Size = new System.Drawing.Size(78, 13);
            this.description_label3.TabIndex = 3;
            this.description_label3.Text = "DIAG327 v1.1.";
            // 
            // description_label4
            // 
            this.description_label4.AutoSize = true;
            this.description_label4.Location = new System.Drawing.Point(12, 115);
            this.description_label4.Name = "description_label4";
            this.description_label4.Size = new System.Drawing.Size(191, 13);
            this.description_label4.TabIndex = 4;
            this.description_label4.Text = "Харламов Даниил денисович 2018г.";
            // 
            // description_label5
            // 
            this.description_label5.AutoSize = true;
            this.description_label5.Location = new System.Drawing.Point(12, 130);
            this.description_label5.Name = "description_label5";
            this.description_label5.Size = new System.Drawing.Size(264, 13);
            this.description_label5.TabIndex = 5;
            this.description_label5.Text = "СПбПУ \"Высшая школа программной инженерии\"";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 152);
            this.Controls.Add(this.description_label5);
            this.Controls.Add(this.description_label4);
            this.Controls.Add(this.description_label3);
            this.Controls.Add(this.description_label2);
            this.Controls.Add(this.description_label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label description_label1;
        private System.Windows.Forms.Label description_label2;
        private System.Windows.Forms.Label description_label3;
        private System.Windows.Forms.Label description_label4;
        private System.Windows.Forms.Label description_label5;
    }
}