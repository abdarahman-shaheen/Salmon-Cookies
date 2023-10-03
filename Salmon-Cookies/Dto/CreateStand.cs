using Salmon_Cookies.Model;

namespace Salmon_Cookies.Dto
{
    public class CreateStand
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }
    }
}
