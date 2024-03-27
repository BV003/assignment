public class OrderDetails
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }

    public OrderDetails(string productName, int quantity, double unitPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public double Total => Quantity * UnitPrice;

    public override string ToString()
    {
        return $"{ProductName} - Quantity: {Quantity}, Total: {Total:C}";
    }
}
