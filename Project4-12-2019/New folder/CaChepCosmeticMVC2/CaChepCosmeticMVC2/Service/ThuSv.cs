using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public partial class ThuSv : IThu
    {
        private readonly ApplicationDbContext _context;

        public ThuSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Thu a)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Thu> GetAll()
        {
            throw new NotImplementedException();
        }

        public Thu GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(Thu a)
        {
            throw new NotImplementedException();
        }
    }
}
