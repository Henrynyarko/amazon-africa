namespace AmazonAfrica.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
