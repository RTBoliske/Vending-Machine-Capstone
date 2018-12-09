using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Beverage : Product
    {
        #region Properties
        #endregion

        #region Constructor
        public Beverage (string name, decimal priceInCents) : base(name, priceInCents)
        {

        }
        
        public Beverage()
        {
        
        }
        #endregion

        #region Methods
        public override string Consume()
        {
            string result = "Glug Glug, Yum!";

            return result;
        }
        #endregion
    }
}
