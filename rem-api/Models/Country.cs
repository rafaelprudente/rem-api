using System.Collections.Generic;

namespace rem_api.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double NetToGrossRatio { get; set; }

        public WorldRegion WorldRegion { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<CurrencyCode> CurrencyCodes { get; set; }
    }
}
