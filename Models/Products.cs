using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fanap.Plus.Product_Management.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)] public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "نام مدیر پروژه")] public string ProjectManagementName { get; set; }

        public string ProductOwnerName { get; set; }
        public ICollection<TeamAssignment> TeamAssignments { get; set; } 



        //[NotMapped] public IEnumerable<Teams> Teams { get; set; }

        //[Display(Name = "SelectedTeam")] public string Team { get; set; }

        //// public string[] DevelopmentTeam { get; set; }
        ////public string[] OtherMembers { get; set; }
    }
}