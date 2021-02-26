using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            CustomerCarts = new HashSet<CustomerCart>();
            CustomerOrderHistories = new HashSet<CustomerOrderHistory>();
            Managers = new HashSet<Manager>();
            StoreOrderHistories = new HashSet<StoreOrderHistory>();
        }

        public int Id { get; set; }
        public string LocName { get; set; }
        public string LocPhone { get; set; }
        public string LocAddress { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ManagersCart ManagersCart { get; set; }
        public virtual ICollection<CustomerCart> CustomerCarts { get; set; }
        public virtual ICollection<CustomerOrderHistory> CustomerOrderHistories { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<StoreOrderHistory> StoreOrderHistories { get; set; }
    }
}
