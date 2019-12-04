using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class SanPhamSV
    {
        private  readonly ApplicationDbContext _context;
        public SanPhamSV(ApplicationDbContext context)
        {
            _context = context;
        }

        public  List<SanPham> GetAll()
        {
            return _context.SanPhams.FromSqlRaw("EXECUTE dbo.GetAllSanPham").ToList();
            
        }
    }
}
