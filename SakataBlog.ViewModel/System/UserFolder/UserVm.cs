﻿using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.System.UserFolder
{
    public class UserVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        //public string Password { get; set; }
        public string Email { get; set; }

        public string AvatarImage { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }
        public List<ObjItem> Roles { get; set; }
    }
}