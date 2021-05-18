using System;

namespace MillionAndUp.Models.Models.ValueObject
{
    public class PropertyDetail
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
    }

    public class PropertyImageDetail
    {
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enable { get; set; }
    }

    public class PropertyTraceDetail
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int PropertyId { get; set; }
    }
}
