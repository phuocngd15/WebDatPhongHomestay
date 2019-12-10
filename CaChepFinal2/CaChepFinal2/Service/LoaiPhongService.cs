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
    public class LoaiPhongService : ILoaiPhong
    {
         private readonly ApplicationDbContext _context;

        public LoaiPhongService(ApplicationDbContext context)
        {
            _context = context;
        }

        void ILoaiPhong.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void ILoaiPhong.Edit(LoaiPhong LoaiPhong)
        {
            throw new NotImplementedException();
        }

        IQueryable<LoaiPhong> ILoaiPhong.GetAll()
        {
            throw new NotImplementedException();
        }

        LoaiPhong ILoaiPhong.GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        void ILoaiPhong.New(LoaiPhong LoaiPhong)
        {
            throw new NotImplementedException();
        }
    }
}
