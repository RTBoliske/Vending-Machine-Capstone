using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum : product
    {
        #region Properties
        #endregion

        #region Constructor
        public Gum(string name, decimal priceInCents) : base(name, priceInCents)
        {

        }
        #endregion

        #region Methods
        public override string Consume()
        {
            string result = "Chew Chew, Yum!";

            return result;
        }
        #endregion
    }
}
