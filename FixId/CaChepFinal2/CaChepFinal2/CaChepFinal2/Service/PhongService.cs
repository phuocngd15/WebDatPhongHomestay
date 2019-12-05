using Microsoft.EntityFrameworkCore;

using CaChepFinal2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CaChepFinal2.Data.DataModel;

namespace CaChepFinal2.Service
{
    public class PhongService : IPhong
    {
        private readonly ApplicationDbContext _context;

        public PhongService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(LoaiPhong LoaiPhong)
        {
            throw new NotImplementedException();
        }

        public IQueryable<LoaiPhong> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoaiPhong GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(LoaiPhong LoaiPhong)
        {
            throw new NotImplementedException();
        }
    }
}
