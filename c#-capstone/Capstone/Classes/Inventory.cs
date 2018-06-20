using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Inventory
    {
        #region Members
        #endregion

        #region Properties
        public Product Item { get; }
        public int Quantity { get; set; } = 5;
        public int PurchaseQuantity { get; set; }
        #endregion

        #region Constructor
        public Inventory(Product item)
        {
            Item = item;
        }
        #endregion

        #region Methods
        #endregion
    }
}
