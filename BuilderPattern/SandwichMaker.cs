using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // "Director"
    // contains _logic_ (steps to make sandwich) only, with guaranteed order and completeness of steps - no partially contructed object,
    // where may have dependencies, and may need to carry out validation in process (e.g. that certain steps are valid or certain things been set before others)
    class SandwichMaker
    {
        private readonly SandwichBuilder builder;

        public SandwichMaker(SandwichBuilder sandwichBuilder)
        {
            this.builder = sandwichBuilder;
        }

        public void BuildSandwich()
        {
            builder.CreateSandwich();
            builder.SetName();
            builder.PrepareBread();
            builder.ApplyMeatAndCheese();
            builder.ApplyVegetables();
            builder.AddCondiments();
        }

        public Sandwich GetSandwich()
        {
            return builder.GetSandwich();
        }
    }
}
