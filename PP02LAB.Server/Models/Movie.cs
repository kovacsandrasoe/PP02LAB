namespace PP02LAB.Server.Models
{
    public class Movie
    {
        public Movie(int id, string title, DateTime release, int rating)
        {
            Id = id;
            Title = title;
            Release = release;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Release { get; set; }
        public int Rating { get; set; }
    }
}
