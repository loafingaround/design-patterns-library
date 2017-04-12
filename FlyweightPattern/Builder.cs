using System;

namespace FlyweightPattern
{
    class Builder
    {
        string buildingType;
        int numberOfRooms;
        int numberOfStoreys;

        public Builder(string buildingType, int numberOfRooms, int numberOfStoreys)
        {
            this.buildingType = buildingType;
            this.numberOfRooms = numberOfRooms;
            this.numberOfStoreys = numberOfStoreys;
        }

        public void Build(int plotNumber)
        {
            Console.WriteLine("Building a {0} on plot no. {1} with {2} rooms and {3} storeys.", buildingType.ToUpper(), plotNumber, numberOfRooms, numberOfStoreys);
        }
    }
}
