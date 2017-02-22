using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // component
    interface BreakfastItem
    {
        string Description { get; }

        double Price { get; }
    }
}
