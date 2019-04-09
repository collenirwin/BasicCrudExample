using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}