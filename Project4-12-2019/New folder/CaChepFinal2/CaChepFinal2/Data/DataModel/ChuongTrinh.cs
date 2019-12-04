using System;
using System.Collections.Generic;
using System.Linq;

namespace CaChepFinal2.Data.DataModel
{
    public interface IChuongTrinh
    {
        IQueryable<ChuongTrinh> GetAll();
        ChuongTrinh GetOneById(int? id);
        void New(ChuongTrinh obj);
        void Edit(ChuongTrinh obj);
        void Delete(int id);
    }
    public  class ChuongTrinh
    {
        public ChuongTrinh()
        {
            Phongs = new HashSet<Phong>();
        }

        public int Id { get; set; }
        public string TenChuongTrinh { get; set; }
        public int TiLeThayDoiGia { get; set; }
        public bool IsTang { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
