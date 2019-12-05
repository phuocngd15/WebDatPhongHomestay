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
    public class DichVusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichVusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DichVus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DichVus.Include(d => d.LoaiDv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/DichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dichVu = _context.DichVus.FromSqlRaw($"EXECUTE dbo.spGetOneByIdDichVu {id}").ToList();

            //var dichVu = await _context.DichVus
            //    .Include(d => d.LoaiDv)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu[0]);
        }

        // GET: Admin/DichVus/Create
        public IActionResult Create()
        {
            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "Name");
            return View();
        }

        // POST: Admin/DichVus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortDescription,Price,ImageUrl,InStock,LoaiDvid")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "Name", dichVu.LoaiDvid);
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
            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "Name", dichVu.LoaiDvid);
            return View(dichVu);
        }

        // POST: Admin/DichVus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortDescription,Price,ImageUrl,InStock,LoaiDvid")] DichVu dichVu)
        {
            if (id != dichVu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichVu);
                    await _context.SaveChangesAsync();
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
            ViewData["LoaiDvid"] = new SelectList(_context.LoaiDichVus, "Id", "Name", dichVu.LoaiDvid);
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
            var dichVu = await _context.DichVus.FindAsync(id);
            _context.DichVus.Remove(dichVu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichVuExists(int id)
        {
            return _context.DichVus.Any(e => e.Id == id);
        }
    }
}
