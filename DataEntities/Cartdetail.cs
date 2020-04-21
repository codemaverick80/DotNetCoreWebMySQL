using System;
using System.Collections.Generic;

namespace DotNetCoreWebMySQL.DataEntities
{
    public partial class Cartdetail
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public string InventoryId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
