using System.Collections.Generic;
using CaChepCosmeticMVC2.Models.DataModels;
namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IAccount
    {
        IEnumerable<Account> GetAll();
        Account GetOneById(int? id);
        void New(Account a);
        void Edit(Account a);
        void Delete(int id);
    }
}