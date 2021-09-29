using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<CurrencyCode> CurrencyCodes { get; set; }
    }
}
