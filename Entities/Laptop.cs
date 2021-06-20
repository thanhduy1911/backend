using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }
        public string LaptopName { get; set; }
        public string LaptopDescription { get; set; }
        public double LaptopPrice { get; set; }
        public string LaptopImage { get; set; }
        public int LaptopQuantity { get; set; }
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreateDate { get; set; }
    }
}