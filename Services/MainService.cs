using DotNetA6.Models;

namespace ApplicationTemplate.Services
{
    public class MainService : IMainService
    {

        private static MediaContext _mediaContext = new();

        // Main Program code goes here
        public void Invoke()
        {
            string menuOption;

            do
            {
                Console.WriteLine("\n1) List media.");
                Console.WriteLine("2) Search for media by title.");
                Console.WriteLine("Enter any other key to exit.\n");
                menuOption = Console.ReadLine();
                if (menuOption == "1")
                {
                    DisplayMedia();
                }
                else if (menuOption == "2")
                {
                    Console.WriteLine("\nWhat media are you looking for?");
                    Console.WriteLine(_mediaContext.SearchAllMedia(Console.ReadLine()));
                }
            } while (menuOption == "1" || menuOption == "2");
        }

        public static void DisplayMedia()
        {
            List<Media> mediaList = new();
            string displayOutput = "";
            string menuOption;
            
            Console.WriteLine("\nSelect a media type to display:");
            Console.WriteLine("1. Movies");
            Console.WriteLine("2. Shows");
            Console.WriteLine("3. Videos");
            Console.WriteLine("4. All");
            Console.WriteLine("Enter any other key to return to menu.\n");
            menuOption = Console.ReadLine();

            if (menuOption == "1")
            {
                _mediaContext.Movies.ForEach(m => displayOutput += $"\n{m.Display()}");
            }
            else if (menuOption == "2")
            {
                _mediaContext.Shows.ForEach(s => displayOutput += $"\n{s.Display()}");
            }
            else if (menuOption == "3")
            {
                _mediaContext.Videos.ForEach(v => displayOutput += $"\n{v.Display()}");
            }
            else if (menuOption == "4")
            {
                displayOutput += "Movies:";
                _mediaContext.Movies.ForEach(m => displayOutput += $"\n\t{m.Display()}");

                displayOutput += "\nShows:";
                _mediaContext.Shows.ForEach(s => displayOutput += $"\n\t{s.Display()}");

                displayOutput += "\nVideos:";
                _mediaContext.Videos.ForEach(v => displayOutput += $"\n\t{v.Display()}");
            }

            Console.WriteLine(displayOutput);
        }
    }
}