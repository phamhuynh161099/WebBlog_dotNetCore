using SakataBlog.ViewModel.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.System.RoleFolder
{
    public class RoleVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public List<ObjItem> Permissions { get; set; }
    }
}