using System;

namespace PrototypePattern
{
    public class FoodOrder : Prototype
    {
        public string Name { get; set; }

        public bool IsDeliverty { get; set; }

        public string[] Contents { get; set; }

        public OrderInfo Info { get; set; }

        public FoodOrder(string name, bool isDelivery, string[] contents, OrderInfo info)
        {
            Name = name;
            IsDeliverty = isDelivery;
            Contents = contents;
            Info = info;
        }

        public override void Debug()
        {
            Console.WriteLine("------- Prototype Food Order -------");
            Console.WriteLine("\nName: {0} \nDelivery: {1}", this.Name, this.IsDeliverty);
            Console.WriteLine("ID: {0}", this.Info.Id);
            Console.WriteLine("Order Contents: " + string.Join(", ", Contents) + "\n");
        }

        public override Prototype DeepCopy()
        {
            var copy = (FoodOrder) MemberwiseClone();

            copy.Info = new OrderInfo(Info.Id);

            return copy;
        }

        // produces copy where value type properties are copied but reference type
        // properties only have their references copied - so new object reference
        // properties point to old object's
        public override Prototype ShallowCopy()
        {
            return (Prototype)MemberwiseClone();
        }
    }
}
