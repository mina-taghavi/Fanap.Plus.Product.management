using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fanap.Plus.Product_Management.Models
{
    public class Teams

    {

        public int Id { get; set; }
        public string Name { set; get; }
        public ICollection<TeamAssignment> TeamAssignments { get; set; }



    }



}
