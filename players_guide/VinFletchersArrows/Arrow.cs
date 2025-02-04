namespace VinFletchersArrows
{
    internal class Arrow
    {
        public string arrowHead;
        public string fletching;
        public int lenght;

        public Arrow(int arrowHead, int fletching, int lenght)
        {
            switch (arrowHead)
            {
                case 1: this.arrowHead = nameof(ArrowHeadType.steel); break;
                case 2: this.arrowHead = nameof(ArrowHeadType.wood); break;
                case 3: this.arrowHead = nameof(ArrowHeadType.obsidian); break;
            }
            switch (fletching)
            {
                case 1: this.fletching = nameof(FletchingType.plastic); break;
                case 2: this.fletching = nameof(FletchingType.turkeyFeathers); break;
                case 3: this.fletching = nameof(FletchingType.gooseFeathers); break;
            }
            this.lenght = lenght;
        }
    }
}