using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly HeliBajaDBContext _context;

        public AgendaRepository(HeliBajaDBContext context)
        {
            _context = context;
        }

        public int Add(Agenda entity)
        {
            _context.Agendas.Add(entity);
            _context.SaveChanges();
            return entity.Id_Agenda;
        }

        public bool AddAdminAgenda(Agenda entry)
        {
            _context.Agendas.Add(entry);
            return _context.SaveChanges() > 0;
        }

        public bool AddFlight(int Id_Agenda, int Id_Flight)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == Id_Agenda);
            if (agenda != null)
            {
                var flight = _context.Flights.FirstOrDefault(f => f.Id_Flight == Id_Flight);
                if (flight != null)
                {
                    agenda.Flights.Add(flight);
                    return _context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == id);
            if (agenda != null)
            {
                _context.Agendas.Remove(agenda);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteAdminAgenda(int entryId)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == entryId && a.Flight == null);
            if (agenda != null)
            {
                _context.Agendas.Remove(agenda);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Agenda Get(int id)
        {
            return _context.Agendas.FirstOrDefault(a => a.Id_Agenda == id);
        }

        public List<Agenda> GetAdminAgenda()
        {
            return _context.Agendas.Where(a => a.Flight == null).ToList();
        }

        public Agenda GetAdminAgendaById(int entryId)
        {
            return _context.Agendas.FirstOrDefault(a => a.Id_Agenda == entryId && a.Flight == null);
        }

        public List<Flight> GetFlights(int Id_Agenda)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == Id_Agenda);
            return agenda?.Flights.ToList();
        }

        public bool RemoveFlight(int Id_Agenda, int Id_Flight)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == Id_Agenda);
            if (agenda != null)
            {
                var flight = agenda.Flights.FirstOrDefault(f => f.Id_Flight == Id_Flight);
                if (flight != null)
                {
                    agenda.Flights.Remove(flight);
                    return _context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Update(Agenda entity)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == entity.Id_Agenda);
            if (agenda != null)
            {
                agenda.Fecha = entity.Fecha;
                agenda.Description = entity.Description;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpdateAdminAgenda(Agenda entry)
        {
            var agenda = _context.Agendas.FirstOrDefault(a => a.Id_Agenda == entry.Id_Agenda && a.Flight == null);
            if (agenda != null)
            {
                agenda.Fecha = entry.Fecha;
                agenda.Description = entry.Description;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}