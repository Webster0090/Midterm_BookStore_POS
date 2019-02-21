using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_BookStore_POS
{
    class Book
    {

        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public Book()
        {

        }
        public Book(string title, string author, double price, int quantity)
        {
            Quantity = quantity;
            Price = price;
            Title = title;
            Author = author;
        }
    }
}
