namespace rem_api.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public State State { get; set; }
    }
}
