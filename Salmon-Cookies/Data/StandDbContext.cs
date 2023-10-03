using Microsoft.EntityFrameworkCore;
using Salmon_Cookies.Model;

namespace Salmon_Cookies.Data
{
    public class StandDbContext : DbContext
    {
        public StandDbContext(DbContextOptions<StandDbContext> options) : base(options)
        {
        }

        public DbSet<CookieStand> CookieStands { get; set; }
        public DbSet<HourSales> HourSales { get; set; }
    }
}