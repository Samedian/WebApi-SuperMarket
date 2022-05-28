using Entities;
using System.Collections.Generic;

namespace MarketService
{
    public interface IItemService
    {
        List<ItemEntity> GetItem();
        int ItemPurchaseAdd(ItemPurchaseSell itemPurchaseSell);
        int ItemSaleAdd(ItemPurchaseSell itemPurchaseSell);
    }
}