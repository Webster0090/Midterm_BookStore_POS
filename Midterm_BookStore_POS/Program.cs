using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_BookStore_POS
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentValidation payValidation = new PaymentValidation();
            Checkout checkout = new Checkout();
            bool finalAnswer = true;
            while (finalAnswer == true)
            {
                checkout = DisplayMenu(checkout);
                checkout.PaymentChoice(checkout.GrandTotal);
                PrintReceipt(checkout, checkout.GrandTotal, checkout.Tax, checkout.SubTotal);
                bool isValid = true;
                while (isValid == true)
                {

                    Console.WriteLine("Would you like to make another transaction? y/n");
                    string inputYorN = Console.ReadLine().ToLower();
                    if (inputYorN == "y")
                    {
                        checkout.Cart.Clear();
                        checkout.GrandTotal = 0;
                        checkout.Tax = 0;
                        checkout.SubTotal = 0;
                        Console.Clear();
                        finalAnswer = true;
                        isValid = false;
                    }
                    else if (inputYorN == "n")
                    {
                        Console.WriteLine("Have a great day!");
                        finalAnswer = false;
                        isValid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid try again");
                        isValid = true;
                    }
                }
            }
        }
        public static Checkout DisplayMenu(Checkout c)
        {
            List<Book> Books = new List<Book>();
            Book b = new Book();
            int num = 1;

            Book InSearchofLostTime = new Book("In Search of Lost Time", "Marcel Proust", 22.75, 0);
            Books.Add(InSearchofLostTime);
            Book DonQuixote = new Book("Don Quixote", "Miguel de Cervantes", 29.99, 0);
            Books.Add(DonQuixote);
            Book Ulysses = new Book("Ulysses", "James Joyce", 15.95, 0);
            Books.Add(Ulysses);
            Book TheGreatGatsby = new Book("The Great Gatsby", "F.Scott Fitzgerald", 10.82, 0);
            Books.Add(TheGreatGatsby);
            Book MobyDick = new Book("Moby Dick", "Herman Melville", 9.56, 0);
            Books.Add(MobyDick);
            Book Hamlet = new Book("Hamlet", "William Shakespeare", 12.95, 0);
            Books.Add(Hamlet);
            Book WarandPeace = new Book("War and Peace", "Leo Tolstoy", 11.16, 0);
            Books.Add(WarandPeace);
            Book TheOdyssey = new Book("The Odyssey", "Homer", 14.39, 0);
            Books.Add(TheOdyssey);
            Book Lolita = new Book("Lolita", "Vladimir Nabokov", 17.00, 0);
            Books.Add(Lolita);
            Book OntheRoad = new Book("On the Road", "Jack Kerouac", 14.45, 0);
            Books.Add(OntheRoad);
            Book Breakfastofchampions = new Book("Breakfast of champions", "Kurt Vonnegut", 15.35, 0);
            Books.Add(Breakfastofchampions);
            Book TheAlchemist = new Book("The Alchemist", "Paulo Coelho", 13.89, 0);
            Books.Add(TheAlchemist);

            Console.WriteLine("Please choose a number of the following options:\n");

            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine(num + ". " + Books[i].Title);
                num++;
            }
            bool toMenu = true;
            while (toMenu == true)
            {
                Console.WriteLine("\nPlease enter a menu number");
                int.TryParse(Console.ReadLine(), out int userNumSelectMenu);
                if (userNumSelectMenu > 0 && userNumSelectMenu <= Books.Count)
                {

                    Console.WriteLine("Title: " + Books[userNumSelectMenu - 1].Title);
                    Console.WriteLine("Author: " + Books[userNumSelectMenu - 1].Author);
                    Console.WriteLine("$" + Books[userNumSelectMenu - 1].Price);
                    c.Cart.Add(Books[userNumSelectMenu - 1]);
                    bool isValid = true;
                    while (isValid == true)
                    {

                        bool getQuantity = true;
                        while (getQuantity == true)
                        {
                            Console.WriteLine("Please input the amount of books you'd like to order.");
                            int.TryParse(Console.ReadLine(), out int quantityValidate);
                            if (quantityValidate <= 0)
                            {
                                Console.WriteLine("Wrong input!");
                                getQuantity = true;
                                isValid = true;
                            }
                            else
                            {
                                c.Cart[c.Cart.Count - 1].Quantity = quantityValidate;
                                getQuantity = false;
                                isValid = false;
                            }

                        }
                        toMenu = backToMenu(Books, num, c);
                    }
                }

            }
            return c;
        }
        public static void PrintReceipt(Checkout c, double gt, double tax, double st)
        {
            foreach (Book b in c.Cart)
            {
                Console.WriteLine($"Title: {b.Title} \t\t{b.Quantity} books at ${b.Price}");
                Console.WriteLine($"	By {b.Author}");
                Console.WriteLine();
            }
            tax = c.GrandTotal - c.SubTotal;
            Console.WriteLine($"Subtotal: {c.SubTotal}");
            Console.WriteLine($"Tax: {Math.Round(tax, 2)}");
            Console.WriteLine($"Grand Total: {Math.Round(c.GrandTotal, 2)}");
            Console.WriteLine("Thank you for shopping at ConsoleReadLine(YourBooks)");

        }
        public static bool backToMenu(List<Book> Books, int num, Checkout c)
        {
            Console.WriteLine("\nWould you like to return to the Menu or proceed to Checkout?(Menu or Checkout)");
            string input = Console.ReadLine().ToLower();
            input = input.ToLower();
            bool goOn;
            if (input == "menu")
            {
                goOn = true;
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine(num - 12 + ". " + Books[i].Title);
                    num++;
                }
            }
            else if (input == "checkout")
            {
                goOn = false;
                c.CalculatingCost();
            }
            else
            {
                Console.WriteLine("I don't understand that, let's try again");
                goOn = backToMenu(Books, num, c);
            }
            return goOn;
        }
    }
}
