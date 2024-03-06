using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Surname).NotNull();
            RuleFor(x => x.PhoneNumber).NotNull();
        }
    }
}
