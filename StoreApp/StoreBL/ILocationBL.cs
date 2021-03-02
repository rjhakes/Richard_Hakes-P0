using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ILocationBL
    {
        List<Location> GetLocations();
        void AddLocation(Location newLocation);
        Location GetLocationByName(string name);
        Location GetLocationById(int id);
        void DeleteLocation(Location location2BDeleted);
        void UpdateLocation(Location location2BUpdated, Location updatedDetails);
    }
}