using System;

namespace backend.Models.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}