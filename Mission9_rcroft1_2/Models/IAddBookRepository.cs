using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models
{
    public interface IAddBookRepository
    {
        // making a list of iqueryable for the purchase
        IQueryable<AddBook> Purchase { get; }

        void SavePurchase(AddBook purchase);
    }
}
