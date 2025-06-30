using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory.Itens
{
    class Food : InventoryItem
    {
        public Food() : base(1f, 0.5f)
        {

        }

        public override string ToString()
        {
            return "Food";
        }
    }
}
