﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Artis.Api.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
