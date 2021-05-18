﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models.Models.Entity
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
        public ICollection<PropertyImage> PropertyImages { get; set; }
        public ICollection<PropertyTrace> PropertyTraces { get; set; }
    }
}
