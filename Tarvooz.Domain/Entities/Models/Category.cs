﻿namespace Tarvooz.Domain.Entities.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SearchCount {  get; set; }
    }
}
