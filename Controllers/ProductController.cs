using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AJAX.Models;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace AJAX.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("InsertProduct")]
        public IActionResult InsertProduct(ProductViewModel productVM)
        {
            return Json(productVM);
        }
    }
}