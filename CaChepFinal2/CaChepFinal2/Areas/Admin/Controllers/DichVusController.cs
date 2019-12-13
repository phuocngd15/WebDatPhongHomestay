using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using CaChepFinal2.Utility;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class DichVusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichVusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DichVus
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

        // GET: Admin/DichVus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dichVu = _context.DichVus.FromSqlRaw($"EXECUTE dbo.GetOneDichVuById {id}").ToList();
            foreach (var i in dichVu)
            {
                var loaiDichVuName = _context.LoaiDichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiDichVu {i.LoaiDvid}").ToList();
                i.LoaiDv = loaiDichVuName[0];

            }
            if (dichVu.Count == 0)
            {
                return NotFound();
            }

            return View(dichVu[0]);
        }

        // GET: Admin/DichVus/Create
        public IActionResult Create()
        {
            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "LoaiDichVuName");
            return View();
        }

        // POST: Admin/DichVus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,DichVuName,ShortDescription,Price,ImageUrl,InStock,LoaiDvid")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {

                var dVuName = new SqlParameter("@Name", dichVu.DichVuName);
                var mota = new SqlParameter("@Mota", dichVu.ShortDescription);
                var gia = new SqlParameter("@Price", dichVu.Price);
                var hinh = new SqlParameter("@hinh", dichVu.ImageUrl);
                var instock = new SqlParameter("@InStock", dichVu.InStock);
                var loaiDVuid = new SqlParameter("@LoaiDVuId", dichVu.LoaiDvid);
                _context.Database.ExecuteSqlRaw("EXEC dbo.spAddDichVu @Name,@Mota,@Price,@hinh,@InStock,@LoaiDVuId", dVuName, mota, gia, hinh, instock, loaiDVuid);
                return RedirectToAction(nameof(Index));
            }
            ViewData["@LoaiDVuId"] = new SelectList(_context.LoaiDichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiDichVu "), dichVu.LoaiDvid);

            return View(dichVu);
        }

        // GET: Admin/DichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return NotFound();
            }

            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "LoaiDichVuName", dichVu.LoaiDvid);
            return View(dichVu);
        }

        // POST: Admin/DichVus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,DichVuName,ShortDescription,Price,ImageUrl,InStock,LoaiDvid")] DichVu dichVu)
        {
            if (id != dichVu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dvId = new SqlParameter("@id", dichVu.Id);
                    var dVuName = new SqlParameter("@Name", dichVu.DichVuName);
                    var mota = new SqlParameter("@Mota", dichVu.ShortDescription);
                    var gia = new SqlParameter("@Price", dichVu.Price);
                    var hinh = new SqlParameter("@hinh", dichVu.ImageUrl);
                    var instock = new SqlParameter("@InStock", dichVu.InStock);
                    var loaiDVuid = new SqlParameter("@LoaiDVuId", dichVu.LoaiDvid);
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditDichVu @id, @Name,@Mota,@Price,@hinh,@InStock,@LoaiDVuId", dvId, dVuName, mota, gia, hinh, instock, loaiDVuid);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichVuExists(dichVu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["@LoaiDVuId"] = new SelectList(_context.LoaiDichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiDichVu "), dichVu.LoaiDvid);

            return View(dichVu);
        }

        // GET: Admin/DichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVus
                .Include(d => d.LoaiDv)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu);
        }

        // POST: Admin/DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongId = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeleteDichVu @id", phongId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichVuExists(int id)
        {
            return _context.DichVus.Any(e => e.Id == id);
        }
    }
}
