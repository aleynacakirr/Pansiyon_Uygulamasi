using Pansiyon_Uygulamasi.DataAccessLayer;
using Pansiyon_Uygulamasi.EntityLayer.Entities;
using Pansiyon_Uygulamasi.PansiyonUI.Araçlar;
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
    public partial class FormKonaklamalar : Form
    {
        KonaklamaDal konaklamaDal =new KonaklamaDal();
        public FormKonaklamalar()
        {
            InitializeComponent();
        }
        public string MusteriId { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        Oda oda;
        private void FormKonaklamalar_Load(object sender, EventArgs e)
        {
            tbxAdiSoyadi.Text = MusteriAdiSoyadi;
            tbxId.Text = MusteriId;
            Listele();
            OdaSec();
        }
        private void OdaSec()
        {
            OdaDal odaDal =new OdaDal();
            int pozisyonx=30, pozisyony=30, satır=1;
            for (int i = 0; i < odaDal.OdaListele().Count; i++)
            {
                MyButton myButton=new MyButton();
                myButton.oda = odaDal.OdaListele()[i];
                myButton.Location=new Point(pozisyonx,pozisyony);
                myButton.Width=50;
                myButton.Height=50;
                myButton.Text = odaDal.OdaListele()[i].OdaNo;
                myButton.Name = odaDal.OdaListele()[i].Id.ToString();
                //o anki buton nesnesinin click eventini aşağıdaki satırda olduğu gibi çağırabiliriz. parantez içerisindeki (SeciliButon) bu event için çalışacak olan metodun adıdır.
                myButton.Click+=new EventHandler(SeciliButon);
                groupBoxOdalar.Controls.Add(myButton);
                if (odaDal.OdaListele()[i].MusaitMi)
                {
                    myButton.BackColor=Color.Green;
                }
                else
                {
                    myButton.BackColor= Color.Red;
                    myButton.Enabled= false;
                }
                if (satır<4)
                {
                    pozisyonx+=75;
                    satır++;
                }
                else
                {
                    pozisyonx=30;
                    pozisyony+=75;
                    satır=1;
                }
            }
        }

        //yukarıda tanımladığımız MyButton nesnelerinin click eventi olarak çlışacak metottur.
        private void SeciliButon(object sender, EventArgs eventArgs)
        {
            MyButton dinamikButon=(sender as MyButton); //(MyButton) sender; olarak da çalışır.
            tbxOdaNO.Text= dinamikButon.oda.OdaNo;
            tbxOdaId.Text=dinamikButon.oda.Id.ToString();
            tbxOdaFiyati.Text=dinamikButon.oda.OdaFiyati.ToString();
            oda=dinamikButon.oda;
        }
        private void ToplamFiyatHesapla()
        {
            if (tbxOdaFiyati.Text!=string.Empty && dtpGirisTarihi.Text !=dtpCikisTarihi.Text)
            {
                TimeSpan gunSayisi;
                gunSayisi =DateTime.Parse(dtpCikisTarihi.Text)-DateTime.Parse(dtpGirisTarihi.Text);
                tbxToplamFiyat.Text=(gunSayisi.TotalDays * Convert.ToDouble( tbxOdaFiyati.Text)).ToString();
            }
        }

        private void Listele()
        {
          dataGridView1.DataSource=konaklamaDal.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Konaklama konaklama=new Konaklama()
            {
                MusteriId=Convert.ToInt32( MusteriId),
                OdaId=Convert.ToInt32(tbxOdaId.Text),
                ToplamFiyat=Convert.ToDouble(tbxToplamFiyat.Text),
                GirisTarihi=Convert.ToDateTime(dtpGirisTarihi.Text),
                CikisTarihi=Convert.ToDateTime(dtpCikisTarihi.Text),
                AktifMi=cbxDurum.Checked,
                GuncellemeTarihi=DateTime.Now
            };
            oda.MusaitMi=false;
            oda.GuncellemeTarihi=DateTime.Now;
            OdaDal odaDal=new OdaDal(); 

            if (konaklamaDal.Ekle(konaklama) && odaDal.Guncelle(oda))
            {
                MessageBox.Show("Kayıt eklendi");
                Listele();
                FormTemizle();
                groupBoxOdalar.Controls.Clear();
                OdaSec();
            }
            else
            {
                MessageBox.Show("Kayıt başarısız");
            }
        }

        private void FormTemizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text="";
                }
                else if (item is DateTimePicker)
                {
                    item.Text=DateTime.Now.ToString();
                }
                cbxDurum.Checked= false;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (tbxId.Text!=string.Empty)
            {
                if(konaklamaDal.Sil(Convert.ToInt32(tbxId.Text)))
                {
                    Listele();
                    FormTemizle();
                }
                else
                {
                    MessageBox.Show("Oda durumunu kontrol ediniz");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz.");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }

        private void groupBoxOdalar_Enter(object sender, EventArgs e)
        {
            OdaSec();
        }

        private void tbxOdaFiyati_TextChanged(object sender, EventArgs e)
        {
            ToplamFiyatHesapla();
        }

        private void dtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {
            ToplamFiyatHesapla();
        }

        private void dtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            ToplamFiyatHesapla() ;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //konaklama verileri güncellenecek
            //eğer durum değişirse oda verisi de güncellenmeli.
            Konaklama konaklama=new Konaklama()
            {
                Id=Convert.ToInt32(tbxId.Text),
                MusteriId=Convert.ToInt32(this.MusteriId),
                OdaId=Convert.ToInt32(tbxOdaId.Text),
                ToplamFiyat=Convert.ToDouble(tbxToplamFiyat.Text),
                GirisTarihi=dtpGirisTarihi.Value,
                CikisTarihi=dtpCikisTarihi.Value,
                AktifMi=cbxDurum.Checked,
                GuncellemeTarihi=DateTime.Now
            };
            if (konaklamaDal.Guncelle(konaklama))
            {
                if (konaklama.AktifMi==false)
                {
                    OdaDal odaDal =new OdaDal();
                    if (oda==null)
                    {
                        oda=new Oda();
                        oda.Id=konaklama.OdaId;
                    }
                    oda.MusaitMi=true;
                    if (odaDal.DurumGuncelle(oda))
                    {
                        MessageBox.Show("Oda Güncellendi");
                    }

                }
                MessageBox.Show("Güncelleme işlemi tamamlandı");
                Listele();
                FormTemizle();
                groupBoxOdalar.Controls.Clear();
                OdaSec();
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi yapılamadı.");
            }
    
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxAdiSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            MusteriId= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxOdaId.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxOdaNO.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxOdaFiyati.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxToplamFiyat.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dtpGirisTarihi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dtpCikisTarihi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cbxDurum.Checked = Convert.ToBoolean( dataGridView1.CurrentRow.Cells[9].Value);
        }
    }
}
