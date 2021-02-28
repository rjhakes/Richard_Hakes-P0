using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class LocationRepoDB : ILocationRepository
    {
        private Entity.StoreDBContext _context;
        private ILocationMapper _mapper;
        public LocationRepoDB(Entity.StoreDBContext context, ILocationMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Location AddLocation(Model.Location newLocation)
        {
            _context.Locations.Add(_mapper.ParseLocation(newLocation));
            _context.SaveChanges();
            return newLocation;
        }

        public Location DeleteLocation(Location location2BDeleted)
        {
            _context.Locations.Remove(_mapper.ParseLocation(location2BDeleted));
            _context.SaveChanges();
            return location2BDeleted;
        }

        public Location GetLocationByName(string name)
        {
            return _context.Locations
            .AsNoTracking()
            .Select(x => _mapper.ParseLocation(x))
            .ToList()
            .FirstOrDefault(x => x.LocName == name);
        }

        public List<Model.Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public void UpdateLocation(Location location2BUpated)
        {
            Entity.Location oldLocation = _context.Locations.Find(location2BUpated.Id);
            _context.Entry(oldLocation).CurrentValues.SetValues(_mapper.ParseLocation(location2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}