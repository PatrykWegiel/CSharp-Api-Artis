using System;

namespace Artis.Api.BindingModels
{
    public class CreateUser
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
    }
}
