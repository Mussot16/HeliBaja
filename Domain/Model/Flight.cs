using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Flight
    {
        [Key]
        public int Id_Flight { get; set; }
        public string NumeroVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public List<Booking> Bookings { get; set; }

        // Propiedad de navegación a Agenda
        public Agenda Agendas { get; set; }
        public int Id_Agenda { get; set; }
        public int PilotId { get; set; }
    }
}
