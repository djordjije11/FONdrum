namespace FONdrum.Domain.Models
{
    public class GrapeVariety
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private GrapeVariety() { }

        public GrapeVariety(string name)
        {
            Name = name;
        }
    }
}
