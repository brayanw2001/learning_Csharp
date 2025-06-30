using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory.Itens
{
    class Water : InventoryItem
    {
        public Water() : base(2f, 3f)
        {

        }

        public override string ToString()
        {
            return "Water";
        }
    }
}
