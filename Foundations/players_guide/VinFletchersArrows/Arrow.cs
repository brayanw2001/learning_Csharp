namespace VinFletchersArrows
{
    internal class Arrow
    {
        private int arrowHeadCost;
        private int fletchingCost;
        private int lenght;
        private string arrowHead;
        private string fletching;

        public Arrow(int arrowHeadCost, int fletchingCost, int lenght)
        {
            switch (arrowHeadCost)
            {
                case 1: 
                    this.arrowHeadCost = (int)ArrowHeadType.steel;
                    this.arrowHead = nameof(ArrowHeadType.steel);
                    break;
                case 2: 
                    this.arrowHeadCost = (int)ArrowHeadType.wood;
                    this.arrowHead = nameof(ArrowHeadType.wood);
                    break;
                case 3: 
                    this.arrowHeadCost = (int)ArrowHeadType.obsidian;
                    this.arrowHead = nameof(ArrowHeadType.obsidian);
                    break;
            }
            switch (fletchingCost)
            {
                case 1:
                    this.fletchingCost = (int)FletchingType.plastic;
                    this.fletching = nameof(FletchingType.plastic);
                    break;
                case 2:
                    this.fletchingCost = (int)FletchingType.turkeyFeathers;
                    this.fletching = nameof(FletchingType.turkeyFeathers);
                    break;
                case 3: 
                    this.fletchingCost = (int)FletchingType.gooseFeathers;
                    this.fletching = nameof(FletchingType.gooseFeathers);
                    break;
            }
            this.lenght = lenght;
        }

        public void GetCost ()
        {
            System.Console.WriteLine($"You choosed: {arrowHead}, {fletching}, {lenght}cm");
            System.Console.WriteLine($"Arrow cost: ${arrowHeadCost+fletchingCost+(lenght*0.05)}");
        }

        public string GetArrowHead => arrowHead;
        public string GetFletching => fletching;
        public int GetLenght => lenght;
    }
}