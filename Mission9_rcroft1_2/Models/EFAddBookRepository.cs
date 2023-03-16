using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models
{
    public class EFAddBookRepository : IAddBookRepository
    {
        private BookStoreContext context;
        public EFAddBookRepository (BookStoreContext temp)
        {
            context = temp;
        }
        public IQueryable<AddBook> Purchase => context.AddBooks.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(AddBook purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if(purchase.PurchaseId == 0)
            {
                context.AddBooks.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
