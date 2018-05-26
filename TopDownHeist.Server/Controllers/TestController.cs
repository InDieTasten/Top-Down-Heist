using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TopDownHeist.Server.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Json(new { Message = "Magic just happened" });
        }
    }
}