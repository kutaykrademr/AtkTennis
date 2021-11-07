using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public class IdContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = 185.141.33.151, 1433\\SQLEXPRESS; Database=IdentityApiTenis; User ID=sa; password=Nostradamus3347;");
        }

        public DbSet<MemberList> memberLİst { get; set; }

    }
}
