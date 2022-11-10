using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Transactions : IColorable
    {
        public decimal Balance { get; set; }

        /// <summary>
        /// Accepts money from user and adds it to the balance, making sure the amount given is a whole number
        /// </summary>
        /// <param name="moneyToFeed">number input from user</param>
        public bool FeedMoney(string moneyToFeed)
        {
            int wholeNumber;
            bool success = int.TryParse(moneyToFeed, out wholeNumber);
            if (success && wholeNumber > 0 && wholeNumber < 101)
            {
                decimal moneyAdd = decimal.Parse(moneyToFeed);
                this.Balance = this.Balance += moneyAdd;
                return true;
            }
            else if (wholeNumber >= 101 && wholeNumber <= 9999)
            {
                ISoundable.UnhappySound();
                IColorable.Color($"Where are you getting {wholeNumber} dollar bills??\n\n", ConsoleColor.Cyan);
                IPauseable.PauseWithRedirect();

                return false;
            }
            else if (wholeNumber >= 10000)
            {
                ISoundable.UnhappySound();
                IColorable.Color($"Go buy your own machine.\n\n", ConsoleColor.Cyan);
                IPauseable.PauseWithRedirect();

                return false;
            }
            else
            {
                ISoundable.UnhappySound();
                IColorable.Color("Invalid entry. Please enter a whole dollar amount.\n\n", ConsoleColor.Red);
                IPauseable.PauseWithRedirect();

                return false;
            }
        }

        /// <summary>
        /// Checks that the price of the item selected is not more than the remaining balance, 
        /// and subtracts the price from the balance if true.  
        /// Otherwise, lets the user know they do not have enough to purchase the item.
        /// </summary>
        /// <param name="price">reads the price of the item selected</param>
        /// <returns>returns true if there is enough money for the item, or false if not</returns>
        public bool PurchaseItem(decimal price)
        {
            if (this.Balance >= price)
            {
                this.Balance -= price;
                return true;
            }
            else
            {
                ISoundable.UnhappySound();
                IColorable.Color("Insufficient funds.\n\n", ConsoleColor.Red);
                IPauseable.PauseWithRedirect();
                return false;
            }
        }

        /// <summary>
        /// Takes the remaining balance and provides change in quarters, dimes, and nickels using the fewest coins possible.
        /// </summary>
        public string GiveChange()
        {
            if (this.Balance == 0.00M)
            {
                IColorable.Color("No change to give.\n\n", ConsoleColor.DarkRed);
                return "Nice try.";
            }

            int quarter = 0;
            int dime = 0;
            int nickel = 0;
            while (this.Balance >= .25M)
            {
                quarter++;
                this.Balance -= .25M;
            }
            while (this.Balance >= .10M)
            {
                dime++;
                this.Balance -= .10M;
            }
            while (this.Balance >= .05M)
            {
                nickel++;
                this.Balance -= .05M;
            }
            string change = $"Dispensing: {quarter} Quarter(s), {dime} Dime(s), {nickel} Nickel(s).\n\n";
            ArtMessages art = new ArtMessages();

            art.GetPicture("changeOut.txt");
            IColorable.Color(change, ConsoleColor.Green);

            return change;
        }
    }
}

