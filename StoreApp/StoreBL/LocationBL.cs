using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationRepository _repo;

        public LocationBL(ILocationRepository repo) {
            _repo = repo;
        }

        public void AddLocation(Location newLocation)
        {
            //TODO: Add BL
            _repo.AddLocation(newLocation);
        }
        public List<Location> GetLocations()
        {
            //TODO Add BL
            return _repo.GetLocations();
        }
    }
}