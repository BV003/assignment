using System;
using System.Linq;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            string input;
            do
            {
                Console.WriteLine("Please enter a command (add, delete, query, sort, exit):");
                input = Console.ReadLine().ToLower().Trim();

                switch (input)
                {
                    case "add":
                        AddOrder(orderService);
                        break;
                    case "delete":
                        DeleteOrder(orderService);
                        break;
                    case "query":
                        QueryOrders(orderService);
                        break;
                    case "sort":
                        SortOrders(orderService);
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            } while (input != "exit");
        }

        static void AddOrder(OrderService service)
        {
            Console.WriteLine("Enter new order ID:");
            if (!int.TryParse(Console.ReadLine(), out int newOrderId) || newOrderId <= 0)
            {
                Console.WriteLine("Invalid order ID. Please enter a positive integer.");
                return;
            }

            Console.WriteLine("Enter product name:");
            string productName = Console.ReadLine();



            Console.WriteLine("Enter customer name:");
            string customerName = Console.ReadLine();


            // 创建客户对象
            var customer = new Customer(customerName, "s");

            Console.WriteLine("Enter order amount:");
            if (!int.TryParse(Console.ReadLine(), out int orderAmount) || orderAmount <= 0)
            {
                Console.WriteLine("Invalid order amount. Please enter a positive number.");
                return;
            }

            // 检查订单ID是否已存在
            if (service.OrderExists(newOrderId))
            {
                Console.WriteLine("An order with the same ID already exists.");
                return;
            }

            // 创建一个新的订单实例
            var newOrder = new Order(newOrderId,productName, orderAmount, customer);

            // 尝试添加订单
            try
            {
                service.AddOrder(newOrder);
                Console.WriteLine("Order added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteOrder(OrderService service)
        {
            Console.WriteLine("Enter the order ID to delete:");
            string input = Console.ReadLine();

            // 尝试解析用户输入的订单ID
            if (!int.TryParse(input, out int orderId) || orderId <= 0)
            {
                Console.WriteLine("Invalid order ID. Please enter a positive integer.");
                return;
            }

            // 调用 OrderService 的 DeleteOrder 方法来删除订单
            if (service.DeleteOrder(orderId))
            {
                Console.WriteLine($"Order with ID {orderId} has been deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Order with ID {orderId} not found or could not be deleted.");
            }
        }

        static void QueryOrders(OrderService service)
        {
            // 示例：查询所有订单
            var orders = service.QueryOrders("Product1");
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        static void SortOrders(OrderService service)
        {
            // 示例：按订单总金额排序
            service.SortOrders(o => o.OrderId);
            Console.WriteLine("Orders sorted by Order ID.");
        }

        
    }

}