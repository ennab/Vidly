﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        //Customer
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }//Navigation Property - to load related objects from database
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }// this as a forign-key

        [Min18IfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }
    }
}