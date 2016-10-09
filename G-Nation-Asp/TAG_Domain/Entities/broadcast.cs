using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class broadcast
    {
        public int id { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string title { get; set; }
    }
}
