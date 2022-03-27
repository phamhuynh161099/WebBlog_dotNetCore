using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Common
{
    public class SelectItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }

        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}