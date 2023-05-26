using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public List<Flight> GetFlights()
        {
            return _flightRepository.GetFlights();
        }

        public List<Flight> GetAdminFlights()
        {
            return _flightRepository.GetAdminFlights();
        }

        public Flight GetFlightById(int flightId)
        {
            return _flightRepository.Get(flightId);
        }

        public bool AddFlight(Flight flight)
        {
            return _flightRepository.Add(flight) > 0;
        }

        public bool UpdateFlight(Flight flight)
        {
            return _flightRepository.Update(flight);
        }

        public bool DeleteFlight(int flightId)
        {
            return _flightRepository.Delete(flightId);
        }

        public bool AssignPilotToFlight(int flightId, int pilotId)
        {
            return _flightRepository.AddFlightToPilot(flightId, pilotId);
        }

        public bool RemovePilotFromFlight(int flightId)
        {
            int pilotId = 0; 

            return _flightRepository.RemoveFlightFromPilot(flightId, pilotId);
        }
    }
}