using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;

namespace Business.Implementation
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public int CreateAgenda(Agenda agenda)
        {
            return _agendaRepository.Add(agenda);
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            return _agendaRepository.Update(agenda);
        }

        public bool DeleteAgenda(int agendaId)
        {
            return _agendaRepository.Delete(agendaId);
        }

        public Agenda GetAgendaById(int agendaId)
        {
            return _agendaRepository.Get(agendaId);
        }

        public bool AddFlightToAgenda(int agendaId, int flightId)
        {
            return _agendaRepository.AddFlight(agendaId, flightId);
        }

        public bool RemoveFlightFromAgenda(int agendaId, int flightId)
        {
            return _agendaRepository.RemoveFlight(agendaId, flightId);
        }

        public List<Agenda> GetAllAgendas()
        {
            return _agendaRepository.GetAdminAgenda();
        }
    }
}