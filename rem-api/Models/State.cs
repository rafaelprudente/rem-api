﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rem_api.Models
{
    public class State
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
