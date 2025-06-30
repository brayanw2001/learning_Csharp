using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory.Itens
{
    class Rope : InventoryItem
    {
        public Rope() : base(1f, 1.5f)
        {

        }

        public override string ToString()
        {
            return "Rope";
        }
    }
}
