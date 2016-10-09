using System;
using System.Collections.Generic;

namespace TAG_Domain.Entities
{
    public partial class team
    {
        public team()
        {
            this.members = new List<member>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<member> members { get; set; }
    }
}
