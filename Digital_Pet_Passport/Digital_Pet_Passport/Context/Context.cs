using Microsoft.EntityFrameworkCore;
using Digital_Pet_Passport.Model;
using System.IO;
using Xamarin.Essentials;
using System.Linq;

namespace Digital_Pet_Passport.Context
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BirthDay> Birthdays { get; set; }
        public DbSet<Weight> Weights { get; set; }
        public DbSet<Image> Images { get; set; }

        public bool ResetDb { get; set; }   

        public Context()
        {
            SQLitePCL.Batteries_V2.Init();

            if (ResetDb)
            {
                Database.EnsureDeleted();
            }

            this.Database.EnsureCreated();
        }

        public Context(bool reset)
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureDeleted();
            
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "PetsDb2.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }

        /// <summary>
        /// Сброс отслеживания всех элементов бд
        /// </summary>
        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted ||
                            e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
