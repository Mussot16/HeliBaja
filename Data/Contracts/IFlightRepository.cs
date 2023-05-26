using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        bool AddFlightToPilot(int Id_Flight, int Id_Pilot);
        bool RemoveFlightFromPilot(int Id_Flight, int Id_Pilot);
        List<Flight> GetFlights();
        bool DeleteFlight(int Id_Flight);
        bool UpdateFlight(Flight flight);
        List<Flight> GetAdminFlights();
        bool AddAdminFlight(Flight flight);
        bool UpdateAdminFlight(Flight flight);
        bool DeleteAdminFlight(int flightId);
    }
}
