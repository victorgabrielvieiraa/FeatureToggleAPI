using System.ComponentModel.DataAnnotations;

namespace FeatureToggle.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public Platforms Platforms { get; set; }

    }
}
