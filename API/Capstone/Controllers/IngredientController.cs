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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientDao IngredientDao;

        public IngredientController(IIngredientDao _ingredientDao)
        {
            IngredientDao = _ingredientDao;
        }

        [HttpGet("/recipe/{recipeId}")]
        public IActionResult GetIngredientsByRecipe(int recipeId)
        {
            List<Ingredient> recipeIngredients = IngredientDao.GetIngredientsByRecipe(recipeId);
            if(recipeIngredients!=null)
            {
                return Ok(recipeIngredients);
            }
            return StatusCode(404);
        }
    }
}
