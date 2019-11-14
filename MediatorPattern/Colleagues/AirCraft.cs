using System;

namespace MediatorPattern.Colleagues
{
    public abstract class Aircraft
    {
        decimal altitude;
        string CallSign { get; }
        IAirTrafficControl Atc { get; }

        public Aircraft(string callSign, IAirTrafficControl atc /* this is our mediator */)
        {
            CallSign = callSign;
            Atc = atc;
            atc.RegisterAircraftUnderGuidance(this); // inform mediator of presence so it knows it may need to communicate with us
        }

        public abstract  int Ceiling { get; }

        public decimal Altitude
        {
            get => altitude;
            set
            {
                altitude = value;
                Atc.ReceiveAircraftLocation(this);
            }
        }

        public void Climb(int ascent)
        {
            Altitude += ascent;
        }

        public void WarnOfAirspaceIntrusionBy(Aircraft aircraft)
        {
            Console.WriteLine($"{CallSign} notified of intrusion of its airspace by {aircraft.CallSign}.");
        }
    }
}