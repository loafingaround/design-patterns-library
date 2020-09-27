using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    // Strategy interface
    public interface ISalesTaxStrategy
    {
        decimal GetTax(Order order);
    }
}