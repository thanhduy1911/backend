using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public string PhoneName { get; set; }
        public string PhoneDescription { get; set; }
        public double PhonePrice { get; set; }
        public string PhoneImage { get; set; }
        public int PhoneQuantity { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreateDate { get; set; }
    }
}