﻿namespace Kalkulačka_v3
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nula = new System.Windows.Forms.Button();
            this.jedna = new System.Windows.Forms.Button();
            this.dva = new System.Windows.Forms.Button();
            this.tri = new System.Windows.Forms.Button();
            this.ctyri = new System.Windows.Forms.Button();
            this.pet = new System.Windows.Forms.Button();
            this.sest = new System.Windows.Forms.Button();
            this.sedm = new System.Windows.Forms.Button();
            this.osm = new System.Windows.Forms.Button();
            this.devet = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.krat = new System.Windows.Forms.Button();
            this.deleno = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rovnase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bck = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.basicCalc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(18, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(171, 32);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nula
            // 
            this.nula.Location = new System.Drawing.Point(60, 306);
            this.nula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nula.Name = "nula";
            this.nula.Size = new System.Drawing.Size(40, 40);
            this.nula.TabIndex = 26;
            this.nula.Text = "0";
            this.nula.UseVisualStyleBackColor = true;
            this.nula.Click += new System.EventHandler(this.nula_Click);
            // 
            // jedna
            // 
            this.jedna.Location = new System.Drawing.Point(15, 262);
            this.jedna.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jedna.Name = "jedna";
            this.jedna.Size = new System.Drawing.Size(40, 40);
            this.jedna.TabIndex = 15;
            this.jedna.Text = "1";
            this.jedna.UseVisualStyleBackColor = true;
            this.jedna.Click += new System.EventHandler(this.nula_Click);
            this.jedna.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jedna_KeyDown);
            // 
            // dva
            // 
            this.dva.Location = new System.Drawing.Point(60, 262);
            this.dva.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dva.Name = "dva";
            this.dva.Size = new System.Drawing.Size(40, 40);
            this.dva.TabIndex = 25;
            this.dva.Text = "2";
            this.dva.UseVisualStyleBackColor = true;
            this.dva.Click += new System.EventHandler(this.nula_Click);
            // 
            // tri
            // 
            this.tri.Location = new System.Drawing.Point(104, 262);
            this.tri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tri.Name = "tri";
            this.tri.Size = new System.Drawing.Size(40, 40);
            this.tri.TabIndex = 35;
            this.tri.Text = "3";
            this.tri.UseVisualStyleBackColor = true;
            this.tri.Click += new System.EventHandler(this.nula_Click);
            // 
            // ctyri
            // 
            this.ctyri.Location = new System.Drawing.Point(14, 217);
            this.ctyri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctyri.Name = "ctyri";
            this.ctyri.Size = new System.Drawing.Size(40, 40);
            this.ctyri.TabIndex = 14;
            this.ctyri.Text = "4";
            this.ctyri.UseVisualStyleBackColor = true;
            this.ctyri.Click += new System.EventHandler(this.nula_Click);
            // 
            // pet
            // 
            this.pet.Location = new System.Drawing.Point(58, 217);
            this.pet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pet.Name = "pet";
            this.pet.Size = new System.Drawing.Size(40, 40);
            this.pet.TabIndex = 24;
            this.pet.Text = "5";
            this.pet.UseVisualStyleBackColor = true;
            this.pet.Click += new System.EventHandler(this.nula_Click);
            // 
            // sest
            // 
            this.sest.Location = new System.Drawing.Point(103, 217);
            this.sest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sest.Name = "sest";
            this.sest.Size = new System.Drawing.Size(40, 40);
            this.sest.TabIndex = 34;
            this.sest.Text = "6";
            this.sest.UseVisualStyleBackColor = true;
            this.sest.Click += new System.EventHandler(this.nula_Click);
            // 
            // sedm
            // 
            this.sedm.Location = new System.Drawing.Point(15, 172);
            this.sedm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sedm.Name = "sedm";
            this.sedm.Size = new System.Drawing.Size(40, 40);
            this.sedm.TabIndex = 13;
            this.sedm.Text = "7";
            this.sedm.UseVisualStyleBackColor = true;
            this.sedm.Click += new System.EventHandler(this.nula_Click);
            // 
            // osm
            // 
            this.osm.Location = new System.Drawing.Point(60, 172);
            this.osm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.osm.Name = "osm";
            this.osm.Size = new System.Drawing.Size(40, 40);
            this.osm.TabIndex = 23;
            this.osm.Text = "8";
            this.osm.UseVisualStyleBackColor = true;
            this.osm.Click += new System.EventHandler(this.nula_Click);
            // 
            // devet
            // 
            this.devet.Location = new System.Drawing.Point(103, 172);
            this.devet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.devet.Name = "devet";
            this.devet.Size = new System.Drawing.Size(40, 40);
            this.devet.TabIndex = 33;
            this.devet.Text = "9";
            this.devet.UseVisualStyleBackColor = true;
            this.devet.Click += new System.EventHandler(this.nula_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(148, 262);
            this.plus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(40, 40);
            this.plus.TabIndex = 45;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(148, 217);
            this.minus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(40, 40);
            this.minus.TabIndex = 44;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.plus_Click);
            // 
            // krat
            // 
            this.krat.Location = new System.Drawing.Point(147, 172);
            this.krat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.krat.Name = "krat";
            this.krat.Size = new System.Drawing.Size(40, 40);
            this.krat.TabIndex = 43;
            this.krat.Text = "x";
            this.krat.UseVisualStyleBackColor = true;
            this.krat.Click += new System.EventHandler(this.plus_Click);
            // 
            // deleno
            // 
            this.deleno.Location = new System.Drawing.Point(148, 128);
            this.deleno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleno.Name = "deleno";
            this.deleno.Size = new System.Drawing.Size(40, 40);
            this.deleno.TabIndex = 42;
            this.deleno.Text = "/";
            this.deleno.UseVisualStyleBackColor = true;
            this.deleno.Click += new System.EventHandler(this.plus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 306);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 36;
            this.button1.Text = ",";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rovnase
            // 
            this.rovnase.Location = new System.Drawing.Point(148, 306);
            this.rovnase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rovnase.Name = "rovnase";
            this.rovnase.Size = new System.Drawing.Size(40, 40);
            this.rovnase.TabIndex = 46;
            this.rovnase.Text = "=";
            this.rovnase.UseVisualStyleBackColor = true;
            this.rovnase.Click += new System.EventHandler(this.rovnase_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 14);
            this.label1.TabIndex = 17;
            // 
            // bck
            // 
            this.bck.Location = new System.Drawing.Point(148, 83);
            this.bck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bck.Name = "bck";
            this.bck.Size = new System.Drawing.Size(40, 40);
            this.bck.TabIndex = 41;
            this.bck.Text = "<<";
            this.bck.UseVisualStyleBackColor = true;
            this.bck.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(104, 83);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 31;
            this.button6.Text = "C";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(60, 83);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 21;
            this.button7.Text = "CA";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(15, 306);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 40);
            this.button8.TabIndex = 16;
            this.button8.Text = "+/-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(60, 128);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 40);
            this.button9.TabIndex = 22;
            this.button9.Text = "x2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(104, 128);
            this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 40);
            this.button10.TabIndex = 32;
            this.button10.Text = "√";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(15, 128);
            this.button11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 40);
            this.button11.TabIndex = 12;
            this.button11.Text = "1/x";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(204, 9);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(104, 338);
            this.listBox1.TabIndex = 25;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 20);
            this.button2.TabIndex = 99;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.basicCalc);
            this.panel1.Location = new System.Drawing.Point(-4, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.MaximumSize = new System.Drawing.Size(338, 812);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 329);
            this.panel1.TabIndex = 100;
            this.panel1.Visible = false;
            // 
            // basicCalc
            // 
            this.basicCalc.Location = new System.Drawing.Point(11, 14);
            this.basicCalc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.basicCalc.Name = "basicCalc";
            this.basicCalc.Size = new System.Drawing.Size(124, 32);
            this.basicCalc.TabIndex = 0;
            this.basicCalc.Text = "Základní";
            this.basicCalc.UseVisualStyleBackColor = true;
            this.basicCalc.Click += new System.EventHandler(this.basicCalc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.bck);
            this.Controls.Add(this.rovnase);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleno);
            this.Controls.Add(this.krat);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.devet);
            this.Controls.Add(this.osm);
            this.Controls.Add(this.sedm);
            this.Controls.Add(this.sest);
            this.Controls.Add(this.pet);
            this.Controls.Add(this.ctyri);
            this.Controls.Add(this.tri);
            this.Controls.Add(this.dva);
            this.Controls.Add(this.jedna);
            this.Controls.Add(this.nula);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(229, 405);
            this.Name = "Form1";
            this.Text = "Kalkulačka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button nula;
        private System.Windows.Forms.Button jedna;
        private System.Windows.Forms.Button dva;
        private System.Windows.Forms.Button tri;
        private System.Windows.Forms.Button ctyri;
        private System.Windows.Forms.Button pet;
        private System.Windows.Forms.Button sest;
        private System.Windows.Forms.Button sedm;
        private System.Windows.Forms.Button osm;
        private System.Windows.Forms.Button devet;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button krat;
        private System.Windows.Forms.Button deleno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rovnase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bck;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button basicCalc;
    }
}

