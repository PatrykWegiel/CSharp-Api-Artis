using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class CreateAuctionItemValidator : AbstractValidator<CreateAuctionItem>
    {
        public CreateAuctionItemValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.StartingPrice).NotNull();
            RuleFor(x => x.ItemName).NotNull();
            RuleFor(x => x.ItemDescription).NotNull();
            RuleFor(x => x.ItemImageHref).NotNull();
            RuleFor(x => x.Condition).NotNull();
            RuleFor(x => x.EndDate).NotNull();
        }
    }
}
