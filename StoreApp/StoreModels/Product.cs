namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private string productName;
        private double productPrice;
        private Category categoryType;
        private string brandName;

        public string ProdName { 
            get {return productName;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                productName = value;
            }
        }
        public double ProdPrice { 
            get {return productPrice;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                productPrice = value;
            }
            }
        public Category ProdCategory { 
            get {return categoryType;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                categoryType = value;
            }
        }
        public string ProdBrandName { 
            get {return brandName;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                brandName = value;
            }
        }

        public int? Id { get; set; }

        public override string ToString() => $"\n\tProduct Name:\t\t{this.ProdName}\n\tPrice:\t\t\t{this.ProdPrice}\n\tCategory:\t\t{this.ProdCategory}\n\tBrand Name:\t\t{this.ProdBrandName}\n";
        //todo: add more properties to define a product (maybe a category?)
    }
}