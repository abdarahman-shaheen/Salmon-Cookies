using Microsoft.EntityFrameworkCore;
using Salmon_Cookies.Data;
using Salmon_Cookies.Dto;
using Salmon_Cookies.Interface;
using Salmon_Cookies.Model;

namespace Salmon_Cookies.Service
{
    public class StandCookiesService : IStandCookies
    {
        private readonly StandDbContext _dbContext;

        public StandCookiesService(StandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CookieStand> Create(CreateStand stand)
        {
            var stanCookies = new CookieStand()
            {
                AverageCookiesPerSale = stand.AverageCookiesPerSale,
                Description = stand.Description,
                Location = stand.Location,
                MaximumCustomersPerHour = stand.MaximumCustomersPerHour,
                MinimumCustomersPerHour = stand.MinimumCustomersPerHour,
                Owner = stand.Owner,
            };
            stanCookies.Hours = await GenerateHourlySales(stanCookies);

        await _dbContext.CookieStands.AddAsync(stanCookies);
            //_dbContext.Entry(stand).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return stanCookies;
        }
        private async Task<List<HourSales>> GenerateHourlySales(CookieStand stand)
        {
            if (stand.Hours != null)
            {
                for (var i = 0; i < stand.Hours.Count; i++)
                {
                    _dbContext.HourSales.Remove(stand.Hours[i]);    
                }
            }

            for (int hour = 0; hour < 12; hour++)
            {
                int Hour = GenerateRandomHour(stand.MinimumCustomersPerHour * stand.AverageCookiesPerSale, stand.MaximumCustomersPerHour * stand.AverageCookiesPerSale);
                stand.Hours.Add(new HourSales { Hour = Hour, CookieStandid = stand.Id });
            }

            return stand.Hours;

        }

        private int GenerateRandomHour(double min, double max)
        {
            Random random = new Random();
            return random.Next((int)min, (int)max + 1);
        }

        public async Task<CookieStand> Delete(int id)
        {
     var cookieStand=  await _dbContext.CookieStands.FindAsync(id);
            _dbContext.CookieStands.Remove(cookieStand);
            return cookieStand;
        }

        public async Task<List<ViewStandCookies>> Get()
        {
            var cookieStands =await _dbContext.CookieStands.Include(x=>x.Hours).Select(v=>new ViewStandCookies
            {
                AverageCookiesPerSale = v.AverageCookiesPerSale,
                Description = v.Description,
                Location    = v.Location,
                MaximumCustomersPerHour = v.MaximumCustomersPerHour,
                MinimumCustomersPerHour = v.MinimumCustomersPerHour,
                Owner = v.Owner,
                Hourss = v.Hours.Select(hour => hour.Hour).ToList()
            }).ToListAsync();
            return cookieStands;
        }
      
        public async Task<ViewStandCookies> GetById(int id)
        {
            var cookieStands = await _dbContext.CookieStands.Where(x => x.Id == id).Include(x => x.Hours)
                .Select(s => new ViewStandCookies
                {
                    AverageCookiesPerSale = s.AverageCookiesPerSale,
                    Description = s.Description,
                    Location = s.Location,
                    MaximumCustomersPerHour = s.MaximumCustomersPerHour,
                    MinimumCustomersPerHour = s.MinimumCustomersPerHour,
                    Owner = s.Owner,
                    Hourss = s.Hours.Select(s => s.Hour).ToList()
                }).FirstOrDefaultAsync();
            return cookieStands;

        }

       


        public async Task<CookieStand> Put(int id, CreateStand updateStand)
        {
            var StandCookies = await _dbContext.CookieStands.Include(x=>x.Hours).Where(i=>i.Id==id).FirstOrDefaultAsync();
            StandCookies.Location = updateStand.Location;
            StandCookies.MaximumCustomersPerHour = updateStand.MaximumCustomersPerHour;
            StandCookies.MinimumCustomersPerHour=updateStand.MinimumCustomersPerHour;
            StandCookies.Description = updateStand.Description;
            StandCookies.AverageCookiesPerSale = updateStand.AverageCookiesPerSale;
            StandCookies.Owner = updateStand.Owner;
            await GenerateHourlySales(StandCookies);
            await _dbContext.SaveChangesAsync();
           return StandCookies;
        }
    }
}
