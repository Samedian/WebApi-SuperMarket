using System;
using System.Collections.Generic;

#nullable disable

namespace MarketRepository.Model
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public int? ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Item Item { get; set; }
    }
}
