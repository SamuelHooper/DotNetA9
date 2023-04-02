namespace DotNetA6.Models
{
    public class Show : Media
    {
        public int Season { get; set; }
        public int Episode { get; set; }
        public string[] Writers { get; set; }

        public Show(int id, string title, int season, int episode, string[] writers)
        {
            Id = id;
            Title = title;
            Season = season;
            Episode = episode;
            Writers = writers;
        }

        public override string Display()
        {
            string writers = "";

            foreach (string writer in Writers)
            {
                writers += writer + ", ";
            }
            writers = writers.TrimEnd(' ').TrimEnd(',');

            return $"{Id}. {Title} | Season: {Season}, Episode: {Episode} | Writer(s): {writers}";
        }

        public override string ToString()
        {
            return "Show";
        }
    }
}
