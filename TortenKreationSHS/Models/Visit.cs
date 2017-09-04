namespace TortenKreationSHS.Models {

    using System;

    public class Visit {

        public Visit() {
            this.VisitedAt = new DateTimeOffset(DateTime.UtcNow);
        }

        public int Id { get; set; }

        public DateTimeOffset VisitedAt { get; private set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Browser { get; set; }

        public string OS { get; set; }

    }

}