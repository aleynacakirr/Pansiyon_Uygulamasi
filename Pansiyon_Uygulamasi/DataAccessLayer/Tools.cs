using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_Uygulamasi.DataAccessLayer
{
    public class Tools
    {
        private static readonly SqlConnection baglanti=new SqlConnection("Server=203-ERGUN\\NA; Database=Pansiyon_Uygulamasi;Integrated Security=true;");
        public static SqlConnection Baglanti
        {
            get { return baglanti; }
        }
        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            bool sonuc=false;
            try
            {
                if (baglanti.State==System.Data.ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                if(komut.ExecuteNonQuery()>0)
                {
                    sonuc=true;
                }
            }
            catch (Exception)
            {
            }
            finally 
            {
               if (baglanti.State==System.Data.ConnectionState.Open) 
               { 
                 baglanti.Close();
               }
            }
            return sonuc;

        }
        public static bool ExecuteReader(SqlCommand komut)
        {
            bool sonnuc=false;
            try
            {
                if (baglanti.State==System.Data.ConnectionState.Closed)
                { 
                    baglanti.Open();
                }
               if( komut.ExecuteReader().HasRows)
                {
                    sonnuc=true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(baglanti.State==System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

            return sonnuc;
        }
    }
}
