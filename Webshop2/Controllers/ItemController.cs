using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using Webshop2.Models;

namespace Webshop2.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int id)
        {
            // id -> kategorijas ID
            var model = new HomeModel();
            model.Categories = CategoryManager.GetAll().Select(u => u.ToModel()).ToList(); // izrādās tam u. nav jābūt kā extension
            //TODO: preču atlasi no DB, izmantojot ItemManager. Tikai konkrētās preces, kas atbilst kategorijas ID
            model.Items = ItemManager.GetByCategory(id).Select(u => u.ToModel()).ToList();
            foreach (var cat in model.Categories)
            {
                cat.ItemCount = CategoryManager.GetItemCount(cat.Id);
            }

            return View(model);
        }

        public IActionResult List()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            var items = ItemManager.GetAll().Select(u => u.ToModel()).ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            //TODO: Pievienot preci grozam
            UserCartManager.Create(HttpContext.Session.GetUserId(), id);
            return RedirectToAction("MyCart", "Account");
        }


        [HttpGet]
        public IActionResult AddItem()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            var model = new ItemModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddItem(ItemModel model)
        {
            if(ModelState.IsValid)
            {
                var category = CategoryManager.Get(model.CategoryId);
                if(category == null)
                {
                    ModelState.AddModelError("cat", "Category not found!");
                }
                else
                {
                    ItemManager.Create(model.Name, model.Description, model.Image, model.CategoryId, model.Price);
                    return RedirectToAction(nameof(List));
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                //return RedirectToAction("Index", "Home"); Var tā
                return NotFound(); // parāda, ka tāda lapa neeksistē (404). Drošāk
            }
            ItemManager.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}