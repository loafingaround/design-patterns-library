namespace FlyweightPattern.ConcreteFlyweights
{
    class SmallOfficeBlock : IBuilding
    {
        // intrinsic state - shared between objects of same type
        Builder builder = new Builder("small office block", 3, 1);

        public void Build(int plotNumber)
        {
            builder.Build(plotNumber);
        }
    }
}
