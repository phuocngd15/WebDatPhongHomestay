using System;
using System.Collections.Generic;
using System.Linq;

namespace CaChepFinal2.Data.DataModel
{
    public interface ITrangThai
    {
        IQueryable<TrangThai> GetAll();
        TrangThai GetOneById(int? id);
        void New(TrangThai a);
        void Edit(TrangThai a);
        void Delete(int id);
    }
    public  class TrangThai
    {
        public TrangThai()
        {
            ChiTietDatPhong = new HashSet<ChiTietDatPhong>();
        }
        public int Id { get; set; }
        public string TrangThaiName { get; set; }

        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhong { get; set; }
    }
}
