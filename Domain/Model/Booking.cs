using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Booking
    {
        [Key]
        public int Id_Booking { get; set; }
        public int Id_Client { get; set; }
        public int Id_Flight { get; set; }

        // Propiedad de navegación
        public Clients Clients { get; set; }
        public Flight Flights { get; set; }
    }
}