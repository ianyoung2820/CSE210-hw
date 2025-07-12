using System.Collections.Generic;

namespace Foundation4Program2
{
    public class Order
    {
        private List<Product> products = new List<Product>();
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public string GetPackingLabel()
        {
            var lines = new List<string>();
            foreach (var prod in products)
            {
                lines.Add(prod.GetPackingInfo());
            }
            return "Packing Label:\n" + string.Join("\n", lines);
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var prod in products)
            {
                total += prod.GetTotalCost();
            }
            decimal shippingFee = customer.IsDomestic() ? 5m : 35m;
            return total + shippingFee;
        }
    }
}
