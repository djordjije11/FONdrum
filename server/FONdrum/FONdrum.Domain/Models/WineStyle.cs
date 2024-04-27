namespace FONdrum.Domain.Models
{
    public class WineStyle
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private WineStyle() { }

        public WineStyle(string name)
        {
            Name = name;
        }
    }
}
