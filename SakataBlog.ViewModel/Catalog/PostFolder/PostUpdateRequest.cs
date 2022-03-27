using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.PostFolder
{
    public class PostUpdateRequest
    {
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFeature { get; set; }
        public string SeoMeta { get; set; }
        public int[] Tags { set; get; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}