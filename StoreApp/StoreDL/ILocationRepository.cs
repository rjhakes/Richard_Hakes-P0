using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface ILocationRepository
    {
        List<Location> GetLocations();
        Location AddLocation(Location newLocation);
        Location GetLocationByName(string name);
        Location GetLocationById(int id);
        Location DeleteLocation(Location location2BDeleted);
        void UpdateLocation(Location location2BUpdated);
    }
}