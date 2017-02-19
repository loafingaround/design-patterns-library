using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // "Concrete builder"
    class PloughmansSandwichBuilder : SandwichBuilder
    {
        public override void AddCondiments()
        {
            sandwich.HasMayo = false;
            sandwich.HasMustard = true;
        }

        public override void ApplyMeatAndCheese()
        {
            sandwich.MeatType = MeatType.Ham;
            sandwich.CheeseType = CheeseType.Cheddar;
        }

        public override void ApplyVegetables()
        {
            sandwich.Vegetables = new List<string>
            {
                "Tomato",
                "Beetroot"
            };
        }

        public override void PrepareBread()
        {
            sandwich.BreadType = BreadType.Wholemeal;
            sandwich.IsToasted = false;
        }

        public override void SetName()
        {
            sandwich.Name = "Ploughman's";
        }
    }
}
