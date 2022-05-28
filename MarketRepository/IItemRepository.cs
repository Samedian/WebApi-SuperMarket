using Entities;
using System.Collections.Generic;

namespace MarketRepository
{
    public interface IItemRepository
    {
        List<ItemEntity> GetItem();
        int ItemPurchaseAdd(ItemPurchaseSell itemPurchaseSell);
        int ItemSaleAdd(ItemPurchaseSell itemPurchaseSell);
    }
}