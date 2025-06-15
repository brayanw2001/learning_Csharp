using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VinFletchersArrows
{
    internal class Arrow
    {
        private Arrowhead arrowheadType { get; }
        private Fletching fletchingType { get; }
        private float length { get; }
        public readonly float price;

        internal Arrow (Arrowhead arrowheadType, Fletching fletchingType, float length)
        {
            this.arrowheadType = arrowheadType;
            this.fletchingType = fletchingType;
            this.length = length;
        }

        private Arrow(Arrowhead arrowheadType, Fletching fletchingType, float length, float price)
        {
            this.arrowheadType = arrowheadType;
            this.fletchingType = fletchingType;
            this.length = length;
            this.price = price;
        }

        public static Arrow CreateEliteArrow() => new Arrow (Arrowhead.steel, Fletching.plastic, 95, 24.50f);
        public static Arrow CreateBeginnerArrow() => new(Arrowhead.wood, Fletching.goose_feathers, 75, 9.50f); // Arrow pode ser omitido
        public static Arrow CreateMarksManArrow() => new Arrow(Arrowhead.steel, Fletching.goose_feathers, 65, 16.00f);

        internal float GetCost ()
        {
            float cost = 0;

            switch (arrowheadType)
            {
                case Arrowhead.steel: 
                    cost += 10;
                    break;
                case Arrowhead.wood:
                    cost += 3;
                    break;
                case Arrowhead.obsidian:
                    cost += 5;
                    break;
            }

            switch (fletchingType)
            {
                case Fletching.plastic:
                    cost += 10;
                    break;
                case Fletching.turkey_feathers:
                    cost += 5;
                    break;
                case Fletching.goose_feathers:
                    cost += 3;
                    break;
            }

            return cost + (length*0.05f);
        }
    }
}
