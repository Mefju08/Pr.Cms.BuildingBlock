using App.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Api.DAL
{
    public class Db : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja value converter dla CarId
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .HasConversion(
                        carId => carId.Value,
                        value => new CarId(value)
                    );
            });
        }
    }
}
