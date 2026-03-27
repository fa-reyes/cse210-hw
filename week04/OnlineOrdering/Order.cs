using System.Runtime.InteropServices.Marshalling;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        double shipping;
        if(_customer.IsInUSA())
        {
            shipping = 5.0;
        }
        else
        {
            shipping = 35.0;
        }

        return total + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += $"- {p.GetName()} (ID: {p.GetId()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
