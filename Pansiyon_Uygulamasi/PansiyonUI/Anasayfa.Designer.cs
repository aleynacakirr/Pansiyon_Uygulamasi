﻿namespace Pansiyon_Uygulamasi.PansiyonUI
{
    partial class Anasayfa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnOdalar = new System.Windows.Forms.Button();
            this.btnKonaklamalar = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.btnPersoneller = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnCikis);
            this.panel1.Controls.Add(this.btnOdalar);
            this.panel1.Controls.Add(this.btnKonaklamalar);
            this.panel1.Controls.Add(this.btnMusteriler);
            this.panel1.Controls.Add(this.btnPersoneller);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 450);
            this.panel1.TabIndex = 1;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(18, 398);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(111, 40);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnOdalar
            // 
            this.btnOdalar.Location = new System.Drawing.Point(18, 201);
            this.btnOdalar.Name = "btnOdalar";
            this.btnOdalar.Size = new System.Drawing.Size(111, 40);
            this.btnOdalar.TabIndex = 0;
            this.btnOdalar.Text = "Odalar";
            this.btnOdalar.UseVisualStyleBackColor = true;
            this.btnOdalar.Click += new System.EventHandler(this.btnOdalar_Click);
            // 
            // btnKonaklamalar
            // 
            this.btnKonaklamalar.Location = new System.Drawing.Point(18, 141);
            this.btnKonaklamalar.Name = "btnKonaklamalar";
            this.btnKonaklamalar.Size = new System.Drawing.Size(111, 40);
            this.btnKonaklamalar.TabIndex = 0;
            this.btnKonaklamalar.Text = "Konaklamalar";
            this.btnKonaklamalar.UseVisualStyleBackColor = true;
            this.btnKonaklamalar.Click += new System.EventHandler(this.btnKonaklamalar_Click);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Location = new System.Drawing.Point(18, 82);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(111, 40);
            this.btnMusteriler.TabIndex = 0;
            this.btnMusteriler.Text = "Müşteriler";
            this.btnMusteriler.UseVisualStyleBackColor = true;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click);
            // 
            // btnPersoneller
            // 
            this.btnPersoneller.Location = new System.Drawing.Point(18, 26);
            this.btnPersoneller.Name = "btnPersoneller";
            this.btnPersoneller.Size = new System.Drawing.Size(111, 40);
            this.btnPersoneller.TabIndex = 0;
            this.btnPersoneller.Text = "Personeller";
            this.btnPersoneller.UseVisualStyleBackColor = true;
            this.btnPersoneller.Click += new System.EventHandler(this.btnPersoneller_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(151, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 450);
            this.panel2.TabIndex = 2;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Anasayfa";
            this.Text = "Anasayfa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Anasayfa_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnOdalar;
        private System.Windows.Forms.Button btnKonaklamalar;
        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button btnPersoneller;
        private System.Windows.Forms.Panel panel2;
    }
}