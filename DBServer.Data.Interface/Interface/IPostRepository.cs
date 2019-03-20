using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Domain.Interfaces
{
    public interface IPostRepository
    {
        void Insert(Post obj);

        void Update(Post obj);

        void Remove(int id);

        Post Select(int id);

        IList<Post> SelectAll();

        IList<Post> SelectByCheckingAccount(int idAccount);

        decimal SumCredit(int idAccount);
        decimal SumDebit(int idAccount);

    }
}
