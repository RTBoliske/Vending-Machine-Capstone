using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capstone.Classes
{
    public class Change
    {
        #region Members
       
       
        #endregion

        #region Properties
        public int Dimes { get; private set; }
        public int Nickels { get; private set; }
        public int Quarters { get; private set; }
      
        #endregion

        #region Constructor
        public Change (decimal amountInDollars)
        {
            MakeChange(amountInDollars);
        }
        #endregion

        #region Methods
       private void MakeChange ( decimal amountInDollars)
       {
            //decimal change = amountInDollars;

            //decimal quarter = 0.25M;
            //decimal dime = 0.10M;
            //decimal nickel = 0.05M;

            //decimal qtyQuarters = (int)(change / quarter);
            //decimal qtyDimes = (int)((change % quarter) / dime);
            //decimal qtyNickels = (int)(((change % quarter) % dime) / nickel);

            //Console.WriteLine($"Your change is {qtyQuarters} quarters, {qtyDimes}, and {qtyNickels} nickels.");
       }
        
        #endregion
    }
}
