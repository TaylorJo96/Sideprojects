using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
namespace Capstone
{
    public class UserInterface : IColorable, ISoundable, IPauseable
    {
        public static void MainMenu()
        {
            ArtMessages art = new ArtMessages();
            Transactions transaction = new Transactions();
            Inventory inventory = new Inventory();

            art.welcomeMessage();
            Inventory.GetMenu();

            string mainMenuChoice;
            do
            {
                Console.WriteLine("                    ┌───────────┐    ");
                Console.WriteLine(" │******************│ Main Menu │******************│");
                Console.WriteLine(" │                  └───────────┘                  │");
                Console.WriteLine(" │        (1) Display Vending Machine Items        │");
                Console.WriteLine(" │                  (2) Purchase                   │");
                Console.WriteLine(" │                    (3) Exit                     │");
                Console.WriteLine(" │                                                 │");
                Console.WriteLine(" │*************************************************│");
                Console.ForegroundColor = ConsoleColor.White;
                mainMenuChoice = Console.ReadLine();
                Console.WriteLine();
                IPauseable.ShortPause();

                if (mainMenuChoice == "1")
                {
                    Console.Clear();
                    IPauseable.ShortPause();
                    inventory.PrintMenu();
                }

                string purchaseChoice = "";

                string directory = Environment.CurrentDirectory;
                string file = "Log.txt";
                string logFile = Path.Combine(directory, file);

                int buttonMashes = 0;

                try
                {
                    using (StreamWriter sw = new StreamWriter(logFile, true))
                    {
                        if (mainMenuChoice == "2")
                        {
                            do
                            {
                                ISoundable.HappySound();
                                Console.Clear();
                                Console.WriteLine("                  ┌───────────────┐            ");
                                Console.WriteLine(" │****************| Purchase Menu |****************│");
                                Console.WriteLine(" │                └───────────────┘                │");
                                Console.WriteLine(" │                 (1) Feed Money                  │");
                                Console.WriteLine(" │               (2) Select Product                │");
                                Console.WriteLine(" │             (3) Finish Transaction              │");
                                Console.WriteLine(" │                                                 │");
                                Console.WriteLine(" │*************************************************│\n");
                                IColorable.Color($"Your current balance is {transaction.Balance.ToString("C")}\n\n", ConsoleColor.Green);
                                purchaseChoice = Console.ReadLine();
                                Console.WriteLine();

                                if (purchaseChoice == "1")
                                {
                                    Console.Write("Please enter whole dollar amount (no decimal): ");
                                    string moneyInput = Console.ReadLine();
                                    Console.WriteLine();
                                    if (transaction.FeedMoney(moneyInput))
                                    {
                                        sw.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyInput}.00 {transaction.Balance.ToString("C")}");

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        art.GetPicture("DollarsIn.txt");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        IPauseable.MediumPause();
                                    }
                                }
                                if (purchaseChoice == "2")
                                {
                                    inventory.PrintMenu();
                                    IColorable.Color($"Your current balance is {transaction.Balance.ToString("C")}\n\n", ConsoleColor.Green);
                                    Console.Write("Select the location of your desired snack: ");
                                    string selection = Console.ReadLine().ToUpper();
                                    Console.WriteLine();
                                    if (inventory.ItemExists(selection))
                                    {
                                        if (inventory.ItemAvailable(selection))
                                        {
                                            if (transaction.PurchaseItem(inventory.ItemMenu[selection].Price))
                                            {
                                                ISoundable.WelcomeSound();
                                                inventory.ItemMenu[selection].Quantity--;
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.WriteLine($"Dispensing {inventory.ItemMenu[selection].ProductName} for " +
                                                    $"{inventory.ItemMenu[selection].Price.ToString("C")}");

                                                Console.WriteLine(art.ItemMessage(selection));
                                                IPauseable.PauseWithRedirect();
                                                IPauseable.MediumPause();
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine();
                                                sw.WriteLine($"{DateTime.Now} {inventory.ItemMenu[selection].ProductName} " +
                                                    $"{inventory.ItemMenu[selection].SlotLocation} " +
                                                    $"{(transaction.Balance + inventory.ItemMenu[selection].Price).ToString("C")} " +
                                                    $"{transaction.Balance.ToString("C")}");
                                            }
                                        }
                                        else
                                        {
                                            ISoundable.UnhappySound();
                                            IColorable.Color("Sold Out :( Try again later!\n\n", ConsoleColor.Red);
                                            IPauseable.PauseWithRedirect();
                                            buttonMashes++;
                                        }
                                    }
                                    else
                                    {
                                        ISoundable.UnhappySound();
                                        IColorable.Color("Item location code not found. Please try again.\n\n", ConsoleColor.Red);
                                        IPauseable.PauseWithRedirect();
                                        buttonMashes++;
                                    }
                                }
                                else if (purchaseChoice != "1" && purchaseChoice != "2" && purchaseChoice != "3")
                                {
                                    ISoundable.UnhappySound();
                                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n\n", ConsoleColor.Red);
                                    IPauseable.PauseWithRedirect();
                                    buttonMashes++;
                                }

                            } while (purchaseChoice != "3");
                        }
                        if (purchaseChoice == "3")
                        {
                            ISoundable.HappySound();
                            Console.WriteLine($"Your remaining balance is {transaction.Balance.ToString("C")}.\n");
                            sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {transaction.Balance.ToString("C")} $0.00");
                            transaction.GiveChange();
                            IPauseable.PauseWithRedirect();
                            Console.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (mainMenuChoice == "3")
                {
                    Console.Clear();
                    ISoundable.WelcomeSound();
                    art.GoodbyeMessage();
                }

                if (mainMenuChoice == "4")
                {
                    ISoundable.HappySound();
                    Console.Write("Please enter password for sales report: ");
                    string password = Console.ReadLine();
                    Console.WriteLine();
                    if (password == "Interpolation")
                    {
                        ISoundable.HappySound();
                        inventory.SalesReport();
                        IPauseable.PauseWithRedirect();
                        Console.Clear();
                    }
                    else
                    {
                        ISoundable.UnhappySound();
                        IColorable.Color("Password incorrect.\n\n", ConsoleColor.Red);
                        IPauseable.PauseWithRedirect();
                    }
                }
                else if (mainMenuChoice != "1" && mainMenuChoice != "2" && mainMenuChoice != "3" && mainMenuChoice != "4")
                {
                    ISoundable.UnhappySound();
                    IColorable.Color("Invalid choice. Please choose 1, 2, or 3.\n\n", ConsoleColor.Red);
                    IPauseable.PauseWithRedirect();
                    Console.Clear();
                }

            } while (mainMenuChoice != "3");
        }
    }
}
