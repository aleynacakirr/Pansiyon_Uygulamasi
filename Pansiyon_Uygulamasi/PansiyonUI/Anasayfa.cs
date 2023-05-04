using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_Uygulamasi.PansiyonUI
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btnPersoneller_Click(object sender, EventArgs e)
        {
            FormPersonel personel=new FormPersonel();
            personel.MdiParent= this;
            FormGetir(personel);

        }
        private void FormGetir(Form form)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.FormBorderStyle= FormBorderStyle.None;
            form.Show();
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FormMusteriler musteriler=new FormMusteriler(); 
            musteriler.MdiParent= this;
            FormGetir(musteriler);
        }

        private void btnKonaklamalar_Click(object sender, EventArgs e)
        {
            FormKonaklamalar konaklamalar=new FormKonaklamalar();
            konaklamalar.MdiParent= this;
            FormGetir(konaklamalar);
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            FormOda oda=new FormOda();
            oda.MdiParent= this;
            FormGetir(oda);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
