using System;
using backend.Models.Category;

namespace backend.Models.Phone
{
    public class PhoneDto
    {
        public int PhoneId { get; set; }
        public string PhoneName { get; set; }
        public string PhoneDescription { get; set; }
        public double PhonePrice { get; set; }
        public string PhoneImage { get; set; }
        public int PhoneQuantity { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreateDate { get; set; }
    }
}