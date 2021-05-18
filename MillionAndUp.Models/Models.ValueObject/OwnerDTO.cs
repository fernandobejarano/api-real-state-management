using System;

namespace MillionAndUp.Models.Models.ValueObject
{
    public class OwnerDetail
    {
        public int OwnerId { get; set; }
        public string  Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class OwnerReq
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }

}
