using Data.Contracts;
using Domain.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public PilotRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var pilot = await _dbContext.Pilots.FindAsync(id);
            if (pilot == null)
            {
                return false;
            }
            _dbContext.Pilots.Remove(pilot);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Pilots> GetById(int id)
        {
            return await _dbContext.Pilots.FindAsync(id);
        }

        public async Task<IEnumerable<Pilots>> GetAll()
        {
            return await _dbContext.Pilots.ToListAsync();
        }

        public async Task<bool> Update(Pilots pilot)
        {
            if (!_dbContext.Pilots.Local.Any(p => p.Id_Pilot == pilot.Id_Pilot))
            {
                _dbContext.Pilots.Attach(pilot);
            }
            _dbContext.Entry(pilot).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public List<Flight> GetFlights(int pilotId)
        {
            var flights = _dbContext.Flights.Where(f => f.PilotId == pilotId).ToList();
            return flights;
        }

        public bool AddFlightToPilot(int flightId, int pilotId)
        {
            var pilot = _dbContext.Pilots.Find(pilotId);
            var flight = _dbContext.Flights.Find(flightId);
            if (pilot == null || flight == null)
            {
                return false;
            }
            pilot.Flights.Add(flight);
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveFlightFromPilot(int flightId, int pilotId)
        {
            var pilot = _dbContext.Pilots.Find(pilotId);
            var flight = _dbContext.Flights.Find(flightId);
            if (pilot == null || flight == null)
            {
                return false;
            }
            pilot.Flights.Remove(flight);
            _dbContext.SaveChanges();
            return true;
        }

        public int Add(Pilots entity)
        {
            _dbContext.Pilots.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Pilot;
        }

        public Pilots Get(int id)
        {
            return _dbContext.Pilots.FirstOrDefault(p => p.Id_Pilot == id);
        }

        bool IGenericRepository<Pilots>.Update(Pilots entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        bool IGenericRepository<Pilots>.Delete(int id)
        {
            var pilot = _dbContext.Pilots.FirstOrDefault(p => p.Id_Pilot == id);
            if (pilot != null)
            {
                _dbContext.Pilots.Remove(pilot);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Pilots>> GetAllPilots()
        {
            return await _dbContext.Pilots.ToListAsync();
        }

        public async Task<Pilots> GetPilotById(int pilotId)
        {
            return await _dbContext.Pilots.FindAsync(pilotId);
        }

        public async Task<int> AddPilot(Pilots pilot)
        {
            _dbContext.Pilots.Add(pilot);
            await _dbContext.SaveChangesAsync();
            return pilot.Id_Pilot;
        }

        public async Task<bool> UpdatePilot(Pilots pilot)
        {
            if (!_dbContext.Pilots.Local.Any(p => p.Id_Pilot == pilot.Id_Pilot))
            {
                _dbContext.Pilots.Attach(pilot);
            }
            _dbContext.Entry(pilot).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePilot(int pilotId)
        {
            var pilot = await _dbContext.Pilots.FindAsync(pilotId);
            if (pilot == null)
            {
                return false;
            }
            _dbContext.Pilots.Remove(pilot);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}