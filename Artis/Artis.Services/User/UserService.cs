using Artis.IData.User;
using Artis.IServices.User;
using Artis.IServices.Requests;
using System.Threading.Tasks;

namespace Artis.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<Domain.User.User> GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }
        public async Task<Domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new Domain.User.User
                (
                createUser.UserName,
                createUser.Name,
                createUser.Surname,
                createUser.PhoneNumber,
                createUser.Email,
                createUser.BirthDate
                );
            user.UserId = await _userRepository.CreateUser(user);
            return user;
        }
        public async Task EditUser(EditUser editUser, int id)
        {
            var user = await _userRepository.GetUser(id);
            user.EditUser(
                editUser.UserName,
                editUser.Name,
                editUser.Surname,
                editUser.PhoneNumber,
                editUser.Email);
            await _userRepository.EditUser(user);
        }
    }
}
