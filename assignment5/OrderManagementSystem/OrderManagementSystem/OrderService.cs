using System;
using System.Collections.Generic;
using System.Linq;

public class OrderService
{
    private List<Order> _orders = new List<Order>();

    // 添加订单
    public void AddOrder(Order order)
    {
        if (_orders.Any(o => o.OrderId == order.OrderId))
        {
            throw new ArgumentException("An order with the same ID already exists.");
        }
        _orders.Add(order);
    }


    
    public bool OrderExists(int orderId)
    {
        return _orders.Any(order => order.OrderId == orderId);
    }

   
        // 删除订单
     public bool DeleteOrder(int orderId)
    {
        var orderToRemove = _orders.FirstOrDefault(o => o.OrderId == orderId);
        if (orderToRemove == null)
        {
            Console.WriteLine("Order not found.");
            return false;
        }

        // 从 _orders 列表中移除订单
        _orders.Remove(orderToRemove);
        Console.WriteLine("Order deleted successfully.");
        return true;
    }

    // 查询订单
    public IEnumerable<Order> QueryOrders(string productName)
    {
        return _orders.Where(o => o.OrderDetailsList.Any(od => od.ProductName == productName))
                    .OrderBy(o => o.TotalAmount);
    }

    // 排序订单
    public void SortOrders(Func<Order, int> sortingCriteria)
    {
        _orders = _orders.OrderBy(sortingCriteria).ToList();
    }
}