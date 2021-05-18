using System;
using System.Collections.Generic;

namespace MillionAndUp.Models.Models.Entity
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Property> Propertys { get; set; }
    }
}
