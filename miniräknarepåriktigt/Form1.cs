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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }
        public bool finnsKomma = false;
        public double Tal = 0;
        public double NyttTal = 0;
        string operation = "";
        public bool första = true;
        
        

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
        private void KnappDelete_Click(object sender, EventArgs e)
        {
            
        }
        private void KnappDelatMedX_Click(object sender, EventArgs e)
        {
            MinTextbox.Text =  (1/double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappRotenUr_Click(object sender, EventArgs e)
        {
            MinTextbox.Text = Math.Sqrt(double.Parse(MinTextbox.Text)).ToString();
        }
        private void KnappProcent_Click(object sender, EventArgs e)
        {
            MinTextbox.Text = (double.Parse(MinTextbox.Text) / 100).ToString();   
        }
        private void KnappPlus_Click(object sender, EventArgs e)
        {
            Button plus = (Button)sender;
            Tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "+";
        }

        private void KnappMinus_Click(object sender, EventArgs e)
        {
            Button minus = (Button)sender;
            Tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "-";
        }

        private void KnappGånger_Click(object sender, EventArgs e)
        {
            Button gånger = (Button)sender;
            Tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "*";
        }
        private void KnappDelatMed_Click(object sender, EventArgs e)
        {
            Button delatMed = (Button)sender;
            Tal = double.Parse(MinTextbox.Text);
            MinTextbox.Clear();
            operation = "/";

        }

        private void MinTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }



       
        public void KnappLikaMed_Click(object sender, EventArgs e)
        {
            if(första == true) 
            {
            NyttTal = double.Parse(MinTextbox.Text);
                första = false;
            }
            switch (operation)
            {
                case "+":
                    MinTextbox.Text = (Tal + NyttTal).ToString();
                    Tal = Tal + NyttTal;
                    break;
                case "/":
                    
                        MinTextbox.Text = (Tal / NyttTal).ToString();
                        Tal = Tal / NyttTal;
                        break;
                case "-":
                    MinTextbox.Text = (Tal - NyttTal).ToString();
                    Tal = Tal - NyttTal;
                    break;
                case "*":
                    MinTextbox.Text = (Tal * NyttTal).ToString();
                    Tal = Tal * NyttTal;
                    break;

            }

        }

        
    }
}
