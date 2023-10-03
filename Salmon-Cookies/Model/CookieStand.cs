namespace Salmon_Cookies.Model
{
    public class CookieStand
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }
        public List<HourSales>? Hours { get; set; }

    }

    public class HourSales
    {
        public int Id { get; set; }

        public int Hour { get; set; }

        public int CookieStandid { get; set; }
        public CookieStand cookieStand { get; set; }
    }
}
