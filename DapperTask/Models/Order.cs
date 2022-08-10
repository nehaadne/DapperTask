namespace DapperTask.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderCode { get; set; }
        public string CustomerName { get; set; }

        public long mobile_no { get; set; }
        public string shippingAddress { get; set; }
        public string billingAddress { get; set; }
        public float totalAmount { get; set; }

    }
}
