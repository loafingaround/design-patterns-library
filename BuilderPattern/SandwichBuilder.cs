using System.Collections.Generic;

namespace BuilderPattern
{
    // "Builder"
    // contains _data_ (ingredients) only - setting of properties in method implementations
    // to create new type of sandwich, simply extend this abstract class
    abstract class SandwichBuilder
    {
        protected Sandwich sandwich;

        public void CreateSandwich()
        {
            sandwich = new Sandwich();
        }

        public Sandwich GetSandwich()
        {
            return sandwich;
        }

        public abstract void PrepareBread();
        public abstract void ApplyMeatAndCheese();
        public abstract void ApplyVegetables();
        public abstract void AddCondiments();
        public abstract void SetName();
    }
}