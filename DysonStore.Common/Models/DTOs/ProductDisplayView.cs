﻿namespace DysonStore.Common.Models.DTOs
{
    public class ProductDisplayView
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CategoryId { get; set; } = 0;
    }
}
