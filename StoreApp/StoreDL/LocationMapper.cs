using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
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
                };
            }

            return new Entity.Location
            {
                LocName = location.LocName,
                LocPhone = location.LocPhone,
                LocAddress = location.LocAddress,
                Id = (int)location.Id
            };
        }
    }
}