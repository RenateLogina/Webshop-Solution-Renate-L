using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Webshop2.Models;
using WebShop.Logic;
using WebShop.Logic.DB;

namespace Webshop2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeModel();
            //TODO: jāatlasa visas kategorijas no DB CategoryManager
            //model.Categories = new List<CategoryModel>();// bija tā <- tas nav vajadzīgs
            model.Items = new List<ItemModel>();
            //pilns kategoriju lists
            model.Categories = CategoryManager.GetAll().Select(u => u.ToModel()).ToList(); // izrādās tam u. nav jābūt kā extension
            foreach(var cat in model.Categories)
            {
                cat.ItemCount = CategoryManager.GetItemCount(cat.Id);
            }

            return View(model);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
