using Microsoft.AspNetCore.Mvc;
using FeatureToggle.Models;
using FeatureToggle.Services;

namespace FeatureToggleApp.Controllers
{
    [ApiController]
    [Route("api/features")]
    public class FeatureController : ControllerBase
    {
        private readonly FeatureService _service;

        public FeatureController(FeatureService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllFeatures()
        {
            var featuresResponse = _service.GetFormattedFeatures();
            return Ok(featuresResponse);
        }

        [HttpPost]
        public IActionResult AddFeature( Feature feature)
        {
            _service.AddFeature(feature);
            return CreatedAtAction(nameof(GetAllFeatures), new { id = feature.Id }, feature);
        }

        [HttpPut("{name}")]
        public IActionResult UpdateFeatureByName(string name, Feature updatedFeature)
        {
                _service.UpdateFeatureByName(name, updatedFeature);
                return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteFeatureByName(string name)
        {
                _service.DeleteFeatureByName(name);
                return NoContent();
           
        }
    }
}