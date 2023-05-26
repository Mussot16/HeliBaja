using Domain.Model;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IAgendaService
    {
        int CreateAgenda(Agenda agenda);
        bool UpdateAgenda(Agenda agenda);
        bool DeleteAgenda(int agendaId);
        Agenda GetAgendaById(int agendaId);
        List<Agenda> GetAllAgendas();
        bool AddFlightToAgenda(int agendaId, int flightId);
        bool RemoveFlightFromAgenda(int agendaId, int flightId);
    }
}