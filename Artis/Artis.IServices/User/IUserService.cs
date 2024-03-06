using System.Threading.Tasks;
using Artis.IServices.Requests;

namespace Artis.IServices.User
{
    public interface IUserService
    {
        Task<Domain.User.User> GetUser(int id);
        Task<Domain.User.User> CreateUser(CreateUser user);
        Task EditUser(EditUser user, int id);
    }
}
