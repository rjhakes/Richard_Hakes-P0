using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
using StoreDL;
//using Linq;
namespace StoreUI
{
    class CustomerLocationMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private ILocationBL _locationBL;
        private Location _location;
        private Customer _user;
        private CustomerCart _customerCart;
        private CustomerOrderLineItem _customerOrderLineItem;
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        private ICustomerCartBL _customerCartBL;
        private ICustomerOrderLineItemBL _customerOrderLineItemBL;
        private ICustomerOrderHistoryBL _customerOrderHistory;
        public override string MenuPrint {
            get { return _menu; }
        }
        public CustomerLocationMenu(Customer user, ICustomerBL customerBL, Location location, ILocationBL locationBL, 
                                    IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL, ICustomerCartBL customerCartBL, ICustomerOrderLineItemBL customerOrderLineItemBL, ICustomerOrderHistoryBL customerOrderHistory) 
        {
            _locationBL = locationBL;
            _location = location;
            _user = user;
            _customerBL = customerBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _customerCartBL = customerCartBL;
            _customerOrderLineItemBL = customerOrderLineItemBL;
            _customerOrderHistory = customerOrderHistory;
            GetCart();
            _menu = "\n" +
                    "\n[View] View Cart and finalize purchase" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }
        public void Start() {
            
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Shopping at {_location.LocName} Store");
                Console.WriteLine(_user);
                Console.WriteLine("-----------------------");
                GetInventory();
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter an item number to place item in cart: ");

                

                string userInput = Console.ReadLine();
                if (userInput != "View" && userInput != "Back" && userInput != "Exit") {
                    OrderItem(userInput);
                } else {
                    switch(userInput) {
                        case "View":
                            //TODO move to CustomerCartMenu
                            //ViewCart();
                            /*if (_user.CustCart.Count > 0) {
                                Console.WriteLine("Would you like to finalize your purchase? (y/n)"); 
                                if (Console.ReadLine().Equals("y")) {
                                    CompletePurchase();
                                    Console.WriteLine("\nPurchase Complete!\nPress Enter to return to menu");
                                    Console.ReadLine();
                                }
                            }*/
                            
                            break;
                        case "Back":
                            stay = false;
                            break;
                        case "Exit":
                            System.Environment.Exit(1);
                            break;
                        default:
                            
                            break;
                    }
                }
                
            } while (stay);
        }

        public void GetInventory() {
            int i = 0;
            Console.WriteLine("Product Details-----");
            foreach (var item in _inventoryLineItemsBL.GetInventoryLineItems())
            {
                if (item.InventoryId == _location.Id)
                {
                    Console.WriteLine($"[{item.ProductId}] {_productBL.GetProductById((int)item.ProductId)} {item.ToString()}");
                    i++;
                }
                
            }
        }

        public void OrderItem(string _item) {
            //move inventory quantity change to new method
            int i = int.Parse(_item);
            Product item = _productBL.GetProductById(i);

            
        }
        /*public void ViewCart() {
            /*foreach (var item in _user.CustCart) {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }*/

        /*public void CompletePurchase() {
            LineItems();
            Console.WriteLine(SumCharges());
            CreateOrder();
            EmptyCart();
        }*/
        public double SumCharges() {
            double TotalCharge = 0;
            /*foreach (var item in _user.CustCart) {
                TotalCharge += item.Product.ProductPrice * item.Quantity;
            }*/
            return TotalCharge;
        }

        public void LineItems() {
            int i = 0;
            /*foreach (var item in _user.CustCart)
            {
                Console.WriteLine($"[{i}] {item.ToString()}");
                i++;
            }*/
        }

        /*public void CreateOrder() {
            Order newOrder = new Order();
            newOrder.Customer = _user;
            newOrder.LocName = _location.LocName;
            newOrder.LocAddress = _location.Address;
            //newOrder.Cart = _user.CustCart;
            newOrder.Total = SumCharges();
            //_orderBL.AddOrder(newOrder);
        }*/

        public void EmptyCart() {
            //_user.CustCart = new List<Item>();
        }
        public void GetCart()
        {
            try
            {
                CustomerCart customerCart = _customerCartBL.GetCustomerCartByIds((int)_user.Id, (int)_location.Id);
                Console.WriteLine(customerCart.ToString());
                Console.ReadLine();
            }
            catch (Exception)
            {

                CreateCustomerOrderLineItem();
                CreateCustomerCart();

        }

    }        

        public void CreateCustomerOrderLineItem()
        {
            _customerOrderLineItemBL.AddCustomerOrderLineItem(GetCustomerOrderLineItemDetails());
            Console.WriteLine("new order line item added");
            Console.ReadLine();
            _customerOrderLineItem.Id = _customerOrderLineItemBL.Ident_Curr();
            Console.WriteLine($"local orderLineItem Id is {_customerOrderLineItem.Id}");
            Console.ReadLine();
        }
        /*public CustomerOrderLineItem GetCustomerOrderLineItemDetails(CustomerOrderLineItem newLineItem)
        {
            CustomOrderLineItem
        }*/

        public CustomerOrderLineItem GetCustomerOrderLineItemDetails()
        {
            CustomerOrderLineItem newLineItem = new CustomerOrderLineItem();
            //newLineItem.Id = _customerOrderLineItemBL.Ident_Curr() + 1;
            newLineItem.OrderId = _customerOrderLineItemBL.Ident_Curr() + 1; //newLineItem.Id;
            newLineItem.ProdId = null;
            newLineItem.Quantity = 0;
            newLineItem.ProdPrice = 0;
            _customerOrderLineItem = newLineItem;
            return newLineItem;
        }

        public void CreateCustomerCart()
        {
            _customerCartBL.AddCustomerCart(GetCustomerCartDetails());
        }

        public CustomerCart GetCustomerCartDetails()
        {
            
            CustomerCart newCart = new CustomerCart();
            newCart.CustId = (int)_user.Id;
            newCart.LocId = (int)_location.Id;
            newCart.CurrentItemsId = (int)_customerOrderLineItem.OrderId;
            _customerCart = newCart;
            return newCart;
        }

        
    }
}