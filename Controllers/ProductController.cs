using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AJAX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AJAX.Controllers
{
    public class ProductController : Controller
    {
        private List<CommentViewModel> _comments;

        public ProductController(List<CommentViewModel> comments)
        {
            _comments = comments;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = new Product() { Name = "Product-1", Price = Convert.ToDecimal(19.99), Quantity = 15 };

            return View(product);
        }

        [HttpGet]
        public IActionResult GetCommnetsByProduct()
        {
            return Json(data: _comments);
        }

        [HttpPost]
        public IActionResult AddCommentToProduct(string comment)
        {
            var productComment = new CommentViewModel() { CustomerName = "Furkan Aydın", Comment = comment };
            _comments.Add(productComment);

            return Json(data: new { isSuccess = true });
        }
    }
}