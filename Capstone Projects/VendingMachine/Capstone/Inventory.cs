using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory : IColorable
    {
        private static Dictionary<string, Item> itemMenu = new Dictionary<string, Item>();
        public Dictionary<string, Item> ItemMenu
        {
            get
            {
                return itemMenu;
            }
        }

        /// <summary>
        /// pulls menu from the vendingmachine.csv file, separates item properties, and puts into private backing field for an item menu dictionary
        /// </summary>
        /// <returns>dictionary with items and their individual properties - Item code as key, item as value</returns>
        public static Dictionary<string, Item> GetMenu()
        {
            string directory = Environment.CurrentDirectory;
            string file = "vendingmachine.csv";
            string menuFile = Path.Combine(directory, file);

            try
            {
                using (StreamReader sr = new StreamReader(menuFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|");
                        decimal price = decimal.Parse(lineArray[2]);

                        Item newItem = new Item(lineArray[0], lineArray[1], price, lineArray[3]);
                        itemMenu[lineArray[0]] = newItem;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return itemMenu;
        }

        /// <summary>
        /// Prints items, their locations(item codes), prices, and remaining quantity of each
        /// </summary>
        public void PrintMenu()
        {
            ISoundable.HappySound();
            string resultEvenTop = "";
            string resultEvenBottom = "";
            int i = 0;
            string[] menuArray = new string[this.ItemMenu.Count];
            Console.Clear();
            foreach (KeyValuePair<string, Item> kvp in this.ItemMenu)
            {
                string resultLineTop = ($"{kvp.Key}- {kvp.Value.ProductName}");

                string resultLineBottom = "";
                if (kvp.Value.Quantity == 0)
                {
                    resultLineBottom = ($"{kvp.Value.Price.ToString("C")} SOLD OUT");
                }
                else
                {
                    resultLineBottom = ($"{kvp.Value.Price.ToString("C")} {kvp.Value.Quantity} remaining");
                }
                int length = 22;
                int spacesNeededTop = 22 - resultLineTop.Length;
                int spacesNeededBottom = 22 - resultLineBottom.Length;
                string spacesTop = "";
                string spacesBottom = "";
                string resultOddTop = "";
                string resultOddBottom = "";

                for (int j = 0; j < spacesNeededTop; j++)
                {
                    spacesTop += " ";
                }
                resultLineTop = resultLineTop + spacesTop;
                for (int k = 0; k < spacesNeededBottom; k++)
                {
                    spacesBottom += " ";
                }
                resultLineBottom = resultLineBottom + spacesBottom;
                //making the top of box
                string topOfOurBox = "╔";

                for (int c = 0; c < length; c++)
                {
                    topOfOurBox += "═";
                }
                topOfOurBox += "╗";

                //bottom of our box
                string bottomOfBox = "╚";

                for (int c = 0; c < length; c++)
                {
                    bottomOfBox += "═";
                }
                bottomOfBox += ("╝");

                if (i % 2 == 0)
                {
                    resultEvenTop = resultLineTop;
                    resultEvenBottom = resultLineBottom;
                }

                else
                {
                    resultOddTop = resultLineTop;
                    resultOddBottom = resultLineBottom;
                    
                    IColorable.Color("   "+ topOfOurBox + topOfOurBox, ConsoleColor.DarkMagenta);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine();
                    Console.Write("   ║");
                    IColorable.Color(resultEvenTop, ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("║║");
                    IColorable.Color(resultOddTop, ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("║");

                    Console.Write("   ║");
                    IColorable.Color(resultEvenBottom, ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("║║");
                    IColorable.Color(resultOddBottom, ConsoleColor.DarkYellow);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("║");
                    IColorable.Color("   "+ bottomOfBox + bottomOfBox, ConsoleColor.DarkMagenta);
                    Console.WriteLine();                                      
                }
                i++;
            }
            Console.WriteLine();
            IPauseable.ShortPause();
        }

        /// <summary>
        /// checks to see if a user input is a valid item code
        /// </summary>
        /// <param name="itemLocation">Item code provided by user</param>
        /// <returns>true if code exists, false if it doesn't</returns>
        public bool ItemExists(string itemLocation)
        {
            bool exists = itemMenu.ContainsKey(itemLocation) ? true : false;
            return exists;
        }

        /// <summary>
        /// checks to see if the confirmed user input code still has the item left in stock
        /// </summary>
        /// <param name="itemLocation">Item code provided by userr</param>
        /// <returns>true if item is still in stock, false if it isn't</returns>
        public bool ItemAvailable(string itemLocation)
        {
            bool available = itemMenu[itemLocation].Quantity > 0 ? true : false;
            return available;
        }

        /// <summary>
        /// Calculates total number of each item sold from the log
        /// </summary>
        private void CalculateSales()
        {
            string directory = Environment.CurrentDirectory;
            string file = "Log.txt";
            string logFile = Path.Combine(directory, file);

            try
            {
                using (StreamReader sr = new StreamReader(logFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        foreach (KeyValuePair<string, Item> kvp in ItemMenu)
                        {
                            if (line.Contains(kvp.Key))
                            {
                                kvp.Value.NumberSold++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// takes the total number of each item sold and writes the item names and totals into a new txt file created at the time this is run
        /// </summary>
        public void SalesReport()
        {
            CalculateSales();

            string directory = Environment.CurrentDirectory;
            string file = $"Sales Report {DateTime.Now.ToString("MM-dd-yyyy HH.mm.ss")}.txt";
            string logFile = Path.Combine(directory, file);

            try
            {
                using (StreamWriter sw = new StreamWriter(logFile, false))
                {
                    foreach (KeyValuePair<string, Item> kvp in ItemMenu)
                    {
                        sw.WriteLine($"{kvp.Value.ProductName}|{kvp.Value.NumberSold}");
                    }
                }
                Console.WriteLine("Sales report generated.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
