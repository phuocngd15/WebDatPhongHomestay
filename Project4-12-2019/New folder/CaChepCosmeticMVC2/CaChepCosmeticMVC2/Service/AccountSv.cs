using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public class AccountSv : IAccount
    {
        private readonly ApplicationDbContext _context;
        public AccountSv(ApplicationDbContext context)
        {
            _context = context;
        }

        //public List<Account> GetAllSanPhams()
        //{
        //    return _context.Account.FromSqlRaw("EXECUTE dbo.GetAllSanPham").ToList();

        //}
        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(Account a)
        {
            throw new NotImplementedException();
        }

        public void Edit(Account a)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
