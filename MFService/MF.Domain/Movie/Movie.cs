using System.Collections.Generic;

namespace MF.Domain.Movie
{
    public class Movie
    {
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
