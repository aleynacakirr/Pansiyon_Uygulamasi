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
    internal class OdaDal : IRepository<Oda>
    {
        public bool Ekle(Oda entity)
        {
            SqlCommand komut=new SqlCommand("Insert Into Odalar(OdaNo, OdaFiyati, MusaitMi, AktifMi) values (@odaNo, @odaFiyati, @musaitMi, @aktifMi)",Tools.Baglanti);
            komut.Parameters.AddWithValue("@odaNo",entity.OdaNo);
            komut.Parameters.AddWithValue("@odaFiyati",entity.OdaFiyati);
            komut.Parameters.AddWithValue("@musaitMi",entity.MusaitMi);
            komut.Parameters.AddWithValue("@aktifMi",entity.AktifMi);
            return Tools.ExecuteNonQuery(komut);

        }

        public bool Guncelle(Oda entity)
        {
            SqlCommand komut=new SqlCommand("Update Odalar set OdaNo=@odaNo, OdaFiyati=@odaFiyati, MusaitMi=@musaitMi, AktifMi=@aktifMi, GuncellemeTarihi=@guncellemeTarihi where Id=@id",Tools.Baglanti);
            komut.Parameters.AddWithValue("@odaNo", entity.OdaNo);
            komut.Parameters.AddWithValue("@odaFiyati", entity.OdaFiyati);
            komut.Parameters.AddWithValue("@musaitMi", entity.MusaitMi);
            komut.Parameters.AddWithValue("@aktifMi", entity.AktifMi);
            komut.Parameters.AddWithValue("@id", entity.Id);
            komut.Parameters.AddWithValue("@guncellemeTarihi", entity.GuncellemeTarihi);
            return Tools.ExecuteNonQuery(komut);
        }

        public DataTable Listele()
        {
            SqlDataAdapter adapter= new SqlDataAdapter("OdaListele",Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;

        }

        public bool Sil(int ıd)
        {
            SqlCommand komut = new SqlCommand("Delete from Odalar where Id=@id", Tools.Baglanti);
            komut.Parameters.AddWithValue("@id", ıd);
            return Tools.ExecuteNonQuery(komut);
        }

        public List<Oda> OdaListele()
        {
            List<Oda> odaList =new List<Oda>();
            SqlCommand komut = new SqlCommand("select * from Odalar where AktifMi=@aktifMi", Tools.Baglanti);
            komut.Parameters.AddWithValue("@aktifMi",true);
            try
            {
                if (Tools.Baglanti.State==ConnectionState.Closed)
                {
                    Tools.Baglanti.Open();
                }
                SqlDataReader reader= komut.ExecuteReader();
                while (reader.Read())
                {
                    Oda oda=new Oda()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        OdaNo=reader["OdaNo"].ToString(),
                        OdaFiyati = Convert.ToDouble(reader["OdaFiyati"]),
                        MusaitMi = Convert.ToBoolean(reader["MusaitMi"]),
                        AktifMi = Convert.ToBoolean(reader["AktifMi"])
                    };
                    odaList.Add(oda);
                }
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                if (Tools.Baglanti.State==ConnectionState.Open)
                {
                    Tools.Baglanti.Close();
                }
            }
            return odaList;
        }

        public bool DurumGuncelle(Oda oda)
        {
            SqlCommand komut= new SqlCommand("Update Odalar set MusaitMi=@musaitMi where Id=@id",Tools.Baglanti);
            komut.Parameters.AddWithValue("@musaitMi",oda.MusaitMi);
            komut.Parameters.AddWithValue("@id",oda.Id);
            return Tools.ExecuteNonQuery(komut);
        }
    }
}
