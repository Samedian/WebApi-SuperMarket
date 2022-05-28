using Entities;
using MarketRepository;
using System;
using System.Collections.Generic;

namespace MarketService
{
    public class ItemService : IItemService
    {
        IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public List<ItemEntity> GetItem()
        {
            List<ItemEntity> itemEntities = _itemRepository.GetItem();
            return itemEntities;

        }

        public int ItemPurchaseAdd(ItemPurchaseSell itemPurchaseSell)
        {
            int res = _itemRepository.ItemPurchaseAdd(itemPurchaseSell);
            return res;
        }

        public int ItemSaleAdd(ItemPurchaseSell itemPurchaseSell)
        {
            int res = _itemRepository.ItemSaleAdd(itemPurchaseSell);
            return res;
        }
    }
}
