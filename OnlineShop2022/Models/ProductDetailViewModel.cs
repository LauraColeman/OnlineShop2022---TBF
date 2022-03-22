
using OnlineShop2022.Models;   
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OnlinseShop2022.Models
{
    public class ProductDetailViewModel
    {
        public List<ProductModel>? Products { get; set; }
        public SelectList? Categories { get; set; }
        public CategoryModel? Category { get; set; }
        public string? SearchString { get; set; }
    }
}
