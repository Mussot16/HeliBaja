using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pilots
    {
        [Key]
        public int Id_Pilot { get; set; }
        public string Name { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Agenda> Agendas { get; set; }
    }
}
