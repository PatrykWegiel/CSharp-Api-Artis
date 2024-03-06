using Artis.Api.BindingModels;
using FluentValidation;

namespace Artis.Api.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Surname).NotNull();
            RuleFor(x => x.PhoneNumber).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
        }
    }
}
