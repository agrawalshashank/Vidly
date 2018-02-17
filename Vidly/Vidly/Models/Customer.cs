using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.CustomValidation;


namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
      
        [Display(Name="Date of Birth")]
        [Agelessthan18ForSpecificMembershipType]
        public DateTime? DateOfBirth { get; set; }

        public bool IsNewsLetterSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership type")]
        public int MembershipTypeId { get; set; }

        public static readonly int MemberIdNull =0;
        public static readonly int MemberTypePayAsUGo = 1;
        
    }
}