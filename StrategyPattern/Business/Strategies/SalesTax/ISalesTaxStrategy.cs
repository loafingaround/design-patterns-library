using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.SalesTax
{
    // Strategy interface
    public interface ISalesTaxStrategy
    {
        decimal GetTax(Order order);
    }
}