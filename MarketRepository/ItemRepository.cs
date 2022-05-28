using Entities;
using Exceptions;
using MarketRepository.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MarketRepository
{
    public class ItemRepository : IItemRepository
    {
        IModelManager _modelManager;
        private readonly cc4Context _cc4Context;
        public ItemRepository(IModelManager modelManager,cc4Context cc4Context)
        {
            _modelManager = modelManager;
            _cc4Context = cc4Context;
        }
        public List<ItemEntity> GetItem()
        {
            using (var context = _cc4Context)
            {
                var items = context.Items.ToList();
                List<ItemEntity> itemEntities = _modelManager.ConvertItem(items);

                return itemEntities;
            }

        }

        public int ItemPurchaseAdd(ItemPurchaseSell itemPurchaseSell)
        {
            const int unknownException = -2;

            Transaction transaction = new Transaction();
            transaction.TransactionType = "Purchase";
            transaction.ItemId = itemPurchaseSell.ItemObject.ItemId;
            transaction.TransactionDate = Convert.ToDateTime(itemPurchaseSell.TransactionDate);
            transaction.Quantity = itemPurchaseSell.ItemObject.Quantity;

            try
            {
                using (var context = _cc4Context)
                {
                    var data = (from d in context.Items where d.ItemId == transaction.ItemId select d).FirstOrDefault();
                    if (data != null)
                    {
                        data.ItemQuantity += transaction.Quantity;
                        context.SaveChanges();
                    }
                    else
                    {
                        MarketRepository.Model.Item item = new MarketRepository.Model.Item();
                        item.ItemId = itemPurchaseSell.ItemObject.ItemId;
                        item.ItemQuantity = itemPurchaseSell.ItemObject.Quantity;
                        item.ItemName = itemPurchaseSell.ItemObject.ItemName;

                        context.Items.Add(item);
                        context.SaveChanges();

                    }

                    context.Transactions.Add(transaction);
                    context.SaveChanges();

                    return 0;
                }
            }
            catch (SqlException ex)
            {
                return ex.Number;
            }
            catch(Exception )
            {
                return unknownException;
            }
        }

        public int ItemSaleAdd(ItemPurchaseSell itemPurchaseSell)
        {
            const int dataNotFound = -1;
            const int unknownException = -2;
            Transaction transaction = new Transaction();
            transaction.TransactionType = "Sale";
            transaction.ItemId = itemPurchaseSell.ItemObject.ItemId;
            transaction.TransactionDate = Convert.ToDateTime(itemPurchaseSell.TransactionDate);
            transaction.Quantity = itemPurchaseSell.ItemObject.Quantity;

            try
            {
                using (var context = _cc4Context)
                {
                    var data = (from d in context.Items where d.ItemId == transaction.ItemId select d).FirstOrDefault();

                    if (data == null && data.ItemQuantity == 0)
                        throw new DataNotFound("Data Not Found");

                    data.ItemQuantity -= itemPurchaseSell.ItemObject.Quantity;
                    context.SaveChanges();

                    context.Transactions.Add(transaction);
                    context.SaveChanges();

                    return 0;
                }
            }
            catch (DataNotFound)
            {
                return dataNotFound;
            }
            catch (SqlException ex)
            {
                return ex.Number;
            }
            catch (Exception)
            {

                return unknownException;
            }
        }
    }
}
