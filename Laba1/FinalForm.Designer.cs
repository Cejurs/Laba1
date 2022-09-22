namespace Laba1
{
    partial class FinalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.AnalisBtn = new System.Windows.Forms.Button();
            this.Okbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Профессия была отгадана";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AnalisBtn
            // 
            this.AnalisBtn.Location = new System.Drawing.Point(69, 72);
            this.AnalisBtn.Name = "AnalisBtn";
            this.AnalisBtn.Size = new System.Drawing.Size(142, 38);
            this.AnalisBtn.TabIndex = 1;
            this.AnalisBtn.Text = "Анализировать";
            this.AnalisBtn.UseVisualStyleBackColor = true;
            this.AnalisBtn.Click += new System.EventHandler(this.AnalisBtn_Click);
            // 
            // Okbtn
            // 
            this.Okbtn.Location = new System.Drawing.Point(257, 72);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(130, 38);
            this.Okbtn.TabIndex = 2;
            this.Okbtn.Text = "ОК";
            this.Okbtn.UseVisualStyleBackColor = true;
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            // 
            // FinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 133);
            this.ControlBox = false;
            this.Controls.Add(this.Okbtn);
            this.Controls.Add(this.AnalisBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinalForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FinalForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button AnalisBtn;
        private Button Okbtn;
    }
}