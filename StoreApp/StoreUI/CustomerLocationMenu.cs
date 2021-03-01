using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerLocationMenu : AMenu, IMenu
    {
        private readonly string _menu;
        //private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        //private ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
        //private IOrderBL _orderBL = new OrderBL(new OrderRepoFile());
        private ILocationBL _locationBL;
        private Location _location;
        private Customer _user;
        private ICustomerBL _customerBL;
        
        public override string MenuPrint {
            get { return _menu; }
        }
        public CustomerLocationMenu(Customer user, ICustomerBL customerBL, Location location, ILocationBL locationBL) 
        {
            _locationBL = locationBL;
            _location = location;
            _user = user;
            _customerBL = customerBL;
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
                //GetInventory();
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter an item number to place item in cart: ");
                string userInput = Console.ReadLine();
                if (userInput != "View" && userInput != "Back" && userInput != "Exit") {
                    //OrderItem(userInput);
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

        /*public void GetInventory() {
            int i = 0;
            foreach (var item in _location.Inventory)
            {
                Console.WriteLine($"[{i}] {item.ToString()}");
                i++;
            }
        }*/

        /*public void OrderItem(string _item) {
            //move inventory quantity change to new method
            int i = int.Parse(_item);
            Item ChooseItem = new Item();
            ChooseItem.Product = _location.Inventory[i].Product;
            Console.Write($"Enter Quantity limited to {_location.Inventory[i].Quantity}: ");
            ChooseItem.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine(ChooseItem.Quantity);
            /*_location.Inventory[i].Quantity -= ChooseItem.Quantity;
            _user.CustCart.Add(ChooseItem);
        }*/
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
    }
}