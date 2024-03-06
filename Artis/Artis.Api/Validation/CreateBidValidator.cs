using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class CreateBidValidator : AbstractValidator<CreateBid>
    {
        public CreateBidValidator()
        {
            RuleFor(x => x.Amount).NotNull();
            RuleFor(x => x.ItemId).NotNull();
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
