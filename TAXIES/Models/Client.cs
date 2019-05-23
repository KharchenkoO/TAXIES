using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAXIES.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public int ClientTel { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string ClientName { get; set; }
        [Required]
        [Range(1900,2019)]
        [Display(Name = "Right year")]
        public int ClientBirth { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

}