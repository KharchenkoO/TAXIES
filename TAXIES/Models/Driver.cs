using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAXIES.Models
{
    public class Driver
    {
        public int DriverID { get; set; }
        public int DriverPassport { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string DriverName { get; set; }
        [Required]
        [Range(1900, 2019)]
        [Display(Name = "Right year")]
        public int DriverBirth { get; set; }
        public int DriverTel { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}