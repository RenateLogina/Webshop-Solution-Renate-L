using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Logic.DB;
using Webshop2.Models;

namespace Webshop2.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            if(!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            var cat = CategoryManager.GetAll().OrderBy(c =>c.Id).Select(u => u.ToModel()).ToList();
            return View(cat);
        }
        [HttpGet]
        public IActionResult CreateCat()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            var model = new CategoryModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateCat(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.ParentId.HasValue)
                {
                    var cat = CategoryManager.Get(model.ParentId.Value);
                    if (cat == null)
                    {
                        ModelState.AddModelError("cat", "Category not found!");
                        return View(model);
                    }
                }
                CategoryManager.CreateCat(model.Name, model.ParentId);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            CategoryManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}