using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccelerable electricEngine = new ElectricEngine();
            IAccelerable dieselEngine = new DieselEngine();

            Train[] trains =
            {
                new Rail(electricEngine),
                new Monorail(electricEngine),
                new Rail(dieselEngine),
                new Monorail(dieselEngine)
            };

            foreach (Train train in trains)
                train.move();

            Console.ReadLine();
        }
    }
}

// following bridge pattern implementation allows to combine two aspects, abstractions, of train movement, rail type and engine type, without
// having to do implementation of each combination, i.e. four implementations here.

abstract class Train
{
    protected IAccelerable accelerable;

    public Train(IAccelerable accelerable)
    {
        this.accelerable = accelerable;
    }

    public abstract void move();
}

class Rail : Train
{
    public Rail(IAccelerable accelerable) : base(accelerable)
    {
    }

    public override void move()
    {
        Console.WriteLine("moving rail train:");
        this.accelerable.accelerate();
    }
}

class Monorail : Train
{
    public Monorail(IAccelerable accelerable) : base(accelerable)
    {
    }

    public override void move()
    {
        Console.WriteLine("moving monorail train:");
        this.accelerable.accelerate();
    }
}

interface IAccelerable
{
    void accelerate();
}

class ElectricEngine : IAccelerable
{
    public void accelerate()
    {
        Console.WriteLine("accelerating using electric engine");
    }
}

class DieselEngine : IAccelerable
{
    public void accelerate()
    {
        Console.WriteLine("accelerating using diesel engine");
    }
}