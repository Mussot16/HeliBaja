using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPilotRepository : IGenericRepository<Pilots>
    {
        List<Flight> GetFlights(int pilotId);
        bool AddFlightToPilot(int flightId, int pilotId);
        bool RemoveFlightFromPilot(int flightId, int pilotId);
        Task<IEnumerable<Pilots>> GetAllPilots();
        Task<Pilots> GetPilotById(int pilotId);
        Task<int> AddPilot(Pilots pilot);
        Task<bool> UpdatePilot(Pilots pilot);
        Task<bool> DeletePilot(int pilotId);
    }
}
