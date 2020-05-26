using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            //realizēt saglabāšanu DB tabulā
            using(var db = new DbContext2())
            {

                db.UserCart.Add(new UserCart()
                { 
                      UserId = userId,
                      ItemId = itemId,
                });
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (var db = new DbContext2())
            {
                db.UserCart.Remove(db.UserCart.FirstOrDefault(u => u.ItemId == id));
                db.SaveChanges();
            }
        }
        public static void Clear(int userId)
        {
            using (var db = new DbContext2())
            {
                //foreach(var i in db.UserCart.Where(u => u.UserId == userId))
                //{
                db.UserCart.RemoveRange(db.UserCart.Where(c => c.UserId == userId));
                //}
              
                db.SaveChanges();
            }
        }
        public static List<UserCart> GetByUser(int userId)
        {
            using(var db = new DbContext2())
            {
                var userCart = db.UserCart.Where(c => c.UserId == userId)
                    .Join(db.Items, c => c.ItemId, i => i.Id, (c,i) => new UserCart()
                    {
                        Item = i
                    }).ToList();
                
                return userCart;
            }
        }
    }
}
