using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinamikButonlar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int pozisyonx = 50, pozisyony = 50;
            int satır=1;
            for (int i = 0; i < 15; i++)
            {
                Button button = new Button();
                button.Height = 50;
                button.Width = 100;
                button.Text = "buton text";

                button.Location = new Point(pozisyonx, pozisyony);
                this.Controls.Add(button);
                pozisyonx+= 100;
                if (satır<5)
                {
                    pozisyonx+=100;
                    satır++;
                }
                else
                {
                    pozisyonx=50;
                    pozisyony+=75;
                    satır=1;
                }
            }
            

        }
    }
}
