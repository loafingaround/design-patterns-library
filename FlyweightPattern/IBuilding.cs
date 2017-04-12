namespace FlyweightPattern
{
    interface IBuilding
    {
        // plot number is extrinsic state - it can be (computed and) passed in when required
        void Build(int plotNumber);
    }
}
