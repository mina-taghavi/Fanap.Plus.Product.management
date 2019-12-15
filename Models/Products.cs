using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fanap.Plus.Product_Management.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime CreationDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        public string Description { get; set; }

        //[Display(Name = "نام مدیر پروژه")] 
        public string ProductManagementName { get; set; }

        public string ProductOwnerName { get; set; }
        public ICollection<TeamAssignment> TeamAssignments { get; set; }
    }
}