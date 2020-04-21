using System;
using System.Collections.Generic;

namespace DotNetCoreWebMySQL.DataEntities
{
    public partial class Cart
    {
        public Cart()
        {
            Cartdetail = new HashSet<Cartdetail>();
        }

        public string Id { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Cartdetail> Cartdetail { get; set; }
    }
}
