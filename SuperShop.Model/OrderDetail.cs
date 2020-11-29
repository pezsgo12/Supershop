namespace SuperShop.Model
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Price { get; set; }
        public int ItemCount { get; set; }
    }
}
