using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9_rcroft1_2.Models;
using Mission9_rcroft1_2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Controllers
{
    public class HomeController : Controller
    {

        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int PageBook = 1)
        {
            int pageSize = 10;

            var x = new BookStoreViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((PageBook - 1) * pageSize)
                .Take(pageSize),

                BookInfo = new BookInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = PageBook
                }
            };
            return View(x);
        }
    }
}
