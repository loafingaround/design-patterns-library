using FlyweightPattern.ConcreteFlyweights;
using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    class BuildingFactory
    {
        // factory manages pool of building instances (just one for each type)
        private static Dictionary<BuildingType, IBuilding> buildings = new Dictionary<BuildingType, IBuilding>();

        public static int BuildingCount { get; set; } = 0;

        public static IBuilding GetBuilding(BuildingType type)
        {
            IBuilding building;

            if(!buildings.TryGetValue(type, out building))
            {
                switch (type)
                {
                    case BuildingType.House:
                        building = new House();
                        break;
                    case BuildingType.School:
                        building = new School();
                        break;
                    case BuildingType.SmallOfficeBlock:
                        building = new SmallOfficeBlock();
                        break;
                    case BuildingType.LargeOfficeBlock:
                        building = new LargeOfficeBlock();
                        break;
                    default:
                        throw new Exception("No such building type '" + type + "'");
                }
                
                buildings.Add(type, building);

                BuildingCount++;
            }

            return building;
        }
    }
}
