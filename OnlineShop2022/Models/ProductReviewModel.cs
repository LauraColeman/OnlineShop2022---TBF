using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OnlineShop2022.Models
{
    public class ProductReviewModel
    {
        public ProductModel Product { get; set; }
        public IEnumerable<ReviewModel> Reviews { get; set; }
    }
}
