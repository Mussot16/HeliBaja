using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Agenda
    {
        [Key]
        public int Id_Agenda { get; set; }
        public DateTime Fecha { get; set; }
        public string Description { get; set; }
        public List<Flight> Flights { get; set; }
        public Flight Flight { get; set; }
    }
}
