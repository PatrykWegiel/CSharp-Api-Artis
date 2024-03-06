using Artis.Api.Mappers;
using Artis.Api.Validation;
using Artis.Data.Sql;
using Artis.IServices.Requests;
using Artis.IServices.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Artis.Api.Controllers
{ 
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:min(1)}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if(user != null)
            {
                return Ok(UserToUserViewModelModelMapper.UserToUserViewModelModel(user));
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = await _userService.CreateUser(createUser);
            return Created(user.UserId.ToString(), UserToUserViewModelModelMapper.UserToUserViewModelModel(user));
        }

        [ValidateModel]
        [HttpPatch("edit/{id:min(1)}", Name = "EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int id)
        {
            await _userService.EditUser(editUser, id);
            return NoContent();
        }
    }
}
