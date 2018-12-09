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

                Console.Write(" Please select an option... ");
                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    _machine.DisplayAllItems();
                }
                else if (input == '2')
                {
                    DisplayPurchaseMenu();
                }
                
                else if (input == 'q' || input == 'Q')
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine(" Please try again... ");
                }
            }
        }

        public void DisplayPurchaseMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine(" -- Purchase Menu --");
                Console.WriteLine();
                Console.WriteLine(" (1) Load Money");
                Console.WriteLine(" (2) Select Product");
                Console.WriteLine(" (3) Finish Transaction");
                Console.WriteLine(" (Q) Quit");
                Console.WriteLine();

                Console.Write(" Please select an option... ");
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
                    Console.WriteLine(" Please try again... ");
                }
            }
        }
        #endregion
    }
}
