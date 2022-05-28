using Entities;
using System.Collections.Generic;

namespace MarketRepository
{
    public interface IModelManager
    {
        List<ItemEntity> ConvertItem(List<Model.Item> items);
    }
}