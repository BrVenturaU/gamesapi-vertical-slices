namespace VerticalSliceArchitecture.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
