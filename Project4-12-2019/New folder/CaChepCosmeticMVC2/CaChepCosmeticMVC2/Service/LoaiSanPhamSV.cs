using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public class LoaiSanPhamSV:ILoaiSanPham
    {
        private readonly ApplicationDbContext _context;
        public LoaiSanPhamSV(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(LoaiSanPham a)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSanPham> GetAll()
        {
            return _context.LoaiSanPhams.FromSqlRaw("EXECUTE dbo.GetAllSanPham");
        }
        public LoaiSanPham GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(LoaiSanPham a)
        {
            throw new NotImplementedException();
        }
    }
}
