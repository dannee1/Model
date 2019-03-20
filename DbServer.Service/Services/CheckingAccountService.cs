using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DbServer.Service
{

    public class CheckingAccountService : ICheckingAccountService
    {
        private ICheckingAccountRepository _repository;
        private IPostRepository _postRepo;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_checkingAccountRepository">Checking Account Repository Injection</param>
        /// <param name="_postRepository">Checking Account Repository Injection</param>
        public CheckingAccountService(ICheckingAccountRepository _checkingAccountRepository, IPostRepository _postRepository)
        {
            _repository = _checkingAccountRepository;
            _postRepo = _postRepository;
        }

        /// <summary>
        /// Create an Account
        /// </summary>
        /// <param name="obj">Checking Account data</param>
        /// <returns>Return a Cheking Account object</returns>
        public CheckingAccount Insert(CheckingAccount obj)
        {
            _repository.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Update an Account Properties
        /// </summary>
        /// <param name="obj">Checking Account data</param>
        /// <returns>Return a Cheking Account object</returns>
        public CheckingAccount Update(CheckingAccount obj)
        {
            _repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Delete a account
        /// </summary>
        /// <param name="id">index</param>
        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The Id can not be zero.");

            _repository.Remove(id);
        }

        /// <summary>
        /// Select all Accounts
        /// </summary>
        /// <returns>Return a Checking Account List</returns>
        public IList<CheckingAccount> Select() => _repository.SelectAll();

        /// <summary>
        /// Select a Checking Account by Number
        /// </summary>
        /// <param name="number">Account Number</param>
        /// <returns></returns>
        public CheckingAccount SelectByNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException("The number can not be empty.");

            var checkingAccount = _repository.SelectByNumber(number);
            if (checkingAccount != null)
            {
                checkingAccount.Credits = _postRepo.SumCredit(checkingAccount.Id);
                checkingAccount.Debits = _postRepo.SumDebit(checkingAccount.Id);
            }
            return checkingAccount;
        }
    }
}
