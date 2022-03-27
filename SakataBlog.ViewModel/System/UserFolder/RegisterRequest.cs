﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.System.UserFolder
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int[] Roles { get; set; }
        public IFormFile AvatarImage { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
    }
}