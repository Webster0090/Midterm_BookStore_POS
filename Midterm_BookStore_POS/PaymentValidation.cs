using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Midterm_BookStore_POS
{
    class PaymentValidation
    {
        public PaymentValidation()
        {

        }

        public static void Cash(double grandTotal)
        {
            bool getCash = true;
            while (getCash == true)
            {
                Console.WriteLine($"Your total is {Math.Round(grandTotal, 2)}, please type in the amount tendered");
                double.TryParse(Console.ReadLine(), out double cashTaken);
                if (cashTaken < grandTotal)
                {
                    Console.WriteLine("Sorry, you're short on your payment!");
                    getCash = true;
                }
                else
                {
                    getCash = false;
                    double changeBack = cashTaken - grandTotal;
                    Console.WriteLine($"You'll be getting back ${Math.Round(changeBack, 2)} Thank you!. ");
                }
            }
        }

        public static void Credit(double grandTotal)
        {

            // Validating card number---------------------------------------
            Console.WriteLine($"Your grand total will be {Math.Round(grandTotal, 2)}");
            Console.WriteLine("Enter your credit card number");
            bool cardValidator = true;
            while (cardValidator == true)
            {
                Regex cardValid = new Regex(@"(^[0-9]{16})$");
                string cardNumber = Console.ReadLine();
                if (!cardValid.IsMatch(cardNumber))
                {
                    Console.WriteLine("Wrong card number, try again! \n");
                    cardValidator = true;
                }
                else
                    cardValidator = false;
            }
            // Validating the CVV number on the back of the card------------------------------------
            Console.WriteLine("Now please input your CVV number (This number is located on the back of your card)");
            bool cvvValidator = true;
            while (cvvValidator == true)
            {
                Regex CVVValid = new Regex(@"(^[0-9]{3})$");
                string cvvNum = Console.ReadLine();
                if (!CVVValid.IsMatch(cvvNum))
                {
                    Console.WriteLine("Wrong input for the CVV, it should be 3 numerical values. EX: 123 \n");
                    cvvValidator = true;
                }
                else
                    cvvValidator = false;
            }
            // Validating the expiration date----------------------------------------
            Console.WriteLine("Great, we're almost there, now enter your exp date in MM/YYYY format, no special characters!");
            bool expireValidator = true;
            while (expireValidator == true)
            {
                Regex ExpireValid = new Regex(@"(^[0-1]{1}[0-9]{1}[- /.][2]{1}[0]{1}[1-9]{1}[0-9]{1})$");
                string expirationNum = Console.ReadLine();
                if (!ExpireValid.IsMatch(expirationNum))
                {
                    Console.WriteLine("Wrong format, please use MM/YYYY");
                    expireValidator = true;
                }
                else
                {
                    expireValidator = false;

                }
            }

        }
        public static void Check(double grandTotal)
        {
            // Validating check number ---------------------------------
            Console.WriteLine($"Your grand total will be {Math.Round(grandTotal, 2)}");
            Console.WriteLine("Please enter your check number");
            bool validCheckNo = true;
            while (validCheckNo == true)
            {
                string checkNo = Console.ReadLine();
                Regex checkValid = new Regex(@"(^[0-9]{1,6})$");
                if (!checkValid.IsMatch(checkNo))
                {
                    Console.WriteLine("Wrong number! Check number is on the top right of your check.");
                    validCheckNo = true;
                }
                else
                    validCheckNo = false;
            }
            // Validating that the account number is accurate on the check.----------------------
            Console.WriteLine("Please enter your account number");
            bool validAccNum = true;
            while (validAccNum == true)
            {
                string accNum = Console.ReadLine();
                Regex accValid = new Regex(@"(^[0-9]{10,12})$");
                if (!accValid.IsMatch(accNum))
                {
                    Console.WriteLine("Your account number is invalid, it's the number in the middle of the check.");
                    validAccNum = true;
                }
                else
                    validAccNum = false;
            }
            // Validating the routing number on the check.-------------------------------
            Console.WriteLine("Finally, enter your routing number");
            bool validRoutingNum = true;
            while (validRoutingNum == true)
            {
                string routingNum = Console.ReadLine();
                Regex routingValid = new Regex(@"(^[0-9]{9})$");
                if (!routingValid.IsMatch(routingNum))
                {
                    Console.WriteLine("Your routing number is invalid, it's the 9 digit number on the left of your check.");
                    validRoutingNum = true;
                }
                else
                {
                    validRoutingNum = false;

                }
            }
        }
    }
}
