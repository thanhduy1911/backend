using System;

namespace backend.Models.Phone
{
    public class PhoneFormDto
    {
        public string PhoneName { get; set; }
        public string PhoneImage { get; set; }
        public double PhonePrice { get; set; }
        public string PhoneDescription { get; set; }
        public string ShortDescription { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}