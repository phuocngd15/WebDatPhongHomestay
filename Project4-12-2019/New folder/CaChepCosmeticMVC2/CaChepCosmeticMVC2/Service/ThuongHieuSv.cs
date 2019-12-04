using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class ThuongHieuSv
    {
        private readonly ApplicationDbContext _context;
        public ThuongHieuSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ThuongHieu> GetAll()
        {
            return _context.ThuongHieus.FromSqlRaw("EXECUTE dbo.GetAllThuongHieu").ToList();

        }
    }
}
