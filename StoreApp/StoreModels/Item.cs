namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public override string ToString() => $"\tItem: {this.Product.ProductName} \tPrice: {this.Product.Price} \t Quantity: {this.Quantity}";
    }
}