using FeatureToggle.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureToggle.Data
{
    public class FeatureRepository
    {
        private readonly FeatureDbContext _context;

        public FeatureRepository(FeatureDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feature> GetAllFeatures()
        {
            return _context.Features.ToList();
        }


        public Feature GetFeatureByName(string name)
        {
            return _context.Features.FirstOrDefault(f => f.Name.ToLower() == name.ToLower());
        }

        public void AddFeature(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
        }

        public void UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
        }

        public void DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                _context.SaveChanges();
            }
        }

        
       
    }
}