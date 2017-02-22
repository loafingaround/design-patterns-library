namespace DecoratorPattern
{
    class Ketchup: BreakfastItemDecorator
    {
        public Ketchup(BreakfastItem breakfastItem): base(breakfastItem)
        {            
        }

        public override string Description
        {
            get
            {
                return base.Description + " with ketchup";
            }
        }

        public override double Price
        {
            get
            {
                return base.Price + 1;
            }
        }
    }
}
