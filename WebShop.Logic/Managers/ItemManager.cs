using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class ItemManager
    {
        public static List<Items> GetByCategory(int id)
        {
            // TODO: realizēt atlasi no DB
            using (var db = new DbContext2())
            {
                //no datubāzes datiem uztaisa List, kas kārtots pēc vārda
                return db.Items.Where(c => c.CategoryId == id).OrderBy(i => i.Price).ToList();
            }
            
        }
        public static List<Items> GetAll()
        {
            // TODO: realizēt atlasi no DB
            using (var db = new DbContext2())
            {
                //no datubāzes datiem uztaisa List, kas kārtots pēc vārda
                return db.Items.OrderBy(i => i.CategoryId).ToList();
            }
            
        }
        public static void Create(string name, string description, string image, int categoryId, decimal price)
        {
            using(var db = new DbContext2())
            {
                db.Items.Add(new Items()
                {
                    Name = name,
                    Description = description,
                    CategoryId = categoryId,
                    Image = image,
                    Price = price,

                });
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using(var db = new DbContext2())
            {
                db.Items.Remove(db.Items.Find(id));
                db.SaveChanges();
            }
        }
    }
}
