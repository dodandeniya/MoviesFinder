namespace MF.Domain.Movie
{
    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }

        public virtual Movie Movie { get; set; }
    }
}