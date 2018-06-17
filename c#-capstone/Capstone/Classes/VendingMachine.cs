using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        #region Members
        
        public Dictionary<string, Inventory> _inventory = new Dictionary<string, Inventory>();
        public List<string> transactionList = new List<string>();
        string sourceFilePath = "";

        //sprivate Log _transactionLogger;
        #endregion

        #region Properties
        public decimal CurrentBalance { get; set; }
        List<string> purchaseList = new List<string>();

        #endregion

        #region Constructor
        public VendingMachine()
        {
        }
        #endregion

        #region Methods
        public void LoadVendingMachine()
        {
            string sourceFilePath = "vendingmachine.csv";
            sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);

            char[] splitChar = { '|' };

            try
            {
                using (StreamReader sr = new StreamReader(sourceFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] product = line.Split(splitChar);

                        if (product[3] == Classes.product.Candy)
                        {
                            Candy candy = new Candy(product[1], decimal.Parse(product[2]));
                            Inventory item = new Inventory(candy);
                            _inventory.Add(product[0], item);
                        }
                        if (product[3] == Classes.product.Chips)
                        {
                            Chips chip = new Chips(product[1], decimal.Parse(product[2]));
                            Inventory item = new Inventory(chip);
                            _inventory.Add(product[0], item);
                        }
                        if (product[3] == Classes.product.Beverage)
                        {
                            Beverage drink = new Beverage(product[1], decimal.Parse(product[2]));
                            Inventory item = new Inventory(drink);
                            _inventory.Add(product[0], item);
                        }
                        if (product[3] == Classes.product.Gum)
                        {
                            Gum gum = new Gum(product[1], decimal.Parse(product[2]));
                            Inventory item = new Inventory(gum);
                            _inventory.Add(product[0], item);
                        }
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(" Error reading the file");
                Console.WriteLine(e.Message);
            }
        }

        public void SelectProduct()
        {
            DisplayAllItems();
            Console.WriteLine();
            Console.WriteLine($" Current balance is {CurrentBalance.ToString("c")}");
            Console.WriteLine();
            Console.Write(" To select an item, enter the Slot ID... ");
            string selectedItem = Console.ReadLine();

            try
            {
                if (_inventory.ContainsKey(selectedItem))
                {
                    Inventory item = _inventory[selectedItem];

                    if (item.Quantity != 0)
                    {
                        transactionList.Add($"{DateTime.Now} {item.Item.Name}\t{CurrentBalance.ToString("c")}\t{(CurrentBalance -= item.Item.Price).ToString("c")}");

                        item.Quantity--;
                        CurrentBalance -= item.Item.Price;

                        purchaseList.Add(selectedItem);

                        
                        //PrintToFile("SELECT PRODUCT");

                        Console.WriteLine();
                        Console.WriteLine($" New balance is {CurrentBalance.ToString("c")}");

                        //transactionList.Add($"{DateTime.Now} BALANCE {CurrentBalance.ToString("c")}");
                    }
                    else
                    {
                        Console.WriteLine($" {item.Item.Name} is SOLD OUT, please make another selection.");
                        Console.WriteLine(" Press any key to return to Purchase Menu. ");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(" Product code does not exist, please try again.");
                    Console.WriteLine(" Press any key to return to Purchase Menu. ");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error selecting a product");
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayAllItems()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" {0, 6} {1, 10} {2, 22} {3, 10}", "Slot", "Name", "Price", "Quantity");
            Console.WriteLine(" ------------------------------------------------------");

            try
            {
                foreach (KeyValuePair<string, Inventory> item in _inventory)
                {
                    Console.WriteLine(" {0, 5}  {1, -27} {2, 4} {3, 7}", item.Key, item.Value.Item.Name, item.Value.Item.Price, item.Value.Quantity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error displaying products");
            }

            Console.WriteLine();
            Console.Write(" Press any key to continue... ");
            Console.ReadKey();
        }

        public void LoadMoney()
        {
            Console.WriteLine();
            Console.WriteLine($" Current balance is {CurrentBalance.ToString("c")}");

            Console.WriteLine();
            Console.WriteLine(" (1) $1");
            Console.WriteLine(" (2) $2");
            Console.WriteLine(" (3) $5");
            Console.WriteLine(" (4) $10");
            Console.WriteLine();
            Console.Write(" How much money would you like to add? ");
            char input = Console.ReadKey().KeyChar;
            string amtLoaded = "";

            try
            {
                if (input == '1')
                {
                    CurrentBalance += 1;

                    amtLoaded = "$1.00";
                }
                else if (input == '2')
                {
                    CurrentBalance += 2;

                    amtLoaded = "$2.00";
                }
                else if (input == '3')
                {
                    CurrentBalance += 5;

                    amtLoaded = "$5.00";
                }
                else if (input == '4')
                {
                    CurrentBalance += 10;

                    amtLoaded = "$10.00";
                }
                else
                {
                    Console.WriteLine(" Please try again. ");
                }

                transactionList.Add($"{DateTime.Now} FEED:\t\t{amtLoaded}\t{CurrentBalance.ToString("c")}");

                //PrintToFile($"FEED {amtLoaded}");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error loading money");
                Console.WriteLine(e.Message);
            }
        }

        public void DispenseProduct(string selectedItem)
        {
            //purchaseList.Add(selectedItem);
        }

        public void ConsumeProduct(List<string> purchaseList)
        {
            try
            {
                foreach (string selection in purchaseList)
                {
                    if (selection == "A1" || selection == "A2" ||
                        selection == "A3" || selection == "A4")
                    {
                        Console.WriteLine(" Crunch Crunch, Yum!");
                    }
                    else if (selection == "B1" || selection == "B2" ||
                             selection == "B3" || selection == "B4")
                    {
                        Console.WriteLine(" Munch, Munch, Yum!");
                    }
                    else if (selection == "C1" || selection == "C2" ||
                             selection == "C3" || selection == "C4")
                    {
                        Console.WriteLine(" Gulp, Gulp, Yum!");
                    }
                    else
                    {
                        Console.WriteLine(" Chew, Chew, Yum!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error while attempting to consume purchased products");
                Console.WriteLine(e.Message);
            }
        }

        public void FinishTransaction()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($" Your current balance is {CurrentBalance.ToString("c")}");
            Console.WriteLine();

            int change = (int)(CurrentBalance * 100);

            int quarter = 25;
            int dime = 10;
            int nickel = 5;

            int qtyQuarters = 0;
            int qtyDimes = 0;
            int qtyNickels = 0;

            try
            {
                qtyQuarters = (change / quarter);
                qtyDimes = ((change % quarter) / dime);
                qtyNickels = (((change % quarter) % dime) / nickel);
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error while attempting to finish transaction");
            }

            Console.WriteLine($" Your change is {qtyQuarters} quarters, {qtyDimes} dimes, and {qtyNickels} nickels.");
            Console.WriteLine();
            decimal FinalBalance = 0;
            Console.WriteLine($" Your balance is now {FinalBalance.ToString("C")}.");
            Console.WriteLine();

            transactionList.Add($"{DateTime.Now} GIVE CHANGE:\t{CurrentBalance.ToString("C")}\t{FinalBalance.ToString("C")}");

            ConsumeProduct(purchaseList);

            PrintToFile("TransactionLog.txt");

            Console.ReadKey();
        }

        public bool DoesFileExist(string sourceFilePath)
        {
            bool exists = false;

            do
            {
                if (!Path.IsPathRooted(sourceFilePath))
                {
                    sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);
                }

                if (File.Exists(sourceFilePath))
                {
                    exists = true;
                }
                else
                {
                    Console.WriteLine(" File path does not exist, please verify correct file.");
                }
            }
            while (!exists);

            return exists;
        }

        public void PrintToFile(string file)
        {
            sourceFilePath = file;

            DoesFileExist(sourceFilePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(sourceFilePath))
                {
                    foreach (string action in transactionList)
                    {
                        sw.WriteLine(action);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write(" Error printing to the file... ");
                Console.Write(e.Message);
            }
        }

        public void PrintReport(string report)
        {
            sourceFilePath = report;

            DoesFileExist(sourceFilePath);

            //try
            //{
            //    using (StreamWriter sw = new StreamWriter(sourceFilePath))
            //    {
            //        foreach (string action in transactionList)
            //        {
            //            sw.WriteLine(action);
            //        }
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.Write(" Error printing to the file... ");
            //    Console.Write(e.Message);
            //}
        }
        #endregion
    }
}
