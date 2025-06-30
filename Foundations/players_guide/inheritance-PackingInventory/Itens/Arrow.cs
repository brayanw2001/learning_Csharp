using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory.Itens
{
    class Arrow : InventoryItem
    {
        public Arrow() : base(0.1f, 0.05f)
        {

        }

        public override string ToString()
        {
            return "Rope";
        }
    }
}
