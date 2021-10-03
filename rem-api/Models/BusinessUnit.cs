namespace rem_api.Models
{
    public class BusinessUnit
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
