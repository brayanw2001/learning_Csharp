using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinFletchersArrows
{
    internal class Arrow
    {
        private Arrowhead arrowheadType;
        private Fletching fletchingType;
        private float length;

        internal Arrow (Arrowhead arrowheadType, Fletching fletchingType, float length)
        {
            this.arrowheadType = arrowheadType;
            this.fletchingType = fletchingType;
            this.length = length;
        }

        Arrowhead GetArrowheadType() => this.arrowheadType;
        Fletching GetFletchingType() => this.fletchingType;
        float getLength() => this.length;

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
