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
    public partial class FormMusteriler : Form
    {
        MusteriDal musteriDal =new MusteriDal();
        public FormMusteriler()
        {
            InitializeComponent();
        }
        private void FormTemizle ()
        {
            tbxId.Clear();
            tbxAdi.Clear();
            tbxAdres.Clear();
            tbxSoyadi.Clear();
            tbxEmail.Clear();
            tbxTc.Clear();
            mtbxTelefon.Clear();
            rbErkek.Checked = false;
            rbKadin.Checked=false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            dataGridView1.DataSource= musteriDal.Listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxTc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString()=="Kadın")
            {
                rbKadin.Checked = true;
            }
            else
            {
                rbErkek.Checked = true;
            }
            mtbxTelefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxAdres.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteri musteri =new Musteri();

                musteri.Adi = tbxAdi.Text;
                musteri.Soyadi = tbxSoyadi.Text;
                musteri.KimlikNo=tbxTc.Text;
                musteri.Adres=tbxAdres.Text;
                musteri.Email=tbxEmail.Text;
                musteri.Telefon=mtbxTelefon.Text;
                if(rbErkek.Checked)
            {
                musteri.Cinsiyet="Erkek";
            }
                else
                musteri.Cinsiyet = "Kadın";

            if (musteriDal.Ekle(musteri))
            {
                MessageBox.Show("Kayıt başarılı");
                FormTemizle();
                Listele();
            }
            else
            {
                MessageBox.Show("Kayıt başarısız");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tbxId.Text!=string.Empty)
            {
                Musteri musteri=new Musteri();
                musteri.Id=Convert.ToInt32( tbxId.Text);
                musteri.Adi = tbxAdi.Text;
                musteri.Soyadi = tbxSoyadi.Text;
                musteri.KimlikNo = tbxTc.Text;
                musteri.Adres = tbxAdres.Text;
                musteri.Email = tbxEmail.Text;
                musteri.Telefon = mtbxTelefon.Text;
                musteri.GuncellemeTarihi=DateTime.Now;
                if (rbErkek.Checked)
                {
                    musteri.Cinsiyet = "Erkek";
                }
                else
                    musteri.Cinsiyet = "Kadın";
                if (musteriDal.Guncelle(musteri))
                {
                    MessageBox.Show("Güncelleme tamamlandı.");
                }
                else
                    MessageBox.Show("Güncellenemedi");
            }
            else
                MessageBox.Show("Güncellemek istediğiniz kaydı seçiniz");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek=MessageBox.Show("Seçili kaydı silmek istiyor musunuz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (secenek==DialogResult.Yes)
            {
                DialogResult secenek2 = MessageBox.Show("Emin misin?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek2==DialogResult.Yes)
                {
                    DialogResult secenek3 = MessageBox.Show("Son kararın mı?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek3 == DialogResult.Yes)
                    {
                        if (musteriDal.Sil(Convert.ToInt32(tbxId.Text)))
                        {
                            MessageBox.Show("Kayıt silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt silinemedi");
                        }
                    }
                }
                
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnKonaklamaEkle_Click(object sender, EventArgs e)
        {
            FormKonaklamalar konaklama=new FormKonaklamalar();
            konaklama.MusteriAdiSoyadi=tbxAdi.Text+"\n"+tbxSoyadi.Text;
            konaklama.MusteriId=tbxId.Text;
            konaklama.ShowDialog();
        }
    }
}
