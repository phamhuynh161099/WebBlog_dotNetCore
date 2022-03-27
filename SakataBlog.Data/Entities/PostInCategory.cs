using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class PostInCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}