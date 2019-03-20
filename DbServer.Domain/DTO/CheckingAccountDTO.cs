using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServer.Api.DTO
{
    /// <summary>
    /// DTO Class Checking Account
    /// </summary>
    public class CheckingAccountDTO
    {
        /// <summary>
        /// Account Number
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Account Balance
        /// </summary>
        public decimal Balance { get; set; }
    }
}
