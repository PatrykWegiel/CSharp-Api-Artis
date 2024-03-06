using Artis.Domain.DomainExceptions;
using System;
using Xunit;

namespace Artis.Domain.Tests
{
    public class UserTest
    {
        [Theory]
        [InlineData("1234567890")]
        [InlineData("12345abc")]
        public void CreateUser_Return_throws_InvalidPhoneNumberException(string phonenumber)
        {
            Assert.Throws<InvalidPhoneNumberException>(() => new Domain.User.User(
                "Username",
                "Name",
                "Surname",
                phonenumber,
                "Email",
                DateTime.UtcNow.AddDays(-1)));
        }

        [Fact]
        public void CreateUser_Return_Correct_Result()
        {
            DateTime birthDate = DateTime.UtcNow.AddDays(-1);
            var user = new Domain.User.User(
                "Username",
                "Name",
                "Surname",
                "12345679",
                "Email",
                birthDate);

            Assert.Equal("Username", user.UserName);
            Assert.Equal("Name", user.Name);
            Assert.Equal("Surname", user.Surname);
            Assert.Equal("12345679", user.PhoneNumber);
            Assert.Equal("Email", user.Email);
            Assert.Equal(birthDate, user.BirthDate);
        }
    }
}
