namespace VerticalSliceArchitecture.Domain
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
