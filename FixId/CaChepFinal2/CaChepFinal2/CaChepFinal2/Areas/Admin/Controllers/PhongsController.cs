using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using Microsoft.Data.SqlClient;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Phongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phongs.FromSqlRaw("EXECUTE dbo.spGetPhong").ToList();
            foreach (var i in applicationDbContext)
            {
              var  chuongTrinhName=_context.ChuongTrinhs.FromSqlRaw($"EXECUTE dbo.spGetNameChuongTrinhById {i.ChuongTrinhId}").ToList();
              i.ChuongTrinh = chuongTrinhName[0];

              var loaiphongName = _context.LoaiPhongs.FromSqlRaw($"EXECUTE dbo.spGetNameLoaiPhongById {i.LoaiPhongId}").ToList();
              i.LoaiPhong = loaiphongName[0];
            }
            return View(applicationDbContext);
        }

        // GET: Admin/Phongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var phong = _context.Phongs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdPhong {id}").ToList();
            foreach (var i in phong)
            {
                var chuongTrinhName = _context.ChuongTrinhs.FromSqlRaw($"EXECUTE dbo.spGetNameChuongTrinhById {i.ChuongTrinhId}").ToList();
                i.ChuongTrinh = chuongTrinhName[0];

                var loaiphongName = _context.LoaiPhongs.FromSqlRaw($"EXECUTE dbo.spGetNameLoaiPhongById {i.LoaiPhongId}").ToList();
                i.LoaiPhong = loaiphongName[0];
            }

            if (phong.Count == 0)
            {
                return NotFound();
            }

            return View(phong[0]);
        }

        // GET: Admin/Phongs/Create
        public IActionResult Create()
        {
            ViewData["ChuongTrinhId"] = new SelectList(_context.ChuongTrinhs, "Id", "ChuongTrinhName");
            ViewData["LoaiPhongId"] = new SelectList(_context.LoaiPhongs, "Id", "LoaiPhongName");
            return View();
        }

        // POST: Admin/Phongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortDescription,Price,LoaiPhongId,ChuongTrinhId")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                var phongName = new SqlParameter("@Ten", phong.PhongName);
                var mota = new SqlParameter("@Mota", phong.ShortDescription);
                var gia = new SqlParameter("@Price", phong.Price);
                var loaiphongId = new SqlParameter("@LoaiphongId", phong.LoaiPhongId);
                var chuongtrinhId = new SqlParameter("@ChuongtrinhId", phong.ChuongTrinhId);
                _context.Database.ExecuteSqlRaw("EXEC dbo.spAddPhong @Ten,@Mota,@Price,@LoaiphongId,@ChuongtrinhId", phongName,mota,gia,loaiphongId,chuongtrinhId);
                return RedirectToAction(nameof(Index));
            }
            
            //ViewData["ChuongTrinhId"] = new SelectList(_context.ChuongTrinhs, "Id", "TenChuongTrinh", phong.ChuongTrinhId);
            //ViewData["LoaiPhongId"] = new SelectList(_context.LoaiPhongs, "Id", "Name", phong.LoaiPhongId);
            ViewData["@LoaiphongId"] = new SelectList(_context.LoaiPhongs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiPhong "), phong.LoaiPhongId);
            ViewData["@ChuongtrinhId"] = new SelectList(_context.ChuongTrinhs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdChuongTrinh "), phong.ChuongTrinhId);

            return View(phong);
        }

        // GET: Admin/Phongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["ChuongTrinhId"] = new SelectList(_context.ChuongTrinhs, "Id", "ChuongTrinhName", phong.ChuongTrinhId);
            ViewData["LoaiPhongId"] = new SelectList(_context.LoaiPhongs, "Id", "LoaiPhongName", phong.LoaiPhongId);
            return View(phong);
        }

        // POST: Admin/Phongs/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortDescription,Price,LoaiPhongId,ChuongTrinhId")] Phong phong)
        {
            if (id != phong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var idphong = new SqlParameter("@id", phong.Id);
                    var phongName = new SqlParameter("@Ten", phong.PhongName);
                    var mota = new SqlParameter("@Mota", phong.ShortDescription);
                    var gia = new SqlParameter("@Price", phong.Price);
                    var loaiphongId = new SqlParameter("@LoaiphongId", phong.LoaiPhongId);
                    var chuongtrinhId = new SqlParameter("@ChuongtrinhId", phong.ChuongTrinhId);
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditPhong @id, @Ten,@Mota,@Price,@LoaiphongId,@ChuongtrinhId",idphong, phongName, mota, gia, loaiphongId, chuongtrinhId);
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.Id))
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
            //ViewData["ChuongTrinhId"] = new SelectList(_context.ChuongTrinhs, "Id", "TenChuongTrinh", phong.ChuongTrinhId);
            //ViewData["LoaiPhongId"] = new SelectList(_context.LoaiPhongs, "Id", "Name", phong.LoaiPhongId);
            ViewData["@LoaiphongId"] = new SelectList(_context.LoaiPhongs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiPhong "), phong.LoaiPhongId);
            ViewData["@ChuongtrinhId"] = new SelectList(_context.ChuongTrinhs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdChuongTrinh "), phong.ChuongTrinhId);

            return View(phong);
        }

        // GET: Admin/Phongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.ChuongTrinh)
                .Include(p => p.LoaiPhong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Admin/Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongId = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeletePhong @id", phongId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.Id == id);
        }
    }
}
