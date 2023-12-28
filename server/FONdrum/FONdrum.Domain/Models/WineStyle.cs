namespace FONdrum.Domain.Models
{
    public class WineStyle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public WineStyle() { }

        public WineStyle(string name)
        {
            Name = name;
        }
    }
}
