using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        bool jeVysledek = false;

        //Vědecká kalkulačka
        string priklad="";
        int ZavCount=0;        
        bool jeMocnina = false;
        bool valid = true;
        bool jeLog = false;
        char[] operandyPole = { '+', '-', '*', '/', '%', '(' , '^'};
        string[] funkcePole = { "log", "ln", "abs", "root" };

        //Programatorská kalkulačka
        int predchoziSoustava = 0;

        //Grafy
        bool jeGraf = false;

        //Převody

        double[,] Soustavy = {
            {10,10,100,1000},
            {100,100,10000,10000}
        };
        int ZvolenaSoustava = 0;
        string[,] SoustavyText =
        {
            {"Mm","Cm","m","Km" },
            {"Mm^2","Cm^2","m^2","Ha"}
        };
        

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
            rovnaseP.Focus();
            btnMakeGraph.Focus();
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
        private void btnFakt(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double pom))
            {
                int fakt = 1;
                for(int i=2;i<=pom;i++)
                {
                    fakt *= i;
                }
                textBox1.Text=fakt.ToString();
            }
        }
        private void Pi_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.PI.ToString("F8");
        }

        private void euler_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.E.ToString("F8");
        }

        private void invalidInput()
        {
            textBox1.Text = "Invalid input";
            clearLabeluVProgKalk();
            valid = false;
        }

        private void clearLabeluVProgKalk()
        {
            labelBin.Text = "0";
            labelDec.Text = "0";
            labelHex.Text = "0";
            labelOct.Text = "0";
        }

        private void ClearComboBox()
        {
            comboPrevodDo.Items.Clear();
            comboPrevodZ.Items.Clear();
        }
        // Zadávání čísel
        private void cisla_Click(object sender, EventArgs e)
        {
            bool validZadani = true;
            if(jeGraf)
            {
                priklad = "";
                label1.Text = "";
                jeGraf = false;
            }
            if (jeVysledek)                   //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
            {
                textBox1.Text = "";
                jeVysledek = false;
            }   
            if(!valid&&!jeMocnina)
            {
                textBox1.Text = "";
                valid = true;
            }
            string s= (sender as Button).Text;
            if(s=="x")
            {
                if(textBox1.Text.Length!=0)
                {
                    if(textBox1.Text!="0")
                    {
                        if(textBox1.Text[textBox1.Text.Length-1]=='x'||(textBox1.Text[textBox1.Text.Length - 1]>='0'&& textBox1.Text[textBox1.Text.Length - 1]<='í'))
                        {
                        
                                priklad += $"{textBox1.Text}*";
                                textBox1.Text = "";
                        
                        }
                    }
                }
            }
            if(!valid&&Double.TryParse(s,out double d))
            {
                valid = true;
            }
            if (s == "(")
            {
                if(jeMocnina)
                {
                    priklad += textBox1.Text;
                    textBox1.Text = "";
                }
                validZadani = false;
                if(Double.TryParse(textBox1.Text,out double pom)&&pom!=0)
                {                   
                     textBox1.Text += 'x';
                     priklad += textBox1.Text;
                     textBox1.Text = "";
                }
                if (priklad.Length!=0&&priklad[priklad.Length - 1] == ')') priklad += "*";
                priklad += "(";
                ZavCount++; 
            }
            if (s == ")")
            {
                if (textBox1.Text.Length == 0&&priklad[priklad.Length-1]=='(') textBox1.Text = "0";
                priklad += textBox1.Text;
                textBox1.Text = "";
                if (ZavCount != 0)
                {
                    ZavCount--;
                    priklad += ")";
                }
                validZadani = false;
            }
            if(validZadani)
            {
                if(textBox1.Text=="0") textBox1.Text = s;                //Braní textu tlačítek jako zadávání
                else textBox1.Text += s;
            }
            label1.Text = priklad;
            rovnaseFocus();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (kalkZakl.Visible)
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

            else if (kalkVed.Visible)
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
                        if (!textBox1.Text.Contains(","))
                            desCarkaV.PerformClick();
                        break;
                }

            }

            else if (kalkProg.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad0:
                        nulaP.PerformClick();
                        break;
                    case Keys.NumPad1:
                        jednaP.PerformClick();
                        break;
                    case Keys.NumPad2:
                        dvaP.PerformClick();
                        break;
                    case Keys.NumPad3:
                        triP.PerformClick();
                        break;
                    case Keys.NumPad4:
                        ctyriP.PerformClick();
                        break;
                    case Keys.NumPad5:
                        petP.PerformClick();
                        break;
                    case Keys.NumPad6:
                        sestP.PerformClick();
                        break;
                    case Keys.NumPad7:
                        sedmP.PerformClick();
                        break;
                    case Keys.NumPad8:
                        osmP.PerformClick();
                        break;
                    case Keys.NumPad9:
                        devetP.PerformClick();
                        break;
                    case Keys.Add:
                        plusP.PerformClick();
                        break;
                    case Keys.Subtract:
                        minusP.PerformClick();
                        break;
                    case Keys.Multiply:
                        kratP.PerformClick();
                        break;
                    case Keys.Divide:
                        delenoP.PerformClick();
                        break;
                    case Keys.Back:
                        bckP.PerformClick();
                        break;
                    case Keys.Enter:
                        rovnaseP.PerformClick();
                        break;
                    case Keys.Decimal:
                        if (!textBox1.Text.Contains(","))
                            desCarkaP.PerformClick();
                        break;
                }
            }

            else if(kalkGraf.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad0:
                        nulaG.PerformClick();
                        break;
                    case Keys.NumPad1:
                        jednaG.PerformClick();
                        break;
                    case Keys.NumPad2:
                        dvaG.PerformClick();
                        break;
                    case Keys.NumPad3:
                        triG.PerformClick();
                        break;
                    case Keys.NumPad4:
                        ctyriG.PerformClick();
                        break;
                    case Keys.NumPad5:
                        petG.PerformClick();
                        break;
                    case Keys.NumPad6:
                        sestG.PerformClick();
                        break;
                    case Keys.NumPad7:
                        sedmG.PerformClick();
                        break;
                    case Keys.NumPad8:
                        osmG.PerformClick();
                        break;
                    case Keys.NumPad9:
                        devetG.PerformClick();
                        break;
                    case Keys.Add:
                        plusG.PerformClick();
                        break;
                    case Keys.Subtract:
                        minusG.PerformClick();
                        break;
                    case Keys.Multiply:
                        kratG.PerformClick();
                        break;
                    case Keys.Divide:
                        delenoG.PerformClick();
                        break;
                    case Keys.Back:
                        bckG.PerformClick();
                        break;
                    case Keys.Enter:
                        btnMakeGraph.PerformClick();
                        break;
                    case Keys.Decimal:
                        if (!textBox1.Text.Contains(","))
                            desCarkaG.PerformClick();
                        break;
                    case Keys.X:
                        btnX.PerformClick();
                        break;
                }
            }

            else if(kalkPrevod.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.NumPad0:
                        nulaT.PerformClick();
                        break;
                    case Keys.NumPad1:
                        jednaT.PerformClick();
                        break;
                    case Keys.NumPad2:
                        dvaT.PerformClick();
                        break;
                    case Keys.NumPad3:
                        triT.PerformClick();
                        break;
                    case Keys.NumPad4:
                        ctyriT.PerformClick();
                        break;
                    case Keys.NumPad5:
                        petT.PerformClick();
                        break;
                    case Keys.NumPad6:
                        sestT.PerformClick();
                        break;
                    case Keys.NumPad7:
                        sedmT.PerformClick();
                        break;
                    case Keys.NumPad8:
                        osmT.PerformClick();
                        break;
                    case Keys.NumPad9:
                        devetT.PerformClick();
                        break;                   
                    case Keys.Back:
                        bckT.PerformClick();
                        break;
                    case Keys.Decimal:
                        if (!textBox1.Text.Contains(","))
                            desCarka.PerformClick();
                        break;
                }
            }
            rovnaseFocus();
        }



        /* Kalkulačky */



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
                        case '*':
                            cislo *= cislo2;
                            break;
                        case '/':
                            if (cislo2 == 0)
                            {
                                invalidInput();
                            }
                            else cislo /= cislo2;
                        break;
                    }
                
            label1.Text = "";
            textBox1.Text = cislo.ToString();
            listBox1.Items.Add(cislo);
            pruchod = false;
                jeVysledek = true;        //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
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
                    case '*':
                        cislo *= cislo2;
                        break;
                    case '/':
                        if(cislo2==0)
                        {
                            invalidInput();
                        }
                        else cislo /= cislo2;
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

        private double vypocitaniPrikladu(string prikladS)
        {           
            List<double> cisla = new List<double>();
            List<char> operandy = new List<char>();            
            //Promenna do ktere hazim cisla
            string cislo = "";     
                   
            //Zaporne cislo
            bool znam = true;

            // Zavorky
            bool zavorka = false;
            int countZacZavorek = 0;
            int countKonZavorek = 0;
            int indexZacZav = 0;           

            string podPriklad = "";
            
            //Vysledek
            double vysledek = 0;
                    
            //Kontrola zavorek v prikladu
            while (prikladS.Contains('('))
            {
                for (int i = 0; i < prikladS.Length; i++)
                {
                    char c = prikladS[i];
                    
                    if (c == '(')
                    {
                        if (!zavorka)
                        {                            
                            zavorka = true;
                            indexZacZav = i;
                        }
                        countZacZavorek++;
                    }
                    else if(c== ')')
                    {
                        countKonZavorek++;
                        if (countZacZavorek == countKonZavorek)  //Diky tomuhle nevadi vnorene zavorky
                        {
                            //vytvoreni prikladu ze zavorky
                            podPriklad = prikladS.Substring(indexZacZav + 1, i - indexZacZav - 1);
                            //Odstraneni podprikladu z hlavniho prikladu
                            prikladS = prikladS.Remove(indexZacZav, i - indexZacZav + 1);
                            //Vlozeni vysledku z podprikladu                            
                            double pomVys = vypocitaniPrikladu(podPriklad);
                           
                            prikladS = prikladS.Insert(indexZacZav, pomVys.ToString());                            
                            zavorka = false;                            
                            //jistota ze to projde vsechny zavorky spravne
                            i = 0;
                        }
                    }
                }                
            }

            

            //Získávání čísel a operandů            
            foreach (char c in prikladS)
            {                    
                if ((c >= '0' && c <= '9')||(znam&&c=='-')||c==',')
                {                    
                    cislo += c;
                    znam = false;                        
                }
                    
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%'||c=='^')
                {                  
                  
                    if(cislo!="")
                    {                           
                        cisla.Add(Convert.ToDouble(cislo));
                    }
                    cislo = "";
                    operandy.Add(c);
                    znam = true;
                }    
                /* l = log
                 * n = ln
                 * a = abs
                 * r = root
                 */
                else if(c=='g'||c=='n'||c=='s'||c=='t')
                {
                    switch(c)
                    {
                        case 'g':
                            operandy.Add('l');
                            break;
                        case 'n':
                            operandy.Add('n');
                            break;
                        case 's':
                            operandy.Add('a');
                            break;
                        case 't':
                            operandy.Add('r');
                            break;
                    }
                }
                        
            }




            
            if(cislo!=""&&Double.TryParse(cislo,out double pomCislo)) cisla.Add(pomCislo);
            if(!double.TryParse(prikladS,out vysledek))
            {               
                

                //Určování a počítání priority operací             
                          

                    //Složitější funkce
                if(funkcePole.Any(prikladS.Contains) && valid)
                {
                    int diff = 0;
                    for (int i = 0; i < operandy.Count; i++)
                    {
                        if (operandy[i] == 'l')
                        {                            
                            double n = cisla[i - diff];
                            if (n > 0)
                            {                                
                                cisla[i - diff] = Math.Log10(n);
                                operandy.RemoveAt(i - diff);
                                diff++;
                            }
                            else
                            {
                                invalidInput();
                                break;
                            }
                        }
                        else if (operandy[i] == 'n')
                        {
                            double n = cisla[i - diff];
                            if (n > 0)
                            {
                                cisla[i - diff] = Math.Log(n);
                                operandy.RemoveAt(i - diff);
                                diff++;
                            }
                            else
                            {
                                invalidInput();
                                break;
                            }
                        }
                        else if (operandy[i] == 'a')
                        {
                            double n = cisla[i - diff];                            
                            cisla[i - diff] = Math.Abs(n);
                            operandy.RemoveAt(i - diff);
                            diff++;                            
                        }
                        else if (operandy[i] == 'r')
                        {
                            double n = cisla[i - diff];
                            if (n >= 0)
                            {
                                cisla[i - diff] = Math.Sqrt(n);
                                operandy.RemoveAt(i - diff);
                                diff++;
                            }
                            else
                            {
                                invalidInput();
                                break;
                            }
                        }
                    }
                }

                    //Mocniny
                if (prikladS.Contains("^")&&valid)
                {                    
                    int diff = 0;
                    for (int i = 0; i < operandy.Count; i++)
                    {
                        if (operandy[i] == '^')
                        {
                            double a = cisla[i - diff];
                            double n = cisla[i - diff + 1];
                            cisla[i - diff] = Math.Pow(a, n);
                            cisla.RemoveAt(i + 1 - diff);
                            operandy.RemoveAt(i - diff);                        
                            diff++;
                        }
                    }                   
                }


                if((prikladS.Contains("*")||prikladS.Contains("/")||prikladS.Contains("%")) && valid)
                {
                    double meziVypocet = 0;
                    int diff = 0;
                    for (int i = 0; i < operandy.Count; i++)
                    {
                        if (operandy[i] == '*' || operandy[i] == '/' || operandy[i] == '%')
                        {
                            switch (operandy[i])
                            {
                                case '*':
                                    meziVypocet = cisla[i - diff] * cisla[i + 1 - diff];
                                    break;
                                case '/':
                                    meziVypocet = cisla[i - diff] / cisla[i + 1 - diff];
                                    break;
                                case '%':
                                    if (Convert.ToInt64(cisla[i + 1 - diff]) == 0) invalidInput();
                                    else meziVypocet = Convert.ToInt64(cisla[i - diff]) % Convert.ToInt64(cisla[i + 1 - diff]);
                                    break;
                            }
                            cisla[i - diff] = meziVypocet;
                            cisla.RemoveAt(i + 1 - diff);
                            operandy.RemoveAt(i - diff);
                            diff++;
                        }
                    }
                }

                
                if(cisla.Count>0 && valid)
                {
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
                }

            }

            ZavCount = 0;
            return vysledek;
        }
        private void vedOper_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                if (jeMocnina) jeMocnina = false;
                if (!jeLog)
                {
                    priklad += textBox1.Text;
                }
                jeLog = false;               
                label1.Text += textBox1.Text;
                if (Convert.ToInt32((sender as Button).Tag) == 10)
                {
                    priklad += "%";
                    label1.Text += "%";
                }
                else
                {
                    priklad += (sender as Button).Text;
                    label1.Text += (sender as Button).Text;
                }            
                textBox1.Text = "0";
            }
        }
        private void rovnaseV_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                if (jeMocnina)
                {
                    priklad += textBox1.Text;
                    textBox1.Text = "";
                    jeMocnina = false;
                }
                if(priklad.Length!=0)
                {
                    if (textBox1.Text.Length != 0&&!jeLog) priklad += textBox1.Text;
                    while(ZavCount>0)
                    {
                        priklad += ")";                       
                        ZavCount--;
                    }
                    //label1.Text += textBox1.Text;
                    label1.Text = priklad;
                    double vysledek=vypocitaniPrikladu(priklad);
                    label1.Text += "=";
                    if (valid)
                    {
                        textBox1.Text = vysledek.ToString();
                        listBox1.Items.Add(vysledek);
                    }
                    else invalidInput();
                    priklad = "";
                    jeVysledek = true;
                }
            }
        }


        //Programátorská kalkulačka


        private long vypocitaniPrikladuProg(string prikladS)
        {
            List<long> cisla = new List<long>();
            List<char> operandy = new List<char>();

            string cislo = "";

            // Zavorky
            bool zavorka = false;
            int countZacZavorek = 0;
            int countKonZavorek = 0;
            int indexZacZav = 0;

            string podPriklad = "";

            long vysledek;

            while (prikladS.Contains('('))
            {
                for (int i = 0; i < prikladS.Length; i++)
                {
                    char c = prikladS[i];                   


                    if (c == '(')
                    {
                        if (!zavorka)
                        {
                            zavorka = true;
                            indexZacZav = i;
                        }
                        countZacZavorek++;
                    }
                    else if (c == ')')
                    {
                        countKonZavorek++;
                        if (countZacZavorek == countKonZavorek)  //Diky tomuhle nevadi vnorene zavorky
                        {
                            //vytvoreni prikladu ze zavorky
                            podPriklad = prikladS.Substring(indexZacZav + 1, i - indexZacZav - 1);
                            //Odstraneni podprikladu z hlavniho prikladu
                            prikladS = prikladS.Remove(indexZacZav, i - indexZacZav + 1);
                            //Vlozeni vysledku z podprikladu                            
                            double pomVys = vypocitaniPrikladu(podPriklad);                            
              
                            prikladS = prikladS.Insert(indexZacZav, pomVys.ToString());
                            zavorka = false;
                            //Neni nejlip optimalizovany, ale aspon to funguje. Sice se bude cely priklad prochazet znovu
                            //ale aspon je jistota ze to projde vsechny zavorky spravne
                            i = 0;
                        }
                    }
                }
            }

            //Získávání čísel a operandů            
            foreach (char c in prikladS)
            {
                if ((c >= '0' && c <= '9'))
                {
                    cislo += c;                    
                }

                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^')
                {

                    if (cislo != "")
                    {
                        cisla.Add(Convert.ToInt64(cislo));
                    }
                    cislo = "";
                    operandy.Add(c);                    
                }

            }

            if (cislo != "") cisla.Add(Convert.ToInt64(cislo));


            if (!Int64.TryParse(prikladS, out vysledek))
            {
                //Určování a počítání priority operací             
                              


                if (prikladS.Contains("*") || prikladS.Contains("/") || prikladS.Contains("%"))
                {
                    long meziVypocet = 0;
                    int diff = 0;
                    for (int i = 0; i < operandy.Count; i++)
                    {
                        if (operandy[i] == '*' || operandy[i] == '/' || operandy[i] == '%')
                        {
                            switch (operandy[i])
                            {
                                case '*':
                                    meziVypocet = cisla[i - diff] * cisla[i + 1 - diff];
                                    break;
                                case '/':
                                    meziVypocet = cisla[i - diff] / cisla[i + 1 - diff];
                                    break;
                                case '%':
                                    if (Convert.ToInt64(cisla[i + 1 - diff]) == 0) invalidInput();
                                    else meziVypocet = Convert.ToInt64(cisla[i - diff]) % Convert.ToInt64(cisla[i + 1 - diff]);
                                    break;
                            }
                            cisla[i - diff] = meziVypocet;
                            cisla.RemoveAt(i + 1 - diff);
                            operandy.RemoveAt(i - diff);
                            diff++;
                        }
                    }
                }


                if (cisla.Count > 0)
                {
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
                }

            }

            ZavCount = 0;
            return vysledek;

        }

        private void rovnaseP_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                if(priklad.Length!=0)
                {
                    //Doplnění o obsah textboxu
                    if (textBox1.Text.Length != 0) priklad += textBox1.Text;
                    //Doplnění závorek
                    while (ZavCount > 0)
                    {
                        priklad += ")";
                        ZavCount--;
                    }
                    //vypsání příkladu do labelu
                    label1.Text = priklad;                  
                    //vypočítání pokud 10 soustava
                    if (radioDec.Checked) textBox1.Text = vypocitaniPrikladuProg(priklad).ToString();
                    //vypočítání pokud 2 soustava
                    else if(radioBin.Checked)
                    {
                        priklad = prevodPrikladuZBinDoDec(priklad);
                        //vypočítání v 10 a převod do 2
                        textBox1.Text = prevodSoustavy(vypocitaniPrikladuProg(priklad), 2);
                        
                    }
                    else if(radioOct.Checked)
                    {
                        priklad = prevodPrikladuZOctDoDec(priklad);
                        //vypočítání v 10 a převod do 8
                        textBox1.Text = prevodSoustavy(vypocitaniPrikladuProg(priklad), 8);
                    }
                    else
                    {
                        priklad = prevodPrikladuZHexDoDec(priklad);
                        //vypočítání v 10 a převod do 16
                        textBox1.Text = vypocitaniPrikladuProg(priklad).ToString("X");
                    }
                    jeVysledek = true;
                    priklad = "";
                }
            }
        }

        private string prevodSoustavy(long cislo,int soustava)
        {
            string vys = "";
            if (cislo == 0) vys = "0";
            while(cislo!=0)
            {
                vys = (cislo % soustava) + vys;
                cislo /= soustava;
            }
            return vys;
        }

        private long prevodSoustavy(string hodnota,int soustava)
        {
            long cislo = 0;
            int nasobek = 1;
            while(hodnota.Length!=0)
            {
                cislo += (Convert.ToInt32(hodnota[hodnota.Length - 1])-48) * nasobek;
                nasobek *= soustava;
                hodnota = hodnota.Substring(0, hodnota.Length - 1);
            }
            return cislo;
        }


        private string prevodPrikladuZDec(string prikladDec,int soustava)
        {
            string cisloDec = "";
            bool jeDecCislo = false;
            int pomIndDec = 0;
            int delka = 0;

            for (int i = 0; i < prikladDec.Length; i++)
            {
                char c = prikladDec[i];
                if (c >= '0' && c <= '9')
                {
                    if (!jeDecCislo)
                    {
                        pomIndDec = i;          //index začátku bin čísla
                        jeDecCislo = true;
                    }
                    cisloDec += c;
                    delka++;
                }
                else if (jeDecCislo)
                {                    
                    prikladDec = prikladDec.Remove(pomIndDec, delka);
                    long pomDes = Int64.Parse(cisloDec);
                    string pomPrevod;
                    if (soustava == 2 || soustava == 8)
                    {
                        pomPrevod = prevodSoustavy(pomDes, soustava);
                        prikladDec = prikladDec.Insert(pomIndDec, pomPrevod);                    
                    }
                    else
                    {
                        pomPrevod = pomDes.ToString("X");
                        prikladDec = prikladDec.Insert(pomIndDec, pomPrevod);
                    }
                    i -= (delka - pomPrevod.Length);
                    cisloDec = "";
                    jeDecCislo = false;
                    delka = 0;
                }
            }
            if (jeDecCislo)
            {
                //přidání posledního čísla v příkladu
                prikladDec = prikladDec.Remove(pomIndDec, delka);
                long pomDes = Int64.Parse(cisloDec);
                if (soustava == 2 || soustava == 8)
                    prikladDec = prikladDec.Insert(pomIndDec, prevodSoustavy(pomDes, soustava));
                else
                    prikladDec = prikladDec.Insert(pomIndDec, pomDes.ToString("X"));
            }            
            return prikladDec;
        }

        private string prevodPrikladuZBinDoDec(string prikladBin)
        {
            string cisloBin = "";
            bool jeBinCislo = false;
            int pomIndBin = 0;
            int delka = 0;

            for (int i = 0; i < prikladBin.Length; i++)
            {
                char c = prikladBin[i];
                if (c == '0' || c == '1')
                {
                    if (!jeBinCislo)
                    {
                        pomIndBin = i;          //index začátku bin čísla
                        jeBinCislo = true;
                    }
                    cisloBin += c;
                    delka++;
                }
                else if (jeBinCislo)
                {
                    //nahrazení binárního čísla desítkovým
                    prikladBin = prikladBin.Remove(pomIndBin, delka);
                    long pomDes = prevodSoustavy(cisloBin, 2);
                    i -= (delka - pomDes.ToString().Length);
                    prikladBin = prikladBin.Insert(pomIndBin, pomDes.ToString());
                    cisloBin = "";
                    jeBinCislo = false;
                    delka = 0;
                }
            }
            if (jeBinCislo)
            {
                //přidání posledního čísla v příkladu
                prikladBin = prikladBin.Remove(pomIndBin, delka);
                prikladBin = prikladBin.Insert(pomIndBin, prevodSoustavy(cisloBin, 2).ToString());
            }            
            return prikladBin;
        }

        private string prevodPrikladuZOctDoDec(string prikladOct)
        {
            string cisloOct = "";
            bool jeOctCislo = false;
            int pomIndOct = 0;
            int delka = 0;

            for (int i = 0; i < prikladOct.Length; i++)
            {
                char c = prikladOct[i];
                if (c >= '0' && c < '8')
                {
                    if (!jeOctCislo)
                    {
                        pomIndOct = i;          //index začátku bin čísla
                        jeOctCislo = true;
                    }
                    cisloOct += c;
                    delka++;
                }
                else if (jeOctCislo)
                {
                    //nahrazení binárního čísla desítkovým
                    prikladOct = prikladOct.Remove(pomIndOct, delka);
                    long pomDes = prevodSoustavy(cisloOct, 8);
                    i -= (delka - pomDes.ToString().Length);
                    prikladOct = prikladOct.Insert(pomIndOct, pomDes.ToString());
                    cisloOct = "";
                    jeOctCislo = false;
                    delka = 0;
                }
            }
            if (jeOctCislo)
            {
                //přidání posledního čísla v příkladu
                prikladOct = prikladOct.Remove(pomIndOct, delka);
                prikladOct = prikladOct.Insert(pomIndOct, prevodSoustavy(cisloOct, 8).ToString());
            }
            return prikladOct;
        }

        private string prevodPrikladuZHexDoDec(string prikladHex)
        {
            string cisloHex = "";
            bool jeHexCislo = false;
            int pomIndHex = 0;
            int delka = 0;

            for (int i = 0; i < prikladHex.Length; i++)
            {
                char c = prikladHex[i];
                if (c >= '0' && c <= '9' || c >= 'A' && c <= 'F')
                {
                    if (!jeHexCislo)
                    {
                        pomIndHex = i;          //index začátku bin čísla
                        jeHexCislo = true;
                    }
                    cisloHex += c;
                    delka++;
                }
                else if (jeHexCislo)
                {
                    //nahrazení binárního čísla desítkovým
                    prikladHex = prikladHex.Remove(pomIndHex, delka);
                    long pomDes = Convert.ToInt64(cisloHex, 16);
                    i -= (delka - pomDes.ToString().Length);
                    prikladHex = prikladHex.Insert(pomIndHex, pomDes.ToString());
                    cisloHex = "";
                    jeHexCislo = false;
                    delka = 0;
                }
            }
            if (jeHexCislo)
            {
                //přidání posledního čísla v příkladu
                prikladHex = prikladHex.Remove(pomIndHex, delka);
                prikladHex = prikladHex.Insert(pomIndHex, Convert.ToInt64(cisloHex, 16).ToString());
            }
            return prikladHex;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && valid)
            {
                if(kalkProg.Visible)
                {
                    if (Int64.TryParse(textBox1.Text, out long hodnota) && radioDec.Checked)
                    {
                        labelDec.Text = hodnota.ToString();
                        labelBin.Text = prevodSoustavy(hodnota, 2);
                        labelOct.Text = prevodSoustavy(hodnota, 8);
                        labelHex.Text = hodnota.ToString("X");
                    }
                    else if (radioBin.Checked)
                    {
                        labelBin.Text = textBox1.Text;
                        long dec = prevodSoustavy(textBox1.Text, 2);
                        labelDec.Text = dec.ToString();
                        labelOct.Text = prevodSoustavy(dec, 8);
                        labelHex.Text = dec.ToString("X");
                    }
                    else if (radioOct.Checked)
                    {
                        labelOct.Text = textBox1.Text;
                        long dec = prevodSoustavy(textBox1.Text, 8);
                        labelDec.Text = dec.ToString();
                        labelBin.Text = prevodSoustavy(dec, 2);
                        labelHex.Text = dec.ToString("X");
                    }
                    else if (radioHex.Checked)
                    {
                        labelHex.Text = textBox1.Text;
                        long dec = Convert.ToInt64(textBox1.Text, 16);
                        labelDec.Text = dec.ToString();
                        labelBin.Text = prevodSoustavy(dec, 2);
                        labelOct.Text = prevodSoustavy(dec, 8);
                    }                  
                    else invalidInput();
                } 
                if(kalkPrevod.Visible)
                {
                    int indPrevodZ = comboPrevodZ.SelectedIndex;
                    int indPrevodDo = comboPrevodDo.SelectedIndex;
                    double hodnota = Double.Parse(textBox1.Text);
                    if(indPrevodZ-indPrevodDo<0)
                    {
                        while(indPrevodZ<indPrevodDo)
                            hodnota /= Soustavy[ZvolenaSoustava,++indPrevodZ];
                    }
                    else
                    {
                        while (indPrevodZ > indPrevodDo)
                            hodnota *= Soustavy[ZvolenaSoustava, indPrevodZ--];
                    }
                    labPrevod.Text = hodnota.ToString();
                }
            }
        }

        //Povolení buttonů pouze pro danou soustavu
        private void enableButtons(int tagKalk)
        {
            foreach (Control c in kalkProg.Controls)
            {
                if (c is Button && Convert.ToInt32(c.Tag) >= tagKalk)
                {
                    c.Enabled = true;
                }
                else if (c is Button)
                {
                    c.Enabled = false;
                }
            }
        }

        private void zmenaSoustavy_ChangeChecked(object sender, EventArgs e)
        {
            switch(predchoziSoustava)
            {
                case 0:
                    break;
                case 1: priklad = prevodPrikladuZBinDoDec(priklad);
                    break;
                case 2: priklad = prevodPrikladuZOctDoDec(priklad);
                    break;
                case 3: priklad = prevodPrikladuZHexDoDec(priklad);
                    break;
            }

            if (radioBin.Checked)
            {
                enableButtons(4);
                priklad = prevodPrikladuZDec(priklad, 2);
                predchoziSoustava = 1;
                label1.Text = priklad;
                textBox1.Text = labelBin.Text;
            }
            else if (radioOct.Checked)
            {
                enableButtons(3);
                priklad = prevodPrikladuZDec(priklad, 8);
                predchoziSoustava = 2;
                label1.Text = priklad;
                textBox1.Text = labelOct.Text;
            }
            else if (radioDec.Checked)
            {
                enableButtons(2);
                predchoziSoustava=0;
                label1.Text = priklad;
                textBox1.Text = labelDec.Text;
            }
            else if (radioHex.Checked)
            {
                enableButtons(1);
                priklad = prevodPrikladuZDec(priklad, 16);
                predchoziSoustava = 3;
                label1.Text = priklad;
                textBox1.Text=labelHex.Text;
            }
        }


        // Grafy
        private void makeGraph_Click(object sender, EventArgs e)
        {
            if(jeGraf)
            {
                Clear();
            }
            jeGraf = true;

            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.DataSource = null;
            
            priklad += textBox1.Text;
            textBox1.Text = priklad;
            label1.Text = "";
            
            double bod;            
            var data = new List<Tuple<double, double>>();
            
            for (double x = -30; x <= 30; x += 0.005)
            {
                x = Math.Round(x, 8);
                string funkce = priklad;
                while(funkce.Contains("x"))
                {
                    int indexOfX=funkce.IndexOf("x");
                    funkce=funkce.Remove(indexOfX, 1);
                    funkce = funkce.Insert(indexOfX, x.ToString());
                }                
                bod = vypocitaniPrikladu(funkce);         
                if(valid) data.Add(Tuple.Create(x, bod));
                
                valid = true;
            }

            textBox1.Text = priklad;
            
            chart1.ChartAreas.Add("area1");
            
            var series = chart1.Series.Add("series1");
           
            series.ChartType = SeriesChartType.Line;
            series.ChartArea = "area1";
            series.XValueMember = "Item1";
            series.YValueMembers = "Item2";
            
            chart1.DataSource = data;

            chart1.ChartAreas[0].AxisX.Interval = 5.0;
            chart1.ChartAreas[0].AxisX.Minimum = -30;
            chart1.ChartAreas[0].AxisX.Maximum = 30;

            chart1.ChartAreas[0].AxisY.Interval = 5.0;
            chart1.ChartAreas[0].AxisY.Minimum = -30;
            chart1.ChartAreas[0].AxisY.Maximum = 30;

            jeVysledek = true;
            rovnaseFocus();
        }

        //Převody
        private void ZmenaComboPrevodu(object sender, EventArgs e)
        {
            if(kalkPrevod.Visible)
            {
                int indPrevodZ = comboPrevodZ.SelectedIndex;
                int indPrevodDo = comboPrevodDo.SelectedIndex;
                double hodnota = Double.Parse(textBox1.Text);
                if (indPrevodZ != indPrevodDo)
                {
                    if (indPrevodZ - indPrevodDo < 0)
                    {
                        while (indPrevodZ < indPrevodDo)
                            hodnota /= Soustavy[ZvolenaSoustava, ++indPrevodZ];
                    }
                    else if(indPrevodZ - indPrevodDo > 0)
                    {                       
                        while (indPrevodZ > indPrevodDo)
                            hodnota *= Soustavy[ZvolenaSoustava, indPrevodZ--];
                    }
                }
                labPrevod.Text = hodnota.ToString();
            }            
        }

        //Mocniny
        private void druhaMocnina_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0&&valid)
            {
                double pom = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                textBox1.Text = (pom *= pom).ToString();
            }
            rovnaseFocus();
        }

        private void druhaOdmocnina_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0&&valid)
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

        private void druhaMocninaV_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length != 0&&!operandyPole.Contains(textBox1.Text[textBox1.Text.Length - 1])&&valid && !jeMocnina)
            {
                textBox1.Text += "^2";
                jeMocnina = true;
            }
            rovnaseFocus();
        }

        private void vedeckaOdmocnina_Click(object sender, EventArgs e)
        {
            if (jeMocnina)
            {
                priklad += "(" + textBox1.Text + ")";
                textBox1.Text = "";
                jeMocnina = false;
                valid = true;
            }
            if (Double.TryParse(textBox1.Text, out double logPar) && valid)
            {                
              
                if (logPar < 0)
                {
                    invalidInput();
                }
                else
                {
                    jeLog = true;
                    priklad += $"root({logPar})";
                    label1.Text = priklad;
                    textBox1.Text = "";
                }
                               
            }
            else if(textBox1.Text == "x")
            {
                jeLog = true;
                priklad += $"root(x)";
                label1.Text = priklad;
                textBox1.Text = "";
            }
            else if (valid && priklad[priklad.Length - 1] == ')')
            {
                int pomPocZav = 1;
                int pomIndZav = 0;
                for (int i = priklad.Length - 2; i >= 0; i--)
                {
                    if (priklad[i] == '(') pomPocZav--;
                    else if (priklad[i] == ')') pomPocZav++;
                    if (pomPocZav == 0)
                    {
                        pomIndZav = i;
                        break;
                    }
                }
                priklad = priklad.Insert(pomIndZav, "root");
                label1.Text = priklad;
            }
        }


        private void libovolnaMocnina_Click(object sender, EventArgs e)
        {            
            if (textBox1.Text.Length != 0 && !operandyPole.Contains(textBox1.Text[textBox1.Text.Length-1])&&valid&&!jeMocnina)
            {
                textBox1.Text += "^";
                jeMocnina = true;
                valid = false;
            }
            rovnaseFocus();
        }
        private void mocnina10_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0&&valid)
            {
                textBox1.Text = "10^" + textBox1.Text;
                jeMocnina=true;
            }
            rovnaseFocus();
        }
        
        //Logaritmy
        private void log_Click(object sender, EventArgs e)
        {
            if (jeMocnina)
            {
                priklad += "(" + textBox1.Text + ")";
                textBox1.Text = "";
                jeMocnina = false;
                valid = true;
            }
            if (Double.TryParse(textBox1.Text,out double logPar)&&valid)
            {
                if(logPar<=0)
                {
                    invalidInput();
                }
                else
                {
                    jeLog = true;                           
                    priklad+= $"log({logPar})";
                    label1.Text = priklad;
                    textBox1.Text = "";
                }
            }
            else if (textBox1.Text == "x")
            {
                jeLog = true;
                priklad += $"log(x)";
                label1.Text = priklad;
                textBox1.Text = "";
            }
            else if(valid&&priklad[priklad.Length-1]==')')
            {
                int pomPocZav = 1;
                int pomIndZav = 0;
                for(int i=priklad.Length-2;i>=0;i--)
                {
                    if (priklad[i] == '(') pomPocZav--;
                    else if(priklad[i]==')') pomPocZav++;
                    if (pomPocZav == 0)
                    {
                        pomIndZav = i;
                        break;
                    }                   
                }
                priklad = priklad.Insert(pomIndZav, "log");
                label1.Text = priklad;
            }
        }

        private void ln_Click(object sender, EventArgs e)
        {
            if(jeMocnina)
            {
                priklad += "(" + textBox1.Text + ")";
                textBox1.Text = "";
                jeMocnina = false;
                valid = true;
            }
            if (Double.TryParse(textBox1.Text, out double logPar)&&valid)
            {
                if (logPar <= 0)
                {
                    invalidInput();
                }
                else
                {
                    jeLog = true;
                    priklad += $"ln({logPar})";
                    label1.Text = priklad;
                    textBox1.Text = "";
                }
            }
            else if (textBox1.Text == "x")
            {
                jeLog = true;
                priklad += $"ln(x)";
                label1.Text = priklad;
                textBox1.Text = "";
            }
            else if (valid&&priklad[priklad.Length - 1] == ')')
            {
                int pomPocZav = 1;
                int pomIndZav = 0;
                for (int i = priklad.Length - 2; i >= 0; i--)
                {
                    if (priklad[i] == '(') pomPocZav--;
                    else if (priklad[i] == ')') pomPocZav++;
                    if (pomPocZav == 0)
                    {
                        pomIndZav = i;
                        break;
                    }
                }
                priklad = priklad.Insert(pomIndZav, "ln");
                label1.Text = priklad;
            }
        }

        //Změny hodnot
        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                string s = textBox1.Text;
                textBox1.Text = "";
                if(s.Contains("("))
                {
                    s = s.Replace("(", "");
                    textBox1.Text = "(";
                }
                if (s.Length > 0)
                {
                    textBox1.Text += (Convert.ToDouble(s) * (-1)).ToString();
                    jeVysledek = false;
                }
                else textBox1.Text = "0";
            }
            rovnaseFocus();
        }

        private void obracenaHodnota_Click(object sender, EventArgs e)
        {
            if (valid && Double.TryParse(textBox1.Text, out double pomVys)&&pomVys!=0)
            {
                textBox1.Text = (1 / pomVys).ToString();
                jeVysledek = true;
            }
            rovnaseFocus();
        }
        private void desCarka_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                if (textBox1.Text.Length == 0) textBox1.Text = "0";            
                if (!textBox1.Text.Contains(",") && !jeVysledek) textBox1.Text += (sender as Button).Text;
                else textBox1.Text = "0" + (sender as Button).Text;
            }
            rovnaseFocus();
        }

        private void abs_Click(object sender, EventArgs e)
        {
            if (jeMocnina)
            {
                priklad += "(" + textBox1.Text + ")";
                textBox1.Text = "";
                jeMocnina = false;
                valid = true;
            }
            if (Double.TryParse(textBox1.Text, out double logPar) && valid)
            {
                jeLog = true;
                priklad += $"abs({logPar})";
                label1.Text = priklad;
                textBox1.Text = "";
            }
            else if (textBox1.Text == "x")
            {
                jeLog = true;
                priklad += $"abs(x)";
                label1.Text = priklad;
                textBox1.Text = "";
            }
            else if (valid && priklad[priklad.Length - 1] == ')')
            {
                int pomPocZav = 1;
                int pomIndZav = 0;
                for (int i = priklad.Length - 2; i >= 0; i--)
                {
                    if (priklad[i] == '(') pomPocZav--;
                    else if (priklad[i] == ')') pomPocZav++;
                    if (pomPocZav == 0)
                    {
                        pomIndZav = i;
                        break;
                    }
                }
                priklad = priklad.Insert(pomIndZav, "abs");
                label1.Text = priklad;
            }
        }


        //Form akce

        private void Form1_Load(object sender, EventArgs e)
        {
            /* JEN NA TVORBU VĚD KALK */
            this.Text = "Základní kalkulačka";
            kalkZakl.Visible = true;
            kalkVed.Visible = false;
            kalkGraf.Visible = false;
            kalkDate.Visible = false;
            kalkPrevod.Visible = false;
                this.Height=500;
                this.Width=500;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
            kalkVed.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkProg.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkGraf.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkDate.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkPrevod.Location= new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
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
            textBox1.Visible = true;
            kalkZakl.Visible = true;
            this.Text = "Základní kalkulačka";
            this.Height = 500;
            this.Width = 500;
        }

        private void sciCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            textBox1.Visible = true;
            kalkVed.Visible=true;
            this.Text = "Vědecká kalkulačka";
            this.Height = 500;
            this.Width = 500;
        }

        private void progCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            radioDec.Checked = true;
            enableButtons(2);
            textBox1.Visible = true;
            kalkProg.Visible = true;
            this.Text = "Programátorská kalkulačka";
            this.Height = 500;
            this.Width = 500;
        }

        private void graphCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            this.Width = 700;
            textBox1.Visible = true;
            kalkGraf.Visible = true;
            this.Text = "Vykreslování grafů";
        }

        private void dateCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            textBox1.Visible=false;
            kalkDate.Visible = true;
            this.Text = "Výpočet data";
            this.Height = 500;
            this.Width = 500;
        }

        private void delkaCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            ClearComboBox();
            textBox1.Visible = true;
            kalkPrevod.Visible = true;
            this.Text = "Převod délky";
            ZvolenaSoustava = 0;
            for(int i=0;i<4;i++)
            {
                comboPrevodZ.Items.Add(SoustavyText[ZvolenaSoustava, i]);
                comboPrevodDo.Items.Add(SoustavyText[ZvolenaSoustava, i]);
            }
            comboPrevodZ.SelectedIndex = 0;
            comboPrevodDo.SelectedIndex = 1;
            this.Height = 500;
            this.Width = 500;
        }

        private void obsahCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            ClearComboBox();
            textBox1.Visible = true;
            kalkPrevod.Visible = true;
            this.Text = "Převod délky";
            ZvolenaSoustava = 1;
            for (int i = 0; i < 4; i++)
            {
                comboPrevodZ.Items.Add(SoustavyText[ZvolenaSoustava, i]);
                comboPrevodDo.Items.Add(SoustavyText[ZvolenaSoustava, i]);
            }
            comboPrevodZ.SelectedIndex = 0;
            comboPrevodDo.SelectedIndex = 1;
            this.Height = 500;
            this.Width = 500;
        }

        //Clear funkce
        private void backspace_Click(object sender, EventArgs e)
        {
            if (!valid) textBox1.Text = "0";
            else
            {                
                if(textBox1.Text.Length>0) textBox1.Text=textBox1.Text.Substring(0,textBox1.Text.Length-1);
                if (textBox1.Text.Length == 0) textBox1.Text = "0";
            }
            rovnaseFocus();
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            ZavCount = 0;
            rovnaseFocus();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePicker1.Value;
            DateTime dateTo = dateTimePicker2.Value;
            if (dateFrom != dateTo)
            {
                TimeSpan rozdil = dateFrom - dateTo;
                int dny=Convert.ToInt32(rozdil.TotalDays);                
                if (dny < 0) dny*= -1;
                string sklonDnu = " dní";
                if (dny == 1) sklonDnu = " den";
                else if (dny >= 2 && dny <= 4) sklonDnu = " dny";
                labelDate.Text = dny.ToString()+sklonDnu;
            }
            else labelDate.Text = "Stejné datumy";
        }

        

        private void Clear()
        {
            ZavCount = 0;
            textBox1.Clear();
            label1.Text = "";
            cislo = 0;
            listBox1.Items.Clear();
            textBox1.Text = "0";
            priklad = "";
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.DataSource = null;
            jeGraf = false;
            jeMocnina = false;
            rovnaseFocus();
        }

    }
}
