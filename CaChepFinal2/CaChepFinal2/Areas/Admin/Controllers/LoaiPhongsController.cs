﻿using System;
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
    public class LoaiPhongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoaiPhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiPhongs
        public IActionResult Index()
        {
            return View( _context.LoaiPhongs.FromSqlRaw("EXECUTE dbo.spGetLoaiPhong"));
        }

        // GET: Admin/LoaiPhongs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhong = _context.LoaiPhongs.FromSqlRaw($"EXECUTE dbo.spGetOneByIdLoaiPhong {id}").ToList();
            if (loaiPhong == null)
            {
                return NotFound();
            }

            return View(loaiPhong[0]);
        }

        // GET: Admin/LoaiPhongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiPhongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                           var loaiphongName = new SqlParameter("@Ten", loaiPhong.LoaiPhongName);
                 _context.Database.ExecuteSqlRaw("EXEC dbo.spAddLoaiPhong @Ten", loaiphongName);
             //    _context.Database.ExecuteSqlCommand();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiPhong);
        }

        // GET: Admin/LoaiPhongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhong = await _context.LoaiPhongs.FindAsync(id);
            if (loaiPhong == null)
            {
                return NotFound();
            }
            return View(loaiPhong);
        }

        // POST: Admin/LoaiPhongs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] LoaiPhong loaiPhong)
        {
            if (id != loaiPhong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loaiphongName = new SqlParameter("@Ten", loaiPhong.LoaiPhongName);
                    var loaiphongId = new SqlParameter("@id",loaiPhong.Id);
                    _context.Database.ExecuteSqlRaw("EXEC dbo.spEditLoaiPhong @id,@Ten", loaiphongId,loaiphongName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiPhongExists(loaiPhong.Id))
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
            return View(loaiPhong);
        }

        // GET: Admin/LoaiPhongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiPhong = await _context.LoaiPhongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiPhong == null)
            {
                return NotFound();
            }

            return View(loaiPhong);
        }

        // POST: Admin/LoaiPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var loaiphongId = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("EXEC dbo.spDeleteLoaiPhong @id", loaiphongId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiPhongExists(int id)
        {
            return _context.LoaiPhongs.Any(e => e.Id == id);
        }
    }
}
