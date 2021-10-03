﻿using System.Collections.Generic;

namespace rem_api.Models
{
    public class WorldRegion
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
