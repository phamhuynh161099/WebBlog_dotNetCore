using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakataBlog.Admin.Controllers
{
    [Route("/file-manager")]
    public class FileManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}