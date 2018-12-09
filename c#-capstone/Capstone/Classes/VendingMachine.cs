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
        public Dictionary<string, Inventory> ItemPurchases = new Dictionary<string, Inventory>();
        public List<string> transactionList = new List<string>();
        List<string> purchaseList = new List<string>();
        string sourceFilePath = "";
        //int purchaseQuantity = 0;
        #endregion

        #region Properties
        public decimal CurrentBalance { get; set; } 
        #endregion

        #region Constructor
        public VendingMachine()
        {
        }
        #endregion

        #region Methods
        public void LoadVendingMachine()
        {
            sourceFilePath = "vendingmachine.csv";
            sourceFilePath = Path.Combine(Environment.CurrentDirectory, sourceFilePath);

            char[] splitChar = { '|' };
            
            Product _product = null;

            try
            {
                using (StreamReader sr = new StreamReader(sourceFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] products = line.Split(splitChar);

                        if (products[3] == Product.Candy)
                        {
                            _product = new Candy(products[1], decimal.Parse(product[2]));
                        }
                        if (products[3] == Product.Chips)
                        {
                            _product = new Chips(products[1], decimal.Parse(product[2]));
                        }
                        if (products[3] == Product.Beverage)
                        {
                            _product = new Beverage(products[1], decimal.Parse(product[2]));
                        }
                        if (products[3] == Product.Gum)
                        {
                            _product = new Gum(products[1], decimal.Parse(product[2]));
                        }
                    }
                    
                    Inventory item = new Inventory(_product);
                    _inventory.Add(products[0], item);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(" Error reading the file... ");
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
                foreach (KeyValuePair<string, Inventory> productItem in _inventory)
                {
                    Console.WriteLine(" {0, 5}  {1, -27} {2, 4} {3, 7}", 
                                     productItem.Key, productItem.Value.Item.Name, 
                                     productItem.Value.Item.Price, productItem.Value.Quantity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error displaying products... ");
                Console.Write(e.Message);
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
            
            Console.Write(" How much money would you like to add? Press the key... ");
            char input = Console.ReadKey().KeyChar;
            string amountAdded = "";

            try
            {
                if (input == '1')
                {
                    CurrentBalance += 1;

                    amountAdded = "$1.00";
                }
                else if (input == '2')
                {
                    CurrentBalance += 2;

                    amountAdded = "$2.00";
                }
                else if (input == '3')
                {
                    CurrentBalance += 5;

                    amountAdded = "$5.00";
                }
                else if (input == '4')
                {
                    CurrentBalance += 10;

                    amountAdded = "$10.00";
                }
                else
                {
                    Console.WriteLine(" Please try again. ");
                }

                transactionList.Add($"{DateTime.Now} FEED:\t\t{amountAdded}\t{CurrentBalance.ToString("c")}");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error loading money... ");
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
                    Inventory itemSelected = _inventory[selectedItem];

                    if (itemSelected.Quantity != 0 && CurrentBalance >= itemSelected.Item.Price)
                    {
                        transactionList.Add($"{DateTime.Now} {itemSelected.Item.Name}\t{CurrentBalance.ToString("c")}" +
                                            $"\t{(CurrentBalance -= itemSelected.Item.Price).ToString("c")}");

                        itemSelected.Quantity--;
                        itemSelected.PurchaseQuantity++;
                        CurrentBalance = CurrentBalance;

                        purchaseList.Add(selectedItem);

                        Console.WriteLine();
                        Console.WriteLine($" New balance is {CurrentBalance.ToString("c")}");
                        
                        UpdateSalesReport("SalesReport.txt");
                    }
                    else
                    {
                        Console.WriteLine($" {itemSelected.Item.Name} is SOLD OUT, please make another selection... ");
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
                Console.WriteLine(" Error selecting a product... ");
                Console.WriteLine(e.Message);
            }
        }

        public void ConsumeProduct(List<string> purchaseList)
        {
            Chips chips = new Chips();
            Candy candy = new Candy();
            Beverage beverage = new Beverage();
            Gum gum = new Gum();
            
            try
            {
                foreach (string selection in purchaseList)
                {
                    if (selection.Contains("A"))
                    {
                        Console.WriteLine(" " + chips.Consume());
                    }
                    else if (selection.Contains("B1"))
                    {
                        Console.WriteLine(" " + candy.Consume());
                    }
                    else if (selection.Contains("C1"))
                    {
                        Console.WriteLine(" " + beverage.Consume());
                    }
                    else
                    {
                        Console.WriteLine(" " + gum.Consume());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error while attempting to consume purchased products... ");
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

            decimal finalBalance = 0;

            try
            {
                qtyQuarters = (change / quarter);
                qtyDimes = ((change % quarter) / dime);
                qtyNickels = (((change % quarter) % dime) / nickel);
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error while attempting to finish transaction... ");
                Console.Write(e.Message);
            }

            Console.WriteLine($" Your change is {qtyQuarters} quarters, {qtyDimes} dimes, and {qtyNickels} nickels.");
            Console.WriteLine();
           
            Console.WriteLine($" Your balance is now {finalBalance.ToString("C")}.");
            Console.WriteLine();

            transactionList.Add($"{DateTime.Now} GIVE CHANGE:\t{CurrentBalance.ToString("C")}\t{finalBalance.ToString("C")}");

            Console.WriteLine();
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
                    Console.WriteLine(" File path does not exist, please verify correct file name... ");
                }
            }
            while (!exists);

            return exists;
        }

        public void PrintToFile(string file)
        {
            sourceFilePath = file;

            //DoesFileExist(sourceFilePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(sourceFilePath))
                {
                    foreach (string action in transactionList)
                    {
                        sw.WriteLine(" " + action);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write(" Error printing to the file... ");
                Console.Write(e.Message);
            }
        }

        public void UpdateSalesReport(string report)
        {
            sourceFilePath = report;
            decimal totalSalesAmount = 0;

            DoesFileExist(sourceFilePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(sourceFilePath))
                {
                    foreach (KeyValuePair<string, Inventory> purchase in _inventory)
                    {
                        sw.WriteLine(" " + purchase.Value.Item.Name + " | " + purchase.Value.PurchaseQuantity);
                        totalSalesAmount = totalSalesAmount + (purchase.Value.PurchaseQuantity * purchase.Value.Item.Price);
                    }

                    sw.WriteLine();
                    sw.WriteLine("** Total Sales ** " + totalSalesAmount.ToString("c"));
                }
            }
            catch (IOException e)
            {
                Console.Write(" Error printing to the file... ");
                Console.Write(e.Message);
            }
        }
        #endregion
    }
}
