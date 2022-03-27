using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class Category : BaseTimeStamp
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public string CategoryName { get; set; }
        public string SeoMeta { get; set; }

        //relation
        public List<PostInCategory> PostInCategories { get; set; }
    }
}