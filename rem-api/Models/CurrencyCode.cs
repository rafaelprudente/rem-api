namespace rem_api.Models
{
    public class CurrencyCode
    {
        public long Id { get; set; }
        public string CharacterCode { get; set; }
        public int NumericCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string Name { get; set; }
    }
}
