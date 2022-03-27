using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.CategoryFolder
{
    public class CategoryCreateRequest
    {
        public int? ParentId { set; get; }
        public string CategoryName { get; set; }
        public string SeoMeta { get; set; }
    }
}