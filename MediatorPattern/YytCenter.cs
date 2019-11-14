using System;
using System.Collections.Generic;
using System.Linq;
using MediatorPattern.Colleagues;

namespace MediatorPattern
{
    // This is the mediator
    public class YytCenter: IAirTrafficControl
    {
        readonly IList<Aircraft> airCraftUnderGuidance = new List<Aircraft>();

        public void ReceiveAircraftLocation(Aircraft aircraft)
        {
            foreach (var aircraftUg in airCraftUnderGuidance.Where(acug => acug != aircraft))
            {
                if (Math.Abs(aircraftUg.Altitude - aircraft.Altitude) < 1000) // check reporting aircraft is not too close to others
                {
                    aircraft.Climb(1000); // tell reporting aircraft to climb
                    aircraftUg.WarnOfAirspaceIntrusionBy(aircraft); // warn other aircraft of intrusion of its airspace
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if(!airCraftUnderGuidance.Contains(aircraft))
                airCraftUnderGuidance.Add(aircraft);
        }
    }
}