using DbServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Service.Interface
{
    public interface ICheckingAccountService
    {
        CheckingAccount Insert(CheckingAccount obj);

        CheckingAccount Update(CheckingAccount obj);

        void Delete(int id);

        IList<CheckingAccount> Select();

        CheckingAccount SelectByNumber(string numero);
    }
}
