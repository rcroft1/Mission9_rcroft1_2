using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_rcroft1_2.Infrastructure;
using Mission9_rcroft1_2.Models;

namespace Mission9_rcroft1_2.Pages
{
    public class AddBookModel : PageModel
    {

        private IBookStoreRepository repo { get; set; }

        public AddBookModel (IBookStoreRepository temp)
        {
            repo = temp;
        }

        // creating a basket of book and its line items

        public Basket basket { get; set; }


        public void OnGet()
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookID)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == BookID);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage();
        }
    }
}
