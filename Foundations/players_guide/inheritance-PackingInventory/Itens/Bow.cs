using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory.Itens
{
    class Bow : InventoryItem
    {
        public Bow() : base(1f, 4f)
        {

        }

        public override string ToString()
        {
            return "Bow";
        }
    }
}
