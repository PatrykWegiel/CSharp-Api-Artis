using Artis.Data.Sql.User;
using Artis.IData.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Artis.Data.Sql.Tests
{
    public class UserRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private ArtisDbContext _context;
        private IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArtisDbContext>();
            optionsBuilder.UseMySQL("server=localhost;userid=root;pwd=yGjCJ87zF6;port=3306;database=artis_db;");
            _context = new ArtisDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task AddUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("username", "name", "surname", "12345679", "email@email.com", DateTime.UtcNow);

            var userId = await _userRepository.CreateUser(user);

            var createdUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(createdUser);

            _context.User.Remove(createdUser);
            await _context.SaveChangesAsync();
        }

    }

}
