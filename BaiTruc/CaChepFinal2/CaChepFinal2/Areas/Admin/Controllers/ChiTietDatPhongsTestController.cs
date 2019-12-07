using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiTietDatPhongsTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietDatPhongsTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietDatPhongsTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChiTietDatPhongs.Include(c => c.DatPhong).Include(c => c.Phong).Include(c => c.TrangThai);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ChiTietDatPhongsTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatPhong = await _context.ChiTietDatPhongs
                .Include(c => c.DatPhong)
                .Include(c => c.Phong)
                .Include(c => c.TrangThai)
                .FirstOrDefaultAsync(m => m.DatPhongId == id);
            if (chiTietDatPhong == null)
            {
                return NotFound();
            }

            return View(chiTietDatPhong);
        }

        // GET: Admin/ChiTietDatPhongsTest/Create
        public IActionResult Create()
        {
            ViewData["DatPhongId"] = new SelectList(_context.DatPhongs, "Id", "Id");
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Name");
            ViewData["TrangThaiId"] = new SelectList(_context.TrangThais, "Id", "Name");
            return View();
        }

        // POST: Admin/ChiTietDatPhongsTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatPhongId,PhongId,TrangThaiId,ThoiGian")] ChiTietDatPhong chiTietDatPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDatPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DatPhongId"] = new SelectList(_context.DatPhongs, "Id", "Id", chiTietDatPhong.DatPhongId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Name", chiTietDatPhong.PhongId);
            ViewData["TrangThaiId"] = new SelectList(_context.TrangThais, "Id", "Name", chiTietDatPhong.TrangThaiId);
            return View(chiTietDatPhong);
        }

        // GET: Admin/ChiTietDatPhongsTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatPhong = await _context.ChiTietDatPhongs.FindAsync(id);
            if (chiTietDatPhong == null)
            {
                return NotFound();
            }
            ViewData["DatPhongId"] = new SelectList(_context.DatPhongs, "Id", "Id", chiTietDatPhong.DatPhongId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Name", chiTietDatPhong.PhongId);
            ViewData["TrangThaiId"] = new SelectList(_context.TrangThais, "Id", "Name", chiTietDatPhong.TrangThaiId);
            return View(chiTietDatPhong);
        }

        // POST: Admin/ChiTietDatPhongsTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatPhongId,PhongId,TrangThaiId,ThoiGian")] ChiTietDatPhong chiTietDatPhong)
        {
            if (id != chiTietDatPhong.DatPhongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietDatPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDatPhongExists(chiTietDatPhong.DatPhongId))
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
            ViewData["DatPhongId"] = new SelectList(_context.DatPhongs, "Id", "Id", chiTietDatPhong.DatPhongId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Name", chiTietDatPhong.PhongId);
            ViewData["TrangThaiId"] = new SelectList(_context.TrangThais, "Id", "Name", chiTietDatPhong.TrangThaiId);
            return View(chiTietDatPhong);
        }

        // GET: Admin/ChiTietDatPhongsTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDatPhong = await _context.ChiTietDatPhongs
                .Include(c => c.DatPhong)
                .Include(c => c.Phong)
                .Include(c => c.TrangThai)
                .FirstOrDefaultAsync(m => m.DatPhongId == id);
            if (chiTietDatPhong == null)
            {
                return NotFound();
            }

            return View(chiTietDatPhong);
        }

        // POST: Admin/ChiTietDatPhongsTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietDatPhong = await _context.ChiTietDatPhongs.FindAsync(id);
            _context.ChiTietDatPhongs.Remove(chiTietDatPhong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietDatPhongExists(int id)
        {
            return _context.ChiTietDatPhongs.Any(e => e.DatPhongId == id);
        }
    }
}
