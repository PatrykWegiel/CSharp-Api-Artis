using Artis.Domain.DomainExceptions;
using Artis.IData.User;
using Artis.IServices.User;
using Artis.IServices.Requests;
using Artis.Services.User;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Artis.Services.Tests
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("1234abc89")]
        public void CreateUser_Returns_throws_InvalidUserException(string phonenumber)
        {
            var user = new CreateUser
            {
                UserName = "Username",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = phonenumber,
                Email = "Email",
                BirthDate = DateTime.UtcNow.AddDays(-1)
            };

            Assert.ThrowsAsync<InvalidPhoneNumberException>(() => _userService.CreateUser(user));
        }

        [Fact]
        public async void CreateUser_Returns_Correct_Response()
        {
            int expectedResult = 0;
            var user = new CreateUser
            {
                UserName= "Username",
                Name = "Name",
                Surname= "Surname",
                PhoneNumber = "12345679",
                Email = "Email",
                BirthDate = DateTime.UtcNow.AddDays(-1)
            };
            _userRepositoryMock.Setup(x => x.CreateUser(new Domain.User.User(
                user.UserName,
                user.Name,
                user.Surname,
                user.PhoneNumber,
                user.Email,
                user.BirthDate))).Returns(Task.FromResult(expectedResult));

            var result = await _userService.CreateUser(user);

            Assert.IsType<Domain.User.User>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.UserId);
        }
    }
}
