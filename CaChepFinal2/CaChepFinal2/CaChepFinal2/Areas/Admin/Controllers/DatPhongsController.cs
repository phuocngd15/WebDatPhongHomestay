using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaChepFinal2.Data;
using CaChepFinal2.Data.DataModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatPhongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<DatPhong> listdatphong;

        public DatPhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DatPhongs
        public IActionResult Index(DatPhongIndexVM reservation, string sortOrder)
        {
            ViewData["NameSortParm"] = sortOrder == "name_desc" ? "name" : "name_desc";
            ViewData["DateNhanSortParm"] = sortOrder == "DateNhan" ? "datenhan_desc" : "DateNhan";
            ViewData["DateTraSortParm"] = sortOrder == "DateTra" ? "datetra_desc" : "DateTra";
            ViewData["TongTienSortParm"] = sortOrder == "TongTien" ? "TongTien_desc" : "TongTien";

            if (reservation.CMND == null && reservation.ThoiGianNhan ==default)
            {
                listdatphong = sortOrder switch
                {
                    "name_desc" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'TenNguoiDat', N'D';"),
                    "DateNhan" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'ThoiGianNhanPhongDuKien', N'I';"),
                    "datenhan_desc" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'ThoiGianNhanPhongDuKien', N'D';"),
                    "DateTra" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'ThoiGianTraPhongDuKien', N'I';"),
                    "datetra_desc" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'ThoiGianTraPhongDuKien', N'D';"),
                    "TongTien_desc" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'TongTien', N'D';"),
                    "TongTien" => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'TongTien', N'I';"),
                    _ => _context.DatPhongs.FromSqlRaw(
                        $"EXECUTE dbo.GetSortedDatPhongsBySomthing N'TenNguoiDat', N'I';")
                };
            }

            var cmndSqlParameter = new SqlParameter {ParameterName = "@Cmnd", SqlDbType = SqlDbType.NVarChar, SqlValue = reservation.CMND};
            var thoiSqlParameter = new SqlParameter {ParameterName = "@ThoiGianNhanPhongDuKien", SqlDbType = SqlDbType.VarChar, SqlValue = reservation.ThoiGianNhan.Date};
            
            if (reservation.CMND != null && reservation.ThoiGianNhan==default)
                listdatphong = _context.DatPhongs.FromSqlRaw($"EXECUTE dbo.SearchDatPhongsBySomthing @Cmnd ", cmndSqlParameter);
            else if (reservation.CMND == null && reservation.ThoiGianNhan != default)
                listdatphong = _context.DatPhongs.FromSqlRaw($"EXECUTE dbo.SearchDatPhongsBySomthing @ThoiGianNhanPhongDuKien = '{reservation.ThoiGianNhan.Date}' ");
            else if(reservation.CMND != null && reservation.ThoiGianNhan != default)
            {
                listdatphong = _context.DatPhongs.FromSqlRaw($"EXECUTE dbo.SearchDatPhongsBySomthing @Cmnd, @ThoiGianNhanPhongDuKien = '{reservation.ThoiGianNhan.Date}'", cmndSqlParameter, thoiSqlParameter);
            }



            var GetDataforReservation2 = new DatPhongIndexVM
            {
                LisDatPhongs = listdatphong.ToList()
            };
            return View(GetDataforReservation2);
        }

        // GET: Admin/DatPhongs/Details/5
        public DatPhongDetailsMD OnetDatPhongDetialsMd { get; set; }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datphong = _context.DatPhongs.FromSqlRaw($" EXECUTE dbo.GetOneDatPhongById @Id={id}").ToList()[0];

            var chitietdatphong = _context.ChiTietDatPhongs
                .FromSqlRaw($" EXECUTE dbo.GetChiTietDatPhong_ByIdDatPhong @Id={id}").ToList();
            foreach (var i in chitietdatphong)
            {
                var phong = _context.Phongs.FromSqlRaw($"EXECUTE dbo.GetOnePhongById {i.PhongId}").ToList();
                i.Phong = phong[0];
                var trangthai = _context.TrangThais.FromSqlRaw($"EXECUTE dbo.GetOneTrangThaiById {i.TrangThaiId}").ToList();
                i.TrangThai = trangthai[0];
            }

            var chiteTietDichVuDatPhongs = _context.ChiTietDichVuDatPhongs
                .FromSqlRaw($" EXECUTE dbo.GetChiTietDichVuByIdPhong @Id={id}").ToList();
            foreach (var i in chiteTietDichVuDatPhongs)
            {
                var dichvu = _context.DichVus.FromSqlRaw($"EXECUTE dbo.GetOneDichVuById {i.DichVuId}").ToList();
                i.DichVu = dichvu[0];
            }


            OnetDatPhongDetialsMd = new DatPhongDetailsMD
            {
                DatPhong = datphong,
                ChiTietDatPhongs = chitietdatphong,
                ChiTietDichVuDatPhongs = chiteTietDichVuDatPhongs,
            };
            if (OnetDatPhongDetialsMd.DatPhong == null)
            {
                return NotFound();
            }

            return View(OnetDatPhongDetialsMd);

        }
        // detail nay la nut nhan phong, thanh toan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, DatPhongDetailsMD abfromView)
        {// id này lưu phongid vì nhận từng phòng.
            if (ModelState.IsValid)
            {
                try
                {
                    var listChiTietDatPhongFromDb = _context.ChiTietDatPhongs
                        .FromSqlRaw($"EXECUTE dbo.GetChiTietDatPhongBy_IdDatPhong_IdPhong_ThoiGian @DatPhongId = {abfromView.DatPhong.Id} ,@PhongId ={id}")
                        .ToList();
                    foreach (var i in listChiTietDatPhongFromDb)
                    {
                        switch (i.TrangThaiId)
                        {
                            case 1:
                                i.TrangThaiId = 2;
                                break;
                            case 2:
                                i.TrangThaiId = 3;
                                break;
                            case 3:
                                break;
                            default:
                                break;
                        }
                        _context.Update(i);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatPhongExists(abfromView.DatPhong.Id))
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

            return RedirectToAction(nameof(Index));

        }
        

        // GET: Admin/DatPhongs/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datPhong = await _context.DatPhongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datPhong == null)
            {
                return NotFound();
            }

            return View(datPhong);
        }

        // POST: Admin/DatPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datPhong = await _context.DatPhongs.FindAsync(id);
            _context.DatPhongs.Remove(datPhong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatPhongExists(int id)
        {
            return _context.DatPhongs.Any(e => e.Id == id);
        }
    }
}
