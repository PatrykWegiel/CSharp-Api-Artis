using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class EditAuctionItemValidator : AbstractValidator<EditAuctionItem>
    {
        public EditAuctionItemValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.StartingPrice).NotNull();
            RuleFor(x => x.ItemName).NotNull();
            RuleFor(x => x.ItemDescription).NotNull();
            RuleFor(x => x.ItemImageHref).NotNull();
            RuleFor(x => x.Condition).NotNull();
            RuleFor(x => x.EndDate).NotNull();
        }
    }
}
