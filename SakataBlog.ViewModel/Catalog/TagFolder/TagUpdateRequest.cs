using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.TagFolder
{
    public class TagUpdateRequest
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string SeoMeta { get; set; }
    }
}