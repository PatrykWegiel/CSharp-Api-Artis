using Artis.Api.ViewModels;
using Artis.Api.BindingModels;
using Artis.Data.Sql;
using Artis.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Artis.Api.Validation;

namespace Artis.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserV1Controller : Controller
    {
        private readonly ArtisDbContext _context;

        public UserV1Controller(ArtisDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:min(1)}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User
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

            return Created(user.UserId.ToString(), new UserViewModel
            {
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{id:min(1)}", Name = "EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
            user.UserName = editUser.UserName;
            user.Name = editUser.Name;
            user.Surname = editUser.Surname;
            user.PhoneNumber = editUser.PhoneNumber;
            user.Email = editUser.Email;
            user.EditionDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
