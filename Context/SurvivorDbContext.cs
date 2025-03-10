using Microsoft.EntityFrameworkCore;
using Pratik__Survivor.Entities;

namespace Pratik__Survivor.Context
{
    public class SurvivorDbContext:DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        
        public DbSet<CompetitorEntity> Competitors => Set<CompetitorEntity>();
    }
}
