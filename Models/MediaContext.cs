namespace DotNetA6.Models
{
    public class MediaContext
    {
        private static string _movoiesFile = $@"{Environment.CurrentDirectory}\Data\movies.csv";
        private static string _showsFile = $@"{Environment.CurrentDirectory}\Data\shows.csv";
        private static string _videosFile = $@"{Environment.CurrentDirectory}\Data\videos.csv";

        public List<Media> Movies { get; set; }
        public List<Media> Shows { get; set; }
        public List<Media> Videos { get; set; }

        public MediaContext()
        {
            // Read movies from file
            Movies = new List<Media>();
            StreamReader sr = new(_movoiesFile);
            try
            {
                sr.ReadLine(); // Skips header line
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string[] genres = line[2].Split('|');
                    Movies.Add(new Movie(Int32.Parse(line[0]), line[1], genres));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read movies.csv.");
            }
            finally
            {
                sr.Close();
            }

            // Read shows from file
            Shows = new List<Media>();
            sr = new(_showsFile);
            try
            {
                sr.ReadLine(); // Skips header line
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string[] writers = line[4].Split('|');
                    Shows.Add(new Show(Int32.Parse(line[0]), line[1], Int32.Parse(line[2]), Int32.Parse(line[3]), writers));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read shows.csv.");
            }
            finally
            {
                sr.Close();
            }

            // Read videos from file
            Videos = new List<Media>();
            sr = new(_videosFile);
            try
            {
                sr.ReadLine(); // Skips header line
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string format = line[2].Replace("|", ", ");
                    int[] regions = Array.ConvertAll(line[4].Split('|'), s => int.Parse(s));
                    Videos.Add(new Video(Int32.Parse(line[0]), line[1], format, Int32.Parse(line[3]), regions));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read videos.csv.");
            }
            finally
            {
                sr.Close();
            }
        }

        public string SearchAllMedia(string searchString)
        {
            string output = SearchMedia(Movies, searchString);
            output += SearchMedia(Shows, searchString);
            output += SearchMedia(Videos, searchString);

            if (!output.Any())
            {
                return $"\nNo results found for \"{searchString}\"";
            }
            return output;
        }

        private static string SearchMedia(List<Media> mediaList, string searchString)
        {
            string output = "";
            var result = mediaList.Where(m => m.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            if (result.Any())
            {
                output = $"\n{mediaList[0]}s:";
                foreach (var media in result)
                {
                    output += $"\n\t{media.Title}";
                }
            }
            return output;
        }
    }
}
