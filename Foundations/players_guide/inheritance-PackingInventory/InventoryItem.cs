using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory
{
    class InventoryItem
    {
        internal float Weight { get; }
        internal float Volume { get; }

        public InventoryItem(float Weight, float Volume)
        {
            this.Weight = Weight;
            this.Volume = Volume;
        }
    }
}
