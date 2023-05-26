using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IPilotService
    {
        Task<IEnumerable<Pilots>> GetAllPilots();
        Task<Pilots> GetPilotById(int pilotId);
        Task<int> AddPilot(Pilots pilot);
        Task<bool> UpdatePilot(Pilots pilot);
        Task<bool> DeletePilot(int pilotId);
        List<Flight> GetFlights(int pilotId);
        bool AddFlightToPilot(int flightId, int pilotId);
        bool RemoveFlightFromPilot(int flightId, int pilotId);
    }
}