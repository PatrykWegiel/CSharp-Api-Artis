using Artis.Api.ViewModels;

namespace Artis.Api.Mappers
{
    public class ItemToItemViewModelModelMapper
    {
        public static ItemViewModel ItemToItemVievModel(Domain.Item.Item item)
        {
            var itemViewModel = new ItemViewModel
            {
                ItemId = item.ItemId,
                CategoryId = item.CategoryId,
                UserId = item.UserId,
                StartingPrice = item.StartingPrice,
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemImageHref = item.ItemImageHref,
                Condition = item.Condition,
                CreationDate = item.CreationDate,
                EndDate = item.EndDate
            };
            return itemViewModel;
        }
    }
}
