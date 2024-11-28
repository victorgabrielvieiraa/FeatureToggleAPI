using System.ComponentModel.DataAnnotations.Schema;

namespace FeatureToggle.Models
{
    [NotMapped]
    public class FeatureResponse
    {
        public Dictionary<string, FeatureDetail> Features { get; set; } = new Dictionary<string, FeatureDetail>();

        public class FeatureDetail
        {
          
            public string Description { get; set; }
            public bool Enabled { get; set; }
            public Platforms Platforms { get; set; }
        }

    }
}
