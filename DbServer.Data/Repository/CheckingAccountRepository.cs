using DbServer.Data.Context;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbServer.Data.Repository
{
    public class CheckingAccountRepository : ICheckingAccountRepository
    {
        private readonly SqlContext _context;

        public CheckingAccountRepository(SqlContext context)
        {
            _context = context;
        }

        public void Insert(CheckingAccount obj)
        {
            _context.Set<CheckingAccount>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(CheckingAccount obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<CheckingAccount>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<CheckingAccount> SelectAll()
        {
            return _context.Set<CheckingAccount>().ToList();
        }

        public CheckingAccount Select(int id)
        {
            return _context.Set<CheckingAccount>().Find(id);
        }

        public CheckingAccount SelectByNumber(string number)
        {
            return _context.Set<CheckingAccount>().FirstOrDefault(p => p.Number == number);
        }
    }
}
