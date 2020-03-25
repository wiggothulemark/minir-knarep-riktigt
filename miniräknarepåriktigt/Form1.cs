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
        public bool finnsKomma = false;
        public double tal = 0;
        public double nyttTal = 0;
        public double resultat = 0;
        public string operation = "ingen";
        public bool första = true;
        public string senasteOperation = "";
        

       
        

        private void press(object sender, EventArgs e)
        {
            Button knapp = (Button)sender;
            MinTextbox.Text += knapp.Text;
        }

        private void KnappKommatecken_Click(object sender, EventArgs e)
        {
            
            Button komma = (Button)sender;

            if (sender == komma && finnsKomma == false)
            {
                if(MinTextbox.Text == "")
                {
                    MinTextbox.Text += "0,";
                    finnsKomma = true;
                }
                else
                {
                MinTextbox.Text += ",";
                finnsKomma = true;
                }

                

            }
            


        }

        private void KnappClearEntry_Click(object sender, EventArgs e)
        {
            MinTextbox.Clear();
        }
        private void KnappClear_Click(object sender, EventArgs e)
        {
            MinTextbox.Clear();
            tal = 0;
            nyttTal = 0;
            operation = "ingen";
        }
        private void KnappDelete_Click(object sender, EventArgs e)
        {
 
            if (MinTextbox.TextLength > 0)
            {
                MinTextbox.Text = MinTextbox.Text.Substring(0, (MinTextbox.TextLength - 1));
            }
        }
        private void KnappDelatMedX_Click(object sender, EventArgs e)
        {
            MinTextbox.Text =  (1/double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappRotenUr_Click(object sender, EventArgs e)
        {
            MinTextbox.Text = Math.Sqrt(double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappPlusMinus_Click(object sender, EventArgs e)
        {
            MinTextbox.Text = (double.Parse(MinTextbox.Text) * -1).ToString();
        }
        private void KnappProcent_Click(object sender, EventArgs e)
        {
            MinTextbox.Text = (double.Parse(MinTextbox.Text) / 100).ToString();   
        }
        private void KnappPlus_Click(object sender, EventArgs e)
        {
            Button plus = (Button)sender;
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "+";
            
        }

        private void KnappMinus_Click(object sender, EventArgs e)
        {
            Button minus = (Button)sender;
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "-";
        }

        private void KnappGånger_Click(object sender, EventArgs e)
        {
            Button gånger = (Button)sender;
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "*";
        }
        private void KnappDelatMed_Click(object sender, EventArgs e)
        {
            Button delatMed = (Button)sender;
            tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "/";

        }

        private void MinTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }



       
        public void KnappLikaMed_Click(object sender, EventArgs e)
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
                switch (operation)
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
               
                //NyttTal = double.Parse(MinTextbox.Text);

                switch (senasteOperation)
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
