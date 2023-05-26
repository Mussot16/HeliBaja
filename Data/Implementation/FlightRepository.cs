using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class FlightRepository : IFlightRepository
    {
        private readonly HeliBajaDBContext _context;

        public FlightRepository(HeliBajaDBContext context)
        {
            _context = context;
        }

        public int Add(Flight entity)
        {
            _context.Flights.Add(entity);
            return _context.SaveChanges();
        }

        public bool AddAdminFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlightToPilot(int Id_Flight, int Id_Pilot)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == Id_Flight);
            if (flight != null)
            {
                flight.PilotId = Id_Pilot;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteAdminFlight(int flightId)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == flightId && f.PilotId == 0);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteFlight(int Id_Flight)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == Id_Flight);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Flight Get(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.Id_Flight == id);
        }

        public List<Flight> GetAdminFlights()
        {
            return _context.Flights.Where(f => f.PilotId == 0).ToList();
        }

        public List<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public bool RemoveFlightFromPilot(int Id_Flight, int Id_Pilot)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == Id_Flight && f.PilotId == Id_Pilot);
            if (flight != null)
            {
                flight.PilotId = 0; // Asignar un valor de 0 en lugar de nulo para el ID del piloto
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Flight entity)
        {
            var existingFlight = _context.Flights.FirstOrDefault(f => f.Id_Flight == entity.Id_Flight);
            if (existingFlight != null)
            {
                existingFlight.NumeroVuelo = entity.NumeroVuelo;
                existingFlight.Origen = entity.Origen;
                existingFlight.Destino = entity.Destino;
                existingFlight.HoraSalida = entity.HoraSalida;
                existingFlight.HoraLlegada = entity.HoraLlegada;
                existingFlight.Bookings = entity.Bookings;
                existingFlight.Agendas = entity.Agendas;
                existingFlight.Id_Agenda = entity.Id_Agenda;
                existingFlight.PilotId = entity.PilotId;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpdateAdminFlight(Flight flight)
        {
            var existingFlight = _context.Flights.FirstOrDefault(f => f.Id_Flight == flight.Id_Flight && f.PilotId == 0);
            if (existingFlight != null)
            {
                existingFlight.NumeroVuelo = flight.NumeroVuelo;
                existingFlight.Origen = flight.Origen;
                existingFlight.Destino = flight.Destino;
                existingFlight.HoraSalida = flight.HoraSalida;
                existingFlight.HoraLlegada = flight.HoraLlegada;
                existingFlight.Bookings = flight.Bookings;
                existingFlight.Agendas = flight.Agendas;
                existingFlight.Id_Agenda = flight.Id_Agenda;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpdateFlight(Flight flight)
        {
            var existingFlight = _context.Flights.FirstOrDefault(f => f.Id_Flight == flight.Id_Flight);
            if (existingFlight != null)
            {
                existingFlight.NumeroVuelo = flight.NumeroVuelo;
                existingFlight.Origen = flight.Origen;
                existingFlight.Destino = flight.Destino;
                existingFlight.HoraSalida = flight.HoraSalida;
                existingFlight.HoraLlegada = flight.HoraLlegada;
                existingFlight.Bookings = flight.Bookings;
                existingFlight.Agendas = flight.Agendas;
                existingFlight.Id_Agenda = flight.Id_Agenda;
                existingFlight.PilotId = flight.PilotId;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
