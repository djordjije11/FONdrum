namespace FONdrum.Domain.Models
{
    public class GrapeVariety
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public GrapeVariety() { }

        public GrapeVariety(string name)
        {
            Name = name;
        }
    }
}
