using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public class CapBacTheSv : ICapBacThe
    {
        private readonly ApplicationDbContext _context;

        public CapBacTheSv(ApplicationDbContext context)
        {
            _context = context;
        }

        //public List<CapBacThe> GetAll()
        //{
        //   // return _context.CapBacThe.FromSqlRaw("EXECUTE dbo.GetAllSanPham").ToList();

        //}


        public IEnumerable<CapBacThe> GetAll()
        {
            throw new NotImplementedException();
        }

        public CapBacThe GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CapBacThe> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(CapBacThe a)
        {
            throw new NotImplementedException();
        }

        public void Edit(CapBacThe a)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
