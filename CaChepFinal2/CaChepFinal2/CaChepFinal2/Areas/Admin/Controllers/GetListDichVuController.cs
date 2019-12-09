using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using CaChepFinal2.Extensions;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GetListDichVuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetListDichVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GetListDichVu
        public IActionResult Index()
        {
            var applicationDbContext = _context.DichVus.FromSqlRaw("EXECUTE dbo.spGetDichVu").ToList();
            foreach (var i in applicationDbContext)
            {
                var loaiDichVuName = _context.LoaiDichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiDichVu {i.LoaiDvid}").ToList();
                i.LoaiDv = loaiDichVuName[0];

            }
            return View(applicationDbContext);
        }
        public IActionResult AddDichVuToCart(int id)
        {
            List<int> lsDichvuCart = HttpContext.Session.Get<List<int>>("ssDichVuCart");
            if (lsDichvuCart == null)
            {
                lsDichvuCart = new List<int>();
            }

            lsDichvuCart.Add(id);
            HttpContext.Session.Set("ssDichVuCart", lsDichvuCart);
            return RedirectToAction("Index", "DatPhongCart", new { area = "Admin" });
        }
    }
}
