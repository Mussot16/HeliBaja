using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IFlightService
    {
        List<Flight> GetFlights();
        List<Flight> GetAdminFlights();
        Flight GetFlightById(int flightId);
        bool AddFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlight(int flightId);
        bool AssignPilotToFlight(int flightId, int pilotId);
        bool RemovePilotFromFlight(int flightId);
    }
}