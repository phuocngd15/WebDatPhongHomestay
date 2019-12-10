using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CaChepFinal2.Data.DataModel
{
    public interface  IDatPhong
    {
        IQueryable<DatPhong> GetAll();
        DatPhong GetOneById(int? id);
        int New(DatPhong DatPhong);
        void Edit(DatPhong DatPhong);
        void Delete(int id);
    }

    public  class DatPhong
    {
        public DatPhong()
        {
            ChiTietDatPhong = new HashSet<ChiTietDatPhong>();
            ChiTietDichVuDatPhong = new HashSet<ChiTietDichVuDatPhong>();
        }

        public int Id { get; set; }
        [Display(Name = "Họ và Tên")]
        public string TenNguoiDat { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        [Display(Name = "CMND")]
        public string Cmnd { get; set; }
        [Display(Name = "SĐT")]
        public string Sdt { get; set; }

        [Column(TypeName = "Money")]
        [Display(Name = "Tiền Đặt Cọc")]
        public decimal TienDatCoc { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Thời Gian Nhận")]
        public DateTime ThoiGianNhanPhongDuKien { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Thời Gian Trả")]
        public DateTime ThoiGianTraPhongDuKien { get; set; }
        [Column(TypeName = "Money")]
        [Display(Name = "Tổng Tiền")]
        public decimal TongTien { get; set; }

        public int? AccoutId { get; set; }
        public virtual AccountSys Account { get; set; }

        public virtual ICollection<ChiTietDatPhong> ChiTietDatPhong { get; set; }
        public virtual ICollection<ChiTietDichVuDatPhong> ChiTietDichVuDatPhong { get; set; }
    }
}
