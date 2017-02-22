namespace DecoratorPattern
{
    // concrete 
    class BaconSandwich : BreakfastItem
    {
        public string Description
        {
            get { return "Bacon sandwich";  }
        }

        public double Price
        {
            get { return 2.90; }
        }
    }
}
