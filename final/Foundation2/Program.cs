using System;

namespace Foundation4Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customers
            var cust1 = new Customer("Alice Brown", new Address("123 Maple St", "Orlando", "FL", "USA"));
            var cust2 = new Customer("Bob Green",  new Address("456 Oak Rd",    "Toronto", "ON", "Canada"));

            // Order 1
            var order1 = new Order(cust1);
            order1.AddProduct(new Product("Widget",      "W123", 3.50m, 4));
            order1.AddProduct(new Product("Gizmo",       "G456", 5.75m, 2));

            // Order 2
            var order2 = new Order(cust2);
            order2.AddProduct(new Product("Thingamajig","T789", 7.25m, 3));
            order2.AddProduct(new Product("Doohickey",  "D012", 2.00m, 5));

            // Display Order 1
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order1.GetTotalPrice():C}\n");

            // Display Order 2
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order2.GetTotalPrice():C}");
        }
    }
}
