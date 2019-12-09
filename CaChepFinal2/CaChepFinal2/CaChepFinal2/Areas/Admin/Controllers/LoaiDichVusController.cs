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
    public class LoaiDichVusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoaiDichVusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiDichVus
        public IActionResult Index()
        {
            return View(_context.LoaiDichVus.FromSqlRaw("EXECUTE dbo.spGetLoaiDichVu"));
        }

        // GET: Admin/LoaiDichVus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = _context.LoaiDichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiDichVu {id}").ToList();

            if (loaiDichVu == null)
            {
                return NotFound();
            }

            return View(loaiDichVu[0]);
        }

        // GET: Admin/LoaiDichVus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiDichVus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] LoaiDichVu loaiDichVu)
        {
            if (ModelState.IsValid)
            { 
               
                var ten = new Microsoft.Data.SqlClient.SqlParameter("@Ten", loaiDichVu.LoaiDichVuName);
                var mota = new Microsoft.Data.SqlClient.SqlParameter("@mota", loaiDichVu.Description);
                  
               
                  //  _context.Database.ExecuteSqlRaw("EXEC dbo.spAddLoaiDichVu @Ten,@mota", ten, mota);
                

                _context.Database.ExecuteSqlRaw("EXEC dbo.spAddLoaiDichVu @Ten", ten);
                return RedirectToAction(nameof(Index));
            }
            return View(loaiDichVu);
        }

        // GET: Admin/LoaiDichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = await _context.LoaiDichVus.FindAsync(id);
            if (loaiDichVu == null)
            {
                return NotFound();
            }
            return View(loaiDichVu);
        }

        // POST: Admin/LoaiDichVus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] LoaiDichVu loaiDichVu)
        {
            if (id != loaiDichVu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loaidvuid = new SqlParameter("@id", loaiDichVu.Id);
                    var loaidichvuName = new SqlParameter("@Ten", loaiDichVu.LoaiDichVuName);
                    var mota = new SqlParameter("@mota", loaiDichVu.Description);
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditLoaiDichVu @id,@Ten,@mota", loaidvuid, loaidichvuName,mota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiDichVuExists(loaiDichVu.Id))
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
            return View(loaiDichVu);
        }

        // GET: Admin/LoaiDichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = await _context.LoaiDichVus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiDichVu == null)
            {
                return NotFound();
            }

            return View(loaiDichVu);
        }

        // POST: Admin/LoaiDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiphongId = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeleteLoaiDichVu @id", loaiphongId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiDichVuExists(int id)
        {
            return _context.LoaiDichVus.Any(e => e.Id == id);
        }
    }
}
