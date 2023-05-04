using Pansiyon_Uygulamasi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pansiyon_Uygulamasi.DataAccessLayer
{
    public interface IRepository<T>
    {
        bool Ekle(T entity);
        bool Sil(int ıd);
        bool Guncelle(T entity);
        DataTable Listele();

    }
}
