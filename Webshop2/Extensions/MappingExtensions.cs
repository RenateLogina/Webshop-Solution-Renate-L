using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Logic.DB;
using Webshop2.Models;

namespace Webshop2
{
    public static class MappingExtensions
    {
        public static CategoryModel ToModel(this Categories category)
        {
            
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
            };
        }
        public static ItemModel ToModel(this Items u)
        {
            if(u == null)
            {
                return null;
            }
            return new ItemModel()
            {
                Id = u.Id,
                Name = u.Name,
                Price = u.Price,
                Description = u.Description,
                CategoryId= u.CategoryId,
                Image = u.Image,
            };
        }
        public static UserModel ToModel(this Users u)
        {
            if (u == null)
            {
                return null;
            }
            else
            {
                return new UserModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    IsAdmin = u.IsAdmin,
                    //Password = u.Password //tā kā paroli nekur īsti nevajag rādīt, tad to var izlaist, sesijā nesaglabā
                };
            }
        }
    }
}
