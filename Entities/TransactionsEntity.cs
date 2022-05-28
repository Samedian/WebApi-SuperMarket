using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TransactionsEntity
    {
        public int TransactionId { get; set; }

        public string TransactionType { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }

    }
}
