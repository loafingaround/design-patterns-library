namespace DecoratorPattern
{
    // decorator
    class BreakfastItemDecorator : BreakfastItem
    {
        // object to be decorated
        private BreakfastItem breakfastItem;

        public BreakfastItemDecorator(BreakfastItem breakfastItem)
        {
            this.breakfastItem = breakfastItem;
        }

        public virtual string Description
        {
            get
            {
                return breakfastItem.Description;
            }
        }

        public virtual double Price
        {
            get
            {
                return breakfastItem.Price;
            }
        }
    }
}
