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
    public class PostService : IPostService
    {
        private ICheckingAccountRepository _checkingAccountRepository;
        private IPostRepository _repository;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_checkingAccountRepository">Checking Account Repository Injection</param>
        /// <param name="_postRepository">Checking Account Repository Injection</param>
        public PostService(ICheckingAccountRepository checkingAccountRepository, IPostRepository _postRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
            _repository = _postRepository;
        }

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="obj">post data</param>
        /// <returns>Return a post object</returns>
        public Post Insert(Post obj)
        {
            var originAccount = _checkingAccountRepository.SelectByNumber(obj.OriginAccountNumber);
            var destinationAccount = _checkingAccountRepository.SelectByNumber(obj.DestinationAccountNumber);
            obj.IDOriginAccount = originAccount.Id;
            obj.IDDestinationAccount = destinationAccount.Id;
            _repository.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Update a new post
        /// </summary>
        /// <param name="obj">post data</param>
        /// <returns>Return a post object</returns>
        public Post Update(Post obj)
        {
            _repository.Update(obj);
            return obj;
        }

        /// <summary>
        /// Select all Posts
        /// </summary>
        /// <returns></returns>
        public IList<Post> Select() => _repository.SelectAll();

        /// <summary>
        /// Select a Post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post Select(int id)
        {
            return _repository.Select(id);
        }
    }
}
