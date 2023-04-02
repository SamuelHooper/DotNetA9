namespace DotNetA6.Models
{
    public class Movie : Media
    {
        public string[] Genres { get; set; }

        public Movie(int id, string title, string[] genres)
        {
            Id = id;
            Title = title;
            Genres = genres;
        }

        public override string Display()
        {
            string genres = "";

            foreach (string genre in Genres)
            {
                genres += genre + ", ";
            }
            genres = genres.TrimEnd(' ').TrimEnd(',');

            return $"{Id}. {Title} | Genre(s): {genres}";
        }

        public override string ToString()
        {
            return "Movie";
        }
    }
}
