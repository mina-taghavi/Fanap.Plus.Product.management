using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanap.Plus.Product_Management.Models
{
    public class TeamAssignment
    {
        public int TeamId { get; set; }
        public int ProductId { get; set; }
        public Teams Team { get; set; }
        public Products Product { get; set; }
    }
}
