using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Mustard : BreakfastItemDecorator
    {
        public Mustard(BreakfastItem breakfastItem) : base(breakfastItem)
        {
        }

        public override string Description
        {
            get
            {
                return base.Description + " with mustard";
            }
        }

        public override double Price
        {
            get
            {
                return base.Price + .8;
            }
        }
    }
}
