namespace DotNetA6.Models
{
    public class Video : Media
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public Video(int id, string title, string format, int length, int[] regions)
        {
            Id = id;
            Title = title;
            Format = format;
            Length = length;
            Regions = regions;
        }

        public override string Display()
        {
            string regions = "";

            foreach (int region in Regions)
            {
                regions += region + ", ";
            }
            regions = regions.TrimEnd(' ').TrimEnd(',');

            return $"{Id}. {Title} | Format: {Format} | Length: {Length} minutes | Regions(s): {regions}";
        }

        public override string ToString()
        {
            return "Video";
        }
    }
}
