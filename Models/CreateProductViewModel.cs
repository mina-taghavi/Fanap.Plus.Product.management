using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fanap.Plus.Product_Management.Models
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)] public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "نام مدیر پروژه")] public string ProjectManagementName { get; set; }

        public string ProductOwnerName { get; set; }
        public ICollection<Teams> Teams { get; set; } = new List<Teams>();
        public int[] TeamIds { get; set; }
    }
}