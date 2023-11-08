﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulačka_v3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        //responsivita

        void autores()
        {
            Control sloup1 = this.button11;
            Control radek1 = this.button7;
            int locX = 0;
            int locY = 0;
            int sirkaForm = this.Width;
            int vyskaForm=this.Height;

            if (sirkaForm < 350)
            {
                listBox1.Visible = false;
            }

            else
            {
                listBox1.Visible = true;
                listBox1.Location = new Point(textBox1.Location.X + textBox1.Width + 25, textBox1.Location.Y);
            }


            if (!listBox1.Visible)
            {
                textBox1.Width = sirkaForm - 50;
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        c.Width = (sirkaForm - 20) / 4 - 10;
                        c.Height = (vyskaForm - textBox1.Height) / 6 - 20;
                        int sloupec = c.TabIndex / 10;
                        int radek = c.TabIndex % 10;

                        if (sloupec > 1)
                        {
                            switch (sloupec)
                            {
                                case 2:
                                    locX = sloup1.Location.X + c.Width + 10;
                                    break;
                                case 3:
                                    locX = sloup1.Location.X + 2 * c.Width + 20;
                                    break;
                                case 4:
                                    locX = sloup1.Location.X + 3 * c.Width + 30;
                                    break;
                            }                           

                            c.Location = new Point(locX, c.Location.Y);
                        }

                        if(radek > 1)
                        {
                            switch (radek)
                            {
                                case 2:
                                    locY = radek1.Location.Y + c.Height + 10;
                                    break;
                                case 3:
                                    locY = radek1.Location.Y + 2 * c.Height + 20;
                                    break;
                                case 4:
                                    locY = radek1.Location.Y + 3 * c.Height + 30;
                                    break;
                                case 5:
                                    locY = radek1.Location.Y + 4 * c.Height + 40;
                                    break;
                                case 6:
                                    locY = radek1.Location.Y + 5 * c.Height + 50;
                                    break;
                            }
                            c.Location = new Point(c.Location.X,locY);
                        }
                    }
                }
            }

            else
            {
                textBox1.Width = sirkaForm - listBox1.Width - 50;

                foreach (Control c in this.Controls)
                {

                    if (c is Button)
                    {
                        c.Width = (sirkaForm - 50) / 4 - 10 - (listBox1.Width / 4);
                        c.Height = (vyskaForm - textBox1.Height) / 6 - 20;
                        int sloupec = c.TabIndex / 10;
                        int radek = c.TabIndex % 10;
                        if (sloupec > 1)
                        {
                            switch (sloupec)
                            {
                                case 2:
                                    locX = sloup1.Location.X + c.Width + 10;
                                    break;
                                case 3:
                                    locX = sloup1.Location.X + 2 * c.Width + 20;
                                    break;
                                case 4:
                                    locX = sloup1.Location.X + 3 * c.Width + 30;
                                    break;
                            }

                            c.Location = new Point(locX, c.Location.Y);
                        }

                        if (radek > 1)
                        {
                            switch (radek)
                            {
                                case 2:
                                    locY = radek1.Location.Y + c.Height + 5;
                                    break;
                                case 3:
                                    locY = radek1.Location.Y + 2 * c.Height + 10;
                                    break;
                                case 4:
                                    locY = radek1.Location.Y + 3 * c.Height + 15;
                                    break;
                                case 5:
                                    locY = radek1.Location.Y + 4 * c.Height + 20;
                                    break;
                                case 6:
                                    locY = radek1.Location.Y + 5 * c.Height + 25;
                                    break;
                            }
                            c.Location = new Point(c.Location.X, locY);
                        }
                    }
                }
            }

        }

        /* Globální proměnné */

        char operace;
        double cislo,cislo2;
        bool pruchod = false;
        bool vysledek = false;

        
        private void nula_Click(object sender, EventArgs e)
        {
            if (vysledek)                   //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
            {
                textBox1.Text = "";
                vysledek = false;
            }
            if(textBox1.Text!="0") textBox1.Text+=(sender as Button).Text;      //Ošetření aby nebylo víc než jedna 0
            else textBox1.Text = (sender as Button).Text;               //Braní textu tlačítek jako zadávání
            rovnase.Focus();
        }

        private void rovnase_Click(object sender, EventArgs e)
        {
            
           if (textBox1.Text.Length>0)
           {

                if (pruchod == true)
                {
                    cislo2 = Convert.ToDouble(textBox1.Text);
                }
                    switch (operace)
                    {
                        case '+':
                            cislo += cislo2;
                            break;
                        case '-':
                            if (cislo2 < 0)
                                cislo += (cislo2 * -1);
                            else cislo -= cislo2;
                            break;
                        case 'x':
                            cislo *= cislo2;
                            break;
                        case '/':
                            cislo /= cislo2;
                            break;
                    }
                
            label1.Text = "";
            textBox1.Text = cislo.ToString();
            listBox1.Items.Add(cislo);
            pruchod = false;
                vysledek = true;        //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                if(label1.Text.Length>0)
                {
                    textBox1.Text=label1.Text.Substring(0,label1.Text.Length-1);
                }
                else textBox1.Text = "0";
            }
            if (pruchod == true) 
            {
                cislo2 = Convert.ToDouble(textBox1.Text);
                switch (operace)
                {
                    case '+':
                        cislo += cislo2;
                        break;
                    case '-':
                        if (cislo2 < 0)                   
                            cislo += (cislo2*-1);                                               
                        else cislo -= cislo2;
                        break;
                    case 'x':
                        cislo *= cislo2;
                        break;
                    case '/':
                        cislo /= cislo2;
                        break;
                }
                listBox1.Items.Add(cislo);
                label1.Text = textBox1.Text;
                textBox1.Text = cislo.ToString();
            }
            cislo = Convert.ToDouble(textBox1.Text);
            textBox1.Text += (sender as Button).Text;
            operace=Convert.ToChar((sender as Button).Text);
            label1.Text = textBox1.Text;            
            textBox1.Clear();
            pruchod = true;
            rovnase.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            rovnase.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0) textBox1.Text=textBox1.Text.Substring(0,textBox1.Text.Length-1);
            if (textBox1.Text.Length == 0) textBox1.Text = "0";
            rovnase.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            cislo = 0;
            listBox1.Items.Clear();
            textBox1.Text = "0";
            rovnase.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = (Convert.ToDouble(textBox1.Text) * (-1)).ToString();                
            }
            rovnase.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                double pom = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                textBox1.Text = (pom *= pom).ToString();
            }
            rovnase.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) textBox1.Text = "0";
            double pom1=Convert.ToDouble(textBox1.Text);
            int pom = Convert.ToInt32(pom1);
            if (pom == pom1) textBox1.Text += (sender as Button).Text;
            rovnase.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if(Convert.ToDouble(textBox1.Text)>=0)
                {
                     double pom = Convert.ToDouble(textBox1.Text);
                    pom = Math.Sqrt(pom);
                    textBox1.Text=pom.ToString();
                }
            }
            rovnase.Focus();
        }

        /* Pí */

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = (1 / Convert.ToDouble(textBox1.Text)).ToString();
            rovnase.Focus();
        }

        // Zadávání pomocí klávesnice

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    nula.PerformClick();
                    break;
                case Keys.NumPad1:
                    jedna.PerformClick();
                    break;

                case Keys.NumPad2:
                    dva.PerformClick();
                    break;
                case Keys.NumPad3:
                    tri.PerformClick();
                    break;
                case Keys.NumPad4:
                    ctyri.PerformClick();
                    break;
                case Keys.NumPad5:
                    pet.PerformClick();
                    break;
                case Keys.NumPad6:
                    sest.PerformClick();
                    break;
                case Keys.NumPad7:
                    sedm.PerformClick();
                    break;
                case Keys.NumPad8:
                    osm.PerformClick();
                    break;
                case Keys.NumPad9:
                    devet.PerformClick();
                    break;
                case Keys.Add:
                    plus.PerformClick();
                    break;
                case Keys.Subtract:
                    minus.PerformClick();
                    break;
                case Keys.Multiply:
                    krat.PerformClick();
                    break;
                case Keys.Divide:
                    deleno.PerformClick();
                    break;
                case Keys.Back:
                    bck.PerformClick();
                    break;
                case Keys.Enter:
                    rovnase.PerformClick();
                        break;
                case Keys.Decimal:
                    if(!textBox1.Text.Contains(","))
                        button1.PerformClick();
                    break;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autores();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            autores();
        }

        private void jedna_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
