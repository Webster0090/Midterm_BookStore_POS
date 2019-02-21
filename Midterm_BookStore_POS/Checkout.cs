using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_BookStore_POS
{
    class Checkout
    {
        public List<Book> Cart = new List<Book>();

        public int Quantity { get; set; }
        private readonly double taxRate = 0.06;
        public double GrandTotal { get; set; }
        public double Tax { get; set; }
        public double SubTotal { get; set; }


        public void CalculatingCost()
        {


            foreach (Book q in Cart)
            {

                SubTotal += q.Price * q.Quantity;
                Console.WriteLine();
                Console.WriteLine($"Title: { q.Title}");
                Console.WriteLine($"Author: {q.Author}");
                Console.WriteLine($"Price: ${q.Price}");
                Console.WriteLine($"You ordered: {q.Quantity}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine($"Your subtotal is {SubTotal}");

            double tax = SubTotal * taxRate;
            GrandTotal = SubTotal + tax;

        }

        public void PaymentChoice(double grandTotal)
        {

            bool paymentReturn = true;
            while (paymentReturn == true)
            {
                Console.WriteLine("How will you be paying today? cash, card, or check?");
                string paymentChoice = Console.ReadLine().ToLower();
                if (paymentChoice == "cash")
                {
                    paymentReturn = false;
                    PaymentValidation.Cash(grandTotal);

                }
                else if (paymentChoice == "card")
                {
                    PaymentValidation.Credit(grandTotal);
                    paymentReturn = false;
                }
                else if (paymentChoice == "check")
                {
                    PaymentValidation.Check(grandTotal);
                    paymentReturn = false;

                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand, please write 'cash' 'card' or 'check'.");
                    paymentReturn = true;
                }
            }
        }
    }
}
