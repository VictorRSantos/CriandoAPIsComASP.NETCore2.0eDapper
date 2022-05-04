namespace BaltaStore.Domain.StoreContext
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }

    }
}