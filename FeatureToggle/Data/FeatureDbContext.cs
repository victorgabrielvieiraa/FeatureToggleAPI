using FeatureToggle.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FeatureToggle.Data
{
    public class FeatureDbContext : DbContext
    {

        public FeatureDbContext(DbContextOptions<FeatureDbContext> options) : base(options) { }

        public DbSet<Feature> Features { get; set; }
    }
}
