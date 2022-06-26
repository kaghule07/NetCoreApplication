using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreApplication.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public double Price { get; set; }   
    }
}
