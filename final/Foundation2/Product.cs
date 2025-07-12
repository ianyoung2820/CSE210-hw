namespace Foundation4Program2
{
    public class Product
    {
        private string name;
        private string productId;
        private decimal unitPrice;
        private int quantity;

        public Product(string name, string productId, decimal unitPrice, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return unitPrice * quantity;
        }

        public string GetPackingInfo()
        {
            return $"{name} (ID: {productId})";
        }
    }
}
