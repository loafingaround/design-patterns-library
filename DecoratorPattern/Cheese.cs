using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Cheese : BreakfastItemDecorator
    {
        public Cheese(BreakfastItem breakfastItem) : base(breakfastItem)
        {
        }

        public override string Description
        {
            get
            {
                return base.Description + " with cheese";
            }
        }

        public override double Price
        {
            get
            {
                return base.Price + 1.2;
            }
        }
    }
}
