namespace FlyweightPattern.ConcreteFlyweights
{
    class House : IBuilding
    {
        // intrinsic state - shared between objects of same type
        Builder builder = new Builder("house", 8, 2);

        public void Build(int plotNumber)
        {
            builder.Build(plotNumber);
        }
    }
}
