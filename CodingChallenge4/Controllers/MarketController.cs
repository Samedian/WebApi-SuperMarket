using Entities;
using MarketService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {

        IItemService _itemService;
        public MarketController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<ItemEntity> itemEntities= _itemService.GetItem();
            return Ok(itemEntities);
        }

        [HttpPost("Purchase")]
        [Authorize]
        public IActionResult Purchase(ItemPurchaseSell itemPurchaseSell)
        {
            int res = _itemService.ItemPurchaseAdd(itemPurchaseSell);
            if (res == 0)
                return Ok();
            if (res == 49802)
                return NotFound("Database is unavailable at the moment, please retry connection at later time.  ");
            if (res == 49918)
                return NotFound("Cannot process create or update request. Too many create or update operations in progress for subscription. Query sys.dm_operation_stats for pending operations. Wait till pending create/update requests are complete or delete one of your pending create/update requests and retry your request later.");
            else
                return NotFound();
        }


        [HttpPost("Sale")]
        [Authorize]
        public IActionResult Sale(ItemPurchaseSell itemPurchaseSell)
        {
            int res = _itemService.ItemSaleAdd(itemPurchaseSell);
            if (res == 0)
                return Ok();
            if (res == -1)
                return NotFound("Data Not Found");
            else
                return NotFound();
                
        }
    }
}
