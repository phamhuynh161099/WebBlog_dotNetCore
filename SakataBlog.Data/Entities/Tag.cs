using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class Tag : BaseTimeStamp
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public string TagName { get; set; }
        public string SeoMeta { get; set; }

        //ralation
        public List<PostInTag> PostInTags { get; set; }
    }
}