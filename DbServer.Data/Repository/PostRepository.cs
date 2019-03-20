using DbServer.Data.Context;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbServer.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlContext _context;

        public PostRepository(SqlContext context)
        {
            _context = context;
        }

        public void Insert(Post obj)
        {
            _context.Set<Post>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(Post obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<Post>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<Post> SelectAll()
        {
            return _context.Set<Post>().ToList();
        }

        public IList<Post> SelectByCheckingAccount(int idConta)
        {
            return _context.Set<Post>().Where(p => p.IDOriginAccount == idConta).ToList();
        }

        public Post Select(int id)
        {
            return _context.Set<Post>().Find(id);
        }

        public decimal SumCredit(int idAccount)
        {
            return _context.Set<Post>().Where(p => p.IDDestinationAccount == idAccount).Sum(p => p.Value);
        }

        public decimal SumDebit(int idAccount)
        {
            return _context.Set<Post>().Where(p => p.IDOriginAccount == idAccount).Sum(p => p.Value);
        }
    }
}
