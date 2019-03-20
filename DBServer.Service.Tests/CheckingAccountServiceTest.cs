using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service;
using Moq;
using System;
using Xunit;

namespace DBServer.Service.Tests
{
    public class CheckingAccountServiceTest
    {
        private CheckingAccountService _checkingAccountService;

        /// <summary>
        /// Contructor
        /// </summary>
        public CheckingAccountServiceTest()
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

            _checkingAccountService = new CheckingAccountService(checkingAccountRepository.Object, postRepository.Object);
        }

        /// <summary>
        /// To test the Checking Account insertion
        /// </summary>
        [Fact]
        public void ShouldInsertObject()
        {
            var obj = new CheckingAccount() {
                Number = "333"
            };
            var result = _checkingAccountService.Insert(obj);
            Assert.Equal("333", result.Number);
        }

        /// <summary>
        /// To test the Select By Number Method
        /// </summary>
        [Fact]
        public void ShouldReturnObject()
        {
            var result = _checkingAccountService.SelectByNumber("111");
            Assert.Equal("111", result.Number);
        }

        /// <summary>
        /// To teste Select By Number when the number is invalid
        /// </summary>
        [Fact]
        public void ShouldNotReturnObject()
        {
            var result = _checkingAccountService.SelectByNumber("222");
            Assert.Null(result);
        }
    }
}
