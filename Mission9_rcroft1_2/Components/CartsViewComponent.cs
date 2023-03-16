using Microsoft.AspNetCore.Mvc;
using Mission9_rcroft1_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Components
{
    // makes the cart at the top of the page
    public class CartsViewComponent : ViewComponent
    {
        private Basket cart;
        public CartsViewComponent(Basket cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
