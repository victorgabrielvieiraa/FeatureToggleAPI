using System.ComponentModel.DataAnnotations;

namespace FeatureToggle.Models
{
    public class Feature
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public bool Android { get; set; }
        public bool Ios { get; set; }
        public bool Web { get; set; }

    }
}
