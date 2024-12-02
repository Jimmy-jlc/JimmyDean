using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            

            label1.Text = trackBar1.Value.ToString();

            switch (trackBar1.Value)
            {
                case 0: { label1.Text ="Lives = 0";
                       
                        break;
                    }
                                                                                                             
                case 1: { label1.Text ="Lives = 1";
                        
                        break;
                    }

                case 2: { label1.Text ="Lives = 11";
                        
                        break;
                    }

                case 3: {
                        label1.Text = "Lives = 30";
                        
                            break;
                    }

                case 4: { label1.Text ="Lives = infinite";
                        
                        break;
                    }

            }
                    
                     
                    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show();
            this.Enabled = false;

        }


    }
}
