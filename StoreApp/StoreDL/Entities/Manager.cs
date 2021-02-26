using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Manager
    {
        public Manager()
        {
            StoreOrderHistories = new HashSet<StoreOrderHistory>();
        }

        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerPasswordHash { get; set; }
        public string ManagerPhone { get; set; }
        public int? ManagerLocId { get; set; }

        public virtual Location ManagerLoc { get; set; }
        public virtual ManagersCart ManagersCart { get; set; }
        public virtual ICollection<StoreOrderHistory> StoreOrderHistories { get; set; }
    }
}
