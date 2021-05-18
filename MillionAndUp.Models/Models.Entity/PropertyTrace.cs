using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models.Models.Entity
{
    public class PropertyTrace
    {
        public int PropertyTraceId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
