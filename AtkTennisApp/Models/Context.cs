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
        public DbSet<ReservationCancel>reservationCancels { get; set; }
        public DbSet<Court> courts { get; set; }
        public DbSet<ResTime> resTimes { get; set; }
        public DbSet<CourtPriceList> courtPriceLists { get; set; }
        public DbSet<CourtRecipeType> courtRecipeTypes { get; set; }
        public DbSet<CourtScaleList> courtScaleLists { get; set; }

        public DbSet<ErrorLog> errorLogs { get; set; }
        public DbSet<ApplicationLog> applicationLogs { get; set; }
        public DbSet<QueryLog> queryLogs { get; set; }
        public DbSet<UserLog> userLogs { get; set; }
        public DbSet<UserSettings> userSettings { get; set; }

        public DbSet<SchoolType> schoolTypes { get; set; }
        public DbSet<SchoolLevel> schoolLevels { get; set; }
        public DbSet<SchoolPrice> schoolPrices { get; set; }

        public DbSet<SchoolPriceType> schoolPriceTypes { get; set; }
        public DbSet<MemberCanDebt> memberCanDebts { get; set; }

        public DbSet<CabinetType> cabinetTypes { get; set; }
        public DbSet<CabinetOperations> cabinetOperations { get; set; }
        public DbSet<CabinetListUser> cabinetListUsers { get; set; }
      

        public DbSet<MemberDuesType> memberDuesTypes { get; set; }
        public DbSet<MemberDebtType> memberDebtTypes { get; set; }
        public DbSet<MemberDuesInfTable> memberDuesInfTables { get; set; }


        public DbSet<PerformanceType> performanceTypes { get; set; }
        public DbSet<PerformanceLevel> performanceLevels { get; set; }

        public DbSet<PrivateLesson> privateLessons { get; set; }

        public DbSet<ReservationSettings> reservationSettings { get; set; }

        public DbSet<MemberList> memberLists { get; set; }
  
        public DbSet<ToDoList> toDoLists { get; set; }

        public DbSet<AllGetPaidLogs> allGetPaidLogs { get; set; }


    }
}
