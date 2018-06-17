using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;



namespace Capstone.Classes
{
    public class MainMenu
    {
        #region Members
        private VendingMachine _machine = null;
        #endregion

        #region Properties
        //public decimal CurrentBalance { get; set; }
        #endregion

        #region Constructor
        public MainMenu(VendingMachine machine)
        {
            _machine = machine;
        }
        #endregion

        #region Methods
        public void Display()
        {
            _machine.LoadVendingMachine();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine(" -- Main Vending Machine Menu --");
                Console.WriteLine();
                Console.WriteLine(" (1) Display Vending Machine Items");
                Console.WriteLine(" (2) Purchase");
                Console.WriteLine(" (Q) Quit");
                Console.WriteLine();

                Console.Write(" What option do you want to select? ");
                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    _machine.DisplayAllItems();
                }
                else if (input == '2')
                {
                    DisplaySubMenu();
                }
                
                else if (input == 'q' || input == 'Q')
                {
                    exit = true;
                    break;
                }
                else
                {
                    Console.WriteLine(" Please try again. ");
                }
            }
        }

        //public void DisplayAllItems()
        //{
        //    Console.Clear();
        //    Console.WriteLine();
        //    Console.WriteLine(" {0, 6} {1, -20} {2, -10} {3, -5}", "Slot", "Name", "Price", "Quantity");
        //    Console.WriteLine(" ------------------------------------------------------");
        //    foreach (KeyValuePair<string, Inventory> item in _machine._inventory)
        //    {
        //        //Console.WriteLine(" {0, -5}  {1, 30} {2, -7} {3, -7}", item.Key, item.Value.Item.Name, item.Value.Item.Price, item.Value.Quantity);
        //        //Console.WriteLine(" {0, -5} {1, -25} {2, -10} {3, -5}", "Product Slot", "Name", "Price", "Quantity");
        //        Console.WriteLine(" {0, 5}  {1, -22} {2, -10} {3, -5}", item.Key, item.Value.Item.Name, item.Value.Item.Price, item.Value.Quantity);
        //    }
        //    //fix to allow user to return to sub menu
        //    Console.WriteLine();
        //    Console.Write(" Press any key to continue... ");
        //    Console.ReadKey();
        //}

        public void DisplaySubMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine(" Purchase Menu");
                Console.WriteLine();
                Console.WriteLine(" (1) Feed Money");
                Console.WriteLine(" (2) Select Product");
                Console.WriteLine(" (3) Finish Transaction");
                Console.WriteLine(" (Q) Return to Main Menu");
                Console.WriteLine();

                Console.Write(" What option do you want to select? ");
                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    _machine.LoadMoney();
                }
                else if (input == '2')
                {
                    _machine.SelectProduct();
                }
                else if (input == '3')
                {
                    _machine.FinishTransaction();
                }
                else if (input == 'q' || input == 'Q')
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine(" Please try again. ");
                }
            }
        }

        //public void LoadMoney()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine($" Current balance is {CurrentBalance.ToString("c")}");

        //    Console.WriteLine();
        //    Console.WriteLine(" (1) $1");
        //    Console.WriteLine(" (2) $2");
        //    Console.WriteLine(" (3) $5");
        //    Console.WriteLine(" (4) $10");
        //    Console.WriteLine();
        //    Console.Write(" How much money would you like to add? ");
        //    char input = Console.ReadKey().KeyChar;

        //    if (input == '1')
        //    {
        //        CurrentBalance += 1;
        //    }
        //    else if (input == '2')
        //    {
        //        CurrentBalance += 2;
        //    }
        //    else if (input == '3')
        //    {
        //        CurrentBalance += 5;
        //    }
        //    else if (input == '4')
        //    {
        //        CurrentBalance += 10;
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Please try again. ");
        //    }
        //}

        //public void SelectProduct()
        //{
        //    DisplayAllItems();
        //    Console.WriteLine();
        //    Console.WriteLine($" Current balance is {CurrentBalance.ToString("c")}");
        //    Console.WriteLine();
        //    Console.Write(" To select an item, enter the Slot ID... ");
        //    string selectedItem = Console.ReadLine();

        //    if (_machine._inventory.ContainsKey(selectedItem))
        //    {
        //        Inventory item = _machine._inventory[selectedItem];

        //        if (item.Quantity != 0)
        //        {
        //            item.Quantity--;
        //            CurrentBalance -= item.Item.Price;

        //            DispenseProduct(selectedItem);

        //            Console.WriteLine();
        //            Console.WriteLine($" New balance is {CurrentBalance.ToString("c")}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($" {item.Item.Name} is SOLD OUT, please make another selection.");
        //            Console.WriteLine(" Press any key to return to Purchase Menu. ");
        //            Console.ReadKey();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Product code does not exist, please try again.");
        //        Console.WriteLine(" Press any key to return to Purchase Menu. ");
        //        Console.ReadKey();
        //    }
        //}

        //public void FinishTransaction()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine($"Your current balance is {CurrentBalance.ToString("c")}");
        //    Console.WriteLine();

        //    int change = (int)(CurrentBalance * 100);

        //    int quarter = 25;
        //    int dime = 10;
        //    int nickel = 5;

        //    int qtyQuarters = (change / quarter);
        //    int qtyDimes = ((change % quarter) / dime);
        //    int qtyNickels = (((change % quarter) % dime) / nickel);

        //    Console.WriteLine($"Your change is {qtyQuarters} quarters, {qtyDimes} dimes, and {qtyNickels} nickels.");
        //    Console.WriteLine();
        //    CurrentBalance = 0;
        //    Console.WriteLine($"Your balance is now {CurrentBalance.ToString("C")}.");
        //    Console.WriteLine();

        //    ConsumeProduct(purchaseList);
        //    Console.ReadKey();
        //}

        //public void DispenseProduct(string selectedItem)
        //{
        //    purchaseList.Add(selectedItem);
        //}

        //public void ConsumeProduct(List<string> purchaseList)
        //{
        //    foreach (string selection in purchaseList)
        //    {
        //        if (purchaseList.Contains("A1") ^ purchaseList.Contains("A2") ^
        //            purchaseList.Contains("A3") ^ purchaseList.Contains("A4"))
        //        {
        //            Console.WriteLine("Crunch Crunch, Yum!");
        //        }
        //        else if (purchaseList.Contains("B1") ^ purchaseList.Contains("B2") ^
        //                    purchaseList.Contains("B3") ^ purchaseList.Contains("B4"))
        //        {
        //            Console.WriteLine("Munch, Munch, Yum!");
        //        }
        //        else if (purchaseList.Contains("C1") ^ purchaseList.Contains("C2") ^
        //                    purchaseList.Contains("C3") ^ purchaseList.Contains("C4"))
        //        {
        //            Console.WriteLine("Gulp, Gulp, Yum!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Chew, Chew, Yum!");
        //        }
        //    }
        //}
        #endregion
    }
}
