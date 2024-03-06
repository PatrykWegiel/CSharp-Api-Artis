using System.Threading.Tasks;

namespace Artis.IData.User
{
    public interface IUserRepository
    {
        Task<Domain.User.User> GetUser(int id);
        Task<int> CreateUser(Domain.User.User user);
        Task EditUser(Domain.User.User user);
    }
}
