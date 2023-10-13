using System;
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

        /* Globální proměnné */

        char operace;
        double cislo,cislo2;
        bool pruchod = false;

        
        private void nula_Click(object sender, EventArgs e)
        {
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
                }
                else
                {
                    switch (operace)
                    {
                        case '+':
                            cislo += cislo2;
                            break;
                        case '-':
                            if (cislo2 < 0) cislo += (cislo2 * (-1));
                            else cislo -= cislo2;
                            break;
                        case 'x':
                            cislo *= cislo2;
                            break;
                        case '/':
                            cislo /= cislo2;
                            break;
                    }
                }
            label1.Text = "";
            textBox1.Text = cislo.ToString();
            listBox1.Items.Add(cislo);
            pruchod = false;
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

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "3,14159265359";
            rovnase.Focus();
        }

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

        private void jedna_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
