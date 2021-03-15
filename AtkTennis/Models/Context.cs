using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=185.141.33.151,1433\\SQLEXPRESS01; Database = AtkTennis; User ID = sa; password =Nostradamus3347;");
        }

        public DbSet<Reservation>reservations { get; set; }
        public DbSet<Court> courts { get; set; }
        public DbSet<ResTime> resTimes { get; set; }
        

    }
}
