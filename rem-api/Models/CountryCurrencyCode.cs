namespace rem_api.Models
{
    public class CountryCurrencyCode
    {
        public long CountryId { get; set; }
        public Country Country { get; set; }
        public long CurrencyCodeId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
    }
}
