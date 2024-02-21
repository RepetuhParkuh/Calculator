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
        bool jeVysledek = false;

        //Vědecká kalkulačka
        string priklad="";
        int ZavCount=0;        
        bool jeMocnina = false;
        bool valid = true;
        bool jeLog = false;
        char[] operandyPole = { '+', '-', '*', '/', '%', '(' , '^'};

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
            valid = false;
        }

        // Zadávání čísel
        private void cisla_Click(object sender, EventArgs e)
        {
            bool validZadani = true;
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
                if (s == "0") s = "";
                priklad += "(";
                ZavCount++; 
            }
            if (s == ")")
            {
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
                    case 'x':
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
          
                    bool logVPrikladu = false;
                    bool lnVPrikladu = false;
                    bool absVPrikladu = false;

            //Kontrola zavorek v prikladu
            while(prikladS.Contains('('))
            {                
                for(int i = 0;i<prikladS.Length;i++)
                {                    
                    char c = prikladS[i];
                    if (c == 'g'&&!logVPrikladu&&!lnVPrikladu && !absVPrikladu)
                    {
                        logVPrikladu = true;
                        prikladS=prikladS.Remove(i - 2,3);
                        i -= 3;
                    }                    
                    if(c=='n'&&!logVPrikladu&&!lnVPrikladu&&!absVPrikladu)
                    {
                        lnVPrikladu=true;
                        prikladS=prikladS.Remove(i - 1, 2);
                        i-= 2;
                    }
                    if(c=='s'&& !logVPrikladu && !lnVPrikladu && !absVPrikladu)
                    {
                        absVPrikladu = true;
                        prikladS = prikladS.Remove(i - 2, 3);
                        i -= 3;
                    }
                    

                    if(c == '(')
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
                            podPriklad=prikladS.Substring(indexZacZav+1,i-indexZacZav-1);
                            //Odstraneni podprikladu z hlavniho prikladu
                            prikladS = prikladS.Remove(indexZacZav, i - indexZacZav+1);
                            //Vlozeni vysledku z podprikladu                            
                            double pomVys = vypocitaniPrikladu(podPriklad);
                            MessageBox.Show(pomVys.ToString());
                            if(logVPrikladu)
                            {
                                if (pomVys >= 0)
                                {
                                    pomVys = Math.Log10(pomVys);                                    
                                    logVPrikladu = false;
                                }
                                else invalidInput();
                            }
                            if(lnVPrikladu)
                            {
                                if (pomVys >= 0)
                                {
                                    pomVys = Math.Log(pomVys);          
                                    lnVPrikladu=false;
                                }
                                else invalidInput();
                            }   
                            if(absVPrikladu)
                            {
                                pomVys=Math.Abs(pomVys);
                                absVPrikladu = false;
                            }
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
                    if ((c >= '0' && c <= '9')||(znam&&c=='-')||c==',')
                    {                    
                        cislo += c;
                        znam = false;                        
                    }
                    
                    else if (c == '+' || c == '-' || c == 'x' || c == '/' || c == '%'||c=='^')
                    {                  
                  
                         if(cislo!="")
                        {                           
                            cisla.Add(Convert.ToDouble(cislo));
                        }
                        cislo = "";
                        operandy.Add(c);
                        znam = true;
                    }                    
                        
            }




            
            if(cislo!="") cisla.Add(Convert.ToDouble(cislo));
        
            if(!double.TryParse(prikladS,out vysledek))
            {                
                //Určování a počítání priority operací             
                          
                if (prikladS.Contains("^"))
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


                if(prikladS.Contains("x")||prikladS.Contains("/")||prikladS.Contains("%"))
                {
                    double meziVypocet = 0;
                    int diff = 0;
                    for (int i = 0; i < operandy.Count; i++)
                    {
                        if (operandy[i] == 'x' || operandy[i] == '/' || operandy[i] == '%')
                        {
                            switch (operandy[i])
                            {
                                case 'x':
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

                
                if(cisla.Count>0)
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
                if ((sender as Button).Name == "btnMod")
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
                    label1.Text += textBox1.Text;                
                    double vysledek=vypocitaniPrikladu(priklad);
                    label1.Text += "=";
                    textBox1.Text = vysledek.ToString();
                    listBox1.Items.Add(vysledek);
                    priklad = "";
                    jeVysledek = true;
                }
            }
        }


        //Programátorská kalkulačka

        private string prevodSoustavy(long cislo,int soustava)
        {
            string vys = "";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && valid&&kalkProg.Visible)
            {
                if (Int64.TryParse(textBox1.Text, out long hodnota)&&radioDec.Checked)
                {
                    labelDec.Text = hodnota.ToString();
                    labelBin.Text = prevodSoustavy(hodnota,2);
                    labelOct.Text = prevodSoustavy(hodnota, 8);
                    labelHex.Text = hodnota.ToString("X");
                }
                else if(radioBin.Checked)
                {
                    labelBin.Text = textBox1.Text;
                    long dec = prevodSoustavy(textBox1.Text, 2);
                    labelDec.Text = dec.ToString();
                    labelOct.Text = prevodSoustavy(dec, 8);
                    labelHex.Text = dec.ToString("X");
                }
                else if(radioOct.Checked)
                {
                    labelOct.Text = textBox1.Text;
                    long dec = prevodSoustavy(textBox1.Text, 8);
                    labelDec.Text = dec.ToString();
                    labelBin.Text = prevodSoustavy(dec, 2);
                    labelHex.Text = dec.ToString("X");
                }
                else if(radioHex.Checked)
                {
                    labelHex.Text = textBox1.Text;
                    long dec=Convert.ToInt64(textBox1.Text,16);
                    labelDec.Text = dec.ToString();
                    labelBin.Text = prevodSoustavy(dec, 2);
                    labelOct.Text = prevodSoustavy(dec, 8);
                }
                else invalidInput();
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
            if (radioBin.Checked)
            {
                enableButtons(4);
                textBox1.Text = labelBin.Text;
            }
            else if (radioOct.Checked)
            {
                enableButtons(3);
                textBox1.Text = labelOct.Text;
            }
            else if (radioDec.Checked)
            {
                enableButtons(2);
                textBox1.Text = labelDec.Text;
            }
            else if (radioHex.Checked)
            {
                enableButtons(1);
                textBox1.Text=labelHex.Text;
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
            
            if (textBox1.Text.Length != 0&&!operandyPole.Contains(textBox1.Text[textBox1.Text.Length - 1])&&valid)
            {
                textBox1.Text += "^2";
                jeMocnina = true;
            }
            rovnaseFocus();
        }


        private void libovolnaMocnina_Click(object sender, EventArgs e)
        {            
            if (textBox1.Text.Length != 0 && !operandyPole.Contains(textBox1.Text[textBox1.Text.Length-1])&&valid)
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
            kalkZakl.Visible = true;
            kalkVed.Visible = false;
                this.Height=500;
                this.Width=500;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;

            kalkVed.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);
            kalkProg.Location = new Point(kalkZakl.Location.X, kalkZakl.Location.Y);     
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

        private void progCalc_Click(object sender, EventArgs e)
        {
            PanelHide();
            enableButtons(2);
            kalkProg.Visible = true;
        }

        //Clear funkce
        private void backspace_Click(object sender, EventArgs e)
        {
            if (!valid) textBox1.Text = "0";
            else
            {
                /*if (textBox1.Text[textBox1.Text.Length - 1] == '(') ZavCount--;
                if (textBox1.Text[textBox1.Text.Length - 1] == ')') ZavCount++;*/
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

        

        private void Clear()
        {
            ZavCount = 0;
            textBox1.Clear();
            label1.Text = "";
            cislo = 0;
            listBox1.Items.Clear();
            textBox1.Text = "0";
            rovnaseFocus();
            priklad = "";
        }

    }
}
