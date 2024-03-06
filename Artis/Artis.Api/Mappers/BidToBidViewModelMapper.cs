using Artis.Api.ViewModels;

namespace Artis.Api.Mappers
{
    public class BidToBidViewModelModelMapper
    {
        public static BidViewModel BidToBidViewModelModel(Domain.Bid.Bid bid)
        {
            var bidViewModel = new BidViewModel
            {
                BidId = bid.BidId,
                UserId = bid.UserId,
                ItemId = bid.ItemId,
                Amount = bid.Amount,
                CreationDate = bid.CreationDate
            };
            return bidViewModel;
        }
    }
}
