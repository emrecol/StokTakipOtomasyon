﻿namespace StokTakip
{
    partial class MERKEZ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MERKEZ));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrunadet = new System.Windows.Forms.TextBox();
            this.txtUrunid = new System.Windows.Forms.TextBox();
            this.cbTransType = new System.Windows.Forms.ComboBox();
            this.cbTargetW = new System.Windows.Forms.ComboBox();
            this.cbSourceW = new System.Windows.Forms.ComboBox();
            this.dtgvBildirim = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSaat = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dtgvMerkez = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBildirim)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMerkez)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUrunadet);
            this.groupBox1.Controls.Add(this.txtUrunid);
            this.groupBox1.Controls.Add(this.cbTransType);
            this.groupBox1.Controls.Add(this.cbTargetW);
            this.groupBox1.Controls.Add(this.cbSourceW);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 693);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRANSFER İŞLEMLERİ";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(228, 397);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(153, 26);
            this.btnKaydet.TabIndex = 23;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(140, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ürün Adet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(160, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ürün İd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(383, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Hareket Tipi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(224, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hedef Depo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(65, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Kaynek Depo";
            // 
            // txtUrunadet
            // 
            this.txtUrunadet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUrunadet.Location = new System.Drawing.Point(228, 333);
            this.txtUrunadet.Name = "txtUrunadet";
            this.txtUrunadet.Size = new System.Drawing.Size(153, 26);
            this.txtUrunadet.TabIndex = 17;
            this.txtUrunadet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunadet_KeyPress);
            // 
            // txtUrunid
            // 
            this.txtUrunid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUrunid.Location = new System.Drawing.Point(228, 301);
            this.txtUrunid.Name = "txtUrunid";
            this.txtUrunid.Size = new System.Drawing.Size(153, 26);
            this.txtUrunid.TabIndex = 16;
            // 
            // cbTransType
            // 
            this.cbTransType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTransType.FormattingEnabled = true;
            this.cbTransType.Location = new System.Drawing.Point(387, 235);
            this.cbTransType.Name = "cbTransType";
            this.cbTransType.Size = new System.Drawing.Size(153, 28);
            this.cbTransType.TabIndex = 14;
            // 
            // cbTargetW
            // 
            this.cbTargetW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTargetW.FormattingEnabled = true;
            this.cbTargetW.Location = new System.Drawing.Point(228, 235);
            this.cbTargetW.Name = "cbTargetW";
            this.cbTargetW.Size = new System.Drawing.Size(153, 28);
            this.cbTargetW.TabIndex = 13;
            this.cbTargetW.SelectedIndexChanged += new System.EventHandler(this.cbTargetW_SelectedIndexChanged);
            // 
            // cbSourceW
            // 
            this.cbSourceW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbSourceW.FormattingEnabled = true;
            this.cbSourceW.Location = new System.Drawing.Point(69, 235);
            this.cbSourceW.Name = "cbSourceW";
            this.cbSourceW.Size = new System.Drawing.Size(153, 28);
            this.cbSourceW.TabIndex = 12;
            // 
            // dtgvBildirim
            // 
            this.dtgvBildirim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBildirim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBildirim.Location = new System.Drawing.Point(6, 19);
            this.dtgvBildirim.Name = "dtgvBildirim";
            this.dtgvBildirim.Size = new System.Drawing.Size(882, 230);
            this.dtgvBildirim.TabIndex = 25;
            this.dtgvBildirim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvBildirim_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSaat);
            this.groupBox2.Controls.Add(this.lblTarih);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 711);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 57);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarih - Saat";
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat.Location = new System.Drawing.Point(320, 22);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(51, 20);
            this.lblSaat.TabIndex = 1;
            this.lblSaat.Text = "label7";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(15, 22);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(51, 20);
            this.lblTarih.TabIndex = 0;
            this.lblTarih.Text = "label6";
            // 
            // dtgvMerkez
            // 
            this.dtgvMerkez.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvMerkez.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvMerkez.Location = new System.Drawing.Point(6, 19);
            this.dtgvMerkez.Name = "dtgvMerkez";
            this.dtgvMerkez.Size = new System.Drawing.Size(882, 470);
            this.dtgvMerkez.TabIndex = 15;
            this.dtgvMerkez.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvMerkez_CellDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgvMerkez);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(658, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(894, 495);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TABLO";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtgvBildirim);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(658, 513);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(894, 255);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "KRİTİK ÜRÜNLER";
            // 
            // MERKEZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 780);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MERKEZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MERKEZ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MERKEZ_FormClosing);
            this.Load += new System.EventHandler(this.MERKEZ_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBildirim)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvMerkez)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgvBildirim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSaat;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrunadet;
        private System.Windows.Forms.TextBox txtUrunid;
        private System.Windows.Forms.DataGridView dtgvMerkez;
        private System.Windows.Forms.ComboBox cbTransType;
        private System.Windows.Forms.ComboBox cbTargetW;
        public System.Windows.Forms.ComboBox cbSourceW;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}