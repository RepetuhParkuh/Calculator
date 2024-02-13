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
            this.nulaV = new System.Windows.Forms.Button();
            this.jednaV = new System.Windows.Forms.Button();
            this.dvaV = new System.Windows.Forms.Button();
            this.triV = new System.Windows.Forms.Button();
            this.ctyriV = new System.Windows.Forms.Button();
            this.petV = new System.Windows.Forms.Button();
            this.sestV = new System.Windows.Forms.Button();
            this.sedmV = new System.Windows.Forms.Button();
            this.osmV = new System.Windows.Forms.Button();
            this.devetV = new System.Windows.Forms.Button();
            this.plusV = new System.Windows.Forms.Button();
            this.minusV = new System.Windows.Forms.Button();
            this.kratV = new System.Windows.Forms.Button();
            this.delenoV = new System.Windows.Forms.Button();
            this.desCarkaV = new System.Windows.Forms.Button();
            this.rovnaseV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bckV = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.basicCalc = new System.Windows.Forms.Button();
            this.kalkVed = new System.Windows.Forms.Panel();
            this.button44 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.kalkZakl = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.nula = new System.Windows.Forms.Button();
            this.jedna = new System.Windows.Forms.Button();
            this.dva = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.tri = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.ctyri = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.pet = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.sest = new System.Windows.Forms.Button();
            this.sedm = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.osm = new System.Windows.Forms.Button();
            this.bck = new System.Windows.Forms.Button();
            this.devet = new System.Windows.Forms.Button();
            this.rovnase = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.desCarka = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.deleno = new System.Windows.Forms.Button();
            this.krat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.kalkVed.SuspendLayout();
            this.kalkZakl.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(24, 55);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 38);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nulaV
            // 
            this.nulaV.Location = new System.Drawing.Point(128, 217);
            this.nulaV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nulaV.Name = "nulaV";
            this.nulaV.Size = new System.Drawing.Size(53, 30);
            this.nulaV.TabIndex = 37;
            this.nulaV.Text = "0";
            this.nulaV.UseVisualStyleBackColor = true;
            this.nulaV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // jednaV
            // 
            this.jednaV.Location = new System.Drawing.Point(69, 183);
            this.jednaV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jednaV.Name = "jednaV";
            this.jednaV.Size = new System.Drawing.Size(53, 30);
            this.jednaV.TabIndex = 26;
            this.jednaV.Text = "1";
            this.jednaV.UseVisualStyleBackColor = true;
            this.jednaV.Click += new System.EventHandler(this.cisla_Click);
            this.jednaV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jedna_KeyDown);
            // 
            // dvaV
            // 
            this.dvaV.Location = new System.Drawing.Point(128, 183);
            this.dvaV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvaV.Name = "dvaV";
            this.dvaV.Size = new System.Drawing.Size(53, 30);
            this.dvaV.TabIndex = 36;
            this.dvaV.Text = "2";
            this.dvaV.UseVisualStyleBackColor = true;
            this.dvaV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // triV
            // 
            this.triV.Location = new System.Drawing.Point(187, 183);
            this.triV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.triV.Name = "triV";
            this.triV.Size = new System.Drawing.Size(53, 30);
            this.triV.TabIndex = 46;
            this.triV.Text = "3";
            this.triV.UseVisualStyleBackColor = true;
            this.triV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // ctyriV
            // 
            this.ctyriV.Location = new System.Drawing.Point(69, 149);
            this.ctyriV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctyriV.Name = "ctyriV";
            this.ctyriV.Size = new System.Drawing.Size(53, 30);
            this.ctyriV.TabIndex = 25;
            this.ctyriV.Text = "4";
            this.ctyriV.UseVisualStyleBackColor = true;
            this.ctyriV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // petV
            // 
            this.petV.Location = new System.Drawing.Point(128, 149);
            this.petV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.petV.Name = "petV";
            this.petV.Size = new System.Drawing.Size(53, 30);
            this.petV.TabIndex = 35;
            this.petV.Text = "5";
            this.petV.UseVisualStyleBackColor = true;
            this.petV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // sestV
            // 
            this.sestV.Location = new System.Drawing.Point(187, 149);
            this.sestV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sestV.Name = "sestV";
            this.sestV.Size = new System.Drawing.Size(53, 30);
            this.sestV.TabIndex = 45;
            this.sestV.Text = "6";
            this.sestV.UseVisualStyleBackColor = true;
            this.sestV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // sedmV
            // 
            this.sedmV.Location = new System.Drawing.Point(69, 114);
            this.sedmV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sedmV.Name = "sedmV";
            this.sedmV.Size = new System.Drawing.Size(53, 30);
            this.sedmV.TabIndex = 24;
            this.sedmV.Text = "7";
            this.sedmV.UseVisualStyleBackColor = true;
            this.sedmV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // osmV
            // 
            this.osmV.Location = new System.Drawing.Point(128, 114);
            this.osmV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.osmV.Name = "osmV";
            this.osmV.Size = new System.Drawing.Size(53, 30);
            this.osmV.TabIndex = 34;
            this.osmV.Text = "8";
            this.osmV.UseVisualStyleBackColor = true;
            this.osmV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // devetV
            // 
            this.devetV.Location = new System.Drawing.Point(187, 114);
            this.devetV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.devetV.Name = "devetV";
            this.devetV.Size = new System.Drawing.Size(53, 30);
            this.devetV.TabIndex = 44;
            this.devetV.Text = "9";
            this.devetV.UseVisualStyleBackColor = true;
            this.devetV.Click += new System.EventHandler(this.cisla_Click);
            // 
            // plusV
            // 
            this.plusV.Location = new System.Drawing.Point(245, 183);
            this.plusV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plusV.Name = "plusV";
            this.plusV.Size = new System.Drawing.Size(53, 30);
            this.plusV.TabIndex = 56;
            this.plusV.Text = "+";
            this.plusV.UseVisualStyleBackColor = true;
            this.plusV.Click += new System.EventHandler(this.vedOper_Click);
            // 
            // minusV
            // 
            this.minusV.Location = new System.Drawing.Point(245, 149);
            this.minusV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minusV.Name = "minusV";
            this.minusV.Size = new System.Drawing.Size(53, 30);
            this.minusV.TabIndex = 55;
            this.minusV.Text = "-";
            this.minusV.UseVisualStyleBackColor = true;
            this.minusV.Click += new System.EventHandler(this.vedOper_Click);
            // 
            // kratV
            // 
            this.kratV.Location = new System.Drawing.Point(245, 114);
            this.kratV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kratV.Name = "kratV";
            this.kratV.Size = new System.Drawing.Size(53, 30);
            this.kratV.TabIndex = 54;
            this.kratV.Text = "x";
            this.kratV.UseVisualStyleBackColor = true;
            this.kratV.Click += new System.EventHandler(this.vedOper_Click);
            // 
            // delenoV
            // 
            this.delenoV.Location = new System.Drawing.Point(245, 81);
            this.delenoV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delenoV.Name = "delenoV";
            this.delenoV.Size = new System.Drawing.Size(53, 30);
            this.delenoV.TabIndex = 53;
            this.delenoV.Text = "/";
            this.delenoV.UseVisualStyleBackColor = true;
            this.delenoV.Click += new System.EventHandler(this.vedOper_Click);
            // 
            // desCarkaV
            // 
            this.desCarkaV.Location = new System.Drawing.Point(187, 217);
            this.desCarkaV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.desCarkaV.Name = "desCarkaV";
            this.desCarkaV.Size = new System.Drawing.Size(53, 30);
            this.desCarkaV.TabIndex = 47;
            this.desCarkaV.Text = ",";
            this.desCarkaV.UseVisualStyleBackColor = true;
            this.desCarkaV.Click += new System.EventHandler(this.desCarka_Click);
            // 
            // rovnaseV
            // 
            this.rovnaseV.Location = new System.Drawing.Point(245, 217);
            this.rovnaseV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rovnaseV.Name = "rovnaseV";
            this.rovnaseV.Size = new System.Drawing.Size(53, 30);
            this.rovnaseV.TabIndex = 57;
            this.rovnaseV.Text = "=";
            this.rovnaseV.UseVisualStyleBackColor = true;
            this.rovnaseV.Click += new System.EventHandler(this.rovnaseV_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 17);
            this.label1.TabIndex = 17;
            // 
            // bckV
            // 
            this.bckV.Location = new System.Drawing.Point(245, 11);
            this.bckV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bckV.Name = "bckV";
            this.bckV.Size = new System.Drawing.Size(53, 30);
            this.bckV.TabIndex = 51;
            this.bckV.Text = "<<";
            this.bckV.UseVisualStyleBackColor = true;
            this.bckV.Click += new System.EventHandler(this.backspace_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(187, 11);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 30);
            this.button6.TabIndex = 41;
            this.button6.Text = "C";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(69, 217);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 30);
            this.button8.TabIndex = 27;
            this.button8.Text = "+/-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnPlusMinus_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(11, 47);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 30);
            this.button9.TabIndex = 12;
            this.button9.Text = "x2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.druhaMocnina_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(11, 81);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 30);
            this.button10.TabIndex = 13;
            this.button10.Text = "√";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.druhaOdmocnina_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(69, 47);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 30);
            this.button11.TabIndex = 22;
            this.button11.Text = "1/x";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.obracenaHodnota_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(285, 11);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(125, 416);
            this.listBox1.TabIndex = 25;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 25);
            this.button2.TabIndex = 99;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.menu_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.basicCalc);
            this.panel1.Location = new System.Drawing.Point(-3, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.MaximumSize = new System.Drawing.Size(451, 999);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 455);
            this.panel1.TabIndex = 100;
            this.panel1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 60);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 39);
            this.button3.TabIndex = 1;
            this.button3.Text = "Vědecká";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.sciCalc_Click);
            // 
            // basicCalc
            // 
            this.basicCalc.Location = new System.Drawing.Point(15, 17);
            this.basicCalc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.basicCalc.Name = "basicCalc";
            this.basicCalc.Size = new System.Drawing.Size(165, 39);
            this.basicCalc.TabIndex = 0;
            this.basicCalc.Text = "Základní";
            this.basicCalc.UseVisualStyleBackColor = true;
            this.basicCalc.Click += new System.EventHandler(this.basicCalc_Click);
            // 
            // kalkVed
            // 
            this.kalkVed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kalkVed.BackColor = System.Drawing.Color.Transparent;
            this.kalkVed.Controls.Add(this.button44);
            this.kalkVed.Controls.Add(this.button43);
            this.kalkVed.Controls.Add(this.button42);
            this.kalkVed.Controls.Add(this.button41);
            this.kalkVed.Controls.Add(this.button40);
            this.kalkVed.Controls.Add(this.button39);
            this.kalkVed.Controls.Add(this.button38);
            this.kalkVed.Controls.Add(this.button37);
            this.kalkVed.Controls.Add(this.button36);
            this.kalkVed.Controls.Add(this.button35);
            this.kalkVed.Controls.Add(this.btnMod);
            this.kalkVed.Controls.Add(this.button33);
            this.kalkVed.Controls.Add(this.button7);
            this.kalkVed.Controls.Add(this.nulaV);
            this.kalkVed.Controls.Add(this.jednaV);
            this.kalkVed.Controls.Add(this.dvaV);
            this.kalkVed.Controls.Add(this.button11);
            this.kalkVed.Controls.Add(this.triV);
            this.kalkVed.Controls.Add(this.button10);
            this.kalkVed.Controls.Add(this.ctyriV);
            this.kalkVed.Controls.Add(this.button9);
            this.kalkVed.Controls.Add(this.petV);
            this.kalkVed.Controls.Add(this.button8);
            this.kalkVed.Controls.Add(this.sestV);
            this.kalkVed.Controls.Add(this.sedmV);
            this.kalkVed.Controls.Add(this.button6);
            this.kalkVed.Controls.Add(this.osmV);
            this.kalkVed.Controls.Add(this.bckV);
            this.kalkVed.Controls.Add(this.devetV);
            this.kalkVed.Controls.Add(this.rovnaseV);
            this.kalkVed.Controls.Add(this.plusV);
            this.kalkVed.Controls.Add(this.desCarkaV);
            this.kalkVed.Controls.Add(this.minusV);
            this.kalkVed.Controls.Add(this.delenoV);
            this.kalkVed.Controls.Add(this.kratV);
            this.kalkVed.Location = new System.Drawing.Point(267, 106);
            this.kalkVed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kalkVed.Name = "kalkVed";
            this.kalkVed.Size = new System.Drawing.Size(359, 373);
            this.kalkVed.TabIndex = 101;
            this.kalkVed.Visible = false;
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(11, 217);
            this.button44.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(53, 30);
            this.button44.TabIndex = 17;
            this.button44.Text = "ln";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Visible = false;
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(11, 183);
            this.button43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(53, 30);
            this.button43.TabIndex = 16;
            this.button43.Text = "log";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.log_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(11, 149);
            this.button42.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(53, 30);
            this.button42.TabIndex = 15;
            this.button42.Text = "10X";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Visible = false;
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(11, 114);
            this.button41.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(53, 30);
            this.button41.TabIndex = 14;
            this.button41.Text = "xY";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.libovolnaMocnina_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(11, 11);
            this.button40.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(53, 30);
            this.button40.TabIndex = 11;
            this.button40.Text = "2nd";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Visible = false;
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(69, 81);
            this.button39.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(53, 30);
            this.button39.TabIndex = 23;
            this.button39.Text = "(";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(69, 11);
            this.button38.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(53, 30);
            this.button38.TabIndex = 21;
            this.button38.Text = "Pi";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.Pi_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(128, 11);
            this.button37.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(53, 30);
            this.button37.TabIndex = 31;
            this.button37.Text = "e";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Visible = false;
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(128, 47);
            this.button36.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(53, 30);
            this.button36.TabIndex = 32;
            this.button36.Text = "|x|";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Visible = false;
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(128, 81);
            this.button35.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(53, 30);
            this.button35.TabIndex = 33;
            this.button35.Text = ")";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.cisla_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(245, 47);
            this.btnMod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(53, 30);
            this.btnMod.TabIndex = 52;
            this.btnMod.Text = "mod";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.vedOper_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(187, 47);
            this.button33.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(53, 30);
            this.button33.TabIndex = 42;
            this.button33.Text = "exp";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(187, 81);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 30);
            this.button7.TabIndex = 43;
            this.button7.Text = "n!";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnFakt);
            // 
            // kalkZakl
            // 
            this.kalkZakl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kalkZakl.BackColor = System.Drawing.Color.Transparent;
            this.kalkZakl.Controls.Add(this.button4);
            this.kalkZakl.Controls.Add(this.nula);
            this.kalkZakl.Controls.Add(this.jedna);
            this.kalkZakl.Controls.Add(this.dva);
            this.kalkZakl.Controls.Add(this.button14);
            this.kalkZakl.Controls.Add(this.tri);
            this.kalkZakl.Controls.Add(this.button16);
            this.kalkZakl.Controls.Add(this.ctyri);
            this.kalkZakl.Controls.Add(this.button18);
            this.kalkZakl.Controls.Add(this.pet);
            this.kalkZakl.Controls.Add(this.button20);
            this.kalkZakl.Controls.Add(this.sest);
            this.kalkZakl.Controls.Add(this.sedm);
            this.kalkZakl.Controls.Add(this.button23);
            this.kalkZakl.Controls.Add(this.osm);
            this.kalkZakl.Controls.Add(this.bck);
            this.kalkZakl.Controls.Add(this.devet);
            this.kalkZakl.Controls.Add(this.rovnase);
            this.kalkZakl.Controls.Add(this.plus);
            this.kalkZakl.Controls.Add(this.desCarka);
            this.kalkZakl.Controls.Add(this.minus);
            this.kalkZakl.Controls.Add(this.deleno);
            this.kalkZakl.Controls.Add(this.krat);
            this.kalkZakl.Location = new System.Drawing.Point(19, 106);
            this.kalkZakl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kalkZakl.Name = "kalkZakl";
            this.kalkZakl.Size = new System.Drawing.Size(359, 373);
            this.kalkZakl.TabIndex = 102;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(67, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 49);
            this.button4.TabIndex = 21;
            this.button4.Text = "CA";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.CE_Click);
            // 
            // nula
            // 
            this.nula.Location = new System.Drawing.Point(67, 277);
            this.nula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nula.Name = "nula";
            this.nula.Size = new System.Drawing.Size(53, 49);
            this.nula.TabIndex = 26;
            this.nula.Text = "0";
            this.nula.UseVisualStyleBackColor = true;
            this.nula.Click += new System.EventHandler(this.cisla_Click);
            // 
            // jedna
            // 
            this.jedna.Location = new System.Drawing.Point(5, 222);
            this.jedna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jedna.Name = "jedna";
            this.jedna.Size = new System.Drawing.Size(53, 49);
            this.jedna.TabIndex = 15;
            this.jedna.Text = "1";
            this.jedna.UseVisualStyleBackColor = true;
            this.jedna.Click += new System.EventHandler(this.cisla_Click);
            // 
            // dva
            // 
            this.dva.Location = new System.Drawing.Point(67, 222);
            this.dva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dva.Name = "dva";
            this.dva.Size = new System.Drawing.Size(53, 49);
            this.dva.TabIndex = 25;
            this.dva.Text = "2";
            this.dva.UseVisualStyleBackColor = true;
            this.dva.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(5, 58);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(53, 49);
            this.button14.TabIndex = 12;
            this.button14.Text = "1/x";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.obracenaHodnota_Click);
            // 
            // tri
            // 
            this.tri.Location = new System.Drawing.Point(125, 222);
            this.tri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tri.Name = "tri";
            this.tri.Size = new System.Drawing.Size(53, 49);
            this.tri.TabIndex = 35;
            this.tri.Text = "3";
            this.tri.UseVisualStyleBackColor = true;
            this.tri.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(125, 58);
            this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(53, 49);
            this.button16.TabIndex = 32;
            this.button16.Text = "√";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.druhaOdmocnina_Click);
            // 
            // ctyri
            // 
            this.ctyri.Location = new System.Drawing.Point(5, 167);
            this.ctyri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctyri.Name = "ctyri";
            this.ctyri.Size = new System.Drawing.Size(53, 49);
            this.ctyri.TabIndex = 14;
            this.ctyri.Text = "4";
            this.ctyri.UseVisualStyleBackColor = true;
            this.ctyri.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(67, 58);
            this.button18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(53, 49);
            this.button18.TabIndex = 22;
            this.button18.Text = "x2";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.druhaMocnina_Click);
            // 
            // pet
            // 
            this.pet.Location = new System.Drawing.Point(63, 167);
            this.pet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pet.Name = "pet";
            this.pet.Size = new System.Drawing.Size(53, 49);
            this.pet.TabIndex = 24;
            this.pet.Text = "5";
            this.pet.UseVisualStyleBackColor = true;
            this.pet.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(5, 277);
            this.button20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(53, 49);
            this.button20.TabIndex = 16;
            this.button20.Text = "+/-";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.btnPlusMinus_Click);
            // 
            // sest
            // 
            this.sest.Location = new System.Drawing.Point(123, 167);
            this.sest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sest.Name = "sest";
            this.sest.Size = new System.Drawing.Size(53, 49);
            this.sest.TabIndex = 34;
            this.sest.Text = "6";
            this.sest.UseVisualStyleBackColor = true;
            this.sest.Click += new System.EventHandler(this.cisla_Click);
            // 
            // sedm
            // 
            this.sedm.Location = new System.Drawing.Point(5, 112);
            this.sedm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sedm.Name = "sedm";
            this.sedm.Size = new System.Drawing.Size(53, 49);
            this.sedm.TabIndex = 13;
            this.sedm.Text = "7";
            this.sedm.UseVisualStyleBackColor = true;
            this.sedm.Click += new System.EventHandler(this.cisla_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(125, 2);
            this.button23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(53, 49);
            this.button23.TabIndex = 31;
            this.button23.Text = "C";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.Clear_Click);
            // 
            // osm
            // 
            this.osm.Location = new System.Drawing.Point(67, 112);
            this.osm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.osm.Name = "osm";
            this.osm.Size = new System.Drawing.Size(53, 49);
            this.osm.TabIndex = 23;
            this.osm.Text = "8";
            this.osm.UseVisualStyleBackColor = true;
            this.osm.Click += new System.EventHandler(this.cisla_Click);
            // 
            // bck
            // 
            this.bck.Location = new System.Drawing.Point(183, 2);
            this.bck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bck.Name = "bck";
            this.bck.Size = new System.Drawing.Size(53, 49);
            this.bck.TabIndex = 41;
            this.bck.Text = "<<";
            this.bck.UseVisualStyleBackColor = true;
            this.bck.Click += new System.EventHandler(this.backspace_Click);
            // 
            // devet
            // 
            this.devet.Location = new System.Drawing.Point(123, 112);
            this.devet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.devet.Name = "devet";
            this.devet.Size = new System.Drawing.Size(53, 49);
            this.devet.TabIndex = 33;
            this.devet.Text = "9";
            this.devet.UseVisualStyleBackColor = true;
            this.devet.Click += new System.EventHandler(this.cisla_Click);
            // 
            // rovnase
            // 
            this.rovnase.Location = new System.Drawing.Point(183, 277);
            this.rovnase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rovnase.Name = "rovnase";
            this.rovnase.Size = new System.Drawing.Size(53, 49);
            this.rovnase.TabIndex = 46;
            this.rovnase.Text = "=";
            this.rovnase.UseVisualStyleBackColor = true;
            this.rovnase.Click += new System.EventHandler(this.zaklRovnase_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(183, 222);
            this.plus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(53, 49);
            this.plus.TabIndex = 45;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.zaklOper_Click);
            // 
            // desCarka
            // 
            this.desCarka.Location = new System.Drawing.Point(123, 277);
            this.desCarka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.desCarka.Name = "desCarka";
            this.desCarka.Size = new System.Drawing.Size(53, 49);
            this.desCarka.TabIndex = 36;
            this.desCarka.Text = ",";
            this.desCarka.UseVisualStyleBackColor = true;
            this.desCarka.Click += new System.EventHandler(this.desCarka_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(183, 167);
            this.minus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(53, 49);
            this.minus.TabIndex = 44;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.zaklOper_Click);
            // 
            // deleno
            // 
            this.deleno.Location = new System.Drawing.Point(183, 58);
            this.deleno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleno.Name = "deleno";
            this.deleno.Size = new System.Drawing.Size(53, 49);
            this.deleno.TabIndex = 42;
            this.deleno.Text = "/";
            this.deleno.UseVisualStyleBackColor = true;
            this.deleno.Click += new System.EventHandler(this.zaklOper_Click);
            // 
            // krat
            // 
            this.krat.Location = new System.Drawing.Point(181, 114);
            this.krat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.krat.Name = "krat";
            this.krat.Size = new System.Drawing.Size(53, 49);
            this.krat.TabIndex = 43;
            this.krat.Text = "x";
            this.krat.UseVisualStyleBackColor = true;
            this.krat.Click += new System.EventHandler(this.zaklOper_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kalkVed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.kalkZakl);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(298, 484);
            this.Name = "Form1";
            this.Text = "Kalkulačka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.kalkVed.ResumeLayout(false);
            this.kalkZakl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button nulaV;
        private System.Windows.Forms.Button jednaV;
        private System.Windows.Forms.Button dvaV;
        private System.Windows.Forms.Button triV;
        private System.Windows.Forms.Button ctyriV;
        private System.Windows.Forms.Button petV;
        private System.Windows.Forms.Button sestV;
        private System.Windows.Forms.Button sedmV;
        private System.Windows.Forms.Button osmV;
        private System.Windows.Forms.Button devetV;
        private System.Windows.Forms.Button plusV;
        private System.Windows.Forms.Button minusV;
        private System.Windows.Forms.Button kratV;
        private System.Windows.Forms.Button delenoV;
        private System.Windows.Forms.Button desCarkaV;
        private System.Windows.Forms.Button rovnaseV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bckV;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button basicCalc;
        private System.Windows.Forms.Panel kalkVed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel kalkZakl;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button nula;
        private System.Windows.Forms.Button jedna;
        private System.Windows.Forms.Button dva;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button tri;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button ctyri;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button pet;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button sest;
        private System.Windows.Forms.Button sedm;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button osm;
        private System.Windows.Forms.Button bck;
        private System.Windows.Forms.Button devet;
        private System.Windows.Forms.Button rovnase;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button desCarka;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button deleno;
        private System.Windows.Forms.Button krat;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button36;
    }
}

