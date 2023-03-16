using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models
{
    public class Basket
    {
        // making a list of the line items in a basket
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Book Book1, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookID == Book1.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = Book1,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        // methods to remove/clear basket and calculate the total price
        public virtual void RemoveItem (Book book1)
        {
            Items.RemoveAll(x => x.Book.BookID == book1.BookID);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
