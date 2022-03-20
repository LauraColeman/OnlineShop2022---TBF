using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OnlineShop2022.Components
{
    public class UserMenu : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var menuItems = new List<UserMenuItem> { new UserMenuItem()
            {
                DisplayValue = "Order Management",
                ControllerValue = "Order"
            },


             new UserMenuItem()
            {
                DisplayValue = "Your Orders",
                ControllerValue = "Order"
            }};

            return View(menuItems);
        }


    }
 
    public class UserMenuItem
    {
        public string DisplayValue { get; set; }
        public string ControllerValue { get; set; }
    }


}

