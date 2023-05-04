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
    public partial class FormOda : Form
    {
        OdaDal odaDal=new OdaDal();
        public FormOda()
        {
            InitializeComponent();
        }

        private void FormOda_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = odaDal.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           Oda oda=new Oda();
           
               oda.OdaNo=tbxOdaNo.Text;
               oda.OdaFiyati=Convert.ToDouble( tbxOdaFiyatı.Text);
            if (cbMusaitMi.Text=="Evet")
            {
                oda.MusaitMi= true;
            }
            else
            { oda.MusaitMi= false; }
            if (cbAktifMi.Text=="Evet")
            {
                oda.AktifMi=true;
            }
            else
            { oda.AktifMi = false; }

            if (odaDal.Ekle(oda))
            {
                MessageBox.Show("Kayıt Başarılı");
                Listele();
            }
            else
                MessageBox.Show("Kayıt gerçekleştirilemedi :(");

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tbxId.Text!=string.Empty)
            {
                Oda oda = new Oda();
                oda.Id = Convert.ToInt32(tbxId.Text);
                oda.OdaNo = tbxOdaNo.Text;
                oda.OdaFiyati = Convert.ToDouble(tbxOdaFiyatı.Text);
                oda.GuncellemeTarihi=DateTime.Now;
                if (cbMusaitMi.Text == "Evet")
                {
                    oda.MusaitMi = true;
                }
                else
                { oda.MusaitMi = false; }
                if (cbAktifMi.Text == "Evet")
                {
                    oda.AktifMi = true;
                }
                else
                { oda.AktifMi = false; }
                if(odaDal.Guncelle(oda))
                {
                    MessageBox.Show("Güncellendi");
                }
                else
                    MessageBox.Show("Güncellenirken hata oluştu.");
            }
            else
                MessageBox.Show("Güncellemek istediğiniz veriyi giriniz.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxOdaNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxOdaFiyatı.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value))
            {
                cbAktifMi.Text="Evet";
            }
            else
            {
                cbAktifMi.Text = "Hayır";
            }
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value))
            {
                cbMusaitMi.Text = "Evet";
            }
            else
            {
                cbMusaitMi.Text = "Hayır";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçili kaydı silmek istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {

                if (odaDal.Sil(Convert.ToInt32(tbxId.Text)))
                {
                    MessageBox.Show("Kayıt silindi.");
                }
                else
                {
                    MessageBox.Show("Kayıt silinemedi");
                }
            }
            
            
        }
        private void Temizle()
        {
            tbxId.Clear();
            tbxOdaFiyatı.Clear();
            tbxOdaNo.Clear();
            cbAktifMi.Items.Clear();
            cbAktifMi.Items.Clear();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
