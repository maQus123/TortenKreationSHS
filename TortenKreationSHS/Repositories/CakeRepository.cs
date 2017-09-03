namespace TortenKreationSHS.Repositories {

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using TortenKreationSHS.Models;

    public class CakeRepository : ICakeRepository {

        private readonly DatabaseContext databaseContext;
        
        public CakeRepository(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        public List<Cake> GetAll() {
            var cakes = this.databaseContext
                .Cakes
                .OrderByDescending(c => c.CreationDate)
                .ToList();
            return cakes;
        }

        public Cake GetBySlug(string slug) {
            var cake = this.databaseContext
                .Cakes
                .Include(c => c.Images)
                .Single(c => c.GetSlug() == slug);
            return cake;
        }

    }

}