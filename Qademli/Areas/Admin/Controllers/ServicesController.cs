using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Qademli.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ServicesController : Controller
    {
        public IActionResult Universities()
        {
            return View();
        }
        public IActionResult LanguageCenter()
        {
            return View();
        }
        public IActionResult VisaPermit()
        {
            return View();
        }
        public IActionResult IELETTest()
        {
            return View();
        }
        public IActionResult Housing()
        {
            return View();
        }
    }
}
