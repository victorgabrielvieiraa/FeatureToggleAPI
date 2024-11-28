using FeatureToggle.Data;
using FeatureToggle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static FeatureToggle.Models.FeatureResponse;

namespace FeatureToggle.Services
{
    public class FeatureService
    {
        private readonly FeatureRepository _repository;

        public FeatureService(FeatureRepository repository)
        {
            _repository = repository;
        }

        public FeatureResponse GetFormattedFeatures()
        {
            var features = _repository.GetAllFeatures();

            var featureResponse = new FeatureResponse
            {
                Features = features.ToDictionary(
                    feature => feature.Name.ToLower(),
                    feature => new FeatureDetail
                    {
                        Description = feature.Description,
                        Enabled = feature.Enabled,
                        Platforms = feature.Platforms ?? new Platforms()
                        {
                            Android = feature.Platforms?.Android ?? false,
                            Ios = feature.Platforms?.Ios ?? false,
                            Web = feature.Platforms?.Web ?? false
                        }
                    })
            };

            return featureResponse;
        }

        public void AddFeature(Feature feature)
        {
            _repository.AddFeature(feature);
        }
       
        public void UpdateFeatureByName(string name, Feature updatedFeature)
        {
            var existingFeature = _repository.GetFeatureByName(name);
            if (existingFeature != null)
            {
               

                
                if (existingFeature.Platforms == null)
                {
                    existingFeature.Platforms = new Platforms(); 
                }

                existingFeature.Name = updatedFeature.Name;
                existingFeature.Description = updatedFeature.Description;
                existingFeature.Enabled = updatedFeature.Enabled;
                existingFeature.Platforms.Android = updatedFeature.Platforms?.Android ?? existingFeature.Platforms.Android;
                existingFeature.Platforms.Ios = updatedFeature.Platforms?.Ios ?? existingFeature.Platforms.Ios;
                existingFeature.Platforms.Web = updatedFeature.Platforms?.Web ?? existingFeature.Platforms.Web;

    
                _repository.UpdateFeature(existingFeature);
            }
            else
            {
                throw new Exception("Feature não encontrada");
            }
        }

      
        public void DeleteFeatureByName(string name)
        {
            var existingFeature = _repository.GetFeatureByName(name);
            if (existingFeature != null)
            {
                _repository.DeleteFeature(existingFeature.Id);
            }
            else
            {
                throw new Exception("Feature não encontrada");
            }
        }
    }
}