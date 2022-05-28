using System;
using System.Collections.Generic;

#nullable disable

namespace MarketRepository.Model
{
    public partial class Item
    {
        public Item()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
