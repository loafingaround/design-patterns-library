namespace FlyweightPattern.ConcreteFlyweights
{
    class LargeOfficeBlock : IBuilding
    {
        // intrinsic state - shared between objects of same type
        Builder builder = new Builder("large office block", 500, 20);

        public void Build(int plotNumber)
        {
            builder.Build(plotNumber);
        }
    }
}
