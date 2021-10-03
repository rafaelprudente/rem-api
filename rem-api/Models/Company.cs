using System.Collections.Generic;

namespace rem_api.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<BusinessUnit> BusinessUnits { get; set; }
    }
}
