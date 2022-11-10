namespace Novanet.OrderService.Domain
{
    public class OrderLine
    {
        public OrderLine(int productId, string? productName, decimal cost, decimal quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Cost = cost;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal WeightPerUnit { get; set; }
        public decimal WeightTotal { get; set; }
        public decimal Cost { get; set; }
    }
}
