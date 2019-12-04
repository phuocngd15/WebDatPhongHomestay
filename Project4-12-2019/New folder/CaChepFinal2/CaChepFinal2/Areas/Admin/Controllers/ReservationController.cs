using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Areas.Admin.Models;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        #region Service
        private readonly ApplicationDbContext _dbContext;

        //private readonly IDatPhong _datphongsv;
        //private readonly IChiTietDichVuDatPhong _chiTietDichVuDatPhongsv;
        ////private readonly IChiTietDatPhong _chiTietDatPhongsv;
        //private readonly IPhong _phong;
        //private readonly ITrangThai _TrangThaisv;
        //private readonly IDichVu _dichVusv;


        public ReservationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            //_datphongsv = datPhong;
            //_chiTietDichVuDatPhongsv = chiTietDichVuDatPhong;
            ////_chiTietDatPhongsv = chiTietDatPhong;
            //_TrangThaisv = trangThai;
            //_phong = phong;
            //_dichVusv = dichVu;
            //_DatPhongCart = new ReservationIndexModel()
            //{
            //    LsPhongDatPhongs = new List<Phong>(),
            //    LsDichVuDatPhongs = new List<DichVu>(),
            //};
            // _mapper = new Mapper();
        }
        #endregion
        public IActionResult Index(ReservationIndexModel reservation, string sortOrder)
        {
            // nếu chưa có gì thì tạo đối tượng vào trả về index;
            if (reservation.LisDatPhongs == null)
            {
                var GetDataforReservation = new ReservationIndexModel
                {
                    // chưa tách ra bằng s
                  //  LisDatPhongs = _datphongsv.GetAll().ToList(),
                    LisDatPhongs = _dbContext.DatPhongs.ToList(),
                };
                return View(GetDataforReservation);
            }



            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            // index chua search
            //  var listdatphong = _datphongsv.GetAll();
            var listdatphong = from m in _dbContext.DatPhongs select m;
            switch (sortOrder)
            {
                case "name_desc":
                    listdatphong = listdatphong.OrderByDescending(s => s.TenNguoiDat);
                    break;
                case "Date":
                    listdatphong = listdatphong.OrderBy(s => s.ThoiGianNhanPhongDuKien);
                    break;
                case "date_desc":
                    listdatphong = listdatphong.OrderByDescending(s => s.ThoiGianNhanPhongDuKien);
                    break;
                default:
                    listdatphong = listdatphong.OrderBy(s => s.TenNguoiDat);
                    break;
            }
            // tìm kiếm theo cmnd
            if (!string.IsNullOrEmpty(reservation.CMND))
            {
                listdatphong = listdatphong.Where(s => s.Cmnd.Contains(reservation.CMND));
            }
            // tìm kiếm theo thời gian nhận
            if (reservation.ThoiGianNhan != default)
            {
                listdatphong = listdatphong
                    .Where(u => u.ThoiGianNhanPhongDuKien.Date == reservation.ThoiGianNhan.Date);

            }
            // tìm kiếm theo ???

            // tạo đối tượng trả về cho view.
            var GetDataforReservation2 = new ReservationIndexModel
            {
                LisDatPhongs = listdatphong.ToList()

            };
            return View(GetDataforReservation2);

        }
    }
}