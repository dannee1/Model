using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Domain.Interfaces
{
    public interface ICheckingAccountRepository
    {
        void Insert(CheckingAccount obj);

        void Update(CheckingAccount obj);

        void Remove(int id);

        CheckingAccount Select(int id);

        IList<CheckingAccount> SelectAll();

        CheckingAccount SelectByNumber(string number);
    }
}
