using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management
{
    public class Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Purpose { get; set; }
        public string Shelf { get; set; }
        public Entity(string name,decimal price,string purpose,string shelf)
        {
            Name = name;
            Price = price;
            Purpose = purpose;
            Shelf = shelf;
        }
        public override string ToString() 
        {
            return $"Name: {Name},Price:{Price}, Purpose:{Purpose}, Shelf{Shelf}";


        }
    }
}
