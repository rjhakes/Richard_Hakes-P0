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
        public void DeleteLocation(Location location2BDeleted)
        {
            _repo.DeleteLocation(location2BDeleted);
        }
        public Location GetLocationByName(string name) {
            //todo validate
            return _repo.GetLocationByName(name);
        }
        public Location GetLocationById(int id) {
            //todo validate
            return _repo.GetLocationById(id);
        }
        public List<Location> GetLocations()
        {
            //TODO Add BL
            return _repo.GetLocations();
        }
        public void UpdateLocation(Location location2BUpdated, Location updatedDetails)
        {
            location2BUpdated.LocName = updatedDetails.LocName;
            location2BUpdated.LocPhone = updatedDetails.LocPhone;
            location2BUpdated.LocAddress = updatedDetails.LocAddress;

            _repo.UpdateLocation(location2BUpdated);
        }
    }
}