using Pansiyon_Uygulamasi.DataAccessLayer;
using Pansiyon_Uygulamasi.EntityLayer.Entities;
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
    public partial class FormPersonel : Form
    {
        PersonelDal db =new PersonelDal();
        public FormPersonel()
        {
            InitializeComponent();
        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {
            Listele();
                
        }
        private void Listele()
        {
            dataGridView1.DataSource= db.Listele();
        }

        

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Personel personel=new Personel()
            {
                Adi=tbxAdi.Text,
                Soyadi=tbxSoyadi.Text,
                KimlikNo=tbxTc.Text,
                KullaniciAdi=tbxKullaniciAdi.Text,
                Sifre=tbxSifre.Text,
                Telefon=tbxTelefon.Text,
                Adres=tbxAdres.Text
            };
            if(db.Ekle(personel))
            {
                MessageBox.Show("Kayıt Başarılı");
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız");
            }
            
            Listele();
        }
        private void FormuTemizle()
        {
            tbxAdi.Clear();
            tbxAdres.Clear();
            tbxSoyadi.Clear();
            tbxTc.Clear();
            tbxTelefon.Clear();
            tbxKullaniciAdi.Clear();
            tbxSifre.Clear();
            tbxId.Clear();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxTelefon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxAdres.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tbxKullaniciAdi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxSifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tbxId.Text!= null && tbxId.Text!=string.Empty)
            {
                Personel personel = new Personel()
                {
                    Id=Convert.ToInt32(tbxId.Text),
                    Adi = tbxAdi.Text,
                    Soyadi = tbxSoyadi.Text,
                    KimlikNo = tbxTc.Text,
                    KullaniciAdi = tbxKullaniciAdi.Text,
                    Sifre = tbxSifre.Text,
                    Telefon = tbxTelefon.Text,
                    Adres = tbxAdres.Text,
                    GuncellemeTarihi=DateTime.Now
                };
                if (db.Guncelle(personel))
                {
                    MessageBox.Show($"{personel.Id} nolu veri güncellendi");
                }
                else 
                {
                    MessageBox.Show($"{personel.Id} nolu veri güncellenemedi");
                }
                FormuTemizle();
                Listele();
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için kayıt seçiniz!");
            }
            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek= MessageBox.Show("Seçili kaydı silmek istiyor musunuz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                if (tbxId.Text!=string.Empty)
                {
                    if (db.Sil(Convert.ToInt32(tbxId.Text)))
                    {
                        MessageBox.Show("Kayıt silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinemedi");
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemi için bir kayıt seçiniz");
                }
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi");
            }

        }
    }
}
