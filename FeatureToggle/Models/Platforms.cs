using System.ComponentModel.DataAnnotations.Schema;

namespace FeatureToggle.Models
{
    [NotMapped]
    public class Platforms
    {

        public bool Android { get; set; }
        public bool Ios { get; set; }
        public bool Web { get; set; }

    }
}
