using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IRecipeDao
    {
        public List<Recipe> GetAllRecipes();

        public MealRecipe GetRecipe(int id);
    }
}
