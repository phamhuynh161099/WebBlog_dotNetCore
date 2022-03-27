using SakataBlog.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.ViewModel.Catalog.PostFolder
{
    public class GetManagePostPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}