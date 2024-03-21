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

namespace Calculator
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
        char[] funkcePole = { 'l','n','a','r','s','c'};        

        //Programatorská kalkulačka
        int predchoziSoustava = 0;

        //Grafy
        bool jeGraf = false;

        //Převody

        int ZvolenaSoustava = 0;

        double[][] Soustavy =
        {
            new double[] {1000,1000,1000,10,100,1000,1.6093,1.15077},
            new double[] {100,100,10000,10000,100,2.589989},
            new double[] {10,10,10,10,10,100,1000},
            new double[] {1000,1000,100,10},
            new double[] {1000,1000,1000,60,60,24,7,52},
            new double[] {1000,1000,4.18399,860.585197}
        };
        
        string[][] SoustavyText =
        {
            new string[] {"nanometrů","Mikrometrů","Milimetrů","Centimetrů","Metrů","Kilometrů","Mil","Námořních mil"},
            new string[] {"Milimetrů čtverečních","Centimetrů čtverečních","metrů čtverečních","hektarů","kilometrů čtverečních","mil čtverečních"},
            new string[] {"miligramů","centigramů", "decigramů", "gramů","dekagramů","kilogramů","tun"},
            new string[] {"mililitrů","litrů","hektolitrů","metrů krychlových"},
            new string[] {"mikrosekund","milisekund", "sekund","minut","hodin","dnů","týdnů","let"},
            new string[] {"joulů","kilojoulů","kalorií","Kilowatthodiny"}
        };        

        //Pomocné funkce

        private int IndexOfAny(List<char> list, char[] pole)
        {
            for(int i=0;i<list.Count;i++)
            {
                if (Array.IndexOf(pole, list[i]) != -1) return i;
            }
            return -1;
        }

        private void EqualsFocus()
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
        private void BtnFakt_Click(object sender, EventArgs e)
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

        private void Euler_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.E.ToString("F8");
        }

        private void InvalidInput()
        {
            Clear();
            ClearLabelInProgCalc();
            textBox1.Text = "Invalid input";
            valid = false;
        }

        //Clear funkce
        private void ClearLabelInProgCalc()
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

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (!valid) textBox1.Text = "0";
            else
            {
                if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                if (textBox1.Text.Length == 0) textBox1.Text = "0";
            }
            EqualsFocus();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            ZavCount = 0;
            textBox1.Clear();
            label1.Text = "";
            cislo = 0;
            cislo2 = 0;
            textBox1.Text = "0";
            priklad = "";
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.DataSource = null;
            jeGraf = false;
            jeMocnina = false;
            EqualsFocus();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePicker1.Value;
            DateTime dateTo = dateTimePicker2.Value;
            if (dateFrom != dateTo)
            {
                TimeSpan rozdil = dateFrom - dateTo;
                int dny = Convert.ToInt32(rozdil.TotalDays);
                if (dny < 0) dny *= -1;
                string sklonDnu = " dní";
                if (dny == 1) sklonDnu = " den";
                else if (dny >= 2 && dny <= 4) sklonDnu = " dny";
                labelDate.Text = dny.ToString() + sklonDnu;
            }
            else labelDate.Text = "Stejné datumy";
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
                     textBox1.Text += '*';
                     priklad += textBox1.Text;
                     textBox1.Text = "";
                }
                if (priklad.Length!=0&&priklad[priklad.Length - 1] == ')') priklad += "*";
                priklad += "(";
                ZavCount++; 
            }
            if (s == ")")
            {
                if (ZavCount != 0)
                {
                    if (textBox1.Text.Length == 0 && ((priklad[priklad.Length - 1] == '(') || !(priklad[priklad.Length - 1] >= '0' && priklad[priklad.Length - 1] <= '9'))) textBox1.Text = "0";
                    else if (textBox1.Text[textBox1.Text.Length - 1] == '^') textBox1.Text += "0";
                    priklad += textBox1.Text;
                    textBox1.Text = "";
                    ZavCount--;
                    priklad += ")";
                }
                else valid = false;
                validZadani = false;
            }
            if(validZadani)
            {
                if(textBox1.Text=="0") textBox1.Text = s;                //Braní textu tlačítek jako zadávání
                else textBox1.Text += s;
            }
            label1.Text = priklad;
            EqualsFocus();
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
                    case Keys.A:
                        progA.PerformClick();
                        break;
                    case Keys.B:
                        progB.PerformClick();
                        break;
                    case Keys.C:
                        progC.PerformClick();
                        break;
                    case Keys.D:
                        progD.PerformClick();
                        break;
                    case Keys.E:
                        progE.PerformClick();
                        break;
                    case Keys.F:
                        progF.PerformClick();
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
            EqualsFocus();
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
                        if (Double.IsInfinity(cislo / cislo2) || Double.IsNaN(cislo / cislo2))
                        {                            
                            InvalidInput();
                        }
                        else cislo /= cislo2;
                        break;
                    }                
                label1.Text = "";
                if(valid) textBox1.Text = cislo.ToString();
                pruchod = false;
                jeVysledek = true;        //Po zmáčknutí rovnáse se nebude připisovat do výsledku ale přepíše se
            }
        }

        private void zaklOper_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                if (textBox1.Text.Length == 0)
                {
                    if (label1.Text.Length > 0)
                    {
                        textBox1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
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
                                cislo += (cislo2 * -1);
                            else cislo -= cislo2;
                            break;
                        case '*':
                            cislo *= cislo2;
                            break;
                        case '/':
                            if (Double.IsInfinity(cislo / cislo2) || Double.IsNaN(cislo / cislo2))
                            {                            
                                InvalidInput();                                
                            }
                            else cislo /= cislo2;
                            break;
                    }                    
                    if(valid) label1.Text = textBox1.Text;
                    textBox1.Text = cislo.ToString();                  
                }
                if(valid)
                {
                    cislo = Convert.ToDouble(textBox1.Text);
                    textBox1.Text += (sender as Button).Text;
                    operace = Convert.ToChar((sender as Button).Text);
                    label1.Text = textBox1.Text;
                    textBox1.Clear();
                    pruchod = true;
                }
                EqualsFocus();
            }            
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
            char predchozi=' ';
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
                 * s = sin
                 * c = cos
                 */
                else if(c=='g'||c=='n'||c=='s'||c=='t')
                {                    
                    switch(c)
                    {
                        case 'g':
                            operandy.Add('l');
                            break;
                        case 'n':
                            if (predchozi == 'l') operandy.Add('n');
                            else operandy.Add('s');
                            break;
                        case 's':
                            if (predchozi == 'b') operandy.Add('a');
                            else operandy.Add('c');
                            break;
                        case 't':
                            operandy.Add('r');
                            break;
                    }
                }
                predchozi = c;      
            }




            
            if(cislo!=""&&Double.TryParse(cislo,out double pomCislo)) cisla.Add(pomCislo);
            if(!double.TryParse(prikladS,out vysledek))
            {
                //Určování a počítání priority operací             
                
                    //Složitější funkce
                    
                while(funkcePole.Any(operandy.Contains)&&valid)
                {
                    int indexFunkce = IndexOfAny(operandy, funkcePole);
                    double n = cisla[indexFunkce];                    
                    switch(operandy[indexFunkce])
                    {
                        case 'l':
                            if (n > 0)
                            {
                                cisla[indexFunkce] = Math.Log10(n);
                                operandy.RemoveAt(indexFunkce);                                
                            }
                            else
                            {
                                InvalidInput();
                            }
                            break;
                        case 'n':                            
                            if (n > 0)
                            {
                                cisla[indexFunkce] = Math.Log(n);
                                operandy.RemoveAt(indexFunkce);
                            }
                            else
                            {
                                InvalidInput();
                            }
                            break;
                        case 'a':                            
                            cisla[indexFunkce] = Math.Abs(n);
                            operandy.RemoveAt(indexFunkce);
                            break;
                        case 'r':
                            if (n >= 0)
                            {
                                cisla[indexFunkce] = Math.Sqrt(n);
                                operandy.RemoveAt(indexFunkce);                                
                            }
                            else
                            {
                                InvalidInput();                                
                            }
                            break;
                        case 's':
                            cisla[indexFunkce] = Math.Sin(n);
                            operandy.RemoveAt(indexFunkce);
                            break;
                        case 'c':
                            cisla[indexFunkce] = Math.Cos(n);
                            operandy.RemoveAt(indexFunkce);
                            break;
                    }
                }

                    //Mocniny

                while(operandy.Contains('^'))
                {
                    int indexMoc = operandy.IndexOf('^');
                    cisla[indexMoc] = Math.Pow(cisla[indexMoc], cisla[indexMoc + 1]);
                    cisla.RemoveAt(indexMoc+1);
                    operandy.RemoveAt(indexMoc);
                }

                while((operandy.Contains('*')||operandy.Contains('/')||operandy.Contains('%'))&&valid)
                {
                    double meziVypocet = 0;
                    char[] pomPole = { '*', '/', '%' };
                    int indexOp = IndexOfAny(operandy, pomPole);                   
                    switch (operandy[indexOp])
                    {
                        case '*':
                            meziVypocet = cisla[indexOp] * cisla[indexOp + 1];
                            break;
                        case '/':
                            meziVypocet = cisla[indexOp] / cisla[indexOp+1];
                            if (Double.IsInfinity(meziVypocet) || Double.IsNaN(meziVypocet)) InvalidInput();
                            break;
                        case '%':
                            if (Double.IsInfinity(1 / cisla[indexOp+1])) InvalidInput();
                            else meziVypocet = cisla[indexOp] % cisla[indexOp+1];
                            break;
                    }
                    cisla[indexOp] = meziVypocet;
                    cisla.RemoveAt(indexOp + 1);
                    operandy.RemoveAt(indexOp);
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
                if (priklad.Length != 0 &&
                    ((priklad[priklad.Length-1]>='0'&& priklad[priklad.Length - 1]<='9')||
                    priklad[priklad.Length - 1] == 'x' || (priklad[priklad.Length-1]>='A'&&
                    priklad[priklad.Length - 1]<='F')))
                {
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
                }                
                textBox1.Text = "0";
            }
        }
        private void rovnaseV_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox1.Text[textBox1.Text.Length - 1] == '^') InvalidInput();
            if (valid)
            {
                if (jeMocnina)
                {
                    priklad += textBox1.Text;
                    textBox1.Text = "";
                    jeMocnina = false;
                }
                if(jeLog)
                {
                    priklad += textBox1.Text;
                    textBox1.Text = "";
                    jeLog = false;
                }
                if(priklad.Length!=0)
                {
                    if (textBox1.Text.Length != 0 && !jeLog)
                    {
                        if (priklad[priklad.Length - 1] == ')') priklad += '*';
                        priklad += textBox1.Text;
                    }
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
                    }
                    else InvalidInput();
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



                while ((operandy.Contains('*') || operandy.Contains('/') || operandy.Contains('%')) && valid)
                {
                    long meziVypocet = 0;
                    char[] pomPole = { '*', '/', '%' };
                    int indexOp = IndexOfAny(operandy, pomPole);
                    switch (operandy[indexOp])
                    {
                        case '*':
                            meziVypocet = cisla[indexOp] * cisla[indexOp + 1];
                            break;
                        case '/':
                            if (cisla[indexOp+1]==0) InvalidInput();
                            else meziVypocet = cisla[indexOp] / cisla[indexOp + 1];
                            break;
                        case '%':
                            if (cisla[indexOp + 1] == 0) InvalidInput();
                            else meziVypocet = cisla[indexOp] % cisla[indexOp + 1];
                            break;
                    }
                    cisla[indexOp] = meziVypocet;
                    cisla.RemoveAt(indexOp + 1);
                    operandy.RemoveAt(indexOp);
                }


                if (cisla.Count > 0 && valid)
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
            if (vysledek < 0) InvalidInput();
            return vysledek;

        }

        private void rovnaseP_Click(object sender, EventArgs e)
        {
            if(valid)
            {
                if(priklad.Length!=0)
                {
                    string pomVys;
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
                    if (radioDec.Checked) pomVys = vypocitaniPrikladuProg(priklad).ToString();
                    //vypočítání pokud 2 soustava
                    else if(radioBin.Checked)
                    {
                        priklad = prevodPrikladuZBinDoDec(priklad);
                        //vypočítání v 10 a převod do 2
                        pomVys = prevodSoustavy(vypocitaniPrikladuProg(priklad), 2);
                        
                    }
                    else if(radioOct.Checked)
                    {
                        priklad = prevodPrikladuZOctDoDec(priklad);
                        //vypočítání v 10 a převod do 8
                        pomVys = prevodSoustavy(vypocitaniPrikladuProg(priklad), 8);
                    }
                    else
                    {
                        priklad = prevodPrikladuZHexDoDec(priklad);
                        //vypočítání v 10 a převod do 16
                        pomVys = vypocitaniPrikladuProg(priklad).ToString("X");
                    }
                    if (valid) textBox1.Text = pomVys;
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
            if (textBox1.Text == "Invalid input") valid = false;
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
                    else InvalidInput();
                } 
                if(kalkPrevod.Visible)
                {
                    int indPrevodZ = comboPrevodZ.SelectedIndex;
                    int indPrevodDo = comboPrevodDo.SelectedIndex;
                    double hodnota = Double.Parse(textBox1.Text);
                    if(indPrevodZ-indPrevodDo<0)
                    {
                        while(indPrevodZ<indPrevodDo)
                            hodnota /= Soustavy[ZvolenaSoustava][++indPrevodZ];
                    }
                    else
                    {
                        while (indPrevodZ > indPrevodDo)
                            hodnota *= Soustavy[ZvolenaSoustava][indPrevodZ--];
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
            if (textBox1.Text.Length!=0&&textBox1.Text[textBox1.Text.Length - 1] == '^') InvalidInput();
            if(valid)
            {
                if (jeGraf)
                {
                    Clear();
                }
                jeGraf = true;

                chart1.ChartAreas.Clear();
                chart1.Series.Clear();
                chart1.DataSource = null;


                priklad += textBox1.Text;
                while (ZavCount > 0)
                {
                    priklad += ")";
                    ZavCount--;
                }
                textBox1.Text = priklad;
                label1.Text = "";

                double bod;
                var data = new List<Tuple<double, double>>();
                for (double x = -30; x <= 30; x += 0.005)
                {
                    x = Math.Round(x, 8);
                    string funkce = priklad;
                    while (funkce.Contains("x"))
                    {
                        int indexOfX = funkce.IndexOf("x");
                        funkce = funkce.Remove(indexOfX, 1);
                        funkce = funkce.Insert(indexOfX, x.ToString());
                    }

                    bod = vypocitaniPrikladu(funkce);
                    if (bod > 100 || bod < -100) valid = false;
                    if (valid) data.Add(Tuple.Create(x, bod));

                    valid = true;
                }

                if (data.Count == 0) InvalidInput();

                if (valid)
                {
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

                }
            }            
            

            jeVysledek = true;
            EqualsFocus();
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
                            hodnota /= Soustavy[ZvolenaSoustava][++indPrevodZ];
                    }
                    else if(indPrevodZ - indPrevodDo > 0)
                    {                       
                        while (indPrevodZ > indPrevodDo)
                            hodnota *= Soustavy[ZvolenaSoustava][indPrevodZ--];
                    }
                }
                labPrevod.Text = hodnota.ToString();
            }            
        }

        //Mocniny
        private void druhaMocnina_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && valid)
            {
                double pom = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                textBox1.Text = (pom *= pom).ToString();
            }            
            EqualsFocus();
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
            EqualsFocus();
        }

        private void druhaMocninaV_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length != 0&&!operandyPole.Contains(textBox1.Text[textBox1.Text.Length - 1])&&valid/* && !jeMocnina*/)
            {
                textBox1.Text += "^2";
                jeMocnina = true;
            }
            else if (priklad.Length!=0&&priklad[priklad.Length - 1] == ')')
            {
                priklad += "^2";
                label1.Text = priklad;
            }
            EqualsFocus();
        }    


        private void libovolnaMocnina_Click(object sender, EventArgs e)
        {            
            if (textBox1.Text.Length != 0 && !operandyPole.Contains(textBox1.Text[textBox1.Text.Length-1])&&valid/*&&!jeMocnina*/)
            {
                textBox1.Text += "^";
                jeMocnina = true;
                valid = false;
            }
            else if (priklad.Length!=0&&priklad[priklad.Length - 1] == ')')
            {
                textBox1.Text = "^";
                jeMocnina = true;
                valid = false;
            }
            EqualsFocus();
        }
        private void mocnina10_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0&&valid)
            {
                textBox1.Text = "10^" + textBox1.Text;
                jeMocnina=true;
            }
            EqualsFocus();
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
            EqualsFocus();
        }

        private void obracenaHodnota_Click(object sender, EventArgs e)
        {
            if (valid && Double.TryParse(textBox1.Text, out double pomVys)&&pomVys!=0)
            {
                textBox1.Text = (1 / pomVys).ToString();
                jeVysledek = true;
            }
            EqualsFocus();
        }
        private void desCarka_Click(object sender, EventArgs e)
        {
            if (valid)
            {
                if (textBox1.Text.Length == 0) textBox1.Text = "0";            
                if (!textBox1.Text.Contains(",") && !jeVysledek) textBox1.Text += (sender as Button).Text;
                else textBox1.Text = "0" + (sender as Button).Text;
            }
            EqualsFocus();
        }

        


        //Form akce

        private void Form1_Load(object sender, EventArgs e)
        {
            kalkZakl.Visible = true;
            kalkVed.Visible = false;
            kalkGraf.Visible = false;
            kalkDate.Visible = false;
            kalkPrevod.Visible = false;
   
            kalkVed.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkProg.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkGraf.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkDate.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkPrevod.Location= new Point(kalkZakl.Location.X, kalkZakl.Location.Y);            
            
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Text = "Základní kalkulačka";
            this.Height = 420;
            this.Width = 210;
            textBox1.Width = 180;
            panel1.Height = this.Height-75;
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
            this.Height = 420;
            this.Width = 210;
            textBox1.Width = 180;
        }

        private void sciCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            textBox1.Visible = true;
            kalkVed.Visible=true;
            this.Text = "Vědecká kalkulačka";
            this.Height = 500;
            this.Width = 500;
            textBox1.Width = kalkVed.Width;
        }
        private void progCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            radioDec.Checked = true;
            enableButtons(2);
            textBox1.Visible = true;
            kalkProg.Visible = true;
            this.Text = "Programátorská kalkulačka";
            textBox1.Width = kalkProg.Width;
            this.Height = 600;
            this.Width = 500;
        }
        private void graphCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            this.Width = 800;
            this.Height = 500;
            textBox1.Visible = true;
            textBox1.Width = 300;
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
        private void SpecialniFunkce_Click(object sender, EventArgs e)
        {
            string textFunkce="";
            switch(Convert.ToInt32((sender as Button).Tag))
            {
                case 0: textFunkce = "root";
                    break;
                case 1: textFunkce = "abs";
                    break;
                case 2: textFunkce = "log";
                    break;
                case 3: textFunkce = "ln";
                    break;
                case 4: textFunkce = "sin";
                    break;
                case 5: textFunkce = "cos";
                    break;
            }

            if (jeMocnina && textBox1.Text[textBox1.Text.Length-1]!='^')
            {
                textBox1.Text = "(" + textBox1.Text + ")";
                jeMocnina = false;
                valid = true;
            }
            if (Double.TryParse(textBox1.Text, out double logPar) && valid)
            {              
                jeLog = true;
                textBox1.Text = $"{textFunkce}({logPar})";
            }
            else if (textBox1.Text == "x")
            {
                jeLog = true;
                textBox1.Text = $"{textFunkce}(x)";       
            }
            else if (valid && textBox1.Text.Length != 0)
            {
                jeLog = true;
                textBox1.Text = $"{textFunkce}({textBox1.Text})";
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
                        if (i - 1 >= 0)
                        {
                            if (priklad[i - 1] == 'n')
                            {
                                priklad = priklad.Insert(pomIndZav -= 2, "(");
                                priklad += ')';
                            }
                            else if (priklad[i - 1] == 'g' || priklad[i - 1] == 's')
                            {
                                priklad = priklad.Insert(pomIndZav -= 3, "(");
                                priklad += ')';
                            }
                            else if (priklad[i - 1] == 't')
                            {
                                priklad = priklad.Insert(pomIndZav -= 4, "(");
                                priklad += ')';
                            }
                        }
                        break;
                    }
                }
                priklad = priklad.Insert(pomIndZav, textFunkce);
                label1.Text = priklad;
            }
        }

        private void TlacitkaPrevody_Click(object sender, EventArgs e)
        {
            string[] titlePrevodu = { "délky", "obsahu", "hmotnosti", "objemu" , "času","energie"};

            PanelHide();
            ClearComboBox();
            textBox1.Visible = true;
            kalkPrevod.Visible = true;
            ZvolenaSoustava = Convert.ToInt32((sender as Button).Tag);
            this.Text = $"Převod {titlePrevodu[ZvolenaSoustava]}";
            foreach(string s in SoustavyText[ZvolenaSoustava])
            { 
                comboPrevodZ.Items.Add(s);
                comboPrevodDo.Items.Add(s);
            }
            comboPrevodZ.SelectedIndex = 0;
            comboPrevodDo.SelectedIndex = 1;
            this.Height = 500;
            this.Width = 500;
        }       
    }
}
