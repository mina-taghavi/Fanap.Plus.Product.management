using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fanap.Plus.Product_Management.Models
{
    public class Members
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Role { set; get; }
        public Products Product { get; set; }
        public int? ProductId { get; set; }
    }
}