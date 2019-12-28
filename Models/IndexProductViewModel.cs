using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fanap.Plus.Product_Management.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fanap.Plus.Product_Management.Models
{
    public class IndexProductViewModel
    {
        public List<Products> Products { get; set; }
        public SelectList Teams { get; set; }
        public string ProductTeam { get; set; }
        public string SearchString { get; set; }
    }
}
