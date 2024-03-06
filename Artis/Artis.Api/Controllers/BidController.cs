using Artis.Api.Mappers;
using Artis.Api.Validation;
using Artis.Data.Sql;
using Artis.IServices.Bid;
using Artis.IServices.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Artis.Api.Controllers {

    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class BidController : Controller
    {
        private readonly ArtisDbContext _context;
        private readonly IBidService _bidService;

        public BidController(ArtisDbContext context, IBidService bidService)
        {
            _context = context;
            _bidService = bidService;
        }

        [HttpGet("{id:min(1)}", Name = "GetBidById")]
        public async Task<IActionResult> GetBidById(int id)
        {
            var bid = await _bidService.GetBidById(id);
            if(bid != null)
            {
                return Ok(BidToBidViewModelModelMapper.BidToBidViewModelModel(bid));
            }
            return NotFound();
        }

        [HttpGet("user/{id:min(1)}", Name = "GetUserBids")]
        public async Task<IActionResult> GetUserBids(int id)
        {
            var bids = await _bidService.GetUserBids(id);
            if (bids.Count != 0)
            {
                return Ok(bids.Select(x => BidToBidViewModelModelMapper.BidToBidViewModelModel(x)).ToList());
            }
            return NotFound();
        }

        [HttpGet("item/{id:min(1)}", Name = "GetBidsByItem")]
        public async Task<IActionResult> GetBidsByItem(int id)
        {
            var bids = await _bidService.GetBidsByItem(id);
            if (bids.Count != 0)
            {
                return Ok(bids.Select(x => BidToBidViewModelModelMapper.BidToBidViewModelModel(x)).ToList());
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateBid createBid)
        {
            var bid = await _bidService.CreateBid(createBid);
            return Created(bid.BidId.ToString(), BidToBidViewModelModelMapper.BidToBidViewModelModel(bid));
        }

        [ValidateModel]
        [HttpPatch("edit/{id:min(1)}", Name = "EditBid")]
        public async Task<IActionResult> EditAuctionItem([FromBody] EditBid editBid, int id)
        {
            await _bidService.EditBid(editBid, id);
            return NoContent();
        }
    }
}
