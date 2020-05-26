using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Item name: ")]
        public string Name { get; set; }
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price: ")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Category: ")]
        public int CategoryId { get; set; }

        [Display(Name = "Image: ")]
        public string Image { get; set; }
    }
}
