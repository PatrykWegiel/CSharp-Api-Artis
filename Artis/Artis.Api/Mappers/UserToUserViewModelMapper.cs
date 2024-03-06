using Artis.Api.ViewModels;

namespace Artis.Api.Mappers
{
    public class UserToUserViewModelModelMapper
    {
        public static UserViewModel UserToUserViewModelModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return userViewModel;
        }
    }
}
