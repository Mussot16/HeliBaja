using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Model;

namespace Data
{
    public class HeliBajaDBContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Pilots> Pilots { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public HeliBajaDBContext() : base("HeliBaja")
        {

        }
    }
}