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
    public class ChuongTrinhsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChuongTrinhsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChuongTrinhs
        public async Task<IActionResult> Index()
        {
            return View(_context.ChuongTrinhs.FromSqlRaw("EXECUTE dbo.spGetChuongTrinh"));
        }

        // GET: Admin/ChuongTrinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuongTrinh = _context.ChuongTrinhs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdChuongTrinh {id}").ToList();

            if (chuongTrinh == null)
            {
                return NotFound();
            }

            return View(chuongTrinh[0]);
        }

        // GET: Admin/ChuongTrinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ChuongTrinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenChuongTrinh,TiLeThayDoiGia,IsTang")] ChuongTrinh chuongTrinh)
        {
            if (ModelState.IsValid)
            {
                var tenchuongtrinh = new SqlParameter("@Name", chuongTrinh.ChuongTrinhName);
                var tile = new SqlParameter("@Tile", chuongTrinh.TiLeThayDoiGia);
                var tang = new SqlParameter("@Tang", chuongTrinh.IsTang);


                _context.Database.ExecuteSqlRaw("EXEC dbo.spAddChuongTrinh @Name,@Tile,@Tang", tenchuongtrinh,tile,tang);
                return RedirectToAction(nameof(Index));
            }
            return View(chuongTrinh);
        }

        // GET: Admin/ChuongTrinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuongTrinh = await _context.ChuongTrinhs.FindAsync(id);
            if (chuongTrinh == null)
            {
                return NotFound();
            }
            return View(chuongTrinh);
        }

        // POST: Admin/ChuongTrinhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenChuongTrinh,TiLeThayDoiGia,IsTang")] ChuongTrinh chuongTrinh)
        {
            if (id != chuongTrinh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var tenct = new SqlParameter("@Ten", chuongTrinh.ChuongTrinhName);
                    var ctId = new SqlParameter("@id", chuongTrinh.Id);
                    var tile = new SqlParameter("@Tile", chuongTrinh.TiLeThayDoiGia);
                    var tang = new SqlParameter("@Tang", chuongTrinh.IsTang);
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditLoaiPhong @id,@Ten,@Tile,@Tang", ctId, tenct,tile,tang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuongTrinhExists(chuongTrinh.Id))
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
            return View(chuongTrinh);
        }

        // GET: Admin/ChuongTrinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuongTrinh = await _context.ChuongTrinhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chuongTrinh == null)
            {
                return NotFound();
            }

            return View(chuongTrinh);
        }

        // POST: Admin/ChuongTrinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuongtrinhId = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeleteChuongTrinh @id", chuongtrinhId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuongTrinhExists(int id)
        {
            return _context.ChuongTrinhs.Any(e => e.Id == id);
        }
    }
}
