using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.System.RoleFolder
{
    public class RoleUpdateRequest
    {
        public string Name { get; set; }
        public int[] Permissions { get; set; }
    }
}