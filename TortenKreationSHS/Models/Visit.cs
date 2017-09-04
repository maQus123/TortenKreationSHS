namespace TortenKreationSHS.Models {

    using System;

    public class Visit {

        public Visit() {
            this.VisitedAt = new DateTimeOffset(DateTime.UtcNow);
        }

        public int Id { get; private set; }

        public DateTimeOffset VisitedAt { get; private set; }

        public string UserAgent { get; set; }

        public string Ip { get; set; }

        public string VisitedSite { get; set; }
        
    }

}