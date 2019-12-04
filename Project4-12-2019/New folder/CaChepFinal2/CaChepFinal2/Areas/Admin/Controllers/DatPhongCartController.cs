using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Areas.Admin.Models;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using CaChepFinal2.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatPhongCartController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public DatPhongCartVM _DatPhongCart { get; set; }
        public DatPhongCartController(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
            _DatPhongCart = new DatPhongCartVM()
            {
                LsPhongDatPhongs = new List<Phong>(),
                LsDichVuDatPhongs = new List<DichVu>(),
            };
        }
        public IActionResult Index()
        {
            List<int> lstsPhongCart = HttpContext.Session.Get<List<int>>("ssPhongCart");
            if (lstsPhongCart == null) return View(_DatPhongCart);
            if (lstsPhongCart.Count > 0)
            {
                foreach (int cartItem in lstsPhongCart)
                {
                    Phong listPhongDat = _Context.Phongs.Find(cartItem);
                    _DatPhongCart.LsPhongDatPhongs.Add(listPhongDat);
                }
            }
            List<int> lstsDichVuCart = HttpContext.Session.Get<List<int>>("ssDichVuCart");
            if (lstsDichVuCart == null) return View(_DatPhongCart);
            if (lstsDichVuCart.Count > 0)
            {
                foreach (int cartItem in lstsDichVuCart)
                {
                    DichVu oneDichVu = _Context.DichVus.Find(cartItem);
                    _DatPhongCart.LsDichVuDatPhongs.Add(oneDichVu);
                }
            }

            return View(_DatPhongCart);
        }
        public async Task<IActionResult> GetListPhong()
        {
            //var listPhong =  _phong.GetAll().Include(m => m.GetLoaiPhong.Name);
            var lsPhongs = _Context.Phongs.Include(p => p.LoaiPhong);
            return RedirectToAction("Index", "GetListDatPhongs", new { area = "Admin" });

        }
        public IActionResult RemovePhongFromCart(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssPhongCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssPhongCart", lstCartItems);
            //return RedirectToAction();
            return RedirectToAction("Index", "DatPhongCart", new { area = "Admin" });
        }



        public async Task<IActionResult> GetListDichVu()
        {
            //  var lsDichVus = _dichVusv.GetAll().Include(p => p.GetLoaiDV);
            var lsPhongs = _Context.Phongs.Include(p => p.LoaiPhong);
            return RedirectToAction("Index", "GetListDichVu", new { area = "Admin" });
        }
        public IActionResult RemoveDVFromCart(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssDichVuCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssDichVuCart", lstCartItems);
            // return RedirectToAction();
            return RedirectToAction("Index", "DatPhongCart", new { area = "Admin" });
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XacNhanDatPhong(DatPhongCartVM ab)
        {
            if (ModelState.IsValid)
            {
                // lấy đc id vừa add vào db : đã lấy đc
                _Context.Add(ab.newDatPhong);
                await _Context.SaveChangesAsync();
                int newDatPhongId = ab.newDatPhong.Id;
                var soDong = (int)(ab.newDatPhong.ThoiGianTraPhongDuKien.Date - ab.newDatPhong.ThoiGianNhanPhongDuKien.Date)
                    .TotalDays;

                // list Id Phong
                List<int> lstsPhongCart = HttpContext.Session.Get<List<int>>("ssPhongCart");


                // xác định số dòng cần thêm cho mỗi phòng
                // 
                for (int j = 0; j < soDong; j++)
                {
                    var thoiGianinChiTietDatPhong = ab.newDatPhong.ThoiGianTraPhongDuKien.Date;

                    foreach (var i in lstsPhongCart)
                    {
                        var objChiTietDatPhong = new ChiTietDatPhong
                        {
                            DatPhongId = newDatPhongId,
                            PhongId = i,
                            TrangThaiId = 1,
                            ThoiGian = thoiGianinChiTietDatPhong
                        };
                        thoiGianinChiTietDatPhong.AddDays(1);
                        _Context.Add(objChiTietDatPhong);
                        await _Context.SaveChangesAsync();
                    }
                    
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "DatPhongs", new { area = "Admin" });
        }
    }

}