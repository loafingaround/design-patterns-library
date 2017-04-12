namespace FlyweightPattern.ConcreteFlyweights
{
    class School : IBuilding
    {
        // intrinsic state - shared between objects of same type
        Builder builder = new Builder("school", 45, 4);

        public void Build(int plotNumber)
        {
            builder.Build(plotNumber);
        }
    }
}
