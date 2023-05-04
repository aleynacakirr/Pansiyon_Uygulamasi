using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormlarArasıVeriTransferi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           //bir form içerisinden (form1) başka bir form (form2) açmak istediğimizde öncelikle açmak istediğimiz formdan (form2) bir nesne oluşturmamız gerekecek.
           Form2 form2=new Form2();
            //form2.Show(); //show ile ilgili formu istediğimiz sayıda açabiliyoruz. 
            form2.BackColor = Color.DarkRed;
            form2.Adi=textBox1.Text;
            form2.ShowDialog(); //bu şekilde yalnızca bir tane açabiliriz. ikinci defa açmak istediğimizde açılan formu kapatmamız gerekir.
            
            

        }
    }
}
