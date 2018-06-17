using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : product
    {
        #region Properties
        #endregion

        #region Constructor
        public Candy(string name, decimal priceInCents) : base(name, priceInCents)
        {

        }
        #endregion

        #region Methods
        public override string Consume()
        {
            string result = "Munch Munch, Yum!";

            return result;
        }
        #endregion
    }
}
