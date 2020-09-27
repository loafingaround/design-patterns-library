using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodOrder1 = new FoodOrder("Simon", true, new [] { "Chips", "Salad", "Burger" }, new OrderInfo(4525));

            var manager = new PrototypeManager();

            manager["2/6/2020"] = foodOrder1;

            manager["23/12/20"] = manager["2/6/2020"].DeepCopy();
            ((FoodOrder)manager["23/12/20"]).Info.Id = 9877;

            manager["2/6/2020"].Debug();

            manager["23/12/20"].Debug();
        }
    }
}
