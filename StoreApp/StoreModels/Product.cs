namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private string productName;
        private double productPrice;
        private Category categoryType;
        private string brandName;

        public string ProductName { 
            get {return productName;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                productName = value;
            }
        }
        public double ProductPrice { 
            get {return productPrice;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                productPrice = value;
            }
            }
        public Category CategoryType { 
            get {return categoryType;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                categoryType = value;
            }
        }
        public string BrandName { 
            get {return brandName;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                brandName = value;
            }
        }

        public override string ToString() => $"Product Details: \n\t Product Name: \t\t{this.ProductName} \n\t Price: \t\t{this.ProductPrice} \n\t Category: \t\t{this.CategoryType} \n\t Brand Name: \t\t{this.BrandName}";
        //todo: add more properties to define a product (maybe a category?)
    }
}