using System;
using System.Collections.Generic;
using System.Linq;

namespace CaChepFinal2.Data.DataModel
{
    public interface ILoaiPhong
    {
        IQueryable<LoaiPhong> GetAll();
        LoaiPhong GetOneById(int? id);
        void New(LoaiPhong LoaiPhong);
        void Edit(LoaiPhong LoaiPhong);
        void Delete(int id);
    }
    public  class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        public int Id { get; set; }
        public string LoaiPhongName { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
