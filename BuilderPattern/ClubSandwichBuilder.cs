using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // "Concrete builder"
    class ClubSandwichBuilder : SandwichBuilder
    {
        public override void AddCondiments()
        {
            sandwich.HasMayo = true;
            sandwich.HasMustard = true;
        }

        public override void ApplyMeatAndCheese()
        {
            sandwich.MeatType = MeatType.Turkey;
            sandwich.CheeseType = CheeseType.Swiss;
        }

        public override void ApplyVegetables()
        {
            sandwich.Vegetables = new List<string>
            {
                "Tomato",
                "Onion"
            };
        }

        public override void PrepareBread()
        {
            sandwich.BreadType = BreadType.Italian;
            sandwich.IsToasted = true;
        }

        public override void SetName()
        {
            sandwich.Name = "Club";
        }
    }
}
