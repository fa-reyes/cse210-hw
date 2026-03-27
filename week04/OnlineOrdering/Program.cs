using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Disney St", "Orlando", "FL", "USA");
        Customer cust1 = new Customer("Mickey Mouse", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Mouse Ears", "ME01", 15.99, 2));
        order1.AddProduct(new Product("Magic Wand", "MW99", 45.00, 1));

        Address addr2 = new Address("Av. Siempre Viva 742", "Santiago", "RM", "Chile");
        Customer cust2 = new Customer("Homer Simpson", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Donuts Box", "DB05", 10.00, 3));
        order2.AddProduct(new Product("Duff Beer", "DB01", 5.50, 6));

        List<Order> orders = new List<Order> { order1, order2 };
        foreach (var o in orders)
        {
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine($"Total Price: ${o.CalculateTotal():0.00}");
            Console.WriteLine("----------------------------------\n");
        }
    }
}