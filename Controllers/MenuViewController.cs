using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fanap.Plus.Product_Management.Controllers
{
    public class MenuViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}