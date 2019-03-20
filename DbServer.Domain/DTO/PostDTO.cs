using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServer.Api.DTO
{
    public class PostDTO
    {
        /// <summary>
        /// Origin Account Number
        /// </summary>
        public string OriginAccountNumber { get; set; }
        /// <summary>
        /// Destination Account Number
        /// </summary>
        public string DestinationAccountNumber { get; set; }
        /// <summary>
        /// Transaction Value
        /// </summary>
        public decimal Value { get; set; }
    }
}
