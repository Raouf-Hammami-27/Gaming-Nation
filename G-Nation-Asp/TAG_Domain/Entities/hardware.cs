using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class hardware
    {
        public int id_hardware { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string type { get; set; }
        public string admin_idUser { get; set; }
        public virtual User user { get; set; }
    }
}
