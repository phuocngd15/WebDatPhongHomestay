using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CaChepFinal2.Data.DataModel
{
    public interface IPhong
    {
        IQueryable<LoaiPhong> GetAll();
        LoaiPhong GetOneById(int? id);
        void New(LoaiPhong LoaiPhong);
        void Edit(LoaiPhong LoaiPhong);
        void Delete(int id);
    }
    public  class Phong
    {
        public Phong()
        {
            ChiTietDatPhong = new HashSet<ChiTietDatPhong>();
            HinhPhong = new HashSet<HinhPhong>();
        }

        public int Id { get; set; }
        public string PhongName { get; set; }
        public string ShortDescription { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public int? LoaiPhongId { get; set; }
        public int? ChuongTrinhId { get; set; }

        [NotMapped]
        public string ChuongTrinhName { get; set; }
        public virtual ChuongTrinh ChuongTrinh { get; set; }
        public virtual LoaiPhong LoaiPhong { get; set; }
        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhong { get; set; }
        public virtual ICollection<HinhPhong> HinhPhong { get; set; }
    }
}
