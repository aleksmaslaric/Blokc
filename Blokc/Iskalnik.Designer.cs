namespace Blokc
{
    partial class Iskalnik
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
            this.lblPoisci = new System.Windows.Forms.Label();
            this.txtPoisci = new System.Windows.Forms.TextBox();
            this.btnPoisci = new System.Windows.Forms.Button();
            this.btnZamenjaj = new System.Windows.Forms.Button();
            this.btnPreklici = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblZamenjaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPoisci
            // 
            this.lblPoisci.AutoSize = true;
            this.lblPoisci.Font = new System.Drawing.Font("Calibri", 11F);
            this.lblPoisci.Location = new System.Drawing.Point(14, 70);
            this.lblPoisci.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPoisci.Name = "lblPoisci";
            this.lblPoisci.Size = new System.Drawing.Size(59, 23);
            this.lblPoisci.TabIndex = 0;
            this.lblPoisci.Text = "Poišči:";
            // 
            // txtPoisci
            // 
            this.txtPoisci.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtPoisci.Location = new System.Drawing.Point(117, 70);
            this.txtPoisci.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPoisci.Name = "txtPoisci";
            this.txtPoisci.Size = new System.Drawing.Size(220, 30);
            this.txtPoisci.TabIndex = 1;
            // 
            // btnPoisci
            // 
            this.btnPoisci.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnPoisci.Location = new System.Drawing.Point(365, 22);
            this.btnPoisci.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPoisci.Name = "btnPoisci";
            this.btnPoisci.Size = new System.Drawing.Size(126, 53);
            this.btnPoisci.TabIndex = 2;
            this.btnPoisci.Text = "POIŠČI";
            this.btnPoisci.UseVisualStyleBackColor = true;
            this.btnPoisci.Click += new System.EventHandler(this.btnPoisci_Click);
            // 
            // btnZamenjaj
            // 
            this.btnZamenjaj.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnZamenjaj.Location = new System.Drawing.Point(365, 101);
            this.btnZamenjaj.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnZamenjaj.Name = "btnZamenjaj";
            this.btnZamenjaj.Size = new System.Drawing.Size(126, 53);
            this.btnZamenjaj.TabIndex = 3;
            this.btnZamenjaj.Text = "ZAMENJAJ";
            this.btnZamenjaj.UseVisualStyleBackColor = true;
            this.btnZamenjaj.Click += new System.EventHandler(this.btnZamenjaj_Click);
            // 
            // btnPreklici
            // 
            this.btnPreklici.Font = new System.Drawing.Font("Calibri", 11F);
            this.btnPreklici.Location = new System.Drawing.Point(365, 180);
            this.btnPreklici.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPreklici.Name = "btnPreklici";
            this.btnPreklici.Size = new System.Drawing.Size(126, 53);
            this.btnPreklici.TabIndex = 4;
            this.btnPreklici.Text = "PREKLIČI";
            this.btnPreklici.UseVisualStyleBackColor = true;
            this.btnPreklici.Click += new System.EventHandler(this.btnPreklici_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11F);
            this.textBox1.Location = new System.Drawing.Point(117, 150);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 30);
            this.textBox1.TabIndex = 6;
            // 
            // lblZamenjaj
            // 
            this.lblZamenjaj.AutoSize = true;
            this.lblZamenjaj.Font = new System.Drawing.Font("Calibri", 11F);
            this.lblZamenjaj.Location = new System.Drawing.Point(14, 150);
            this.lblZamenjaj.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblZamenjaj.Name = "lblZamenjaj";
            this.lblZamenjaj.Size = new System.Drawing.Size(86, 23);
            this.lblZamenjaj.TabIndex = 5;
            this.lblZamenjaj.Text = "Zamenjaj:";
            // 
            // Iskalnik
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(535, 259);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblZamenjaj);
            this.Controls.Add(this.btnPreklici);
            this.Controls.Add(this.btnZamenjaj);
            this.Controls.Add(this.btnPoisci);
            this.Controls.Add(this.txtPoisci);
            this.Controls.Add(this.lblPoisci);
            this.Font = new System.Drawing.Font("Calibri", 11F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Iskalnik";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Iskalnik";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPoisci;
        private System.Windows.Forms.TextBox txtPoisci;
        private System.Windows.Forms.Button btnPoisci;
        private System.Windows.Forms.Button btnZamenjaj;
        private System.Windows.Forms.Button btnPreklici;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblZamenjaj;
    }
}