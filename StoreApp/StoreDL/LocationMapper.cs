using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
using System;
namespace StoreDL
{
    public class LocationMapper : ILocationMapper
    {
        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                LocName = location.LocName,
                LocPhone = location.LocPhone,
                LocAddress = location.LocAddress,
                //Inventory = ParseInventory(location.Inventory),
                Id = location.Id
            };
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            if (location.Id == null)
            {
                return new Entity.Location
                {
                    LocName = location.LocName,
                    LocPhone = location.LocPhone,
                    LocAddress = location.LocAddress,
                    //Inventory = ParseInventory(location.Inventory)
                };
            }

            return new Entity.Location
            {
                LocName = location.LocName,
                LocPhone = location.LocPhone,
                LocAddress = location.LocAddress,
                //Inventory = ParseInventory(location.Inventory),
                Id = (int)location.Id
            };
        }

        public Model.Inventory ParseInventory(Entity.Inventory inventory)
        {
            return new Model.Inventory
            {
                LocId = inventory.LocId,
                Id = inventory.Id
            };
        }

        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            if (inventory.Id == null)
            {
                return new Entity.Inventory
                {
                    LocId = inventory.LocId
                };
            }
            //For updating the superpower, you need the id to find it
            return new Entity.Inventory
            {
                LocId = inventory.LocId,
                Id = (int)inventory.Id
            };
        }
    }
}