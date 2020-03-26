using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniräknarepåriktigt
{
    public partial class WiggosKalkylator : Form
    {
        public WiggosKalkylator()
        {
            InitializeComponent();
            

            
        }
        public bool finnsKommatecken = false;
        public double tal = 0;
        public double nyttTal = 0;
        public double resultat = 0;
        public string operation = "ingen";
        public bool första = true;
        public string senasteOperation = "";
 


       
        

        private void press(object sender, EventArgs e) //gör att om man trycker på en siffra så skrivs siffran ut i textboxen
        {
            Button knapp = (Button)sender;
            if (MinTextbox.Text == "0" && sender == KnappNoll)//man kan inte spamma nollor i början
            {

            }
            else
            MinTextbox.Text += knapp.Text;
        }

        private void KnappKommatecken_Click(object sender, EventArgs e)
        {
            
            Button komma = (Button)sender;

            if (sender == komma && finnsKommatecken == false)
            {
                if(MinTextbox.Text == "")
                {
                    MinTextbox.Text += "0,";
                    finnsKommatecken = true;
                }
                else
                {
                MinTextbox.Text += ",";
                finnsKommatecken = true;
                }

                

            }
            


        }

        private void KnappClearEntry_Click(object sender, EventArgs e)
        {
            MinTextbox.Clear();
            finnsKommatecken = false;
        }
        private void KnappClear_Click(object sender, EventArgs e)//nollställer hela miniräknaren
        {
            MinTextbox.Clear();
            tal = 0;
            nyttTal = 0;
            operation = "ingen";
            finnsKommatecken = false;
        }
        private void KnappDelete_Click(object sender, EventArgs e)
        {
 
            if (MinTextbox.TextLength > 0)
            {
                MinTextbox.Text = MinTextbox.Text.Substring(0, (MinTextbox.TextLength - 1));//tar bort sista siffran i talet
            }
        }
        private void KnappDelatMedX_Click(object sender, EventArgs e)
        {
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            MinTextbox.Text =  (1/double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappRotenUr_Click(object sender, EventArgs e)
        {
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            MinTextbox.Text = Math.Sqrt(double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappPlusMinus_Click(object sender, EventArgs e)
        {
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            MinTextbox.Text = (double.Parse(MinTextbox.Text) * -1).ToString();
        }
        private void KnappProcent_Click(object sender, EventArgs e)
        {
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            MinTextbox.Text = (double.Parse(MinTextbox.Text) / 100).ToString();   
        }
        private void KnappPlus_Click(object sender, EventArgs e)//sparar talet som står i textboxen för att sedan addera med ett annat
        {
            Button plus = (Button)sender;
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "+";
            finnsKommatecken = false;
        }

        private void KnappMinus_Click(object sender, EventArgs e)//sparar talet som står i textboxen för att sedan subtrahera ett annat från det
        {
            Button minus = (Button)sender;
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "-";
            finnsKommatecken = false;
        }

        private void KnappGånger_Click(object sender, EventArgs e)//sparar talet som står i textboxen för att sedan multiplicera med ett annat
        {
            Button gånger = (Button)sender;
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "*";
            finnsKommatecken = false;
        }
        private void KnappDelatMed_Click(object sender, EventArgs e)//sparar talet som står i textboxen för att sedan dividera med ett annat
        {
            Button delatMed = (Button)sender;
            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "/";
            finnsKommatecken = false;

        }

        



       
        public void KnappLikaMed_Click(object sender, EventArgs e)//gör operarationen
        {

            if (MinTextbox.Text == "")
                MinTextbox.Text = "0";
           
            if(operation != "ingen")
            {
                
                if (första == true)
                {
                    
                    nyttTal = double.Parse(MinTextbox.Text);

                    första = false;
                }
                switch (operation)//operation med det nya talet (första gången man trycker lika med)
                {
                case "+":
                    resultat = tal + nyttTal;
                    MinTextbox.Text = (resultat).ToString();
                    tal =  tal + nyttTal;
                    första = true;
                        senasteOperation = operation;
                        operation = "ingen";

                        break;
                case "/":
                    MinTextbox.Text = (tal / nyttTal).ToString();
                    tal = tal / nyttTal;
                    första = true;
                        senasteOperation = operation;
                        operation = "ingen";
                    break;
                case "-":
                    MinTextbox.Text = (tal - nyttTal).ToString();
                    tal = tal - nyttTal;
                    första = true;
                        senasteOperation = operation;
                        operation = "ingen";
                    break;
                case "*":
                    MinTextbox.Text = (tal * nyttTal).ToString();
                    tal = tal * nyttTal;
                    första = true;
                        senasteOperation = operation;
                        operation = "ingen";
                    break;

            }
            }
            else {
               
               

                switch (senasteOperation)//gör operationen om det är andra eller mer gången man trycker lika med i rad
            {
                case "+":

                        MinTextbox.Text = ((double.Parse(MinTextbox.Text)) + nyttTal).ToString();
                        //Tal =  Tal + NyttTal;


                        break;
                case "/":
                        MinTextbox.Text = ((double.Parse(MinTextbox.Text)) / nyttTal).ToString();
                        tal = tal / nyttTal;
                    
                    
                    break;
                case "-":
                        MinTextbox.Text = ((double.Parse(MinTextbox.Text)) - nyttTal).ToString();
                        tal = tal - nyttTal;
                    
                    
                    break;
                case "*":
                        MinTextbox.Text = ((double.Parse(MinTextbox.Text)) * nyttTal).ToString();
                    //Tal = Tal * NyttTal                    
                    break;
            }
            }

        }

        
    }
}
