using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chips : Product
    {
        #region Properties
        #endregion

        #region Constructor
        public Chips(string name, decimal priceInCents) : base(name, priceInCents)
        {

        }
        #endregion

        #region Methods
        public override string Consume()
        {
            string result = "Crunch Crunch, Yum!";

            return result;
        }
        #endregion
    }
}
