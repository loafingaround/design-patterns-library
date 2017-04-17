using System;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            const int numberOfPlots = 500;
            
            int numberOfBuildingTypes = Enum.GetValues(typeof(BuildingType)).Length;

            for(int plotNumber = 0; plotNumber < numberOfPlots; plotNumber++)
            {
                // pick random BuildingType enum value...
                int buildingTypeValue = random.Next(0, numberOfBuildingTypes);

                // ...in order to get a random building type
                BuildingType buildingType = (BuildingType) Enum.ToObject(typeof(BuildingType), buildingTypeValue);

                IBuilding building = BuildingFactory.GetBuilding(buildingType);

                // plot number, extrinsic state, is computed and passed in when required, instead of being passed into constructor
                building.Build(plotNumber);
            }

            Console.WriteLine("Totals:\n=======");
            Console.WriteLine("No. buildings built: {0}", numberOfPlots);
            Console.WriteLine("No. building instances constructed: {0}", BuildingFactory.BuildingCount);

            Console.ReadLine();
        }
    }
}
