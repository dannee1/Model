using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DbServer.Domain.Entities
{
    public class CheckingAccount : BaseEntity
    {
        /// <summary>
        /// Account Number
        /// </summary>
        public string Number { get; set; }

        #region Not Mapped

        [NotMapped]
        public decimal Credits { get; set; }

        [NotMapped]
        public decimal Debits { get; set; }

        [NotMapped]
        public decimal Balance { get { return Credits - Debits; } }

        #endregion 
    }
}
