using System.Collections.Generic;

namespace rem_api.Models
{
    public class State
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
