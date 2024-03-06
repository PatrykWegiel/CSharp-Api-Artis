using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class EditBidValidator : AbstractValidator<EditBid>
    {
        public EditBidValidator()
        {
            RuleFor(x => x.Amount).NotNull();
        }
    }
}
