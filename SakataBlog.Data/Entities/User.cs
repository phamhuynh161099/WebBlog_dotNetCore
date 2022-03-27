using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class User : BaseTimeStamp
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AvatarImage { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }

        //relation
        public List<UserInRole> UserInRoles { get; set; }

        public List<Post> Posts { get; set; }
    }
}