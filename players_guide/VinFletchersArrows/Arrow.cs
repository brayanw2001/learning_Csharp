namespace VinFletchersArrows
{
    internal class Arrow
    {
        public int arrowHead;
        public int fletching;
        public int lenght;

        public Arrow(int arrowHead, int fletching, int lenght)
        {
            switch (arrowHead)
            {
                case 1: this.arrowHead = (int)ArrowHeadType.steel; break;
                case 2: this.arrowHead = (int)ArrowHeadType.wood; break;
                case 3: this.arrowHead = (int)ArrowHeadType.obsidian; break;
            }
            switch (fletching)
            {
                case 1: this.fletching = (int)FletchingType.plastic; break; //nameof(FletchingType.plastic); break;
                case 2: this.fletching = (int)FletchingType.turkeyFeathers; break;
                case 3: this.fletching = (int)FletchingType.gooseFeathers; break;
            }
            this.lenght = lenght;
        }

        public void GetCost ()
        {
            System.Console.WriteLine($"Arrow cost: {arrowHead+fletching+(lenght*0.05)}");
        }
    }
}