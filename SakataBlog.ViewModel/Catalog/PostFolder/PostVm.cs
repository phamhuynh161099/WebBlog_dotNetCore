using SakataBlog.ViewModel.Catalog.CategoryFolder;
using SakataBlog.ViewModel.Catalog.TagFolder;
using SakataBlog.ViewModel.Common;
using SakataBlog.ViewModel.System.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.PostFolder
{
    public class PostVm
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public string ImageFeature { get; set; }
        public string SeoMeta { get; set; }

        public string CreatedBy { get; set; }
        public List<ObjItem> Categories { get; set; }
        public List<ObjItem> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}