using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public string Calories { get; set; }
        public string Instructions { get; set; }
        public string Category { get; set; }
        public string DishType { get; set; }
        public int UserId { get; set; }
    }
}
