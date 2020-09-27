namespace StrategyPattern.Business.Models
{
    public class Item
    {
        public Item(string id, string name, ItemType type, decimal price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }

        public string Id { get; }
        public string Name { get; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }
    }
}