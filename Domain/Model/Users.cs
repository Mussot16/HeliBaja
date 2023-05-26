using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string APaterno { get; set; }

        public string AMaterno { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? PilotId { get; set; }

        public int? ClientId { get; set; }

        // Propiedades de navegación
        public virtual Clients Cliente { get; set; }

        public virtual Pilots Piloto { get; set; }
        public bool IsAdmin { get; set; }
    }
}
