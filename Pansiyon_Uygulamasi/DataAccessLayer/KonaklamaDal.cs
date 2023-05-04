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
    public class KonaklamaDal : IRepository<Konaklama>
    {
        public bool Ekle(Konaklama entity)
        {
            SqlCommand komut=new SqlCommand("Insert Into Konaklamalar(MusteriId,OdaId,ToplamFiyat,GirisTarihi,CikisTarihi,AktifMi) values (@musteriId,@odaId,@toplamFiyat,@girisTarihi,@cikisTarihi,@aktifMi)", Tools.Baglanti);
            komut.Parameters.AddWithValue("@musteriId", entity.MusteriId);
            komut.Parameters.AddWithValue("@odaId", entity.OdaId);
            komut.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
            komut.Parameters.AddWithValue("@girisTarihi", entity.GirisTarihi);
            komut.Parameters.AddWithValue("@cikisTarihi", entity.CikisTarihi);
            komut.Parameters.AddWithValue("@aktifMi", entity.AktifMi);
            return Tools.ExecuteNonQuery(komut);

        }

        public bool Guncelle(Konaklama entity)
        {
            SqlCommand komut = new SqlCommand("Update Konaklamalar set MusteriId=@musteriId,OdaId=@odaId,ToplamFiyat=@toplamFiyat,GirisTarihi=@girisTarihi,CikisTarihi=@cikisTarihi,AktifMi=@aktifMi, GuncellemeTarihi=@guncellemeTarihi where Id=@id", Tools.Baglanti);
            komut.Parameters.AddWithValue("@musteriId", entity.MusteriId);
            komut.Parameters.AddWithValue("@odaId", entity.OdaId);
            komut.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
            komut.Parameters.AddWithValue("@girisTarihi", entity.GirisTarihi);
            komut.Parameters.AddWithValue("@cikisTarihi", entity.CikisTarihi);
            komut.Parameters.AddWithValue("@aktifMi", entity.AktifMi);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);
            return Tools.ExecuteNonQuery(komut);
        }

        public DataTable Listele()
        {
            SqlDataAdapter adapter=new SqlDataAdapter("KonaklamaListele",Tools.Baglanti);
            adapter.SelectCommand.CommandType= CommandType.StoredProcedure;
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            return dt;

        }

        public bool Sil(int ıd)
        {
            SqlCommand komut=new SqlCommand("Delete from Konaklamalar where Id=@ıd and AktifMi=@aktifMi",Tools.Baglanti);
            komut.Parameters.AddWithValue("@Id",ıd);
            komut.Parameters.AddWithValue("@aktifMi",false);
            return Tools.ExecuteNonQuery(komut);

        }
    }
}
