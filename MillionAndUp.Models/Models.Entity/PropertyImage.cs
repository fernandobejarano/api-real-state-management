using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models.Models.Entity
{
    public class PropertyImage
    {
        public int PropertyImageId { get; set; }
        public int IdProperty { get; set; }
        public string File { get; set; }
        public bool Enable { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
