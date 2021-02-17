namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private string productName;
        private double price;
        private Category categoryType;
        private string brandName;

        public string ProductName { get; set; }
        public double Price { get; set; }
        public Category CategoryType { get; set; }
        public string BrandName { get; set; }

        //todo: add more properties to define a product (maybe a category?)
    }
}