using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class Post : BaseTimeStamp
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public string ImageFeature { get; set; }
        public string SeoMeta { get; set; }
        public int UserId { get; set; }

        public User User;

        //relation
        public List<PostInCategory> PostInCategories { get; set; }

        public List<PostInTag> PostInTags { get; set; }
    }
}