using Salmon_Cookies.Model;

namespace Salmon_Cookies.Dto
{
    public class ViewStandCookies
    {
        public string Location { get; set; }

        public List<int> Hourss { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }
    }
}
