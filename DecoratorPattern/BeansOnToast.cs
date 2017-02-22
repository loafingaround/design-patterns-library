namespace DecoratorPattern
{
    // concrete 
    class BeansOnToast : BreakfastItem
    {
        public string Description
        {
            get { return "Beans on toast"; }
        }

        public double Price
        {
            get { return 5.30; }
        }
    }
}
