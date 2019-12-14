using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fanap.Plus.Product_Management.Helpers;

namespace Fanap.Plus.Product_Management.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CreationDate { get; set; }

        [DataType(DataType.Date)] public DateTime GregorianCreationDate => DateHelper.ConvertToGregorian(CreationDate);

        public string Description { get; set; }

        // [Display(Name = "نام مدیر پروژه")]
        public string ProjectManagementName { get; set; }

        public string ProductOwnerName { get; set; }
        public ICollection<Teams> Teams { get; set; } = new List<Teams>();
        public int[] TeamIds { get; set; }
        public int[] MemberIds { get; set; } = {1};
        public ICollection<Members> Members { get; set; } = new List<Members>();
    }
}