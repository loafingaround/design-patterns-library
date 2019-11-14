using MediatorPattern.Colleagues;

namespace MediatorPattern
{
    public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft aircraft);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }
}