using Artis.Api.Mappers;
using Artis.Api.Validation;
using Artis.Data.Sql;
using Artis.IServices.Item;
using Artis.IServices.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Artis.Api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ItemController : Controller
    {
        private readonly ArtisDbContext _context;
        private readonly IItemService _itemService;

        public ItemController(ArtisDbContext context, IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        [HttpGet("{id:min(1)}", Name = "GetAuctionItem")]
        public async Task<IActionResult> GetAuctionItem(int id)
        {
            var item = await _itemService.GetAuctionItem(id);
            if (item != null)
            {
                return Ok(ItemToItemViewModelModelMapper.ItemToItemVievModel(item));
            }
            return NotFound();
        }

        [HttpGet("category/{id:min(1)}", Name = "GetAuctionItemsByCategory")]
        public async Task<IActionResult> GetAuctionItemsByCategory(int id)
        {
            var items = await _itemService.GetAuctionItemsByCategory(id);
            if (items.Count != 0)
            {
                return Ok(items.Select(x => ItemToItemViewModelModelMapper.ItemToItemVievModel(x)).ToList());
            }
            return NotFound();
        }

        [HttpGet("user/{id:min(1)}", Name = "GetAuctionItemsByUser")]
        public async Task<IActionResult> GetAuctionItemsByUser(int id)
        {
            var items = await _itemService.GetAuctionItemsByUser(id);
            if (items.Count != 0)
            {
                return Ok(items.Select(x => ItemToItemViewModelModelMapper.ItemToItemVievModel(x)).ToList());
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateAuctionItem createItem)
        {
            var item = await _itemService.CreateAuctionItem(createItem);
            return Created(item.ItemId.ToString(), ItemToItemViewModelModelMapper.ItemToItemVievModel(item));
        }

        [ValidateModel]
        [HttpPatch("edit/{id:min(1)}", Name = "EditAuctionItem")]
        public async Task<IActionResult> EditAuctionItem([FromBody] EditAuctionItem editItem, int id)
        {
            await _itemService.EditAuctionItem(editItem, id);
            return NoContent();
        }
    }
}
