using Pansiyon_Uygulamasi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_Uygulamasi.DataAccessLayer
{
    public class PersonelDal : IRepository<Personel>
    {
        public bool Ekle(Personel entity)
        {
            SqlCommand komut=new SqlCommand("Insert Into Personeller (Adi, Soyadi, KimlikNo, KullanıcıAdi, Sifre, Telefon, Adres) Values(@adi, @soyadi, @kimlikNo, @kullanıcıAdi, @sifre, @telefon, @adres)", Tools.Baglanti);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@kullanıcıAdi", entity.KullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", entity.Sifre);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
            return Tools.ExecuteNonQuery(komut);
            

        }

        public bool Guncelle(Personel entity)
        {
          SqlCommand komut=new SqlCommand("Update Personeller set Adi=@adi, Soyadi=@soyadi, KimlikNo=@kimlikNo, KullanıcıAdi=@kullanıcıAdi, Sifre=@sifre, Telefon=@telefon, Adres=@adres, GuncellemeTarihi=@guncellemeTarihi where Id=@id", Tools.Baglanti);
            komut.Parameters.AddWithValue("@adi", entity.Adi);
            komut.Parameters.AddWithValue("@soyadi", entity.Soyadi);
            komut.Parameters.AddWithValue("@kimlikNo", entity.KimlikNo);
            komut.Parameters.AddWithValue("@kullanıcıAdi", entity.KullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", entity.Sifre);
            komut.Parameters.AddWithValue("@telefon", entity.Telefon);
            komut.Parameters.AddWithValue("@adres", entity.Adres);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);
            komut.Parameters.AddWithValue("@id", entity.Id);
            return Tools.ExecuteNonQuery(komut);
        }

        public DataTable Listele()
        {
            SqlDataAdapter adp=new SqlDataAdapter("PersonelListele", Tools.Baglanti);
            adp.SelectCommand.CommandType= System.Data.CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);
            return dataTable;
        }

        public bool Sil(int ıd)
        {
            SqlCommand komut = new SqlCommand("Delete from Personeller where Id=@id", Tools.Baglanti);
            komut.Parameters.AddWithValue("@id", ıd);
            return Tools.ExecuteNonQuery(komut);
        }
        
    }
    
}
