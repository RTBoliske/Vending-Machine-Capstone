using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class product 
    {
        public const string Beverage = "Drink";
        public const string Candy = "Candy";
        public const string Chips = "Chip";
        public const string Gum = "Gum";
        #region Members
        #endregion

        #region Properties
        public string Name { get; } = "";
        public decimal Price { get; }
        #endregion

        #region Constructor
        public product (string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        #endregion

        #region Methods
        public abstract string Consume();
       
        #endregion
    }
}
