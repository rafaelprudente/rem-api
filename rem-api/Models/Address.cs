namespace rem_api.Models
{
    public class Address
    {
        public long Id { get; set; }

        public City City { get; set; }

        public string ZipCode { get; set; }
        public string Number { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
    }
}
