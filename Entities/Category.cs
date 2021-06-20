using System;

namespace backend.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}