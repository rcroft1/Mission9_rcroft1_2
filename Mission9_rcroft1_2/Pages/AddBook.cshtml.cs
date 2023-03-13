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
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public AddBookModel (IBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        // creating a basket of book and its line items

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == BookID);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookID == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
