namespace Kalkulačka_v3
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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(10, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nula
            // 
            this.nula.Location = new System.Drawing.Point(66, 350);
            this.nula.Name = "nula";
            this.nula.Size = new System.Drawing.Size(53, 49);
            this.nula.TabIndex = 17;
            this.nula.Text = "0";
            this.nula.UseVisualStyleBackColor = true;
            this.nula.Click += new System.EventHandler(this.nula_Click);
            // 
            // jedna
            // 
            this.jedna.Location = new System.Drawing.Point(7, 295);
            this.jedna.Name = "jedna";
            this.jedna.Size = new System.Drawing.Size(53, 49);
            this.jedna.TabIndex = 2;
            this.jedna.Text = "1";
            this.jedna.UseVisualStyleBackColor = true;
            this.jedna.Click += new System.EventHandler(this.nula_Click);
            this.jedna.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jedna_KeyDown);
            // 
            // dva
            // 
            this.dva.Location = new System.Drawing.Point(66, 295);
            this.dva.Name = "dva";
            this.dva.Size = new System.Drawing.Size(53, 49);
            this.dva.TabIndex = 3;
            this.dva.Text = "2";
            this.dva.UseVisualStyleBackColor = true;
            this.dva.Click += new System.EventHandler(this.nula_Click);
            // 
            // tri
            // 
            this.tri.Location = new System.Drawing.Point(125, 295);
            this.tri.Name = "tri";
            this.tri.Size = new System.Drawing.Size(53, 49);
            this.tri.TabIndex = 4;
            this.tri.Text = "3";
            this.tri.UseVisualStyleBackColor = true;
            this.tri.Click += new System.EventHandler(this.nula_Click);
            // 
            // ctyri
            // 
            this.ctyri.Location = new System.Drawing.Point(6, 240);
            this.ctyri.Name = "ctyri";
            this.ctyri.Size = new System.Drawing.Size(53, 49);
            this.ctyri.TabIndex = 5;
            this.ctyri.Text = "4";
            this.ctyri.UseVisualStyleBackColor = true;
            this.ctyri.Click += new System.EventHandler(this.nula_Click);
            // 
            // pet
            // 
            this.pet.Location = new System.Drawing.Point(65, 240);
            this.pet.Name = "pet";
            this.pet.Size = new System.Drawing.Size(53, 49);
            this.pet.TabIndex = 6;
            this.pet.Text = "5";
            this.pet.UseVisualStyleBackColor = true;
            this.pet.Click += new System.EventHandler(this.nula_Click);
            // 
            // sest
            // 
            this.sest.Location = new System.Drawing.Point(124, 240);
            this.sest.Name = "sest";
            this.sest.Size = new System.Drawing.Size(53, 49);
            this.sest.TabIndex = 7;
            this.sest.Text = "6";
            this.sest.UseVisualStyleBackColor = true;
            this.sest.Click += new System.EventHandler(this.nula_Click);
            // 
            // sedm
            // 
            this.sedm.Location = new System.Drawing.Point(7, 185);
            this.sedm.Name = "sedm";
            this.sedm.Size = new System.Drawing.Size(53, 49);
            this.sedm.TabIndex = 8;
            this.sedm.Text = "7";
            this.sedm.UseVisualStyleBackColor = true;
            this.sedm.Click += new System.EventHandler(this.nula_Click);
            // 
            // osm
            // 
            this.osm.Location = new System.Drawing.Point(66, 185);
            this.osm.Name = "osm";
            this.osm.Size = new System.Drawing.Size(53, 49);
            this.osm.TabIndex = 9;
            this.osm.Text = "8";
            this.osm.UseVisualStyleBackColor = true;
            this.osm.Click += new System.EventHandler(this.nula_Click);
            // 
            // devet
            // 
            this.devet.Location = new System.Drawing.Point(124, 185);
            this.devet.Name = "devet";
            this.devet.Size = new System.Drawing.Size(53, 49);
            this.devet.TabIndex = 10;
            this.devet.Text = "9";
            this.devet.UseVisualStyleBackColor = true;
            this.devet.Click += new System.EventHandler(this.nula_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(184, 295);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(53, 49);
            this.plus.TabIndex = 11;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(184, 240);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(53, 49);
            this.minus.TabIndex = 12;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.plus_Click);
            // 
            // krat
            // 
            this.krat.Location = new System.Drawing.Point(183, 185);
            this.krat.Name = "krat";
            this.krat.Size = new System.Drawing.Size(53, 49);
            this.krat.TabIndex = 13;
            this.krat.Text = "x";
            this.krat.UseVisualStyleBackColor = true;
            this.krat.Click += new System.EventHandler(this.plus_Click);
            // 
            // deleno
            // 
            this.deleno.Location = new System.Drawing.Point(184, 130);
            this.deleno.Name = "deleno";
            this.deleno.Size = new System.Drawing.Size(53, 49);
            this.deleno.TabIndex = 14;
            this.deleno.Text = "/";
            this.deleno.UseVisualStyleBackColor = true;
            this.deleno.Click += new System.EventHandler(this.plus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 49);
            this.button1.TabIndex = 15;
            this.button1.Text = ",";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rovnase
            // 
            this.rovnase.Location = new System.Drawing.Point(184, 350);
            this.rovnase.Name = "rovnase";
            this.rovnase.Size = new System.Drawing.Size(53, 49);
            this.rovnase.TabIndex = 1;
            this.rovnase.Text = "=";
            this.rovnase.UseVisualStyleBackColor = true;
            this.rovnase.Click += new System.EventHandler(this.rovnase_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 16);
            this.label1.TabIndex = 17;
            // 
            // bck
            // 
            this.bck.Location = new System.Drawing.Point(184, 75);
            this.bck.Name = "bck";
            this.bck.Size = new System.Drawing.Size(53, 49);
            this.bck.TabIndex = 18;
            this.bck.Text = "<<";
            this.bck.UseVisualStyleBackColor = true;
            this.bck.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(125, 75);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 49);
            this.button6.TabIndex = 19;
            this.button6.Text = "C";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(66, 75);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 49);
            this.button7.TabIndex = 20;
            this.button7.Text = "CA";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 350);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 49);
            this.button8.TabIndex = 21;
            this.button8.Text = "+/-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(66, 130);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 49);
            this.button9.TabIndex = 22;
            this.button9.Text = "x2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(125, 130);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 49);
            this.button10.TabIndex = 23;
            this.button10.Text = "√";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(7, 130);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 49);
            this.button11.TabIndex = 24;
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
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(272, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 352);
            this.listBox1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 404);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.bck);
            this.Controls.Add(this.label1);
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
            this.Name = "Form1";
            this.Text = "Kalkulačka";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
    }
}

