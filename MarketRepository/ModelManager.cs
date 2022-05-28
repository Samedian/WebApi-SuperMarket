using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketRepository
{
    public class ModelManager : IModelManager
    {
        public List<ItemEntity> ConvertItem(List<Model.Item> items)
        {
            List<ItemEntity> itemEntity = new List<ItemEntity>();
            foreach (var data in items)
            {
                ItemEntity item = new ItemEntity();
                item.ItemId = data.ItemId;
                item.ItemName = data.ItemName;
                item.Quantity = data.ItemQuantity;

                itemEntity.Add(item);
            }

            return itemEntity;
        }
    }
}
