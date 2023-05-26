using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Clients
    {
        [Key]
        public int Id_Client { get; set; }
        public string Name { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Propiedad de navegación para las reservas del cliente
        public List<Booking> Bookings { get; set; }
    }
}
