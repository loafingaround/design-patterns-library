using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    public interface ISalesTaxStrategy
    {
        decimal GetTax(Order order);
    }
}