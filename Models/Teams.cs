using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fanap.Plus.Product_Management.Models
{
    public class Teams

    {

        public int Id { get; set; }
        public string Name { set; get; }
        public ICollection<TeamAssignment> TeamAssignments { get; set; }
       
        public enum TeamMember
        {

        }
    }



}
