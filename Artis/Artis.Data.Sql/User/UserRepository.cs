using System;
using System.Threading.Tasks;
using Artis.IData.User;
using Microsoft.EntityFrameworkCore;

namespace Artis.Data.Sql.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ArtisDbContext _context;

        public UserRepository(ArtisDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.User.User> GetUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
            return new Domain.User.User(
                user.UserId,
                user.UserName,
                user.Email,
                user.Name,
                user.Surname,
                user.PhoneNumber,
                user.RegistrationDate,
                user.EditionDate,
                user.BirthDate,
                user.Banned,
                user.Active);
        }

        public async Task<int> CreateUser (Domain.User.User createUser)
        {
            var user = new DAO.User
            {
                UserName = createUser.UserName,
                Name = createUser.Name,
                Surname = createUser.Surname,
                PhoneNumber = createUser.PhoneNumber,
                Email = createUser.Email,
                BirthDate = createUser.BirthDate,
                RegistrationDate = DateTime.UtcNow,
                EditionDate = DateTime.UtcNow,
                Active = true,
                Banned = false
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }
        public async Task EditUser(Domain.User.User editUser)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == editUser.UserId);
            user.UserName = editUser.UserName;
            user.Name = editUser.Name;
            user.Surname = editUser.Surname;
            user.PhoneNumber = editUser.PhoneNumber;
            user.Email = editUser.Email;
            user.EditionDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
