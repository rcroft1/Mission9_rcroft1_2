using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models
{
    public interface IAddBookRepository
    {
        IQueryable<AddBook> Purchase { get; }

        void SavePurchase(AddBook purchase);
    }
}
