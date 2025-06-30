using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance___Packing_Inventory
{
    class Pack
    {
        public int MaxItens { get; }
        public float MaxWeight { get; }
        public float MaxVolume { get; }
        internal InventoryItem [] Items { get; }

        public int CurrentCount { get; private set; } = 0;
        public float CurrentVolume { get; private set; }
        public float CurrentWeight { get; private set; }

        public Pack(int MaxItens, float MaxWeight, float MaxVolume)
        {
            this.MaxItens = MaxItens;
            this.MaxWeight = MaxWeight;
            this.MaxVolume = MaxVolume;
            Items = new InventoryItem[MaxItens];
        }

        public bool Add(InventoryItem item)
        {
            if (CurrentWeight + item.Weight >= MaxWeight || CurrentVolume + item.Volume >= MaxVolume || CurrentCount >= MaxItens) return false;

            else 
            {
                Items[CurrentCount] = item;
                CurrentVolume += item.Volume;
                CurrentWeight += item.Weight;
                CurrentCount++;

                return true;
            }
        }

        public override string ToString()
        {
            string contents = "Pack containing ";

            if (CurrentCount == 0) contents += "nothing";

            for (int i = 0; i < CurrentCount; i++)
            {
                contents += Items[i].ToString() + " ";
            }

            return contents;
        }

    }
}
