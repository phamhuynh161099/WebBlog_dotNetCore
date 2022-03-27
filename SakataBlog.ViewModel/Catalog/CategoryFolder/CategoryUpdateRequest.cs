using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.CategoryFolder
{
    public class CategoryUpdateRequest
    {
        public int Id { get; set; }
        public int? ParentId { set; get; }
        public string CategoryName { get; set; }
        public string SeoMeta { get; set; }
    }
}