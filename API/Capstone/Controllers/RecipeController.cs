using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeDao recipeDao;

        public RecipeController(IRecipeDao _recipeDao)
        {
            recipeDao = _recipeDao;
        }

        [HttpGet("all")]
        public IActionResult GetAllRecipes()
        {
            List<Recipe> allRecipes = recipeDao.GetAllRecipes();
            if(allRecipes!=null)
            {
                return Ok(allRecipes);
            }
            return StatusCode(503);
        }
        [HttpGet("/{recipeId}")]
        public IActionResult GetRecipe(int recipeId)
        {
            MealRecipe mealRecipe = recipeDao.GetRecipe(recipeId);
            if(mealRecipe != null)
            {
                return Ok(mealRecipe);
            }
            return StatusCode(404);
        }
    }
}
