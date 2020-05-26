using Remotion.Linq.Parsing.ExpressionVisitors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic

{
    public class CategoryManager
    {
        public static List<Categories> GetAll()
        {
            // TODO: realizēt atlasi no DB
            using (var db = new DbContext2())
            {
                //no datubāzes datiem uztaisa List, kas kārtots pēc vārda
                return db.Categories.OrderBy(u => u.Name).ToList();
            }
            //throw new NotImplementedException();
        }
        public static Categories Get(int id)
        {
            using (var db = new DbContext2())
            {
                return db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }
        public static void CreateCat(string name, int? parentId)
        {
            using( var db = new DbContext2())
            {
                db.Categories.Add(new Categories()
                {
                    Name = name,
                    ParentId = parentId,
                });
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (var db = new DbContext2())
            {
                db.Categories.Remove(db.Categories.Find(id));
                db.SaveChanges();
            }
        }
        public static int GetItemCount(int id)
        {
            using(var db = new DbContext2())
            {
                return db.Items.Count(i => i.CategoryId == id);

            }
        }
    }
}
