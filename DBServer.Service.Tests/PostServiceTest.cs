using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service;
using Moq;
using System;
using Xunit;

namespace DBServer.Service.Tests
{
    public class PostServiceTest
    {
        private PostService _PostService;

        /// <summary>
        /// Contructor
        /// </summary>
        public PostServiceTest()
        {
            var checkingAccountRepository = new Mock<ICheckingAccountRepository>();
            checkingAccountRepository.Setup(x => x.SelectByNumber("111")).Returns((string i) =>
            {
                return new CheckingAccount()
                {
                    Id = 1,
                    Number = "111"
                };
            });

            checkingAccountRepository.Setup(x => x.SelectByNumber("222")).Returns((string i) =>
            {
                return new CheckingAccount()
                {
                    Id = 1,
                    Number = "222"
                };
            });

            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.Select(1)).Returns((int i) =>
            {
                return new Post()
                {
                    Id = 1,
                    IDOriginAccount = 1,
                    IDDestinationAccount = 2,
                    Value = 200,
                };
            });

            _PostService = new PostService(checkingAccountRepository.Object, postRepository.Object);
        }

        /// <summary>
        /// To test Post insertion 
        /// </summary>
        [Fact]
        public void ShouldInsertObject()
        {
            var obj = new Post() {
                OriginAccountNumber = "111",
                DestinationAccountNumber = "222",
                Value = 100
            };
            var result = _PostService.Insert(obj);
            Assert.Equal(100, result.Value);
        }
    }
}
