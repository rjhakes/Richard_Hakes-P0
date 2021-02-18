using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public class LocationRepoSC : ILocationRepository
    {
        public List<Location> GetLocations()
        {
            return Storage.AllLocations;
        }
        public Location AddLocation(Location newLocation)
        {
            Storage.AllLocations.Add(newLocation);
            return newLocation;
        }
    }
}