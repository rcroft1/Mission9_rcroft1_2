using Mission9_rcroft1_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models.ViewModels
{

    // initializing bookstoreviewmdoel
    public class BookStoreViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public BookInfo BookInfo { get; set; }
    }
}
