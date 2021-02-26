using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class ManagersCart
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int LocId { get; set; }
        public int? OrderId { get; set; }

        public virtual Location Loc { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
