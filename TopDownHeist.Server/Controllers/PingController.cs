using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TopDownHeist.Server.Controllers
{
    public class PingController : Controller
    {
        public IActionResult Index()
        {
            return Json(new { Message = "Pong!" });
        }
    }
}