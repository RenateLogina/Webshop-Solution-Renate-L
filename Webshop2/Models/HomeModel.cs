using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class HomeModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}
