using Microsoft.EntityFrameworkCore;

namespace CSharpTourOfHeroes.Models
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }

        public DbSet<Hero> Hero { get; set; }

		// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		// 	optionsBuilder.UseMySQL("connectionString");
		// }
    }
}