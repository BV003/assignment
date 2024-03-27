
public class Order
{
    public int OrderId { get; set; }

    public string ProductName { get; set; }
    public Customer Customer { get; set; }

    public int Price { get; set; }

    public List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();
    public double TotalAmount => OrderDetailsList.Sum(od => od.Total);

    public Order(int orderId,string productName,int price, Customer customer)
    {
        OrderId = orderId;
        Customer = customer;
        ProductName = productName;
        Price = price;
    }

    public override bool Equals(object obj)
    {
        if (obj is Order other)
        {
            return OrderId == other.OrderId;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Order {OrderId} for {Customer.Name}, Total: {TotalAmount:C}";
    }
}
