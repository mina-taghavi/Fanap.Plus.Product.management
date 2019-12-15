using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Fanap.Plus.Product_Management.Helpers;

namespace Fanap.Plus.Product_Management.Models
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string DeadlineDate { get; set; }

        public DateTime GregorianDeadlineDate => DateHelper.ConvertToGregorian(DeadlineDate).GetValueOrDefault();
        public string Description { get; set; }

        // [Display(Name = "نام مدیر پروژه")]
        public string ProductManagementName { get; set; }

        public string ProductOwnerName { get; set; }
        public ICollection<Teams> Teams { get; set; } = new List<Teams>();
        public int[] TeamIds { get; set; }
        public int[] MemberIds { get; set; } 
        public ICollection<Members> Members { get; set; } = new List<Members>();
    }
}
