using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_Uygulamasi.DataAccessLayer
{
    public class KullaniciKontrolDal
    {
        public bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
            SqlCommand command=new SqlCommand("Select * from Personeller where KullanıcıAdi=@kullanıcıAdi and Sifre=@sifre",Tools.Baglanti);
            command.Parameters.AddWithValue("@kullanıcıAdi",kullaniciAdi);
            command.Parameters.AddWithValue("@sifre",sifre);
            return Tools.ExecuteReader(command);
        }
    }
}
