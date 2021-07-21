namespace JewelleryInfo.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Customertype { get; set; }
        public double GoldPrice { get; set; }
        public float Weight { get; set; }
        public double TotalPrice { get; set; }
        public float Discount { get; set; }
    }
}