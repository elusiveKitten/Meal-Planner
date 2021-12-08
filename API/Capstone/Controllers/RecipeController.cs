﻿using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("recipe/")]
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
            List<MealRecipe> allRecipes = recipeDao.GetAllRecipes();
            if(allRecipes!=null)
            {
                return Ok(allRecipes);
            }
            return StatusCode(503);
        }
        [HttpGet("{recipeId}")]
        public IActionResult GetRecipe(int recipeId)
        {
            MealRecipe mealRecipe = recipeDao.GetRecipe(recipeId);
            if(mealRecipe != null)
            {
                return Ok(mealRecipe);
            }
            return StatusCode(404);
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetRecipesByUser(int userId)
        {
            List<MealRecipe> userRecipes = recipeDao.GetRecipesByUser(userId);
            if(userRecipes != null)
            {
                return Ok(userRecipes);
            }
            return StatusCode(404);
        }
        [HttpGet("search/ingredient/{ingredient}")]
        public IActionResult SearchByIngredient(string ingredient)
        {
            List<MealRecipe> ingredientRecipes = recipeDao.SearchByIngredient(ingredient);
            if(ingredientRecipes != null)
            {
                return Ok(ingredientRecipes);
            }
            return StatusCode(404);
        }
    }
}
