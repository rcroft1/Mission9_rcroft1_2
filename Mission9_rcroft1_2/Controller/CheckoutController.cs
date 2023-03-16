using Microsoft.AspNetCore.Mvc;
using Mission9_rcroft1_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Controllers
{
    public class CheckoutController : Controller
    {
        private IAddBookRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController (IAddBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new AddBook());
        }
        [HttpPost]
        public IActionResult Checkout(AddBook purchase)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
