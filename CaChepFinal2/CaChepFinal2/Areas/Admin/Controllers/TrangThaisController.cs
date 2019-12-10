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
    public class TrangThaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrangThaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TrangThais
        public IActionResult Index()
        {
            return View(_context.TrangThais.FromSqlRaw("EXECUTE dbo.spGetTrangThai"));
        }

        // GET: Admin/TrangThais/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThai = _context.TrangThais.FromSqlRaw($"EXECUTE dbo.spGetOneByIdTrangThai {id}").ToList();

            if (trangThai.Count == 0)
            {
                return NotFound();
            }

            return View(trangThai[0]);
        }

        // GET: Admin/TrangThais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TrangThais/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] TrangThai trangThai)
        {
            if (ModelState.IsValid)
            {
                var ten = new SqlParameter("@Name", trangThai.TrangThaiName);
               
                _context.Database.ExecuteSqlRaw("EXEC dbo.spAddTrangThai @Name", ten);
                return RedirectToAction(nameof(Index));
            }
            return View(trangThai);
        }

        // GET: Admin/TrangThais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThai = await _context.TrangThais.FindAsync(id);
            if (trangThai == null)
            {
                return NotFound();
            }
            return View(trangThai);
        }

        // POST: Admin/TrangThais/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TrangThai trangThai)
        {
            if (id != trangThai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ten = new SqlParameter("@Ten", trangThai.TrangThaiName);
                    var trangthaiId = new SqlParameter("@id", trangThai.Id);
                  
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditTrangThai @id,@Ten", trangthaiId, ten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrangThaiExists(trangThai.Id))
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
            return View(trangThai);
        }

        // GET: Admin/TrangThais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trangThai = await _context.TrangThais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trangThai == null)
            {
                return NotFound();
            }

            return View(trangThai);
        }

        // POST: Admin/TrangThais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trangthai = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeleteTrangThai @id", trangthai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrangThaiExists(int id)
        {
            return _context.TrangThais.Any(e => e.Id == id);
        }
    }
}
