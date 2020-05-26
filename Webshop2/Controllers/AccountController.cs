using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebShop.Logic;
using Webshop2.Models;

namespace Webshop2.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Signup()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Signup(UserModel model)
        {
            if(ModelState.IsValid)
            {
                //pārbaudes- vai paroles ir vienādas
                if(model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match!");
                }
                else
                {
                    //atlasa lietotāju no DB pēc e-pasta. Izmantojot UserManager.
                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();
                    if(user != null)
                    {
                        ModelState.AddModelError("user", "User with this email already exists!");
                    }
                    else
                    {
                        //TODO:saglabāt ievadītos datus DB. Izmantojot UserManager
                        UserManager.Create(model.Name, model.Email, model.Password);
                        return RedirectToAction(nameof(SignIn));
                    }
                }

            }
            return View(model);
        }




        [HttpGet]
        public IActionResult Signin()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Signin(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //meklē pēc epasta un paroles no DB izmantojot UserManager
                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();

                if(user == null)
                {
                    ModelState.AddModelError("user", "Wrong email or password!");
                }
                else
                {
                    //saglabā lietotāja datus sesijā
                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);
                    return RedirectToAction("Index", "Home"); // aizsūta uz pašu sākumu
                }
            }
            return View(model);
        }


        public IActionResult MyCart(int userId)
        {
            // TODO: veikt lietotāja groza atlasi no DB, izmantojot UserCartManager.
            var cart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());

            if(cart.Count == 0)
            {
                ModelState.AddModelError("cart", "cart is empty!");
            }

            // TODO: attēlot lietotāja groza saturu.
            var items = cart.Select(c => c.Item.ToModel()).ToList();
            //var items = cart.Select(c => c.Item.ToModel()).Distinct().ToList();


            return View(items);
        }
        public IActionResult Confirm(int userId)
        {
            // TODO: veikt lietotāja groza atlasi no DB, izmantojot UserCartManager.
            UserCartManager.Clear(HttpContext.Session.GetUserId());
            return View();
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();//iebūvētā metode
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {

            UserCartManager.Delete(id);
            return RedirectToAction(nameof(MyCart));
        }
    }
}