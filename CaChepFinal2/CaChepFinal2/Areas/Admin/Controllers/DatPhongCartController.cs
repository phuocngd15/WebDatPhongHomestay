using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Areas.Admin.Models;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using CaChepFinal2.Extensions;
using CaChepFinal2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Linq;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
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

        public IActionResult GetListPhong()
        {
            var lsPhongs = _Context.Phongs.Include(p => p.LoaiPhong);
            return RedirectToAction("Index", "GetListDatPhongs", new {area = "Admin"});

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
            return RedirectToAction("Index", "DatPhongCart", new {area = "Admin"});
        }

        public IActionResult GetListDichVu()
        {
            var lsPhongs = _Context.Phongs.Include(p => p.LoaiPhong);
            return RedirectToAction("Index", "GetListDichVu", new {area = "Admin"});
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
            return RedirectToAction("Index", "DatPhongCart", new {area = "Admin"});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XacNhanDatPhong(DatPhongCartVM ab)
        {
            if (ModelState.IsValid)
            {
                List<int> lstsPhongCart = HttpContext.Session.Get<List<int>>("ssPhongCart");
                if (lstsPhongCart != null)
                {
                    if (lstsPhongCart.Count != 0)
                        foreach (var i in lstsPhongCart)
                        {
                            _Context.Database.ExecuteSqlRaw($"EXECUTE dbo.AddChiTietDatPhongHeap {i}");
                        }
                }

                List<int> lstsDichVuCart = HttpContext.Session.Get<List<int>>("ssDichVuCart");
                if (lstsDichVuCart != null)
                {
                    if (lstsDichVuCart.Count != 0)
                        foreach (var i in lstsDichVuCart)
                        {
                            _Context.Database.ExecuteSqlRaw($"EXECUTE dbo.AddChiTietDichVuHeap {i}");
                        }
                }

                var Tenkh = new SqlParameter("@Tenkh", ab.newDatPhong.TenNguoiDat);
                var DiaChi = new SqlParameter("@DiaChi", ab.newDatPhong.Address);
                var CMND = new SqlParameter("@CMND", ab.newDatPhong.Cmnd);
                var SDT = new SqlParameter("@SDT", ab.newDatPhong.Sdt);
                var TienCoc = new SqlParameter("@TienCoc", ab.newDatPhong.TienDatCoc);
                var NgayNhan = new SqlParameter("@NgayNhan", ab.newDatPhong.ThoiGianNhanPhongDuKien.ToShortDateString());
                var NgayTra = new SqlParameter("@NgayTra", ab.newDatPhong.ThoiGianTraPhongDuKien.ToShortDateString());

                _Context.Database.ExecuteSqlRaw(
                    $"EXECUTE  dbo.AddDatPhong @Tenkh , @DiaChi, @CMND, @SDT,@TienCoc,@NgayNhan ='{ab.newDatPhong.ThoiGianNhanPhongDuKien.ToShortDateString()}',@NgayTra ='{ab.newDatPhong.ThoiGianTraPhongDuKien.ToShortDateString()}'", Tenkh, DiaChi, CMND, SDT, TienCoc);

                // xoa sestion
                lstsDichVuCart = null;
                HttpContext.Session.Set("ssPhongCart", lstsDichVuCart);
                lstsPhongCart = null;
                HttpContext.Session.Set("ssPhongCart", lstsPhongCart);


                return RedirectToAction("Index", "DatPhongs", new {area = "Admin"});
            }
            return RedirectToAction("Index", "DatPhongCart", new { area = "Admin" });
        }

    }
}