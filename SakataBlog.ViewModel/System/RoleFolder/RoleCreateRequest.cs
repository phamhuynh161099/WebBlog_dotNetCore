using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.System.RoleFolder
{
    public class RoleCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] Permissions { get; set; }
    }
}