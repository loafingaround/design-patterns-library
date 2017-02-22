namespace DecoratorPattern
{
    // concrete component
    class EggMuffin: BreakfastItem
    {
        public string Description
        {
            get { return "Egg muffin"; }
        }

        public double Price
        {
            get { return 4.00; }
        }
    }
}
