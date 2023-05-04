using Pansiyon_Uygulamasi.DataAccessLayer;
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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            KullaniciKontrolDal kullaniciKontrolDal=new KullaniciKontrolDal();
            if (kullaniciKontrolDal.KullaniciKontrol(tbxKullaniciAdi.Text,tbxSifre.Text))
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı"+"\n"+"Lütfen tekrar deneyiniz.","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tbxKullaniciAdi.Clear();
                tbxSifre.Clear();
            }
            
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
