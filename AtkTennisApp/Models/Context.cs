using AtkTennisApp;
using AtkTennisApp.Models;
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
            optionsBuilder.UseSqlServer(Mutuals.DbUrl);
        }
       
        public DbSet<Reservation>reservations { get; set; }
        public DbSet<Court> courts { get; set; }
        public DbSet<ResTime> resTimes { get; set; }
        public DbSet<CourtPriceList> courtPriceLists { get; set; }

        public DbSet<ErrorLog> errorLogs { get; set; }
        public DbSet<ApplicationLog> applicationLogs { get; set; }
        public DbSet<QueryLog> queryLogs { get; set; }
        public DbSet<UserLog> userLogs { get; set; }
        public DbSet<UserSettings> userSettings { get; set; }
        public DbSet<SchoolType> schoolTypes { get; set; }
        public DbSet<SchoolLevel> schoolLevels { get; set; }



    }
}
