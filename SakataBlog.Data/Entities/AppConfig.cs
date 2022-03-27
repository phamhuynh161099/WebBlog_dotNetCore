using SakataBlog.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Entities
{
    public class AppConfig : BaseTimeStamp
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}