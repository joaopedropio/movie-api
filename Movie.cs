namespace Movie
{
    public class Movie
    {
        // if you change here, you have to change 
        // the sql create statement on MovieRepository class too
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
