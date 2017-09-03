namespace TortenKreationSHS {

    using Microsoft.EntityFrameworkCore;
    using TortenKreationSHS.Models;

    public class DatabaseContext : DbContext {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Cake> Cakes { get; set; }

        public DbSet<Image> Images { get; set; }

    }

}