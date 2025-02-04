using Properties;

namespace VinFletchersArrows
{
    internal class Arrow
    {
        private string arrowHead;
        private string fletching;
        private int lenght;

        public Arrow(int arrowHead, int fletching, int lenght)
        {
            switch (arrowHead)
            {
                case 1: this.arrowHead = ArrowHeadType.steel; break;
                case 2: this.arrowHead = ArrowHeadType.wood; break;
                case 3: this.arrowHead = ArrowHeadType.obsidian; break;
            }
            switch (fletching)
            {
                case 1: this.arrowHead = ArrowHeadType.plastic; break;
                case 2: this.arrowHead = ArrowHeadType.turkeyFeathers; break;
                case 3: this.arrowHead = ArrowHeadType.gooseFeathers; break;
            }
            this.lenght = lenght;
        }
    }
}