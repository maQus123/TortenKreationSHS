namespace TortenKreationSHS.Repositories {

    using Microsoft.AspNetCore.Mvc;
    using TortenKreationSHS.Models;

    public class VisitRepository : IVisitRepository {

        private readonly DatabaseContext databaseContext;

        public VisitRepository(DatabaseContext databaseContext) {
            this.databaseContext = databaseContext;
        }

        [HttpPost]
        public void AddVisit(Visit visit) {
            databaseContext.Visits.Add(visit);
            databaseContext.SaveChangesAsync();
        }

    }

}