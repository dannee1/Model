using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DbServer.Domain.Entities
{
    public class Post : BaseEntity
    {
        public int IDOriginAccount { get; set; }

        public int IDDestinationAccount { get; set; }

        public decimal Value { get; set; }

        #region NotMapped
        [NotMapped]
        public string OriginAccountNumber { get; set; }
        [NotMapped]
        public string DestinationAccountNumber { get; set; }
        #endregion
    }
}
