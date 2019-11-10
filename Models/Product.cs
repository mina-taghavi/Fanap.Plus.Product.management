using System;
using System.ComponentModel.DataAnnotations;

namespace Fanap.Plus.Product_Management.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "نام مدیر پروژه")]
        public string ProjectManagementName { get; set; }
        public string ProductOwnerName { get; set; }

       // public string[] DevelopmentTeam { get; set; }
        //public string[] OtherMembers { get; set; }
    }
}
