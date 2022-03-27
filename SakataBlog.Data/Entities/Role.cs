using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class Role : BaseTimeStamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        //relation
        public List<UserInRole> UserInRoles { get; set; }

        public List<RoleInPermission> RoleInPermissions { get; set; }
    }
}