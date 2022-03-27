using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.TagFolder
{
    public class TagVm
    {
        public int Id { set; get; }
        public string TagName { get; set; }
        public string SeoMeta { get; set; }
        public bool IsShowOnHome { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}