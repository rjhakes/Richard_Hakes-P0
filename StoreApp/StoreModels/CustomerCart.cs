using System;
using System.Collections.Generic;
namespace StoreModels
{
    public class CustomerCart
    {
        public int CustId { get; set; }
        public int LocId { get; set; }
        public int CurrentItemsId { get; set; }
        public int? Id { get; set; }

        public override string ToString() => $"CustId: {this.CustId}       LocId: {this.LocId}         CurrentItemsId: {this.CurrentItemsId}";
    }
}