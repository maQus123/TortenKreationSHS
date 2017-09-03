namespace TortenKreationSHS.Models {

    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Cake {

        public Cake() {
            this.Images = new List<Image>();
        }

        public int Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string TopImageUrl { get; set; }

        public List<Image> Images { get; set; }

        public DateTime CreationDate { get; set; }

        public string GetSlug() {
            string slug = this.Title.ToLower();
            slug = Regex.Replace(slug, "ö", "oe");
            slug = Regex.Replace(slug, "ä", "ae");
            slug = Regex.Replace(slug, "ü", "ue");
            slug = Regex.Replace(slug, "ß", "ss");
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = slug.Substring(0, slug.Length <= 45 ? slug.Length : 45).Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            return slug;
        }

        public string GetPrettyDate() {
            var timeSpan = DateTime.Now.Subtract(this.CreationDate);
            int dayDiff = (int)timeSpan.TotalDays;
            var prettyDate = string.Empty;
            if (dayDiff == 0) {
                prettyDate = "Heute";
            } else {
                if (dayDiff == 1) {
                    prettyDate = "Gestern";
                } else {
                    if (dayDiff == 2) {
                        prettyDate = "Vorgestern";
                    } else {
                        if (dayDiff < 7) {
                            prettyDate = string.Format("Vor {0} Tagen", dayDiff);
                        } else {
                            if (dayDiff < 31) {
                                var weeks = Math.Ceiling((double)dayDiff / 7);
                                prettyDate = string.Format("Vor {0} Wochen", weeks);
                                if (weeks == 1) {
                                    prettyDate.Remove(prettyDate.Length - 2, 1);
                                }
                            } else {
                                if (dayDiff < 365) {
                                    var months = Math.Ceiling((double)dayDiff / 31);
                                    prettyDate = string.Format("Vor {0} Monaten", months);
                                    if (months == 1) {
                                        prettyDate.Remove(prettyDate.Length - 2, 1);
                                    }
                                } else {
                                    if (dayDiff < 3650) {
                                        var years = Math.Ceiling((double)dayDiff / 365);
                                        years = years - 1;
                                        prettyDate = string.Format("Vor {0} Jahren", years);
                                        if (years == 1) {
                                            prettyDate = prettyDate.Remove(prettyDate.Length - 2, 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return prettyDate;
        }

    }

}