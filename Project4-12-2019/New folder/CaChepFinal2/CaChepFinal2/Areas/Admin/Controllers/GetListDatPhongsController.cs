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
    public class GetListDatPhongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetListDatPhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GetListDatPhongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phongs.Include(p => p.ChuongTrinh).Include(p => p.LoaiPhong);
            return View(await applicationDbContext.ToListAsync());
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
