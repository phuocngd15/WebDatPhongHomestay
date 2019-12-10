using System.Collections.Generic;
using System.Data;
using System.Linq;
using CaChepFinal2.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using CaChepFinal2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Linq;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class GetListDatPhongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetListDatPhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GetListDatPhongs
        public IActionResult Index(GetListDatPhongIndexVM getListDatPhongIndexVm, string sortOrder)
        { // getlist phong trong theo ngay den ngay di.
          // có 2 ô ngày đến ngày đi nhập vô.
          // tìm phòng ngày đó.
          // chọn phòng
            var lsPhongsDb = from m in _context.Phongs select m;
            bool isFillterDb = false;
            if (getListDatPhongIndexVm.NgayNhanPhongDuKien != default)
            {
                // tìm tất cả các phòng trong chi tiết đặt phòng theo ngày đến, ngày đi
                var thoiGianNhanSqlParameter = new SqlParameter
                {
                    ParameterName = "@ThoiGianNhan",
                    SqlDbType = SqlDbType.Date,
                    SqlValue = getListDatPhongIndexVm.NgayNhanPhongDuKien
                };
                var thoiGianTraSqlParameter = new SqlParameter
                {
                    ParameterName = "@ThoiGianTra",
                    SqlDbType = SqlDbType.Date,
                    SqlValue = getListDatPhongIndexVm.NgayTraPhongDuKien
                };
                lsPhongsDb =  _context.Phongs.FromSqlRaw($"EXECUTE dbo.TimPhongLienTuc @ThoiGianNhan,@ThoiGianTra ",thoiGianNhanSqlParameter,thoiGianTraSqlParameter);
                isFillterDb = true;
            }
            var getListDatPhongIndexVm2 = new GetListDatPhongIndexVM
            {
                LsPhongDatPhongs = lsPhongsDb.ToList(),
                isFillter= isFillterDb
            };
            return View(getListDatPhongIndexVm2);
        }

        public IActionResult AddPhongToCart(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssPhongCart");
            if (lstShoppingCart == null)
            {
                lstShoppingCart = new List<int>();
            }

            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssPhongCart", lstShoppingCart);

            return RedirectToAction("Index", "DatPhongCart", new {area = "Admin"});

        }

    }
}
