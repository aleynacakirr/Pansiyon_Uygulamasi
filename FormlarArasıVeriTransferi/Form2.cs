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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //farklı bir form üzerinden bu forma bir veri taşımak istiyorsak, öncelikle class seviyesinde bir değişken ya da property tanımlamamız gerekiyor. burada tek bir şart var o da tanımlanan değişken ya da property kesinlikle public olmalı. aksi takdirde bu değişkene ulaşamayız.
        //bu formu açmak istediğimizde bu formdan bir örnek nesne almalıyız. yani bu formu new'lememiz gerekir. bu durumda burada tanımladığımız değişkene ulaşabiliriz.
        public string Adi { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            //property'e set edilen veriyi label'a atarak kullanmış olduk. 
            label2.Text=Adi;
        }
    }
}
