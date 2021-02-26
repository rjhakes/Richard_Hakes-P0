using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCarts = new HashSet<CustomerCart>();
            CustomerOrderHistories = new HashSet<CustomerOrderHistory>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPasswordHash { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }

        public virtual ICollection<CustomerCart> CustomerCarts { get; set; }
        public virtual ICollection<CustomerOrderHistory> CustomerOrderHistories { get; set; }
    }
}
