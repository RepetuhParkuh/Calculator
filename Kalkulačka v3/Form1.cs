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


        //Základní kalkulačka
        char operace;
        double cislo,cislo2;
        bool pruchod = false;
        bool vysledek = false;

        //Vědecká kalkulačka
        string priklad="";
   

        //responsivita

        void autores(int pocSloup, int pocRad, Panel kalk)
        {
            Control radek1 = this.button11;
            Control sloup1 = this.button7;            
            if(kalk.Name == kalkZakl.Name)
            {
                kalkZakl.Location = new Point(kalkVed.Location.X, kalkVed.Location.Y);
                sloup1 = this.button40;
                radek1 = this.button40;
            }
            int locX = 0;
            int locY = 0;
            int sirkaForm = this.Width;
            int vyskaForm = this.Height;
            int lbSirka = 0;
            
            
            //panel1.Height = vyskaForm / 5 * 4;
            if (sirkaForm < 350)
            {
                listBox1.Visible = false;
                panel1.Width = sirkaForm / 3*2;
                lbSirka = 0;
            }

            else
            {
                listBox1.Visible = true;
                listBox1.Location = new Point(textBox1.Location.X + textBox1.Width + 25, textBox1.Location.Y);
                listBox1.Width = sirkaForm / 3;
                lbSirka = listBox1.Width;
                
            }            
            
                textBox1.Width = sirkaForm - lbSirka - 50;
                kalk.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Height);
                kalk.Width = textBox1.Width;
                textBox1.Font = new Font(textBox1.Font.FontFamily, vyskaForm / 7 - 35);
                listBox1.Font = new Font(listBox1.Font.FontFamily, vyskaForm / 12 - 25);
                if (textBox1.Font.Size < 40) label1.Font = new Font(label1.Font.FontFamily, textBox1.Font.Size - 15);
                label1.Height = label1.Font.Height;
                textBox1.Location = new Point(textBox1.Location.X, label1.Location.Y + label1.Height + 5);
                panel1.Width = sirkaForm / 12 * 5;

            foreach (Control c in kalk.Controls)
                {

                    if (c is Button && c.TabIndex!=99)
                    {
                        c.Width = (kalk.Width-50)/pocSloup;
                        c.Height = (vyskaForm - textBox1.Height-label1.Height) / pocRad - 20;
                        c.Font = new Font(c.Font.FontFamily, c.Height / 2-10);
                        int sloupec = c.TabIndex / 10;
                        int radek = c.TabIndex % 10;
                        if (sloupec > 1)
                        {
                            switch (sloupec)
                            {
                                case 2:
                                    locX = sloup1.Location.X + c.Width + 7;
                                    break;
                                case 3:
                                    locX = sloup1.Location.X + 2 * c.Width + 12;
                                    break;
                                case 4:
                                    locX = sloup1.Location.X + 3 * c.Width + 17;
                                    break;
                            case 5:
                                    locX=sloup1.Location.X+4*c.Width+22;
                                    break;
                            }

                            c.Location = new Point(locX, c.Location.Y);
                        }
                        else
                        {
                            c.Location = new Point(textBox1.Location.X, c.Location.Y);
                        }

                        if (radek > 1)
                        {
                            switch (radek)
                            {
                                case 2:
                                    locY = radek1.Location.Y + c.Height + 5;
                                    break;
                                case 3:
                                    locY = radek1.Location.Y + 2 * c.Height + 7;
                                    break;
                                case 4:
                                    locY = radek1.Location.Y + 3 * c.Height + 12;
                                    break;
                                case 5:
                                    locY = radek1.Location.Y + 4 * c.Height + 17;
                                    break;
                                case 6:
                                    locY = radek1.Location.Y + 5 * c.Height + 22;
                                    break;
                                case 7:
                                    locY = radek1.Location.Y + 6 * c.Height + 27;
                                    break;
                            }
                            
                            c.Location = new Point(c.Location.X, locY);
                        }
                        else
                        {
                            c.Location = new Point(c.Location.X, c.Location.Y);
                        }
                    }
                
                }
            
            foreach(Control c in panel1.Controls)
            {
                c.Width = panel1.Width / 5 * 4;
            }

        }

        //Pomocné funkce

        private void rovnaseFocus()
        {
            rovnase.Focus();
            rovnaseV.Focus();
        }

        private void PanelHide()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                    c.Visible = false;
            }

            Clear();
        }

        // Zadávání čísel
        private void cisla_Click(object sender, EventArgs e)
        {
            if (vysledek)                   //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
            {
                textBox1.Text = "";
                vysledek = false;
            }
            if(textBox1.Text!="0") textBox1.Text+=(sender as Button).Text;      //Ošetření aby nebylo víc než jedna 0
            else textBox1.Text = (sender as Button).Text;               //Braní textu tlačítek jako zadávání
            rovnaseFocus();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(kalkZakl.Visible)
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
                        if (!textBox1.Text.Contains(","))
                            desCarka.PerformClick();
                        break;
                }
               
            }

            else if(kalkVed.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad0:
                        nulaV.PerformClick();
                        break;
                    case Keys.NumPad1:
                        jednaV.PerformClick();
                        break;

                    case Keys.NumPad2:
                        dvaV.PerformClick();
                        break;
                    case Keys.NumPad3:
                        triV.PerformClick();
                        break;
                    case Keys.NumPad4:
                        ctyriV.PerformClick();
                        break;
                    case Keys.NumPad5:
                        petV.PerformClick();
                        break;
                    case Keys.NumPad6:
                        sestV.PerformClick();
                        break;
                    case Keys.NumPad7:
                        sedmV.PerformClick();
                        break;
                    case Keys.NumPad8:
                        osmV.PerformClick();
                        break;
                    case Keys.NumPad9:
                        devetV.PerformClick();
                        break;
                    case Keys.Add:
                        plusV.PerformClick();
                        break;
                    case Keys.Subtract:
                        minusV.PerformClick();
                        break;
                    case Keys.Multiply:
                        kratV.PerformClick();
                        break;
                    case Keys.Divide:
                        delenoV.PerformClick();
                        break;
                    case Keys.Back:
                        bckV.PerformClick();
                        break;
                    case Keys.Enter:
                        rovnaseV.PerformClick();
                            break;
                    case Keys.Decimal:
                        if(!textBox1.Text.Contains(","))
                            desCarkaV.PerformClick();
                        break;
                }
               
            }

            rovnaseFocus();
        }

        //Základní kalkulačka - operace
        private void zaklRovnase_Click(object sender, EventArgs e)
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

        private void zaklOper_Click(object sender, EventArgs e)
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
            rovnaseFocus();
        }


        //Vědecká kalkulačka - operace
        private void vedOper_Click(object sender, EventArgs e)
        {
            priklad += textBox1.Text;
            priklad+=(sender as Button).Text;
            label1.Text = priklad;
            textBox1.Text = "0";
        }
        private void rovnaseV_Click(object sender, EventArgs e)
        {
            if(priklad.Length!=0)
            {
                if (textBox1.Text.Length != 0) priklad += textBox1.Text;
                label1.Text = priklad;
                List<double> cisla=new List<double>();
                List<char> operandy = new List<char>();
                double cislo = 0;
                bool prvni = true;
                bool des = false;
                double del = 1;
                double vysledek = 0 ;

                //Získávání čísel a operandů
                foreach(char c in priklad)
                {
                    if(c>='0'&&c<='9')
                    {
                        if(!prvni) cislo *= 10;                       
                        cislo += Convert.ToDouble(c.ToString());
                        prvni = false;
                        if(des) del *= 10;
                    }
                    else if(c=='+'||c=='-'||c=='x'||c=='/')
                    {
                        prvni = true;
                        if(des)
                        {
                            cislo /= del;
                            des= false;
                            del = 10;
                        }
                        cisla.Add(cislo);
                        cislo = 0;
                        operandy.Add(c);
                    }
                    else if(c==',')
                    {
                        des = true;
                    }
                }
                if (des)
                {
                    cislo /= del;
                    des = false;
                    del = 10;
                }
                cisla.Add(cislo);
                

                //Určování priority operací
                List<int> prioritaIndex=new List<int>();
                for(int i = 0;i<operandy.Count;i++)
                {                 
                    if (operandy[i] == 'x' || operandy[i] == '/')
                    {
                        prioritaIndex.Add(i);
                    }
                }

                

                //Počítání operací s prioritou

                double meziVypocet = 0;
                int diff = 0;

                if(prioritaIndex.Count>0)
                {
                    foreach (int i in prioritaIndex)
                    {
                        switch (operandy[i])
                        {
                            case 'x': meziVypocet = cisla[i - diff] * cisla[i + 1 - diff];
                                break;
                            case '/': meziVypocet = cisla[i - diff] / cisla[i + 1 - diff];
                                break;
                        }           
                        cisla[i-diff] = meziVypocet;                      
                        cisla.RemoveAt(i + 1-diff);
                        diff++;
                    }
                    
                    int diffOp = 0;
                    foreach(int i in prioritaIndex)
                    {
                        
                        operandy.RemoveAt(i-diffOp);
                        diffOp++;
                    }              
                }

                vysledek = cisla[0];

                if (operandy.Count > 0)
                {
                    int count = 1;
                    foreach (char c in operandy)
                    {
                        switch (c)
                        {
                            case '+':
                                vysledek += cisla[count];
                                break;
                            case '-':
                                vysledek -= cisla[count];
                                break;
                        }
                        count++;
                    }
                }


                label1.Text += "=";
                textBox1.Text = vysledek.ToString();
                priklad = "";
            }
        }


        //Mocniny
        private void druhaMocnina_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                double pom = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                textBox1.Text = (pom *= pom).ToString();
            }
            rovnaseFocus();
        }

        private void druhaOdmocnina_Click(object sender, EventArgs e)
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
            rovnaseFocus();
        }

        //Změny hodnot
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = (Convert.ToDouble(textBox1.Text) * (-1)).ToString();
                vysledek = false;
            }
            else textBox1.Text = "0";
            rovnaseFocus();
        }

        private void obracenaHodnota_Click(object sender, EventArgs e)
        {
            textBox1.Text = (1 / Convert.ToDouble(textBox1.Text)).ToString();
            rovnaseFocus();
        }
        private void desCarka_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) textBox1.Text = "0";
            double pom1=Convert.ToDouble(textBox1.Text);
            int pom = Convert.ToInt32(pom1);
            if (pom == pom1 && !vysledek) textBox1.Text += (sender as Button).Text;
            else textBox1.Text = "0" + (sender as Button).Text;
            rovnaseFocus();
        }


        //Form akce

        private void Form1_Load(object sender, EventArgs e)
        {
                /* JEN NA TVORBU VĚD KALK */                
                listBox1.Visible = false;
                kalkZakl.Visible = false;
                kalkVed.Visible = true;
                this.Height=500;
                this.Width=500;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;

                kalkVed.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {            
            //autores(5,7,kalkVed);
        }


        //Menu button
        private void menu_Click(object sender, EventArgs e)
        {
            if (panel1.Visible) panel1.Visible = false;
            else panel1.Visible = true;
        }


        //Funkce na zobrazení konkrétních kalkulaček
        private void basicCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            kalkZakl.Visible = true;
            
        }

        private void sciCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            kalkVed.Visible=true;
        }

        //Clear funkce
        private void backspace_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0) textBox1.Text=textBox1.Text.Substring(0,textBox1.Text.Length-1);
            if (textBox1.Text.Length == 0) textBox1.Text = "0";
            rovnaseFocus();
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            rovnaseFocus();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
            textBox1.Clear();
            label1.Text = "";
            cislo = 0;
            listBox1.Items.Clear();
            textBox1.Text = "0";
            rovnaseFocus();
            priklad = "";
        }



        //Nepoužité
        private void CA_Click(object sender, EventArgs e)
        {

        }
        private void jedna_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
